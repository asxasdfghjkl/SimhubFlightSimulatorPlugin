using System;
using System.Runtime.InteropServices;

namespace SimConnectServer.TelemetryData {

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
	internal struct AirCraftInfo {
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public String Title;
		public int BrakeIndicator;
	};
}
