using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBindeIssue.Models
{
    public class JsonValueConverter<TModel> : ValueConverter<TModel, string>
    {
        public static JsonSerializerSettings setting = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
        };
        public JsonValueConverter() : base(m => Ser(m),
            str => Der(str))
        {

        }


        public static string Ser(TModel m)
        {
            try
            {
                return JsonConvert.SerializeObject(m, setting);
            }
            catch
            {
                return null;
            }
        }

        public static TModel Der(string str)
        {
            try
            {
                return JsonConvert.DeserializeObject<TModel>(str, setting);
            }
            catch
            {
                return default;
            }
        }
    }
}
