namespace EnergyPlus.SurfaceConstructionElements
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
    using EnergyPlus.SimulationParameters;
    using EnergyPlus.SolarCollectors;
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
    
    
    [Description("Regular materials described with full set of thermal properties")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Material
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="roughness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Material_Roughness Roughness { get; set; } = (Material_Roughness)Enum.Parse(typeof(Material_Roughness), "MediumRough");
        

[JsonProperty(PropertyName="thickness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Thickness { get; set; } = null;
        

[JsonProperty(PropertyName="conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Conductivity { get; set; } = null;
        

[JsonProperty(PropertyName="density", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Density { get; set; } = null;
        

[JsonProperty(PropertyName="specific_heat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SpecificHeat { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_absorptance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalAbsorptance { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="solar_absorptance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SolarAbsorptance { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="visible_absorptance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VisibleAbsorptance { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
    }
    
    public enum Material_Roughness
    {
        
        [System.Runtime.Serialization.EnumMember(Value="MediumRough")]
        MediumRough = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MediumSmooth")]
        MediumSmooth = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Rough")]
        Rough = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Smooth")]
        Smooth = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="VeryRough")]
        VeryRough = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="VerySmooth")]
        VerySmooth = 5,
    }
    
    [Description("Regular materials properties described whose principal description is R (Thermal " +
        "Resistance)")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Material_NoMass
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="roughness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Material_NoMass_Roughness Roughness { get; set; } = (Material_NoMass_Roughness)Enum.Parse(typeof(Material_NoMass_Roughness), "MediumRough");
        

[JsonProperty(PropertyName="thermal_resistance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalResistance { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_absorptance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalAbsorptance { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="solar_absorptance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SolarAbsorptance { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="visible_absorptance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VisibleAbsorptance { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
    }
    
    public enum Material_NoMass_Roughness
    {
        
        [System.Runtime.Serialization.EnumMember(Value="MediumRough")]
        MediumRough = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MediumSmooth")]
        MediumSmooth = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Rough")]
        Rough = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Smooth")]
        Smooth = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="VeryRough")]
        VeryRough = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="VerySmooth")]
        VerySmooth = 5,
    }
    
    [Description(@"Special infrared transparent material. Similar to a Material:Nomass with low thermal resistance. High absorptance in both wavelengths. Area will be doubled internally to make internal radiant exchange accurate. Should be only material in single layer surface construction. All thermal properties are set internally. User needs only to supply name. Cannot be used with ConductionFiniteDifference solution algorithms")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Material_InfraredTransparent
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
    }
    
    [Description("Air Space in Opaque Construction")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Material_AirGap
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="thermal_resistance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalResistance { get; set; } = null;
    }
    
    [Description(@"EcoRoof model, plant layer plus soil layer Implemented by Portland State University (Sailor et al., January, 2007) only one material must be referenced per simulation though the same EcoRoof material could be used in multiple constructions. New moisture redistribution scheme (2010) requires higher number of timesteps per hour (minimum 12 recommended).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Material_RoofVegetation
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("The ecoroof module is designed for short plants and shrubs.")]
[JsonProperty(PropertyName="height_of_plants", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeightOfPlants { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[Description("Entire surface is assumed covered, so decrease LAI accordingly.")]
[JsonProperty(PropertyName="leaf_area_index", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LeafAreaIndex { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Leaf reflectivity (albedo) is typically 0.18-0.25")]
[JsonProperty(PropertyName="leaf_reflectivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LeafReflectivity { get; set; } = Double.Parse("0.22", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="leaf_emissivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LeafEmissivity { get; set; } = Double.Parse("0.95", CultureInfo.InvariantCulture);
        

[Description("This depends upon plant type")]
[JsonProperty(PropertyName="minimum_stomatal_resistance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumStomatalResistance { get; set; } = Double.Parse("180", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="soil_layer_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SoilLayerName { get; set; } = "Green Roof Soil";
        

[JsonProperty(PropertyName="roughness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Material_RoofVegetation_Roughness Roughness { get; set; } = (Material_RoofVegetation_Roughness)Enum.Parse(typeof(Material_RoofVegetation_Roughness), "MediumRough");
        

[Description("thickness of the soil layer of the EcoRoof Soil depths of 0.15m (6in) and 0.30m (" +
    "12in) are common.")]
[JsonProperty(PropertyName="thickness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Thickness { get; set; } = Double.Parse("0.1", CultureInfo.InvariantCulture);
        

[Description("Thermal conductivity of dry soil. Typical ecoroof soils range from 0.3 to 0.5")]
[JsonProperty(PropertyName="conductivity_of_dry_soil", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConductivityOfDrySoil { get; set; } = Double.Parse("0.35", CultureInfo.InvariantCulture);
        

[Description("Density of dry soil (the code modifies this as the soil becomes moist) Typical ec" +
    "oroof soils range from 400 to 1000 (dry to wet)")]
[JsonProperty(PropertyName="density_of_dry_soil", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DensityOfDrySoil { get; set; } = Double.Parse("1100", CultureInfo.InvariantCulture);
        

[Description("Specific heat of dry soil")]
[JsonProperty(PropertyName="specific_heat_of_dry_soil", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SpecificHeatOfDrySoil { get; set; } = Double.Parse("1200", CultureInfo.InvariantCulture);
        

[Description("Soil emissivity is typically in range of 0.90 to 0.98")]
[JsonProperty(PropertyName="thermal_absorptance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalAbsorptance { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[Description("Solar absorptance of dry soil (1-albedo) is typically 0.60 to 0.85 corresponding " +
    "to a dry albedo of 0.15 to 0.40")]
[JsonProperty(PropertyName="solar_absorptance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SolarAbsorptance { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="visible_absorptance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VisibleAbsorptance { get; set; } = Double.Parse("0.75", CultureInfo.InvariantCulture);
        

[Description("Maximum moisture content is typically less than 0.5")]
[JsonProperty(PropertyName="saturation_volumetric_moisture_content_of_the_soil_layer", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SaturationVolumetricMoistureContentOfTheSoilLayer { get; set; } = Double.Parse("0.3", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="residual_volumetric_moisture_content_of_the_soil_layer", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ResidualVolumetricMoistureContentOfTheSoilLayer { get; set; } = Double.Parse("0.01", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="initial_volumetric_moisture_content_of_the_soil_layer", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InitialVolumetricMoistureContentOfTheSoilLayer { get; set; } = Double.Parse("0.1", CultureInfo.InvariantCulture);
        

[Description("Advanced calculation requires increased number of timesteps (recommended >20).")]
[JsonProperty(PropertyName="moisture_diffusion_calculation_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Material_RoofVegetation_MoistureDiffusionCalculationMethod MoistureDiffusionCalculationMethod { get; set; } = (Material_RoofVegetation_MoistureDiffusionCalculationMethod)Enum.Parse(typeof(Material_RoofVegetation_MoistureDiffusionCalculationMethod), "Advanced");
    }
    
    public enum Material_RoofVegetation_Roughness
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MediumRough")]
        MediumRough = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="MediumSmooth")]
        MediumSmooth = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Rough")]
        Rough = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Smooth")]
        Smooth = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="VeryRough")]
        VeryRough = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="VerySmooth")]
        VerySmooth = 6,
    }
    
    public enum Material_RoofVegetation_MoistureDiffusionCalculationMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Advanced")]
        Advanced = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Simple")]
        Simple = 2,
    }
    
    [Description("Alternate method of describing windows This window material object is used to def" +
        "ine an entire glazing system using simple performance parameters.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowMaterial_SimpleGlazingSystem
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Enter U-Factor including film coefficients Note that the effective upper limit fo" +
    "r U-factor is 5.8 W/m2-K")]
[JsonProperty(PropertyName="u_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> UFactor { get; set; } = null;
        

[Description("SHGC at Normal Incidence")]
[JsonProperty(PropertyName="solar_heat_gain_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SolarHeatGainCoefficient { get; set; } = null;
        

[Description("VT at Normal Incidence optional")]
[JsonProperty(PropertyName="visible_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VisibleTransmittance { get; set; } = null;
    }
    
    [Description("Glass material properties for Windows or Glass Doors Transmittance/Reflectance in" +
        "put method.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowMaterial_Glazing
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="optical_data_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowMaterial_Glazing_OpticalDataType OpticalDataType { get; set; } = (WindowMaterial_Glazing_OpticalDataType)Enum.Parse(typeof(WindowMaterial_Glazing_OpticalDataType), "BSDF");
        

[Description("Used only when Optical Data Type = Spectral")]
[JsonProperty(PropertyName="window_glass_spectral_data_set_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WindowGlassSpectralDataSetName { get; set; } = "";
        

[JsonProperty(PropertyName="thickness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Thickness { get; set; } = null;
        

[Description("Used only when Optical Data Type = SpectralAverage")]
[JsonProperty(PropertyName="solar_transmittance_at_normal_incidence", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SolarTransmittanceAtNormalIncidence { get; set; } = null;
        

[Description("Used only when Optical Data Type = SpectralAverage Front Side is side closest to " +
    "outdoor air")]
[JsonProperty(PropertyName="front_side_solar_reflectance_at_normal_incidence", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideSolarReflectanceAtNormalIncidence { get; set; } = null;
        

[Description("Used only when Optical Data Type = SpectralAverage Back Side is side closest to z" +
    "one air")]
[JsonProperty(PropertyName="back_side_solar_reflectance_at_normal_incidence", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideSolarReflectanceAtNormalIncidence { get; set; } = null;
        

[Description("Used only when Optical Data Type = SpectralAverage")]
[JsonProperty(PropertyName="visible_transmittance_at_normal_incidence", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VisibleTransmittanceAtNormalIncidence { get; set; } = null;
        

[Description("Used only when Optical Data Type = SpectralAverage")]
[JsonProperty(PropertyName="front_side_visible_reflectance_at_normal_incidence", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideVisibleReflectanceAtNormalIncidence { get; set; } = null;
        

[Description("Used only when Optical Data Type = SpectralAverage")]
[JsonProperty(PropertyName="back_side_visible_reflectance_at_normal_incidence", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideVisibleReflectanceAtNormalIncidence { get; set; } = null;
        

[JsonProperty(PropertyName="infrared_transmittance_at_normal_incidence", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InfraredTransmittanceAtNormalIncidence { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="front_side_infrared_hemispherical_emissivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideInfraredHemisphericalEmissivity { get; set; } = Double.Parse("0.84", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="back_side_infrared_hemispherical_emissivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideInfraredHemisphericalEmissivity { get; set; } = Double.Parse("0.84", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Conductivity { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="dirt_correction_factor_for_solar_and_visible_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DirtCorrectionFactorForSolarAndVisibleTransmittance { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="solar_diffusing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes SolarDiffusing { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
        

[Description("coefficient used for deflection calculations. Used only with complex fenestration" +
    " when deflection model is set to TemperatureAndPressureInput")]
[JsonProperty(PropertyName="young_s_modulus", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> YoungSModulus { get; set; } = Double.Parse("72000000000", CultureInfo.InvariantCulture);
        

[Description("coefficient used for deflection calculations. Used only with complex fenestration" +
    " when deflection model is set to TemperatureAndPressureInput")]
[JsonProperty(PropertyName="poisson_s_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PoissonSRatio { get; set; } = Double.Parse("0.22", CultureInfo.InvariantCulture);
        

[Description("Used only when Optical Data Type = SpectralAndAngle")]
[JsonProperty(PropertyName="window_glass_spectral_and_incident_angle_transmittance_data_set_table_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WindowGlassSpectralAndIncidentAngleTransmittanceDataSetTableName { get; set; } = "";
        

[Description("Used only when Optical Data Type = SpectralAndAngle")]
[JsonProperty(PropertyName="window_glass_spectral_and_incident_angle_front_reflectance_data_set_table_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WindowGlassSpectralAndIncidentAngleFrontReflectanceDataSetTableName { get; set; } = "";
        

[Description("Used only when Optical Data Type = SpectralAndAngle")]
[JsonProperty(PropertyName="window_glass_spectral_and_incident_angle_back_reflectance_data_set_table_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WindowGlassSpectralAndIncidentAngleBackReflectanceDataSetTableName { get; set; } = "";
    }
    
    public enum WindowMaterial_Glazing_OpticalDataType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="BSDF")]
        BSDF = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Spectral")]
        Spectral = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SpectralAndAngle")]
        SpectralAndAngle = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="SpectralAverage")]
        SpectralAverage = 3,
    }
    
    [Description("thermochromic glass at different temperatures")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowMaterial_GlazingGroup_Thermochromic
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="temperature_data", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_GlazingGroup_Thermochromic_TemperatureData_Item> TemperatureData { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowMaterial_GlazingGroup_Thermochromic_TemperatureData_Item
    {
        

[JsonProperty(PropertyName="optical_data_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OpticalDataTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="window_material_glazing_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WindowMaterialGlazingName { get; set; } = "";
    }
    
    [Description("Glass material properties for Windows or Glass Doors Index of Refraction/Extincti" +
        "on Coefficient input method Not to be used for coated glass")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowMaterial_Glazing_RefractionExtinctionMethod
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="thickness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Thickness { get; set; } = null;
        

[JsonProperty(PropertyName="solar_index_of_refraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SolarIndexOfRefraction { get; set; } = null;
        

[JsonProperty(PropertyName="solar_extinction_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SolarExtinctionCoefficient { get; set; } = null;
        

[JsonProperty(PropertyName="visible_index_of_refraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VisibleIndexOfRefraction { get; set; } = null;
        

[JsonProperty(PropertyName="visible_extinction_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VisibleExtinctionCoefficient { get; set; } = null;
        

[JsonProperty(PropertyName="infrared_transmittance_at_normal_incidence", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InfraredTransmittanceAtNormalIncidence { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Emissivity of front and back side assumed equal")]
[JsonProperty(PropertyName="infrared_hemispherical_emissivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InfraredHemisphericalEmissivity { get; set; } = Double.Parse("0.84", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Conductivity { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="dirt_correction_factor_for_solar_and_visible_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DirtCorrectionFactorForSolarAndVisibleTransmittance { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="solar_diffusing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public EmptyNoYes SolarDiffusing { get; set; } = (EmptyNoYes)Enum.Parse(typeof(EmptyNoYes), "No");
    }
    
    [Description("Gas material properties that are used in Windows or Glass Doors")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowMaterial_Gas
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="gas_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowMaterial_Gas_GasType GasType { get; set; } = (WindowMaterial_Gas_GasType)Enum.Parse(typeof(WindowMaterial_Gas_GasType), "Air");
        

[JsonProperty(PropertyName="thickness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Thickness { get; set; } = null;
        

[Description("Used only if Gas Type = Custom")]
[JsonProperty(PropertyName="conductivity_coefficient_a", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConductivityCoefficientA { get; set; } = null;
        

[Description("Used only if Gas Type = Custom")]
[JsonProperty(PropertyName="conductivity_coefficient_b", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConductivityCoefficientB { get; set; } = null;
        

[Description("Used only if Gas Type = Custom")]
[JsonProperty(PropertyName="conductivity_coefficient_c", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConductivityCoefficientC { get; set; } = null;
        

[Description("Used only if Gas Type = Custom")]
[JsonProperty(PropertyName="viscosity_coefficient_a", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ViscosityCoefficientA { get; set; } = null;
        

[Description("Used only if Gas Type = Custom")]
[JsonProperty(PropertyName="viscosity_coefficient_b", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ViscosityCoefficientB { get; set; } = null;
        

[Description("Used only if Gas Type = Custom")]
[JsonProperty(PropertyName="viscosity_coefficient_c", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ViscosityCoefficientC { get; set; } = null;
        

[Description("Used only if Gas Type = Custom")]
[JsonProperty(PropertyName="specific_heat_coefficient_a", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SpecificHeatCoefficientA { get; set; } = null;
        

[Description("Used only if Gas Type = Custom")]
[JsonProperty(PropertyName="specific_heat_coefficient_b", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SpecificHeatCoefficientB { get; set; } = null;
        

[Description("Used only if Gas Type = Custom")]
[JsonProperty(PropertyName="specific_heat_coefficient_c", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SpecificHeatCoefficientC { get; set; } = null;
        

[Description("Used only if Gas Type = Custom")]
[JsonProperty(PropertyName="molecular_weight", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MolecularWeight { get; set; } = null;
        

[Description("Used only if Gas Type = Custom")]
[JsonProperty(PropertyName="specific_heat_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SpecificHeatRatio { get; set; } = null;
    }
    
    public enum WindowMaterial_Gas_GasType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Air")]
        Air = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Argon")]
        Argon = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Custom")]
        Custom = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Krypton")]
        Krypton = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Xenon")]
        Xenon = 4,
    }
    
    [Description("used to define pillar geometry for support pillars")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowGap_SupportPillar
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="spacing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Spacing { get; set; } = Double.Parse("0.04", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="radius", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Radius { get; set; } = Double.Parse("0.0004", CultureInfo.InvariantCulture);
    }
    
    [Description("Used to enter data describing deflection state of the gap. It is referenced from " +
        "WindowMaterial:Gap object only and it is used only when deflection model is set " +
        "to MeasuredDeflection, otherwise it is ignored.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowGap_DeflectionState
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("If left blank will be considered that gap has no deflection.")]
[JsonProperty(PropertyName="deflected_thickness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DeflectedThickness { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="initial_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InitialTemperature { get; set; } = Double.Parse("25", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="initial_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InitialPressure { get; set; } = Double.Parse("101325", CultureInfo.InvariantCulture);
    }
    
    [Description("Gas mixtures that are used in Windows or Glass Doors")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowMaterial_GasMixture
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="thickness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Thickness { get; set; } = null;
        

[JsonProperty(PropertyName="number_of_gases_in_mixture", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfGasesInMixture { get; set; } = null;
        

[JsonProperty(PropertyName="gas_1_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowMaterial_GasMixture_Gas1Type Gas1Type { get; set; } = (WindowMaterial_GasMixture_Gas1Type)Enum.Parse(typeof(WindowMaterial_GasMixture_Gas1Type), "Air");
        

[JsonProperty(PropertyName="gas_1_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Gas1Fraction { get; set; } = null;
        

[JsonProperty(PropertyName="gas_2_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowMaterial_GasMixture_Gas2Type Gas2Type { get; set; } = (WindowMaterial_GasMixture_Gas2Type)Enum.Parse(typeof(WindowMaterial_GasMixture_Gas2Type), "Air");
        

[JsonProperty(PropertyName="gas_2_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Gas2Fraction { get; set; } = null;
        

[JsonProperty(PropertyName="gas_3_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowMaterial_GasMixture_Gas3Type Gas3Type { get; set; } = (WindowMaterial_GasMixture_Gas3Type)Enum.Parse(typeof(WindowMaterial_GasMixture_Gas3Type), "Air");
        

[JsonProperty(PropertyName="gas_3_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Gas3Fraction { get; set; } = null;
        

[JsonProperty(PropertyName="gas_4_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowMaterial_GasMixture_Gas4Type Gas4Type { get; set; } = (WindowMaterial_GasMixture_Gas4Type)Enum.Parse(typeof(WindowMaterial_GasMixture_Gas4Type), "Air");
        

[JsonProperty(PropertyName="gas_4_fraction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Gas4Fraction { get; set; } = null;
    }
    
    public enum WindowMaterial_GasMixture_Gas1Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Air")]
        Air = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Argon")]
        Argon = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Krypton")]
        Krypton = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Xenon")]
        Xenon = 3,
    }
    
    public enum WindowMaterial_GasMixture_Gas2Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Air")]
        Air = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Argon")]
        Argon = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Krypton")]
        Krypton = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Xenon")]
        Xenon = 3,
    }
    
    public enum WindowMaterial_GasMixture_Gas3Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Air")]
        Air = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Argon")]
        Argon = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Krypton")]
        Krypton = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Xenon")]
        Xenon = 3,
    }
    
    public enum WindowMaterial_GasMixture_Gas4Type
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Air")]
        Air = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Argon")]
        Argon = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Krypton")]
        Krypton = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Xenon")]
        Xenon = 3,
    }
    
    [Description(@"Used to define the gap between two layers in a complex fenestration system, where the Construction:ComplexFenestrationState object is used. It is referenced as a layer in the Construction:ComplexFenestrationState object. It cannot be referenced as a layer from the Construction object.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowMaterial_Gap
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="thickness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Thickness { get; set; } = null;
        

[Description("This field should reference only WindowMaterial:Gas or WindowMaterial:GasMixture " +
    "objects")]
[JsonProperty(PropertyName="gas_or_gas_mixture_", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string GasOrGasMixture { get; set; } = "";
        

[JsonProperty(PropertyName="pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Pressure { get; set; } = Double.Parse("101325", CultureInfo.InvariantCulture);
        

[Description("If left blank, it will be considered that gap is not deflected")]
[JsonProperty(PropertyName="deflection_state", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DeflectionState { get; set; } = "";
        

[Description("If left blank, it will be considered that gap does not have support pillars")]
[JsonProperty(PropertyName="support_pillar", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SupportPillar { get; set; } = "";
    }
    
    [Description(@"Specifies the properties of window shade materials. Reflectance and emissivity properties are assumed to be the same on both sides of the shade. Shades are considered to be perfect diffusers (all transmitted and reflected radiation is hemispherically-diffuse) independent of angle of incidence.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowMaterial_Shade
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Assumed independent of incidence angle")]
[JsonProperty(PropertyName="solar_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SolarTransmittance { get; set; } = null;
        

[Description("Assumed same for both sides Assumed independent of incidence angle")]
[JsonProperty(PropertyName="solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SolarReflectance { get; set; } = null;
        

[Description("Assumed independent of incidence angle")]
[JsonProperty(PropertyName="visible_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VisibleTransmittance { get; set; } = null;
        

[Description("Assumed same for both sides Assumed independent of incidence angle")]
[JsonProperty(PropertyName="visible_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VisibleReflectance { get; set; } = null;
        

[JsonProperty(PropertyName="infrared_hemispherical_emissivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InfraredHemisphericalEmissivity { get; set; } = null;
        

[JsonProperty(PropertyName="infrared_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InfraredTransmittance { get; set; } = null;
        

[JsonProperty(PropertyName="thickness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Thickness { get; set; } = null;
        

[JsonProperty(PropertyName="conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Conductivity { get; set; } = null;
        

[JsonProperty(PropertyName="shade_to_glass_distance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ShadeToGlassDistance { get; set; } = Double.Parse("0.05", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="top_opening_multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TopOpeningMultiplier { get; set; } = Double.Parse("0.5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="bottom_opening_multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BottomOpeningMultiplier { get; set; } = Double.Parse("0.5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="left_side_opening_multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LeftSideOpeningMultiplier { get; set; } = Double.Parse("0.5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="right_side_opening_multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RightSideOpeningMultiplier { get; set; } = Double.Parse("0.5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="airflow_permeability", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AirflowPermeability { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    [Description("Complex window shading layer thermal properties")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowMaterial_ComplexShade
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="layer_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowMaterial_ComplexShade_LayerType LayerType { get; set; } = (WindowMaterial_ComplexShade_LayerType)Enum.Parse(typeof(WindowMaterial_ComplexShade_LayerType), "OtherShadingType");
        

[JsonProperty(PropertyName="thickness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Thickness { get; set; } = Double.Parse("0.002", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Conductivity { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="ir_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> IrTransmittance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="front_emissivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontEmissivity { get; set; } = Double.Parse("0.84", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="back_emissivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackEmissivity { get; set; } = Double.Parse("0.84", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="top_opening_multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TopOpeningMultiplier { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="bottom_opening_multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BottomOpeningMultiplier { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="left_side_opening_multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LeftSideOpeningMultiplier { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="right_side_opening_multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RightSideOpeningMultiplier { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="front_opening_multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontOpeningMultiplier { get; set; } = Double.Parse("0.05", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="slat_width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlatWidth { get; set; } = Double.Parse("0.016", CultureInfo.InvariantCulture);
        

[Description("Distance between adjacent slat faces")]
[JsonProperty(PropertyName="slat_spacing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlatSpacing { get; set; } = Double.Parse("0.012", CultureInfo.InvariantCulture);
        

[Description("Distance between top and bottom surfaces of slat Slat is assumed to be rectangula" +
    "r in cross section and flat")]
[JsonProperty(PropertyName="slat_thickness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlatThickness { get; set; } = Double.Parse("0.0006", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="slat_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlatAngle { get; set; } = Double.Parse("90", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="slat_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlatConductivity { get; set; } = Double.Parse("160", CultureInfo.InvariantCulture);
        

[Description("this value represents curvature radius of the slat. if the slat is flat use zero." +
    " if this value is not zero, then it must be > SlatWidth/2.")]
[JsonProperty(PropertyName="slat_curve", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlatCurve { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    public enum WindowMaterial_ComplexShade_LayerType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BSDF")]
        BSDF = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherShadingType")]
        OtherShadingType = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Perforated")]
        Perforated = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="VenetianHorizontal")]
        VenetianHorizontal = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="VenetianVertical")]
        VenetianVertical = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Woven")]
        Woven = 6,
    }
    
    [Description("Window blind thermal properties")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowMaterial_Blind
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="slat_orientation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowMaterial_Blind_SlatOrientation SlatOrientation { get; set; } = (WindowMaterial_Blind_SlatOrientation)Enum.Parse(typeof(WindowMaterial_Blind_SlatOrientation), "Horizontal");
        

[JsonProperty(PropertyName="slat_width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlatWidth { get; set; } = null;
        

[Description("Distance between adjacent slat faces")]
[JsonProperty(PropertyName="slat_separation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlatSeparation { get; set; } = null;
        

[Description("Distance between top and bottom surfaces of slat Slat is assumed to be rectangula" +
    "r in cross section and flat")]
[JsonProperty(PropertyName="slat_thickness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlatThickness { get; set; } = Double.Parse("0.00025", CultureInfo.InvariantCulture);
        

[Description(@"If WindowShadingControl referencing the window that incorporates this blind has Type of Slat Angle Control for Blinds = FixedSlatAngle, then this is the fixed value of the slat angle; If WindowShadingControl referencing the window that incorporates this blind has Type of Slat Angle Control for Blinds = BlockBeamSolar, then this is the slat angle when slat angle control is not in effect (e.g., when there is no beam solar on the blind); Not used if WindowShadingControl referencing the window that incorporates this blind has Type of Slat Angle Control for Blinds = ScheduledSlatAngle.")]
[JsonProperty(PropertyName="slat_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlatAngle { get; set; } = Double.Parse("45", CultureInfo.InvariantCulture);
        

[Description("default is for aluminum")]
[JsonProperty(PropertyName="slat_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlatConductivity { get; set; } = Double.Parse("221", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="slat_beam_solar_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlatBeamSolarTransmittance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="front_side_slat_beam_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideSlatBeamSolarReflectance { get; set; } = null;
        

[JsonProperty(PropertyName="back_side_slat_beam_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideSlatBeamSolarReflectance { get; set; } = null;
        

[Description("Must equal \"Slat beam solar transmittance\"")]
[JsonProperty(PropertyName="slat_diffuse_solar_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlatDiffuseSolarTransmittance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Must equal \"Front Side Slat Beam Solar Reflectance\"")]
[JsonProperty(PropertyName="front_side_slat_diffuse_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideSlatDiffuseSolarReflectance { get; set; } = null;
        

[Description("Must equal \"Back Side Slat Beam Solar Reflectance\"")]
[JsonProperty(PropertyName="back_side_slat_diffuse_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideSlatDiffuseSolarReflectance { get; set; } = null;
        

[Description("Required for detailed daylighting calculation")]
[JsonProperty(PropertyName="slat_beam_visible_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlatBeamVisibleTransmittance { get; set; } = null;
        

[Description("Required for detailed daylighting calculation")]
[JsonProperty(PropertyName="front_side_slat_beam_visible_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideSlatBeamVisibleReflectance { get; set; } = null;
        

[Description("Required for detailed daylighting calculation")]
[JsonProperty(PropertyName="back_side_slat_beam_visible_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideSlatBeamVisibleReflectance { get; set; } = null;
        

[Description("Used only for detailed daylighting calculation Must equal \"Slat Beam Visible Tran" +
    "smittance\"")]
[JsonProperty(PropertyName="slat_diffuse_visible_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlatDiffuseVisibleTransmittance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Required for detailed daylighting calculation Must equal \"Front Side Slat Beam Vi" +
    "sible Reflectance\"")]
[JsonProperty(PropertyName="front_side_slat_diffuse_visible_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideSlatDiffuseVisibleReflectance { get; set; } = null;
        

[Description("Required for detailed daylighting calculation Must equal \"Back Side Slat Beam Vis" +
    "ible Reflectance\"")]
[JsonProperty(PropertyName="back_side_slat_diffuse_visible_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideSlatDiffuseVisibleReflectance { get; set; } = null;
        

[JsonProperty(PropertyName="slat_infrared_hemispherical_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlatInfraredHemisphericalTransmittance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="front_side_slat_infrared_hemispherical_emissivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideSlatInfraredHemisphericalEmissivity { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="back_side_slat_infrared_hemispherical_emissivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideSlatInfraredHemisphericalEmissivity { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="blind_to_glass_distance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BlindToGlassDistance { get; set; } = Double.Parse("0.05", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="blind_top_opening_multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BlindTopOpeningMultiplier { get; set; } = Double.Parse("0.5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="blind_bottom_opening_multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BlindBottomOpeningMultiplier { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="blind_left_side_opening_multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BlindLeftSideOpeningMultiplier { get; set; } = Double.Parse("0.5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="blind_right_side_opening_multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BlindRightSideOpeningMultiplier { get; set; } = Double.Parse("0.5", CultureInfo.InvariantCulture);
        

[Description("Used only if WindowShadingControl referencing the window that incorporates this b" +
    "lind varies the slat angle (i.e., WindowShadingControl with Type of Slat Angle C" +
    "ontrol for Blinds = ScheduledSlatAngle or BlockBeamSolar)")]
[JsonProperty(PropertyName="minimum_slat_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumSlatAngle { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Used only if WindowShadingControl referencing the window that incorporates this b" +
    "lind varies the slat angle (i.e., WindowShadingControl with Type of Slat Angle C" +
    "ontrol for Blinds = ScheduledSlatAngle or BlockBeamSolar)")]
[JsonProperty(PropertyName="maximum_slat_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumSlatAngle { get; set; } = Double.Parse("180", CultureInfo.InvariantCulture);
    }
    
    public enum WindowMaterial_Blind_SlatOrientation
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Horizontal")]
        Horizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Vertical")]
        Vertical = 2,
    }
    
    [Description("Window screen physical properties. Can only be located on the exterior side of a " +
        "window construction.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowMaterial_Screen
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Select the method used to account for the beam solar reflected off the material s" +
    "urface.")]
[JsonProperty(PropertyName="reflected_beam_transmittance_accounting_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowMaterial_Screen_ReflectedBeamTransmittanceAccountingMethod ReflectedBeamTransmittanceAccountingMethod { get; set; } = (WindowMaterial_Screen_ReflectedBeamTransmittanceAccountingMethod)Enum.Parse(typeof(WindowMaterial_Screen_ReflectedBeamTransmittanceAccountingMethod), "ModelAsDiffuse");
        

[Description("Diffuse reflectance of the screen material over the entire solar radiation spectr" +
    "um. Assumed to be the same for both sides of the screen.")]
[JsonProperty(PropertyName="diffuse_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DiffuseSolarReflectance { get; set; } = null;
        

[Description("Diffuse visible reflectance of the screen material averaged over the solar spectr" +
    "um and weighted by the response of the human eye. Assumed to be the same for bot" +
    "h sides of the screen.")]
[JsonProperty(PropertyName="diffuse_visible_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DiffuseVisibleReflectance { get; set; } = null;
        

[Description("Long-wave emissivity of the screen material. Assumed to be the same for both side" +
    "s of the screen.")]
[JsonProperty(PropertyName="thermal_hemispherical_emissivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalHemisphericalEmissivity { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[Description("Thermal conductivity of the screen material. Default is for aluminum.")]
[JsonProperty(PropertyName="conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Conductivity { get; set; } = Double.Parse("221", CultureInfo.InvariantCulture);
        

[Description("Spacing assumed to be the same in both directions.")]
[JsonProperty(PropertyName="screen_material_spacing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ScreenMaterialSpacing { get; set; } = null;
        

[Description("Diameter assumed to be the same in both directions.")]
[JsonProperty(PropertyName="screen_material_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ScreenMaterialDiameter { get; set; } = null;
        

[Description("Distance from the window screen to the adjacent glass surface.")]
[JsonProperty(PropertyName="screen_to_glass_distance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ScreenToGlassDistance { get; set; } = Double.Parse("0.025", CultureInfo.InvariantCulture);
        

[Description("Effective area for air flow at the top of the screen divided by the perpendicular" +
    " area between the glass and the top of the screen.")]
[JsonProperty(PropertyName="top_opening_multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TopOpeningMultiplier { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Effective area for air flow at the bottom of the screen divided by the perpendicu" +
    "lar area between the glass and the bottom of the screen.")]
[JsonProperty(PropertyName="bottom_opening_multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BottomOpeningMultiplier { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Effective area for air flow at the left side of the screen divided by the perpend" +
    "icular area between the glass and the left side of the screen.")]
[JsonProperty(PropertyName="left_side_opening_multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LeftSideOpeningMultiplier { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Effective area for air flow at the right side of the screen divided by the perpen" +
    "dicular area between the glass and the right side of the screen.")]
[JsonProperty(PropertyName="right_side_opening_multiplier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RightSideOpeningMultiplier { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Select the resolution of azimuth and altitude angles for the screen transmittance" +
    " map. A value of 0 means no transmittance map will be generated. Valid values fo" +
    "r this field are 0, 1, 2, 3 and 5.")]
[JsonProperty(PropertyName="angle_of_resolution_for_screen_transmittance_output_map", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AngleOfResolutionForScreenTransmittanceOutputMap { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    public enum WindowMaterial_Screen_ReflectedBeamTransmittanceAccountingMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DoNotModel")]
        DoNotModel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ModelAsDiffuse")]
        ModelAsDiffuse = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ModelAsDirectBeam")]
        ModelAsDirectBeam = 3,
    }
    
    [Description("Specifies the properties of equivalent layer window shade material Shades are con" +
        "sidered to be perfect diffusers (all transmitted and reflected radiation is hemi" +
        "spherically-diffuse) independent of angle of incidence. Shade represents roller " +
        "blinds.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowMaterial_Shade_EquivalentLayer
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("The beam-beam solar transmittance at normal incidence. This value is the same as " +
    "the openness area fraction of the shade material. Assumed to be the same for fro" +
    "nt and back sides.")]
[JsonProperty(PropertyName="shade_beam_beam_solar_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ShadeBeamBeamSolarTransmittance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("The front side beam-diffuse solar transmittance at normal incidence averaged over" +
    " the entire spectrum of solar radiation.")]
[JsonProperty(PropertyName="front_side_shade_beam_diffuse_solar_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideShadeBeamDiffuseSolarTransmittance { get; set; } = null;
        

[Description("The back side beam-diffuse solar transmittance at normal incidence averaged over " +
    "the entire spectrum of solar radiation.")]
[JsonProperty(PropertyName="back_side_shade_beam_diffuse_solar_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideShadeBeamDiffuseSolarTransmittance { get; set; } = null;
        

[Description("The front side beam-diffuse solar reflectance at normal incidence averaged over t" +
    "he entire spectrum of solar radiation.")]
[JsonProperty(PropertyName="front_side_shade_beam_diffuse_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideShadeBeamDiffuseSolarReflectance { get; set; } = null;
        

[Description("The back side beam-diffuse solar reflectance at normal incidence averaged over th" +
    "e entire spectrum of solar radiation.")]
[JsonProperty(PropertyName="back_side_shade_beam_diffuse_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideShadeBeamDiffuseSolarReflectance { get; set; } = null;
        

[Description("The beam-beam visible transmittance at normal incidence averaged over the visible" +
    " spectrum range of solar radiation. Assumed to be the same for front and back si" +
    "des of the shade.")]
[JsonProperty(PropertyName="shade_beam_beam_visible_transmittance_at_normal_incidence", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ShadeBeamBeamVisibleTransmittanceAtNormalIncidence { get; set; } = null;
        

[Description("The beam-diffuse visible transmittance at normal incidence averaged over the visi" +
    "ble spectrum range of solar radiation. Assumed to be the same for front and back" +
    " sides of the shade.")]
[JsonProperty(PropertyName="shade_beam_diffuse_visible_transmittance_at_normal_incidence", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ShadeBeamDiffuseVisibleTransmittanceAtNormalIncidence { get; set; } = null;
        

[Description("The beam-diffuse visible reflectance at normal incidence averaged over the visibl" +
    "e spectrum range of solar radiation. Assumed to be the same for front and back s" +
    "ides of the shade.")]
[JsonProperty(PropertyName="shade_beam_diffuse_visible_reflectance_at_normal_incidence", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ShadeBeamDiffuseVisibleReflectanceAtNormalIncidence { get; set; } = null;
        

[Description("The long-wave transmittance of the shade material at zero shade openness. Assumed" +
    " to be the same for front and back sides of the shade.")]
[JsonProperty(PropertyName="shade_material_infrared_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ShadeMaterialInfraredTransmittance { get; set; } = Double.Parse("0.05", CultureInfo.InvariantCulture);
        

[Description("The front side long-wave emissivity of the shade material at zero shade openness." +
    " Openness fraction is used to calculate the effective emissivity value.")]
[JsonProperty(PropertyName="front_side_shade_material_infrared_emissivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideShadeMaterialInfraredEmissivity { get; set; } = Double.Parse("0.91", CultureInfo.InvariantCulture);
        

[Description("The back side long-wave emissivity of the shade material at zero shade openness. " +
    "Openness fraction is used to calculate the effective emissivity value.")]
[JsonProperty(PropertyName="back_side_shade_material_infrared_emissivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideShadeMaterialInfraredEmissivity { get; set; } = Double.Parse("0.91", CultureInfo.InvariantCulture);
    }
    
    [Description(@"Specifies the properties of equivalent layer drape fabric materials. Shades are considered to be perfect diffusers (all transmitted and reflected radiation is hemispherically-diffuse) independent of angle of incidence. unpleated drape fabric is treated as thin and flat layer.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowMaterial_Drape_EquivalentLayer
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("The beam-beam solar transmittance at normal incidence. This value is the same as " +
    "the openness area fraction of the drape fabric. Assumed to be same for front and" +
    " back sides.")]
[JsonProperty(PropertyName="drape_beam_beam_solar_transmittance_at_normal_incidence", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DrapeBeamBeamSolarTransmittanceAtNormalIncidence { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("The front side beam-diffuse solar transmittance at normal incidence averaged over" +
    " the entire spectrum of solar radiation. Assumed to be the same for front and ba" +
    "ck sides.")]
[JsonProperty(PropertyName="front_side_drape_beam_diffuse_solar_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideDrapeBeamDiffuseSolarTransmittance { get; set; } = null;
        

[Description("The back side beam-diffuse solar transmittance at normal incidence averaged over " +
    "the entire spectrum of solar radiation. Assumed to be the same for front and bac" +
    "k sides.")]
[JsonProperty(PropertyName="back_side_drape_beam_diffuse_solar_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideDrapeBeamDiffuseSolarTransmittance { get; set; } = null;
        

[Description("The front side beam-diffuse solar reflectance at normal incidence averaged over t" +
    "he entire spectrum of solar radiation.")]
[JsonProperty(PropertyName="front_side_drape_beam_diffuse_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideDrapeBeamDiffuseSolarReflectance { get; set; } = null;
        

[Description("The back side beam-diffuse solar reflectance at normal incidence averaged over th" +
    "e entire spectrum of solar radiation.")]
[JsonProperty(PropertyName="back_side_drape_beam_diffuse_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideDrapeBeamDiffuseSolarReflectance { get; set; } = null;
        

[Description("The beam-beam visible transmittance at normal incidence averaged over the visible" +
    " spectrum of solar radiation. Assumed same for front and back sides.")]
[JsonProperty(PropertyName="drape_beam_beam_visible_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DrapeBeamBeamVisibleTransmittance { get; set; } = null;
        

[Description("The beam-diffuse visible transmittance at normal incidence averaged over the visi" +
    "ble spectrum range of solar radiation. Assumed to be the same for front and back" +
    " sides.")]
[JsonProperty(PropertyName="drape_beam_diffuse_visible_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DrapeBeamDiffuseVisibleTransmittance { get; set; } = null;
        

[Description("The beam-diffuse visible reflectance at normal incidence average over the visible" +
    " spectrum range of solar radiation. Assumed to be the same for front and back si" +
    "des.")]
[JsonProperty(PropertyName="drape_beam_diffuse_visible_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DrapeBeamDiffuseVisibleReflectance { get; set; } = null;
        

[Description("Long-wave transmittance of the drape fabric at zero openness fraction. Assumed sa" +
    "me for front and back sides.")]
[JsonProperty(PropertyName="drape_material_infrared_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DrapeMaterialInfraredTransmittance { get; set; } = Double.Parse("0.05", CultureInfo.InvariantCulture);
        

[Description("Front side long-wave emissivity of the drape fabric at zero shade openness. Openn" +
    "ess fraction specified above is used to calculate the effective emissivity value" +
    ".")]
[JsonProperty(PropertyName="front_side_drape_material_infrared_emissivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideDrapeMaterialInfraredEmissivity { get; set; } = Double.Parse("0.87", CultureInfo.InvariantCulture);
        

[Description("Back side long-wave emissivity of the drape fabric at zero shade openness. Openne" +
    "ss fraction specified above is used to calculate the effective emissivity value." +
    "")]
[JsonProperty(PropertyName="back_side_drape_material_infrared_emissivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideDrapeMaterialInfraredEmissivity { get; set; } = Double.Parse("0.87", CultureInfo.InvariantCulture);
        

[Description("Width of the pleated section of the draped fabric. If the drape fabric is unpleat" +
    "ed or is flat, then the pleated section width is set to zero.")]
[JsonProperty(PropertyName="width_of_pleated_fabric", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WidthOfPleatedFabric { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Length of the pleated section of the draped fabric. If the drape fabric is unplea" +
    "ted or is flat, then the pleated section length is set to zero.")]
[JsonProperty(PropertyName="length_of_pleated_fabric", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LengthOfPleatedFabric { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    [Description("Window equivalent layer blind slat optical and thermal properties. The model assu" +
        "mes that slats are thin and flat, applies correction empirical correlation to ac" +
        "count for curvature effect. Slats are assumed to transmit and reflect diffusely." +
        "")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowMaterial_Blind_EquivalentLayer
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="slat_orientation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowMaterial_Blind_EquivalentLayer_SlatOrientation SlatOrientation { get; set; } = (WindowMaterial_Blind_EquivalentLayer_SlatOrientation)Enum.Parse(typeof(WindowMaterial_Blind_EquivalentLayer_SlatOrientation), "Horizontal");
        

[JsonProperty(PropertyName="slat_width", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlatWidth { get; set; } = null;
        

[Description("Distance between adjacent slat faces")]
[JsonProperty(PropertyName="slat_separation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlatSeparation { get; set; } = null;
        

[Description("Perpendicular length between the cord and the curve. Slat is assumed to be rectan" +
    "gular in cross section and flat. Crown=0.0625x\"Slat width\"")]
[JsonProperty(PropertyName="slat_crown", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlatCrown { get; set; } = Double.Parse("0.0015", CultureInfo.InvariantCulture);
        

[Description("Slat angle is +ve if the tip of the slat front face is tilted upward, else the sl" +
    "at angle is -ve if the tip of the slat front face is tilted downward. The slat a" +
    "ngle varies between -90 to +90. The default value is 45 degrees.")]
[JsonProperty(PropertyName="slat_angle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlatAngle { get; set; } = Double.Parse("45", CultureInfo.InvariantCulture);
        

[Description("The front side beam-diffuse solar transmittance of the slat at normal incidence a" +
    "veraged over the entire spectrum of solar radiation.")]
[JsonProperty(PropertyName="front_side_slat_beam_diffuse_solar_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideSlatBeamDiffuseSolarTransmittance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("The back side beam-diffuse solar transmittance of the slat at normal incidence av" +
    "eraged over the entire spectrum of solar radiation.")]
[JsonProperty(PropertyName="back_side_slat_beam_diffuse_solar_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideSlatBeamDiffuseSolarTransmittance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("The front side beam-diffuse solar reflectance of the slat at normal incidence ave" +
    "raged over the entire spectrum of solar radiation.")]
[JsonProperty(PropertyName="front_side_slat_beam_diffuse_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideSlatBeamDiffuseSolarReflectance { get; set; } = null;
        

[Description("The back side beam-diffuse solar reflectance of the slat at normal incidence aver" +
    "aged over the entire spectrum of solar radiation.")]
[JsonProperty(PropertyName="back_side_slat_beam_diffuse_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideSlatBeamDiffuseSolarReflectance { get; set; } = null;
        

[Description("The front side beam-diffuse visible transmittance of the slat at normal incidence" +
    " averaged over the visible spectrum range of solar radiation.")]
[JsonProperty(PropertyName="front_side_slat_beam_diffuse_visible_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideSlatBeamDiffuseVisibleTransmittance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("The back side beam-diffuse visible transmittance of the slat at normal incidence " +
    "averaged over the visible spectrum range of solar radiation.")]
[JsonProperty(PropertyName="back_side_slat_beam_diffuse_visible_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideSlatBeamDiffuseVisibleTransmittance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("The front side beam-diffuse visible reflectance of the slat at normal incidence a" +
    "veraged over the visible spectrum range of solar radiation.")]
[JsonProperty(PropertyName="front_side_slat_beam_diffuse_visible_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideSlatBeamDiffuseVisibleReflectance { get; set; } = null;
        

[Description("The back side beam-diffuse visible reflectance of the slat at normal incidence av" +
    "eraged over the visible spectrum range of solar radiation.")]
[JsonProperty(PropertyName="back_side_slat_beam_diffuse_visible_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideSlatBeamDiffuseVisibleReflectance { get; set; } = null;
        

[Description("The beam-diffuse solar transmittance of the slat averaged over the entire solar s" +
    "pectrum of solar radiation.")]
[JsonProperty(PropertyName="slat_diffuse_diffuse_solar_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlatDiffuseDiffuseSolarTransmittance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("The front side beam-diffuse solar reflectance of the slat averaged over the entir" +
    "e solar spectrum of solar radiation.")]
[JsonProperty(PropertyName="front_side_slat_diffuse_diffuse_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideSlatDiffuseDiffuseSolarReflectance { get; set; } = null;
        

[Description("The back side beam-diffuse solar reflectance of the slat averaged over the entire" +
    " solar spectrum of solar radiation.")]
[JsonProperty(PropertyName="back_side_slat_diffuse_diffuse_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideSlatDiffuseDiffuseSolarReflectance { get; set; } = null;
        

[Description("The beam-diffuse visible transmittance of the slat averaged over the visible spec" +
    "trum range of solar radiation.")]
[JsonProperty(PropertyName="slat_diffuse_diffuse_visible_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlatDiffuseDiffuseVisibleTransmittance { get; set; } = null;
        

[Description("The front side beam-diffuse visible reflectance of the slat averaged over the vis" +
    "ible spectrum range of solar radiation.")]
[JsonProperty(PropertyName="front_side_slat_diffuse_diffuse_visible_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideSlatDiffuseDiffuseVisibleReflectance { get; set; } = null;
        

[Description("The back side beam-diffuse visible reflectance of the slat averaged over the visi" +
    "ble spectrum range of solar radiation.")]
[JsonProperty(PropertyName="back_side_slat_diffuse_diffuse_visible_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideSlatDiffuseDiffuseVisibleReflectance { get; set; } = null;
        

[Description("Long-wave hemispherical transmittance of the slat material. Assumed to be the sam" +
    "e for both sides of the slat.")]
[JsonProperty(PropertyName="slat_infrared_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SlatInfraredTransmittance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Front side long-wave hemispherical emissivity of the slat material.")]
[JsonProperty(PropertyName="front_side_slat_infrared_emissivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideSlatInfraredEmissivity { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[Description("Back side long-wave hemispherical emissivity of the slat material.")]
[JsonProperty(PropertyName="back_side_slat_infrared_emissivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideSlatInfraredEmissivity { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[Description(@"Used only if slat angle control is desired to either maximize solar gain (MaximizeSolar), maximize visibility while eliminating beam solar radiation (BlockBeamSolar), or fixed slate angle (FixedSlatAngle). If FixedSlatAngle is selected, the slat angle entered above is used.")]
[JsonProperty(PropertyName="slat_angle_control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowMaterial_Blind_EquivalentLayer_SlatAngleControl SlatAngleControl { get; set; } = (WindowMaterial_Blind_EquivalentLayer_SlatAngleControl)Enum.Parse(typeof(WindowMaterial_Blind_EquivalentLayer_SlatAngleControl), "FixedSlatAngle");
    }
    
    public enum WindowMaterial_Blind_EquivalentLayer_SlatOrientation
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Horizontal")]
        Horizontal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Vertical")]
        Vertical = 2,
    }
    
    public enum WindowMaterial_Blind_EquivalentLayer_SlatAngleControl
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BlockBeamSolar")]
        BlockBeamSolar = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedSlatAngle")]
        FixedSlatAngle = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MaximizeSolar")]
        MaximizeSolar = 3,
    }
    
    [Description("Equivalent layer window screen physical properties. Can only be located on the ex" +
        "terior side of a window construction.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowMaterial_Screen_EquivalentLayer
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description(@"The beam-beam transmittance of the screen material at normal incidence. This input field is the same as the material openness area fraction and can be autocalculated from the wire spacing and wire and diameter. Assumed to be the same for both sides of the screen.")]
[JsonProperty(PropertyName="screen_beam_beam_solar_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> ScreenBeamBeamSolarTransmittance { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("The beam-diffuse solar transmittance of the screen material at normal incidence a" +
    "veraged over the entire spectrum of solar radiation. Assumed to be the same for " +
    "both sides of the screen.")]
[JsonProperty(PropertyName="screen_beam_diffuse_solar_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ScreenBeamDiffuseSolarTransmittance { get; set; } = null;
        

[Description("The beam-diffuse solar reflectance of the screen material at normal incidence ave" +
    "raged over the entire spectrum of solar radiation. Assumed to be the same for bo" +
    "th sides of the screen.")]
[JsonProperty(PropertyName="screen_beam_diffuse_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ScreenBeamDiffuseSolarReflectance { get; set; } = null;
        

[Description("The beam-beam visible transmittance of the screen material at normal incidence av" +
    "eraged over the visible spectrum range of solar radiation. Assumed to be the sam" +
    "e for both sides of the screen.")]
[JsonProperty(PropertyName="screen_beam_beam_visible_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ScreenBeamBeamVisibleTransmittance { get; set; } = null;
        

[Description("The beam-diffuse visible transmittance of the screen material at normal incidence" +
    " averaged over the visible spectrum range of solar radiation. Assumed to be the " +
    "same for both sides of the screen.")]
[JsonProperty(PropertyName="screen_beam_diffuse_visible_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ScreenBeamDiffuseVisibleTransmittance { get; set; } = null;
        

[Description("Beam-diffuse visible reflectance of the screen material at normal incidence avera" +
    "ged over the visible spectrum range of solar radiation. Assumed to be the same f" +
    "or both sides of the screen.")]
[JsonProperty(PropertyName="screen_beam_diffuse_visible_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ScreenBeamDiffuseVisibleReflectance { get; set; } = null;
        

[Description("The long-wave hemispherical transmittance of the screen material. Assumed to be t" +
    "he same for both sides of the screen.")]
[JsonProperty(PropertyName="screen_infrared_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ScreenInfraredTransmittance { get; set; } = Double.Parse("0.02", CultureInfo.InvariantCulture);
        

[Description("The long-wave hemispherical emissivity of the screen material. Assumed to be the " +
    "same for both sides of the screen.")]
[JsonProperty(PropertyName="screen_infrared_emissivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ScreenInfraredEmissivity { get; set; } = Double.Parse("0.93", CultureInfo.InvariantCulture);
        

[Description("Spacing assumed to be the same in both directions.")]
[JsonProperty(PropertyName="screen_wire_spacing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ScreenWireSpacing { get; set; } = Double.Parse("0.025", CultureInfo.InvariantCulture);
        

[Description("Diameter assumed to be the same in both directions.")]
[JsonProperty(PropertyName="screen_wire_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ScreenWireDiameter { get; set; } = Double.Parse("0.005", CultureInfo.InvariantCulture);
    }
    
    [Description("Glass material properties for Windows or Glass Doors Transmittance/Reflectance in" +
        "put method.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowMaterial_Glazing_EquivalentLayer
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Spectral is not currently supported and SpectralAverage is the default.")]
[JsonProperty(PropertyName="optical_data_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowMaterial_Glazing_EquivalentLayer_OpticalDataType OpticalDataType { get; set; } = (WindowMaterial_Glazing_EquivalentLayer_OpticalDataType)Enum.Parse(typeof(WindowMaterial_Glazing_EquivalentLayer_OpticalDataType), "SpectralAverage");
        

[Description("Spectral data is not currently supported. Used only when Optical Data Type = Spec" +
    "tral")]
[JsonProperty(PropertyName="window_glass_spectral_data_set_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WindowGlassSpectralDataSetName { get; set; } = "";
        

[Description("Used only when Optical Data Type = SpectralAverage")]
[JsonProperty(PropertyName="front_side_beam_beam_solar_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideBeamBeamSolarTransmittance { get; set; } = null;
        

[Description("Used only when Optical Data Type = SpectralAverage")]
[JsonProperty(PropertyName="back_side_beam_beam_solar_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideBeamBeamSolarTransmittance { get; set; } = null;
        

[Description("Used only when Optical Data Type = SpectralAverage Front Side is side closest to " +
    "outdoor air")]
[JsonProperty(PropertyName="front_side_beam_beam_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideBeamBeamSolarReflectance { get; set; } = null;
        

[Description("Used only when Optical Data Type = SpectralAverage Back Side is side closest to z" +
    "one air")]
[JsonProperty(PropertyName="back_side_beam_beam_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideBeamBeamSolarReflectance { get; set; } = null;
        

[Description("Used only when Optical Data Type = SpectralAverage")]
[JsonProperty(PropertyName="front_side_beam_beam_visible_solar_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideBeamBeamVisibleSolarTransmittance { get; set; } = null;
        

[Description("Used only when Optical Data Type = SpectralAverage")]
[JsonProperty(PropertyName="back_side_beam_beam_visible_solar_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideBeamBeamVisibleSolarTransmittance { get; set; } = null;
        

[Description("Used only when Optical Data Type = SpectralAverage Front Side is side closest to " +
    "outdoor air")]
[JsonProperty(PropertyName="front_side_beam_beam_visible_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideBeamBeamVisibleSolarReflectance { get; set; } = null;
        

[Description("Used only when Optical Data Type = SpectralAverage Back Side is side closest to z" +
    "one air")]
[JsonProperty(PropertyName="back_side_beam_beam_visible_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideBeamBeamVisibleSolarReflectance { get; set; } = null;
        

[Description("Used only when Optical Data Type = SpectralAverage")]
[JsonProperty(PropertyName="front_side_beam_diffuse_solar_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideBeamDiffuseSolarTransmittance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Used only when Optical Data Type = SpectralAverage")]
[JsonProperty(PropertyName="back_side_beam_diffuse_solar_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideBeamDiffuseSolarTransmittance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Used only when Optical Data Type = SpectralAverage Front Side is side closest to " +
    "outdoor air")]
[JsonProperty(PropertyName="front_side_beam_diffuse_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideBeamDiffuseSolarReflectance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Used only when Optical Data Type = SpectralAverage Back Side is side closest to z" +
    "one air")]
[JsonProperty(PropertyName="back_side_beam_diffuse_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideBeamDiffuseSolarReflectance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Used only when Optical Data Type = SpectralAverage")]
[JsonProperty(PropertyName="front_side_beam_diffuse_visible_solar_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideBeamDiffuseVisibleSolarTransmittance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Used only when Optical Data Type = SpectralAverage")]
[JsonProperty(PropertyName="back_side_beam_diffuse_visible_solar_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideBeamDiffuseVisibleSolarTransmittance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Used only when Optical Data Type = SpectralAverage Front Side is side closest to " +
    "outdoor air")]
[JsonProperty(PropertyName="front_side_beam_diffuse_visible_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideBeamDiffuseVisibleSolarReflectance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Used only when Optical Data Type = SpectralAverage Back Side is side closest to z" +
    "one air")]
[JsonProperty(PropertyName="back_side_beam_diffuse_visible_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideBeamDiffuseVisibleSolarReflectance { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description(@"Used only when Optical Data Type = SpectralAverage If this field is autocalculate, then the diffuse-diffuse solar transmittance is automatically estimated from other inputs and used in subsequent calculations. If this field is zero or positive, then the value entered here will be used.")]
[JsonProperty(PropertyName="diffuse_diffuse_solar_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> DiffuseDiffuseSolarTransmittance { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Used only when Optical Data Type = SpectralAverage If this field is autocalculate, then the front diffuse-diffuse solar reflectance is automatically estimated from other inputs and used in subsequent calculations. If this field is zero or positive, then the value entered here will be used. Front Side is side closest to outdoor air.")]
[JsonProperty(PropertyName="front_side_diffuse_diffuse_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> FrontSideDiffuseDiffuseSolarReflectance { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Used only when Optical Data Type = SpectralAverage If this field is autocalculate, then the back diffuse-diffuse solar reflectance is automatically estimated from other inputs and used in subsequent calculations. If this field is zero or positive, then the value entered here will be used. Back side is side closest to indoor air.")]
[JsonProperty(PropertyName="back_side_diffuse_diffuse_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> BackSideDiffuseDiffuseSolarReflectance { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Used only when Optical Data Type = SpectralAverage This input field is not used c" +
    "urrently.")]
[JsonProperty(PropertyName="diffuse_diffuse_visible_solar_transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> DiffuseDiffuseVisibleSolarTransmittance { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Used only when Optical Data Type = SpectralAverage This input field is not used c" +
    "urrently.")]
[JsonProperty(PropertyName="front_side_diffuse_diffuse_visible_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> FrontSideDiffuseDiffuseVisibleSolarReflectance { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Used only when Optical Data Type = SpectralAverage This input field is not used c" +
    "urrently.")]
[JsonProperty(PropertyName="back_side_diffuse_diffuse_visible_solar_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> BackSideDiffuseDiffuseVisibleSolarReflectance { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("The long-wave hemispherical transmittance of the glazing. Assumed to be the same " +
    "for both sides of the glazing.")]
[JsonProperty(PropertyName="infrared_transmittance_applies_to_front_and_back_", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InfraredTransmittanceAppliesToFrontAndBack { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("The front side long-wave hemispherical emissivity of the glazing.")]
[JsonProperty(PropertyName="front_side_infrared_emissivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSideInfraredEmissivity { get; set; } = Double.Parse("0.84", CultureInfo.InvariantCulture);
        

[Description("The back side long-wave hemispherical emissivity of the glazing.")]
[JsonProperty(PropertyName="back_side_infrared_emissivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackSideInfraredEmissivity { get; set; } = Double.Parse("0.84", CultureInfo.InvariantCulture);
        

[Description("This is the R-Value in SI for the glass. The default value is an approximation fo" +
    "r a single layer of glass at 1/4\" inch thickness. This field is used only for mo" +
    "vable insulation defined with this material type.")]
[JsonProperty(PropertyName="thermal_resistance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalResistance { get; set; } = Double.Parse("0.158", CultureInfo.InvariantCulture);
    }
    
    public enum WindowMaterial_Glazing_EquivalentLayer_OpticalDataType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Spectral")]
        Spectral = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SpectralAverage")]
        SpectralAverage = 2,
    }
    
    [Description("Gas material properties that are used in Windows Equivalent Layer References only" +
        " WindowMaterial:Gas properties")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowMaterial_Gap_EquivalentLayer
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="gas_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowMaterial_Gap_EquivalentLayer_GasType GasType { get; set; } = (WindowMaterial_Gap_EquivalentLayer_GasType)Enum.Parse(typeof(WindowMaterial_Gap_EquivalentLayer_GasType), "AIR");
        

[JsonProperty(PropertyName="thickness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Thickness { get; set; } = null;
        

[Description(@"Sealed means the gap is enclosed and gas tight, i.e., no venting to indoor or outdoor environment. VentedIndoor means the gap is vented to indoor environment, and VentedOutdoor means the gap is vented to the outdoor environment. The gap types VentedIndoor and VentedOutdoor are used with gas type ""Air"" only.")]
[JsonProperty(PropertyName="gap_vent_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowMaterial_Gap_EquivalentLayer_GapVentType GapVentType { get; set; } = (WindowMaterial_Gap_EquivalentLayer_GapVentType)Enum.Parse(typeof(WindowMaterial_Gap_EquivalentLayer_GapVentType), "Sealed");
        

[Description("Used only if Gas Type = Custom")]
[JsonProperty(PropertyName="conductivity_coefficient_a", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConductivityCoefficientA { get; set; } = null;
        

[Description("Used only if Gas Type = Custom")]
[JsonProperty(PropertyName="conductivity_coefficient_b", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConductivityCoefficientB { get; set; } = null;
        

[Description("Used only if Gas Type = Custom")]
[JsonProperty(PropertyName="conductivity_coefficient_c", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConductivityCoefficientC { get; set; } = null;
        

[Description("Used only if Gas Type = Custom")]
[JsonProperty(PropertyName="viscosity_coefficient_a", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ViscosityCoefficientA { get; set; } = null;
        

[Description("Used only if Gas Type = Custom")]
[JsonProperty(PropertyName="viscosity_coefficient_b", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ViscosityCoefficientB { get; set; } = null;
        

[Description("Used only if Gas Type = Custom")]
[JsonProperty(PropertyName="viscosity_coefficient_c", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ViscosityCoefficientC { get; set; } = null;
        

[Description("Used only if Gas Type = Custom")]
[JsonProperty(PropertyName="specific_heat_coefficient_a", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SpecificHeatCoefficientA { get; set; } = null;
        

[Description("Used only if Gas Type = Custom")]
[JsonProperty(PropertyName="specific_heat_coefficient_b", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SpecificHeatCoefficientB { get; set; } = null;
        

[Description("Used only if Gas Type = Custom")]
[JsonProperty(PropertyName="specific_heat_coefficient_c", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SpecificHeatCoefficientC { get; set; } = null;
        

[Description("Used only if Gas Type = Custom")]
[JsonProperty(PropertyName="molecular_weight", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MolecularWeight { get; set; } = null;
        

[Description("Used only if Gas Type = Custom")]
[JsonProperty(PropertyName="specific_heat_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SpecificHeatRatio { get; set; } = null;
    }
    
    public enum WindowMaterial_Gap_EquivalentLayer_GasType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AIR")]
        AIR = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ARGON")]
        ARGON = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CUSTOM")]
        CUSTOM = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="KRYPTON")]
        KRYPTON = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="XENON")]
        XENON = 4,
    }
    
    public enum WindowMaterial_Gap_EquivalentLayer_GapVentType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Sealed")]
        Sealed = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="VentedIndoor")]
        VentedIndoor = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="VentedOutdoor")]
        VentedOutdoor = 2,
    }
    
    [Description("Additional properties for moisture using EMPD procedure HeatBalanceAlgorithm choi" +
        "ce=MoisturePenetrationDepthConductionTransferFunction only Has no effect with ot" +
        "her HeatBalanceAlgorithm solution algorithms")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class MaterialProperty_MoisturePenetrationDepth_Settings
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Ratio of water vapor permeability of stagnant air to water vapor permeability of " +
    "material")]
[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_equation_coefficient_a", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureEquationCoefficientA { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_equation_coefficient_b", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureEquationCoefficientB { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_equation_coefficient_c", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureEquationCoefficientC { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_equation_coefficient_d", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureEquationCoefficientD { get; set; } = null;
        

[JsonProperty(PropertyName="surface_layer_penetration_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> SurfaceLayerPenetrationDepth { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="deep_layer_penetration_depth", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> DeepLayerPenetrationDepth { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="coating_layer_thickness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoatingLayerThickness { get; set; } = null;
        

[Description("The coating\'s resistance to water vapor diffusion relative to the resistance to w" +
    "ater vapor diffusion in stagnant air (see Water Vapor Diffusion Resistance Facto" +
    "r above).")]
[JsonProperty(PropertyName="coating_layer_water_vapor_diffusion_resistance_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoatingLayerWaterVaporDiffusionResistanceFactor { get; set; } = null;
    }
    
    [Description(@"Additional properties for temperature dependent thermal conductivity and enthalpy for Phase Change Materials (PCM) HeatBalanceAlgorithm = CondFD(ConductionFiniteDifference) solution algorithm only. Constructions with this should use the detailed CondFD process. Has no effect with other HeatBalanceAlgorithm solution algorithms")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class MaterialProperty_PhaseChange
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("The base temperature is 20C. This is the thermal conductivity change per degree e" +
    "xcursion from 20C. This variable conductivity function is overridden by the Vari" +
    "ableThermalConductivity object, if present.")]
[JsonProperty(PropertyName="temperature_coefficient_for_thermal_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureCoefficientForThermalConductivity { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("for Temperature-enthalpy function")]
[JsonProperty(PropertyName="temperature_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature1 { get; set; } = null;
        

[Description("for Temperature-enthalpy function corresponding to temperature 1")]
[JsonProperty(PropertyName="enthalpy_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Enthalpy1 { get; set; } = null;
        

[Description("for Temperature-enthalpy function")]
[JsonProperty(PropertyName="temperature_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature2 { get; set; } = null;
        

[Description("for Temperature-enthalpy function corresponding to temperature 2")]
[JsonProperty(PropertyName="enthalpy_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Enthalpy2 { get; set; } = null;
        

[Description("for Temperature-enthalpy function")]
[JsonProperty(PropertyName="temperature_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature3 { get; set; } = null;
        

[Description("for Temperature-enthalpy function corresponding to temperature 3")]
[JsonProperty(PropertyName="enthalpy_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Enthalpy3 { get; set; } = null;
        

[Description("for Temperature-enthalpy function")]
[JsonProperty(PropertyName="temperature_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature4 { get; set; } = null;
        

[Description("for Temperature-enthalpy function corresponding to temperature 4")]
[JsonProperty(PropertyName="enthalpy_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Enthalpy4 { get; set; } = null;
        

[Description("for Temperature-enthalpy function")]
[JsonProperty(PropertyName="temperature_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature5 { get; set; } = null;
        

[Description("for Temperature-enthalpy function corresponding to temperature 5")]
[JsonProperty(PropertyName="enthalpy_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Enthalpy5 { get; set; } = null;
        

[Description("for Temperature-enthalpy function")]
[JsonProperty(PropertyName="temperature_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature6 { get; set; } = null;
        

[Description("for Temperature-enthalpy function corresponding to temperature 6")]
[JsonProperty(PropertyName="enthalpy_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Enthalpy6 { get; set; } = null;
        

[Description("for Temperature-enthalpy function")]
[JsonProperty(PropertyName="temperature_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature7 { get; set; } = null;
        

[Description("for Temperature-enthalpy function corresponding to temperature 7")]
[JsonProperty(PropertyName="enthalpy_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Enthalpy7 { get; set; } = null;
        

[Description("for Temperature-enthalpy function")]
[JsonProperty(PropertyName="temperature_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature8 { get; set; } = null;
        

[Description("for Temperature-enthalpy function corresponding to temperature 8")]
[JsonProperty(PropertyName="enthalpy_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Enthalpy8 { get; set; } = null;
        

[Description("for Temperature-enthalpy function")]
[JsonProperty(PropertyName="temperature_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature9 { get; set; } = null;
        

[Description("for Temperature-enthalpy function corresponding to temperature 1")]
[JsonProperty(PropertyName="enthalpy_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Enthalpy9 { get; set; } = null;
        

[Description("for Temperature-enthalpy function")]
[JsonProperty(PropertyName="temperature_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature10 { get; set; } = null;
        

[Description("for Temperature-enthalpy function corresponding to temperature 2")]
[JsonProperty(PropertyName="enthalpy_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Enthalpy10 { get; set; } = null;
        

[Description("for Temperature-enthalpy function")]
[JsonProperty(PropertyName="temperature_11", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature11 { get; set; } = null;
        

[Description("for Temperature-enthalpy function corresponding to temperature 3")]
[JsonProperty(PropertyName="enthalpy_11", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Enthalpy11 { get; set; } = null;
        

[Description("for Temperature-enthalpy function")]
[JsonProperty(PropertyName="temperature_12", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature12 { get; set; } = null;
        

[Description("for Temperature-enthalpy function corresponding to temperature 14")]
[JsonProperty(PropertyName="enthalpy_12", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Enthalpy12 { get; set; } = null;
        

[Description("for Temperature-enthalpy function")]
[JsonProperty(PropertyName="temperature_13", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature13 { get; set; } = null;
        

[Description("for Temperature-enthalpy function corresponding to temperature 15")]
[JsonProperty(PropertyName="enthalpy_13", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Enthalpy13 { get; set; } = null;
        

[Description("for Temperature-enthalpy function")]
[JsonProperty(PropertyName="temperature_14", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature14 { get; set; } = null;
        

[Description("for Temperature-enthalpy function corresponding to temperature 16")]
[JsonProperty(PropertyName="enthalpy_14", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Enthalpy14 { get; set; } = null;
        

[Description("for Temperature-enthalpy function")]
[JsonProperty(PropertyName="temperature_15", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature15 { get; set; } = null;
        

[Description("for Temperature-enthalpy function corresponding to temperature 17")]
[JsonProperty(PropertyName="enthalpy_15", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Enthalpy15 { get; set; } = null;
        

[Description("for Temperature-enthalpy function")]
[JsonProperty(PropertyName="temperature_16", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature16 { get; set; } = null;
        

[Description("for Temperature-enthalpy function corresponding to temperature 16")]
[JsonProperty(PropertyName="enthalpy_16", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Enthalpy16 { get; set; } = null;
    }
    
    [Description(@"Additional properties for temperature dependent thermal conductivity and enthalpy for Phase Change Materials (PCM) with separate melting and freezing curves. HeatBalanceAlgorithm = CondFD (ConductionFiniteDifference) solution algorithm only. Constructions with this should use the detailed CondFD process. Has no effect with other HeatBalanceAlgorithm solution algorithms.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class MaterialProperty_PhaseChangeHysteresis
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("The total latent heat absorbed or rejected during the transition from solid to li" +
    "quid, or back")]
[JsonProperty(PropertyName="latent_heat_during_the_entire_phase_change_process", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LatentHeatDuringTheEntirePhaseChangeProcess { get; set; } = null;
        

[Description("The thermal conductivity used by this material when the material is fully liquid")]
[JsonProperty(PropertyName="liquid_state_thermal_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidStateThermalConductivity { get; set; } = null;
        

[Description("The density used by this material when the material is fully liquid")]
[JsonProperty(PropertyName="liquid_state_density", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidStateDensity { get; set; } = null;
        

[Description("The constant specific heat used for the fully melted (liquid) state")]
[JsonProperty(PropertyName="liquid_state_specific_heat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidStateSpecificHeat { get; set; } = null;
        

[Description("The total melting range of the material is the sum of low and high temperature di" +
    "fference of melting curve.")]
[JsonProperty(PropertyName="high_temperature_difference_of_melting_curve", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HighTemperatureDifferenceOfMeltingCurve { get; set; } = null;
        

[Description("The temperature at which the melting curve peaks")]
[JsonProperty(PropertyName="peak_melting_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PeakMeltingTemperature { get; set; } = null;
        

[Description("The total melting range of the material is the sum of low and high temperature di" +
    "fference of melting curve.")]
[JsonProperty(PropertyName="low_temperature_difference_of_melting_curve", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LowTemperatureDifferenceOfMeltingCurve { get; set; } = null;
        

[Description("The thermal conductivity used by this material when the material is fully solid")]
[JsonProperty(PropertyName="solid_state_thermal_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SolidStateThermalConductivity { get; set; } = null;
        

[Description("The density used by this material when the material is fully solid")]
[JsonProperty(PropertyName="solid_state_density", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SolidStateDensity { get; set; } = null;
        

[Description("The constant specific heat used for the fully frozen (crystallized) state")]
[JsonProperty(PropertyName="solid_state_specific_heat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SolidStateSpecificHeat { get; set; } = null;
        

[Description("The total freezing range of the material is the sum of low and high temperature d" +
    "ifference of freezing curve.")]
[JsonProperty(PropertyName="high_temperature_difference_of_freezing_curve", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HighTemperatureDifferenceOfFreezingCurve { get; set; } = null;
        

[Description("The temperature at which the freezing curve peaks")]
[JsonProperty(PropertyName="peak_freezing_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PeakFreezingTemperature { get; set; } = null;
        

[Description("The total freezing range of the material is the sum of low and high temperature d" +
    "ifference of freezing curve.")]
[JsonProperty(PropertyName="low_temperature_difference_of_freezing_curve", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LowTemperatureDifferenceOfFreezingCurve { get; set; } = null;
    }
    
    [Description(@"Additional properties for temperature dependent thermal conductivity using piecewise linear temperature-conductivity function. HeatBalanceAlgorithm = CondFD(ConductionFiniteDifference) solution algorithm only. Has no effect with other HeatBalanceAlgorithm solution algorithms")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class MaterialProperty_VariableThermalConductivity
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("for Temperature-Thermal Conductivity function")]
[JsonProperty(PropertyName="temperature_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature1 { get; set; } = null;
        

[Description("for Temperature-Thermal Conductivity function corresponding to temperature 1")]
[JsonProperty(PropertyName="thermal_conductivity_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity1 { get; set; } = null;
        

[Description("for Temperature-Thermal Conductivity function")]
[JsonProperty(PropertyName="temperature_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature2 { get; set; } = null;
        

[Description("for Temperature-Thermal Conductivity function corresponding to temperature 2")]
[JsonProperty(PropertyName="thermal_conductivity_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity2 { get; set; } = null;
        

[Description("for Temperature-Thermal Conductivity function")]
[JsonProperty(PropertyName="temperature_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature3 { get; set; } = null;
        

[Description("for Temperature-Thermal Conductivity function corresponding to temperature 3")]
[JsonProperty(PropertyName="thermal_conductivity_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity3 { get; set; } = null;
        

[Description("for Temperature-Thermal Conductivity function")]
[JsonProperty(PropertyName="temperature_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature4 { get; set; } = null;
        

[Description("for Temperature-Thermal Conductivity function corresponding to temperature 4")]
[JsonProperty(PropertyName="thermal_conductivity_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity4 { get; set; } = null;
        

[Description("for Temperature-Thermal Conductivity function")]
[JsonProperty(PropertyName="temperature_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature5 { get; set; } = null;
        

[Description("for Temperature-Thermal Conductivity function corresponding to temperature 5")]
[JsonProperty(PropertyName="thermal_conductivity_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity5 { get; set; } = null;
        

[Description("for Temperature-Thermal Conductivity function")]
[JsonProperty(PropertyName="temperature_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature6 { get; set; } = null;
        

[Description("for Temperature-Thermal Conductivity function corresponding to temperature 6")]
[JsonProperty(PropertyName="thermal_conductivity_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity6 { get; set; } = null;
        

[Description("for Temperature-Thermal Conductivity function")]
[JsonProperty(PropertyName="temperature_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature7 { get; set; } = null;
        

[Description("for Temperature-Thermal Conductivity function corresponding to temperature 7")]
[JsonProperty(PropertyName="thermal_conductivity_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity7 { get; set; } = null;
        

[Description("for Temperature-Thermal Conductivity function")]
[JsonProperty(PropertyName="temperature_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature8 { get; set; } = null;
        

[Description("for Temperature-Thermal Conductivity function corresponding to temperature 8")]
[JsonProperty(PropertyName="thermal_conductivity_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity8 { get; set; } = null;
        

[Description("for Temperature-Thermal Conductivity function")]
[JsonProperty(PropertyName="temperature_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature9 { get; set; } = null;
        

[Description("for Temperature-Thermal Conductivity function corresponding to temperature 9")]
[JsonProperty(PropertyName="thermal_conductivity_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity9 { get; set; } = null;
        

[Description("for Temperature-Thermal Conductivity function")]
[JsonProperty(PropertyName="temperature_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Temperature10 { get; set; } = null;
        

[Description("for Temperature-Thermal Conductivity function corresponding to temperature 10")]
[JsonProperty(PropertyName="thermal_conductivity_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity10 { get; set; } = null;
    }
    
    [Description("HeatBalanceAlgorithm = CombinedHeatAndMoistureFiniteElement solution algorithm on" +
        "ly. Additional material properties for surfaces. Has no effect with other HeatBa" +
        "lanceAlgorithm solution algorithms")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class MaterialProperty_HeatAndMoistureTransfer_Settings
    {
        

[Description("Material Name that the moisture properties will be added to. This augments materi" +
    "al properties needed for combined heat and moisture transfer for surfaces.")]
[JsonProperty(PropertyName="material_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaterialName { get; set; } = "";
        

[JsonProperty(PropertyName="porosity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Porosity { get; set; } = null;
        

[Description("units are the water/material density ratio at the beginning of each run period.")]
[JsonProperty(PropertyName="initial_water_content_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InitialWaterContentRatio { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
    }
    
    [Description("HeatBalanceAlgorithm = CombinedHeatAndMoistureFiniteElement solution algorithm on" +
        "ly. Relationship between moisture content and relative humidity fraction. Has no" +
        " effect with other HeatBalanceAlgorithm solution algorithms")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class MaterialProperty_HeatAndMoistureTransfer_SorptionIsotherm
    {
        

[Description("The Material Name that the moisture sorption isotherm will be added to.")]
[JsonProperty(PropertyName="material_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaterialName { get; set; } = "";
        

[Description("Number of data Coordinates")]
[JsonProperty(PropertyName="number_of_isotherm_coordinates", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfIsothermCoordinates { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction1 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent1 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction2 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent2 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction3 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent3 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction4 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent4 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction5 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent5 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction6 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent6 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction7 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent7 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction8 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent8 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction9 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent9 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction10 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent10 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_11", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction11 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_11", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent11 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_12", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction12 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_12", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent12 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_13", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction13 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_13", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent13 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_14", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction14 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_14", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent14 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_15", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction15 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_15", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent15 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_16", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction16 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_16", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent16 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_17", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction17 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_17", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent17 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_18", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction18 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_18", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent18 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_19", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction19 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_19", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent19 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_20", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction20 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_20", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent20 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_21", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction21 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_21", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent21 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_22", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction22 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_22", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent22 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_23", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction23 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_23", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent23 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_24", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction24 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_24", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent24 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_25", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction25 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_25", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent25 { get; set; } = null;
    }
    
    [Description("HeatBalanceAlgorithm = CombinedHeatAndMoistureFiniteElement solution algorithm on" +
        "ly. Relationship between liquid suction transport coefficient and moisture conte" +
        "nt Has no effect with other HeatBalanceAlgorithm solution algorithms")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class MaterialProperty_HeatAndMoistureTransfer_Suction
    {
        

[Description("Material Name that the moisture properties will be added to.")]
[JsonProperty(PropertyName="material_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaterialName { get; set; } = "";
        

[Description("Number of Suction Liquid Transport Coefficient coordinates")]
[JsonProperty(PropertyName="number_of_suction_points", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfSuctionPoints { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent1 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient1 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent2 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient2 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent3 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient3 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent4 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient4 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent5 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient5 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent6 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient6 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent7 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient7 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent8 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient8 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent9 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient9 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent10 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient10 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_11", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent11 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_11", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient11 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_12", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent12 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_12", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient12 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_13", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent13 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_13", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient13 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_14", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent14 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_14", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient14 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_15", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent15 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_15", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient15 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_16", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent16 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_16", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient16 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_17", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent17 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_17", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient17 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_18", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent18 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_18", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient18 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_19", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent19 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_19", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient19 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_20", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent20 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_20", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient20 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_21", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent21 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_21", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient21 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_22", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent22 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_22", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient22 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_23", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent23 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_23", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient23 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_24", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent24 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_24", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient24 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_25", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent25 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_25", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient25 { get; set; } = null;
    }
    
    [Description("HeatBalanceAlgorithm = CombinedHeatAndMoistureFiniteElement solution algorithm on" +
        "ly. Relationship between liquid transport coefficient and moisture content Has n" +
        "o effect with other HeatBalanceAlgorithm solution algorithms")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class MaterialProperty_HeatAndMoistureTransfer_Redistribution
    {
        

[Description("Moisture Material Name that the moisture properties will be added to.")]
[JsonProperty(PropertyName="material_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaterialName { get; set; } = "";
        

[Description("number of data points")]
[JsonProperty(PropertyName="number_of_redistribution_points", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfRedistributionPoints { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent1 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient1 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent2 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient2 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent3 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient3 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent4 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient4 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent5 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient5 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent6 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient6 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent7 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient7 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent8 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient8 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent9 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient9 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent10 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient10 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_11", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent11 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_11", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient11 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_12", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent12 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_12", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient12 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_13", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent13 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_13", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient13 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_14", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent14 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_14", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient14 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_15", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent15 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_15", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient15 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_16", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent16 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_16", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient16 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_17", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent17 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_17", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient17 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_18", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent18 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_18", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient18 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_19", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent19 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_19", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient19 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_20", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent20 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_20", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient20 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_21", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent21 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_21", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient21 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_22", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent22 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_22", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient22 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_23", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent23 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_23", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient23 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_24", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent24 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_24", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient24 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_25", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent25 { get; set; } = null;
        

[JsonProperty(PropertyName="liquid_transport_coefficient_25", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LiquidTransportCoefficient25 { get; set; } = null;
    }
    
    [Description("HeatBalanceAlgorithm = CombinedHeatAndMoistureFiniteElement solution algorithm on" +
        "ly. Relationship between water vapor diffusion and relative humidity fraction Ha" +
        "s no effect with other HeatBalanceAlgorithm solution algorithms")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class MaterialProperty_HeatAndMoistureTransfer_Diffusion
    {
        

[Description("Moisture Material Name that the moisture properties will be added to.")]
[JsonProperty(PropertyName="material_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaterialName { get; set; } = "";
        

[Description("Water Vapor Diffusion Resistance Factor")]
[JsonProperty(PropertyName="number_of_data_pairs", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfDataPairs { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction1 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor1 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction2 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor2 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction3 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor3 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction4 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor4 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction5 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor5 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction6 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor6 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction7 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor7 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction8 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor8 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction9 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor9 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction10 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor10 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_11", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction11 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_11", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor11 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_12", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction12 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_12", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor12 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_13", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction13 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_13", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor13 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_14", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction14 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_14", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor14 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_15", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction15 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_15", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor15 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_16", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction16 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_16", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor16 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_17", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction17 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_17", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor17 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_18", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction18 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_18", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor18 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_19", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction19 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_19", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor19 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_20", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction20 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_20", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor20 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_21", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction21 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_21", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor21 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_22", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction22 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_22", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor22 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_23", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction23 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_23", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor23 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_24", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction24 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_24", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor24 { get; set; } = null;
        

[Description("The relative humidity is entered as a fraction.")]
[JsonProperty(PropertyName="relative_humidity_fraction_25", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RelativeHumidityFraction25 { get; set; } = null;
        

[JsonProperty(PropertyName="water_vapor_diffusion_resistance_factor_25", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> WaterVaporDiffusionResistanceFactor25 { get; set; } = null;
    }
    
    [Description("HeatBalanceAlgorithm = CombinedHeatAndMoistureFiniteElement solution algorithm on" +
        "ly. Relationship between thermal conductivity and moisture content Has no effect" +
        " with other HeatBalanceAlgorithm solution algorithms")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class MaterialProperty_HeatAndMoistureTransfer_ThermalConductivity
    {
        

[Description("Moisture Material Name that the Thermal Conductivity will be added to.")]
[JsonProperty(PropertyName="material_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaterialName { get; set; } = "";
        

[Description("number of data coordinates")]
[JsonProperty(PropertyName="number_of_thermal_coordinates", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfThermalCoordinates { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent1 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity1 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent2 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity2 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent3 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity3 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent4 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity4 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent5 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity5 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent6 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity6 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent7 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity7 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent8 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity8 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent9 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity9 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent10 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity10 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_11", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent11 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_11", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity11 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_12", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent12 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_12", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity12 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_13", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent13 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_13", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity13 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_14", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent14 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_14", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity14 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_15", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent15 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_15", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity15 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_16", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent16 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_16", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity16 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_17", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent17 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_17", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity17 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_18", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent18 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_18", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity18 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_19", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent19 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_19", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity19 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_20", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent20 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_20", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity20 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_21", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent21 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_21", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity21 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_22", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent22 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_22", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity22 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_23", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent23 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_23", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity23 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_24", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent24 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_24", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity24 { get; set; } = null;
        

[JsonProperty(PropertyName="moisture_content_25", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MoistureContent25 { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conductivity_25", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalConductivity25 { get; set; } = null;
    }
    
    [Description("Name is followed by up to 800 sets of normal-incidence measured values of [wavele" +
        "ngth, transmittance, front reflectance, back reflectance] for wavelengths coveri" +
        "ng the solar spectrum (from about 0.25 to 2.5 microns)")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class MaterialProperty_GlazingSpectralData
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="wavelength_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Wavelength1 { get; set; } = null;
        

[JsonProperty(PropertyName="transmittance_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Transmittance1 { get; set; } = null;
        

[JsonProperty(PropertyName="front_reflectance_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontReflectance1 { get; set; } = null;
        

[JsonProperty(PropertyName="back_reflectance_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackReflectance1 { get; set; } = null;
        

[JsonProperty(PropertyName="wavelength_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Wavelength2 { get; set; } = null;
        

[JsonProperty(PropertyName="transmittance_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Transmittance2 { get; set; } = null;
        

[JsonProperty(PropertyName="front_reflectance_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontReflectance2 { get; set; } = null;
        

[JsonProperty(PropertyName="back_reflectance_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackReflectance2 { get; set; } = null;
        

[JsonProperty(PropertyName="wavelength_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Wavelength3 { get; set; } = null;
        

[JsonProperty(PropertyName="transmittance_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Transmittance3 { get; set; } = null;
        

[JsonProperty(PropertyName="front_reflectance_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontReflectance3 { get; set; } = null;
        

[JsonProperty(PropertyName="back_reflectance_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackReflectance3 { get; set; } = null;
        

[JsonProperty(PropertyName="wavelength_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Wavelength4 { get; set; } = null;
        

[JsonProperty(PropertyName="transmittance_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Transmittance4 { get; set; } = null;
        

[JsonProperty(PropertyName="front_reflectance_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontReflectance4 { get; set; } = null;
        

[JsonProperty(PropertyName="back_reflectance_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackReflectance4 { get; set; } = null;
        

[JsonProperty(PropertyName="extensions", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.MaterialProperty_GlazingSpectralData_Extensions_Item> Extensions { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class MaterialProperty_GlazingSpectralData_Extensions_Item
    {
        

[JsonProperty(PropertyName="wavelength", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Wavelength { get; set; } = null;
        

[JsonProperty(PropertyName="transmittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Transmittance { get; set; } = null;
        

[JsonProperty(PropertyName="front_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontReflectance { get; set; } = null;
        

[JsonProperty(PropertyName="back_reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BackReflectance { get; set; } = null;
    }
    
    [Description("Start with outside layer and work your way to the inside layer Up to 10 layers to" +
        "tal, 8 for windows Enter the material name for each layer")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Construction
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="outside_layer", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutsideLayer { get; set; } = "";
        

[JsonProperty(PropertyName="layer_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer2 { get; set; } = "";
        

[JsonProperty(PropertyName="layer_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer3 { get; set; } = "";
        

[JsonProperty(PropertyName="layer_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer4 { get; set; } = "";
        

[JsonProperty(PropertyName="layer_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer5 { get; set; } = "";
        

[JsonProperty(PropertyName="layer_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer6 { get; set; } = "";
        

[JsonProperty(PropertyName="layer_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer7 { get; set; } = "";
        

[JsonProperty(PropertyName="layer_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer8 { get; set; } = "";
        

[JsonProperty(PropertyName="layer_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer9 { get; set; } = "";
        

[JsonProperty(PropertyName="layer_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer10 { get; set; } = "";
    }
    
    [Description("Alternate method of describing underground wall constructions")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Construction_CfactorUndergroundWall
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Enter C-Factor without film coefficients or soil")]
[JsonProperty(PropertyName="c_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CFactor { get; set; } = null;
        

[Description("Enter height of the underground wall")]
[JsonProperty(PropertyName="height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Height { get; set; } = null;
    }
    
    [Description("Alternate method of describing slab-on-grade or underground floor constructions")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Construction_FfactorGroundFloor
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="f_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FFactor { get; set; } = null;
        

[Description("Enter area of the floor")]
[JsonProperty(PropertyName="area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Area { get; set; } = null;
        

[Description("Enter exposed perimeter of the floor")]
[JsonProperty(PropertyName="perimeterexposed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Perimeterexposed { get; set; } = null;
    }
    
    [Description("Internal heat source to be attached to a construction layer")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ConstructionProperty_InternalHeatSource
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="construction_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ConstructionName { get; set; } = "";
        

[Description("refers to the list of materials which follows")]
[JsonProperty(PropertyName="thermal_source_present_after_layer_number", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalSourcePresentAfterLayerNumber { get; set; } = null;
        

[Description("refers to the list of materials which follows")]
[JsonProperty(PropertyName="temperature_calculation_requested_after_layer_number", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TemperatureCalculationRequestedAfterLayerNumber { get; set; } = null;
        

[Description("1 = 1-dimensional calculation, 2 = 2-dimensional calculation")]
[JsonProperty(PropertyName="dimensions_for_the_ctf_calculation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DimensionsForTheCtfCalculation { get; set; } = null;
        

[Description("uniform spacing between tubes or resistance wires in direction perpendicular to m" +
    "ain intended direction of heat transfer")]
[JsonProperty(PropertyName="tube_spacing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TubeSpacing { get; set; } = null;
        

[Description(@"used in conjunction with field Temperature Calculation Requested After Layer Number this field is the location perpendicular to the main direction of heat transfer 0.0 means in line with the tubing, 1.0 means at the midpoint between two adjacent pipes this field is ignored for 1-D calculations")]
[JsonProperty(PropertyName="two_dimensional_temperature_calculation_position", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TwoDimensionalTemperatureCalculationPosition { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
    }
    
    [Description(@"Indicates an open boundary between two zones. It may be used for base surfaces and fenestration surfaces. The two adjacent zones are grouped together for solar, daylighting and radiant exchange. When this construction type is used, the Outside Boundary Condition of the surface (or the base surface of a fenestration surface) must be either Surface or Zone. A base surface with Construction:AirBoundary cannot hold any fenestration surfaces.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Construction_AirBoundary
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("This field controls how air exchange is modeled across this boundary.")]
[JsonProperty(PropertyName="air_exchange_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Construction_AirBoundary_AirExchangeMethod AirExchangeMethod { get; set; } = (Construction_AirBoundary_AirExchangeMethod)Enum.Parse(typeof(Construction_AirBoundary_AirExchangeMethod), "None");
        

[Description("If the Air Exchange Method is SimpleMixing then this field specifies the air chan" +
    "ges per hour using the volume of the smaller zone as the basis. If an AirflowNet" +
    "work simulation is active this field is ignored.")]
[JsonProperty(PropertyName="simple_mixing_air_changes_per_hour", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SimpleMixingAirChangesPerHour { get; set; } = Double.Parse("0.5", CultureInfo.InvariantCulture);
        

[Description("If the Air Exchange Method is SimpleMixing then this field specifies the air exch" +
    "ange schedule. If this field is blank, the schedule is always 1.0. If an Airflow" +
    "Network simulation is active this field is ignored.")]
[JsonProperty(PropertyName="simple_mixing_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SimpleMixingScheduleName { get; set; } = "";
    }
    
    public enum Construction_AirBoundary_AirExchangeMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SimpleMixing")]
        SimpleMixing = 2,
    }
    
    [Description("object is used to select which thermal model should be used in tarcog simulations" +
        "")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowThermalModel_Params
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="standard", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowThermalModel_Params_Standard Standard { get; set; } = (WindowThermalModel_Params_Standard)Enum.Parse(typeof(WindowThermalModel_Params_Standard), "ISO15099");
        

[JsonProperty(PropertyName="thermal_model", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowThermalModel_Params_ThermalModel ThermalModel { get; set; } = (WindowThermalModel_Params_ThermalModel)Enum.Parse(typeof(WindowThermalModel_Params_ThermalModel), "ISO15099");
        

[JsonProperty(PropertyName="sdscalar", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Sdscalar { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="deflection_model", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowThermalModel_Params_DeflectionModel DeflectionModel { get; set; } = (WindowThermalModel_Params_DeflectionModel)Enum.Parse(typeof(WindowThermalModel_Params_DeflectionModel), "NoDeflection");
        

[JsonProperty(PropertyName="vacuum_pressure_limit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> VacuumPressureLimit { get; set; } = Double.Parse("13.238", CultureInfo.InvariantCulture);
        

[Description("This is temperature in time of window fabrication")]
[JsonProperty(PropertyName="initial_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InitialTemperature { get; set; } = Double.Parse("25", CultureInfo.InvariantCulture);
        

[Description("This is pressure in time of window fabrication")]
[JsonProperty(PropertyName="initial_pressure", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> InitialPressure { get; set; } = Double.Parse("101325", CultureInfo.InvariantCulture);
    }
    
    public enum WindowThermalModel_Params_Standard
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="EN673Declared")]
        EN673Declared = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="EN673Design")]
        EN673Design = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099")]
        ISO15099 = 3,
    }
    
    public enum WindowThermalModel_Params_ThermalModel
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ConvectiveScalarModel_NoSDThickness")]
        ConvectiveScalarModelNoSDThickness = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ConvectiveScalarModel_withSDThickness")]
        ConvectiveScalarModelWithSDThickness = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ISO15099")]
        ISO15099 = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ScaledCavityWidth")]
        ScaledCavityWidth = 4,
    }
    
    public enum WindowThermalModel_Params_DeflectionModel
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MeasuredDeflection")]
        MeasuredDeflection = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="NoDeflection")]
        NoDeflection = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="TemperatureAndPressureInput")]
        TemperatureAndPressureInput = 3,
    }
    
    [Description(@"Describes which window model will be used in calculations. Built in windows model will use algorithms that are part of EnergyPlus, while ExternalWindowsModel will use Windows-CalcEngine library to perform optical and thermal performances of windows and doors.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class WindowsCalculationEngine
    {
        

[JsonProperty(PropertyName="windows_engine", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public WindowsCalculationEngine_WindowsEngine WindowsEngine { get; set; } = (WindowsCalculationEngine_WindowsEngine)Enum.Parse(typeof(WindowsCalculationEngine_WindowsEngine), "BuiltInWindowsModel");
    }
    
    public enum WindowsCalculationEngine_WindowsEngine
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BuiltInWindowsModel")]
        BuiltInWindowsModel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ExternalWindowsModel")]
        ExternalWindowsModel = 2,
    }
    
    [Description("Describes one state for a complex glazing system These input objects are typicall" +
        "y generated by using WINDOW software and export to IDF syntax")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Construction_ComplexFenestrationState
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="basis_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Construction_ComplexFenestrationState_BasisType BasisType { get; set; } = (Construction_ComplexFenestrationState_BasisType)Enum.Parse(typeof(Construction_ComplexFenestrationState_BasisType), "LBNLWINDOW");
        

[JsonProperty(PropertyName="basis_symmetry_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Construction_ComplexFenestrationState_BasisSymmetryType BasisSymmetryType { get; set; } = (Construction_ComplexFenestrationState_BasisSymmetryType)Enum.Parse(typeof(Construction_ComplexFenestrationState_BasisSymmetryType), "None");
        

[JsonProperty(PropertyName="window_thermal_model", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WindowThermalModel { get; set; } = "";
        

[JsonProperty(PropertyName="basis_matrix_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BasisMatrixName { get; set; } = "";
        

[JsonProperty(PropertyName="solar_optical_complex_front_transmittance_matrix_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SolarOpticalComplexFrontTransmittanceMatrixName { get; set; } = "";
        

[JsonProperty(PropertyName="solar_optical_complex_back_reflectance_matrix_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SolarOpticalComplexBackReflectanceMatrixName { get; set; } = "";
        

[JsonProperty(PropertyName="visible_optical_complex_front_transmittance_matrix_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string VisibleOpticalComplexFrontTransmittanceMatrixName { get; set; } = "";
        

[JsonProperty(PropertyName="visible_optical_complex_back_transmittance_matrix_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string VisibleOpticalComplexBackTransmittanceMatrixName { get; set; } = "";
        

[JsonProperty(PropertyName="outside_layer_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutsideLayerName { get; set; } = "";
        

[JsonProperty(PropertyName="outside_layer_directional_front_absoptance_matrix_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutsideLayerDirectionalFrontAbsoptanceMatrixName { get; set; } = "";
        

[JsonProperty(PropertyName="outside_layer_directional_back_absoptance_matrix_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutsideLayerDirectionalBackAbsoptanceMatrixName { get; set; } = "";
        

[JsonProperty(PropertyName="gap_1_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Gap1Name { get; set; } = "";
        

[Description("Reserved for future use. Leave it blank for this version")]
[JsonProperty(PropertyName="cfs_gap_1_directional_front_absoptance_matrix_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CfsGap1DirectionalFrontAbsoptanceMatrixName { get; set; } = "";
        

[Description("Reserved for future use. Leave it blank for this version")]
[JsonProperty(PropertyName="cfs_gap_1_directional_back_absoptance_matrix_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CfsGap1DirectionalBackAbsoptanceMatrixName { get; set; } = "";
        

[JsonProperty(PropertyName="layer_2_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer2Name { get; set; } = "";
        

[JsonProperty(PropertyName="layer_2_directional_front_absoptance_matrix_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer2DirectionalFrontAbsoptanceMatrixName { get; set; } = "";
        

[JsonProperty(PropertyName="layer_2_directional_back_absoptance_matrix_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer2DirectionalBackAbsoptanceMatrixName { get; set; } = "";
        

[JsonProperty(PropertyName="gap_2_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Gap2Name { get; set; } = "";
        

[Description("Reserved for future use. Leave it blank for this version")]
[JsonProperty(PropertyName="gap_2_directional_front_absoptance_matrix_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Gap2DirectionalFrontAbsoptanceMatrixName { get; set; } = "";
        

[Description("Reserved for future use. Leave it blank for this version")]
[JsonProperty(PropertyName="gap_2_directional_back_absoptance_matrix_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Gap2DirectionalBackAbsoptanceMatrixName { get; set; } = "";
        

[JsonProperty(PropertyName="layer_3_material", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer3Material { get; set; } = "";
        

[JsonProperty(PropertyName="layer_3_directional_front_absoptance_matrix_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer3DirectionalFrontAbsoptanceMatrixName { get; set; } = "";
        

[JsonProperty(PropertyName="layer_3_directional_back_absoptance_matrix_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer3DirectionalBackAbsoptanceMatrixName { get; set; } = "";
        

[JsonProperty(PropertyName="gap_3_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Gap3Name { get; set; } = "";
        

[Description("Reserved for future use. Leave it blank for this version")]
[JsonProperty(PropertyName="gap_3_directional_front_absoptance_matrix_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Gap3DirectionalFrontAbsoptanceMatrixName { get; set; } = "";
        

[Description("Reserved for future use. Leave it blank for this version")]
[JsonProperty(PropertyName="gap_3_directional_back_absoptance_matrix_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Gap3DirectionalBackAbsoptanceMatrixName { get; set; } = "";
        

[JsonProperty(PropertyName="layer_4_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer4Name { get; set; } = "";
        

[JsonProperty(PropertyName="layer_4_directional_front_absoptance_matrix_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer4DirectionalFrontAbsoptanceMatrixName { get; set; } = "";
        

[JsonProperty(PropertyName="layer_4_directional_back_absoptance_matrix_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer4DirectionalBackAbsoptanceMatrixName { get; set; } = "";
        

[JsonProperty(PropertyName="gap_4_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Gap4Name { get; set; } = "";
        

[Description("Reserved for future use. Leave it blank for this version")]
[JsonProperty(PropertyName="gap_4_directional_front_absoptance_matrix_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Gap4DirectionalFrontAbsoptanceMatrixName { get; set; } = "";
        

[Description("Reserved for future use. Leave it blank for this version")]
[JsonProperty(PropertyName="gap_4_directional_back_absoptance_matrix_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Gap4DirectionalBackAbsoptanceMatrixName { get; set; } = "";
        

[JsonProperty(PropertyName="layer_5_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer5Name { get; set; } = "";
        

[JsonProperty(PropertyName="layer_5_directional_front_absoptance_matrix_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer5DirectionalFrontAbsoptanceMatrixName { get; set; } = "";
        

[JsonProperty(PropertyName="layer_5_directional_back_absoptance_matrix_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer5DirectionalBackAbsoptanceMatrixName { get; set; } = "";
    }
    
    public enum Construction_ComplexFenestrationState_BasisType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="LBNLWINDOW")]
        LBNLWINDOW = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UserDefined")]
        UserDefined = 2,
    }
    
    public enum Construction_ComplexFenestrationState_BasisSymmetryType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Axisymmetric")]
        Axisymmetric = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
    }
    
    [Description("Start with outside layer and work your way to the inside Layer Up to 11 layers to" +
        "tal. Up to six solid layers and up to five gaps. Enter the material name for eac" +
        "h layer")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Construction_WindowEquivalentLayer
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="outside_layer", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutsideLayer { get; set; } = "";
        

[JsonProperty(PropertyName="layer_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer2 { get; set; } = "";
        

[JsonProperty(PropertyName="layer_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer3 { get; set; } = "";
        

[JsonProperty(PropertyName="layer_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer4 { get; set; } = "";
        

[JsonProperty(PropertyName="layer_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer5 { get; set; } = "";
        

[JsonProperty(PropertyName="layer_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer6 { get; set; } = "";
        

[JsonProperty(PropertyName="layer_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer7 { get; set; } = "";
        

[JsonProperty(PropertyName="layer_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer8 { get; set; } = "";
        

[JsonProperty(PropertyName="layer_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer9 { get; set; } = "";
        

[JsonProperty(PropertyName="layer_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer10 { get; set; } = "";
        

[JsonProperty(PropertyName="layer_11", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Layer11 { get; set; } = "";
    }
    
    [Description("Initiates search of the Window data file for a window called Name.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Construction_WindowDataFile
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("default file name is \"Window5DataFile.dat\" limit on this field is 100 characters." +
    "")]
[JsonProperty(PropertyName="file_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FileName { get; set; } = "";
    }
}
