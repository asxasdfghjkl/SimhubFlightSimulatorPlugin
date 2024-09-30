using System;
using System.IO;
using System.Windows.Forms;

namespace SimConnectServer {
	internal static class Program {
		/// <summary>
		/// 應用程式的主要進入點。
		/// </summary>
		[STAThread]
		static void Main() {
			var files = new string[] { "SimConnect.dll", "managed\\Microsoft.FlightSimulator.SimConnect.dll" };
			foreach(var file in files) {
				var fileName = Path.GetFileName(file);
				if(!File.Exists(fileName)) {
					var sdkPath = Environment.GetEnvironmentVariable("MSFS_SDK");
					var dllPath = Path.Combine(sdkPath, file);
					if(File.Exists(dllPath)) {
						File.Copy(dllPath, fileName, false);
					}
				}
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
