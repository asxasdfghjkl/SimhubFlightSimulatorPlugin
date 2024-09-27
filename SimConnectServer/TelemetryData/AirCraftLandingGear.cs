using Microsoft.FlightSimulator.SimConnect;
using SimConnectServer.Attributes;
using System.Runtime.InteropServices;

namespace SimConnectServer.TelemetryData {

	[TelemetryStruct(typeof(AirCraftLandingGear))]
	internal struct AirCraftLandingGear {
		[VariableInfo("CONTACT POINT IS ON GROUND:index", "bool", SIMCONNECT_DATATYPE.INT32)]
		public int CONTACT_ON_GROUND;
	}
}