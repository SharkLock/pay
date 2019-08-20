using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lx.WxPay.Core
{
    public class WxPayAccVM
    {
        /// <summary>
        /// AppId
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 支付密钥
        /// </summary>
        public string MchIdKey { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        public string MchId { get; set; }
        /// <summary>
        /// 通知地址
        /// </summary>
        public string NotifyUrl { get; set; }

    }
}
