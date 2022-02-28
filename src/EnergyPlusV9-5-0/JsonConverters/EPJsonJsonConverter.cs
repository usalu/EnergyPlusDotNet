using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EnergyPlus;

namespace EnergyPlus.JsonConverters
{
    /// <summary>
    /// Recursive iterations need to be stopped.
    /// See: https://stackoverflow.com/questions/29719509/json-net-throws-stackoverflowexception-when-using-jsonconvert
    /// </summary>
    internal class EPJsonJsonConverter : JsonConverter<EPSimulationFile>
    {

        [ThreadStatic]
        static bool disabled;

        // Disables the converter in a thread-safe manner.
        bool Disabled { get { return disabled; } set { disabled = value; } }

        public override bool CanWrite { get { return !Disabled; } }

        public override void WriteJson(JsonWriter writer, EPSimulationFile value, JsonSerializer serializer)
        {
            JToken t;
            using (new PushValue<bool>(true, () => Disabled, (canWrite) => Disabled = canWrite))
            {
                t = JToken.FromObject(value, serializer);
            }

            if (t.Type != JTokenType.Object)
            {
                t.WriteTo(writer);
                return;
            }
            //Test
            JObject o = (JObject)t;

            //Without wrapper classes for the epProperties
            //GetClearedEPJsonJObject((JObject)t).WriteTo(writer);

            writer.WriteStartObject();
            //With wrapper classes
            foreach (var property in o.Properties())
            {
                if (property.Value.Type == JTokenType.Object)
                {
                    JObject clearedObject = GetClearedEPJsonJObject((JObject)property.Value);
                    if (clearedObject.HasValues)
                    {
                        foreach (var ePProperty in clearedObject.Properties())
                        {
                            ePProperty.WriteTo(writer);
                        }
                    }
                }
            }
            writer.WriteEndObject();

        }

        public override EPSimulationFile ReadJson(JsonReader reader, Type objectType, EPSimulationFile existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        internal struct PushValue<T> : IDisposable
        {
            Action<T> setValue;
            T oldValue;

            public PushValue(T value, Func<T> getValue, Action<T> setValue)
            {
                if (getValue == null || setValue == null)
                    throw new ArgumentNullException();
                this.setValue = setValue;
                this.oldValue = getValue();
                setValue(value);
            }

            #region IDisposable Members

            // By using a disposable struct we avoid the overhead of allocating and freeing an instance of a finalizable class.
            public void Dispose()
            {
                if (setValue != null)
                    setValue(oldValue);
            }

            #endregion
        }

        static JToken GetEPNodeWithNameAsMainProperty(JObject ePNode)
        {

            string name = ePNode.Property("name").Value.ToString();
            if (name != null)
            {
                var valuesByName = new JObject(ePNode);
                valuesByName.Property("name").Remove();
                var newProperty = new JProperty(name, valuesByName);
                return newProperty;
            }
            return ePNode;
        }

        static JObject GetClearedEPJsonJObject(JObject ePJObject)
        {
            JObject newPPJObject = new JObject(ePJObject);
            newPPJObject.Property("BHoM_Guid")?.Remove();
            newPPJObject.Property("Name")?.Remove();
            newPPJObject.Property("Fragments")?.Remove();
            newPPJObject.Property("Tags")?.Remove();
            newPPJObject.Property("CustomData")?.Remove();

            foreach (var ePGroup in newPPJObject.Properties())
            {
                JProperty ePObjectGroup = newPPJObject.Property(ePGroup.Name);
                JObject newEPObjectGroupValues = new JObject();
                switch (ePGroup.Value.Type)
                {
                    case JTokenType.Array:
                        foreach (var epNode in ePGroup.Values())
                        {
                            newEPObjectGroupValues.Add(GetEPNodeWithNameAsMainProperty((JObject)epNode));
                        }

                        ePObjectGroup.Value = newEPObjectGroupValues;
                        break;
                    default:
                        newEPObjectGroupValues.Add(GetEPNodeWithNameAsMainProperty((JObject)ePGroup.Value));
                        ePObjectGroup.Value = newEPObjectGroupValues;
                        break;
                }
            }
            return newPPJObject;
        }

    }

    //Throws Stack.Overflow
    //public class EPJsonJsonConverter : JsonConverter<EPSimulationFile>
    //{

    //    public override void WriteJson(JsonWriter writer, EPSimulationFile value, JsonSerializer serializer)
    //    {
    //        JToken t = JToken.FromObject(value);

    //        if (t.Type != JTokenType.Object)
    //        {
    //            t.WriteTo(writer);
    //        }
    //        else
    //        {
    //            GetClearedEPJsonJObject((JObject)t).WriteTo(writer);
    //        }
    //    }


    //    public override EPSimulationFile ReadJson(JsonReader reader, Type objectType, EPSimulationFile existingValue, bool hasExistingValue,
    //    JsonSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }
}
