using Masking.Components;
using Newtonsoft.Json;

namespace Masking.Types
{
    public class MaskedType<T>
    {

        public T Model { get; }

        public MaskedType(T model)
        {
            Model = model;
        }

        public string Serialize()
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new JsonMaskContractResolver()
            };
            return JsonConvert.SerializeObject(Model, jsonSerializerSettings);
        }

    }

}
