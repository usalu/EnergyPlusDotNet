namespace EnergyPlus.HumidifiersandDehumidifiers
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
    
    
    [Description("Electrically heated steam humidifier with fan.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Humidifier_Steam_Electric
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("Capacity is m3/s of water at 5.05 C")]
[JsonProperty(PropertyName="rated_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> RatedCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("if autosized the rated power is calculated from the rated capacity and enthalpy r" +
    "ise of water from 20.0C to 100.0C steam and assumes electric to thermal energy c" +
    "onversion efficiency of 100.0%")]
[JsonProperty(PropertyName="rated_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> RatedPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="rated_fan_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedFanPower { get; set; } = null;
        

[JsonProperty(PropertyName="standby_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StandbyPower { get; set; } = null;
        

[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="water_storage_tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterStorageTankName { get; set; } = "";
    }
    
    [Description("Natural gas fired steam humidifier with optional blower fan.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Humidifier_Steam_Gas
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("Capacity is m3/s of water at 5.05 C The nominal full capacity water addition rate" +
    " in m3/s of water at 5.05 C")]
[JsonProperty(PropertyName="rated_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> RatedCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"if auto-sized, the rated gas use rate is calculated from the rated capacity and enthalpy rise of water from 20.0C to 100.0C steam and user input thermal efficiency value specified in the next input field. If this input field is hard-sized and Inlet Water Temperature Option input field is selected as FixedInletWaterTemperature, then the thermal efficiency input field will not be used or else if the Inlet Water Temperature Option input field is selected as VariableInletWaterTemperature, then the thermal efficiency input value is overridden by a value calculated from the capacity, rated gas use rate and design condition.")]
[JsonProperty(PropertyName="rated_gas_use_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> RatedGasUseRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Based on the higher heating value of fuel. If ""Rated Gas Use Rate"" in the field above is not auto-sized and the Inlet Water Temperature Option input field is specified as FixedInletWaterTemperature, then the thermal efficiency specified will not be used in the calculation, or else if the Inlet Water Temperature Option input field is selected as VariableInletWaterTemperature, then the thermal efficiency value is overridden by a value calculated from the capacity, rated gas use rate and design condition.")]
[JsonProperty(PropertyName="thermal_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalEfficiency { get; set; } = Double.Parse("0.8", CultureInfo.InvariantCulture);
        

[Description(@"Linear, Quadratic and Cubic efficiency curves are solely a function of PLR. Linear = C1 + C2*PLR Quadratic = C1 + C2*PLR + C3*PLR^2 Cubic = C1 + C2*PLR + C3*PLR^2 + C4*PLR^3 This is thermal efficiency modifier curve name of gas fired steam humidifier. This curve is normalized, i.e., curve output value at rated condition is 1.0.")]
[JsonProperty(PropertyName="thermal_efficiency_modifier_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ThermalEfficiencyModifierCurveName { get; set; } = "";
        

[Description("The nominal full capacity electric power input to the blower fan in Watts. If no " +
    "blower fan is required to inject the dry steam to the supply air stream, then th" +
    "is input field is set to zero.")]
[JsonProperty(PropertyName="rated_fan_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedFanPower { get; set; } = null;
        

[Description("The auxiliary electric power input in watts. This amount of power will be consume" +
    "d whenever the unit is available (as defined by the availability schedule). This" +
    " electric power is used for control purpose only.")]
[JsonProperty(PropertyName="auxiliary_electric_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AuxiliaryElectricPower { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="water_storage_tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterStorageTankName { get; set; } = "";
        

[Description(@"The inlet water temperature can be fixed at 20C as it is done for electric steam humidifier or it can be allowed to vary with temperature of the water source. Currently allowed water sources are main water or water storage tank in water use objects. if FixedInletWaterTemperature is specified, then a fixed 20C water temperature will be used, or else if VariableInletWaterTemperature is specified, then inlet water will vary depending the source water temperature. If this input field is left blank, then fixed inlet water temperature of 20C will be assumed.")]
[JsonProperty(PropertyName="inlet_water_temperature_option", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Humidifier_Steam_Gas_InletWaterTemperatureOption InletWaterTemperatureOption { get; set; } = (Humidifier_Steam_Gas_InletWaterTemperatureOption)Enum.Parse(typeof(Humidifier_Steam_Gas_InletWaterTemperatureOption), "FixedInletWaterTemperature");
    }
    
    public enum Humidifier_Steam_Gas_InletWaterTemperatureOption
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedInletWaterTemperature")]
        FixedInletWaterTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableInletWaterTemperature")]
        VariableInletWaterTemperature = 2,
    }
    
    [Description(@"This object models a solid desiccant dehumidifier. The process air stream is the air which is dehumidified. The regeneration air stream is the air which is heated to regenerate the desiccant. This object determines the process air outlet conditions, the load on the regeneration heating coil, the electric power consumption for the wheel rotor motor, and the regeneration air fan mass flow rate. All other heat exchangers are modeled as separate objects connected to the inlet and outlet nodes of the dehumidifier. The solid desiccant dehumidifier is typically used in an AirLoopHVAC:OutdoorAirSystem, but can also be specified in any AirLoopHVAC.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Dehumidifier_Desiccant_NoFans
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("This is the node entering the process side of the desiccant wheel.")]
[JsonProperty(PropertyName="process_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ProcessAirInletNodeName { get; set; } = "";
        

[Description("This is the node leaving the process side of the desiccant wheel.")]
[JsonProperty(PropertyName="process_air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ProcessAirOutletNodeName { get; set; } = "";
        

[Description("This is the node entering the regeneration side of the desiccant wheel after the " +
    "regeneration coil.")]
[JsonProperty(PropertyName="regeneration_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RegenerationAirInletNodeName { get; set; } = "";
        

[Description("Node for air entering the regeneration fan, mass flow is set by the desiccant deh" +
    "umidifier module.")]
[JsonProperty(PropertyName="regeneration_fan_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RegenerationFanInletNodeName { get; set; } = "";
        

[Description(@"Type of setpoint control: LeavingMaximumHumidityRatioSetpoint means that the unit is controlled to deliver air at the Leaving Max Humidity Ratio Setpoint (see below), SystemNodeMaximumHumidityRatioSetpoint means that the leaving humidity ratio setpoint is the System Node Humidity Ratio Max property of the Process Air Outlet Node. A Setpoint object must be used to control this setpoint. Both control types use bypass dampers to prevent over drying.")]
[JsonProperty(PropertyName="control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Dehumidifier_Desiccant_NoFans_ControlType ControlType { get; set; } = (Dehumidifier_Desiccant_NoFans_ControlType)Enum.Parse(typeof(Dehumidifier_Desiccant_NoFans_ControlType), "LeavingMaximumHumidityRatioSetpoint");
        

[Description("Fixed setpoint for maximum process air leaving humidity ratio Applicable only whe" +
    "n Control Type = LeavingMaximumHumidityRatioSetpoint.")]
[JsonProperty(PropertyName="leaving_maximum_humidity_ratio_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LeavingMaximumHumidityRatioSetpoint { get; set; } = null;
        

[Description("Process air flow rate at nominal conditions")]
[JsonProperty(PropertyName="nominal_process_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NominalProcessAirFlowRate { get; set; } = null;
        

[Description("Process air velocity at nominal flow When using Performance Model Type of Default" +
    ", must be 2.032 to 4.064 m/s (400 to 800 fpm)")]
[JsonProperty(PropertyName="nominal_process_air_velocity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NominalProcessAirVelocity { get; set; } = null;
        

[Description("Power input to wheel rotor motor")]
[JsonProperty(PropertyName="rotor_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RotorPower { get; set; } = null;
        

[Description("heating coil type works with gas, electric, hot water and steam heating coils")]
[JsonProperty(PropertyName="regeneration_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Dehumidifier_Desiccant_NoFans_RegenerationCoilObjectType RegenerationCoilObjectType { get; set; } = (Dehumidifier_Desiccant_NoFans_RegenerationCoilObjectType)Enum.Parse(typeof(Dehumidifier_Desiccant_NoFans_RegenerationCoilObjectType), "CoilHeatingElectric");
        

[Description("Name of heating coil object for regeneration air")]
[JsonProperty(PropertyName="regeneration_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RegenerationCoilName { get; set; } = "";
        

[Description("Type of fan object for regeneration air. When using the Default Performance Model" +
    " Type (see below), only Fan:VariableVolume or Fan:SystemModel are valid.")]
[JsonProperty(PropertyName="regeneration_fan_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Dehumidifier_Desiccant_NoFans_RegenerationFanObjectType RegenerationFanObjectType { get; set; } = (Dehumidifier_Desiccant_NoFans_RegenerationFanObjectType)Enum.Parse(typeof(Dehumidifier_Desiccant_NoFans_RegenerationFanObjectType), "FanConstantVolume");
        

[Description("Name of fan object for regeneration air")]
[JsonProperty(PropertyName="regeneration_fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RegenerationFanName { get; set; } = "";
        

[Description(@"Specifies whether the default performance model or user-specified curves should be used to model the performance. The default model is a generic solid desiccant wheel using performance curves of the form: curve = C1 + C2*edb + C3*edb**2 + C4*ew + C5*ew**2 + C6*vel + C7*vel**2 + C8*edb*ew + C9*edb**2*ew**2 + C10*edb*vel + C11*edb**2*vel**2 + C12*ew*vel + C13*ew**2*vel**2 + C14*ALOG(edb) + C15*ALOG(ew) + C16*ALOG(vel) edb = process entering dry-bulb temperature [C] ew  = process entering humidity ratio [kgWater/kgDryAir] vel = process air velocity [m/s] If UserCurves are specified, then performance is calculated as follows: Leaving Dry-Bulb = (Leaving Dry-Bulb fTW Curve) * (Leaving Dry-Bulb fV Curve) Leaving Humidity Ratio = (Leaving Humidity Ratio fTW Curve) * (Leaving Humidity Ratio fV Curve) Regen Energy = (Regen Energy fTW Curve) * (Regen Energy fV Curve) Regen Velocity = (Regen Velocity fTW Curve) * (Regen Velocity fV Curve)")]
[JsonProperty(PropertyName="performance_model_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Dehumidifier_Desiccant_NoFans_PerformanceModelType PerformanceModelType { get; set; } = (Dehumidifier_Desiccant_NoFans_PerformanceModelType)Enum.Parse(typeof(Dehumidifier_Desiccant_NoFans_PerformanceModelType), "Default");
        

[Description(@"Leaving dry-bulb of process air as a function of entering dry-bulb and entering humidity ratio, biquadratic curve curve = C1 + C2*edb + C3*edb**2 + C4*ew + C5*ew**2 + C6*edb*ew edb = process entering dry-bulb temperature [C] ew  = process entering humidity ratio [kgWater/kgDryAir]")]
[JsonProperty(PropertyName="leaving_dry_bulb_function_of_entering_dry_bulb_and_humidity_ratio_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string LeavingDryBulbFunctionOfEnteringDryBulbAndHumidityRatioCurveName { get; set; } = "";
        

[Description("Leaving dry-bulb of process air as a function of air velocity, quadratic curve. c" +
    "urve = C1 + C2*v + C3*v**2 v = process air velocity [m/s]")]
[JsonProperty(PropertyName="leaving_dry_bulb_function_of_air_velocity_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string LeavingDryBulbFunctionOfAirVelocityCurveName { get; set; } = "";
        

[Description(@"Leaving humidity ratio of process air as a function of entering dry-bulb and entering humidity ratio, biquadratic curve curve = C1 + C2*edb + C3*edb**2 + C4*ew + C5*ew**2 + C6*edb*ew edb = process entering dry-bulb temperature [C] ew  = process entering humidity ratio [kgWater/kgDryAir]")]
[JsonProperty(PropertyName="leaving_humidity_ratio_function_of_entering_dry_bulb_and_humidity_ratio_curve_nam" +
    "e", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string LeavingHumidityRatioFunctionOfEnteringDryBulbAndHumidityRatioCurveName { get; set; } = "";
        

[Description("Leaving humidity ratio of process air as a function of process air velocity, quad" +
    "ratic curve. curve = C1 + C2*v + C3*v**2 v = process air velocity [m/s]")]
[JsonProperty(PropertyName="leaving_humidity_ratio_function_of_air_velocity_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string LeavingHumidityRatioFunctionOfAirVelocityCurveName { get; set; } = "";
        

[Description(@"Regeneration energy [J/kg of water removed] as a function of entering dry-bulb and entering humidity ratio, biquadratic curve curve = C1 + C2*edb + C3*edb**2 + C4*ew + C5*ew**2 + C6*edb*ew edb = process entering dry-bulb temperature [C] ew  = process entering humidity ratio [kgWater/kgDryAir]")]
[JsonProperty(PropertyName="regeneration_energy_function_of_entering_dry_bulb_and_humidity_ratio_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RegenerationEnergyFunctionOfEnteringDryBulbAndHumidityRatioCurveName { get; set; } = "";
        

[Description("Regeneration energy [J/kg of water removed] as a function of process air velocity" +
    ", quadratic curve. curve = C1 + C2*v + C3*v**2 v = process air velocity [m/s]")]
[JsonProperty(PropertyName="regeneration_energy_function_of_air_velocity_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RegenerationEnergyFunctionOfAirVelocityCurveName { get; set; } = "";
        

[Description(@"Regeneration velocity [m/s] as a function of entering dry-bulb and entering humidity ratio, biquadratic curve curve = C1 + C2*edb + C3*edb**2 + C4*ew + C5*ew**2 + C6*edb*ew edb = process entering dry-bulb temperature [C] ew  = process entering humidity ratio [kgWater/kgDryAir]")]
[JsonProperty(PropertyName="regeneration_velocity_function_of_entering_dry_bulb_and_humidity_ratio_curve_name" +
    "", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RegenerationVelocityFunctionOfEnteringDryBulbAndHumidityRatioCurveName { get; set; } = "";
        

[Description("Regeneration velocity [m/s] as a function of process air velocity, quadratic curv" +
    "e. curve = C1 + C2*v + C3*v**2 v = process air velocity [m/s]")]
[JsonProperty(PropertyName="regeneration_velocity_function_of_air_velocity_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RegenerationVelocityFunctionOfAirVelocityCurveName { get; set; } = "";
        

[Description("Nominal regen temperature upon which the regen energy modifier curve is based. No" +
    "t used if Default if chosen for the field Performance Mode Type. 121 C is a comm" +
    "only used value.")]
[JsonProperty(PropertyName="nominal_regeneration_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NominalRegenerationTemperature { get; set; } = null;
    }
    
    public enum Dehumidifier_Desiccant_NoFans_ControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="LeavingMaximumHumidityRatioSetpoint")]
        LeavingMaximumHumidityRatioSetpoint = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SystemNodeMaximumHumidityRatioSetpoint")]
        SystemNodeMaximumHumidityRatioSetpoint = 1,
    }
    
    public enum Dehumidifier_Desiccant_NoFans_RegenerationCoilObjectType
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
    
    public enum Dehumidifier_Desiccant_NoFans_RegenerationFanObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:ConstantVolume")]
        FanConstantVolume = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:SystemModel")]
        FanSystemModel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:VariableVolume")]
        FanVariableVolume = 2,
    }
    
    public enum Dehumidifier_Desiccant_NoFans_PerformanceModelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Default")]
        Default = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurves")]
        UserCurves = 1,
    }
    
    [Description(@"This compound object models a desiccant heat exchanger, an optional heater, and associated fans. The process air stream is the air which is dehumidified. The regeneration air stream is the air which is heated to regenerate the desiccant. The desiccant heat exchanger transfers both sensible and latent energy between the process and regeneration air streams. The desiccant dehumidifier is typically used in an AirLoopHVAC:OutdoorAirSystem, but can also be specified in any AirLoopHVAC.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Dehumidifier_Desiccant_System
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="desiccant_heat_exchanger_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Dehumidifier_Desiccant_System_DesiccantHeatExchangerObjectType DesiccantHeatExchangerObjectType { get; set; } = (Dehumidifier_Desiccant_System_DesiccantHeatExchangerObjectType)Enum.Parse(typeof(Dehumidifier_Desiccant_System_DesiccantHeatExchangerObjectType), "HeatExchangerDesiccantBalancedFlow");
        

[JsonProperty(PropertyName="desiccant_heat_exchanger_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesiccantHeatExchangerName { get; set; } = "";
        

[JsonProperty(PropertyName="sensor_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SensorNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="regeneration_air_fan_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Dehumidifier_Desiccant_System_RegenerationAirFanObjectType RegenerationAirFanObjectType { get; set; } = (Dehumidifier_Desiccant_System_RegenerationAirFanObjectType)Enum.Parse(typeof(Dehumidifier_Desiccant_System_RegenerationAirFanObjectType), "FanConstantVolume");
        

[JsonProperty(PropertyName="regeneration_air_fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RegenerationAirFanName { get; set; } = "";
        

[JsonProperty(PropertyName="regeneration_air_fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Dehumidifier_Desiccant_System_RegenerationAirFanPlacement RegenerationAirFanPlacement { get; set; } = (Dehumidifier_Desiccant_System_RegenerationAirFanPlacement)Enum.Parse(typeof(Dehumidifier_Desiccant_System_RegenerationAirFanPlacement), "DrawThrough");
        

[Description(@"works with gas, electric, hot water and steam heating coils. For autosizing the regeneration air heating coil the Design Coil Inlet Air Condition used is the outdoor air condition if the desiccant system is on the primary air loop, or else if the desiccant system is on outdoor air system then it is the return air condition. The Design Coil Outlet Air Temperature is the Regeneration Inlet Air Setpoint Temperature specified in the input field below.")]
[JsonProperty(PropertyName="regeneration_air_heater_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Dehumidifier_Desiccant_System_RegenerationAirHeaterObjectType RegenerationAirHeaterObjectType { get; set; } = (Dehumidifier_Desiccant_System_RegenerationAirHeaterObjectType)Enum.Parse(typeof(Dehumidifier_Desiccant_System_RegenerationAirHeaterObjectType), "CoilHeatingElectric");
        

[JsonProperty(PropertyName="regeneration_air_heater_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RegenerationAirHeaterName { get; set; } = "";
        

[Description("This value is also used as regeneration air heater design coil air outlet tempera" +
    "ture for autosizing calculation of the heater.")]
[JsonProperty(PropertyName="regeneration_inlet_air_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RegenerationInletAirSetpointTemperature { get; set; } = Double.Parse("46", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="companion_cooling_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Dehumidifier_Desiccant_System_CompanionCoolingCoilObjectType CompanionCoolingCoilObjectType { get; set; } = (Dehumidifier_Desiccant_System_CompanionCoolingCoilObjectType)Enum.Parse(typeof(Dehumidifier_Desiccant_System_CompanionCoolingCoilObjectType), "CoilCoolingDXSingleSpeed");
        

[JsonProperty(PropertyName="companion_cooling_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CompanionCoolingCoilName { get; set; } = "";
        

[Description("Select Yes if the companion cooling coil is located directly upstream of the desi" +
    "ccant heat exchanger\'s process air inlet node.")]
[JsonProperty(PropertyName="companion_cooling_coil_upstream_of_dehumidifier_process_inlet", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes CompanionCoolingCoilUpstreamOfDehumidifierProcessInlet { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[JsonProperty(PropertyName="companion_coil_regeneration_air_heating", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes CompanionCoilRegenerationAirHeating { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[JsonProperty(PropertyName="exhaust_fan_maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ExhaustFanMaximumFlowRate { get; set; } = null;
        

[JsonProperty(PropertyName="exhaust_fan_maximum_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ExhaustFanMaximumPower { get; set; } = null;
        

[Description("Curve object type must be Curve:Quadratic or Curve:Cubic")]
[JsonProperty(PropertyName="exhaust_fan_power_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ExhaustFanPowerCurveName { get; set; } = "";
    }
    
    public enum Dehumidifier_Desiccant_System_DesiccantHeatExchangerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchanger:Desiccant:BalancedFlow")]
        HeatExchangerDesiccantBalancedFlow = 0,
    }
    
    public enum Dehumidifier_Desiccant_System_RegenerationAirFanObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:ConstantVolume")]
        FanConstantVolume = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:OnOff")]
        FanOnOff = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:SystemModel")]
        FanSystemModel = 2,
    }
    
    public enum Dehumidifier_Desiccant_System_RegenerationAirFanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum Dehumidifier_Desiccant_System_RegenerationAirHeaterObjectType
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
    
    public enum Dehumidifier_Desiccant_System_CompanionCoolingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:SingleSpeed")]
        CoilCoolingDXSingleSpeed = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:TwoStageWithHumidityControlMode")]
        CoilCoolingDXTwoStageWithHumidityControlMode = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:VariableSpeed")]
        CoilCoolingDXVariableSpeed = 2,
    }
}
