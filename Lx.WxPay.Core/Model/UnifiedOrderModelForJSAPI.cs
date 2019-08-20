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
	public class UnifiedOrderModelForJSAPI
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("signType")]
		public string SignType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("paySign")]
		public string PaySign { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("appId")]
		public string AppId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("timeStamp")]
		public string TimeStamp { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("nonceStr")]
		public string NonceStr { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("package")]
		public string Package { get; set; }
	}
}
