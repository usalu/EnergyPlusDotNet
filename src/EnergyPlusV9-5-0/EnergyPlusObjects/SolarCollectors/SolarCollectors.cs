namespace EnergyPlus.SolarCollectors
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
    
    
    [Description(@"Thermal and optical performance parameters for a single flat plate solar collector module. These parameters are based on the testing methodologies described in ASHRAE Standards 93 and 96 which are used Solar Rating and Certification Corporation (SRCC) Directory of SRCC Certified Solar Collector Ratings. See EnergyPlus DataSets file SolarCollectors.idf.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SolarCollectorPerformance_FlatPlate
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="gross_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GrossArea { get; set; } = null;
        

[JsonProperty(PropertyName="test_fluid", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SolarCollectorPerformance_FlatPlate_TestFluid TestFluid { get; set; } = (SolarCollectorPerformance_FlatPlate_TestFluid)Enum.Parse(typeof(SolarCollectorPerformance_FlatPlate_TestFluid), "Water");
        

[JsonProperty(PropertyName="test_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TestFlowRate { get; set; } = null;
        

[JsonProperty(PropertyName="test_correlation_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SolarCollectorPerformance_FlatPlate_TestCorrelationType TestCorrelationType { get; set; } = (SolarCollectorPerformance_FlatPlate_TestCorrelationType)Enum.Parse(typeof(SolarCollectorPerformance_FlatPlate_TestCorrelationType), "Average");
        

[Description("Y-intercept term")]
[JsonProperty(PropertyName="coefficient_1_of_efficiency_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1OfEfficiencyEquation { get; set; } = null;
        

[Description("1st Order term")]
[JsonProperty(PropertyName="coefficient_2_of_efficiency_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2OfEfficiencyEquation { get; set; } = null;
        

[Description("2nd order term")]
[JsonProperty(PropertyName="coefficient_3_of_efficiency_equation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3OfEfficiencyEquation { get; set; } = null;
        

[Description("1st order term")]
[JsonProperty(PropertyName="coefficient_2_of_incident_angle_modifier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2OfIncidentAngleModifier { get; set; } = null;
        

[Description("2nd order term")]
[JsonProperty(PropertyName="coefficient_3_of_incident_angle_modifier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3OfIncidentAngleModifier { get; set; } = null;
    }
    
    public enum SolarCollectorPerformance_FlatPlate_TestFluid
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Water")]
        Water = 1,
    }
    
    public enum SolarCollectorPerformance_FlatPlate_TestCorrelationType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Average")]
        Average = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Inlet")]
        Inlet = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Outlet")]
        Outlet = 2,
    }
    
    [Description(@"Flat plate water solar collector (single glazed, unglazed, or evacuated tube). Thermal and optical properties are taken from the referenced SolarCollectorPerformance:FlatPlate object. Collector tilt, azimuth, and gross area are taken from the referenced building surface or shading surface. The collector surface participates normally in all shading calculations.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SolarCollector_FlatPlate_Water
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="solarcollectorperformance_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SolarcollectorperformanceName { get; set; } = "";
        

[JsonProperty(PropertyName="surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceName { get; set; } = "";
        

[JsonProperty(PropertyName="inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumFlowRate { get; set; } = null;
    }
    
    [Description("Models hybrid photovoltaic-thermal (PVT) solar collectors that convert incident s" +
        "olar energy into both electricity and useful thermal energy by heating air or wa" +
        "ter.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SolarCollector_FlatPlate_PhotovoltaicThermal
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceName { get; set; } = "";
        

[JsonProperty(PropertyName="photovoltaic_thermal_model_performance_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PhotovoltaicThermalModelPerformanceName { get; set; } = "";
        

[Description("Enter the name of a Generator:Photovoltaic object.")]
[JsonProperty(PropertyName="photovoltaic_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PhotovoltaicName { get; set; } = "";
        

[JsonProperty(PropertyName="thermal_working_fluid_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SolarCollector_FlatPlate_PhotovoltaicThermal_ThermalWorkingFluidType ThermalWorkingFluidType { get; set; } = (SolarCollector_FlatPlate_PhotovoltaicThermal_ThermalWorkingFluidType)Enum.Parse(typeof(SolarCollector_FlatPlate_PhotovoltaicThermal_ThermalWorkingFluidType), "Air");
        

[JsonProperty(PropertyName="water_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="water_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="air_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="air_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AirOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="design_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> DesignFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
    }
    
    public enum SolarCollector_FlatPlate_PhotovoltaicThermal_ThermalWorkingFluidType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Air")]
        Air = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Water")]
        Water = 1,
    }
    
    [Description("Thermal performance parameters for a hybrid photovoltaic-thermal (PVT) solar coll" +
        "ector.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SolarCollectorPerformance_PhotovoltaicThermal_Simple
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="fraction_of_surface_area_with_active_thermal_collector", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfSurfaceAreaWithActiveThermalCollector { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conversion_efficiency_input_mode_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SolarCollectorPerformance_PhotovoltaicThermal_Simple_ThermalConversionEfficiencyInputModeType ThermalConversionEfficiencyInputModeType { get; set; } = (SolarCollectorPerformance_PhotovoltaicThermal_Simple_ThermalConversionEfficiencyInputModeType)Enum.Parse(typeof(SolarCollectorPerformance_PhotovoltaicThermal_Simple_ThermalConversionEfficiencyInputModeType), "Fixed");
        

[Description("Efficiency = (thermal power generated [W])/(incident solar[W])")]
[JsonProperty(PropertyName="value_for_thermal_conversion_efficiency_if_fixed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ValueForThermalConversionEfficiencyIfFixed { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_conversion_efficiency_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ThermalConversionEfficiencyScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="front_surface_emittance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FrontSurfaceEmittance { get; set; } = Double.Parse("0.84", CultureInfo.InvariantCulture);
    }
    
    public enum SolarCollectorPerformance_PhotovoltaicThermal_Simple_ThermalConversionEfficiencyInputModeType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Fixed")]
        Fixed = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Scheduled")]
        Scheduled = 1,
    }
    
    [Description(@"Glazed solar collector with integral storage unit. Thermal and optical properties are taken from the referenced SolarCollectorPerformance:IntegralCollectorStorage object. Collector tilt, azimuth, and gross area are taken from the referenced building surface or shading surface. The collector surface participates normally in all shading calculations.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SolarCollector_IntegralCollectorStorage
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="integralcollectorstorageparameters_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string IntegralcollectorstorageparametersName { get; set; } = "";
        

[JsonProperty(PropertyName="surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceName { get; set; } = "";
        

[JsonProperty(PropertyName="bottom_surface_boundary_conditions_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SolarCollector_IntegralCollectorStorage_BottomSurfaceBoundaryConditionsType BottomSurfaceBoundaryConditionsType { get; set; } = (SolarCollector_IntegralCollectorStorage_BottomSurfaceBoundaryConditionsType)Enum.Parse(typeof(SolarCollector_IntegralCollectorStorage_BottomSurfaceBoundaryConditionsType), "AmbientAir");
        

[Description("Enter the name of a SurfaceProperty:OtherSideConditionsModel object. Specified on" +
    "ly if the boundary condition type is OtherSideConditionsModel, otherwise leave i" +
    "t blank")]
[JsonProperty(PropertyName="boundary_condition_model_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BoundaryConditionModelName { get; set; } = "";
        

[JsonProperty(PropertyName="inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumFlowRate { get; set; } = null;
    }
    
    public enum SolarCollector_IntegralCollectorStorage_BottomSurfaceBoundaryConditionsType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="AmbientAir")]
        AmbientAir = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherSideConditionsModel")]
        OtherSideConditionsModel = 2,
    }
    
    [Description("Thermal and optical performance parameters for a single glazed solar collector wi" +
        "th integral storage unit.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SolarCollectorPerformance_IntegralCollectorStorage
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Currently only RectangularTank ICS collector type is available.")]
[JsonProperty(PropertyName="ics_collector_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SolarCollectorPerformance_IntegralCollectorStorage_IcsCollectorType IcsCollectorType { get; set; } = (SolarCollectorPerformance_IntegralCollectorStorage_IcsCollectorType)Enum.Parse(typeof(SolarCollectorPerformance_IntegralCollectorStorage_IcsCollectorType), "RectangularTank");
        

[JsonProperty(PropertyName="gross_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> GrossArea { get; set; } = null;
        

[JsonProperty(PropertyName="collector_water_volume", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CollectorWaterVolume { get; set; } = null;
        

[Description("Heat loss conductance of the collector bottom insulation")]
[JsonProperty(PropertyName="bottom_heat_loss_conductance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BottomHeatLossConductance { get; set; } = Double.Parse("0.4", CultureInfo.InvariantCulture);
        

[Description("heat loss conductance of the collector side insulation")]
[JsonProperty(PropertyName="side_heat_loss_conductance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SideHeatLossConductance { get; set; } = Double.Parse("0.6", CultureInfo.InvariantCulture);
        

[Description("This value is ratio of the width (short side) to length (long side of) of the col" +
    "lector. Used to calculate the perimeter of the collector")]
[JsonProperty(PropertyName="aspect_ratio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AspectRatio { get; set; } = Double.Parse("0.8", CultureInfo.InvariantCulture);
        

[Description("This value is used to estimate collector side area for the heat loss calculation " +
    "through the collector side")]
[JsonProperty(PropertyName="collector_side_height", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CollectorSideHeight { get; set; } = Double.Parse("0.2", CultureInfo.InvariantCulture);
        

[Description("Calculated from the specific heat, density and thickness of the absorber plate.")]
[JsonProperty(PropertyName="thermal_mass_of_absorber_plate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalMassOfAbsorberPlate { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Number of transparent covers. Common practice is to use low-iron glass as the out" +
    "er cover and very thin transparent sheet such as Teflon as the inner cover.")]
[JsonProperty(PropertyName="number_of_covers", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfCovers { get; set; } = Double.Parse("2", CultureInfo.InvariantCulture);
        

[Description("The gap between the transparent covers and between the inner cover and the absorb" +
    "er plate")]
[JsonProperty(PropertyName="cover_spacing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoverSpacing { get; set; } = Double.Parse("0.05", CultureInfo.InvariantCulture);
        

[Description("Refractive index of outer cover. Typically low-iron glass is used as the outer co" +
    "ver material, and used as the default outer cover with a value of 1.526.")]
[JsonProperty(PropertyName="refractive_index_of_outer_cover", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RefractiveIndexOfOuterCover { get; set; } = Double.Parse("1.526", CultureInfo.InvariantCulture);
        

[Description("Clear glass has extinction coefficient of about 15 [1/m] and with thickness of 3." +
    "0mm, the product of the extinction coefficient and thickness becomes 0.045 (=15 " +
    "* 0.003)")]
[JsonProperty(PropertyName="extinction_coefficient_times_thickness_of_outer_cover", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ExtinctionCoefficientTimesThicknessOfOuterCover { get; set; } = Double.Parse("0.045", CultureInfo.InvariantCulture);
        

[Description("Thermal emissivity of the outer cover, commonly glass is used as the out collecto" +
    "r cover material.")]
[JsonProperty(PropertyName="emissivity_of_outer_cover", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EmissivityOfOuterCover { get; set; } = Double.Parse("0.88", CultureInfo.InvariantCulture);
        

[Description("Typical material is very thin sheet of Teflon (PTFE). The default value is refrac" +
    "tive index of Teflon.")]
[JsonProperty(PropertyName="refractive_index_of_inner_cover", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RefractiveIndexOfInnerCover { get; set; } = Double.Parse("1.37", CultureInfo.InvariantCulture);
        

[Description("Default inner cover is very thin sheet of Teflon with extinction coefficient of a" +
    "pproximately 40.0 and a thickness 0.2mm yields a default value of 0.008.")]
[JsonProperty(PropertyName="extinction_coefficient_times_thickness_of_the_inner_cover", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ExtinctionCoefficientTimesThicknessOfTheInnerCover { get; set; } = Double.Parse("0.008", CultureInfo.InvariantCulture);
        

[Description("Thermal emissivity of the inner cover material")]
[JsonProperty(PropertyName="emissivity_of_inner_cover", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EmissivityOfInnerCover { get; set; } = Double.Parse("0.88", CultureInfo.InvariantCulture);
        

[Description("The absorber plate solar absorptance. Copper is assumed as the default absorber p" +
    "late.")]
[JsonProperty(PropertyName="absorptance_of_absorber_plate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AbsorptanceOfAbsorberPlate { get; set; } = Double.Parse("0.96", CultureInfo.InvariantCulture);
        

[Description("Thermal emissivity of the absorber plate")]
[JsonProperty(PropertyName="emissivity_of_absorber_plate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EmissivityOfAbsorberPlate { get; set; } = Double.Parse("0.3", CultureInfo.InvariantCulture);
    }
    
    public enum SolarCollectorPerformance_IntegralCollectorStorage_IcsCollectorType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="RectangularTank")]
        RectangularTank = 1,
    }
    
    [Description(@"Unglazed transpired solar collector (UTSC) used to condition outdoor air. This type of collector is generally used to heat air drawn through perforated absorbers and also recover heat conducted out through the underlying surface. This object represents a single collector attached to one or more building or shading surfaces and to one or more outdoor air systems.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SolarCollector_UnglazedTranspired
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Enter the name of a SurfaceProperty:OtherSideConditionsModel object")]
[JsonProperty(PropertyName="boundary_conditions_model_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BoundaryConditionsModelName { get; set; } = "";
        

[Description("Availability schedule name for this collector. Schedule value > 0 means it is ava" +
    "ilable. If this field is blank, the collector is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("required field if no SolarCollector:UnglazedTranspired:Multisystem")]
[JsonProperty(PropertyName="inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletNodeName { get; set; } = "";
        

[Description("required field if no SolarCollector:UnglazedTranspired:Multisystem")]
[JsonProperty(PropertyName="outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutletNodeName { get; set; } = "";
        

[Description("This node is where the mixed air setpoint is determined. required field if no Sol" +
    "arCollector:UnglazedTranspired:Multisystem")]
[JsonProperty(PropertyName="setpoint_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SetpointNodeName { get; set; } = "";
        

[Description("This node is used to identify the affected zone required field if no SolarCollect" +
    "or:UnglazedTranspired:Multisystem")]
[JsonProperty(PropertyName="zone_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="free_heating_setpoint_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FreeHeatingSetpointScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="diameter_of_perforations_in_collector", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DiameterOfPerforationsInCollector { get; set; } = null;
        

[JsonProperty(PropertyName="distance_between_perforations_in_collector", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DistanceBetweenPerforationsInCollector { get; set; } = null;
        

[JsonProperty(PropertyName="thermal_emissivity_of_collector_surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ThermalEmissivityOfCollectorSurface { get; set; } = null;
        

[JsonProperty(PropertyName="solar_absorbtivity_of_collector_surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SolarAbsorbtivityOfCollectorSurface { get; set; } = null;
        

[JsonProperty(PropertyName="effective_overall_height_of_collector", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EffectiveOverallHeightOfCollector { get; set; } = null;
        

[Description("if corrugated, use average depth")]
[JsonProperty(PropertyName="effective_gap_thickness_of_plenum_behind_collector", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EffectiveGapThicknessOfPlenumBehindCollector { get; set; } = null;
        

[Description("if corrugated, use average depth")]
[JsonProperty(PropertyName="effective_cross_section_area_of_plenum_behind_collector", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EffectiveCrossSectionAreaOfPlenumBehindCollector { get; set; } = null;
        

[JsonProperty(PropertyName="hole_layout_pattern_for_pitch", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SolarCollector_UnglazedTranspired_HoleLayoutPatternForPitch HoleLayoutPatternForPitch { get; set; } = (SolarCollector_UnglazedTranspired_HoleLayoutPatternForPitch)Enum.Parse(typeof(SolarCollector_UnglazedTranspired_HoleLayoutPatternForPitch), "Square");
        

[JsonProperty(PropertyName="heat_exchange_effectiveness_correlation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SolarCollector_UnglazedTranspired_HeatExchangeEffectivenessCorrelation HeatExchangeEffectivenessCorrelation { get; set; } = (SolarCollector_UnglazedTranspired_HeatExchangeEffectivenessCorrelation)Enum.Parse(typeof(SolarCollector_UnglazedTranspired_HeatExchangeEffectivenessCorrelation), "Kutscher1994");
        

[Description("This parameter is used to help account for corrugations in the collector")]
[JsonProperty(PropertyName="ratio_of_actual_collector_surface_area_to_projected_surface_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatioOfActualCollectorSurfaceAreaToProjectedSurfaceArea { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="roughness_of_collector", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public SolarCollector_UnglazedTranspired_RoughnessOfCollector RoughnessOfCollector { get; set; } = (SolarCollector_UnglazedTranspired_RoughnessOfCollector)Enum.Parse(typeof(SolarCollector_UnglazedTranspired_RoughnessOfCollector), "MediumRough");
        

[Description("Collector thickness is not required for Kutscher correlation Collector thickness " +
    "is required for Van Decker et al. correlation")]
[JsonProperty(PropertyName="collector_thickness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CollectorThickness { get; set; } = null;
        

[Description("Cv")]
[JsonProperty(PropertyName="effectiveness_for_perforations_with_respect_to_wind", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EffectivenessForPerforationsWithRespectToWind { get; set; } = Double.Parse("0.25", CultureInfo.InvariantCulture);
        

[Description("Cd")]
[JsonProperty(PropertyName="discharge_coefficient_for_openings_with_respect_to_buoyancy_driven_flow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DischargeCoefficientForOpeningsWithRespectToBuoyancyDrivenFlow { get; set; } = Double.Parse("0.65", CultureInfo.InvariantCulture);
        

[Description("This list is the AllShadingAndHTSurfNames object-list")]
[JsonProperty(PropertyName="surfaces", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<string> Surfaces { get; set; } = null;
    }
    
    public enum SolarCollector_UnglazedTranspired_HoleLayoutPatternForPitch
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Square")]
        Square = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Triangle")]
        Triangle = 2,
    }
    
    public enum SolarCollector_UnglazedTranspired_HeatExchangeEffectivenessCorrelation
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Kutscher1994")]
        Kutscher1994 = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="VanDeckerHollandsBrunger2001")]
        VanDeckerHollandsBrunger2001 = 2,
    }
    
    public enum SolarCollector_UnglazedTranspired_RoughnessOfCollector
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
    
    [Description("quad-tuples of inlet, outlet, control, and zone nodes for multiple different outd" +
        "oor air systems attached to same collector")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SolarCollector_UnglazedTranspired_Multisystem
    {
        

[Description("Enter the name of a SolarCollector:UnglazedTranspired object.")]
[JsonProperty(PropertyName="solar_collector_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SolarCollectorName { get; set; } = "";
        

[JsonProperty(PropertyName="systems", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SolarCollectors.SolarCollector_UnglazedTranspired_Multisystem_Systems_Item> Systems { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class SolarCollector_UnglazedTranspired_Multisystem_Systems_Item
    {
        

[JsonProperty(PropertyName="outdoor_air_system_collector_inlet_node", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirSystemCollectorInletNode { get; set; } = "";
        

[JsonProperty(PropertyName="outdoor_air_system_collector_outlet_node", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirSystemCollectorOutletNode { get; set; } = "";
        

[JsonProperty(PropertyName="outdoor_air_system_mixed_air_node", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirSystemMixedAirNode { get; set; } = "";
        

[JsonProperty(PropertyName="outdoor_air_system_zone_node", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirSystemZoneNode { get; set; } = "";
    }
}
