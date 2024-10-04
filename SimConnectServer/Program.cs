using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace SimConnectServer {
	internal static class Program {
		/// <summary>
		/// 應用程式的主要進入點。
		/// </summary>
		[STAThread]
		static void Main(string[] args) {
			ParseArguments(args);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
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
