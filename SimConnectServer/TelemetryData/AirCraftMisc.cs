using Microsoft.FlightSimulator.SimConnect;
using SimConnectServer.Attributes;
using System.Runtime.InteropServices;

namespace SimConnectServer.TelemetryData {

	[TelemetryStruct(typeof(AirCraftMisc))]
	internal struct AirCraftMisc {
		[VariableInfo("PLANE LATITUDE", "degree", SIMCONNECT_DATATYPE.FLOAT64)]
		public double PLANE_LATITUDE;
		[VariableInfo("PLANE LONGITUDE", "degree", SIMCONNECT_DATATYPE.FLOAT64)]
		public double PLANE_LONGITUDE;
		[VariableInfo("PLANE ALTITUDE", "feet", SIMCONNECT_DATATYPE.FLOAT64)]
		public double PLANE_ALTITUDE;
		[VariableInfo("PLANE ALT ABOVE GROUND", "feet", SIMCONNECT_DATATYPE.FLOAT64)]
		public double PLANE_ALT_ABOVE_GROUND;
		[VariableInfo("ACCELERATION BODY X", "feet", SIMCONNECT_DATATYPE.FLOAT64)]
		public double ACCELERATION_BODY_X;
		[VariableInfo("ACCELERATION BODY Y", "feet", SIMCONNECT_DATATYPE.FLOAT64)]
		public double ACCELERATION_BODY_Y;
		[VariableInfo("ACCELERATION BODY Z", "feet", SIMCONNECT_DATATYPE.FLOAT64)]
		public double ACCELERATION_BODY_Z;
		[VariableInfo("GROUND VELOCITY", "knots", SIMCONNECT_DATATYPE.FLOAT64)]
		public double GROUND_VELOCITY;
		[VariableInfo("AIRSPEED EQUIVALENT", "knots", SIMCONNECT_DATATYPE.FLOAT64)]
		public double AIRSPEED_EQUIVALENT;
		[VariableInfo("AIRSPEED INDICATED", "knots", SIMCONNECT_DATATYPE.FLOAT64)]
		public double AIRSPEED_INDICATED;
		[VariableInfo("VERTICAL SPEED", "feet per minute", SIMCONNECT_DATATYPE.FLOAT64)]
		public double VERTICAL_SPEED;
	}
}