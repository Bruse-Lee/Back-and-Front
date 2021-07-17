using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace ContosoPizza.Utils
{
    public class JsonHelper
    {
        public static string Serialize(dynamic obj)
        {
            var datetimeFormat = "yyyy-MM-dd HH:mm:ss";
            var setting = new JsonSerializerSettings();
            // 首字母转换成小写
            setting.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            setting.DateFormatString = datetimeFormat;

            var timeConverter = new IsoDateTimeConverter {DateTimeFormat = datetimeFormat};
            var result = JsonConvert.SerializeObject(obj,Formatting.Indented,setting);
            return result;
        }
    }
}