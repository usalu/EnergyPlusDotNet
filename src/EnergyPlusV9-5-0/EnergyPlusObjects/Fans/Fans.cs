namespace EnergyPlus.Fans
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
    
    
    [Description(@"Versatile simple fan that can be used in variable air volume, constant volume, on-off cycling, two-speed or multi-speed applications. Performance at different flow rates, or speed levels, is determined using separate performance curve or table or prescribed power fractions at discrete speed levels for two-speed or multi-speed fans.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Fan_SystemModel
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this fan. Schedule value > 0 means the fan is avai" +
    "lable. If this field is blank, the fan is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="design_maximum_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignMaximumAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="speed_control_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Fan_SystemModel_SpeedControlMethod SpeedControlMethod { get; set; } = (Fan_SystemModel_SpeedControlMethod)Enum.Parse(typeof(Fan_SystemModel_SpeedControlMethod), "Discrete");
        

[JsonProperty(PropertyName="electric_power_minimum_flow_rate_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ElectricPowerMinimumFlowRateFraction { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="design_pressure_rise", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignPressureRise { get; set; } = null;
        

[JsonProperty(PropertyName="motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[Description("0.0 means fan motor outside of air stream, 1.0 means motor inside of air stream")]
[JsonProperty(PropertyName="motor_in_air_stream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MotorInAirStreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Fan power consumption at maximum air flow rate. If autosized the method used to s" +
    "cale power is chosen in the following field")]
[JsonProperty(PropertyName="design_electric_power_consumption", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignElectricPowerConsumption { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="design_power_sizing_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Fan_SystemModel_DesignPowerSizingMethod DesignPowerSizingMethod { get; set; } = (Fan_SystemModel_DesignPowerSizingMethod)Enum.Parse(typeof(Fan_SystemModel_DesignPowerSizingMethod), "PowerPerFlowPerPressure");
        

[JsonProperty(PropertyName="electric_power_per_unit_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ElectricPowerPerUnitFlowRate { get; set; } = null;
        

[JsonProperty(PropertyName="electric_power_per_unit_flow_rate_per_unit_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ElectricPowerPerUnitFlowRatePerUnitPressure { get; set; } = Double.Parse("1.66667", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[Description(@"independent variable is normalized flow rate, current flow divided by Design Maximum Air Flow Rate. dependent variable is modification factor multiplied by Design Power Consumption. This field is required if Speed Control Method is set to Continuous or if the Number of Speeds is greater than 1 and Speed Electric Power Fraction fields are not used.")]
[JsonProperty(PropertyName="electric_power_function_of_flow_fraction_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ElectricPowerFunctionOfFlowFractionCurveName { get; set; } = "";
        

[Description("Total system fan pressure rise at the fan when in night mode using AvailabilityMa" +
    "nager:NightVentilation")]
[JsonProperty(PropertyName="night_ventilation_mode_pressure_rise", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NightVentilationModePressureRise { get; set; } = null;
        

[Description("Fraction of Design Maximum Air Flow Rate to use when in night mode using Availabi" +
    "lityManager:NightVentilation")]
[JsonProperty(PropertyName="night_ventilation_mode_flow_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NightVentilationModeFlowFraction { get; set; } = null;
        

[Description("optional, if used fan motor heat losses that not added to air stream are transfer" +
    "red to zone as internal gains")]
[JsonProperty(PropertyName="motor_loss_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MotorLossZoneName { get; set; } = "";
        

[Description("optional. If zone identified in previous field then this determines the split bet" +
    "ween convection and radiation for the fan motor\'s skin losses")]
[JsonProperty(PropertyName="motor_loss_radiative_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MotorLossRadiativeFraction { get; set; } = null;
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
        

[Description(@"number of different speed levels available when Speed Control Method is set to Discrete Speed need to be arranged in increasing order in remaining field sets. If set to 1, or omitted, and Speed Control Method is Discrete then constant fan speed is the design maximum.")]
[JsonProperty(PropertyName="number_of_speeds", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfSpeeds { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="speed_fractions", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Fans.Fan_SystemModel_SpeedFractions_Item> SpeedFractions { get; set; } = null;
    }
    
    public enum Fan_SystemModel_SpeedControlMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Continuous")]
        Continuous = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Discrete")]
        Discrete = 2,
    }
    
    public enum Fan_SystemModel_DesignPowerSizingMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PowerPerFlow")]
        PowerPerFlow = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PowerPerFlowPerPressure")]
        PowerPerFlowPerPressure = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="TotalEfficiencyAndPressure")]
        TotalEfficiencyAndPressure = 3,
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Fan_SystemModel_SpeedFractions_Item
    {
        

[JsonProperty(PropertyName="speed_flow_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SpeedFlowFraction { get; set; } = null;
        

[JsonProperty(PropertyName="speed_electric_power_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SpeedElectricPowerFraction { get; set; } = null;
    }
    
    [Description("Constant volume fan that is intended to operate continuously based on a time sche" +
        "dule. This fan will not cycle on and off based on cooling/heating load or other " +
        "control signals.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Fan_ConstantVolume
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pressure_rise", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PressureRise { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[Description("0.0 means fan motor outside of air stream, 1.0 means motor inside of air stream")]
[JsonProperty(PropertyName="motor_in_airstream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MotorInAirstreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    [Description("Variable air volume fan where the electric power input varies according to a perf" +
        "ormance curve as a function of flow fraction.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Fan_VariableVolume
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanTotalEfficiency { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pressure_rise", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PressureRise { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fan_power_minimum_flow_rate_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Fan_VariableVolume_FanPowerMinimumFlowRateInputMethod FanPowerMinimumFlowRateInputMethod { get; set; } = (Fan_VariableVolume_FanPowerMinimumFlowRateInputMethod)Enum.Parse(typeof(Fan_VariableVolume_FanPowerMinimumFlowRateInputMethod), "Fraction");
        

[JsonProperty(PropertyName="fan_power_minimum_flow_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanPowerMinimumFlowFraction { get; set; } = Double.Parse("0.25", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fan_power_minimum_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanPowerMinimumAirFlowRate { get; set; } = null;
        

[JsonProperty(PropertyName="motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[Description("0.0 means fan motor outside of air stream, 1.0 means motor inside of air stream")]
[JsonProperty(PropertyName="motor_in_airstream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MotorInAirstreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("all Fan Power Coefficients should not be 0.0 or no fan power will be consumed. Fa" +
    "n Power Coefficents are specified as function of full flow rate/power Equation:")]
[JsonProperty(PropertyName="fan_power_coefficient_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanPowerCoefficient1 { get; set; } = null;
        

[JsonProperty(PropertyName="fan_power_coefficient_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanPowerCoefficient2 { get; set; } = null;
        

[JsonProperty(PropertyName="fan_power_coefficient_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanPowerCoefficient3 { get; set; } = null;
        

[JsonProperty(PropertyName="fan_power_coefficient_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanPowerCoefficient4 { get; set; } = null;
        

[JsonProperty(PropertyName="fan_power_coefficient_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanPowerCoefficient5 { get; set; } = null;
        

[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    public enum Fan_VariableVolume_FanPowerMinimumFlowRateInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedFlowRate")]
        FixedFlowRate = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Fraction")]
        Fraction = 2,
    }
    
    [Description("Constant volume fan that is intended to cycle on and off based on cooling/heating" +
        " load or other control signals. This fan can also operate continuously like Fan:" +
        "ConstantVolume.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Fan_OnOff
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanTotalEfficiency { get; set; } = Double.Parse("0.6", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pressure_rise", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PressureRise { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MotorEfficiency { get; set; } = Double.Parse("0.8", CultureInfo.InvariantCulture);
        

[Description("0.0 means fan motor outside of air stream, 1.0 means motor inside of air stream")]
[JsonProperty(PropertyName="motor_in_airstream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MotorInAirstreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="fan_power_ratio_function_of_speed_ratio_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FanPowerRatioFunctionOfSpeedRatioCurveName { get; set; } = "";
        

[JsonProperty(PropertyName="fan_efficiency_ratio_function_of_speed_ratio_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FanEfficiencyRatioFunctionOfSpeedRatioCurveName { get; set; } = "";
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    [Description("Models a fan that exhausts air from a zone.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Fan_ZoneExhaust
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanTotalEfficiency { get; set; } = Double.Parse("0.6", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pressure_rise", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PressureRise { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumFlowRate { get; set; } = null;
        

[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
        

[Description("If field is used, then when fan runs the exhausted air flow rate is controlled to" +
    " be the scheduled fraction times the Maximum Flow Rate")]
[JsonProperty(PropertyName="flow_fraction_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FlowFractionScheduleName { get; set; } = "";
        

[Description("Control if fan is to be interlocked with HVAC system Availability Managers or not" +
    ".")]
[JsonProperty(PropertyName="system_availability_manager_coupling_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Fan_ZoneExhaust_SystemAvailabilityManagerCouplingMode SystemAvailabilityManagerCouplingMode { get; set; } = (Fan_ZoneExhaust_SystemAvailabilityManagerCouplingMode)Enum.Parse(typeof(Fan_ZoneExhaust_SystemAvailabilityManagerCouplingMode), "Coupled");
        

[Description("If field is used, the exhaust fan will not run if the zone temperature is lower t" +
    "han this limit")]
[JsonProperty(PropertyName="minimum_zone_temperature_limit_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumZoneTemperatureLimitScheduleName { get; set; } = "";
        

[Description("Used to control fan\'s impact on flow at the return air node. Enter the portion of" +
    " the exhaust that is balanced by simple airflows.")]
[JsonProperty(PropertyName="balanced_exhaust_fraction_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BalancedExhaustFractionScheduleName { get; set; } = "";
    }
    
    public enum Fan_ZoneExhaust_SystemAvailabilityManagerCouplingMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coupled")]
        Coupled = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Decoupled")]
        Decoupled = 2,
    }
    
    [Description(@"Specifies an alternate set of performance parameters for a fan. These alternate parameters are used when a system manager (such as AvailabilityManager:NightVentilation) sets a specified flow rate. May be used with Fan:ConstantVolume, Fan:VariableVolume and Fan:ComponentModel. If the fan model senses that a fixed flow rate has been set, it will use these alternate performance parameters. It is assumed that the fan will run at a fixed speed in the alternate mode.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class FanPerformance_NightVentilation
    {
        

[JsonProperty(PropertyName="fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FanName { get; set; } = "";
        

[JsonProperty(PropertyName="fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanTotalEfficiency { get; set; } = null;
        

[JsonProperty(PropertyName="pressure_rise", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PressureRise { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MotorEfficiency { get; set; } = null;
        

[Description("0.0 means fan motor outside of airstream 1.0 means fan motor inside of airstream")]
[JsonProperty(PropertyName="motor_in_airstream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MotorInAirstreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
    }
    
    [Description("A detailed fan type for constant-air-volume (CAV) and variable-air-volume (VAV) s" +
        "ystems. It includes inputs that describe the air-distribution system as well as " +
        "the fan, drive belt (if used), motor, and variable-frequency-drive (if used).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Fan_ComponentModel
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MinimumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Applied to specified or autosized max fan airflow")]
[JsonProperty(PropertyName="fan_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanSizingFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Diameter of wheel outer circumference")]
[JsonProperty(PropertyName="fan_wheel_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanWheelDiameter { get; set; } = null;
        

[Description("Area at fan outlet plane for determining discharge velocity pressure")]
[JsonProperty(PropertyName="fan_outlet_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FanOutletArea { get; set; } = null;
        

[Description("Maximum ratio between power delivered to air and fan shaft input power Determined" +
    " from fan performance data")]
[JsonProperty(PropertyName="maximum_fan_static_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumFanStaticEfficiency { get; set; } = null;
        

[Description("Euler number (Eu) determined from fan performance data")]
[JsonProperty(PropertyName="euler_number_at_maximum_fan_static_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EulerNumberAtMaximumFanStaticEfficiency { get; set; } = null;
        

[Description("Corresponds to maximum ratio between fan airflow and fan shaft rotational speed f" +
    "or specified fan wheel diameter Determined from fan performance data")]
[JsonProperty(PropertyName="maximum_dimensionless_fan_airflow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumDimensionlessFanAirflow { get; set; } = null;
        

[Description("Ratio of motor pulley diameter to fan pulley diameter")]
[JsonProperty(PropertyName="motor_fan_pulley_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MotorFanPulleyRatio { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Maximum torque transmitted by belt")]
[JsonProperty(PropertyName="belt_maximum_torque", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> BeltMaximumTorque { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Applied to specified or autosized max torque transmitted by belt")]
[JsonProperty(PropertyName="belt_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BeltSizingFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Region 1 to 2 curve transition for belt normalized efficiency")]
[JsonProperty(PropertyName="belt_fractional_torque_transition", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BeltFractionalTorqueTransition { get; set; } = Double.Parse("0.167", CultureInfo.InvariantCulture);
        

[Description("Maximum rotational speed of fan motor shaft")]
[JsonProperty(PropertyName="motor_maximum_speed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MotorMaximumSpeed { get; set; } = null;
        

[Description("Maximum power input to drive belt by motor")]
[JsonProperty(PropertyName="maximum_motor_output_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumMotorOutputPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Applied to specified or autosized motor output power")]
[JsonProperty(PropertyName="motor_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MotorSizingFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("0.0 means motor outside air stream 1.0 means motor inside air stream")]
[JsonProperty(PropertyName="motor_in_airstream_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MotorInAirstreamFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Efficiency depends on fraction of full-load motor speed Efficiency depends on  fr" +
    "action of full-load motor input power If field blank, then assumes constant VFD " +
    "efficiency (0.97)")]
[JsonProperty(PropertyName="vfd_efficiency_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Fan_ComponentModel_VfdEfficiencyType VfdEfficiencyType { get; set; } = (Fan_ComponentModel_VfdEfficiencyType)Enum.Parse(typeof(Fan_ComponentModel_VfdEfficiencyType), "Power");
        

[Description("Maximum power input to motor by VFD")]
[JsonProperty(PropertyName="maximum_vfd_output_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumVfdOutputPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Applied to specified or autosized VFD output power")]
[JsonProperty(PropertyName="vfd_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VfdSizingFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Pressure rise depends on volumetric flow, system resistances, system leakage, and" +
    " duct static pressure set point")]
[JsonProperty(PropertyName="fan_pressure_rise_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FanPressureRiseCurveName { get; set; } = "";
        

[Description("Function of fan volumetric flow Minimum and maximum fan airflows correspond respe" +
    "ctively to minimum and maximum duct static pressure set points")]
[JsonProperty(PropertyName="duct_static_pressure_reset_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DuctStaticPressureResetCurveName { get; set; } = "";
        

[Description("xfan <= 0 Curve should have maximum of 1.0")]
[JsonProperty(PropertyName="normalized_fan_static_efficiency_curve_name_non_stall_region", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NormalizedFanStaticEfficiencyCurveNameNonStallRegion { get; set; } = "";
        

[Description("xfan > 0 Curve should have maximum of 1.0")]
[JsonProperty(PropertyName="normalized_fan_static_efficiency_curve_name_stall_region", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NormalizedFanStaticEfficiencyCurveNameStallRegion { get; set; } = "";
        

[Description("xspd <= 0 Curve should have maximum of 1.0")]
[JsonProperty(PropertyName="normalized_dimensionless_airflow_curve_name_non_stall_region", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NormalizedDimensionlessAirflowCurveNameNonStallRegion { get; set; } = "";
        

[Description("xspd > 0 Curve should have maximum of 1.0")]
[JsonProperty(PropertyName="normalized_dimensionless_airflow_curve_name_stall_region", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NormalizedDimensionlessAirflowCurveNameStallRegion { get; set; } = "";
        

[Description("Determines maximum fan drive belt efficiency in log space as function of xbelt,ma" +
    "x Curve should have minimum of -4.6 and maximum of 0.0 If field blank, assumes o" +
    "utput of curve is always 1.0")]
[JsonProperty(PropertyName="maximum_belt_efficiency_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaximumBeltEfficiencyCurveName { get; set; } = "";
        

[Description("Region 1 (0 <= xbelt < xbelt,trans) Curve should have minimum > 0.0 and maximum o" +
    "f 1.0 If field blank, assumes output of curve is always 1.0 in Region 1")]
[JsonProperty(PropertyName="normalized_belt_efficiency_curve_name_region_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NormalizedBeltEfficiencyCurveNameRegion1 { get; set; } = "";
        

[Description("Region 2 (xbelt,trans <= xbelt <= 1) Curve should have minimum > 0.0 and maximum " +
    "of 1.0 If field blank, assumes output of curve is always 1.0 in Region 2")]
[JsonProperty(PropertyName="normalized_belt_efficiency_curve_name_region_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NormalizedBeltEfficiencyCurveNameRegion2 { get; set; } = "";
        

[Description("Determines normalized drive belt efficiency Region 3 (xbelt > 1) Curve should hav" +
    "e minimum > 0.0 and maximum of 1.0 If field blank, assumes output of curve is al" +
    "ways 1.0 in Region 3")]
[JsonProperty(PropertyName="normalized_belt_efficiency_curve_name_region_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NormalizedBeltEfficiencyCurveNameRegion3 { get; set; } = "";
        

[Description("Curve should have minimum > 0.0 and maximum of 1.0 If field blank, assumes output" +
    " of curve is always 1.0")]
[JsonProperty(PropertyName="maximum_motor_efficiency_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaximumMotorEfficiencyCurveName { get; set; } = "";
        

[Description("Curve should have minimum > 0.0 and maximum of 1.0 If field blank, assumes output" +
    " of curve is always 1.0")]
[JsonProperty(PropertyName="normalized_motor_efficiency_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NormalizedMotorEfficiencyCurveName { get; set; } = "";
        

[Description("Determines VFD efficiency as function of motor load or speed fraction Curve shoul" +
    "d have minimum > 0.0 and maximum of 1.0 If field blank, assumes constant VFD eff" +
    "iciency (0.97)")]
[JsonProperty(PropertyName="vfd_efficiency_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string VfdEfficiencyCurveName { get; set; } = "";
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    public enum Fan_ComponentModel_VfdEfficiencyType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Speed")]
        Speed = 1,
    }
}
