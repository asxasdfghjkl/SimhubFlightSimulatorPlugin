using SimConnectServer.Attributes;

namespace SimConnectServer.TelemetryData {
	[TelemetryStruct(typeof(AirCraftLandingGear))]
	internal struct AirCraftLandingGear {
		[VariableInfo("CONTACT POINT IS ON GROUND:index", "bool", Microsoft.FlightSimulator.SimConnect.SIMCONNECT_DATATYPE.INT32)]
		public int CONTACT_ON_GROUND;
	}
}
