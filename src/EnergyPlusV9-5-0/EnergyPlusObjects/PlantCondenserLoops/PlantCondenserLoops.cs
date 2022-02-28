namespace EnergyPlus.PlantCondenserLoops
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
    
    
    [Description("Defines a central plant loop.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class PlantLoop
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="fluid_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantLoop_FluidType FluidType { get; set; } = (PlantLoop_FluidType)Enum.Parse(typeof(PlantLoop_FluidType), "Water");
        

[Description("This field is only required when Fluid Type is UserDefinedFluidType")]
[JsonProperty(PropertyName="user_defined_fluid_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UserDefinedFluidType { get; set; } = "";
        

[JsonProperty(PropertyName="plant_equipment_operation_scheme_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PlantEquipmentOperationSchemeName { get; set; } = "";
        

[JsonProperty(PropertyName="loop_temperature_setpoint_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string LoopTemperatureSetpointNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_loop_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumLoopTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_loop_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumLoopTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_loop_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumLoopFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_loop_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumLoopFlowRate { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="plant_loop_volume", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> PlantLoopVolume { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="plant_side_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PlantSideInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="plant_side_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PlantSideOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="plant_side_branch_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PlantSideBranchListName { get; set; } = "";
        

[JsonProperty(PropertyName="plant_side_connector_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string PlantSideConnectorListName { get; set; } = "";
        

[JsonProperty(PropertyName="demand_side_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DemandSideInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="demand_side_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DemandSideOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="demand_side_branch_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DemandSideBranchListName { get; set; } = "";
        

[JsonProperty(PropertyName="demand_side_connector_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DemandSideConnectorListName { get; set; } = "";
        

[JsonProperty(PropertyName="load_distribution_scheme", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantLoop_LoadDistributionScheme LoadDistributionScheme { get; set; } = (PlantLoop_LoadDistributionScheme)Enum.Parse(typeof(PlantLoop_LoadDistributionScheme), "SequentialLoad");
        

[JsonProperty(PropertyName="availability_manager_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AvailabilityManagerListName { get; set; } = "";
        

[JsonProperty(PropertyName="plant_loop_demand_calculation_scheme", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantLoop_PlantLoopDemandCalculationScheme PlantLoopDemandCalculationScheme { get; set; } = (PlantLoop_PlantLoopDemandCalculationScheme)Enum.Parse(typeof(PlantLoop_PlantLoopDemandCalculationScheme), "SingleSetpoint");
        

[Description(@"Specifies a primary-secondary loop configuration. The plant side is the primary loop, and the demand side is the secondary loop. A secondary supply pump is required on the demand side. None = Primary-only, no secondary simulation CommonPipe = Primary-secondary with no temperature control at primary-secondary interface TwoWayCommonPipe = Primary-secondary with control of secondary supply temperature or primary return temperature (requires a setpoint be placed on the plant side or demand side inlet node).")]
[JsonProperty(PropertyName="common_pipe_simulation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantLoop_CommonPipeSimulation CommonPipeSimulation { get; set; } = (PlantLoop_CommonPipeSimulation)Enum.Parse(typeof(PlantLoop_CommonPipeSimulation), "None");
        

[JsonProperty(PropertyName="pressure_simulation_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public PlantLoop_PressureSimulationType PressureSimulationType { get; set; } = (PlantLoop_PressureSimulationType)Enum.Parse(typeof(PlantLoop_PressureSimulationType), "None");
        

[Description("This field is only used to autocalulate the Plant Loop Volume. Loop Volume = Loop" +
    " Circulation Time * Maximum Loop Flow Rate")]
[JsonProperty(PropertyName="loop_circulation_time", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoopCirculationTime { get; set; } = Double.Parse("2", CultureInfo.InvariantCulture);
    }
    
    public enum PlantLoop_FluidType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Steam")]
        Steam = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="UserDefinedFluidType")]
        UserDefinedFluidType = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Water")]
        Water = 3,
    }
    
    public enum PlantLoop_LoadDistributionScheme
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Optimal")]
        Optimal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SequentialLoad")]
        SequentialLoad = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="SequentialUniformPLR")]
        SequentialUniformPLR = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="UniformLoad")]
        UniformLoad = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="UniformPLR")]
        UniformPLR = 5,
    }
    
    public enum PlantLoop_PlantLoopDemandCalculationScheme
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="DualSetpointDeadband")]
        DualSetpointDeadband = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SingleSetpoint")]
        SingleSetpoint = 2,
    }
    
    public enum PlantLoop_CommonPipeSimulation
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="CommonPipe")]
        CommonPipe = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="TwoWayCommonPipe")]
        TwoWayCommonPipe = 3,
    }
    
    public enum PlantLoop_PressureSimulationType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="LoopFlowCorrection")]
        LoopFlowCorrection = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PumpPowerCorrection")]
        PumpPowerCorrection = 3,
    }
    
    [Description("Defines a central plant condenser loop. CondenserLoop and PlantLoop are nearly id" +
        "entical except some components and operation schemes are applicable to only one " +
        "loop type or the other.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class CondenserLoop
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="fluid_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CondenserLoop_FluidType FluidType { get; set; } = (CondenserLoop_FluidType)Enum.Parse(typeof(CondenserLoop_FluidType), "Water");
        

[Description("This field is only required when Fluid Type is UserDefinedFluidType")]
[JsonProperty(PropertyName="user_defined_fluid_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UserDefinedFluidType { get; set; } = "";
        

[JsonProperty(PropertyName="condenser_equipment_operation_scheme_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CondenserEquipmentOperationSchemeName { get; set; } = "";
        

[JsonProperty(PropertyName="condenser_loop_temperature_setpoint_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CondenserLoopTemperatureSetpointNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="maximum_loop_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumLoopTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_loop_temperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumLoopTemperature { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_loop_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutosizeJsonConverter))]
public System.Nullable<double> MaximumLoopFlowRate { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="minimum_loop_flow_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumLoopFlowRate { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="condenser_loop_volume", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPNullToAutocalculateJsonConverter))]
public System.Nullable<double> CondenserLoopVolume { get; set; } = Double.Parse("-987654321", CultureInfo.InvariantCulture);
        

[JsonProperty(PropertyName="condenser_side_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CondenserSideInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="condenser_side_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CondenserSideOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="condenser_side_branch_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CondenserSideBranchListName { get; set; } = "";
        

[JsonProperty(PropertyName="condenser_side_connector_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CondenserSideConnectorListName { get; set; } = "";
        

[JsonProperty(PropertyName="demand_side_inlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DemandSideInletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="demand_side_outlet_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string DemandSideOutletNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="condenser_demand_side_branch_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CondenserDemandSideBranchListName { get; set; } = "";
        

[JsonProperty(PropertyName="condenser_demand_side_connector_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CondenserDemandSideConnectorListName { get; set; } = "";
        

[JsonProperty(PropertyName="load_distribution_scheme", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CondenserLoop_LoadDistributionScheme LoadDistributionScheme { get; set; } = (CondenserLoop_LoadDistributionScheme)Enum.Parse(typeof(CondenserLoop_LoadDistributionScheme), "SequentialLoad");
        

[JsonProperty(PropertyName="pressure_simulation_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CondenserLoop_PressureSimulationType PressureSimulationType { get; set; } = (CondenserLoop_PressureSimulationType)Enum.Parse(typeof(CondenserLoop_PressureSimulationType), "None");
        

[Description("This field is only used to autocalulate the Condenser Loop Volume. Loop Volume = " +
    "Loop Circulation Time * Maximum Loop Flow Rate")]
[JsonProperty(PropertyName="loop_circulation_time", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LoopCirculationTime { get; set; } = Double.Parse("2", CultureInfo.InvariantCulture);
    }
    
    public enum CondenserLoop_FluidType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="UserDefinedFluidType")]
        UserDefinedFluidType = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Water")]
        Water = 2,
    }
    
    public enum CondenserLoop_LoadDistributionScheme
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Optimal")]
        Optimal = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SequentialLoad")]
        SequentialLoad = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="SequentialUniformPLR")]
        SequentialUniformPLR = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="UniformLoad")]
        UniformLoad = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="UniformPLR")]
        UniformPLR = 5,
    }
    
    public enum CondenserLoop_PressureSimulationType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="LoopFlowCorrection")]
        LoopFlowCorrection = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="PumpPowerCorrection")]
        PumpPowerCorrection = 3,
    }
}
