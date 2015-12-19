using DotNet4.Utilities;
using ISC.WeiXin.PN.Helper;
using ISC.WeiXin.PN.Receive;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region http xml
            //HttpHelper http=new HttpHelper();
         //HttpItem item=new HttpItem{
         //    URL = "http://sxqs.ishuchang.net:8082/home/GetPro",
         //    Method="post",
         //    ContentType = "application/json"
         //};
         //HttpResult resutl = http.GetHtml(item);
            
         //var rtxt = new RText { 
         //    Content="我是中国人，我爱自己的神兽",
         //    CreateTime=123432323,
         //    FromUserName="sefefafawefawfaefaf",
         //    ToUserName="fasjlkfjaiefja;wlfkj;322",
         //    MsgId=32324829482
         //};
         ////var xmlf=XmlSerialize<RText>(rtxt);
         ////Console.WriteLine(xmlf);
         //Stopwatch sw = new Stopwatch();
         //var count = 10;
         //sw.Start();
         //for (int i = 0; i < count; i++)
         //{
         //    //var s = wxArg.GetXml<RText>(rtxt);
         //}
         //sw.Stop();
         //Console.WriteLine(sw.Elapsed);
         //Console.WriteLine(sw.ElapsedMilliseconds);
         //Console.WriteLine(sw.ElapsedTicks);
         //Console.WriteLine("-----------------");
         //sw.Start();
         //for (int i = 0; i < count; i++)
         //{
         //    //var s2 = wxArg.GetXML2<RText>(rtxt);
         //}
         //sw.Stop();
         //Console.WriteLine(sw.Elapsed);
         //Console.WriteLine(sw.ElapsedMilliseconds);
         //Console.WriteLine(sw.ElapsedTicks);
            
            

        //http://sxqs.ishuchang.net:8082/home/GetPro


//            XElement root = new XElement("xml",
//    new XElement("ToUserName", " kkisc "),
//    new XElement("FromUserName", "<A></A>"));
//            Console.WriteLine(root.ToString());
//            Console.WriteLine(root.ToString(SaveOptions.DisableFormatting));
//            var root2 = XElement.Parse(@"<xml>
//  <ToUserName> kkisc </ToUserName>
//  <FromUserName>scikk</FromUserName>
//</xml>");
//            root2.Element("ToUserName").Value="爱舒畅";
            //            Console.WriteLine(root2.ToString());
            #endregion
            Stopwatch sw = new Stopwatch();
            var str = "sf;74928fj;alsfkja;l3aow8faj:3ofajf;a";
            var count = 100000;
            sw.Start();
            for (int i = 0; i < count; i++)
            {
                var s=GetSha1(str);
                s.ToLower();
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            sw.Start();
            for (int i = 0; i < count; i++)
            {
                Encrypted(str);
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine(GetSha1(str));
            Console.WriteLine(Encrypted(str));
            Console.ReadLine();
        }
        private static string Encrypted(string targetPassword)
        {
            byte[] hash = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(targetPassword));
            StringBuilder hex = new StringBuilder();
            foreach (var item in hash)
            {
                hex.AppendFormat("{0:x2}", item);
            }
            return hex.ToString();
        }
        /// <summary>
        /// 签名算法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetSha1(string str)
        {
            //建立SHA1对象
            SHA1 sha = new SHA1CryptoServiceProvider();
            //将mystr转换成byte[] 
            ASCIIEncoding enc = new ASCIIEncoding();
            byte[] dataToHash = enc.GetBytes(str);
            //Hash运算
            byte[] dataHashed = sha.ComputeHash(dataToHash);
            //将运算结果转换成string
            string hash = BitConverter.ToString(dataHashed).Replace("-", "");
            return hash;
        }
        public static string XmlSerialize<T>(T obj)
        {
            if (obj == null) return string.Empty;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;//这一句表示忽略xml声明
                settings.Indent = true;
                settings.Encoding = Encoding.UTF8;
                var xml = string.Empty;
                using (XmlWriter xtw = XmlWriter.Create(memoryStream, settings))
                {
                    
                    XmlSerializerNamespaces xln=new XmlSerializerNamespaces();
                    xln.Add("","");
                    xmlSerializer.Serialize(xtw, obj,xln);
                    memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                    using (System.IO.StreamReader streamReader = new System.IO.StreamReader(memoryStream, Encoding.UTF8))
                    {
                        xml=streamReader.ReadToEnd();                    
                    }
                  
                }

                return xml;
            }
        }
    }
}
