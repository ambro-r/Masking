using Dapper;
using Masking.Types;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Data;

namespace Masking.SQLMappers
{

    /*
     * SimpleCRUD will ignore all types that is not TypeExtension.IsSimpleType()
     * This happens inside GetScaffoldableProperties Modifying a few lines of code fixes the issue (i.e., removing the check for IsSimpleType())
     * 
     * OR ... one could simply set [Editable(true)] flag on the complex type field.
     */
    public class MaskedJSONTypeHandler : SqlMapper.TypeHandler<MaskedJSON>
    {

        private MaskedJSONTypeHandler() { }

        public static MaskedJSONTypeHandler Instance { get; } = new MaskedJSONTypeHandler();

        public override MaskedJSON Parse(object value)
        {
            string json = value.ToString();
            MaskedJSON maskedJSON = new MaskedJSON();
            if (value != null)
            {
                maskedJSON.Json = json;
            }
            return maskedJSON;
        }

        public override void SetValue(IDbDataParameter parameter, MaskedJSON maskedJSON)
        {
            if (maskedJSON != null)
            {
                parameter.Value = maskedJSON.MaskedJson;
            }
            ((NpgsqlParameter)parameter).NpgsqlDbType = NpgsqlDbType.Jsonb;
        }

       

    }
}
