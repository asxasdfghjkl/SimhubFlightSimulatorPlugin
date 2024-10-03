using SimHub.Plugins;
using System;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Threading;

namespace JZCoding.Simhub.GearPlugin {

	public partial class UI : UserControl {
		private readonly FlightPlugin Plugin;
		internal Process ServerProcess { get; private set; }
		public UI() {
			InitializeComponent();
			var timer = new DispatcherTimer() {
				Interval = TimeSpan.FromSeconds(1),
				IsEnabled = true
			};
			timer.Tick += this.UpdateUI;
		}

		private void UpdateUI(object sender, EventArgs e) {
			this.ChkShowLog.IsChecked = Plugin.ShowLogUntil > DateTime.Now;
			this.BtnStartServer.Visibility = (ServerProcess != null && ServerProcess.HasExited == false)
				? Visibility.Collapsed : Visibility.Visible;
			this.BtnStopServer.Visibility = BtnStartServer.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
		}

		public UI(FlightPlugin plugin) : this() {
			Plugin = plugin;
		}

		private void ClearLog_Click(object sender, RoutedEventArgs e) {
			this.Log.Text = "";
		}

		private void ChkShowLog_Toggled(object sender, RoutedEventArgs e) {
			this.Plugin.ShowLogUntil = ChkShowLog.IsChecked == true ? DateTime.Now.AddSeconds(10) : DateTime.MinValue;
			this.UpdateUI(sender, e);
		}

		private void BtnStartServer_Click(object sender, RoutedEventArgs e) {
			if(ServerProcess != null && !ServerProcess.HasExited) {
				ServerProcess.Kill();
			} else {
				ServerProcess = new Process() {
					StartInfo = new ProcessStartInfo {
						FileName = "simconnectserver.exe",
						Arguments = $"--port {this.Plugin.Settings.UdpPort} --hide"
					}
				};
				ServerProcess.Start();
			}
			this.UpdateUI(sender, e);
		}

		private void BtnStopServer_Click(object sender, RoutedEventArgs e) {
			ServerProcess?.Kill();
			this.UpdateUI(sender, e);
		}
	}
}
