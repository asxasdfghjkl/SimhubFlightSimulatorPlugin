using SimConnectServer.Attributes;
using System;
using System.Runtime.InteropServices;

namespace SimConnectServer.TelemetryData {

	[TelemetryStruct(typeof(AirCraftInfo))]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
	internal struct AirCraftInfo {

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		[VariableInfo("Title", null, Microsoft.FlightSimulator.SimConnect.SIMCONNECT_DATATYPE.STRING128)]
		public string Title;
	};
}
