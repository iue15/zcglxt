using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using WebWMS.Detail;

namespace WebWMS.DAL
{
    public abstract class StatusProvider : DataAccess
    {
        #region create instance and class construct
        
        /// <summary>
        /// Returns an instance of the StatusProvider type specified in the config file
        /// </summary>
        private static StatusProvider _instance = null;
        static public StatusProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    try
                    {
                        _instance = (StatusProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Status.ProviderType));
                    }
                    catch (Exception ew)
                    {
                        throw new Exception(ew.Message);
                    }
                }
                return _instance;
            }
        }

        public StatusProvider()
        {
            ConnectionString = Globals.Settings.Status.ConnectionString;
        }
        
        #endregion

        //user's code added here
        //example:public abstract int Insert(StatusDetail obj);
        public abstract int Delete(string code );
        
        
        public abstract int Insert(string name,string note );
        
        public abstract int Insert(StatusDetail obj);
        
        public abstract int Insert(List<StatusDetail> objData);
        
        public abstract int Update(string code,string name,string note );
        
        public abstract int Update(StatusDetail obj);
        
        public abstract int Update(List<StatusDetail> objData);
        
        public abstract List<StatusDetail> GetAll( );
        
        
        public abstract StatusDetail GetByCode(string code );
        
        
        
        
        #region get object
        /// <summary>
        ///  Returns a new StatusDetail instance filled with the DataReader's current record data
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual StatusDetail GetStatusFromReader(IDataReader reader)
        {
            StatusDetail objReturn = null;
            try
            {
                SqlDataReader sqlReader = (SqlDataReader)reader;
                if (sqlReader.HasRows)
                {
                    objReturn = new StatusDetail(

					Helpers.ReadString(reader["Code"]),
					Helpers.ReadString(reader["Name"]),
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
        /// Returns a collection of StatusDetail objects with the data read from the input DataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual List<StatusDetail> GetStatusCollectionFromReader(IDataReader reader)
        {
            List<StatusDetail> objReturn = new List<StatusDetail>();
            while (reader.Read())
                objReturn.Add(GetStatusFromReader(reader));
            return objReturn;
        }
        
        protected virtual List<StatusDetail> GetStatusCollectionFromReader(IDataReader reader,out int totalNum,out int totalPage)
        {
            List<StatusDetail> objReturn = new List<StatusDetail>();
            
            totalPage = 0;
            totalNum = 0;

            if (reader != null)
            {
                while (reader.Read())
                objReturn.Add(GetStatusFromReader(reader));

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

        protected virtual StatusDetail GetStatusFromBaseReader(IDataReader reader)
        {
            StatusDetail objReturn = null;
            if (reader != null)
            {
                reader.Read();
                objReturn = GetStatusFromReader(reader);
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

