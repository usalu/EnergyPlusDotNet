namespace EnergyPlus.ZoneHVACEquipmentConnections
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
    using EnergyPlus.ZoneHVACForcedAirUnits;
    using EnergyPlus.ZoneHVACRadiativeConvectiveUnits;
    
    
    [Description(@"List equipment in simulation order. Note that an ZoneHVAC:AirDistributionUnit object must be listed in this statement if there is a forced air system serving the zone from the air loop. Equipment is simulated in the order specified by Zone Equipment Cooling Sequence and Zone Equipment Heating or No-Load Sequence, depending on the thermostat request. For equipment of similar type, assign sequence 1 to the first system intended to serve that type of load. For situations where one or more equipment types has limited capacity or limited control, order the sequence so that the most controllable piece of equipment runs last. For example, with a dedicated outdoor air system (DOAS), the air terminal for the DOAS should be assigned Heating Sequence = 1 and Cooling Sequence = 1. Any other equipment should be assigned sequence 2 or higher so that it will see the net load after the DOAS air is added to the zone.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_EquipmentList
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="load_distribution_scheme", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ZoneHVAC_EquipmentList_LoadDistributionScheme LoadDistributionScheme { get; set; } = (ZoneHVAC_EquipmentList_LoadDistributionScheme)Enum.Parse(typeof(ZoneHVAC_EquipmentList_LoadDistributionScheme), "SequentialLoad");
        

[JsonProperty(PropertyName="equipment", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACEquipmentConnections.ZoneHVAC_EquipmentList_Equipment_Item> Equipment { get; set; } = null;
    }
    
    public enum ZoneHVAC_EquipmentList_LoadDistributionScheme
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="SequentialLoad")]
        SequentialLoad = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="SequentialUniformPLR")]
        SequentialUniformPLR = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="UniformLoad")]
        UniformLoad = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="UniformPLR")]
        UniformPLR = 4,
    }
    
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_EquipmentList_Equipment_Item
    {
        

[JsonProperty(PropertyName="zone_equipment_object_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneEquipmentObjectType { get; set; } = "";
        

[JsonProperty(PropertyName="zone_equipment_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneEquipmentName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_equipment_cooling_sequence", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneEquipmentCoolingSequence { get; set; } = null;
        

[JsonProperty(PropertyName="zone_equipment_heating_or_no_load_sequence", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ZoneEquipmentHeatingOrNoLoadSequence { get; set; } = null;
        

[JsonProperty(PropertyName="zone_equipment_sequential_cooling_fraction_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneEquipmentSequentialCoolingFractionScheduleName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_equipment_sequential_heating_fraction_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneEquipmentSequentialHeatingFractionScheduleName { get; set; } = "";
    }
    
    [Description("Specifies the HVAC equipment connections for a zone. Node names are specified for" +
        " the zone air node, air inlet nodes, air exhaust nodes, and the air return node." +
        " A zone equipment list is referenced which lists all HVAC equipment connected to" +
        " the zone.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ZoneHVAC_EquipmentConnections
    {
        

[JsonProperty(PropertyName="zone_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneName { get; set; } = "";
        

[Description("Enter the name of a ZoneHVAC:EquipmentList object.")]
[JsonProperty(PropertyName="zone_conditioning_equipment_list_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneConditioningEquipmentListName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_air_inlet_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneAirInletNodeOrNodelistName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_air_exhaust_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneAirExhaustNodeOrNodelistName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_air_node_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneAirNodeName { get; set; } = "";
        

[JsonProperty(PropertyName="zone_return_air_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneReturnAirNodeOrNodelistName { get; set; } = "";
        

[Description("This schedule is multiplied times the base return air flow rate. If this field is" +
    " left blank, the schedule defaults to 1.0 at all times.")]
[JsonProperty(PropertyName="zone_return_air_node_1_flow_rate_fraction_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneReturnAirNode1FlowRateFractionScheduleName { get; set; } = "";
        

[Description(@"The optional basis node(s) used to calculate the base return air flow rate for the first return air node in this zone. The return air flow rate is the sum of the flow rates at the basis node(s) multiplied by the Zone Return Air Flow Rate Fraction Schedule. If this  field is blank, then the base return air flow rate is the total supply inlet flow rate to the zone less the total exhaust node flow rate from the zone.")]
[JsonProperty(PropertyName="zone_return_air_node_1_flow_rate_basis_node_or_nodelist_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ZoneReturnAirNode1FlowRateBasisNodeOrNodelistName { get; set; } = "";
    }
}
