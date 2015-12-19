/*----------------------------------------------------------------
    Copyright (C) 2015
    文件名：XmlHelper.cs
    文件功能描述：微信XML与Model转换
    修改描述：整理接口
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ISC.WeiXin.PN.Helper
{
    /// <summary>
    /// XMl与Model之前的相互映射
    /// </summary>
    public class XmlHelper
    {
        #region 通过反射给Model赋值,微信消息对应的Model +GetModel<T>(T model, XElement xml) where T : class
        /// <summary>
        /// 通过反射给Model赋值,微信消息对应的Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="xmlModel"></param>
        /// <returns></returns>
        public static T GetModel<T>(T model, XElement xml) where T : class
        {
            var m = model.GetType();
            foreach (PropertyInfo p in m.GetProperties())
            {
                string name = p.Name;
                var value = xml.Element(name).Value;
                if (value != null)
                {
                    p.SetValue(model, Convert.ChangeType(value, p.PropertyType));
                }
            }
            return model;
        }


        #endregion

        #region 序列化获得xml,性能高一些 +GetXmlSerializer<T>(T entity)
        /// <summary>
        /// 序列化获得xml,性能高一些
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>

        public static string GetXmlSerializer<T>(T entity)
        {
            StringBuilder buffer = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            //XmlWriterSettings settings = new XmlWriterSettings();
            //settings.OmitXmlDeclaration = true;//这一句表示忽略xml声明
            //settings.Indent = true;
            //settings.Encoding = Encoding.UTF8;
            using (TextWriter writer = new StringWriter(buffer))
            {
                serializer.Serialize(writer, entity);
            }
            return buffer.ToString();

        }
        #endregion

        #region 反射获取Xml +GetXML<T>(T model) where T : class
        /// <summary>
        /// 反射获取Xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string GetXML<T>(T model) where T : class
        {
            XElement xml = new XElement("xml");

            var m = model.GetType();
            XElement item;
            foreach (PropertyInfo p in m.GetProperties())
            {
                string name = p.Name;
                var value = p.GetValue(model);
                if (value != null)
                {
                    xml.Add(new XElement(name, value));
                }
                else
                {
                    xml.Add(new XElement(name, string.Empty));
                }
            }
            return xml.ToString();
        }
        #endregion
    }
}
