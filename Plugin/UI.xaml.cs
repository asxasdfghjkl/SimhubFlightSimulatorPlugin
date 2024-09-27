using SimHub.Plugins;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace JZCoding.Simhub.GearPlugin {

	public partial class UI : UserControl {
		private readonly FlightPlugin Plugin;

		public bool ShowLog {
			set { this.Plugin.Settings.ShowLog = value; }
			get { return this.Plugin.Settings.ShowLog; }
		}

		public UI() {
			InitializeComponent();
		}

		public UI(FlightPlugin plugin) : this() {
			Plugin = plugin;
		}

		private void ClearLog_Click(object sender, RoutedEventArgs e) {
			this.Log.Text = "";
		}

		private void ChkShowLog_Toggled(object sender, RoutedEventArgs e) {
			this.ShowLog = ChkShowLog.IsChecked == true;
		}
	}
}
