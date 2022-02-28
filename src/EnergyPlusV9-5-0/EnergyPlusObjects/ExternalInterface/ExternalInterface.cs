namespace EnergyPlus.ExternalInterface
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
    
    
    [Description(@"This object activates the external interface of EnergyPlus. If the object ExternalInterface is present, then all ExtnernalInterface:* objects will receive their values from the BCVTB interface or from FMUs at each zone time step. If this object is not present, then the values of these objects will be fixed at the value declared in the ""initial value"" field of the corresponding object, and a warning will be written to the EnergyPlus error file.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ExternalInterface
    {
        

[Description("Name of External Interface Currently, the only valid entries are PtolemyServer, F" +
    "unctionalMockupUnitImport, and FunctionalMockupUnitExport.")]
[JsonProperty(PropertyName="name_of_external_interface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ExternalInterface_NameOfExternalInterface NameOfExternalInterface { get; set; } = (ExternalInterface_NameOfExternalInterface)Enum.Parse(typeof(ExternalInterface_NameOfExternalInterface), "FunctionalMockupUnitExport");
    }
    
    public enum ExternalInterface_NameOfExternalInterface
    {
        
        [System.Runtime.Serialization.EnumMember(Value="FunctionalMockupUnitExport")]
        FunctionalMockupUnitExport = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FunctionalMockupUnitImport")]
        FunctionalMockupUnitImport = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PtolemyServer")]
        PtolemyServer = 2,
    }
    
    [Description("A ExternalInterface:Schedule contains only one value, which is used during the wa" +
        "rm-up period and the system sizing.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ExternalInterface_Schedule
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="schedule_type_limits_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleTypeLimitsName { get; set; } = "";
        

[Description("Used during warm-up and system sizing.")]
[JsonProperty(PropertyName="initial_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InitialValue { get; set; } = null;
    }
    
    [Description(@"This input object is similar to EnergyManagementSystem:GlobalVariable. However, at the beginning of each zone time step, its value is set to the value received from the external interface. During the warm-up period and the system sizing, its value is set to the value specified by the field ""initial value."" This object can be used to move data into Erl subroutines.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ExternalInterface_Variable
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Used during warm-up and system sizing.")]
[JsonProperty(PropertyName="initial_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InitialValue { get; set; } = null;
    }
    
    [Description("Hardware portion of EMS used to set up actuators in the model")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ExternalInterface_Actuator
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
        

[Description("If specified, it is used during warm-up and system sizing. If not specified, then" +
    " the actuator only overwrites the actuated component after the warm-up and syste" +
    "m sizing.")]
[JsonProperty(PropertyName="optional_initial_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OptionalInitialValue { get; set; } = null;
    }
    
    [Description("This object declares an FMU")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ExternalInterface_FunctionalMockupUnitImport
    {
        

[JsonProperty(PropertyName="fmu_file_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FmuFileName { get; set; } = "";
        

[Description("in milli-seconds")]
[JsonProperty(PropertyName="fmu_timeout", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FmuTimeout { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fmu_loggingon", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FmuLoggingon { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    [Description("This object declares an FMU input variable")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ExternalInterface_FunctionalMockupUnitImport_From_Variable
    {
        

[JsonProperty(PropertyName="output_variable_index_key_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutputVariableIndexKeyName { get; set; } = "";
        

[JsonProperty(PropertyName="output_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutputVariableName { get; set; } = "";
        

[JsonProperty(PropertyName="fmu_file_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FmuFileName { get; set; } = "";
        

[JsonProperty(PropertyName="fmu_instance_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FmuInstanceName { get; set; } = "";
        

[JsonProperty(PropertyName="fmu_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FmuVariableName { get; set; } = "";
    }
    
    [Description("This objects contains only one value, which is used during the first call of Ener" +
        "gyPlus")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ExternalInterface_FunctionalMockupUnitImport_To_Schedule
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="schedule_type_limits_names", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleTypeLimitsNames { get; set; } = "";
        

[JsonProperty(PropertyName="fmu_file_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FmuFileName { get; set; } = "";
        

[JsonProperty(PropertyName="fmu_instance_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FmuInstanceName { get; set; } = "";
        

[JsonProperty(PropertyName="fmu_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FmuVariableName { get; set; } = "";
        

[Description("Used during the first call of EnergyPlus.")]
[JsonProperty(PropertyName="initial_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InitialValue { get; set; } = null;
    }
    
    [Description("Hardware portion of EMS used to set up actuators in the model that are dynamicall" +
        "y updated from the FMU.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ExternalInterface_FunctionalMockupUnitImport_To_Actuator
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
        

[JsonProperty(PropertyName="fmu_file_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FmuFileName { get; set; } = "";
        

[JsonProperty(PropertyName="fmu_instance_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FmuInstanceName { get; set; } = "";
        

[JsonProperty(PropertyName="fmu_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FmuVariableName { get; set; } = "";
        

[Description("Used during the first call of EnergyPlus.")]
[JsonProperty(PropertyName="initial_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InitialValue { get; set; } = null;
    }
    
    [Description("Declares Erl variable as having global scope No spaces allowed in names used for " +
        "Erl variables")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ExternalInterface_FunctionalMockupUnitImport_To_Variable
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="fmu_file_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FmuFileName { get; set; } = "";
        

[JsonProperty(PropertyName="fmu_instance_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FmuInstanceName { get; set; } = "";
        

[JsonProperty(PropertyName="fmu_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FmuVariableName { get; set; } = "";
        

[Description("Used during the first call of EnergyPlus.")]
[JsonProperty(PropertyName="initial_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InitialValue { get; set; } = null;
    }
    
    [Description("This object declares an FMU input variable")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ExternalInterface_FunctionalMockupUnitExport_From_Variable
    {
        

[JsonProperty(PropertyName="output_variable_index_key_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutputVariableIndexKeyName { get; set; } = "";
        

[JsonProperty(PropertyName="output_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutputVariableName { get; set; } = "";
        

[JsonProperty(PropertyName="fmu_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FmuVariableName { get; set; } = "";
    }
    
    [Description("This objects contains only one value, which is used during the first call of Ener" +
        "gyPlus")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ExternalInterface_FunctionalMockupUnitExport_To_Schedule
    {
        

[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="schedule_type_limits_names", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleTypeLimitsNames { get; set; } = "";
        

[JsonProperty(PropertyName="fmu_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FmuVariableName { get; set; } = "";
        

[Description("Used during the first call of EnergyPlus.")]
[JsonProperty(PropertyName="initial_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InitialValue { get; set; } = null;
    }
    
    [Description("Hardware portion of EMS used to set up actuators in the model that are dynamicall" +
        "y updated from the FMU.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ExternalInterface_FunctionalMockupUnitExport_To_Actuator
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
        

[JsonProperty(PropertyName="fmu_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FmuVariableName { get; set; } = "";
        

[Description("Used during the first call of EnergyPlus.")]
[JsonProperty(PropertyName="initial_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InitialValue { get; set; } = null;
    }
    
    [Description("Declares Erl variable as having global scope No spaces allowed in names used for " +
        "Erl variables")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ExternalInterface_FunctionalMockupUnitExport_To_Variable
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="fmu_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FmuVariableName { get; set; } = "";
        

[Description("Used during the first call of EnergyPlus.")]
[JsonProperty(PropertyName="initial_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InitialValue { get; set; } = null;
    }
}
