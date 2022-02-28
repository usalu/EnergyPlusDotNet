namespace EnergyPlus.ZoneHVACRadiativeConvectiveUnits
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
    
    
    [Description(null)]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_Baseboard_RadiantConvective_Water_Design
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description(@"Enter the method used to determine the heating design capacity. HeatingDesignCapacity = > selected when the design heating capacity value or autosize is specified. CapacityPerFloorArea = > selected when the design heating capacity is determine from user specified heating capacity per floor area and zone floor area. FractionOfAutosizedHeatingCapacity = > is selected when the design heating capacity is determined from a user specified fraction and the auto-sized design heating capacity.")]
[JsonProperty(PropertyName="heating_design_capacity_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_Baseboard_RadiantConvective_Water_Design_HeatingDesignCapacityMethod HeatingDesignCapacityMethod { get; set; } = (ZoneHVAC_Baseboard_RadiantConvective_Water_Design_HeatingDesignCapacityMethod)Enum.Parse(typeof(ZoneHVAC_Baseboard_RadiantConvective_Water_Design_HeatingDesignCapacityMethod), "HeatingDesignCapacity");
        

[Description("Enter the heating design capacity per zone floor area. Required field when the he" +
    "ating design capacity method field is CapacityPerFloorArea.")]
[JsonProperty(PropertyName="heating_design_capacity_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingDesignCapacityPerFloorArea { get; set; } = null;
        

[Description("Enter the fraction of autosized heating design capacity. Required field when capa" +
    "city the heating design capacity method field is FractionOfAutosizedHeatingCapac" +
    "ity.")]
[JsonProperty(PropertyName="fraction_of_autosized_heating_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfAutosizedHeatingDesignCapacity { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="convergence_tolerance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConvergenceTolerance { get; set; } = Double.Parse("0.001", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_radiant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionRadiant { get; set; } = null;
        

[JsonProperty(PropertyName="fraction_of_radiant_energy_incident_on_people", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfRadiantEnergyIncidentOnPeople { get; set; } = null;
    }
    
    public enum ZoneHVAC_Baseboard_RadiantConvective_Water_Design_HeatingDesignCapacityMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CapacityPerFloorArea")]
        CapacityPerFloorArea = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedHeatingCapacity")]
        FractionOfAutosizedHeatingCapacity = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatingDesignCapacity")]
        HeatingDesignCapacity = 3,
    }
    
    [Description("The number of surfaces can be expanded beyond 100, if necessary, by adding more g" +
        "roups to the end of the list")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_Baseboard_RadiantConvective_Water
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="design_object", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignObject { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutletNodeName { get; set; } = "";
        

[Description("Rated average water temperature is the average of the inlet and outlet water temp" +
    "eratures at rated conditions.")]
[JsonProperty(PropertyName="rated_average_water_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedAverageWaterTemperature { get; set; } = Double.Parse("87.78", CultureInfo.InvariantCulture);
        

[Description(@"Standard is I=B=R Rating document where all baseboards are rated at either 0.063 kg/s (1 gpm) or 0.252 kg/s (4 gpm). It is recommended that users find data for the baseboard heater that corresponds to performance at 0.063 kg/s unless the flow rate is expected to be above 0.252 kg/s. If the flow rate is expected to be above 0.252 kg/s, this field should be 0.252 kg/s.")]
[JsonProperty(PropertyName="rated_water_mass_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedWaterMassFlowRate { get; set; } = Double.Parse("0.063", CultureInfo.InvariantCulture);
        

[Description(@"Enter the design heating capacity. Required field when the heating design capacity method HeatingDesignCapacity. This input field is rated heating capacity. Users must multiply the actual finned length published in the literature to determine the rated capacity. Rated Capacity is for an inlet air dry-bulb temperature of 18.0C, the Rated Water Mass Flow Rate of 0.063kg/s or 0.252kg/s, and the Rated Average Water Temperature between 32.2C and 115.6C.")]
[JsonProperty(PropertyName="heating_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingDesignCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_water_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumWaterFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="surface_fractions", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_Baseboard_RadiantConvective_Water_SurfaceFractions_Item> SurfaceFractions { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_Baseboard_RadiantConvective_Water_SurfaceFractions_Item
    {
        

[JsonProperty(PropertyName="surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceName { get; set; } = "";
        

[JsonProperty(PropertyName="fraction_of_radiant_energy_to_surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfRadiantEnergyToSurface { get; set; } = null;
    }
    
    [Description(null)]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_Baseboard_RadiantConvective_Steam_Design
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description(@"Enter the method used to determine the heating design capacity. HeatingDesignCapacity is selected when the design heating capacity value or autosize is specified. CapacityPerFloorArea is selected when the design heating capacity is determine from user specified heating capacity per floor area and zone floor area. FractionOfAutosizedHeatingCapacity is selected when the design heating capacity is determined from a user specified fraction and the auto-sized design heating capacity.")]
[JsonProperty(PropertyName="heating_design_capacity_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_Baseboard_RadiantConvective_Steam_Design_HeatingDesignCapacityMethod HeatingDesignCapacityMethod { get; set; } = (ZoneHVAC_Baseboard_RadiantConvective_Steam_Design_HeatingDesignCapacityMethod)Enum.Parse(typeof(ZoneHVAC_Baseboard_RadiantConvective_Steam_Design_HeatingDesignCapacityMethod), "HeatingDesignCapacity");
        

[Description("Enter the heating design capacity per zone floor area. Required field when the he" +
    "ating design capacity method field is CapacityPerFloorArea.")]
[JsonProperty(PropertyName="heating_design_capacity_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingDesignCapacityPerFloorArea { get; set; } = null;
        

[Description("Enter the fraction of autosized heating design capacity. Required field when capa" +
    "city the heating design capacity method field is FractionOfAutosizedHeatingCapac" +
    "ity.")]
[JsonProperty(PropertyName="fraction_of_autosized_heating_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfAutosizedHeatingDesignCapacity { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="convergence_tolerance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConvergenceTolerance { get; set; } = Double.Parse("0.001", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_radiant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionRadiant { get; set; } = null;
        

[JsonProperty(PropertyName="fraction_of_radiant_energy_incident_on_people", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfRadiantEnergyIncidentOnPeople { get; set; } = null;
    }
    
    public enum ZoneHVAC_Baseboard_RadiantConvective_Steam_Design_HeatingDesignCapacityMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CapacityPerFloorArea")]
        CapacityPerFloorArea = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedHeatingCapacity")]
        FractionOfAutosizedHeatingCapacity = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatingDesignCapacity")]
        HeatingDesignCapacity = 3,
    }
    
    [Description("The number of surfaces can be expanded beyond 100, if necessary, by adding more g" +
        "roups to the end of the list.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_Baseboard_RadiantConvective_Steam
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="design_object", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignObject { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutletNodeName { get; set; } = "";
        

[Description("Enter the design heating capacity. Required field when the heating design capacit" +
    "y method HeatingDesignCapacity.")]
[JsonProperty(PropertyName="heating_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingDesignCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="degree_of_subcooling", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DegreeOfSubcooling { get; set; } = Double.Parse("5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_steam_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumSteamFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="surface_fractions", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_Baseboard_RadiantConvective_Steam_SurfaceFractions_Item> SurfaceFractions { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_Baseboard_RadiantConvective_Steam_SurfaceFractions_Item
    {
        

[JsonProperty(PropertyName="surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceName { get; set; } = "";
        

[JsonProperty(PropertyName="fraction_of_radiant_energy_to_surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfRadiantEnergyToSurface { get; set; } = null;
    }
    
    [Description("The number of surfaces can be expanded beyond 100, if necessary, by adding more g" +
        "roups to the end of the list")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_Baseboard_RadiantConvective_Electric
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description(@"Enter the method used to determine the heating design capacity. HeatingDesignCapacity = > selected when the design heating capacity value or autosize is specified. CapacityPerFloorArea = > selected when the design heating capacity is determine from user specified heating capacity per floor area and zone floor area. FractionOfAutosizedHeatingCapacity = > is selected when the design heating capacity is determined from a user specified fraction and the auto-sized design heating capacity.")]
[JsonProperty(PropertyName="heating_design_capacity_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_Baseboard_RadiantConvective_Electric_HeatingDesignCapacityMethod HeatingDesignCapacityMethod { get; set; } = (ZoneHVAC_Baseboard_RadiantConvective_Electric_HeatingDesignCapacityMethod)Enum.Parse(typeof(ZoneHVAC_Baseboard_RadiantConvective_Electric_HeatingDesignCapacityMethod), "HeatingDesignCapacity");
        

[Description("Enter the design heating capacity. Required field when the heating design capacit" +
    "y method HeatingDesignCapacity.")]
[JsonProperty(PropertyName="heating_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingDesignCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the heating design capacity per zone floor area. Required field when the he" +
    "ating design capacity method field is CapacityPerFloorArea.")]
[JsonProperty(PropertyName="heating_design_capacity_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingDesignCapacityPerFloorArea { get; set; } = null;
        

[Description("Enter the fraction of autosized heating design capacity. Required field when capa" +
    "city the heating design capacity method field is FractionOfAutosizedHeatingCapac" +
    "ity.")]
[JsonProperty(PropertyName="fraction_of_autosized_heating_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfAutosizedHeatingDesignCapacity { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Efficiency { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_radiant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionRadiant { get; set; } = null;
        

[JsonProperty(PropertyName="fraction_of_radiant_energy_incident_on_people", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfRadiantEnergyIncidentOnPeople { get; set; } = null;
        

[JsonProperty(PropertyName="surface_fractions", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_Baseboard_RadiantConvective_Electric_SurfaceFractions_Item> SurfaceFractions { get; set; } = null;
    }
    
    public enum ZoneHVAC_Baseboard_RadiantConvective_Electric_HeatingDesignCapacityMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CapacityPerFloorArea")]
        CapacityPerFloorArea = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedHeatingCapacity")]
        FractionOfAutosizedHeatingCapacity = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatingDesignCapacity")]
        HeatingDesignCapacity = 3,
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_Baseboard_RadiantConvective_Electric_SurfaceFractions_Item
    {
        

[JsonProperty(PropertyName="surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceName { get; set; } = "";
        

[JsonProperty(PropertyName="fraction_of_radiant_energy_to_surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfRadiantEnergyToSurface { get; set; } = null;
    }
    
    [Description("The number of surfaces can be expanded beyond 100, if necessary, by adding more g" +
        "roups to the end of the list")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_CoolingPanel_RadiantConvective_Water
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="water_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="water_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string WaterOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="rated_inlet_water_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedInletWaterTemperature { get; set; } = Double.Parse("5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="rated_inlet_space_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedInletSpaceTemperature { get; set; } = Double.Parse("24", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="rated_water_mass_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedWaterMassFlowRate { get; set; } = Double.Parse("0.063", CultureInfo.InvariantCulture);
        

[Description(@"Enter the method used to determine the cooling design capacity for scalable sizing. CoolingDesignCapacity => selected when the design cooling capacity value is specified or auto-sized. CapacityPerFloorArea => selected when the design cooling capacity is determined from user specified cooling capacity per floor area and total floor area of cooled zone served by the hydrolic unit. FractionOfAutosizedCoolingCapacity => is selected when the design cooling capacity is determined from a user specified fraction and the auto-sized design cooling capacity of the system.")]
[JsonProperty(PropertyName="cooling_design_capacity_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_CoolingPanel_RadiantConvective_Water_CoolingDesignCapacityMethod CoolingDesignCapacityMethod { get; set; } = (ZoneHVAC_CoolingPanel_RadiantConvective_Water_CoolingDesignCapacityMethod)Enum.Parse(typeof(ZoneHVAC_CoolingPanel_RadiantConvective_Water_CoolingDesignCapacityMethod), "CoolingDesignCapacity");
        

[Description("Enter the design cooling capacity. Required field when the cooling design capacit" +
    "y method CoolingDesignCapacity.")]
[JsonProperty(PropertyName="cooling_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingDesignCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the cooling design capacity per total floor area of cooled zones served by " +
    "the unit. Required field when the cooling design capacity method field is Capaci" +
    "tyPerFloorArea.")]
[JsonProperty(PropertyName="cooling_design_capacity_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingDesignCapacityPerFloorArea { get; set; } = null;
        

[Description("Enter the fraction of auto-sized cooling design capacity. Required field when the" +
    " cooling design capacity method field is FractionOfAutosizedCoolingCapacity.")]
[JsonProperty(PropertyName="fraction_of_autosized_cooling_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfAutosizedCoolingDesignCapacity { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_chilled_water_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumChilledWaterFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Temperature on which unit is controlled")]
[JsonProperty(PropertyName="control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_CoolingPanel_RadiantConvective_Water_ControlType ControlType { get; set; } = (ZoneHVAC_CoolingPanel_RadiantConvective_Water_ControlType)Enum.Parse(typeof(ZoneHVAC_CoolingPanel_RadiantConvective_Water_ControlType), "MeanAirTemperature");
        

[JsonProperty(PropertyName="cooling_control_throttling_range", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingControlThrottlingRange { get; set; } = Double.Parse("0.5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cooling_control_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingControlTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="condensation_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_CoolingPanel_RadiantConvective_Water_CondensationControlType CondensationControlType { get; set; } = (ZoneHVAC_CoolingPanel_RadiantConvective_Water_CondensationControlType)Enum.Parse(typeof(ZoneHVAC_CoolingPanel_RadiantConvective_Water_CondensationControlType), "SimpleOff");
        

[JsonProperty(PropertyName="condensation_control_dewpoint_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CondensationControlDewpointOffset { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_radiant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionRadiant { get; set; } = null;
        

[JsonProperty(PropertyName="fraction_of_radiant_energy_incident_on_people", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfRadiantEnergyIncidentOnPeople { get; set; } = null;
        

[JsonProperty(PropertyName="surface_fractions", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_CoolingPanel_RadiantConvective_Water_SurfaceFractions_Item> SurfaceFractions { get; set; } = null;
    }
    
    public enum ZoneHVAC_CoolingPanel_RadiantConvective_Water_CoolingDesignCapacityMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CapacityPerFloorArea")]
        CapacityPerFloorArea = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingDesignCapacity")]
        CoolingDesignCapacity = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedCoolingCapacity")]
        FractionOfAutosizedCoolingCapacity = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum ZoneHVAC_CoolingPanel_RadiantConvective_Water_ControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MeanAirTemperature")]
        MeanAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="MeanRadiantTemperature")]
        MeanRadiantTemperature = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="OperativeTemperature")]
        OperativeTemperature = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorDryBulbTemperature")]
        OutdoorDryBulbTemperature = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorWetBulbTemperature")]
        OutdoorWetBulbTemperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="ZoneConvectiveLoad")]
        ZoneConvectiveLoad = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="ZoneTotalLoad")]
        ZoneTotalLoad = 7,
    }
    
    public enum ZoneHVAC_CoolingPanel_RadiantConvective_Water_CondensationControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Off")]
        Off = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SimpleOff")]
        SimpleOff = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableOff")]
        VariableOff = 3,
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_CoolingPanel_RadiantConvective_Water_SurfaceFractions_Item
    {
        

[JsonProperty(PropertyName="surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceName { get; set; } = "";
        

[JsonProperty(PropertyName="fraction_of_radiant_energy_to_surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfRadiantEnergyToSurface { get; set; } = null;
    }
    
    [Description("Hot water baseboard heater, convection-only. Natural convection hydronic heating " +
        "unit.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_Baseboard_Convective_Water
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string InletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutletNodeName { get; set; } = "";
        

[Description(@"Enter the method used to determine the heating design capacity. HeatingDesignCapacity = > selected when the design heating capacity value or autosize is specified. CapacityPerFloorArea = > selected when the design heating capacity is determine from user specified heating capacity per floor area and zone floor area. FractionOfAutosizedHeatingCapacity = > is selected when the design heating capacity is determined from a user specified fraction and the auto-sized design heating capacity.")]
[JsonProperty(PropertyName="heating_design_capacity_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_Baseboard_Convective_Water_HeatingDesignCapacityMethod HeatingDesignCapacityMethod { get; set; } = (ZoneHVAC_Baseboard_Convective_Water_HeatingDesignCapacityMethod)Enum.Parse(typeof(ZoneHVAC_Baseboard_Convective_Water_HeatingDesignCapacityMethod), "HeatingDesignCapacity");
        

[Description("Enter the design heating capacity. Required field when the heating design capacit" +
    "y method HeatingDesignCapacity.")]
[JsonProperty(PropertyName="heating_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingDesignCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the heating design capacity per zone floor area. Required field when the he" +
    "ating design capacity method field is CapacityPerFloorArea.")]
[JsonProperty(PropertyName="heating_design_capacity_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingDesignCapacityPerFloorArea { get; set; } = null;
        

[Description("Enter the fraction of autosized heating design capacity. Required field when capa" +
    "city the heating design capacity method field is FractionOfAutosizedHeatingCapac" +
    "ity.")]
[JsonProperty(PropertyName="fraction_of_autosized_heating_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfAutosizedHeatingDesignCapacity { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="u_factor_times_area_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> UFactorTimesAreaValue { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_water_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumWaterFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="convergence_tolerance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ConvergenceTolerance { get; set; } = Double.Parse("0.001", CultureInfo.InvariantCulture);
    }
    
    public enum ZoneHVAC_Baseboard_Convective_Water_HeatingDesignCapacityMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CapacityPerFloorArea")]
        CapacityPerFloorArea = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedHeatingCapacity")]
        FractionOfAutosizedHeatingCapacity = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatingDesignCapacity")]
        HeatingDesignCapacity = 3,
    }
    
    [Description("Electric baseboard heater, convection-only. Natural convection electric heating u" +
        "nit.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_Baseboard_Convective_Electric
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description(@"Enter the method used to determine the heating design capacity. HeatingDesignCapacity = > selected when the design heating capacity value or autosize is specified. CapacityPerFloorArea = > selected when the design heating capacity is determine from user specified heating capacity per floor area and zone floor area. FractionOfAutosizedHeatingCapacity = > is selected when the design heating capacity is determined from a user specified fraction and the auto-sized design heating capacity.")]
[JsonProperty(PropertyName="heating_design_capacity_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_Baseboard_Convective_Electric_HeatingDesignCapacityMethod HeatingDesignCapacityMethod { get; set; } = (ZoneHVAC_Baseboard_Convective_Electric_HeatingDesignCapacityMethod)Enum.Parse(typeof(ZoneHVAC_Baseboard_Convective_Electric_HeatingDesignCapacityMethod), "HeatingDesignCapacity");
        

[Description("Enter the design heating capacity. Required field when the heating design capacit" +
    "y method HeatingDesignCapacity.")]
[JsonProperty(PropertyName="heating_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingDesignCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the heating design capacity per zone floor area. Required field when the he" +
    "ating design capacity method field is CapacityPerFloorArea.")]
[JsonProperty(PropertyName="heating_design_capacity_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingDesignCapacityPerFloorArea { get; set; } = null;
        

[Description("Enter the fraction of autosized heating design capacity. Required field when capa" +
    "city the heating design capacity method field is FractionOfAutosizedHeatingCapac" +
    "ity.")]
[JsonProperty(PropertyName="fraction_of_autosized_heating_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfAutosizedHeatingDesignCapacity { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Efficiency { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
    }
    
    public enum ZoneHVAC_Baseboard_Convective_Electric_HeatingDesignCapacityMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CapacityPerFloorArea")]
        CapacityPerFloorArea = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedHeatingCapacity")]
        FractionOfAutosizedHeatingCapacity = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatingDesignCapacity")]
        HeatingDesignCapacity = 3,
    }
    
    [Description("Low temperature hydronic radiant heating and/or cooling system embedded in a buil" +
        "ding surface (wall, ceiling, or floor). Controlled by varying the hot or chilled" +
        " water flow to the unit.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_LowTemperatureRadiant_VariableFlow
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="design_object", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignObject { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("Name of zone system is serving")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Identifies surfaces that radiant system is embedded in. For a system with multipl" +
    "e surfaces, enter the name of a ZoneHVAC:LowTemperatureRadiant:SurfaceGroup obje" +
    "ct.")]
[JsonProperty(PropertyName="surface_name_or_radiant_surface_group_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceNameOrRadiantSurfaceGroupName { get; set; } = "";
        

[Description("(total length of pipe embedded in surface)")]
[JsonProperty(PropertyName="hydronic_tubing_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HydronicTubingLength { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the design heating capacity. Required field when the heating design capacit" +
    "y method HeatingDesignCapacity.")]
[JsonProperty(PropertyName="heating_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingDesignCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_hot_water_flow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumHotWaterFlow { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_water_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingWaterInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="heating_water_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingWaterOutletNodeName { get; set; } = "";
        

[Description("Enter the design cooling capacity. Required field when the cooling design capacit" +
    "y method CoolingDesignCapacity.")]
[JsonProperty(PropertyName="cooling_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> CoolingDesignCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="maximum_cold_water_flow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumColdWaterFlow { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cooling_water_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingWaterInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="cooling_water_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingWaterOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="number_of_circuits", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_LowTemperatureRadiant_VariableFlow_NumberOfCircuits NumberOfCircuits { get; set; } = (ZoneHVAC_LowTemperatureRadiant_VariableFlow_NumberOfCircuits)Enum.Parse(typeof(ZoneHVAC_LowTemperatureRadiant_VariableFlow_NumberOfCircuits), "OnePerSurface");
        

[JsonProperty(PropertyName="circuit_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CircuitLength { get; set; } = Double.Parse("106.7", CultureInfo.InvariantCulture);
    }
    
    public enum ZoneHVAC_LowTemperatureRadiant_VariableFlow_NumberOfCircuits
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CalculateFromCircuitLength")]
        CalculateFromCircuitLength = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="OnePerSurface")]
        OnePerSurface = 2,
    }
    
    [Description(null)]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description(@"This parameter identifies how the heat transfer between fluid being circulated through the radiant system and the radiant system (slab) is modeled. ConvectionOnly means that only convection between the fluid and the inside surface of the pipe is modeled using a conventional equation for flow inside a pipe. ISOStandard models convection between the fluid and the inside of of the pipe and conduction through the pipe material using equations specific to ISO Standard 11855-2.")]
[JsonProperty(PropertyName="fluid_to_radiant_surface_heat_transfer_model", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_FluidToRadiantSurfaceHeatTransferModel FluidToRadiantSurfaceHeatTransferModel { get; set; } = (ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_FluidToRadiantSurfaceHeatTransferModel)Enum.Parse(typeof(ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_FluidToRadiantSurfaceHeatTransferModel), "ConvectionOnly");
        

[JsonProperty(PropertyName="hydronic_tubing_inside_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HydronicTubingInsideDiameter { get; set; } = Double.Parse("0.013", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hydronic_tubing_outside_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HydronicTubingOutsideDiameter { get; set; } = Double.Parse("0.016", CultureInfo.InvariantCulture);
        

[Description("Conductivity of the tubing/piping material")]
[JsonProperty(PropertyName="hydronic_tubing_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HydronicTubingConductivity { get; set; } = Double.Parse("0.35", CultureInfo.InvariantCulture);
        

[Description("(Temperature on which unit is controlled)")]
[JsonProperty(PropertyName="temperature_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_TemperatureControlType TemperatureControlType { get; set; } = (ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_TemperatureControlType)Enum.Parse(typeof(ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_TemperatureControlType), "MeanAirTemperature");
        

[Description("How setpoint temperature is defined")]
[JsonProperty(PropertyName="setpoint_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_SetpointControlType SetpointControlType { get; set; } = (ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_SetpointControlType)Enum.Parse(typeof(ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_SetpointControlType), "HalfFlowPower");
        

[Description(@"Enter the method used to determine the heating design capacity. HeatingDesignCapacity = > selected when the design heating capacity value or autosize is specified. CapacityPerFloorArea = > selected when the design heating capacity is determine from user specified heating capacity per floor area and zone floor area. FractionOfAutosizedHeatingCapacity = > is selected when the design heating capacity is determined from a user specified fraction and the auto-sized design heating capacity.")]
[JsonProperty(PropertyName="heating_design_capacity_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_HeatingDesignCapacityMethod HeatingDesignCapacityMethod { get; set; } = (ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_HeatingDesignCapacityMethod)Enum.Parse(typeof(ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_HeatingDesignCapacityMethod), "HeatingDesignCapacity");
        

[Description("Enter the heating design capacity per zone floor area. Required field when the he" +
    "ating design capacity method field is CapacityPerFloorArea.")]
[JsonProperty(PropertyName="heating_design_capacity_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingDesignCapacityPerFloorArea { get; set; } = null;
        

[Description("Enter the fraction of autosized heating design capacity. Required field when capa" +
    "city the heating design capacity method field is FractionOfAutosizedHeatingCapac" +
    "ity.")]
[JsonProperty(PropertyName="fraction_of_autosized_heating_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfAutosizedHeatingDesignCapacity { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_control_throttling_range", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingControlThrottlingRange { get; set; } = Double.Parse("0.5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_control_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingControlTemperatureScheduleName { get; set; } = "";
        

[Description(@"Enter the method used to determine the cooling design capacity for scalable sizing. CoolingDesignCapacity => selected when the design cooling capacity value is specified or auto-sized. CapacityPerFloorArea => selected when the design cooling capacity is determined from user specified cooling capacity per floor area and total floor area of cooled zone served by the hydrolic unit. FractionOfAutosizedCoolingCapacity => is selected when the design cooling capacity is determined from a user specified fraction and the auto-sized design cooling capacity of the system.")]
[JsonProperty(PropertyName="cooling_design_capacity_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_CoolingDesignCapacityMethod CoolingDesignCapacityMethod { get; set; } = (ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_CoolingDesignCapacityMethod)Enum.Parse(typeof(ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_CoolingDesignCapacityMethod), "CoolingDesignCapacity");
        

[Description("Enter the cooling design capacity per total floor area of cooled zones served by " +
    "the unit. Required field when the cooling design capacity method field is Capaci" +
    "tyPerFloorArea.")]
[JsonProperty(PropertyName="cooling_design_capacity_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingDesignCapacityPerFloorArea { get; set; } = null;
        

[Description("Enter the fraction of auto-sized cooling design capacity. Required field when the" +
    " cooling design capacity method field is FractionOfAutosizedCoolingCapacity.")]
[JsonProperty(PropertyName="fraction_of_autosized_cooling_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfAutosizedCoolingDesignCapacity { get; set; } = null;
        

[JsonProperty(PropertyName="cooling_control_throttling_range", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoolingControlThrottlingRange { get; set; } = Double.Parse("0.5", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="cooling_control_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingControlTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="condensation_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_CondensationControlType CondensationControlType { get; set; } = (ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_CondensationControlType)Enum.Parse(typeof(ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_CondensationControlType), "SimpleOff");
        

[JsonProperty(PropertyName="condensation_control_dewpoint_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CondensationControlDewpointOffset { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Changeover delay schedule name for this system. Schedule value <= 0 allows change" +
    "over with no delay The schedule values are interpretted as hours. If this field " +
    "is blank, the system allows changeover with no delay")]
[JsonProperty(PropertyName="changeover_delay_time_period_schedule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ChangeoverDelayTimePeriodSchedule { get; set; } = "";
    }
    
    public enum ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_FluidToRadiantSurfaceHeatTransferModel
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ConvectionOnly")]
        ConvectionOnly = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ISOStandard")]
        ISOStandard = 2,
    }
    
    public enum ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_TemperatureControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MeanAirTemperature")]
        MeanAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="MeanRadiantTemperature")]
        MeanRadiantTemperature = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="OperativeTemperature")]
        OperativeTemperature = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorDryBulbTemperature")]
        OutdoorDryBulbTemperature = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorWetBulbTemperature")]
        OutdoorWetBulbTemperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="SurfaceFaceTemperature")]
        SurfaceFaceTemperature = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="SurfaceInteriorTemperature")]
        SurfaceInteriorTemperature = 7,
    }
    
    public enum ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_SetpointControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="HalfFlowPower")]
        HalfFlowPower = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ZeroFlowPower")]
        ZeroFlowPower = 2,
    }
    
    public enum ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_HeatingDesignCapacityMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CapacityPerFloorArea")]
        CapacityPerFloorArea = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedHeatingCapacity")]
        FractionOfAutosizedHeatingCapacity = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatingDesignCapacity")]
        HeatingDesignCapacity = 3,
    }
    
    public enum ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_CoolingDesignCapacityMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CapacityPerFloorArea")]
        CapacityPerFloorArea = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CoolingDesignCapacity")]
        CoolingDesignCapacity = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedCoolingCapacity")]
        FractionOfAutosizedCoolingCapacity = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 4,
    }
    
    public enum ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_CondensationControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Off")]
        Off = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SimpleOff")]
        SimpleOff = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableOff")]
        VariableOff = 3,
    }
    
    [Description("Low temperature hydronic radiant heating and/or cooling system embedded in a buil" +
        "ding surface (wall, ceiling, or floor). Controlled by varying the hot or chilled" +
        " water temperature circulating through the unit.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_LowTemperatureRadiant_ConstantFlow
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="design_object", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignObject { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("Name of zone system is serving")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Identifies surfaces that radiant system is embedded in. For a system with multipl" +
    "e surfaces, enter the name of a ZoneHVAC:LowTemperatureRadiant:SurfaceGroup obje" +
    "ct.")]
[JsonProperty(PropertyName="surface_name_or_radiant_surface_group_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceNameOrRadiantSurfaceGroupName { get; set; } = "";
        

[Description("(total length of pipe embedded in surface)")]
[JsonProperty(PropertyName="hydronic_tubing_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HydronicTubingLength { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="rated_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> RatedFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description(@"Modifies the Rated Flow Rate of the pump on a time basis the default is that the pump is ON and runs according to its other operational requirements specified above. The schedule is for special pump operations. Values here are between 0 and 1 and are multipliers on the previous field (Rated Flow Rate).")]
[JsonProperty(PropertyName="pump_flow_rate_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PumpFlowRateScheduleName { get; set; } = "";
        

[Description("default head is 60 feet")]
[JsonProperty(PropertyName="rated_pump_head", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedPumpHead { get; set; } = Double.Parse("179352", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="rated_power_consumption", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RatedPowerConsumption { get; set; } = null;
        

[JsonProperty(PropertyName="heating_water_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingWaterInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="heating_water_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingWaterOutletNodeName { get; set; } = "";
        

[Description(@"Water and control temperatures for heating work together to provide a linear function that determines the water temperature sent to the radiant system. The current control temperature (see Temperature Control Type above) is compared to the high and low control temperatures at the current time. If the control temperature is above the high temperature, then the inlet water temperature is set to the low water temperature. If the control temperature is below the low temperature, then the inlet water temperature is set to the high water temperature. If the control temperature is between the high and low value, then the inlet water temperature is linearly interpolated between the low and high water temperature values.")]
[JsonProperty(PropertyName="heating_high_water_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingHighWaterTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="heating_low_water_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingLowWaterTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="heating_high_control_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingHighControlTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="heating_low_control_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingLowControlTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="cooling_water_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingWaterInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="cooling_water_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingWaterOutletNodeName { get; set; } = "";
        

[Description("See note for Heating High Water Temperature Schedule above for interpretation inf" +
    "ormation (or see the Input/Output Reference).")]
[JsonProperty(PropertyName="cooling_high_water_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingHighWaterTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="cooling_low_water_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingLowWaterTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="cooling_high_control_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingHighControlTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="cooling_low_control_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingLowControlTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="number_of_circuits", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_LowTemperatureRadiant_ConstantFlow_NumberOfCircuits NumberOfCircuits { get; set; } = (ZoneHVAC_LowTemperatureRadiant_ConstantFlow_NumberOfCircuits)Enum.Parse(typeof(ZoneHVAC_LowTemperatureRadiant_ConstantFlow_NumberOfCircuits), "OnePerSurface");
        

[JsonProperty(PropertyName="circuit_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CircuitLength { get; set; } = Double.Parse("106.7", CultureInfo.InvariantCulture);
    }
    
    public enum ZoneHVAC_LowTemperatureRadiant_ConstantFlow_NumberOfCircuits
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CalculateFromCircuitLength")]
        CalculateFromCircuitLength = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="OnePerSurface")]
        OnePerSurface = 2,
    }
    
    [Description(null)]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_LowTemperatureRadiant_ConstantFlow_Design
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description(@"This parameter identifies how the heat transfer between fluid being circulated through the radiant system and the radiant system (slab) is modeled. ConvectionOnly means that only convection between the fluid and the inside surface of the pipe is modeled using a conventional equation for flow inside a pipe. ISOStandard models convection between the fluid and the inside of of the pipe and conduction through the pipe material using equations specific to ISO Standard 11855-2.")]
[JsonProperty(PropertyName="fluid_to_radiant_surface_heat_transfer_model", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_LowTemperatureRadiant_ConstantFlow_Design_FluidToRadiantSurfaceHeatTransferModel FluidToRadiantSurfaceHeatTransferModel { get; set; } = (ZoneHVAC_LowTemperatureRadiant_ConstantFlow_Design_FluidToRadiantSurfaceHeatTransferModel)Enum.Parse(typeof(ZoneHVAC_LowTemperatureRadiant_ConstantFlow_Design_FluidToRadiantSurfaceHeatTransferModel), "ConvectionOnly");
        

[JsonProperty(PropertyName="hydronic_tubing_inside_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HydronicTubingInsideDiameter { get; set; } = Double.Parse("0.013", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="hydronic_tubing_outside_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HydronicTubingOutsideDiameter { get; set; } = Double.Parse("0.016", CultureInfo.InvariantCulture);
        

[Description("Conductivity of the tubing/piping material")]
[JsonProperty(PropertyName="hydronic_tubing_conductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HydronicTubingConductivity { get; set; } = Double.Parse("0.35", CultureInfo.InvariantCulture);
        

[Description("Temperature used to control system")]
[JsonProperty(PropertyName="temperature_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_LowTemperatureRadiant_ConstantFlow_Design_TemperatureControlType TemperatureControlType { get; set; } = (ZoneHVAC_LowTemperatureRadiant_ConstantFlow_Design_TemperatureControlType)Enum.Parse(typeof(ZoneHVAC_LowTemperatureRadiant_ConstantFlow_Design_TemperatureControlType), "MeanAirTemperature");
        

[Description(@"this is the weighting factor in the equation that calculate the running mean outdoor dry-bulb temperature as a weighted average of the previous dayâ€™s running mean outdoor dry-bulb temperature and the previous dayâ€™s average outdoor dry-bulb temperature this value is only used by EnergyPlus when the user elects to use the RunningMeanOutdoorDryBulbTemperature control type")]
[JsonProperty(PropertyName="running_mean_outdoor_dry_bulb_temperature_weighting_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RunningMeanOutdoorDryBulbTemperatureWeightingFactor { get; set; } = Double.Parse("0.8", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="motor_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MotorEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_of_motor_inefficiencies_to_fluid_stream", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfMotorInefficienciesToFluidStream { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="condensation_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_LowTemperatureRadiant_ConstantFlow_Design_CondensationControlType CondensationControlType { get; set; } = (ZoneHVAC_LowTemperatureRadiant_ConstantFlow_Design_CondensationControlType)Enum.Parse(typeof(ZoneHVAC_LowTemperatureRadiant_ConstantFlow_Design_CondensationControlType), "SimpleOff");
        

[JsonProperty(PropertyName="condensation_control_dewpoint_offset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CondensationControlDewpointOffset { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Changeover delay schedule name for this system. Schedule value <= 0 allows change" +
    "over with no delay The schedule values are interpretted as hours. If this field " +
    "is blank, the system allows changeover with no delay")]
[JsonProperty(PropertyName="changeover_delay_time_period_schedule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ChangeoverDelayTimePeriodSchedule { get; set; } = "";
    }
    
    public enum ZoneHVAC_LowTemperatureRadiant_ConstantFlow_Design_FluidToRadiantSurfaceHeatTransferModel
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ConvectionOnly")]
        ConvectionOnly = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ISOStandard")]
        ISOStandard = 2,
    }
    
    public enum ZoneHVAC_LowTemperatureRadiant_ConstantFlow_Design_TemperatureControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MeanAirTemperature")]
        MeanAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="MeanRadiantTemperature")]
        MeanRadiantTemperature = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="OperativeTemperature")]
        OperativeTemperature = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorDryBulbTemperature")]
        OutdoorDryBulbTemperature = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorWetBulbTemperature")]
        OutdoorWetBulbTemperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="RunningMeanOutdoorDryBulbTemperature")]
        RunningMeanOutdoorDryBulbTemperature = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="SurfaceFaceTemperature")]
        SurfaceFaceTemperature = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="SurfaceInteriorTemperature")]
        SurfaceInteriorTemperature = 8,
    }
    
    public enum ZoneHVAC_LowTemperatureRadiant_ConstantFlow_Design_CondensationControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Off")]
        Off = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SimpleOff")]
        SimpleOff = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="VariableOff")]
        VariableOff = 3,
    }
    
    [Description("Electric resistance low temperature radiant system")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_LowTemperatureRadiant_Electric
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("Name of zone system is serving")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Identifies surfaces that radiant system is embedded in. For a system with multipl" +
    "e surfaces, enter the name of a ZoneHVAC:LowTemperatureRadiant:SurfaceGroup obje" +
    "ct.")]
[JsonProperty(PropertyName="surface_name_or_radiant_surface_group_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceNameOrRadiantSurfaceGroupName { get; set; } = "";
        

[Description(@"Enter the method used to determine the maximum electrical heating design capacity. HeatingDesignCapacity = > selected when the design heating capacity value or autosize is specified. CapacityPerFloorArea = > selected when the design heating capacity is determine from user specified heating capacity per floor area and zone floor area. FractionOfAutosizedHeatingCapacity = > is selected when the design heating capacity is determined from a user specified fraction and the auto-sized design heating capacity.")]
[JsonProperty(PropertyName="heating_design_capacity_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_LowTemperatureRadiant_Electric_HeatingDesignCapacityMethod HeatingDesignCapacityMethod { get; set; } = (ZoneHVAC_LowTemperatureRadiant_Electric_HeatingDesignCapacityMethod)Enum.Parse(typeof(ZoneHVAC_LowTemperatureRadiant_Electric_HeatingDesignCapacityMethod), "HeatingDesignCapacity");
        

[Description("Enter the design heating capacity. Required field when the heating design capacit" +
    "y method HeatingDesignCapacity.")]
[JsonProperty(PropertyName="heating_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingDesignCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the heating design capacity per zone floor area. Required field when the he" +
    "ating design capacity method field is CapacityPerFloorArea.")]
[JsonProperty(PropertyName="heating_design_capacity_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingDesignCapacityPerFloorArea { get; set; } = null;
        

[Description("Enter the fraction of autosized heating design capacity. Required field when capa" +
    "city the heating design capacity method field is FractionOfAutosizedHeatingCapac" +
    "ity.")]
[JsonProperty(PropertyName="fraction_of_autosized_heating_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfAutosizedHeatingDesignCapacity { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Temperature used to control unit")]
[JsonProperty(PropertyName="temperature_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_LowTemperatureRadiant_Electric_TemperatureControlType TemperatureControlType { get; set; } = (ZoneHVAC_LowTemperatureRadiant_Electric_TemperatureControlType)Enum.Parse(typeof(ZoneHVAC_LowTemperatureRadiant_Electric_TemperatureControlType), "MeanAirTemperature");
        

[Description("How setpoint temperature is defined")]
[JsonProperty(PropertyName="setpoint_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_LowTemperatureRadiant_Electric_SetpointControlType SetpointControlType { get; set; } = (ZoneHVAC_LowTemperatureRadiant_Electric_SetpointControlType)Enum.Parse(typeof(ZoneHVAC_LowTemperatureRadiant_Electric_SetpointControlType), "HalfFlowPower");
        

[JsonProperty(PropertyName="heating_throttling_range", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingThrottlingRange { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="heating_setpoint_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingSetpointTemperatureScheduleName { get; set; } = "";
    }
    
    public enum ZoneHVAC_LowTemperatureRadiant_Electric_HeatingDesignCapacityMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CapacityPerFloorArea")]
        CapacityPerFloorArea = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedHeatingCapacity")]
        FractionOfAutosizedHeatingCapacity = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatingDesignCapacity")]
        HeatingDesignCapacity = 3,
    }
    
    public enum ZoneHVAC_LowTemperatureRadiant_Electric_TemperatureControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MeanAirTemperature")]
        MeanAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="MeanRadiantTemperature")]
        MeanRadiantTemperature = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="OperativeTemperature")]
        OperativeTemperature = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorDryBulbTemperature")]
        OutdoorDryBulbTemperature = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorWetBulbTemperature")]
        OutdoorWetBulbTemperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="SurfaceFaceTemperature")]
        SurfaceFaceTemperature = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="SurfaceInteriorTemperature")]
        SurfaceInteriorTemperature = 7,
    }
    
    public enum ZoneHVAC_LowTemperatureRadiant_Electric_SetpointControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="HalfFlowPower")]
        HalfFlowPower = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ZeroFlowPower")]
        ZeroFlowPower = 2,
    }
    
    [Description("This is used to allow the coordinate control of several radiant system surfaces. " +
        "Note that the following flow fractions must sum up to 1.0 The number of surfaces" +
        " can be expanded beyond 100, if necessary, by adding more groups to the end of t" +
        "he list")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_LowTemperatureRadiant_SurfaceGroup
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="surface_fractions", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_LowTemperatureRadiant_SurfaceGroup_SurfaceFractions_Item> SurfaceFractions { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_LowTemperatureRadiant_SurfaceGroup_SurfaceFractions_Item
    {
        

[JsonProperty(PropertyName="surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceName { get; set; } = "";
        

[JsonProperty(PropertyName="flow_fraction_for_surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FlowFractionForSurface { get; set; } = null;
    }
    
    [Description("The number of surfaces can be expanded beyond 100, if necessary, by adding more g" +
        "roups to the end of the list")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_HighTemperatureRadiant
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("Name of zone system is serving")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description(@"Enter the method used to determine the maximum heating power input capacity. HeatingDesignCapacity = > selected when the design heating capacity value or autosize is specified. CapacityPerFloorArea = > selected when the design heating capacity is determine from user specified heating capacity per floor area and zone floor area. FractionOfAutosizedHeatingCapacity = > is selected when the design heating capacity is determined from a user specified fraction and the auto-sized design heating capacity.")]
[JsonProperty(PropertyName="heating_design_capacity_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_HighTemperatureRadiant_HeatingDesignCapacityMethod HeatingDesignCapacityMethod { get; set; } = (ZoneHVAC_HighTemperatureRadiant_HeatingDesignCapacityMethod)Enum.Parse(typeof(ZoneHVAC_HighTemperatureRadiant_HeatingDesignCapacityMethod), "HeatingDesignCapacity");
        

[Description("Enter the design heating capacity. Required field when the heating design capacit" +
    "y method HeatingDesignCapacity.")]
[JsonProperty(PropertyName="heating_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> HeatingDesignCapacity { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Enter the heating design capacity per zone floor area. Required field when the he" +
    "ating design capacity method field is CapacityPerFloorArea.")]
[JsonProperty(PropertyName="heating_design_capacity_per_floor_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingDesignCapacityPerFloorArea { get; set; } = null;
        

[Description("Enter the fraction of autosized heating design capacity. Required field when capa" +
    "city the heating design capacity method field is FractionOfAutosizedHeatingCapac" +
    "ity.")]
[JsonProperty(PropertyName="fraction_of_autosized_heating_design_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfAutosizedHeatingDesignCapacity { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("Natural gas or electricity")]
[JsonProperty(PropertyName="fuel_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_HighTemperatureRadiant_FuelType FuelType { get; set; } = (ZoneHVAC_HighTemperatureRadiant_FuelType)Enum.Parse(typeof(ZoneHVAC_HighTemperatureRadiant_FuelType), "Electricity");
        

[Description("Not used for non-gas radiant heaters")]
[JsonProperty(PropertyName="combustion_efficiency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CombustionEfficiency { get; set; } = Double.Parse("0.9", CultureInfo.InvariantCulture);
        

[Description("Radiant+latent+lost fractions must sum to 1 or less, remainder is considered conv" +
    "ective heat")]
[JsonProperty(PropertyName="fraction_of_input_converted_to_radiant_energy", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfInputConvertedToRadiantEnergy { get; set; } = Double.Parse("0.7", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="fraction_of_input_converted_to_latent_energy", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfInputConvertedToLatentEnergy { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Fraction of input vented to outdoor environment")]
[JsonProperty(PropertyName="fraction_of_input_that_is_lost", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfInputThatIsLost { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Temperature type used to control unit")]
[JsonProperty(PropertyName="temperature_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_HighTemperatureRadiant_TemperatureControlType TemperatureControlType { get; set; } = (ZoneHVAC_HighTemperatureRadiant_TemperatureControlType)Enum.Parse(typeof(ZoneHVAC_HighTemperatureRadiant_TemperatureControlType), "OperativeTemperature");
        

[JsonProperty(PropertyName="heating_throttling_range", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HeatingThrottlingRange { get; set; } = Double.Parse("2", CultureInfo.InvariantCulture);
        

[Description("This setpoint is an \"operative temperature\" setpoint")]
[JsonProperty(PropertyName="heating_setpoint_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingSetpointTemperatureScheduleName { get; set; } = "";
        

[Description("This will affect thermal comfort but from an energy balance standpoint this value" +
    " gets added to the convective gains from the radiant heater")]
[JsonProperty(PropertyName="fraction_of_radiant_energy_incident_on_people", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfRadiantEnergyIncidentOnPeople { get; set; } = null;
        

[JsonProperty(PropertyName="surface_fractions", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_HighTemperatureRadiant_SurfaceFractions_Item> SurfaceFractions { get; set; } = null;
    }
    
    public enum ZoneHVAC_HighTemperatureRadiant_HeatingDesignCapacityMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CapacityPerFloorArea")]
        CapacityPerFloorArea = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="FractionOfAutosizedHeatingCapacity")]
        FractionOfAutosizedHeatingCapacity = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatingDesignCapacity")]
        HeatingDesignCapacity = 3,
    }
    
    public enum ZoneHVAC_HighTemperatureRadiant_FuelType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Electricity")]
        Electricity = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="NaturalGas")]
        NaturalGas = 1,
    }
    
    public enum ZoneHVAC_HighTemperatureRadiant_TemperatureControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MeanAirTemperature")]
        MeanAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="MeanAirTemperatureSetpoint")]
        MeanAirTemperatureSetpoint = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MeanRadiantTemperature")]
        MeanRadiantTemperature = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="MeanRadiantTemperatureSetpoint")]
        MeanRadiantTemperatureSetpoint = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="OperativeTemperature")]
        OperativeTemperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="OperativeTemperatureSetpoint")]
        OperativeTemperatureSetpoint = 6,
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_HighTemperatureRadiant_SurfaceFractions_Item
    {
        

[JsonProperty(PropertyName="surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceName { get; set; } = "";
        

[JsonProperty(PropertyName="fraction_of_radiant_energy_to_surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FractionOfRadiantEnergyToSurface { get; set; } = null;
    }
    
    [Description("Ventilated slab system where outdoor air flows through hollow cores in a building" +
        " surface (wall, ceiling, or floor).")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_VentilatedSlab
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("Availability schedule name for this system. Schedule value > 0 means the system i" +
    "s available. If this field is blank, the system is always available.")]
[JsonProperty(PropertyName="availability_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityScheduleName { get; set; } = "";
        

[Description("(name of zone system is serving)")]
[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("(name of surface system is embedded in) or list of surfaces")]
[JsonProperty(PropertyName="surface_name_or_radiant_surface_group_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceNameOrRadiantSurfaceGroupName { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="outdoor_air_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_VentilatedSlab_OutdoorAirControlType OutdoorAirControlType { get; set; } = (ZoneHVAC_VentilatedSlab_OutdoorAirControlType)Enum.Parse(typeof(ZoneHVAC_VentilatedSlab_OutdoorAirControlType), "FixedAmount");
        

[JsonProperty(PropertyName="minimum_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MinimumOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_outdoor_air_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumOutdoorAirScheduleName { get; set; } = "";
        

[Description("schedule values multiply the minimum outdoor air flow rate")]
[JsonProperty(PropertyName="maximum_outdoor_air_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumOutdoorAirFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[Description("Note that this depends on the control type as to whether schedule values are a fr" +
    "action or temperature")]
[JsonProperty(PropertyName="maximum_outdoor_air_fraction_or_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MaximumOutdoorAirFractionOrTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="system_configuration_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_VentilatedSlab_SystemConfigurationType SystemConfigurationType { get; set; } = (ZoneHVAC_VentilatedSlab_SystemConfigurationType)Enum.Parse(typeof(ZoneHVAC_VentilatedSlab_SystemConfigurationType), "SlabOnly");
        

[JsonProperty(PropertyName="hollow_core_inside_diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HollowCoreInsideDiameter { get; set; } = Double.Parse("0.05", CultureInfo.InvariantCulture);
        

[Description("(length of core cavity embedded in surface)")]
[JsonProperty(PropertyName="hollow_core_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> HollowCoreLength { get; set; } = null;
        

[Description("flow will be divided evenly among the cores")]
[JsonProperty(PropertyName="number_of_cores", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfCores { get; set; } = null;
        

[Description("(temperature on which unit is controlled)")]
[JsonProperty(PropertyName="temperature_control_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_VentilatedSlab_TemperatureControlType TemperatureControlType { get; set; } = (ZoneHVAC_VentilatedSlab_TemperatureControlType)Enum.Parse(typeof(ZoneHVAC_VentilatedSlab_TemperatureControlType), "OutdoorDryBulbTemperature");
        

[Description(@"Air and control temperatures for heating work together to provide a linear function that determines the air temperature sent to the radiant system. The current control temperature (see A14) is compared to the high and low control temperatures at the current time. If the control temperature is above the high temperature, then the inlet air temperature is set to the low air temperature. If the control temperature is below the low temperature, then the inlet air temperature is set to the high air temperature. If the control temperature is between the high and low value, then the inlet air temperature is linearly interpolated between the low and high air temperature values.")]
[JsonProperty(PropertyName="heating_high_air_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingHighAirTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="heating_low_air_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingLowAirTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="heating_high_control_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingHighControlTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="heating_low_control_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingLowControlTemperatureScheduleName { get; set; } = "";
        

[Description("See note for heating high air temperature schedule above for interpretation infor" +
    "mation (or see the Input/Output Reference).")]
[JsonProperty(PropertyName="cooling_high_air_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingHighAirTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="cooling_low_air_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingLowAirTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="cooling_high_control_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingHighControlTemperatureScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="cooling_low_control_temperature_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingLowControlTemperatureScheduleName { get; set; } = "";
        

[Description("This is the zone return air inlet to the ventilated slab system outdoor air mixer" +
    ". This node is typically a zone exhaust node (do not connect to \"Zone Return Air" +
    " Node\").")]
[JsonProperty(PropertyName="return_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReturnAirNodeName { get; set; } = "";
        

[Description("This is the node entering the slab or series of slabs after the fan and coil(s).")]
[JsonProperty(PropertyName="slab_in_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SlabInNodeName { get; set; } = "";
        

[Description("This is the node name exiting the slab. This node is typically a zone inlet node." +
    " Leave blank when the system configuration is SlabOnly or SeriesSlabs.")]
[JsonProperty(PropertyName="zone_supply_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneSupplyAirNodeName { get; set; } = "";
        

[Description("This node is the outdoor air inlet to the ventilated slab oa mixer. This node sho" +
    "uld also be specified in an OutdoorAir:Node or OutdoorAir:NodeList object.")]
[JsonProperty(PropertyName="outdoor_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirNodeName { get; set; } = "";
        

[Description("This node is the relief air node from the ventilated slab outdoor air mixer.")]
[JsonProperty(PropertyName="relief_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ReliefAirNodeName { get; set; } = "";
        

[Description("This is the node name leaving the outdoor air mixer and entering the fan and coil" +
    "(s).")]
[JsonProperty(PropertyName="outdoor_air_mixer_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutdoorAirMixerOutletNodeName { get; set; } = "";
        

[Description("This is the node name of the fan outlet.")]
[JsonProperty(PropertyName="fan_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FanOutletNodeName { get; set; } = "";
        

[Description("Allowable fan types are Fan:SystemModel and Fan:ConstantVolume")]
[JsonProperty(PropertyName="fan_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string FanName { get; set; } = "";
        

[JsonProperty(PropertyName="coil_option_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_VentilatedSlab_CoilOptionType CoilOptionType { get; set; } = (ZoneHVAC_VentilatedSlab_CoilOptionType)Enum.Parse(typeof(ZoneHVAC_VentilatedSlab_CoilOptionType), "Cooling");
        

[JsonProperty(PropertyName="heating_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_VentilatedSlab_HeatingCoilObjectType HeatingCoilObjectType { get; set; } = (ZoneHVAC_VentilatedSlab_HeatingCoilObjectType)Enum.Parse(typeof(ZoneHVAC_VentilatedSlab_HeatingCoilObjectType), "CoilHeatingElectric");
        

[JsonProperty(PropertyName="heating_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HeatingCoilName { get; set; } = "";
        

[JsonProperty(PropertyName="hot_water_or_steam_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string HotWaterOrSteamInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="cooling_coil_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_VentilatedSlab_CoolingCoilObjectType CoolingCoilObjectType { get; set; } = (ZoneHVAC_VentilatedSlab_CoolingCoilObjectType)Enum.Parse(typeof(ZoneHVAC_VentilatedSlab_CoolingCoilObjectType), "CoilCoolingWater");
        

[JsonProperty(PropertyName="cooling_coil_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CoolingCoilName { get; set; } = "";
        

[JsonProperty(PropertyName="cold_water_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ColdWaterInletNodeName { get; set; } = "";
        

[Description("Enter the name of an AvailabilityManagerAssignmentList object.")]
[JsonProperty(PropertyName="availability_manager_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityManagerListName { get; set; } = "";
        

[Description("Enter the name of a DesignSpecificationZoneHVACSizing object.")]
[JsonProperty(PropertyName="design_specification_zonehvac_sizing_object_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DesignSpecificationZonehvacSizingObjectName { get; set; } = "";
    }
    
    public enum ZoneHVAC_VentilatedSlab_OutdoorAirControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="FixedAmount")]
        FixedAmount = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FixedTemperature")]
        FixedTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="VariablePercent")]
        VariablePercent = 2,
    }
    
    public enum ZoneHVAC_VentilatedSlab_SystemConfigurationType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SeriesSlabs")]
        SeriesSlabs = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SlabAndZone")]
        SlabAndZone = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="SlabOnly")]
        SlabOnly = 3,
    }
    
    public enum ZoneHVAC_VentilatedSlab_TemperatureControlType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MeanAirTemperature")]
        MeanAirTemperature = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="MeanRadiantTemperature")]
        MeanRadiantTemperature = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="OperativeTemperature")]
        OperativeTemperature = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorDryBulbTemperature")]
        OutdoorDryBulbTemperature = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="OutdoorWetBulbTemperature")]
        OutdoorWetBulbTemperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="SurfaceTemperature")]
        SurfaceTemperature = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="ZoneAirDewPointTemperature")]
        ZoneAirDewPointTemperature = 7,
    }
    
    public enum ZoneHVAC_VentilatedSlab_CoilOptionType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Cooling")]
        Cooling = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Heating")]
        Heating = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HeatingAndCooling")]
        HeatingAndCooling = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 3,
    }
    
    public enum ZoneHVAC_VentilatedSlab_HeatingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Electric")]
        CoilHeatingElectric = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Fuel")]
        CoilHeatingFuel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Steam")]
        CoilHeatingSteam = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Water")]
        CoilHeatingWater = 3,
    }
    
    public enum ZoneHVAC_VentilatedSlab_CoolingCoilObjectType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water")]
        CoilCoolingWater = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:Water:DetailedGeometry")]
        CoilCoolingWaterDetailedGeometry = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CoilSystem:Cooling:Water:HeatExchangerAssisted")]
        CoilSystemCoolingWaterHeatExchangerAssisted = 2,
    }
    
    [Description("This is used to allow the coordinate control of several ventilated slab system su" +
        "rfaces. Note that the flow fractions must sum up to 1.0. The number of surfaces " +
        "can be expanded beyond 10, if necessary, by adding more groups to the end of the" +
        " list")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_VentilatedSlab_SlabGroup
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="data", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_VentilatedSlab_SlabGroup_Data_Item> Data { get; set; } = null;
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_VentilatedSlab_SlabGroup_Data_Item
    {
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[JsonProperty(PropertyName="surface_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SurfaceName { get; set; } = "";
        

[JsonProperty(PropertyName="core_diameter_for_surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoreDiameterForSurface { get; set; } = null;
        

[JsonProperty(PropertyName="core_length_for_surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoreLengthForSurface { get; set; } = null;
        

[JsonProperty(PropertyName="core_numbers_for_surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CoreNumbersForSurface { get; set; } = null;
        

[JsonProperty(PropertyName="slab_inlet_node_name_for_surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SlabInletNodeNameForSurface { get; set; } = "";
        

[JsonProperty(PropertyName="slab_outlet_node_name_for_surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SlabOutletNodeNameForSurface { get; set; } = "";
    }
}
