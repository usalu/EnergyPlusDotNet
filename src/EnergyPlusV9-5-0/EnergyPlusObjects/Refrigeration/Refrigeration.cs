namespace EnergyPlus.Refrigeration
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
    
    
    [Description(@"The Refrigeration Case object works in conjunction with a compressor rack, a refrigeration system, or a secondary loop to simulate the performance of a refrigerated case system. The object calculates the energy use for lights, fans and anti-sweat heaters and accounts for the sensible and latent heat exchange with the surrounding environment (termed ""case credits"") which impacts the temperature and humidity in the zone where the case is located.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Refrigeration_Case
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("This must be a controlled zone and appear in a ZoneHVAC:EquipmentConnections obje" +
    "ct.")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="rated_ambient_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedAmbientTemperature { get; set; } = Double.Parse("23.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="rated_ambient_relative_humidity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedAmbientRelativeHumidity { get; set; } = Double.Parse("55", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="rated_total_cooling_capacity_per_unit_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedTotalCoolingCapacityPerUnitLength { get; set; } = Double.Parse("1900", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="rated_latent_heat_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedLatentHeatRatio { get; set; } = Double.Parse("0.3", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="rated_runtime_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedRuntimeFraction { get; set; } = Double.Parse("0.85", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="case_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CaseLength { get; set; } = Double.Parse("3", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="case_operating_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CaseOperatingTemperature { get; set; } = Double.Parse("1.1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="latent_case_credit_curve_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_Case_LatentCaseCreditCurveType LatentCaseCreditCurveType { get; set; } = (Refrigeration_Case_LatentCaseCreditCurveType)Enum.Parse(typeof(Refrigeration_Case_LatentCaseCreditCurveType), "CaseTemperatureMethod");
        

[JsonProperty(PropertyName="latent_case_credit_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string LatentCaseCreditCurveName { get; set; } = "";
        

[JsonProperty(PropertyName="standard_case_fan_power_per_unit_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StandardCaseFanPowerPerUnitLength { get; set; } = Double.Parse("75", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="operating_case_fan_power_per_unit_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OperatingCaseFanPowerPerUnitLength { get; set; } = Double.Parse("75", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="standard_case_lighting_power_per_unit_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StandardCaseLightingPowerPerUnitLength { get; set; } = Double.Parse("90", CultureInfo.InvariantCulture);
        

[Description("default set equal to Standard Case Lighting Power per Unit Length")]
[JsonProperty(PropertyName="installed_case_lighting_power_per_unit_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InstalledCaseLightingPowerPerUnitLength { get; set; } = null;
        

[JsonProperty(PropertyName="case_lighting_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CaseLightingScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="fraction_of_lighting_energy_to_case", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfLightingEnergyToCase { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="case_anti_sweat_heater_power_per_unit_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CaseAntiSweatHeaterPowerPerUnitLength { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This field is only applicable to the Linear, Dewpoint Method, and Heat Balance Me" +
    "thod anti-sweat heater control types")]
[JsonProperty(PropertyName="minimum_anti_sweat_heater_power_per_unit_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumAntiSweatHeaterPowerPerUnitLength { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="anti_sweat_heater_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_Case_AntiSweatHeaterControlType AntiSweatHeaterControlType { get; set; } = (Refrigeration_Case_AntiSweatHeaterControlType)Enum.Parse(typeof(Refrigeration_Case_AntiSweatHeaterControlType), "None");
        

[Description("This field is only applicable to Linear AS heater control type Zone relative humi" +
    "dity (%) where anti-sweat heater energy is zero")]
[JsonProperty(PropertyName="humidity_at_zero_anti_sweat_heater_energy", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidityAtZeroAntiSweatHeaterEnergy { get; set; } = Double.Parse("-10", CultureInfo.InvariantCulture);
        

[Description("This field only applicable to Heat Balance Method AS heater control type Height m" +
    "ust be greater than zero if Heat Balance Method AS heater control is selected")]
[JsonProperty(PropertyName="case_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CaseHeight { get; set; } = Double.Parse("1.5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_of_anti_sweat_heater_energy_to_case", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfAntiSweatHeaterEnergyToCase { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Used to evaluate load on case as well as power or heat consumption")]
[JsonProperty(PropertyName="case_defrost_power_per_unit_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CaseDefrostPowerPerUnitLength { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="case_defrost_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_Case_CaseDefrostType CaseDefrostType { get; set; } = (Refrigeration_Case_CaseDefrostType)Enum.Parse(typeof(Refrigeration_Case_CaseDefrostType), "OffCycle");
        

[Description("A case defrost schedule name is required unless case defrost type = None")]
[JsonProperty(PropertyName="case_defrost_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CaseDefrostScheduleName { get; set; } = "";
        

[Description(@"If left blank, the defrost schedule will be used The start time for each defrost period in this drip-down schedule should coincide with the start time for each defrost period in the case defrost schedule (previous input field). The length of each defrost drip-down period must be greater than or equal to the corresponding defrost period specified in the case defrost schedule. This extra time allows the melted frost to drip from the coil before refrigeration is restarted.")]
[JsonProperty(PropertyName="case_defrost_drip_down_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CaseDefrostDripDownScheduleName { get; set; } = "";
        

[Description("Case Temperature, Relative Humidity, and Dewpoint Method are applicable to case d" +
    "efrost types with temperature termination only.")]
[JsonProperty(PropertyName="defrost_energy_correction_curve_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_Case_DefrostEnergyCorrectionCurveType DefrostEnergyCorrectionCurveType { get; set; } = (Refrigeration_Case_DefrostEnergyCorrectionCurveType)Enum.Parse(typeof(Refrigeration_Case_DefrostEnergyCorrectionCurveType), "None");
        

[Description("Defrost Energy Correction Curve Name is applicable to case defrost types with tem" +
    "perature termination only.")]
[JsonProperty(PropertyName="defrost_energy_correction_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DefrostEnergyCorrectionCurveName { get; set; } = "";
        

[JsonProperty(PropertyName="under_case_hvac_return_air_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> UnderCaseHvacReturnAirFraction { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Schedule values should be in units of Watts per unit case length (W/m) Leave this" +
    " field blank if no restocking is to be modeled")]
[JsonProperty(PropertyName="refrigerated_case_restocking_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RefrigeratedCaseRestockingScheduleName { get; set; } = "";
        

[Description("Schedule values should be from 0 to 1 Leave this field blank if no case credit fr" +
    "action is to be applied")]
[JsonProperty(PropertyName="case_credit_fraction_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CaseCreditFractionScheduleName { get; set; } = "";
        

[Description(@"Required for detailed refrigeration system, not for compressor rack For a DX system, enter the saturated temperature for refrigerant pressure leaving case For a brine-cooled cooled (secondary system) case, enter the brine inlet temperature Default is 5 C less than case operating temperature")]
[JsonProperty(PropertyName="design_evaporator_temperature_or_brine_inlet_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignEvaporatorTemperatureOrBrineInletTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="average_refrigerant_charge_inventory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AverageRefrigerantChargeInventory { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Name of the return air node for this case. If left blank, defaults to the first r" +
    "eturn air node for this zone.")]
[JsonProperty(PropertyName="under_case_hvac_return_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UnderCaseHvacReturnAirNodeName { get; set; } = "";
    }
    
    public enum Refrigeration_Case_LatentCaseCreditCurveType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CaseTemperatureMethod")]
        CaseTemperatureMethod = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DewpointMethod")]
        DewpointMethod = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="RelativeHumidityMethod")]
        RelativeHumidityMethod = 3,
    }
    
    public enum Refrigeration_Case_AntiSweatHeaterControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Constant")]
        Constant = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DewpointMethod")]
        DewpointMethod = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatBalanceMethod")]
        HeatBalanceMethod = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Linear")]
        Linear = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 5,
    }
    
    public enum Refrigeration_Case_CaseDefrostType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectricWithTemperatureTermination")]
        ElectricWithTemperatureTermination = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HotFluid")]
        HotFluid = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="HotFluidWithTemperatureTermination")]
        HotFluidWithTemperatureTermination = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="HotGas")]
        HotGas = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="HotGasWithTemperatureTermination")]
        HotGasWithTemperatureTermination = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="OffCycle")]
        OffCycle = 8,
    }
    
    public enum Refrigeration_Case_DefrostEnergyCorrectionCurveType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CaseTemperatureMethod")]
        CaseTemperatureMethod = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DewpointMethod")]
        DewpointMethod = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="RelativeHumidityMethod")]
        RelativeHumidityMethod = 4,
    }
    
    [Description(@"Works in conjunction with the refrigeration case and walk-in objects to simulate the performance of a refrigerated case system. This object models the electric consumption of the rack compressors and the condenser fans. Heat can be rejected either outdoors or to a zone. Compressor rack waste heat can also be reclaimed for use by an optional air- or water-heating coil (Coil:Heating:Desuperheater and Coil:WaterHeating:Desuperheater).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Refrigeration_CompressorRack
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="heat_rejection_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_CompressorRack_HeatRejectionLocation HeatRejectionLocation { get; set; } = (Refrigeration_CompressorRack_HeatRejectionLocation)Enum.Parse(typeof(Refrigeration_CompressorRack_HeatRejectionLocation), "Outdoors");
        

[Description("It is important that this COP correspond to the lowest saturated suction temperat" +
    "ure needed to serve all refrigeration loads")]
[JsonProperty(PropertyName="design_compressor_rack_cop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignCompressorRackCop { get; set; } = Double.Parse("2", CultureInfo.InvariantCulture);
        

[Description("It is important that this COP curve correspond to the lowest saturated suction te" +
    "mperature needed to serve all refrigeration loads")]
[JsonProperty(PropertyName="compressor_rack_cop_function_of_temperature_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CompressorRackCopFunctionOfTemperatureCurveName { get; set; } = "";
        

[Description("Design power for condenser fan(s).")]
[JsonProperty(PropertyName="design_condenser_fan_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignCondenserFanPower { get; set; } = Double.Parse("250", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="condenser_fan_power_function_of_temperature_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CondenserFanPowerFunctionOfTemperatureCurveName { get; set; } = "";
        

[Description("Applicable only when Heat Rejection Location is Outdoors.")]
[JsonProperty(PropertyName="condenser_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_CompressorRack_CondenserType CondenserType { get; set; } = (Refrigeration_CompressorRack_CondenserType)Enum.Parse(typeof(Refrigeration_CompressorRack_CondenserType), "AirCooled");
        

[JsonProperty(PropertyName="water_cooled_condenser_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterCooledCondenserInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="water_cooled_condenser_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterCooledCondenserOutletNodeName { get; set; } = "";
        

[Description("Applicable only when Condenser Type is WaterCooled.")]
[JsonProperty(PropertyName="water_cooled_loop_flow_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_CompressorRack_WaterCooledLoopFlowType WaterCooledLoopFlowType { get; set; } = (Refrigeration_CompressorRack_WaterCooledLoopFlowType)Enum.Parse(typeof(Refrigeration_CompressorRack_WaterCooledLoopFlowType), "VariableFlow");
        

[Description("Applicable only when loop Flow type is VariableFlow.")]
[JsonProperty(PropertyName="water_cooled_condenser_outlet_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterCooledCondenserOutletTemperatureScheduleName { get; set; } = "";
        

[Description("Applicable only when loop flow type is ConstantFlow.")]
[JsonProperty(PropertyName="water_cooled_condenser_design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterCooledCondenserDesignFlowRate { get; set; } = null;
        

[JsonProperty(PropertyName="water_cooled_condenser_maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterCooledCondenserMaximumFlowRate { get; set; } = null;
        

[JsonProperty(PropertyName="water_cooled_condenser_maximum_water_outlet_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterCooledCondenserMaximumWaterOutletTemperature { get; set; } = Double.Parse("55", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="water_cooled_condenser_minimum_water_inlet_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterCooledCondenserMinimumWaterInletTemperature { get; set; } = Double.Parse("10", CultureInfo.InvariantCulture);
        

[Description(@"This field is only used for Condenser Type = EvaporativelyCooled. Schedule values greater than 0 indicate that evaporative cooling of the condenser is available. This schedule allows the user to define seasonal shutdown/draining of the water cooling system in cold climate applications. For periods with schedule values of 0, the condenser operates as AirCooled.")]
[JsonProperty(PropertyName="evaporative_condenser_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EvaporativeCondenserAvailabilityScheduleName { get; set; } = "";
        

[Description("Applicable only for Condenser Type = EvaporativlyCooled.")]
[JsonProperty(PropertyName="evaporative_condenser_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvaporativeCondenserEffectiveness { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[Description("Applicable only for Condenser Type = EvaporativelyCooled. Used to calculate evapo" +
    "rative condenser water use.")]
[JsonProperty(PropertyName="evaporative_condenser_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> EvaporativeCondenserAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"This field is only used for Condenser Type = EvaporativelyCooled and for periods when the evaporatively cooled condenser is available (field Evaporative Condenser Availability Schedule Name). For this situation, the heater heats the basin water when the outdoor air dry-bulb temperature falls below the setpoint temperature, but only when the condenser fans are off (i.e., no refrigerated case load).")]
[JsonProperty(PropertyName="basin_heater_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BasinHeaterCapacity { get; set; } = Double.Parse("200", CultureInfo.InvariantCulture);
        

[Description("Enter the outdoor dry-bulb temperature at which the basin heater turns on.")]
[JsonProperty(PropertyName="basin_heater_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BasinHeaterSetpointTemperature { get; set; } = Double.Parse("2", CultureInfo.InvariantCulture);
        

[Description("Design recirc water pump power for Condenser Type = EvaporativelyCooled. Applicab" +
    "le only for Condenser Type = EvaporativelyCooled.")]
[JsonProperty(PropertyName="design_evaporative_condenser_water_pump_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> DesignEvaporativeCondenserWaterPumpPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("If blank, water supply is from Mains. Applicable only for Condenser Type = Evapor" +
    "ativelyCooled.")]
[JsonProperty(PropertyName="evaporative_water_supply_tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EvaporativeWaterSupplyTankName { get; set; } = "";
        

[Description(@"Applicable only when Heat Rejection Location is Outdoors and Condenser Type is not WaterCooled; otherwise, leave field blank. If field is left blank with Heat Rejection Location = Outdoors, then the model assumes that the Inlet Air conditions are the outdoor air conditions for the current timestep (e.g., no adjustment for height above ground).")]
[JsonProperty(PropertyName="condenser_air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CondenserAirInletNodeName { get; set; } = "";
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
        

[Description("Enter the name of a Refrigeration:Case or Refrigeration:Walkin or Refrigeration:C" +
    "aseAndWalkinList object.")]
[JsonProperty(PropertyName="refrigeration_case_name_or_walkin_name_or_caseandwalkinlist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RefrigerationCaseNameOrWalkinNameOrCaseandwalkinlistName { get; set; } = "";
        

[Description("This must be a controlled zone and appear in a ZoneHVAC:EquipmentConnections obje" +
    "ct. Required only if walk-in[s] are connected to this rack AND the heat rejectio" +
    "n location is \"Zone\"")]
[JsonProperty(PropertyName="heat_rejection_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatRejectionZoneName { get; set; } = "";
    }
    
    public enum Refrigeration_CompressorRack_HeatRejectionLocation
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Outdoors")]
        Outdoors = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Zone")]
        Zone = 2,
    }
    
    public enum Refrigeration_CompressorRack_CondenserType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AirCooled")]
        AirCooled = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="EvaporativelyCooled")]
        EvaporativelyCooled = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="WaterCooled")]
        WaterCooled = 3,
    }
    
    public enum Refrigeration_CompressorRack_WaterCooledLoopFlowType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ConstantFlow")]
        ConstantFlow = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableFlow")]
        VariableFlow = 2,
    }
    
    [Description(@"Provides a list of all the refrigerated cases, walk in coolers, or air chillers cooled by a single refrigeration system. Note that the names of all cases, walk-ins ,air chillers, and CaseAndWalkInLists must be unique. That is, you cannot give a list the same name as one of list items. This list may contain a combination of case and walk-in names OR a list of air chiller names. Air chillers may not be included in any list that also includes cases or walk-ins.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Refrigeration_CaseAndWalkInList
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("This list is the RefrigerationCaseAndWalkInNames object-list")]
[JsonProperty(PropertyName="cases_and_walkins", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> CasesAndWalkins { get; set; } = null;
    }
    
    [Description("Air cooled condenser for a refrigeration system (Refrigeration:System).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Refrigeration_Condenser_AirCooled
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Rating as per ARI 460 Be sure the rating corresponds to the correct refrigerant H" +
    "eatRejection(W)=C1 +C2(Condensing Temp - Entering Air Temp, deg C) Will be adjus" +
    "ted for elevation automatically")]
[JsonProperty(PropertyName="rated_effective_total_heat_rejection_rate_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RatedEffectiveTotalHeatRejectionRateCurveName { get; set; } = "";
        

[Description("must correspond to rating given for total heat rejection effect")]
[JsonProperty(PropertyName="rated_subcooling_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedSubcoolingTemperatureDifference { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="condenser_fan_speed_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_Condenser_AirCooled_CondenserFanSpeedControlType CondenserFanSpeedControlType { get; set; } = (Refrigeration_Condenser_AirCooled_CondenserFanSpeedControlType)Enum.Parse(typeof(Refrigeration_Condenser_AirCooled_CondenserFanSpeedControlType), "Fixed");
        

[Description("Power for condenser fan(s) corresponding to rated total heat rejection effect.")]
[JsonProperty(PropertyName="rated_fan_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedFanPower { get; set; } = Double.Parse("250", CultureInfo.InvariantCulture);
        

[Description("Minimum air flow fraction through condenser fan")]
[JsonProperty(PropertyName="minimum_fan_air_flow_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumFanAirFlowRatio { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[Description(@"If field is left blank, then the model assumes that the inlet air conditions are the outdoor air conditions for the current timestep (e.g., no adjustment for height above ground). If the condenser rejects heat to a conditioned zone, enter the zone name here.")]
[JsonProperty(PropertyName="air_inlet_node_name_or_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeNameOrZoneName { get; set; } = "";
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
        

[Description("optional input")]
[JsonProperty(PropertyName="condenser_refrigerant_operating_charge_inventory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CondenserRefrigerantOperatingChargeInventory { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("optional input")]
[JsonProperty(PropertyName="condensate_receiver_refrigerant_inventory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CondensateReceiverRefrigerantInventory { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("optional input")]
[JsonProperty(PropertyName="condensate_piping_refrigerant_inventory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CondensatePipingRefrigerantInventory { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    public enum Refrigeration_Condenser_AirCooled_CondenserFanSpeedControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fixed")]
        Fixed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedLinear")]
        FixedLinear = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="TwoSpeed")]
        TwoSpeed = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableSpeed")]
        VariableSpeed = 4,
    }
    
    [Description("Evaporative-cooled condenser for a refrigeration system (Refrigeration:System).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Refrigeration_Condenser_EvaporativeCooled
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Rating as per ARI 490 Be sure the rating corresponds to the correct refrigerant")]
[JsonProperty(PropertyName="rated_effective_total_heat_rejection_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedEffectiveTotalHeatRejectionRate { get; set; } = null;
        

[Description("must correspond to rating given for total heat rejection effect")]
[JsonProperty(PropertyName="rated_subcooling_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedSubcoolingTemperatureDifference { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fan_speed_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_Condenser_EvaporativeCooled_FanSpeedControlType FanSpeedControlType { get; set; } = (Refrigeration_Condenser_EvaporativeCooled_FanSpeedControlType)Enum.Parse(typeof(Refrigeration_Condenser_EvaporativeCooled_FanSpeedControlType), "Fixed");
        

[Description("Power for condenser fan(s) corresponding to rated total heat rejection effect.")]
[JsonProperty(PropertyName="rated_fan_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedFanPower { get; set; } = null;
        

[Description("Minimum air flow fraction through condenser fan")]
[JsonProperty(PropertyName="minimum_fan_air_flow_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumFanAirFlowRatio { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[Description("A1 in delta T = A1 + A2(hrcf) + A3/(hrcf) + A4(Twb)")]
[JsonProperty(PropertyName="approach_temperature_constant_term", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ApproachTemperatureConstantTerm { get; set; } = Double.Parse("6.63", CultureInfo.InvariantCulture);
        

[Description("A2 in delta T = A1 + A2(hrcf) +A3/(hrcf) +A4(Twb)")]
[JsonProperty(PropertyName="approach_temperature_coefficient_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ApproachTemperatureCoefficient2 { get; set; } = Double.Parse("0.468", CultureInfo.InvariantCulture);
        

[Description("A3 in delta T = A1 + A2(hrcf) +A3/(hrcf) +A4(Twb)")]
[JsonProperty(PropertyName="approach_temperature_coefficient_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ApproachTemperatureCoefficient3 { get; set; } = Double.Parse("17.93", CultureInfo.InvariantCulture);
        

[Description("A4 in deltaT=A1 + A2(hrcf) +A3/(hrcf) +A4(Twb)")]
[JsonProperty(PropertyName="approach_temperature_coefficient_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ApproachTemperatureCoefficient4 { get; set; } = Double.Parse("-0.322", CultureInfo.InvariantCulture);
        

[Description("taken from manufacturer\'s Heat Rejection Capacity Factor Table")]
[JsonProperty(PropertyName="minimum_capacity_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCapacityFactor { get; set; } = Double.Parse("0.5", CultureInfo.InvariantCulture);
        

[Description("taken from manufacturer\'s Heat Rejection Capacity Factor Table")]
[JsonProperty(PropertyName="maximum_capacity_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCapacityFactor { get; set; } = Double.Parse("5", CultureInfo.InvariantCulture);
        

[Description("If field is left blank, then the model assumes that the inlet air conditions are " +
    "the outdoor air conditions for the current timestep (e.g., no adjustment for hei" +
    "ght above ground).")]
[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[Description("Used to calculate evaporative condenser water use and fan energy use.")]
[JsonProperty(PropertyName="rated_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> RatedAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"This field is only used for periods when the evap condenser is available (field Evaporative Condenser Availability Schedule). For this situation, the heater heats the basin water when the outdoor air dry-bulb temperature falls below the set point temperature, but only when the condenser fans are off (i.e., no refrigerated case load).")]
[JsonProperty(PropertyName="basin_heater_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BasinHeaterCapacity { get; set; } = Double.Parse("200", CultureInfo.InvariantCulture);
        

[Description("Enter the outdoor dry-bulb temperature at which the basin heater turns on.")]
[JsonProperty(PropertyName="basin_heater_setpoint_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BasinHeaterSetpointTemperature { get; set; } = Double.Parse("2", CultureInfo.InvariantCulture);
        

[Description("Design recirculating water pump power.")]
[JsonProperty(PropertyName="rated_water_pump_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> RatedWaterPumpPower { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("If blank, water supply is from Mains.")]
[JsonProperty(PropertyName="evaporative_water_supply_tank_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EvaporativeWaterSupplyTankName { get; set; } = "";
        

[Description(@"Schedule values greater than 0 indicate that evaporative cooling of the condenser is available. This schedule allows the user to define seasonal shutdown/draining of the water cooling system in cold climate applications. For periods with schedule values of 0, the condenser operates as Air Cooled.")]
[JsonProperty(PropertyName="evaporative_condenser_availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EvaporativeCondenserAvailabilityScheduleName { get; set; } = "";
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
        

[Description("optional input")]
[JsonProperty(PropertyName="condenser_refrigerant_operating_charge_inventory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CondenserRefrigerantOperatingChargeInventory { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("optional input")]
[JsonProperty(PropertyName="condensate_receiver_refrigerant_inventory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CondensateReceiverRefrigerantInventory { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("optional input")]
[JsonProperty(PropertyName="condensate_piping_refrigerant_inventory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CondensatePipingRefrigerantInventory { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    public enum Refrigeration_Condenser_EvaporativeCooled_FanSpeedControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fixed")]
        Fixed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedLinear")]
        FixedLinear = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="TwoSpeed")]
        TwoSpeed = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableSpeed")]
        VariableSpeed = 4,
    }
    
    [Description("Water cooled condenser for a refrigeration system (Refrigeration:System).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Refrigeration_Condenser_WaterCooled
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Rating as per ARI 450 Be sure the rating corresponds to the correct refrigerant n" +
    "ot used in calculations, only for identification and output")]
[JsonProperty(PropertyName="rated_effective_total_heat_rejection_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedEffectiveTotalHeatRejectionRate { get; set; } = null;
        

[Description("must correspond to rating given for total heat rejection effect")]
[JsonProperty(PropertyName="rated_condensing_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedCondensingTemperature { get; set; } = null;
        

[Description("must correspond to rating given for total heat rejection effect")]
[JsonProperty(PropertyName="rated_subcooling_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedSubcoolingTemperatureDifference { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("must correspond to rating given for total heat rejection effect")]
[JsonProperty(PropertyName="rated_water_inlet_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedWaterInletTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="water_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="water_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="water_cooled_loop_flow_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_Condenser_WaterCooled_WaterCooledLoopFlowType WaterCooledLoopFlowType { get; set; } = (Refrigeration_Condenser_WaterCooled_WaterCooledLoopFlowType)Enum.Parse(typeof(Refrigeration_Condenser_WaterCooled_WaterCooledLoopFlowType), "VariableFlow");
        

[Description("Applicable only when loop flow type is Variable Flow.")]
[JsonProperty(PropertyName="water_outlet_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterOutletTemperatureScheduleName { get; set; } = "";
        

[Description("note required units must be converted from L/s as specified in ARI 450-2007 Appli" +
    "cable only when loop flow type is Constant Flow.")]
[JsonProperty(PropertyName="water_design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterDesignFlowRate { get; set; } = null;
        

[JsonProperty(PropertyName="water_maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterMaximumFlowRate { get; set; } = null;
        

[JsonProperty(PropertyName="water_maximum_water_outlet_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterMaximumWaterOutletTemperature { get; set; } = Double.Parse("55", CultureInfo.InvariantCulture);
        

[Description("related to the minimum allowed refrigeration system condensing temperature")]
[JsonProperty(PropertyName="water_minimum_water_inlet_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterMinimumWaterInletTemperature { get; set; } = Double.Parse("10", CultureInfo.InvariantCulture);
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
        

[Description("optional input")]
[JsonProperty(PropertyName="condenser_refrigerant_operating_charge_inventory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CondenserRefrigerantOperatingChargeInventory { get; set; } = null;
        

[Description("optional input")]
[JsonProperty(PropertyName="condensate_receiver_refrigerant_inventory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CondensateReceiverRefrigerantInventory { get; set; } = null;
        

[Description("optional input")]
[JsonProperty(PropertyName="condensate_piping_refrigerant_inventory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CondensatePipingRefrigerantInventory { get; set; } = null;
    }
    
    public enum Refrigeration_Condenser_WaterCooled_WaterCooledLoopFlowType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ConstantFlow")]
        ConstantFlow = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableFlow")]
        VariableFlow = 2,
    }
    
    [Description(@"Cascade condenser for a refrigeration system (Refrigeration:System). The cascade condenser is unlike the other condenser options because it rejects heat to another, higher-temperature, refrigeration system. That is, the cascade condenser acts as a heat rejection object for one system, but acts as a refrigeration load for another system.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Refrigeration_Condenser_Cascade
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("This is the condensing temperature for the lower temperature secondary loop")]
[JsonProperty(PropertyName="rated_condensing_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedCondensingTemperature { get; set; } = null;
        

[Description("This is the difference between the condensing and evaporating temperatures")]
[JsonProperty(PropertyName="rated_approach_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedApproachTemperatureDifference { get; set; } = Double.Parse("3", CultureInfo.InvariantCulture);
        

[Description("used for identification and rough system size error checking")]
[JsonProperty(PropertyName="rated_effective_total_heat_rejection_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedEffectiveTotalHeatRejectionRate { get; set; } = null;
        

[Description("Fixed keeps condensing temperature constant Float sets the condensing temperature" +
    " according to the other loads on the higher temperature system")]
[JsonProperty(PropertyName="condensing_temperature_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_Condenser_Cascade_CondensingTemperatureControlType CondensingTemperatureControlType { get; set; } = (Refrigeration_Condenser_Cascade_CondensingTemperatureControlType)Enum.Parse(typeof(Refrigeration_Condenser_Cascade_CondensingTemperatureControlType), "Fixed");
        

[Description("optional input")]
[JsonProperty(PropertyName="condenser_refrigerant_operating_charge_inventory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CondenserRefrigerantOperatingChargeInventory { get; set; } = null;
        

[Description("optional input")]
[JsonProperty(PropertyName="condensate_receiver_refrigerant_inventory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CondensateReceiverRefrigerantInventory { get; set; } = null;
        

[Description("optional input")]
[JsonProperty(PropertyName="condensate_piping_refrigerant_inventory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CondensatePipingRefrigerantInventory { get; set; } = null;
    }
    
    public enum Refrigeration_Condenser_Cascade_CondensingTemperatureControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fixed")]
        Fixed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Float")]
        Float = 2,
    }
    
    [Description("The transcritical refrigeration system requires a single gas cooler to reject the" +
        " system heat.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Refrigeration_GasCooler_AirCooled
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Be sure the rating corresponds to the correct refrigerant (R744) HeatRejection(W)" +
    "=C1 +C2(Gas Cooler Outlet Temp - Entering Air Temp, deg C) Will be adjusted for " +
    "elevation automatically")]
[JsonProperty(PropertyName="rated_total_heat_rejection_rate_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RatedTotalHeatRejectionRateCurveName { get; set; } = "";
        

[JsonProperty(PropertyName="gas_cooler_fan_speed_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_GasCooler_AirCooled_GasCoolerFanSpeedControlType GasCoolerFanSpeedControlType { get; set; } = (Refrigeration_GasCooler_AirCooled_GasCoolerFanSpeedControlType)Enum.Parse(typeof(Refrigeration_GasCooler_AirCooled_GasCoolerFanSpeedControlType), "Fixed");
        

[Description("Power for gas cooler fan(s) corresponding to rated total heat rejection effect.")]
[JsonProperty(PropertyName="rated_fan_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedFanPower { get; set; } = Double.Parse("5000", CultureInfo.InvariantCulture);
        

[Description("Minimum air flow fraction through gas cooler fan")]
[JsonProperty(PropertyName="minimum_fan_air_flow_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumFanAirFlowRatio { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[Description("Temperature at which system transitions between subcritical and transcritical ope" +
    "ration.")]
[JsonProperty(PropertyName="transition_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TransitionTemperature { get; set; } = Double.Parse("27", CultureInfo.InvariantCulture);
        

[Description("Temperature difference between the CO2 exiting the gas cooler and the air enterin" +
    "g the gas cooler during transcritical operation.")]
[JsonProperty(PropertyName="transcritical_approach_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TranscriticalApproachTemperature { get; set; } = Double.Parse("3", CultureInfo.InvariantCulture);
        

[Description("Temperature difference between the saturated condensing temperature and the air t" +
    "emperature during subcritical operation.")]
[JsonProperty(PropertyName="subcritical_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SubcriticalTemperatureDifference { get; set; } = Double.Parse("10", CultureInfo.InvariantCulture);
        

[Description("Minimum saturated condensing temperature during subcritical operation.")]
[JsonProperty(PropertyName="minimum_condensing_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCondensingTemperature { get; set; } = Double.Parse("10", CultureInfo.InvariantCulture);
        

[Description("If field is left blank, then the model assumes that the inlet air conditions are " +
    "the outdoor air conditions for the current timestep (e.g., no adjustment for hei" +
    "ght above ground).")]
[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
        

[Description("optional input")]
[JsonProperty(PropertyName="gas_cooler_refrigerant_operating_charge_inventory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasCoolerRefrigerantOperatingChargeInventory { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("optional input")]
[JsonProperty(PropertyName="gas_cooler_receiver_refrigerant_inventory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasCoolerReceiverRefrigerantInventory { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("optional input")]
[JsonProperty(PropertyName="gas_cooler_outlet_piping_refrigerant_inventory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GasCoolerOutletPipingRefrigerantInventory { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    public enum Refrigeration_GasCooler_AirCooled_GasCoolerFanSpeedControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fixed")]
        Fixed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedLinear")]
        FixedLinear = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="TwoSpeed")]
        TwoSpeed = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableSpeed")]
        VariableSpeed = 4,
    }
    
    [Description(@"A refrigeration system may provide cooling to other, secondary, systems through either a secondary loop or a cascade condenser. If multiple transfer loads are served by a single primary system, use this list to group them together for reference by the primary system (see the field ""Refrigeration Transfer Load or TransferLoad List Name"" in the Refrigeration:System object).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Refrigeration_TransferLoadList
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("This list is the RefrigerationCascadeCondenserAndSecondarySystemNames object-list" +
    "")]
[JsonProperty(PropertyName="transfer_loads", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> TransferLoads { get; set; } = null;
    }
    
    [Description(@"Two types of subcoolers are modeled by the detailed refrigeration system. The liquid suction heat exchanger uses cool suction gas to subcool the hot condensate after it leaves the condenser and before it reaches the thermal expansion valve. A mechanical subcooler is used to transfer cooling capacity from one refrigeration system to another.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Refrigeration_Subcooler
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("plan to add ambient subcoolers at future time")]
[JsonProperty(PropertyName="subcooler_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_Subcooler_SubcoolerType SubcoolerType { get; set; } = (Refrigeration_Subcooler_SubcoolerType)Enum.Parse(typeof(Refrigeration_Subcooler_SubcoolerType), "LiquidSuction");
        

[Description("Applicable only and required for liquid suction heat exchangers design liquid suc" +
    "tion subcooling")]
[JsonProperty(PropertyName="liquid_suction_design_subcooling_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidSuctionDesignSubcoolingTemperatureDifference { get; set; } = null;
        

[Description("design inlet temperature on liquid side Applicable only and required for liquid s" +
    "uction heat exchangers (LSHX)")]
[JsonProperty(PropertyName="design_liquid_inlet_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignLiquidInletTemperature { get; set; } = null;
        

[Description("design inlet temperature on vapor side Applicable only and required for liquid su" +
    "ction heat exchangers (LSHX) Design vapor inlet temperature must be less than or" +
    " equal to the Liquid inlet design temp")]
[JsonProperty(PropertyName="design_vapor_inlet_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignVaporInletTemperature { get; set; } = null;
        

[Description("Name of the Detailed Refrigeration System providing cooling capacity Applicable o" +
    "nly and required for mechanical subcoolers")]
[JsonProperty(PropertyName="capacity_providing_system", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CapacityProvidingSystem { get; set; } = "";
        

[Description("Control Temperature Out for subcooled liquid Applicable only and required for mec" +
    "hanical subcoolers")]
[JsonProperty(PropertyName="outlet_control_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OutletControlTemperature { get; set; } = null;
    }
    
    public enum Refrigeration_Subcooler_SubcoolerType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="LiquidSuction")]
        LiquidSuction = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Mechanical")]
        Mechanical = 2,
    }
    
    [Description("Refrigeration system compressor. Data is available for many compressors in the Re" +
        "frigerationCompressor.idf dataset")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Refrigeration_Compressor
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description(@"the input order for the Curve:Bicubic does not match the ARI 540-2004 Eq. 1 coefficient order N1 is ARI_C1, N2 is ARI_C2, N3 is ARI_C4, N4 is ARI_C3, N5 is ARI_C6, N6 is ARI_C5, N7 is ARI_C7, N8 is ARI_C10, N9 is ARI_C8, N10 is ARI_C9, N11 is Minimum Suction dewpoint temperature, N12 is Maximum Suction dewpoint temperature, N13 is Minimum Discharge dewpoint temperature, N14 is Maximum Discharge dewpoint temperature")]
[JsonProperty(PropertyName="refrigeration_compressor_power_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RefrigerationCompressorPowerCurveName { get; set; } = "";
        

[Description(@"the input order for the Curve:Bicubic does not match the ARI 540-2004 Eq. 1 coefficient order N1 is ARI_C1, N2 is ARI_C2, N3 is ARI_C4, N4 is ARI_C3, N5 is ARI_C6, N6 is ARI_C5, N7 is ARI_C7, N8 is ARI_C10, N9 is ARI_C8, N10 is ARI_C9, N11 is Minimum Suction dewpoint temperature, N12 is Maximum Suction dewpoint temperature, N13 is Minimum Discharge dewpoint temperature, N14 is Maximum Discharge dewpoint temperature")]
[JsonProperty(PropertyName="refrigeration_compressor_capacity_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RefrigerationCompressorCapacityCurveName { get; set; } = "";
        

[Description("Use this input field OR the next, not both This is used if the compressor rating " +
    "is based upon degrees of superheat")]
[JsonProperty(PropertyName="rated_superheat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedSuperheat { get; set; } = null;
        

[Description("Use this input field OR the previous, not both This is used if the compressor rat" +
    "ing is based upon rated return gas temperature (Rated Suction Temperature)")]
[JsonProperty(PropertyName="rated_return_gas_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedReturnGasTemperature { get; set; } = null;
        

[Description("Use this input field OR the next, not both This is used if the compressor rating " +
    "is based upon rated liquid temperature at the expansion valve")]
[JsonProperty(PropertyName="rated_liquid_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedLiquidTemperature { get; set; } = null;
        

[Description("Use this input field OR the previous, not both This is used if the compressor rat" +
    "ing is based upon degrees of subcooling")]
[JsonProperty(PropertyName="rated_subcooling", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedSubcooling { get; set; } = null;
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
        

[JsonProperty(PropertyName="mode_of_operation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_Compressor_ModeOfOperation ModeOfOperation { get; set; } = (Refrigeration_Compressor_ModeOfOperation)Enum.Parse(typeof(Refrigeration_Compressor_ModeOfOperation), "Subcritical");
        

[JsonProperty(PropertyName="transcritical_compressor_power_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TranscriticalCompressorPowerCurveName { get; set; } = "";
        

[JsonProperty(PropertyName="transcritical_compressor_capacity_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TranscriticalCompressorCapacityCurveName { get; set; } = "";
    }
    
    public enum Refrigeration_Compressor_ModeOfOperation
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Subcritical")]
        Subcritical = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Transcritical")]
        Transcritical = 2,
    }
    
    [Description(@"List of all the compressors included within a single refrigeration system (Refrigeration:System). Each list must contain at least one compressor. The order in which the individual compressors are listed here will be the order in which the compressors are dispatched to meet the system load. IMPORTANT: List compressor names in the order in which the compressors will be loaded Data is available for many compressors in the RefrigerationCompressor.idf dataset")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Refrigeration_CompressorList
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("This list is the RefrigerationCompressorNames object-list")]
[JsonProperty(PropertyName="compressors", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Compressors { get; set; } = null;
    }
    
    [Description("Simulates the performance of a supermarket refrigeration system when used along w" +
        "ith other objects to define the refrigeration load(s), the compressor(s), and th" +
        "e condenser.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Refrigeration_System
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description(@"Enter the name of a Refrigeration:Case or Refrigeration:WalkIn object. If there is more than one refrigerated case or walk-in served by this system, enter the name of a Refrigeration:CaseAndWalkInList object. Only cases and walkins served directly by the system should be included in this list. Any cases served indirectly via a secondary chiller should NOT be included in this list")]
[JsonProperty(PropertyName="refrigerated_case_or_walkin_or_caseandwalkinlist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RefrigeratedCaseOrWalkinOrCaseandwalkinlistName { get; set; } = "";
        

[Description(@"Enter the name of a Refrigeration:SecondarySystem object OR a Refrigeration:Condenser:Cascade object OR, a Refrigeration:TransferLoadList object. A transfer load is identified as one which moves the load from one system to another. So if you have more than one such load (including cascade condensers and secondary loops) served by the same system, use a TransferLoadList object.")]
[JsonProperty(PropertyName="refrigeration_transfer_load_or_transferload_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RefrigerationTransferLoadOrTransferloadListName { get; set; } = "";
        

[JsonProperty(PropertyName="refrigeration_condenser_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RefrigerationCondenserName { get; set; } = "";
        

[JsonProperty(PropertyName="compressor_or_compressorlist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CompressorOrCompressorlistName { get; set; } = "";
        

[Description("related to the proper operation of the thermal expansion valves and compressors")]
[JsonProperty(PropertyName="minimum_condensing_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCondensingTemperature { get; set; } = null;
        

[Description(@"Fluid property data for the refrigerant must be entered. The fluid property data, including the objects: FluidProperties:Name, FluidProperties:Temperatures, FluidProperties:Saturated and FluidProperties:Superheated can be copied from the FluidPropertiesRefData.idf dataset")]
[JsonProperty(PropertyName="refrigeration_system_working_fluid_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RefrigerationSystemWorkingFluidType { get; set; } = "";
        

[JsonProperty(PropertyName="suction_temperature_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_System_SuctionTemperatureControlType SuctionTemperatureControlType { get; set; } = (Refrigeration_System_SuctionTemperatureControlType)Enum.Parse(typeof(Refrigeration_System_SuctionTemperatureControlType), "ConstantSuctionTemperature");
        

[Description("Optional Field Recipient of refrigeration capacity, that is receives cool liquid " +
    "from another refrigeration system to help meet aggregate case loads")]
[JsonProperty(PropertyName="mechanical_subcooler_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MechanicalSubcoolerName { get; set; } = "";
        

[Description("Optional Field Liquid Suction Heat Exchanger Name, or leave blank")]
[JsonProperty(PropertyName="liquid_suction_heat_exchanger_subcooler_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string LiquidSuctionHeatExchangerSubcoolerName { get; set; } = "";
        

[Description("Use only if you want to include suction piping heat gain in refrigeration load")]
[JsonProperty(PropertyName="sum_ua_suction_piping", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SumUaSuctionPiping { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This will be used to determine the temperature used for distribution piping heat " +
    "gain and the pipe heat gains  as cooling credit for the zone. Required only if S" +
    "um UA Distribution Piping >0.0")]
[JsonProperty(PropertyName="suction_piping_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SuctionPipingZoneName { get; set; } = "";
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
        

[JsonProperty(PropertyName="number_of_compressor_stages", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfCompressorStages { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="intercooler_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_System_IntercoolerType IntercoolerType { get; set; } = (Refrigeration_System_IntercoolerType)Enum.Parse(typeof(Refrigeration_System_IntercoolerType), "None");
        

[JsonProperty(PropertyName="shell_and_coil_intercooler_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ShellAndCoilIntercoolerEffectiveness { get; set; } = Double.Parse("0.8", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="high_stage_compressor_or_compressorlist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HighStageCompressorOrCompressorlistName { get; set; } = "";
    }
    
    public enum Refrigeration_System_SuctionTemperatureControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ConstantSuctionTemperature")]
        ConstantSuctionTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FloatSuctionTemperature")]
        FloatSuctionTemperature = 2,
    }
    
    public enum Refrigeration_System_IntercoolerType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Flash Intercooler")]
        FlashIntercooler = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Shell-and-Coil Intercooler")]
        ShellandCoilIntercooler = 3,
    }
    
    [Description("Detailed transcritical carbon dioxide (CO2) booster refrigeration systems used in" +
        " supermarkets. The object allows for modeling either a single stage system with " +
        "medium-temperature loads or a two stage system with both medium- and low-tempera" +
        "ture loads.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Refrigeration_TranscriticalSystem
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="system_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_TranscriticalSystem_SystemType SystemType { get; set; } = (Refrigeration_TranscriticalSystem_SystemType)Enum.Parse(typeof(Refrigeration_TranscriticalSystem_SystemType), "SingleStage");
        

[Description(@"Enter the name of a Refrigeration:Case or Refrigeration:WalkIn object. If there is more than one refrigerated case or walk-in served by this system, enter the name of a Refrigeration:CaseAndWalkInList object. Only medium temperature cases and walk-ins served directly by the system should be included in this list.")]
[JsonProperty(PropertyName="medium_temperature_refrigerated_case_or_walkin_or_caseandwalkinlist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MediumTemperatureRefrigeratedCaseOrWalkinOrCaseandwalkinlistName { get; set; } = "";
        

[Description(@"Enter the name of a Refrigeration:Case or Refrigeration:WalkIn object. If there is more than one refrigerated case or walk-in served by this system, enter the name of a Refrigeration:CaseAndWalkInList object. Only low temperature cases and walkins served directly by the system should be included in this list.")]
[JsonProperty(PropertyName="low_temperature_refrigerated_case_or_walkin_or_caseandwalkinlist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string LowTemperatureRefrigeratedCaseOrWalkinOrCaseandwalkinlistName { get; set; } = "";
        

[JsonProperty(PropertyName="refrigeration_gas_cooler_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RefrigerationGasCoolerName { get; set; } = "";
        

[JsonProperty(PropertyName="high_pressure_compressor_or_compressorlist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HighPressureCompressorOrCompressorlistName { get; set; } = "";
        

[JsonProperty(PropertyName="low_pressure_compressor_or_compressorlist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string LowPressureCompressorOrCompressorlistName { get; set; } = "";
        

[JsonProperty(PropertyName="receiver_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReceiverPressure { get; set; } = Double.Parse("4000000", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="subcooler_effectiveness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SubcoolerEffectiveness { get; set; } = Double.Parse("0.4", CultureInfo.InvariantCulture);
        

[Description(@"Fluid property data for the refrigerant must be entered. The fluid property data, including the objects: FluidProperties:Name, FluidProperties:Temperatures, FluidProperties:Saturated and FluidProperties:Superheated can be copied from the FluidPropertiesRefData.idf dataset")]
[JsonProperty(PropertyName="refrigeration_system_working_fluid_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RefrigerationSystemWorkingFluidType { get; set; } = "";
        

[Description("Use only if you want to include suction piping heat gain in refrigeration load")]
[JsonProperty(PropertyName="sum_ua_suction_piping_for_medium_temperature_loads", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SumUaSuctionPipingForMediumTemperatureLoads { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This will be used to determine the temperature used for distribution piping heat " +
    "gain and the pipe heat gains as cooling credit for the zone. Required only if Su" +
    "m UA Distribution Piping for Medium Temperature Loads > 0.0")]
[JsonProperty(PropertyName="medium_temperature_suction_piping_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MediumTemperatureSuctionPipingZoneName { get; set; } = "";
        

[Description("Use only if you want to include suction piping heat gain in refrigeration load")]
[JsonProperty(PropertyName="sum_ua_suction_piping_for_low_temperature_loads", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SumUaSuctionPipingForLowTemperatureLoads { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This will be used to determine the temperature used for distribution piping heat " +
    "gain and the pipe heat gains as cooling credit for the zone. Required only if Su" +
    "m UA Distribution Piping for Low Temperature Loads > 0.0")]
[JsonProperty(PropertyName="low_temperature_suction_piping_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string LowTemperatureSuctionPipingZoneName { get; set; } = "";
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    public enum Refrigeration_TranscriticalSystem_SystemType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="SingleStage")]
        SingleStage = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="TwoStage")]
        TwoStage = 1,
    }
    
    [Description(@"Works in conjunction with refrigerated cases and walkins to simulate the performance of a secondary loop supermarket refrigeration system. Heat from the refrigeration loads served by the secondary loop is absorbed by a primary refrigeration system (Refrigeration:System). The SecondarySystem object simulates a heat exchanger that is an evaporator, or refrigeration load, on the primary refrigeration system.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Refrigeration_SecondarySystem
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Enter the name of a Refrigeration:Case or Refrigeration:WalkIn object. If there i" +
    "s more than one refrigerated case or walk-in served by this secondary system, en" +
    "ter the name of a Refrigeration:CaseAndWalkInList object.")]
[JsonProperty(PropertyName="refrigerated_case_or_walkin_or_caseandwalkinlist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RefrigeratedCaseOrWalkinOrCaseandwalkinlistName { get; set; } = "";
        

[Description(@"If ""FluidAlwaysLiquid"" is selected, the fluid properties must be input using the objects: FluidProperties:Name, FluidProperties:GlycolConcentration, and, if user defined fluid type, FluidProperties:Temperatures and FluidProperties:Concentration. Many sets of fluid properties can be found in GlycolPropertiesRefData.idf. If ""FluidPhaseChange"" is selected, the refrigerant properties must be input using the objects: (if user defined fluid type): FluidProperties:Name, FluidProperties:Temperatures, FluidProperties:Saturated, and FluidProperties:Superheated. Many sets of refrigerant data can be found in FluidPropertiesRefData.idf.")]
[JsonProperty(PropertyName="circulating_fluid_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_SecondarySystem_CirculatingFluidType CirculatingFluidType { get; set; } = (Refrigeration_SecondarySystem_CirculatingFluidType)Enum.Parse(typeof(Refrigeration_SecondarySystem_CirculatingFluidType), "FluidAlwaysLiquid");
        

[Description("This must correspond to a name in the FluidProperties:Name object.")]
[JsonProperty(PropertyName="circulating_fluid_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CirculatingFluidName { get; set; } = "";
        

[Description(@"For ""FluidAlwaysLiquid"", at least one of the two, Evaporator Capacity OR Evaporator Flow Rate for Secondary Fluid, is required. For ""FluidPhaseChange"", the default capacity is the sum of the rated capacities of the Cases and Walk-ins served by the secondary loop.")]
[JsonProperty(PropertyName="evaporator_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvaporatorCapacity { get; set; } = null;
        

[Description("For \"FluidAlwaysLiquid\", at least one of the two, Evaporator Capacity OR Evaporat" +
    "or Flow Rate for Secondary Fluid, is required. For \"FluidPhaseChange\" loops, thi" +
    "s input is not used. (see PhaseChange Circulating Rate)")]
[JsonProperty(PropertyName="evaporator_flow_rate_for_secondary_fluid", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvaporatorFlowRateForSecondaryFluid { get; set; } = null;
        

[Description("This is the evaporating temperature in the heat exchanger used to chill or conden" +
    "se the secondary loop circulating fluid. It is NOT the temperature in any cases " +
    "or walk-ins served by the secondary loop.")]
[JsonProperty(PropertyName="evaporator_evaporating_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvaporatorEvaporatingTemperature { get; set; } = null;
        

[Description(@"For ""FluidAlwaysLiquid"", this is the rated difference between the temperature of the circulating fluid leaving the heat exchanger and the heat exchanger's rated evaporating temperature. For ""FluidPhaseChange"", this is the difference between the temperature of the evaporating and condensing temperatures in the heat exchanger.")]
[JsonProperty(PropertyName="evaporator_approach_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvaporatorApproachTemperatureDifference { get; set; } = null;
        

[Description(@"For ""FluidAlwaysLiquid"", this is the rated difference between the temperature of the circulating fluid entering the heat exchanger and the temperature of the circulating fluid leaving the heat exchanger, and is Required. For ""FluidPhaseChange"", this input is not used.")]
[JsonProperty(PropertyName="evaporator_range_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvaporatorRangeTemperatureDifference { get; set; } = null;
        

[JsonProperty(PropertyName="number_of_pumps_in_loop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfPumpsInLoop { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("For \"FluidAlwaysLiquid\",if not input, Evaporator Flow Rate for Secondary Fluid wi" +
    "ll be used. For \"FluidPhaseChange\", if not input, this will be calculated using " +
    "the PhaseChange Circulating Rate.")]
[JsonProperty(PropertyName="total_pump_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TotalPumpFlowRate { get; set; } = null;
        

[Description("Either the Total Pump Power or the Total Pump Head is required.")]
[JsonProperty(PropertyName="total_pump_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TotalPumpPower { get; set; } = null;
        

[Description("Either the Total Pump Power or the Total Pump Head is required.")]
[JsonProperty(PropertyName="total_pump_head", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TotalPumpHead { get; set; } = null;
        

[Description("This is the total mass flow at the pump divided by the gaseous mass flow leaving " +
    "the refrigeration load.")]
[JsonProperty(PropertyName="phasechange_circulating_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PhasechangeCirculatingRate { get; set; } = Double.Parse("2.5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="pump_drive_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_SecondarySystem_PumpDriveType PumpDriveType { get; set; } = (Refrigeration_SecondarySystem_PumpDriveType)Enum.Parse(typeof(Refrigeration_SecondarySystem_PumpDriveType), "Constant");
        

[Description("Variable Speed Pump Curve Name is applicable to variable speed pumps only.")]
[JsonProperty(PropertyName="variable_speed_pump_cubic_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string VariableSpeedPumpCubicCurveName { get; set; } = "";
        

[Description("This is the portion of the pump motor heat added to secondary circulating fluid a" +
    "nd is equal to the motor efficiency for non-hermetic motor. Enter 1.0 for a semi" +
    "-hermetic motor.")]
[JsonProperty(PropertyName="pump_motor_heat_to_fluid", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PumpMotorHeatToFluid { get; set; } = Double.Parse("0.85", CultureInfo.InvariantCulture);
        

[Description("Use only if you want to include distribution piping heat gain in refrigeration lo" +
    "ad.")]
[JsonProperty(PropertyName="sum_ua_distribution_piping", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SumUaDistributionPiping { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This will be used to determine the temperature used for distribution piping heat " +
    "gain. The pipe heat gains are also counted as cooling credit for the zone. Requi" +
    "red only if Sum UA Distribution Piping >0.0")]
[JsonProperty(PropertyName="distribution_piping_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DistributionPipingZoneName { get; set; } = "";
        

[Description("Use only if you want to include Receiver/Separator Shell heat gain in refrigerati" +
    "on load.")]
[JsonProperty(PropertyName="sum_ua_receiver_separator_shell", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SumUaReceiverSeparatorShell { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This will be used to determine the temperature used for Receiver/Separator Shell " +
    "heat gain. The shell heat gains are also counted as cooling credit for the zone." +
    " Required only if Sum UA Receiver/Separator Shell >0.0")]
[JsonProperty(PropertyName="receiver_separator_zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReceiverSeparatorZoneName { get; set; } = "";
        

[Description("This value refers to the refrigerant circulating within the primary system provid" +
    "ing cooling to the chiller for the secondary loop, not to the fluid circulating " +
    "within the secondary loop itself.")]
[JsonProperty(PropertyName="evaporator_refrigerant_inventory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EvaporatorRefrigerantInventory { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Any text may be used here to categorize the end-uses in the ABUPS End Uses by Sub" +
    "category table.")]
[JsonProperty(PropertyName="end_use_subcategory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string EndUseSubcategory { get; set; } = "General";
    }
    
    public enum Refrigeration_SecondarySystem_CirculatingFluidType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="FluidAlwaysLiquid")]
        FluidAlwaysLiquid = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FluidPhaseChange")]
        FluidPhaseChange = 1,
    }
    
    public enum Refrigeration_SecondarySystem_PumpDriveType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Constant")]
        Constant = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Variable")]
        Variable = 2,
    }
    
    [Description(@"Works in conjunction with a compressor rack, a refrigeration system, or a refrigeration secondary system to simulate the performance of a walk-in cooler. The walk-in cooler model uses information at rated conditions along with input descriptions for heat transfer surfaces facing multiple zones to determine performance.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Refrigeration_WalkIn
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="rated_coil_cooling_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedCoilCoolingCapacity { get; set; } = null;
        

[JsonProperty(PropertyName="operating_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OperatingTemperature { get; set; } = null;
        

[Description("If DXEvaporator, use evaporating temperature (saturated suction temperature) If B" +
    "rineCoil, use Brine entering temperature used to set minimum suction pressure fo" +
    "r DX systems and minimum brine temp for secondary systems")]
[JsonProperty(PropertyName="rated_cooling_source_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedCoolingSourceTemperature { get; set; } = null;
        

[Description("Include total for all anti-sweat, door, drip-pan, and floor heater power Do not i" +
    "nclude defrost heater power")]
[JsonProperty(PropertyName="rated_total_heating_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedTotalHeatingPower { get; set; } = null;
        

[Description("Values will be used to multiply the total heating power Values in the schedule sh" +
    "ould be between 0.0 and 1.0 For example, this could be used if display door anti" +
    "sweat heaters are turned off at night Defaults to always on if schedule name lef" +
    "t blank.")]
[JsonProperty(PropertyName="heating_power_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingPowerScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="rated_cooling_coil_fan_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedCoolingCoilFanPower { get; set; } = Double.Parse("375", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="rated_circulation_fan_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedCirculationFanPower { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Enter the total (display + task) installed lighting power.")]
[JsonProperty(PropertyName="rated_total_lighting_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedTotalLightingPower { get; set; } = null;
        

[Description("The schedule should contain values between 0 and 1 Defaults to always on if sched" +
    "ule name left blank.")]
[JsonProperty(PropertyName="lighting_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string LightingScheduleName { get; set; } = "";
        

[Description("HotFluid includes either hot gas defrost for a DX system or Hot Brine defrost if " +
    "this walk in is cooled by brine from a secondary chiller")]
[JsonProperty(PropertyName="defrost_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_WalkIn_DefrostType DefrostType { get; set; } = (Refrigeration_WalkIn_DefrostType)Enum.Parse(typeof(Refrigeration_WalkIn_DefrostType), "Electric");
        

[JsonProperty(PropertyName="defrost_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_WalkIn_DefrostControlType DefrostControlType { get; set; } = (Refrigeration_WalkIn_DefrostControlType)Enum.Parse(typeof(Refrigeration_WalkIn_DefrostControlType), "TimeSchedule");
        

[Description("The schedule values should be 0 (off) or 1 (on)")]
[JsonProperty(PropertyName="defrost_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DefrostScheduleName { get; set; } = "";
        

[Description(@"The schedule values should be 0 (off) or 1 (on) The start time for each defrost period in this drip-down schedule should coincide with the start time for each defrost period in the defrost schedule (previous input field). The length of each defrost drip-down period must be greater than or equal to the corresponding defrost period specified in the defrost schedule. This extra time allows the melted frost to drip from the coil before refrigeration is restarted.")]
[JsonProperty(PropertyName="defrost_drip_down_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DefrostDripDownScheduleName { get; set; } = "";
        

[Description("needed for all defrost types except none and offcycle")]
[JsonProperty(PropertyName="defrost_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DefrostPower { get; set; } = null;
        

[Description("This is the portion of the defrost energy that is available to melt frost Needed " +
    "only for defrost control type TemperatureTermination defaults to 0.7 for electri" +
    "c defrost and to 0.3 for hot fluid defrost")]
[JsonProperty(PropertyName="temperature_termination_defrost_fraction_to_ice", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureTerminationDefrostFractionToIce { get; set; } = null;
        

[Description("Schedule values should be in units of Watts Leave this field blank if no restocki" +
    "ng is to be modeled")]
[JsonProperty(PropertyName="restocking_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RestockingScheduleName { get; set; } = "";
        

[Description("This value is only used if the Cooling Source Type is DXEvaporator")]
[JsonProperty(PropertyName="average_refrigerant_charge_inventory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AverageRefrigerantChargeInventory { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("floor area of walk-in cooler")]
[JsonProperty(PropertyName="insulated_floor_surface_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InsulatedFloorSurfaceArea { get; set; } = null;
        

[Description("The default value corresponds to R18 [ft2-F-hr/Btu] To convert other IP R-values " +
    "to U, divide 5.678 by the R-value Some examples: R15 is U 0.3785 W/m2-K R5 is U " +
    "1.136 W/m2-K")]
[JsonProperty(PropertyName="insulated_floor_u_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InsulatedFloorUValue { get; set; } = Double.Parse("0.3154", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="zone_data", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_WalkIn_ZoneData_Item> ZoneData { get; set; } = null;
    }
    
    public enum Refrigeration_WalkIn_DefrostType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HotFluid")]
        HotFluid = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="OffCycle")]
        OffCycle = 4,
    }
    
    public enum Refrigeration_WalkIn_DefrostControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureTermination")]
        TemperatureTermination = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TimeSchedule")]
        TimeSchedule = 2,
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Refrigeration_WalkIn_ZoneData_Item
    {
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="total_insulated_surface_area_facing_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TotalInsulatedSurfaceAreaFacingZone { get; set; } = null;
        

[JsonProperty(PropertyName="insulated_surface_u_value_facing_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InsulatedSurfaceUValueFacingZone { get; set; } = null;
        

[JsonProperty(PropertyName="area_of_glass_reach_in_doors_facing_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AreaOfGlassReachInDoorsFacingZone { get; set; } = null;
        

[JsonProperty(PropertyName="height_of_glass_reach_in_doors_facing_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeightOfGlassReachInDoorsFacingZone { get; set; } = null;
        

[JsonProperty(PropertyName="glass_reach_in_door_u_value_facing_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GlassReachInDoorUValueFacingZone { get; set; } = null;
        

[JsonProperty(PropertyName="glass_reach_in_door_opening_schedule_name_facing_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string GlassReachInDoorOpeningScheduleNameFacingZone { get; set; } = "";
        

[JsonProperty(PropertyName="area_of_stocking_doors_facing_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AreaOfStockingDoorsFacingZone { get; set; } = null;
        

[JsonProperty(PropertyName="height_of_stocking_doors_facing_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeightOfStockingDoorsFacingZone { get; set; } = null;
        

[JsonProperty(PropertyName="stocking_door_u_value_facing_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> StockingDoorUValueFacingZone { get; set; } = null;
        

[JsonProperty(PropertyName="stocking_door_opening_schedule_name_facing_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string StockingDoorOpeningScheduleNameFacingZone { get; set; } = "";
        

[JsonProperty(PropertyName="stocking_door_opening_protection_type_facing_zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string StockingDoorOpeningProtectionTypeFacingZone { get; set; } = "";
    }
    
    [Description(@"Works in conjunction with a refrigeration chiller set, compressor rack, a refrigeration system, or a refrigeration secondary system to simulate the performance of an air chiller, similar to one found in a refrigerated warehouse. Energy use for fans and heaters is modeled based on inputs for nominal power, schedules, and control type. The air chiller model accounts for the sensible and latent heat exchange with the surrounding environment.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Refrigeration_AirChiller
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description(@"In each case, select the rating option that corresponds to the expected service conditions. For example, U.S. manufacturers quote a separate Unit Load Factor for wet or frosted coils. If the evaporating temperature is less than 0C, input the frosted coil value. Within the European convention, select SC1, 2, 3, 4, or 5 depending upon the expected evaporating temperature.")]
[JsonProperty(PropertyName="capacity_rating_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_AirChiller_CapacityRatingType CapacityRatingType { get; set; } = (Refrigeration_AirChiller_CapacityRatingType)Enum.Parse(typeof(Refrigeration_AirChiller_CapacityRatingType), "CapacityTotalSpecificConditions");
        

[Description(@"The sensible cooling capacity in watts (W/C) at rated conditions. The value entered for this field must be greater than zero, with no default value. This value is only used if the Capacity Rating Type is UnitLoadFactorSensibleOnly. The value given must be based upon the difference between the chiller inlet and outlet air temperatures, not on the difference between the zone mean temperature and the outlet air temperature")]
[JsonProperty(PropertyName="rated_unit_load_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedUnitLoadFactor { get; set; } = null;
        

[Description(@"This value is only used if the Capacity Rating Type is NOT UnitLoadFactorSensibleOnly. For CapacityTotalSpecificConditions, this capacity includes both sensible and latent at the conditions given in the next two fields. Note that the European Standard ratings are sensible only and the European Nominal ratings include latent capacity as well. The value given here must correspond to the capacity rating type given previously")]
[JsonProperty(PropertyName="rated_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedCapacity { get; set; } = null;
        

[Description("This field is ONLY used if the Capacity Rating Type is CapacityTotalSpecificCondi" +
    "tions and represents the relative humidity at rated conditions. The default is 8" +
    "5.")]
[JsonProperty(PropertyName="rated_relative_humidity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedRelativeHumidity { get; set; } = Double.Parse("85", CultureInfo.InvariantCulture);
        

[Description("If DXEvaporator, use evaporating temperature (saturated suction temperature) If B" +
    "rineCoil, use Brine entering temperature used to set minimum suction pressure fo" +
    "r DX systems and minimum brine temp for secondary systems")]
[JsonProperty(PropertyName="rated_cooling_source_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedCoolingSourceTemperature { get; set; } = null;
        

[Description("The rated difference between the air entering the refrigeration chiller and the c" +
    "ooling source temperature in degC.")]
[JsonProperty(PropertyName="rated_temperature_difference_dt1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedTemperatureDifferenceDt1 { get; set; } = null;
        

[Description("The maximum difference between the air entering the refrigeration chiller and the" +
    " cooling source temperature in degC used to limit capacity during pull-down. def" +
    "aults to 1.3 times the Rated Temperature Difference DT1")]
[JsonProperty(PropertyName="maximum_temperature_difference_between_inlet_air_and_evaporating_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumTemperatureDifferenceBetweenInletAirAndEvaporatingTemperature { get; set; } = null;
        

[Description("This is the manufacturer\'s correction factor for coil material corresponding to r" +
    "ating")]
[JsonProperty(PropertyName="coil_material_correction_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoilMaterialCorrectionFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("This is the manufacturer\'s correction factor for refrigerant corresponding to rat" +
    "ing")]
[JsonProperty(PropertyName="refrigerant_correction_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RefrigerantCorrectionFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("In each case, select the correction curve type that corresponds to the rating typ" +
    "e. default LinearSHR60 unless Capacity Rating Type = CapacityTotalSpecificCondit" +
    "ions")]
[JsonProperty(PropertyName="capacity_correction_curve_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_AirChiller_CapacityCorrectionCurveType CapacityCorrectionCurveType { get; set; } = (Refrigeration_AirChiller_CapacityCorrectionCurveType)Enum.Parse(typeof(Refrigeration_AirChiller_CapacityCorrectionCurveType), "European");
        

[Description("Should be blank for LinearSHR60 correction curve type")]
[JsonProperty(PropertyName="capacity_correction_curve_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CapacityCorrectionCurveName { get; set; } = "";
        

[Description("only used when the capacity correction curve type is LinearSHR60")]
[JsonProperty(PropertyName="shr60_correction_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Shr60CorrectionFactor { get; set; } = Double.Parse("1.48", CultureInfo.InvariantCulture);
        

[Description("Include total for all heater power Do not include defrost heater power")]
[JsonProperty(PropertyName="rated_total_heating_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedTotalHeatingPower { get; set; } = null;
        

[Description("Values will be used to multiply the total heating power Values in the schedule sh" +
    "ould be between 0.0 and 1.0 Defaults to always on if schedule name left blank.")]
[JsonProperty(PropertyName="heating_power_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingPowerScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="fan_speed_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_AirChiller_FanSpeedControlType FanSpeedControlType { get; set; } = (Refrigeration_AirChiller_FanSpeedControlType)Enum.Parse(typeof(Refrigeration_AirChiller_FanSpeedControlType), "Fixed");
        

[JsonProperty(PropertyName="rated_fan_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedFanPower { get; set; } = Double.Parse("375", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="rated_air_flow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedAirFlow { get; set; } = null;
        

[Description("Minimum air flow fraction through fan")]
[JsonProperty(PropertyName="minimum_fan_air_flow_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumFanAirFlowRatio { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[Description("HotFluid includes either hot gas defrost for a DX system or Hot Brine defrost if " +
    "this walk in is cooled by brine from a secondary chiller")]
[JsonProperty(PropertyName="defrost_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_AirChiller_DefrostType DefrostType { get; set; } = (Refrigeration_AirChiller_DefrostType)Enum.Parse(typeof(Refrigeration_AirChiller_DefrostType), "Electric");
        

[JsonProperty(PropertyName="defrost_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_AirChiller_DefrostControlType DefrostControlType { get; set; } = (Refrigeration_AirChiller_DefrostControlType)Enum.Parse(typeof(Refrigeration_AirChiller_DefrostControlType), "TimeSchedule");
        

[Description("The schedule values should be 0 (off) or 1 (on)")]
[JsonProperty(PropertyName="defrost_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DefrostScheduleName { get; set; } = "";
        

[Description(@"The schedule values should be 0 (off) or 1 (on) The start time for each defrost period in this drip-down schedule should coincide with the start time for each defrost period in the defrost schedule (previous input field). The length of each defrost drip-down period must be greater than or equal to the corresponding defrost period specified in the defrost schedule. This extra time allows the melted frost to drip from the coil before refrigeration is restarted.")]
[JsonProperty(PropertyName="defrost_drip_down_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DefrostDripDownScheduleName { get; set; } = "";
        

[Description("needed for all defrost types except none and offcycle")]
[JsonProperty(PropertyName="defrost_power", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DefrostPower { get; set; } = null;
        

[Description("This is the portion of the defrost energy that is available to melt frost Needed " +
    "only for defrost control type TemperatureTermination defaults to 0.7 for electri" +
    "c defrost and to 0.3 for hot fluid defrost")]
[JsonProperty(PropertyName="temperature_termination_defrost_fraction_to_ice", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureTerminationDefrostFractionToIce { get; set; } = null;
        

[JsonProperty(PropertyName="vertical_location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Refrigeration_AirChiller_VerticalLocation VerticalLocation { get; set; } = (Refrigeration_AirChiller_VerticalLocation)Enum.Parse(typeof(Refrigeration_AirChiller_VerticalLocation), "Middle");
        

[Description("This value is only used if the Cooling Source Type is DXEvaporator")]
[JsonProperty(PropertyName="average_refrigerant_charge_inventory", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AverageRefrigerantChargeInventory { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    public enum Refrigeration_AirChiller_CapacityRatingType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="CapacityTotalSpecificConditions")]
        CapacityTotalSpecificConditions = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="EuropeanSC1NominalWet")]
        EuropeanSC1NominalWet = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="EuropeanSC1Standard")]
        EuropeanSC1Standard = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="EuropeanSC2NominalWet")]
        EuropeanSC2NominalWet = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="EuropeanSC2Standard")]
        EuropeanSC2Standard = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="EuropeanSC3NominalWet")]
        EuropeanSC3NominalWet = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="EuropeanSC3Standard")]
        EuropeanSC3Standard = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="EuropeanSC4NominalWet")]
        EuropeanSC4NominalWet = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="EuropeanSC4Standard")]
        EuropeanSC4Standard = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="EuropeanSC5NominalWet")]
        EuropeanSC5NominalWet = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="EuropeanSC5Standard")]
        EuropeanSC5Standard = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedLinear")]
        FixedLinear = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="UnitLoadFactorSensibleOnly")]
        UnitLoadFactorSensibleOnly = 12,
    }
    
    public enum Refrigeration_AirChiller_CapacityCorrectionCurveType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="European")]
        European = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="LinearSHR60")]
        LinearSHR60 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="QuadraticSHR")]
        QuadraticSHR = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="TabularRHxDT1xTRoom")]
        TabularRHxDT1xTRoom = 3,
    }
    
    public enum Refrigeration_AirChiller_FanSpeedControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fixed")]
        Fixed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedLinear")]
        FixedLinear = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="TwoSpeed")]
        TwoSpeed = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableSpeed")]
        VariableSpeed = 4,
    }
    
    public enum Refrigeration_AirChiller_DefrostType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Electric")]
        Electric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HotFluid")]
        HotFluid = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="OffCycle")]
        OffCycle = 4,
    }
    
    public enum Refrigeration_AirChiller_DefrostControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureTermination")]
        TemperatureTermination = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TimeSchedule")]
        TimeSchedule = 2,
    }
    
    public enum Refrigeration_AirChiller_VerticalLocation
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Ceiling")]
        Ceiling = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Floor")]
        Floor = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Middle")]
        Middle = 3,
    }
    
    [Description(@"Works in conjunction with one or multiple air chillers, compressor racks, refrigeration systems, or refrigeration secondary system objects to simulate the performance of a group of air chillers cooling a single zone. The chiller set model passes information about the zone conditions to determine the performance of individual chiller coils within the set, thus providing the sensible and latent heat exchange with the zone environment.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_RefrigerationChillerSet
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("This must be a controlled zone and appear in a ZoneHVAC:EquipmentConnections obje" +
    "ct.")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Not used - reserved for future use Name of the zone exhaust node (see Node) from " +
    "which the refrigeration chiller draws its indoor air. This should be one of the " +
    "zone exhaust nodes for the zone cooled by the chiller set.")]
[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[Description("Not used - reserved for future use The name of the node where the chiller coil se" +
    "nds its outlet air, which must be one of the inlet air nodes for the zone which " +
    "is being cooled.")]
[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[Description("This list is the RefrigerationAirChillerNames object-list")]
[JsonProperty(PropertyName="chillers", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Chillers { get; set; } = null;
    }
}
