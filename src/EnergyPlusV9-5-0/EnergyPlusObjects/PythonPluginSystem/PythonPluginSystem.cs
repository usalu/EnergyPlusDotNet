namespace EnergyPlus.PythonPluginSystem
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
    
    
    [Description(@"Add directories to the search path for Python plugin modules The directory containing the EnergyPlus executable file is automatically added so that the Python interpreter can find the packaged up pyenergyplus Python package. By default, the current working directory and input file directory are also added to the search path. However, this object allows modifying this behavior. With this object, searching these directories can be disabled, and users can add supplemental search paths that point to libraries of plugin scripts.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PythonPlugin_SearchPaths
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Adding the current working directory allows Python to find plugin scripts in the " +
    "current directory.")]
[JsonProperty(PropertyName="add_current_working_directory_to_search_path", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes AddCurrentWorkingDirectoryToSearchPath { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[Description("Enabling this will allow Python to find plugin scripts in the same directory as t" +
    "he running input file, even if that is not the current working directory.")]
[JsonProperty(PropertyName="add_input_file_directory_to_search_path", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes AddInputFileDirectoryToSearchPath { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[JsonProperty(PropertyName="py_search_paths", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> PySearchPaths { get; set; } = null;
    }
    
    [Description("A single plugin to be executed during the simulation, which can contain multiple " +
        "calling points for the same class instance by overriding multiple calling point " +
        "methods.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PythonPlugin_Instance
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("If this field is enabled, the plugin will be executed during warmup days, otherwi" +
    "se it will only be executed once warmup is completed and the actual run period b" +
    "egins")]
[JsonProperty(PropertyName="run_during_warmup_days", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes RunDuringWarmupDays { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description(@"This is the name of the Python file, without a file extension. For ""plugin_b.py"", use just ""plugin_b"". The Python plugin file must be on the plugin system search path to be found during a simulation Additional directories can be added to the search path using the PythonPlugin:SearchPaths object")]
[JsonProperty(PropertyName="python_module_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PythonModuleName { get; set; } = "";
        

[Description("This is the name of the class to be executed as a plugin during a simulation The " +
    "class must inherit the EnergyPlusPlugin base class")]
[JsonProperty(PropertyName="plugin_class_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PluginClassName { get; set; } = "";
    }
    
    [Description("This object defines name identifiers for custom Python Plugin variable data that " +
        "should be shared among all running Python Plugins.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PythonPlugin_Variables
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="global_py_vars", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> GlobalPyVars { get; set; } = null;
    }
    
    [Description("This object sets up a Python plugin trend variable from an Python plugin variable" +
        " A trend variable logs values across timesteps")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PythonPlugin_TrendVariable
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="name_of_a_python_plugin_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NameOfAPythonPluginVariable { get; set; } = "";
        

[JsonProperty(PropertyName="number_of_timesteps_to_be_logged", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfTimestepsToBeLogged { get; set; } = null;
    }
    
    [Description("This object sets up an EnergyPlus output variable from a Python Plugin variable")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PythonPlugin_OutputVariable
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Must be listed in the PythonPlugin:Variables object")]
[JsonProperty(PropertyName="python_plugin_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PythonPluginVariableName { get; set; } = "";
        

[Description("If Metered is selected, the variable is automatically set to a \"Summed\" type, and" +
    " the Resource Type, Group Type, and End-Use Subcategory fields on this object ar" +
    "e required")]
[JsonProperty(PropertyName="type_of_data_in_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PythonPlugin_OutputVariable_TypeOfDataInVariable TypeOfDataInVariable { get; set; } = (PythonPlugin_OutputVariable_TypeOfDataInVariable)Enum.Parse(typeof(PythonPlugin_OutputVariable_TypeOfDataInVariable), "Averaged");
        

[JsonProperty(PropertyName="update_frequency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PythonPlugin_OutputVariable_UpdateFrequency UpdateFrequency { get; set; } = (PythonPlugin_OutputVariable_UpdateFrequency)Enum.Parse(typeof(PythonPlugin_OutputVariable_UpdateFrequency), "SystemTimestep");
        

[Description("optional but will result in dimensionless units for blank EnergyPlus units are st" +
    "andard SI units")]
[JsonProperty(PropertyName="units", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Units { get; set; } = "";
        

[Description(@"This field is optional for regular output variables with ""Type of Data in Variable"" set to either Averaged or Summed. For Metered variables, this field is required. Choose the type of fuel, water, electricity, pollution or heat rate that should be metered.")]
[JsonProperty(PropertyName="resource_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PythonPlugin_OutputVariable_ResourceType ResourceType { get; set; } = (PythonPlugin_OutputVariable_ResourceType)Enum.Parse(typeof(PythonPlugin_OutputVariable_ResourceType), "Coal");
        

[Description(@"This field is optional for regular output variables with ""Type of Data in Variable"" set to either Averaged or Summed. For Metered variables, this field is required. Choose a general classification, building (internal services), HVAC (air systems), or plant (hydronic systems), or system")]
[JsonProperty(PropertyName="group_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PythonPlugin_OutputVariable_GroupType GroupType { get; set; } = (PythonPlugin_OutputVariable_GroupType)Enum.Parse(typeof(PythonPlugin_OutputVariable_GroupType), "Building");
        

[Description("This field is optional for regular output variables with \"Type of Data in Variabl" +
    "e\" set to either Averaged or Summed. For Metered variables, this field is requir" +
    "ed. Choose how the metered output should be classified for end-use category")]
[JsonProperty(PropertyName="end_use_category", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PythonPlugin_OutputVariable_EndUseCategory EndUseCategory { get; set; } = (PythonPlugin_OutputVariable_EndUseCategory)Enum.Parse(typeof(PythonPlugin_OutputVariable_EndUseCategory), "Baseboard");
        

[Description(@"This field is always optional. For regular output variables with ""Type of Data in Variable"" set to either Averaged or Summed, this field is completely ignored. For Metered variables, this field is optional, but allows custom categorization of the end-uses in the ABUPS End Uses by Subcategory table. Enter a user-defined subcategory for this metered output")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "";
    }
    
    public enum PythonPlugin_OutputVariable_TypeOfDataInVariable
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Averaged")]
        Averaged = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Metered")]
        Metered = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Summed")]
        Summed = 2,
    }
    
    public enum PythonPlugin_OutputVariable_UpdateFrequency
    {
        
        [System.Runtime.Serialization.EnumMember(Value="SystemTimestep")]
        SystemTimestep = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ZoneTimestep")]
        ZoneTimestep = 1,
    }
    
    public enum PythonPlugin_OutputVariable_ResourceType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coal")]
        Coal = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CondensateWaterCollected")]
        CondensateWaterCollected = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Diesel")]
        Diesel = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DistrictCooling")]
        DistrictCooling = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="DistrictHeating")]
        DistrictHeating = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Electricity")]
        Electricity = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectricityProducedOnSite")]
        ElectricityProducedOnSite = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="EnergyTransfer")]
        EnergyTransfer = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo1")]
        FuelOilNo1 = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo2")]
        FuelOilNo2 = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Gasoline")]
        Gasoline = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="MainsWaterSupply")]
        MainsWaterSupply = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="NaturalGas")]
        NaturalGas = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="OnSiteWaterProduced")]
        OnSiteWaterProduced = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel1")]
        OtherFuel1 = 14,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel2")]
        OtherFuel2 = 15,
        
        [System.Runtime.Serialization.EnumMember(Value="Propane")]
        Propane = 16,
        
        [System.Runtime.Serialization.EnumMember(Value="RainWaterCollected")]
        RainWaterCollected = 17,
        
        [System.Runtime.Serialization.EnumMember(Value="SolarAirHeating")]
        SolarAirHeating = 18,
        
        [System.Runtime.Serialization.EnumMember(Value="SolarWaterHeating")]
        SolarWaterHeating = 19,
        
        [System.Runtime.Serialization.EnumMember(Value="Steam")]
        Steam = 20,
        
        [System.Runtime.Serialization.EnumMember(Value="WaterUse")]
        WaterUse = 21,
        
        [System.Runtime.Serialization.EnumMember(Value="WellWaterDrawn")]
        WellWaterDrawn = 22,
    }
    
    public enum PythonPlugin_OutputVariable_GroupType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Building")]
        Building = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="HVAC")]
        HVAC = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Plant")]
        Plant = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="System")]
        System = 3,
    }
    
    public enum PythonPlugin_OutputVariable_EndUseCategory
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Baseboard")]
        Baseboard = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Boilers")]
        Boilers = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Chillers")]
        Chillers = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingCoils")]
        CoolingCoils = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="ExteriorEquipment")]
        ExteriorEquipment = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="ExteriorLights")]
        ExteriorLights = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="Fans")]
        Fans = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatRecovery")]
        HeatRecovery = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatRecoveryForCooling")]
        HeatRecoveryForCooling = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatRecoveryForHeating")]
        HeatRecoveryForHeating = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatRejection")]
        HeatRejection = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatingCoils")]
        HeatingCoils = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Humidifier")]
        Humidifier = 14,
        
        [System.Runtime.Serialization.EnumMember(Value="InteriorEquipment")]
        InteriorEquipment = 15,
        
        [System.Runtime.Serialization.EnumMember(Value="InteriorLights")]
        InteriorLights = 16,
        
        [System.Runtime.Serialization.EnumMember(Value="OnSiteGeneration")]
        OnSiteGeneration = 17,
        
        [System.Runtime.Serialization.EnumMember(Value="Pumps")]
        Pumps = 18,
        
        [System.Runtime.Serialization.EnumMember(Value="Refrigeration")]
        Refrigeration = 19,
        
        [System.Runtime.Serialization.EnumMember(Value="WaterSystems")]
        WaterSystems = 20,
    }
}
