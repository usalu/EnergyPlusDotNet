namespace EnergyPlus.NodeBranchManagement
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
    
    
    [Description("List components on the branch in simulation and connection order Note: this shoul" +
        "d NOT include splitters or mixers which define endpoints of branches")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Branch
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description(@"Optional field to include this branch in plant pressure drop calculations This field is only relevant for branches in PlantLoops and CondenserLoops Air loops do not account for pressure drop using this field Valid curve types are: Curve:Functional:PressureDrop or one of Curve:{Linear,Quadratic,Cubic,Exponent}')")]
[JsonProperty(PropertyName="pressure_drop_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PressureDropCurveName { get; set; } = "";
        

[JsonProperty(PropertyName="components", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.Branch_Components_Item> Components { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Branch_Components_Item
    {
        

[JsonProperty(PropertyName="component_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComponentObjectType { get; set; } = "";
        

[JsonProperty(PropertyName="component_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComponentName { get; set; } = "";
        

[JsonProperty(PropertyName="component_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComponentInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComponentOutletNodeName { get; set; } = "";
    }
    
    [Description("Branches MUST be listed in Flow order: Inlet branch, then parallel branches, then" +
        " Outlet branch. Branches are simulated in the order listed. Branch names cannot " +
        "be duplicated within a single branch list.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class BranchList
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("This list is the Branches object-list")]
[JsonProperty(PropertyName="branches", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Branches { get; set; } = null;
    }
    
    [Description("Split one air/water stream into N outlet streams. Branch names cannot be duplicat" +
        "ed within a single Splitter list.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Connector_Splitter
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="inlet_branch_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletBranchName { get; set; } = "";
        

[Description("This list is the Branches object-list")]
[JsonProperty(PropertyName="branches", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Branches { get; set; } = null;
    }
    
    [Description("Mix N inlet air/water streams into one. Branch names cannot be duplicated within " +
        "a single mixer list.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Connector_Mixer
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="outlet_branch_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutletBranchName { get; set; } = "";
        

[Description("This list is the Branches object-list")]
[JsonProperty(PropertyName="branches", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Branches { get; set; } = null;
    }
    
    [Description("only two connectors allowed per loop if two entered, one must be Connector:Splitt" +
        "er and one must be Connector:Mixer")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ConnectorList
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="connector_1_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ConnectorList_Connector1ObjectType Connector1ObjectType { get; set; } = (ConnectorList_Connector1ObjectType)Enum.Parse(typeof(ConnectorList_Connector1ObjectType), "ConnectorMixer");
        

[JsonProperty(PropertyName="connector_1_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Connector1Name { get; set; } = "";
        

[JsonProperty(PropertyName="connector_2_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ConnectorList_Connector2ObjectType Connector2ObjectType { get; set; } = (ConnectorList_Connector2ObjectType)Enum.Parse(typeof(ConnectorList_Connector2ObjectType), "ConnectorMixer");
        

[JsonProperty(PropertyName="connector_2_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Connector2Name { get; set; } = "";
    }
    
    public enum ConnectorList_Connector1ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Connector:Mixer")]
        ConnectorMixer = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Connector:Splitter")]
        ConnectorSplitter = 1,
    }
    
    public enum ConnectorList_Connector2ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Connector:Mixer")]
        ConnectorMixer = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Connector:Splitter")]
        ConnectorSplitter = 1,
    }
    
    [Description("This object is used in places where lists of nodes may be needed, e.g. ZoneHVAC:E" +
        "quipmentConnections field Zone Air Inlet Node or NodeList Name")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class NodeList
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="nodes", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Nodes { get; set; } = null;
    }
    
    [Description(@"This object sets the temperature and humidity conditions for an outdoor air node. It allows the height above ground to be specified. This object may be used more than once. The same node name may not appear in both an OutdoorAir:Node object and an OutdoorAir:NodeList object. This object defines local outdoor air environmental conditions.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class OutdoorAir_Node
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("A value less than zero indicates that the height will be ignored and the weather " +
    "file conditions will be used.")]
[JsonProperty(PropertyName="height_above_ground", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeightAboveGround { get; set; } = Double.Parse("-1", CultureInfo.InvariantCulture);
        

[Description("Schedule values are real numbers, -100.0 to 100.0, units C")]
[JsonProperty(PropertyName="drybulb_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DrybulbTemperatureScheduleName { get; set; } = "";
        

[Description("Schedule values are real numbers, -100.0 to 100.0, units C")]
[JsonProperty(PropertyName="wetbulb_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WetbulbTemperatureScheduleName { get; set; } = "";
        

[Description("Schedule values are real numbers, 0.0 to 40.0, units m/s")]
[JsonProperty(PropertyName="wind_speed_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WindSpeedScheduleName { get; set; } = "";
        

[Description("Schedule values are real numbers, 0.0 to 360.0, units degree")]
[JsonProperty(PropertyName="wind_direction_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WindDirectionScheduleName { get; set; } = "";
        

[Description("The name of the AirflowNetwork:MultiZone:WindPressureCoefficientValues, curve, or" +
    " table object specifying the wind pressure coefficient.")]
[JsonProperty(PropertyName="wind_pressure_coefficient_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WindPressureCoefficientCurveName { get; set; } = "";
        

[Description("Specify whether the pressure curve is symmetric or not. Specify Yes for curves th" +
    "at should be evaluated from 0 to 180 degrees Specify No for curves that should b" +
    "e evaluated from 0 to 360 degrees")]
[JsonProperty(PropertyName="symmetric_wind_pressure_coefficient_curve", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes SymmetricWindPressureCoefficientCurve { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("Specify whether the angle used to compute the wind pressure coefficient is absolu" +
    "te or relative Specify Relative to compute the angle between the wind direction " +
    "and the surface azimuth Specify Absolute to use the wind direction angle directl" +
    "y")]
[JsonProperty(PropertyName="wind_angle_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public OutdoorAir_Node_WindAngleType WindAngleType { get; set; } = (OutdoorAir_Node_WindAngleType)Enum.Parse(typeof(OutdoorAir_Node_WindAngleType), "Absolute");
    }
    
    public enum OutdoorAir_Node_WindAngleType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Absolute")]
        Absolute = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Relative")]
        Relative = 2,
    }
    
    [Description(@"This object sets the temperature and humidity conditions for an outdoor air node using the weather data values. to vary outdoor air node conditions with height above ground use OutdoorAir:Node instead of this object. This object may be used more than once. The same node name may not appear in both an OutdoorAir:Node object and an OutdoorAir:NodeList object.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class OutdoorAir_NodeList
    {
        

[JsonProperty(PropertyName="nodes", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Nodes { get; set; } = null;
    }
    
    [Description("Passes Inlet Node state variables to Outlet Node state variables")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Pipe_Adiabatic
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutletNodeName { get; set; } = "";
    }
    
    [Description("Passes Inlet Node state variables to Outlet Node state variables")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Pipe_Adiabatic_Steam
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutletNodeName { get; set; } = "";
    }
    
    [Description("Pipe model with transport delay and heat transfer to the environment.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Pipe_Indoor
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[JsonProperty(PropertyName="fluid_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FluidInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="fluid_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FluidOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="environment_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Pipe_Indoor_EnvironmentType EnvironmentType { get; set; } = (Pipe_Indoor_EnvironmentType)Enum.Parse(typeof(Pipe_Indoor_EnvironmentType), "Zone");
        

[JsonProperty(PropertyName="ambient_temperature_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AmbientTemperatureZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="ambient_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AmbientTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="ambient_air_velocity_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AmbientAirVelocityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="pipe_inside_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeInsideDiameter { get; set; } = null;
        

[JsonProperty(PropertyName="pipe_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeLength { get; set; } = null;
    }
    
    public enum Pipe_Indoor_EnvironmentType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Schedule")]
        Schedule = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Zone")]
        Zone = 2,
    }
    
    [Description("Pipe model with transport delay and heat transfer to the environment.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Pipe_Outdoor
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[JsonProperty(PropertyName="fluid_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FluidInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="fluid_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FluidOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="ambient_temperature_outdoor_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AmbientTemperatureOutdoorAirNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="pipe_inside_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeInsideDiameter { get; set; } = null;
        

[JsonProperty(PropertyName="pipe_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeLength { get; set; } = null;
    }
    
    [Description("Buried Pipe model: For pipes buried at a depth less than one meter, this is an al" +
        "ternative object to: HeatExchanger:Surface")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Pipe_Underground
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[JsonProperty(PropertyName="fluid_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FluidInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="fluid_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FluidOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="sun_exposure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Pipe_Underground_SunExposure SunExposure { get; set; } = (Pipe_Underground_SunExposure)Enum.Parse(typeof(Pipe_Underground_SunExposure), "NoSun");
        

[Description("pipe thickness is defined in the Construction object")]
[JsonProperty(PropertyName="pipe_inside_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeInsideDiameter { get; set; } = null;
        

[JsonProperty(PropertyName="pipe_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeLength { get; set; } = null;
        

[JsonProperty(PropertyName="soil_material_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SoilMaterialName { get; set; } = "";
        

[JsonProperty(PropertyName="undisturbed_ground_temperature_model_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Pipe_Underground_UndisturbedGroundTemperatureModelType UndisturbedGroundTemperatureModelType { get; set; } = (Pipe_Underground_UndisturbedGroundTemperatureModelType)Enum.Parse(typeof(Pipe_Underground_UndisturbedGroundTemperatureModelType), "SiteGroundTemperatureUndisturbedFiniteDifference");
        

[JsonProperty(PropertyName="undisturbed_ground_temperature_model_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UndisturbedGroundTemperatureModelName { get; set; } = "";
    }
    
    public enum Pipe_Underground_SunExposure
    {
        
        [System.Runtime.Serialization.EnumMember(Value="NoSun")]
        NoSun = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SunExposed")]
        SunExposed = 1,
    }
    
    public enum Pipe_Underground_UndisturbedGroundTemperatureModelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:Undisturbed:FiniteDifference")]
        SiteGroundTemperatureUndisturbedFiniteDifference = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:Undisturbed:KusudaAchenbach")]
        SiteGroundTemperatureUndisturbedKusudaAchenbach = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:Undisturbed:Xing")]
        SiteGroundTemperatureUndisturbedXing = 2,
    }
    
    [Description("The ground domain object for underground piping system simulation.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PipingSystem_Underground_Domain
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Domain extent in the local \'X\' direction")]
[JsonProperty(PropertyName="xmax", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Xmax { get; set; } = null;
        

[Description("Domain extent in the local \'Y\' direction")]
[JsonProperty(PropertyName="ymax", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Ymax { get; set; } = null;
        

[Description("Domain extent in the local \'Y\' direction")]
[JsonProperty(PropertyName="zmax", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Zmax { get; set; } = null;
        

[Description("If mesh type is symmetric geometric, this should be an even number.")]
[JsonProperty(PropertyName="x_direction_mesh_density_parameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> XDirectionMeshDensityParameter { get; set; } = Double.Parse("4", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="x_direction_mesh_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PipingSystem_Underground_Domain_XDirectionMeshType XDirectionMeshType { get; set; } = (PipingSystem_Underground_Domain_XDirectionMeshType)Enum.Parse(typeof(PipingSystem_Underground_Domain_XDirectionMeshType), "SymmetricGeometric");
        

[Description("optional Only used if mesh type is symmetric geometric")]
[JsonProperty(PropertyName="x_direction_geometric_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> XDirectionGeometricCoefficient { get; set; } = Double.Parse("1.3", CultureInfo.InvariantCulture);
        

[Description("If mesh type is symmetric geometric, this should be an even number.")]
[JsonProperty(PropertyName="y_direction_mesh_density_parameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> YDirectionMeshDensityParameter { get; set; } = Double.Parse("4", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="y_direction_mesh_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PipingSystem_Underground_Domain_YDirectionMeshType YDirectionMeshType { get; set; } = (PipingSystem_Underground_Domain_YDirectionMeshType)Enum.Parse(typeof(PipingSystem_Underground_Domain_YDirectionMeshType), "SymmetricGeometric");
        

[Description("optional Only used if mesh type is symmetric geometric")]
[JsonProperty(PropertyName="y_direction_geometric_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> YDirectionGeometricCoefficient { get; set; } = Double.Parse("1.3", CultureInfo.InvariantCulture);
        

[Description("If mesh type is symmetric geometric, this should be an even number.")]
[JsonProperty(PropertyName="z_direction_mesh_density_parameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZDirectionMeshDensityParameter { get; set; } = Double.Parse("4", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="z_direction_mesh_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PipingSystem_Underground_Domain_ZDirectionMeshType ZDirectionMeshType { get; set; } = (PipingSystem_Underground_Domain_ZDirectionMeshType)Enum.Parse(typeof(PipingSystem_Underground_Domain_ZDirectionMeshType), "SymmetricGeometric");
        

[Description("optional Only used if mesh type is symmetric geometric")]
[JsonProperty(PropertyName="z_direction_geometric_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZDirectionGeometricCoefficient { get; set; } = Double.Parse("1.3", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_thermal_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilThermalConductivity { get; set; } = null;
        

[JsonProperty(PropertyName="soil_density", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilDensity { get; set; } = null;
        

[Description("This is a dry soil property, which is adjusted for freezing effects by the simula" +
    "tion algorithm.")]
[JsonProperty(PropertyName="soil_specific_heat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilSpecificHeat { get; set; } = null;
        

[JsonProperty(PropertyName="soil_moisture_content_volume_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilMoistureContentVolumeFraction { get; set; } = Double.Parse("30", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_moisture_content_volume_fraction_at_saturation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SoilMoistureContentVolumeFractionAtSaturation { get; set; } = Double.Parse("50", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="undisturbed_ground_temperature_model_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PipingSystem_Underground_Domain_UndisturbedGroundTemperatureModelType UndisturbedGroundTemperatureModelType { get; set; } = (PipingSystem_Underground_Domain_UndisturbedGroundTemperatureModelType)Enum.Parse(typeof(PipingSystem_Underground_Domain_UndisturbedGroundTemperatureModelType), "SiteGroundTemperatureUndisturbedFiniteDifference");
        

[JsonProperty(PropertyName="undisturbed_ground_temperature_model_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UndisturbedGroundTemperatureModelName { get; set; } = "";
        

[Description("if Yes, then the following basement inputs are used if No, then the following bas" +
    "ement inputs are *ignored*")]
[JsonProperty(PropertyName="this_domain_includes_basement_surface_interaction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes ThisDomainIncludesBasementSurfaceInteraction { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("Required only if Domain Has Basement Interaction")]
[JsonProperty(PropertyName="width_of_basement_floor_in_ground_domain", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WidthOfBasementFloorInGroundDomain { get; set; } = null;
        

[Description("Required only if Domain Has Basement Interaction")]
[JsonProperty(PropertyName="depth_of_basement_wall_in_ground_domain", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DepthOfBasementWallInGroundDomain { get; set; } = null;
        

[Description("Required only if Domain Has Basement Interaction")]
[JsonProperty(PropertyName="shift_pipe_x_coordinates_by_basement_width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PipingSystem_Underground_Domain_ShiftPipeXCoordinatesByBasementWidth ShiftPipeXCoordinatesByBasementWidth { get; set; } = (PipingSystem_Underground_Domain_ShiftPipeXCoordinatesByBasementWidth)Enum.Parse(typeof(PipingSystem_Underground_Domain_ShiftPipeXCoordinatesByBasementWidth), "No");
        

[Description("Required only if Domain Has Basement Interaction")]
[JsonProperty(PropertyName="name_of_basement_wall_boundary_condition_model", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NameOfBasementWallBoundaryConditionModel { get; set; } = "";
        

[Description("Required only if Domain Has Basement Interaction")]
[JsonProperty(PropertyName="name_of_basement_floor_boundary_condition_model", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NameOfBasementFloorBoundaryConditionModel { get; set; } = "";
        

[JsonProperty(PropertyName="convergence_criterion_for_the_outer_cartesian_domain_iteration_loop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConvergenceCriterionForTheOuterCartesianDomainIterationLoop { get; set; } = Double.Parse("0.001", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_iterations_in_the_outer_cartesian_domain_iteration_loop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumIterationsInTheOuterCartesianDomainIterationLoop { get; set; } = Double.Parse("500", CultureInfo.InvariantCulture);
        

[Description(@"This specifies the ground cover effects during evapotranspiration calculations. The value roughly represents the following cases: = 0   : concrete or other solid, non-permeable ground surface material = 0.5 : short grass, much like a manicured lawn = 1   : standard reference state (12 cm grass) = 1.5 : wild growth")]
[JsonProperty(PropertyName="evapotranspiration_ground_cover_parameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvapotranspirationGroundCoverParameter { get; set; } = Double.Parse("0.4", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="number_of_pipe_circuits_entered_for_this_domain", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfPipeCircuitsEnteredForThisDomain { get; set; } = null;
        

[Description("This list is the PipingSystemUndergroundCircuitNames object-list")]
[JsonProperty(PropertyName="pipe_circuits", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> PipeCircuits { get; set; } = null;
    }
    
    public enum PipingSystem_Underground_Domain_XDirectionMeshType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="SymmetricGeometric")]
        SymmetricGeometric = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Uniform")]
        Uniform = 1,
    }
    
    public enum PipingSystem_Underground_Domain_YDirectionMeshType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="SymmetricGeometric")]
        SymmetricGeometric = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Uniform")]
        Uniform = 1,
    }
    
    public enum PipingSystem_Underground_Domain_ZDirectionMeshType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="SymmetricGeometric")]
        SymmetricGeometric = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Uniform")]
        Uniform = 1,
    }
    
    public enum PipingSystem_Underground_Domain_UndisturbedGroundTemperatureModelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:Undisturbed:FiniteDifference")]
        SiteGroundTemperatureUndisturbedFiniteDifference = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:Undisturbed:KusudaAchenbach")]
        SiteGroundTemperatureUndisturbedKusudaAchenbach = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Site:GroundTemperature:Undisturbed:Xing")]
        SiteGroundTemperatureUndisturbedXing = 2,
    }
    
    public enum PipingSystem_Underground_Domain_ShiftPipeXCoordinatesByBasementWidth
    {
        
        [System.Runtime.Serialization.EnumMember(Value="No")]
        No = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Yes")]
        Yes = 1,
    }
    
    [Description("The pipe circuit object in an underground piping system. This object is simulated" +
        " within an underground piping domain object and connected on a branch on a plant" +
        " loop.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PipingSystem_Underground_PipeCircuit
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="pipe_thermal_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeThermalConductivity { get; set; } = null;
        

[JsonProperty(PropertyName="pipe_density", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeDensity { get; set; } = null;
        

[JsonProperty(PropertyName="pipe_specific_heat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeSpecificHeat { get; set; } = null;
        

[JsonProperty(PropertyName="pipe_inner_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeInnerDiameter { get; set; } = null;
        

[JsonProperty(PropertyName="pipe_outer_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PipeOuterDiameter { get; set; } = null;
        

[JsonProperty(PropertyName="design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignFlowRate { get; set; } = null;
        

[JsonProperty(PropertyName="circuit_inlet_node", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CircuitInletNode { get; set; } = "";
        

[JsonProperty(PropertyName="circuit_outlet_node", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CircuitOutletNode { get; set; } = "";
        

[JsonProperty(PropertyName="convergence_criterion_for_the_inner_radial_iteration_loop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConvergenceCriterionForTheInnerRadialIterationLoop { get; set; } = Double.Parse("0.001", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_iterations_in_the_inner_radial_iteration_loop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumIterationsInTheInnerRadialIterationLoop { get; set; } = Double.Parse("500", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="number_of_soil_nodes_in_the_inner_radial_near_pipe_mesh_region", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfSoilNodesInTheInnerRadialNearPipeMeshRegion { get; set; } = Double.Parse("3", CultureInfo.InvariantCulture);
        

[Description("Required because it must be selected by user instead of being inferred from circu" +
    "it/domain object inputs.")]
[JsonProperty(PropertyName="radial_thickness_of_inner_radial_near_pipe_mesh_region", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RadialThicknessOfInnerRadialNearPipeMeshRegion { get; set; } = null;
        

[JsonProperty(PropertyName="number_of_pipe_segments_entered_for_this_pipe_circuit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfPipeSegmentsEnteredForThisPipeCircuit { get; set; } = null;
        

[Description("This list is the PipingSystemUndergroundSegmentNames object-list")]
[JsonProperty(PropertyName="pipe_segments", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> PipeSegments { get; set; } = null;
    }
    
    [Description("The pipe segment to be used in an underground piping system This object represent" +
        "s a single pipe leg positioned axially in the local z-direction, at a given x, y" +
        " location in the domain")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PipingSystem_Underground_PipeSegment
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("This segment will be centered at this distance from the x=0 domain surface or the" +
    " basement wall surface, based on whether a basement exists in this domain and th" +
    "e selection of the shift input field found in the domain object.")]
[JsonProperty(PropertyName="x_position", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> XPosition { get; set; } = null;
        

[Description("This segment will be centered at this distance away from the ground surface; thus" +
    " this value represents the burial depth of this pipe segment.")]
[JsonProperty(PropertyName="y_position", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> YPosition { get; set; } = null;
        

[Description("This segment will be simulated such that the flow is in the selected direction. T" +
    "his can allow for detailed analysis of circuiting effects in a single domain.")]
[JsonProperty(PropertyName="flow_direction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PipingSystem_Underground_PipeSegment_FlowDirection FlowDirection { get; set; } = (PipingSystem_Underground_PipeSegment_FlowDirection)Enum.Parse(typeof(PipingSystem_Underground_PipeSegment_FlowDirection), "DecreasingZ");
    }
    
    public enum PipingSystem_Underground_PipeSegment_FlowDirection
    {
        
        [System.Runtime.Serialization.EnumMember(Value="DecreasingZ")]
        DecreasingZ = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="IncreasingZ")]
        IncreasingZ = 1,
    }
    
    [Description("Passes inlet node state variables to outlet node state variables")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Duct
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutletNodeName { get; set; } = "";
    }
}
