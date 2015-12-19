using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.WeiXin.PN.Receive
{

    /// <summary>
    /// 自定义菜单点击
    /// </summary>
    public class RMenuClick:BaseEvent
    {
        public string EventKey { get; set; }//事件key

    }

}
