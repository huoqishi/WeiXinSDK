using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Xml.Linq;

using ISC.WeiXin.PN.Helper;
using ISC.Wei.Xin.PN;
namespace Senparc.Weixin.MP.Sample.Controllers
{
    public  class WeiXinController : Controller
    {
        public static readonly string Token = wxArg.Token;//与微信公众账号后台的Token设置保持一致，区分大小写。
        //public static readonly string EncodingAESKey = WebConfigurationManager.AppSettings["WeixinEncodingAESKey"];//与微信公众账号后台的EncodingAESKey设置保持一致，区分大小写。
        public static readonly string AppId = wxArg.AppId;//与微信公众账号后台的AppId设置保持一致，区分大小写。
        //readonly Func<string> _getRandomFileName = () => DateTime.Now.Ticks + Guid.NewGuid().ToString("n").Substring(0, 6);

        /// <summary>
        /// 微信后台验证地址（使用Get），微信后台的“接口配置信息”的Url填写如：http://weixin.senparc.com/weixin
        /// </summary>
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get(string signature, string timestamp, string nonce, string echostr)
        {
            if (CheckSignature.Check(signature, timestamp,nonce, Token))
            {
                return Content(echostr);//返回随机字符串则表示验证通过
            }
            else
            {
                return Content("failed:" + signature + "," + CheckSignature.GetSignature(timestamp, nonce, Token) + "。如果你在浏览器中看到这句话，说明此地址可以被作为微信公众账号后台的Url，请注意保持Token一致。");
            }
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult Post(string signature, string timestamp, string nonce, string echostr)
        {
            if (!CheckSignature.Check(signature, timestamp, nonce, Token))
            {
                return Content("参数错误！");
            }

            WxApiDispatch wad = new WxApiDispatch(Request.InputStream);
            return Content(wad.Dispatch());

            //postModel.Token = Token;
            //postModel.EncodingAESKey = EncodingAESKey;//根据自己后台的设置保持一致
            //postModel.AppId = AppId;//根据自己后台的设置保持一致

            //var messageHandler = new CustomMessageHandler(Request.InputStream, postModel);//接收消息

            //messageHandler.Execute();//执行微信处理过程

            //return new WeixinResult(messageHandler);//返回结果
        }
    }
}
