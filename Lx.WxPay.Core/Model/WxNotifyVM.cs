using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lx.WxPay.Core
{
	/// <summary>
	/// 微信回调对象
	/// </summary>
	[Serializable]
	[XmlRoot("xml")]
	public class WxNotifyVM
	{
		[XmlElement("appid")]
		public string AppId { get; set; }
		[XmlElement("attach")]
		public string Attach { get; set; }
		[XmlElement("bank_type")]
		public string BankType { get; set; }
		[XmlElement("cash_fee")]
		public string CashFee { get; set; }
		[XmlElement("fee_type")]
		public string FeeType { get; set; }
		[XmlElement("is_subscribe")]
		public string IsSubscribe { get; set; }
		[XmlElement("mch_id")]
		public string MchId { get; set; }
		[XmlElement("nonce_str")]
		public string NonceStr { get; set; }
		[XmlElement("openid")]
		public string OpenId { get; set; }
		[XmlElement("out_trade_no")]
		public string OutTradeNo { get; set; }
		[XmlElement("result_code")]
		public string ResultCode { get; set; }
		[XmlElement("return_code")]
		public string ReturnCode { get; set; }
		[XmlElement("sign")]
		public string Sign { get; set; }
		[XmlElement("time_end")]
		public string TimeEnd { get; set; }
		[XmlElement("total_fee")]
		public string TotalFee { get; set; }
		[XmlElement("trade_type")]
		public string TradeType { get; set; }
		[XmlElement("transaction_id")]
		public string TransactionId { get; set; } 
	}
}
