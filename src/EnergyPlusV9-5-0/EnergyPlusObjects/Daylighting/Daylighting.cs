namespace EnergyPlus.Daylighting
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
    
    
    [Description("Dimming of overhead electric lighting is determined from each reference point. Gl" +
        "are from daylighting is also calculated.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Daylighting_Controls
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="daylighting_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Daylighting_Controls_DaylightingMethod DaylightingMethod { get; set; } = (Daylighting_Controls_DaylightingMethod)Enum.Parse(typeof(Daylighting_Controls_DaylightingMethod), "SplitFlux");
        

[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="lighting_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Daylighting_Controls_LightingControlType LightingControlType { get; set; } = (Daylighting_Controls_LightingControlType)Enum.Parse(typeof(Daylighting_Controls_LightingControlType), "Continuous");
        

[JsonProperty(PropertyName="minimum_input_power_fraction_for_continuous_or_continuousoff_dimming_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumInputPowerFractionForContinuousOrContinuousoffDimmingControl { get; set; } = Double.Parse("0.3", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_light_output_fraction_for_continuous_or_continuousoff_dimming_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumLightOutputFractionForContinuousOrContinuousoffDimmingControl { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[Description("The number of steps, excluding off, in a stepped lighting control system. If Ligh" +
    "ting Control Type is Stepped, this field must be greater than zero. The steps ar" +
    "e assumed to be equally spaced.")]
[JsonProperty(PropertyName="number_of_stepped_control_steps", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfSteppedControlSteps { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="probability_lighting_will_be_reset_when_needed_in_manual_stepped_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ProbabilityLightingWillBeResetWhenNeededInManualSteppedControl { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="glare_calculation_daylighting_reference_point_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string GlareCalculationDaylightingReferencePointName { get; set; } = "";
        

[JsonProperty(PropertyName="glare_calculation_azimuth_angle_of_view_direction_clockwise_from_zone_y_axis", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GlareCalculationAzimuthAngleOfViewDirectionClockwiseFromZoneYAxis { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("The default is for general office work")]
[JsonProperty(PropertyName="maximum_allowable_discomfort_glare_index", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumAllowableDiscomfortGlareIndex { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[Description(@"Maximum surface area for nodes in gridding all surfaces in the DElight zone. All reflective and transmitting surfaces will be subdivided into approximately square nodes that do not exceed this maximum. Higher resolution subdivisions require greater calculation times, but generally produce more accurate results.")]
[JsonProperty(PropertyName="delight_gridding_resolution", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DelightGriddingResolution { get; set; } = null;
        

[JsonProperty(PropertyName="control_data", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Daylighting.Daylighting_Controls_ControlData_Item> ControlData { get; set; } = null;
    }
    
    public enum Daylighting_Controls_DaylightingMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DElight")]
        DElight = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SplitFlux")]
        SplitFlux = 2,
    }
    
    public enum Daylighting_Controls_LightingControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Continuous")]
        Continuous = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ContinuousOff")]
        ContinuousOff = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Stepped")]
        Stepped = 3,
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Daylighting_Controls_ControlData_Item
    {
        

[JsonProperty(PropertyName="daylighting_reference_point_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DaylightingReferencePointName { get; set; } = "";
        

[JsonProperty(PropertyName="fraction_of_zone_controlled_by_reference_point", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfZoneControlledByReferencePoint { get; set; } = null;
        

[JsonProperty(PropertyName="illuminance_setpoint_at_reference_point", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> IlluminanceSetpointAtReferencePoint { get; set; } = null;
    }
    
    [Description("Used by Daylighting:Controls to identify the reference point coordinates for each" +
        " sensor. Reference points are given in coordinates specified in the GlobalGeomet" +
        "ryRules object Daylighting Reference Point CoordinateSystem field")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Daylighting_ReferencePoint
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="x_coordinate_of_reference_point", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> XCoordinateOfReferencePoint { get; set; } = null;
        

[JsonProperty(PropertyName="y_coordinate_of_reference_point", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> YCoordinateOfReferencePoint { get; set; } = null;
        

[JsonProperty(PropertyName="z_coordinate_of_reference_point", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZCoordinateOfReferencePoint { get; set; } = Double.Parse("0.8", CultureInfo.InvariantCulture);
    }
    
    [Description("Used for DElight Complex Fenestration of all types")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Daylighting_DELight_ComplexFenestration
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Used to select the appropriate Complex Fenestration BTDF data")]
[JsonProperty(PropertyName="complex_fenestration_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComplexFenestrationType { get; set; } = "";
        

[Description("This is a reference to a valid surface object (such as BuildingSurface:Detailed) " +
    "hosting this complex fenestration, analogous to the base surface Name field for " +
    "subsurfaces such as Windows.")]
[JsonProperty(PropertyName="building_surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BuildingSurfaceName { get; set; } = "";
        

[Description("This is a reference to a valid FenestrationSurface:Detailed window object used to" +
    " account for the geometry, and the solar and thermal gains/losses, of the Comple" +
    "x Fenestration")]
[JsonProperty(PropertyName="window_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WindowName { get; set; } = "";
        

[Description(@"In-plane counter-clockwise rotation angle of the Complex Fenestration optical reference direction and the base edge of the Complex Fenestration. The Rotation will typically be zero when the host and CFS surfaces are rectangular and height and width edges are aligned.")]
[JsonProperty(PropertyName="fenestration_rotation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FenestrationRotation { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    [Description("Defines a tubular daylighting device (TDD) consisting of three components: a dome" +
        ", a pipe, and a diffuser. The dome and diffuser are defined separately using the" +
        " FenestrationSurface:Detailed object.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class DaylightingDevice_Tubular
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("This must refer to a subsurface object of type TubularDaylightDome")]
[JsonProperty(PropertyName="dome_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DomeName { get; set; } = "";
        

[Description("This must refer to a subsurface object of type TubularDaylightDiffuser Delivery z" +
    "one is specified in the diffuser object")]
[JsonProperty(PropertyName="diffuser_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DiffuserName { get; set; } = "";
        

[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[JsonProperty(PropertyName="diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Diameter { get; set; } = null;
        

[Description("The exterior exposed length is the difference between total and sum of zone lengt" +
    "hs")]
[JsonProperty(PropertyName="total_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TotalLength { get; set; } = null;
        

[Description("R value between TubularDaylightDome and TubularDaylightDiffuser")]
[JsonProperty(PropertyName="effective_thermal_resistance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EffectiveThermalResistance { get; set; } = Double.Parse("0.28", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="transition_lengths", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Daylighting.DaylightingDevice_Tubular_TransitionLengths_Item> TransitionLengths { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class DaylightingDevice_Tubular_TransitionLengths_Item
    {
        

[JsonProperty(PropertyName="transition_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TransitionZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="transition_zone_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TransitionZoneLength { get; set; } = null;
    }
    
    [Description("Defines a daylighting which can have an inside shelf, an outside shelf, or both. " +
        "The inside shelf is defined as a building surface and the outside shelf is defin" +
        "ed as a shading surface.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class DaylightingDevice_Shelf
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="window_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WindowName { get; set; } = "";
        

[Description("This must refer to a BuildingSurface:Detailed or equivalent object This surface m" +
    "ust be its own Surface for other side boundary conditions.")]
[JsonProperty(PropertyName="inside_shelf_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InsideShelfName { get; set; } = "";
        

[Description("This must refer to a Shading:Zone:Detailed object")]
[JsonProperty(PropertyName="outside_shelf_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutsideShelfName { get; set; } = "";
        

[Description("Required if outside shelf is specified")]
[JsonProperty(PropertyName="outside_shelf_construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutsideShelfConstructionName { get; set; } = "";
        

[JsonProperty(PropertyName="view_factor_to_outside_shelf", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ViewFactorToOutsideShelf { get; set; } = null;
    }
    
    [Description("Applies only to exterior windows in daylighting-controlled zones or in zones that" +
        " share an interior window with a daylighting-controlled  zone. Generally used wi" +
        "th skylights.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class DaylightingDevice_LightWell
    {
        

[JsonProperty(PropertyName="exterior_window_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ExteriorWindowName { get; set; } = "";
        

[Description("Distance from Bottom of Window to Bottom of Well")]
[JsonProperty(PropertyName="height_of_well", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeightOfWell { get; set; } = null;
        

[JsonProperty(PropertyName="perimeter_of_bottom_of_well", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PerimeterOfBottomOfWell { get; set; } = null;
        

[JsonProperty(PropertyName="area_of_bottom_of_well", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AreaOfBottomOfWell { get; set; } = null;
        

[JsonProperty(PropertyName="visible_reflectance_of_well_walls", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VisibleReflectanceOfWellWalls { get; set; } = null;
    }
    
    [Description("Reports hourly daylight factors for each exterior window for four sky types (clea" +
        "r, turbid clear, intermediate, and overcast).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_DaylightFactors
    {
        

[JsonProperty(PropertyName="reporting_days", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_DaylightFactors_ReportingDays ReportingDays { get; set; } = (Output_DaylightFactors_ReportingDays)Enum.Parse(typeof(Output_DaylightFactors_ReportingDays), "AllShadowCalculationDays");
    }
    
    public enum Output_DaylightFactors_ReportingDays
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AllShadowCalculationDays")]
        AllShadowCalculationDays = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SizingDays")]
        SizingDays = 1,
    }
    
    [Description("reference points are given in coordinates specified in the GlobalGeometryRules ob" +
        "ject Daylighting Reference Point CoordinateSystem field")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_IlluminanceMap
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="z_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZHeight { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="x_minimum_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> XMinimumCoordinate { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="x_maximum_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> XMaximumCoordinate { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Maximum number of total grid points must be <= 2500 (X*Y)")]
[JsonProperty(PropertyName="number_of_x_grid_points", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfXGridPoints { get; set; } = Double.Parse("2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="y_minimum_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> YMinimumCoordinate { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="y_maximum_coordinate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> YMaximumCoordinate { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Maximum number of total grid points must be <= 2500 (X*Y)")]
[JsonProperty(PropertyName="number_of_y_grid_points", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfYGridPoints { get; set; } = Double.Parse("2", CultureInfo.InvariantCulture);
    }
    
    [Description(@"default style for the Daylighting Illuminance Map is comma -- this works well for importing into spreadsheet programs such as Excel(tm) but not so well for word processing programs -- there tab may be a better choice. fixed puts spaces between the ""columns""")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class OutputControl_IlluminanceMap_Style
    {
        

[JsonProperty(PropertyName="column_separator", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public OutputControl_IlluminanceMap_Style_ColumnSeparator ColumnSeparator { get; set; } = (OutputControl_IlluminanceMap_Style_ColumnSeparator)Enum.Parse(typeof(OutputControl_IlluminanceMap_Style_ColumnSeparator), "Comma");
    }
    
    public enum OutputControl_IlluminanceMap_Style_ColumnSeparator
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Comma")]
        Comma = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Fixed")]
        Fixed = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Tab")]
        Tab = 3,
    }
}
