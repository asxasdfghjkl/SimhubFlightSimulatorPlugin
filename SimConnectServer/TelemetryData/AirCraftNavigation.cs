using Microsoft.FlightSimulator.SimConnect;
using SimConnectServer.Attributes;
using System.Runtime.InteropServices;

namespace SimConnectServer.TelemetryData {

	[TelemetryStruct(typeof(AirCraftNavigation))]
	internal struct AirCraftNavigation {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		[VariableInfo("ATC MODEL", null, SIMCONNECT_DATATYPE.STRING128)]
		public string ATC_MODEL;
	}
}