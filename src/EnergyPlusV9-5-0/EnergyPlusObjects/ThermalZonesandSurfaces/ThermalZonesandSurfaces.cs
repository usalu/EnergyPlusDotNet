namespace EnergyPlus.ThermalZonesandSurfaces
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
    
    
    [Description("Specifies the geometric rules used to describe the input of surface vertices and " +
        "daylighting reference points.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GlobalGeometryRules
    {
        

[Description("Specified as entry for a 4 sided surface/rectangle Surfaces are specified as view" +
    "ed from outside the surface Shading surfaces as viewed from behind. (towards wha" +
    "t they are shading)")]
[JsonProperty(PropertyName="starting_vertex_position", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public GlobalGeometryRules_StartingVertexPosition StartingVertexPosition { get; set; } = (GlobalGeometryRules_StartingVertexPosition)Enum.Parse(typeof(GlobalGeometryRules_StartingVertexPosition), "LowerLeftCorner");
        

[JsonProperty(PropertyName="vertex_entry_direction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public GlobalGeometryRules_VertexEntryDirection VertexEntryDirection { get; set; } = (GlobalGeometryRules_VertexEntryDirection)Enum.Parse(typeof(GlobalGeometryRules_VertexEntryDirection), "Clockwise");
        

[Description("Relative -- coordinates are entered relative to zone origin World -- all coordina" +
    "tes entered are \"absolute\" for this facility")]
[JsonProperty(PropertyName="coordinate_system", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public GlobalGeometryRules_CoordinateSystem CoordinateSystem { get; set; } = (GlobalGeometryRules_CoordinateSystem)Enum.Parse(typeof(GlobalGeometryRules_CoordinateSystem), "Relative");
        

[Description("Relative -- coordinates are entered relative to zone origin World -- all coordina" +
    "tes entered are \"absolute\" for this facility")]
[JsonProperty(PropertyName="daylighting_reference_point_coordinate_system", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public GlobalGeometryRules_DaylightingReferencePointCoordinateSystem DaylightingReferencePointCoordinateSystem { get; set; } = (GlobalGeometryRules_DaylightingReferencePointCoordinateSystem)Enum.Parse(typeof(GlobalGeometryRules_DaylightingReferencePointCoordinateSystem), "Relative");
        

[Description("Relative -- Starting corner is entered relative to zone origin World -- Starting " +
    "corner is entered in \"absolute\"")]
[JsonProperty(PropertyName="rectangular_surface_coordinate_system", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public GlobalGeometryRules_RectangularSurfaceCoordinateSystem RectangularSurfaceCoordinateSystem { get; set; } = (GlobalGeometryRules_RectangularSurfaceCoordinateSystem)Enum.Parse(typeof(GlobalGeometryRules_RectangularSurfaceCoordinateSystem), "Relative");
    }
    
    public enum GlobalGeometryRules_StartingVertexPosition
    {
        
        [System.Runtime.Serialization.EnumMember(Value="LowerLeftCorner")]
        LowerLeftCorner = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="LowerRightCorner")]
        LowerRightCorner = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UpperLeftCorner")]
        UpperLeftCorner = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="UpperRightCorner")]
        UpperRightCorner = 3,
    }
    
    public enum GlobalGeometryRules_VertexEntryDirection
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Clockwise")]
        Clockwise = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Counterclockwise")]
        Counterclockwise = 1,
    }
    
    public enum GlobalGeometryRules_CoordinateSystem
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Relative")]
        Relative = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="World")]
        World = 1,
    }
    
    public enum GlobalGeometryRules_DaylightingReferencePointCoordinateSystem
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Relative")]
        Relative = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="World")]
        World = 2,
    }
    
    public enum GlobalGeometryRules_RectangularSurfaceCoordinateSystem
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Relative")]
        Relative = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="World")]
        World = 2,
    }
    
    [Description("Provides a simple method of altering the footprint geometry of a model. The inten" +
        "t is to provide a single parameter that can be used to reshape the building desc" +
        "ription contained in the rest of the input file.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GeometryTransform
    {
        

[Description("only current allowed value is \"XY\"")]
[JsonProperty(PropertyName="plane_of_transform", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public GeometryTransform_PlaneOfTransform PlaneOfTransform { get; set; } = (GeometryTransform_PlaneOfTransform)Enum.Parse(typeof(GeometryTransform_PlaneOfTransform), "XY");
        

[Description("Aspect ratio of building as described in idf")]
[JsonProperty(PropertyName="current_aspect_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CurrentAspectRatio { get; set; } = null;
        

[Description("Aspect ratio to transform to during run")]
[JsonProperty(PropertyName="new_aspect_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NewAspectRatio { get; set; } = null;
    }
    
    public enum GeometryTransform_PlaneOfTransform
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="XY")]
        XY = 1,
    }
    
    [Description("Defines a thermal zone of the building.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Zone
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="direction_of_relative_north", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DirectionOfRelativeNorth { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="x_origin", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> XOrigin { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="y_origin", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> YOrigin { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="z_origin", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZOrigin { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Type { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Multiplier { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description(@"If this field is 0.0, negative or autocalculate, then the average height of the zone is automatically calculated and used in subsequent calculations. If this field is positive, then the number entered here will be used. Note that the Zone Ceiling Height is the distance from the Floor to the Ceiling in the Zone, not an absolute height from the ground.")]
[JsonProperty(PropertyName="ceiling_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> CeilingHeight { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("If this field is 0.0, negative or autocalculate, then the volume of the zone is a" +
    "utomatically calculated and used in subsequent calculations. If this field is po" +
    "sitive, then the number entered here will be used.")]
[JsonProperty(PropertyName="volume", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> Volume { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("If this field is 0.0, negative or autocalculate, then the floor area of the zone " +
    "is automatically calculated and used in subsequent calculations. If this field i" +
    "s positive, then the number entered here will be used.")]
[JsonProperty(PropertyName="floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> FloorArea { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Will default to same value as SurfaceConvectionAlgorithm:Inside object setting this field overrides the default SurfaceConvectionAlgorithm:Inside for this zone Simple = constant natural convection (ASHRAE) TARP = variable natural convection based on temperature difference (ASHRAE) CeilingDiffuser = ACH based forced and mixed convection correlations for ceiling diffuser configuration with simple natural convection limit AdaptiveConvectionAlgorithm = dynamic selection of convection models based on conditions TrombeWall = variable natural convection in an enclosed rectangular cavity ASTMC1340 = mixed convection correlations specified for attic zone")]
[JsonProperty(PropertyName="zone_inside_convection_algorithm", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Zone_ZoneInsideConvectionAlgorithm ZoneInsideConvectionAlgorithm { get; set; } = (Zone_ZoneInsideConvectionAlgorithm)Enum.Parse(typeof(Zone_ZoneInsideConvectionAlgorithm), "Empty");
        

[Description(@"Will default to same value as SurfaceConvectionAlgorithm:Outside object setting this field overrides the default SurfaceConvectionAlgorithm:Outside for this zone SimpleCombined = Combined radiation and convection coefficient using simple ASHRAE model TARP = correlation from models developed by ASHRAE, Walton, and Sparrow et. al. MoWiTT = correlation from measurements by Klems and Yazdanian for smooth surfaces DOE-2 = correlation from measurements by Klems and Yazdanian for rough surfaces AdaptiveConvectionAlgorithm = dynamic selection of correlations based on conditions")]
[JsonProperty(PropertyName="zone_outside_convection_algorithm", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Zone_ZoneOutsideConvectionAlgorithm ZoneOutsideConvectionAlgorithm { get; set; } = (Zone_ZoneOutsideConvectionAlgorithm)Enum.Parse(typeof(Zone_ZoneOutsideConvectionAlgorithm), "Empty");
        

[JsonProperty(PropertyName="part_of_total_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes PartOfTotalFloorArea { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
    }
    
    public enum Zone_ZoneInsideConvectionAlgorithm
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASTMC1340")]
        ASTMC1340 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveConvectionAlgorithm")]
        AdaptiveConvectionAlgorithm = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="CeilingDiffuser")]
        CeilingDiffuser = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Simple")]
        Simple = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="TARP")]
        TARP = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="TrombeWall")]
        TrombeWall = 6,
    }
    
    public enum Zone_ZoneOutsideConvectionAlgorithm
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveConvectionAlgorithm")]
        AdaptiveConvectionAlgorithm = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DOE-2")]
        DOE2 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MoWiTT")]
        MoWiTT = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="SimpleCombined")]
        SimpleCombined = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="TARP")]
        TARP = 5,
    }
    
    [Description(@"Defines a list of thermal zones which can be referenced as a group. The ZoneList name may be used elsewhere in the input to apply a parameter to all zones in the list. ZoneLists can be used effectively with the following objects: People, Lights, ElectricEquipment, GasEquipment, HotWaterEquipment, ZoneInfiltration:DesignFlowRate, ZoneVentilation:DesignFlowRate, Sizing:Zone, ZoneControl:Thermostat, and others.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneList
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("This list is the ZoneNames object-list")]
[JsonProperty(PropertyName="zones", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Zones { get; set; } = null;
    }
    
    [Description("Adds a multiplier to a ZoneList. This can be used to reduce the amount of input n" +
        "ecessary for simulating repetitive structures, such as the identical floors of a" +
        " multi-story building.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneGroup
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneListName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_list_multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneListMultiplier { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
    }
    
    [Description("Allows for detailed entry of building heat transfer surfaces. Does not include su" +
        "bsurfaces such as windows or doors.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class BuildingSurface_Detailed
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="surface_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public BuildingSurface_Detailed_SurfaceType SurfaceType { get; set; } = (BuildingSurface_Detailed_SurfaceType)Enum.Parse(typeof(BuildingSurface_Detailed_SurfaceType), "Ceiling");
        

[Description("To be matched with a construction in this input file")]
[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("Zone the surface is a part of")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="outside_boundary_condition", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public BuildingSurface_Detailed_OutsideBoundaryCondition OutsideBoundaryCondition { get; set; } = (BuildingSurface_Detailed_OutsideBoundaryCondition)Enum.Parse(typeof(BuildingSurface_Detailed_OutsideBoundaryCondition), "Adiabatic");
        

[Description(@"Non-blank only if the field Outside Boundary Condition is Surface, Zone, OtherSideCoefficients or OtherSideConditionsModel If Surface, specify name of corresponding surface in adjacent zone or specify current surface name for internal partition separating like zones If Zone, specify the name of the corresponding zone and the program will generate the corresponding interzone surface If Foundation, specify the name of the corresponding Foundation object and the program will calculate the heat transfer appropriately If OtherSideCoefficients, specify name of SurfaceProperty:OtherSideCoefficients If OtherSideConditionsModel, specify name of SurfaceProperty:OtherSideConditionsModel")]
[JsonProperty(PropertyName="outside_boundary_condition_object", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutsideBoundaryConditionObject { get; set; } = "";
        

[JsonProperty(PropertyName="sun_exposure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public BuildingSurface_Detailed_SunExposure SunExposure { get; set; } = (BuildingSurface_Detailed_SunExposure)Enum.Parse(typeof(BuildingSurface_Detailed_SunExposure), "SunExposed");
        

[JsonProperty(PropertyName="wind_exposure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public BuildingSurface_Detailed_WindExposure WindExposure { get; set; } = (BuildingSurface_Detailed_WindExposure)Enum.Parse(typeof(BuildingSurface_Detailed_WindExposure), "WindExposed");
        

[Description(@"From the exterior of the surface Unused if one uses the ""reflections"" options in Solar Distribution in Building input unless a DaylightingDevice:Shelf or DaylightingDevice:Tubular object has been specified. autocalculate will automatically calculate this value from the tilt of the surface")]
[JsonProperty(PropertyName="view_factor_to_ground", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> ViewFactorToGround { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"shown with 120 vertex coordinates -- extensible object ""extensible"" -- duplicate last set of x,y,z coordinates (last 3 fields), remembering to remove ; from ""inner"" fields. for clarity in any error messages, renumber the fields as well. (and changing z terminator to a comma "","" for all but last one which needs a semi-colon "";"") vertices are given in GlobalGeometryRules coordinates -- if relative, all surface coordinates are ""relative"" to the Zone Origin. If world, then building and zone origins are used for some internal calculations, but all coordinates are given in an ""absolute"" system.")]
[JsonProperty(PropertyName="number_of_vertices", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> NumberOfVertices { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="vertices", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.BuildingSurface_Detailed_Vertices_Item> Vertices { get; set; } = null;
    }
    
    public enum BuildingSurface_Detailed_SurfaceType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Ceiling")]
        Ceiling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Floor")]
        Floor = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Roof")]
        Roof = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Wall")]
        Wall = 3,
    }
    
    public enum BuildingSurface_Detailed_OutsideBoundaryCondition
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Adiabatic")]
        Adiabatic = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Foundation")]
        Foundation = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Ground")]
        Ground = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundBasementPreprocessorAverageFloor")]
        GroundBasementPreprocessorAverageFloor = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundBasementPreprocessorAverageWall")]
        GroundBasementPreprocessorAverageWall = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundBasementPreprocessorLowerWall")]
        GroundBasementPreprocessorLowerWall = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundBasementPreprocessorUpperWall")]
        GroundBasementPreprocessorUpperWall = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundFCfactorMethod")]
        GroundFCfactorMethod = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundSlabPreprocessorAverage")]
        GroundSlabPreprocessorAverage = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundSlabPreprocessorCore")]
        GroundSlabPreprocessorCore = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundSlabPreprocessorPerimeter")]
        GroundSlabPreprocessorPerimeter = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherSideCoefficients")]
        OtherSideCoefficients = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherSideConditionsModel")]
        OtherSideConditionsModel = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Outdoors")]
        Outdoors = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Surface")]
        Surface = 14,
        
        [System.Runtime.Serialization.EnumMember(Value="Zone")]
        Zone = 15,
    }
    
    public enum BuildingSurface_Detailed_SunExposure
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="NoSun")]
        NoSun = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SunExposed")]
        SunExposed = 2,
    }
    
    public enum BuildingSurface_Detailed_WindExposure
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="NoWind")]
        NoWind = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="WindExposed")]
        WindExposed = 2,
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class BuildingSurface_Detailed_Vertices_Item
    {
        

[JsonProperty(PropertyName="vertex_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VertexXCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="vertex_y_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VertexYCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="vertex_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VertexZCoordinate { get; set; } = null;
    }
    
    [Description("Allows for detailed entry of wall heat transfer surfaces.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Wall_Detailed
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("To be matched with a construction in this input file")]
[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("Zone the surface is a part of")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="outside_boundary_condition", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Wall_Detailed_OutsideBoundaryCondition OutsideBoundaryCondition { get; set; } = (Wall_Detailed_OutsideBoundaryCondition)Enum.Parse(typeof(Wall_Detailed_OutsideBoundaryCondition), "Adiabatic");
        

[Description(@"Non-blank only if the field Outside Boundary Condition is Surface, Zone, OtherSideCoefficients or OtherSideConditionsModel If Surface, specify name of corresponding surface in adjacent zone or specify current surface name for internal partition separating like zones If Zone, specify the name of the corresponding zone and the program will generate the corresponding interzone surface If Foundation, specify the name of the corresponding Foundation object and If OtherSideCoefficients, specify name of SurfaceProperty:OtherSideCoefficients If OtherSideConditionsModel, specify name of SurfaceProperty:OtherSideConditionsModel")]
[JsonProperty(PropertyName="outside_boundary_condition_object", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutsideBoundaryConditionObject { get; set; } = "";
        

[JsonProperty(PropertyName="sun_exposure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Wall_Detailed_SunExposure SunExposure { get; set; } = (Wall_Detailed_SunExposure)Enum.Parse(typeof(Wall_Detailed_SunExposure), "SunExposed");
        

[JsonProperty(PropertyName="wind_exposure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Wall_Detailed_WindExposure WindExposure { get; set; } = (Wall_Detailed_WindExposure)Enum.Parse(typeof(Wall_Detailed_WindExposure), "WindExposed");
        

[Description(@"From the exterior of the surface Unused if one uses the ""reflections"" options in Solar Distribution in Building input unless a DaylightingDevice:Shelf or DaylightingDevice:Tubular object has been specified. autocalculate will automatically calculate this value from the tilt of the surface")]
[JsonProperty(PropertyName="view_factor_to_ground", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> ViewFactorToGround { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"shown with 10 vertex coordinates -- extensible object ""extensible"" -- duplicate last set of x,y,z coordinates, renumbering please (and changing z terminator to a comma "","" for all but last one which needs a semi-colon "";"") vertices are given in GlobalGeometryRules coordinates -- if relative, all surface coordinates are ""relative"" to the Zone Origin. If world, then building and zone origins are used for some internal calculations, but all coordinates are given in an ""absolute"" system.")]
[JsonProperty(PropertyName="number_of_vertices", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> NumberOfVertices { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="vertices", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Wall_Detailed_Vertices_Item> Vertices { get; set; } = null;
    }
    
    public enum Wall_Detailed_OutsideBoundaryCondition
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Adiabatic")]
        Adiabatic = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Foundation")]
        Foundation = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Ground")]
        Ground = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundBasementPreprocessorAverageFloor")]
        GroundBasementPreprocessorAverageFloor = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundBasementPreprocessorAverageWall")]
        GroundBasementPreprocessorAverageWall = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundBasementPreprocessorLowerWall")]
        GroundBasementPreprocessorLowerWall = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundBasementPreprocessorUpperWall")]
        GroundBasementPreprocessorUpperWall = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundFCfactorMethod")]
        GroundFCfactorMethod = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundSlabPreprocessorAverage")]
        GroundSlabPreprocessorAverage = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundSlabPreprocessorCore")]
        GroundSlabPreprocessorCore = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundSlabPreprocessorPerimeter")]
        GroundSlabPreprocessorPerimeter = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherSideCoefficients")]
        OtherSideCoefficients = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherSideConditionsModel")]
        OtherSideConditionsModel = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Outdoors")]
        Outdoors = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Surface")]
        Surface = 14,
        
        [System.Runtime.Serialization.EnumMember(Value="Zone")]
        Zone = 15,
    }
    
    public enum Wall_Detailed_SunExposure
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="NoSun")]
        NoSun = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SunExposed")]
        SunExposed = 2,
    }
    
    public enum Wall_Detailed_WindExposure
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="NoWind")]
        NoWind = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="WindExposed")]
        WindExposed = 2,
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Wall_Detailed_Vertices_Item
    {
        

[JsonProperty(PropertyName="vertex_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VertexXCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="vertex_y_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VertexYCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="vertex_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VertexZCoordinate { get; set; } = null;
    }
    
    [Description("Allows for detailed entry of roof/ceiling heat transfer surfaces.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoofCeiling_Detailed
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("To be matched with a construction in this input file")]
[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("Zone the surface is a part of")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="outside_boundary_condition", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public RoofCeiling_Detailed_OutsideBoundaryCondition OutsideBoundaryCondition { get; set; } = (RoofCeiling_Detailed_OutsideBoundaryCondition)Enum.Parse(typeof(RoofCeiling_Detailed_OutsideBoundaryCondition), "Adiabatic");
        

[Description(@"Non-blank only if the field Outside Boundary Condition is Surface, Zone, OtherSideCoefficients or OtherSideConditionsModel If Surface, specify name of corresponding surface in adjacent zone or specify current surface name for internal partition separating like zones If Zone, specify the name of the corresponding zone and the program will generate the corresponding interzone surface If OtherSideCoefficients, specify name of SurfaceProperty:OtherSideCoefficients If OtherSideConditionsModel, specify name of SurfaceProperty:OtherSideConditionsModel")]
[JsonProperty(PropertyName="outside_boundary_condition_object", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutsideBoundaryConditionObject { get; set; } = "";
        

[JsonProperty(PropertyName="sun_exposure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public RoofCeiling_Detailed_SunExposure SunExposure { get; set; } = (RoofCeiling_Detailed_SunExposure)Enum.Parse(typeof(RoofCeiling_Detailed_SunExposure), "SunExposed");
        

[JsonProperty(PropertyName="wind_exposure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public RoofCeiling_Detailed_WindExposure WindExposure { get; set; } = (RoofCeiling_Detailed_WindExposure)Enum.Parse(typeof(RoofCeiling_Detailed_WindExposure), "WindExposed");
        

[Description(@"From the exterior of the surface Unused if one uses the ""reflections"" options in Solar Distribution in Building input unless a DaylightingDevice:Shelf or DaylightingDevice:Tubular object has been specified. autocalculate will automatically calculate this value from the tilt of the surface")]
[JsonProperty(PropertyName="view_factor_to_ground", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> ViewFactorToGround { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"shown with 10 vertex coordinates -- extensible object ""extensible"" -- duplicate last set of x,y,z coordinates, renumbering please (and changing z terminator to a comma "","" for all but last one which needs a semi-colon "";"") vertices are given in GlobalGeometryRules coordinates -- if relative, all surface coordinates are ""relative"" to the Zone Origin. If world, then building and zone origins are used for some internal calculations, but all coordinates are given in an ""absolute"" system.")]
[JsonProperty(PropertyName="number_of_vertices", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> NumberOfVertices { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="vertices", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.RoofCeiling_Detailed_Vertices_Item> Vertices { get; set; } = null;
    }
    
    public enum RoofCeiling_Detailed_OutsideBoundaryCondition
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Adiabatic")]
        Adiabatic = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Ground")]
        Ground = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundBasementPreprocessorAverageFloor")]
        GroundBasementPreprocessorAverageFloor = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundBasementPreprocessorAverageWall")]
        GroundBasementPreprocessorAverageWall = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundBasementPreprocessorLowerWall")]
        GroundBasementPreprocessorLowerWall = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundBasementPreprocessorUpperWall")]
        GroundBasementPreprocessorUpperWall = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundSlabPreprocessorAverage")]
        GroundSlabPreprocessorAverage = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundSlabPreprocessorCore")]
        GroundSlabPreprocessorCore = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundSlabPreprocessorPerimeter")]
        GroundSlabPreprocessorPerimeter = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherSideCoefficients")]
        OtherSideCoefficients = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherSideConditionsModel")]
        OtherSideConditionsModel = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="Outdoors")]
        Outdoors = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="Surface")]
        Surface = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Zone")]
        Zone = 13,
    }
    
    public enum RoofCeiling_Detailed_SunExposure
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="NoSun")]
        NoSun = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SunExposed")]
        SunExposed = 2,
    }
    
    public enum RoofCeiling_Detailed_WindExposure
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="NoWind")]
        NoWind = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="WindExposed")]
        WindExposed = 2,
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class RoofCeiling_Detailed_Vertices_Item
    {
        

[JsonProperty(PropertyName="vertex_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VertexXCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="vertex_y_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VertexYCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="vertex_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VertexZCoordinate { get; set; } = null;
    }
    
    [Description("Allows for detailed entry of floor heat transfer surfaces.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Floor_Detailed
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("To be matched with a construction in this input file")]
[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("Zone the surface is a part of")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="outside_boundary_condition", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Floor_Detailed_OutsideBoundaryCondition OutsideBoundaryCondition { get; set; } = (Floor_Detailed_OutsideBoundaryCondition)Enum.Parse(typeof(Floor_Detailed_OutsideBoundaryCondition), "Adiabatic");
        

[Description(@"Non-blank only if the field Outside Boundary Condition is Surface, Zone, OtherSideCoefficients or OtherSideConditionsModel If Surface, specify name of corresponding surface in adjacent zone or specify current surface name for internal partition separating like zones If Zone, specify the name of the corresponding zone and the program will generate the corresponding interzone surface If Foundation, specify the name of the corresponding Foundation object and If OtherSideCoefficients, specify name of SurfaceProperty:OtherSideCoefficients If OtherSideConditionsModel, specify name of SurfaceProperty:OtherSideConditionsModel")]
[JsonProperty(PropertyName="outside_boundary_condition_object", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutsideBoundaryConditionObject { get; set; } = "";
        

[JsonProperty(PropertyName="sun_exposure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Floor_Detailed_SunExposure SunExposure { get; set; } = (Floor_Detailed_SunExposure)Enum.Parse(typeof(Floor_Detailed_SunExposure), "SunExposed");
        

[JsonProperty(PropertyName="wind_exposure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Floor_Detailed_WindExposure WindExposure { get; set; } = (Floor_Detailed_WindExposure)Enum.Parse(typeof(Floor_Detailed_WindExposure), "WindExposed");
        

[Description(@"From the exterior of the surface Unused if one uses the ""reflections"" options in Solar Distribution in Building input unless a DaylightingDevice:Shelf or DaylightingDevice:Tubular object has been specified. autocalculate will automatically calculate this value from the tilt of the surface")]
[JsonProperty(PropertyName="view_factor_to_ground", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> ViewFactorToGround { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"shown with 10 vertex coordinates -- extensible object ""extensible"" -- duplicate last set of x,y,z coordinates, renumbering please (and changing z terminator to a comma "","" for all but last one which needs a semi-colon "";"") vertices are given in GlobalGeometryRules coordinates -- if relative, all surface coordinates are ""relative"" to the Zone Origin. If world, then building and zone origins are used for some internal calculations, but all coordinates are given in an ""absolute"" system.")]
[JsonProperty(PropertyName="number_of_vertices", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> NumberOfVertices { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="vertices", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Floor_Detailed_Vertices_Item> Vertices { get; set; } = null;
    }
    
    public enum Floor_Detailed_OutsideBoundaryCondition
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Adiabatic")]
        Adiabatic = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Foundation")]
        Foundation = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Ground")]
        Ground = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundBasementPreprocessorAverageFloor")]
        GroundBasementPreprocessorAverageFloor = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundBasementPreprocessorAverageWall")]
        GroundBasementPreprocessorAverageWall = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundBasementPreprocessorLowerWall")]
        GroundBasementPreprocessorLowerWall = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundBasementPreprocessorUpperWall")]
        GroundBasementPreprocessorUpperWall = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundFCfactorMethod")]
        GroundFCfactorMethod = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundSlabPreprocessorAverage")]
        GroundSlabPreprocessorAverage = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundSlabPreprocessorCore")]
        GroundSlabPreprocessorCore = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="GroundSlabPreprocessorPerimeter")]
        GroundSlabPreprocessorPerimeter = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherSideCoefficients")]
        OtherSideCoefficients = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherSideConditionsModel")]
        OtherSideConditionsModel = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Outdoors")]
        Outdoors = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Surface")]
        Surface = 14,
        
        [System.Runtime.Serialization.EnumMember(Value="Zone")]
        Zone = 15,
    }
    
    public enum Floor_Detailed_SunExposure
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="NoSun")]
        NoSun = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SunExposed")]
        SunExposed = 2,
    }
    
    public enum Floor_Detailed_WindExposure
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="NoWind")]
        NoWind = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="WindExposed")]
        WindExposed = 2,
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Floor_Detailed_Vertices_Item
    {
        

[JsonProperty(PropertyName="vertex_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VertexXCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="vertex_y_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VertexYCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="vertex_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VertexZCoordinate { get; set; } = null;
    }
    
    [Description("Allows for simplified entry of exterior walls. View Factor to Ground is automatic" +
        "ally calculated.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Wall_Exterior
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("To be matched with a construction in this input file")]
[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("Zone the surface is a part of")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Facing direction of outside of wall (S=180,N=0,E=90,W=270)")]
[JsonProperty(PropertyName="azimuth_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AzimuthAngle { get; set; } = null;
        

[Description("Walls are usually tilted 90 degrees")]
[JsonProperty(PropertyName="tilt_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TiltAngle { get; set; } = Double.Parse("90", CultureInfo.InvariantCulture);
        

[Description("Starting (x,y,z) coordinate is the Lower Left Corner of the Wall")]
[JsonProperty(PropertyName="starting_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingXCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_y_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingYCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingZCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Length { get; set; } = null;
        

[JsonProperty(PropertyName="height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Height { get; set; } = null;
    }
    
    [Description("Allows for simplified entry of interior walls.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Wall_Adiabatic
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("To be matched with a construction in this input file")]
[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("Zone the surface is a part of")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Facing direction of outside of wall (S=180,N=0,E=90,W=270)")]
[JsonProperty(PropertyName="azimuth_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AzimuthAngle { get; set; } = null;
        

[Description("Walls are usually tilted 90 degrees")]
[JsonProperty(PropertyName="tilt_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TiltAngle { get; set; } = Double.Parse("90", CultureInfo.InvariantCulture);
        

[Description("Starting (x,y,z) coordinate is the Lower Left Corner of the Wall")]
[JsonProperty(PropertyName="starting_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingXCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_y_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingYCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingZCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Length { get; set; } = null;
        

[JsonProperty(PropertyName="height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Height { get; set; } = null;
    }
    
    [Description("Allows for simplified entry of underground walls.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Wall_Underground
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("To be matched with a construction in this input file. If the construction is type" +
    " \"Construction:CfactorUndergroundWall\", then the GroundFCfactorMethod will be us" +
    "ed.")]
[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("Zone the surface is a part of")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Facing direction of outside of wall (S=180,N=0,E=90,W=270)")]
[JsonProperty(PropertyName="azimuth_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AzimuthAngle { get; set; } = null;
        

[Description("Walls are usually tilted 90 degrees")]
[JsonProperty(PropertyName="tilt_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TiltAngle { get; set; } = Double.Parse("90", CultureInfo.InvariantCulture);
        

[Description("Starting (x,y,z) coordinate is the Lower Left Corner of the Wall")]
[JsonProperty(PropertyName="starting_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingXCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_y_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingYCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingZCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Length { get; set; } = null;
        

[JsonProperty(PropertyName="height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Height { get; set; } = null;
    }
    
    [Description("Allows for simplified entry of interzone walls (walls between zones).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Wall_Interzone
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("To be matched with a construction in this input file")]
[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("Zone for the inside of the surface")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Specify a surface name in an adjacent zone for known interior walls. Specify a zo" +
    "ne name of an adjacent zone to automatically generate the interior wall in the a" +
    "djacent zone.")]
[JsonProperty(PropertyName="outside_boundary_condition_object", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutsideBoundaryConditionObject { get; set; } = "";
        

[Description("Facing direction of outside of wall (S=180,N=0,E=90,W=270)")]
[JsonProperty(PropertyName="azimuth_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AzimuthAngle { get; set; } = null;
        

[Description("Walls are usually tilted 90 degrees")]
[JsonProperty(PropertyName="tilt_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TiltAngle { get; set; } = Double.Parse("90", CultureInfo.InvariantCulture);
        

[Description("Starting (x,y,z) coordinate is the Lower Left Corner of the Wall")]
[JsonProperty(PropertyName="starting_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingXCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_y_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingYCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingZCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Length { get; set; } = null;
        

[JsonProperty(PropertyName="height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Height { get; set; } = null;
    }
    
    [Description("Allows for simplified entry of roofs (exterior). View Factor to Ground is automat" +
        "ically calculated.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Roof
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("To be matched with a construction in this input file")]
[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("Zone the surface is a part of")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Facing direction of outside of Roof")]
[JsonProperty(PropertyName="azimuth_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AzimuthAngle { get; set; } = null;
        

[Description("Flat Roofs are tilted 0 degrees")]
[JsonProperty(PropertyName="tilt_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TiltAngle { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("If not Flat, Starting coordinate is the Lower Left Corner of the Roof")]
[JsonProperty(PropertyName="starting_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingXCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_y_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingYCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingZCoordinate { get; set; } = null;
        

[Description("Along X Axis")]
[JsonProperty(PropertyName="length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Length { get; set; } = null;
        

[Description("Along Y Axis")]
[JsonProperty(PropertyName="width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Width { get; set; } = null;
    }
    
    [Description("Allows for simplified entry of interior ceilings.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Ceiling_Adiabatic
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("To be matched with a construction in this input file")]
[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("Zone the surface is a part of")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Facing direction of outside of Ceiling")]
[JsonProperty(PropertyName="azimuth_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AzimuthAngle { get; set; } = null;
        

[Description("Ceilings are usually tilted 0 degrees")]
[JsonProperty(PropertyName="tilt_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TiltAngle { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("If not Flat, Starting coordinate is the Lower Left Corner of the Ceiling")]
[JsonProperty(PropertyName="starting_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingXCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_y_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingYCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingZCoordinate { get; set; } = null;
        

[Description("Along X Axis")]
[JsonProperty(PropertyName="length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Length { get; set; } = null;
        

[Description("Along Y Axis")]
[JsonProperty(PropertyName="width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Width { get; set; } = null;
    }
    
    [Description("Allows for simplified entry of ceilings using adjacent zone (interzone) heat tran" +
        "sfer - adjacent surface should be a floor")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Ceiling_Interzone
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("To be matched with a construction in this input file")]
[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("Zone for the inside of the surface")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Specify a surface name in an adjacent zone for known interior floors Specify a zo" +
    "ne name of an adjacent zone to automatically generate the interior floor in the " +
    "adjacent zone.")]
[JsonProperty(PropertyName="outside_boundary_condition_object", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutsideBoundaryConditionObject { get; set; } = "";
        

[Description("Facing direction of outside of wall (S=180,N=0,E=90,W=270)")]
[JsonProperty(PropertyName="azimuth_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AzimuthAngle { get; set; } = null;
        

[Description("Ceilings are usually tilted 0 degrees")]
[JsonProperty(PropertyName="tilt_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TiltAngle { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("If not Flat, should be Lower Left Corner (from outside)")]
[JsonProperty(PropertyName="starting_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingXCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_y_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingYCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingZCoordinate { get; set; } = null;
        

[Description("Along X Axis")]
[JsonProperty(PropertyName="length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Length { get; set; } = null;
        

[Description("Along Y Axis")]
[JsonProperty(PropertyName="width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Width { get; set; } = null;
    }
    
    [Description("Allows for simplified entry of exterior floors with ground contact. View Factors " +
        "to Ground is automatically calculated.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Floor_GroundContact
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("To be matched with a construction in this input file If the construction is type " +
    "\"Construction:FfactorGroundFloor\", then the GroundFCfactorMethod will be used.")]
[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("Zone the surface is a part of")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="azimuth_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AzimuthAngle { get; set; } = null;
        

[Description("Floors are usually tilted 180 degrees")]
[JsonProperty(PropertyName="tilt_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TiltAngle { get; set; } = Double.Parse("180", CultureInfo.InvariantCulture);
        

[Description("if not flat, should be lower left corner (from outside)")]
[JsonProperty(PropertyName="starting_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingXCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_y_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingYCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingZCoordinate { get; set; } = null;
        

[Description("Along X Axis")]
[JsonProperty(PropertyName="length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Length { get; set; } = null;
        

[Description("Along Y Axis")]
[JsonProperty(PropertyName="width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Width { get; set; } = null;
    }
    
    [Description("Allows for simplified entry of exterior floors ignoring ground contact or interio" +
        "r floors. View Factor to Ground is automatically calculated.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Floor_Adiabatic
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("To be matched with a construction in this input file")]
[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("Zone the surface is a part of")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="azimuth_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AzimuthAngle { get; set; } = null;
        

[Description("Floors are usually tilted 180 degrees")]
[JsonProperty(PropertyName="tilt_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TiltAngle { get; set; } = Double.Parse("180", CultureInfo.InvariantCulture);
        

[Description("if not flat, should be lower left corner (from outside)")]
[JsonProperty(PropertyName="starting_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingXCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_y_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingYCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingZCoordinate { get; set; } = null;
        

[Description("Along X Axis")]
[JsonProperty(PropertyName="length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Length { get; set; } = null;
        

[Description("Along Y Axis")]
[JsonProperty(PropertyName="width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Width { get; set; } = null;
    }
    
    [Description("Allows for simplified entry of floors using adjacent zone (interzone) heat transf" +
        "er - adjacent surface should be a ceiling.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Floor_Interzone
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("To be matched with a construction in this input file")]
[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("Zone for the inside of the surface")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Specify a surface name in an adjacent zone for known interior ceilings. Specify a" +
    " zone name of an adjacent zone to automatically generate the interior ceiling in" +
    " the adjacent zone.")]
[JsonProperty(PropertyName="outside_boundary_condition_object", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutsideBoundaryConditionObject { get; set; } = "";
        

[JsonProperty(PropertyName="azimuth_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AzimuthAngle { get; set; } = null;
        

[Description("Floors are usually tilted 180 degrees")]
[JsonProperty(PropertyName="tilt_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TiltAngle { get; set; } = Double.Parse("180", CultureInfo.InvariantCulture);
        

[Description("If not Flat, should be Lower Left Corner (from outside)")]
[JsonProperty(PropertyName="starting_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingXCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_y_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingYCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingZCoordinate { get; set; } = null;
        

[Description("Along X Axis")]
[JsonProperty(PropertyName="length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Length { get; set; } = null;
        

[Description("Along Y Axis")]
[JsonProperty(PropertyName="width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Width { get; set; } = null;
    }
    
    [Description("Allows for detailed entry of subsurfaces (windows, doors, glass doors, tubular da" +
        "ylighting devices).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class FenestrationSurface_Detailed
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="surface_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public FenestrationSurface_Detailed_SurfaceType SurfaceType { get; set; } = (FenestrationSurface_Detailed_SurfaceType)Enum.Parse(typeof(FenestrationSurface_Detailed_SurfaceType), "Door");
        

[Description("To be matched with a construction in this input file")]
[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[JsonProperty(PropertyName="building_surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BuildingSurfaceName { get; set; } = "";
        

[Description(@"Non-blank only if base surface field Outside Boundary Condition is Surface or OtherSideCoefficients If Base Surface's Surface, specify name of corresponding subsurface in adjacent zone or specify current subsurface name for internal partition separating like zones If OtherSideCoefficients, specify name of SurfaceProperty:OtherSideCoefficients or leave blank to inherit Base Surface's OtherSide Coefficients")]
[JsonProperty(PropertyName="outside_boundary_condition_object", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutsideBoundaryConditionObject { get; set; } = "";
        

[Description(@"From the exterior of the surface Unused if one uses the ""reflections"" options in Solar Distribution in Building input unless a DaylightingDevice:Shelf or DaylightingDevice:Tubular object has been specified. autocalculate will automatically calculate this value from the tilt of the surface")]
[JsonProperty(PropertyName="view_factor_to_ground", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> ViewFactorToGround { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Enter the name of a WindowProperty:FrameAndDivider object Used only for exterior windows (rectangular) and glass doors. Unused for triangular windows. If not specified (blank), window or glass door has no frame or divider and no beam solar reflection from reveal surfaces.")]
[JsonProperty(PropertyName="frame_and_divider_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FrameAndDividerName { get; set; } = "";
        

[Description("Used only for Surface Type = WINDOW, GLASSDOOR or DOOR Non-integer values will be" +
    " truncated to integer")]
[JsonProperty(PropertyName="multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Multiplier { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description(@"vertices are given in GlobalGeometryRules coordinates -- if relative, all surface coordinates are ""relative"" to the Zone Origin. If world, then building and zone origins are used for some internal calculations, but all coordinates are given in an ""absolute"" system.")]
[JsonProperty(PropertyName="number_of_vertices", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> NumberOfVertices { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="vertex_1_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Vertex1XCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="vertex_1_y_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Vertex1YCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="vertex_1_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Vertex1ZCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="vertex_2_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Vertex2XCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="vertex_2_y_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Vertex2YCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="vertex_2_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Vertex2ZCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="vertex_3_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Vertex3XCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="vertex_3_y_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Vertex3YCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="vertex_3_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Vertex3ZCoordinate { get; set; } = null;
        

[Description("Not used for triangles")]
[JsonProperty(PropertyName="vertex_4_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Vertex4XCoordinate { get; set; } = null;
        

[Description("Not used for triangles")]
[JsonProperty(PropertyName="vertex_4_y_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Vertex4YCoordinate { get; set; } = null;
        

[Description("Not used for triangles")]
[JsonProperty(PropertyName="vertex_4_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Vertex4ZCoordinate { get; set; } = null;
    }
    
    public enum FenestrationSurface_Detailed_SurfaceType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Door")]
        Door = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="GlassDoor")]
        GlassDoor = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDiffuser")]
        TubularDaylightDiffuser = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDome")]
        TubularDaylightDome = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Window")]
        Window = 4,
    }
    
    [Description("Allows for simplified entry of Windows.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Window
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("To be matched with a construction in this input file")]
[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("Name of Surface (Wall, usually) the Window is on (i.e., Base Surface) Window assu" +
    "mes the azimuth and tilt angles of the surface it is on.")]
[JsonProperty(PropertyName="building_surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BuildingSurfaceName { get; set; } = "";
        

[Description(@"Enter the name of a WindowProperty:FrameAndDivider object Used only for exterior windows (rectangular) and glass doors. Unused for triangular windows. If not specified (blank), window or glass door has no frame or divider and no beam solar reflection from reveal surfaces.")]
[JsonProperty(PropertyName="frame_and_divider_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FrameAndDividerName { get; set; } = "";
        

[Description("Used only for Surface Type = WINDOW, GLASSDOOR or DOOR Non-integer values will be" +
    " truncated to integer")]
[JsonProperty(PropertyName="multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Multiplier { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Window starting coordinate is specified relative to the Base Surface origin.")]
[JsonProperty(PropertyName="starting_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingXCoordinate { get; set; } = null;
        

[Description("How far up the wall the Window starts. (in 2-d, this would be a Y Coordinate)")]
[JsonProperty(PropertyName="starting_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingZCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Length { get; set; } = null;
        

[JsonProperty(PropertyName="height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Height { get; set; } = null;
    }
    
    [Description("Allows for simplified entry of opaque Doors.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Door
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("To be matched with a construction in this input file")]
[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("Name of Surface (Wall, usually) the Door is on (i.e., Base Surface) Door assumes " +
    "the azimuth and tilt angles of the surface it is on.")]
[JsonProperty(PropertyName="building_surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BuildingSurfaceName { get; set; } = "";
        

[Description("Used only for Surface Type = WINDOW, GLASSDOOR or DOOR Non-integer values will be" +
    " truncated to integer")]
[JsonProperty(PropertyName="multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Multiplier { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Door starting coordinate is specified relative to the Base Surface origin.")]
[JsonProperty(PropertyName="starting_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingXCoordinate { get; set; } = null;
        

[Description("How far up the wall the Door starts. (in 2-d, this would be a Y Coordinate)")]
[JsonProperty(PropertyName="starting_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingZCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Length { get; set; } = null;
        

[JsonProperty(PropertyName="height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Height { get; set; } = null;
    }
    
    [Description("Allows for simplified entry of glass Doors.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GlazedDoor
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("To be matched with a construction in this input file")]
[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("Name of Surface (Wall, usually) the Door is on (i.e., Base Surface) Door assumes " +
    "the azimuth and tilt angles of the surface it is on.")]
[JsonProperty(PropertyName="building_surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BuildingSurfaceName { get; set; } = "";
        

[Description(@"Enter the name of a WindowProperty:FrameAndDivider object Used only for exterior windows (rectangular) and glass doors. Unused for triangular windows. If not specified (blank), window or glass door has no frame or divider and no beam solar reflection from reveal surfaces.")]
[JsonProperty(PropertyName="frame_and_divider_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FrameAndDividerName { get; set; } = "";
        

[Description("Used only for Surface Type = WINDOW, GLASSDOOR or DOOR Non-integer values will be" +
    " truncated to integer")]
[JsonProperty(PropertyName="multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Multiplier { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Door starting coordinate is specified relative to the Base Surface origin.")]
[JsonProperty(PropertyName="starting_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingXCoordinate { get; set; } = null;
        

[Description("How far up the wall the Door starts. (in 2-d, this would be a Y Coordinate)")]
[JsonProperty(PropertyName="starting_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingZCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Length { get; set; } = null;
        

[JsonProperty(PropertyName="height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Height { get; set; } = null;
    }
    
    [Description("Allows for simplified entry of interzone windows (adjacent to other zones).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Window_Interzone
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("To be matched with a construction in this input file")]
[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("Name of Surface (Wall, usually) the Window is on (i.e., Base Surface) Window assu" +
    "mes the azimuth and tilt angles of the surface it is on.")]
[JsonProperty(PropertyName="building_surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BuildingSurfaceName { get; set; } = "";
        

[Description(@"Specify a surface name in an adjacent zone for known interior windows. Specify a zone name of an adjacent zone to automatically generate the interior window in the adjacent zone. a blank field will set up a Window in an adjacent zone (same zone as adjacent to base surface)")]
[JsonProperty(PropertyName="outside_boundary_condition_object", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutsideBoundaryConditionObject { get; set; } = "";
        

[Description("Used only for Surface Type = WINDOW, GLASSDOOR or DOOR Non-integer values will be" +
    " truncated to integer")]
[JsonProperty(PropertyName="multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Multiplier { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Window starting coordinate is specified relative to the Base Surface origin.")]
[JsonProperty(PropertyName="starting_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingXCoordinate { get; set; } = null;
        

[Description("How far up the wall the Window starts. (in 2-d, this would be a Y Coordinate)")]
[JsonProperty(PropertyName="starting_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingZCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Length { get; set; } = null;
        

[JsonProperty(PropertyName="height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Height { get; set; } = null;
    }
    
    [Description("Allows for simplified entry of interzone (opaque interior) doors (adjacent to oth" +
        "er zones).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Door_Interzone
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("To be matched with a construction in this input file")]
[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("Name of Surface (Wall, usually) the Door is on (i.e., Base Surface) Door assumes " +
    "the azimuth and tilt angles of the surface it is on.")]
[JsonProperty(PropertyName="building_surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BuildingSurfaceName { get; set; } = "";
        

[Description(@"Specify a surface name in an adjacent zone for known interior doors. Specify a zone name of an adjacent zone to automatically generate the interior door in the adjacent zone. a blank field will set up a Window in an adjacent zone (same zone as adjacent to base surface)")]
[JsonProperty(PropertyName="outside_boundary_condition_object", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutsideBoundaryConditionObject { get; set; } = "";
        

[Description("Used only for Surface Type = WINDOW, GLASSDOOR or DOOR Non-integer values will be" +
    " truncated to integer")]
[JsonProperty(PropertyName="multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Multiplier { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Door starting coordinate is specified relative to the Base Surface origin.")]
[JsonProperty(PropertyName="starting_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingXCoordinate { get; set; } = null;
        

[Description("How far up the wall the Door starts. (in 2-d, this would be a Y Coordinate)")]
[JsonProperty(PropertyName="starting_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingZCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Length { get; set; } = null;
        

[JsonProperty(PropertyName="height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Height { get; set; } = null;
    }
    
    [Description("Allows for simplified entry of interzone (glass interior) doors (adjacent to othe" +
        "r zones).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GlazedDoor_Interzone
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("To be matched with a construction in this input file")]
[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("Name of Surface (Wall, usually) the Door is on (i.e., Base Surface) Door assumes " +
    "the azimuth and tilt angles of the surface it is on.")]
[JsonProperty(PropertyName="building_surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BuildingSurfaceName { get; set; } = "";
        

[Description(@"Specify a surface name in an adjacent zone for known interior doors. Specify a zone name of an adjacent zone to automatically generate the interior door in the adjacent zone. a blank field will set up a Window in an adjacent zone (same zone as adjacent to base surface)")]
[JsonProperty(PropertyName="outside_boundary_condition_object", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutsideBoundaryConditionObject { get; set; } = "";
        

[Description("Used only for Surface Type = WINDOW, GLASSDOOR or DOOR Non-integer values will be" +
    " truncated to integer")]
[JsonProperty(PropertyName="multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Multiplier { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Door starting coordinate is specified relative to the Base Surface origin.")]
[JsonProperty(PropertyName="starting_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingXCoordinate { get; set; } = null;
        

[Description("How far up the wall the Door starts. (in 2-d, this would be a Y Coordinate)")]
[JsonProperty(PropertyName="starting_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingZCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Length { get; set; } = null;
        

[JsonProperty(PropertyName="height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Height { get; set; } = null;
    }
    
    [Description("Specifies the type, location, and controls for window shades, window blinds, and " +
        "switchable glazing. Referencing the surface objects for exterior windows and gla" +
        "ss doors (ref: FenestrationSurface:Detailed, Window, and GlazedDoor).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowShadingControl
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description(@"If multiple WindowShadingControl objects are used than the order that they deploy the window shades can be set with this field. The first WindowShadingControl should be 1 and subsequent WindowShadingControl should 2 or 3 or higher. This is usually used when the Multiple Surface Control Type field is set to Group and groups of windows are being controlled in a certain order.")]
[JsonProperty(PropertyName="shading_control_sequence_number", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ShadingControlSequenceNumber { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="shading_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowShadingControl_ShadingType ShadingType { get; set; } = (WindowShadingControl_ShadingType)Enum.Parse(typeof(WindowShadingControl_ShadingType), "BetweenGlassBlind");
        

[Description(@"Required if Shading Type = SwitchableGlazing Required if Shading Type = interior or exterior shade or blind, or exterior screen, and ""Shading Device Material Name"" is not specified. If both ""Construction with Shading Name"" and ""Shading Device Material Name"" are entered, the former takes precedence.")]
[JsonProperty(PropertyName="construction_with_shading_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionWithShadingName { get; set; } = "";
        

[Description(@"OnIfScheduleAllows requires that Schedule Name be specified and Shading Control Is Scheduled = Yes. AlwaysOn, AlwaysOff and OnIfScheduleAllows are the only valid control types for ExteriorScreen. The following six control types are used primarily to reduce zone cooling load due to window solar gain Following entry should be used only if Shading Type = SwitchableGlazing and window is in a daylit zone The following three control types are used to reduce zone Heating load. They can be used with any Shading Type but are most appropriate for opaque interior or exterior shades with high insulating value (""opaque movable insulation"") The following two control types are used to reduce zone heating and cooling load. They can be used with any Shading Type but are most appropriate for translucent interior or exterior shades with high insulating value (""translucent movable insulation"") The following two control types are used to reduce zone Cooling load. They can be used with any Shading Type but are most appropriate for interior or exterior blinds,interior or exterior shades with low insulating value, or switchable glazing The following four control types require that both Setpoint and Setpoint2 be specified Setpoint will correspond to outdoor air temp or zone air temp (deg C) Setpoint2 will correspond to solar on window or horizontal solar (W/m2)")]
[JsonProperty(PropertyName="shading_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowShadingControl_ShadingControlType ShadingControlType { get; set; } = (WindowShadingControl_ShadingControlType)Enum.Parse(typeof(WindowShadingControl_ShadingControlType), "AlwaysOff");
        

[Description(@"Required if Shading Control Is Scheduled = Yes. If schedule value = 1, shading control is active, i.e., shading can take place only if the control test passes. If schedule value = 0, shading is off whether or not the control test passes. Schedule Name is required if Shading Control Is Scheduled = Yes. If Schedule Name is not specified, shading control is assumed to be active at all times.")]
[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[Description("W/m2 for solar-based controls, W for cooling- or heating-based controls, deg C fo" +
    "r temperature-based controls. Unused for Shading Control Type = AlwaysOn, Always" +
    "Off, OnIfScheduleAllows, OnIfHighGlare, Glare, and DaylightIlluminance")]
[JsonProperty(PropertyName="setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Setpoint { get; set; } = null;
        

[Description("If Yes, Schedule Name is required; if No, Schedule Name is not used. Shading Cont" +
    "rol Is Scheduled = Yes is required if Shading Control Type = OnIfScheduleAllows." +
    "")]
[JsonProperty(PropertyName="shading_control_is_scheduled", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes ShadingControlIsScheduled { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description(@"If Yes and window is in a daylit zone, shading is on if zone's discomfort glare index exceeds the maximum discomfort glare index specified in the Daylighting object referenced by the zone. The glare test is OR'ed with the test specified by Shading Control Type. Glare Control Is Active = Yes is required if Shading Control Type = OnIfHighGlare.")]
[JsonProperty(PropertyName="glare_control_is_active", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes GlareControlIsActive { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description(@"Enter the name of a WindowMaterial:Shade, WindowMaterial:Screen or WindowMaterial:Blind object. Required if ""Construction with Shading Name"" is not specified. Not used if Shading Control Type = SwitchableGlazing, BetweenGlassShade, or BetweenGlassBlind. If both ""Construction with Shading Name"" and ""Shading Device Material Name"" are entered, the former takes precedence.")]
[JsonProperty(PropertyName="shading_device_material_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ShadingDeviceMaterialName { get; set; } = "";
        

[Description("Used only if Shading Type = InteriorBlind, ExteriorBlind or BetweenGlassBlind. If" +
    " choice is ScheduledSlatAngle then Slat Angle Schedule Name is required.")]
[JsonProperty(PropertyName="type_of_slat_angle_control_for_blinds", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowShadingControl_TypeOfSlatAngleControlForBlinds TypeOfSlatAngleControlForBlinds { get; set; } = (WindowShadingControl_TypeOfSlatAngleControlForBlinds)Enum.Parse(typeof(WindowShadingControl_TypeOfSlatAngleControlForBlinds), "FixedSlatAngle");
        

[Description("Used only if Shading Type = InteriorBlind, ExteriorBlind or BetweenGlassBlind. Re" +
    "quired if Type of Slat Angle Control for Blinds = ScheduledSlatAngle Schedule va" +
    "lues should be degrees (0 minimum, 180 maximum)")]
[JsonProperty(PropertyName="slat_angle_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SlatAngleScheduleName { get; set; } = "";
        

[Description(@"W/m2 for solar-based controls, deg C for temperature-based controls. Used only as the second setpoint for the following two-setpoint control types: OnIfHighOutdoorAirTempAndHighSolarOnWindow, OnIfHighOutdoorAirTempAndHighHorizontalSolar, OnIfHighZoneAirTempAndHighSolarOnWindow, and OnIfHighZoneAirTempAndHighHorizontalSolar")]
[JsonProperty(PropertyName="setpoint_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Setpoint2 { get; set; } = null;
        

[Description("Reference to the Daylighting:Controls object that provides the glare and illumina" +
    "nce control to the zone.")]
[JsonProperty(PropertyName="daylighting_control_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DaylightingControlObjectName { get; set; } = "";
        

[Description(@"When Sequential is used the list of fenestration surfaces are controlled individually in the order specified When Group is used the entire list is controlled simultaneously and if glare control is needed the entire group of window shades are deployed together a the same time")]
[JsonProperty(PropertyName="multiple_surface_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowShadingControl_MultipleSurfaceControlType MultipleSurfaceControlType { get; set; } = (WindowShadingControl_MultipleSurfaceControlType)Enum.Parse(typeof(WindowShadingControl_MultipleSurfaceControlType), "Sequential");
        

[Description("This list is the GlazedExtSubSurfNames object-list")]
[JsonProperty(PropertyName="fenestration_surfaces", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> FenestrationSurfaces { get; set; } = null;
    }
    
    public enum WindowShadingControl_ShadingType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="BetweenGlassBlind")]
        BetweenGlassBlind = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BetweenGlassShade")]
        BetweenGlassShade = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ExteriorBlind")]
        ExteriorBlind = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ExteriorScreen")]
        ExteriorScreen = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ExteriorShade")]
        ExteriorShade = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="InteriorBlind")]
        InteriorBlind = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="InteriorShade")]
        InteriorShade = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="SwitchableGlazing")]
        SwitchableGlazing = 7,
    }
    
    public enum WindowShadingControl_ShadingControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AlwaysOff")]
        AlwaysOff = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlwaysOn")]
        AlwaysOn = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="MeetDaylightIlluminanceSetpoint")]
        MeetDaylightIlluminanceSetpoint = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="OffNightAndOnDayIfCoolingAndHighSolarOnWindow")]
        OffNightAndOnDayIfCoolingAndHighSolarOnWindow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="OnIfHighGlare")]
        OnIfHighGlare = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="OnIfHighHorizontalSolar")]
        OnIfHighHorizontalSolar = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="OnIfHighOutdoorAirTempAndHighHorizontalSolar")]
        OnIfHighOutdoorAirTempAndHighHorizontalSolar = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="OnIfHighOutdoorAirTempAndHighSolarOnWindow")]
        OnIfHighOutdoorAirTempAndHighSolarOnWindow = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="OnIfHighOutdoorAirTemperature")]
        OnIfHighOutdoorAirTemperature = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="OnIfHighSolarOnWindow")]
        OnIfHighSolarOnWindow = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="OnIfHighZoneAirTempAndHighHorizontalSolar")]
        OnIfHighZoneAirTempAndHighHorizontalSolar = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="OnIfHighZoneAirTempAndHighSolarOnWindow")]
        OnIfHighZoneAirTempAndHighSolarOnWindow = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="OnIfHighZoneAirTemperature")]
        OnIfHighZoneAirTemperature = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="OnIfHighZoneCooling")]
        OnIfHighZoneCooling = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="OnIfScheduleAllows")]
        OnIfScheduleAllows = 14,
        
        [System.Runtime.Serialization.EnumMember(Value="OnNightAndOnDayIfCoolingAndHighSolarOnWindow")]
        OnNightAndOnDayIfCoolingAndHighSolarOnWindow = 15,
        
        [System.Runtime.Serialization.EnumMember(Value="OnNightIfHeatingAndOffDay")]
        OnNightIfHeatingAndOffDay = 16,
        
        [System.Runtime.Serialization.EnumMember(Value="OnNightIfHeatingAndOnDayIfCooling")]
        OnNightIfHeatingAndOnDayIfCooling = 17,
        
        [System.Runtime.Serialization.EnumMember(Value="OnNightIfLowInsideTempAndOffDay")]
        OnNightIfLowInsideTempAndOffDay = 18,
        
        [System.Runtime.Serialization.EnumMember(Value="OnNightIfLowOutdoorTempAndOffDay")]
        OnNightIfLowOutdoorTempAndOffDay = 19,
        
        [System.Runtime.Serialization.EnumMember(Value="OnNightIfLowOutdoorTempAndOnDayIfCooling")]
        OnNightIfLowOutdoorTempAndOnDayIfCooling = 20,
    }
    
    public enum WindowShadingControl_TypeOfSlatAngleControlForBlinds
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlockBeamSolar")]
        BlockBeamSolar = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedSlatAngle")]
        FixedSlatAngle = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ScheduledSlatAngle")]
        ScheduledSlatAngle = 3,
    }
    
    public enum WindowShadingControl_MultipleSurfaceControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Group")]
        Group = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Sequential")]
        Sequential = 2,
    }
    
    [Description("Specifies the dimensions of a window frame, dividers, and inside reveal surfaces." +
        " Referenced by the surface objects for exterior windows and glass doors (ref: Fe" +
        "nestrationSurface:Detailed, Window, and GlazedDoor).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowProperty_FrameAndDivider
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Width of frame in plane of window Frame width assumed the same on all sides of wi" +
    "ndow")]
[JsonProperty(PropertyName="frame_width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrameWidth { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Amount that frame projects outward from the outside face of the glazing")]
[JsonProperty(PropertyName="frame_outside_projection", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrameOutsideProjection { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Amount that frame projects inward from the inside face of the glazing")]
[JsonProperty(PropertyName="frame_inside_projection", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrameInsideProjection { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Effective conductance of frame Excludes air films Obtained from WINDOW 5 or other" +
    " 2-D calculation")]
[JsonProperty(PropertyName="frame_conductance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrameConductance { get; set; } = null;
        

[Description("Excludes air films; applies only to multipane windows Obtained from WINDOW 5 or o" +
    "ther 2-D calculation")]
[JsonProperty(PropertyName="ratio_of_frame_edge_glass_conductance_to_center_of_glass_conductance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatioOfFrameEdgeGlassConductanceToCenterOfGlassConductance { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Assumed same on outside and inside of frame")]
[JsonProperty(PropertyName="frame_solar_absorptance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrameSolarAbsorptance { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[Description("Assumed same on outside and inside of frame")]
[JsonProperty(PropertyName="frame_visible_absorptance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrameVisibleAbsorptance { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[Description("Assumed same on outside and inside of frame")]
[JsonProperty(PropertyName="frame_thermal_hemispherical_emissivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrameThermalHemisphericalEmissivity { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="divider_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowProperty_FrameAndDivider_DividerType DividerType { get; set; } = (WindowProperty_FrameAndDivider_DividerType)Enum.Parse(typeof(WindowProperty_FrameAndDivider_DividerType), "DividedLite");
        

[Description("Width of dividers in plane of window Width assumed the same for all dividers")]
[JsonProperty(PropertyName="divider_width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DividerWidth { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("\"Horizontal\" means parallel to local window X-axis")]
[JsonProperty(PropertyName="number_of_horizontal_dividers", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfHorizontalDividers { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("\"Vertical\" means parallel to local window Y-axis")]
[JsonProperty(PropertyName="number_of_vertical_dividers", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfVerticalDividers { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Amount that divider projects outward from the outside face of the glazing Outside" +
    " projection assumed the same for all divider elements")]
[JsonProperty(PropertyName="divider_outside_projection", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DividerOutsideProjection { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Amount that divider projects inward from the inside face of the glazing Inside pr" +
    "ojection assumed the same for all divider elements")]
[JsonProperty(PropertyName="divider_inside_projection", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DividerInsideProjection { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Effective conductance of divider Excludes air films Obtained from WINDOW 5 or oth" +
    "er 2-D calculation")]
[JsonProperty(PropertyName="divider_conductance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DividerConductance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Excludes air films Obtained from WINDOW 5 or other 2-D calculation")]
[JsonProperty(PropertyName="ratio_of_divider_edge_glass_conductance_to_center_of_glass_conductance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatioOfDividerEdgeGlassConductanceToCenterOfGlassConductance { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Assumed same on outside and inside of divider")]
[JsonProperty(PropertyName="divider_solar_absorptance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DividerSolarAbsorptance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Assumed same on outside and inside of divider")]
[JsonProperty(PropertyName="divider_visible_absorptance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DividerVisibleAbsorptance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Assumed same on outside and inside of divider")]
[JsonProperty(PropertyName="divider_thermal_hemispherical_emissivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DividerThermalHemisphericalEmissivity { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="outside_reveal_solar_absorptance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutsideRevealSolarAbsorptance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="inside_sill_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InsideSillDepth { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="inside_sill_solar_absorptance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InsideSillSolarAbsorptance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description(@"Distance from plane of inside surface of glazing to plane of inside surface of wall. Outside reveal depth is determined from the geometry of the window and the wall it is on; it is non-zero if the plane of the outside surface of the glazing is set back from the plane of the outside surface of the wall.")]
[JsonProperty(PropertyName="inside_reveal_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InsideRevealDepth { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="inside_reveal_solar_absorptance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InsideRevealSolarAbsorptance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    public enum WindowProperty_FrameAndDivider_DividerType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DividedLite")]
        DividedLite = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Suspended")]
        Suspended = 2,
    }
    
    [Description("Used to control forced airflow through a gap between glass layers")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowProperty_AirflowControl
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="airflow_source", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowProperty_AirflowControl_AirflowSource AirflowSource { get; set; } = (WindowProperty_AirflowControl_AirflowSource)Enum.Parse(typeof(WindowProperty_AirflowControl_AirflowSource), "IndoorAir");
        

[Description("If ReturnAir is selected, the name of the Return Air Node may be specified below." +
    "")]
[JsonProperty(PropertyName="airflow_destination", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowProperty_AirflowControl_AirflowDestination AirflowDestination { get; set; } = (WindowProperty_AirflowControl_AirflowDestination)Enum.Parse(typeof(WindowProperty_AirflowControl_AirflowDestination), "OutdoorAir");
        

[Description("Above is m3/s per m of glazing width")]
[JsonProperty(PropertyName="maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumFlowRate { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("ScheduledOnly requires that Airflow Has Multiplier Schedule Name = Yes and that A" +
    "irflow Multiplier Schedule Name is specified.")]
[JsonProperty(PropertyName="airflow_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowProperty_AirflowControl_AirflowControlType AirflowControlType { get; set; } = (WindowProperty_AirflowControl_AirflowControlType)Enum.Parse(typeof(WindowProperty_AirflowControl_AirflowControlType), "AlwaysOnAtMaximumFlow");
        

[Description("If Yes, then Airflow Multiplier Schedule Name must be specified")]
[JsonProperty(PropertyName="airflow_is_scheduled", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes AirflowIsScheduled { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("Required if Airflow Is Scheduled = Yes. Schedule values are 0.0 or 1.0 and multip" +
    "ly Maximum Air Flow.")]
[JsonProperty(PropertyName="airflow_multiplier_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirflowMultiplierScheduleName { get; set; } = "";
        

[Description("Name of the return air node for this airflow window if the Airflow Destination is" +
    " ReturnAir. If left blank, defaults to the first return air node for the zone of" +
    " the window surface.")]
[JsonProperty(PropertyName="airflow_return_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirflowReturnAirNodeName { get; set; } = "";
    }
    
    public enum WindowProperty_AirflowControl_AirflowSource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="IndoorAir")]
        IndoorAir = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAir")]
        OutdoorAir = 2,
    }
    
    public enum WindowProperty_AirflowControl_AirflowDestination
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="IndoorAir")]
        IndoorAir = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorAir")]
        OutdoorAir = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ReturnAir")]
        ReturnAir = 3,
    }
    
    public enum WindowProperty_AirflowControl_AirflowControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AlwaysOff")]
        AlwaysOff = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AlwaysOnAtMaximumFlow")]
        AlwaysOnAtMaximumFlow = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ScheduledOnly")]
        ScheduledOnly = 3,
    }
    
    [Description("This is a movable exterior glass layer that is usually applied in the winter and " +
        "removed in the summer.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowProperty_StormWindow
    {
        

[Description("Must be the name of a FenestrationSurface:Detailed object with Surface Type = WIN" +
    "DOW. The WindowProperty:StormWindow object can only be used with exterior window" +
    "s.")]
[JsonProperty(PropertyName="window_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WindowName { get; set; } = "";
        

[Description("Must be a WindowMaterial:Glazing or WindowMaterial:Glazing:RefractionExtinctionMe" +
    "thod Gap between storm glass layer and adjacent glass layer is assumed to be fil" +
    "led with Air")]
[JsonProperty(PropertyName="storm_glass_layer_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string StormGlassLayerName { get; set; } = "";
        

[JsonProperty(PropertyName="distance_between_storm_glass_layer_and_adjacent_glass", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistanceBetweenStormGlassLayerAndAdjacentGlass { get; set; } = Double.Parse("0.05", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="month_that_storm_glass_layer_is_put_on", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MonthThatStormGlassLayerIsPutOn { get; set; } = null;
        

[JsonProperty(PropertyName="day_of_month_that_storm_glass_layer_is_put_on", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DayOfMonthThatStormGlassLayerIsPutOn { get; set; } = null;
        

[JsonProperty(PropertyName="month_that_storm_glass_layer_is_taken_off", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MonthThatStormGlassLayerIsTakenOff { get; set; } = null;
        

[JsonProperty(PropertyName="day_of_month_that_storm_glass_layer_is_taken_off", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DayOfMonthThatStormGlassLayerIsTakenOff { get; set; } = null;
    }
    
    [Description(@"Used to describe internal zone surface area that does not need to be part of geometric representation. This should be the total surface area exposed to the zone air. If you use a ZoneList in the Zone or ZoneList name field then this definition applies to all the zones in the ZoneList.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class InternalMass
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("To be matched with a construction in this input file")]
[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("Zone the surface is a part of used to be Interior Environment")]
[JsonProperty(PropertyName="zone_or_zonelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneOrZonelistName { get; set; } = "";
        

[JsonProperty(PropertyName="surface_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SurfaceArea { get; set; } = null;
    }
    
    [Description("used for shading elements such as trees these items are fixed in space and would " +
        "not move with relative geometry")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Shading_Site
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Facing direction of outside of shading device (S=180,N=0,E=90,W=270)")]
[JsonProperty(PropertyName="azimuth_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AzimuthAngle { get; set; } = null;
        

[JsonProperty(PropertyName="tilt_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TiltAngle { get; set; } = Double.Parse("90", CultureInfo.InvariantCulture);
        

[Description("Starting coordinate is the Lower Left Corner of the Shade")]
[JsonProperty(PropertyName="starting_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingXCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_y_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingYCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingZCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Length { get; set; } = null;
        

[JsonProperty(PropertyName="height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Height { get; set; } = null;
    }
    
    [Description("used for shading elements such as trees, other buildings, parts of this building " +
        "not being modeled these items are relative to the current building and would mov" +
        "e with relative geometry")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Shading_Building
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Facing direction of outside of shading device (S=180,N=0,E=90,W=270)")]
[JsonProperty(PropertyName="azimuth_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AzimuthAngle { get; set; } = null;
        

[JsonProperty(PropertyName="tilt_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TiltAngle { get; set; } = Double.Parse("90", CultureInfo.InvariantCulture);
        

[Description("Starting coordinate is the Lower Left Corner of the Shade")]
[JsonProperty(PropertyName="starting_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingXCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_y_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingYCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="starting_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartingZCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Length { get; set; } = null;
        

[JsonProperty(PropertyName="height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Height { get; set; } = null;
    }
    
    [Description("used for shading elements such as trees these items are fixed in space and would " +
        "not move with relative geometry")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Shading_Site_Detailed
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Transmittance schedule for the shading device, defaults to zero (always opaque)")]
[JsonProperty(PropertyName="transmittance_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TransmittanceScheduleName { get; set; } = "";
        

[Description("shown with 6 vertex coordinates -- extensible object Rules for vertices are given" +
    " in GlobalGeometryRules coordinates -- For this object all surface coordinates a" +
    "re in world coordinates.")]
[JsonProperty(PropertyName="number_of_vertices", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> NumberOfVertices { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="vertices", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Shading_Site_Detailed_Vertices_Item> Vertices { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Shading_Site_Detailed_Vertices_Item
    {
        

[JsonProperty(PropertyName="vertex_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VertexXCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="vertex_y_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VertexYCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="vertex_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VertexZCoordinate { get; set; } = null;
    }
    
    [Description("used for shading elements such as trees, other buildings, parts of this building " +
        "not being modeled these items are relative to the current building and would mov" +
        "e with relative geometry")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Shading_Building_Detailed
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Transmittance schedule for the shading device, defaults to zero (always opaque)")]
[JsonProperty(PropertyName="transmittance_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TransmittanceScheduleName { get; set; } = "";
        

[Description("shown with 6 vertex coordinates -- extensible object Rules for vertices are given" +
    " in GlobalGeometryRules coordinates -- For this object all surface coordinates a" +
    "re relative to the building origin (0,0,0) and will rotate with the BUILDING nor" +
    "th axis.")]
[JsonProperty(PropertyName="number_of_vertices", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> NumberOfVertices { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="vertices", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Shading_Building_Detailed_Vertices_Item> Vertices { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Shading_Building_Detailed_Vertices_Item
    {
        

[JsonProperty(PropertyName="vertex_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VertexXCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="vertex_y_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VertexYCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="vertex_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VertexZCoordinate { get; set; } = null;
    }
    
    [Description("Overhangs are usually flat shading surfaces that reference a window or door.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Shading_Overhang
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="window_or_door_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WindowOrDoorName { get; set; } = "";
        

[JsonProperty(PropertyName="height_above_window_or_door", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeightAboveWindowOrDoor { get; set; } = null;
        

[JsonProperty(PropertyName="tilt_angle_from_window_door", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TiltAngleFromWindowDoor { get; set; } = Double.Parse("90", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="left_extension_from_window_door_width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LeftExtensionFromWindowDoorWidth { get; set; } = null;
        

[Description("N3 + N4 + Window/Door Width is Overhang Length")]
[JsonProperty(PropertyName="right_extension_from_window_door_width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RightExtensionFromWindowDoorWidth { get; set; } = null;
        

[JsonProperty(PropertyName="depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Depth { get; set; } = null;
    }
    
    [Description("Overhangs are typically flat shading surfaces that reference a window or door.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Shading_Overhang_Projection
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="window_or_door_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WindowOrDoorName { get; set; } = "";
        

[JsonProperty(PropertyName="height_above_window_or_door", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeightAboveWindowOrDoor { get; set; } = null;
        

[JsonProperty(PropertyName="tilt_angle_from_window_door", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TiltAngleFromWindowDoor { get; set; } = Double.Parse("90", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="left_extension_from_window_door_width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LeftExtensionFromWindowDoorWidth { get; set; } = null;
        

[Description("N3 + N4 + Window/Door Width is Overhang Length")]
[JsonProperty(PropertyName="right_extension_from_window_door_width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RightExtensionFromWindowDoorWidth { get; set; } = null;
        

[JsonProperty(PropertyName="depth_as_fraction_of_window_door_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DepthAsFractionOfWindowDoorHeight { get; set; } = null;
    }
    
    [Description("Fins are usually shading surfaces that are perpendicular to a window or door.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Shading_Fin
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="window_or_door_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WindowOrDoorName { get; set; } = "";
        

[JsonProperty(PropertyName="left_extension_from_window_door", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LeftExtensionFromWindowDoor { get; set; } = null;
        

[JsonProperty(PropertyName="left_distance_above_top_of_window", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LeftDistanceAboveTopOfWindow { get; set; } = null;
        

[Description("N2 + N3 + height of Window/Door is height of Fin")]
[JsonProperty(PropertyName="left_distance_below_bottom_of_window", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LeftDistanceBelowBottomOfWindow { get; set; } = null;
        

[JsonProperty(PropertyName="left_tilt_angle_from_window_door", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LeftTiltAngleFromWindowDoor { get; set; } = Double.Parse("90", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="left_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LeftDepth { get; set; } = null;
        

[JsonProperty(PropertyName="right_extension_from_window_door", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RightExtensionFromWindowDoor { get; set; } = null;
        

[JsonProperty(PropertyName="right_distance_above_top_of_window", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RightDistanceAboveTopOfWindow { get; set; } = null;
        

[Description("N7 + N8 + height of Window/Door is height of Fin")]
[JsonProperty(PropertyName="right_distance_below_bottom_of_window", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RightDistanceBelowBottomOfWindow { get; set; } = null;
        

[JsonProperty(PropertyName="right_tilt_angle_from_window_door", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RightTiltAngleFromWindowDoor { get; set; } = Double.Parse("90", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="right_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RightDepth { get; set; } = null;
    }
    
    [Description("Fins are usually shading surfaces that are perpendicular to a window or door.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Shading_Fin_Projection
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="window_or_door_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WindowOrDoorName { get; set; } = "";
        

[JsonProperty(PropertyName="left_extension_from_window_door", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LeftExtensionFromWindowDoor { get; set; } = null;
        

[JsonProperty(PropertyName="left_distance_above_top_of_window", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LeftDistanceAboveTopOfWindow { get; set; } = null;
        

[Description("N2 + N3 + height of Window/Door is height of Fin")]
[JsonProperty(PropertyName="left_distance_below_bottom_of_window", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LeftDistanceBelowBottomOfWindow { get; set; } = null;
        

[JsonProperty(PropertyName="left_tilt_angle_from_window_door", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LeftTiltAngleFromWindowDoor { get; set; } = Double.Parse("90", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="left_depth_as_fraction_of_window_door_width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LeftDepthAsFractionOfWindowDoorWidth { get; set; } = null;
        

[JsonProperty(PropertyName="right_extension_from_window_door", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RightExtensionFromWindowDoor { get; set; } = null;
        

[JsonProperty(PropertyName="right_distance_above_top_of_window", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RightDistanceAboveTopOfWindow { get; set; } = null;
        

[Description("N7 + N8 + height of Window/Door is height of Fin")]
[JsonProperty(PropertyName="right_distance_below_bottom_of_window", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RightDistanceBelowBottomOfWindow { get; set; } = null;
        

[JsonProperty(PropertyName="right_tilt_angle_from_window_door", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RightTiltAngleFromWindowDoor { get; set; } = Double.Parse("90", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="right_depth_as_fraction_of_window_door_width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RightDepthAsFractionOfWindowDoorWidth { get; set; } = null;
    }
    
    [Description("used For fins, overhangs, elements that shade the building, are attached to the b" +
        "uilding but are not part of the heat transfer calculations")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Shading_Zone_Detailed
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="base_surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BaseSurfaceName { get; set; } = "";
        

[Description("Transmittance schedule for the shading device, defaults to zero (always opaque)")]
[JsonProperty(PropertyName="transmittance_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TransmittanceScheduleName { get; set; } = "";
        

[Description(@"shown with 6 vertex coordinates -- extensible object vertices are given in GlobalGeometryRules coordinates -- if relative, all surface coordinates are ""relative"" to the Zone Origin. if world, then building and zone origins are used for some internal calculations, but all coordinates are given in an ""absolute"" system.")]
[JsonProperty(PropertyName="number_of_vertices", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> NumberOfVertices { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="vertices", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Shading_Zone_Detailed_Vertices_Item> Vertices { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Shading_Zone_Detailed_Vertices_Item
    {
        

[JsonProperty(PropertyName="vertex_x_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VertexXCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="vertex_y_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VertexYCoordinate { get; set; } = null;
        

[JsonProperty(PropertyName="vertex_z_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VertexZCoordinate { get; set; } = null;
    }
    
    [Description("If this object is not defined for a shading surface the default values listed in " +
        "following fields will be used in the solar reflection calculation.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ShadingProperty_Reflectance
    {
        

[JsonProperty(PropertyName="shading_surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ShadingSurfaceName { get; set; } = "";
        

[JsonProperty(PropertyName="diffuse_solar_reflectance_of_unglazed_part_of_shading_surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DiffuseSolarReflectanceOfUnglazedPartOfShadingSurface { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="diffuse_visible_reflectance_of_unglazed_part_of_shading_surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DiffuseVisibleReflectanceOfUnglazedPartOfShadingSurface { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_of_shading_surface_that_is_glazed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfShadingSurfaceThatIsGlazed { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Required if Fraction of Shading Surface That Is Glazed > 0.0")]
[JsonProperty(PropertyName="glazing_construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string GlazingConstructionName { get; set; } = "";
    }
}
