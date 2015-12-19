/*----------------------------------------------------------------
    Copyright (C) 2015
    文件名：SHA1UtilHelper.cs
    文件功能描述：SHA1签名算法
    修改描述：整理接口
----------------------------------------------------------------*/

using System;
using System.Security.Cryptography;
using System.Text;

namespace ISC.Helper
{
    public class SHA1UtilHelper
    {
        /// <summary>
        /// 签名算法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetSha1(string str)
        {
            //建立SHA1对象
            SHA1 sha = new SHA1CryptoServiceProvider();
            //将str转换成byte[] 
            ASCIIEncoding enc = new ASCIIEncoding();
            byte[] dataToHash = enc.GetBytes(str);
            //Hash运算
            byte[] dataHashed = sha.ComputeHash(dataToHash);
            //将运算结果转换成string
            string hash = BitConverter.ToString(dataHashed).Replace("-", "");
            return hash;
        }
    }
}