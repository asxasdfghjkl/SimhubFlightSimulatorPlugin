using MahApps.Metro.Controls;
using Newtonsoft.Json.Linq;
using SimHub.Plugins;
using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WoteverCommon.Extensions;

namespace JZCoding.Simhub.GearPlugin {
	[PluginDescription("Flight Simulator Plugin")]
	[PluginAuthor("Jamie")]
	[PluginName("MSFS Plugin")]
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
		public string LeftMenuTitle => "Flight Plugin";
		private UI UI { set; get; }
		private Task UdpListenerTask;
		public DateTime LastUpdateTime { private set; get; } = DateTime.MinValue;
		public DateTime ShowLogUntil { set; get; }

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
			this.UI.ServerProcess.Kill();
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

			this.AttachDelegate("IS_MSFS_PLUGIN_INSTALLED", () => 1);
			this.AttachDelegate("IS_MSFS_DATA_UPDATING", () => {
				var result = (DateTime.Now - LastUpdateTime).TotalSeconds <= 5;
				return result;
			});

			foreach(var prop in props) {
				var nameAttr = prop.GetCustomAttribute<DisplayNameAttribute>(false);

				var propName = nameAttr?.DisplayName ?? "FlightData." + prop.Name;
				this.AttachDelegate(propName, () => prop.GetValue(this.Telemetry));
			}

			if(UdpListenerTask == null) {
				StartUdpListener();
			}
		}



		private void StartUdpListener() {
			try {

				var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
				socket.Bind(new IPEndPoint(IPAddress.Any, Settings.UdpPort));

				var stateProps = typeof(TelemetryStates).GetProperties();

				UdpListenerTask = Task.Run(() => {
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
								if(prop != null) {
									prop.SetValue(this.Telemetry, Convert.ChangeType(jProp.Value, prop.PropertyType));
									LastUpdateTime = DateTime.Now;
								}
							}
						}
					}
				});
			} catch(Exception ex) {
				AddLog($"Can't Listen to UDP Port:{Settings.UdpPort}. {ex.Message}");
			}
		}

		private void AddLog(string message) {
			if(this.ShowLogUntil >= DateTime.Now || !message.StartsWith("{")) {
				if(!this.UI.Dispatcher.CheckAccess()) {
					this.UI.Invoke(new Action(() => { AddLog(message); }));
				} else {
					this.UI.Log.Text += (this.UI.Log.Text == "" ? "" : "\n") + message.Replace("\0", "").Trim();
				}
			}
		}
	}
}