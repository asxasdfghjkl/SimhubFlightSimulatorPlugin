using Microsoft.FlightSimulator.SimConnect;

namespace SimConnectUDP {
	public partial class WinMain : Form {
		public WinMain() {
			InitializeComponent();
		}

		SimConnect? MSFS = null;
		const int WM_USER_SIMCONNECT = 0x0402;

		private void MainForm_Load(object sender, EventArgs e) {
			// this.Hide();

			MSFS = new SimConnect("Telemetry UDP", this.Handle, WM_USER_SIMCONNECT, null, 0);
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
			MSFS?.Dispose();
		}
	}
}
