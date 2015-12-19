using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.WeiXin.PN.Send
{
    public class SText
    {
        public string ToUserName { get; set; }// 用户号（OpenID）
        public string FromUserName { get; set; }// 开发者微信号

        public long CreateTime { get; set; }// 创建时间

        public string MsgType { get { return "text"; } } //消息类型

        public string Content { get; set; }//内容
    }
}
