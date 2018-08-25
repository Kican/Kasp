using System;
using Newtonsoft.Json;

namespace Kasp.CloudMessage.FireBase.Models.Converters {
	public class BoolToIntConverter : JsonConverter {
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
			bool booleanValue = (bool) value;

			writer.WriteValue(Convert.ToInt32(booleanValue));
		}


		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
			throw new NotImplementedException();
		}

		public override bool CanConvert(Type objectType) {
			return typeof(bool) == objectType;
		}
	}
}