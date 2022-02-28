namespace EnergyPlus.EvaporativeCoolers
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
    
    
    [Description("Direct evaporative cooler with rigid media evaporative pad and recirculating wate" +
        "r pump. This model has no controls other than its availability schedule.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class EvaporativeCooler_Direct_CelDekPad
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="direct_pad_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DirectPadArea { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="direct_pad_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DirectPadDepth { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="recirculating_water_pump_power_consumption", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RecirculatingWaterPumpPowerConsumption { get; set; } = null;
        

[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[Description("This field is not currently used and can be left blank")]
[JsonProperty(PropertyName="control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlType { get; set; } = "";
        

[JsonProperty(PropertyName="water_supply_storage_tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterSupplyStorageTankName { get; set; } = "";
    }
    
    [Description("Indirect evaporative cooler with rigid media evaporative pad, recirculating water" +
        " pump, and secondary air fan. This model has no controls other than its availabi" +
        "lity schedule.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class EvaporativeCooler_Indirect_CelDekPad
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="direct_pad_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DirectPadArea { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="direct_pad_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DirectPadDepth { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="recirculating_water_pump_power_consumption", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RecirculatingWaterPumpPowerConsumption { get; set; } = null;
        

[JsonProperty(PropertyName="secondary_air_fan_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SecondaryAirFanFlowRate { get; set; } = null;
        

[JsonProperty(PropertyName="secondary_air_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SecondaryAirFanTotalEfficiency { get; set; } = null;
        

[JsonProperty(PropertyName="secondary_air_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SecondaryAirFanDeltaPressure { get; set; } = null;
        

[JsonProperty(PropertyName="indirect_heat_exchanger_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> IndirectHeatExchangerEffectiveness { get; set; } = null;
        

[JsonProperty(PropertyName="primary_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PrimaryAirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="primary_air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PrimaryAirOutletNodeName { get; set; } = "";
        

[Description("This field is not currently used and can be left blank")]
[JsonProperty(PropertyName="control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlType { get; set; } = "";
        

[JsonProperty(PropertyName="water_supply_storage_tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterSupplyStorageTankName { get; set; } = "";
        

[Description("Enter the name of an outdoor air node")]
[JsonProperty(PropertyName="secondary_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SecondaryAirInletNodeName { get; set; } = "";
    }
    
    [Description("Indirect evaporative cooler with wetted coil, recirculating water pump, and secon" +
        "dary air fan. This model has no controls other than its availability schedule.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class EvaporativeCooler_Indirect_WetCoil
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="coil_maximum_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoilMaximumEfficiency { get; set; } = null;
        

[JsonProperty(PropertyName="coil_flow_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoilFlowRatio { get; set; } = null;
        

[JsonProperty(PropertyName="recirculating_water_pump_power_consumption", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RecirculatingWaterPumpPowerConsumption { get; set; } = null;
        

[JsonProperty(PropertyName="secondary_air_fan_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SecondaryAirFanFlowRate { get; set; } = null;
        

[JsonProperty(PropertyName="secondary_air_fan_total_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SecondaryAirFanTotalEfficiency { get; set; } = null;
        

[JsonProperty(PropertyName="secondary_air_fan_delta_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SecondaryAirFanDeltaPressure { get; set; } = null;
        

[JsonProperty(PropertyName="primary_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PrimaryAirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="primary_air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PrimaryAirOutletNodeName { get; set; } = "";
        

[Description("This field is not currently used and can be left blank")]
[JsonProperty(PropertyName="control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlType { get; set; } = "";
        

[JsonProperty(PropertyName="water_supply_storage_tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterSupplyStorageTankName { get; set; } = "";
        

[Description("Enter the name of an outdoor air node")]
[JsonProperty(PropertyName="secondary_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SecondaryAirInletNodeName { get; set; } = "";
    }
    
    [Description("Indirect evaporative cooler with user-specified effectiveness (can represent rigi" +
        "d pad or wetted coil), recirculating water pump, and secondary air fan. This mod" +
        "el is controlled to meet the primary air outlet temperature setpoint.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class EvaporativeCooler_Indirect_ResearchSpecial
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("wet operation effectiveness with respect to wetbulb depression this is the nomina" +
    "l design wetbulb effectiveness at design air flow rates and water rate")]
[JsonProperty(PropertyName="cooler_wetbulb_design_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolerWetbulbDesignEffectiveness { get; set; } = null;
        

[Description(@"this curve modifies the wetbulb effectiveness in the previous field (eff_wb_design) by multiplying the value by the result of this curve, eff_wb = eff_wb_design * func(HXFlowRatio) x = HXFlowRatio = sum of the primary and secondary flow rates divided by the sum of the design flow rates. If this input field is left blank, constant cooler wetbulb effectiveness is assumed. This input field is required in order to use operating range control based on the following three input fields: Evaporative Operation Minimum Limit Secondary Air Drybulb Temperature, Evaporative Operation Maximum Limit Outdoor Wetbulb Temperature, and Dry Operation Maximum Limit Outdoor Drybulb Temperature")]
[JsonProperty(PropertyName="wetbulb_effectiveness_flow_ratio_modifier_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WetbulbEffectivenessFlowRatioModifierCurveName { get; set; } = "";
        

[Description("dry operation effectiveness with respect to drybulb temperature difference this i" +
    "s the nominal design dryblub effectiveness at design air flow rates, no evaporat" +
    "ion water active")]
[JsonProperty(PropertyName="cooler_drybulb_design_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolerDrybulbDesignEffectiveness { get; set; } = null;
        

[Description(@"this curve modifies the drybulb effectiveness in the previous field (eff_db_design) by multiplying the value by the result of this curve, eff_db = eff_db_design * f(HXFlowRatio) x = HXFlowRatio = sum of the primary and secondary flow rates divided by the sum of the design flow rates. If this input field is left blank, constant cooler drybulb effectiveness is assumed. This input field is required in order to use operating range control based on the following three input fields: Evaporative Operation Minimum Limit Secondary Air Drybulb Temperature, Evaporative Operation Maximum Limit Outdoor Wetbulb Temperature, and Dry Operation Maximum Limit Outdoor Drybulb Temperature")]
[JsonProperty(PropertyName="drybulb_effectiveness_flow_ratio_modifier_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DrybulbEffectivenessFlowRatioModifierCurveName { get; set; } = "";
        

[Description("This is the nominal design pump power of water recirculation and spray for evapor" +
    "ation at design air flow rates and cooler design effectiveness")]
[JsonProperty(PropertyName="recirculating_water_pump_design_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> RecirculatingWaterPumpDesignPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"This field is used when the previous field is set to autosize. The pump power is scaled with Secondary Air Design Air Flow Rate. This value was backed out from inputs in energy plus example files. Average Pump Power sizing factor was estimated from pump power and secondary air design flow rates inputs from energyplus example files is about 90.0 [W/(m3/s)] (=90.0 ~ Pump Power / Secondary Air Design Flow Rate). The factor ranges from 55.0 to 150.0 [W/(m3/s)] were noted. The pump power can be sized to zero by setting this factor to zero.")]
[JsonProperty(PropertyName="water_pump_power_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterPumpPowerSizingFactor { get; set; } = Double.Parse("90", CultureInfo.InvariantCulture);
        

[Description(@"this curve modifies the pump power in the previous field by multiplying the design power by the result of this curve. x = ff = flow fraction on the secondary side, secondary air flow rate during operation divided by Secondary Air Design Air Flow Rate. If this input field is left blank, pump power is assumed to be proportional to part load ratio.")]
[JsonProperty(PropertyName="water_pump_power_modifier_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterPumpPowerModifierCurveName { get; set; } = "";
        

[JsonProperty(PropertyName="secondary_air_design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SecondaryAirDesignFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is used when the previous field is set to autoize. The Primary Design " +
    "Air Flow Rate is scaled using this factor to calculate the secondary design air " +
    "flow rate.")]
[JsonProperty(PropertyName="secondary_air_flow_scaling_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SecondaryAirFlowScalingFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("This is the fan design power at Secondary Design Air Flow Rate. This is the nomin" +
    "al design power at full speed.")]
[JsonProperty(PropertyName="secondary_air_fan_design_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SecondaryAirFanDesignPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is used when the previous field is set to autosize. The fan power is s" +
    "caled with Secondary Air Design Flow Rate. The default value is estimated from 1" +
    "25 Pa fan total pressure and fan total efficiency of 50.0% (250.0 = 125/0.5).")]
[JsonProperty(PropertyName="secondary_air_fan_sizing_specific_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SecondaryAirFanSizingSpecificPower { get; set; } = Double.Parse("250", CultureInfo.InvariantCulture);
        

[Description(@"this curve modifies the design fan power in the previous field by multiplying the value by the result of this curve. It should have a value of 1.0 at a x = 1.0. x = ff = flow fraction on the secondary side, secondary air flow rate during operation divided by Secondary Air Design Air Flow Rate. If this input field is left blank, the secondary fan power is assumed to be proportional to part load ratio.")]
[JsonProperty(PropertyName="secondary_air_fan_power_modifier_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SecondaryAirFanPowerModifierCurveName { get; set; } = "";
        

[JsonProperty(PropertyName="primary_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PrimaryAirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="primary_air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PrimaryAirOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="primary_air_design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> PrimaryAirDesignFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="dewpoint_effectiveness_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointEffectivenessFactor { get; set; } = null;
        

[JsonProperty(PropertyName="secondary_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SecondaryAirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="secondary_air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SecondaryAirOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="sensor_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SensorNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="relief_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReliefAirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="water_supply_storage_tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterSupplyStorageTankName { get; set; } = "";
        

[Description("Rate of drift loss as a fraction of evaporated water flow rate. If this input fie" +
    "ld is left blank, then zero drift loss is assumed.")]
[JsonProperty(PropertyName="drift_loss_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DriftLossFraction { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description(@"Characterizes the rate of blowdown in the evaporative cooler. Blowdown is water intentionally drained from the cooler in order to offset the build up of solids in the water that would otherwise occur because of evaporation. Ratio of solids in the blowdown water to solids in the make up water. A typical value is 3. If left blank then there is no blowdown.")]
[JsonProperty(PropertyName="blowdown_concentration_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BlowdownConcentrationRatio { get; set; } = null;
        

[Description(@"This input field value defines the secondary air inlet node drybulb temperature limits in degreeCelsius. When the secondary side entering air dry bulb temperature drops below this limit, then the evaporative cooler operation mode changes to dry heat exchanger. Users specify their own limits. If this field is left blank, then there is no drybulb temperature lower limit for evaporative cooler operation. If operating range control is desired then this input field and the next two input fields should be specified or all the three should be left blank or left out. If no minimum drybulb temperature limit is desired while there are maximum drybulb and wetbulb temperature limits then specify very low minimum temperature limit value (e.g. -99.0C).")]
[JsonProperty(PropertyName="evaporative_operation_minimum_limit_secondary_air_drybulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvaporativeOperationMinimumLimitSecondaryAirDrybulbTemperature { get; set; } = null;
        

[Description(@"This input field value defines the secondary air inlet node wetbulb temperature limits in degree Celsius. When the secondary side entering air wet bulb temperature exceeds this limit, then the evaporative cooler urns off and does not attempt to do any cooling. If this field is left blank, then there is no wetbulb temperature upper limit for evaporative cooler wet operation mode. If this input field is left blank then, the previous and the next input fields should also be left blank. If no maximum wetbulb temperature limits is desired while there are minimum drybulb and maximum drybulb upper temperature limits then specify very high maximum wetbulb temperature limit value (e.g. 99.0 C).")]
[JsonProperty(PropertyName="evaporative_operation_maximum_limit_outdoor_wetbulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvaporativeOperationMaximumLimitOutdoorWetbulbTemperature { get; set; } = null;
        

[Description(@"This input field value defines the secondary air inlet node drybulb temperature limits in degree Celsius. When the secondary side entering air drybulb temperature exceeds this limit, then the evaporative cooler will not run in dry operation mode or may be turned off depending on its wetbulb temperature. If this field is left blank, then there is no drybulb temperature maximum limit for evaporative cooler operation. If this input field is left blank then, the previous and the next input fields should also be left blank. If no maximum drybulb temperature limit is desired while there are minimum drybulb and maximum wetbulb upper temperature limits then specify very high maximum drybulb temperature limit value (e.g. 99.0 C).")]
[JsonProperty(PropertyName="dry_operation_maximum_limit_outdoor_drybulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryOperationMaximumLimitOutdoorDrybulbTemperature { get; set; } = null;
    }
    
    [Description("Direct evaporative cooler with user-specified effectiveness (can represent rigid " +
        "pad or similar media), and recirculating water pump, and secondary air fan. This" +
        " model is controlled to meet the primary air outlet temperature setpoint.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class EvaporativeCooler_Direct_ResearchSpecial
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("effectiveness with respect to wet-bulb depression")]
[JsonProperty(PropertyName="cooler_design_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolerDesignEffectiveness { get; set; } = null;
        

[Description(@"this curve modifies the design effectiveness in the previous field by multiplying the value by the result of this curve. The effectiveness flow modifier curve is a function of flow fraction. Flow fraction is the ratio of current primary air flow rate to the primary air design flow rate. If this input field is left blank then, the effectiveness is assumed to be constant.")]
[JsonProperty(PropertyName="effectiveness_flow_ratio_modifier_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EffectivenessFlowRatioModifierCurveName { get; set; } = "";
        

[JsonProperty(PropertyName="primary_air_design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> PrimaryAirDesignFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This is the design water pump or spray for evaporation at the primary air design " +
    "air flow rates and cooler design effectiveness")]
[JsonProperty(PropertyName="recirculating_water_pump_design_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> RecirculatingWaterPumpDesignPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"This field is used when the previous field is set to autosize. The pump power is scaled with Primary Air Design Air Flow Rate. This value was backed out from inputs in energy plus example files. Average Pump Power sizing factor was estimated from pump power and primary air design flow rates inputs from energyplus example files is about 90.0 [W/(m3/s)] (=90.0 ~ Pump Power / Primary Air Design Flow Rate). The factor ranges from 55.0 to 150.0 [W/(m3/s)]. The pump power can be sized to zero by setting this factor to zero.")]
[JsonProperty(PropertyName="water_pump_power_sizing_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterPumpPowerSizingFactor { get; set; } = Double.Parse("90", CultureInfo.InvariantCulture);
        

[Description(@"this curve modifies the pump power in the previous field by multiplying the design power by the result of this curve. x = ff = flow fraction on the primary air. The flow fraction is the primary air flow rate during current operation divided by Primary Air Design Flow Rate")]
[JsonProperty(PropertyName="water_pump_power_modifier_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterPumpPowerModifierCurveName { get; set; } = "";
        

[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="sensor_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SensorNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="water_supply_storage_tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterSupplyStorageTankName { get; set; } = "";
        

[Description("Rate of drift loss as a fraction of evaporated water flow rate")]
[JsonProperty(PropertyName="drift_loss_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DriftLossFraction { get; set; } = null;
        

[Description(@"Characterizes the rate of blowdown in the evaporative cooler. Blowdown is water intentionally drained from the cooler in order to offset the build up of solids in the water that would otherwise occur because of evaporation. Ratio of solids in the blowdown water to solids in the make up water. A typical value is 3. If left blank then there is no blowdown.")]
[JsonProperty(PropertyName="blowdown_concentration_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BlowdownConcentrationRatio { get; set; } = null;
        

[Description(@"This numeric field defines the evaporative cooler air inlet node drybulb temperature minimum limit in degrees Celsius. The evaporative cooler will be turned off when the evaporator cooler air inlet node dry-bulb temperature falls below this limit. The typical minimum value is 16degC. Users are allowed to specify their own limits. If this field is left blank, then there is no drybulb lower temperature limit for evaporative cooler operation.")]
[JsonProperty(PropertyName="evaporative_operation_minimum_drybulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvaporativeOperationMinimumDrybulbTemperature { get; set; } = null;
        

[Description(@"when outdoor wetbulb temperature rises above this limit the cooler shuts down. This numeric field defines the evaporative cooler air inlet node wet-bulb temperature maximum limit in degrees Celsius. The evaporative cooler will be turned off when the evaporative cooler air inlet node wet-bulb temperature exceeds this limit. The typical maximum value is 24degC. Users are allowed to specify their own limits. If this field is left blank, then there is no upper wetbulb temperature limit for evaporative cooler operation.")]
[JsonProperty(PropertyName="evaporative_operation_maximum_limit_wetbulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvaporativeOperationMaximumLimitWetbulbTemperature { get; set; } = null;
        

[Description(@"This numeric field defines the evaporative cooler air inlet node dry-bulb temperature maximum limit in degrees Celsius. The evaporative cooler will be turned off when its air inlet node drybulb temperature exceeds this limit. The typical maximum value is 26degC. Users are allowed to specify their own limits. If this field is left blank, then there is no upper temperature limit for evaporative cooler operation.")]
[JsonProperty(PropertyName="evaporative_operation_maximum_limit_drybulb_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvaporativeOperationMaximumLimitDrybulbTemperature { get; set; } = null;
    }
}
