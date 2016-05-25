using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using WebWMS.Detail;

namespace WebWMS.DAL
{
    public abstract class CheckItemsProvider : DataAccess
    {
        #region create instance and class construct
        
        /// <summary>
        /// Returns an instance of the CheckItemsProvider type specified in the config file
        /// </summary>
        private static CheckItemsProvider _instance = null;
        static public CheckItemsProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    try
                    {
                        _instance = (CheckItemsProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.CheckItems.ProviderType));
                    }
                    catch (Exception ew)
                    {
                        throw new Exception(ew.Message);
                    }
                }
                return _instance;
            }
        }

        public CheckItemsProvider()
        {
            ConnectionString = Globals.Settings.CheckItems.ConnectionString;
        }
        
        #endregion

        //user's code added here
        //example:public abstract int Insert(CheckItemsDetail obj);
        public abstract int Check(int iD,DateTime checkTime,string checkUser,decimal actualQuantity );
        
        
        public abstract int Delete(int iD );
        
        
        public abstract int Insert(int billID,string code,string barCode,string departmentCode,decimal inventoryQuantity,string note );
        
        public abstract int Insert(CheckItemsDetail obj);
        
        public abstract int Insert(List<CheckItemsDetail> objData);
        
        public abstract int OneKeyCheck(int iD,int billID,DateTime checkTime,string checkUser,decimal actualQuantity );
        
        
        public abstract List<CheckItemsDetail> GetByBillID(int billID,int pageIndex,int pageSize ,out int totalNum,out int totalPage );
        
        
        public abstract List<CheckItemsDetail> GetByCondition(int billID,string keyWord,string note,int pageIndex,int pageSize ,out int totalNum,out int totalPage );
        
        
        
        
        #region get object
        /// <summary>
        ///  Returns a new CheckItemsDetail instance filled with the DataReader's current record data
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual CheckItemsDetail GetCheckItemsFromReader(IDataReader reader)
        {
            CheckItemsDetail objReturn = null;
            try
            {
                SqlDataReader sqlReader = (SqlDataReader)reader;
                if (sqlReader.HasRows)
                {
                    objReturn = new CheckItemsDetail(

					Helpers.ReadInt(reader["ID"]),
					Helpers.ReadInt(reader["BillID"]),
					Helpers.ReadString(reader["Code"]),
					Helpers.ReadString(reader["Name"]),
					Helpers.ReadString(reader["BarCode"]),
					Helpers.ReadString(reader["DepartmentCode"]),
					Helpers.ReadString(reader["DepartmentName"]),
					Helpers.ReadDecimal(reader["InventoryQuantity"]),
					Helpers.ReadDateTime(reader["CheckTime"]),
					Helpers.ReadString(reader["CheckUser"]),
					Helpers.ReadDecimal(reader["ActualQuantity"]),
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
        /// Returns a collection of CheckItemsDetail objects with the data read from the input DataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual List<CheckItemsDetail> GetCheckItemsCollectionFromReader(IDataReader reader)
        {
            List<CheckItemsDetail> objReturn = new List<CheckItemsDetail>();
            while (reader.Read())
                objReturn.Add(GetCheckItemsFromReader(reader));
            return objReturn;
        }
        
        protected virtual List<CheckItemsDetail> GetCheckItemsCollectionFromReader(IDataReader reader,out int totalNum,out int totalPage)
        {
            List<CheckItemsDetail> objReturn = new List<CheckItemsDetail>();
            
            totalPage = 0;
            totalNum = 0;

            if (reader != null)
            {
                while (reader.Read())
                objReturn.Add(GetCheckItemsFromReader(reader));

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

        protected virtual CheckItemsDetail GetCheckItemsFromBaseReader(IDataReader reader)
        {
            CheckItemsDetail objReturn = null;
            if (reader != null)
            {
                reader.Read();
                objReturn = GetCheckItemsFromReader(reader);
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

