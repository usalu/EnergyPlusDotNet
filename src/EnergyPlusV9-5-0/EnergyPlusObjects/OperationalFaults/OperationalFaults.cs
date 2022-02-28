namespace EnergyPlus.OperationalFaults
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
    
    
    [Description("This object describes outdoor air temperature sensor offset")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class FaultModel_TemperatureSensorOffset_OutdoorAir
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="severity_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SeverityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="controller_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public FaultModel_TemperatureSensorOffset_OutdoorAir_ControllerObjectType ControllerObjectType { get; set; } = (FaultModel_TemperatureSensorOffset_OutdoorAir_ControllerObjectType)Enum.Parse(typeof(FaultModel_TemperatureSensorOffset_OutdoorAir_ControllerObjectType), "ControllerOutdoorAir");
        

[JsonProperty(PropertyName="controller_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControllerObjectName { get; set; } = "";
        

[JsonProperty(PropertyName="temperature_sensor_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureSensorOffset { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    public enum FaultModel_TemperatureSensorOffset_OutdoorAir_ControllerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Controller:OutdoorAir")]
        ControllerOutdoorAir = 0,
    }
    
    [Description("This object describes outdoor air humidity sensor offset")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class FaultModel_HumiditySensorOffset_OutdoorAir
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="severity_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SeverityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="controller_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public FaultModel_HumiditySensorOffset_OutdoorAir_ControllerObjectType ControllerObjectType { get; set; } = (FaultModel_HumiditySensorOffset_OutdoorAir_ControllerObjectType)Enum.Parse(typeof(FaultModel_HumiditySensorOffset_OutdoorAir_ControllerObjectType), "ControllerOutdoorAir");
        

[JsonProperty(PropertyName="controller_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControllerObjectName { get; set; } = "";
        

[JsonProperty(PropertyName="humidity_sensor_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumiditySensorOffset { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    public enum FaultModel_HumiditySensorOffset_OutdoorAir_ControllerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Controller:OutdoorAir")]
        ControllerOutdoorAir = 0,
    }
    
    [Description("This object describes outdoor air enthalpy sensor offset")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class FaultModel_EnthalpySensorOffset_OutdoorAir
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="severity_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SeverityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="controller_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public FaultModel_EnthalpySensorOffset_OutdoorAir_ControllerObjectType ControllerObjectType { get; set; } = (FaultModel_EnthalpySensorOffset_OutdoorAir_ControllerObjectType)Enum.Parse(typeof(FaultModel_EnthalpySensorOffset_OutdoorAir_ControllerObjectType), "ControllerOutdoorAir");
        

[JsonProperty(PropertyName="controller_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControllerObjectName { get; set; } = "";
        

[JsonProperty(PropertyName="enthalpy_sensor_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EnthalpySensorOffset { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    public enum FaultModel_EnthalpySensorOffset_OutdoorAir_ControllerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Controller:OutdoorAir")]
        ControllerOutdoorAir = 0,
    }
    
    [Description("This object describes return air temperature sensor offset")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class FaultModel_TemperatureSensorOffset_ReturnAir
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="severity_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SeverityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="controller_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public FaultModel_TemperatureSensorOffset_ReturnAir_ControllerObjectType ControllerObjectType { get; set; } = (FaultModel_TemperatureSensorOffset_ReturnAir_ControllerObjectType)Enum.Parse(typeof(FaultModel_TemperatureSensorOffset_ReturnAir_ControllerObjectType), "ControllerOutdoorAir");
        

[JsonProperty(PropertyName="controller_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControllerObjectName { get; set; } = "";
        

[JsonProperty(PropertyName="temperature_sensor_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureSensorOffset { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    public enum FaultModel_TemperatureSensorOffset_ReturnAir_ControllerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Controller:OutdoorAir")]
        ControllerOutdoorAir = 0,
    }
    
    [Description("This object describes return air enthalpy sensor offset")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class FaultModel_EnthalpySensorOffset_ReturnAir
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="severity_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SeverityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="controller_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public FaultModel_EnthalpySensorOffset_ReturnAir_ControllerObjectType ControllerObjectType { get; set; } = (FaultModel_EnthalpySensorOffset_ReturnAir_ControllerObjectType)Enum.Parse(typeof(FaultModel_EnthalpySensorOffset_ReturnAir_ControllerObjectType), "ControllerOutdoorAir");
        

[JsonProperty(PropertyName="controller_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControllerObjectName { get; set; } = "";
        

[JsonProperty(PropertyName="enthalpy_sensor_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EnthalpySensorOffset { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    public enum FaultModel_EnthalpySensorOffset_ReturnAir_ControllerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Controller:OutdoorAir")]
        ControllerOutdoorAir = 0,
    }
    
    [Description("This object describes fault of chiller supply water temperature sensor offset")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class FaultModel_TemperatureSensorOffset_ChillerSupplyWater
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="severity_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SeverityScheduleName { get; set; } = "";
        

[Description("Enter the type of a chiller object")]
[JsonProperty(PropertyName="chiller_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public FaultModel_TemperatureSensorOffset_ChillerSupplyWater_ChillerObjectType ChillerObjectType { get; set; } = (FaultModel_TemperatureSensorOffset_ChillerSupplyWater_ChillerObjectType)Enum.Parse(typeof(FaultModel_TemperatureSensorOffset_ChillerSupplyWater_ChillerObjectType), "ChillerAbsorption");
        

[Description("Enter the name of a chiller object")]
[JsonProperty(PropertyName="chiller_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ChillerObjectName { get; set; } = "";
        

[JsonProperty(PropertyName="reference_sensor_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReferenceSensorOffset { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    public enum FaultModel_TemperatureSensorOffset_ChillerSupplyWater_ChillerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Chiller:Absorption")]
        ChillerAbsorption = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Chiller:Absorption:Indirect")]
        ChillerAbsorptionIndirect = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Chiller:CombustionTurbine")]
        ChillerCombustionTurbine = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Chiller:ConstantCOP")]
        ChillerConstantCOP = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Chiller:Electric")]
        ChillerElectric = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Chiller:Electric:EIR")]
        ChillerElectricEIR = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Chiller:Electric:ReformulatedEIR")]
        ChillerElectricReformulatedEIR = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="Chiller:EngineDriven")]
        ChillerEngineDriven = 7,
    }
    
    [Description("This object describes fault of coil supply air temperature sensor offset")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class FaultModel_TemperatureSensorOffset_CoilSupplyAir
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="severity_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SeverityScheduleName { get; set; } = "";
        

[Description("Enter the type of the coil affected")]
[JsonProperty(PropertyName="coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public FaultModel_TemperatureSensorOffset_CoilSupplyAir_CoilObjectType CoilObjectType { get; set; } = (FaultModel_TemperatureSensorOffset_CoilSupplyAir_CoilObjectType)Enum.Parse(typeof(FaultModel_TemperatureSensorOffset_CoilSupplyAir_CoilObjectType), "AirLoopHVACUnitarySystem");
        

[Description("Enter the name of the coil affected")]
[JsonProperty(PropertyName="coil_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoilObjectName { get; set; } = "";
        

[Description("Enter the name of controller for the water coil affected Required for water coils" +
    "")]
[JsonProperty(PropertyName="water_coil_controller_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterCoilControllerName { get; set; } = "";
        

[JsonProperty(PropertyName="reference_sensor_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReferenceSensorOffset { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    public enum FaultModel_TemperatureSensorOffset_CoilSupplyAir_CoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AirLoopHVAC:UnitarySystem")]
        AirLoopHVACUnitarySystem = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water")]
        CoilCoolingWater = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water:Detailedgeometry")]
        CoilCoolingWaterDetailedgeometry = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Desuperheater")]
        CoilHeatingDesuperheater = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric")]
        CoilHeatingElectric = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Gas")]
        CoilHeatingGas = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Steam")]
        CoilHeatingSteam = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Water")]
        CoilHeatingWater = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:DX")]
        CoilSystemCoolingDX = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Heating:DX")]
        CoilSystemHeatingDX = 9,
    }
    
    [Description("This object describes fault of condenser supply water temperature sensor offset")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class FaultModel_TemperatureSensorOffset_CondenserSupplyWater
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="severity_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SeverityScheduleName { get; set; } = "";
        

[Description("Enter the type of the cooling tower affected")]
[JsonProperty(PropertyName="cooling_tower_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public FaultModel_TemperatureSensorOffset_CondenserSupplyWater_CoolingTowerObjectType CoolingTowerObjectType { get; set; } = (FaultModel_TemperatureSensorOffset_CondenserSupplyWater_CoolingTowerObjectType)Enum.Parse(typeof(FaultModel_TemperatureSensorOffset_CondenserSupplyWater_CoolingTowerObjectType), "CoolingTowerSingleSpeed");
        

[Description("Enter the name of the cooling tower affected")]
[JsonProperty(PropertyName="cooling_tower_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingTowerObjectName { get; set; } = "";
        

[JsonProperty(PropertyName="reference_sensor_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReferenceSensorOffset { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    public enum FaultModel_TemperatureSensorOffset_CondenserSupplyWater_CoolingTowerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingTower:SingleSpeed")]
        CoolingTowerSingleSpeed = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingTower:TwoSpeed")]
        CoolingTowerTwoSpeed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingTower:VariableSpeed")]
        CoolingTowerVariableSpeed = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingTower:VariableSpeed:MERKEL")]
        CoolingTowerVariableSpeedMERKEL = 3,
    }
    
    [Description("This object describes fault of thermostat offset")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class FaultModel_ThermostatOffset
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Enter the name of a ZoneControl:Thermostat object.")]
[JsonProperty(PropertyName="thermostat_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ThermostatName { get; set; } = "";
        

[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="severity_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SeverityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="reference_thermostat_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReferenceThermostatOffset { get; set; } = Double.Parse("2", CultureInfo.InvariantCulture);
    }
    
    [Description("This object describes fault of humidistat offset")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class FaultModel_HumidistatOffset
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Enter the name of a ZoneControl:Humidistat object.")]
[JsonProperty(PropertyName="humidistat_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HumidistatName { get; set; } = "";
        

[Description("Two types are available: Type ThermostatOffsetIndependent Type ThermostatOffsetDe" +
    "pendent")]
[JsonProperty(PropertyName="humidistat_offset_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public FaultModel_HumidistatOffset_HumidistatOffsetType HumidistatOffsetType { get; set; } = (FaultModel_HumidistatOffset_HumidistatOffsetType)Enum.Parse(typeof(FaultModel_HumidistatOffset_HumidistatOffsetType), "ThermostatOffsetIndependent");
        

[Description("This field is applicable for Type ThermostatOffsetIndependent")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("This field is applicable for Type ThermostatOffsetIndependent")]
[JsonProperty(PropertyName="severity_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SeverityScheduleName { get; set; } = "";
        

[Description("Required field for Type ThermostatOffsetIndependent")]
[JsonProperty(PropertyName="reference_humidistat_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReferenceHumidistatOffset { get; set; } = Double.Parse("5", CultureInfo.InvariantCulture);
        

[Description("Enter the name of a FaultModel:ThermostatOffset object Required field for Type Th" +
    "ermostatOffsetDependent")]
[JsonProperty(PropertyName="related_thermostat_offset_fault_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RelatedThermostatOffsetFaultName { get; set; } = "";
    }
    
    public enum FaultModel_HumidistatOffset_HumidistatOffsetType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatOffsetDependent")]
        ThermostatOffsetDependent = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermostatOffsetIndependent")]
        ThermostatOffsetIndependent = 2,
    }
    
    [Description("This object describes fault of dirty air filters")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class FaultModel_Fouling_AirFilter
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Choose the type of the fan Support for Fan:SystemModel is pending")]
[JsonProperty(PropertyName="fan_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public FaultModel_Fouling_AirFilter_FanObjectType FanObjectType { get; set; } = (FaultModel_Fouling_AirFilter_FanObjectType)Enum.Parse(typeof(FaultModel_Fouling_AirFilter_FanObjectType), "FanConstantVolume");
        

[Description("Enter the name of a fan object")]
[JsonProperty(PropertyName="fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FanName { get; set; } = "";
        

[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("Enter the name of a schedule describing the variations of the fan pressure rise i" +
    "n terms of multipliers to the fan design pressure rise")]
[JsonProperty(PropertyName="pressure_fraction_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PressureFractionScheduleName { get; set; } = "";
        

[Description("The curve describes the relationship between the fan pressure rise and air flow r" +
    "ate")]
[JsonProperty(PropertyName="fan_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FanCurveName { get; set; } = "";
    }
    
    public enum FaultModel_Fouling_AirFilter_FanObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:ConstantVolume")]
        FanConstantVolume = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:OnOff")]
        FanOnOff = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Fan:VariableVolume")]
        FanVariableVolume = 2,
    }
    
    [Description("This object describes the fouling fault of boilers with water-based heat exchange" +
        "rs")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class FaultModel_Fouling_Boiler
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="severity_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SeverityScheduleName { get; set; } = "";
        

[Description("Enter the type of a boiler object The fault applies to the hot-water boilers")]
[JsonProperty(PropertyName="boiler_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public FaultModel_Fouling_Boiler_BoilerObjectType BoilerObjectType { get; set; } = (FaultModel_Fouling_Boiler_BoilerObjectType)Enum.Parse(typeof(FaultModel_Fouling_Boiler_BoilerObjectType), "BoilerHotWater");
        

[Description("Enter the name of a Boiler object")]
[JsonProperty(PropertyName="boiler_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BoilerObjectName { get; set; } = "";
        

[Description("The factor indicates the decrease of the nominal capacity of the boiler It is the" +
    " ratio between the nominal capacity at fouling case and that at fault free case")]
[JsonProperty(PropertyName="fouling_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FoulingFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
    }
    
    public enum FaultModel_Fouling_Boiler_BoilerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Boiler:HotWater")]
        BoilerHotWater = 0,
    }
    
    [Description("This object describes the fouling fault of the wetted coil evaporative cooler")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class FaultModel_Fouling_EvaporativeCooler
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="severity_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SeverityScheduleName { get; set; } = "";
        

[Description("Enter the type of a Evaporative Cooler object The fault applies to the wetted coi" +
    "l evaporative cooler The fault does not apply to direct evaporative coolers or t" +
    "he dry coil indirect evaporative coolers")]
[JsonProperty(PropertyName="evaporative_cooler_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public FaultModel_Fouling_EvaporativeCooler_EvaporativeCoolerObjectType EvaporativeCoolerObjectType { get; set; } = (FaultModel_Fouling_EvaporativeCooler_EvaporativeCoolerObjectType)Enum.Parse(typeof(FaultModel_Fouling_EvaporativeCooler_EvaporativeCoolerObjectType), "EvaporativeCoolerIndirectWetCoil");
        

[Description("Enter the name of aN Evaporative Cooler object")]
[JsonProperty(PropertyName="evaporative_cooler_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EvaporativeCoolerObjectName { get; set; } = "";
        

[Description("The factor indicates the decrease of the indirect stage efficiency It is the rati" +
    "o between the indirect stage efficiency at fouling case and that at fault free c" +
    "ase")]
[JsonProperty(PropertyName="fouling_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FoulingFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
    }
    
    public enum FaultModel_Fouling_EvaporativeCooler_EvaporativeCoolerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="EvaporativeCooler:Indirect:WetCoil")]
        EvaporativeCoolerIndirectWetCoil = 0,
    }
    
    [Description("This object describes the fouling fault of chillers with water-cooled condensers")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class FaultModel_Fouling_Chiller
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="severity_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SeverityScheduleName { get; set; } = "";
        

[Description("Enter the type of a chiller object The fault applies to the chillers with water-c" +
    "ooled condensers")]
[JsonProperty(PropertyName="chiller_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public FaultModel_Fouling_Chiller_ChillerObjectType ChillerObjectType { get; set; } = (FaultModel_Fouling_Chiller_ChillerObjectType)Enum.Parse(typeof(FaultModel_Fouling_Chiller_ChillerObjectType), "ChillerCombustionTurbine");
        

[Description("Enter the name of a chiller object")]
[JsonProperty(PropertyName="chiller_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ChillerObjectName { get; set; } = "";
        

[Description("The factor indicates the decrease of the nominal capacity of the chiller It is th" +
    "e ratio between the nominal capacity at fouling case and that at fault free case" +
    "")]
[JsonProperty(PropertyName="fouling_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FoulingFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
    }
    
    public enum FaultModel_Fouling_Chiller_ChillerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Chiller:CombustionTurbine")]
        ChillerCombustionTurbine = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Chiller:ConstantCOP")]
        ChillerConstantCOP = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Chiller:Electric")]
        ChillerElectric = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Chiller:Electric:EIR")]
        ChillerElectricEIR = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Chiller:Electric:ReformulatedEIR")]
        ChillerElectricReformulatedEIR = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Chiller:EngineDriven")]
        ChillerEngineDriven = 5,
    }
    
    [Description("This object describes the fault of fouling cooling towers")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class FaultModel_Fouling_CoolingTower
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="severity_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SeverityScheduleName { get; set; } = "";
        

[Description("Enter the type of the cooling tower affected")]
[JsonProperty(PropertyName="cooling_tower_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public FaultModel_Fouling_CoolingTower_CoolingTowerObjectType CoolingTowerObjectType { get; set; } = (FaultModel_Fouling_CoolingTower_CoolingTowerObjectType)Enum.Parse(typeof(FaultModel_Fouling_CoolingTower_CoolingTowerObjectType), "CoolingTowerSingleSpeed");
        

[Description("Enter the name of the cooling tower affected")]
[JsonProperty(PropertyName="cooling_tower_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingTowerObjectName { get; set; } = "";
        

[Description("Factor describing the tower UA reduction due to fouling It is the ratio between t" +
    "he UA value at fouling case and that at fault free case It is applicable to both" +
    " the Design UA and Free Convection UA of the tower")]
[JsonProperty(PropertyName="reference_ua_reduction_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReferenceUaReductionFactor { get; set; } = null;
    }
    
    public enum FaultModel_Fouling_CoolingTower_CoolingTowerObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingTower:SingleSpeed")]
        CoolingTowerSingleSpeed = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingTower:TwoSpeed")]
        CoolingTowerTwoSpeed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingTower:VariableSpeed:MERKEL")]
        CoolingTowerVariableSpeedMERKEL = 2,
    }
    
    [Description("This object describes fouling water heating or cooling coils")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class FaultModel_Fouling_Coil
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoilName { get; set; } = "";
        

[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="severity_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SeverityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="fouling_input_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public FaultModel_Fouling_Coil_FoulingInputMethod FoulingInputMethod { get; set; } = (FaultModel_Fouling_Coil_FoulingInputMethod)Enum.Parse(typeof(FaultModel_Fouling_Coil_FoulingInputMethod), "FouledUARated");
        

[Description("Fouling coil UA value under rating conditions For Fouling Input Method: FouledUAR" +
    "ated")]
[JsonProperty(PropertyName="uafouled", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Uafouled { get; set; } = null;
        

[Description("For Fouling Input Method: FoulingFactor")]
[JsonProperty(PropertyName="water_side_fouling_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterSideFoulingFactor { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("For Fouling Input Method: FoulingFactor")]
[JsonProperty(PropertyName="air_side_fouling_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AirSideFoulingFactor { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("For Fouling Input Method: FoulingFactor")]
[JsonProperty(PropertyName="outside_coil_surface_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutsideCoilSurfaceArea { get; set; } = null;
        

[Description("For Fouling Input Method: FoulingFactor")]
[JsonProperty(PropertyName="inside_to_outside_coil_surface_area_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InsideToOutsideCoilSurfaceAreaRatio { get; set; } = Double.Parse("0.07", CultureInfo.InvariantCulture);
    }
    
    public enum FaultModel_Fouling_Coil_FoulingInputMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FouledUARated")]
        FouledUARated = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FoulingFactor")]
        FoulingFactor = 2,
    }
}
