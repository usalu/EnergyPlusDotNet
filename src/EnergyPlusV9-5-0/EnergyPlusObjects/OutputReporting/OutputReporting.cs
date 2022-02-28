namespace EnergyPlus.OutputReporting
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
    
    
    [Description(@"Produces a list summarizing the output variables and meters that are available for reporting for the model being simulated (rdd output file). The list varies depending on the types of objects present in the idf file. For example, variables related to lights will only appear if a Lights object is present. The IDF option generates complete Output:Variable objects to simplify adding the desired output to the idf file.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_VariableDictionary
    {
        

[JsonProperty(PropertyName="key_field", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_VariableDictionary_KeyField KeyField { get; set; } = (Output_VariableDictionary_KeyField)Enum.Parse(typeof(Output_VariableDictionary_KeyField), "Empty");
        

[JsonProperty(PropertyName="sort_option", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_VariableDictionary_SortOption SortOption { get; set; } = (Output_VariableDictionary_SortOption)Enum.Parse(typeof(Output_VariableDictionary_SortOption), "Name");
    }
    
    public enum Output_VariableDictionary_KeyField
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="IDF")]
        IDF = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="regular")]
        Regular = 2,
    }
    
    public enum Output_VariableDictionary_SortOption
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Name")]
        Name = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Unsorted")]
        Unsorted = 1,
    }
    
    [Description("Produces a report summarizing the details of surfaces in the eio output file.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_Surfaces_List
    {
        

[JsonProperty(PropertyName="report_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_Surfaces_List_ReportType ReportType { get; set; } = (Output_Surfaces_List_ReportType)Enum.Parse(typeof(Output_Surfaces_List_ReportType), "CostInfo");
        

[Description("(IDF, only for Output:Surfaces:List, Lines report -- will print transformed coord" +
    "inates in IDF style)")]
[JsonProperty(PropertyName="report_specifications", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_Surfaces_List_ReportSpecifications ReportSpecifications { get; set; } = (Output_Surfaces_List_ReportSpecifications)Enum.Parse(typeof(Output_Surfaces_List_ReportSpecifications), "IDF");
    }
    
    public enum Output_Surfaces_List_ReportType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="CostInfo")]
        CostInfo = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DecayCurvesFromComponentLoadsSummary")]
        DecayCurvesFromComponentLoadsSummary = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Details")]
        Details = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DetailsWithVertices")]
        DetailsWithVertices = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Lines")]
        Lines = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Vertices")]
        Vertices = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="ViewFactorInfo")]
        ViewFactorInfo = 6,
    }
    
    public enum Output_Surfaces_List_ReportSpecifications
    {
        
        [System.Runtime.Serialization.EnumMember(Value="IDF")]
        IDF = 0,
    }
    
    [Description("Produces reports/files that are capable of rendering graphically or being importe" +
        "d into other programs. Rendering does not alter the actual inputs/surfaces.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_Surfaces_Drawing
    {
        

[JsonProperty(PropertyName="report_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_Surfaces_Drawing_ReportType ReportType { get; set; } = (Output_Surfaces_Drawing_ReportType)Enum.Parse(typeof(Output_Surfaces_Drawing_ReportType), "DXF");
        

[Description("Triangulate3DFace (default), ThickPolyline, RegularPolyline apply to DXF This fie" +
    "ld is ignored for DXF:WireFrame and VRML")]
[JsonProperty(PropertyName="report_specifications_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_Surfaces_Drawing_ReportSpecifications1 ReportSpecifications1 { get; set; } = (Output_Surfaces_Drawing_ReportSpecifications1)Enum.Parse(typeof(Output_Surfaces_Drawing_ReportSpecifications1), "Triangulate3DFace");
        

[Description("Use ColorScheme Name for DXF reports")]
[JsonProperty(PropertyName="report_specifications_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReportSpecifications2 { get; set; } = "";
    }
    
    public enum Output_Surfaces_Drawing_ReportType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="DXF")]
        DXF = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DXF:WireFrame")]
        DXFWireFrame = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="VRML")]
        VRML = 2,
    }
    
    public enum Output_Surfaces_Drawing_ReportSpecifications1
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="RegularPolyline")]
        RegularPolyline = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ThickPolyline")]
        ThickPolyline = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Triangulate3DFace")]
        Triangulate3DFace = 3,
    }
    
    [Description("Produces a condensed reporting that illustrates the full range of schedule values" +
        " in the eio output file. In the style of input: DaySchedule,  WeekSchedule, and " +
        "Annual Schedule.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_Schedules
    {
        

[JsonProperty(PropertyName="key_field", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_Schedules_KeyField KeyField { get; set; } = (Output_Schedules_KeyField)Enum.Parse(typeof(Output_Schedules_KeyField), "Hourly");
    }
    
    public enum Output_Schedules_KeyField
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Hourly")]
        Hourly = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Timestep")]
        Timestep = 1,
    }
    
    [Description("Adds a report to the eio output file which shows details for each construction, i" +
        "ncluding overall properties, a list of material layers, and calculated results r" +
        "elated to conduction transfer functions.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_Constructions
    {
        

[JsonProperty(PropertyName="details_type_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_Constructions_DetailsType1 DetailsType1 { get; set; } = (Output_Constructions_DetailsType1)Enum.Parse(typeof(Output_Constructions_DetailsType1), "Constructions");
        

[JsonProperty(PropertyName="details_type_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_Constructions_DetailsType2 DetailsType2 { get; set; } = (Output_Constructions_DetailsType2)Enum.Parse(typeof(Output_Constructions_DetailsType2), "Constructions");
    }
    
    public enum Output_Constructions_DetailsType1
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Constructions")]
        Constructions = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Materials")]
        Materials = 1,
    }
    
    public enum Output_Constructions_DetailsType2
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Constructions")]
        Constructions = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Materials")]
        Materials = 1,
    }
    
    [Description("This object is used to control the output produced by the Energy Management Syste" +
        "m")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_EnergyManagementSystem
    {
        

[JsonProperty(PropertyName="actuator_availability_dictionary_reporting", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_EnergyManagementSystem_ActuatorAvailabilityDictionaryReporting ActuatorAvailabilityDictionaryReporting { get; set; } = (Output_EnergyManagementSystem_ActuatorAvailabilityDictionaryReporting)Enum.Parse(typeof(Output_EnergyManagementSystem_ActuatorAvailabilityDictionaryReporting), "None");
        

[JsonProperty(PropertyName="internal_variable_availability_dictionary_reporting", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_EnergyManagementSystem_InternalVariableAvailabilityDictionaryReporting InternalVariableAvailabilityDictionaryReporting { get; set; } = (Output_EnergyManagementSystem_InternalVariableAvailabilityDictionaryReporting)Enum.Parse(typeof(Output_EnergyManagementSystem_InternalVariableAvailabilityDictionaryReporting), "None");
        

[JsonProperty(PropertyName="ems_runtime_language_debug_output_level", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_EnergyManagementSystem_EmsRuntimeLanguageDebugOutputLevel EmsRuntimeLanguageDebugOutputLevel { get; set; } = (Output_EnergyManagementSystem_EmsRuntimeLanguageDebugOutputLevel)Enum.Parse(typeof(Output_EnergyManagementSystem_EmsRuntimeLanguageDebugOutputLevel), "None");
    }
    
    public enum Output_EnergyManagementSystem_ActuatorAvailabilityDictionaryReporting
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="NotByUniqueKeyNames")]
        NotByUniqueKeyNames = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Verbose")]
        Verbose = 3,
    }
    
    public enum Output_EnergyManagementSystem_InternalVariableAvailabilityDictionaryReporting
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="NotByUniqueKeyNames")]
        NotByUniqueKeyNames = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Verbose")]
        Verbose = 3,
    }
    
    public enum Output_EnergyManagementSystem_EmsRuntimeLanguageDebugOutputLevel
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ErrorsOnly")]
        ErrorsOnly = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Verbose")]
        Verbose = 3,
    }
    
    [Description(@"This object is used to set colors for reporting on various building elements particularly for the DXF reports. We know the user can enter 0 to 255 and the color map is available in DXF output. Therefore, we are limiting the colors in that range. You can extend by editing the IDD but you do so on your own. Colors not changed in any scheme will remain as the default scheme uses.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class OutputControl_SurfaceColorScheme
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="drawing_element_1_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public OutputControl_SurfaceColorScheme_DrawingElement1Type DrawingElement1Type { get; set; } = (OutputControl_SurfaceColorScheme_DrawingElement1Type)Enum.Parse(typeof(OutputControl_SurfaceColorScheme_DrawingElement1Type), "AttachedBuildingShades");
        

[Description("use color number for output assignment (e.g. DXF)")]
[JsonProperty(PropertyName="color_for_drawing_element_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ColorForDrawingElement1 { get; set; } = null;
        

[JsonProperty(PropertyName="drawing_element_2_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public OutputControl_SurfaceColorScheme_DrawingElement2Type DrawingElement2Type { get; set; } = (OutputControl_SurfaceColorScheme_DrawingElement2Type)Enum.Parse(typeof(OutputControl_SurfaceColorScheme_DrawingElement2Type), "AttachedBuildingShades");
        

[Description("use color number for output assignment (e.g. DXF)")]
[JsonProperty(PropertyName="color_for_drawing_element_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ColorForDrawingElement2 { get; set; } = null;
        

[JsonProperty(PropertyName="drawing_element_3_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public OutputControl_SurfaceColorScheme_DrawingElement3Type DrawingElement3Type { get; set; } = (OutputControl_SurfaceColorScheme_DrawingElement3Type)Enum.Parse(typeof(OutputControl_SurfaceColorScheme_DrawingElement3Type), "AttachedBuildingShades");
        

[Description("use color number for output assignment (e.g. DXF)")]
[JsonProperty(PropertyName="color_for_drawing_element_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ColorForDrawingElement3 { get; set; } = null;
        

[JsonProperty(PropertyName="drawing_element_4_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public OutputControl_SurfaceColorScheme_DrawingElement4Type DrawingElement4Type { get; set; } = (OutputControl_SurfaceColorScheme_DrawingElement4Type)Enum.Parse(typeof(OutputControl_SurfaceColorScheme_DrawingElement4Type), "AttachedBuildingShades");
        

[Description("use color number for output assignment (e.g. DXF)")]
[JsonProperty(PropertyName="color_for_drawing_element_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ColorForDrawingElement4 { get; set; } = null;
        

[JsonProperty(PropertyName="drawing_element_5_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public OutputControl_SurfaceColorScheme_DrawingElement5Type DrawingElement5Type { get; set; } = (OutputControl_SurfaceColorScheme_DrawingElement5Type)Enum.Parse(typeof(OutputControl_SurfaceColorScheme_DrawingElement5Type), "AttachedBuildingShades");
        

[Description("use color number for output assignment (e.g. DXF)")]
[JsonProperty(PropertyName="color_for_drawing_element_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ColorForDrawingElement5 { get; set; } = null;
        

[JsonProperty(PropertyName="drawing_element_6_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public OutputControl_SurfaceColorScheme_DrawingElement6Type DrawingElement6Type { get; set; } = (OutputControl_SurfaceColorScheme_DrawingElement6Type)Enum.Parse(typeof(OutputControl_SurfaceColorScheme_DrawingElement6Type), "AttachedBuildingShades");
        

[Description("use color number for output assignment (e.g. DXF)")]
[JsonProperty(PropertyName="color_for_drawing_element_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ColorForDrawingElement6 { get; set; } = null;
        

[JsonProperty(PropertyName="drawing_element_7_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public OutputControl_SurfaceColorScheme_DrawingElement7Type DrawingElement7Type { get; set; } = (OutputControl_SurfaceColorScheme_DrawingElement7Type)Enum.Parse(typeof(OutputControl_SurfaceColorScheme_DrawingElement7Type), "AttachedBuildingShades");
        

[Description("use color number for output assignment (e.g. DXF)")]
[JsonProperty(PropertyName="color_for_drawing_element_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ColorForDrawingElement7 { get; set; } = null;
        

[JsonProperty(PropertyName="drawing_element_8_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public OutputControl_SurfaceColorScheme_DrawingElement8Type DrawingElement8Type { get; set; } = (OutputControl_SurfaceColorScheme_DrawingElement8Type)Enum.Parse(typeof(OutputControl_SurfaceColorScheme_DrawingElement8Type), "AttachedBuildingShades");
        

[Description("use color number for output assignment (e.g. DXF)")]
[JsonProperty(PropertyName="color_for_drawing_element_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ColorForDrawingElement8 { get; set; } = null;
        

[JsonProperty(PropertyName="drawing_element_9_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public OutputControl_SurfaceColorScheme_DrawingElement9Type DrawingElement9Type { get; set; } = (OutputControl_SurfaceColorScheme_DrawingElement9Type)Enum.Parse(typeof(OutputControl_SurfaceColorScheme_DrawingElement9Type), "AttachedBuildingShades");
        

[Description("use color number for output assignment (e.g. DXF)")]
[JsonProperty(PropertyName="color_for_drawing_element_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ColorForDrawingElement9 { get; set; } = null;
        

[JsonProperty(PropertyName="drawing_element_10_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public OutputControl_SurfaceColorScheme_DrawingElement10Type DrawingElement10Type { get; set; } = (OutputControl_SurfaceColorScheme_DrawingElement10Type)Enum.Parse(typeof(OutputControl_SurfaceColorScheme_DrawingElement10Type), "AttachedBuildingShades");
        

[Description("use color number for output assignment (e.g. DXF)")]
[JsonProperty(PropertyName="color_for_drawing_element_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ColorForDrawingElement10 { get; set; } = null;
        

[JsonProperty(PropertyName="drawing_element_11_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public OutputControl_SurfaceColorScheme_DrawingElement11Type DrawingElement11Type { get; set; } = (OutputControl_SurfaceColorScheme_DrawingElement11Type)Enum.Parse(typeof(OutputControl_SurfaceColorScheme_DrawingElement11Type), "AttachedBuildingShades");
        

[Description("use color number for output assignment (e.g. DXF)")]
[JsonProperty(PropertyName="color_for_drawing_element_11", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ColorForDrawingElement11 { get; set; } = null;
        

[JsonProperty(PropertyName="drawing_element_12_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public OutputControl_SurfaceColorScheme_DrawingElement12Type DrawingElement12Type { get; set; } = (OutputControl_SurfaceColorScheme_DrawingElement12Type)Enum.Parse(typeof(OutputControl_SurfaceColorScheme_DrawingElement12Type), "AttachedBuildingShades");
        

[Description("use color number for output assignment (e.g. DXF)")]
[JsonProperty(PropertyName="color_for_drawing_element_12", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ColorForDrawingElement12 { get; set; } = null;
        

[JsonProperty(PropertyName="drawing_element_13_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public OutputControl_SurfaceColorScheme_DrawingElement13Type DrawingElement13Type { get; set; } = (OutputControl_SurfaceColorScheme_DrawingElement13Type)Enum.Parse(typeof(OutputControl_SurfaceColorScheme_DrawingElement13Type), "AttachedBuildingShades");
        

[Description("use color number for output assignment (e.g. DXF)")]
[JsonProperty(PropertyName="color_for_drawing_element_13", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ColorForDrawingElement13 { get; set; } = null;
        

[JsonProperty(PropertyName="drawing_element_14_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public OutputControl_SurfaceColorScheme_DrawingElement14Type DrawingElement14Type { get; set; } = (OutputControl_SurfaceColorScheme_DrawingElement14Type)Enum.Parse(typeof(OutputControl_SurfaceColorScheme_DrawingElement14Type), "AttachedBuildingShades");
        

[Description("use color number for output assignment (e.g. DXF)")]
[JsonProperty(PropertyName="color_for_drawing_element_14", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ColorForDrawingElement14 { get; set; } = null;
        

[JsonProperty(PropertyName="drawing_element_15_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public OutputControl_SurfaceColorScheme_DrawingElement15Type DrawingElement15Type { get; set; } = (OutputControl_SurfaceColorScheme_DrawingElement15Type)Enum.Parse(typeof(OutputControl_SurfaceColorScheme_DrawingElement15Type), "AttachedBuildingShades");
        

[Description("use color number for output assignment (e.g. DXF)")]
[JsonProperty(PropertyName="color_for_drawing_element_15", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ColorForDrawingElement15 { get; set; } = null;
    }
    
    public enum OutputControl_SurfaceColorScheme_DrawingElement1Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AttachedBuildingShades")]
        AttachedBuildingShades = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint1")]
        DaylightReferencePoint1 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint2")]
        DaylightReferencePoint2 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedBuildingShades")]
        DetachedBuildingShades = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedFixedShades")]
        DetachedFixedShades = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Doors")]
        Doors = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Floors")]
        Floors = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="GlassDoors")]
        GlassDoors = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Photovoltaics")]
        Photovoltaics = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Roofs")]
        Roofs = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Text")]
        Text = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDiffusers")]
        TubularDaylightDiffusers = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDomes")]
        TubularDaylightDomes = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Walls")]
        Walls = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Windows")]
        Windows = 14,
    }
    
    public enum OutputControl_SurfaceColorScheme_DrawingElement2Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AttachedBuildingShades")]
        AttachedBuildingShades = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint1")]
        DaylightReferencePoint1 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint2")]
        DaylightReferencePoint2 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedBuildingShades")]
        DetachedBuildingShades = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedFixedShades")]
        DetachedFixedShades = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Doors")]
        Doors = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Floors")]
        Floors = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="GlassDoors")]
        GlassDoors = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Photovoltaics")]
        Photovoltaics = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Roofs")]
        Roofs = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Text")]
        Text = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDiffusers")]
        TubularDaylightDiffusers = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDomes")]
        TubularDaylightDomes = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Walls")]
        Walls = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Windows")]
        Windows = 14,
    }
    
    public enum OutputControl_SurfaceColorScheme_DrawingElement3Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AttachedBuildingShades")]
        AttachedBuildingShades = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint1")]
        DaylightReferencePoint1 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint2")]
        DaylightReferencePoint2 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedBuildingShades")]
        DetachedBuildingShades = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedFixedShades")]
        DetachedFixedShades = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Doors")]
        Doors = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Floors")]
        Floors = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="GlassDoors")]
        GlassDoors = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Photovoltaics")]
        Photovoltaics = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Roofs")]
        Roofs = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Text")]
        Text = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDiffusers")]
        TubularDaylightDiffusers = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDomes")]
        TubularDaylightDomes = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Walls")]
        Walls = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Windows")]
        Windows = 14,
    }
    
    public enum OutputControl_SurfaceColorScheme_DrawingElement4Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AttachedBuildingShades")]
        AttachedBuildingShades = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint1")]
        DaylightReferencePoint1 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint2")]
        DaylightReferencePoint2 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedBuildingShades")]
        DetachedBuildingShades = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedFixedShades")]
        DetachedFixedShades = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Doors")]
        Doors = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Floors")]
        Floors = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="GlassDoors")]
        GlassDoors = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Photovoltaics")]
        Photovoltaics = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Roofs")]
        Roofs = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Text")]
        Text = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDiffusers")]
        TubularDaylightDiffusers = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDomes")]
        TubularDaylightDomes = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Walls")]
        Walls = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Windows")]
        Windows = 14,
    }
    
    public enum OutputControl_SurfaceColorScheme_DrawingElement5Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AttachedBuildingShades")]
        AttachedBuildingShades = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint1")]
        DaylightReferencePoint1 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint2")]
        DaylightReferencePoint2 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedBuildingShades")]
        DetachedBuildingShades = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedFixedShades")]
        DetachedFixedShades = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Doors")]
        Doors = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Floors")]
        Floors = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="GlassDoors")]
        GlassDoors = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Photovoltaics")]
        Photovoltaics = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Roofs")]
        Roofs = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Text")]
        Text = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDiffusers")]
        TubularDaylightDiffusers = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDomes")]
        TubularDaylightDomes = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Walls")]
        Walls = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Windows")]
        Windows = 14,
    }
    
    public enum OutputControl_SurfaceColorScheme_DrawingElement6Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AttachedBuildingShades")]
        AttachedBuildingShades = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint1")]
        DaylightReferencePoint1 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint2")]
        DaylightReferencePoint2 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedBuildingShades")]
        DetachedBuildingShades = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedFixedShades")]
        DetachedFixedShades = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Doors")]
        Doors = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Floors")]
        Floors = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="GlassDoors")]
        GlassDoors = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Photovoltaics")]
        Photovoltaics = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Roofs")]
        Roofs = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Text")]
        Text = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDiffusers")]
        TubularDaylightDiffusers = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDomes")]
        TubularDaylightDomes = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Walls")]
        Walls = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Windows")]
        Windows = 14,
    }
    
    public enum OutputControl_SurfaceColorScheme_DrawingElement7Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AttachedBuildingShades")]
        AttachedBuildingShades = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint1")]
        DaylightReferencePoint1 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint2")]
        DaylightReferencePoint2 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedBuildingShades")]
        DetachedBuildingShades = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedFixedShades")]
        DetachedFixedShades = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Doors")]
        Doors = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Floors")]
        Floors = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="GlassDoors")]
        GlassDoors = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Photovoltaics")]
        Photovoltaics = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Roofs")]
        Roofs = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Text")]
        Text = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDiffusers")]
        TubularDaylightDiffusers = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDomes")]
        TubularDaylightDomes = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Walls")]
        Walls = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Windows")]
        Windows = 14,
    }
    
    public enum OutputControl_SurfaceColorScheme_DrawingElement8Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AttachedBuildingShades")]
        AttachedBuildingShades = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint1")]
        DaylightReferencePoint1 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint2")]
        DaylightReferencePoint2 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedBuildingShades")]
        DetachedBuildingShades = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedFixedShades")]
        DetachedFixedShades = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Doors")]
        Doors = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Floors")]
        Floors = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="GlassDoors")]
        GlassDoors = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Photovoltaics")]
        Photovoltaics = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Roofs")]
        Roofs = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Text")]
        Text = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDiffusers")]
        TubularDaylightDiffusers = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDomes")]
        TubularDaylightDomes = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Walls")]
        Walls = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Windows")]
        Windows = 14,
    }
    
    public enum OutputControl_SurfaceColorScheme_DrawingElement9Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AttachedBuildingShades")]
        AttachedBuildingShades = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint1")]
        DaylightReferencePoint1 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint2")]
        DaylightReferencePoint2 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedBuildingShades")]
        DetachedBuildingShades = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedFixedShades")]
        DetachedFixedShades = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Doors")]
        Doors = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Floors")]
        Floors = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="GlassDoors")]
        GlassDoors = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Photovoltaics")]
        Photovoltaics = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Roofs")]
        Roofs = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Text")]
        Text = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDiffusers")]
        TubularDaylightDiffusers = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDomes")]
        TubularDaylightDomes = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Walls")]
        Walls = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Windows")]
        Windows = 14,
    }
    
    public enum OutputControl_SurfaceColorScheme_DrawingElement10Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AttachedBuildingShades")]
        AttachedBuildingShades = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint1")]
        DaylightReferencePoint1 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint2")]
        DaylightReferencePoint2 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedBuildingShades")]
        DetachedBuildingShades = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedFixedShades")]
        DetachedFixedShades = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Doors")]
        Doors = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Floors")]
        Floors = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="GlassDoors")]
        GlassDoors = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Photovoltaics")]
        Photovoltaics = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Roofs")]
        Roofs = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Text")]
        Text = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDiffusers")]
        TubularDaylightDiffusers = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDomes")]
        TubularDaylightDomes = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Walls")]
        Walls = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Windows")]
        Windows = 14,
    }
    
    public enum OutputControl_SurfaceColorScheme_DrawingElement11Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AttachedBuildingShades")]
        AttachedBuildingShades = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint1")]
        DaylightReferencePoint1 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint2")]
        DaylightReferencePoint2 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedBuildingShades")]
        DetachedBuildingShades = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedFixedShades")]
        DetachedFixedShades = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Doors")]
        Doors = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Floors")]
        Floors = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="GlassDoors")]
        GlassDoors = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Photovoltaics")]
        Photovoltaics = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Roofs")]
        Roofs = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Text")]
        Text = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDiffusers")]
        TubularDaylightDiffusers = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDomes")]
        TubularDaylightDomes = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Walls")]
        Walls = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Windows")]
        Windows = 14,
    }
    
    public enum OutputControl_SurfaceColorScheme_DrawingElement12Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AttachedBuildingShades")]
        AttachedBuildingShades = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint1")]
        DaylightReferencePoint1 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint2")]
        DaylightReferencePoint2 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedBuildingShades")]
        DetachedBuildingShades = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedFixedShades")]
        DetachedFixedShades = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Doors")]
        Doors = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Floors")]
        Floors = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="GlassDoors")]
        GlassDoors = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Photovoltaics")]
        Photovoltaics = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Roofs")]
        Roofs = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Text")]
        Text = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDiffusers")]
        TubularDaylightDiffusers = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDomes")]
        TubularDaylightDomes = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Walls")]
        Walls = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Windows")]
        Windows = 14,
    }
    
    public enum OutputControl_SurfaceColorScheme_DrawingElement13Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AttachedBuildingShades")]
        AttachedBuildingShades = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint1")]
        DaylightReferencePoint1 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint2")]
        DaylightReferencePoint2 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedBuildingShades")]
        DetachedBuildingShades = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedFixedShades")]
        DetachedFixedShades = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Doors")]
        Doors = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Floors")]
        Floors = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="GlassDoors")]
        GlassDoors = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Photovoltaics")]
        Photovoltaics = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Roofs")]
        Roofs = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Text")]
        Text = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDiffusers")]
        TubularDaylightDiffusers = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDomes")]
        TubularDaylightDomes = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Walls")]
        Walls = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Windows")]
        Windows = 14,
    }
    
    public enum OutputControl_SurfaceColorScheme_DrawingElement14Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AttachedBuildingShades")]
        AttachedBuildingShades = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint1")]
        DaylightReferencePoint1 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint2")]
        DaylightReferencePoint2 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedBuildingShades")]
        DetachedBuildingShades = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedFixedShades")]
        DetachedFixedShades = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Doors")]
        Doors = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Floors")]
        Floors = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="GlassDoors")]
        GlassDoors = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Photovoltaics")]
        Photovoltaics = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Roofs")]
        Roofs = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Text")]
        Text = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDiffusers")]
        TubularDaylightDiffusers = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDomes")]
        TubularDaylightDomes = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Walls")]
        Walls = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Windows")]
        Windows = 14,
    }
    
    public enum OutputControl_SurfaceColorScheme_DrawingElement15Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AttachedBuildingShades")]
        AttachedBuildingShades = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint1")]
        DaylightReferencePoint1 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DaylightReferencePoint2")]
        DaylightReferencePoint2 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedBuildingShades")]
        DetachedBuildingShades = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="DetachedFixedShades")]
        DetachedFixedShades = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Doors")]
        Doors = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Floors")]
        Floors = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="GlassDoors")]
        GlassDoors = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Photovoltaics")]
        Photovoltaics = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Roofs")]
        Roofs = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Text")]
        Text = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDiffusers")]
        TubularDaylightDiffusers = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="TubularDaylightDomes")]
        TubularDaylightDomes = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Walls")]
        Walls = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Windows")]
        Windows = 14,
    }
    
    [Description(@"This object allows the user to call report types that are predefined and will appear with the other tabular reports. These predefined reports are sensitive to the OutputControl:Table:Style object and appear in the same files as the tabular reports. The entries for this object is a list of the predefined reports that should appear in the tabular report output file.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_Table_SummaryReports
    {
        

[JsonProperty(PropertyName="reports", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Reports { get; set; } = null;
    }
    
    [Description("Produces a bin report in the table output file which shows the amount of time in " +
        "hours that occurs in different bins for a single specific output variable or met" +
        "er. Two different types of binning are reported: by month and by hour of the day" +
        ".")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_Table_TimeBins
    {
        

[Description("use \'*\' (without quotes) to apply this variable to all keys")]
[JsonProperty(PropertyName="key_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string KeyValue { get; set; } = "*";
        

[JsonProperty(PropertyName="variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string VariableName { get; set; } = "";
        

[Description("The lowest value for the intervals being binned into.")]
[JsonProperty(PropertyName="interval_start", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> IntervalStart { get; set; } = null;
        

[Description("The size of the bins starting with Interval start.")]
[JsonProperty(PropertyName="interval_size", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> IntervalSize { get; set; } = null;
        

[Description("The number of bins used. The number of hours below the start of the Lowest bin an" +
    "d above the value of the last bin are also shown.")]
[JsonProperty(PropertyName="interval_count", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> IntervalCount { get; set; } = null;
        

[Description("Optional schedule name. Binning is performed for non-zero hours. Binning always p" +
    "erformed if left blank.")]
[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[Description("Optional input on the type of units for the variable used by other fields in the " +
    "object.")]
[JsonProperty(PropertyName="variable_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_Table_TimeBins_VariableType VariableType { get; set; } = (Output_Table_TimeBins_VariableType)Enum.Parse(typeof(Output_Table_TimeBins_VariableType), "Energy");
    }
    
    public enum Output_Table_TimeBins_VariableType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Energy")]
        Energy = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 3,
    }
    
    [Description(@"Provides a generic method of setting up tables of monthly results. The report has multiple columns that are each defined using a repeated group of fields for any number of columns. A single Output:Table:Monthly object often produces multiple tables in the output. A table is produced for every instance of a particular output variable. For example, a table defined with zone variables will be produced once for every zone.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_Table_Monthly
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="digits_after_decimal", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DigitsAfterDecimal { get; set; } = Double.Parse("2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="variable_details", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Table_Monthly_VariableDetails_Item> VariableDetails { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_Table_Monthly_VariableDetails_Item
    {
        

[JsonProperty(PropertyName="variable_or_meter_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string VariableOrMeterName { get; set; } = "";
        

[JsonProperty(PropertyName="aggregation_type_for_variable_or_meter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AggregationTypeForVariableOrMeter { get; set; } = "";
    }
    
    [Description(@"Provides a generic method of setting up tables of annual results with one row per object. The report has multiple columns that are each defined using a repeated group of fields for any number of columns. A single Output:Table:Annual produces a single table in the output.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_Table_Annual
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description(@"An optional text string that is compared to the names of the objects referenced by the variables and if they match are included in the table. A footnote will appear that indicates that the objects shown may not be all the objects that of that type that occur in the file.")]
[JsonProperty(PropertyName="filter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Filter { get; set; } = "";
        

[Description("Optional schedule name. If left blank, aggregation is performed for all hours sim" +
    "ulated. If a schedule is specified, aggregation is performed for non-zero hours " +
    "in the schedule.")]
[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="variable_details", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Table_Annual_VariableDetails_Item> VariableDetails { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_Table_Annual_VariableDetails_Item
    {
        

[JsonProperty(PropertyName="variable_or_meter_or_ems_variable_or_field_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string VariableOrMeterOrEmsVariableOrFieldName { get; set; } = "";
        

[JsonProperty(PropertyName="aggregation_type_for_variable_or_meter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AggregationTypeForVariableOrMeter { get; set; } = "";
        

[JsonProperty(PropertyName="digits_after_decimal", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DigitsAfterDecimal { get; set; } = null;
    }
    
    [Description(@"default style for the OutputControl:Table:Style is comma -- this works well for importing into spreadsheet programs such as Excel(tm) but not so well for word processing programs -- there tab may be a better choice. fixed puts spaces between the ""columns"". HTML produces tables in HTML. XML produces an XML file. note - if no OutputControl:Table:Style is included, the defaults are comma and None.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class OutputControl_Table_Style
    {
        

[JsonProperty(PropertyName="column_separator", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public OutputControl_Table_Style_ColumnSeparator ColumnSeparator { get; set; } = (OutputControl_Table_Style_ColumnSeparator)Enum.Parse(typeof(OutputControl_Table_Style_ColumnSeparator), "Comma");
        

[JsonProperty(PropertyName="unit_conversion", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public OutputControl_Table_Style_UnitConversion UnitConversion { get; set; } = (OutputControl_Table_Style_UnitConversion)Enum.Parse(typeof(OutputControl_Table_Style_UnitConversion), "None");
    }
    
    public enum OutputControl_Table_Style_ColumnSeparator
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="All")]
        All = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Comma")]
        Comma = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="CommaAndHTML")]
        CommaAndHTML = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="CommaAndXML")]
        CommaAndXML = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Fixed")]
        Fixed = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="HTML")]
        HTML = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="Tab")]
        Tab = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="TabAndHTML")]
        TabAndHTML = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="XML")]
        XML = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="XMLandHTML")]
        XMLandHTML = 10,
    }
    
    public enum OutputControl_Table_Style_UnitConversion
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="InchPound")]
        InchPound = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="JtoGJ")]
        JtoGJ = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="JtoKWH")]
        JtoKWH = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="JtoMJ")]
        JtoMJ = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 5,
    }
    
    [Description("Calculations of the time that setpoints are not met use a tolerance of 0.2C. This" +
        " object allows changing the tolerance used to determine when setpoints are being" +
        " met.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class OutputControl_ReportingTolerances
    {
        

[Description(@"If the zone temperature is below the heating setpoint by more than this value, the following output variables will increment as appropriate Zone Heating Setpoint Not Met Time Zone Heating Setpoint Not Met While Occupied Time This also impacts table report ""Annual Building Utility Performance Summary"" subtable ""Comfort and Setpoint Not Met Summary""")]
[JsonProperty(PropertyName="tolerance_for_time_heating_setpoint_not_met", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ToleranceForTimeHeatingSetpointNotMet { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[Description(@"If the zone temperature is above the cooling setpoint by more than this value, the following output variables will increment as appropriate Zone Cooling Setpoint Not Met Time Zone Cooling Setpoint Not Met While Occupied Time This also impacts table report ""Annual Building Utility Performance Summary"" subtable ""Comfort and Setpoint Not Met Summary""")]
[JsonProperty(PropertyName="tolerance_for_time_cooling_setpoint_not_met", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ToleranceForTimeCoolingSetpointNotMet { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
    }
    
    [Description(@"each Output:Variable command picks variables to be put onto the standard output file (.eso) some variables may not be reported for every simulation. a list of variables that can be reported are available after a run on the report dictionary file (.rdd) if the Output:VariableDictionary has been requested.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_Variable
    {
        

[Description("use \'*\' (without quotes) to apply this variable to all keys")]
[JsonProperty(PropertyName="key_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string KeyValue { get; set; } = "*";
        

[JsonProperty(PropertyName="variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string VariableName { get; set; } = "";
        

[Description("Detailed lists every instance (i.e. HVAC variable timesteps) Timestep refers to t" +
    "he zone Timestep/Number of Timesteps in hour value RunPeriod and Environment are" +
    " the same")]
[JsonProperty(PropertyName="reporting_frequency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_Variable_ReportingFrequency ReportingFrequency { get; set; } = (Output_Variable_ReportingFrequency)Enum.Parse(typeof(Output_Variable_ReportingFrequency), "Hourly");
        

[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
    }
    
    public enum Output_Variable_ReportingFrequency
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Annual")]
        Annual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Daily")]
        Daily = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Detailed")]
        Detailed = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Environment")]
        Environment = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Hourly")]
        Hourly = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Monthly")]
        Monthly = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="RunPeriod")]
        RunPeriod = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Timestep")]
        Timestep = 8,
    }
    
    [Description(@"Each Output:Meter command picks meters to be put onto the standard output file (.eso) and meter file (.mtr). Not all meters are reported in every simulation. A list of meters that can be reported are available after a run on the meter dictionary file (.mdd) if the Output:VariableDictionary has been requested.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_Meter
    {
        

[Description("Form is EnergyUseType:..., e.g. Electricity:* for all Electricity meters or EndUs" +
    "e:..., e.g. GeneralLights:* for all General Lights Output:Meter puts results on " +
    "both the eplusout.mtr and eplusout.eso files")]
[JsonProperty(PropertyName="key_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string KeyName { get; set; } = "";
        

[Description("Timestep refers to the zone Timestep/Number of Timesteps in hour value RunPeriod " +
    "and Environment are the same")]
[JsonProperty(PropertyName="reporting_frequency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_Meter_ReportingFrequency ReportingFrequency { get; set; } = (Output_Meter_ReportingFrequency)Enum.Parse(typeof(Output_Meter_ReportingFrequency), "Hourly");
    }
    
    public enum Output_Meter_ReportingFrequency
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Annual")]
        Annual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Daily")]
        Daily = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Detailed")]
        Detailed = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Environment")]
        Environment = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Hourly")]
        Hourly = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Monthly")]
        Monthly = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="RunPeriod")]
        RunPeriod = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Timestep")]
        Timestep = 8,
    }
    
    [Description(@"Each Output:Meter:MeterFileOnly command picks meters to be put only onto meter file (.mtr). Not all meters are reported in every simulation. A list of meters that can be reported a list of meters that can be reported are available after a run on the meter dictionary file (.mdd) if the Output:VariableDictionary has been requested.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_Meter_MeterFileOnly
    {
        

[Description("Form is EnergyUseType:..., e.g. Electricity:* for all Electricity meters or EndUs" +
    "e:..., e.g. GeneralLights:* for all General Lights Output:Meter:MeterFileOnly pu" +
    "ts results on the eplusout.mtr file only")]
[JsonProperty(PropertyName="key_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string KeyName { get; set; } = "";
        

[Description("Timestep refers to the zone Timestep/Number of Timesteps in hour value RunPeriod " +
    "and Environment are the same")]
[JsonProperty(PropertyName="reporting_frequency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_Meter_MeterFileOnly_ReportingFrequency ReportingFrequency { get; set; } = (Output_Meter_MeterFileOnly_ReportingFrequency)Enum.Parse(typeof(Output_Meter_MeterFileOnly_ReportingFrequency), "Hourly");
    }
    
    public enum Output_Meter_MeterFileOnly_ReportingFrequency
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Annual")]
        Annual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Daily")]
        Daily = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Detailed")]
        Detailed = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Environment")]
        Environment = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Hourly")]
        Hourly = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Monthly")]
        Monthly = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="RunPeriod")]
        RunPeriod = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Timestep")]
        Timestep = 8,
    }
    
    [Description(@"Each Output:Meter:Cumulative command picks meters to be reported cumulatively onto the standard output file (.eso) and meter file (.mtr). Not all meters are reported in every simulation. a list of meters that can be reported are available after a run on the meter dictionary file (.mdd) if the Output:VariableDictionary has been requested.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_Meter_Cumulative
    {
        

[Description("Form is EnergyUseType:..., e.g. Electricity:* for all Electricity meters or EndUs" +
    "e:..., e.g. GeneralLights:* for all General Lights Output:Meter:Cumulative puts " +
    "results on both the eplusout.mtr and eplusout.eso files")]
[JsonProperty(PropertyName="key_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string KeyName { get; set; } = "";
        

[Description("Timestep refers to the zone Timestep/Number of Timesteps in hour value RunPeriod " +
    "and Environment are the same")]
[JsonProperty(PropertyName="reporting_frequency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_Meter_Cumulative_ReportingFrequency ReportingFrequency { get; set; } = (Output_Meter_Cumulative_ReportingFrequency)Enum.Parse(typeof(Output_Meter_Cumulative_ReportingFrequency), "Hourly");
    }
    
    public enum Output_Meter_Cumulative_ReportingFrequency
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Annual")]
        Annual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Daily")]
        Daily = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Detailed")]
        Detailed = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Environment")]
        Environment = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Hourly")]
        Hourly = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Monthly")]
        Monthly = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="RunPeriod")]
        RunPeriod = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Timestep")]
        Timestep = 8,
    }
    
    [Description(@"Each Output:Meter:Cumulative:MeterFileOnly command picks meters to be reported cumulatively onto the standard output file (.eso) and meter file (.mtr). Not all meters are reported in every simulation. a list of meters that can be reported are available after a run on the meter dictionary file (.mdd) if the Output:VariableDictionary has been requested.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_Meter_Cumulative_MeterFileOnly
    {
        

[Description("Form is EnergyUseType:..., e.g. Electricity:* for all Electricity meters or EndUs" +
    "e:..., e.g. GeneralLights:* for all General Lights Output:Meter:Cumulative:Meter" +
    "FileOnly puts results on the eplusout.mtr file only")]
[JsonProperty(PropertyName="key_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string KeyName { get; set; } = "";
        

[Description("Timestep refers to the zone Timestep/Number of Timesteps in hour value RunPeriod " +
    "and Environment are the same")]
[JsonProperty(PropertyName="reporting_frequency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_Meter_Cumulative_MeterFileOnly_ReportingFrequency ReportingFrequency { get; set; } = (Output_Meter_Cumulative_MeterFileOnly_ReportingFrequency)Enum.Parse(typeof(Output_Meter_Cumulative_MeterFileOnly_ReportingFrequency), "Hourly");
    }
    
    public enum Output_Meter_Cumulative_MeterFileOnly_ReportingFrequency
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Annual")]
        Annual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Daily")]
        Daily = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Detailed")]
        Detailed = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Environment")]
        Environment = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Hourly")]
        Hourly = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Monthly")]
        Monthly = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="RunPeriod")]
        RunPeriod = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Timestep")]
        Timestep = 8,
    }
    
    [Description(@"Used to allow users to combine specific variables and/or meters into ""custom"" meter configurations. To access these meters by name, one must first run a simulation to generate the RDD/MDD files and names. A Meter:Custom cannot reference another Meter:Custom.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Meter_Custom
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="resource_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Meter_Custom_ResourceType ResourceType { get; set; } = (Meter_Custom_ResourceType)Enum.Parse(typeof(Meter_Custom_ResourceType), "Coal");
        

[JsonProperty(PropertyName="variable_details", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.Meter_Custom_VariableDetails_Item> VariableDetails { get; set; } = null;
    }
    
    public enum Meter_Custom_ResourceType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coal")]
        Coal = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Diesel")]
        Diesel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DistrictCooling")]
        DistrictCooling = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DistrictHeating")]
        DistrictHeating = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Electricity")]
        Electricity = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo1")]
        FuelOilNo1 = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo2")]
        FuelOilNo2 = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="Gasoline")]
        Gasoline = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Generic")]
        Generic = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="NaturalGas")]
        NaturalGas = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel1")]
        OtherFuel1 = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel2")]
        OtherFuel2 = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="Propane")]
        Propane = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Steam")]
        Steam = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Water")]
        Water = 14,
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Meter_Custom_VariableDetails_Item
    {
        

[JsonProperty(PropertyName="key_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string KeyName { get; set; } = "";
        

[JsonProperty(PropertyName="output_variable_or_meter_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutputVariableOrMeterName { get; set; } = "";
    }
    
    [Description("Used to allow users to combine specific variables and/or meters into \"custom\" met" +
        "er configurations. To access these meters by name, one must first run a simulati" +
        "on to generate the RDD/MDD files and names.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Meter_CustomDecrement
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="resource_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Meter_CustomDecrement_ResourceType ResourceType { get; set; } = (Meter_CustomDecrement_ResourceType)Enum.Parse(typeof(Meter_CustomDecrement_ResourceType), "Coal");
        

[JsonProperty(PropertyName="source_meter_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SourceMeterName { get; set; } = "";
        

[JsonProperty(PropertyName="variable_details", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.Meter_CustomDecrement_VariableDetails_Item> VariableDetails { get; set; } = null;
    }
    
    public enum Meter_CustomDecrement_ResourceType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coal")]
        Coal = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Diesel")]
        Diesel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DistrictCooling")]
        DistrictCooling = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DistrictHeating")]
        DistrictHeating = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Electricity")]
        Electricity = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo1")]
        FuelOilNo1 = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo2")]
        FuelOilNo2 = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="Gasoline")]
        Gasoline = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Generic")]
        Generic = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="NaturalGas")]
        NaturalGas = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel1")]
        OtherFuel1 = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel2")]
        OtherFuel2 = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="Propane")]
        Propane = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Steam")]
        Steam = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Water")]
        Water = 14,
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Meter_CustomDecrement_VariableDetails_Item
    {
        

[JsonProperty(PropertyName="key_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string KeyName { get; set; } = "";
        

[JsonProperty(PropertyName="output_variable_or_meter_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutputVariableOrMeterName { get; set; } = "";
    }
    
    [Description("Conditionally turn on/off output from EnergyPlus.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class OutputControl_Files
    {
        

[JsonProperty(PropertyName="output_csv", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputCsv { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[JsonProperty(PropertyName="output_mtr", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputMtr { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_eso", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputEso { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_eio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputEio { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_tabular", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputTabular { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_sqlite", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputSqlite { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_json", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputJson { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_audit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputAudit { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_zone_sizing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputZoneSizing { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_system_sizing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputSystemSizing { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_dxf", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputDxf { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_bnd", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputBnd { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_rdd", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputRdd { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_mdd", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputMdd { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_mtd", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputMtd { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_end", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputEnd { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_shd", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputShd { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_dfs", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputDfs { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_glhe", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputGlhe { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_delightin", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputDelightin { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_delighteldmp", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputDelighteldmp { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_delightdfdmp", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputDelightdfdmp { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_edd", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputEdd { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_dbg", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputDbg { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_perflog", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputPerflog { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_sln", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputSln { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_sci", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputSci { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_wrl", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputWrl { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_screen", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputScreen { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_extshd", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputExtshd { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[Description("Not Implemented Yet")]
[JsonProperty(PropertyName="output_tarcog", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputTarcog { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
    }
    
    [Description("Output from EnergyPlus can be written to JSON format files.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_JSON
    {
        

[JsonProperty(PropertyName="option_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_JSON_OptionType OptionType { get; set; } = (Output_JSON_OptionType)Enum.Parse(typeof(Output_JSON_OptionType), "TimeSeries");
        

[JsonProperty(PropertyName="output_json", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputJson { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="output_cbor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputCbor { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[JsonProperty(PropertyName="output_messagepack", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputMessagepack { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
    }
    
    public enum Output_JSON_OptionType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="TimeSeries")]
        TimeSeries = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="TimeSeriesAndTabular")]
        TimeSeriesAndTabular = 1,
    }
    
    [Description("Output from EnergyPlus can be written to an SQLite format file.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_SQLite
    {
        

[JsonProperty(PropertyName="option_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_SQLite_OptionType OptionType { get; set; } = (Output_SQLite_OptionType)Enum.Parse(typeof(Output_SQLite_OptionType), "Simple");
        

[Description("Unit conversion option used when writing SQLite Tabular Data This option applies " +
    "to TabularData and TabularDatawithString in the SQLite file")]
[JsonProperty(PropertyName="unit_conversion_for_tabular_data", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_SQLite_UnitConversionForTabularData UnitConversionForTabularData { get; set; } = (Output_SQLite_UnitConversionForTabularData)Enum.Parse(typeof(Output_SQLite_UnitConversionForTabularData), "UseOutputControlTableStyle");
    }
    
    public enum Output_SQLite_OptionType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Simple")]
        Simple = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SimpleAndTabular")]
        SimpleAndTabular = 1,
    }
    
    public enum Output_SQLite_UnitConversionForTabularData
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="InchPound")]
        InchPound = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="JtoGJ")]
        JtoGJ = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="JtoKWH")]
        JtoKWH = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="JtoMJ")]
        JtoMJ = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="UseOutputControlTableStyle")]
        UseOutputControlTableStyle = 6,
    }
    
    [Description("This is used to Automatically report the facility meters and turn on the Environm" +
        "ental Impact Report calculations for all of the Environmental Factors.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_EnvironmentalImpactFactors
    {
        

[Description("Timestep refers to the zone Timestep/Number of Timesteps in hour value RunPeriod " +
    "and Environment are the same. Detailed is not a valid choice.")]
[JsonProperty(PropertyName="reporting_frequency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_EnvironmentalImpactFactors_ReportingFrequency ReportingFrequency { get; set; } = (Output_EnvironmentalImpactFactors_ReportingFrequency)Enum.Parse(typeof(Output_EnvironmentalImpactFactors_ReportingFrequency), "Annual");
    }
    
    public enum Output_EnvironmentalImpactFactors_ReportingFrequency
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Annual")]
        Annual = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Daily")]
        Daily = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Environment")]
        Environment = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Hourly")]
        Hourly = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Monthly")]
        Monthly = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="RunPeriod")]
        RunPeriod = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Timestep")]
        Timestep = 6,
    }
    
    [Description("Used to help convert district and ideal energy use to a fuel type and provide tot" +
        "al carbon equivalent with coefficients Also used in Source=>Site conversions.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class EnvironmentalImpactFactors
    {
        

[Description("District heating efficiency used when converted to natural gas")]
[JsonProperty(PropertyName="district_heating_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistrictHeatingEfficiency { get; set; } = Double.Parse("0.3", CultureInfo.InvariantCulture);
        

[Description("District cooling COP used when converted to electricity")]
[JsonProperty(PropertyName="district_cooling_cop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistrictCoolingCop { get; set; } = Double.Parse("3", CultureInfo.InvariantCulture);
        

[Description("Steam conversion efficiency used to convert steam usage to natural gas")]
[JsonProperty(PropertyName="steam_conversion_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SteamConversionEfficiency { get; set; } = Double.Parse("0.25", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="total_carbon_equivalent_emission_factor_from_n2o", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TotalCarbonEquivalentEmissionFactorFromN2o { get; set; } = Double.Parse("80.7272", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="total_carbon_equivalent_emission_factor_from_ch4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TotalCarbonEquivalentEmissionFactorFromCh4 { get; set; } = Double.Parse("6.2727", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="total_carbon_equivalent_emission_factor_from_co2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TotalCarbonEquivalentEmissionFactorFromCo2 { get; set; } = Double.Parse("0.2727", CultureInfo.InvariantCulture);
    }
    
    [Description("Provides Fuel Factors for Emissions as well as Source=>Site conversions. OtherFue" +
        "l1, OtherFuel2 provide options for users who want to create and use fuels that m" +
        "ay not be mainstream (biomass, wood, pellets).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class FuelFactors
    {
        

[JsonProperty(PropertyName="existing_fuel_resource_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public FuelFactors_ExistingFuelResourceName ExistingFuelResourceName { get; set; } = (FuelFactors_ExistingFuelResourceName)Enum.Parse(typeof(FuelFactors_ExistingFuelResourceName), "Coal");
        

[JsonProperty(PropertyName="units_of_measure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UnitsOfMeasure { get; set; } = "";
        

[JsonProperty(PropertyName="energy_per_unit_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EnergyPerUnitFactor { get; set; } = null;
        

[JsonProperty(PropertyName="source_energy_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SourceEnergyFactor { get; set; } = null;
        

[JsonProperty(PropertyName="source_energy_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SourceEnergyScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="co2_emission_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Co2EmissionFactor { get; set; } = null;
        

[JsonProperty(PropertyName="co2_emission_factor_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Co2EmissionFactorScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="co_emission_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoEmissionFactor { get; set; } = null;
        

[JsonProperty(PropertyName="co_emission_factor_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoEmissionFactorScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="ch4_emission_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Ch4EmissionFactor { get; set; } = null;
        

[JsonProperty(PropertyName="ch4_emission_factor_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Ch4EmissionFactorScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="nox_emission_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NoxEmissionFactor { get; set; } = null;
        

[JsonProperty(PropertyName="nox_emission_factor_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NoxEmissionFactorScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="n2o_emission_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> N2oEmissionFactor { get; set; } = null;
        

[JsonProperty(PropertyName="n2o_emission_factor_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string N2oEmissionFactorScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="so2_emission_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> So2EmissionFactor { get; set; } = null;
        

[JsonProperty(PropertyName="so2_emission_factor_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string So2EmissionFactorScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="pm_emission_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PmEmissionFactor { get; set; } = null;
        

[JsonProperty(PropertyName="pm_emission_factor_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PmEmissionFactorScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="pm10_emission_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Pm10EmissionFactor { get; set; } = null;
        

[JsonProperty(PropertyName="pm10_emission_factor_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Pm10EmissionFactorScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="pm2_5_emission_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Pm25EmissionFactor { get; set; } = null;
        

[JsonProperty(PropertyName="pm2_5_emission_factor_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Pm25EmissionFactorScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="nh3_emission_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Nh3EmissionFactor { get; set; } = null;
        

[JsonProperty(PropertyName="nh3_emission_factor_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Nh3EmissionFactorScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="nmvoc_emission_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NmvocEmissionFactor { get; set; } = null;
        

[JsonProperty(PropertyName="nmvoc_emission_factor_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NmvocEmissionFactorScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="hg_emission_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HgEmissionFactor { get; set; } = null;
        

[JsonProperty(PropertyName="hg_emission_factor_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HgEmissionFactorScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="pb_emission_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PbEmissionFactor { get; set; } = null;
        

[JsonProperty(PropertyName="pb_emission_factor_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PbEmissionFactorScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="water_emission_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterEmissionFactor { get; set; } = null;
        

[JsonProperty(PropertyName="water_emission_factor_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterEmissionFactorScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="nuclear_high_level_emission_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NuclearHighLevelEmissionFactor { get; set; } = null;
        

[JsonProperty(PropertyName="nuclear_high_level_emission_factor_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NuclearHighLevelEmissionFactorScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="nuclear_low_level_emission_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NuclearLowLevelEmissionFactor { get; set; } = null;
        

[JsonProperty(PropertyName="nuclear_low_level_emission_factor_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NuclearLowLevelEmissionFactorScheduleName { get; set; } = "";
    }
    
    public enum FuelFactors_ExistingFuelResourceName
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coal")]
        Coal = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Diesel")]
        Diesel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Electricity")]
        Electricity = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo1")]
        FuelOilNo1 = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo2")]
        FuelOilNo2 = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Gasoline")]
        Gasoline = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="NaturalGas")]
        NaturalGas = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel1")]
        OtherFuel1 = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel2")]
        OtherFuel2 = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Propane")]
        Propane = 9,
    }
    
    [Description("Special keys to produce certain warning messages or effect certain simulation cha" +
        "racteristics.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_Diagnostics
    {
        

[JsonProperty(PropertyName="diagnostics", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Diagnostics { get; set; } = null;
    }
    
    [Description("switch eplusout.dbg file on or off")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_DebuggingData
    {
        

[JsonProperty(PropertyName="report_debugging_data", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes ReportDebuggingData { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[JsonProperty(PropertyName="report_during_warmup", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes ReportDuringWarmup { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
    }
    
    [Description("This object does not come from a user input. This is generated by a pre-processor" +
        " so that various conditions can be gracefully passed on by the InputProcessor.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Output_PreprocessorMessage
    {
        

[JsonProperty(PropertyName="preprocessor_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PreprocessorName { get; set; } = "";
        

[Description("Depending on type, InputProcessor may terminate the program.")]
[JsonProperty(PropertyName="error_severity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Output_PreprocessorMessage_ErrorSeverity ErrorSeverity { get; set; } = (Output_PreprocessorMessage_ErrorSeverity)Enum.Parse(typeof(Output_PreprocessorMessage_ErrorSeverity), "Fatal");
        

[JsonProperty(PropertyName="message_line_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MessageLine1 { get; set; } = "";
        

[JsonProperty(PropertyName="message_line_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MessageLine2 { get; set; } = "";
        

[JsonProperty(PropertyName="message_line_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MessageLine3 { get; set; } = "";
        

[JsonProperty(PropertyName="message_line_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MessageLine4 { get; set; } = "";
        

[JsonProperty(PropertyName="message_line_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MessageLine5 { get; set; } = "";
        

[JsonProperty(PropertyName="message_line_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MessageLine6 { get; set; } = "";
        

[JsonProperty(PropertyName="message_line_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MessageLine7 { get; set; } = "";
        

[JsonProperty(PropertyName="message_line_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MessageLine8 { get; set; } = "";
        

[JsonProperty(PropertyName="message_line_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MessageLine9 { get; set; } = "";
        

[JsonProperty(PropertyName="message_line_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MessageLine10 { get; set; } = "";
    }
    
    public enum Output_PreprocessorMessage_ErrorSeverity
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fatal")]
        Fatal = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Information")]
        Information = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Severe")]
        Severe = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Warning")]
        Warning = 3,
    }
}
