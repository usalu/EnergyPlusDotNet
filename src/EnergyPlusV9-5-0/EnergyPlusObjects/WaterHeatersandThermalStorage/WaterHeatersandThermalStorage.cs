namespace EnergyPlus.WaterHeatersandThermalStorage
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
    using EnergyPlus.WaterSystems;
    using EnergyPlus.ZoneAirflow;
    using EnergyPlus.ZoneHVACAirLoopTerminalUnits;
    using EnergyPlus.ZoneHVACControlsandThermostats;
    using EnergyPlus.ZoneHVACEquipmentConnections;
    using EnergyPlus.ZoneHVACForcedAirUnits;
    using EnergyPlus.ZoneHVACRadiativeConvectiveUnits;
    
    
    [Description("Water heater with well-mixed, single-node water tank. May be used to model a tank" +
        "less water heater (small tank volume), a hot water storage tank (zero heater cap" +
        "acity), or a heat pump water heater (see WaterHeater:HeatPump:PumpedCondenser.)")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WaterHeater_Mixed
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="tank_volume", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> TankVolume { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="setpoint_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="deadband_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DeadbandTemperatureDifference { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_temperature_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumTemperatureLimit { get; set; } = null;
        

[JsonProperty(PropertyName="heater_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_Mixed_HeaterControlType HeaterControlType { get; set; } = (WaterHeater_Mixed_HeaterControlType)Enum.Parse(typeof(WaterHeater_Mixed_HeaterControlType), "Cycle");
        

[JsonProperty(PropertyName="heater_maximum_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeaterMaximumCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Only used when Heater Control Type is set to Modulate")]
[JsonProperty(PropertyName="heater_minimum_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeaterMinimumCapacity { get; set; } = null;
        

[Description("Not yet implemented")]
[JsonProperty(PropertyName="heater_ignition_minimum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeaterIgnitionMinimumFlowRate { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Not yet implemented")]
[JsonProperty(PropertyName="heater_ignition_delay", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeaterIgnitionDelay { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heater_fuel_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_Mixed_HeaterFuelType HeaterFuelType { get; set; } = (WaterHeater_Mixed_HeaterFuelType)Enum.Parse(typeof(WaterHeater_Mixed_HeaterFuelType), "Coal");
        

[JsonProperty(PropertyName="heater_thermal_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeaterThermalEfficiency { get; set; } = null;
        

[JsonProperty(PropertyName="part_load_factor_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PartLoadFactorCurveName { get; set; } = "";
        

[JsonProperty(PropertyName="off_cycle_parasitic_fuel_consumption_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OffCycleParasiticFuelConsumptionRate { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="off_cycle_parasitic_fuel_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_Mixed_OffCycleParasiticFuelType OffCycleParasiticFuelType { get; set; } = (WaterHeater_Mixed_OffCycleParasiticFuelType)Enum.Parse(typeof(WaterHeater_Mixed_OffCycleParasiticFuelType), "Coal");
        

[JsonProperty(PropertyName="off_cycle_parasitic_heat_fraction_to_tank", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OffCycleParasiticHeatFractionToTank { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="on_cycle_parasitic_fuel_consumption_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OnCycleParasiticFuelConsumptionRate { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="on_cycle_parasitic_fuel_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_Mixed_OnCycleParasiticFuelType OnCycleParasiticFuelType { get; set; } = (WaterHeater_Mixed_OnCycleParasiticFuelType)Enum.Parse(typeof(WaterHeater_Mixed_OnCycleParasiticFuelType), "Coal");
        

[JsonProperty(PropertyName="on_cycle_parasitic_heat_fraction_to_tank", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OnCycleParasiticHeatFractionToTank { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="ambient_temperature_indicator", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_Mixed_AmbientTemperatureIndicator AmbientTemperatureIndicator { get; set; } = (WaterHeater_Mixed_AmbientTemperatureIndicator)Enum.Parse(typeof(WaterHeater_Mixed_AmbientTemperatureIndicator), "Outdoors");
        

[JsonProperty(PropertyName="ambient_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AmbientTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="ambient_temperature_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AmbientTemperatureZoneName { get; set; } = "";
        

[Description("required for Ambient Temperature Indicator=Outdoors")]
[JsonProperty(PropertyName="ambient_temperature_outdoor_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AmbientTemperatureOutdoorAirNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="off_cycle_loss_coefficient_to_ambient_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OffCycleLossCoefficientToAmbientTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="off_cycle_loss_fraction_to_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OffCycleLossFractionToZone { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="on_cycle_loss_coefficient_to_ambient_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OnCycleLossCoefficientToAmbientTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="on_cycle_loss_fraction_to_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OnCycleLossFractionToZone { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Only used if Use Side Node connections are blank")]
[JsonProperty(PropertyName="peak_use_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PeakUseFlowRate { get; set; } = null;
        

[Description("Only used if Use Side Node connections are blank")]
[JsonProperty(PropertyName="use_flow_rate_fraction_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UseFlowRateFractionScheduleName { get; set; } = "";
        

[Description("Only used if Use Side Node connections are blank Defaults to water temperatures c" +
    "alculated by Site:WaterMainsTemperature object")]
[JsonProperty(PropertyName="cold_water_supply_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ColdWaterSupplyTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="use_side_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UseSideInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="use_side_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UseSideOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="use_side_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> UseSideEffectiveness { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="source_side_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SourceSideInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="source_side_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SourceSideOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="source_side_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SourceSideEffectiveness { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="use_side_design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> UseSideDesignFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="source_side_design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SourceSideDesignFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Parameter for autosizing design flow rates for indirectly heated water tanks Time" +
    " required to raise temperature of entire tank from 14.4C to 57.2C")]
[JsonProperty(PropertyName="indirect_water_heating_recovery_time", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> IndirectWaterHeatingRecoveryTime { get; set; } = Double.Parse("1.5", CultureInfo.InvariantCulture);
        

[Description(@"StorageTank mode always requests flow unless tank is at its Maximum Temperature Limit IndirectHeatPrimarySetpoint mode requests flow whenever primary setpoint calls for heat IndirectHeatAlternateSetpoint mode requests flow whenever alternate indirect setpoint calls for heat")]
[JsonProperty(PropertyName="source_side_flow_control_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_Mixed_SourceSideFlowControlMode SourceSideFlowControlMode { get; set; } = (WaterHeater_Mixed_SourceSideFlowControlMode)Enum.Parse(typeof(WaterHeater_Mixed_SourceSideFlowControlMode), "IndirectHeatPrimarySetpoint");
        

[Description("This field is only used if the previous is set to IndirectHeatAlternateSetpoint")]
[JsonProperty(PropertyName="indirect_alternate_setpoint_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string IndirectAlternateSetpointTemperatureScheduleName { get; set; } = "";
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    public enum WaterHeater_Mixed_HeaterControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Cycle")]
        Cycle = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Modulate")]
        Modulate = 2,
    }
    
    public enum WaterHeater_Mixed_HeaterFuelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coal")]
        Coal = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Diesel")]
        Diesel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DistrictHeating")]
        DistrictHeating = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Electricity")]
        Electricity = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo1")]
        FuelOilNo1 = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo2")]
        FuelOilNo2 = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Gasoline")]
        Gasoline = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="NaturalGas")]
        NaturalGas = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel1")]
        OtherFuel1 = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel2")]
        OtherFuel2 = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Propane")]
        Propane = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="Steam")]
        Steam = 11,
    }
    
    public enum WaterHeater_Mixed_OffCycleParasiticFuelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coal")]
        Coal = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Diesel")]
        Diesel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DistrictHeating")]
        DistrictHeating = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Electricity")]
        Electricity = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo1")]
        FuelOilNo1 = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo2")]
        FuelOilNo2 = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Gasoline")]
        Gasoline = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="NaturalGas")]
        NaturalGas = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel1")]
        OtherFuel1 = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel2")]
        OtherFuel2 = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Propane")]
        Propane = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="Steam")]
        Steam = 11,
    }
    
    public enum WaterHeater_Mixed_OnCycleParasiticFuelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coal")]
        Coal = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Diesel")]
        Diesel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DistrictHeating")]
        DistrictHeating = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Electricity")]
        Electricity = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo1")]
        FuelOilNo1 = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo2")]
        FuelOilNo2 = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Gasoline")]
        Gasoline = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="NaturalGas")]
        NaturalGas = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel1")]
        OtherFuel1 = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel2")]
        OtherFuel2 = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Propane")]
        Propane = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="Steam")]
        Steam = 11,
    }
    
    public enum WaterHeater_Mixed_AmbientTemperatureIndicator
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Outdoors")]
        Outdoors = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Schedule")]
        Schedule = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Zone")]
        Zone = 2,
    }
    
    public enum WaterHeater_Mixed_SourceSideFlowControlMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="IndirectHeatAlternateSetpoint")]
        IndirectHeatAlternateSetpoint = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="IndirectHeatPrimarySetpoint")]
        IndirectHeatPrimarySetpoint = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="StorageTank")]
        StorageTank = 3,
    }
    
    [Description("Water heater with stratified, multi-node water tank. May be used to model a tankl" +
        "ess water heater (small tank volume), a hot water storage tank (zero heater capa" +
        "city), or a heat pump water heater (see WaterHeater:HeatPump:*.)")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WaterHeater_Stratified
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
        

[JsonProperty(PropertyName="tank_volume", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> TankVolume { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Height is measured in the axial direction for horizontal cylinders")]
[JsonProperty(PropertyName="tank_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> TankHeight { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="tank_shape", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_Stratified_TankShape TankShape { get; set; } = (WaterHeater_Stratified_TankShape)Enum.Parse(typeof(WaterHeater_Stratified_TankShape), "VerticalCylinder");
        

[Description("Only used if Tank Shape is Other")]
[JsonProperty(PropertyName="tank_perimeter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TankPerimeter { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_temperature_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumTemperatureLimit { get; set; } = null;
        

[JsonProperty(PropertyName="heater_priority_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_Stratified_HeaterPriorityControl HeaterPriorityControl { get; set; } = (WaterHeater_Stratified_HeaterPriorityControl)Enum.Parse(typeof(WaterHeater_Stratified_HeaterPriorityControl), "MasterSlave");
        

[JsonProperty(PropertyName="heater_1_setpoint_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Heater1SetpointTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="heater_1_deadband_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Heater1DeadbandTemperatureDifference { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heater_1_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> Heater1Capacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heater_1_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Heater1Height { get; set; } = null;
        

[JsonProperty(PropertyName="heater_2_setpoint_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Heater2SetpointTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="heater_2_deadband_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Heater2DeadbandTemperatureDifference { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heater_2_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Heater2Capacity { get; set; } = null;
        

[JsonProperty(PropertyName="heater_2_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Heater2Height { get; set; } = null;
        

[JsonProperty(PropertyName="heater_fuel_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_Stratified_HeaterFuelType HeaterFuelType { get; set; } = (WaterHeater_Stratified_HeaterFuelType)Enum.Parse(typeof(WaterHeater_Stratified_HeaterFuelType), "Coal");
        

[JsonProperty(PropertyName="heater_thermal_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeaterThermalEfficiency { get; set; } = null;
        

[JsonProperty(PropertyName="off_cycle_parasitic_fuel_consumption_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OffCycleParasiticFuelConsumptionRate { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="off_cycle_parasitic_fuel_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_Stratified_OffCycleParasiticFuelType OffCycleParasiticFuelType { get; set; } = (WaterHeater_Stratified_OffCycleParasiticFuelType)Enum.Parse(typeof(WaterHeater_Stratified_OffCycleParasiticFuelType), "Coal");
        

[JsonProperty(PropertyName="off_cycle_parasitic_heat_fraction_to_tank", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OffCycleParasiticHeatFractionToTank { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="off_cycle_parasitic_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OffCycleParasiticHeight { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="on_cycle_parasitic_fuel_consumption_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OnCycleParasiticFuelConsumptionRate { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="on_cycle_parasitic_fuel_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_Stratified_OnCycleParasiticFuelType OnCycleParasiticFuelType { get; set; } = (WaterHeater_Stratified_OnCycleParasiticFuelType)Enum.Parse(typeof(WaterHeater_Stratified_OnCycleParasiticFuelType), "Coal");
        

[JsonProperty(PropertyName="on_cycle_parasitic_heat_fraction_to_tank", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OnCycleParasiticHeatFractionToTank { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="on_cycle_parasitic_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OnCycleParasiticHeight { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="ambient_temperature_indicator", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_Stratified_AmbientTemperatureIndicator AmbientTemperatureIndicator { get; set; } = (WaterHeater_Stratified_AmbientTemperatureIndicator)Enum.Parse(typeof(WaterHeater_Stratified_AmbientTemperatureIndicator), "Outdoors");
        

[JsonProperty(PropertyName="ambient_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AmbientTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="ambient_temperature_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AmbientTemperatureZoneName { get; set; } = "";
        

[Description("required for Ambient Temperature Indicator=Outdoors")]
[JsonProperty(PropertyName="ambient_temperature_outdoor_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AmbientTemperatureOutdoorAirNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="uniform_skin_loss_coefficient_per_unit_area_to_ambient_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> UniformSkinLossCoefficientPerUnitAreaToAmbientTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="skin_loss_fraction_to_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SkinLossFractionToZone { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="off_cycle_flue_loss_coefficient_to_ambient_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OffCycleFlueLossCoefficientToAmbientTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="off_cycle_flue_loss_fraction_to_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OffCycleFlueLossFractionToZone { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Only used if Use Side Node connections are blank")]
[JsonProperty(PropertyName="peak_use_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PeakUseFlowRate { get; set; } = null;
        

[Description("If blank, defaults to 1.0 at all times Only used if use side node connections are" +
    " blank")]
[JsonProperty(PropertyName="use_flow_rate_fraction_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UseFlowRateFractionScheduleName { get; set; } = "";
        

[Description("Only used if use side node connections are blank Defaults to water temperatures c" +
    "alculated by Site:WaterMainsTemperature object")]
[JsonProperty(PropertyName="cold_water_supply_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ColdWaterSupplyTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="use_side_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UseSideInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="use_side_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UseSideOutletNodeName { get; set; } = "";
        

[Description(@"The use side effectiveness in the stratified tank model is a simplified analogy of a heat exchanger's effectiveness. This effectiveness is equal to the fraction of use mass flow rate that directly mixes with the tank fluid. And one minus the effectiveness is the fraction that bypasses the tank. The use side mass flow rate that bypasses the tank is mixed with the fluid or water leaving the stratified tank.")]
[JsonProperty(PropertyName="use_side_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> UseSideEffectiveness { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Defaults to bottom of tank")]
[JsonProperty(PropertyName="use_side_inlet_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> UseSideInletHeight { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Defaults to top of tank")]
[JsonProperty(PropertyName="use_side_outlet_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> UseSideOutletHeight { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="source_side_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SourceSideInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="source_side_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SourceSideOutletNodeName { get; set; } = "";
        

[Description(@"The source side effectiveness in the stratified tank model is a simplified analogy of a heat exchanger's effectiveness. This effectiveness is equal to the fraction of source mass flow rate that directly mixes with the tank fluid. And one minus the effectiveness is the fraction that bypasses the tank. The source side mass flow rate that bypasses the tank is mixed with the fluid or water leaving the stratified tank.")]
[JsonProperty(PropertyName="source_side_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SourceSideEffectiveness { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Defaults to top of tank")]
[JsonProperty(PropertyName="source_side_inlet_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> SourceSideInletHeight { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Defaults to bottom of tank")]
[JsonProperty(PropertyName="source_side_outlet_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SourceSideOutletHeight { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="inlet_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_Stratified_InletMode InletMode { get; set; } = (WaterHeater_Stratified_InletMode)Enum.Parse(typeof(WaterHeater_Stratified_InletMode), "Fixed");
        

[JsonProperty(PropertyName="use_side_design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> UseSideDesignFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="source_side_design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SourceSideDesignFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Parameter for autosizing design flow rates for indirectly heated water tanks time" +
    " required to raise temperature of entire tank from 14.4C to 57.2C")]
[JsonProperty(PropertyName="indirect_water_heating_recovery_time", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> IndirectWaterHeatingRecoveryTime { get; set; } = Double.Parse("1.5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="number_of_nodes", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfNodes { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="additional_destratification_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AdditionalDestratificationConductivity { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="node_1_additional_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Node1AdditionalLossCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="node_2_additional_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Node2AdditionalLossCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="node_3_additional_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Node3AdditionalLossCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="node_4_additional_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Node4AdditionalLossCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="node_5_additional_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Node5AdditionalLossCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="node_6_additional_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Node6AdditionalLossCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="node_7_additional_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Node7AdditionalLossCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="node_8_additional_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Node8AdditionalLossCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="node_9_additional_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Node9AdditionalLossCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="node_10_additional_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Node10AdditionalLossCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="node_11_additional_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Node11AdditionalLossCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="node_12_additional_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Node12AdditionalLossCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description(@"StorageTank mode always requests flow unless tank is at its Maximum Temperature Limit IndirectHeatPrimarySetpoint mode requests flow whenever primary setpoint for heater 1 calls for heat IndirectHeatAlternateSetpoint mode requests flow whenever alternate indirect setpoint calls for heat")]
[JsonProperty(PropertyName="source_side_flow_control_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_Stratified_SourceSideFlowControlMode SourceSideFlowControlMode { get; set; } = (WaterHeater_Stratified_SourceSideFlowControlMode)Enum.Parse(typeof(WaterHeater_Stratified_SourceSideFlowControlMode), "IndirectHeatPrimarySetpoint");
        

[Description("This field is only used if the previous is set to IndirectHeatAlternateSetpoint")]
[JsonProperty(PropertyName="indirect_alternate_setpoint_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string IndirectAlternateSetpointTemperatureScheduleName { get; set; } = "";
    }
    
    public enum WaterHeater_Stratified_TankShape
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="HorizontalCylinder")]
        HorizontalCylinder = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Other")]
        Other = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="VerticalCylinder")]
        VerticalCylinder = 3,
    }
    
    public enum WaterHeater_Stratified_HeaterPriorityControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MasterSlave")]
        MasterSlave = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Simultaneous")]
        Simultaneous = 2,
    }
    
    public enum WaterHeater_Stratified_HeaterFuelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coal")]
        Coal = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Diesel")]
        Diesel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DistrictHeating")]
        DistrictHeating = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Electricity")]
        Electricity = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo1")]
        FuelOilNo1 = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo2")]
        FuelOilNo2 = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Gasoline")]
        Gasoline = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="NaturalGas")]
        NaturalGas = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel1")]
        OtherFuel1 = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel2")]
        OtherFuel2 = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Propane")]
        Propane = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="Steam")]
        Steam = 11,
    }
    
    public enum WaterHeater_Stratified_OffCycleParasiticFuelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coal")]
        Coal = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Diesel")]
        Diesel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DistrictHeating")]
        DistrictHeating = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Electricity")]
        Electricity = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo1")]
        FuelOilNo1 = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo2")]
        FuelOilNo2 = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Gasoline")]
        Gasoline = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="NaturalGas")]
        NaturalGas = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel1")]
        OtherFuel1 = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel2")]
        OtherFuel2 = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Propane")]
        Propane = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="Steam")]
        Steam = 11,
    }
    
    public enum WaterHeater_Stratified_OnCycleParasiticFuelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coal")]
        Coal = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Diesel")]
        Diesel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DistrictHeating")]
        DistrictHeating = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Electricity")]
        Electricity = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo1")]
        FuelOilNo1 = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo2")]
        FuelOilNo2 = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Gasoline")]
        Gasoline = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="NaturalGas")]
        NaturalGas = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel1")]
        OtherFuel1 = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel2")]
        OtherFuel2 = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Propane")]
        Propane = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="Steam")]
        Steam = 11,
    }
    
    public enum WaterHeater_Stratified_AmbientTemperatureIndicator
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Outdoors")]
        Outdoors = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Schedule")]
        Schedule = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Zone")]
        Zone = 2,
    }
    
    public enum WaterHeater_Stratified_InletMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fixed")]
        Fixed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Seeking")]
        Seeking = 2,
    }
    
    public enum WaterHeater_Stratified_SourceSideFlowControlMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="IndirectHeatAlternateSetpoint")]
        IndirectHeatAlternateSetpoint = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="IndirectHeatPrimarySetpoint")]
        IndirectHeatPrimarySetpoint = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="StorageTank")]
        StorageTank = 3,
    }
    
    [Description("This input object is used with WaterHeater:Mixed or with WaterHeater:Stratified t" +
        "o autosize tank volume and heater capacity This object is not needed if water he" +
        "aters are not autosized.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WaterHeater_Sizing
    {
        

[JsonProperty(PropertyName="waterheater_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterheaterName { get; set; } = "";
        

[JsonProperty(PropertyName="design_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_Sizing_DesignMode DesignMode { get; set; } = (WaterHeater_Sizing_DesignMode)Enum.Parse(typeof(WaterHeater_Sizing_DesignMode), "PeakDraw");
        

[Description("Only used for Design Mode = PeakDraw")]
[JsonProperty(PropertyName="time_storage_can_meet_peak_draw", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TimeStorageCanMeetPeakDraw { get; set; } = null;
        

[Description("Only used for Design Mode = PeakDraw")]
[JsonProperty(PropertyName="time_for_tank_recovery", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TimeForTankRecovery { get; set; } = null;
        

[Description("Only used if Design Mode = PeakDraw and the water heater also has autosized flow " +
    "rates for connections on the demand side of a plant loop")]
[JsonProperty(PropertyName="nominal_tank_volume_for_autosizing_plant_connections", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NominalTankVolumeForAutosizingPlantConnections { get; set; } = null;
        

[Description("Only used for Design Mode = ResidentialHUD-FHAMinimum")]
[JsonProperty(PropertyName="number_of_bedrooms", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfBedrooms { get; set; } = null;
        

[Description("Only used for Design Mode = ResidentialHUD-FHAMinimum")]
[JsonProperty(PropertyName="number_of_bathrooms", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfBathrooms { get; set; } = null;
        

[Description("Only used for Design Mode = PerPerson")]
[JsonProperty(PropertyName="storage_capacity_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StorageCapacityPerPerson { get; set; } = null;
        

[Description("Only used for Design Mode = PerPerson")]
[JsonProperty(PropertyName="recovery_capacity_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RecoveryCapacityPerPerson { get; set; } = null;
        

[Description("Only used for Design Mode = PerFloorArea")]
[JsonProperty(PropertyName="storage_capacity_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StorageCapacityPerFloorArea { get; set; } = null;
        

[Description("Only used for Design Mode = PerFloorArea")]
[JsonProperty(PropertyName="recovery_capacity_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RecoveryCapacityPerFloorArea { get; set; } = null;
        

[Description("Only used for Design Mode = PerUnit")]
[JsonProperty(PropertyName="number_of_units", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfUnits { get; set; } = null;
        

[Description("Only used for Design Mode = PerUnit")]
[JsonProperty(PropertyName="storage_capacity_per_unit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StorageCapacityPerUnit { get; set; } = null;
        

[Description("Only used for Design Mode = PerUnit")]
[JsonProperty(PropertyName="recovery_capacity_perunit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RecoveryCapacityPerunit { get; set; } = null;
        

[Description("Only used for Design Mode = PerSolarCollectorArea")]
[JsonProperty(PropertyName="storage_capacity_per_collector_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StorageCapacityPerCollectorArea { get; set; } = null;
        

[Description("only used if for WaterHeater:Stratified")]
[JsonProperty(PropertyName="height_aspect_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeightAspectRatio { get; set; } = null;
    }
    
    public enum WaterHeater_Sizing_DesignMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="PeakDraw")]
        PeakDraw = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PerFloorArea")]
        PerFloorArea = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PerPerson")]
        PerPerson = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PerSolarCollectorArea")]
        PerSolarCollectorArea = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="PerUnit")]
        PerUnit = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="ResidentialHUD-FHAMinimum")]
        ResidentialHUDFHAMinimum = 5,
    }
    
    [Description(@"This object models an air-source heat pump for water heating where the water is pumped out of the tank, through a heating coil and returned to the tank. For wrapped condenser HPWHs, see WaterHeater:HeatPump:WrappedCondenser. WaterHeater:HeatPump:PumpedCondenser is a compound object that references other component objects - Coil:WaterHeating:AirToWaterHeatPump:*, Fan:OnOff, WaterHeater:Mixed or WaterHeater:Stratified")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WaterHeater_HeatPump_PumpedCondenser
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description(@"Availability schedule name for this system. Schedule value > 0 means the system is available. If this field is blank, the system is always available. Schedule values of 0 denote the heat pump compressor is off and the parasitic electric energy is also off.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("Defines the cut-out temperature where the heat pump compressor turns off. The hea" +
    "t pump compressor setpoint temperature should always be greater than the water t" +
    "ank\'s heater (element or burner) setpoint temperature.")]
[JsonProperty(PropertyName="compressor_setpoint_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CompressorSetpointTemperatureScheduleName { get; set; } = "";
        

[Description(@"Setpoint temperature minus the dead band temperature difference defines the cut-in temperature where the heat pump compressor turns on. The water tank's heater (element or burner) setpoint temperature should always be less than the heat pump compressor cut-in temperature.")]
[JsonProperty(PropertyName="dead_band_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DeadBandTemperatureDifference { get; set; } = Double.Parse("5", CultureInfo.InvariantCulture);
        

[Description("Should match the field Source Outlet Node Name in the water heater tank object. S" +
    "hould also match the Condenser Water Inlet Node Name in the associated DX coil o" +
    "bject.")]
[JsonProperty(PropertyName="condenser_water_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CondenserWaterInletNodeName { get; set; } = "";
        

[Description("Should match the field Source Inlet Node Name in water heater tank object. Should" +
    " also match the Condenser Water Outlet Node Name in the associated DX Coil objec" +
    "t.")]
[JsonProperty(PropertyName="condenser_water_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CondenserWaterOutletNodeName { get; set; } = "";
        

[Description("Actual water flow rate through the heat pump\'s water coil (condenser). If autocal" +
    "culated, the water flow rate is set equal to 4.487E-8 m3/s/W times the rated hea" +
    "ting capacity of the heat pump\'s DX coil.")]
[JsonProperty(PropertyName="condenser_water_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> CondenserWaterFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Actual air flow rate across the heat pump\'s air coil (evaporator). If autocalcula" +
    "ted, the air flow rate is set equal to 5.035E-5 m3/s/W times the rated heating c" +
    "apacity of the heat pump\'s DX coil.")]
[JsonProperty(PropertyName="evaporator_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> EvaporatorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Defines the configuration of the airflow path through the air coil and fan sectio" +
    "n.")]
[JsonProperty(PropertyName="inlet_air_configuration", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_HeatPump_PumpedCondenser_InletAirConfiguration InletAirConfiguration { get; set; } = (WaterHeater_HeatPump_PumpedCondenser_InletAirConfiguration)Enum.Parse(typeof(WaterHeater_HeatPump_PumpedCondenser_InletAirConfiguration), "OutdoorAirOnly");
        

[Description("Zone air exhaust node name if Inlet Air Configuration is ZoneAirOnly or ZoneAndOu" +
    "tdoorAir. Simply a unique Node Name if Inlet Air Configuration is Schedule. Othe" +
    "rwise, leave field blank.")]
[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[Description("Zone Air Inlet Node Name if Inlet Air Configuration is ZoneAirOnly or ZoneAndOutd" +
    "oorAir. Simply a unique Node Name if Inlet Air Configuration is Schedule. Otherw" +
    "ise, leave field blank.")]
[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[Description("Outdoor air node name if inlet air configuration is ZoneAndOutdoorAir or OutdoorA" +
    "irOnly, otherwise leave field blank.")]
[JsonProperty(PropertyName="outdoor_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirNodeName { get; set; } = "";
        

[Description("Simply a unique Node Name if Inlet Air Configuration is ZoneAndOutdoorAir or Outd" +
    "oorAirOnly, otherwise leave field blank.")]
[JsonProperty(PropertyName="exhaust_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ExhaustAirNodeName { get; set; } = "";
        

[Description("Used only if Inlet Air Configuration is Schedule, otherwise leave blank. Schedule" +
    " values should be degrees C.")]
[JsonProperty(PropertyName="inlet_air_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletAirTemperatureScheduleName { get; set; } = "";
        

[Description("Used only if Inlet Air Configuration is Schedule, otherwise leave blank. Schedule" +
    " values are entered as a fraction (e.g. 0.5 is equal to 50%RH)")]
[JsonProperty(PropertyName="inlet_air_humidity_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletAirHumidityScheduleName { get; set; } = "";
        

[Description("Used only if Inlet Air Configuration is ZoneAirOnly or ZoneAndOutdoorAir. Otherwi" +
    "se, leave field blank.")]
[JsonProperty(PropertyName="inlet_air_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletAirZoneName { get; set; } = "";
        

[Description("Specify the type of water heater tank used by this heat pump water heater.")]
[JsonProperty(PropertyName="tank_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_HeatPump_PumpedCondenser_TankObjectType TankObjectType { get; set; } = (WaterHeater_HeatPump_PumpedCondenser_TankObjectType)Enum.Parse(typeof(WaterHeater_HeatPump_PumpedCondenser_TankObjectType), "Empty");
        

[Description("Needs to match the name used in the corresponding Water Heater object.")]
[JsonProperty(PropertyName="tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TankName { get; set; } = "";
        

[Description("Used only when the heat pump water heater is connected to a plant loop, otherwise" +
    " leave blank. Needs to match the name used in the corresponding Water Heater obj" +
    "ect when connected to a plant loop.")]
[JsonProperty(PropertyName="tank_use_side_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TankUseSideInletNodeName { get; set; } = "";
        

[Description("Used only when the heat pump water heater is connected to a plant loop, otherwise" +
    " leave blank. Needs to match the name used in the corresponding Water Heater obj" +
    "ect when connected to a plant loop.")]
[JsonProperty(PropertyName="tank_use_side_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TankUseSideOutletNodeName { get; set; } = "";
        

[Description("Specify the type of DX coil used by this heat pump water heater. The only valid c" +
    "hoice is Coil:WaterHeating:AirToWaterHeatPump:Pumped and Coil:WaterHeating:AirTo" +
    "WaterHeatPump:VariableSpeed, and CoilSystem:IntegratedHeatPump:AirSource")]
[JsonProperty(PropertyName="dx_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_HeatPump_PumpedCondenser_DxCoilObjectType DxCoilObjectType { get; set; } = (WaterHeater_HeatPump_PumpedCondenser_DxCoilObjectType)Enum.Parse(typeof(WaterHeater_HeatPump_PumpedCondenser_DxCoilObjectType), "Empty");
        

[Description("Must match the name used in the corresponding Coil:WaterHeating:AirToWaterHeatPum" +
    "p:* object, or CoilSystem:IntegratedHeatPump:AirSource")]
[JsonProperty(PropertyName="dx_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DxCoilName { get; set; } = "";
        

[Description("Heat pump compressor will not operate when the inlet air dry-bulb temperature is " +
    "below this value.")]
[JsonProperty(PropertyName="minimum_inlet_air_temperature_for_compressor_operation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumInletAirTemperatureForCompressorOperation { get; set; } = Double.Parse("10", CultureInfo.InvariantCulture);
        

[Description("Heat pump compressor will not operate when the inlet air dry-bulb temperature is " +
    "above this value.")]
[JsonProperty(PropertyName="maximum_inlet_air_temperature_for_compressor_operation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumInletAirTemperatureForCompressorOperation { get; set; } = Double.Parse("48.88888888889", CultureInfo.InvariantCulture);
        

[Description("If Zone is selected, Inlet Air Configuration must be ZoneAirOnly or ZoneAndOutdoo" +
    "rAir. If Schedule is selected, then you must provide a Compressor Ambient Temper" +
    "ature Schedule Name below.")]
[JsonProperty(PropertyName="compressor_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_HeatPump_PumpedCondenser_CompressorLocation CompressorLocation { get; set; } = (WaterHeater_HeatPump_PumpedCondenser_CompressorLocation)Enum.Parse(typeof(WaterHeater_HeatPump_PumpedCondenser_CompressorLocation), "Outdoors");
        

[Description("Used only if Compressor Location is Schedule, otherwise leave field blank.")]
[JsonProperty(PropertyName="compressor_ambient_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CompressorAmbientTemperatureScheduleName { get; set; } = "";
        

[Description("Specify the type of fan used by this heat pump water heater. The only valid choic" +
    "es are Fan:SystemModel or Fan:OnOff.")]
[JsonProperty(PropertyName="fan_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_HeatPump_PumpedCondenser_FanObjectType FanObjectType { get; set; } = (WaterHeater_HeatPump_PumpedCondenser_FanObjectType)Enum.Parse(typeof(WaterHeater_HeatPump_PumpedCondenser_FanObjectType), "Empty");
        

[Description("Needs to match the name used in the corresponding Fan:SystemModel or Fan:OnOff ob" +
    "ject.")]
[JsonProperty(PropertyName="fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FanName { get; set; } = "";
        

[Description("BlowThrough means the fan is located before the air coil (upstream). DrawThrough " +
    "means the fan is located after the air coil (downstream).")]
[JsonProperty(PropertyName="fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_HeatPump_PumpedCondenser_FanPlacement FanPlacement { get; set; } = (WaterHeater_HeatPump_PumpedCondenser_FanPlacement)Enum.Parse(typeof(WaterHeater_HeatPump_PumpedCondenser_FanPlacement), "DrawThrough");
        

[Description("Parasitic electric power consumed when the heat pump compressor operates. Does no" +
    "t contribute to water heating but can impact the zone air heat balance.")]
[JsonProperty(PropertyName="on_cycle_parasitic_electric_load", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OnCycleParasiticElectricLoad { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Parasitic electric power consumed when the heat pump compressor is off. Does not " +
    "contribute to water heating but can impact the zone air heat balance. Off-cycle " +
    "parasitic power is 0 when the availability schedule is 0.")]
[JsonProperty(PropertyName="off_cycle_parasitic_electric_load", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OffCycleParasiticElectricLoad { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This field determines if the parasitic electric load impacts the zone air heat ba" +
    "lance. If Zone is selected, Inlet Air Configuration must be ZoneAirOnly or ZoneA" +
    "ndOutdoorAir.")]
[JsonProperty(PropertyName="parasitic_heat_rejection_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_HeatPump_PumpedCondenser_ParasiticHeatRejectionLocation ParasiticHeatRejectionLocation { get; set; } = (WaterHeater_HeatPump_PumpedCondenser_ParasiticHeatRejectionLocation)Enum.Parse(typeof(WaterHeater_HeatPump_PumpedCondenser_ParasiticHeatRejectionLocation), "Outdoors");
        

[Description("Required only if Inlet Air Configuration is ZoneAndOutdoorAir, otherwise leave fi" +
    "eld blank.")]
[JsonProperty(PropertyName="inlet_air_mixer_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletAirMixerNodeName { get; set; } = "";
        

[Description("Required only if Inlet Air Configuration is ZoneAndOutdoorAir, otherwise leave fi" +
    "eld blank.")]
[JsonProperty(PropertyName="outlet_air_splitter_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutletAirSplitterNodeName { get; set; } = "";
        

[Description(@"Required only if Inlet Air Configuration is ZoneAndOutdoorAir, otherwise leave field blank. Schedule values define whether the heat pump draws its inlet air from the zone, outdoors or a combination of zone and outdoor air. A schedule value of 0 denotes inlet air is drawn only from the zone. A schedule value of 1 denotes inlet air is drawn only from outdoors. Schedule values between 0 and 1 denote a mixture of zone and outdoor air proportional to the schedule value (i.e. 0.4 = 40% outdoor air, 60% zone air).")]
[JsonProperty(PropertyName="inlet_air_mixer_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletAirMixerScheduleName { get; set; } = "";
        

[Description(@"MutuallyExclusive means that once the tank heating element is active the heat pump is shut down until setpoint is reached. Simultaneous (default) means that both the tank heating element and heat pump are used at the same time recover the tank temperature.")]
[JsonProperty(PropertyName="tank_element_control_logic", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_HeatPump_PumpedCondenser_TankElementControlLogic TankElementControlLogic { get; set; } = (WaterHeater_HeatPump_PumpedCondenser_TankElementControlLogic)Enum.Parse(typeof(WaterHeater_HeatPump_PumpedCondenser_TankElementControlLogic), "Simultaneous");
        

[Description("Used to indicate height of control sensor for Tank Object Type = WaterHeater:Stra" +
    "tified If left blank, it will default to the height of Heater1")]
[JsonProperty(PropertyName="control_sensor_1_height_in_stratified_tank", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ControlSensor1HeightInStratifiedTank { get; set; } = null;
        

[Description("Weight to give Control Sensor 1 temperature The weight of Control Sensor 2 will b" +
    "e 1 - (wt. of control sensor 1)")]
[JsonProperty(PropertyName="control_sensor_1_weight", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ControlSensor1Weight { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Used to indicate height of control sensor for Tank Object Type = WaterHeater:Stra" +
    "tified If left blank, it will default to the height of Heater2")]
[JsonProperty(PropertyName="control_sensor_2_height_in_stratified_tank", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ControlSensor2HeightInStratifiedTank { get; set; } = null;
    }
    
    public enum WaterHeater_HeatPump_PumpedCondenser_InletAirConfiguration
    {
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAirOnly")]
        OutdoorAirOnly = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Schedule")]
        Schedule = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ZoneAirOnly")]
        ZoneAirOnly = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ZoneAndOutdoorAir")]
        ZoneAndOutdoorAir = 3,
    }
    
    public enum WaterHeater_HeatPump_PumpedCondenser_TankObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="WaterHeater:Mixed")]
        WaterHeaterMixed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="WaterHeater:Stratified")]
        WaterHeaterStratified = 2,
    }
    
    public enum WaterHeater_HeatPump_PumpedCondenser_DxCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:WaterHeating:AirToWaterHeatPump:Pumped")]
        CoilWaterHeatingAirToWaterHeatPumpPumped = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:WaterHeating:AirToWaterHeatPump:VariableSpeed")]
        CoilWaterHeatingAirToWaterHeatPumpVariableSpeed = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:IntegratedHeatPump:AirSource")]
        CoilSystemIntegratedHeatPumpAirSource = 3,
    }
    
    public enum WaterHeater_HeatPump_PumpedCondenser_CompressorLocation
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Outdoors")]
        Outdoors = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Schedule")]
        Schedule = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Zone")]
        Zone = 2,
    }
    
    public enum WaterHeater_HeatPump_PumpedCondenser_FanObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:OnOff")]
        FanOnOff = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:SystemModel")]
        FanSystemModel = 2,
    }
    
    public enum WaterHeater_HeatPump_PumpedCondenser_FanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum WaterHeater_HeatPump_PumpedCondenser_ParasiticHeatRejectionLocation
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Outdoors")]
        Outdoors = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Zone")]
        Zone = 2,
    }
    
    public enum WaterHeater_HeatPump_PumpedCondenser_TankElementControlLogic
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MutuallyExclusive")]
        MutuallyExclusive = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Simultaneous")]
        Simultaneous = 2,
    }
    
    [Description(@"This object models an air-source heat pump for water heating where the heating coil is wrapped around the tank, which is typical of residential HPWHs. For pumped condenser HPWHs, see WaterHeater:HeatPump:PumpedCondenser. WaterHeater:HeatPump:WrappedCondenser is a compound object that references other component objects - Coil:WaterHeating:AirToWaterHeatPump:Pumped, Fan:OnOff, WaterHeater:Mixed")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WaterHeater_HeatPump_WrappedCondenser
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description(@"Availability schedule name for this system. Schedule value > 0 means the system is available. If this field is blank, the system is always available. Schedule values of 0 denote the heat pump compressor is off and the parasitic electric energy is also off.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("Defines the cut-out temperature where the heat pump compressor turns off. The hea" +
    "t pump compressor setpoint temperature should always be greater than the water t" +
    "ank\'s heater (element or burner) setpoint temperature.")]
[JsonProperty(PropertyName="compressor_setpoint_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CompressorSetpointTemperatureScheduleName { get; set; } = "";
        

[Description(@"Setpoint temperature minus the dead band temperature difference defines the cut-in temperature where the heat pump compressor turns on. The water tank's heater (element or burner) setpoint temperature should always be less than the heat pump compressor cut-in temperature.")]
[JsonProperty(PropertyName="dead_band_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DeadBandTemperatureDifference { get; set; } = Double.Parse("5", CultureInfo.InvariantCulture);
        

[Description("Distance from the bottom of the tank to the bottom of the wrapped condenser.")]
[JsonProperty(PropertyName="condenser_bottom_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CondenserBottomLocation { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Distance from the bottom of the tank to the top of the wrapped condenser.")]
[JsonProperty(PropertyName="condenser_top_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CondenserTopLocation { get; set; } = null;
        

[Description("Actual air flow rate across the heat pump\'s air coil (evaporator). If autocalcula" +
    "ted, the air flow rate is set equal to 5.035E-5 m3/s/W times the rated heating c" +
    "apacity of the heat pump\'s DX coil.")]
[JsonProperty(PropertyName="evaporator_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> EvaporatorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Defines the configuration of the airflow path through the air coil and fan sectio" +
    "n.")]
[JsonProperty(PropertyName="inlet_air_configuration", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_HeatPump_WrappedCondenser_InletAirConfiguration InletAirConfiguration { get; set; } = (WaterHeater_HeatPump_WrappedCondenser_InletAirConfiguration)Enum.Parse(typeof(WaterHeater_HeatPump_WrappedCondenser_InletAirConfiguration), "OutdoorAirOnly");
        

[Description("Zone air exhaust node name if Inlet Air Configuration is ZoneAirOnly or ZoneAndOu" +
    "tdoorAir. Simply a unique Node Name if Inlet Air Configuration is Schedule. Othe" +
    "rwise, leave field blank.")]
[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[Description("Zone Air Inlet Node Name if Inlet Air Configuration is ZoneAirOnly or ZoneAndOutd" +
    "oorAir. Simply a unique Node Name if Inlet Air Configuration is Schedule. Otherw" +
    "ise, leave field blank.")]
[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[Description("Outdoor air node name if inlet air configuration is ZoneAndOutdoorAir or OutdoorA" +
    "irOnly, otherwise leave field blank.")]
[JsonProperty(PropertyName="outdoor_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirNodeName { get; set; } = "";
        

[Description("Simply a unique Node Name if Inlet Air Configuration is ZoneAndOutdoorAir or Outd" +
    "oorAirOnly, otherwise leave field blank.")]
[JsonProperty(PropertyName="exhaust_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ExhaustAirNodeName { get; set; } = "";
        

[Description("Used only if Inlet Air Configuration is Schedule, otherwise leave blank. Schedule" +
    " values should be degrees C.")]
[JsonProperty(PropertyName="inlet_air_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletAirTemperatureScheduleName { get; set; } = "";
        

[Description("Used only if Inlet Air Configuration is Schedule, otherwise leave blank. Schedule" +
    " values are entered as a fraction (e.g. 0.5 is equal to 50%RH)")]
[JsonProperty(PropertyName="inlet_air_humidity_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletAirHumidityScheduleName { get; set; } = "";
        

[Description("Used only if Inlet Air Configuration is ZoneAirOnly or ZoneAndOutdoorAir. Otherwi" +
    "se, leave field blank.")]
[JsonProperty(PropertyName="inlet_air_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletAirZoneName { get; set; } = "";
        

[Description("Specify the type of water heater tank used by this heat pump water heater.")]
[JsonProperty(PropertyName="tank_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_HeatPump_WrappedCondenser_TankObjectType TankObjectType { get; set; } = (WaterHeater_HeatPump_WrappedCondenser_TankObjectType)Enum.Parse(typeof(WaterHeater_HeatPump_WrappedCondenser_TankObjectType), "Empty");
        

[Description("Needs to match the name used in the corresponding Water Heater object. Must be a " +
    "WaterHeater:Stratified tank.")]
[JsonProperty(PropertyName="tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TankName { get; set; } = "";
        

[Description("Used only when the heat pump water heater is connected to a plant loop, otherwise" +
    " leave blank. Needs to match the name used in the corresponding Water Heater obj" +
    "ect when connected to a plant loop.")]
[JsonProperty(PropertyName="tank_use_side_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TankUseSideInletNodeName { get; set; } = "";
        

[Description("Used only when the heat pump water heater is connected to a plant loop, otherwise" +
    " leave blank. Needs to match the name used in the corresponding Water Heater obj" +
    "ect when connected to a plant loop.")]
[JsonProperty(PropertyName="tank_use_side_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TankUseSideOutletNodeName { get; set; } = "";
        

[Description("Specify the type of DX coil used by this heat pump water heater. The only valid c" +
    "hoice is Coil:WaterHeating:AirToWaterHeatPump:Wrapped")]
[JsonProperty(PropertyName="dx_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_HeatPump_WrappedCondenser_DxCoilObjectType DxCoilObjectType { get; set; } = (WaterHeater_HeatPump_WrappedCondenser_DxCoilObjectType)Enum.Parse(typeof(WaterHeater_HeatPump_WrappedCondenser_DxCoilObjectType), "Empty");
        

[Description("Must match the name used in the corresponding Coil:WaterHeating:AirToWaterHeatPum" +
    "p:Wrapped object.")]
[JsonProperty(PropertyName="dx_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DxCoilName { get; set; } = "";
        

[Description("Heat pump compressor will not operate when the inlet air dry-bulb temperature is " +
    "below this value.")]
[JsonProperty(PropertyName="minimum_inlet_air_temperature_for_compressor_operation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumInletAirTemperatureForCompressorOperation { get; set; } = Double.Parse("10", CultureInfo.InvariantCulture);
        

[Description("Heat pump compressor will not operate when the inlet air dry-bulb temperature is " +
    "above this value.")]
[JsonProperty(PropertyName="maximum_inlet_air_temperature_for_compressor_operation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumInletAirTemperatureForCompressorOperation { get; set; } = Double.Parse("48.88888888889", CultureInfo.InvariantCulture);
        

[Description("If Zone is selected, Inlet Air Configuration must be ZoneAirOnly or ZoneAndOutdoo" +
    "rAir. If Schedule is selected, then you must provide a Compressor Ambient Temper" +
    "ature Schedule Name below.")]
[JsonProperty(PropertyName="compressor_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_HeatPump_WrappedCondenser_CompressorLocation CompressorLocation { get; set; } = (WaterHeater_HeatPump_WrappedCondenser_CompressorLocation)Enum.Parse(typeof(WaterHeater_HeatPump_WrappedCondenser_CompressorLocation), "Outdoors");
        

[Description("Used only if Compressor Location is Schedule, otherwise leave field blank.")]
[JsonProperty(PropertyName="compressor_ambient_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CompressorAmbientTemperatureScheduleName { get; set; } = "";
        

[Description("Specify the type of fan used by this heat pump water heater. The only valid choic" +
    "es are Fan:SystemModel or Fan:OnOff.")]
[JsonProperty(PropertyName="fan_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_HeatPump_WrappedCondenser_FanObjectType FanObjectType { get; set; } = (WaterHeater_HeatPump_WrappedCondenser_FanObjectType)Enum.Parse(typeof(WaterHeater_HeatPump_WrappedCondenser_FanObjectType), "Empty");
        

[Description("Needs to match the name used in the corresponding Fan:SystemModel or Fan:OnOff ob" +
    "ject.")]
[JsonProperty(PropertyName="fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FanName { get; set; } = "";
        

[Description("BlowThrough means the fan is located before the air coil (upstream). DrawThrough " +
    "means the fan is located after the air coil (downstream).")]
[JsonProperty(PropertyName="fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_HeatPump_WrappedCondenser_FanPlacement FanPlacement { get; set; } = (WaterHeater_HeatPump_WrappedCondenser_FanPlacement)Enum.Parse(typeof(WaterHeater_HeatPump_WrappedCondenser_FanPlacement), "DrawThrough");
        

[Description("Parasitic electric power consumed when the heat pump compressor operates. Does no" +
    "t contribute to water heating but can impact the zone air heat balance.")]
[JsonProperty(PropertyName="on_cycle_parasitic_electric_load", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OnCycleParasiticElectricLoad { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Parasitic electric power consumed when the heat pump compressor is off. Does not " +
    "contribute to water heating but can impact the zone air heat balance. Off-cycle " +
    "parasitic power is 0 when the availability schedule is 0.")]
[JsonProperty(PropertyName="off_cycle_parasitic_electric_load", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OffCycleParasiticElectricLoad { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This field determines if the parasitic electric load impacts the zone air heat ba" +
    "lance. If Zone is selected, Inlet Air Configuration must be ZoneAirOnly or ZoneA" +
    "ndOutdoorAir.")]
[JsonProperty(PropertyName="parasitic_heat_rejection_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_HeatPump_WrappedCondenser_ParasiticHeatRejectionLocation ParasiticHeatRejectionLocation { get; set; } = (WaterHeater_HeatPump_WrappedCondenser_ParasiticHeatRejectionLocation)Enum.Parse(typeof(WaterHeater_HeatPump_WrappedCondenser_ParasiticHeatRejectionLocation), "Outdoors");
        

[Description("Required only if Inlet Air Configuration is ZoneAndOutdoorAir, otherwise leave fi" +
    "eld blank.")]
[JsonProperty(PropertyName="inlet_air_mixer_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletAirMixerNodeName { get; set; } = "";
        

[Description("Required only if Inlet Air Configuration is ZoneAndOutdoorAir, otherwise leave fi" +
    "eld blank.")]
[JsonProperty(PropertyName="outlet_air_splitter_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutletAirSplitterNodeName { get; set; } = "";
        

[Description(@"Required only if Inlet Air Configuration is ZoneAndOutdoorAir, otherwise leave field blank. Schedule values define whether the heat pump draws its inlet air from the zone, outdoors or a combination of zone and outdoor air. A schedule value of 0 denotes inlet air is drawn only from the zone. A schedule value of 1 denotes inlet air is drawn only from outdoors. Schedule values between 0 and 1 denote a mixture of zone and outdoor air proportional to the schedule value.")]
[JsonProperty(PropertyName="inlet_air_mixer_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletAirMixerScheduleName { get; set; } = "";
        

[Description(@"MutuallyExclusive means that once the tank heating element is active the heat pump is shut down until setpoint is reached. Simultaneous (default) means that both the tank heating element and heat pump are used at the same time recover the tank temperature.")]
[JsonProperty(PropertyName="tank_element_control_logic", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WaterHeater_HeatPump_WrappedCondenser_TankElementControlLogic TankElementControlLogic { get; set; } = (WaterHeater_HeatPump_WrappedCondenser_TankElementControlLogic)Enum.Parse(typeof(WaterHeater_HeatPump_WrappedCondenser_TankElementControlLogic), "Simultaneous");
        

[Description("Used to indicate height of control sensor if Tank Object Type is WaterHeater:Stra" +
    "tified If left blank, it will default to the height of Heater1")]
[JsonProperty(PropertyName="control_sensor_1_height_in_stratified_tank", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ControlSensor1HeightInStratifiedTank { get; set; } = null;
        

[Description("Weight to give Control Sensor 1 temperature")]
[JsonProperty(PropertyName="control_sensor_1_weight", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ControlSensor1Weight { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Used to indicate height of control sensor if Tank Object Type is WaterHeater:Stra" +
    "tified If left blank, it will default to the height of Heater2 The weight of thi" +
    "s control sensor will be 1 - (wt. of control sensor 1)")]
[JsonProperty(PropertyName="control_sensor_2_height_in_stratified_tank", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ControlSensor2HeightInStratifiedTank { get; set; } = null;
    }
    
    public enum WaterHeater_HeatPump_WrappedCondenser_InletAirConfiguration
    {
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAirOnly")]
        OutdoorAirOnly = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Schedule")]
        Schedule = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ZoneAirOnly")]
        ZoneAirOnly = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ZoneAndOutdoorAir")]
        ZoneAndOutdoorAir = 3,
    }
    
    public enum WaterHeater_HeatPump_WrappedCondenser_TankObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="WaterHeater:Stratified")]
        WaterHeaterStratified = 1,
    }
    
    public enum WaterHeater_HeatPump_WrappedCondenser_DxCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:WaterHeating:AirToWaterHeatPump:Wrapped")]
        CoilWaterHeatingAirToWaterHeatPumpWrapped = 1,
    }
    
    public enum WaterHeater_HeatPump_WrappedCondenser_CompressorLocation
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Outdoors")]
        Outdoors = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Schedule")]
        Schedule = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Zone")]
        Zone = 2,
    }
    
    public enum WaterHeater_HeatPump_WrappedCondenser_FanObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:OnOff")]
        FanOnOff = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:SystemModel")]
        FanSystemModel = 2,
    }
    
    public enum WaterHeater_HeatPump_WrappedCondenser_FanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum WaterHeater_HeatPump_WrappedCondenser_ParasiticHeatRejectionLocation
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Outdoors")]
        Outdoors = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Zone")]
        Zone = 2,
    }
    
    public enum WaterHeater_HeatPump_WrappedCondenser_TankElementControlLogic
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MutuallyExclusive")]
        MutuallyExclusive = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Simultaneous")]
        Simultaneous = 2,
    }
    
    [Description(@"This ice storage model is a simplified model It requires a setpoint placed on the Chilled Water Side Outlet Node It should be placed in the chilled water supply side outlet branch followed by a pipe. Use the PlantEquipmentOperation:ComponentSetpoint plant operation scheme.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ThermalStorage_Ice_Simple
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("IceOnCoilInternal = Ice-on-Coil, internal melt IceOnCoilExternal = Ice-on-Coil, e" +
    "xternal melt")]
[JsonProperty(PropertyName="ice_storage_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ThermalStorage_Ice_Simple_IceStorageType IceStorageType { get; set; } = (ThermalStorage_Ice_Simple_IceStorageType)Enum.Parse(typeof(ThermalStorage_Ice_Simple_IceStorageType), "IceOnCoilExternal");
        

[JsonProperty(PropertyName="capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Capacity { get; set; } = null;
        

[JsonProperty(PropertyName="inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutletNodeName { get; set; } = "";
    }
    
    public enum ThermalStorage_Ice_Simple_IceStorageType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="IceOnCoilExternal")]
        IceOnCoilExternal = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="IceOnCoilInternal")]
        IceOnCoilInternal = 1,
    }
    
    [Description("This input syntax is intended to describe a thermal storage system that includes " +
        "smaller containers filled with water that are placed in a larger tank or series " +
        "of tanks. The model uses polynomial equations to describe the system performance" +
        ".")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ThermalStorage_Ice_Detailed
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("This includes only the latent storage capacity")]
[JsonProperty(PropertyName="capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Capacity { get; set; } = null;
        

[JsonProperty(PropertyName="inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="discharging_curve_variable_specifications", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ThermalStorage_Ice_Detailed_DischargingCurveVariableSpecifications DischargingCurveVariableSpecifications { get; set; } = (ThermalStorage_Ice_Detailed_DischargingCurveVariableSpecifications)Enum.Parse(typeof(ThermalStorage_Ice_Detailed_DischargingCurveVariableSpecifications), "FractionChargedLMTD");
        

[JsonProperty(PropertyName="discharging_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DischargingCurveName { get; set; } = "";
        

[JsonProperty(PropertyName="charging_curve_variable_specifications", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ThermalStorage_Ice_Detailed_ChargingCurveVariableSpecifications ChargingCurveVariableSpecifications { get; set; } = (ThermalStorage_Ice_Detailed_ChargingCurveVariableSpecifications)Enum.Parse(typeof(ThermalStorage_Ice_Detailed_ChargingCurveVariableSpecifications), "FractionChargedLMTD");
        

[JsonProperty(PropertyName="charging_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ChargingCurveName { get; set; } = "";
        

[JsonProperty(PropertyName="timestep_of_the_curve_data", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TimestepOfTheCurveData { get; set; } = null;
        

[JsonProperty(PropertyName="parasitic_electric_load_during_discharging", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ParasiticElectricLoadDuringDischarging { get; set; } = null;
        

[JsonProperty(PropertyName="parasitic_electric_load_during_charging", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ParasiticElectricLoadDuringCharging { get; set; } = null;
        

[Description("This is the fraction the total storage capacity that is lost or melts each hour")]
[JsonProperty(PropertyName="tank_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TankLossCoefficient { get; set; } = null;
        

[Description("This temperature is typically 0C for water. Simply changing this temperature with" +
    "out adjusting the performance parameters input above is inappropriate and not ad" +
    "vised.")]
[JsonProperty(PropertyName="freezing_temperature_of_storage_medium", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FreezingTemperatureOfStorageMedium { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This field determines whether the system uses internal or external melt during di" +
    "scharging. This will then have an impact on charging performance.")]
[JsonProperty(PropertyName="thaw_process_indicator", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ThermalStorage_Ice_Detailed_ThawProcessIndicator ThawProcessIndicator { get; set; } = (ThermalStorage_Ice_Detailed_ThawProcessIndicator)Enum.Parse(typeof(ThermalStorage_Ice_Detailed_ThawProcessIndicator), "OutsideMelt");
    }
    
    public enum ThermalStorage_Ice_Detailed_DischargingCurveVariableSpecifications
    {
        
        [System.Runtime.Serialization.EnumMember(Value="FractionChargedLMTD")]
        FractionChargedLMTD = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionDischargedLMTD")]
        FractionDischargedLMTD = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="LMTDFractionCharged")]
        LMTDFractionCharged = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="LMTDMassFlow")]
        LMTDMassFlow = 3,
    }
    
    public enum ThermalStorage_Ice_Detailed_ChargingCurveVariableSpecifications
    {
        
        [System.Runtime.Serialization.EnumMember(Value="FractionChargedLMTD")]
        FractionChargedLMTD = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionDischargedLMTD")]
        FractionDischargedLMTD = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="LMTDFractionCharged")]
        LMTDFractionCharged = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="LMTDMassFlow")]
        LMTDMassFlow = 3,
    }
    
    public enum ThermalStorage_Ice_Detailed_ThawProcessIndicator
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="InsideMelt")]
        InsideMelt = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="OutsideMelt")]
        OutsideMelt = 2,
    }
    
    [Description("Chilled water storage with a well-mixed, single-node tank. The chilled water is \"" +
        "used\" by drawing from the \"Use Side\" of the water tank. The tank is indirectly c" +
        "harged by circulating cold water through the \"Source Side\" of the water tank.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ThermalStorage_ChilledWater_Mixed
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="tank_volume", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TankVolume { get; set; } = Double.Parse("0.1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="setpoint_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="deadband_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DeadbandTemperatureDifference { get; set; } = Double.Parse("0.5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_temperature_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumTemperatureLimit { get; set; } = null;
        

[JsonProperty(PropertyName="nominal_cooling_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NominalCoolingCapacity { get; set; } = null;
        

[JsonProperty(PropertyName="ambient_temperature_indicator", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ThermalStorage_ChilledWater_Mixed_AmbientTemperatureIndicator AmbientTemperatureIndicator { get; set; } = (ThermalStorage_ChilledWater_Mixed_AmbientTemperatureIndicator)Enum.Parse(typeof(ThermalStorage_ChilledWater_Mixed_AmbientTemperatureIndicator), "Outdoors");
        

[JsonProperty(PropertyName="ambient_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AmbientTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="ambient_temperature_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AmbientTemperatureZoneName { get; set; } = "";
        

[Description("required when field Ambient Temperature Indicator=Outdoors")]
[JsonProperty(PropertyName="ambient_temperature_outdoor_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AmbientTemperatureOutdoorAirNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="heat_gain_coefficient_from_ambient_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatGainCoefficientFromAmbientTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="use_side_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UseSideInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="use_side_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UseSideOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="use_side_heat_transfer_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> UseSideHeatTransferEffectiveness { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Availability schedule name for use side. Schedule value > 0 means the system is a" +
    "vailable. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="use_side_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UseSideAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="use_side_design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> UseSideDesignFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="source_side_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SourceSideInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="source_side_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SourceSideOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="source_side_heat_transfer_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SourceSideHeatTransferEffectiveness { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Availability schedule name for source side. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="source_side_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SourceSideAvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="source_side_design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SourceSideDesignFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Parameter for autosizing design flow rates for indirectly cooled water tanks time" +
    " required to lower temperature of entire tank from 14.4C to 9.0C")]
[JsonProperty(PropertyName="tank_recovery_time", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TankRecoveryTime { get; set; } = Double.Parse("4", CultureInfo.InvariantCulture);
    }
    
    public enum ThermalStorage_ChilledWater_Mixed_AmbientTemperatureIndicator
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Outdoors")]
        Outdoors = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Schedule")]
        Schedule = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Zone")]
        Zone = 2,
    }
    
    [Description("Chilled water storage with a stratified, multi-node tank. The chilled water is \"u" +
        "sed\" by drawing from the \"Use Side\" of the water tank. The tank is indirectly ch" +
        "arged by circulating cold water through the \"Source Side\" of the water tank.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ThermalStorage_ChilledWater_Stratified
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="tank_volume", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TankVolume { get; set; } = null;
        

[Description("Height is measured in the axial direction for horizontal cylinders")]
[JsonProperty(PropertyName="tank_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TankHeight { get; set; } = null;
        

[JsonProperty(PropertyName="tank_shape", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ThermalStorage_ChilledWater_Stratified_TankShape TankShape { get; set; } = (ThermalStorage_ChilledWater_Stratified_TankShape)Enum.Parse(typeof(ThermalStorage_ChilledWater_Stratified_TankShape), "VerticalCylinder");
        

[Description("Only used if Tank Shape is Other")]
[JsonProperty(PropertyName="tank_perimeter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TankPerimeter { get; set; } = null;
        

[JsonProperty(PropertyName="setpoint_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="deadband_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DeadbandTemperatureDifference { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="temperature_sensor_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureSensorHeight { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_temperature_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumTemperatureLimit { get; set; } = null;
        

[JsonProperty(PropertyName="nominal_cooling_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NominalCoolingCapacity { get; set; } = null;
        

[JsonProperty(PropertyName="ambient_temperature_indicator", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ThermalStorage_ChilledWater_Stratified_AmbientTemperatureIndicator AmbientTemperatureIndicator { get; set; } = (ThermalStorage_ChilledWater_Stratified_AmbientTemperatureIndicator)Enum.Parse(typeof(ThermalStorage_ChilledWater_Stratified_AmbientTemperatureIndicator), "Outdoors");
        

[JsonProperty(PropertyName="ambient_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AmbientTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="ambient_temperature_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AmbientTemperatureZoneName { get; set; } = "";
        

[Description("required for Ambient Temperature Indicator=Outdoors")]
[JsonProperty(PropertyName="ambient_temperature_outdoor_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AmbientTemperatureOutdoorAirNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="uniform_skin_loss_coefficient_per_unit_area_to_ambient_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> UniformSkinLossCoefficientPerUnitAreaToAmbientTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="use_side_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UseSideInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="use_side_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UseSideOutletNodeName { get; set; } = "";
        

[Description(@"The use side effectiveness in the stratified tank model is a simplified analogy of a heat exchanger's effectiveness. This effectiveness is equal to the fraction of use mass flow rate that directly mixes with the tank fluid. And one minus the effectiveness is the fraction that bypasses the tank. The use side mass flow rate that bypasses the tank is mixed with the fluid or water leaving the stratified tank.")]
[JsonProperty(PropertyName="use_side_heat_transfer_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> UseSideHeatTransferEffectiveness { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Availability schedule name for use side. Schedule value > 0 means the system is a" +
    "vailable. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="use_side_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UseSideAvailabilityScheduleName { get; set; } = "";
        

[Description("Defaults to top of tank")]
[JsonProperty(PropertyName="use_side_inlet_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> UseSideInletHeight { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Defaults to bottom of tank")]
[JsonProperty(PropertyName="use_side_outlet_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> UseSideOutletHeight { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="use_side_design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> UseSideDesignFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="source_side_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SourceSideInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="source_side_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SourceSideOutletNodeName { get; set; } = "";
        

[Description(@"The source side effectiveness in the stratified tank model is a simplified analogy of a heat exchanger's effectiveness. This effectiveness is equal to the fraction of source mass flow rate that directly mixes with the tank fluid. And one minus the effectiveness is the fraction that bypasses the tank. The source side mass flow rate that bypasses the tank is mixed with the fluid or water leaving the stratified tank.")]
[JsonProperty(PropertyName="source_side_heat_transfer_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SourceSideHeatTransferEffectiveness { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Availability schedule name for use side. Schedule value > 0 means the system is a" +
    "vailable. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="source_side_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SourceSideAvailabilityScheduleName { get; set; } = "";
        

[Description("Defaults to bottom of tank")]
[JsonProperty(PropertyName="source_side_inlet_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SourceSideInletHeight { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Defaults to top of tank")]
[JsonProperty(PropertyName="source_side_outlet_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> SourceSideOutletHeight { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="source_side_design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SourceSideDesignFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Parameter for autosizing design flow rates for indirectly cooled water tanks time" +
    " required to lower temperature of entire tank from 14.4C to 9.0C")]
[JsonProperty(PropertyName="tank_recovery_time", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TankRecoveryTime { get; set; } = Double.Parse("4", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="inlet_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ThermalStorage_ChilledWater_Stratified_InletMode InletMode { get; set; } = (ThermalStorage_ChilledWater_Stratified_InletMode)Enum.Parse(typeof(ThermalStorage_ChilledWater_Stratified_InletMode), "Fixed");
        

[JsonProperty(PropertyName="number_of_nodes", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfNodes { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="additional_destratification_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AdditionalDestratificationConductivity { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="node_1_additional_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Node1AdditionalLossCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="node_2_additional_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Node2AdditionalLossCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="node_3_additional_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Node3AdditionalLossCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="node_4_additional_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Node4AdditionalLossCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="node_5_additional_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Node5AdditionalLossCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="node_6_additional_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Node6AdditionalLossCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="node_7_additional_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Node7AdditionalLossCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="node_8_additional_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Node8AdditionalLossCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="node_9_additional_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Node9AdditionalLossCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="node_10_additional_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Node10AdditionalLossCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    public enum ThermalStorage_ChilledWater_Stratified_TankShape
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="HorizontalCylinder")]
        HorizontalCylinder = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Other")]
        Other = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="VerticalCylinder")]
        VerticalCylinder = 3,
    }
    
    public enum ThermalStorage_ChilledWater_Stratified_AmbientTemperatureIndicator
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Outdoors")]
        Outdoors = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Schedule")]
        Schedule = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Zone")]
        Zone = 2,
    }
    
    public enum ThermalStorage_ChilledWater_Stratified_InletMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fixed")]
        Fixed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Seeking")]
        Seeking = 2,
    }
}
