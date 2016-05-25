using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using WebWMS.Detail;

namespace WebWMS.DAL
{
    public abstract class AssetProvider : DataAccess
    {
        #region create instance and class construct
        
        /// <summary>
        /// Returns an instance of the AssetProvider type specified in the config file
        /// </summary>
        private static AssetProvider _instance = null;
        static public AssetProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    try
                    {
                        _instance = (AssetProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Asset.ProviderType));
                    }
                    catch (Exception ew)
                    {
                        throw new Exception(ew.Message);
                    }
                }
                return _instance;
            }
        }

        public AssetProvider()
        {
            ConnectionString = Globals.Settings.Asset.ConnectionString;
        }
        
        #endregion

        //user's code added here
        //example:public abstract int Insert(AssetDetail obj);
        public abstract int Delete(string code );
        
        
        public abstract int Insert(string name,string chartNumber,string categoryCode,string measureCode,string note );
        
        public abstract int Insert(AssetDetail obj);
        
        public abstract int Insert(List<AssetDetail> objData);
        
        public abstract int Update(string code,string name,string note );
        
        public abstract int Update(AssetDetail obj);
        
        public abstract int Update(List<AssetDetail> objData);
        
        public abstract List<AssetDetail> GetAll( );
        
        
        public abstract AssetDetail GetByCode(string code );
        
        
        public abstract List<AssetDetail> GetByCondition(string keyWord,string measureCode,string categoryCode,int pageIndex,int pageSize ,out int totalNum,out int totalPage );
        
        
        
        
        #region get object
        /// <summary>
        ///  Returns a new AssetDetail instance filled with the DataReader's current record data
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual AssetDetail GetAssetFromReader(IDataReader reader)
        {
            AssetDetail objReturn = null;
            try
            {
                SqlDataReader sqlReader = (SqlDataReader)reader;
                if (sqlReader.HasRows)
                {
                    objReturn = new AssetDetail(

					Helpers.ReadString(reader["Code"]),
					Helpers.ReadString(reader["Name"]),
					Helpers.ReadString(reader["ChartNumber"]),
					Helpers.ReadString(reader["CategoryCode"]),
					Helpers.ReadString(reader["CategoryName"]),
					Helpers.ReadString(reader["MeasureCode"]),
					Helpers.ReadString(reader["MeasureName"]),
					Helpers.ReadString(reader["Note"])                        
                    );
                }
            }
            catch (Exception ew)
            {
                throw new Exception(ew.Message);
            }
            return objReturn;
        }

        /// <summary>
        /// Returns a collection of AssetDetail objects with the data read from the input DataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual List<AssetDetail> GetAssetCollectionFromReader(IDataReader reader)
        {
            List<AssetDetail> objReturn = new List<AssetDetail>();
            while (reader.Read())
                objReturn.Add(GetAssetFromReader(reader));
            return objReturn;
        }
        
        protected virtual List<AssetDetail> GetAssetCollectionFromReader(IDataReader reader,out int totalNum,out int totalPage)
        {
            List<AssetDetail> objReturn = new List<AssetDetail>();
            
            totalPage = 0;
            totalNum = 0;

            if (reader != null)
            {
                while (reader.Read())
                objReturn.Add(GetAssetFromReader(reader));

                if (reader.NextResult())
                {
                    if (reader.Read())
                    {
                        totalNum = Convert.ToInt32(reader["TotalNum"]);
                        totalPage = Convert.ToInt32(reader["TotalPage"]);
                        
                    }
                }
            }
            
            
            return objReturn;
        }

        protected virtual AssetDetail GetAssetFromBaseReader(IDataReader reader)
        {
            AssetDetail objReturn = null;
            if (reader != null)
            {
                reader.Read();
                objReturn = GetAssetFromReader(reader);
            }
            return objReturn;
        }
        
        #endregion
        
        #region get object????????

        /// <summary>
        ///  Returns a new InStockDetail instance filled with the DataReader's current record data
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual int GetSequenceFromReader(IDataReader reader)
        {
            int objReturn = 1;
            try
            {
                SqlDataReader sqlReader = (SqlDataReader)reader;
                if (sqlReader.HasRows)
                {
                    objReturn = Helpers.ReadInt(reader["Sequence"]);
                }
            }
            catch (Exception ew)
            {
                throw new Exception(ew.Message);
            }
            return objReturn;
        }

        protected virtual string GetTextFromReader(IDataReader reader)
        {
            string objReturn = "";
            try
            {
                SqlDataReader sqlReader = (SqlDataReader)reader;
                if (sqlReader.HasRows)
                {
                    objReturn = Helpers.ReadString(reader["Text"]);
                }
            }
            catch (Exception ew)
            {
                throw new Exception(ew.Message);
            }
            return objReturn;
        }

        /// <summary>
        /// Returns a collection of InStockDetail objects with the data read from the input DataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual List<int> GetSequenceCollectionFromReader(IDataReader reader)
        {
            List<int> objReturn = new List<int>();
            while (reader.Read())
                objReturn.Add(GetSequenceFromReader(reader));
            return objReturn;
        }
        
        protected virtual List<string> GetTextCollectionFromReader(IDataReader reader)
        {
            List<string> objReturn = new List<string>();
            while (reader.Read())
                objReturn.Add(GetTextFromReader(reader));
            return objReturn;
        }

        protected virtual int GetSequenceFromBaseReader(IDataReader reader)
        {
            int objReturn = 0;
            if (reader != null)
            {
                reader.Read();
                objReturn = GetSequenceFromReader(reader);
            }
            return objReturn;
        }

        #endregion
    }
}

