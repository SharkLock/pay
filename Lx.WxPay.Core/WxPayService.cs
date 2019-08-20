using Lx.WxPay.Core.Helper;
using Senparc.Weixin.TenPay.V3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lx.WxPay.Core
{
	public class WxPayService
	{
		const string Success = "SUCCESS";
		const string Fail = "FAIL";
		/// <summary>
		/// 此处配置信息需要持久保存
		/// </summary>
		const string AccStr =
			"{" +
				"\"AppId\":\"AppIdAppIdAppIdAppIdAppId\"," + //微信公众号的AppId或者App申请的微信AppId
				"\"MchIdKey\":\"商户支付密钥商户支付密钥商户支付密钥\"," +//商户支付密钥
				"\"MchId\":\"商户号商户号商户号\"," +//商户号
				"\"NotifyUrl\":\"http://www.XXXXXX.com/WxNotify/Index\"" +//微信回调地址
			"}";
		#region 微信支付 
		/// <summary>
		/// 微信支付下单
		/// JsAPI下单部分
		/// </summary>
		/// <param name="reqmodel"></param>
		/// <returns></returns>
		public UnifiedOrderModelForJSAPI WxPayUnifiedOrderForJSAPI(RequestUnifiedOrder reqmodel)
		{
			try
			{
				var wxPayAcc = JsonHelper.Deserialize<WxPayAccVM>(AccStr);
				var nonceStr = TenPayV3Util.GetNoncestr();
				var timeStamp = TenPayV3Util.GetTimestamp();
				//此处填入此支付附加信息
				var attach = string.Empty;
				var xmlDataInfo = new TenPayV3UnifiedorderRequestData(wxPayAcc.AppId, wxPayAcc.MchId, reqmodel.Body,
					reqmodel.OutTradeNo, reqmodel.TotalFee, reqmodel.SpbillCreateIp, wxPayAcc.NotifyUrl, Senparc.Weixin.TenPay.TenPayV3Type.JSAPI,
					reqmodel.OpenId, wxPayAcc.MchIdKey, nonceStr, null, null, null, null, attach);
				var result = TenPayV3.Html5Order(xmlDataInfo);//调用统一订单接口
				var package = string.Format("prepay_id={0}", result.prepay_id);
				var paySign = TenPayV3.GetJsPaySign(wxPayAcc.AppId, timeStamp, nonceStr, package, wxPayAcc.MchIdKey);
				var model = new UnifiedOrderModelForJSAPI
				{
					AppId = result.appid,
					NonceStr = nonceStr,
					TimeStamp = timeStamp,
					Package = package,
					SignType = "MD5",
					PaySign = paySign
				};
				return model;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		/// <summary>
		/// 微信支付下单
		/// APP下单部分
		/// </summary>
		/// <param name="reqmodel"></param>
		/// <returns></returns>
		public UnifiedOrderModelForApp WxPayUnifiedOrderByApp(RequestUnifiedOrder reqmodel)
		{
			try
			{
				var wxPayAcc = JsonHelper.Deserialize<WxPayAccVM>(AccStr);
				var nonceStr = TenPayV3Util.GetNoncestr();
				var timeStamp = TenPayV3Util.GetTimestamp();
				//此处填入此支付附加信息
				var attach = string.Empty;
				var xmlDataInfo = new TenPayV3UnifiedorderRequestData(wxPayAcc.AppId, wxPayAcc.MchId, reqmodel.Body,
					reqmodel.OutTradeNo, reqmodel.TotalFee,
					reqmodel.SpbillCreateIp, wxPayAcc.NotifyUrl, Senparc.Weixin.TenPay.TenPayV3Type.APP,
					null, wxPayAcc.MchIdKey, nonceStr, null, null, null, null, attach);

				var response = TenPayV3.Unifiedorder(xmlDataInfo);//调用统一订单接口
				if (response.result_code != Success || response.return_code != Success) throw new Exception("微信App统一下单失败,请检查参数是否配置正确");
				//重新获取混淆信息以及时间戳
				nonceStr = TenPayV3Util.GetNoncestr();
				timeStamp = TenPayV3Util.GetTimestamp();
				var signData = new UnifiedOrderModelForApp
				{
					AppId = wxPayAcc.AppId,
					PartnerId = wxPayAcc.MchId,
					PrepayId = response.prepay_id,
					Package = "Sign=WXPay",
					NonceStr = nonceStr,
					TimeStamp = timeStamp
				};
				//构建签名词典
				var sParams = new SortedDictionary<string, string>{
					{ "appid", wxPayAcc.AppId },
					{ "partnerid", wxPayAcc.MchId },
					{ "prepayid", response.prepay_id },
					{ "package", "Sign=WXPay" },
					{ "noncestr",nonceStr },
					{ "timestamp",timeStamp}
				};
				var li = new List<string>();
				//拼接部分
				foreach (KeyValuePair<string, string> temp in sParams) li.Add(temp.Key + "=" + temp.Value);
				//在最后追加支付密钥
				li.Add("key=" + wxPayAcc.MchIdKey.Trim());
				//MD5处理部分
				MD5CryptoServiceProvider m5 = new MD5CryptoServiceProvider();
				var inputBye = Encoding.UTF8.GetBytes(string.Join("&", li));
				var outputBye = m5.ComputeHash(inputBye);
				signData.Sign = BitConverter.ToString(outputBye).Replace("-", "").ToUpper();
				return signData;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		#endregion


		/// <summary>
		/// 微信支付回调
		/// XML字符串封装进对象
		///调用示例:
		///	var stringData = new StreamReader(System.Web.HttpContext.Current.Request.InputStream).ReadToEnd();
		///	var para= XmlHelper.Deserialize<WxNotifyVM>(stringData);
		///	var rr = WxPayCalBack(para.CmpCode, para);
		/// </summary>
		/// <param name="cmpCode"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		public WxNotifyResultVM WxPayCalBack(string cmpCode, WxNotifyVM para)
		{
			try
			{
				if (string.Compare(para.ResultCode, Success) == 0)
				{
					if (true)//微信正常回调商户系统处理逻辑
					{
						return new WxNotifyResultVM()
						{
							ReturnCode = "SUCCESS",
							ReturnMsg = "OK"
						};
					}
				}
			}
			catch (Exception ex)
			{
				return new WxNotifyResultVM()
				{
					ReturnCode = "FAIL",
					ReturnMsg = ex.Message
				};
			}
			return new WxNotifyResultVM();
		}
	}
}
