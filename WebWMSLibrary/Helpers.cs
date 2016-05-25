using System;
using System.Data;
using System.Configuration;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

namespace WebWMS
{
    public static class Helpers
    {
        public static int ConvertBoolToInt(bool input)
        {
            return (input == true ? 1 : 0);
        }

        public static string BuildSpecifyLengthString(int key)
        {
            string strvalue = key.ToString();
            if (key.ToString().Length == 1)
            {
                strvalue = "0" + key.ToString();
            }
            return strvalue;
        }
        /// <summary>
        /// ??????????????????
        /// </summary>
        /// <param name="permissions"></param>
        /// <returns></returns>
        public static string JoinInt(int[] nums, string splitStr)
        {
            if (nums == null || nums.Length == 0)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            bool hasComma = false;

            foreach (int num in nums)
            {
                if (hasComma)
                {
                    sb.Append(splitStr + num.ToString());
                }
                else
                {
                    sb.Append(num.ToString());
                    hasComma = true;
                }
            }

            return sb.ToString();
        }

        public static byte[] ReadBlog(object objStr)
        {
            byte[] outstr = null;
            if (objStr != DBNull.Value)
            {
                outstr = (byte[])objStr;
            }
            return outstr;
        }

        public static string ReadString(object objStr)
        {
            string outstr = string.Empty;
            if (objStr != DBNull.Value)
            {
                outstr = objStr.ToString().Trim();
            }
            return outstr;
        }
        
        public static long ReadLong(object objStr)
        {
            long outstr = 0;
            if (objStr != DBNull.Value)
            {
                outstr = long.Parse(objStr.ToString());
            }
            return outstr;
        }
        
        public static int ReadInt(object objStr)
        {
            int outstr = 0;
            if (objStr != DBNull.Value)
            {
                outstr = int.Parse(objStr.ToString());
            }
            return outstr;
        }

        public static Decimal ReadDecimal(object objStr)
        {
            Decimal outstr = Decimal.Zero;
            if (objStr != DBNull.Value)
            {
                if(objStr.ToString().Contains("."))
                {
                    outstr = Decimal.Parse(objStr.ToString().TrimEnd('0').TrimEnd('.'));
                }
                else
                {
                    outstr = Decimal.Parse(objStr.ToString());
                }
            }
            return outstr;
        }

        public static bool ReadBoolean(object objStr)
        {
            bool outstr = false;
            if (objStr != DBNull.Value)
            {
                outstr = bool.Parse(objStr.ToString());
            }
            return outstr;
        }

        public static DateTime ReadDateTime(object objStr)
        {
            DateTime outstr = DateTime.MinValue;
            if (objStr != DBNull.Value)
            {
                outstr = DateTime.Parse(objStr.ToString());
            }
            return outstr;
        }
    }
}


