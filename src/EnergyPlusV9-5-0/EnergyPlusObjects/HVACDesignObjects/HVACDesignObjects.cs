namespace EnergyPlus.HVACDesignObjects
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
    using EnergyPlus.ZoneHVACForcedAirUnits;
    using EnergyPlus.ZoneHVACRadiativeConvectiveUnits;
    
    
    [Description("This object is used to describe general outdoor air requirements which are refere" +
        "nced by other objects.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class DesignSpecification_OutdoorAir
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description(@"Flow/Person => Outdoor Air Flow per Person * Occupancy = Design Flow Rate, Flow/Area => Outdoor Air Flow per Zone Floor Area * Zone Floor Area = Design Flow Rate, Flow/Zone => Outdoor Air Flow per Zone = Design Flow Rate, AirChanges/Hour => Outdoor Air Flow Air Changes per Hour * Zone Volume adjusted for m3/s = Design Flow Rate")]
[JsonProperty(PropertyName="outdoor_air_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public DesignSpecification_OutdoorAir_OutdoorAirMethod OutdoorAirMethod { get; set; } = (DesignSpecification_OutdoorAir_OutdoorAirMethod)Enum.Parse(typeof(DesignSpecification_OutdoorAir_OutdoorAirMethod), "Empty");
        

[Description(@"0.00944 m3/s is equivalent to 20 cfm per person This input is only used if the field Outdoor Air Method is Flow/Person, Sum, or Maximum For sizing, the design number of occupants is used. For outdoor air flow control, the use of design occupants or current occupants depends on the component and DCV options. AirTerminal:SingleDuct:VAV:NoReheat, AirTerminal:SingleDuct:VAV:Reheat use the DCV flag specified in Controller:MechanicalVentilation AirTerminal:DualDuct:VAV:OutdoorAir and ZoneHVAC:IdealLoadsAirSystem have their own DCV control input. ZoneHVAC:FourPipeFanCoil always uses current occupants.")]
[JsonProperty(PropertyName="outdoor_air_flow_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowPerPerson { get; set; } = Double.Parse("0.00944", CultureInfo.InvariantCulture);
        

[Description("This input is only used if the field Outdoor Air Method is Flow/Area, Sum, or Max" +
    "imum")]
[JsonProperty(PropertyName="outdoor_air_flow_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowPerZoneFloorArea { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This input is only used if the field Outdoor Air Method is Flow/Zone, Sum, or Max" +
    "imum")]
[JsonProperty(PropertyName="outdoor_air_flow_per_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowPerZone { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This input is only used if the field Outdoor Air Method is AirChanges/Hour, Sum, " +
    "or Maximum")]
[JsonProperty(PropertyName="outdoor_air_flow_air_changes_per_hour", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutdoorAirFlowAirChangesPerHour { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description(@"Schedule values are multiplied by the Outdoor Air Flow rate calculated using the previous four inputs. Schedule values are limited to 0 to 1. If left blank, the schedule defaults to 1.0. This schedule is ignored during sizing. All other components which reference this design specification use the current schedule value to calculate the current outdoor air requirement. This includes AirTerminal:SingleDuct:VAV:NoReheat, AirTerminal:SingleDuct:VAV:Reheat, AirTerminal:DualDuct:VAV:OutdoorAir, ZoneHVAC:FourPipeFanCoil, and ZoneHVAC:IdealLoadsAirSystem. This schedule will also be applied by Controller:MechanicalVentilation for all System Outdoor Air Methods.")]
[JsonProperty(PropertyName="outdoor_air_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirScheduleName { get; set; } = "";
        

[Description("This input is only used to calculate the minimum outdoor air flow rate when the f" +
    "ield System Outdoor Air Method = ProportionalControlBasedOnDesignOARate in Contr" +
    "oller:MechanicalVentilation.")]
[JsonProperty(PropertyName="proportional_control_minimum_outdoor_air_flow_rate_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ProportionalControlMinimumOutdoorAirFlowRateScheduleName { get; set; } = "";
    }
    
    public enum DesignSpecification_OutdoorAir_OutdoorAirMethod
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
        
        [System.Runtime.Serialization.EnumMember(Value="IndoorAirQualityProcedure")]
        IndoorAirQualityProcedure = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Maximum")]
        Maximum = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="ProportionalControlBasedOnDesignOccupancy")]
        ProportionalControlBasedOnDesignOccupancy = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="ProportionalControlBasedOnOccupancySchedule")]
        ProportionalControlBasedOnOccupancySchedule = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Sum")]
        Sum = 9,
    }
    
    [Description("This object is used to describe zone air distribution in terms of air distributio" +
        "n effectiveness and secondary recirculation fraction. It is referenced by Sizing" +
        ":Zone and Controller:MechanicalVentilation objects")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class DesignSpecification_ZoneAirDistribution
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_air_distribution_effectiveness_in_cooling_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneAirDistributionEffectivenessInCoolingMode { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="zone_air_distribution_effectiveness_in_heating_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneAirDistributionEffectivenessInHeatingMode { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("optionally used to replace Zone Air Distribution Effectiveness in Cooling and Hea" +
    "ting Mode")]
[JsonProperty(PropertyName="zone_air_distribution_effectiveness_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneAirDistributionEffectivenessScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_secondary_recirculation_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneSecondaryRecirculationFraction { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_zone_ventilation_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumZoneVentilationEfficiency { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    [Description(@"Specifies global heating and cooling sizing factors/ratios. These ratios are applied at the zone level to all of the zone heating and cooling loads and air flow rates. Then these new loads and air flow rates are used to calculate the system level flow rates and capacities and are used in all component sizing calculations. Specifies the width (in load timesteps) of a moving average window which is used to smooth the peak load across more than one timestep.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Sizing_Parameters
    {
        

[JsonProperty(PropertyName="heating_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingSizingFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cooling_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingSizingFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("blank => set the timesteps in averaging window to Number of Timesteps per Hour re" +
    "sulting in a 1 hour averaging window default is number of timesteps for 1 hour a" +
    "veraging window")]
[JsonProperty(PropertyName="timesteps_in_averaging_window", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TimestepsInAveragingWindow { get; set; } = null;
    }
    
    [Description(@"Specifies the data needed to perform a zone design air flow calculation. The calculation is done for every sizing period included in the input. The maximum cooling and heating load and cooling, heating, and ventilation air flows are then saved for system level and zone component design calculations.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Sizing_Zone
    {
        

[JsonProperty(PropertyName="zone_or_zonelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneOrZonelistName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Sizing_Zone_ZoneCoolingDesignSupplyAirTemperatureInputMethod ZoneCoolingDesignSupplyAirTemperatureInputMethod { get; set; } = (Sizing_Zone_ZoneCoolingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(Sizing_Zone_ZoneCoolingDesignSupplyAirTemperatureInputMethod), "SupplyAirTemperature");
        

[Description("Zone Cooling Design Supply Air Temperature is only used when Zone Cooling Design " +
    "Supply Air Temperature Input Method = SupplyAirTemperature")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirTemperature { get; set; } = null;
        

[Description(@"Zone Cooling Design Supply Air Temperature is only used when Zone Cooling Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be subtracted from the zone temperature at peak load to calculate the Zone Cooling Design Supply Air Temperature.")]
[JsonProperty(PropertyName="zone_cooling_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirTemperatureDifference { get; set; } = null;
        

[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Sizing_Zone_ZoneHeatingDesignSupplyAirTemperatureInputMethod ZoneHeatingDesignSupplyAirTemperatureInputMethod { get; set; } = (Sizing_Zone_ZoneHeatingDesignSupplyAirTemperatureInputMethod)Enum.Parse(typeof(Sizing_Zone_ZoneHeatingDesignSupplyAirTemperatureInputMethod), "SupplyAirTemperature");
        

[Description("Zone Heating Design Supply Air Temperature is only used when Zone Heating Design " +
    "Supply Air Temperature Input Method = SupplyAirTemperature")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirTemperature { get; set; } = null;
        

[Description(@"Zone Heating Design Supply Air Temperature is only used when Zone Heating Design Supply Air Temperature Input Method = TemperatureDifference The absolute value of this field will be added to the zone temperature at peak load to calculate the Zone Heating Design Supply Air Temperature.")]
[JsonProperty(PropertyName="zone_heating_design_supply_air_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirTemperatureDifference { get; set; } = null;
        

[JsonProperty(PropertyName="zone_cooling_design_supply_air_humidity_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingDesignSupplyAirHumidityRatio { get; set; } = null;
        

[JsonProperty(PropertyName="zone_heating_design_supply_air_humidity_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingDesignSupplyAirHumidityRatio { get; set; } = null;
        

[JsonProperty(PropertyName="design_specification_outdoor_air_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationOutdoorAirObjectName { get; set; } = "";
        

[Description("if blank or zero, global heating sizing factor from Sizing:Parameters is used.")]
[JsonProperty(PropertyName="zone_heating_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneHeatingSizingFactor { get; set; } = null;
        

[Description("if blank or zero, global cooling sizing factor from Sizing:Parameters is used.")]
[JsonProperty(PropertyName="zone_cooling_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneCoolingSizingFactor { get; set; } = null;
        

[JsonProperty(PropertyName="cooling_design_air_flow_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Sizing_Zone_CoolingDesignAirFlowMethod CoolingDesignAirFlowMethod { get; set; } = (Sizing_Zone_CoolingDesignAirFlowMethod)Enum.Parse(typeof(Sizing_Zone_CoolingDesignAirFlowMethod), "DesignDay");
        

[Description("This input is used if Cooling Design Air Flow Method is Flow/Zone This value will" +
    " be multiplied by the global or zone sizing factor and by zone multipliers.")]
[JsonProperty(PropertyName="cooling_design_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingDesignAirFlowRate { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("default is .15 cfm/ft2 This input is used if Cooling Design Air Flow Method is De" +
    "signDayWithLimit")]
[JsonProperty(PropertyName="cooling_minimum_air_flow_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingMinimumAirFlowPerZoneFloorArea { get; set; } = Double.Parse("0.000762", CultureInfo.InvariantCulture);
        

[Description("This input is used if Cooling Design Air Flow Method is DesignDayWithLimit")]
[JsonProperty(PropertyName="cooling_minimum_air_flow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingMinimumAirFlow { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("fraction of the Cooling design Air Flow Rate This input is currently used in sizi" +
    "ng the VAV air terminal unit and fan minimum flow rate It does not currently aff" +
    "ect other component autosizing.")]
[JsonProperty(PropertyName="cooling_minimum_air_flow_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingMinimumAirFlowFraction { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_design_air_flow_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Sizing_Zone_HeatingDesignAirFlowMethod HeatingDesignAirFlowMethod { get; set; } = (Sizing_Zone_HeatingDesignAirFlowMethod)Enum.Parse(typeof(Sizing_Zone_HeatingDesignAirFlowMethod), "DesignDay");
        

[Description("This input is used if Heating Design Air Flow Method is Flow/Zone. This value wil" +
    "l be multiplied by the global or zone sizing factor and by zone multipliers.")]
[JsonProperty(PropertyName="heating_design_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingDesignAirFlowRate { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("default is .40 cfm/ft2 This field is used to size the heating design flow rate wh" +
    "en Heating Design Air Flow Method = Flow/Zone. This input is used for autosizing" +
    " components when Heating Design Air Flow Method = DesignDayWithLimit.")]
[JsonProperty(PropertyName="heating_maximum_air_flow_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingMaximumAirFlowPerZoneFloorArea { get; set; } = Double.Parse("0.002032", CultureInfo.InvariantCulture);
        

[Description("default is 300 cfm This input is used for autosizing components when Heating Desi" +
    "gn Air Flow Method = DesignDayWithLimit.")]
[JsonProperty(PropertyName="heating_maximum_air_flow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingMaximumAirFlow { get; set; } = Double.Parse("0.1415762", CultureInfo.InvariantCulture);
        

[Description("fraction of the Heating Design Air Flow Rate This input is used for autosizing co" +
    "mponents when Heating Design Air Flow Method = DesignDayWithLimit.")]
[JsonProperty(PropertyName="heating_maximum_air_flow_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingMaximumAirFlowFraction { get; set; } = Double.Parse("0.3", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="design_specification_zone_air_distribution_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZoneAirDistributionObjectName { get; set; } = "";
        

[Description("account for effect of dedicated outdoor air system supplying air directly to the " +
    "zone")]
[JsonProperty(PropertyName="account_for_dedicated_outdoor_air_system", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes AccountForDedicatedOutdoorAirSystem { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("1)supply neutral ventilation air; 2)supply neutral dehumidified and reheated vent" +
    "ilation air; 3)supply cold ventilation air")]
[JsonProperty(PropertyName="dedicated_outdoor_air_system_control_strategy", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Sizing_Zone_DedicatedOutdoorAirSystemControlStrategy DedicatedOutdoorAirSystemControlStrategy { get; set; } = (Sizing_Zone_DedicatedOutdoorAirSystemControlStrategy)Enum.Parse(typeof(Sizing_Zone_DedicatedOutdoorAirSystemControlStrategy), "NeutralSupplyAir");
        

[JsonProperty(PropertyName="dedicated_outdoor_air_low_setpoint_temperature_for_design", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DedicatedOutdoorAirLowSetpointTemperatureForDesign { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="dedicated_outdoor_air_high_setpoint_temperature_for_design", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DedicatedOutdoorAirHighSetpointTemperatureForDesign { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
    }
    
    public enum Sizing_Zone_ZoneCoolingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 2,
    }
    
    public enum Sizing_Zone_ZoneHeatingDesignSupplyAirTemperatureInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureDifference")]
        TemperatureDifference = 2,
    }
    
    public enum Sizing_Zone_CoolingDesignAirFlowMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DesignDay")]
        DesignDay = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DesignDayWithLimit")]
        DesignDayWithLimit = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Zone")]
        FlowZone = 3,
    }
    
    public enum Sizing_Zone_HeatingDesignAirFlowMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DesignDay")]
        DesignDay = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DesignDayWithLimit")]
        DesignDayWithLimit = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/Zone")]
        FlowZone = 3,
    }
    
    public enum Sizing_Zone_DedicatedOutdoorAirSystemControlStrategy
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ColdSupplyAir")]
        ColdSupplyAir = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="NeutralDehumidifiedSupplyAir")]
        NeutralDehumidifiedSupplyAir = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="NeutralSupplyAir")]
        NeutralSupplyAir = 3,
    }
    
    [Description("This object is used to describe general scalable zone HVAC equipment sizing which" +
        " are referenced by other objects.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class DesignSpecification_ZoneHVAC_Sizing
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description(@"Enter the method used to determine the cooling supply air volume flow rate. None is used when a cooling coil is not included in the Zone HVAC Equip or this field may be blank. SupplyAirFlowRate => selected when the magnitude of the supply air volume flow rate is specified. FlowPerFloorArea => selected when the supply air volume flow rate is determined from total floor area served by the Zone HVAC unit and Flow Per Floor Area value specified. FractionOfAutosizedCoolingAirflow => is selected when the supply air volume is determined from a user specified fraction and the autosized cooling supply air flow rate value determined by the simulation. FlowPerCoolingCapacity => is selected when the supply air volume is determined from user specified flow per Cooling Capacity and Cooling Capacity determined by the simulation.")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public DesignSpecification_ZoneHVAC_Sizing_CoolingSupplyAirFlowRateMethod CoolingSupplyAirFlowRateMethod { get; set; } = (DesignSpecification_ZoneHVAC_Sizing_CoolingSupplyAirFlowRateMethod)Enum.Parse(typeof(DesignSpecification_ZoneHVAC_Sizing_CoolingSupplyAirFlowRateMethod), "SupplyAirFlowRate");
        

[Description("Enter the magnitude of supply air volume flow rate during cooling operation. Requ" +
    "ired field when Cooling Supply Air Flow Rate Method is SupplyAirFlowRate. This f" +
    "ield may be blank if a cooling coil is not included in the Zone HVAC equipment.")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the cooling supply air volume flow rate per total conditioned floor area. R" +
    "equired field when Cooling Supply Air Flow Rate Method is FlowPerFloorArea. This" +
    " field may be blank if a cooling coil is not included in the Zone HVAC equipment" +
    ".")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingSupplyAirFlowRatePerFloorArea { get; set; } = null;
        

[Description(@"Enter the supply air volume flow rate as a fraction of the cooling supply air flow rate. Required field when Cooling Supply Air Flow Rate Method is FractionOfAutosizedCoolingAirflow. This field may be blank if a cooling coil is not included in the Zone HVAC equipment.")]
[JsonProperty(PropertyName="cooling_fraction_of_autosized_cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingFractionOfAutosizedCoolingSupplyAirFlowRate { get; set; } = null;
        

[Description("Enter the cooling supply air volume flow rate unit cooling capacity. Required fie" +
    "ld when Cooling Supply Air Flow Rate Method is FlowPerCoolingCapacity. This fiel" +
    "d may be blank if a cooling coil is not included in the Zone HVAC equipment.")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate_per_unit_cooling_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingSupplyAirFlowRatePerUnitCoolingCapacity { get; set; } = null;
        

[Description(@"Enter the method used to determine the supply air volume flow rate When No Cooling or Heating is Required. None is used when a cooling or heating coil is not included in the Zone HVAC Equipment or this field may be blank. SupplyAirFlowRate => selected when the magnitude of the supply air volume flow rate is specified. FlowPerFloorArea => selected when the supply air volume flow rate is determined from total floor area served by the Zone HVAC unit and Flow Per Floor Area is specified. FractionOfAutosizedCoolingAirflow => is selected when the supply air volume is determined from a user specified fraction and the Autosized cooling supply air flow rate value determined by the simulation. FractionOfAutosizedHeatingAirflow => is selected when the supply air volume is determined from a user specified fraction and the Autosized heating supply air flow rate value determined by the simulation.")]
[JsonProperty(PropertyName="no_load_supply_air_flow_rate_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public DesignSpecification_ZoneHVAC_Sizing_NoLoadSupplyAirFlowRateMethod NoLoadSupplyAirFlowRateMethod { get; set; } = (DesignSpecification_ZoneHVAC_Sizing_NoLoadSupplyAirFlowRateMethod)Enum.Parse(typeof(DesignSpecification_ZoneHVAC_Sizing_NoLoadSupplyAirFlowRateMethod), "SupplyAirFlowRate");
        

[Description("Enter the magnitude of the supply air volume flow rate during when no cooling or " +
    "heating is required. Required field when No Load Supply Air Flow Rate Method is " +
    "SupplyAirFlowRate.")]
[JsonProperty(PropertyName="no_load_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoLoadSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the supply air volume flow rate per total floor area. Required field when N" +
    "o Load Supply Air Flow Rate Method is FlowPerFloorArea.")]
[JsonProperty(PropertyName="no_load_supply_air_flow_rate_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NoLoadSupplyAirFlowRatePerFloorArea { get; set; } = null;
        

[Description("Enter the supply air volume flow rate as a fraction of the cooling supply air flo" +
    "w rate. Required field when No Load Supply Air Flow Rate Method is FractionOfAut" +
    "osizedCoolingAirflow.")]
[JsonProperty(PropertyName="no_load_fraction_of_cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NoLoadFractionOfCoolingSupplyAirFlowRate { get; set; } = null;
        

[Description("Enter the supply air volume flow rate as a fraction of the heating supply air flo" +
    "w rate. Required field when No Load Supply Air Flow Rate Method is FractionOfAut" +
    "osizedHeatingAirflow.")]
[JsonProperty(PropertyName="no_load_fraction_of_heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NoLoadFractionOfHeatingSupplyAirFlowRate { get; set; } = null;
        

[Description(@"Enter the method used to determine the heating supply air volume flow rate. None is used when a heating coil is not included in the Zone HVAC Equipment or this field may be blank. SupplyAirFlowRate => selected when the magnitude of the heating supply air volume flow rate is specified. FlowPerFloorArea => selected when the supply air volume flow rate is determined from total floor area served by a Zone HVAC unit and user specified value of Flow Per Floor Area. FractionOfAutosizedHeatingAirflow => is selected when the supply air volume is determined from a user specified fraction and the Autosized heating supply air flow rate value determined by the simulation. FlowPerHeatingCapacity => is selected when the supply air volume is determined from user specified flow per Heating Capacity and Heating Capacity determined by the simulation.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public DesignSpecification_ZoneHVAC_Sizing_HeatingSupplyAirFlowRateMethod HeatingSupplyAirFlowRateMethod { get; set; } = (DesignSpecification_ZoneHVAC_Sizing_HeatingSupplyAirFlowRateMethod)Enum.Parse(typeof(DesignSpecification_ZoneHVAC_Sizing_HeatingSupplyAirFlowRateMethod), "SupplyAirFlowRate");
        

[Description("Enter the magnitude of the supply air volume flow rate during heating operation. " +
    "Required field when Heating Supply Air Flow Rate Method is SupplyAirFlowRate. Th" +
    "is field may be blank if a heating coil is not included in the Zone HVAC equipme" +
    "nt.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the heating supply air volume flow rate per total conditioned floor area. R" +
    "equired field when Heating Supply Air Flow Rate Method is FlowPerFloorArea. This" +
    " field may be blank if a heating coil is not included in the Zone HVAC equipment" +
    ".")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingSupplyAirFlowRatePerFloorArea { get; set; } = null;
        

[Description(@"Enter the supply air volume flow rate as a fraction of the heating supply air flow rate. Required field when Heating Supply Air Flow Rate Method is FractionOfAutosizedHeatingAirflow. This field may be blank if a heating coil is not included in the Zone HVAC equipment.")]
[JsonProperty(PropertyName="heating_fraction_of_heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingFractionOfHeatingSupplyAirFlowRate { get; set; } = null;
        

[Description("Enter the supply air volume flow rate per unit heating capacity. Required field w" +
    "hen Heating Supply Air Flow Rate Method is FlowPerHeatingCapacity. This field ma" +
    "y be blank if a heating coil is not included in the Zone HVAC equipment.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate_per_unit_heating_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingSupplyAirFlowRatePerUnitHeatingCapacity { get; set; } = null;
        

[Description(@"Enter the method used to determine the cooling design capacity for scalable sizing. None is used when a cooling coils is not included in the Zone HVAC Equipment or this field may be blank. If this input field is left blank, then the design cooling capacity is set to zero. CoolingDesignCapacity => selected when the design cooling capacity value is specified or auto-sized. CapacityPerFloorArea => selected when the design cooling capacity is determine from user specified cooling capacity per floor area and zone floor area. FractionOfAutosizedCoolingCapacity => is selected when the design cooling capacity is determined from a user specified fraction and the auto-sized design cooling capacity.")]
[JsonProperty(PropertyName="cooling_design_capacity_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public DesignSpecification_ZoneHVAC_Sizing_CoolingDesignCapacityMethod CoolingDesignCapacityMethod { get; set; } = (DesignSpecification_ZoneHVAC_Sizing_CoolingDesignCapacityMethod)Enum.Parse(typeof(DesignSpecification_ZoneHVAC_Sizing_CoolingDesignCapacityMethod), "None");
        

[Description("Enter the design cooling capacity. Required field when the cooling design capacit" +
    "y method CoolingDesignCapacity.")]
[JsonProperty(PropertyName="cooling_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingDesignCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the cooling design capacity per zone floor area. Required field when the co" +
    "oling design capacity method field is CapacityPerFloorArea.")]
[JsonProperty(PropertyName="cooling_design_capacity_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingDesignCapacityPerFloorArea { get; set; } = null;
        

[Description("Enter the fraction of auto-sized cooling design capacity. Required field when the" +
    " cooling design capacity method field is FractionOfAutosizedCoolingCapacity.")]
[JsonProperty(PropertyName="fraction_of_autosized_cooling_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfAutosizedCoolingDesignCapacity { get; set; } = null;
        

[Description(@"Enter the method used to determine the heating design capacity for scalable sizing. None is used when a heating coil is not included in the Zone HVAC Equipment or this field may be blank. If this input field is left blank, then the design heating capacity is set to zero. HeatingDesignCapacity => selected when the design heating capacity value is specified or auto-sized. CapacityPerFloorArea => selected when the design cooling capacity is determine from user specified heating capacity per flow area and zone floor area. FractionOfAutosizedHeatingCapacity => is selected when the design heating capacity is determined from a user specified fraction and the auto-sized design heating capacity")]
[JsonProperty(PropertyName="heating_design_capacity_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public DesignSpecification_ZoneHVAC_Sizing_HeatingDesignCapacityMethod HeatingDesignCapacityMethod { get; set; } = (DesignSpecification_ZoneHVAC_Sizing_HeatingDesignCapacityMethod)Enum.Parse(typeof(DesignSpecification_ZoneHVAC_Sizing_HeatingDesignCapacityMethod), "None");
        

[Description("Enter the design heating capacity. Required field when the heating design capacit" +
    "y method HeatingDesignCapacity.")]
[JsonProperty(PropertyName="heating_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingDesignCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the heating design capacity per zone floor area. Required field when the he" +
    "ating design capacity method field is CapacityPerFloorArea.")]
[JsonProperty(PropertyName="heating_design_capacity_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingDesignCapacityPerFloorArea { get; set; } = null;
        

[Description("Enter the fraction of auto-sized heating design capacity. Required field when cap" +
    "acity the heating design capacity method field is FractionOfAutosizedHeatingCapa" +
    "city.")]
[JsonProperty(PropertyName="fraction_of_autosized_heating_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfAutosizedHeatingDesignCapacity { get; set; } = null;
    }
    
    public enum DesignSpecification_ZoneHVAC_Sizing_CoolingSupplyAirFlowRateMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FlowPerCoolingCapacity")]
        FlowPerCoolingCapacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FlowPerFloorArea")]
        FlowPerFloorArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedCoolingAirflow")]
        FractionOfAutosizedCoolingAirflow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirFlowRate")]
        SupplyAirFlowRate = 5,
    }
    
    public enum DesignSpecification_ZoneHVAC_Sizing_NoLoadSupplyAirFlowRateMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FlowPerFloorArea")]
        FlowPerFloorArea = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedCoolingAirflow")]
        FractionOfAutosizedCoolingAirflow = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedHeatingAirflow")]
        FractionOfAutosizedHeatingAirflow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirFlowRate")]
        SupplyAirFlowRate = 5,
    }
    
    public enum DesignSpecification_ZoneHVAC_Sizing_HeatingSupplyAirFlowRateMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FlowPerFloorArea")]
        FlowPerFloorArea = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FlowPerHeatingCapacity")]
        FlowPerHeatingCapacity = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedHeatingAirflow")]
        FractionOfAutosizedHeatingAirflow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirFlowRate")]
        SupplyAirFlowRate = 5,
    }
    
    public enum DesignSpecification_ZoneHVAC_Sizing_CoolingDesignCapacityMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CapacityPerFloorArea")]
        CapacityPerFloorArea = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingDesignCapacity")]
        CoolingDesignCapacity = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedCoolingCapacity")]
        FractionOfAutosizedCoolingCapacity = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum DesignSpecification_ZoneHVAC_Sizing_HeatingDesignCapacityMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CapacityPerFloorArea")]
        CapacityPerFloorArea = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedHeatingCapacity")]
        FractionOfAutosizedHeatingCapacity = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatingDesignCapacity")]
        HeatingDesignCapacity = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    [Description("This object is used to scale the sizing of air terminal units.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class DesignSpecification_AirTerminal_Sizing
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("The fraction of the design sensible cooling load to be met by this terminal unit." +
    " This fraction is applied after the Zone Cooling Sizing Factor (see Sizing:Zone)" +
    ".")]
[JsonProperty(PropertyName="fraction_of_design_cooling_load", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfDesignCoolingLoad { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("This ratio adjusts the supply air temperature difference used to calculate the co" +
    "oling design supply air flow rate for this terminal unit.")]
[JsonProperty(PropertyName="cooling_design_supply_air_temperature_difference_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingDesignSupplyAirTemperatureDifferenceRatio { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("The fraction of the design sensible heating load to be met by this terminal unit." +
    " This fraction is applied after the Zone Heating Sizing Factor (see Sizing:Zone)" +
    ".")]
[JsonProperty(PropertyName="fraction_of_design_heating_load", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfDesignHeatingLoad { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("This ratio adjusts the supply air temperature difference used to calculate the he" +
    "ating design supply air flow rate for this terminal unit.")]
[JsonProperty(PropertyName="heating_design_supply_air_temperature_difference_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingDesignSupplyAirTemperatureDifferenceRatio { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("The fraction of the zone minimum outdoor air requirement to be met by this termin" +
    "al unit.")]
[JsonProperty(PropertyName="fraction_of_minimum_outdoor_air_flow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfMinimumOutdoorAirFlow { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
    }
    
    [Description("Specifies the input needed to perform sizing calculations for a central forced ai" +
        "r system. System design air flow, heating capacity, and cooling capacity will be" +
        " calculated using this input data.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Sizing_System
    {
        

[JsonProperty(PropertyName="airloop_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirloopName { get; set; } = "";
        

[Description(@"Specifies the basis for sizing the system supply air flow rate Sensible and Total use the zone design air flow rates to size the system supply air flow rate The cooling coil will then be sized at either the peak Sensible or Total flow rate and conditions The heating coil is always sized at the peak sensible heating load. VentilationRequirement uses the system ventilation requirement")]
[JsonProperty(PropertyName="type_of_load_to_size_on", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Sizing_System_TypeOfLoadToSizeOn TypeOfLoadToSizeOn { get; set; } = (Sizing_System_TypeOfLoadToSizeOn)Enum.Parse(typeof(Sizing_System_TypeOfLoadToSizeOn), "Sensible");
        

[JsonProperty(PropertyName="design_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="central_heating_maximum_system_air_flow_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CentralHeatingMaximumSystemAirFlowRatio { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="preheat_design_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PreheatDesignTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="preheat_design_humidity_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PreheatDesignHumidityRatio { get; set; } = null;
        

[JsonProperty(PropertyName="precool_design_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PrecoolDesignTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="precool_design_humidity_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PrecoolDesignHumidityRatio { get; set; } = null;
        

[JsonProperty(PropertyName="central_cooling_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CentralCoolingDesignSupplyAirTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="central_heating_design_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CentralHeatingDesignSupplyAirTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="type_of_zone_sum_to_use", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Sizing_System_TypeOfZoneSumToUse TypeOfZoneSumToUse { get; set; } = (Sizing_System_TypeOfZoneSumToUse)Enum.Parse(typeof(Sizing_System_TypeOfZoneSumToUse), "NonCoincident");
        

[JsonProperty(PropertyName="100_outdoor_air_in_cooling", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes _100OutdoorAirInCooling { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[JsonProperty(PropertyName="100_outdoor_air_in_heating", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes _100OutdoorAirInHeating { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[JsonProperty(PropertyName="central_cooling_design_supply_air_humidity_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CentralCoolingDesignSupplyAirHumidityRatio { get; set; } = Double.Parse("0.008", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="central_heating_design_supply_air_humidity_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CentralHeatingDesignSupplyAirHumidityRatio { get; set; } = Double.Parse("0.008", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cooling_supply_air_flow_rate_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Sizing_System_CoolingSupplyAirFlowRateMethod CoolingSupplyAirFlowRateMethod { get; set; } = (Sizing_System_CoolingSupplyAirFlowRateMethod)Enum.Parse(typeof(Sizing_System_CoolingSupplyAirFlowRateMethod), "DesignDay");
        

[Description("This input is used if Cooling Supply Air Flow Rate Method is Flow/System This val" +
    "ue will *not* be multiplied by any sizing factor or by zone multipliers. If usin" +
    "g zone multipliers, this value must be large enough to serve the multiplied zone" +
    "s.")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingSupplyAirFlowRate { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Enter the cooling supply air volume flow rate per total conditioned floor area. R" +
    "equired field when Cooling Supply Air Flow Rate Method is FlowPerFloorArea.")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingSupplyAirFlowRatePerFloorArea { get; set; } = null;
        

[Description("Enter the supply air volume flow rate as a fraction of the cooling supply air flo" +
    "w rate. Required field when Cooling Supply Air Flow Rate Method is FractionOfAut" +
    "osizedCoolingAirflow.")]
[JsonProperty(PropertyName="cooling_fraction_of_autosized_cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingFractionOfAutosizedCoolingSupplyAirFlowRate { get; set; } = null;
        

[Description("Enter the supply air volume flow rate per unit cooling capacity. Required field w" +
    "hen Cooling Supply Air Flow Rate Method is FlowPerCoolingCapacity.")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate_per_unit_cooling_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingSupplyAirFlowRatePerUnitCoolingCapacity { get; set; } = null;
        

[JsonProperty(PropertyName="heating_supply_air_flow_rate_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Sizing_System_HeatingSupplyAirFlowRateMethod HeatingSupplyAirFlowRateMethod { get; set; } = (Sizing_System_HeatingSupplyAirFlowRateMethod)Enum.Parse(typeof(Sizing_System_HeatingSupplyAirFlowRateMethod), "DesignDay");
        

[Description("Required field when Heating Supply Air Flow Rate Method is Flow/System This value" +
    " will *not* be multiplied by any sizing factor or by zone multipliers. If using " +
    "zone multipliers, this value must be large enough to serve the multiplied zones." +
    "")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingSupplyAirFlowRate { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Enter the heating supply air volume flow rate per total conditioned floor area. R" +
    "equired field when Heating Supply Air Flow Rate Method is FlowPerFloorArea.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingSupplyAirFlowRatePerFloorArea { get; set; } = null;
        

[Description("Enter the supply air volume flow rate as a fraction of the heating supply air flo" +
    "w rate. Required field when Heating Supply Air Flow Rate Method is FractionOfAut" +
    "osizedHeatingAirflow.")]
[JsonProperty(PropertyName="heating_fraction_of_autosized_heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingFractionOfAutosizedHeatingSupplyAirFlowRate { get; set; } = null;
        

[Description("Enter the supply air volume flow rate as a fraction of the cooling supply air flo" +
    "w rate. Required field when Heating Supply Air Flow Rate Method is FractionOfAut" +
    "osizedCoolingAirflow.")]
[JsonProperty(PropertyName="heating_fraction_of_autosized_cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingFractionOfAutosizedCoolingSupplyAirFlowRate { get; set; } = null;
        

[Description("Enter the heating supply air volume flow rate per unit heating capacity. Required" +
    " field when Heating Supply Air Flow Rate Method is FlowPerHeatingCapacity.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate_per_unit_heating_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingSupplyAirFlowRatePerUnitHeatingCapacity { get; set; } = null;
        

[JsonProperty(PropertyName="system_outdoor_air_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Sizing_System_SystemOutdoorAirMethod SystemOutdoorAirMethod { get; set; } = (Sizing_System_SystemOutdoorAirMethod)Enum.Parse(typeof(Sizing_System_SystemOutdoorAirMethod), "ZoneSum");
        

[JsonProperty(PropertyName="zone_maximum_outdoor_air_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneMaximumOutdoorAirFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description(@"Enter the method used to determine the system cooling design capacity for scalable sizing. None is used when a cooling coils is not included in an airloop or this field may be blank. If this input field is left blank, then the design cooling capacity is set to zero. CoolingDesignCapacity => selected when the design cooling capacity value is specified or auto-sized. CapacityPerFloorArea => selected when the design cooling capacity is determined from user specified cooling capacity per floor area and total floor area of cooled zones served by an airloop. FractionOfAutosizedCoolingCapacity => is selected when the design cooling capacity is determined from a user specified fraction and the auto-sized design cooling capacity of the system.")]
[JsonProperty(PropertyName="cooling_design_capacity_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Sizing_System_CoolingDesignCapacityMethod CoolingDesignCapacityMethod { get; set; } = (Sizing_System_CoolingDesignCapacityMethod)Enum.Parse(typeof(Sizing_System_CoolingDesignCapacityMethod), "CoolingDesignCapacity");
        

[Description("Enter the design cooling capacity.")]
[JsonProperty(PropertyName="cooling_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingDesignCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the cooling design capacity per total floor area of cooled zones served by " +
    "an airloop. Required field when the cooling design capacity method field is Capa" +
    "cityPerFloorArea.")]
[JsonProperty(PropertyName="cooling_design_capacity_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingDesignCapacityPerFloorArea { get; set; } = null;
        

[Description("Enter the fraction of auto-sized cooling design capacity. Required field when the" +
    " cooling design capacity method field is FractionOfAutosizedCoolingCapacity.")]
[JsonProperty(PropertyName="fraction_of_autosized_cooling_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfAutosizedCoolingDesignCapacity { get; set; } = null;
        

[Description(@"Enter the method used to determine the heating design capacity for scalable sizing. None is used when a heating coil not included in an airloop or this field may be blank. If this input field is left blank, then the design heating capacity is set to zero. HeatingDesignCapacity => selected when the design heating capacity value is specified or auto-sized. CapacityPerFloorArea => selected when the design heating capacity is determined from user specified heating capacity per flow area and total floor area of heated zones served by an airloop. FractionOfAutosizedHeatingCapacity => is selected when the design heating capacity is determined from a user specified fraction and the auto-sized design heating capacity of the system.")]
[JsonProperty(PropertyName="heating_design_capacity_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Sizing_System_HeatingDesignCapacityMethod HeatingDesignCapacityMethod { get; set; } = (Sizing_System_HeatingDesignCapacityMethod)Enum.Parse(typeof(Sizing_System_HeatingDesignCapacityMethod), "HeatingDesignCapacity");
        

[Description("Enter the design heating capacity.")]
[JsonProperty(PropertyName="heating_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingDesignCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the heating design capacity per zone floor area. Required field when the he" +
    "ating design capacity method field is CapacityPerFloorArea.")]
[JsonProperty(PropertyName="heating_design_capacity_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingDesignCapacityPerFloorArea { get; set; } = null;
        

[Description("Enter the fraction of auto-sized heating design capacity. Required field when cap" +
    "acity the heating design capacity method field is FractionOfAutosizedHeatingCapa" +
    "city.")]
[JsonProperty(PropertyName="fraction_of_autosized_heating_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfAutosizedHeatingDesignCapacity { get; set; } = null;
        

[Description("Method used to control the coil\'s output")]
[JsonProperty(PropertyName="central_cooling_capacity_control_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Sizing_System_CentralCoolingCapacityControlMethod CentralCoolingCapacityControlMethod { get; set; } = (Sizing_System_CentralCoolingCapacityControlMethod)Enum.Parse(typeof(Sizing_System_CentralCoolingCapacityControlMethod), "OnOff");
    }
    
    public enum Sizing_System_TypeOfLoadToSizeOn
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Sensible")]
        Sensible = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Total")]
        Total = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="VentilationRequirement")]
        VentilationRequirement = 3,
    }
    
    public enum Sizing_System_TypeOfZoneSumToUse
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coincident")]
        Coincident = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="NonCoincident")]
        NonCoincident = 2,
    }
    
    public enum Sizing_System_CoolingSupplyAirFlowRateMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DesignDay")]
        DesignDay = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/System")]
        FlowSystem = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FlowPerCoolingCapacity")]
        FlowPerCoolingCapacity = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="FlowPerFloorArea")]
        FlowPerFloorArea = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedCoolingAirflow")]
        FractionOfAutosizedCoolingAirflow = 5,
    }
    
    public enum Sizing_System_HeatingSupplyAirFlowRateMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DesignDay")]
        DesignDay = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Flow/System")]
        FlowSystem = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FlowPerFloorArea")]
        FlowPerFloorArea = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="FlowPerHeatingCapacity")]
        FlowPerHeatingCapacity = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedCoolingAirflow")]
        FractionOfAutosizedCoolingAirflow = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedHeatingAirflow")]
        FractionOfAutosizedHeatingAirflow = 6,
    }
    
    public enum Sizing_System_SystemOutdoorAirMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="VentilationRateProcedure")]
        VentilationRateProcedure = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ZoneSum")]
        ZoneSum = 2,
    }
    
    public enum Sizing_System_CoolingDesignCapacityMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CapacityPerFloorArea")]
        CapacityPerFloorArea = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingDesignCapacity")]
        CoolingDesignCapacity = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedCoolingCapacity")]
        FractionOfAutosizedCoolingCapacity = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum Sizing_System_HeatingDesignCapacityMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CapacityPerFloorArea")]
        CapacityPerFloorArea = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedHeatingCapacity")]
        FractionOfAutosizedHeatingCapacity = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatingDesignCapacity")]
        HeatingDesignCapacity = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum Sizing_System_CentralCoolingCapacityControlMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Bypass")]
        Bypass = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="OnOff")]
        OnOff = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="VAV")]
        VAV = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="VT")]
        VT = 4,
    }
    
    [Description(@"Specifies the input needed to autosize plant loop flow rates and equipment capacities. This information is initially used by components that use water for heating or cooling such as hot or chilled water coils to calculate their maximum water flow rates. These flow rates are then summed for use in calculating the Plant Loop flow rates.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Sizing_Plant
    {
        

[Description("Enter the name of a PlantLoop or a CondenserLoop object")]
[JsonProperty(PropertyName="plant_or_condenser_loop_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PlantOrCondenserLoopName { get; set; } = "";
        

[JsonProperty(PropertyName="loop_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Sizing_Plant_LoopType LoopType { get; set; } = (Sizing_Plant_LoopType)Enum.Parse(typeof(Sizing_Plant_LoopType), "Condenser");
        

[JsonProperty(PropertyName="design_loop_exit_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignLoopExitTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="loop_design_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoopDesignTemperatureDifference { get; set; } = null;
        

[Description("if Coincident is chosen, then sizing is based on HVAC Sizing Simulations and the " +
    "input field called Do HVAC Sizing Simulation for Sizing Periods in SimulationCon" +
    "trol must be set to Yes")]
[JsonProperty(PropertyName="sizing_option", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Sizing_Plant_SizingOption SizingOption { get; set; } = (Sizing_Plant_SizingOption)Enum.Parse(typeof(Sizing_Plant_SizingOption), "NonCoincident");
        

[Description("this is used in the coincident sizing algorithm to apply a running average to pea" +
    "k flow rates that occur during HVAC Sizing Simulations")]
[JsonProperty(PropertyName="zone_timesteps_in_averaging_window", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneTimestepsInAveragingWindow { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("this is used to adjust the result for coincident sizing by applying a sizing fact" +
    "or")]
[JsonProperty(PropertyName="coincident_sizing_factor_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Sizing_Plant_CoincidentSizingFactorMode CoincidentSizingFactorMode { get; set; } = (Sizing_Plant_CoincidentSizingFactorMode)Enum.Parse(typeof(Sizing_Plant_CoincidentSizingFactorMode), "GlobalCoolingSizingFactor");
    }
    
    public enum Sizing_Plant_LoopType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Condenser")]
        Condenser = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Steam")]
        Steam = 3,
    }
    
    public enum Sizing_Plant_SizingOption
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coincident")]
        Coincident = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="NonCoincident")]
        NonCoincident = 2,
    }
    
    public enum Sizing_Plant_CoincidentSizingFactorMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="GlobalCoolingSizingFactor")]
        GlobalCoolingSizingFactor = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="GlobalHeatingSizingFactor")]
        GlobalHeatingSizingFactor = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="LoopComponentSizingFactor")]
        LoopComponentSizingFactor = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    [Description("Default style for the Sizing output files is comma -- this works well for importi" +
        "ng into spreadsheet programs such as Excel(tm) but not so well for word processi" +
        "ng programs -- there tab may be a better choice. Fixed puts spaces between the \"" +
        "columns\"")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class OutputControl_Sizing_Style
    {
        

[JsonProperty(PropertyName="column_separator", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public OutputControl_Sizing_Style_ColumnSeparator ColumnSeparator { get; set; } = (OutputControl_Sizing_Style_ColumnSeparator)Enum.Parse(typeof(OutputControl_Sizing_Style_ColumnSeparator), "Comma");
    }
    
    public enum OutputControl_Sizing_Style_ColumnSeparator
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Comma")]
        Comma = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fixed")]
        Fixed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Tab")]
        Tab = 2,
    }
}
