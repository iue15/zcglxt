using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.Common;

using System.Security.Cryptography;
using System.IO;

namespace WebWMS.DAL
{
    public abstract class DataAccess
    {
        private string _connectionString = "";
        protected string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        private bool _enableCaching = true;
        protected bool EnableCaching
        {
            get { return _enableCaching; }
            set { _enableCaching = value; }
        }

        private int _cacheDuration = 0;
        protected int CacheDuration
        {
            get { return _cacheDuration; }
            set { _cacheDuration = value; }
        }

        protected int ExecuteNonQuery(DbCommand cmd)
        {
            int ret = -1;
            foreach (DbParameter param in cmd.Parameters)
            {
                if (param.Direction == ParameterDirection.Output ||
                   param.Direction == ParameterDirection.ReturnValue)
                {
                    switch (param.DbType)
                    {
                        case DbType.AnsiString:
                        case DbType.AnsiStringFixedLength:
                        case DbType.String:
                        case DbType.StringFixedLength:
                        case DbType.Xml:
                            param.Value = "";
                            break;
                        case DbType.Boolean:
                            param.Value = false;
                            break;
                        case DbType.Byte:
                            param.Value = byte.MinValue;
                            break;
                        case DbType.Date:
                        case DbType.DateTime:
                            param.Value = DateTime.MinValue;
                            break;
                        case DbType.Currency:
                        case DbType.Decimal:
                            param.Value = decimal.MinValue;
                            break;
                        case DbType.Guid:
                            param.Value = Guid.Empty;
                            break;
                        case DbType.Double:
                        case DbType.Int16:
                        case DbType.Int32:
                        case DbType.Int64:
                            param.Value = 0;
                            break;
                        default:
                            param.Value = null;
                            break;
                    }
                }
            }

            try
            {
                ret = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ew)
            {
                throw new Exception(ew.Message);

            }

            return ret;
        }

        protected IDataReader ExecuteReader(DbCommand cmd)
        {
            return ExecuteReader(cmd, CommandBehavior.Default);
        }

        protected IDataReader ExecuteReader(DbCommand cmd, CommandBehavior behavior)
        {
            return cmd.ExecuteReader(behavior);
        }

        protected object ExecuteScalar(DbCommand cmd)
        {
            return cmd.ExecuteScalar();
        }
        
        private string Decrypt(string connectionString, string encryptkey)
        {
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();
            byte[] key = Encoding.Unicode.GetBytes(encryptkey);
            byte[] data = Convert.FromBase64String(connectionString.Trim());
            MemoryStream MStream = new MemoryStream();
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);
            CStream.Write(data, 0, data.Length);
            CStream.FlushFinalBlock();
            return Encoding.Unicode.GetString(MStream.ToArray());
        }
    }
}

