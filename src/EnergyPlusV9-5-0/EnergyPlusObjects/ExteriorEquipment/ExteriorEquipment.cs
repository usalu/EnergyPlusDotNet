namespace EnergyPlus.ExteriorEquipment
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
    
    
    [Description("only used for Meter type reporting, does not affect building loads")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Exterior_Lights
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("units in schedule should be fraction applied to capacity of the exterior lights e" +
    "quipment, generally (0.0 - 1.0)")]
[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="design_level", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignLevel { get; set; } = null;
        

[Description("Astronomical Clock option overrides schedule to turn lights off when sun is up")]
[JsonProperty(PropertyName="control_option", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Exterior_Lights_ControlOption ControlOption { get; set; } = (Exterior_Lights_ControlOption)Enum.Parse(typeof(Exterior_Lights_ControlOption), "AstronomicalClock");
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    public enum Exterior_Lights_ControlOption
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AstronomicalClock")]
        AstronomicalClock = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ScheduleNameOnly")]
        ScheduleNameOnly = 1,
    }
    
    [Description("only used for Meter type reporting, does not affect building loads")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Exterior_FuelEquipment
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="fuel_use_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Exterior_FuelEquipment_FuelUseType FuelUseType { get; set; } = (Exterior_FuelEquipment_FuelUseType)Enum.Parse(typeof(Exterior_FuelEquipment_FuelUseType), "Coal");
        

[Description("units in schedule should be fraction applied to capacity of the exterior fuel equ" +
    "ipment, generally (0.0 - 1.0)")]
[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="design_level", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignLevel { get; set; } = null;
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    public enum Exterior_FuelEquipment_FuelUseType
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
        
        [System.Runtime.Serialization.EnumMember(Value="NaturalGas")]
        NaturalGas = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel1")]
        OtherFuel1 = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel2")]
        OtherFuel2 = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="Propane")]
        Propane = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="Steam")]
        Steam = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Water")]
        Water = 13,
    }
    
    [Description("only used for Meter type reporting, does not affect building loads")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Exterior_WaterEquipment
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="fuel_use_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Exterior_WaterEquipment_FuelUseType FuelUseType { get; set; } = (Exterior_WaterEquipment_FuelUseType)Enum.Parse(typeof(Exterior_WaterEquipment_FuelUseType), "Water");
        

[Description("units in Schedule should be fraction applied to capacity of the exterior water eq" +
    "uipment, generally (0.0 - 1.0)")]
[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="design_level", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignLevel { get; set; } = null;
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    public enum Exterior_WaterEquipment_FuelUseType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Water")]
        Water = 1,
    }
}
