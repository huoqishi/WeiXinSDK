/*----------------------------------------------------------------
    Copyright (C) 2015
    文件名：CheckSignature.cs
    文件功能描述：微信签名siim
----------------------------------------------------------------*/
using ISC.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.WeiXin.PN.Helper
{
    public class CheckSignature
    {
        #region 检查签名是否正确 +Check(string signature, string timestamp, string nonce, string token)
        /// <summary>
        /// 检查签名是否正确
        /// </summary>
        /// <param name="signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool Check(string signature, string timestamp, string nonce, string token)
        {
            return string.Equals(signature, GetSignature(timestamp, nonce, token), StringComparison.InvariantCultureIgnoreCase);
        } 
        #endregion

        #region 获取签名 +GetSignature(string timestamp, string nonce, string token = null)
        /// <summary>
        /// 获取签名
        /// </summary>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string GetSignature(string timestamp, string nonce, string token)
        {
            var list = new List<string> { timestamp, nonce, token };
            list.Sort();
            return SHA1UtilHelper.GetSha1(string.Join("", list));
        } 
        #endregion
    }
}
