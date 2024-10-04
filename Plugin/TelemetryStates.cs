namespace JZCoding.Simhub.FlightPlugin {
  internal class TelemetryStates {
    public double PLANE_LATITUDE { set;get; }
    public double PLANE_LONGITUDE { set;get; }
    public double PLANE_ALTITUDE { set;get; }
    public double PLANE_ALT_ABOVE_GROUND { set;get; }
    public double ACCELERATION_BODY_X { set;get; }
    public double ACCELERATION_BODY_Y { set;get; }
    public double ACCELERATION_BODY_Z { set;get; }
    public double GROUND_VELOCITY { set;get; }
    public double AIRSPEED_EQUIVALENT { set;get; }
    public double AIRSPEED_INDICATED { set;get; }
    public double VERTICAL_SPEED { set;get; }
    public string ATC_MODEL { set;get; }
    public double MAX_RATED_ENGINE_RPM_1 { set;get; }
    public double GENERAL_ENG_PCT_MAX_RPM_1 { set;get; }
    public double GENERAL_ENG_RPM_1 { set;get; }
    public double MAX_RATED_ENGINE_RPM_2 { set;get; }
    public double GENERAL_ENG_PCT_MAX_RPM_2 { set;get; }
    public double GENERAL_ENG_RPM_2 { set;get; }
    public double MAX_RATED_ENGINE_RPM_3 { set;get; }
    public double GENERAL_ENG_PCT_MAX_RPM_3 { set;get; }
    public double GENERAL_ENG_RPM_4 { set;get; }
    public double MAX_RATED_ENGINE_RPM_4 { set;get; }
    public double GENERAL_ENG_PCT_MAX_RPM_4 { set;get; }
    public double GENERAL_ENG_RPM_3 { set;get; }
    public int GEAR_IS_ON_GROUND_1 { set;get; }
    public int GEAR_IS_ON_GROUND_2 { set;get; }
    public int CONTACT_ON_GROUND_1 { set;get; }
    public int CONTACT_ON_GROUND_2 { set;get; }
    public int CONTACT_ON_GROUND_3 { set;get; }
    public int CONTACT_ON_GROUND_4 { set;get; }
    public double RUDDER_DEFLECTION { set;get; }
    public double RELATIVE_WIND_VELOCITY_BODY_X { set;get; }
    public double RELATIVE_WIND_VELOCITY_BODY_Y { set;get; }
    public double RELATIVE_WIND_VELOCITY_BODY_Z { set;get; }
  }
}