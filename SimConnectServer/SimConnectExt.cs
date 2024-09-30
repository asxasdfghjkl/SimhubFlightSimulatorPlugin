using Microsoft.FlightSimulator.SimConnect;
using SimConnectServer.Attributes;
using SimConnectServer.TelemetryData;
using System;
using System.Linq;
using System.Reflection;

namespace SimConnectServer {
	public static class SimConnectExt {

		private static bool IsStructType(TypeInfo info) {
			return info.IsValueType && !info.IsPrimitive && !info.IsInterface;
		}

		public static void RequestAllTelemety(this SimConnect sim) {
			var structs = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsDefined(typeof(TelemetryStructAttribute)));
			foreach(var type in structs) {
				sim.RequestTelemetry(type);
			}
		}

		public static void RequestTelemetry<T>(this SimConnect sim) {
			RequestTelemetry(sim, typeof(T));
		}

		public static void RequestTelemetry(this SimConnect sim, Type structType) {
			var typeInfo = structType.GetTypeInfo();
			var attr = typeInfo.GetCustomAttribute<TelemetryStructAttribute>();
			if(!IsStructType(typeInfo) || attr == null) {
				throw new ArgumentException("[type] needs to be a struct with TelemetryStruct attribute");
			}


			var structIndex = (TelemetryType)attr.StructIndex;

			foreach(var field in typeInfo.GetFields()) {
				var fieldInfo = field.GetCustomAttribute<VariableInfoAttribute>();
				if(fieldInfo != null) {
					sim.AddToDataDefinition(
						structIndex,
						fieldInfo.VariableName,
						fieldInfo.Unit,
						fieldInfo.Type,
						0,
						SimConnect.SIMCONNECT_UNUSED
					);
				} else {
					throw new ArgumentException($"All the fields in [${typeInfo.Name}] should have VariableInfo attribute");
				}
			}
			sim.GetType()
				.GetMethod(nameof(sim.RegisterDataDefineStruct))
				.MakeGenericMethod(structType)
				.Invoke(sim, new object[] { structIndex });
			sim.RequestDataOnSimObject(structIndex, structIndex, SimConnect.SIMCONNECT_OBJECT_ID_USER, attr.UpdatePeriod, attr.RequestFlag, 0, 0, 0);
		}

	}
}
