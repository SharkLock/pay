using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lx.WxPay.Core.Helper
{
	public static class JsonHelper
	{
		private static readonly JsonConverter[] JavaScriptConverters = new JsonConverter[] { new DateTimeConverter() };

		public static string Serialize(object data)
		{
			return JsonConvert.SerializeObject(data, JavaScriptConverters);
		}

		public static object Deserialize(string json, Type targetType)
		{
			return JsonConvert.DeserializeObject(json, targetType);
		}

		public static T Deserialize<T>(string json)
		{
			return !string.IsNullOrWhiteSpace(json) ? JsonConvert.DeserializeObject<T>(json) : default(T);
		}
	}

	internal class DateTimeConverter : Newtonsoft.Json.Converters.DateTimeConverterBase
	{
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteValue(((DateTime)value).ToString("yyyy/MM/dd HH:mm:ss"));
		}
	}

}
