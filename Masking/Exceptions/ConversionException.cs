using System;
using System.Collections.Generic;
using System.Text;

namespace Masking.Exceptions
{
    [Serializable]
    public class ConversionException : Exception
    {

        private ConversionException() { }

        public ConversionException(string what, string to, string message) : base(string.Format("Unable to convert {0} to {1}: {2}", what, to, message)) { }

    }
}
