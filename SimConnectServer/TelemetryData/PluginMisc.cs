using Microsoft.FlightSimulator.SimConnect;
using SimConnectServer.Attributes;
using System.Runtime.InteropServices;

namespace SimConnectServer.TelemetryData {

	[TelemetryStruct(typeof(PluginMisc))]
	internal struct PluginMisc {
		[VariableInfo("", null, SIMCONNECT_DATATYPE.INT32)]
		public int IS_MSFS_PLUGIN_INSTALLED;
		[VariableInfo("", null, SIMCONNECT_DATATYPE.INT32)]
		public int IS_MSFS_RUNNING;
	}
}