using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.WeiXin.PN.Receive
{
    public abstract class BaseMsg : BaseReceive
    {
        public long MsgId { get; set; }//消息ID
    }
}
