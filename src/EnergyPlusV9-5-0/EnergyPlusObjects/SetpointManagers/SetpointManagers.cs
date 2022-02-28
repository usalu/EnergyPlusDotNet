namespace EnergyPlus.SetpointManagers
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
    
    
    [Description("The simplest Setpoint Manager simply uses a schedule to determine one or more set" +
        "points. Values of the nodes are not used as input.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_Scheduled
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="control_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_Scheduled_ControlVariable ControlVariable { get; set; } = (SetpointManager_Scheduled_ControlVariable)Enum.Parse(typeof(SetpointManager_Scheduled_ControlVariable), "HumidityRatio");
        

[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[Description("Node(s) at which control variable will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
    }
    
    public enum SetpointManager_Scheduled_ControlVariable
    {
        
        [System.Runtime.Serialization.EnumMember(Value="HumidityRatio")]
        HumidityRatio = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlowRate")]
        MassFlowRate = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="MaximumHumidityRatio")]
        MaximumHumidityRatio = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MaximumMassFlowRate")]
        MaximumMassFlowRate = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="MaximumTemperature")]
        MaximumTemperature = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="MinimumHumidityRatio")]
        MinimumHumidityRatio = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="MinimumMassFlowRate")]
        MinimumMassFlowRate = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="MinimumTemperature")]
        MinimumTemperature = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 8,
    }
    
    [Description("This setpoint manager places a high and low schedule value on one or more nodes.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_Scheduled_DualSetpoint
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="control_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_Scheduled_DualSetpoint_ControlVariable ControlVariable { get; set; } = (SetpointManager_Scheduled_DualSetpoint_ControlVariable)Enum.Parse(typeof(SetpointManager_Scheduled_DualSetpoint_ControlVariable), "Temperature");
        

[JsonProperty(PropertyName="high_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HighSetpointScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="low_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string LowSetpointScheduleName { get; set; } = "";
        

[Description("Node(s) at which temperature will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
    }
    
    public enum SetpointManager_Scheduled_DualSetpoint_ControlVariable
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 1,
    }
    
    [Description("This Setpoint Manager is used to place a setpoint temperature on system node acco" +
        "rding to the outdoor air temperature using a reset rule. The outdoor air tempera" +
        "ture is obtained from the weather information during the simulation.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_OutdoorAirReset
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="control_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_OutdoorAirReset_ControlVariable ControlVariable { get; set; } = (SetpointManager_OutdoorAirReset_ControlVariable)Enum.Parse(typeof(SetpointManager_OutdoorAirReset_ControlVariable), "Temperature");
        

[JsonProperty(PropertyName="setpoint_at_outdoor_low_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SetpointAtOutdoorLowTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="outdoor_low_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorLowTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="setpoint_at_outdoor_high_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SetpointAtOutdoorHighTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="outdoor_high_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorHighTemperature { get; set; } = null;
        

[Description("Node(s) at which temperature will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
        

[Description("Optional input. Schedule allows scheduling of the outdoor air reset rule - a sche" +
    "dule value of 1 means use the first rule; a value of 2 means use the second rule" +
    ".")]
[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[Description("2nd outdoor air temperature reset rule")]
[JsonProperty(PropertyName="setpoint_at_outdoor_low_temperature_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SetpointAtOutdoorLowTemperature2 { get; set; } = null;
        

[Description("2nd outdoor air temperature reset rule")]
[JsonProperty(PropertyName="outdoor_low_temperature_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorLowTemperature2 { get; set; } = null;
        

[Description("2nd outdoor air temperature reset rule")]
[JsonProperty(PropertyName="setpoint_at_outdoor_high_temperature_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SetpointAtOutdoorHighTemperature2 { get; set; } = null;
        

[Description("2nd outdoor air temperature reset rule")]
[JsonProperty(PropertyName="outdoor_high_temperature_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorHighTemperature2 { get; set; } = null;
    }
    
    public enum SetpointManager_OutdoorAirReset_ControlVariable
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MaximumTemperature")]
        MaximumTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="MinimumTemperature")]
        MinimumTemperature = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 3,
    }
    
    [Description(@"This setpoint manager detects the control zone load, zone inlet node flow rate, and zone node temperature and calculates a setpoint temperature for the supply air that will satisfy the zone load (heating or cooling) for the control zone. This setpoint manager is not limited to reheat applications.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_SingleZone_Reheat
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="control_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_SingleZone_Reheat_ControlVariable ControlVariable { get; set; } = (SetpointManager_SingleZone_Reheat_ControlVariable)Enum.Parse(typeof(SetpointManager_SingleZone_Reheat_ControlVariable), "Temperature");
        

[JsonProperty(PropertyName="minimum_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumSupplyAirTemperature { get; set; } = Double.Parse("-99", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumSupplyAirTemperature { get; set; } = Double.Parse("99", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneInletNodeName { get; set; } = "";
        

[Description("Node(s) at which the temperature will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
    }
    
    public enum SetpointManager_SingleZone_Reheat_ControlVariable
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 1,
    }
    
    [Description(@"This setpoint manager detects the control zone load to meet the current heating setpoint, zone inlet node flow rate, and zone node temperature, and calculates a setpoint temperature for the supply air that will satisfy the zone heating load for the control zone.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_SingleZone_Heating
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="control_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_SingleZone_Heating_ControlVariable ControlVariable { get; set; } = (SetpointManager_SingleZone_Heating_ControlVariable)Enum.Parse(typeof(SetpointManager_SingleZone_Heating_ControlVariable), "Temperature");
        

[JsonProperty(PropertyName="minimum_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumSupplyAirTemperature { get; set; } = Double.Parse("-99", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumSupplyAirTemperature { get; set; } = Double.Parse("99", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneInletNodeName { get; set; } = "";
        

[Description("Node(s) at which the temperature will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
    }
    
    public enum SetpointManager_SingleZone_Heating_ControlVariable
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 1,
    }
    
    [Description(@"This setpoint manager detects the control zone load to meet the current cooling setpoint, zone inlet node flow rate, and zone node temperature, and calculates a setpoint temperature for the supply air that will satisfy the zone cooling load for the control zone.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_SingleZone_Cooling
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="control_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_SingleZone_Cooling_ControlVariable ControlVariable { get; set; } = (SetpointManager_SingleZone_Cooling_ControlVariable)Enum.Parse(typeof(SetpointManager_SingleZone_Cooling_ControlVariable), "Temperature");
        

[JsonProperty(PropertyName="minimum_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumSupplyAirTemperature { get; set; } = Double.Parse("-99", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumSupplyAirTemperature { get; set; } = Double.Parse("99", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneInletNodeName { get; set; } = "";
        

[Description("Node(s) at which the temperature will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
    }
    
    public enum SetpointManager_SingleZone_Cooling_ControlVariable
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 1,
    }
    
    [Description("The Single Zone Minimum Humidity Setpoint Manager allows the control of a single " +
        "zone minimum humidity level. This setpoint manager can be used in conjunction wi" +
        "th object ZoneControl:Humidistat to detect humidity levels.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_SingleZone_Humidity_Minimum
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Node(s) at which humidity ratio setpoint will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
        

[Description("Name of the zone air node for the humidity control zone")]
[JsonProperty(PropertyName="control_zone_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlZoneAirNodeName { get; set; } = "";
    }
    
    [Description("The Single Zone Maximum Humidity Setpoint Manager allows the control of a single " +
        "zone maximum humidity level. This setpoint manager can be used in conjunction wi" +
        "th object ZoneControl:Humidistat to detect humidity levels.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_SingleZone_Humidity_Maximum
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Node(s) at which humidity ratio setpoint will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
        

[Description("Name of the zone air node for the humidity control zone")]
[JsonProperty(PropertyName="control_zone_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlZoneAirNodeName { get; set; } = "";
    }
    
    [Description("The Mixed Air Setpoint Manager is meant to be used in conjunction with a Controll" +
        "er:OutdoorAir object. This setpoint manager is used to establish a temperature s" +
        "etpoint at the mixed air node.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_MixedAir
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="control_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_MixedAir_ControlVariable ControlVariable { get; set; } = (SetpointManager_MixedAir_ControlVariable)Enum.Parse(typeof(SetpointManager_MixedAir_ControlVariable), "Temperature");
        

[JsonProperty(PropertyName="reference_setpoint_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReferenceSetpointNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="fan_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FanInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="fan_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FanOutletNodeName { get; set; } = "";
        

[Description("Node(s) at which the temperature will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
        

[Description("Optional field used to limit economizer operation to prevent freezing of DX cooli" +
    "ng coil.")]
[JsonProperty(PropertyName="cooling_coil_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilInletNodeName { get; set; } = "";
        

[Description("Optional field used to limit economizer operation to prevent freezing of DX cooli" +
    "ng coil.")]
[JsonProperty(PropertyName="cooling_coil_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilOutletNodeName { get; set; } = "";
        

[Description("Optional field used to limit economizer operation to prevent freezing of DX cooli" +
    "ng coil.")]
[JsonProperty(PropertyName="minimum_temperature_at_cooling_coil_outlet_node", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumTemperatureAtCoolingCoilOutletNode { get; set; } = Double.Parse("7.2", CultureInfo.InvariantCulture);
    }
    
    public enum SetpointManager_MixedAir_ControlVariable
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 1,
    }
    
    [Description("This setpoint manager determines the required conditions at the outdoor air strea" +
        "m node which will produce the reference setpoint condition at the mixed air node" +
        " when mixed with the return air stream")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_OutdoorAirPretreat
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="control_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_OutdoorAirPretreat_ControlVariable ControlVariable { get; set; } = (SetpointManager_OutdoorAirPretreat_ControlVariable)Enum.Parse(typeof(SetpointManager_OutdoorAirPretreat_ControlVariable), "HumidityRatio");
        

[Description("Applicable only if Control variable is Temperature")]
[JsonProperty(PropertyName="minimum_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumSetpointTemperature { get; set; } = Double.Parse("-99", CultureInfo.InvariantCulture);
        

[Description("Applicable only if Control variable is Temperature")]
[JsonProperty(PropertyName="maximum_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumSetpointTemperature { get; set; } = Double.Parse("99", CultureInfo.InvariantCulture);
        

[Description("Applicable only if Control variable is MaximumHumidityRatio, MinimumHumidityRatio" +
    ", or HumidityRatio - then minimum is 0.00001")]
[JsonProperty(PropertyName="minimum_setpoint_humidity_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumSetpointHumidityRatio { get; set; } = Double.Parse("1E-05", CultureInfo.InvariantCulture);
        

[Description("Applicable only if Control variable is MaximumHumidityRatio, MinimumHumidityRatio" +
    ", or HumidityRatio - then minimum is 0.00001")]
[JsonProperty(PropertyName="maximum_setpoint_humidity_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumSetpointHumidityRatio { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("The current setpoint at this node is the desired condition for the Mixed Air Node" +
    " This node must have a valid setpoint which has been set by another setpoint man" +
    "ager")]
[JsonProperty(PropertyName="reference_setpoint_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReferenceSetpointNodeName { get; set; } = "";
        

[Description("Name of Mixed Air Node")]
[JsonProperty(PropertyName="mixed_air_stream_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MixedAirStreamNodeName { get; set; } = "";
        

[Description("Name of Outdoor Air Stream Node")]
[JsonProperty(PropertyName="outdoor_air_stream_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirStreamNodeName { get; set; } = "";
        

[Description("Name of Return Air Stream Node")]
[JsonProperty(PropertyName="return_air_stream_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReturnAirStreamNodeName { get; set; } = "";
        

[Description("Node(s) at which the temperature or humidity ratio will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
    }
    
    public enum SetpointManager_OutdoorAirPretreat_ControlVariable
    {
        
        [System.Runtime.Serialization.EnumMember(Value="HumidityRatio")]
        HumidityRatio = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MaximumHumidityRatio")]
        MaximumHumidityRatio = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="MinimumHumidityRatio")]
        MinimumHumidityRatio = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 3,
    }
    
    [Description("This SetpointManager resets the cooling supply air temperature of a central force" +
        "d air HVAC system according to the cooling demand of the warmest zone.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_Warmest
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="control_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_Warmest_ControlVariable ControlVariable { get; set; } = (SetpointManager_Warmest_ControlVariable)Enum.Parse(typeof(SetpointManager_Warmest_ControlVariable), "Temperature");
        

[Description("Enter the name of an AirLoopHVAC object")]
[JsonProperty(PropertyName="hvac_air_loop_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HvacAirLoopName { get; set; } = "";
        

[JsonProperty(PropertyName="minimum_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumSetpointTemperature { get; set; } = Double.Parse("12", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumSetpointTemperature { get; set; } = Double.Parse("18", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="strategy", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_Warmest_Strategy Strategy { get; set; } = (SetpointManager_Warmest_Strategy)Enum.Parse(typeof(SetpointManager_Warmest_Strategy), "MaximumTemperature");
        

[Description("Node(s) at which the temperature will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
    }
    
    public enum SetpointManager_Warmest_ControlVariable
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 1,
    }
    
    public enum SetpointManager_Warmest_Strategy
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MaximumTemperature")]
        MaximumTemperature = 1,
    }
    
    [Description("This SetpointManager is used in dual duct systems to reset the setpoint temperatu" +
        "re of the air in the heating supply duct. Usually it is used in conjunction with" +
        " a SetpointManager:Warmest resetting the temperature of the air in the cooling s" +
        "upply duct.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_Coldest
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="control_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_Coldest_ControlVariable ControlVariable { get; set; } = (SetpointManager_Coldest_ControlVariable)Enum.Parse(typeof(SetpointManager_Coldest_ControlVariable), "Temperature");
        

[Description("Enter the name of an AirLoopHVAC object.")]
[JsonProperty(PropertyName="hvac_air_loop_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HvacAirLoopName { get; set; } = "";
        

[JsonProperty(PropertyName="minimum_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumSetpointTemperature { get; set; } = Double.Parse("20", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumSetpointTemperature { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="strategy", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_Coldest_Strategy Strategy { get; set; } = (SetpointManager_Coldest_Strategy)Enum.Parse(typeof(SetpointManager_Coldest_Strategy), "MinimumTemperature");
        

[Description("Node(s) at which the temperature will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
    }
    
    public enum SetpointManager_Coldest_ControlVariable
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 1,
    }
    
    public enum SetpointManager_Coldest_Strategy
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MinimumTemperature")]
        MinimumTemperature = 1,
    }
    
    [Description("This setpoint manager determines the required mass flow rate through a return air" +
        " bypass duct to meet the specified temperature setpoint")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_ReturnAirBypassFlow
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="control_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_ReturnAirBypassFlow_ControlVariable ControlVariable { get; set; } = (SetpointManager_ReturnAirBypassFlow_ControlVariable)Enum.Parse(typeof(SetpointManager_ReturnAirBypassFlow_ControlVariable), "Flow");
        

[Description("Enter the name of an AirLoopHVAC object.")]
[JsonProperty(PropertyName="hvac_air_loop_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HvacAirLoopName { get; set; } = "";
        

[JsonProperty(PropertyName="temperature_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TemperatureSetpointScheduleName { get; set; } = "";
    }
    
    public enum SetpointManager_ReturnAirBypassFlow_ControlVariable
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow")]
        Flow = 1,
    }
    
    [Description("This setpoint manager sets both the supply air temperature and the supply air flo" +
        "w rate.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_WarmestTemperatureFlow
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="control_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_WarmestTemperatureFlow_ControlVariable ControlVariable { get; set; } = (SetpointManager_WarmestTemperatureFlow_ControlVariable)Enum.Parse(typeof(SetpointManager_WarmestTemperatureFlow_ControlVariable), "Temperature");
        

[Description("Enter the name of an AirLoopHVAC object.")]
[JsonProperty(PropertyName="hvac_air_loop_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HvacAirLoopName { get; set; } = "";
        

[JsonProperty(PropertyName="minimum_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumSetpointTemperature { get; set; } = Double.Parse("12", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumSetpointTemperature { get; set; } = Double.Parse("18", CultureInfo.InvariantCulture);
        

[Description(@"For TemperatureFirst the manager tries to find the highest setpoint temperature that will satisfy all the zone cooling loads at minimum supply air flow rate. If this setpoint temperature is less than the minimum, the setpoint temperature is set to the minimum, and the supply air flow rate is increased to meet the loads. For FlowFirst the manager tries to find the lowest supply air flow rate that will satisfy all the zone cooling loads at the maximum setpoint temperature. If this flow is greater than the maximum, the flow is set to the maximum and the setpoint temperature is reduced to satisfy the cooling loads.")]
[JsonProperty(PropertyName="strategy", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_WarmestTemperatureFlow_Strategy Strategy { get; set; } = (SetpointManager_WarmestTemperatureFlow_Strategy)Enum.Parse(typeof(SetpointManager_WarmestTemperatureFlow_Strategy), "TemperatureFirst");
        

[Description("Node(s) at which the temperature will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
        

[Description("Fraction of the maximum supply air flow rate. Used to define the minimum supply f" +
    "low for the TemperatureFirst strategy.")]
[JsonProperty(PropertyName="minimum_turndown_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumTurndownRatio { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
    }
    
    public enum SetpointManager_WarmestTemperatureFlow_ControlVariable
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 0,
    }
    
    public enum SetpointManager_WarmestTemperatureFlow_Strategy
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FlowFirst")]
        FlowFirst = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureFirst")]
        TemperatureFirst = 2,
    }
    
    [Description("This setpoint manager sets the average supply air temperature based on the heatin" +
        "g load requirements of all controlled zones in an air loop served by a central a" +
        "ir-conditioner.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_MultiZone_Heating_Average
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Enter the name of an AirLoopHVAC object")]
[JsonProperty(PropertyName="hvac_air_loop_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HvacAirLoopName { get; set; } = "";
        

[JsonProperty(PropertyName="minimum_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumSetpointTemperature { get; set; } = Double.Parse("20", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumSetpointTemperature { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[Description("Node(s) at which the temperature will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
    }
    
    [Description("This setpoint manager sets the average supply air temperature based on the coolin" +
        "g load requirements of all controlled zones in an air loop served by a central a" +
        "ir-conditioner.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_MultiZone_Cooling_Average
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Enter the name of an AirLoopHVAC object")]
[JsonProperty(PropertyName="hvac_air_loop_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HvacAirLoopName { get; set; } = "";
        

[JsonProperty(PropertyName="minimum_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumSetpointTemperature { get; set; } = Double.Parse("12", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumSetpointTemperature { get; set; } = Double.Parse("18", CultureInfo.InvariantCulture);
        

[Description("Node(s) at which the temperature will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
    }
    
    [Description("This setpoint manager sets the average supply air minimum humidity ratio based on" +
        " moisture load requirements of all controlled zones in an air loop served by a c" +
        "entral air-conditioner.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_MultiZone_MinimumHumidity_Average
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Enter the name of an AirLoopHVAC object")]
[JsonProperty(PropertyName="hvac_air_loop_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HvacAirLoopName { get; set; } = "";
        

[JsonProperty(PropertyName="minimum_setpoint_humidity_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumSetpointHumidityRatio { get; set; } = Double.Parse("0.005", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_setpoint_humidity_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumSetpointHumidityRatio { get; set; } = Double.Parse("0.012", CultureInfo.InvariantCulture);
        

[Description("Node(s) at which the humidity ratio will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
    }
    
    [Description("This setpoint manager sets the average supply air maximum humidity ratio based on" +
        " moisture load requirements of all controlled zones in an air loop served by a c" +
        "entral air-conditioner.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_MultiZone_MaximumHumidity_Average
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Enter the name of an AirLoopHVAC object")]
[JsonProperty(PropertyName="hvac_air_loop_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HvacAirLoopName { get; set; } = "";
        

[JsonProperty(PropertyName="minimum_setpoint_humidity_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumSetpointHumidityRatio { get; set; } = Double.Parse("0.008", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_setpoint_humidity_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumSetpointHumidityRatio { get; set; } = Double.Parse("0.015", CultureInfo.InvariantCulture);
        

[Description("Node(s) at which the humidity ratio will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
    }
    
    [Description(@"This setpoint manager sets the minimum supply air humidity ratio based on humidification requirements of a controlled zone with critical humidity ratio setpoint (i.e., a zone with the highest humidity ratio setpoint) in an air loop served by a central air-conditioner.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_MultiZone_Humidity_Minimum
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Enter the name of an AirLoopHVAC object")]
[JsonProperty(PropertyName="hvac_air_loop_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HvacAirLoopName { get; set; } = "";
        

[JsonProperty(PropertyName="minimum_setpoint_humidity_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumSetpointHumidityRatio { get; set; } = Double.Parse("0.005", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_setpoint_humidity_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumSetpointHumidityRatio { get; set; } = Double.Parse("0.012", CultureInfo.InvariantCulture);
        

[Description("Node(s) at which the humidity ratio will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
    }
    
    [Description(@"This setpoint manager sets the maximum supply air humidity ratio based on dehumidification requirements of a controlled zone with critical humidity ratio setpoint (i.e., a zone with the lowest humidity ratio setpoint) in an air loop served by a central air-conditioner.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_MultiZone_Humidity_Maximum
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Enter the name of an AirLoopHVAC object")]
[JsonProperty(PropertyName="hvac_air_loop_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HvacAirLoopName { get; set; } = "";
        

[JsonProperty(PropertyName="minimum_setpoint_humidity_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumSetpointHumidityRatio { get; set; } = Double.Parse("0.008", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_setpoint_humidity_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumSetpointHumidityRatio { get; set; } = Double.Parse("0.015", CultureInfo.InvariantCulture);
        

[Description("Node(s) at which the humidity ratio will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
    }
    
    [Description("This setpoint manager is used to place a temperature setpoint on a system node th" +
        "at is derived from the current outdoor air environmental conditions. The outdoor" +
        " air conditions are obtained from the weather information during the simulation." +
        "")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_FollowOutdoorAirTemperature
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="control_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_FollowOutdoorAirTemperature_ControlVariable ControlVariable { get; set; } = (SetpointManager_FollowOutdoorAirTemperature_ControlVariable)Enum.Parse(typeof(SetpointManager_FollowOutdoorAirTemperature_ControlVariable), "Temperature");
        

[JsonProperty(PropertyName="reference_temperature_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_FollowOutdoorAirTemperature_ReferenceTemperatureType ReferenceTemperatureType { get; set; } = (SetpointManager_FollowOutdoorAirTemperature_ReferenceTemperatureType)Enum.Parse(typeof(SetpointManager_FollowOutdoorAirTemperature_ReferenceTemperatureType), "OutdoorAirWetBulb");
        

[JsonProperty(PropertyName="offset_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OffsetTemperatureDifference { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumSetpointTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumSetpointTemperature { get; set; } = null;
        

[Description("Node(s) at which control variable will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
    }
    
    public enum SetpointManager_FollowOutdoorAirTemperature_ControlVariable
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MaximumTemperature")]
        MaximumTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="MinimumTemperature")]
        MinimumTemperature = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 3,
    }
    
    public enum SetpointManager_FollowOutdoorAirTemperature_ReferenceTemperatureType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAirDryBulb")]
        OutdoorAirDryBulb = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAirWetBulb")]
        OutdoorAirWetBulb = 2,
    }
    
    [Description(@"This setpoint manager is used to place a temperature setpoint on a system node that is derived from the current temperatures at a separate system node. The current value of the temperature at a reference node is obtained and used to generate setpoint on a second system node. If the reference node is also designated to be an outdoor air (intake) node, then this setpoint manager can be used to follow outdoor air conditions that are adjusted for altitude.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_FollowSystemNodeTemperature
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="control_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_FollowSystemNodeTemperature_ControlVariable ControlVariable { get; set; } = (SetpointManager_FollowSystemNodeTemperature_ControlVariable)Enum.Parse(typeof(SetpointManager_FollowSystemNodeTemperature_ControlVariable), "Temperature");
        

[JsonProperty(PropertyName="reference_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReferenceNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="reference_temperature_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_FollowSystemNodeTemperature_ReferenceTemperatureType ReferenceTemperatureType { get; set; } = (SetpointManager_FollowSystemNodeTemperature_ReferenceTemperatureType)Enum.Parse(typeof(SetpointManager_FollowSystemNodeTemperature_ReferenceTemperatureType), "NodeDryBulb");
        

[JsonProperty(PropertyName="offset_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OffsetTemperatureDifference { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_limit_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumLimitSetpointTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_limit_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumLimitSetpointTemperature { get; set; } = null;
        

[Description("Node(s) at which control variable will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
    }
    
    public enum SetpointManager_FollowSystemNodeTemperature_ControlVariable
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MaximumTemperature")]
        MaximumTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="MinimumTemperature")]
        MinimumTemperature = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 3,
    }
    
    public enum SetpointManager_FollowSystemNodeTemperature_ReferenceTemperatureType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="NodeDryBulb")]
        NodeDryBulb = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="NodeWetBulb")]
        NodeWetBulb = 2,
    }
    
    [Description(@"This setpoint manager is used to place a temperature setpoint on a system node that is derived from a current ground temperature. The ground temperatures are specified in different Site:GroundTemperature:* objects and used during the simulation. This setpoint manager is primarily intended for condenser or plant loops using some type of ground heat exchanger.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_FollowGroundTemperature
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="control_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_FollowGroundTemperature_ControlVariable ControlVariable { get; set; } = (SetpointManager_FollowGroundTemperature_ControlVariable)Enum.Parse(typeof(SetpointManager_FollowGroundTemperature_ControlVariable), "Temperature");
        

[JsonProperty(PropertyName="reference_ground_temperature_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_FollowGroundTemperature_ReferenceGroundTemperatureObjectType ReferenceGroundTemperatureObjectType { get; set; } = (SetpointManager_FollowGroundTemperature_ReferenceGroundTemperatureObjectType)Enum.Parse(typeof(SetpointManager_FollowGroundTemperature_ReferenceGroundTemperatureObjectType), "SiteGroundTemperatureBuildingSurface");
        

[JsonProperty(PropertyName="offset_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OffsetTemperatureDifference { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumSetpointTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumSetpointTemperature { get; set; } = null;
        

[Description("Node(s) at which control variable will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
    }
    
    public enum SetpointManager_FollowGroundTemperature_ControlVariable
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MaximumTemperature")]
        MaximumTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="MinimumTemperature")]
        MinimumTemperature = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 3,
    }
    
    public enum SetpointManager_FollowGroundTemperature_ReferenceGroundTemperatureObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:BuildingSurface")]
        SiteGroundTemperatureBuildingSurface = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:Deep")]
        SiteGroundTemperatureDeep = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:FCfactorMethod")]
        SiteGroundTemperatureFCfactorMethod = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:Shallow")]
        SiteGroundTemperatureShallow = 3,
    }
    
    [Description("This setpoint manager uses one curve to determine the optimum condenser entering " +
        "water temperature for a given timestep and two other curves to place boundary co" +
        "nditions on the setpoint value.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_CondenserEnteringReset
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="control_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_CondenserEnteringReset_ControlVariable ControlVariable { get; set; } = (SetpointManager_CondenserEnteringReset_ControlVariable)Enum.Parse(typeof(SetpointManager_CondenserEnteringReset_ControlVariable), "Temperature");
        

[Description("This scheduled setpoint value is only used in a given timestep if the \"Optimized\"" +
    " Condenser Entering Temperature does not fall within the prescribed boundary con" +
    "ditions.")]
[JsonProperty(PropertyName="default_condenser_entering_water_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DefaultCondenserEnteringWaterTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="minimum_design_wetbulb_temperature_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumDesignWetbulbTemperatureCurveName { get; set; } = "";
        

[JsonProperty(PropertyName="minimum_outside_air_wetbulb_temperature_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumOutsideAirWetbulbTemperatureCurveName { get; set; } = "";
        

[JsonProperty(PropertyName="optimized_cond_entering_water_temperature_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OptimizedCondEnteringWaterTemperatureCurveName { get; set; } = "";
        

[JsonProperty(PropertyName="minimum_lift", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumLift { get; set; } = Double.Parse("11.1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_condenser_entering_water_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCondenserEnteringWaterTemperature { get; set; } = Double.Parse("32", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cooling_tower_design_inlet_air_wet_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingTowerDesignInletAirWetBulbTemperature { get; set; } = Double.Parse("25.56", CultureInfo.InvariantCulture);
        

[Description("Node(s) at which control variable will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
    }
    
    public enum SetpointManager_CondenserEnteringReset_ControlVariable
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 1,
    }
    
    [Description("This setpoint manager determine the ideal optimum condenser entering water temper" +
        "ature setpoint for a given timestep.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_CondenserEnteringReset_Ideal
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="control_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_CondenserEnteringReset_Ideal_ControlVariable ControlVariable { get; set; } = (SetpointManager_CondenserEnteringReset_Ideal_ControlVariable)Enum.Parse(typeof(SetpointManager_CondenserEnteringReset_Ideal_ControlVariable), "Temperature");
        

[JsonProperty(PropertyName="minimum_lift", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumLift { get; set; } = Double.Parse("11.1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_condenser_entering_water_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCondenserEnteringWaterTemperature { get; set; } = Double.Parse("32", CultureInfo.InvariantCulture);
        

[Description("Node(s) at which control variable will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
    }
    
    public enum SetpointManager_CondenserEnteringReset_Ideal_ControlVariable
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 1,
    }
    
    [Description(@"This object can be used with CoilSystem:Cooling:DX to model on/off cycling control of single stage air systems. Setpoints are modulated to run coil full on or full off depending on zone conditions. Intended for use with ZoneControl:Thermostat:StagedDualSetpoint")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_SingleZone_OneStageCooling
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("This is the setpoint value applied when cooling device is to cycle ON")]
[JsonProperty(PropertyName="cooling_stage_on_supply_air_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingStageOnSupplyAirSetpointTemperature { get; set; } = Double.Parse("-99", CultureInfo.InvariantCulture);
        

[Description("This is the setpoint value applied when cooling device is to cycle OFF")]
[JsonProperty(PropertyName="cooling_stage_off_supply_air_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingStageOffSupplyAirSetpointTemperature { get; set; } = Double.Parse("99", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlZoneName { get; set; } = "";
        

[Description("Node(s) at which the temperature will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
    }
    
    [Description(@"This object can be used with CoilSystem:Heating:DX, Coil:Heating:Fuel, Coil:Heating:Electric to model on/off cycling control of single stage air systems. Setpoints are modulated to run coil full on or full off depending on zone conditions. Intended for use with ZoneControl:Thermostat:StagedDualSetpoint.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_SingleZone_OneStageHeating
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("This is the setpoint value applied when heating device is to cycle ON")]
[JsonProperty(PropertyName="heating_stage_on_supply_air_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingStageOnSupplyAirSetpointTemperature { get; set; } = Double.Parse("99", CultureInfo.InvariantCulture);
        

[Description("This is the setpoint value applied when heating device is to cycle OFF")]
[JsonProperty(PropertyName="heating_stage_off_supply_air_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingStageOffSupplyAirSetpointTemperature { get; set; } = Double.Parse("-99", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlZoneName { get; set; } = "";
        

[Description("Node(s) at which the temperature will be set")]
[JsonProperty(PropertyName="setpoint_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeOrNodelistName { get; set; } = "";
    }
    
    [Description(@"This setpoint manager is used to place a temperature setpoint on a plant supply outlet node based on a target return water setpoint. The setpoint manager attempts to achieve the desired return water temperature by adjusting the supply temperature setpoint based on the plant conditions at each system time step.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_ReturnTemperature_ChilledWater
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description(@"This is the name of the supply outlet node for the plant being controlled by this setpoint manager. Typically this is where the setpoint will be actuated for supply equipment to control to, but not necessarily. This setpoint manager will mine that information from the internal plant data structures.")]
[JsonProperty(PropertyName="plant_loop_supply_outlet_node", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PlantLoopSupplyOutletNode { get; set; } = "";
        

[Description("This is the name of the supply inlet node for the plant being controlled with thi" +
    "s setpoint manager. The temperature on this node is controlled by actuating the " +
    "supply setpoint.")]
[JsonProperty(PropertyName="plant_loop_supply_inlet_node", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PlantLoopSupplyInletNode { get; set; } = "";
        

[Description("This is the minimum chilled water supply temperature setpoint. This is also used " +
    "as the default setpoint during no-load or negative-load conditions and during in" +
    "itialization.")]
[JsonProperty(PropertyName="minimum_supply_temperature_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumSupplyTemperatureSetpoint { get; set; } = Double.Parse("5", CultureInfo.InvariantCulture);
        

[Description("This is the maximum reset temperature for the chilled water supply.")]
[JsonProperty(PropertyName="maximum_supply_temperature_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumSupplyTemperatureSetpoint { get; set; } = Double.Parse("10", CultureInfo.InvariantCulture);
        

[Description("This defines whether the chilled water return temperature target is constant, sch" +
    "eduled, or specified on the supply inlet node by a separate setpoint manager.")]
[JsonProperty(PropertyName="return_temperature_setpoint_input_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_ReturnTemperature_ChilledWater_ReturnTemperatureSetpointInputType ReturnTemperatureSetpointInputType { get; set; } = (SetpointManager_ReturnTemperature_ChilledWater_ReturnTemperatureSetpointInputType)Enum.Parse(typeof(SetpointManager_ReturnTemperature_ChilledWater_ReturnTemperatureSetpointInputType), "Constant");
        

[Description("This is the desired return temperature target, which is met by adjusting the supp" +
    "ly temperature setpoint. This constant value is only used if the Design Chilled " +
    "Water Return Temperature Input Type is Constant")]
[JsonProperty(PropertyName="return_temperature_setpoint_constant_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnTemperatureSetpointConstantValue { get; set; } = Double.Parse("13", CultureInfo.InvariantCulture);
        

[Description(@"This is the desired return temperature target, which is met by adjusting the supply temperature setpoint. This is a schedule name to allow the return temperature target value to be scheduled. This field is only used if the Design Chilled Water Return Temperature Input Type is Scheduled")]
[JsonProperty(PropertyName="return_temperature_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReturnTemperatureSetpointScheduleName { get; set; } = "";
    }
    
    public enum SetpointManager_ReturnTemperature_ChilledWater_ReturnTemperatureSetpointInputType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Constant")]
        Constant = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ReturnTemperatureSetpoint")]
        ReturnTemperatureSetpoint = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Scheduled")]
        Scheduled = 2,
    }
    
    [Description(@"This setpoint manager is used to place a temperature setpoint on a plant supply outlet node based on a target return water setpoint. The setpoint manager attempts to achieve the desired return water temperature by adjusting the supply temperature setpoint based on the plant conditions at each system time step.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SetpointManager_ReturnTemperature_HotWater
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description(@"This is the name of the supply outlet node for the plant being controlled by this setpoint manager. Typically this is where the setpoint will be actuated for supply equipment to control to, but not necessarily. This setpoint manager will mine that information from the internal plant data structures.")]
[JsonProperty(PropertyName="plant_loop_supply_outlet_node", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PlantLoopSupplyOutletNode { get; set; } = "";
        

[Description("This is the name of the supply inlet node for the plant being controlled with thi" +
    "s setpoint manager. The temperature on this node is controlled by actuating the " +
    "supply setpoint.")]
[JsonProperty(PropertyName="plant_loop_supply_inlet_node", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PlantLoopSupplyInletNode { get; set; } = "";
        

[Description("This is the minimum reset temperature for the hot water supply.")]
[JsonProperty(PropertyName="minimum_supply_temperature_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumSupplyTemperatureSetpoint { get; set; } = Double.Parse("77", CultureInfo.InvariantCulture);
        

[Description("This is the maximum hot water supply temperature setpoint. This is also used as t" +
    "he default setpoint during no-load or negative-load conditions and during initia" +
    "lization.")]
[JsonProperty(PropertyName="maximum_supply_temperature_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumSupplyTemperatureSetpoint { get; set; } = Double.Parse("82", CultureInfo.InvariantCulture);
        

[Description("This defines whether the hot water return temperature target is constant, schedul" +
    "ed, or specified on the supply inlet node by a separate setpoint manager.")]
[JsonProperty(PropertyName="return_temperature_setpoint_input_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SetpointManager_ReturnTemperature_HotWater_ReturnTemperatureSetpointInputType ReturnTemperatureSetpointInputType { get; set; } = (SetpointManager_ReturnTemperature_HotWater_ReturnTemperatureSetpointInputType)Enum.Parse(typeof(SetpointManager_ReturnTemperature_HotWater_ReturnTemperatureSetpointInputType), "Constant");
        

[Description("This is the desired return temperature target, which is met by adjusting the supp" +
    "ly temperature setpoint. This constant value is only used if the Design Hot Wate" +
    "r Return Temperature Input Type is Constant")]
[JsonProperty(PropertyName="return_temperature_setpoint_constant_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnTemperatureSetpointConstantValue { get; set; } = Double.Parse("71", CultureInfo.InvariantCulture);
        

[Description(@"This is the desired return temperature target, which is met by adjusting the supply temperature setpoint. This is a schedule name to allow the return temperature target value to be scheduled. This field is only used if the Design Hot Water Return Temperature Input Type is Scheduled")]
[JsonProperty(PropertyName="return_temperature_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReturnTemperatureSetpointScheduleName { get; set; } = "";
    }
    
    public enum SetpointManager_ReturnTemperature_HotWater_ReturnTemperatureSetpointInputType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Constant")]
        Constant = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ReturnTemperatureSetpoint")]
        ReturnTemperatureSetpoint = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Scheduled")]
        Scheduled = 2,
    }
}
