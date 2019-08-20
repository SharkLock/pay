using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Lx.WxPay.Core
{
	[Serializable]
	[XmlRoot("xml")]
	public class WxNotifyResultVM : IXmlSerializable
	{
		/// <summary>
		/// SUCCESS
		/// FAIL
		/// </summary>
		[XmlElement("return_code")]
		public string ReturnCode { get; set; }
		/// <summary>
		/// OK
		/// 失败原因
		/// </summary>
		[XmlElement("return_msg")]
		public string ReturnMsg { get; set; }

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteStartElement("ReturnCode");
			writer.WriteCData(this.ReturnCode);
			writer.WriteEndElement();

			writer.WriteStartElement("ReturnMsg");
			writer.WriteCData(this.ReturnMsg);
			writer.WriteEndElement();
		}
		public XmlSchema GetSchema()
		{
			return default(XmlSchema);
		}
		public void ReadXml(XmlReader reader)
		{
			this.ReturnMsg = reader.ReadElementContentAsString("ReturnMsg", "");
			this.ReturnCode = reader.ReadElementContentAsString("ReturnCode", "");
		}

		/// <summary>
		/// 获取对接微信的返回值
		/// </summary>
		/// <returns></returns>
		public string GetWxNotifyXmlResultStr()
		{
			XmlSerializer xs = new XmlSerializer(this.GetType());
			var xml = string.Empty;
			using (MemoryStream writer = new MemoryStream())
			{
				xs.Serialize(writer, this);
				xml = Encoding.UTF8.GetString(writer.GetBuffer());
			}
			xml = xml.Replace("<?xml version=\"1.0\"?>", string.Empty).Replace("\r\n", string.Empty);
			return xml;
		}

	}
}
