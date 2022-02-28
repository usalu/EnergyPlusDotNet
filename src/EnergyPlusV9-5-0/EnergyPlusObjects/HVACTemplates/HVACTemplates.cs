namespace EnergyPlus.HVACTemplates
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
    using EnergyPlus.ZoneHVACControlsandThermostats;
    using EnergyPlus.ZoneHVACEquipmentConnections;
    using EnergyPlus.ZoneHVACForcedAirUnits;
    using EnergyPlus.ZoneHVACRadiativeConvectiveUnits;
    
    
    [Description(@"Zone thermostat control. Referenced schedules must be defined elsewhere in the idf. Thermostat control type is dual setpoint with deadband. It is not necessary to create a thermostat object for every zone, only for each unique set of setpoint schedules. For example, an office building may have two thermostat objects, one for ""Office"" and one for ""Storage"".")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_Thermostat
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Leave blank if constant setpoint specified below, must enter schedule or constant" +
    " setpoint")]
[JsonProperty(PropertyName="heating_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingSetpointScheduleName { get; set; } = "";
        

[Description("Ignored if schedule specified above, must enter schedule or constant setpoint")]
[JsonProperty(PropertyName="constant_heating_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConstantHeatingSetpoint { get; set; } = null;
        

[Description("Leave blank if constant setpoint specified below, must enter schedule or constant" +
    " setpoint")]
[JsonProperty(PropertyName="cooling_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingSetpointScheduleName { get; set; } = "";
        

[Description("Ignored if schedule specified above, must enter schedule or constant setpoint")]
[JsonProperty(PropertyName="constant_cooling_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConstantCoolingSetpoint { get; set; } = null;
    }
    
    [Description("Zone with ideal air system that meets heating or cooling loads")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_Zone_IdealLoadsAirSystem
    {
        

[Description("Zone name must match a building zone name")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Enter the name of a HVACTemplate:Thermostat object. If blank, then it is assumed " +
    "that standard thermostat objects have been defined for this zone.")]
[JsonProperty(PropertyName="template_thermostat_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TemplateThermostatName { get; set; } = "";
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="system_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SystemAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_heating_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumHeatingSupplyAirTemperature { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_cooling_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCoolingSupplyAirTemperature { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_heating_supply_air_humidity_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumHeatingSupplyAirHumidityRatio { get; set; } = Double.Parse("0.0156", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_cooling_supply_air_humidity_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCoolingSupplyAirHumidityRatio { get; set; } = Double.Parse("0.0077", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_IdealLoadsAirSystem_HeatingLimit HeatingLimit { get; set; } = (HVACTemplate_Zone_IdealLoadsAirSystem_HeatingLimit)Enum.Parse(typeof(HVACTemplate_Zone_IdealLoadsAirSystem_HeatingLimit), "NoLimit");
        

[Description("This field is ignored if Heating Limit = NoLimit If this field is blank, there is" +
    " no limit.")]
[JsonProperty(PropertyName="maximum_heating_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumHeatingAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is ignored if Heating Limit = NoLimit If this field is blank, there is" +
    " no limit.")]
[JsonProperty(PropertyName="maximum_sensible_heating_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumSensibleHeatingCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cooling_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_IdealLoadsAirSystem_CoolingLimit CoolingLimit { get; set; } = (HVACTemplate_Zone_IdealLoadsAirSystem_CoolingLimit)Enum.Parse(typeof(HVACTemplate_Zone_IdealLoadsAirSystem_CoolingLimit), "NoLimit");
        

[Description("This field is ignored if Cooling Limit = NoLimit This field is required if Outdoo" +
    "r Air Economizer Type is anything other than NoEconomizer.")]
[JsonProperty(PropertyName="maximum_cooling_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumCoolingAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is ignored if Cooling Limit = NoLimit")]
[JsonProperty(PropertyName="maximum_total_cooling_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumTotalCoolingCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("If blank, heating is always available.")]
[JsonProperty(PropertyName="heating_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingAvailabilityScheduleName { get; set; } = "";
        

[Description("If blank, cooling is always available.")]
[JsonProperty(PropertyName="cooling_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingAvailabilityScheduleName { get; set; } = "";
        

[Description(@"ConstantSensibleHeatRatio means that the ideal loads system will be controlled to meet the sensible cooling load, and the latent cooling rate will be computed using a constant sensible heat ratio (SHR) Humidistat means that there is a ZoneControl:Humidistat for this zone and the ideal loads system will attempt to satisfy the humidistat. None means that there is no dehumidification. ConstantSupplyHumidityRatio means that during cooling the supply air will always be at the Minimum Cooling Supply Humidity Ratio.")]
[JsonProperty(PropertyName="dehumidification_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_IdealLoadsAirSystem_DehumidificationControlType DehumidificationControlType { get; set; } = (HVACTemplate_Zone_IdealLoadsAirSystem_DehumidificationControlType)Enum.Parse(typeof(HVACTemplate_Zone_IdealLoadsAirSystem_DehumidificationControlType), "ConstantSensibleHeatRatio");
        

[Description("This field is applicable only when Dehumidification Control Type is ConstantSensi" +
    "bleHeatRatio")]
[JsonProperty(PropertyName="cooling_sensible_heat_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingSensibleHeatRatio { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[Description("Zone relative humidity setpoint in percent (0 to 100)")]
[JsonProperty(PropertyName="dehumidification_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DehumidificationSetpoint { get; set; } = Double.Parse("60", CultureInfo.InvariantCulture);
        

[Description(@"None means that there is no humidification. Humidistat means that there is a ZoneControl:Humidistat for this zone and the ideal loads system will attempt to satisfy the humidistat. ConstantSupplyHumidityRatio means that during heating the supply air will always be at the Maximum Heating Supply Humidity Ratio.")]
[JsonProperty(PropertyName="humidification_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_IdealLoadsAirSystem_HumidificationControlType HumidificationControlType { get; set; } = (HVACTemplate_Zone_IdealLoadsAirSystem_HumidificationControlType)Enum.Parse(typeof(HVACTemplate_Zone_IdealLoadsAirSystem_HumidificationControlType), "None");
        

[Description("Zone relative humidity setpoint in percent (0 to 100)")]
[JsonProperty(PropertyName="humidification_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidificationSetpoint { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
        

[Description(@"None means there is no outdoor air and all related fields will be ignored Flow/Person, Flow/Zone, Flow/Area, Sum, and Maximum use the values in the next three fields: Outdoor Air Flow Rate per Person, Outdoor Air Flow Rate per Zone Floor Area, and Outdoor Air Flow Rate per Zone. DetailedSpecification ignores these three Outdoor Air Flow Rate fields and instead references design specification objects named in the fields Design Specification Outdoor Air Object Name and Design Specification Zone Air Distribution Object Name.")]
[JsonProperty(PropertyName="outdoor_air_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_IdealLoadsAirSystem_OutdoorAirMethod OutdoorAirMethod { get; set; } = (HVACTemplate_Zone_IdealLoadsAirSystem_OutdoorAirMethod)Enum.Parse(typeof(HVACTemplate_Zone_IdealLoadsAirSystem_OutdoorAirMethod), "None");
        

[Description("Default 0.00944 is 20 cfm per person This input is used if the field Outdoor Air " +
    "Method is Flow/Person, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerPerson { get; set; } = Double.Parse("0.00944", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Area, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZoneFloorArea { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Zone, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZone { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description(@"When the name of a DesignSpecification:OutdoorAir object is entered, the minimum outdoor air flow rate will be computed using these specifications. The outdoor air flow rate will also be affected by the next two fields. If this field is blank, there will be no outdoor air and the remaining fields will be ignored.")]
[JsonProperty(PropertyName="design_specification_outdoor_air_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationOutdoorAirObjectName { get; set; } = "";
        

[Description(@"This field controls how the minimum outdoor air flow rate is calculated. None means that design occupancy will be used to compute the minimum outdoor air flow rate OccupancySchedule means that current occupancy level will be used. CO2Setpoint means that the design occupancy will be used to compute the minimum outdoor air flow rate and the outdoor air flow rate may be increased if necessary to maintain the indoor air carbon dioxide setpoint defined in a ZoneControl:ContaminantController object.")]
[JsonProperty(PropertyName="demand_controlled_ventilation_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_IdealLoadsAirSystem_DemandControlledVentilationType DemandControlledVentilationType { get; set; } = (HVACTemplate_Zone_IdealLoadsAirSystem_DemandControlledVentilationType)Enum.Parse(typeof(HVACTemplate_Zone_IdealLoadsAirSystem_DemandControlledVentilationType), "None");
        

[Description("DifferentialDryBulb and DifferentialEnthalpy will increase the outdoor air flow r" +
    "ate when there is a cooling load and the outdoor air temperature or enthalpy is " +
    "below the zone exhaust air temperature or enthalpy.")]
[JsonProperty(PropertyName="outdoor_air_economizer_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_IdealLoadsAirSystem_OutdoorAirEconomizerType OutdoorAirEconomizerType { get; set; } = (HVACTemplate_Zone_IdealLoadsAirSystem_OutdoorAirEconomizerType)Enum.Parse(typeof(HVACTemplate_Zone_IdealLoadsAirSystem_OutdoorAirEconomizerType), "NoEconomizer");
        

[JsonProperty(PropertyName="heat_recovery_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_IdealLoadsAirSystem_HeatRecoveryType HeatRecoveryType { get; set; } = (HVACTemplate_Zone_IdealLoadsAirSystem_HeatRecoveryType)Enum.Parse(typeof(HVACTemplate_Zone_IdealLoadsAirSystem_HeatRecoveryType), "None");
        

[JsonProperty(PropertyName="sensible_heat_recovery_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SensibleHeatRecoveryEffectiveness { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[Description("Applicable only if Heat Recovery Type is Enthalpy.")]
[JsonProperty(PropertyName="latent_heat_recovery_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LatentHeatRecoveryEffectiveness { get; set; } = Double.Parse("0.65", CultureInfo.InvariantCulture);
    }
    
    public enum HVACTemplate_Zone_IdealLoadsAirSystem_HeatingLimit
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="LimitCapacity")]
        LimitCapacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="LimitFlowRate")]
        LimitFlowRate = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="LimitFlowRateAndCapacity")]
        LimitFlowRateAndCapacity = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="NoLimit")]
        NoLimit = 4,
    }
    
    public enum HVACTemplate_Zone_IdealLoadsAirSystem_CoolingLimit
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="LimitCapacity")]
        LimitCapacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="LimitFlowRate")]
        LimitFlowRate = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="LimitFlowRateAndCapacity")]
        LimitFlowRateAndCapacity = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="NoLimit")]
        NoLimit = 4,
    }
    
    public enum HVACTemplate_Zone_IdealLoadsAirSystem_DehumidificationControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ConstantSensibleHeatRatio")]
        ConstantSensibleHeatRatio = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ConstantSupplyHumidityRatio")]
        ConstantSupplyHumidityRatio = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Humidistat")]
        Humidistat = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum HVACTemplate_Zone_IdealLoadsAirSystem_HumidificationControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ConstantSupplyHumidityRatio")]
        ConstantSupplyHumidityRatio = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Humidistat")]
        Humidistat = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    public enum HVACTemplate_Zone_IdealLoadsAirSystem_OutdoorAirMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DetailedSpecification")]
        DetailedSpecification = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Area")]
        FlowArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Person")]
        FlowPerson = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Zone")]
        FlowZone = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Maximum")]
        Maximum = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="Sum")]
        Sum = 7,
    }
    
    public enum HVACTemplate_Zone_IdealLoadsAirSystem_DemandControlledVentilationType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CO2Setpoint")]
        CO2Setpoint = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="OccupancySchedule")]
        OccupancySchedule = 3,
    }
    
    public enum HVACTemplate_Zone_IdealLoadsAirSystem_OutdoorAirEconomizerType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferentialDryBulb")]
        DifferentialDryBulb = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferentialEnthalpy")]
        DifferentialEnthalpy = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="NoEconomizer")]
        NoEconomizer = 3,
    }
    
    public enum HVACTemplate_Zone_IdealLoadsAirSystem_HeatRecoveryType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Enthalpy")]
        Enthalpy = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Sensible")]
        Sensible = 3,
    }
    
    [Description("Zone baseboard heating system.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_Zone_BaseboardHeat
    {
        

[Description("Zone name must match a building zone name")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Enter the name of a HVACTemplate:Thermostat object. If blank, then it is assumed " +
    "that standard thermostat objects have been defined for this zone.")]
[JsonProperty(PropertyName="template_thermostat_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TemplateThermostatName { get; set; } = "";
        

[Description("If blank, value from Sizing:Parameters will be used.")]
[JsonProperty(PropertyName="zone_heating_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingSizingFactor { get; set; } = null;
        

[JsonProperty(PropertyName="baseboard_heating_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_BaseboardHeat_BaseboardHeatingType BaseboardHeatingType { get; set; } = (HVACTemplate_Zone_BaseboardHeat_BaseboardHeatingType)Enum.Parse(typeof(HVACTemplate_Zone_BaseboardHeat_BaseboardHeatingType), "HotWater");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="baseboard_heating_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BaseboardHeatingAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="baseboard_heating_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> BaseboardHeatingCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the name of an HVACTemplate:System:DedicatedOutdoorAir object if this zone " +
    "is served by a separate dedicated outdoor air system (DOAS). Leave field blank i" +
    "f no DOAS serves this zone.")]
[JsonProperty(PropertyName="dedicated_outdoor_air_system_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DedicatedOutdoorAirSystemName { get; set; } = "";
        

[Description(@"Flow/Person, Flow/Zone, Flow/Area, Sum, and Maximum use the values in the next three fields: Outdoor Air Flow Rate per Person, Outdoor Air Flow Rate per Zone Floor Area, and Outdoor Air Flow Rate per Zone. DetailedSpecification ignores these three Outdoor Air Flow Rate fields and instead references design specification objects named in the fields Design Specification Outdoor Air Object Name and Design Specification Zone Air Distribution Object Name.")]
[JsonProperty(PropertyName="outdoor_air_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_BaseboardHeat_OutdoorAirMethod OutdoorAirMethod { get; set; } = (HVACTemplate_Zone_BaseboardHeat_OutdoorAirMethod)Enum.Parse(typeof(HVACTemplate_Zone_BaseboardHeat_OutdoorAirMethod), "Empty");
        

[Description("Default 0.00944 is 20 cfm per person This input is used if the field Outdoor Air " +
    "Method is Flow/Person, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerPerson { get; set; } = Double.Parse("0.00944", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Area, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZoneFloorArea { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Zone, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZone { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This field is used only when Outdoor Air Method=DetailedSpecification.")]
[JsonProperty(PropertyName="design_specification_outdoor_air_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationOutdoorAirObjectName { get; set; } = "";
        

[Description("This field is used only when Outdoor Air Method=DetailedSpecification.")]
[JsonProperty(PropertyName="design_specification_zone_air_distribution_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZoneAirDistributionObjectName { get; set; } = "";
    }
    
    public enum HVACTemplate_Zone_BaseboardHeat_BaseboardHeatingType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 2,
    }
    
    public enum HVACTemplate_Zone_BaseboardHeat_OutdoorAirMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DetailedSpecification")]
        DetailedSpecification = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Area")]
        FlowArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Person")]
        FlowPerson = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Zone")]
        FlowZone = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Maximum")]
        Maximum = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Sum")]
        Sum = 6,
    }
    
    [Description("4 pipe fan coil unit with optional outdoor air.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_Zone_FanCoil
    {
        

[Description("Zone name must match a building zone name")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Enter the name of a HVACTemplate:Thermostat object. If blank, then it is assumed " +
    "that standard thermostat objects have been defined for this zone.")]
[JsonProperty(PropertyName="template_thermostat_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TemplateThermostatName { get; set; } = "";
        

[Description("This field may be set to \"autosize\". If a value is entered, it will be multiplied" +
    " by the Supply Air Sizing Factor and by zone multipliers.")]
[JsonProperty(PropertyName="supply_air_maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SupplyAirMaximumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("If blank, value from Sizing:Parameters will be used.")]
[JsonProperty(PropertyName="zone_heating_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingSizingFactor { get; set; } = null;
        

[Description("If blank, value from Sizing:Parameters will be used.")]
[JsonProperty(PropertyName="zone_cooling_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingSizingFactor { get; set; } = null;
        

[Description(@"Flow/Person, Flow/Zone, Flow/Area, Sum, and Maximum use the values in the next three fields: Outdoor Air Flow Rate per Person, Outdoor Air Flow Rate per Zone Floor Area, and Outdoor Air Flow Rate per Zone. DetailedSpecification ignores these three Outdoor Air Flow Rate fields and instead references design specification objects named in the fields Design Specification Outdoor Air Object Name and Design Specification Zone Air Distribution Object Name.")]
[JsonProperty(PropertyName="outdoor_air_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_FanCoil_OutdoorAirMethod OutdoorAirMethod { get; set; } = (HVACTemplate_Zone_FanCoil_OutdoorAirMethod)Enum.Parse(typeof(HVACTemplate_Zone_FanCoil_OutdoorAirMethod), "Empty");
        

[Description("Default 0.00944 is 20 cfm per person This input is used if the field Outdoor Air " +
    "Method is Flow/Person, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerPerson { get; set; } = Double.Parse("0.00944", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Area, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZoneFloorArea { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Zone, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZone { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="system_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SystemAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="supply_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanDeltaPressure { get; set; } = Double.Parse("75", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanMotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_motor_in_air_stream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanMotorInAirStreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cooling_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_FanCoil_CoolingCoilType CoolingCoilType { get; set; } = (HVACTemplate_Zone_FanCoil_CoolingCoilType)Enum.Parse(typeof(HVACTemplate_Zone_FanCoil_CoolingCoilType), "ChilledWater");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="cooling_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilAvailabilityScheduleName { get; set; } = "";
        

[Description("Used for sizing when Zone Cooling Design Supply Air Temperature Input Method = Su" +
    "pplyAirTemperature")]
[JsonProperty(PropertyName="cooling_coil_design_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilDesignSetpoint { get; set; } = Double.Parse("14", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_FanCoil_HeatingCoilType HeatingCoilType { get; set; } = (HVACTemplate_Zone_FanCoil_HeatingCoilType)Enum.Parse(typeof(HVACTemplate_Zone_FanCoil_HeatingCoilType), "HotWater");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="heating_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilAvailabilityScheduleName { get; set; } = "";
        

[Description("Used for sizing when Zone Heating Design Supply Air Temperature Input Method = Su" +
    "pplyAirTemperature")]
[JsonProperty(PropertyName="heating_coil_design_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingCoilDesignSetpoint { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[Description("Enter the name of an HVACTemplate:System:DedicatedOutdoorAir object if this zone " +
    "is served by a separate dedicated outdoor air system (DOAS). Leave field blank i" +
    "f no DOAS serves this zone.")]
[JsonProperty(PropertyName="dedicated_outdoor_air_system_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DedicatedOutdoorAirSystemName { get; set; } = "";
        

[Description("SupplyAirTemperature = use the value from Cooling Coil Design Setpoint (above) Te" +
    "mperatureDifference = use the value from Zone Cooling Design Supply Air Temperat" +
    "ure Difference")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_FanCoil_ZoneCoolingDesignSupplyAirTemperatureInputMethod ZoneCoolingDesignSupplyAirTemperatureInputMethod { get; set; } = (HVACTemplate_Zone_FanCoil_ZoneCoolingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(HVACTemplate_Zone_FanCoil_ZoneCoolingDesignSupplyAirTemperatureInputMethod), "SupplyAirTemperature");
        

[Description(@"Zone Cooling Design Supply Air Temperature is only used when Zone Cooling Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be subtracted from the zone temperature at peak load to calculate the Zone Cooling Design Supply Air Temperature.")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirTemperatureDifference { get; set; } = Double.Parse("11.11", CultureInfo.InvariantCulture);
        

[Description("SupplyAirTemperature = use the value from Heating Coil Design Setpoint (above) Te" +
    "mperatureDifference = use the value from Zone Heating Design Supply Air Temperat" +
    "ure Difference")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_FanCoil_ZoneHeatingDesignSupplyAirTemperatureInputMethod ZoneHeatingDesignSupplyAirTemperatureInputMethod { get; set; } = (HVACTemplate_Zone_FanCoil_ZoneHeatingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(HVACTemplate_Zone_FanCoil_ZoneHeatingDesignSupplyAirTemperatureInputMethod), "SupplyAirTemperature");
        

[Description(@"Zone Heating Design Supply Air Temperature is only used when Zone Heating Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be added to the zone temperature at peak load to calculate the Zone Heating Design Supply Air Temperature.")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirTemperatureDifference { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
        

[Description("This field is used only when Outdoor Air Method=DetailedSpecification.")]
[JsonProperty(PropertyName="design_specification_outdoor_air_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationOutdoorAirObjectName { get; set; } = "";
        

[Description("This field is used only when Outdoor Air Method=DetailedSpecification.")]
[JsonProperty(PropertyName="design_specification_zone_air_distribution_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZoneAirDistributionObjectName { get; set; } = "";
        

[Description("If this field is left blank, it will default to CyclingFan if a Dedicated Outdoor" +
    " Air System is specified (see above), otherwise it will default to ConstantFanVa" +
    "riableFlow.")]
[JsonProperty(PropertyName="capacity_control_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_FanCoil_CapacityControlMethod CapacityControlMethod { get; set; } = (HVACTemplate_Zone_FanCoil_CapacityControlMethod)Enum.Parse(typeof(HVACTemplate_Zone_FanCoil_CapacityControlMethod), "ASHRAE90VariableFan");
        

[JsonProperty(PropertyName="low_speed_supply_air_flow_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LowSpeedSupplyAirFlowRatio { get; set; } = Double.Parse("0.33", CultureInfo.InvariantCulture);
        

[Description("Medium Speed Supply Air Flow Ratio should be greater than Low Speed Supply Air Fl" +
    "ow Ratio")]
[JsonProperty(PropertyName="medium_speed_supply_air_flow_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MediumSpeedSupplyAirFlowRatio { get; set; } = Double.Parse("0.66", CultureInfo.InvariantCulture);
        

[Description("Value of schedule multiplies maximum outdoor air flow rate This schedule is ignor" +
    "ed if this zone is served by an HVACTemplate dedicated outdoor air system.")]
[JsonProperty(PropertyName="outdoor_air_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="baseboard_heating_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_FanCoil_BaseboardHeatingType BaseboardHeatingType { get; set; } = (HVACTemplate_Zone_FanCoil_BaseboardHeatingType)Enum.Parse(typeof(HVACTemplate_Zone_FanCoil_BaseboardHeatingType), "None");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="baseboard_heating_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BaseboardHeatingAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="baseboard_heating_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> BaseboardHeatingCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
    }
    
    public enum HVACTemplate_Zone_FanCoil_OutdoorAirMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DetailedSpecification")]
        DetailedSpecification = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Area")]
        FlowArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Person")]
        FlowPerson = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Zone")]
        FlowZone = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Maximum")]
        Maximum = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Sum")]
        Sum = 6,
    }
    
    public enum HVACTemplate_Zone_FanCoil_CoolingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ChilledWater")]
        ChilledWater = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ChilledWaterDetailedFlatModel")]
        ChilledWaterDetailedFlatModel = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchangerAssistedChilledWater")]
        HeatExchangerAssistedChilledWater = 3,
    }
    
    public enum HVACTemplate_Zone_FanCoil_HeatingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 2,
    }
    
    public enum HVACTemplate_Zone_FanCoil_ZoneCoolingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 2,
    }
    
    public enum HVACTemplate_Zone_FanCoil_ZoneHeatingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 2,
    }
    
    public enum HVACTemplate_Zone_FanCoil_CapacityControlMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAE90VariableFan")]
        ASHRAE90VariableFan = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ConstantFanVariableFlow")]
        ConstantFanVariableFlow = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CyclingFan")]
        CyclingFan = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MultiSpeedFan")]
        MultiSpeedFan = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableFanConstantFlow")]
        VariableFanConstantFlow = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableFanVariableFlow")]
        VariableFanVariableFlow = 5,
    }
    
    public enum HVACTemplate_Zone_FanCoil_BaseboardHeatingType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    [Description("Packaged Terminal Air Conditioner")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_Zone_PTAC
    {
        

[Description("Zone name must match a building zone name")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Enter the name of a HVACTemplate:Thermostat object. If blank, then it is assumed " +
    "that standard thermostat objects have been defined for this zone.")]
[JsonProperty(PropertyName="template_thermostat_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TemplateThermostatName { get; set; } = "";
        

[Description("Supply air flow rate during cooling operation This field may be set to \"autosize\"" +
    ". If a value is entered, it will be multiplied by the Supply Air Sizing Factor a" +
    "nd by zone multipliers.")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Supply air flow rate during heating operation This field may be set to \"autosize\"" +
    ". If a value is entered, it will be multiplied by the Supply Air Sizing Factor a" +
    "nd by zone multipliers.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Supply air flow rate when no cooling or heating is needed Only used when heat pump fan operating mode is continuous. This air flow rate is used when no heating or cooling is required and the DX coil compressor is off. If this field is left blank or zero, the supply air flow rate from the previous on cycle (either cooling or heating) is used. A value entered in this field will *not* be multiplied by the sizing factor or by zone multipliers. It is best to autosize or leave blank when using zone multipliers.")]
[JsonProperty(PropertyName="no_load_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoLoadSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("If blank, value from Sizing:Parameters will be used.")]
[JsonProperty(PropertyName="zone_heating_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingSizingFactor { get; set; } = null;
        

[Description("If blank, value from Sizing:Parameters will be used.")]
[JsonProperty(PropertyName="zone_cooling_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingSizingFactor { get; set; } = null;
        

[Description(@"Flow/Person, Flow/Zone, Flow/Area, Sum, and Maximum use the values in the next three fields: Outdoor Air Flow Rate per Person, Outdoor Air Flow Rate per Zone Floor Area, and Outdoor Air Flow Rate per Zone. DetailedSpecification ignores these three Outdoor Air Flow Rate fields and instead references design specification objects named in the fields Design Specification Outdoor Air Object Name and Design Specification Zone Air Distribution Object Name.")]
[JsonProperty(PropertyName="outdoor_air_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_PTAC_OutdoorAirMethod OutdoorAirMethod { get; set; } = (HVACTemplate_Zone_PTAC_OutdoorAirMethod)Enum.Parse(typeof(HVACTemplate_Zone_PTAC_OutdoorAirMethod), "Empty");
        

[Description("Default 0.00944 is 20 cfm per person This input is used if the field Outdoor Air " +
    "Method is Flow/Person, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerPerson { get; set; } = Double.Parse("0.00944", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Area, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZoneFloorArea { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Zone, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZone { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="system_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SystemAvailabilityScheduleName { get; set; } = "";
        

[Description("Refers to a schedule to specify unitary supply fan operating mode. Schedule Name " +
    "values of 0 indicate cycling fan (auto) Schedule values of 1 indicate continuous" +
    " fan (on) If this field is left blank, a schedule of always zero (cycling fan) w" +
    "ill be used.")]
[JsonProperty(PropertyName="supply_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyFanOperatingModeScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="supply_fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_PTAC_SupplyFanPlacement SupplyFanPlacement { get; set; } = (HVACTemplate_Zone_PTAC_SupplyFanPlacement)Enum.Parse(typeof(HVACTemplate_Zone_PTAC_SupplyFanPlacement), "DrawThrough");
        

[JsonProperty(PropertyName="supply_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanDeltaPressure { get; set; } = Double.Parse("75", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanMotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cooling_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_PTAC_CoolingCoilType CoolingCoilType { get; set; } = (HVACTemplate_Zone_PTAC_CoolingCoilType)Enum.Parse(typeof(HVACTemplate_Zone_PTAC_CoolingCoilType), "SingleSpeedDX");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="cooling_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilAvailabilityScheduleName { get; set; } = "";
        

[Description("Total cooling capacity not accounting for the effect of supply air fan heat Ratin" +
    "g point: air entering the cooling coil at 26.7 C dry-bulb/19.4 C wet-bulb, and a" +
    "ir entering the outdoor condenser coil at 35 C dry-bulb/23.9 C wet-bulb")]
[JsonProperty(PropertyName="cooling_coil_gross_rated_total_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingCoilGrossRatedTotalCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Rated sensible heat ratio (gross sensible capacity/gross total capacity) Sensible" +
    " and total capacities do not include effect of supply fan heat")]
[JsonProperty(PropertyName="cooling_coil_gross_rated_sensible_heat_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingCoilGrossRatedSensibleHeatRatio { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Gross cooling capacity divided by power input to the compressor and outdoor fan, " +
    "does not include supply fan heat or supply fan electrical energy input")]
[JsonProperty(PropertyName="cooling_coil_gross_rated_cooling_cop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilGrossRatedCoolingCop { get; set; } = Double.Parse("3", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_PTAC_HeatingCoilType HeatingCoilType { get; set; } = (HVACTemplate_Zone_PTAC_HeatingCoilType)Enum.Parse(typeof(HVACTemplate_Zone_PTAC_HeatingCoilType), "Electric");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="heating_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="heating_coil_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingCoilCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Applies only if Heating Coil Type is Gas")]
[JsonProperty(PropertyName="gas_heating_coil_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasHeatingCoilEfficiency { get; set; } = Double.Parse("0.8", CultureInfo.InvariantCulture);
        

[Description("Applies only if Heating Coil Type is Gas")]
[JsonProperty(PropertyName="gas_heating_coil_parasitic_electric_load", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasHeatingCoilParasiticElectricLoad { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Enter the name of an HVACTemplate:System:DedicatedOutdoorAir object if this zone " +
    "is served by a separate dedicated outdoor air system (DOAS). Leave field blank i" +
    "f no DOAS serves this zone.")]
[JsonProperty(PropertyName="dedicated_outdoor_air_system_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DedicatedOutdoorAirSystemName { get; set; } = "";
        

[Description("SupplyAirTemperature = use the value from Zone Cooling Design Supply Air Temperat" +
    "ure TemperatureDifference = use the value from Zone Cooling Design Supply Air Te" +
    "mperature Difference")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_PTAC_ZoneCoolingDesignSupplyAirTemperatureInputMethod ZoneCoolingDesignSupplyAirTemperatureInputMethod { get; set; } = (HVACTemplate_Zone_PTAC_ZoneCoolingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(HVACTemplate_Zone_PTAC_ZoneCoolingDesignSupplyAirTemperatureInputMethod), "SupplyAirTemperature");
        

[Description("Zone Cooling Design Supply Air Temperature is only used when Zone Cooling Design " +
    "Supply Air Temperature Input Method = SupplyAirTemperature")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirTemperature { get; set; } = Double.Parse("14", CultureInfo.InvariantCulture);
        

[Description(@"Zone Cooling Design Supply Air Temperature is only used when Zone Cooling Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be subtracted from the zone temperature at peak load to calculate the Zone Cooling Design Supply Air Temperature.")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirTemperatureDifference { get; set; } = Double.Parse("11.11", CultureInfo.InvariantCulture);
        

[Description("SupplyAirTemperature = use the value from Zone Heating Design Supply Air Temperat" +
    "ure TemperatureDifference = use the value from Zone Heating Design Supply Air Te" +
    "mperature Difference")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_PTAC_ZoneHeatingDesignSupplyAirTemperatureInputMethod ZoneHeatingDesignSupplyAirTemperatureInputMethod { get; set; } = (HVACTemplate_Zone_PTAC_ZoneHeatingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(HVACTemplate_Zone_PTAC_ZoneHeatingDesignSupplyAirTemperatureInputMethod), "SupplyAirTemperature");
        

[Description("Zone Heating Design Supply Air Temperature is only used when Zone Heating Design " +
    "Supply Air Temperature Input Method = SupplyAirTemperature")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirTemperature { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[Description(@"Zone Heating Design Supply Air Temperature is only used when Zone Heating Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be added to the zone temperature at peak load to calculate the Zone Heating Design Supply Air Temperature.")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirTemperatureDifference { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
        

[Description("This field is used only when Outdoor Air Method=DetailedSpecification.")]
[JsonProperty(PropertyName="design_specification_outdoor_air_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationOutdoorAirObjectName { get; set; } = "";
        

[Description("This field is used only when Outdoor Air Method=DetailedSpecification.")]
[JsonProperty(PropertyName="design_specification_zone_air_distribution_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZoneAirDistributionObjectName { get; set; } = "";
        

[JsonProperty(PropertyName="baseboard_heating_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_PTAC_BaseboardHeatingType BaseboardHeatingType { get; set; } = (HVACTemplate_Zone_PTAC_BaseboardHeatingType)Enum.Parse(typeof(HVACTemplate_Zone_PTAC_BaseboardHeatingType), "None");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="baseboard_heating_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BaseboardHeatingAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="baseboard_heating_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> BaseboardHeatingCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="capacity_control_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_PTAC_CapacityControlMethod CapacityControlMethod { get; set; } = (HVACTemplate_Zone_PTAC_CapacityControlMethod)Enum.Parse(typeof(HVACTemplate_Zone_PTAC_CapacityControlMethod), "None");
    }
    
    public enum HVACTemplate_Zone_PTAC_OutdoorAirMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DetailedSpecification")]
        DetailedSpecification = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Area")]
        FlowArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Person")]
        FlowPerson = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Zone")]
        FlowZone = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Maximum")]
        Maximum = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Sum")]
        Sum = 6,
    }
    
    public enum HVACTemplate_Zone_PTAC_SupplyFanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum HVACTemplate_Zone_PTAC_CoolingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SingleSpeedDX")]
        SingleSpeedDX = 1,
    }
    
    public enum HVACTemplate_Zone_PTAC_HeatingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Gas")]
        Gas = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 3,
    }
    
    public enum HVACTemplate_Zone_PTAC_ZoneCoolingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 2,
    }
    
    public enum HVACTemplate_Zone_PTAC_ZoneHeatingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 2,
    }
    
    public enum HVACTemplate_Zone_PTAC_BaseboardHeatingType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    public enum HVACTemplate_Zone_PTAC_CapacityControlMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SingleZoneVAV")]
        SingleZoneVAV = 2,
    }
    
    [Description("Packaged Terminal Heat Pump")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_Zone_PTHP
    {
        

[Description("Zone name must match a building zone name")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Enter the name of a HVACTemplate:Thermostat object. If blank, then it is assumed " +
    "that standard thermostat objects have been defined for this zone.")]
[JsonProperty(PropertyName="template_thermostat_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TemplateThermostatName { get; set; } = "";
        

[Description("Supply air flow rate during cooling operation This field may be set to \"autosize\"" +
    ". If a value is entered, it will be multiplied by the Supply Air Sizing Factor a" +
    "nd by zone multipliers.")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Supply air flow rate during heating operation This field may be set to \"autosize\"" +
    ". If a value is entered, it will be multiplied by the Supply Air Sizing Factor a" +
    "nd by zone multipliers.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Supply air flow rate when no cooling or heating is needed Only used when heat pump fan operating mode is continuous. This air flow rate is used when no heating or cooling is required and the DX coil compressor is off. If this field is left blank or zero, the supply air flow rate from the previous on cycle (either cooling or heating) is used. A value entered in this field will *not* be multiplied by the sizing factor or by zone multipliers. It is best to autosize or leave blank when using zone multipliers.")]
[JsonProperty(PropertyName="no_load_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoLoadSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("If blank, value from Sizing:Parameters will be used.")]
[JsonProperty(PropertyName="zone_heating_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingSizingFactor { get; set; } = null;
        

[Description("If blank, value from Sizing:Parameters will be used.")]
[JsonProperty(PropertyName="zone_cooling_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingSizingFactor { get; set; } = null;
        

[Description(@"Flow/Person, Flow/Zone, Flow/Area, Sum, and Maximum use the values in the next three fields: Outdoor Air Flow Rate per Person, Outdoor Air Flow Rate per Zone Floor Area, and Outdoor Air Flow Rate per Zone. DetailedSpecification ignores these three Outdoor Air Flow Rate fields and instead references design specification objects named in the fields Design Specification Outdoor Air Object Name and Design Specification Zone Air Distribution Object Name.")]
[JsonProperty(PropertyName="outdoor_air_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_PTHP_OutdoorAirMethod OutdoorAirMethod { get; set; } = (HVACTemplate_Zone_PTHP_OutdoorAirMethod)Enum.Parse(typeof(HVACTemplate_Zone_PTHP_OutdoorAirMethod), "Empty");
        

[Description("Default 0.00944 is 20 cfm per person This input is used if the field Outdoor Air " +
    "Method is Flow/Person, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerPerson { get; set; } = Double.Parse("0.00944", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Area, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZoneFloorArea { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Zone, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZone { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="system_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SystemAvailabilityScheduleName { get; set; } = "";
        

[Description("Refers to a schedule to specify unitary supply fan operating mode. Schedule value" +
    "s of 0 indicate cycling fan (auto) Schedule values of 1 indicate continuous fan " +
    "(on) If this field is left blank, a schedule of always zero (cycling fan) will b" +
    "e used.")]
[JsonProperty(PropertyName="supply_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyFanOperatingModeScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="supply_fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_PTHP_SupplyFanPlacement SupplyFanPlacement { get; set; } = (HVACTemplate_Zone_PTHP_SupplyFanPlacement)Enum.Parse(typeof(HVACTemplate_Zone_PTHP_SupplyFanPlacement), "DrawThrough");
        

[JsonProperty(PropertyName="supply_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanDeltaPressure { get; set; } = Double.Parse("75", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanMotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cooling_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_PTHP_CoolingCoilType CoolingCoilType { get; set; } = (HVACTemplate_Zone_PTHP_CoolingCoilType)Enum.Parse(typeof(HVACTemplate_Zone_PTHP_CoolingCoilType), "SingleSpeedDX");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="cooling_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilAvailabilityScheduleName { get; set; } = "";
        

[Description("Total cooling capacity not accounting for the effect of supply air fan heat Ratin" +
    "g point: air entering the cooling coil at 26.7 C dry-bulb/19.4 C wet-bulb, and a" +
    "ir entering the outdoor condenser coil at 35 C dry-bulb/23.9 C wet-bulb")]
[JsonProperty(PropertyName="cooling_coil_gross_rated_total_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingCoilGrossRatedTotalCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Rated sensible heat ratio (gross sensible capacity/gross total capacity) Sensible" +
    " and total capacities do not include effect of supply fan heat")]
[JsonProperty(PropertyName="cooling_coil_gross_rated_sensible_heat_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingCoilGrossRatedSensibleHeatRatio { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Gross cooling capacity divided by power input to the compressor and outdoor fan, " +
    "does not include supply fan heat or supply fan electrical energy input")]
[JsonProperty(PropertyName="cooling_coil_gross_rated_cop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilGrossRatedCop { get; set; } = Double.Parse("3", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heat_pump_heating_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_PTHP_HeatPumpHeatingCoilType HeatPumpHeatingCoilType { get; set; } = (HVACTemplate_Zone_PTHP_HeatPumpHeatingCoilType)Enum.Parse(typeof(HVACTemplate_Zone_PTHP_HeatPumpHeatingCoilType), "SingleSpeedDXHeatPump");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="heat_pump_heating_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatPumpHeatingCoilAvailabilityScheduleName { get; set; } = "";
        

[Description("Capacity excluding supply air fan heat Rating point outdoor dry-bulb temp 8.33 C," +
    " outdoor wet-bulb temp 6.11 C Rating point heating coil entering air dry-bulb 21" +
    ".11 C, coil entering wet-bulb 15.55 C")]
[JsonProperty(PropertyName="heat_pump_heating_coil_gross_rated_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatPumpHeatingCoilGrossRatedCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Heat Pump Heating Coil Rated Capacity divided by power input to the compressor and outdoor fan, Does not include supply air fan heat or supply air fan electrical energy Rating point outdoor dry-bulb temp 8.33 C, outdoor wet-bulb temp 6.11 C Rating point heating coil entering air dry-bulb 21.11 C, coil entering wet-bulb 15.55 C")]
[JsonProperty(PropertyName="heat_pump_heating_coil_gross_rated_cop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatPumpHeatingCoilGrossRatedCop { get; set; } = Double.Parse("2.75", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heat_pump_heating_minimum_outdoor_dry_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatPumpHeatingMinimumOutdoorDryBulbTemperature { get; set; } = Double.Parse("-8", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heat_pump_defrost_maximum_outdoor_dry_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatPumpDefrostMaximumOutdoorDryBulbTemperature { get; set; } = Double.Parse("5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heat_pump_defrost_strategy", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_PTHP_HeatPumpDefrostStrategy HeatPumpDefrostStrategy { get; set; } = (HVACTemplate_Zone_PTHP_HeatPumpDefrostStrategy)Enum.Parse(typeof(HVACTemplate_Zone_PTHP_HeatPumpDefrostStrategy), "ReverseCycle");
        

[JsonProperty(PropertyName="heat_pump_defrost_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_PTHP_HeatPumpDefrostControl HeatPumpDefrostControl { get; set; } = (HVACTemplate_Zone_PTHP_HeatPumpDefrostControl)Enum.Parse(typeof(HVACTemplate_Zone_PTHP_HeatPumpDefrostControl), "Timed");
        

[Description("Fraction of time in defrost mode only applicable if Timed defrost control is spec" +
    "ified")]
[JsonProperty(PropertyName="heat_pump_defrost_time_period_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatPumpDefrostTimePeriodFraction { get; set; } = Double.Parse("0.058333", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supplemental_heating_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_PTHP_SupplementalHeatingCoilType SupplementalHeatingCoilType { get; set; } = (HVACTemplate_Zone_PTHP_SupplementalHeatingCoilType)Enum.Parse(typeof(HVACTemplate_Zone_PTHP_SupplementalHeatingCoilType), "Electric");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="supplemental_heating_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplementalHeatingCoilAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="supplemental_heating_coil_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SupplementalHeatingCoilCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Supplemental heater will not operate when outdoor temperature exceeds this value." +
    "")]
[JsonProperty(PropertyName="supplemental_heating_coil_maximum_outdoor_dry_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplementalHeatingCoilMaximumOutdoorDryBulbTemperature { get; set; } = Double.Parse("21", CultureInfo.InvariantCulture);
        

[Description("Applies only if Supplemental Heating Coil Type is Gas")]
[JsonProperty(PropertyName="supplemental_gas_heating_coil_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplementalGasHeatingCoilEfficiency { get; set; } = Double.Parse("0.8", CultureInfo.InvariantCulture);
        

[Description("Applies only if Supplemental Heating Coil Type is Gas")]
[JsonProperty(PropertyName="supplemental_gas_heating_coil_parasitic_electric_load", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplementalGasHeatingCoilParasiticElectricLoad { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Enter the name of an HVACTemplate:System:DedicatedOutdoorAir object if this zone " +
    "is served by a separate dedicated outdoor air system (DOAS). Leave field blank i" +
    "f no DOAS serves this zone.")]
[JsonProperty(PropertyName="dedicated_outdoor_air_system_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DedicatedOutdoorAirSystemName { get; set; } = "";
        

[Description("SupplyAirTemperature = use the value from Zone Cooling Design Supply Air Temperat" +
    "ure TemperatureDifference = use the value from Zone Cooling Design Supply Air Te" +
    "mperature Difference")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_PTHP_ZoneCoolingDesignSupplyAirTemperatureInputMethod ZoneCoolingDesignSupplyAirTemperatureInputMethod { get; set; } = (HVACTemplate_Zone_PTHP_ZoneCoolingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(HVACTemplate_Zone_PTHP_ZoneCoolingDesignSupplyAirTemperatureInputMethod), "SupplyAirTemperature");
        

[Description("Zone Cooling Design Supply Air Temperature is only used when Zone Cooling Design " +
    "Supply Air Temperature Input Method = SupplyAirTemperature")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirTemperature { get; set; } = Double.Parse("14", CultureInfo.InvariantCulture);
        

[Description(@"Zone Cooling Design Supply Air Temperature is only used when Zone Cooling Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be subtracted from the zone temperature at peak load to calculate the Zone Cooling Design Supply Air Temperature.")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirTemperatureDifference { get; set; } = Double.Parse("11.11", CultureInfo.InvariantCulture);
        

[Description("SupplyAirTemperature = use the value from Zone Heating Design Supply Air Temperat" +
    "ure TemperatureDifference = use the value from Zone Heating Design Supply Air Te" +
    "mperature Difference")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_PTHP_ZoneHeatingDesignSupplyAirTemperatureInputMethod ZoneHeatingDesignSupplyAirTemperatureInputMethod { get; set; } = (HVACTemplate_Zone_PTHP_ZoneHeatingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(HVACTemplate_Zone_PTHP_ZoneHeatingDesignSupplyAirTemperatureInputMethod), "SupplyAirTemperature");
        

[Description("Zone Heating Design Supply Air Temperature is only used when Zone Heating Design " +
    "Supply Air Temperature Input Method = SupplyAirTemperature")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirTemperature { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[Description(@"Zone Heating Design Supply Air Temperature is only used when Zone Heating Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be added to the zone temperature at peak load to calculate the Zone Heating Design Supply Air Temperature.")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirTemperatureDifference { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
        

[Description("This field is used only when Outdoor Air Method=DetailedSpecification.")]
[JsonProperty(PropertyName="design_specification_outdoor_air_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationOutdoorAirObjectName { get; set; } = "";
        

[Description("This field is used only when Outdoor Air Method=DetailedSpecification.")]
[JsonProperty(PropertyName="design_specification_zone_air_distribution_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZoneAirDistributionObjectName { get; set; } = "";
        

[JsonProperty(PropertyName="baseboard_heating_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_PTHP_BaseboardHeatingType BaseboardHeatingType { get; set; } = (HVACTemplate_Zone_PTHP_BaseboardHeatingType)Enum.Parse(typeof(HVACTemplate_Zone_PTHP_BaseboardHeatingType), "None");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="baseboard_heating_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BaseboardHeatingAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="baseboard_heating_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> BaseboardHeatingCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="capacity_control_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_PTHP_CapacityControlMethod CapacityControlMethod { get; set; } = (HVACTemplate_Zone_PTHP_CapacityControlMethod)Enum.Parse(typeof(HVACTemplate_Zone_PTHP_CapacityControlMethod), "None");
    }
    
    public enum HVACTemplate_Zone_PTHP_OutdoorAirMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DetailedSpecification")]
        DetailedSpecification = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Area")]
        FlowArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Person")]
        FlowPerson = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Zone")]
        FlowZone = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Maximum")]
        Maximum = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Sum")]
        Sum = 6,
    }
    
    public enum HVACTemplate_Zone_PTHP_SupplyFanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum HVACTemplate_Zone_PTHP_CoolingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SingleSpeedDX")]
        SingleSpeedDX = 1,
    }
    
    public enum HVACTemplate_Zone_PTHP_HeatPumpHeatingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SingleSpeedDXHeatPump")]
        SingleSpeedDXHeatPump = 1,
    }
    
    public enum HVACTemplate_Zone_PTHP_HeatPumpDefrostStrategy
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Resistive")]
        Resistive = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ReverseCycle")]
        ReverseCycle = 2,
    }
    
    public enum HVACTemplate_Zone_PTHP_HeatPumpDefrostControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="OnDemand")]
        OnDemand = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Timed")]
        Timed = 2,
    }
    
    public enum HVACTemplate_Zone_PTHP_SupplementalHeatingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Gas")]
        Gas = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 3,
    }
    
    public enum HVACTemplate_Zone_PTHP_ZoneCoolingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 2,
    }
    
    public enum HVACTemplate_Zone_PTHP_ZoneHeatingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 2,
    }
    
    public enum HVACTemplate_Zone_PTHP_BaseboardHeatingType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    public enum HVACTemplate_Zone_PTHP_CapacityControlMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SingleZoneVAV")]
        SingleZoneVAV = 2,
    }
    
    [Description("Water to Air Heat Pump to be used with HVACTemplate:Plant:MixedWaterLoop")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_Zone_WaterToAirHeatPump
    {
        

[Description("Zone name must match a building zone name")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Enter the name of a HVACTemplate:Thermostat object. If blank, then it is assumed " +
    "that standard thermostat objects have been defined for this zone.")]
[JsonProperty(PropertyName="template_thermostat_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TemplateThermostatName { get; set; } = "";
        

[Description("Supply air flow rate during cooling operation This field may be set to \"autosize\"" +
    ". If a value is entered, it will be multiplied by the Supply Air Sizing Factor a" +
    "nd by zone multipliers.")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Supply air flow rate during heating operation This field may be set to \"autosize\"" +
    ". If a value is entered, it will be multiplied by the Supply Air Sizing Factor a" +
    "nd by zone multipliers.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Supply air flow rate when no cooling or heating is needed Only used when heat pump fan operating mode is continuous. This air flow rate is used when no heating or cooling is required. If this field is left blank or zero, the supply air flow rate from the previous on cycle (either cooling or heating) is used. A value entered in this field will *not* be multiplied by the sizing factor or by zone multipliers. It is best to autosize or leave blank when using zone multipliers.")]
[JsonProperty(PropertyName="no_load_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoLoadSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("If blank, value from Sizing:Parameters will be used.")]
[JsonProperty(PropertyName="zone_heating_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingSizingFactor { get; set; } = null;
        

[Description("If blank, value from Sizing:Parameters will be used.")]
[JsonProperty(PropertyName="zone_cooling_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingSizingFactor { get; set; } = null;
        

[Description(@"Flow/Person, Flow/Zone, Flow/Area, Sum, and Maximum use the values in the next three fields: Outdoor Air Flow Rate per Person, Outdoor Air Flow Rate per Zone Floor Area, and Outdoor Air Flow Rate per Zone. DetailedSpecification ignores these three Outdoor Air Flow Rate fields and instead references design specification objects named in the fields Design Specification Outdoor Air Object Name and Design Specification Zone Air Distribution Object Name.")]
[JsonProperty(PropertyName="outdoor_air_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_WaterToAirHeatPump_OutdoorAirMethod OutdoorAirMethod { get; set; } = (HVACTemplate_Zone_WaterToAirHeatPump_OutdoorAirMethod)Enum.Parse(typeof(HVACTemplate_Zone_WaterToAirHeatPump_OutdoorAirMethod), "Empty");
        

[Description("Default 0.00944 is 20 cfm per person This input is used if the field Outdoor Air " +
    "Method is Flow/Person, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerPerson { get; set; } = Double.Parse("0.00944", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Area, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZoneFloorArea { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Zone, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZone { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="system_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SystemAvailabilityScheduleName { get; set; } = "";
        

[Description("Refers to a schedule to specify unitary supply fan operating mode. Schedule value" +
    "s of 0 indicate cycling fan (auto) Schedule values of 1 indicate continuous fan " +
    "(on) If this field is left blank, a schedule of always zero (cycling fan) will b" +
    "e used.")]
[JsonProperty(PropertyName="supply_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyFanOperatingModeScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="supply_fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_WaterToAirHeatPump_SupplyFanPlacement SupplyFanPlacement { get; set; } = (HVACTemplate_Zone_WaterToAirHeatPump_SupplyFanPlacement)Enum.Parse(typeof(HVACTemplate_Zone_WaterToAirHeatPump_SupplyFanPlacement), "DrawThrough");
        

[JsonProperty(PropertyName="supply_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanDeltaPressure { get; set; } = Double.Parse("75", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanMotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cooling_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_WaterToAirHeatPump_CoolingCoilType CoolingCoilType { get; set; } = (HVACTemplate_Zone_WaterToAirHeatPump_CoolingCoilType)Enum.Parse(typeof(HVACTemplate_Zone_WaterToAirHeatPump_CoolingCoilType), "Empty");
        

[Description("Total cooling capacity not accounting for the effect of supply air fan heat")]
[JsonProperty(PropertyName="cooling_coil_gross_rated_total_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingCoilGrossRatedTotalCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Rated sensible heat ratio (gross sensible capacity/gross total capacity) Sensible" +
    " and total capacities do not include effect of supply fan heat")]
[JsonProperty(PropertyName="cooling_coil_gross_rated_sensible_heat_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingCoilGrossRatedSensibleHeatRatio { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Gross cooling capacity divided by power input to the compressor and outdoor fan, " +
    "does not include supply fan heat or supply fan electric power input")]
[JsonProperty(PropertyName="cooling_coil_gross_rated_cop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilGrossRatedCop { get; set; } = Double.Parse("3.5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heat_pump_heating_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_WaterToAirHeatPump_HeatPumpHeatingCoilType HeatPumpHeatingCoilType { get; set; } = (HVACTemplate_Zone_WaterToAirHeatPump_HeatPumpHeatingCoilType)Enum.Parse(typeof(HVACTemplate_Zone_WaterToAirHeatPump_HeatPumpHeatingCoilType), "Empty");
        

[Description("Capacity excluding supply air fan heat")]
[JsonProperty(PropertyName="heat_pump_heating_coil_gross_rated_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatPumpHeatingCoilGrossRatedCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Heat Pump Heating Coil Rated Capacity divided by power input to the compressor an" +
    "d outdoor fan, does not include supply air fan heat or supply air fan electric p" +
    "ower input")]
[JsonProperty(PropertyName="heat_pump_heating_coil_gross_rated_cop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatPumpHeatingCoilGrossRatedCop { get; set; } = Double.Parse("4.2", CultureInfo.InvariantCulture);
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="supplemental_heating_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplementalHeatingCoilAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="supplemental_heating_coil_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SupplementalHeatingCoilCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("The maximum on-off cycling rate for the compressor Suggested value is 2.5 for a t" +
    "ypical heat pump")]
[JsonProperty(PropertyName="maximum_cycling_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCyclingRate { get; set; } = Double.Parse("2.5", CultureInfo.InvariantCulture);
        

[Description("Time constant for the cooling coil\'s capacity to reach steady state after startup" +
    " Suggested value is 60 for a typical heat pump")]
[JsonProperty(PropertyName="heat_pump_time_constant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatPumpTimeConstant { get; set; } = Double.Parse("60", CultureInfo.InvariantCulture);
        

[Description("The fraction of on-cycle power use to adjust the part load fraction based on the " +
    "off-cycle power consumption due to crankcase heaters, controls, fans, and etc. S" +
    "uggested value is 0.01 for a typical heat pump")]
[JsonProperty(PropertyName="fraction_of_on_cycle_power_use", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfOnCyclePowerUse { get; set; } = Double.Parse("0.01", CultureInfo.InvariantCulture);
        

[Description("Programmed time delay for heat pump fan to shut off after compressor cycle off. O" +
    "nly required when fan operating mode is cycling Enter 0 when fan operating mode " +
    "is continuous")]
[JsonProperty(PropertyName="heat_pump_fan_delay_time", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatPumpFanDelayTime { get; set; } = Double.Parse("60", CultureInfo.InvariantCulture);
        

[Description("Enter the name of an HVACTemplate:System:DedicatedOutdoorAir object if this zone " +
    "is served by a separate dedicated outdoor air system (DOAS). Leave field blank i" +
    "f no DOAS serves this zone.")]
[JsonProperty(PropertyName="dedicated_outdoor_air_system_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DedicatedOutdoorAirSystemName { get; set; } = "";
        

[JsonProperty(PropertyName="supplemental_heating_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_WaterToAirHeatPump_SupplementalHeatingCoilType SupplementalHeatingCoilType { get; set; } = (HVACTemplate_Zone_WaterToAirHeatPump_SupplementalHeatingCoilType)Enum.Parse(typeof(HVACTemplate_Zone_WaterToAirHeatPump_SupplementalHeatingCoilType), "Electric");
        

[Description("SupplyAirTemperature = use the value from Zone Cooling Design Supply Air Temperat" +
    "ure TemperatureDifference = use the value from Zone Cooling Design Supply Air Te" +
    "mperature Difference")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_WaterToAirHeatPump_ZoneCoolingDesignSupplyAirTemperatureInputMethod ZoneCoolingDesignSupplyAirTemperatureInputMethod { get; set; } = (HVACTemplate_Zone_WaterToAirHeatPump_ZoneCoolingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(HVACTemplate_Zone_WaterToAirHeatPump_ZoneCoolingDesignSupplyAirTemperatureInputMethod), "SupplyAirTemperature");
        

[Description("Zone Cooling Design Supply Air Temperature is only used when Zone Cooling Design " +
    "Supply Air Temperature Input Method = SupplyAirTemperature")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirTemperature { get; set; } = Double.Parse("14", CultureInfo.InvariantCulture);
        

[Description(@"Zone Cooling Design Supply Air Temperature is only used when Zone Cooling Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be subtracted from the zone temperature at peak load to calculate the Zone Cooling Design Supply Air Temperature.")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirTemperatureDifference { get; set; } = Double.Parse("11.11", CultureInfo.InvariantCulture);
        

[Description("SupplyAirTemperature = use the value from Zone Heating Design Supply Air Temperat" +
    "ure TemperatureDifference = use the value from Zone Heating Design Supply Air Te" +
    "mperature Difference")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_WaterToAirHeatPump_ZoneHeatingDesignSupplyAirTemperatureInputMethod ZoneHeatingDesignSupplyAirTemperatureInputMethod { get; set; } = (HVACTemplate_Zone_WaterToAirHeatPump_ZoneHeatingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(HVACTemplate_Zone_WaterToAirHeatPump_ZoneHeatingDesignSupplyAirTemperatureInputMethod), "SupplyAirTemperature");
        

[Description("Zone Heating Design Supply Air Temperature is only used when Zone Heating Design " +
    "Supply Air Temperature Input Method = SupplyAirTemperature")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirTemperature { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[Description(@"Zone Heating Design Supply Air Temperature is only used when Zone Heating Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be added to the zone temperature at peak load to calculate the Zone Heating Design Supply Air Temperature.")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirTemperatureDifference { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
        

[Description(@"used only when the heat pump coils are of the type WaterToAirHeatPump:EquationFit Constant results in 100% water flow regardless of compressor PLR Cycling results in water flow that matches compressor PLR ConstantOnDemand results in 100% water flow whenever the coil is on, but is 0% whenever the coil has no load")]
[JsonProperty(PropertyName="heat_pump_coil_water_flow_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_WaterToAirHeatPump_HeatPumpCoilWaterFlowMode HeatPumpCoilWaterFlowMode { get; set; } = (HVACTemplate_Zone_WaterToAirHeatPump_HeatPumpCoilWaterFlowMode)Enum.Parse(typeof(HVACTemplate_Zone_WaterToAirHeatPump_HeatPumpCoilWaterFlowMode), "Cycling");
        

[Description("This field is used only when Outdoor Air Method=DetailedSpecification.")]
[JsonProperty(PropertyName="design_specification_outdoor_air_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationOutdoorAirObjectName { get; set; } = "";
        

[Description("This field is used only when Outdoor Air Method=DetailedSpecification.")]
[JsonProperty(PropertyName="design_specification_zone_air_distribution_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZoneAirDistributionObjectName { get; set; } = "";
        

[JsonProperty(PropertyName="baseboard_heating_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_WaterToAirHeatPump_BaseboardHeatingType BaseboardHeatingType { get; set; } = (HVACTemplate_Zone_WaterToAirHeatPump_BaseboardHeatingType)Enum.Parse(typeof(HVACTemplate_Zone_WaterToAirHeatPump_BaseboardHeatingType), "None");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="baseboard_heating_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BaseboardHeatingAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="baseboard_heating_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> BaseboardHeatingCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
    }
    
    public enum HVACTemplate_Zone_WaterToAirHeatPump_OutdoorAirMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DetailedSpecification")]
        DetailedSpecification = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Area")]
        FlowArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Person")]
        FlowPerson = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Zone")]
        FlowZone = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Maximum")]
        Maximum = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Sum")]
        Sum = 6,
    }
    
    public enum HVACTemplate_Zone_WaterToAirHeatPump_SupplyFanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum HVACTemplate_Zone_WaterToAirHeatPump_CoolingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:WaterToAirHeatPump:EquationFit")]
        CoilCoolingWaterToAirHeatPumpEquationFit = 1,
    }
    
    public enum HVACTemplate_Zone_WaterToAirHeatPump_HeatPumpHeatingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:WaterToAirHeatPump:EquationFit")]
        CoilHeatingWaterToAirHeatPumpEquationFit = 1,
    }
    
    public enum HVACTemplate_Zone_WaterToAirHeatPump_SupplementalHeatingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 2,
    }
    
    public enum HVACTemplate_Zone_WaterToAirHeatPump_ZoneCoolingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 2,
    }
    
    public enum HVACTemplate_Zone_WaterToAirHeatPump_ZoneHeatingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 2,
    }
    
    public enum HVACTemplate_Zone_WaterToAirHeatPump_HeatPumpCoilWaterFlowMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Constant")]
        Constant = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ConstantOnDemand")]
        ConstantOnDemand = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Cycling")]
        Cycling = 3,
    }
    
    public enum HVACTemplate_Zone_WaterToAirHeatPump_BaseboardHeatingType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    [Description("Zone terminal unit with variable refrigerant flow (VRF) DX cooling and heating co" +
        "ils (air-to-air or water-to-air heat pump). The VRF terminal units are served by" +
        " an HVACTemplate:System:VRF system.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_Zone_VRF
    {
        

[Description("Zone name must match a building zone name")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Name of a HVACTemplate:System:VRF object serving this zone")]
[JsonProperty(PropertyName="template_vrf_system_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TemplateVrfSystemName { get; set; } = "";
        

[Description("Enter the name of a HVACTemplate:Thermostat object. If blank, then it is assumed " +
    "that standard thermostat objects have been defined for this zone.")]
[JsonProperty(PropertyName="template_thermostat_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TemplateThermostatName { get; set; } = "";
        

[Description("If blank, value from Sizing:Parameters will be used.")]
[JsonProperty(PropertyName="zone_heating_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingSizingFactor { get; set; } = null;
        

[Description("If blank, value from Sizing:Parameters will be used.")]
[JsonProperty(PropertyName="zone_cooling_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingSizingFactor { get; set; } = null;
        

[Description(@"If this terminal unit's heating coil is autosized, the heating capacity is sized to be equal to the cooling capacity multiplied by this sizing ratio. This input applies to the terminal unit heating coil and overrides the sizing ratio entered in the HVACTemplate:System:VRF object.")]
[JsonProperty(PropertyName="rated_total_heating_capacity_sizing_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedTotalHeatingCapacitySizingRatio { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("This field may be set to \"autosize\". If a value is entered, it will be multiplied" +
    " by the Supply Air Sizing Factor and by zone multipliers.")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This flow rate is used when the terminal is not cooling and the previous mode was" +
    " cooling. This field may be set to \"autosize\". If a value is entered, it will be" +
    " multiplied by the Supply Air Sizing Factor and by zone multipliers.")]
[JsonProperty(PropertyName="no_cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoCoolingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field may be set to \"autosize\". If a value is entered, it will be multiplied" +
    " by the Supply Air Sizing Factor and by zone multipliers.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This flow rate is used when the terminal is not heating and the previous mode was" +
    " heating. This field may be set to \"autosize\". If a value is entered, it will be" +
    " multiplied by the Supply Air Sizing Factor and by zone multipliers.")]
[JsonProperty(PropertyName="no_heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoHeatingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("If this field is set to autosize it will be sized based on the outdoor air inputs" +
    " below, unless a dedicated outdoor air system is specified for this zone and the" +
    "n it will be set to zero.")]
[JsonProperty(PropertyName="cooling_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("If this field is set to autosize it will be sized based on the outdoor air inputs" +
    " below, unless a dedicated outdoor air system is specified for this zone and the" +
    "n it will be set to zero.")]
[JsonProperty(PropertyName="heating_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("If this field is set to autosize it will be sized based on the outdoor air inputs" +
    " below, unless a dedicated outdoor air system is specified for this zone and the" +
    "n it will be set to zero.")]
[JsonProperty(PropertyName="no_load_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoLoadOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Flow/Person, Flow/Zone, Flow/Area, Sum, and Maximum use the values in the next three fields: Outdoor Air Flow Rate per Person, Outdoor Air Flow Rate per Zone Floor Area, and Outdoor Air Flow Rate per Zone. DetailedSpecification ignores these three Outdoor Air Flow Rate fields and instead references design specification objects named in the fields Design Specification Outdoor Air Object Name and Design Specification Zone Air Distribution Object Name.")]
[JsonProperty(PropertyName="outdoor_air_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VRF_OutdoorAirMethod OutdoorAirMethod { get; set; } = (HVACTemplate_Zone_VRF_OutdoorAirMethod)Enum.Parse(typeof(HVACTemplate_Zone_VRF_OutdoorAirMethod), "Empty");
        

[Description("Default 0.00944 is 20 cfm per person This input is used if the field Outdoor Air " +
    "Method is Flow/Person, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerPerson { get; set; } = Double.Parse("0.00944", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Area, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZoneFloorArea { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Zone, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZone { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This field is used only when Outdoor Air Method=DetailedSpecification.")]
[JsonProperty(PropertyName="design_specification_outdoor_air_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationOutdoorAirObjectName { get; set; } = "";
        

[Description("This field is used only when Outdoor Air Method=DetailedSpecification.")]
[JsonProperty(PropertyName="design_specification_zone_air_distribution_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZoneAirDistributionObjectName { get; set; } = "";
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="system_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SystemAvailabilityScheduleName { get; set; } = "";
        

[Description("Refers to a schedule to specify unitary supply fan operating mode. Schedule value" +
    "s of 0 indicate cycling fan (auto) Schedule values of 1 indicate continuous fan " +
    "(on) If this field is left blank, a schedule of always zero (cycling fan) will b" +
    "e used.")]
[JsonProperty(PropertyName="supply_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyFanOperatingModeScheduleName { get; set; } = "";
        

[Description("Select fan placement as either blow through or draw through.")]
[JsonProperty(PropertyName="supply_air_fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VRF_SupplyAirFanPlacement SupplyAirFanPlacement { get; set; } = (HVACTemplate_Zone_VRF_SupplyAirFanPlacement)Enum.Parse(typeof(HVACTemplate_Zone_VRF_SupplyAirFanPlacement), "BlowThrough");
        

[JsonProperty(PropertyName="supply_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanDeltaPressure { get; set; } = Double.Parse("75", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanMotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cooling_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VRF_CoolingCoilType CoolingCoilType { get; set; } = (HVACTemplate_Zone_VRF_CoolingCoilType)Enum.Parse(typeof(HVACTemplate_Zone_VRF_CoolingCoilType), "VariableRefrigerantFlowDX");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="cooling_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilAvailabilityScheduleName { get; set; } = "";
        

[Description("Total cooling capacity not accounting for the effect of supply air fan heat Ratin" +
    "g point: air entering the cooling coil at 26.7 C dry-bulb/19.4 C wet-bulb, and a" +
    "ir entering the outdoor condenser coil at 35 C dry-bulb/23.9 C wet-bulb")]
[JsonProperty(PropertyName="cooling_coil_gross_rated_total_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingCoilGrossRatedTotalCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Rated sensible heat ratio (gross sensible capacity/gross total capacity) Sensible" +
    " and total capacities do not include effect of supply fan heat")]
[JsonProperty(PropertyName="cooling_coil_gross_rated_sensible_heat_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingCoilGrossRatedSensibleHeatRatio { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heat_pump_heating_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VRF_HeatPumpHeatingCoilType HeatPumpHeatingCoilType { get; set; } = (HVACTemplate_Zone_VRF_HeatPumpHeatingCoilType)Enum.Parse(typeof(HVACTemplate_Zone_VRF_HeatPumpHeatingCoilType), "VariableRefrigerantFlowDX");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="heat_pump_heating_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatPumpHeatingCoilAvailabilityScheduleName { get; set; } = "";
        

[Description("Capacity excluding supply air fan heat Rating point outdoor dry-bulb temp 8.33 C," +
    " outdoor wet-bulb temp 6.11 C Rating point heating coil entering air dry-bulb 21" +
    ".11 C, coil entering wet-bulb 15.55 C")]
[JsonProperty(PropertyName="heat_pump_heating_coil_gross_rated_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatPumpHeatingCoilGrossRatedCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="zone_terminal_unit_on_parasitic_electric_energy_use", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneTerminalUnitOnParasiticElectricEnergyUse { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="zone_terminal_unit_off_parasitic_electric_energy_use", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneTerminalUnitOffParasiticElectricEnergyUse { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Enter the name of an HVACTemplate:System:DedicatedOutdoorAir object if this zone " +
    "is served by a separate dedicated outdoor air system (DOAS). Leave field blank i" +
    "f no DOAS serves this zone.")]
[JsonProperty(PropertyName="dedicated_outdoor_air_system_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DedicatedOutdoorAirSystemName { get; set; } = "";
        

[Description("SupplyAirTemperature = use the value from Zone Cooling Design Supply Air Temperat" +
    "ure TemperatureDifference = use the value from Zone Cooling Design Supply Air Te" +
    "mperature Difference")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VRF_ZoneCoolingDesignSupplyAirTemperatureInputMethod ZoneCoolingDesignSupplyAirTemperatureInputMethod { get; set; } = (HVACTemplate_Zone_VRF_ZoneCoolingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(HVACTemplate_Zone_VRF_ZoneCoolingDesignSupplyAirTemperatureInputMethod), "SupplyAirTemperature");
        

[Description("Zone Cooling Design Supply Air Temperature is only used when Zone Cooling Design " +
    "Supply Air Temperature Input Method = SupplyAirTemperature")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirTemperature { get; set; } = Double.Parse("14", CultureInfo.InvariantCulture);
        

[Description(@"Zone Cooling Design Supply Air Temperature is only used when Zone Cooling Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be subtracted from the zone temperature at peak load to calculate the Zone Cooling Design Supply Air Temperature.")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirTemperatureDifference { get; set; } = Double.Parse("11.11", CultureInfo.InvariantCulture);
        

[Description("SupplyAirTemperature = use the value from Zone Heating Design Supply Air Temperat" +
    "ure TemperatureDifference = use the value from Zone Heating Design Supply Air Te" +
    "mperature Difference")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VRF_ZoneHeatingDesignSupplyAirTemperatureInputMethod ZoneHeatingDesignSupplyAirTemperatureInputMethod { get; set; } = (HVACTemplate_Zone_VRF_ZoneHeatingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(HVACTemplate_Zone_VRF_ZoneHeatingDesignSupplyAirTemperatureInputMethod), "SupplyAirTemperature");
        

[Description("Zone Heating Design Supply Air Temperature is only used when Zone Heating Design " +
    "Supply Air Temperature Input Method = SupplyAirTemperature")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirTemperature { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[Description(@"Zone Heating Design Supply Air Temperature is only used when Zone Heating Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be added to the zone temperature at peak load to calculate the Zone Heating Design Supply Air Temperature.")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirTemperatureDifference { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="baseboard_heating_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VRF_BaseboardHeatingType BaseboardHeatingType { get; set; } = (HVACTemplate_Zone_VRF_BaseboardHeatingType)Enum.Parse(typeof(HVACTemplate_Zone_VRF_BaseboardHeatingType), "None");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="baseboard_heating_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BaseboardHeatingAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="baseboard_heating_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> BaseboardHeatingCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
    }
    
    public enum HVACTemplate_Zone_VRF_OutdoorAirMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DetailedSpecification")]
        DetailedSpecification = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Area")]
        FlowArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Person")]
        FlowPerson = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Zone")]
        FlowZone = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Maximum")]
        Maximum = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Sum")]
        Sum = 6,
    }
    
    public enum HVACTemplate_Zone_VRF_SupplyAirFanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum HVACTemplate_Zone_VRF_CoolingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableRefrigerantFlowDX")]
        VariableRefrigerantFlowDX = 2,
    }
    
    public enum HVACTemplate_Zone_VRF_HeatPumpHeatingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableRefrigerantFlowDX")]
        VariableRefrigerantFlowDX = 2,
    }
    
    public enum HVACTemplate_Zone_VRF_ZoneCoolingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 2,
    }
    
    public enum HVACTemplate_Zone_VRF_ZoneHeatingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 2,
    }
    
    public enum HVACTemplate_Zone_VRF_BaseboardHeatingType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    [Description("Zone terminal unit, constant volume, no controls.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_Zone_Unitary
    {
        

[Description("Zone name must match a building zone name")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Enter the name of an HVACTemplate:System:Unitary, HVACTemplate:System:UnitaryHeat" +
    "Pump:AirTtoAir, or HVACTemplate:System:UnitarySystem object serving this zone.")]
[JsonProperty(PropertyName="template_unitary_system_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TemplateUnitarySystemName { get; set; } = "";
        

[Description("Enter the name of a HVACTemplate:Thermostat object. If blank, then it is assumed " +
    "that standard thermostat objects have been defined for this zone.")]
[JsonProperty(PropertyName="template_thermostat_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TemplateThermostatName { get; set; } = "";
        

[Description("This field may be set to \"autosize\". If a value is entered, it will be multiplied" +
    " by the Supply Air Sizing Factor and by zone multipliers.")]
[JsonProperty(PropertyName="supply_air_maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SupplyAirMaximumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("If blank, value from Sizing:Parameters will be used.")]
[JsonProperty(PropertyName="zone_heating_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingSizingFactor { get; set; } = null;
        

[Description("If blank, value from Sizing:Parameters will be used.")]
[JsonProperty(PropertyName="zone_cooling_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingSizingFactor { get; set; } = null;
        

[Description(@"Flow/Person, Flow/Zone, Flow/Area, Sum, and Maximum use the values in the next three fields: Outdoor Air Flow Rate per Person, Outdoor Air Flow Rate per Zone Floor Area, and Outdoor Air Flow Rate per Zone. DetailedSpecification ignores these three Outdoor Air Flow Rate fields and instead references design specification objects named in the fields Design Specification Outdoor Air Object Name and Design Specification Zone Air Distribution Object Name.")]
[JsonProperty(PropertyName="outdoor_air_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_Unitary_OutdoorAirMethod OutdoorAirMethod { get; set; } = (HVACTemplate_Zone_Unitary_OutdoorAirMethod)Enum.Parse(typeof(HVACTemplate_Zone_Unitary_OutdoorAirMethod), "Empty");
        

[Description("Default 0.00944 is 20 cfm per person This input is used if the field Outdoor Air " +
    "Method is Flow/Person, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerPerson { get; set; } = Double.Parse("0.00944", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Area, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZoneFloorArea { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Zone, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZone { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Plenum zone name. Supply plenum runs through only this zone. Blank if none.")]
[JsonProperty(PropertyName="supply_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyPlenumName { get; set; } = "";
        

[Description("Plenum zone name. Return plenum runs through only this zone. Blank if none.")]
[JsonProperty(PropertyName="return_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReturnPlenumName { get; set; } = "";
        

[JsonProperty(PropertyName="baseboard_heating_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_Unitary_BaseboardHeatingType BaseboardHeatingType { get; set; } = (HVACTemplate_Zone_Unitary_BaseboardHeatingType)Enum.Parse(typeof(HVACTemplate_Zone_Unitary_BaseboardHeatingType), "None");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="baseboard_heating_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BaseboardHeatingAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="baseboard_heating_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> BaseboardHeatingCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"SupplyAirTemperature = use the value from Zone Cooling Design Supply Air Temperature TemperatureDifference = use the value from Zone Cooling Design Supply Air Temperature Difference SystemSupplyAirTemperature = use the value from HVACTemplate:System:Unitary or HVACTemplate:System:UnitaryHeatPump:AirToAir Cooling Design Supply Air Temperature")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_Unitary_ZoneCoolingDesignSupplyAirTemperatureInputMethod ZoneCoolingDesignSupplyAirTemperatureInputMethod { get; set; } = (HVACTemplate_Zone_Unitary_ZoneCoolingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(HVACTemplate_Zone_Unitary_ZoneCoolingDesignSupplyAirTemperatureInputMethod), "SystemSupplyAirTemperature");
        

[Description("Zone Cooling Design Supply Air Temperature is only used when Zone Cooling Design " +
    "Supply Air Temperature Input Method = SupplyAirTemperature")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirTemperature { get; set; } = Double.Parse("12.8", CultureInfo.InvariantCulture);
        

[Description(@"Zone Cooling Design Supply Air Temperature is only used when Zone Cooling Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be subtracted from the zone temperature at peak load to calculate the Zone Cooling Design Supply Air Temperature.")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirTemperatureDifference { get; set; } = Double.Parse("11.11", CultureInfo.InvariantCulture);
        

[Description(@"SupplyAirTemperature = use the value from Zone Heating Design Supply Air Temperature TemperatureDifference = use the value from Zone Heating Design Supply Air Temperature Difference SystemSupplyAirTemperature = use the value from HVACTemplate:System:Unitary or HVACTemplate:System:UnitaryHeatPump:AirToAir Heating Design Supply Air Temperature")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_Unitary_ZoneHeatingDesignSupplyAirTemperatureInputMethod ZoneHeatingDesignSupplyAirTemperatureInputMethod { get; set; } = (HVACTemplate_Zone_Unitary_ZoneHeatingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(HVACTemplate_Zone_Unitary_ZoneHeatingDesignSupplyAirTemperatureInputMethod), "SystemSupplyAirTemperature");
        

[Description("Zone Heating Design Supply Air Temperature is only used when Zone Heating Design " +
    "Supply Air Temperature Input Method = SupplyAirTemperature")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirTemperature { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[Description(@"Zone Heating Design Supply Air Temperature is only used when Zone Heating Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be added to the zone temperature at peak load to calculate the Zone Heating Design Supply Air Temperature.")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirTemperatureDifference { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
        

[Description("This field is used only when Outdoor Air Method=DetailedSpecification.")]
[JsonProperty(PropertyName="design_specification_outdoor_air_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationOutdoorAirObjectName { get; set; } = "";
        

[Description("This field is used only when Outdoor Air Method=DetailedSpecification.")]
[JsonProperty(PropertyName="design_specification_zone_air_distribution_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZoneAirDistributionObjectName { get; set; } = "";
    }
    
    public enum HVACTemplate_Zone_Unitary_OutdoorAirMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DetailedSpecification")]
        DetailedSpecification = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Area")]
        FlowArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Person")]
        FlowPerson = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Zone")]
        FlowZone = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Maximum")]
        Maximum = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Sum")]
        Sum = 6,
    }
    
    public enum HVACTemplate_Zone_Unitary_BaseboardHeatingType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    public enum HVACTemplate_Zone_Unitary_ZoneCoolingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SystemSupplyAirTemperature")]
        SystemSupplyAirTemperature = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 3,
    }
    
    public enum HVACTemplate_Zone_Unitary_ZoneHeatingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SystemSupplyAirTemperature")]
        SystemSupplyAirTemperature = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 3,
    }
    
    [Description("Zone terminal unit, variable volume, reheat optional. For heating, this unit acti" +
        "vates reheat coil first, then increases airflow (if reverse action specified).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_Zone_VAV
    {
        

[Description("Zone name must match a building zone name")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Name of a HVACTemplate:System:VAV or HVACTemplate:System:PackagedVAV object servi" +
    "ng this zone")]
[JsonProperty(PropertyName="template_vav_system_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TemplateVavSystemName { get; set; } = "";
        

[Description("Enter the name of a HVACTemplate:Thermostat object. If blank, then it is assumed " +
    "that standard thermostat objects have been defined for this zone.")]
[JsonProperty(PropertyName="template_thermostat_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TemplateThermostatName { get; set; } = "";
        

[Description("This field may be set to \"autosize\". If a value is entered, it will be multiplied" +
    " by the Supply Air Sizing Factor and by zone multipliers.")]
[JsonProperty(PropertyName="supply_air_maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SupplyAirMaximumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("If blank, value from Sizing:Parameters will be used.")]
[JsonProperty(PropertyName="zone_heating_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingSizingFactor { get; set; } = null;
        

[Description("If blank, value from Sizing:Parameters will be used.")]
[JsonProperty(PropertyName="zone_cooling_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingSizingFactor { get; set; } = null;
        

[Description("Constant = Constant Minimum Air Flow Fraction (a fraction of Maximum Air Flow Rat" +
    "e) FixedFlowRate = Fixed Minimum Air Flow Rate (a fixed minimum air volume flow " +
    "rate) Scheduled = Scheduled Minimum Air Flow Fraction (a fraction of Maximum Air" +
    " Flow")]
[JsonProperty(PropertyName="zone_minimum_air_flow_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VAV_ZoneMinimumAirFlowInputMethod ZoneMinimumAirFlowInputMethod { get; set; } = (HVACTemplate_Zone_VAV_ZoneMinimumAirFlowInputMethod)Enum.Parse(typeof(HVACTemplate_Zone_VAV_ZoneMinimumAirFlowInputMethod), "Constant");
        

[Description(@"This field is used if the field Zone Minimum Air Flow Input Method is Constant If the field Zone Minimum Air Flow Input Method is Scheduled, then this field is optional. If a value is entered, then it is used for sizing normal-action reheat coils. If both this field and the following field are entered, the larger result is used.")]
[JsonProperty(PropertyName="constant_minimum_air_flow_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConstantMinimumAirFlowFraction { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[Description(@"This field is used if the field Zone Minimum Air Flow Input Method is FixedFlowRate. If the field Zone Minimum Air Flow Input Method is Scheduled, then this field is optional. If a value is entered, then it is used for sizing normal-action reheat coils. If both this field and the previous field are entered, the larger result is used.")]
[JsonProperty(PropertyName="fixed_minimum_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FixedMinimumAirFlowRate { get; set; } = null;
        

[Description(@"This field is used if the field Zone Minimum Air Flow Input Method is Scheduled Schedule values are fractions, 0.0 to 1.0. If the field Constant Minimum Air Flow Fraction is blank, then the average of the minimum and maximum schedule values is used for sizing normal-action reheat coils.")]
[JsonProperty(PropertyName="minimum_air_flow_fraction_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumAirFlowFractionScheduleName { get; set; } = "";
        

[Description(@"Flow/Person, Flow/Zone, Flow/Area, Sum, and Maximum use the values in the next three fields: Outdoor Air Flow Rate per Person, Outdoor Air Flow Rate per Zone Floor Area, and Outdoor Air Flow Rate per Zone. DetailedSpecification ignores these three Outdoor Air Flow Rate fields and instead references design specification objects named in the fields Design Specification Outdoor Air Object Name and Design Specification Zone Air Distribution Object Name.")]
[JsonProperty(PropertyName="outdoor_air_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VAV_OutdoorAirMethod OutdoorAirMethod { get; set; } = (HVACTemplate_Zone_VAV_OutdoorAirMethod)Enum.Parse(typeof(HVACTemplate_Zone_VAV_OutdoorAirMethod), "Empty");
        

[Description("Default 0.00944 is 20 cfm per person This input is used if the field Outdoor Air " +
    "Method is Flow/Person, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerPerson { get; set; } = Double.Parse("0.00944", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Area, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZoneFloorArea { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Zone, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZone { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="reheat_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VAV_ReheatCoilType ReheatCoilType { get; set; } = (HVACTemplate_Zone_VAV_ReheatCoilType)Enum.Parse(typeof(HVACTemplate_Zone_VAV_ReheatCoilType), "None");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="reheat_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReheatCoilAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="damper_heating_action", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VAV_DamperHeatingAction DamperHeatingAction { get; set; } = (HVACTemplate_Zone_VAV_DamperHeatingAction)Enum.Parse(typeof(HVACTemplate_Zone_VAV_DamperHeatingAction), "Reverse");
        

[Description(@"Used only when Reheat Coil Object Type = Coil:Heating:Water and Damper Heating Action = Reverse When autocalculating, the maximum flow per zone is set to 0.002032 m3/s-m2 (0.4 cfm/sqft) This optional field limits the maximum flow allowed in reheat mode. If this field and the following field are left blank, the maximum flow will not be limited. At no time will the maximum flow rate calculated here exceed the value of Maximum Air Flow Rate.")]
[JsonProperty(PropertyName="maximum_flow_per_zone_floor_area_during_reheat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> MaximumFlowPerZoneFloorAreaDuringReheat { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Used only when Reheat Coil Object Type = Coil:Heating:Water and Damper Heating Action = Reverse When autocalculating, the maximum flow fraction is set to the ratio of 0.002032 m3/s-m2 (0.4 cfm/sqft) multiplied by the zone floor area and the Maximum Air Flow Rate. This optional field limits the maximum flow allowed in reheat mode. If this field and the previous field are left blank, the maximum flow will not be limited. At no time will the maximum flow rate calculated here exceed the value of Maximum Air Flow Rate.")]
[JsonProperty(PropertyName="maximum_flow_fraction_during_reheat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> MaximumFlowFractionDuringReheat { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Specifies the maximum allowable supply air temperature leaving the reheat coil. I" +
    "f left blank, there is no limit and no default. If unknown, 35C (95F) is recomme" +
    "nded.")]
[JsonProperty(PropertyName="maximum_reheat_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumReheatAirTemperature { get; set; } = null;
        

[Description(@"When the name of a DesignSpecification:OutdoorAir object is entered, the terminal unit will increase flow as needed to meet this outdoor air requirement. If Outdoor Air Flow per Person is non-zero, then the outdoor air requirement will be computed based on the current number of occupants in the zone. At no time will the supply air flow rate exceed the value for Maximum Air Flow Rate. If this field is blank, then the terminal unit will not be controlled for outdoor air flow. Note that this field is used only for specifying the design outdoor air flow rate used for control. The field Design Specification Outdoor Air Object Name for Sizing (see below) is used to specify the design outdoor air flow rate.")]
[JsonProperty(PropertyName="design_specification_outdoor_air_object_name_for_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationOutdoorAirObjectNameForControl { get; set; } = "";
        

[Description("Plenum zone name. Supply plenum runs through only this zone. Blank if none.")]
[JsonProperty(PropertyName="supply_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyPlenumName { get; set; } = "";
        

[Description("Plenum zone name. Return plenum runs through only this zone. Blank if none.")]
[JsonProperty(PropertyName="return_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReturnPlenumName { get; set; } = "";
        

[JsonProperty(PropertyName="baseboard_heating_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VAV_BaseboardHeatingType BaseboardHeatingType { get; set; } = (HVACTemplate_Zone_VAV_BaseboardHeatingType)Enum.Parse(typeof(HVACTemplate_Zone_VAV_BaseboardHeatingType), "None");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="baseboard_heating_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BaseboardHeatingAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="baseboard_heating_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> BaseboardHeatingCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"SupplyAirTemperature = use the value from Zone Cooling Design Supply Air Temperature TemperatureDifference = use the value from Zone Cooling Design Supply Air Temperature Difference SystemSupplyAirTemperature = use the value from HVACTemplate:System:VAV Cooling Coil Design Setpoint")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VAV_ZoneCoolingDesignSupplyAirTemperatureInputMethod ZoneCoolingDesignSupplyAirTemperatureInputMethod { get; set; } = (HVACTemplate_Zone_VAV_ZoneCoolingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(HVACTemplate_Zone_VAV_ZoneCoolingDesignSupplyAirTemperatureInputMethod), "SystemSupplyAirTemperature");
        

[Description("Zone Cooling Design Supply Air Temperature is only used when Zone Cooling Design " +
    "Supply Air Temperature Input Method = SupplyAirTemperature")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirTemperature { get; set; } = Double.Parse("12.8", CultureInfo.InvariantCulture);
        

[Description(@"Zone Cooling Design Supply Air Temperature is only used when Zone Cooling Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be subtracted from the zone temperature at peak load to calculate the Zone Cooling Design Supply Air Temperature.")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirTemperatureDifference { get; set; } = Double.Parse("11.11", CultureInfo.InvariantCulture);
        

[Description("SupplyAirTemperature = use the value from Zone Heating Design Supply Air Temperat" +
    "ure TemperatureDifference = use the value from Zone Heating Design Supply Air Te" +
    "mperature Difference")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VAV_ZoneHeatingDesignSupplyAirTemperatureInputMethod ZoneHeatingDesignSupplyAirTemperatureInputMethod { get; set; } = (HVACTemplate_Zone_VAV_ZoneHeatingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(HVACTemplate_Zone_VAV_ZoneHeatingDesignSupplyAirTemperatureInputMethod), "SupplyAirTemperature");
        

[Description("Zone Heating Design Supply Air Temperature is only used when Zone Heating Design " +
    "Supply Air Temperature Input Method = SupplyAirTemperature")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirTemperature { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[Description(@"Zone Heating Design Supply Air Temperature is only used when Zone Heating Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be added to the zone temperature at peak load to calculate the Zone Heating Design Supply Air Temperature.")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirTemperatureDifference { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
        

[Description(@"This field is used only when Outdoor Air Method=DetailedSpecification. Note that this field is used only for specifying the design outdoor air flow rate used for sizing. The field Design Specification Outdoor Air Object Name for Control (see above) is used to actively control the VAV terminal air flow rate.")]
[JsonProperty(PropertyName="design_specification_outdoor_air_object_name_for_sizing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationOutdoorAirObjectNameForSizing { get; set; } = "";
        

[Description("This field is used only when Outdoor Air Method=DetailedSpecification.")]
[JsonProperty(PropertyName="design_specification_zone_air_distribution_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZoneAirDistributionObjectName { get; set; } = "";
    }
    
    public enum HVACTemplate_Zone_VAV_ZoneMinimumAirFlowInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Constant")]
        Constant = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedFlowRate")]
        FixedFlowRate = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Scheduled")]
        Scheduled = 3,
    }
    
    public enum HVACTemplate_Zone_VAV_OutdoorAirMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DetailedSpecification")]
        DetailedSpecification = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Area")]
        FlowArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Person")]
        FlowPerson = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Zone")]
        FlowZone = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Maximum")]
        Maximum = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Sum")]
        Sum = 6,
    }
    
    public enum HVACTemplate_Zone_VAV_ReheatCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Gas")]
        Gas = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum HVACTemplate_Zone_VAV_DamperHeatingAction
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Normal")]
        Normal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Reverse")]
        Reverse = 2,
    }
    
    public enum HVACTemplate_Zone_VAV_BaseboardHeatingType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    public enum HVACTemplate_Zone_VAV_ZoneCoolingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SystemSupplyAirTemperature")]
        SystemSupplyAirTemperature = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 3,
    }
    
    public enum HVACTemplate_Zone_VAV_ZoneHeatingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 2,
    }
    
    [Description("Zone terminal unit, fan powered variable volume, reheat optional. Referenced sche" +
        "dules must be defined elsewhere in the idf.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_Zone_VAV_FanPowered
    {
        

[Description("Zone Name must match a building zone name")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Enter the name of a HVACTemplate:System:VAV or HVACTemplate:System:PackagedVAV ob" +
    "ject serving this zone.")]
[JsonProperty(PropertyName="template_vav_system_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TemplateVavSystemName { get; set; } = "";
        

[Description("Enter the name of a HVACTemplate:Thermostat object. If blank, then it is assumed " +
    "that standard thermostat objects have been defined for this zone.")]
[JsonProperty(PropertyName="template_thermostat_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TemplateThermostatName { get; set; } = "";
        

[Description("This field may be set to \"autosize\". If a value is entered, it will be multiplied" +
    " by the Supply Air Sizing Factor and by zone multipliers.")]
[JsonProperty(PropertyName="primary_supply_air_maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> PrimarySupplyAirMaximumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("If blank, value from Sizing:Parameters will be used.")]
[JsonProperty(PropertyName="zone_heating_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingSizingFactor { get; set; } = null;
        

[Description("If blank, value from Sizing:Parameters will be used.")]
[JsonProperty(PropertyName="zone_cooling_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingSizingFactor { get; set; } = null;
        

[JsonProperty(PropertyName="primary_supply_air_minimum_flow_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> PrimarySupplyAirMinimumFlowFraction { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field may be set to \"autosize\". If a value is entered, it will be multiplied" +
    " by the Supply Air Sizing Factor and by zone multipliers.")]
[JsonProperty(PropertyName="secondary_supply_air_maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SecondarySupplyAirMaximumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="flow_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VAV_FanPowered_FlowType FlowType { get; set; } = (HVACTemplate_Zone_VAV_FanPowered_FlowType)Enum.Parse(typeof(HVACTemplate_Zone_VAV_FanPowered_FlowType), "Parallel");
        

[Description("The fraction of the primary air flow at which fan turns on Applicable only to Par" +
    "allel Flow Type")]
[JsonProperty(PropertyName="parallel_fan_on_flow_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> ParallelFanOnFlowFraction { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Flow/Person, Flow/Zone, Flow/Area, Sum, and Maximum use the values in the next three fields: Outdoor Air Flow Rate per Person, Outdoor Air Flow Rate per Zone Floor Area, and Outdoor Air Flow Rate per Zone. DetailedSpecification ignores these three Outdoor Air Flow Rate fields and instead references design specification objects named in the fields Design Specification Outdoor Air Object Name and Design Specification Zone Air Distribution Object Name.")]
[JsonProperty(PropertyName="outdoor_air_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VAV_FanPowered_OutdoorAirMethod OutdoorAirMethod { get; set; } = (HVACTemplate_Zone_VAV_FanPowered_OutdoorAirMethod)Enum.Parse(typeof(HVACTemplate_Zone_VAV_FanPowered_OutdoorAirMethod), "Empty");
        

[Description("Default 0.00944 is 20 cfm per person This input is used if the field Outdoor Air " +
    "Method is Flow/Person, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerPerson { get; set; } = Double.Parse("0.00944", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/area, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZoneFloorArea { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Zone, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZone { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="reheat_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VAV_FanPowered_ReheatCoilType ReheatCoilType { get; set; } = (HVACTemplate_Zone_VAV_FanPowered_ReheatCoilType)Enum.Parse(typeof(HVACTemplate_Zone_VAV_FanPowered_ReheatCoilType), "Electric");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="reheat_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReheatCoilAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanDeltaPressure { get; set; } = Double.Parse("1000", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fan_motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanMotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[Description("Plenum zone name. Supply plenum runs through only this zone. Blank if none.")]
[JsonProperty(PropertyName="supply_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyPlenumName { get; set; } = "";
        

[Description("Plenum zone name. Return plenum runs through only this zone. Blank if none.")]
[JsonProperty(PropertyName="return_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReturnPlenumName { get; set; } = "";
        

[JsonProperty(PropertyName="baseboard_heating_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VAV_FanPowered_BaseboardHeatingType BaseboardHeatingType { get; set; } = (HVACTemplate_Zone_VAV_FanPowered_BaseboardHeatingType)Enum.Parse(typeof(HVACTemplate_Zone_VAV_FanPowered_BaseboardHeatingType), "None");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="baseboard_heating_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BaseboardHeatingAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="baseboard_heating_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> BaseboardHeatingCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"SupplyAirTemperature = use the value from Zone Cooling Design Supply Air Temperature TemperatureDifference = use the value from Zone Cooling Design Supply Air Temperature Difference SystemSupplyAirTemperature = use the value from HVACTemplate:System:VAV Cooling Coil Design Setpoint")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VAV_FanPowered_ZoneCoolingDesignSupplyAirTemperatureInputMethod ZoneCoolingDesignSupplyAirTemperatureInputMethod { get; set; } = (HVACTemplate_Zone_VAV_FanPowered_ZoneCoolingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(HVACTemplate_Zone_VAV_FanPowered_ZoneCoolingDesignSupplyAirTemperatureInputMethod), "SystemSupplyAirTemperature");
        

[Description("Zone Cooling Design Supply Air Temperature is only used when Zone Cooling Design " +
    "Supply Air Temperature Input Method = SupplyAirTemperature")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirTemperature { get; set; } = Double.Parse("12.8", CultureInfo.InvariantCulture);
        

[Description(@"Zone Cooling Design Supply Air Temperature is only used when Zone Cooling Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be subtracted from the zone temperature at peak load to calculate the Zone Cooling Design Supply Air Temperature.")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirTemperatureDifference { get; set; } = Double.Parse("11.11", CultureInfo.InvariantCulture);
        

[Description("SupplyAirTemperature = use the value from Zone Heating Design Supply Air Temperat" +
    "ure TemperatureDifference = use the value from Zone Heating Design Supply Air Te" +
    "mperature Difference")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VAV_FanPowered_ZoneHeatingDesignSupplyAirTemperatureInputMethod ZoneHeatingDesignSupplyAirTemperatureInputMethod { get; set; } = (HVACTemplate_Zone_VAV_FanPowered_ZoneHeatingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(HVACTemplate_Zone_VAV_FanPowered_ZoneHeatingDesignSupplyAirTemperatureInputMethod), "SupplyAirTemperature");
        

[Description("Zone Heating Design Supply Air Temperature is only used when Zone Heating Design " +
    "Supply Air Temperature Input Method = SupplyAirTemperature")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirTemperature { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[Description(@"Zone Heating Design Supply Air Temperature is only used when Zone Heating Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be added to the zone temperature at peak load to calculate the Zone Heating Design Supply Air Temperature.")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirTemperatureDifference { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
        

[Description(@"This is the operating schedule for the zone PIU fan. For a parallel PIU, the fan operates only when the primary air flow is below the Parallel Fan On Flow Fraction and the Zone PIU Fan Schedule is on, or it is activated by an availability manager. For a series PIU, the zone fan operates whenever the Zone PIU Fan Schedule is on, or it is activated by an availability manager. If this field is left blank, the System Availability Schedule for the HVACTemplate:System serving this zone will be used.")]
[JsonProperty(PropertyName="zone_piu_fan_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZonePiuFanScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="design_specification_outdoor_air_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationOutdoorAirObjectName { get; set; } = "";
        

[JsonProperty(PropertyName="design_specification_zone_air_distribution_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZoneAirDistributionObjectName { get; set; } = "";
    }
    
    public enum HVACTemplate_Zone_VAV_FanPowered_FlowType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Parallel")]
        Parallel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ParallelFromPlenum")]
        ParallelFromPlenum = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Series")]
        Series = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="SeriesFromPlenum")]
        SeriesFromPlenum = 4,
    }
    
    public enum HVACTemplate_Zone_VAV_FanPowered_OutdoorAirMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DetailedSpecification")]
        DetailedSpecification = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Area")]
        FlowArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Person")]
        FlowPerson = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Zone")]
        FlowZone = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Maximum")]
        Maximum = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Sum")]
        Sum = 6,
    }
    
    public enum HVACTemplate_Zone_VAV_FanPowered_ReheatCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Gas")]
        Gas = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 3,
    }
    
    public enum HVACTemplate_Zone_VAV_FanPowered_BaseboardHeatingType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    public enum HVACTemplate_Zone_VAV_FanPowered_ZoneCoolingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SystemSupplyAirTemperature")]
        SystemSupplyAirTemperature = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 3,
    }
    
    public enum HVACTemplate_Zone_VAV_FanPowered_ZoneHeatingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 2,
    }
    
    [Description("VAV system with VAV for both heating and cooling and optional reheat coil. For he" +
        "ating, this unit increases airflow first, then activates reheat coil.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_Zone_VAV_HeatAndCool
    {
        

[Description("Zone name must match a building zone name")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Name of a HVACTemplate:System:VAV or HVACTemplate:System:PackagedVAV object servi" +
    "ng this zone")]
[JsonProperty(PropertyName="template_vav_system_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TemplateVavSystemName { get; set; } = "";
        

[Description("Enter the name of a HVACTemplate:Thermostat object. If blank, then it is assumed " +
    "that standard thermostat objects have been defined for this zone.")]
[JsonProperty(PropertyName="template_thermostat_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TemplateThermostatName { get; set; } = "";
        

[Description("This field may be set to \"autosize\". If a value is entered, it will be multiplied" +
    " by the Supply Air Sizing Factor and by zone multipliers.")]
[JsonProperty(PropertyName="supply_air_maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SupplyAirMaximumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("If blank, value from Sizing:Parameters will be used.")]
[JsonProperty(PropertyName="zone_heating_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingSizingFactor { get; set; } = null;
        

[Description("If blank, value from Sizing:Parameters will be used.")]
[JsonProperty(PropertyName="zone_cooling_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingSizingFactor { get; set; } = null;
        

[Description(@"This field is used if the field Zone Minimum Air Flow Input Method is Constant If the field Zone Minimum Air Flow Input Method is Scheduled, then this field is optional. If a value is entered, then it is used for sizing normal-action reheat coils. If both this field and the following field are entered, the larger result is used.")]
[JsonProperty(PropertyName="constant_minimum_air_flow_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConstantMinimumAirFlowFraction { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[Description(@"Flow/Person, Flow/Zone, Flow/Area, Sum, and Maximum use the values in the next three fields: Outdoor Air Flow Rate per Person, Outdoor Air Flow Rate per Zone Floor Area, and Outdoor Air Flow Rate per Zone. DetailedSpecification ignores these three Outdoor Air Flow Rate fields and instead references design specification objects named in the fields Design Specification Outdoor Air Object Name and Design Specification Zone Air Distribution Object Name.")]
[JsonProperty(PropertyName="outdoor_air_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VAV_HeatAndCool_OutdoorAirMethod OutdoorAirMethod { get; set; } = (HVACTemplate_Zone_VAV_HeatAndCool_OutdoorAirMethod)Enum.Parse(typeof(HVACTemplate_Zone_VAV_HeatAndCool_OutdoorAirMethod), "Empty");
        

[Description("Default 0.00944 is 20 cfm per person This input is used if the field Outdoor Air " +
    "Method is Flow/Person, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerPerson { get; set; } = Double.Parse("0.00944", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Area, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZoneFloorArea { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Zone, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZone { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description(@"This field is used only when Outdoor Air Method=DetailedSpecification. Note that this field is used only for specifying the design outdoor air flow rate used for sizing. The field Design Specification Outdoor Air Object Name for Control (see above) is used to actively control the VAV terminal air flow rate.")]
[JsonProperty(PropertyName="design_specification_outdoor_air_object_name_for_sizing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationOutdoorAirObjectNameForSizing { get; set; } = "";
        

[Description("This field is used only when Outdoor Air Method=DetailedSpecification.")]
[JsonProperty(PropertyName="design_specification_zone_air_distribution_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZoneAirDistributionObjectName { get; set; } = "";
        

[JsonProperty(PropertyName="reheat_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VAV_HeatAndCool_ReheatCoilType ReheatCoilType { get; set; } = (HVACTemplate_Zone_VAV_HeatAndCool_ReheatCoilType)Enum.Parse(typeof(HVACTemplate_Zone_VAV_HeatAndCool_ReheatCoilType), "None");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="reheat_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReheatCoilAvailabilityScheduleName { get; set; } = "";
        

[Description("Specifies the maximum allowable supply air temperature leaving the reheat coil. I" +
    "f left blank, there is no limit and no default. If unknown, 35C (95F) is recomme" +
    "nded.")]
[JsonProperty(PropertyName="maximum_reheat_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumReheatAirTemperature { get; set; } = null;
        

[Description("Plenum zone name. Supply plenum runs through only this zone. Blank if none.")]
[JsonProperty(PropertyName="supply_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyPlenumName { get; set; } = "";
        

[Description("Plenum zone name. Return plenum runs through only this zone. Blank if none.")]
[JsonProperty(PropertyName="return_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReturnPlenumName { get; set; } = "";
        

[JsonProperty(PropertyName="baseboard_heating_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VAV_HeatAndCool_BaseboardHeatingType BaseboardHeatingType { get; set; } = (HVACTemplate_Zone_VAV_HeatAndCool_BaseboardHeatingType)Enum.Parse(typeof(HVACTemplate_Zone_VAV_HeatAndCool_BaseboardHeatingType), "None");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="baseboard_heating_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BaseboardHeatingAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="baseboard_heating_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> BaseboardHeatingCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"SupplyAirTemperature = use the value from Zone Cooling Design Supply Air Temperature TemperatureDifference = use the value from Zone Cooling Design Supply Air Temperature Difference SystemSupplyAirTemperature = use the value from HVACTemplate:System:VAV Cooling Coil Design Setpoint")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VAV_HeatAndCool_ZoneCoolingDesignSupplyAirTemperatureInputMethod ZoneCoolingDesignSupplyAirTemperatureInputMethod { get; set; } = (HVACTemplate_Zone_VAV_HeatAndCool_ZoneCoolingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(HVACTemplate_Zone_VAV_HeatAndCool_ZoneCoolingDesignSupplyAirTemperatureInputMethod), "SystemSupplyAirTemperature");
        

[Description("Zone Cooling Design Supply Air Temperature is only used when Zone Cooling Design " +
    "Supply Air Temperature Input Method = SupplyAirTemperature")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirTemperature { get; set; } = Double.Parse("12.8", CultureInfo.InvariantCulture);
        

[Description(@"Zone Cooling Design Supply Air Temperature is only used when Zone Cooling Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be subtracted from the zone temperature at peak load to calculate the Zone Cooling Design Supply Air Temperature.")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirTemperatureDifference { get; set; } = Double.Parse("11.11", CultureInfo.InvariantCulture);
        

[Description(@"SupplyAirTemperature = use the value from Zone Heating Design Supply Air Temperature SystemSupplyAirTemperature = use the value from HVACTemplate:System:VAV Heating Coil Design Setpoint TemperatureDifference = use the value from Zone Heating Design Supply Air Temperature Difference")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_VAV_HeatAndCool_ZoneHeatingDesignSupplyAirTemperatureInputMethod ZoneHeatingDesignSupplyAirTemperatureInputMethod { get; set; } = (HVACTemplate_Zone_VAV_HeatAndCool_ZoneHeatingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(HVACTemplate_Zone_VAV_HeatAndCool_ZoneHeatingDesignSupplyAirTemperatureInputMethod), "SupplyAirTemperature");
        

[Description("Zone Heating Design Supply Air Temperature is only used when Zone Heating Design " +
    "Supply Air Temperature Input Method = SupplyAirTemperature")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirTemperature { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[Description(@"Zone Heating Design Supply Air Temperature is only used when Zone Heating Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be added to the zone temperature at peak load to calculate the Zone Heating Design Supply Air Temperature.")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirTemperatureDifference { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
    }
    
    public enum HVACTemplate_Zone_VAV_HeatAndCool_OutdoorAirMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DetailedSpecification")]
        DetailedSpecification = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Area")]
        FlowArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Person")]
        FlowPerson = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Zone")]
        FlowZone = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Maximum")]
        Maximum = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Sum")]
        Sum = 6,
    }
    
    public enum HVACTemplate_Zone_VAV_HeatAndCool_ReheatCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Gas")]
        Gas = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum HVACTemplate_Zone_VAV_HeatAndCool_BaseboardHeatingType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    public enum HVACTemplate_Zone_VAV_HeatAndCool_ZoneCoolingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SystemSupplyAirTemperature")]
        SystemSupplyAirTemperature = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 3,
    }
    
    public enum HVACTemplate_Zone_VAV_HeatAndCool_ZoneHeatingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 2,
    }
    
    [Description("Zone terminal unit, constant volume, reheat optional. Referenced schedules must b" +
        "e defined elsewhere in the idf.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_Zone_ConstantVolume
    {
        

[Description("Zone name must match a building zone name")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Name of a HVACTemplate:System:ConstantVolume object serving this zone")]
[JsonProperty(PropertyName="template_constant_volume_system_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TemplateConstantVolumeSystemName { get; set; } = "";
        

[Description("Enter the name of a HVACTemplate:Thermostat object. If blank, then it is assumed " +
    "that standard thermostat objects have been defined for this zone.")]
[JsonProperty(PropertyName="template_thermostat_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TemplateThermostatName { get; set; } = "";
        

[Description("This field may be set to \"autosize\". If a value is entered, it will be multiplied" +
    " by the Supply Air Sizing Factor and by zone multipliers.")]
[JsonProperty(PropertyName="supply_air_maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SupplyAirMaximumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("If blank, value from Sizing:Parameters will be used.")]
[JsonProperty(PropertyName="zone_heating_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingSizingFactor { get; set; } = null;
        

[Description("If blank, value from Sizing:Parameters will be used.")]
[JsonProperty(PropertyName="zone_cooling_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingSizingFactor { get; set; } = null;
        

[Description(@"Flow/Person, Flow/Zone, Flow/Area, Sum, and Maximum use the values in the next three fields: Outdoor Air Flow Rate per Person, Outdoor Air Flow Rate per Zone Floor Area, and Outdoor Air Flow Rate per Zone. DetailedSpecification ignores these three Outdoor Air Flow Rate fields and instead references design specification objects named in the fields Design Specification Outdoor Air Object Name and Design Specification Zone Air Distribution Object Name.")]
[JsonProperty(PropertyName="outdoor_air_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_ConstantVolume_OutdoorAirMethod OutdoorAirMethod { get; set; } = (HVACTemplate_Zone_ConstantVolume_OutdoorAirMethod)Enum.Parse(typeof(HVACTemplate_Zone_ConstantVolume_OutdoorAirMethod), "Empty");
        

[Description("Default 0.00944 is 20 cfm per person This input is used if the field Outdoor Air " +
    "Method is Flow/Person, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerPerson { get; set; } = Double.Parse("0.00944", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Area, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZoneFloorArea { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Zone, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZone { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This field is used only when Outdoor Air Method=DetailedSpecification.")]
[JsonProperty(PropertyName="design_specification_outdoor_air_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationOutdoorAirObjectName { get; set; } = "";
        

[Description("This field is used only when Outdoor Air Method=DetailedSpecification.")]
[JsonProperty(PropertyName="design_specification_zone_air_distribution_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZoneAirDistributionObjectName { get; set; } = "";
        

[JsonProperty(PropertyName="reheat_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_ConstantVolume_ReheatCoilType ReheatCoilType { get; set; } = (HVACTemplate_Zone_ConstantVolume_ReheatCoilType)Enum.Parse(typeof(HVACTemplate_Zone_ConstantVolume_ReheatCoilType), "None");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="reheat_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReheatCoilAvailabilityScheduleName { get; set; } = "";
        

[Description("Specifies the maximum allowable supply air temperature leaving the reheat coil. I" +
    "f left blank, there is no limit and no default. If unknown, 35C (95F) is recomme" +
    "nded.")]
[JsonProperty(PropertyName="maximum_reheat_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumReheatAirTemperature { get; set; } = null;
        

[Description("Plenum zone name. Supply plenum runs through only this zone. Blank if none.")]
[JsonProperty(PropertyName="supply_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyPlenumName { get; set; } = "";
        

[Description("Plenum zone name. Return plenum runs through only this zone. Blank if none.")]
[JsonProperty(PropertyName="return_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReturnPlenumName { get; set; } = "";
        

[JsonProperty(PropertyName="baseboard_heating_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_ConstantVolume_BaseboardHeatingType BaseboardHeatingType { get; set; } = (HVACTemplate_Zone_ConstantVolume_BaseboardHeatingType)Enum.Parse(typeof(HVACTemplate_Zone_ConstantVolume_BaseboardHeatingType), "None");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="baseboard_heating_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BaseboardHeatingAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="baseboard_heating_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> BaseboardHeatingCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"SupplyAirTemperature = use the value from Zone Cooling Design Supply Air Temperature TemperatureDifference = use the value from Zone Cooling Design Supply Air Temperature Difference SystemSupplyAirTemperature = use the value from HVACTemplate:System:VAV Cooling Coil Design Setpoint")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_ConstantVolume_ZoneCoolingDesignSupplyAirTemperatureInputMethod ZoneCoolingDesignSupplyAirTemperatureInputMethod { get; set; } = (HVACTemplate_Zone_ConstantVolume_ZoneCoolingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(HVACTemplate_Zone_ConstantVolume_ZoneCoolingDesignSupplyAirTemperatureInputMethod), "SystemSupplyAirTemperature");
        

[Description("Zone Cooling Design Supply Air Temperature is only used when Zone Cooling Design " +
    "Supply Air Temperature Input Method = SupplyAirTemperature")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirTemperature { get; set; } = Double.Parse("12.8", CultureInfo.InvariantCulture);
        

[Description(@"Zone Cooling Design Supply Air Temperature is only used when Zone Cooling Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be subtracted from the zone temperature at peak load to calculate the Zone Cooling Design Supply Air Temperature.")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirTemperatureDifference { get; set; } = Double.Parse("11.11", CultureInfo.InvariantCulture);
        

[Description("SupplyAirTemperature = use the value from Zone Heating Design Supply Air Temperat" +
    "ure TemperatureDifference = use the value from Zone Heating Design Supply Air Te" +
    "mperature Difference")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_ConstantVolume_ZoneHeatingDesignSupplyAirTemperatureInputMethod ZoneHeatingDesignSupplyAirTemperatureInputMethod { get; set; } = (HVACTemplate_Zone_ConstantVolume_ZoneHeatingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(HVACTemplate_Zone_ConstantVolume_ZoneHeatingDesignSupplyAirTemperatureInputMethod), "SupplyAirTemperature");
        

[Description("Zone Heating Design Supply Air Temperature is only used when Zone Heating Design " +
    "Supply Air Temperature Input Method = SupplyAirTemperature")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirTemperature { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[Description(@"Zone Heating Design Supply Air Temperature is only used when Zone Heating Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be added to the zone temperature at peak load to calculate the Zone Heating Design Supply Air Temperature")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirTemperatureDifference { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
    }
    
    public enum HVACTemplate_Zone_ConstantVolume_OutdoorAirMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DetailedSpecification")]
        DetailedSpecification = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Area")]
        FlowArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Person")]
        FlowPerson = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Zone")]
        FlowZone = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Maximum")]
        Maximum = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Sum")]
        Sum = 6,
    }
    
    public enum HVACTemplate_Zone_ConstantVolume_ReheatCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Gas")]
        Gas = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum HVACTemplate_Zone_ConstantVolume_BaseboardHeatingType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    public enum HVACTemplate_Zone_ConstantVolume_ZoneCoolingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SystemSupplyAirTemperature")]
        SystemSupplyAirTemperature = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 3,
    }
    
    public enum HVACTemplate_Zone_ConstantVolume_ZoneHeatingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 2,
    }
    
    [Description("Zone terminal unit, dual-duct, constant or variable volume.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_Zone_DualDuct
    {
        

[Description("Zone name must match a building zone name")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Name of a HVACTemplate:System:DualDuct object serving this zone")]
[JsonProperty(PropertyName="template_dual_duct_system_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TemplateDualDuctSystemName { get; set; } = "";
        

[Description("Enter the name of a HVACTemplate:Thermostat object. If blank, then it is assumed " +
    "that standard thermostat objects have been defined for this zone.")]
[JsonProperty(PropertyName="template_thermostat_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TemplateThermostatName { get; set; } = "";
        

[Description("This field may be set to \"autosize\". If a value is entered, it will be multiplied" +
    " by the Supply Air Sizing Factor and by zone multipliers.")]
[JsonProperty(PropertyName="supply_air_maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SupplyAirMaximumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("If blank, value from Sizing:Parameters will be used.")]
[JsonProperty(PropertyName="zone_heating_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingSizingFactor { get; set; } = null;
        

[Description("If blank, value from Sizing:Parameters will be used.")]
[JsonProperty(PropertyName="zone_cooling_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingSizingFactor { get; set; } = null;
        

[Description("This field is the Zone Minimum Air Flow Fraction specified as a fraction of the m" +
    "aximum air flow rate. This field is ignored if the system serving this zone is c" +
    "onstant volume.")]
[JsonProperty(PropertyName="zone_minimum_air_flow_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneMinimumAirFlowFraction { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[Description(@"Flow/Person, Flow/Zone, Flow/Area, Sum, and Maximum use the values in the next three fields: Outdoor Air Flow Rate per Person, Outdoor Air Flow Rate per Zone Floor Area, and Outdoor Air Flow Rate per Zone. DetailedSpecification ignores these three Outdoor Air Flow Rate fields and instead references design specification objects named in the fields Design Specification Outdoor Air Object Name and Design Specification Zone Air Distribution Object Name.")]
[JsonProperty(PropertyName="outdoor_air_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_DualDuct_OutdoorAirMethod OutdoorAirMethod { get; set; } = (HVACTemplate_Zone_DualDuct_OutdoorAirMethod)Enum.Parse(typeof(HVACTemplate_Zone_DualDuct_OutdoorAirMethod), "Empty");
        

[Description("Default 0.00944 is 20 cfm per person This input is used if the field Outdoor Air " +
    "Method is Flow/Person, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerPerson { get; set; } = Double.Parse("0.00944", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Area, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZoneFloorArea { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This input is used if the field Outdoor Air Method is Flow/Zone, Sum, or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_per_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowRatePerZone { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description(@"This field is used only when Outdoor Air Method=DetailedSpecification. Note that this field is used only for specifying the design outdoor air flow rate used for sizing. The field Design Specification Outdoor Air Object Name for Control (see above) is used to actively control the VAV terminal air flow rate.")]
[JsonProperty(PropertyName="design_specification_outdoor_air_object_name_for_sizing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationOutdoorAirObjectNameForSizing { get; set; } = "";
        

[Description("This field is used only when Outdoor Air Method=DetailedSpecification.")]
[JsonProperty(PropertyName="design_specification_zone_air_distribution_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZoneAirDistributionObjectName { get; set; } = "";
        

[Description(@"When the name of a DesignSpecification:OutdoorAir object is entered, the terminal unit will increase flow as needed to meet this outdoor air requirement. If Outdoor Air Flow per Person is non-zero, then the outdoor air requirement will be computed based on the current number of occupants in the zone. At no time will the supply air flow rate exceed the value for Maximum Air Flow Rate. If this field is blank, then the terminal unit will not be controlled for outdoor air flow. Note that this field is used only for specifying the design outdoor air flow rate used for control. The field Design Specification Outdoor Air Object Name for Sizing (see below) is used to specify the design outdoor air flow rate.")]
[JsonProperty(PropertyName="design_specification_outdoor_air_object_name_for_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationOutdoorAirObjectNameForControl { get; set; } = "";
        

[Description("Plenum zone name. Cold supply plenum that serves only this zone. Blank if none.")]
[JsonProperty(PropertyName="cold_supply_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ColdSupplyPlenumName { get; set; } = "";
        

[Description("Plenum zone name. Hot supply plenum that serves only this zone. Blank if none.")]
[JsonProperty(PropertyName="hot_supply_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HotSupplyPlenumName { get; set; } = "";
        

[Description("Plenum zone name. Return plenum that serves only this zone. Blank if none.")]
[JsonProperty(PropertyName="return_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReturnPlenumName { get; set; } = "";
        

[JsonProperty(PropertyName="baseboard_heating_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_DualDuct_BaseboardHeatingType BaseboardHeatingType { get; set; } = (HVACTemplate_Zone_DualDuct_BaseboardHeatingType)Enum.Parse(typeof(HVACTemplate_Zone_DualDuct_BaseboardHeatingType), "None");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="baseboard_heating_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BaseboardHeatingAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="baseboard_heating_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> BaseboardHeatingCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"SupplyAirTemperature = use the value from Zone Cooling Design Supply Air Temperature TemperatureDifference = use the value from Zone Cooling Design Supply Air Temperature Difference SystemSupplyAirTemperature = use the value from HVACTemplate:System:DualDuct Cooling Coil Design Setpoint")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_DualDuct_ZoneCoolingDesignSupplyAirTemperatureInputMethod ZoneCoolingDesignSupplyAirTemperatureInputMethod { get; set; } = (HVACTemplate_Zone_DualDuct_ZoneCoolingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(HVACTemplate_Zone_DualDuct_ZoneCoolingDesignSupplyAirTemperatureInputMethod), "SystemSupplyAirTemperature");
        

[Description("Zone Cooling Design Supply Air Temperature is only used when Zone Cooling Design " +
    "Supply Air Temperature Input Method = SupplyAirTemperature")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirTemperature { get; set; } = Double.Parse("12.8", CultureInfo.InvariantCulture);
        

[Description(@"Zone Cooling Design Supply Air Temperature is only used when Zone Cooling Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be subtracted from the zone temperature at peak load to calculate the Zone Cooling Design Supply Air Temperature.")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirTemperatureDifference { get; set; } = Double.Parse("11.11", CultureInfo.InvariantCulture);
        

[Description(@"SupplyAirTemperature = use the value from Zone Heating Design Supply Air Temperature TemperatureDifference = use the value from Zone Heating Design Supply Air Temperature Difference SystemSupplyAirTemperature = use the value from HVACTemplate:System:DualDuct Heating Coil Design Setpoint")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Zone_DualDuct_ZoneHeatingDesignSupplyAirTemperatureInputMethod ZoneHeatingDesignSupplyAirTemperatureInputMethod { get; set; } = (HVACTemplate_Zone_DualDuct_ZoneHeatingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(HVACTemplate_Zone_DualDuct_ZoneHeatingDesignSupplyAirTemperatureInputMethod), "SystemSupplyAirTemperature");
        

[Description("Zone Heating Design Supply Air Temperature is only used when Zone Heating Design " +
    "Supply Air Temperature Input Method = SupplyAirTemperature")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirTemperature { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[Description(@"Zone Heating Design Supply Air Temperature is only used when Zone Heating Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be added to the zone temperature at peak load to calculate the Zone Heating Design Supply Air Temperature.")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirTemperatureDifference { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
    }
    
    public enum HVACTemplate_Zone_DualDuct_OutdoorAirMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DetailedSpecification")]
        DetailedSpecification = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Area")]
        FlowArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Person")]
        FlowPerson = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Zone")]
        FlowZone = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Maximum")]
        Maximum = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Sum")]
        Sum = 6,
    }
    
    public enum HVACTemplate_Zone_DualDuct_BaseboardHeatingType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    public enum HVACTemplate_Zone_DualDuct_ZoneCoolingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SystemSupplyAirTemperature")]
        SystemSupplyAirTemperature = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 3,
    }
    
    public enum HVACTemplate_Zone_DualDuct_ZoneHeatingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SystemSupplyAirTemperature")]
        SystemSupplyAirTemperature = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 3,
    }
    
    [Description("Variable refrigerant flow (VRF) heat pump condensing unit. Serves one or more VRF" +
        " zone terminal units (HVACTemplate:Zone:VRF).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_System_VRF
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="system_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SystemAvailabilityScheduleName { get; set; } = "";
        

[Description("Enter the total cooling capacity in watts at rated conditions or set to autosize." +
    " Total cooling capacity not accounting for the effect of supply air fan heat")]
[JsonProperty(PropertyName="gross_rated_total_cooling_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> GrossRatedTotalCoolingCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the coefficient of performance at rated conditions or leave blank to use de" +
    "fault. COP includes compressor and condenser fan electrical energy input COP doe" +
    "s not include supply fan heat or supply fan electric power input")]
[JsonProperty(PropertyName="gross_rated_cooling_cop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GrossRatedCoolingCop { get; set; } = Double.Parse("3.3", CultureInfo.InvariantCulture);
        

[Description("Enter the minimum outdoor temperature allowed for cooling operation. Cooling is d" +
    "isabled below this temperature.")]
[JsonProperty(PropertyName="minimum_outdoor_temperature_in_cooling_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumOutdoorTemperatureInCoolingMode { get; set; } = Double.Parse("-6", CultureInfo.InvariantCulture);
        

[Description("Enter the maximum outdoor temperature allowed for cooling operation. Cooling is d" +
    "isabled above this temperature.")]
[JsonProperty(PropertyName="maximum_outdoor_temperature_in_cooling_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumOutdoorTemperatureInCoolingMode { get; set; } = Double.Parse("43", CultureInfo.InvariantCulture);
        

[Description("Enter the heating capacity in watts at rated conditions or set to autosize. Heati" +
    "ng capacity not accounting for the effect of supply air fan heat")]
[JsonProperty(PropertyName="gross_rated_heating_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> GrossRatedHeatingCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"If the Gross Rated Heating Capacity is autosized, the heating capacity is sized to be equal to the cooling capacity multiplied by this sizing ratio. The zone terminal unit heating coils are also sized using this ratio unless the sizing ratio input in the ZoneHVAC:TerminalUnit:VariableRefrigerantFlow object is entered.")]
[JsonProperty(PropertyName="rated_heating_capacity_sizing_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedHeatingCapacitySizingRatio { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("COP includes compressor and condenser fan electrical energy input COP does not in" +
    "clude supply fan heat or supply fan electrical energy input")]
[JsonProperty(PropertyName="gross_rated_heating_cop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GrossRatedHeatingCop { get; set; } = Double.Parse("3.4", CultureInfo.InvariantCulture);
        

[Description("Enter the minimum outdoor temperature allowed for heating operation.")]
[JsonProperty(PropertyName="minimum_outdoor_temperature_in_heating_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumOutdoorTemperatureInHeatingMode { get; set; } = Double.Parse("-20", CultureInfo.InvariantCulture);
        

[Description("Enter the maximum outdoor temperature allowed for heating operation.")]
[JsonProperty(PropertyName="maximum_outdoor_temperature_in_heating_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumOutdoorTemperatureInHeatingMode { get; set; } = Double.Parse("16", CultureInfo.InvariantCulture);
        

[Description("Enter the minimum heat pump part-load ratio (PLR). When the cooling or heating PL" +
    "R is below this value, the heat pump compressor will cycle to meet the cooling o" +
    "r heating demand.")]
[JsonProperty(PropertyName="minimum_heat_pump_part_load_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumHeatPumpPartLoadRatio { get; set; } = Double.Parse("0.15", CultureInfo.InvariantCulture);
        

[Description("Enter the name of the zone where the master thermostat is located.")]
[JsonProperty(PropertyName="zone_name_for_master_thermostat_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneNameForMasterThermostatLocation { get; set; } = "";
        

[Description("Choose a thermostat control logic scheme. If these control types fail to control " +
    "zone temperature within a reasonable limit, consider using multiple VRF systems")]
[JsonProperty(PropertyName="master_thermostat_priority_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_VRF_MasterThermostatPriorityControlType MasterThermostatPriorityControlType { get; set; } = (HVACTemplate_System_VRF_MasterThermostatPriorityControlType)Enum.Parse(typeof(HVACTemplate_System_VRF_MasterThermostatPriorityControlType), "MasterThermostatPriority");
        

[Description("this field is required if Master Thermostat Priority Control Type is Scheduled. S" +
    "chedule values of 0 denote cooling, 1 for heating, and all other values disable " +
    "the system.")]
[JsonProperty(PropertyName="thermostat_priority_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ThermostatPriorityScheduleName { get; set; } = "";
        

[Description("This field is reserved for future use. The only valid choice is No.")]
[JsonProperty(PropertyName="heat_pump_waste_heat_recovery", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes HeatPumpWasteHeatRecovery { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("Enter the equivalent length of the farthest terminal unit from the condenser")]
[JsonProperty(PropertyName="equivalent_piping_length_used_for_piping_correction_factor_in_cooling_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EquivalentPipingLengthUsedForPipingCorrectionFactorInCoolingMode { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
        

[Description("Enter the height difference between the highest and lowest terminal unit")]
[JsonProperty(PropertyName="vertical_height_used_for_piping_correction_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VerticalHeightUsedForPipingCorrectionFactor { get; set; } = Double.Parse("10", CultureInfo.InvariantCulture);
        

[Description("Enter the equivalent length of the farthest terminal unit from the condenser")]
[JsonProperty(PropertyName="equivalent_piping_length_used_for_piping_correction_factor_in_heating_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EquivalentPipingLengthUsedForPipingCorrectionFactorInHeatingMode { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
        

[Description("Enter the value of the resistive heater located in the compressor(s). This heater" +
    " is used to warm the refrigerant and oil when the compressor is off.")]
[JsonProperty(PropertyName="crankcase_heater_power_per_compressor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CrankcaseHeaterPowerPerCompressor { get; set; } = Double.Parse("33", CultureInfo.InvariantCulture);
        

[Description("Enter the total number of compressor. This input is used only for crankcase heate" +
    "r calculations.")]
[JsonProperty(PropertyName="number_of_compressors", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfCompressors { get; set; } = Double.Parse("2", CultureInfo.InvariantCulture);
        

[Description("Enter the ratio of the first stage compressor to total compressor capacity. All o" +
    "ther compressors are assumed to be equally sized. This inputs is used only for c" +
    "rankcase heater calculations.")]
[JsonProperty(PropertyName="ratio_of_compressor_size_to_total_compressor_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatioOfCompressorSizeToTotalCompressorCapacity { get; set; } = Double.Parse("0.5", CultureInfo.InvariantCulture);
        

[Description("Enter the maximum outdoor temperature above which the crankcase heaters are disab" +
    "led.")]
[JsonProperty(PropertyName="maximum_outdoor_dry_bulb_temperature_for_crankcase_heater", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumOutdoorDryBulbTemperatureForCrankcaseHeater { get; set; } = Double.Parse("5", CultureInfo.InvariantCulture);
        

[Description("Select a defrost strategy. Reverse cycle reverses the operating mode from heating" +
    " to cooling to melt frost formation on the condenser coil. The resistive strateg" +
    "y uses a resistive heater to melt the frost.")]
[JsonProperty(PropertyName="defrost_strategy", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_VRF_DefrostStrategy DefrostStrategy { get; set; } = (HVACTemplate_System_VRF_DefrostStrategy)Enum.Parse(typeof(HVACTemplate_System_VRF_DefrostStrategy), "Resistive");
        

[Description("Choose a defrost control type. Either use a fixed Timed defrost period or select " +
    "OnDemand to defrost only when necessary.")]
[JsonProperty(PropertyName="defrost_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_VRF_DefrostControl DefrostControl { get; set; } = (HVACTemplate_System_VRF_DefrostControl)Enum.Parse(typeof(HVACTemplate_System_VRF_DefrostControl), "Timed");
        

[Description("Fraction of time in defrost mode. Only applicable if timed defrost control is spe" +
    "cified.")]
[JsonProperty(PropertyName="defrost_time_period_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DefrostTimePeriodFraction { get; set; } = Double.Parse("0.058333", CultureInfo.InvariantCulture);
        

[Description("Enter the size of the resistive defrost heating element. Only applicable if resis" +
    "tive defrost strategy is specified")]
[JsonProperty(PropertyName="resistive_defrost_heater_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> ResistiveDefrostHeaterCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the maximum outdoor temperature above which defrost operation is disabled.")]
[JsonProperty(PropertyName="maximum_outdoor_dry_bulb_temperature_for_defrost_operation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumOutdoorDryBulbTemperatureForDefrostOperation { get; set; } = Double.Parse("5", CultureInfo.InvariantCulture);
        

[Description("Select either an air cooled or evaporatively cooled condenser.")]
[JsonProperty(PropertyName="condenser_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_VRF_CondenserType CondenserType { get; set; } = (HVACTemplate_System_VRF_CondenserType)Enum.Parse(typeof(HVACTemplate_System_VRF_CondenserType), "AirCooled");
        

[Description("Only used when Condenser Type = WaterCooled.")]
[JsonProperty(PropertyName="water_condenser_volume_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> WaterCondenserVolumeFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the effectiveness of the evaporatively cooled condenser. This field is only" +
    " used when the Condenser Type = EvaporativelyCooled.")]
[JsonProperty(PropertyName="evaporative_condenser_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvaporativeCondenserEffectiveness { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[Description("Used to calculate evaporative condenser water use. This field is only used when t" +
    "he Condenser Type = EvaporativelyCooled.")]
[JsonProperty(PropertyName="evaporative_condenser_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> EvaporativeCondenserAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Rated power consumed by the evaporative condenser\'s water pump. This field is onl" +
    "y used when the Condenser Type = EvaporativelyCooled.")]
[JsonProperty(PropertyName="evaporative_condenser_pump_rated_power_consumption", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> EvaporativeCondenserPumpRatedPowerConsumption { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"This field is only used for Condenser Type = EvaporativelyCooled and for periods when the basin heater is available (field Basin Heater Operating Schedule Name). For this situation, the heater maintains the basin water temperature at the basin heater setpoint temperature when the outdoor air temperature falls below the setpoint temperature. The basin heater only operates when the DX coil is off.")]
[JsonProperty(PropertyName="basin_heater_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BasinHeaterCapacity { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This field is only used for Condenser Type = EvaporativelyCooled. Enter the outdo" +
    "or dry-bulb temperature when the basin heater turns on.")]
[JsonProperty(PropertyName="basin_heater_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BasinHeaterSetpointTemperature { get; set; } = Double.Parse("2", CultureInfo.InvariantCulture);
        

[Description(@"This field is only used for Condenser Type = EvaporativelyCooled. Schedule values greater than 0 allow the basin heater to operate whenever the outdoor air dry-bulb temperature is below the basin heater setpoint temperature. If a schedule name is not entered, the basin heater is allowed to operate throughout the entire simulation.")]
[JsonProperty(PropertyName="basin_heater_operating_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BasinHeaterOperatingScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="fuel_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_VRF_FuelType FuelType { get; set; } = (HVACTemplate_System_VRF_FuelType)Enum.Parse(typeof(HVACTemplate_System_VRF_FuelType), "Electricity");
        

[Description("The minimum outdoor temperature below which heat recovery mode will not operate.")]
[JsonProperty(PropertyName="minimum_outdoor_temperature_in_heat_recovery_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumOutdoorTemperatureInHeatRecoveryMode { get; set; } = Double.Parse("-15", CultureInfo.InvariantCulture);
        

[Description("The maximum outdoor temperature above which heat recovery mode will not operate.")]
[JsonProperty(PropertyName="maximum_outdoor_temperature_in_heat_recovery_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumOutdoorTemperatureInHeatRecoveryMode { get; set; } = Double.Parse("45", CultureInfo.InvariantCulture);
    }
    
    public enum HVACTemplate_System_VRF_MasterThermostatPriorityControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="LoadPriority")]
        LoadPriority = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="MasterThermostatPriority")]
        MasterThermostatPriority = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Scheduled")]
        Scheduled = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatOffsetPriority")]
        ThermostatOffsetPriority = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="ZonePriority")]
        ZonePriority = 5,
    }
    
    public enum HVACTemplate_System_VRF_DefrostStrategy
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Resistive")]
        Resistive = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ReverseCycle")]
        ReverseCycle = 2,
    }
    
    public enum HVACTemplate_System_VRF_DefrostControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="OnDemand")]
        OnDemand = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Timed")]
        Timed = 2,
    }
    
    public enum HVACTemplate_System_VRF_CondenserType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AirCooled")]
        AirCooled = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="EvaporativelyCooled")]
        EvaporativelyCooled = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="WaterCooled")]
        WaterCooled = 3,
    }
    
    public enum HVACTemplate_System_VRF_FuelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Diesel")]
        Diesel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Electricity")]
        Electricity = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo1")]
        FuelOilNo1 = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo2")]
        FuelOilNo2 = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Gasoline")]
        Gasoline = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="NaturalGas")]
        NaturalGas = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel1")]
        OtherFuel1 = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel2")]
        OtherFuel2 = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Propane")]
        Propane = 9,
    }
    
    [Description("Unitary furnace with air conditioner")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_System_Unitary
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("If blank, always on; Unitary System always on. Schedule is used in availability m" +
    "anager and fan scheduling. Also see \"Night Cycle Control\" field.")]
[JsonProperty(PropertyName="system_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SystemAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="control_zone_or_thermostat_location_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlZoneOrThermostatLocationName { get; set; } = "";
        

[Description("This field may be set to \"autosize\". If a value is entered, it will *not* be mult" +
    "iplied by any sizing factor or by zone multipliers. If using zone multipliers a " +
    "value entered here must be large enough to serve the multiplied zones.")]
[JsonProperty(PropertyName="supply_fan_maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SupplyFanMaximumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Refers to a schedule to specify unitary supply fan operating mode. Schedule value" +
    "s of 0 indicate cycling fan (auto) Schedule values of 1 indicate continuous fan " +
    "(on) If this field is left blank, a schedule of always zero (cycling fan) will b" +
    "e used.")]
[JsonProperty(PropertyName="supply_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyFanOperatingModeScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="supply_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanDeltaPressure { get; set; } = Double.Parse("600", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanMotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_motor_in_air_stream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanMotorInAirStreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cooling_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_Unitary_CoolingCoilType CoolingCoilType { get; set; } = (HVACTemplate_System_Unitary_CoolingCoilType)Enum.Parse(typeof(HVACTemplate_System_Unitary_CoolingCoilType), "SingleSpeedDX");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="cooling_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilAvailabilityScheduleName { get; set; } = "";
        

[Description("Used for sizing.")]
[JsonProperty(PropertyName="cooling_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingDesignSupplyAirTemperature { get; set; } = Double.Parse("12.8", CultureInfo.InvariantCulture);
        

[Description("Total cooling capacity not accounting for the effect of supply air fan heat")]
[JsonProperty(PropertyName="cooling_coil_gross_rated_total_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingCoilGrossRatedTotalCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Gross SHR")]
[JsonProperty(PropertyName="cooling_coil_gross_rated_sensible_heat_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingCoilGrossRatedSensibleHeatRatio { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Gross cooling capacity divided by power input to the compressor and outdoor fan, " +
    "does not include supply air fan heat or supply air fan electric power")]
[JsonProperty(PropertyName="cooling_coil_gross_rated_cop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilGrossRatedCop { get; set; } = Double.Parse("3", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_Unitary_HeatingCoilType HeatingCoilType { get; set; } = (HVACTemplate_System_Unitary_HeatingCoilType)Enum.Parse(typeof(HVACTemplate_System_Unitary_HeatingCoilType), "Electric");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="heating_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilAvailabilityScheduleName { get; set; } = "";
        

[Description("Used for sizing.")]
[JsonProperty(PropertyName="heating_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingDesignSupplyAirTemperature { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_coil_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingCoilCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="gas_heating_coil_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasHeatingCoilEfficiency { get; set; } = Double.Parse("0.8", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="gas_heating_coil_parasitic_electric_load", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasHeatingCoilParasiticElectricLoad { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MinimumOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Schedule values multiply the minimum outdoor air flow rate If blank, always one")]
[JsonProperty(PropertyName="minimum_outdoor_air_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumOutdoorAirScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="economizer_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_Unitary_EconomizerType EconomizerType { get; set; } = (HVACTemplate_System_Unitary_EconomizerType)Enum.Parse(typeof(HVACTemplate_System_Unitary_EconomizerType), "NoEconomizer");
        

[JsonProperty(PropertyName="economizer_lockout", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_Unitary_EconomizerLockout EconomizerLockout { get; set; } = (HVACTemplate_System_Unitary_EconomizerLockout)Enum.Parse(typeof(HVACTemplate_System_Unitary_EconomizerLockout), "NoLockout");
        

[Description("Outdoor temperature above which economizer is disabled and heat recovery is enabl" +
    "ed (if available). Blank means no limit.")]
[JsonProperty(PropertyName="economizer_upper_temperature_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerUpperTemperatureLimit { get; set; } = null;
        

[Description("Outdoor temperature below which economizer is disabled and heat recovery is enabl" +
    "ed (if available). Blank means no limit.")]
[JsonProperty(PropertyName="economizer_lower_temperature_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerLowerTemperatureLimit { get; set; } = null;
        

[Description("Outdoor enthalpy above which economizer is disabled and heat recovery is enabled " +
    "(if available). Blank means no limit.")]
[JsonProperty(PropertyName="economizer_upper_enthalpy_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerUpperEnthalpyLimit { get; set; } = null;
        

[Description("Enter the maximum outdoor dewpoint temperature limit for FixedDewPointAndDryBulb " +
    "economizer control type. No input or blank input means this limit is not operati" +
    "ve. Limit is applied regardless of economizer control type.")]
[JsonProperty(PropertyName="economizer_maximum_limit_dewpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerMaximumLimitDewpointTemperature { get; set; } = null;
        

[Description("Plenum zone name. Supply plenum serves all zones on this system. Blank if none.")]
[JsonProperty(PropertyName="supply_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyPlenumName { get; set; } = "";
        

[Description("Plenum zone name. Return plenum serves all zones on this system. Blank if none.")]
[JsonProperty(PropertyName="return_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReturnPlenumName { get; set; } = "";
        

[JsonProperty(PropertyName="supply_fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_Unitary_SupplyFanPlacement SupplyFanPlacement { get; set; } = (HVACTemplate_System_Unitary_SupplyFanPlacement)Enum.Parse(typeof(HVACTemplate_System_Unitary_SupplyFanPlacement), "BlowThrough");
        

[JsonProperty(PropertyName="night_cycle_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_Unitary_NightCycleControl NightCycleControl { get; set; } = (HVACTemplate_System_Unitary_NightCycleControl)Enum.Parse(typeof(HVACTemplate_System_Unitary_NightCycleControl), "StayOff");
        

[Description("Applicable only if Night Cycle Control is Cycle On Control Zone.")]
[JsonProperty(PropertyName="night_cycle_control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NightCycleControlZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="heat_recovery_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_Unitary_HeatRecoveryType HeatRecoveryType { get; set; } = (HVACTemplate_System_Unitary_HeatRecoveryType)Enum.Parse(typeof(HVACTemplate_System_Unitary_HeatRecoveryType), "None");
        

[JsonProperty(PropertyName="sensible_heat_recovery_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SensibleHeatRecoveryEffectiveness { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[Description("Applicable only if Heat Recovery Type is Enthalpy.")]
[JsonProperty(PropertyName="latent_heat_recovery_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LatentHeatRecoveryEffectiveness { get; set; } = Double.Parse("0.65", CultureInfo.InvariantCulture);
        

[Description(@"None = meet sensible cooling load only CoolReheatHeatingCoil = cool beyond the dry-bulb setpoint as required to meet the humidity setpoint, reheat with main heating coil. CoolReheatDesuperheater = cool beyond the dry-bulb setpoint as required to meet the humidity setpoint, reheat with desuperheater coil.")]
[JsonProperty(PropertyName="dehumidification_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_Unitary_DehumidificationControlType DehumidificationControlType { get; set; } = (HVACTemplate_System_Unitary_DehumidificationControlType)Enum.Parse(typeof(HVACTemplate_System_Unitary_DehumidificationControlType), "None");
        

[Description("Zone relative humidity setpoint in percent (0 to 100)")]
[JsonProperty(PropertyName="dehumidification_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DehumidificationSetpoint { get; set; } = Double.Parse("60", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="humidifier_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_Unitary_HumidifierType HumidifierType { get; set; } = (HVACTemplate_System_Unitary_HumidifierType)Enum.Parse(typeof(HVACTemplate_System_Unitary_HumidifierType), "None");
        

[Description("If blank, always available")]
[JsonProperty(PropertyName="humidifier_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HumidifierAvailabilityScheduleName { get; set; } = "";
        

[Description("Moisture output rate at full rated power input. The humidifier does not currently" +
    " autosize, so the default is very large to allow for adequate capacity.")]
[JsonProperty(PropertyName="humidifier_rated_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidifierRatedCapacity { get; set; } = Double.Parse("1E-06", CultureInfo.InvariantCulture);
        

[Description("Electric power input at rated capacity moisture output. Power consumption is prop" +
    "ortional to moisture output with no part-load penalty.")]
[JsonProperty(PropertyName="humidifier_rated_electric_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HumidifierRatedElectricPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Zone name where humidistat is located")]
[JsonProperty(PropertyName="humidifier_control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HumidifierControlZoneName { get; set; } = "";
        

[Description("Zone relative humidity setpoint in percent (0 to 100)")]
[JsonProperty(PropertyName="humidifier_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidifierSetpoint { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
        

[Description("Specifies if the system has a return fan.")]
[JsonProperty(PropertyName="return_fan", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes ReturnFan { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[JsonProperty(PropertyName="return_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="return_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanDeltaPressure { get; set; } = Double.Parse("500", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="return_fan_motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanMotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="return_fan_motor_in_air_stream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanMotorInAirStreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
    }
    
    public enum HVACTemplate_System_Unitary_CoolingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SingleSpeedDX")]
        SingleSpeedDX = 2,
    }
    
    public enum HVACTemplate_System_Unitary_HeatingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Gas")]
        Gas = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 2,
    }
    
    public enum HVACTemplate_System_Unitary_EconomizerType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferentialDryBulb")]
        DifferentialDryBulb = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferentialDryBulbAndEnthalpy")]
        DifferentialDryBulbAndEnthalpy = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferentialEnthalpy")]
        DifferentialEnthalpy = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectronicEnthalpy")]
        ElectronicEnthalpy = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedDewPointAndDryBulb")]
        FixedDewPointAndDryBulb = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedDryBulb")]
        FixedDryBulb = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedEnthalpy")]
        FixedEnthalpy = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="NoEconomizer")]
        NoEconomizer = 8,
    }
    
    public enum HVACTemplate_System_Unitary_EconomizerLockout
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="LockoutWithCompressor")]
        LockoutWithCompressor = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="LockoutWithHeating")]
        LockoutWithHeating = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="NoLockout")]
        NoLockout = 3,
    }
    
    public enum HVACTemplate_System_Unitary_SupplyFanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum HVACTemplate_System_Unitary_NightCycleControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CycleOnAny")]
        CycleOnAny = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CycleOnControlZone")]
        CycleOnControlZone = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="StayOff")]
        StayOff = 3,
    }
    
    public enum HVACTemplate_System_Unitary_HeatRecoveryType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Enthalpy")]
        Enthalpy = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Sensible")]
        Sensible = 3,
    }
    
    public enum HVACTemplate_System_Unitary_DehumidificationControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolReheatDesuperheater")]
        CoolReheatDesuperheater = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolReheatHeatingCoil")]
        CoolReheatHeatingCoil = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    public enum HVACTemplate_System_Unitary_HumidifierType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectricSteam")]
        ElectricSteam = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
    }
    
    [Description("Unitary furnace with electric air-to-air heat pump")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_System_UnitaryHeatPump_AirToAir
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("If blank, always on; Unitary System always on. Schedule is used in availability m" +
    "anager and fan scheduling. Also see \"Night Cycle Control\" field.")]
[JsonProperty(PropertyName="system_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SystemAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="control_zone_or_thermostat_location_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlZoneOrThermostatLocationName { get; set; } = "";
        

[Description(@"Supply air flow rate during cooling operation This field may be set to ""autosize"". If a value is entered, it will *not* be multiplied by any sizing factor or by zone multipliers. If using zone multipliers a value entered here must be large enough to serve the multiplied zones.")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Supply air flow rate during heating operation This field may be set to ""autosize"". If a value is entered, it will *not* be multiplied by any sizing factor or by zone multipliers. If using zone multipliers a value entered here must be large enough to serve the multiplied zones.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Supply air flow rate when no cooling or heating is needed Only used when heat pump fan operating mode is Continuous. This air flow rate is used when no heating or cooling is required and the DX coil compressor is off. If this field is left blank or zero, the supply air flow rate from the previous on cycle (either cooling or heating) is used. This field may be set to ""autosize"". If a value is entered, it will *not* be multiplied by any sizing factor or by zone multipliers. If using zone multipliers a value entered here must be large enough to serve the multiplied zones.")]
[JsonProperty(PropertyName="no_load_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoLoadSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Refers to a schedule to specify unitary supply fan operating mode. Schedule value" +
    "s of 0 indicate cycling fan (auto) Schedule values of 1 indicate continuous fan " +
    "(on) If this field is left blank, a schedule of always zero (cycling fan) will b" +
    "e used.")]
[JsonProperty(PropertyName="supply_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyFanOperatingModeScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="supply_fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitaryHeatPump_AirToAir_SupplyFanPlacement SupplyFanPlacement { get; set; } = (HVACTemplate_System_UnitaryHeatPump_AirToAir_SupplyFanPlacement)Enum.Parse(typeof(HVACTemplate_System_UnitaryHeatPump_AirToAir_SupplyFanPlacement), "BlowThrough");
        

[JsonProperty(PropertyName="supply_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanDeltaPressure { get; set; } = Double.Parse("600", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanMotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_motor_in_air_stream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanMotorInAirStreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cooling_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitaryHeatPump_AirToAir_CoolingCoilType CoolingCoilType { get; set; } = (HVACTemplate_System_UnitaryHeatPump_AirToAir_CoolingCoilType)Enum.Parse(typeof(HVACTemplate_System_UnitaryHeatPump_AirToAir_CoolingCoilType), "SingleSpeedDX");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="cooling_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilAvailabilityScheduleName { get; set; } = "";
        

[Description("Used for sizing.")]
[JsonProperty(PropertyName="cooling_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingDesignSupplyAirTemperature { get; set; } = Double.Parse("12.8", CultureInfo.InvariantCulture);
        

[Description("Total cooling capacity not accounting for the effect of supply air fan heat Ratin" +
    "g point: air entering the cooling coil at 26.7 C dry-bulb/19.4 C wet-bulb, and a" +
    "ir entering the outdoor condenser coil at 35 C dry-bulb/23.9 C wet-bulb")]
[JsonProperty(PropertyName="cooling_coil_gross_rated_total_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingCoilGrossRatedTotalCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Rated sensible heat ratio (gross sensible capacity/gross total capacity) Sensible" +
    " and total capacities do not include effect of supply fan heat")]
[JsonProperty(PropertyName="cooling_coil_gross_rated_sensible_heat_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingCoilGrossRatedSensibleHeatRatio { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Gross cooling capacity divided by power input to the compressor and outdoor fan, " +
    "does not include supply fan heat or supply fan electric power input")]
[JsonProperty(PropertyName="cooling_coil_gross_rated_cop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilGrossRatedCop { get; set; } = Double.Parse("3", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heat_pump_heating_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitaryHeatPump_AirToAir_HeatPumpHeatingCoilType HeatPumpHeatingCoilType { get; set; } = (HVACTemplate_System_UnitaryHeatPump_AirToAir_HeatPumpHeatingCoilType)Enum.Parse(typeof(HVACTemplate_System_UnitaryHeatPump_AirToAir_HeatPumpHeatingCoilType), "SingleSpeedDXHeatPump");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="heat_pump_heating_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatPumpHeatingCoilAvailabilityScheduleName { get; set; } = "";
        

[Description("Used for sizing.")]
[JsonProperty(PropertyName="heating_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingDesignSupplyAirTemperature { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[Description("Rated heating capacity excluding the effect of supply air fan heat Rating point o" +
    "utdoor dry-bulb temp 8.33 C, outdoor wet-bulb temp 6.11 C Rating point heating c" +
    "oil entering air dry-bulb 21.11 C, coil entering wet-bulb 15.55 C")]
[JsonProperty(PropertyName="heat_pump_heating_coil_gross_rated_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatPumpHeatingCoilGrossRatedCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Heat Pump Heating Coil Rated Capacity divided by power input to the compressor and outdoor fan, does not include supply air fan heat or supply air fan electrical energy. Rating point outdoor dry-bulb temp 8.33 C, outdoor wet-bulb temp 6.11 C Rating point heating coil entering air dry-bulb 21.11 C, coil entering wet-bulb 15.55 C")]
[JsonProperty(PropertyName="heat_pump_heating_coil_rated_cop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatPumpHeatingCoilRatedCop { get; set; } = Double.Parse("2.75", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heat_pump_heating_minimum_outdoor_dry_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatPumpHeatingMinimumOutdoorDryBulbTemperature { get; set; } = Double.Parse("-8", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heat_pump_defrost_maximum_outdoor_dry_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatPumpDefrostMaximumOutdoorDryBulbTemperature { get; set; } = Double.Parse("5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heat_pump_defrost_strategy", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitaryHeatPump_AirToAir_HeatPumpDefrostStrategy HeatPumpDefrostStrategy { get; set; } = (HVACTemplate_System_UnitaryHeatPump_AirToAir_HeatPumpDefrostStrategy)Enum.Parse(typeof(HVACTemplate_System_UnitaryHeatPump_AirToAir_HeatPumpDefrostStrategy), "ReverseCycle");
        

[JsonProperty(PropertyName="heat_pump_defrost_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitaryHeatPump_AirToAir_HeatPumpDefrostControl HeatPumpDefrostControl { get; set; } = (HVACTemplate_System_UnitaryHeatPump_AirToAir_HeatPumpDefrostControl)Enum.Parse(typeof(HVACTemplate_System_UnitaryHeatPump_AirToAir_HeatPumpDefrostControl), "Timed");
        

[Description("Fraction of time in defrost mode only applicable if Timed defrost control is spec" +
    "ified")]
[JsonProperty(PropertyName="heat_pump_defrost_time_period_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatPumpDefrostTimePeriodFraction { get; set; } = Double.Parse("0.058333", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supplemental_heating_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitaryHeatPump_AirToAir_SupplementalHeatingCoilType SupplementalHeatingCoilType { get; set; } = (HVACTemplate_System_UnitaryHeatPump_AirToAir_SupplementalHeatingCoilType)Enum.Parse(typeof(HVACTemplate_System_UnitaryHeatPump_AirToAir_SupplementalHeatingCoilType), "Electric");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="supplemental_heating_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplementalHeatingCoilAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="supplemental_heating_coil_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SupplementalHeatingCoilCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Supplemental heater will not operate when outdoor temperature exceeds this value." +
    "")]
[JsonProperty(PropertyName="supplemental_heating_coil_maximum_outdoor_dry_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplementalHeatingCoilMaximumOutdoorDryBulbTemperature { get; set; } = Double.Parse("21", CultureInfo.InvariantCulture);
        

[Description("Applies only if Supplemental Heating Coil Type is Gas")]
[JsonProperty(PropertyName="supplemental_gas_heating_coil_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplementalGasHeatingCoilEfficiency { get; set; } = Double.Parse("0.8", CultureInfo.InvariantCulture);
        

[Description("Applies only if Supplemental Heating Coil Type is Gas")]
[JsonProperty(PropertyName="supplemental_gas_heating_coil_parasitic_electric_load", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplementalGasHeatingCoilParasiticElectricLoad { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MinimumOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Schedule values multiply the minimum outdoor air flow rate If blank, multiplier i" +
    "s always one")]
[JsonProperty(PropertyName="minimum_outdoor_air_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumOutdoorAirScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="economizer_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitaryHeatPump_AirToAir_EconomizerType EconomizerType { get; set; } = (HVACTemplate_System_UnitaryHeatPump_AirToAir_EconomizerType)Enum.Parse(typeof(HVACTemplate_System_UnitaryHeatPump_AirToAir_EconomizerType), "NoEconomizer");
        

[JsonProperty(PropertyName="economizer_lockout", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitaryHeatPump_AirToAir_EconomizerLockout EconomizerLockout { get; set; } = (HVACTemplate_System_UnitaryHeatPump_AirToAir_EconomizerLockout)Enum.Parse(typeof(HVACTemplate_System_UnitaryHeatPump_AirToAir_EconomizerLockout), "NoLockout");
        

[Description("Enter the maximum outdoor dry-bulb temperature limit for FixedDryBulb economizer " +
    "control type. No input or blank input means this limit is not operative. Limit i" +
    "s applied regardless of economizer control type.")]
[JsonProperty(PropertyName="economizer_maximum_limit_dry_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerMaximumLimitDryBulbTemperature { get; set; } = null;
        

[Description("Enter the maximum outdoor enthalpy limit for FixedEnthalpy economizer control typ" +
    "e. No input or blank input means this limit is not operative Limit is applied re" +
    "gardless of economizer control type.")]
[JsonProperty(PropertyName="economizer_maximum_limit_enthalpy", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerMaximumLimitEnthalpy { get; set; } = null;
        

[Description("Enter the maximum outdoor dewpoint temperature limit for FixedDewPointAndDryBulb " +
    "economizer control type. No input or blank input means this limit is not operati" +
    "ve. Limit is applied regardless of economizer control type.")]
[JsonProperty(PropertyName="economizer_maximum_limit_dewpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerMaximumLimitDewpointTemperature { get; set; } = null;
        

[Description("Enter the minimum outdoor dry-bulb temperature limit for economizer control. No i" +
    "nput or blank input means this limit is not operative Limit is applied regardles" +
    "s of economizer control type.")]
[JsonProperty(PropertyName="economizer_minimum_limit_dry_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerMinimumLimitDryBulbTemperature { get; set; } = null;
        

[Description("Plenum zone name. Supply plenum serves all zones on this system. Blank if none.")]
[JsonProperty(PropertyName="supply_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyPlenumName { get; set; } = "";
        

[Description("Plenum zone name. Return plenum serves all zones on this system. Blank if none.")]
[JsonProperty(PropertyName="return_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReturnPlenumName { get; set; } = "";
        

[JsonProperty(PropertyName="night_cycle_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitaryHeatPump_AirToAir_NightCycleControl NightCycleControl { get; set; } = (HVACTemplate_System_UnitaryHeatPump_AirToAir_NightCycleControl)Enum.Parse(typeof(HVACTemplate_System_UnitaryHeatPump_AirToAir_NightCycleControl), "StayOff");
        

[Description("Applicable only if Night Cycle Control is Cycle On Control Zone.")]
[JsonProperty(PropertyName="night_cycle_control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NightCycleControlZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="heat_recovery_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitaryHeatPump_AirToAir_HeatRecoveryType HeatRecoveryType { get; set; } = (HVACTemplate_System_UnitaryHeatPump_AirToAir_HeatRecoveryType)Enum.Parse(typeof(HVACTemplate_System_UnitaryHeatPump_AirToAir_HeatRecoveryType), "None");
        

[JsonProperty(PropertyName="sensible_heat_recovery_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SensibleHeatRecoveryEffectiveness { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[Description("Applicable only if Heat Recovery Type is Enthalpy.")]
[JsonProperty(PropertyName="latent_heat_recovery_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LatentHeatRecoveryEffectiveness { get; set; } = Double.Parse("0.65", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="humidifier_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitaryHeatPump_AirToAir_HumidifierType HumidifierType { get; set; } = (HVACTemplate_System_UnitaryHeatPump_AirToAir_HumidifierType)Enum.Parse(typeof(HVACTemplate_System_UnitaryHeatPump_AirToAir_HumidifierType), "None");
        

[Description("If blank, always available")]
[JsonProperty(PropertyName="humidifier_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HumidifierAvailabilityScheduleName { get; set; } = "";
        

[Description("Moisture output rate at full rated power input. The humidifier does not currently" +
    " autosize, so the default is very large to allow for adequate capacity.")]
[JsonProperty(PropertyName="humidifier_rated_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidifierRatedCapacity { get; set; } = Double.Parse("1E-06", CultureInfo.InvariantCulture);
        

[Description("Electric power input at rated capacity moisture output. Power consumption is prop" +
    "ortional to moisture output with no part-load penalty.")]
[JsonProperty(PropertyName="humidifier_rated_electric_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HumidifierRatedElectricPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Zone name where humidistat is located")]
[JsonProperty(PropertyName="humidifier_control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HumidifierControlZoneName { get; set; } = "";
        

[Description("Zone relative humidity setpoint in percent (0 to 100)")]
[JsonProperty(PropertyName="humidifier_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidifierSetpoint { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
        

[Description("Specifies if the system has a return fan.")]
[JsonProperty(PropertyName="return_fan", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes ReturnFan { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[JsonProperty(PropertyName="return_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="return_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanDeltaPressure { get; set; } = Double.Parse("500", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="return_fan_motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanMotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="return_fan_motor_in_air_stream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanMotorInAirStreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
    }
    
    public enum HVACTemplate_System_UnitaryHeatPump_AirToAir_SupplyFanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum HVACTemplate_System_UnitaryHeatPump_AirToAir_CoolingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SingleSpeedDX")]
        SingleSpeedDX = 1,
    }
    
    public enum HVACTemplate_System_UnitaryHeatPump_AirToAir_HeatPumpHeatingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SingleSpeedDXHeatPump")]
        SingleSpeedDXHeatPump = 1,
    }
    
    public enum HVACTemplate_System_UnitaryHeatPump_AirToAir_HeatPumpDefrostStrategy
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Resistive")]
        Resistive = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ReverseCycle")]
        ReverseCycle = 2,
    }
    
    public enum HVACTemplate_System_UnitaryHeatPump_AirToAir_HeatPumpDefrostControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="OnDemand")]
        OnDemand = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Timed")]
        Timed = 2,
    }
    
    public enum HVACTemplate_System_UnitaryHeatPump_AirToAir_SupplementalHeatingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Gas")]
        Gas = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 3,
    }
    
    public enum HVACTemplate_System_UnitaryHeatPump_AirToAir_EconomizerType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferentialDryBulb")]
        DifferentialDryBulb = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferentialDryBulbAndEnthalpy")]
        DifferentialDryBulbAndEnthalpy = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferentialEnthalpy")]
        DifferentialEnthalpy = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectronicEnthalpy")]
        ElectronicEnthalpy = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedDewPointAndDryBulb")]
        FixedDewPointAndDryBulb = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedDryBulb")]
        FixedDryBulb = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedEnthalpy")]
        FixedEnthalpy = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="NoEconomizer")]
        NoEconomizer = 8,
    }
    
    public enum HVACTemplate_System_UnitaryHeatPump_AirToAir_EconomizerLockout
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="LockoutWithCompressor")]
        LockoutWithCompressor = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="LockoutWithHeating")]
        LockoutWithHeating = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="NoLockout")]
        NoLockout = 3,
    }
    
    public enum HVACTemplate_System_UnitaryHeatPump_AirToAir_NightCycleControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CycleOnAny")]
        CycleOnAny = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CycleOnControlZone")]
        CycleOnControlZone = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="StayOff")]
        StayOff = 3,
    }
    
    public enum HVACTemplate_System_UnitaryHeatPump_AirToAir_HeatRecoveryType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Enthalpy")]
        Enthalpy = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Sensible")]
        Sensible = 3,
    }
    
    public enum HVACTemplate_System_UnitaryHeatPump_AirToAir_HumidifierType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectricSteam")]
        ElectricSteam = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
    }
    
    [Description("Unitary HVAC system with optional cooling and heating. Supports DX and chilled wa" +
        "ter, cooling, gas, electric, and hot water heating, air-to-air and water-to-air " +
        "heat pumps.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_System_UnitarySystem
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("If blank, always available. Also see Supply Fan Operating Mode Schedule Name fiel" +
    "d.")]
[JsonProperty(PropertyName="system_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SystemAvailabilityScheduleName { get; set; } = "";
        

[Description("Load control requires a Controlling Zone name. SetPoint control requires set poin" +
    "ts at coil outlet nodes. The user must add appropriate SetpointManager objects t" +
    "o the idf file.")]
[JsonProperty(PropertyName="control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitarySystem_ControlType ControlType { get; set; } = (HVACTemplate_System_UnitarySystem_ControlType)Enum.Parse(typeof(HVACTemplate_System_UnitarySystem_ControlType), "Load");
        

[Description("This field is required if Control Type is Load.")]
[JsonProperty(PropertyName="control_zone_or_thermostat_location_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlZoneOrThermostatLocationName { get; set; } = "";
        

[Description(@"Supply air flow rate during cooling operation This field may be set to ""autosize"". If a value is entered, it will *not* be multiplied by any sizing factor or by zone multipliers. If using zone multipliers a value entered here must be large enough to serve the multiplied zones.")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Supply air flow rate during heating operation This field may be set to ""autosize"". If a value is entered, it will *not* be multiplied by any sizing factor or by zone multipliers. If using zone multipliers a value entered here must be large enough to serve the multiplied zones.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Supply air flow rate when no cooling or heating is needed Only used when heat pump fan operating mode is Continuous. This air flow rate is used when no heating or cooling is required and the DX coil compressor is off. If this field is left blank or zero, the supply air flow rate from the previous on cycle (either cooling or heating) is used. This field may be set to ""autosize"". If a value is entered, it will *not* be multiplied by any sizing factor or by zone multipliers. If using zone multipliers a value entered here must be large enough to serve the multiplied zones.")]
[JsonProperty(PropertyName="no_load_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoLoadSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Refers to a schedule to specify unitary supply fan operating mode. Schedule value" +
    "s of 0 indicate cycling fan (auto) Schedule values of 1 indicate continuous fan " +
    "(on) If this field is left blank, a schedule of always zero (cycling fan) will b" +
    "e used.")]
[JsonProperty(PropertyName="supply_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyFanOperatingModeScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="supply_fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitarySystem_SupplyFanPlacement SupplyFanPlacement { get; set; } = (HVACTemplate_System_UnitarySystem_SupplyFanPlacement)Enum.Parse(typeof(HVACTemplate_System_UnitarySystem_SupplyFanPlacement), "BlowThrough");
        

[JsonProperty(PropertyName="supply_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanDeltaPressure { get; set; } = Double.Parse("600", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanMotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_motor_in_air_stream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanMotorInAirStreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cooling_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitarySystem_CoolingCoilType CoolingCoilType { get; set; } = (HVACTemplate_System_UnitarySystem_CoolingCoilType)Enum.Parse(typeof(HVACTemplate_System_UnitarySystem_CoolingCoilType), "SingleSpeedDX");
        

[Description("Used only for Cooling Coil Type = MultiSpeedDX.")]
[JsonProperty(PropertyName="number_of_speeds_for_cooling", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfSpeedsForCooling { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="cooling_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilAvailabilityScheduleName { get; set; } = "";
        

[Description("Used for sizing.")]
[JsonProperty(PropertyName="cooling_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingDesignSupplyAirTemperature { get; set; } = Double.Parse("12.8", CultureInfo.InvariantCulture);
        

[Description("Total cooling capacity not accounting for the effect of supply air fan heat Ratin" +
    "g point: air entering the cooling coil at 26.7 C dry-bulb/19.4 C wet-bulb, and a" +
    "ir entering the outdoor condenser coil at 35 C dry-bulb/23.9 C wet-bulb")]
[JsonProperty(PropertyName="dx_cooling_coil_gross_rated_total_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DxCoolingCoilGrossRatedTotalCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Rated sensible heat ratio (gross sensible capacity/gross total capacity) Sensible" +
    " and total capacities do not include effect of supply fan heat")]
[JsonProperty(PropertyName="dx_cooling_coil_gross_rated_sensible_heat_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DxCoolingCoilGrossRatedSensibleHeatRatio { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Gross cooling capacity divided by power input to the compressor and outdoor fan, " +
    "does not include supply fan heat or supply fan electric power input")]
[JsonProperty(PropertyName="dx_cooling_coil_gross_rated_cop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DxCoolingCoilGrossRatedCop { get; set; } = Double.Parse("3", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitarySystem_HeatingCoilType HeatingCoilType { get; set; } = (HVACTemplate_System_UnitarySystem_HeatingCoilType)Enum.Parse(typeof(HVACTemplate_System_UnitarySystem_HeatingCoilType), "Gas");
        

[Description("Used only for Heating Coil Type = MultiSpeedDXHeatPumpAirSource), MultiStageElect" +
    "ric, or MultiStageGas.")]
[JsonProperty(PropertyName="number_of_speeds_or_stages_for_heating", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfSpeedsOrStagesForHeating { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="heating_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilAvailabilityScheduleName { get; set; } = "";
        

[Description("Used for sizing.")]
[JsonProperty(PropertyName="heating_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingDesignSupplyAirTemperature { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[Description("Rated heating capacity excluding the effect of supply air fan heat Rating point o" +
    "utdoor dry-bulb temp 8.33 C, outdoor wet-bulb temp 6.11 C Rating point heating c" +
    "oil entering air dry-bulb 21.11 C, coil entering wet-bulb 15.55 C")]
[JsonProperty(PropertyName="heating_coil_gross_rated_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingCoilGrossRatedCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="gas_heating_coil_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasHeatingCoilEfficiency { get; set; } = Double.Parse("0.8", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="gas_heating_coil_parasitic_electric_load", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasHeatingCoilParasiticElectricLoad { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description(@"Heating Coil Rated Capacity divided by power input to the compressor and outdoor fan, does not include supply air fan heat or supply air fan electrical energy. Rating point outdoor dry-bulb temp 8.33 C, outdoor wet-bulb temp 6.11 C Rating point heating coil entering air dry-bulb 21.11 C, coil entering wet-bulb 15.55 C Applies only to DX coils")]
[JsonProperty(PropertyName="heat_pump_heating_coil_gross_rated_cop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatPumpHeatingCoilGrossRatedCop { get; set; } = Double.Parse("2.75", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heat_pump_heating_minimum_outdoor_dry_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatPumpHeatingMinimumOutdoorDryBulbTemperature { get; set; } = Double.Parse("-8", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heat_pump_defrost_maximum_outdoor_dry_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatPumpDefrostMaximumOutdoorDryBulbTemperature { get; set; } = Double.Parse("5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heat_pump_defrost_strategy", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitarySystem_HeatPumpDefrostStrategy HeatPumpDefrostStrategy { get; set; } = (HVACTemplate_System_UnitarySystem_HeatPumpDefrostStrategy)Enum.Parse(typeof(HVACTemplate_System_UnitarySystem_HeatPumpDefrostStrategy), "ReverseCycle");
        

[JsonProperty(PropertyName="heat_pump_defrost_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitarySystem_HeatPumpDefrostControl HeatPumpDefrostControl { get; set; } = (HVACTemplate_System_UnitarySystem_HeatPumpDefrostControl)Enum.Parse(typeof(HVACTemplate_System_UnitarySystem_HeatPumpDefrostControl), "Timed");
        

[Description("Fraction of time in defrost mode only applicable if Timed defrost control is spec" +
    "ified")]
[JsonProperty(PropertyName="heat_pump_defrost_time_period_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatPumpDefrostTimePeriodFraction { get; set; } = Double.Parse("0.058333", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supplemental_heating_or_reheat_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitarySystem_SupplementalHeatingOrReheatCoilType SupplementalHeatingOrReheatCoilType { get; set; } = (HVACTemplate_System_UnitarySystem_SupplementalHeatingOrReheatCoilType)Enum.Parse(typeof(HVACTemplate_System_UnitarySystem_SupplementalHeatingOrReheatCoilType), "None");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="supplemental_heating_or_reheat_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplementalHeatingOrReheatCoilAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="supplemental_heating_or_reheat_coil_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SupplementalHeatingOrReheatCoilCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Supplemental heater will not operate when outdoor temperature exceeds this value." +
    "")]
[JsonProperty(PropertyName="supplemental_heating_or_reheat_coil_maximum_outdoor_dry_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplementalHeatingOrReheatCoilMaximumOutdoorDryBulbTemperature { get; set; } = Double.Parse("21", CultureInfo.InvariantCulture);
        

[Description("Applies only if Supplemental Heating Coil Type is Gas")]
[JsonProperty(PropertyName="supplemental_gas_heating_or_reheat_coil_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplementalGasHeatingOrReheatCoilEfficiency { get; set; } = Double.Parse("0.8", CultureInfo.InvariantCulture);
        

[Description("Applies only if Supplemental Heating Coil Type is Gas")]
[JsonProperty(PropertyName="supplemental_gas_heating_or_reheat_coil_parasitic_electric_load", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplementalGasHeatingOrReheatCoilParasiticElectricLoad { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MinimumOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Schedule values multiply the minimum outdoor air flow rate If blank, multiplier i" +
    "s always one")]
[JsonProperty(PropertyName="minimum_outdoor_air_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumOutdoorAirScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="economizer_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitarySystem_EconomizerType EconomizerType { get; set; } = (HVACTemplate_System_UnitarySystem_EconomizerType)Enum.Parse(typeof(HVACTemplate_System_UnitarySystem_EconomizerType), "NoEconomizer");
        

[JsonProperty(PropertyName="economizer_lockout", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitarySystem_EconomizerLockout EconomizerLockout { get; set; } = (HVACTemplate_System_UnitarySystem_EconomizerLockout)Enum.Parse(typeof(HVACTemplate_System_UnitarySystem_EconomizerLockout), "NoLockout");
        

[Description("Enter the maximum outdoor dry-bulb temperature limit for FixedDryBulb economizer " +
    "control type. No input or blank input means this limit is not operative. Limit i" +
    "s applied regardless of economizer control type.")]
[JsonProperty(PropertyName="economizer_maximum_limit_dry_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerMaximumLimitDryBulbTemperature { get; set; } = null;
        

[Description("Enter the maximum outdoor enthalpy limit for FixedEnthalpy economizer control typ" +
    "e. No input or blank input means this limit is not operative Limit is applied re" +
    "gardless of economizer control type.")]
[JsonProperty(PropertyName="economizer_maximum_limit_enthalpy", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerMaximumLimitEnthalpy { get; set; } = null;
        

[Description("Enter the maximum outdoor dewpoint temperature limit for FixedDewPointAndDryBulb " +
    "economizer control type. No input or blank input means this limit is not operati" +
    "ve. Limit is applied regardless of economizer control type.")]
[JsonProperty(PropertyName="economizer_maximum_limit_dewpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerMaximumLimitDewpointTemperature { get; set; } = null;
        

[Description("Enter the minimum outdoor dry-bulb temperature limit for economizer control. No i" +
    "nput or blank input means this limit is not operative Limit is applied regardles" +
    "s of economizer control type.")]
[JsonProperty(PropertyName="economizer_minimum_limit_dry_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerMinimumLimitDryBulbTemperature { get; set; } = null;
        

[Description("Plenum zone name. Supply plenum serves all zones on this system. Blank if none.")]
[JsonProperty(PropertyName="supply_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyPlenumName { get; set; } = "";
        

[Description("Plenum zone name. Return plenum serves all zones on this system. Blank if none.")]
[JsonProperty(PropertyName="return_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReturnPlenumName { get; set; } = "";
        

[JsonProperty(PropertyName="heat_recovery_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitarySystem_HeatRecoveryType HeatRecoveryType { get; set; } = (HVACTemplate_System_UnitarySystem_HeatRecoveryType)Enum.Parse(typeof(HVACTemplate_System_UnitarySystem_HeatRecoveryType), "None");
        

[JsonProperty(PropertyName="sensible_heat_recovery_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SensibleHeatRecoveryEffectiveness { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[Description("Applicable only if Heat Recovery Type is Enthalpy.")]
[JsonProperty(PropertyName="latent_heat_recovery_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LatentHeatRecoveryEffectiveness { get; set; } = Double.Parse("0.65", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heat_recovery_heat_exchanger_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitarySystem_HeatRecoveryHeatExchangerType HeatRecoveryHeatExchangerType { get; set; } = (HVACTemplate_System_UnitarySystem_HeatRecoveryHeatExchangerType)Enum.Parse(typeof(HVACTemplate_System_UnitarySystem_HeatRecoveryHeatExchangerType), "Plate");
        

[JsonProperty(PropertyName="heat_recovery_frost_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitarySystem_HeatRecoveryFrostControlType HeatRecoveryFrostControlType { get; set; } = (HVACTemplate_System_UnitarySystem_HeatRecoveryFrostControlType)Enum.Parse(typeof(HVACTemplate_System_UnitarySystem_HeatRecoveryFrostControlType), "None");
        

[Description(@"None = meet sensible load only CoolReheat = cool beyond the dry-bulb setpoint, reheat with reheat coil If no reheat coil specified, cold supply temps may occur. Multimode = activate enhanced dehumidification mode as needed and meet sensible load. Valid only for Cooling Coil Type = TwoStageHumidityControlDX or HeatExchangerAssistedDX")]
[JsonProperty(PropertyName="dehumidification_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitarySystem_DehumidificationControlType DehumidificationControlType { get; set; } = (HVACTemplate_System_UnitarySystem_DehumidificationControlType)Enum.Parse(typeof(HVACTemplate_System_UnitarySystem_DehumidificationControlType), "None");
        

[Description("Zone relative humidity setpoint in percent (0 to 100) Ignored if Dehumidification" +
    " Relative Humidity Setpoint Schedule specified below")]
[JsonProperty(PropertyName="dehumidification_relative_humidity_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DehumidificationRelativeHumiditySetpoint { get; set; } = Double.Parse("60", CultureInfo.InvariantCulture);
        

[Description("Leave blank to use constant setpoint specified in Dehumidification Relative Humid" +
    "ity Setpoint above. Schedule values must be in percent relative humidity (0 to 1" +
    "00).")]
[JsonProperty(PropertyName="dehumidification_relative_humidity_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DehumidificationRelativeHumiditySetpointScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="humidifier_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitarySystem_HumidifierType HumidifierType { get; set; } = (HVACTemplate_System_UnitarySystem_HumidifierType)Enum.Parse(typeof(HVACTemplate_System_UnitarySystem_HumidifierType), "None");
        

[Description("If blank, always available")]
[JsonProperty(PropertyName="humidifier_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HumidifierAvailabilityScheduleName { get; set; } = "";
        

[Description("Moisture output rate at full rated power input. The humidifier does not currently" +
    " autosize, so the default is very large to allow for adequate capacity.")]
[JsonProperty(PropertyName="humidifier_rated_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidifierRatedCapacity { get; set; } = Double.Parse("1E-06", CultureInfo.InvariantCulture);
        

[Description("Electric power input at rated capacity moisture output. Power consumption is prop" +
    "ortional to moisture output with no part-load penalty.")]
[JsonProperty(PropertyName="humidifier_rated_electric_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HumidifierRatedElectricPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Zone name where humidistat is located")]
[JsonProperty(PropertyName="humidifier_control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HumidifierControlZoneName { get; set; } = "";
        

[Description("Zone relative humidity setpoint in percent (0 to 100). Ignored if Humidifier Rela" +
    "tive Humidity Setpoint Schedule specified below")]
[JsonProperty(PropertyName="humidifier_relative_humidity_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidifierRelativeHumiditySetpoint { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
        

[Description("Leave blank to use constant setpoint specified in Humidifier Relative Humidity Se" +
    "tpoint above. Schedule values must be in percent relative humidity (0 to 100).")]
[JsonProperty(PropertyName="humidifier_relative_humidity_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HumidifierRelativeHumiditySetpointScheduleName { get; set; } = "";
        

[Description("Select whether autosized system supply flow rate is the sum of Coincident or NonC" +
    "oincident zone air flow rates.")]
[JsonProperty(PropertyName="sizing_option", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_UnitarySystem_SizingOption SizingOption { get; set; } = (HVACTemplate_System_UnitarySystem_SizingOption)Enum.Parse(typeof(HVACTemplate_System_UnitarySystem_SizingOption), "NonCoincident");
        

[Description("Specifies if the system has a return fan.")]
[JsonProperty(PropertyName="return_fan", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes ReturnFan { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[JsonProperty(PropertyName="return_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="return_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanDeltaPressure { get; set; } = Double.Parse("300", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="return_fan_motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanMotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="return_fan_motor_in_air_stream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanMotorInAirStreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
    }
    
    public enum HVACTemplate_System_UnitarySystem_ControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Load")]
        Load = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SetPoint")]
        SetPoint = 2,
    }
    
    public enum HVACTemplate_System_UnitarySystem_SupplyFanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum HVACTemplate_System_UnitarySystem_CoolingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ChilledWater")]
        ChilledWater = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ChilledWaterDetailedFlatModel")]
        ChilledWaterDetailedFlatModel = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchangerAssistedChilledWater")]
        HeatExchangerAssistedChilledWater = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchangerAssistedDX")]
        HeatExchangerAssistedDX = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="MultiSpeedDX")]
        MultiSpeedDX = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="SingleSpeedDX")]
        SingleSpeedDX = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="SingleSpeedDXWaterCooled")]
        SingleSpeedDXWaterCooled = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="TwoSpeedDX")]
        TwoSpeedDX = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="TwoStageDX")]
        TwoStageDX = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="TwoStageHumidityControlDX")]
        TwoStageHumidityControlDX = 11,
    }
    
    public enum HVACTemplate_System_UnitarySystem_HeatingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Gas")]
        Gas = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="MultiSpeedDXHeatPumpAirSource")]
        MultiSpeedDXHeatPumpAirSource = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="MultiStageElectric")]
        MultiStageElectric = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="MultiStageGas")]
        MultiStageGas = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="SingleSpeedDXHeatPumpAirSource")]
        SingleSpeedDXHeatPumpAirSource = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="SingleSpeedDXHeatPumpWaterSource")]
        SingleSpeedDXHeatPumpWaterSource = 9,
    }
    
    public enum HVACTemplate_System_UnitarySystem_HeatPumpDefrostStrategy
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Resistive")]
        Resistive = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ReverseCycle")]
        ReverseCycle = 2,
    }
    
    public enum HVACTemplate_System_UnitarySystem_HeatPumpDefrostControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="OnDemand")]
        OnDemand = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Timed")]
        Timed = 2,
    }
    
    public enum HVACTemplate_System_UnitarySystem_SupplementalHeatingOrReheatCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DesuperHeater")]
        DesuperHeater = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Gas")]
        Gas = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 5,
    }
    
    public enum HVACTemplate_System_UnitarySystem_EconomizerType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferentialDryBulb")]
        DifferentialDryBulb = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferentialDryBulbAndEnthalpy")]
        DifferentialDryBulbAndEnthalpy = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferentialEnthalpy")]
        DifferentialEnthalpy = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectronicEnthalpy")]
        ElectronicEnthalpy = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedDewPointAndDryBulb")]
        FixedDewPointAndDryBulb = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedDryBulb")]
        FixedDryBulb = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedEnthalpy")]
        FixedEnthalpy = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="NoEconomizer")]
        NoEconomizer = 8,
    }
    
    public enum HVACTemplate_System_UnitarySystem_EconomizerLockout
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="LockoutWithCompressor")]
        LockoutWithCompressor = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="LockoutWithHeating")]
        LockoutWithHeating = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="NoLockout")]
        NoLockout = 3,
    }
    
    public enum HVACTemplate_System_UnitarySystem_HeatRecoveryType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Enthalpy")]
        Enthalpy = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Sensible")]
        Sensible = 3,
    }
    
    public enum HVACTemplate_System_UnitarySystem_HeatRecoveryHeatExchangerType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Plate")]
        Plate = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Rotary")]
        Rotary = 2,
    }
    
    public enum HVACTemplate_System_UnitarySystem_HeatRecoveryFrostControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ExhaustAirRecirculation")]
        ExhaustAirRecirculation = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ExhaustOnly")]
        ExhaustOnly = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MinimumExhaustTemperature")]
        MinimumExhaustTemperature = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum HVACTemplate_System_UnitarySystem_DehumidificationControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolReheat")]
        CoolReheat = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Multimode")]
        Multimode = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    public enum HVACTemplate_System_UnitarySystem_HumidifierType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectricSteam")]
        ElectricSteam = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
    }
    
    public enum HVACTemplate_System_UnitarySystem_SizingOption
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coincident")]
        Coincident = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="NonCoincident")]
        NonCoincident = 2,
    }
    
    [Description("Variable Air Volume (VAV) air loop with optional heating coil and optional prehea" +
        "t.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_System_VAV
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("If blank, always on; VAV System always on. Schedule is used in availability manag" +
    "er and fan scheduling. Also see \"Night Cycle Control\" field.")]
[JsonProperty(PropertyName="system_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SystemAvailabilityScheduleName { get; set; } = "";
        

[Description("This field may be set to \"autosize\". If a value is entered, it will *not* be mult" +
    "iplied by any sizing factor or by zone multipliers. If using zone multipliers a " +
    "value entered here must be large enough to serve the multiplied zones.")]
[JsonProperty(PropertyName="supply_fan_maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SupplyFanMaximumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used to set a minimum part load on the VAV fan power curve. Au" +
    "tosize or zero is recommended.")]
[JsonProperty(PropertyName="supply_fan_minimum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SupplyFanMinimumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanDeltaPressure { get; set; } = Double.Parse("1000", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanMotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_motor_in_air_stream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanMotorInAirStreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cooling_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_VAV_CoolingCoilType CoolingCoilType { get; set; } = (HVACTemplate_System_VAV_CoolingCoilType)Enum.Parse(typeof(HVACTemplate_System_VAV_CoolingCoilType), "ChilledWater");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="cooling_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilAvailabilityScheduleName { get; set; } = "";
        

[Description("Leave blank if constant setpoint")]
[JsonProperty(PropertyName="cooling_coil_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilSetpointScheduleName { get; set; } = "";
        

[Description("Used for sizing and as constant setpoint if no Cooling Coil Setpoint Schedule Nam" +
    "e is specified.")]
[JsonProperty(PropertyName="cooling_coil_design_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilDesignSetpoint { get; set; } = Double.Parse("12.8", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_VAV_HeatingCoilType HeatingCoilType { get; set; } = (HVACTemplate_System_VAV_HeatingCoilType)Enum.Parse(typeof(HVACTemplate_System_VAV_HeatingCoilType), "None");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="heating_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilAvailabilityScheduleName { get; set; } = "";
        

[Description("Leave blank if constant setpoint")]
[JsonProperty(PropertyName="heating_coil_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilSetpointScheduleName { get; set; } = "";
        

[Description("Used for sizing and as constant setpoint if no Heating Coil Setpoint Schedule Nam" +
    "e is specified.")]
[JsonProperty(PropertyName="heating_coil_design_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingCoilDesignSetpoint { get; set; } = Double.Parse("10", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="gas_heating_coil_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasHeatingCoilEfficiency { get; set; } = Double.Parse("0.8", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="gas_heating_coil_parasitic_electric_load", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasHeatingCoilParasiticElectricLoad { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="preheat_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_VAV_PreheatCoilType PreheatCoilType { get; set; } = (HVACTemplate_System_VAV_PreheatCoilType)Enum.Parse(typeof(HVACTemplate_System_VAV_PreheatCoilType), "None");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="preheat_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PreheatCoilAvailabilityScheduleName { get; set; } = "";
        

[Description("Leave blank if constant setpoint")]
[JsonProperty(PropertyName="preheat_coil_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PreheatCoilSetpointScheduleName { get; set; } = "";
        

[Description("Used for sizing and as constant setpoint if no Preheat Coil Setpoint Schedule Nam" +
    "e specified.")]
[JsonProperty(PropertyName="preheat_coil_design_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PreheatCoilDesignSetpoint { get; set; } = Double.Parse("7.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="gas_preheat_coil_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasPreheatCoilEfficiency { get; set; } = Double.Parse("0.8", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="gas_preheat_coil_parasitic_electric_load", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasPreheatCoilParasiticElectricLoad { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MinimumOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_outdoor_air_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_VAV_MinimumOutdoorAirControlType MinimumOutdoorAirControlType { get; set; } = (HVACTemplate_System_VAV_MinimumOutdoorAirControlType)Enum.Parse(typeof(HVACTemplate_System_VAV_MinimumOutdoorAirControlType), "ProportionalMinimum");
        

[Description("Schedule values multiply the Minimum Outdoor Air Flow Rate If blank, multiplier i" +
    "s always one")]
[JsonProperty(PropertyName="minimum_outdoor_air_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumOutdoorAirScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="economizer_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_VAV_EconomizerType EconomizerType { get; set; } = (HVACTemplate_System_VAV_EconomizerType)Enum.Parse(typeof(HVACTemplate_System_VAV_EconomizerType), "NoEconomizer");
        

[JsonProperty(PropertyName="economizer_lockout", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_VAV_EconomizerLockout EconomizerLockout { get; set; } = (HVACTemplate_System_VAV_EconomizerLockout)Enum.Parse(typeof(HVACTemplate_System_VAV_EconomizerLockout), "NoLockout");
        

[Description("Outdoor temperature above which economizer is disabled and heat recovery is enabl" +
    "ed (if available). Blank means no limit.")]
[JsonProperty(PropertyName="economizer_upper_temperature_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerUpperTemperatureLimit { get; set; } = null;
        

[Description("Outdoor temperature below which economizer is disabled and heat recovery is enabl" +
    "ed (if available). Blank means no limit.")]
[JsonProperty(PropertyName="economizer_lower_temperature_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerLowerTemperatureLimit { get; set; } = null;
        

[Description("Outdoor enthalpy above which economizer is disabled and heat recovery is enabled " +
    "(if available). Blank means no limit.")]
[JsonProperty(PropertyName="economizer_upper_enthalpy_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerUpperEnthalpyLimit { get; set; } = null;
        

[Description("Enter the maximum outdoor dewpoint temperature limit for FixedDewPointAndDryBulb " +
    "economizer control type. No input or blank input means this limit is not operati" +
    "ve. Limit is applied regardless of economizer control type.")]
[JsonProperty(PropertyName="economizer_maximum_limit_dewpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerMaximumLimitDewpointTemperature { get; set; } = null;
        

[Description("Plenum zone name. Supply plenum serves all zones on this system. Blank if none.")]
[JsonProperty(PropertyName="supply_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyPlenumName { get; set; } = "";
        

[Description("Plenum zone name. Supply plenum serves all zones on this system. Blank if none.")]
[JsonProperty(PropertyName="return_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReturnPlenumName { get; set; } = "";
        

[JsonProperty(PropertyName="supply_fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_VAV_SupplyFanPlacement SupplyFanPlacement { get; set; } = (HVACTemplate_System_VAV_SupplyFanPlacement)Enum.Parse(typeof(HVACTemplate_System_VAV_SupplyFanPlacement), "DrawThrough");
        

[Description("This field selects a predefined set of fan power coefficients. The ASHRAE 90.1-20" +
    "04 Appendix G coefficients are from TABLE G3.1.3.15, Method 2. The other sets of" +
    " coefficients are from the EnergyPlus Input Output Reference, Fan Coefficient Va" +
    "lues table.")]
[JsonProperty(PropertyName="supply_fan_part_load_power_coefficients", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_VAV_SupplyFanPartLoadPowerCoefficients SupplyFanPartLoadPowerCoefficients { get; set; } = (HVACTemplate_System_VAV_SupplyFanPartLoadPowerCoefficients)Enum.Parse(typeof(HVACTemplate_System_VAV_SupplyFanPartLoadPowerCoefficients), "InletVaneDampers");
        

[JsonProperty(PropertyName="night_cycle_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_VAV_NightCycleControl NightCycleControl { get; set; } = (HVACTemplate_System_VAV_NightCycleControl)Enum.Parse(typeof(HVACTemplate_System_VAV_NightCycleControl), "StayOff");
        

[Description("Applicable only if Night Cycle Control is Cycle On Control Zone.")]
[JsonProperty(PropertyName="night_cycle_control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NightCycleControlZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="heat_recovery_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_VAV_HeatRecoveryType HeatRecoveryType { get; set; } = (HVACTemplate_System_VAV_HeatRecoveryType)Enum.Parse(typeof(HVACTemplate_System_VAV_HeatRecoveryType), "None");
        

[JsonProperty(PropertyName="sensible_heat_recovery_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SensibleHeatRecoveryEffectiveness { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="latent_heat_recovery_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LatentHeatRecoveryEffectiveness { get; set; } = Double.Parse("0.65", CultureInfo.InvariantCulture);
        

[Description(@"Overrides Cooling Coil Setpoint Schedule Name None = no reset, control to Cooling Coil Design Setpoint Temperature or Schedule Warmest = reset as warm as possible yet meet all zone cooling loads at max supply air flow rate OutdoorAirTemperatureReset = reset based on outdoor air temperature (18.0C at 15.6C ODB, to the Cooling Design Setpoint at 26.7C) WarmestTemperatureFirst = reset as warm as possible yet meet all zone cooling loads at min supply air flow rate")]
[JsonProperty(PropertyName="cooling_coil_setpoint_reset_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_VAV_CoolingCoilSetpointResetType CoolingCoilSetpointResetType { get; set; } = (HVACTemplate_System_VAV_CoolingCoilSetpointResetType)Enum.Parse(typeof(HVACTemplate_System_VAV_CoolingCoilSetpointResetType), "None");
        

[Description(@"Overrides Heating Coil Setpoint Schedule Name None = no reset, control to Heating Coil Design Setpoint Temperature or Schedule OutdoorAirTemperatureReset = reset based on outdoor air temperature (Heating Design Setpoint at -6.7C ODB to Heating Design Setpoint minus 5.2C at 10C ODB) min supply air flow rate")]
[JsonProperty(PropertyName="heating_coil_setpoint_reset_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_VAV_HeatingCoilSetpointResetType HeatingCoilSetpointResetType { get; set; } = (HVACTemplate_System_VAV_HeatingCoilSetpointResetType)Enum.Parse(typeof(HVACTemplate_System_VAV_HeatingCoilSetpointResetType), "None");
        

[Description("None = meet sensible load only CoolReheat = cool beyond the dry-bulb setpoint as " +
    "required to meet the humidity setpoint.")]
[JsonProperty(PropertyName="dehumidification_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_VAV_DehumidificationControlType DehumidificationControlType { get; set; } = (HVACTemplate_System_VAV_DehumidificationControlType)Enum.Parse(typeof(HVACTemplate_System_VAV_DehumidificationControlType), "None");
        

[Description("Zone name where humidistat is located")]
[JsonProperty(PropertyName="dehumidification_control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DehumidificationControlZoneName { get; set; } = "";
        

[Description("Zone relative humidity setpoint in percent (0 to 100)")]
[JsonProperty(PropertyName="dehumidification_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DehumidificationSetpoint { get; set; } = Double.Parse("60", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="humidifier_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_VAV_HumidifierType HumidifierType { get; set; } = (HVACTemplate_System_VAV_HumidifierType)Enum.Parse(typeof(HVACTemplate_System_VAV_HumidifierType), "None");
        

[Description("If blank, always available")]
[JsonProperty(PropertyName="humidifier_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HumidifierAvailabilityScheduleName { get; set; } = "";
        

[Description("Moisture output rate at full rated power input. The humidifier does not currently" +
    " autosize, so the default is very large to allow for adequate capacity.")]
[JsonProperty(PropertyName="humidifier_rated_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidifierRatedCapacity { get; set; } = Double.Parse("1E-06", CultureInfo.InvariantCulture);
        

[Description("Electric power input at rated capacity moisture output. Power consumption is prop" +
    "ortional to moisture output with no part-load penalty.")]
[JsonProperty(PropertyName="humidifier_rated_electric_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HumidifierRatedElectricPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Zone name where humidistat is located")]
[JsonProperty(PropertyName="humidifier_control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HumidifierControlZoneName { get; set; } = "";
        

[Description("Zone relative humidity setpoint in percent (0 to 100)")]
[JsonProperty(PropertyName="humidifier_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidifierSetpoint { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
        

[Description("Select whether autosized system supply flow rate is the sum of Coincident or NonC" +
    "oincident zone air flow rates.")]
[JsonProperty(PropertyName="sizing_option", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_VAV_SizingOption SizingOption { get; set; } = (HVACTemplate_System_VAV_SizingOption)Enum.Parse(typeof(HVACTemplate_System_VAV_SizingOption), "NonCoincident");
        

[Description("Specifies if the system has a return fan.")]
[JsonProperty(PropertyName="return_fan", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes ReturnFan { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[JsonProperty(PropertyName="return_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="return_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanDeltaPressure { get; set; } = Double.Parse("500", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="return_fan_motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanMotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="return_fan_motor_in_air_stream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanMotorInAirStreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("This field selects a predefined set of fan power coefficients. The ASHRAE 90.1-20" +
    "04 Appendix G coefficients are from TABLE G3.1.3.15, Method 2. The other sets of" +
    " coefficients are from the EnergyPlus Input Output Reference, Fan Coefficient Va" +
    "lues table.")]
[JsonProperty(PropertyName="return_fan_part_load_power_coefficients", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_VAV_ReturnFanPartLoadPowerCoefficients ReturnFanPartLoadPowerCoefficients { get; set; } = (HVACTemplate_System_VAV_ReturnFanPartLoadPowerCoefficients)Enum.Parse(typeof(HVACTemplate_System_VAV_ReturnFanPartLoadPowerCoefficients), "InletVaneDampers");
    }
    
    public enum HVACTemplate_System_VAV_CoolingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ChilledWater")]
        ChilledWater = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ChilledWaterDetailedFlatModel")]
        ChilledWaterDetailedFlatModel = 2,
    }
    
    public enum HVACTemplate_System_VAV_HeatingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Gas")]
        Gas = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum HVACTemplate_System_VAV_PreheatCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Gas")]
        Gas = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum HVACTemplate_System_VAV_MinimumOutdoorAirControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedMinimum")]
        FixedMinimum = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ProportionalMinimum")]
        ProportionalMinimum = 2,
    }
    
    public enum HVACTemplate_System_VAV_EconomizerType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferentialDryBulb")]
        DifferentialDryBulb = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferentialDryBulbAndEnthalpy")]
        DifferentialDryBulbAndEnthalpy = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferentialEnthalpy")]
        DifferentialEnthalpy = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectronicEnthalpy")]
        ElectronicEnthalpy = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedDewPointAndDryBulb")]
        FixedDewPointAndDryBulb = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedDryBulb")]
        FixedDryBulb = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedEnthalpy")]
        FixedEnthalpy = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="NoEconomizer")]
        NoEconomizer = 8,
    }
    
    public enum HVACTemplate_System_VAV_EconomizerLockout
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="NoLockout")]
        NoLockout = 1,
    }
    
    public enum HVACTemplate_System_VAV_SupplyFanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum HVACTemplate_System_VAV_SupplyFanPartLoadPowerCoefficients
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAE90.1-2004AppendixG")]
        ASHRAE9012004AppendixG = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="InletVaneDampers")]
        InletVaneDampers = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="OutletDampers")]
        OutletDampers = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableSpeedMotor")]
        VariableSpeedMotor = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableSpeedMotorPressureReset")]
        VariableSpeedMotorPressureReset = 5,
    }
    
    public enum HVACTemplate_System_VAV_NightCycleControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CycleOnAny")]
        CycleOnAny = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CycleOnAnyZoneFansOnly")]
        CycleOnAnyZoneFansOnly = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="CycleOnControlZone")]
        CycleOnControlZone = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="StayOff")]
        StayOff = 4,
    }
    
    public enum HVACTemplate_System_VAV_HeatRecoveryType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Enthalpy")]
        Enthalpy = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Sensible")]
        Sensible = 3,
    }
    
    public enum HVACTemplate_System_VAV_CoolingCoilSetpointResetType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAirTemperatureReset")]
        OutdoorAirTemperatureReset = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Warmest")]
        Warmest = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="WarmestTemperatureFirst")]
        WarmestTemperatureFirst = 4,
    }
    
    public enum HVACTemplate_System_VAV_HeatingCoilSetpointResetType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAirTemperatureReset")]
        OutdoorAirTemperatureReset = 2,
    }
    
    public enum HVACTemplate_System_VAV_DehumidificationControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolReheat")]
        CoolReheat = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
    }
    
    public enum HVACTemplate_System_VAV_HumidifierType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectricSteam")]
        ElectricSteam = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
    }
    
    public enum HVACTemplate_System_VAV_SizingOption
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coincident")]
        Coincident = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="NonCoincident")]
        NonCoincident = 2,
    }
    
    public enum HVACTemplate_System_VAV_ReturnFanPartLoadPowerCoefficients
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAE90.1-2004AppendixG")]
        ASHRAE9012004AppendixG = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="InletVaneDampers")]
        InletVaneDampers = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="OutletDampers")]
        OutletDampers = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableSpeedMotor")]
        VariableSpeedMotor = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableSpeedMotorPressureReset")]
        VariableSpeedMotorPressureReset = 5,
    }
    
    [Description("Packaged Variable Air Volume (PVAV) air loop with optional heating coil and optio" +
        "nal preheat.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_System_PackagedVAV
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("If blank, always on; PVAV System always on. Schedule is used in availability mana" +
    "ger and fan scheduling. Also see \"Night Cycle Control\" field.")]
[JsonProperty(PropertyName="system_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SystemAvailabilityScheduleName { get; set; } = "";
        

[Description("This field may be set to \"autosize\". If a value is entered, it will *not* be mult" +
    "iplied by any sizing factor or by zone multipliers. If using zone multipliers a " +
    "value entered here must be large enough to serve the multiplied zones.")]
[JsonProperty(PropertyName="supply_fan_maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SupplyFanMaximumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used to set a minimum part load on the VAV fan power curve. Au" +
    "tosize or zero is recommended.")]
[JsonProperty(PropertyName="supply_fan_minimum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SupplyFanMinimumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_PackagedVAV_SupplyFanPlacement SupplyFanPlacement { get; set; } = (HVACTemplate_System_PackagedVAV_SupplyFanPlacement)Enum.Parse(typeof(HVACTemplate_System_PackagedVAV_SupplyFanPlacement), "DrawThrough");
        

[JsonProperty(PropertyName="supply_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanDeltaPressure { get; set; } = Double.Parse("1000", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanMotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_motor_in_air_stream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanMotorInAirStreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cooling_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_PackagedVAV_CoolingCoilType CoolingCoilType { get; set; } = (HVACTemplate_System_PackagedVAV_CoolingCoilType)Enum.Parse(typeof(HVACTemplate_System_PackagedVAV_CoolingCoilType), "TwoSpeedDX");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="cooling_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilAvailabilityScheduleName { get; set; } = "";
        

[Description("Leave blank if constant setpoint")]
[JsonProperty(PropertyName="cooling_coil_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilSetpointScheduleName { get; set; } = "";
        

[Description("Used for sizing and as constant setpoint if no Cooling Coil Setpoint Schedule Nam" +
    "e is specified.")]
[JsonProperty(PropertyName="cooling_coil_design_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilDesignSetpoint { get; set; } = Double.Parse("12.8", CultureInfo.InvariantCulture);
        

[Description("Total cooling capacity not accounting for the effect of supply air fan heat")]
[JsonProperty(PropertyName="cooling_coil_gross_rated_total_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingCoilGrossRatedTotalCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Gross SHR")]
[JsonProperty(PropertyName="cooling_coil_gross_rated_sensible_heat_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingCoilGrossRatedSensibleHeatRatio { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Gross cooling capacity divided by power input to the compressor and outdoor fan, " +
    "does not include supply fan heat or supply fan electric power input")]
[JsonProperty(PropertyName="cooling_coil_gross_rated_cop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilGrossRatedCop { get; set; } = Double.Parse("3", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_PackagedVAV_HeatingCoilType HeatingCoilType { get; set; } = (HVACTemplate_System_PackagedVAV_HeatingCoilType)Enum.Parse(typeof(HVACTemplate_System_PackagedVAV_HeatingCoilType), "None");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="heating_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilAvailabilityScheduleName { get; set; } = "";
        

[Description("Leave blank if constant setpoint")]
[JsonProperty(PropertyName="heating_coil_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilSetpointScheduleName { get; set; } = "";
        

[Description("Used for sizing and as constant setpoint if no Heating Coil Setpoint Schedule Nam" +
    "e is specified.")]
[JsonProperty(PropertyName="heating_coil_design_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingCoilDesignSetpoint { get; set; } = Double.Parse("10", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_coil_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingCoilCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="gas_heating_coil_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasHeatingCoilEfficiency { get; set; } = Double.Parse("0.8", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="gas_heating_coil_parasitic_electric_load", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasHeatingCoilParasiticElectricLoad { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MinimumOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_outdoor_air_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_PackagedVAV_MinimumOutdoorAirControlType MinimumOutdoorAirControlType { get; set; } = (HVACTemplate_System_PackagedVAV_MinimumOutdoorAirControlType)Enum.Parse(typeof(HVACTemplate_System_PackagedVAV_MinimumOutdoorAirControlType), "ProportionalMinimum");
        

[Description("Schedule values multiply the Minimum Outdoor Air Flow Rate If blank, multiplier i" +
    "s always one")]
[JsonProperty(PropertyName="minimum_outdoor_air_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumOutdoorAirScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="economizer_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_PackagedVAV_EconomizerType EconomizerType { get; set; } = (HVACTemplate_System_PackagedVAV_EconomizerType)Enum.Parse(typeof(HVACTemplate_System_PackagedVAV_EconomizerType), "NoEconomizer");
        

[JsonProperty(PropertyName="economizer_lockout", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_PackagedVAV_EconomizerLockout EconomizerLockout { get; set; } = (HVACTemplate_System_PackagedVAV_EconomizerLockout)Enum.Parse(typeof(HVACTemplate_System_PackagedVAV_EconomizerLockout), "NoLockout");
        

[Description("Enter the maximum outdoor dry-bulb temperature limit for FixedDryBulb economizer " +
    "control type. No input or blank input means this limit is not operative. Limit i" +
    "s applied regardless of economizer control type.")]
[JsonProperty(PropertyName="economizer_maximum_limit_dry_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerMaximumLimitDryBulbTemperature { get; set; } = null;
        

[Description("Enter the maximum outdoor enthalpy limit for FixedEnthalpy economizer control typ" +
    "e. No input or blank input means this limit is not operative Limit is applied re" +
    "gardless of economizer control type.")]
[JsonProperty(PropertyName="economizer_maximum_limit_enthalpy", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerMaximumLimitEnthalpy { get; set; } = null;
        

[Description("Enter the maximum outdoor dewpoint temperature limit for FixedDewPointAndDryBulb " +
    "economizer control type. No input or blank input means this limit is not operati" +
    "ve. Limit is applied regardless of economizer control type.")]
[JsonProperty(PropertyName="economizer_maximum_limit_dewpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerMaximumLimitDewpointTemperature { get; set; } = null;
        

[Description("Enter the minimum outdoor dry-bulb temperature limit for economizer control. No i" +
    "nput or blank input means this limit is not operative Limit is applied regardles" +
    "s of economizer control type.")]
[JsonProperty(PropertyName="economizer_minimum_limit_dry_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerMinimumLimitDryBulbTemperature { get; set; } = null;
        

[Description("Plenum zone name. Supply plenum serves all zones on this system. Blank if none.")]
[JsonProperty(PropertyName="supply_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyPlenumName { get; set; } = "";
        

[Description("Plenum zone name. Supply plenum serves all zones on this system. Blank if none.")]
[JsonProperty(PropertyName="return_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReturnPlenumName { get; set; } = "";
        

[Description("This field selects a predefined set of fan power coefficients. The ASHRAE 90.1-20" +
    "04 Appendix G coefficients are from TABLE G3.1.3.15, Method 2. The other sets of" +
    " coefficients are from the EnergyPlus Input Output Reference, Fan Coefficient Va" +
    "lues table.")]
[JsonProperty(PropertyName="supply_fan_part_load_power_coefficients", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_PackagedVAV_SupplyFanPartLoadPowerCoefficients SupplyFanPartLoadPowerCoefficients { get; set; } = (HVACTemplate_System_PackagedVAV_SupplyFanPartLoadPowerCoefficients)Enum.Parse(typeof(HVACTemplate_System_PackagedVAV_SupplyFanPartLoadPowerCoefficients), "InletVaneDampers");
        

[JsonProperty(PropertyName="night_cycle_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_PackagedVAV_NightCycleControl NightCycleControl { get; set; } = (HVACTemplate_System_PackagedVAV_NightCycleControl)Enum.Parse(typeof(HVACTemplate_System_PackagedVAV_NightCycleControl), "StayOff");
        

[Description("Applicable only if Night Cycle Control is Cycle On Control Zone.")]
[JsonProperty(PropertyName="night_cycle_control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NightCycleControlZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="heat_recovery_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_PackagedVAV_HeatRecoveryType HeatRecoveryType { get; set; } = (HVACTemplate_System_PackagedVAV_HeatRecoveryType)Enum.Parse(typeof(HVACTemplate_System_PackagedVAV_HeatRecoveryType), "None");
        

[JsonProperty(PropertyName="sensible_heat_recovery_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SensibleHeatRecoveryEffectiveness { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="latent_heat_recovery_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LatentHeatRecoveryEffectiveness { get; set; } = Double.Parse("0.65", CultureInfo.InvariantCulture);
        

[Description(@"Overrides Cooling Coil Setpoint Schedule Name None = no reset, control to Cooling Coil Design Setpoint Temperature or Schedule Warmest = reset as warm as possible yet meet all zone cooling loads at max supply air flow rate OutdoorAirTemperatureReset = reset based on outdoor air temperature (18.0C at 15.6C ODB, to the Cooling Design Setpoint at 26.7C) WarmestTemperatureFirst = reset as warm as possible yet meet all zone cooling loads at min supply air flow rate")]
[JsonProperty(PropertyName="cooling_coil_setpoint_reset_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_PackagedVAV_CoolingCoilSetpointResetType CoolingCoilSetpointResetType { get; set; } = (HVACTemplate_System_PackagedVAV_CoolingCoilSetpointResetType)Enum.Parse(typeof(HVACTemplate_System_PackagedVAV_CoolingCoilSetpointResetType), "None");
        

[Description(@"Overrides Heating Coil Setpoint Schedule Name None = no reset, control to Heating Coil Design Setpoint Temperature or Schedule OutdoorAirTemperatureReset = reset based on outdoor air temperature (Heating Design Setpoint at -6.7C ODB to Heating Design Setpoint minus 5.2C at 10C ODB) min supply air flow rate")]
[JsonProperty(PropertyName="heating_coil_setpoint_reset_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_PackagedVAV_HeatingCoilSetpointResetType HeatingCoilSetpointResetType { get; set; } = (HVACTemplate_System_PackagedVAV_HeatingCoilSetpointResetType)Enum.Parse(typeof(HVACTemplate_System_PackagedVAV_HeatingCoilSetpointResetType), "None");
        

[Description("None = meet sensible load only CoolReheat = cool beyond the dry-bulb setpoint as " +
    "required to meet the humidity setpoint.")]
[JsonProperty(PropertyName="dehumidification_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_PackagedVAV_DehumidificationControlType DehumidificationControlType { get; set; } = (HVACTemplate_System_PackagedVAV_DehumidificationControlType)Enum.Parse(typeof(HVACTemplate_System_PackagedVAV_DehumidificationControlType), "None");
        

[Description("Zone name where humidistat is located")]
[JsonProperty(PropertyName="dehumidification_control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DehumidificationControlZoneName { get; set; } = "";
        

[Description("Zone relative humidity setpoint in percent (0 to 100)")]
[JsonProperty(PropertyName="dehumidification_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DehumidificationSetpoint { get; set; } = Double.Parse("60", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="humidifier_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_PackagedVAV_HumidifierType HumidifierType { get; set; } = (HVACTemplate_System_PackagedVAV_HumidifierType)Enum.Parse(typeof(HVACTemplate_System_PackagedVAV_HumidifierType), "None");
        

[Description("If blank, always available")]
[JsonProperty(PropertyName="humidifier_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HumidifierAvailabilityScheduleName { get; set; } = "";
        

[Description("Moisture output rate at full rated power input. The humidifier does not currently" +
    " autosize, so the default is very large to allow for adequate capacity.")]
[JsonProperty(PropertyName="humidifier_rated_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidifierRatedCapacity { get; set; } = Double.Parse("1E-06", CultureInfo.InvariantCulture);
        

[Description("Electric power input at rated capacity moisture output. Power consumption is prop" +
    "ortional to moisture output with no part-load penalty.")]
[JsonProperty(PropertyName="humidifier_rated_electric_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HumidifierRatedElectricPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Zone name where humidistat is located")]
[JsonProperty(PropertyName="humidifier_control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HumidifierControlZoneName { get; set; } = "";
        

[Description("Zone relative humidity setpoint in percent (0 to 100)")]
[JsonProperty(PropertyName="humidifier_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidifierSetpoint { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
        

[Description("Select whether autosized system supply flow rate is the sum of Coincident or NonC" +
    "oincident zone air flow rates.")]
[JsonProperty(PropertyName="sizing_option", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_PackagedVAV_SizingOption SizingOption { get; set; } = (HVACTemplate_System_PackagedVAV_SizingOption)Enum.Parse(typeof(HVACTemplate_System_PackagedVAV_SizingOption), "NonCoincident");
        

[Description("Specifies if the system has a return fan.")]
[JsonProperty(PropertyName="return_fan", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes ReturnFan { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[JsonProperty(PropertyName="return_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="return_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanDeltaPressure { get; set; } = Double.Parse("500", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="return_fan_motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanMotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="return_fan_motor_in_air_stream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanMotorInAirStreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("This field selects a predefined set of fan power coefficients. The ASHRAE 90.1-20" +
    "04 Appendix G coefficients are from TABLE G3.1.3.15, Method 2. The other sets of" +
    " coefficients are from the EnergyPlus Input Output Reference, Fan Coefficient Va" +
    "lues table.")]
[JsonProperty(PropertyName="return_fan_part_load_power_coefficients", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_PackagedVAV_ReturnFanPartLoadPowerCoefficients ReturnFanPartLoadPowerCoefficients { get; set; } = (HVACTemplate_System_PackagedVAV_ReturnFanPartLoadPowerCoefficients)Enum.Parse(typeof(HVACTemplate_System_PackagedVAV_ReturnFanPartLoadPowerCoefficients), "InletVaneDampers");
    }
    
    public enum HVACTemplate_System_PackagedVAV_SupplyFanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum HVACTemplate_System_PackagedVAV_CoolingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="TwoSpeedDX")]
        TwoSpeedDX = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TwoSpeedHumidControlDX")]
        TwoSpeedHumidControlDX = 2,
    }
    
    public enum HVACTemplate_System_PackagedVAV_HeatingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Gas")]
        Gas = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum HVACTemplate_System_PackagedVAV_MinimumOutdoorAirControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedMinimum")]
        FixedMinimum = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ProportionalMinimum")]
        ProportionalMinimum = 2,
    }
    
    public enum HVACTemplate_System_PackagedVAV_EconomizerType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferentialDryBulb")]
        DifferentialDryBulb = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferentialDryBulbAndEnthalpy")]
        DifferentialDryBulbAndEnthalpy = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferentialEnthalpy")]
        DifferentialEnthalpy = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectronicEnthalpy")]
        ElectronicEnthalpy = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedDewPointAndDryBulb")]
        FixedDewPointAndDryBulb = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedDryBulb")]
        FixedDryBulb = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedEnthalpy")]
        FixedEnthalpy = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="NoEconomizer")]
        NoEconomizer = 8,
    }
    
    public enum HVACTemplate_System_PackagedVAV_EconomizerLockout
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="LockoutWithCompressor")]
        LockoutWithCompressor = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="LockoutWithHeating")]
        LockoutWithHeating = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="NoLockout")]
        NoLockout = 3,
    }
    
    public enum HVACTemplate_System_PackagedVAV_SupplyFanPartLoadPowerCoefficients
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAE90.1-2004AppendixG")]
        ASHRAE9012004AppendixG = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="InletVaneDampers")]
        InletVaneDampers = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="OutletDampers")]
        OutletDampers = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableSpeedMotor")]
        VariableSpeedMotor = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableSpeedMotorPressureReset")]
        VariableSpeedMotorPressureReset = 5,
    }
    
    public enum HVACTemplate_System_PackagedVAV_NightCycleControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CycleOnAny")]
        CycleOnAny = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CycleOnAnyZoneFansOnly")]
        CycleOnAnyZoneFansOnly = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="CycleOnControlZone")]
        CycleOnControlZone = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="StayOff")]
        StayOff = 4,
    }
    
    public enum HVACTemplate_System_PackagedVAV_HeatRecoveryType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Enthalpy")]
        Enthalpy = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Sensible")]
        Sensible = 3,
    }
    
    public enum HVACTemplate_System_PackagedVAV_CoolingCoilSetpointResetType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAirTemperatureReset")]
        OutdoorAirTemperatureReset = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Warmest")]
        Warmest = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="WarmestTemperatureFirst")]
        WarmestTemperatureFirst = 4,
    }
    
    public enum HVACTemplate_System_PackagedVAV_HeatingCoilSetpointResetType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAirTemperatureReset")]
        OutdoorAirTemperatureReset = 2,
    }
    
    public enum HVACTemplate_System_PackagedVAV_DehumidificationControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolReheat")]
        CoolReheat = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
    }
    
    public enum HVACTemplate_System_PackagedVAV_HumidifierType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectricSteam")]
        ElectricSteam = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
    }
    
    public enum HVACTemplate_System_PackagedVAV_SizingOption
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coincident")]
        Coincident = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="NonCoincident")]
        NonCoincident = 2,
    }
    
    public enum HVACTemplate_System_PackagedVAV_ReturnFanPartLoadPowerCoefficients
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAE90.1-2004AppendixG")]
        ASHRAE9012004AppendixG = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="InletVaneDampers")]
        InletVaneDampers = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="OutletDampers")]
        OutletDampers = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableSpeedMotor")]
        VariableSpeedMotor = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableSpeedMotorPressureReset")]
        VariableSpeedMotorPressureReset = 5,
    }
    
    [Description("Constant Air Volume air loop with optional chilled water cooling coil, optional h" +
        "eating coil and optional preheat.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_System_ConstantVolume
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("If blank, always on;  Schedule is used in availability manager and fan scheduling" +
    ". Also see \"Night Cycle Control\" field.")]
[JsonProperty(PropertyName="system_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SystemAvailabilityScheduleName { get; set; } = "";
        

[Description("This field may be set to \"autosize\". If a value is entered, it will *not* be mult" +
    "iplied by any sizing factor or by zone multipliers. If using zone multipliers a " +
    "value entered here must be large enough to serve the multiplied zones.")]
[JsonProperty(PropertyName="supply_fan_maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SupplyFanMaximumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanDeltaPressure { get; set; } = Double.Parse("600", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanMotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_motor_in_air_stream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanMotorInAirStreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_ConstantVolume_SupplyFanPlacement SupplyFanPlacement { get; set; } = (HVACTemplate_System_ConstantVolume_SupplyFanPlacement)Enum.Parse(typeof(HVACTemplate_System_ConstantVolume_SupplyFanPlacement), "DrawThrough");
        

[JsonProperty(PropertyName="cooling_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_ConstantVolume_CoolingCoilType CoolingCoilType { get; set; } = (HVACTemplate_System_ConstantVolume_CoolingCoilType)Enum.Parse(typeof(HVACTemplate_System_ConstantVolume_CoolingCoilType), "ChilledWater");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="cooling_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="cooling_coil_setpoint_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_ConstantVolume_CoolingCoilSetpointControlType CoolingCoilSetpointControlType { get; set; } = (HVACTemplate_System_ConstantVolume_CoolingCoilSetpointControlType)Enum.Parse(typeof(HVACTemplate_System_ConstantVolume_CoolingCoilSetpointControlType), "FixedSetpoint");
        

[Description("name of the HVACTemplate:ZoneConstantVolume object that contains the cooling ther" +
    "mostat when Cooling Coil Setpoint Control Type = ControlZone")]
[JsonProperty(PropertyName="cooling_coil_control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilControlZoneName { get; set; } = "";
        

[Description("Used for sizing and as constant setpoint if no Cooling Coil Setpoint Schedule Nam" +
    "e is specified.")]
[JsonProperty(PropertyName="cooling_coil_design_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilDesignSetpointTemperature { get; set; } = Double.Parse("12.8", CultureInfo.InvariantCulture);
        

[Description("Leave blank if constant setpoint")]
[JsonProperty(PropertyName="cooling_coil_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilSetpointScheduleName { get; set; } = "";
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="cooling_coil_setpoint_at_outdoor_dry_bulb_low", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilSetpointAtOutdoorDryBulbLow { get; set; } = Double.Parse("15.6", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control. Defaults are 15.6C (60F) " +
    "at 15.6C (60F) to 12.8C (55F) at 23.3C (74F)")]
[JsonProperty(PropertyName="cooling_coil_reset_outdoor_dry_bulb_low", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilResetOutdoorDryBulbLow { get; set; } = Double.Parse("15.6", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="cooling_coil_setpoint_at_outdoor_dry_bulb_high", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilSetpointAtOutdoorDryBulbHigh { get; set; } = Double.Parse("12.8", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="cooling_coil_reset_outdoor_dry_bulb_high", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilResetOutdoorDryBulbHigh { get; set; } = Double.Parse("23.3", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_ConstantVolume_HeatingCoilType HeatingCoilType { get; set; } = (HVACTemplate_System_ConstantVolume_HeatingCoilType)Enum.Parse(typeof(HVACTemplate_System_ConstantVolume_HeatingCoilType), "HotWater");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="heating_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="heating_coil_setpoint_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_ConstantVolume_HeatingCoilSetpointControlType HeatingCoilSetpointControlType { get; set; } = (HVACTemplate_System_ConstantVolume_HeatingCoilSetpointControlType)Enum.Parse(typeof(HVACTemplate_System_ConstantVolume_HeatingCoilSetpointControlType), "FixedSetpoint");
        

[Description("name of the HVACTemplate:ZoneConstantVolume object that contains the heating ther" +
    "mostat")]
[JsonProperty(PropertyName="heating_coil_control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilControlZoneName { get; set; } = "";
        

[Description("Used for sizing and as constant setpoint if no Heating Coil Setpoint Schedule Nam" +
    "e is specified.")]
[JsonProperty(PropertyName="heating_coil_design_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingCoilDesignSetpoint { get; set; } = Double.Parse("10", CultureInfo.InvariantCulture);
        

[Description("Leave blank if constant setpoint")]
[JsonProperty(PropertyName="heating_coil_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilSetpointScheduleName { get; set; } = "";
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="heating_coil_setpoint_at_outdoor_dry_bulb_low", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingCoilSetpointAtOutdoorDryBulbLow { get; set; } = Double.Parse("15", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control. Defaults are 15.6C (60F) " +
    "at 15.6C (60F) to 12.8C (55F) at 23.3C (74F)")]
[JsonProperty(PropertyName="heating_coil_reset_outdoor_dry_bulb_low", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingCoilResetOutdoorDryBulbLow { get; set; } = Double.Parse("7.8", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="heating_coil_setpoint_at_outdoor_dry_bulb_high", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingCoilSetpointAtOutdoorDryBulbHigh { get; set; } = Double.Parse("12.2", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="heating_coil_reset_outdoor_dry_bulb_high", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingCoilResetOutdoorDryBulbHigh { get; set; } = Double.Parse("12.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_coil_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingCoilCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="gas_heating_coil_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasHeatingCoilEfficiency { get; set; } = Double.Parse("0.8", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="gas_heating_coil_parasitic_electric_load", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasHeatingCoilParasiticElectricLoad { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="preheat_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_ConstantVolume_PreheatCoilType PreheatCoilType { get; set; } = (HVACTemplate_System_ConstantVolume_PreheatCoilType)Enum.Parse(typeof(HVACTemplate_System_ConstantVolume_PreheatCoilType), "None");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="preheat_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PreheatCoilAvailabilityScheduleName { get; set; } = "";
        

[Description("Used for sizing and as constant setpoint if no Preheat Coil Setpoint Schedule Nam" +
    "e specified.")]
[JsonProperty(PropertyName="preheat_coil_design_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PreheatCoilDesignSetpoint { get; set; } = Double.Parse("7.2", CultureInfo.InvariantCulture);
        

[Description("Leave blank if constant setpoint")]
[JsonProperty(PropertyName="preheat_coil_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PreheatCoilSetpointScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="gas_preheat_coil_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasPreheatCoilEfficiency { get; set; } = Double.Parse("0.8", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="gas_preheat_coil_parasitic_electric_load", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasPreheatCoilParasiticElectricLoad { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MinimumOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Schedule values multiply the Minimum Outdoor Air Flow Rate If blank, multiplier i" +
    "s always one")]
[JsonProperty(PropertyName="minimum_outdoor_air_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumOutdoorAirScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="economizer_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_ConstantVolume_EconomizerType EconomizerType { get; set; } = (HVACTemplate_System_ConstantVolume_EconomizerType)Enum.Parse(typeof(HVACTemplate_System_ConstantVolume_EconomizerType), "NoEconomizer");
        

[Description("Outdoor temperature above which economizer is disabled and heat recovery is enabl" +
    "ed (if available). Blank means no limit.")]
[JsonProperty(PropertyName="economizer_upper_temperature_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerUpperTemperatureLimit { get; set; } = null;
        

[Description("Outdoor temperature below which economizer is disabled and heat recovery is enabl" +
    "ed (if available). Blank means no limit.")]
[JsonProperty(PropertyName="economizer_lower_temperature_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerLowerTemperatureLimit { get; set; } = null;
        

[Description("Outdoor enthalpy above which economizer is disabled and heat recovery is enabled " +
    "(if available). Blank means no limit.")]
[JsonProperty(PropertyName="economizer_upper_enthalpy_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerUpperEnthalpyLimit { get; set; } = null;
        

[Description("Enter the maximum outdoor dewpoint temperature limit for FixedDewPointAndDryBulb " +
    "economizer control type. No input or blank input means this limit is not operati" +
    "ve. Limit is applied regardless of economizer control type.")]
[JsonProperty(PropertyName="economizer_maximum_limit_dewpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerMaximumLimitDewpointTemperature { get; set; } = null;
        

[Description("Plenum zone name. Supply plenum serves all zones on this system. Blank if none.")]
[JsonProperty(PropertyName="supply_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyPlenumName { get; set; } = "";
        

[Description("Plenum zone name. Supply plenum serves all zones on this system. Blank if none.")]
[JsonProperty(PropertyName="return_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReturnPlenumName { get; set; } = "";
        

[JsonProperty(PropertyName="night_cycle_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_ConstantVolume_NightCycleControl NightCycleControl { get; set; } = (HVACTemplate_System_ConstantVolume_NightCycleControl)Enum.Parse(typeof(HVACTemplate_System_ConstantVolume_NightCycleControl), "StayOff");
        

[Description("Applicable only if Night Cycle Control is Cycle On Control Zone.")]
[JsonProperty(PropertyName="night_cycle_control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NightCycleControlZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="heat_recovery_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_ConstantVolume_HeatRecoveryType HeatRecoveryType { get; set; } = (HVACTemplate_System_ConstantVolume_HeatRecoveryType)Enum.Parse(typeof(HVACTemplate_System_ConstantVolume_HeatRecoveryType), "None");
        

[JsonProperty(PropertyName="sensible_heat_recovery_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SensibleHeatRecoveryEffectiveness { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="latent_heat_recovery_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LatentHeatRecoveryEffectiveness { get; set; } = Double.Parse("0.65", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heat_recovery_heat_exchanger_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_ConstantVolume_HeatRecoveryHeatExchangerType HeatRecoveryHeatExchangerType { get; set; } = (HVACTemplate_System_ConstantVolume_HeatRecoveryHeatExchangerType)Enum.Parse(typeof(HVACTemplate_System_ConstantVolume_HeatRecoveryHeatExchangerType), "Plate");
        

[JsonProperty(PropertyName="heat_recovery_frost_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_ConstantVolume_HeatRecoveryFrostControlType HeatRecoveryFrostControlType { get; set; } = (HVACTemplate_System_ConstantVolume_HeatRecoveryFrostControlType)Enum.Parse(typeof(HVACTemplate_System_ConstantVolume_HeatRecoveryFrostControlType), "None");
        

[Description("None = meet sensible load only CoolReheat = cool beyond the dry-bulb setpoint as " +
    "required to meet the humidity setpoint.")]
[JsonProperty(PropertyName="dehumidification_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_ConstantVolume_DehumidificationControlType DehumidificationControlType { get; set; } = (HVACTemplate_System_ConstantVolume_DehumidificationControlType)Enum.Parse(typeof(HVACTemplate_System_ConstantVolume_DehumidificationControlType), "None");
        

[Description("Zone name where humidistat is located")]
[JsonProperty(PropertyName="dehumidification_control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DehumidificationControlZoneName { get; set; } = "";
        

[Description("Zone relative humidity setpoint in percent (0 to 100) Ignored if Dehumidification" +
    " Relative Humidity Setpoint Schedule specified below")]
[JsonProperty(PropertyName="dehumidification_relative_humidity_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DehumidificationRelativeHumiditySetpoint { get; set; } = Double.Parse("60", CultureInfo.InvariantCulture);
        

[Description("Leave blank to use constant setpoint specified in Dehumidification Relative Humid" +
    "ity Setpoint above. Schedule values must be in percent relative humidity (0 to 1" +
    "00).")]
[JsonProperty(PropertyName="dehumidification_relative_humidity_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DehumidificationRelativeHumiditySetpointScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="humidifier_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_ConstantVolume_HumidifierType HumidifierType { get; set; } = (HVACTemplate_System_ConstantVolume_HumidifierType)Enum.Parse(typeof(HVACTemplate_System_ConstantVolume_HumidifierType), "None");
        

[Description("If blank, always available")]
[JsonProperty(PropertyName="humidifier_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HumidifierAvailabilityScheduleName { get; set; } = "";
        

[Description("Moisture output rate at full rated power input. The humidifier does not currently" +
    " autosize, so the default is very large to allow for adequate capacity.")]
[JsonProperty(PropertyName="humidifier_rated_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidifierRatedCapacity { get; set; } = Double.Parse("1E-06", CultureInfo.InvariantCulture);
        

[Description("Electric power input at rated capacity moisture output. Power consumption is prop" +
    "ortional to moisture output with no part-load penalty.")]
[JsonProperty(PropertyName="humidifier_rated_electric_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HumidifierRatedElectricPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Zone name where humidistat is located")]
[JsonProperty(PropertyName="humidifier_control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HumidifierControlZoneName { get; set; } = "";
        

[Description("Zone relative humidity setpoint in percent (0 to 100). Ignored if Humidifier Rela" +
    "tive Humidity Setpoint Schedule specified below")]
[JsonProperty(PropertyName="humidifier_relative_humidity_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidifierRelativeHumiditySetpoint { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
        

[Description("Leave blank to use constant setpoint specified in Humidifier Relative Humidity Se" +
    "tpoint above. Schedule values must be in percent relative humidity (0 to 100).")]
[JsonProperty(PropertyName="humidifier_relative_humidity_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HumidifierRelativeHumiditySetpointScheduleName { get; set; } = "";
        

[Description("Specifies if the system has a return fan.")]
[JsonProperty(PropertyName="return_fan", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes ReturnFan { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[JsonProperty(PropertyName="return_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="return_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanDeltaPressure { get; set; } = Double.Parse("300", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="return_fan_motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanMotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="return_fan_motor_in_air_stream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanMotorInAirStreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
    }
    
    public enum HVACTemplate_System_ConstantVolume_SupplyFanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum HVACTemplate_System_ConstantVolume_CoolingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ChilledWater")]
        ChilledWater = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ChilledWaterDetailedFlatModel")]
        ChilledWaterDetailedFlatModel = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchangerAssistedChilledWater")]
        HeatExchangerAssistedChilledWater = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum HVACTemplate_System_ConstantVolume_CoolingCoilSetpointControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ControlZone")]
        ControlZone = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedSetpoint")]
        FixedSetpoint = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAirTemperatureReset")]
        OutdoorAirTemperatureReset = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Scheduled")]
        Scheduled = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Warmest")]
        Warmest = 5,
    }
    
    public enum HVACTemplate_System_ConstantVolume_HeatingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Gas")]
        Gas = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum HVACTemplate_System_ConstantVolume_HeatingCoilSetpointControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ControlZone")]
        ControlZone = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedSetpoint")]
        FixedSetpoint = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAirTemperatureReset")]
        OutdoorAirTemperatureReset = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Scheduled")]
        Scheduled = 4,
    }
    
    public enum HVACTemplate_System_ConstantVolume_PreheatCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Gas")]
        Gas = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum HVACTemplate_System_ConstantVolume_EconomizerType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferentialDryBulb")]
        DifferentialDryBulb = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferentialDryBulbAndEnthalpy")]
        DifferentialDryBulbAndEnthalpy = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferentialEnthalpy")]
        DifferentialEnthalpy = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectronicEnthalpy")]
        ElectronicEnthalpy = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedDewPointAndDryBulb")]
        FixedDewPointAndDryBulb = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedDryBulb")]
        FixedDryBulb = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedEnthalpy")]
        FixedEnthalpy = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="NoEconomizer")]
        NoEconomizer = 8,
    }
    
    public enum HVACTemplate_System_ConstantVolume_NightCycleControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CycleOnAny")]
        CycleOnAny = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CycleOnAnyZoneFansOnly")]
        CycleOnAnyZoneFansOnly = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="CycleOnControlZone")]
        CycleOnControlZone = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="StayOff")]
        StayOff = 4,
    }
    
    public enum HVACTemplate_System_ConstantVolume_HeatRecoveryType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Enthalpy")]
        Enthalpy = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Sensible")]
        Sensible = 3,
    }
    
    public enum HVACTemplate_System_ConstantVolume_HeatRecoveryHeatExchangerType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Plate")]
        Plate = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Rotary")]
        Rotary = 2,
    }
    
    public enum HVACTemplate_System_ConstantVolume_HeatRecoveryFrostControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ExhaustAirRecirculation")]
        ExhaustAirRecirculation = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ExhaustOnly")]
        ExhaustOnly = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MinimumExhaustTemperature")]
        MinimumExhaustTemperature = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum HVACTemplate_System_ConstantVolume_DehumidificationControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolReheat")]
        CoolReheat = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
    }
    
    public enum HVACTemplate_System_ConstantVolume_HumidifierType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectricSteam")]
        ElectricSteam = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
    }
    
    [Description("Dual-duct constant volume or variable volume air loop")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_System_DualDuct
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("If blank, always on;  Schedule is used in availability manager and fan scheduling" +
    ". Also see \"Night Cycle Control\" field.")]
[JsonProperty(PropertyName="system_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SystemAvailabilityScheduleName { get; set; } = "";
        

[Description("SingleFan - a single supply fan before the split to dual ducts DualFan - two supp" +
    "ly fans, one each for the cold and hot ducts ConstantVolume - constant volume Va" +
    "riableVolume - variable volume")]
[JsonProperty(PropertyName="system_configuration_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DualDuct_SystemConfigurationType SystemConfigurationType { get; set; } = (HVACTemplate_System_DualDuct_SystemConfigurationType)Enum.Parse(typeof(HVACTemplate_System_DualDuct_SystemConfigurationType), "SingleFanConstantVolume");
        

[Description("This field may be set to \"autosize\". If a value is entered, it will *not* be mult" +
    "iplied by any sizing factor or by zone multipliers. If using zone multipliers a " +
    "value entered here must be large enough to serve the multiplied zones.")]
[JsonProperty(PropertyName="main_supply_fan_maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MainSupplyFanMaximumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="main_supply_fan_minimum_flow_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MainSupplyFanMinimumFlowFraction { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="main_supply_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MainSupplyFanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="main_supply_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MainSupplyFanDeltaPressure { get; set; } = Double.Parse("1000", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="main_supply_fan_motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MainSupplyFanMotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="main_supply_fan_motor_in_air_stream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MainSupplyFanMotorInAirStreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("This field selects a predefined set of fan power coefficients. The ASHRAE 90.1-20" +
    "04 Appendix G coefficients are from TABLE G3.1.3.15, Method 2. The other sets of" +
    " coefficients are from the EnergyPlus Input Output Reference, Fan Coefficient Va" +
    "lues table.")]
[JsonProperty(PropertyName="main_supply_fan_part_load_power_coefficients", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DualDuct_MainSupplyFanPartLoadPowerCoefficients MainSupplyFanPartLoadPowerCoefficients { get; set; } = (HVACTemplate_System_DualDuct_MainSupplyFanPartLoadPowerCoefficients)Enum.Parse(typeof(HVACTemplate_System_DualDuct_MainSupplyFanPartLoadPowerCoefficients), "InletVaneDampers");
        

[Description("This field may be set to \"autosize\". If a value is entered, it will *not* be mult" +
    "iplied by any sizing factor or by zone multipliers. If using zone multipliers a " +
    "value entered here must be large enough to serve the multiplied zones.")]
[JsonProperty(PropertyName="cold_duct_supply_fan_maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> ColdDuctSupplyFanMaximumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cold_duct_supply_fan_minimum_flow_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ColdDuctSupplyFanMinimumFlowFraction { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cold_duct_supply_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ColdDuctSupplyFanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cold_duct_supply_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ColdDuctSupplyFanDeltaPressure { get; set; } = Double.Parse("1000", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cold_duct_supply_fan_motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ColdDuctSupplyFanMotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cold_duct_supply_fan_motor_in_air_stream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ColdDuctSupplyFanMotorInAirStreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("This field selects a predefined set of fan power coefficients. The ASHRAE 90.1-20" +
    "04 Appendix G coefficients are from TABLE G3.1.3.15, Method 2. The other sets of" +
    " coefficients are from the EnergyPlus Input Output Reference, Fan Coefficient Va" +
    "lues table.")]
[JsonProperty(PropertyName="cold_duct_supply_fan_part_load_power_coefficients", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DualDuct_ColdDuctSupplyFanPartLoadPowerCoefficients ColdDuctSupplyFanPartLoadPowerCoefficients { get; set; } = (HVACTemplate_System_DualDuct_ColdDuctSupplyFanPartLoadPowerCoefficients)Enum.Parse(typeof(HVACTemplate_System_DualDuct_ColdDuctSupplyFanPartLoadPowerCoefficients), "InletVaneDampers");
        

[JsonProperty(PropertyName="cold_duct_supply_fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DualDuct_ColdDuctSupplyFanPlacement ColdDuctSupplyFanPlacement { get; set; } = (HVACTemplate_System_DualDuct_ColdDuctSupplyFanPlacement)Enum.Parse(typeof(HVACTemplate_System_DualDuct_ColdDuctSupplyFanPlacement), "DrawThrough");
        

[Description("This field may be set to \"autosize\". If a value is entered, it will *not* be mult" +
    "iplied by any sizing factor or by zone multipliers. If using zone multipliers a " +
    "value entered here must be large enough to serve the multiplied zones.")]
[JsonProperty(PropertyName="hot_duct_supply_fan_maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HotDuctSupplyFanMaximumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hot_duct_supply_fan_minimum_flow_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HotDuctSupplyFanMinimumFlowFraction { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hot_duct_supply_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HotDuctSupplyFanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hot_duct_supply_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HotDuctSupplyFanDeltaPressure { get; set; } = Double.Parse("1000", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hot_duct_supply_fan_motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HotDuctSupplyFanMotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hot_duct_supply_fan_motor_in_air_stream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HotDuctSupplyFanMotorInAirStreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("This field selects a predefined set of fan power coefficients. The ASHRAE 90.1-20" +
    "04 Appendix G coefficients are from TABLE G3.1.3.15, Method 2. The other sets of" +
    " coefficients are from the EnergyPlus Input Output Reference, Fan Coefficient Va" +
    "lues table.")]
[JsonProperty(PropertyName="hot_duct_supply_fan_part_load_power_coefficients", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DualDuct_HotDuctSupplyFanPartLoadPowerCoefficients HotDuctSupplyFanPartLoadPowerCoefficients { get; set; } = (HVACTemplate_System_DualDuct_HotDuctSupplyFanPartLoadPowerCoefficients)Enum.Parse(typeof(HVACTemplate_System_DualDuct_HotDuctSupplyFanPartLoadPowerCoefficients), "InletVaneDampers");
        

[JsonProperty(PropertyName="hot_duct_supply_fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DualDuct_HotDuctSupplyFanPlacement HotDuctSupplyFanPlacement { get; set; } = (HVACTemplate_System_DualDuct_HotDuctSupplyFanPlacement)Enum.Parse(typeof(HVACTemplate_System_DualDuct_HotDuctSupplyFanPlacement), "DrawThrough");
        

[JsonProperty(PropertyName="cooling_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DualDuct_CoolingCoilType CoolingCoilType { get; set; } = (HVACTemplate_System_DualDuct_CoolingCoilType)Enum.Parse(typeof(HVACTemplate_System_DualDuct_CoolingCoilType), "ChilledWater");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="cooling_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="cooling_coil_setpoint_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DualDuct_CoolingCoilSetpointControlType CoolingCoilSetpointControlType { get; set; } = (HVACTemplate_System_DualDuct_CoolingCoilSetpointControlType)Enum.Parse(typeof(HVACTemplate_System_DualDuct_CoolingCoilSetpointControlType), "FixedSetpoint");
        

[Description("Used for sizing and as constant setpoint if no Cooling Coil Setpoint Schedule Nam" +
    "e is specified.")]
[JsonProperty(PropertyName="cooling_coil_design_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilDesignSetpointTemperature { get; set; } = Double.Parse("12.8", CultureInfo.InvariantCulture);
        

[Description("Leave blank if constant setpoint")]
[JsonProperty(PropertyName="cooling_coil_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilSetpointScheduleName { get; set; } = "";
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="cooling_coil_setpoint_at_outdoor_dry_bulb_low", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilSetpointAtOutdoorDryBulbLow { get; set; } = Double.Parse("15.6", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control. Defaults are 15.6C (60F) " +
    "at 15.6C (60F) to 12.8C (55F) at 23.3C (74F)")]
[JsonProperty(PropertyName="cooling_coil_reset_outdoor_dry_bulb_low", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilResetOutdoorDryBulbLow { get; set; } = Double.Parse("15.6", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="cooling_coil_setpoint_at_outdoor_dry_bulb_high", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilSetpointAtOutdoorDryBulbHigh { get; set; } = Double.Parse("12.8", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="cooling_coil_reset_outdoor_dry_bulb_high", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilResetOutdoorDryBulbHigh { get; set; } = Double.Parse("23.3", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DualDuct_HeatingCoilType HeatingCoilType { get; set; } = (HVACTemplate_System_DualDuct_HeatingCoilType)Enum.Parse(typeof(HVACTemplate_System_DualDuct_HeatingCoilType), "HotWater");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="heating_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="heating_coil_setpoint_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DualDuct_HeatingCoilSetpointControlType HeatingCoilSetpointControlType { get; set; } = (HVACTemplate_System_DualDuct_HeatingCoilSetpointControlType)Enum.Parse(typeof(HVACTemplate_System_DualDuct_HeatingCoilSetpointControlType), "FixedSetpoint");
        

[Description("Used for sizing and as constant setpoint if no Heating Coil Setpoint Schedule Nam" +
    "e is specified.")]
[JsonProperty(PropertyName="heating_coil_design_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingCoilDesignSetpoint { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[Description("Leave blank if constant setpoint")]
[JsonProperty(PropertyName="heating_coil_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilSetpointScheduleName { get; set; } = "";
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="heating_coil_setpoint_at_outdoor_dry_bulb_low", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingCoilSetpointAtOutdoorDryBulbLow { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control. Defaults are 15.6C (60F) " +
    "at 15.6C (60F) to 12.8C (55F) at 23.3C (74F)")]
[JsonProperty(PropertyName="heating_coil_reset_outdoor_dry_bulb_low", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingCoilResetOutdoorDryBulbLow { get; set; } = Double.Parse("7.8", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="heating_coil_setpoint_at_outdoor_dry_bulb_high", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingCoilSetpointAtOutdoorDryBulbHigh { get; set; } = Double.Parse("20", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="heating_coil_reset_outdoor_dry_bulb_high", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingCoilResetOutdoorDryBulbHigh { get; set; } = Double.Parse("12.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_coil_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingCoilCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="gas_heating_coil_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasHeatingCoilEfficiency { get; set; } = Double.Parse("0.8", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="gas_heating_coil_parasitic_electric_load", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasHeatingCoilParasiticElectricLoad { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="preheat_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DualDuct_PreheatCoilType PreheatCoilType { get; set; } = (HVACTemplate_System_DualDuct_PreheatCoilType)Enum.Parse(typeof(HVACTemplate_System_DualDuct_PreheatCoilType), "None");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="preheat_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PreheatCoilAvailabilityScheduleName { get; set; } = "";
        

[Description("Used for sizing and as constant setpoint if no Preheat Coil Setpoint Schedule Nam" +
    "e specified.")]
[JsonProperty(PropertyName="preheat_coil_design_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PreheatCoilDesignSetpoint { get; set; } = Double.Parse("7.2", CultureInfo.InvariantCulture);
        

[Description("Leave blank if constant setpoint")]
[JsonProperty(PropertyName="preheat_coil_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PreheatCoilSetpointScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="gas_preheat_coil_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasPreheatCoilEfficiency { get; set; } = Double.Parse("0.8", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="gas_preheat_coil_parasitic_electric_load", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasPreheatCoilParasiticElectricLoad { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MinimumOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_outdoor_air_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DualDuct_MinimumOutdoorAirControlType MinimumOutdoorAirControlType { get; set; } = (HVACTemplate_System_DualDuct_MinimumOutdoorAirControlType)Enum.Parse(typeof(HVACTemplate_System_DualDuct_MinimumOutdoorAirControlType), "ProportionalMinimum");
        

[Description("Schedule values multiply the Minimum Outdoor Air Flow Rate If blank, multiplier i" +
    "s always one")]
[JsonProperty(PropertyName="minimum_outdoor_air_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumOutdoorAirScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="economizer_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DualDuct_EconomizerType EconomizerType { get; set; } = (HVACTemplate_System_DualDuct_EconomizerType)Enum.Parse(typeof(HVACTemplate_System_DualDuct_EconomizerType), "NoEconomizer");
        

[JsonProperty(PropertyName="economizer_lockout", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DualDuct_EconomizerLockout EconomizerLockout { get; set; } = (HVACTemplate_System_DualDuct_EconomizerLockout)Enum.Parse(typeof(HVACTemplate_System_DualDuct_EconomizerLockout), "NoLockout");
        

[Description("Outdoor temperature above which economizer is disabled and heat recovery is enabl" +
    "ed (if available). Blank means no limit.")]
[JsonProperty(PropertyName="economizer_upper_temperature_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerUpperTemperatureLimit { get; set; } = null;
        

[Description("Outdoor temperature below which economizer is disabled and heat recovery is enabl" +
    "ed (if available). Blank means no limit.")]
[JsonProperty(PropertyName="economizer_lower_temperature_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerLowerTemperatureLimit { get; set; } = null;
        

[Description("Outdoor enthalpy above which economizer is disabled and heat recovery is enabled " +
    "(if available). Blank means no limit.")]
[JsonProperty(PropertyName="economizer_upper_enthalpy_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerUpperEnthalpyLimit { get; set; } = null;
        

[Description("Enter the maximum outdoor dewpoint temperature limit for FixedDewPointAndDryBulb " +
    "economizer control type. No input or blank input means this limit is not operati" +
    "ve. Limit is applied regardless of economizer control type.")]
[JsonProperty(PropertyName="economizer_maximum_limit_dewpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EconomizerMaximumLimitDewpointTemperature { get; set; } = null;
        

[Description("Plenum zone name. Supply plenum serves the cold inlets of all zones on this syste" +
    "m. Blank if none.")]
[JsonProperty(PropertyName="cold_supply_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ColdSupplyPlenumName { get; set; } = "";
        

[Description("Plenum zone name. Supply plenum serves the hot inlets of all zones on this system" +
    ". Blank if none.")]
[JsonProperty(PropertyName="hot_supply_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HotSupplyPlenumName { get; set; } = "";
        

[Description("Plenum zone name. Supply plenum serves all zones on this system. Blank if none.")]
[JsonProperty(PropertyName="return_plenum_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReturnPlenumName { get; set; } = "";
        

[JsonProperty(PropertyName="night_cycle_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DualDuct_NightCycleControl NightCycleControl { get; set; } = (HVACTemplate_System_DualDuct_NightCycleControl)Enum.Parse(typeof(HVACTemplate_System_DualDuct_NightCycleControl), "StayOff");
        

[Description("Applicable only if Night Cycle Control is Cycle On Control Zone.")]
[JsonProperty(PropertyName="night_cycle_control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NightCycleControlZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="heat_recovery_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DualDuct_HeatRecoveryType HeatRecoveryType { get; set; } = (HVACTemplate_System_DualDuct_HeatRecoveryType)Enum.Parse(typeof(HVACTemplate_System_DualDuct_HeatRecoveryType), "None");
        

[JsonProperty(PropertyName="sensible_heat_recovery_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SensibleHeatRecoveryEffectiveness { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="latent_heat_recovery_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LatentHeatRecoveryEffectiveness { get; set; } = Double.Parse("0.65", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heat_recovery_heat_exchanger_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DualDuct_HeatRecoveryHeatExchangerType HeatRecoveryHeatExchangerType { get; set; } = (HVACTemplate_System_DualDuct_HeatRecoveryHeatExchangerType)Enum.Parse(typeof(HVACTemplate_System_DualDuct_HeatRecoveryHeatExchangerType), "Plate");
        

[JsonProperty(PropertyName="heat_recovery_frost_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DualDuct_HeatRecoveryFrostControlType HeatRecoveryFrostControlType { get; set; } = (HVACTemplate_System_DualDuct_HeatRecoveryFrostControlType)Enum.Parse(typeof(HVACTemplate_System_DualDuct_HeatRecoveryFrostControlType), "None");
        

[Description("None = meet sensible load only CoolReheat = cool beyond the dry-bulb setpoint as " +
    "required to meet the humidity setpoint.")]
[JsonProperty(PropertyName="dehumidification_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DualDuct_DehumidificationControlType DehumidificationControlType { get; set; } = (HVACTemplate_System_DualDuct_DehumidificationControlType)Enum.Parse(typeof(HVACTemplate_System_DualDuct_DehumidificationControlType), "None");
        

[Description("Zone name where humidistat is located")]
[JsonProperty(PropertyName="dehumidification_control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DehumidificationControlZoneName { get; set; } = "";
        

[Description("Zone relative humidity setpoint in percent (0 to 100) Ignored if Dehumidification" +
    " Relative Humidity Setpoint Schedule specified below")]
[JsonProperty(PropertyName="dehumidification_relative_humidity_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DehumidificationRelativeHumiditySetpoint { get; set; } = Double.Parse("60", CultureInfo.InvariantCulture);
        

[Description("Leave blank to use constant setpoint specified in Dehumidification Relative Humid" +
    "ity Setpoint above. Schedule values must be in percent relative humidity (0 to 1" +
    "00).")]
[JsonProperty(PropertyName="dehumidification_relative_humidity_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DehumidificationRelativeHumiditySetpointScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="humidifier_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DualDuct_HumidifierType HumidifierType { get; set; } = (HVACTemplate_System_DualDuct_HumidifierType)Enum.Parse(typeof(HVACTemplate_System_DualDuct_HumidifierType), "None");
        

[Description("If blank, always available")]
[JsonProperty(PropertyName="humidifier_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HumidifierAvailabilityScheduleName { get; set; } = "";
        

[Description("Moisture output rate at full rated power input. The humidifier does not currently" +
    " autosize, so the default is very large to allow for adequate capacity.")]
[JsonProperty(PropertyName="humidifier_rated_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidifierRatedCapacity { get; set; } = Double.Parse("1E-06", CultureInfo.InvariantCulture);
        

[Description("Electric power input at rated capacity moisture output. Power consumption is prop" +
    "ortional to moisture output with no part-load penalty.")]
[JsonProperty(PropertyName="humidifier_rated_electric_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HumidifierRatedElectricPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Zone name where humidistat is located")]
[JsonProperty(PropertyName="humidifier_control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HumidifierControlZoneName { get; set; } = "";
        

[Description("Zone relative humidity setpoint in percent (0 to 100). Ignored if Humidifier Rela" +
    "tive Humidity Setpoint Schedule specified below")]
[JsonProperty(PropertyName="humidifier_relative_humidity_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidifierRelativeHumiditySetpoint { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
        

[Description("Leave blank to use constant setpoint specified in Humidifier Relative Humidity Se" +
    "tpoint above. Schedule values must be in percent relative humidity (0 to 100).")]
[JsonProperty(PropertyName="humidifier_relative_humidity_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HumidifierRelativeHumiditySetpointScheduleName { get; set; } = "";
        

[Description("Select whether autosized system supply flow rate is the sum of Coincident or NonC" +
    "oincident zone air flow rates.")]
[JsonProperty(PropertyName="sizing_option", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DualDuct_SizingOption SizingOption { get; set; } = (HVACTemplate_System_DualDuct_SizingOption)Enum.Parse(typeof(HVACTemplate_System_DualDuct_SizingOption), "NonCoincident");
        

[Description("Specifies if the system has a return fan.")]
[JsonProperty(PropertyName="return_fan", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes ReturnFan { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[JsonProperty(PropertyName="return_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="return_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanDeltaPressure { get; set; } = Double.Parse("500", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="return_fan_motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanMotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="return_fan_motor_in_air_stream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnFanMotorInAirStreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("This field selects a predefined set of fan power coefficients. The ASHRAE 90.1-20" +
    "04 Appendix G coefficients are from TABLE G3.1.3.15, Method 2. The other sets of" +
    " coefficients are from the EnergyPlus Input Output Reference, Fan Coefficient Va" +
    "lues table.")]
[JsonProperty(PropertyName="return_fan_part_load_power_coefficients", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DualDuct_ReturnFanPartLoadPowerCoefficients ReturnFanPartLoadPowerCoefficients { get; set; } = (HVACTemplate_System_DualDuct_ReturnFanPartLoadPowerCoefficients)Enum.Parse(typeof(HVACTemplate_System_DualDuct_ReturnFanPartLoadPowerCoefficients), "InletVaneDampers");
    }
    
    public enum HVACTemplate_System_DualDuct_SystemConfigurationType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DualFanConstantVolume")]
        DualFanConstantVolume = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DualFanVariableVolume")]
        DualFanVariableVolume = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="SingleFanConstantVolume")]
        SingleFanConstantVolume = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="SingleFanVariableVolume")]
        SingleFanVariableVolume = 4,
    }
    
    public enum HVACTemplate_System_DualDuct_MainSupplyFanPartLoadPowerCoefficients
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAE90.1-2004AppendixG")]
        ASHRAE9012004AppendixG = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="InletVaneDampers")]
        InletVaneDampers = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="OutletDampers")]
        OutletDampers = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableSpeedMotor")]
        VariableSpeedMotor = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableSpeedMotorPressureReset")]
        VariableSpeedMotorPressureReset = 5,
    }
    
    public enum HVACTemplate_System_DualDuct_ColdDuctSupplyFanPartLoadPowerCoefficients
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAE90.1-2004AppendixG")]
        ASHRAE9012004AppendixG = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="InletVaneDampers")]
        InletVaneDampers = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="OutletDampers")]
        OutletDampers = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableSpeedMotor")]
        VariableSpeedMotor = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableSpeedMotorPressureReset")]
        VariableSpeedMotorPressureReset = 5,
    }
    
    public enum HVACTemplate_System_DualDuct_ColdDuctSupplyFanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum HVACTemplate_System_DualDuct_HotDuctSupplyFanPartLoadPowerCoefficients
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAE90.1-2004AppendixG")]
        ASHRAE9012004AppendixG = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="InletVaneDampers")]
        InletVaneDampers = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="OutletDampers")]
        OutletDampers = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableSpeedMotor")]
        VariableSpeedMotor = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableSpeedMotorPressureReset")]
        VariableSpeedMotorPressureReset = 5,
    }
    
    public enum HVACTemplate_System_DualDuct_HotDuctSupplyFanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum HVACTemplate_System_DualDuct_CoolingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ChilledWater")]
        ChilledWater = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ChilledWaterDetailedFlatModel")]
        ChilledWaterDetailedFlatModel = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    public enum HVACTemplate_System_DualDuct_CoolingCoilSetpointControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedSetpoint")]
        FixedSetpoint = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAirTemperatureReset")]
        OutdoorAirTemperatureReset = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Scheduled")]
        Scheduled = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Warmest")]
        Warmest = 4,
    }
    
    public enum HVACTemplate_System_DualDuct_HeatingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Gas")]
        Gas = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum HVACTemplate_System_DualDuct_HeatingCoilSetpointControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coldest")]
        Coldest = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedSetpoint")]
        FixedSetpoint = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAirTemperatureReset")]
        OutdoorAirTemperatureReset = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Scheduled")]
        Scheduled = 4,
    }
    
    public enum HVACTemplate_System_DualDuct_PreheatCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Gas")]
        Gas = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum HVACTemplate_System_DualDuct_MinimumOutdoorAirControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedMinimum")]
        FixedMinimum = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ProportionalMinimum")]
        ProportionalMinimum = 2,
    }
    
    public enum HVACTemplate_System_DualDuct_EconomizerType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferentialDryBulb")]
        DifferentialDryBulb = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferentialDryBulbAndEnthalpy")]
        DifferentialDryBulbAndEnthalpy = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DifferentialEnthalpy")]
        DifferentialEnthalpy = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectronicEnthalpy")]
        ElectronicEnthalpy = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedDewPointAndDryBulb")]
        FixedDewPointAndDryBulb = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedDryBulb")]
        FixedDryBulb = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedEnthalpy")]
        FixedEnthalpy = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="NoEconomizer")]
        NoEconomizer = 8,
    }
    
    public enum HVACTemplate_System_DualDuct_EconomizerLockout
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="NoLockout")]
        NoLockout = 1,
    }
    
    public enum HVACTemplate_System_DualDuct_NightCycleControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CycleOnAny")]
        CycleOnAny = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CycleOnControlZone")]
        CycleOnControlZone = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="StayOff")]
        StayOff = 3,
    }
    
    public enum HVACTemplate_System_DualDuct_HeatRecoveryType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Enthalpy")]
        Enthalpy = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Sensible")]
        Sensible = 3,
    }
    
    public enum HVACTemplate_System_DualDuct_HeatRecoveryHeatExchangerType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Plate")]
        Plate = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Rotary")]
        Rotary = 2,
    }
    
    public enum HVACTemplate_System_DualDuct_HeatRecoveryFrostControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ExhaustAirRecirculation")]
        ExhaustAirRecirculation = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ExhaustOnly")]
        ExhaustOnly = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MinimumExhaustTemperature")]
        MinimumExhaustTemperature = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum HVACTemplate_System_DualDuct_DehumidificationControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolReheat")]
        CoolReheat = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
    }
    
    public enum HVACTemplate_System_DualDuct_HumidifierType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectricSteam")]
        ElectricSteam = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
    }
    
    public enum HVACTemplate_System_DualDuct_SizingOption
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coincident")]
        Coincident = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="NonCoincident")]
        NonCoincident = 2,
    }
    
    public enum HVACTemplate_System_DualDuct_ReturnFanPartLoadPowerCoefficients
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAE90.1-2004AppendixG")]
        ASHRAE9012004AppendixG = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="InletVaneDampers")]
        InletVaneDampers = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="OutletDampers")]
        OutletDampers = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableSpeedMotor")]
        VariableSpeedMotor = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableSpeedMotorPressureReset")]
        VariableSpeedMotorPressureReset = 5,
    }
    
    [Description("This object creates a dedicated outdoor air system that must be used with HVACTem" +
        "plate:Zone:* objects for BaseboardHeat FanCoil PTAC PTHP WaterToAirHeatPump and " +
        "VRF. Does not support HVACTemplate:Zone:VAV or other central multizone systems")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_System_DedicatedOutdoorAir
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("If blank, always on; DOAS System always on. Schedule is used in availability mana" +
    "ger and fan scheduling.")]
[JsonProperty(PropertyName="system_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SystemAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="air_outlet_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DedicatedOutdoorAir_AirOutletType AirOutletType { get; set; } = (HVACTemplate_System_DedicatedOutdoorAir_AirOutletType)Enum.Parse(typeof(HVACTemplate_System_DedicatedOutdoorAir_AirOutletType), "DirectIntoZone");
        

[JsonProperty(PropertyName="supply_fan_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SupplyFanFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanDeltaPressure { get; set; } = Double.Parse("1000", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanMotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_motor_in_air_stream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyFanMotorInAirStreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DedicatedOutdoorAir_SupplyFanPlacement SupplyFanPlacement { get; set; } = (HVACTemplate_System_DedicatedOutdoorAir_SupplyFanPlacement)Enum.Parse(typeof(HVACTemplate_System_DedicatedOutdoorAir_SupplyFanPlacement), "DrawThrough");
        

[JsonProperty(PropertyName="cooling_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DedicatedOutdoorAir_CoolingCoilType CoolingCoilType { get; set; } = (HVACTemplate_System_DedicatedOutdoorAir_CoolingCoilType)Enum.Parse(typeof(HVACTemplate_System_DedicatedOutdoorAir_CoolingCoilType), "ChilledWater");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="cooling_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="cooling_coil_setpoint_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DedicatedOutdoorAir_CoolingCoilSetpointControlType CoolingCoilSetpointControlType { get; set; } = (HVACTemplate_System_DedicatedOutdoorAir_CoolingCoilSetpointControlType)Enum.Parse(typeof(HVACTemplate_System_DedicatedOutdoorAir_CoolingCoilSetpointControlType), "FixedSetpoint");
        

[Description("Used for sizing and as constant setpoint if no Cooling Coil Setpoint Schedule Nam" +
    "e is specified.")]
[JsonProperty(PropertyName="cooling_coil_design_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilDesignSetpoint { get; set; } = Double.Parse("12.8", CultureInfo.InvariantCulture);
        

[Description("Leave blank if constant setpoint")]
[JsonProperty(PropertyName="cooling_coil_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilSetpointScheduleName { get; set; } = "";
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="cooling_coil_setpoint_at_outdoor_dry_bulb_low", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilSetpointAtOutdoorDryBulbLow { get; set; } = Double.Parse("15.6", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control. Defaults are 15.6C (60F) " +
    "at 15.6C (60F) to 12.8C (55F) at 23.3C (74F)")]
[JsonProperty(PropertyName="cooling_coil_reset_outdoor_dry_bulb_low", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilResetOutdoorDryBulbLow { get; set; } = Double.Parse("15.6", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="cooling_coil_setpoint_at_outdoor_dry_bulb_high", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilSetpointAtOutdoorDryBulbHigh { get; set; } = Double.Parse("12.8", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="cooling_coil_reset_outdoor_dry_bulb_high", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingCoilResetOutdoorDryBulbHigh { get; set; } = Double.Parse("23.3", CultureInfo.InvariantCulture);
        

[Description("Total cooling capacity not accounting for the effect of supply air fan heat")]
[JsonProperty(PropertyName="dx_cooling_coil_gross_rated_total_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DxCoolingCoilGrossRatedTotalCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Gross SHR")]
[JsonProperty(PropertyName="dx_cooling_coil_gross_rated_sensible_heat_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DxCoolingCoilGrossRatedSensibleHeatRatio { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Gross cooling capacity divided by power input to the compressor and outdoor fan, " +
    "does not include supply fan heat or supply fan electrical energy input")]
[JsonProperty(PropertyName="dx_cooling_coil_gross_rated_cop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DxCoolingCoilGrossRatedCop { get; set; } = Double.Parse("3", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_coil_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DedicatedOutdoorAir_HeatingCoilType HeatingCoilType { get; set; } = (HVACTemplate_System_DedicatedOutdoorAir_HeatingCoilType)Enum.Parse(typeof(HVACTemplate_System_DedicatedOutdoorAir_HeatingCoilType), "HotWater");
        

[Description("If blank, always on")]
[JsonProperty(PropertyName="heating_coil_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilAvailabilityScheduleName { get; set; } = "";
        

[Description("When selecting OutdoorAirTemperatureReset, the Heating Coil Design Setpoint may n" +
    "eed to be changed")]
[JsonProperty(PropertyName="heating_coil_setpoint_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DedicatedOutdoorAir_HeatingCoilSetpointControlType HeatingCoilSetpointControlType { get; set; } = (HVACTemplate_System_DedicatedOutdoorAir_HeatingCoilSetpointControlType)Enum.Parse(typeof(HVACTemplate_System_DedicatedOutdoorAir_HeatingCoilSetpointControlType), "FixedSetpoint");
        

[Description("Used for sizing and as constant setpoint if no Heating Coil Setpoint Schedule Nam" +
    "e is specified.")]
[JsonProperty(PropertyName="heating_coil_design_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingCoilDesignSetpoint { get; set; } = Double.Parse("12.2", CultureInfo.InvariantCulture);
        

[Description("Leave blank if constant setpoint")]
[JsonProperty(PropertyName="heating_coil_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilSetpointScheduleName { get; set; } = "";
        

[Description("Applicable only for OutdoorAirTemperatureReset control. Defaults 15.0C (59F) at 7" +
    ".8C (46F) to 12.2C (54F) at 12.2C (54F)")]
[JsonProperty(PropertyName="heating_coil_setpoint_at_outdoor_dry_bulb_low", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingCoilSetpointAtOutdoorDryBulbLow { get; set; } = Double.Parse("15", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="heating_coil_reset_outdoor_dry_bulb_low", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingCoilResetOutdoorDryBulbLow { get; set; } = Double.Parse("7.8", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="heating_coil_setpoint_at_outdoor_dry_bulb_high", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingCoilSetpointAtOutdoorDryBulbHigh { get; set; } = Double.Parse("12.2", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="heating_coil_reset_outdoor_dry_bulb_high", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingCoilResetOutdoorDryBulbHigh { get; set; } = Double.Parse("12.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="gas_heating_coil_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasHeatingCoilEfficiency { get; set; } = Double.Parse("0.8", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="gas_heating_coil_parasitic_electric_load", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasHeatingCoilParasiticElectricLoad { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heat_recovery_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DedicatedOutdoorAir_HeatRecoveryType HeatRecoveryType { get; set; } = (HVACTemplate_System_DedicatedOutdoorAir_HeatRecoveryType)Enum.Parse(typeof(HVACTemplate_System_DedicatedOutdoorAir_HeatRecoveryType), "None");
        

[JsonProperty(PropertyName="heat_recovery_sensible_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatRecoverySensibleEffectiveness { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heat_recovery_latent_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatRecoveryLatentEffectiveness { get; set; } = Double.Parse("0.65", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heat_recovery_heat_exchanger_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DedicatedOutdoorAir_HeatRecoveryHeatExchangerType HeatRecoveryHeatExchangerType { get; set; } = (HVACTemplate_System_DedicatedOutdoorAir_HeatRecoveryHeatExchangerType)Enum.Parse(typeof(HVACTemplate_System_DedicatedOutdoorAir_HeatRecoveryHeatExchangerType), "Plate");
        

[JsonProperty(PropertyName="heat_recovery_frost_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DedicatedOutdoorAir_HeatRecoveryFrostControlType HeatRecoveryFrostControlType { get; set; } = (HVACTemplate_System_DedicatedOutdoorAir_HeatRecoveryFrostControlType)Enum.Parse(typeof(HVACTemplate_System_DedicatedOutdoorAir_HeatRecoveryFrostControlType), "None");
        

[Description(@"None = meet sensible load only CoolReheatHeatingCoil = cool beyond the dry-bulb setpoint, reheat with heating coil Valid for all cooling coil types. If no heating coil specified, cold supply temps may occur. CoolReheatDesuperheater = cool beyond the dry-bulb setpoint as required to meet the humidity setpoint, reheat with desuperheater coil. Valid only for Cooling Coil Type = TwoSpeedDX, TwoStageDX, TwoStageHumidityControlDX, or HeatExchangerAssistedDX. Multimode = activate enhanced dehumidification mode as needed and meet sensible load. Valid only for Cooling Coil Type = TwoStageHumidityControlDX or HeatExchangerAssistedDX")]
[JsonProperty(PropertyName="dehumidification_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DedicatedOutdoorAir_DehumidificationControlType DehumidificationControlType { get; set; } = (HVACTemplate_System_DedicatedOutdoorAir_DehumidificationControlType)Enum.Parse(typeof(HVACTemplate_System_DedicatedOutdoorAir_DehumidificationControlType), "None");
        

[Description("The supply air humidity ratio for dehumidification control. Default of 0.00924 kg" +
    "Water/kgDryAir is equivalent to 12.8C (55F) dewpoint. Ignored if Dehumidificatio" +
    "n Setpoint Schedule specified below")]
[JsonProperty(PropertyName="dehumidification_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DehumidificationSetpoint { get; set; } = Double.Parse("0.00924", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="humidifier_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_System_DedicatedOutdoorAir_HumidifierType HumidifierType { get; set; } = (HVACTemplate_System_DedicatedOutdoorAir_HumidifierType)Enum.Parse(typeof(HVACTemplate_System_DedicatedOutdoorAir_HumidifierType), "None");
        

[Description("If blank, always available")]
[JsonProperty(PropertyName="humidifier_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HumidifierAvailabilityScheduleName { get; set; } = "";
        

[Description("Moisture output rate at full rated power input. The humidifier does not currently" +
    " autosize, so the default is very large to allow for adequate capacity.")]
[JsonProperty(PropertyName="humidifier_rated_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidifierRatedCapacity { get; set; } = Double.Parse("1E-06", CultureInfo.InvariantCulture);
        

[Description("Electric power input at rated capacity moisture output. Power consumption is prop" +
    "ortional to moisture output with no part-load penalty.")]
[JsonProperty(PropertyName="humidifier_rated_electric_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HumidifierRatedElectricPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("The supply air humidity ratio for humidification control. Ignored if Humidifier S" +
    "etpoint Schedule specified below")]
[JsonProperty(PropertyName="humidifier_constant_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidifierConstantSetpoint { get; set; } = Double.Parse("0.003", CultureInfo.InvariantCulture);
        

[Description("Leave blank to use constant setpoint specified in Dehumidification Setpoint above" +
    ". Schedule values must be in units of humidity ratio (kgWater/kgDryAir or lbWate" +
    "r/lbDryAir)")]
[JsonProperty(PropertyName="dehumidification_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DehumidificationSetpointScheduleName { get; set; } = "";
        

[Description("Leave blank to use constant setpoint specified in Humidifier Constant Setpoint ab" +
    "ove. Schedule values must be in units of humidity ratio (kgWater/kgDryAir or lbW" +
    "ater/lbDryAir)")]
[JsonProperty(PropertyName="humidifier_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HumidifierSetpointScheduleName { get; set; } = "";
    }
    
    public enum HVACTemplate_System_DedicatedOutdoorAir_AirOutletType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DirectIntoZone")]
        DirectIntoZone = 1,
    }
    
    public enum HVACTemplate_System_DedicatedOutdoorAir_SupplyFanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum HVACTemplate_System_DedicatedOutdoorAir_CoolingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ChilledWater")]
        ChilledWater = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ChilledWaterDetailedFlatModel")]
        ChilledWaterDetailedFlatModel = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchangerAssistedChilledWater")]
        HeatExchangerAssistedChilledWater = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchangerAssistedDX")]
        HeatExchangerAssistedDX = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="TwoSpeedDX")]
        TwoSpeedDX = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="TwoStageDX")]
        TwoStageDX = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="TwoStageHumidityControlDX")]
        TwoStageHumidityControlDX = 8,
    }
    
    public enum HVACTemplate_System_DedicatedOutdoorAir_CoolingCoilSetpointControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedSetpoint")]
        FixedSetpoint = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAirTemperatureReset")]
        OutdoorAirTemperatureReset = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Scheduled")]
        Scheduled = 3,
    }
    
    public enum HVACTemplate_System_DedicatedOutdoorAir_HeatingCoilType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Gas")]
        Gas = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum HVACTemplate_System_DedicatedOutdoorAir_HeatingCoilSetpointControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedSetpoint")]
        FixedSetpoint = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAirTemperatureReset")]
        OutdoorAirTemperatureReset = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Scheduled")]
        Scheduled = 3,
    }
    
    public enum HVACTemplate_System_DedicatedOutdoorAir_HeatRecoveryType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Enthalpy")]
        Enthalpy = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Sensible")]
        Sensible = 3,
    }
    
    public enum HVACTemplate_System_DedicatedOutdoorAir_HeatRecoveryHeatExchangerType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Plate")]
        Plate = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Rotary")]
        Rotary = 2,
    }
    
    public enum HVACTemplate_System_DedicatedOutdoorAir_HeatRecoveryFrostControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ExhaustAirRecirculation")]
        ExhaustAirRecirculation = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ExhaustOnly")]
        ExhaustOnly = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MinimumExhaustTemperature")]
        MinimumExhaustTemperature = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum HVACTemplate_System_DedicatedOutdoorAir_DehumidificationControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolReheatDesuperheater")]
        CoolReheatDesuperheater = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolReheatHeatingCoil")]
        CoolReheatHeatingCoil = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Multimode")]
        Multimode = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum HVACTemplate_System_DedicatedOutdoorAir_HumidifierType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectricSteam")]
        ElectricSteam = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
    }
    
    [Description("Plant and condenser loops to serve all HVACTemplate chilled water coils, chillers" +
        ", and towers.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_Plant_ChilledWaterLoop
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("If blank, always available Applies to both chilled water and condenser loop pumps" +
    "")]
[JsonProperty(PropertyName="pump_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PumpScheduleName { get; set; } = "";
        

[Description("Applies to both chilled water and condenser loop pumps")]
[JsonProperty(PropertyName="pump_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_ChilledWaterLoop_PumpControlType PumpControlType { get; set; } = (HVACTemplate_Plant_ChilledWaterLoop_PumpControlType)Enum.Parse(typeof(HVACTemplate_Plant_ChilledWaterLoop_PumpControlType), "Intermittent");
        

[Description("Default operation type makes all equipment available at all times operating in or" +
    "der of Priority specified in HVACTemplate:Plant:Chiller objects.")]
[JsonProperty(PropertyName="chiller_plant_operation_scheme_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_ChilledWaterLoop_ChillerPlantOperationSchemeType ChillerPlantOperationSchemeType { get; set; } = (HVACTemplate_Plant_ChilledWaterLoop_ChillerPlantOperationSchemeType)Enum.Parse(typeof(HVACTemplate_Plant_ChilledWaterLoop_ChillerPlantOperationSchemeType), "Default");
        

[Description("Name of a PlantEquipmentOperationSchemes object Ignored if Chiller Plant Operatio" +
    "n Scheme Type = Default")]
[JsonProperty(PropertyName="chiller_plant_equipment_operation_schemes_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ChillerPlantEquipmentOperationSchemesName { get; set; } = "";
        

[Description("Leave blank if constant setpoint")]
[JsonProperty(PropertyName="chilled_water_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ChilledWaterSetpointScheduleName { get; set; } = "";
        

[Description("Used for sizing and as constant setpoint if no Chilled Water Setpoint Schedule Na" +
    "me is specified.")]
[JsonProperty(PropertyName="chilled_water_design_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ChilledWaterDesignSetpoint { get; set; } = Double.Parse("7.22", CultureInfo.InvariantCulture);
        

[Description(@"VariablePrimaryNoSecondary - variable flow to chillers and coils ConstantPrimaryNoSecondary - constant flow to chillers and coils, excess bypassed ConstantPrimaryVariableSecondary - constant flow to chillers, variable flow to coils VariablePrimaryConstantSecondary - currently unsupported - variable flow to chillers, constant flow to coils")]
[JsonProperty(PropertyName="chilled_water_pump_configuration", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_ChilledWaterLoop_ChilledWaterPumpConfiguration ChilledWaterPumpConfiguration { get; set; } = (HVACTemplate_Plant_ChilledWaterLoop_ChilledWaterPumpConfiguration)Enum.Parse(typeof(HVACTemplate_Plant_ChilledWaterLoop_ChilledWaterPumpConfiguration), "ConstantPrimaryNoSecondary");
        

[Description("default head is 60 feet H2O")]
[JsonProperty(PropertyName="primary_chilled_water_pump_rated_head", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PrimaryChilledWaterPumpRatedHead { get; set; } = Double.Parse("179352", CultureInfo.InvariantCulture);
        

[Description("default head is 60 feet H2O")]
[JsonProperty(PropertyName="secondary_chilled_water_pump_rated_head", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SecondaryChilledWaterPumpRatedHead { get; set; } = Double.Parse("179352", CultureInfo.InvariantCulture);
        

[Description("Default operation type makes all equipment available at all times operating in or" +
    "der of Priority specified in HVACTemplate:Plant:Tower objects. May be left blank" +
    " if not serving any water cooled chillers")]
[JsonProperty(PropertyName="condenser_plant_operation_scheme_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_ChilledWaterLoop_CondenserPlantOperationSchemeType CondenserPlantOperationSchemeType { get; set; } = (HVACTemplate_Plant_ChilledWaterLoop_CondenserPlantOperationSchemeType)Enum.Parse(typeof(HVACTemplate_Plant_ChilledWaterLoop_CondenserPlantOperationSchemeType), "Default");
        

[Description("Name of a CondenserEquipmentOperationSchemes object Ignored if Condenser Plant Op" +
    "eration Scheme Type = Default May be left blank if not serving any water cooled " +
    "chillers")]
[JsonProperty(PropertyName="condenser_equipment_operation_schemes_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CondenserEquipmentOperationSchemesName { get; set; } = "";
        

[Description("May be left blank if not serving any water cooled chillers")]
[JsonProperty(PropertyName="condenser_water_temperature_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_ChilledWaterLoop_CondenserWaterTemperatureControlType CondenserWaterTemperatureControlType { get; set; } = (HVACTemplate_Plant_ChilledWaterLoop_CondenserWaterTemperatureControlType)Enum.Parse(typeof(HVACTemplate_Plant_ChilledWaterLoop_CondenserWaterTemperatureControlType), "OutdoorWetBulbTemperature");
        

[Description("Leave blank if constant setpoint May be left blank if not serving any water coole" +
    "d chillers")]
[JsonProperty(PropertyName="condenser_water_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CondenserWaterSetpointScheduleName { get; set; } = "";
        

[Description("Used for sizing and as constant setpoint if no Condenser Water Setpoint Schedule " +
    "Name is specified. May be left blank if not serving any water cooled chillers")]
[JsonProperty(PropertyName="condenser_water_design_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CondenserWaterDesignSetpoint { get; set; } = Double.Parse("29.4", CultureInfo.InvariantCulture);
        

[Description("May be left blank if not serving any water cooled chillers default head is 60 fee" +
    "t H2O")]
[JsonProperty(PropertyName="condenser_water_pump_rated_head", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CondenserWaterPumpRatedHead { get; set; } = Double.Parse("179352", CultureInfo.InvariantCulture);
        

[Description("Overrides Chilled Water Setpoint Schedule Name")]
[JsonProperty(PropertyName="chilled_water_setpoint_reset_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_ChilledWaterLoop_ChilledWaterSetpointResetType ChilledWaterSetpointResetType { get; set; } = (HVACTemplate_Plant_ChilledWaterLoop_ChilledWaterSetpointResetType)Enum.Parse(typeof(HVACTemplate_Plant_ChilledWaterLoop_ChilledWaterSetpointResetType), "None");
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="chilled_water_setpoint_at_outdoor_dry_bulb_low", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ChilledWaterSetpointAtOutdoorDryBulbLow { get; set; } = Double.Parse("12.2", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="chilled_water_reset_outdoor_dry_bulb_low", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ChilledWaterResetOutdoorDryBulbLow { get; set; } = Double.Parse("15.6", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="chilled_water_setpoint_at_outdoor_dry_bulb_high", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ChilledWaterSetpointAtOutdoorDryBulbHigh { get; set; } = Double.Parse("6.7", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="chilled_water_reset_outdoor_dry_bulb_high", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ChilledWaterResetOutdoorDryBulbHigh { get; set; } = Double.Parse("26.7", CultureInfo.InvariantCulture);
        

[Description("Describes the type of pump configuration used for the primary portion of the chil" +
    "led water loop.")]
[JsonProperty(PropertyName="chilled_water_primary_pump_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_ChilledWaterLoop_ChilledWaterPrimaryPumpType ChilledWaterPrimaryPumpType { get; set; } = (HVACTemplate_Plant_ChilledWaterLoop_ChilledWaterPrimaryPumpType)Enum.Parse(typeof(HVACTemplate_Plant_ChilledWaterLoop_ChilledWaterPrimaryPumpType), "SinglePump");
        

[Description("Describes the type of pump configuration used for the secondary portion of the ch" +
    "illed water loop.")]
[JsonProperty(PropertyName="chilled_water_secondary_pump_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_ChilledWaterLoop_ChilledWaterSecondaryPumpType ChilledWaterSecondaryPumpType { get; set; } = (HVACTemplate_Plant_ChilledWaterLoop_ChilledWaterSecondaryPumpType)Enum.Parse(typeof(HVACTemplate_Plant_ChilledWaterLoop_ChilledWaterSecondaryPumpType), "SinglePump");
        

[Description("Describes the type of pump configuration used for the condenser water loop.")]
[JsonProperty(PropertyName="condenser_water_pump_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_ChilledWaterLoop_CondenserWaterPumpType CondenserWaterPumpType { get; set; } = (HVACTemplate_Plant_ChilledWaterLoop_CondenserWaterPumpType)Enum.Parse(typeof(HVACTemplate_Plant_ChilledWaterLoop_CondenserWaterPumpType), "SinglePump");
        

[Description("Determines if a supply side bypass pipe is present in the chilled water loop.")]
[JsonProperty(PropertyName="chilled_water_supply_side_bypass_pipe", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes ChilledWaterSupplySideBypassPipe { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[Description("Determines if a demand side bypass pipe is present in the chilled water loop.")]
[JsonProperty(PropertyName="chilled_water_demand_side_bypass_pipe", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes ChilledWaterDemandSideBypassPipe { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[Description("Determines if a supply side bypass pipe is present in the condenser water loop.")]
[JsonProperty(PropertyName="condenser_water_supply_side_bypass_pipe", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes CondenserWaterSupplySideBypassPipe { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[Description("Determines if a demand side bypass pipe is present in the condenser water loop.")]
[JsonProperty(PropertyName="condenser_water_demand_side_bypass_pipe", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes CondenserWaterDemandSideBypassPipe { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="fluid_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_ChilledWaterLoop_FluidType FluidType { get; set; } = (HVACTemplate_Plant_ChilledWaterLoop_FluidType)Enum.Parse(typeof(HVACTemplate_Plant_ChilledWaterLoop_FluidType), "Water");
        

[Description("The temperature difference used in sizing the loop flow rate.")]
[JsonProperty(PropertyName="loop_design_delta_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoopDesignDeltaTemperature { get; set; } = Double.Parse("6.67", CultureInfo.InvariantCulture);
        

[Description("The minimum outdoor dry-bulb temperature that the chilled water loops operate. Le" +
    "ave blank for no limit.")]
[JsonProperty(PropertyName="minimum_outdoor_dry_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumOutdoorDryBulbTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="chilled_water_load_distribution_scheme", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_ChilledWaterLoop_ChilledWaterLoadDistributionScheme ChilledWaterLoadDistributionScheme { get; set; } = (HVACTemplate_Plant_ChilledWaterLoop_ChilledWaterLoadDistributionScheme)Enum.Parse(typeof(HVACTemplate_Plant_ChilledWaterLoop_ChilledWaterLoadDistributionScheme), "SequentialLoad");
        

[JsonProperty(PropertyName="condenser_water_load_distribution_scheme", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_ChilledWaterLoop_CondenserWaterLoadDistributionScheme CondenserWaterLoadDistributionScheme { get; set; } = (HVACTemplate_Plant_ChilledWaterLoop_CondenserWaterLoadDistributionScheme)Enum.Parse(typeof(HVACTemplate_Plant_ChilledWaterLoop_CondenserWaterLoadDistributionScheme), "SequentialLoad");
    }
    
    public enum HVACTemplate_Plant_ChilledWaterLoop_PumpControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Continuous")]
        Continuous = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Intermittent")]
        Intermittent = 2,
    }
    
    public enum HVACTemplate_Plant_ChilledWaterLoop_ChillerPlantOperationSchemeType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Default")]
        Default = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UserDefined")]
        UserDefined = 2,
    }
    
    public enum HVACTemplate_Plant_ChilledWaterLoop_ChilledWaterPumpConfiguration
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ConstantPrimaryNoSecondary")]
        ConstantPrimaryNoSecondary = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ConstantPrimaryVariableSecondary")]
        ConstantPrimaryVariableSecondary = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="VariablePrimaryNoSecondary")]
        VariablePrimaryNoSecondary = 3,
    }
    
    public enum HVACTemplate_Plant_ChilledWaterLoop_CondenserPlantOperationSchemeType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Default")]
        Default = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UserDefined")]
        UserDefined = 2,
    }
    
    public enum HVACTemplate_Plant_ChilledWaterLoop_CondenserWaterTemperatureControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorWetBulbTemperature")]
        OutdoorWetBulbTemperature = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SpecifiedSetpoint")]
        SpecifiedSetpoint = 1,
    }
    
    public enum HVACTemplate_Plant_ChilledWaterLoop_ChilledWaterSetpointResetType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAirTemperatureReset")]
        OutdoorAirTemperatureReset = 2,
    }
    
    public enum HVACTemplate_Plant_ChilledWaterLoop_ChilledWaterPrimaryPumpType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FiveHeaderedPumps")]
        FiveHeaderedPumps = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FourHeaderedPumps")]
        FourHeaderedPumps = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PumpPerChiller")]
        PumpPerChiller = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="SinglePump")]
        SinglePump = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="ThreeHeaderedPumps")]
        ThreeHeaderedPumps = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="TwoHeaderedPumps")]
        TwoHeaderedPumps = 6,
    }
    
    public enum HVACTemplate_Plant_ChilledWaterLoop_ChilledWaterSecondaryPumpType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FiveHeaderedPumps")]
        FiveHeaderedPumps = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FourHeaderedPumps")]
        FourHeaderedPumps = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="SinglePump")]
        SinglePump = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ThreeHeaderedPumps")]
        ThreeHeaderedPumps = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="TwoHeaderedPumps")]
        TwoHeaderedPumps = 5,
    }
    
    public enum HVACTemplate_Plant_ChilledWaterLoop_CondenserWaterPumpType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FiveHeaderedPumps")]
        FiveHeaderedPumps = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FourHeaderedPumps")]
        FourHeaderedPumps = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PumpPerTower")]
        PumpPerTower = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="SinglePump")]
        SinglePump = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="ThreeHeaderedPumps")]
        ThreeHeaderedPumps = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="TwoHeaderedPumps")]
        TwoHeaderedPumps = 6,
    }
    
    public enum HVACTemplate_Plant_ChilledWaterLoop_FluidType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="EthyleneGlycol30")]
        EthyleneGlycol30 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="EthyleneGlycol40")]
        EthyleneGlycol40 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="EthyleneGlycol50")]
        EthyleneGlycol50 = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="EthyleneGlycol60")]
        EthyleneGlycol60 = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="PropyleneGlycol30")]
        PropyleneGlycol30 = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="PropyleneGlycol40")]
        PropyleneGlycol40 = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="PropyleneGlycol50")]
        PropyleneGlycol50 = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="PropyleneGlycol60")]
        PropyleneGlycol60 = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Water")]
        Water = 9,
    }
    
    public enum HVACTemplate_Plant_ChilledWaterLoop_ChilledWaterLoadDistributionScheme
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Optimal")]
        Optimal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SequentialLoad")]
        SequentialLoad = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="SequentialUniformPLR")]
        SequentialUniformPLR = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="UniformLoad")]
        UniformLoad = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="UniformPLR")]
        UniformPLR = 5,
    }
    
    public enum HVACTemplate_Plant_ChilledWaterLoop_CondenserWaterLoadDistributionScheme
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Optimal")]
        Optimal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SequentialLoad")]
        SequentialLoad = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="SequentialUniformPLR")]
        SequentialUniformPLR = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="UniformLoad")]
        UniformLoad = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="UniformPLR")]
        UniformPLR = 5,
    }
    
    [Description("This object adds a chiller to an HVACTemplate:Plant:ChilledWaterLoop.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_Plant_Chiller
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="chiller_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_Chiller_ChillerType ChillerType { get; set; } = (HVACTemplate_Plant_Chiller_ChillerType)Enum.Parse(typeof(HVACTemplate_Plant_Chiller_ChillerType), "DistrictChilledWater");
        

[JsonProperty(PropertyName="capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> Capacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Not applicable if Chiller Type is DistrictChilledWater Electric Reciprocating Chi" +
    "ller")]
[JsonProperty(PropertyName="nominal_cop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NominalCop { get; set; } = null;
        

[Description("Not applicable if Chiller Type is DistrictChilledWater")]
[JsonProperty(PropertyName="condenser_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_Chiller_CondenserType CondenserType { get; set; } = (HVACTemplate_Plant_Chiller_CondenserType)Enum.Parse(typeof(HVACTemplate_Plant_Chiller_CondenserType), "WaterCooled");
        

[Description("If Chiller Plant Operation Scheme Type=Default in HVACTemplate:Plant:ChilledWater" +
    "Loop, then equipment operates in Priority order, 1, 2, 3, etc.")]
[JsonProperty(PropertyName="priority", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Priority { get; set; } = "";
        

[Description("Multiplies the autosized capacity and flow rates")]
[JsonProperty(PropertyName="sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SizingFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Part load ratio below which the chiller starts cycling on/off to meet the load. M" +
    "ust be less than or equal to Maximum Part Load Ratio.")]
[JsonProperty(PropertyName="minimum_part_load_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumPartLoadRatio { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Maximum allowable part load ratio. Must be greater than or equal to Minimum Part " +
    "Load Ratio.")]
[JsonProperty(PropertyName="maximum_part_load_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumPartLoadRatio { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Optimum part load ratio where the chiller is most efficient. Must be greater than" +
    " or equal to the Minimum Part Load Ratio and less than or equal to the Maximum P" +
    "art Load Ratio.")]
[JsonProperty(PropertyName="optimum_part_load_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OptimumPartLoadRatio { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Part load ratio where the chiller can no longer unload and false loading begins. " +
    "Minimum unloading ratio must be greater than or equal to the Minimum Part Load R" +
    "atio and less than or equal to the Maximum Part Load Ratio.")]
[JsonProperty(PropertyName="minimum_unloading_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumUnloadingRatio { get; set; } = Double.Parse("0.25", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="leaving_chilled_water_lower_temperature_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LeavingChilledWaterLowerTemperatureLimit { get; set; } = Double.Parse("5", CultureInfo.InvariantCulture);
    }
    
    public enum HVACTemplate_Plant_Chiller_ChillerType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="DistrictChilledWater")]
        DistrictChilledWater = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectricCentrifugalChiller")]
        ElectricCentrifugalChiller = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectricReciprocatingChiller")]
        ElectricReciprocatingChiller = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectricScrewChiller")]
        ElectricScrewChiller = 3,
    }
    
    public enum HVACTemplate_Plant_Chiller_CondenserType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AirCooled")]
        AirCooled = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="EvaporativelyCooled")]
        EvaporativelyCooled = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="WaterCooled")]
        WaterCooled = 3,
    }
    
    [Description("This object references a detailed chiller object and adds it to an HVACTemplate:P" +
        "lant:ChilledWaterLoop. The user must create a complete detailed chiller object w" +
        "ith all required curve or performance objects.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_Plant_Chiller_ObjectReference
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="chiller_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_Chiller_ObjectReference_ChillerObjectType ChillerObjectType { get; set; } = (HVACTemplate_Plant_Chiller_ObjectReference_ChillerObjectType)Enum.Parse(typeof(HVACTemplate_Plant_Chiller_ObjectReference_ChillerObjectType), "Empty");
        

[Description("The name of the detailed chiller object.")]
[JsonProperty(PropertyName="chiller_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ChillerName { get; set; } = "";
        

[Description("If Chiller Plant Operation Scheme Type=Default in HVACTemplate:Plant:ChilledWater" +
    "Loop, then equipment operates in Priority order, 1, 2, 3, etc.")]
[JsonProperty(PropertyName="priority", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Priority { get; set; } = null;
    }
    
    public enum HVACTemplate_Plant_Chiller_ObjectReference_ChillerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Chiller:Electric:EIR")]
        ChillerElectricEIR = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Chiller:Electric:ReformulatedEIR")]
        ChillerElectricReformulatedEIR = 2,
    }
    
    [Description("This object adds a cooling tower to an HVACTemplate:Plant:ChilledWaterLoop or Mix" +
        "edWaterLoop.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_Plant_Tower
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="tower_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_Tower_TowerType TowerType { get; set; } = (HVACTemplate_Plant_Tower_TowerType)Enum.Parse(typeof(HVACTemplate_Plant_Tower_TowerType), "SingleSpeed");
        

[Description(@"Applicable for tower type SingleSpeed and TwoSpeed Nominal tower capacity with entering water at 35C (95F), leaving water at 29.44C (85F), entering air at 25.56C (78F) wet-bulb temperature and 35C (95F) dry-bulb temperature, with the tower fan operating at high speed. Design water flow rate assumed to be 5.382E-8 m3/s per watt(3 gpm/ton). Nominal tower capacity times (1.25) gives the actual tower heat rejection at these operating conditions.")]
[JsonProperty(PropertyName="high_speed_nominal_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HighSpeedNominalCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Applicable for tower type SingleSpeed and TwoSpeed")]
[JsonProperty(PropertyName="high_speed_fan_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HighSpeedFanPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Applicable only for Tower Type TwoSpeed Nominal tower capacity with entering water at 35C (95F), leaving water at 29.44C (85F), entering air at 25.56C (78F) wet-bulb temperature and 35C (95F) dry-bulb temperature, with the tower fan operating at low speed. Design water flow rate assumed to be 5.382E-8 m3/s per watt of tower high-speed nominal capacity (3 gpm/ton). Nominal tower capacity times (1.25) gives the actual tower heat rejection at these operating conditions.")]
[JsonProperty(PropertyName="low_speed_nominal_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> LowSpeedNominalCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Applicable only for Tower Type TwoSpeed")]
[JsonProperty(PropertyName="low_speed_fan_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> LowSpeedFanPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Applicable for Tower Type SingleSpeed and TwoSpeed Tower capacity in free convection regime with entering water at 35C (95F), leaving water at 29.44C (85F), entering air at 25.56C (78F) wet-bulb temperature and 35C (95F) dry-bulb temperature. Design water flow rate assumed to be 5.382E-8 m3/s per watt of tower high-speed nominal capacity (3 gpm/ton). Tower free convection capacity times (1.25) gives the actual tower heat rejection at these operating conditions.")]
[JsonProperty(PropertyName="free_convection_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> FreeConvectionCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Applicable for all Tower Types If Condenser Plant Operation Scheme Type=Default i" +
    "n HVACTemplate:Plant:ChilledWaterLoop, then equipment operates in Priority order" +
    ", 1, 2, 3, etc.")]
[JsonProperty(PropertyName="priority", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Priority { get; set; } = "";
        

[Description("Multiplies the autosized capacity and flow rates")]
[JsonProperty(PropertyName="sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SizingFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Specifies if this tower serves a template chilled water loop or mixed water loop " +
    "If left blank, will serve a chilled water loop if present, or a mixed water loop" +
    " (if no chilled water loop is present).")]
[JsonProperty(PropertyName="template_plant_loop_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_Tower_TemplatePlantLoopType TemplatePlantLoopType { get; set; } = (HVACTemplate_Plant_Tower_TemplatePlantLoopType)Enum.Parse(typeof(HVACTemplate_Plant_Tower_TemplatePlantLoopType), "ChilledWater");
    }
    
    public enum HVACTemplate_Plant_Tower_TowerType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="SingleSpeed")]
        SingleSpeed = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="TwoSpeed")]
        TwoSpeed = 1,
    }
    
    public enum HVACTemplate_Plant_Tower_TemplatePlantLoopType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="ChilledWater")]
        ChilledWater = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MixedWater")]
        MixedWater = 1,
    }
    
    [Description("This object references a detailed cooling tower object and adds it to an HVACTemp" +
        "late:Plant:ChilledWaterLoop or MixedWaterLoop. The user must create a complete d" +
        "etailed cooling tower object with all required curve or performance objects.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_Plant_Tower_ObjectReference
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="cooling_tower_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_Tower_ObjectReference_CoolingTowerObjectType CoolingTowerObjectType { get; set; } = (HVACTemplate_Plant_Tower_ObjectReference_CoolingTowerObjectType)Enum.Parse(typeof(HVACTemplate_Plant_Tower_ObjectReference_CoolingTowerObjectType), "Empty");
        

[Description("The name of the detailed cooling tower object.")]
[JsonProperty(PropertyName="cooling_tower_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingTowerName { get; set; } = "";
        

[Description("If Condenser Plant Operation Scheme Type=Default in HVACTemplate:Plant:ChilledWat" +
    "erLoop or MixedWaterLoop, then equipment operates in Priority order, 1, 2, 3, et" +
    "c.")]
[JsonProperty(PropertyName="priority", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Priority { get; set; } = null;
        

[Description("Specifies if this tower serves a template chilled water loop or mixed water loop " +
    "If left blank, will serve a chilled water loop if present, or a mixed water loop" +
    " (if no chilled water loop is present).")]
[JsonProperty(PropertyName="template_plant_loop_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_Tower_ObjectReference_TemplatePlantLoopType TemplatePlantLoopType { get; set; } = (HVACTemplate_Plant_Tower_ObjectReference_TemplatePlantLoopType)Enum.Parse(typeof(HVACTemplate_Plant_Tower_ObjectReference_TemplatePlantLoopType), "ChilledWater");
    }
    
    public enum HVACTemplate_Plant_Tower_ObjectReference_CoolingTowerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingTower:SingleSpeed")]
        CoolingTowerSingleSpeed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingTower:TwoSpeed")]
        CoolingTowerTwoSpeed = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingTower:VariableSpeed")]
        CoolingTowerVariableSpeed = 3,
    }
    
    public enum HVACTemplate_Plant_Tower_ObjectReference_TemplatePlantLoopType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="ChilledWater")]
        ChilledWater = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MixedWater")]
        MixedWater = 1,
    }
    
    [Description("Plant loop to serve all HVACTemplate hot water coils and boilers.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_Plant_HotWaterLoop
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("If blank, always available")]
[JsonProperty(PropertyName="pump_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PumpScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="pump_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_HotWaterLoop_PumpControlType PumpControlType { get; set; } = (HVACTemplate_Plant_HotWaterLoop_PumpControlType)Enum.Parse(typeof(HVACTemplate_Plant_HotWaterLoop_PumpControlType), "Intermittent");
        

[Description("Default operation type makes all equipment available at all times operating in or" +
    "der of Priority specified in HVACTemplate:Plant:Boiler objects.")]
[JsonProperty(PropertyName="hot_water_plant_operation_scheme_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_HotWaterLoop_HotWaterPlantOperationSchemeType HotWaterPlantOperationSchemeType { get; set; } = (HVACTemplate_Plant_HotWaterLoop_HotWaterPlantOperationSchemeType)Enum.Parse(typeof(HVACTemplate_Plant_HotWaterLoop_HotWaterPlantOperationSchemeType), "Default");
        

[Description("Name of a PlantEquipmentOperationSchemes object Ignored if Plant Operation Scheme" +
    " Type = Default")]
[JsonProperty(PropertyName="hot_water_plant_equipment_operation_schemes_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HotWaterPlantEquipmentOperationSchemesName { get; set; } = "";
        

[Description("Leave blank if constant setpoint")]
[JsonProperty(PropertyName="hot_water_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HotWaterSetpointScheduleName { get; set; } = "";
        

[Description("Used for sizing and as constant setpoint if no Setpoint Schedule Name is specifie" +
    "d.")]
[JsonProperty(PropertyName="hot_water_design_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HotWaterDesignSetpoint { get; set; } = Double.Parse("82", CultureInfo.InvariantCulture);
        

[Description("VariableFlow - variable flow to boilers and coils, excess bypassed ConstantFlow -" +
    " constant flow to boilers and coils, excess bypassed")]
[JsonProperty(PropertyName="hot_water_pump_configuration", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_HotWaterLoop_HotWaterPumpConfiguration HotWaterPumpConfiguration { get; set; } = (HVACTemplate_Plant_HotWaterLoop_HotWaterPumpConfiguration)Enum.Parse(typeof(HVACTemplate_Plant_HotWaterLoop_HotWaterPumpConfiguration), "ConstantFlow");
        

[Description("Default head is 60 feet H2O")]
[JsonProperty(PropertyName="hot_water_pump_rated_head", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HotWaterPumpRatedHead { get; set; } = Double.Parse("179352", CultureInfo.InvariantCulture);
        

[Description("Overrides Hot Water Setpoint Schedule Name")]
[JsonProperty(PropertyName="hot_water_setpoint_reset_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_HotWaterLoop_HotWaterSetpointResetType HotWaterSetpointResetType { get; set; } = (HVACTemplate_Plant_HotWaterLoop_HotWaterSetpointResetType)Enum.Parse(typeof(HVACTemplate_Plant_HotWaterLoop_HotWaterSetpointResetType), "None");
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="hot_water_setpoint_at_outdoor_dry_bulb_low", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HotWaterSetpointAtOutdoorDryBulbLow { get; set; } = Double.Parse("82.2", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="hot_water_reset_outdoor_dry_bulb_low", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HotWaterResetOutdoorDryBulbLow { get; set; } = Double.Parse("-6.7", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="hot_water_setpoint_at_outdoor_dry_bulb_high", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HotWaterSetpointAtOutdoorDryBulbHigh { get; set; } = Double.Parse("65.6", CultureInfo.InvariantCulture);
        

[Description("Applicable only for OutdoorAirTemperatureReset control.")]
[JsonProperty(PropertyName="hot_water_reset_outdoor_dry_bulb_high", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HotWaterResetOutdoorDryBulbHigh { get; set; } = Double.Parse("10", CultureInfo.InvariantCulture);
        

[Description("Describes the type of pump configuration used for the hot water loop.")]
[JsonProperty(PropertyName="hot_water_pump_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_HotWaterLoop_HotWaterPumpType HotWaterPumpType { get; set; } = (HVACTemplate_Plant_HotWaterLoop_HotWaterPumpType)Enum.Parse(typeof(HVACTemplate_Plant_HotWaterLoop_HotWaterPumpType), "SinglePump");
        

[Description("Determines if a supply side bypass pipe is present in the hot water loop.")]
[JsonProperty(PropertyName="supply_side_bypass_pipe", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes SupplySideBypassPipe { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[Description("Determines if a demand side bypass pipe is present in the hot water loop.")]
[JsonProperty(PropertyName="demand_side_bypass_pipe", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes DemandSideBypassPipe { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="fluid_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_HotWaterLoop_FluidType FluidType { get; set; } = (HVACTemplate_Plant_HotWaterLoop_FluidType)Enum.Parse(typeof(HVACTemplate_Plant_HotWaterLoop_FluidType), "Water");
        

[Description("The temperature difference used in sizing the loop flow rate.")]
[JsonProperty(PropertyName="loop_design_delta_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoopDesignDeltaTemperature { get; set; } = Double.Parse("11", CultureInfo.InvariantCulture);
        

[Description("The maximum outdoor dry-bulb temperature that the hot water loops operate. Leave " +
    "blank for no limit.")]
[JsonProperty(PropertyName="maximum_outdoor_dry_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumOutdoorDryBulbTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="load_distribution_scheme", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_HotWaterLoop_LoadDistributionScheme LoadDistributionScheme { get; set; } = (HVACTemplate_Plant_HotWaterLoop_LoadDistributionScheme)Enum.Parse(typeof(HVACTemplate_Plant_HotWaterLoop_LoadDistributionScheme), "SequentialLoad");
    }
    
    public enum HVACTemplate_Plant_HotWaterLoop_PumpControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Continuous")]
        Continuous = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Intermittent")]
        Intermittent = 2,
    }
    
    public enum HVACTemplate_Plant_HotWaterLoop_HotWaterPlantOperationSchemeType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Default")]
        Default = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UserDefined")]
        UserDefined = 2,
    }
    
    public enum HVACTemplate_Plant_HotWaterLoop_HotWaterPumpConfiguration
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ConstantFlow")]
        ConstantFlow = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableFlow")]
        VariableFlow = 2,
    }
    
    public enum HVACTemplate_Plant_HotWaterLoop_HotWaterSetpointResetType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAirTemperatureReset")]
        OutdoorAirTemperatureReset = 2,
    }
    
    public enum HVACTemplate_Plant_HotWaterLoop_HotWaterPumpType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FiveHeaderedPumps")]
        FiveHeaderedPumps = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FourHeaderedPumps")]
        FourHeaderedPumps = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PumpPerBoiler")]
        PumpPerBoiler = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="SinglePump")]
        SinglePump = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="ThreeHeaderedPumps")]
        ThreeHeaderedPumps = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="TwoHeaderedPumps")]
        TwoHeaderedPumps = 6,
    }
    
    public enum HVACTemplate_Plant_HotWaterLoop_FluidType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="EthyleneGlycol30")]
        EthyleneGlycol30 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="EthyleneGlycol40")]
        EthyleneGlycol40 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="EthyleneGlycol50")]
        EthyleneGlycol50 = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="EthyleneGlycol60")]
        EthyleneGlycol60 = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="PropyleneGlycol30")]
        PropyleneGlycol30 = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="PropyleneGlycol40")]
        PropyleneGlycol40 = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="PropyleneGlycol50")]
        PropyleneGlycol50 = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="PropyleneGlycol60")]
        PropyleneGlycol60 = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Water")]
        Water = 9,
    }
    
    public enum HVACTemplate_Plant_HotWaterLoop_LoadDistributionScheme
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Optimal")]
        Optimal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SequentialLoad")]
        SequentialLoad = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="SequentialUniformPLR")]
        SequentialUniformPLR = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="UniformLoad")]
        UniformLoad = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="UniformPLR")]
        UniformPLR = 5,
    }
    
    [Description("This object adds a boiler to an HVACTemplate:Plant:HotWaterLoop or MixedWaterLoop" +
        ".")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_Plant_Boiler
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="boiler_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_Boiler_BoilerType BoilerType { get; set; } = (HVACTemplate_Plant_Boiler_BoilerType)Enum.Parse(typeof(HVACTemplate_Plant_Boiler_BoilerType), "CondensingHotWaterBoiler");
        

[JsonProperty(PropertyName="capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> Capacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Not applicable  if Boiler Type is DistrictHotWater")]
[JsonProperty(PropertyName="efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Efficiency { get; set; } = Double.Parse("0.8", CultureInfo.InvariantCulture);
        

[Description("Not applicable  if Boiler Type is DistrictHotWater")]
[JsonProperty(PropertyName="fuel_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_Boiler_FuelType FuelType { get; set; } = (HVACTemplate_Plant_Boiler_FuelType)Enum.Parse(typeof(HVACTemplate_Plant_Boiler_FuelType), "Coal");
        

[Description("If Hot Water Plant Operation Scheme Type=Default in HVACTemplate:Plant:HotWaterLo" +
    "op, then equipment operates in priority order, 1, 2, 3, etc.")]
[JsonProperty(PropertyName="priority", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Priority { get; set; } = "";
        

[Description("Multiplies the autosized capacity and flow rates")]
[JsonProperty(PropertyName="sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SizingFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_part_load_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumPartLoadRatio { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_part_load_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumPartLoadRatio { get; set; } = Double.Parse("1.1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="optimum_part_load_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OptimumPartLoadRatio { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="water_outlet_upper_temperature_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterOutletUpperTemperatureLimit { get; set; } = Double.Parse("100", CultureInfo.InvariantCulture);
        

[Description("Specifies if this boiler serves a template hot water loop or mixed water loop If " +
    "left blank, will serve a hot water loop if present, or a mixed water loop (if no" +
    " hot water loop is present).")]
[JsonProperty(PropertyName="template_plant_loop_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_Boiler_TemplatePlantLoopType TemplatePlantLoopType { get; set; } = (HVACTemplate_Plant_Boiler_TemplatePlantLoopType)Enum.Parse(typeof(HVACTemplate_Plant_Boiler_TemplatePlantLoopType), "HotWater");
    }
    
    public enum HVACTemplate_Plant_Boiler_BoilerType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="CondensingHotWaterBoiler")]
        CondensingHotWaterBoiler = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DistrictHotWater")]
        DistrictHotWater = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HotWaterBoiler")]
        HotWaterBoiler = 2,
    }
    
    public enum HVACTemplate_Plant_Boiler_FuelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coal")]
        Coal = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Diesel")]
        Diesel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Electricity")]
        Electricity = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo1")]
        FuelOilNo1 = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo2")]
        FuelOilNo2 = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Gasoline")]
        Gasoline = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="NaturalGas")]
        NaturalGas = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel1")]
        OtherFuel1 = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel2")]
        OtherFuel2 = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Propane")]
        Propane = 9,
    }
    
    public enum HVACTemplate_Plant_Boiler_TemplatePlantLoopType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MixedWater")]
        MixedWater = 1,
    }
    
    [Description("This object references a detailed boiler object and adds it to an HVACTemplate:Pl" +
        "ant:HotWaterLoop or MixedWaterLoop. The user must create a complete detailed boi" +
        "ler object with all required curve or performance objects.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_Plant_Boiler_ObjectReference
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="boiler_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_Boiler_ObjectReference_BoilerObjectType BoilerObjectType { get; set; } = (HVACTemplate_Plant_Boiler_ObjectReference_BoilerObjectType)Enum.Parse(typeof(HVACTemplate_Plant_Boiler_ObjectReference_BoilerObjectType), "Empty");
        

[Description("The name of the detailed boiler object.")]
[JsonProperty(PropertyName="boiler_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BoilerName { get; set; } = "";
        

[Description("If Hot Water Plant Operation Scheme Type=Default in HVACTemplate:Plant:HotWaterLo" +
    "op or MixedWaterLoop, then equipment operates in Priority order, 1, 2, 3, etc.")]
[JsonProperty(PropertyName="priority", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Priority { get; set; } = null;
        

[Description("Specifies if this boiler serves a template hot water loop or mixed water loop If " +
    "left blank, will serve a hot water loop if present, or a mixed water loop (if no" +
    " hot water loop is present).")]
[JsonProperty(PropertyName="template_plant_loop_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_Boiler_ObjectReference_TemplatePlantLoopType TemplatePlantLoopType { get; set; } = (HVACTemplate_Plant_Boiler_ObjectReference_TemplatePlantLoopType)Enum.Parse(typeof(HVACTemplate_Plant_Boiler_ObjectReference_TemplatePlantLoopType), "HotWater");
    }
    
    public enum HVACTemplate_Plant_Boiler_ObjectReference_BoilerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Boiler:HotWater")]
        BoilerHotWater = 1,
    }
    
    public enum HVACTemplate_Plant_Boiler_ObjectReference_TemplatePlantLoopType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="HotWater")]
        HotWater = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MixedWater")]
        MixedWater = 1,
    }
    
    [Description("Central plant loop portion of a water source heat pump system.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACTemplate_Plant_MixedWaterLoop
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("If blank, always available Applies to both chilled water and condenser loop pumps" +
    "")]
[JsonProperty(PropertyName="pump_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PumpScheduleName { get; set; } = "";
        

[Description("Applies to both chilled water and condenser loop pumps")]
[JsonProperty(PropertyName="pump_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_MixedWaterLoop_PumpControlType PumpControlType { get; set; } = (HVACTemplate_Plant_MixedWaterLoop_PumpControlType)Enum.Parse(typeof(HVACTemplate_Plant_MixedWaterLoop_PumpControlType), "Intermittent");
        

[Description("Default operation type makes all equipment available at all times operating in or" +
    "der of Priority specified in HVACTemplate:Plant:Boiler and HVACTemplate:Plant:To" +
    "wer objects.")]
[JsonProperty(PropertyName="operation_scheme_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_MixedWaterLoop_OperationSchemeType OperationSchemeType { get; set; } = (HVACTemplate_Plant_MixedWaterLoop_OperationSchemeType)Enum.Parse(typeof(HVACTemplate_Plant_MixedWaterLoop_OperationSchemeType), "Default");
        

[Description("Name of a PlantEquipmentOperationSchemes object Ignored if Plant Operation Scheme" +
    " Type = Default")]
[JsonProperty(PropertyName="equipment_operation_schemes_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EquipmentOperationSchemesName { get; set; } = "";
        

[Description("Leave blank if constant setpoint")]
[JsonProperty(PropertyName="high_temperature_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HighTemperatureSetpointScheduleName { get; set; } = "";
        

[Description("Used for sizing and as constant setpoint if no Setpoint Schedule Name is specifie" +
    "d.")]
[JsonProperty(PropertyName="high_temperature_design_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HighTemperatureDesignSetpoint { get; set; } = Double.Parse("33", CultureInfo.InvariantCulture);
        

[Description("Leave blank if constant setpoint May be left blank if not serving any water coole" +
    "d chillers")]
[JsonProperty(PropertyName="low_temperature_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string LowTemperatureSetpointScheduleName { get; set; } = "";
        

[Description("Used for sizing and as constant setpoint if no Condenser Water Setpoint Schedule " +
    "Name is specified. May be left blank if not serving any water cooled chillers")]
[JsonProperty(PropertyName="low_temperature_design_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LowTemperatureDesignSetpoint { get; set; } = Double.Parse("20", CultureInfo.InvariantCulture);
        

[Description("VariableFlow - variable flow to boilers and coils, excess bypassed ConstantFlow -" +
    " constant flow to boilers and coils, excess bypassed")]
[JsonProperty(PropertyName="water_pump_configuration", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_MixedWaterLoop_WaterPumpConfiguration WaterPumpConfiguration { get; set; } = (HVACTemplate_Plant_MixedWaterLoop_WaterPumpConfiguration)Enum.Parse(typeof(HVACTemplate_Plant_MixedWaterLoop_WaterPumpConfiguration), "ConstantFlow");
        

[Description("May be left blank if not serving any water cooled chillers default head is 60 fee" +
    "t H2O")]
[JsonProperty(PropertyName="water_pump_rated_head", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterPumpRatedHead { get; set; } = Double.Parse("179352", CultureInfo.InvariantCulture);
        

[Description("Describes the type of pump configuration used for the mixed water loop.")]
[JsonProperty(PropertyName="water_pump_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_MixedWaterLoop_WaterPumpType WaterPumpType { get; set; } = (HVACTemplate_Plant_MixedWaterLoop_WaterPumpType)Enum.Parse(typeof(HVACTemplate_Plant_MixedWaterLoop_WaterPumpType), "SinglePump");
        

[Description("Determines if a supply side bypass pipe is present in the hot water loop.")]
[JsonProperty(PropertyName="supply_side_bypass_pipe", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes SupplySideBypassPipe { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[Description("Determines if a demand side bypass pipe is present in the hot water loop.")]
[JsonProperty(PropertyName="demand_side_bypass_pipe", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes DemandSideBypassPipe { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="fluid_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_MixedWaterLoop_FluidType FluidType { get; set; } = (HVACTemplate_Plant_MixedWaterLoop_FluidType)Enum.Parse(typeof(HVACTemplate_Plant_MixedWaterLoop_FluidType), "Water");
        

[Description("The temperature difference used in sizing the loop flow rate.")]
[JsonProperty(PropertyName="loop_design_delta_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoopDesignDeltaTemperature { get; set; } = Double.Parse("5.6", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="load_distribution_scheme", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACTemplate_Plant_MixedWaterLoop_LoadDistributionScheme LoadDistributionScheme { get; set; } = (HVACTemplate_Plant_MixedWaterLoop_LoadDistributionScheme)Enum.Parse(typeof(HVACTemplate_Plant_MixedWaterLoop_LoadDistributionScheme), "SequentialLoad");
    }
    
    public enum HVACTemplate_Plant_MixedWaterLoop_PumpControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Continuous")]
        Continuous = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Intermittent")]
        Intermittent = 2,
    }
    
    public enum HVACTemplate_Plant_MixedWaterLoop_OperationSchemeType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Default")]
        Default = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UserDefined")]
        UserDefined = 2,
    }
    
    public enum HVACTemplate_Plant_MixedWaterLoop_WaterPumpConfiguration
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ConstantFlow")]
        ConstantFlow = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableFlow")]
        VariableFlow = 2,
    }
    
    public enum HVACTemplate_Plant_MixedWaterLoop_WaterPumpType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FiveHeaderedPumps")]
        FiveHeaderedPumps = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FourHeaderedPumps")]
        FourHeaderedPumps = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PumpPerTowerOrBoiler")]
        PumpPerTowerOrBoiler = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="SinglePump")]
        SinglePump = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="ThreeHeaderedPumps")]
        ThreeHeaderedPumps = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="TwoHeaderedPumps")]
        TwoHeaderedPumps = 6,
    }
    
    public enum HVACTemplate_Plant_MixedWaterLoop_FluidType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="EthyleneGlycol30")]
        EthyleneGlycol30 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="EthyleneGlycol40")]
        EthyleneGlycol40 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="EthyleneGlycol50")]
        EthyleneGlycol50 = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="EthyleneGlycol60")]
        EthyleneGlycol60 = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="PropyleneGlycol30")]
        PropyleneGlycol30 = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="PropyleneGlycol40")]
        PropyleneGlycol40 = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="PropyleneGlycol50")]
        PropyleneGlycol50 = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="PropyleneGlycol60")]
        PropyleneGlycol60 = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Water")]
        Water = 9,
    }
    
    public enum HVACTemplate_Plant_MixedWaterLoop_LoadDistributionScheme
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Optimal")]
        Optimal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SequentialLoad")]
        SequentialLoad = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="SequentialUniformPLR")]
        SequentialUniformPLR = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="UniformLoad")]
        UniformLoad = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="UniformPLR")]
        UniformPLR = 5,
    }
}
