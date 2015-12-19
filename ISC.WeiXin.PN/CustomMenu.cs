using Huoqishi.ISC;
using ISC.Wei.Xin.PN;
using ISC.WeiXin.PN.Helper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.WeiXin.PN
{
    /// <summary>
    /// 处理自定义菜单
    /// </summary>
    public class CustomMenu
    {
        /// <summary>
        /// 获取通过api设置的菜单配置
        /// </summary>
        /// <returns></returns>
        public static string GetMenuByApi()
        {
            return null;
        }

        /// <summary>
        /// 获取菜单配置
        /// </summary>
        public static string GetMenu() {
            var access_token = wxArg.Access_Token;
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/get_current_selfmenu_info?access_token={0}", access_token);
            var result = string.Empty;
            result = MyHttpUtility.Get(url);
            //JObject jobj = JObject.Parse(result);
            return result;
        }

        /// <summary>
        /// 创建自定义菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public static string CreatMenu(string menu) {
            var access_token = wxArg.Access_Token;
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", access_token);
            return MyHttpUtility.Post(url, menu);
        }
    }
}
