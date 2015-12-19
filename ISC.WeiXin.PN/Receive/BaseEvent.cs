using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.WeiXin.PN.Receive
{
    public abstract class BaseEvent : BaseReceive
    {
        public string Event { get; set; }//事件类型
    }
}
