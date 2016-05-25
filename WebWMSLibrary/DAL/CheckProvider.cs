using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using WebWMS.Detail;

namespace WebWMS.DAL
{
    public abstract class CheckProvider : DataAccess
    {
        #region create instance and class construct
        
        /// <summary>
        /// Returns an instance of the CheckProvider type specified in the config file
        /// </summary>
        private static CheckProvider _instance = null;
        static public CheckProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    try
                    {
                        _instance = (CheckProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Check.ProviderType));
                    }
                    catch (Exception ew)
                    {
                        throw new Exception(ew.Message);
                    }
                }
                return _instance;
            }
        }

        public CheckProvider()
        {
            ConnectionString = Globals.Settings.Check.ConnectionString;
        }
        
        #endregion

        //user's code added here
        //example:public abstract int Insert(CheckDetail obj);
        public abstract int CheckOperate(int iD );
        
        
        public abstract int Complete(int iD );
        
        
        public abstract int Delete(int iD );
        
        
        public abstract int Insert(string taskName,string mode,string departmentCode,DateTime startDate,DateTime endDate,string operatorCode,string note );
        
        public abstract int Insert(CheckDetail obj);
        
        public abstract int Insert(List<CheckDetail> objData);
        
        public abstract int Update(int iD,string taskName,string mode,DateTime startDate,DateTime endDate,string operatorCode,string note );
        
        public abstract int Update(CheckDetail obj);
        
        public abstract int Update(List<CheckDetail> objData);
        
        public abstract List<CheckDetail> GetAll( );
        
        
        public abstract CheckDetail GetByID(int iD );
        
        
        public abstract List<CheckDetail> GetByCondition(string keyWord,string statusCode,string departmentCode,DateTime startDate,DateTime endDate,string operatorCode,int pageIndex,int pageSize ,out int totalNum,out int totalPage );
        
        
        
        
        #region get object
        /// <summary>
        ///  Returns a new CheckDetail instance filled with the DataReader's current record data
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual CheckDetail GetCheckFromReader(IDataReader reader)
        {
            CheckDetail objReturn = null;
            try
            {
                SqlDataReader sqlReader = (SqlDataReader)reader;
                if (sqlReader.HasRows)
                {
                    objReturn = new CheckDetail(

					Helpers.ReadInt(reader["ID"]),
					Helpers.ReadString(reader["TaskName"]),
					Helpers.ReadString(reader["Mode"]),
					Helpers.ReadString(reader["StatusCode"]),
					Helpers.ReadString(reader["StatusName"]),
					Helpers.ReadString(reader["DepartmentCode"]),
					Helpers.ReadString(reader["DepartmentName"]),
					Helpers.ReadDateTime(reader["StartDate"]),
					Helpers.ReadDateTime(reader["EndDate"]),
					Helpers.ReadString(reader["OperatorCode"]),
					Helpers.ReadString(reader["OperatorName"]),
					Helpers.ReadDecimal(reader["InventoryQuantity"]),
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
        /// Returns a collection of CheckDetail objects with the data read from the input DataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual List<CheckDetail> GetCheckCollectionFromReader(IDataReader reader)
        {
            List<CheckDetail> objReturn = new List<CheckDetail>();
            while (reader.Read())
                objReturn.Add(GetCheckFromReader(reader));
            return objReturn;
        }
        
        protected virtual List<CheckDetail> GetCheckCollectionFromReader(IDataReader reader,out int totalNum,out int totalPage)
        {
            List<CheckDetail> objReturn = new List<CheckDetail>();
            
            totalPage = 0;
            totalNum = 0;

            if (reader != null)
            {
                while (reader.Read())
                objReturn.Add(GetCheckFromReader(reader));

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

        protected virtual CheckDetail GetCheckFromBaseReader(IDataReader reader)
        {
            CheckDetail objReturn = null;
            if (reader != null)
            {
                reader.Read();
                objReturn = GetCheckFromReader(reader);
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

