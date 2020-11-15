using Masking.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Masking.Components
{
    public class JsonMaskContractResolver : DefaultContractResolver
    {        

        public JsonMaskContractResolver() { }
          
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            Dictionary<string, Mask> masks = MaskApplicator.Instance.MasksForType(type);
            IList<JsonProperty> jsonProperties = base.CreateProperties(type, memberSerialization);

            object[] attributes = type.GetCustomAttributes(typeof(IgnoreContractResolver), false);
            if (attributes == null || attributes.Length <= 0)
            {
                if (masks != null && masks.Count > 0)
                {
                    foreach (JsonProperty jsonProperty in jsonProperties)
                    {
                        string propertyName = jsonProperty.PropertyName;
                        if(masks.ContainsKey(propertyName)) {
                            jsonProperty.Converter = new JsonMaskedFieldConverter(masks[propertyName]);
                        }
                    }
                }                
            }
            return jsonProperties;
        }

    }
}
