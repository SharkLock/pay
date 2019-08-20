using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lx.WxPay.Core
{
	/// <summary>
	/// 
	/// </summary>
	public class UnifiedOrderModelForApp
	{
		/// <summary>
		/// 商户号
		/// </summary>
		[JsonProperty("partnerid")]
		public string PartnerId { get; set; }
		/// <summary>
		/// 预支付交易会话标识
		/// </summary>
		[JsonProperty("prepayid")]
		public string PrepayId { get; set; }
		/// <summary>
		/// 签名
		/// </summary>
		[JsonProperty("sign")]
		public string Sign { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("appid")]
		public string AppId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("timestamp")]
		public string TimeStamp { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("noncestr")]
		public string NonceStr { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("package")]
		public string Package { get; set; }
	}
}
