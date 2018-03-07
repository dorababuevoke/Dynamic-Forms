using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace DynamicForms
{
    public static class JsonParser
    {
        public static JsonResult GetJsonData(string jsonPath, Assembly assembly)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            };

            var converter = new BaseControlConverter();

            settings.Converters.Add(converter);
            Stream stream = assembly.GetManifestResourceStream(jsonPath);
            JsonResult formControls;
            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                formControls = JsonConvert.DeserializeObject<JsonResult>(json, settings);
            }

            return formControls;
        }
    }
}
