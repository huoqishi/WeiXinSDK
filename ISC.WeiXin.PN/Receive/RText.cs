using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.WeiXin.PN.Receive
{
    /// <summary>
    /// 文本消息
    /// </summary>
    public class RText:BaseMsg
    {
        public string Content { get; set; }//消息内容
    }
}
