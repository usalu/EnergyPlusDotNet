namespace EnergyPlus.InternalGains
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
    
    
    [Description("Sets internal gains and contaminant rates for occupants in the zone. If you use a" +
        " ZoneList in the Zone or ZoneList name field then this definition applies to all" +
        " the zones in the ZoneList.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class People
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_or_zonelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneOrZonelistName { get; set; } = "";
        

[Description("units in schedule should be fraction applied to number of people (0.0 - 1.0)")]
[JsonProperty(PropertyName="number_of_people_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NumberOfPeopleScheduleName { get; set; } = "";
        

[Description(@"The entered calculation method is used to create the maximum number of people for this set of attributes (i.e. sensible fraction, schedule, etc) Choices: People -- simply enter number of occupants. People per Zone Floor Area -- enter the number to apply. Value * Floor Area = Number of people Zone Floor Area per Person -- enter the number to apply. Floor Area / Value = Number of people")]
[JsonProperty(PropertyName="number_of_people_calculation_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public People_NumberOfPeopleCalculationMethod NumberOfPeopleCalculationMethod { get; set; } = (People_NumberOfPeopleCalculationMethod)Enum.Parse(typeof(People_NumberOfPeopleCalculationMethod), "People");
        

[JsonProperty(PropertyName="number_of_people", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfPeople { get; set; } = null;
        

[JsonProperty(PropertyName="people_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PeoplePerZoneFloorArea { get; set; } = null;
        

[JsonProperty(PropertyName="zone_floor_area_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneFloorAreaPerPerson { get; set; } = null;
        

[Description("This is radiant fraction of the sensible heat released by people in a zone. This " +
    "value will be multiplied by the total sensible heat released by people yields th" +
    "e amount of long wavelength radiation gain from people in a zone. Default value " +
    "is 0.30.")]
[JsonProperty(PropertyName="fraction_radiant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionRadiant { get; set; } = Double.Parse("0.3", CultureInfo.InvariantCulture);
        

[Description("if input, overrides program calculated sensible/latent split")]
[JsonProperty(PropertyName="sensible_heat_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> SensibleHeatFraction { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Note that W has to be converted to mets in TC routine units in schedule are W/per" +
    "son")]
[JsonProperty(PropertyName="activity_level_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ActivityLevelScheduleName { get; set; } = "";
        

[Description("CO2 generation rate per unit of activity level. The default value is obtained fro" +
    "m ASHRAE Std 62.1 at 0.0084 cfm/met/person over the general adult population.")]
[JsonProperty(PropertyName="carbon_dioxide_generation_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CarbonDioxideGenerationRate { get; set; } = Double.Parse("3.82E-08", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="enable_ashrae_55_comfort_warnings", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes EnableAshrae55ComfortWarnings { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("optional (only required for thermal comfort runs)")]
[JsonProperty(PropertyName="mean_radiant_temperature_calculation_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public People_MeanRadiantTemperatureCalculationType MeanRadiantTemperatureCalculationType { get; set; } = (People_MeanRadiantTemperatureCalculationType)Enum.Parse(typeof(People_MeanRadiantTemperatureCalculationType), "ZoneAveraged");
        

[Description("optional (only required for runs of thermal comfort models: Fanger, Pierce, KSU, " +
    "CoolingEffectASH55 and AnkleDraftASH55)")]
[JsonProperty(PropertyName="surface_name_angle_factor_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceNameAngleFactorListName { get; set; } = "";
        

[Description("units in schedule are 0.0 to 1.0 optional (only required for runs of thermal comf" +
    "ort models: Fanger, Pierce, KSU, CoolingEffectASH55 and AnkleDraftASH55)")]
[JsonProperty(PropertyName="work_efficiency_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WorkEfficiencyScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="clothing_insulation_calculation_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public People_ClothingInsulationCalculationMethod ClothingInsulationCalculationMethod { get; set; } = (People_ClothingInsulationCalculationMethod)Enum.Parse(typeof(People_ClothingInsulationCalculationMethod), "ClothingInsulationSchedule");
        

[Description("a schedule value of 1 for the Scheduled method, and 2 for the DynamicClothingMode" +
    "lASHRAE55 method")]
[JsonProperty(PropertyName="clothing_insulation_calculation_method_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ClothingInsulationCalculationMethodScheduleName { get; set; } = "";
        

[Description("use \"Clo\" from ASHRAE or Thermal Comfort guides optional (only required for runs " +
    "of thermal comfort models: Fanger, Pierce, KSU, CoolingEffectASH55 and AnkleDraf" +
    "tASH55)")]
[JsonProperty(PropertyName="clothing_insulation_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ClothingInsulationScheduleName { get; set; } = "";
        

[Description("units in the schedule are m/s optional (only required for runs of thermal comfort" +
    " models: Fanger, Pierce, KSU, CoolingEffectASH55 and AnkleDraftASH55)")]
[JsonProperty(PropertyName="air_velocity_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirVelocityScheduleName { get; set; } = "";
        

[Description("optional (only needed for people thermal comfort results reporting)")]
[JsonProperty(PropertyName="thermal_comfort_model_1_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public People_ThermalComfortModel1Type ThermalComfortModel1Type { get; set; } = (People_ThermalComfortModel1Type)Enum.Parse(typeof(People_ThermalComfortModel1Type), "AdaptiveASH55");
        

[Description("optional (second type of thermal comfort model and results reporting)")]
[JsonProperty(PropertyName="thermal_comfort_model_2_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public People_ThermalComfortModel2Type ThermalComfortModel2Type { get; set; } = (People_ThermalComfortModel2Type)Enum.Parse(typeof(People_ThermalComfortModel2Type), "AdaptiveASH55");
        

[Description("optional (third thermal comfort model and report type)")]
[JsonProperty(PropertyName="thermal_comfort_model_3_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public People_ThermalComfortModel3Type ThermalComfortModel3Type { get; set; } = (People_ThermalComfortModel3Type)Enum.Parse(typeof(People_ThermalComfortModel3Type), "AdaptiveASH55");
        

[Description("optional (fourth thermal comfort model and report type)")]
[JsonProperty(PropertyName="thermal_comfort_model_4_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public People_ThermalComfortModel4Type ThermalComfortModel4Type { get; set; } = (People_ThermalComfortModel4Type)Enum.Parse(typeof(People_ThermalComfortModel4Type), "AdaptiveASH55");
        

[Description("optional (fifth thermal comfort model and report type)")]
[JsonProperty(PropertyName="thermal_comfort_model_5_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public People_ThermalComfortModel5Type ThermalComfortModel5Type { get; set; } = (People_ThermalComfortModel5Type)Enum.Parse(typeof(People_ThermalComfortModel5Type), "AdaptiveASH55");
        

[Description("optional (sixth thermal comfort model and report type)")]
[JsonProperty(PropertyName="thermal_comfort_model_6_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public People_ThermalComfortModel6Type ThermalComfortModel6Type { get; set; } = (People_ThermalComfortModel6Type)Enum.Parse(typeof(People_ThermalComfortModel6Type), "AdaptiveASH55");
        

[Description("optional (seventh thermal comfort model and report type)")]
[JsonProperty(PropertyName="thermal_comfort_model_7_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public People_ThermalComfortModel7Type ThermalComfortModel7Type { get; set; } = (People_ThermalComfortModel7Type)Enum.Parse(typeof(People_ThermalComfortModel7Type), "AdaptiveASH55");
        

[Description("units in the schedule are m/s this is the schedule of the air speed at the 0.1 m " +
    "above the floor optional (only required for runs of thermal comfort models Ankle" +
    "DraftASH55)")]
[JsonProperty(PropertyName="ankle_level_air_velocity_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AnkleLevelAirVelocityScheduleName { get; set; } = "";
    }
    
    public enum People_NumberOfPeopleCalculationMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Area/Person")]
        AreaPerson = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="People")]
        People = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="People/Area")]
        PeopleArea = 3,
    }
    
    public enum People_MeanRadiantTemperatureCalculationType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AngleFactor")]
        AngleFactor = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SurfaceWeighted")]
        SurfaceWeighted = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ZoneAveraged")]
        ZoneAveraged = 3,
    }
    
    public enum People_ClothingInsulationCalculationMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CalculationMethodSchedule")]
        CalculationMethodSchedule = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ClothingInsulationSchedule")]
        ClothingInsulationSchedule = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DynamicClothingModelASHRAE55")]
        DynamicClothingModelASHRAE55 = 3,
    }
    
    public enum People_ThermalComfortModel1Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveASH55")]
        AdaptiveASH55 = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveCEN15251")]
        AdaptiveCEN15251 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AnkleDraftASH55")]
        AnkleDraftASH55 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingEffectASH55")]
        CoolingEffectASH55 = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Fanger")]
        Fanger = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="KSU")]
        KSU = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Pierce")]
        Pierce = 6,
    }
    
    public enum People_ThermalComfortModel2Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveASH55")]
        AdaptiveASH55 = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveCEN15251")]
        AdaptiveCEN15251 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AnkleDraftASH55")]
        AnkleDraftASH55 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingEffectASH55")]
        CoolingEffectASH55 = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Fanger")]
        Fanger = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="KSU")]
        KSU = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Pierce")]
        Pierce = 6,
    }
    
    public enum People_ThermalComfortModel3Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveASH55")]
        AdaptiveASH55 = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveCEN15251")]
        AdaptiveCEN15251 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AnkleDraftASH55")]
        AnkleDraftASH55 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingEffectASH55")]
        CoolingEffectASH55 = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Fanger")]
        Fanger = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="KSU")]
        KSU = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Pierce")]
        Pierce = 6,
    }
    
    public enum People_ThermalComfortModel4Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveASH55")]
        AdaptiveASH55 = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveCEN15251")]
        AdaptiveCEN15251 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AnkleDraftASH55")]
        AnkleDraftASH55 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingEffectASH55")]
        CoolingEffectASH55 = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Fanger")]
        Fanger = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="KSU")]
        KSU = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Pierce")]
        Pierce = 6,
    }
    
    public enum People_ThermalComfortModel5Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveASH55")]
        AdaptiveASH55 = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveCEN15251")]
        AdaptiveCEN15251 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AnkleDraftASH55")]
        AnkleDraftASH55 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingEffectASH55")]
        CoolingEffectASH55 = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Fanger")]
        Fanger = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="KSU")]
        KSU = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Pierce")]
        Pierce = 6,
    }
    
    public enum People_ThermalComfortModel6Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveASH55")]
        AdaptiveASH55 = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveCEN15251")]
        AdaptiveCEN15251 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AnkleDraftASH55")]
        AnkleDraftASH55 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingEffectASH55")]
        CoolingEffectASH55 = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Fanger")]
        Fanger = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="KSU")]
        KSU = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Pierce")]
        Pierce = 6,
    }
    
    public enum People_ThermalComfortModel7Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveASH55")]
        AdaptiveASH55 = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveCEN15251")]
        AdaptiveCEN15251 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AnkleDraftASH55")]
        AnkleDraftASH55 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingEffectASH55")]
        CoolingEffectASH55 = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Fanger")]
        Fanger = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="KSU")]
        KSU = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Pierce")]
        Pierce = 6,
    }
    
    [Description("Used to specify radiant view factors for thermal comfort calculations.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ComfortViewFactorAngles
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="surface_1_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface1Name { get; set; } = "";
        

[JsonProperty(PropertyName="angle_factor_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AngleFactor1 { get; set; } = null;
        

[JsonProperty(PropertyName="surface_2_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface2Name { get; set; } = "";
        

[JsonProperty(PropertyName="angle_factor_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AngleFactor2 { get; set; } = null;
        

[JsonProperty(PropertyName="surface_3_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface3Name { get; set; } = "";
        

[JsonProperty(PropertyName="angle_factor_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AngleFactor3 { get; set; } = null;
        

[JsonProperty(PropertyName="surface_4_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface4Name { get; set; } = "";
        

[JsonProperty(PropertyName="angle_factor_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AngleFactor4 { get; set; } = null;
        

[JsonProperty(PropertyName="surface_5_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface5Name { get; set; } = "";
        

[JsonProperty(PropertyName="angle_factor_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AngleFactor5 { get; set; } = null;
        

[JsonProperty(PropertyName="surface_6_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface6Name { get; set; } = "";
        

[JsonProperty(PropertyName="angle_factor_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AngleFactor6 { get; set; } = null;
        

[JsonProperty(PropertyName="surface_7_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface7Name { get; set; } = "";
        

[JsonProperty(PropertyName="angle_factor_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AngleFactor7 { get; set; } = null;
        

[JsonProperty(PropertyName="surface_8_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface8Name { get; set; } = "";
        

[JsonProperty(PropertyName="angle_factor_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AngleFactor8 { get; set; } = null;
        

[JsonProperty(PropertyName="surface_9_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface9Name { get; set; } = "";
        

[JsonProperty(PropertyName="angle_factor_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AngleFactor9 { get; set; } = null;
        

[JsonProperty(PropertyName="surface_10_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface10Name { get; set; } = "";
        

[JsonProperty(PropertyName="angle_factor_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AngleFactor10 { get; set; } = null;
        

[JsonProperty(PropertyName="surface_11_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface11Name { get; set; } = "";
        

[JsonProperty(PropertyName="angle_factor_11", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AngleFactor11 { get; set; } = null;
        

[JsonProperty(PropertyName="surface_12_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface12Name { get; set; } = "";
        

[JsonProperty(PropertyName="angle_factor_12", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AngleFactor12 { get; set; } = null;
        

[JsonProperty(PropertyName="surface_13_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface13Name { get; set; } = "";
        

[JsonProperty(PropertyName="angle_factor_13", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AngleFactor13 { get; set; } = null;
        

[JsonProperty(PropertyName="surface_14_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface14Name { get; set; } = "";
        

[JsonProperty(PropertyName="angle_factor_14", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AngleFactor14 { get; set; } = null;
        

[JsonProperty(PropertyName="surface_15_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface15Name { get; set; } = "";
        

[JsonProperty(PropertyName="angle_factor_15", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AngleFactor15 { get; set; } = null;
        

[JsonProperty(PropertyName="surface_16_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface16Name { get; set; } = "";
        

[JsonProperty(PropertyName="angle_factor_16", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AngleFactor16 { get; set; } = null;
        

[JsonProperty(PropertyName="surface_17_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface17Name { get; set; } = "";
        

[JsonProperty(PropertyName="angle_factor_17", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AngleFactor17 { get; set; } = null;
        

[JsonProperty(PropertyName="surface_18_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface18Name { get; set; } = "";
        

[JsonProperty(PropertyName="angle_factor_18", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AngleFactor18 { get; set; } = null;
        

[JsonProperty(PropertyName="surface_19_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface19Name { get; set; } = "";
        

[JsonProperty(PropertyName="angle_factor_19", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AngleFactor19 { get; set; } = null;
        

[JsonProperty(PropertyName="surface_20_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Surface20Name { get; set; } = "";
        

[JsonProperty(PropertyName="angle_factor_20", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AngleFactor20 { get; set; } = null;
    }
    
    [Description("Sets internal gains for lights in the zone. If you use a ZoneList in the Zone or " +
        "ZoneList name field then this definition applies to all the zones in the ZoneLis" +
        "t.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Lights
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_or_zonelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneOrZonelistName { get; set; } = "";
        

[Description("units in schedule should be fraction applied to design level of lights, generally" +
    " (0.0 - 1.0)")]
[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[Description(@"The entered calculation method is used to create the maximum amount of lights for this set of attributes Choices: LightingLevel => Lighting Level -- simply enter watts of lights Watts/Area => Watts per Zone Floor Area -- enter the number to apply. Value * Floor Area = Lights Watts/Person => Watts per Person -- enter the number to apply. Value * Occupants = Lights")]
[JsonProperty(PropertyName="design_level_calculation_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Lights_DesignLevelCalculationMethod DesignLevelCalculationMethod { get; set; } = (Lights_DesignLevelCalculationMethod)Enum.Parse(typeof(Lights_DesignLevelCalculationMethod), "LightingLevel");
        

[JsonProperty(PropertyName="lighting_level", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LightingLevel { get; set; } = null;
        

[JsonProperty(PropertyName="watts_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WattsPerZoneFloorArea { get; set; } = null;
        

[JsonProperty(PropertyName="watts_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WattsPerPerson { get; set; } = null;
        

[Description("Used only for sizing calculation if return-air-fraction coefficients are specifie" +
    "d.")]
[JsonProperty(PropertyName="return_air_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnAirFraction { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_radiant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionRadiant { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_visible", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionVisible { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("For Daylighting:Controls must be 0 or 1:  0 = no dimming control, 1 = full dimmin" +
    "g control")]
[JsonProperty(PropertyName="fraction_replaceable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionReplaceable { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
        

[JsonProperty(PropertyName="return_air_fraction_calculated_from_plenum_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes ReturnAirFractionCalculatedFromPlenumTemperature { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("Used only if Return Air Fraction Is Calculated from Plenum Temperature = Yes Equa" +
    "tion is Return Air Fraction = Coefficient#1 - Coefficient#2 X PlenumTemp(degC)")]
[JsonProperty(PropertyName="return_air_fraction_function_of_plenum_temperature_coefficient_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnAirFractionFunctionOfPlenumTemperatureCoefficient1 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Used only if Return Air Fraction Is Calculated from Plenum Temperature = Yes Equa" +
    "tion is Return Air Fraction = Coefficient#1 - Coefficient#2 X PlenumTemp(degC)")]
[JsonProperty(PropertyName="return_air_fraction_function_of_plenum_temperature_coefficient_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnAirFractionFunctionOfPlenumTemperatureCoefficient2 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Name of the return air node for this heat gain. If left blank, defaults to the fi" +
    "rst return air node for the zone. Leave this field blank when using a ZoneList n" +
    "ame.")]
[JsonProperty(PropertyName="return_air_heat_gain_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReturnAirHeatGainNodeName { get; set; } = "";
    }
    
    public enum Lights_DesignLevelCalculationMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="LightingLevel")]
        LightingLevel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Watts/Area")]
        WattsArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Watts/Person")]
        WattsPerson = 3,
    }
    
    [Description("Sets internal gains for electric equipment in the zone. If you use a ZoneList in " +
        "the Zone or ZoneList name field then this definition applies to all the zones in" +
        " the ZoneList.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ElectricEquipment
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_or_zonelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneOrZonelistName { get; set; } = "";
        

[Description("units in schedule should be fraction applied to design level of electric equipmen" +
    "t, generally (0.0 - 1.0)")]
[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[Description(@"The entered calculation method is used to create the maximum amount of electric equipment for this set of attributes Choices: EquipmentLevel => Equipment Level -- simply enter watts of equipment Watts/Area => Watts per Zone Floor Area -- enter the number to apply. Value * Floor Area = Equipment Level Watts/Person => Watts per Person -- enter the number to apply. Value * Occupants = Equipment Level")]
[JsonProperty(PropertyName="design_level_calculation_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ElectricEquipment_DesignLevelCalculationMethod DesignLevelCalculationMethod { get; set; } = (ElectricEquipment_DesignLevelCalculationMethod)Enum.Parse(typeof(ElectricEquipment_DesignLevelCalculationMethod), "EquipmentLevel");
        

[JsonProperty(PropertyName="design_level", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignLevel { get; set; } = null;
        

[JsonProperty(PropertyName="watts_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WattsPerZoneFloorArea { get; set; } = null;
        

[JsonProperty(PropertyName="watts_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WattsPerPerson { get; set; } = null;
        

[JsonProperty(PropertyName="fraction_latent", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionLatent { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_radiant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionRadiant { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_lost", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionLost { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    public enum ElectricEquipment_DesignLevelCalculationMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="EquipmentLevel")]
        EquipmentLevel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Watts/Area")]
        WattsArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Watts/Person")]
        WattsPerson = 3,
    }
    
    [Description("Sets internal gains and contaminant rates for gas equipment in the zone. If you u" +
        "se a ZoneList in the Zone name field then this definition applies to all those z" +
        "ones.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GasEquipment
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_or_zonelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneOrZonelistName { get; set; } = "";
        

[Description("units in Schedule should be fraction applied to design level of gas equipment, ge" +
    "nerally (0.0 - 1.0)")]
[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[Description(@"The entered calculation method is used to create the maximum amount of gas equipment for this set of attributes Choices: EquipmentLevel => Design Level -- simply enter power input of equipment Watts/Area or Power/Area => Power per Zone Floor Area -- enter the number to apply. Value * Floor Area = Equipment Level Watts/Person or Power/Person => Power per Person -- enter the number to apply. Value * Occupants = Equipment Level")]
[JsonProperty(PropertyName="design_level_calculation_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public GasEquipment_DesignLevelCalculationMethod DesignLevelCalculationMethod { get; set; } = (GasEquipment_DesignLevelCalculationMethod)Enum.Parse(typeof(GasEquipment_DesignLevelCalculationMethod), "EquipmentLevel");
        

[JsonProperty(PropertyName="design_level", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignLevel { get; set; } = null;
        

[JsonProperty(PropertyName="power_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PowerPerZoneFloorArea { get; set; } = null;
        

[JsonProperty(PropertyName="power_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PowerPerPerson { get; set; } = null;
        

[JsonProperty(PropertyName="fraction_latent", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionLatent { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_radiant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionRadiant { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_lost", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionLost { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description(@"CO2 generation rate per unit of power input The default value assumes the equipment is fully vented. For unvented equipment, a suggested value is 3.45E-8 m3/s-W. This value is converted from a natural gas CO2 emission rate of 117 lbs CO2 per million Btu. The maximum value assumes to be 10 times of the recommended value.")]
[JsonProperty(PropertyName="carbon_dioxide_generation_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CarbonDioxideGenerationRate { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    public enum GasEquipment_DesignLevelCalculationMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="EquipmentLevel")]
        EquipmentLevel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Power/Area")]
        PowerArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Power/Person")]
        PowerPerson = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Watts/Area")]
        WattsArea = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Watts/Person")]
        WattsPerson = 5,
    }
    
    [Description("Sets internal gains for hot water equipment in the zone. If you use a ZoneList in" +
        " the Zone name field then this definition applies to all those zones.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HotWaterEquipment
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_or_zonelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneOrZonelistName { get; set; } = "";
        

[Description("units in Schedule should be fraction applied to design level of hot water equipme" +
    "nt, generally (0.0 - 1.0)")]
[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[Description(@"The entered calculation method is used to create the maximum amount of hot water equipment for this set of attributes Choices: EquipmentLevel => Design Level -- simply enter power input of equipment Watts/Area or Power/Area => Power per Zone Floor Area -- enter the number to apply. Value * Floor Area = Equipment Level Watts/Person or Power/Person => Power per Person -- enter the number to apply. Value * Occupants = Equipment Level")]
[JsonProperty(PropertyName="design_level_calculation_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HotWaterEquipment_DesignLevelCalculationMethod DesignLevelCalculationMethod { get; set; } = (HotWaterEquipment_DesignLevelCalculationMethod)Enum.Parse(typeof(HotWaterEquipment_DesignLevelCalculationMethod), "EquipmentLevel");
        

[JsonProperty(PropertyName="design_level", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignLevel { get; set; } = null;
        

[JsonProperty(PropertyName="power_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PowerPerZoneFloorArea { get; set; } = null;
        

[JsonProperty(PropertyName="power_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PowerPerPerson { get; set; } = null;
        

[JsonProperty(PropertyName="fraction_latent", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionLatent { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_radiant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionRadiant { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_lost", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionLost { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    public enum HotWaterEquipment_DesignLevelCalculationMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="EquipmentLevel")]
        EquipmentLevel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Power/Area")]
        PowerArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Power/Person")]
        PowerPerson = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Watts/Area")]
        WattsArea = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Watts/Person")]
        WattsPerson = 5,
    }
    
    [Description("Sets internal gains for steam equipment in the zone.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SteamEquipment
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_or_zonelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneOrZonelistName { get; set; } = "";
        

[Description("units in Schedule should be fraction applied to design level of steam equipment, " +
    "generally (0.0 - 1.0)")]
[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[Description(@"The entered calculation method is used to create the maximum amount of steam equipment for this set of attributes Choices: EquipmentLevel => Design Level -- simply enter power input of equipment Watts/Area or Power/Area => Power per Zone Floor Area -- enter the number to apply. Value * Floor Area = Equipment Level Watts/Person or Power/Person => Power per Person -- enter the number to apply. Value * Occupants = Equipment Level")]
[JsonProperty(PropertyName="design_level_calculation_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SteamEquipment_DesignLevelCalculationMethod DesignLevelCalculationMethod { get; set; } = (SteamEquipment_DesignLevelCalculationMethod)Enum.Parse(typeof(SteamEquipment_DesignLevelCalculationMethod), "EquipmentLevel");
        

[JsonProperty(PropertyName="design_level", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignLevel { get; set; } = null;
        

[JsonProperty(PropertyName="power_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PowerPerZoneFloorArea { get; set; } = null;
        

[JsonProperty(PropertyName="power_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PowerPerPerson { get; set; } = null;
        

[JsonProperty(PropertyName="fraction_latent", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionLatent { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_radiant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionRadiant { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_lost", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionLost { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    public enum SteamEquipment_DesignLevelCalculationMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="EquipmentLevel")]
        EquipmentLevel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Power/Area")]
        PowerArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Power/Person")]
        PowerPerson = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Watts/Area")]
        WattsArea = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Watts/Person")]
        WattsPerson = 5,
    }
    
    [Description("Sets internal gains or losses for \"other\" equipment in the zone.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class OtherEquipment
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="fuel_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public OtherEquipment_FuelType FuelType { get; set; } = (OtherEquipment_FuelType)Enum.Parse(typeof(OtherEquipment_FuelType), "None");
        

[JsonProperty(PropertyName="zone_or_zonelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneOrZonelistName { get; set; } = "";
        

[Description("units in Schedule should be fraction applied to design level of other equipment, " +
    "generally (0.0 - 1.0)")]
[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[Description(@"The entered calculation method is used to create the maximum amount of other equipment. to set a loss, use a negative value in the following fields. for this set of attributes Choices: EquipmentLevel => Design Level -- simply enter power input of equipment Watts/Area or Power/Area => Power per Zone Floor Area -- enter the number to apply. Value * Floor Area = Equipment Level Watts/Person or Power/Person => Power per Person -- enter the number to apply. Value * Occupants = Equipment Level")]
[JsonProperty(PropertyName="design_level_calculation_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public OtherEquipment_DesignLevelCalculationMethod DesignLevelCalculationMethod { get; set; } = (OtherEquipment_DesignLevelCalculationMethod)Enum.Parse(typeof(OtherEquipment_DesignLevelCalculationMethod), "EquipmentLevel");
        

[JsonProperty(PropertyName="design_level", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignLevel { get; set; } = null;
        

[JsonProperty(PropertyName="power_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PowerPerZoneFloorArea { get; set; } = null;
        

[JsonProperty(PropertyName="power_per_person", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PowerPerPerson { get; set; } = null;
        

[JsonProperty(PropertyName="fraction_latent", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionLatent { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_radiant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionRadiant { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_lost", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionLost { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("CO2 generation rate per unit of power input The default value assumes the equipme" +
    "nt is fully vented.")]
[JsonProperty(PropertyName="carbon_dioxide_generation_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CarbonDioxideGenerationRate { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    public enum OtherEquipment_FuelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coal")]
        Coal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Diesel")]
        Diesel = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="DistrictCooling")]
        DistrictCooling = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="DistrictHeating")]
        DistrictHeating = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Electricity")]
        Electricity = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo1")]
        FuelOilNo1 = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo2")]
        FuelOilNo2 = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Gasoline")]
        Gasoline = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="NaturalGas")]
        NaturalGas = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel1")]
        OtherFuel1 = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel2")]
        OtherFuel2 = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Propane")]
        Propane = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Steam")]
        Steam = 14,
    }
    
    public enum OtherEquipment_DesignLevelCalculationMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="EquipmentLevel")]
        EquipmentLevel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Power/Area")]
        PowerArea = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Power/Person")]
        PowerPerson = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Watts/Area")]
        WattsArea = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Watts/Person")]
        WattsPerson = 5,
    }
    
    [Description("This object describes air-cooled electric information technology equipment (ITE) " +
        "which has variable power consumption as a function of loading and temperature.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ElectricEquipment_ITE_AirCooled
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description(@"The specified method is used to calculate the IT inlet temperature and zone return air temperature. If FlowFromSystem is chosen, the zone is assumed to be well-mixed. If FlowControlWithApproachTemperatures is chosen, Supply and Return approach temperature should be defined to indicate the temperature difference due to the air distribution. When FlowControlWithApproachTemperatures is chosen, the inputs of Air Inlet Connection Type, Design Recirculation Fraction and Recirculation Function of Loading and Supply Temperature Curve Name are ignored. For multiple ITE objects defined for one zone, the same calculation method should apply. The FlowControlWithApproachTemperatures only applies to ITE zones with single duct VAV terminal unit. Other return air heat gains from window or lights are not allowed when FlowControlWithApproachTemperatures is chosen.")]
[JsonProperty(PropertyName="air_flow_calculation_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ElectricEquipment_ITE_AirCooled_AirFlowCalculationMethod AirFlowCalculationMethod { get; set; } = (ElectricEquipment_ITE_AirCooled_AirFlowCalculationMethod)Enum.Parse(typeof(ElectricEquipment_ITE_AirCooled_AirFlowCalculationMethod), "FlowFromSystem");
        

[Description("The entered calculation method is used to specify the design power input Watts/Un" +
    "it => Watts per Unit -- Design Power = Watts per Unit * Number of Units Watts/Ar" +
    "ea => Watts per Zone Floor Area -- Design Power = Watts per Zone Floor Area * Fl" +
    "oor Area")]
[JsonProperty(PropertyName="design_power_input_calculation_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ElectricEquipment_ITE_AirCooled_DesignPowerInputCalculationMethod DesignPowerInputCalculationMethod { get; set; } = (ElectricEquipment_ITE_AirCooled_DesignPowerInputCalculationMethod)Enum.Parse(typeof(ElectricEquipment_ITE_AirCooled_DesignPowerInputCalculationMethod), "Empty");
        

[JsonProperty(PropertyName="watts_per_unit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WattsPerUnit { get; set; } = null;
        

[JsonProperty(PropertyName="number_of_units", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfUnits { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="watts_per_zone_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WattsPerZoneFloorArea { get; set; } = null;
        

[Description("Operating schedule for this equipment, fraction applied to the design power input" +
    ", generally (0.0 - 1.0) If this field is blank, the schedule is assumed to alway" +
    "s be 1.0.")]
[JsonProperty(PropertyName="design_power_input_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignPowerInputScheduleName { get; set; } = "";
        

[Description("CPU loading schedule for this equipment as a fraction from 0.0 (idle) to 1.0 (ful" +
    "l load). If this field is blank, the schedule is assumed to always be 1.0.")]
[JsonProperty(PropertyName="cpu_loading_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CpuLoadingScheduleName { get; set; } = "";
        

[Description(@"The name of a two-variable curve or table lookup object which modifies the CPU power input as a function of CPU loading (x) and air inlet node temperature (y). This curve (table) should equal 1.0 at design conditions (CPU loading = 1.0 and Design Entering Air Temperature).")]
[JsonProperty(PropertyName="cpu_power_input_function_of_loading_and_air_temperature_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CpuPowerInputFunctionOfLoadingAndAirTemperatureCurveName { get; set; } = "";
        

[Description("The fraction of the total power input at design conditions which is for the cooli" +
    "ng fan(s)")]
[JsonProperty(PropertyName="design_fan_power_input_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignFanPowerInputFraction { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("The cooling fan air flow rate per total electric power input at design conditions" +
    "")]
[JsonProperty(PropertyName="design_fan_air_flow_rate_per_power_input", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignFanAirFlowRatePerPowerInput { get; set; } = null;
        

[Description(@"The name of a two-variable curve or table lookup object which modifies the cooling air flow rate as a function of CPU loading (x) and air inlet node temperature (y). This curve (table) should equal 1.0 at design conditions (CPU loading = 1.0 and Design Entering Air Temperature).")]
[JsonProperty(PropertyName="air_flow_function_of_loading_and_air_temperature_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirFlowFunctionOfLoadingAndAirTemperatureCurveName { get; set; } = "";
        

[Description("The name of a single-variable curve or table lookup object which modifies the coo" +
    "ling fan power as a function of flow fraction (x). This curve (table) should equ" +
    "al 1.0 at a flow fraction of 1.0.")]
[JsonProperty(PropertyName="fan_power_input_function_of_flow_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FanPowerInputFunctionOfFlowCurveName { get; set; } = "";
        

[Description("The entering air temperature at design conditions.")]
[JsonProperty(PropertyName="design_entering_air_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignEnteringAirTemperature { get; set; } = Double.Parse("15", CultureInfo.InvariantCulture);
        

[Description("Specifies the allowable operating conditions for the air inlet conditions. Used f" +
    "or reporting time outside allowable conditions.")]
[JsonProperty(PropertyName="environmental_class", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ElectricEquipment_ITE_AirCooled_EnvironmentalClass EnvironmentalClass { get; set; } = (ElectricEquipment_ITE_AirCooled_EnvironmentalClass)Enum.Parse(typeof(ElectricEquipment_ITE_AirCooled_EnvironmentalClass), "None");
        

[Description(@"Specifies the type of connection between the zone and the ITE air inlet node. AdjustedSupply = ITE inlet temperature will be the current Supply Air Node temperature adjusted by the current recirculation fraction. All heat output is added to the zone air heat balance as a convective gain. ZoneAirNode = ITE air inlet condition is  the average zone condition. All heat output is added to the zone air heat balance as a convective gain. RoomAirModel = ITE air inlet and outlet are connected to room air model nodes. This field is only used when Air Flow Calculation Method is FlowFromSystem.")]
[JsonProperty(PropertyName="air_inlet_connection_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ElectricEquipment_ITE_AirCooled_AirInletConnectionType AirInletConnectionType { get; set; } = (ElectricEquipment_ITE_AirCooled_AirInletConnectionType)Enum.Parse(typeof(ElectricEquipment_ITE_AirCooled_AirInletConnectionType), "AdjustedSupply");
        

[Description("Name of a RoomAir:Node object which is connected to the ITE air inlet.")]
[JsonProperty(PropertyName="air_inlet_room_air_model_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletRoomAirModelNodeName { get; set; } = "";
        

[Description("Name of a RoomAir:Node object which is connected to the ITE air outlet.")]
[JsonProperty(PropertyName="air_outlet_room_air_model_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletRoomAirModelNodeName { get; set; } = "";
        

[Description("Name of the supply air inlet node serving this ITE. Required if the Air Node Conn" +
    "ection Type = AdjustedSupply. Also required if Calculation Method = FlowControlW" +
    "ithApproachTemperatures. Also required if reporting of Supply Heat Index is desi" +
    "red.")]
[JsonProperty(PropertyName="supply_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyAirNodeName { get; set; } = "";
        

[Description(@"The recirculation fraction for this equipment at design conditions. This field is used only if the Air Node Connection Type = AdjustedSupply. The default is 0.0 (no recirculation). This field is only used when Air Flow Calculation Method is FlowFromSystem.")]
[JsonProperty(PropertyName="design_recirculation_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignRecirculationFraction { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description(@"The name of a two-variable curve or table lookup object which modifies the recirculation fractionas a function of CPU loading (x) and supply air node temperature (y). This curve (table) should equal 1.0 at design conditions (CPU loading = 1.0 and Design Entering Air Temperature).This field is used only if the Air Node Connection Type = AdjustedSupply. If this curve is left blank, then the curve is assumed to always equal 1.0. This field is only used when Air Flow Calculation Method is FlowFromSystem.")]
[JsonProperty(PropertyName="recirculation_function_of_loading_and_supply_temperature_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RecirculationFunctionOfLoadingAndSupplyTemperatureCurveName { get; set; } = "";
        

[Description("The efficiency of the power supply system serving this ITE")]
[JsonProperty(PropertyName="design_electric_power_supply_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignElectricPowerSupplyEfficiency { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description(@"The name of a single-variable curve or table lookup object which modifies the electric power supply efficiency as a function of part-load ratio (x). This curve (table) should equal 1.0 at full load (PLR = 1.0). If this curve is left blank, then the curve is assumed to always equal 1.0.")]
[JsonProperty(PropertyName="electric_power_supply_efficiency_function_of_part_load_ratio_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ElectricPowerSupplyEfficiencyFunctionOfPartLoadRatioCurveName { get; set; } = "";
        

[Description("Fraction of the electric power supply losses which are a heat gain to the zone If" +
    " this field is <1.0, the remainder of the losses are assumed to be lost to the o" +
    "utdoors.")]
[JsonProperty(PropertyName="fraction_of_electric_power_supply_losses_to_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfElectricPowerSupplyLossesToZone { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="cpu_end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CpuEndUseSubcategory { get; set; } = "ITE-CPU";
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="fan_end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FanEndUseSubcategory { get; set; } = "ITE-Fans";
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="electric_power_supply_end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ElectricPowerSupplyEndUseSubcategory { get; set; } = "ITE-UPS";
        

[Description(@"The difference of the IT inlet temperature from the AHU supply air temperature. Either Supply Temperature Difference or Supply Temperature Difference Schedule is required if Air Flow Calculation Method is set to FlowControlWithApproachTemperatures. This field is ignored when Air Flow Calculation Method is FlowFromSystem.")]
[JsonProperty(PropertyName="supply_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SupplyTemperatureDifference { get; set; } = null;
        

[Description(@"The difference schedule of the IT inlet temperature from the AHU supply air temperature. Either Supply Temperature Difference or Supply Temperature Difference Schedule is required if Air Flow Calculation Method is set to FlowControlWithApproachTemperatures. This field is ignored when Air Flow Calculation Method is FlowFromSystem.")]
[JsonProperty(PropertyName="supply_temperature_difference_schedule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupplyTemperatureDifferenceSchedule { get; set; } = "";
        

[Description(@"The difference of the the actual AHU return air temperature to the IT equipment outlet temperature. Either Return Temperature Difference or Return Temperature Difference Schedule is required if Air Flow Calculation Method is set to FlowControlWithApproachTemperatures. This field is ignored when Air Flow Calculation Method is FlowFromSystem.")]
[JsonProperty(PropertyName="return_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReturnTemperatureDifference { get; set; } = null;
        

[Description(@"The difference schedule of the actual AHU return air temperature to the IT equipment outlet temperature. Either Return Temperature Difference or Return Temperature Difference Schedule is required if Air Flow Calculation Method is set to FlowControlWithApproachTemperatures. This field is ignored when Air Flow Calculation Method is FlowFromSystem.")]
[JsonProperty(PropertyName="return_temperature_difference_schedule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReturnTemperatureDifferenceSchedule { get; set; } = "";
    }
    
    public enum ElectricEquipment_ITE_AirCooled_AirFlowCalculationMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FlowControlWithApproachTemperatures")]
        FlowControlWithApproachTemperatures = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FlowFromSystem")]
        FlowFromSystem = 2,
    }
    
    public enum ElectricEquipment_ITE_AirCooled_DesignPowerInputCalculationMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Watts/Area")]
        WattsArea = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Watts/Unit")]
        WattsUnit = 2,
    }
    
    public enum ElectricEquipment_ITE_AirCooled_EnvironmentalClass
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="A1")]
        A1 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="A2")]
        A2 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="A3")]
        A3 = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="A4")]
        A4 = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="B")]
        B = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="C")]
        C = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 7,
    }
    
    public enum ElectricEquipment_ITE_AirCooled_AirInletConnectionType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AdjustedSupply")]
        AdjustedSupply = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="RoomAirModel")]
        RoomAirModel = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ZoneAirNode")]
        ZoneAirNode = 3,
    }
    
    [Description("Specifies outside temperature-controlled electric baseboard heating.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneBaseboard_OutdoorTemperatureControlled
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("units in Schedule should be fraction applied to capacity of the baseboard heat eq" +
    "uipment, generally (0.0 - 1.0)")]
[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="capacity_at_low_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CapacityAtLowTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="low_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LowTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="capacity_at_high_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CapacityAtHighTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="high_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HighTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="fraction_radiant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionRadiant { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    [Description("Specifies an indoor swimming pools linked to a floor surface. The pool is assumed" +
        " to cover the entire floor to which it is linked.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SwimmingPool_Indoor
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Name of the floor surface where the pool is located.")]
[JsonProperty(PropertyName="surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceName { get; set; } = "";
        

[JsonProperty(PropertyName="average_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AverageDepth { get; set; } = null;
        

[JsonProperty(PropertyName="activity_factor_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ActivityFactorScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="make_up_water_supply_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MakeUpWaterSupplyScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="cover_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoverScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="cover_evaporation_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoverEvaporationFactor { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cover_convection_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoverConvectionFactor { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cover_short_wavelength_radiation_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoverShortWavelengthRadiationFactor { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cover_long_wavelength_radiation_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoverLongWavelengthRadiationFactor { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pool_water_inlet_node", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PoolWaterInletNode { get; set; } = "";
        

[JsonProperty(PropertyName="pool_water_outlet_node", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PoolWaterOutletNode { get; set; } = "";
        

[JsonProperty(PropertyName="pool_heating_system_maximum_water_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PoolHeatingSystemMaximumWaterFlowRate { get; set; } = null;
        

[Description("Power input per pool water flow rate")]
[JsonProperty(PropertyName="pool_miscellaneous_equipment_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PoolMiscellaneousEquipmentPower { get; set; } = null;
        

[JsonProperty(PropertyName="setpoint_temperature_schedule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointTemperatureSchedule { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_number_of_people", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumNumberOfPeople { get; set; } = null;
        

[JsonProperty(PropertyName="people_schedule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PeopleSchedule { get; set; } = "";
        

[JsonProperty(PropertyName="people_heat_gain_schedule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PeopleHeatGainSchedule { get; set; } = "";
    }
    
    [Description("Represents internal CO2 gains and sinks in the zone.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneContaminantSourceAndSink_CarbonDioxide
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Positive values represent sources and negative values represent sinks.")]
[JsonProperty(PropertyName="design_generation_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignGenerationRate { get; set; } = null;
        

[Description("Value in this schedule should be a fraction (generally 0.0 - 1.0) applied to the " +
    "Design Generation Rate")]
[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
    }
    
    [Description("Sets internal generic contaminant gains and sinks in a zone with constant values." +
        "")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneContaminantSourceAndSink_Generic_Constant
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("The values represent source.")]
[JsonProperty(PropertyName="design_generation_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignGenerationRate { get; set; } = null;
        

[Description("Value in this schedule should be a fraction (generally 0.0 - 1.0) applied to the " +
    "Design Generation Rate")]
[JsonProperty(PropertyName="generation_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string GenerationScheduleName { get; set; } = "";
        

[Description("The value represent sink.")]
[JsonProperty(PropertyName="design_removal_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignRemovalCoefficient { get; set; } = null;
        

[Description("Value in this schedule should be a fraction (generally 0.0 - 1.0) applied to the " +
    "Design removal Coefficient")]
[JsonProperty(PropertyName="removal_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RemovalScheduleName { get; set; } = "";
    }
    
    [Description("Simulate generic contaminant source driven by the pressure difference across a su" +
        "rface.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceContaminantSourceAndSink_Generic_PressureDriven
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceName { get; set; } = "";
        

[JsonProperty(PropertyName="design_generation_rate_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignGenerationRateCoefficient { get; set; } = null;
        

[Description("Value in this schedule should be a fraction (generally 0.0 - 1.0) applied to the " +
    "Design Generation Rate Coefficient")]
[JsonProperty(PropertyName="generation_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string GenerationScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="generation_exponent", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GenerationExponent { get; set; } = null;
    }
    
    [Description("Simulate generic contaminant source driven by the cutoff concentration model.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneContaminantSourceAndSink_Generic_CutoffModel
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="design_generation_rate_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignGenerationRateCoefficient { get; set; } = null;
        

[Description("Value in this schedule should be a fraction (generally 0.0 - 1.0) applied to the " +
    "Design Generation Rate Coefficient")]
[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[Description("When the zone concentration level is greater than the cutoff level, emission stop" +
    "s, and the source level is zero.")]
[JsonProperty(PropertyName="cutoff_generic_contaminant_at_which_emission_ceases", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CutoffGenericContaminantAtWhichEmissionCeases { get; set; } = null;
    }
    
    [Description("Simulate generic contaminant source driven by the cutoff concentration model.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneContaminantSourceAndSink_Generic_DecaySource
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="initial_emission_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InitialEmissionRate { get; set; } = null;
        

[Description("Value in this schedule should be a fraction (generally 0.0 - 1.0) applied to the " +
    "Initial Emission Rate. When the value is equal to 1.0, the time will be reset to" +
    " zero.")]
[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="delay_time_constant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DelayTimeConstant { get; set; } = null;
    }
    
    [Description("Simulate generic contaminant source driven by the boundary layer diffusion contro" +
        "lled model.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceContaminantSourceAndSink_Generic_BoundaryLayerDiffusion
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceName { get; set; } = "";
        

[JsonProperty(PropertyName="mass_transfer_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MassTransferCoefficient { get; set; } = null;
        

[Description("Value in this schedule should be a fraction (generally 0.0 - 1.0) applied to the " +
    "Initial Emission Rate. When the value is equal to 1.0, the time will be reset to" +
    " zero.")]
[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="henry_adsorption_constant_or_partition_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HenryAdsorptionConstantOrPartitionCoefficient { get; set; } = null;
    }
    
    [Description("Simulate generic contaminant source driven by the boundary layer diffusion contro" +
        "lled model.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceContaminantSourceAndSink_Generic_DepositionVelocitySink
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceName { get; set; } = "";
        

[JsonProperty(PropertyName="deposition_velocity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DepositionVelocity { get; set; } = null;
        

[Description("Value in this schedule should be a fraction (generally 0.0 - 1.0) applied to the " +
    "Initial Emission Rate. When the value is equal to 1.0, the time will be reset to" +
    " zero.")]
[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
    }
    
    [Description("Simulate generic contaminant source driven by the boundary layer diffusion contro" +
        "lled model.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneContaminantSourceAndSink_Generic_DepositionRateSink
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="deposition_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DepositionRate { get; set; } = null;
        

[Description("Value in this schedule should be a fraction (generally 0.0 - 1.0) applied to the " +
    "Initial Emission Rate. When the value is equal to 1.0, the time will be reset to" +
    " zero.")]
[JsonProperty(PropertyName="schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleName { get; set; } = "";
    }
}
