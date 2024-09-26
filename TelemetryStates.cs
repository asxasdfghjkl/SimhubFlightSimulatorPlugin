namespace JZCoding.Simhub.GearPlugin {
	internal class TelemetryStates {
		public int CONTACT_ON_GROUND { set; get; }
		public int ENGINE_RPM_MAX { set; get; }
		public int ENGINE_RPM_N1 { set; get; }
		public int ENGINE_RPM_N2 { set; get; }
		public int PLANE_LATITUDE { set; get; }
		public int PLANE_LONGITUDE { set; get; }
		public int PLANE_ALTITUDE { set; get; }
		public int PLANE_ALT_ABOVE_GROUND { set; get; }
		public int ACCELERATION_BODY_X { set; get; }
		public int ACCELERATION_BODY_Y { set; get; }
		public int ACCELERATION_BODY_Z { set; get; }
		public int GROUND_VELOCITY { set; get; }
		public int AIRSPEED_BARBER_POLE { set; get; }
		public int AIRSPEED_INDICATED { set; get; }
		public string ATC_MODEL { set; get; }
	}
}