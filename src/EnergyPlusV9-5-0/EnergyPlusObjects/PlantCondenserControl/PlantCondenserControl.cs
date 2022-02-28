namespace EnergyPlus.PlantCondenserControl
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
    
    
    [Description(@"List plant equipment in order of operating priority, 1st in list will be used 1st, etc Use only plant equipment in this list. If no equipment object types and equipment names are specified, then the corresponding PlantEquipmentOperation:* object will assume all available plant equipment for the loop should be OFF (not operate) within the specified lower/upper limit.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PlantEquipmentList
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="equipment", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentList_Equipment_Item> Equipment { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PlantEquipmentList_Equipment_Item
    {
        

[JsonProperty(PropertyName="equipment_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EquipmentObjectType { get; set; } = "";
        

[JsonProperty(PropertyName="equipment_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EquipmentName { get; set; } = "";
    }
    
    [Description(@"List condenser equipment in order of operating priority, 1st in list will be used 1st, etc Use only condenser equipment in this list. If no equipment object types and equipment names are specified, then the corresponding PlantEquipmentOperation:* object will assume all available condenser equipment for the loop should be OFF (not operate) within the specified lower/upper limit.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class CondenserEquipmentList
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="equipment", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.CondenserEquipmentList_Equipment_Item> Equipment { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class CondenserEquipmentList_Equipment_Item
    {
        

[JsonProperty(PropertyName="equipment_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EquipmentObjectType { get; set; } = "";
        

[JsonProperty(PropertyName="equipment_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EquipmentName { get; set; } = "";
    }
    
    [Description("Plant equipment operation scheme for uncontrolled operation. Specifies a group of" +
        " equipment that runs if the loop is active, unless turned off by the loop flow r" +
        "esolver to maintain continuity in the fluid loop.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PlantEquipmentOperation_Uncontrolled
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EquipmentListName { get; set; } = "";
    }
    
    [Description("Plant equipment operation scheme for cooling load range operation. Specifies one " +
        "or more groups of equipment which are available to operate for successive coolin" +
        "g load ranges.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PlantEquipmentOperation_CoolingLoad
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="load_range_1_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange1LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="load_range_1_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange1UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_1_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range1EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="load_range_2_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange2LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="load_range_2_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange2UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_2_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range2EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="load_range_3_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange3LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="load_range_3_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange3UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_3_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range3EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="load_range_4_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange4LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="load_range_4_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange4UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_4_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range4EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="load_range_5_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange5LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="load_range_5_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange5UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_5_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range5EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="load_range_6_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange6LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="load_range_6_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange6UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_6_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range6EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="load_range_7_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange7LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="load_range_7_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange7UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_7_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range7EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="load_range_8_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange8LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="load_range_8_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange8UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_8_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range8EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="load_range_9_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange9LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="load_range_9_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange9UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_9_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range9EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="load_range_10_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange10LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="load_range_10_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange10UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_10_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range10EquipmentListName { get; set; } = "";
    }
    
    [Description("Plant equipment operation scheme for heating load range operation. Specifies one " +
        "or more groups of equipment which are available to operate for successive heatin" +
        "g load ranges.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PlantEquipmentOperation_HeatingLoad
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="load_range_1_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange1LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="load_range_1_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange1UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_1_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range1EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="load_range_2_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange2LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="load_range_2_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange2UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_2_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range2EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="load_range_3_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange3LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="load_range_3_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange3UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_3_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range3EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="load_range_4_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange4LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="load_range_4_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange4UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_4_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range4EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="load_range_5_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange5LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="load_range_5_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange5UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_5_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range5EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="load_range_6_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange6LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="load_range_6_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange6UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_6_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range6EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="load_range_7_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange7LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="load_range_7_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange7UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_7_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range7EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="load_range_8_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange8LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="load_range_8_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange8UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_8_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range8EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="load_range_9_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange9LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="load_range_9_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange9UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_9_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range9EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="load_range_10_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange10LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="load_range_10_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadRange10UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_10_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range10EquipmentListName { get; set; } = "";
    }
    
    [Description("Plant equipment operation scheme for outdoor dry-bulb temperature range operation" +
        ". Specifies one or more groups of equipment which are available to operate for s" +
        "uccessive outdoor dry-bulb temperature ranges.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PlantEquipmentOperation_OutdoorDryBulb
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="dry_bulb_temperature_range_1_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureRange1LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dry_bulb_temperature_range_1_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureRange1UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_1_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range1EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dry_bulb_temperature_range_2_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureRange2LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dry_bulb_temperature_range_2_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureRange2UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_2_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range2EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dry_bulb_temperature_range_3_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureRange3LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dry_bulb_temperature_range_3_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureRange3UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_3_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range3EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dry_bulb_temperature_range_4_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureRange4LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dry_bulb_temperature_range_4_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureRange4UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_4_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range4EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dry_bulb_temperature_range_5_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureRange5LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dry_bulb_temperature_range_5_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureRange5UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_5_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range5EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dry_bulb_temperature_range_6_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureRange6LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dry_bulb_temperature_range_6_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureRange6UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_6_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range6EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dry_bulb_temperature_range_7_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureRange7LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dry_bulb_temperature_range_7_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureRange7UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_7_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range7EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dry_bulb_temperature_range_8_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureRange8LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dry_bulb_temperature_range_8_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureRange8UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_8_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range8EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dry_bulb_temperature_range_9_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureRange9LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dry_bulb_temperature_range_9_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureRange9UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_9_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range9EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dry_bulb_temperature_range_10_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureRange10LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dry_bulb_temperature_range_10_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureRange10UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_10_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range10EquipmentListName { get; set; } = "";
    }
    
    [Description("Plant equipment operation scheme for outdoor wet-bulb temperature range operation" +
        ". Specifies one or more groups of equipment which are available to operate for s" +
        "uccessive outdoor wet-bulb temperature ranges.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PlantEquipmentOperation_OutdoorWetBulb
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="wet_bulb_temperature_range_1_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureRange1LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="wet_bulb_temperature_range_1_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureRange1UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_1_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range1EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="wet_bulb_temperature_range_2_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureRange2LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="wet_bulb_temperature_range_2_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureRange2UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_2_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range2EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="wet_bulb_temperature_range_3_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureRange3LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="wet_bulb_temperature_range_3_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureRange3UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_3_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range3EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="wet_bulb_temperature_range_4_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureRange4LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="wet_bulb_temperature_range_4_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureRange4UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_4_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range4EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="wet_bulb_temperature_range_5_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureRange5LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="wet_bulb_temperature_range_5_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureRange5UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_5_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range5EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="wet_bulb_temperature_range_6_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureRange6LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="wet_bulb_temperature_range_6_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureRange6UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_6_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range6EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="wet_bulb_temperature_range_7_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureRange7LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="wet_bulb_temperature_range_7_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureRange7UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_7_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range7EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="wet_bulb_temperature_range_8_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureRange8LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="wet_bulb_temperature_range_8_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureRange8UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_8_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range8EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="wet_bulb_temperature_range_9_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureRange9LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="wet_bulb_temperature_range_9_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureRange9UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_9_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range9EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="wet_bulb_temperature_range_10_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureRange10LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="wet_bulb_temperature_range_10_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureRange10UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_10_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range10EquipmentListName { get; set; } = "";
    }
    
    [Description("Plant equipment operation scheme for outdoor relative humidity range operation. S" +
        "pecifies one or more groups of equipment which are available to operate for succ" +
        "essive outdoor relative humidity ranges.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PlantEquipmentOperation_OutdoorRelativeHumidity
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="relative_humidity_range_1_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityRange1LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="relative_humidity_range_1_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityRange1UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_1_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range1EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="relative_humidity_range_2_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityRange2LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="relative_humidity_range_2_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityRange2UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_2_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range2EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="relative_humidity_range_3_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityRange3LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="relative_humidity_range_3_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityRange3UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_3_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range3EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="relative_humidity_range_4_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityRange4LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="relative_humidity_range_4_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityRange4UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_4_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range4EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="relative_humidity_range_5_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityRange5LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="relative_humidity_range_5_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityRange5UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_5_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range5EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="relative_humidity_range_6_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityRange6LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="relative_humidity_range_6_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityRange6UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_6_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range6EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="relative_humidity_range_7_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityRange7LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="relative_humidity_range_7_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityRange7UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_7_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range7EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="relative_humidity_range_8_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityRange8LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="relative_humidity_range_8_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityRange8UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_8_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range8EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="relative_humidity_range_9_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityRange9LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="relative_humidity_range_9_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityRange9UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_9_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range9EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="relative_humidity_range_10_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityRange10LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="relative_humidity_range_10_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityRange10UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_10_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range10EquipmentListName { get; set; } = "";
    }
    
    [Description("Plant equipment operation scheme for outdoor dewpoint temperature range operation" +
        ". Specifies one or more groups of equipment which are available to operate for s" +
        "uccessive outdoor dewpoint temperature ranges.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PlantEquipmentOperation_OutdoorDewpoint
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="dewpoint_temperature_range_1_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureRange1LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dewpoint_temperature_range_1_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureRange1UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_1_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range1EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dewpoint_temperature_range_2_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureRange2LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dewpoint_temperature_range_2_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureRange2UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_2_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range2EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dewpoint_temperature_range_3_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureRange3LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dewpoint_temperature_range_3_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureRange3UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_3_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range3EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dewpoint_temperature_range_4_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureRange4LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dewpoint_temperature_range_4_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureRange4UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_4_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range4EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dewpoint_temperature_range_5_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureRange5LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dewpoint_temperature_range_5_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureRange5UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_5_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range5EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dewpoint_temperature_range_6_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureRange6LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dewpoint_temperature_range_6_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureRange6UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_6_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range6EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dewpoint_temperature_range_7_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureRange7LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dewpoint_temperature_range_7_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureRange7UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_7_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range7EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dewpoint_temperature_range_8_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureRange8LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dewpoint_temperature_range_8_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureRange8UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_8_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range8EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dewpoint_temperature_range_9_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureRange9LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dewpoint_temperature_range_9_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureRange9UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_9_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range9EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dewpoint_temperature_range_10_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureRange10LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dewpoint_temperature_range_10_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureRange10UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_10_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range10EquipmentListName { get; set; } = "";
    }
    
    [Description("Plant equipment operation scheme for component setpoint operation. Specifies one " +
        "or pieces of equipment which are controlled to meet the temperature setpoint at " +
        "the component outlet node.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PlantEquipmentOperation_ComponentSetpoint
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="equipment_1_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Equipment1ObjectType { get; set; } = "";
        

[JsonProperty(PropertyName="equipment_1_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Equipment1Name { get; set; } = "";
        

[JsonProperty(PropertyName="demand_calculation_1_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DemandCalculation1NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="setpoint_1_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Setpoint1NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_1_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> Component1FlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="operation_1_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ComponentSetpoint_Operation1Type Operation1Type { get; set; } = (PlantEquipmentOperation_ComponentSetpoint_Operation1Type)Enum.Parse(typeof(PlantEquipmentOperation_ComponentSetpoint_Operation1Type), "Cooling");
        

[JsonProperty(PropertyName="equipment_2_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Equipment2ObjectType { get; set; } = "";
        

[JsonProperty(PropertyName="equipment_2_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Equipment2Name { get; set; } = "";
        

[JsonProperty(PropertyName="demand_calculation_2_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DemandCalculation2NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="setpoint_2_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Setpoint2NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_2_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> Component2FlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="operation_2_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ComponentSetpoint_Operation2Type Operation2Type { get; set; } = (PlantEquipmentOperation_ComponentSetpoint_Operation2Type)Enum.Parse(typeof(PlantEquipmentOperation_ComponentSetpoint_Operation2Type), "Cooling");
        

[JsonProperty(PropertyName="equipment_3_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Equipment3ObjectType { get; set; } = "";
        

[JsonProperty(PropertyName="equipment_3_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Equipment3Name { get; set; } = "";
        

[JsonProperty(PropertyName="demand_calculation_3_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DemandCalculation3NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="setpoint_3_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Setpoint3NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_3_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> Component3FlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="operation_3_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ComponentSetpoint_Operation3Type Operation3Type { get; set; } = (PlantEquipmentOperation_ComponentSetpoint_Operation3Type)Enum.Parse(typeof(PlantEquipmentOperation_ComponentSetpoint_Operation3Type), "Cooling");
        

[JsonProperty(PropertyName="equipment_4_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Equipment4ObjectType { get; set; } = "";
        

[JsonProperty(PropertyName="equipment_4_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Equipment4Name { get; set; } = "";
        

[JsonProperty(PropertyName="demand_calculation_4_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DemandCalculation4NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="setpoint_4_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Setpoint4NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_4_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> Component4FlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="operation_4_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ComponentSetpoint_Operation4Type Operation4Type { get; set; } = (PlantEquipmentOperation_ComponentSetpoint_Operation4Type)Enum.Parse(typeof(PlantEquipmentOperation_ComponentSetpoint_Operation4Type), "Cooling");
        

[JsonProperty(PropertyName="equipment_5_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Equipment5ObjectType { get; set; } = "";
        

[JsonProperty(PropertyName="equipment_5_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Equipment5Name { get; set; } = "";
        

[JsonProperty(PropertyName="demand_calculation_5_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DemandCalculation5NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="setpoint_5_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Setpoint5NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_5_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> Component5FlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="operation_5_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ComponentSetpoint_Operation5Type Operation5Type { get; set; } = (PlantEquipmentOperation_ComponentSetpoint_Operation5Type)Enum.Parse(typeof(PlantEquipmentOperation_ComponentSetpoint_Operation5Type), "Cooling");
        

[JsonProperty(PropertyName="equipment_6_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Equipment6ObjectType { get; set; } = "";
        

[JsonProperty(PropertyName="equipment_6_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Equipment6Name { get; set; } = "";
        

[JsonProperty(PropertyName="demand_calculation_6_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DemandCalculation6NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="setpoint_6_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Setpoint6NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_6_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> Component6FlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="operation_6_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ComponentSetpoint_Operation6Type Operation6Type { get; set; } = (PlantEquipmentOperation_ComponentSetpoint_Operation6Type)Enum.Parse(typeof(PlantEquipmentOperation_ComponentSetpoint_Operation6Type), "Cooling");
        

[JsonProperty(PropertyName="equipment_7_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Equipment7ObjectType { get; set; } = "";
        

[JsonProperty(PropertyName="equipment_7_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Equipment7Name { get; set; } = "";
        

[JsonProperty(PropertyName="demand_calculation_7_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DemandCalculation7NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="setpoint_7_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Setpoint7NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_7_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> Component7FlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="operation_7_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ComponentSetpoint_Operation7Type Operation7Type { get; set; } = (PlantEquipmentOperation_ComponentSetpoint_Operation7Type)Enum.Parse(typeof(PlantEquipmentOperation_ComponentSetpoint_Operation7Type), "Cooling");
        

[JsonProperty(PropertyName="equipment_8_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Equipment8ObjectType { get; set; } = "";
        

[JsonProperty(PropertyName="equipment_8_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Equipment8Name { get; set; } = "";
        

[JsonProperty(PropertyName="demand_calculation_8_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DemandCalculation8NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="setpoint_8_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Setpoint8NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_8_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> Component8FlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="operation_8_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ComponentSetpoint_Operation8Type Operation8Type { get; set; } = (PlantEquipmentOperation_ComponentSetpoint_Operation8Type)Enum.Parse(typeof(PlantEquipmentOperation_ComponentSetpoint_Operation8Type), "Cooling");
        

[JsonProperty(PropertyName="equipment_9_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Equipment9ObjectType { get; set; } = "";
        

[JsonProperty(PropertyName="equipment_9_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Equipment9Name { get; set; } = "";
        

[JsonProperty(PropertyName="demand_calculation_9_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DemandCalculation9NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="setpoint_9_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Setpoint9NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_9_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> Component9FlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="operation_9_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ComponentSetpoint_Operation9Type Operation9Type { get; set; } = (PlantEquipmentOperation_ComponentSetpoint_Operation9Type)Enum.Parse(typeof(PlantEquipmentOperation_ComponentSetpoint_Operation9Type), "Cooling");
        

[JsonProperty(PropertyName="equipment_10_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Equipment10ObjectType { get; set; } = "";
        

[JsonProperty(PropertyName="equipment_10_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Equipment10Name { get; set; } = "";
        

[JsonProperty(PropertyName="demand_calculation_10_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DemandCalculation10NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="setpoint_10_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Setpoint10NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_10_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> Component10FlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="operation_10_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ComponentSetpoint_Operation10Type Operation10Type { get; set; } = (PlantEquipmentOperation_ComponentSetpoint_Operation10Type)Enum.Parse(typeof(PlantEquipmentOperation_ComponentSetpoint_Operation10Type), "Cooling");
    }
    
    public enum PlantEquipmentOperation_ComponentSetpoint_Operation1Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dual")]
        Dual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 2,
    }
    
    public enum PlantEquipmentOperation_ComponentSetpoint_Operation2Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dual")]
        Dual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 2,
    }
    
    public enum PlantEquipmentOperation_ComponentSetpoint_Operation3Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dual")]
        Dual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 2,
    }
    
    public enum PlantEquipmentOperation_ComponentSetpoint_Operation4Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dual")]
        Dual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 2,
    }
    
    public enum PlantEquipmentOperation_ComponentSetpoint_Operation5Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dual")]
        Dual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 2,
    }
    
    public enum PlantEquipmentOperation_ComponentSetpoint_Operation6Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dual")]
        Dual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 2,
    }
    
    public enum PlantEquipmentOperation_ComponentSetpoint_Operation7Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dual")]
        Dual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 2,
    }
    
    public enum PlantEquipmentOperation_ComponentSetpoint_Operation8Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dual")]
        Dual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 2,
    }
    
    public enum PlantEquipmentOperation_ComponentSetpoint_Operation9Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dual")]
        Dual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 2,
    }
    
    public enum PlantEquipmentOperation_ComponentSetpoint_Operation10Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dual")]
        Dual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 2,
    }
    
    [Description("Plant equipment operation scheme for simpler input to control thermal (ice) energ" +
        "y storage systems. It replaces a host of setpoint managers with simple, single i" +
        "nput values. For more complex controls, use the ComponentSetpoint scheme.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PlantEquipmentOperation_ThermalEnergyStorage
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="on_peak_schedule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OnPeakSchedule { get; set; } = "";
        

[JsonProperty(PropertyName="charging_availability_schedule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ChargingAvailabilitySchedule { get; set; } = "";
        

[Description("Single temperature for chiller outlet when not in cooling season or during on-pea" +
    "k cooling (discharge)")]
[JsonProperty(PropertyName="non_charging_chilled_water_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NonChargingChilledWaterTemperature { get; set; } = null;
        

[Description("Single temperature for chiller outlet when off-peak during cooling season (chargi" +
    "ng)")]
[JsonProperty(PropertyName="charging_chilled_water_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ChargingChilledWaterTemperature { get; set; } = null;
        

[Description("This field is the type of object and should either be a chiller or some ice stora" +
    "ge equipment.")]
[JsonProperty(PropertyName="component_1_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ThermalEnergyStorage_Component1ObjectType Component1ObjectType { get; set; } = (PlantEquipmentOperation_ThermalEnergyStorage_Component1ObjectType)Enum.Parse(typeof(PlantEquipmentOperation_ThermalEnergyStorage_Component1ObjectType), "ChillerAbsorption");
        

[Description("This field is the name of either the chiller or ice storage equipment on the loop" +
    ".")]
[JsonProperty(PropertyName="component_1_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component1Name { get; set; } = "";
        

[Description("This field is the name of the inlet node for the component defined in the two pre" +
    "vious input fields.")]
[JsonProperty(PropertyName="component_1_demand_calculation_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component1DemandCalculationNodeName { get; set; } = "";
        

[Description("This field is the name of the outlet node for the component listed above.")]
[JsonProperty(PropertyName="component_1_setpoint_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component1SetpointNodeName { get; set; } = "";
        

[Description("This field is the flow rate for the component listed above.")]
[JsonProperty(PropertyName="component_1_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> Component1FlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("This field is the operation type for the component listed above. For this plant e" +
    "quipment operation scheme, \"Cooling\" should be selected for chiller equipment wh" +
    "ile ice storage equipment should be defined as \"Dual\".")]
[JsonProperty(PropertyName="component_1_operation_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ThermalEnergyStorage_Component1OperationType Component1OperationType { get; set; } = (PlantEquipmentOperation_ThermalEnergyStorage_Component1OperationType)Enum.Parse(typeof(PlantEquipmentOperation_ThermalEnergyStorage_Component1OperationType), "Cooling");
        

[JsonProperty(PropertyName="component_2_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ThermalEnergyStorage_Component2ObjectType Component2ObjectType { get; set; } = (PlantEquipmentOperation_ThermalEnergyStorage_Component2ObjectType)Enum.Parse(typeof(PlantEquipmentOperation_ThermalEnergyStorage_Component2ObjectType), "ChillerAbsorption");
        

[JsonProperty(PropertyName="component_2_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component2Name { get; set; } = "";
        

[JsonProperty(PropertyName="component_2_demand_calculation_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component2DemandCalculationNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_2_setpoint_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component2SetpointNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_2_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> Component2FlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="component_2_operation_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ThermalEnergyStorage_Component2OperationType Component2OperationType { get; set; } = (PlantEquipmentOperation_ThermalEnergyStorage_Component2OperationType)Enum.Parse(typeof(PlantEquipmentOperation_ThermalEnergyStorage_Component2OperationType), "Cooling");
        

[JsonProperty(PropertyName="component_3_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ThermalEnergyStorage_Component3ObjectType Component3ObjectType { get; set; } = (PlantEquipmentOperation_ThermalEnergyStorage_Component3ObjectType)Enum.Parse(typeof(PlantEquipmentOperation_ThermalEnergyStorage_Component3ObjectType), "ChillerAbsorption");
        

[JsonProperty(PropertyName="component_3_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component3Name { get; set; } = "";
        

[JsonProperty(PropertyName="component_3_demand_calculation_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component3DemandCalculationNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_3_setpoint_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component3SetpointNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_3_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> Component3FlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="component_3_operation_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ThermalEnergyStorage_Component3OperationType Component3OperationType { get; set; } = (PlantEquipmentOperation_ThermalEnergyStorage_Component3OperationType)Enum.Parse(typeof(PlantEquipmentOperation_ThermalEnergyStorage_Component3OperationType), "Cooling");
        

[JsonProperty(PropertyName="component_4_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ThermalEnergyStorage_Component4ObjectType Component4ObjectType { get; set; } = (PlantEquipmentOperation_ThermalEnergyStorage_Component4ObjectType)Enum.Parse(typeof(PlantEquipmentOperation_ThermalEnergyStorage_Component4ObjectType), "ChillerAbsorption");
        

[JsonProperty(PropertyName="component_4_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component4Name { get; set; } = "";
        

[JsonProperty(PropertyName="component_4_demand_calculation_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component4DemandCalculationNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_4_setpoint_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component4SetpointNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_4_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> Component4FlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="component_4_operation_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ThermalEnergyStorage_Component4OperationType Component4OperationType { get; set; } = (PlantEquipmentOperation_ThermalEnergyStorage_Component4OperationType)Enum.Parse(typeof(PlantEquipmentOperation_ThermalEnergyStorage_Component4OperationType), "Cooling");
        

[JsonProperty(PropertyName="component_5_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ThermalEnergyStorage_Component5ObjectType Component5ObjectType { get; set; } = (PlantEquipmentOperation_ThermalEnergyStorage_Component5ObjectType)Enum.Parse(typeof(PlantEquipmentOperation_ThermalEnergyStorage_Component5ObjectType), "ChillerAbsorption");
        

[JsonProperty(PropertyName="component_5_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component5Name { get; set; } = "";
        

[JsonProperty(PropertyName="component_5_demand_calculation_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component5DemandCalculationNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_5_setpoint_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component5SetpointNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_5_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> Component5FlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="component_5_operation_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ThermalEnergyStorage_Component5OperationType Component5OperationType { get; set; } = (PlantEquipmentOperation_ThermalEnergyStorage_Component5OperationType)Enum.Parse(typeof(PlantEquipmentOperation_ThermalEnergyStorage_Component5OperationType), "Cooling");
        

[JsonProperty(PropertyName="component_6_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ThermalEnergyStorage_Component6ObjectType Component6ObjectType { get; set; } = (PlantEquipmentOperation_ThermalEnergyStorage_Component6ObjectType)Enum.Parse(typeof(PlantEquipmentOperation_ThermalEnergyStorage_Component6ObjectType), "ChillerAbsorption");
        

[JsonProperty(PropertyName="component_6_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component6Name { get; set; } = "";
        

[JsonProperty(PropertyName="component_6_demand_calculation_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component6DemandCalculationNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_6_setpoint_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component6SetpointNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_6_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> Component6FlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="component_6_operation_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ThermalEnergyStorage_Component6OperationType Component6OperationType { get; set; } = (PlantEquipmentOperation_ThermalEnergyStorage_Component6OperationType)Enum.Parse(typeof(PlantEquipmentOperation_ThermalEnergyStorage_Component6OperationType), "Cooling");
        

[JsonProperty(PropertyName="component_7_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ThermalEnergyStorage_Component7ObjectType Component7ObjectType { get; set; } = (PlantEquipmentOperation_ThermalEnergyStorage_Component7ObjectType)Enum.Parse(typeof(PlantEquipmentOperation_ThermalEnergyStorage_Component7ObjectType), "ChillerAbsorption");
        

[JsonProperty(PropertyName="component_7_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component7Name { get; set; } = "";
        

[JsonProperty(PropertyName="component_7_demand_calculation_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component7DemandCalculationNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_7_setpoint_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component7SetpointNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_7_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> Component7FlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="component_7_operation_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ThermalEnergyStorage_Component7OperationType Component7OperationType { get; set; } = (PlantEquipmentOperation_ThermalEnergyStorage_Component7OperationType)Enum.Parse(typeof(PlantEquipmentOperation_ThermalEnergyStorage_Component7OperationType), "Cooling");
        

[JsonProperty(PropertyName="component_8_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ThermalEnergyStorage_Component8ObjectType Component8ObjectType { get; set; } = (PlantEquipmentOperation_ThermalEnergyStorage_Component8ObjectType)Enum.Parse(typeof(PlantEquipmentOperation_ThermalEnergyStorage_Component8ObjectType), "ChillerAbsorption");
        

[JsonProperty(PropertyName="component_8_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component8Name { get; set; } = "";
        

[JsonProperty(PropertyName="component_8_demand_calculation_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component8DemandCalculationNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_8_setpoint_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component8SetpointNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_8_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> Component8FlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="component_8_operation_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ThermalEnergyStorage_Component8OperationType Component8OperationType { get; set; } = (PlantEquipmentOperation_ThermalEnergyStorage_Component8OperationType)Enum.Parse(typeof(PlantEquipmentOperation_ThermalEnergyStorage_Component8OperationType), "Cooling");
        

[JsonProperty(PropertyName="component_9_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ThermalEnergyStorage_Component9ObjectType Component9ObjectType { get; set; } = (PlantEquipmentOperation_ThermalEnergyStorage_Component9ObjectType)Enum.Parse(typeof(PlantEquipmentOperation_ThermalEnergyStorage_Component9ObjectType), "ChillerAbsorption");
        

[JsonProperty(PropertyName="component_9_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component9Name { get; set; } = "";
        

[JsonProperty(PropertyName="component_9_demand_calculation_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component9DemandCalculationNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_9_setpoint_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component9SetpointNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_9_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> Component9FlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="component_9_operation_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ThermalEnergyStorage_Component9OperationType Component9OperationType { get; set; } = (PlantEquipmentOperation_ThermalEnergyStorage_Component9OperationType)Enum.Parse(typeof(PlantEquipmentOperation_ThermalEnergyStorage_Component9OperationType), "Cooling");
        

[JsonProperty(PropertyName="component_10_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ThermalEnergyStorage_Component10ObjectType Component10ObjectType { get; set; } = (PlantEquipmentOperation_ThermalEnergyStorage_Component10ObjectType)Enum.Parse(typeof(PlantEquipmentOperation_ThermalEnergyStorage_Component10ObjectType), "ChillerAbsorption");
        

[JsonProperty(PropertyName="component_10_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component10Name { get; set; } = "";
        

[JsonProperty(PropertyName="component_10_demand_calculation_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component10DemandCalculationNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_10_setpoint_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Component10SetpointNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="component_10_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> Component10FlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="component_10_operation_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperation_ThermalEnergyStorage_Component10OperationType Component10OperationType { get; set; } = (PlantEquipmentOperation_ThermalEnergyStorage_Component10OperationType)Enum.Parse(typeof(PlantEquipmentOperation_ThermalEnergyStorage_Component10OperationType), "Cooling");
    }
    
    public enum PlantEquipmentOperation_ThermalEnergyStorage_Component1ObjectType
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
        
        [System.Runtime.Serialization.EnumMember(Value="ThermalStorage:Ice:Detailed")]
        ThermalStorageIceDetailed = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermalStorage:Ice:Simple")]
        ThermalStorageIceSimple = 9,
    }
    
    public enum PlantEquipmentOperation_ThermalEnergyStorage_Component1OperationType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dual")]
        Dual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 2,
    }
    
    public enum PlantEquipmentOperation_ThermalEnergyStorage_Component2ObjectType
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
        
        [System.Runtime.Serialization.EnumMember(Value="ThermalStorage:Ice:Detailed")]
        ThermalStorageIceDetailed = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermalStorage:Ice:Simple")]
        ThermalStorageIceSimple = 9,
    }
    
    public enum PlantEquipmentOperation_ThermalEnergyStorage_Component2OperationType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dual")]
        Dual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 2,
    }
    
    public enum PlantEquipmentOperation_ThermalEnergyStorage_Component3ObjectType
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
        
        [System.Runtime.Serialization.EnumMember(Value="ThermalStorage:Ice:Detailed")]
        ThermalStorageIceDetailed = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermalStorage:Ice:Simple")]
        ThermalStorageIceSimple = 9,
    }
    
    public enum PlantEquipmentOperation_ThermalEnergyStorage_Component3OperationType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dual")]
        Dual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 2,
    }
    
    public enum PlantEquipmentOperation_ThermalEnergyStorage_Component4ObjectType
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
        
        [System.Runtime.Serialization.EnumMember(Value="ThermalStorage:Ice:Detailed")]
        ThermalStorageIceDetailed = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermalStorage:Ice:Simple")]
        ThermalStorageIceSimple = 9,
    }
    
    public enum PlantEquipmentOperation_ThermalEnergyStorage_Component4OperationType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dual")]
        Dual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 2,
    }
    
    public enum PlantEquipmentOperation_ThermalEnergyStorage_Component5ObjectType
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
        
        [System.Runtime.Serialization.EnumMember(Value="ThermalStorage:Ice:Detailed")]
        ThermalStorageIceDetailed = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermalStorage:Ice:Simple")]
        ThermalStorageIceSimple = 9,
    }
    
    public enum PlantEquipmentOperation_ThermalEnergyStorage_Component5OperationType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dual")]
        Dual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 2,
    }
    
    public enum PlantEquipmentOperation_ThermalEnergyStorage_Component6ObjectType
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
        
        [System.Runtime.Serialization.EnumMember(Value="ThermalStorage:Ice:Detailed")]
        ThermalStorageIceDetailed = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermalStorage:Ice:Simple")]
        ThermalStorageIceSimple = 9,
    }
    
    public enum PlantEquipmentOperation_ThermalEnergyStorage_Component6OperationType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dual")]
        Dual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 2,
    }
    
    public enum PlantEquipmentOperation_ThermalEnergyStorage_Component7ObjectType
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
        
        [System.Runtime.Serialization.EnumMember(Value="ThermalStorage:Ice:Detailed")]
        ThermalStorageIceDetailed = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermalStorage:Ice:Simple")]
        ThermalStorageIceSimple = 9,
    }
    
    public enum PlantEquipmentOperation_ThermalEnergyStorage_Component7OperationType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dual")]
        Dual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 2,
    }
    
    public enum PlantEquipmentOperation_ThermalEnergyStorage_Component8ObjectType
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
        
        [System.Runtime.Serialization.EnumMember(Value="ThermalStorage:Ice:Detailed")]
        ThermalStorageIceDetailed = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermalStorage:Ice:Simple")]
        ThermalStorageIceSimple = 9,
    }
    
    public enum PlantEquipmentOperation_ThermalEnergyStorage_Component8OperationType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dual")]
        Dual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 2,
    }
    
    public enum PlantEquipmentOperation_ThermalEnergyStorage_Component9ObjectType
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
        
        [System.Runtime.Serialization.EnumMember(Value="ThermalStorage:Ice:Detailed")]
        ThermalStorageIceDetailed = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermalStorage:Ice:Simple")]
        ThermalStorageIceSimple = 9,
    }
    
    public enum PlantEquipmentOperation_ThermalEnergyStorage_Component9OperationType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dual")]
        Dual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 2,
    }
    
    public enum PlantEquipmentOperation_ThermalEnergyStorage_Component10ObjectType
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
        
        [System.Runtime.Serialization.EnumMember(Value="ThermalStorage:Ice:Detailed")]
        ThermalStorageIceDetailed = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="ThermalStorage:Ice:Simple")]
        ThermalStorageIceSimple = 9,
    }
    
    public enum PlantEquipmentOperation_ThermalEnergyStorage_Component10OperationType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dual")]
        Dual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 2,
    }
    
    [Description(@"Plant equipment operation scheme for outdoor dry-bulb temperature difference operation. Specifies one or more groups of equipment which are available to operate for successive ranges based the difference between a reference node temperature and the outdoor dry-bulb temperature.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PlantEquipmentOperation_OutdoorDryBulbDifference
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="reference_temperature_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReferenceTemperatureNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="dry_bulb_temperature_difference_range_1_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureDifferenceRange1LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dry_bulb_temperature_difference_range_1_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureDifferenceRange1UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_1_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range1EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dry_bulb_temperature_difference_range_2_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureDifferenceRange2LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dry_bulb_temperature_difference_range_2_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureDifferenceRange2UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_2_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range2EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dry_bulb_temperature_difference_range_3_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureDifferenceRange3LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dry_bulb_temperature_difference_range_3_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureDifferenceRange3UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_3_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range3EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dry_bulb_temperature_difference_range_4_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureDifferenceRange4LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dry_bulb_temperature_difference_range_4_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureDifferenceRange4UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_4_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range4EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dry_bulb_temperature_difference_range_5_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureDifferenceRange5LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dry_bulb_temperature_difference_range_5_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureDifferenceRange5UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_5_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range5EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dry_bulb_temperature_difference_range_6_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureDifferenceRange6LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dry_bulb_temperature_difference_range_6_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureDifferenceRange6UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_6_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range6EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dry_bulb_temperature_difference_range_7_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureDifferenceRange7LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dry_bulb_temperature_difference_range_7_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureDifferenceRange7UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_7_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range7EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dry_bulb_temperature_difference_range_8_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureDifferenceRange8LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dry_bulb_temperature_difference_range_8_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureDifferenceRange8UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_8_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range8EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dry_bulb_temperature_difference_range_9_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureDifferenceRange9LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dry_bulb_temperature_difference_range_9_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureDifferenceRange9UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_9_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range9EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dry_bulb_temperature_difference_range_10_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureDifferenceRange10LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dry_bulb_temperature_difference_range_10_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DryBulbTemperatureDifferenceRange10UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_10_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range10EquipmentListName { get; set; } = "";
    }
    
    [Description(@"Plant equipment operation scheme for outdoor wet-bulb temperature difference operation. Specifies one or more groups of equipment which are available to operate for successive ranges based the difference between a reference node temperature and the outdoor wet-bulb temperature.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PlantEquipmentOperation_OutdoorWetBulbDifference
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="reference_temperature_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReferenceTemperatureNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="wet_bulb_temperature_difference_range_1_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureDifferenceRange1LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="wet_bulb_temperature_difference_range_1_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureDifferenceRange1UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_1_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range1EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="wet_bulb_temperature_difference_range_2_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureDifferenceRange2LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="wet_bulb_temperature_difference_range_2_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureDifferenceRange2UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_2_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range2EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="wet_bulb_temperature_difference_range_3_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureDifferenceRange3LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="wet_bulb_temperature_difference_range_3_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureDifferenceRange3UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_3_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range3EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="wet_bulb_temperature_difference_range_4_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureDifferenceRange4LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="wet_bulb_temperature_difference_range_4_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureDifferenceRange4UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_4_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range4EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="wet_bulb_temperature_difference_range_5_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureDifferenceRange5LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="wet_bulb_temperature_difference_range_5_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureDifferenceRange5UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_5_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range5EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="wet_bulb_temperature_difference_range_6_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureDifferenceRange6LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="wet_bulb_temperature_difference_range_6_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureDifferenceRange6UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_6_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range6EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="wet_bulb_temperature_difference_range_7_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureDifferenceRange7LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="wet_bulb_temperature_difference_range_7_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureDifferenceRange7UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_7_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range7EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="wet_bulb_temperature_difference_range_8_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureDifferenceRange8LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="wet_bulb_temperature_difference_range_8_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureDifferenceRange8UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_8_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range8EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="wet_bulb_temperature_difference_range_9_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureDifferenceRange9LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="wet_bulb_temperature_difference_range_9_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureDifferenceRange9UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_9_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range9EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="wet_bulb_temperature_difference_range_10_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureDifferenceRange10LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="wet_bulb_temperature_difference_range_10_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WetBulbTemperatureDifferenceRange10UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_10_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range10EquipmentListName { get; set; } = "";
    }
    
    [Description(@"Plant equipment operation scheme for outdoor dewpoint temperature difference operation. Specifies one or more groups of equipment which are available to operate for successive ranges based the difference between a reference node temperature and the outdoor dewpoint temperature.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PlantEquipmentOperation_OutdoorDewpointDifference
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="reference_temperature_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReferenceTemperatureNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="dewpoint_temperature_difference_range_1_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureDifferenceRange1LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dewpoint_temperature_difference_range_1_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureDifferenceRange1UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_1_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range1EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dewpoint_temperature_difference_range_2_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureDifferenceRange2LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dewpoint_temperature_difference_range_2_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureDifferenceRange2UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_2_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range2EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dewpoint_temperature_difference_range_3_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureDifferenceRange3LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dewpoint_temperature_difference_range_3_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureDifferenceRange3UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_3_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range3EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dewpoint_temperature_difference_range_4_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureDifferenceRange4LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dewpoint_temperature_difference_range_4_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureDifferenceRange4UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_4_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range4EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dewpoint_temperature_difference_range_5_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureDifferenceRange5LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dewpoint_temperature_difference_range_5_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureDifferenceRange5UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_5_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range5EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dewpoint_temperature_difference_range_6_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureDifferenceRange6LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dewpoint_temperature_difference_range_6_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureDifferenceRange6UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_6_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range6EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dewpoint_temperature_difference_range_7_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureDifferenceRange7LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dewpoint_temperature_difference_range_7_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureDifferenceRange7UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_7_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range7EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dewpoint_temperature_difference_range_8_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureDifferenceRange8LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dewpoint_temperature_difference_range_8_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureDifferenceRange8UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_8_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range8EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dewpoint_temperature_difference_range_9_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureDifferenceRange9LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dewpoint_temperature_difference_range_9_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureDifferenceRange9UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_9_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range9EquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="dewpoint_temperature_difference_range_10_lower_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureDifferenceRange10LowerLimit { get; set; } = null;
        

[JsonProperty(PropertyName="dewpoint_temperature_difference_range_10_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DewpointTemperatureDifferenceRange10UpperLimit { get; set; } = null;
        

[JsonProperty(PropertyName="range_10_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Range10EquipmentListName { get; set; } = "";
    }
    
    [Description(@"Operation schemes are listed in ""priority"" order. Note that each scheme must address the entire load and/or condition ranges for the simulation. The actual one selected for use will be the first that is ""Scheduled"" on. That is, if control scheme 1 is not ""on"" and control scheme 2 is -- then control scheme 2 is selected. Only plant equipment should be listed on a Control Scheme for this item.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PlantEquipmentOperationSchemes
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_1_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperationSchemes_ControlScheme1ObjectType ControlScheme1ObjectType { get; set; } = (PlantEquipmentOperationSchemes_ControlScheme1ObjectType)Enum.Parse(typeof(PlantEquipmentOperationSchemes_ControlScheme1ObjectType), "PlantEquipmentOperationComponentSetpoint");
        

[JsonProperty(PropertyName="control_scheme_1_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme1Name { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_1_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme1ScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_2_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperationSchemes_ControlScheme2ObjectType ControlScheme2ObjectType { get; set; } = (PlantEquipmentOperationSchemes_ControlScheme2ObjectType)Enum.Parse(typeof(PlantEquipmentOperationSchemes_ControlScheme2ObjectType), "PlantEquipmentOperationComponentSetpoint");
        

[JsonProperty(PropertyName="control_scheme_2_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme2Name { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_2_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme2ScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_3_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperationSchemes_ControlScheme3ObjectType ControlScheme3ObjectType { get; set; } = (PlantEquipmentOperationSchemes_ControlScheme3ObjectType)Enum.Parse(typeof(PlantEquipmentOperationSchemes_ControlScheme3ObjectType), "PlantEquipmentOperationComponentSetpoint");
        

[JsonProperty(PropertyName="control_scheme_3_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme3Name { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_3_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme3ScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_4_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperationSchemes_ControlScheme4ObjectType ControlScheme4ObjectType { get; set; } = (PlantEquipmentOperationSchemes_ControlScheme4ObjectType)Enum.Parse(typeof(PlantEquipmentOperationSchemes_ControlScheme4ObjectType), "PlantEquipmentOperationComponentSetpoint");
        

[JsonProperty(PropertyName="control_scheme_4_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme4Name { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_4_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme4ScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_5_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperationSchemes_ControlScheme5ObjectType ControlScheme5ObjectType { get; set; } = (PlantEquipmentOperationSchemes_ControlScheme5ObjectType)Enum.Parse(typeof(PlantEquipmentOperationSchemes_ControlScheme5ObjectType), "PlantEquipmentOperationComponentSetpoint");
        

[JsonProperty(PropertyName="control_scheme_5_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme5Name { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_5_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme5ScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_6_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperationSchemes_ControlScheme6ObjectType ControlScheme6ObjectType { get; set; } = (PlantEquipmentOperationSchemes_ControlScheme6ObjectType)Enum.Parse(typeof(PlantEquipmentOperationSchemes_ControlScheme6ObjectType), "PlantEquipmentOperationComponentSetpoint");
        

[JsonProperty(PropertyName="control_scheme_6_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme6Name { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_6_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme6ScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_7_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperationSchemes_ControlScheme7ObjectType ControlScheme7ObjectType { get; set; } = (PlantEquipmentOperationSchemes_ControlScheme7ObjectType)Enum.Parse(typeof(PlantEquipmentOperationSchemes_ControlScheme7ObjectType), "PlantEquipmentOperationComponentSetpoint");
        

[JsonProperty(PropertyName="control_scheme_7_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme7Name { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_7_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme7ScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_8_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantEquipmentOperationSchemes_ControlScheme8ObjectType ControlScheme8ObjectType { get; set; } = (PlantEquipmentOperationSchemes_ControlScheme8ObjectType)Enum.Parse(typeof(PlantEquipmentOperationSchemes_ControlScheme8ObjectType), "PlantEquipmentOperationComponentSetpoint");
        

[JsonProperty(PropertyName="control_scheme_8_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme8Name { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_8_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme8ScheduleName { get; set; } = "";
    }
    
    public enum PlantEquipmentOperationSchemes_ControlScheme1ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:ComponentSetpoint")]
        PlantEquipmentOperationComponentSetpoint = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:CoolingLoad")]
        PlantEquipmentOperationCoolingLoad = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:HeatingLoad")]
        PlantEquipmentOperationHeatingLoad = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpoint")]
        PlantEquipmentOperationOutdoorDewpoint = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpointDifference")]
        PlantEquipmentOperationOutdoorDewpointDifference = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulb")]
        PlantEquipmentOperationOutdoorDryBulb = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulbDifference")]
        PlantEquipmentOperationOutdoorDryBulbDifference = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorRelativeHumidity")]
        PlantEquipmentOperationOutdoorRelativeHumidity = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulb")]
        PlantEquipmentOperationOutdoorWetBulb = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulbDifference")]
        PlantEquipmentOperationOutdoorWetBulbDifference = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:ThermalEnergyStorage")]
        PlantEquipmentOperationThermalEnergyStorage = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:Uncontrolled")]
        PlantEquipmentOperationUncontrolled = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:UserDefined")]
        PlantEquipmentOperationUserDefined = 12,
    }
    
    public enum PlantEquipmentOperationSchemes_ControlScheme2ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:ComponentSetpoint")]
        PlantEquipmentOperationComponentSetpoint = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:CoolingLoad")]
        PlantEquipmentOperationCoolingLoad = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:HeatingLoad")]
        PlantEquipmentOperationHeatingLoad = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpoint")]
        PlantEquipmentOperationOutdoorDewpoint = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpointDifference")]
        PlantEquipmentOperationOutdoorDewpointDifference = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulb")]
        PlantEquipmentOperationOutdoorDryBulb = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulbDifference")]
        PlantEquipmentOperationOutdoorDryBulbDifference = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorRelativeHumidity")]
        PlantEquipmentOperationOutdoorRelativeHumidity = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulb")]
        PlantEquipmentOperationOutdoorWetBulb = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulbDifference")]
        PlantEquipmentOperationOutdoorWetBulbDifference = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:ThermalEnergyStorage")]
        PlantEquipmentOperationThermalEnergyStorage = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:Uncontrolled")]
        PlantEquipmentOperationUncontrolled = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:UserDefined")]
        PlantEquipmentOperationUserDefined = 12,
    }
    
    public enum PlantEquipmentOperationSchemes_ControlScheme3ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:ComponentSetpoint")]
        PlantEquipmentOperationComponentSetpoint = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:CoolingLoad")]
        PlantEquipmentOperationCoolingLoad = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:HeatingLoad")]
        PlantEquipmentOperationHeatingLoad = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpoint")]
        PlantEquipmentOperationOutdoorDewpoint = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpointDifference")]
        PlantEquipmentOperationOutdoorDewpointDifference = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulb")]
        PlantEquipmentOperationOutdoorDryBulb = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulbDifference")]
        PlantEquipmentOperationOutdoorDryBulbDifference = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorRelativeHumidity")]
        PlantEquipmentOperationOutdoorRelativeHumidity = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulb")]
        PlantEquipmentOperationOutdoorWetBulb = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulbDifference")]
        PlantEquipmentOperationOutdoorWetBulbDifference = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:ThermalEnergyStorage")]
        PlantEquipmentOperationThermalEnergyStorage = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:Uncontrolled")]
        PlantEquipmentOperationUncontrolled = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:UserDefined")]
        PlantEquipmentOperationUserDefined = 12,
    }
    
    public enum PlantEquipmentOperationSchemes_ControlScheme4ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:ComponentSetpoint")]
        PlantEquipmentOperationComponentSetpoint = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:CoolingLoad")]
        PlantEquipmentOperationCoolingLoad = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:HeatingLoad")]
        PlantEquipmentOperationHeatingLoad = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpoint")]
        PlantEquipmentOperationOutdoorDewpoint = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpointDifference")]
        PlantEquipmentOperationOutdoorDewpointDifference = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulb")]
        PlantEquipmentOperationOutdoorDryBulb = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulbDifference")]
        PlantEquipmentOperationOutdoorDryBulbDifference = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorRelativeHumidity")]
        PlantEquipmentOperationOutdoorRelativeHumidity = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulb")]
        PlantEquipmentOperationOutdoorWetBulb = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulbDifference")]
        PlantEquipmentOperationOutdoorWetBulbDifference = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:ThermalEnergyStorage")]
        PlantEquipmentOperationThermalEnergyStorage = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:Uncontrolled")]
        PlantEquipmentOperationUncontrolled = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:UserDefined")]
        PlantEquipmentOperationUserDefined = 12,
    }
    
    public enum PlantEquipmentOperationSchemes_ControlScheme5ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:ComponentSetpoint")]
        PlantEquipmentOperationComponentSetpoint = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:CoolingLoad")]
        PlantEquipmentOperationCoolingLoad = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:HeatingLoad")]
        PlantEquipmentOperationHeatingLoad = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpoint")]
        PlantEquipmentOperationOutdoorDewpoint = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpointDifference")]
        PlantEquipmentOperationOutdoorDewpointDifference = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulb")]
        PlantEquipmentOperationOutdoorDryBulb = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulbDifference")]
        PlantEquipmentOperationOutdoorDryBulbDifference = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorRelativeHumidity")]
        PlantEquipmentOperationOutdoorRelativeHumidity = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulb")]
        PlantEquipmentOperationOutdoorWetBulb = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulbDifference")]
        PlantEquipmentOperationOutdoorWetBulbDifference = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:ThermalEnergyStorage")]
        PlantEquipmentOperationThermalEnergyStorage = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:Uncontrolled")]
        PlantEquipmentOperationUncontrolled = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:UserDefined")]
        PlantEquipmentOperationUserDefined = 12,
    }
    
    public enum PlantEquipmentOperationSchemes_ControlScheme6ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:ComponentSetpoint")]
        PlantEquipmentOperationComponentSetpoint = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:CoolingLoad")]
        PlantEquipmentOperationCoolingLoad = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:HeatingLoad")]
        PlantEquipmentOperationHeatingLoad = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpoint")]
        PlantEquipmentOperationOutdoorDewpoint = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpointDifference")]
        PlantEquipmentOperationOutdoorDewpointDifference = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulb")]
        PlantEquipmentOperationOutdoorDryBulb = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulbDifference")]
        PlantEquipmentOperationOutdoorDryBulbDifference = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorRelativeHumidity")]
        PlantEquipmentOperationOutdoorRelativeHumidity = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulb")]
        PlantEquipmentOperationOutdoorWetBulb = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulbDifference")]
        PlantEquipmentOperationOutdoorWetBulbDifference = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:ThermalEnergyStorage")]
        PlantEquipmentOperationThermalEnergyStorage = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:Uncontrolled")]
        PlantEquipmentOperationUncontrolled = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:UserDefined")]
        PlantEquipmentOperationUserDefined = 12,
    }
    
    public enum PlantEquipmentOperationSchemes_ControlScheme7ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:ComponentSetpoint")]
        PlantEquipmentOperationComponentSetpoint = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:CoolingLoad")]
        PlantEquipmentOperationCoolingLoad = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:HeatingLoad")]
        PlantEquipmentOperationHeatingLoad = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpoint")]
        PlantEquipmentOperationOutdoorDewpoint = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpointDifference")]
        PlantEquipmentOperationOutdoorDewpointDifference = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulb")]
        PlantEquipmentOperationOutdoorDryBulb = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulbDifference")]
        PlantEquipmentOperationOutdoorDryBulbDifference = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorRelativeHumidity")]
        PlantEquipmentOperationOutdoorRelativeHumidity = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulb")]
        PlantEquipmentOperationOutdoorWetBulb = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulbDifference")]
        PlantEquipmentOperationOutdoorWetBulbDifference = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:ThermalEnergyStorage")]
        PlantEquipmentOperationThermalEnergyStorage = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:Uncontrolled")]
        PlantEquipmentOperationUncontrolled = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:UserDefined")]
        PlantEquipmentOperationUserDefined = 12,
    }
    
    public enum PlantEquipmentOperationSchemes_ControlScheme8ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:ComponentSetpoint")]
        PlantEquipmentOperationComponentSetpoint = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:CoolingLoad")]
        PlantEquipmentOperationCoolingLoad = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:HeatingLoad")]
        PlantEquipmentOperationHeatingLoad = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpoint")]
        PlantEquipmentOperationOutdoorDewpoint = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpointDifference")]
        PlantEquipmentOperationOutdoorDewpointDifference = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulb")]
        PlantEquipmentOperationOutdoorDryBulb = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulbDifference")]
        PlantEquipmentOperationOutdoorDryBulbDifference = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorRelativeHumidity")]
        PlantEquipmentOperationOutdoorRelativeHumidity = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulb")]
        PlantEquipmentOperationOutdoorWetBulb = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulbDifference")]
        PlantEquipmentOperationOutdoorWetBulbDifference = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:ThermalEnergyStorage")]
        PlantEquipmentOperationThermalEnergyStorage = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:Uncontrolled")]
        PlantEquipmentOperationUncontrolled = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:UserDefined")]
        PlantEquipmentOperationUserDefined = 12,
    }
    
    [Description(@"Operation schemes are listed in ""priority"" order. Note that each scheme must address the entire load and/or condition ranges for the simulation. The actual one selected for use will be the first that is ""Scheduled"" on. That is, if control scheme 1 is not ""on"" and control scheme 2 is -- then control scheme 2 is selected. Only condenser equipment should be listed on a Control Scheme for this item.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class CondenserEquipmentOperationSchemes
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_1_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CondenserEquipmentOperationSchemes_ControlScheme1ObjectType ControlScheme1ObjectType { get; set; } = (CondenserEquipmentOperationSchemes_ControlScheme1ObjectType)Enum.Parse(typeof(CondenserEquipmentOperationSchemes_ControlScheme1ObjectType), "PlantEquipmentOperationCoolingLoad");
        

[JsonProperty(PropertyName="control_scheme_1_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme1Name { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_1_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme1ScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_2_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CondenserEquipmentOperationSchemes_ControlScheme2ObjectType ControlScheme2ObjectType { get; set; } = (CondenserEquipmentOperationSchemes_ControlScheme2ObjectType)Enum.Parse(typeof(CondenserEquipmentOperationSchemes_ControlScheme2ObjectType), "PlantEquipmentOperationCoolingLoad");
        

[JsonProperty(PropertyName="control_scheme_2_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme2Name { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_2_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme2ScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_3_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CondenserEquipmentOperationSchemes_ControlScheme3ObjectType ControlScheme3ObjectType { get; set; } = (CondenserEquipmentOperationSchemes_ControlScheme3ObjectType)Enum.Parse(typeof(CondenserEquipmentOperationSchemes_ControlScheme3ObjectType), "PlantEquipmentOperationCoolingLoad");
        

[JsonProperty(PropertyName="control_scheme_3_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme3Name { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_3_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme3ScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_4_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CondenserEquipmentOperationSchemes_ControlScheme4ObjectType ControlScheme4ObjectType { get; set; } = (CondenserEquipmentOperationSchemes_ControlScheme4ObjectType)Enum.Parse(typeof(CondenserEquipmentOperationSchemes_ControlScheme4ObjectType), "PlantEquipmentOperationCoolingLoad");
        

[JsonProperty(PropertyName="control_scheme_4_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme4Name { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_4_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme4ScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_5_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CondenserEquipmentOperationSchemes_ControlScheme5ObjectType ControlScheme5ObjectType { get; set; } = (CondenserEquipmentOperationSchemes_ControlScheme5ObjectType)Enum.Parse(typeof(CondenserEquipmentOperationSchemes_ControlScheme5ObjectType), "PlantEquipmentOperationCoolingLoad");
        

[JsonProperty(PropertyName="control_scheme_5_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme5Name { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_5_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme5ScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_6_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CondenserEquipmentOperationSchemes_ControlScheme6ObjectType ControlScheme6ObjectType { get; set; } = (CondenserEquipmentOperationSchemes_ControlScheme6ObjectType)Enum.Parse(typeof(CondenserEquipmentOperationSchemes_ControlScheme6ObjectType), "PlantEquipmentOperationCoolingLoad");
        

[JsonProperty(PropertyName="control_scheme_6_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme6Name { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_6_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme6ScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_7_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CondenserEquipmentOperationSchemes_ControlScheme7ObjectType ControlScheme7ObjectType { get; set; } = (CondenserEquipmentOperationSchemes_ControlScheme7ObjectType)Enum.Parse(typeof(CondenserEquipmentOperationSchemes_ControlScheme7ObjectType), "PlantEquipmentOperationCoolingLoad");
        

[JsonProperty(PropertyName="control_scheme_7_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme7Name { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_7_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme7ScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_8_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CondenserEquipmentOperationSchemes_ControlScheme8ObjectType ControlScheme8ObjectType { get; set; } = (CondenserEquipmentOperationSchemes_ControlScheme8ObjectType)Enum.Parse(typeof(CondenserEquipmentOperationSchemes_ControlScheme8ObjectType), "PlantEquipmentOperationCoolingLoad");
        

[JsonProperty(PropertyName="control_scheme_8_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme8Name { get; set; } = "";
        

[JsonProperty(PropertyName="control_scheme_8_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ControlScheme8ScheduleName { get; set; } = "";
    }
    
    public enum CondenserEquipmentOperationSchemes_ControlScheme1ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:CoolingLoad")]
        PlantEquipmentOperationCoolingLoad = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:HeatingLoad")]
        PlantEquipmentOperationHeatingLoad = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpoint")]
        PlantEquipmentOperationOutdoorDewpoint = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpointDifference")]
        PlantEquipmentOperationOutdoorDewpointDifference = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulb")]
        PlantEquipmentOperationOutdoorDryBulb = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulbDifference")]
        PlantEquipmentOperationOutdoorDryBulbDifference = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorRelativeHumidity")]
        PlantEquipmentOperationOutdoorRelativeHumidity = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulb")]
        PlantEquipmentOperationOutdoorWetBulb = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulbDifference")]
        PlantEquipmentOperationOutdoorWetBulbDifference = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:Uncontrolled")]
        PlantEquipmentOperationUncontrolled = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:UserDefined")]
        PlantEquipmentOperationUserDefined = 10,
    }
    
    public enum CondenserEquipmentOperationSchemes_ControlScheme2ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:CoolingLoad")]
        PlantEquipmentOperationCoolingLoad = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:HeatingLoad")]
        PlantEquipmentOperationHeatingLoad = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpoint")]
        PlantEquipmentOperationOutdoorDewpoint = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpointDifference")]
        PlantEquipmentOperationOutdoorDewpointDifference = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulb")]
        PlantEquipmentOperationOutdoorDryBulb = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulbDifference")]
        PlantEquipmentOperationOutdoorDryBulbDifference = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorRelativeHumidity")]
        PlantEquipmentOperationOutdoorRelativeHumidity = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulb")]
        PlantEquipmentOperationOutdoorWetBulb = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulbDifference")]
        PlantEquipmentOperationOutdoorWetBulbDifference = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:Uncontrolled")]
        PlantEquipmentOperationUncontrolled = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:UserDefined")]
        PlantEquipmentOperationUserDefined = 10,
    }
    
    public enum CondenserEquipmentOperationSchemes_ControlScheme3ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:CoolingLoad")]
        PlantEquipmentOperationCoolingLoad = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:HeatingLoad")]
        PlantEquipmentOperationHeatingLoad = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpoint")]
        PlantEquipmentOperationOutdoorDewpoint = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpointDifference")]
        PlantEquipmentOperationOutdoorDewpointDifference = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulb")]
        PlantEquipmentOperationOutdoorDryBulb = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulbDifference")]
        PlantEquipmentOperationOutdoorDryBulbDifference = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorRelativeHumidity")]
        PlantEquipmentOperationOutdoorRelativeHumidity = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulb")]
        PlantEquipmentOperationOutdoorWetBulb = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulbDifference")]
        PlantEquipmentOperationOutdoorWetBulbDifference = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:Uncontrolled")]
        PlantEquipmentOperationUncontrolled = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:UserDefined")]
        PlantEquipmentOperationUserDefined = 10,
    }
    
    public enum CondenserEquipmentOperationSchemes_ControlScheme4ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:CoolingLoad")]
        PlantEquipmentOperationCoolingLoad = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:HeatingLoad")]
        PlantEquipmentOperationHeatingLoad = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpoint")]
        PlantEquipmentOperationOutdoorDewpoint = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpointDifference")]
        PlantEquipmentOperationOutdoorDewpointDifference = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulb")]
        PlantEquipmentOperationOutdoorDryBulb = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulbDifference")]
        PlantEquipmentOperationOutdoorDryBulbDifference = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorRelativeHumidity")]
        PlantEquipmentOperationOutdoorRelativeHumidity = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulb")]
        PlantEquipmentOperationOutdoorWetBulb = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulbDifference")]
        PlantEquipmentOperationOutdoorWetBulbDifference = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:Uncontrolled")]
        PlantEquipmentOperationUncontrolled = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:UserDefined")]
        PlantEquipmentOperationUserDefined = 10,
    }
    
    public enum CondenserEquipmentOperationSchemes_ControlScheme5ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:CoolingLoad")]
        PlantEquipmentOperationCoolingLoad = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:HeatingLoad")]
        PlantEquipmentOperationHeatingLoad = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpoint")]
        PlantEquipmentOperationOutdoorDewpoint = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpointDifference")]
        PlantEquipmentOperationOutdoorDewpointDifference = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulb")]
        PlantEquipmentOperationOutdoorDryBulb = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulbDifference")]
        PlantEquipmentOperationOutdoorDryBulbDifference = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorRelativeHumidity")]
        PlantEquipmentOperationOutdoorRelativeHumidity = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulb")]
        PlantEquipmentOperationOutdoorWetBulb = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulbDifference")]
        PlantEquipmentOperationOutdoorWetBulbDifference = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:Uncontrolled")]
        PlantEquipmentOperationUncontrolled = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:UserDefined")]
        PlantEquipmentOperationUserDefined = 10,
    }
    
    public enum CondenserEquipmentOperationSchemes_ControlScheme6ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:CoolingLoad")]
        PlantEquipmentOperationCoolingLoad = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:HeatingLoad")]
        PlantEquipmentOperationHeatingLoad = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpoint")]
        PlantEquipmentOperationOutdoorDewpoint = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpointDifference")]
        PlantEquipmentOperationOutdoorDewpointDifference = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulb")]
        PlantEquipmentOperationOutdoorDryBulb = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulbDifference")]
        PlantEquipmentOperationOutdoorDryBulbDifference = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorRelativeHumidity")]
        PlantEquipmentOperationOutdoorRelativeHumidity = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulb")]
        PlantEquipmentOperationOutdoorWetBulb = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulbDifference")]
        PlantEquipmentOperationOutdoorWetBulbDifference = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:Uncontrolled")]
        PlantEquipmentOperationUncontrolled = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:UserDefined")]
        PlantEquipmentOperationUserDefined = 10,
    }
    
    public enum CondenserEquipmentOperationSchemes_ControlScheme7ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:CoolingLoad")]
        PlantEquipmentOperationCoolingLoad = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:HeatingLoad")]
        PlantEquipmentOperationHeatingLoad = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpoint")]
        PlantEquipmentOperationOutdoorDewpoint = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpointDifference")]
        PlantEquipmentOperationOutdoorDewpointDifference = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulb")]
        PlantEquipmentOperationOutdoorDryBulb = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulbDifference")]
        PlantEquipmentOperationOutdoorDryBulbDifference = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorRelativeHumidity")]
        PlantEquipmentOperationOutdoorRelativeHumidity = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulb")]
        PlantEquipmentOperationOutdoorWetBulb = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulbDifference")]
        PlantEquipmentOperationOutdoorWetBulbDifference = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:Uncontrolled")]
        PlantEquipmentOperationUncontrolled = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:UserDefined")]
        PlantEquipmentOperationUserDefined = 10,
    }
    
    public enum CondenserEquipmentOperationSchemes_ControlScheme8ObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:CoolingLoad")]
        PlantEquipmentOperationCoolingLoad = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:HeatingLoad")]
        PlantEquipmentOperationHeatingLoad = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpoint")]
        PlantEquipmentOperationOutdoorDewpoint = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDewpointDifference")]
        PlantEquipmentOperationOutdoorDewpointDifference = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulb")]
        PlantEquipmentOperationOutdoorDryBulb = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorDryBulbDifference")]
        PlantEquipmentOperationOutdoorDryBulbDifference = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorRelativeHumidity")]
        PlantEquipmentOperationOutdoorRelativeHumidity = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulb")]
        PlantEquipmentOperationOutdoorWetBulb = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:OutdoorWetBulbDifference")]
        PlantEquipmentOperationOutdoorWetBulbDifference = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:Uncontrolled")]
        PlantEquipmentOperationUncontrolled = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="PlantEquipmentOperation:UserDefined")]
        PlantEquipmentOperationUserDefined = 10,
    }
}
