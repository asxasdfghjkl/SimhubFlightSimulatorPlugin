namespace JZCoding.Simhub.GearPlugin {
	/// <summary>
	/// Settings class, make sure it can be correctly serialized using JSON.net
	/// </summary>
	public class PluginSettings {
		public int UdpPort { set; get; } = 56789;
		public bool ShowLog { set; get; } = false;
	}
}