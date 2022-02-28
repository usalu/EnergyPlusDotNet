namespace EnergyPlus.EnergyManagementSystemEMS
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
    
    
    [Description("Declares EMS variable as a sensor a list of output variables and meters that can " +
        "be reported are available after a run on the report (.rdd) or meter dictionary f" +
        "ile (.mdd) if the Output:VariableDictionary has been requested.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class EnergyManagementSystem_Sensor
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="output_variable_or_output_meter_index_key_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutputVariableOrOutputMeterIndexKeyName { get; set; } = "";
        

[JsonProperty(PropertyName="output_variable_or_output_meter_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutputVariableOrOutputMeterName { get; set; } = "";
    }
    
    [Description("Hardware portion of EMS used to set up actuators in the model")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class EnergyManagementSystem_Actuator
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="actuated_component_unique_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ActuatedComponentUniqueName { get; set; } = "";
        

[JsonProperty(PropertyName="actuated_component_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ActuatedComponentType { get; set; } = "";
        

[JsonProperty(PropertyName="actuated_component_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ActuatedComponentControlType { get; set; } = "";
    }
    
    [Description("Input EMS program. a program needs a name a description of when it should be call" +
        "ed and then lines of program code for EMS Runtime language")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class EnergyManagementSystem_ProgramCallingManager
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="energyplus_model_calling_point", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EnergyManagementSystem_ProgramCallingManager_EnergyplusModelCallingPoint EnergyplusModelCallingPoint { get; set; } = (EnergyManagementSystem_ProgramCallingManager_EnergyplusModelCallingPoint)Enum.Parse(typeof(EnergyManagementSystem_ProgramCallingManager_EnergyplusModelCallingPoint), "AfterComponentInputReadIn");
        

[Description("This list is the ErlProgramNames object-list")]
[JsonProperty(PropertyName="programs", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Programs { get; set; } = null;
    }
    
    public enum EnergyManagementSystem_ProgramCallingManager_EnergyplusModelCallingPoint
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AfterComponentInputReadIn")]
        AfterComponentInputReadIn = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AfterNewEnvironmentWarmUpIsComplete")]
        AfterNewEnvironmentWarmUpIsComplete = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AfterPredictorAfterHVACManagers")]
        AfterPredictorAfterHVACManagers = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="AfterPredictorBeforeHVACManagers")]
        AfterPredictorBeforeHVACManagers = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="BeginNewEnvironment")]
        BeginNewEnvironment = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="BeginTimestepBeforePredictor")]
        BeginTimestepBeforePredictor = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="BeginZoneTimestepAfterInitHeatBalance")]
        BeginZoneTimestepAfterInitHeatBalance = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="BeginZoneTimestepBeforeInitHeatBalance")]
        BeginZoneTimestepBeforeInitHeatBalance = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="BeginZoneTimestepBeforeSetCurrentWeather")]
        BeginZoneTimestepBeforeSetCurrentWeather = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="EndOfSystemSizing")]
        EndOfSystemSizing = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="EndOfSystemTimestepAfterHVACReporting")]
        EndOfSystemTimestepAfterHVACReporting = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="EndOfSystemTimestepBeforeHVACReporting")]
        EndOfSystemTimestepBeforeHVACReporting = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="EndOfZoneSizing")]
        EndOfZoneSizing = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="EndOfZoneTimestepAfterZoneReporting")]
        EndOfZoneTimestepAfterZoneReporting = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="EndOfZoneTimestepBeforeZoneReporting")]
        EndOfZoneTimestepBeforeZoneReporting = 14,
        
        [System.Runtime.Serialization.EnumMember(Value="InsideHVACSystemIterationLoop")]
        InsideHVACSystemIterationLoop = 15,
        
        [System.Runtime.Serialization.EnumMember(Value="UnitarySystemSizing")]
        UnitarySystemSizing = 16,
        
        [System.Runtime.Serialization.EnumMember(Value="UserDefinedComponentModel")]
        UserDefinedComponentModel = 17,
    }
    
    [Description("This input defines an Erl program Each field after the name is a line of EMS Runt" +
        "ime Language")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class EnergyManagementSystem_Program
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="lines", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Lines { get; set; } = null;
    }
    
    [Description("This input defines an Erl program subroutine Each field after the name is a line " +
        "of EMS Runtime Language")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class EnergyManagementSystem_Subroutine
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="lines", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Lines { get; set; } = null;
    }
    
    [Description("Declares Erl variable as having global scope No spaces allowed in names used for " +
        "Erl variables")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class EnergyManagementSystem_GlobalVariable
    {
        

[JsonProperty(PropertyName="variables", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Variables { get; set; } = null;
    }
    
    [Description("This object sets up an EnergyPlus output variable from an Erl variable")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class EnergyManagementSystem_OutputVariable
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("must be an acceptable EMS variable")]
[JsonProperty(PropertyName="ems_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EmsVariableName { get; set; } = "";
        

[JsonProperty(PropertyName="type_of_data_in_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EnergyManagementSystem_OutputVariable_TypeOfDataInVariable TypeOfDataInVariable { get; set; } = (EnergyManagementSystem_OutputVariable_TypeOfDataInVariable)Enum.Parse(typeof(EnergyManagementSystem_OutputVariable_TypeOfDataInVariable), "Averaged");
        

[JsonProperty(PropertyName="update_frequency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EnergyManagementSystem_OutputVariable_UpdateFrequency UpdateFrequency { get; set; } = (EnergyManagementSystem_OutputVariable_UpdateFrequency)Enum.Parse(typeof(EnergyManagementSystem_OutputVariable_UpdateFrequency), "SystemTimestep");
        

[Description("optional for global scope variables, required for local scope variables")]
[JsonProperty(PropertyName="ems_program_or_subroutine_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EmsProgramOrSubroutineName { get; set; } = "";
        

[Description("optional but will result in dimensionless units for blank EnergyPlus units are st" +
    "andard SI units")]
[JsonProperty(PropertyName="units", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Units { get; set; } = "";
    }
    
    public enum EnergyManagementSystem_OutputVariable_TypeOfDataInVariable
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Averaged")]
        Averaged = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Summed")]
        Summed = 1,
    }
    
    public enum EnergyManagementSystem_OutputVariable_UpdateFrequency
    {
        
        [System.Runtime.Serialization.EnumMember(Value="SystemTimestep")]
        SystemTimestep = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ZoneTimestep")]
        ZoneTimestep = 1,
    }
    
    [Description("This object sets up an EnergyPlus output variable from an Erl variable")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class EnergyManagementSystem_MeteredOutputVariable
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("must be an acceptable EMS variable, no spaces")]
[JsonProperty(PropertyName="ems_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EmsVariableName { get; set; } = "";
        

[JsonProperty(PropertyName="update_frequency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EnergyManagementSystem_MeteredOutputVariable_UpdateFrequency UpdateFrequency { get; set; } = (EnergyManagementSystem_MeteredOutputVariable_UpdateFrequency)Enum.Parse(typeof(EnergyManagementSystem_MeteredOutputVariable_UpdateFrequency), "SystemTimestep");
        

[Description("optional for global scope variables, required for local scope variables")]
[JsonProperty(PropertyName="ems_program_or_subroutine_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EmsProgramOrSubroutineName { get; set; } = "";
        

[Description("choose the type of fuel, water, electricity, pollution or heat rate that should b" +
    "e metered.")]
[JsonProperty(PropertyName="resource_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EnergyManagementSystem_MeteredOutputVariable_ResourceType ResourceType { get; set; } = (EnergyManagementSystem_MeteredOutputVariable_ResourceType)Enum.Parse(typeof(EnergyManagementSystem_MeteredOutputVariable_ResourceType), "Coal");
        

[Description("choose a general classification, building (internal services), HVAC (air systems)" +
    ", or plant (hydronic systems), or system")]
[JsonProperty(PropertyName="group_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EnergyManagementSystem_MeteredOutputVariable_GroupType GroupType { get; set; } = (EnergyManagementSystem_MeteredOutputVariable_GroupType)Enum.Parse(typeof(EnergyManagementSystem_MeteredOutputVariable_GroupType), "Building");
        

[Description("choose how the metered output should be classified for end-use category")]
[JsonProperty(PropertyName="end_use_category", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EnergyManagementSystem_MeteredOutputVariable_EndUseCategory EndUseCategory { get; set; } = (EnergyManagementSystem_MeteredOutputVariable_EndUseCategory)Enum.Parse(typeof(EnergyManagementSystem_MeteredOutputVariable_EndUseCategory), "Baseboard");
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table. enter a user-defined subcategory for this metered output")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "";
        

[Description("optional but will result in dimensionless units for blank EnergyPlus units are st" +
    "andard SI units")]
[JsonProperty(PropertyName="units", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Units { get; set; } = "";
    }
    
    public enum EnergyManagementSystem_MeteredOutputVariable_UpdateFrequency
    {
        
        [System.Runtime.Serialization.EnumMember(Value="SystemTimestep")]
        SystemTimestep = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ZoneTimestep")]
        ZoneTimestep = 1,
    }
    
    public enum EnergyManagementSystem_MeteredOutputVariable_ResourceType
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
    
    public enum EnergyManagementSystem_MeteredOutputVariable_GroupType
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
    
    public enum EnergyManagementSystem_MeteredOutputVariable_EndUseCategory
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
    
    [Description("This object sets up an EMS trend variable from an Erl variable A trend variable l" +
        "ogs values across timesteps")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class EnergyManagementSystem_TrendVariable
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("must be a global scope EMS variable")]
[JsonProperty(PropertyName="ems_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EmsVariableName { get; set; } = "";
        

[JsonProperty(PropertyName="number_of_timesteps_to_be_logged", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfTimestepsToBeLogged { get; set; } = null;
    }
    
    [Description("Declares EMS variable as an internal data variable")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class EnergyManagementSystem_InternalVariable
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="internal_data_index_key_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InternalDataIndexKeyName { get; set; } = "";
        

[JsonProperty(PropertyName="internal_data_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InternalDataType { get; set; } = "";
    }
    
    [Description("Declares EMS variable that identifies a curve or table")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class EnergyManagementSystem_CurveOrTableIndexVariable
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="curve_or_table_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CurveOrTableObjectName { get; set; } = "";
    }
    
    [Description("Declares EMS variable that identifies a construction")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class EnergyManagementSystem_ConstructionIndexVariable
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="construction_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionObjectName { get; set; } = "";
    }
}
