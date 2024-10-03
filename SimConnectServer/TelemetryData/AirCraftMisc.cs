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
		[VariableInfo("RUDDER DEFLECTION", "radians", SIMCONNECT_DATATYPE.FLOAT64)]
		public double RUDDER_DEFLECTION;
		[VariableInfo("RELATIVE WIND VELOCITY BODY X", "knots", SIMCONNECT_DATATYPE.FLOAT64)]
		public double RELATIVE_WIND_VELOCITY_BODY_X;
		[VariableInfo("RELATIVE WIND VELOCITY BODY Y", "knots", SIMCONNECT_DATATYPE.FLOAT64)]
		public double RELATIVE_WIND_VELOCITY_BODY_Y;
		[VariableInfo("RELATIVE WIND VELOCITY BODY Z", "knots", SIMCONNECT_DATATYPE.FLOAT64)]
		public double RELATIVE_WIND_VELOCITY_BODY_Z;
	}
}