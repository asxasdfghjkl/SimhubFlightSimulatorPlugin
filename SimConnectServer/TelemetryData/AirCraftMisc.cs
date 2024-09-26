using Microsoft.FlightSimulator.SimConnect;
using SimConnectServer.Attributes;

[TelemetryStruct(typeof(AirCraftMisc))]
internal struct AirCraftMisc {

	[VariableInfo("PLANE LATITUDE", "degree", SIMCONNECT_DATATYPE.INT32)]
	public int PLANE_LATITUDE;

	[VariableInfo("PLANE LONGITUDE", "degree", SIMCONNECT_DATATYPE.INT32)]
	public int PLANE_LONGITUDE;

	[VariableInfo("PLANE ALTITUDE", "feet", SIMCONNECT_DATATYPE.INT32)]
	public int PLANE_ALTITUDE;

	[VariableInfo("PLANE ALT ABOVE GROUND", null, SIMCONNECT_DATATYPE.INT32)]
	public int PLANE_ALT_ABOVE_GROUND;

	[VariableInfo("ACCELERATION BODY X", null, SIMCONNECT_DATATYPE.INT32)]
	public int ACCELERATION_BODY_X;

	[VariableInfo("ACCELERATION BODY Y", null, SIMCONNECT_DATATYPE.INT32)]
	public int ACCELERATION_BODY_Y;

	[VariableInfo("ACCELERATION BODY Z", null, SIMCONNECT_DATATYPE.INT32)]
	public int ACCELERATION_BODY_Z;

	[VariableInfo("GROUND VELOCITY", null, SIMCONNECT_DATATYPE.INT32)]
	public int GROUND_VELOCITY;

	[VariableInfo("AIRSPEED BARBER POLE", null, SIMCONNECT_DATATYPE.INT32)]
	public int AIRSPEED_BARBER_POLE;

	[VariableInfo("AIRSPEED INDICATED", null, SIMCONNECT_DATATYPE.INT32)]
	public int AIRSPEED_INDICATED;

}