namespace EnergyPlus.ZoneAirflow
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
    using EnergyPlus.LocationandClimate;
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
    using EnergyPlus.ZoneHVACAirLoopTerminalUnits;
    using EnergyPlus.ZoneHVACControlsandThermostats;
    using EnergyPlus.ZoneHVACEquipmentConnections;
    using EnergyPlus.ZoneHVACForcedAirUnits;
    using EnergyPlus.ZoneHVACRadiativeConvectiveUnits;
    
    
    [Description(@"Infiltration is specified as a design level which is modified by a Schedule fraction, temperature difference and wind speed: Infiltration=Idesign * FSchedule * (A + B*|(Tzone-Todb)| + C*WindSpd + D * WindSpd**2) If you use a ZoneList in the Zone or ZoneList name field then this definition applies to all the zones in the ZoneList.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneInfiltration_DesignFlowRate
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_or_zonelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneOrZonelistName { get; set; } = "";
        

[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[Description(@"The entered calculation method is used to create the maximum amount of infiltration for this set of attributes Choices: Flow/Zone => Design Flow Rate -- simply enter Design Flow Rate Flow/Area => Flow per Zone Floor Area - Value * Floor Area (zone) = Design Flow Rate Flow/ExteriorArea => Flow per Exterior Surface Area - Value * Exterior Surface Area (zone) = Design Flow Rate Flow/ExteriorWallArea => Flow per Exterior Surface Area - Value * Exterior Wall Surface Area (zone) = Design Flow Rate AirChanges/Hour => Air Changes per Hour - Value * Floor Volume (zone) adjusted for m3/s = Design Volume Flow Rate ""Idesign"" in Equation is the result.")]
[JsonProperty(PropertyName="design_flow_rate_calculation_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneInfiltration_DesignFlowRate_DesignFlowRateCalculationMethod DesignFlowRateCalculationMethod { get; set; } = (ZoneInfiltration_DesignFlowRate_DesignFlowRateCalculationMethod)Enum.Parse(typeof(ZoneInfiltration_DesignFlowRate_DesignFlowRateCalculationMethod), "Empty");
        

[JsonProperty(PropertyName="design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignFlowRate { get; set; } = null;
        

[JsonProperty(PropertyName="flow_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FlowPerZoneFloorArea { get; set; } = null;
        

[Description("use key Flow/ExteriorArea for all exterior surface area use key Flow/ExteriorWall" +
    "Area to include only exterior wall area")]
[JsonProperty(PropertyName="flow_per_exterior_surface_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FlowPerExteriorSurfaceArea { get; set; } = null;
        

[JsonProperty(PropertyName="air_changes_per_hour", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AirChangesPerHour { get; set; } = null;
        

[Description("\"A\" in Equation")]
[JsonProperty(PropertyName="constant_term_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConstantTermCoefficient { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("\"B\" in Equation")]
[JsonProperty(PropertyName="temperature_term_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureTermCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("\"C\" in Equation")]
[JsonProperty(PropertyName="velocity_term_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VelocityTermCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("\"D\" in Equation")]
[JsonProperty(PropertyName="velocity_squared_term_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VelocitySquaredTermCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    public enum ZoneInfiltration_DesignFlowRate_DesignFlowRateCalculationMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AirChanges/Hour")]
        AirChangesHour = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Area")]
        FlowArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/ExteriorArea")]
        FlowExteriorArea = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/ExteriorWallArea")]
        FlowExteriorWallArea = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Zone")]
        FlowZone = 5,
    }
    
    [Description("Infiltration is specified as effective leakage area at 4 Pa, schedule fraction, s" +
        "tack and wind coefficients, and is a function of temperature difference and wind" +
        " speed: Infiltration=FSchedule * (AL /1000) SQRT(Cs*|(Tzone-Todb)| +  Cw*WindSpd" +
        "**2 )")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneInfiltration_EffectiveLeakageArea
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[Description("\"AL\" in Equation units are cm2 (square centimeters)")]
[JsonProperty(PropertyName="effective_air_leakage_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EffectiveAirLeakageArea { get; set; } = null;
        

[Description("\"Cs\" in Equation")]
[JsonProperty(PropertyName="stack_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StackCoefficient { get; set; } = null;
        

[Description("\"Cw\" in Equation")]
[JsonProperty(PropertyName="wind_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WindCoefficient { get; set; } = null;
    }
    
    [Description("Infiltration is specified as flow coefficient, schedule fraction, stack and wind " +
        "coefficients, and is a function of temperature difference and wind speed: Infilt" +
        "ration=FSchedule * SQRT( (c * Cs*|(Tzone-Todb)|**n)**2 + (c* Cw*(s * WindSpd)**2" +
        "n)**2 )")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneInfiltration_FlowCoefficient
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[Description("\"c\" in Equation")]
[JsonProperty(PropertyName="flow_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FlowCoefficient { get; set; } = null;
        

[Description("\"Cs\" in Equation")]
[JsonProperty(PropertyName="stack_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StackCoefficient { get; set; } = null;
        

[Description("\"n\" in Equation")]
[JsonProperty(PropertyName="pressure_exponent", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PressureExponent { get; set; } = Double.Parse("0.67", CultureInfo.InvariantCulture);
        

[Description("\"Cw\" in Equation")]
[JsonProperty(PropertyName="wind_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WindCoefficient { get; set; } = null;
        

[Description("\"s\" in Equation")]
[JsonProperty(PropertyName="shelter_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ShelterFactor { get; set; } = null;
    }
    
    [Description(@"Ventilation is specified as a design level which is modified by a schedule fraction, temperature difference and wind speed: Ventilation=Vdesign * Fschedule * (A + B*|(Tzone-Todb)| + C*WindSpd + D * WindSpd**2) If you use a ZoneList in the Zone or ZoneList name field then this definition applies to all the zones in the ZoneList.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneVentilation_DesignFlowRate
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_or_zonelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneOrZonelistName { get; set; } = "";
        

[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[Description(@"The entered calculation method is used to create the maximum amount of ventilation for this set of attributes Choices: Flow/Zone => Design Flow Rate -- simply enter Design Flow Rate Flow/Area => Flow Rate per Zone Floor Area - Value * Floor Area (zone) = Design Flow Rate Flow/Person => Flow Rate per Person - Value * #people = Design Flow Rate AirChanges/Hour => Air Changes per Hour - Value * Floor Volume (zone) adjusted for m3/s = Design Volume Flow Rate ""Vdesign"" in Equation is the result.")]
[JsonProperty(PropertyName="design_flow_rate_calculation_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneVentilation_DesignFlowRate_DesignFlowRateCalculationMethod DesignFlowRateCalculationMethod { get; set; } = (ZoneVentilation_DesignFlowRate_DesignFlowRateCalculationMethod)Enum.Parse(typeof(ZoneVentilation_DesignFlowRate_DesignFlowRateCalculationMethod), "Empty");
        

[JsonProperty(PropertyName="design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignFlowRate { get; set; } = null;
        

[JsonProperty(PropertyName="flow_rate_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FlowRatePerZoneFloorArea { get; set; } = null;
        

[JsonProperty(PropertyName="flow_rate_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FlowRatePerPerson { get; set; } = null;
        

[JsonProperty(PropertyName="air_changes_per_hour", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AirChangesPerHour { get; set; } = null;
        

[JsonProperty(PropertyName="ventilation_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneVentilation_DesignFlowRate_VentilationType VentilationType { get; set; } = (ZoneVentilation_DesignFlowRate_VentilationType)Enum.Parse(typeof(ZoneVentilation_DesignFlowRate_VentilationType), "Natural");
        

[Description("pressure rise across the fan")]
[JsonProperty(PropertyName="fan_pressure_rise", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanPressureRise { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanTotalEfficiency { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("\"A\" in Equation")]
[JsonProperty(PropertyName="constant_term_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConstantTermCoefficient { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("\"B\" in Equation")]
[JsonProperty(PropertyName="temperature_term_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureTermCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("\"C\" in Equation")]
[JsonProperty(PropertyName="velocity_term_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VelocityTermCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("\"D\" in Equation")]
[JsonProperty(PropertyName="velocity_squared_term_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VelocitySquaredTermCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("this is the indoor temperature below which ventilation is shutoff")]
[JsonProperty(PropertyName="minimum_indoor_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumIndoorTemperature { get; set; } = Double.Parse("-100", CultureInfo.InvariantCulture);
        

[Description("This schedule contains the indoor temperature versus time below which ventilation" +
    " is shutoff.")]
[JsonProperty(PropertyName="minimum_indoor_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumIndoorTemperatureScheduleName { get; set; } = "";
        

[Description("this is the indoor temperature above which ventilation is shutoff")]
[JsonProperty(PropertyName="maximum_indoor_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumIndoorTemperature { get; set; } = Double.Parse("100", CultureInfo.InvariantCulture);
        

[Description("This schedule contains the indoor temperature versus time above which ventilation" +
    " is shutoff.")]
[JsonProperty(PropertyName="maximum_indoor_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaximumIndoorTemperatureScheduleName { get; set; } = "";
        

[Description(@"This is the temperature differential between indoor and outdoor below which ventilation is shutoff. If ((IndoorTemp - OutdoorTemp) < DeltaTemperature) then ventilation is not allowed. For example, if delta temperature is 2C, ventilation is assumed to be available if the outside air temperature is at least 2C cooler than the zone air temperature. The values for this field can include negative numbers. This allows ventilation to occur even if the outdoor temperature is above the indoor temperature.")]
[JsonProperty(PropertyName="delta_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DeltaTemperature { get; set; } = Double.Parse("-100", CultureInfo.InvariantCulture);
        

[Description("This schedule contains the temperature differential between indoor and outdoor ve" +
    "rsus time below which ventilation is shutoff.")]
[JsonProperty(PropertyName="delta_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DeltaTemperatureScheduleName { get; set; } = "";
        

[Description("this is the outdoor temperature below which ventilation is shutoff")]
[JsonProperty(PropertyName="minimum_outdoor_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumOutdoorTemperature { get; set; } = Double.Parse("-100", CultureInfo.InvariantCulture);
        

[Description("This schedule contains the outdoor temperature versus time below which ventilatio" +
    "n is shutoff.")]
[JsonProperty(PropertyName="minimum_outdoor_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumOutdoorTemperatureScheduleName { get; set; } = "";
        

[Description("this is the outdoor temperature above which ventilation is shutoff")]
[JsonProperty(PropertyName="maximum_outdoor_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumOutdoorTemperature { get; set; } = Double.Parse("100", CultureInfo.InvariantCulture);
        

[Description("This schedule contains the outdoor temperature versus time above which ventilatio" +
    "n is shutoff.")]
[JsonProperty(PropertyName="maximum_outdoor_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaximumOutdoorTemperatureScheduleName { get; set; } = "";
        

[Description("this is the outdoor wind speed above which ventilation is shutoff")]
[JsonProperty(PropertyName="maximum_wind_speed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumWindSpeed { get; set; } = Double.Parse("40", CultureInfo.InvariantCulture);
    }
    
    public enum ZoneVentilation_DesignFlowRate_DesignFlowRateCalculationMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AirChanges/Hour")]
        AirChangesHour = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Area")]
        FlowArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Person")]
        FlowPerson = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Zone")]
        FlowZone = 4,
    }
    
    public enum ZoneVentilation_DesignFlowRate_VentilationType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Balanced")]
        Balanced = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Exhaust")]
        Exhaust = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Intake")]
        Intake = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Natural")]
        Natural = 4,
    }
    
    [Description(@"This object is specified as natural ventilation driven by wind and stack effect only: Ventilation Wind = Cw * Opening Area * Schedule * WindSpd Ventilation Stack = Cd * Opening Area * Schedule * SQRT(2*g*DH*(|(Tzone-Todb)|/Tzone)) Total Ventilation = SQRT((Ventilation Wind)^2 + (Ventilation Stack)^2)")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneVentilation_WindandStackOpenArea
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("This is the opening area used to calculate stack effect and wind driven ventilati" +
    "on.")]
[JsonProperty(PropertyName="opening_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OpeningArea { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This schedule contains the fraction values applied to the opening area given in t" +
    "he previous input field (0.0 - 1.0).")]
[JsonProperty(PropertyName="opening_area_fraction_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OpeningAreaFractionScheduleName { get; set; } = "";
        

[Description(@"This field is used to calculate wind driven ventilation. ""Cw"" in the wind-driven equation and the maximum value is 1.0. When the input is Autocalculate, the program calculates Cw based on an angle between wind direction and effective angle Cw = 0.55 at angle = 0, and Cw = 0.3 at angle=180 Linear interpolation is used to calculate Cw based on the above two values.")]
[JsonProperty(PropertyName="opening_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> OpeningEffectiveness { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is defined as normal angle of the opening area and is used when input " +
    "field Opening Effectiveness = Autocalculate.")]
[JsonProperty(PropertyName="effective_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EffectiveAngle { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This is the height difference between the midpoint of an opening and the neutral " +
    "pressure level. \"DH\" in the stack equation.")]
[JsonProperty(PropertyName="height_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeightDifference { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This is the discharge coefficient used to calculate stack effect. \"Cd\" in the sta" +
    "ck equation and the maximum value is 1.0. When the input is Autocalculate, the f" +
    "ollowing equation is used to calculate the coefficient: Cd = 0.4 + 0.0045*|(Tzon" +
    "e-Todb)|")]
[JsonProperty(PropertyName="discharge_coefficient_for_opening", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> DischargeCoefficientForOpening { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This is the indoor temperature below which ventilation is shutoff.")]
[JsonProperty(PropertyName="minimum_indoor_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumIndoorTemperature { get; set; } = Double.Parse("-100", CultureInfo.InvariantCulture);
        

[Description("This schedule contains the indoor temperature versus time below which ventilation" +
    " is shutoff.")]
[JsonProperty(PropertyName="minimum_indoor_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumIndoorTemperatureScheduleName { get; set; } = "";
        

[Description("This is the indoor temperature above which ventilation is shutoff.")]
[JsonProperty(PropertyName="maximum_indoor_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumIndoorTemperature { get; set; } = Double.Parse("100", CultureInfo.InvariantCulture);
        

[Description("This schedule contains the indoor temperature versus time above which ventilation" +
    " is shutoff.")]
[JsonProperty(PropertyName="maximum_indoor_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaximumIndoorTemperatureScheduleName { get; set; } = "";
        

[Description("This is the temperature differential between indoor and outdoor below which venti" +
    "lation is shutoff.")]
[JsonProperty(PropertyName="delta_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DeltaTemperature { get; set; } = Double.Parse("-100", CultureInfo.InvariantCulture);
        

[Description("This schedule contains the temperature differential between indoor and outdoor ve" +
    "rsus time below which ventilation is shutoff.")]
[JsonProperty(PropertyName="delta_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DeltaTemperatureScheduleName { get; set; } = "";
        

[Description("This is the outdoor temperature below which ventilation is shutoff.")]
[JsonProperty(PropertyName="minimum_outdoor_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumOutdoorTemperature { get; set; } = Double.Parse("-100", CultureInfo.InvariantCulture);
        

[Description("This schedule contains the outdoor temperature versus time below which ventilatio" +
    "n is shutoff.")]
[JsonProperty(PropertyName="minimum_outdoor_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumOutdoorTemperatureScheduleName { get; set; } = "";
        

[Description("This is the outdoor temperature above which ventilation is shutoff.")]
[JsonProperty(PropertyName="maximum_outdoor_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumOutdoorTemperature { get; set; } = Double.Parse("100", CultureInfo.InvariantCulture);
        

[Description("This schedule contains the outdoor temperature versus time above which ventilatio" +
    "n is shutoff.")]
[JsonProperty(PropertyName="maximum_outdoor_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaximumOutdoorTemperatureScheduleName { get; set; } = "";
        

[Description("This is the outdoor wind speed above which ventilation is shutoff.")]
[JsonProperty(PropertyName="maximum_wind_speed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumWindSpeed { get; set; } = Double.Parse("40", CultureInfo.InvariantCulture);
    }
    
    [Description(@"Provide a combined zone outdoor air flow by including interactions between mechanical ventilation, infiltration and duct leakage. This object will combine outdoor flows from all ZoneInfiltration and ZoneVentilation objects in the same zone. Balanced flows will be summed, while unbalanced flows will be added in quadrature.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneAirBalance_OutdoorAir
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("None: Only perform simple calculations without using a combined zone outdoor air." +
    " Quadrature: A combined outdoor air is used in the quadrature sum.")]
[JsonProperty(PropertyName="air_balance_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneAirBalance_OutdoorAir_AirBalanceMethod AirBalanceMethod { get; set; } = (ZoneAirBalance_OutdoorAir_AirBalanceMethod)Enum.Parse(typeof(ZoneAirBalance_OutdoorAir_AirBalanceMethod), "Quadrature");
        

[JsonProperty(PropertyName="induced_outdoor_air_due_to_unbalanced_duct_leakage", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InducedOutdoorAirDueToUnbalancedDuctLeakage { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This schedule contains the fraction values applied to the Induced Outdoor Air giv" +
    "en in the previous input field (0.0 - 1.0).")]
[JsonProperty(PropertyName="induced_outdoor_air_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InducedOutdoorAirScheduleName { get; set; } = "";
    }
    
    public enum ZoneAirBalance_OutdoorAir_AirBalanceMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Quadrature")]
        Quadrature = 2,
    }
    
    [Description(@"ZoneMixing is a simple air exchange from one zone to another. Note that this statement only affects the energy balance of the ""receiving"" zone and will not produce any effect on the ""source"" zone. Mixing statements can be complementary and include multiple zones, but the balancing of flows between zones is left to the user's discretion.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneMixing
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[Description(@"The entered calculation method is used to create the maximum amount of ventilation for this set of attributes Choices: Flow/Zone => Design Flow Rate -- simply enter Design Flow Rate Flow/Area => Flow Rate per Zone Floor Area - Value * Floor Area (zone) = Design Flow Rate Flow/Person => Flow Rate per Person - Value * #people = Design Flow Rate AirChanges/Hour => Air Changes per Hour - Value * Floor Volume (zone) adjusted for m3/s = Design Volume Flow Rate ""Vdesign"" in Equation is the result.")]
[JsonProperty(PropertyName="design_flow_rate_calculation_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneMixing_DesignFlowRateCalculationMethod DesignFlowRateCalculationMethod { get; set; } = (ZoneMixing_DesignFlowRateCalculationMethod)Enum.Parse(typeof(ZoneMixing_DesignFlowRateCalculationMethod), "Empty");
        

[JsonProperty(PropertyName="design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignFlowRate { get; set; } = null;
        

[JsonProperty(PropertyName="flow_rate_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FlowRatePerZoneFloorArea { get; set; } = null;
        

[JsonProperty(PropertyName="flow_rate_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FlowRatePerPerson { get; set; } = null;
        

[JsonProperty(PropertyName="air_changes_per_hour", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AirChangesPerHour { get; set; } = null;
        

[JsonProperty(PropertyName="source_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SourceZoneName { get; set; } = "";
        

[Description("This field contains the constant temperature differential between source and rece" +
    "iving zones below which mixing is shutoff.")]
[JsonProperty(PropertyName="delta_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DeltaTemperature { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This schedule contains the temperature differential between source and receiving " +
    "zones versus time below which mixing is shutoff.")]
[JsonProperty(PropertyName="delta_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DeltaTemperatureScheduleName { get; set; } = "";
        

[Description("This schedule contains the zone dry-bulb temperature versus time below which mixi" +
    "ng is shutoff.")]
[JsonProperty(PropertyName="minimum_zone_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumZoneTemperatureScheduleName { get; set; } = "";
        

[Description("This schedule contains the zone dry-bulb temperature versus time above which mixi" +
    "ng is shutoff.")]
[JsonProperty(PropertyName="maximum_zone_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaximumZoneTemperatureScheduleName { get; set; } = "";
        

[Description("This schedule contains the source zone dry-bulb temperature versus time below whi" +
    "ch mixing is shutoff.")]
[JsonProperty(PropertyName="minimum_source_zone_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumSourceZoneTemperatureScheduleName { get; set; } = "";
        

[Description("This schedule contains the source zone dry-bulb temperature versus time above whi" +
    "ch mixing is shutoff.")]
[JsonProperty(PropertyName="maximum_source_zone_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaximumSourceZoneTemperatureScheduleName { get; set; } = "";
        

[Description("This schedule contains the outdoor temperature versus time below which mixing is " +
    "shutoff.")]
[JsonProperty(PropertyName="minimum_outdoor_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumOutdoorTemperatureScheduleName { get; set; } = "";
        

[Description("This schedule contains the outdoor temperature versus time above which mixing is " +
    "shutoff.")]
[JsonProperty(PropertyName="maximum_outdoor_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaximumOutdoorTemperatureScheduleName { get; set; } = "";
    }
    
    public enum ZoneMixing_DesignFlowRateCalculationMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AirChanges/Hour")]
        AirChangesHour = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Area")]
        FlowArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Person")]
        FlowPerson = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Zone")]
        FlowZone = 4,
    }
    
    [Description("ZoneCrossMixing exchanges an equal amount of air between two zones. Note that thi" +
        "s statement affects the energy balance of both zones.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneCrossMixing
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[Description(@"The entered calculation method is used to create the maximum amount of ventilation for this set of attributes Choices: Flow/Zone => Design Flow Rate -- simply enter Design Flow Rate Flow/Area => Flow Rate per Zone Floor Area - Value * Floor Area (zone) = Design Flow Rate Flow/Person => Flow Rate per Person - Value * #people = Design Flow Rate AirChanges/Hour => Air Changes per Hour - Value * Floor Volume (zone) adjusted for m3/s = Design Volume Flow Rate ""Vdesign"" in Equation is the result.")]
[JsonProperty(PropertyName="design_flow_rate_calculation_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneCrossMixing_DesignFlowRateCalculationMethod DesignFlowRateCalculationMethod { get; set; } = (ZoneCrossMixing_DesignFlowRateCalculationMethod)Enum.Parse(typeof(ZoneCrossMixing_DesignFlowRateCalculationMethod), "Empty");
        

[JsonProperty(PropertyName="design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignFlowRate { get; set; } = null;
        

[JsonProperty(PropertyName="flow_rate_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FlowRatePerZoneFloorArea { get; set; } = null;
        

[JsonProperty(PropertyName="flow_rate_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FlowRatePerPerson { get; set; } = null;
        

[JsonProperty(PropertyName="air_changes_per_hour", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AirChangesPerHour { get; set; } = null;
        

[JsonProperty(PropertyName="source_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SourceZoneName { get; set; } = "";
        

[Description("This field contains the constant temperature differential between source and rece" +
    "iving zones below which cross mixing is shutoff. This value must be greater than" +
    " or equal to zero.")]
[JsonProperty(PropertyName="delta_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DeltaTemperature { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This schedule contains the temperature differential between source and receiving " +
    "zones versus time below which cross mixing is shutoff.")]
[JsonProperty(PropertyName="delta_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DeltaTemperatureScheduleName { get; set; } = "";
        

[Description("This schedule contains the indoor temperature versus time below which cross mixin" +
    "g is shutoff.")]
[JsonProperty(PropertyName="minimum_zone_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumZoneTemperatureScheduleName { get; set; } = "";
        

[Description("This schedule contains the indoor temperature versus time above which cross mixin" +
    "g is shutoff.")]
[JsonProperty(PropertyName="maximum_zone_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaximumZoneTemperatureScheduleName { get; set; } = "";
        

[Description("This schedule contains the source zone dry-bulb temperature versus time below whi" +
    "ch cross mixing is shutoff.")]
[JsonProperty(PropertyName="minimum_source_zone_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumSourceZoneTemperatureScheduleName { get; set; } = "";
        

[Description("This schedule contains the source zone dry-bulb temperature versus time above whi" +
    "ch cross mixing is shutoff.")]
[JsonProperty(PropertyName="maximum_source_zone_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaximumSourceZoneTemperatureScheduleName { get; set; } = "";
        

[Description("This schedule contains the outdoor temperature versus time below which cross mixi" +
    "ng is shutoff.")]
[JsonProperty(PropertyName="minimum_outdoor_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumOutdoorTemperatureScheduleName { get; set; } = "";
        

[Description("This schedule contains the outdoor temperature versus time above which cross mixi" +
    "ng is shutoff.")]
[JsonProperty(PropertyName="maximum_outdoor_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaximumOutdoorTemperatureScheduleName { get; set; } = "";
    }
    
    public enum ZoneCrossMixing_DesignFlowRateCalculationMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AirChanges/Hour")]
        AirChangesHour = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Area")]
        FlowArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Person")]
        FlowPerson = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Zone")]
        FlowZone = 4,
    }
    
    [Description(@"Refrigeration Door Mixing is used for an opening between two zones that are at the same elevation but have different air temperatures. In this case, the mixing air flow between the two zones is determined by the density difference between the two zones. This would typically be used between two zones in a refrigerated warehouse that are controlled at different temperatures. It could also be used to model a door to a walk-in refrigerated space if that space were modeled as a zone instead of using the object Refrigeration:WalkIn.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneRefrigerationDoorMixing
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_1_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Zone1Name { get; set; } = "";
        

[JsonProperty(PropertyName="zone_2_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Zone2Name { get; set; } = "";
        

[Description(@"This schedule defines the fraction of the time the refrigeration door is open For example, if the warehouse is closed at night and there are no door openings between two zones, the value for that time period would be 0. If doors were propped open, the value  over that time period would be 1.0 If the doors were open about 20% of the time, the value over that period would be 0.2 Schedule values must lie between 0 and 1.0")]
[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="door_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DoorHeight { get; set; } = Double.Parse("3", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="door_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DoorArea { get; set; } = Double.Parse("9", CultureInfo.InvariantCulture);
        

[Description("Door protection can reduce the air flow through a refrigeration door The default " +
    "value is \"None\" Choices: \"None\", \"AirCurtain\", and \"StripCurtain\" A strip curtai" +
    "n reduces the air flow more than an air curtain")]
[JsonProperty(PropertyName="door_protection_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneRefrigerationDoorMixing_DoorProtectionType DoorProtectionType { get; set; } = (ZoneRefrigerationDoorMixing_DoorProtectionType)Enum.Parse(typeof(ZoneRefrigerationDoorMixing_DoorProtectionType), "None");
    }
    
    public enum ZoneRefrigerationDoorMixing_DoorProtectionType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AirCurtain")]
        AirCurtain = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="StripCurtain")]
        StripCurtain = 3,
    }
    
    [Description("Earth Tube is specified as a design level which is modified by a Schedule fractio" +
        "n, temperature difference and wind speed: Earthtube=Edesign * Fschedule * (A + B" +
        "*|(Tzone-Todb)| + C*WindSpd + D * WindSpd**2)")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneEarthtube
    {
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[Description("\"Edesign\" in Equation")]
[JsonProperty(PropertyName="design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignFlowRate { get; set; } = null;
        

[Description("this is the indoor temperature below which the earth tube is shut off")]
[JsonProperty(PropertyName="minimum_zone_temperature_when_cooling", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumZoneTemperatureWhenCooling { get; set; } = null;
        

[Description("this is the indoor temperature above which the earth tube is shut off")]
[JsonProperty(PropertyName="maximum_zone_temperature_when_heating", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumZoneTemperatureWhenHeating { get; set; } = null;
        

[Description("This is the temperature difference between indoor and outdoor below which the ear" +
    "th tube is shut off")]
[JsonProperty(PropertyName="delta_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DeltaTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="earthtube_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneEarthtube_EarthtubeType EarthtubeType { get; set; } = (ZoneEarthtube_EarthtubeType)Enum.Parse(typeof(ZoneEarthtube_EarthtubeType), "Natural");
        

[Description("pressure rise across the fan")]
[JsonProperty(PropertyName="fan_pressure_rise", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanPressureRise { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanTotalEfficiency { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pipe_radius", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeRadius { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pipe_thickness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeThickness { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pipe_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeLength { get; set; } = Double.Parse("15", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pipe_thermal_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeThermalConductivity { get; set; } = Double.Parse("200", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pipe_depth_under_ground_surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeDepthUnderGroundSurface { get; set; } = Double.Parse("3", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_condition", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneEarthtube_SoilCondition SoilCondition { get; set; } = (ZoneEarthtube_SoilCondition)Enum.Parse(typeof(ZoneEarthtube_SoilCondition), "HeavyAndDamp");
        

[JsonProperty(PropertyName="average_soil_surface_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AverageSoilSurfaceTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="amplitude_of_soil_surface_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AmplitudeOfSoilSurfaceTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="phase_constant_of_soil_surface_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PhaseConstantOfSoilSurfaceTemperature { get; set; } = null;
        

[Description("\"A\" in Equation")]
[JsonProperty(PropertyName="constant_term_flow_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConstantTermFlowCoefficient { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("\"B\" in Equation")]
[JsonProperty(PropertyName="temperature_term_flow_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureTermFlowCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("\"C\" in Equation")]
[JsonProperty(PropertyName="velocity_term_flow_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VelocityTermFlowCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("\"D\" in Equation")]
[JsonProperty(PropertyName="velocity_squared_term_flow_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VelocitySquaredTermFlowCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    public enum ZoneEarthtube_EarthtubeType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Exhaust")]
        Exhaust = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Intake")]
        Intake = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Natural")]
        Natural = 3,
    }
    
    public enum ZoneEarthtube_SoilCondition
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="HeavyAndDamp")]
        HeavyAndDamp = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HeavyAndDry")]
        HeavyAndDry = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HeavyAndSaturated")]
        HeavyAndSaturated = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="LightAndDry")]
        LightAndDry = 4,
    }
    
    [Description(@"A cooltower (sometimes referred to as a wind tower or a shower cooling tower) models passive downdraught evaporative cooling (PDEC) that is designed to capture the wind at the top of a tower and cool the outdoor air using water evaporation before delivering it to a space.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneCoolTower_Shower
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("In case of stand alone tank or underground water, leave this input blank")]
[JsonProperty(PropertyName="water_supply_storage_tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterSupplyStorageTankName { get; set; } = "";
        

[Description("Water flow schedule should be selected when the water flow rate is known. Wind-dr" +
    "iven flow should be selected when the water flow rate is unknown.")]
[JsonProperty(PropertyName="flow_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneCoolTower_Shower_FlowControlType FlowControlType { get; set; } = (ZoneCoolTower_Shower_FlowControlType)Enum.Parse(typeof(ZoneCoolTower_Shower_FlowControlType), "WindDrivenFlow");
        

[JsonProperty(PropertyName="pump_flow_rate_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PumpFlowRateScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_water_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumWaterFlowRate { get; set; } = null;
        

[Description("This field is from either the spray or the wet pad to the top of the outlet.")]
[JsonProperty(PropertyName="effective_tower_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EffectiveTowerHeight { get; set; } = null;
        

[Description("User have to specify effective area when outlet area is relatively bigger than th" +
    "e cross sectional area of cooltower. If the number of outlet is more than one, a" +
    "ssume the air passes through only one.")]
[JsonProperty(PropertyName="airflow_outlet_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AirflowOutletArea { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumAirFlowRate { get; set; } = null;
        

[Description("This field is to specify the indoor temperature below which cooltower is shutoff." +
    "")]
[JsonProperty(PropertyName="minimum_indoor_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumIndoorTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="fraction_of_water_loss", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfWaterLoss { get; set; } = null;
        

[JsonProperty(PropertyName="fraction_of_flow_schedule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfFlowSchedule { get; set; } = null;
        

[JsonProperty(PropertyName="rated_power_consumption", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedPowerConsumption { get; set; } = null;
    }
    
    public enum ZoneCoolTower_Shower_FlowControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="WaterFlowSchedule")]
        WaterFlowSchedule = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="WindDrivenFlow")]
        WindDrivenFlow = 2,
    }
    
    [Description("A thermal chimney is a vertical shaft utilizing solar radiation to enhance natura" +
        "l ventilation. It consists of an absorber wall, air gap and glass cover with hig" +
        "h solar transmissivity.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneThermalChimney
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Name of zone that is the thermal chimney")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="width_of_the_absorber_wall", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WidthOfTheAbsorberWall { get; set; } = null;
        

[JsonProperty(PropertyName="cross_sectional_area_of_air_channel_outlet", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CrossSectionalAreaOfAirChannelOutlet { get; set; } = null;
        

[JsonProperty(PropertyName="discharge_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DischargeCoefficient { get; set; } = Double.Parse("0.8", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="zone_1_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Zone1Name { get; set; } = "";
        

[JsonProperty(PropertyName="distance_from_top_of_thermal_chimney_to_inlet_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistanceFromTopOfThermalChimneyToInlet1 { get; set; } = null;
        

[JsonProperty(PropertyName="relative_ratios_of_air_flow_rates_passing_through_zone_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeRatiosOfAirFlowRatesPassingThroughZone1 { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cross_sectional_areas_of_air_channel_inlet_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CrossSectionalAreasOfAirChannelInlet1 { get; set; } = null;
        

[JsonProperty(PropertyName="zone_2_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Zone2Name { get; set; } = "";
        

[JsonProperty(PropertyName="distance_from_top_of_thermal_chimney_to_inlet_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistanceFromTopOfThermalChimneyToInlet2 { get; set; } = null;
        

[JsonProperty(PropertyName="relative_ratios_of_air_flow_rates_passing_through_zone_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeRatiosOfAirFlowRatesPassingThroughZone2 { get; set; } = null;
        

[JsonProperty(PropertyName="cross_sectional_areas_of_air_channel_inlet_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CrossSectionalAreasOfAirChannelInlet2 { get; set; } = null;
        

[JsonProperty(PropertyName="zone_3_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Zone3Name { get; set; } = "";
        

[JsonProperty(PropertyName="distance_from_top_of_thermal_chimney_to_inlet_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistanceFromTopOfThermalChimneyToInlet3 { get; set; } = null;
        

[JsonProperty(PropertyName="relative_ratios_of_air_flow_rates_passing_through_zone_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeRatiosOfAirFlowRatesPassingThroughZone3 { get; set; } = null;
        

[JsonProperty(PropertyName="cross_sectional_areas_of_air_channel_inlet_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CrossSectionalAreasOfAirChannelInlet3 { get; set; } = null;
        

[JsonProperty(PropertyName="zone_4_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Zone4Name { get; set; } = "";
        

[JsonProperty(PropertyName="distance_from_top_of_thermal_chimney_to_inlet_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistanceFromTopOfThermalChimneyToInlet4 { get; set; } = null;
        

[JsonProperty(PropertyName="relative_ratios_of_air_flow_rates_passing_through_zone_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeRatiosOfAirFlowRatesPassingThroughZone4 { get; set; } = null;
        

[JsonProperty(PropertyName="cross_sectional_areas_of_air_channel_inlet_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CrossSectionalAreasOfAirChannelInlet4 { get; set; } = null;
        

[JsonProperty(PropertyName="zone_5_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Zone5Name { get; set; } = "";
        

[JsonProperty(PropertyName="distance_from_top_of_thermal_chimney_to_inlet_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistanceFromTopOfThermalChimneyToInlet5 { get; set; } = null;
        

[JsonProperty(PropertyName="relative_ratios_of_air_flow_rates_passing_through_zone_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeRatiosOfAirFlowRatesPassingThroughZone5 { get; set; } = null;
        

[JsonProperty(PropertyName="cross_sectional_areas_of_air_channel_inlet_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CrossSectionalAreasOfAirChannelInlet5 { get; set; } = null;
        

[JsonProperty(PropertyName="zone_6_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Zone6Name { get; set; } = "";
        

[JsonProperty(PropertyName="distance_from_top_of_thermal_chimney_to_inlet_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistanceFromTopOfThermalChimneyToInlet6 { get; set; } = null;
        

[JsonProperty(PropertyName="relative_ratios_of_air_flow_rates_passing_through_zone_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeRatiosOfAirFlowRatesPassingThroughZone6 { get; set; } = null;
        

[JsonProperty(PropertyName="cross_sectional_areas_of_air_channel_inlet_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CrossSectionalAreasOfAirChannelInlet6 { get; set; } = null;
        

[JsonProperty(PropertyName="zone_7_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Zone7Name { get; set; } = "";
        

[JsonProperty(PropertyName="distance_from_top_of_thermal_chimney_to_inlet_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistanceFromTopOfThermalChimneyToInlet7 { get; set; } = null;
        

[JsonProperty(PropertyName="relative_ratios_of_air_flow_rates_passing_through_zone_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeRatiosOfAirFlowRatesPassingThroughZone7 { get; set; } = null;
        

[JsonProperty(PropertyName="cross_sectional_areas_of_air_channel_inlet_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CrossSectionalAreasOfAirChannelInlet7 { get; set; } = null;
        

[JsonProperty(PropertyName="zone_8_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Zone8Name { get; set; } = "";
        

[JsonProperty(PropertyName="distance_from_top_of_thermal_chimney_to_inlet_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistanceFromTopOfThermalChimneyToInlet8 { get; set; } = null;
        

[JsonProperty(PropertyName="relative_ratios_of_air_flow_rates_passing_through_zone_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeRatiosOfAirFlowRatesPassingThroughZone8 { get; set; } = null;
        

[JsonProperty(PropertyName="cross_sectional_areas_of_air_channel_inlet_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CrossSectionalAreasOfAirChannelInlet8 { get; set; } = null;
        

[JsonProperty(PropertyName="zone_9_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Zone9Name { get; set; } = "";
        

[JsonProperty(PropertyName="distance_from_top_of_thermal_chimney_to_inlet_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistanceFromTopOfThermalChimneyToInlet9 { get; set; } = null;
        

[JsonProperty(PropertyName="relative_ratios_of_air_flow_rates_passing_through_zone_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeRatiosOfAirFlowRatesPassingThroughZone9 { get; set; } = null;
        

[JsonProperty(PropertyName="cross_sectional_areas_of_air_channel_inlet_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CrossSectionalAreasOfAirChannelInlet9 { get; set; } = null;
        

[JsonProperty(PropertyName="zone_10_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Zone10Name { get; set; } = "";
        

[JsonProperty(PropertyName="distance_from_top_of_thermal_chimney_to_inlet_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistanceFromTopOfThermalChimneyToInlet10 { get; set; } = null;
        

[JsonProperty(PropertyName="relative_ratios_of_air_flow_rates_passing_through_zone_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeRatiosOfAirFlowRatesPassingThroughZone10 { get; set; } = null;
        

[JsonProperty(PropertyName="cross_sectional_areas_of_air_channel_inlet_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CrossSectionalAreasOfAirChannelInlet10 { get; set; } = null;
        

[JsonProperty(PropertyName="zone_11_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Zone11Name { get; set; } = "";
        

[JsonProperty(PropertyName="distance_from_top_of_thermal_chimney_to_inlet_11", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistanceFromTopOfThermalChimneyToInlet11 { get; set; } = null;
        

[JsonProperty(PropertyName="relative_ratios_of_air_flow_rates_passing_through_zone_11", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeRatiosOfAirFlowRatesPassingThroughZone11 { get; set; } = null;
        

[JsonProperty(PropertyName="cross_sectional_areas_of_air_channel_inlet_11", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CrossSectionalAreasOfAirChannelInlet11 { get; set; } = null;
        

[JsonProperty(PropertyName="zone_12_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Zone12Name { get; set; } = "";
        

[JsonProperty(PropertyName="distance_from_top_of_thermal_chimney_to_inlet_12", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistanceFromTopOfThermalChimneyToInlet12 { get; set; } = null;
        

[JsonProperty(PropertyName="relative_ratios_of_air_flow_rates_passing_through_zone_12", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeRatiosOfAirFlowRatesPassingThroughZone12 { get; set; } = null;
        

[JsonProperty(PropertyName="cross_sectional_areas_of_air_channel_inlet_12", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CrossSectionalAreasOfAirChannelInlet12 { get; set; } = null;
        

[JsonProperty(PropertyName="zone_13_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Zone13Name { get; set; } = "";
        

[JsonProperty(PropertyName="distance_from_top_of_thermal_chimney_to_inlet_13", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistanceFromTopOfThermalChimneyToInlet13 { get; set; } = null;
        

[JsonProperty(PropertyName="relative_ratios_of_air_flow_rates_passing_through_zone_13", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeRatiosOfAirFlowRatesPassingThroughZone13 { get; set; } = null;
        

[JsonProperty(PropertyName="cross_sectional_areas_of_air_channel_inlet_13", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CrossSectionalAreasOfAirChannelInlet13 { get; set; } = null;
        

[JsonProperty(PropertyName="zone_14_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Zone14Name { get; set; } = "";
        

[JsonProperty(PropertyName="distance_from_top_of_thermal_chimney_to_inlet_14", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistanceFromTopOfThermalChimneyToInlet14 { get; set; } = null;
        

[JsonProperty(PropertyName="relative_ratios_of_air_flow_rates_passing_through_zone_14", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeRatiosOfAirFlowRatesPassingThroughZone14 { get; set; } = null;
        

[JsonProperty(PropertyName="cross_sectional_areas_of_air_channel_inlet_14", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CrossSectionalAreasOfAirChannelInlet14 { get; set; } = null;
        

[JsonProperty(PropertyName="zone_15_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Zone15Name { get; set; } = "";
        

[JsonProperty(PropertyName="distance_from_top_of_thermal_chimney_to_inlet_15", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistanceFromTopOfThermalChimneyToInlet15 { get; set; } = null;
        

[JsonProperty(PropertyName="relative_ratios_of_air_flow_rates_passing_through_zone_15", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeRatiosOfAirFlowRatesPassingThroughZone15 { get; set; } = null;
        

[JsonProperty(PropertyName="cross_sectional_areas_of_air_channel_inlet_15", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CrossSectionalAreasOfAirChannelInlet15 { get; set; } = null;
        

[JsonProperty(PropertyName="zone_16_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Zone16Name { get; set; } = "";
        

[JsonProperty(PropertyName="distance_from_top_of_thermal_chimney_to_inlet_16", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistanceFromTopOfThermalChimneyToInlet16 { get; set; } = null;
        

[JsonProperty(PropertyName="relative_ratios_of_air_flow_rates_passing_through_zone_16", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeRatiosOfAirFlowRatesPassingThroughZone16 { get; set; } = null;
        

[JsonProperty(PropertyName="cross_sectional_areas_of_air_channel_inlet_16", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CrossSectionalAreasOfAirChannelInlet16 { get; set; } = null;
        

[JsonProperty(PropertyName="zone_17_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Zone17Name { get; set; } = "";
        

[JsonProperty(PropertyName="distance_from_top_of_thermal_chimney_to_inlet_17", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistanceFromTopOfThermalChimneyToInlet17 { get; set; } = null;
        

[JsonProperty(PropertyName="relative_ratios_of_air_flow_rates_passing_through_zone_17", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeRatiosOfAirFlowRatesPassingThroughZone17 { get; set; } = null;
        

[JsonProperty(PropertyName="cross_sectional_areas_of_air_channel_inlet_17", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CrossSectionalAreasOfAirChannelInlet17 { get; set; } = null;
        

[JsonProperty(PropertyName="zone_18_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Zone18Name { get; set; } = "";
        

[JsonProperty(PropertyName="distance_from_top_of_thermal_chimney_to_inlet_18", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistanceFromTopOfThermalChimneyToInlet18 { get; set; } = null;
        

[JsonProperty(PropertyName="relative_ratios_of_air_flow_rates_passing_through_zone_18", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeRatiosOfAirFlowRatesPassingThroughZone18 { get; set; } = null;
        

[JsonProperty(PropertyName="cross_sectional_areas_of_air_channel_inlet_18", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CrossSectionalAreasOfAirChannelInlet18 { get; set; } = null;
        

[JsonProperty(PropertyName="zone_19_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Zone19Name { get; set; } = "";
        

[JsonProperty(PropertyName="distance_from_top_of_thermal_chimney_to_inlet_19", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistanceFromTopOfThermalChimneyToInlet19 { get; set; } = null;
        

[JsonProperty(PropertyName="relative_ratios_of_air_flow_rates_passing_through_zone_19", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeRatiosOfAirFlowRatesPassingThroughZone19 { get; set; } = null;
        

[JsonProperty(PropertyName="cross_sectional_areas_of_air_channel_inlet_19", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CrossSectionalAreasOfAirChannelInlet19 { get; set; } = null;
        

[JsonProperty(PropertyName="zone_20_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Zone20Name { get; set; } = "";
        

[JsonProperty(PropertyName="distance_from_top_of_thermal_chimney_to_inlet_20", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistanceFromTopOfThermalChimneyToInlet20 { get; set; } = null;
        

[JsonProperty(PropertyName="relative_ratios_of_air_flow_rates_passing_through_zone_20", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeRatiosOfAirFlowRatesPassingThroughZone20 { get; set; } = null;
        

[JsonProperty(PropertyName="cross_sectional_areas_of_air_channel_inlet_20", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CrossSectionalAreasOfAirChannelInlet20 { get; set; } = null;
    }
}
