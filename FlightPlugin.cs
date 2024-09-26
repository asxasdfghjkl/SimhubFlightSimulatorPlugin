using MahApps.Metro.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimHub.Plugins;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WoteverCommon;
using WoteverCommon.Extensions;

namespace JZCoding.Simhub.GearPlugin {
	[PluginDescription("Flight Simulator Plugin")]
	[PluginAuthor("Jamie")]
	[PluginName("M$FS Plugin")]
	public class FlightPlugin : IPlugin, IWPFSettingsV2 {
		public PluginSettings Settings;

		/// <summary>
		/// Instance of the current plugin manager
		/// </summary>
		public PluginManager PluginManager { get; set; }

		/// <summary>
		/// Gets the left menu icon. Icon must be 24x24 and compatible with black and white display.
		/// </summary>
		public ImageSource PictureIcon => this.ToIcon(Properties.Resources.menuIcon);

		/// <summary>
		/// Gets a short plugin title to show in left menu. Return null if you want to use the title as defined in PluginName attribute.
		/// </summary>
		public string LeftMenuTitle => "M$FS Plugin";
		private UI UI { set; get; }
		private Task UdpTask;
		public FlightPlugin() {
			UI = new UI(this);
		}

		internal TelemetryStates Telemetry { set; get; }

		/// <summary>
		/// Called at plugin manager stop, close/dispose anything needed here !
		/// Plugins are rebuilt at game change
		/// </summary>
		/// <param name="pluginManager"></param>
		public void End(PluginManager pluginManager) {
			// Save settings
			this.SaveCommonSettings(pluginManager.GameName, Settings);
		}

		/// <summary>
		/// Returns the settings control, return null if no settings control is required
		/// </summary>
		/// <param name="pluginManager"></param>
		/// <returns></returns>
		public System.Windows.Controls.Control GetWPFSettingsControl(PluginManager pluginManager) {
			return this.UI;
		}

		/// <summary>
		/// Called once after plugins startup
		/// Plugins are rebuilt at game change
		/// </summary>
		/// <param name="pluginManager"></param>
		public void Init(PluginManager pluginManager) {
			SimHub.Logging.Current.Debug("Starting plugin");
			Settings = this.ReadCommonSettings(nameof(FlightPlugin), () => new PluginSettings());

			this.Telemetry = new TelemetryStates();
			var props = typeof(TelemetryStates).GetProperties();
			foreach(var prop in props) {
				this.AttachDelegate("FlightData." + prop.Name, () => prop.GetValue(this.Telemetry));
			}

			if(UdpTask == null) {
				StartUdpServer();
			}
		}


		private void StartUdpServer() {
			try {

				var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
				socket.Bind(new IPEndPoint(IPAddress.Any, Settings.UdpPort));

				var stateProps = typeof(TelemetryStates).GetProperties();

				UdpTask = Task.Run(() => {
					while(true) {
						var buffer = new byte[1024 * 1024];
						socket.Receive(buffer, SocketFlags.None);
						var content = Encoding.UTF8.GetString(buffer);

						AddLog(content);
						if(!content.StartsWith("{")) {
							continue;
						}

						var obj = JObject.Parse(content);
						foreach(var jToken in obj.Children()) {
							if(jToken is JProperty jProp) {
								var prop = stateProps.FirstOrDefault(p => p.Name == jProp.Name);
								prop?.SetValue(this.Telemetry, Convert.ChangeType(jProp.Value, prop.PropertyType));
							}
						}
					}
				});
			} catch(Exception ex) {
				AddLog($"Can't Listen to UDP Port:{Settings.UdpPort}. {ex.Message}");
			}
		}

		private void AddLog(string message) {
			if(!this.UI.Dispatcher.CheckAccess()) {
				this.UI.Invoke(new Action(() => { AddLog(message); }));
			} else {
				this.UI.Log.Text += (this.UI.Log.Text == "" ? "" : "\n") + message.Replace("\0", "").Trim();
			}
		}
	}
}