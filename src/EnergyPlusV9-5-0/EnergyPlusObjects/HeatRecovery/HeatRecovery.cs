namespace EnergyPlus.HeatRecovery
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
    
    
    [Description("Flat plate air-to-air heat exchanger, typically used for exhaust or relief air he" +
        "at recovery.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HeatExchanger_AirToAir_FlatPlate
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="flow_arrangement_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HeatExchanger_AirToAir_FlatPlate_FlowArrangementType FlowArrangementType { get; set; } = (HeatExchanger_AirToAir_FlatPlate_FlowArrangementType)Enum.Parse(typeof(HeatExchanger_AirToAir_FlatPlate_FlowArrangementType), "CounterFlow");
        

[Description("Yes means that the heat exchanger will be locked out (off) when the economizer is" +
    " operating or high humidity control is active")]
[JsonProperty(PropertyName="economizer_lockout", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes EconomizerLockout { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[Description("Ratio of h*A for supply side to h*A for exhaust side")]
[JsonProperty(PropertyName="ratio_of_supply_to_secondary_ha_values", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatioOfSupplyToSecondaryHaValues { get; set; } = null;
        

[JsonProperty(PropertyName="nominal_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NominalSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="nominal_supply_air_inlet_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NominalSupplyAirInletTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="nominal_supply_air_outlet_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NominalSupplyAirOutletTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="nominal_secondary_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NominalSecondaryAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="nominal_secondary_air_inlet_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NominalSecondaryAirInletTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="nominal_electric_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NominalElectricPower { get; set; } = null;
        

[JsonProperty(PropertyName="supply_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="supply_air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="secondary_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SecondaryAirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="secondary_air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SecondaryAirOutletNodeName { get; set; } = "";
    }
    
    public enum HeatExchanger_AirToAir_FlatPlate_FlowArrangementType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="CounterFlow")]
        CounterFlow = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CrossFlowBothUnmixed")]
        CrossFlowBothUnmixed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ParallelFlow")]
        ParallelFlow = 2,
    }
    
    [Description("This object models an air-to-air heat exchanger using effectiveness relationships" +
        ". The heat exchanger can transfer sensible energy, latent energy, or both betwee" +
        "n the supply (primary) and exhaust (secondary) air streams.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HeatExchanger_AirToAir_SensibleAndLatent
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="nominal_supply_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NominalSupplyAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="sensible_effectiveness_at_100_heating_air_flow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SensibleEffectivenessAt100HeatingAirFlow { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="latent_effectiveness_at_100_heating_air_flow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LatentEffectivenessAt100HeatingAirFlow { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="sensible_effectiveness_at_75_heating_air_flow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SensibleEffectivenessAt75HeatingAirFlow { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="latent_effectiveness_at_75_heating_air_flow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LatentEffectivenessAt75HeatingAirFlow { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="sensible_effectiveness_at_100_cooling_air_flow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SensibleEffectivenessAt100CoolingAirFlow { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="latent_effectiveness_at_100_cooling_air_flow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LatentEffectivenessAt100CoolingAirFlow { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="sensible_effectiveness_at_75_cooling_air_flow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SensibleEffectivenessAt75CoolingAirFlow { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="latent_effectiveness_at_75_cooling_air_flow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LatentEffectivenessAt75CoolingAirFlow { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="supply_air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="exhaust_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ExhaustAirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="exhaust_air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ExhaustAirOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="nominal_electric_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NominalElectricPower { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="supply_air_outlet_temperature_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes SupplyAirOutletTemperatureControl { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[JsonProperty(PropertyName="heat_exchanger_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HeatExchanger_AirToAir_SensibleAndLatent_HeatExchangerType HeatExchangerType { get; set; } = (HeatExchanger_AirToAir_SensibleAndLatent_HeatExchangerType)Enum.Parse(typeof(HeatExchanger_AirToAir_SensibleAndLatent_HeatExchangerType), "Plate");
        

[JsonProperty(PropertyName="frost_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HeatExchanger_AirToAir_SensibleAndLatent_FrostControlType FrostControlType { get; set; } = (HeatExchanger_AirToAir_SensibleAndLatent_FrostControlType)Enum.Parse(typeof(HeatExchanger_AirToAir_SensibleAndLatent_FrostControlType), "None");
        

[Description("Supply (outdoor) air inlet temp threshold for exhaust air recirculation and exhau" +
    "st only frost control types. Exhaust air outlet threshold Temperature for minimu" +
    "m exhaust temperature frost control type.")]
[JsonProperty(PropertyName="threshold_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThresholdTemperature { get; set; } = Double.Parse("1.7", CultureInfo.InvariantCulture);
        

[Description("Fraction of the time when frost control will be invoked at the threshold temperat" +
    "ure. This field only used for exhaust air recirc and exhaust-only frost control " +
    "types.")]
[JsonProperty(PropertyName="initial_defrost_time_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InitialDefrostTimeFraction { get; set; } = Double.Parse("0.083", CultureInfo.InvariantCulture);
        

[Description("Rate of increase in defrost time fraction as actual temp falls below threshold te" +
    "mperature. This field only used for exhaust air recirc and exhaust-only frost co" +
    "ntrol types.")]
[JsonProperty(PropertyName="rate_of_defrost_time_fraction_increase", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RateOfDefrostTimeFractionIncrease { get; set; } = Double.Parse("0.012", CultureInfo.InvariantCulture);
        

[Description("Yes means that the heat exchanger will be locked out (off) when the economizer is" +
    " operating or high humidity control is active")]
[JsonProperty(PropertyName="economizer_lockout", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes EconomizerLockout { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
    }
    
    public enum HeatExchanger_AirToAir_SensibleAndLatent_HeatExchangerType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Plate")]
        Plate = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Rotary")]
        Rotary = 2,
    }
    
    public enum HeatExchanger_AirToAir_SensibleAndLatent_FrostControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ExhaustAirRecirculation")]
        ExhaustAirRecirculation = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ExhaustOnly")]
        ExhaustOnly = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MinimumExhaustTemperature")]
        MinimumExhaustTemperature = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    [Description(@"This object models a balanced desiccant heat exchanger. The heat exchanger transfers both sensible and latent energy between the process and regeneration air streams. The air flow rate and face velocity are assumed to be the same on both the process and regeneration sides of the heat exchanger.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HeatExchanger_Desiccant_BalancedFlow
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="regeneration_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RegenerationAirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="regeneration_air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RegenerationAirOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="process_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ProcessAirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="process_air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ProcessAirOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="heat_exchanger_performance_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HeatExchanger_Desiccant_BalancedFlow_HeatExchangerPerformanceObjectType HeatExchangerPerformanceObjectType { get; set; } = (HeatExchanger_Desiccant_BalancedFlow_HeatExchangerPerformanceObjectType)Enum.Parse(typeof(HeatExchanger_Desiccant_BalancedFlow_HeatExchangerPerformanceObjectType), "Empty");
        

[JsonProperty(PropertyName="heat_exchanger_performance_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatExchangerPerformanceName { get; set; } = "";
        

[Description("Yes means that the heat exchanger will be locked out (off) when the economizer is" +
    " operating or high humidity control is active")]
[JsonProperty(PropertyName="economizer_lockout", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes EconomizerLockout { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
    }
    
    public enum HeatExchanger_Desiccant_BalancedFlow_HeatExchangerPerformanceObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatExchanger:Desiccant:BalancedFlow:PerformanceDataType1")]
        HeatExchangerDesiccantBalancedFlowPerformanceDataType1 = 1,
    }
    
    [Description(@"RTO = B1 + B2*RWI + B3*RTI + B4*(RWI/RTI) + B5*PWI + B6*PTI + B7*(PWI/PTI) + B8*RFV RWO = C1 + C2*RWI + C3*RTI + C4*(RWI/RTI) + C5*PWI + C6*PTI + C7*(PWI/PTI) + C8*RFV where, RTO = Dry-bulb temperature of the regeneration outlet air (C) RWO = Humidity ratio of the regeneration outlet air (kgWater/kgDryAir) RWI = Humidity ratio of the regeneration inlet air (kgWater/kgDryAir) RTI = Dry-bulb temperature of the regeneration inlet air (C) PWI = Humidity ratio of the process inlet air (kgWater/kgDryAir) PTI = Dry-bulb temperature of the process inlet air (C) RFV = Regeneration Face Velocity (m/s)")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HeatExchanger_Desiccant_BalancedFlow_PerformanceDataType1
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Air flow rate at nominal conditions (assumed to be the same for both sides of the" +
    " heat exchanger).")]
[JsonProperty(PropertyName="nominal_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NominalAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="nominal_air_face_velocity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> NominalAirFaceVelocity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Parasitic electric power (e.g., desiccant wheel motor)")]
[JsonProperty(PropertyName="nominal_electric_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NominalElectricPower { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="temperature_equation_coefficient_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureEquationCoefficient1 { get; set; } = null;
        

[JsonProperty(PropertyName="temperature_equation_coefficient_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureEquationCoefficient2 { get; set; } = null;
        

[JsonProperty(PropertyName="temperature_equation_coefficient_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureEquationCoefficient3 { get; set; } = null;
        

[JsonProperty(PropertyName="temperature_equation_coefficient_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureEquationCoefficient4 { get; set; } = null;
        

[JsonProperty(PropertyName="temperature_equation_coefficient_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureEquationCoefficient5 { get; set; } = null;
        

[JsonProperty(PropertyName="temperature_equation_coefficient_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureEquationCoefficient6 { get; set; } = null;
        

[JsonProperty(PropertyName="temperature_equation_coefficient_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureEquationCoefficient7 { get; set; } = null;
        

[JsonProperty(PropertyName="temperature_equation_coefficient_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureEquationCoefficient8 { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_regeneration_inlet_air_humidity_ratio_for_temperature_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumRegenerationInletAirHumidityRatioForTemperatureEquation { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_regeneration_inlet_air_humidity_ratio_for_temperature_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumRegenerationInletAirHumidityRatioForTemperatureEquation { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_regeneration_inlet_air_temperature_for_temperature_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumRegenerationInletAirTemperatureForTemperatureEquation { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_regeneration_inlet_air_temperature_for_temperature_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumRegenerationInletAirTemperatureForTemperatureEquation { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_process_inlet_air_humidity_ratio_for_temperature_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumProcessInletAirHumidityRatioForTemperatureEquation { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_process_inlet_air_humidity_ratio_for_temperature_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumProcessInletAirHumidityRatioForTemperatureEquation { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_process_inlet_air_temperature_for_temperature_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumProcessInletAirTemperatureForTemperatureEquation { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_process_inlet_air_temperature_for_temperature_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumProcessInletAirTemperatureForTemperatureEquation { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_regeneration_air_velocity_for_temperature_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumRegenerationAirVelocityForTemperatureEquation { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_regeneration_air_velocity_for_temperature_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumRegenerationAirVelocityForTemperatureEquation { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_regeneration_outlet_air_temperature_for_temperature_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumRegenerationOutletAirTemperatureForTemperatureEquation { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_regeneration_outlet_air_temperature_for_temperature_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumRegenerationOutletAirTemperatureForTemperatureEquation { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_regeneration_inlet_air_relative_humidity_for_temperature_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumRegenerationInletAirRelativeHumidityForTemperatureEquation { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_regeneration_inlet_air_relative_humidity_for_temperature_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumRegenerationInletAirRelativeHumidityForTemperatureEquation { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_process_inlet_air_relative_humidity_for_temperature_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumProcessInletAirRelativeHumidityForTemperatureEquation { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_process_inlet_air_relative_humidity_for_temperature_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumProcessInletAirRelativeHumidityForTemperatureEquation { get; set; } = null;
        

[JsonProperty(PropertyName="humidity_ratio_equation_coefficient_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidityRatioEquationCoefficient1 { get; set; } = null;
        

[JsonProperty(PropertyName="humidity_ratio_equation_coefficient_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidityRatioEquationCoefficient2 { get; set; } = null;
        

[JsonProperty(PropertyName="humidity_ratio_equation_coefficient_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidityRatioEquationCoefficient3 { get; set; } = null;
        

[JsonProperty(PropertyName="humidity_ratio_equation_coefficient_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidityRatioEquationCoefficient4 { get; set; } = null;
        

[JsonProperty(PropertyName="humidity_ratio_equation_coefficient_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidityRatioEquationCoefficient5 { get; set; } = null;
        

[JsonProperty(PropertyName="humidity_ratio_equation_coefficient_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidityRatioEquationCoefficient6 { get; set; } = null;
        

[JsonProperty(PropertyName="humidity_ratio_equation_coefficient_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidityRatioEquationCoefficient7 { get; set; } = null;
        

[JsonProperty(PropertyName="humidity_ratio_equation_coefficient_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidityRatioEquationCoefficient8 { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_regeneration_inlet_air_humidity_ratio_for_humidity_ratio_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumRegenerationInletAirHumidityRatioForHumidityRatioEquation { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_regeneration_inlet_air_humidity_ratio_for_humidity_ratio_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumRegenerationInletAirHumidityRatioForHumidityRatioEquation { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_regeneration_inlet_air_temperature_for_humidity_ratio_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumRegenerationInletAirTemperatureForHumidityRatioEquation { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_regeneration_inlet_air_temperature_for_humidity_ratio_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumRegenerationInletAirTemperatureForHumidityRatioEquation { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_process_inlet_air_humidity_ratio_for_humidity_ratio_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumProcessInletAirHumidityRatioForHumidityRatioEquation { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_process_inlet_air_humidity_ratio_for_humidity_ratio_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumProcessInletAirHumidityRatioForHumidityRatioEquation { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_process_inlet_air_temperature_for_humidity_ratio_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumProcessInletAirTemperatureForHumidityRatioEquation { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_process_inlet_air_temperature_for_humidity_ratio_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumProcessInletAirTemperatureForHumidityRatioEquation { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_regeneration_air_velocity_for_humidity_ratio_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumRegenerationAirVelocityForHumidityRatioEquation { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_regeneration_air_velocity_for_humidity_ratio_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumRegenerationAirVelocityForHumidityRatioEquation { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_regeneration_outlet_air_humidity_ratio_for_humidity_ratio_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumRegenerationOutletAirHumidityRatioForHumidityRatioEquation { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_regeneration_outlet_air_humidity_ratio_for_humidity_ratio_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumRegenerationOutletAirHumidityRatioForHumidityRatioEquation { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_regeneration_inlet_air_relative_humidity_for_humidity_ratio_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumRegenerationInletAirRelativeHumidityForHumidityRatioEquation { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_regeneration_inlet_air_relative_humidity_for_humidity_ratio_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumRegenerationInletAirRelativeHumidityForHumidityRatioEquation { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_process_inlet_air_relative_humidity_for_humidity_ratio_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumProcessInletAirRelativeHumidityForHumidityRatioEquation { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_process_inlet_air_relative_humidity_for_humidity_ratio_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumProcessInletAirRelativeHumidityForHumidityRatioEquation { get; set; } = null;
    }
}
