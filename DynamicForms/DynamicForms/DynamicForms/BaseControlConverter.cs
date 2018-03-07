using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Xamarin.Forms.Internals;

namespace DynamicForms
{
    public abstract class JsonCreationConverter<T> : JsonConverter
    {
        protected abstract T Create(Type objectType, JObject jsonObject);

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var target = Create(objectType, jsonObject);
            serializer.Populate(jsonObject.CreateReader(), target);
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    public class BaseControlConverter : JsonCreationConverter<BaseControl>
    {
        protected override BaseControl Create(Type objectType, JObject jsonObject)
        {
            string typeName = (jsonObject["Type"]).ToString();
            switch (typeName)
            {
                case "Label":
                    return new FormLabel();
                case "Entry":
                    return new FormEntry();
                case "Picker":
                    return new FormPicker();
                case "ImageUpload":
                    return new BaseControl();
                default:
                    return null;
            }
        }
    }
}
