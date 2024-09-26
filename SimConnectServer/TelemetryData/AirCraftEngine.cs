using Microsoft.FlightSimulator.SimConnect;
using SimConnectServer.Attributes;
using System;

[TelemetryStruct(typeof(AirCraftEngine))]
internal struct AirCraftEngine {

	[VariableInfo("ENG MAX RPM", "rpm", SIMCONNECT_DATATYPE.INT32)]
	public int ENGINE_RPM_MAX;

	[VariableInfo("ENG N1 RPM:index", "rpm", SIMCONNECT_DATATYPE.INT32)]
	public int ENGINE_RPM_N1;

	[VariableInfo("ENG N2 RPM:index", "rpm", SIMCONNECT_DATATYPE.INT32)]
	public int ENGINE_RPM_N2;

}