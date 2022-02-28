namespace EnergyPlus.Schedules
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
    using EnergyPlus.PythonPluginSystem;
    using EnergyPlus.Refrigeration;
    using EnergyPlus.RoomAirModels;
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
    
    
    [Description("ScheduleTypeLimits specifies the data types and limits for the values contained i" +
        "n schedules")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ScheduleTypeLimits
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("lower limit (real or integer) for the Schedule Type. e.g. if fraction, this is 0." +
    "0")]
[JsonProperty(PropertyName="lower_limit_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LowerLimitValue { get; set; } = null;
        

[Description("upper limit (real or integer) for the Schedule Type. e.g. if fraction, this is 1." +
    "0")]
[JsonProperty(PropertyName="upper_limit_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> UpperLimitValue { get; set; } = null;
        

[Description("Numeric type is either Continuous (all numbers within the min and max are valid o" +
    "r Discrete (only integer numbers between min and max are valid. (Could also allo" +
    "w REAL and INTEGER to mean the same things)")]
[JsonProperty(PropertyName="numeric_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ScheduleTypeLimits_NumericType NumericType { get; set; } = (ScheduleTypeLimits_NumericType)Enum.Parse(typeof(ScheduleTypeLimits_NumericType), "Continuous");
        

[Description("Temperature (C or F) DeltaTemperature (C or F) PrecipitationRate (m/hr or ft/hr) " +
    "Angle (degrees) Convection Coefficient (W/m2-K or Btu/sqft-hr-F) Activity Level " +
    "(W/person) Velocity (m/s or ft/min) Capacity (W or Btu/h) Power (W)")]
[JsonProperty(PropertyName="unit_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ScheduleTypeLimits_UnitType UnitType { get; set; } = (ScheduleTypeLimits_UnitType)Enum.Parse(typeof(ScheduleTypeLimits_UnitType), "Dimensionless");
    }
    
    public enum ScheduleTypeLimits_NumericType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Continuous")]
        Continuous = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Discrete")]
        Discrete = 1,
    }
    
    public enum ScheduleTypeLimits_UnitType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ActivityLevel")]
        ActivityLevel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Angle")]
        Angle = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Availability")]
        Availability = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Capacity")]
        Capacity = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Control")]
        Control = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="ConvectionCoefficient")]
        ConvectionCoefficient = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="DeltaTemperature")]
        DeltaTemperature = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Mode")]
        Mode = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="Percent")]
        Percent = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="PrecipitationRate")]
        PrecipitationRate = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Velocity")]
        Velocity = 14,
    }
    
    [Description("A Schedule:Day:Hourly contains 24 values for each hour of the day.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Schedule_Day_Hourly
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="schedule_type_limits_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleTypeLimitsName { get; set; } = "";
        

[JsonProperty(PropertyName="hour_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour1 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hour_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour2 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hour_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour3 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hour_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour4 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hour_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour5 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hour_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour6 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hour_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour7 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hour_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour8 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hour_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour9 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hour_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour10 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hour_11", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour11 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hour_12", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour12 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hour_13", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour13 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hour_14", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour14 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hour_15", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour15 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hour_16", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour16 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hour_17", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour17 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hour_18", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour18 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hour_19", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour19 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hour_20", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour20 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hour_21", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour21 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hour_22", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour22 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hour_23", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour23 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hour_24", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Hour24 { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    [Description("A Schedule:Day:Interval contains a full day of values with specified end times fo" +
        "r each value Currently, is set up to allow for 10 minute intervals for an entire" +
        " day.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Schedule_Day_Interval
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="schedule_type_limits_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleTypeLimitsName { get; set; } = "";
        

[Description(@"when the interval does not match the user specified timestep a Average choice will average between the intervals request (to timestep resolution. A No choice will use the interval value at the simulation timestep without regard to if it matches the boundary or not. A Linear choice will interpolate linearly between successive values.")]
[JsonProperty(PropertyName="interpolate_to_timestep", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Schedule_Day_Interval_InterpolateToTimestep InterpolateToTimestep { get; set; } = (Schedule_Day_Interval_InterpolateToTimestep)Enum.Parse(typeof(Schedule_Day_Interval_InterpolateToTimestep), "No");
        

[JsonProperty(PropertyName="data", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Schedules.Schedule_Day_Interval_Data_Item> Data { get; set; } = null;
    }
    
    public enum Schedule_Day_Interval_InterpolateToTimestep
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Average")]
        Average = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Linear")]
        Linear = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="No")]
        No = 3,
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Schedule_Day_Interval_Data_Item
    {
        

[JsonProperty(PropertyName="time", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Time { get; set; } = "";
        

[JsonProperty(PropertyName="value_until_time", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ValueUntilTime { get; set; } = null;
    }
    
    [Description("Schedule:Day:List will allow the user to list 24 hours worth of values, which can" +
        " be sub-hourly in nature.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Schedule_Day_List
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="schedule_type_limits_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleTypeLimitsName { get; set; } = "";
        

[Description(@"when the interval does not match the user specified timestep a ""Average"" choice will average between the intervals request (to timestep resolution. A ""No"" choice will use the interval value at the simulation timestep without regard to if it matches the boundary or not. A ""Linear"" choice will interpolate linearly between successive values.")]
[JsonProperty(PropertyName="interpolate_to_timestep", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Schedule_Day_List_InterpolateToTimestep InterpolateToTimestep { get; set; } = (Schedule_Day_List_InterpolateToTimestep)Enum.Parse(typeof(Schedule_Day_List_InterpolateToTimestep), "No");
        

[Description("Must be evenly divisible into 60")]
[JsonProperty(PropertyName="minutes_per_item", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinutesPerItem { get; set; } = null;
        

[JsonProperty(PropertyName="extensions", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Extensions { get; set; } = "";
    }
    
    public enum Schedule_Day_List_InterpolateToTimestep
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Average")]
        Average = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Linear")]
        Linear = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="No")]
        No = 3,
    }
    
    [Description("A Schedule:Week:Daily contains 12 Schedule:Day:Hourly objects, one for each day t" +
        "ype.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Schedule_Week_Daily
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="sunday_schedule_day_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SundayScheduleDayName { get; set; } = "";
        

[JsonProperty(PropertyName="monday_schedule_day_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MondayScheduleDayName { get; set; } = "";
        

[JsonProperty(PropertyName="tuesday_schedule_day_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TuesdayScheduleDayName { get; set; } = "";
        

[JsonProperty(PropertyName="wednesday_schedule_day_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WednesdayScheduleDayName { get; set; } = "";
        

[JsonProperty(PropertyName="thursday_schedule_day_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ThursdayScheduleDayName { get; set; } = "";
        

[JsonProperty(PropertyName="friday_schedule_day_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FridayScheduleDayName { get; set; } = "";
        

[JsonProperty(PropertyName="saturday_schedule_day_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SaturdayScheduleDayName { get; set; } = "";
        

[JsonProperty(PropertyName="holiday_schedule_day_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HolidayScheduleDayName { get; set; } = "";
        

[JsonProperty(PropertyName="summerdesignday_schedule_day_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SummerdesigndayScheduleDayName { get; set; } = "";
        

[JsonProperty(PropertyName="winterdesignday_schedule_day_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WinterdesigndayScheduleDayName { get; set; } = "";
        

[JsonProperty(PropertyName="customday1_schedule_day_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Customday1ScheduleDayName { get; set; } = "";
        

[JsonProperty(PropertyName="customday2_schedule_day_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Customday2ScheduleDayName { get; set; } = "";
    }
    
    [Description("Compact definition for Schedule:Day:List")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Schedule_Week_Compact
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="data", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Schedules.Schedule_Week_Compact_Data_Item> Data { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Schedule_Week_Compact_Data_Item
    {
        

[JsonProperty(PropertyName="daytype_list", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DaytypeList { get; set; } = "";
        

[JsonProperty(PropertyName="schedule_day_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleDayName { get; set; } = "";
    }
    
    [Description("A Schedule:Year contains from 1 to 52 week schedules")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Schedule_Year
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="schedule_type_limits_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleTypeLimitsName { get; set; } = "";
        

[JsonProperty(PropertyName="schedule_weeks", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Schedules.Schedule_Year_ScheduleWeeks_Item> ScheduleWeeks { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Schedule_Year_ScheduleWeeks_Item
    {
        

[JsonProperty(PropertyName="schedule_week_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleWeekName { get; set; } = "";
        

[JsonProperty(PropertyName="start_month", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartMonth { get; set; } = null;
        

[JsonProperty(PropertyName="start_day", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StartDay { get; set; } = null;
        

[JsonProperty(PropertyName="end_month", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EndMonth { get; set; } = null;
        

[JsonProperty(PropertyName="end_day", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EndDay { get; set; } = null;
    }
    
    [Description(@"Irregular object. Does not follow the usual definition for fields. Fields A3... are: Through: Date For: Applicable days (ref: Schedule:Week:Compact) Interpolate: Average/Linear/No (ref: Schedule:Day:Interval) -- optional, if not used will be ""No"" Until: <Time> (ref: Schedule:Day:Interval) <numeric value> words ""Through"",""For"",""Interpolate"",""Until"" must be included.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Schedule_Compact
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="schedule_type_limits_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleTypeLimitsName { get; set; } = "";
        

[JsonProperty(PropertyName="data", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Data { get; set; } = "";
    }
    
    [Description("Constant hourly value for entire year.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Schedule_Constant
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="schedule_type_limits_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleTypeLimitsName { get; set; } = "";
        

[JsonProperty(PropertyName="hourly_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HourlyValue { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    [Description("A Schedule:File:Shading points to a CSV file that has 8760-8784 hours of sunlit f" +
        "raction data for all or some of the exterior surfaces.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Schedule_File_Shading
    {
        

[Description("The name of the file that writes all shading data.")]
[JsonProperty(PropertyName="file_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FileName { get; set; } = "";
    }
    
    [Description("A Schedule:File points to a text computer file that has 8760-8784 hours of data.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Schedule_File
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="schedule_type_limits_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ScheduleTypeLimitsName { get; set; } = "";
        

[JsonProperty(PropertyName="file_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FileName { get; set; } = "";
        

[JsonProperty(PropertyName="column_number", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ColumnNumber { get; set; } = null;
        

[JsonProperty(PropertyName="rows_to_skip_at_top", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RowsToSkipAtTop { get; set; } = null;
        

[Description("8760 hours does not account for leap years, 8784 does. should be either 8760 or 8" +
    "784")]
[JsonProperty(PropertyName="number_of_hours_of_data", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfHoursOfData { get; set; } = Double.Parse("8760", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="column_separator", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Schedule_File_ColumnSeparator ColumnSeparator { get; set; } = (Schedule_File_ColumnSeparator)Enum.Parse(typeof(Schedule_File_ColumnSeparator), "Comma");
        

[Description(@"when the interval does not match the user specified timestep a ""Yes"" choice will average between the intervals request (to timestep resolution. a ""No"" choice will use the interval value at the simulation timestep without regard to if it matches the boundary or not.")]
[JsonProperty(PropertyName="interpolate_to_timestep", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes InterpolateToTimestep { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("Must be evenly divisible into 60")]
[JsonProperty(PropertyName="minutes_per_item", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinutesPerItem { get; set; } = null;
    }
    
    public enum Schedule_File_ColumnSeparator
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Comma")]
        Comma = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Semicolon")]
        Semicolon = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Space")]
        Space = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Tab")]
        Tab = 4,
    }
}
