using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lx.WxPay.Core.Helper
{
	/// <summary>
	/// Xml帮助类
	/// </summary>
	public class XmlHelper
	{
		/// <summary>
		/// 将Xml字符串反序列化成对象
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="xmlStr"></param>
		/// <returns></returns>
		public static T Deserialize<T>(string xmlStr) where T : new()
		{
			if (string.IsNullOrWhiteSpace(xmlStr)) return default(T);
			using (MemoryStream ms1 = new MemoryStream(Encoding.UTF8.GetBytes(xmlStr)))
			{
				XmlSerializer xs = new XmlSerializer(typeof(T)); 
				var obj = (T)xs.Deserialize(ms1);
				return obj;
			}
		}
		/// <summary>
		/// 将对象序列化成Xml字符串
		/// 特性配置注意参考以下两个类
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="data"></param>
		/// <returns></returns>
		public static string Serialize<T>(T data) where T : new()
		{
			XmlSerializer xs = new XmlSerializer(data.GetType());
			var xml = string.Empty;
			using (MemoryStream writer = new MemoryStream())
			{
				xs.Serialize(writer, data);
				xml = Encoding.UTF8.GetString(writer.GetBuffer());
			}
			return xml;
		}
	}
}
