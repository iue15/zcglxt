using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using WebWMS.Detail;

namespace WebWMS.DAL
{
    public abstract class EmployerProvider : DataAccess
    {
        #region create instance and class construct
        
        /// <summary>
        /// Returns an instance of the EmployerProvider type specified in the config file
        /// </summary>
        private static EmployerProvider _instance = null;
        static public EmployerProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    try
                    {
                        _instance = (EmployerProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Employer.ProviderType));
                    }
                    catch (Exception ew)
                    {
                        throw new Exception(ew.Message);
                    }
                }
                return _instance;
            }
        }

        public EmployerProvider()
        {
            ConnectionString = Globals.Settings.Employer.ConnectionString;
        }
        
        #endregion

        //user's code added here
        //example:public abstract int Insert(EmployerDetail obj);
        public abstract int Delete(string code );
        
        
        public abstract int Insert(string name,string job,string departmentCode,string note );
        
        public abstract int Insert(EmployerDetail obj);
        
        public abstract int Insert(List<EmployerDetail> objData);
        
        public abstract int Move(string code,string departmentCode );
        
        
        public abstract int Update(string code,string name,string job,string note );
        
        public abstract int Update(EmployerDetail obj);
        
        public abstract int Update(List<EmployerDetail> objData);
        
        public abstract List<EmployerDetail> GetAll( );
        
        
        public abstract List<EmployerDetail> GetByDepartmentCode(string departmentCode );
        
        
        public abstract EmployerDetail GetByCode(string code );
        
        
        public abstract List<EmployerDetail> GetByCondition(string keyWord,string departmentCode,int pageIndex,int pageSize ,out int totalNum,out int totalPage );
        
        
        public abstract List<EmployerDetail> GetByDepartmentCode(string departmentCode,int pageIndex,int pageSize ,out int totalNum,out int totalPage );
        
        
        
        
        #region get object
        /// <summary>
        ///  Returns a new EmployerDetail instance filled with the DataReader's current record data
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual EmployerDetail GetEmployerFromReader(IDataReader reader)
        {
            EmployerDetail objReturn = null;
            try
            {
                SqlDataReader sqlReader = (SqlDataReader)reader;
                if (sqlReader.HasRows)
                {
                    objReturn = new EmployerDetail(

					Helpers.ReadString(reader["Code"]),
					Helpers.ReadString(reader["Name"]),
					Helpers.ReadString(reader["Job"]),
					Helpers.ReadString(reader["DepartmentCode"]),
					Helpers.ReadString(reader["DepartmentName"]),
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
        /// Returns a collection of EmployerDetail objects with the data read from the input DataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual List<EmployerDetail> GetEmployerCollectionFromReader(IDataReader reader)
        {
            List<EmployerDetail> objReturn = new List<EmployerDetail>();
            while (reader.Read())
                objReturn.Add(GetEmployerFromReader(reader));
            return objReturn;
        }
        
        protected virtual List<EmployerDetail> GetEmployerCollectionFromReader(IDataReader reader,out int totalNum,out int totalPage)
        {
            List<EmployerDetail> objReturn = new List<EmployerDetail>();
            
            totalPage = 0;
            totalNum = 0;

            if (reader != null)
            {
                while (reader.Read())
                objReturn.Add(GetEmployerFromReader(reader));

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

        protected virtual EmployerDetail GetEmployerFromBaseReader(IDataReader reader)
        {
            EmployerDetail objReturn = null;
            if (reader != null)
            {
                reader.Read();
                objReturn = GetEmployerFromReader(reader);
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

