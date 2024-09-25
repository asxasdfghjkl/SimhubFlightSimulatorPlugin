using Microsoft.FlightSimulator.SimConnect;
using Newtonsoft.Json;
using SimConnectServer.TelemetryData;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimConnectServer {
	public partial class MainForm : Form {
		public MainForm() {
			InitializeComponent();
		}
		private readonly UdpClient Udp = new UdpClient();
		private SimConnect Sim;
		private const int WM_USER_SIMCONNECT = 0x0402;

		private void MainForm_Load(object sender, EventArgs e) {
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
			Sim?.Dispose();
		}

		protected override void WndProc(ref Message m) {
			switch(m.Msg) {
				case WM_USER_SIMCONNECT:
					Sim?.ReceiveMessage();
					break;
				default:
					base.WndProc(ref m);
					break;
			}
		}

		private void TimerConnection_Tick(object sender, EventArgs e) {
			if(Sim == null) {
				StartSimconnect();
			}
		}

		private void StartSimconnect() {
			try {
				Sim = new SimConnect("Telemetry UDP", this.Handle, WM_USER_SIMCONNECT, null, 0);
				Sim.OnRecvOpen += this.Sim_OnRecvOpen;
				Sim.OnRecvQuit += this.Sim_OnRecvQuit;
				Sim.OnRecvSimobjectData += this.Sim_OnRecvSimobjectData;
				RegisterDataRequest();
			} catch(COMException) {
				_ = SendUdp("MSFS Disconnected");
			}
		}

		private void RegisterDataRequest() {
			//msfs.AddToDataDefinition(SimConnectStructs.AirCraftInfo, "Title", null, SIMCONNECT_DATATYPE.STRING256, 0, SimConnect.SIMCONNECT_UNUSED);
			//msfs.AddToDataDefinition(SimConnectStructs.AirCraftInfo, "Airspeed True", "knots", SIMCONNECT_DATATYPE.FLOAT64, 0, SimConnect.SIMCONNECT_UNUSED);
			//msfs.AddToDataDefinition(SimConnectStructs.AirCraftInfo, "Trailing Edge Flaps Left Percent", "percent", SIMCONNECT_DATATYPE.FLOAT64, 0, SimConnect.SIMCONNECT_UNUSED);
			//msfs.AddToDataDefinition(SimConnectStructs.AirCraftInfo, "Spoilers Handle Position", "percent", SIMCONNECT_DATATYPE.FLOAT64, 0, SimConnect.SIMCONNECT_UNUSED);
			//msfs.RegisterDataDefineStruct<AirCraftInfo>(SimConnectStructs.AirCraftInfo);
			//msfs.RequestDataOnSimObject(SimConnectStructs.AirCraftInfo, SimConnectStructs.AirCraftInfo, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SECOND, SIMCONNECT_DATA_REQUEST_FLAG.CHANGED, 0, 0, 0);

			Sim.AddToDataDefinition(SimConnectStructs.RudderInfo, "RUDDER DEFLECTION", "degree", SIMCONNECT_DATATYPE.INT32, 0, SimConnect.SIMCONNECT_UNUSED);
			Sim.AddToDataDefinition(SimConnectStructs.RudderInfo, "RUDDER PEDAL INDICATOR", "position", SIMCONNECT_DATATYPE.INT32, 0, SimConnect.SIMCONNECT_UNUSED);
			Sim.AddToDataDefinition(SimConnectStructs.RudderInfo, "RUDDER PEDAL POSITION", "position", SIMCONNECT_DATATYPE.INT32, 0, SimConnect.SIMCONNECT_UNUSED);
			Sim.AddToDataDefinition(SimConnectStructs.RudderInfo, "RUDDER POSITION", "position", SIMCONNECT_DATATYPE.INT32, 0, SimConnect.SIMCONNECT_UNUSED);
			Sim.AddToDataDefinition(SimConnectStructs.RudderInfo, "RUDDER TRIM", "degree", SIMCONNECT_DATATYPE.INT32, 0, SimConnect.SIMCONNECT_UNUSED);
			Sim.AddToDataDefinition(SimConnectStructs.RudderInfo, "RUDDER TRIM DISABLED", "bool", SIMCONNECT_DATATYPE.INT32, 0, SimConnect.SIMCONNECT_UNUSED);
			Sim.RegisterDataDefineStruct<RudderInfo>(SimConnectStructs.RudderInfo);
			Sim.RequestDataOnSimObject(SimConnectStructs.RudderInfo, SimConnectStructs.RudderInfo, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SECOND, SIMCONNECT_DATA_REQUEST_FLAG.CHANGED, 0, 0, 0);
		}

		private void Sim_OnRecvSimobjectData(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA data) {
			if(data.dwRequestID == (int)SimConnectStructs.AirCraftInfo) {
				var payload = (AirCraftInfo)data.dwData[0];
				var json = JsonConvert.SerializeObject(payload);
				_ = SendUdp(json);
			} else if(data.dwRequestID == (int)SimConnectStructs.RudderInfo) {
				var payload = (RudderInfo)data.dwData[0];
				var json = JsonConvert.SerializeObject(payload);
				_ = SendUdp(json);
			}
		}

		private void Sim_OnRecvQuit(SimConnect sender, SIMCONNECT_RECV data) {
			this.Text = "Disconnected";
			this.Sim = null;
			_ = SendUdp("MSFS Disconnected");
		}

		private void Sim_OnRecvOpen(SimConnect sender, SIMCONNECT_RECV_OPEN data) {
			this.Text = "Connected";
			_ = SendUdp("MSFS Conntected");
		}


		private Task SendUdp(string message) {
			var bytes = Encoding.UTF8.GetBytes(message);
			var tasks = TextPort.Text.Split(',')
				.Select(port => UInt16.TryParse(port, out var value) ? value : 0)
				.Where(port => port > 0)
				.Select(port => Udp.SendAsync(bytes, bytes.Length, new IPEndPoint(IPAddress.Parse("127.0.0.1"), port)));
			return Task.WhenAll(tasks);
		}

		private void button1_Click(object sender, EventArgs e) {
			_ = SendUdp("Signal Test");
		}
	}
}
