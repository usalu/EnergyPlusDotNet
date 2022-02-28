namespace EnergyPlus.LocationandClimate
{
    using System.ComponentModel;
    using EnergyPlus;
    using System;
    using System.Globalization;
    using Newtonsoft.Json;
    using EnergyPlus.AdvancedConstructionSurfaceZoneConcepts;
    using EnergyPlus.AirDistribution;
    using EnergyPlus.AirflowNetwork;
    using EnergyPlus.Coils;
    using EnergyPlus.ComplianceObjects;
    using EnergyPlus.CondenserEquipmentandHeatExchangers;
    using EnergyPlus.Controllers;
    using EnergyPlus.Daylighting;
    using EnergyPlus.DemandLimitingControls;
    using EnergyPlus.DetailedGroundHeatTransfer;
    using EnergyPlus.Economics;
    using EnergyPlus.ElectricLoadCenterGeneratorSpecifications;
    using EnergyPlus.EnergyManagementSystemEMS;
    using EnergyPlus.EvaporativeCoolers;
    using EnergyPlus.ExteriorEquipment;
    using EnergyPlus.ExternalInterface;
    using EnergyPlus.Fans;
    using EnergyPlus.FluidProperties;
    using EnergyPlus.GeneralDataEntry;
    using EnergyPlus.HeatRecovery;
    using EnergyPlus.HumidifiersandDehumidifiers;
    using EnergyPlus.HVACDesignObjects;
    using EnergyPlus.HVACTemplates;
    using EnergyPlus.HybridModel;
    using EnergyPlus.InternalGains;
    using EnergyPlus.NodeBranchManagement;
    using EnergyPlus.NonZoneEquipment;
    using EnergyPlus.OperationalFaults;
    using EnergyPlus.OutputReporting;
    using EnergyPlus.Parametrics;
    using EnergyPlus.PerformanceCurves;
    using EnergyPlus.PerformanceTables;
    using EnergyPlus.PlantHeatingandCoolingEquipment;
    using EnergyPlus.PlantCondenserControl;
    using EnergyPlus.PlantCondenserFlowControl;
    using EnergyPlus.PlantCondenserLoops;
    using EnergyPlus.Pumps;
    using EnergyPlus.PythonPluginSystem;
    using EnergyPlus.Refrigeration;
    using EnergyPlus.RoomAirModels;
    using EnergyPlus.Schedules;
    using EnergyPlus.SetpointManagers;
    using EnergyPlus.SimulationParameters;
    using EnergyPlus.SolarCollectors;
    using EnergyPlus.SurfaceConstructionElements;
    using EnergyPlus.SystemAvailabilityManagers;
    using EnergyPlus.ThermalZonesandSurfaces;
    using EnergyPlus.UnitaryEquipment;
    using EnergyPlus.UserDefinedHVACandPlantComponentModels;
    using EnergyPlus.VariableRefrigerantFlowEquipment;
    using EnergyPlus.WaterHeatersandThermalStorage;
    using EnergyPlus.WaterSystems;
    using EnergyPlus.ZoneAirflow;
    using EnergyPlus.ZoneHVACAirLoopTerminalUnits;
    using EnergyPlus.ZoneHVACControlsandThermostats;
    using EnergyPlus.ZoneHVACEquipmentConnections;
    using EnergyPlus.ZoneHVACForcedAirUnits;
    using EnergyPlus.ZoneHVACRadiativeConvectiveUnits;
    
    
    [Description("Specifies the building\'s location. Only one location is allowed. Weather data fil" +
        "e location, if it exists, will override this object.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Site_Location
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("+ is North, - is South, degree minutes represented in decimal (i.e. 30 minutes is" +
    " .5)")]
[JsonProperty(PropertyName="latitude", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Latitude { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("- is West, + is East, degree minutes represented in decimal (i.e. 30 minutes is ." +
    "5)")]
[JsonProperty(PropertyName="longitude", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Longitude { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("basic these limits on the WorldTimeZone Map (2003) Time relative to GMT. Decimal " +
    "hours.")]
[JsonProperty(PropertyName="time_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TimeZone { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="elevation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Elevation { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    [Description("Captures the scheduling of a moving/reorienting building, or more likely a vessel" +
        "")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Site_VariableLocation
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("The name of a schedule that defines the latitude of the building at any time. If " +
    "not entered, the latitude defined in the Site:Location, or the default latitude," +
    " will be used for the entirety of the simulation")]
[JsonProperty(PropertyName="building_location_latitude_schedule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BuildingLocationLatitudeSchedule { get; set; } = "";
        

[Description("The name of a schedule that defines the longitude of the building at any time. If" +
    " not entered, the longitude defined in the Site:Location, or the default longitu" +
    "de, will be used for the entirety of the simulation")]
[JsonProperty(PropertyName="building_location_longitude_schedule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BuildingLocationLongitudeSchedule { get; set; } = "";
        

[Description(@"The name of a schedule that defines the orientation of the building at any time. This orientation is based on a change from the original orientation. -- NEED TO REFINE THIS If not entered, the original orientation will be used for the entirety of the simulation")]
[JsonProperty(PropertyName="building_location_orientation_schedule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BuildingLocationOrientationSchedule { get; set; } = "";
    }
    
    [Description(@"The design day object creates the parameters for the program to create the 24 hour weather profile that can be used for sizing as well as running to test the other simulation parameters. Parameters in this include a date (month and day), a day type (which uses the appropriate schedules for either sizing or simple tests), min/max temperatures, wind speeds, and solar radiation values.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SizingPeriod_DesignDay
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="month", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Month { get; set; } = null;
        

[Description("must be valid for Month field")]
[JsonProperty(PropertyName="day_of_month", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DayOfMonth { get; set; } = null;
        

[Description("Day Type selects the schedules appropriate for this design day")]
[JsonProperty(PropertyName="day_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SizingPeriod_DesignDay_DayType DayType { get; set; } = (SizingPeriod_DesignDay_DayType)Enum.Parse(typeof(SizingPeriod_DesignDay_DayType), "CustomDay1");
        

[Description("This field is required when field \"Dry-Bulb Temperature Range Modifier Type\" is n" +
    "ot \"TemperatureProfileSchedule\".")]
[JsonProperty(PropertyName="maximum_dry_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumDryBulbTemperature { get; set; } = null;
        

[Description("Must still produce appropriate maximum dry-bulb (within range) This field is not " +
    "needed if Dry-Bulb Temperature Range Modifier Type is \"delta\".")]
[JsonProperty(PropertyName="daily_dry_bulb_temperature_range", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DailyDryBulbTemperatureRange { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Type of modifier to the dry-bulb temperature calculated for the timestep")]
[JsonProperty(PropertyName="dry_bulb_temperature_range_modifier_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SizingPeriod_DesignDay_DryBulbTemperatureRangeModifierType DryBulbTemperatureRangeModifierType { get; set; } = (SizingPeriod_DesignDay_DryBulbTemperatureRangeModifierType)Enum.Parse(typeof(SizingPeriod_DesignDay_DryBulbTemperatureRangeModifierType), "DefaultMultipliers");
        

[Description(@"Only used when previous field is ""MultiplierSchedule"", ""DifferenceSchedule"" or ""TemperatureProfileSchedule"". For type ""MultiplierSchedule""  the hour/time interval values should specify the fraction (0-1) of the dry-bulb temperature range to be subtracted from the maximum dry-bulb temperature for each timestep in the day For type ""DifferenceSchedule"" the values should specify a number to be subtracted from the maximum dry-bulb temperature for each timestep in the day. Note that numbers in the difference schedule cannot be negative as that would result in a higher maximum than the maximum previously specified. For type ""TemperatureProfileSchedule"" the values should specify the actual dry-bulb temperature for each timestep in the day.")]
[JsonProperty(PropertyName="dry_bulb_temperature_range_modifier_day_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DryBulbTemperatureRangeModifierDayScheduleName { get; set; } = "";
        

[Description("values/schedules indicated here and in subsequent fields create the humidity valu" +
    "es in the 24 hour design day conditions profile.")]
[JsonProperty(PropertyName="humidity_condition_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SizingPeriod_DesignDay_HumidityConditionType HumidityConditionType { get; set; } = (SizingPeriod_DesignDay_HumidityConditionType)Enum.Parse(typeof(SizingPeriod_DesignDay_HumidityConditionType), "WetBulb");
        

[Description("Wetbulb or dewpoint temperature coincident with the maximum temperature. Required" +
    " only if field Humidity Condition Type is \"Wetbulb\", \"Dewpoint\", \"WetBulbProfile" +
    "MultiplierSchedule\", \"WetBulbProfileDifferenceSchedule\", or \"WetBulbProfileDefau" +
    "ltMultipliers\"")]
[JsonProperty(PropertyName="wetbulb_or_dewpoint_at_maximum_dry_bulb", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetbulbOrDewpointAtMaximumDryBulb { get; set; } = null;
        

[Description(@"Only used when Humidity Condition Type is ""RelativeHumiditySchedule"", ""WetBulbProfileMultiplierSchedule"", or ""WetBulbProfileDifferenceSchedule"" For type ""RelativeHumiditySchedule"", the hour/time interval values should specify relative humidity (percent) from 0.0 to 100.0. For type ""WetBulbProfileMultiplierSchedule"" the hour/time interval values should specify the fraction (0-1) of the wet-bulb temperature range to be subtracted from the maximum wet-bulb temperature for each timestep in the day (units = Fraction) For type ""WetBulbProfileDifferenceSchedule"" the values should specify a number to be subtracted from the maximum wet-bulb temperature for each timestep in the day. (units = deltaC)")]
[JsonProperty(PropertyName="humidity_condition_day_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HumidityConditionDayScheduleName { get; set; } = "";
        

[Description("Humidity ratio coincident with the maximum temperature (constant humidity ratio t" +
    "hroughout day). Required only if field Humidity Condition Type is \"HumidityRatio" +
    "\".")]
[JsonProperty(PropertyName="humidity_ratio_at_maximum_dry_bulb", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidityRatioAtMaximumDryBulb { get; set; } = null;
        

[Description("Enthalpy coincident with the maximum temperature. Required only if field Humidity" +
    " Condition Type is \"Enthalpy\".")]
[JsonProperty(PropertyName="enthalpy_at_maximum_dry_bulb", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EnthalpyAtMaximumDryBulb { get; set; } = null;
        

[Description("Required only if Humidity Condition Type = \"WetbulbProfileMultiplierSchedule\" or " +
    "\"WetBulbProfileDefaultMultipliers\"")]
[JsonProperty(PropertyName="daily_wet_bulb_temperature_range", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DailyWetBulbTemperatureRange { get; set; } = null;
        

[Description("This field\'s value is also checked against the calculated \"standard barometric pr" +
    "essure\" for the location. If out of range (>10%) or blank, then is replaced by s" +
    "tandard value.")]
[JsonProperty(PropertyName="barometric_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BarometricPressure { get; set; } = null;
        

[JsonProperty(PropertyName="wind_speed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WindSpeed { get; set; } = null;
        

[Description("North=0.0 East=90.0 0 and 360 are the same direction.")]
[JsonProperty(PropertyName="wind_direction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WindDirection { get; set; } = null;
        

[Description("Yes is raining (all day), No is not raining")]
[JsonProperty(PropertyName="rain_indicator", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes RainIndicator { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("Yes is Snow on Ground, No is no Snow on Ground")]
[JsonProperty(PropertyName="snow_indicator", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes SnowIndicator { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("Yes -- use schedules modified for Daylight Saving Time Schedules. No - do not use" +
    " schedules modified for Daylight Saving Time Schedules")]
[JsonProperty(PropertyName="daylight_saving_time_indicator", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes DaylightSavingTimeIndicator { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[JsonProperty(PropertyName="solar_model_indicator", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SizingPeriod_DesignDay_SolarModelIndicator SolarModelIndicator { get; set; } = (SizingPeriod_DesignDay_SolarModelIndicator)Enum.Parse(typeof(SizingPeriod_DesignDay_SolarModelIndicator), "ASHRAEClearSky");
        

[Description("if Solar Model Indicator = Schedule, then beam schedule name (for day)")]
[JsonProperty(PropertyName="beam_solar_day_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BeamSolarDayScheduleName { get; set; } = "";
        

[Description("if Solar Model Indicator = Schedule, then diffuse schedule name (for day)")]
[JsonProperty(PropertyName="diffuse_solar_day_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DiffuseSolarDayScheduleName { get; set; } = "";
        

[Description("Required if Solar Model Indicator = ASHRAETau or ASHRAETau2017 ASHRAETau2017 sola" +
    "r model can be used with 2013 and 2017 HOF matching taub")]
[JsonProperty(PropertyName="ashrae_clear_sky_optical_depth_for_beam_irradiance_taub_", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AshraeClearSkyOpticalDepthForBeamIrradianceTaub { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Required if Solar Model Indicator = ASHRAETau or ASHRAETau2017 ASHRAETau2017 sola" +
    "r model can be used with 2013 and 2017 HOF matching taud")]
[JsonProperty(PropertyName="ashrae_clear_sky_optical_depth_for_diffuse_irradiance_taud_", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AshraeClearSkyOpticalDepthForDiffuseIrradianceTaud { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Used if Sky Model Indicator = ASHRAEClearSky or ZhangHuang 0.0 is totally unclear" +
    ", 1.0 is totally clear")]
[JsonProperty(PropertyName="sky_clearness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SkyClearness { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("If used this design day will be run with a custom limit on the maximum number of " +
    "days that are repeated for warmup. Limiting the number of warmup days can improv" +
    "e run time.")]
[JsonProperty(PropertyName="maximum_number_warmup_days", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumNumberWarmupDays { get; set; } = null;
        

[Description("If used this can control if you want the thermal history to be reset at the begin" +
    "ning of the design day. When using a series of similiar design days, this field " +
    "can be used to retain warmup state from the previous design day.")]
[JsonProperty(PropertyName="begin_environment_reset_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SizingPeriod_DesignDay_BeginEnvironmentResetMode BeginEnvironmentResetMode { get; set; } = (SizingPeriod_DesignDay_BeginEnvironmentResetMode)Enum.Parse(typeof(SizingPeriod_DesignDay_BeginEnvironmentResetMode), "FullResetAtBeginEnvironment");
    }
    
    public enum SizingPeriod_DesignDay_DayType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="CustomDay1")]
        CustomDay1 = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CustomDay2")]
        CustomDay2 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Friday")]
        Friday = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Holiday")]
        Holiday = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Monday")]
        Monday = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Saturday")]
        Saturday = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="SummerDesignDay")]
        SummerDesignDay = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="Sunday")]
        Sunday = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Thursday")]
        Thursday = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Tuesday")]
        Tuesday = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Wednesday")]
        Wednesday = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="WinterDesignDay")]
        WinterDesignDay = 11,
    }
    
    public enum SizingPeriod_DesignDay_DryBulbTemperatureRangeModifierType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DefaultMultipliers")]
        DefaultMultipliers = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferenceSchedule")]
        DifferenceSchedule = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MultiplierSchedule")]
        MultiplierSchedule = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureProfileSchedule")]
        TemperatureProfileSchedule = 4,
    }
    
    public enum SizingPeriod_DesignDay_HumidityConditionType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DewPoint")]
        DewPoint = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Enthalpy")]
        Enthalpy = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HumidityRatio")]
        HumidityRatio = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="RelativeHumiditySchedule")]
        RelativeHumiditySchedule = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="WetBulb")]
        WetBulb = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="WetBulbProfileDefaultMultipliers")]
        WetBulbProfileDefaultMultipliers = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="WetBulbProfileDifferenceSchedule")]
        WetBulbProfileDifferenceSchedule = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="WetBulbProfileMultiplierSchedule")]
        WetBulbProfileMultiplierSchedule = 8,
    }
    
    public enum SizingPeriod_DesignDay_SolarModelIndicator
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAEClearSky")]
        ASHRAEClearSky = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAETau")]
        ASHRAETau = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAETau2017")]
        ASHRAETau2017 = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Schedule")]
        Schedule = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="ZhangHuang")]
        ZhangHuang = 5,
    }
    
    public enum SizingPeriod_DesignDay_BeginEnvironmentResetMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FullResetAtBeginEnvironment")]
        FullResetAtBeginEnvironment = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SuppressAllBeginEnvironmentResets")]
        SuppressAllBeginEnvironmentResets = 2,
    }
    
    [Description("Use a weather file period for design sizing calculations.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SizingPeriod_WeatherFileDays
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="begin_month", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BeginMonth { get; set; } = null;
        

[JsonProperty(PropertyName="begin_day_of_month", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BeginDayOfMonth { get; set; } = null;
        

[JsonProperty(PropertyName="end_month", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EndMonth { get; set; } = null;
        

[JsonProperty(PropertyName="end_day_of_month", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EndDayOfMonth { get; set; } = null;
        

[Description(@"=[|Sunday|Monday|Tuesday|Wednesday|Thursday|Friday|Saturday|SummerDesignDay|WinterDesignDay| |CustomDay1|CustomDay2]; if you use SummerDesignDay or WinterDesignDay or the CustomDays then this will apply to the whole period; other days (i.e., Monday) will signify a start day and normal sequence of subsequent days")]
[JsonProperty(PropertyName="day_of_week_for_start_day", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SizingPeriod_WeatherFileDays_DayOfWeekForStartDay DayOfWeekForStartDay { get; set; } = (SizingPeriod_WeatherFileDays_DayOfWeekForStartDay)Enum.Parse(typeof(SizingPeriod_WeatherFileDays_DayOfWeekForStartDay), "Monday");
        

[Description("If yes or blank, use daylight saving period as specified on Weatherfile. If no, d" +
    "o not use the daylight saving period as specified on the Weatherfile.")]
[JsonProperty(PropertyName="use_weather_file_daylight_saving_period", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes UseWeatherFileDaylightSavingPeriod { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="use_weather_file_rain_and_snow_indicators", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes UseWeatherFileRainAndSnowIndicators { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
    }
    
    public enum SizingPeriod_WeatherFileDays_DayOfWeekForStartDay
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CustomDay1")]
        CustomDay1 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CustomDay2")]
        CustomDay2 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Friday")]
        Friday = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Monday")]
        Monday = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Saturday")]
        Saturday = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="SummerDesignDay")]
        SummerDesignDay = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="Sunday")]
        Sunday = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Thursday")]
        Thursday = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Tuesday")]
        Tuesday = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Wednesday")]
        Wednesday = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="WinterDesignDay")]
        WinterDesignDay = 11,
    }
    
    [Description("Use a weather file period for design sizing calculations. EPW weather files are c" +
        "reated with typical and extreme periods created heuristically from the weather f" +
        "ile data. For more details on these periods, see AuxiliaryPrograms document.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SizingPeriod_WeatherFileConditionType
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Following is a list of all possible types of Extreme and Typical periods that mig" +
    "ht be identified in the Weather File. Not all possible types are available for a" +
    "ll weather files.")]
[JsonProperty(PropertyName="period_selection", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SizingPeriod_WeatherFileConditionType_PeriodSelection PeriodSelection { get; set; } = (SizingPeriod_WeatherFileConditionType_PeriodSelection)Enum.Parse(typeof(SizingPeriod_WeatherFileConditionType_PeriodSelection), "AutumnTypical");
        

[Description(@"=[|Sunday|Monday|Tuesday|Wednesday|Thursday|Friday|Saturday|SummerDesignDay|WinterDesignDay| |CustomDay1|CustomDay2]; if you use SummerDesignDay or WinterDesignDay or the CustomDays then this will apply to the whole period; other days (i.e., Monday) will signify a start day and normal sequence of subsequent days")]
[JsonProperty(PropertyName="day_of_week_for_start_day", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SizingPeriod_WeatherFileConditionType_DayOfWeekForStartDay DayOfWeekForStartDay { get; set; } = (SizingPeriod_WeatherFileConditionType_DayOfWeekForStartDay)Enum.Parse(typeof(SizingPeriod_WeatherFileConditionType_DayOfWeekForStartDay), "Monday");
        

[Description("If yes or blank, use daylight saving period as specified on Weatherfile. If no, d" +
    "o not use the daylight saving period as specified on the Weatherfile.")]
[JsonProperty(PropertyName="use_weather_file_daylight_saving_period", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes UseWeatherFileDaylightSavingPeriod { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="use_weather_file_rain_and_snow_indicators", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes UseWeatherFileRainAndSnowIndicators { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
    }
    
    public enum SizingPeriod_WeatherFileConditionType_PeriodSelection
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AutumnTypical")]
        AutumnTypical = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DrySeason")]
        DrySeason = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="NoDrySeason")]
        NoDrySeason = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="NoDrySeasonMax")]
        NoDrySeasonMax = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="NoDrySeasonMin")]
        NoDrySeasonMin = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="NoWetSeason")]
        NoWetSeason = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="NoWetSeasonMax")]
        NoWetSeasonMax = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="NoWetSeasonMin")]
        NoWetSeasonMin = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="SpringTypical")]
        SpringTypical = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="SummerExtreme")]
        SummerExtreme = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="SummerTypical")]
        SummerTypical = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="TropicalCold")]
        TropicalCold = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="TropicalHot")]
        TropicalHot = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="WetSeason")]
        WetSeason = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="WinterExtreme")]
        WinterExtreme = 14,
        
        [System.Runtime.Serialization.EnumMember(Value="WinterTypical")]
        WinterTypical = 15,
    }
    
    public enum SizingPeriod_WeatherFileConditionType_DayOfWeekForStartDay
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CustomDay1")]
        CustomDay1 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CustomDay2")]
        CustomDay2 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Friday")]
        Friday = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Monday")]
        Monday = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Saturday")]
        Saturday = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="SummerDesignDay")]
        SummerDesignDay = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="Sunday")]
        Sunday = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Thursday")]
        Thursday = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Tuesday")]
        Tuesday = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Wednesday")]
        Wednesday = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="WinterDesignDay")]
        WinterDesignDay = 11,
    }
    
    [Description("Specify a range of dates and other parameters for a simulation. Multiple run peri" +
        "ods may be input, but they may not overlap.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RunPeriod
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="begin_month", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BeginMonth { get; set; } = null;
        

[JsonProperty(PropertyName="begin_day_of_month", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BeginDayOfMonth { get; set; } = null;
        

[Description("Start year of the simulation, if this field is specified it must agree with the D" +
    "ay of Week for Start Day If this field is blank, the year will be selected to ma" +
    "tch the weekday, which is Sunday if not specified")]
[JsonProperty(PropertyName="begin_year", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BeginYear { get; set; } = null;
        

[JsonProperty(PropertyName="end_month", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EndMonth { get; set; } = null;
        

[JsonProperty(PropertyName="end_day_of_month", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EndDayOfMonth { get; set; } = null;
        

[Description("end year of simulation, if specified")]
[JsonProperty(PropertyName="end_year", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EndYear { get; set; } = null;
        

[Description("=[Sunday|Monday|Tuesday|Wednesday|Thursday|Friday|Saturday]; If no year is input," +
    " this field will default to Sunday If a year is input and this field is blank, t" +
    "he correct weekday is determined")]
[JsonProperty(PropertyName="day_of_week_for_start_day", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public RunPeriod_DayOfWeekForStartDay DayOfWeekForStartDay { get; set; } = (RunPeriod_DayOfWeekForStartDay)Enum.Parse(typeof(RunPeriod_DayOfWeekForStartDay), "Friday");
        

[Description("If yes or blank, use holidays as specified on Weatherfile. If no, do not use the " +
    "holidays specified on the Weatherfile. Note: You can still specify holidays/spec" +
    "ial days using the RunPeriodControl:SpecialDays object(s).")]
[JsonProperty(PropertyName="use_weather_file_holidays_and_special_days", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes UseWeatherFileHolidaysAndSpecialDays { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[Description("If yes or blank, use daylight saving period as specified on Weatherfile. If no, d" +
    "o not use the daylight saving period as specified on the Weatherfile.")]
[JsonProperty(PropertyName="use_weather_file_daylight_saving_period", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes UseWeatherFileDaylightSavingPeriod { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[Description("if yes and single day holiday falls on weekend, \"holiday\" occurs on following Mon" +
    "day")]
[JsonProperty(PropertyName="apply_weekend_holiday_rule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes ApplyWeekendHolidayRule { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[JsonProperty(PropertyName="use_weather_file_rain_indicators", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes UseWeatherFileRainIndicators { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="use_weather_file_snow_indicators", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes UseWeatherFileSnowIndicators { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="treat_weather_as_actual", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes TreatWeatherAsActual { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
    }
    
    public enum RunPeriod_DayOfWeekForStartDay
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Friday")]
        Friday = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Monday")]
        Monday = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Saturday")]
        Saturday = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Sunday")]
        Sunday = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Thursday")]
        Thursday = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Tuesday")]
        Tuesday = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Wednesday")]
        Wednesday = 6,
    }
    
    [Description(@"This object sets up holidays/special days to be used during weather file run periods. (These are not used with SizingPeriod:* objects.) Depending on the value in the run period, days on the weather file may also be used. However, the weather file specification will take precedence over any specification shown here. (No error message on duplicate days or overlapping days).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RunPeriodControl_SpecialDays
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description(@"Dates can be several formats: <number>/<number>  (month/day) <number> <Month> <Month> <number> <Nth> <Weekday> in <Month) Last <WeekDay> in <Month> <Month> can be January, February, March, April, May, June, July, August, September, October, November, December Months can be the first 3 letters of the month <Weekday> can be Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday <Nth> can be 1 or 1st, 2 or 2nd, etc. up to 5(?)")]
[JsonProperty(PropertyName="start_date", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string StartDate { get; set; } = "";
        

[JsonProperty(PropertyName="duration", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Duration { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Special Day Type selects the schedules appropriate for each day so labeled")]
[JsonProperty(PropertyName="special_day_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public RunPeriodControl_SpecialDays_SpecialDayType SpecialDayType { get; set; } = (RunPeriodControl_SpecialDays_SpecialDayType)Enum.Parse(typeof(RunPeriodControl_SpecialDays_SpecialDayType), "Holiday");
    }
    
    public enum RunPeriodControl_SpecialDays_SpecialDayType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CustomDay1")]
        CustomDay1 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CustomDay2")]
        CustomDay2 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Holiday")]
        Holiday = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="SummerDesignDay")]
        SummerDesignDay = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="WinterDesignDay")]
        WinterDesignDay = 5,
    }
    
    [Description(@"This object sets up the daylight saving time period for any RunPeriod. Ignores any daylight saving time period on the weather file and uses this definition. These are not used with SizingPeriod:DesignDay objects. Use with SizingPeriod:WeatherFileDays object can be controlled in that object.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RunPeriodControl_DaylightSavingTime
    {
        

[JsonProperty(PropertyName="start_date", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string StartDate { get; set; } = "";
        

[Description(@"Dates can be several formats: <number>/<number>  (month/day) <number> <Month> <Month> <number> <Nth> <Weekday> in <Month) Last <WeekDay> in <Month> <Month> can be January, February, March, April, May, June, July, August, September, October, November, December Months can be the first 3 letters of the month <Weekday> can be Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday <Nth> can be 1 or 1st, 2 or 2nd, etc. up to 5(?)")]
[JsonProperty(PropertyName="end_date", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndDate { get; set; } = "";
    }
    
    [Description("This object is used to override internal sky temperature calculations.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WeatherProperty_SkyTemperature
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("The field indicates that the sky temperature will be imported from external sched" +
    "ules or calculated by alternative methods other than default.")]
[JsonProperty(PropertyName="calculation_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WeatherProperty_SkyTemperature_CalculationType CalculationType { get; set; } = (WeatherProperty_SkyTemperature_CalculationType)Enum.Parse(typeof(WeatherProperty_SkyTemperature_CalculationType), "ClarkAllen");
        

[Description(@"if name matches a SizingPeriod:DesignDay, put in a day schedule of this name if name is for a SizingPeriod:WeatherFileDays, SizingPeriod:WeatherFileConditionType or RunPeriod, put in a full year schedule that covers the appropriate days. Required if Calculation Type is ScheduleValue, DifferenceScheduleDryBulbValue or DifferenceScheduleDewPointValue.")]
[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[Description(@"If yes or blank, use Horizontal IR values from weather file when present, otherwise use the specified sky model. If no, always use the specified sky model and ignore the horizontal IR values from the weather file. For Calculation Type = ScheduleValue, DifferenceScheduleDryBulbValue or DifferenceScheduleDewPointValue, this field is ignored and the scheduled values are used.")]
[JsonProperty(PropertyName="use_weather_file_horizontal_ir", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes UseWeatherFileHorizontalIr { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
    }
    
    public enum WeatherProperty_SkyTemperature_CalculationType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BerdahlMartin")]
        BerdahlMartin = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Brunt")]
        Brunt = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ClarkAllen")]
        ClarkAllen = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferenceScheduleDewPointValue")]
        DifferenceScheduleDewPointValue = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferenceScheduleDryBulbValue")]
        DifferenceScheduleDryBulbValue = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Idso")]
        Idso = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="ScheduleValue")]
        ScheduleValue = 7,
    }
    
    [Description("This object should only be used for non-standard weather data. Standard weather d" +
        "ata such as TMY2, IWEC, and ASHRAE design day data are all measured at the defau" +
        "lt conditions and do not require this object.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Site_WeatherStation
    {
        

[JsonProperty(PropertyName="wind_sensor_height_above_ground", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WindSensorHeightAboveGround { get; set; } = Double.Parse("10", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="wind_speed_profile_exponent", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WindSpeedProfileExponent { get; set; } = Double.Parse("0.14", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="wind_speed_profile_boundary_layer_thickness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WindSpeedProfileBoundaryLayerThickness { get; set; } = Double.Parse("270", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="air_temperature_sensor_height_above_ground", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AirTemperatureSensorHeightAboveGround { get; set; } = Double.Parse("1.5", CultureInfo.InvariantCulture);
    }
    
    [Description(@"This object is used if the user requires advanced control over height-dependent variations in wind speed and temperature. When this object is not present, the default model for temperature dependence on height is used, and the wind speed is modeled according to the Terrain field of the BUILDING object.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Site_HeightVariation
    {
        

[Description("Set to zero for no wind speed dependence on height.")]
[JsonProperty(PropertyName="wind_speed_profile_exponent", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WindSpeedProfileExponent { get; set; } = Double.Parse("0.22", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="wind_speed_profile_boundary_layer_thickness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WindSpeedProfileBoundaryLayerThickness { get; set; } = Double.Parse("370", CultureInfo.InvariantCulture);
        

[Description("Set to zero for no air temperature dependence on height.")]
[JsonProperty(PropertyName="air_temperature_gradient_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AirTemperatureGradientCoefficient { get; set; } = Double.Parse("0.0065", CultureInfo.InvariantCulture);
    }
    
    [Description(@"These temperatures are specifically for those surfaces that have the outside environment of ""Ground"". Documentation about what values these should be is located in the Auxiliary programs document (Ground Heat Transfer) as well as the InputOutput Reference. CAUTION - Do not use the ""undisturbed"" ground temperatures from the weather data. These values are too extreme for the soil under a conditioned building. For best results, use the Slab or Basement program to calculate custom monthly average ground temperatures (see Auxiliary Programs). For typical commercial buildings in the USA, a reasonable default value is 2C less than the average indoor space temperature.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Site_GroundTemperature_BuildingSurface
    {
        

[JsonProperty(PropertyName="january_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> JanuaryGroundTemperature { get; set; } = Double.Parse("18", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="february_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FebruaryGroundTemperature { get; set; } = Double.Parse("18", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="march_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MarchGroundTemperature { get; set; } = Double.Parse("18", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="april_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AprilGroundTemperature { get; set; } = Double.Parse("18", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="may_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MayGroundTemperature { get; set; } = Double.Parse("18", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="june_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> JuneGroundTemperature { get; set; } = Double.Parse("18", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="july_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> JulyGroundTemperature { get; set; } = Double.Parse("18", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="august_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AugustGroundTemperature { get; set; } = Double.Parse("18", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="september_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SeptemberGroundTemperature { get; set; } = Double.Parse("18", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="october_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OctoberGroundTemperature { get; set; } = Double.Parse("18", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="november_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NovemberGroundTemperature { get; set; } = Double.Parse("18", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="december_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DecemberGroundTemperature { get; set; } = Double.Parse("18", CultureInfo.InvariantCulture);
    }
    
    [Description("These temperatures are specifically for underground walls and ground floors defin" +
        "ed with the C-factor and F-factor methods, and should be close to the monthly av" +
        "erage outdoor air temperature delayed by 3 months for the location.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Site_GroundTemperature_FCfactorMethod
    {
        

[JsonProperty(PropertyName="january_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> JanuaryGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="february_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FebruaryGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="march_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MarchGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="april_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AprilGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="may_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MayGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="june_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> JuneGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="july_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> JulyGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="august_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AugustGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="september_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SeptemberGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="october_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OctoberGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="november_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NovemberGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="december_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DecemberGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
    }
    
    [Description("These temperatures are specifically for the Surface Ground Heat Exchanger and sho" +
        "uld probably be close to the average outdoor air temperature for the location. T" +
        "hey are not used in other models.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Site_GroundTemperature_Shallow
    {
        

[JsonProperty(PropertyName="january_surface_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> JanuarySurfaceGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="february_surface_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FebruarySurfaceGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="march_surface_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MarchSurfaceGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="april_surface_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AprilSurfaceGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="may_surface_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaySurfaceGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="june_surface_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> JuneSurfaceGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="july_surface_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> JulySurfaceGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="august_surface_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AugustSurfaceGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="september_surface_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SeptemberSurfaceGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="october_surface_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OctoberSurfaceGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="november_surface_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NovemberSurfaceGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="december_surface_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DecemberSurfaceGroundTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
    }
    
    [Description("These temperatures are specifically for the ground heat exchangers that would use" +
        " \"deep\" (3-4 m depth) ground temperatures for their heat source. They are not us" +
        "ed in other models.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Site_GroundTemperature_Deep
    {
        

[JsonProperty(PropertyName="january_deep_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> JanuaryDeepGroundTemperature { get; set; } = Double.Parse("16", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="february_deep_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FebruaryDeepGroundTemperature { get; set; } = Double.Parse("16", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="march_deep_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MarchDeepGroundTemperature { get; set; } = Double.Parse("16", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="april_deep_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AprilDeepGroundTemperature { get; set; } = Double.Parse("16", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="may_deep_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MayDeepGroundTemperature { get; set; } = Double.Parse("16", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="june_deep_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> JuneDeepGroundTemperature { get; set; } = Double.Parse("16", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="july_deep_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> JulyDeepGroundTemperature { get; set; } = Double.Parse("16", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="august_deep_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AugustDeepGroundTemperature { get; set; } = Double.Parse("16", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="september_deep_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SeptemberDeepGroundTemperature { get; set; } = Double.Parse("16", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="october_deep_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OctoberDeepGroundTemperature { get; set; } = Double.Parse("16", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="november_deep_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NovemberDeepGroundTemperature { get; set; } = Double.Parse("16", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="december_deep_ground_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DecemberDeepGroundTemperature { get; set; } = Double.Parse("16", CultureInfo.InvariantCulture);
    }
    
    [Description("Undisturbed ground temperature object using a detailed finite difference 1-D mode" +
        "l")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Site_GroundTemperature_Undisturbed_FiniteDifference
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="soil_thermal_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilThermalConductivity { get; set; } = null;
        

[JsonProperty(PropertyName="soil_density", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilDensity { get; set; } = null;
        

[JsonProperty(PropertyName="soil_specific_heat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilSpecificHeat { get; set; } = null;
        

[JsonProperty(PropertyName="soil_moisture_content_volume_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilMoistureContentVolumeFraction { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_moisture_content_volume_fraction_at_saturation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilMoistureContentVolumeFractionAtSaturation { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[Description(@"This specifies the ground cover effects during evapotranspiration calculations. The value roughly represents the following cases: = 0   : concrete or other solid, non-permeable ground surface material = 0.5 : short grass, much like a manicured lawn = 1   : standard reference state (12 cm grass) = 1.5 : wild growth")]
[JsonProperty(PropertyName="evapotranspiration_ground_cover_parameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvapotranspirationGroundCoverParameter { get; set; } = Double.Parse("0.4", CultureInfo.InvariantCulture);
    }
    
    [Description("Undisturbed ground temperature object using the Kusuda-Achenbach 1965 correlation" +
        ".")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Site_GroundTemperature_Undisturbed_KusudaAchenbach
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="soil_thermal_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilThermalConductivity { get; set; } = null;
        

[JsonProperty(PropertyName="soil_density", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilDensity { get; set; } = null;
        

[JsonProperty(PropertyName="soil_specific_heat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilSpecificHeat { get; set; } = null;
        

[Description("Annual average surface temperature If left blank the Site:GroundTemperature:Shall" +
    "ow object must be included in the input The soil temperature, amplitude, and pha" +
    "se shift must all be included or omitted together")]
[JsonProperty(PropertyName="average_soil_surface_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AverageSoilSurfaceTemperature { get; set; } = null;
        

[Description("Annual average surface temperature variation from average. If left blank the Site" +
    ":GroundTemperature:Shallow object must be included in the input The soil tempera" +
    "ture, amplitude, and phase shift must all be included or omitted together")]
[JsonProperty(PropertyName="average_amplitude_of_surface_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AverageAmplitudeOfSurfaceTemperature { get; set; } = null;
        

[Description(@"The phase shift of minimum surface temperature, or the day of the year when the minimum surface temperature occurs. If left blank the Site:GroundTemperature:Shallow object must be included in the input The soil temperature, amplitude, and phase shift must all be included or omitted together")]
[JsonProperty(PropertyName="phase_shift_of_minimum_surface_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PhaseShiftOfMinimumSurfaceTemperature { get; set; } = null;
    }
    
    [Description("Undisturbed ground temperature object using the Xing 2014 2 harmonic parameter mo" +
        "del.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Site_GroundTemperature_Undisturbed_Xing
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="soil_thermal_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilThermalConductivity { get; set; } = null;
        

[JsonProperty(PropertyName="soil_density", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilDensity { get; set; } = null;
        

[JsonProperty(PropertyName="soil_specific_heat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilSpecificHeat { get; set; } = null;
        

[JsonProperty(PropertyName="average_soil_surface_tempeature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AverageSoilSurfaceTempeature { get; set; } = null;
        

[JsonProperty(PropertyName="soil_surface_temperature_amplitude_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilSurfaceTemperatureAmplitude1 { get; set; } = null;
        

[JsonProperty(PropertyName="soil_surface_temperature_amplitude_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilSurfaceTemperatureAmplitude2 { get; set; } = null;
        

[JsonProperty(PropertyName="phase_shift_of_temperature_amplitude_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PhaseShiftOfTemperatureAmplitude1 { get; set; } = null;
        

[JsonProperty(PropertyName="phase_shift_of_temperature_amplitude_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PhaseShiftOfTemperatureAmplitude2 { get; set; } = null;
    }
    
    [Description("Ground-coupled slab model for on-grade and in-grade cases with or without insulat" +
        "ion.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Site_GroundDomain_Slab
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="ground_domain_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GroundDomainDepth { get; set; } = Double.Parse("10", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="aspect_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AspectRatio { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="perimeter_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PerimeterOffset { get; set; } = Double.Parse("5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_thermal_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilThermalConductivity { get; set; } = Double.Parse("1.5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_density", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilDensity { get; set; } = Double.Parse("2800", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_specific_heat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilSpecificHeat { get; set; } = Double.Parse("850", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_moisture_content_volume_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilMoistureContentVolumeFraction { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_moisture_content_volume_fraction_at_saturation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilMoistureContentVolumeFractionAtSaturation { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="undisturbed_ground_temperature_model_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Site_GroundDomain_Slab_UndisturbedGroundTemperatureModelType UndisturbedGroundTemperatureModelType { get; set; } = (Site_GroundDomain_Slab_UndisturbedGroundTemperatureModelType)Enum.Parse(typeof(Site_GroundDomain_Slab_UndisturbedGroundTemperatureModelType), "SiteGroundTemperatureUndisturbedFiniteDifference");
        

[JsonProperty(PropertyName="undisturbed_ground_temperature_model_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UndisturbedGroundTemperatureModelName { get; set; } = "";
        

[Description(@"This specifies the ground cover effects during evapotranspiration calculations. The value roughly represents the following cases: = 0   : concrete or other solid, non-permeable ground surface material = 0.5 : short grass, much like a manicured lawn = 1   : standard reference state (12 cm grass) = 1.5 : wild growth")]
[JsonProperty(PropertyName="evapotranspiration_ground_cover_parameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvapotranspirationGroundCoverParameter { get; set; } = Double.Parse("0.4", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="slab_boundary_condition_model_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SlabBoundaryConditionModelName { get; set; } = "";
        

[Description("This field specifies whether the slab is located \"in-grade\" or \"on-grade\"")]
[JsonProperty(PropertyName="slab_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Site_GroundDomain_Slab_SlabLocation SlabLocation { get; set; } = (Site_GroundDomain_Slab_SlabLocation)Enum.Parse(typeof(Site_GroundDomain_Slab_SlabLocation), "InGrade");
        

[Description("Only applicable for the in-grade case")]
[JsonProperty(PropertyName="slab_material_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SlabMaterialName { get; set; } = "";
        

[Description("This field specifies the presence of insulation beneath the slab. Only required f" +
    "or in-grade case.")]
[JsonProperty(PropertyName="horizontal_insulation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes HorizontalInsulation { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("This field specifies the horizontal insulation material.")]
[JsonProperty(PropertyName="horizontal_insulation_material_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HorizontalInsulationMaterialName { get; set; } = "";
        

[Description("This field specifies whether the horizontal insulation fully insulates the surfac" +
    "e or is perimeter only insulation")]
[JsonProperty(PropertyName="horizontal_insulation_extents", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Site_GroundDomain_Slab_HorizontalInsulationExtents HorizontalInsulationExtents { get; set; } = (Site_GroundDomain_Slab_HorizontalInsulationExtents)Enum.Parse(typeof(Site_GroundDomain_Slab_HorizontalInsulationExtents), "Full");
        

[Description("This field specifies the width of the underfloor perimeter insulation")]
[JsonProperty(PropertyName="perimeter_insulation_width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PerimeterInsulationWidth { get; set; } = null;
        

[Description("This field specifies the presence of vertical insulation at the slab edge.")]
[JsonProperty(PropertyName="vertical_insulation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes VerticalInsulation { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("This field specifies the vertical insulation material.")]
[JsonProperty(PropertyName="vertical_insulation_material_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string VerticalInsulationMaterialName { get; set; } = "";
        

[Description("Only used when including vertical insulation This field specifies the depth of th" +
    "e vertical insulation")]
[JsonProperty(PropertyName="vertical_insulation_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VerticalInsulationDepth { get; set; } = null;
        

[Description("This field specifies the ground domain simulation timestep.")]
[JsonProperty(PropertyName="simulation_timestep", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Site_GroundDomain_Slab_SimulationTimestep SimulationTimestep { get; set; } = (Site_GroundDomain_Slab_SimulationTimestep)Enum.Parse(typeof(Site_GroundDomain_Slab_SimulationTimestep), "Hourly");
        

[JsonProperty(PropertyName="geometric_mesh_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GeometricMeshCoefficient { get; set; } = Double.Parse("1.6", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="mesh_density_parameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MeshDensityParameter { get; set; } = Double.Parse("6", CultureInfo.InvariantCulture);
    }
    
    public enum Site_GroundDomain_Slab_UndisturbedGroundTemperatureModelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:Undisturbed:FiniteDifference")]
        SiteGroundTemperatureUndisturbedFiniteDifference = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:Undisturbed:KusudaAchenbach")]
        SiteGroundTemperatureUndisturbedKusudaAchenbach = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:Undisturbed:Xing")]
        SiteGroundTemperatureUndisturbedXing = 2,
    }
    
    public enum Site_GroundDomain_Slab_SlabLocation
    {
        
        [System.Runtime.Serialization.EnumMember(Value="InGrade")]
        InGrade = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="OnGrade")]
        OnGrade = 1,
    }
    
    public enum Site_GroundDomain_Slab_HorizontalInsulationExtents
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Full")]
        Full = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Perimeter")]
        Perimeter = 2,
    }
    
    public enum Site_GroundDomain_Slab_SimulationTimestep
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Hourly")]
        Hourly = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Timestep")]
        Timestep = 2,
    }
    
    [Description("Ground-coupled basement model for simulating basements or other underground zones" +
        ".")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Site_GroundDomain_Basement
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("The depth from ground surface to the deep ground boundary of the domain.")]
[JsonProperty(PropertyName="ground_domain_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GroundDomainDepth { get; set; } = Double.Parse("10", CultureInfo.InvariantCulture);
        

[Description("This defines the height to width ratio of the basement zone.")]
[JsonProperty(PropertyName="aspect_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AspectRatio { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("The distance from the basement wall edge to the edge of the ground domain")]
[JsonProperty(PropertyName="perimeter_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PerimeterOffset { get; set; } = Double.Parse("5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_thermal_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilThermalConductivity { get; set; } = Double.Parse("1.5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_density", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilDensity { get; set; } = Double.Parse("2800", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_specific_heat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilSpecificHeat { get; set; } = Double.Parse("850", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_moisture_content_volume_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilMoistureContentVolumeFraction { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_moisture_content_volume_fraction_at_saturation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilMoistureContentVolumeFractionAtSaturation { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="undisturbed_ground_temperature_model_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Site_GroundDomain_Basement_UndisturbedGroundTemperatureModelType UndisturbedGroundTemperatureModelType { get; set; } = (Site_GroundDomain_Basement_UndisturbedGroundTemperatureModelType)Enum.Parse(typeof(Site_GroundDomain_Basement_UndisturbedGroundTemperatureModelType), "SiteGroundTemperatureUndisturbedFiniteDifference");
        

[JsonProperty(PropertyName="undisturbed_ground_temperature_model_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UndisturbedGroundTemperatureModelName { get; set; } = "";
        

[Description(@"This specifies the ground cover effects during evapotranspiration calculations. The value roughly represents the following cases: = 0   : concrete or other solid, non-permeable ground surface material = 0.5 : short grass, much like a manicured lawn = 1   : standard reference state (12 cm grass) = 1.5 : wild growth")]
[JsonProperty(PropertyName="evapotranspiration_ground_cover_parameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvapotranspirationGroundCoverParameter { get; set; } = Double.Parse("0.4", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="basement_floor_boundary_condition_model_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BasementFloorBoundaryConditionModelName { get; set; } = "";
        

[Description("This field specifies the presence of insulation beneath the basement floor.")]
[JsonProperty(PropertyName="horizontal_insulation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes HorizontalInsulation { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[JsonProperty(PropertyName="horizontal_insulation_material_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HorizontalInsulationMaterialName { get; set; } = "";
        

[Description("This field specifies whether the horizontal insulation fully insulates the surfac" +
    "e or is perimeter only insulation")]
[JsonProperty(PropertyName="horizontal_insulation_extents", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Site_GroundDomain_Basement_HorizontalInsulationExtents HorizontalInsulationExtents { get; set; } = (Site_GroundDomain_Basement_HorizontalInsulationExtents)Enum.Parse(typeof(Site_GroundDomain_Basement_HorizontalInsulationExtents), "Full");
        

[Description("Width of horizontal perimeter insulation measured from foundation wall inside sur" +
    "face.")]
[JsonProperty(PropertyName="perimeter_horizontal_insulation_width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PerimeterHorizontalInsulationWidth { get; set; } = null;
        

[Description("Depth measured from ground surface.")]
[JsonProperty(PropertyName="basement_wall_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BasementWallDepth { get; set; } = null;
        

[JsonProperty(PropertyName="basement_wall_boundary_condition_model_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BasementWallBoundaryConditionModelName { get; set; } = "";
        

[JsonProperty(PropertyName="vertical_insulation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes VerticalInsulation { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[JsonProperty(PropertyName="basement_wall_vertical_insulation_material_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BasementWallVerticalInsulationMaterialName { get; set; } = "";
        

[Description("Depth measured from the ground surface.")]
[JsonProperty(PropertyName="vertical_insulation_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VerticalInsulationDepth { get; set; } = null;
        

[Description("This field specifies the basement domain simulation interval.")]
[JsonProperty(PropertyName="simulation_timestep", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Site_GroundDomain_Basement_SimulationTimestep SimulationTimestep { get; set; } = (Site_GroundDomain_Basement_SimulationTimestep)Enum.Parse(typeof(Site_GroundDomain_Basement_SimulationTimestep), "Hourly");
        

[JsonProperty(PropertyName="mesh_density_parameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MeshDensityParameter { get; set; } = Double.Parse("4", CultureInfo.InvariantCulture);
    }
    
    public enum Site_GroundDomain_Basement_UndisturbedGroundTemperatureModelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:Undisturbed:FiniteDifference")]
        SiteGroundTemperatureUndisturbedFiniteDifference = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:Undisturbed:KusudaAchenbach")]
        SiteGroundTemperatureUndisturbedKusudaAchenbach = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:Undisturbed:Xing")]
        SiteGroundTemperatureUndisturbedXing = 2,
    }
    
    public enum Site_GroundDomain_Basement_HorizontalInsulationExtents
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Full")]
        Full = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Perimeter")]
        Perimeter = 2,
    }
    
    public enum Site_GroundDomain_Basement_SimulationTimestep
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Hourly")]
        Hourly = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Timestep")]
        Timestep = 2,
    }
    
    [Description("Specifies the ground reflectance values used to calculate ground reflected solar." +
        " The ground reflectance can be further modified when snow is on the ground by Si" +
        "te:GroundReflectance:SnowModifier.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Site_GroundReflectance
    {
        

[JsonProperty(PropertyName="january_ground_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> JanuaryGroundReflectance { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="february_ground_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FebruaryGroundReflectance { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="march_ground_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MarchGroundReflectance { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="april_ground_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AprilGroundReflectance { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="may_ground_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MayGroundReflectance { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="june_ground_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> JuneGroundReflectance { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="july_ground_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> JulyGroundReflectance { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="august_ground_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AugustGroundReflectance { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="september_ground_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SeptemberGroundReflectance { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="october_ground_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OctoberGroundReflectance { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="november_ground_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NovemberGroundReflectance { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="december_ground_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DecemberGroundReflectance { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
    }
    
    [Description("Specifies ground reflectance multipliers when snow resident on the ground. These " +
        "multipliers are applied to the \"normal\" ground reflectances specified in Site:Gr" +
        "oundReflectance.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Site_GroundReflectance_SnowModifier
    {
        

[Description(@"Value for modifying the ""normal"" ground reflectance when Snow is on ground when calculating the ""Ground Reflected Solar Radiation Value"" a value of 1.0 here uses the ""normal"" ground reflectance Ground Reflected Solar = (BeamSolar*CosSunZenith + DiffuseSolar)*GroundReflectance This would be further modified by the Snow Ground Reflectance Modifier when Snow was on the ground When Snow on ground, effective GroundReflectance is normal GroundReflectance*""Ground Reflectance Snow Modifier"" Ground Reflectance achieved in this manner will be restricted to [0.0,1.0]")]
[JsonProperty(PropertyName="ground_reflected_solar_modifier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GroundReflectedSolarModifier { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description(@"Value for modifying the ""normal"" daylighting ground reflectance when Snow is on ground when calculating the ""Ground Reflected Solar Radiation Value"" a value of 1.0 here uses the ""normal"" ground reflectance Ground Reflected Solar = (BeamSolar*CosSunZenith + DiffuseSolar)*GroundReflectance This would be further modified by the Snow Ground Reflectance Modifier when Snow was on the ground When Snow on ground, effective GroundReflectance is normal GroundReflectance*""Daylighting Ground Reflectance Snow Modifier"" Ground Reflectance achieved in this manner will be restricted to [0.0,1.0]")]
[JsonProperty(PropertyName="daylighting_ground_reflected_solar_modifier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DaylightingGroundReflectedSolarModifier { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
    }
    
    [Description("Used to calculate water mains temperatures delivered by underground water main pi" +
        "pes. Water mains temperatures are a function of outdoor climate conditions and v" +
        "ary with time of year.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Site_WaterMainsTemperature
    {
        

[Description("If calculation method is CorrelationFromWeatherFile, the two numeric input fields" +
    " are ignored. Instead, EnergyPlus calculates them from weather file.")]
[JsonProperty(PropertyName="calculation_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Site_WaterMainsTemperature_CalculationMethod CalculationMethod { get; set; } = (Site_WaterMainsTemperature_CalculationMethod)Enum.Parse(typeof(Site_WaterMainsTemperature_CalculationMethod), "CorrelationFromWeatherFile");
        

[JsonProperty(PropertyName="temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TemperatureScheduleName { get; set; } = "";
        

[Description("If calculation method is CorrelationFromWeatherFile or Schedule, this input field" +
    " is ignored.")]
[JsonProperty(PropertyName="annual_average_outdoor_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AnnualAverageOutdoorAirTemperature { get; set; } = null;
        

[Description("If calculation method is CorrelationFromWeatherFile or Schedule, this input field" +
    " is ignored.")]
[JsonProperty(PropertyName="maximum_difference_in_monthly_average_outdoor_air_temperatures", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumDifferenceInMonthlyAverageOutdoorAirTemperatures { get; set; } = null;
    }
    
    public enum Site_WaterMainsTemperature_CalculationMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Correlation")]
        Correlation = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CorrelationFromWeatherFile")]
        CorrelationFromWeatherFile = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Schedule")]
        Schedule = 3,
    }
    
    [Description("Used to describe the amount of water precipitation at the building site. Precipit" +
        "ation includes both rain and the equivalent water content of snow.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Site_Precipitation
    {
        

[JsonProperty(PropertyName="precipitation_model_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Site_Precipitation_PrecipitationModelType PrecipitationModelType { get; set; } = (Site_Precipitation_PrecipitationModelType)Enum.Parse(typeof(Site_Precipitation_PrecipitationModelType), "ScheduleAndDesignLevel");
        

[Description("meters of water per year used for design level")]
[JsonProperty(PropertyName="design_level_for_total_annual_precipitation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignLevelForTotalAnnualPrecipitation { get; set; } = null;
        

[Description("Schedule values in meters of water per hour values should be non-negative")]
[JsonProperty(PropertyName="precipitation_rates_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PrecipitationRatesScheduleName { get; set; } = "";
        

[Description("meters of water per year from average weather statistics")]
[JsonProperty(PropertyName="average_total_annual_precipitation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AverageTotalAnnualPrecipitation { get; set; } = null;
    }
    
    public enum Site_Precipitation_PrecipitationModelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="ScheduleAndDesignLevel")]
        ScheduleAndDesignLevel = 0,
    }
    
    [Description("Used to describe the amount of irrigation on the ecoroof surface over the course " +
        "of the simulation runperiod.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoofIrrigation
    {
        

[Description("SmartSchedule will not allow irrigation when soil is already moist. Current thres" +
    "hold set at 30% of saturation.")]
[JsonProperty(PropertyName="irrigation_model_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public RoofIrrigation_IrrigationModelType IrrigationModelType { get; set; } = (RoofIrrigation_IrrigationModelType)Enum.Parse(typeof(RoofIrrigation_IrrigationModelType), "Schedule");
        

[Description("Schedule values in meters of water per hour values should be non-negative")]
[JsonProperty(PropertyName="irrigation_rate_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string IrrigationRateScheduleName { get; set; } = "";
        

[Description("Used with SmartSchedule to set the saturation level at which no irrigation is all" +
    "owed.")]
[JsonProperty(PropertyName="irrigation_maximum_saturation_threshold", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> IrrigationMaximumSaturationThreshold { get; set; } = Double.Parse("40", CultureInfo.InvariantCulture);
    }
    
    public enum RoofIrrigation_IrrigationModelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Schedule")]
        Schedule = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SmartSchedule")]
        SmartSchedule = 1,
    }
    
    [Description("If this object is omitted, the default solar and visible spectrum data will be us" +
        "ed.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Site_SolarAndVisibleSpectrum
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("The method specifies which of the solar and visible spectrum data to use in the c" +
    "alculations. Choices: Default - existing hard-wired spectrum data in EnergyPlus." +
    " UserDefined - user specified spectrum data referenced by the next two fields")]
[JsonProperty(PropertyName="spectrum_data_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Site_SolarAndVisibleSpectrum_SpectrumDataMethod SpectrumDataMethod { get; set; } = (Site_SolarAndVisibleSpectrum_SpectrumDataMethod)Enum.Parse(typeof(Site_SolarAndVisibleSpectrum_SpectrumDataMethod), "Default");
        

[JsonProperty(PropertyName="solar_spectrum_data_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SolarSpectrumDataObjectName { get; set; } = "";
        

[JsonProperty(PropertyName="visible_spectrum_data_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string VisibleSpectrumDataObjectName { get; set; } = "";
    }
    
    public enum Site_SolarAndVisibleSpectrum_SpectrumDataMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Default")]
        Default = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UserDefined")]
        UserDefined = 2,
    }
    
    [Description("Spectrum Data Type is followed by up to 107 sets of normal-incidence measured val" +
        "ues of [wavelength, spectrum] for wavelengths covering the solar (0.25 to 2.5 mi" +
        "crons) or visible spectrum (0.38 to 0.78 microns)")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Site_SpectrumData
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="spectrum_data_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Site_SpectrumData_SpectrumDataType SpectrumDataType { get; set; } = (Site_SpectrumData_SpectrumDataType)Enum.Parse(typeof(Site_SpectrumData_SpectrumDataType), "Solar");
        

[JsonProperty(PropertyName="wavelength", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Wavelength { get; set; } = null;
        

[JsonProperty(PropertyName="spectrum", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Spectrum { get; set; } = null;
        

[JsonProperty(PropertyName="wavelength_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Wavelength1 { get; set; } = null;
        

[JsonProperty(PropertyName="spectrum_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Spectrum2 { get; set; } = null;
        

[JsonProperty(PropertyName="extensions", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.LocationandClimate.Site_SpectrumData_Extensions_Item> Extensions { get; set; } = null;
    }
    
    public enum Site_SpectrumData_SpectrumDataType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Solar")]
        Solar = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Visible")]
        Visible = 1,
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Site_SpectrumData_Extensions_Item
    {
        

[JsonProperty(PropertyName="wavelength", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Wavelength { get; set; } = null;
        

[JsonProperty(PropertyName="spectrum", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Spectrum { get; set; } = null;
    }
}
