using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI;

namespace Maticsoft.Common
{
    public class Common : System.Web.UI.Page
    {
        #region 获取MD5值
        /// <summary>
        /// 获取MD5值
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <returns></returns>
        public string MD5(string sourceString)
        {
            string result = "";
            byte[] b = System.Text.Encoding.Default.GetBytes(sourceString);
            b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
            for (int i = 0; i < b.Length; i++)
            {
                result += b[i].ToString("x").PadLeft(2, '0');
            }
            return result;
        }
        #endregion
        #region 弹出LAYER提示框，半透明提示框效果
        /// <summary>
        /// 弹出LAYER提示框，半透明提示框效果
        /// </summary>
        /// <param name="msgText">消息提示文本</param>
        /// <param name="page">当前要显示消息提示的窗口，一般转入this</param>
        public void MsgTrans(string msgText, Page page)
        {
            page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>layer.msg('" + msgText + "');</script>");
        }
        #endregion
        #region 弹出LAYER提示框并跳转到指定URL
        /// <summary>
        /// 弹出LAYER提示框并跳转到指定URL
        /// </summary>
        /// <param name="msgText">消息提示文本</param>
        /// <param name="url">跳转到URL</param>
        /// <param name="page">当前要显示消息提示的窗口，一般转入this</param>
        public void Msg(string msgText, string url, Page page)
        {
            page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>layer.alert('" + msgText + "',{icon:7,title:false,closeBtn:false},function(){window.location='" + url + "'});</script>");
        }
        #endregion
        #region 防SQL注入程序，可以替换SQL参数中的危险代码
        /// <summary>
        /// 防SQL注入程序，可以替换SQL参数中的危险代码
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <returns></returns>
        public string SQLFilter(string sourceString)
        {
            string result = "";
            if (!string.IsNullOrEmpty(sourceString))
            {
                result = sourceString;
                result = result.Replace("'", "&acute;");
                result = result.Replace("\"", "&quot;");
                result = result.Replace("<", "&lt;");
                result = result.Replace(">", "&gt;");
                result = result.Replace("&", "&amp;");
                result = result.Replace("=", "＝");
            }
            else
            {
                return "";
            }
            return result;
        }
        #endregion
        #region 弹出LAYER提示框并关闭父窗体
        /// <summary>
        /// 弹出LAYER提示框并关闭父窗体
        /// </summary>
        /// <param name="msgText">消息提示文本</param>
        /// <param name="page">当前要显示消息提示的窗口，一般转入this</param>
        public void MsgAndClose(string msgText, Page page)
        {
            page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>layer.alert('" + msgText + "',{icon:7,title:false,closeBtn:false},function(){CloseLayerWindow()});</script>");
        }
        #endregion
        #region 截取字符串，如果超出源字符串的长度不会报错，还可以自动加上占位符
        /// <summary>
        /// 截取字符串，如果超出源字符串的长度不会报错，还可以自动加上占位符
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <param name="length">截取长度</param>
        /// <param name="placeholder">占位符，注意：如果不要占位符就填写空字符串“”</param>
        /// <returns></returns>
        public string GetSubString(string sourceString, int length, string placeholder)
        {
            string result = "";
            if (sourceString.Length <= length)
            {
                result = sourceString;
            }
            else
            {
                result = sourceString.Substring(0, length);
                if (placeholder != "")
                {
                    result += placeholder;
                }
            }
            return result;
        }
        #endregion
        #region 输出图片路劲。如果路劲图片不存在则替换图片
        /// <summary>
        /// 输出图片路劲。如果路劲图片不存在则替换图片
        /// </summary>
        /// <param name="sourceImageURL">源图片路径及文件名</param>
        /// <returns></returns>
        public string GetImageURL(string sourceImageURL)
        {
            string result = sourceImageURL;
            if (!(result != "" && result != null))
            {
                result = "Images/noImage.gif";
            }
            return result;
        }
        #endregion
        #region 去除HTML标签以及特殊字符
        /// <summary>
        /// 去除HTML标签以及特殊字符
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <returns></returns>
        public string HTMLFilter(string sourceString)
        {
            string result = sourceString;
            result = Regex.Replace(result, "<[^>]+>", "");
            result = Regex.Replace(result, "lt;[^>]+gt;", "");
            result = Regex.Replace(result, "&[^;]+;", "");
            result = result.Replace("\r", "");
            result = result.Replace("\n", "");
            return result;
        }
        #endregion
        #region 加密解密字符串
        #region 使用 缺省密钥字符串 加密/解密string

        /// <summary>
        /// 使用缺省密钥字符串加密string
        /// </summary>
        /// <param name="original">明文</param>
        /// <returns>密文</returns>
        public static string Encrypt(string original)
        {
            return Encrypt(original, "MATICSOFT");
        }
        /// <summary>
        /// 使用缺省密钥字符串解密string
        /// </summary>
        /// <param name="original">密文</param>
        /// <returns>明文</returns>
        public static string Decrypt(string original)
        {
            return Decrypt(original, "MATICSOFT", System.Text.Encoding.Default);
        }

        #endregion

        #region 使用 给定密钥字符串 加密/解密string
        /// <summary>
        /// 使用给定密钥字符串加密string
        /// </summary>
        /// <param name="original">原始文字</param>
        /// <param name="key">密钥</param>
        /// <param name="encoding">字符编码方案</param>
        /// <returns>密文</returns>
        public static string Encrypt(string original, string key)
        {
            byte[] buff = System.Text.Encoding.Default.GetBytes(original);
            byte[] kb = System.Text.Encoding.Default.GetBytes(key);
            return Convert.ToBase64String(Encrypt(buff, kb));
        }

        /// <summary>
        /// 使用给定密钥字符串解密string,返回指定编码方式明文
        /// </summary>
        /// <param name="encrypted">密文</param>
        /// <param name="key">密钥</param>
        /// <param name="encoding">字符编码方案</param>
        /// <returns>明文</returns>
        public static string Decrypt(string encrypted, string key, Encoding encoding)
        {
            byte[] buff = Convert.FromBase64String(encrypted);
            byte[] kb = System.Text.Encoding.Default.GetBytes(key);
            return encoding.GetString(Decrypt(buff, kb));
        }
        #endregion

        #region  使用 给定密钥 加密/解密/byte[]

        /// <summary>
        /// 生成MD5摘要
        /// </summary>
        /// <param name="original">数据源</param>
        /// <returns>摘要</returns>
        public static byte[] MakeMD5(byte[] original)
        {
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            byte[] keyhash = hashmd5.ComputeHash(original);
            hashmd5 = null;
            return keyhash;
        }


        /// <summary>
        /// 使用给定密钥加密
        /// </summary>
        /// <param name="original">明文</param>
        /// <param name="key">密钥</param>
        /// <returns>密文</returns>
        public static byte[] Encrypt(byte[] original, byte[] key)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = MakeMD5(key);
            des.Mode = CipherMode.ECB;

            return des.CreateEncryptor().TransformFinalBlock(original, 0, original.Length);
        }

        /// <summary>
        /// 使用给定密钥解密数据
        /// </summary>
        /// <param name="encrypted">密文</param>
        /// <param name="key">密钥</param>
        /// <returns>明文</returns>
        public static byte[] Decrypt(byte[] encrypted, byte[] key)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = MakeMD5(key);
            des.Mode = CipherMode.ECB;

            return des.CreateDecryptor().TransformFinalBlock(encrypted, 0, encrypted.Length);
        }

        #endregion 
        #endregion
    }
}
