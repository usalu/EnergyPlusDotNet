namespace EnergyPlus.Pumps
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
    
    
    [Description("This pump model is described in the ASHRAE secondary HVAC toolkit.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Pump_VariableSpeed
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="design_maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignMaximumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("default head is 60 feet")]
[JsonProperty(PropertyName="design_pump_head", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignPumpHead { get; set; } = Double.Parse("179352", CultureInfo.InvariantCulture);
        

[Description("When autosized the type of scaling factor is chosen in the input field Design Pow" +
    "er Sizing Method")]
[JsonProperty(PropertyName="design_power_consumption", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignPowerConsumption { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This is the motor efficiency only. When the Design Power Consumption is autosized" +
    " using PowerPerFlowPerPressure, the Design Shaft Power per Unit Flow Rate per Un" +
    "it Head is used in addition to the motor efficiency.")]
[JsonProperty(PropertyName="motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_of_motor_inefficiencies_to_fluid_stream", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfMotorInefficienciesToFluidStream { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="coefficient_1_of_the_part_load_performance_curve", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1OfThePartLoadPerformanceCurve { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="coefficient_2_of_the_part_load_performance_curve", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2OfThePartLoadPerformanceCurve { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="coefficient_3_of_the_part_load_performance_curve", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3OfThePartLoadPerformanceCurve { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="coefficient_4_of_the_part_load_performance_curve", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient4OfThePartLoadPerformanceCurve { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("When autosized the scaling factor is the input field Design Minimum Flow Rate Fra" +
    "ction")]
[JsonProperty(PropertyName="design_minimum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignMinimumFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pump_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Pump_VariableSpeed_PumpControlType PumpControlType { get; set; } = (Pump_VariableSpeed_PumpControlType)Enum.Parse(typeof(Pump_VariableSpeed_PumpControlType), "Continuous");
        

[Description("Modifies the rated flow rate of the pump on a time basis. Default is that the pum" +
    "p is on and runs according to its other operational requirements specified above" +
    ". The schedule is for special pump operations.")]
[JsonProperty(PropertyName="pump_flow_rate_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PumpFlowRateScheduleName { get; set; } = "";
        

[Description(@"This references any single independent variable polynomial curve in order to do pressure vs. flow calculations for this pump. The available types are then: Linear, Quadratic, Cubic, and Quartic The non-dimensional pump pressure relationship is of the following form: (psi = C4*phi^4 + C3*phi^3 + C2*phi^2 + C1*phi + C0) Where the non-dimensional variables are defined as: delP = rho * ((N/60)^2) * (D^2) * psi mdot = rho * (N/60) * (D^3) * phi")]
[JsonProperty(PropertyName="pump_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PumpCurveName { get; set; } = "";
        

[Description("\"D\" in above expression in field A6")]
[JsonProperty(PropertyName="impeller_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ImpellerDiameter { get; set; } = null;
        

[JsonProperty(PropertyName="vfd_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Pump_VariableSpeed_VfdControlType VfdControlType { get; set; } = (Pump_VariableSpeed_VfdControlType)Enum.Parse(typeof(Pump_VariableSpeed_VfdControlType), "ManualControl");
        

[Description("Modifies the rpm of the pump on a time basis. Default is that the pump is on and " +
    "runs according to its other operational requirements specified above. The schedu" +
    "le is for special pump operations.")]
[JsonProperty(PropertyName="pump_rpm_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PumpRpmScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="minimum_pressure_schedule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumPressureSchedule { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_pressure_schedule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaximumPressureSchedule { get; set; } = "";
        

[JsonProperty(PropertyName="minimum_rpm_schedule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumRpmSchedule { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_rpm_schedule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaximumRpmSchedule { get; set; } = "";
        

[Description("optional, if used pump losses transfered to zone as internal gains")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("optional. If zone identified in previous field then this determines the split bet" +
    "ween convection and radiation for the skin losses")]
[JsonProperty(PropertyName="skin_loss_radiative_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SkinLossRadiativeFraction { get; set; } = null;
        

[Description(@"Used to indicate which sizing factor is used to calculate Design Power Consumption. PowerPerFlow indicates that Design Electric Power per Unit Flow Rate is used as scaling factor. Design Power Consumption = Design Maximum Flow Rate * scaling factor PowerPerFlowPerPressure indicates that Design Shaft Power per Unit Flow Rate per Unit Head is used as scaling factor. Design Power Consumption = Design Maximum Flow Rate * Design Pump Head * scaling factor / Motor Efficiency")]
[JsonProperty(PropertyName="design_power_sizing_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Pump_VariableSpeed_DesignPowerSizingMethod DesignPowerSizingMethod { get; set; } = (Pump_VariableSpeed_DesignPowerSizingMethod)Enum.Parse(typeof(Pump_VariableSpeed_DesignPowerSizingMethod), "PowerPerFlowPerPressure");
        

[Description("Used to size Design Power Consumption from design flow rate")]
[JsonProperty(PropertyName="design_electric_power_per_unit_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignElectricPowerPerUnitFlowRate { get; set; } = Double.Parse("348701.1", CultureInfo.InvariantCulture);
        

[Description("Used to size Design Power Consumption from design flow rate for head and motor ef" +
    "ficiency")]
[JsonProperty(PropertyName="design_shaft_power_per_unit_flow_rate_per_unit_head", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignShaftPowerPerUnitFlowRatePerUnitHead { get; set; } = Double.Parse("1.282051282", CultureInfo.InvariantCulture);
        

[Description("Used to size Design Minimum Flow Rate")]
[JsonProperty(PropertyName="design_minimum_flow_rate_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignMinimumFlowRateFraction { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    public enum Pump_VariableSpeed_PumpControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Continuous")]
        Continuous = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Intermittent")]
        Intermittent = 2,
    }
    
    public enum Pump_VariableSpeed_VfdControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="ManualControl")]
        ManualControl = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PressureSetpointControl")]
        PressureSetpointControl = 1,
    }
    
    public enum Pump_VariableSpeed_DesignPowerSizingMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PowerPerFlow")]
        PowerPerFlow = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PowerPerFlowPerPressure")]
        PowerPerFlowPerPressure = 2,
    }
    
    [Description("This pump model is described in the ASHRAE secondary HVAC toolkit.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Pump_ConstantSpeed
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
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("default head is 60 feet")]
[JsonProperty(PropertyName="design_pump_head", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignPumpHead { get; set; } = Double.Parse("179352", CultureInfo.InvariantCulture);
        

[Description("When autosized the type of scaling factor is chosen in the input field Design Pow" +
    "er Sizing Method")]
[JsonProperty(PropertyName="design_power_consumption", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignPowerConsumption { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This is the motor efficiency only. When the Design Power Consumption is autosized" +
    " using PowerPerFlowPerPressure, the Design Shaft Power per Unit Flow Rate per Un" +
    "it Head is used in addition to the motor efficiency.")]
[JsonProperty(PropertyName="motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_of_motor_inefficiencies_to_fluid_stream", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfMotorInefficienciesToFluidStream { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pump_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Pump_ConstantSpeed_PumpControlType PumpControlType { get; set; } = (Pump_ConstantSpeed_PumpControlType)Enum.Parse(typeof(Pump_ConstantSpeed_PumpControlType), "Continuous");
        

[Description("Modifies the rated flow rate of the pump on a time basis. Default is that the pum" +
    "p is on and runs according to its other operational requirements specified above" +
    ". The schedule is for special pump operations.")]
[JsonProperty(PropertyName="pump_flow_rate_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PumpFlowRateScheduleName { get; set; } = "";
        

[Description(@"This references any single independent variable polynomial curve in order to do pressure vs. flow calculations for this pump. The available types are then: Linear, Quadratic, Cubic, and Quartic The non-dimensional pump pressure relationship is of the following form: (psi = C4*phi^4 + C3*phi^3 + C2*phi^2 + C1*phi + C0) Where the non-dimensional variables are defined as: delP = rho * ((N/60)^2) * (D^2) * psi mdot = rho * (N/60) * (D^3) * phi")]
[JsonProperty(PropertyName="pump_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PumpCurveName { get; set; } = "";
        

[Description("\"D\" in above expression in field A6")]
[JsonProperty(PropertyName="impeller_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ImpellerDiameter { get; set; } = null;
        

[Description("\"N\" in above expression in field A6")]
[JsonProperty(PropertyName="rotational_speed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RotationalSpeed { get; set; } = null;
        

[Description("optional, if used pump losses transfered to zone as internal gains")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("optional. If zone identified in previous field then this determines the split bet" +
    "ween convection and radiation for the skin losses")]
[JsonProperty(PropertyName="skin_loss_radiative_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SkinLossRadiativeFraction { get; set; } = null;
        

[Description(@"Used to indicate which sizing factor is used to calculate Design Power Consumption. PowerPerFlow indicates that Design Electric Power per Unit Flow Rate is used as scaling factor. Design Power Consumption = Design Maximum Flow Rate * scaling factor PowerPerFlowPerPressure indicates that Design Shaft Power per Unit Flow Rate per Unit Head is used as scaling factor. Design Power Consumption = Design Maximum Flow Rate * Design Pump Head * scaling factor / Motor Efficiency")]
[JsonProperty(PropertyName="design_power_sizing_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Pump_ConstantSpeed_DesignPowerSizingMethod DesignPowerSizingMethod { get; set; } = (Pump_ConstantSpeed_DesignPowerSizingMethod)Enum.Parse(typeof(Pump_ConstantSpeed_DesignPowerSizingMethod), "PowerPerFlowPerPressure");
        

[Description("Used to size Design Power Consumption from design flow rate")]
[JsonProperty(PropertyName="design_electric_power_per_unit_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignElectricPowerPerUnitFlowRate { get; set; } = Double.Parse("348701.1", CultureInfo.InvariantCulture);
        

[Description("Used to size Design Power Consumption from design flow rate for head and motor ef" +
    "ficiency")]
[JsonProperty(PropertyName="design_shaft_power_per_unit_flow_rate_per_unit_head", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignShaftPowerPerUnitFlowRatePerUnitHead { get; set; } = Double.Parse("1.282051282", CultureInfo.InvariantCulture);
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    public enum Pump_ConstantSpeed_PumpControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Continuous")]
        Continuous = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Intermittent")]
        Intermittent = 2,
    }
    
    public enum Pump_ConstantSpeed_DesignPowerSizingMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PowerPerFlow")]
        PowerPerFlow = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PowerPerFlowPerPressure")]
        PowerPerFlowPerPressure = 2,
    }
    
    [Description("This pump model is described in the ASHRAE secondary HVAC toolkit. Variable Speed" +
        " Condensate pump for Steam Systems")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Pump_VariableSpeed_Condensate
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutletNodeName { get; set; } = "";
        

[Description("this is the volume of steam before condensation, the volume of condensate is much" +
    " lower and calculated from steam density")]
[JsonProperty(PropertyName="design_steam_volume_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignSteamVolumeFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("default head is 60 feet")]
[JsonProperty(PropertyName="design_pump_head", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignPumpHead { get; set; } = Double.Parse("179352", CultureInfo.InvariantCulture);
        

[Description("When autosized the type of scaling factor is chosen in the input field Design Pow" +
    "er Sizing Method")]
[JsonProperty(PropertyName="design_power_consumption", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignPowerConsumption { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This is the motor efficiency only. When the Design Power Consumption is autosized" +
    " using PowerPerFlowPerPressure, the Design Shaft Power per Unit Flow Rate per Un" +
    "it Head is used in addition to the motor efficiency.")]
[JsonProperty(PropertyName="motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_of_motor_inefficiencies_to_fluid_stream", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfMotorInefficienciesToFluidStream { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="coefficient_1_of_the_part_load_performance_curve", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1OfThePartLoadPerformanceCurve { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="coefficient_2_of_the_part_load_performance_curve", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2OfThePartLoadPerformanceCurve { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="coefficient_3_of_the_part_load_performance_curve", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3OfThePartLoadPerformanceCurve { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="coefficient_4_of_the_part_load_performance_curve", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient4OfThePartLoadPerformanceCurve { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Modifies the rated flow rate of the pump on a time basis. Default is that the pum" +
    "p is on and runs according to its other operational requirements specified above" +
    ". The schedule is for special pump operations.")]
[JsonProperty(PropertyName="pump_flow_rate_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PumpFlowRateScheduleName { get; set; } = "";
        

[Description("optional, if used pump losses transfered to zone as internal gains")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("optional. If zone identified in previous field then this determines the split bet" +
    "ween convection and radiation for the skin losses")]
[JsonProperty(PropertyName="skin_loss_radiative_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SkinLossRadiativeFraction { get; set; } = null;
        

[Description(@"Used to indicate which sizing factor is used to calculate Design Power Consumption. PowerPerFlow indicates that Design Electric Power per Unit Flow Rate is used as scaling factor. Design Power Consumption = Design Maximum Flow Rate * scaling factor PowerPerFlowPerPressure indicates that Design Shaft Power per Unit Flow Rate per Unit Head is used as scaling factor. Design Power Consumption = Design Maximum Flow Rate * Design Pump Head * scaling factor / Motor Efficiency")]
[JsonProperty(PropertyName="design_power_sizing_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Pump_VariableSpeed_Condensate_DesignPowerSizingMethod DesignPowerSizingMethod { get; set; } = (Pump_VariableSpeed_Condensate_DesignPowerSizingMethod)Enum.Parse(typeof(Pump_VariableSpeed_Condensate_DesignPowerSizingMethod), "PowerPerFlowPerPressure");
        

[Description("Used to size Design Power Consumption from design flow rate")]
[JsonProperty(PropertyName="design_electric_power_per_unit_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignElectricPowerPerUnitFlowRate { get; set; } = Double.Parse("348701.1", CultureInfo.InvariantCulture);
        

[Description("Used to size Design Power Consumption from design flow rate for head and motor ef" +
    "ficiency")]
[JsonProperty(PropertyName="design_shaft_power_per_unit_flow_rate_per_unit_head", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignShaftPowerPerUnitFlowRatePerUnitHead { get; set; } = Double.Parse("1.282051282", CultureInfo.InvariantCulture);
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    public enum Pump_VariableSpeed_Condensate_DesignPowerSizingMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PowerPerFlow")]
        PowerPerFlow = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PowerPerFlowPerPressure")]
        PowerPerFlowPerPressure = 2,
    }
    
    [Description("This Headered pump object describes a pump bank with more than 1 pump in parallel" +
        "")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HeaderedPumps_ConstantSpeed
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutletNodeName { get; set; } = "";
        

[Description("If the field is not autosized set to the flow rate to the total flow when all pum" +
    "ps are running at full load")]
[JsonProperty(PropertyName="total_design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> TotalDesignFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="number_of_pumps_in_bank", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfPumpsInBank { get; set; } = null;
        

[JsonProperty(PropertyName="flow_sequencing_control_scheme", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HeaderedPumps_ConstantSpeed_FlowSequencingControlScheme FlowSequencingControlScheme { get; set; } = (HeaderedPumps_ConstantSpeed_FlowSequencingControlScheme)Enum.Parse(typeof(HeaderedPumps_ConstantSpeed_FlowSequencingControlScheme), "Sequential");
        

[Description("default head is 60 feet")]
[JsonProperty(PropertyName="design_pump_head", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignPumpHead { get; set; } = Double.Parse("179352", CultureInfo.InvariantCulture);
        

[Description("If the field is not autosized set to the power consumed by the pump bank when all" +
    " the pumps are running at nominal flow When autosized the type of scaling factor" +
    " is chosen in the input field Design Power Sizing Method")]
[JsonProperty(PropertyName="design_power_consumption", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignPowerConsumption { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This is the motor efficiency only. When the Design Power Consumption is autosized" +
    " using PowerPerFlowPerPressure, the Design Shaft Power per Unit Flow Rate per Un" +
    "it Head is used in addition to the motor efficiency.")]
[JsonProperty(PropertyName="motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_of_motor_inefficiencies_to_fluid_stream", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfMotorInefficienciesToFluidStream { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pump_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HeaderedPumps_ConstantSpeed_PumpControlType PumpControlType { get; set; } = (HeaderedPumps_ConstantSpeed_PumpControlType)Enum.Parse(typeof(HeaderedPumps_ConstantSpeed_PumpControlType), "Continuous");
        

[Description("Modifies the rated flow rate of the pump on a time basis. Default is that the pum" +
    "p is on and runs according to its other operational requirements specified above" +
    ". The schedule is for special pump operations.")]
[JsonProperty(PropertyName="pump_flow_rate_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PumpFlowRateScheduleName { get; set; } = "";
        

[Description("optional, if used pump losses transfered to zone as internal gains")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("optional. If zone identified in previous field then this determines the split bet" +
    "ween convection and radiation for the skin losses")]
[JsonProperty(PropertyName="skin_loss_radiative_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SkinLossRadiativeFraction { get; set; } = null;
        

[Description(@"Used to indicate which sizing factor is used to calculate Design Power Consumption. PowerPerFlow indicates that Design Electric Power per Unit Flow Rate is used as scaling factor. Design Power Consumption = Design Maximum Flow Rate * scaling factor PowerPerFlowPerPressure indicates that Design Shaft Power per Unit Flow Rate per Unit Head is used as scaling factor. Design Power Consumption = Design Maximum Flow Rate * Design Pump Head * scaling factor / Motor Efficiency")]
[JsonProperty(PropertyName="design_power_sizing_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HeaderedPumps_ConstantSpeed_DesignPowerSizingMethod DesignPowerSizingMethod { get; set; } = (HeaderedPumps_ConstantSpeed_DesignPowerSizingMethod)Enum.Parse(typeof(HeaderedPumps_ConstantSpeed_DesignPowerSizingMethod), "PowerPerFlowPerPressure");
        

[Description("Used to size Design Power Consumption from design flow rate")]
[JsonProperty(PropertyName="design_electric_power_per_unit_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignElectricPowerPerUnitFlowRate { get; set; } = Double.Parse("348701.1", CultureInfo.InvariantCulture);
        

[Description("Used to size Design Power Consumption from design flow rate for head and motor ef" +
    "ficiency")]
[JsonProperty(PropertyName="design_shaft_power_per_unit_flow_rate_per_unit_head", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignShaftPowerPerUnitFlowRatePerUnitHead { get; set; } = Double.Parse("1.282051282", CultureInfo.InvariantCulture);
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    public enum HeaderedPumps_ConstantSpeed_FlowSequencingControlScheme
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Sequential")]
        Sequential = 1,
    }
    
    public enum HeaderedPumps_ConstantSpeed_PumpControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Continuous")]
        Continuous = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Intermittent")]
        Intermittent = 2,
    }
    
    public enum HeaderedPumps_ConstantSpeed_DesignPowerSizingMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PowerPerFlow")]
        PowerPerFlow = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PowerPerFlowPerPressure")]
        PowerPerFlowPerPressure = 2,
    }
    
    [Description("This Headered pump object describes a pump bank with more than 1 pump in parallel" +
        "")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HeaderedPumps_VariableSpeed
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutletNodeName { get; set; } = "";
        

[Description("If the field is not autosized set to the flow rate to the total flow when all pum" +
    "ps are running at full load")]
[JsonProperty(PropertyName="total_design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> TotalDesignFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="number_of_pumps_in_bank", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfPumpsInBank { get; set; } = null;
        

[JsonProperty(PropertyName="flow_sequencing_control_scheme", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HeaderedPumps_VariableSpeed_FlowSequencingControlScheme FlowSequencingControlScheme { get; set; } = (HeaderedPumps_VariableSpeed_FlowSequencingControlScheme)Enum.Parse(typeof(HeaderedPumps_VariableSpeed_FlowSequencingControlScheme), "Sequential");
        

[Description("default head is 60 feet")]
[JsonProperty(PropertyName="design_pump_head", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignPumpHead { get; set; } = Double.Parse("179352", CultureInfo.InvariantCulture);
        

[Description("If the field is not autosized set to the power consumed by the pump bank when all" +
    " the pumps are running at nominal flow When autosized the type of scaling factor" +
    " is chosen in the input field Design Power Sizing Method")]
[JsonProperty(PropertyName="design_power_consumption", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignPowerConsumption { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This is the motor efficiency only. When the Design Power Consumption is autosized" +
    " using PowerPerFlowPerPressure, the Design Shaft Power per Unit Flow Rate per Un" +
    "it Head is used in addition to the motor efficiency.")]
[JsonProperty(PropertyName="motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_of_motor_inefficiencies_to_fluid_stream", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfMotorInefficienciesToFluidStream { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="coefficient_1_of_the_part_load_performance_curve", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1OfThePartLoadPerformanceCurve { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="coefficient_2_of_the_part_load_performance_curve", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2OfThePartLoadPerformanceCurve { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="coefficient_3_of_the_part_load_performance_curve", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3OfThePartLoadPerformanceCurve { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="coefficient_4_of_the_part_load_performance_curve", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient4OfThePartLoadPerformanceCurve { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This value can be zero and will be defaulted to that if not specified.")]
[JsonProperty(PropertyName="minimum_flow_rate_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumFlowRateFraction { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pump_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HeaderedPumps_VariableSpeed_PumpControlType PumpControlType { get; set; } = (HeaderedPumps_VariableSpeed_PumpControlType)Enum.Parse(typeof(HeaderedPumps_VariableSpeed_PumpControlType), "Continuous");
        

[Description("Modifies the rated flow rate of the pump on a time basis. Default is that the pum" +
    "p is on and runs according to its other operational requirements specified above" +
    ". The schedule is for special pump operations.")]
[JsonProperty(PropertyName="pump_flow_rate_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PumpFlowRateScheduleName { get; set; } = "";
        

[Description("optional, if used pump losses transfered to zone as internal gains")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("optional. If zone identified in previous field then this determines the split bet" +
    "ween convection and radiation for the skin losses")]
[JsonProperty(PropertyName="skin_loss_radiative_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SkinLossRadiativeFraction { get; set; } = null;
        

[Description(@"Used to indicate which sizing factor is used to calculate Design Power Consumption. PowerPerFlow indicates that Design Electric Power per Unit Flow Rate is used as scaling factor. Design Power Consumption = Design Maximum Flow Rate * scaling factor PowerPerFlowPerPressure indicates that Design Shaft Power per Unit Flow Rate per Unit Head is used as scaling factor. Design Power Consumption = Design Maximum Flow Rate * Design Pump Head * scaling factor / Motor Efficiency")]
[JsonProperty(PropertyName="design_power_sizing_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HeaderedPumps_VariableSpeed_DesignPowerSizingMethod DesignPowerSizingMethod { get; set; } = (HeaderedPumps_VariableSpeed_DesignPowerSizingMethod)Enum.Parse(typeof(HeaderedPumps_VariableSpeed_DesignPowerSizingMethod), "PowerPerFlowPerPressure");
        

[Description("Used to size Design Power Consumption from design flow rate")]
[JsonProperty(PropertyName="design_electric_power_per_unit_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignElectricPowerPerUnitFlowRate { get; set; } = Double.Parse("348701.1", CultureInfo.InvariantCulture);
        

[Description("Used to size Design Power Consumption from design flow rate for head and motor ef" +
    "ficiency")]
[JsonProperty(PropertyName="design_shaft_power_per_unit_flow_rate_per_unit_head", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignShaftPowerPerUnitFlowRatePerUnitHead { get; set; } = Double.Parse("1.282051282", CultureInfo.InvariantCulture);
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    public enum HeaderedPumps_VariableSpeed_FlowSequencingControlScheme
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Sequential")]
        Sequential = 1,
    }
    
    public enum HeaderedPumps_VariableSpeed_PumpControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Continuous")]
        Continuous = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Intermittent")]
        Intermittent = 2,
    }
    
    public enum HeaderedPumps_VariableSpeed_DesignPowerSizingMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PowerPerFlow")]
        PowerPerFlow = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PowerPerFlowPerPressure")]
        PowerPerFlowPerPressure = 2,
    }
}
