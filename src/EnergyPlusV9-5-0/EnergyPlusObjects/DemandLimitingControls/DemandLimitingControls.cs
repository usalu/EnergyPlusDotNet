namespace EnergyPlus.DemandLimitingControls
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
    
    
    [Description("a list of meters that can be reported are available after a run on the meter dict" +
        "ionary file (.mdd) if the Output:VariableDictionary has been requested.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class DemandManagerAssignmentList
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="meter_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MeterName { get; set; } = "";
        

[JsonProperty(PropertyName="demand_limit_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DemandLimitScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="demand_limit_safety_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DemandLimitSafetyFraction { get; set; } = null;
        

[Description("This field should reference the same schedule as the month schedule name field of" +
    " the UtilityCost:Tariff object, if used. If blank, defaults to regular divisions" +
    " between months.")]
[JsonProperty(PropertyName="billing_period_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BillingPeriodScheduleName { get; set; } = "";
        

[Description("This field should reference the same schedule as the period schedule name field o" +
    "f the UtilityCost:Tariff object, if used. If blank, defaults to always on peak.")]
[JsonProperty(PropertyName="peak_period_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PeakPeriodScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="demand_window_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DemandWindowLength { get; set; } = null;
        

[JsonProperty(PropertyName="demand_manager_priority", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public DemandManagerAssignmentList_DemandManagerPriority DemandManagerPriority { get; set; } = (DemandManagerAssignmentList_DemandManagerPriority)Enum.Parse(typeof(DemandManagerAssignmentList_DemandManagerPriority), "All");
        

[JsonProperty(PropertyName="manager_data", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DemandLimitingControls.DemandManagerAssignmentList_ManagerData_Item> ManagerData { get; set; } = null;
    }
    
    public enum DemandManagerAssignmentList_DemandManagerPriority
    {
        
        [System.Runtime.Serialization.EnumMember(Value="All")]
        All = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Sequential")]
        Sequential = 1,
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class DemandManagerAssignmentList_ManagerData_Item
    {
        

[JsonProperty(PropertyName="demandmanager_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DemandmanagerObjectType { get; set; } = "";
        

[JsonProperty(PropertyName="demandmanager_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DemandmanagerName { get; set; } = "";
    }
    
    [Description("used for demand limiting Exterior:Lights objects.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class DemandManager_ExteriorLights
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="limit_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public DemandManager_ExteriorLights_LimitControl LimitControl { get; set; } = (DemandManager_ExteriorLights_LimitControl)Enum.Parse(typeof(DemandManager_ExteriorLights_LimitControl), "Fixed");
        

[Description("If blank, duration defaults to the timestep")]
[JsonProperty(PropertyName="minimum_limit_duration", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumLimitDuration { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_limit_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumLimitFraction { get; set; } = null;
        

[Description("Not yet implemented")]
[JsonProperty(PropertyName="limit_step_change", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LimitStepChange { get; set; } = null;
        

[JsonProperty(PropertyName="selection_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public DemandManager_ExteriorLights_SelectionControl SelectionControl { get; set; } = (DemandManager_ExteriorLights_SelectionControl)Enum.Parse(typeof(DemandManager_ExteriorLights_SelectionControl), "All");
        

[Description("If blank, duration defaults to the timestep")]
[JsonProperty(PropertyName="rotation_duration", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RotationDuration { get; set; } = null;
        

[Description("This list is the ExteriorLightsNames object-list")]
[JsonProperty(PropertyName="lights", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Lights { get; set; } = null;
    }
    
    public enum DemandManager_ExteriorLights_LimitControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fixed")]
        Fixed = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Off")]
        Off = 1,
    }
    
    public enum DemandManager_ExteriorLights_SelectionControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="All")]
        All = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="RotateMany")]
        RotateMany = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="RotateOne")]
        RotateOne = 2,
    }
    
    [Description("used for demand limiting Lights objects.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class DemandManager_Lights
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="limit_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public DemandManager_Lights_LimitControl LimitControl { get; set; } = (DemandManager_Lights_LimitControl)Enum.Parse(typeof(DemandManager_Lights_LimitControl), "Fixed");
        

[Description("If blank, duration defaults to the timestep")]
[JsonProperty(PropertyName="minimum_limit_duration", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumLimitDuration { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_limit_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumLimitFraction { get; set; } = null;
        

[Description("Not yet implemented")]
[JsonProperty(PropertyName="limit_step_change", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LimitStepChange { get; set; } = null;
        

[JsonProperty(PropertyName="selection_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public DemandManager_Lights_SelectionControl SelectionControl { get; set; } = (DemandManager_Lights_SelectionControl)Enum.Parse(typeof(DemandManager_Lights_SelectionControl), "All");
        

[Description("If blank, duration defaults to the timestep")]
[JsonProperty(PropertyName="rotation_duration", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RotationDuration { get; set; } = null;
        

[Description("This list is the LightsNames object-list")]
[JsonProperty(PropertyName="lights", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Lights { get; set; } = null;
    }
    
    public enum DemandManager_Lights_LimitControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fixed")]
        Fixed = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Off")]
        Off = 1,
    }
    
    public enum DemandManager_Lights_SelectionControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="All")]
        All = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="RotateMany")]
        RotateMany = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="RotateOne")]
        RotateOne = 2,
    }
    
    [Description("used for demand limiting ElectricEquipment objects.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class DemandManager_ElectricEquipment
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="limit_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public DemandManager_ElectricEquipment_LimitControl LimitControl { get; set; } = (DemandManager_ElectricEquipment_LimitControl)Enum.Parse(typeof(DemandManager_ElectricEquipment_LimitControl), "Fixed");
        

[Description("If blank, duration defaults to the timestep")]
[JsonProperty(PropertyName="minimum_limit_duration", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumLimitDuration { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_limit_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumLimitFraction { get; set; } = null;
        

[Description("Not yet implemented")]
[JsonProperty(PropertyName="limit_step_change", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LimitStepChange { get; set; } = null;
        

[JsonProperty(PropertyName="selection_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public DemandManager_ElectricEquipment_SelectionControl SelectionControl { get; set; } = (DemandManager_ElectricEquipment_SelectionControl)Enum.Parse(typeof(DemandManager_ElectricEquipment_SelectionControl), "All");
        

[Description("If blank, duration defaults to the timestep")]
[JsonProperty(PropertyName="rotation_duration", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RotationDuration { get; set; } = null;
        

[Description("This list is the ElectricEquipmentNames object-list")]
[JsonProperty(PropertyName="equipment", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Equipment { get; set; } = null;
    }
    
    public enum DemandManager_ElectricEquipment_LimitControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fixed")]
        Fixed = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Off")]
        Off = 1,
    }
    
    public enum DemandManager_ElectricEquipment_SelectionControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="All")]
        All = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="RotateMany")]
        RotateMany = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="RotateOne")]
        RotateOne = 2,
    }
    
    [Description("used for demand limiting ZoneControl:Thermostat objects.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class DemandManager_Thermostats
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="reset_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public DemandManager_Thermostats_ResetControl ResetControl { get; set; } = (DemandManager_Thermostats_ResetControl)Enum.Parse(typeof(DemandManager_Thermostats_ResetControl), "Fixed");
        

[Description("If blank, duration defaults to the timestep")]
[JsonProperty(PropertyName="minimum_reset_duration", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumResetDuration { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_heating_setpoint_reset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumHeatingSetpointReset { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_cooling_setpoint_reset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCoolingSetpointReset { get; set; } = null;
        

[Description("Not yet implemented")]
[JsonProperty(PropertyName="reset_step_change", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ResetStepChange { get; set; } = null;
        

[JsonProperty(PropertyName="selection_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public DemandManager_Thermostats_SelectionControl SelectionControl { get; set; } = (DemandManager_Thermostats_SelectionControl)Enum.Parse(typeof(DemandManager_Thermostats_SelectionControl), "All");
        

[Description("If blank, duration defaults to the timestep")]
[JsonProperty(PropertyName="rotation_duration", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RotationDuration { get; set; } = null;
        

[Description("This list is the ZoneControlThermostaticNames object-list")]
[JsonProperty(PropertyName="thermostats", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Thermostats { get; set; } = null;
    }
    
    public enum DemandManager_Thermostats_ResetControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fixed")]
        Fixed = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Off")]
        Off = 1,
    }
    
    public enum DemandManager_Thermostats_SelectionControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="All")]
        All = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="RotateMany")]
        RotateMany = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="RotateOne")]
        RotateOne = 2,
    }
    
    [Description("used for demand limiting Controller:OutdoorAir objects.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class DemandManager_Ventilation
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this demand manager. Schedule value > 0 means the " +
    "demand manager is available. If this field is blank, the DR is always available." +
    "")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="limit_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public DemandManager_Ventilation_LimitControl LimitControl { get; set; } = (DemandManager_Ventilation_LimitControl)Enum.Parse(typeof(DemandManager_Ventilation_LimitControl), "FixedRate");
        

[Description("If blank, duration defaults to the timestep")]
[JsonProperty(PropertyName="minimum_limit_duration", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumLimitDuration { get; set; } = null;
        

[Description("Used in case when Limit strategy is set to FixedRate")]
[JsonProperty(PropertyName="fixed_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FixedRate { get; set; } = null;
        

[Description("Used in case when Limit Control is set to ReductionRatio")]
[JsonProperty(PropertyName="reduction_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReductionRatio { get; set; } = null;
        

[Description("Not yet implemented")]
[JsonProperty(PropertyName="limit_step_change", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LimitStepChange { get; set; } = null;
        

[JsonProperty(PropertyName="selection_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public DemandManager_Ventilation_SelectionControl SelectionControl { get; set; } = (DemandManager_Ventilation_SelectionControl)Enum.Parse(typeof(DemandManager_Ventilation_SelectionControl), "All");
        

[Description("If blank, duration defaults to the timestep")]
[JsonProperty(PropertyName="rotation_duration", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RotationDuration { get; set; } = null;
        

[Description("This list is the OAControllerNames object-list")]
[JsonProperty(PropertyName="controllers", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Controllers { get; set; } = null;
    }
    
    public enum DemandManager_Ventilation_LimitControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="FixedRate")]
        FixedRate = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Off")]
        Off = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ReductionRatio")]
        ReductionRatio = 2,
    }
    
    public enum DemandManager_Ventilation_SelectionControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="All")]
        All = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="RotateMany")]
        RotateMany = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="RotateOne")]
        RotateOne = 3,
    }
}
