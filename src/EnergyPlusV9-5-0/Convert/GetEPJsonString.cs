using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EnergyPlus
{
    public static partial class Convert
    {
        public static string GetEPJsonString(EPSimulationFile ePSimulationFile)
        {
            return JsonConvert.SerializeObject(ePSimulationFile, Formatting.Indented);
        }
    }
}


