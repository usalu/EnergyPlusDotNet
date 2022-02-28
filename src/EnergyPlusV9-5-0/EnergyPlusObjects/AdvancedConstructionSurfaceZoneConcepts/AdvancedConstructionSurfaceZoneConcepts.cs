namespace EnergyPlus.AdvancedConstructionSurfaceZoneConcepts
{
    using System.ComponentModel;
    using EnergyPlus;
    using System;
    using System.Globalization;
    using Newtonsoft.Json;
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
    using EnergyPlus.WaterSystems;
    using EnergyPlus.ZoneAirflow;
    using EnergyPlus.ZoneHVACAirLoopTerminalUnits;
    using EnergyPlus.ZoneHVACControlsandThermostats;
    using EnergyPlus.ZoneHVACEquipmentConnections;
    using EnergyPlus.ZoneHVACForcedAirUnits;
    using EnergyPlus.ZoneHVACRadiativeConvectiveUnits;
    
    
    [Description(@"Determines which Heat Balance Algorithm will be used for a specific surface Allows selectively overriding the global setting in HeatBalanceAlgorithm CTF (Conduction Transfer Functions), EMPD (Effective Moisture Penetration Depth with Conduction Transfer Functions). Advanced/Research Usage: CondFD (Conduction Finite Difference) Advanced/Research Usage: HAMT (Combined Heat And Moisture Finite Element)")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceProperty_HeatTransferAlgorithm
    {
        

[JsonProperty(PropertyName="surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceName { get; set; } = "";
        

[JsonProperty(PropertyName="algorithm", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceProperty_HeatTransferAlgorithm_Algorithm Algorithm { get; set; } = (SurfaceProperty_HeatTransferAlgorithm_Algorithm)Enum.Parse(typeof(SurfaceProperty_HeatTransferAlgorithm_Algorithm), "ConductionTransferFunction");
    }
    
    public enum SurfaceProperty_HeatTransferAlgorithm_Algorithm
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CombinedHeatAndMoistureFiniteElement")]
        CombinedHeatAndMoistureFiniteElement = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ConductionFiniteDifference")]
        ConductionFiniteDifference = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ConductionTransferFunction")]
        ConductionTransferFunction = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="MoisturePenetrationDepthConductionTransferFunction")]
        MoisturePenetrationDepthConductionTransferFunction = 4,
    }
    
    [Description(@"Determines which Heat Balance Algorithm will be used for a group of surface types Allows selectively overriding the global setting in HeatBalanceAlgorithm CTF (Conduction Transfer Functions), EMPD (Effective Moisture Penetration Depth with Conduction Transfer Functions). Advanced/Research Usage: CondFD (Conduction Finite Difference) Advanced/Research Usage: HAMT (Combined Heat And Moisture Finite Element)")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceProperty_HeatTransferAlgorithm_MultipleSurface
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="surface_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceProperty_HeatTransferAlgorithm_MultipleSurface_SurfaceType SurfaceType { get; set; } = (SurfaceProperty_HeatTransferAlgorithm_MultipleSurface_SurfaceType)Enum.Parse(typeof(SurfaceProperty_HeatTransferAlgorithm_MultipleSurface_SurfaceType), "AllExteriorFloors");
        

[JsonProperty(PropertyName="algorithm", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceProperty_HeatTransferAlgorithm_MultipleSurface_Algorithm Algorithm { get; set; } = (SurfaceProperty_HeatTransferAlgorithm_MultipleSurface_Algorithm)Enum.Parse(typeof(SurfaceProperty_HeatTransferAlgorithm_MultipleSurface_Algorithm), "ConductionTransferFunction");
    }
    
    public enum SurfaceProperty_HeatTransferAlgorithm_MultipleSurface_SurfaceType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AllExteriorFloors")]
        AllExteriorFloors = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AllExteriorRoofs")]
        AllExteriorRoofs = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AllExteriorSurfaces")]
        AllExteriorSurfaces = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="AllExteriorWalls")]
        AllExteriorWalls = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="AllGroundContactSurfaces")]
        AllGroundContactSurfaces = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="AllInteriorCeilings")]
        AllInteriorCeilings = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="AllInteriorFloors")]
        AllInteriorFloors = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="AllInteriorSurfaces")]
        AllInteriorSurfaces = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="AllInteriorWalls")]
        AllInteriorWalls = 8,
    }
    
    public enum SurfaceProperty_HeatTransferAlgorithm_MultipleSurface_Algorithm
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CombinedHeatAndMoistureFiniteElement")]
        CombinedHeatAndMoistureFiniteElement = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ConductionFiniteDifference")]
        ConductionFiniteDifference = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ConductionTransferFunction")]
        ConductionTransferFunction = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="MoisturePenetrationDepthConductionTransferFunction")]
        MoisturePenetrationDepthConductionTransferFunction = 4,
    }
    
    [Description(@"Determines which Heat Balance Algorithm will be used for a list of surfaces Allows selectively overriding the global setting in HeatBalanceAlgorithm CTF (Conduction Transfer Functions), EMPD (Effective Moisture Penetration Depth with Conduction Transfer Functions). Advanced/Research Usage: CondFD (Conduction Finite Difference) Advanced/Research Usage: HAMT (Combined Heat And Moisture Finite Element)")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceProperty_HeatTransferAlgorithm_SurfaceList
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="algorithm", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceProperty_HeatTransferAlgorithm_SurfaceList_Algorithm Algorithm { get; set; } = (SurfaceProperty_HeatTransferAlgorithm_SurfaceList_Algorithm)Enum.Parse(typeof(SurfaceProperty_HeatTransferAlgorithm_SurfaceList_Algorithm), "ConductionTransferFunction");
        

[Description("This list is the SurfaceNames object-list")]
[JsonProperty(PropertyName="surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Surface { get; set; } = null;
    }
    
    public enum SurfaceProperty_HeatTransferAlgorithm_SurfaceList_Algorithm
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CombinedHeatAndMoistureFiniteElement")]
        CombinedHeatAndMoistureFiniteElement = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ConductionFiniteDifference")]
        ConductionFiniteDifference = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ConductionTransferFunction")]
        ConductionTransferFunction = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="MoisturePenetrationDepthConductionTransferFunction")]
        MoisturePenetrationDepthConductionTransferFunction = 4,
    }
    
    [Description(@"Determines which Heat Balance Algorithm will be used for surfaces that have a specific type of construction Allows selectively overriding the global setting in HeatBalanceAlgorithm CTF (Conduction Transfer Functions), EMPD (Effective Moisture Penetration Depth with Conduction Transfer Functions). Advanced/Research Usage: CondFD (Conduction Finite Difference) Advanced/Research Usage: HAMT (Combined Heat And Moisture Finite Element)")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceProperty_HeatTransferAlgorithm_Construction
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="algorithm", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceProperty_HeatTransferAlgorithm_Construction_Algorithm Algorithm { get; set; } = (SurfaceProperty_HeatTransferAlgorithm_Construction_Algorithm)Enum.Parse(typeof(SurfaceProperty_HeatTransferAlgorithm_Construction_Algorithm), "ConductionTransferFunction");
        

[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
    }
    
    public enum SurfaceProperty_HeatTransferAlgorithm_Construction_Algorithm
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CombinedHeatAndMoistureFiniteElement")]
        CombinedHeatAndMoistureFiniteElement = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ConductionFiniteDifference")]
        ConductionFiniteDifference = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ConductionTransferFunction")]
        ConductionTransferFunction = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="MoisturePenetrationDepthConductionTransferFunction")]
        MoisturePenetrationDepthConductionTransferFunction = 4,
    }
    
    [Description("Allows an additional heat source term to be added to the inside or outside surfac" +
        "e boundary. A heat source can be added to either or both the inside and outside " +
        "of the same surface.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceProperty_HeatBalanceSourceTerm
    {
        

[JsonProperty(PropertyName="surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceName { get; set; } = "";
        

[Description(@"The value of this schedule is the source term value for the inside face of this surface If this field is left blank, no inside surface source term will be applied. The schedule values are heat rate per surface area (W/m2), when positive schedule values indicate heat gain and negative values indicates loss.")]
[JsonProperty(PropertyName="inside_face_heat_source_term_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InsideFaceHeatSourceTermScheduleName { get; set; } = "";
        

[Description(@"The value of this schedule is the source term value for the outside face of this surface If this field is left blank, no outside surface source term will be applied. The schedule values are heat rate per surface area (W/m2), when positive schedule values indicate heat gain and negative values indicates loss.")]
[JsonProperty(PropertyName="outside_face_heat_source_term_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutsideFaceHeatSourceTermScheduleName { get; set; } = "";
    }
    
    [Description("Exterior or Interior Insulation on opaque surfaces")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceControl_MovableInsulation
    {
        

[JsonProperty(PropertyName="insulation_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceControl_MovableInsulation_InsulationType InsulationType { get; set; } = (SurfaceControl_MovableInsulation_InsulationType)Enum.Parse(typeof(SurfaceControl_MovableInsulation_InsulationType), "Inside");
        

[JsonProperty(PropertyName="surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceName { get; set; } = "";
        

[JsonProperty(PropertyName="material_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaterialName { get; set; } = "";
        

[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
    }
    
    public enum SurfaceControl_MovableInsulation_InsulationType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Inside")]
        Inside = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Outside")]
        Outside = 1,
    }
    
    [Description("This object sets the other side conditions for a surface in a variety of ways.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceProperty_OtherSideCoefficients
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description(@"if>0, this field becomes the exterior convective/radiative film coefficient and the other fields are used to calculate the outdoor air temperature then exterior surface temperature based on outdoor air and specified coefficient if<=0, then remaining fields calculate the outside surface temperature The following fields are used in the equation: OtherSideTemp=N2*N3 + N4*OutdoorDry-bulb + N5*GroundTemp + N6*WindSpeed*OutdoorDry-bulb + N7*TempZone + N9*TempPrev")]
[JsonProperty(PropertyName="combined_convective_radiative_film_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CombinedConvectiveRadiativeFilmCoefficient { get; set; } = null;
        

[Description("This parameter will be overwritten by the values from the Constant Temperature Sc" +
    "hedule Name (below) if one is present")]
[JsonProperty(PropertyName="constant_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConstantTemperature { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This coefficient is used even with a Schedule. It should normally be 1.0 in that " +
    "case. This field is ignored if Sinusoidal Variation of Constant Temperature Coef" +
    "ficient = Yes.")]
[JsonProperty(PropertyName="constant_temperature_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConstantTemperatureCoefficient { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="external_dry_bulb_temperature_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ExternalDryBulbTemperatureCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="ground_temperature_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GroundTemperatureCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="wind_speed_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WindSpeedCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="zone_air_temperature_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneAirTemperatureCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Name of schedule for values of constant temperature. Schedule values replace any " +
    "value specified in the field Constant Temperature.")]
[JsonProperty(PropertyName="constant_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstantTemperatureScheduleName { get; set; } = "";
        

[Description("Optionally used to vary Constant Temperature Coefficient with unitary sine wave")]
[JsonProperty(PropertyName="sinusoidal_variation_of_constant_temperature_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes SinusoidalVariationOfConstantTemperatureCoefficient { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("Use with sinusoidal variation to define the time period")]
[JsonProperty(PropertyName="period_of_sinusoidal_variation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PeriodOfSinusoidalVariation { get; set; } = Double.Parse("24", CultureInfo.InvariantCulture);
        

[Description("This coefficient multiplies the other side temperature result from the previous z" +
    "one timestep")]
[JsonProperty(PropertyName="previous_other_side_temperature_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PreviousOtherSideTemperatureCoefficient { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This field specifies a lower limit for the other side temperature result. Blank i" +
    "ndicates no limit")]
[JsonProperty(PropertyName="minimum_other_side_temperature_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumOtherSideTemperatureLimit { get; set; } = null;
        

[Description("This field specifies an upper limit for the other side temperature result. Blank " +
    "indicates no limit")]
[JsonProperty(PropertyName="maximum_other_side_temperature_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumOtherSideTemperatureLimit { get; set; } = null;
    }
    
    [Description("This object sets up modifying the other side conditions for a surface from other " +
        "model results.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceProperty_OtherSideConditionsModel
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description(@"GapConvectionRadiation provides boundary conditions for convection and linearized thermal radiation across a gap or cavity on the other side of the surface that are modeled separately. UndergroundPipingSystemSurface provides boundary conditions for surfaces in contact with PipingSystem:Underground domains GroundCoupledSurface provides boundary conditions for surfaces in contact with GroundDomain objects ConvectiveUnderwater provides a connection between a surface and an underwater boundary condition defined using a SurfaceProperty:Underwater object")]
[JsonProperty(PropertyName="type_of_modeling", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceProperty_OtherSideConditionsModel_TypeOfModeling TypeOfModeling { get; set; } = (SurfaceProperty_OtherSideConditionsModel_TypeOfModeling)Enum.Parse(typeof(SurfaceProperty_OtherSideConditionsModel_TypeOfModeling), "GapConvectionRadiation");
    }
    
    public enum SurfaceProperty_OtherSideConditionsModel_TypeOfModeling
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ConvectiveUnderwater")]
        ConvectiveUnderwater = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="GapConvectionRadiation")]
        GapConvectionRadiation = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundCoupledSurface")]
        GroundCoupledSurface = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="UndergroundPipingSystemSurface")]
        UndergroundPipingSystemSurface = 4,
    }
    
    [Description("This object sets up a convective water boundary condition for a surface The free " +
        "stream temperature and velocity are scheduled. If the free stream velocity is ze" +
        "ro, the surface will naturally convect with the surrounding water.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceProperty_Underwater
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("This is the distance from the leading edge of the boundary layer development to t" +
    "he centroid of the surface of interest. The value of this field is used as the d" +
    "istance in the Reynolds number for evaluating the local convection coefficient.")]
[JsonProperty(PropertyName="distance_from_surface_centroid_to_leading_edge_of_boundary_layer", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistanceFromSurfaceCentroidToLeadingEdgeOfBoundaryLayer { get; set; } = null;
        

[JsonProperty(PropertyName="free_stream_water_temperature_schedule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FreeStreamWaterTemperatureSchedule { get; set; } = "";
        

[JsonProperty(PropertyName="free_stream_water_velocity_schedule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FreeStreamWaterVelocitySchedule { get; set; } = "";
    }
    
    [Description("Refined definition of the foundation surface construction used to inform two-dime" +
        "nsional heat transfer calculated using the Kiva ground heat transfer methodology" +
        ".")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Foundation_Kiva
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Indoor air temperature used for Kiva initialization (prior to warmup period) If l" +
    "eft blank, indoor air temperature will be determined based on zone setpoints")]
[JsonProperty(PropertyName="initial_indoor_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InitialIndoorAirTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="interior_horizontal_insulation_material_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InteriorHorizontalInsulationMaterialName { get; set; } = "";
        

[Description("Distance from the slab bottom to the top of interior horizontal insulation")]
[JsonProperty(PropertyName="interior_horizontal_insulation_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InteriorHorizontalInsulationDepth { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Extent of insulation as measured from the wall interior")]
[JsonProperty(PropertyName="interior_horizontal_insulation_width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InteriorHorizontalInsulationWidth { get; set; } = null;
        

[JsonProperty(PropertyName="interior_vertical_insulation_material_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InteriorVerticalInsulationMaterialName { get; set; } = "";
        

[Description("Extent of insulation as measured from the wall top to the bottom edge of the inte" +
    "rior vertical insulation")]
[JsonProperty(PropertyName="interior_vertical_insulation_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InteriorVerticalInsulationDepth { get; set; } = null;
        

[JsonProperty(PropertyName="exterior_horizontal_insulation_material_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ExteriorHorizontalInsulationMaterialName { get; set; } = "";
        

[Description("Distance from the exterior grade to the top of exterior horizontal insulation")]
[JsonProperty(PropertyName="exterior_horizontal_insulation_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ExteriorHorizontalInsulationDepth { get; set; } = null;
        

[Description("Extent of insulation as measured from the wall exterior")]
[JsonProperty(PropertyName="exterior_horizontal_insulation_width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ExteriorHorizontalInsulationWidth { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="exterior_vertical_insulation_material_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ExteriorVerticalInsulationMaterialName { get; set; } = "";
        

[Description("Extent of insulation as measured from the wall top to the bottom edge of the exte" +
    "rior vertical insulation")]
[JsonProperty(PropertyName="exterior_vertical_insulation_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ExteriorVerticalInsulationDepth { get; set; } = null;
        

[Description("Distance from the exterior grade to the wall top")]
[JsonProperty(PropertyName="wall_height_above_grade", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WallHeightAboveGrade { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[Description("Distance from the slab bottom to the bottom of the foundation wall")]
[JsonProperty(PropertyName="wall_depth_below_slab", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WallDepthBelowSlab { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Defines the below-grade surface construction for slabs. Required if foundation wa" +
    "ll is not exposed to the zone.")]
[JsonProperty(PropertyName="footing_wall_construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FootingWallConstructionName { get; set; } = "";
        

[JsonProperty(PropertyName="footing_material_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FootingMaterialName { get; set; } = "";
        

[Description("Top-to-bottom dimension of the footing (not to be confused with its depth in the " +
    "ground). The width of the footing is defined by the material\'s thickness.")]
[JsonProperty(PropertyName="footing_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FootingDepth { get; set; } = Double.Parse("0.3", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="blocks", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.Foundation_Kiva_Blocks_Item> Blocks { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Foundation_Kiva_Blocks_Item
    {
        

[JsonProperty(PropertyName="custom_block_material_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CustomBlockMaterialName { get; set; } = "";
        

[JsonProperty(PropertyName="custom_block_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CustomBlockDepth { get; set; } = null;
        

[JsonProperty(PropertyName="custom_block_x_position", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CustomBlockXPosition { get; set; } = null;
        

[JsonProperty(PropertyName="custom_block_z_position", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CustomBlockZPosition { get; set; } = null;
    }
    
    [Description("Settings applied across all Kiva foundation calculations. Object is not required." +
        " If not defined, defaults will be applied.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Foundation_Kiva_Settings
    {
        

[JsonProperty(PropertyName="soil_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilConductivity { get; set; } = Double.Parse("1.73", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_density", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilDensity { get; set; } = Double.Parse("1842", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_specific_heat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilSpecificHeat { get; set; } = Double.Parse("419", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="ground_solar_absorptivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GroundSolarAbsorptivity { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="ground_thermal_absorptivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GroundThermalAbsorptivity { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="ground_surface_roughness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GroundSurfaceRoughness { get; set; } = Double.Parse("0.03", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="far_field_width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FarFieldWidth { get; set; } = Double.Parse("40", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="deep_ground_boundary_condition", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Foundation_Kiva_Settings_DeepGroundBoundaryCondition DeepGroundBoundaryCondition { get; set; } = (Foundation_Kiva_Settings_DeepGroundBoundaryCondition)Enum.Parse(typeof(Foundation_Kiva_Settings_DeepGroundBoundaryCondition), "Autoselect");
        

[JsonProperty(PropertyName="deep_ground_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> DeepGroundDepth { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_cell_dimension", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCellDimension { get; set; } = Double.Parse("0.02", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_cell_growth_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCellGrowthCoefficient { get; set; } = Double.Parse("1.5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="simulation_timestep", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Foundation_Kiva_Settings_SimulationTimestep SimulationTimestep { get; set; } = (Foundation_Kiva_Settings_SimulationTimestep)Enum.Parse(typeof(Foundation_Kiva_Settings_SimulationTimestep), "Hourly");
    }
    
    public enum Foundation_Kiva_Settings_DeepGroundBoundaryCondition
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Autoselect")]
        Autoselect = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundWater")]
        GroundWater = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ZeroFlux")]
        ZeroFlux = 3,
    }
    
    public enum Foundation_Kiva_Settings_SimulationTimestep
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Hourly")]
        Hourly = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Timestep")]
        Timestep = 2,
    }
    
    [Description(@"Defines the perimeter of a foundation floor that is exposed to the exterior environment through the floor. User may either define the total exposed perimeter, fraction of perimeter exposed or individually define which segments of the floor surface perimeter are exposed.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceProperty_ExposedFoundationPerimeter
    {
        

[JsonProperty(PropertyName="surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceName { get; set; } = "";
        

[Description(@"Choices: TotalExposedPerimeter => total exposed perimeter in meters ExposedPerimeterFraction => fraction of total perimeter that is exposed. Value * Fraction = Total exposed perimeter BySegment => define whether the segment between each set of consecutive vertices of the floor surface is exposed. SUM(exposed segement lengths) = Total exposed perimeter")]
[JsonProperty(PropertyName="exposed_perimeter_calculation_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceProperty_ExposedFoundationPerimeter_ExposedPerimeterCalculationMethod ExposedPerimeterCalculationMethod { get; set; } = (SurfaceProperty_ExposedFoundationPerimeter_ExposedPerimeterCalculationMethod)Enum.Parse(typeof(SurfaceProperty_ExposedFoundationPerimeter_ExposedPerimeterCalculationMethod), "BySegment");
        

[JsonProperty(PropertyName="total_exposed_perimeter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TotalExposedPerimeter { get; set; } = null;
        

[JsonProperty(PropertyName="exposed_perimeter_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ExposedPerimeterFraction { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="surfaces", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Surfaces { get; set; } = null;
    }
    
    public enum SurfaceProperty_ExposedFoundationPerimeter_ExposedPerimeterCalculationMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="BySegment")]
        BySegment = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ExposedPerimeterFraction")]
        ExposedPerimeterFraction = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TotalExposedPerimeter")]
        TotalExposedPerimeter = 2,
    }
    
    [Description(@"Options to change the individual convection model equations for dynamic selection when using AdaptiveConvectiongAlgorithm This object is only needed to make changes to the default model selections for any or all of the surface categories. This object is for the inside face, the side of the surface facing a thermal zone.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Applies to zone with no HVAC or when HVAC is off This is for vertical walls")]
[JsonProperty(PropertyName="simple_buoyancy_vertical_wall_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyVerticalWallEquationSource SimpleBuoyancyVerticalWallEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyVerticalWallEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyVerticalWallEquationSource), "FohannoPolidoriVerticalWall");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="simple_buoyancy_vertical_wall_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SimpleBuoyancyVerticalWallUserCurveName { get; set; } = "";
        

[Description("Applies to zone with no HVAC or when HVAC is off This is for horizontal surfaces " +
    "with heat flow directed for stable thermal stratification")]
[JsonProperty(PropertyName="simple_buoyancy_stable_horizontal_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyStableHorizontalEquationSource SimpleBuoyancyStableHorizontalEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyStableHorizontalEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyStableHorizontalEquationSource), "AlamdariHammondStableHorizontal");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="simple_buoyancy_stable_horizontal_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SimpleBuoyancyStableHorizontalEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with no HVAC or when HVAC is off This is for passive horizontal s" +
    "urfaces with heat flow for unstable thermal stratification")]
[JsonProperty(PropertyName="simple_buoyancy_unstable_horizontal_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyUnstableHorizontalEquationSource SimpleBuoyancyUnstableHorizontalEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyUnstableHorizontalEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyUnstableHorizontalEquationSource), "AlamdariHammondUnstableHorizontal");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="simple_buoyancy_unstable_horizontal_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SimpleBuoyancyUnstableHorizontalEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with no HVAC or when HVAC is off This is for tilted surfaces with" +
    " heat flow for stable thermal stratification")]
[JsonProperty(PropertyName="simple_buoyancy_stable_tilted_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyStableTiltedEquationSource SimpleBuoyancyStableTiltedEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyStableTiltedEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyStableTiltedEquationSource), "WaltonStableHorizontalOrTilt");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="simple_buoyancy_stable_tilted_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SimpleBuoyancyStableTiltedEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with no HVAC or when HVAC is off This is for tilted surfaces with" +
    " heat flow for unstable thermal stratification")]
[JsonProperty(PropertyName="simple_buoyancy_unstable_tilted_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyUnstableTiltedEquationSource SimpleBuoyancyUnstableTiltedEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyUnstableTiltedEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyUnstableTiltedEquationSource), "WaltonUnstableHorizontalOrTilt");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="simple_buoyancy_unstable_tilted_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SimpleBuoyancyUnstableTiltedEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with no HVAC or when HVAC is off This is for all window surfaces")]
[JsonProperty(PropertyName="simple_buoyancy_windows_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyWindowsEquationSource SimpleBuoyancyWindowsEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyWindowsEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyWindowsEquationSource), "ISO15099Windows");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="simple_buoyancy_windows_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SimpleBuoyancyWindowsEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with in-floor heating and/or in-ceiling cooling This is for verti" +
    "cal walls")]
[JsonProperty(PropertyName="floor_heat_ceiling_cool_vertical_wall_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolVerticalWallEquationSource FloorHeatCeilingCoolVerticalWallEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolVerticalWallEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolVerticalWallEquationSource), "KhalifaEq3WallAwayFromHeat");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="floor_heat_ceiling_cool_vertical_wall_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FloorHeatCeilingCoolVerticalWallEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with in-floor heating and/or in-ceiling cooling This is for passi" +
    "ve horizontal surfaces with heat flow for stable thermal stratification")]
[JsonProperty(PropertyName="floor_heat_ceiling_cool_stable_horizontal_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolStableHorizontalEquationSource FloorHeatCeilingCoolStableHorizontalEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolStableHorizontalEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolStableHorizontalEquationSource), "AlamdariHammondStableHorizontal");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="floor_heat_ceiling_cool_stable_horizontal_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FloorHeatCeilingCoolStableHorizontalEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with in-floor heating and/or in-ceiling cooling This is for passi" +
    "ve horizontal surfaces with heat flow for unstable thermal stratification")]
[JsonProperty(PropertyName="floor_heat_ceiling_cool_unstable_horizontal_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolUnstableHorizontalEquationSource FloorHeatCeilingCoolUnstableHorizontalEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolUnstableHorizontalEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolUnstableHorizontalEquationSource), "KhalifaEq4CeilingAwayFromHeat");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="floor_heat_ceiling_cool_unstable_horizontal_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FloorHeatCeilingCoolUnstableHorizontalEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with in-floor heating and/or in-ceiling cooling This is for a flo" +
    "or with active heating elements")]
[JsonProperty(PropertyName="floor_heat_ceiling_cool_heated_floor_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolHeatedFloorEquationSource FloorHeatCeilingCoolHeatedFloorEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolHeatedFloorEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolHeatedFloorEquationSource), "AwbiHattonHeatedFloor");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="floor_heat_ceiling_cool_heated_floor_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FloorHeatCeilingCoolHeatedFloorEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with in-floor heating and/or in-ceiling cooling This is for a cei" +
    "ling with active cooling elements")]
[JsonProperty(PropertyName="floor_heat_ceiling_cool_chilled_ceiling_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolChilledCeilingEquationSource FloorHeatCeilingCoolChilledCeilingEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolChilledCeilingEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolChilledCeilingEquationSource), "KaradagChilledCeiling");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="floor_heat_ceiling_cool_chilled_ceiling_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FloorHeatCeilingCoolChilledCeilingEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with in-floor heating and/or in-ceiling cooling This is for tilte" +
    "d surfaces with heat flow for stable thermal stratification")]
[JsonProperty(PropertyName="floor_heat_ceiling_cool_stable_tilted_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolStableTiltedEquationSource FloorHeatCeilingCoolStableTiltedEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolStableTiltedEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolStableTiltedEquationSource), "WaltonStableHorizontalOrTilt");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="floor_heat_ceiling_cool_stable_tilted_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FloorHeatCeilingCoolStableTiltedEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with in-floor heating and/or in-ceiling cooling This is for tilte" +
    "d surfaces with heat flow for unstable thermal stratification")]
[JsonProperty(PropertyName="floor_heat_ceiling_cool_unstable_tilted_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolUnstableTiltedEquationSource FloorHeatCeilingCoolUnstableTiltedEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolUnstableTiltedEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolUnstableTiltedEquationSource), "WaltonUnstableHorizontalOrTilt");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="floor_heat_ceiling_cool_unstable_tilted_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FloorHeatCeilingCoolUnstableTiltedEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with in-floor heating and/or in-ceiling cooling This is for all w" +
    "indow surfaces")]
[JsonProperty(PropertyName="floor_heat_ceiling_cool_window_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolWindowEquationSource FloorHeatCeilingCoolWindowEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolWindowEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolWindowEquationSource), "ISO15099Windows");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="floor_heat_ceiling_cool_window_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FloorHeatCeilingCoolWindowEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with in-wall panel heating This is for vertical walls that are no" +
    "t actively heated")]
[JsonProperty(PropertyName="wall_panel_heating_vertical_wall_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingVerticalWallEquationSource WallPanelHeatingVerticalWallEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingVerticalWallEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingVerticalWallEquationSource), "KhalifaEq6NonHeatedWalls");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="wall_panel_heating_vertical_wall_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WallPanelHeatingVerticalWallEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with in-wall panel heating This is for vertical walls that are be" +
    "ing actively heated")]
[JsonProperty(PropertyName="wall_panel_heating_heated_wall_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingHeatedWallEquationSource WallPanelHeatingHeatedWallEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingHeatedWallEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingHeatedWallEquationSource), "AwbiHattonHeatedWall");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="wall_panel_heating_heated_wall_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WallPanelHeatingHeatedWallEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with in-wall panel heating This is for horizontal surfaces with h" +
    "eat flow directed for stable thermal stratification")]
[JsonProperty(PropertyName="wall_panel_heating_stable_horizontal_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingStableHorizontalEquationSource WallPanelHeatingStableHorizontalEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingStableHorizontalEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingStableHorizontalEquationSource), "AlamdariHammondStableHorizontal");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="wall_panel_heating_stable_horizontal_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WallPanelHeatingStableHorizontalEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with in-wall panel heating This is for horizontal surfaces with h" +
    "eat flow directed for unstable thermal stratification")]
[JsonProperty(PropertyName="wall_panel_heating_unstable_horizontal_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingUnstableHorizontalEquationSource WallPanelHeatingUnstableHorizontalEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingUnstableHorizontalEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingUnstableHorizontalEquationSource), "KhalifaEq7Ceiling");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="wall_panel_heating_unstable_horizontal_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WallPanelHeatingUnstableHorizontalEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with in-wall panel heating This is for tilted surfaces with heat " +
    "flow for stable thermal stratification")]
[JsonProperty(PropertyName="wall_panel_heating_stable_tilted_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingStableTiltedEquationSource WallPanelHeatingStableTiltedEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingStableTiltedEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingStableTiltedEquationSource), "WaltonStableHorizontalOrTilt");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="wall_panel_heating_stable_tilted_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WallPanelHeatingStableTiltedEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with in-wall panel heating This is for tilted surfaces with heat " +
    "flow for unstable thermal stratification")]
[JsonProperty(PropertyName="wall_panel_heating_unstable_tilted_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingUnstableTiltedEquationSource WallPanelHeatingUnstableTiltedEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingUnstableTiltedEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingUnstableTiltedEquationSource), "WaltonUnstableHorizontalOrTilt");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="wall_panel_heating_unstable_tilted_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WallPanelHeatingUnstableTiltedEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with in-wall panel heating This is for all window surfaces")]
[JsonProperty(PropertyName="wall_panel_heating_window_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingWindowEquationSource WallPanelHeatingWindowEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingWindowEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingWindowEquationSource), "ISO15099Windows");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="wall_panel_heating_window_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WallPanelHeatingWindowEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with convective heater This is for vertical walls not directly af" +
    "fected by heater")]
[JsonProperty(PropertyName="convective_zone_heater_vertical_wall_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterVerticalWallEquationSource ConvectiveZoneHeaterVerticalWallEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterVerticalWallEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterVerticalWallEquationSource), "FohannoPolidoriVerticalWall");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="convective_zone_heater_vertical_wall_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConvectiveZoneHeaterVerticalWallEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with convective heater This is for vertical walls that are direct" +
    "ly affected by heater Walls are considered \"near\" when listed in field set for F" +
    "raction of Radiant Energy to Surface")]
[JsonProperty(PropertyName="convective_zone_heater_vertical_walls_near_heater_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterVerticalWallsNearHeaterEquationSource ConvectiveZoneHeaterVerticalWallsNearHeaterEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterVerticalWallsNearHeaterEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterVerticalWallsNearHeaterEquationSource), "KhalifaEq5WallNearHeat");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="convective_zone_heater_vertical_walls_near_heater_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConvectiveZoneHeaterVerticalWallsNearHeaterEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with convective heater This is for horizontal surfaces with heat " +
    "flow directed for stable thermal stratification")]
[JsonProperty(PropertyName="convective_zone_heater_stable_horizontal_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterStableHorizontalEquationSource ConvectiveZoneHeaterStableHorizontalEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterStableHorizontalEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterStableHorizontalEquationSource), "AlamdariHammondStableHorizontal");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="convective_zone_heater_stable_horizontal_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConvectiveZoneHeaterStableHorizontalEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with convective heater This is for horizontal surfaces with heat " +
    "flow directed for unstable thermal stratification")]
[JsonProperty(PropertyName="convective_zone_heater_unstable_horizontal_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterUnstableHorizontalEquationSource ConvectiveZoneHeaterUnstableHorizontalEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterUnstableHorizontalEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterUnstableHorizontalEquationSource), "KhalifaEq7Ceiling");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="convective_zone_heater_unstable_horizontal_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConvectiveZoneHeaterUnstableHorizontalEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with convective heater This is for tilted surfaces with heat flow" +
    " for stable thermal stratification")]
[JsonProperty(PropertyName="convective_zone_heater_stable_tilted_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterStableTiltedEquationSource ConvectiveZoneHeaterStableTiltedEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterStableTiltedEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterStableTiltedEquationSource), "WaltonStableHorizontalOrTilt");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="convective_zone_heater_stable_tilted_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConvectiveZoneHeaterStableTiltedEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with convective heater This is for tilted surfaces with heat flow" +
    " for unstable thermal stratification")]
[JsonProperty(PropertyName="convective_zone_heater_unstable_tilted_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterUnstableTiltedEquationSource ConvectiveZoneHeaterUnstableTiltedEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterUnstableTiltedEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterUnstableTiltedEquationSource), "WaltonUnstableHorizontalOrTilt");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="convective_zone_heater_unstable_tilted_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConvectiveZoneHeaterUnstableTiltedEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with convective heater This is for all window surfaces")]
[JsonProperty(PropertyName="convective_zone_heater_windows_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterWindowsEquationSource ConvectiveZoneHeaterWindowsEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterWindowsEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterWindowsEquationSource), "ISO15099Windows");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="convective_zone_heater_windows_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConvectiveZoneHeaterWindowsEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with mechanical forced central air with diffusers This is for all" +
    " wall surfaces")]
[JsonProperty(PropertyName="central_air_diffuser_wall_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_CentralAirDiffuserWallEquationSource CentralAirDiffuserWallEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_CentralAirDiffuserWallEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_CentralAirDiffuserWallEquationSource), "GoldsteinNovoselacCeilingDiffuserWalls");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="central_air_diffuser_wall_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CentralAirDiffuserWallEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with mechanical forced central air with diffusers This is for all" +
    " ceiling surfaces")]
[JsonProperty(PropertyName="central_air_diffuser_ceiling_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_CentralAirDiffuserCeilingEquationSource CentralAirDiffuserCeilingEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_CentralAirDiffuserCeilingEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_CentralAirDiffuserCeilingEquationSource), "FisherPedersenCeilingDiffuserCeiling");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="central_air_diffuser_ceiling_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CentralAirDiffuserCeilingEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with mechanical forced central air with diffusers This is for all" +
    " floor surfaces")]
[JsonProperty(PropertyName="central_air_diffuser_floor_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_CentralAirDiffuserFloorEquationSource CentralAirDiffuserFloorEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_CentralAirDiffuserFloorEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_CentralAirDiffuserFloorEquationSource), "GoldsteinNovoselacCeilingDiffuserFloor");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="central_air_diffuser_floor_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CentralAirDiffuserFloorEquationUserCurveName { get; set; } = "";
        

[Description("Applies to zone with mechanical forced central air with diffusers This is for all" +
    " window surfaces")]
[JsonProperty(PropertyName="central_air_diffuser_window_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_CentralAirDiffuserWindowEquationSource CentralAirDiffuserWindowEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_CentralAirDiffuserWindowEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_CentralAirDiffuserWindowEquationSource), "GoldsteinNovoselacCeilingDiffuserWindow");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="central_air_diffuser_window_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CentralAirDiffuserWindowEquationUserCurveName { get; set; } = "";
        

[Description("reference choice fields")]
[JsonProperty(PropertyName="mechanical_zone_fan_circulation_vertical_wall_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationVerticalWallEquationSource MechanicalZoneFanCirculationVerticalWallEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationVerticalWallEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationVerticalWallEquationSource), "KhalifaEq3WallAwayFromHeat");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="mechanical_zone_fan_circulation_vertical_wall_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MechanicalZoneFanCirculationVerticalWallEquationUserCurveName { get; set; } = "";
        

[Description("reference choice fields")]
[JsonProperty(PropertyName="mechanical_zone_fan_circulation_stable_horizontal_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationStableHorizontalEquationSource MechanicalZoneFanCirculationStableHorizontalEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationStableHorizontalEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationStableHorizontalEquationSource), "AlamdariHammondStableHorizontal");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="mechanical_zone_fan_circulation_stable_horizontal_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MechanicalZoneFanCirculationStableHorizontalEquationUserCurveName { get; set; } = "";
        

[Description("reference choice fields")]
[JsonProperty(PropertyName="mechanical_zone_fan_circulation_unstable_horizontal_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationUnstableHorizontalEquationSource MechanicalZoneFanCirculationUnstableHorizontalEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationUnstableHorizontalEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationUnstableHorizontalEquationSource), "KhalifaEq4CeilingAwayFromHeat");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="mechanical_zone_fan_circulation_unstable_horizontal_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MechanicalZoneFanCirculationUnstableHorizontalEquationUserCurveName { get; set; } = "";
        

[Description("reference choice fields")]
[JsonProperty(PropertyName="mechanical_zone_fan_circulation_stable_tilted_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationStableTiltedEquationSource MechanicalZoneFanCirculationStableTiltedEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationStableTiltedEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationStableTiltedEquationSource), "WaltonStableHorizontalOrTilt");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="mechanical_zone_fan_circulation_stable_tilted_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MechanicalZoneFanCirculationStableTiltedEquationUserCurveName { get; set; } = "";
        

[Description("reference choice fields")]
[JsonProperty(PropertyName="mechanical_zone_fan_circulation_unstable_tilted_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationUnstableTiltedEquationSource MechanicalZoneFanCirculationUnstableTiltedEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationUnstableTiltedEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationUnstableTiltedEquationSource), "WaltonUnstableHorizontalOrTilt");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="mechanical_zone_fan_circulation_unstable_tilted_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MechanicalZoneFanCirculationUnstableTiltedEquationUserCurveName { get; set; } = "";
        

[Description("reference choice fields")]
[JsonProperty(PropertyName="mechanical_zone_fan_circulation_window_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationWindowEquationSource MechanicalZoneFanCirculationWindowEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationWindowEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationWindowEquationSource), "ISO15099Windows");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="mechanical_zone_fan_circulation_window_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MechanicalZoneFanCirculationWindowEquationUserCurveName { get; set; } = "";
        

[Description("reference choice fields")]
[JsonProperty(PropertyName="mixed_regime_buoyancy_assisting_flow_on_walls_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeBuoyancyAssistingFlowOnWallsEquationSource MixedRegimeBuoyancyAssistingFlowOnWallsEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeBuoyancyAssistingFlowOnWallsEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeBuoyancyAssistingFlowOnWallsEquationSource), "BeausoleilMorrisonMixedAssistedWall");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="mixed_regime_buoyancy_assisting_flow_on_walls_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MixedRegimeBuoyancyAssistingFlowOnWallsEquationUserCurveName { get; set; } = "";
        

[Description("reference choice fields")]
[JsonProperty(PropertyName="mixed_regime_buoyancy_opposing_flow_on_walls_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeBuoyancyOpposingFlowOnWallsEquationSource MixedRegimeBuoyancyOpposingFlowOnWallsEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeBuoyancyOpposingFlowOnWallsEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeBuoyancyOpposingFlowOnWallsEquationSource), "BeausoleilMorrisonMixedOpposingWall");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="mixed_regime_buoyancy_opposing_flow_on_walls_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MixedRegimeBuoyancyOpposingFlowOnWallsEquationUserCurveName { get; set; } = "";
        

[Description("reference choice fields")]
[JsonProperty(PropertyName="mixed_regime_stable_floor_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeStableFloorEquationSource MixedRegimeStableFloorEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeStableFloorEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeStableFloorEquationSource), "BeausoleilMorrisonMixedStableFloor");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="mixed_regime_stable_floor_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MixedRegimeStableFloorEquationUserCurveName { get; set; } = "";
        

[Description("reference choice fields")]
[JsonProperty(PropertyName="mixed_regime_unstable_floor_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeUnstableFloorEquationSource MixedRegimeUnstableFloorEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeUnstableFloorEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeUnstableFloorEquationSource), "BeausoleilMorrisonMixedUnstableFloor");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="mixed_regime_unstable_floor_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MixedRegimeUnstableFloorEquationUserCurveName { get; set; } = "";
        

[Description("reference choice fields")]
[JsonProperty(PropertyName="mixed_regime_stable_ceiling_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeStableCeilingEquationSource MixedRegimeStableCeilingEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeStableCeilingEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeStableCeilingEquationSource), "BeausoleilMorrisonMixedStableCeiling");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="mixed_regime_stable_ceiling_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MixedRegimeStableCeilingEquationUserCurveName { get; set; } = "";
        

[Description("reference choice fields")]
[JsonProperty(PropertyName="mixed_regime_unstable_ceiling_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeUnstableCeilingEquationSource MixedRegimeUnstableCeilingEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeUnstableCeilingEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeUnstableCeilingEquationSource), "BeausoleilMorrisonMixedUnstableCeiling");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="mixed_regime_unstable_ceiling_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MixedRegimeUnstableCeilingEquationUserCurveName { get; set; } = "";
        

[Description("reference choice fields")]
[JsonProperty(PropertyName="mixed_regime_window_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeWindowEquationSource MixedRegimeWindowEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeWindowEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeWindowEquationSource), "GoldsteinNovoselacCeilingDiffuserWindow");
        

[Description("The SurfaceConvectionAlgorithm:Inside:UserCurve named in this field is used when " +
    "the previous field is set to UserCurve")]
[JsonProperty(PropertyName="mixed_regime_window_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MixedRegimeWindowEquationUserCurveName { get; set; } = "";
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyVerticalWallEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAEVerticalWall")]
        ASHRAEVerticalWall = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondVerticalWall")]
        AlamdariHammondVerticalWall = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FohannoPolidoriVerticalWall")]
        FohannoPolidoriVerticalWall = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq3WallAwayFromHeat")]
        KhalifaEq3WallAwayFromHeat = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq6NonHeatedWalls")]
        KhalifaEq6NonHeatedWalls = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 7,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyStableHorizontalEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondStableHorizontal")]
        AlamdariHammondStableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonStableHorizontalOrTilt")]
        WaltonStableHorizontalOrTilt = 3,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyUnstableHorizontalEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondUnstableHorizontal")]
        AlamdariHammondUnstableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonUnstableHorizontalOrTilt")]
        WaltonUnstableHorizontalOrTilt = 3,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyStableTiltedEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondStableHorizontal")]
        AlamdariHammondStableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonStableHorizontalOrTilt")]
        WaltonStableHorizontalOrTilt = 3,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyUnstableTiltedEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondUnstableHorizontal")]
        AlamdariHammondUnstableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonUnstableHorizontalOrTilt")]
        WaltonUnstableHorizontalOrTilt = 3,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_SimpleBuoyancyWindowsEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAEVerticalWall")]
        ASHRAEVerticalWall = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondVerticalWall")]
        AlamdariHammondVerticalWall = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FohannoPolidoriVerticalWall")]
        FohannoPolidoriVerticalWall = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="KaradagChilledCeiling")]
        KaradagChilledCeiling = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 6,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolVerticalWallEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAEVerticalWall")]
        ASHRAEVerticalWall = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondVerticalWall")]
        AlamdariHammondVerticalWall = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FohannoPolidoriVerticalWall")]
        FohannoPolidoriVerticalWall = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq3WallAwayFromHeat")]
        KhalifaEq3WallAwayFromHeat = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 6,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolStableHorizontalEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondStableHorizontal")]
        AlamdariHammondStableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonStableHorizontalOrTilt")]
        WaltonStableHorizontalOrTilt = 3,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolUnstableHorizontalEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondUnstableHorizontal")]
        AlamdariHammondUnstableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq4CeilingAwayFromHeat")]
        KhalifaEq4CeilingAwayFromHeat = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonUnstableHorizontalOrTilt")]
        WaltonUnstableHorizontalOrTilt = 4,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolHeatedFloorEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondUnstableHorizontal")]
        AlamdariHammondUnstableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AwbiHattonHeatedFloor")]
        AwbiHattonHeatedFloor = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonUnstableHorizontalOrTilt")]
        WaltonUnstableHorizontalOrTilt = 4,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolChilledCeilingEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondUnstableHorizontal")]
        AlamdariHammondUnstableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="KaradagChilledCeiling")]
        KaradagChilledCeiling = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonUnstableHorizontalOrTilt")]
        WaltonUnstableHorizontalOrTilt = 4,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolStableTiltedEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondStableHorizontal")]
        AlamdariHammondStableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonStableHorizontalOrTilt")]
        WaltonStableHorizontalOrTilt = 4,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolUnstableTiltedEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondUnstableHorizontal")]
        AlamdariHammondUnstableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonUnstableHorizontalOrTilt")]
        WaltonUnstableHorizontalOrTilt = 4,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_FloorHeatCeilingCoolWindowEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAEVerticalWall")]
        ASHRAEVerticalWall = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondVerticalWall")]
        AlamdariHammondVerticalWall = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 4,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingVerticalWallEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAEVerticalWall")]
        ASHRAEVerticalWall = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondVerticalWall")]
        AlamdariHammondVerticalWall = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FohannoPolidoriVerticalWall")]
        FohannoPolidoriVerticalWall = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq6NonHeatedWalls")]
        KhalifaEq6NonHeatedWalls = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 6,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingHeatedWallEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAEVerticalWall")]
        ASHRAEVerticalWall = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondVerticalWall")]
        AlamdariHammondVerticalWall = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="AwbiHattonHeatedWall")]
        AwbiHattonHeatedWall = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="FohannoPolidoriVerticalWall")]
        FohannoPolidoriVerticalWall = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq5WallNearHeat")]
        KhalifaEq5WallNearHeat = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 7,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingStableHorizontalEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondStableHorizontal")]
        AlamdariHammondStableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonStableHorizontalOrTilt")]
        WaltonStableHorizontalOrTilt = 3,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingUnstableHorizontalEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAEVerticalWall")]
        ASHRAEVerticalWall = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondUnstableHorizontal")]
        AlamdariHammondUnstableHorizontal = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="KaradagChilledCeiling")]
        KaradagChilledCeiling = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq7Ceiling")]
        KhalifaEq7Ceiling = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonUnstableHorizontalOrTilt")]
        WaltonUnstableHorizontalOrTilt = 6,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingStableTiltedEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondStableHorizontal")]
        AlamdariHammondStableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonStableHorizontalOrTilt")]
        WaltonStableHorizontalOrTilt = 4,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingUnstableTiltedEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondUnstableHorizontal")]
        AlamdariHammondUnstableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonUnstableHorizontalOrTilt")]
        WaltonUnstableHorizontalOrTilt = 4,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_WallPanelHeatingWindowEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAEVerticalWall")]
        ASHRAEVerticalWall = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondVerticalWall")]
        AlamdariHammondVerticalWall = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FohannoPolidoriVerticalWall")]
        FohannoPolidoriVerticalWall = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 5,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterVerticalWallEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAEVerticalWall")]
        ASHRAEVerticalWall = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondVerticalWall")]
        AlamdariHammondVerticalWall = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FohannoPolidoriVerticalWall")]
        FohannoPolidoriVerticalWall = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq3WallAwayFromHeat")]
        KhalifaEq3WallAwayFromHeat = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq6NonHeatedWalls")]
        KhalifaEq6NonHeatedWalls = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 7,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterVerticalWallsNearHeaterEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAEVerticalWall")]
        ASHRAEVerticalWall = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondVerticalWall")]
        AlamdariHammondVerticalWall = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="AwbiHattonHeatedWall")]
        AwbiHattonHeatedWall = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="FohannoPolidoriVerticalWall")]
        FohannoPolidoriVerticalWall = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq5WallNearHeat")]
        KhalifaEq5WallNearHeat = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 7,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterStableHorizontalEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondStableHorizontal")]
        AlamdariHammondStableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonStableHorizontalOrTilt")]
        WaltonStableHorizontalOrTilt = 3,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterUnstableHorizontalEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondUnstableHorizontal")]
        AlamdariHammondUnstableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq4CeilingAwayFromHeat")]
        KhalifaEq4CeilingAwayFromHeat = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq7Ceiling")]
        KhalifaEq7Ceiling = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonUnstableHorizontalOrTilt")]
        WaltonUnstableHorizontalOrTilt = 5,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterStableTiltedEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondStableHorizontal")]
        AlamdariHammondStableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonStableHorizontalOrTilt")]
        WaltonStableHorizontalOrTilt = 3,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterUnstableTiltedEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondUnstableHorizontal")]
        AlamdariHammondUnstableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonUnstableHorizontalOrTilt")]
        WaltonUnstableHorizontalOrTilt = 3,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_ConvectiveZoneHeaterWindowsEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAEVerticalWall")]
        ASHRAEVerticalWall = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondVerticalWall")]
        AlamdariHammondVerticalWall = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FohannoPolidoriVerticalWall")]
        FohannoPolidoriVerticalWall = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq3WallAwayFromHeat")]
        KhalifaEq3WallAwayFromHeat = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 6,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_CentralAirDiffuserWallEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAEVerticalWall")]
        ASHRAEVerticalWall = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondVerticalWall")]
        AlamdariHammondVerticalWall = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedAssistedWall")]
        BeausoleilMorrisonMixedAssistedWall = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedOpposingWall")]
        BeausoleilMorrisonMixedOpposingWall = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="FisherPedersenCeilingDiffuserWalls")]
        FisherPedersenCeilingDiffuserWalls = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="FohannoPolidoriVerticalWall")]
        FohannoPolidoriVerticalWall = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="GoldsteinNovoselacCeilingDiffuserWalls")]
        GoldsteinNovoselacCeilingDiffuserWalls = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 9,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_CentralAirDiffuserCeilingEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedStableCeiling")]
        BeausoleilMorrisonMixedStableCeiling = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedUnstableCeiling")]
        BeausoleilMorrisonMixedUnstableCeiling = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FisherPedersenCeilingDiffuserCeiling")]
        FisherPedersenCeilingDiffuserCeiling = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 4,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_CentralAirDiffuserFloorEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedStableFloor")]
        BeausoleilMorrisonMixedStableFloor = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedUnstableFloor")]
        BeausoleilMorrisonMixedUnstableFloor = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FisherPedersenCeilingDiffuserFloor")]
        FisherPedersenCeilingDiffuserFloor = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="GoldsteinNovoselacCeilingDiffuserFloor")]
        GoldsteinNovoselacCeilingDiffuserFloor = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 5,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_CentralAirDiffuserWindowEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAEVerticalWall")]
        ASHRAEVerticalWall = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondVerticalWall")]
        AlamdariHammondVerticalWall = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedAssistedWall")]
        BeausoleilMorrisonMixedAssistedWall = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedOpposingWall")]
        BeausoleilMorrisonMixedOpposingWall = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="FisherPedersenCeilingDiffuserWalls")]
        FisherPedersenCeilingDiffuserWalls = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="FohannoPolidoriVerticalWall")]
        FohannoPolidoriVerticalWall = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="GoldsteinNovoselacCeilingDiffuserWindow")]
        GoldsteinNovoselacCeilingDiffuserWindow = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 9,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationVerticalWallEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAEVerticalWall")]
        ASHRAEVerticalWall = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondVerticalWall")]
        AlamdariHammondVerticalWall = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedAssistedWall")]
        BeausoleilMorrisonMixedAssistedWall = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedOpposingWall")]
        BeausoleilMorrisonMixedOpposingWall = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="FisherPedersenCeilingDiffuserWalls")]
        FisherPedersenCeilingDiffuserWalls = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="FohannoPolidoriVerticalWall")]
        FohannoPolidoriVerticalWall = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="GoldsteinNovoselacCeilingDiffuserWalls")]
        GoldsteinNovoselacCeilingDiffuserWalls = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq3WallAwayFromHeat")]
        KhalifaEq3WallAwayFromHeat = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 10,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationStableHorizontalEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondStableHorizontal")]
        AlamdariHammondStableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonStableHorizontalOrTilt")]
        WaltonStableHorizontalOrTilt = 3,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationUnstableHorizontalEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondUnstableHorizontal")]
        AlamdariHammondUnstableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq4CeilingAwayFromHeat")]
        KhalifaEq4CeilingAwayFromHeat = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonUnstableHorizontalOrTilt")]
        WaltonUnstableHorizontalOrTilt = 4,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationStableTiltedEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonStableHorizontalOrTilt")]
        WaltonStableHorizontalOrTilt = 2,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationUnstableTiltedEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondUnstableHorizontal")]
        AlamdariHammondUnstableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonUnstableHorizontalOrTilt")]
        WaltonUnstableHorizontalOrTilt = 3,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MechanicalZoneFanCirculationWindowEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAEVerticalWall")]
        ASHRAEVerticalWall = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondVerticalWall")]
        AlamdariHammondVerticalWall = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FohannoPolidoriVerticalWall")]
        FohannoPolidoriVerticalWall = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="GoldsteinNovoselacCeilingDiffuserWindow")]
        GoldsteinNovoselacCeilingDiffuserWindow = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 6,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeBuoyancyAssistingFlowOnWallsEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAEVerticalWall")]
        ASHRAEVerticalWall = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondVerticalWall")]
        AlamdariHammondVerticalWall = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedAssistedWall")]
        BeausoleilMorrisonMixedAssistedWall = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="FisherPedersenCeilingDiffuserWalls")]
        FisherPedersenCeilingDiffuserWalls = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="FohannoPolidoriVerticalWall")]
        FohannoPolidoriVerticalWall = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="GoldsteinNovoselacCeilingDiffuserWalls")]
        GoldsteinNovoselacCeilingDiffuserWalls = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 7,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeBuoyancyOpposingFlowOnWallsEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAEVerticalWall")]
        ASHRAEVerticalWall = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondVerticalWall")]
        AlamdariHammondVerticalWall = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedOpposingWall")]
        BeausoleilMorrisonMixedOpposingWall = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="FisherPedersenCeilingDiffuserWalls")]
        FisherPedersenCeilingDiffuserWalls = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="FohannoPolidoriVerticalWall")]
        FohannoPolidoriVerticalWall = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="GoldsteinNovoselacCeilingDiffuserWalls")]
        GoldsteinNovoselacCeilingDiffuserWalls = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 7,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeStableFloorEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondStableHorizontal")]
        AlamdariHammondStableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedStableFloor")]
        BeausoleilMorrisonMixedStableFloor = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonStableHorizontalOrTilt")]
        WaltonStableHorizontalOrTilt = 4,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeUnstableFloorEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondUnstableHorizontal")]
        AlamdariHammondUnstableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedUnstableFloor")]
        BeausoleilMorrisonMixedUnstableFloor = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonUnstableHorizontalOrTilt")]
        WaltonUnstableHorizontalOrTilt = 4,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeStableCeilingEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondStableHorizontal")]
        AlamdariHammondStableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedStableCeiling")]
        BeausoleilMorrisonMixedStableCeiling = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonStableHorizontalOrTilt")]
        WaltonStableHorizontalOrTilt = 4,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeUnstableCeilingEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondUnstableHorizontal")]
        AlamdariHammondUnstableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedUnstableCeiling")]
        BeausoleilMorrisonMixedUnstableCeiling = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonUnstableHorizontalOrTilt")]
        WaltonUnstableHorizontalOrTilt = 4,
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections_MixedRegimeWindowEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="GoldsteinNovoselacCeilingDiffuserWindow")]
        GoldsteinNovoselacCeilingDiffuserWindow = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 3,
    }
    
    [Description(@"Options to change the individual convection model equations for dynamic selection when using AdaptiveConvectiongAlgorithm This object is only needed to make changes to the default model selections for any or all of the surface categories. This object is for the outside face, the side of the surface facing away from the thermal zone.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="wind_convection_windward_vertical_wall_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_WindConvectionWindwardVerticalWallEquationSource WindConvectionWindwardVerticalWallEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_WindConvectionWindwardVerticalWallEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_WindConvectionWindwardVerticalWallEquationSource), "TARPWindward");
        

[Description("The SurfaceConvectionAlgorithm:Outside:UserCurve named in this field is used when" +
    " the previous field is set to UserCurve")]
[JsonProperty(PropertyName="wind_convection_windward_equation_vertical_wall_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WindConvectionWindwardEquationVerticalWallUserCurveName { get; set; } = "";
        

[JsonProperty(PropertyName="wind_convection_leeward_vertical_wall_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_WindConvectionLeewardVerticalWallEquationSource WindConvectionLeewardVerticalWallEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_WindConvectionLeewardVerticalWallEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_WindConvectionLeewardVerticalWallEquationSource), "TARPLeeward");
        

[Description("The SurfaceConvectionAlgorithm:Outside:UserCurve named in this field is used when" +
    " the previous field is set to UserCurve")]
[JsonProperty(PropertyName="wind_convection_leeward_vertical_wall_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WindConvectionLeewardVerticalWallEquationUserCurveName { get; set; } = "";
        

[JsonProperty(PropertyName="wind_convection_horizontal_roof_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_WindConvectionHorizontalRoofEquationSource WindConvectionHorizontalRoofEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_WindConvectionHorizontalRoofEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_WindConvectionHorizontalRoofEquationSource), "ClearRoof");
        

[Description("The SurfaceConvectionAlgorithm:Outside:UserCurve named in this field is used when" +
    " the previous field is set to UserCurve")]
[JsonProperty(PropertyName="wind_convection_horizontal_roof_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WindConvectionHorizontalRoofUserCurveName { get; set; } = "";
        

[Description("This is for vertical walls")]
[JsonProperty(PropertyName="natural_convection_vertical_wall_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_NaturalConvectionVerticalWallEquationSource NaturalConvectionVerticalWallEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_NaturalConvectionVerticalWallEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_NaturalConvectionVerticalWallEquationSource), "ASHRAEVerticalWall");
        

[Description("The SurfaceConvectionAlgorithm:Outside:UserCurve named in this field is used when" +
    " the previous field is set to UserCurve")]
[JsonProperty(PropertyName="natural_convection_vertical_wall_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NaturalConvectionVerticalWallEquationUserCurveName { get; set; } = "";
        

[Description("This is for horizontal surfaces with heat flow directed for stable thermal strati" +
    "fication")]
[JsonProperty(PropertyName="natural_convection_stable_horizontal_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_NaturalConvectionStableHorizontalEquationSource NaturalConvectionStableHorizontalEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_NaturalConvectionStableHorizontalEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_NaturalConvectionStableHorizontalEquationSource), "WaltonStableHorizontalOrTilt");
        

[Description("The SurfaceConvectionAlgorithm:Outside:UserCurve named in this field is used when" +
    " the previous field is set to UserCurve")]
[JsonProperty(PropertyName="natural_convection_stable_horizontal_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NaturalConvectionStableHorizontalEquationUserCurveName { get; set; } = "";
        

[JsonProperty(PropertyName="natural_convection_unstable_horizontal_equation_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_NaturalConvectionUnstableHorizontalEquationSource NaturalConvectionUnstableHorizontalEquationSource { get; set; } = (SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_NaturalConvectionUnstableHorizontalEquationSource)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_NaturalConvectionUnstableHorizontalEquationSource), "WaltonUnstableHorizontalOrTilt");
        

[Description("The SurfaceConvectionAlgorithm:Outside:UserCurve named in this field is used when" +
    " the previous field is set to UserCurve")]
[JsonProperty(PropertyName="natural_convection_unstable_horizontal_equation_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NaturalConvectionUnstableHorizontalEquationUserCurveName { get; set; } = "";
    }
    
    public enum SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_WindConvectionWindwardVerticalWallEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlockenWindward")]
        BlockenWindward = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DOE2Windward")]
        DOE2Windward = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="EmmelVertical")]
        EmmelVertical = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="McAdams")]
        McAdams = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Mitchell")]
        Mitchell = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="MoWiTTWindward")]
        MoWiTTWindward = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="NusseltJurges")]
        NusseltJurges = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="SimpleCombined")]
        SimpleCombined = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="TARPWindward")]
        TARPWindward = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 10,
    }
    
    public enum SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_WindConvectionLeewardVerticalWallEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DOE2Leeward")]
        DOE2Leeward = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="EmmelVertical")]
        EmmelVertical = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="McAdams")]
        McAdams = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Mitchell")]
        Mitchell = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="MoWiTTLeeward")]
        MoWiTTLeeward = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="NusseltJurges")]
        NusseltJurges = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="SimpleCombined")]
        SimpleCombined = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="TARPLeeward")]
        TARPLeeward = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 9,
    }
    
    public enum SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_WindConvectionHorizontalRoofEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlockenWindward")]
        BlockenWindward = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ClearRoof")]
        ClearRoof = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DOE2Windward")]
        DOE2Windward = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="EmmelRoof")]
        EmmelRoof = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="McAdams")]
        McAdams = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Mitchell")]
        Mitchell = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="MoWiTTWindward")]
        MoWiTTWindward = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="NusseltJurges")]
        NusseltJurges = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="SimpleCombined")]
        SimpleCombined = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="TARPWindward")]
        TARPWindward = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 11,
    }
    
    public enum SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_NaturalConvectionVerticalWallEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAEVerticalWall")]
        ASHRAEVerticalWall = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondVerticalWall")]
        AlamdariHammondVerticalWall = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FohannoPolidoriVerticalWall")]
        FohannoPolidoriVerticalWall = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 6,
    }
    
    public enum SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_NaturalConvectionStableHorizontalEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondStableHorizontal")]
        AlamdariHammondStableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonStableHorizontalOrTilt")]
        WaltonStableHorizontalOrTilt = 4,
    }
    
    public enum SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections_NaturalConvectionUnstableHorizontalEquationSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondUnstableHorizontal")]
        AlamdariHammondUnstableHorizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonUnstableHorizontalOrTilt")]
        WaltonUnstableHorizontalOrTilt = 4,
    }
    
    [Description("Used to describe a custom model equation for surface convection heat transfer coe" +
        "fficient If more than one curve is referenced they are all used and added togeth" +
        "er.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceConvectionAlgorithm_Inside_UserCurve
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Controls which temperature is differenced from surface temperature when using the" +
    " Hc value")]
[JsonProperty(PropertyName="reference_temperature_for_convection_heat_transfer", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_UserCurve_ReferenceTemperatureForConvectionHeatTransfer ReferenceTemperatureForConvectionHeatTransfer { get; set; } = (SurfaceConvectionAlgorithm_Inside_UserCurve_ReferenceTemperatureForConvectionHeatTransfer)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_UserCurve_ReferenceTemperatureForConvectionHeatTransfer), "AdjacentAirTemperature");
        

[Description("Curve\'s \"x\" is absolute value of delta-T (Surface temperature minus reference tem" +
    "perature, (C))")]
[JsonProperty(PropertyName="hc_function_of_temperature_difference_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HcFunctionOfTemperatureDifferenceCurveName { get; set; } = "";
        

[Description("Curve\'s \"x\" is absolute value of delta-T/Height (Surface temp minus Air temp)/(ve" +
    "rtical length scale), (C/m) when used for an inside face the vertical length sca" +
    "le is the zone\'s interior height")]
[JsonProperty(PropertyName="hc_function_of_temperature_difference_divided_by_height_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HcFunctionOfTemperatureDifferenceDividedByHeightCurveName { get; set; } = "";
        

[Description("Curve\'s \"x\" is mechanical ACH (Air Changes per hour from mechanical air system), " +
    "(1/hr)")]
[JsonProperty(PropertyName="hc_function_of_air_change_rate_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HcFunctionOfAirChangeRateCurveName { get; set; } = "";
        

[Description("Curve\'s \"x\" is mechanical system air flow rate (m3/s) divided by zone\'s length al" +
    "ong exterior walls (m).")]
[JsonProperty(PropertyName="hc_function_of_air_system_volume_flow_rate_divided_by_zone_perimeter_length_curve" +
    "_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HcFunctionOfAirSystemVolumeFlowRateDividedByZonePerimeterLengthCurveName { get; set; } = "";
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_UserCurve_ReferenceTemperatureForConvectionHeatTransfer
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AdjacentAirTemperature")]
        AdjacentAirTemperature = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MeanAirTemperature")]
        MeanAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SupplyAirTemperature")]
        SupplyAirTemperature = 2,
    }
    
    [Description("Used to describe a custom model equation for surface convection heat transfer coe" +
        "fficient If more than one curve is referenced they are all used and added togeth" +
        "er.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceConvectionAlgorithm_Outside_UserCurve
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="wind_speed_type_for_curve", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Outside_UserCurve_WindSpeedTypeForCurve WindSpeedTypeForCurve { get; set; } = (SurfaceConvectionAlgorithm_Outside_UserCurve_WindSpeedTypeForCurve)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Outside_UserCurve_WindSpeedTypeForCurve), "HeightAdjust");
        

[Description("Curve\'s \"x\" is wind speed of the type determined in the previous field (m/s)")]
[JsonProperty(PropertyName="hf_function_of_wind_speed_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HfFunctionOfWindSpeedCurveName { get; set; } = "";
        

[Description("Curve\'s \"x\" is absolute value of delta-T (Surface temperature minus air temperatu" +
    "re, (C))")]
[JsonProperty(PropertyName="hn_function_of_temperature_difference_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HnFunctionOfTemperatureDifferenceCurveName { get; set; } = "";
        

[Description("Curve\'s \"x\" is absolute value of delta-T/Height (Surface temp minus Air temp)/(ve" +
    "rtical length scale), (C/m) when used for an outside face the vertical length sc" +
    "ale is the exterior facade\'s overall height")]
[JsonProperty(PropertyName="hn_function_of_temperature_difference_divided_by_height_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HnFunctionOfTemperatureDifferenceDividedByHeightCurveName { get; set; } = "";
    }
    
    public enum SurfaceConvectionAlgorithm_Outside_UserCurve_WindSpeedTypeForCurve
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="HeightAdjust")]
        HeightAdjust = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ParallelComponent")]
        ParallelComponent = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ParallelComponentHeightAdjust")]
        ParallelComponentHeightAdjust = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="WeatherFile")]
        WeatherFile = 4,
    }
    
    [Description(@"Allow user settable interior and/or exterior convection coefficients. Note that some other factors may limit the lower bounds for these values, such as for windows, the interior convection coefficient must be >.28, for trombe wall algorithm selection (zone), the interior convection coefficient must be >.1 for TARP interior convection, the lower limit is also .1 Minimum and maximum limits are set in HeatBalanceAlgorithm object. Defaults in HeatBalanceAlgorithm object are [.1,1000].")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceProperty_ConvectionCoefficients
    {
        

[JsonProperty(PropertyName="surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceName { get; set; } = "";
        

[JsonProperty(PropertyName="convection_coefficient_1_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceProperty_ConvectionCoefficients_ConvectionCoefficient1Location ConvectionCoefficient1Location { get; set; } = (SurfaceProperty_ConvectionCoefficients_ConvectionCoefficient1Location)Enum.Parse(typeof(SurfaceProperty_ConvectionCoefficients_ConvectionCoefficient1Location), "Inside");
        

[JsonProperty(PropertyName="convection_coefficient_1_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceProperty_ConvectionCoefficients_ConvectionCoefficient1Type ConvectionCoefficient1Type { get; set; } = (SurfaceProperty_ConvectionCoefficients_ConvectionCoefficient1Type)Enum.Parse(typeof(SurfaceProperty_ConvectionCoefficients_ConvectionCoefficient1Type), "ASHRAEVerticalWall");
        

[Description("used if Convection Type=Value, min and max limits are set in HeatBalanceAlgorithm" +
    " object. Default limits are Minimum >= 0.1 and Maximum <= 1000")]
[JsonProperty(PropertyName="convection_coefficient_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConvectionCoefficient1 { get; set; } = null;
        

[Description("used if Convection Type=Schedule,  min and max limits are set in HeatBalanceAlgor" +
    "ithm object. Default limits are Minimum >= 0.1 and Maximum <= 1000")]
[JsonProperty(PropertyName="convection_coefficient_1_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConvectionCoefficient1ScheduleName { get; set; } = "";
        

[Description("used if Convection Type = UserCurve")]
[JsonProperty(PropertyName="convection_coefficient_1_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConvectionCoefficient1UserCurveName { get; set; } = "";
        

[JsonProperty(PropertyName="convection_coefficient_2_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceProperty_ConvectionCoefficients_ConvectionCoefficient2Location ConvectionCoefficient2Location { get; set; } = (SurfaceProperty_ConvectionCoefficients_ConvectionCoefficient2Location)Enum.Parse(typeof(SurfaceProperty_ConvectionCoefficients_ConvectionCoefficient2Location), "Inside");
        

[JsonProperty(PropertyName="convection_coefficient_2_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceProperty_ConvectionCoefficients_ConvectionCoefficient2Type ConvectionCoefficient2Type { get; set; } = (SurfaceProperty_ConvectionCoefficients_ConvectionCoefficient2Type)Enum.Parse(typeof(SurfaceProperty_ConvectionCoefficients_ConvectionCoefficient2Type), "ASHRAEVerticalWall");
        

[Description("used if Convection Type=Value, min and max limits are set in HeatBalanceAlgorithm" +
    " object. Default limits are Minimum >= 0.1 and Maximum <= 1000")]
[JsonProperty(PropertyName="convection_coefficient_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConvectionCoefficient2 { get; set; } = Double.Parse("0.1", CultureInfo.InvariantCulture);
        

[Description("used if Convection Type=Schedule,  min and max limits are set in HeatBalanceAlgor" +
    "ithm object. Default limits are Minimum >= 0.1 and Maximum <= 1000")]
[JsonProperty(PropertyName="convection_coefficient_2_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConvectionCoefficient2ScheduleName { get; set; } = "";
        

[Description("used if Convection Type = UserCurve")]
[JsonProperty(PropertyName="convection_coefficient_2_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConvectionCoefficient2UserCurveName { get; set; } = "";
    }
    
    public enum SurfaceProperty_ConvectionCoefficients_ConvectionCoefficient1Location
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Inside")]
        Inside = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Outside")]
        Outside = 1,
    }
    
    public enum SurfaceProperty_ConvectionCoefficients_ConvectionCoefficient1Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAEVerticalWall")]
        ASHRAEVerticalWall = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASTMC1340")]
        ASTMC1340 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveConvectionAlgorithm")]
        AdaptiveConvectionAlgorithm = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondStableHorizontal")]
        AlamdariHammondStableHorizontal = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondUnstableHorizontal")]
        AlamdariHammondUnstableHorizontal = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondVerticalWall")]
        AlamdariHammondVerticalWall = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="AwbiHattonHeatedFloor")]
        AwbiHattonHeatedFloor = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="AwbiHattonHeatedWall")]
        AwbiHattonHeatedWall = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedAssistedWall")]
        BeausoleilMorrisonMixedAssistedWall = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedOpposingWall")]
        BeausoleilMorrisonMixedOpposingWall = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedStableCeiling")]
        BeausoleilMorrisonMixedStableCeiling = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedStableFloor")]
        BeausoleilMorrisonMixedStableFloor = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedUnstableCeiling")]
        BeausoleilMorrisonMixedUnstableCeiling = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedUnstableFloor")]
        BeausoleilMorrisonMixedUnstableFloor = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="ClearRoof")]
        ClearRoof = 14,
        
        [System.Runtime.Serialization.EnumMember(Value="DOE-2")]
        DOE2 = 15,
        
        [System.Runtime.Serialization.EnumMember(Value="EmmelRoof")]
        EmmelRoof = 16,
        
        [System.Runtime.Serialization.EnumMember(Value="EmmelVertical")]
        EmmelVertical = 17,
        
        [System.Runtime.Serialization.EnumMember(Value="FisherPedersenCeilingDiffuserCeiling")]
        FisherPedersenCeilingDiffuserCeiling = 18,
        
        [System.Runtime.Serialization.EnumMember(Value="FisherPedersenCeilingDiffuserFloor")]
        FisherPedersenCeilingDiffuserFloor = 19,
        
        [System.Runtime.Serialization.EnumMember(Value="FisherPedersenCeilingDiffuserWalls")]
        FisherPedersenCeilingDiffuserWalls = 20,
        
        [System.Runtime.Serialization.EnumMember(Value="FohannoPolidoriVerticalWall")]
        FohannoPolidoriVerticalWall = 21,
        
        [System.Runtime.Serialization.EnumMember(Value="GoldsteinNovoselacCeilingDiffuserFloor")]
        GoldsteinNovoselacCeilingDiffuserFloor = 22,
        
        [System.Runtime.Serialization.EnumMember(Value="GoldsteinNovoselacCeilingDiffuserWalls")]
        GoldsteinNovoselacCeilingDiffuserWalls = 23,
        
        [System.Runtime.Serialization.EnumMember(Value="GoldsteinNovoselacCeilingDiffuserWindow")]
        GoldsteinNovoselacCeilingDiffuserWindow = 24,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 25,
        
        [System.Runtime.Serialization.EnumMember(Value="KaradagChilledCeiling")]
        KaradagChilledCeiling = 26,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq3WallAwayFromHeat")]
        KhalifaEq3WallAwayFromHeat = 27,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq4CeilingAwayFromHeat")]
        KhalifaEq4CeilingAwayFromHeat = 28,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq5WallNearHeat")]
        KhalifaEq5WallNearHeat = 29,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq6NonHeatedWalls")]
        KhalifaEq6NonHeatedWalls = 30,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq7Ceiling")]
        KhalifaEq7Ceiling = 31,
        
        [System.Runtime.Serialization.EnumMember(Value="McAdams")]
        McAdams = 32,
        
        [System.Runtime.Serialization.EnumMember(Value="Mitchell")]
        Mitchell = 33,
        
        [System.Runtime.Serialization.EnumMember(Value="MoWitt")]
        MoWitt = 34,
        
        [System.Runtime.Serialization.EnumMember(Value="NusseltJurges")]
        NusseltJurges = 35,
        
        [System.Runtime.Serialization.EnumMember(Value="Schedule")]
        Schedule = 36,
        
        [System.Runtime.Serialization.EnumMember(Value="Simple")]
        Simple = 37,
        
        [System.Runtime.Serialization.EnumMember(Value="SimpleCombined")]
        SimpleCombined = 38,
        
        [System.Runtime.Serialization.EnumMember(Value="TARP")]
        TARP = 39,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 40,
        
        [System.Runtime.Serialization.EnumMember(Value="Value")]
        Value = 41,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonStableHorizontalOrTilt")]
        WaltonStableHorizontalOrTilt = 42,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonUnstableHorizontalOrTilt")]
        WaltonUnstableHorizontalOrTilt = 43,
    }
    
    public enum SurfaceProperty_ConvectionCoefficients_ConvectionCoefficient2Location
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Inside")]
        Inside = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Outside")]
        Outside = 1,
    }
    
    public enum SurfaceProperty_ConvectionCoefficients_ConvectionCoefficient2Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAEVerticalWall")]
        ASHRAEVerticalWall = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASTMC1340")]
        ASTMC1340 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveConvectionAlgorithm")]
        AdaptiveConvectionAlgorithm = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondStableHorizontal")]
        AlamdariHammondStableHorizontal = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondUnstableHorizontal")]
        AlamdariHammondUnstableHorizontal = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondVerticalWall")]
        AlamdariHammondVerticalWall = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="AwbiHattonHeatedFloor")]
        AwbiHattonHeatedFloor = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="AwbiHattonHeatedWall")]
        AwbiHattonHeatedWall = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedAssistedWall")]
        BeausoleilMorrisonMixedAssistedWall = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedOpposingWall")]
        BeausoleilMorrisonMixedOpposingWall = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedStableCeiling")]
        BeausoleilMorrisonMixedStableCeiling = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedStableFloor")]
        BeausoleilMorrisonMixedStableFloor = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedUnstableCeiling")]
        BeausoleilMorrisonMixedUnstableCeiling = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedUnstableFloor")]
        BeausoleilMorrisonMixedUnstableFloor = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="ClearRoof")]
        ClearRoof = 14,
        
        [System.Runtime.Serialization.EnumMember(Value="DOE-2")]
        DOE2 = 15,
        
        [System.Runtime.Serialization.EnumMember(Value="EmmelRoof")]
        EmmelRoof = 16,
        
        [System.Runtime.Serialization.EnumMember(Value="EmmelVertical")]
        EmmelVertical = 17,
        
        [System.Runtime.Serialization.EnumMember(Value="FisherPedersenCeilingDiffuserCeiling")]
        FisherPedersenCeilingDiffuserCeiling = 18,
        
        [System.Runtime.Serialization.EnumMember(Value="FisherPedersenCeilingDiffuserFloor")]
        FisherPedersenCeilingDiffuserFloor = 19,
        
        [System.Runtime.Serialization.EnumMember(Value="FisherPedersenCeilingDiffuserWalls")]
        FisherPedersenCeilingDiffuserWalls = 20,
        
        [System.Runtime.Serialization.EnumMember(Value="FohannoPolidoriVerticalWall")]
        FohannoPolidoriVerticalWall = 21,
        
        [System.Runtime.Serialization.EnumMember(Value="GoldsteinNovoselacCeilingDiffuserFloor")]
        GoldsteinNovoselacCeilingDiffuserFloor = 22,
        
        [System.Runtime.Serialization.EnumMember(Value="GoldsteinNovoselacCeilingDiffuserWalls")]
        GoldsteinNovoselacCeilingDiffuserWalls = 23,
        
        [System.Runtime.Serialization.EnumMember(Value="GoldsteinNovoselacCeilingDiffuserWindow")]
        GoldsteinNovoselacCeilingDiffuserWindow = 24,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 25,
        
        [System.Runtime.Serialization.EnumMember(Value="KaradagChilledCeiling")]
        KaradagChilledCeiling = 26,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq3WallAwayFromHeat")]
        KhalifaEq3WallAwayFromHeat = 27,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq4CeilingAwayFromHeat")]
        KhalifaEq4CeilingAwayFromHeat = 28,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq5WallNearHeat")]
        KhalifaEq5WallNearHeat = 29,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq6NonHeatedWalls")]
        KhalifaEq6NonHeatedWalls = 30,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq7Ceiling")]
        KhalifaEq7Ceiling = 31,
        
        [System.Runtime.Serialization.EnumMember(Value="McAdams")]
        McAdams = 32,
        
        [System.Runtime.Serialization.EnumMember(Value="Mitchell")]
        Mitchell = 33,
        
        [System.Runtime.Serialization.EnumMember(Value="MoWitt")]
        MoWitt = 34,
        
        [System.Runtime.Serialization.EnumMember(Value="NusseltJurges")]
        NusseltJurges = 35,
        
        [System.Runtime.Serialization.EnumMember(Value="Schedule")]
        Schedule = 36,
        
        [System.Runtime.Serialization.EnumMember(Value="Simple")]
        Simple = 37,
        
        [System.Runtime.Serialization.EnumMember(Value="SimpleCombined")]
        SimpleCombined = 38,
        
        [System.Runtime.Serialization.EnumMember(Value="TARP")]
        TARP = 39,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 40,
        
        [System.Runtime.Serialization.EnumMember(Value="Value")]
        Value = 41,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonStableHorizontalOrTilt")]
        WaltonStableHorizontalOrTilt = 42,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonUnstableHorizontalOrTilt")]
        WaltonUnstableHorizontalOrTilt = 43,
    }
    
    [Description(@"Allow user settable interior and/or exterior convection coefficients. Note that some other factors may limit the lower bounds for these values, such as for windows, the interior convection coefficient must be >.28, for trombe wall algorithm selection (zone), the interior convection coefficient must be >.1 for TARP interior convection, the lower limit is also .1 Minimum and maximum limits are set in HeatBalanceAlgorithm object. Defaults in HeatBalanceAlgorithm object are [.1,1000].")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceProperty_ConvectionCoefficients_MultipleSurface
    {
        

[JsonProperty(PropertyName="surface_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceProperty_ConvectionCoefficients_MultipleSurface_SurfaceType SurfaceType { get; set; } = (SurfaceProperty_ConvectionCoefficients_MultipleSurface_SurfaceType)Enum.Parse(typeof(SurfaceProperty_ConvectionCoefficients_MultipleSurface_SurfaceType), "AllExteriorFloors");
        

[JsonProperty(PropertyName="convection_coefficient_1_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceProperty_ConvectionCoefficients_MultipleSurface_ConvectionCoefficient1Location ConvectionCoefficient1Location { get; set; } = (SurfaceProperty_ConvectionCoefficients_MultipleSurface_ConvectionCoefficient1Location)Enum.Parse(typeof(SurfaceProperty_ConvectionCoefficients_MultipleSurface_ConvectionCoefficient1Location), "Inside");
        

[JsonProperty(PropertyName="convection_coefficient_1_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceProperty_ConvectionCoefficients_MultipleSurface_ConvectionCoefficient1Type ConvectionCoefficient1Type { get; set; } = (SurfaceProperty_ConvectionCoefficients_MultipleSurface_ConvectionCoefficient1Type)Enum.Parse(typeof(SurfaceProperty_ConvectionCoefficients_MultipleSurface_ConvectionCoefficient1Type), "ASHRAEVerticalWall");
        

[Description("used if Convection Type=Value, min and max limits are set in HeatBalanceAlgorithm" +
    " object. Default limits are Minimum >= 0.1 and Maximum <= 1000")]
[JsonProperty(PropertyName="convection_coefficient_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConvectionCoefficient1 { get; set; } = null;
        

[Description("used if Convection Type=Schedule,  min and max limits are set in HeatBalanceAlgor" +
    "ithm object. Default limits are Minimum >= 0.1 and Maximum <= 1000")]
[JsonProperty(PropertyName="convection_coefficient_1_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConvectionCoefficient1ScheduleName { get; set; } = "";
        

[Description("used if Convection Type = UserCurve")]
[JsonProperty(PropertyName="convection_coefficient_1_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConvectionCoefficient1UserCurveName { get; set; } = "";
        

[JsonProperty(PropertyName="convection_coefficient_2_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceProperty_ConvectionCoefficients_MultipleSurface_ConvectionCoefficient2Location ConvectionCoefficient2Location { get; set; } = (SurfaceProperty_ConvectionCoefficients_MultipleSurface_ConvectionCoefficient2Location)Enum.Parse(typeof(SurfaceProperty_ConvectionCoefficients_MultipleSurface_ConvectionCoefficient2Location), "Inside");
        

[JsonProperty(PropertyName="convection_coefficient_2_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceProperty_ConvectionCoefficients_MultipleSurface_ConvectionCoefficient2Type ConvectionCoefficient2Type { get; set; } = (SurfaceProperty_ConvectionCoefficients_MultipleSurface_ConvectionCoefficient2Type)Enum.Parse(typeof(SurfaceProperty_ConvectionCoefficients_MultipleSurface_ConvectionCoefficient2Type), "ASHRAEVerticalWall");
        

[Description("used if Convection Type=Value, min and max limits are set in HeatBalanceAlgorithm" +
    " object. Default limits are Minimum >= 0.1 and Maximum <= 1000")]
[JsonProperty(PropertyName="convection_coefficient_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConvectionCoefficient2 { get; set; } = Double.Parse("0.1", CultureInfo.InvariantCulture);
        

[Description("used if Convection Type=Schedule,  min and max limits are set in HeatBalanceAlgor" +
    "ithm object. Default limits are Minimum >= 0.1 and Maximum <= 1000")]
[JsonProperty(PropertyName="convection_coefficient_2_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConvectionCoefficient2ScheduleName { get; set; } = "";
        

[Description("used if Convection Type = UserCurve")]
[JsonProperty(PropertyName="convection_coefficient_2_user_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConvectionCoefficient2UserCurveName { get; set; } = "";
    }
    
    public enum SurfaceProperty_ConvectionCoefficients_MultipleSurface_SurfaceType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AllExteriorFloors")]
        AllExteriorFloors = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AllExteriorRoofs")]
        AllExteriorRoofs = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AllExteriorSurfaces")]
        AllExteriorSurfaces = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="AllExteriorWalls")]
        AllExteriorWalls = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="AllExteriorWindows")]
        AllExteriorWindows = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="AllInteriorCeilings")]
        AllInteriorCeilings = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="AllInteriorFloors")]
        AllInteriorFloors = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="AllInteriorSurfaces")]
        AllInteriorSurfaces = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="AllInteriorWalls")]
        AllInteriorWalls = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="AllInteriorWindows")]
        AllInteriorWindows = 9,
    }
    
    public enum SurfaceProperty_ConvectionCoefficients_MultipleSurface_ConvectionCoefficient1Location
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Inside")]
        Inside = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Outside")]
        Outside = 1,
    }
    
    public enum SurfaceProperty_ConvectionCoefficients_MultipleSurface_ConvectionCoefficient1Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAEVerticalWall")]
        ASHRAEVerticalWall = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASTMC1340")]
        ASTMC1340 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveConvectionAlgorithm")]
        AdaptiveConvectionAlgorithm = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondStableHorizontal")]
        AlamdariHammondStableHorizontal = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondUnstableHorizontal")]
        AlamdariHammondUnstableHorizontal = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondVerticalWall")]
        AlamdariHammondVerticalWall = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="AwbiHattonHeatedFloor")]
        AwbiHattonHeatedFloor = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="AwbiHattonHeatedWall")]
        AwbiHattonHeatedWall = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedAssistedWall")]
        BeausoleilMorrisonMixedAssistedWall = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedOpposingWall")]
        BeausoleilMorrisonMixedOpposingWall = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedStableCeiling")]
        BeausoleilMorrisonMixedStableCeiling = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedStableFloor")]
        BeausoleilMorrisonMixedStableFloor = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedUnstableCeiling")]
        BeausoleilMorrisonMixedUnstableCeiling = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedUnstableFloor")]
        BeausoleilMorrisonMixedUnstableFloor = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="BlockenWindard")]
        BlockenWindard = 14,
        
        [System.Runtime.Serialization.EnumMember(Value="ClearRoof")]
        ClearRoof = 15,
        
        [System.Runtime.Serialization.EnumMember(Value="DOE-2")]
        DOE2 = 16,
        
        [System.Runtime.Serialization.EnumMember(Value="EmmelRoof")]
        EmmelRoof = 17,
        
        [System.Runtime.Serialization.EnumMember(Value="EmmelVertical")]
        EmmelVertical = 18,
        
        [System.Runtime.Serialization.EnumMember(Value="FisherPedersenCeilingDiffuserCeiling")]
        FisherPedersenCeilingDiffuserCeiling = 19,
        
        [System.Runtime.Serialization.EnumMember(Value="FisherPedersenCeilingDiffuserFloor")]
        FisherPedersenCeilingDiffuserFloor = 20,
        
        [System.Runtime.Serialization.EnumMember(Value="FisherPedersenCeilingDiffuserWalls")]
        FisherPedersenCeilingDiffuserWalls = 21,
        
        [System.Runtime.Serialization.EnumMember(Value="FohannoPolidoriVerticalWall")]
        FohannoPolidoriVerticalWall = 22,
        
        [System.Runtime.Serialization.EnumMember(Value="GoldsteinNovoselacCeilingDiffuserFloor")]
        GoldsteinNovoselacCeilingDiffuserFloor = 23,
        
        [System.Runtime.Serialization.EnumMember(Value="GoldsteinNovoselacCeilingDiffuserWalls")]
        GoldsteinNovoselacCeilingDiffuserWalls = 24,
        
        [System.Runtime.Serialization.EnumMember(Value="GoldsteinNovoselacCeilingDiffuserWindow")]
        GoldsteinNovoselacCeilingDiffuserWindow = 25,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 26,
        
        [System.Runtime.Serialization.EnumMember(Value="KaradagChilledCeiling")]
        KaradagChilledCeiling = 27,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq3WallAwayFromHeat")]
        KhalifaEq3WallAwayFromHeat = 28,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq4CeilingAwayFromHeat")]
        KhalifaEq4CeilingAwayFromHeat = 29,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq5WallNearHeat")]
        KhalifaEq5WallNearHeat = 30,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq6NonHeatedWalls")]
        KhalifaEq6NonHeatedWalls = 31,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq7Ceiling")]
        KhalifaEq7Ceiling = 32,
        
        [System.Runtime.Serialization.EnumMember(Value="McAdams")]
        McAdams = 33,
        
        [System.Runtime.Serialization.EnumMember(Value="Mitchell")]
        Mitchell = 34,
        
        [System.Runtime.Serialization.EnumMember(Value="MoWitt")]
        MoWitt = 35,
        
        [System.Runtime.Serialization.EnumMember(Value="NusseltJurges")]
        NusseltJurges = 36,
        
        [System.Runtime.Serialization.EnumMember(Value="Schedule")]
        Schedule = 37,
        
        [System.Runtime.Serialization.EnumMember(Value="Simple")]
        Simple = 38,
        
        [System.Runtime.Serialization.EnumMember(Value="SimpleCombined")]
        SimpleCombined = 39,
        
        [System.Runtime.Serialization.EnumMember(Value="TARP")]
        TARP = 40,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 41,
        
        [System.Runtime.Serialization.EnumMember(Value="Value")]
        Value = 42,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonStableHorizontalOrTilt")]
        WaltonStableHorizontalOrTilt = 43,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonUnstableHorizontalOrTilt")]
        WaltonUnstableHorizontalOrTilt = 44,
    }
    
    public enum SurfaceProperty_ConvectionCoefficients_MultipleSurface_ConvectionCoefficient2Location
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Inside")]
        Inside = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Outside")]
        Outside = 1,
    }
    
    public enum SurfaceProperty_ConvectionCoefficients_MultipleSurface_ConvectionCoefficient2Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="ASHRAEVerticalWall")]
        ASHRAEVerticalWall = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASTMC1340")]
        ASTMC1340 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveConvectionAlgorithm")]
        AdaptiveConvectionAlgorithm = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondStableHorizontal")]
        AlamdariHammondStableHorizontal = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondUnstableHorizontal")]
        AlamdariHammondUnstableHorizontal = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="AlamdariHammondVerticalWall")]
        AlamdariHammondVerticalWall = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="AwbiHattonHeatedFloor")]
        AwbiHattonHeatedFloor = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="AwbiHattonHeatedWall")]
        AwbiHattonHeatedWall = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedAssistedWall")]
        BeausoleilMorrisonMixedAssistedWall = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedOpposingWall")]
        BeausoleilMorrisonMixedOpposingWall = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedStableCeiling")]
        BeausoleilMorrisonMixedStableCeiling = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedStableFloor")]
        BeausoleilMorrisonMixedStableFloor = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedUnstableCeiling")]
        BeausoleilMorrisonMixedUnstableCeiling = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="BeausoleilMorrisonMixedUnstableFloor")]
        BeausoleilMorrisonMixedUnstableFloor = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="BlockenWindard")]
        BlockenWindard = 14,
        
        [System.Runtime.Serialization.EnumMember(Value="ClearRoof")]
        ClearRoof = 15,
        
        [System.Runtime.Serialization.EnumMember(Value="DOE-2")]
        DOE2 = 16,
        
        [System.Runtime.Serialization.EnumMember(Value="EmmelRoof")]
        EmmelRoof = 17,
        
        [System.Runtime.Serialization.EnumMember(Value="EmmelVertical")]
        EmmelVertical = 18,
        
        [System.Runtime.Serialization.EnumMember(Value="FisherPedersenCeilingDiffuserCeiling")]
        FisherPedersenCeilingDiffuserCeiling = 19,
        
        [System.Runtime.Serialization.EnumMember(Value="FisherPedersenCeilingDiffuserFloor")]
        FisherPedersenCeilingDiffuserFloor = 20,
        
        [System.Runtime.Serialization.EnumMember(Value="FisherPedersenCeilingDiffuserWalls")]
        FisherPedersenCeilingDiffuserWalls = 21,
        
        [System.Runtime.Serialization.EnumMember(Value="FohannoPolidoriVerticalWall")]
        FohannoPolidoriVerticalWall = 22,
        
        [System.Runtime.Serialization.EnumMember(Value="GoldsteinNovoselacCeilingDiffuserFloor")]
        GoldsteinNovoselacCeilingDiffuserFloor = 23,
        
        [System.Runtime.Serialization.EnumMember(Value="GoldsteinNovoselacCeilingDiffuserWalls")]
        GoldsteinNovoselacCeilingDiffuserWalls = 24,
        
        [System.Runtime.Serialization.EnumMember(Value="GoldsteinNovoselacCeilingDiffuserWindow")]
        GoldsteinNovoselacCeilingDiffuserWindow = 25,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099Windows")]
        ISO15099Windows = 26,
        
        [System.Runtime.Serialization.EnumMember(Value="KaradagChilledCeiling")]
        KaradagChilledCeiling = 27,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq3WallAwayFromHeat")]
        KhalifaEq3WallAwayFromHeat = 28,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq4CeilingAwayFromHeat")]
        KhalifaEq4CeilingAwayFromHeat = 29,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq5WallNearHeat")]
        KhalifaEq5WallNearHeat = 30,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq6NonHeatedWalls")]
        KhalifaEq6NonHeatedWalls = 31,
        
        [System.Runtime.Serialization.EnumMember(Value="KhalifaEq7Ceiling")]
        KhalifaEq7Ceiling = 32,
        
        [System.Runtime.Serialization.EnumMember(Value="McAdams")]
        McAdams = 33,
        
        [System.Runtime.Serialization.EnumMember(Value="Mitchell")]
        Mitchell = 34,
        
        [System.Runtime.Serialization.EnumMember(Value="MoWitt")]
        MoWitt = 35,
        
        [System.Runtime.Serialization.EnumMember(Value="NusseltJurges")]
        NusseltJurges = 36,
        
        [System.Runtime.Serialization.EnumMember(Value="Schedule")]
        Schedule = 37,
        
        [System.Runtime.Serialization.EnumMember(Value="Simple")]
        Simple = 38,
        
        [System.Runtime.Serialization.EnumMember(Value="SimpleCombined")]
        SimpleCombined = 39,
        
        [System.Runtime.Serialization.EnumMember(Value="TARP")]
        TARP = 40,
        
        [System.Runtime.Serialization.EnumMember(Value="UserCurve")]
        UserCurve = 41,
        
        [System.Runtime.Serialization.EnumMember(Value="Value")]
        Value = 42,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonStableHorizontalOrTilt")]
        WaltonStableHorizontalOrTilt = 43,
        
        [System.Runtime.Serialization.EnumMember(Value="WaltonUnstableHorizontalOrTilt")]
        WaltonUnstableHorizontalOrTilt = 44,
    }
    
    [Description(@"The interior and external vapor transfer coefficients. Normally these value are calculated using the heat convection coefficient values. Use this object to used fixed constant values. Units are kg/Pa.s.m2 This will only work with the CombinedHeatAndMoistureFiniteElement algorithm for surfaces. Other algorithms will ignore these coefficients")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceProperties_VaporCoefficients
    {
        

[JsonProperty(PropertyName="surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceName { get; set; } = "";
        

[JsonProperty(PropertyName="constant_external_vapor_transfer_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes ConstantExternalVaporTransferCoefficient { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[JsonProperty(PropertyName="external_vapor_coefficient_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ExternalVaporCoefficientValue { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="constant_internal_vapor_transfer_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes ConstantInternalVaporTransferCoefficient { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[JsonProperty(PropertyName="internal_vapor_coefficient_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InternalVaporCoefficientValue { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    [Description("Used to describe the decoupled layer, or baffle, and the characteristics of the c" +
        "avity and openings for naturally ventilated exterior surfaces. This object is al" +
        "so used in conjunction with the OtherSideConditionsModel.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceProperty_ExteriorNaturalVentedCavity
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Enter the name of a SurfaceProperty:OtherSideConditionsModel object")]
[JsonProperty(PropertyName="boundary_conditions_model_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BoundaryConditionsModelName { get; set; } = "";
        

[JsonProperty(PropertyName="area_fraction_of_openings", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AreaFractionOfOpenings { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_emissivity_of_exterior_baffle_material", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalEmissivityOfExteriorBaffleMaterial { get; set; } = null;
        

[JsonProperty(PropertyName="solar_absorbtivity_of_exterior_baffle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SolarAbsorbtivityOfExteriorBaffle { get; set; } = null;
        

[JsonProperty(PropertyName="height_scale_for_buoyancy_driven_ventilation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeightScaleForBuoyancyDrivenVentilation { get; set; } = null;
        

[Description("if corrugated, use average depth")]
[JsonProperty(PropertyName="effective_thickness_of_cavity_behind_exterior_baffle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EffectiveThicknessOfCavityBehindExteriorBaffle { get; set; } = null;
        

[Description("this parameter is used to help account for corrugations in the collector")]
[JsonProperty(PropertyName="ratio_of_actual_surface_area_to_projected_surface_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatioOfActualSurfaceAreaToProjectedSurfaceArea { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="roughness_of_exterior_surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceProperty_ExteriorNaturalVentedCavity_RoughnessOfExteriorSurface RoughnessOfExteriorSurface { get; set; } = (SurfaceProperty_ExteriorNaturalVentedCavity_RoughnessOfExteriorSurface)Enum.Parse(typeof(SurfaceProperty_ExteriorNaturalVentedCavity_RoughnessOfExteriorSurface), "MediumRough");
        

[JsonProperty(PropertyName="effectiveness_for_perforations_with_respect_to_wind", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EffectivenessForPerforationsWithRespectToWind { get; set; } = Double.Parse("0.25", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="discharge_coefficient_for_openings_with_respect_to_buoyancy_driven_flow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DischargeCoefficientForOpeningsWithRespectToBuoyancyDrivenFlow { get; set; } = Double.Parse("0.65", CultureInfo.InvariantCulture);
        

[Description("This list is the AllShadingAndHTSurfNames object-list")]
[JsonProperty(PropertyName="surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Surface { get; set; } = null;
    }
    
    public enum SurfaceProperty_ExteriorNaturalVentedCavity_RoughnessOfExteriorSurface
    {
        
        [System.Runtime.Serialization.EnumMember(Value="MediumRough")]
        MediumRough = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MediumSmooth")]
        MediumSmooth = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Rough")]
        Rough = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Smooth")]
        Smooth = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="VeryRough")]
        VeryRough = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="VerySmooth")]
        VerySmooth = 5,
    }
    
    [Description("Used to provide incident solar radiation on the inside of the surface. Reference " +
        "surface-construction pair and if that pair is used in a simulation, then program" +
        " will use value provided in schedule instead of calculating it.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceProperty_SolarIncidentInside
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceName { get; set; } = "";
        

[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("Values in schedule are expected to be in W/m2")]
[JsonProperty(PropertyName="inside_surface_incident_sun_solar_radiation_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InsideSurfaceIncidentSunSolarRadiationScheduleName { get; set; } = "";
    }
    
    [Description("This object defines the local environment properties of an exterior surface. One " +
        "or more environment properties have to be defined and linked to the exterior sur" +
        "face.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceProperty_LocalEnvironment
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Enter the name of an exterior surface object")]
[JsonProperty(PropertyName="exterior_surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ExteriorSurfaceName { get; set; } = "";
        

[Description("Enter the name of a Schedule object")]
[JsonProperty(PropertyName="external_shading_fraction_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ExternalShadingFractionScheduleName { get; set; } = "";
        

[Description("Enter the name of a SurfaceProperty:SurroundingSurfaces object")]
[JsonProperty(PropertyName="surrounding_surfaces_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurroundingSurfacesObjectName { get; set; } = "";
        

[Description("Enter the name of an OutdoorAir:Node object")]
[JsonProperty(PropertyName="outdoor_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirNodeName { get; set; } = "";
    }
    
    [Description("This object defines the local environment properties of a zone object. A correspo" +
        "nding outdoor air node should be defined and linked to the zone object.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneProperty_LocalEnvironment
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Enter the name of a zone object")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Enter the name of an OutdoorAir:Node object")]
[JsonProperty(PropertyName="outdoor_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirNodeName { get; set; } = "";
    }
    
    [Description("This object defines a list of surrounding surfaces for an exterior surface.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceProperty_SurroundingSurfaces
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("optional")]
[JsonProperty(PropertyName="sky_view_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SkyViewFactor { get; set; } = Double.Parse("0.5", CultureInfo.InvariantCulture);
        

[Description("Schedule values are real numbers, -100.0 to 100.0, units C optional")]
[JsonProperty(PropertyName="sky_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SkyTemperatureScheduleName { get; set; } = "";
        

[Description("optional")]
[JsonProperty(PropertyName="ground_view_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GroundViewFactor { get; set; } = Double.Parse("0.5", CultureInfo.InvariantCulture);
        

[Description("Schedule values are real numbers, -100.0 to 100.0, units C optional")]
[JsonProperty(PropertyName="ground_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string GroundTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="surfaces", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_SurroundingSurfaces_Surfaces_Item> Surfaces { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceProperty_SurroundingSurfaces_Surfaces_Item
    {
        

[JsonProperty(PropertyName="surrounding_surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurroundingSurfaceName { get; set; } = "";
        

[JsonProperty(PropertyName="surrounding_surface_view_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SurroundingSurfaceViewFactor { get; set; } = null;
        

[JsonProperty(PropertyName="surrounding_surface_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurroundingSurfaceTemperatureScheduleName { get; set; } = "";
    }
    
    [Description("Used to provide solar radiation absorbed in fenestration layers. References surfa" +
        "ce-construction pair and if that pair is used in a simulation, then program will" +
        " use value provided in schedules instead of calculating it.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ComplexFenestrationProperty_SolarAbsorbedLayers
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="fenestration_surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FenestrationSurface { get; set; } = "";
        

[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("Values in schedule are expected to be in W/m2")]
[JsonProperty(PropertyName="layer_1_solar_radiation_absorbed_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer1SolarRadiationAbsorbedScheduleName { get; set; } = "";
        

[Description("Values in schedule are expected to be in W/m2")]
[JsonProperty(PropertyName="layer_2_solar_radiation_absorbed_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer2SolarRadiationAbsorbedScheduleName { get; set; } = "";
        

[Description("Values in schedule are expected to be in W/m2")]
[JsonProperty(PropertyName="layer_3_solar_radiation_absorbed_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer3SolarRadiationAbsorbedScheduleName { get; set; } = "";
        

[Description("Values in schedule are expected to be in W/m2")]
[JsonProperty(PropertyName="layer_4_solar_radiation_absorbed_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer4SolarRadiationAbsorbedScheduleName { get; set; } = "";
        

[Description("Values in schedule are expected to be in W/m2")]
[JsonProperty(PropertyName="layer_5_solar_radiation_absorbed_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer5SolarRadiationAbsorbedScheduleName { get; set; } = "";
    }
    
    [Description("View factors for Surface to Surface in a zone. (Number of Surfaces)**2 are expect" +
        "ed. Any omitted surface pairs will be assumed to have a view factor of zero.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneProperty_UserViewFactors_BySurfaceName
    {
        

[Description("View factors may be entered for a single zone or for a group of zones connected b" +
    "y Construction:AirBoundary")]
[JsonProperty(PropertyName="zone_or_zonelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneOrZonelistName { get; set; } = "";
        

[JsonProperty(PropertyName="view_factors", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.ZoneProperty_UserViewFactors_BySurfaceName_ViewFactors_Item> ViewFactors { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneProperty_UserViewFactors_BySurfaceName_ViewFactors_Item
    {
        

[JsonProperty(PropertyName="from_surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FromSurface { get; set; } = "";
        

[JsonProperty(PropertyName="to_surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ToSurface { get; set; } = "";
        

[JsonProperty(PropertyName="view_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ViewFactor { get; set; } = null;
    }
}
