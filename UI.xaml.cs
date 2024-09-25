using SimHub.Plugins;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace JZCoding.Simhub.GearPlugin {

	public partial class UI : UserControl {
		private readonly FlightPlugin Plugin;
		public UI() {
			InitializeComponent();
		}

		public UI(FlightPlugin plugin) : this() {
			Plugin = plugin;
		}

		private void ClearLog_Click(object sender, RoutedEventArgs e) {
			this.Log.Text = "";
		}
	}
}
