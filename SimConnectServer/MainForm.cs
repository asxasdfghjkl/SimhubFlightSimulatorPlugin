using Microsoft.FlightSimulator.SimConnect;
using Newtonsoft.Json;
using SimConnectServer.Attributes;
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
					try {
						Sim?.ReceiveMessage();
					} catch {
					}
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
			Sim.RequestAllTelemety();
		}

		private void Sim_OnRecvSimobjectData(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA data) {
			for(var i = 0; i < TelemetryStructAttribute.AllStructs.Count; ++i) {
				if(data.dwRequestID == i) {
					var json = JsonConvert.SerializeObject(Convert.ChangeType(data.dwData[0], TelemetryStructAttribute.AllStructs[i]));
					_ = SendUdp(json);
				}
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
			this.Log.Text += message + Environment.NewLine;
			this.Log.SelectionStart = this.Log.Text.Length;
			this.Log.ScrollToCaret();
			var bytes = Encoding.UTF8.GetBytes(message);
			var tasks = TextPort.Text.Split(',')
				.Select(port => int.TryParse(port, out var value) ? value : 0)
				.Where(port => port > 0)
				.Select(port => Udp.SendAsync(bytes, bytes.Length, new IPEndPoint(IPAddress.Parse("127.0.0.1"), port)));
			return Task.WhenAll(tasks);
		}

		private void BtnSignalTest_Click(object sender, EventArgs e) {
			_ = SendUdp("Signal Test");
		}

		private void BtnClearLog_Click(object sender, EventArgs e) {
			this.Log.Text = "";
		}
	}
}
