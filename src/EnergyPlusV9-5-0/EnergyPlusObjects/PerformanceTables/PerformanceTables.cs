namespace EnergyPlus.PerformanceTables
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
    
    
    [Description("An independent variable representing a single dimension of a Table:Lookup object." +
        "")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Table_IndependentVariable
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="interpolation_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Table_IndependentVariable_InterpolationMethod InterpolationMethod { get; set; } = (Table_IndependentVariable_InterpolationMethod)Enum.Parse(typeof(Table_IndependentVariable_InterpolationMethod), "Linear");
        

[JsonProperty(PropertyName="extrapolation_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Table_IndependentVariable_ExtrapolationMethod ExtrapolationMethod { get; set; } = (Table_IndependentVariable_ExtrapolationMethod)Enum.Parse(typeof(Table_IndependentVariable_ExtrapolationMethod), "Constant");
        

[JsonProperty(PropertyName="minimum_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValue { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValue { get; set; } = null;
        

[JsonProperty(PropertyName="normalization_reference_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NormalizationReferenceValue { get; set; } = null;
        

[JsonProperty(PropertyName="unit_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Table_IndependentVariable_UnitType UnitType { get; set; } = (Table_IndependentVariable_UnitType)Enum.Parse(typeof(Table_IndependentVariable_UnitType), "Dimensionless");
        

[JsonProperty(PropertyName="external_file_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ExternalFileName { get; set; } = "";
        

[JsonProperty(PropertyName="external_file_column_number", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ExternalFileColumnNumber { get; set; } = null;
        

[JsonProperty(PropertyName="external_file_starting_row_number", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ExternalFileStartingRowNumber { get; set; } = null;
        

[JsonProperty(PropertyName="values", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Values { get; set; } = "";
    }
    
    public enum Table_IndependentVariable_InterpolationMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Cubic")]
        Cubic = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Linear")]
        Linear = 2,
    }
    
    public enum Table_IndependentVariable_ExtrapolationMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Constant")]
        Constant = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Linear")]
        Linear = 2,
    }
    
    public enum Table_IndependentVariable_UnitType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Angle")]
        Angle = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 7,
    }
    
    [Description("A sorted list of independent variables used by one or more Table:Lookup objects.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Table_IndependentVariableList
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("This list is the IndependentVariableName object-list")]
[JsonProperty(PropertyName="independent_variables", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> IndependentVariables { get; set; } = null;
    }
    
    [Description(@"Lookup tables are used in place of curves and can represent any number of independent variables (defined as Table:IndependentVariable objects in a Table:IndependentVariableList). Output values are interpolated within the bounds defined by each independent variable and extrapolated beyond the bounds according to the interpolation/extrapolation methods defined by each independent variable.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Table_Lookup
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="independent_variable_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string IndependentVariableListName { get; set; } = "";
        

[JsonProperty(PropertyName="normalization_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Table_Lookup_NormalizationMethod NormalizationMethod { get; set; } = (Table_Lookup_NormalizationMethod)Enum.Parse(typeof(Table_Lookup_NormalizationMethod), "None");
        

[JsonProperty(PropertyName="normalization_divisor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NormalizationDivisor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumOutput { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumOutput { get; set; } = null;
        

[JsonProperty(PropertyName="output_unit_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Table_Lookup_OutputUnitType OutputUnitType { get; set; } = (Table_Lookup_OutputUnitType)Enum.Parse(typeof(Table_Lookup_OutputUnitType), "Dimensionless");
        

[JsonProperty(PropertyName="external_file_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ExternalFileName { get; set; } = "";
        

[JsonProperty(PropertyName="external_file_column_number", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ExternalFileColumnNumber { get; set; } = null;
        

[JsonProperty(PropertyName="external_file_starting_row_number", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ExternalFileStartingRowNumber { get; set; } = null;
        

[JsonProperty(PropertyName="values", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Values { get; set; } = "";
    }
    
    public enum Table_Lookup_NormalizationMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AutomaticWithDivisor")]
        AutomaticWithDivisor = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DivisorOnly")]
        DivisorOnly = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    public enum Table_Lookup_OutputUnitType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Capacity")]
        Capacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Pressure")]
        Pressure = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
    }
}
