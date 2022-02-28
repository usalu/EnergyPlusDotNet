namespace EnergyPlus.ZoneHVACControlsandThermostats
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
    using EnergyPlus.ZoneAirflow;
    using EnergyPlus.ZoneHVACAirLoopTerminalUnits;
    using EnergyPlus.ZoneHVACEquipmentConnections;
    using EnergyPlus.ZoneHVACForcedAirUnits;
    using EnergyPlus.ZoneHVACRadiativeConvectiveUnits;
    
    
    [Description("Specifies zone relative humidity setpoint schedules for humidifying and dehumidif" +
        "ying.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneControl_Humidistat
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("hourly schedule values should be in Relative Humidity (percent)")]
[JsonProperty(PropertyName="humidifying_relative_humidity_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HumidifyingRelativeHumiditySetpointScheduleName { get; set; } = "";
        

[Description("hourly schedule values should be in Relative Humidity (percent)")]
[JsonProperty(PropertyName="dehumidifying_relative_humidity_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DehumidifyingRelativeHumiditySetpointScheduleName { get; set; } = "";
    }
    
    [Description("Define the Thermostat settings for a zone or list of zones. If you use a ZoneList" +
        " in the Zone or ZoneList name field then this definition applies to all the zone" +
        "s in the ZoneList.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneControl_Thermostat
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_or_zonelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneOrZonelistName { get; set; } = "";
        

[Description(@"This schedule contains appropriate control types for thermostat. Control types are integers: 0 - Uncontrolled (floating, no thermostat), 1 = ThermostatSetpoint:SingleHeating, 2 = ThermostatSetpoint:SingleCooling, 3 = ThermostatSetpoint:SingleHeatingOrCooling, 4 = ThermostatSetpoint:DualSetpoint")]
[JsonProperty(PropertyName="control_type_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlTypeScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="control_1_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneControl_Thermostat_Control1ObjectType Control1ObjectType { get; set; } = (ZoneControl_Thermostat_Control1ObjectType)Enum.Parse(typeof(ZoneControl_Thermostat_Control1ObjectType), "ThermostatSetpointDualSetpoint");
        

[Description("Control names are names of individual control objects (e.g. ThermostatSetpoint:Si" +
    "ngleHeating) Schedule values in these objects list actual setpoint temperatures " +
    "for the control types")]
[JsonProperty(PropertyName="control_1_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Control1Name { get; set; } = "";
        

[JsonProperty(PropertyName="control_2_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneControl_Thermostat_Control2ObjectType Control2ObjectType { get; set; } = (ZoneControl_Thermostat_Control2ObjectType)Enum.Parse(typeof(ZoneControl_Thermostat_Control2ObjectType), "ThermostatSetpointDualSetpoint");
        

[Description("Control names are names of individual control objects (e.g. ThermostatSetpoint:Si" +
    "ngleHeating) Schedule values in these objects list actual setpoint temperatures " +
    "for the control types")]
[JsonProperty(PropertyName="control_2_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Control2Name { get; set; } = "";
        

[JsonProperty(PropertyName="control_3_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneControl_Thermostat_Control3ObjectType Control3ObjectType { get; set; } = (ZoneControl_Thermostat_Control3ObjectType)Enum.Parse(typeof(ZoneControl_Thermostat_Control3ObjectType), "ThermostatSetpointDualSetpoint");
        

[Description("Control names are names of individual control objects (e.g. ThermostatSetpoint:Si" +
    "ngleHeating) Schedule values in these objects list actual setpoint temperatures " +
    "for the control types")]
[JsonProperty(PropertyName="control_3_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Control3Name { get; set; } = "";
        

[JsonProperty(PropertyName="control_4_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneControl_Thermostat_Control4ObjectType Control4ObjectType { get; set; } = (ZoneControl_Thermostat_Control4ObjectType)Enum.Parse(typeof(ZoneControl_Thermostat_Control4ObjectType), "ThermostatSetpointDualSetpoint");
        

[Description("Control names are names of individual control objects (e.g. ThermostatSetpoint:Si" +
    "ngleHeating) Schedule values in these objects list actual setpoint temperatures " +
    "for the control types")]
[JsonProperty(PropertyName="control_4_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Control4Name { get; set; } = "";
        

[Description("This optional choice field provides a temperature difference between cut-out temp" +
    "erature and setpoint. The difference is used to adjust to heating or cooling set" +
    "point based on control types.")]
[JsonProperty(PropertyName="temperature_difference_between_cutout_and_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureDifferenceBetweenCutoutAndSetpoint { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    public enum ZoneControl_Thermostat_Control1ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:DualSetpoint")]
        ThermostatSetpointDualSetpoint = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:SingleCooling")]
        ThermostatSetpointSingleCooling = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:SingleHeating")]
        ThermostatSetpointSingleHeating = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:SingleHeatingOrCooling")]
        ThermostatSetpointSingleHeatingOrCooling = 3,
    }
    
    public enum ZoneControl_Thermostat_Control2ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:DualSetpoint")]
        ThermostatSetpointDualSetpoint = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:SingleCooling")]
        ThermostatSetpointSingleCooling = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:SingleHeating")]
        ThermostatSetpointSingleHeating = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:SingleHeatingOrCooling")]
        ThermostatSetpointSingleHeatingOrCooling = 3,
    }
    
    public enum ZoneControl_Thermostat_Control3ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:DualSetpoint")]
        ThermostatSetpointDualSetpoint = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:SingleCooling")]
        ThermostatSetpointSingleCooling = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:SingleHeating")]
        ThermostatSetpointSingleHeating = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:SingleHeatingOrCooling")]
        ThermostatSetpointSingleHeatingOrCooling = 3,
    }
    
    public enum ZoneControl_Thermostat_Control4ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:DualSetpoint")]
        ThermostatSetpointDualSetpoint = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:SingleCooling")]
        ThermostatSetpointSingleCooling = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:SingleHeating")]
        ThermostatSetpointSingleHeating = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:SingleHeatingOrCooling")]
        ThermostatSetpointSingleHeatingOrCooling = 3,
    }
    
    [Description("This object can be used with the ZoneList option on a thermostat or with one of t" +
        "he zones on that list (but you won\'t be able to use the object list to pick only" +
        " one of those zones. Thermostat names are <Zone Name> <global Thermostat name> i" +
        "nternally.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneControl_Thermostat_OperativeTemperature
    {
        

[Description("Enter the name of a ZoneControl:Thermostat object. This object modifies a ZoneCon" +
    "trol:Thermostat object to add a radiative fraction.")]
[JsonProperty(PropertyName="thermostat_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ThermostatName { get; set; } = "";
        

[JsonProperty(PropertyName="radiative_fraction_input_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneControl_Thermostat_OperativeTemperature_RadiativeFractionInputMode RadiativeFractionInputMode { get; set; } = (ZoneControl_Thermostat_OperativeTemperature_RadiativeFractionInputMode)Enum.Parse(typeof(ZoneControl_Thermostat_OperativeTemperature_RadiativeFractionInputMode), "Constant");
        

[JsonProperty(PropertyName="fixed_radiative_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FixedRadiativeFraction { get; set; } = null;
        

[Description("Schedule values of 0.0 indicate no operative temperature control")]
[JsonProperty(PropertyName="radiative_fraction_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RadiativeFractionScheduleName { get; set; } = "";
        

[Description("the cooling setpoint temperature schedule of the referenced thermostat will be ad" +
    "justed based on the selected adaptive comfort model type")]
[JsonProperty(PropertyName="adaptive_comfort_model_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneControl_Thermostat_OperativeTemperature_AdaptiveComfortModelType AdaptiveComfortModelType { get; set; } = (ZoneControl_Thermostat_OperativeTemperature_AdaptiveComfortModelType)Enum.Parse(typeof(ZoneControl_Thermostat_OperativeTemperature_AdaptiveComfortModelType), "None");
    }
    
    public enum ZoneControl_Thermostat_OperativeTemperature_RadiativeFractionInputMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Constant")]
        Constant = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Scheduled")]
        Scheduled = 1,
    }
    
    public enum ZoneControl_Thermostat_OperativeTemperature_AdaptiveComfortModelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveASH5580PercentUpperLine")]
        AdaptiveASH5580PercentUpperLine = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveASH5590PercentUpperLine")]
        AdaptiveASH5590PercentUpperLine = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveASH55CentralLine")]
        AdaptiveASH55CentralLine = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveCEN15251CategoryIIIUpperLine")]
        AdaptiveCEN15251CategoryIIIUpperLine = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveCEN15251CategoryIIUpperLine")]
        AdaptiveCEN15251CategoryIIUpperLine = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveCEN15251CategoryIUpperLine")]
        AdaptiveCEN15251CategoryIUpperLine = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveCEN15251CentralLine")]
        AdaptiveCEN15251CentralLine = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 8,
    }
    
    [Description("If you use a ZoneList in the Zone or ZoneList name field then this definition app" +
        "lies to all the zones in the ZoneList.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneControl_Thermostat_ThermalComfort
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_or_zonelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneOrZonelistName { get; set; } = "";
        

[Description("The method used to calculate thermal comfort dry-bulb temperature setpoint for mu" +
    "ltiple people objects in a zone")]
[JsonProperty(PropertyName="averaging_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneControl_Thermostat_ThermalComfort_AveragingMethod AveragingMethod { get; set; } = (ZoneControl_Thermostat_ThermalComfort_AveragingMethod)Enum.Parse(typeof(ZoneControl_Thermostat_ThermalComfort_AveragingMethod), "PeopleAverage");
        

[Description("Used only when Averaging Method = SpecificObject in the previous field.")]
[JsonProperty(PropertyName="specific_people_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SpecificPeopleName { get; set; } = "";
        

[JsonProperty(PropertyName="minimum_dry_bulb_temperature_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumDryBulbTemperatureSetpoint { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_dry_bulb_temperature_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumDryBulbTemperatureSetpoint { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[Description(@"The Thermal Comfort Control Type Schedule contains values that are appropriate control types. Thermal Comfort Control types are integers: 0 - Uncontrolled (floating), 1 = ThermostatSetpoint:ThermalComfort:Fanger:SingleHeating 2 = ThermostatSetpoint:ThermalComfort:Fanger:SingleCooling 3 = ThermostatSetpoint:ThermalComfort:Fanger:SingleHeatingOrCooling 4 = ThermostatSetpoint:ThermalComfort:Fanger:DualSetpoint")]
[JsonProperty(PropertyName="thermal_comfort_control_type_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ThermalComfortControlTypeScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="thermal_comfort_control_1_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneControl_Thermostat_ThermalComfort_ThermalComfortControl1ObjectType ThermalComfortControl1ObjectType { get; set; } = (ZoneControl_Thermostat_ThermalComfort_ThermalComfortControl1ObjectType)Enum.Parse(typeof(ZoneControl_Thermostat_ThermalComfort_ThermalComfortControl1ObjectType), "ThermostatSetpointThermalComfortFangerDualSetpoint");
        

[Description("Control type names are names for individual control type objects. Schedule values" +
    " in these objects list actual setpoint temperatures for the control types")]
[JsonProperty(PropertyName="thermal_comfort_control_1_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ThermalComfortControl1Name { get; set; } = "";
        

[JsonProperty(PropertyName="thermal_comfort_control_2_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneControl_Thermostat_ThermalComfort_ThermalComfortControl2ObjectType ThermalComfortControl2ObjectType { get; set; } = (ZoneControl_Thermostat_ThermalComfort_ThermalComfortControl2ObjectType)Enum.Parse(typeof(ZoneControl_Thermostat_ThermalComfort_ThermalComfortControl2ObjectType), "ThermostatSetpointThermalComfortFangerDualSetpoint");
        

[Description("Control Type names are names for individual control type objects. Schedule values" +
    " in these objects list actual setpoint temperatures for the control types")]
[JsonProperty(PropertyName="thermal_comfort_control_2_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ThermalComfortControl2Name { get; set; } = "";
        

[JsonProperty(PropertyName="thermal_comfort_control_3_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneControl_Thermostat_ThermalComfort_ThermalComfortControl3ObjectType ThermalComfortControl3ObjectType { get; set; } = (ZoneControl_Thermostat_ThermalComfort_ThermalComfortControl3ObjectType)Enum.Parse(typeof(ZoneControl_Thermostat_ThermalComfort_ThermalComfortControl3ObjectType), "ThermostatSetpointThermalComfortFangerDualSetpoint");
        

[Description("Control type names are names for individual control type objects. Schedule values" +
    " in these objects list actual setpoint temperatures for the control types")]
[JsonProperty(PropertyName="thermal_comfort_control_3_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ThermalComfortControl3Name { get; set; } = "";
        

[JsonProperty(PropertyName="thermal_comfort_control_4_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneControl_Thermostat_ThermalComfort_ThermalComfortControl4ObjectType ThermalComfortControl4ObjectType { get; set; } = (ZoneControl_Thermostat_ThermalComfort_ThermalComfortControl4ObjectType)Enum.Parse(typeof(ZoneControl_Thermostat_ThermalComfort_ThermalComfortControl4ObjectType), "ThermostatSetpointThermalComfortFangerDualSetpoint");
        

[Description("Control type names are names for individual control type objects. Schedule values" +
    " in these objects list actual setpoint temperatures for the control types")]
[JsonProperty(PropertyName="thermal_comfort_control_4_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ThermalComfortControl4Name { get; set; } = "";
    }
    
    public enum ZoneControl_Thermostat_ThermalComfort_AveragingMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ObjectAverage")]
        ObjectAverage = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PeopleAverage")]
        PeopleAverage = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="SpecificObject")]
        SpecificObject = 3,
    }
    
    public enum ZoneControl_Thermostat_ThermalComfort_ThermalComfortControl1ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:ThermalComfort:Fanger:DualSetpoint")]
        ThermostatSetpointThermalComfortFangerDualSetpoint = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:ThermalComfort:Fanger:SingleCooling")]
        ThermostatSetpointThermalComfortFangerSingleCooling = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:ThermalComfort:Fanger:SingleHeating")]
        ThermostatSetpointThermalComfortFangerSingleHeating = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:ThermalComfort:Fanger:SingleHeatingOrCooling")]
        ThermostatSetpointThermalComfortFangerSingleHeatingOrCooling = 3,
    }
    
    public enum ZoneControl_Thermostat_ThermalComfort_ThermalComfortControl2ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:ThermalComfort:Fanger:DualSetpoint")]
        ThermostatSetpointThermalComfortFangerDualSetpoint = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:ThermalComfort:Fanger:SingleCooling")]
        ThermostatSetpointThermalComfortFangerSingleCooling = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:ThermalComfort:Fanger:SingleHeating")]
        ThermostatSetpointThermalComfortFangerSingleHeating = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:ThermalComfort:Fanger:SingleHeatingOrCooling")]
        ThermostatSetpointThermalComfortFangerSingleHeatingOrCooling = 3,
    }
    
    public enum ZoneControl_Thermostat_ThermalComfort_ThermalComfortControl3ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:ThermalComfort:Fanger:DualSetpoint")]
        ThermostatSetpointThermalComfortFangerDualSetpoint = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:ThermalComfort:Fanger:SingleCooling")]
        ThermostatSetpointThermalComfortFangerSingleCooling = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:ThermalComfort:Fanger:SingleHeating")]
        ThermostatSetpointThermalComfortFangerSingleHeating = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:ThermalComfort:Fanger:SingleHeatingOrCooling")]
        ThermostatSetpointThermalComfortFangerSingleHeatingOrCooling = 3,
    }
    
    public enum ZoneControl_Thermostat_ThermalComfort_ThermalComfortControl4ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:ThermalComfort:Fanger:DualSetpoint")]
        ThermostatSetpointThermalComfortFangerDualSetpoint = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:ThermalComfort:Fanger:SingleCooling")]
        ThermostatSetpointThermalComfortFangerSingleCooling = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:ThermalComfort:Fanger:SingleHeating")]
        ThermostatSetpointThermalComfortFangerSingleHeating = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatSetpoint:ThermalComfort:Fanger:SingleHeatingOrCooling")]
        ThermostatSetpointThermalComfortFangerSingleHeatingOrCooling = 3,
    }
    
    [Description("This object modifies a ZoneControl:Thermostat object to effect temperature contro" +
        "l based on zone air humidity conditions.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneControl_Thermostat_TemperatureAndHumidity
    {
        

[Description(@"Enter the name of a ZoneControl:Thermostat object whose operation is to be modified to effect temperature control based on zone air humidity conditions. If the ZoneControl: Thermostat object references a ZoneList, simply enter the name of the ZoneControl:Thermostat object and this temperature and humidity thermostat control will be applied to all zones in the ZoneList. If the ZoneControl:Thermostat object references a ZoneList but it is desired that only a single zone within the ZoneList be controlled based on temperature and humidity control, then the name to be put here is <Zone Name> <Thermostat Name> where the Thermostat Name is the the name of the ZoneControl:Thermostat object.")]
[JsonProperty(PropertyName="thermostat_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ThermostatName { get; set; } = "";
        

[Description("Schedule values should be in Relative Humidity (percent)")]
[JsonProperty(PropertyName="dehumidifying_relative_humidity_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DehumidifyingRelativeHumiditySetpointScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="dehumidification_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneControl_Thermostat_TemperatureAndHumidity_DehumidificationControlType DehumidificationControlType { get; set; } = (ZoneControl_Thermostat_TemperatureAndHumidity_DehumidificationControlType)Enum.Parse(typeof(ZoneControl_Thermostat_TemperatureAndHumidity_DehumidificationControlType), "Overcool");
        

[JsonProperty(PropertyName="overcool_range_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneControl_Thermostat_TemperatureAndHumidity_OvercoolRangeInputMethod OvercoolRangeInputMethod { get; set; } = (ZoneControl_Thermostat_TemperatureAndHumidity_OvercoolRangeInputMethod)Enum.Parse(typeof(ZoneControl_Thermostat_TemperatureAndHumidity_OvercoolRangeInputMethod), "Constant");
        

[Description("Maximum Overcool temperature range for cooling setpoint reduction. Used with Dehu" +
    "midification Control Type = Overcool. A value of 0.0 indicates no zone temperatu" +
    "re overcooling will be provided to gain additional dehumidification.")]
[JsonProperty(PropertyName="overcool_constant_range", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OvercoolConstantRange { get; set; } = Double.Parse("1.7", CultureInfo.InvariantCulture);
        

[Description("Schedule values of 0.0 indicates no zone temperature overcooling will be provided" +
    " to gain additional dehumidification. Schedule values should be >= 0 and <= 3 (d" +
    "eltaC).")]
[JsonProperty(PropertyName="overcool_range_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OvercoolRangeScheduleName { get; set; } = "";
        

[Description(@"The value of this input field is used to adjust the cooling setpoint temperature (established by the associated ZoneControl:Thermostat object) downward based on the difference between the zone air relative humidity level and the dehumidifying relative humidity setpoint.")]
[JsonProperty(PropertyName="overcool_control_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OvercoolControlRatio { get; set; } = Double.Parse("3.6", CultureInfo.InvariantCulture);
    }
    
    public enum ZoneControl_Thermostat_TemperatureAndHumidity_DehumidificationControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Overcool")]
        Overcool = 2,
    }
    
    public enum ZoneControl_Thermostat_TemperatureAndHumidity_OvercoolRangeInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Constant")]
        Constant = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Scheduled")]
        Scheduled = 2,
    }
    
    [Description("Used for a heating only thermostat. The setpoint can be scheduled and varied thro" +
        "ughout the simulation but only heating is allowed with this control type.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ThermostatSetpoint_SingleHeating
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="setpoint_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointTemperatureScheduleName { get; set; } = "";
    }
    
    [Description("Used for a cooling only thermostat. The setpoint can be scheduled and varied thro" +
        "ughout the simulation but only cooling is allowed.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ThermostatSetpoint_SingleCooling
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="setpoint_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointTemperatureScheduleName { get; set; } = "";
    }
    
    [Description("Used for a heating and cooling thermostat with a single setpoint. The setpoint ca" +
        "n be scheduled and varied throughout the simulation for both heating and cooling" +
        ".")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ThermostatSetpoint_SingleHeatingOrCooling
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="setpoint_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointTemperatureScheduleName { get; set; } = "";
    }
    
    [Description("Used for a heating and cooling thermostat with dual setpoints. The setpoints can " +
        "be scheduled and varied throughout the simulation for both heating and cooling.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ThermostatSetpoint_DualSetpoint
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="heating_setpoint_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingSetpointTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="cooling_setpoint_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingSetpointTemperatureScheduleName { get; set; } = "";
    }
    
    [Description("Used for heating only thermal comfort control. The PMV setpoint can be scheduled " +
        "and varied throughout the simulation but only heating is allowed with this contr" +
        "ol type.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ThermostatSetpoint_ThermalComfort_Fanger_SingleHeating
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Schedule values should be Predicted Mean Vote (PMV)")]
[JsonProperty(PropertyName="fanger_thermal_comfort_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FangerThermalComfortScheduleName { get; set; } = "";
    }
    
    [Description("Used for cooling only thermal comfort control. The PMV setpoint can be scheduled " +
        "and varied throughout the simulation but only cooling is allowed with this contr" +
        "ol type.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ThermostatSetpoint_ThermalComfort_Fanger_SingleCooling
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Schedule values should be Predicted Mean Vote (PMV)")]
[JsonProperty(PropertyName="fanger_thermal_comfort_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FangerThermalComfortScheduleName { get; set; } = "";
    }
    
    [Description("Used for heating and cooling thermal comfort control with a single setpoint. The " +
        "PMV setpoint can be scheduled and varied throughout the simulation for both heat" +
        "ing and cooling.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ThermostatSetpoint_ThermalComfort_Fanger_SingleHeatingOrCooling
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Schedule values should be Predicted Mean Vote (PMV)")]
[JsonProperty(PropertyName="fanger_thermal_comfort_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FangerThermalComfortScheduleName { get; set; } = "";
    }
    
    [Description("Used for heating and cooling thermal comfort control with dual setpoints. The PMV" +
        " setpoints can be scheduled and varied throughout the simulation for both heatin" +
        "g and cooling.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ThermostatSetpoint_ThermalComfort_Fanger_DualSetpoint
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Schedule values should be Predicted Mean Vote (PMV)")]
[JsonProperty(PropertyName="fanger_thermal_comfort_heating_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FangerThermalComfortHeatingScheduleName { get; set; } = "";
        

[Description("Schedule values should be Predicted Mean Vote (PMV)")]
[JsonProperty(PropertyName="fanger_thermal_comfort_cooling_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FangerThermalComfortCoolingScheduleName { get; set; } = "";
    }
    
    [Description("Define the Thermostat StagedDualSetpoint settings for a zone or list of zones. If" +
        " you use a ZoneList in the Zone or ZoneList name field then this definition appl" +
        "ies to all the zones in the ZoneList.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneControl_Thermostat_StagedDualSetpoint
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_or_zonelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneOrZonelistName { get; set; } = "";
        

[Description("Enter the number of the following sets of data for heating temperature offset")]
[JsonProperty(PropertyName="number_of_heating_stages", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfHeatingStages { get; set; } = null;
        

[JsonProperty(PropertyName="heating_temperature_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingTemperatureSetpointScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="heating_throttling_temperature_range", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingThrottlingTemperatureRange { get; set; } = Double.Parse("1.1", CultureInfo.InvariantCulture);
        

[Description(@"The heating temperature offset is used to determine heating stage number for multi stage equipment. When the temperature difference of the heating setpoint and the controlled zone temperature at previous time step is less than Stage 1 value and greater than Stage 2 value, the stage number is 1.")]
[JsonProperty(PropertyName="stage_1_heating_temperature_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Stage1HeatingTemperatureOffset { get; set; } = null;
        

[Description(@"The heating temperature offset is used to determine heating stage number for multi stage equipment. When the temperature difference of the heating setpoint and the controlled zone temperature at previous time step is less than Stage 2 value and greater than Stage 3 value, the stage number is 2. The value of this field has to be less the value at the previous field.")]
[JsonProperty(PropertyName="stage_2_heating_temperature_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Stage2HeatingTemperatureOffset { get; set; } = null;
        

[Description(@"The heating temperature offset is used to determine heating stage number for multi stage equipment. When the temperature difference of the heating setpoint and the controlled zone temperature at previous time step is less than Stage 3 value and greater than Stage 4 value, the stage number is 3. The value of this field has to be less the value at the previous field.")]
[JsonProperty(PropertyName="stage_3_heating_temperature_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Stage3HeatingTemperatureOffset { get; set; } = null;
        

[Description(@"The heating temperature offset is used to determine heating stage number for multi stage equipment. When the temperature difference of the heating setpoint and the controlled zone temperature at previous time step is less than Stage 4 value, the stage number is 4. The value of this field has to be less the value at the previous field.")]
[JsonProperty(PropertyName="stage_4_heating_temperature_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Stage4HeatingTemperatureOffset { get; set; } = null;
        

[Description("Enter the number of the following sets of data for cooling temperature offset")]
[JsonProperty(PropertyName="number_of_cooling_stages", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfCoolingStages { get; set; } = null;
        

[JsonProperty(PropertyName="cooling_temperature_setpoint_base_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingTemperatureSetpointBaseScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="cooling_throttling_temperature_range", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingThrottlingTemperatureRange { get; set; } = Double.Parse("1.1", CultureInfo.InvariantCulture);
        

[Description(@"The cooling temperature offset is used to determine cooling stage number for multi stage equipment. When the temperature difference of the cooling setpoint and the controlled zone temperature at previous time step is greater than Stage 1 value and less than Stage 2 value, the stage number is 1.")]
[JsonProperty(PropertyName="stage_1_cooling_temperature_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Stage1CoolingTemperatureOffset { get; set; } = null;
        

[Description(@"The cooling temperature offset is used to determine cooling stage number for multi stage equipment. When the temperature difference of the cooling setpoint and the controlled zone temperature at previous time step is greater than Stage 2 value and less than Stage 3 value, the stage number is 2. The value of this field has to be greater than the value at the previous field.")]
[JsonProperty(PropertyName="stage_2_cooling_temperature_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Stage2CoolingTemperatureOffset { get; set; } = null;
        

[Description(@"The cooling temperature offset is used to determine cooling stage number for multi stage equipment. When the temperature difference of the cooling setpoint and the controlled zone temperature at previous time step is greater than Stage 3 value and less than Stage 4 value, the stage number is 3. The value of this field has to be greater than the value at the previous field.")]
[JsonProperty(PropertyName="stage_3_cooling_temperature_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Stage3CoolingTemperatureOffset { get; set; } = null;
        

[Description(@"The cooling temperature offset is used to determine cooling stage number for multi stage equipment. When the temperature difference of the cooling setpoint and the controlled zone temperature at previous time step is greater than Stage 4 value, the stage number is 4. The value of this field has to be greater than the value at the previous field.")]
[JsonProperty(PropertyName="stage_4_cooling_temperature_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Stage4CoolingTemperatureOffset { get; set; } = null;
    }
    
    [Description("Used to control a zone to a specified indoor level of CO2 or generic contaminants" +
        ", or to specify minimum CO2 concentration schedule name for a zone.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneControl_ContaminantController
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Availability schedule name for CO2 controller. Schedule value > 0 means the CO2 c" +
    "ontroller is enabled. If this field is blank, then CO2 controller is always enab" +
    "led.")]
[JsonProperty(PropertyName="carbon_dioxide_control_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CarbonDioxideControlAvailabilityScheduleName { get; set; } = "";
        

[Description("Schedule values should be carbon dioxide concentration in parts per million (ppm)" +
    "")]
[JsonProperty(PropertyName="carbon_dioxide_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CarbonDioxideSetpointScheduleName { get; set; } = "";
        

[Description(@"Schedule values should be carbon dioxide concentration in parts per million (ppm) This field is used when the field System Outdoor Air Method = ProportionalControlBasedOnOccupancySchedule or ProportionalControlBasedOnDesignOccupancy, or ProportionalControlBasedOnDesignOARate in Controller:MechanicalVentilation")]
[JsonProperty(PropertyName="minimum_carbon_dioxide_concentration_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumCarbonDioxideConcentrationScheduleName { get; set; } = "";
        

[Description(@"Schedule values should be carbon dioxide concentration in parts per million (ppm) This field is used when the field System Outdoor Air Method = ProportionalControlBasedOnOccupancySchedule or ProportionalControlBasedOnDesignOccupancy or ProportionalControlBasedOnDesignOARate.")]
[JsonProperty(PropertyName="maximum_carbon_dioxide_concentration_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaximumCarbonDioxideConcentrationScheduleName { get; set; } = "";
        

[Description("Availability schedule name for generic contaminant controller. Schedule value > 0" +
    " means the generic contaminant controller is enabled. If this field is blank, th" +
    "en generic contaminant controller is always enabled.")]
[JsonProperty(PropertyName="generic_contaminant_control_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string GenericContaminantControlAvailabilityScheduleName { get; set; } = "";
        

[Description("Schedule values should be generic contaminant concentration in parts per million " +
    "(ppm) This field is used when the field System Outdoor Air Method = IndoorAirQua" +
    "lityProcedureGenericContaminant in Controller:MechanicalVentilation")]
[JsonProperty(PropertyName="generic_contaminant_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string GenericContaminantSetpointScheduleName { get; set; } = "";
    }
}
