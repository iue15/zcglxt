using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using WebWMS.Detail;

namespace WebWMS.DAL
{
    public abstract class OutStockProvider : DataAccess
    {
        #region create instance and class construct
        
        /// <summary>
        /// Returns an instance of the OutStockProvider type specified in the config file
        /// </summary>
        private static OutStockProvider _instance = null;
        static public OutStockProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    try
                    {
                        _instance = (OutStockProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.OutStock.ProviderType));
                    }
                    catch (Exception ew)
                    {
                        throw new Exception(ew.Message);
                    }
                }
                return _instance;
            }
        }

        public OutStockProvider()
        {
            ConnectionString = Globals.Settings.OutStock.ConnectionString;
        }
        
        #endregion

        //user's code added here
        //example:public abstract int Insert(OutStockDetail obj);
        public abstract List<OutStockDetail> GetAll( );
        
        
        public abstract OutStockDetail GetByID(string iD );
        
        
        
        
        #region get object
        /// <summary>
        ///  Returns a new OutStockDetail instance filled with the DataReader's current record data
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual OutStockDetail GetOutStockFromReader(IDataReader reader)
        {
            OutStockDetail objReturn = null;
            try
            {
                SqlDataReader sqlReader = (SqlDataReader)reader;
                if (sqlReader.HasRows)
                {
                    objReturn = new OutStockDetail(

					Helpers.ReadString(reader["ID"]),
					Helpers.ReadString(reader["Task"]),
					Helpers.ReadString(reader["Name"]),
					Helpers.ReadString(reader["DepartmentCode"]),
					Helpers.ReadString(reader["DepartmentName"]),
					Helpers.ReadDateTime(reader["StartDate"]),
					Helpers.ReadDateTime(reader["EndDate"]),
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
        /// Returns a collection of OutStockDetail objects with the data read from the input DataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual List<OutStockDetail> GetOutStockCollectionFromReader(IDataReader reader)
        {
            List<OutStockDetail> objReturn = new List<OutStockDetail>();
            while (reader.Read())
                objReturn.Add(GetOutStockFromReader(reader));
            return objReturn;
        }
        
        protected virtual List<OutStockDetail> GetOutStockCollectionFromReader(IDataReader reader,out int totalNum,out int totalPage)
        {
            List<OutStockDetail> objReturn = new List<OutStockDetail>();
            
            totalPage = 0;
            totalNum = 0;

            if (reader != null)
            {
                while (reader.Read())
                objReturn.Add(GetOutStockFromReader(reader));

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

        protected virtual OutStockDetail GetOutStockFromBaseReader(IDataReader reader)
        {
            OutStockDetail objReturn = null;
            if (reader != null)
            {
                reader.Read();
                objReturn = GetOutStockFromReader(reader);
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

