using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace SimConnectServer {
	internal static class Program {
		/// <summary>
		/// 應用程式的主要進入點。
		/// </summary>
		[STAThread]
		static void Main(string[] args) {
			switch(CheckSdkDll()) {

				case CheckDllResult.Restart:
					Process.Start(new ProcessStartInfo() {
						Arguments = string.Join(" ", args),
						FileName = Application.ExecutablePath
					});
					return;
				case CheckDllResult.Kill:
					return;
			}
			ParseArguments(args);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}


		private enum CheckDllResult {
			Start,
			Kill,
			Restart
		}

		private static CheckDllResult CheckSdkDll() {
			var restart = false;
			var files = new string[] { "SimConnect.dll", "managed\\Microsoft.FlightSimulator.SimConnect.dll" };
			foreach(var file in files) {
				var fileName = Path.GetFileName(file);
				if(!File.Exists(fileName)) {
					restart = true;
					var sdkPath = Environment.GetEnvironmentVariable("MSFS_SDK");
					if(string.IsNullOrWhiteSpace(sdkPath)) {
						MessageBox.Show("MSFS SDK is missing in the directory and also is not detected in the system. Please install MSFS SDK.");
						return CheckDllResult.Kill;
					}
					var dllPath = Path.Combine(sdkPath, "SimConnect SDK\\lib", file);
					if(File.Exists(dllPath)) {
						File.Copy(dllPath, fileName, false);
					} else {
						MessageBox.Show("MSFS SDK is detected but the required files do not exist.");
						return CheckDllResult.Kill;
					}
				}
			}

			return restart ? CheckDllResult.Restart : CheckDllResult.Start;
		}

		private static void ParseArguments(string[] args) {
			int i = 0;
			while(i < args.Length) {
				try {
					switch(args[i]) {
						case "--port":
						case "-p":
							Arguments.Ports = args[i + 1].Split(',')
								.Select(port => int.TryParse(port, out var value) ? value : 0)
								.Where(port => port > 0)
								.ToArray();
							i += 2;
							break;
						case "--show":
							Arguments.ShowWindow = true;
							i += 1;
							break;
						case "--hide":
							Arguments.ShowWindow = false;
							i += 1;
							break;
					}
				} catch(Exception) { }
			}
		}
	}
}
