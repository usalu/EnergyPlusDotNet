using EnergyPlus;

namespace EnergyPlus
{
    public static partial class Convert
    {

        public static string GetIDF(string energyPlusExeFilePath, EPSimulationFile ePJson, bool isSilent = true) =>
            ConvertEPSimulationFile(energyPlusExeFilePath, GetEPJsonString(ePJson), isSilent);

        public static string GetIDF(string energyPlusExeFilePath, string baseIDF, string ePJson, bool isSilent = true) =>
            ConvertEPSimulationFile(energyPlusExeFilePath, GetMergedEPJsonString(ConvertEPSimulationFile(energyPlusExeFilePath, baseIDF), ePJson), isSilent);

        public static string GetIDF(string energyPlusExeFilePath, string baseIDF, EPSimulationFile ePJson, bool isSilent = true) =>
            ConvertEPSimulationFile(energyPlusExeFilePath, GetMergedEPJsonString(ConvertEPSimulationFile(energyPlusExeFilePath, baseIDF, isSilent), GetEPJsonString(ePJson)), isSilent);
        public static string GetIDF(string energyPlusExeFilePath, EPSimulationFile baseEPJson, EPSimulationFile ePJson, bool isSilent = true) =>
            ConvertEPSimulationFile(energyPlusExeFilePath, GetMergedEPJsonString(baseEPJson, ePJson), isSilent);

    }
}


