using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using WebWMS.Detail;

namespace WebWMS.DAL
{
    public abstract class InventoryListProvider : DataAccess
    {
        #region create instance and class construct
        
        /// <summary>
        /// Returns an instance of the InventoryListProvider type specified in the config file
        /// </summary>
        private static InventoryListProvider _instance = null;
        static public InventoryListProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    try
                    {
                        _instance = (InventoryListProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.InventoryList.ProviderType));
                    }
                    catch (Exception ew)
                    {
                        throw new Exception(ew.Message);
                    }
                }
                return _instance;
            }
        }

        public InventoryListProvider()
        {
            ConnectionString = Globals.Settings.InventoryList.ConnectionString;
        }
        
        #endregion

        //user's code added here
        //example:public abstract int Insert(InventoryListDetail obj);
        public abstract List<InventoryListDetail> GetByCondition(string departmentCode,string operatorCode,string note,int pageIndex,int pageSize ,out int totalNum,out int totalPage );
        
        
        
        
        #region get object
        /// <summary>
        ///  Returns a new InventoryListDetail instance filled with the DataReader's current record data
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual InventoryListDetail GetInventoryListFromReader(IDataReader reader)
        {
            InventoryListDetail objReturn = null;
            try
            {
                SqlDataReader sqlReader = (SqlDataReader)reader;
                if (sqlReader.HasRows)
                {
                    objReturn = new InventoryListDetail(

					Helpers.ReadInt(reader["ID"]),
					Helpers.ReadString(reader["BillID"]),
					Helpers.ReadString(reader["DepartmentCode"]),
					Helpers.ReadString(reader["DepartmentName"]),
					Helpers.ReadString(reader["VenderCode"]),
					Helpers.ReadString(reader["VenderName"]),
					Helpers.ReadString(reader["OperatorCode"]),
					Helpers.ReadString(reader["OperatorName"]),
					Helpers.ReadString(reader["AddTime"]),
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
        /// Returns a collection of InventoryListDetail objects with the data read from the input DataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual List<InventoryListDetail> GetInventoryListCollectionFromReader(IDataReader reader)
        {
            List<InventoryListDetail> objReturn = new List<InventoryListDetail>();
            while (reader.Read())
                objReturn.Add(GetInventoryListFromReader(reader));
            return objReturn;
        }
        
        protected virtual List<InventoryListDetail> GetInventoryListCollectionFromReader(IDataReader reader,out int totalNum,out int totalPage)
        {
            List<InventoryListDetail> objReturn = new List<InventoryListDetail>();
            
            totalPage = 0;
            totalNum = 0;

            if (reader != null)
            {
                while (reader.Read())
                objReturn.Add(GetInventoryListFromReader(reader));

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

        protected virtual InventoryListDetail GetInventoryListFromBaseReader(IDataReader reader)
        {
            InventoryListDetail objReturn = null;
            if (reader != null)
            {
                reader.Read();
                objReturn = GetInventoryListFromReader(reader);
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

