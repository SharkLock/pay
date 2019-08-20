using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lx.WxPay.Core
{
	public class RequestUnifiedOrder
	{
		/// <summary>
		/// 商品描述
		/// </summary>
		public string Body { get; set; }
		/// <summary>
		/// 商品详情
		/// </summary>
		public string Detail { get; set; }

		/// <summary>
		/// 商户订单号
		/// </summary>
		public string OutTradeNo { get; set; }
		/// <summary>
		/// 总金额
		/// </summary>
		public int TotalFee { get; set; }
		/// <summary>
		/// 终端IP
		/// </summary>
		public string SpbillCreateIp { get; set; }

		/// <summary>
		/// openid
		/// </summary> 
		public string OpenId { get; set; }
		/// <summary>
		/// 统一下单类型
		/// 微信支付JSAPI/APP
		/// </summary>
		public string TradeType { get; set; } 
	}
}
