using System;

namespace Masking.Attributes
{
    public enum MaskingMethod
    {
        Encrypt,
        Mask,
        Replace,
        Trim
    }

    public class Mask : Attribute
    {          
        readonly MaskingMethod _method;
        readonly string _value;

        public Mask() { 
        }

        public Mask(MaskingMethod maskMethod, String value)
        {
            _method = maskMethod;
            _value = value;
        }

        public Mask(MaskingMethod maskMethod)
        {
            _method = maskMethod;
            _value = string.Empty;
        }

        public string Value
        {
            get { return _value; }
        }

        public MaskingMethod Method
        {
            get { return _method; }
        }
    }
}
