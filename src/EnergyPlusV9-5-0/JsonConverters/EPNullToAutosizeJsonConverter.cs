using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnergyPlusV9_5_0.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EnergyPlus.JsonConverters
{
    public class EPNullToAutosizeJsonConverter : JsonConverter<double?>
    {
        public override void WriteJson(JsonWriter writer, double? value, JsonSerializer serializer)
        {
            double autosizeValue;
            double.TryParse(Resources.autosizableValue, out autosizeValue);
            if (value == autosizeValue)
            {
                writer.WriteRawValue("\"Autosize\"");
            }
            else
            {
                JToken t = JToken.FromObject(value);
                t.WriteTo(writer);
            }
        }

        public override double? ReadJson(JsonReader reader, Type objectType, double? existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
