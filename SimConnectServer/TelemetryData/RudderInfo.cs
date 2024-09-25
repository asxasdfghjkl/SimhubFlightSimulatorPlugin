using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimConnectServer.TelemetryData {
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
	internal struct RudderInfo {
		public int Deflection;
		public int PedalIndicator;
		public int PedalPosition;
		public int Position;
		public int Trim;
		public int TrimDisabled;
	}
}
