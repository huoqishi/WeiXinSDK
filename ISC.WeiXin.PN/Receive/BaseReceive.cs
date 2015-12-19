using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.WeiXin.PN.Receive
{
    public abstract class  BaseReceive
    {
        public string ToUserName { get; set; }//接收者微信(OpenID)
        public string FromUserName { get; set; }//发送者微信(OpenID)
        public long CreateTime { get; set; }//创建时间
        public string MsgType { get; set; }//消息类型
    }
}
