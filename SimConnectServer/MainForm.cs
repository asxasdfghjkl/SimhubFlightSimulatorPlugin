using Microsoft.FlightSimulator.SimConnect;
using Newtonsoft.Json;
using SimConnectServer.Attributes;
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
		private DateTime ShowLogUntil = DateTime.MinValue;
		private SimConnect Sim;
		private const int WM_USER_SIMCONNECT = 0x0402;

		private void MainForm_Load(object sender, EventArgs e) {
			this.TextPort.Text = string.Join(",", Arguments.Ports);
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
			Sim?.Dispose();
		}

		protected override void WndProc(ref Message m) {
			switch(m.Msg) {
				case WM_USER_SIMCONNECT:
					try {
						Sim?.ReceiveMessage();
					} catch(Exception ex) {
						this.Log.Text += ex.Message + Environment.NewLine;
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
			ChkShowLog.Checked = ShowLogUntil >= DateTime.Now;
		}

		private void StartSimconnect() {
			try {
				Sim = new SimConnect("Telemetry UDP", this.Handle, WM_USER_SIMCONNECT, null, 0);
				Sim.OnRecvOpen += this.Sim_OnRecvOpen;
				Sim.OnRecvQuit += this.Sim_OnRecvQuit;
				Sim.OnRecvSimobjectData += this.Sim_OnRecvSimobjectData;
				RegisterDataRequest();
			} catch(COMException) {
				_ = SendUdp("{\"IS_MSFS_RUNNING\": 0}");
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
			_ = _ = SendUdp("{\"IS_MSFS_RUNNING\": 0}");
		}

		private void Sim_OnRecvOpen(SimConnect sender, SIMCONNECT_RECV_OPEN data) {
			this.Text = "Connected";
			_ = SendUdp("{\"IS_MSFS_RUNNING\": 1}");
		}


		private Task SendUdp(string message) {
			if(ShowLogUntil >= DateTime.Now || !message.StartsWith("{")) {
				this.Log.Text += message + Environment.NewLine;
				this.Log.SelectionStart = this.Log.Text.Length;
				this.Log.ScrollToCaret();
			}
			var bytes = Encoding.UTF8.GetBytes(message);
			var tasks = Arguments.Ports.Select(port =>
				Udp.SendAsync(bytes, bytes.Length, new IPEndPoint(IPAddress.Parse("127.0.0.1"), port))
			);
			return Task.WhenAll(tasks);
		}

		private void BtnSignalTest_Click(object sender, EventArgs e) {
			_ = SendUdp("Signal Test");
		}

		private void BtnClearLog_Click(object sender, EventArgs e) {
			this.Log.Text = "";
		}

		private void ChkShowLog_CheckedChanged(object sender, EventArgs e) {
			ShowLogUntil = ChkShowLog.Checked ? DateTime.Now.AddSeconds(10) : DateTime.MinValue;
		}

		private void MainForm_Shown(object sender, EventArgs e) {
			if(!Arguments.ShowWindow) {
				this.Hide();
			}
		}

		private void SysTrayIcon_MouseDoubleClick(object sender, MouseEventArgs e) {
			this.Show();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
			if(!Arguments.ShowWindow && e.CloseReason == CloseReason.UserClosing) {
				e.Cancel = true;
				this.Hide();
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Application.Exit();
		}

		private void showWindowToolStripMenuItem_Click(object sender, EventArgs e) {
			this.Show();
		}
	}
}
