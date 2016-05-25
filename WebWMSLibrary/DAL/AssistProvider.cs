using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using WebWMS.Detail;

namespace WebWMS.DAL
{
    public abstract class AssistProvider : DataAccess
    {
        #region create instance and class construct
        
        /// <summary>
        /// Returns an instance of the AssistProvider type specified in the config file
        /// </summary>
        private static AssistProvider _instance = null;
        static public AssistProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    try
                    {
                        _instance = (AssistProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Assist.ProviderType));
                    }
                    catch (Exception ew)
                    {
                        throw new Exception(ew.Message);
                    }
                }
                return _instance;
            }
        }

        public AssistProvider()
        {
            ConnectionString = Globals.Settings.Assist.ConnectionString;
        }
        
        #endregion

        //user's code added here
        //example:public abstract int Insert(AssistDetail obj);
        public abstract int Delete(string code );
        
        
        public abstract int Insert(string classCode,string name,string note );
        
        public abstract int Insert(AssistDetail obj);
        
        public abstract int Insert(List<AssistDetail> objData);
        
        public abstract List<AssistDetail> GetByClassCode(string classCode );
        
        
        public abstract AssistDetail GetByCode(string code );
        
        
        
        
        #region get object
        /// <summary>
        ///  Returns a new AssistDetail instance filled with the DataReader's current record data
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual AssistDetail GetAssistFromReader(IDataReader reader)
        {
            AssistDetail objReturn = null;
            try
            {
                SqlDataReader sqlReader = (SqlDataReader)reader;
                if (sqlReader.HasRows)
                {
                    objReturn = new AssistDetail(

					Helpers.ReadString(reader["ClassCode"]),
					Helpers.ReadString(reader["Code"]),
					Helpers.ReadString(reader["Name"]),
					Helpers.ReadInt(reader["Sort"]),
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
        /// Returns a collection of AssistDetail objects with the data read from the input DataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual List<AssistDetail> GetAssistCollectionFromReader(IDataReader reader)
        {
            List<AssistDetail> objReturn = new List<AssistDetail>();
            while (reader.Read())
                objReturn.Add(GetAssistFromReader(reader));
            return objReturn;
        }
        
        protected virtual List<AssistDetail> GetAssistCollectionFromReader(IDataReader reader,out int totalNum,out int totalPage)
        {
            List<AssistDetail> objReturn = new List<AssistDetail>();
            
            totalPage = 0;
            totalNum = 0;

            if (reader != null)
            {
                while (reader.Read())
                objReturn.Add(GetAssistFromReader(reader));

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

        protected virtual AssistDetail GetAssistFromBaseReader(IDataReader reader)
        {
            AssistDetail objReturn = null;
            if (reader != null)
            {
                reader.Read();
                objReturn = GetAssistFromReader(reader);
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

