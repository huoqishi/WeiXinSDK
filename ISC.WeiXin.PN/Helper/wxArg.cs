/*
 * 维护access_token,appid 等数据，过期自动更新
 * 
 */
using Huoqishi.ISC;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ISC.WeiXin.PN.Helper
{
    /// <summary>
    /// 处理微的一些常用变量。如appid等
    /// </summary>
    public class wxArg
    {
        private static string access_Token;
        private static DateTime Access_Token_Time;//最后从微信服务器更新的access_Token时间
        private static int Access_Token_Expire;//微信access_Token过期时间（单位:秒);
        //https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=APPID&secret=APPSECRET
        private static  string access_token_ulr = "https://api.weixin.qq.com/cgi-bin/token";//获取微信access_Token接口

        private static string appsecret;//微信公众号appsecret

        private static string appid;//微信公众号appid
        private static string token;//微信公众平台填写的token 

        #region 返回微信token +Token
        /// <summary>
        /// 返回微信token
        /// </summary>
        public static string Token
        {
            get
            {
                if (string.IsNullOrEmpty(token))
                {
                    token = WebConfigurationManager.AppSettings.Get("WeixinToken");
                }
                return token;
            }
        }
        #endregion

        #region 返回appid +AppId
        /// <summary>
        /// 返回appid
        /// </summary>
        public static string AppId
        {
            get
            {
                if (string.IsNullOrEmpty(appid))
                {
                    appid = WebConfigurationManager.AppSettings.Get("WeixinAppId");
                }
                return appid;
            }
        }
        #endregion

        #region 返回 appsecret +AppSecret
        /// <summary>
        /// 返回 appsecret
        /// </summary>
        public static string AppSecret
        {
            get
            {
                if (string.IsNullOrEmpty(appsecret))
                {
                    appsecret = WebConfigurationManager.AppSettings.Get("WeixinAppSecret");
                }
                return appsecret;
            }
        }
        #endregion

        #region 获取access_Token +Access_Token
        /// <summary>
        /// 获取access_Token
        /// </summary>
        public static string Access_Token
        {
            get
            {
                TimeSpan ts = DateTime.Now - Access_Token_Time;
                //access_token为空的情况
                if (string.IsNullOrEmpty(access_Token) || ts.TotalSeconds > Access_Token_Expire)
                {
                    var url =string.Format(access_token_ulr + "?grant_type={0}&appid={1}&secret={2}", "client_credential", AppId, AppSecret);
                    var result = MyHttpUtility.Get(url);//access_Token
                    JObject jobj = JObject.Parse(result);
                    access_Token = (string)jobj["access_token"];
                    Access_Token_Expire = (int)jobj["expires_in"];
                    Access_Token_Time = DateTime.Now;
                }
                return access_Token;
            }
        }
        #endregion

    }
}
