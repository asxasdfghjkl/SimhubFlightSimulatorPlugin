using Microsoft.FlightSimulator.SimConnect;
using SimConnectServer.Attributes;
using System.Runtime.InteropServices;

[TelemetryStruct(typeof(AirCraftNavigation))]
internal struct AirCraftNavigation {

	[VariableInfo("ATC MODEL", null, SIMCONNECT_DATATYPE.STRING128)]
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string ATC_MODEL;
}