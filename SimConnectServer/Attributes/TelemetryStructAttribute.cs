using Microsoft.FlightSimulator.SimConnect;
using SimConnectServer.TelemetryData;
using System;
using System.Collections.Generic;

namespace SimConnectServer.Attributes {

	[System.AttributeUsage(AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
	sealed class TelemetryStructAttribute : Attribute {
		public int StructIndex { private set; get; }
		public SIMCONNECT_PERIOD UpdatePeriod { private set; get; }
		public SIMCONNECT_DATA_REQUEST_FLAG RequestFlag { private set; get; }

		internal static List<Type> AllStructs = new List<Type>();

		public TelemetryStructAttribute(
			Type structType,
			SIMCONNECT_PERIOD updatePeriod = SIMCONNECT_PERIOD.SIM_FRAME,
			SIMCONNECT_DATA_REQUEST_FLAG requestFlag = SIMCONNECT_DATA_REQUEST_FLAG.CHANGED
		) {
			this.UpdatePeriod = updatePeriod;
			this.RequestFlag = requestFlag;
			AllStructs.Add(structType);
			this.StructIndex = AllStructs.IndexOf(structType);
		}
	}
}
