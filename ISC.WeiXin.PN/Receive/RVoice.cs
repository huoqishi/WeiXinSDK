using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.WeiXin.PN.Receive
{
    /// <summary>
    /// 语音消息
    /// </summary>
    public class RVoice:BaseMsg
    {
        public long MediaId { get; set; }	//语音消息媒体id，可以调用多媒体文件下载接口拉取数据。
        public string Format { get; set; }	//语音格式，如amr，speex等
    }
}
