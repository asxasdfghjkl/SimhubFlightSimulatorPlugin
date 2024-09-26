using Microsoft.FlightSimulator.SimConnect;
using SimConnectServer.Attributes;
using SimConnectServer.TelemetryData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SimConnectServer {
	public static class SimConnectExt {

		private static bool IsStructType(TypeInfo info) {
			return info.IsValueType && !info.IsPrimitive && !info.IsInterface;
		}

		public static void RequestTelemetry<T>(this SimConnect sim) {
			var typeInfo = typeof(T).GetTypeInfo();
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
			sim.RegisterDataDefineStruct<T>(structIndex);
			sim.RequestDataOnSimObject(structIndex, structIndex, SimConnect.SIMCONNECT_OBJECT_ID_USER, attr.UpdatePeriod, attr.RequestFlag, 0, 0, 0);
		}


	}
}
