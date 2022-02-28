namespace EnergyPlus.Economics
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
    
    
    [Description("If CurrencyType is not specified, it will default to USD and produce $ in the rep" +
        "orts.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class CurrencyType
    {
        

[Description("The commonly used three letter currency code for the units of money for the count" +
    "ry or region. Based on ISO 4217 currency codes. Common currency codes are USD fo" +
    "r $ and EUR for Euros.")]
[JsonProperty(PropertyName="monetary_unit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public CurrencyType_MonetaryUnit MonetaryUnit { get; set; } = (CurrencyType_MonetaryUnit)Enum.Parse(typeof(CurrencyType_MonetaryUnit), "AFN");
    }
    
    public enum CurrencyType_MonetaryUnit
    {
        
        [System.Runtime.Serialization.EnumMember(Value="AFN")]
        AFN = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ALL")]
        ALL = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ANG")]
        ANG = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ARS")]
        ARS = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="AUD")]
        AUD = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="AWG")]
        AWG = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="AZN")]
        AZN = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="BAM")]
        BAM = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="BBD")]
        BBD = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="BGN")]
        BGN = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="BMD")]
        BMD = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="BND")]
        BND = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="BOB")]
        BOB = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="BRL")]
        BRL = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="BSD")]
        BSD = 14,
        
        [System.Runtime.Serialization.EnumMember(Value="BWP")]
        BWP = 15,
        
        [System.Runtime.Serialization.EnumMember(Value="BYR")]
        BYR = 16,
        
        [System.Runtime.Serialization.EnumMember(Value="BZD")]
        BZD = 17,
        
        [System.Runtime.Serialization.EnumMember(Value="CAD")]
        CAD = 18,
        
        [System.Runtime.Serialization.EnumMember(Value="CHF")]
        CHF = 19,
        
        [System.Runtime.Serialization.EnumMember(Value="CLP")]
        CLP = 20,
        
        [System.Runtime.Serialization.EnumMember(Value="CNY")]
        CNY = 21,
        
        [System.Runtime.Serialization.EnumMember(Value="COP")]
        COP = 22,
        
        [System.Runtime.Serialization.EnumMember(Value="CRC")]
        CRC = 23,
        
        [System.Runtime.Serialization.EnumMember(Value="CUP")]
        CUP = 24,
        
        [System.Runtime.Serialization.EnumMember(Value="CZK")]
        CZK = 25,
        
        [System.Runtime.Serialization.EnumMember(Value="DKK")]
        DKK = 26,
        
        [System.Runtime.Serialization.EnumMember(Value="DOP")]
        DOP = 27,
        
        [System.Runtime.Serialization.EnumMember(Value="EEK")]
        EEK = 28,
        
        [System.Runtime.Serialization.EnumMember(Value="EGP")]
        EGP = 29,
        
        [System.Runtime.Serialization.EnumMember(Value="EUR")]
        EUR = 30,
        
        [System.Runtime.Serialization.EnumMember(Value="FJD")]
        FJD = 31,
        
        [System.Runtime.Serialization.EnumMember(Value="GBP")]
        GBP = 32,
        
        [System.Runtime.Serialization.EnumMember(Value="GHC")]
        GHC = 33,
        
        [System.Runtime.Serialization.EnumMember(Value="GIP")]
        GIP = 34,
        
        [System.Runtime.Serialization.EnumMember(Value="GTQ")]
        GTQ = 35,
        
        [System.Runtime.Serialization.EnumMember(Value="GYD")]
        GYD = 36,
        
        [System.Runtime.Serialization.EnumMember(Value="HKD")]
        HKD = 37,
        
        [System.Runtime.Serialization.EnumMember(Value="HNL")]
        HNL = 38,
        
        [System.Runtime.Serialization.EnumMember(Value="HRK")]
        HRK = 39,
        
        [System.Runtime.Serialization.EnumMember(Value="HUF")]
        HUF = 40,
        
        [System.Runtime.Serialization.EnumMember(Value="IDR")]
        IDR = 41,
        
        [System.Runtime.Serialization.EnumMember(Value="ILS")]
        ILS = 42,
        
        [System.Runtime.Serialization.EnumMember(Value="IMP")]
        IMP = 43,
        
        [System.Runtime.Serialization.EnumMember(Value="INR")]
        INR = 44,
        
        [System.Runtime.Serialization.EnumMember(Value="IRR")]
        IRR = 45,
        
        [System.Runtime.Serialization.EnumMember(Value="ISK")]
        ISK = 46,
        
        [System.Runtime.Serialization.EnumMember(Value="JEP")]
        JEP = 47,
        
        [System.Runtime.Serialization.EnumMember(Value="JMD")]
        JMD = 48,
        
        [System.Runtime.Serialization.EnumMember(Value="JPY")]
        JPY = 49,
        
        [System.Runtime.Serialization.EnumMember(Value="KGS")]
        KGS = 50,
        
        [System.Runtime.Serialization.EnumMember(Value="KHR")]
        KHR = 51,
        
        [System.Runtime.Serialization.EnumMember(Value="KPW")]
        KPW = 52,
        
        [System.Runtime.Serialization.EnumMember(Value="KRW")]
        KRW = 53,
        
        [System.Runtime.Serialization.EnumMember(Value="KYD")]
        KYD = 54,
        
        [System.Runtime.Serialization.EnumMember(Value="KZT")]
        KZT = 55,
        
        [System.Runtime.Serialization.EnumMember(Value="LAK")]
        LAK = 56,
        
        [System.Runtime.Serialization.EnumMember(Value="LBP")]
        LBP = 57,
        
        [System.Runtime.Serialization.EnumMember(Value="LKR")]
        LKR = 58,
        
        [System.Runtime.Serialization.EnumMember(Value="LRD")]
        LRD = 59,
        
        [System.Runtime.Serialization.EnumMember(Value="LTL")]
        LTL = 60,
        
        [System.Runtime.Serialization.EnumMember(Value="LVL")]
        LVL = 61,
        
        [System.Runtime.Serialization.EnumMember(Value="MKD")]
        MKD = 62,
        
        [System.Runtime.Serialization.EnumMember(Value="MNT")]
        MNT = 63,
        
        [System.Runtime.Serialization.EnumMember(Value="MUR")]
        MUR = 64,
        
        [System.Runtime.Serialization.EnumMember(Value="MXN")]
        MXN = 65,
        
        [System.Runtime.Serialization.EnumMember(Value="MYR")]
        MYR = 66,
        
        [System.Runtime.Serialization.EnumMember(Value="MZN")]
        MZN = 67,
        
        [System.Runtime.Serialization.EnumMember(Value="NAD")]
        NAD = 68,
        
        [System.Runtime.Serialization.EnumMember(Value="NGN")]
        NGN = 69,
        
        [System.Runtime.Serialization.EnumMember(Value="NIO")]
        NIO = 70,
        
        [System.Runtime.Serialization.EnumMember(Value="NOK")]
        NOK = 71,
        
        [System.Runtime.Serialization.EnumMember(Value="NPR")]
        NPR = 72,
        
        [System.Runtime.Serialization.EnumMember(Value="NZD")]
        NZD = 73,
        
        [System.Runtime.Serialization.EnumMember(Value="OMR")]
        OMR = 74,
        
        [System.Runtime.Serialization.EnumMember(Value="PAB")]
        PAB = 75,
        
        [System.Runtime.Serialization.EnumMember(Value="PEN")]
        PEN = 76,
        
        [System.Runtime.Serialization.EnumMember(Value="PHP")]
        PHP = 77,
        
        [System.Runtime.Serialization.EnumMember(Value="PKR")]
        PKR = 78,
        
        [System.Runtime.Serialization.EnumMember(Value="PLN")]
        PLN = 79,
        
        [System.Runtime.Serialization.EnumMember(Value="PYG")]
        PYG = 80,
        
        [System.Runtime.Serialization.EnumMember(Value="QAR")]
        QAR = 81,
        
        [System.Runtime.Serialization.EnumMember(Value="RON")]
        RON = 82,
        
        [System.Runtime.Serialization.EnumMember(Value="RSD")]
        RSD = 83,
        
        [System.Runtime.Serialization.EnumMember(Value="RUB")]
        RUB = 84,
        
        [System.Runtime.Serialization.EnumMember(Value="SAR")]
        SAR = 85,
        
        [System.Runtime.Serialization.EnumMember(Value="SBD")]
        SBD = 86,
        
        [System.Runtime.Serialization.EnumMember(Value="SCR")]
        SCR = 87,
        
        [System.Runtime.Serialization.EnumMember(Value="SEK")]
        SEK = 88,
        
        [System.Runtime.Serialization.EnumMember(Value="SGD")]
        SGD = 89,
        
        [System.Runtime.Serialization.EnumMember(Value="SHP")]
        SHP = 90,
        
        [System.Runtime.Serialization.EnumMember(Value="SOS")]
        SOS = 91,
        
        [System.Runtime.Serialization.EnumMember(Value="SRD")]
        SRD = 92,
        
        [System.Runtime.Serialization.EnumMember(Value="SVC")]
        SVC = 93,
        
        [System.Runtime.Serialization.EnumMember(Value="SYP")]
        SYP = 94,
        
        [System.Runtime.Serialization.EnumMember(Value="THB")]
        THB = 95,
        
        [System.Runtime.Serialization.EnumMember(Value="TRL")]
        TRL = 96,
        
        [System.Runtime.Serialization.EnumMember(Value="TRY")]
        TRY = 97,
        
        [System.Runtime.Serialization.EnumMember(Value="TTD")]
        TTD = 98,
        
        [System.Runtime.Serialization.EnumMember(Value="TVD")]
        TVD = 99,
        
        [System.Runtime.Serialization.EnumMember(Value="TWD")]
        TWD = 100,
        
        [System.Runtime.Serialization.EnumMember(Value="UAH")]
        UAH = 101,
        
        [System.Runtime.Serialization.EnumMember(Value="USD")]
        USD = 102,
        
        [System.Runtime.Serialization.EnumMember(Value="UYU")]
        UYU = 103,
        
        [System.Runtime.Serialization.EnumMember(Value="UZS")]
        UZS = 104,
        
        [System.Runtime.Serialization.EnumMember(Value="VEF")]
        VEF = 105,
        
        [System.Runtime.Serialization.EnumMember(Value="VND")]
        VND = 106,
        
        [System.Runtime.Serialization.EnumMember(Value="XCD")]
        XCD = 107,
        
        [System.Runtime.Serialization.EnumMember(Value="YER")]
        YER = 108,
        
        [System.Runtime.Serialization.EnumMember(Value="ZAR")]
        ZAR = 109,
        
        [System.Runtime.Serialization.EnumMember(Value="ZWD")]
        ZWD = 110,
    }
    
    [Description("Used to perform various modifications to the construction costs to arrive at an e" +
        "stimate for total project costs. This object allows extending the line item mode" +
        "l so that the overall costs of the project will reflect various profit and fees." +
        "")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ComponentCost_Adjustments
    {
        

[Description("based on conditioned floor area for cost not accounted for in current line item c" +
    "ost model")]
[JsonProperty(PropertyName="miscellaneous_cost_per_conditioned_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MiscellaneousCostPerConditionedArea { get; set; } = null;
        

[JsonProperty(PropertyName="design_and_engineering_fees", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DesignAndEngineeringFees { get; set; } = null;
        

[JsonProperty(PropertyName="contractor_fee", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ContractorFee { get; set; } = null;
        

[JsonProperty(PropertyName="contingency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Contingency { get; set; } = null;
        

[JsonProperty(PropertyName="permits_bonding_and_insurance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> PermitsBondingAndInsurance { get; set; } = null;
        

[JsonProperty(PropertyName="commissioning_fee", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CommissioningFee { get; set; } = null;
        

[Description("for use with average data in line item and Misc cost models")]
[JsonProperty(PropertyName="regional_adjustment_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RegionalAdjustmentFactor { get; set; } = null;
    }
    
    [Description(@"Used to allow comparing the current cost estimate to the results of a previous estimate for a reference building. This object parallels the ComponentCost:Adjustments object but adds a field for entering the cost line item model result for the reference building. The factors entered in this object are applied to the reference building while the factors listed in the ComponentCost:Adjustments object are applied to the current building model cost estimate.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ComponentCost_Reference
    {
        

[Description("should be comparable to the components in current line item cost model")]
[JsonProperty(PropertyName="reference_building_line_item_costs", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReferenceBuildingLineItemCosts { get; set; } = null;
        

[Description("based on conditioned floor area for cost not accounted for in reference line item" +
    " costs")]
[JsonProperty(PropertyName="reference_building_miscellaneous_cost_per_conditioned_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReferenceBuildingMiscellaneousCostPerConditionedArea { get; set; } = null;
        

[JsonProperty(PropertyName="reference_building_design_and_engineering_fees", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReferenceBuildingDesignAndEngineeringFees { get; set; } = null;
        

[JsonProperty(PropertyName="reference_building_contractor_fee", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReferenceBuildingContractorFee { get; set; } = null;
        

[JsonProperty(PropertyName="reference_building_contingency", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReferenceBuildingContingency { get; set; } = null;
        

[JsonProperty(PropertyName="reference_building_permits_bonding_and_insurance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReferenceBuildingPermitsBondingAndInsurance { get; set; } = null;
        

[JsonProperty(PropertyName="reference_building_commissioning_fee", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReferenceBuildingCommissioningFee { get; set; } = null;
        

[Description("for use with average data in line item and Misc cost models")]
[JsonProperty(PropertyName="reference_building_regional_adjustment_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ReferenceBuildingRegionalAdjustmentFactor { get; set; } = null;
    }
    
    [Description("Each instance of this object creates a cost line item and will contribute to the " +
        "total for a cost estimate.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class ComponentCost_LineItem
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Type { get; set; } = "";
        

[Description("extend choice-keys as Cases are added to code")]
[JsonProperty(PropertyName="line_item_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public ComponentCost_LineItem_LineItemType LineItemType { get; set; } = (ComponentCost_LineItem_LineItemType)Enum.Parse(typeof(ComponentCost_LineItem_LineItemType), "ChillerElectric");
        

[Description("wildcard \"*\" is acceptable for some components")]
[JsonProperty(PropertyName="item_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ItemName { get; set; } = "";
        

[Description("not yet used")]
[JsonProperty(PropertyName="object_end_use_key", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ObjectEndUseKey { get; set; } = "";
        

[JsonProperty(PropertyName="cost_per_each", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CostPerEach { get; set; } = null;
        

[JsonProperty(PropertyName="cost_per_area", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CostPerArea { get; set; } = null;
        

[JsonProperty(PropertyName="cost_per_unit_of_output_capacity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CostPerUnitOfOutputCapacity { get; set; } = null;
        

[Description("The value is per change in COP.")]
[JsonProperty(PropertyName="cost_per_unit_of_output_capacity_per_cop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CostPerUnitOfOutputCapacityPerCop { get; set; } = null;
        

[JsonProperty(PropertyName="cost_per_volume", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CostPerVolume { get; set; } = null;
        

[JsonProperty(PropertyName="cost_per_volume_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CostPerVolumeRate { get; set; } = null;
        

[Description("as in for use with UA sizing of Coils")]
[JsonProperty(PropertyName="cost_per_energy_per_temperature_difference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> CostPerEnergyPerTemperatureDifference { get; set; } = null;
        

[Description("optional for use with Cost per Each and \"General\" object Type")]
[JsonProperty(PropertyName="quantity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Quantity { get; set; } = null;
    }
    
    public enum ComponentCost_LineItem_LineItemType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Chiller:Electric")]
        ChillerElectric = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Cooling:DX:SingleSpeed")]
        CoilCoolingDXSingleSpeed = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:DX")]
        CoilDX = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Coil:Heating:Fuel")]
        CoilHeatingFuel = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Construction")]
        Construction = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Daylighting:Controls")]
        DaylightingControls = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="General")]
        General = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="Generator:Photovoltaic")]
        GeneratorPhotovoltaic = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Lights")]
        Lights = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Shading:Zone:Detailed")]
        ShadingZoneDetailed = 9,
    }
    
    [Description(@"Defines the name of a utility cost tariff, the type of tariff, and other details about the overall tariff. Each other object that is part of the tariff model references the tariff name. See UtilityCost:Charge:Simple, UtilityCost:Charge:Block, UtilityCost:Ratchet, UtilityCost:Qualify, UtilityCost:Variable and UtilityCost:Computation objects.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class UtilityCost_Tariff
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("The name of any standard meter or custom meter or but usually set to either Elect" +
    "ricity:Facility or Gas:Facility")]
[JsonProperty(PropertyName="output_meter_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OutputMeterName { get; set; } = "";
        

[Description("A choice that allows several different predefined conversion factors to be used; " +
    "otherwise user defined conversion factors are used as defined in the next two fi" +
    "elds. If left blank m3 is used for water meters and kWh are used for all other m" +
    "eters.")]
[JsonProperty(PropertyName="conversion_factor_choice", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public UtilityCost_Tariff_ConversionFactorChoice ConversionFactorChoice { get; set; } = (UtilityCost_Tariff_ConversionFactorChoice)Enum.Parse(typeof(UtilityCost_Tariff_ConversionFactorChoice), "CCF");
        

[Description(@"Is a multiplier used to convert energy into the units specified by the utility in their tariff. If left blank it defaults to 1 (no conversion). This field should will be used only if Conversion Factor Choice is set to UserDefined. Within EnergyPlus energy always has units of J (joules). For conversion from J to kWh use the value of 0.0000002778. This is also used for all objects that reference the UtilityCost:Tariff.")]
[JsonProperty(PropertyName="energy_conversion_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EnergyConversionFactor { get; set; } = null;
        

[Description(@"Is a multiplier used to convert demand into the units specified by the utility in their tariff. If left blank it defaults to 1 (no conversion). This field should will be used only if Conversion Factor Choice is set to UserDefined. Within EnergyPlus demand always has units of J/s (joules/sec) which equivalent to W (watts). For conversion from W to kW use the value of 0.001. This is also used for all objects that reference the UtilityCost:Tariff.")]
[JsonProperty(PropertyName="demand_conversion_factor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DemandConversionFactor { get; set; } = null;
        

[Description(@"The name of the schedule that defines the time-of-use periods that occur each day. The values for the different variables are: 1 for Peak. 2 for Shoulder. 3 for OffPeak. 4 for MidPeak. The following variables are created automatically if these different periods are used in the schedule and include: TotalEnergy, TotalDemand, PeakEnergy, PeakDemand, ShoulderEnergy, ShoulderDemand, OffPeakEnergy, OffPeakDemand, MidPeakEnergy, MidPeakDemand Some special variables are created that include: PeakExceedsOffPeak, OffPeakExceedsPeak, PeakExceedsMidPeak, MidPeakExceedsPeak, PeakExceedsShoulder, ShoulderExceedsPeak, Others include: PeakAndShoulderEnergy, PeakAndShoulderDemand, PeakAndMidPeakEnergy, PeakAndMidPeakDemand, ShoulderAndOffPeakEnergy, ShoulderAndOffPeakDemand, PeakAndOffPeakEnergy, PeakAndOffPeakDemand, RealTimePriceCosts, AboveCustomerBaseCosts, BelowCustomerBaseCosts, AboveCustomerBaseEnergy, BelowCustomerBaseEnergy")]
[JsonProperty(PropertyName="time_of_use_period_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TimeOfUsePeriodScheduleName { get; set; } = "";
        

[Description(@"The name of a schedule that defines the seasons. The schedule values are: 1 for Winter. 2 for Spring. 3 for Summer. 4 for Autumn. Variables are automatically created if a season schedule is used. These variables are set to 1 within the season and 0 for the months that are not in the season. The variables are: IsWinter, IsNotWinter, IsSpring, IsNotSpring, IsSummer, IsNotSummer, IsAutumn, IsNotAutumn.")]
[JsonProperty(PropertyName="season_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SeasonScheduleName { get; set; } = "";
        

[Description(@"The name of the schedule that defines the billing periods of the year. Normally this entry is allowed to default and a schedule will be internally used that has the breaks between billing periods occurring at the same time as the breaks between months i.e. at midnight prior to the first day of the month. If other billing periods are used such as two month cycles or a single bill for an entire season such as some natural gas companies do in the summer then the month schedule may be used to redefine it. Make sure that the month schedule and season schedule are consistent otherwise an error will be issued.")]
[JsonProperty(PropertyName="month_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MonthScheduleName { get; set; } = "";
        

[Description(@"The determination of demand can vary by utility. Some utilities use the peak instantaneous demand measured but most use a fifteen minute average demand or a one hour average demand. Some gas utilities measure demand as the use during the peak day or peak week.")]
[JsonProperty(PropertyName="demand_window_length", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public UtilityCost_Tariff_DemandWindowLength DemandWindowLength { get; set; } = (UtilityCost_Tariff_DemandWindowLength)Enum.Parse(typeof(UtilityCost_Tariff_DemandWindowLength), "Day");
        

[Description("The fixed monthly service charge that many utilities have. The entry may be numer" +
    "ic and gets added to the ServiceCharges variable or if a variable name is entere" +
    "d here its values for each month are used.")]
[JsonProperty(PropertyName="monthly_charge_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MonthlyChargeOrVariableName { get; set; } = "";
        

[Description("The minimum total charge for the tariff or if a variable name is entered here its" +
    " values for each month are used.")]
[JsonProperty(PropertyName="minimum_monthly_charge_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MinimumMonthlyChargeOrVariableName { get; set; } = "";
        

[Description("Used with real time pricing rates. The name of a schedule that contains the cost " +
    "of energy for that particular time period of the year. Real time rates can be mo" +
    "deled using a charge schedule with the actual real time prices entered in the sc" +
    "hedule.")]
[JsonProperty(PropertyName="real_time_pricing_charge_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RealTimePricingChargeScheduleName { get; set; } = "";
        

[Description("Used with real time pricing rates. The name of a schedule that contains the basel" +
    "ine energy use for the customer. Many real time rates apply the charges as a cre" +
    "dit or debit only to the difference between the baseline use and the actual use." +
    "")]
[JsonProperty(PropertyName="customer_baseline_load_schedule_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CustomerBaselineLoadScheduleName { get; set; } = "";
        

[Description(@"The group name of the tariff such as distribution transmission supplier etc. If more than one tariff with the same group name is present and qualifies only the lowest cost tariff is used. Usually the group name field is left blank which results in all tariffs using the same meter variable being compared and the lowest cost one being selected.")]
[JsonProperty(PropertyName="group_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string GroupName { get; set; } = "";
        

[Description(@"Sets whether the tariff is used for buying selling or both to the utility. This should be allowed to default to buyFromUtility unless a power generation system is included in the building that may generate more power than the building needs during the year")]
[JsonProperty(PropertyName="buy_or_sell", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public UtilityCost_Tariff_BuyOrSell BuyOrSell { get; set; } = (UtilityCost_Tariff_BuyOrSell)Enum.Parse(typeof(UtilityCost_Tariff_BuyOrSell), "BuyFromUtility");
    }
    
    public enum UtilityCost_Tariff_ConversionFactorChoice
    {
        
        [System.Runtime.Serialization.EnumMember(Value="CCF")]
        CCF = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="MCF")]
        MCF = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="MJ")]
        MJ = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MMBtu")]
        MMBtu = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Therm")]
        Therm = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="UserDefined")]
        UserDefined = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="gal")]
        Gal = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="kBtu")]
        KBtu = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="kWh")]
        KWh = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="kgal")]
        Kgal = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="m3")]
        M3 = 10,
    }
    
    public enum UtilityCost_Tariff_DemandWindowLength
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Day")]
        Day = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="FullHour")]
        FullHour = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="HalfHour")]
        HalfHour = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="QuarterHour")]
        QuarterHour = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Week")]
        Week = 4,
    }
    
    public enum UtilityCost_Tariff_BuyOrSell
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BuyFromUtility")]
        BuyFromUtility = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="NetMetering")]
        NetMetering = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="SellToUtility")]
        SellToUtility = 3,
    }
    
    [Description(@"The qualify object allows only tariffs to be selected based on limits which may apply such as maximum or minimum demand requirements. If the results of the simulation fall outside of the range of qualifications, that tariff is still calculated but the ""Qualified"" entry will say ""No"" and the UtilityCost:Qualify that caused its exclusion is shown. Multiple UtilityCost:Qualify objects can appear for the same tariff and they can be based on any variable.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class UtilityCost_Qualify
    {
        

[Description("Displayed in the report if the tariff does not qualify")]
[JsonProperty(PropertyName="utility_cost_qualify_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UtilityCostQualifyName { get; set; } = "";
        

[Description("The name of the UtilityCost:Tariff that is associated with this UtilityCost:Quali" +
    "fy.")]
[JsonProperty(PropertyName="tariff_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TariffName { get; set; } = "";
        

[Description("The name of the variable used. For energy and demand the automatically created va" +
    "riables totalEnergy and totalDemand should be used respectively.")]
[JsonProperty(PropertyName="variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string VariableName { get; set; } = "";
        

[JsonProperty(PropertyName="qualify_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public UtilityCost_Qualify_QualifyType QualifyType { get; set; } = (UtilityCost_Qualify_QualifyType)Enum.Parse(typeof(UtilityCost_Qualify_QualifyType), "Maximum");
        

[Description(@"The minimum or maximum value for the qualify. If the variable has values that are less than this value when the qualify type is minimum then the tariff may be disqualified. If the variable has values that are greater than this value when the qualify type is maximum then the tariff may be disqualified.")]
[JsonProperty(PropertyName="threshold_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ThresholdValueOrVariableName { get; set; } = "";
        

[Description("If the UtilityCost:Qualify only applies to a season enter the season name. If thi" +
    "s field is left blank it defaults to Annual.")]
[JsonProperty(PropertyName="season", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public UtilityCost_Qualify_Season Season { get; set; } = (UtilityCost_Qualify_Season)Enum.Parse(typeof(UtilityCost_Qualify_Season), "Annual");
        

[Description(@"Uses the number in Number of Months in one of two different ways depending on the Threshold  Test. If the Threshold Test is set to Count then the qualification is based on the count of the total number of months per year. If the Threshold Test is set to consecutive then the qualification is based on a consecutive number of months.")]
[JsonProperty(PropertyName="threshold_test", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public UtilityCost_Qualify_ThresholdTest ThresholdTest { get; set; } = (UtilityCost_Qualify_ThresholdTest)Enum.Parse(typeof(UtilityCost_Qualify_ThresholdTest), "Consecutive");
        

[Description(@"A number from 1 to 12. If no value entered 12 is assumed when the qualify type is minimum and 1 when the qualify type is maximum. This is the number of months that the threshold test applies to determine if the rate qualifies or not. If the season is less than 12 months (if it is not annual) then the value is automatically reduced to the number of months of the season.")]
[JsonProperty(PropertyName="number_of_months", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NumberOfMonths { get; set; } = null;
    }
    
    public enum UtilityCost_Qualify_QualifyType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Maximum")]
        Maximum = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Minimum")]
        Minimum = 2,
    }
    
    public enum UtilityCost_Qualify_Season
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Annual")]
        Annual = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fall")]
        Fall = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Spring")]
        Spring = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Summer")]
        Summer = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Winter")]
        Winter = 4,
    }
    
    public enum UtilityCost_Qualify_ThresholdTest
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Consecutive")]
        Consecutive = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Count")]
        Count = 2,
    }
    
    [Description(@"UtilityCost:Charge:Simple is one of the most often used objects for tariff calculation. It is used to compute energy and demand charges that are very simple. It may also be used for taxes, surcharges and any other charges that occur on a utility bill. Multiple UtilityCost:Charge:Simple objects may be defined for a single tariff and they will be added together.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class UtilityCost_Charge_Simple
    {
        

[Description(@"Charge Variable Name This is the name associated with the UtilityCost:Charge:Simple object and will appear in the report. In addition the results of the UtilityCost:Charge:Simple calculation are stored in a variable with the same name. That way the results may be used for further calculation. Spaces are not significant in Charge variable names. They are removed during the utility bill calculation process.")]
[JsonProperty(PropertyName="utility_cost_charge_simple_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UtilityCostChargeSimpleName { get; set; } = "";
        

[Description("The name of the UtilityCost:Tariff that is associated with this UtilityCost:Charg" +
    "e:Simple.")]
[JsonProperty(PropertyName="tariff_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TariffName { get; set; } = "";
        

[Description(@"The name of the source used by the UtilityCost:Charge:Simple. This is usually the name of the variable holding the energy or demand but may also be the name of any variable including the subtotal or basis if other charges are based on those. Typical values include totalEnergy totalDemand EnergyCharges DemandCharges ServiceCharges Basis Adjustments Surcharges Subtotal Taxes and Total. If it is a time-of-use rate then peakEnergy peakDemand shoulderEnergy shoulderDemand offPeakEnergy offPeakDemand midPeakEnergy and midPeakDemand. In addition see the Tariff Report to see other native variables that may be available. Also you can create additional user defined variables to model complex tariffs.")]
[JsonProperty(PropertyName="source_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SourceVariable { get; set; } = "";
        

[Description("If this is set to annual the calculations are performed for the UtilityCost:Charg" +
    "e:Simple for the entire year (all months) otherwise it is calculated only for th" +
    "ose months in the season defined.")]
[JsonProperty(PropertyName="season", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public UtilityCost_Charge_Simple_Season Season { get; set; } = (UtilityCost_Charge_Simple_Season)Enum.Parse(typeof(UtilityCost_Charge_Simple_Season), "Annual");
        

[Description("This field shows where the charge should be added. The reason to enter this field" +
    " appropriately is so that the charge gets reported in a reasonable category. The" +
    " charge automatically gets added to the variable that is the category.")]
[JsonProperty(PropertyName="category_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public UtilityCost_Charge_Simple_CategoryVariableName CategoryVariableName { get; set; } = (UtilityCost_Charge_Simple_CategoryVariableName)Enum.Parse(typeof(UtilityCost_Charge_Simple_CategoryVariableName), "Adjustment");
        

[Description(@"This field contains either a single number or the name of a variable. The number is multiplied with all of the energy or demand or other source that is specified in the source field. If a variable is used then the monthly values of the variable are multiplied against the variable specified in the source field. This field makes it easy to include a simple charge without specifying block sizes. This is a good way to include a tax or cost adjustment.")]
[JsonProperty(PropertyName="cost_per_unit_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string CostPerUnitValueOrVariableName { get; set; } = "";
    }
    
    public enum UtilityCost_Charge_Simple_Season
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Annual")]
        Annual = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fall")]
        Fall = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Spring")]
        Spring = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Summer")]
        Summer = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Winter")]
        Winter = 4,
    }
    
    public enum UtilityCost_Charge_Simple_CategoryVariableName
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Adjustment")]
        Adjustment = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Basis")]
        Basis = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DemandCharges")]
        DemandCharges = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="EnergyCharges")]
        EnergyCharges = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="NotIncluded")]
        NotIncluded = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="ServiceCharges")]
        ServiceCharges = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Subtotal")]
        Subtotal = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="Surcharge")]
        Surcharge = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Taxes")]
        Taxes = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Total")]
        Total = 9,
    }
    
    [Description("Used to compute energy and demand charges (or any other charges) that are structu" +
        "red in blocks of charges. Multiple UtilityCost:Charge:Block objects may be defin" +
        "ed for a single tariff and they will be added together.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class UtilityCost_Charge_Block
    {
        

[Description(@"Charge Variable Name This is the name associated with the UtilityCost:Charge:Block object and will appear in the report. In addition the results of the UtilityCost:Charge:Block are stored in a variable with the same name. That way the results may be used for further calculation.")]
[JsonProperty(PropertyName="utility_cost_charge_block_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string UtilityCostChargeBlockName { get; set; } = "";
        

[Description("The name of the UtilityCost:Tariff that is associated with this UtilityCost:Charg" +
    "e:Block.")]
[JsonProperty(PropertyName="tariff_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TariffName { get; set; } = "";
        

[Description(@"The name of the source used by the UtilityCost:Charge:Block. This is usually the name of the variable holding the energy or demand but may also be the name of any variable including the subtotal or basis if other charges are based on those. Typical values include totalEnergy totalDemand EnergyCharges DemandCharges ServiceCharges Basis Adjustments Surcharges Subtotal Taxes and Total. If it is a time-of-use rate then peakEnergy peakDemand shoulderEnergy shoulderDemand offPeakEnergy offPeakDemand midPeakEnergy and midPeakDemand. In addition see the Tariff Report to see other native variables that may be available. Also you can create additional user defined variables to model complex tariffs.")]
[JsonProperty(PropertyName="source_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string SourceVariable { get; set; } = "";
        

[Description("If this is set to annual the calculations are performed for the UtilityCost:Charg" +
    "e:Block for the entire year (all months) otherwise it is calculated only for tho" +
    "se months in the season defined.")]
[JsonProperty(PropertyName="season", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public UtilityCost_Charge_Block_Season Season { get; set; } = (UtilityCost_Charge_Block_Season)Enum.Parse(typeof(UtilityCost_Charge_Block_Season), "Annual");
        

[Description("This field shows where the charge should be added. The reason to enter this field" +
    " appropriately is so that the charge gets reported in a reasonable category. The" +
    " charge automatically gets added to the variable that is the category.")]
[JsonProperty(PropertyName="category_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public UtilityCost_Charge_Block_CategoryVariableName CategoryVariableName { get; set; } = (UtilityCost_Charge_Block_CategoryVariableName)Enum.Parse(typeof(UtilityCost_Charge_Block_CategoryVariableName), "Adjustment");
        

[Description(@"If the blocks do not use all of the energy or demand from the source some energy and demand remains then the remaining amount should be assigned to a variable. If no variable is assigned and some amount of energy or demand is not used in the block structure a warning will be issued.")]
[JsonProperty(PropertyName="remaining_into_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string RemainingIntoVariable { get; set; } = "";
        

[Description(@"The sizes of the blocks are usually used directly but if a value or a variable is entered here the block sizes entered in the rest of the charge are first multiplied by the entered value prior to being used. This is common for rates that are kWh/kW rates and in that case the variable that holds the monthly total electric demand would be entered. If no value is entered a default value of one is assumed so that the block sizes remain exactly as entered. This field is unusual for the EnergyPlus syntax because it can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_size_multiplier_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BlockSizeMultiplierValueOrVariableName { get; set; } = "";
        

[Description(@"The size of the block of the charges is entered here. For most rates that use multiple blocks this will be the value for the block size. Using remaining may be used when the remaining amount should be included in that block. This field is unusual because it can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_size_1_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BlockSize1ValueOrVariableName { get; set; } = "";
        

[Description("The cost of the block. This field is unusual for the EnergyPlus syntax because it" +
    " can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_1_cost_per_unit_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Block1CostPerUnitValueOrVariableName { get; set; } = "";
        

[Description(@"The size of the block of the charges is entered here. For most rates that use multiple blocks this will be the value for the block size. Using remaining may be used when the remaining amount should be included in that block. This field is unusual because it can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_size_2_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BlockSize2ValueOrVariableName { get; set; } = "";
        

[Description("The cost of the block. This field is unusual for the EnergyPlus syntax because it" +
    " can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_2_cost_per_unit_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Block2CostPerUnitValueOrVariableName { get; set; } = "";
        

[Description(@"The size of the block of the charges is entered here. For most rates that use multiple blocks this will be the value for the block size. Using remaining may be used when the remaining amount should be included in that block. This field is unusual because it can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_size_3_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BlockSize3ValueOrVariableName { get; set; } = "";
        

[Description("The cost of the block. This field is unusual for the EnergyPlus syntax because it" +
    " can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_3_cost_per_unit_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Block3CostPerUnitValueOrVariableName { get; set; } = "";
        

[Description(@"The size of the block of the charges is entered here. For most rates that use multiple blocks this will be the value for the block size. Using remaining may be used when the remaining amount should be included in that block. This field is unusual because it can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_size_4_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BlockSize4ValueOrVariableName { get; set; } = "";
        

[Description("The cost of the block. This field is unusual for the EnergyPlus syntax because it" +
    " can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_4_cost_per_unit_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Block4CostPerUnitValueOrVariableName { get; set; } = "";
        

[Description(@"The size of the block of the charges is entered here. For most rates that use multiple blocks this will be the value for the block size. Using remaining may be used when the remaining amount should be included in that block. This field is unusual because it can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_size_5_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BlockSize5ValueOrVariableName { get; set; } = "";
        

[Description("The cost of the block. This field is unusual for the EnergyPlus syntax because it" +
    " can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_5_cost_per_unit_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Block5CostPerUnitValueOrVariableName { get; set; } = "";
        

[Description(@"The size of the block of the charges is entered here. For most rates that use multiple blocks this will be the value for the block size. Using remaining may be used when the remaining amount should be included in that block. This field is unusual because it can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_size_6_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BlockSize6ValueOrVariableName { get; set; } = "";
        

[Description("The cost of the block. This field is unusual for the EnergyPlus syntax because it" +
    " can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_6_cost_per_unit_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Block6CostPerUnitValueOrVariableName { get; set; } = "";
        

[Description(@"The size of the block of the charges is entered here. For most rates that use multiple blocks this will be the value for the block size. Using remaining may be used when the remaining amount should be included in that block. This field is unusual because it can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_size_7_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BlockSize7ValueOrVariableName { get; set; } = "";
        

[Description("The cost of the block. This field is unusual for the EnergyPlus syntax because it" +
    " can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_7_cost_per_unit_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Block7CostPerUnitValueOrVariableName { get; set; } = "";
        

[Description(@"The size of the block of the charges is entered here. For most rates that use multiple blocks this will be the value for the block size. Using remaining may be used when the remaining amount should be included in that block. This field is unusual because it can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_size_8_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BlockSize8ValueOrVariableName { get; set; } = "";
        

[Description("The cost of the block. This field is unusual for the EnergyPlus syntax because it" +
    " can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_8_cost_per_unit_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Block8CostPerUnitValueOrVariableName { get; set; } = "";
        

[Description(@"The size of the block of the charges is entered here. For most rates that use multiple blocks this will be the value for the block size. Using remaining may be used when the remaining amount should be included in that block. This field is unusual because it can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_size_9_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BlockSize9ValueOrVariableName { get; set; } = "";
        

[Description("The cost of the block. This field is unusual for the EnergyPlus syntax because it" +
    " can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_9_cost_per_unit_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Block9CostPerUnitValueOrVariableName { get; set; } = "";
        

[Description(@"The size of the block of the charges is entered here. For most rates that use multiple blocks this will be the value for the block size. Using remaining may be used when the remaining amount should be included in that block. This field is unusual because it can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_size_10_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BlockSize10ValueOrVariableName { get; set; } = "";
        

[Description("The cost of the block. This field is unusual for the EnergyPlus syntax because it" +
    " can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_10_cost_per_unit_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Block10CostPerUnitValueOrVariableName { get; set; } = "";
        

[Description(@"The size of the block of the charges is entered here. For most rates that use multiple blocks this will be the value for the block size. Using remaining may be used when the remaining amount should be included in that block. This field is unusual because it can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_size_11_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BlockSize11ValueOrVariableName { get; set; } = "";
        

[Description("The cost of the block. This field is unusual for the EnergyPlus syntax because it" +
    " can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_11_cost_per_unit_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Block11CostPerUnitValueOrVariableName { get; set; } = "";
        

[Description(@"The size of the block of the charges is entered here. For most rates that use multiple blocks this will be the value for the block size. Using remaining may be used when the remaining amount should be included in that block. This field is unusual because it can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_size_12_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BlockSize12ValueOrVariableName { get; set; } = "";
        

[Description("The cost of the block. This field is unusual for the EnergyPlus syntax because it" +
    " can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_12_cost_per_unit_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Block12CostPerUnitValueOrVariableName { get; set; } = "";
        

[Description(@"The size of the block of the charges is entered here. For most rates that use multiple blocks this will be the value for the block size. Using remaining may be used when the remaining amount should be included in that block. This field is unusual because it can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_size_13_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BlockSize13ValueOrVariableName { get; set; } = "";
        

[Description("The cost of the block. This field is unusual for the EnergyPlus syntax because it" +
    " can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_13_cost_per_unit_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Block13CostPerUnitValueOrVariableName { get; set; } = "";
        

[Description(@"The size of the block of the charges is entered here. For most rates that use multiple blocks this will be the value for the block size. Using remaining may be used when the remaining amount should be included in that block. This field is unusual because it can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_size_14_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BlockSize14ValueOrVariableName { get; set; } = "";
        

[Description("The cost of the block. This field is unusual for the EnergyPlus syntax because it" +
    " can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_14_cost_per_unit_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Block14CostPerUnitValueOrVariableName { get; set; } = "";
        

[Description(@"The size of the block of the charges is entered here. For most rates that use multiple blocks this will be the value for the block size. Using remaining may be used when the remaining amount should be included in that block. This field is unusual because it can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_size_15_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BlockSize15ValueOrVariableName { get; set; } = "";
        

[Description("The cost of the block. This field is unusual for the EnergyPlus syntax because it" +
    " can be either a number or a name of a variable.")]
[JsonProperty(PropertyName="block_15_cost_per_unit_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Block15CostPerUnitValueOrVariableName { get; set; } = "";
    }
    
    public enum UtilityCost_Charge_Block_Season
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Annual")]
        Annual = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Fall")]
        Fall = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Spring")]
        Spring = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Summer")]
        Summer = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Winter")]
        Winter = 5,
    }
    
    public enum UtilityCost_Charge_Block_CategoryVariableName
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Adjustment")]
        Adjustment = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Basis")]
        Basis = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="DemandCharges")]
        DemandCharges = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="EnergyCharges")]
        EnergyCharges = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="NotIncluded")]
        NotIncluded = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="ServiceCharges")]
        ServiceCharges = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Subtotal")]
        Subtotal = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="Surcharge")]
        Surcharge = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="Taxes")]
        Taxes = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Total")]
        Total = 9,
    }
    
    [Description(@"Allows the modeling of tariffs that include some type of seasonal ratcheting. Ratchets are most common when used with electric demand charges. A ratchet is when a utility requires that the demand charge for a month with a low demand may be increased to be more consistent with a month that set a higher demand charge.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class UtilityCost_Ratchet
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("The name of the UtilityCost:Tariff that is associated with this UtilityCost:Ratch" +
    "et.")]
[JsonProperty(PropertyName="tariff_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TariffName { get; set; } = "";
        

[Description(@"When the ratcheted value exceeds the baseline value for a month the ratcheted value is used but when the baseline value is greater then the ratcheted value the baseline value is used. Usually the electric demand charge is used. The baseline source variable can be the results of another ratchet object. This allows utility tariffs that have multiple ratchets to be modeled.")]
[JsonProperty(PropertyName="baseline_source_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string BaselineSourceVariable { get; set; } = "";
        

[Description(@"The variable that the ratchet is calculated from. It is often but not always the same as the baseline source variable. The ratcheting calculations using offset and multiplier are using the values from the adjustment source variable. If left blank the adjustment source variable is the same as the baseline source variable.")]
[JsonProperty(PropertyName="adjustment_source_variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string AdjustmentSourceVariable { get; set; } = "";
        

[Description(@"The name of the season that is being examined. The maximum value for all of the months in the named season is what is used with the multiplier and offset. This is most commonly Summer or Annual. When Monthly is used the adjustment source variable is used directly for all months.")]
[JsonProperty(PropertyName="season_from", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public UtilityCost_Ratchet_SeasonFrom SeasonFrom { get; set; } = (UtilityCost_Ratchet_SeasonFrom)Enum.Parse(typeof(UtilityCost_Ratchet_SeasonFrom), "Annual");
        

[Description(@"The name of the season when the ratchet would be calculated. This is most commonly Winter. The ratchet only is applied to the months in the named season. The resulting variable for months not in the Season To selection will contain the values as appear in the baseline source variable.")]
[JsonProperty(PropertyName="season_to", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public UtilityCost_Ratchet_SeasonTo SeasonTo { get; set; } = (UtilityCost_Ratchet_SeasonTo)Enum.Parse(typeof(UtilityCost_Ratchet_SeasonTo), "Annual");
        

[Description(@"Often the ratchet has a clause such as ""the current month demand or 90% of the summer month demand"". For this case a value of 0.9 would be entered here as the multiplier. This value may be left blank if no multiplier is needed and a value of one will be used as a default.")]
[JsonProperty(PropertyName="multiplier_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string MultiplierValueOrVariableName { get; set; } = "";
        

[Description(@"A less common strategy is to say that the ratchet must be all demand greater than a value in this case an offset that is added to the demand may be entered here. If entered it is common for the offset value to be negative representing that the demand be reduced. If no value is entered it is assumed to be zero and not affect the ratchet.")]
[JsonProperty(PropertyName="offset_value_or_variable_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string OffsetValueOrVariableName { get; set; } = "";
    }
    
    public enum UtilityCost_Ratchet_SeasonFrom
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Annual")]
        Annual = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fall")]
        Fall = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Monthly")]
        Monthly = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Spring")]
        Spring = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Summer")]
        Summer = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="Winter")]
        Winter = 5,
    }
    
    public enum UtilityCost_Ratchet_SeasonTo
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Annual")]
        Annual = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Fall")]
        Fall = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Spring")]
        Spring = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Summer")]
        Summer = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Winter")]
        Winter = 4,
    }
    
    [Description("Allows for the direct entry of monthly values into a utility tariff variable.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class UtilityCost_Variable
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("The name of the UtilityCost:Tariff that is associated with this UtilityCost:Varia" +
    "ble.")]
[JsonProperty(PropertyName="tariff_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TariffName { get; set; } = "";
        

[JsonProperty(PropertyName="variable_type", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public UtilityCost_Variable_VariableType VariableType { get; set; } = (UtilityCost_Variable_VariableType)Enum.Parse(typeof(UtilityCost_Variable_VariableType), "Dimensionless");
        

[JsonProperty(PropertyName="january_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> JanuaryValue { get; set; } = null;
        

[JsonProperty(PropertyName="february_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> FebruaryValue { get; set; } = null;
        

[JsonProperty(PropertyName="march_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MarchValue { get; set; } = null;
        

[JsonProperty(PropertyName="april_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AprilValue { get; set; } = null;
        

[JsonProperty(PropertyName="may_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MayValue { get; set; } = null;
        

[JsonProperty(PropertyName="june_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> JuneValue { get; set; } = null;
        

[JsonProperty(PropertyName="july_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> JulyValue { get; set; } = null;
        

[JsonProperty(PropertyName="august_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AugustValue { get; set; } = null;
        

[JsonProperty(PropertyName="september_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> SeptemberValue { get; set; } = null;
        

[JsonProperty(PropertyName="october_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> OctoberValue { get; set; } = null;
        

[JsonProperty(PropertyName="november_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NovemberValue { get; set; } = null;
        

[JsonProperty(PropertyName="december_value", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> DecemberValue { get; set; } = null;
    }
    
    public enum UtilityCost_Variable_VariableType
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Currency")]
        Currency = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Demand")]
        Demand = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Dimensionless")]
        Dimensionless = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Energy")]
        Energy = 4,
    }
    
    [Description(@"The object lists a series of computations that are used to perform the utility bill calculation. The object is only used for complex tariffs that cannot be modeled any other way. For most utility tariffs, UtilityCost:Computation is unnecessary and should be avoided. If UtilityCost:Computation is used, it must contain references to all objects involved in the rate in the order that they should be computed.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class UtilityCost_Computation
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("The name of the UtilityCost:Tariff that is associated with this UtilityCost:Varia" +
    "ble.")]
[JsonProperty(PropertyName="tariff_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string TariffName { get; set; } = "";
        

[Description("Contain a simple language that describes the steps used in the computation proces" +
    "s similar to a programming language.")]
[JsonProperty(PropertyName="compute_step_1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep1 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep2 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_3", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep3 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_4", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep4 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_5", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep5 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_6", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep6 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_7", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep7 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_8", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep8 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_9", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep9 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_10", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep10 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_11", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep11 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_12", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep12 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_13", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep13 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_14", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep14 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_15", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep15 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_16", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep16 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_17", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep17 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_18", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep18 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_19", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep19 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_20", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep20 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_21", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep21 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_22", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep22 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_23", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep23 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_24", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep24 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_25", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep25 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_26", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep26 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_27", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep27 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_28", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep28 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_29", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep29 { get; set; } = "";
        

[JsonProperty(PropertyName="compute_step_30", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string ComputeStep30 { get; set; } = "";
    }
    
    [Description(@"Provides inputs related to the overall life-cycle analysis. It establishes many of the assumptions used in computing the present value. It is important that when comparing the results of multiple simulations that the fields in the LifeCycleCost:Parameters objects are the same for all the simulations. When this object is present the tabular report file will contain the Life-Cycle Cost Report.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class LifeCycleCost_Parameters
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[Description("The field specifies if the discounting of future costs should be computed as occu" +
    "rring at the end of each year or the middle of each year or the beginning of eac" +
    "h year. The most common discounting convention uses the end of each year.")]
[JsonProperty(PropertyName="discounting_convention", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public LifeCycleCost_Parameters_DiscountingConvention DiscountingConvention { get; set; } = (LifeCycleCost_Parameters_DiscountingConvention)Enum.Parse(typeof(LifeCycleCost_Parameters_DiscountingConvention), "EndOfYear");
        

[Description(@"This field is used to determine if the analysis should use constant dollars or current dollars which is related to how inflation is treated. If ConstantDollar is selected then the Real Discount Rate input is used and it excludes the rate of inflation. If CurrentDollar is selected then the Nominal Discount Rate input is used and it includes the rate of inflation.")]
[JsonProperty(PropertyName="inflation_approach", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public LifeCycleCost_Parameters_InflationApproach InflationApproach { get; set; } = (LifeCycleCost_Parameters_InflationApproach)Enum.Parse(typeof(LifeCycleCost_Parameters_InflationApproach), "ConstantDollar");
        

[Description(@"Enter the real discount rate as a decimal. For a 3% rate enter the value 0.03. This input is used when the Inflation Approach is ConstantDollar. The real discount rate reflects the interest rates needed to make current and future expenditures have comparable equivalent values when general inflation is ignored. When Inflation Approach is set to CurrentDollar this input is ignored.")]
[JsonProperty(PropertyName="real_discount_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RealDiscountRate { get; set; } = null;
        

[Description(@"Enter the nominal discount rate as a decimal. For a 5% rate enter the value 0.05. This input is used when the Inflation Approach is CurrentDollar. The real discount rate reflects the interest rates needed to make current and future expenditures have comparable equivalent values when general inflation is included. When Inflation Approach is set to ConstantDollar this input is ignored.")]
[JsonProperty(PropertyName="nominal_discount_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> NominalDiscountRate { get; set; } = null;
        

[Description("Enter the rate of inflation for general goods and services as a decimal. For a 2%" +
    " rate enter the value 0.02.")]
[JsonProperty(PropertyName="inflation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Inflation { get; set; } = null;
        

[Description("Enter the month that is the beginning of study period also known as the beginning" +
    " of the base period.")]
[JsonProperty(PropertyName="base_date_month", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public LifeCycleCost_Parameters_BaseDateMonth BaseDateMonth { get; set; } = (LifeCycleCost_Parameters_BaseDateMonth)Enum.Parse(typeof(LifeCycleCost_Parameters_BaseDateMonth), "January");
        

[Description("Enter the four digit year that is the beginning of study period such as 2010. The" +
    " study period is also known as the base period.")]
[JsonProperty(PropertyName="base_date_year", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> BaseDateYear { get; set; } = null;
        

[Description(@"Enter the month that is the beginning of building occupancy. Energy costs computed by EnergyPlus are assumed to occur during the year following the service date. The service date must be the same or later than the Base Date. This field could also be referred to as part of beneficial occupancy date.")]
[JsonProperty(PropertyName="service_date_month", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public LifeCycleCost_Parameters_ServiceDateMonth ServiceDateMonth { get; set; } = (LifeCycleCost_Parameters_ServiceDateMonth)Enum.Parse(typeof(LifeCycleCost_Parameters_ServiceDateMonth), "January");
        

[Description("Enter the four digit year that is the beginning of occupancy such as 2010.")]
[JsonProperty(PropertyName="service_date_year", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> ServiceDateYear { get; set; } = null;
        

[Description("Enter the number of years of the study period. It is the number of years that the" +
    " study continues based on the start at the base date. The default value is 25 ye" +
    "ars. Only integers may be used indicating whole years.")]
[JsonProperty(PropertyName="length_of_study_period_in_years", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> LengthOfStudyPeriodInYears { get; set; } = null;
        

[Description(@"Enter the overall marginal tax rate for the project costs. This does not include energy or water taxes. The tax rate entered should be based on the marginal tax rate for the entity and not the average tax rate. Enter the tax rate results in present value calculations after taxes. Most analyses do not factor in the impact of taxes and assume that all options under consideration have roughly the same tax impact. Due to this many times the tax rate can be left to default to zero and the present value results before taxes are used to make decisions. The value should be entered as a decimal value. For 15% enter 0.15. For an analysis that does not include tax impacts enter 0.0.")]
[JsonProperty(PropertyName="tax_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> TaxRate { get; set; } = null;
        

[Description("For an analysis that includes income tax impacts this entry describes how capital" +
    " costs are depreciated. Only one depreciation method may be used for an analysis" +
    " and is applied to all capital expenditures.")]
[JsonProperty(PropertyName="depreciation_method", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public LifeCycleCost_Parameters_DepreciationMethod DepreciationMethod { get; set; } = (LifeCycleCost_Parameters_DepreciationMethod)Enum.Parse(typeof(LifeCycleCost_Parameters_DepreciationMethod), "None");
    }
    
    public enum LifeCycleCost_Parameters_DiscountingConvention
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BeginningOfYear")]
        BeginningOfYear = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="EndOfYear")]
        EndOfYear = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MidYear")]
        MidYear = 3,
    }
    
    public enum LifeCycleCost_Parameters_InflationApproach
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ConstantDollar")]
        ConstantDollar = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="CurrentDollar")]
        CurrentDollar = 2,
    }
    
    public enum LifeCycleCost_Parameters_BaseDateMonth
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="April")]
        April = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="August")]
        August = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="December")]
        December = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="February")]
        February = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="January")]
        January = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="July")]
        July = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="June")]
        June = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="March")]
        March = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="May")]
        May = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="November")]
        November = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="October")]
        October = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="September")]
        September = 12,
    }
    
    public enum LifeCycleCost_Parameters_ServiceDateMonth
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="April")]
        April = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="August")]
        August = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="December")]
        December = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="February")]
        February = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="January")]
        January = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="July")]
        July = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="June")]
        June = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="March")]
        March = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="May")]
        May = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="November")]
        November = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="October")]
        October = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="September")]
        September = 12,
    }
    
    public enum LifeCycleCost_Parameters_DepreciationMethod
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="ModifiedAcceleratedCostRecoverySystem-10year")]
        ModifiedAcceleratedCostRecoverySystem10year = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ModifiedAcceleratedCostRecoverySystem-15year")]
        ModifiedAcceleratedCostRecoverySystem15year = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ModifiedAcceleratedCostRecoverySystem-20year")]
        ModifiedAcceleratedCostRecoverySystem20year = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ModifiedAcceleratedCostRecoverySystem-3year")]
        ModifiedAcceleratedCostRecoverySystem3year = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="ModifiedAcceleratedCostRecoverySystem-5year")]
        ModifiedAcceleratedCostRecoverySystem5year = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="ModifiedAcceleratedCostRecoverySystem-7year")]
        ModifiedAcceleratedCostRecoverySystem7year = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="None")]
        None = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="StraightLine-27year")]
        StraightLine27year = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="StraightLine-31year")]
        StraightLine31year = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="StraightLine-39year")]
        StraightLine39year = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="StraightLine-40year")]
        StraightLine40year = 11,
    }
    
    [Description("Recurring costs are costs that repeat over time on a regular schedule during the " +
        "study period. If costs associated with equipment do repeat but not on a regular " +
        "schedule, use LifeCycleCost:NonrecurringCost objects instead.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class LifeCycleCost_RecurringCosts
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="category", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public LifeCycleCost_RecurringCosts_Category Category { get; set; } = (LifeCycleCost_RecurringCosts_Category)Enum.Parse(typeof(LifeCycleCost_RecurringCosts_Category), "Maintenance");
        

[Description("Enter the cost in dollars (or the appropriate monetary unit) for the recurring co" +
    "sts. Enter the cost for each time it occurs. For example if the annual maintenan" +
    "ce cost is 500 dollars enter 500 here.")]
[JsonProperty(PropertyName="cost", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Cost { get; set; } = null;
        

[Description("Enter when the costs start. The First Year of Cost is based on the number of year" +
    "s past the Start of Costs. For most maintenance costs the Start of Costs should " +
    "be Service Period.")]
[JsonProperty(PropertyName="start_of_costs", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public LifeCycleCost_RecurringCosts_StartOfCosts StartOfCosts { get; set; } = (LifeCycleCost_RecurringCosts_StartOfCosts)Enum.Parse(typeof(LifeCycleCost_RecurringCosts_StartOfCosts), "ServicePeriod");
        

[Description(@"This field and the Months From Start field together represent the time from either the start of the Service Period on the service month and year or start of the Base Period on the base month and year (depending on the Start of Costs field) that the costs start to occur. Only integers should be entered representing whole years.")]
[JsonProperty(PropertyName="years_from_start", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> YearsFromStart { get; set; } = null;
        

[Description(@"This field and the Years From Start field together represent the time from either the start of the Service Period on the service month and year or start of the Base Period on the base month and year (depending on the Start of Costs field) that the costs start to occur. Only integers should be entered representing whole months. The Years From Start (times 12) and Months From Start are added together.")]
[JsonProperty(PropertyName="months_from_start", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MonthsFromStart { get; set; } = null;
        

[Description(@"This field and the Repeat Period Months field indicate how much time elapses between re-occurrences of the cost. For costs that occur every year such the Repeat Period Years should be 1 and Repeat Period Months should be 0. Only integers should be entered representing whole years.")]
[JsonProperty(PropertyName="repeat_period_years", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RepeatPeriodYears { get; set; } = Double.Parse("1", CultureInfo.InvariantCulture);
        

[Description("This field and the Repeat Period Years field indicate how much time elapses betwe" +
    "en re-occurrences of the cost. Only integers should be entered representing whol" +
    "e years. The Repeat Period Years (times 12) and Repeat Period Months are added t" +
    "ogether.")]
[JsonProperty(PropertyName="repeat_period_months", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> RepeatPeriodMonths { get; set; } = Double.Parse("0", CultureInfo.InvariantCulture);
        

[Description("Enter the annual escalation rate as a decimal. For a 1% rate enter the value 0.01" +
    ". This input is used when the Inflation Approach is CurrentDollar. When Inflatio" +
    "n Approach is set to ConstantDollar this input is ignored.")]
[JsonProperty(PropertyName="annual_escalation_rate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> AnnualEscalationRate { get; set; } = null;
    }
    
    public enum LifeCycleCost_RecurringCosts_Category
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Maintenance")]
        Maintenance = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="MajorOverhaul")]
        MajorOverhaul = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="MinorOverhaul")]
        MinorOverhaul = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="Operation")]
        Operation = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherOperational")]
        OtherOperational = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="Repair")]
        Repair = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="Replacement")]
        Replacement = 7,
    }
    
    public enum LifeCycleCost_RecurringCosts_StartOfCosts
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BasePeriod")]
        BasePeriod = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ServicePeriod")]
        ServicePeriod = 2,
    }
    
    [Description("A non-recurring cost happens only once during the study period. For costs that oc" +
        "cur more than once during the study period on a regular schedule, use the LifeCy" +
        "cleCost:RecurringCost object.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class LifeCycleCost_NonrecurringCost
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="category", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public LifeCycleCost_NonrecurringCost_Category Category { get; set; } = (LifeCycleCost_NonrecurringCost_Category)Enum.Parse(typeof(LifeCycleCost_NonrecurringCost_Category), "Construction");
        

[Description(@"Enter the non-recurring cost value. For construction and other capital costs the value entered is typically a positive value. For salvage costs the value entered is typically a negative value which represents the money paid to the investor for the equipment at the end of the study period.")]
[JsonProperty(PropertyName="cost", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> Cost { get; set; } = null;
        

[Description("Enter when the costs start. The First Year of Cost is based on the number of year" +
    "s past the Start of Costs. For most non-recurring costs the Start of Costs shoul" +
    "d be Base Period which begins at the base month and year.")]
[JsonProperty(PropertyName="start_of_costs", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public LifeCycleCost_NonrecurringCost_StartOfCosts StartOfCosts { get; set; } = (LifeCycleCost_NonrecurringCost_StartOfCosts)Enum.Parse(typeof(LifeCycleCost_NonrecurringCost_StartOfCosts), "ServicePeriod");
        

[Description(@"This field and the Months From Start field together represent the time from either the start of the Service Period on the service month and year or start of the Base Period on the base month and year (depending on the Start of Cost field) that the costs start to occur. Only integers should be entered representing whole years.")]
[JsonProperty(PropertyName="years_from_start", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> YearsFromStart { get; set; } = null;
        

[Description(@"This field and the Years From Start field together represent the time from either the start of the Service Period on the service month and year or start of the Base Period on the base month and year (depending on the Start of Cost field) that the costs start to occur. Only integers should be entered representing whole months. The Years From Start (times 12) and Months From Start are added together.")]
[JsonProperty(PropertyName="months_from_start", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> MonthsFromStart { get; set; } = null;
    }
    
    public enum LifeCycleCost_NonrecurringCost_Category
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Construction")]
        Construction = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherCapital")]
        OtherCapital = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="Salvage")]
        Salvage = 3,
    }
    
    public enum LifeCycleCost_NonrecurringCost_StartOfCosts
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="BasePeriod")]
        BasePeriod = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="ServicePeriod")]
        ServicePeriod = 2,
    }
    
    [Description("Life cycle cost escalation factors. The values for this object may be found in th" +
        "e annual supplement to NIST Handbook 135 in Tables Ca-1 to Ca-5 and are included" +
        " in an EnergyPlus dataset file.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class LifeCycleCost_UsePriceEscalation
    {
        

[Description(@"The identifier used for the object. The name usually identifies the location (such as the state or region or country or census area) that the escalations apply to. In addition the name should identify the building class such as residential or commercial or industrial and the use type such as electricity or natural gas or water.")]
[JsonProperty(PropertyName="lcc_price_escalation_name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string LccPriceEscalationName { get; set; } = "";
        

[JsonProperty(PropertyName="resource", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public LifeCycleCost_UsePriceEscalation_Resource Resource { get; set; } = (LifeCycleCost_UsePriceEscalation_Resource)Enum.Parse(typeof(LifeCycleCost_UsePriceEscalation_Resource), "Coal");
        

[Description("This field and the Escalation Start Month define the time that corresponds to Yea" +
    "r 1 Escalation such as 2010 when the escalation rates are applied. This field an" +
    "d the Escalation Start Month define the time that escalation begins.")]
[JsonProperty(PropertyName="escalation_start_year", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Nullable<double> EscalationStartYear { get; set; } = null;
        

[Description("This field and the Escalation Start Year define the time that corresponds to Year" +
    " 1 Escalation such as 2010 when the escalation rates are applied. This field and" +
    " the Escalation Start Year define the time that escalation begins.")]
[JsonProperty(PropertyName="escalation_start_month", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public LifeCycleCost_UsePriceEscalation_EscalationStartMonth EscalationStartMonth { get; set; } = (LifeCycleCost_UsePriceEscalation_EscalationStartMonth)Enum.Parse(typeof(LifeCycleCost_UsePriceEscalation_EscalationStartMonth), "January");
        

[JsonProperty(PropertyName="escalations", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Escalations { get; set; } = "";
    }
    
    public enum LifeCycleCost_UsePriceEscalation_Resource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coal")]
        Coal = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Diesel")]
        Diesel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Electricity")]
        Electricity = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectricityNet")]
        ElectricityNet = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectricityProduced")]
        ElectricityProduced = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectricityPurchased")]
        ElectricityPurchased = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectricitySurplusSold")]
        ElectricitySurplusSold = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo1")]
        FuelOilNo1 = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo2")]
        FuelOilNo2 = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Gasoline")]
        Gasoline = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="NaturalGas")]
        NaturalGas = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel1")]
        OtherFuel1 = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel2")]
        OtherFuel2 = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Propane")]
        Propane = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Steam")]
        Steam = 14,
        
        [System.Runtime.Serialization.EnumMember(Value="Water")]
        Water = 15,
    }
    
    public enum LifeCycleCost_UsePriceEscalation_EscalationStartMonth
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="April")]
        April = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="August")]
        August = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="December")]
        December = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="February")]
        February = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="January")]
        January = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="July")]
        July = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="June")]
        June = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="March")]
        March = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="May")]
        May = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="November")]
        November = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="October")]
        October = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="September")]
        September = 12,
    }
    
    [Description(@"Used by advanced users to adjust the energy or water use costs for future years. This should not be used for compensating for inflation but should only be used to increase the costs of energy or water based on assumed changes to the actual usage, such as anticipated changes in the future function of the building. The adjustments begin at the start of the service period.")]
    [JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class LifeCycleCost_UseAdjustment
    {
        

[Description("This will be the main key of this instance. It will be the main key of the serial" +
    "ization and all other properties will be sub properties of this key.")]
[JsonProperty(PropertyName="name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string NodeName { get; set; } = "";
        

[JsonProperty(PropertyName="resource", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public LifeCycleCost_UseAdjustment_Resource Resource { get; set; } = (LifeCycleCost_UseAdjustment_Resource)Enum.Parse(typeof(LifeCycleCost_UseAdjustment_Resource), "Coal");
        

[JsonProperty(PropertyName="multipliers", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public string Multipliers { get; set; } = "";
    }
    
    public enum LifeCycleCost_UseAdjustment_Resource
    {
        
        [System.Runtime.Serialization.EnumMember(Value="Coal")]
        Coal = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="Diesel")]
        Diesel = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Electricity")]
        Electricity = 2,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectricityNet")]
        ElectricityNet = 3,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectricityProduced")]
        ElectricityProduced = 4,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectricityPurchased")]
        ElectricityPurchased = 5,
        
        [System.Runtime.Serialization.EnumMember(Value="ElectricitySurplusSold")]
        ElectricitySurplusSold = 6,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo1")]
        FuelOilNo1 = 7,
        
        [System.Runtime.Serialization.EnumMember(Value="FuelOilNo2")]
        FuelOilNo2 = 8,
        
        [System.Runtime.Serialization.EnumMember(Value="Gasoline")]
        Gasoline = 9,
        
        [System.Runtime.Serialization.EnumMember(Value="NaturalGas")]
        NaturalGas = 10,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel1")]
        OtherFuel1 = 11,
        
        [System.Runtime.Serialization.EnumMember(Value="OtherFuel2")]
        OtherFuel2 = 12,
        
        [System.Runtime.Serialization.EnumMember(Value="Propane")]
        Propane = 13,
        
        [System.Runtime.Serialization.EnumMember(Value="Steam")]
        Steam = 14,
        
        [System.Runtime.Serialization.EnumMember(Value="Water")]
        Water = 15,
    }
}
