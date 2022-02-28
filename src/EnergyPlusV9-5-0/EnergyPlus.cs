namespace EnergyPlus
{
    using System.ComponentModel;
    using System;
    using System.Globalization;
    using Newtonsoft.Json;
    using AdvancedConstructionSurfaceZoneConcepts;
    using AirDistribution;
    using AirflowNetwork;
    using Coils;
    using ComplianceObjects;
    using CondenserEquipmentandHeatExchangers;
    using Controllers;
    using Daylighting;
    using DemandLimitingControls;
    using DetailedGroundHeatTransfer;
    using Economics;
    using ElectricLoadCenterGeneratorSpecifications;
    using EnergyManagementSystemEMS;
    using EvaporativeCoolers;
    using ExteriorEquipment;
    using ExternalInterface;
    using Fans;
    using FluidProperties;
    using GeneralDataEntry;
    using HeatRecovery;
    using HumidifiersandDehumidifiers;
    using HVACDesignObjects;
    using HVACTemplates;
    using HybridModel;
    using InternalGains;
    using LocationandClimate;
    using NodeBranchManagement;
    using NonZoneEquipment;
    using OperationalFaults;
    using OutputReporting;
    using Parametrics;
    using PerformanceCurves;
    using PerformanceTables;
    using PlantHeatingandCoolingEquipment;
    using PlantCondenserControl;
    using PlantCondenserFlowControl;
    using PlantCondenserLoops;
    using Pumps;
    using PythonPluginSystem;
    using Refrigeration;
    using RoomAirModels;
    using Schedules;
    using SetpointManagers;
    using SimulationParameters;
    using SolarCollectors;
    using SurfaceConstructionElements;
    using SystemAvailabilityManagers;
    using ThermalZonesandSurfaces;
    using UnitaryEquipment;
    using UserDefinedHVACandPlantComponentModels;
    using VariableRefrigerantFlowEquipment;
    using WaterHeatersandThermalStorage;
    using WaterSystems;
    using ZoneAirflow;
    using ZoneHVACAirLoopTerminalUnits;
    using ZoneHVACControlsandThermostats;
    using ZoneHVACEquipmentConnections;
    using ZoneHVACForcedAirUnits;
    using ZoneHVACRadiativeConvectiveUnits;
    
    
    [Description("Ultimate class that can be automatically (de)serialized and simulated.")]
    [Newtonsoft.Json.JsonConverter(typeof(EnergyPlus.JsonConverters.EPJsonJsonConverter))]
    public class EPSimulationFile
    {
        
        public bool ShouldSerializeSurfaceProperty_HeatTransferAlgorithm_List()
        {
            return (SurfaceProperty_HeatTransferAlgorithm_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SurfaceProperty:HeatTransferAlgorithm", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_HeatTransferAlgorithm> SurfaceProperty_HeatTransferAlgorithm_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_HeatTransferAlgorithm> ();
        
        public bool ShouldSerializeSurfaceProperty_HeatTransferAlgorithm_MultipleSurface_List()
        {
            return (SurfaceProperty_HeatTransferAlgorithm_MultipleSurface_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SurfaceProperty:HeatTransferAlgorithm:MultipleSurface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_HeatTransferAlgorithm_MultipleSurface> SurfaceProperty_HeatTransferAlgorithm_MultipleSurface_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_HeatTransferAlgorithm_MultipleSurface> ();
        
        public bool ShouldSerializeSurfaceProperty_HeatTransferAlgorithm_SurfaceList_List()
        {
            return (SurfaceProperty_HeatTransferAlgorithm_SurfaceList_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SurfaceProperty:HeatTransferAlgorithm:SurfaceList", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_HeatTransferAlgorithm_SurfaceList> SurfaceProperty_HeatTransferAlgorithm_SurfaceList_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_HeatTransferAlgorithm_SurfaceList> ();
        
        public bool ShouldSerializeSurfaceProperty_HeatTransferAlgorithm_Construction_List()
        {
            return (SurfaceProperty_HeatTransferAlgorithm_Construction_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SurfaceProperty:HeatTransferAlgorithm:Construction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_HeatTransferAlgorithm_Construction> SurfaceProperty_HeatTransferAlgorithm_Construction_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_HeatTransferAlgorithm_Construction> ();
        
        public bool ShouldSerializeSurfaceProperty_HeatBalanceSourceTerm_List()
        {
            return (SurfaceProperty_HeatBalanceSourceTerm_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SurfaceProperty:HeatBalanceSourceTerm", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_HeatBalanceSourceTerm> SurfaceProperty_HeatBalanceSourceTerm_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_HeatBalanceSourceTerm> ();
        
        public bool ShouldSerializeSurfaceControl_MovableInsulation_List()
        {
            return (SurfaceControl_MovableInsulation_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SurfaceControl:MovableInsulation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceControl_MovableInsulation> SurfaceControl_MovableInsulation_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceControl_MovableInsulation> ();
        
        public bool ShouldSerializeSurfaceProperty_OtherSideCoefficients_List()
        {
            return (SurfaceProperty_OtherSideCoefficients_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SurfaceProperty:OtherSideCoefficients", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_OtherSideCoefficients> SurfaceProperty_OtherSideCoefficients_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_OtherSideCoefficients> ();
        
        public bool ShouldSerializeSurfaceProperty_OtherSideConditionsModel_List()
        {
            return (SurfaceProperty_OtherSideConditionsModel_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SurfaceProperty:OtherSideConditionsModel", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_OtherSideConditionsModel> SurfaceProperty_OtherSideConditionsModel_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_OtherSideConditionsModel> ();
        
        public bool ShouldSerializeSurfaceProperty_Underwater_List()
        {
            return (SurfaceProperty_Underwater_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SurfaceProperty:Underwater", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_Underwater> SurfaceProperty_Underwater_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_Underwater> ();
        
        public bool ShouldSerializeFoundation_Kiva_List()
        {
            return (Foundation_Kiva_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Foundation:Kiva", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.Foundation_Kiva> Foundation_Kiva_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.Foundation_Kiva> ();
        
        public bool ShouldSerializeFoundation_Kiva_Settings_List()
        {
            return (Foundation_Kiva_Settings_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Foundation:Kiva:Settings", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.Foundation_Kiva_Settings> Foundation_Kiva_Settings_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.Foundation_Kiva_Settings> ();
        
        public bool ShouldSerializeSurfaceProperty_ExposedFoundationPerimeter_List()
        {
            return (SurfaceProperty_ExposedFoundationPerimeter_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SurfaceProperty:ExposedFoundationPerimeter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_ExposedFoundationPerimeter> SurfaceProperty_ExposedFoundationPerimeter_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_ExposedFoundationPerimeter> ();
        

[JsonProperty(PropertyName="SurfaceConvectionAlgorithm:Inside:AdaptiveModelSelections", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections SurfaceConvectionAlgorithm_Inside_AdaptiveModelSelections { get; set; } = null;
        

[JsonProperty(PropertyName="SurfaceConvectionAlgorithm:Outside:AdaptiveModelSelections", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections SurfaceConvectionAlgorithm_Outside_AdaptiveModelSelections { get; set; } = null;
        
        public bool ShouldSerializeSurfaceConvectionAlgorithm_Inside_UserCurve_List()
        {
            return (SurfaceConvectionAlgorithm_Inside_UserCurve_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SurfaceConvectionAlgorithm:Inside:UserCurve", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceConvectionAlgorithm_Inside_UserCurve> SurfaceConvectionAlgorithm_Inside_UserCurve_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceConvectionAlgorithm_Inside_UserCurve> ();
        
        public bool ShouldSerializeSurfaceConvectionAlgorithm_Outside_UserCurve_List()
        {
            return (SurfaceConvectionAlgorithm_Outside_UserCurve_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SurfaceConvectionAlgorithm:Outside:UserCurve", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceConvectionAlgorithm_Outside_UserCurve> SurfaceConvectionAlgorithm_Outside_UserCurve_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceConvectionAlgorithm_Outside_UserCurve> ();
        
        public bool ShouldSerializeSurfaceProperty_ConvectionCoefficients_List()
        {
            return (SurfaceProperty_ConvectionCoefficients_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SurfaceProperty:ConvectionCoefficients", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_ConvectionCoefficients> SurfaceProperty_ConvectionCoefficients_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_ConvectionCoefficients> ();
        
        public bool ShouldSerializeSurfaceProperty_ConvectionCoefficients_MultipleSurface_List()
        {
            return (SurfaceProperty_ConvectionCoefficients_MultipleSurface_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SurfaceProperty:ConvectionCoefficients:MultipleSurface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_ConvectionCoefficients_MultipleSurface> SurfaceProperty_ConvectionCoefficients_MultipleSurface_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_ConvectionCoefficients_MultipleSurface> ();
        
        public bool ShouldSerializeSurfaceProperties_VaporCoefficients_List()
        {
            return (SurfaceProperties_VaporCoefficients_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SurfaceProperties:VaporCoefficients", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperties_VaporCoefficients> SurfaceProperties_VaporCoefficients_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperties_VaporCoefficients> ();
        
        public bool ShouldSerializeSurfaceProperty_ExteriorNaturalVentedCavity_List()
        {
            return (SurfaceProperty_ExteriorNaturalVentedCavity_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SurfaceProperty:ExteriorNaturalVentedCavity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_ExteriorNaturalVentedCavity> SurfaceProperty_ExteriorNaturalVentedCavity_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_ExteriorNaturalVentedCavity> ();
        
        public bool ShouldSerializeSurfaceProperty_SolarIncidentInside_List()
        {
            return (SurfaceProperty_SolarIncidentInside_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SurfaceProperty:SolarIncidentInside", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_SolarIncidentInside> SurfaceProperty_SolarIncidentInside_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_SolarIncidentInside> ();
        
        public bool ShouldSerializeSurfaceProperty_LocalEnvironment_List()
        {
            return (SurfaceProperty_LocalEnvironment_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SurfaceProperty:LocalEnvironment", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_LocalEnvironment> SurfaceProperty_LocalEnvironment_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_LocalEnvironment> ();
        
        public bool ShouldSerializeZoneProperty_LocalEnvironment_List()
        {
            return (ZoneProperty_LocalEnvironment_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneProperty:LocalEnvironment", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.ZoneProperty_LocalEnvironment> ZoneProperty_LocalEnvironment_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.ZoneProperty_LocalEnvironment> ();
        
        public bool ShouldSerializeSurfaceProperty_SurroundingSurfaces_List()
        {
            return (SurfaceProperty_SurroundingSurfaces_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SurfaceProperty:SurroundingSurfaces", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_SurroundingSurfaces> SurfaceProperty_SurroundingSurfaces_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.SurfaceProperty_SurroundingSurfaces> ();
        
        public bool ShouldSerializeComplexFenestrationProperty_SolarAbsorbedLayers_List()
        {
            return (ComplexFenestrationProperty_SolarAbsorbedLayers_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ComplexFenestrationProperty:SolarAbsorbedLayers", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.ComplexFenestrationProperty_SolarAbsorbedLayers> ComplexFenestrationProperty_SolarAbsorbedLayers_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.ComplexFenestrationProperty_SolarAbsorbedLayers> ();
        
        public bool ShouldSerializeZoneProperty_UserViewFactors_BySurfaceName_List()
        {
            return (ZoneProperty_UserViewFactors_BySurfaceName_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneProperty:UserViewFactors:BySurfaceName", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.ZoneProperty_UserViewFactors_BySurfaceName> ZoneProperty_UserViewFactors_BySurfaceName_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AdvancedConstructionSurfaceZoneConcepts.ZoneProperty_UserViewFactors_BySurfaceName> ();
        
        public bool ShouldSerializeAirLoopHVAC_List()
        {
            return (AirLoopHVAC_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirLoopHVAC", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC> AirLoopHVAC_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC> ();
        
        public bool ShouldSerializeAirLoopHVAC_OutdoorAirSystem_EquipmentList_List()
        {
            return (AirLoopHVAC_OutdoorAirSystem_EquipmentList_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirLoopHVAC:OutdoorAirSystem:EquipmentList", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC_OutdoorAirSystem_EquipmentList> AirLoopHVAC_OutdoorAirSystem_EquipmentList_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC_OutdoorAirSystem_EquipmentList> ();
        
        public bool ShouldSerializeAirLoopHVAC_OutdoorAirSystem_List()
        {
            return (AirLoopHVAC_OutdoorAirSystem_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirLoopHVAC:OutdoorAirSystem", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC_OutdoorAirSystem> AirLoopHVAC_OutdoorAirSystem_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC_OutdoorAirSystem> ();
        
        public bool ShouldSerializeOutdoorAir_Mixer_List()
        {
            return (OutdoorAir_Mixer_List.Count > 0);
        }
        

[JsonProperty(PropertyName="OutdoorAir:Mixer", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirDistribution.OutdoorAir_Mixer> OutdoorAir_Mixer_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirDistribution.OutdoorAir_Mixer> ();
        
        public bool ShouldSerializeAirLoopHVAC_ZoneSplitter_List()
        {
            return (AirLoopHVAC_ZoneSplitter_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirLoopHVAC:ZoneSplitter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC_ZoneSplitter> AirLoopHVAC_ZoneSplitter_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC_ZoneSplitter> ();
        
        public bool ShouldSerializeAirLoopHVAC_SupplyPlenum_List()
        {
            return (AirLoopHVAC_SupplyPlenum_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirLoopHVAC:SupplyPlenum", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC_SupplyPlenum> AirLoopHVAC_SupplyPlenum_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC_SupplyPlenum> ();
        
        public bool ShouldSerializeAirLoopHVAC_SupplyPath_List()
        {
            return (AirLoopHVAC_SupplyPath_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirLoopHVAC:SupplyPath", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC_SupplyPath> AirLoopHVAC_SupplyPath_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC_SupplyPath> ();
        
        public bool ShouldSerializeAirLoopHVAC_ZoneMixer_List()
        {
            return (AirLoopHVAC_ZoneMixer_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirLoopHVAC:ZoneMixer", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC_ZoneMixer> AirLoopHVAC_ZoneMixer_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC_ZoneMixer> ();
        
        public bool ShouldSerializeAirLoopHVAC_ReturnPlenum_List()
        {
            return (AirLoopHVAC_ReturnPlenum_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirLoopHVAC:ReturnPlenum", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC_ReturnPlenum> AirLoopHVAC_ReturnPlenum_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC_ReturnPlenum> ();
        
        public bool ShouldSerializeAirLoopHVAC_ReturnPath_List()
        {
            return (AirLoopHVAC_ReturnPath_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirLoopHVAC:ReturnPath", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC_ReturnPath> AirLoopHVAC_ReturnPath_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC_ReturnPath> ();
        
        public bool ShouldSerializeAirLoopHVAC_DedicatedOutdoorAirSystem_List()
        {
            return (AirLoopHVAC_DedicatedOutdoorAirSystem_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirLoopHVAC:DedicatedOutdoorAirSystem", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC_DedicatedOutdoorAirSystem> AirLoopHVAC_DedicatedOutdoorAirSystem_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC_DedicatedOutdoorAirSystem> ();
        
        public bool ShouldSerializeAirLoopHVAC_Mixer_List()
        {
            return (AirLoopHVAC_Mixer_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirLoopHVAC:Mixer", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC_Mixer> AirLoopHVAC_Mixer_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC_Mixer> ();
        
        public bool ShouldSerializeAirLoopHVAC_Splitter_List()
        {
            return (AirLoopHVAC_Splitter_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirLoopHVAC:Splitter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC_Splitter> AirLoopHVAC_Splitter_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirDistribution.AirLoopHVAC_Splitter> ();
        

[JsonProperty(PropertyName="AirflowNetwork:SimulationControl", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.AirflowNetwork.AirflowNetwork_SimulationControl AirflowNetwork_SimulationControl { get; set; } = null;
        
        public bool ShouldSerializeAirflowNetwork_MultiZone_Zone_List()
        {
            return (AirflowNetwork_MultiZone_Zone_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:MultiZone:Zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_Zone> AirflowNetwork_MultiZone_Zone_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_Zone> ();
        
        public bool ShouldSerializeAirflowNetwork_MultiZone_Surface_List()
        {
            return (AirflowNetwork_MultiZone_Surface_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:MultiZone:Surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_Surface> AirflowNetwork_MultiZone_Surface_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_Surface> ();
        
        public bool ShouldSerializeAirflowNetwork_MultiZone_ReferenceCrackConditions_List()
        {
            return (AirflowNetwork_MultiZone_ReferenceCrackConditions_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:MultiZone:ReferenceCrackConditions", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_ReferenceCrackConditions> AirflowNetwork_MultiZone_ReferenceCrackConditions_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_ReferenceCrackConditions> ();
        
        public bool ShouldSerializeAirflowNetwork_MultiZone_Surface_Crack_List()
        {
            return (AirflowNetwork_MultiZone_Surface_Crack_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:MultiZone:Surface:Crack", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_Surface_Crack> AirflowNetwork_MultiZone_Surface_Crack_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_Surface_Crack> ();
        
        public bool ShouldSerializeAirflowNetwork_MultiZone_Surface_EffectiveLeakageArea_List()
        {
            return (AirflowNetwork_MultiZone_Surface_EffectiveLeakageArea_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:MultiZone:Surface:EffectiveLeakageArea", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_Surface_EffectiveLeakageArea> AirflowNetwork_MultiZone_Surface_EffectiveLeakageArea_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_Surface_EffectiveLeakageArea> ();
        
        public bool ShouldSerializeAirflowNetwork_MultiZone_Component_DetailedOpening_List()
        {
            return (AirflowNetwork_MultiZone_Component_DetailedOpening_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:MultiZone:Component:DetailedOpening", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_Component_DetailedOpening> AirflowNetwork_MultiZone_Component_DetailedOpening_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_Component_DetailedOpening> ();
        
        public bool ShouldSerializeAirflowNetwork_MultiZone_Component_SimpleOpening_List()
        {
            return (AirflowNetwork_MultiZone_Component_SimpleOpening_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:MultiZone:Component:SimpleOpening", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_Component_SimpleOpening> AirflowNetwork_MultiZone_Component_SimpleOpening_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_Component_SimpleOpening> ();
        
        public bool ShouldSerializeAirflowNetwork_MultiZone_Component_HorizontalOpening_List()
        {
            return (AirflowNetwork_MultiZone_Component_HorizontalOpening_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:MultiZone:Component:HorizontalOpening", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_Component_HorizontalOpening> AirflowNetwork_MultiZone_Component_HorizontalOpening_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_Component_HorizontalOpening> ();
        
        public bool ShouldSerializeAirflowNetwork_MultiZone_Component_ZoneExhaustFan_List()
        {
            return (AirflowNetwork_MultiZone_Component_ZoneExhaustFan_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:MultiZone:Component:ZoneExhaustFan", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_Component_ZoneExhaustFan> AirflowNetwork_MultiZone_Component_ZoneExhaustFan_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_Component_ZoneExhaustFan> ();
        
        public bool ShouldSerializeAirflowNetwork_MultiZone_ExternalNode_List()
        {
            return (AirflowNetwork_MultiZone_ExternalNode_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:MultiZone:ExternalNode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_ExternalNode> AirflowNetwork_MultiZone_ExternalNode_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_ExternalNode> ();
        
        public bool ShouldSerializeAirflowNetwork_MultiZone_WindPressureCoefficientArray_List()
        {
            return (AirflowNetwork_MultiZone_WindPressureCoefficientArray_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:MultiZone:WindPressureCoefficientArray", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_WindPressureCoefficientArray> AirflowNetwork_MultiZone_WindPressureCoefficientArray_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_WindPressureCoefficientArray> ();
        
        public bool ShouldSerializeAirflowNetwork_MultiZone_WindPressureCoefficientValues_List()
        {
            return (AirflowNetwork_MultiZone_WindPressureCoefficientValues_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:MultiZone:WindPressureCoefficientValues", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_WindPressureCoefficientValues> AirflowNetwork_MultiZone_WindPressureCoefficientValues_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_MultiZone_WindPressureCoefficientValues> ();
        

[JsonProperty(PropertyName="AirflowNetwork:ZoneControl:PressureController", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.AirflowNetwork.AirflowNetwork_ZoneControl_PressureController AirflowNetwork_ZoneControl_PressureController { get; set; } = null;
        
        public bool ShouldSerializeAirflowNetwork_Distribution_Node_List()
        {
            return (AirflowNetwork_Distribution_Node_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:Distribution:Node", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Node> AirflowNetwork_Distribution_Node_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Node> ();
        
        public bool ShouldSerializeAirflowNetwork_Distribution_Component_Leak_List()
        {
            return (AirflowNetwork_Distribution_Component_Leak_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:Distribution:Component:Leak", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Component_Leak> AirflowNetwork_Distribution_Component_Leak_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Component_Leak> ();
        
        public bool ShouldSerializeAirflowNetwork_Distribution_Component_LeakageRatio_List()
        {
            return (AirflowNetwork_Distribution_Component_LeakageRatio_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:Distribution:Component:LeakageRatio", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Component_LeakageRatio> AirflowNetwork_Distribution_Component_LeakageRatio_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Component_LeakageRatio> ();
        
        public bool ShouldSerializeAirflowNetwork_Distribution_Component_Duct_List()
        {
            return (AirflowNetwork_Distribution_Component_Duct_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:Distribution:Component:Duct", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Component_Duct> AirflowNetwork_Distribution_Component_Duct_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Component_Duct> ();
        
        public bool ShouldSerializeAirflowNetwork_Distribution_Component_Fan_List()
        {
            return (AirflowNetwork_Distribution_Component_Fan_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:Distribution:Component:Fan", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Component_Fan> AirflowNetwork_Distribution_Component_Fan_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Component_Fan> ();
        
        public bool ShouldSerializeAirflowNetwork_Distribution_Component_Coil_List()
        {
            return (AirflowNetwork_Distribution_Component_Coil_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:Distribution:Component:Coil", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Component_Coil> AirflowNetwork_Distribution_Component_Coil_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Component_Coil> ();
        
        public bool ShouldSerializeAirflowNetwork_Distribution_Component_HeatExchanger_List()
        {
            return (AirflowNetwork_Distribution_Component_HeatExchanger_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:Distribution:Component:HeatExchanger", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Component_HeatExchanger> AirflowNetwork_Distribution_Component_HeatExchanger_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Component_HeatExchanger> ();
        
        public bool ShouldSerializeAirflowNetwork_Distribution_Component_TerminalUnit_List()
        {
            return (AirflowNetwork_Distribution_Component_TerminalUnit_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:Distribution:Component:TerminalUnit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Component_TerminalUnit> AirflowNetwork_Distribution_Component_TerminalUnit_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Component_TerminalUnit> ();
        
        public bool ShouldSerializeAirflowNetwork_Distribution_Component_ConstantPressureDrop_List()
        {
            return (AirflowNetwork_Distribution_Component_ConstantPressureDrop_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:Distribution:Component:ConstantPressureDrop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Component_ConstantPressureDrop> AirflowNetwork_Distribution_Component_ConstantPressureDrop_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Component_ConstantPressureDrop> ();
        
        public bool ShouldSerializeAirflowNetwork_Distribution_Component_OutdoorAirFlow_List()
        {
            return (AirflowNetwork_Distribution_Component_OutdoorAirFlow_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:Distribution:Component:OutdoorAirFlow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Component_OutdoorAirFlow> AirflowNetwork_Distribution_Component_OutdoorAirFlow_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Component_OutdoorAirFlow> ();
        
        public bool ShouldSerializeAirflowNetwork_Distribution_Component_ReliefAirFlow_List()
        {
            return (AirflowNetwork_Distribution_Component_ReliefAirFlow_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:Distribution:Component:ReliefAirFlow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Component_ReliefAirFlow> AirflowNetwork_Distribution_Component_ReliefAirFlow_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Component_ReliefAirFlow> ();
        
        public bool ShouldSerializeAirflowNetwork_Distribution_Linkage_List()
        {
            return (AirflowNetwork_Distribution_Linkage_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:Distribution:Linkage", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Linkage> AirflowNetwork_Distribution_Linkage_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_Linkage> ();
        
        public bool ShouldSerializeAirflowNetwork_Distribution_DuctViewFactors_List()
        {
            return (AirflowNetwork_Distribution_DuctViewFactors_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:Distribution:DuctViewFactors", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_DuctViewFactors> AirflowNetwork_Distribution_DuctViewFactors_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_Distribution_DuctViewFactors> ();
        
        public bool ShouldSerializeAirflowNetwork_OccupantVentilationControl_List()
        {
            return (AirflowNetwork_OccupantVentilationControl_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:OccupantVentilationControl", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_OccupantVentilationControl> AirflowNetwork_OccupantVentilationControl_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_OccupantVentilationControl> ();
        
        public bool ShouldSerializeAirflowNetwork_IntraZone_Node_List()
        {
            return (AirflowNetwork_IntraZone_Node_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:IntraZone:Node", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_IntraZone_Node> AirflowNetwork_IntraZone_Node_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_IntraZone_Node> ();
        
        public bool ShouldSerializeAirflowNetwork_IntraZone_Linkage_List()
        {
            return (AirflowNetwork_IntraZone_Linkage_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirflowNetwork:IntraZone:Linkage", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_IntraZone_Linkage> AirflowNetwork_IntraZone_Linkage_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.AirflowNetwork.AirflowNetwork_IntraZone_Linkage> ();
        
        public bool ShouldSerializeCoil_Cooling_Water_List()
        {
            return (Coil_Cooling_Water_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Cooling:Water", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_Water> Coil_Cooling_Water_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_Water> ();
        
        public bool ShouldSerializeCoil_Cooling_Water_DetailedGeometry_List()
        {
            return (Coil_Cooling_Water_DetailedGeometry_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Cooling:Water:DetailedGeometry", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_Water_DetailedGeometry> Coil_Cooling_Water_DetailedGeometry_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_Water_DetailedGeometry> ();
        
        public bool ShouldSerializeCoil_Cooling_DX_List()
        {
            return (Coil_Cooling_DX_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Cooling:DX", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX> Coil_Cooling_DX_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX> ();
        
        public bool ShouldSerializeCoil_Cooling_DX_CurveFit_Performance_List()
        {
            return (Coil_Cooling_DX_CurveFit_Performance_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Cooling:DX:CurveFit:Performance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX_CurveFit_Performance> Coil_Cooling_DX_CurveFit_Performance_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX_CurveFit_Performance> ();
        
        public bool ShouldSerializeCoil_Cooling_DX_CurveFit_OperatingMode_List()
        {
            return (Coil_Cooling_DX_CurveFit_OperatingMode_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Cooling:DX:CurveFit:OperatingMode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX_CurveFit_OperatingMode> Coil_Cooling_DX_CurveFit_OperatingMode_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX_CurveFit_OperatingMode> ();
        
        public bool ShouldSerializeCoil_Cooling_DX_CurveFit_Speed_List()
        {
            return (Coil_Cooling_DX_CurveFit_Speed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Cooling:DX:CurveFit:Speed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX_CurveFit_Speed> Coil_Cooling_DX_CurveFit_Speed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX_CurveFit_Speed> ();
        
        public bool ShouldSerializeCoil_Cooling_DX_SingleSpeed_List()
        {
            return (Coil_Cooling_DX_SingleSpeed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Cooling:DX:SingleSpeed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX_SingleSpeed> Coil_Cooling_DX_SingleSpeed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX_SingleSpeed> ();
        
        public bool ShouldSerializeCoil_Cooling_DX_TwoSpeed_List()
        {
            return (Coil_Cooling_DX_TwoSpeed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Cooling:DX:TwoSpeed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX_TwoSpeed> Coil_Cooling_DX_TwoSpeed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX_TwoSpeed> ();
        
        public bool ShouldSerializeCoil_Cooling_DX_MultiSpeed_List()
        {
            return (Coil_Cooling_DX_MultiSpeed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Cooling:DX:MultiSpeed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX_MultiSpeed> Coil_Cooling_DX_MultiSpeed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX_MultiSpeed> ();
        
        public bool ShouldSerializeCoil_Cooling_DX_VariableSpeed_List()
        {
            return (Coil_Cooling_DX_VariableSpeed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Cooling:DX:VariableSpeed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX_VariableSpeed> Coil_Cooling_DX_VariableSpeed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX_VariableSpeed> ();
        
        public bool ShouldSerializeCoil_Cooling_DX_TwoStageWithHumidityControlMode_List()
        {
            return (Coil_Cooling_DX_TwoStageWithHumidityControlMode_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Cooling:DX:TwoStageWithHumidityControlMode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX_TwoStageWithHumidityControlMode> Coil_Cooling_DX_TwoStageWithHumidityControlMode_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX_TwoStageWithHumidityControlMode> ();
        
        public bool ShouldSerializeCoilPerformance_DX_Cooling_List()
        {
            return (CoilPerformance_DX_Cooling_List.Count > 0);
        }
        

[JsonProperty(PropertyName="CoilPerformance:DX:Cooling", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.CoilPerformance_DX_Cooling> CoilPerformance_DX_Cooling_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.CoilPerformance_DX_Cooling> ();
        
        public bool ShouldSerializeCoil_Cooling_DX_VariableRefrigerantFlow_List()
        {
            return (Coil_Cooling_DX_VariableRefrigerantFlow_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Cooling:DX:VariableRefrigerantFlow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX_VariableRefrigerantFlow> Coil_Cooling_DX_VariableRefrigerantFlow_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX_VariableRefrigerantFlow> ();
        
        public bool ShouldSerializeCoil_Heating_DX_VariableRefrigerantFlow_List()
        {
            return (Coil_Heating_DX_VariableRefrigerantFlow_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Heating:DX:VariableRefrigerantFlow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_DX_VariableRefrigerantFlow> Coil_Heating_DX_VariableRefrigerantFlow_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_DX_VariableRefrigerantFlow> ();
        
        public bool ShouldSerializeCoil_Cooling_DX_VariableRefrigerantFlow_FluidTemperatureControl_List()
        {
            return (Coil_Cooling_DX_VariableRefrigerantFlow_FluidTemperatureControl_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Cooling:DX:VariableRefrigerantFlow:FluidTemperatureControl", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX_VariableRefrigerantFlow_FluidTemperatureControl> Coil_Cooling_DX_VariableRefrigerantFlow_FluidTemperatureControl_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX_VariableRefrigerantFlow_FluidTemperatureControl> ();
        
        public bool ShouldSerializeCoil_Heating_DX_VariableRefrigerantFlow_FluidTemperatureControl_List()
        {
            return (Coil_Heating_DX_VariableRefrigerantFlow_FluidTemperatureControl_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Heating:DX:VariableRefrigerantFlow:FluidTemperatureControl", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_DX_VariableRefrigerantFlow_FluidTemperatureControl> Coil_Heating_DX_VariableRefrigerantFlow_FluidTemperatureControl_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_DX_VariableRefrigerantFlow_FluidTemperatureControl> ();
        
        public bool ShouldSerializeCoil_Heating_Water_List()
        {
            return (Coil_Heating_Water_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Heating:Water", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_Water> Coil_Heating_Water_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_Water> ();
        
        public bool ShouldSerializeCoil_Heating_Steam_List()
        {
            return (Coil_Heating_Steam_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Heating:Steam", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_Steam> Coil_Heating_Steam_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_Steam> ();
        
        public bool ShouldSerializeCoil_Heating_Electric_List()
        {
            return (Coil_Heating_Electric_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Heating:Electric", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_Electric> Coil_Heating_Electric_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_Electric> ();
        
        public bool ShouldSerializeCoil_Heating_Electric_MultiStage_List()
        {
            return (Coil_Heating_Electric_MultiStage_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Heating:Electric:MultiStage", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_Electric_MultiStage> Coil_Heating_Electric_MultiStage_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_Electric_MultiStage> ();
        
        public bool ShouldSerializeCoil_Heating_Fuel_List()
        {
            return (Coil_Heating_Fuel_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Heating:Fuel", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_Fuel> Coil_Heating_Fuel_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_Fuel> ();
        
        public bool ShouldSerializeCoil_Heating_Gas_MultiStage_List()
        {
            return (Coil_Heating_Gas_MultiStage_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Heating:Gas:MultiStage", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_Gas_MultiStage> Coil_Heating_Gas_MultiStage_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_Gas_MultiStage> ();
        
        public bool ShouldSerializeCoil_Heating_Desuperheater_List()
        {
            return (Coil_Heating_Desuperheater_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Heating:Desuperheater", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_Desuperheater> Coil_Heating_Desuperheater_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_Desuperheater> ();
        
        public bool ShouldSerializeCoil_Heating_DX_SingleSpeed_List()
        {
            return (Coil_Heating_DX_SingleSpeed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Heating:DX:SingleSpeed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_DX_SingleSpeed> Coil_Heating_DX_SingleSpeed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_DX_SingleSpeed> ();
        
        public bool ShouldSerializeCoil_Heating_DX_MultiSpeed_List()
        {
            return (Coil_Heating_DX_MultiSpeed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Heating:DX:MultiSpeed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_DX_MultiSpeed> Coil_Heating_DX_MultiSpeed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_DX_MultiSpeed> ();
        
        public bool ShouldSerializeCoil_Heating_DX_VariableSpeed_List()
        {
            return (Coil_Heating_DX_VariableSpeed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Heating:DX:VariableSpeed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_DX_VariableSpeed> Coil_Heating_DX_VariableSpeed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_DX_VariableSpeed> ();
        
        public bool ShouldSerializeCoil_Cooling_WaterToAirHeatPump_ParameterEstimation_List()
        {
            return (Coil_Cooling_WaterToAirHeatPump_ParameterEstimation_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Cooling:WaterToAirHeatPump:ParameterEstimation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_WaterToAirHeatPump_ParameterEstimation> Coil_Cooling_WaterToAirHeatPump_ParameterEstimation_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_WaterToAirHeatPump_ParameterEstimation> ();
        
        public bool ShouldSerializeCoil_Heating_WaterToAirHeatPump_ParameterEstimation_List()
        {
            return (Coil_Heating_WaterToAirHeatPump_ParameterEstimation_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Heating:WaterToAirHeatPump:ParameterEstimation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_WaterToAirHeatPump_ParameterEstimation> Coil_Heating_WaterToAirHeatPump_ParameterEstimation_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_WaterToAirHeatPump_ParameterEstimation> ();
        
        public bool ShouldSerializeCoil_Cooling_WaterToAirHeatPump_EquationFit_List()
        {
            return (Coil_Cooling_WaterToAirHeatPump_EquationFit_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Cooling:WaterToAirHeatPump:EquationFit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_WaterToAirHeatPump_EquationFit> Coil_Cooling_WaterToAirHeatPump_EquationFit_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_WaterToAirHeatPump_EquationFit> ();
        
        public bool ShouldSerializeCoil_Cooling_WaterToAirHeatPump_VariableSpeedEquationFit_List()
        {
            return (Coil_Cooling_WaterToAirHeatPump_VariableSpeedEquationFit_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Cooling:WaterToAirHeatPump:VariableSpeedEquationFit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_WaterToAirHeatPump_VariableSpeedEquationFit> Coil_Cooling_WaterToAirHeatPump_VariableSpeedEquationFit_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_WaterToAirHeatPump_VariableSpeedEquationFit> ();
        
        public bool ShouldSerializeCoil_Heating_WaterToAirHeatPump_EquationFit_List()
        {
            return (Coil_Heating_WaterToAirHeatPump_EquationFit_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Heating:WaterToAirHeatPump:EquationFit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_WaterToAirHeatPump_EquationFit> Coil_Heating_WaterToAirHeatPump_EquationFit_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_WaterToAirHeatPump_EquationFit> ();
        
        public bool ShouldSerializeCoil_Heating_WaterToAirHeatPump_VariableSpeedEquationFit_List()
        {
            return (Coil_Heating_WaterToAirHeatPump_VariableSpeedEquationFit_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Heating:WaterToAirHeatPump:VariableSpeedEquationFit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_WaterToAirHeatPump_VariableSpeedEquationFit> Coil_Heating_WaterToAirHeatPump_VariableSpeedEquationFit_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Heating_WaterToAirHeatPump_VariableSpeedEquationFit> ();
        
        public bool ShouldSerializeCoil_WaterHeating_AirToWaterHeatPump_Pumped_List()
        {
            return (Coil_WaterHeating_AirToWaterHeatPump_Pumped_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:WaterHeating:AirToWaterHeatPump:Pumped", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_WaterHeating_AirToWaterHeatPump_Pumped> Coil_WaterHeating_AirToWaterHeatPump_Pumped_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_WaterHeating_AirToWaterHeatPump_Pumped> ();
        
        public bool ShouldSerializeCoil_WaterHeating_AirToWaterHeatPump_Wrapped_List()
        {
            return (Coil_WaterHeating_AirToWaterHeatPump_Wrapped_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:WaterHeating:AirToWaterHeatPump:Wrapped", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_WaterHeating_AirToWaterHeatPump_Wrapped> Coil_WaterHeating_AirToWaterHeatPump_Wrapped_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_WaterHeating_AirToWaterHeatPump_Wrapped> ();
        
        public bool ShouldSerializeCoil_WaterHeating_AirToWaterHeatPump_VariableSpeed_List()
        {
            return (Coil_WaterHeating_AirToWaterHeatPump_VariableSpeed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:WaterHeating:AirToWaterHeatPump:VariableSpeed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_WaterHeating_AirToWaterHeatPump_VariableSpeed> Coil_WaterHeating_AirToWaterHeatPump_VariableSpeed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_WaterHeating_AirToWaterHeatPump_VariableSpeed> ();
        
        public bool ShouldSerializeCoil_WaterHeating_Desuperheater_List()
        {
            return (Coil_WaterHeating_Desuperheater_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:WaterHeating:Desuperheater", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_WaterHeating_Desuperheater> Coil_WaterHeating_Desuperheater_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_WaterHeating_Desuperheater> ();
        
        public bool ShouldSerializeCoilSystem_Cooling_DX_List()
        {
            return (CoilSystem_Cooling_DX_List.Count > 0);
        }
        

[JsonProperty(PropertyName="CoilSystem:Cooling:DX", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.CoilSystem_Cooling_DX> CoilSystem_Cooling_DX_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.CoilSystem_Cooling_DX> ();
        
        public bool ShouldSerializeCoilSystem_Heating_DX_List()
        {
            return (CoilSystem_Heating_DX_List.Count > 0);
        }
        

[JsonProperty(PropertyName="CoilSystem:Heating:DX", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.CoilSystem_Heating_DX> CoilSystem_Heating_DX_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.CoilSystem_Heating_DX> ();
        
        public bool ShouldSerializeCoilSystem_Cooling_Water_HeatExchangerAssisted_List()
        {
            return (CoilSystem_Cooling_Water_HeatExchangerAssisted_List.Count > 0);
        }
        

[JsonProperty(PropertyName="CoilSystem:Cooling:Water:HeatExchangerAssisted", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.CoilSystem_Cooling_Water_HeatExchangerAssisted> CoilSystem_Cooling_Water_HeatExchangerAssisted_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.CoilSystem_Cooling_Water_HeatExchangerAssisted> ();
        
        public bool ShouldSerializeCoilSystem_Cooling_DX_HeatExchangerAssisted_List()
        {
            return (CoilSystem_Cooling_DX_HeatExchangerAssisted_List.Count > 0);
        }
        

[JsonProperty(PropertyName="CoilSystem:Cooling:DX:HeatExchangerAssisted", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.CoilSystem_Cooling_DX_HeatExchangerAssisted> CoilSystem_Cooling_DX_HeatExchangerAssisted_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.CoilSystem_Cooling_DX_HeatExchangerAssisted> ();
        
        public bool ShouldSerializeCoilSystem_IntegratedHeatPump_AirSource_List()
        {
            return (CoilSystem_IntegratedHeatPump_AirSource_List.Count > 0);
        }
        

[JsonProperty(PropertyName="CoilSystem:IntegratedHeatPump:AirSource", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.CoilSystem_IntegratedHeatPump_AirSource> CoilSystem_IntegratedHeatPump_AirSource_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.CoilSystem_IntegratedHeatPump_AirSource> ();
        
        public bool ShouldSerializeCoil_Cooling_DX_SingleSpeed_ThermalStorage_List()
        {
            return (Coil_Cooling_DX_SingleSpeed_ThermalStorage_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:Cooling:DX:SingleSpeed:ThermalStorage", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX_SingleSpeed_ThermalStorage> Coil_Cooling_DX_SingleSpeed_ThermalStorage_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Coils.Coil_Cooling_DX_SingleSpeed_ThermalStorage> ();
        

[JsonProperty(PropertyName="Compliance:Building", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.ComplianceObjects.Compliance_Building Compliance_Building { get; set; } = null;
        
        public bool ShouldSerializeCoolingTower_SingleSpeed_List()
        {
            return (CoolingTower_SingleSpeed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="CoolingTower:SingleSpeed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.CoolingTower_SingleSpeed> CoolingTower_SingleSpeed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.CoolingTower_SingleSpeed> ();
        
        public bool ShouldSerializeCoolingTower_TwoSpeed_List()
        {
            return (CoolingTower_TwoSpeed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="CoolingTower:TwoSpeed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.CoolingTower_TwoSpeed> CoolingTower_TwoSpeed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.CoolingTower_TwoSpeed> ();
        
        public bool ShouldSerializeCoolingTower_VariableSpeed_Merkel_List()
        {
            return (CoolingTower_VariableSpeed_Merkel_List.Count > 0);
        }
        

[JsonProperty(PropertyName="CoolingTower:VariableSpeed:Merkel", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.CoolingTower_VariableSpeed_Merkel> CoolingTower_VariableSpeed_Merkel_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.CoolingTower_VariableSpeed_Merkel> ();
        
        public bool ShouldSerializeCoolingTower_VariableSpeed_List()
        {
            return (CoolingTower_VariableSpeed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="CoolingTower:VariableSpeed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.CoolingTower_VariableSpeed> CoolingTower_VariableSpeed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.CoolingTower_VariableSpeed> ();
        
        public bool ShouldSerializeCoolingTowerPerformance_CoolTools_List()
        {
            return (CoolingTowerPerformance_CoolTools_List.Count > 0);
        }
        

[JsonProperty(PropertyName="CoolingTowerPerformance:CoolTools", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.CoolingTowerPerformance_CoolTools> CoolingTowerPerformance_CoolTools_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.CoolingTowerPerformance_CoolTools> ();
        
        public bool ShouldSerializeCoolingTowerPerformance_YorkCalc_List()
        {
            return (CoolingTowerPerformance_YorkCalc_List.Count > 0);
        }
        

[JsonProperty(PropertyName="CoolingTowerPerformance:YorkCalc", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.CoolingTowerPerformance_YorkCalc> CoolingTowerPerformance_YorkCalc_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.CoolingTowerPerformance_YorkCalc> ();
        
        public bool ShouldSerializeEvaporativeFluidCooler_SingleSpeed_List()
        {
            return (EvaporativeFluidCooler_SingleSpeed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="EvaporativeFluidCooler:SingleSpeed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.EvaporativeFluidCooler_SingleSpeed> EvaporativeFluidCooler_SingleSpeed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.EvaporativeFluidCooler_SingleSpeed> ();
        
        public bool ShouldSerializeEvaporativeFluidCooler_TwoSpeed_List()
        {
            return (EvaporativeFluidCooler_TwoSpeed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="EvaporativeFluidCooler:TwoSpeed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.EvaporativeFluidCooler_TwoSpeed> EvaporativeFluidCooler_TwoSpeed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.EvaporativeFluidCooler_TwoSpeed> ();
        
        public bool ShouldSerializeFluidCooler_SingleSpeed_List()
        {
            return (FluidCooler_SingleSpeed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FluidCooler:SingleSpeed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.FluidCooler_SingleSpeed> FluidCooler_SingleSpeed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.FluidCooler_SingleSpeed> ();
        
        public bool ShouldSerializeFluidCooler_TwoSpeed_List()
        {
            return (FluidCooler_TwoSpeed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FluidCooler:TwoSpeed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.FluidCooler_TwoSpeed> FluidCooler_TwoSpeed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.FluidCooler_TwoSpeed> ();
        
        public bool ShouldSerializeGroundHeatExchanger_System_List()
        {
            return (GroundHeatExchanger_System_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatExchanger:System", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.GroundHeatExchanger_System> GroundHeatExchanger_System_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.GroundHeatExchanger_System> ();
        
        public bool ShouldSerializeGroundHeatExchanger_Vertical_Properties_List()
        {
            return (GroundHeatExchanger_Vertical_Properties_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatExchanger:Vertical:Properties", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.GroundHeatExchanger_Vertical_Properties> GroundHeatExchanger_Vertical_Properties_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.GroundHeatExchanger_Vertical_Properties> ();
        
        public bool ShouldSerializeGroundHeatExchanger_Vertical_Array_List()
        {
            return (GroundHeatExchanger_Vertical_Array_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatExchanger:Vertical:Array", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.GroundHeatExchanger_Vertical_Array> GroundHeatExchanger_Vertical_Array_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.GroundHeatExchanger_Vertical_Array> ();
        
        public bool ShouldSerializeGroundHeatExchanger_Vertical_Single_List()
        {
            return (GroundHeatExchanger_Vertical_Single_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatExchanger:Vertical:Single", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.GroundHeatExchanger_Vertical_Single> GroundHeatExchanger_Vertical_Single_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.GroundHeatExchanger_Vertical_Single> ();
        
        public bool ShouldSerializeGroundHeatExchanger_ResponseFactors_List()
        {
            return (GroundHeatExchanger_ResponseFactors_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatExchanger:ResponseFactors", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.GroundHeatExchanger_ResponseFactors> GroundHeatExchanger_ResponseFactors_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.GroundHeatExchanger_ResponseFactors> ();
        
        public bool ShouldSerializeGroundHeatExchanger_Pond_List()
        {
            return (GroundHeatExchanger_Pond_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatExchanger:Pond", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.GroundHeatExchanger_Pond> GroundHeatExchanger_Pond_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.GroundHeatExchanger_Pond> ();
        
        public bool ShouldSerializeGroundHeatExchanger_Surface_List()
        {
            return (GroundHeatExchanger_Surface_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatExchanger:Surface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.GroundHeatExchanger_Surface> GroundHeatExchanger_Surface_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.GroundHeatExchanger_Surface> ();
        
        public bool ShouldSerializeGroundHeatExchanger_HorizontalTrench_List()
        {
            return (GroundHeatExchanger_HorizontalTrench_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatExchanger:HorizontalTrench", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.GroundHeatExchanger_HorizontalTrench> GroundHeatExchanger_HorizontalTrench_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.GroundHeatExchanger_HorizontalTrench> ();
        
        public bool ShouldSerializeGroundHeatExchanger_Slinky_List()
        {
            return (GroundHeatExchanger_Slinky_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatExchanger:Slinky", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.GroundHeatExchanger_Slinky> GroundHeatExchanger_Slinky_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.GroundHeatExchanger_Slinky> ();
        
        public bool ShouldSerializeHeatExchanger_FluidToFluid_List()
        {
            return (HeatExchanger_FluidToFluid_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HeatExchanger:FluidToFluid", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.HeatExchanger_FluidToFluid> HeatExchanger_FluidToFluid_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.CondenserEquipmentandHeatExchangers.HeatExchanger_FluidToFluid> ();
        
        public bool ShouldSerializeController_WaterCoil_List()
        {
            return (Controller_WaterCoil_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Controller:WaterCoil", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Controllers.Controller_WaterCoil> Controller_WaterCoil_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Controllers.Controller_WaterCoil> ();
        
        public bool ShouldSerializeController_OutdoorAir_List()
        {
            return (Controller_OutdoorAir_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Controller:OutdoorAir", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Controllers.Controller_OutdoorAir> Controller_OutdoorAir_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Controllers.Controller_OutdoorAir> ();
        
        public bool ShouldSerializeController_MechanicalVentilation_List()
        {
            return (Controller_MechanicalVentilation_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Controller:MechanicalVentilation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Controllers.Controller_MechanicalVentilation> Controller_MechanicalVentilation_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Controllers.Controller_MechanicalVentilation> ();
        
        public bool ShouldSerializeAirLoopHVAC_ControllerList_List()
        {
            return (AirLoopHVAC_ControllerList_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirLoopHVAC:ControllerList", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Controllers.AirLoopHVAC_ControllerList> AirLoopHVAC_ControllerList_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Controllers.AirLoopHVAC_ControllerList> ();
        
        public bool ShouldSerializeDaylighting_Controls_List()
        {
            return (Daylighting_Controls_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Daylighting:Controls", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Daylighting.Daylighting_Controls> Daylighting_Controls_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Daylighting.Daylighting_Controls> ();
        
        public bool ShouldSerializeDaylighting_ReferencePoint_List()
        {
            return (Daylighting_ReferencePoint_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Daylighting:ReferencePoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Daylighting.Daylighting_ReferencePoint> Daylighting_ReferencePoint_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Daylighting.Daylighting_ReferencePoint> ();
        
        public bool ShouldSerializeDaylighting_DELight_ComplexFenestration_List()
        {
            return (Daylighting_DELight_ComplexFenestration_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Daylighting:DELight:ComplexFenestration", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Daylighting.Daylighting_DELight_ComplexFenestration> Daylighting_DELight_ComplexFenestration_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Daylighting.Daylighting_DELight_ComplexFenestration> ();
        
        public bool ShouldSerializeDaylightingDevice_Tubular_List()
        {
            return (DaylightingDevice_Tubular_List.Count > 0);
        }
        

[JsonProperty(PropertyName="DaylightingDevice:Tubular", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Daylighting.DaylightingDevice_Tubular> DaylightingDevice_Tubular_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Daylighting.DaylightingDevice_Tubular> ();
        
        public bool ShouldSerializeDaylightingDevice_Shelf_List()
        {
            return (DaylightingDevice_Shelf_List.Count > 0);
        }
        

[JsonProperty(PropertyName="DaylightingDevice:Shelf", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Daylighting.DaylightingDevice_Shelf> DaylightingDevice_Shelf_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Daylighting.DaylightingDevice_Shelf> ();
        
        public bool ShouldSerializeDaylightingDevice_LightWell_List()
        {
            return (DaylightingDevice_LightWell_List.Count > 0);
        }
        

[JsonProperty(PropertyName="DaylightingDevice:LightWell", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Daylighting.DaylightingDevice_LightWell> DaylightingDevice_LightWell_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Daylighting.DaylightingDevice_LightWell> ();
        
        public bool ShouldSerializeOutput_DaylightFactors_List()
        {
            return (Output_DaylightFactors_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Output:DaylightFactors", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Daylighting.Output_DaylightFactors> Output_DaylightFactors_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Daylighting.Output_DaylightFactors> ();
        
        public bool ShouldSerializeOutput_IlluminanceMap_List()
        {
            return (Output_IlluminanceMap_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Output:IlluminanceMap", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Daylighting.Output_IlluminanceMap> Output_IlluminanceMap_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Daylighting.Output_IlluminanceMap> ();
        

[JsonProperty(PropertyName="OutputControl:IlluminanceMap:Style", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.Daylighting.OutputControl_IlluminanceMap_Style OutputControl_IlluminanceMap_Style { get; set; } = null;
        
        public bool ShouldSerializeDemandManagerAssignmentList_List()
        {
            return (DemandManagerAssignmentList_List.Count > 0);
        }
        

[JsonProperty(PropertyName="DemandManagerAssignmentList", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DemandLimitingControls.DemandManagerAssignmentList> DemandManagerAssignmentList_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DemandLimitingControls.DemandManagerAssignmentList> ();
        
        public bool ShouldSerializeDemandManager_ExteriorLights_List()
        {
            return (DemandManager_ExteriorLights_List.Count > 0);
        }
        

[JsonProperty(PropertyName="DemandManager:ExteriorLights", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DemandLimitingControls.DemandManager_ExteriorLights> DemandManager_ExteriorLights_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DemandLimitingControls.DemandManager_ExteriorLights> ();
        
        public bool ShouldSerializeDemandManager_Lights_List()
        {
            return (DemandManager_Lights_List.Count > 0);
        }
        

[JsonProperty(PropertyName="DemandManager:Lights", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DemandLimitingControls.DemandManager_Lights> DemandManager_Lights_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DemandLimitingControls.DemandManager_Lights> ();
        
        public bool ShouldSerializeDemandManager_ElectricEquipment_List()
        {
            return (DemandManager_ElectricEquipment_List.Count > 0);
        }
        

[JsonProperty(PropertyName="DemandManager:ElectricEquipment", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DemandLimitingControls.DemandManager_ElectricEquipment> DemandManager_ElectricEquipment_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DemandLimitingControls.DemandManager_ElectricEquipment> ();
        
        public bool ShouldSerializeDemandManager_Thermostats_List()
        {
            return (DemandManager_Thermostats_List.Count > 0);
        }
        

[JsonProperty(PropertyName="DemandManager:Thermostats", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DemandLimitingControls.DemandManager_Thermostats> DemandManager_Thermostats_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DemandLimitingControls.DemandManager_Thermostats> ();
        
        public bool ShouldSerializeDemandManager_Ventilation_List()
        {
            return (DemandManager_Ventilation_List.Count > 0);
        }
        

[JsonProperty(PropertyName="DemandManager:Ventilation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DemandLimitingControls.DemandManager_Ventilation> DemandManager_Ventilation_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DemandLimitingControls.DemandManager_Ventilation> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Control_List()
        {
            return (GroundHeatTransfer_Control_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Control", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Control> GroundHeatTransfer_Control_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Control> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Slab_Materials_List()
        {
            return (GroundHeatTransfer_Slab_Materials_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Slab:Materials", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Slab_Materials> GroundHeatTransfer_Slab_Materials_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Slab_Materials> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Slab_MatlProps_List()
        {
            return (GroundHeatTransfer_Slab_MatlProps_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Slab:MatlProps", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Slab_MatlProps> GroundHeatTransfer_Slab_MatlProps_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Slab_MatlProps> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Slab_BoundConds_List()
        {
            return (GroundHeatTransfer_Slab_BoundConds_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Slab:BoundConds", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Slab_BoundConds> GroundHeatTransfer_Slab_BoundConds_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Slab_BoundConds> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Slab_BldgProps_List()
        {
            return (GroundHeatTransfer_Slab_BldgProps_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Slab:BldgProps", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Slab_BldgProps> GroundHeatTransfer_Slab_BldgProps_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Slab_BldgProps> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Slab_Insulation_List()
        {
            return (GroundHeatTransfer_Slab_Insulation_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Slab:Insulation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Slab_Insulation> GroundHeatTransfer_Slab_Insulation_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Slab_Insulation> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Slab_EquivalentSlab_List()
        {
            return (GroundHeatTransfer_Slab_EquivalentSlab_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Slab:EquivalentSlab", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Slab_EquivalentSlab> GroundHeatTransfer_Slab_EquivalentSlab_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Slab_EquivalentSlab> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Slab_AutoGrid_List()
        {
            return (GroundHeatTransfer_Slab_AutoGrid_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Slab:AutoGrid", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Slab_AutoGrid> GroundHeatTransfer_Slab_AutoGrid_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Slab_AutoGrid> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Slab_ManualGrid_List()
        {
            return (GroundHeatTransfer_Slab_ManualGrid_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Slab:ManualGrid", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Slab_ManualGrid> GroundHeatTransfer_Slab_ManualGrid_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Slab_ManualGrid> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Slab_XFACE_List()
        {
            return (GroundHeatTransfer_Slab_XFACE_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Slab:XFACE", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Slab_XFACE> GroundHeatTransfer_Slab_XFACE_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Slab_XFACE> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Slab_YFACE_List()
        {
            return (GroundHeatTransfer_Slab_YFACE_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Slab:YFACE", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Slab_YFACE> GroundHeatTransfer_Slab_YFACE_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Slab_YFACE> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Slab_ZFACE_List()
        {
            return (GroundHeatTransfer_Slab_ZFACE_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Slab:ZFACE", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Slab_ZFACE> GroundHeatTransfer_Slab_ZFACE_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Slab_ZFACE> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Basement_SimParameters_List()
        {
            return (GroundHeatTransfer_Basement_SimParameters_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Basement:SimParameters", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_SimParameters> GroundHeatTransfer_Basement_SimParameters_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_SimParameters> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Basement_MatlProps_List()
        {
            return (GroundHeatTransfer_Basement_MatlProps_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Basement:MatlProps", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_MatlProps> GroundHeatTransfer_Basement_MatlProps_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_MatlProps> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Basement_Insulation_List()
        {
            return (GroundHeatTransfer_Basement_Insulation_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Basement:Insulation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_Insulation> GroundHeatTransfer_Basement_Insulation_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_Insulation> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Basement_SurfaceProps_List()
        {
            return (GroundHeatTransfer_Basement_SurfaceProps_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Basement:SurfaceProps", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_SurfaceProps> GroundHeatTransfer_Basement_SurfaceProps_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_SurfaceProps> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Basement_BldgData_List()
        {
            return (GroundHeatTransfer_Basement_BldgData_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Basement:BldgData", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_BldgData> GroundHeatTransfer_Basement_BldgData_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_BldgData> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Basement_Interior_List()
        {
            return (GroundHeatTransfer_Basement_Interior_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Basement:Interior", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_Interior> GroundHeatTransfer_Basement_Interior_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_Interior> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Basement_ComBldg_List()
        {
            return (GroundHeatTransfer_Basement_ComBldg_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Basement:ComBldg", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_ComBldg> GroundHeatTransfer_Basement_ComBldg_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_ComBldg> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Basement_EquivSlab_List()
        {
            return (GroundHeatTransfer_Basement_EquivSlab_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Basement:EquivSlab", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_EquivSlab> GroundHeatTransfer_Basement_EquivSlab_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_EquivSlab> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Basement_EquivAutoGrid_List()
        {
            return (GroundHeatTransfer_Basement_EquivAutoGrid_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Basement:EquivAutoGrid", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_EquivAutoGrid> GroundHeatTransfer_Basement_EquivAutoGrid_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_EquivAutoGrid> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Basement_AutoGrid_List()
        {
            return (GroundHeatTransfer_Basement_AutoGrid_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Basement:AutoGrid", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_AutoGrid> GroundHeatTransfer_Basement_AutoGrid_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_AutoGrid> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Basement_ManualGrid_List()
        {
            return (GroundHeatTransfer_Basement_ManualGrid_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Basement:ManualGrid", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_ManualGrid> GroundHeatTransfer_Basement_ManualGrid_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_ManualGrid> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Basement_XFACE_List()
        {
            return (GroundHeatTransfer_Basement_XFACE_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Basement:XFACE", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_XFACE> GroundHeatTransfer_Basement_XFACE_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_XFACE> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Basement_YFACE_List()
        {
            return (GroundHeatTransfer_Basement_YFACE_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Basement:YFACE", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_YFACE> GroundHeatTransfer_Basement_YFACE_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_YFACE> ();
        
        public bool ShouldSerializeGroundHeatTransfer_Basement_ZFACE_List()
        {
            return (GroundHeatTransfer_Basement_ZFACE_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GroundHeatTransfer:Basement:ZFACE", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_ZFACE> GroundHeatTransfer_Basement_ZFACE_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.DetailedGroundHeatTransfer.GroundHeatTransfer_Basement_ZFACE> ();
        

[JsonProperty(PropertyName="CurrencyType", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.Economics.CurrencyType CurrencyType { get; set; } = null;
        
        public bool ShouldSerializeComponentCost_Adjustments_List()
        {
            return (ComponentCost_Adjustments_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ComponentCost:Adjustments", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Economics.ComponentCost_Adjustments> ComponentCost_Adjustments_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Economics.ComponentCost_Adjustments> ();
        
        public bool ShouldSerializeComponentCost_Reference_List()
        {
            return (ComponentCost_Reference_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ComponentCost:Reference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Economics.ComponentCost_Reference> ComponentCost_Reference_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Economics.ComponentCost_Reference> ();
        
        public bool ShouldSerializeComponentCost_LineItem_List()
        {
            return (ComponentCost_LineItem_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ComponentCost:LineItem", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Economics.ComponentCost_LineItem> ComponentCost_LineItem_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Economics.ComponentCost_LineItem> ();
        
        public bool ShouldSerializeUtilityCost_Tariff_List()
        {
            return (UtilityCost_Tariff_List.Count > 0);
        }
        

[JsonProperty(PropertyName="UtilityCost:Tariff", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Economics.UtilityCost_Tariff> UtilityCost_Tariff_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Economics.UtilityCost_Tariff> ();
        
        public bool ShouldSerializeUtilityCost_Qualify_List()
        {
            return (UtilityCost_Qualify_List.Count > 0);
        }
        

[JsonProperty(PropertyName="UtilityCost:Qualify", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Economics.UtilityCost_Qualify> UtilityCost_Qualify_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Economics.UtilityCost_Qualify> ();
        
        public bool ShouldSerializeUtilityCost_Charge_Simple_List()
        {
            return (UtilityCost_Charge_Simple_List.Count > 0);
        }
        

[JsonProperty(PropertyName="UtilityCost:Charge:Simple", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Economics.UtilityCost_Charge_Simple> UtilityCost_Charge_Simple_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Economics.UtilityCost_Charge_Simple> ();
        
        public bool ShouldSerializeUtilityCost_Charge_Block_List()
        {
            return (UtilityCost_Charge_Block_List.Count > 0);
        }
        

[JsonProperty(PropertyName="UtilityCost:Charge:Block", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Economics.UtilityCost_Charge_Block> UtilityCost_Charge_Block_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Economics.UtilityCost_Charge_Block> ();
        
        public bool ShouldSerializeUtilityCost_Ratchet_List()
        {
            return (UtilityCost_Ratchet_List.Count > 0);
        }
        

[JsonProperty(PropertyName="UtilityCost:Ratchet", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Economics.UtilityCost_Ratchet> UtilityCost_Ratchet_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Economics.UtilityCost_Ratchet> ();
        
        public bool ShouldSerializeUtilityCost_Variable_List()
        {
            return (UtilityCost_Variable_List.Count > 0);
        }
        

[JsonProperty(PropertyName="UtilityCost:Variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Economics.UtilityCost_Variable> UtilityCost_Variable_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Economics.UtilityCost_Variable> ();
        
        public bool ShouldSerializeUtilityCost_Computation_List()
        {
            return (UtilityCost_Computation_List.Count > 0);
        }
        

[JsonProperty(PropertyName="UtilityCost:Computation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Economics.UtilityCost_Computation> UtilityCost_Computation_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Economics.UtilityCost_Computation> ();
        

[JsonProperty(PropertyName="LifeCycleCost:Parameters", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.Economics.LifeCycleCost_Parameters LifeCycleCost_Parameters { get; set; } = null;
        
        public bool ShouldSerializeLifeCycleCost_RecurringCosts_List()
        {
            return (LifeCycleCost_RecurringCosts_List.Count > 0);
        }
        

[JsonProperty(PropertyName="LifeCycleCost:RecurringCosts", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Economics.LifeCycleCost_RecurringCosts> LifeCycleCost_RecurringCosts_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Economics.LifeCycleCost_RecurringCosts> ();
        
        public bool ShouldSerializeLifeCycleCost_NonrecurringCost_List()
        {
            return (LifeCycleCost_NonrecurringCost_List.Count > 0);
        }
        

[JsonProperty(PropertyName="LifeCycleCost:NonrecurringCost", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Economics.LifeCycleCost_NonrecurringCost> LifeCycleCost_NonrecurringCost_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Economics.LifeCycleCost_NonrecurringCost> ();
        
        public bool ShouldSerializeLifeCycleCost_UsePriceEscalation_List()
        {
            return (LifeCycleCost_UsePriceEscalation_List.Count > 0);
        }
        

[JsonProperty(PropertyName="LifeCycleCost:UsePriceEscalation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Economics.LifeCycleCost_UsePriceEscalation> LifeCycleCost_UsePriceEscalation_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Economics.LifeCycleCost_UsePriceEscalation> ();
        
        public bool ShouldSerializeLifeCycleCost_UseAdjustment_List()
        {
            return (LifeCycleCost_UseAdjustment_List.Count > 0);
        }
        

[JsonProperty(PropertyName="LifeCycleCost:UseAdjustment", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Economics.LifeCycleCost_UseAdjustment> LifeCycleCost_UseAdjustment_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Economics.LifeCycleCost_UseAdjustment> ();
        
        public bool ShouldSerializeGenerator_InternalCombustionEngine_List()
        {
            return (Generator_InternalCombustionEngine_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Generator:InternalCombustionEngine", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_InternalCombustionEngine> Generator_InternalCombustionEngine_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_InternalCombustionEngine> ();
        
        public bool ShouldSerializeGenerator_CombustionTurbine_List()
        {
            return (Generator_CombustionTurbine_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Generator:CombustionTurbine", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_CombustionTurbine> Generator_CombustionTurbine_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_CombustionTurbine> ();
        
        public bool ShouldSerializeGenerator_MicroTurbine_List()
        {
            return (Generator_MicroTurbine_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Generator:MicroTurbine", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_MicroTurbine> Generator_MicroTurbine_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_MicroTurbine> ();
        
        public bool ShouldSerializeGenerator_Photovoltaic_List()
        {
            return (Generator_Photovoltaic_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Generator:Photovoltaic", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_Photovoltaic> Generator_Photovoltaic_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_Photovoltaic> ();
        
        public bool ShouldSerializePhotovoltaicPerformance_Simple_List()
        {
            return (PhotovoltaicPerformance_Simple_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PhotovoltaicPerformance:Simple", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.PhotovoltaicPerformance_Simple> PhotovoltaicPerformance_Simple_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.PhotovoltaicPerformance_Simple> ();
        
        public bool ShouldSerializePhotovoltaicPerformance_EquivalentOneDiode_List()
        {
            return (PhotovoltaicPerformance_EquivalentOneDiode_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PhotovoltaicPerformance:EquivalentOne-Diode", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.PhotovoltaicPerformance_EquivalentOneDiode> PhotovoltaicPerformance_EquivalentOneDiode_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.PhotovoltaicPerformance_EquivalentOneDiode> ();
        
        public bool ShouldSerializePhotovoltaicPerformance_Sandia_List()
        {
            return (PhotovoltaicPerformance_Sandia_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PhotovoltaicPerformance:Sandia", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.PhotovoltaicPerformance_Sandia> PhotovoltaicPerformance_Sandia_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.PhotovoltaicPerformance_Sandia> ();
        
        public bool ShouldSerializeGenerator_PVWatts_List()
        {
            return (Generator_PVWatts_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Generator:PVWatts", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_PVWatts> Generator_PVWatts_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_PVWatts> ();
        
        public bool ShouldSerializeElectricLoadCenter_Inverter_PVWatts_List()
        {
            return (ElectricLoadCenter_Inverter_PVWatts_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ElectricLoadCenter:Inverter:PVWatts", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.ElectricLoadCenter_Inverter_PVWatts> ElectricLoadCenter_Inverter_PVWatts_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.ElectricLoadCenter_Inverter_PVWatts> ();
        
        public bool ShouldSerializeGenerator_FuelCell_List()
        {
            return (Generator_FuelCell_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Generator:FuelCell", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_FuelCell> Generator_FuelCell_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_FuelCell> ();
        
        public bool ShouldSerializeGenerator_FuelCell_PowerModule_List()
        {
            return (Generator_FuelCell_PowerModule_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Generator:FuelCell:PowerModule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_FuelCell_PowerModule> Generator_FuelCell_PowerModule_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_FuelCell_PowerModule> ();
        
        public bool ShouldSerializeGenerator_FuelCell_AirSupply_List()
        {
            return (Generator_FuelCell_AirSupply_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Generator:FuelCell:AirSupply", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_FuelCell_AirSupply> Generator_FuelCell_AirSupply_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_FuelCell_AirSupply> ();
        
        public bool ShouldSerializeGenerator_FuelCell_WaterSupply_List()
        {
            return (Generator_FuelCell_WaterSupply_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Generator:FuelCell:WaterSupply", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_FuelCell_WaterSupply> Generator_FuelCell_WaterSupply_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_FuelCell_WaterSupply> ();
        
        public bool ShouldSerializeGenerator_FuelCell_AuxiliaryHeater_List()
        {
            return (Generator_FuelCell_AuxiliaryHeater_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Generator:FuelCell:AuxiliaryHeater", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_FuelCell_AuxiliaryHeater> Generator_FuelCell_AuxiliaryHeater_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_FuelCell_AuxiliaryHeater> ();
        
        public bool ShouldSerializeGenerator_FuelCell_ExhaustGasToWaterHeatExchanger_List()
        {
            return (Generator_FuelCell_ExhaustGasToWaterHeatExchanger_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Generator:FuelCell:ExhaustGasToWaterHeatExchanger", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_FuelCell_ExhaustGasToWaterHeatExchanger> Generator_FuelCell_ExhaustGasToWaterHeatExchanger_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_FuelCell_ExhaustGasToWaterHeatExchanger> ();
        
        public bool ShouldSerializeGenerator_FuelCell_ElectricalStorage_List()
        {
            return (Generator_FuelCell_ElectricalStorage_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Generator:FuelCell:ElectricalStorage", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_FuelCell_ElectricalStorage> Generator_FuelCell_ElectricalStorage_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_FuelCell_ElectricalStorage> ();
        
        public bool ShouldSerializeGenerator_FuelCell_Inverter_List()
        {
            return (Generator_FuelCell_Inverter_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Generator:FuelCell:Inverter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_FuelCell_Inverter> Generator_FuelCell_Inverter_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_FuelCell_Inverter> ();
        
        public bool ShouldSerializeGenerator_FuelCell_StackCooler_List()
        {
            return (Generator_FuelCell_StackCooler_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Generator:FuelCell:StackCooler", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_FuelCell_StackCooler> Generator_FuelCell_StackCooler_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_FuelCell_StackCooler> ();
        
        public bool ShouldSerializeGenerator_MicroCHP_List()
        {
            return (Generator_MicroCHP_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Generator:MicroCHP", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_MicroCHP> Generator_MicroCHP_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_MicroCHP> ();
        
        public bool ShouldSerializeGenerator_MicroCHP_NonNormalizedParameters_List()
        {
            return (Generator_MicroCHP_NonNormalizedParameters_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Generator:MicroCHP:NonNormalizedParameters", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_MicroCHP_NonNormalizedParameters> Generator_MicroCHP_NonNormalizedParameters_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_MicroCHP_NonNormalizedParameters> ();
        
        public bool ShouldSerializeGenerator_FuelSupply_List()
        {
            return (Generator_FuelSupply_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Generator:FuelSupply", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_FuelSupply> Generator_FuelSupply_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_FuelSupply> ();
        
        public bool ShouldSerializeGenerator_WindTurbine_List()
        {
            return (Generator_WindTurbine_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Generator:WindTurbine", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_WindTurbine> Generator_WindTurbine_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.Generator_WindTurbine> ();
        
        public bool ShouldSerializeElectricLoadCenter_Generators_List()
        {
            return (ElectricLoadCenter_Generators_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ElectricLoadCenter:Generators", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.ElectricLoadCenter_Generators> ElectricLoadCenter_Generators_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.ElectricLoadCenter_Generators> ();
        
        public bool ShouldSerializeElectricLoadCenter_Inverter_Simple_List()
        {
            return (ElectricLoadCenter_Inverter_Simple_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ElectricLoadCenter:Inverter:Simple", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.ElectricLoadCenter_Inverter_Simple> ElectricLoadCenter_Inverter_Simple_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.ElectricLoadCenter_Inverter_Simple> ();
        
        public bool ShouldSerializeElectricLoadCenter_Inverter_FunctionOfPower_List()
        {
            return (ElectricLoadCenter_Inverter_FunctionOfPower_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ElectricLoadCenter:Inverter:FunctionOfPower", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.ElectricLoadCenter_Inverter_FunctionOfPower> ElectricLoadCenter_Inverter_FunctionOfPower_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.ElectricLoadCenter_Inverter_FunctionOfPower> ();
        
        public bool ShouldSerializeElectricLoadCenter_Inverter_LookUpTable_List()
        {
            return (ElectricLoadCenter_Inverter_LookUpTable_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ElectricLoadCenter:Inverter:LookUpTable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.ElectricLoadCenter_Inverter_LookUpTable> ElectricLoadCenter_Inverter_LookUpTable_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.ElectricLoadCenter_Inverter_LookUpTable> ();
        
        public bool ShouldSerializeElectricLoadCenter_Storage_Simple_List()
        {
            return (ElectricLoadCenter_Storage_Simple_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ElectricLoadCenter:Storage:Simple", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.ElectricLoadCenter_Storage_Simple> ElectricLoadCenter_Storage_Simple_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.ElectricLoadCenter_Storage_Simple> ();
        
        public bool ShouldSerializeElectricLoadCenter_Storage_Battery_List()
        {
            return (ElectricLoadCenter_Storage_Battery_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ElectricLoadCenter:Storage:Battery", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.ElectricLoadCenter_Storage_Battery> ElectricLoadCenter_Storage_Battery_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.ElectricLoadCenter_Storage_Battery> ();
        
        public bool ShouldSerializeElectricLoadCenter_Storage_LiIonNMCBattery_List()
        {
            return (ElectricLoadCenter_Storage_LiIonNMCBattery_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ElectricLoadCenter:Storage:LiIonNMCBattery", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.ElectricLoadCenter_Storage_LiIonNMCBattery> ElectricLoadCenter_Storage_LiIonNMCBattery_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.ElectricLoadCenter_Storage_LiIonNMCBattery> ();
        
        public bool ShouldSerializeElectricLoadCenter_Transformer_List()
        {
            return (ElectricLoadCenter_Transformer_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ElectricLoadCenter:Transformer", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.ElectricLoadCenter_Transformer> ElectricLoadCenter_Transformer_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.ElectricLoadCenter_Transformer> ();
        
        public bool ShouldSerializeElectricLoadCenter_Distribution_List()
        {
            return (ElectricLoadCenter_Distribution_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ElectricLoadCenter:Distribution", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.ElectricLoadCenter_Distribution> ElectricLoadCenter_Distribution_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.ElectricLoadCenter_Distribution> ();
        
        public bool ShouldSerializeElectricLoadCenter_Storage_Converter_List()
        {
            return (ElectricLoadCenter_Storage_Converter_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ElectricLoadCenter:Storage:Converter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.ElectricLoadCenter_Storage_Converter> ElectricLoadCenter_Storage_Converter_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ElectricLoadCenterGeneratorSpecifications.ElectricLoadCenter_Storage_Converter> ();
        
        public bool ShouldSerializeEnergyManagementSystem_Sensor_List()
        {
            return (EnergyManagementSystem_Sensor_List.Count > 0);
        }
        

[JsonProperty(PropertyName="EnergyManagementSystem:Sensor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_Sensor> EnergyManagementSystem_Sensor_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_Sensor> ();
        
        public bool ShouldSerializeEnergyManagementSystem_Actuator_List()
        {
            return (EnergyManagementSystem_Actuator_List.Count > 0);
        }
        

[JsonProperty(PropertyName="EnergyManagementSystem:Actuator", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_Actuator> EnergyManagementSystem_Actuator_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_Actuator> ();
        
        public bool ShouldSerializeEnergyManagementSystem_ProgramCallingManager_List()
        {
            return (EnergyManagementSystem_ProgramCallingManager_List.Count > 0);
        }
        

[JsonProperty(PropertyName="EnergyManagementSystem:ProgramCallingManager", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_ProgramCallingManager> EnergyManagementSystem_ProgramCallingManager_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_ProgramCallingManager> ();
        
        public bool ShouldSerializeEnergyManagementSystem_Program_List()
        {
            return (EnergyManagementSystem_Program_List.Count > 0);
        }
        

[JsonProperty(PropertyName="EnergyManagementSystem:Program", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_Program> EnergyManagementSystem_Program_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_Program> ();
        
        public bool ShouldSerializeEnergyManagementSystem_Subroutine_List()
        {
            return (EnergyManagementSystem_Subroutine_List.Count > 0);
        }
        

[JsonProperty(PropertyName="EnergyManagementSystem:Subroutine", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_Subroutine> EnergyManagementSystem_Subroutine_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_Subroutine> ();
        
        public bool ShouldSerializeEnergyManagementSystem_GlobalVariable_List()
        {
            return (EnergyManagementSystem_GlobalVariable_List.Count > 0);
        }
        

[JsonProperty(PropertyName="EnergyManagementSystem:GlobalVariable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_GlobalVariable> EnergyManagementSystem_GlobalVariable_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_GlobalVariable> ();
        
        public bool ShouldSerializeEnergyManagementSystem_OutputVariable_List()
        {
            return (EnergyManagementSystem_OutputVariable_List.Count > 0);
        }
        

[JsonProperty(PropertyName="EnergyManagementSystem:OutputVariable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_OutputVariable> EnergyManagementSystem_OutputVariable_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_OutputVariable> ();
        
        public bool ShouldSerializeEnergyManagementSystem_MeteredOutputVariable_List()
        {
            return (EnergyManagementSystem_MeteredOutputVariable_List.Count > 0);
        }
        

[JsonProperty(PropertyName="EnergyManagementSystem:MeteredOutputVariable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_MeteredOutputVariable> EnergyManagementSystem_MeteredOutputVariable_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_MeteredOutputVariable> ();
        
        public bool ShouldSerializeEnergyManagementSystem_TrendVariable_List()
        {
            return (EnergyManagementSystem_TrendVariable_List.Count > 0);
        }
        

[JsonProperty(PropertyName="EnergyManagementSystem:TrendVariable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_TrendVariable> EnergyManagementSystem_TrendVariable_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_TrendVariable> ();
        
        public bool ShouldSerializeEnergyManagementSystem_InternalVariable_List()
        {
            return (EnergyManagementSystem_InternalVariable_List.Count > 0);
        }
        

[JsonProperty(PropertyName="EnergyManagementSystem:InternalVariable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_InternalVariable> EnergyManagementSystem_InternalVariable_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_InternalVariable> ();
        
        public bool ShouldSerializeEnergyManagementSystem_CurveOrTableIndexVariable_List()
        {
            return (EnergyManagementSystem_CurveOrTableIndexVariable_List.Count > 0);
        }
        

[JsonProperty(PropertyName="EnergyManagementSystem:CurveOrTableIndexVariable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_CurveOrTableIndexVariable> EnergyManagementSystem_CurveOrTableIndexVariable_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_CurveOrTableIndexVariable> ();
        
        public bool ShouldSerializeEnergyManagementSystem_ConstructionIndexVariable_List()
        {
            return (EnergyManagementSystem_ConstructionIndexVariable_List.Count > 0);
        }
        

[JsonProperty(PropertyName="EnergyManagementSystem:ConstructionIndexVariable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_ConstructionIndexVariable> EnergyManagementSystem_ConstructionIndexVariable_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.EnergyManagementSystemEMS.EnergyManagementSystem_ConstructionIndexVariable> ();
        
        public bool ShouldSerializeEvaporativeCooler_Direct_CelDekPad_List()
        {
            return (EvaporativeCooler_Direct_CelDekPad_List.Count > 0);
        }
        

[JsonProperty(PropertyName="EvaporativeCooler:Direct:CelDekPad", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.EvaporativeCoolers.EvaporativeCooler_Direct_CelDekPad> EvaporativeCooler_Direct_CelDekPad_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.EvaporativeCoolers.EvaporativeCooler_Direct_CelDekPad> ();
        
        public bool ShouldSerializeEvaporativeCooler_Indirect_CelDekPad_List()
        {
            return (EvaporativeCooler_Indirect_CelDekPad_List.Count > 0);
        }
        

[JsonProperty(PropertyName="EvaporativeCooler:Indirect:CelDekPad", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.EvaporativeCoolers.EvaporativeCooler_Indirect_CelDekPad> EvaporativeCooler_Indirect_CelDekPad_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.EvaporativeCoolers.EvaporativeCooler_Indirect_CelDekPad> ();
        
        public bool ShouldSerializeEvaporativeCooler_Indirect_WetCoil_List()
        {
            return (EvaporativeCooler_Indirect_WetCoil_List.Count > 0);
        }
        

[JsonProperty(PropertyName="EvaporativeCooler:Indirect:WetCoil", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.EvaporativeCoolers.EvaporativeCooler_Indirect_WetCoil> EvaporativeCooler_Indirect_WetCoil_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.EvaporativeCoolers.EvaporativeCooler_Indirect_WetCoil> ();
        
        public bool ShouldSerializeEvaporativeCooler_Indirect_ResearchSpecial_List()
        {
            return (EvaporativeCooler_Indirect_ResearchSpecial_List.Count > 0);
        }
        

[JsonProperty(PropertyName="EvaporativeCooler:Indirect:ResearchSpecial", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.EvaporativeCoolers.EvaporativeCooler_Indirect_ResearchSpecial> EvaporativeCooler_Indirect_ResearchSpecial_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.EvaporativeCoolers.EvaporativeCooler_Indirect_ResearchSpecial> ();
        
        public bool ShouldSerializeEvaporativeCooler_Direct_ResearchSpecial_List()
        {
            return (EvaporativeCooler_Direct_ResearchSpecial_List.Count > 0);
        }
        

[JsonProperty(PropertyName="EvaporativeCooler:Direct:ResearchSpecial", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.EvaporativeCoolers.EvaporativeCooler_Direct_ResearchSpecial> EvaporativeCooler_Direct_ResearchSpecial_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.EvaporativeCoolers.EvaporativeCooler_Direct_ResearchSpecial> ();
        
        public bool ShouldSerializeExterior_Lights_List()
        {
            return (Exterior_Lights_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Exterior:Lights", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ExteriorEquipment.Exterior_Lights> Exterior_Lights_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ExteriorEquipment.Exterior_Lights> ();
        
        public bool ShouldSerializeExterior_FuelEquipment_List()
        {
            return (Exterior_FuelEquipment_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Exterior:FuelEquipment", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ExteriorEquipment.Exterior_FuelEquipment> Exterior_FuelEquipment_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ExteriorEquipment.Exterior_FuelEquipment> ();
        
        public bool ShouldSerializeExterior_WaterEquipment_List()
        {
            return (Exterior_WaterEquipment_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Exterior:WaterEquipment", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ExteriorEquipment.Exterior_WaterEquipment> Exterior_WaterEquipment_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ExteriorEquipment.Exterior_WaterEquipment> ();
        
        public bool ShouldSerializeExternalInterface_List()
        {
            return (ExternalInterface_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ExternalInterface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface> ExternalInterface_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface> ();
        
        public bool ShouldSerializeExternalInterface_Schedule_List()
        {
            return (ExternalInterface_Schedule_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ExternalInterface:Schedule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_Schedule> ExternalInterface_Schedule_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_Schedule> ();
        
        public bool ShouldSerializeExternalInterface_Variable_List()
        {
            return (ExternalInterface_Variable_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ExternalInterface:Variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_Variable> ExternalInterface_Variable_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_Variable> ();
        
        public bool ShouldSerializeExternalInterface_Actuator_List()
        {
            return (ExternalInterface_Actuator_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ExternalInterface:Actuator", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_Actuator> ExternalInterface_Actuator_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_Actuator> ();
        
        public bool ShouldSerializeExternalInterface_FunctionalMockupUnitImport_List()
        {
            return (ExternalInterface_FunctionalMockupUnitImport_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ExternalInterface:FunctionalMockupUnitImport", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_FunctionalMockupUnitImport> ExternalInterface_FunctionalMockupUnitImport_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_FunctionalMockupUnitImport> ();
        
        public bool ShouldSerializeExternalInterface_FunctionalMockupUnitImport_From_Variable_List()
        {
            return (ExternalInterface_FunctionalMockupUnitImport_From_Variable_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ExternalInterface:FunctionalMockupUnitImport:From:Variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_FunctionalMockupUnitImport_From_Variable> ExternalInterface_FunctionalMockupUnitImport_From_Variable_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_FunctionalMockupUnitImport_From_Variable> ();
        
        public bool ShouldSerializeExternalInterface_FunctionalMockupUnitImport_To_Schedule_List()
        {
            return (ExternalInterface_FunctionalMockupUnitImport_To_Schedule_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ExternalInterface:FunctionalMockupUnitImport:To:Schedule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_FunctionalMockupUnitImport_To_Schedule> ExternalInterface_FunctionalMockupUnitImport_To_Schedule_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_FunctionalMockupUnitImport_To_Schedule> ();
        
        public bool ShouldSerializeExternalInterface_FunctionalMockupUnitImport_To_Actuator_List()
        {
            return (ExternalInterface_FunctionalMockupUnitImport_To_Actuator_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ExternalInterface:FunctionalMockupUnitImport:To:Actuator", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_FunctionalMockupUnitImport_To_Actuator> ExternalInterface_FunctionalMockupUnitImport_To_Actuator_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_FunctionalMockupUnitImport_To_Actuator> ();
        
        public bool ShouldSerializeExternalInterface_FunctionalMockupUnitImport_To_Variable_List()
        {
            return (ExternalInterface_FunctionalMockupUnitImport_To_Variable_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ExternalInterface:FunctionalMockupUnitImport:To:Variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_FunctionalMockupUnitImport_To_Variable> ExternalInterface_FunctionalMockupUnitImport_To_Variable_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_FunctionalMockupUnitImport_To_Variable> ();
        
        public bool ShouldSerializeExternalInterface_FunctionalMockupUnitExport_From_Variable_List()
        {
            return (ExternalInterface_FunctionalMockupUnitExport_From_Variable_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ExternalInterface:FunctionalMockupUnitExport:From:Variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_FunctionalMockupUnitExport_From_Variable> ExternalInterface_FunctionalMockupUnitExport_From_Variable_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_FunctionalMockupUnitExport_From_Variable> ();
        
        public bool ShouldSerializeExternalInterface_FunctionalMockupUnitExport_To_Schedule_List()
        {
            return (ExternalInterface_FunctionalMockupUnitExport_To_Schedule_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ExternalInterface:FunctionalMockupUnitExport:To:Schedule", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_FunctionalMockupUnitExport_To_Schedule> ExternalInterface_FunctionalMockupUnitExport_To_Schedule_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_FunctionalMockupUnitExport_To_Schedule> ();
        
        public bool ShouldSerializeExternalInterface_FunctionalMockupUnitExport_To_Actuator_List()
        {
            return (ExternalInterface_FunctionalMockupUnitExport_To_Actuator_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ExternalInterface:FunctionalMockupUnitExport:To:Actuator", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_FunctionalMockupUnitExport_To_Actuator> ExternalInterface_FunctionalMockupUnitExport_To_Actuator_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_FunctionalMockupUnitExport_To_Actuator> ();
        
        public bool ShouldSerializeExternalInterface_FunctionalMockupUnitExport_To_Variable_List()
        {
            return (ExternalInterface_FunctionalMockupUnitExport_To_Variable_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ExternalInterface:FunctionalMockupUnitExport:To:Variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_FunctionalMockupUnitExport_To_Variable> ExternalInterface_FunctionalMockupUnitExport_To_Variable_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ExternalInterface.ExternalInterface_FunctionalMockupUnitExport_To_Variable> ();
        
        public bool ShouldSerializeFan_SystemModel_List()
        {
            return (Fan_SystemModel_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Fan:SystemModel", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Fans.Fan_SystemModel> Fan_SystemModel_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Fans.Fan_SystemModel> ();
        
        public bool ShouldSerializeFan_ConstantVolume_List()
        {
            return (Fan_ConstantVolume_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Fan:ConstantVolume", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Fans.Fan_ConstantVolume> Fan_ConstantVolume_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Fans.Fan_ConstantVolume> ();
        
        public bool ShouldSerializeFan_VariableVolume_List()
        {
            return (Fan_VariableVolume_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Fan:VariableVolume", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Fans.Fan_VariableVolume> Fan_VariableVolume_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Fans.Fan_VariableVolume> ();
        
        public bool ShouldSerializeFan_OnOff_List()
        {
            return (Fan_OnOff_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Fan:OnOff", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Fans.Fan_OnOff> Fan_OnOff_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Fans.Fan_OnOff> ();
        
        public bool ShouldSerializeFan_ZoneExhaust_List()
        {
            return (Fan_ZoneExhaust_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Fan:ZoneExhaust", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Fans.Fan_ZoneExhaust> Fan_ZoneExhaust_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Fans.Fan_ZoneExhaust> ();
        
        public bool ShouldSerializeFanPerformance_NightVentilation_List()
        {
            return (FanPerformance_NightVentilation_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FanPerformance:NightVentilation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Fans.FanPerformance_NightVentilation> FanPerformance_NightVentilation_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Fans.FanPerformance_NightVentilation> ();
        
        public bool ShouldSerializeFan_ComponentModel_List()
        {
            return (Fan_ComponentModel_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Fan:ComponentModel", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Fans.Fan_ComponentModel> Fan_ComponentModel_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Fans.Fan_ComponentModel> ();
        
        public bool ShouldSerializeFluidProperties_Name_List()
        {
            return (FluidProperties_Name_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FluidProperties:Name", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.FluidProperties.FluidProperties_Name> FluidProperties_Name_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.FluidProperties.FluidProperties_Name> ();
        
        public bool ShouldSerializeFluidProperties_GlycolConcentration_List()
        {
            return (FluidProperties_GlycolConcentration_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FluidProperties:GlycolConcentration", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.FluidProperties.FluidProperties_GlycolConcentration> FluidProperties_GlycolConcentration_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.FluidProperties.FluidProperties_GlycolConcentration> ();
        
        public bool ShouldSerializeFluidProperties_Temperatures_List()
        {
            return (FluidProperties_Temperatures_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FluidProperties:Temperatures", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.FluidProperties.FluidProperties_Temperatures> FluidProperties_Temperatures_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.FluidProperties.FluidProperties_Temperatures> ();
        
        public bool ShouldSerializeFluidProperties_Saturated_List()
        {
            return (FluidProperties_Saturated_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FluidProperties:Saturated", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.FluidProperties.FluidProperties_Saturated> FluidProperties_Saturated_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.FluidProperties.FluidProperties_Saturated> ();
        
        public bool ShouldSerializeFluidProperties_Superheated_List()
        {
            return (FluidProperties_Superheated_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FluidProperties:Superheated", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.FluidProperties.FluidProperties_Superheated> FluidProperties_Superheated_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.FluidProperties.FluidProperties_Superheated> ();
        
        public bool ShouldSerializeFluidProperties_Concentration_List()
        {
            return (FluidProperties_Concentration_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FluidProperties:Concentration", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.FluidProperties.FluidProperties_Concentration> FluidProperties_Concentration_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.FluidProperties.FluidProperties_Concentration> ();
        
        public bool ShouldSerializeMatrix_TwoDimension_List()
        {
            return (Matrix_TwoDimension_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Matrix:TwoDimension", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.GeneralDataEntry.Matrix_TwoDimension> Matrix_TwoDimension_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.GeneralDataEntry.Matrix_TwoDimension> ();
        
        public bool ShouldSerializeHeatExchanger_AirToAir_FlatPlate_List()
        {
            return (HeatExchanger_AirToAir_FlatPlate_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HeatExchanger:AirToAir:FlatPlate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HeatRecovery.HeatExchanger_AirToAir_FlatPlate> HeatExchanger_AirToAir_FlatPlate_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HeatRecovery.HeatExchanger_AirToAir_FlatPlate> ();
        
        public bool ShouldSerializeHeatExchanger_AirToAir_SensibleAndLatent_List()
        {
            return (HeatExchanger_AirToAir_SensibleAndLatent_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HeatExchanger:AirToAir:SensibleAndLatent", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HeatRecovery.HeatExchanger_AirToAir_SensibleAndLatent> HeatExchanger_AirToAir_SensibleAndLatent_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HeatRecovery.HeatExchanger_AirToAir_SensibleAndLatent> ();
        
        public bool ShouldSerializeHeatExchanger_Desiccant_BalancedFlow_List()
        {
            return (HeatExchanger_Desiccant_BalancedFlow_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HeatExchanger:Desiccant:BalancedFlow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HeatRecovery.HeatExchanger_Desiccant_BalancedFlow> HeatExchanger_Desiccant_BalancedFlow_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HeatRecovery.HeatExchanger_Desiccant_BalancedFlow> ();
        
        public bool ShouldSerializeHeatExchanger_Desiccant_BalancedFlow_PerformanceDataType1_List()
        {
            return (HeatExchanger_Desiccant_BalancedFlow_PerformanceDataType1_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HeatExchanger:Desiccant:BalancedFlow:PerformanceDataType1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HeatRecovery.HeatExchanger_Desiccant_BalancedFlow_PerformanceDataType1> HeatExchanger_Desiccant_BalancedFlow_PerformanceDataType1_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HeatRecovery.HeatExchanger_Desiccant_BalancedFlow_PerformanceDataType1> ();
        
        public bool ShouldSerializeHumidifier_Steam_Electric_List()
        {
            return (Humidifier_Steam_Electric_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Humidifier:Steam:Electric", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HumidifiersandDehumidifiers.Humidifier_Steam_Electric> Humidifier_Steam_Electric_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HumidifiersandDehumidifiers.Humidifier_Steam_Electric> ();
        
        public bool ShouldSerializeHumidifier_Steam_Gas_List()
        {
            return (Humidifier_Steam_Gas_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Humidifier:Steam:Gas", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HumidifiersandDehumidifiers.Humidifier_Steam_Gas> Humidifier_Steam_Gas_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HumidifiersandDehumidifiers.Humidifier_Steam_Gas> ();
        
        public bool ShouldSerializeDehumidifier_Desiccant_NoFans_List()
        {
            return (Dehumidifier_Desiccant_NoFans_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Dehumidifier:Desiccant:NoFans", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HumidifiersandDehumidifiers.Dehumidifier_Desiccant_NoFans> Dehumidifier_Desiccant_NoFans_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HumidifiersandDehumidifiers.Dehumidifier_Desiccant_NoFans> ();
        
        public bool ShouldSerializeDehumidifier_Desiccant_System_List()
        {
            return (Dehumidifier_Desiccant_System_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Dehumidifier:Desiccant:System", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HumidifiersandDehumidifiers.Dehumidifier_Desiccant_System> Dehumidifier_Desiccant_System_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HumidifiersandDehumidifiers.Dehumidifier_Desiccant_System> ();
        
        public bool ShouldSerializeDesignSpecification_OutdoorAir_List()
        {
            return (DesignSpecification_OutdoorAir_List.Count > 0);
        }
        

[JsonProperty(PropertyName="DesignSpecification:OutdoorAir", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACDesignObjects.DesignSpecification_OutdoorAir> DesignSpecification_OutdoorAir_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACDesignObjects.DesignSpecification_OutdoorAir> ();
        
        public bool ShouldSerializeDesignSpecification_ZoneAirDistribution_List()
        {
            return (DesignSpecification_ZoneAirDistribution_List.Count > 0);
        }
        

[JsonProperty(PropertyName="DesignSpecification:ZoneAirDistribution", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACDesignObjects.DesignSpecification_ZoneAirDistribution> DesignSpecification_ZoneAirDistribution_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACDesignObjects.DesignSpecification_ZoneAirDistribution> ();
        

[JsonProperty(PropertyName="Sizing:Parameters", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.HVACDesignObjects.Sizing_Parameters Sizing_Parameters { get; set; } = null;
        
        public bool ShouldSerializeSizing_Zone_List()
        {
            return (Sizing_Zone_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Sizing:Zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACDesignObjects.Sizing_Zone> Sizing_Zone_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACDesignObjects.Sizing_Zone> ();
        
        public bool ShouldSerializeDesignSpecification_ZoneHVAC_Sizing_List()
        {
            return (DesignSpecification_ZoneHVAC_Sizing_List.Count > 0);
        }
        

[JsonProperty(PropertyName="DesignSpecification:ZoneHVAC:Sizing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACDesignObjects.DesignSpecification_ZoneHVAC_Sizing> DesignSpecification_ZoneHVAC_Sizing_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACDesignObjects.DesignSpecification_ZoneHVAC_Sizing> ();
        
        public bool ShouldSerializeDesignSpecification_AirTerminal_Sizing_List()
        {
            return (DesignSpecification_AirTerminal_Sizing_List.Count > 0);
        }
        

[JsonProperty(PropertyName="DesignSpecification:AirTerminal:Sizing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACDesignObjects.DesignSpecification_AirTerminal_Sizing> DesignSpecification_AirTerminal_Sizing_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACDesignObjects.DesignSpecification_AirTerminal_Sizing> ();
        
        public bool ShouldSerializeSizing_System_List()
        {
            return (Sizing_System_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Sizing:System", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACDesignObjects.Sizing_System> Sizing_System_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACDesignObjects.Sizing_System> ();
        
        public bool ShouldSerializeSizing_Plant_List()
        {
            return (Sizing_Plant_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Sizing:Plant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACDesignObjects.Sizing_Plant> Sizing_Plant_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACDesignObjects.Sizing_Plant> ();
        

[JsonProperty(PropertyName="OutputControl:Sizing:Style", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.HVACDesignObjects.OutputControl_Sizing_Style OutputControl_Sizing_Style { get; set; } = null;
        
        public bool ShouldSerializeHVACTemplate_Thermostat_List()
        {
            return (HVACTemplate_Thermostat_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:Thermostat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Thermostat> HVACTemplate_Thermostat_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Thermostat> ();
        
        public bool ShouldSerializeHVACTemplate_Zone_IdealLoadsAirSystem_List()
        {
            return (HVACTemplate_Zone_IdealLoadsAirSystem_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:Zone:IdealLoadsAirSystem", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_IdealLoadsAirSystem> HVACTemplate_Zone_IdealLoadsAirSystem_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_IdealLoadsAirSystem> ();
        
        public bool ShouldSerializeHVACTemplate_Zone_BaseboardHeat_List()
        {
            return (HVACTemplate_Zone_BaseboardHeat_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:Zone:BaseboardHeat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_BaseboardHeat> HVACTemplate_Zone_BaseboardHeat_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_BaseboardHeat> ();
        
        public bool ShouldSerializeHVACTemplate_Zone_FanCoil_List()
        {
            return (HVACTemplate_Zone_FanCoil_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:Zone:FanCoil", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_FanCoil> HVACTemplate_Zone_FanCoil_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_FanCoil> ();
        
        public bool ShouldSerializeHVACTemplate_Zone_PTAC_List()
        {
            return (HVACTemplate_Zone_PTAC_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:Zone:PTAC", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_PTAC> HVACTemplate_Zone_PTAC_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_PTAC> ();
        
        public bool ShouldSerializeHVACTemplate_Zone_PTHP_List()
        {
            return (HVACTemplate_Zone_PTHP_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:Zone:PTHP", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_PTHP> HVACTemplate_Zone_PTHP_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_PTHP> ();
        
        public bool ShouldSerializeHVACTemplate_Zone_WaterToAirHeatPump_List()
        {
            return (HVACTemplate_Zone_WaterToAirHeatPump_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:Zone:WaterToAirHeatPump", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_WaterToAirHeatPump> HVACTemplate_Zone_WaterToAirHeatPump_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_WaterToAirHeatPump> ();
        
        public bool ShouldSerializeHVACTemplate_Zone_VRF_List()
        {
            return (HVACTemplate_Zone_VRF_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:Zone:VRF", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_VRF> HVACTemplate_Zone_VRF_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_VRF> ();
        
        public bool ShouldSerializeHVACTemplate_Zone_Unitary_List()
        {
            return (HVACTemplate_Zone_Unitary_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:Zone:Unitary", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_Unitary> HVACTemplate_Zone_Unitary_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_Unitary> ();
        
        public bool ShouldSerializeHVACTemplate_Zone_VAV_List()
        {
            return (HVACTemplate_Zone_VAV_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:Zone:VAV", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_VAV> HVACTemplate_Zone_VAV_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_VAV> ();
        
        public bool ShouldSerializeHVACTemplate_Zone_VAV_FanPowered_List()
        {
            return (HVACTemplate_Zone_VAV_FanPowered_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:Zone:VAV:FanPowered", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_VAV_FanPowered> HVACTemplate_Zone_VAV_FanPowered_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_VAV_FanPowered> ();
        
        public bool ShouldSerializeHVACTemplate_Zone_VAV_HeatAndCool_List()
        {
            return (HVACTemplate_Zone_VAV_HeatAndCool_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:Zone:VAV:HeatAndCool", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_VAV_HeatAndCool> HVACTemplate_Zone_VAV_HeatAndCool_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_VAV_HeatAndCool> ();
        
        public bool ShouldSerializeHVACTemplate_Zone_ConstantVolume_List()
        {
            return (HVACTemplate_Zone_ConstantVolume_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:Zone:ConstantVolume", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_ConstantVolume> HVACTemplate_Zone_ConstantVolume_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_ConstantVolume> ();
        
        public bool ShouldSerializeHVACTemplate_Zone_DualDuct_List()
        {
            return (HVACTemplate_Zone_DualDuct_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:Zone:DualDuct", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_DualDuct> HVACTemplate_Zone_DualDuct_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Zone_DualDuct> ();
        
        public bool ShouldSerializeHVACTemplate_System_VRF_List()
        {
            return (HVACTemplate_System_VRF_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:System:VRF", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_System_VRF> HVACTemplate_System_VRF_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_System_VRF> ();
        
        public bool ShouldSerializeHVACTemplate_System_Unitary_List()
        {
            return (HVACTemplate_System_Unitary_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:System:Unitary", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_System_Unitary> HVACTemplate_System_Unitary_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_System_Unitary> ();
        
        public bool ShouldSerializeHVACTemplate_System_UnitaryHeatPump_AirToAir_List()
        {
            return (HVACTemplate_System_UnitaryHeatPump_AirToAir_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:System:UnitaryHeatPump:AirToAir", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_System_UnitaryHeatPump_AirToAir> HVACTemplate_System_UnitaryHeatPump_AirToAir_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_System_UnitaryHeatPump_AirToAir> ();
        
        public bool ShouldSerializeHVACTemplate_System_UnitarySystem_List()
        {
            return (HVACTemplate_System_UnitarySystem_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:System:UnitarySystem", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_System_UnitarySystem> HVACTemplate_System_UnitarySystem_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_System_UnitarySystem> ();
        
        public bool ShouldSerializeHVACTemplate_System_VAV_List()
        {
            return (HVACTemplate_System_VAV_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:System:VAV", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_System_VAV> HVACTemplate_System_VAV_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_System_VAV> ();
        
        public bool ShouldSerializeHVACTemplate_System_PackagedVAV_List()
        {
            return (HVACTemplate_System_PackagedVAV_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:System:PackagedVAV", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_System_PackagedVAV> HVACTemplate_System_PackagedVAV_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_System_PackagedVAV> ();
        
        public bool ShouldSerializeHVACTemplate_System_ConstantVolume_List()
        {
            return (HVACTemplate_System_ConstantVolume_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:System:ConstantVolume", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_System_ConstantVolume> HVACTemplate_System_ConstantVolume_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_System_ConstantVolume> ();
        
        public bool ShouldSerializeHVACTemplate_System_DualDuct_List()
        {
            return (HVACTemplate_System_DualDuct_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:System:DualDuct", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_System_DualDuct> HVACTemplate_System_DualDuct_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_System_DualDuct> ();
        
        public bool ShouldSerializeHVACTemplate_System_DedicatedOutdoorAir_List()
        {
            return (HVACTemplate_System_DedicatedOutdoorAir_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:System:DedicatedOutdoorAir", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_System_DedicatedOutdoorAir> HVACTemplate_System_DedicatedOutdoorAir_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_System_DedicatedOutdoorAir> ();
        

[JsonProperty(PropertyName="HVACTemplate:Plant:ChilledWaterLoop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.HVACTemplates.HVACTemplate_Plant_ChilledWaterLoop HVACTemplate_Plant_ChilledWaterLoop { get; set; } = null;
        
        public bool ShouldSerializeHVACTemplate_Plant_Chiller_List()
        {
            return (HVACTemplate_Plant_Chiller_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:Plant:Chiller", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Plant_Chiller> HVACTemplate_Plant_Chiller_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Plant_Chiller> ();
        
        public bool ShouldSerializeHVACTemplate_Plant_Chiller_ObjectReference_List()
        {
            return (HVACTemplate_Plant_Chiller_ObjectReference_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:Plant:Chiller:ObjectReference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Plant_Chiller_ObjectReference> HVACTemplate_Plant_Chiller_ObjectReference_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Plant_Chiller_ObjectReference> ();
        
        public bool ShouldSerializeHVACTemplate_Plant_Tower_List()
        {
            return (HVACTemplate_Plant_Tower_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:Plant:Tower", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Plant_Tower> HVACTemplate_Plant_Tower_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Plant_Tower> ();
        
        public bool ShouldSerializeHVACTemplate_Plant_Tower_ObjectReference_List()
        {
            return (HVACTemplate_Plant_Tower_ObjectReference_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:Plant:Tower:ObjectReference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Plant_Tower_ObjectReference> HVACTemplate_Plant_Tower_ObjectReference_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Plant_Tower_ObjectReference> ();
        

[JsonProperty(PropertyName="HVACTemplate:Plant:HotWaterLoop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.HVACTemplates.HVACTemplate_Plant_HotWaterLoop HVACTemplate_Plant_HotWaterLoop { get; set; } = null;
        
        public bool ShouldSerializeHVACTemplate_Plant_Boiler_List()
        {
            return (HVACTemplate_Plant_Boiler_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:Plant:Boiler", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Plant_Boiler> HVACTemplate_Plant_Boiler_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Plant_Boiler> ();
        
        public bool ShouldSerializeHVACTemplate_Plant_Boiler_ObjectReference_List()
        {
            return (HVACTemplate_Plant_Boiler_ObjectReference_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HVACTemplate:Plant:Boiler:ObjectReference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Plant_Boiler_ObjectReference> HVACTemplate_Plant_Boiler_ObjectReference_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HVACTemplates.HVACTemplate_Plant_Boiler_ObjectReference> ();
        

[JsonProperty(PropertyName="HVACTemplate:Plant:MixedWaterLoop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.HVACTemplates.HVACTemplate_Plant_MixedWaterLoop HVACTemplate_Plant_MixedWaterLoop { get; set; } = null;
        
        public bool ShouldSerializeHybridModel_Zone_List()
        {
            return (HybridModel_Zone_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HybridModel:Zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.HybridModel.HybridModel_Zone> HybridModel_Zone_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.HybridModel.HybridModel_Zone> ();
        
        public bool ShouldSerializePeople_List()
        {
            return (People_List.Count > 0);
        }
        

[JsonProperty(PropertyName="People", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.InternalGains.People> People_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.InternalGains.People> ();
        
        public bool ShouldSerializeComfortViewFactorAngles_List()
        {
            return (ComfortViewFactorAngles_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ComfortViewFactorAngles", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.InternalGains.ComfortViewFactorAngles> ComfortViewFactorAngles_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.InternalGains.ComfortViewFactorAngles> ();
        
        public bool ShouldSerializeLights_List()
        {
            return (Lights_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Lights", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.InternalGains.Lights> Lights_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.InternalGains.Lights> ();
        
        public bool ShouldSerializeElectricEquipment_List()
        {
            return (ElectricEquipment_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ElectricEquipment", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.InternalGains.ElectricEquipment> ElectricEquipment_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.InternalGains.ElectricEquipment> ();
        
        public bool ShouldSerializeGasEquipment_List()
        {
            return (GasEquipment_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GasEquipment", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.InternalGains.GasEquipment> GasEquipment_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.InternalGains.GasEquipment> ();
        
        public bool ShouldSerializeHotWaterEquipment_List()
        {
            return (HotWaterEquipment_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HotWaterEquipment", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.InternalGains.HotWaterEquipment> HotWaterEquipment_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.InternalGains.HotWaterEquipment> ();
        
        public bool ShouldSerializeSteamEquipment_List()
        {
            return (SteamEquipment_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SteamEquipment", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.InternalGains.SteamEquipment> SteamEquipment_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.InternalGains.SteamEquipment> ();
        
        public bool ShouldSerializeOtherEquipment_List()
        {
            return (OtherEquipment_List.Count > 0);
        }
        

[JsonProperty(PropertyName="OtherEquipment", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.InternalGains.OtherEquipment> OtherEquipment_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.InternalGains.OtherEquipment> ();
        
        public bool ShouldSerializeElectricEquipment_ITE_AirCooled_List()
        {
            return (ElectricEquipment_ITE_AirCooled_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ElectricEquipment:ITE:AirCooled", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.InternalGains.ElectricEquipment_ITE_AirCooled> ElectricEquipment_ITE_AirCooled_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.InternalGains.ElectricEquipment_ITE_AirCooled> ();
        
        public bool ShouldSerializeZoneBaseboard_OutdoorTemperatureControlled_List()
        {
            return (ZoneBaseboard_OutdoorTemperatureControlled_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneBaseboard:OutdoorTemperatureControlled", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.InternalGains.ZoneBaseboard_OutdoorTemperatureControlled> ZoneBaseboard_OutdoorTemperatureControlled_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.InternalGains.ZoneBaseboard_OutdoorTemperatureControlled> ();
        
        public bool ShouldSerializeSwimmingPool_Indoor_List()
        {
            return (SwimmingPool_Indoor_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SwimmingPool:Indoor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.InternalGains.SwimmingPool_Indoor> SwimmingPool_Indoor_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.InternalGains.SwimmingPool_Indoor> ();
        
        public bool ShouldSerializeZoneContaminantSourceAndSink_CarbonDioxide_List()
        {
            return (ZoneContaminantSourceAndSink_CarbonDioxide_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneContaminantSourceAndSink:CarbonDioxide", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.InternalGains.ZoneContaminantSourceAndSink_CarbonDioxide> ZoneContaminantSourceAndSink_CarbonDioxide_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.InternalGains.ZoneContaminantSourceAndSink_CarbonDioxide> ();
        
        public bool ShouldSerializeZoneContaminantSourceAndSink_Generic_Constant_List()
        {
            return (ZoneContaminantSourceAndSink_Generic_Constant_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneContaminantSourceAndSink:Generic:Constant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.InternalGains.ZoneContaminantSourceAndSink_Generic_Constant> ZoneContaminantSourceAndSink_Generic_Constant_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.InternalGains.ZoneContaminantSourceAndSink_Generic_Constant> ();
        
        public bool ShouldSerializeSurfaceContaminantSourceAndSink_Generic_PressureDriven_List()
        {
            return (SurfaceContaminantSourceAndSink_Generic_PressureDriven_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SurfaceContaminantSourceAndSink:Generic:PressureDriven", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.InternalGains.SurfaceContaminantSourceAndSink_Generic_PressureDriven> SurfaceContaminantSourceAndSink_Generic_PressureDriven_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.InternalGains.SurfaceContaminantSourceAndSink_Generic_PressureDriven> ();
        
        public bool ShouldSerializeZoneContaminantSourceAndSink_Generic_CutoffModel_List()
        {
            return (ZoneContaminantSourceAndSink_Generic_CutoffModel_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneContaminantSourceAndSink:Generic:CutoffModel", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.InternalGains.ZoneContaminantSourceAndSink_Generic_CutoffModel> ZoneContaminantSourceAndSink_Generic_CutoffModel_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.InternalGains.ZoneContaminantSourceAndSink_Generic_CutoffModel> ();
        
        public bool ShouldSerializeZoneContaminantSourceAndSink_Generic_DecaySource_List()
        {
            return (ZoneContaminantSourceAndSink_Generic_DecaySource_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneContaminantSourceAndSink:Generic:DecaySource", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.InternalGains.ZoneContaminantSourceAndSink_Generic_DecaySource> ZoneContaminantSourceAndSink_Generic_DecaySource_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.InternalGains.ZoneContaminantSourceAndSink_Generic_DecaySource> ();
        
        public bool ShouldSerializeSurfaceContaminantSourceAndSink_Generic_BoundaryLayerDiffusion_List()
        {
            return (SurfaceContaminantSourceAndSink_Generic_BoundaryLayerDiffusion_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SurfaceContaminantSourceAndSink:Generic:BoundaryLayerDiffusion", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.InternalGains.SurfaceContaminantSourceAndSink_Generic_BoundaryLayerDiffusion> SurfaceContaminantSourceAndSink_Generic_BoundaryLayerDiffusion_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.InternalGains.SurfaceContaminantSourceAndSink_Generic_BoundaryLayerDiffusion> ();
        
        public bool ShouldSerializeSurfaceContaminantSourceAndSink_Generic_DepositionVelocitySink_List()
        {
            return (SurfaceContaminantSourceAndSink_Generic_DepositionVelocitySink_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SurfaceContaminantSourceAndSink:Generic:DepositionVelocitySink", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.InternalGains.SurfaceContaminantSourceAndSink_Generic_DepositionVelocitySink> SurfaceContaminantSourceAndSink_Generic_DepositionVelocitySink_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.InternalGains.SurfaceContaminantSourceAndSink_Generic_DepositionVelocitySink> ();
        
        public bool ShouldSerializeZoneContaminantSourceAndSink_Generic_DepositionRateSink_List()
        {
            return (ZoneContaminantSourceAndSink_Generic_DepositionRateSink_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneContaminantSourceAndSink:Generic:DepositionRateSink", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.InternalGains.ZoneContaminantSourceAndSink_Generic_DepositionRateSink> ZoneContaminantSourceAndSink_Generic_DepositionRateSink_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.InternalGains.ZoneContaminantSourceAndSink_Generic_DepositionRateSink> ();
        

[JsonProperty(PropertyName="Site:Location", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.LocationandClimate.Site_Location Site_Location { get; set; } = null;
        

[JsonProperty(PropertyName="Site:VariableLocation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.LocationandClimate.Site_VariableLocation Site_VariableLocation { get; set; } = null;
        
        public bool ShouldSerializeSizingPeriod_DesignDay_List()
        {
            return (SizingPeriod_DesignDay_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SizingPeriod:DesignDay", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.LocationandClimate.SizingPeriod_DesignDay> SizingPeriod_DesignDay_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.LocationandClimate.SizingPeriod_DesignDay> ();
        
        public bool ShouldSerializeSizingPeriod_WeatherFileDays_List()
        {
            return (SizingPeriod_WeatherFileDays_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SizingPeriod:WeatherFileDays", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.LocationandClimate.SizingPeriod_WeatherFileDays> SizingPeriod_WeatherFileDays_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.LocationandClimate.SizingPeriod_WeatherFileDays> ();
        
        public bool ShouldSerializeSizingPeriod_WeatherFileConditionType_List()
        {
            return (SizingPeriod_WeatherFileConditionType_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SizingPeriod:WeatherFileConditionType", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.LocationandClimate.SizingPeriod_WeatherFileConditionType> SizingPeriod_WeatherFileConditionType_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.LocationandClimate.SizingPeriod_WeatherFileConditionType> ();
        
        public bool ShouldSerializeRunPeriod_List()
        {
            return (RunPeriod_List.Count > 0);
        }
        

[JsonProperty(PropertyName="RunPeriod", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.LocationandClimate.RunPeriod> RunPeriod_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.LocationandClimate.RunPeriod> ();
        
        public bool ShouldSerializeRunPeriodControl_SpecialDays_List()
        {
            return (RunPeriodControl_SpecialDays_List.Count > 0);
        }
        

[JsonProperty(PropertyName="RunPeriodControl:SpecialDays", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.LocationandClimate.RunPeriodControl_SpecialDays> RunPeriodControl_SpecialDays_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.LocationandClimate.RunPeriodControl_SpecialDays> ();
        

[JsonProperty(PropertyName="RunPeriodControl:DaylightSavingTime", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.LocationandClimate.RunPeriodControl_DaylightSavingTime RunPeriodControl_DaylightSavingTime { get; set; } = null;
        
        public bool ShouldSerializeWeatherProperty_SkyTemperature_List()
        {
            return (WeatherProperty_SkyTemperature_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WeatherProperty:SkyTemperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.LocationandClimate.WeatherProperty_SkyTemperature> WeatherProperty_SkyTemperature_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.LocationandClimate.WeatherProperty_SkyTemperature> ();
        

[JsonProperty(PropertyName="Site:WeatherStation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.LocationandClimate.Site_WeatherStation Site_WeatherStation { get; set; } = null;
        

[JsonProperty(PropertyName="Site:HeightVariation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.LocationandClimate.Site_HeightVariation Site_HeightVariation { get; set; } = null;
        

[JsonProperty(PropertyName="Site:GroundTemperature:BuildingSurface", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.LocationandClimate.Site_GroundTemperature_BuildingSurface Site_GroundTemperature_BuildingSurface { get; set; } = null;
        

[JsonProperty(PropertyName="Site:GroundTemperature:FCfactorMethod", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.LocationandClimate.Site_GroundTemperature_FCfactorMethod Site_GroundTemperature_FCfactorMethod { get; set; } = null;
        

[JsonProperty(PropertyName="Site:GroundTemperature:Shallow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.LocationandClimate.Site_GroundTemperature_Shallow Site_GroundTemperature_Shallow { get; set; } = null;
        

[JsonProperty(PropertyName="Site:GroundTemperature:Deep", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.LocationandClimate.Site_GroundTemperature_Deep Site_GroundTemperature_Deep { get; set; } = null;
        
        public bool ShouldSerializeSite_GroundTemperature_Undisturbed_FiniteDifference_List()
        {
            return (Site_GroundTemperature_Undisturbed_FiniteDifference_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Site:GroundTemperature:Undisturbed:FiniteDifference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.LocationandClimate.Site_GroundTemperature_Undisturbed_FiniteDifference> Site_GroundTemperature_Undisturbed_FiniteDifference_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.LocationandClimate.Site_GroundTemperature_Undisturbed_FiniteDifference> ();
        
        public bool ShouldSerializeSite_GroundTemperature_Undisturbed_KusudaAchenbach_List()
        {
            return (Site_GroundTemperature_Undisturbed_KusudaAchenbach_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Site:GroundTemperature:Undisturbed:KusudaAchenbach", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.LocationandClimate.Site_GroundTemperature_Undisturbed_KusudaAchenbach> Site_GroundTemperature_Undisturbed_KusudaAchenbach_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.LocationandClimate.Site_GroundTemperature_Undisturbed_KusudaAchenbach> ();
        
        public bool ShouldSerializeSite_GroundTemperature_Undisturbed_Xing_List()
        {
            return (Site_GroundTemperature_Undisturbed_Xing_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Site:GroundTemperature:Undisturbed:Xing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.LocationandClimate.Site_GroundTemperature_Undisturbed_Xing> Site_GroundTemperature_Undisturbed_Xing_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.LocationandClimate.Site_GroundTemperature_Undisturbed_Xing> ();
        
        public bool ShouldSerializeSite_GroundDomain_Slab_List()
        {
            return (Site_GroundDomain_Slab_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Site:GroundDomain:Slab", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.LocationandClimate.Site_GroundDomain_Slab> Site_GroundDomain_Slab_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.LocationandClimate.Site_GroundDomain_Slab> ();
        
        public bool ShouldSerializeSite_GroundDomain_Basement_List()
        {
            return (Site_GroundDomain_Basement_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Site:GroundDomain:Basement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.LocationandClimate.Site_GroundDomain_Basement> Site_GroundDomain_Basement_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.LocationandClimate.Site_GroundDomain_Basement> ();
        

[JsonProperty(PropertyName="Site:GroundReflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.LocationandClimate.Site_GroundReflectance Site_GroundReflectance { get; set; } = null;
        
        public bool ShouldSerializeSite_GroundReflectance_SnowModifier_List()
        {
            return (Site_GroundReflectance_SnowModifier_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Site:GroundReflectance:SnowModifier", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.LocationandClimate.Site_GroundReflectance_SnowModifier> Site_GroundReflectance_SnowModifier_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.LocationandClimate.Site_GroundReflectance_SnowModifier> ();
        
        public bool ShouldSerializeSite_WaterMainsTemperature_List()
        {
            return (Site_WaterMainsTemperature_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Site:WaterMainsTemperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.LocationandClimate.Site_WaterMainsTemperature> Site_WaterMainsTemperature_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.LocationandClimate.Site_WaterMainsTemperature> ();
        
        public bool ShouldSerializeSite_Precipitation_List()
        {
            return (Site_Precipitation_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Site:Precipitation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.LocationandClimate.Site_Precipitation> Site_Precipitation_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.LocationandClimate.Site_Precipitation> ();
        
        public bool ShouldSerializeRoofIrrigation_List()
        {
            return (RoofIrrigation_List.Count > 0);
        }
        

[JsonProperty(PropertyName="RoofIrrigation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.LocationandClimate.RoofIrrigation> RoofIrrigation_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.LocationandClimate.RoofIrrigation> ();
        

[JsonProperty(PropertyName="Site:SolarAndVisibleSpectrum", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.LocationandClimate.Site_SolarAndVisibleSpectrum Site_SolarAndVisibleSpectrum { get; set; } = null;
        
        public bool ShouldSerializeSite_SpectrumData_List()
        {
            return (Site_SpectrumData_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Site:SpectrumData", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.LocationandClimate.Site_SpectrumData> Site_SpectrumData_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.LocationandClimate.Site_SpectrumData> ();
        
        public bool ShouldSerializeBranch_List()
        {
            return (Branch_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Branch", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.Branch> Branch_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.Branch> ();
        
        public bool ShouldSerializeBranchList_List()
        {
            return (BranchList_List.Count > 0);
        }
        

[JsonProperty(PropertyName="BranchList", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.BranchList> BranchList_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.BranchList> ();
        
        public bool ShouldSerializeConnector_Splitter_List()
        {
            return (Connector_Splitter_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Connector:Splitter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.Connector_Splitter> Connector_Splitter_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.Connector_Splitter> ();
        
        public bool ShouldSerializeConnector_Mixer_List()
        {
            return (Connector_Mixer_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Connector:Mixer", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.Connector_Mixer> Connector_Mixer_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.Connector_Mixer> ();
        
        public bool ShouldSerializeConnectorList_List()
        {
            return (ConnectorList_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ConnectorList", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.ConnectorList> ConnectorList_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.ConnectorList> ();
        
        public bool ShouldSerializeNodeList_List()
        {
            return (NodeList_List.Count > 0);
        }
        

[JsonProperty(PropertyName="NodeList", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.NodeList> NodeList_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.NodeList> ();
        
        public bool ShouldSerializeOutdoorAir_Node_List()
        {
            return (OutdoorAir_Node_List.Count > 0);
        }
        

[JsonProperty(PropertyName="OutdoorAir:Node", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.OutdoorAir_Node> OutdoorAir_Node_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.OutdoorAir_Node> ();
        
        public bool ShouldSerializeOutdoorAir_NodeList_List()
        {
            return (OutdoorAir_NodeList_List.Count > 0);
        }
        

[JsonProperty(PropertyName="OutdoorAir:NodeList", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.OutdoorAir_NodeList> OutdoorAir_NodeList_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.OutdoorAir_NodeList> ();
        
        public bool ShouldSerializePipe_Adiabatic_List()
        {
            return (Pipe_Adiabatic_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Pipe:Adiabatic", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.Pipe_Adiabatic> Pipe_Adiabatic_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.Pipe_Adiabatic> ();
        
        public bool ShouldSerializePipe_Adiabatic_Steam_List()
        {
            return (Pipe_Adiabatic_Steam_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Pipe:Adiabatic:Steam", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.Pipe_Adiabatic_Steam> Pipe_Adiabatic_Steam_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.Pipe_Adiabatic_Steam> ();
        
        public bool ShouldSerializePipe_Indoor_List()
        {
            return (Pipe_Indoor_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Pipe:Indoor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.Pipe_Indoor> Pipe_Indoor_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.Pipe_Indoor> ();
        
        public bool ShouldSerializePipe_Outdoor_List()
        {
            return (Pipe_Outdoor_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Pipe:Outdoor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.Pipe_Outdoor> Pipe_Outdoor_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.Pipe_Outdoor> ();
        
        public bool ShouldSerializePipe_Underground_List()
        {
            return (Pipe_Underground_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Pipe:Underground", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.Pipe_Underground> Pipe_Underground_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.Pipe_Underground> ();
        
        public bool ShouldSerializePipingSystem_Underground_Domain_List()
        {
            return (PipingSystem_Underground_Domain_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PipingSystem:Underground:Domain", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.PipingSystem_Underground_Domain> PipingSystem_Underground_Domain_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.PipingSystem_Underground_Domain> ();
        
        public bool ShouldSerializePipingSystem_Underground_PipeCircuit_List()
        {
            return (PipingSystem_Underground_PipeCircuit_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PipingSystem:Underground:PipeCircuit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.PipingSystem_Underground_PipeCircuit> PipingSystem_Underground_PipeCircuit_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.PipingSystem_Underground_PipeCircuit> ();
        
        public bool ShouldSerializePipingSystem_Underground_PipeSegment_List()
        {
            return (PipingSystem_Underground_PipeSegment_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PipingSystem:Underground:PipeSegment", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.PipingSystem_Underground_PipeSegment> PipingSystem_Underground_PipeSegment_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.PipingSystem_Underground_PipeSegment> ();
        
        public bool ShouldSerializeDuct_List()
        {
            return (Duct_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Duct", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.Duct> Duct_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.NodeBranchManagement.Duct> ();
        
        public bool ShouldSerializeLoadProfile_Plant_List()
        {
            return (LoadProfile_Plant_List.Count > 0);
        }
        

[JsonProperty(PropertyName="LoadProfile:Plant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.NonZoneEquipment.LoadProfile_Plant> LoadProfile_Plant_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.NonZoneEquipment.LoadProfile_Plant> ();
        
        public bool ShouldSerializeFaultModel_TemperatureSensorOffset_OutdoorAir_List()
        {
            return (FaultModel_TemperatureSensorOffset_OutdoorAir_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FaultModel:TemperatureSensorOffset:OutdoorAir", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_TemperatureSensorOffset_OutdoorAir> FaultModel_TemperatureSensorOffset_OutdoorAir_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_TemperatureSensorOffset_OutdoorAir> ();
        
        public bool ShouldSerializeFaultModel_HumiditySensorOffset_OutdoorAir_List()
        {
            return (FaultModel_HumiditySensorOffset_OutdoorAir_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FaultModel:HumiditySensorOffset:OutdoorAir", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_HumiditySensorOffset_OutdoorAir> FaultModel_HumiditySensorOffset_OutdoorAir_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_HumiditySensorOffset_OutdoorAir> ();
        
        public bool ShouldSerializeFaultModel_EnthalpySensorOffset_OutdoorAir_List()
        {
            return (FaultModel_EnthalpySensorOffset_OutdoorAir_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FaultModel:EnthalpySensorOffset:OutdoorAir", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_EnthalpySensorOffset_OutdoorAir> FaultModel_EnthalpySensorOffset_OutdoorAir_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_EnthalpySensorOffset_OutdoorAir> ();
        
        public bool ShouldSerializeFaultModel_TemperatureSensorOffset_ReturnAir_List()
        {
            return (FaultModel_TemperatureSensorOffset_ReturnAir_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FaultModel:TemperatureSensorOffset:ReturnAir", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_TemperatureSensorOffset_ReturnAir> FaultModel_TemperatureSensorOffset_ReturnAir_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_TemperatureSensorOffset_ReturnAir> ();
        
        public bool ShouldSerializeFaultModel_EnthalpySensorOffset_ReturnAir_List()
        {
            return (FaultModel_EnthalpySensorOffset_ReturnAir_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FaultModel:EnthalpySensorOffset:ReturnAir", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_EnthalpySensorOffset_ReturnAir> FaultModel_EnthalpySensorOffset_ReturnAir_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_EnthalpySensorOffset_ReturnAir> ();
        
        public bool ShouldSerializeFaultModel_TemperatureSensorOffset_ChillerSupplyWater_List()
        {
            return (FaultModel_TemperatureSensorOffset_ChillerSupplyWater_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FaultModel:TemperatureSensorOffset:ChillerSupplyWater", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_TemperatureSensorOffset_ChillerSupplyWater> FaultModel_TemperatureSensorOffset_ChillerSupplyWater_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_TemperatureSensorOffset_ChillerSupplyWater> ();
        
        public bool ShouldSerializeFaultModel_TemperatureSensorOffset_CoilSupplyAir_List()
        {
            return (FaultModel_TemperatureSensorOffset_CoilSupplyAir_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FaultModel:TemperatureSensorOffset:CoilSupplyAir", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_TemperatureSensorOffset_CoilSupplyAir> FaultModel_TemperatureSensorOffset_CoilSupplyAir_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_TemperatureSensorOffset_CoilSupplyAir> ();
        
        public bool ShouldSerializeFaultModel_TemperatureSensorOffset_CondenserSupplyWater_List()
        {
            return (FaultModel_TemperatureSensorOffset_CondenserSupplyWater_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FaultModel:TemperatureSensorOffset:CondenserSupplyWater", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_TemperatureSensorOffset_CondenserSupplyWater> FaultModel_TemperatureSensorOffset_CondenserSupplyWater_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_TemperatureSensorOffset_CondenserSupplyWater> ();
        
        public bool ShouldSerializeFaultModel_ThermostatOffset_List()
        {
            return (FaultModel_ThermostatOffset_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FaultModel:ThermostatOffset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_ThermostatOffset> FaultModel_ThermostatOffset_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_ThermostatOffset> ();
        
        public bool ShouldSerializeFaultModel_HumidistatOffset_List()
        {
            return (FaultModel_HumidistatOffset_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FaultModel:HumidistatOffset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_HumidistatOffset> FaultModel_HumidistatOffset_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_HumidistatOffset> ();
        
        public bool ShouldSerializeFaultModel_Fouling_AirFilter_List()
        {
            return (FaultModel_Fouling_AirFilter_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FaultModel:Fouling:AirFilter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_Fouling_AirFilter> FaultModel_Fouling_AirFilter_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_Fouling_AirFilter> ();
        
        public bool ShouldSerializeFaultModel_Fouling_Boiler_List()
        {
            return (FaultModel_Fouling_Boiler_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FaultModel:Fouling:Boiler", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_Fouling_Boiler> FaultModel_Fouling_Boiler_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_Fouling_Boiler> ();
        
        public bool ShouldSerializeFaultModel_Fouling_EvaporativeCooler_List()
        {
            return (FaultModel_Fouling_EvaporativeCooler_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FaultModel:Fouling:EvaporativeCooler", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_Fouling_EvaporativeCooler> FaultModel_Fouling_EvaporativeCooler_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_Fouling_EvaporativeCooler> ();
        
        public bool ShouldSerializeFaultModel_Fouling_Chiller_List()
        {
            return (FaultModel_Fouling_Chiller_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FaultModel:Fouling:Chiller", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_Fouling_Chiller> FaultModel_Fouling_Chiller_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_Fouling_Chiller> ();
        
        public bool ShouldSerializeFaultModel_Fouling_CoolingTower_List()
        {
            return (FaultModel_Fouling_CoolingTower_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FaultModel:Fouling:CoolingTower", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_Fouling_CoolingTower> FaultModel_Fouling_CoolingTower_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_Fouling_CoolingTower> ();
        
        public bool ShouldSerializeFaultModel_Fouling_Coil_List()
        {
            return (FaultModel_Fouling_Coil_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FaultModel:Fouling:Coil", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_Fouling_Coil> FaultModel_Fouling_Coil_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OperationalFaults.FaultModel_Fouling_Coil> ();
        
        public bool ShouldSerializeOutput_VariableDictionary_List()
        {
            return (Output_VariableDictionary_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Output:VariableDictionary", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_VariableDictionary> Output_VariableDictionary_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_VariableDictionary> ();
        
        public bool ShouldSerializeOutput_Surfaces_List_List()
        {
            return (Output_Surfaces_List_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Output:Surfaces:List", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Surfaces_List> Output_Surfaces_List_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Surfaces_List> ();
        
        public bool ShouldSerializeOutput_Surfaces_Drawing_List()
        {
            return (Output_Surfaces_Drawing_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Output:Surfaces:Drawing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Surfaces_Drawing> Output_Surfaces_Drawing_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Surfaces_Drawing> ();
        
        public bool ShouldSerializeOutput_Schedules_List()
        {
            return (Output_Schedules_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Output:Schedules", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Schedules> Output_Schedules_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Schedules> ();
        
        public bool ShouldSerializeOutput_Constructions_List()
        {
            return (Output_Constructions_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Output:Constructions", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Constructions> Output_Constructions_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Constructions> ();
        

[JsonProperty(PropertyName="Output:EnergyManagementSystem", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.OutputReporting.Output_EnergyManagementSystem Output_EnergyManagementSystem { get; set; } = null;
        
        public bool ShouldSerializeOutputControl_SurfaceColorScheme_List()
        {
            return (OutputControl_SurfaceColorScheme_List.Count > 0);
        }
        

[JsonProperty(PropertyName="OutputControl:SurfaceColorScheme", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.OutputControl_SurfaceColorScheme> OutputControl_SurfaceColorScheme_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OutputReporting.OutputControl_SurfaceColorScheme> ();
        

[JsonProperty(PropertyName="Output:Table:SummaryReports", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.OutputReporting.Output_Table_SummaryReports Output_Table_SummaryReports { get; set; } = null;
        
        public bool ShouldSerializeOutput_Table_TimeBins_List()
        {
            return (Output_Table_TimeBins_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Output:Table:TimeBins", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Table_TimeBins> Output_Table_TimeBins_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Table_TimeBins> ();
        
        public bool ShouldSerializeOutput_Table_Monthly_List()
        {
            return (Output_Table_Monthly_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Output:Table:Monthly", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Table_Monthly> Output_Table_Monthly_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Table_Monthly> ();
        
        public bool ShouldSerializeOutput_Table_Annual_List()
        {
            return (Output_Table_Annual_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Output:Table:Annual", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Table_Annual> Output_Table_Annual_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Table_Annual> ();
        

[JsonProperty(PropertyName="OutputControl:Table:Style", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.OutputReporting.OutputControl_Table_Style OutputControl_Table_Style { get; set; } = null;
        

[JsonProperty(PropertyName="OutputControl:ReportingTolerances", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.OutputReporting.OutputControl_ReportingTolerances OutputControl_ReportingTolerances { get; set; } = null;
        
        public bool ShouldSerializeOutput_Variable_List()
        {
            return (Output_Variable_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Output:Variable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Variable> Output_Variable_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Variable> ();
        
        public bool ShouldSerializeOutput_Meter_List()
        {
            return (Output_Meter_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Output:Meter", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Meter> Output_Meter_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Meter> ();
        
        public bool ShouldSerializeOutput_Meter_MeterFileOnly_List()
        {
            return (Output_Meter_MeterFileOnly_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Output:Meter:MeterFileOnly", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Meter_MeterFileOnly> Output_Meter_MeterFileOnly_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Meter_MeterFileOnly> ();
        
        public bool ShouldSerializeOutput_Meter_Cumulative_List()
        {
            return (Output_Meter_Cumulative_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Output:Meter:Cumulative", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Meter_Cumulative> Output_Meter_Cumulative_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Meter_Cumulative> ();
        
        public bool ShouldSerializeOutput_Meter_Cumulative_MeterFileOnly_List()
        {
            return (Output_Meter_Cumulative_MeterFileOnly_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Output:Meter:Cumulative:MeterFileOnly", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Meter_Cumulative_MeterFileOnly> Output_Meter_Cumulative_MeterFileOnly_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_Meter_Cumulative_MeterFileOnly> ();
        
        public bool ShouldSerializeMeter_Custom_List()
        {
            return (Meter_Custom_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Meter:Custom", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.Meter_Custom> Meter_Custom_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OutputReporting.Meter_Custom> ();
        
        public bool ShouldSerializeMeter_CustomDecrement_List()
        {
            return (Meter_CustomDecrement_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Meter:CustomDecrement", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.Meter_CustomDecrement> Meter_CustomDecrement_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OutputReporting.Meter_CustomDecrement> ();
        

[JsonProperty(PropertyName="OutputControl:Files", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.OutputReporting.OutputControl_Files OutputControl_Files { get; set; } = null;
        

[JsonProperty(PropertyName="Output:JSON", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.OutputReporting.Output_JSON Output_JSON { get; set; } = null;
        

[JsonProperty(PropertyName="Output:SQLite", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.OutputReporting.Output_SQLite Output_SQLite { get; set; } = null;
        
        public bool ShouldSerializeOutput_EnvironmentalImpactFactors_List()
        {
            return (Output_EnvironmentalImpactFactors_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Output:EnvironmentalImpactFactors", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_EnvironmentalImpactFactors> Output_EnvironmentalImpactFactors_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_EnvironmentalImpactFactors> ();
        
        public bool ShouldSerializeEnvironmentalImpactFactors_List()
        {
            return (EnvironmentalImpactFactors_List.Count > 0);
        }
        

[JsonProperty(PropertyName="EnvironmentalImpactFactors", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.EnvironmentalImpactFactors> EnvironmentalImpactFactors_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OutputReporting.EnvironmentalImpactFactors> ();
        
        public bool ShouldSerializeFuelFactors_List()
        {
            return (FuelFactors_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FuelFactors", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.FuelFactors> FuelFactors_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OutputReporting.FuelFactors> ();
        

[JsonProperty(PropertyName="Output:Diagnostics", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.OutputReporting.Output_Diagnostics Output_Diagnostics { get; set; } = null;
        

[JsonProperty(PropertyName="Output:DebuggingData", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.OutputReporting.Output_DebuggingData Output_DebuggingData { get; set; } = null;
        
        public bool ShouldSerializeOutput_PreprocessorMessage_List()
        {
            return (Output_PreprocessorMessage_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Output:PreprocessorMessage", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_PreprocessorMessage> Output_PreprocessorMessage_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.OutputReporting.Output_PreprocessorMessage> ();
        
        public bool ShouldSerializeParametric_SetValueForRun_List()
        {
            return (Parametric_SetValueForRun_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Parametric:SetValueForRun", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Parametrics.Parametric_SetValueForRun> Parametric_SetValueForRun_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Parametrics.Parametric_SetValueForRun> ();
        

[JsonProperty(PropertyName="Parametric:Logic", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.Parametrics.Parametric_Logic Parametric_Logic { get; set; } = null;
        

[JsonProperty(PropertyName="Parametric:RunControl", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.Parametrics.Parametric_RunControl Parametric_RunControl { get; set; } = null;
        

[JsonProperty(PropertyName="Parametric:FileNameSuffix", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.Parametrics.Parametric_FileNameSuffix Parametric_FileNameSuffix { get; set; } = null;
        
        public bool ShouldSerializeCurve_Linear_List()
        {
            return (Curve_Linear_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Curve:Linear", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_Linear> Curve_Linear_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_Linear> ();
        
        public bool ShouldSerializeCurve_QuadLinear_List()
        {
            return (Curve_QuadLinear_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Curve:QuadLinear", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_QuadLinear> Curve_QuadLinear_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_QuadLinear> ();
        
        public bool ShouldSerializeCurve_QuintLinear_List()
        {
            return (Curve_QuintLinear_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Curve:QuintLinear", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_QuintLinear> Curve_QuintLinear_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_QuintLinear> ();
        
        public bool ShouldSerializeCurve_Quadratic_List()
        {
            return (Curve_Quadratic_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Curve:Quadratic", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_Quadratic> Curve_Quadratic_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_Quadratic> ();
        
        public bool ShouldSerializeCurve_Cubic_List()
        {
            return (Curve_Cubic_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Curve:Cubic", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_Cubic> Curve_Cubic_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_Cubic> ();
        
        public bool ShouldSerializeCurve_Quartic_List()
        {
            return (Curve_Quartic_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Curve:Quartic", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_Quartic> Curve_Quartic_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_Quartic> ();
        
        public bool ShouldSerializeCurve_Exponent_List()
        {
            return (Curve_Exponent_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Curve:Exponent", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_Exponent> Curve_Exponent_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_Exponent> ();
        
        public bool ShouldSerializeCurve_Bicubic_List()
        {
            return (Curve_Bicubic_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Curve:Bicubic", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_Bicubic> Curve_Bicubic_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_Bicubic> ();
        
        public bool ShouldSerializeCurve_Biquadratic_List()
        {
            return (Curve_Biquadratic_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Curve:Biquadratic", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_Biquadratic> Curve_Biquadratic_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_Biquadratic> ();
        
        public bool ShouldSerializeCurve_QuadraticLinear_List()
        {
            return (Curve_QuadraticLinear_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Curve:QuadraticLinear", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_QuadraticLinear> Curve_QuadraticLinear_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_QuadraticLinear> ();
        
        public bool ShouldSerializeCurve_CubicLinear_List()
        {
            return (Curve_CubicLinear_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Curve:CubicLinear", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_CubicLinear> Curve_CubicLinear_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_CubicLinear> ();
        
        public bool ShouldSerializeCurve_Triquadratic_List()
        {
            return (Curve_Triquadratic_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Curve:Triquadratic", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_Triquadratic> Curve_Triquadratic_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_Triquadratic> ();
        
        public bool ShouldSerializeCurve_Functional_PressureDrop_List()
        {
            return (Curve_Functional_PressureDrop_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Curve:Functional:PressureDrop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_Functional_PressureDrop> Curve_Functional_PressureDrop_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_Functional_PressureDrop> ();
        
        public bool ShouldSerializeCurve_FanPressureRise_List()
        {
            return (Curve_FanPressureRise_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Curve:FanPressureRise", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_FanPressureRise> Curve_FanPressureRise_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_FanPressureRise> ();
        
        public bool ShouldSerializeCurve_ExponentialSkewNormal_List()
        {
            return (Curve_ExponentialSkewNormal_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Curve:ExponentialSkewNormal", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_ExponentialSkewNormal> Curve_ExponentialSkewNormal_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_ExponentialSkewNormal> ();
        
        public bool ShouldSerializeCurve_Sigmoid_List()
        {
            return (Curve_Sigmoid_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Curve:Sigmoid", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_Sigmoid> Curve_Sigmoid_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_Sigmoid> ();
        
        public bool ShouldSerializeCurve_RectangularHyperbola1_List()
        {
            return (Curve_RectangularHyperbola1_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Curve:RectangularHyperbola1", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_RectangularHyperbola1> Curve_RectangularHyperbola1_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_RectangularHyperbola1> ();
        
        public bool ShouldSerializeCurve_RectangularHyperbola2_List()
        {
            return (Curve_RectangularHyperbola2_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Curve:RectangularHyperbola2", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_RectangularHyperbola2> Curve_RectangularHyperbola2_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_RectangularHyperbola2> ();
        
        public bool ShouldSerializeCurve_ExponentialDecay_List()
        {
            return (Curve_ExponentialDecay_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Curve:ExponentialDecay", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_ExponentialDecay> Curve_ExponentialDecay_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_ExponentialDecay> ();
        
        public bool ShouldSerializeCurve_DoubleExponentialDecay_List()
        {
            return (Curve_DoubleExponentialDecay_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Curve:DoubleExponentialDecay", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_DoubleExponentialDecay> Curve_DoubleExponentialDecay_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_DoubleExponentialDecay> ();
        
        public bool ShouldSerializeCurve_ChillerPartLoadWithLift_List()
        {
            return (Curve_ChillerPartLoadWithLift_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Curve:ChillerPartLoadWithLift", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_ChillerPartLoadWithLift> Curve_ChillerPartLoadWithLift_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceCurves.Curve_ChillerPartLoadWithLift> ();
        
        public bool ShouldSerializeTable_IndependentVariable_List()
        {
            return (Table_IndependentVariable_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Table:IndependentVariable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceTables.Table_IndependentVariable> Table_IndependentVariable_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceTables.Table_IndependentVariable> ();
        
        public bool ShouldSerializeTable_IndependentVariableList_List()
        {
            return (Table_IndependentVariableList_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Table:IndependentVariableList", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceTables.Table_IndependentVariableList> Table_IndependentVariableList_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceTables.Table_IndependentVariableList> ();
        
        public bool ShouldSerializeTable_Lookup_List()
        {
            return (Table_Lookup_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Table:Lookup", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PerformanceTables.Table_Lookup> Table_Lookup_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PerformanceTables.Table_Lookup> ();
        
        public bool ShouldSerializeBoiler_HotWater_List()
        {
            return (Boiler_HotWater_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Boiler:HotWater", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.Boiler_HotWater> Boiler_HotWater_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.Boiler_HotWater> ();
        
        public bool ShouldSerializeBoiler_Steam_List()
        {
            return (Boiler_Steam_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Boiler:Steam", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.Boiler_Steam> Boiler_Steam_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.Boiler_Steam> ();
        
        public bool ShouldSerializeChiller_Electric_EIR_List()
        {
            return (Chiller_Electric_EIR_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Chiller:Electric:EIR", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.Chiller_Electric_EIR> Chiller_Electric_EIR_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.Chiller_Electric_EIR> ();
        
        public bool ShouldSerializeChiller_Electric_ReformulatedEIR_List()
        {
            return (Chiller_Electric_ReformulatedEIR_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Chiller:Electric:ReformulatedEIR", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.Chiller_Electric_ReformulatedEIR> Chiller_Electric_ReformulatedEIR_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.Chiller_Electric_ReformulatedEIR> ();
        
        public bool ShouldSerializeChiller_Electric_List()
        {
            return (Chiller_Electric_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Chiller:Electric", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.Chiller_Electric> Chiller_Electric_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.Chiller_Electric> ();
        
        public bool ShouldSerializeChiller_Absorption_Indirect_List()
        {
            return (Chiller_Absorption_Indirect_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Chiller:Absorption:Indirect", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.Chiller_Absorption_Indirect> Chiller_Absorption_Indirect_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.Chiller_Absorption_Indirect> ();
        
        public bool ShouldSerializeChiller_Absorption_List()
        {
            return (Chiller_Absorption_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Chiller:Absorption", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.Chiller_Absorption> Chiller_Absorption_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.Chiller_Absorption> ();
        
        public bool ShouldSerializeChiller_ConstantCOP_List()
        {
            return (Chiller_ConstantCOP_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Chiller:ConstantCOP", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.Chiller_ConstantCOP> Chiller_ConstantCOP_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.Chiller_ConstantCOP> ();
        
        public bool ShouldSerializeChiller_EngineDriven_List()
        {
            return (Chiller_EngineDriven_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Chiller:EngineDriven", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.Chiller_EngineDriven> Chiller_EngineDriven_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.Chiller_EngineDriven> ();
        
        public bool ShouldSerializeChiller_CombustionTurbine_List()
        {
            return (Chiller_CombustionTurbine_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Chiller:CombustionTurbine", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.Chiller_CombustionTurbine> Chiller_CombustionTurbine_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.Chiller_CombustionTurbine> ();
        
        public bool ShouldSerializeChillerHeater_Absorption_DirectFired_List()
        {
            return (ChillerHeater_Absorption_DirectFired_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ChillerHeater:Absorption:DirectFired", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.ChillerHeater_Absorption_DirectFired> ChillerHeater_Absorption_DirectFired_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.ChillerHeater_Absorption_DirectFired> ();
        
        public bool ShouldSerializeChillerHeater_Absorption_DoubleEffect_List()
        {
            return (ChillerHeater_Absorption_DoubleEffect_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ChillerHeater:Absorption:DoubleEffect", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.ChillerHeater_Absorption_DoubleEffect> ChillerHeater_Absorption_DoubleEffect_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.ChillerHeater_Absorption_DoubleEffect> ();
        
        public bool ShouldSerializeHeatPump_PlantLoop_EIR_Cooling_List()
        {
            return (HeatPump_PlantLoop_EIR_Cooling_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HeatPump:PlantLoop:EIR:Cooling", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.HeatPump_PlantLoop_EIR_Cooling> HeatPump_PlantLoop_EIR_Cooling_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.HeatPump_PlantLoop_EIR_Cooling> ();
        
        public bool ShouldSerializeHeatPump_PlantLoop_EIR_Heating_List()
        {
            return (HeatPump_PlantLoop_EIR_Heating_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HeatPump:PlantLoop:EIR:Heating", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.HeatPump_PlantLoop_EIR_Heating> HeatPump_PlantLoop_EIR_Heating_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.HeatPump_PlantLoop_EIR_Heating> ();
        
        public bool ShouldSerializeHeatPump_WaterToWater_EquationFit_Heating_List()
        {
            return (HeatPump_WaterToWater_EquationFit_Heating_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HeatPump:WaterToWater:EquationFit:Heating", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.HeatPump_WaterToWater_EquationFit_Heating> HeatPump_WaterToWater_EquationFit_Heating_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.HeatPump_WaterToWater_EquationFit_Heating> ();
        
        public bool ShouldSerializeHeatPump_WaterToWater_EquationFit_Cooling_List()
        {
            return (HeatPump_WaterToWater_EquationFit_Cooling_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HeatPump:WaterToWater:EquationFit:Cooling", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.HeatPump_WaterToWater_EquationFit_Cooling> HeatPump_WaterToWater_EquationFit_Cooling_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.HeatPump_WaterToWater_EquationFit_Cooling> ();
        
        public bool ShouldSerializeHeatPump_WaterToWater_ParameterEstimation_Cooling_List()
        {
            return (HeatPump_WaterToWater_ParameterEstimation_Cooling_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HeatPump:WaterToWater:ParameterEstimation:Cooling", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.HeatPump_WaterToWater_ParameterEstimation_Cooling> HeatPump_WaterToWater_ParameterEstimation_Cooling_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.HeatPump_WaterToWater_ParameterEstimation_Cooling> ();
        
        public bool ShouldSerializeHeatPump_WaterToWater_ParameterEstimation_Heating_List()
        {
            return (HeatPump_WaterToWater_ParameterEstimation_Heating_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HeatPump:WaterToWater:ParameterEstimation:Heating", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.HeatPump_WaterToWater_ParameterEstimation_Heating> HeatPump_WaterToWater_ParameterEstimation_Heating_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.HeatPump_WaterToWater_ParameterEstimation_Heating> ();
        
        public bool ShouldSerializeDistrictCooling_List()
        {
            return (DistrictCooling_List.Count > 0);
        }
        

[JsonProperty(PropertyName="DistrictCooling", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.DistrictCooling> DistrictCooling_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.DistrictCooling> ();
        
        public bool ShouldSerializeDistrictHeating_List()
        {
            return (DistrictHeating_List.Count > 0);
        }
        

[JsonProperty(PropertyName="DistrictHeating", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.DistrictHeating> DistrictHeating_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.DistrictHeating> ();
        
        public bool ShouldSerializePlantComponent_TemperatureSource_List()
        {
            return (PlantComponent_TemperatureSource_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PlantComponent:TemperatureSource", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.PlantComponent_TemperatureSource> PlantComponent_TemperatureSource_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.PlantComponent_TemperatureSource> ();
        
        public bool ShouldSerializeCentralHeatPumpSystem_List()
        {
            return (CentralHeatPumpSystem_List.Count > 0);
        }
        

[JsonProperty(PropertyName="CentralHeatPumpSystem", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.CentralHeatPumpSystem> CentralHeatPumpSystem_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.CentralHeatPumpSystem> ();
        
        public bool ShouldSerializeChillerHeaterPerformance_Electric_EIR_List()
        {
            return (ChillerHeaterPerformance_Electric_EIR_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ChillerHeaterPerformance:Electric:EIR", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.ChillerHeaterPerformance_Electric_EIR> ChillerHeaterPerformance_Electric_EIR_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantHeatingandCoolingEquipment.ChillerHeaterPerformance_Electric_EIR> ();
        
        public bool ShouldSerializePlantEquipmentList_List()
        {
            return (PlantEquipmentList_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PlantEquipmentList", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentList> PlantEquipmentList_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentList> ();
        
        public bool ShouldSerializeCondenserEquipmentList_List()
        {
            return (CondenserEquipmentList_List.Count > 0);
        }
        

[JsonProperty(PropertyName="CondenserEquipmentList", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.CondenserEquipmentList> CondenserEquipmentList_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.CondenserEquipmentList> ();
        
        public bool ShouldSerializePlantEquipmentOperation_Uncontrolled_List()
        {
            return (PlantEquipmentOperation_Uncontrolled_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PlantEquipmentOperation:Uncontrolled", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_Uncontrolled> PlantEquipmentOperation_Uncontrolled_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_Uncontrolled> ();
        
        public bool ShouldSerializePlantEquipmentOperation_CoolingLoad_List()
        {
            return (PlantEquipmentOperation_CoolingLoad_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PlantEquipmentOperation:CoolingLoad", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_CoolingLoad> PlantEquipmentOperation_CoolingLoad_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_CoolingLoad> ();
        
        public bool ShouldSerializePlantEquipmentOperation_HeatingLoad_List()
        {
            return (PlantEquipmentOperation_HeatingLoad_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PlantEquipmentOperation:HeatingLoad", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_HeatingLoad> PlantEquipmentOperation_HeatingLoad_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_HeatingLoad> ();
        
        public bool ShouldSerializePlantEquipmentOperation_OutdoorDryBulb_List()
        {
            return (PlantEquipmentOperation_OutdoorDryBulb_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PlantEquipmentOperation:OutdoorDryBulb", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_OutdoorDryBulb> PlantEquipmentOperation_OutdoorDryBulb_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_OutdoorDryBulb> ();
        
        public bool ShouldSerializePlantEquipmentOperation_OutdoorWetBulb_List()
        {
            return (PlantEquipmentOperation_OutdoorWetBulb_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PlantEquipmentOperation:OutdoorWetBulb", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_OutdoorWetBulb> PlantEquipmentOperation_OutdoorWetBulb_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_OutdoorWetBulb> ();
        
        public bool ShouldSerializePlantEquipmentOperation_OutdoorRelativeHumidity_List()
        {
            return (PlantEquipmentOperation_OutdoorRelativeHumidity_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PlantEquipmentOperation:OutdoorRelativeHumidity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_OutdoorRelativeHumidity> PlantEquipmentOperation_OutdoorRelativeHumidity_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_OutdoorRelativeHumidity> ();
        
        public bool ShouldSerializePlantEquipmentOperation_OutdoorDewpoint_List()
        {
            return (PlantEquipmentOperation_OutdoorDewpoint_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PlantEquipmentOperation:OutdoorDewpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_OutdoorDewpoint> PlantEquipmentOperation_OutdoorDewpoint_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_OutdoorDewpoint> ();
        
        public bool ShouldSerializePlantEquipmentOperation_ComponentSetpoint_List()
        {
            return (PlantEquipmentOperation_ComponentSetpoint_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PlantEquipmentOperation:ComponentSetpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_ComponentSetpoint> PlantEquipmentOperation_ComponentSetpoint_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_ComponentSetpoint> ();
        
        public bool ShouldSerializePlantEquipmentOperation_ThermalEnergyStorage_List()
        {
            return (PlantEquipmentOperation_ThermalEnergyStorage_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PlantEquipmentOperation:ThermalEnergyStorage", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_ThermalEnergyStorage> PlantEquipmentOperation_ThermalEnergyStorage_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_ThermalEnergyStorage> ();
        
        public bool ShouldSerializePlantEquipmentOperation_OutdoorDryBulbDifference_List()
        {
            return (PlantEquipmentOperation_OutdoorDryBulbDifference_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PlantEquipmentOperation:OutdoorDryBulbDifference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_OutdoorDryBulbDifference> PlantEquipmentOperation_OutdoorDryBulbDifference_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_OutdoorDryBulbDifference> ();
        
        public bool ShouldSerializePlantEquipmentOperation_OutdoorWetBulbDifference_List()
        {
            return (PlantEquipmentOperation_OutdoorWetBulbDifference_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PlantEquipmentOperation:OutdoorWetBulbDifference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_OutdoorWetBulbDifference> PlantEquipmentOperation_OutdoorWetBulbDifference_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_OutdoorWetBulbDifference> ();
        
        public bool ShouldSerializePlantEquipmentOperation_OutdoorDewpointDifference_List()
        {
            return (PlantEquipmentOperation_OutdoorDewpointDifference_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PlantEquipmentOperation:OutdoorDewpointDifference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_OutdoorDewpointDifference> PlantEquipmentOperation_OutdoorDewpointDifference_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperation_OutdoorDewpointDifference> ();
        
        public bool ShouldSerializePlantEquipmentOperationSchemes_List()
        {
            return (PlantEquipmentOperationSchemes_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PlantEquipmentOperationSchemes", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperationSchemes> PlantEquipmentOperationSchemes_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.PlantEquipmentOperationSchemes> ();
        
        public bool ShouldSerializeCondenserEquipmentOperationSchemes_List()
        {
            return (CondenserEquipmentOperationSchemes_List.Count > 0);
        }
        

[JsonProperty(PropertyName="CondenserEquipmentOperationSchemes", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.CondenserEquipmentOperationSchemes> CondenserEquipmentOperationSchemes_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantCondenserControl.CondenserEquipmentOperationSchemes> ();
        
        public bool ShouldSerializeTemperingValve_List()
        {
            return (TemperingValve_List.Count > 0);
        }
        

[JsonProperty(PropertyName="TemperingValve", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantCondenserFlowControl.TemperingValve> TemperingValve_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantCondenserFlowControl.TemperingValve> ();
        
        public bool ShouldSerializePlantLoop_List()
        {
            return (PlantLoop_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PlantLoop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantCondenserLoops.PlantLoop> PlantLoop_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantCondenserLoops.PlantLoop> ();
        
        public bool ShouldSerializeCondenserLoop_List()
        {
            return (CondenserLoop_List.Count > 0);
        }
        

[JsonProperty(PropertyName="CondenserLoop", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PlantCondenserLoops.CondenserLoop> CondenserLoop_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PlantCondenserLoops.CondenserLoop> ();
        
        public bool ShouldSerializePump_VariableSpeed_List()
        {
            return (Pump_VariableSpeed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Pump:VariableSpeed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Pumps.Pump_VariableSpeed> Pump_VariableSpeed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Pumps.Pump_VariableSpeed> ();
        
        public bool ShouldSerializePump_ConstantSpeed_List()
        {
            return (Pump_ConstantSpeed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Pump:ConstantSpeed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Pumps.Pump_ConstantSpeed> Pump_ConstantSpeed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Pumps.Pump_ConstantSpeed> ();
        
        public bool ShouldSerializePump_VariableSpeed_Condensate_List()
        {
            return (Pump_VariableSpeed_Condensate_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Pump:VariableSpeed:Condensate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Pumps.Pump_VariableSpeed_Condensate> Pump_VariableSpeed_Condensate_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Pumps.Pump_VariableSpeed_Condensate> ();
        
        public bool ShouldSerializeHeaderedPumps_ConstantSpeed_List()
        {
            return (HeaderedPumps_ConstantSpeed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HeaderedPumps:ConstantSpeed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Pumps.HeaderedPumps_ConstantSpeed> HeaderedPumps_ConstantSpeed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Pumps.HeaderedPumps_ConstantSpeed> ();
        
        public bool ShouldSerializeHeaderedPumps_VariableSpeed_List()
        {
            return (HeaderedPumps_VariableSpeed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="HeaderedPumps:VariableSpeed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Pumps.HeaderedPumps_VariableSpeed> HeaderedPumps_VariableSpeed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Pumps.HeaderedPumps_VariableSpeed> ();
        

[JsonProperty(PropertyName="PythonPlugin:SearchPaths", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.PythonPluginSystem.PythonPlugin_SearchPaths PythonPlugin_SearchPaths { get; set; } = null;
        
        public bool ShouldSerializePythonPlugin_Instance_List()
        {
            return (PythonPlugin_Instance_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PythonPlugin:Instance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PythonPluginSystem.PythonPlugin_Instance> PythonPlugin_Instance_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PythonPluginSystem.PythonPlugin_Instance> ();
        

[JsonProperty(PropertyName="PythonPlugin:Variables", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.PythonPluginSystem.PythonPlugin_Variables PythonPlugin_Variables { get; set; } = null;
        
        public bool ShouldSerializePythonPlugin_TrendVariable_List()
        {
            return (PythonPlugin_TrendVariable_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PythonPlugin:TrendVariable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PythonPluginSystem.PythonPlugin_TrendVariable> PythonPlugin_TrendVariable_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PythonPluginSystem.PythonPlugin_TrendVariable> ();
        
        public bool ShouldSerializePythonPlugin_OutputVariable_List()
        {
            return (PythonPlugin_OutputVariable_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PythonPlugin:OutputVariable", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.PythonPluginSystem.PythonPlugin_OutputVariable> PythonPlugin_OutputVariable_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.PythonPluginSystem.PythonPlugin_OutputVariable> ();
        
        public bool ShouldSerializeRefrigeration_Case_List()
        {
            return (Refrigeration_Case_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Refrigeration:Case", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_Case> Refrigeration_Case_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_Case> ();
        
        public bool ShouldSerializeRefrigeration_CompressorRack_List()
        {
            return (Refrigeration_CompressorRack_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Refrigeration:CompressorRack", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_CompressorRack> Refrigeration_CompressorRack_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_CompressorRack> ();
        
        public bool ShouldSerializeRefrigeration_CaseAndWalkInList_List()
        {
            return (Refrigeration_CaseAndWalkInList_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Refrigeration:CaseAndWalkInList", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_CaseAndWalkInList> Refrigeration_CaseAndWalkInList_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_CaseAndWalkInList> ();
        
        public bool ShouldSerializeRefrigeration_Condenser_AirCooled_List()
        {
            return (Refrigeration_Condenser_AirCooled_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Refrigeration:Condenser:AirCooled", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_Condenser_AirCooled> Refrigeration_Condenser_AirCooled_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_Condenser_AirCooled> ();
        
        public bool ShouldSerializeRefrigeration_Condenser_EvaporativeCooled_List()
        {
            return (Refrigeration_Condenser_EvaporativeCooled_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Refrigeration:Condenser:EvaporativeCooled", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_Condenser_EvaporativeCooled> Refrigeration_Condenser_EvaporativeCooled_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_Condenser_EvaporativeCooled> ();
        
        public bool ShouldSerializeRefrigeration_Condenser_WaterCooled_List()
        {
            return (Refrigeration_Condenser_WaterCooled_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Refrigeration:Condenser:WaterCooled", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_Condenser_WaterCooled> Refrigeration_Condenser_WaterCooled_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_Condenser_WaterCooled> ();
        
        public bool ShouldSerializeRefrigeration_Condenser_Cascade_List()
        {
            return (Refrigeration_Condenser_Cascade_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Refrigeration:Condenser:Cascade", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_Condenser_Cascade> Refrigeration_Condenser_Cascade_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_Condenser_Cascade> ();
        
        public bool ShouldSerializeRefrigeration_GasCooler_AirCooled_List()
        {
            return (Refrigeration_GasCooler_AirCooled_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Refrigeration:GasCooler:AirCooled", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_GasCooler_AirCooled> Refrigeration_GasCooler_AirCooled_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_GasCooler_AirCooled> ();
        
        public bool ShouldSerializeRefrigeration_TransferLoadList_List()
        {
            return (Refrigeration_TransferLoadList_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Refrigeration:TransferLoadList", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_TransferLoadList> Refrigeration_TransferLoadList_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_TransferLoadList> ();
        
        public bool ShouldSerializeRefrigeration_Subcooler_List()
        {
            return (Refrigeration_Subcooler_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Refrigeration:Subcooler", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_Subcooler> Refrigeration_Subcooler_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_Subcooler> ();
        
        public bool ShouldSerializeRefrigeration_Compressor_List()
        {
            return (Refrigeration_Compressor_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Refrigeration:Compressor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_Compressor> Refrigeration_Compressor_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_Compressor> ();
        
        public bool ShouldSerializeRefrigeration_CompressorList_List()
        {
            return (Refrigeration_CompressorList_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Refrigeration:CompressorList", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_CompressorList> Refrigeration_CompressorList_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_CompressorList> ();
        
        public bool ShouldSerializeRefrigeration_System_List()
        {
            return (Refrigeration_System_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Refrigeration:System", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_System> Refrigeration_System_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_System> ();
        
        public bool ShouldSerializeRefrigeration_TranscriticalSystem_List()
        {
            return (Refrigeration_TranscriticalSystem_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Refrigeration:TranscriticalSystem", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_TranscriticalSystem> Refrigeration_TranscriticalSystem_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_TranscriticalSystem> ();
        
        public bool ShouldSerializeRefrigeration_SecondarySystem_List()
        {
            return (Refrigeration_SecondarySystem_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Refrigeration:SecondarySystem", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_SecondarySystem> Refrigeration_SecondarySystem_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_SecondarySystem> ();
        
        public bool ShouldSerializeRefrigeration_WalkIn_List()
        {
            return (Refrigeration_WalkIn_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Refrigeration:WalkIn", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_WalkIn> Refrigeration_WalkIn_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_WalkIn> ();
        
        public bool ShouldSerializeRefrigeration_AirChiller_List()
        {
            return (Refrigeration_AirChiller_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Refrigeration:AirChiller", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_AirChiller> Refrigeration_AirChiller_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Refrigeration.Refrigeration_AirChiller> ();
        
        public bool ShouldSerializeZoneHVAC_RefrigerationChillerSet_List()
        {
            return (ZoneHVAC_RefrigerationChillerSet_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:RefrigerationChillerSet", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Refrigeration.ZoneHVAC_RefrigerationChillerSet> ZoneHVAC_RefrigerationChillerSet_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Refrigeration.ZoneHVAC_RefrigerationChillerSet> ();
        
        public bool ShouldSerializeRoomAirModelType_List()
        {
            return (RoomAirModelType_List.Count > 0);
        }
        

[JsonProperty(PropertyName="RoomAirModelType", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAirModelType> RoomAirModelType_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAirModelType> ();
        
        public bool ShouldSerializeRoomAir_TemperaturePattern_UserDefined_List()
        {
            return (RoomAir_TemperaturePattern_UserDefined_List.Count > 0);
        }
        

[JsonProperty(PropertyName="RoomAir:TemperaturePattern:UserDefined", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_TemperaturePattern_UserDefined> RoomAir_TemperaturePattern_UserDefined_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_TemperaturePattern_UserDefined> ();
        
        public bool ShouldSerializeRoomAir_TemperaturePattern_ConstantGradient_List()
        {
            return (RoomAir_TemperaturePattern_ConstantGradient_List.Count > 0);
        }
        

[JsonProperty(PropertyName="RoomAir:TemperaturePattern:ConstantGradient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_TemperaturePattern_ConstantGradient> RoomAir_TemperaturePattern_ConstantGradient_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_TemperaturePattern_ConstantGradient> ();
        
        public bool ShouldSerializeRoomAir_TemperaturePattern_TwoGradient_List()
        {
            return (RoomAir_TemperaturePattern_TwoGradient_List.Count > 0);
        }
        

[JsonProperty(PropertyName="RoomAir:TemperaturePattern:TwoGradient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_TemperaturePattern_TwoGradient> RoomAir_TemperaturePattern_TwoGradient_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_TemperaturePattern_TwoGradient> ();
        
        public bool ShouldSerializeRoomAir_TemperaturePattern_NondimensionalHeight_List()
        {
            return (RoomAir_TemperaturePattern_NondimensionalHeight_List.Count > 0);
        }
        

[JsonProperty(PropertyName="RoomAir:TemperaturePattern:NondimensionalHeight", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_TemperaturePattern_NondimensionalHeight> RoomAir_TemperaturePattern_NondimensionalHeight_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_TemperaturePattern_NondimensionalHeight> ();
        
        public bool ShouldSerializeRoomAir_TemperaturePattern_SurfaceMapping_List()
        {
            return (RoomAir_TemperaturePattern_SurfaceMapping_List.Count > 0);
        }
        

[JsonProperty(PropertyName="RoomAir:TemperaturePattern:SurfaceMapping", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_TemperaturePattern_SurfaceMapping> RoomAir_TemperaturePattern_SurfaceMapping_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_TemperaturePattern_SurfaceMapping> ();
        
        public bool ShouldSerializeRoomAir_Node_List()
        {
            return (RoomAir_Node_List.Count > 0);
        }
        

[JsonProperty(PropertyName="RoomAir:Node", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_Node> RoomAir_Node_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_Node> ();
        
        public bool ShouldSerializeRoomAirSettings_OneNodeDisplacementVentilation_List()
        {
            return (RoomAirSettings_OneNodeDisplacementVentilation_List.Count > 0);
        }
        

[JsonProperty(PropertyName="RoomAirSettings:OneNodeDisplacementVentilation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAirSettings_OneNodeDisplacementVentilation> RoomAirSettings_OneNodeDisplacementVentilation_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAirSettings_OneNodeDisplacementVentilation> ();
        
        public bool ShouldSerializeRoomAirSettings_ThreeNodeDisplacementVentilation_List()
        {
            return (RoomAirSettings_ThreeNodeDisplacementVentilation_List.Count > 0);
        }
        

[JsonProperty(PropertyName="RoomAirSettings:ThreeNodeDisplacementVentilation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAirSettings_ThreeNodeDisplacementVentilation> RoomAirSettings_ThreeNodeDisplacementVentilation_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAirSettings_ThreeNodeDisplacementVentilation> ();
        
        public bool ShouldSerializeRoomAirSettings_CrossVentilation_List()
        {
            return (RoomAirSettings_CrossVentilation_List.Count > 0);
        }
        

[JsonProperty(PropertyName="RoomAirSettings:CrossVentilation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAirSettings_CrossVentilation> RoomAirSettings_CrossVentilation_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAirSettings_CrossVentilation> ();
        
        public bool ShouldSerializeRoomAirSettings_UnderFloorAirDistributionInterior_List()
        {
            return (RoomAirSettings_UnderFloorAirDistributionInterior_List.Count > 0);
        }
        

[JsonProperty(PropertyName="RoomAirSettings:UnderFloorAirDistributionInterior", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAirSettings_UnderFloorAirDistributionInterior> RoomAirSettings_UnderFloorAirDistributionInterior_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAirSettings_UnderFloorAirDistributionInterior> ();
        
        public bool ShouldSerializeRoomAirSettings_UnderFloorAirDistributionExterior_List()
        {
            return (RoomAirSettings_UnderFloorAirDistributionExterior_List.Count > 0);
        }
        

[JsonProperty(PropertyName="RoomAirSettings:UnderFloorAirDistributionExterior", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAirSettings_UnderFloorAirDistributionExterior> RoomAirSettings_UnderFloorAirDistributionExterior_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAirSettings_UnderFloorAirDistributionExterior> ();
        
        public bool ShouldSerializeRoomAir_Node_AirflowNetwork_List()
        {
            return (RoomAir_Node_AirflowNetwork_List.Count > 0);
        }
        

[JsonProperty(PropertyName="RoomAir:Node:AirflowNetwork", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_Node_AirflowNetwork> RoomAir_Node_AirflowNetwork_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_Node_AirflowNetwork> ();
        
        public bool ShouldSerializeRoomAir_Node_AirflowNetwork_AdjacentSurfaceList_List()
        {
            return (RoomAir_Node_AirflowNetwork_AdjacentSurfaceList_List.Count > 0);
        }
        

[JsonProperty(PropertyName="RoomAir:Node:AirflowNetwork:AdjacentSurfaceList", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_Node_AirflowNetwork_AdjacentSurfaceList> RoomAir_Node_AirflowNetwork_AdjacentSurfaceList_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_Node_AirflowNetwork_AdjacentSurfaceList> ();
        
        public bool ShouldSerializeRoomAir_Node_AirflowNetwork_InternalGains_List()
        {
            return (RoomAir_Node_AirflowNetwork_InternalGains_List.Count > 0);
        }
        

[JsonProperty(PropertyName="RoomAir:Node:AirflowNetwork:InternalGains", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_Node_AirflowNetwork_InternalGains> RoomAir_Node_AirflowNetwork_InternalGains_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_Node_AirflowNetwork_InternalGains> ();
        
        public bool ShouldSerializeRoomAir_Node_AirflowNetwork_HVACEquipment_List()
        {
            return (RoomAir_Node_AirflowNetwork_HVACEquipment_List.Count > 0);
        }
        

[JsonProperty(PropertyName="RoomAir:Node:AirflowNetwork:HVACEquipment", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_Node_AirflowNetwork_HVACEquipment> RoomAir_Node_AirflowNetwork_HVACEquipment_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAir_Node_AirflowNetwork_HVACEquipment> ();
        
        public bool ShouldSerializeRoomAirSettings_AirflowNetwork_List()
        {
            return (RoomAirSettings_AirflowNetwork_List.Count > 0);
        }
        

[JsonProperty(PropertyName="RoomAirSettings:AirflowNetwork", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAirSettings_AirflowNetwork> RoomAirSettings_AirflowNetwork_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.RoomAirModels.RoomAirSettings_AirflowNetwork> ();
        
        public bool ShouldSerializeScheduleTypeLimits_List()
        {
            return (ScheduleTypeLimits_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ScheduleTypeLimits", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Schedules.ScheduleTypeLimits> ScheduleTypeLimits_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Schedules.ScheduleTypeLimits> ();
        
        public bool ShouldSerializeSchedule_Day_Hourly_List()
        {
            return (Schedule_Day_Hourly_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Schedule:Day:Hourly", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Schedules.Schedule_Day_Hourly> Schedule_Day_Hourly_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Schedules.Schedule_Day_Hourly> ();
        
        public bool ShouldSerializeSchedule_Day_Interval_List()
        {
            return (Schedule_Day_Interval_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Schedule:Day:Interval", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Schedules.Schedule_Day_Interval> Schedule_Day_Interval_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Schedules.Schedule_Day_Interval> ();
        
        public bool ShouldSerializeSchedule_Day_List_List()
        {
            return (Schedule_Day_List_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Schedule:Day:List", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Schedules.Schedule_Day_List> Schedule_Day_List_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Schedules.Schedule_Day_List> ();
        
        public bool ShouldSerializeSchedule_Week_Daily_List()
        {
            return (Schedule_Week_Daily_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Schedule:Week:Daily", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Schedules.Schedule_Week_Daily> Schedule_Week_Daily_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Schedules.Schedule_Week_Daily> ();
        
        public bool ShouldSerializeSchedule_Week_Compact_List()
        {
            return (Schedule_Week_Compact_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Schedule:Week:Compact", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Schedules.Schedule_Week_Compact> Schedule_Week_Compact_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Schedules.Schedule_Week_Compact> ();
        
        public bool ShouldSerializeSchedule_Year_List()
        {
            return (Schedule_Year_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Schedule:Year", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Schedules.Schedule_Year> Schedule_Year_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Schedules.Schedule_Year> ();
        
        public bool ShouldSerializeSchedule_Compact_List()
        {
            return (Schedule_Compact_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Schedule:Compact", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Schedules.Schedule_Compact> Schedule_Compact_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Schedules.Schedule_Compact> ();
        
        public bool ShouldSerializeSchedule_Constant_List()
        {
            return (Schedule_Constant_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Schedule:Constant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Schedules.Schedule_Constant> Schedule_Constant_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Schedules.Schedule_Constant> ();
        

[JsonProperty(PropertyName="Schedule:File:Shading", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.Schedules.Schedule_File_Shading Schedule_File_Shading { get; set; } = null;
        
        public bool ShouldSerializeSchedule_File_List()
        {
            return (Schedule_File_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Schedule:File", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.Schedules.Schedule_File> Schedule_File_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.Schedules.Schedule_File> ();
        
        public bool ShouldSerializeSetpointManager_Scheduled_List()
        {
            return (SetpointManager_Scheduled_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:Scheduled", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_Scheduled> SetpointManager_Scheduled_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_Scheduled> ();
        
        public bool ShouldSerializeSetpointManager_Scheduled_DualSetpoint_List()
        {
            return (SetpointManager_Scheduled_DualSetpoint_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:Scheduled:DualSetpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_Scheduled_DualSetpoint> SetpointManager_Scheduled_DualSetpoint_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_Scheduled_DualSetpoint> ();
        
        public bool ShouldSerializeSetpointManager_OutdoorAirReset_List()
        {
            return (SetpointManager_OutdoorAirReset_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:OutdoorAirReset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_OutdoorAirReset> SetpointManager_OutdoorAirReset_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_OutdoorAirReset> ();
        
        public bool ShouldSerializeSetpointManager_SingleZone_Reheat_List()
        {
            return (SetpointManager_SingleZone_Reheat_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:SingleZone:Reheat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_SingleZone_Reheat> SetpointManager_SingleZone_Reheat_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_SingleZone_Reheat> ();
        
        public bool ShouldSerializeSetpointManager_SingleZone_Heating_List()
        {
            return (SetpointManager_SingleZone_Heating_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:SingleZone:Heating", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_SingleZone_Heating> SetpointManager_SingleZone_Heating_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_SingleZone_Heating> ();
        
        public bool ShouldSerializeSetpointManager_SingleZone_Cooling_List()
        {
            return (SetpointManager_SingleZone_Cooling_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:SingleZone:Cooling", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_SingleZone_Cooling> SetpointManager_SingleZone_Cooling_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_SingleZone_Cooling> ();
        
        public bool ShouldSerializeSetpointManager_SingleZone_Humidity_Minimum_List()
        {
            return (SetpointManager_SingleZone_Humidity_Minimum_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:SingleZone:Humidity:Minimum", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_SingleZone_Humidity_Minimum> SetpointManager_SingleZone_Humidity_Minimum_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_SingleZone_Humidity_Minimum> ();
        
        public bool ShouldSerializeSetpointManager_SingleZone_Humidity_Maximum_List()
        {
            return (SetpointManager_SingleZone_Humidity_Maximum_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:SingleZone:Humidity:Maximum", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_SingleZone_Humidity_Maximum> SetpointManager_SingleZone_Humidity_Maximum_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_SingleZone_Humidity_Maximum> ();
        
        public bool ShouldSerializeSetpointManager_MixedAir_List()
        {
            return (SetpointManager_MixedAir_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:MixedAir", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_MixedAir> SetpointManager_MixedAir_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_MixedAir> ();
        
        public bool ShouldSerializeSetpointManager_OutdoorAirPretreat_List()
        {
            return (SetpointManager_OutdoorAirPretreat_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:OutdoorAirPretreat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_OutdoorAirPretreat> SetpointManager_OutdoorAirPretreat_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_OutdoorAirPretreat> ();
        
        public bool ShouldSerializeSetpointManager_Warmest_List()
        {
            return (SetpointManager_Warmest_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:Warmest", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_Warmest> SetpointManager_Warmest_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_Warmest> ();
        
        public bool ShouldSerializeSetpointManager_Coldest_List()
        {
            return (SetpointManager_Coldest_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:Coldest", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_Coldest> SetpointManager_Coldest_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_Coldest> ();
        
        public bool ShouldSerializeSetpointManager_ReturnAirBypassFlow_List()
        {
            return (SetpointManager_ReturnAirBypassFlow_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:ReturnAirBypassFlow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_ReturnAirBypassFlow> SetpointManager_ReturnAirBypassFlow_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_ReturnAirBypassFlow> ();
        
        public bool ShouldSerializeSetpointManager_WarmestTemperatureFlow_List()
        {
            return (SetpointManager_WarmestTemperatureFlow_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:WarmestTemperatureFlow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_WarmestTemperatureFlow> SetpointManager_WarmestTemperatureFlow_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_WarmestTemperatureFlow> ();
        
        public bool ShouldSerializeSetpointManager_MultiZone_Heating_Average_List()
        {
            return (SetpointManager_MultiZone_Heating_Average_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:MultiZone:Heating:Average", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_MultiZone_Heating_Average> SetpointManager_MultiZone_Heating_Average_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_MultiZone_Heating_Average> ();
        
        public bool ShouldSerializeSetpointManager_MultiZone_Cooling_Average_List()
        {
            return (SetpointManager_MultiZone_Cooling_Average_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:MultiZone:Cooling:Average", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_MultiZone_Cooling_Average> SetpointManager_MultiZone_Cooling_Average_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_MultiZone_Cooling_Average> ();
        
        public bool ShouldSerializeSetpointManager_MultiZone_MinimumHumidity_Average_List()
        {
            return (SetpointManager_MultiZone_MinimumHumidity_Average_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:MultiZone:MinimumHumidity:Average", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_MultiZone_MinimumHumidity_Average> SetpointManager_MultiZone_MinimumHumidity_Average_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_MultiZone_MinimumHumidity_Average> ();
        
        public bool ShouldSerializeSetpointManager_MultiZone_MaximumHumidity_Average_List()
        {
            return (SetpointManager_MultiZone_MaximumHumidity_Average_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:MultiZone:MaximumHumidity:Average", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_MultiZone_MaximumHumidity_Average> SetpointManager_MultiZone_MaximumHumidity_Average_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_MultiZone_MaximumHumidity_Average> ();
        
        public bool ShouldSerializeSetpointManager_MultiZone_Humidity_Minimum_List()
        {
            return (SetpointManager_MultiZone_Humidity_Minimum_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:MultiZone:Humidity:Minimum", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_MultiZone_Humidity_Minimum> SetpointManager_MultiZone_Humidity_Minimum_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_MultiZone_Humidity_Minimum> ();
        
        public bool ShouldSerializeSetpointManager_MultiZone_Humidity_Maximum_List()
        {
            return (SetpointManager_MultiZone_Humidity_Maximum_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:MultiZone:Humidity:Maximum", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_MultiZone_Humidity_Maximum> SetpointManager_MultiZone_Humidity_Maximum_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_MultiZone_Humidity_Maximum> ();
        
        public bool ShouldSerializeSetpointManager_FollowOutdoorAirTemperature_List()
        {
            return (SetpointManager_FollowOutdoorAirTemperature_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:FollowOutdoorAirTemperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_FollowOutdoorAirTemperature> SetpointManager_FollowOutdoorAirTemperature_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_FollowOutdoorAirTemperature> ();
        
        public bool ShouldSerializeSetpointManager_FollowSystemNodeTemperature_List()
        {
            return (SetpointManager_FollowSystemNodeTemperature_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:FollowSystemNodeTemperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_FollowSystemNodeTemperature> SetpointManager_FollowSystemNodeTemperature_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_FollowSystemNodeTemperature> ();
        
        public bool ShouldSerializeSetpointManager_FollowGroundTemperature_List()
        {
            return (SetpointManager_FollowGroundTemperature_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:FollowGroundTemperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_FollowGroundTemperature> SetpointManager_FollowGroundTemperature_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_FollowGroundTemperature> ();
        
        public bool ShouldSerializeSetpointManager_CondenserEnteringReset_List()
        {
            return (SetpointManager_CondenserEnteringReset_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:CondenserEnteringReset", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_CondenserEnteringReset> SetpointManager_CondenserEnteringReset_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_CondenserEnteringReset> ();
        
        public bool ShouldSerializeSetpointManager_CondenserEnteringReset_Ideal_List()
        {
            return (SetpointManager_CondenserEnteringReset_Ideal_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:CondenserEnteringReset:Ideal", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_CondenserEnteringReset_Ideal> SetpointManager_CondenserEnteringReset_Ideal_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_CondenserEnteringReset_Ideal> ();
        
        public bool ShouldSerializeSetpointManager_SingleZone_OneStageCooling_List()
        {
            return (SetpointManager_SingleZone_OneStageCooling_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:SingleZone:OneStageCooling", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_SingleZone_OneStageCooling> SetpointManager_SingleZone_OneStageCooling_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_SingleZone_OneStageCooling> ();
        
        public bool ShouldSerializeSetpointManager_SingleZone_OneStageHeating_List()
        {
            return (SetpointManager_SingleZone_OneStageHeating_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:SingleZone:OneStageHeating", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_SingleZone_OneStageHeating> SetpointManager_SingleZone_OneStageHeating_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_SingleZone_OneStageHeating> ();
        
        public bool ShouldSerializeSetpointManager_ReturnTemperature_ChilledWater_List()
        {
            return (SetpointManager_ReturnTemperature_ChilledWater_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:ReturnTemperature:ChilledWater", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_ReturnTemperature_ChilledWater> SetpointManager_ReturnTemperature_ChilledWater_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_ReturnTemperature_ChilledWater> ();
        
        public bool ShouldSerializeSetpointManager_ReturnTemperature_HotWater_List()
        {
            return (SetpointManager_ReturnTemperature_HotWater_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SetpointManager:ReturnTemperature:HotWater", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_ReturnTemperature_HotWater> SetpointManager_ReturnTemperature_HotWater_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SetpointManagers.SetpointManager_ReturnTemperature_HotWater> ();
        

[JsonProperty(PropertyName="Version", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.SimulationParameters.Version Version { get; set; } = null;
        

[JsonProperty(PropertyName="SimulationControl", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.SimulationParameters.SimulationControl SimulationControl { get; set; } = null;
        

[JsonProperty(PropertyName="PerformancePrecisionTradeoffs", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.SimulationParameters.PerformancePrecisionTradeoffs PerformancePrecisionTradeoffs { get; set; } = null;
        

[JsonProperty(PropertyName="Building", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.SimulationParameters.Building Building { get; set; } = null;
        

[JsonProperty(PropertyName="ShadowCalculation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.SimulationParameters.ShadowCalculation ShadowCalculation { get; set; } = null;
        

[JsonProperty(PropertyName="SurfaceConvectionAlgorithm:Inside", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.SimulationParameters.SurfaceConvectionAlgorithm_Inside SurfaceConvectionAlgorithm_Inside { get; set; } = null;
        

[JsonProperty(PropertyName="SurfaceConvectionAlgorithm:Outside", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.SimulationParameters.SurfaceConvectionAlgorithm_Outside SurfaceConvectionAlgorithm_Outside { get; set; } = null;
        

[JsonProperty(PropertyName="HeatBalanceAlgorithm", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.SimulationParameters.HeatBalanceAlgorithm HeatBalanceAlgorithm { get; set; } = null;
        

[JsonProperty(PropertyName="HeatBalanceSettings:ConductionFiniteDifference", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.SimulationParameters.HeatBalanceSettings_ConductionFiniteDifference HeatBalanceSettings_ConductionFiniteDifference { get; set; } = null;
        

[JsonProperty(PropertyName="ZoneAirHeatBalanceAlgorithm", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.SimulationParameters.ZoneAirHeatBalanceAlgorithm ZoneAirHeatBalanceAlgorithm { get; set; } = null;
        

[JsonProperty(PropertyName="ZoneAirContaminantBalance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.SimulationParameters.ZoneAirContaminantBalance ZoneAirContaminantBalance { get; set; } = null;
        

[JsonProperty(PropertyName="ZoneAirMassFlowConservation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.SimulationParameters.ZoneAirMassFlowConservation ZoneAirMassFlowConservation { get; set; } = null;
        
        public bool ShouldSerializeZoneCapacitanceMultiplier_ResearchSpecial_List()
        {
            return (ZoneCapacitanceMultiplier_ResearchSpecial_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneCapacitanceMultiplier:ResearchSpecial", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SimulationParameters.ZoneCapacitanceMultiplier_ResearchSpecial> ZoneCapacitanceMultiplier_ResearchSpecial_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SimulationParameters.ZoneCapacitanceMultiplier_ResearchSpecial> ();
        

[JsonProperty(PropertyName="Timestep", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.SimulationParameters.Timestep Timestep { get; set; } = null;
        

[JsonProperty(PropertyName="ConvergenceLimits", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.SimulationParameters.ConvergenceLimits ConvergenceLimits { get; set; } = null;
        

[JsonProperty(PropertyName="HVACSystemRootFindingAlgorithm", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.SimulationParameters.HVACSystemRootFindingAlgorithm HVACSystemRootFindingAlgorithm { get; set; } = null;
        
        public bool ShouldSerializeSolarCollectorPerformance_FlatPlate_List()
        {
            return (SolarCollectorPerformance_FlatPlate_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SolarCollectorPerformance:FlatPlate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SolarCollectors.SolarCollectorPerformance_FlatPlate> SolarCollectorPerformance_FlatPlate_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SolarCollectors.SolarCollectorPerformance_FlatPlate> ();
        
        public bool ShouldSerializeSolarCollector_FlatPlate_Water_List()
        {
            return (SolarCollector_FlatPlate_Water_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SolarCollector:FlatPlate:Water", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SolarCollectors.SolarCollector_FlatPlate_Water> SolarCollector_FlatPlate_Water_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SolarCollectors.SolarCollector_FlatPlate_Water> ();
        
        public bool ShouldSerializeSolarCollector_FlatPlate_PhotovoltaicThermal_List()
        {
            return (SolarCollector_FlatPlate_PhotovoltaicThermal_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SolarCollector:FlatPlate:PhotovoltaicThermal", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SolarCollectors.SolarCollector_FlatPlate_PhotovoltaicThermal> SolarCollector_FlatPlate_PhotovoltaicThermal_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SolarCollectors.SolarCollector_FlatPlate_PhotovoltaicThermal> ();
        
        public bool ShouldSerializeSolarCollectorPerformance_PhotovoltaicThermal_Simple_List()
        {
            return (SolarCollectorPerformance_PhotovoltaicThermal_Simple_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SolarCollectorPerformance:PhotovoltaicThermal:Simple", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SolarCollectors.SolarCollectorPerformance_PhotovoltaicThermal_Simple> SolarCollectorPerformance_PhotovoltaicThermal_Simple_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SolarCollectors.SolarCollectorPerformance_PhotovoltaicThermal_Simple> ();
        
        public bool ShouldSerializeSolarCollector_IntegralCollectorStorage_List()
        {
            return (SolarCollector_IntegralCollectorStorage_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SolarCollector:IntegralCollectorStorage", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SolarCollectors.SolarCollector_IntegralCollectorStorage> SolarCollector_IntegralCollectorStorage_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SolarCollectors.SolarCollector_IntegralCollectorStorage> ();
        
        public bool ShouldSerializeSolarCollectorPerformance_IntegralCollectorStorage_List()
        {
            return (SolarCollectorPerformance_IntegralCollectorStorage_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SolarCollectorPerformance:IntegralCollectorStorage", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SolarCollectors.SolarCollectorPerformance_IntegralCollectorStorage> SolarCollectorPerformance_IntegralCollectorStorage_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SolarCollectors.SolarCollectorPerformance_IntegralCollectorStorage> ();
        
        public bool ShouldSerializeSolarCollector_UnglazedTranspired_List()
        {
            return (SolarCollector_UnglazedTranspired_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SolarCollector:UnglazedTranspired", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SolarCollectors.SolarCollector_UnglazedTranspired> SolarCollector_UnglazedTranspired_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SolarCollectors.SolarCollector_UnglazedTranspired> ();
        
        public bool ShouldSerializeSolarCollector_UnglazedTranspired_Multisystem_List()
        {
            return (SolarCollector_UnglazedTranspired_Multisystem_List.Count > 0);
        }
        

[JsonProperty(PropertyName="SolarCollector:UnglazedTranspired:Multisystem", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SolarCollectors.SolarCollector_UnglazedTranspired_Multisystem> SolarCollector_UnglazedTranspired_Multisystem_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SolarCollectors.SolarCollector_UnglazedTranspired_Multisystem> ();
        
        public bool ShouldSerializeMaterial_List()
        {
            return (Material_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Material", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Material> Material_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Material> ();
        
        public bool ShouldSerializeMaterial_NoMass_List()
        {
            return (Material_NoMass_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Material:NoMass", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Material_NoMass> Material_NoMass_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Material_NoMass> ();
        
        public bool ShouldSerializeMaterial_InfraredTransparent_List()
        {
            return (Material_InfraredTransparent_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Material:InfraredTransparent", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Material_InfraredTransparent> Material_InfraredTransparent_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Material_InfraredTransparent> ();
        
        public bool ShouldSerializeMaterial_AirGap_List()
        {
            return (Material_AirGap_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Material:AirGap", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Material_AirGap> Material_AirGap_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Material_AirGap> ();
        
        public bool ShouldSerializeMaterial_RoofVegetation_List()
        {
            return (Material_RoofVegetation_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Material:RoofVegetation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Material_RoofVegetation> Material_RoofVegetation_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Material_RoofVegetation> ();
        
        public bool ShouldSerializeWindowMaterial_SimpleGlazingSystem_List()
        {
            return (WindowMaterial_SimpleGlazingSystem_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowMaterial:SimpleGlazingSystem", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_SimpleGlazingSystem> WindowMaterial_SimpleGlazingSystem_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_SimpleGlazingSystem> ();
        
        public bool ShouldSerializeWindowMaterial_Glazing_List()
        {
            return (WindowMaterial_Glazing_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowMaterial:Glazing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Glazing> WindowMaterial_Glazing_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Glazing> ();
        
        public bool ShouldSerializeWindowMaterial_GlazingGroup_Thermochromic_List()
        {
            return (WindowMaterial_GlazingGroup_Thermochromic_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowMaterial:GlazingGroup:Thermochromic", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_GlazingGroup_Thermochromic> WindowMaterial_GlazingGroup_Thermochromic_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_GlazingGroup_Thermochromic> ();
        
        public bool ShouldSerializeWindowMaterial_Glazing_RefractionExtinctionMethod_List()
        {
            return (WindowMaterial_Glazing_RefractionExtinctionMethod_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowMaterial:Glazing:RefractionExtinctionMethod", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Glazing_RefractionExtinctionMethod> WindowMaterial_Glazing_RefractionExtinctionMethod_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Glazing_RefractionExtinctionMethod> ();
        
        public bool ShouldSerializeWindowMaterial_Gas_List()
        {
            return (WindowMaterial_Gas_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowMaterial:Gas", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Gas> WindowMaterial_Gas_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Gas> ();
        
        public bool ShouldSerializeWindowGap_SupportPillar_List()
        {
            return (WindowGap_SupportPillar_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowGap:SupportPillar", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowGap_SupportPillar> WindowGap_SupportPillar_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowGap_SupportPillar> ();
        
        public bool ShouldSerializeWindowGap_DeflectionState_List()
        {
            return (WindowGap_DeflectionState_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowGap:DeflectionState", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowGap_DeflectionState> WindowGap_DeflectionState_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowGap_DeflectionState> ();
        
        public bool ShouldSerializeWindowMaterial_GasMixture_List()
        {
            return (WindowMaterial_GasMixture_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowMaterial:GasMixture", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_GasMixture> WindowMaterial_GasMixture_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_GasMixture> ();
        
        public bool ShouldSerializeWindowMaterial_Gap_List()
        {
            return (WindowMaterial_Gap_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowMaterial:Gap", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Gap> WindowMaterial_Gap_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Gap> ();
        
        public bool ShouldSerializeWindowMaterial_Shade_List()
        {
            return (WindowMaterial_Shade_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowMaterial:Shade", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Shade> WindowMaterial_Shade_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Shade> ();
        
        public bool ShouldSerializeWindowMaterial_ComplexShade_List()
        {
            return (WindowMaterial_ComplexShade_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowMaterial:ComplexShade", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_ComplexShade> WindowMaterial_ComplexShade_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_ComplexShade> ();
        
        public bool ShouldSerializeWindowMaterial_Blind_List()
        {
            return (WindowMaterial_Blind_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowMaterial:Blind", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Blind> WindowMaterial_Blind_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Blind> ();
        
        public bool ShouldSerializeWindowMaterial_Screen_List()
        {
            return (WindowMaterial_Screen_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowMaterial:Screen", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Screen> WindowMaterial_Screen_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Screen> ();
        
        public bool ShouldSerializeWindowMaterial_Shade_EquivalentLayer_List()
        {
            return (WindowMaterial_Shade_EquivalentLayer_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowMaterial:Shade:EquivalentLayer", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Shade_EquivalentLayer> WindowMaterial_Shade_EquivalentLayer_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Shade_EquivalentLayer> ();
        
        public bool ShouldSerializeWindowMaterial_Drape_EquivalentLayer_List()
        {
            return (WindowMaterial_Drape_EquivalentLayer_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowMaterial:Drape:EquivalentLayer", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Drape_EquivalentLayer> WindowMaterial_Drape_EquivalentLayer_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Drape_EquivalentLayer> ();
        
        public bool ShouldSerializeWindowMaterial_Blind_EquivalentLayer_List()
        {
            return (WindowMaterial_Blind_EquivalentLayer_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowMaterial:Blind:EquivalentLayer", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Blind_EquivalentLayer> WindowMaterial_Blind_EquivalentLayer_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Blind_EquivalentLayer> ();
        
        public bool ShouldSerializeWindowMaterial_Screen_EquivalentLayer_List()
        {
            return (WindowMaterial_Screen_EquivalentLayer_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowMaterial:Screen:EquivalentLayer", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Screen_EquivalentLayer> WindowMaterial_Screen_EquivalentLayer_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Screen_EquivalentLayer> ();
        
        public bool ShouldSerializeWindowMaterial_Glazing_EquivalentLayer_List()
        {
            return (WindowMaterial_Glazing_EquivalentLayer_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowMaterial:Glazing:EquivalentLayer", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Glazing_EquivalentLayer> WindowMaterial_Glazing_EquivalentLayer_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Glazing_EquivalentLayer> ();
        
        public bool ShouldSerializeWindowMaterial_Gap_EquivalentLayer_List()
        {
            return (WindowMaterial_Gap_EquivalentLayer_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowMaterial:Gap:EquivalentLayer", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Gap_EquivalentLayer> WindowMaterial_Gap_EquivalentLayer_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowMaterial_Gap_EquivalentLayer> ();
        
        public bool ShouldSerializeMaterialProperty_MoisturePenetrationDepth_Settings_List()
        {
            return (MaterialProperty_MoisturePenetrationDepth_Settings_List.Count > 0);
        }
        

[JsonProperty(PropertyName="MaterialProperty:MoisturePenetrationDepth:Settings", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.MaterialProperty_MoisturePenetrationDepth_Settings> MaterialProperty_MoisturePenetrationDepth_Settings_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.MaterialProperty_MoisturePenetrationDepth_Settings> ();
        
        public bool ShouldSerializeMaterialProperty_PhaseChange_List()
        {
            return (MaterialProperty_PhaseChange_List.Count > 0);
        }
        

[JsonProperty(PropertyName="MaterialProperty:PhaseChange", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.MaterialProperty_PhaseChange> MaterialProperty_PhaseChange_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.MaterialProperty_PhaseChange> ();
        
        public bool ShouldSerializeMaterialProperty_PhaseChangeHysteresis_List()
        {
            return (MaterialProperty_PhaseChangeHysteresis_List.Count > 0);
        }
        

[JsonProperty(PropertyName="MaterialProperty:PhaseChangeHysteresis", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.MaterialProperty_PhaseChangeHysteresis> MaterialProperty_PhaseChangeHysteresis_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.MaterialProperty_PhaseChangeHysteresis> ();
        
        public bool ShouldSerializeMaterialProperty_VariableThermalConductivity_List()
        {
            return (MaterialProperty_VariableThermalConductivity_List.Count > 0);
        }
        

[JsonProperty(PropertyName="MaterialProperty:VariableThermalConductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.MaterialProperty_VariableThermalConductivity> MaterialProperty_VariableThermalConductivity_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.MaterialProperty_VariableThermalConductivity> ();
        
        public bool ShouldSerializeMaterialProperty_HeatAndMoistureTransfer_Settings_List()
        {
            return (MaterialProperty_HeatAndMoistureTransfer_Settings_List.Count > 0);
        }
        

[JsonProperty(PropertyName="MaterialProperty:HeatAndMoistureTransfer:Settings", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.MaterialProperty_HeatAndMoistureTransfer_Settings> MaterialProperty_HeatAndMoistureTransfer_Settings_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.MaterialProperty_HeatAndMoistureTransfer_Settings> ();
        
        public bool ShouldSerializeMaterialProperty_HeatAndMoistureTransfer_SorptionIsotherm_List()
        {
            return (MaterialProperty_HeatAndMoistureTransfer_SorptionIsotherm_List.Count > 0);
        }
        

[JsonProperty(PropertyName="MaterialProperty:HeatAndMoistureTransfer:SorptionIsotherm", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.MaterialProperty_HeatAndMoistureTransfer_SorptionIsotherm> MaterialProperty_HeatAndMoistureTransfer_SorptionIsotherm_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.MaterialProperty_HeatAndMoistureTransfer_SorptionIsotherm> ();
        
        public bool ShouldSerializeMaterialProperty_HeatAndMoistureTransfer_Suction_List()
        {
            return (MaterialProperty_HeatAndMoistureTransfer_Suction_List.Count > 0);
        }
        

[JsonProperty(PropertyName="MaterialProperty:HeatAndMoistureTransfer:Suction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.MaterialProperty_HeatAndMoistureTransfer_Suction> MaterialProperty_HeatAndMoistureTransfer_Suction_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.MaterialProperty_HeatAndMoistureTransfer_Suction> ();
        
        public bool ShouldSerializeMaterialProperty_HeatAndMoistureTransfer_Redistribution_List()
        {
            return (MaterialProperty_HeatAndMoistureTransfer_Redistribution_List.Count > 0);
        }
        

[JsonProperty(PropertyName="MaterialProperty:HeatAndMoistureTransfer:Redistribution", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.MaterialProperty_HeatAndMoistureTransfer_Redistribution> MaterialProperty_HeatAndMoistureTransfer_Redistribution_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.MaterialProperty_HeatAndMoistureTransfer_Redistribution> ();
        
        public bool ShouldSerializeMaterialProperty_HeatAndMoistureTransfer_Diffusion_List()
        {
            return (MaterialProperty_HeatAndMoistureTransfer_Diffusion_List.Count > 0);
        }
        

[JsonProperty(PropertyName="MaterialProperty:HeatAndMoistureTransfer:Diffusion", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.MaterialProperty_HeatAndMoistureTransfer_Diffusion> MaterialProperty_HeatAndMoistureTransfer_Diffusion_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.MaterialProperty_HeatAndMoistureTransfer_Diffusion> ();
        
        public bool ShouldSerializeMaterialProperty_HeatAndMoistureTransfer_ThermalConductivity_List()
        {
            return (MaterialProperty_HeatAndMoistureTransfer_ThermalConductivity_List.Count > 0);
        }
        

[JsonProperty(PropertyName="MaterialProperty:HeatAndMoistureTransfer:ThermalConductivity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.MaterialProperty_HeatAndMoistureTransfer_ThermalConductivity> MaterialProperty_HeatAndMoistureTransfer_ThermalConductivity_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.MaterialProperty_HeatAndMoistureTransfer_ThermalConductivity> ();
        
        public bool ShouldSerializeMaterialProperty_GlazingSpectralData_List()
        {
            return (MaterialProperty_GlazingSpectralData_List.Count > 0);
        }
        

[JsonProperty(PropertyName="MaterialProperty:GlazingSpectralData", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.MaterialProperty_GlazingSpectralData> MaterialProperty_GlazingSpectralData_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.MaterialProperty_GlazingSpectralData> ();
        
        public bool ShouldSerializeConstruction_List()
        {
            return (Construction_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Construction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Construction> Construction_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Construction> ();
        
        public bool ShouldSerializeConstruction_CfactorUndergroundWall_List()
        {
            return (Construction_CfactorUndergroundWall_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Construction:CfactorUndergroundWall", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Construction_CfactorUndergroundWall> Construction_CfactorUndergroundWall_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Construction_CfactorUndergroundWall> ();
        
        public bool ShouldSerializeConstruction_FfactorGroundFloor_List()
        {
            return (Construction_FfactorGroundFloor_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Construction:FfactorGroundFloor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Construction_FfactorGroundFloor> Construction_FfactorGroundFloor_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Construction_FfactorGroundFloor> ();
        
        public bool ShouldSerializeConstructionProperty_InternalHeatSource_List()
        {
            return (ConstructionProperty_InternalHeatSource_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ConstructionProperty:InternalHeatSource", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.ConstructionProperty_InternalHeatSource> ConstructionProperty_InternalHeatSource_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.ConstructionProperty_InternalHeatSource> ();
        
        public bool ShouldSerializeConstruction_AirBoundary_List()
        {
            return (Construction_AirBoundary_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Construction:AirBoundary", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Construction_AirBoundary> Construction_AirBoundary_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Construction_AirBoundary> ();
        
        public bool ShouldSerializeWindowThermalModel_Params_List()
        {
            return (WindowThermalModel_Params_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowThermalModel:Params", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowThermalModel_Params> WindowThermalModel_Params_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowThermalModel_Params> ();
        
        public bool ShouldSerializeWindowsCalculationEngine_List()
        {
            return (WindowsCalculationEngine_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowsCalculationEngine", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowsCalculationEngine> WindowsCalculationEngine_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.WindowsCalculationEngine> ();
        
        public bool ShouldSerializeConstruction_ComplexFenestrationState_List()
        {
            return (Construction_ComplexFenestrationState_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Construction:ComplexFenestrationState", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Construction_ComplexFenestrationState> Construction_ComplexFenestrationState_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Construction_ComplexFenestrationState> ();
        
        public bool ShouldSerializeConstruction_WindowEquivalentLayer_List()
        {
            return (Construction_WindowEquivalentLayer_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Construction:WindowEquivalentLayer", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Construction_WindowEquivalentLayer> Construction_WindowEquivalentLayer_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Construction_WindowEquivalentLayer> ();
        
        public bool ShouldSerializeConstruction_WindowDataFile_List()
        {
            return (Construction_WindowDataFile_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Construction:WindowDataFile", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Construction_WindowDataFile> Construction_WindowDataFile_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SurfaceConstructionElements.Construction_WindowDataFile> ();
        
        public bool ShouldSerializeAvailabilityManager_Scheduled_List()
        {
            return (AvailabilityManager_Scheduled_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AvailabilityManager:Scheduled", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_Scheduled> AvailabilityManager_Scheduled_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_Scheduled> ();
        
        public bool ShouldSerializeAvailabilityManager_ScheduledOn_List()
        {
            return (AvailabilityManager_ScheduledOn_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AvailabilityManager:ScheduledOn", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_ScheduledOn> AvailabilityManager_ScheduledOn_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_ScheduledOn> ();
        
        public bool ShouldSerializeAvailabilityManager_ScheduledOff_List()
        {
            return (AvailabilityManager_ScheduledOff_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AvailabilityManager:ScheduledOff", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_ScheduledOff> AvailabilityManager_ScheduledOff_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_ScheduledOff> ();
        
        public bool ShouldSerializeAvailabilityManager_OptimumStart_List()
        {
            return (AvailabilityManager_OptimumStart_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AvailabilityManager:OptimumStart", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_OptimumStart> AvailabilityManager_OptimumStart_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_OptimumStart> ();
        
        public bool ShouldSerializeAvailabilityManager_NightCycle_List()
        {
            return (AvailabilityManager_NightCycle_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AvailabilityManager:NightCycle", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_NightCycle> AvailabilityManager_NightCycle_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_NightCycle> ();
        
        public bool ShouldSerializeAvailabilityManager_DifferentialThermostat_List()
        {
            return (AvailabilityManager_DifferentialThermostat_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AvailabilityManager:DifferentialThermostat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_DifferentialThermostat> AvailabilityManager_DifferentialThermostat_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_DifferentialThermostat> ();
        
        public bool ShouldSerializeAvailabilityManager_HighTemperatureTurnOff_List()
        {
            return (AvailabilityManager_HighTemperatureTurnOff_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AvailabilityManager:HighTemperatureTurnOff", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_HighTemperatureTurnOff> AvailabilityManager_HighTemperatureTurnOff_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_HighTemperatureTurnOff> ();
        
        public bool ShouldSerializeAvailabilityManager_HighTemperatureTurnOn_List()
        {
            return (AvailabilityManager_HighTemperatureTurnOn_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AvailabilityManager:HighTemperatureTurnOn", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_HighTemperatureTurnOn> AvailabilityManager_HighTemperatureTurnOn_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_HighTemperatureTurnOn> ();
        
        public bool ShouldSerializeAvailabilityManager_LowTemperatureTurnOff_List()
        {
            return (AvailabilityManager_LowTemperatureTurnOff_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AvailabilityManager:LowTemperatureTurnOff", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_LowTemperatureTurnOff> AvailabilityManager_LowTemperatureTurnOff_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_LowTemperatureTurnOff> ();
        
        public bool ShouldSerializeAvailabilityManager_LowTemperatureTurnOn_List()
        {
            return (AvailabilityManager_LowTemperatureTurnOn_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AvailabilityManager:LowTemperatureTurnOn", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_LowTemperatureTurnOn> AvailabilityManager_LowTemperatureTurnOn_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_LowTemperatureTurnOn> ();
        
        public bool ShouldSerializeAvailabilityManager_NightVentilation_List()
        {
            return (AvailabilityManager_NightVentilation_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AvailabilityManager:NightVentilation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_NightVentilation> AvailabilityManager_NightVentilation_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_NightVentilation> ();
        
        public bool ShouldSerializeAvailabilityManager_HybridVentilation_List()
        {
            return (AvailabilityManager_HybridVentilation_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AvailabilityManager:HybridVentilation", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_HybridVentilation> AvailabilityManager_HybridVentilation_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManager_HybridVentilation> ();
        
        public bool ShouldSerializeAvailabilityManagerAssignmentList_List()
        {
            return (AvailabilityManagerAssignmentList_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AvailabilityManagerAssignmentList", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManagerAssignmentList> AvailabilityManagerAssignmentList_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.SystemAvailabilityManagers.AvailabilityManagerAssignmentList> ();
        

[JsonProperty(PropertyName="GlobalGeometryRules", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.ThermalZonesandSurfaces.GlobalGeometryRules GlobalGeometryRules { get; set; } = null;
        

[JsonProperty(PropertyName="GeometryTransform", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public EnergyPlus.ThermalZonesandSurfaces.GeometryTransform GeometryTransform { get; set; } = null;
        
        public bool ShouldSerializeZone_List()
        {
            return (Zone_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Zone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Zone> Zone_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Zone> ();
        
        public bool ShouldSerializeZoneList_List()
        {
            return (ZoneList_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneList", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.ZoneList> ZoneList_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.ZoneList> ();
        
        public bool ShouldSerializeZoneGroup_List()
        {
            return (ZoneGroup_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneGroup", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.ZoneGroup> ZoneGroup_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.ZoneGroup> ();
        
        public bool ShouldSerializeBuildingSurface_Detailed_List()
        {
            return (BuildingSurface_Detailed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="BuildingSurface:Detailed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.BuildingSurface_Detailed> BuildingSurface_Detailed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.BuildingSurface_Detailed> ();
        
        public bool ShouldSerializeWall_Detailed_List()
        {
            return (Wall_Detailed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Wall:Detailed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Wall_Detailed> Wall_Detailed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Wall_Detailed> ();
        
        public bool ShouldSerializeRoofCeiling_Detailed_List()
        {
            return (RoofCeiling_Detailed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="RoofCeiling:Detailed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.RoofCeiling_Detailed> RoofCeiling_Detailed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.RoofCeiling_Detailed> ();
        
        public bool ShouldSerializeFloor_Detailed_List()
        {
            return (Floor_Detailed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Floor:Detailed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Floor_Detailed> Floor_Detailed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Floor_Detailed> ();
        
        public bool ShouldSerializeWall_Exterior_List()
        {
            return (Wall_Exterior_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Wall:Exterior", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Wall_Exterior> Wall_Exterior_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Wall_Exterior> ();
        
        public bool ShouldSerializeWall_Adiabatic_List()
        {
            return (Wall_Adiabatic_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Wall:Adiabatic", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Wall_Adiabatic> Wall_Adiabatic_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Wall_Adiabatic> ();
        
        public bool ShouldSerializeWall_Underground_List()
        {
            return (Wall_Underground_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Wall:Underground", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Wall_Underground> Wall_Underground_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Wall_Underground> ();
        
        public bool ShouldSerializeWall_Interzone_List()
        {
            return (Wall_Interzone_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Wall:Interzone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Wall_Interzone> Wall_Interzone_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Wall_Interzone> ();
        
        public bool ShouldSerializeRoof_List()
        {
            return (Roof_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Roof", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Roof> Roof_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Roof> ();
        
        public bool ShouldSerializeCeiling_Adiabatic_List()
        {
            return (Ceiling_Adiabatic_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Ceiling:Adiabatic", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Ceiling_Adiabatic> Ceiling_Adiabatic_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Ceiling_Adiabatic> ();
        
        public bool ShouldSerializeCeiling_Interzone_List()
        {
            return (Ceiling_Interzone_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Ceiling:Interzone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Ceiling_Interzone> Ceiling_Interzone_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Ceiling_Interzone> ();
        
        public bool ShouldSerializeFloor_GroundContact_List()
        {
            return (Floor_GroundContact_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Floor:GroundContact", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Floor_GroundContact> Floor_GroundContact_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Floor_GroundContact> ();
        
        public bool ShouldSerializeFloor_Adiabatic_List()
        {
            return (Floor_Adiabatic_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Floor:Adiabatic", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Floor_Adiabatic> Floor_Adiabatic_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Floor_Adiabatic> ();
        
        public bool ShouldSerializeFloor_Interzone_List()
        {
            return (Floor_Interzone_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Floor:Interzone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Floor_Interzone> Floor_Interzone_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Floor_Interzone> ();
        
        public bool ShouldSerializeFenestrationSurface_Detailed_List()
        {
            return (FenestrationSurface_Detailed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="FenestrationSurface:Detailed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.FenestrationSurface_Detailed> FenestrationSurface_Detailed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.FenestrationSurface_Detailed> ();
        
        public bool ShouldSerializeWindow_List()
        {
            return (Window_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Window", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Window> Window_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Window> ();
        
        public bool ShouldSerializeDoor_List()
        {
            return (Door_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Door", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Door> Door_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Door> ();
        
        public bool ShouldSerializeGlazedDoor_List()
        {
            return (GlazedDoor_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GlazedDoor", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.GlazedDoor> GlazedDoor_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.GlazedDoor> ();
        
        public bool ShouldSerializeWindow_Interzone_List()
        {
            return (Window_Interzone_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Window:Interzone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Window_Interzone> Window_Interzone_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Window_Interzone> ();
        
        public bool ShouldSerializeDoor_Interzone_List()
        {
            return (Door_Interzone_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Door:Interzone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Door_Interzone> Door_Interzone_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Door_Interzone> ();
        
        public bool ShouldSerializeGlazedDoor_Interzone_List()
        {
            return (GlazedDoor_Interzone_List.Count > 0);
        }
        

[JsonProperty(PropertyName="GlazedDoor:Interzone", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.GlazedDoor_Interzone> GlazedDoor_Interzone_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.GlazedDoor_Interzone> ();
        
        public bool ShouldSerializeWindowShadingControl_List()
        {
            return (WindowShadingControl_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowShadingControl", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.WindowShadingControl> WindowShadingControl_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.WindowShadingControl> ();
        
        public bool ShouldSerializeWindowProperty_FrameAndDivider_List()
        {
            return (WindowProperty_FrameAndDivider_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowProperty:FrameAndDivider", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.WindowProperty_FrameAndDivider> WindowProperty_FrameAndDivider_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.WindowProperty_FrameAndDivider> ();
        
        public bool ShouldSerializeWindowProperty_AirflowControl_List()
        {
            return (WindowProperty_AirflowControl_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowProperty:AirflowControl", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.WindowProperty_AirflowControl> WindowProperty_AirflowControl_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.WindowProperty_AirflowControl> ();
        
        public bool ShouldSerializeWindowProperty_StormWindow_List()
        {
            return (WindowProperty_StormWindow_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WindowProperty:StormWindow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.WindowProperty_StormWindow> WindowProperty_StormWindow_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.WindowProperty_StormWindow> ();
        
        public bool ShouldSerializeInternalMass_List()
        {
            return (InternalMass_List.Count > 0);
        }
        

[JsonProperty(PropertyName="InternalMass", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.InternalMass> InternalMass_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.InternalMass> ();
        
        public bool ShouldSerializeShading_Site_List()
        {
            return (Shading_Site_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Shading:Site", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Shading_Site> Shading_Site_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Shading_Site> ();
        
        public bool ShouldSerializeShading_Building_List()
        {
            return (Shading_Building_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Shading:Building", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Shading_Building> Shading_Building_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Shading_Building> ();
        
        public bool ShouldSerializeShading_Site_Detailed_List()
        {
            return (Shading_Site_Detailed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Shading:Site:Detailed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Shading_Site_Detailed> Shading_Site_Detailed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Shading_Site_Detailed> ();
        
        public bool ShouldSerializeShading_Building_Detailed_List()
        {
            return (Shading_Building_Detailed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Shading:Building:Detailed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Shading_Building_Detailed> Shading_Building_Detailed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Shading_Building_Detailed> ();
        
        public bool ShouldSerializeShading_Overhang_List()
        {
            return (Shading_Overhang_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Shading:Overhang", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Shading_Overhang> Shading_Overhang_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Shading_Overhang> ();
        
        public bool ShouldSerializeShading_Overhang_Projection_List()
        {
            return (Shading_Overhang_Projection_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Shading:Overhang:Projection", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Shading_Overhang_Projection> Shading_Overhang_Projection_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Shading_Overhang_Projection> ();
        
        public bool ShouldSerializeShading_Fin_List()
        {
            return (Shading_Fin_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Shading:Fin", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Shading_Fin> Shading_Fin_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Shading_Fin> ();
        
        public bool ShouldSerializeShading_Fin_Projection_List()
        {
            return (Shading_Fin_Projection_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Shading:Fin:Projection", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Shading_Fin_Projection> Shading_Fin_Projection_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Shading_Fin_Projection> ();
        
        public bool ShouldSerializeShading_Zone_Detailed_List()
        {
            return (Shading_Zone_Detailed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Shading:Zone:Detailed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Shading_Zone_Detailed> Shading_Zone_Detailed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.Shading_Zone_Detailed> ();
        
        public bool ShouldSerializeShadingProperty_Reflectance_List()
        {
            return (ShadingProperty_Reflectance_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ShadingProperty:Reflectance", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.ShadingProperty_Reflectance> ShadingProperty_Reflectance_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ThermalZonesandSurfaces.ShadingProperty_Reflectance> ();
        
        public bool ShouldSerializeAirLoopHVAC_UnitarySystem_List()
        {
            return (AirLoopHVAC_UnitarySystem_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirLoopHVAC:UnitarySystem", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.UnitaryEquipment.AirLoopHVAC_UnitarySystem> AirLoopHVAC_UnitarySystem_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.UnitaryEquipment.AirLoopHVAC_UnitarySystem> ();
        
        public bool ShouldSerializeUnitarySystemPerformance_Multispeed_List()
        {
            return (UnitarySystemPerformance_Multispeed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="UnitarySystemPerformance:Multispeed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.UnitaryEquipment.UnitarySystemPerformance_Multispeed> UnitarySystemPerformance_Multispeed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.UnitaryEquipment.UnitarySystemPerformance_Multispeed> ();
        
        public bool ShouldSerializeAirLoopHVAC_Unitary_Furnace_HeatOnly_List()
        {
            return (AirLoopHVAC_Unitary_Furnace_HeatOnly_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirLoopHVAC:Unitary:Furnace:HeatOnly", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.UnitaryEquipment.AirLoopHVAC_Unitary_Furnace_HeatOnly> AirLoopHVAC_Unitary_Furnace_HeatOnly_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.UnitaryEquipment.AirLoopHVAC_Unitary_Furnace_HeatOnly> ();
        
        public bool ShouldSerializeAirLoopHVAC_Unitary_Furnace_HeatCool_List()
        {
            return (AirLoopHVAC_Unitary_Furnace_HeatCool_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirLoopHVAC:Unitary:Furnace:HeatCool", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.UnitaryEquipment.AirLoopHVAC_Unitary_Furnace_HeatCool> AirLoopHVAC_Unitary_Furnace_HeatCool_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.UnitaryEquipment.AirLoopHVAC_Unitary_Furnace_HeatCool> ();
        
        public bool ShouldSerializeAirLoopHVAC_UnitaryHeatOnly_List()
        {
            return (AirLoopHVAC_UnitaryHeatOnly_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirLoopHVAC:UnitaryHeatOnly", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.UnitaryEquipment.AirLoopHVAC_UnitaryHeatOnly> AirLoopHVAC_UnitaryHeatOnly_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.UnitaryEquipment.AirLoopHVAC_UnitaryHeatOnly> ();
        
        public bool ShouldSerializeAirLoopHVAC_UnitaryHeatCool_List()
        {
            return (AirLoopHVAC_UnitaryHeatCool_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirLoopHVAC:UnitaryHeatCool", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.UnitaryEquipment.AirLoopHVAC_UnitaryHeatCool> AirLoopHVAC_UnitaryHeatCool_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.UnitaryEquipment.AirLoopHVAC_UnitaryHeatCool> ();
        
        public bool ShouldSerializeAirLoopHVAC_UnitaryHeatPump_AirToAir_List()
        {
            return (AirLoopHVAC_UnitaryHeatPump_AirToAir_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirLoopHVAC:UnitaryHeatPump:AirToAir", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.UnitaryEquipment.AirLoopHVAC_UnitaryHeatPump_AirToAir> AirLoopHVAC_UnitaryHeatPump_AirToAir_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.UnitaryEquipment.AirLoopHVAC_UnitaryHeatPump_AirToAir> ();
        
        public bool ShouldSerializeAirLoopHVAC_UnitaryHeatPump_WaterToAir_List()
        {
            return (AirLoopHVAC_UnitaryHeatPump_WaterToAir_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirLoopHVAC:UnitaryHeatPump:WaterToAir", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.UnitaryEquipment.AirLoopHVAC_UnitaryHeatPump_WaterToAir> AirLoopHVAC_UnitaryHeatPump_WaterToAir_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.UnitaryEquipment.AirLoopHVAC_UnitaryHeatPump_WaterToAir> ();
        
        public bool ShouldSerializeAirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_List()
        {
            return (AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirLoopHVAC:UnitaryHeatCool:VAVChangeoverBypass", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.UnitaryEquipment.AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass> AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.UnitaryEquipment.AirLoopHVAC_UnitaryHeatCool_VAVChangeoverBypass> ();
        
        public bool ShouldSerializeAirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed_List()
        {
            return (AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirLoopHVAC:UnitaryHeatPump:AirToAir:MultiSpeed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.UnitaryEquipment.AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed> AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.UnitaryEquipment.AirLoopHVAC_UnitaryHeatPump_AirToAir_MultiSpeed> ();
        
        public bool ShouldSerializeZoneHVAC_ForcedAir_UserDefined_List()
        {
            return (ZoneHVAC_ForcedAir_UserDefined_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:ForcedAir:UserDefined", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.UserDefinedHVACandPlantComponentModels.ZoneHVAC_ForcedAir_UserDefined> ZoneHVAC_ForcedAir_UserDefined_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.UserDefinedHVACandPlantComponentModels.ZoneHVAC_ForcedAir_UserDefined> ();
        
        public bool ShouldSerializeAirTerminal_SingleDuct_UserDefined_List()
        {
            return (AirTerminal_SingleDuct_UserDefined_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirTerminal:SingleDuct:UserDefined", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.UserDefinedHVACandPlantComponentModels.AirTerminal_SingleDuct_UserDefined> AirTerminal_SingleDuct_UserDefined_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.UserDefinedHVACandPlantComponentModels.AirTerminal_SingleDuct_UserDefined> ();
        
        public bool ShouldSerializeCoil_UserDefined_List()
        {
            return (Coil_UserDefined_List.Count > 0);
        }
        

[JsonProperty(PropertyName="Coil:UserDefined", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.UserDefinedHVACandPlantComponentModels.Coil_UserDefined> Coil_UserDefined_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.UserDefinedHVACandPlantComponentModels.Coil_UserDefined> ();
        
        public bool ShouldSerializePlantComponent_UserDefined_List()
        {
            return (PlantComponent_UserDefined_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PlantComponent:UserDefined", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.UserDefinedHVACandPlantComponentModels.PlantComponent_UserDefined> PlantComponent_UserDefined_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.UserDefinedHVACandPlantComponentModels.PlantComponent_UserDefined> ();
        
        public bool ShouldSerializePlantEquipmentOperation_UserDefined_List()
        {
            return (PlantEquipmentOperation_UserDefined_List.Count > 0);
        }
        

[JsonProperty(PropertyName="PlantEquipmentOperation:UserDefined", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.UserDefinedHVACandPlantComponentModels.PlantEquipmentOperation_UserDefined> PlantEquipmentOperation_UserDefined_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.UserDefinedHVACandPlantComponentModels.PlantEquipmentOperation_UserDefined> ();
        
        public bool ShouldSerializeAirConditioner_VariableRefrigerantFlow_List()
        {
            return (AirConditioner_VariableRefrigerantFlow_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirConditioner:VariableRefrigerantFlow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.VariableRefrigerantFlowEquipment.AirConditioner_VariableRefrigerantFlow> AirConditioner_VariableRefrigerantFlow_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.VariableRefrigerantFlowEquipment.AirConditioner_VariableRefrigerantFlow> ();
        
        public bool ShouldSerializeAirConditioner_VariableRefrigerantFlow_FluidTemperatureControl_List()
        {
            return (AirConditioner_VariableRefrigerantFlow_FluidTemperatureControl_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirConditioner:VariableRefrigerantFlow:FluidTemperatureControl", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.VariableRefrigerantFlowEquipment.AirConditioner_VariableRefrigerantFlow_FluidTemperatureControl> AirConditioner_VariableRefrigerantFlow_FluidTemperatureControl_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.VariableRefrigerantFlowEquipment.AirConditioner_VariableRefrigerantFlow_FluidTemperatureControl> ();
        
        public bool ShouldSerializeAirConditioner_VariableRefrigerantFlow_FluidTemperatureControl_HR_List()
        {
            return (AirConditioner_VariableRefrigerantFlow_FluidTemperatureControl_HR_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirConditioner:VariableRefrigerantFlow:FluidTemperatureControl:HR", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.VariableRefrigerantFlowEquipment.AirConditioner_VariableRefrigerantFlow_FluidTemperatureControl_HR> AirConditioner_VariableRefrigerantFlow_FluidTemperatureControl_HR_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.VariableRefrigerantFlowEquipment.AirConditioner_VariableRefrigerantFlow_FluidTemperatureControl_HR> ();
        
        public bool ShouldSerializeZoneTerminalUnitList_List()
        {
            return (ZoneTerminalUnitList_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneTerminalUnitList", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.VariableRefrigerantFlowEquipment.ZoneTerminalUnitList> ZoneTerminalUnitList_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.VariableRefrigerantFlowEquipment.ZoneTerminalUnitList> ();
        
        public bool ShouldSerializeWaterHeater_Mixed_List()
        {
            return (WaterHeater_Mixed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WaterHeater:Mixed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.WaterHeatersandThermalStorage.WaterHeater_Mixed> WaterHeater_Mixed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.WaterHeatersandThermalStorage.WaterHeater_Mixed> ();
        
        public bool ShouldSerializeWaterHeater_Stratified_List()
        {
            return (WaterHeater_Stratified_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WaterHeater:Stratified", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.WaterHeatersandThermalStorage.WaterHeater_Stratified> WaterHeater_Stratified_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.WaterHeatersandThermalStorage.WaterHeater_Stratified> ();
        
        public bool ShouldSerializeWaterHeater_Sizing_List()
        {
            return (WaterHeater_Sizing_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WaterHeater:Sizing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.WaterHeatersandThermalStorage.WaterHeater_Sizing> WaterHeater_Sizing_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.WaterHeatersandThermalStorage.WaterHeater_Sizing> ();
        
        public bool ShouldSerializeWaterHeater_HeatPump_PumpedCondenser_List()
        {
            return (WaterHeater_HeatPump_PumpedCondenser_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WaterHeater:HeatPump:PumpedCondenser", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.WaterHeatersandThermalStorage.WaterHeater_HeatPump_PumpedCondenser> WaterHeater_HeatPump_PumpedCondenser_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.WaterHeatersandThermalStorage.WaterHeater_HeatPump_PumpedCondenser> ();
        
        public bool ShouldSerializeWaterHeater_HeatPump_WrappedCondenser_List()
        {
            return (WaterHeater_HeatPump_WrappedCondenser_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WaterHeater:HeatPump:WrappedCondenser", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.WaterHeatersandThermalStorage.WaterHeater_HeatPump_WrappedCondenser> WaterHeater_HeatPump_WrappedCondenser_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.WaterHeatersandThermalStorage.WaterHeater_HeatPump_WrappedCondenser> ();
        
        public bool ShouldSerializeThermalStorage_Ice_Simple_List()
        {
            return (ThermalStorage_Ice_Simple_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ThermalStorage:Ice:Simple", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.WaterHeatersandThermalStorage.ThermalStorage_Ice_Simple> ThermalStorage_Ice_Simple_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.WaterHeatersandThermalStorage.ThermalStorage_Ice_Simple> ();
        
        public bool ShouldSerializeThermalStorage_Ice_Detailed_List()
        {
            return (ThermalStorage_Ice_Detailed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ThermalStorage:Ice:Detailed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.WaterHeatersandThermalStorage.ThermalStorage_Ice_Detailed> ThermalStorage_Ice_Detailed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.WaterHeatersandThermalStorage.ThermalStorage_Ice_Detailed> ();
        
        public bool ShouldSerializeThermalStorage_ChilledWater_Mixed_List()
        {
            return (ThermalStorage_ChilledWater_Mixed_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ThermalStorage:ChilledWater:Mixed", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.WaterHeatersandThermalStorage.ThermalStorage_ChilledWater_Mixed> ThermalStorage_ChilledWater_Mixed_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.WaterHeatersandThermalStorage.ThermalStorage_ChilledWater_Mixed> ();
        
        public bool ShouldSerializeThermalStorage_ChilledWater_Stratified_List()
        {
            return (ThermalStorage_ChilledWater_Stratified_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ThermalStorage:ChilledWater:Stratified", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.WaterHeatersandThermalStorage.ThermalStorage_ChilledWater_Stratified> ThermalStorage_ChilledWater_Stratified_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.WaterHeatersandThermalStorage.ThermalStorage_ChilledWater_Stratified> ();
        
        public bool ShouldSerializeWaterUse_Equipment_List()
        {
            return (WaterUse_Equipment_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WaterUse:Equipment", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.WaterSystems.WaterUse_Equipment> WaterUse_Equipment_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.WaterSystems.WaterUse_Equipment> ();
        
        public bool ShouldSerializeWaterUse_Connections_List()
        {
            return (WaterUse_Connections_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WaterUse:Connections", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.WaterSystems.WaterUse_Connections> WaterUse_Connections_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.WaterSystems.WaterUse_Connections> ();
        
        public bool ShouldSerializeWaterUse_Storage_List()
        {
            return (WaterUse_Storage_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WaterUse:Storage", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.WaterSystems.WaterUse_Storage> WaterUse_Storage_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.WaterSystems.WaterUse_Storage> ();
        
        public bool ShouldSerializeWaterUse_Well_List()
        {
            return (WaterUse_Well_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WaterUse:Well", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.WaterSystems.WaterUse_Well> WaterUse_Well_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.WaterSystems.WaterUse_Well> ();
        
        public bool ShouldSerializeWaterUse_RainCollector_List()
        {
            return (WaterUse_RainCollector_List.Count > 0);
        }
        

[JsonProperty(PropertyName="WaterUse:RainCollector", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.WaterSystems.WaterUse_RainCollector> WaterUse_RainCollector_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.WaterSystems.WaterUse_RainCollector> ();
        
        public bool ShouldSerializeZoneInfiltration_DesignFlowRate_List()
        {
            return (ZoneInfiltration_DesignFlowRate_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneInfiltration:DesignFlowRate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneInfiltration_DesignFlowRate> ZoneInfiltration_DesignFlowRate_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneInfiltration_DesignFlowRate> ();
        
        public bool ShouldSerializeZoneInfiltration_EffectiveLeakageArea_List()
        {
            return (ZoneInfiltration_EffectiveLeakageArea_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneInfiltration:EffectiveLeakageArea", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneInfiltration_EffectiveLeakageArea> ZoneInfiltration_EffectiveLeakageArea_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneInfiltration_EffectiveLeakageArea> ();
        
        public bool ShouldSerializeZoneInfiltration_FlowCoefficient_List()
        {
            return (ZoneInfiltration_FlowCoefficient_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneInfiltration:FlowCoefficient", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneInfiltration_FlowCoefficient> ZoneInfiltration_FlowCoefficient_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneInfiltration_FlowCoefficient> ();
        
        public bool ShouldSerializeZoneVentilation_DesignFlowRate_List()
        {
            return (ZoneVentilation_DesignFlowRate_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneVentilation:DesignFlowRate", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneVentilation_DesignFlowRate> ZoneVentilation_DesignFlowRate_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneVentilation_DesignFlowRate> ();
        
        public bool ShouldSerializeZoneVentilation_WindandStackOpenArea_List()
        {
            return (ZoneVentilation_WindandStackOpenArea_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneVentilation:WindandStackOpenArea", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneVentilation_WindandStackOpenArea> ZoneVentilation_WindandStackOpenArea_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneVentilation_WindandStackOpenArea> ();
        
        public bool ShouldSerializeZoneAirBalance_OutdoorAir_List()
        {
            return (ZoneAirBalance_OutdoorAir_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneAirBalance:OutdoorAir", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneAirBalance_OutdoorAir> ZoneAirBalance_OutdoorAir_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneAirBalance_OutdoorAir> ();
        
        public bool ShouldSerializeZoneMixing_List()
        {
            return (ZoneMixing_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneMixing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneMixing> ZoneMixing_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneMixing> ();
        
        public bool ShouldSerializeZoneCrossMixing_List()
        {
            return (ZoneCrossMixing_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneCrossMixing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneCrossMixing> ZoneCrossMixing_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneCrossMixing> ();
        
        public bool ShouldSerializeZoneRefrigerationDoorMixing_List()
        {
            return (ZoneRefrigerationDoorMixing_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneRefrigerationDoorMixing", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneRefrigerationDoorMixing> ZoneRefrigerationDoorMixing_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneRefrigerationDoorMixing> ();
        
        public bool ShouldSerializeZoneEarthtube_List()
        {
            return (ZoneEarthtube_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneEarthtube", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneEarthtube> ZoneEarthtube_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneEarthtube> ();
        
        public bool ShouldSerializeZoneCoolTower_Shower_List()
        {
            return (ZoneCoolTower_Shower_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneCoolTower:Shower", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneCoolTower_Shower> ZoneCoolTower_Shower_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneCoolTower_Shower> ();
        
        public bool ShouldSerializeZoneThermalChimney_List()
        {
            return (ZoneThermalChimney_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneThermalChimney", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneThermalChimney> ZoneThermalChimney_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneAirflow.ZoneThermalChimney> ();
        
        public bool ShouldSerializeAirTerminal_SingleDuct_ConstantVolume_Reheat_List()
        {
            return (AirTerminal_SingleDuct_ConstantVolume_Reheat_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirTerminal:SingleDuct:ConstantVolume:Reheat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_ConstantVolume_Reheat> AirTerminal_SingleDuct_ConstantVolume_Reheat_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_ConstantVolume_Reheat> ();
        
        public bool ShouldSerializeAirTerminal_SingleDuct_ConstantVolume_NoReheat_List()
        {
            return (AirTerminal_SingleDuct_ConstantVolume_NoReheat_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirTerminal:SingleDuct:ConstantVolume:NoReheat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_ConstantVolume_NoReheat> AirTerminal_SingleDuct_ConstantVolume_NoReheat_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_ConstantVolume_NoReheat> ();
        
        public bool ShouldSerializeAirTerminal_SingleDuct_VAV_NoReheat_List()
        {
            return (AirTerminal_SingleDuct_VAV_NoReheat_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirTerminal:SingleDuct:VAV:NoReheat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_VAV_NoReheat> AirTerminal_SingleDuct_VAV_NoReheat_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_VAV_NoReheat> ();
        
        public bool ShouldSerializeAirTerminal_SingleDuct_VAV_Reheat_List()
        {
            return (AirTerminal_SingleDuct_VAV_Reheat_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirTerminal:SingleDuct:VAV:Reheat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_VAV_Reheat> AirTerminal_SingleDuct_VAV_Reheat_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_VAV_Reheat> ();
        
        public bool ShouldSerializeAirTerminal_SingleDuct_VAV_Reheat_VariableSpeedFan_List()
        {
            return (AirTerminal_SingleDuct_VAV_Reheat_VariableSpeedFan_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirTerminal:SingleDuct:VAV:Reheat:VariableSpeedFan", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_VAV_Reheat_VariableSpeedFan> AirTerminal_SingleDuct_VAV_Reheat_VariableSpeedFan_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_VAV_Reheat_VariableSpeedFan> ();
        
        public bool ShouldSerializeAirTerminal_SingleDuct_VAV_HeatAndCool_NoReheat_List()
        {
            return (AirTerminal_SingleDuct_VAV_HeatAndCool_NoReheat_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirTerminal:SingleDuct:VAV:HeatAndCool:NoReheat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_VAV_HeatAndCool_NoReheat> AirTerminal_SingleDuct_VAV_HeatAndCool_NoReheat_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_VAV_HeatAndCool_NoReheat> ();
        
        public bool ShouldSerializeAirTerminal_SingleDuct_VAV_HeatAndCool_Reheat_List()
        {
            return (AirTerminal_SingleDuct_VAV_HeatAndCool_Reheat_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirTerminal:SingleDuct:VAV:HeatAndCool:Reheat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_VAV_HeatAndCool_Reheat> AirTerminal_SingleDuct_VAV_HeatAndCool_Reheat_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_VAV_HeatAndCool_Reheat> ();
        
        public bool ShouldSerializeAirTerminal_SingleDuct_SeriesPIU_Reheat_List()
        {
            return (AirTerminal_SingleDuct_SeriesPIU_Reheat_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirTerminal:SingleDuct:SeriesPIU:Reheat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_SeriesPIU_Reheat> AirTerminal_SingleDuct_SeriesPIU_Reheat_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_SeriesPIU_Reheat> ();
        
        public bool ShouldSerializeAirTerminal_SingleDuct_ParallelPIU_Reheat_List()
        {
            return (AirTerminal_SingleDuct_ParallelPIU_Reheat_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirTerminal:SingleDuct:ParallelPIU:Reheat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_ParallelPIU_Reheat> AirTerminal_SingleDuct_ParallelPIU_Reheat_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_ParallelPIU_Reheat> ();
        
        public bool ShouldSerializeAirTerminal_SingleDuct_ConstantVolume_FourPipeInduction_List()
        {
            return (AirTerminal_SingleDuct_ConstantVolume_FourPipeInduction_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirTerminal:SingleDuct:ConstantVolume:FourPipeInduction", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_ConstantVolume_FourPipeInduction> AirTerminal_SingleDuct_ConstantVolume_FourPipeInduction_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_ConstantVolume_FourPipeInduction> ();
        
        public bool ShouldSerializeAirTerminal_SingleDuct_ConstantVolume_FourPipeBeam_List()
        {
            return (AirTerminal_SingleDuct_ConstantVolume_FourPipeBeam_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirTerminal:SingleDuct:ConstantVolume:FourPipeBeam", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_ConstantVolume_FourPipeBeam> AirTerminal_SingleDuct_ConstantVolume_FourPipeBeam_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_ConstantVolume_FourPipeBeam> ();
        
        public bool ShouldSerializeAirTerminal_SingleDuct_ConstantVolume_CooledBeam_List()
        {
            return (AirTerminal_SingleDuct_ConstantVolume_CooledBeam_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirTerminal:SingleDuct:ConstantVolume:CooledBeam", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_ConstantVolume_CooledBeam> AirTerminal_SingleDuct_ConstantVolume_CooledBeam_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_ConstantVolume_CooledBeam> ();
        
        public bool ShouldSerializeAirTerminal_SingleDuct_Mixer_List()
        {
            return (AirTerminal_SingleDuct_Mixer_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirTerminal:SingleDuct:Mixer", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_Mixer> AirTerminal_SingleDuct_Mixer_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_SingleDuct_Mixer> ();
        
        public bool ShouldSerializeAirTerminal_DualDuct_ConstantVolume_List()
        {
            return (AirTerminal_DualDuct_ConstantVolume_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirTerminal:DualDuct:ConstantVolume", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_DualDuct_ConstantVolume> AirTerminal_DualDuct_ConstantVolume_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_DualDuct_ConstantVolume> ();
        
        public bool ShouldSerializeAirTerminal_DualDuct_VAV_List()
        {
            return (AirTerminal_DualDuct_VAV_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirTerminal:DualDuct:VAV", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_DualDuct_VAV> AirTerminal_DualDuct_VAV_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_DualDuct_VAV> ();
        
        public bool ShouldSerializeAirTerminal_DualDuct_VAV_OutdoorAir_List()
        {
            return (AirTerminal_DualDuct_VAV_OutdoorAir_List.Count > 0);
        }
        

[JsonProperty(PropertyName="AirTerminal:DualDuct:VAV:OutdoorAir", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_DualDuct_VAV_OutdoorAir> AirTerminal_DualDuct_VAV_OutdoorAir_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.AirTerminal_DualDuct_VAV_OutdoorAir> ();
        
        public bool ShouldSerializeZoneHVAC_AirDistributionUnit_List()
        {
            return (ZoneHVAC_AirDistributionUnit_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:AirDistributionUnit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.ZoneHVAC_AirDistributionUnit> ZoneHVAC_AirDistributionUnit_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACAirLoopTerminalUnits.ZoneHVAC_AirDistributionUnit> ();
        
        public bool ShouldSerializeZoneControl_Humidistat_List()
        {
            return (ZoneControl_Humidistat_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneControl:Humidistat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ZoneControl_Humidistat> ZoneControl_Humidistat_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ZoneControl_Humidistat> ();
        
        public bool ShouldSerializeZoneControl_Thermostat_List()
        {
            return (ZoneControl_Thermostat_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneControl:Thermostat", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ZoneControl_Thermostat> ZoneControl_Thermostat_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ZoneControl_Thermostat> ();
        
        public bool ShouldSerializeZoneControl_Thermostat_OperativeTemperature_List()
        {
            return (ZoneControl_Thermostat_OperativeTemperature_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneControl:Thermostat:OperativeTemperature", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ZoneControl_Thermostat_OperativeTemperature> ZoneControl_Thermostat_OperativeTemperature_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ZoneControl_Thermostat_OperativeTemperature> ();
        
        public bool ShouldSerializeZoneControl_Thermostat_ThermalComfort_List()
        {
            return (ZoneControl_Thermostat_ThermalComfort_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneControl:Thermostat:ThermalComfort", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ZoneControl_Thermostat_ThermalComfort> ZoneControl_Thermostat_ThermalComfort_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ZoneControl_Thermostat_ThermalComfort> ();
        
        public bool ShouldSerializeZoneControl_Thermostat_TemperatureAndHumidity_List()
        {
            return (ZoneControl_Thermostat_TemperatureAndHumidity_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneControl:Thermostat:TemperatureAndHumidity", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ZoneControl_Thermostat_TemperatureAndHumidity> ZoneControl_Thermostat_TemperatureAndHumidity_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ZoneControl_Thermostat_TemperatureAndHumidity> ();
        
        public bool ShouldSerializeThermostatSetpoint_SingleHeating_List()
        {
            return (ThermostatSetpoint_SingleHeating_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ThermostatSetpoint:SingleHeating", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ThermostatSetpoint_SingleHeating> ThermostatSetpoint_SingleHeating_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ThermostatSetpoint_SingleHeating> ();
        
        public bool ShouldSerializeThermostatSetpoint_SingleCooling_List()
        {
            return (ThermostatSetpoint_SingleCooling_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ThermostatSetpoint:SingleCooling", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ThermostatSetpoint_SingleCooling> ThermostatSetpoint_SingleCooling_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ThermostatSetpoint_SingleCooling> ();
        
        public bool ShouldSerializeThermostatSetpoint_SingleHeatingOrCooling_List()
        {
            return (ThermostatSetpoint_SingleHeatingOrCooling_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ThermostatSetpoint:SingleHeatingOrCooling", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ThermostatSetpoint_SingleHeatingOrCooling> ThermostatSetpoint_SingleHeatingOrCooling_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ThermostatSetpoint_SingleHeatingOrCooling> ();
        
        public bool ShouldSerializeThermostatSetpoint_DualSetpoint_List()
        {
            return (ThermostatSetpoint_DualSetpoint_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ThermostatSetpoint:DualSetpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ThermostatSetpoint_DualSetpoint> ThermostatSetpoint_DualSetpoint_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ThermostatSetpoint_DualSetpoint> ();
        
        public bool ShouldSerializeThermostatSetpoint_ThermalComfort_Fanger_SingleHeating_List()
        {
            return (ThermostatSetpoint_ThermalComfort_Fanger_SingleHeating_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ThermostatSetpoint:ThermalComfort:Fanger:SingleHeating", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ThermostatSetpoint_ThermalComfort_Fanger_SingleHeating> ThermostatSetpoint_ThermalComfort_Fanger_SingleHeating_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ThermostatSetpoint_ThermalComfort_Fanger_SingleHeating> ();
        
        public bool ShouldSerializeThermostatSetpoint_ThermalComfort_Fanger_SingleCooling_List()
        {
            return (ThermostatSetpoint_ThermalComfort_Fanger_SingleCooling_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ThermostatSetpoint:ThermalComfort:Fanger:SingleCooling", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ThermostatSetpoint_ThermalComfort_Fanger_SingleCooling> ThermostatSetpoint_ThermalComfort_Fanger_SingleCooling_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ThermostatSetpoint_ThermalComfort_Fanger_SingleCooling> ();
        
        public bool ShouldSerializeThermostatSetpoint_ThermalComfort_Fanger_SingleHeatingOrCooling_List()
        {
            return (ThermostatSetpoint_ThermalComfort_Fanger_SingleHeatingOrCooling_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ThermostatSetpoint:ThermalComfort:Fanger:SingleHeatingOrCooling", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ThermostatSetpoint_ThermalComfort_Fanger_SingleHeatingOrCooling> ThermostatSetpoint_ThermalComfort_Fanger_SingleHeatingOrCooling_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ThermostatSetpoint_ThermalComfort_Fanger_SingleHeatingOrCooling> ();
        
        public bool ShouldSerializeThermostatSetpoint_ThermalComfort_Fanger_DualSetpoint_List()
        {
            return (ThermostatSetpoint_ThermalComfort_Fanger_DualSetpoint_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ThermostatSetpoint:ThermalComfort:Fanger:DualSetpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ThermostatSetpoint_ThermalComfort_Fanger_DualSetpoint> ThermostatSetpoint_ThermalComfort_Fanger_DualSetpoint_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ThermostatSetpoint_ThermalComfort_Fanger_DualSetpoint> ();
        
        public bool ShouldSerializeZoneControl_Thermostat_StagedDualSetpoint_List()
        {
            return (ZoneControl_Thermostat_StagedDualSetpoint_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneControl:Thermostat:StagedDualSetpoint", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ZoneControl_Thermostat_StagedDualSetpoint> ZoneControl_Thermostat_StagedDualSetpoint_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ZoneControl_Thermostat_StagedDualSetpoint> ();
        
        public bool ShouldSerializeZoneControl_ContaminantController_List()
        {
            return (ZoneControl_ContaminantController_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneControl:ContaminantController", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ZoneControl_ContaminantController> ZoneControl_ContaminantController_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACControlsandThermostats.ZoneControl_ContaminantController> ();
        
        public bool ShouldSerializeZoneHVAC_EquipmentList_List()
        {
            return (ZoneHVAC_EquipmentList_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:EquipmentList", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACEquipmentConnections.ZoneHVAC_EquipmentList> ZoneHVAC_EquipmentList_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACEquipmentConnections.ZoneHVAC_EquipmentList> ();
        
        public bool ShouldSerializeZoneHVAC_EquipmentConnections_List()
        {
            return (ZoneHVAC_EquipmentConnections_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:EquipmentConnections", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACEquipmentConnections.ZoneHVAC_EquipmentConnections> ZoneHVAC_EquipmentConnections_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACEquipmentConnections.ZoneHVAC_EquipmentConnections> ();
        
        public bool ShouldSerializeZoneHVAC_IdealLoadsAirSystem_List()
        {
            return (ZoneHVAC_IdealLoadsAirSystem_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:IdealLoadsAirSystem", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_IdealLoadsAirSystem> ZoneHVAC_IdealLoadsAirSystem_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_IdealLoadsAirSystem> ();
        
        public bool ShouldSerializeZoneHVAC_FourPipeFanCoil_List()
        {
            return (ZoneHVAC_FourPipeFanCoil_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:FourPipeFanCoil", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_FourPipeFanCoil> ZoneHVAC_FourPipeFanCoil_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_FourPipeFanCoil> ();
        
        public bool ShouldSerializeZoneHVAC_WindowAirConditioner_List()
        {
            return (ZoneHVAC_WindowAirConditioner_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:WindowAirConditioner", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_WindowAirConditioner> ZoneHVAC_WindowAirConditioner_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_WindowAirConditioner> ();
        
        public bool ShouldSerializeZoneHVAC_PackagedTerminalAirConditioner_List()
        {
            return (ZoneHVAC_PackagedTerminalAirConditioner_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:PackagedTerminalAirConditioner", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_PackagedTerminalAirConditioner> ZoneHVAC_PackagedTerminalAirConditioner_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_PackagedTerminalAirConditioner> ();
        
        public bool ShouldSerializeZoneHVAC_PackagedTerminalHeatPump_List()
        {
            return (ZoneHVAC_PackagedTerminalHeatPump_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:PackagedTerminalHeatPump", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_PackagedTerminalHeatPump> ZoneHVAC_PackagedTerminalHeatPump_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_PackagedTerminalHeatPump> ();
        
        public bool ShouldSerializeZoneHVAC_WaterToAirHeatPump_List()
        {
            return (ZoneHVAC_WaterToAirHeatPump_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:WaterToAirHeatPump", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_WaterToAirHeatPump> ZoneHVAC_WaterToAirHeatPump_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_WaterToAirHeatPump> ();
        
        public bool ShouldSerializeZoneHVAC_Dehumidifier_DX_List()
        {
            return (ZoneHVAC_Dehumidifier_DX_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:Dehumidifier:DX", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_Dehumidifier_DX> ZoneHVAC_Dehumidifier_DX_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_Dehumidifier_DX> ();
        
        public bool ShouldSerializeZoneHVAC_EnergyRecoveryVentilator_List()
        {
            return (ZoneHVAC_EnergyRecoveryVentilator_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:EnergyRecoveryVentilator", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_EnergyRecoveryVentilator> ZoneHVAC_EnergyRecoveryVentilator_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_EnergyRecoveryVentilator> ();
        
        public bool ShouldSerializeZoneHVAC_EnergyRecoveryVentilator_Controller_List()
        {
            return (ZoneHVAC_EnergyRecoveryVentilator_Controller_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:EnergyRecoveryVentilator:Controller", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_EnergyRecoveryVentilator_Controller> ZoneHVAC_EnergyRecoveryVentilator_Controller_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_EnergyRecoveryVentilator_Controller> ();
        
        public bool ShouldSerializeZoneHVAC_UnitVentilator_List()
        {
            return (ZoneHVAC_UnitVentilator_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:UnitVentilator", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_UnitVentilator> ZoneHVAC_UnitVentilator_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_UnitVentilator> ();
        
        public bool ShouldSerializeZoneHVAC_UnitHeater_List()
        {
            return (ZoneHVAC_UnitHeater_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:UnitHeater", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_UnitHeater> ZoneHVAC_UnitHeater_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_UnitHeater> ();
        
        public bool ShouldSerializeZoneHVAC_EvaporativeCoolerUnit_List()
        {
            return (ZoneHVAC_EvaporativeCoolerUnit_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:EvaporativeCoolerUnit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_EvaporativeCoolerUnit> ZoneHVAC_EvaporativeCoolerUnit_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_EvaporativeCoolerUnit> ();
        
        public bool ShouldSerializeZoneHVAC_HybridUnitaryHVAC_List()
        {
            return (ZoneHVAC_HybridUnitaryHVAC_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:HybridUnitaryHVAC", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_HybridUnitaryHVAC> ZoneHVAC_HybridUnitaryHVAC_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_HybridUnitaryHVAC> ();
        
        public bool ShouldSerializeZoneHVAC_OutdoorAirUnit_List()
        {
            return (ZoneHVAC_OutdoorAirUnit_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:OutdoorAirUnit", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_OutdoorAirUnit> ZoneHVAC_OutdoorAirUnit_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_OutdoorAirUnit> ();
        
        public bool ShouldSerializeZoneHVAC_OutdoorAirUnit_EquipmentList_List()
        {
            return (ZoneHVAC_OutdoorAirUnit_EquipmentList_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:OutdoorAirUnit:EquipmentList", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_OutdoorAirUnit_EquipmentList> ZoneHVAC_OutdoorAirUnit_EquipmentList_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_OutdoorAirUnit_EquipmentList> ();
        
        public bool ShouldSerializeZoneHVAC_TerminalUnit_VariableRefrigerantFlow_List()
        {
            return (ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:TerminalUnit:VariableRefrigerantFlow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_TerminalUnit_VariableRefrigerantFlow> ZoneHVAC_TerminalUnit_VariableRefrigerantFlow_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACForcedAirUnits.ZoneHVAC_TerminalUnit_VariableRefrigerantFlow> ();
        
        public bool ShouldSerializeZoneHVAC_Baseboard_RadiantConvective_Water_Design_List()
        {
            return (ZoneHVAC_Baseboard_RadiantConvective_Water_Design_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:Baseboard:RadiantConvective:Water:Design", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_Baseboard_RadiantConvective_Water_Design> ZoneHVAC_Baseboard_RadiantConvective_Water_Design_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_Baseboard_RadiantConvective_Water_Design> ();
        
        public bool ShouldSerializeZoneHVAC_Baseboard_RadiantConvective_Water_List()
        {
            return (ZoneHVAC_Baseboard_RadiantConvective_Water_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:Baseboard:RadiantConvective:Water", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_Baseboard_RadiantConvective_Water> ZoneHVAC_Baseboard_RadiantConvective_Water_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_Baseboard_RadiantConvective_Water> ();
        
        public bool ShouldSerializeZoneHVAC_Baseboard_RadiantConvective_Steam_Design_List()
        {
            return (ZoneHVAC_Baseboard_RadiantConvective_Steam_Design_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:Baseboard:RadiantConvective:Steam:Design", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_Baseboard_RadiantConvective_Steam_Design> ZoneHVAC_Baseboard_RadiantConvective_Steam_Design_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_Baseboard_RadiantConvective_Steam_Design> ();
        
        public bool ShouldSerializeZoneHVAC_Baseboard_RadiantConvective_Steam_List()
        {
            return (ZoneHVAC_Baseboard_RadiantConvective_Steam_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:Baseboard:RadiantConvective:Steam", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_Baseboard_RadiantConvective_Steam> ZoneHVAC_Baseboard_RadiantConvective_Steam_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_Baseboard_RadiantConvective_Steam> ();
        
        public bool ShouldSerializeZoneHVAC_Baseboard_RadiantConvective_Electric_List()
        {
            return (ZoneHVAC_Baseboard_RadiantConvective_Electric_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:Baseboard:RadiantConvective:Electric", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_Baseboard_RadiantConvective_Electric> ZoneHVAC_Baseboard_RadiantConvective_Electric_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_Baseboard_RadiantConvective_Electric> ();
        
        public bool ShouldSerializeZoneHVAC_CoolingPanel_RadiantConvective_Water_List()
        {
            return (ZoneHVAC_CoolingPanel_RadiantConvective_Water_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:CoolingPanel:RadiantConvective:Water", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_CoolingPanel_RadiantConvective_Water> ZoneHVAC_CoolingPanel_RadiantConvective_Water_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_CoolingPanel_RadiantConvective_Water> ();
        
        public bool ShouldSerializeZoneHVAC_Baseboard_Convective_Water_List()
        {
            return (ZoneHVAC_Baseboard_Convective_Water_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:Baseboard:Convective:Water", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_Baseboard_Convective_Water> ZoneHVAC_Baseboard_Convective_Water_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_Baseboard_Convective_Water> ();
        
        public bool ShouldSerializeZoneHVAC_Baseboard_Convective_Electric_List()
        {
            return (ZoneHVAC_Baseboard_Convective_Electric_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:Baseboard:Convective:Electric", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_Baseboard_Convective_Electric> ZoneHVAC_Baseboard_Convective_Electric_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_Baseboard_Convective_Electric> ();
        
        public bool ShouldSerializeZoneHVAC_LowTemperatureRadiant_VariableFlow_List()
        {
            return (ZoneHVAC_LowTemperatureRadiant_VariableFlow_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:LowTemperatureRadiant:VariableFlow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_LowTemperatureRadiant_VariableFlow> ZoneHVAC_LowTemperatureRadiant_VariableFlow_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_LowTemperatureRadiant_VariableFlow> ();
        
        public bool ShouldSerializeZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_List()
        {
            return (ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:LowTemperatureRadiant:VariableFlow:Design", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design> ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_LowTemperatureRadiant_VariableFlow_Design> ();
        
        public bool ShouldSerializeZoneHVAC_LowTemperatureRadiant_ConstantFlow_List()
        {
            return (ZoneHVAC_LowTemperatureRadiant_ConstantFlow_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:LowTemperatureRadiant:ConstantFlow", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_LowTemperatureRadiant_ConstantFlow> ZoneHVAC_LowTemperatureRadiant_ConstantFlow_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_LowTemperatureRadiant_ConstantFlow> ();
        
        public bool ShouldSerializeZoneHVAC_LowTemperatureRadiant_ConstantFlow_Design_List()
        {
            return (ZoneHVAC_LowTemperatureRadiant_ConstantFlow_Design_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:LowTemperatureRadiant:ConstantFlow:Design", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_LowTemperatureRadiant_ConstantFlow_Design> ZoneHVAC_LowTemperatureRadiant_ConstantFlow_Design_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_LowTemperatureRadiant_ConstantFlow_Design> ();
        
        public bool ShouldSerializeZoneHVAC_LowTemperatureRadiant_Electric_List()
        {
            return (ZoneHVAC_LowTemperatureRadiant_Electric_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:LowTemperatureRadiant:Electric", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_LowTemperatureRadiant_Electric> ZoneHVAC_LowTemperatureRadiant_Electric_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_LowTemperatureRadiant_Electric> ();
        
        public bool ShouldSerializeZoneHVAC_LowTemperatureRadiant_SurfaceGroup_List()
        {
            return (ZoneHVAC_LowTemperatureRadiant_SurfaceGroup_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:LowTemperatureRadiant:SurfaceGroup", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_LowTemperatureRadiant_SurfaceGroup> ZoneHVAC_LowTemperatureRadiant_SurfaceGroup_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_LowTemperatureRadiant_SurfaceGroup> ();
        
        public bool ShouldSerializeZoneHVAC_HighTemperatureRadiant_List()
        {
            return (ZoneHVAC_HighTemperatureRadiant_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:HighTemperatureRadiant", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_HighTemperatureRadiant> ZoneHVAC_HighTemperatureRadiant_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_HighTemperatureRadiant> ();
        
        public bool ShouldSerializeZoneHVAC_VentilatedSlab_List()
        {
            return (ZoneHVAC_VentilatedSlab_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:VentilatedSlab", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_VentilatedSlab> ZoneHVAC_VentilatedSlab_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_VentilatedSlab> ();
        
        public bool ShouldSerializeZoneHVAC_VentilatedSlab_SlabGroup_List()
        {
            return (ZoneHVAC_VentilatedSlab_SlabGroup_List.Count > 0);
        }
        

[JsonProperty(PropertyName="ZoneHVAC:VentilatedSlab:SlabGroup", NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore)]
public System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_VentilatedSlab_SlabGroup> ZoneHVAC_VentilatedSlab_SlabGroup_List { get; set; } = new System.Collections.Generic.List<EnergyPlus.ZoneHVACRadiativeConvectiveUnits.ZoneHVAC_VentilatedSlab_SlabGroup> ();
    }
    
    public enum EmptyNoYes
    {
        
        [System.Runtime.Serialization.EnumMember(Value="")]
        Empty = 0,
        
        [System.Runtime.Serialization.EnumMember(Value="No")]
        No = 1,
        
        [System.Runtime.Serialization.EnumMember(Value="Yes")]
        Yes = 2,
    }
}
