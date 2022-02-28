namespace EnergyPlus.DetailedGroundHeatTransfer
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
    
    
    [Description("Object determines if the Slab and Basement preprocessors are going to be executed" +
        ".")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Control
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="run_basement_preprocessor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes RunBasementPreprocessor { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[JsonProperty(PropertyName="run_slab_preprocessor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes RunSlabPreprocessor { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
    }
    
    [Description("Object gives an overall description of the slab ground heat transfer model.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Slab_Materials
    {
        

[Description("This field specifies the number of different materials that will be used in the m" +
    "odel. Typically only a ground material and a slab material are used. (2 material" +
    "s)")]
[JsonProperty(PropertyName="nmat_number_of_materials", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NmatNumberOfMaterials { get; set; } = null;
        

[Description(@"Two fields specify the albedo value of the surface: first for no snow coverage days; second for days with snow coverage. The albedo is the solar reflectivity of the surface, and can vary from 0.05 for blacktop to 0.95 for fresh snow. Typical values for North America reported by Bahnfleth range from 0.16 to 0.4.")]
[JsonProperty(PropertyName="albedo_surface_albedo_no_snow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AlbedoSurfaceAlbedoNoSnow { get; set; } = Double.Parse("0.16", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="albedo_surface_albedo_snow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AlbedoSurfaceAlbedoSnow { get; set; } = Double.Parse("0.4", CultureInfo.InvariantCulture);
        

[Description("EPSLW (No Snow and Snow) specifies the long wavelength (thermal) emissivity of th" +
    "e ground surface. primarily important for nighttime radiation to sky. typical va" +
    "lue .95")]
[JsonProperty(PropertyName="epslw_surface_emissivity_no_snow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EpslwSurfaceEmissivityNoSnow { get; set; } = Double.Parse("0.94", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="epslw_surface_emissivity_snow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EpslwSurfaceEmissivitySnow { get; set; } = Double.Parse("0.86", CultureInfo.InvariantCulture);
        

[Description("fields Z0 (No Snow and Snow) describe the height at which an experimentally veloc" +
    "ity profile goes to zero. typical value= .75 cm")]
[JsonProperty(PropertyName="z0_surface_roughness_no_snow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Z0SurfaceRoughnessNoSnow { get; set; } = Double.Parse("0.75", CultureInfo.InvariantCulture);
        

[Description("typical value= .05 cm")]
[JsonProperty(PropertyName="z0_surface_roughness_snow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Z0SurfaceRoughnessSnow { get; set; } = Double.Parse("0.25", CultureInfo.InvariantCulture);
        

[Description(@"These fields specify the combined convective and radiative heat transfer coefficient between the slab top inside surface and the room air for the cases where heat is flowing downward, and upward. The program toggles between the two if the direction of the heat flux changes. Typical values can be found in the ASHRAE Handbook of Fundamentals, but should be about 6 W/(m2-K) for downward heat flow and 9 W/(m2-K) for upward heat flow. typical value= 4-10")]
[JsonProperty(PropertyName="hin_indoor_hconv_downward_flow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HinIndoorHconvDownwardFlow { get; set; } = Double.Parse("6.13", CultureInfo.InvariantCulture);
        

[Description("typical value= 4-10")]
[JsonProperty(PropertyName="hin_indoor_hconv_upward", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HinIndoorHconvUpward { get; set; } = Double.Parse("9.26", CultureInfo.InvariantCulture);
    }
    
    [Description("This object contains the material properties for the materials used in the model." +
        " The fields are mostly self explanatory.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Slab_MatlProps
    {
        

[Description("Density of Slab Material typical value= 2300.0")]
[JsonProperty(PropertyName="rho_slab_material_density", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RhoSlabMaterialDensity { get; set; } = Double.Parse("2300", CultureInfo.InvariantCulture);
        

[Description("Density of Soil Material typical value= 1200.0")]
[JsonProperty(PropertyName="rho_soil_density", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RhoSoilDensity { get; set; } = Double.Parse("1200", CultureInfo.InvariantCulture);
        

[Description("Specific Heat of Slab Material typical value=650.0")]
[JsonProperty(PropertyName="cp_slab_cp", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CpSlabCp { get; set; } = Double.Parse("650", CultureInfo.InvariantCulture);
        

[Description("Specific Heat of Soil Material typical value= 1200.0")]
[JsonProperty(PropertyName="cp_soil_cp", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CpSoilCp { get; set; } = Double.Parse("1200", CultureInfo.InvariantCulture);
        

[Description("Conductivity of Slab Material typical value= .9")]
[JsonProperty(PropertyName="tcon_slab_k", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TconSlabK { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[Description("Conductivity of Soil Material typical value= 1.0")]
[JsonProperty(PropertyName="tcon_soil_k", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TconSoilK { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
    }
    
    [Description("Supplies some of the boundary conditions used in the ground heat transfer calcula" +
        "tions.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Slab_BoundConds
    {
        

[Description(@"This field specifies whether or not to use the evapotransporation model. The inclusion of evapotransporation in the calculation has the greatest effect in warm dry climates, primarily on the ground surface temperature. This field can be used to turn the evapotransporation off and on to check sensitivity to it.")]
[JsonProperty(PropertyName="evtr_is_surface_evapotranspiration_modeled", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public GroundHeatTransfer_Slab_BoundConds_EvtrIsSurfaceEvapotranspirationModeled EvtrIsSurfaceEvapotranspirationModeled { get; set; } = (GroundHeatTransfer_Slab_BoundConds_EvtrIsSurfaceEvapotranspirationModeled)Enum.Parse(typeof(GroundHeatTransfer_Slab_BoundConds_EvtrIsSurfaceEvapotranspirationModeled), "FALSE");
        

[Description("This field permits using a fixed temperature at the lower surface of the model in" +
    "stead of a zero heat flux condition. This change normally has a very small effec" +
    "t on the results. FALSE selects the zero flux lower boundary condition")]
[JsonProperty(PropertyName="fixbc_is_the_lower_boundary_at_a_fixed_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public GroundHeatTransfer_Slab_BoundConds_FixbcIsTheLowerBoundaryAtAFixedTemperature FixbcIsTheLowerBoundaryAtAFixedTemperature { get; set; } = (GroundHeatTransfer_Slab_BoundConds_FixbcIsTheLowerBoundaryAtAFixedTemperature)Enum.Parse(typeof(GroundHeatTransfer_Slab_BoundConds_FixbcIsTheLowerBoundaryAtAFixedTemperature), "FALSE");
        

[Description("User input lower boundary temperature if FIXBC is TRUE Blank for FIXBC FALSE or t" +
    "o use the calculated 1-D deep ground temperature.")]
[JsonProperty(PropertyName="tdeepin", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Tdeepin { get; set; } = null;
        

[Description(@"This field flags the use of a user specified heat transfer coefficient on the ground surface. This condition is used primarily for testing. For normal runs (USPHflag is FALSE) and the program calculates the heat transfer coefficient using the weather conditions.")]
[JsonProperty(PropertyName="usrhflag_is_the_ground_surface_h_specified_by_the_user_", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public GroundHeatTransfer_Slab_BoundConds_UsrhflagIsTheGroundSurfaceHSpecifiedByTheUser UsrhflagIsTheGroundSurfaceHSpecifiedByTheUser { get; set; } = (GroundHeatTransfer_Slab_BoundConds_UsrhflagIsTheGroundSurfaceHSpecifiedByTheUser)Enum.Parse(typeof(GroundHeatTransfer_Slab_BoundConds_UsrhflagIsTheGroundSurfaceHSpecifiedByTheUser), "FALSE");
        

[Description("Used only if USRHflag is TRUE and the heat transfer coefficient value is specifie" +
    "d in this field.")]
[JsonProperty(PropertyName="userh_user_specified_ground_surface_heat_transfer_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> UserhUserSpecifiedGroundSurfaceHeatTransferCoefficient { get; set; } = null;
    }
    
    public enum GroundHeatTransfer_Slab_BoundConds_EvtrIsSurfaceEvapotranspirationModeled
    {
        
        [System.Runtime.Serialization.EnumMember(Value="FALSE")]
        FALSE = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="TRUE")]
        TRUE = 1,
    }
    
    public enum GroundHeatTransfer_Slab_BoundConds_FixbcIsTheLowerBoundaryAtAFixedTemperature
    {
        
        [System.Runtime.Serialization.EnumMember(Value="FALSE")]
        FALSE = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="TRUE")]
        TRUE = 1,
    }
    
    public enum GroundHeatTransfer_Slab_BoundConds_UsrhflagIsTheGroundSurfaceHSpecifiedByTheUser
    {
        
        [System.Runtime.Serialization.EnumMember(Value="FALSE")]
        FALSE = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="TRUE")]
        TRUE = 1,
    }
    
    [Description(@"Object provides information about the building and its operating conditions Monthly Average Temperature SetPoint fields specify the average indoor building set point temperatures for each month of the year. These fields are useful for simulating a building that is not temperature controlled for some of the year. In such a case, the average indoor set point temperatures can be obtained by first running the model in EnergyPlus with an insulated floor boundary condition, and then using the resulting monthly average zone temperatures in these fields.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Slab_BldgProps
    {
        

[Description(@"This field specifies the number of years to iterate. Either the ground heat transfer calculations come to an an annual steady periodic condition by converging to a tolerance (see ConvTol field) or it runs for this number of years. A ten year maximum is usually sufficient.")]
[JsonProperty(PropertyName="iyrs_number_of_years_to_iterate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> IyrsNumberOfYearsToIterate { get; set; } = Double.Parse("10", CultureInfo.InvariantCulture);
        

[Description("Use only the value 0 here. Only a rectangular shape is implemented.")]
[JsonProperty(PropertyName="shape_slab_shape", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ShapeSlabShape { get; set; } = null;
        

[Description("This field supplies the building height. This is used to calculate the building s" +
    "hadowing on the ground. typical value= 0-20")]
[JsonProperty(PropertyName="hbldg_building_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HbldgBuildingHeight { get; set; } = null;
        

[Description("see memo on object for more information")]
[JsonProperty(PropertyName="tin1_january_indoor_average_temperature_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Tin1JanuaryIndoorAverageTemperatureSetpoint { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[Description("see memo on object for more information")]
[JsonProperty(PropertyName="tin2_february_indoor_average_temperature_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Tin2FebruaryIndoorAverageTemperatureSetpoint { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[Description("see memo on object for more information")]
[JsonProperty(PropertyName="tin3_march_indoor_average_temperature_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Tin3MarchIndoorAverageTemperatureSetpoint { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[Description("see memo on object for more information")]
[JsonProperty(PropertyName="tin4_april_indoor_average_temperature_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Tin4AprilIndoorAverageTemperatureSetpoint { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[Description("see memo on object for more information")]
[JsonProperty(PropertyName="tin5_may_indoor_average_temperature_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Tin5MayIndoorAverageTemperatureSetpoint { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[Description("see memo on object for more information")]
[JsonProperty(PropertyName="tin6_june_indoor_average_temperature_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Tin6JuneIndoorAverageTemperatureSetpoint { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[Description("see memo on object for more information")]
[JsonProperty(PropertyName="tin7_july_indoor_average_temperature_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Tin7JulyIndoorAverageTemperatureSetpoint { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[Description("see memo on object for more information")]
[JsonProperty(PropertyName="tin8_august_indoor_average_temperature_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Tin8AugustIndoorAverageTemperatureSetpoint { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[Description("see memo on object for more information")]
[JsonProperty(PropertyName="tin9_september_indoor_average_temperature_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Tin9SeptemberIndoorAverageTemperatureSetpoint { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[Description("see memo on object for more information")]
[JsonProperty(PropertyName="tin10_october_indoor_average_temperature_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Tin10OctoberIndoorAverageTemperatureSetpoint { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[Description("see memo on object for more information")]
[JsonProperty(PropertyName="tin11_november_indoor_average_temperature_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Tin11NovemberIndoorAverageTemperatureSetpoint { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[Description("see memo on object for more information")]
[JsonProperty(PropertyName="tin12_december_indoor_average_temperature_setpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Tin12DecemberIndoorAverageTemperatureSetpoint { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[Description("This field permits imposing a daily sinusoidal variation in the indoor setpoint t" +
    "emperature to simulate the effect of a setback profile. The value specified is t" +
    "he amplitude of the sine wave.")]
[JsonProperty(PropertyName="tinamp_daily_indoor_sine_wave_variation_amplitude", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TinampDailyIndoorSineWaveVariationAmplitude { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This field specifies the convergence tolerance used to control the iteration. Whe" +
    "n the temperature change of all nodes is less than the convergence value, iterat" +
    "ion ceases.")]
[JsonProperty(PropertyName="convtol_convergence_tolerance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConvtolConvergenceTolerance { get; set; } = Double.Parse("0.1", CultureInfo.InvariantCulture);
    }
    
    [Description("This object supplies the information about insulation used around the slab. There" +
        " are two possible configurations: under the slab or vertical insulation around t" +
        "he slab.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Slab_Insulation
    {
        

[Description("This field provides the thermal resistance value of the under slab insulation. It" +
    " should be zero if the vertical insulation configuration is selected. typical va" +
    "lue= 0-2.0")]
[JsonProperty(PropertyName="rins_r_value_of_under_slab_insulation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RinsRValueOfUnderSlabInsulation { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This specifies the width of the perimeter strip of insulation under the slab. It " +
    "should be zero if for the vertical insulation configuration is selected. typical" +
    " value= 0-2.0")]
[JsonProperty(PropertyName="dins_width_of_strip_of_under_slab_insulation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DinsWidthOfStripOfUnderSlabInsulation { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("This field specifies the thermal resistance of the vertical insulation. It should" +
    " be zero if the under slab insulation configuration is selected. typical value= " +
    "0-3.0")]
[JsonProperty(PropertyName="rvins_r_value_of_vertical_insulation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RvinsRValueOfVerticalInsulation { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description(@"This field specifies the depth of the vertical insulation into the ground in meters. It starts at the slab upper surface and extends into the ground. It should be zero if the under slab insulation configuration is selected. only use values= .2 .4 .6 .8 1.0 1.5 2.0 2.5 3.0")]
[JsonProperty(PropertyName="zvins_depth_of_vertical_insulation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZvinsDepthOfVerticalInsulation { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Specifies if the vertical insulation configuration is being used. values: 1=yes v" +
    "ertical insulation 0=no under-slab insulation")]
[JsonProperty(PropertyName="ivins_flag_is_there_vertical_insulation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> IvinsFlagIsThereVerticalInsulation { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    [Description("Using an equivalent slab allows non-rectangular shapes to be modeled accurately. " +
        "Object uses the area - perimeter (area/perimeter) ratio to determine the size of" +
        " an equivalent rectangular slab. EnergyPlus users normally use this option.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Slab_EquivalentSlab
    {
        

[Description("Equivalent square slab is simulated,  side is 4*APRatio.")]
[JsonProperty(PropertyName="apratio_the_area_to_perimeter_ratio_for_this_slab", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ApratioTheAreaToPerimeterRatioForThisSlab { get; set; } = null;
        

[Description(@"This field specifies the thickness of the slab. The slab top surface is level with the ground surface, so this is the depth into the ground. The slab depth has a significant effect on the temperature calculation, and it is also important for the auto-grid process. The finite difference grids are set in such a way that they use the slab thickness to determine the vertical grid spacing. Autogridding will fail if the slab thickness is specified larger than 0.25 meters.")]
[JsonProperty(PropertyName="slabdepth_thickness_of_slab_on_grade", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlabdepthThicknessOfSlabOnGrade { get; set; } = Double.Parse("0.1", CultureInfo.InvariantCulture);
        

[Description("This field specifies the distance from the slab to the edge of the area that will" +
    " be modeled with the grid system. It is the basic size dimension that is used to" +
    " set the horizontal extent of the domain. 15 meters is a reasonable value.")]
[JsonProperty(PropertyName="clearance_distance_from_edge_of_slab_to_domain_edge", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ClearanceDistanceFromEdgeOfSlabToDomainEdge { get; set; } = Double.Parse("15", CultureInfo.InvariantCulture);
        

[Description("This field specifies the vertical distance from the slab to the bottom edge of th" +
    "e area that will be modeled with the grid system. 15 meters is a reasonable valu" +
    "e.")]
[JsonProperty(PropertyName="zclearance_distance_from_bottom_of_slab_to_domain_bottom", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZclearanceDistanceFromBottomOfSlabToDomainBottom { get; set; } = Double.Parse("15", CultureInfo.InvariantCulture);
    }
    
    [Description("AutoGrid only necessary when EquivalentSlab option not chosen. Not normally neede" +
        "d by EnergyPlus users. This object permits user selection of rectangular slab di" +
        "mensions. NO SLAB DIMENSIONS LESS THAN 6 m.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Slab_AutoGrid
    {
        

[Description("typical values= 6 to 60.0")]
[JsonProperty(PropertyName="slabx_x_dimension_of_the_building_slab", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlabxXDimensionOfTheBuildingSlab { get; set; } = null;
        

[Description("typical values= 6 to 60.0")]
[JsonProperty(PropertyName="slaby_y_dimension_of_the_building_slab", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlabyYDimensionOfTheBuildingSlab { get; set; } = null;
        

[JsonProperty(PropertyName="slabdepth_thickness_of_slab_on_grade", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlabdepthThicknessOfSlabOnGrade { get; set; } = Double.Parse("0.1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="clearance_distance_from_edge_of_slab_to_domain_edge", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ClearanceDistanceFromEdgeOfSlabToDomainEdge { get; set; } = Double.Parse("15", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="zclearance_distance_from_bottom_of_slab_to_domain_bottom", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZclearanceDistanceFromBottomOfSlabToDomainBottom { get; set; } = Double.Parse("15", CultureInfo.InvariantCulture);
    }
    
    [Description("Manual Grid only necessary when using manual gridding (not recommended) Used only" +
        " in special cases when previous two objects are not used. User must input comple" +
        "te gridding information.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Slab_ManualGrid
    {
        

[JsonProperty(PropertyName="nx_number_of_cells_in_the_x_direction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NxNumberOfCellsInTheXDirection { get; set; } = null;
        

[JsonProperty(PropertyName="ny_number_of_cells_in_the_y_direction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NyNumberOfCellsInTheYDirection { get; set; } = null;
        

[JsonProperty(PropertyName="nz_number_of_cells_in_the_z_direction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NzNumberOfCellsInTheZDirection { get; set; } = null;
        

[Description("typical values= 1-10")]
[JsonProperty(PropertyName="ibox_x_direction_cell_indicator_of_slab_edge", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> IboxXDirectionCellIndicatorOfSlabEdge { get; set; } = null;
        

[Description("typical values= 1-10")]
[JsonProperty(PropertyName="jbox_y_direction_cell_indicator_of_slab_edge", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> JboxYDirectionCellIndicatorOfSlabEdge { get; set; } = null;
    }
    
    [Description("This is only needed when using manual gridding (not recommended) XFACE: X Directi" +
        "on cell face coordinates: m")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Slab_XFACE
    {
    }
    
    [Description("This is only needed when using manual gridding (not recommended) YFACE: Y Directi" +
        "on cell face coordinates: m,")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Slab_YFACE
    {
    }
    
    [Description("This is only needed when using manual gridding (not recommended) ZFACE: Z Directi" +
        "on cell face coordinates: m")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Slab_ZFACE
    {
    }
    
    [Description("Specifies certain parameters that control the Basement preprocessor ground heat t" +
        "ransfer simulation.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Basement_SimParameters
    {
        

[Description("0<F<1.0, typically 0.1 (0.3 for high k soil - saturated sand is about 2.6 w/m-K)")]
[JsonProperty(PropertyName="f_multiplier_for_the_adi_solution", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FMultiplierForTheAdiSolution { get; set; } = null;
        

[Description("typically 15-30]")]
[JsonProperty(PropertyName="iyrs_maximum_number_of_yearly_iterations_", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> IyrsMaximumNumberOfYearlyIterations { get; set; } = Double.Parse("15", CultureInfo.InvariantCulture);
    }
    
    [Description("Specifies the material properties for the Basement preprocessor ground heat trans" +
        "fer simulation. Only the Foundation Wall, Floor Slab, Soil, and Gravel propertie" +
        "s are currently used.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Basement_MatlProps
    {
        

[JsonProperty(PropertyName="nmat_number_of_materials_in_this_domain", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NmatNumberOfMaterialsInThisDomain { get; set; } = null;
        

[JsonProperty(PropertyName="density_for_foundation_wall", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DensityForFoundationWall { get; set; } = Double.Parse("2243", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="density_for_floor_slab", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DensityForFloorSlab { get; set; } = Double.Parse("2243", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="density_for_ceiling", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DensityForCeiling { get; set; } = Double.Parse("311", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="density_for_soil", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DensityForSoil { get; set; } = Double.Parse("1500", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="density_for_gravel", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DensityForGravel { get; set; } = Double.Parse("2000", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="density_for_wood", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DensityForWood { get; set; } = Double.Parse("449", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="specific_heat_for_foundation_wall", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SpecificHeatForFoundationWall { get; set; } = Double.Parse("880", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="specific_heat_for_floor_slab", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SpecificHeatForFloorSlab { get; set; } = Double.Parse("880", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="specific_heat_for_ceiling", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SpecificHeatForCeiling { get; set; } = Double.Parse("1530", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="specific_heat_for_soil", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SpecificHeatForSoil { get; set; } = Double.Parse("840", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="specific_heat_for_gravel", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SpecificHeatForGravel { get; set; } = Double.Parse("720", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="specific_heat_for_wood", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SpecificHeatForWood { get; set; } = Double.Parse("1530", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="thermal_conductivity_for_foundation_wall", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivityForFoundationWall { get; set; } = Double.Parse("1.4", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="thermal_conductivity_for_floor_slab", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivityForFloorSlab { get; set; } = Double.Parse("1.4", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="thermal_conductivity_for_ceiling", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivityForCeiling { get; set; } = Double.Parse("0.09", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="thermal_conductivity_for_soil", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivityForSoil { get; set; } = Double.Parse("1.1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="thermal_conductivity_for_gravel", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivityForGravel { get; set; } = Double.Parse("1.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="thermal_conductivity_for_wood", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivityForWood { get; set; } = Double.Parse("0.12", CultureInfo.InvariantCulture);
    }
    
    [Description("Describes the insulation used on an exterior basement wall for the Basement prepr" +
        "ocessor ground heat transfer simulation.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Basement_Insulation
    {
        

[JsonProperty(PropertyName="rext_r_value_of_any_exterior_insulation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RextRValueOfAnyExteriorInsulation { get; set; } = null;
        

[Description("True for full insulation False for insulation half way down side wall from grade " +
    "line")]
[JsonProperty(PropertyName="insfull_flag_is_the_wall_fully_insulated_", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public GroundHeatTransfer_Basement_Insulation_InsfullFlagIsTheWallFullyInsulated InsfullFlagIsTheWallFullyInsulated { get; set; } = (GroundHeatTransfer_Basement_Insulation_InsfullFlagIsTheWallFullyInsulated)Enum.Parse(typeof(GroundHeatTransfer_Basement_Insulation_InsfullFlagIsTheWallFullyInsulated), "FALSE");
    }
    
    public enum GroundHeatTransfer_Basement_Insulation_InsfullFlagIsTheWallFullyInsulated
    {
        
        [System.Runtime.Serialization.EnumMember(Value="FALSE")]
        FALSE = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="TRUE")]
        TRUE = 1,
    }
    
    [Description("Specifies the soil surface properties for the Basement preprocessor ground heat t" +
        "ransfer simulation.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Basement_SurfaceProps
    {
        

[JsonProperty(PropertyName="albedo_surface_albedo_for_no_snow_conditions", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AlbedoSurfaceAlbedoForNoSnowConditions { get; set; } = Double.Parse("0.16", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="albedo_surface_albedo_for_snow_conditions", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AlbedoSurfaceAlbedoForSnowConditions { get; set; } = Double.Parse("0.4", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="epsln_surface_emissivity_no_snow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EpslnSurfaceEmissivityNoSnow { get; set; } = Double.Parse("0.94", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="epsln_surface_emissivity_with_snow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EpslnSurfaceEmissivityWithSnow { get; set; } = Double.Parse("0.86", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="veght_surface_roughness_no_snow_conditions", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VeghtSurfaceRoughnessNoSnowConditions { get; set; } = Double.Parse("6", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="veght_surface_roughness_snow_conditions", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VeghtSurfaceRoughnessSnowConditions { get; set; } = Double.Parse("0.25", CultureInfo.InvariantCulture);
        

[Description("Typically, PET is False")]
[JsonProperty(PropertyName="pet_flag_potential_evapotranspiration_on_", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public GroundHeatTransfer_Basement_SurfaceProps_PetFlagPotentialEvapotranspirationOn PetFlagPotentialEvapotranspirationOn { get; set; } = (GroundHeatTransfer_Basement_SurfaceProps_PetFlagPotentialEvapotranspirationOn)Enum.Parse(typeof(GroundHeatTransfer_Basement_SurfaceProps_PetFlagPotentialEvapotranspirationOn), "FALSE");
    }
    
    public enum GroundHeatTransfer_Basement_SurfaceProps_PetFlagPotentialEvapotranspirationOn
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FALSE")]
        FALSE = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TRUE")]
        TRUE = 2,
    }
    
    [Description("Specifies the surface and gravel thicknesses used for the Basement preprocessor g" +
        "round heat transfer simulation.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Basement_BldgData
    {
        

[JsonProperty(PropertyName="dwall_wall_thickness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DwallWallThickness { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="dslab_floor_slab_thickness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DslabFloorSlabThickness { get; set; } = Double.Parse("0.1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="dgravxy_width_of_gravel_pit_beside_basement_wall", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DgravxyWidthOfGravelPitBesideBasementWall { get; set; } = Double.Parse("0.3", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="dgravzn_gravel_depth_extending_above_the_floor_slab", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DgravznGravelDepthExtendingAboveTheFloorSlab { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="dgravzp_gravel_depth_below_the_floor_slab", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DgravzpGravelDepthBelowTheFloorSlab { get; set; } = Double.Parse("0.1", CultureInfo.InvariantCulture);
    }
    
    [Description("Provides the information needed to simulate the inside boundary conditions for th" +
        "e Basement preprocessor ground heat transfer simulation.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Basement_Interior
    {
        

[Description("for EnergyPlus this should be TRUE")]
[JsonProperty(PropertyName="cond_flag_is_the_basement_conditioned_", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public GroundHeatTransfer_Basement_Interior_CondFlagIsTheBasementConditioned CondFlagIsTheBasementConditioned { get; set; } = (GroundHeatTransfer_Basement_Interior_CondFlagIsTheBasementConditioned)Enum.Parse(typeof(GroundHeatTransfer_Basement_Interior_CondFlagIsTheBasementConditioned), "TRUE");
        

[JsonProperty(PropertyName="hin_downward_convection_only_heat_transfer_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HinDownwardConvectionOnlyHeatTransferCoefficient { get; set; } = Double.Parse("0.92", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hin_upward_convection_only_heat_transfer_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HinUpwardConvectionOnlyHeatTransferCoefficient { get; set; } = Double.Parse("4.04", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hin_horizontal_convection_only_heat_transfer_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HinHorizontalConvectionOnlyHeatTransferCoefficient { get; set; } = Double.Parse("3.08", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hin_downward_combined_convection_and_radiation_heat_transfer_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HinDownwardCombinedConvectionAndRadiationHeatTransferCoefficient { get; set; } = Double.Parse("6.13", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hin_upward_combined_convection_and_radiation_heat_transfer_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HinUpwardCombinedConvectionAndRadiationHeatTransferCoefficient { get; set; } = Double.Parse("9.26", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hin_horizontal_combined_convection_and_radiation_heat_transfer_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HinHorizontalCombinedConvectionAndRadiationHeatTransferCoefficient { get; set; } = Double.Parse("8.29", CultureInfo.InvariantCulture);
    }
    
    public enum GroundHeatTransfer_Basement_Interior_CondFlagIsTheBasementConditioned
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FALSE")]
        FALSE = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="TRUE")]
        TRUE = 2,
    }
    
    [Description("ComBldg contains the monthly average temperatures (C) and possibility of daily va" +
        "riation amplitude")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Basement_ComBldg
    {
        

[JsonProperty(PropertyName="january_average_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> JanuaryAverageTemperature { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="february_average_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FebruaryAverageTemperature { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="march_average_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MarchAverageTemperature { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="april_average_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AprilAverageTemperature { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="may_average_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MayAverageTemperature { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="june_average_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> JuneAverageTemperature { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="july_average_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> JulyAverageTemperature { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="august_average_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AugustAverageTemperature { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="september_average_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SeptemberAverageTemperature { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="october_average_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OctoberAverageTemperature { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="november_average_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NovemberAverageTemperature { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="december_average_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DecemberAverageTemperature { get; set; } = Double.Parse("22", CultureInfo.InvariantCulture);
        

[Description("(Normally zero, just for checking)")]
[JsonProperty(PropertyName="daily_variation_sine_wave_amplitude", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DailyVariationSineWaveAmplitude { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    [Description("Using an equivalent slab allows non-rectangular shapes to be modeled accurately. " +
        "The simulation default should be EquivSizing=True")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Basement_EquivSlab
    {
        

[JsonProperty(PropertyName="apratio_the_area_to_perimeter_ratio_for_this_slab", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ApratioTheAreaToPerimeterRatioForThisSlab { get; set; } = null;
        

[Description("Will the dimensions of an equivalent slab be calculated (TRUE) or will the dimens" +
    "ions be input directly? (FALSE)] Only advanced special simulations should use FA" +
    "LSE.")]
[JsonProperty(PropertyName="equivsizing_flag", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public GroundHeatTransfer_Basement_EquivSlab_EquivsizingFlag EquivsizingFlag { get; set; } = (GroundHeatTransfer_Basement_EquivSlab_EquivsizingFlag)Enum.Parse(typeof(GroundHeatTransfer_Basement_EquivSlab_EquivsizingFlag), "FALSE");
    }
    
    public enum GroundHeatTransfer_Basement_EquivSlab_EquivsizingFlag
    {
        
        [System.Runtime.Serialization.EnumMember(Value="FALSE")]
        FALSE = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="TRUE")]
        TRUE = 1,
    }
    
    [Description("EquivAutoGrid necessary when EquivSizing=TRUE, TRUE is is the normal case.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Basement_EquivAutoGrid
    {
        

[JsonProperty(PropertyName="clearance_distance_from_outside_of_wall_to_edge_of_3_d_ground_domain", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ClearanceDistanceFromOutsideOfWallToEdgeOf3DGroundDomain { get; set; } = Double.Parse("15", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="slabdepth_thickness_of_the_floor_slab", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlabdepthThicknessOfTheFloorSlab { get; set; } = Double.Parse("0.1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="basedepth_depth_of_the_basement_wall_below_grade", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BasedepthDepthOfTheBasementWallBelowGrade { get; set; } = Double.Parse("2", CultureInfo.InvariantCulture);
    }
    
    [Description("AutoGrid only necessary when EquivSizing is false If the modeled building is not " +
        "a rectangle or square, Equivalent sizing MUST be used to get accurate results")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Basement_AutoGrid
    {
        

[JsonProperty(PropertyName="clearance_distance_from_outside_of_wall_to_edge_", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ClearanceDistanceFromOutsideOfWallToEdge { get; set; } = Double.Parse("15", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="slabx_x_dimension_of_the_building_slab", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlabxXDimensionOfTheBuildingSlab { get; set; } = null;
        

[JsonProperty(PropertyName="slaby_y_dimension_of_the_building_slab", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlabyYDimensionOfTheBuildingSlab { get; set; } = null;
        

[JsonProperty(PropertyName="concagheight_height_of_the_foundation_wall_above_grade", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConcagheightHeightOfTheFoundationWallAboveGrade { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="slabdepth_thickness_of_the_floor_slab", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlabdepthThicknessOfTheFloorSlab { get; set; } = Double.Parse("0.1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="basedepth_depth_of_the_basement_wall_below_grade", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BasedepthDepthOfTheBasementWallBelowGrade { get; set; } = Double.Parse("2", CultureInfo.InvariantCulture);
    }
    
    [Description("Manual Grid only necessary using manual gridding (not recommended)")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Basement_ManualGrid
    {
        

[JsonProperty(PropertyName="nx_number_of_cells_in_the_x_direction_20_", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NxNumberOfCellsInTheXDirection20 { get; set; } = null;
        

[JsonProperty(PropertyName="ny_number_of_cells_in_the_y_direction_20_", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NyNumberOfCellsInTheYDirection20 { get; set; } = null;
        

[JsonProperty(PropertyName="nzag_number_of_cells_in_the_z_direction_above_grade_4_always_", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NzagNumberOfCellsInTheZDirectionAboveGrade4Always { get; set; } = null;
        

[JsonProperty(PropertyName="nzbg_number_of_cells_in_z_direction_below_grade_10_35_", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NzbgNumberOfCellsInZDirectionBelowGrade1035 { get; set; } = null;
        

[JsonProperty(PropertyName="ibase_x_direction_cell_indicator_of_slab_edge_5_20_", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> IbaseXDirectionCellIndicatorOfSlabEdge520 { get; set; } = null;
        

[JsonProperty(PropertyName="jbase_y_direction_cell_indicator_of_slab_edge_5_20_", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> JbaseYDirectionCellIndicatorOfSlabEdge520 { get; set; } = null;
        

[JsonProperty(PropertyName="kbase_z_direction_cell_indicator_of_the_top_of_the_floor_slab_5_20_", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> KbaseZDirectionCellIndicatorOfTheTopOfTheFloorSlab520 { get; set; } = null;
    }
    
    [Description("This is only needed when using manual gridding (not recommended) XFACE: X Directi" +
        "on cell face coordinates: m")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Basement_XFACE
    {
    }
    
    [Description("This is only needed when using manual gridding (not recommended) YFACE: Y Directi" +
        "on cell face coordinates: m")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Basement_YFACE
    {
    }
    
    [Description("This is only needed when using manual gridding (not recommended) ZFACE: Z Directi" +
        "on cell face coordinates: m")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class GroundHeatTransfer_Basement_ZFACE
    {
    }
}
