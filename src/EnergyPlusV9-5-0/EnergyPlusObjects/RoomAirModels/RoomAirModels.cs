namespace EnergyPlus.RoomAirModels
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
    
    
    [Description("Selects the type of room air model to be used in a given zone. If no RoomAirModel" +
        "Type object is specified then the default Mixing model (all zone air at the same" +
        " temperature) will be used.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoomAirModelType
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description(@"Mixing = Complete mixing air model UserDefined = UserDefined Room Air Temperature Patterns needs RoomAir:TemperaturePattern:UserDefined object referencing this Zone OneNodeDisplacementVentilation = Mundt roomair model for displacement ventilation with single floor air node needs RoomAirSettings:OneNodeDisplacementVentilation object referencing this Zone ThreeNodeDisplacementVentilation = RoomAir modeling using UCSD three-node displacement ventilation model needs RoomAirSettings:ThreeNodeDisplacementVentilation object referencing this Zone CrossVentilation = RoomAir modeling using UCSD two-zone cross ventilation model needs RoomAirSettings:CrossVentilation object referencing this Zone UnderFloorAirDistributionInterior = 2-Node UFAD model for interior zones needs RoomAirSettings:UnderFloorAirDistributionInterior object referencing this Zone UnderFloorAirDistributionExterior = RoomAir modeling using 2-Node UFAD model for exterior zones needs RoomAirSettings:UnderFloorAirDistributionExterior object referencing this Zone AirflowNetwork = RoomAir modeling using AirflowNetwork needs RoomAirSettings:AirflowNetwork object referencing this Zone")]
[JsonProperty(PropertyName="room_air_modeling_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public RoomAirModelType_RoomAirModelingType RoomAirModelingType { get; set; } = (RoomAirModelType_RoomAirModelingType)Enum.Parse(typeof(RoomAirModelType_RoomAirModelingType), "Mixing");
        

[JsonProperty(PropertyName="air_temperature_coupling_strategy", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public RoomAirModelType_AirTemperatureCouplingStrategy AirTemperatureCouplingStrategy { get; set; } = (RoomAirModelType_AirTemperatureCouplingStrategy)Enum.Parse(typeof(RoomAirModelType_AirTemperatureCouplingStrategy), "Direct");
    }
    
    public enum RoomAirModelType_RoomAirModelingType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AirflowNetwork")]
        AirflowNetwork = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CrossVentilation")]
        CrossVentilation = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Mixing")]
        Mixing = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="OneNodeDisplacementVentilation")]
        OneNodeDisplacementVentilation = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="ThreeNodeDisplacementVentilation")]
        ThreeNodeDisplacementVentilation = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="UnderFloorAirDistributionExterior")]
        UnderFloorAirDistributionExterior = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="UnderFloorAirDistributionInterior")]
        UnderFloorAirDistributionInterior = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="UserDefined")]
        UserDefined = 8,
    }
    
    public enum RoomAirModelType_AirTemperatureCouplingStrategy
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Direct")]
        Direct = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Indirect")]
        Indirect = 2,
    }
    
    [Description("Used to explicitly define temperature patterns that are to be applied to the mean" +
        " air temperature within a thermal zone. Used with RoomAirModelType = UserDefined" +
        ".")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoomAir_TemperaturePattern_UserDefined
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Availability schedule name for this model. Schedule value > 0 means the model is " +
    "active. Schedule value = 0 means the model is inactive and the zone will be mode" +
    "led as fully mixed (Mixing). If this field is blank, the model is always active." +
    "")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("The schedule should contain integer values that correspond to unique Control Inte" +
    "ger fields in one of the RoomAir:TemperaturePattern:* objects.")]
[JsonProperty(PropertyName="pattern_control_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PatternControlScheduleName { get; set; } = "";
    }
    
    [Description("Used to model room air with a fixed temperature gradient in the vertical directio" +
        "n. Used in combination with RoomAir:TemperaturePattern:UserDefined.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoomAir_TemperaturePattern_ConstantGradient
    {
        

[JsonProperty(PropertyName="room_air_temperature_pattern_constant_gradient_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RoomAirTemperaturePatternConstantGradientName { get; set; } = "";
        

[Description("reference this entry in Schedule Name")]
[JsonProperty(PropertyName="control_integer_for_pattern_control_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ControlIntegerForPatternControlScheduleName { get; set; } = null;
        

[Description("= (Temp at thermostat- Mean Air Temp)")]
[JsonProperty(PropertyName="thermostat_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermostatOffset { get; set; } = null;
        

[Description("= (Tleaving - Mean Air Temp )")]
[JsonProperty(PropertyName="return_air_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnAirOffset { get; set; } = null;
        

[Description("= (Texhaust - Mean Air Temp) deg C")]
[JsonProperty(PropertyName="exhaust_air_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ExhaustAirOffset { get; set; } = null;
        

[Description("Slope of temperature change in vertical direction")]
[JsonProperty(PropertyName="temperature_gradient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureGradient { get; set; } = null;
    }
    
    [Description("Used to model room air with two temperature gradients in the vertical direction. " +
        "Used in combination with RoomAir:TemperaturePattern:UserDefined.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoomAir_TemperaturePattern_TwoGradient
    {
        

[JsonProperty(PropertyName="room_air_temperature_pattern_two_gradient_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RoomAirTemperaturePatternTwoGradientName { get; set; } = "";
        

[Description("reference this entry in Schedule Name")]
[JsonProperty(PropertyName="control_integer_for_pattern_control_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ControlIntegerForPatternControlScheduleName { get; set; } = null;
        

[Description("= Distance from floor of zone")]
[JsonProperty(PropertyName="thermostat_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermostatHeight { get; set; } = null;
        

[Description("= Distance from floor of zone")]
[JsonProperty(PropertyName="return_air_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnAirHeight { get; set; } = null;
        

[Description("= Distance from floor of zone")]
[JsonProperty(PropertyName="exhaust_air_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ExhaustAirHeight { get; set; } = null;
        

[Description("Slope of temperature change in vertical direction")]
[JsonProperty(PropertyName="temperature_gradient_lower_bound", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureGradientLowerBound { get; set; } = null;
        

[Description("Slope of temperature change in vertical direction")]
[JsonProperty(PropertyName="temperature_gradient_upper_bound", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureGradientUpperBound { get; set; } = null;
        

[JsonProperty(PropertyName="gradient_interpolation_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public RoomAir_TemperaturePattern_TwoGradient_GradientInterpolationMode GradientInterpolationMode { get; set; } = (RoomAir_TemperaturePattern_TwoGradient_GradientInterpolationMode)Enum.Parse(typeof(RoomAir_TemperaturePattern_TwoGradient_GradientInterpolationMode), "OutdoorDryBulbTemperature");
        

[JsonProperty(PropertyName="upper_temperature_bound", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> UpperTemperatureBound { get; set; } = null;
        

[JsonProperty(PropertyName="lower_temperature_bound", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LowerTemperatureBound { get; set; } = null;
        

[JsonProperty(PropertyName="upper_heat_rate_bound", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> UpperHeatRateBound { get; set; } = null;
        

[JsonProperty(PropertyName="lower_heat_rate_bound", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LowerHeatRateBound { get; set; } = null;
    }
    
    public enum RoomAir_TemperaturePattern_TwoGradient_GradientInterpolationMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorDryBulbTemperature")]
        OutdoorDryBulbTemperature = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SensibleCoolingLoad")]
        SensibleCoolingLoad = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SensibleHeatingLoad")]
        SensibleHeatingLoad = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ZoneAndOutdoorTemperatureDifference")]
        ZoneAndOutdoorTemperatureDifference = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ZoneDryBulbTemperature")]
        ZoneDryBulbTemperature = 4,
    }
    
    [Description(@"Defines a distribution pattern for air temperatures relative to the current mean air temperature as a function of height. The height, referred to as Zeta, is nondimensional by normalizing with the zone ceiling height. Used in combination with RoomAir:TemperaturePattern:UserDefined.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoomAir_TemperaturePattern_NondimensionalHeight
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("this value should appear in as a schedule value")]
[JsonProperty(PropertyName="control_integer_for_pattern_control_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ControlIntegerForPatternControlScheduleName { get; set; } = null;
        

[Description("= (Temp at thermostat- Mean Air Temp)")]
[JsonProperty(PropertyName="thermostat_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermostatOffset { get; set; } = null;
        

[Description("= (Temp leaving - Mean Air Temp ) deg C")]
[JsonProperty(PropertyName="return_air_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnAirOffset { get; set; } = null;
        

[Description(@"= (Temp exhaust - Mean Air Temp) deg C the remaining fields have pairs that describe the relative temperature pattern in the vertical direction of a zone Zeta is the nondimensional height (in z-direction). on [0..1] DeltaTai =  (Tai - MAT) in units of deg. C relative deg C on [-10.0 .. 20.0 ]")]
[JsonProperty(PropertyName="exhaust_air_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ExhaustAirOffset { get; set; } = null;
        

[JsonProperty(PropertyName="pairs", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_TemperaturePattern_NondimensionalHeight_Pairs_Item> Pairs { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoomAir_TemperaturePattern_NondimensionalHeight_Pairs_Item
    {
        

[JsonProperty(PropertyName="pair_zeta_nondimensional_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PairZetaNondimensionalHeight { get; set; } = null;
        

[JsonProperty(PropertyName="pair_delta_adjacent_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PairDeltaAdjacentAirTemperature { get; set; } = null;
    }
    
    [Description(@"Defines a distribution pattern for the air temperatures adjacent to individual surfaces. This allows controlling the adjacent air temperature on a surface-by-surface basis rather than by height. This allows modeling different adjacent air temperatures on the opposite sides of the zone. Used in combination with RoomAir:TemperaturePattern:UserDefined.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoomAir_TemperaturePattern_SurfaceMapping
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("reference this entry in schedule")]
[JsonProperty(PropertyName="control_integer_for_pattern_control_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ControlIntegerForPatternControlScheduleName { get; set; } = null;
        

[Description("= (Temp at thermostat- Mean Air Temp)")]
[JsonProperty(PropertyName="thermostat_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermostatOffset { get; set; } = null;
        

[Description("= (Tleaving - Mean Air Temp ) deg C")]
[JsonProperty(PropertyName="return_air_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnAirOffset { get; set; } = null;
        

[Description("= (Texhaust - Mean Air Temp) deg C")]
[JsonProperty(PropertyName="exhaust_air_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ExhaustAirOffset { get; set; } = null;
        

[JsonProperty(PropertyName="surface_deltas", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_TemperaturePattern_SurfaceMapping_SurfaceDeltas_Item> SurfaceDeltas { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoomAir_TemperaturePattern_SurfaceMapping_SurfaceDeltas_Item
    {
        

[JsonProperty(PropertyName="surface_name_pair", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceNamePair { get; set; } = "";
        

[JsonProperty(PropertyName="delta_adjacent_air_temperature_pair", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DeltaAdjacentAirTemperaturePair { get; set; } = null;
    }
    
    [Description("Define an air node for some types of nodal room air models")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoomAir_Node
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="node_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public RoomAir_Node_NodeType NodeType { get; set; } = (RoomAir_Node_NodeType)Enum.Parse(typeof(RoomAir_Node_NodeType), "Ceiling");
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="height_of_nodal_control_volume_center", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeightOfNodalControlVolumeCenter { get; set; } = null;
        

[JsonProperty(PropertyName="surface_1_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface1Name { get; set; } = "";
        

[JsonProperty(PropertyName="surface_2_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface2Name { get; set; } = "";
        

[JsonProperty(PropertyName="surface_3_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface3Name { get; set; } = "";
        

[JsonProperty(PropertyName="surface_4_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface4Name { get; set; } = "";
        

[JsonProperty(PropertyName="surface_5_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface5Name { get; set; } = "";
        

[JsonProperty(PropertyName="surface_6_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface6Name { get; set; } = "";
        

[JsonProperty(PropertyName="surface_7_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface7Name { get; set; } = "";
        

[JsonProperty(PropertyName="surface_8_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface8Name { get; set; } = "";
        

[JsonProperty(PropertyName="surface_9_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface9Name { get; set; } = "";
        

[JsonProperty(PropertyName="surface_10_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface10Name { get; set; } = "";
        

[JsonProperty(PropertyName="surface_11_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface11Name { get; set; } = "";
        

[JsonProperty(PropertyName="surface_12_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface12Name { get; set; } = "";
        

[JsonProperty(PropertyName="surface_13_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface13Name { get; set; } = "";
        

[JsonProperty(PropertyName="surface_14_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface14Name { get; set; } = "";
        

[JsonProperty(PropertyName="surface_15_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface15Name { get; set; } = "";
        

[JsonProperty(PropertyName="surface_16_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface16Name { get; set; } = "";
        

[JsonProperty(PropertyName="surface_17_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface17Name { get; set; } = "";
        

[JsonProperty(PropertyName="surface_18_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface18Name { get; set; } = "";
        

[JsonProperty(PropertyName="surface_19_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface19Name { get; set; } = "";
        

[JsonProperty(PropertyName="surface_20_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface20Name { get; set; } = "";
        

[JsonProperty(PropertyName="surface_21_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface21Name { get; set; } = "";
    }
    
    public enum RoomAir_Node_NodeType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Ceiling")]
        Ceiling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Control")]
        Control = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Floor")]
        Floor = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Inlet")]
        Inlet = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="MundtRoom")]
        MundtRoom = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Return")]
        Return = 5,
    }
    
    [Description("The Mundt model for displacement ventilation")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoomAirSettings_OneNodeDisplacementVentilation
    {
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="fraction_of_convective_internal_loads_added_to_floor_air", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfConvectiveInternalLoadsAddedToFloorAir { get; set; } = null;
        

[JsonProperty(PropertyName="fraction_of_infiltration_internal_loads_added_to_floor_air", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfInfiltrationInternalLoadsAddedToFloorAir { get; set; } = null;
    }
    
    [Description("The UCSD model for Displacement Ventilation")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoomAirSettings_ThreeNodeDisplacementVentilation
    {
        

[Description("Name of Zone being described. Any existing zone name")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Distribution of the convective heat gains between the occupied and mixed zones. 0" +
    "<= Accepted Value <= 1. In the DV model 1 means all convective gains in the lowe" +
    "r layer.")]
[JsonProperty(PropertyName="gain_distribution_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string GainDistributionScheduleName { get; set; } = "";
        

[Description("Used only in the UCSD displacement ventilation model. Effective number of separat" +
    "e plumes per occupant in the occupied zone. Plumes that merge together in the oc" +
    "cupied zone count as one.")]
[JsonProperty(PropertyName="number_of_plumes_per_occupant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfPlumesPerOccupant { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Height of thermostat/temperature control sensor above floor")]
[JsonProperty(PropertyName="thermostat_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermostatHeight { get; set; } = Double.Parse("1.1", CultureInfo.InvariantCulture);
        

[Description("Height at which air temperature is calculated for comfort purposes")]
[JsonProperty(PropertyName="comfort_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ComfortHeight { get; set; } = Double.Parse("1.1", CultureInfo.InvariantCulture);
        

[Description(@"Minimum temperature difference between predicted upper and lower layer temperatures above which DV auxiliary outputs are calculated. These outputs are 'DV Transition Height', 'DV Fraction Min Recommended Flow Rate' 'DV Average Temp Gradient' and 'DV Maximum Temp Gradient'. They are set to negative values when the temperature difference is less than the threshold and the output 'DV Zone Is Mixed' is set to 1")]
[JsonProperty(PropertyName="temperature_difference_threshold_for_reporting", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureDifferenceThresholdForReporting { get; set; } = Double.Parse("0.4", CultureInfo.InvariantCulture);
    }
    
    [Description(@"This UCSD Cross Ventilation Room Air Model provides a simple model for heat transfer and vertical temperature profile prediction in cross ventilated rooms. The model distinguishes two regions in the room, the main jet region and the recirculations, and predicts characteristic airflow velocities and average air temperatures. Used with RoomAirModelType = CrossVentilation.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoomAirSettings_CrossVentilation
    {
        

[Description("Name of Zone being described. Any existing zone name")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Distribution of the convective heat gains between the jet and recirculation zones" +
    ". 0<= Accepted Value <= 1. In the CV model 1 means all convective gains in the j" +
    "et region.")]
[JsonProperty(PropertyName="gain_distribution_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string GainDistributionScheduleName { get; set; } = "";
        

[Description("Required field whenever thermal comfort is predicted defines Air temperature and " +
    "Airflow velocity that will be used in the Fanger model conditions must refer to " +
    "one of the two regions: jet or recirculation")]
[JsonProperty(PropertyName="airflow_region_used_for_thermal_comfort_evaluation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public RoomAirSettings_CrossVentilation_AirflowRegionUsedForThermalComfortEvaluation AirflowRegionUsedForThermalComfortEvaluation { get; set; } = (RoomAirSettings_CrossVentilation_AirflowRegionUsedForThermalComfortEvaluation)Enum.Parse(typeof(RoomAirSettings_CrossVentilation_AirflowRegionUsedForThermalComfortEvaluation), "Jet");
    }
    
    public enum RoomAirSettings_CrossVentilation_AirflowRegionUsedForThermalComfortEvaluation
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Jet")]
        Jet = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Recirculation")]
        Recirculation = 1,
    }
    
    [Description(@"This Room Air Model is applicable to interior spaces that are served by an underfloor air distribution system. The dominant sources of heat gain should be from people, equipment, and other localized sources located in the occupied part of the room. The model should be used with caution in zones which have large heat gains or losses through exterior walls or windows or which have considerable direct solar gain. Used with RoomAirModelType = UnderFloorAirDistributionInterior.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoomAirSettings_UnderFloorAirDistributionInterior
    {
        

[Description("Name of Zone with underfloor air distribution")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Total number of diffusers in this zone")]
[JsonProperty(PropertyName="number_of_diffusers", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> NumberOfDiffusers { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="power_per_plume", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> PowerPerPlume { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="design_effective_area_of_diffuser", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> DesignEffectiveAreaOfDiffuser { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="diffuser_slot_angle_from_vertical", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> DiffuserSlotAngleFromVertical { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Height of thermostat/temperature control sensor above floor")]
[JsonProperty(PropertyName="thermostat_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermostatHeight { get; set; } = Double.Parse("1.2", CultureInfo.InvariantCulture);
        

[Description("Height at which air temperature is calculated for comfort purposes")]
[JsonProperty(PropertyName="comfort_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ComfortHeight { get; set; } = Double.Parse("1.1", CultureInfo.InvariantCulture);
        

[Description(@"Minimum temperature difference between predicted upper and lower layer temperatures above which UFAD auxiliary outputs are calculated. These outputs are 'UF Transition Height' and 'UF Average Temp Gradient'. They are set to zero values when the temperature difference is less than the threshold and the output 'UF Zone Is Mixed' is set to 1")]
[JsonProperty(PropertyName="temperature_difference_threshold_for_reporting", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureDifferenceThresholdForReporting { get; set; } = Double.Parse("0.4", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="floor_diffuser_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public RoomAirSettings_UnderFloorAirDistributionInterior_FloorDiffuserType FloorDiffuserType { get; set; } = (RoomAirSettings_UnderFloorAirDistributionInterior_FloorDiffuserType)Enum.Parse(typeof(RoomAirSettings_UnderFloorAirDistributionInterior_FloorDiffuserType), "Swirl");
        

[Description("user-specified height above floor of boundary between occupied and upper subzones" +
    "")]
[JsonProperty(PropertyName="transition_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> TransitionHeight { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Coefficient A in Formula Kc = A*Gamma**B + C + D*Gamma + E*Gamma**2 Kc is the fra" +
    "ction of the total zone load attributable to the lower subzone")]
[JsonProperty(PropertyName="coefficient_a", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> CoefficientA { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Coefficient B in Formula Kc = A*Gamma**B + C + D*Gamma + E*Gamma**2 Kc is the fra" +
    "ction of the total zone load attributable to the lower subzone")]
[JsonProperty(PropertyName="coefficient_b", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> CoefficientB { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Coefficient C in Formula Kc = A*Gamma**B + C + D*Gamma + E*Gamma**2 Kc is the fra" +
    "ction of the total zone load attributable to the lower subzone")]
[JsonProperty(PropertyName="coefficient_c", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> CoefficientC { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Coefficient D in Formula Kc = A*Gamma**B + C + D*Gamma + E*Gamma**2 Kc is the fra" +
    "ction of the total zone load attributable to the lower subzone")]
[JsonProperty(PropertyName="coefficient_d", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> CoefficientD { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Coefficient E in Formula Kc = A*Gamma**B + C + D*Gamma + E*Gamma**2 Kc is the fra" +
    "ction of the total zone load attributable to the lower subzone")]
[JsonProperty(PropertyName="coefficient_e", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> CoefficientE { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
    }
    
    public enum RoomAirSettings_UnderFloorAirDistributionInterior_FloorDiffuserType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Custom")]
        Custom = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HorizontalSwirl")]
        HorizontalSwirl = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="LinearBarGrille")]
        LinearBarGrille = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Swirl")]
        Swirl = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableArea")]
        VariableArea = 5,
    }
    
    [Description(@"Applicable to exterior spaces that are served by an underfloor air distribution system. The dominant sources of heat gain should be from people, equipment, and other localized sources located in the occupied part of the room, as well as convective gain coming from a warm window. Used with RoomAirModelType = CrossVentilation.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoomAirSettings_UnderFloorAirDistributionExterior
    {
        

[Description("Name of Zone being described. Any existing zone name")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="number_of_diffusers_per_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> NumberOfDiffusersPerZone { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="power_per_plume", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> PowerPerPlume { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="design_effective_area_of_diffuser", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> DesignEffectiveAreaOfDiffuser { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="diffuser_slot_angle_from_vertical", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> DiffuserSlotAngleFromVertical { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Height of thermostat/temperature control sensor above floor")]
[JsonProperty(PropertyName="thermostat_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermostatHeight { get; set; } = Double.Parse("1.2", CultureInfo.InvariantCulture);
        

[Description("Height at which Air temperature is calculated for comfort purposes")]
[JsonProperty(PropertyName="comfort_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ComfortHeight { get; set; } = Double.Parse("1.1", CultureInfo.InvariantCulture);
        

[Description(@"Minimum temperature difference between upper and lower layer temperatures above which UFAD auxiliary outputs are calculated. These outputs are 'UF Transition Height' and 'UF Average Temp Gradient'. They are set to zero values when the temperature difference is less than the threshold and the output 'UF Zone Is Mixed' is set to 1")]
[JsonProperty(PropertyName="temperature_difference_threshold_for_reporting", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureDifferenceThresholdForReporting { get; set; } = Double.Parse("0.4", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="floor_diffuser_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public RoomAirSettings_UnderFloorAirDistributionExterior_FloorDiffuserType FloorDiffuserType { get; set; } = (RoomAirSettings_UnderFloorAirDistributionExterior_FloorDiffuserType)Enum.Parse(typeof(RoomAirSettings_UnderFloorAirDistributionExterior_FloorDiffuserType), "Swirl");
        

[Description("User-specified height above floor of boundary between occupied and upper subzones" +
    "")]
[JsonProperty(PropertyName="transition_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> TransitionHeight { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Kc is the fraction of the total zone load attributable to the lower subzone")]
[JsonProperty(PropertyName="coefficient_a_in_formula_kc_a_gamma_b_c_d_gamma_e_gamma_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> CoefficientAInFormulaKcAGammaBCDGammaEGamma2 { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Kc is the fraction of the total zone load attributable to the lower subzone")]
[JsonProperty(PropertyName="coefficient_b_in_formula_kc_a_gamma_b_c_d_gamma_e_gamma_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> CoefficientBInFormulaKcAGammaBCDGammaEGamma2 { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Kc is the fraction of the total zone load attributable to the lower subzone")]
[JsonProperty(PropertyName="coefficient_c_in_formula_kc_a_gamma_b_c_d_gamma_e_gamma_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> CoefficientCInFormulaKcAGammaBCDGammaEGamma2 { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Kc is the fraction of the total zone load attributable to the lower subzone")]
[JsonProperty(PropertyName="coefficient_d_in_formula_kc_a_gamma_b_c_d_gamma_e_gamma_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> CoefficientDInFormulaKcAGammaBCDGammaEGamma2 { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Kc is the fraction of the total zone load attributable to the lower subzone")]
[JsonProperty(PropertyName="coefficient_e_in_formula_kc_a_gamma_b_c_d_gamma_e_gamma_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> CoefficientEInFormulaKcAGammaBCDGammaEGamma2 { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
    }
    
    public enum RoomAirSettings_UnderFloorAirDistributionExterior_FloorDiffuserType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Custom")]
        Custom = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HorizontalSwirl")]
        HorizontalSwirl = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="LinearBarGrille")]
        LinearBarGrille = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Swirl")]
        Swirl = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableArea")]
        VariableArea = 5,
    }
    
    [Description("define an air node for some types of nodal air models")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoomAir_Node_AirflowNetwork
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="fraction_of_zone_air_volume", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfZoneAirVolume { get; set; } = null;
        

[JsonProperty(PropertyName="roomair_node_airflownetwork_adjacentsurfacelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RoomairNodeAirflownetworkAdjacentsurfacelistName { get; set; } = "";
        

[JsonProperty(PropertyName="roomair_node_airflownetwork_internalgains_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RoomairNodeAirflownetworkInternalgainsName { get; set; } = "";
        

[JsonProperty(PropertyName="roomair_node_airflownetwork_hvacequipment_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RoomairNodeAirflownetworkHvacequipmentName { get; set; } = "";
    }
    
    [Description(null)]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoomAir_Node_AirflowNetwork_AdjacentSurfaceList
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("This list is the AllHeatTranSurfNames object-list")]
[JsonProperty(PropertyName="surfaces", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Surfaces { get; set; } = null;
    }
    
    [Description("define the internal gains that are associated with one particular RoomAir:Node")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoomAir_Node_AirflowNetwork_InternalGains
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="gains", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_Node_AirflowNetwork_InternalGains_Gains_Item> Gains { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoomAir_Node_AirflowNetwork_InternalGains_Gains_Item
    {
        

[JsonProperty(PropertyName="internal_gain_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InternalGainObjectType { get; set; } = "";
        

[JsonProperty(PropertyName="internal_gain_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InternalGainObjectName { get; set; } = "";
        

[JsonProperty(PropertyName="fraction_of_gains_to_node", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfGainsToNode { get; set; } = null;
    }
    
    [Description("define the zone equipment associated with one particular RoomAir:Node")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoomAir_Node_AirflowNetwork_HVACEquipment
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="equipment_fractions", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_Node_AirflowNetwork_HVACEquipment_EquipmentFractions_Item> EquipmentFractions { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoomAir_Node_AirflowNetwork_HVACEquipment_EquipmentFractions_Item
    {
        

[JsonProperty(PropertyName="zonehvac_or_air_terminal_equipment_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZonehvacOrAirTerminalEquipmentObjectType { get; set; } = "";
        

[JsonProperty(PropertyName="zonehvac_or_air_terminal_equipment_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZonehvacOrAirTerminalEquipmentObjectName { get; set; } = "";
        

[JsonProperty(PropertyName="fraction_of_output_or_supply_air_from_hvac_equipment", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfOutputOrSupplyAirFromHvacEquipment { get; set; } = null;
        

[JsonProperty(PropertyName="fraction_of_input_or_return_air_to_hvac_equipment", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfInputOrReturnAirToHvacEquipment { get; set; } = null;
    }
    
    [Description("RoomAir modeling using Airflow pressure network solver")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoomAirSettings_AirflowNetwork
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Name of Zone being described. Any existing zone name")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="control_point_roomairflownetwork_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlPointRoomairflownetworkNodeName { get; set; } = "";
        

[Description("This list is the RoomAirflowNetworkNodes object-list")]
[JsonProperty(PropertyName="nodes", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Nodes { get; set; } = null;
    }
}
