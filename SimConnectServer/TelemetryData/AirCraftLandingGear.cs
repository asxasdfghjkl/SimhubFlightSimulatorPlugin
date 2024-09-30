using Microsoft.FlightSimulator.SimConnect;
using SimConnectServer.Attributes;
using System.Runtime.InteropServices;

namespace SimConnectServer.TelemetryData {

	[TelemetryStruct(typeof(AirCraftLandingGear))]
	internal struct AirCraftLandingGear {
		[VariableInfo("GEAR IS ON GROUND:1", "bool", SIMCONNECT_DATATYPE.INT32)]
		public int GEAR_IS_ON_GROUND_1;
		[VariableInfo("GEAR IS ON GROUND:2", "bool", SIMCONNECT_DATATYPE.INT32)]
		public int GEAR_IS_ON_GROUND_2;
		[VariableInfo("CONTACT POINT IS ON GROUND:1", "bool", SIMCONNECT_DATATYPE.INT32)]
		public int CONTACT_ON_GROUND_1;
		[VariableInfo("CONTACT POINT IS ON GROUND:2", "bool", SIMCONNECT_DATATYPE.INT32)]
		public int CONTACT_ON_GROUND_2;
		[VariableInfo("CONTACT POINT IS ON GROUND:3", "bool", SIMCONNECT_DATATYPE.INT32)]
		public int CONTACT_ON_GROUND_3;
		[VariableInfo("CONTACT POINT IS ON GROUND:4", "bool", SIMCONNECT_DATATYPE.INT32)]
		public int CONTACT_ON_GROUND_4;
	}
}