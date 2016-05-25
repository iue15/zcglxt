using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using WebWMS.Detail;

namespace WebWMS.DAL
{
    public abstract class InventoryProvider : DataAccess
    {
        #region create instance and class construct
        
        /// <summary>
        /// Returns an instance of the InventoryProvider type specified in the config file
        /// </summary>
        private static InventoryProvider _instance = null;
        static public InventoryProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    try
                    {
                        _instance = (InventoryProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Inventory.ProviderType));
                    }
                    catch (Exception ew)
                    {
                        throw new Exception(ew.Message);
                    }
                }
                return _instance;
            }
        }

        public InventoryProvider()
        {
            ConnectionString = Globals.Settings.Inventory.ConnectionString;
        }
        
        #endregion

        //user's code added here
        //example:public abstract int Insert(InventoryDetail obj);
        public abstract int Allocate(string iD,string departmentCode,string userCode,string storageCode,string addTime,string operatorCode );
        
        
        public abstract int Allot(string iD,string departmentCode,string userCode,string storageCode,string addTime,string operatorCode );
        
        
        public abstract int Insert(string iD,string code,string measureCode,string chartNumber,string categoryCode,decimal quantity,decimal limitYear,decimal originalValue,string storageCode,string addModeCode,string addTime,string operatorCode,string note );
        
        public abstract int Insert(InventoryDetail obj);
        
        public abstract int Insert(List<InventoryDetail> objData);
        
        public abstract int Reuse(string iD,string departmentCode,string operatorCode,string addTime );
        
        
        public abstract int Scrap(string iD,string departmentCode,string operatorCode,string addTime );
        
        
        public abstract int Update(string iD,string chartNumber,decimal quantity,decimal limitYear,decimal originalValue,string storageCode,string addModeCode,string note );
        
        public abstract int Update(InventoryDetail obj);
        
        public abstract int Update(List<InventoryDetail> objData);
        
        public abstract List<InventoryDetail> GetAll( );
        
        
        public abstract InventoryDetail GetByID(string iD );
        
        
        public abstract List<InventoryDetail> GetByCondition(string keyWord,string statusCode,string measureCode,string categoryCode,string storageCode,string departmentCode,string userCode,string addModeCode,int pageIndex,int pageSize ,out int totalNum,out int totalPage );
        
        
        public abstract List<InventoryDetail> GetByKeyWord(string keyWord,int pageIndex,int pageSize ,out int totalNum,out int totalPage );
        
        
        public abstract List<InventoryDetail> GetByKeyWordAndStatus(string keyWord,string statusCode,int pageIndex,int pageSize ,out int totalNum,out int totalPage );
        
        
        public abstract List<InventoryDetail> GetByStatusCode(string statusCode,int pageIndex,int pageSize ,out int totalNum,out int totalPage );
        
        
        public abstract List<InventoryDetail> GetForStatistics(string keyWord,string categoryCode,string departmentCode,string addModeCode,string startTime,string endTime,int pageIndex,int pageSize ,out int totalNum,out int totalPage );
        
        
        
        
        #region get object
        /// <summary>
        ///  Returns a new InventoryDetail instance filled with the DataReader's current record data
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual InventoryDetail GetInventoryFromReader(IDataReader reader)
        {
            InventoryDetail objReturn = null;
            try
            {
                SqlDataReader sqlReader = (SqlDataReader)reader;
                if (sqlReader.HasRows)
                {
                    objReturn = new InventoryDetail(

					Helpers.ReadString(reader["ID"]),
					Helpers.ReadString(reader["Code"]),
					Helpers.ReadString(reader["Name"]),
					Helpers.ReadString(reader["MeasureCode"]),
					Helpers.ReadString(reader["MeasureName"]),
					Helpers.ReadString(reader["ChartNumber"]),
					Helpers.ReadString(reader["CategoryCode"]),
					Helpers.ReadString(reader["CategoryName"]),
					Helpers.ReadString(reader["StatusCode"]),
					Helpers.ReadString(reader["StatusName"]),
					Helpers.ReadString(reader["BarCode"]),
					Helpers.ReadDecimal(reader["Quantity"]),
					Helpers.ReadDecimal(reader["LimitYear"]),
					Helpers.ReadDecimal(reader["ResidualRate"]),
					Helpers.ReadDecimal(reader["OriginalValue"]),
					Helpers.ReadDecimal(reader["PresentValue"]),
					Helpers.ReadString(reader["StorageCode"]),
					Helpers.ReadString(reader["StorageName"]),
					Helpers.ReadString(reader["DepartmentCode"]),
					Helpers.ReadString(reader["DepartmentName"]),
					Helpers.ReadString(reader["UserCode"]),
					Helpers.ReadString(reader["UserName"]),
					Helpers.ReadString(reader["AddModeCode"]),
					Helpers.ReadString(reader["AddModeName"]),
					Helpers.ReadString(reader["AddTime"]),
					Helpers.ReadString(reader["OperatorCode"]),
					Helpers.ReadString(reader["OperatorName"]),
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
        /// Returns a collection of InventoryDetail objects with the data read from the input DataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual List<InventoryDetail> GetInventoryCollectionFromReader(IDataReader reader)
        {
            List<InventoryDetail> objReturn = new List<InventoryDetail>();
            while (reader.Read())
                objReturn.Add(GetInventoryFromReader(reader));
            return objReturn;
        }
        
        protected virtual List<InventoryDetail> GetInventoryCollectionFromReader(IDataReader reader,out int totalNum,out int totalPage)
        {
            List<InventoryDetail> objReturn = new List<InventoryDetail>();
            
            totalPage = 0;
            totalNum = 0;

            if (reader != null)
            {
                while (reader.Read())
                objReturn.Add(GetInventoryFromReader(reader));

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

        protected virtual InventoryDetail GetInventoryFromBaseReader(IDataReader reader)
        {
            InventoryDetail objReturn = null;
            if (reader != null)
            {
                reader.Read();
                objReturn = GetInventoryFromReader(reader);
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

