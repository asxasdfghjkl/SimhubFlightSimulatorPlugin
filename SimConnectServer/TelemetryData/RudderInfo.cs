using Microsoft.FlightSimulator.SimConnect;
using SimConnectServer.Attributes;
using System.Runtime.InteropServices;

namespace SimConnectServer.TelemetryData {
	[TelemetryStruct(typeof(RudderInfo))]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
	internal struct RudderInfo {
		[VariableInfo("RUDDER DEFLECTION", "degree", SIMCONNECT_DATATYPE.INT32)]
		public int Deflection;
		[VariableInfo("RUDDER PEDAL INDICATOR", "position", SIMCONNECT_DATATYPE.INT32)]
		public int PedalIndicator;
		[VariableInfo("RUDDER PEDAL POSITION", "position", SIMCONNECT_DATATYPE.INT32)]
		public int PedalPosition;
		[VariableInfo("RUDDER POSITION", "position", SIMCONNECT_DATATYPE.INT32)]
		public int Position;
		[VariableInfo("RUDDER TRIM", "degree", SIMCONNECT_DATATYPE.INT32)]
		public int Trim;
		[VariableInfo("RUDDER TRIM DISABLED", "bool", SIMCONNECT_DATATYPE.INT32)]
		public int TrimDisabled;
	}
}
