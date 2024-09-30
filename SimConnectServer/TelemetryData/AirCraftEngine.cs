using Microsoft.FlightSimulator.SimConnect;
using SimConnectServer.Attributes;
using System.Runtime.InteropServices;

namespace SimConnectServer.TelemetryData {

	[TelemetryStruct(typeof(AirCraftEngine))]
	internal struct AirCraftEngine {
		[VariableInfo("MAX RATED ENGINE RPM:1", "rpm", SIMCONNECT_DATATYPE.FLOAT64)]
		public double MAX_RATED_ENGINE_RPM_1;
		[VariableInfo("GENERAL ENG PCT MAX RPM:1", "percent", SIMCONNECT_DATATYPE.FLOAT64)]
		public double GENERAL_ENG_PCT_MAX_RPM_1;
		[VariableInfo("GENERAL ENG RPM:1", "rpm", SIMCONNECT_DATATYPE.FLOAT64)]
		public double GENERAL_ENG_RPM_1;
		[VariableInfo("MAX RATED ENGINE RPM:2", "rpm", SIMCONNECT_DATATYPE.FLOAT64)]
		public double MAX_RATED_ENGINE_RPM_2;
		[VariableInfo("GENERAL ENG PCT MAX RPM:2", "percent", SIMCONNECT_DATATYPE.FLOAT64)]
		public double GENERAL_ENG_PCT_MAX_RPM_2;
		[VariableInfo("GENERAL ENG RPM:2", "rpm", SIMCONNECT_DATATYPE.FLOAT64)]
		public double GENERAL_ENG_RPM_2;
		[VariableInfo("MAX RATED ENGINE RPM:3", "rpm", SIMCONNECT_DATATYPE.FLOAT64)]
		public double MAX_RATED_ENGINE_RPM_3;
		[VariableInfo("GENERAL ENG PCT MAX RPM:3", "percent", SIMCONNECT_DATATYPE.FLOAT64)]
		public double GENERAL_ENG_PCT_MAX_RPM_3;
		[VariableInfo("GENERAL ENG RPM:3", "rpm", SIMCONNECT_DATATYPE.FLOAT64)]
		public double GENERAL_ENG_RPM_4;
		[VariableInfo("MAX RATED ENGINE RPM:4", "rpm", SIMCONNECT_DATATYPE.FLOAT64)]
		public double MAX_RATED_ENGINE_RPM_4;
		[VariableInfo("GENERAL ENG PCT MAX RPM:4", "percent", SIMCONNECT_DATATYPE.FLOAT64)]
		public double GENERAL_ENG_PCT_MAX_RPM_4;
		[VariableInfo("GENERAL ENG RPM:4", "rpm", SIMCONNECT_DATATYPE.FLOAT64)]
		public double GENERAL_ENG_RPM_3;
	}
}