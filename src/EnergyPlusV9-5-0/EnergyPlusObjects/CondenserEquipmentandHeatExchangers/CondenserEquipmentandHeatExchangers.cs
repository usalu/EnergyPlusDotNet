namespace EnergyPlus.CondenserEquipmentandHeatExchangers
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
    using EnergyPlus.ZoneHVACForcedAirUnits;
    using EnergyPlus.ZoneHVACRadiativeConvectiveUnits;
    
    
    [Description(@"This tower model is based on Merkel's theory, which is also the basis for the tower model in ASHRAE's HVAC1 Toolkit. The open wet cooling tower is modeled as a counter flow heat exchanger with a single-speed fan drawing air through the tower (induced-draft configuration). Added fluid bypass as an additional capacity control. 8/2008. For a multi-cell tower, the capacity and air/water flow rate inputs are for the entire tower.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class CoolingTower_SingleSpeed
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Name of tower water inlet node")]
[JsonProperty(PropertyName="water_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterInletNodeName { get; set; } = "";
        

[Description("Name of tower water outlet node")]
[JsonProperty(PropertyName="water_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterOutletNodeName { get; set; } = "";
        

[Description("Leave field blank if tower performance input method is NominalCapacity")]
[JsonProperty(PropertyName="design_water_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignWaterFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="design_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This is the fan motor electric input power")]
[JsonProperty(PropertyName="design_fan_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignFanPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Leave field blank if tower performance input method is NominalCapacity")]
[JsonProperty(PropertyName="design_u_factor_times_area_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignUFactorTimesAreaValue { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="free_convection_regime_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> FreeConvectionRegimeAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used if the previous field is set to autocalculate.")]
[JsonProperty(PropertyName="free_convection_regime_air_flow_rate_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FreeConvectionRegimeAirFlowRateSizingFactor { get; set; } = Double.Parse("0.1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="free_convection_regime_u_factor_times_area_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> FreeConvectionRegimeUFactorTimesAreaValue { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used if the previous field is set to autocalculate and the Per" +
    "formance Input Method is UFactorTimesAreaAndDesignWaterFlowRate")]
[JsonProperty(PropertyName="free_convection_u_factor_times_area_value_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FreeConvectionUFactorTimesAreaValueSizingFactor { get; set; } = Double.Parse("0.1", CultureInfo.InvariantCulture);
        

[Description("User can define tower thermal performance by specifying the tower UA, the Design " +
    "Air Flow Rate and the Design Water Flow Rate, or by specifying the tower nominal" +
    " capacity")]
[JsonProperty(PropertyName="performance_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CoolingTower_SingleSpeed_PerformanceInputMethod PerformanceInputMethod { get; set; } = (CoolingTower_SingleSpeed_PerformanceInputMethod)Enum.Parse(typeof(CoolingTower_SingleSpeed_PerformanceInputMethod), "UFactorTimesAreaAndDesignWaterFlowRate");
        

[JsonProperty(PropertyName="heat_rejection_capacity_and_nominal_capacity_sizing_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatRejectionCapacityAndNominalCapacitySizingRatio { get; set; } = Double.Parse("1.25", CultureInfo.InvariantCulture);
        

[Description(@"Nominal tower capacity with entering water at 35C (95F), leaving water at 29.44C (85F), entering air at 25.56C (78F) wet-bulb temperature and 35C (95F) dry-bulb temperature. Design water flow rate assumed to be 5.382E-8 m3/s per watt (3 gpm/ton). Nominal tower capacity times (1.25) gives the actual tower heat rejection at these operating conditions.")]
[JsonProperty(PropertyName="nominal_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NominalCapacity { get; set; } = null;
        

[Description(@"Tower capacity in free convection regime with entering water at 35C (95F), leaving water at 29.44C (85F), entering air at 25.56C (78F) wet-bulb temperature and 35C (95F) dry-bulb temperature. Design water flow rate assumed to be 5.382E-8 m3/s per watt of nominal tower capacity (3 gpm/ton). Tower free convection capacity times (1.25) gives the actual tower heat rejection at these operating conditions.")]
[JsonProperty(PropertyName="free_convection_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> FreeConvectionCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used if the previous field is set to autocalculate")]
[JsonProperty(PropertyName="free_convection_nominal_capacity_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FreeConvectionNominalCapacitySizingFactor { get; set; } = Double.Parse("0.1", CultureInfo.InvariantCulture);
        

[Description("Enter the tower\'s design inlet air dry-bulb temperature")]
[JsonProperty(PropertyName="design_inlet_air_dry_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignInletAirDryBulbTemperature { get; set; } = Double.Parse("35", CultureInfo.InvariantCulture);
        

[Description("Enter the tower\'s design inlet air wet-bulb temperature")]
[JsonProperty(PropertyName="design_inlet_air_wet_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignInletAirWetBulbTemperature { get; set; } = Double.Parse("25.6", CultureInfo.InvariantCulture);
        

[Description("Enter the approach temperature corresponding to the design inlet air wet-bulb tem" +
    "perature and design range temperature. Design approach temp = outlet water tempe" +
    "rature minus inlet air wet-bulb temperature at design conditions. Autosized to 3" +
    ".9 deltaC.")]
[JsonProperty(PropertyName="design_approach_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignApproachTemperature { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the range temperature corresponding to the design inlet air wet-bulb temper" +
    "ature and design approach temperature. Design range = inlet water temperature mi" +
    "nus outlet water temperature at design conditions. Autosized to 5.5 deltaC.")]
[JsonProperty(PropertyName="design_range_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignRangeTemperature { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This heater maintains the basin water temperature at the basin heater setpoint te" +
    "mperature when the outdoor air temperature falls below the setpoint temperature." +
    " The basin heater only operates when water is not flowing through the tower.")]
[JsonProperty(PropertyName="basin_heater_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BasinHeaterCapacity { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Enter the outdoor dry-bulb temperature when the basin heater turns on")]
[JsonProperty(PropertyName="basin_heater_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BasinHeaterSetpointTemperature { get; set; } = Double.Parse("2", CultureInfo.InvariantCulture);
        

[Description(@"Schedule values greater than 0 allow the basin heater to operate whenever the outdoor air dry-bulb temperature is below the basin heater setpoint temperature. If a schedule name is not entered, the basin heater is allowed to operate throughout the entire simulation.")]
[JsonProperty(PropertyName="basin_heater_operating_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BasinHeaterOperatingScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="evaporation_loss_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CoolingTower_SingleSpeed_EvaporationLossMode EvaporationLossMode { get; set; } = (CoolingTower_SingleSpeed_EvaporationLossMode)Enum.Parse(typeof(CoolingTower_SingleSpeed_EvaporationLossMode), "LossFactor");
        

[Description(@"Rate of water evaporation from the cooling tower and lost to the outdoor air [%/K] Evaporation loss is calculated as percentage of the circulating condenser water rate Value entered here is percent-per-degree K of temperature drop in the condenser water Typical values are from 0.15 to 0.27 [%/K].")]
[JsonProperty(PropertyName="evaporation_loss_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvaporationLossFactor { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[Description("Rate of drift loss as a percentage of circulating condenser water flow rate Typic" +
    "al values are between 0.002 and 0.2% The default value is 0.008%")]
[JsonProperty(PropertyName="drift_loss_percent", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DriftLossPercent { get; set; } = Double.Parse("0.008", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="blowdown_calculation_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CoolingTower_SingleSpeed_BlowdownCalculationMode BlowdownCalculationMode { get; set; } = (CoolingTower_SingleSpeed_BlowdownCalculationMode)Enum.Parse(typeof(CoolingTower_SingleSpeed_BlowdownCalculationMode), "ConcentrationRatio");
        

[Description(@"Characterizes the rate of blowdown in the cooling tower. Blowdown is water intentionally drained from the tower in order to offset the build up of solids in the water that would otherwise occur because of evaporation. Ratio of solids in the blowdown water to solids in the make up water. Typical values for tower operation are 3 to 5. The default value is 3.")]
[JsonProperty(PropertyName="blowdown_concentration_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BlowdownConcentrationRatio { get; set; } = Double.Parse("3", CultureInfo.InvariantCulture);
        

[Description(@"Makeup water usage due to blowdown results from occasionally draining a small amount of water in the tower basin to purge scale or other contaminants to reduce their concentration in order to maintain an acceptable level of water quality. Schedule values should reflect water usage in m3/s.")]
[JsonProperty(PropertyName="blowdown_makeup_water_usage_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BlowdownMakeupWaterUsageScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="supply_water_storage_tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyWaterStorageTankName { get; set; } = "";
        

[Description("Enter the name of an outdoor air node")]
[JsonProperty(PropertyName="outdoor_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="capacity_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CoolingTower_SingleSpeed_CapacityControl CapacityControl { get; set; } = (CoolingTower_SingleSpeed_CapacityControl)Enum.Parse(typeof(CoolingTower_SingleSpeed_CapacityControl), "FanCycling");
        

[JsonProperty(PropertyName="number_of_cells", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfCells { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cell_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CoolingTower_SingleSpeed_CellControl CellControl { get; set; } = (CoolingTower_SingleSpeed_CellControl)Enum.Parse(typeof(CoolingTower_SingleSpeed_CellControl), "MinimalCell");
        

[Description("The allowable minimal fraction of the nominal flow rate per cell")]
[JsonProperty(PropertyName="cell_minimum_water_flow_rate_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CellMinimumWaterFlowRateFraction { get; set; } = Double.Parse("0.33", CultureInfo.InvariantCulture);
        

[Description("The allowable maximal fraction of the nominal flow rate per cell")]
[JsonProperty(PropertyName="cell_maximum_water_flow_rate_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CellMaximumWaterFlowRateFraction { get; set; } = Double.Parse("2.5", CultureInfo.InvariantCulture);
        

[Description("Multiplies the autosized capacity and flow rates")]
[JsonProperty(PropertyName="sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SizingFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    public enum CoolingTower_SingleSpeed_PerformanceInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="NominalCapacity")]
        NominalCapacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UFactorTimesAreaAndDesignWaterFlowRate")]
        UFactorTimesAreaAndDesignWaterFlowRate = 2,
    }
    
    public enum CoolingTower_SingleSpeed_EvaporationLossMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="LossFactor")]
        LossFactor = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SaturatedExit")]
        SaturatedExit = 1,
    }
    
    public enum CoolingTower_SingleSpeed_BlowdownCalculationMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="ConcentrationRatio")]
        ConcentrationRatio = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ScheduledRate")]
        ScheduledRate = 1,
    }
    
    public enum CoolingTower_SingleSpeed_CapacityControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FanCycling")]
        FanCycling = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FluidBypass")]
        FluidBypass = 2,
    }
    
    public enum CoolingTower_SingleSpeed_CellControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MaximalCell")]
        MaximalCell = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="MinimalCell")]
        MinimalCell = 2,
    }
    
    [Description(@"This tower model is based on Merkel's theory, which is also the basis for the tower model in ASHRAE's HVAC1 Toolkit. The open wet cooling tower is modeled as a counter flow heat exchanger with a two-speed fan drawing air through the tower (induced-draft configuration). For a multi-cell tower, the capacity and air/water flow rate inputs are for the entire tower.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class CoolingTower_TwoSpeed
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Name of tower Water Inlet Node")]
[JsonProperty(PropertyName="water_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterInletNodeName { get; set; } = "";
        

[Description("Name of tower Water Outlet Node")]
[JsonProperty(PropertyName="water_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterOutletNodeName { get; set; } = "";
        

[Description("Leave field blank if Tower Performance Input Method is NominalCapacity")]
[JsonProperty(PropertyName="design_water_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignWaterFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="high_fan_speed_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HighFanSpeedAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This is the fan motor electric input power at high speed")]
[JsonProperty(PropertyName="high_fan_speed_fan_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HighFanSpeedFanPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Leave field blank if Tower Performance Input Method is NominalCapacity")]
[JsonProperty(PropertyName="high_fan_speed_u_factor_times_area_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HighFanSpeedUFactorTimesAreaValue { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Low speed air flow rate must be less than high speed air flow rate Low speed air " +
    "flow rate must be greater than free convection air flow rate")]
[JsonProperty(PropertyName="low_fan_speed_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> LowFanSpeedAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used if the previous field is set to autocalculate.")]
[JsonProperty(PropertyName="low_fan_speed_air_flow_rate_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LowFanSpeedAirFlowRateSizingFactor { get; set; } = Double.Parse("0.5", CultureInfo.InvariantCulture);
        

[Description("This is the fan motor electric input power at low speed")]
[JsonProperty(PropertyName="low_fan_speed_fan_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> LowFanSpeedFanPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used if the previous field is set to autocalculate.")]
[JsonProperty(PropertyName="low_fan_speed_fan_power_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LowFanSpeedFanPowerSizingFactor { get; set; } = Double.Parse("0.16", CultureInfo.InvariantCulture);
        

[Description("Leave field blank if tower Performance Input Method is NominalCapacity Low speed " +
    "tower UA must be less than high speed tower UA Low speed tower UA must be greate" +
    "r than free convection tower UA")]
[JsonProperty(PropertyName="low_fan_speed_u_factor_times_area_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> LowFanSpeedUFactorTimesAreaValue { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used if the previous field is set to autocalculate and the Per" +
    "formance Input Method is UFactorTimesAreaAndDesignWaterFlowRate")]
[JsonProperty(PropertyName="low_fan_speed_u_factor_times_area_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LowFanSpeedUFactorTimesAreaSizingFactor { get; set; } = Double.Parse("0.6", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="free_convection_regime_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> FreeConvectionRegimeAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used if the previous field is set to autocalculate.")]
[JsonProperty(PropertyName="free_convection_regime_air_flow_rate_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FreeConvectionRegimeAirFlowRateSizingFactor { get; set; } = Double.Parse("0.1", CultureInfo.InvariantCulture);
        

[Description("Leave field blank if Tower Performance Input Method is NominalCapacity")]
[JsonProperty(PropertyName="free_convection_regime_u_factor_times_area_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> FreeConvectionRegimeUFactorTimesAreaValue { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used if the previous field is set to autocalculate and the Per" +
    "formance Input Method is UFactorTimesAreaAndDesignWaterFlowRate")]
[JsonProperty(PropertyName="free_convection_u_factor_times_area_value_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FreeConvectionUFactorTimesAreaValueSizingFactor { get; set; } = Double.Parse("0.1", CultureInfo.InvariantCulture);
        

[Description("User can define tower thermal performance by specifying the tower UA, the Design " +
    "Air Flow Rate and the Design Water Flow Rate, or by specifying the tower nominal" +
    " capacity")]
[JsonProperty(PropertyName="performance_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CoolingTower_TwoSpeed_PerformanceInputMethod PerformanceInputMethod { get; set; } = (CoolingTower_TwoSpeed_PerformanceInputMethod)Enum.Parse(typeof(CoolingTower_TwoSpeed_PerformanceInputMethod), "UFactorTimesAreaAndDesignWaterFlowRate");
        

[JsonProperty(PropertyName="heat_rejection_capacity_and_nominal_capacity_sizing_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatRejectionCapacityAndNominalCapacitySizingRatio { get; set; } = Double.Parse("1.25", CultureInfo.InvariantCulture);
        

[Description(@"Nominal tower capacity with entering water at 35C (95F), leaving water at 29.44C (85F), entering air at 25.56C (78F) wet-bulb temperature and 35C (95F) dry-bulb temperature, with the tower fan operating at high speed. Design water flow rate assumed to be 5.382E-8 m3/s per watt(3 gpm/ton). Nominal tower capacity times the Heat Rejection Capacity and Nominal Capacity Sizing Ratio (e.g. 1.25) gives the actual tower heat rejection at these operating conditions.")]
[JsonProperty(PropertyName="high_speed_nominal_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HighSpeedNominalCapacity { get; set; } = null;
        

[Description(@"Nominal tower capacity with entering water at 35C (95F), leaving water at 29.44C (85F), entering air at 25.56C (78F) wet-bulb temperature and 35C (95F) dry-bulb temperature, with the tower fan operating at low speed. Design water flow rate assumed to be 5.382E-8 m3/s per watt of tower high-speed nominal capacity (3 gpm/ton). Nominal tower capacity times the Heat Rejection Capacity and Nominal Capacity Sizing Ratio (e.g. 1.25) gives the actual tower heat rejection at these operating conditions.")]
[JsonProperty(PropertyName="low_speed_nominal_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> LowSpeedNominalCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used if the previous field is set to autocalculate")]
[JsonProperty(PropertyName="low_speed_nominal_capacity_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LowSpeedNominalCapacitySizingFactor { get; set; } = Double.Parse("0.5", CultureInfo.InvariantCulture);
        

[Description(@"Tower capacity in free convection regime with entering water at 35C (95F), leaving water at 29.44C (85F), entering air at 25.56C (78F) wet-bulb temperature and 35C (95F) dry-bulb temperature. Design water flow rate assumed to be 5.382E-8 m3/s per watt of tower high-speed nominal capacity (3 gpm/ton). Tower free convection capacity times the Heat Rejection Capacity and Nominal Capacity Sizing Ratio (e.g. 1.25)  gives the actual tower heat rejection at these operating conditions")]
[JsonProperty(PropertyName="free_convection_nominal_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> FreeConvectionNominalCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used if the previous field is set to autocalculate")]
[JsonProperty(PropertyName="free_convection_nominal_capacity_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FreeConvectionNominalCapacitySizingFactor { get; set; } = Double.Parse("0.1", CultureInfo.InvariantCulture);
        

[Description("Enter the tower\'s design inlet air dry-bulb temperature")]
[JsonProperty(PropertyName="design_inlet_air_dry_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignInletAirDryBulbTemperature { get; set; } = Double.Parse("35", CultureInfo.InvariantCulture);
        

[Description("Enter the tower\'s design inlet air wet-bulb temperature")]
[JsonProperty(PropertyName="design_inlet_air_wet_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignInletAirWetBulbTemperature { get; set; } = Double.Parse("25.6", CultureInfo.InvariantCulture);
        

[Description("Enter the approach temperature corresponding to the design inlet air wet-bulb tem" +
    "perature and design range temperature. Design approach temp = outlet water tempe" +
    "rature minus inlet air wet-bulb temperature at design conditions. Autosized to 3" +
    ".9 deltaC.")]
[JsonProperty(PropertyName="design_approach_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignApproachTemperature { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the range temperature corresponding to the design inlet air wet-bulb temper" +
    "ature and design approach temperature. Design range = inlet water temperature mi" +
    "nus outlet water temperature at design conditions. Autosized to 5.5 deltaC.")]
[JsonProperty(PropertyName="design_range_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignRangeTemperature { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This heater maintains the basin water temperature at the basin heater setpoint te" +
    "mperature when the outdoor air temperature falls below the setpoint temperature." +
    " The basin heater only operates when water is not flowing through the tower.")]
[JsonProperty(PropertyName="basin_heater_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BasinHeaterCapacity { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Enter the outdoor dry-bulb temperature when the basin heater turns on")]
[JsonProperty(PropertyName="basin_heater_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BasinHeaterSetpointTemperature { get; set; } = Double.Parse("2", CultureInfo.InvariantCulture);
        

[Description(@"Schedule values greater than 0 allow the basin heater to operate whenever the outdoor air dry-bulb temperature is below the basin heater setpoint temperature. If a schedule name is not entered, the basin heater is allowed to operate throughout the entire simulation.")]
[JsonProperty(PropertyName="basin_heater_operating_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BasinHeaterOperatingScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="evaporation_loss_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CoolingTower_TwoSpeed_EvaporationLossMode EvaporationLossMode { get; set; } = (CoolingTower_TwoSpeed_EvaporationLossMode)Enum.Parse(typeof(CoolingTower_TwoSpeed_EvaporationLossMode), "LossFactor");
        

[Description(@"Rate of water evaporated from the cooling tower and lost to the outdoor air [%/K] Evaporation loss is calculated as percentage of the circulating condenser water rate Value entered here is percent-per-degree K of temperature drop in the condenser water Typical values are from 0.15 to 0.27 [%/K].")]
[JsonProperty(PropertyName="evaporation_loss_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvaporationLossFactor { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[Description("Rate of drift loss as a percentage of circulating condenser water flow rate Typic" +
    "al values are between 0.002 and 0.2% The default value is 0.008%")]
[JsonProperty(PropertyName="drift_loss_percent", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DriftLossPercent { get; set; } = Double.Parse("0.008", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="blowdown_calculation_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CoolingTower_TwoSpeed_BlowdownCalculationMode BlowdownCalculationMode { get; set; } = (CoolingTower_TwoSpeed_BlowdownCalculationMode)Enum.Parse(typeof(CoolingTower_TwoSpeed_BlowdownCalculationMode), "ConcentrationRatio");
        

[Description(@"Characterizes the rate of blowdown in the cooling tower. Blowdown is water intentionally drained from the tower in order to offset the build up of solids in the water that would otherwise occur because of evaporation. Ratio of solids in the blowdown water to solids in the make up water. Typical values for tower operation are 3 to 5. The default value is 3.")]
[JsonProperty(PropertyName="blowdown_concentration_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BlowdownConcentrationRatio { get; set; } = Double.Parse("3", CultureInfo.InvariantCulture);
        

[Description(@"Makeup water usage due to blowdown results from occasionally draining some amount of water in the tower basin to purge scale or other contaminants to reduce their concentration in order to maintain an acceptable level of water quality. Schedule values should reflect water usage in m3/s.")]
[JsonProperty(PropertyName="blowdown_makeup_water_usage_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BlowdownMakeupWaterUsageScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="supply_water_storage_tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyWaterStorageTankName { get; set; } = "";
        

[Description("Enter the name of an outdoor air node")]
[JsonProperty(PropertyName="outdoor_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="number_of_cells", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfCells { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cell_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CoolingTower_TwoSpeed_CellControl CellControl { get; set; } = (CoolingTower_TwoSpeed_CellControl)Enum.Parse(typeof(CoolingTower_TwoSpeed_CellControl), "MinimalCell");
        

[Description("The allowable minimal fraction of the nominal flow rate per cell")]
[JsonProperty(PropertyName="cell_minimum_water_flow_rate_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CellMinimumWaterFlowRateFraction { get; set; } = Double.Parse("0.33", CultureInfo.InvariantCulture);
        

[Description("The allowable maximal fraction of the nominal flow rate per cell")]
[JsonProperty(PropertyName="cell_maximum_water_flow_rate_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CellMaximumWaterFlowRateFraction { get; set; } = Double.Parse("2.5", CultureInfo.InvariantCulture);
        

[Description("Multiplies the autosized capacity and flow rates")]
[JsonProperty(PropertyName="sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SizingFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    public enum CoolingTower_TwoSpeed_PerformanceInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="NominalCapacity")]
        NominalCapacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UFactorTimesAreaAndDesignWaterFlowRate")]
        UFactorTimesAreaAndDesignWaterFlowRate = 2,
    }
    
    public enum CoolingTower_TwoSpeed_EvaporationLossMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="LossFactor")]
        LossFactor = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SaturatedExit")]
        SaturatedExit = 1,
    }
    
    public enum CoolingTower_TwoSpeed_BlowdownCalculationMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="ConcentrationRatio")]
        ConcentrationRatio = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ScheduledRate")]
        ScheduledRate = 1,
    }
    
    public enum CoolingTower_TwoSpeed_CellControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MaximalCell")]
        MaximalCell = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="MinimalCell")]
        MinimalCell = 2,
    }
    
    [Description(@"This tower model is based on Merkel's theory, which is also the basis for the tower model in ASHRAE's HVAC1 Toolkit. The open wet cooling tower is modeled as a counter flow heat exchanger with a variable-speed fan drawing air through the tower (induced-draft configuration). For a multi-cell tower, the capacity and air/water flow rate inputs are for the entire tower.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class CoolingTower_VariableSpeed_Merkel
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Name of tower water inlet node")]
[JsonProperty(PropertyName="water_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterInletNodeName { get; set; } = "";
        

[Description("Name of tower water outlet node")]
[JsonProperty(PropertyName="water_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterOutletNodeName { get; set; } = "";
        

[Description("User can define tower thermal performance by specifying the tower UA, the Design " +
    "Air Flow Rate and the Design Water Flow Rate, or by specifying the tower nominal" +
    " capacity")]
[JsonProperty(PropertyName="performance_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CoolingTower_VariableSpeed_Merkel_PerformanceInputMethod PerformanceInputMethod { get; set; } = (CoolingTower_VariableSpeed_Merkel_PerformanceInputMethod)Enum.Parse(typeof(CoolingTower_VariableSpeed_Merkel_PerformanceInputMethod), "NominalCapacity");
        

[JsonProperty(PropertyName="heat_rejection_capacity_and_nominal_capacity_sizing_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatRejectionCapacityAndNominalCapacitySizingRatio { get; set; } = Double.Parse("1.25", CultureInfo.InvariantCulture);
        

[Description(@"Nominal tower capacity with entering water at 35C (95F), leaving water at 29.44C (85F), entering air at 25.56C (78F) wet-bulb temperature and 35C (95F) dry-bulb temperature, with the tower fan operating at Design Air Flow Rate (full speed). Design water flow rate is as set in Design Water Flow Rate per Unit of Nominal Capacity. Nominal tower capacity times the Heat Rejection Capacity and Nominal Capacity Sizing Ratio (e.g. 1.25) gives the actual tower heat rejection at these operating conditions.")]
[JsonProperty(PropertyName="nominal_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NominalCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"required field when performance method is NominalCapacity Tower capacity in free convection regime with entering water at 35C (95F), leaving water at 29.44C (85F), entering air at 25.56C (78F) wet-bulb temperature and 35C (95F) dry-bulb temperature. Design water flow rate is as set in Design Water Flow Rate per Unit of Nominal Capacity. Tower free convection capacity times the Heat Rejection Capacity and Nominal Capacity Sizing Ratio (e.g. 1.25)  gives the actual tower heat rejection at these operating conditions")]
[JsonProperty(PropertyName="free_convection_nominal_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> FreeConvectionNominalCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used if the previous field is set to autocalculate")]
[JsonProperty(PropertyName="free_convection_nominal_capacity_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FreeConvectionNominalCapacitySizingFactor { get; set; } = Double.Parse("0.1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="design_water_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignWaterFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used if the previous is set to autocalculate and performance i" +
    "nput method is NominalCapacity")]
[JsonProperty(PropertyName="design_water_flow_rate_per_unit_of_nominal_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignWaterFlowRatePerUnitOfNominalCapacity { get; set; } = Double.Parse("5.382E-08", CultureInfo.InvariantCulture);
        

[Description("This is the air flow rate at full fan speed")]
[JsonProperty(PropertyName="design_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> DesignAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"This field is only used if the previous is set to autocalculate When field is left blank the default scaling factor is adjusted for elevation to increase volume flow at altitude When field has a value the scaling factor is used without adjusting for elevation")]
[JsonProperty(PropertyName="design_air_flow_rate_per_unit_of_nominal_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignAirFlowRatePerUnitOfNominalCapacity { get; set; } = Double.Parse("2.76316E-05", CultureInfo.InvariantCulture);
        

[Description("Enter the minimum air flow rate ratio. This is typically determined by the variab" +
    "le speed drive that controls the fan motor speed. Valid entries are from 0.1 to " +
    "0.5.")]
[JsonProperty(PropertyName="minimum_air_flow_rate_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumAirFlowRateRatio { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[Description("This is the fan motor electric input power at high speed")]
[JsonProperty(PropertyName="design_fan_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> DesignFanPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used if the previous is set to autocalculate [W/W] Watts of fa" +
    "n power per Watt of tower nominal capacity")]
[JsonProperty(PropertyName="design_fan_power_per_unit_of_nominal_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignFanPowerPerUnitOfNominalCapacity { get; set; } = Double.Parse("0.0105", CultureInfo.InvariantCulture);
        

[Description("Any curve or table with one independent variable can be used cubic curve = a + b*" +
    "AFR + c*AFR**2 + d*AFR**3 quartic curve = a + b*AFR + c*AFR**2 + d*AFR**3 + e*AF" +
    "R**4 x = AFR = Ratio of current operating air flow rate to Design Air Flow Rate")]
[JsonProperty(PropertyName="fan_power_modifier_function_of_air_flow_rate_ratio_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FanPowerModifierFunctionOfAirFlowRateRatioCurveName { get; set; } = "";
        

[JsonProperty(PropertyName="free_convection_regime_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> FreeConvectionRegimeAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used if the previous field is set to autocalculate.")]
[JsonProperty(PropertyName="free_convection_regime_air_flow_rate_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FreeConvectionRegimeAirFlowRateSizingFactor { get; set; } = Double.Parse("0.1", CultureInfo.InvariantCulture);
        

[Description("required field when performance method is UFactorTimesAreaAndDesignWaterFlowRate " +
    "when performance method is NominalCapacity the program will solve for this UA")]
[JsonProperty(PropertyName="design_air_flow_rate_u_factor_times_area_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignAirFlowRateUFactorTimesAreaValue { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("required field when performance input method is UFactorTimesAreaAndDesignWaterFlo" +
    "wRate Leave field blank if performance input method is NominalCapacity")]
[JsonProperty(PropertyName="free_convection_regime_u_factor_times_area_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> FreeConvectionRegimeUFactorTimesAreaValue { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("required field when performance input method is UFactorTimesAreaAndDesignWaterFlo" +
    "wRate This field is only used if the previous field is set to autocalculate and " +
    "the performance input method is UFactorTimesAreaAndDesignWaterFlowRate")]
[JsonProperty(PropertyName="free_convection_u_factor_times_area_value_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FreeConvectionUFactorTimesAreaValueSizingFactor { get; set; } = Double.Parse("0.1", CultureInfo.InvariantCulture);
        

[Description(@"This curve describes how tower's design UA changes with variable air flow rate Any curve or table with one independent variable can be used cubic curve = a + b*AFR + c*AFR**2 + d*AFR**3 quartic curve = a + b*AFR + c*AFR**2 + d*AFR**3 + e*AFR**4 x = AFR = Ratio of current operating air flow rate to Design Air Flow Rate")]
[JsonProperty(PropertyName="u_factor_times_area_modifier_function_of_air_flow_ratio_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UFactorTimesAreaModifierFunctionOfAirFlowRatioCurveName { get; set; } = "";
        

[Description(@"curve describes how tower UA changes with outdoor air wet-bulb temperature difference from design wet-bulb Any curve or table with one independent variable can be used cubic curve = a + b*DeltaWB + c*DeltaWB**2 + d*DeltaWB**3 quartic curve = a + b*DeltaWB + c*DeltaWB**2 + d*DeltaWB**3 + e*DeltaWB**4 x = DeltaWB = (design wet-bulb temperature in C - current wet-bulb temperature in C) where design wet-bulb temperature of entering air is 25.56C (78F)")]
[JsonProperty(PropertyName="u_factor_times_area_modifier_function_of_wetbulb_temperature_difference_curve_nam" +
    "e", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UFactorTimesAreaModifierFunctionOfWetbulbTemperatureDifferenceCurveName { get; set; } = "";
        

[Description(@"curve describes how tower UA changes with the flow rate of condenser water through the tower Any curve or table with one independent variable can be used cubic curve = a + b*WFR + c*WFR**2 + d*WFR**3 quartic curve = a + b*WFR + c*WFR**2 + d*WFR**3 + e*WFR**4 x = WFR = Ratio of current operating water flow rate to Design Water Flow Rate")]
[JsonProperty(PropertyName="u_factor_times_area_modifier_function_of_water_flow_ratio_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UFactorTimesAreaModifierFunctionOfWaterFlowRatioCurveName { get; set; } = "";
        

[Description("Enter the tower\'s design inlet air dry-bulb temperature")]
[JsonProperty(PropertyName="design_inlet_air_dry_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignInletAirDryBulbTemperature { get; set; } = Double.Parse("35", CultureInfo.InvariantCulture);
        

[Description("Enter the tower\'s design inlet air wet-bulb temperature")]
[JsonProperty(PropertyName="design_inlet_air_wet_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignInletAirWetBulbTemperature { get; set; } = Double.Parse("25.6", CultureInfo.InvariantCulture);
        

[Description("Enter the approach temperature corresponding to the design inlet air wet-bulb tem" +
    "perature and design range temperature. Design approach temp = outlet water tempe" +
    "rature minus inlet air wet-bulb temperature at design conditions. Autosized to 3" +
    ".9 deltaC.")]
[JsonProperty(PropertyName="design_approach_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignApproachTemperature { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the range temperature corresponding to the design inlet air wet-bulb temper" +
    "ature and design approach temperature. Design range = inlet water temperature mi" +
    "nus outlet water temperature at design conditions. Autosized to 5.5 deltaC.")]
[JsonProperty(PropertyName="design_range_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignRangeTemperature { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This heater maintains the basin water temperature at the basin heater setpoint te" +
    "mperature when the outdoor air temperature falls below the setpoint temperature." +
    " The basin heater only operates when water is not flowing through the tower.")]
[JsonProperty(PropertyName="basin_heater_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BasinHeaterCapacity { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Enter the outdoor dry-bulb temperature when the basin heater turns on")]
[JsonProperty(PropertyName="basin_heater_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BasinHeaterSetpointTemperature { get; set; } = Double.Parse("2", CultureInfo.InvariantCulture);
        

[Description(@"Schedule values greater than 0 allow the basin heater to operate whenever the outdoor air dry-bulb temperature is below the basin heater setpoint temperature. If a schedule name is not entered, the basin heater is allowed to operate throughout the entire simulation.")]
[JsonProperty(PropertyName="basin_heater_operating_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BasinHeaterOperatingScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="evaporation_loss_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CoolingTower_VariableSpeed_Merkel_EvaporationLossMode EvaporationLossMode { get; set; } = (CoolingTower_VariableSpeed_Merkel_EvaporationLossMode)Enum.Parse(typeof(CoolingTower_VariableSpeed_Merkel_EvaporationLossMode), "LossFactor");
        

[Description(@"Rate of water evaporated from the cooling tower and lost to the outdoor air [%/K] Evaporation loss is calculated as percentage of the circulating condenser water rate Value entered here is percent-per-degree K of temperature drop in the condenser water Typical values are from 0.15 to 0.27 [%/K].")]
[JsonProperty(PropertyName="evaporation_loss_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvaporationLossFactor { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[Description("Rate of drift loss as a percentage of circulating condenser water flow rate Typic" +
    "al values are between 0.002 and 0.2% The default value is 0.008%")]
[JsonProperty(PropertyName="drift_loss_percent", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DriftLossPercent { get; set; } = Double.Parse("0.008", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="blowdown_calculation_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CoolingTower_VariableSpeed_Merkel_BlowdownCalculationMode BlowdownCalculationMode { get; set; } = (CoolingTower_VariableSpeed_Merkel_BlowdownCalculationMode)Enum.Parse(typeof(CoolingTower_VariableSpeed_Merkel_BlowdownCalculationMode), "ConcentrationRatio");
        

[Description(@"Characterizes the rate of blowdown in the cooling tower. Blowdown is water intentionally drained from the tower in order to offset the build up of solids in the water that would otherwise occur because of evaporation. Ratio of solids in the blowdown water to solids in the make up water. Typical values for tower operation are 3 to 5. The default value is 3.")]
[JsonProperty(PropertyName="blowdown_concentration_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BlowdownConcentrationRatio { get; set; } = Double.Parse("3", CultureInfo.InvariantCulture);
        

[Description(@"Makeup water usage due to blowdown results from occasionally draining some amount of water in the tower basin to purge scale or other contaminants to reduce their concentration in order to maintain an acceptable level of water quality. Schedule values should reflect water usage in m3/s.")]
[JsonProperty(PropertyName="blowdown_makeup_water_usage_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BlowdownMakeupWaterUsageScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="supply_water_storage_tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyWaterStorageTankName { get; set; } = "";
        

[Description("Enter the name of an outdoor air node")]
[JsonProperty(PropertyName="outdoor_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="number_of_cells", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfCells { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cell_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CoolingTower_VariableSpeed_Merkel_CellControl CellControl { get; set; } = (CoolingTower_VariableSpeed_Merkel_CellControl)Enum.Parse(typeof(CoolingTower_VariableSpeed_Merkel_CellControl), "MinimalCell");
        

[Description("The allowable minimal fraction of the nominal flow rate per cell")]
[JsonProperty(PropertyName="cell_minimum_water_flow_rate_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CellMinimumWaterFlowRateFraction { get; set; } = Double.Parse("0.33", CultureInfo.InvariantCulture);
        

[Description("The allowable maximal fraction of the nominal flow rate per cell")]
[JsonProperty(PropertyName="cell_maximum_water_flow_rate_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CellMaximumWaterFlowRateFraction { get; set; } = Double.Parse("2.5", CultureInfo.InvariantCulture);
        

[Description("Multiplies the autosized capacity and flow rates")]
[JsonProperty(PropertyName="sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SizingFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    public enum CoolingTower_VariableSpeed_Merkel_PerformanceInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="NominalCapacity")]
        NominalCapacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UFactorTimesAreaAndDesignWaterFlowRate")]
        UFactorTimesAreaAndDesignWaterFlowRate = 2,
    }
    
    public enum CoolingTower_VariableSpeed_Merkel_EvaporationLossMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="LossFactor")]
        LossFactor = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SaturatedExit")]
        SaturatedExit = 1,
    }
    
    public enum CoolingTower_VariableSpeed_Merkel_BlowdownCalculationMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="ConcentrationRatio")]
        ConcentrationRatio = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ScheduledRate")]
        ScheduledRate = 1,
    }
    
    public enum CoolingTower_VariableSpeed_Merkel_CellControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MaximalCell")]
        MaximalCell = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="MinimalCell")]
        MinimalCell = 2,
    }
    
    [Description(@"This open wet tower model is based on purely empirical algorithms derived from manufacturer's performance data or field measurements. The user can select from two existing algorithms (CoolTools or YorkCalc), or they can enter their own correlation for approach temperature by using a variable speed tower model coefficient object. For a multi-cell tower, the capacity and air/water flow rate inputs are for the entire tower.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class CoolingTower_VariableSpeed
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Name of tower water inlet node")]
[JsonProperty(PropertyName="water_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterInletNodeName { get; set; } = "";
        

[Description("Name of tower water outlet node")]
[JsonProperty(PropertyName="water_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterOutletNodeName { get; set; } = "";
        

[Description("Determines the coefficients and form of the equation for calculating approach tem" +
    "perature")]
[JsonProperty(PropertyName="model_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CoolingTower_VariableSpeed_ModelType ModelType { get; set; } = (CoolingTower_VariableSpeed_ModelType)Enum.Parse(typeof(CoolingTower_VariableSpeed_ModelType), "YorkCalc");
        

[Description("Name of the tower model coefficient object. Used only when tower Model Type is ei" +
    "ther CoolToolsUserDefined or YorkCalcUserDefined.")]
[JsonProperty(PropertyName="model_coefficient_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ModelCoefficientName { get; set; } = "";
        

[Description("Enter the tower\'s design inlet air wet-bulb temperature")]
[JsonProperty(PropertyName="design_inlet_air_wet_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignInletAirWetBulbTemperature { get; set; } = Double.Parse("25.6", CultureInfo.InvariantCulture);
        

[Description("Enter the approach temperature corresponding to the design inlet air wet-bulb tem" +
    "perature and design range temperature. Design approach temp = outlet water tempe" +
    "rature minus inlet air wet-bulb temperature at design conditions.")]
[JsonProperty(PropertyName="design_approach_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignApproachTemperature { get; set; } = Double.Parse("3.9", CultureInfo.InvariantCulture);
        

[Description("Enter the range temperature corresponding to the design inlet air wet-bulb temper" +
    "ature and design approach temperature. Design range = inlet water temperature mi" +
    "nus outlet water temperature at design conditions.")]
[JsonProperty(PropertyName="design_range_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignRangeTemperature { get; set; } = Double.Parse("5.6", CultureInfo.InvariantCulture);
        

[Description("Water flow rate through the tower at design conditions")]
[JsonProperty(PropertyName="design_water_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignWaterFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Design (maximum) air flow rate through the tower")]
[JsonProperty(PropertyName="design_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the fan motor electric input power at design (max) air flow through the tow" +
    "er Standard conversion for horsepower is 1 HP = 745.7 W")]
[JsonProperty(PropertyName="design_fan_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignFanPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("FPR = a + b*AFR + c*AFR**2 + d*AFR**3 FPR = fraction of the design fan power AFR " +
    "= fraction of the design air flow rate If left blank, then fan power is assumed " +
    "to be proportional to (air flow rate ratio)^3")]
[JsonProperty(PropertyName="fan_power_ratio_function_of_air_flow_rate_ratio_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FanPowerRatioFunctionOfAirFlowRateRatioCurveName { get; set; } = "";
        

[Description("Enter the minimum air flow rate ratio. This is typically determined by the variab" +
    "le speed drive that controls the fan motor speed. Valid entries are from 0.2 to " +
    "0.5.")]
[JsonProperty(PropertyName="minimum_air_flow_rate_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumAirFlowRateRatio { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[Description(@"Enter the fraction of tower capacity in the free convection regime. This is the fraction of the tower capacity, at the current inlet air wet-bulb temperature, that is available when the tower fan is off. Manufacturers typically estimate the free convection capacity at approximately 10-15%. Values are entered as a fraction and can range from 0 to 0.2.")]
[JsonProperty(PropertyName="fraction_of_tower_capacity_in_free_convection_regime", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfTowerCapacityInFreeConvectionRegime { get; set; } = Double.Parse("0.125", CultureInfo.InvariantCulture);
        

[Description("This heater maintains the basin water temperature at the basin heater setpoint te" +
    "mperature when the outdoor air temperature falls below the setpoint temperature." +
    " The basin heater only operates when water is not flowing through the tower.")]
[JsonProperty(PropertyName="basin_heater_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BasinHeaterCapacity { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Enter the outdoor dry-bulb temperature when the basin heater turns on")]
[JsonProperty(PropertyName="basin_heater_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BasinHeaterSetpointTemperature { get; set; } = Double.Parse("2", CultureInfo.InvariantCulture);
        

[Description(@"Schedule values greater than 0 allow the basin heater to operate whenever the outdoor air dry-bulb temperature is below the basin heater setpoint temperature. If a schedule name is not entered, the basin heater is allowed to operate throughout the entire simulation.")]
[JsonProperty(PropertyName="basin_heater_operating_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BasinHeaterOperatingScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="evaporation_loss_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CoolingTower_VariableSpeed_EvaporationLossMode EvaporationLossMode { get; set; } = (CoolingTower_VariableSpeed_EvaporationLossMode)Enum.Parse(typeof(CoolingTower_VariableSpeed_EvaporationLossMode), "LossFactor");
        

[Description(@"Rate of water evaporated from the cooling tower and lost to the outdoor air [%/K] Evaporation loss is calculated as percentage of the circulating condenser water rate Value entered here is percent-per-degree K of temperature drop in the condenser water Typical values are from 0.15 to 0.27 [percent/K].")]
[JsonProperty(PropertyName="evaporation_loss_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvaporationLossFactor { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[Description("Rate of drift loss as a percentage of circulating condenser water flow rate Typic" +
    "al values are between 0.002 and 0.2% The default value is 0.008%")]
[JsonProperty(PropertyName="drift_loss_percent", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DriftLossPercent { get; set; } = null;
        

[JsonProperty(PropertyName="blowdown_calculation_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CoolingTower_VariableSpeed_BlowdownCalculationMode BlowdownCalculationMode { get; set; } = (CoolingTower_VariableSpeed_BlowdownCalculationMode)Enum.Parse(typeof(CoolingTower_VariableSpeed_BlowdownCalculationMode), "ConcentrationRatio");
        

[Description(@"Characterizes the rate of blowdown in the cooling tower. Blowdown is water intentionally drained from the tower in order to offset the build up of solids in the water that would otherwise occur because of evaporation. Ratio of solids in the blowdown water to solids in the make up water. Typical values for tower operation are 3 to 5. The default value is 3.")]
[JsonProperty(PropertyName="blowdown_concentration_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BlowdownConcentrationRatio { get; set; } = Double.Parse("3", CultureInfo.InvariantCulture);
        

[Description(@"Makeup water usage due to blowdown results from occasionally draining a small amount of water in the tower basin to purge scale or other contaminants to reduce their concentration in order to maintain an acceptable level of water quality. Schedule values should reflect water usage in m3/s.")]
[JsonProperty(PropertyName="blowdown_makeup_water_usage_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BlowdownMakeupWaterUsageScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="supply_water_storage_tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyWaterStorageTankName { get; set; } = "";
        

[Description("Enter the name of an outdoor air node")]
[JsonProperty(PropertyName="outdoor_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="number_of_cells", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfCells { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cell_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CoolingTower_VariableSpeed_CellControl CellControl { get; set; } = (CoolingTower_VariableSpeed_CellControl)Enum.Parse(typeof(CoolingTower_VariableSpeed_CellControl), "MinimalCell");
        

[Description("The allowable minimal fraction of the nominal flow rate per cell")]
[JsonProperty(PropertyName="cell_minimum_water_flow_rate_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CellMinimumWaterFlowRateFraction { get; set; } = Double.Parse("0.33", CultureInfo.InvariantCulture);
        

[Description("The allowable maximal fraction of the nominal flow rate per cell")]
[JsonProperty(PropertyName="cell_maximum_water_flow_rate_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CellMaximumWaterFlowRateFraction { get; set; } = Double.Parse("2.5", CultureInfo.InvariantCulture);
        

[Description("Multiplies the autosized capacity and flow rates")]
[JsonProperty(PropertyName="sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SizingFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    public enum CoolingTower_VariableSpeed_ModelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolToolsCrossFlow")]
        CoolToolsCrossFlow = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolToolsUserDefined")]
        CoolToolsUserDefined = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="YorkCalc")]
        YorkCalc = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="YorkCalcUserDefined")]
        YorkCalcUserDefined = 4,
    }
    
    public enum CoolingTower_VariableSpeed_EvaporationLossMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="LossFactor")]
        LossFactor = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SaturatedExit")]
        SaturatedExit = 1,
    }
    
    public enum CoolingTower_VariableSpeed_BlowdownCalculationMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="ConcentrationRatio")]
        ConcentrationRatio = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ScheduledRate")]
        ScheduledRate = 1,
    }
    
    public enum CoolingTower_VariableSpeed_CellControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MaximalCell")]
        MaximalCell = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="MinimalCell")]
        MinimalCell = 2,
    }
    
    [Description("This object is used to define coefficients for the approach temperature correlati" +
        "on for a variable speed cooling tower when tower Model Type is specified as Cool" +
        "ToolsUserDefined in the object CoolingTower:VariableSpeed.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class CoolingTowerPerformance_CoolTools
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Minimum valid inlet air wet-bulb temperature for this approach temperature correl" +
    "ation.")]
[JsonProperty(PropertyName="minimum_inlet_air_wet_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumInletAirWetBulbTemperature { get; set; } = null;
        

[Description("Maximum valid inlet air wet-bulb temperature for this approach temperature correl" +
    "ation.")]
[JsonProperty(PropertyName="maximum_inlet_air_wet_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumInletAirWetBulbTemperature { get; set; } = null;
        

[Description("Minimum valid range temperature for this approach temperature correlation.")]
[JsonProperty(PropertyName="minimum_range_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumRangeTemperature { get; set; } = null;
        

[Description("Maximum valid range temperature for this approach temperature correlation.")]
[JsonProperty(PropertyName="maximum_range_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumRangeTemperature { get; set; } = null;
        

[Description("Minimum valid approach temperature for this correlation.")]
[JsonProperty(PropertyName="minimum_approach_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumApproachTemperature { get; set; } = null;
        

[Description("Maximum valid approach temperature for this correlation.")]
[JsonProperty(PropertyName="maximum_approach_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumApproachTemperature { get; set; } = null;
        

[Description("Minimum valid water flow rate ratio for this approach temperature correlation.")]
[JsonProperty(PropertyName="minimum_water_flow_rate_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumWaterFlowRateRatio { get; set; } = null;
        

[Description("Maximum valid water flow rate ratio for this approach temperature correlation.")]
[JsonProperty(PropertyName="maximum_water_flow_rate_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumWaterFlowRateRatio { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient4 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient5 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient6 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient7 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient8 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient9 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient10 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_11", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient11 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_12", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient12 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_13", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient13 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_14", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient14 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_15", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient15 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_16", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient16 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_17", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient17 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_18", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient18 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_19", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient19 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_20", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient20 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_21", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient21 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_22", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient22 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_23", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient23 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_24", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient24 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_25", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient25 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_26", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient26 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_27", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient27 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_28", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient28 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_29", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient29 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_30", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient30 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_31", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient31 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_32", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient32 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_33", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient33 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_34", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient34 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_35", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient35 { get; set; } = null;
    }
    
    [Description("This object is used to define coefficients for the approach temperature correlati" +
        "on for a variable speed cooling tower when tower Model Type is specified as York" +
        "CalcUserDefined in the object CoolingTower:VariableSpeed.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class CoolingTowerPerformance_YorkCalc
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Minimum valid inlet air wet-bulb temperature for this approach temperature correl" +
    "ation.")]
[JsonProperty(PropertyName="minimum_inlet_air_wet_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumInletAirWetBulbTemperature { get; set; } = null;
        

[Description("Maximum valid inlet air wet-bulb temperature for this approach temperature correl" +
    "ation.")]
[JsonProperty(PropertyName="maximum_inlet_air_wet_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumInletAirWetBulbTemperature { get; set; } = null;
        

[Description("Minimum valid range temperature for this approach temperature correlation.")]
[JsonProperty(PropertyName="minimum_range_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumRangeTemperature { get; set; } = null;
        

[Description("Maximum valid range temperature for this approach temperature correlation.")]
[JsonProperty(PropertyName="maximum_range_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumRangeTemperature { get; set; } = null;
        

[Description("Minimum valid approach temperature for this correlation.")]
[JsonProperty(PropertyName="minimum_approach_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumApproachTemperature { get; set; } = null;
        

[Description("Maximum valid approach temperature for this correlation.")]
[JsonProperty(PropertyName="maximum_approach_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumApproachTemperature { get; set; } = null;
        

[Description("Minimum valid water flow rate ratio for this approach temperature correlation.")]
[JsonProperty(PropertyName="minimum_water_flow_rate_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumWaterFlowRateRatio { get; set; } = null;
        

[Description("Maximum valid water flow rate ratio for this approach temperature correlation.")]
[JsonProperty(PropertyName="maximum_water_flow_rate_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumWaterFlowRateRatio { get; set; } = null;
        

[Description("Maximum liquid (water) to gas (air) ratio for this approach temperature correlati" +
    "on.")]
[JsonProperty(PropertyName="maximum_liquid_to_gas_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumLiquidToGasRatio { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient4 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient5 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient6 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient7 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient8 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient9 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient10 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_11", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient11 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_12", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient12 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_13", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient13 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_14", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient14 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_15", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient15 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_16", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient16 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_17", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient17 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_18", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient18 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_19", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient19 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_20", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient20 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_21", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient21 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_22", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient22 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_23", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient23 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_24", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient24 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_25", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient25 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_26", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient26 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient_27", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient27 { get; set; } = null;
    }
    
    [Description("This model is based on Merkel\'s theory, which is also the basis for the cooling t" +
        "ower model in EnergyPlus. The Evaporative fluid cooler is modeled as a counter f" +
        "low heat exchanger.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class EvaporativeFluidCooler_SingleSpeed
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Name of Fluid Cooler water inlet node")]
[JsonProperty(PropertyName="water_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterInletNodeName { get; set; } = "";
        

[Description("Name of Fluid Cooler water outlet node")]
[JsonProperty(PropertyName="water_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="design_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This is the fan motor electric input power")]
[JsonProperty(PropertyName="design_air_flow_rate_fan_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignAirFlowRateFanPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="design_spray_water_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignSprayWaterFlowRate { get; set; } = null;
        

[Description("User can define fluid cooler thermal performance by specifying the fluid cooler U" +
    "A and the Design Water Flow Rate, or by specifying the fluid cooler Standard Des" +
    "ign Capacity or by specifying Design Capacity for Non standard conditions.")]
[JsonProperty(PropertyName="performance_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EvaporativeFluidCooler_SingleSpeed_PerformanceInputMethod PerformanceInputMethod { get; set; } = (EvaporativeFluidCooler_SingleSpeed_PerformanceInputMethod)Enum.Parse(typeof(EvaporativeFluidCooler_SingleSpeed_PerformanceInputMethod), "StandardDesignCapacity");
        

[Description("Enter the name of an outdoor air node")]
[JsonProperty(PropertyName="outdoor_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="heat_rejection_capacity_and_nominal_capacity_sizing_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatRejectionCapacityAndNominalCapacitySizingRatio { get; set; } = Double.Parse("1.25", CultureInfo.InvariantCulture);
        

[Description(@"Standard design capacity with entering water at 35C (95F), leaving water at 29.44C (85F), entering air at 25.56C (78F) wet-bulb temperature and 35C (95F) dry-bulb temperature. Design water flow rate assumed to be 5.382E-8 m3/s per watt (3 gpm/ton). Standard design capacity times the Heat Rejection Capacity and Nominal Capacity Sizing Ratio (e.g. 1.25) gives the actual fluid cooler heat rejection at these operating conditions. Only used for Performance Input Method = StandardDesignCapacity; for other input methods, this field is ignored. The standard conditions mentioned above for Standard design capacity are already specified in the EnergyPlus. So the input fields such as design entering water temp., design entering air wet-bulb and dry-bulb temp. and design water flow rate, if provided in the input, will be ignored for the StandardDesignCapacity performance input method. Also, the standard conditions are for water as a fluid type so this performance input method can only be used with water as a fluid type (as specified in CondenserLoop object).")]
[JsonProperty(PropertyName="standard_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StandardDesignCapacity { get; set; } = null;
        

[Description("Only used for Performance Input Method = UFactorTimesAreaAndDesignWaterFlowRate; " +
    "for other Performance Input Methods, this field is ignored.")]
[JsonProperty(PropertyName="design_air_flow_rate_u_factor_times_area_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignAirFlowRateUFactorTimesAreaValue { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Input value is ignored if fluid cooler Performance Input Method= StandardDesignCa" +
    "pacity.")]
[JsonProperty(PropertyName="design_water_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignWaterFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Only used for Performance Input Method = UserSpecifiedDesignCapacity; for other P" +
    "erformance Input Methods, this field is ignored.")]
[JsonProperty(PropertyName="user_specified_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> UserSpecifiedDesignCapacity { get; set; } = null;
        

[Description("Only used for Performance Input Method = UserSpecifiedDesignCapacity; for other P" +
    "erformance Input Methods, this field is ignored. Design Entering Water Temperatu" +
    "re must be greater than Design Entering Air Temperature.")]
[JsonProperty(PropertyName="design_entering_water_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignEnteringWaterTemperature { get; set; } = null;
        

[Description("Only used for Performance Input Method = UserSpecifiedDesignCapacity; for other P" +
    "erformance Input Methods, this field is ignored. Design Entering Air Temperature" +
    " must be greater than Design Entering Air Wet-bulb Temperature.")]
[JsonProperty(PropertyName="design_entering_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignEnteringAirTemperature { get; set; } = null;
        

[Description("Only used for Performance Input Method = UserSpecifiedDesignCapacity; for other P" +
    "erformance Input Methods, this field is ignored. Design Entering Air Wet-bulb Te" +
    "mperature must be less than Design Entering Air Temperature.")]
[JsonProperty(PropertyName="design_entering_air_wet_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignEnteringAirWetBulbTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="capacity_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EvaporativeFluidCooler_SingleSpeed_CapacityControl CapacityControl { get; set; } = (EvaporativeFluidCooler_SingleSpeed_CapacityControl)Enum.Parse(typeof(EvaporativeFluidCooler_SingleSpeed_CapacityControl), "FanCycling");
        

[Description("Multiplies the autosized capacity and flow rates")]
[JsonProperty(PropertyName="sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SizingFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="evaporation_loss_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EvaporativeFluidCooler_SingleSpeed_EvaporationLossMode EvaporationLossMode { get; set; } = (EvaporativeFluidCooler_SingleSpeed_EvaporationLossMode)Enum.Parse(typeof(EvaporativeFluidCooler_SingleSpeed_EvaporationLossMode), "SaturatedExit");
        

[Description("Rate of water evaporation from the Fluid Cooler and lost to the outdoor air [%/K]" +
    " Empirical correlation is used to calculate default loss factor if it not explic" +
    "itly provided.")]
[JsonProperty(PropertyName="evaporation_loss_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvaporationLossFactor { get; set; } = null;
        

[Description("Rate of drift loss as a percentage of circulating spray water flow rate Default v" +
    "alue for this field is under investigation. For now Cooling tower\'s drift loss p" +
    "ercent default value is taken here.")]
[JsonProperty(PropertyName="drift_loss_percent", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DriftLossPercent { get; set; } = Double.Parse("0.008", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="blowdown_calculation_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EvaporativeFluidCooler_SingleSpeed_BlowdownCalculationMode BlowdownCalculationMode { get; set; } = (EvaporativeFluidCooler_SingleSpeed_BlowdownCalculationMode)Enum.Parse(typeof(EvaporativeFluidCooler_SingleSpeed_BlowdownCalculationMode), "ConcentrationRatio");
        

[Description(@"Characterizes the rate of blowdown in the Evaporative Fluid Cooler. Blowdown is water intentionally drained from the basin in order to offset the build up of solids in the water that would otherwise occur because of evaporation. Ratio of solids in the blowdown water to solids in the make up water. Default value for this field is under investigation. For now Cooling tower's Blowdown Concentration Ratio percent default value is taken here.")]
[JsonProperty(PropertyName="blowdown_concentration_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BlowdownConcentrationRatio { get; set; } = Double.Parse("3", CultureInfo.InvariantCulture);
        

[Description(@"Makeup water usage due to blowdown results from occasionally draining a small amount of water in the Fluid Cooler basin to purge scale or other contaminants to reduce their concentration in order to maintain an acceptable level of water quality. Schedule values should reflect water usage in m3/s.")]
[JsonProperty(PropertyName="blowdown_makeup_water_usage_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BlowdownMakeupWaterUsageScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="supply_water_storage_tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyWaterStorageTankName { get; set; } = "";
    }
    
    public enum EvaporativeFluidCooler_SingleSpeed_PerformanceInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="StandardDesignCapacity")]
        StandardDesignCapacity = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="UFactorTimesAreaAndDesignWaterFlowRate")]
        UFactorTimesAreaAndDesignWaterFlowRate = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UserSpecifiedDesignCapacity")]
        UserSpecifiedDesignCapacity = 2,
    }
    
    public enum EvaporativeFluidCooler_SingleSpeed_CapacityControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FanCycling")]
        FanCycling = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FluidBypass")]
        FluidBypass = 2,
    }
    
    public enum EvaporativeFluidCooler_SingleSpeed_EvaporationLossMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="LossFactor")]
        LossFactor = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SaturatedExit")]
        SaturatedExit = 2,
    }
    
    public enum EvaporativeFluidCooler_SingleSpeed_BlowdownCalculationMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ConcentrationRatio")]
        ConcentrationRatio = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ScheduledRate")]
        ScheduledRate = 2,
    }
    
    [Description("This model is based on Merkel\'s theory, which is also the basis for the cooling t" +
        "ower model in EnergyPlus. The Evaporative fluid cooler is modeled as a counter f" +
        "low heat exchanger.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class EvaporativeFluidCooler_TwoSpeed
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Name of fluid cooler water inlet node")]
[JsonProperty(PropertyName="water_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterInletNodeName { get; set; } = "";
        

[Description("Name of fluid cooler water outlet node")]
[JsonProperty(PropertyName="water_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="high_fan_speed_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HighFanSpeedAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This is the fan motor electric input power at high speed")]
[JsonProperty(PropertyName="high_fan_speed_fan_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HighFanSpeedFanPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Low speed air flow rate must be less than high speed air flow rate")]
[JsonProperty(PropertyName="low_fan_speed_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> LowFanSpeedAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used if the previous field is set to autocalculate")]
[JsonProperty(PropertyName="low_fan_speed_air_flow_rate_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LowFanSpeedAirFlowRateSizingFactor { get; set; } = Double.Parse("0.5", CultureInfo.InvariantCulture);
        

[Description("This is the fan motor electric input power at low speed")]
[JsonProperty(PropertyName="low_fan_speed_fan_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> LowFanSpeedFanPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used if the previous field is set to autocalculate.")]
[JsonProperty(PropertyName="low_fan_speed_fan_power_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LowFanSpeedFanPowerSizingFactor { get; set; } = Double.Parse("0.16", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="design_spray_water_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignSprayWaterFlowRate { get; set; } = null;
        

[Description("User can define fluid cooler thermal performance by specifying the fluid cooler U" +
    "A and the Design Water Flow Rate, or by specifying the fluid cooler Standard Des" +
    "ign Capacity or by specifying Design Capacity for Non standard conditions.")]
[JsonProperty(PropertyName="performance_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EvaporativeFluidCooler_TwoSpeed_PerformanceInputMethod PerformanceInputMethod { get; set; } = (EvaporativeFluidCooler_TwoSpeed_PerformanceInputMethod)Enum.Parse(typeof(EvaporativeFluidCooler_TwoSpeed_PerformanceInputMethod), "StandardDesignCapacity");
        

[Description("Enter the name of an outdoor air node")]
[JsonProperty(PropertyName="outdoor_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="heat_rejection_capacity_and_nominal_capacity_sizing_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatRejectionCapacityAndNominalCapacitySizingRatio { get; set; } = Double.Parse("1.25", CultureInfo.InvariantCulture);
        

[Description(@"Standard design capacity with entering water at 35C (95F), leaving water at 29.44C (85F), entering air at 25.56C (78F) wet-bulb temperature and 35C (95F) dry-bulb temperature. Design water flow rate assumed to be 5.382E-8 m3/s per watt (3 gpm/ton). Standard design capacity times the Heat Rejection Capacity and Nominal Capacity Sizing Ratio (e.g. 1.25) gives the actual fluid cooler heat rejection at these operating conditions. Only used for Performance Input Method = StandardDesignCapacity; for other input methods, this field is ignored. The standard conditions mentioned above for Standard design capacity are already specified in the EnergyPlus. So the input fields such as design entering water temp., design entering air wet-bulb and dry-bulb temp. and design water flow rate, if provided in the input, will be ignored for the StandardDesignCapacity performance input method. Also, the standard conditions are for water as a fluid type so this performance input method can only be used with water as a fluid type (as specified in CondenserLoop object).")]
[JsonProperty(PropertyName="high_speed_standard_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HighSpeedStandardDesignCapacity { get; set; } = null;
        

[Description(@"Standard design capacity with entering water at 35C (95F), leaving water at 29.44C (85F), entering air at 25.56C (78F) wet-bulb temperature and 35C (95F) dry-bulb temperature. Design water flow rate assumed to be 5.382E-8 m3/s per watt (3 gpm/ton). Standard design capacity times the Heat Rejection Capacity and Nominal Capacity Sizing Ratio (e.g. 1.25) gives the actual fluid cooler heat rejection at these operating conditions. Only used for Performance Input Method = StandardDesignCapacity; for other input methods, this field is ignored. The standard conditions mentioned above for Standard design capacity are already specified in the EnergyPlus. So the input fields such as design entering water temp., design entering air wet-bulb and dry-bulb temp. and design water flow rate, if provided in the input, will be ignored for the StandardDesignCapacity performance input method. Also, the standard conditions are for water as a fluid type so this performance input method can only be used with water as a fluid type (as specified in CondenserLoop object).")]
[JsonProperty(PropertyName="low_speed_standard_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> LowSpeedStandardDesignCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used if the previous field is set to autocalculate")]
[JsonProperty(PropertyName="low_speed_standard_capacity_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LowSpeedStandardCapacitySizingFactor { get; set; } = Double.Parse("0.5", CultureInfo.InvariantCulture);
        

[Description("Only used for Performance Input Method = UFactorTimesAreaAndDesignWaterFlowRate; " +
    "for other Performance Input Methods, this field is ignored.")]
[JsonProperty(PropertyName="high_fan_speed_u_factor_times_area_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HighFanSpeedUFactorTimesAreaValue { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Only used for Performance Input Method = UFactorTimesAreaAndDesignWaterFlowRate; " +
    "for other input methods, this field is ignored. Low speed fluid cooler UA must b" +
    "e less than high speed fluid cooler UA")]
[JsonProperty(PropertyName="low_fan_speed_u_factor_times_area_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> LowFanSpeedUFactorTimesAreaValue { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used if the previous field is set to autocalculate and the Per" +
    "formance Input Method is UFactorTimesAreaAndDesignWaterFlowRate")]
[JsonProperty(PropertyName="low_fan_speed_u_factor_times_area_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LowFanSpeedUFactorTimesAreaSizingFactor { get; set; } = Double.Parse("0.6", CultureInfo.InvariantCulture);
        

[Description("Input value is ignored if fluid cooler Performance Input Method= StandardDesignCa" +
    "pacity")]
[JsonProperty(PropertyName="design_water_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignWaterFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Only used for Performance Input Method = UserSpecifiedDesignCapacity; for other P" +
    "erformance Input Methods, this field is ignored.")]
[JsonProperty(PropertyName="high_speed_user_specified_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HighSpeedUserSpecifiedDesignCapacity { get; set; } = null;
        

[Description("Only used for Performance Input Method = UserSpecifiedDesignCapacity; for other P" +
    "erformance Input Methods, this field is ignored.")]
[JsonProperty(PropertyName="low_speed_user_specified_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> LowSpeedUserSpecifiedDesignCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used if the previous field is set to autocalculate")]
[JsonProperty(PropertyName="low_speed_user_specified_design_capacity_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LowSpeedUserSpecifiedDesignCapacitySizingFactor { get; set; } = Double.Parse("0.5", CultureInfo.InvariantCulture);
        

[Description("Only used for Performance Input Method = UserSpecifiedDesignCapacity; for other P" +
    "erformance Input Methods, this field is ignored. Design Entering Water Temperatu" +
    "re must be greater than Design Entering Air Temperature.")]
[JsonProperty(PropertyName="design_entering_water_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignEnteringWaterTemperature { get; set; } = null;
        

[Description("Only used for Performance Input Method = UserSpecifiedDesignCapacity; for other P" +
    "erformance Input Methods, this field is ignored. Design Entering Air Temperature" +
    " must be greater than Design Entering Air Wet-bulb Temperature.")]
[JsonProperty(PropertyName="design_entering_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignEnteringAirTemperature { get; set; } = null;
        

[Description("Only used for Performance Input Method = UserSpecifiedDesignCapacity; for other P" +
    "erformance Input Methods, this field is ignored. Design Entering Air Wet-bulb Te" +
    "mperature must be less than Design Entering Air Temperature.")]
[JsonProperty(PropertyName="design_entering_air_wet_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignEnteringAirWetBulbTemperature { get; set; } = null;
        

[Description("Multiplies the autosized capacity and flow rates")]
[JsonProperty(PropertyName="high_speed_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HighSpeedSizingFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="evaporation_loss_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EvaporativeFluidCooler_TwoSpeed_EvaporationLossMode EvaporationLossMode { get; set; } = (EvaporativeFluidCooler_TwoSpeed_EvaporationLossMode)Enum.Parse(typeof(EvaporativeFluidCooler_TwoSpeed_EvaporationLossMode), "SaturatedExit");
        

[Description("Rate of water evaporation from the Fluid Cooler and lost to the outdoor air [%/K]" +
    " Empirical correlation is used to calculate default loss factor if it not explic" +
    "itly provided.")]
[JsonProperty(PropertyName="evaporation_loss_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvaporationLossFactor { get; set; } = null;
        

[Description("Default value is under investigation. For now cooling tower\'s default value is ta" +
    "ken.")]
[JsonProperty(PropertyName="drift_loss_percent", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DriftLossPercent { get; set; } = Double.Parse("0.008", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="blowdown_calculation_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EvaporativeFluidCooler_TwoSpeed_BlowdownCalculationMode BlowdownCalculationMode { get; set; } = (EvaporativeFluidCooler_TwoSpeed_BlowdownCalculationMode)Enum.Parse(typeof(EvaporativeFluidCooler_TwoSpeed_BlowdownCalculationMode), "ConcentrationRatio");
        

[Description(@"Characterizes the rate of blowdown in the Evaporative Fluid Cooler. Blowdown is water intentionally drained from the Evaporative Fluid Cooler in order to offset the build up of solids in the water that would otherwise occur because of evaporation. Ratio of solids in the blowdown water to solids in the make up water. Default value is under investigation. For now cooling tower's default value is taken.")]
[JsonProperty(PropertyName="blowdown_concentration_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BlowdownConcentrationRatio { get; set; } = Double.Parse("3", CultureInfo.InvariantCulture);
        

[Description(@"Makeup water usage due to blowdown results from occasionally draining some amount of water in the Evaporative Fluid Cooler basin to purge scale or other contaminants to reduce their concentration in order to maintain an acceptable level of water quality. Schedule values should reflect water usage in m3/s.")]
[JsonProperty(PropertyName="blowdown_makeup_water_usage_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BlowdownMakeupWaterUsageScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="supply_water_storage_tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyWaterStorageTankName { get; set; } = "";
    }
    
    public enum EvaporativeFluidCooler_TwoSpeed_PerformanceInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="StandardDesignCapacity")]
        StandardDesignCapacity = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="UFactorTimesAreaAndDesignWaterFlowRate")]
        UFactorTimesAreaAndDesignWaterFlowRate = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UserSpecifiedDesignCapacity")]
        UserSpecifiedDesignCapacity = 2,
    }
    
    public enum EvaporativeFluidCooler_TwoSpeed_EvaporationLossMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="LossFactor")]
        LossFactor = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SaturatedExit")]
        SaturatedExit = 2,
    }
    
    public enum EvaporativeFluidCooler_TwoSpeed_BlowdownCalculationMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ConcentrationRatio")]
        ConcentrationRatio = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ScheduledRate")]
        ScheduledRate = 2,
    }
    
    [Description("The fluid cooler is modeled as a cross flow heat exchanger (both streams unmixed)" +
        " with single-speed fans (induced draft configuration).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class FluidCooler_SingleSpeed
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Name of fluid cooler water inlet node")]
[JsonProperty(PropertyName="water_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterInletNodeName { get; set; } = "";
        

[Description("Name of fluid cooler water outlet node")]
[JsonProperty(PropertyName="water_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterOutletNodeName { get; set; } = "";
        

[Description("User can define fluid cooler thermal performance by specifying the fluid cooler U" +
    "A and the Design Water Flow Rate, or by specifying the fluid cooler nominal capa" +
    "city")]
[JsonProperty(PropertyName="performance_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public FluidCooler_SingleSpeed_PerformanceInputMethod PerformanceInputMethod { get; set; } = (FluidCooler_SingleSpeed_PerformanceInputMethod)Enum.Parse(typeof(FluidCooler_SingleSpeed_PerformanceInputMethod), "NominalCapacity");
        

[Description("Leave field blank if fluid cooler Performance Input Method is NominalCapacity")]
[JsonProperty(PropertyName="design_air_flow_rate_u_factor_times_area_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignAirFlowRateUFactorTimesAreaValue { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Nominal fluid cooler capacity")]
[JsonProperty(PropertyName="nominal_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NominalCapacity { get; set; } = null;
        

[Description("Design Entering Water Temperature must be specified for both the performance inpu" +
    "t methods and its value must be greater than Design Entering Air Temperature.")]
[JsonProperty(PropertyName="design_entering_water_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignEnteringWaterTemperature { get; set; } = null;
        

[Description("Design Entering Air Temperature must be specified for both the performance input " +
    "methods and its value must be greater than Design Entering Air Wet-bulb Temperat" +
    "ure.")]
[JsonProperty(PropertyName="design_entering_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignEnteringAirTemperature { get; set; } = null;
        

[Description("Design Entering Air Wet-bulb Temperature must be specified for both the performan" +
    "ce input methods and its value must be less than Design Entering Air Temperature" +
    ".")]
[JsonProperty(PropertyName="design_entering_air_wetbulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignEnteringAirWetbulbTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="design_water_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignWaterFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="design_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This is the fan motor electric input power")]
[JsonProperty(PropertyName="design_air_flow_rate_fan_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignAirFlowRateFanPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the name of an outdoor air node")]
[JsonProperty(PropertyName="outdoor_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirInletNodeName { get; set; } = "";
    }
    
    public enum FluidCooler_SingleSpeed_PerformanceInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="NominalCapacity")]
        NominalCapacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UFactorTimesAreaAndDesignWaterFlowRate")]
        UFactorTimesAreaAndDesignWaterFlowRate = 2,
    }
    
    [Description("The fluid cooler is modeled as a cross flow heat exchanger (both streams unmixed)" +
        " with two-speed fans (induced draft configuration).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class FluidCooler_TwoSpeed
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Name of fluid cooler water inlet node")]
[JsonProperty(PropertyName="water_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterInletNodeName { get; set; } = "";
        

[Description("Name of fluid cooler water outlet node")]
[JsonProperty(PropertyName="water_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterOutletNodeName { get; set; } = "";
        

[Description("User can define fluid cooler thermal performance by specifying the fluid cooler U" +
    "A and the Design Water Flow Rate, or by specifying the fluid cooler nominal capa" +
    "city")]
[JsonProperty(PropertyName="performance_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public FluidCooler_TwoSpeed_PerformanceInputMethod PerformanceInputMethod { get; set; } = (FluidCooler_TwoSpeed_PerformanceInputMethod)Enum.Parse(typeof(FluidCooler_TwoSpeed_PerformanceInputMethod), "NominalCapacity");
        

[Description("Leave field blank if fluid cooler Performance Input Method is NominalCapacity")]
[JsonProperty(PropertyName="high_fan_speed_u_factor_times_area_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HighFanSpeedUFactorTimesAreaValue { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Leave field blank if fluid cooler Performance Input Method is NominalCapacity Low" +
    " speed fluid cooler UA must be less than high speed fluid cooler UA Low speed fl" +
    "uid cooler UA must be greater than free convection fluid cooler UA")]
[JsonProperty(PropertyName="low_fan_speed_u_factor_times_area_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> LowFanSpeedUFactorTimesAreaValue { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used if the previous field is set to autocalculate and the Per" +
    "formance Input Method is UFactorTimesAreaAndDesignWaterFlowRate")]
[JsonProperty(PropertyName="low_fan_speed_u_factor_times_area_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LowFanSpeedUFactorTimesAreaSizingFactor { get; set; } = Double.Parse("0.6", CultureInfo.InvariantCulture);
        

[Description("Nominal fluid cooler capacity at high fan speed")]
[JsonProperty(PropertyName="high_speed_nominal_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HighSpeedNominalCapacity { get; set; } = null;
        

[Description("Nominal fluid cooler capacity at low fan speed")]
[JsonProperty(PropertyName="low_speed_nominal_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> LowSpeedNominalCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used if the previous field is set to autocalculate and the Per" +
    "formance Input Method is NominalCapacity")]
[JsonProperty(PropertyName="low_speed_nominal_capacity_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LowSpeedNominalCapacitySizingFactor { get; set; } = Double.Parse("0.5", CultureInfo.InvariantCulture);
        

[Description("Design Entering Water Temperature must be specified for both the performance inpu" +
    "t methods and its value must be greater than Design Entering Air Temperature.")]
[JsonProperty(PropertyName="design_entering_water_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignEnteringWaterTemperature { get; set; } = null;
        

[Description("Design Entering Air Temperature must be specified for both the performance input " +
    "methods and its value must be greater than Design Entering Air Wet-bulb Temperat" +
    "ure.")]
[JsonProperty(PropertyName="design_entering_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignEnteringAirTemperature { get; set; } = null;
        

[Description("Design Entering Air Wet-bulb Temperature must be specified for both the performan" +
    "ce input methods and its value must be less than Design Entering Air Temperature" +
    ".")]
[JsonProperty(PropertyName="design_entering_air_wet_bulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignEnteringAirWetBulbTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="design_water_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignWaterFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Air Flow Rate at High Fan Speed must be greater than Air Flow Rate at Low Fan Spe" +
    "ed")]
[JsonProperty(PropertyName="high_fan_speed_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HighFanSpeedAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This is the fan motor electric input power at high speed")]
[JsonProperty(PropertyName="high_fan_speed_fan_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HighFanSpeedFanPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Air Flow Rate at Low Fan Speed must be less than Air Flow Rate at High Fan Speed")]
[JsonProperty(PropertyName="low_fan_speed_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> LowFanSpeedAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used if the previous field is set to autocalculate.")]
[JsonProperty(PropertyName="low_fan_speed_air_flow_rate_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LowFanSpeedAirFlowRateSizingFactor { get; set; } = Double.Parse("0.5", CultureInfo.InvariantCulture);
        

[Description("This is the fan motor electric input power at low speed")]
[JsonProperty(PropertyName="low_fan_speed_fan_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> LowFanSpeedFanPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is only used if the previous field is set to autocalculate.")]
[JsonProperty(PropertyName="low_fan_speed_fan_power_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LowFanSpeedFanPowerSizingFactor { get; set; } = Double.Parse("0.16", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="outdoor_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirInletNodeName { get; set; } = "";
    }
    
    public enum FluidCooler_TwoSpeed_PerformanceInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="NominalCapacity")]
        NominalCapacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UFactorTimesAreaAndDesignWaterFlowRate")]
        UFactorTimesAreaAndDesignWaterFlowRate = 2,
    }
    
    [Description("Models vertical ground heat exchangers systems using the response factor approach" +
        " developed by Eskilson. Response factors are calculated using a finite line sour" +
        "ce model assuming uniform heat flux at the borehole wall.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatExchanger_System
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignFlowRate { get; set; } = null;
        

[JsonProperty(PropertyName="undisturbed_ground_temperature_model_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public GroundHeatExchanger_System_UndisturbedGroundTemperatureModelType UndisturbedGroundTemperatureModelType { get; set; } = (GroundHeatExchanger_System_UndisturbedGroundTemperatureModelType)Enum.Parse(typeof(GroundHeatExchanger_System_UndisturbedGroundTemperatureModelType), "SiteGroundTemperatureUndisturbedFiniteDifference");
        

[JsonProperty(PropertyName="undisturbed_ground_temperature_model_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UndisturbedGroundTemperatureModelName { get; set; } = "";
        

[JsonProperty(PropertyName="ground_thermal_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GroundThermalConductivity { get; set; } = null;
        

[JsonProperty(PropertyName="ground_thermal_heat_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GroundThermalHeatCapacity { get; set; } = null;
        

[JsonProperty(PropertyName="ghe_vertical_responsefactors_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string GheVerticalResponsefactorsObjectName { get; set; } = "";
        

[JsonProperty(PropertyName="ghe_vertical_array_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string GheVerticalArrayObjectName { get; set; } = "";
        

[Description("This list is the GroundHeatExchangerVerticalSingleNames object-list")]
[JsonProperty(PropertyName="vertical_well_locations", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> VerticalWellLocations { get; set; } = null;
    }
    
    public enum GroundHeatExchanger_System_UndisturbedGroundTemperatureModelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:Undisturbed:FiniteDifference")]
        SiteGroundTemperatureUndisturbedFiniteDifference = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:Undisturbed:KusudaAchenbach")]
        SiteGroundTemperatureUndisturbedKusudaAchenbach = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:Undisturbed:Xing")]
        SiteGroundTemperatureUndisturbedXing = 2,
    }
    
    [Description("Properties for vertical ground heat exchanger systems")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatExchanger_Vertical_Properties
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="depth_of_top_of_borehole", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DepthOfTopOfBorehole { get; set; } = null;
        

[JsonProperty(PropertyName="borehole_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BoreholeLength { get; set; } = null;
        

[JsonProperty(PropertyName="borehole_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BoreholeDiameter { get; set; } = null;
        

[JsonProperty(PropertyName="grout_thermal_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GroutThermalConductivity { get; set; } = null;
        

[JsonProperty(PropertyName="grout_thermal_heat_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GroutThermalHeatCapacity { get; set; } = null;
        

[JsonProperty(PropertyName="pipe_thermal_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeThermalConductivity { get; set; } = null;
        

[JsonProperty(PropertyName="pipe_thermal_heat_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeThermalHeatCapacity { get; set; } = null;
        

[JsonProperty(PropertyName="pipe_outer_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeOuterDiameter { get; set; } = null;
        

[JsonProperty(PropertyName="pipe_thickness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeThickness { get; set; } = null;
        

[JsonProperty(PropertyName="u_tube_distance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> UTubeDistance { get; set; } = null;
    }
    
    [Description(null)]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatExchanger_Vertical_Array
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="ghe_vertical_properties_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string GheVerticalPropertiesObjectName { get; set; } = "";
        

[JsonProperty(PropertyName="number_of_boreholes_in_x_direction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfBoreholesInXDirection { get; set; } = null;
        

[JsonProperty(PropertyName="number_of_boreholes_in_y_direction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfBoreholesInYDirection { get; set; } = null;
        

[JsonProperty(PropertyName="borehole_spacing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BoreholeSpacing { get; set; } = null;
    }
    
    [Description(null)]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatExchanger_Vertical_Single
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="ghe_vertical_properties_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string GheVerticalPropertiesObjectName { get; set; } = "";
        

[JsonProperty(PropertyName="x_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> XLocation { get; set; } = null;
        

[JsonProperty(PropertyName="y_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> YLocation { get; set; } = null;
    }
    
    [Description("Response factor definitions from third-party tool, commonly referred to a \"g-func" +
        "tions\"")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatExchanger_ResponseFactors
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="ghe_vertical_properties_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string GheVerticalPropertiesObjectName { get; set; } = "";
        

[JsonProperty(PropertyName="number_of_boreholes", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfBoreholes { get; set; } = null;
        

[JsonProperty(PropertyName="g_function_reference_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GFunctionReferenceRatio { get; set; } = Double.Parse("0.0005", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="g_functions", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.GroundHeatExchanger_ResponseFactors_GFunctions_Item> GFunctions { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatExchanger_ResponseFactors_GFunctions_Item
    {
        

[JsonProperty(PropertyName="g_function_ln_t_ts_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GFunctionLnTTsValue { get; set; } = null;
        

[JsonProperty(PropertyName="g_function_g_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GFunctionGValue { get; set; } = null;
    }
    
    [Description("A model of a shallow pond with immersed pipe loops. Typically used in hybrid geot" +
        "hermal systems and included in the condenser loop. This component may also be us" +
        "ed as a simple solar collector.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatExchanger_Pond
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="fluid_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FluidInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="fluid_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FluidOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="pond_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PondDepth { get; set; } = null;
        

[JsonProperty(PropertyName="pond_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PondArea { get; set; } = null;
        

[JsonProperty(PropertyName="hydronic_tubing_inside_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HydronicTubingInsideDiameter { get; set; } = null;
        

[JsonProperty(PropertyName="hydronic_tubing_outside_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HydronicTubingOutsideDiameter { get; set; } = null;
        

[JsonProperty(PropertyName="hydronic_tubing_thermal_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HydronicTubingThermalConductivity { get; set; } = null;
        

[JsonProperty(PropertyName="ground_thermal_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GroundThermalConductivity { get; set; } = null;
        

[JsonProperty(PropertyName="number_of_tubing_circuits", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfTubingCircuits { get; set; } = null;
        

[JsonProperty(PropertyName="length_of_each_tubing_circuit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LengthOfEachTubingCircuit { get; set; } = null;
    }
    
    [Description(@"A hydronic surface/panel consisting of a multi-layer construction with embedded rows of tubes. Typically used in hybrid geothermal systems and included in the condenser loop. This component may also be used as a simple solar collector. The bottom surface may be defined as ground-coupled or exposed to wind (eg. bridge deck).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatExchanger_Surface
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[JsonProperty(PropertyName="fluid_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FluidInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="fluid_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FluidOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="hydronic_tubing_inside_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HydronicTubingInsideDiameter { get; set; } = null;
        

[JsonProperty(PropertyName="number_of_tubing_circuits", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfTubingCircuits { get; set; } = null;
        

[JsonProperty(PropertyName="hydronic_tube_spacing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HydronicTubeSpacing { get; set; } = null;
        

[JsonProperty(PropertyName="surface_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SurfaceLength { get; set; } = null;
        

[JsonProperty(PropertyName="surface_width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SurfaceWidth { get; set; } = null;
        

[JsonProperty(PropertyName="lower_surface_environment", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public GroundHeatExchanger_Surface_LowerSurfaceEnvironment LowerSurfaceEnvironment { get; set; } = (GroundHeatExchanger_Surface_LowerSurfaceEnvironment)Enum.Parse(typeof(GroundHeatExchanger_Surface_LowerSurfaceEnvironment), "Ground");
    }
    
    public enum GroundHeatExchanger_Surface_LowerSurfaceEnvironment
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Exposed")]
        Exposed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Ground")]
        Ground = 2,
    }
    
    [Description("This models a horizontal heat exchanger placed in a series of trenches The model " +
        "uses the PipingSystem:Underground underlying algorithms, but provides a more usa" +
        "ble input interface.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatExchanger_HorizontalTrench
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignFlowRate { get; set; } = null;
        

[Description("This is the total pipe axial length of the heat exchanger If all pipe trenches ar" +
    "e parallel, this is the length of a single trench. If a single, long run of pipe" +
    " is used with one trench, this is the full length of the pipe run.")]
[JsonProperty(PropertyName="trench_length_in_pipe_axial_direction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TrenchLengthInPipeAxialDirection { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[Description("This is the number of horizontal legs that will be used in the entire heat exchan" +
    "ger, one pipe per trench")]
[JsonProperty(PropertyName="number_of_trenches", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfTrenches { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("This represents the average horizontal spacing between any two trenches for heat " +
    "exchangers that have multiple trenches")]
[JsonProperty(PropertyName="horizontal_spacing_between_pipes", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HorizontalSpacingBetweenPipes { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pipe_inner_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeInnerDiameter { get; set; } = Double.Parse("0.016", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pipe_outer_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeOuterDiameter { get; set; } = Double.Parse("0.026", CultureInfo.InvariantCulture);
        

[Description("This is the burial depth of the pipes, or the trenches containing the pipes")]
[JsonProperty(PropertyName="burial_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BurialDepth { get; set; } = Double.Parse("1.5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_thermal_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilThermalConductivity { get; set; } = Double.Parse("1.08", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_density", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilDensity { get; set; } = Double.Parse("962", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_specific_heat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilSpecificHeat { get; set; } = Double.Parse("2576", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pipe_thermal_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeThermalConductivity { get; set; } = Double.Parse("0.3895", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pipe_density", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeDensity { get; set; } = Double.Parse("641", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pipe_specific_heat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeSpecificHeat { get; set; } = Double.Parse("2405", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_moisture_content_percent", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilMoistureContentPercent { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_moisture_content_percent_at_saturation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilMoistureContentPercentAtSaturation { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="undisturbed_ground_temperature_model_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public GroundHeatExchanger_HorizontalTrench_UndisturbedGroundTemperatureModelType UndisturbedGroundTemperatureModelType { get; set; } = (GroundHeatExchanger_HorizontalTrench_UndisturbedGroundTemperatureModelType)Enum.Parse(typeof(GroundHeatExchanger_HorizontalTrench_UndisturbedGroundTemperatureModelType), "SiteGroundTemperatureUndisturbedFiniteDifference");
        

[JsonProperty(PropertyName="undisturbed_ground_temperature_model_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UndisturbedGroundTemperatureModelName { get; set; } = "";
        

[Description(@"This specifies the ground cover effects during evapotranspiration calculations. The value roughly represents the following cases: = 0   : concrete or other solid, non-permeable ground surface material = 0.5 : short grass, much like a manicured lawn = 1   : standard reference state (12 cm grass) = 1.5 : wild growth")]
[JsonProperty(PropertyName="evapotranspiration_ground_cover_parameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvapotranspirationGroundCoverParameter { get; set; } = Double.Parse("0.4", CultureInfo.InvariantCulture);
    }
    
    public enum GroundHeatExchanger_HorizontalTrench_UndisturbedGroundTemperatureModelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:Undisturbed:FiniteDifference")]
        SiteGroundTemperatureUndisturbedFiniteDifference = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:Undisturbed:KusudaAchenbach")]
        SiteGroundTemperatureUndisturbedKusudaAchenbach = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:Undisturbed:Xing")]
        SiteGroundTemperatureUndisturbedXing = 2,
    }
    
    [Description(@"This models a slinky horizontal heat exchanger placed in a series of trenches The model uses the model developed by: Xiong, Z., D.E. Fisher, and J.D. Spitler. 2015. Development and Validation of a Slinky Ground Heat Exchanger Model. Applied Energy 141: 57-69.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatExchanger_Slinky
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignFlowRate { get; set; } = Double.Parse("0.002", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_thermal_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilThermalConductivity { get; set; } = Double.Parse("1.08", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_density", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilDensity { get; set; } = Double.Parse("962", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_specific_heat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilSpecificHeat { get; set; } = Double.Parse("2576", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pipe_thermal_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeThermalConductivity { get; set; } = Double.Parse("0.4", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pipe_density", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeDensity { get; set; } = Double.Parse("641", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pipe_specific_heat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeSpecificHeat { get; set; } = Double.Parse("2405", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pipe_outer_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeOuterDiameter { get; set; } = Double.Parse("0.02667", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pipe_thickness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeThickness { get; set; } = Double.Parse("0.002413", CultureInfo.InvariantCulture);
        

[Description("This is the orientation of the heat exchanger")]
[JsonProperty(PropertyName="heat_exchanger_configuration", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public GroundHeatExchanger_Slinky_HeatExchangerConfiguration HeatExchangerConfiguration { get; set; } = (GroundHeatExchanger_Slinky_HeatExchangerConfiguration)Enum.Parse(typeof(GroundHeatExchanger_Slinky_HeatExchangerConfiguration), "Horizontal");
        

[Description("This is the diameter of the heat exchanger coil")]
[JsonProperty(PropertyName="coil_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoilDiameter { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("This is the center-to-center distance between coils")]
[JsonProperty(PropertyName="coil_pitch", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoilPitch { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[Description("This is the distance from the ground surface to the trench bottom")]
[JsonProperty(PropertyName="trench_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TrenchDepth { get; set; } = Double.Parse("1.8", CultureInfo.InvariantCulture);
        

[Description("This is the total length of a single trench This assumes the heat exchanger runs " +
    "the full length of the trench")]
[JsonProperty(PropertyName="trench_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TrenchLength { get; set; } = Double.Parse("10", CultureInfo.InvariantCulture);
        

[Description("This is the number of parallel trenches that has a heat exchanger, one per trench" +
    "")]
[JsonProperty(PropertyName="number_of_trenches", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfTrenches { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("This represents the average horizontal spacing between any two trenches for heat " +
    "exchangers that have multiple trenches")]
[JsonProperty(PropertyName="horizontal_spacing_between_pipes", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HorizontalSpacingBetweenPipes { get; set; } = Double.Parse("2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="undisturbed_ground_temperature_model_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public GroundHeatExchanger_Slinky_UndisturbedGroundTemperatureModelType UndisturbedGroundTemperatureModelType { get; set; } = (GroundHeatExchanger_Slinky_UndisturbedGroundTemperatureModelType)Enum.Parse(typeof(GroundHeatExchanger_Slinky_UndisturbedGroundTemperatureModelType), "SiteGroundTemperatureUndisturbedFiniteDifference");
        

[JsonProperty(PropertyName="undisturbed_ground_temperature_model_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UndisturbedGroundTemperatureModelName { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_length_of_simulation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumLengthOfSimulation { get; set; } = null;
    }
    
    public enum GroundHeatExchanger_Slinky_HeatExchangerConfiguration
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Horizontal")]
        Horizontal = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Vertical")]
        Vertical = 1,
    }
    
    public enum GroundHeatExchanger_Slinky_UndisturbedGroundTemperatureModelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:Undisturbed:FiniteDifference")]
        SiteGroundTemperatureUndisturbedFiniteDifference = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:Undisturbed:KusudaAchenbach")]
        SiteGroundTemperatureUndisturbedKusudaAchenbach = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:Undisturbed:Xing")]
        SiteGroundTemperatureUndisturbedXing = 2,
    }
    
    [Description("A fluid/fluid heat exchanger designed to couple the supply side of one loop to th" +
        "e demand side of another loop Loops can be either plant or condenser loops but n" +
        "o air side connections are allowed")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HeatExchanger_FluidToFluid
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available. default is " +
    "that heat exchanger is on")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("This connection is to the demand side of a loop and is the inlet to the heat exch" +
    "anger")]
[JsonProperty(PropertyName="loop_demand_side_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string LoopDemandSideInletNodeName { get; set; } = "";
        

[Description("This connection is to the demand side of a loop")]
[JsonProperty(PropertyName="loop_demand_side_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string LoopDemandSideOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="loop_demand_side_design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> LoopDemandSideDesignFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="loop_supply_side_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string LoopSupplySideInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="loop_supply_side_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string LoopSupplySideOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="loop_supply_side_design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> LoopSupplySideDesignFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heat_exchange_model_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HeatExchanger_FluidToFluid_HeatExchangeModelType HeatExchangeModelType { get; set; } = (HeatExchanger_FluidToFluid_HeatExchangeModelType)Enum.Parse(typeof(HeatExchanger_FluidToFluid_HeatExchangeModelType), "Ideal");
        

[JsonProperty(PropertyName="heat_exchanger_u_factor_times_area_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatExchangerUFactorTimesAreaValue { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HeatExchanger_FluidToFluid_ControlType ControlType { get; set; } = (HeatExchanger_FluidToFluid_ControlType)Enum.Parse(typeof(HeatExchanger_FluidToFluid_ControlType), "UncontrolledOn");
        

[Description("Setpoint node is needed with any Control Type that is \"*Setpoint*\"")]
[JsonProperty(PropertyName="heat_exchanger_setpoint_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatExchangerSetpointNodeName { get; set; } = "";
        

[Description("Tolerance between control temperatures used to determine if heat exchanger should" +
    " run.")]
[JsonProperty(PropertyName="minimum_temperature_difference_to_activate_heat_exchanger", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumTemperatureDifferenceToActivateHeatExchanger { get; set; } = Double.Parse("0.01", CultureInfo.InvariantCulture);
        

[Description("This field controls end use reporting for heat transfer meters")]
[JsonProperty(PropertyName="heat_transfer_metering_end_use_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HeatExchanger_FluidToFluid_HeatTransferMeteringEndUseType HeatTransferMeteringEndUseType { get; set; } = (HeatExchanger_FluidToFluid_HeatTransferMeteringEndUseType)Enum.Parse(typeof(HeatExchanger_FluidToFluid_HeatTransferMeteringEndUseType), "LoopToLoop");
        

[Description("This field is only used if Control Type is set to CoolingSetpointOnOffWithCompone" +
    "ntOverride")]
[JsonProperty(PropertyName="component_override_loop_supply_side_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComponentOverrideLoopSupplySideInletNodeName { get; set; } = "";
        

[Description("This field is only used if Control Type is set to CoolingSetpointOnOffWithCompone" +
    "ntOverride")]
[JsonProperty(PropertyName="component_override_loop_demand_side_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComponentOverrideLoopDemandSideInletNodeName { get; set; } = "";
        

[Description("This field is only used if Control Type is set to CoolingSetpointOnOffWithCompone" +
    "ntOverride")]
[JsonProperty(PropertyName="component_override_cooling_control_temperature_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HeatExchanger_FluidToFluid_ComponentOverrideCoolingControlTemperatureMode ComponentOverrideCoolingControlTemperatureMode { get; set; } = (HeatExchanger_FluidToFluid_ComponentOverrideCoolingControlTemperatureMode)Enum.Parse(typeof(HeatExchanger_FluidToFluid_ComponentOverrideCoolingControlTemperatureMode), "Loop");
        

[Description("Multiplies the autosized flow rates for this device")]
[JsonProperty(PropertyName="sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SizingFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Lower limit on inlet temperatures, heat exchanger will not operate if either inle" +
    "t is below this limit")]
[JsonProperty(PropertyName="operation_minimum_temperature_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OperationMinimumTemperatureLimit { get; set; } = null;
        

[Description("Upper limit on inlet temperatures, heat exchanger will not operate if either inle" +
    "t is above this limit")]
[JsonProperty(PropertyName="operation_maximum_temperature_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OperationMaximumTemperatureLimit { get; set; } = null;
    }
    
    public enum HeatExchanger_FluidToFluid_HeatExchangeModelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CounterFlow")]
        CounterFlow = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CrossFlowBothMixed")]
        CrossFlowBothMixed = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="CrossFlowBothUnMixed")]
        CrossFlowBothUnMixed = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="CrossFlowSupplyMixedDemandUnMixed")]
        CrossFlowSupplyMixedDemandUnMixed = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="CrossFlowSupplyUnMixedDemandMixed")]
        CrossFlowSupplyUnMixedDemandMixed = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Ideal")]
        Ideal = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="ParallelFlow")]
        ParallelFlow = 7,
    }
    
    public enum HeatExchanger_FluidToFluid_ControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingDifferentialOnOff")]
        CoolingDifferentialOnOff = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingSetpointModulated")]
        CoolingSetpointModulated = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingSetpointOnOff")]
        CoolingSetpointOnOff = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingSetpointOnOffWithComponentOverride")]
        CoolingSetpointOnOffWithComponentOverride = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="DualDeadbandSetpointModulated")]
        DualDeadbandSetpointModulated = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="DualDeadbandSetpointOnOff")]
        DualDeadbandSetpointOnOff = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatingSetpointModulated")]
        HeatingSetpointModulated = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatingSetpointOnOff")]
        HeatingSetpointOnOff = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="OperationSchemeModulated")]
        OperationSchemeModulated = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="OperationSchemeOnOff")]
        OperationSchemeOnOff = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="UncontrolledOn")]
        UncontrolledOn = 11,
    }
    
    public enum HeatExchanger_FluidToFluid_HeatTransferMeteringEndUseType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FreeCooling")]
        FreeCooling = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatRecovery")]
        HeatRecovery = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatRecoveryForCooling")]
        HeatRecoveryForCooling = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatRecoveryForHeating")]
        HeatRecoveryForHeating = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatRejection")]
        HeatRejection = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="LoopToLoop")]
        LoopToLoop = 6,
    }
    
    public enum HeatExchanger_FluidToFluid_ComponentOverrideCoolingControlTemperatureMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DryBulbTemperature")]
        DryBulbTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Loop")]
        Loop = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="WetBulbTemperature")]
        WetBulbTemperature = 3,
    }
}
