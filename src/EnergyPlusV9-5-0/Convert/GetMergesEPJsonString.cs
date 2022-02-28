using EnergyPlus;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EnergyPlus
{
    public static partial class Convert
    {
        
        public static string GetMergedEPJsonString(EPSimulationFile basEPJson, EPSimulationFile additionalEpJson) =>
            GetMergedEPJsonString(GetEPJsonString(basEPJson), GetEPJsonString(additionalEpJson));

        public static string GetMergedEPJsonString(string baseEPJson, string additionalEpJson)
        {
            JObject mergedEPJsonJson = JObject.Parse(baseEPJson.Trim());
            JObject parsedAdditionalEPJson = JObject.Parse(additionalEpJson.Trim());
            mergedEPJsonJson.Merge(parsedAdditionalEPJson);
            return JsonConvert.SerializeObject(mergedEPJsonJson);
        }

    }
}


