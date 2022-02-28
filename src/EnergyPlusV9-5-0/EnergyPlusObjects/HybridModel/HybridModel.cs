namespace EnergyPlus.HybridModel
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
    
    
    [Description("Zones with measured air temperature data and a range of dates. If the range of te" +
        "mperature measurement dates includes a leap day, the weather data should include" +
        " a leap day.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HybridModel_Zone
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Use measured zone air temperature to calculate zone internal thermal mass. If set" +
    " to Yes, the measured zone air temperature should be provided to calculate the t" +
    "hermal mass. If set to No, the inverse calculation of thermal mass will not be a" +
    "ctivated.")]
[JsonProperty(PropertyName="calculate_zone_internal_thermal_mass", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes CalculateZoneInternalThermalMass { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description(@"Use measured temperature data (temperature, humidity ratio, or CO2 concentration) to calculate zone air infiltration air flow rate. Only one of field Calculate Zone Internal Thermal Mass, Calculate Zone Air Infiltration Rate, and Calculate Zone People Count can be set to YES at a time. By default, this field is set to NO. When set to NO, the inverse calculation of the zone air infiltration rate will not be activated. If this field is set to YES, one of the following fields (combinations) should be provided: 1. Measurements were conducted when HVAC is free-floating: 1.1 Zone Measured Air Temperature Schedule Name 1.2 Zone Measured Air Humidity Ratio Schedule Name 1.3 Zone Measured Air CO2 Concentration Schedule Name 2. Measurements were conducted when HVAC is on: 2.1 Zone Measured Air Temperature Schedule Name, Zone Input Supply Air Temperature Schedule Name, and Zone Input Supply Air Mass Flow Rate Schedule Name 2.2 Zone Measured Air Humidity Ratio Schedule Name, Zone Input Supply Air Temperature Schedule Name, Zone Input Supply Air Mass Flow Rate Schedule Name, and Zone Input Supply Air Humidity Ratio Schedule Name 2.3 Zone Measured Air CO2 Concentration Schedule Name, Zone Input Supply Air Mass Flow Rate Schedule Name, and Zone Input Supply Air CO2 Concentration Schedule Name")]
[JsonProperty(PropertyName="calculate_zone_air_infiltration_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes CalculateZoneAirInfiltrationRate { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("Use measured humidity ratio data (temperature, humidity ratio, or CO2 concentrati" +
    "on) to calculate zone people count. Only one of field Calculate Zone Internal Th" +
    "ermal Mass, Calculate Zone Air Infiltration Rate, and Calculate Zone People Coun" +
    "t can be set to YES at a time. By default, this field is set to NO. When set to " +
    "NO, the inverse calculation of the zone people count will not be activated. If t" +
    "his field is set to YES, one of the following fields (combinations) should be pr" +
    "ovided: 1. Measurements were conducted when HVAC is free-floating: 1.1 Zone Meas" +
    "ured Air Temperature Schedule Name 1.2 Zone Measured Air Humidity Ratio Schedule" +
    " Name 1.3 Zone Measured Air CO2 Concentration Schedule Name 2. Measurements were" +
    " conducted when HVAC is on: 2.1 Zone Measured Air Temperature Schedule Name, Zon" +
    "e Input Supply Air Temperature Schedule Name, and Zone Input Supply Air Mass Flo" +
    "w Rate Schedule Name 2.2 Zone Measured Air Humidity Ratio Schedule Name, Zone In" +
    "put Supply Air Temperature Schedule Name, Zone Input Supply Air Mass Flow Rate S" +
    "chedule Name, and Zone Input Supply Air Humidity Ratio Schedule Name 2.3 Zone Me" +
    "asured Air CO2 Concentration Schedule Name, Zone Input Supply Air Mass Flow Rate" +
    " Schedule Name, and Zone Input Supply Air CO2 Concentration Schedule Name Field " +
    "Zone Input People Activity Schedule Name, Zone Input People Sensible Heat Fracti" +
    "on Schedule Name, Zone Input People Radiant Heat Fraction Schedule Name, Zone In" +
    "put People CO2 Generation Rate Schedule Name are optional. If provided, the defa" +
    "ult people activity level (130W), sensible heat generation rate (78W), latent he" +
    "at generation (52W) rate, and CO2 generation rate (0.0000000382 [m3/(s*W)]) will" +
    " be overwritten correspondingly.")]
[JsonProperty(PropertyName="calculate_zone_people_count", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes CalculateZonePeopleCount { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("from Schedule:File")]
[JsonProperty(PropertyName="zone_measured_air_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneMeasuredAirTemperatureScheduleName { get; set; } = "";
        

[Description("from Schedule:File")]
[JsonProperty(PropertyName="zone_measured_air_humidity_ratio_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneMeasuredAirHumidityRatioScheduleName { get; set; } = "";
        

[Description("from Schedule:File")]
[JsonProperty(PropertyName="zone_measured_air_co2_concentration_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneMeasuredAirCo2ConcentrationScheduleName { get; set; } = "";
        

[Description("When this field is provided and valid, the default people activity level (used to" +
    " calculate people count) will be overwritten. from Schedule:File")]
[JsonProperty(PropertyName="zone_input_people_activity_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneInputPeopleActivityScheduleName { get; set; } = "";
        

[Description("When this field is provided and valid, the default sensible heat fraction from pe" +
    "ople (used to calculate people count) will be overwritten. from Schedule:File")]
[JsonProperty(PropertyName="zone_input_people_sensible_heat_fraction_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneInputPeopleSensibleHeatFractionScheduleName { get; set; } = "";
        

[Description("When this field is provided and valid, the default radiant heat portion of the se" +
    "nsible heat from people (used to calculate people count) will be overwritten. fr" +
    "om Schedule:File")]
[JsonProperty(PropertyName="zone_input_people_radiant_heat_fraction_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneInputPeopleRadiantHeatFractionScheduleName { get; set; } = "";
        

[Description("When this field is provided and valid, the default people CO2 generation rate (us" +
    "ed to calculate people count) will be overwritten. from Schedule:File")]
[JsonProperty(PropertyName="zone_input_people_co2_generation_rate_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneInputPeopleCo2GenerationRateScheduleName { get; set; } = "";
        

[Description("from Schedule:File")]
[JsonProperty(PropertyName="zone_input_supply_air_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneInputSupplyAirTemperatureScheduleName { get; set; } = "";
        

[Description("from Schedule:File")]
[JsonProperty(PropertyName="zone_input_supply_air_mass_flow_rate_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneInputSupplyAirMassFlowRateScheduleName { get; set; } = "";
        

[Description("from Schedule:File")]
[JsonProperty(PropertyName="zone_input_supply_air_humidity_ratio_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneInputSupplyAirHumidityRatioScheduleName { get; set; } = "";
        

[Description("from Schedule:File")]
[JsonProperty(PropertyName="zone_input_supply_air_co2_concentration_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneInputSupplyAirCo2ConcentrationScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="begin_month", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BeginMonth { get; set; } = null;
        

[JsonProperty(PropertyName="begin_day_of_month", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BeginDayOfMonth { get; set; } = null;
        

[JsonProperty(PropertyName="end_month", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EndMonth { get; set; } = null;
        

[JsonProperty(PropertyName="end_day_of_month", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EndDayOfMonth { get; set; } = null;
    }
}
