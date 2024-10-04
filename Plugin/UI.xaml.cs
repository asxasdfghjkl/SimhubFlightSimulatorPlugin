using SimHub.Plugins;
using System;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;

namespace JZCoding.Simhub.FlightPlugin {

	public partial class UI : UserControl {
		private readonly FlightPlugin Plugin;
		internal static Process ServerProcess { get; private set; }
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
			if(Plugin.IsSimconnectServerRunning && Plugin.IsUdpListening) {
				this.StatusLight.Fill = Brushes.Green;
				this.BtnStartServer.Visibility = Visibility.Collapsed;
				this.BtnStopServer.Visibility = Visibility.Visible;
			} else if(Plugin.IsSimconnectServerRunning || Plugin.IsUdpListening) {
				this.StatusLight.Fill = Brushes.Yellow;
				this.BtnStartServer.Visibility = Visibility.Visible;
				this.BtnStopServer.Visibility = Visibility.Collapsed;
			} else {
				this.StatusLight.Fill = Brushes.Red;
				this.BtnStartServer.Visibility = Visibility.Visible;
				this.BtnStopServer.Visibility = Visibility.Collapsed;
			}
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
			Plugin.StopSimconnectServer();
			Plugin.StopUdpServer();
			Plugin.StartUdpListener();
			Plugin.StartSimconnectServer();
			this.UpdateUI(sender, e);
		}

		private void BtnStopServer_Click(object sender, RoutedEventArgs e) {
			this.Plugin.StopSimconnectServer();
			this.Plugin.StopUdpServer();
			this.UpdateUI(sender, e);
		}
	}
}
