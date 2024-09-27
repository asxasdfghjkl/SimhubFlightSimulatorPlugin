using Microsoft.FlightSimulator.SimConnect;
using SimConnectServer.Attributes;
using System.Runtime.InteropServices;

namespace SimConnectServer.TelemetryData {

	[TelemetryStruct(typeof(AirCraftEngine))]
	internal struct AirCraftEngine {
		[VariableInfo("ENG MAX RPM:1", "rpm", SIMCONNECT_DATATYPE.INT32)]
		public int ENGING1_RPM_MAX;
		[VariableInfo("ENG N1 RPM:1", "rpm", SIMCONNECT_DATATYPE.INT32)]
		public int ENGING1_RPM_N1;
		[VariableInfo("ENG N2 RPM:1", "rpm", SIMCONNECT_DATATYPE.INT32)]
		public int ENGING1_RPM_N2;
		[VariableInfo("ENG MAX RPM:2", "rpm", SIMCONNECT_DATATYPE.INT32)]
		public int ENGING2_RPM_MAX;
		[VariableInfo("ENG N1 RPM:2", "rpm", SIMCONNECT_DATATYPE.INT32)]
		public int ENGING2_RPM_N1;
		[VariableInfo("ENG N2 RPM:2", "rpm", SIMCONNECT_DATATYPE.INT32)]
		public int ENGING2_RPM_N2;
		[VariableInfo("ENG MAX RPM:3", "rpm", SIMCONNECT_DATATYPE.INT32)]
		public int ENGING3_RPM_MAX;
		[VariableInfo("ENG N1 RPM:3", "rpm", SIMCONNECT_DATATYPE.INT32)]
		public int ENGING3_RPM_N1;
		[VariableInfo("ENG N2 RPM:3", "rpm", SIMCONNECT_DATATYPE.INT32)]
		public int ENGING3_RPM_N2;
		[VariableInfo("ENG MAX RPM:4", "rpm", SIMCONNECT_DATATYPE.INT32)]
		public int ENGING4_RPM_MAX;
		[VariableInfo("ENG N1 RPM:4", "rpm", SIMCONNECT_DATATYPE.INT32)]
		public int ENGING4_RPM_N1;
		[VariableInfo("ENG N2 RPM:4", "rpm", SIMCONNECT_DATATYPE.INT32)]
		public int ENGING4_RPM_N2;
	}
}