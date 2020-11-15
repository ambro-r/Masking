using Masking.Attributes;
using Newtonsoft.Json;
using System;

namespace Masking.Components
{
    public class JsonMaskedFieldConverter : JsonConverter
    {
        private readonly Mask Mask;

        public JsonMaskedFieldConverter(Mask mask)
        {
            Mask = mask;
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {      
            return reader.Value;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {         
            serializer.Serialize(writer, MaskApplicator.Instance.Mask(Mask, value.ToString()));
        }

    }
}
