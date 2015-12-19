using ISC.WeiXin.PN.Helper;
using ISC.WeiXin.PN.MessageHandle;
using ISC.WeiXin.PN.Receive;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ISC.Wei.Xin.PN
{
    /// <summary>
    /// 颁发不同的微信请求
    /// </summary>
    public class WxApiDispatch
    {
        private XElement xml = null;
        private WxApiDispatch() { }

        /// <summary>
        /// 获取请求的xml数据
        /// </summary>
        /// <param name="stream"></param>
        public WxApiDispatch(Stream stream)//Request.InputStream
        {
            
            using (stream)
            {
                Byte[] postBytes = new Byte[stream.Length];
                stream.Read(postBytes, 0, (Int32)stream.Length);
                var postString = Encoding.UTF8.GetString(postBytes);
                xml = XElement.Parse(postString);

            }
        }

        /// <summary>
        /// 处理不同请求
        /// </summary>
        /// <returns></returns>
        public string Dispatch()
        {
            if (xml==null)
            {
                return string.Empty;
            }
            //XElement root=new XElement("xml",
            //    new XElement("ToUserName","kkisc"),
            //    new XElement("FromUserName","scikk"));
            //return string.Empty;
            var result = string.Empty;
            //获取消息对应枚举类型
            var msgType = (RequestMsgType)Enum.Parse(typeof(RequestMsgType), xml.Element("MsgType").Value, true);
            #region 判断消息类型
            switch (msgType)
            {
                case RequestMsgType.Text:
                    RText rtext = new RText();
                    rtext = XmlHelper.GetModel<RText>(rtext, xml);
                    MsgHandle mh = new MsgHandle();
                    result= mh.TextHandle(rtext);//处理相关逻辑
                    break;
                case RequestMsgType.Image: break;
                case RequestMsgType.Voice: break;
                case RequestMsgType.Video: break;
                case RequestMsgType.Location: break;
                case RequestMsgType.Link: break;
                #region 事件
                case RequestMsgType.Event:
                    //获取事件对应枚举类型
                    var eventType=(Event)Enum.Parse(typeof(Event), xml.Element("Event").Value, true);
                    switch (eventType)
                    {
                        case Event.subscribe: break;
                        case Event.unsubscribe: break;
                        case Event.scan: break;
                        case Event.LOCATION: break;
                        case Event.CLICK: break;
                        case Event.VIEW://自定义菜单跳转
                            break;
                        default:
                            break;
                    }
                    break;
                #endregion
                default:
                    break;
            }
            #endregion
            return result;
        }
    }
}
