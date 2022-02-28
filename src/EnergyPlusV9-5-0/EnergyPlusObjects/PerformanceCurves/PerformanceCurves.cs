namespace EnergyPlus.PerformanceCurves
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
    
    
    [Description(@"Linear curve with one independent variable. Input for the linear curve consists of a curve name, the two coefficients, and the maximum and minimum valid independent variable values. Optional inputs for curve minimum and maximum may be used to limit the output of the performance curve. curve = C1 + C2*x")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Curve_Linear
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="coefficient1_constant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1Constant { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient2_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2X { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfX { get; set; } = null;
        

[Description("Specify the minimum value calculated by this curve object")]
[JsonProperty(PropertyName="minimum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCurveOutput { get; set; } = null;
        

[Description("Specify the maximum value calculated by this curve object")]
[JsonProperty(PropertyName="maximum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCurveOutput { get; set; } = null;
        

[JsonProperty(PropertyName="input_unit_type_for_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_Linear_InputUnitTypeForX InputUnitTypeForX { get; set; } = (Curve_Linear_InputUnitTypeForX)Enum.Parse(typeof(Curve_Linear_InputUnitTypeForX), "Dimensionless");
        

[JsonProperty(PropertyName="output_unit_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_Linear_OutputUnitType OutputUnitType { get; set; } = (Curve_Linear_OutputUnitType)Enum.Parse(typeof(Curve_Linear_OutputUnitType), "Dimensionless");
    }
    
    public enum Curve_Linear_InputUnitTypeForX
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Pressure")]
        Pressure = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 7,
    }
    
    public enum Curve_Linear_OutputUnitType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Capacity")]
        Capacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Pressure")]
        Pressure = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
    }
    
    [Description(@"Linear curve with four independent variables. Input for the linear curve consists of a curve name, the two coefficients, and the maximum and minimum valid independent variable values. Optional inputs for curve minimum and maximum may be used to limit the output of the performance curve. curve = C1 + C2*w + C3*x + C4*y + C5*z")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Curve_QuadLinear
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="coefficient1_constant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1Constant { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient2_w", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2W { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient3_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3X { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient4_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient4Y { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient5_z", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient5Z { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_w", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfW { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_w", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfW { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfY { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfY { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_z", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfZ { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_z", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfZ { get; set; } = null;
        

[Description("Specify the minimum value calculated by this curve object")]
[JsonProperty(PropertyName="minimum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCurveOutput { get; set; } = null;
        

[Description("Specify the maximum value calculated by this curve object")]
[JsonProperty(PropertyName="maximum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCurveOutput { get; set; } = null;
        

[JsonProperty(PropertyName="input_unit_type_for_w", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_QuadLinear_InputUnitTypeForW InputUnitTypeForW { get; set; } = (Curve_QuadLinear_InputUnitTypeForW)Enum.Parse(typeof(Curve_QuadLinear_InputUnitTypeForW), "Dimensionless");
        

[JsonProperty(PropertyName="input_unit_type_for_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_QuadLinear_InputUnitTypeForX InputUnitTypeForX { get; set; } = (Curve_QuadLinear_InputUnitTypeForX)Enum.Parse(typeof(Curve_QuadLinear_InputUnitTypeForX), "Dimensionless");
        

[JsonProperty(PropertyName="input_unit_type_for_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_QuadLinear_InputUnitTypeForY InputUnitTypeForY { get; set; } = (Curve_QuadLinear_InputUnitTypeForY)Enum.Parse(typeof(Curve_QuadLinear_InputUnitTypeForY), "Dimensionless");
        

[JsonProperty(PropertyName="input_unit_type_for_z", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_QuadLinear_InputUnitTypeForZ InputUnitTypeForZ { get; set; } = (Curve_QuadLinear_InputUnitTypeForZ)Enum.Parse(typeof(Curve_QuadLinear_InputUnitTypeForZ), "Dimensionless");
    }
    
    public enum Curve_QuadLinear_InputUnitTypeForW
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlowPerPower")]
        VolumetricFlowPerPower = 7,
    }
    
    public enum Curve_QuadLinear_InputUnitTypeForX
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlowPerPower")]
        VolumetricFlowPerPower = 7,
    }
    
    public enum Curve_QuadLinear_InputUnitTypeForY
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlowPerPower")]
        VolumetricFlowPerPower = 7,
    }
    
    public enum Curve_QuadLinear_InputUnitTypeForZ
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlowPerPower")]
        VolumetricFlowPerPower = 7,
    }
    
    [Description(@"Linear curve with five independent variables. Input for the linear curve consists of a curve name, the two coefficients, and the maximum and minimum valid independent variable values. Optional inputs for curve minimum and maximum may be used to limit the output of the performance curve. curve = C1 + C2*v + C3*w + C4*x + C5*y + C6*z")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Curve_QuintLinear
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="coefficient1_constant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1Constant { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient2_v", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2V { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient3_w", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3W { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient4_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient4X { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient5_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient5Y { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient6_z", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient6Z { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_v", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfV { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_v", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfV { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_w", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfW { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_w", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfW { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfY { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfY { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_z", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfZ { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_z", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfZ { get; set; } = null;
        

[Description("Specify the minimum value calculated by this curve object")]
[JsonProperty(PropertyName="minimum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCurveOutput { get; set; } = null;
        

[Description("Specify the maximum value calculated by this curve object")]
[JsonProperty(PropertyName="maximum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCurveOutput { get; set; } = null;
        

[JsonProperty(PropertyName="input_unit_type_for_v", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_QuintLinear_InputUnitTypeForV InputUnitTypeForV { get; set; } = (Curve_QuintLinear_InputUnitTypeForV)Enum.Parse(typeof(Curve_QuintLinear_InputUnitTypeForV), "Dimensionless");
        

[JsonProperty(PropertyName="input_unit_type_for_w", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_QuintLinear_InputUnitTypeForW InputUnitTypeForW { get; set; } = (Curve_QuintLinear_InputUnitTypeForW)Enum.Parse(typeof(Curve_QuintLinear_InputUnitTypeForW), "Dimensionless");
        

[JsonProperty(PropertyName="input_unit_type_for_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_QuintLinear_InputUnitTypeForX InputUnitTypeForX { get; set; } = (Curve_QuintLinear_InputUnitTypeForX)Enum.Parse(typeof(Curve_QuintLinear_InputUnitTypeForX), "Dimensionless");
        

[JsonProperty(PropertyName="input_unit_type_for_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_QuintLinear_InputUnitTypeForY InputUnitTypeForY { get; set; } = (Curve_QuintLinear_InputUnitTypeForY)Enum.Parse(typeof(Curve_QuintLinear_InputUnitTypeForY), "Dimensionless");
        

[JsonProperty(PropertyName="input_unit_type_for_z", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_QuintLinear_InputUnitTypeForZ InputUnitTypeForZ { get; set; } = (Curve_QuintLinear_InputUnitTypeForZ)Enum.Parse(typeof(Curve_QuintLinear_InputUnitTypeForZ), "Dimensionless");
    }
    
    public enum Curve_QuintLinear_InputUnitTypeForV
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlowPerPower")]
        VolumetricFlowPerPower = 7,
    }
    
    public enum Curve_QuintLinear_InputUnitTypeForW
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlowPerPower")]
        VolumetricFlowPerPower = 7,
    }
    
    public enum Curve_QuintLinear_InputUnitTypeForX
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlowPerPower")]
        VolumetricFlowPerPower = 7,
    }
    
    public enum Curve_QuintLinear_InputUnitTypeForY
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlowPerPower")]
        VolumetricFlowPerPower = 7,
    }
    
    public enum Curve_QuintLinear_InputUnitTypeForZ
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlowPerPower")]
        VolumetricFlowPerPower = 7,
    }
    
    [Description(@"Quadratic curve with one independent variable. Input for a quadratic curve consists of the curve name, the three coefficients, and the maximum and minimum valid independent variable values. Optional inputs for curve minimum and maximum may be used to limit the output of the performance curve. curve = C1 + C2*x + C3*x**2")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Curve_Quadratic
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="coefficient1_constant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1Constant { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient2_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2X { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient3_x_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3X2 { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfX { get; set; } = null;
        

[Description("Specify the minimum value calculated by this curve object")]
[JsonProperty(PropertyName="minimum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCurveOutput { get; set; } = null;
        

[Description("Specify the maximum value calculated by this curve object")]
[JsonProperty(PropertyName="maximum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCurveOutput { get; set; } = null;
        

[JsonProperty(PropertyName="input_unit_type_for_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_Quadratic_InputUnitTypeForX InputUnitTypeForX { get; set; } = (Curve_Quadratic_InputUnitTypeForX)Enum.Parse(typeof(Curve_Quadratic_InputUnitTypeForX), "Dimensionless");
        

[JsonProperty(PropertyName="output_unit_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_Quadratic_OutputUnitType OutputUnitType { get; set; } = (Curve_Quadratic_OutputUnitType)Enum.Parse(typeof(Curve_Quadratic_OutputUnitType), "Dimensionless");
    }
    
    public enum Curve_Quadratic_InputUnitTypeForX
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 6,
    }
    
    public enum Curve_Quadratic_OutputUnitType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Capacity")]
        Capacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Pressure")]
        Pressure = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
    }
    
    [Description(@"Cubic curve with one independent variable. Input for a cubic curve consists of the curve name, the 4 coefficients, and the maximum and minimum valid independent variable values. Optional inputs for curve minimum and maximum may be used to limit the output of the performance curve. curve = C1 + C2*x + C3*x**2 + C4*x**3")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Curve_Cubic
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="coefficient1_constant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1Constant { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient2_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2X { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient3_x_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3X2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient4_x_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient4X3 { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfX { get; set; } = null;
        

[Description("Specify the minimum value calculated by this curve object")]
[JsonProperty(PropertyName="minimum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCurveOutput { get; set; } = null;
        

[Description("Specify the maximum value calculated by this curve object")]
[JsonProperty(PropertyName="maximum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCurveOutput { get; set; } = null;
        

[JsonProperty(PropertyName="input_unit_type_for_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_Cubic_InputUnitTypeForX InputUnitTypeForX { get; set; } = (Curve_Cubic_InputUnitTypeForX)Enum.Parse(typeof(Curve_Cubic_InputUnitTypeForX), "Dimensionless");
        

[JsonProperty(PropertyName="output_unit_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_Cubic_OutputUnitType OutputUnitType { get; set; } = (Curve_Cubic_OutputUnitType)Enum.Parse(typeof(Curve_Cubic_OutputUnitType), "Dimensionless");
    }
    
    public enum Curve_Cubic_InputUnitTypeForX
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 6,
    }
    
    public enum Curve_Cubic_OutputUnitType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Capacity")]
        Capacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Pressure")]
        Pressure = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
    }
    
    [Description(@"Quartic (fourth order polynomial) curve with one independent variable. Input for a Quartic curve consists of the curve name, the five coefficients, and the maximum and minimum valid independent variable values. Optional inputs for curve minimum and maximum may be used to limit the output of the performance curve. curve = C1 + C2*x + C3*x**2 + C4*x**3 + C5*x**4")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Curve_Quartic
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="coefficient1_constant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1Constant { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient2_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2X { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient3_x_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3X2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient4_x_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient4X3 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient5_x_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient5X4 { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfX { get; set; } = null;
        

[Description("Specify the minimum value calculated by this curve object")]
[JsonProperty(PropertyName="minimum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCurveOutput { get; set; } = null;
        

[Description("Specify the maximum value calculated by this curve object")]
[JsonProperty(PropertyName="maximum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCurveOutput { get; set; } = null;
        

[JsonProperty(PropertyName="input_unit_type_for_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_Quartic_InputUnitTypeForX InputUnitTypeForX { get; set; } = (Curve_Quartic_InputUnitTypeForX)Enum.Parse(typeof(Curve_Quartic_InputUnitTypeForX), "Dimensionless");
        

[JsonProperty(PropertyName="output_unit_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_Quartic_OutputUnitType OutputUnitType { get; set; } = (Curve_Quartic_OutputUnitType)Enum.Parse(typeof(Curve_Quartic_OutputUnitType), "Dimensionless");
    }
    
    public enum Curve_Quartic_InputUnitTypeForX
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 6,
    }
    
    public enum Curve_Quartic_OutputUnitType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Capacity")]
        Capacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Pressure")]
        Pressure = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
    }
    
    [Description(@"Exponent curve with one independent variable. Input for a exponent curve consists of the curve name, the 3 coefficients, and the maximum and minimum valid independent variable values. Optional inputs for curve minimum and maximum may be used to limit the output of the performance curve. curve = C1 + C2*x**C3 The independent variable x is raised to the C3 power, multiplied by C2, and C1 is added to the result.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Curve_Exponent
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="coefficient1_constant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1Constant { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient2_constant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2Constant { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient3_constant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3Constant { get; set; } = null;
        

[Description("Specify the minimum value of the independent variable x allowed")]
[JsonProperty(PropertyName="minimum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfX { get; set; } = null;
        

[Description("Specify the maximum value of the independent variable x allowed")]
[JsonProperty(PropertyName="maximum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfX { get; set; } = null;
        

[Description("Specify the minimum value calculated by this curve object")]
[JsonProperty(PropertyName="minimum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCurveOutput { get; set; } = null;
        

[Description("Specify the maximum value calculated by this curve object")]
[JsonProperty(PropertyName="maximum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCurveOutput { get; set; } = null;
        

[JsonProperty(PropertyName="input_unit_type_for_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_Exponent_InputUnitTypeForX InputUnitTypeForX { get; set; } = (Curve_Exponent_InputUnitTypeForX)Enum.Parse(typeof(Curve_Exponent_InputUnitTypeForX), "Dimensionless");
        

[JsonProperty(PropertyName="output_unit_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_Exponent_OutputUnitType OutputUnitType { get; set; } = (Curve_Exponent_OutputUnitType)Enum.Parse(typeof(Curve_Exponent_OutputUnitType), "Dimensionless");
    }
    
    public enum Curve_Exponent_InputUnitTypeForX
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 6,
    }
    
    public enum Curve_Exponent_OutputUnitType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Capacity")]
        Capacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Pressure")]
        Pressure = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
    }
    
    [Description(@"Cubic curve with two independent variables. Input consists of the curve name, the ten coefficients, and the minimum and maximum values for each of the independent variables. Optional inputs for curve minimum and maximum may be used to limit the output of the performance curve. curve = C1 + C2*x + C3*x**2 + C4*y + C5*y**2 + C6*x*y + C7*x**3 + C8*y**3 + C9*x**2*y + C10*x*y**2")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Curve_Bicubic
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="coefficient1_constant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1Constant { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient2_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2X { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient3_x_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3X2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient4_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient4Y { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient5_y_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient5Y2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient6_x_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient6XY { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient7_x_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient7X3 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient8_y_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient8Y3 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient9_x_2_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient9X2Y { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient10_x_y_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient10XY2 { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfY { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfY { get; set; } = null;
        

[Description("Specify the minimum value calculated by this curve object")]
[JsonProperty(PropertyName="minimum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCurveOutput { get; set; } = null;
        

[Description("Specify the maximum value calculated by this curve object")]
[JsonProperty(PropertyName="maximum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCurveOutput { get; set; } = null;
        

[JsonProperty(PropertyName="input_unit_type_for_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_Bicubic_InputUnitTypeForX InputUnitTypeForX { get; set; } = (Curve_Bicubic_InputUnitTypeForX)Enum.Parse(typeof(Curve_Bicubic_InputUnitTypeForX), "Dimensionless");
        

[JsonProperty(PropertyName="input_unit_type_for_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_Bicubic_InputUnitTypeForY InputUnitTypeForY { get; set; } = (Curve_Bicubic_InputUnitTypeForY)Enum.Parse(typeof(Curve_Bicubic_InputUnitTypeForY), "Dimensionless");
        

[JsonProperty(PropertyName="output_unit_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_Bicubic_OutputUnitType OutputUnitType { get; set; } = (Curve_Bicubic_OutputUnitType)Enum.Parse(typeof(Curve_Bicubic_OutputUnitType), "Dimensionless");
    }
    
    public enum Curve_Bicubic_InputUnitTypeForX
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 6,
    }
    
    public enum Curve_Bicubic_InputUnitTypeForY
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 6,
    }
    
    public enum Curve_Bicubic_OutputUnitType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Capacity")]
        Capacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Pressure")]
        Pressure = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
    }
    
    [Description(@"Quadratic curve with two independent variables. Input consists of the curve name, the six coefficients, and min and max values for each of the independent variables. Optional inputs for curve minimum and maximum may be used to limit the output of the performance curve. curve = C1 + C2*x + C3*x**2 + C4*y + C5*y**2 + C6*x*y")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Curve_Biquadratic
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="coefficient1_constant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1Constant { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient2_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2X { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient3_x_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3X2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient4_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient4Y { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient5_y_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient5Y2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient6_x_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient6XY { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfY { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfY { get; set; } = null;
        

[Description("Specify the minimum value calculated by this curve object")]
[JsonProperty(PropertyName="minimum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCurveOutput { get; set; } = null;
        

[Description("Specify the maximum value calculated by this curve object")]
[JsonProperty(PropertyName="maximum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCurveOutput { get; set; } = null;
        

[JsonProperty(PropertyName="input_unit_type_for_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_Biquadratic_InputUnitTypeForX InputUnitTypeForX { get; set; } = (Curve_Biquadratic_InputUnitTypeForX)Enum.Parse(typeof(Curve_Biquadratic_InputUnitTypeForX), "Dimensionless");
        

[JsonProperty(PropertyName="input_unit_type_for_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_Biquadratic_InputUnitTypeForY InputUnitTypeForY { get; set; } = (Curve_Biquadratic_InputUnitTypeForY)Enum.Parse(typeof(Curve_Biquadratic_InputUnitTypeForY), "Dimensionless");
        

[JsonProperty(PropertyName="output_unit_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_Biquadratic_OutputUnitType OutputUnitType { get; set; } = (Curve_Biquadratic_OutputUnitType)Enum.Parse(typeof(Curve_Biquadratic_OutputUnitType), "Dimensionless");
    }
    
    public enum Curve_Biquadratic_InputUnitTypeForX
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 6,
    }
    
    public enum Curve_Biquadratic_InputUnitTypeForY
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 6,
    }
    
    public enum Curve_Biquadratic_OutputUnitType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Capacity")]
        Capacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Pressure")]
        Pressure = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
    }
    
    [Description(@"Quadratic-linear curve with two independent variables. Input consists of the curve name, the six coefficients, and min and max values for each of the independent variables. Optional inputs for curve minimum and maximum may be used to limit the output of the performance curve. curve = (C1 + C2*x + C3*x**2) + (C4 + C5*x + C6*x**2)*y")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Curve_QuadraticLinear
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="coefficient1_constant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1Constant { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient2_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2X { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient3_x_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3X2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient4_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient4Y { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient5_x_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient5XY { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient6_x_2_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient6X2Y { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfY { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfY { get; set; } = null;
        

[Description("Specify the minimum value calculated by this curve object")]
[JsonProperty(PropertyName="minimum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCurveOutput { get; set; } = null;
        

[Description("Specify the maximum value calculated by this curve object")]
[JsonProperty(PropertyName="maximum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCurveOutput { get; set; } = null;
        

[JsonProperty(PropertyName="input_unit_type_for_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_QuadraticLinear_InputUnitTypeForX InputUnitTypeForX { get; set; } = (Curve_QuadraticLinear_InputUnitTypeForX)Enum.Parse(typeof(Curve_QuadraticLinear_InputUnitTypeForX), "Dimensionless");
        

[JsonProperty(PropertyName="input_unit_type_for_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_QuadraticLinear_InputUnitTypeForY InputUnitTypeForY { get; set; } = (Curve_QuadraticLinear_InputUnitTypeForY)Enum.Parse(typeof(Curve_QuadraticLinear_InputUnitTypeForY), "Dimensionless");
        

[JsonProperty(PropertyName="output_unit_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_QuadraticLinear_OutputUnitType OutputUnitType { get; set; } = (Curve_QuadraticLinear_OutputUnitType)Enum.Parse(typeof(Curve_QuadraticLinear_OutputUnitType), "Dimensionless");
    }
    
    public enum Curve_QuadraticLinear_InputUnitTypeForX
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 6,
    }
    
    public enum Curve_QuadraticLinear_InputUnitTypeForY
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 6,
    }
    
    public enum Curve_QuadraticLinear_OutputUnitType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Capacity")]
        Capacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Pressure")]
        Pressure = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
    }
    
    [Description(@"Cubic-linear curve with two independent variables. Input consists of the curve name, the six coefficients, and min and max values for each of the independent variables. Optional inputs for curve minimum and maximum may be used to limit the output of the performance curve. curve = (C1 + C2*x + C3*x**2 + C4*x**3) + (C5 + C6*x)*y")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Curve_CubicLinear
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="coefficient1_constant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1Constant { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient2_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2X { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient3_x_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3X2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient4_x_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient4X3 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient5_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient5Y { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient6_x_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient6XY { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfY { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfY { get; set; } = null;
        

[Description("Specify the minimum value calculated by this curve object")]
[JsonProperty(PropertyName="minimum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCurveOutput { get; set; } = null;
        

[Description("Specify the maximum value calculated by this curve object")]
[JsonProperty(PropertyName="maximum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCurveOutput { get; set; } = null;
        

[JsonProperty(PropertyName="input_unit_type_for_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_CubicLinear_InputUnitTypeForX InputUnitTypeForX { get; set; } = (Curve_CubicLinear_InputUnitTypeForX)Enum.Parse(typeof(Curve_CubicLinear_InputUnitTypeForX), "Dimensionless");
        

[JsonProperty(PropertyName="input_unit_type_for_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_CubicLinear_InputUnitTypeForY InputUnitTypeForY { get; set; } = (Curve_CubicLinear_InputUnitTypeForY)Enum.Parse(typeof(Curve_CubicLinear_InputUnitTypeForY), "Dimensionless");
        

[JsonProperty(PropertyName="output_unit_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_CubicLinear_OutputUnitType OutputUnitType { get; set; } = (Curve_CubicLinear_OutputUnitType)Enum.Parse(typeof(Curve_CubicLinear_OutputUnitType), "Dimensionless");
    }
    
    public enum Curve_CubicLinear_InputUnitTypeForX
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 2,
    }
    
    public enum Curve_CubicLinear_InputUnitTypeForY
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 2,
    }
    
    public enum Curve_CubicLinear_OutputUnitType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Capacity")]
        Capacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Pressure")]
        Pressure = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
    }
    
    [Description(@"Quadratic curve with three independent variables. Input consists of the curve name, the twenty seven coefficients, and min and max values for each of the independent variables. Optional inputs for curve minimum and maximum may be used to limit the output of the performance curve. curve = a0 + a1*x**2 + a2*x + a3*y**2 + a4*y + a5*z**2 + a6*z + a7*x**2*y**2 + a8*x*y + a9*x*y**2 + a10*x**2*y + a11*x**2*z**2 + a12*x*z + a13*x*z**2 + a14*x**2*z + a15*y**2*z**2 + a16*y*z + a17*y*z**2 + a18*y**2*z + a19*x**2*y**2*z**2 + a20*x**2*y**2*z + a21*x**2*y*z**2 + a22*x*y**2*z**2 + a23*x**2*y*z + a24*x*y**2*z + a25*x*y*z**2 +a26*x*y*z")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Curve_Triquadratic
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="coefficient1_constant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1Constant { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient2_x_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2X2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient3_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3X { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient4_y_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient4Y2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient5_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient5Y { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient6_z_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient6Z2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient7_z", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient7Z { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient8_x_2_y_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient8X2Y2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient9_x_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient9XY { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient10_x_y_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient10XY2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient11_x_2_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient11X2Y { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient12_x_2_z_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient12X2Z2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient13_x_z", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient13XZ { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient14_x_z_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient14XZ2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient15_x_2_z", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient15X2Z { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient16_y_2_z_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient16Y2Z2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient17_y_z", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient17YZ { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient18_y_z_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient18YZ2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient19_y_2_z", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient19Y2Z { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient20_x_2_y_2_z_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient20X2Y2Z2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient21_x_2_y_2_z", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient21X2Y2Z { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient22_x_2_y_z_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient22X2YZ2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient23_x_y_2_z_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient23XY2Z2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient24_x_2_y_z", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient24X2YZ { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient25_x_y_2_z", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient25XY2Z { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient26_x_y_z_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient26XYZ2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient27_x_y_z", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient27XYZ { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfY { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfY { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_z", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfZ { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_z", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfZ { get; set; } = null;
        

[Description("Specify the minimum value calculated by this curve object")]
[JsonProperty(PropertyName="minimum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCurveOutput { get; set; } = null;
        

[Description("Specify the maximum value calculated by this curve object")]
[JsonProperty(PropertyName="maximum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCurveOutput { get; set; } = null;
        

[JsonProperty(PropertyName="input_unit_type_for_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_Triquadratic_InputUnitTypeForX InputUnitTypeForX { get; set; } = (Curve_Triquadratic_InputUnitTypeForX)Enum.Parse(typeof(Curve_Triquadratic_InputUnitTypeForX), "Dimensionless");
        

[JsonProperty(PropertyName="input_unit_type_for_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_Triquadratic_InputUnitTypeForY InputUnitTypeForY { get; set; } = (Curve_Triquadratic_InputUnitTypeForY)Enum.Parse(typeof(Curve_Triquadratic_InputUnitTypeForY), "Dimensionless");
        

[JsonProperty(PropertyName="input_unit_type_for_z", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_Triquadratic_InputUnitTypeForZ InputUnitTypeForZ { get; set; } = (Curve_Triquadratic_InputUnitTypeForZ)Enum.Parse(typeof(Curve_Triquadratic_InputUnitTypeForZ), "Dimensionless");
        

[JsonProperty(PropertyName="output_unit_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_Triquadratic_OutputUnitType OutputUnitType { get; set; } = (Curve_Triquadratic_OutputUnitType)Enum.Parse(typeof(Curve_Triquadratic_OutputUnitType), "Dimensionless");
    }
    
    public enum Curve_Triquadratic_InputUnitTypeForX
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 6,
    }
    
    public enum Curve_Triquadratic_InputUnitTypeForY
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 6,
    }
    
    public enum Curve_Triquadratic_InputUnitTypeForZ
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Distance")]
        Distance = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MassFlow")]
        MassFlow = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="VolumetricFlow")]
        VolumetricFlow = 6,
    }
    
    public enum Curve_Triquadratic_OutputUnitType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Capacity")]
        Capacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Pressure")]
        Pressure = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
    }
    
    [Description("Sets up curve information for minor loss and/or friction calculations in plant pr" +
        "essure simulations Expression: DeltaP = {K + f*(L/D)} * (rho * V^2) / 2")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Curve_Functional_PressureDrop
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("\"D\" in above expression, used to also calculate local velocity")]
[JsonProperty(PropertyName="diameter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Diameter { get; set; } = null;
        

[Description("\"K\" in above expression")]
[JsonProperty(PropertyName="minor_loss_coefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinorLossCoefficient { get; set; } = null;
        

[Description("\"L\" in above expression")]
[JsonProperty(PropertyName="length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Length { get; set; } = null;
        

[Description("This will be used to calculate \"f\" from Moody-chart approximations")]
[JsonProperty(PropertyName="roughness", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Roughness { get; set; } = null;
        

[Description("Optional way to set a constant value for \"f\", instead of using internal Moody-cha" +
    "rt approximations")]
[JsonProperty(PropertyName="fixed_friction_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FixedFrictionFactor { get; set; } = null;
    }
    
    [Description(@"Special curve type with two independent variables. Input for the fan total pressure rise curve consists of the curve name, the four coefficients, and the maximum and minimum valid independent variable values. Optional inputs for the curve minimum and maximum may be used to limit the output of the performance curve. curve = C1*Qfan**2+C2*Qfan+C3*Qfan*(Psm-Po)**0.5+C4*(Psm-Po) Po assumed to be zero See InputOut Reference for curve details")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Curve_FanPressureRise
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="coefficient1_c1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1C1 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient2_c2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2C2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient3_c3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3C3 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient4_c4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient4C4 { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_qfan", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfQfan { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_qfan", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfQfan { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_psm", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfPsm { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_psm", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfPsm { get; set; } = null;
        

[Description("Specify the minimum value calculated by this curve object")]
[JsonProperty(PropertyName="minimum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCurveOutput { get; set; } = null;
        

[Description("Specify the maximum value calculated by this curve object")]
[JsonProperty(PropertyName="maximum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCurveOutput { get; set; } = null;
    }
    
    [Description(@"Exponential-modified skew normal curve with one independent variable. Input consists of the curve name, the four coefficients, and the maximum and minimum valid independent variable values. Optional inputs for the curve minimum and maximum may be used to limit the output of the performance curve. curve = see Input Output Reference")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Curve_ExponentialSkewNormal
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="coefficient1_c1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1C1 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient2_c2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2C2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient3_c3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3C3 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient4_c4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient4C4 { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfX { get; set; } = null;
        

[Description("Specify the minimum value calculated by this curve object")]
[JsonProperty(PropertyName="minimum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCurveOutput { get; set; } = null;
        

[Description("Specify the maximum value calculated by this curve object")]
[JsonProperty(PropertyName="maximum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCurveOutput { get; set; } = null;
        

[JsonProperty(PropertyName="input_unit_type_for_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_ExponentialSkewNormal_InputUnitTypeForX InputUnitTypeForX { get; set; } = (Curve_ExponentialSkewNormal_InputUnitTypeForX)Enum.Parse(typeof(Curve_ExponentialSkewNormal_InputUnitTypeForX), "Dimensionless");
        

[JsonProperty(PropertyName="output_unit_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_ExponentialSkewNormal_OutputUnitType OutputUnitType { get; set; } = (Curve_ExponentialSkewNormal_OutputUnitType)Enum.Parse(typeof(Curve_ExponentialSkewNormal_OutputUnitType), "Dimensionless");
    }
    
    public enum Curve_ExponentialSkewNormal_InputUnitTypeForX
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
    }
    
    public enum Curve_ExponentialSkewNormal_OutputUnitType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Capacity")]
        Capacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Pressure")]
        Pressure = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
    }
    
    [Description(@"Sigmoid curve with one independent variable. Input consists of the curve name, the five coefficients, and the maximum and minimum valid independent variable values. Optional inputs for the curve minimum and maximum may be used to limit the output of the performance curve. curve = C1+C2/[1+exp((C3-x)/C4)]**C5")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Curve_Sigmoid
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="coefficient1_c1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1C1 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient2_c2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2C2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient3_c3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3C3 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient4_c4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient4C4 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient5_c5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient5C5 { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfX { get; set; } = null;
        

[Description("Specify the minimum value calculated by this curve object")]
[JsonProperty(PropertyName="minimum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCurveOutput { get; set; } = null;
        

[Description("Specify the maximum value calculated by this curve object")]
[JsonProperty(PropertyName="maximum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCurveOutput { get; set; } = null;
        

[JsonProperty(PropertyName="input_unit_type_for_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_Sigmoid_InputUnitTypeForX InputUnitTypeForX { get; set; } = (Curve_Sigmoid_InputUnitTypeForX)Enum.Parse(typeof(Curve_Sigmoid_InputUnitTypeForX), "Dimensionless");
        

[JsonProperty(PropertyName="output_unit_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_Sigmoid_OutputUnitType OutputUnitType { get; set; } = (Curve_Sigmoid_OutputUnitType)Enum.Parse(typeof(Curve_Sigmoid_OutputUnitType), "Dimensionless");
    }
    
    public enum Curve_Sigmoid_InputUnitTypeForX
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
    }
    
    public enum Curve_Sigmoid_OutputUnitType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Capacity")]
        Capacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Pressure")]
        Pressure = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
    }
    
    [Description(@"Rectangular hyperbola type 1 curve with one independent variable. Input consists of the curve name, the three coefficients, and the maximum and minimum valid independent variable values. Optional inputs for the curve minimum and maximum may be used to limit the output of the performance curve. curve = ((C1*x)/(C2+x))+C3")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Curve_RectangularHyperbola1
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="coefficient1_c1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1C1 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient2_c2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2C2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient3_c3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3C3 { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfX { get; set; } = null;
        

[Description("Specify the minimum value calculated by this curve object")]
[JsonProperty(PropertyName="minimum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCurveOutput { get; set; } = null;
        

[Description("Specify the maximum value calculated by this curve object")]
[JsonProperty(PropertyName="maximum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCurveOutput { get; set; } = null;
        

[JsonProperty(PropertyName="input_unit_type_for_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_RectangularHyperbola1_InputUnitTypeForX InputUnitTypeForX { get; set; } = (Curve_RectangularHyperbola1_InputUnitTypeForX)Enum.Parse(typeof(Curve_RectangularHyperbola1_InputUnitTypeForX), "Dimensionless");
        

[JsonProperty(PropertyName="output_unit_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_RectangularHyperbola1_OutputUnitType OutputUnitType { get; set; } = (Curve_RectangularHyperbola1_OutputUnitType)Enum.Parse(typeof(Curve_RectangularHyperbola1_OutputUnitType), "Dimensionless");
    }
    
    public enum Curve_RectangularHyperbola1_InputUnitTypeForX
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
    }
    
    public enum Curve_RectangularHyperbola1_OutputUnitType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Capacity")]
        Capacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Pressure")]
        Pressure = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
    }
    
    [Description(@"Rectangular hyperbola type 2 curve with one independent variable. Input consists of the curve name, the three coefficients, and the maximum and minimum valid independent variable values. Optional inputs for the curve minimum and maximum may be used to limit the output of the performance curve. curve = ((C1*x)/(C2+x))+(C3*x)")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Curve_RectangularHyperbola2
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="coefficient1_c1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1C1 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient2_c2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2C2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient3_c3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3C3 { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfX { get; set; } = null;
        

[Description("Specify the minimum value calculated by this curve object")]
[JsonProperty(PropertyName="minimum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCurveOutput { get; set; } = null;
        

[Description("Specify the maximum value calculated by this curve object")]
[JsonProperty(PropertyName="maximum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCurveOutput { get; set; } = null;
        

[JsonProperty(PropertyName="input_unit_type_for_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_RectangularHyperbola2_InputUnitTypeForX InputUnitTypeForX { get; set; } = (Curve_RectangularHyperbola2_InputUnitTypeForX)Enum.Parse(typeof(Curve_RectangularHyperbola2_InputUnitTypeForX), "Dimensionless");
        

[JsonProperty(PropertyName="output_unit_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_RectangularHyperbola2_OutputUnitType OutputUnitType { get; set; } = (Curve_RectangularHyperbola2_OutputUnitType)Enum.Parse(typeof(Curve_RectangularHyperbola2_OutputUnitType), "Dimensionless");
    }
    
    public enum Curve_RectangularHyperbola2_InputUnitTypeForX
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
    }
    
    public enum Curve_RectangularHyperbola2_OutputUnitType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Capacity")]
        Capacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Pressure")]
        Pressure = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
    }
    
    [Description(@"Exponential decay curve with one independent variable. Input consists of the curve name, the three coefficients, and the maximum and minimum valid independent variable values. Optional inputs for the curve minimum and maximum may be used to limit the output of the performance curve. curve = C1+C2*exp(C3*x)")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Curve_ExponentialDecay
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="coefficient1_c1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1C1 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient2_c2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2C2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient3_c3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3C3 { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfX { get; set; } = null;
        

[Description("Specify the minimum value calculated by this curve object")]
[JsonProperty(PropertyName="minimum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCurveOutput { get; set; } = null;
        

[Description("Specify the maximum value calculated by this curve object")]
[JsonProperty(PropertyName="maximum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCurveOutput { get; set; } = null;
        

[JsonProperty(PropertyName="input_unit_type_for_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_ExponentialDecay_InputUnitTypeForX InputUnitTypeForX { get; set; } = (Curve_ExponentialDecay_InputUnitTypeForX)Enum.Parse(typeof(Curve_ExponentialDecay_InputUnitTypeForX), "Dimensionless");
        

[JsonProperty(PropertyName="output_unit_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_ExponentialDecay_OutputUnitType OutputUnitType { get; set; } = (Curve_ExponentialDecay_OutputUnitType)Enum.Parse(typeof(Curve_ExponentialDecay_OutputUnitType), "Dimensionless");
    }
    
    public enum Curve_ExponentialDecay_InputUnitTypeForX
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
    }
    
    public enum Curve_ExponentialDecay_OutputUnitType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Capacity")]
        Capacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Pressure")]
        Pressure = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
    }
    
    [Description(@"Double exponential decay curve with one independent variable. Input consists of the curve name, the five coefficients, and the maximum and minimum valid independent variable values. Optional inputs for the curve minimum and maximum may be used to limit the output of the performance curve. curve = C1+C2*exp(C3*x)+C4*exp(C5*x)")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Curve_DoubleExponentialDecay
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="coefficient1_c1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1C1 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient2_c2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2C2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient3_c3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3C3 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient4_c4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient4C4 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient5_c5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient5C5 { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfX { get; set; } = null;
        

[Description("Specify the minimum value calculated by this curve object")]
[JsonProperty(PropertyName="minimum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCurveOutput { get; set; } = null;
        

[Description("Specify the maximum value calculated by this curve object")]
[JsonProperty(PropertyName="maximum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCurveOutput { get; set; } = null;
        

[JsonProperty(PropertyName="input_unit_type_for_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_DoubleExponentialDecay_InputUnitTypeForX InputUnitTypeForX { get; set; } = (Curve_DoubleExponentialDecay_InputUnitTypeForX)Enum.Parse(typeof(Curve_DoubleExponentialDecay_InputUnitTypeForX), "Dimensionless");
        

[JsonProperty(PropertyName="output_unit_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_DoubleExponentialDecay_OutputUnitType OutputUnitType { get; set; } = (Curve_DoubleExponentialDecay_OutputUnitType)Enum.Parse(typeof(Curve_DoubleExponentialDecay_OutputUnitType), "Dimensionless");
    }
    
    public enum Curve_DoubleExponentialDecay_InputUnitTypeForX
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
    }
    
    public enum Curve_DoubleExponentialDecay_OutputUnitType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Capacity")]
        Capacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Pressure")]
        Pressure = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
    }
    
    [Description(@"This chiller part-load performance curve has three independent variables. Input consists of the curve name, the twelve coefficients, and the maximum and minimum valid independent variable values. Optional inputs for the curve minimum and maximum may be used to limit the output of the performance curve. curve = C1 + C2*x + C3*x**2 + C4*y + C5*y**2 + C6*x*y + C7*x**3 + C8*y**3 + C9*x**2*y + C10*x*y**2 + C11*x**2*y**2 + C12*z*y**3 x = dT* = normalized fractional Lift = dT / dTref y = PLR = part load ratio (cooling load/steady state capacity) z = Tdev* = normalized Tdev = Tdev / dTref Where: dT = Lift = Leaving Condenser Water Temperature - Leaving Chilled Water Temperature dTref = dT at the reference condition Tdev = Leaving Chilled Water Temperature - Reference Chilled Water Temperature")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Curve_ChillerPartLoadWithLift
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="coefficient1_c1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient1C1 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient2_c2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient2C2 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient3_c3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient3C3 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient4_c4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient4C4 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient5_c5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient5C5 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient6_c6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient6C6 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient7_c7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient7C7 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient8_c8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient8C8 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient9_c9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient9C9 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient10_c10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient10C10 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient11_c11", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient11C11 { get; set; } = null;
        

[JsonProperty(PropertyName="coefficient12_c12", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Coefficient12C12 { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfX { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfY { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfY { get; set; } = null;
        

[JsonProperty(PropertyName="minimum_value_of_z", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumValueOfZ { get; set; } = null;
        

[JsonProperty(PropertyName="maximum_value_of_z", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumValueOfZ { get; set; } = null;
        

[Description("Specify the minimum value calculated by this curve object")]
[JsonProperty(PropertyName="minimum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MinimumCurveOutput { get; set; } = null;
        

[Description("Specify the maximum value calculated by this curve object")]
[JsonProperty(PropertyName="maximum_curve_output", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MaximumCurveOutput { get; set; } = null;
        

[JsonProperty(PropertyName="input_unit_type_for_x", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_ChillerPartLoadWithLift_InputUnitTypeForX InputUnitTypeForX { get; set; } = (Curve_ChillerPartLoadWithLift_InputUnitTypeForX)Enum.Parse(typeof(Curve_ChillerPartLoadWithLift_InputUnitTypeForX), "Dimensionless");
        

[JsonProperty(PropertyName="input_unit_type_for_y", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_ChillerPartLoadWithLift_InputUnitTypeForY InputUnitTypeForY { get; set; } = (Curve_ChillerPartLoadWithLift_InputUnitTypeForY)Enum.Parse(typeof(Curve_ChillerPartLoadWithLift_InputUnitTypeForY), "Dimensionless");
        

[JsonProperty(PropertyName="input_unit_type_for_z", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_ChillerPartLoadWithLift_InputUnitTypeForZ InputUnitTypeForZ { get; set; } = (Curve_ChillerPartLoadWithLift_InputUnitTypeForZ)Enum.Parse(typeof(Curve_ChillerPartLoadWithLift_InputUnitTypeForZ), "Dimensionless");
        

[JsonProperty(PropertyName="output_unit_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public Curve_ChillerPartLoadWithLift_OutputUnitType OutputUnitType { get; set; } = (Curve_ChillerPartLoadWithLift_OutputUnitType)Enum.Parse(typeof(Curve_ChillerPartLoadWithLift_OutputUnitType), "Dimensionless");
    }
    
    public enum Curve_ChillerPartLoadWithLift_InputUnitTypeForX
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
    }
    
    public enum Curve_ChillerPartLoadWithLift_InputUnitTypeForY
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
    }
    
    public enum Curve_ChillerPartLoadWithLift_InputUnitTypeForZ
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 1,
    }
    
    public enum Curve_ChillerPartLoadWithLift_OutputUnitType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Capacity")]
        Capacity = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Power")]
        Power = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Pressure")]
        Pressure = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Temperature")]
        Temperature = 5,
    }
}
