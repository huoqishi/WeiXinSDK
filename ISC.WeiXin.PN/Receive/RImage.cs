using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.WeiXin.PN.Receive
{
    public class RImage:BaseMsg
    {
        public string PicUrl { get; set; }//	图片链接
        public long MediaId { get; set; }//	图片消息媒体id，可以调用多媒体文件下载接口拉取数据。

    }
}
