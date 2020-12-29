using Masking.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Masking
{
    public class MaskApplicator
    {
        private MaskApplicator() { }

        public static MaskApplicator Instance { get; } = new MaskApplicator();

        public string Mask(Mask mask, string value)
        {
            // If the String is empty or null we just leave it as is for the moment. 
            if (!string.IsNullOrEmpty(value))
            {
                if (mask.Method == MaskingMethod.Mask)
                {
                    Regex regex = new Regex(mask.Value.Trim());
                    Match match = regex.Match(value);
                    string replace = new String('X', match.Value.Length);
                    value = Regex.Replace(value, mask.Value, replace);
                }
                else if (mask.Method == MaskingMethod.Replace)
                {
                    value = mask.Value;
                }
                else if (mask.Method == MaskingMethod.Trim)
                {
                    value = Regex.Replace(value, mask.Value, "...");
                }
            }
            return value;
        }

        public Dictionary<string, Mask> MasksForType(Type type)
        {
            Dictionary<string, Mask> masks = new Dictionary<string, Mask>(StringComparer.OrdinalIgnoreCase);
            object[] attributes = type.GetCustomAttributes(typeof(Mask), false);
            if (attributes != null && attributes.Length > 0)
            {
                System.Reflection.PropertyInfo[] properties = type.GetProperties();
                foreach (System.Reflection.PropertyInfo property in properties)
                {
                    object[] maskAttributes = property.GetCustomAttributes(typeof(Mask), false);
                    object[] jsonProperty = property.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                    string key = property.Name;
                    if (jsonProperty != null && jsonProperty.Length > 0)
                    {
                        JsonPropertyAttribute jpa = (JsonPropertyAttribute)jsonProperty[0];
                        if (!string.IsNullOrEmpty(jpa.PropertyName))
                        {
                            key = jpa.PropertyName;
                        }
                    }

                    if (maskAttributes != null && maskAttributes.Length > 0)
                    {
                        masks.Add(key.ToLower(), (Mask)maskAttributes[0]);
                    }
                }
            }
            return masks;
        }


    }
}
