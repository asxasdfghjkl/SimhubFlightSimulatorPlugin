using Microsoft.FlightSimulator.SimConnect;
using System;

namespace SimConnectServer.Attributes {

	[System.AttributeUsage(AttributeTargets.Field, Inherited = false)]
	sealed class VariableInfoAttribute : Attribute {

		public string VariableName { set; get; }
		public string Unit { set; get; }
		public SIMCONNECT_DATATYPE Type { set; get; }
		public VariableInfoAttribute(string variableName, string unit, SIMCONNECT_DATATYPE type) {
			this.VariableName = variableName;
			this.Unit = unit;
			this.Type = type;
		}
	}
}
