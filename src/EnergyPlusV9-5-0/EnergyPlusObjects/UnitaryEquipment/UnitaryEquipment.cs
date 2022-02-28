namespace EnergyPlus.UnitaryEquipment
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
    
    
    [Description(@"AirloopHVAC:UnitarySystem is a generic HVAC system type that allows any configuration of coils and/or fan. This object is a replacement of other AirloopHVAC objects. This object can be used in outdoor air systems, outdoor air units, air loops, and as zone equipment if desired.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class AirLoopHVAC_UnitarySystem
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description(@"Load control requires a Controlling Zone name. SetPoint control requires set points at coil outlet node. SingleZoneVAV also requires a Controlling Zone name and allows load control at low speed fan until the load exceeds capacity or outlet air temperature limits. The fan speed is then increased.")]
[JsonProperty(PropertyName="control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitarySystem_ControlType ControlType { get; set; } = (AirLoopHVAC_UnitarySystem_ControlType)Enum.Parse(typeof(AirLoopHVAC_UnitarySystem_ControlType), "Load");
        

[Description("Used only for Load based control Zone name where thermostat is located. Required " +
    "when Control Type = Load.")]
[JsonProperty(PropertyName="controlling_zone_or_thermostat_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControllingZoneOrThermostatLocation { get; set; } = "";
        

[Description(@"None = meet sensible load only. Required when Control Type = SingleZoneVAV. Multimode = activate enhanced dehumidification mode as needed and meet sensible load. Valid only with cooling coil type Coil:Cooling:DX:TwoStageWithHumidityControlMode or CoilSystem:Cooling:DX:HeatExchangerAssisted. This control mode either switches the coil mode or allows the heat exchanger to be turned on and off based on the zone dehumidification requirements. A ZoneControl:Humidistat object is also required. CoolReheat = cool beyond the dry-bulb setpoint. as required to meet the humidity setpoint. Valid with all cooling coil types. When a heat exchanger assisted cooling coil is used, the heat exchanger is locked on at all times. A ZoneControl:Humidistat object is also required.")]
[JsonProperty(PropertyName="dehumidification_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitarySystem_DehumidificationControlType DehumidificationControlType { get; set; } = (AirLoopHVAC_UnitarySystem_DehumidificationControlType)Enum.Parse(typeof(AirLoopHVAC_UnitarySystem_DehumidificationControlType), "None");
        

[Description(@"Availability schedule name for this system. Schedule value > 0 means the system is available. If this field is blank, the system is always available. A schedule value greater than zero (usually 1 is used) indicates that the unit is available to operate as needed. A value less than or equal to zero (usually zero is used) denotes that the unit must be off.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("Enter the node name used as the inlet air node for the unitary system.")]
[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[Description("Enter the node name used as the outlet air node for the unitary system.")]
[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[Description(@"Enter the type of supply air fan if included in the unitary system. Fan:ConstantVolume only works with continuous fan operating mode (i.e. supply air fan operating mode schedule values greater than 0). Specify a Fan:SystemModel or a Fan:OnOff object when the Supply Air Fan Operating Mode Schedule Name input field above is left blank. Specify a Fan:SystemModel or a Fan:VariableVolume when modeling VAV systems which used setpoint based control if the fan is included in the unitary system object. The ComponentModel fan type may be substituted for the ConstantVolume or VariableVolume fan types when more detailed fan modeling is required. The variable or constant volume fan may be specified on the branch instead of contained within the unitary system object (i.e., this field may be blank for certain configurations).")]
[JsonProperty(PropertyName="supply_fan_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitarySystem_SupplyFanObjectType SupplyFanObjectType { get; set; } = (AirLoopHVAC_UnitarySystem_SupplyFanObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitarySystem_SupplyFanObjectType), "FanComponentModel");
        

[Description("Enter the name of the supply air fan if included in the unitary system.")]
[JsonProperty(PropertyName="supply_fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyFanName { get; set; } = "";
        

[Description("Enter the type of supply air fan if included in the unitary system.")]
[JsonProperty(PropertyName="fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitarySystem_FanPlacement FanPlacement { get; set; } = (AirLoopHVAC_UnitarySystem_FanPlacement)Enum.Parse(typeof(AirLoopHVAC_UnitarySystem_FanPlacement), "BlowThrough");
        

[Description(@"A fan operating mode schedule value of 0 indicates cycling fan mode (supply air fan cycles on and off in tandem with the cooling or heating coil). Any other schedule value indicates continuous fan mode (supply air fan operates continuously regardless of cooling or heating coil operation). Provide a schedule with non-zero values when high humidity control is specified. Leaving this schedule name blank will default to constant fan mode for the entire simulation period. This field is not used when set point based control is used where a set point controls the coil. SingleZoneVAV control type is only active when constant fan operating mode is active.")]
[JsonProperty(PropertyName="supply_air_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanOperatingModeScheduleName { get; set; } = "";
        

[Description("Enter the type of heating coil if included in the unitary system.")]
[JsonProperty(PropertyName="heating_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitarySystem_HeatingCoilObjectType HeatingCoilObjectType { get; set; } = (AirLoopHVAC_UnitarySystem_HeatingCoilObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitarySystem_HeatingCoilObjectType), "CoilHeatingDXMultiSpeed");
        

[Description("Enter the name of the heating coil if included in the unitary system.")]
[JsonProperty(PropertyName="heating_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilName { get; set; } = "";
        

[Description("Used to adjust heat pump heating capacity with respect to DX cooling capacity use" +
    "d only for heat pump configurations (i.e., a DX cooling and DX heating coil is u" +
    "sed).")]
[JsonProperty(PropertyName="dx_heating_coil_sizing_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DxHeatingCoilSizingRatio { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Enter the type of cooling coil if included in the unitary system.")]
[JsonProperty(PropertyName="cooling_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitarySystem_CoolingCoilObjectType CoolingCoilObjectType { get; set; } = (AirLoopHVAC_UnitarySystem_CoolingCoilObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitarySystem_CoolingCoilObjectType), "CoilCoolingDX");
        

[Description("Enter the name of the cooling coil if included in the unitary system.")]
[JsonProperty(PropertyName="cooling_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilName { get; set; } = "";
        

[Description("If Yes, the DX cooling coil runs as 100% DOAS DX coil. If No, the DX cooling coil" +
    " runs as a regular DX coil. If left blank the default is regular dx coil.")]
[JsonProperty(PropertyName="use_doas_dx_cooling_coil", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes UseDoasDxCoolingCoil { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description(@"When Use DOAS DX Cooling Coil is specified as Yes, Minimum Supply Air Temperature defines the minimum DOAS DX cooling coil leaving air temperature that should be maintained to avoid frost formation. This field is not autosizable when the input for Use DOAS DX Cooling Coil = Yes. When Control Type = SingleZoneVAV, enter the minimum air temperature limit for reduced fan speed.")]
[JsonProperty(PropertyName="minimum_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MinimumSupplyAirTemperature { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"SensibleOnlyLoadControl is selected when thermostat or SingleZoneVAV control is used. LatentOnlyLoadControl is selected when humidistat control is used. LatentWithSensibleLoadControl is selected when thermostat control is used and dehumidification is required only when a sensible load exists. LatentOrSensibleLoadControl is selected when thermostat control is used and dehumidification is required any time the humidistat set point is exceeded.")]
[JsonProperty(PropertyName="latent_load_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitarySystem_LatentLoadControl LatentLoadControl { get; set; } = (AirLoopHVAC_UnitarySystem_LatentLoadControl)Enum.Parse(typeof(AirLoopHVAC_UnitarySystem_LatentLoadControl), "SensibleOnlyLoadControl");
        

[Description(@"Enter the type of supplemental heating or reheat coil if included in the unitary system. Only required if dehumidification control type is ""CoolReheat"". This coil supplements heating mode operation or reheats the supply air during dehumidification mode operation. If set point based control is used the coils operate to meet their respective supply air temperature set point.")]
[JsonProperty(PropertyName="supplemental_heating_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitarySystem_SupplementalHeatingCoilObjectType SupplementalHeatingCoilObjectType { get; set; } = (AirLoopHVAC_UnitarySystem_SupplementalHeatingCoilObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitarySystem_SupplementalHeatingCoilObjectType), "CoilHeatingDesuperheater");
        

[Description("Enter the name of the supplemental heating coil if included in the unitary system" +
    ". Only required if dehumidification control type is \"CoolReheat\".")]
[JsonProperty(PropertyName="supplemental_heating_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplementalHeatingCoilName { get; set; } = "";
        

[Description(@"Enter the method used to determine the cooling supply air volume flow rate. None is used when a cooling coil is not included in the unitary system or this field may be blank. SupplyAirFlowRate is selected when the magnitude of the supply air volume is used. FlowPerFloorArea is selected when the supply air volume flow rate is based on total floor area served by the unitary system. FractionOfAutosizedCoolingValue is selected when the supply air volume is a fraction of the value determined by the simulation. FlowPerCoolingCapacity is selected when the supply air volume is a fraction of the cooling capacity as determined by the simulation.")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitarySystem_CoolingSupplyAirFlowRateMethod CoolingSupplyAirFlowRateMethod { get; set; } = (AirLoopHVAC_UnitarySystem_CoolingSupplyAirFlowRateMethod)Enum.Parse(typeof(AirLoopHVAC_UnitarySystem_CoolingSupplyAirFlowRateMethod), "FlowPerCoolingCapacity");
        

[Description("Enter the magnitude of the supply air volume flow rate during cooling operation. " +
    "Required field when Cooling Supply Air Flow Rate Method is SupplyAirFlowRate. Th" +
    "is field may be blank if a cooling coil is not included in the unitary system.")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the supply air volume flow rate per total floor area fraction. Required fie" +
    "ld when Cooling Supply Air Flow Rate Method is FlowPerFloorArea. This field may " +
    "be blank if a cooling coil is not included in the unitary system.")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingSupplyAirFlowRatePerFloorArea { get; set; } = null;
        

[Description(@"Enter the supply air volume flow rate as a fraction of the cooling supply air flow rate. Required field when Cooling Supply Air Flow Rate Method is FractionOfAutosizedCoolingValue. This field may be blank if a cooling coil is not included in the unitary system.")]
[JsonProperty(PropertyName="cooling_fraction_of_autosized_cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingFractionOfAutosizedCoolingSupplyAirFlowRate { get; set; } = null;
        

[Description("Enter the supply air volume flow rate as a fraction of the cooling capacity. Requ" +
    "ired field when Cooling Supply Air Flow Rate Method is FlowPerCoolingCapacity. T" +
    "his field may be blank if a cooling coil is not included in the unitary system.")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate_per_unit_of_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingSupplyAirFlowRatePerUnitOfCapacity { get; set; } = null;
        

[Description(@"Enter the method used to determine the heating supply air volume flow rate. None is used when a heating coil is not included in the unitary system or this field may be blank. SupplyAirFlowRate is selected when the magnitude of the supply air volume is used. FlowPerFloorArea is selected when the supply air volume flow rate is based on total floor area served by the unitary system. FractionOfAutosizedHeatingValue is selected when the supply air volume is a fraction of the value determined by the simulation. FlowPerHeatingCapacity is selected when the supply air volume is a fraction of the heating capacity as determined by the simulation.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitarySystem_HeatingSupplyAirFlowRateMethod HeatingSupplyAirFlowRateMethod { get; set; } = (AirLoopHVAC_UnitarySystem_HeatingSupplyAirFlowRateMethod)Enum.Parse(typeof(AirLoopHVAC_UnitarySystem_HeatingSupplyAirFlowRateMethod), "FlowPerFloorArea");
        

[Description("Enter the magnitude of the supply air volume flow rate during heating operation. " +
    "Required field when Heating Supply Air Flow Rate Method is SupplyAirFlowRate. Th" +
    "is field may be blank if a heating coil is not included in the unitary system.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the supply air volume flow rate per total floor area fraction. Required fie" +
    "ld when Heating Supply Air Flow Rate Method is FlowPerFloorArea. This field may " +
    "be blank if a heating coil is not included in the unitary system.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingSupplyAirFlowRatePerFloorArea { get; set; } = null;
        

[Description(@"Enter the supply air volume flow rate as a fraction of the heating supply air flow rate. Required field when Heating Supply Air Flow Rate Method is FractionOfAutosizedHeatingValue. This field may be blank if a heating coil is not included in the unitary system.")]
[JsonProperty(PropertyName="heating_fraction_of_autosized_heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingFractionOfAutosizedHeatingSupplyAirFlowRate { get; set; } = null;
        

[Description("Enter the supply air volume flow rate as a fraction of the heating capacity. Requ" +
    "ired field when Heating Supply Air Flow Rate Method is FlowPerHeatingCapacity. T" +
    "his field may be blank if a heating coil is not included in the unitary system.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate_per_unit_of_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingSupplyAirFlowRatePerUnitOfCapacity { get; set; } = null;
        

[Description(@"Enter the method used to determine the supply air volume flow rate when no cooling or heating is required. None is used when a cooling and heating coil is not included in the unitary system or this field may be blank. SupplyAirFlowRate is selected when the magnitude of the supply air volume is used. FlowPerFloorArea is selected when the supply air volume flow rate is based on total floor area served by the unitary system. FractionOfAutosizedCoolingValue is selected when the supply air volume is a fraction of the cooling value determined by the simulation. FractionOfAutosizedHeatingValue is selected when the supply air volume is a fraction of the heating value determined by the simulation. FlowPerCoolingCapacity is selected when the supply air volume is a fraction of the cooling capacity as determined by the simulation. FlowPerHeatingCapacity is selected when the supply air volume is a fraction of the heating capacity as determined by the simulation.")]
[JsonProperty(PropertyName="no_load_supply_air_flow_rate_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitarySystem_NoLoadSupplyAirFlowRateMethod NoLoadSupplyAirFlowRateMethod { get; set; } = (AirLoopHVAC_UnitarySystem_NoLoadSupplyAirFlowRateMethod)Enum.Parse(typeof(AirLoopHVAC_UnitarySystem_NoLoadSupplyAirFlowRateMethod), "FlowPerCoolingCapacity");
        

[Description("Enter the magnitude of the supply air volume flow rate during when no cooling or " +
    "heating is required. Required field when No Load Supply Air Flow Rate Method is " +
    "SupplyAirFlowRate.")]
[JsonProperty(PropertyName="no_load_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoLoadSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the supply air volume flow rate per total floor area fraction. Required fie" +
    "ld when No Load Supply Air Flow Rate Method is FlowPerFloorArea.")]
[JsonProperty(PropertyName="no_load_supply_air_flow_rate_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NoLoadSupplyAirFlowRatePerFloorArea { get; set; } = null;
        

[Description("Enter the supply air volume flow rate as a fraction of the cooling supply air flo" +
    "w rate. Required field when No Load Supply Air Flow Rate Method is FractionOfAut" +
    "osizedCoolingValue.")]
[JsonProperty(PropertyName="no_load_fraction_of_autosized_cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NoLoadFractionOfAutosizedCoolingSupplyAirFlowRate { get; set; } = null;
        

[Description("Enter the supply air volume flow rate as a fraction of the heating supply air flo" +
    "w rate. Required field when No Load Supply Air Flow Rate Method is FractionOfAut" +
    "osizedHeatingValue.")]
[JsonProperty(PropertyName="no_load_fraction_of_autosized_heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NoLoadFractionOfAutosizedHeatingSupplyAirFlowRate { get; set; } = null;
        

[Description("Enter the supply air volume flow rate as a fraction of the cooling capacity. Requ" +
    "ired field when No Load Supply Air Flow Rate Method is FlowPerCoolingCapacity.")]
[JsonProperty(PropertyName="no_load_supply_air_flow_rate_per_unit_of_capacity_during_cooling_operation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NoLoadSupplyAirFlowRatePerUnitOfCapacityDuringCoolingOperation { get; set; } = null;
        

[Description("Enter the supply air volume flow rate as a fraction of the heating capacity. Requ" +
    "ired field when No Load Supply Air Flow Rate Method is FlowPerHeatingCapacity.")]
[JsonProperty(PropertyName="no_load_supply_air_flow_rate_per_unit_of_capacity_during_heating_operation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NoLoadSupplyAirFlowRatePerUnitOfCapacityDuringHeatingOperation { get; set; } = null;
        

[Description("Enter the maximum supply air temperature leaving the heating coil. When Control T" +
    "ype = SingleZoneVAV, enter the maximum air temperature limit for reduced fan spe" +
    "ed.")]
[JsonProperty(PropertyName="maximum_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumSupplyAirTemperature { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the maximum outdoor dry-bulb temperature for supplemental heater operation." +
    "")]
[JsonProperty(PropertyName="maximum_outdoor_dry_bulb_temperature_for_supplemental_heater_operation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumOutdoorDryBulbTemperatureForSupplementalHeaterOperation { get; set; } = Double.Parse("21", CultureInfo.InvariantCulture);
        

[Description("If this field is blank, outdoor temperature from the weather file is used. If thi" +
    "s field is not blank, the node name specified determines the outdoor temperature" +
    " used for controlling supplemental heater operation.")]
[JsonProperty(PropertyName="outdoor_dry_bulb_temperature_sensor_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorDryBulbTemperatureSensorNodeName { get; set; } = "";
        

[Description("Used only for water source heat pump. The maximum on-off cycling rate for the com" +
    "pressor. Suggested value is 2.5 for a typical heat pump.")]
[JsonProperty(PropertyName="maximum_cycling_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCyclingRate { get; set; } = Double.Parse("2.5", CultureInfo.InvariantCulture);
        

[Description("Used only for water source heat pump. Time constant for the cooling coil\'s capaci" +
    "ty to reach steady state after startup. Suggested value is 60 for a typical heat" +
    " pump.")]
[JsonProperty(PropertyName="heat_pump_time_constant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatPumpTimeConstant { get; set; } = Double.Parse("60", CultureInfo.InvariantCulture);
        

[Description("Used only for water source heat pump. The fraction of on-cycle power use to adjus" +
    "t the part load fraction based on the off-cycle power consumption due to crankca" +
    "se heaters, controls, fans, and etc. Suggested value is 0.01 for a typical heat " +
    "pump.")]
[JsonProperty(PropertyName="fraction_of_on_cycle_power_use", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfOnCyclePowerUse { get; set; } = Double.Parse("0.01", CultureInfo.InvariantCulture);
        

[Description("Used only for water source heat pump. Programmed time delay for heat pump fan to " +
    "shut off after compressor cycle off. Only required when fan operating mode is cy" +
    "cling. Enter 0 when fan operating mode is continuous.")]
[JsonProperty(PropertyName="heat_pump_fan_delay_time", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatPumpFanDelayTime { get; set; } = Double.Parse("60", CultureInfo.InvariantCulture);
        

[Description("Enter the value of ancillary electric power for controls or other devices consume" +
    "d during the on cycle.")]
[JsonProperty(PropertyName="ancillary_on_cycle_electric_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AncillaryOnCycleElectricPower { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Enter the value of ancillary electric power for controls or other devices consume" +
    "d during the off cycle.")]
[JsonProperty(PropertyName="ancillary_off_cycle_electric_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AncillaryOffCycleElectricPower { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("If non-zero, then the heat recovery inlet and outlet node names must be entered. " +
    "Used for heat recovery to an EnergyPlus plant loop.")]
[JsonProperty(PropertyName="design_heat_recovery_water_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignHeatRecoveryWaterFlowRate { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Enter the maximum heat recovery inlet temperature allowed for heat recovery.")]
[JsonProperty(PropertyName="maximum_temperature_for_heat_recovery", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumTemperatureForHeatRecovery { get; set; } = Double.Parse("80", CultureInfo.InvariantCulture);
        

[Description("Enter the name of the heat recovery water inlet node if plant water loop connecti" +
    "ons are present.")]
[JsonProperty(PropertyName="heat_recovery_water_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatRecoveryWaterInletNodeName { get; set; } = "";
        

[Description("Enter the name of the heat recovery water outlet node if plant water loop connect" +
    "ions are present.")]
[JsonProperty(PropertyName="heat_recovery_water_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatRecoveryWaterOutletNodeName { get; set; } = "";
        

[Description("Enter the type of performance specification object used to describe the multispee" +
    "d coil.")]
[JsonProperty(PropertyName="design_specification_multispeed_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitarySystem_DesignSpecificationMultispeedObjectType DesignSpecificationMultispeedObjectType { get; set; } = (AirLoopHVAC_UnitarySystem_DesignSpecificationMultispeedObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitarySystem_DesignSpecificationMultispeedObjectType), "UnitarySystemPerformanceMultispeed");
        

[Description("Enter the name of the performance specification object used to describe the multi" +
    "speed coil.")]
[JsonProperty(PropertyName="design_specification_multispeed_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationMultispeedObjectName { get; set; } = "";
    }
    
    public enum AirLoopHVAC_UnitarySystem_ControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Load")]
        Load = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SetPoint")]
        SetPoint = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="SingleZoneVAV")]
        SingleZoneVAV = 3,
    }
    
    public enum AirLoopHVAC_UnitarySystem_DehumidificationControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolReheat")]
        CoolReheat = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Multimode")]
        Multimode = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    public enum AirLoopHVAC_UnitarySystem_SupplyFanObjectType
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
    
    public enum AirLoopHVAC_UnitarySystem_FanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 1,
    }
    
    public enum AirLoopHVAC_UnitarySystem_HeatingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:DX:MultiSpeed")]
        CoilHeatingDXMultiSpeed = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:DX:SingleSpeed")]
        CoilHeatingDXSingleSpeed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:DX:VariableSpeed")]
        CoilHeatingDXVariableSpeed = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Desuperheater")]
        CoilHeatingDesuperheater = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric")]
        CoilHeatingElectric = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric:MultiStage")]
        CoilHeatingElectricMultiStage = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Fuel")]
        CoilHeatingFuel = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Gas:MultiStage")]
        CoilHeatingGasMultiStage = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Steam")]
        CoilHeatingSteam = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Water")]
        CoilHeatingWater = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:WaterToAirHeatPump:EquationFit")]
        CoilHeatingWaterToAirHeatPumpEquationFit = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:WaterToAirHeatPump:ParameterEstimation")]
        CoilHeatingWaterToAirHeatPumpParameterEstimation = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:WaterToAirHeatPump:VariableSpeedEquationFit")]
        CoilHeatingWaterToAirHeatPumpVariableSpeedEquationFit = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:UserDefined")]
        CoilUserDefined = 13,
    }
    
    public enum AirLoopHVAC_UnitarySystem_CoolingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX")]
        CoilCoolingDX = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:MultiSpeed")]
        CoilCoolingDXMultiSpeed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:SingleSpeed")]
        CoilCoolingDXSingleSpeed = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:SingleSpeed:ThermalStorage")]
        CoilCoolingDXSingleSpeedThermalStorage = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:TwoSpeed")]
        CoilCoolingDXTwoSpeed = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:TwoStageWithHumidityControlMode")]
        CoilCoolingDXTwoStageWithHumidityControlMode = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:VariableSpeed")]
        CoilCoolingDXVariableSpeed = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water")]
        CoilCoolingWater = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water:DetailedGeometry")]
        CoilCoolingWaterDetailedGeometry = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:WaterToAirHeatPump:EquationFit")]
        CoilCoolingWaterToAirHeatPumpEquationFit = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:WaterToAirHeatPump:ParameterEstimation")]
        CoilCoolingWaterToAirHeatPumpParameterEstimation = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:WaterToAirHeatPump:VariableSpeedEquationFit")]
        CoilCoolingWaterToAirHeatPumpVariableSpeedEquationFit = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:UserDefined")]
        CoilUserDefined = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:DX:HeatExchangerAssisted")]
        CoilSystemCoolingDXHeatExchangerAssisted = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:Water:HeatExchangerAssisted")]
        CoilSystemCoolingWaterHeatExchangerAssisted = 14,
    }
    
    public enum AirLoopHVAC_UnitarySystem_LatentLoadControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="LatentOnlyLoadControl")]
        LatentOnlyLoadControl = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="LatentOrSensibleLoadControl")]
        LatentOrSensibleLoadControl = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="LatentWithSensibleLoadControl")]
        LatentWithSensibleLoadControl = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="SensibleOnlyLoadControl")]
        SensibleOnlyLoadControl = 4,
    }
    
    public enum AirLoopHVAC_UnitarySystem_SupplementalHeatingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Desuperheater")]
        CoilHeatingDesuperheater = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric")]
        CoilHeatingElectric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Fuel")]
        CoilHeatingFuel = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Steam")]
        CoilHeatingSteam = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Water")]
        CoilHeatingWater = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:UserDefined")]
        CoilUserDefined = 5,
    }
    
    public enum AirLoopHVAC_UnitarySystem_CoolingSupplyAirFlowRateMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="FlowPerCoolingCapacity")]
        FlowPerCoolingCapacity = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FlowPerFloorArea")]
        FlowPerFloorArea = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedCoolingValue")]
        FractionOfAutosizedCoolingValue = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirFlowRate")]
        SupplyAirFlowRate = 4,
    }
    
    public enum AirLoopHVAC_UnitarySystem_HeatingSupplyAirFlowRateMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="FlowPerFloorArea")]
        FlowPerFloorArea = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FlowPerHeatingCapacity")]
        FlowPerHeatingCapacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedHeatingValue")]
        FractionOfAutosizedHeatingValue = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirFlowRate")]
        SupplyAirFlowRate = 4,
    }
    
    public enum AirLoopHVAC_UnitarySystem_NoLoadSupplyAirFlowRateMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="FlowPerCoolingCapacity")]
        FlowPerCoolingCapacity = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FlowPerFloorArea")]
        FlowPerFloorArea = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FlowPerHeatingCapacity")]
        FlowPerHeatingCapacity = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedCoolingValue")]
        FractionOfAutosizedCoolingValue = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedHeatingValue")]
        FractionOfAutosizedHeatingValue = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirFlowRate")]
        SupplyAirFlowRate = 6,
    }
    
    public enum AirLoopHVAC_UnitarySystem_DesignSpecificationMultispeedObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="UnitarySystemPerformance:Multispeed")]
        UnitarySystemPerformanceMultispeed = 0,
    }
    
    [Description(@"The UnitarySystemPerformance object is used to specify the air flow ratio at each operating speed. This object is primarily used for multispeed DX and water coils to allow operation at alternate flow rates different from those specified in the coil object.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class UnitarySystemPerformance_Multispeed
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Used only for Multi speed coils Enter the number of the following sets of data fo" +
    "r air flow rates.")]
[JsonProperty(PropertyName="number_of_speeds_for_heating", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfSpeedsForHeating { get; set; } = null;
        

[Description("Used only for Multi speed coils Enter the number of the following sets of data fo" +
    "r air flow rates.")]
[JsonProperty(PropertyName="number_of_speeds_for_cooling", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfSpeedsForCooling { get; set; } = null;
        

[Description(@"Controls coil operation during each HVAC timestep. This choice does not apply to speed 1 operation. Yes = operate at the highest speed possible without exceeding the current load. No = allow operation at the average of two adjacent speeds to match the current load.")]
[JsonProperty(PropertyName="single_mode_operation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes SingleModeOperation { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("Used to define the no load operating air flow rate when the system fan is specifi" +
    "ed to operate continuously.")]
[JsonProperty(PropertyName="no_load_supply_air_flow_rate_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NoLoadSupplyAirFlowRateRatio { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="flow_ratios", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.UnitaryEquipment.UnitarySystemPerformance_Multispeed_FlowRatios_Item> FlowRatios { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class UnitarySystemPerformance_Multispeed_FlowRatios_Item
    {
        

[JsonProperty(PropertyName="heating_speed_supply_air_flow_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingSpeedSupplyAirFlowRatio { get; set; } = "";
        

[JsonProperty(PropertyName="cooling_speed_supply_air_flow_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingSpeedSupplyAirFlowRatio { get; set; } = "";
    }
    
    [Description("Unitary system, heating-only with constant volume supply fan (continuous or cycli" +
        "ng) and heating coil (gas, electric, hot water, or steam). Identical to AirLoopH" +
        "VAC:UnitaryHeatOnly.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class AirLoopHVAC_Unitary_Furnace_HeatOnly
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="furnace_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FurnaceAirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="furnace_air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FurnaceAirOutletNodeName { get; set; } = "";
        

[Description(@"A fan operating mode schedule value of 0 indicates cycling fan mode (supply air fan cycles on and off in tandem with the heating coil). Any other schedule value indicates continuous fan mode (supply air fan operates continuously regardless of heating coil operation). Leaving this schedule name blank will default to cycling fan mode for the entire simulation period.")]
[JsonProperty(PropertyName="supply_air_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanOperatingModeScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumSupplyAirTemperature { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This value should be > 0 and <= than the fan air flow rate.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="controlling_zone_or_thermostat_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControllingZoneOrThermostatLocation { get; set; } = "";
        

[Description("Fan:ConstantVolume only works with continuous fan operating mode (i.e. fan operat" +
    "ing mode schedule values are greater than 0).")]
[JsonProperty(PropertyName="supply_fan_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_Unitary_Furnace_HeatOnly_SupplyFanObjectType SupplyFanObjectType { get; set; } = (AirLoopHVAC_Unitary_Furnace_HeatOnly_SupplyFanObjectType)Enum.Parse(typeof(AirLoopHVAC_Unitary_Furnace_HeatOnly_SupplyFanObjectType), "FanConstantVolume");
        

[JsonProperty(PropertyName="supply_fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyFanName { get; set; } = "";
        

[JsonProperty(PropertyName="fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_Unitary_Furnace_HeatOnly_FanPlacement FanPlacement { get; set; } = (AirLoopHVAC_Unitary_Furnace_HeatOnly_FanPlacement)Enum.Parse(typeof(AirLoopHVAC_Unitary_Furnace_HeatOnly_FanPlacement), "BlowThrough");
        

[Description("works with gas, electric, hot water and steam heating coils")]
[JsonProperty(PropertyName="heating_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_Unitary_Furnace_HeatOnly_HeatingCoilObjectType HeatingCoilObjectType { get; set; } = (AirLoopHVAC_Unitary_Furnace_HeatOnly_HeatingCoilObjectType)Enum.Parse(typeof(AirLoopHVAC_Unitary_Furnace_HeatOnly_HeatingCoilObjectType), "CoilHeatingElectric");
        

[JsonProperty(PropertyName="heating_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilName { get; set; } = "";
    }
    
    public enum AirLoopHVAC_Unitary_Furnace_HeatOnly_SupplyFanObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:ConstantVolume")]
        FanConstantVolume = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:OnOff")]
        FanOnOff = 1,
    }
    
    public enum AirLoopHVAC_Unitary_Furnace_HeatOnly_FanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum AirLoopHVAC_Unitary_Furnace_HeatOnly_HeatingCoilObjectType
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
    
    [Description(@"Unitary system, heating and cooling with constant volume supply fan (continuous or cycling), direct expansion (DX) cooling coil, heating coil (gas, electric, hot water, or steam), and optional reheat coil for dehumidification control. Identical to AirLoopHVAC:UnitaryHeatCool.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class AirLoopHVAC_Unitary_Furnace_HeatCool
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description(@"Availability schedule name for this system. Schedule value > 0 means the system is available. If this field is blank, the system is always available. A schedule value greater than zero (usually 1 is used) indicates that the unit is available to operate as needed. A value less than or equal to zero (usually zero is used) denotes that the unit must be off.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="furnace_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FurnaceAirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="furnace_air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FurnaceAirOutletNodeName { get; set; } = "";
        

[Description(@"A fan operating mode schedule value of 0 indicates cycling fan mode (supply air fan cycles on and off in tandem with the cooling or heating coil). Any other schedule value indicates continuous fan mode (supply air fan operates continuously regardless of cooling or heating coil operation). Provide a schedule with non-zero values when high humidity control is specified. Leaving this schedule name blank will default to cycling fan mode for the entire simulation period.")]
[JsonProperty(PropertyName="supply_air_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanOperatingModeScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumSupplyAirTemperature { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Must be less than or equal to the fan\'s maximum flow rate.")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Must be less than or equal to the fan\'s maximum flow fate.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Must be less than or equal to the fan's maximum flow rate. Only used when fan operating mode is continuous (disregarded for cycling fan mode). This air flow rate is used when no heating or cooling is required (i.e., the DX coil compressor and heating coil are off). If this field is left blank or zero, the supply air flow rate from the previous on cycle (either cooling or heating) is used.")]
[JsonProperty(PropertyName="no_load_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoLoadSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="controlling_zone_or_thermostat_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControllingZoneOrThermostatLocation { get; set; } = "";
        

[Description("Fan:ConstantVolume only works with continuous fan operating mode (i.e. supply air" +
    " fan operating mode schedule values not equal to 0).")]
[JsonProperty(PropertyName="supply_fan_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_Unitary_Furnace_HeatCool_SupplyFanObjectType SupplyFanObjectType { get; set; } = (AirLoopHVAC_Unitary_Furnace_HeatCool_SupplyFanObjectType)Enum.Parse(typeof(AirLoopHVAC_Unitary_Furnace_HeatCool_SupplyFanObjectType), "FanConstantVolume");
        

[JsonProperty(PropertyName="supply_fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyFanName { get; set; } = "";
        

[JsonProperty(PropertyName="fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_Unitary_Furnace_HeatCool_FanPlacement FanPlacement { get; set; } = (AirLoopHVAC_Unitary_Furnace_HeatCool_FanPlacement)Enum.Parse(typeof(AirLoopHVAC_Unitary_Furnace_HeatCool_FanPlacement), "BlowThrough");
        

[Description("works with gas, electric, hot water and steam heating coils")]
[JsonProperty(PropertyName="heating_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_Unitary_Furnace_HeatCool_HeatingCoilObjectType HeatingCoilObjectType { get; set; } = (AirLoopHVAC_Unitary_Furnace_HeatCool_HeatingCoilObjectType)Enum.Parse(typeof(AirLoopHVAC_Unitary_Furnace_HeatCool_HeatingCoilObjectType), "CoilHeatingElectric");
        

[JsonProperty(PropertyName="heating_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilName { get; set; } = "";
        

[Description("Only works with DX cooling coil types")]
[JsonProperty(PropertyName="cooling_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_Unitary_Furnace_HeatCool_CoolingCoilObjectType CoolingCoilObjectType { get; set; } = (AirLoopHVAC_Unitary_Furnace_HeatCool_CoolingCoilObjectType)Enum.Parse(typeof(AirLoopHVAC_Unitary_Furnace_HeatCool_CoolingCoilObjectType), "CoilCoolingDXSingleSpeed");
        

[JsonProperty(PropertyName="cooling_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilName { get; set; } = "";
        

[Description(@"None = meet sensible load only Multimode = activate enhanced dehumidification mode as needed and meet sensible load. Valid only with cooling coil type CoilSystem:Cooling:DX:HeatExchangerAssisted. This control mode allows the heat exchanger to be turned on and off based on the zone dehumidification requirements. A ZoneControl:Humidistat object is also required. CoolReheat = cool beyond the dry-bulb setpoint. as required to meet the humidity setpoint. Valid with all cooling coil types. When a heat exchanger assisted cooling coil is used, the heat exchanger is locked on at all times. A ZoneControl:Humidistat object is also required.")]
[JsonProperty(PropertyName="dehumidification_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_Unitary_Furnace_HeatCool_DehumidificationControlType DehumidificationControlType { get; set; } = (AirLoopHVAC_Unitary_Furnace_HeatCool_DehumidificationControlType)Enum.Parse(typeof(AirLoopHVAC_Unitary_Furnace_HeatCool_DehumidificationControlType), "None");
        

[Description("Only required if dehumidification control type is \"CoolReheat\" works with gas, el" +
    "ectric, hot water and steam heating coils")]
[JsonProperty(PropertyName="reheat_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_Unitary_Furnace_HeatCool_ReheatCoilObjectType ReheatCoilObjectType { get; set; } = (AirLoopHVAC_Unitary_Furnace_HeatCool_ReheatCoilObjectType)Enum.Parse(typeof(AirLoopHVAC_Unitary_Furnace_HeatCool_ReheatCoilObjectType), "CoilHeatingDesuperheater");
        

[Description("Only required if dehumidification control type is \"CoolReheat\"")]
[JsonProperty(PropertyName="reheat_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReheatCoilName { get; set; } = "";
    }
    
    public enum AirLoopHVAC_Unitary_Furnace_HeatCool_SupplyFanObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:ConstantVolume")]
        FanConstantVolume = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:OnOff")]
        FanOnOff = 1,
    }
    
    public enum AirLoopHVAC_Unitary_Furnace_HeatCool_FanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum AirLoopHVAC_Unitary_Furnace_HeatCool_HeatingCoilObjectType
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
    
    public enum AirLoopHVAC_Unitary_Furnace_HeatCool_CoolingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:SingleSpeed")]
        CoilCoolingDXSingleSpeed = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:VariableSpeed")]
        CoilCoolingDXVariableSpeed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:DX:HeatExchangerAssisted")]
        CoilSystemCoolingDXHeatExchangerAssisted = 2,
    }
    
    public enum AirLoopHVAC_Unitary_Furnace_HeatCool_DehumidificationControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolReheat")]
        CoolReheat = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Multimode")]
        Multimode = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    public enum AirLoopHVAC_Unitary_Furnace_HeatCool_ReheatCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Desuperheater")]
        CoilHeatingDesuperheater = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric")]
        CoilHeatingElectric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Fuel")]
        CoilHeatingFuel = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Steam")]
        CoilHeatingSteam = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Water")]
        CoilHeatingWater = 4,
    }
    
    [Description("Unitary system, heating-only with constant volume supply fan (continuous or cycli" +
        "ng) and heating coil (gas, electric, hot water, or steam). Identical to AirLoopH" +
        "VAC:Unitary:Furnace:HeatOnly.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class AirLoopHVAC_UnitaryHeatOnly
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="unitary_system_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UnitarySystemAirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="unitary_system_air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UnitarySystemAirOutletNodeName { get; set; } = "";
        

[Description(@"A fan operating mode schedule value of 0 indicates cycling fan mode (supply air fan cycles on and off in tandem with the heating coil). Any other schedule value indicates continuous fan mode (supply air fan operates continuously regardless of heating coil operation). Leaving this schedule name blank will default to cycling fan mode for the entire simulation period.")]
[JsonProperty(PropertyName="supply_air_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanOperatingModeScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumSupplyAirTemperature { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This value should be > 0 and <= than the fan air flow rate.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="controlling_zone_or_thermostat_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControllingZoneOrThermostatLocation { get; set; } = "";
        

[Description("Fan:ConstantVolume only works with continuous fan operating mode (i.e. fan operat" +
    "ing mode schedule values are greater than 0).")]
[JsonProperty(PropertyName="supply_fan_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatOnly_SupplyFanObjectType SupplyFanObjectType { get; set; } = (AirLoopHVAC_UnitaryHeatOnly_SupplyFanObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatOnly_SupplyFanObjectType), "FanConstantVolume");
        

[JsonProperty(PropertyName="supply_fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyFanName { get; set; } = "";
        

[JsonProperty(PropertyName="fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatOnly_FanPlacement FanPlacement { get; set; } = (AirLoopHVAC_UnitaryHeatOnly_FanPlacement)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatOnly_FanPlacement), "BlowThrough");
        

[Description("works with gas, electric, hot water and steam heating coils")]
[JsonProperty(PropertyName="heating_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatOnly_HeatingCoilObjectType HeatingCoilObjectType { get; set; } = (AirLoopHVAC_UnitaryHeatOnly_HeatingCoilObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatOnly_HeatingCoilObjectType), "CoilHeatingElectric");
        

[JsonProperty(PropertyName="heating_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilName { get; set; } = "";
    }
    
    public enum AirLoopHVAC_UnitaryHeatOnly_SupplyFanObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:ConstantVolume")]
        FanConstantVolume = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:OnOff")]
        FanOnOff = 1,
    }
    
    public enum AirLoopHVAC_UnitaryHeatOnly_FanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum AirLoopHVAC_UnitaryHeatOnly_HeatingCoilObjectType
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
    
    [Description(@"Unitary system, heating and cooling with constant volume supply fan (continuous or cycling), direct expansion (DX) cooling coil, heating coil (gas, electric, hot water, or steam), and optional reheat coil for dehumidification control. Identical to AirLoopHVAC:Unitary:Furnace:HeatCool.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class AirLoopHVAC_UnitaryHeatCool
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="unitary_system_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UnitarySystemAirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="unitary_system_air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UnitarySystemAirOutletNodeName { get; set; } = "";
        

[Description(@"A fan operating mode schedule value of 0 indicates cycling fan mode (supply air fan cycles on and off in tandem with the cooling or heating coil). Any other schedule value indicates continuous fan mode (supply air fan operates continuously regardless of cooling or heating coil operation). Provide a schedule with non-zero values when high humidity control is specified. Leaving this schedule name blank will default to cycling fan mode for the entire simulation period.")]
[JsonProperty(PropertyName="supply_air_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanOperatingModeScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_supply_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumSupplyAirTemperature { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Must be less than or equal to the fan\'s maximum flow rate.")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Must be less than or equal to the fan\'s maximum flow rate.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Must be less than or equal to the fan's maximum flow rate. Only used when fan operating mode is continuous (disregarded for cycling fan mode). This air flow rate is used when no heating or cooling is required (i.e., the DX coil compressor and heating coil are off). If this field is left blank or zero, the supply air flow rate from the previous on cycle (either cooling or heating) is used.")]
[JsonProperty(PropertyName="no_load_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoLoadSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="controlling_zone_or_thermostat_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControllingZoneOrThermostatLocation { get; set; } = "";
        

[Description("Fan:ConstantVolume only works with continuous fan operating mode (i.e. supply air" +
    " fan operating mode schedule values not equal to 0).")]
[JsonProperty(PropertyName="supply_fan_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatCool_SupplyFanObjectType SupplyFanObjectType { get; set; } = (AirLoopHVAC_UnitaryHeatCool_SupplyFanObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatCool_SupplyFanObjectType), "FanConstantVolume");
        

[JsonProperty(PropertyName="supply_fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyFanName { get; set; } = "";
        

[JsonProperty(PropertyName="fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatCool_FanPlacement FanPlacement { get; set; } = (AirLoopHVAC_UnitaryHeatCool_FanPlacement)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatCool_FanPlacement), "BlowThrough");
        

[Description("works with gas, electric, hot water and steam heating coils")]
[JsonProperty(PropertyName="heating_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatCool_HeatingCoilObjectType HeatingCoilObjectType { get; set; } = (AirLoopHVAC_UnitaryHeatCool_HeatingCoilObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatCool_HeatingCoilObjectType), "CoilHeatingElectric");
        

[JsonProperty(PropertyName="heating_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilName { get; set; } = "";
        

[Description("Only works with DX cooling coil types or Coil:Cooling:DX:VariableSpeed.")]
[JsonProperty(PropertyName="cooling_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatCool_CoolingCoilObjectType CoolingCoilObjectType { get; set; } = (AirLoopHVAC_UnitaryHeatCool_CoolingCoilObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatCool_CoolingCoilObjectType), "CoilCoolingDXSingleSpeed");
        

[JsonProperty(PropertyName="cooling_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilName { get; set; } = "";
        

[Description(@"None = meet sensible load only Multimode = activate enhanced dehumidification mode as needed and meet sensible load. Valid only with cooling coil type CoilSystem:Cooling:DX:HeatExchangerAssisted. This control mode allows the heat exchanger to be turned on and off based on the zone dehumidification requirements. A ZoneControl:Humidistat object is also required. CoolReheat = cool beyond the dry-bulb setpoint. as required to meet the humidity setpoint. Valid with all cooling coil types. When a heat exchanger assisted Cooling coil is used, the heat exchanger is locked on at all times. A ZoneControl:Humidistat object is also required.")]
[JsonProperty(PropertyName="dehumidification_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatCool_DehumidificationControlType DehumidificationControlType { get; set; } = (AirLoopHVAC_UnitaryHeatCool_DehumidificationControlType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatCool_DehumidificationControlType), "None");
        

[Description("Only required if dehumidification control type is \"CoolReheat\" works with gas, el" +
    "ectric, desuperheating, hot water and steam heating coils")]
[JsonProperty(PropertyName="reheat_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatCool_ReheatCoilObjectType ReheatCoilObjectType { get; set; } = (AirLoopHVAC_UnitaryHeatCool_ReheatCoilObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatCool_ReheatCoilObjectType), "CoilHeatingDesuperheater");
        

[Description("Only required if dehumidification control type is \"CoolReheat\"")]
[JsonProperty(PropertyName="reheat_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReheatCoilName { get; set; } = "";
    }
    
    public enum AirLoopHVAC_UnitaryHeatCool_SupplyFanObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:ConstantVolume")]
        FanConstantVolume = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:OnOff")]
        FanOnOff = 1,
    }
    
    public enum AirLoopHVAC_UnitaryHeatCool_FanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum AirLoopHVAC_UnitaryHeatCool_HeatingCoilObjectType
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
    
    public enum AirLoopHVAC_UnitaryHeatCool_CoolingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:SingleSpeed")]
        CoilCoolingDXSingleSpeed = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:VariableSpeed")]
        CoilCoolingDXVariableSpeed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:DX:HeatExchangerAssisted")]
        CoilSystemCoolingDXHeatExchangerAssisted = 2,
    }
    
    public enum AirLoopHVAC_UnitaryHeatCool_DehumidificationControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolReheat")]
        CoolReheat = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Multimode")]
        Multimode = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    public enum AirLoopHVAC_UnitaryHeatCool_ReheatCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Desuperheater")]
        CoilHeatingDesuperheater = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric")]
        CoilHeatingElectric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Fuel")]
        CoilHeatingFuel = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Steam")]
        CoilHeatingSteam = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Water")]
        CoilHeatingWater = 4,
    }
    
    [Description("Unitary heat pump system, heating and cooling, single-speed with supply fan, dire" +
        "ct expansion (DX) cooling coil, DX heating coil (air-to-air heat pump), and supp" +
        "lemental heating coil (gas, electric, hot water, or steam).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class AirLoopHVAC_UnitaryHeatPump_AirToAir
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description(@"Availability schedule name for this system. Schedule value > 0 means the system is available. If this field is blank, the system is always available. A schedule value greater than zero (usually 1 is used) indicates that the unit is available to operate as needed. A value less than or equal to zero (usually zero is used) denotes that the unit must be off.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[Description("Must be less than or equal to the fan\'s maximum flow rate.")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Must be less than or equal to the fan\'s maximum flow rate.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Must be less than or equal to the fan's maximum flow rate. Only used when fan operating mode is continuous (disregarded for cycling fan mode). This air flow rate is used when no heating or cooling is required (i.e., the DX coil compressor and supplemental heating coil are off). If this field is left blank or zero, the supply air flow rate from the previous on cycle (either cooling or heating) is used.")]
[JsonProperty(PropertyName="no_load_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoLoadSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="controlling_zone_or_thermostat_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControllingZoneOrThermostatLocation { get; set; } = "";
        

[Description("Fan:ConstantVolume only works with continuous fan operating mode (i.e. fan operat" +
    "ing mode schedule values are greater than 0 or the fan operating mode schedule n" +
    "ame field is left blank).")]
[JsonProperty(PropertyName="supply_air_fan_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatPump_AirToAir_SupplyAirFanObjectType SupplyAirFanObjectType { get; set; } = (AirLoopHVAC_UnitaryHeatPump_AirToAir_SupplyAirFanObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatPump_AirToAir_SupplyAirFanObjectType), "FanConstantVolume");
        

[Description("Needs to match in the fan object")]
[JsonProperty(PropertyName="supply_air_fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanName { get; set; } = "";
        

[Description("Only works with Coil:Heating:DX:SingleSpeed or Coil:Heating:DX:VariableSpeed or C" +
    "oilSystem:IntegratedHeatPump:AirSource")]
[JsonProperty(PropertyName="heating_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatPump_AirToAir_HeatingCoilObjectType HeatingCoilObjectType { get; set; } = (AirLoopHVAC_UnitaryHeatPump_AirToAir_HeatingCoilObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatPump_AirToAir_HeatingCoilObjectType), "CoilHeatingDXSingleSpeed");
        

[Description("Needs to match in the DX heating coil object")]
[JsonProperty(PropertyName="heating_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilName { get; set; } = "";
        

[Description("Only works with Coil:Cooling:DX:SingleSpeed or CoilSystem:Cooling:DX:HeatExchange" +
    "rAssisted or Coil:Cooling:DX:VariableSpeed or CoilSystem:IntegratedHeatPump:AirS" +
    "ource")]
[JsonProperty(PropertyName="cooling_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatPump_AirToAir_CoolingCoilObjectType CoolingCoilObjectType { get; set; } = (AirLoopHVAC_UnitaryHeatPump_AirToAir_CoolingCoilObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatPump_AirToAir_CoolingCoilObjectType), "CoilCoolingDXSingleSpeed");
        

[Description("Needs to match in the DX cooling coil object")]
[JsonProperty(PropertyName="cooling_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilName { get; set; } = "";
        

[Description("works with gas, electric, hot water and steam heating coils")]
[JsonProperty(PropertyName="supplemental_heating_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatPump_AirToAir_SupplementalHeatingCoilObjectType SupplementalHeatingCoilObjectType { get; set; } = (AirLoopHVAC_UnitaryHeatPump_AirToAir_SupplementalHeatingCoilObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatPump_AirToAir_SupplementalHeatingCoilObjectType), "CoilHeatingElectric");
        

[Description("Needs to match in the supplemental heating coil object")]
[JsonProperty(PropertyName="supplemental_heating_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplementalHeatingCoilName { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_supply_air_temperature_from_supplemental_heater", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumSupplyAirTemperatureFromSupplementalHeater { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_outdoor_dry_bulb_temperature_for_supplemental_heater_operation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumOutdoorDryBulbTemperatureForSupplementalHeaterOperation { get; set; } = Double.Parse("21", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatPump_AirToAir_FanPlacement FanPlacement { get; set; } = (AirLoopHVAC_UnitaryHeatPump_AirToAir_FanPlacement)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatPump_AirToAir_FanPlacement), "BlowThrough");
        

[Description(@"A fan operating mode schedule value of 0 indicates cycling fan mode (supply air fan cycles on and off in tandem with the cooling or heating coil). Any other schedule value indicates continuous fan mode (supply air fan operates continuously regardless of cooling or heating coil operation). Leaving this schedule name blank will default to cycling fan mode for the entire simulation period.")]
[JsonProperty(PropertyName="supply_air_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanOperatingModeScheduleName { get; set; } = "";
        

[Description(@"None = meet sensible load only Multimode = activate enhanced dehumidification mode as needed and meet sensible load. Valid only with cooling coil type CoilSystem:Cooling:DX:HeatExchangerAssisted. This control mode allows the heat exchanger to be turned on and off based on the zone dehumidification requirements. A ZoneControl:Humidistat object is also required. CoolReheat = cool beyond the dry-bulb setpoint. as required to meet the humidity setpoint. Valid with all cooling coil types. When a heat exchanger assisted Cooling coil is used, the heat exchanger is locked on at all times. A ZoneControl:Humidistat object is also required.")]
[JsonProperty(PropertyName="dehumidification_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatPump_AirToAir_DehumidificationControlType DehumidificationControlType { get; set; } = (AirLoopHVAC_UnitaryHeatPump_AirToAir_DehumidificationControlType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatPump_AirToAir_DehumidificationControlType), "None");
    }
    
    public enum AirLoopHVAC_UnitaryHeatPump_AirToAir_SupplyAirFanObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:ConstantVolume")]
        FanConstantVolume = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:OnOff")]
        FanOnOff = 1,
    }
    
    public enum AirLoopHVAC_UnitaryHeatPump_AirToAir_HeatingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:DX:SingleSpeed")]
        CoilHeatingDXSingleSpeed = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:DX:VariableSpeed")]
        CoilHeatingDXVariableSpeed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:IntegratedHeatPump:AirSource")]
        CoilSystemIntegratedHeatPumpAirSource = 2,
    }
    
    public enum AirLoopHVAC_UnitaryHeatPump_AirToAir_CoolingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:SingleSpeed")]
        CoilCoolingDXSingleSpeed = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:VariableSpeed")]
        CoilCoolingDXVariableSpeed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:DX:HeatExchangerAssisted")]
        CoilSystemCoolingDXHeatExchangerAssisted = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:IntegratedHeatPump:AirSource")]
        CoilSystemIntegratedHeatPumpAirSource = 3,
    }
    
    public enum AirLoopHVAC_UnitaryHeatPump_AirToAir_SupplementalHeatingCoilObjectType
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
    
    public enum AirLoopHVAC_UnitaryHeatPump_AirToAir_FanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum AirLoopHVAC_UnitaryHeatPump_AirToAir_DehumidificationControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolReheat")]
        CoolReheat = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Multimode")]
        Multimode = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    [Description(@"Unitary heat pump system, heating and cooling, single-speed with constant volume supply fan (continuous or cycling), direct expansion (DX) cooling coil, DX heating coil (water-to-air heat pump), and supplemental heating coil (gas, electric, hot water, or steam).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class AirLoopHVAC_UnitaryHeatPump_WaterToAir
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
        

[Description("This value should be > 0 and <= than the fan air flow rate.")]
[JsonProperty(PropertyName="supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> SupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="controlling_zone_or_thermostat_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControllingZoneOrThermostatLocation { get; set; } = "";
        

[Description("Only works with On/Off Fan")]
[JsonProperty(PropertyName="supply_air_fan_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatPump_WaterToAir_SupplyAirFanObjectType SupplyAirFanObjectType { get; set; } = (AirLoopHVAC_UnitaryHeatPump_WaterToAir_SupplyAirFanObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatPump_WaterToAir_SupplyAirFanObjectType), "FanOnOff");
        

[Description("Needs to match Fan:OnOff object")]
[JsonProperty(PropertyName="supply_air_fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanName { get; set; } = "";
        

[JsonProperty(PropertyName="heating_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatPump_WaterToAir_HeatingCoilObjectType HeatingCoilObjectType { get; set; } = (AirLoopHVAC_UnitaryHeatPump_WaterToAir_HeatingCoilObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatPump_WaterToAir_HeatingCoilObjectType), "CoilHeatingWaterToAirHeatPumpEquationFit");
        

[Description("Needs to match in the water-to-air heat pump heating coil object")]
[JsonProperty(PropertyName="heating_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilName { get; set; } = "";
        

[JsonProperty(PropertyName="heating_convergence", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingConvergence { get; set; } = Double.Parse("0.001", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cooling_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatPump_WaterToAir_CoolingCoilObjectType CoolingCoilObjectType { get; set; } = (AirLoopHVAC_UnitaryHeatPump_WaterToAir_CoolingCoilObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatPump_WaterToAir_CoolingCoilObjectType), "CoilCoolingWaterToAirHeatPumpEquationFit");
        

[Description("Needs to match in the water-to-air heat pump cooling coil object")]
[JsonProperty(PropertyName="cooling_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilName { get; set; } = "";
        

[JsonProperty(PropertyName="cooling_convergence", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingConvergence { get; set; } = Double.Parse("0.001", CultureInfo.InvariantCulture);
        

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
public AirLoopHVAC_UnitaryHeatPump_WaterToAir_SupplementalHeatingCoilObjectType SupplementalHeatingCoilObjectType { get; set; } = (AirLoopHVAC_UnitaryHeatPump_WaterToAir_SupplementalHeatingCoilObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatPump_WaterToAir_SupplementalHeatingCoilObjectType), "CoilHeatingElectric");
        

[Description("Needs to match in the supplemental heating coil object")]
[JsonProperty(PropertyName="supplemental_heating_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplementalHeatingCoilName { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_supply_air_temperature_from_supplemental_heater", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumSupplyAirTemperatureFromSupplementalHeater { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_outdoor_dry_bulb_temperature_for_supplemental_heater_operation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumOutdoorDryBulbTemperatureForSupplementalHeaterOperation { get; set; } = Double.Parse("21", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="outdoor_dry_bulb_temperature_sensor_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorDryBulbTemperatureSensorNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatPump_WaterToAir_FanPlacement FanPlacement { get; set; } = (AirLoopHVAC_UnitaryHeatPump_WaterToAir_FanPlacement)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatPump_WaterToAir_FanPlacement), "BlowThrough");
        

[Description(@"Enter the name of a schedule that controls fan operation. Schedule values of 0 denote cycling fan operation (fan cycles with cooling or heating coil). Schedule values greater than 0 denote constant fan operation (fan runs continually regardless of coil operation). The fan operating mode defaults to cycling fan operation if this field is left blank.")]
[JsonProperty(PropertyName="supply_air_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanOperatingModeScheduleName { get; set; } = "";
        

[Description("None = meet sensible load only CoolReheat = cool beyond the dry-bulb setpoint. as" +
    " required to meet the humidity setpoint. Valid only with Coil:Cooling:WaterToAir" +
    "HeatPump:EquationFit or Coil:Cooling:WaterToAirHeatPump:VariableSpeedEquationFit" +
    "")]
[JsonProperty(PropertyName="dehumidification_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatPump_WaterToAir_DehumidificationControlType DehumidificationControlType { get; set; } = (AirLoopHVAC_UnitaryHeatPump_WaterToAir_DehumidificationControlType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatPump_WaterToAir_DehumidificationControlType), "None");
        

[Description(@"used only when the heat pump coils are of the type WaterToAirHeatPump:EquationFit Constant results in 100% water flow regardless of compressor PLR Cycling results in water flow that matches compressor PLR ConstantOnDemand results in 100% water flow whenever the coil is on, but is 0% whenever the coil has no load")]
[JsonProperty(PropertyName="heat_pump_coil_water_flow_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatPump_WaterToAir_HeatPumpCoilWaterFlowMode HeatPumpCoilWaterFlowMode { get; set; } = (AirLoopHVAC_UnitaryHeatPump_WaterToAir_HeatPumpCoilWaterFlowMode)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatPump_WaterToAir_HeatPumpCoilWaterFlowMode), "Cycling");
    }
    
    public enum AirLoopHVAC_UnitaryHeatPump_WaterToAir_SupplyAirFanObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:OnOff")]
        FanOnOff = 0,
    }
    
    public enum AirLoopHVAC_UnitaryHeatPump_WaterToAir_HeatingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:WaterToAirHeatPump:EquationFit")]
        CoilHeatingWaterToAirHeatPumpEquationFit = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:WaterToAirHeatPump:ParameterEstimation")]
        CoilHeatingWaterToAirHeatPumpParameterEstimation = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:WaterToAirHeatPump:VariableSpeedEquationFit")]
        CoilHeatingWaterToAirHeatPumpVariableSpeedEquationFit = 2,
    }
    
    public enum AirLoopHVAC_UnitaryHeatPump_WaterToAir_CoolingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:WaterToAirHeatPump:EquationFit")]
        CoilCoolingWaterToAirHeatPumpEquationFit = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:WaterToAirHeatPump:ParameterEstimation")]
        CoilCoolingWaterToAirHeatPumpParameterEstimation = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:WaterToAirHeatPump:VariableSpeedEquationFit")]
        CoilCoolingWaterToAirHeatPumpVariableSpeedEquationFit = 2,
    }
    
    public enum AirLoopHVAC_UnitaryHeatPump_WaterToAir_SupplementalHeatingCoilObjectType
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
    
    public enum AirLoopHVAC_UnitaryHeatPump_WaterToAir_FanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 2,
    }
    
    public enum AirLoopHVAC_UnitaryHeatPump_WaterToAir_DehumidificationControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolReheat")]
        CoolReheat = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
    }
    
    public enum AirLoopHVAC_UnitaryHeatPump_WaterToAir_HeatPumpCoilWaterFlowMode
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
    
    [Description(@"Unitary system, heating and cooling with constant volume supply fan (continuous or cycling), direct expansion (DX) cooling coil, heating coil (gas, electric, hot water, steam, or DX air-to-air heat pump) and bypass damper for variable volume flow to terminal units. Used with AirTerminal:SingleDuct:VAV:HeatAndCool:Reheat or AirTerminal:SingleDuct:VAV:HeatAndCool:NoReheat.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description(@"Availability schedule name for this system. Schedule value > 0 means the system is available. If this field is blank, the system is always available. Enter the availability schedule name. Schedule values of zero denote system is Off. Non-zero schedule values denote system is available to operate.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("Enter the system air flow rate during cooling operation or specify autosize.")]
[JsonProperty(PropertyName="cooling_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the system air flow rate during heating operation or specify autosize.")]
[JsonProperty(PropertyName="heating_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Only used when the supply air fan operating mode is continuous (see field Supply air fan operating mode schedule name). This system air flow rate is used when no heating or cooling is required and the coils are off. If this field is left blank or zero, the system air flow rate from the previous on cycle (either cooling or heating) is used.")]
[JsonProperty(PropertyName="no_load_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoLoadSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the outdoor air flow rate during cooling operation or specify autosize.")]
[JsonProperty(PropertyName="cooling_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the outdoor air flow rate during heating operation or specify autosize.")]
[JsonProperty(PropertyName="heating_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Only used when the supply air fan operating mode is continuous (see field Supply air fan operating mode schedule name). This outdoor air flow rate is used when no heating or cooling is required and the coils are off. If this field is left blank or zero, the outdoor air flow rate from the previous on cycle (either cooling or heating) is used.")]
[JsonProperty(PropertyName="no_load_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoLoadOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the name of a schedule that contains multipliers for the outdoor air flow r" +
    "ates. Schedule values must be from 0 to 1. If field is left blank, model assumes" +
    " multiplier is 1 for the entire simulation period.")]
[JsonProperty(PropertyName="outdoor_air_flow_rate_multiplier_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirFlowRateMultiplierScheduleName { get; set; } = "";
        

[Description("Enter the name of the unitary system\'s air inlet node.")]
[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[Description("Enter the name of the bypass duct mixer node. This name should be the name of the" +
    " return air node for the outdoor air mixer associated with this system. This nod" +
    "e name must be different from the air inlet node name.")]
[JsonProperty(PropertyName="bypass_duct_mixer_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BypassDuctMixerNodeName { get; set; } = "";
        

[Description(@"Enter the name of the bypass duct splitter node. This splitter air node is the outlet node of the last component in this unitary system. For blow through fan placement, the splitter air node is the outlet node of the heating coil. For draw through fan placement, the splitter node is the outlet node of the supply air fan.")]
[JsonProperty(PropertyName="bypass_duct_splitter_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BypassDuctSplitterNodeName { get; set; } = "";
        

[Description("Enter the name of the unitary system\'s air outlet node.")]
[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[Description("currently only one type OutdoorAir:Mixer object is available.")]
[JsonProperty(PropertyName="outdoor_air_mixer_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_OutdoorAirMixerObjectType OutdoorAirMixerObjectType { get; set; } = (AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_OutdoorAirMixerObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_OutdoorAirMixerObjectType), "OutdoorAirMixer");
        

[Description("Enter the name of the outdoor air mixer used with this unitary system.")]
[JsonProperty(PropertyName="outdoor_air_mixer_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirMixerName { get; set; } = "";
        

[Description("Specify the type of supply air fan used in this unitary system.")]
[JsonProperty(PropertyName="supply_air_fan_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_SupplyAirFanObjectType SupplyAirFanObjectType { get; set; } = (AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_SupplyAirFanObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_SupplyAirFanObjectType), "FanConstantVolume");
        

[Description("Enter the name of the supply air fan used in this unitary system.")]
[JsonProperty(PropertyName="supply_air_fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanName { get; set; } = "";
        

[Description("Specify supply air fan placement as either blow through or draw through. BlowThro" +
    "ugh means the supply air fan is located before the cooling coil. DrawThrough mea" +
    "ns the supply air fan is located after the heating coil.")]
[JsonProperty(PropertyName="supply_air_fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_SupplyAirFanPlacement SupplyAirFanPlacement { get; set; } = (AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_SupplyAirFanPlacement)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_SupplyAirFanPlacement), "BlowThrough");
        

[Description(@"Enter the name of a schedule to control the supply air fan. Schedule Name values of zero mean that the supply air fan will cycle off if there is no cooling or heating load in any of the zones being served by this system. Non-zero schedule values mean that the supply air fan will operate continuously even if there is no cooling or heating load in any of the zones being served. If this field is left blank, the supply air fan will operate continuously for the entire simulation period.")]
[JsonProperty(PropertyName="supply_air_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanOperatingModeScheduleName { get; set; } = "";
        

[Description("Specify the type of cooling coil used in this unitary system.")]
[JsonProperty(PropertyName="cooling_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_CoolingCoilObjectType CoolingCoilObjectType { get; set; } = (AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_CoolingCoilObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_CoolingCoilObjectType), "CoilCoolingDXSingleSpeed");
        

[Description("Enter the name of the cooling coil used in this unitary system.")]
[JsonProperty(PropertyName="cooling_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilName { get; set; } = "";
        

[Description("works with DX, gas, electric, hot water and steam heating coils Specify the type " +
    "of heating coil used in this unitary system.")]
[JsonProperty(PropertyName="heating_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_HeatingCoilObjectType HeatingCoilObjectType { get; set; } = (AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_HeatingCoilObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_HeatingCoilObjectType), "CoilHeatingDXSingleSpeed");
        

[Description("Enter the name of the heating coil used in this unitary system.")]
[JsonProperty(PropertyName="heating_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilName { get; set; } = "";
        

[Description(@"CoolingPriority = system provides cooling if any zone requires cooling. HeatingPriority = system provides heating if any zone requires heating. ZonePriority = system controlled based on the total number of zones requiring cooling or heating (highest number of zones in cooling or heating determines the system's operating mode). LoadPriority = system provides cooling or heating based on total zone loads.")]
[JsonProperty(PropertyName="priority_control_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_PriorityControlMode PriorityControlMode { get; set; } = (AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_PriorityControlMode)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_PriorityControlMode), "ZonePriority");
        

[Description("Specify the minimum outlet air temperature allowed for this unitary system during" +
    " cooling operation. This value should be less than the maximum outlet air temper" +
    "ature during heating operation.")]
[JsonProperty(PropertyName="minimum_outlet_air_temperature_during_cooling_operation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumOutletAirTemperatureDuringCoolingOperation { get; set; } = Double.Parse("8", CultureInfo.InvariantCulture);
        

[Description("Specify the maximum outlet air temperature allowed for this unitary system during" +
    " heating operation. This value should be greater than the minimum outlet air tem" +
    "perature during cooling operation.")]
[JsonProperty(PropertyName="maximum_outlet_air_temperature_during_heating_operation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumOutletAirTemperatureDuringHeatingOperation { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[Description(@"None = meet sensible load only. Multimode = activate enhanced dehumidification mode as needed and meet sensible load. Valid only with Coil:Cooling:DX:TwoStageWithHumidityControlMode. CoolReheat = cool beyond the Dry-Bulb temperature setpoint as required to meet the humidity setpoint. Valid only with Coil:Cooling:DX:TwoStageWithHumidityControlMode. For all dehumidification controls, the max humidity setpoint on this unitary system's air outlet node is used. This must be set using ZoneControl:Humidistat and SetpointManager:SingleZone:Humidity:Maximum, SetpointManager:MultiZone:Humidity:Maximum or SetpointManager:MultiZone:MaximumHumidity:Average objects.")]
[JsonProperty(PropertyName="dehumidification_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_DehumidificationControlType DehumidificationControlType { get; set; } = (AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_DehumidificationControlType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_DehumidificationControlType), "None");
        

[Description("Enter the name of the bypass duct node connected to a plenum or mixer. This field" +
    " is required when this HVAC System is connected to a plenum or mixer. This is a " +
    "different node name than that entered in the Bypass Duct Splitter Node Name fiel" +
    "d.")]
[JsonProperty(PropertyName="plenum_or_mixer_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PlenumOrMixerInletNodeName { get; set; } = "";
        

[Description("This is the minimum amount of time the unit operates in cooling or heating mode b" +
    "efore changing modes.")]
[JsonProperty(PropertyName="minimum_runtime_before_operating_mode_change", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumRuntimeBeforeOperatingModeChange { get; set; } = Double.Parse("0.25", CultureInfo.InvariantCulture);
    }
    
    public enum AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_OutdoorAirMixerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAir:Mixer")]
        OutdoorAirMixer = 0,
    }
    
    public enum AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_SupplyAirFanObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:ConstantVolume")]
        FanConstantVolume = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:OnOff")]
        FanOnOff = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:SystemModel")]
        FanSystemModel = 2,
    }
    
    public enum AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_SupplyAirFanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 1,
    }
    
    public enum AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_CoolingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:SingleSpeed")]
        CoilCoolingDXSingleSpeed = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:TwoStageWithHumidityControlMode")]
        CoilCoolingDXTwoStageWithHumidityControlMode = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:VariableSpeed")]
        CoilCoolingDXVariableSpeed = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:DX:HeatExchangerAssisted")]
        CoilSystemCoolingDXHeatExchangerAssisted = 3,
    }
    
    public enum AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_HeatingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:DX:SingleSpeed")]
        CoilHeatingDXSingleSpeed = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:DX:VariableSpeed")]
        CoilHeatingDXVariableSpeed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric")]
        CoilHeatingElectric = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Fuel")]
        CoilHeatingFuel = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Steam")]
        CoilHeatingSteam = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Water")]
        CoilHeatingWater = 5,
    }
    
    public enum AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_PriorityControlMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingPriority")]
        CoolingPriority = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatingPriority")]
        HeatingPriority = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="LoadPriority")]
        LoadPriority = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ZonePriority")]
        ZonePriority = 4,
    }
    
    public enum AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_DehumidificationControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolReheat")]
        CoolReheat = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Multimode")]
        Multimode = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    [Description(@"Unitary system, heating and cooling, multi-speed with constant volume supply fan (continuous or cycling), direct expansion (DX) cooling coil, heating coil (DX air-to-air heat pump, gas, electric, hot water, or steam), and supplemental heating coil (gas, electric, hot water, or steam).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed
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
        

[JsonProperty(PropertyName="controlling_zone_or_thermostat_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControllingZoneOrThermostatLocation { get; set; } = "";
        

[Description("Select the type of supply air fan used in this unitary system.")]
[JsonProperty(PropertyName="supply_air_fan_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed_SupplyAirFanObjectType SupplyAirFanObjectType { get; set; } = (AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed_SupplyAirFanObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed_SupplyAirFanObjectType), "FanConstantVolume");
        

[Description("Enter the name of the supply air fan used in this unitary system.")]
[JsonProperty(PropertyName="supply_air_fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanName { get; set; } = "";
        

[Description(@"Select supply air fan placement as either BlowThrough or DrawThrough. BlowThrough means the supply air fan is located before the cooling coil. DrawThrough means the supply air fan is located after the heating coil but before the optional supplemental heating coil.")]
[JsonProperty(PropertyName="supply_air_fan_placement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed_SupplyAirFanPlacement SupplyAirFanPlacement { get; set; } = (AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed_SupplyAirFanPlacement)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed_SupplyAirFanPlacement), "BlowThrough");
        

[Description(@"Enter the name of a schedule to control the supply air fan. Schedule values of zero mean that the supply air fan will cycle off if there is no cooling or heating load in the control zone. Non-zero schedule values mean that the supply air fan will operate continuously even if there is no cooling or heating load in the control zone. If this field is left blank, the supply air fan will operate continuously for the entire simulation period.")]
[JsonProperty(PropertyName="supply_air_fan_operating_mode_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirFanOperatingModeScheduleName { get; set; } = "";
        

[Description("Multi Speed DX, Electric, Gas, and Single speed Water and Steam coils")]
[JsonProperty(PropertyName="heating_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed_HeatingCoilObjectType HeatingCoilObjectType { get; set; } = (AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed_HeatingCoilObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed_HeatingCoilObjectType), "CoilHeatingDXMultiSpeed");
        

[JsonProperty(PropertyName="heating_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilName { get; set; } = "";
        

[Description("Needs to match the corresponding minimum outdoor temperature defined in the DX he" +
    "ating coil object.")]
[JsonProperty(PropertyName="minimum_outdoor_dry_bulb_temperature_for_compressor_operation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumOutdoorDryBulbTemperatureForCompressorOperation { get; set; } = Double.Parse("-8", CultureInfo.InvariantCulture);
        

[Description("Only works with Coil:Cooling:DX:MultiSpeed")]
[JsonProperty(PropertyName="cooling_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed_CoolingCoilObjectType CoolingCoilObjectType { get; set; } = (AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed_CoolingCoilObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed_CoolingCoilObjectType), "CoilCoolingDXMultiSpeed");
        

[Description("Needs to match in the DX Cooling Coil object")]
[JsonProperty(PropertyName="cooling_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilName { get; set; } = "";
        

[Description("works with gas, electric, hot water and steam heating coils")]
[JsonProperty(PropertyName="supplemental_heating_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed_SupplementalHeatingCoilObjectType SupplementalHeatingCoilObjectType { get; set; } = (AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed_SupplementalHeatingCoilObjectType)Enum.Parse(typeof(AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed_SupplementalHeatingCoilObjectType), "CoilHeatingElectric");
        

[Description("Needs to match in the supplemental heating coil object")]
[JsonProperty(PropertyName="supplemental_heating_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplementalHeatingCoilName { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_supply_air_temperature_from_supplemental_heater", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumSupplyAirTemperatureFromSupplementalHeater { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_outdoor_dry_bulb_temperature_for_supplemental_heater_operation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumOutdoorDryBulbTemperatureForSupplementalHeaterOperation { get; set; } = Double.Parse("21", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="auxiliary_on_cycle_electric_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AuxiliaryOnCycleElectricPower { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="auxiliary_off_cycle_electric_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AuxiliaryOffCycleElectricPower { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("If non-zero, then the heat recovery inlet and outlet node names must be entered. " +
    "Used for heat recovery to an EnergyPlus plant loop.")]
[JsonProperty(PropertyName="design_heat_recovery_water_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignHeatRecoveryWaterFlowRate { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_temperature_for_heat_recovery", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumTemperatureForHeatRecovery { get; set; } = Double.Parse("80", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heat_recovery_water_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatRecoveryWaterInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="heat_recovery_water_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatRecoveryWaterOutletNodeName { get; set; } = "";
        

[Description(@"Only used when the supply air fan operating mode is continuous (see field Supply Air Fan Operating Mode Schedule Name). This air flow rate is used when no heating or cooling is required and the coils are off. If this field is left blank or zero, the supply air flow rate from the previous on cycle (either cooling or heating) is used.")]
[JsonProperty(PropertyName="no_load_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NoLoadSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the number of the following sets of data for air flow rates. If Heating Coi" +
    "l Object Type is Coil:Heating:Water or Coil:Heating:Steam, this field should be " +
    "1.")]
[JsonProperty(PropertyName="number_of_speeds_for_heating", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfSpeedsForHeating { get; set; } = null;
        

[Description("Enter the number of the following sets of data for air flow rates.")]
[JsonProperty(PropertyName="number_of_speeds_for_cooling", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfSpeedsForCooling { get; set; } = null;
        

[Description("Enter the operating supply air flow rate during heating operation or specify auto" +
    "size.")]
[JsonProperty(PropertyName="heating_speed_1_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingSpeed1SupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the operating supply air flow rate during heating operation or specify auto" +
    "size.")]
[JsonProperty(PropertyName="heating_speed_2_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingSpeed2SupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the operating supply air flow rate during heating operation or specify auto" +
    "size.")]
[JsonProperty(PropertyName="heating_speed_3_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingSpeed3SupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the operating supply air flow rate during heating operation or specify auto" +
    "size.")]
[JsonProperty(PropertyName="heating_speed_4_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingSpeed4SupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the operating supply air flow rate during cooling operation or specify auto" +
    "size.")]
[JsonProperty(PropertyName="cooling_speed_1_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingSpeed1SupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the operating supply air flow rate during cooling operation or specify auto" +
    "size.")]
[JsonProperty(PropertyName="cooling_speed_2_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingSpeed2SupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the operating supply air flow rate during cooling operation or specify auto" +
    "size.")]
[JsonProperty(PropertyName="cooling_speed_3_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingSpeed3SupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the operating supply air flow rate during cooling operation or specify auto" +
    "size.")]
[JsonProperty(PropertyName="cooling_speed_4_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingSpeed4SupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
    }
    
    public enum AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed_SupplyAirFanObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:ConstantVolume")]
        FanConstantVolume = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:OnOff")]
        FanOnOff = 1,
    }
    
    public enum AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed_SupplyAirFanPlacement
    {
        
        [System.Runtime.Serialization.EnumMember(Value="BlowThrough")]
        BlowThrough = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DrawThrough")]
        DrawThrough = 1,
    }
    
    public enum AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed_HeatingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:DX:MultiSpeed")]
        CoilHeatingDXMultiSpeed = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric:MultiStage")]
        CoilHeatingElectricMultiStage = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Gas:MultiStage")]
        CoilHeatingGasMultiStage = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Steam")]
        CoilHeatingSteam = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Water")]
        CoilHeatingWater = 4,
    }
    
    public enum AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed_CoolingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:MultiSpeed")]
        CoilCoolingDXMultiSpeed = 0,
    }
    
    public enum AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed_SupplementalHeatingCoilObjectType
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
