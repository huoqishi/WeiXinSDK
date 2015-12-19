using ISC.WeiXin.PN.Helper;
using ISC.WeiXin.PN.Receive;
using ISC.WeiXin.PN.Send;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ISC.WeiXin.PN.MessageHandle
{
    public class MsgHandle
    {
        /// <summary>
        /// 文本消息处理
        /// </summary>
        /// <param name="rtxt"></param>
        /// <returns></returns>
        public string TextHandle(RText rtxt)
        {
            var stxt = new SText();
            var resutl=string.Empty;
            switch (rtxt.Content)
            {
                case "111":
                    stxt.Content = "嘻嘻";
                    stxt.CreateTime = MySharpUtility.GetTimeSpan();
                    stxt.FromUserName = rtxt.ToUserName;
                    stxt.ToUserName = rtxt.FromUserName;
                    resutl = XmlHelper.GetXML<SText>(stxt);
                    break;
                default:
                    break;
            }
            //new XmlSerializer(typeof(SText)).Serialize(;
            return resutl;
        }

        /// <summary>
        /// 图片消息处理
        /// </summary>
        /// <param name="rimg"></param>
        /// <returns></returns>
        public RImage ImageHandle(RImage rimg)
        {
            return null;
        }
    }
}
