using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.WeiXin.PN.Receive
{
    public class RVideo
    {
        public long MediaId { get; set; }//	视频消息媒体id，可以调用多媒体文件下载接口拉取数据。
        public long ThumbMediaId { get; set; }//	视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据。
    }
}
