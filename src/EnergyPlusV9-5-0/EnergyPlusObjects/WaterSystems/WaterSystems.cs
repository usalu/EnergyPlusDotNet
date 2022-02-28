namespace EnergyPlus.WaterSystems
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
    using EnergyPlus.ZoneAirflow;
    using EnergyPlus.ZoneHVACAirLoopTerminalUnits;
    using EnergyPlus.ZoneHVACControlsandThermostats;
    using EnergyPlus.ZoneHVACEquipmentConnections;
    using EnergyPlus.ZoneHVACForcedAirUnits;
    using EnergyPlus.ZoneHVACRadiativeConvectiveUnits;
    
    
    [Description(@"A generalized object for simulating all water end uses. Hot and cold water uses are included, as well as controlled mixing of hot and cold water at the tap. The WaterUse:Equipment object can be used stand-alone, or coupled into a plant loop using the WaterUse:Connections object (see below). The WaterUse:Connections object allows water uses to be linked to WaterUse:Storage objects to store and draw reclaimed water. The object can also simulate drainwater heat recovery.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WaterUse_Equipment
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
        

[JsonProperty(PropertyName="peak_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PeakFlowRate { get; set; } = null;
        

[Description("Defaults to 1.0 at all times")]
[JsonProperty(PropertyName="flow_rate_fraction_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FlowRateFractionScheduleName { get; set; } = "";
        

[Description("Defaults to hot water supply temperature")]
[JsonProperty(PropertyName="target_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TargetTemperatureScheduleName { get; set; } = "";
        

[Description("Defaults to cold water supply temperature")]
[JsonProperty(PropertyName="hot_water_supply_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HotWaterSupplyTemperatureScheduleName { get; set; } = "";
        

[Description("Defaults to water temperatures calculated by Site:WaterMainsTemperature object")]
[JsonProperty(PropertyName="cold_water_supply_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ColdWaterSupplyTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Defaults to 0.0 at all times")]
[JsonProperty(PropertyName="sensible_fraction_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SensibleFractionScheduleName { get; set; } = "";
        

[Description("Defaults to 0.0 at all times")]
[JsonProperty(PropertyName="latent_fraction_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string LatentFractionScheduleName { get; set; } = "";
    }
    
    [Description(@"A subsystem that groups together multiple WaterUse:Equipment components. As its name suggests, the object provides connections that are shared by these components, including: 1. Inlet node and outlet node connections to a plant loop 2. Connections to WaterUse:Storage objects to store and draw reclaimed water 3. Internal connections to simulate drainwater heat recovery.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WaterUse_Connections
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutletNodeName { get; set; } = "";
        

[Description("If blank, or tank is empty, defaults to fresh water from the mains")]
[JsonProperty(PropertyName="supply_water_storage_tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyWaterStorageTankName { get; set; } = "";
        

[JsonProperty(PropertyName="reclamation_water_storage_tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReclamationWaterStorageTankName { get; set; } = "";
        

[Description("Defaults to cold water supply temperature")]
[JsonProperty(PropertyName="hot_water_supply_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HotWaterSupplyTemperatureScheduleName { get; set; } = "";
        

[Description("Defaults to water temperatures calculated by Site:WaterMainsTemperature object")]
[JsonProperty(PropertyName="cold_water_supply_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ColdWaterSupplyTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="drain_water_heat_exchanger_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterUse_Connections_DrainWaterHeatExchangerType DrainWaterHeatExchangerType { get; set; } = (WaterUse_Connections_DrainWaterHeatExchangerType)Enum.Parse(typeof(WaterUse_Connections_DrainWaterHeatExchangerType), "None");
        

[JsonProperty(PropertyName="drain_water_heat_exchanger_destination", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterUse_Connections_DrainWaterHeatExchangerDestination DrainWaterHeatExchangerDestination { get; set; } = (WaterUse_Connections_DrainWaterHeatExchangerDestination)Enum.Parse(typeof(WaterUse_Connections_DrainWaterHeatExchangerDestination), "Plant");
        

[JsonProperty(PropertyName="drain_water_heat_exchanger_u_factor_times_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DrainWaterHeatExchangerUFactorTimesArea { get; set; } = null;
        

[Description("This list is the WaterUseEquipmentNames object-list")]
[JsonProperty(PropertyName="connections", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Connections { get; set; } = null;
    }
    
    public enum WaterUse_Connections_DrainWaterHeatExchangerType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CounterFlow")]
        CounterFlow = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CrossFlow")]
        CrossFlow = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Ideal")]
        Ideal = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum WaterUse_Connections_DrainWaterHeatExchangerDestination
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Equipment")]
        Equipment = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Plant")]
        Plant = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantAndEquipment")]
        PlantAndEquipment = 3,
    }
    
    [Description(@"A water storage tank. If the building model is to include any on-site water collection, wells, or storing and reuse of graywater, then a WaterUse:Storage object is needed. Each WaterUse:Storage can serve as a central node and make connections to numerous sources of supply or numerous components with demand. If a maximum capacity is not specified, the tank is assumed to have unlimited capacity.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WaterUse_Storage
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="water_quality_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterQualitySubcategory { get; set; } = "";
        

[Description("Defaults to unlimited capacity.")]
[JsonProperty(PropertyName="maximum_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCapacity { get; set; } = null;
        

[JsonProperty(PropertyName="initial_volume", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InitialVolume { get; set; } = null;
        

[Description("Defaults to unlimited flow.")]
[JsonProperty(PropertyName="design_in_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignInFlowRate { get; set; } = null;
        

[Description("Defaults to unlimited flow.")]
[JsonProperty(PropertyName="design_out_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignOutFlowRate { get; set; } = null;
        

[Description("If blank, overflow is discarded")]
[JsonProperty(PropertyName="overflow_destination", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OverflowDestination { get; set; } = "";
        

[JsonProperty(PropertyName="type_of_supply_controlled_by_float_valve", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterUse_Storage_TypeOfSupplyControlledByFloatValve TypeOfSupplyControlledByFloatValve { get; set; } = (WaterUse_Storage_TypeOfSupplyControlledByFloatValve)Enum.Parse(typeof(WaterUse_Storage_TypeOfSupplyControlledByFloatValve), "GroundwaterWell");
        

[Description("Lower range of target storage level e.g. float valve kicks on")]
[JsonProperty(PropertyName="float_valve_on_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FloatValveOnCapacity { get; set; } = null;
        

[Description("Upper range of target storage level e.g. float valve kicks off")]
[JsonProperty(PropertyName="float_valve_off_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FloatValveOffCapacity { get; set; } = null;
        

[Description("Lower range of secondary target storage level used to keep tanks at a minimum lev" +
    "el using mains water if well can\'t keep up")]
[JsonProperty(PropertyName="backup_mains_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackupMainsCapacity { get; set; } = null;
        

[JsonProperty(PropertyName="other_tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OtherTankName { get; set; } = "";
        

[JsonProperty(PropertyName="water_thermal_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterUse_Storage_WaterThermalMode WaterThermalMode { get; set; } = (WaterUse_Storage_WaterThermalMode)Enum.Parse(typeof(WaterUse_Storage_WaterThermalMode), "ScheduledTemperature");
        

[JsonProperty(PropertyName="water_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="ambient_temperature_indicator", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterUse_Storage_AmbientTemperatureIndicator AmbientTemperatureIndicator { get; set; } = (WaterUse_Storage_AmbientTemperatureIndicator)Enum.Parse(typeof(WaterUse_Storage_AmbientTemperatureIndicator), "Outdoors");
        

[JsonProperty(PropertyName="ambient_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AmbientTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="tank_surface_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TankSurfaceArea { get; set; } = null;
        

[JsonProperty(PropertyName="tank_u_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TankUValue { get; set; } = null;
        

[JsonProperty(PropertyName="tank_outside_surface_material_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TankOutsideSurfaceMaterialName { get; set; } = "";
    }
    
    public enum WaterUse_Storage_TypeOfSupplyControlledByFloatValve
    {
        
        [System.Runtime.Serialization.EnumMember(Value="GroundwaterWell")]
        GroundwaterWell = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Mains")]
        Mains = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherTank")]
        OtherTank = 3,
    }
    
    public enum WaterUse_Storage_WaterThermalMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="ScheduledTemperature")]
        ScheduledTemperature = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermalModel")]
        ThermalModel = 1,
    }
    
    public enum WaterUse_Storage_AmbientTemperatureIndicator
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Outdoors")]
        Outdoors = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Schedule")]
        Schedule = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Zone")]
        Zone = 2,
    }
    
    [Description(@"Simulates on-site water supply from a well. Well water is pumped out of the ground into a WaterUse:Storage. The operation of the ground water well is controlled by the associated WaterUse:Storage which is assumed to be operated as a vented cistern with no pressure tank.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WaterUse_Well
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="storage_tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string StorageTankName { get; set; } = "";
        

[JsonProperty(PropertyName="pump_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PumpDepth { get; set; } = null;
        

[JsonProperty(PropertyName="pump_rated_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PumpRatedFlowRate { get; set; } = null;
        

[JsonProperty(PropertyName="pump_rated_head", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PumpRatedHead { get; set; } = null;
        

[JsonProperty(PropertyName="pump_rated_power_consumption", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PumpRatedPowerConsumption { get; set; } = null;
        

[JsonProperty(PropertyName="pump_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PumpEfficiency { get; set; } = null;
        

[JsonProperty(PropertyName="well_recovery_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WellRecoveryRate { get; set; } = null;
        

[JsonProperty(PropertyName="nominal_well_storage_volume", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NominalWellStorageVolume { get; set; } = null;
        

[JsonProperty(PropertyName="water_table_depth_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterUse_Well_WaterTableDepthMode WaterTableDepthMode { get; set; } = (WaterUse_Well_WaterTableDepthMode)Enum.Parse(typeof(WaterUse_Well_WaterTableDepthMode), "Constant");
        

[JsonProperty(PropertyName="water_table_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterTableDepth { get; set; } = null;
        

[JsonProperty(PropertyName="water_table_depth_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterTableDepthScheduleName { get; set; } = "";
    }
    
    public enum WaterUse_Well_WaterTableDepthMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Constant")]
        Constant = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Scheduled")]
        Scheduled = 1,
    }
    
    [Description("Used for harvesting rainwater falling on building surfaces. The rainwater is sent" +
        " to a WaterUse:Storage object. In order to use this object it is necessary to al" +
        "so include a Site:Precipitation object to describe the rates of rainfall.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WaterUse_RainCollector
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="storage_tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string StorageTankName { get; set; } = "";
        

[JsonProperty(PropertyName="loss_factor_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterUse_RainCollector_LossFactorMode LossFactorMode { get; set; } = (WaterUse_RainCollector_LossFactorMode)Enum.Parse(typeof(WaterUse_RainCollector_LossFactorMode), "Constant");
        

[Description("this is the portion of rain that is lost in the process of collecting it the rain" +
    " collected is one minus this factor")]
[JsonProperty(PropertyName="collection_loss_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CollectionLossFactor { get; set; } = null;
        

[JsonProperty(PropertyName="collection_loss_factor_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CollectionLossFactorScheduleName { get; set; } = "";
        

[Description("Defaults to unlimited flow.")]
[JsonProperty(PropertyName="maximum_collection_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCollectionRate { get; set; } = null;
        

[Description("This list is the AllShadingAndHTSurfNames object-list")]
[JsonProperty(PropertyName="surfaces", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Surfaces { get; set; } = null;
    }
    
    public enum WaterUse_RainCollector_LossFactorMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Constant")]
        Constant = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Scheduled")]
        Scheduled = 1,
    }
}
