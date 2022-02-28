namespace EnergyPlus.SimulationParameters
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
    using EnergyPlus.Schedules;
    using EnergyPlus.SetpointManagers;
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
    
    
    [Description("Specifies the EnergyPlus version of the IDF file.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Version
    {
        

[JsonProperty(PropertyName="version_identifier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string VersionIdentifier { get; set; } = "9.5";
    }
    
    [Description(@"Note that the following 3 fields are related to the Sizing:Zone, Sizing:System, and Sizing:Plant objects. Having these fields set to Yes but no corresponding Sizing object will not cause the sizing to be done. However, having any of these fields set to No, the corresponding Sizing object is ignored. Note also, if you want to do system sizing, you must also do zone sizing in the same run or an error will result.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SimulationControl
    {
        

[Description("If Yes, Zone sizing is accomplished from corresponding Sizing:Zone objects and au" +
    "tosize fields.")]
[JsonProperty(PropertyName="do_zone_sizing_calculation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes DoZoneSizingCalculation { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("If Yes, System sizing is accomplished from corresponding Sizing:System objects an" +
    "d autosize fields. If Yes, Zone sizing (previous field) must also be Yes.")]
[JsonProperty(PropertyName="do_system_sizing_calculation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes DoSystemSizingCalculation { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("If Yes, Plant sizing is accomplished from corresponding Sizing:Plant objects and " +
    "autosize fields.")]
[JsonProperty(PropertyName="do_plant_sizing_calculation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes DoPlantSizingCalculation { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("If Yes, SizingPeriod:* objects are executed and results from those may be display" +
    "ed..")]
[JsonProperty(PropertyName="run_simulation_for_sizing_periods", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes RunSimulationForSizingPeriods { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[Description("If Yes, RunPeriod:* objects are executed and results from those may be displayed." +
    ".")]
[JsonProperty(PropertyName="run_simulation_for_weather_file_run_periods", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes RunSimulationForWeatherFileRunPeriods { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "Yes");
        

[Description("If Yes, SizingPeriod:* objects are exectuted additional times for advanced sizing" +
    ". Currently limited to use with coincident plant sizing, see Sizing:Plant object" +
    "")]
[JsonProperty(PropertyName="do_hvac_sizing_simulation_for_sizing_periods", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes DoHvacSizingSimulationForSizingPeriods { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("the entire set of SizingPeriod:* objects may be repeated to fine tune size result" +
    "s this input sets a limit on the number of passes that the sizing algorithms can" +
    " repeate the set")]
[JsonProperty(PropertyName="maximum_number_of_hvac_sizing_simulation_passes", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumNumberOfHvacSizingSimulationPasses { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
    }
    
    [Description("This object enables users to choose certain options that speed up EnergyPlus simu" +
        "lation, but may lead to small decreases in accuracy of results.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PerformancePrecisionTradeoffs
    {
        

[Description("If Yes, an analytical or empirical solution will be used to replace iterations in" +
    " the coil performance calculations.")]
[JsonProperty(PropertyName="use_coil_direct_solutions", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes UseCoilDirectSolutions { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("Determines which algorithm will be used to solve long wave radiant exchange among" +
    " surfaces within a zone.")]
[JsonProperty(PropertyName="zone_radiant_exchange_algorithm", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PerformancePrecisionTradeoffs_ZoneRadiantExchangeAlgorithm ZoneRadiantExchangeAlgorithm { get; set; } = (PerformancePrecisionTradeoffs_ZoneRadiantExchangeAlgorithm)Enum.Parse(typeof(PerformancePrecisionTradeoffs_ZoneRadiantExchangeAlgorithm), "ScriptF");
        

[Description("The increasing mode number roughly correspond with increased speed. A description" +
    " of each mode are shown in the documentation. When Advanced is selected the N1 f" +
    "ield value is used.")]
[JsonProperty(PropertyName="override_mode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PerformancePrecisionTradeoffs_OverrideMode OverrideMode { get; set; } = (PerformancePrecisionTradeoffs_OverrideMode)Enum.Parse(typeof(PerformancePrecisionTradeoffs_OverrideMode), "Normal");
        

[Description("Maximum zone temperature change before HVAC timestep is shortened. Only used when" +
    " Override Mode is set to Advanced")]
[JsonProperty(PropertyName="maxzonetempdiff", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Maxzonetempdiff { get; set; } = Double.Parse("0.3", CultureInfo.InvariantCulture);
        

[Description("Maximum surface temperature change before HVAC timestep is shortened. Only used w" +
    "hen Override Mode is set to Advanced")]
[JsonProperty(PropertyName="maxalloweddeltemp", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Maxalloweddeltemp { get; set; } = Double.Parse("0.002", CultureInfo.InvariantCulture);
    }
    
    public enum PerformancePrecisionTradeoffs_ZoneRadiantExchangeAlgorithm
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CarrollMRT")]
        CarrollMRT = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ScriptF")]
        ScriptF = 2,
    }
    
    public enum PerformancePrecisionTradeoffs_OverrideMode
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Advanced")]
        Advanced = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Mode01")]
        Mode01 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Mode02")]
        Mode02 = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Mode03")]
        Mode03 = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Mode04")]
        Mode04 = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Mode05")]
        Mode05 = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="Mode06")]
        Mode06 = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Mode07")]
        Mode07 = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Normal")]
        Normal = 9,
    }
    
    [Description("Describes parameters that are used during the simulation of the building. There a" +
        "re necessary correlations between the entries for this object and some entries i" +
        "n the Site:WeatherStation and Site:HeightVariation objects, specifically the Ter" +
        "rain field.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Building
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("degrees from true North")]
[JsonProperty(PropertyName="north_axis", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NorthAxis { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Country=FlatOpenCountry | Suburbs=CountryTownsSuburbs | City=CityCenter | Ocean=b" +
    "ody of water (5km) | Urban=Urban-Industrial-Forest")]
[JsonProperty(PropertyName="terrain", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Building_Terrain Terrain { get; set; } = (Building_Terrain)Enum.Parse(typeof(Building_Terrain), "Suburbs");
        

[Description("Loads Convergence Tolerance Value is a change in load from one warmup day to the " +
    "next")]
[JsonProperty(PropertyName="loads_convergence_tolerance_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoadsConvergenceToleranceValue { get; set; } = Double.Parse("0.04", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="temperature_convergence_tolerance_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureConvergenceToleranceValue { get; set; } = Double.Parse("0.4", CultureInfo.InvariantCulture);
        

[Description("MinimalShadowing | FullExterior | FullInteriorAndExterior | FullExteriorWithRefle" +
    "ctions | FullInteriorAndExteriorWithReflections")]
[JsonProperty(PropertyName="solar_distribution", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Building_SolarDistribution SolarDistribution { get; set; } = (Building_SolarDistribution)Enum.Parse(typeof(Building_SolarDistribution), "FullExterior");
        

[Description("EnergyPlus will only use as many warmup days as needed to reach convergence toler" +
    "ance. This field\'s value should NOT be set less than 25.")]
[JsonProperty(PropertyName="maximum_number_of_warmup_days", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumNumberOfWarmupDays { get; set; } = Double.Parse("25", CultureInfo.InvariantCulture);
        

[Description(@"The minimum number of warmup days that produce enough temperature and flux history to start EnergyPlus simulation for all reference buildings was suggested to be 6. However this can lead to excessive run times as warmup days can be repeated needlessly. For faster execution rely on the convergence criteria to detect when warmup is complete. When this field is greater than the maximum warmup days defined previous field the maximum number of warmup days will be reset to the minimum value entered here. Warmup days will be set to be the value you entered. The default is 1.")]
[JsonProperty(PropertyName="minimum_number_of_warmup_days", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumNumberOfWarmupDays { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
    }
    
    public enum Building_Terrain
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="City")]
        City = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Country")]
        Country = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Ocean")]
        Ocean = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Suburbs")]
        Suburbs = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Urban")]
        Urban = 5,
    }
    
    public enum Building_SolarDistribution
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FullExterior")]
        FullExterior = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FullExteriorWithReflections")]
        FullExteriorWithReflections = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FullInteriorAndExterior")]
        FullInteriorAndExterior = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="FullInteriorAndExteriorWithReflections")]
        FullInteriorAndExteriorWithReflections = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="MinimalShadowing")]
        MinimalShadowing = 5,
    }
    
    [Description("This object is used to control details of the solar, shading, and daylighting mod" +
        "els")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ShadowCalculation
    {
        

[Description(@"Select between CPU-based polygon clipping method, the GPU-based pixel counting method, or importing from external shading data. If PixelCounting is selected and GPU hardware (or GPU emulation) is not available, a warning will be displayed and EnergyPlus will revert to PolygonClipping. If Scheduled is chosen, the External Shading Fraction Schedule Name is required in SurfaceProperty:LocalEnvironment. If Imported is chosen, the Schedule:File:Shading object is required.")]
[JsonProperty(PropertyName="shading_calculation_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ShadowCalculation_ShadingCalculationMethod ShadingCalculationMethod { get; set; } = (ShadowCalculation_ShadingCalculationMethod)Enum.Parse(typeof(ShadowCalculation_ShadingCalculationMethod), "PolygonClipping");
        

[Description("choose calculation frequency method. note that Timestep is only needed for certai" +
    "n cases and can increase execution time significantly.")]
[JsonProperty(PropertyName="shading_calculation_update_frequency_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ShadowCalculation_ShadingCalculationUpdateFrequencyMethod ShadingCalculationUpdateFrequencyMethod { get; set; } = (ShadowCalculation_ShadingCalculationUpdateFrequencyMethod)Enum.Parse(typeof(ShadowCalculation_ShadingCalculationUpdateFrequencyMethod), "Periodic");
        

[Description("enter number of days this field is only used if the previous field is set to Peri" +
    "odic warning issued if >31")]
[JsonProperty(PropertyName="shading_calculation_update_frequency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ShadingCalculationUpdateFrequency { get; set; } = Double.Parse("20", CultureInfo.InvariantCulture);
        

[Description("Number of allowable figures in shadow overlap in PolygonClipping calculations")]
[JsonProperty(PropertyName="maximum_figures_in_shadow_overlap_calculations", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumFiguresInShadowOverlapCalculations { get; set; } = Double.Parse("15000", CultureInfo.InvariantCulture);
        

[Description("Advanced Feature. Internal default is SutherlandHodgman Refer to InputOutput Refe" +
    "rence and Engineering Reference for more information")]
[JsonProperty(PropertyName="polygon_clipping_algorithm", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ShadowCalculation_PolygonClippingAlgorithm PolygonClippingAlgorithm { get; set; } = (ShadowCalculation_PolygonClippingAlgorithm)Enum.Parse(typeof(ShadowCalculation_PolygonClippingAlgorithm), "SutherlandHodgman");
        

[Description("Number of pixels in both dimensions of the surface rendering")]
[JsonProperty(PropertyName="pixel_counting_resolution", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PixelCountingResolution { get; set; } = Double.Parse("512", CultureInfo.InvariantCulture);
        

[Description("Advanced Feature. Internal default is SimpleSkyDiffuseModeling If you have shadin" +
    "g elements that change transmittance over the year, you may wish to choose the d" +
    "etailed method. Refer to InputOutput Reference and Engineering Reference for mor" +
    "e information")]
[JsonProperty(PropertyName="sky_diffuse_modeling_algorithm", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ShadowCalculation_SkyDiffuseModelingAlgorithm SkyDiffuseModelingAlgorithm { get; set; } = (ShadowCalculation_SkyDiffuseModelingAlgorithm)Enum.Parse(typeof(ShadowCalculation_SkyDiffuseModelingAlgorithm), "SimpleSkyDiffuseModeling");
        

[Description("If Yes is chosen, the calculated external shading fraction results will be saved " +
    "to an external CSV file with surface names as the column headers.")]
[JsonProperty(PropertyName="output_external_shading_calculation_results", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes OutputExternalShadingCalculationResults { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description(@"If Yes, self-shading will be disabled from all exterior surfaces in a given Shading Zone Group to surfaces within the same Shading Zone Group. If both Disable Self-Shading Within Shading Zone Groups and Disable Self-Shading From Shading Zone Groups to Other Zones = Yes, then all self-shading from exterior surfaces will be disabled. If only one of these fields = Yes, then at least one Shading Zone Group must be specified, or this field will be ignored. Shading from Shading:* surfaces, overhangs, fins, and reveals will not be disabled.")]
[JsonProperty(PropertyName="disable_self_shading_within_shading_zone_groups", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes DisableSelfShadingWithinShadingZoneGroups { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description(@"If Yes, self-shading will be disabled from all exterior surfaces in a given Shading Zone Group to all other zones in the model. If both Disable Self-Shading Within Shading Zone Groups and Disable Self-Shading From Shading Zone Groups to Other Zones = Yes, then all self-shading from exterior surfaces will be disabled. If only one of these fields = Yes, then at least one Shading Zone Group must be specified, or this field will be ignored. Shading from Shading:* surfaces, overhangs, fins, and reveals will not be disabled.")]
[JsonProperty(PropertyName="disable_self_shading_from_shading_zone_groups_to_other_zones", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes DisableSelfShadingFromShadingZoneGroupsToOtherZones { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("This list is the ZoneListNames object-list")]
[JsonProperty(PropertyName="shading_zone_groups", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> ShadingZoneGroups { get; set; } = null;
    }
    
    public enum ShadowCalculation_ShadingCalculationMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Imported")]
        Imported = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="PixelCounting")]
        PixelCounting = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PolygonClipping")]
        PolygonClipping = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Scheduled")]
        Scheduled = 4,
    }
    
    public enum ShadowCalculation_ShadingCalculationUpdateFrequencyMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Periodic")]
        Periodic = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Timestep")]
        Timestep = 2,
    }
    
    public enum ShadowCalculation_PolygonClippingAlgorithm
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ConvexWeilerAtherton")]
        ConvexWeilerAtherton = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SlaterBarskyandSutherlandHodgman")]
        SlaterBarskyandSutherlandHodgman = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="SutherlandHodgman")]
        SutherlandHodgman = 3,
    }
    
    public enum ShadowCalculation_SkyDiffuseModelingAlgorithm
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DetailedSkyDiffuseModeling")]
        DetailedSkyDiffuseModeling = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SimpleSkyDiffuseModeling")]
        SimpleSkyDiffuseModeling = 2,
    }
    
    [Description("Default indoor surface heat transfer convection algorithm to be used for all zone" +
        "s")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceConvectionAlgorithm_Inside
    {
        

[Description(@"Simple = constant value natural convection (ASHRAE) TARP = variable natural convection based on temperature difference (ASHRAE, Walton) CeilingDiffuser = ACH-based forced and mixed convection correlations for ceiling diffuser configuration with simple natural convection limit AdaptiveConvectionAlgorithm = dynamic selection of convection models based on conditions ASTMC1340 = mixed convection correlations based on heat flow direction, surface tilt angle, surface characteristic length, and air speed past the surface.")]
[JsonProperty(PropertyName="algorithm", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Inside_Algorithm Algorithm { get; set; } = (SurfaceConvectionAlgorithm_Inside_Algorithm)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Inside_Algorithm), "TARP");
    }
    
    public enum SurfaceConvectionAlgorithm_Inside_Algorithm
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ASTMC1340")]
        ASTMC1340 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveConvectionAlgorithm")]
        AdaptiveConvectionAlgorithm = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="CeilingDiffuser")]
        CeilingDiffuser = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Simple")]
        Simple = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="TARP")]
        TARP = 5,
    }
    
    [Description("Default outside surface heat transfer convection algorithm to be used for all zon" +
        "es")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SurfaceConvectionAlgorithm_Outside
    {
        

[Description(@"SimpleCombined = Combined radiation and convection coefficient using simple ASHRAE model TARP = correlation from models developed by ASHRAE, Walton, and Sparrow et. al. MoWiTT = correlation from measurements by Klems and Yazdanian for smooth surfaces DOE-2 = correlation from measurements by Klems and Yazdanian for rough surfaces AdaptiveConvectionAlgorithm = dynamic selection of correlations based on conditions")]
[JsonProperty(PropertyName="algorithm", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SurfaceConvectionAlgorithm_Outside_Algorithm Algorithm { get; set; } = (SurfaceConvectionAlgorithm_Outside_Algorithm)Enum.Parse(typeof(SurfaceConvectionAlgorithm_Outside_Algorithm), "Empty");
    }
    
    public enum SurfaceConvectionAlgorithm_Outside_Algorithm
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AdaptiveConvectionAlgorithm")]
        AdaptiveConvectionAlgorithm = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DOE-2")]
        DOE2 = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MoWiTT")]
        MoWiTT = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="SimpleCombined")]
        SimpleCombined = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="TARP")]
        TARP = 5,
    }
    
    [Description(@"Determines which Heat Balance Algorithm will be used ie. CTF (Conduction Transfer Functions), EMPD (Effective Moisture Penetration Depth with Conduction Transfer Functions). Advanced/Research Usage: CondFD (Conduction Finite Difference) Advanced/Research Usage: ConductionFiniteDifferenceSimplified Advanced/Research Usage: HAMT (Combined Heat And Moisture Finite Element)")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HeatBalanceAlgorithm
    {
        

[JsonProperty(PropertyName="algorithm", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HeatBalanceAlgorithm_Algorithm Algorithm { get; set; } = (HeatBalanceAlgorithm_Algorithm)Enum.Parse(typeof(HeatBalanceAlgorithm_Algorithm), "ConductionTransferFunction");
        

[JsonProperty(PropertyName="surface_temperature_upper_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SurfaceTemperatureUpperLimit { get; set; } = Double.Parse("200", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_surface_convection_heat_transfer_coefficient_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumSurfaceConvectionHeatTransferCoefficientValue { get; set; } = Double.Parse("0.1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_surface_convection_heat_transfer_coefficient_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumSurfaceConvectionHeatTransferCoefficientValue { get; set; } = Double.Parse("1000", CultureInfo.InvariantCulture);
    }
    
    public enum HeatBalanceAlgorithm_Algorithm
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CombinedHeatAndMoistureFiniteElement")]
        CombinedHeatAndMoistureFiniteElement = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ConductionFiniteDifference")]
        ConductionFiniteDifference = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ConductionTransferFunction")]
        ConductionTransferFunction = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="MoisturePenetrationDepthConductionTransferFunction")]
        MoisturePenetrationDepthConductionTransferFunction = 4,
    }
    
    [Description("Determines settings for the Conduction Finite Difference algorithm for surface he" +
        "at transfer modeling.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HeatBalanceSettings_ConductionFiniteDifference
    {
        

[JsonProperty(PropertyName="difference_scheme", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HeatBalanceSettings_ConductionFiniteDifference_DifferenceScheme DifferenceScheme { get; set; } = (HeatBalanceSettings_ConductionFiniteDifference_DifferenceScheme)Enum.Parse(typeof(HeatBalanceSettings_ConductionFiniteDifference_DifferenceScheme), "FullyImplicitFirstOrder");
        

[Description("increase or decrease number of nodes")]
[JsonProperty(PropertyName="space_discretization_constant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SpaceDiscretizationConstant { get; set; } = Double.Parse("3", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="relaxation_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelaxationFactor { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="inside_face_surface_temperature_convergence_criteria", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InsideFaceSurfaceTemperatureConvergenceCriteria { get; set; } = Double.Parse("0.002", CultureInfo.InvariantCulture);
    }
    
    public enum HeatBalanceSettings_ConductionFiniteDifference_DifferenceScheme
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CrankNicholsonSecondOrder")]
        CrankNicholsonSecondOrder = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FullyImplicitFirstOrder")]
        FullyImplicitFirstOrder = 2,
    }
    
    [Description("Determines which algorithm will be used to solve the zone air heat balance.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneAirHeatBalanceAlgorithm
    {
        

[JsonProperty(PropertyName="algorithm", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneAirHeatBalanceAlgorithm_Algorithm Algorithm { get; set; } = (ZoneAirHeatBalanceAlgorithm_Algorithm)Enum.Parse(typeof(ZoneAirHeatBalanceAlgorithm_Algorithm), "ThirdOrderBackwardDifference");
    }
    
    public enum ZoneAirHeatBalanceAlgorithm_Algorithm
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AnalyticalSolution")]
        AnalyticalSolution = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="EulerMethod")]
        EulerMethod = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ThirdOrderBackwardDifference")]
        ThirdOrderBackwardDifference = 3,
    }
    
    [Description("Determines which contaminant concentration will be simulates.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneAirContaminantBalance
    {
        

[Description("If Yes, CO2 simulation will be performed.")]
[JsonProperty(PropertyName="carbon_dioxide_concentration", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes CarbonDioxideConcentration { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("Schedule values should be in parts per million (ppm)")]
[JsonProperty(PropertyName="outdoor_carbon_dioxide_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorCarbonDioxideScheduleName { get; set; } = "";
        

[Description("If Yes, generic contaminant simulation will be performed.")]
[JsonProperty(PropertyName="generic_contaminant_concentration", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes GenericContaminantConcentration { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("Schedule values should be generic contaminant concentration in parts per million " +
    "(ppm)")]
[JsonProperty(PropertyName="outdoor_generic_contaminant_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorGenericContaminantScheduleName { get; set; } = "";
    }
    
    [Description(@"Enforces the zone air mass flow balance by either adjusting zone mixing object flow only, adjusting zone total return flow only, zone mixing and the zone total return flows, or adjusting the zone total return and zone mixing object flows. Zone infiltration flow air flow is increased or decreased depending user selection in the infiltration treatment method. If either of zone mixing or zone return flow adjusting methods or infiltration is active, then the zone air mass flow balance calculation will attempt to enforce conservation of mass for each zone. If flow balancing method is ""None"" and infiltration is ""None"", then the zone air mass flow calculation defaults to assume self-balanced simple flow mixing and infiltration objects.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneAirMassFlowConservation
    {
        

[Description(@"If ""AdjustMixingOnly"", zone mixing object flow rates are adjusted to balance the zone air mass flow and zone infiltration air flow may be increased or decreased if required in order to balance the zone air mass flow. If ""AdjustReturnOnly"", zone total return flow rate is adjusted to balance the zone air mass flow and zone infiltration air flow may be increased or decreased if required in order to balance the zone air mass flow. If ""AdjustMixingThenReturn"", first the zone mixing objects flow rates are adjusted to balance the zone air flow, second zone total return flow rate is adjusted and zone infiltration air flow may be increased or decreased if required in order to balance the zone air mass flow. If ""AdjustReturnThenMixing"", first zone total return flow rate is adjusted to balance the zone air flow, second the zone mixing object flow rates are adjusted and infiltration air flow may be increased or decreased if required in order to balance the zone air mass flow.")]
[JsonProperty(PropertyName="adjust_zone_mixing_and_return_for_air_mass_flow_balance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneAirMassFlowConservation_AdjustZoneMixingAndReturnForAirMassFlowBalance AdjustZoneMixingAndReturnForAirMassFlowBalance { get; set; } = (ZoneAirMassFlowConservation_AdjustZoneMixingAndReturnForAirMassFlowBalance)Enum.Parse(typeof(ZoneAirMassFlowConservation_AdjustZoneMixingAndReturnForAirMassFlowBalance), "None");
        

[Description(@"This input field allows user to choose how zone infiltration flow is treated during the zone air mass flow balance calculation. AddInfiltrationFlow may add infiltration to the base flow specified in the infiltration object to balance the zone air mass flow. The additional infiltration air mass flow is not self-balanced. The base flow is assumed to be self-balanced. AdjustInfiltrationFlow may adjust the base flow calculated using the base flow specified in the infiltration object to balance the zone air mass flow. If it If no adjustment is required, then the base infiltration is assumed to be self-balanced. None will make no changes to the base infiltration flow.")]
[JsonProperty(PropertyName="infiltration_balancing_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneAirMassFlowConservation_InfiltrationBalancingMethod InfiltrationBalancingMethod { get; set; } = (ZoneAirMassFlowConservation_InfiltrationBalancingMethod)Enum.Parse(typeof(ZoneAirMassFlowConservation_InfiltrationBalancingMethod), "AddInfiltrationFlow");
        

[Description(@"This input field allows user to choose which zones are included in infiltration balancing. MixingSourceZonesOnly allows infiltration balancing only in zones which as source zones for mixing which also have an infiltration object defined. AllZones allows infiltration balancing in any zone which has an infiltration object defined.")]
[JsonProperty(PropertyName="infiltration_balancing_zones", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneAirMassFlowConservation_InfiltrationBalancingZones InfiltrationBalancingZones { get; set; } = (ZoneAirMassFlowConservation_InfiltrationBalancingZones)Enum.Parse(typeof(ZoneAirMassFlowConservation_InfiltrationBalancingZones), "MixingSourceZonesOnly");
    }
    
    public enum ZoneAirMassFlowConservation_AdjustZoneMixingAndReturnForAirMassFlowBalance
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AdjustMixingOnly")]
        AdjustMixingOnly = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AdjustMixingThenReturn")]
        AdjustMixingThenReturn = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="AdjustReturnOnly")]
        AdjustReturnOnly = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="AdjustReturnThenMixing")]
        AdjustReturnThenMixing = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 5,
    }
    
    public enum ZoneAirMassFlowConservation_InfiltrationBalancingMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AddInfiltrationFlow")]
        AddInfiltrationFlow = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="AdjustInfiltrationFlow")]
        AdjustInfiltrationFlow = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    public enum ZoneAirMassFlowConservation_InfiltrationBalancingZones
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AllZones")]
        AllZones = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="MixingSourceZonesOnly")]
        MixingSourceZonesOnly = 2,
    }
    
    [Description("Multiplier altering the relative capacitance of the air compared to an empty zone" +
        "")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneCapacitanceMultiplier_ResearchSpecial
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("If this field is left blank, the multipliers are applied to all the zones not spe" +
    "cified")]
[JsonProperty(PropertyName="zone_or_zonelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneOrZonelistName { get; set; } = "";
        

[Description("Used to alter the capacitance of zone air with respect to heat or temperature")]
[JsonProperty(PropertyName="temperature_capacity_multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureCapacityMultiplier { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Used to alter the capacitance of zone air with respect to moisture or humidity ra" +
    "tio")]
[JsonProperty(PropertyName="humidity_capacity_multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HumidityCapacityMultiplier { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Used to alter the capacitance of zone air with respect to zone air carbon dioxide" +
    " concentration")]
[JsonProperty(PropertyName="carbon_dioxide_capacity_multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CarbonDioxideCapacityMultiplier { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Used to alter the capacitance of zone air with respect to zone air generic contam" +
    "inant concentration")]
[JsonProperty(PropertyName="generic_contaminant_capacity_multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GenericContaminantCapacityMultiplier { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
    }
    
    [Description("Specifies the \"basic\" timestep for the simulation. The value entered here is also" +
        " known as the Zone Timestep. This is used in the Zone Heat Balance Model calcula" +
        "tion as the driving timestep for heat transfer and load calculations.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Timestep
    {
        

[Description(@"Number in hour: normal validity 4 to 60: 6 suggested Must be evenly divisible into 60 Allowable values include 1, 2, 3, 4, 5, 6, 10, 12, 15, 20, 30, and 60 Normal 6 is minimum as lower values may cause inaccuracies A minimum value of 20 is suggested for both ConductionFiniteDifference and CombinedHeatAndMoistureFiniteElement surface heat balance algorithms A minimum of 12 is suggested for simulations involving a Vegetated Roof (Material:RoofVegetation).")]
[JsonProperty(PropertyName="number_of_timesteps_per_hour", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfTimestepsPerHour { get; set; } = Double.Parse("6", CultureInfo.InvariantCulture);
    }
    
    [Description("Specifies limits on HVAC system simulation timesteps and iterations. This item is" +
        " an advanced feature that should be used only with caution.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ConvergenceLimits
    {
        

[Description("0 sets the minimum to the zone timestep (ref: Timestep) 1 is normal (ratchet down" +
    " to 1 minute) setting greater than zone timestep (in minutes) will effectively s" +
    "et to zone timestep")]
[JsonProperty(PropertyName="minimum_system_timestep", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumSystemTimestep { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_hvac_iterations", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumHvacIterations { get; set; } = Double.Parse("20", CultureInfo.InvariantCulture);
        

[Description(@"Controls the minimum number of plant system solver iterations within a single HVAC iteration Larger values will increase runtime but might improve solution accuracy for complicated plant systems Complex plants include: several interconnected loops, heat recovery, thermal load following generators, etc.")]
[JsonProperty(PropertyName="minimum_plant_iterations", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumPlantIterations { get; set; } = Double.Parse("2", CultureInfo.InvariantCulture);
        

[Description("Controls the maximum number of plant system solver iterations within a single HVA" +
    "C iteration Smaller values might decrease runtime but could decrease solution ac" +
    "curacy for complicated plant systems")]
[JsonProperty(PropertyName="maximum_plant_iterations", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumPlantIterations { get; set; } = Double.Parse("8", CultureInfo.InvariantCulture);
    }
    
    [Description("Specifies a HVAC system solver algorithm to find a root")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class HVACSystemRootFindingAlgorithm
    {
        

[JsonProperty(PropertyName="algorithm", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public HVACSystemRootFindingAlgorithm_Algorithm Algorithm { get; set; } = (HVACSystemRootFindingAlgorithm_Algorithm)Enum.Parse(typeof(HVACSystemRootFindingAlgorithm_Algorithm), "RegulaFalsi");
        

[Description("This field is used when RegulaFalsiThenBisection or BisectionThenRegulaFalsi is e" +
    "ntered. When iteration number is greater than the value, algorithm switches.")]
[JsonProperty(PropertyName="number_of_iterations_before_algorithm_switch", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfIterationsBeforeAlgorithmSwitch { get; set; } = Double.Parse("5", CultureInfo.InvariantCulture);
    }
    
    public enum HVACSystemRootFindingAlgorithm_Algorithm
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Alternation")]
        Alternation = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Bisection")]
        Bisection = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="BisectionThenRegulaFalsi")]
        BisectionThenRegulaFalsi = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="RegulaFalsi")]
        RegulaFalsi = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="RegulaFalsiThenBisection")]
        RegulaFalsiThenBisection = 5,
    }
}
