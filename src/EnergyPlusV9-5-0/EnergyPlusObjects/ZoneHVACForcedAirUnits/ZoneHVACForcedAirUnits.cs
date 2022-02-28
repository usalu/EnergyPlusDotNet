namespace EnergyPlus.ZoneHVACForcedAirUnits
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
    using EnergyPlus.ZoneHVACControlsandThermostats;
    using EnergyPlus.ZoneHVACEquipmentConnections;
    using EnergyPlus.ZoneHVACRadiativeConvectiveUnits;
    
    
    [Description(@"Ideal system used to calculate loads without modeling a full HVAC system. All that is required for the ideal system are zone controls, zone equipment configurations, and the ideal loads system component. This component can be thought of as an ideal unit that mixes zone air with the specified amount of outdoor air and then adds or removes heat and moisture at 100% efficiency in order to meet the specified controls. Energy use is reported as DistrictHeating and DistrictCooling.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_IdealLoadsAirSystem
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("Must match a zone air inlet node name.")]
[JsonProperty(PropertyName="zone_supply_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneSupplyAirNodeName { get; set; } = "";
        

[Description("Should match a zone air exhaust node name. This field is optional, but is require" +
    "d if this this object is used with other forced air equipment.")]
[JsonProperty(PropertyName="zone_exhaust_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneExhaustAirNodeName { get; set; } = "";
        

[Description(@"This field is only required when the Ideal Loads Air System is connected to an AirloopHVAC:ZoneReturnPlenum, otherwise leave this field blank. When connected to a plenum the return plenum Outlet Node Name (or Induced Air Outlet Node Name when connecting multiple ideal loads air sytems) is entered here. The two ideal loads air system node name fields described above, the Zone Supply Air Node Name and the Zone Exhaust Air Node Name must also be entered. The Zone Supply Air Node Name must match a zone inlet air node name for the zone where this Ideal Loads Air System is connected. The Zone Exhaust Air Node Name must match an inlet air node name of an AirloopHVAC:ReturnAirPlenum object.")]
[JsonProperty(PropertyName="system_inlet_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SystemInletAirNodeName { get; set; } = "";
        

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
public ZoneHVAC_IdealLoadsAirSystem_HeatingLimit HeatingLimit { get; set; } = (ZoneHVAC_IdealLoadsAirSystem_HeatingLimit)Enum.Parse(typeof(ZoneHVAC_IdealLoadsAirSystem_HeatingLimit), "NoLimit");
        

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
public ZoneHVAC_IdealLoadsAirSystem_CoolingLimit CoolingLimit { get; set; } = (ZoneHVAC_IdealLoadsAirSystem_CoolingLimit)Enum.Parse(typeof(ZoneHVAC_IdealLoadsAirSystem_CoolingLimit), "NoLimit");
        

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
public ZoneHVAC_IdealLoadsAirSystem_DehumidificationControlType DehumidificationControlType { get; set; } = (ZoneHVAC_IdealLoadsAirSystem_DehumidificationControlType)Enum.Parse(typeof(ZoneHVAC_IdealLoadsAirSystem_DehumidificationControlType), "ConstantSensibleHeatRatio");
        

[Description("This field is applicable only when Dehumidification Control Type is ConstantSensi" +
    "bleHeatRatio")]
[JsonProperty(PropertyName="cooling_sensible_heat_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingSensibleHeatRatio { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[Description(@"None means that there is no humidification. Humidistat means that there is a ZoneControl:Humidistat for this zone and the ideal loads system will attempt to satisfy the humidistat. ConstantSupplyHumidityRatio means that during heating the supply air will always be at the Maximum Heating Supply Humidity Ratio.")]
[JsonProperty(PropertyName="humidification_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_IdealLoadsAirSystem_HumidificationControlType HumidificationControlType { get; set; } = (ZoneHVAC_IdealLoadsAirSystem_HumidificationControlType)Enum.Parse(typeof(ZoneHVAC_IdealLoadsAirSystem_HumidificationControlType), "None");
        

[Description(@"When the name of a DesignSpecification:OutdoorAir object is entered, the minimum outdoor air flow rate will be computed using these specifications. The outdoor air flow rate will also be affected by the next two fields. If this field is blank, there will be no outdoor air and the remaining fields will be ignored.")]
[JsonProperty(PropertyName="design_specification_outdoor_air_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationOutdoorAirObjectName { get; set; } = "";
        

[Description("This field is required if the system provides outdoor air Enter the name of an ou" +
    "tdoor air node. This node name is also specified in an OutdoorAir:Node or Outdoo" +
    "rAir:NodeList object.")]
[JsonProperty(PropertyName="outdoor_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirInletNodeName { get; set; } = "";
        

[Description(@"This field controls how the minimum outdoor air flow rate is calculated. None means that design occupancy will be used to compute the minimum outdoor air flow rate OccupancySchedule means that current occupancy level will be used. CO2Setpoint means that the design occupancy will be used to compute the minimum outdoor air flow rate and the outdoor air flow rate may be increased if necessary to maintain the indoor air carbon dioxide setpoint defined in a ZoneControl:ContaminantController object.")]
[JsonProperty(PropertyName="demand_controlled_ventilation_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_IdealLoadsAirSystem_DemandControlledVentilationType DemandControlledVentilationType { get; set; } = (ZoneHVAC_IdealLoadsAirSystem_DemandControlledVentilationType)Enum.Parse(typeof(ZoneHVAC_IdealLoadsAirSystem_DemandControlledVentilationType), "None");
        

[Description("DifferentialDryBulb and DifferentialEnthalpy will increase the outdoor air flow r" +
    "ate when there is a cooling load and the outdoor air temperature or enthalpy is " +
    "below the zone exhaust air temperature or enthalpy.")]
[JsonProperty(PropertyName="outdoor_air_economizer_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_IdealLoadsAirSystem_OutdoorAirEconomizerType OutdoorAirEconomizerType { get; set; } = (ZoneHVAC_IdealLoadsAirSystem_OutdoorAirEconomizerType)Enum.Parse(typeof(ZoneHVAC_IdealLoadsAirSystem_OutdoorAirEconomizerType), "NoEconomizer");
        

[JsonProperty(PropertyName="heat_recovery_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_IdealLoadsAirSystem_HeatRecoveryType HeatRecoveryType { get; set; } = (ZoneHVAC_IdealLoadsAirSystem_HeatRecoveryType)Enum.Parse(typeof(ZoneHVAC_IdealLoadsAirSystem_HeatRecoveryType), "None");
        

[JsonProperty(PropertyName="sensible_heat_recovery_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SensibleHeatRecoveryEffectiveness { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[Description("Applicable only if Heat Recovery Type is Enthalpy.")]
[JsonProperty(PropertyName="latent_heat_recovery_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LatentHeatRecoveryEffectiveness { get; set; } = Double.Parse("0.65", CultureInfo.InvariantCulture);
        

[Description("Enter the name of a DesignSpecificationZoneHVACSizing object.")]
[JsonProperty(PropertyName="design_specification_zonehvac_sizing_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZonehvacSizingObjectName { get; set; } = "";
    }
    
    public enum ZoneHVAC_IdealLoadsAirSystem_HeatingLimit
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
    
    public enum ZoneHVAC_IdealLoadsAirSystem_CoolingLimit
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
    
    public enum ZoneHVAC_IdealLoadsAirSystem_DehumidificationControlType
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
    
    public enum ZoneHVAC_IdealLoadsAirSystem_HumidificationControlType
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
    
    public enum ZoneHVAC_IdealLoadsAirSystem_DemandControlledVentilationType
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
    
    public enum ZoneHVAC_IdealLoadsAirSystem_OutdoorAirEconomizerType
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
    
    public enum ZoneHVAC_IdealLoadsAirSystem_HeatRecoveryType
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
    
    [Description("Four pipe fan coil system. Forced-convection hydronic heating-cooling unit with s" +
        "upply fan, hot water heating coil, chilled water cooling coil, and fixed-positio" +
        "n outdoor air mixer.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_FourPipeFanCoil
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="capacity_control_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_FourPipeFanCoil_CapacityControlMethod CapacityControlMethod { get; set; } = (ZoneHVAC_FourPipeFanCoil_CapacityControlMethod)Enum.Parse(typeof(ZoneHVAC_FourPipeFanCoil_CapacityControlMethod), "ASHRAE90VariableFan");
        

[JsonProperty(PropertyName="maximum_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="low_speed_supply_air_flow_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LowSpeedSupplyAirFlowRatio { get; set; } = Double.Parse("0.33", CultureInfo.InvariantCulture);
        

[Description("Medium Speed Supply Air Flow Ratio should be greater than Low Speed Supply Air Fl" +
    "ow Ratio")]
[JsonProperty(PropertyName="medium_speed_supply_air_flow_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MediumSpeedSupplyAirFlowRatio { get; set; } = Double.Parse("0.66", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Value of schedule multiplies maximum outdoor air flow rate")]
[JsonProperty(PropertyName="outdoor_air_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[Description("Currently only one type OutdoorAir:Mixer object is available. This field should b" +
    "e left blank if the FanCoil is connected to central dedicated outdoor air throug" +
    "h an AirTerminal:SingleDuct:Mixer object.")]
[JsonProperty(PropertyName="outdoor_air_mixer_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_FourPipeFanCoil_OutdoorAirMixerObjectType OutdoorAirMixerObjectType { get; set; } = (ZoneHVAC_FourPipeFanCoil_OutdoorAirMixerObjectType)Enum.Parse(typeof(ZoneHVAC_FourPipeFanCoil_OutdoorAirMixerObjectType), "OutdoorAirMixer");
        

[Description(@"If this field is blank, the OutdoorAir:Mixer is not used. This optional field specifies the name of the OutdoorAir:Mixer object. When used, this name needs to match name of the OutdoorAir:Mixer object. This field should be left blank if the FanCoil is connected to central dedicated outdoor air through an AirTerminal:SingleDuct:Mixer object.")]
[JsonProperty(PropertyName="outdoor_air_mixer_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirMixerName { get; set; } = "";
        

[Description(@"Fan type must be according to capacity control method (see I/O) For ConstantFanVariableFlow a Fan:OnOff or Fan:ConstantVolume is valid. For CyclingFan a Fan:OnOff is valid. For VariableFanVariableFlow or VariableFanConstantFlow a Fan:VariableVolume is valid. For ASHRAE90.1 a Fan:OnOff or Fan:VariableVolume is valid. Fan:SystemModel is valid for all capacity control methods. The fan's inlet node should be the same as the outdoor air mixer's mixed air node.")]
[JsonProperty(PropertyName="supply_air_fan_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_FourPipeFanCoil_SupplyAirFanObjectType SupplyAirFanObjectType { get; set; } = (ZoneHVAC_FourPipeFanCoil_SupplyAirFanObjectType)Enum.Parse(typeof(ZoneHVAC_FourPipeFanCoil_SupplyAirFanObjectType), "FanConstantVolume");
        

[JsonProperty(PropertyName="supply_air_fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanName { get; set; } = "";
        

[JsonProperty(PropertyName="cooling_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_FourPipeFanCoil_CoolingCoilObjectType CoolingCoilObjectType { get; set; } = (ZoneHVAC_FourPipeFanCoil_CoolingCoilObjectType)Enum.Parse(typeof(ZoneHVAC_FourPipeFanCoil_CoolingCoilObjectType), "CoilCoolingWater");
        

[JsonProperty(PropertyName="cooling_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilName { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_cold_water_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumColdWaterFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_cold_water_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumColdWaterFlowRate { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cooling_convergence_tolerance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingConvergenceTolerance { get; set; } = Double.Parse("0.001", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_FourPipeFanCoil_HeatingCoilObjectType HeatingCoilObjectType { get; set; } = (ZoneHVAC_FourPipeFanCoil_HeatingCoilObjectType)Enum.Parse(typeof(ZoneHVAC_FourPipeFanCoil_HeatingCoilObjectType), "CoilHeatingElectric");
        

[JsonProperty(PropertyName="heating_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilName { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_hot_water_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumHotWaterFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_hot_water_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumHotWaterFlowRate { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_convergence_tolerance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingConvergenceTolerance { get; set; } = Double.Parse("0.001", CultureInfo.InvariantCulture);
        

[Description("Enter the name of an AvailabilityManagerAssignmentList object.")]
[JsonProperty(PropertyName="availability_manager_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityManagerListName { get; set; } = "";
        

[Description("Enter the name of a DesignSpecificationZoneHVACSizing object.")]
[JsonProperty(PropertyName="design_specification_zonehvac_sizing_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZonehvacSizingObjectName { get; set; } = "";
        

[Description(@"Enter the name of a schedule that controls fan operation. Schedule Name values of 0 denote cycling fan operation (fan cycles with cooling coil). Schedule values greater than 0 denote constant fan operation (fan runs continually regardless of coil operation). The fan operating mode defaults to cycling fan operation if this field is left blank. This input field is currently used with MultiStageFan capacity control method")]
[JsonProperty(PropertyName="supply_air_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanOperatingModeScheduleName { get; set; } = "";
        

[Description("For Capacity Control Method = ASHRAE90VariableFan, enter the minimum air temperat" +
    "ure in cooling mode. Leave this field blank or enter 0 to control to the zone lo" +
    "ad per ASHRAE 90.1. In this case, a zone sizing simulation is required.")]
[JsonProperty(PropertyName="minimum_supply_air_temperature_in_cooling_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MinimumSupplyAirTemperatureInCoolingMode { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("For Capacity Control Method = ASHRAE90VariableFan, enter the maximum air temperat" +
    "ure in heating mode. Leave this field blank or enter 0 to control to the zone lo" +
    "ad per ASHRAE 90.1. In this case, a zone sizing simulation is required.")]
[JsonProperty(PropertyName="maximum_supply_air_temperature_in_heating_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumSupplyAirTemperatureInHeatingMode { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
    }
    
    public enum ZoneHVAC_FourPipeFanCoil_CapacityControlMethod
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
    
    public enum ZoneHVAC_FourPipeFanCoil_OutdoorAirMixerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAir:Mixer")]
        OutdoorAirMixer = 0,
    }
    
    public enum ZoneHVAC_FourPipeFanCoil_SupplyAirFanObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:ConstantVolume")]
        FanConstantVolume = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:OnOff")]
        FanOnOff = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:SystemModel")]
        FanSystemModel = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:VariableVolume")]
        FanVariableVolume = 3,
    }
    
    public enum ZoneHVAC_FourPipeFanCoil_CoolingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water")]
        CoilCoolingWater = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water:DetailedGeometry")]
        CoilCoolingWaterDetailedGeometry = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:Water:HeatExchangerAssisted")]
        CoilSystemCoolingWaterHeatExchangerAssisted = 2,
    }
    
    public enum ZoneHVAC_FourPipeFanCoil_HeatingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric")]
        CoilHeatingElectric = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Water")]
        CoilHeatingWater = 1,
    }
    
    [Description("Window air conditioner. Forced-convection cooling-only unit with supply fan, dire" +
        "ct expansion (DX) cooling coil, and fixed-position outdoor air mixer.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_WindowAirConditioner
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[Description("currently only one OutdoorAir:Mixer object type is available.")]
[JsonProperty(PropertyName="outdoor_air_mixer_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_WindowAirConditioner_OutdoorAirMixerObjectType OutdoorAirMixerObjectType { get; set; } = (ZoneHVAC_WindowAirConditioner_OutdoorAirMixerObjectType)Enum.Parse(typeof(ZoneHVAC_WindowAirConditioner_OutdoorAirMixerObjectType), "OutdoorAirMixer");
        

[JsonProperty(PropertyName="outdoor_air_mixer_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirMixerName { get; set; } = "";
        

[Description(@"Fan:ConstantVolume only works when continuous fan operation is used the entire simulation (all supply air fan operating mode schedule values are greater than 0). If any fan operating mode schedule values are 0 a Fan:SystemModel or Fan:OnOff object must be used.")]
[JsonProperty(PropertyName="supply_air_fan_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_WindowAirConditioner_SupplyAirFanObjectType SupplyAirFanObjectType { get; set; } = (ZoneHVAC_WindowAirConditioner_SupplyAirFanObjectType)Enum.Parse(typeof(ZoneHVAC_WindowAirConditioner_SupplyAirFanObjectType), "FanConstantVolume");
        

[Description("Fan type Fan:ConstantVolume is used with continuous fan and fan type Fan:OnOff is" +
    " used with cycling Fan.")]
[JsonProperty(PropertyName="supply_air_fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanName { get; set; } = "";
        

[JsonProperty(PropertyName="cooling_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_WindowAirConditioner_CoolingCoilObjectType CoolingCoilObjectType { get; set; } = (ZoneHVAC_WindowAirConditioner_CoolingCoilObjectType)Enum.Parse(typeof(ZoneHVAC_WindowAirConditioner_CoolingCoilObjectType), "CoilCoolingDXSingleSpeed");
        

[JsonProperty(PropertyName="dx_cooling_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DxCoolingCoilName { get; set; } = "";
        

[Description(@"Enter the name of a schedule that controls fan operation. Schedule Name values of 0 denote cycling fan operation (fan cycles with cooling coil). Schedule values greater than 0 denote constant fan operation (fan runs continually regardless of coil operation). The fan operating mode defaults to cycling fan operation if this field is left blank.")]
[JsonProperty(PropertyName="supply_air_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanOperatingModeScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_WindowAirConditioner_FanPlacement FanPlacement { get; set; } = (ZoneHVAC_WindowAirConditioner_FanPlacement)Enum.Parse(typeof(ZoneHVAC_WindowAirConditioner_FanPlacement), "BlowThrough");
        

[JsonProperty(PropertyName="cooling_convergence_tolerance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingConvergenceTolerance { get; set; } = Double.Parse("0.001", CultureInfo.InvariantCulture);
        

[Description("Enter the name of an AvailabilityManagerAssignmentList object.")]
[JsonProperty(PropertyName="availability_manager_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityManagerListName { get; set; } = "";
        

[Description("Enter the name of a DesignSpecificationZoneHVACSizing object.")]
[JsonProperty(PropertyName="design_specification_zonehvac_sizing_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZonehvacSizingObjectName { get; set; } = "";
    }
    
    public enum ZoneHVAC_WindowAirConditioner_OutdoorAirMixerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAir:Mixer")]
        OutdoorAirMixer = 0,
    }
    
    public enum ZoneHVAC_WindowAirConditioner_SupplyAirFanObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:ConstantVolume")]
        FanConstantVolume = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:OnOff")]
        FanOnOff = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:SystemModel")]
        FanSystemModel = 2,
    }
    
    public enum ZoneHVAC_WindowAirConditioner_CoolingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:SingleSpeed")]
        CoilCoolingDXSingleSpeed = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:VariableSpeed")]
        CoilCoolingDXVariableSpeed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:DX:HeatExchangerAssisted")]
        CoilSystemCoolingDXHeatExchangerAssisted = 2,
    }
    
    public enum ZoneHVAC_WindowAirConditioner_FanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 1,
    }
    
    [Description("Packaged terminal air conditioner (PTAC). Forced-convection heating-cooling unit " +
        "with supply fan, direct expansion (DX) cooling coil, heating coil (gas, electric" +
        ", hot water, or steam) and fixed-position outdoor air mixer.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_PackagedTerminalAirConditioner
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available. Schedule va" +
    "lues of 0 denote the unit is off.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("Air inlet node for the PTAC must be a zone air exhaust Node.")]
[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[Description("Air outlet node for the PTAC must be a zone air inlet node.")]
[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[Description("Currently only one OutdoorAir:Mixer object type is available. This field should b" +
    "e left blank if the PTAC is connected to central dedicated outdoor air through a" +
    "n AirTerminal:SingleDuct:Mixer object.")]
[JsonProperty(PropertyName="outdoor_air_mixer_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_PackagedTerminalAirConditioner_OutdoorAirMixerObjectType OutdoorAirMixerObjectType { get; set; } = (ZoneHVAC_PackagedTerminalAirConditioner_OutdoorAirMixerObjectType)Enum.Parse(typeof(ZoneHVAC_PackagedTerminalAirConditioner_OutdoorAirMixerObjectType), "OutdoorAirMixer");
        

[Description(@"If this field is blank, the OutdoorAir:Mixer is not used. This optional field specifies the name of the OutdoorAir:Mixer object. When used, this name needs to match name of the OutdoorAir:Mixer object. This field should be left blank if the PTAC is connected to central dedicated outdoor air through an AirTerminal:SingleDuct:Mixer object.")]
[JsonProperty(PropertyName="outdoor_air_mixer_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirMixerName { get; set; } = "";
        

[Description("Must be less than or equal to fan size.")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Must be less than or equal to fan size.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Must be less than or equal to fan size. Only used when supply air fan operating mode schedule values specify continuous fan (schedule values greater than 0 specify continuous fan operation). This air flow rate is used when no heating or cooling is required and the cooling or heating coil is off. If this field is left blank or zero, the supply air flow rate from the previous on cycle (either cooling or heating) is used.")]
[JsonProperty(PropertyName="no_load_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoLoadSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Must be less than or equal to supply air flow rate during cooling operation. This" +
    " field is set to zero flow when the PTAC is connected to central dedicated outdo" +
    "or air through air terminal single duct mixer object.")]
[JsonProperty(PropertyName="cooling_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Must be less than or equal to supply air flow rate during heating operation. This" +
    " field is set to zero flow when the PTAC is connected to central dedicated outdo" +
    "or air through air terminal single duct mixer object.")]
[JsonProperty(PropertyName="heating_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Only used when supply air fan operating mode schedule values specify continuous fan (schedule values greater than 0 specify continuous fan operation). This air flow rate is used when no heating or cooling is required and the cooling or heating coil is off. If this field is left blank or zero, the outdoor air flow rate from the previous on cycle (either cooling or heating) is used. This field is set to zero flow when the PTAC is connected to central dedicated outdoor air through air terminal single duct mixer object.")]
[JsonProperty(PropertyName="no_load_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoLoadOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Fan:ConstantVolume only works when continuous fan operation is used the entire simulation (all supply air fan operating mode schedule values are greater than 0). If any fan operating mode schedule values are 0 a Fan:SystemModel or Fan:OnOff object must be used.")]
[JsonProperty(PropertyName="supply_air_fan_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_PackagedTerminalAirConditioner_SupplyAirFanObjectType SupplyAirFanObjectType { get; set; } = (ZoneHVAC_PackagedTerminalAirConditioner_SupplyAirFanObjectType)Enum.Parse(typeof(ZoneHVAC_PackagedTerminalAirConditioner_SupplyAirFanObjectType), "FanConstantVolume");
        

[Description("Needs to match in the fan object.")]
[JsonProperty(PropertyName="supply_air_fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanName { get; set; } = "";
        

[Description("Select the type of heating coil.")]
[JsonProperty(PropertyName="heating_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_PackagedTerminalAirConditioner_HeatingCoilObjectType HeatingCoilObjectType { get; set; } = (ZoneHVAC_PackagedTerminalAirConditioner_HeatingCoilObjectType)Enum.Parse(typeof(ZoneHVAC_PackagedTerminalAirConditioner_HeatingCoilObjectType), "CoilHeatingElectric");
        

[Description("Needs to match in the heating coil object.")]
[JsonProperty(PropertyName="heating_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilName { get; set; } = "";
        

[Description("Select the type of Cooling Coil. Only works with Coil:Cooling:DX:SingleSpeed or C" +
    "oilSystem:Cooling:DX:HeatExchangerAssisted or Coil:Cooling:DX:VariableSpeed.")]
[JsonProperty(PropertyName="cooling_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_PackagedTerminalAirConditioner_CoolingCoilObjectType CoolingCoilObjectType { get; set; } = (ZoneHVAC_PackagedTerminalAirConditioner_CoolingCoilObjectType)Enum.Parse(typeof(ZoneHVAC_PackagedTerminalAirConditioner_CoolingCoilObjectType), "CoilCoolingDXSingleSpeed");
        

[Description("Needs to match a DX cooling coil object.")]
[JsonProperty(PropertyName="cooling_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilName { get; set; } = "";
        

[Description("Select fan placement as either blow through or draw through.")]
[JsonProperty(PropertyName="fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_PackagedTerminalAirConditioner_FanPlacement FanPlacement { get; set; } = (ZoneHVAC_PackagedTerminalAirConditioner_FanPlacement)Enum.Parse(typeof(ZoneHVAC_PackagedTerminalAirConditioner_FanPlacement), "DrawThrough");
        

[Description(@"Enter the name of a schedule that controls fan operation. Schedule Name values of 0 denote cycling fan operation (fan cycles with cooling or heating coil). Schedule Name values greater than 0 denote constant fan operation (fan runs continually regardless of coil operation).")]
[JsonProperty(PropertyName="supply_air_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanOperatingModeScheduleName { get; set; } = "";
        

[Description("Enter the name of an AvailabilityManagerAssignmentList object.")]
[JsonProperty(PropertyName="availability_manager_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityManagerListName { get; set; } = "";
        

[Description("Enter the name of a DesignSpecificationZoneHVACSizing object.")]
[JsonProperty(PropertyName="design_specification_zonehvac_sizing_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZonehvacSizingObjectName { get; set; } = "";
        

[JsonProperty(PropertyName="capacity_control_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_PackagedTerminalAirConditioner_CapacityControlMethod CapacityControlMethod { get; set; } = (ZoneHVAC_PackagedTerminalAirConditioner_CapacityControlMethod)Enum.Parse(typeof(ZoneHVAC_PackagedTerminalAirConditioner_CapacityControlMethod), "None");
        

[Description("For Capacity Control Method = SingleZoneVAV, enter the minimum air temperature li" +
    "mit for reduced fan speed.")]
[JsonProperty(PropertyName="minimum_supply_air_temperature_in_cooling_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MinimumSupplyAirTemperatureInCoolingMode { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("For Capacity Control Method = SingleZoneVAV, enter the maximum air temperature li" +
    "mit for reduced fan speed.")]
[JsonProperty(PropertyName="maximum_supply_air_temperature_in_heating_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumSupplyAirTemperatureInHeatingMode { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
    }
    
    public enum ZoneHVAC_PackagedTerminalAirConditioner_OutdoorAirMixerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAir:Mixer")]
        OutdoorAirMixer = 0,
    }
    
    public enum ZoneHVAC_PackagedTerminalAirConditioner_SupplyAirFanObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:ConstantVolume")]
        FanConstantVolume = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:OnOff")]
        FanOnOff = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:SystemModel")]
        FanSystemModel = 2,
    }
    
    public enum ZoneHVAC_PackagedTerminalAirConditioner_HeatingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric")]
        CoilHeatingElectric = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Fuel")]
        CoilHeatingFuel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Steam")]
        CoilHeatingSteam = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Water")]
        CoilHeatingWater = 3,
    }
    
    public enum ZoneHVAC_PackagedTerminalAirConditioner_CoolingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:SingleSpeed")]
        CoilCoolingDXSingleSpeed = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:VariableSpeed")]
        CoilCoolingDXVariableSpeed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:DX:HeatExchangerAssisted")]
        CoilSystemCoolingDXHeatExchangerAssisted = 2,
    }
    
    public enum ZoneHVAC_PackagedTerminalAirConditioner_FanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum ZoneHVAC_PackagedTerminalAirConditioner_CapacityControlMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SingleZoneVAV")]
        SingleZoneVAV = 2,
    }
    
    [Description(@"Packaged terminal heat pump (PTHP). Forced-convection heating-cooling unit with supply fan, direct expansion (DX) cooling coil, DX heating coil (air-to-air heat pump), supplemental heating coil (gas, electric, hot water, or steam), and fixed-position outdoor air mixer.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_PackagedTerminalHeatPump
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available. Schedule va" +
    "lues of 0 denote the unit is off.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("Air inlet node for the PTHP must be a zone air exhaust node.")]
[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[Description("Air outlet node for the PTHP must be a zone air inlet node.")]
[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[Description("Currently only one OutdoorAir:Mixer object type is available. This field should b" +
    "e left blank if the PTHP is connected to central dedicated outdoor air through a" +
    "n AirTerminal:SingleDuct:Mixer object.")]
[JsonProperty(PropertyName="outdoor_air_mixer_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_PackagedTerminalHeatPump_OutdoorAirMixerObjectType OutdoorAirMixerObjectType { get; set; } = (ZoneHVAC_PackagedTerminalHeatPump_OutdoorAirMixerObjectType)Enum.Parse(typeof(ZoneHVAC_PackagedTerminalHeatPump_OutdoorAirMixerObjectType), "OutdoorAirMixer");
        

[Description(@"If this field is blank, the OutdoorAir:Mixer is not used. This optional field specifies the name of the OutdoorAir:Mixer object. When used, this name needs to match name of the OutdoorAir:Mixer object. This field should be left blank if the PTHP is connected to central dedicated outdoor air through an AirTerminal:SingleDuct:Mixer object.")]
[JsonProperty(PropertyName="outdoor_air_mixer_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirMixerName { get; set; } = "";
        

[Description("Must be less than or equal to fan size.")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Must be less than or equal to fan size.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Must be less than or equal to fan size. Only used when heat pump fan operating mode is continuous. This air flow rate is used when no heating or cooling is required and the DX coil compressor is off. If this field is left blank or zero, the supply air flow rate from the previous on cycle (either cooling or heating) is used.")]
[JsonProperty(PropertyName="no_load_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoLoadSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Must be less than or equal to supply air flow rate during cooling operation. This" +
    " field is set to zero flow when the PTHP is connected to central dedicated outdo" +
    "or air through air terminal single duct mixer object.")]
[JsonProperty(PropertyName="cooling_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Must be less than or equal to supply air flow rate during heating operation. This" +
    " field is set to zero flow when the PTHP is connected to central dedicated outdo" +
    "or air through air terminal single duct mixer object.")]
[JsonProperty(PropertyName="heating_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Only used when heat pump Fan operating mode is continuous. This air flow rate is used when no heating or cooling is required and the DX coil compressor is off. If this field is left blank or zero, the outdoor air flow rate from the previous on cycle (either cooling or heating) is used. This field is set to zero flow when the PTHP is connected to central dedicated outdoor air through air terminal single duct mixer object.")]
[JsonProperty(PropertyName="no_load_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoLoadOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Fan:ConstantVolume only works with fan operating mode is continuous.")]
[JsonProperty(PropertyName="supply_air_fan_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_PackagedTerminalHeatPump_SupplyAirFanObjectType SupplyAirFanObjectType { get; set; } = (ZoneHVAC_PackagedTerminalHeatPump_SupplyAirFanObjectType)Enum.Parse(typeof(ZoneHVAC_PackagedTerminalHeatPump_SupplyAirFanObjectType), "FanConstantVolume");
        

[Description("Needs to match a fan object.")]
[JsonProperty(PropertyName="supply_air_fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanName { get; set; } = "";
        

[Description("Only works with Coil:Heating:DX:SingleSpeed or Coil:Heating:DX:VariableSpeed.")]
[JsonProperty(PropertyName="heating_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_PackagedTerminalHeatPump_HeatingCoilObjectType HeatingCoilObjectType { get; set; } = (ZoneHVAC_PackagedTerminalHeatPump_HeatingCoilObjectType)Enum.Parse(typeof(ZoneHVAC_PackagedTerminalHeatPump_HeatingCoilObjectType), "CoilHeatingDXSingleSpeed");
        

[Description("Needs to match in the DX Heating Coil object.")]
[JsonProperty(PropertyName="heating_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilName { get; set; } = "";
        

[Description("Defines Heating convergence tolerance as a fraction of Heating load to be met.")]
[JsonProperty(PropertyName="heating_convergence_tolerance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingConvergenceTolerance { get; set; } = Double.Parse("0.001", CultureInfo.InvariantCulture);
        

[Description("Only works with Coil:Cooling:DX:SingleSpeed or CoilSystem:Cooling:DX:HeatExchange" +
    "rAssisted or Coil:Cooling:DX:VariableSpeed.")]
[JsonProperty(PropertyName="cooling_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_PackagedTerminalHeatPump_CoolingCoilObjectType CoolingCoilObjectType { get; set; } = (ZoneHVAC_PackagedTerminalHeatPump_CoolingCoilObjectType)Enum.Parse(typeof(ZoneHVAC_PackagedTerminalHeatPump_CoolingCoilObjectType), "CoilCoolingDXSingleSpeed");
        

[Description("Needs to match in the DX Cooling Coil object.")]
[JsonProperty(PropertyName="cooling_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilName { get; set; } = "";
        

[Description("Defines Cooling convergence tolerance as a fraction of the Cooling load to be met" +
    ".")]
[JsonProperty(PropertyName="cooling_convergence_tolerance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingConvergenceTolerance { get; set; } = Double.Parse("0.001", CultureInfo.InvariantCulture);
        

[Description("works with gas, electric, hot water and steam heating coil.")]
[JsonProperty(PropertyName="supplemental_heating_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_PackagedTerminalHeatPump_SupplementalHeatingCoilObjectType SupplementalHeatingCoilObjectType { get; set; } = (ZoneHVAC_PackagedTerminalHeatPump_SupplementalHeatingCoilObjectType)Enum.Parse(typeof(ZoneHVAC_PackagedTerminalHeatPump_SupplementalHeatingCoilObjectType), "CoilHeatingElectric");
        

[Description("Needs to match in the supplemental heating coil object.")]
[JsonProperty(PropertyName="supplemental_heating_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplementalHeatingCoilName { get; set; } = "";
        

[Description("Supply air temperature from the supplemental heater will not exceed this value.")]
[JsonProperty(PropertyName="maximum_supply_air_temperature_from_supplemental_heater", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumSupplyAirTemperatureFromSupplementalHeater { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Supplemental heater will not operate when outdoor temperature exceeds this value." +
    "")]
[JsonProperty(PropertyName="maximum_outdoor_dry_bulb_temperature_for_supplemental_heater_operation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumOutdoorDryBulbTemperatureForSupplementalHeaterOperation { get; set; } = Double.Parse("21", CultureInfo.InvariantCulture);
        

[Description("Select fan placement as either blow through or draw through.")]
[JsonProperty(PropertyName="fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_PackagedTerminalHeatPump_FanPlacement FanPlacement { get; set; } = (ZoneHVAC_PackagedTerminalHeatPump_FanPlacement)Enum.Parse(typeof(ZoneHVAC_PackagedTerminalHeatPump_FanPlacement), "DrawThrough");
        

[Description(@"Enter the name of a schedule that controls fan operation. Schedule values of 0 denote cycling fan operation (fan cycles with cooling or heating coil). Schedule Name values greater than 0 denote constant fan operation (fan runs continually regardless of coil operation). The fan operating mode defaults to cycling fan operation if this field is left blank.")]
[JsonProperty(PropertyName="supply_air_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanOperatingModeScheduleName { get; set; } = "";
        

[Description("Enter the name of an AvailabilityManagerAssignmentList object.")]
[JsonProperty(PropertyName="availability_manager_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityManagerListName { get; set; } = "";
        

[Description("Enter the name of a DesignSpecificationZoneHVACSizing object.")]
[JsonProperty(PropertyName="design_specification_zonehvac_sizing_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZonehvacSizingObjectName { get; set; } = "";
        

[JsonProperty(PropertyName="capacity_control_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_PackagedTerminalHeatPump_CapacityControlMethod CapacityControlMethod { get; set; } = (ZoneHVAC_PackagedTerminalHeatPump_CapacityControlMethod)Enum.Parse(typeof(ZoneHVAC_PackagedTerminalHeatPump_CapacityControlMethod), "None");
        

[Description("For Capacity Control Method = SingleZoneVAV, enter the minimum air temperature li" +
    "mit for reduced fan speed.")]
[JsonProperty(PropertyName="minimum_supply_air_temperature_in_cooling_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MinimumSupplyAirTemperatureInCoolingMode { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("For Capacity Control Method = SingleZoneVAV, enter the maximum air temperature li" +
    "mit for reduced fan speed.")]
[JsonProperty(PropertyName="maximum_supply_air_temperature_in_heating_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumSupplyAirTemperatureInHeatingMode { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
    }
    
    public enum ZoneHVAC_PackagedTerminalHeatPump_OutdoorAirMixerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAir:Mixer")]
        OutdoorAirMixer = 0,
    }
    
    public enum ZoneHVAC_PackagedTerminalHeatPump_SupplyAirFanObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:ConstantVolume")]
        FanConstantVolume = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:OnOff")]
        FanOnOff = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:SystemModel")]
        FanSystemModel = 2,
    }
    
    public enum ZoneHVAC_PackagedTerminalHeatPump_HeatingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:DX:SingleSpeed")]
        CoilHeatingDXSingleSpeed = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:DX:VariableSpeed")]
        CoilHeatingDXVariableSpeed = 1,
    }
    
    public enum ZoneHVAC_PackagedTerminalHeatPump_CoolingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:SingleSpeed")]
        CoilCoolingDXSingleSpeed = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:VariableSpeed")]
        CoilCoolingDXVariableSpeed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:DX:HeatExchangerAssisted")]
        CoilSystemCoolingDXHeatExchangerAssisted = 2,
    }
    
    public enum ZoneHVAC_PackagedTerminalHeatPump_SupplementalHeatingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric")]
        CoilHeatingElectric = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Fuel")]
        CoilHeatingFuel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Steam")]
        CoilHeatingSteam = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Water")]
        CoilHeatingWater = 3,
    }
    
    public enum ZoneHVAC_PackagedTerminalHeatPump_FanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum ZoneHVAC_PackagedTerminalHeatPump_CapacityControlMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SingleZoneVAV")]
        SingleZoneVAV = 2,
    }
    
    [Description("Water-to-air heat pump. Forced-convection heating-cooling unit with supply fan, w" +
        "ater-to-air cooling and heating coils, supplemental heating coil (gas, electric," +
        " hot water, or steam), and fixed-position outdoor air mixer.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_WaterToAirHeatPump
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[Description("Currently only one OutdoorAir:Mixer object type is available. This field should b" +
    "e left blank if the WSHP is connected to central dedicated outdoor air through a" +
    "n AirTerminal:SingleDuct:Mixer object.")]
[JsonProperty(PropertyName="outdoor_air_mixer_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_WaterToAirHeatPump_OutdoorAirMixerObjectType OutdoorAirMixerObjectType { get; set; } = (ZoneHVAC_WaterToAirHeatPump_OutdoorAirMixerObjectType)Enum.Parse(typeof(ZoneHVAC_WaterToAirHeatPump_OutdoorAirMixerObjectType), "OutdoorAirMixer");
        

[Description(@"If this field is blank, the OutdoorAir:Mixer is not used. This optional field specifies the name of the OutdoorAir:Mixer object. When used, this name needs to match name of the OutdoorAir:Mixer object. This field should be left blank if the WSHP is connected to central dedicated outdoor air through an AirTerminal:SingleDuct:Mixer object.")]
[JsonProperty(PropertyName="outdoor_air_mixer_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirMixerName { get; set; } = "";
        

[Description("Must be less than or equal to fan size.")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Must be less than or equal to fan size.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Must be less than or equal to fan size. Only used when heat pump fan operating mode is continuous. This air flow rate is used when no heating or cooling is required and the DX coil compressor is off. If this field is left blank or zero, the supply air flow rate from the previous on cycle (either cooling or heating) is used.")]
[JsonProperty(PropertyName="no_load_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoLoadSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Must be less than or equal to supply air flow rate during cooling operation. This" +
    " field is set to zero flow when the WSHP is connected to central dedicated outdo" +
    "or air through air terminal single duct mixer object.")]
[JsonProperty(PropertyName="cooling_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Must be less than or equal to supply air flow rate during heating operation. This" +
    " field is set to zero flow when the WSHP is connected to central dedicated outdo" +
    "or air through air terminal single duct mixer object.")]
[JsonProperty(PropertyName="heating_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Only used when heat pump Fan operating mode is continuous. This air flow rate is used when no heating or cooling is required and the DX coil compressor is off. If this field is left blank or zero, the outdoor air flow rate from the previous on cycle (either cooling or heating) is used. This field is set to zero flow when the PTHP is connected to central dedicated outdoor air through air terminal single duct mixer object.")]
[JsonProperty(PropertyName="no_load_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoLoadOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_air_fan_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_WaterToAirHeatPump_SupplyAirFanObjectType SupplyAirFanObjectType { get; set; } = (ZoneHVAC_WaterToAirHeatPump_SupplyAirFanObjectType)Enum.Parse(typeof(ZoneHVAC_WaterToAirHeatPump_SupplyAirFanObjectType), "FanOnOff");
        

[Description("Needs to match Fan:SystemModel or Fan:OnOff object")]
[JsonProperty(PropertyName="supply_air_fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanName { get; set; } = "";
        

[JsonProperty(PropertyName="heating_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_WaterToAirHeatPump_HeatingCoilObjectType HeatingCoilObjectType { get; set; } = (ZoneHVAC_WaterToAirHeatPump_HeatingCoilObjectType)Enum.Parse(typeof(ZoneHVAC_WaterToAirHeatPump_HeatingCoilObjectType), "CoilHeatingWaterToAirHeatPumpEquationFit");
        

[Description("Needs to match in the water-to-air heat pump heating coil object")]
[JsonProperty(PropertyName="heating_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilName { get; set; } = "";
        

[JsonProperty(PropertyName="cooling_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_WaterToAirHeatPump_CoolingCoilObjectType CoolingCoilObjectType { get; set; } = (ZoneHVAC_WaterToAirHeatPump_CoolingCoilObjectType)Enum.Parse(typeof(ZoneHVAC_WaterToAirHeatPump_CoolingCoilObjectType), "CoilCoolingWaterToAirHeatPumpEquationFit");
        

[Description("Needs to match in the water-to-air heat pump cooling coil object")]
[JsonProperty(PropertyName="cooling_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilName { get; set; } = "";
        

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
        

[Description("works with gas, electric, hot water and steam heating coils")]
[JsonProperty(PropertyName="supplemental_heating_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_WaterToAirHeatPump_SupplementalHeatingCoilObjectType SupplementalHeatingCoilObjectType { get; set; } = (ZoneHVAC_WaterToAirHeatPump_SupplementalHeatingCoilObjectType)Enum.Parse(typeof(ZoneHVAC_WaterToAirHeatPump_SupplementalHeatingCoilObjectType), "CoilHeatingElectric");
        

[Description("Needs to match in the supplemental heating coil object")]
[JsonProperty(PropertyName="supplemental_heating_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplementalHeatingCoilName { get; set; } = "";
        

[Description("Supply air temperature from the supplemental heater will not exceed this value.")]
[JsonProperty(PropertyName="maximum_supply_air_temperature_from_supplemental_heater", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumSupplyAirTemperatureFromSupplementalHeater { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_outdoor_dry_bulb_temperature_for_supplemental_heater_operation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumOutdoorDryBulbTemperatureForSupplementalHeaterOperation { get; set; } = Double.Parse("21", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="outdoor_dry_bulb_temperature_sensor_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorDryBulbTemperatureSensorNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_WaterToAirHeatPump_FanPlacement FanPlacement { get; set; } = (ZoneHVAC_WaterToAirHeatPump_FanPlacement)Enum.Parse(typeof(ZoneHVAC_WaterToAirHeatPump_FanPlacement), "BlowThrough");
        

[Description(@"Enter the name of a schedule that controls fan operation. Schedule values of 0 denote cycling fan operation (fan cycles with cooling or heating coil). Schedule values greater than 0 denote constant fan operation (fan runs continually regardless of coil operation). The fan operating mode defaults to cycling fan operation if this field is left blank.")]
[JsonProperty(PropertyName="supply_air_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanOperatingModeScheduleName { get; set; } = "";
        

[Description("Enter the name of an AvailabilityManagerAssignmentList object.")]
[JsonProperty(PropertyName="availability_manager_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityManagerListName { get; set; } = "";
        

[Description(@"used only when the heat pump coils are of the type WaterToAirHeatPump:EquationFit Constant results in 100% water flow regardless of compressor PLR Cycling results in water flow that matches compressor PLR ConstantOnDemand results in 100% water flow whenever the coil is on, but is 0% whenever the coil has no load")]
[JsonProperty(PropertyName="heat_pump_coil_water_flow_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_WaterToAirHeatPump_HeatPumpCoilWaterFlowMode HeatPumpCoilWaterFlowMode { get; set; } = (ZoneHVAC_WaterToAirHeatPump_HeatPumpCoilWaterFlowMode)Enum.Parse(typeof(ZoneHVAC_WaterToAirHeatPump_HeatPumpCoilWaterFlowMode), "Cycling");
        

[Description("Enter the name of a DesignSpecificationZoneHVACSizing object.")]
[JsonProperty(PropertyName="design_specification_zonehvac_sizing_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZonehvacSizingObjectName { get; set; } = "";
    }
    
    public enum ZoneHVAC_WaterToAirHeatPump_OutdoorAirMixerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAir:Mixer")]
        OutdoorAirMixer = 0,
    }
    
    public enum ZoneHVAC_WaterToAirHeatPump_SupplyAirFanObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:OnOff")]
        FanOnOff = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:SystemModel")]
        FanSystemModel = 1,
    }
    
    public enum ZoneHVAC_WaterToAirHeatPump_HeatingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:WaterToAirHeatPump:EquationFit")]
        CoilHeatingWaterToAirHeatPumpEquationFit = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:WaterToAirHeatPump:VariableSpeedEquationFit")]
        CoilHeatingWaterToAirHeatPumpVariableSpeedEquationFit = 1,
    }
    
    public enum ZoneHVAC_WaterToAirHeatPump_CoolingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:WaterToAirHeatPump:EquationFit")]
        CoilCoolingWaterToAirHeatPumpEquationFit = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:WaterToAirHeatPump:VariableSpeedEquationFit")]
        CoilCoolingWaterToAirHeatPumpVariableSpeedEquationFit = 1,
    }
    
    public enum ZoneHVAC_WaterToAirHeatPump_SupplementalHeatingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric")]
        CoilHeatingElectric = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Fuel")]
        CoilHeatingFuel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Steam")]
        CoilHeatingSteam = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Water")]
        CoilHeatingWater = 3,
    }
    
    public enum ZoneHVAC_WaterToAirHeatPump_FanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum ZoneHVAC_WaterToAirHeatPump_HeatPumpCoilWaterFlowMode
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
    
    [Description(@"This object calculates the performance of zone (room) air dehumidifiers. Meant to model conventional direct expansion (DX) cooling-based room air dehumidifiers (reject 100% of condenser heat to the zone air), but this object might be able to be used to model other room air dehumidifier types.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_Dehumidifier_DX
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description(@"Availability schedule name for this system. Schedule value > 0 means the system is available. If this field is blank, the system is always available. Schedule values of 0 denote the unit is off. Schedule values >0.0 (usually 1.0) indicate that the dehumidifier is available to operate.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("Air inlet node for the dehumidifier must be a zone air exhaust node.")]
[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[Description("Air outlet node for the dehumidifier must be a zone air inlet node.")]
[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[Description("Rating point: air entering dehumidifier at 26.7 C (80 F) dry-bulb and 60% relativ" +
    "e humidity.")]
[JsonProperty(PropertyName="rated_water_removal", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedWaterRemoval { get; set; } = null;
        

[Description("Rating point: air entering dehumidifier at 26.7 C (80 F) dry-bulb and 60% relativ" +
    "e humidity.")]
[JsonProperty(PropertyName="rated_energy_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedEnergyFactor { get; set; } = null;
        

[JsonProperty(PropertyName="rated_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedAirFlowRate { get; set; } = null;
        

[Description(@"Name of a curve that describes the water removal rate (normalized to rated conditions) as a function of the dry-bulb temperature and relative humidity of the air entering the dehumidifier. Curve output = (actual water removal/rated water removal) = a + b*T + c*T**2 + d*RH + e*RH**2 + f*T*RH T = inlet air dry-bulb temperature (C) RH = inlet air RH (%)")]
[JsonProperty(PropertyName="water_removal_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterRemovalCurveName { get; set; } = "";
        

[Description(@"Name of a curve that describes the energy factor (normalized to rated conditions) as a function of the dry-bulb temperature and relative humidity of the air entering the dehumidifier. Curve output = (actual energy factor/rated energy factor) = a + b*T + c*T**2 + d*RH + e*RH**2 + f*T*RH T = inlet air dry-bulb temperature (C) RH = inlet air RH (%)")]
[JsonProperty(PropertyName="energy_factor_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EnergyFactorCurveName { get; set; } = "";
        

[Description(@"Name of a curve that describes the part load fraction (PLF) of the system as a function of the part load ratio. Used to calculate dehumidifier run time fraction and electric power. quadratic curve = a + b*PLR + c*PLR**2 cubic curve = a + b*PLR + c*PLR**2 + d*PLR**3 PLR = part load ratio (dehumidification load/steady state water removal capacity)")]
[JsonProperty(PropertyName="part_load_fraction_correlation_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PartLoadFractionCorrelationCurveName { get; set; } = "";
        

[Description("Dehumidifier shut off if inlet air (zone) temperature is below this value. This v" +
    "alue must be less than the Maximum Dry-Bulb Temperature for Dehumidifier Operati" +
    "on.")]
[JsonProperty(PropertyName="minimum_dry_bulb_temperature_for_dehumidifier_operation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumDryBulbTemperatureForDehumidifierOperation { get; set; } = Double.Parse("10", CultureInfo.InvariantCulture);
        

[Description("Dehumidifier shut off if inlet air (zone) temperature is above this value. This v" +
    "alue must be greater than the Minimum Dry-Bulb Temperature for Dehumidifier Oper" +
    "ation.")]
[JsonProperty(PropertyName="maximum_dry_bulb_temperature_for_dehumidifier_operation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumDryBulbTemperatureForDehumidifierOperation { get; set; } = Double.Parse("35", CultureInfo.InvariantCulture);
        

[Description(@"Parasitic electric power consumed when the dehumidifier is available to operate, but does not operate (i.e., no high humidity load to be met). Off cycle parasitic power is 0 when the availability schedule is 0. This electric load is considered as a heat gain to the zone air.")]
[JsonProperty(PropertyName="off_cycle_parasitic_electric_load", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OffCycleParasiticElectricLoad { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Name of storage tank used to collect water removed by the dehumidifier.")]
[JsonProperty(PropertyName="condensate_collection_water_storage_tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CondensateCollectionWaterStorageTankName { get; set; } = "";
    }
    
    [Description(@"This compound component models a stand-alone energy recovery ventilator (ERV) that conditions outdoor ventilation air and supplies that air directly to a zone. The ERV unit is modeled as a collection of components: air-to-air heat exchanger, supply air fan, exhaust air fan and an optional controller to avoid overheating of the supply air (economizer or free cooling operation).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_EnergyRecoveryVentilator
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("Heat exchanger type must be HeatExchanger:AirToAir:SensibleAndLatent")]
[JsonProperty(PropertyName="heat_exchanger_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatExchangerName { get; set; } = "";
        

[Description("This flow rate must match the supply fan\'s air flow rate.")]
[JsonProperty(PropertyName="supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This flow rate must match the supply fan air flow rate.")]
[JsonProperty(PropertyName="exhaust_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> ExhaustAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Fan type must be Fan:OnOff or Fan:SystemModel")]
[JsonProperty(PropertyName="supply_air_fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanName { get; set; } = "";
        

[Description("Fan type must be Fan:OnOff or Fan:SystemModel")]
[JsonProperty(PropertyName="exhaust_air_fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ExhaustAirFanName { get; set; } = "";
        

[Description("Enter the name of a ZoneHVAC:EnergyRecoveryVentilator:Controller object.")]
[JsonProperty(PropertyName="controller_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControllerName { get; set; } = "";
        

[Description("0.000508 m3/s-m2 corresponds to 0.1 ft3/min-ft2 Used only when supply and exhaust" +
    " air flow rates are autosized.")]
[JsonProperty(PropertyName="ventilation_rate_per_unit_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VentilationRatePerUnitFloorArea { get; set; } = null;
        

[Description("0.00236 m3/s-person corresponds to 5 ft3/min-person Used only when supply and exh" +
    "aust air flow rates are autosized.")]
[JsonProperty(PropertyName="ventilation_rate_per_occupant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VentilationRatePerOccupant { get; set; } = null;
        

[Description("Enter the name of an AvailabilityManagerAssignmentList object.")]
[JsonProperty(PropertyName="availability_manager_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityManagerListName { get; set; } = "";
    }
    
    [Description("This controller is used exclusively by the ZoneHVAC:EnergyRecoveryVentilator obje" +
        "ct to allow economizer (free cooling) operation when possible.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_EnergyRecoveryVentilator_Controller
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Enter the maximum outdoor dry-bulb temperature limit for economizer operation. No" +
    " input or blank input means this limit is not operative")]
[JsonProperty(PropertyName="temperature_high_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureHighLimit { get; set; } = null;
        

[Description("Enter the minimum outdoor dry-bulb temperature limit for economizer operation. No" +
    " input or blank input means this limit is not operative")]
[JsonProperty(PropertyName="temperature_low_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureLowLimit { get; set; } = null;
        

[Description("Enter the maximum outdoor enthalpy limit for economizer operation. No input or bl" +
    "ank input means this limit is not operative")]
[JsonProperty(PropertyName="enthalpy_high_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EnthalpyHighLimit { get; set; } = null;
        

[Description("Enter the maximum outdoor dew point temperature limit for economizer operation. N" +
    "o input or blank input means this limit is not operative")]
[JsonProperty(PropertyName="dewpoint_temperature_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureLimit { get; set; } = null;
        

[Description("Enter the name of a quadratic or cubic curve which defines the maximum outdoor hu" +
    "midity ratio (function of outdoor dry-bulb temperature) for economizer operation" +
    ". No input or blank input means this limit is not operative")]
[JsonProperty(PropertyName="electronic_enthalpy_limit_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ElectronicEnthalpyLimitCurveName { get; set; } = "";
        

[JsonProperty(PropertyName="exhaust_air_temperature_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_EnergyRecoveryVentilator_Controller_ExhaustAirTemperatureLimit ExhaustAirTemperatureLimit { get; set; } = (ZoneHVAC_EnergyRecoveryVentilator_Controller_ExhaustAirTemperatureLimit)Enum.Parse(typeof(ZoneHVAC_EnergyRecoveryVentilator_Controller_ExhaustAirTemperatureLimit), "NoExhaustAirTemperatureLimit");
        

[JsonProperty(PropertyName="exhaust_air_enthalpy_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_EnergyRecoveryVentilator_Controller_ExhaustAirEnthalpyLimit ExhaustAirEnthalpyLimit { get; set; } = (ZoneHVAC_EnergyRecoveryVentilator_Controller_ExhaustAirEnthalpyLimit)Enum.Parse(typeof(ZoneHVAC_EnergyRecoveryVentilator_Controller_ExhaustAirEnthalpyLimit), "NoExhaustAirEnthalpyLimit");
        

[Description("Schedule values greater than 0 indicate economizer operation is active. This sche" +
    "dule may be used with or without the High Humidity Control option. When used tog" +
    "ether, high humidity control has priority over economizer control.")]
[JsonProperty(PropertyName="time_of_day_economizer_flow_control_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TimeOfDayEconomizerFlowControlScheduleName { get; set; } = "";
        

[Description("Select Yes to modify air flow rates based on a zone humidistat. Select No to disa" +
    "ble this feature.")]
[JsonProperty(PropertyName="high_humidity_control_flag", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes HighHumidityControlFlag { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("Enter the name of the zone where the humidistat is located.")]
[JsonProperty(PropertyName="humidistat_control_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HumidistatControlZoneName { get; set; } = "";
        

[Description("Enter the ratio of supply (outdoor) air to the maximum supply air flow rate when " +
    "modified air flow rates are active based on high indoor humidity.")]
[JsonProperty(PropertyName="high_humidity_outdoor_air_flow_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HighHumidityOutdoorAirFlowRatio { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description(@"If NO is selected, the air flow rate is modified any time indoor relative humidity is above humidistat setpoint. If YES is selected, outdoor air flow rate is modified any time indoor relative humidity is above the humidistat setpoint AND the outdoor humidity ratio is less than the indoor humidity ratio.")]
[JsonProperty(PropertyName="control_high_indoor_humidity_based_on_outdoor_humidity_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes ControlHighIndoorHumidityBasedOnOutdoorHumidityRatio { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
    }
    
    public enum ZoneHVAC_EnergyRecoveryVentilator_Controller_ExhaustAirTemperatureLimit
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ExhaustAirTemperatureLimit")]
        ExhaustAirTemperatureLimit = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="NoExhaustAirTemperatureLimit")]
        NoExhaustAirTemperatureLimit = 2,
    }
    
    public enum ZoneHVAC_EnergyRecoveryVentilator_Controller_ExhaustAirEnthalpyLimit
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ExhaustAirEnthalpyLimit")]
        ExhaustAirEnthalpyLimit = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="NoExhaustAirEnthalpyLimit")]
        NoExhaustAirEnthalpyLimit = 2,
    }
    
    [Description("Unit ventilator. Forced-convection ventilation unit with supply fan (constant-vol" +
        "ume or variable-volume), optional chilled water cooling coil, optional heating c" +
        "oil (gas, electric, hot water, or steam) and controllable outdoor air mixer.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_UnitVentilator
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="outdoor_air_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_UnitVentilator_OutdoorAirControlType OutdoorAirControlType { get; set; } = (ZoneHVAC_UnitVentilator_OutdoorAirControlType)Enum.Parse(typeof(ZoneHVAC_UnitVentilator_OutdoorAirControlType), "FixedAmount");
        

[JsonProperty(PropertyName="minimum_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MinimumOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("schedule values multiply the minimum outdoor air flow rate")]
[JsonProperty(PropertyName="minimum_outdoor_air_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumOutdoorAirScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("that this depends on the control type as to whether it is a fraction or temperatu" +
    "re")]
[JsonProperty(PropertyName="maximum_outdoor_air_fraction_or_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaximumOutdoorAirFractionOrTemperatureScheduleName { get; set; } = "";
        

[Description("Inlet node name must be zone exhaust node name if there is no DOA Mixer, or if th" +
    "e unit ventilator is connected DOA, then the air inlet node name must be the mix" +
    "er outlet air node name for InletSide mixer connection.")]
[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[Description("Outlet node name must be zone inlet node name if there is no DOA Mixer, or if the" +
    " unit ventilator is connected DOA, then the air outlet node name must be the mix" +
    "er secondary air inlet node name for SupplySide mixer connection.")]
[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[Description("this field is left blank only if the Unit Ventilator is connected to a central de" +
    "dicated outdoor air (DOA) via AirTerminal:SingleDuct:Mixer object")]
[JsonProperty(PropertyName="outdoor_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirNodeName { get; set; } = "";
        

[Description("this field is left blank only if the Unit Ventilator is connected to a central de" +
    "dicated outdoor air (DOA) via AirTerminal:SingleDuct:Mixer object")]
[JsonProperty(PropertyName="exhaust_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ExhaustAirNodeName { get; set; } = "";
        

[Description("inlet to coils this field is left blank only if the Unit Ventilator is connected " +
    "to a central dedicated outdoor air (DOA) via AirTerminal:SingleDuct:Mixer object" +
    "")]
[JsonProperty(PropertyName="mixed_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MixedAirNodeName { get; set; } = "";
        

[Description("Allowable fan types are Fan:ConstantVolume, Fan:OnOff, Fan:VariableVolume, and Fa" +
    "n:SystemModel")]
[JsonProperty(PropertyName="supply_air_fan_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_UnitVentilator_SupplyAirFanObjectType SupplyAirFanObjectType { get; set; } = (ZoneHVAC_UnitVentilator_SupplyAirFanObjectType)Enum.Parse(typeof(ZoneHVAC_UnitVentilator_SupplyAirFanObjectType), "FanConstantVolume");
        

[JsonProperty(PropertyName="supply_air_fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanName { get; set; } = "";
        

[JsonProperty(PropertyName="coil_option", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_UnitVentilator_CoilOption CoilOption { get; set; } = (ZoneHVAC_UnitVentilator_CoilOption)Enum.Parse(typeof(ZoneHVAC_UnitVentilator_CoilOption), "Cooling");
        

[Description(@"Enter the name of a schedule that controls fan operation. Schedule name values of 0 denote cycling fan operation (fan cycles with cooling/heating coil). Schedule values greater than 0 denote constant fan operation (fan runs continually regardless of coil operation). The fan operating mode defaults to cycling fan operation if this input field is left blank.")]
[JsonProperty(PropertyName="supply_air_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanOperatingModeScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="heating_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_UnitVentilator_HeatingCoilObjectType HeatingCoilObjectType { get; set; } = (ZoneHVAC_UnitVentilator_HeatingCoilObjectType)Enum.Parse(typeof(ZoneHVAC_UnitVentilator_HeatingCoilObjectType), "CoilHeatingElectric");
        

[JsonProperty(PropertyName="heating_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilName { get; set; } = "";
        

[JsonProperty(PropertyName="heating_convergence_tolerance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingConvergenceTolerance { get; set; } = Double.Parse("0.001", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cooling_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_UnitVentilator_CoolingCoilObjectType CoolingCoilObjectType { get; set; } = (ZoneHVAC_UnitVentilator_CoolingCoilObjectType)Enum.Parse(typeof(ZoneHVAC_UnitVentilator_CoolingCoilObjectType), "CoilCoolingWater");
        

[JsonProperty(PropertyName="cooling_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilName { get; set; } = "";
        

[JsonProperty(PropertyName="cooling_convergence_tolerance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingConvergenceTolerance { get; set; } = Double.Parse("0.001", CultureInfo.InvariantCulture);
        

[Description("Enter the name of an AvailabilityManagerAssignmentList object.")]
[JsonProperty(PropertyName="availability_manager_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityManagerListName { get; set; } = "";
        

[Description("Enter the name of a DesignSpecificationZoneHVACSizing object.")]
[JsonProperty(PropertyName="design_specification_zonehvac_sizing_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZonehvacSizingObjectName { get; set; } = "";
    }
    
    public enum ZoneHVAC_UnitVentilator_OutdoorAirControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="FixedAmount")]
        FixedAmount = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedTemperature")]
        FixedTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="VariablePercent")]
        VariablePercent = 2,
    }
    
    public enum ZoneHVAC_UnitVentilator_SupplyAirFanObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:ConstantVolume")]
        FanConstantVolume = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:OnOff")]
        FanOnOff = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:SystemModel")]
        FanSystemModel = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:VariableVolume")]
        FanVariableVolume = 3,
    }
    
    public enum ZoneHVAC_UnitVentilator_CoilOption
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatingAndCooling")]
        HeatingAndCooling = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    public enum ZoneHVAC_UnitVentilator_HeatingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric")]
        CoilHeatingElectric = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Fuel")]
        CoilHeatingFuel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Steam")]
        CoilHeatingSteam = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Water")]
        CoilHeatingWater = 3,
    }
    
    public enum ZoneHVAC_UnitVentilator_CoolingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water")]
        CoilCoolingWater = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water:DetailedGeometry")]
        CoilCoolingWaterDetailedGeometry = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:Water:HeatExchangerAssisted")]
        CoilSystemCoolingWaterHeatExchangerAssisted = 2,
    }
    
    [Description("Unit heater. Forced-convection heating-only unit with supply fan, heating coil (g" +
        "as, electric, hot water, or steam) and fixed-position outdoor air mixer.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_UnitHeater
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[Description("Allowable fan types are Fan:ConstantVolume, Fan:OnOff, Fan:VariableVolume and Fan" +
    ":SystemModel")]
[JsonProperty(PropertyName="supply_air_fan_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_UnitHeater_SupplyAirFanObjectType SupplyAirFanObjectType { get; set; } = (ZoneHVAC_UnitHeater_SupplyAirFanObjectType)Enum.Parse(typeof(ZoneHVAC_UnitHeater_SupplyAirFanObjectType), "FanConstantVolume");
        

[JsonProperty(PropertyName="supply_air_fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanName { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_UnitHeater_HeatingCoilObjectType HeatingCoilObjectType { get; set; } = (ZoneHVAC_UnitHeater_HeatingCoilObjectType)Enum.Parse(typeof(ZoneHVAC_UnitHeater_HeatingCoilObjectType), "CoilHeatingElectric");
        

[JsonProperty(PropertyName="heating_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilName { get; set; } = "";
        

[Description(@"Enter the name of a schedule that controls fan operation. Schedule name values of 0 denote cycling fan operation (fan cycles with the heating coil). Schedule values greater than 0 denote constant fan operation (fan runs continually regardless of coil operation). The fan operating mode defaults to cycling fan operation if this input field is left blank.")]
[JsonProperty(PropertyName="supply_air_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanOperatingModeScheduleName { get; set; } = "";
        

[Description(@"This choice field allows the user to define how the unit heater will operate under ""no heating load"" or cooling conditions. If the ""No"" is selected, then the fan will not run unless there is a heating load. If the fan does not run, this effectively shuts the unit heater system off when there is no heating load. If the ""Yes"" is selected, the unit heater is available and has a ConstantVolume fan, or has an OnOff fan with ""Supply Air Fan Operating Mode Schedule"" value greater than zero, then the fan will always run regardless of the zone load.")]
[JsonProperty(PropertyName="supply_air_fan_operation_during_no_heating", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_UnitHeater_SupplyAirFanOperationDuringNoHeating SupplyAirFanOperationDuringNoHeating { get; set; } = (ZoneHVAC_UnitHeater_SupplyAirFanOperationDuringNoHeating)Enum.Parse(typeof(ZoneHVAC_UnitHeater_SupplyAirFanOperationDuringNoHeating), "No");
        

[Description("Not used when heating coil is gas or electric")]
[JsonProperty(PropertyName="maximum_hot_water_or_steam_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumHotWaterOrSteamFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Not used when heating coil is gas or electric")]
[JsonProperty(PropertyName="minimum_hot_water_or_steam_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumHotWaterOrSteamFlowRate { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_convergence_tolerance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingConvergenceTolerance { get; set; } = Double.Parse("0.001", CultureInfo.InvariantCulture);
        

[Description("Enter the name of an AvailabilityManagerAssignmentList object.")]
[JsonProperty(PropertyName="availability_manager_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityManagerListName { get; set; } = "";
        

[Description("Enter the name of a DesignSpecificationZoneHVACSizing object.")]
[JsonProperty(PropertyName="design_specification_zonehvac_sizing_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZonehvacSizingObjectName { get; set; } = "";
    }
    
    public enum ZoneHVAC_UnitHeater_SupplyAirFanObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:ConstantVolume")]
        FanConstantVolume = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:OnOff")]
        FanOnOff = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:SystemModel")]
        FanSystemModel = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:VariableVolume")]
        FanVariableVolume = 3,
    }
    
    public enum ZoneHVAC_UnitHeater_HeatingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric")]
        CoilHeatingElectric = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Fuel")]
        CoilHeatingFuel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Steam")]
        CoilHeatingSteam = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Water")]
        CoilHeatingWater = 3,
    }
    
    public enum ZoneHVAC_UnitHeater_SupplyAirFanOperationDuringNoHeating
    {
        
        [System.Runtime.Serialization.EnumMember(Value="No")]
        No = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Yes")]
        Yes = 1,
    }
    
    [Description("Zone evaporative cooler. Forced-convection cooling-only unit with supply fan, 100" +
        "% outdoor air supply. Optional relief exhaust node")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_EvaporativeCoolerUnit
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("Enter the name of an AvailabilityManagerAssignmentList object.")]
[JsonProperty(PropertyName="availability_manager_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityManagerListName { get; set; } = "";
        

[Description("this is an outdoor air node")]
[JsonProperty(PropertyName="outdoor_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirInletNodeName { get; set; } = "";
        

[Description("this is a zone inlet node")]
[JsonProperty(PropertyName="cooler_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolerOutletNodeName { get; set; } = "";
        

[Description("this is a zone exhaust node, optional if flow is being balanced elsewhere")]
[JsonProperty(PropertyName="zone_relief_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneReliefAirNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="supply_air_fan_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_EvaporativeCoolerUnit_SupplyAirFanObjectType SupplyAirFanObjectType { get; set; } = (ZoneHVAC_EvaporativeCoolerUnit_SupplyAirFanObjectType)Enum.Parse(typeof(ZoneHVAC_EvaporativeCoolerUnit_SupplyAirFanObjectType), "FanComponentModel");
        

[JsonProperty(PropertyName="supply_air_fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanName { get; set; } = "";
        

[JsonProperty(PropertyName="design_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_EvaporativeCoolerUnit_FanPlacement FanPlacement { get; set; } = (ZoneHVAC_EvaporativeCoolerUnit_FanPlacement)Enum.Parse(typeof(ZoneHVAC_EvaporativeCoolerUnit_FanPlacement), "BlowThrough");
        

[JsonProperty(PropertyName="cooler_unit_control_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_EvaporativeCoolerUnit_CoolerUnitControlMethod CoolerUnitControlMethod { get; set; } = (ZoneHVAC_EvaporativeCoolerUnit_CoolerUnitControlMethod)Enum.Parse(typeof(ZoneHVAC_EvaporativeCoolerUnit_CoolerUnitControlMethod), "ZoneCoolingLoadOnOffCycling");
        

[Description("used for ZoneTemperatureDeadbandOnOffCycling hystersis range for thermostatic con" +
    "trol")]
[JsonProperty(PropertyName="throttling_range_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThrottlingRangeTemperatureDifference { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Sign convention is that positive values indicate a cooling load")]
[JsonProperty(PropertyName="cooling_load_control_threshold_heat_transfer_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingLoadControlThresholdHeatTransferRate { get; set; } = Double.Parse("100", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="first_evaporative_cooler_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_EvaporativeCoolerUnit_FirstEvaporativeCoolerObjectType FirstEvaporativeCoolerObjectType { get; set; } = (ZoneHVAC_EvaporativeCoolerUnit_FirstEvaporativeCoolerObjectType)Enum.Parse(typeof(ZoneHVAC_EvaporativeCoolerUnit_FirstEvaporativeCoolerObjectType), "EvaporativeCoolerDirectCelDekPad");
        

[JsonProperty(PropertyName="first_evaporative_cooler_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FirstEvaporativeCoolerObjectName { get; set; } = "";
        

[Description("optional, used for direct/indirect configurations second cooler must be immediate" +
    "ly downstream of first cooler, if present")]
[JsonProperty(PropertyName="second_evaporative_cooler_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_EvaporativeCoolerUnit_SecondEvaporativeCoolerObjectType SecondEvaporativeCoolerObjectType { get; set; } = (ZoneHVAC_EvaporativeCoolerUnit_SecondEvaporativeCoolerObjectType)Enum.Parse(typeof(ZoneHVAC_EvaporativeCoolerUnit_SecondEvaporativeCoolerObjectType), "EvaporativeCoolerDirectCelDekPad");
        

[Description("optional, used for direct/indirect configurations")]
[JsonProperty(PropertyName="second_evaporative_cooler_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SecondEvaporativeCoolerName { get; set; } = "";
        

[Description("Enter the name of a DesignSpecificationZoneHVACSizing object.")]
[JsonProperty(PropertyName="design_specification_zonehvac_sizing_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZonehvacSizingObjectName { get; set; } = "";
    }
    
    public enum ZoneHVAC_EvaporativeCoolerUnit_SupplyAirFanObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:ComponentModel")]
        FanComponentModel = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:ConstantVolume")]
        FanConstantVolume = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:OnOff")]
        FanOnOff = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:SystemModel")]
        FanSystemModel = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:VariableVolume")]
        FanVariableVolume = 4,
    }
    
    public enum ZoneHVAC_EvaporativeCoolerUnit_FanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 1,
    }
    
    public enum ZoneHVAC_EvaporativeCoolerUnit_CoolerUnitControlMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="ZoneCoolingLoadOnOffCycling")]
        ZoneCoolingLoadOnOffCycling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ZoneCoolingLoadVariableSpeedFan")]
        ZoneCoolingLoadVariableSpeedFan = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ZoneTemperatureDeadbandOnOffCycling")]
        ZoneTemperatureDeadbandOnOffCycling = 2,
    }
    
    public enum ZoneHVAC_EvaporativeCoolerUnit_FirstEvaporativeCoolerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="EvaporativeCooler:Direct:CelDekPad")]
        EvaporativeCoolerDirectCelDekPad = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="EvaporativeCooler:Direct:ResearchSpecial")]
        EvaporativeCoolerDirectResearchSpecial = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="EvaporativeCooler:Indirect:CelDekPad")]
        EvaporativeCoolerIndirectCelDekPad = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="EvaporativeCooler:Indirect:ResearchSpecial")]
        EvaporativeCoolerIndirectResearchSpecial = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="EvaporativeCooler:Indirect:WetCoil")]
        EvaporativeCoolerIndirectWetCoil = 4,
    }
    
    public enum ZoneHVAC_EvaporativeCoolerUnit_SecondEvaporativeCoolerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="EvaporativeCooler:Direct:CelDekPad")]
        EvaporativeCoolerDirectCelDekPad = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="EvaporativeCooler:Direct:ResearchSpecial")]
        EvaporativeCoolerDirectResearchSpecial = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="EvaporativeCooler:Indirect:CelDekPad")]
        EvaporativeCoolerIndirectCelDekPad = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="EvaporativeCooler:Indirect:ResearchSpecial")]
        EvaporativeCoolerIndirectResearchSpecial = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="EvaporativeCooler:Indirect:WetCoil")]
        EvaporativeCoolerIndirectWetCoil = 4,
    }
    
    [Description(@"Hybrid Unitary HVAC. A black box model for multi-mode packaged forced air equipment. Independent variables include outdoor air conditions and indoor air conditions. Controlled inputs include operating mode, supply air flow rate, and outdoor air faction. Emperical lookup tables are required to map supply air temperature supply air humidity, electricity use, fuel uses, water use, fan electricity use, and external static pressure as a function of each indpednent varaible and each controlled input. In each timestep the model will choose one or more combinations of settings for mode, supply air flow rate, outdoor air faction, and part runtime fraction so as to satisfy zone requests for sensible cooling, heating, ventilation, and/or dehumidification with the least resource consumption. Equipment in this class may consume electricity, water, and up to two additional fuel types.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_HybridUnitaryHVAC
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Enter the availability schedule name for this system. Schedule value > 0 means th" +
    "e system is available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("Enter the name of an AvailabilityManagerAssignmentList object.")]
[JsonProperty(PropertyName="availability_manager_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityManagerListName { get; set; } = "";
        

[Description("Values in this schedule are used as a constraint in choosing the feasible setting" +
    "s for supply air flow rate and ouside air fraction in each operating mode. If th" +
    "is field is blank, no minimum is imposed.")]
[JsonProperty(PropertyName="minimum_supply_air_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumSupplyAirTemperatureScheduleName { get; set; } = "";
        

[Description("Values in this schedule are used as a constraint in choosing the feasible setting" +
    "s for supply air flow rate and outdoor air fraction in each operating mode. If t" +
    "his field is blank, no maximum is imposed.")]
[JsonProperty(PropertyName="maximum_supply_air_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaximumSupplyAirTemperatureScheduleName { get; set; } = "";
        

[Description("Values in this schedule are used as a constraint in choosing the feasible setting" +
    "s for supply air flow rate and outdoor air fraction in each operating mode. If t" +
    "his field is blank, no minimum is imposed.")]
[JsonProperty(PropertyName="minimum_supply_air_humidity_ratio_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumSupplyAirHumidityRatioScheduleName { get; set; } = "";
        

[Description("Values in this schedule are used as a constraint in choosing the feasible setting" +
    "s for supply air flow rate and outdoor air fraction in each operating mode. If t" +
    "his field is blank, no maximum is imposed.")]
[JsonProperty(PropertyName="maximum_supply_air_humidity_ratio_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaximumSupplyAirHumidityRatioScheduleName { get; set; } = "";
        

[Description(@"Select the method that will be used to choose operating mode(s), supply air flow rate(s), outdoor air fraction(s) and part runtime fraction(s) in each time step. ""Automatic"" = chooses controlled inputs and part runtime fraction(s) to minimize resource use within each time step while best satisfying requested sensible cooling, dehumidification and ventilation, and subject to constraints. ""User Defined"" = EMS will be used to choose controlled inputs and part runtime fraction(s) in each time step. If this field is blank, default to ""Automatic"".")]
[JsonProperty(PropertyName="method_to_choose_controlled_inputs_and_part_runtime_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_HybridUnitaryHVAC_MethodToChooseControlledInputsAndPartRuntimeFraction MethodToChooseControlledInputsAndPartRuntimeFraction { get; set; } = (ZoneHVAC_HybridUnitaryHVAC_MethodToChooseControlledInputsAndPartRuntimeFraction)Enum.Parse(typeof(ZoneHVAC_HybridUnitaryHVAC_MethodToChooseControlledInputsAndPartRuntimeFraction), "Automatic");
        

[Description("Return air node for the hybrid unit must be a zone exhaust node.")]
[JsonProperty(PropertyName="return_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReturnAirNodeName { get; set; } = "";
        

[Description("Outdoor air node for the hybrid unit must be an outdoor air node.")]
[JsonProperty(PropertyName="outdoor_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirNodeName { get; set; } = "";
        

[Description("Supply air node for the hybrid unit must be a zone air inlet node.")]
[JsonProperty(PropertyName="supply_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirNodeName { get; set; } = "";
        

[Description("Relief node for the hybrid unit must be a zone exhaust node, unless flow is being" +
    " balanced elsewhere.")]
[JsonProperty(PropertyName="relief_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReliefNodeName { get; set; } = "";
        

[Description(@"The value in this field represents the maximum supply air volume flow rate among all operating modes. Values of extensive variables in lookup tables are normalized by the system maximum supply air mass flow rate that was used to build performance curves. The value in this field is used to rescale the output from exenstive variables to a desired system size.")]
[JsonProperty(PropertyName="system_maximum_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SystemMaximumSupplyAirFlowRate { get; set; } = null;
        

[Description(@"Input the external static pressure when the system operates at maximum supply air flow rate. Fan affinity laws are used to scale supply fan power from the values tabulated in lookup tables, to values that match the external static pressure input to this field. If this field is blank, the supply fan power is not scaled from the values tabulated in lookup tables.")]
[JsonProperty(PropertyName="external_static_pressure_at_system_maximum_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ExternalStaticPressureAtSystemMaximumSupplyAirFlowRate { get; set; } = null;
        

[Description("This field specifies if the fan heat is accounted for in the lookup tables.")]
[JsonProperty(PropertyName="fan_heat_included_in_lookup_tables", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes FanHeatIncludedInLookupTables { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("This field specifies where to add the fan heat in the air stream.")]
[JsonProperty(PropertyName="fan_heat_gain_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_HybridUnitaryHVAC_FanHeatGainLocation FanHeatGainLocation { get; set; } = (ZoneHVAC_HybridUnitaryHVAC_FanHeatGainLocation)Enum.Parse(typeof(ZoneHVAC_HybridUnitaryHVAC_FanHeatGainLocation), "SupplyAirStream");
        

[Description("0.0 means no fan heat is added to the air stream, 1.0 means all fan heat is added" +
    " to the air stream.")]
[JsonProperty(PropertyName="fan_heat_in_air_stream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanHeatInAirStreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("The value in this field scales all extensive performance variables including: sup" +
    "ply air mass flow rate, fuel uses, and water use. If this field is blank, the de" +
    "fault scaling factor is 1.")]
[JsonProperty(PropertyName="scaling_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ScalingFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description(@"Any mode selected will not operate for less time than the value input in this field. If the value in this field is larger than each timestep, the mode selected in one time step will persist in later time steps until the minimum time between mode change is satisfied. Supply air mass flow rate and outdoor air fraction within a mode are not subject to minimum runtime and may change in every time step. Mode 0 does not have a minimum time. If this field is blank, the default minimum time between mode change is 10 minutes.")]
[JsonProperty(PropertyName="minimum_time_between_mode_change", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumTimeBetweenModeChange { get; set; } = Double.Parse("10", CultureInfo.InvariantCulture);
        

[Description("Select the fuel type associated with field: \"System Electric Power Lookup Table\" " +
    "in each mode. If this field is blank, default first fuel type = Electricity.")]
[JsonProperty(PropertyName="first_fuel_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_HybridUnitaryHVAC_FirstFuelType FirstFuelType { get; set; } = (ZoneHVAC_HybridUnitaryHVAC_FirstFuelType)Enum.Parse(typeof(ZoneHVAC_HybridUnitaryHVAC_FirstFuelType), "Electricity");
        

[Description("Select the fuel type associated with field: \"System Second Fuel Consumption Looku" +
    "p Table\" in each mode. If this field is blank, default second fuel type = None.")]
[JsonProperty(PropertyName="second_fuel_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_HybridUnitaryHVAC_SecondFuelType SecondFuelType { get; set; } = (ZoneHVAC_HybridUnitaryHVAC_SecondFuelType)Enum.Parse(typeof(ZoneHVAC_HybridUnitaryHVAC_SecondFuelType), "None");
        

[Description("Select the fuel type associated with field: \"System Third Fuel Consumption Lookup" +
    " Table\" in each mode. If this field is blank, default third fuel type = None.")]
[JsonProperty(PropertyName="third_fuel_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_HybridUnitaryHVAC_ThirdFuelType ThirdFuelType { get; set; } = (ZoneHVAC_HybridUnitaryHVAC_ThirdFuelType)Enum.Parse(typeof(ZoneHVAC_HybridUnitaryHVAC_ThirdFuelType), "None");
        

[Description("In each time step, controlled variables will be chosen to minimize the selection " +
    "in this field, subject to constraints. If this field is blank, the objective fun" +
    "ction will minimize electricity use.")]
[JsonProperty(PropertyName="objective_function_to_minimize", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_HybridUnitaryHVAC_ObjectiveFunctionToMinimize ObjectiveFunctionToMinimize { get; set; } = (ZoneHVAC_HybridUnitaryHVAC_ObjectiveFunctionToMinimize)Enum.Parse(typeof(ZoneHVAC_HybridUnitaryHVAC_ObjectiveFunctionToMinimize), "Empty");
        

[Description(@"Enter the name of a DesignSpecification:OutdoorAir object. Information in that object will be used to compute the minimum outdoor air flow rate in each time step. If this field is blank, the system may still supply outdoor air, if it is capable as described by lookup tables, when doing so is the most efficient way to satisfy other constraints.")]
[JsonProperty(PropertyName="design_specification_outdoor_air_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationOutdoorAirObjectName { get; set; } = "";
        

[Description(@"Enter a name for Mode 0. Mode 0 describes equipment performance in standby. Mode 0 is usually characterized by electricity use for controls and crankcase heaters, or other standby resouce consumption. Mode 0 will be chosen for any timestep, or portion of timestep, when no ventilation, cooling, humidification, or dehumidification is required. Mode 0 is available at any environmental condition.")]
[JsonProperty(PropertyName="mode_0_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Mode0Name { get; set; } = "";
        

[Description(@"Enter the name of the Supply Air Temperature Lookup Table for Mode 0. Units for lookup table values should be in C. If this field is blank, Mode 0 will not be considered for any period that requires ventilation, heating, cooling, humidification, or dehumidification. If this field is blank, when Mode 0 is chosen (during standby periods) the supply air temperature will equal the return air temperature.")]
[JsonProperty(PropertyName="mode_0_supply_air_temperature_lookup_table_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Mode0SupplyAirTemperatureLookupTableName { get; set; } = "";
        

[Description(@"Enter the name of the Supply Air Humidity Ratio Lookup Table for Mode 0. Units for lookup table values should be in kgWater/kgDryAir. If this field is blank, Mode 0 will not be considered for any period that requires ventilation, heating, cooling, humidification, or dehumidification. If this field is blank, when Mode 0 is chosen (during standby periods) the supply air humidty ratio will equal the return air humidity ratio.")]
[JsonProperty(PropertyName="mode_0_supply_air_humidity_ratio_lookup_table_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Mode0SupplyAirHumidityRatioLookupTableName { get; set; } = "";
        

[Description("Enter the name of the Electric Power Lookup Table for Mode 0. Units for lookup ta" +
    "ble values should be in W. If this field is blank, Mode 0 does not consume elect" +
    "ricity.")]
[JsonProperty(PropertyName="mode_0_system_electric_power_lookup_table_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Mode0SystemElectricPowerLookupTableName { get; set; } = "";
        

[Description("Enter the name of the Supply Fan Electric Power Lookup Table for Mode 0. Units fo" +
    "r lookup table values should be in W. If this field is blank, Mode 0 does not co" +
    "nsume electricity for supply fan.")]
[JsonProperty(PropertyName="mode_0_supply_fan_electric_power_lookup_table_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Mode0SupplyFanElectricPowerLookupTableName { get; set; } = "";
        

[Description("Enter the name of the External Static Pressure Lookup Table for Mode 0. Units for" +
    " lookup table values should be in Pa. If this field is blank, external static pr" +
    "essure will not be reported.")]
[JsonProperty(PropertyName="mode_0_external_static_pressure_lookup_table_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Mode0ExternalStaticPressureLookupTableName { get; set; } = "";
        

[Description("Enter the name of the System Second Fuel Consumption Lookup Table for Mode 0. Uni" +
    "ts for lookup table values should be in W. If this field is blank, Mode 0 does n" +
    "ot consume a second fuel.")]
[JsonProperty(PropertyName="mode_0_system_second_fuel_consumption_lookup_table_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Mode0SystemSecondFuelConsumptionLookupTableName { get; set; } = "";
        

[Description("Enter the name of the System Third Fuel Consumption Lookup Table for Mode 0. Unit" +
    "s for lookup table values should be in W. If this field is blank, Mode 0 does no" +
    "t consume a third fuel.")]
[JsonProperty(PropertyName="mode_0_system_third_fuel_consumption_lookup_table_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Mode0SystemThirdFuelConsumptionLookupTableName { get; set; } = "";
        

[Description("Enter the name of the System Water Use Lookup Table for Mode 0. Units for lookup " +
    "table values should be in kg/s. If this field is blank, Mode 0 does not consume " +
    "water.")]
[JsonProperty(PropertyName="mode_0_system_water_use_lookup_table_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Mode0SystemWaterUseLookupTableName { get; set; } = "";
        

[Description("Enter the outdoor air fraction for Mode 0. If this field is blank, the outdoor ai" +
    "r fraction for Mode 0 will be 0.00.")]
[JsonProperty(PropertyName="mode_0_outdoor_air_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Mode0OutdoorAirFraction { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description(@"Enter the supply air mass flow rate ratio for Mode 0. The value in this field will be used to determine the supply air mass flow rate in Mode 0. Supply air mass flow rate ratio describes supply air mass flow rate as a fraction of mass flow rate associated with the value in field: ""System Maximum Supply Air Flow Rate"". If this field is blank, the supply air mass flow rate ratio for Mode 0 will be 0.")]
[JsonProperty(PropertyName="mode_0_supply_air_mass_flow_rate_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Mode0SupplyAirMassFlowRateRatio { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="modes", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_HybridUnitaryHVAC_Modes_Item> Modes { get; set; } = null;
    }
    
    public enum ZoneHVAC_HybridUnitaryHVAC_MethodToChooseControlledInputsAndPartRuntimeFraction
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Automatic")]
        Automatic = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="User Defined")]
        UserDefined = 2,
    }
    
    public enum ZoneHVAC_HybridUnitaryHVAC_FanHeatGainLocation
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MixedAirStream")]
        MixedAirStream = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirStream")]
        SupplyAirStream = 2,
    }
    
    public enum ZoneHVAC_HybridUnitaryHVAC_FirstFuelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coal")]
        Coal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Diesel")]
        Diesel = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DistrictCooling")]
        DistrictCooling = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="DistrictHeating")]
        DistrictHeating = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Electricity")]
        Electricity = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo1")]
        FuelOilNo1 = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo2")]
        FuelOilNo2 = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Gasoline")]
        Gasoline = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="NaturalGas")]
        NaturalGas = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel1")]
        OtherFuel1 = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel2")]
        OtherFuel2 = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Propane")]
        Propane = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Steam")]
        Steam = 14,
    }
    
    public enum ZoneHVAC_HybridUnitaryHVAC_SecondFuelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coal")]
        Coal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Diesel")]
        Diesel = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DistrictCooling")]
        DistrictCooling = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="DistrictHeating")]
        DistrictHeating = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Electricity")]
        Electricity = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo1")]
        FuelOilNo1 = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo2")]
        FuelOilNo2 = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Gasoline")]
        Gasoline = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="NaturalGas")]
        NaturalGas = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel1")]
        OtherFuel1 = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel2")]
        OtherFuel2 = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Propane")]
        Propane = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Steam")]
        Steam = 14,
    }
    
    public enum ZoneHVAC_HybridUnitaryHVAC_ThirdFuelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coal")]
        Coal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Diesel")]
        Diesel = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DistrictCooling")]
        DistrictCooling = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="DistrictHeating")]
        DistrictHeating = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Electricity")]
        Electricity = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo1")]
        FuelOilNo1 = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo2")]
        FuelOilNo2 = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Gasoline")]
        Gasoline = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="NaturalGas")]
        NaturalGas = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel1")]
        OtherFuel1 = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel2")]
        OtherFuel2 = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Propane")]
        Propane = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Steam")]
        Steam = 14,
    }
    
    public enum ZoneHVAC_HybridUnitaryHVAC_ObjectiveFunctionToMinimize
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electricity Use")]
        ElectricityUse = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Second Fuel Use")]
        SecondFuelUse = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Third Fuel Use")]
        ThirdFuelUse = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Water Use")]
        WaterUse = 4,
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_HybridUnitaryHVAC_Modes_Item
    {
        

[JsonProperty(PropertyName="mode_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ModeName { get; set; } = "";
        

[JsonProperty(PropertyName="mode_supply_air_temperature_lookup_table_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ModeSupplyAirTemperatureLookupTableName { get; set; } = "";
        

[JsonProperty(PropertyName="mode_supply_air_humidity_ratio_lookup_table_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ModeSupplyAirHumidityRatioLookupTableName { get; set; } = "";
        

[JsonProperty(PropertyName="mode_system_electric_power_lookup_table_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ModeSystemElectricPowerLookupTableName { get; set; } = "";
        

[JsonProperty(PropertyName="mode_supply_fan_electric_power_lookup_table_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ModeSupplyFanElectricPowerLookupTableName { get; set; } = "";
        

[JsonProperty(PropertyName="mode_external_static_pressure_lookup_table_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ModeExternalStaticPressureLookupTableName { get; set; } = "";
        

[JsonProperty(PropertyName="mode_system_second_fuel_consumption_lookup_table_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ModeSystemSecondFuelConsumptionLookupTableName { get; set; } = "";
        

[JsonProperty(PropertyName="mode_system_third_fuel_consumption_lookup_table_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ModeSystemThirdFuelConsumptionLookupTableName { get; set; } = "";
        

[JsonProperty(PropertyName="mode_system_water_use_lookup_table_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ModeSystemWaterUseLookupTableName { get; set; } = "";
        

[JsonProperty(PropertyName="mode_minimum_outdoor_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ModeMinimumOutdoorAirTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="mode_maximum_outdoor_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ModeMaximumOutdoorAirTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="mode_minimum_outdoor_air_humidity_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ModeMinimumOutdoorAirHumidityRatio { get; set; } = null;
        

[JsonProperty(PropertyName="mode_maximum_outdoor_air_humidity_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ModeMaximumOutdoorAirHumidityRatio { get; set; } = null;
        

[JsonProperty(PropertyName="mode_minimum_outdoor_air_relative_humidity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ModeMinimumOutdoorAirRelativeHumidity { get; set; } = null;
        

[JsonProperty(PropertyName="mode_maximum_outdoor_air_relative_humidity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ModeMaximumOutdoorAirRelativeHumidity { get; set; } = null;
        

[JsonProperty(PropertyName="mode_minimum_return_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ModeMinimumReturnAirTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="mode_maximum_return_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ModeMaximumReturnAirTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="mode_minimum_return_air_humidity_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ModeMinimumReturnAirHumidityRatio { get; set; } = null;
        

[JsonProperty(PropertyName="mode_maximum_return_air_humidity_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ModeMaximumReturnAirHumidityRatio { get; set; } = null;
        

[JsonProperty(PropertyName="mode_minimum_return_air_relative_humidity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ModeMinimumReturnAirRelativeHumidity { get; set; } = null;
        

[JsonProperty(PropertyName="mode_maximum_return_air_relative_humidity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ModeMaximumReturnAirRelativeHumidity { get; set; } = null;
        

[JsonProperty(PropertyName="mode_minimum_outdoor_air_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ModeMinimumOutdoorAirFraction { get; set; } = null;
        

[JsonProperty(PropertyName="mode_maximum_outdoor_air_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ModeMaximumOutdoorAirFraction { get; set; } = null;
        

[JsonProperty(PropertyName="mode_minimum_supply_air_mass_flow_rate_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ModeMinimumSupplyAirMassFlowRateRatio { get; set; } = null;
        

[JsonProperty(PropertyName="mode_maximum_supply_air_mass_flow_rate_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ModeMaximumSupplyAirMassFlowRateRatio { get; set; } = null;
    }
    
    [Description("The zone outdoor air unit models a single-zone dedicated outdoor air system (DOAS" +
        "). Forced-convection 100% outdoor air unit with supply fan and optional equipmen" +
        "t including exhaust fan, heating coil, cooling coil, and heat recovery.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_OutdoorAirUnit
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("(name of zone system is serving)")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> OutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="outdoor_air_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirScheduleName { get; set; } = "";
        

[Description("Allowable fan types are Fan:SystemModel and Fan:ConstantVolume and Fan:VariableVo" +
    "lume")]
[JsonProperty(PropertyName="supply_fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyFanName { get; set; } = "";
        

[JsonProperty(PropertyName="supply_fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_OutdoorAirUnit_SupplyFanPlacement SupplyFanPlacement { get; set; } = (ZoneHVAC_OutdoorAirUnit_SupplyFanPlacement)Enum.Parse(typeof(ZoneHVAC_OutdoorAirUnit_SupplyFanPlacement), "DrawThrough");
        

[Description("Allowable fan types are Fan:SystemModel and Fan:ConstantVolume and Fan:VariableVo" +
    "lume Fan:VariableVolume")]
[JsonProperty(PropertyName="exhaust_fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ExhaustFanName { get; set; } = "";
        

[JsonProperty(PropertyName="exhaust_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> ExhaustAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="exhaust_air_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ExhaustAirScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="unit_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_OutdoorAirUnit_UnitControlType UnitControlType { get; set; } = (ZoneHVAC_OutdoorAirUnit_UnitControlType)Enum.Parse(typeof(ZoneHVAC_OutdoorAirUnit_UnitControlType), "NeutralControl");
        

[Description(@"Air and control temperatures for cooling. If outdoor air temperature is above the high air control temperature, then the zone inlet air temperature is set to the high air control temperature. If the outdoor air is between high and low air control temperature, then there is no cooling/heating requirements.")]
[JsonProperty(PropertyName="high_air_control_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HighAirControlTemperatureScheduleName { get; set; } = "";
        

[Description(@"Air and control temperatures for Heating. If outdoor air temperature is below the low air control temperature, then the zone inlet air temperature is set to the low air control temperature. If the outdoor air is between high and low air control temperature, then there is no cooling/heating requirements.")]
[JsonProperty(PropertyName="low_air_control_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string LowAirControlTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="outdoor_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="airoutlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AiroutletNodeName { get; set; } = "";
        

[Description("air leaves zone")]
[JsonProperty(PropertyName="airinlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirinletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="supply_fanoutlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyFanoutletNodeName { get; set; } = "";
        

[Description("Enter the name of an ZoneHVAC:OutdoorAirUnit:EquipmentList object.")]
[JsonProperty(PropertyName="outdoor_air_unit_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirUnitListName { get; set; } = "";
        

[Description("Enter the name of an AvailabilityManagerAssignmentList object.")]
[JsonProperty(PropertyName="availability_manager_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityManagerListName { get; set; } = "";
    }
    
    public enum ZoneHVAC_OutdoorAirUnit_SupplyFanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum ZoneHVAC_OutdoorAirUnit_UnitControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="NeutralControl")]
        NeutralControl = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureControl")]
        TemperatureControl = 2,
    }
    
    [Description("Equipment list for components in a ZoneHVAC:OutdoorAirUnit. Components are simula" +
        "ted sequentially in the order given in the equipment list.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_OutdoorAirUnit_EquipmentList
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_1_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_OutdoorAirUnit_EquipmentList_Component1ObjectType Component1ObjectType { get; set; } = (ZoneHVAC_OutdoorAirUnit_EquipmentList_Component1ObjectType)Enum.Parse(typeof(ZoneHVAC_OutdoorAirUnit_EquipmentList_Component1ObjectType), "AirLoopHVACUnitarySystem");
        

[JsonProperty(PropertyName="component_1_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component1Name { get; set; } = "";
        

[JsonProperty(PropertyName="component_2_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_OutdoorAirUnit_EquipmentList_Component2ObjectType Component2ObjectType { get; set; } = (ZoneHVAC_OutdoorAirUnit_EquipmentList_Component2ObjectType)Enum.Parse(typeof(ZoneHVAC_OutdoorAirUnit_EquipmentList_Component2ObjectType), "AirLoopHVACUnitarySystem");
        

[JsonProperty(PropertyName="component_2_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component2Name { get; set; } = "";
        

[JsonProperty(PropertyName="component_3_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_OutdoorAirUnit_EquipmentList_Component3ObjectType Component3ObjectType { get; set; } = (ZoneHVAC_OutdoorAirUnit_EquipmentList_Component3ObjectType)Enum.Parse(typeof(ZoneHVAC_OutdoorAirUnit_EquipmentList_Component3ObjectType), "AirLoopHVACUnitarySystem");
        

[JsonProperty(PropertyName="component_3_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component3Name { get; set; } = "";
        

[JsonProperty(PropertyName="component_4_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_OutdoorAirUnit_EquipmentList_Component4ObjectType Component4ObjectType { get; set; } = (ZoneHVAC_OutdoorAirUnit_EquipmentList_Component4ObjectType)Enum.Parse(typeof(ZoneHVAC_OutdoorAirUnit_EquipmentList_Component4ObjectType), "AirLoopHVACUnitarySystem");
        

[JsonProperty(PropertyName="component_4_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component4Name { get; set; } = "";
        

[JsonProperty(PropertyName="component_5_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_OutdoorAirUnit_EquipmentList_Component5ObjectType Component5ObjectType { get; set; } = (ZoneHVAC_OutdoorAirUnit_EquipmentList_Component5ObjectType)Enum.Parse(typeof(ZoneHVAC_OutdoorAirUnit_EquipmentList_Component5ObjectType), "AirLoopHVACUnitarySystem");
        

[JsonProperty(PropertyName="component_5_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component5Name { get; set; } = "";
        

[JsonProperty(PropertyName="component_6_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_OutdoorAirUnit_EquipmentList_Component6ObjectType Component6ObjectType { get; set; } = (ZoneHVAC_OutdoorAirUnit_EquipmentList_Component6ObjectType)Enum.Parse(typeof(ZoneHVAC_OutdoorAirUnit_EquipmentList_Component6ObjectType), "AirLoopHVACUnitarySystem");
        

[JsonProperty(PropertyName="component_6_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component6Name { get; set; } = "";
        

[JsonProperty(PropertyName="component_7_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_OutdoorAirUnit_EquipmentList_Component7ObjectType Component7ObjectType { get; set; } = (ZoneHVAC_OutdoorAirUnit_EquipmentList_Component7ObjectType)Enum.Parse(typeof(ZoneHVAC_OutdoorAirUnit_EquipmentList_Component7ObjectType), "AirLoopHVACUnitarySystem");
        

[JsonProperty(PropertyName="component_7_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component7Name { get; set; } = "";
        

[JsonProperty(PropertyName="component_8_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_OutdoorAirUnit_EquipmentList_Component8ObjectType Component8ObjectType { get; set; } = (ZoneHVAC_OutdoorAirUnit_EquipmentList_Component8ObjectType)Enum.Parse(typeof(ZoneHVAC_OutdoorAirUnit_EquipmentList_Component8ObjectType), "AirLoopHVACUnitarySystem");
        

[JsonProperty(PropertyName="component_8_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component8Name { get; set; } = "";
    }
    
    public enum ZoneHVAC_OutdoorAirUnit_EquipmentList_Component1ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AirLoopHVAC:UnitarySystem")]
        AirLoopHVACUnitarySystem = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water")]
        CoilCoolingWater = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water:DetailedGeometry")]
        CoilCoolingWaterDetailedGeometry = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric")]
        CoilHeatingElectric = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Fuel")]
        CoilHeatingFuel = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Steam")]
        CoilHeatingSteam = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Water")]
        CoilHeatingWater = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:DX")]
        CoilSystemCoolingDX = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:Water:HeatexchangerAssisted")]
        CoilSystemCoolingWaterHeatexchangerAssisted = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Heating:DX")]
        CoilSystemHeatingDX = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Dehumidifier:Desiccant:NoFans")]
        DehumidifierDesiccantNoFans = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchanger:AirToAir:FlatPlate")]
        HeatExchangerAirToAirFlatPlate = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchanger:AirToAir:SensibleAndLatent")]
        HeatExchangerAirToAirSensibleAndLatent = 12,
    }
    
    public enum ZoneHVAC_OutdoorAirUnit_EquipmentList_Component2ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AirLoopHVAC:UnitarySystem")]
        AirLoopHVACUnitarySystem = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water")]
        CoilCoolingWater = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water:DetailedGeometry")]
        CoilCoolingWaterDetailedGeometry = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric")]
        CoilHeatingElectric = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Fuel")]
        CoilHeatingFuel = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Steam")]
        CoilHeatingSteam = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Water")]
        CoilHeatingWater = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:DX")]
        CoilSystemCoolingDX = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:Water:HeatexchangerAssisted")]
        CoilSystemCoolingWaterHeatexchangerAssisted = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Heating:DX")]
        CoilSystemHeatingDX = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Dehumidifier:Desiccant:NoFans")]
        DehumidifierDesiccantNoFans = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchanger:AirToAir:FlatPlate")]
        HeatExchangerAirToAirFlatPlate = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchanger:AirToAir:SensibleAndLatent")]
        HeatExchangerAirToAirSensibleAndLatent = 12,
    }
    
    public enum ZoneHVAC_OutdoorAirUnit_EquipmentList_Component3ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AirLoopHVAC:UnitarySystem")]
        AirLoopHVACUnitarySystem = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water")]
        CoilCoolingWater = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water:DetailedGeometry")]
        CoilCoolingWaterDetailedGeometry = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric")]
        CoilHeatingElectric = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Fuel")]
        CoilHeatingFuel = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Steam")]
        CoilHeatingSteam = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Water")]
        CoilHeatingWater = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:DX")]
        CoilSystemCoolingDX = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:Water:HeatexchangerAssisted")]
        CoilSystemCoolingWaterHeatexchangerAssisted = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Heating:DX")]
        CoilSystemHeatingDX = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Dehumidifier:Desiccant:NoFans")]
        DehumidifierDesiccantNoFans = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchanger:AirToAir:FlatPlate")]
        HeatExchangerAirToAirFlatPlate = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchanger:AirToAir:SensibleAndLatent")]
        HeatExchangerAirToAirSensibleAndLatent = 12,
    }
    
    public enum ZoneHVAC_OutdoorAirUnit_EquipmentList_Component4ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AirLoopHVAC:UnitarySystem")]
        AirLoopHVACUnitarySystem = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water")]
        CoilCoolingWater = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water:DetailedGeometry")]
        CoilCoolingWaterDetailedGeometry = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric")]
        CoilHeatingElectric = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Fuel")]
        CoilHeatingFuel = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Steam")]
        CoilHeatingSteam = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Water")]
        CoilHeatingWater = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:DX")]
        CoilSystemCoolingDX = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:Water:HeatexchangerAssisted")]
        CoilSystemCoolingWaterHeatexchangerAssisted = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Heating:DX")]
        CoilSystemHeatingDX = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Dehumidifier:Desiccant:NoFans")]
        DehumidifierDesiccantNoFans = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchanger:AirToAir:FlatPlate")]
        HeatExchangerAirToAirFlatPlate = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchanger:AirToAir:SensibleAndLatent")]
        HeatExchangerAirToAirSensibleAndLatent = 12,
    }
    
    public enum ZoneHVAC_OutdoorAirUnit_EquipmentList_Component5ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AirLoopHVAC:UnitarySystem")]
        AirLoopHVACUnitarySystem = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water")]
        CoilCoolingWater = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water:DetailedGeometry")]
        CoilCoolingWaterDetailedGeometry = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric")]
        CoilHeatingElectric = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Fuel")]
        CoilHeatingFuel = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Steam")]
        CoilHeatingSteam = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Water")]
        CoilHeatingWater = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:DX")]
        CoilSystemCoolingDX = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:Water:HeatexchangerAssisted")]
        CoilSystemCoolingWaterHeatexchangerAssisted = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Heating:DX")]
        CoilSystemHeatingDX = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Dehumidifier:Desiccant:NoFans")]
        DehumidifierDesiccantNoFans = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchanger:AirToAir:FlatPlate")]
        HeatExchangerAirToAirFlatPlate = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchanger:AirToAir:SensibleAndLatent")]
        HeatExchangerAirToAirSensibleAndLatent = 12,
    }
    
    public enum ZoneHVAC_OutdoorAirUnit_EquipmentList_Component6ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AirLoopHVAC:UnitarySystem")]
        AirLoopHVACUnitarySystem = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water")]
        CoilCoolingWater = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water:DetailedGeometry")]
        CoilCoolingWaterDetailedGeometry = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric")]
        CoilHeatingElectric = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Fuel")]
        CoilHeatingFuel = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Steam")]
        CoilHeatingSteam = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Water")]
        CoilHeatingWater = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:DX")]
        CoilSystemCoolingDX = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:Water:HeatexchangerAssisted")]
        CoilSystemCoolingWaterHeatexchangerAssisted = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Heating:DX")]
        CoilSystemHeatingDX = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Dehumidifier:Desiccant:NoFans")]
        DehumidifierDesiccantNoFans = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchanger:AirToAir:FlatPlate")]
        HeatExchangerAirToAirFlatPlate = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchanger:AirToAir:SensibleAndLatent")]
        HeatExchangerAirToAirSensibleAndLatent = 12,
    }
    
    public enum ZoneHVAC_OutdoorAirUnit_EquipmentList_Component7ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AirLoopHVAC:UnitarySystem")]
        AirLoopHVACUnitarySystem = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water")]
        CoilCoolingWater = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water:DetailedGeometry")]
        CoilCoolingWaterDetailedGeometry = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric")]
        CoilHeatingElectric = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Fuel")]
        CoilHeatingFuel = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Steam")]
        CoilHeatingSteam = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Water")]
        CoilHeatingWater = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:DX")]
        CoilSystemCoolingDX = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:Water:HeatexchangerAssisted")]
        CoilSystemCoolingWaterHeatexchangerAssisted = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Heating:DX")]
        CoilSystemHeatingDX = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Dehumidifier:Desiccant:NoFans")]
        DehumidifierDesiccantNoFans = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchanger:AirToAir:FlatPlate")]
        HeatExchangerAirToAirFlatPlate = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchanger:AirToAir:SensibleAndLatent")]
        HeatExchangerAirToAirSensibleAndLatent = 12,
    }
    
    public enum ZoneHVAC_OutdoorAirUnit_EquipmentList_Component8ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AirLoopHVAC:UnitarySystem")]
        AirLoopHVACUnitarySystem = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water")]
        CoilCoolingWater = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water:DetailedGeometry")]
        CoilCoolingWaterDetailedGeometry = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric")]
        CoilHeatingElectric = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Fuel")]
        CoilHeatingFuel = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Steam")]
        CoilHeatingSteam = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Water")]
        CoilHeatingWater = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:DX")]
        CoilSystemCoolingDX = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:Water:HeatexchangerAssisted")]
        CoilSystemCoolingWaterHeatexchangerAssisted = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Heating:DX")]
        CoilSystemHeatingDX = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Dehumidifier:Desiccant:NoFans")]
        DehumidifierDesiccantNoFans = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchanger:AirToAir:FlatPlate")]
        HeatExchangerAirToAirFlatPlate = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchanger:AirToAir:SensibleAndLatent")]
        HeatExchangerAirToAirSensibleAndLatent = 12,
    }
    
    [Description(@"A terminal unit with variable refrigerant flow (VRF) DX cooling and heating coils (air-to-air heat pump). The VRF terminal units are served by an AirConditioner:VariableRefrigerantFlow or AirConditioner:VariableRefrigerantFlow:FluidTemperatureControl:* system. Terminal units can be configured as zone, air loop or outside air system equipment.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_TerminalUnit_VariableRefrigerantFlow
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("The unit is available the entire simulation if this field is left blank Schedule " +
    "values of 0 denote the unit is off.")]
[JsonProperty(PropertyName="terminal_unit_availability_schedule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TerminalUnitAvailabilitySchedule { get; set; } = "";
        

[Description("the inlet node to the terminal unit")]
[JsonProperty(PropertyName="terminal_unit_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TerminalUnitAirInletNodeName { get; set; } = "";
        

[Description("the outlet node of the terminal unit")]
[JsonProperty(PropertyName="terminal_unit_air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TerminalUnitAirOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="no_cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoCoolingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="no_heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoHeatingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"This field is used only when an oudoor air mixer is included. This field is set to zero flow when the VRF terminal unit is connected to central dedicated outdoor air through air terminal single duct mixer object. When this VRF terminal is used as air loop equipment the autosized flow rate will be set to 0 when an outdoor air system is connected to this air loop, otherwise the outdoor air flow rate will equal the maximum outdoor air flow rate.")]
[JsonProperty(PropertyName="cooling_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"This field is used only when an oudoor air mixer is included. This field is set to zero flow when the VRF terminal unit is connected to central dedicated outdoor air through air terminal single duct mixer object. When this VRF terminal is used as air loop equipment the autosized flow rate will be set to 0 when an outdoor air system is connected to this air loop, otherwise the outdoor air flow rate will equal the maximum outdoor air flow rate.")]
[JsonProperty(PropertyName="heating_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"This field is used only when an oudoor air mixer is included. This field is set to zero flow when the VRF terminal unit is connected to central dedicated outdoor air through air terminal single duct mixer object. When this VRF terminal is used as air loop equipment the autosized flow rate will be set to 0 when an outdoor air system is connected to this air loop, otherwise the outdoor air flow rate will equal the maximum outdoor air flow rate.")]
[JsonProperty(PropertyName="no_load_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoLoadOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Required for zone equipment. Leave blank if terminal unit is used in AirLoopHVAC:" +
    "OutdoorAirSystem:EquipmentList. Also leave blank if terminal unit is used on mai" +
    "n AirloopHVAC branch and terminal unit has no fan.")]
[JsonProperty(PropertyName="supply_air_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanOperatingModeScheduleName { get; set; } = "";
        

[Description(@"Select fan placement as either blow through or draw through. Required for zone equipment. This field is ignored if the VRF terminal unit is used in AirLoopHVAC:OutdoorAirSystem:EquipmentList. This field is also ignored if VRF terminal unit is used on main AirloopHVAC branch and terminal unit has no fan.")]
[JsonProperty(PropertyName="supply_air_fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_SupplyAirFanPlacement SupplyAirFanPlacement { get; set; } = (ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_SupplyAirFanPlacement)Enum.Parse(typeof(ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_SupplyAirFanPlacement), "BlowThrough");
        

[Description(@"Supply Air Fan Object Type must be Fan:SystemModel, Fan:OnOff, or Fan:ConstantVolume if AirConditioner:VariableRefrigerantFlow is used to model VRF outdoor unit Supply Air Fan Object Type must be Fan:SystemModel or Fan:VariableVolume if AirConditioner:VariableRefrigerantFlow:FluidTemperatureControl or AirConditioner:VariableRefrigerantFlow:FluidTemperatureControl:HR is used to model VRF outdoor unit Required for zone equipment. Leave blank if terminal unit is used in AirLoopHVAC:OutdoorAirSystem:EquipmentList. Also leave blank if terminal unit is used on main AirloopHVAC branch and terminal unit has no fan.")]
[JsonProperty(PropertyName="supply_air_fan_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_SupplyAirFanObjectType SupplyAirFanObjectType { get; set; } = (ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_SupplyAirFanObjectType)Enum.Parse(typeof(ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_SupplyAirFanObjectType), "Empty");
        

[JsonProperty(PropertyName="supply_air_fan_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanObjectName { get; set; } = "";
        

[Description(@"Currently only one type OutdoorAir:Mixer object is available. If this field is blank, and outside air mixer is not used. This field should be left blank if the VRF terminal unit is connected to central dedicated outdoor air through an AirTerminal:SingleDuct:Mixer object. This field may also be left blank when the VRF terminal is used in the air loop or outdoor air system.")]
[JsonProperty(PropertyName="outside_air_mixer_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_OutsideAirMixerObjectType OutsideAirMixerObjectType { get; set; } = (ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_OutsideAirMixerObjectType)Enum.Parse(typeof(ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_OutsideAirMixerObjectType), "OutdoorAirMixer");
        

[Description(@"If this field is blank, the OutdoorAir:Mixer is not used. This optional field specifies the name of the OutdoorAir:Mixer object. When used, this name needs to match name of the OutdoorAir:Mixer object. This field should be left blank if the VRF terminal unit is connected to central dedicated outdoor air through an AirTerminal:SingleDuct:Mixer object. This field may also be left blank when the VRF terminal is used in the air loop or outdoor air system.")]
[JsonProperty(PropertyName="outside_air_mixer_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutsideAirMixerObjectName { get; set; } = "";
        

[Description(@"Cooling Coil Type must be Coil:Cooling:DX:VariableRefrigerantFlow if AirConditioner:VariableRefrigerantFlow is used to model VRF outdoor unit Cooling Coil Type must be Coil:Cooling:DX:VariableRefrigerantFlow:FluidTemperatureControl if AirConditioner:VariableRefrigerantFlow:FluidTemperatureControl or if AirConditioner:VariableRefrigerantFlow:FluidTemperatureControl:HR is used to model VRF outdoor unit This field may be left blank if heating-only mode is used")]
[JsonProperty(PropertyName="cooling_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_CoolingCoilObjectType CoolingCoilObjectType { get; set; } = (ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_CoolingCoilObjectType)Enum.Parse(typeof(ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_CoolingCoilObjectType), "CoilCoolingDXVariableRefrigerantFlow");
        

[Description("Cooling Coil Type must be Coil:Cooling:DX:VariableRefrigerantFlow This field may " +
    "be left blank if heating-only mode is used")]
[JsonProperty(PropertyName="cooling_coil_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilObjectName { get; set; } = "";
        

[Description(@"Heating Coil Type must be Coil:Heating:DX:VariableRefrigerantFlow if AirConditioner:VariableRefrigerantFlow is used to model VRF outdoor unit Heating Coil Type must be Coil:Heating:DX:VariableRefrigerantFlow:FluidTemperatureControl if AirConditioner:VariableRefrigerantFlow:FluidTemperatureControl or if AirConditioner:VariableRefrigerantFlow:FluidTemperatureControl:HR is used to model VRF outdoor unit This field may be left blank if cooling-only mode is used")]
[JsonProperty(PropertyName="heating_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_HeatingCoilObjectType HeatingCoilObjectType { get; set; } = (ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_HeatingCoilObjectType)Enum.Parse(typeof(ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_HeatingCoilObjectType), "CoilHeatingDXVariableRefrigerantFlow");
        

[Description("Heating Coil Type must be Coil:Heating:DX:VariableRefrigerantFlow This field may " +
    "be left blank if cooling-only mode is used")]
[JsonProperty(PropertyName="heating_coil_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilObjectName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_terminal_unit_on_parasitic_electric_energy_use", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneTerminalUnitOnParasiticElectricEnergyUse { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="zone_terminal_unit_off_parasitic_electric_energy_use", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneTerminalUnitOffParasiticElectricEnergyUse { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description(@"If this terminal unit's heating coil is autosized, the heating capacity is sized to be equal to the cooling capacity multiplied by this sizing ratio. This input applies to the terminal unit heating coil and overrides the sizing ratio entered in the AirConditioner:VariableRefrigerantFlow object.")]
[JsonProperty(PropertyName="rated_heating_capacity_sizing_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedHeatingCapacitySizingRatio { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Enter the name of an AvailabilityManagerAssignmentList object.")]
[JsonProperty(PropertyName="availability_manager_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityManagerListName { get; set; } = "";
        

[Description("Enter the name of a DesignSpecificationZoneHVACSizing object.")]
[JsonProperty(PropertyName="design_specification_zonehvac_sizing_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZonehvacSizingObjectName { get; set; } = "";
        

[Description("works with gas, electric, hot water and steam heating coil.")]
[JsonProperty(PropertyName="supplemental_heating_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_SupplementalHeatingCoilObjectType SupplementalHeatingCoilObjectType { get; set; } = (ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_SupplementalHeatingCoilObjectType)Enum.Parse(typeof(ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_SupplementalHeatingCoilObjectType), "CoilHeatingElectric");
        

[Description("Needs to match in the supplemental heating coil object.")]
[JsonProperty(PropertyName="supplemental_heating_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplementalHeatingCoilName { get; set; } = "";
        

[Description("Supply air temperature from the supplemental heater will not exceed this value.")]
[JsonProperty(PropertyName="maximum_supply_air_temperature_from_supplemental_heater", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumSupplyAirTemperatureFromSupplementalHeater { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Supplemental heater will not operate when outdoor temperature exceeds this value." +
    "")]
[JsonProperty(PropertyName="maximum_outdoor_dry_bulb_temperature_for_supplemental_heater_operation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumOutdoorDryBulbTemperatureForSupplementalHeaterOperation { get; set; } = Double.Parse("21", CultureInfo.InvariantCulture);
        

[Description(@"Used only for AirloopHVAC equipment on a main branch and defines zone name where thermostat is located. Not required for zone equipment. Leave blank if terminal unit is used in AirLoopHVAC:OutdoorAirSystem:EquipmentList. Required when terminal unit is used on main AirloopHVAC branch and coils are not set point controlled. When terminal unit is used in air loop and is load controlled, this zone's thermostat will control operation.")]
[JsonProperty(PropertyName="controlling_zone_or_thermostat_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControllingZoneOrThermostatLocation { get; set; } = "";
    }
    
    public enum ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_SupplyAirFanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_SupplyAirFanObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:ConstantVolume")]
        FanConstantVolume = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:OnOff")]
        FanOnOff = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:SystemModel")]
        FanSystemModel = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:VariableVolume")]
        FanVariableVolume = 4,
    }
    
    public enum ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_OutsideAirMixerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAir:Mixer")]
        OutdoorAirMixer = 0,
    }
    
    public enum ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_CoolingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:VariableRefrigerantFlow")]
        CoilCoolingDXVariableRefrigerantFlow = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:VariableRefrigerantFlow:FluidTemperatureControl")]
        CoilCoolingDXVariableRefrigerantFlowFluidTemperatureControl = 1,
    }
    
    public enum ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_HeatingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:DX:VariableRefrigerantFlow")]
        CoilHeatingDXVariableRefrigerantFlow = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:DX:VariableRefrigerantFlow:FluidTemperatureControl")]
        CoilHeatingDXVariableRefrigerantFlowFluidTemperatureControl = 1,
    }
    
    public enum ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_SupplementalHeatingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric")]
        CoilHeatingElectric = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Fuel")]
        CoilHeatingFuel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Steam")]
        CoilHeatingSteam = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Water")]
        CoilHeatingWater = 3,
    }
}
