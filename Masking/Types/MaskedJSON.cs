using Masking.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Masking.Types
{
    public class MaskedJSON
    {

        private string _json;

        public string Json
        {
            get
            {
                return this._json;
            }
            set
            {
                string _value = value.Trim();
                if (_value.StartsWith("<") && _value.EndsWith(">"))
                {
                    try
                    {
                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.LoadXml(_value);
                        this._json = JsonConvert.SerializeXmlNode(xmlDocument);
                    }
                    catch (Exception e)
                    {
                        throw new ConversionException(_value, "JSON", e.Message);                       
                    }
                }
                else if (string.IsNullOrEmpty(_value))
                {
                    this._json = "{}";
                }
                else
                {
                    this._json = _value;
                }
            }
        }

        public string MaskedJson { get; set; }

    }
}
