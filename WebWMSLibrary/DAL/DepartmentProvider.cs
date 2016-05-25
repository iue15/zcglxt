using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using WebWMS.Detail;

namespace WebWMS.DAL
{
    public abstract class DepartmentProvider : DataAccess
    {
        #region create instance and class construct
        
        /// <summary>
        /// Returns an instance of the DepartmentProvider type specified in the config file
        /// </summary>
        private static DepartmentProvider _instance = null;
        static public DepartmentProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    try
                    {
                        _instance = (DepartmentProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Department.ProviderType));
                    }
                    catch (Exception ew)
                    {
                        throw new Exception(ew.Message);
                    }
                }
                return _instance;
            }
        }

        public DepartmentProvider()
        {
            ConnectionString = Globals.Settings.Department.ConnectionString;
        }
        
        #endregion

        //user's code added here
        //example:public abstract int Insert(DepartmentDetail obj);
        public abstract int Delete(string code );
        
        
        public abstract int Insert(string name,string user,string job,string note,string parentCode );
        
        public abstract int Insert(DepartmentDetail obj);
        
        public abstract int Insert(List<DepartmentDetail> objData);
        
        public abstract int Update(string code,string name,string user,string job,string note );
        
        public abstract int Update(DepartmentDetail obj);
        
        public abstract int Update(List<DepartmentDetail> objData);
        
        public abstract List<DepartmentDetail> GetAll( );
        
        
        public abstract DepartmentDetail GetByCode(string code );
        
        
        public abstract List<DepartmentDetail> GetByCondition(string keyWord,int pageIndex,int pageSize ,out int totalNum,out int totalPage );
        
        
        
        
        #region get object
        /// <summary>
        ///  Returns a new DepartmentDetail instance filled with the DataReader's current record data
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual DepartmentDetail GetDepartmentFromReader(IDataReader reader)
        {
            DepartmentDetail objReturn = null;
            try
            {
                SqlDataReader sqlReader = (SqlDataReader)reader;
                if (sqlReader.HasRows)
                {
                    objReturn = new DepartmentDetail(

					Helpers.ReadString(reader["Code"]),
					Helpers.ReadString(reader["Name"]),
					Helpers.ReadString(reader["User"]),
					Helpers.ReadString(reader["Job"]),
					Helpers.ReadString(reader["ParentCode"]),
					Helpers.ReadString(reader["ParentName"]),
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
        /// Returns a collection of DepartmentDetail objects with the data read from the input DataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual List<DepartmentDetail> GetDepartmentCollectionFromReader(IDataReader reader)
        {
            List<DepartmentDetail> objReturn = new List<DepartmentDetail>();
            while (reader.Read())
                objReturn.Add(GetDepartmentFromReader(reader));
            return objReturn;
        }
        
        protected virtual List<DepartmentDetail> GetDepartmentCollectionFromReader(IDataReader reader,out int totalNum,out int totalPage)
        {
            List<DepartmentDetail> objReturn = new List<DepartmentDetail>();
            
            totalPage = 0;
            totalNum = 0;

            if (reader != null)
            {
                while (reader.Read())
                objReturn.Add(GetDepartmentFromReader(reader));

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

        protected virtual DepartmentDetail GetDepartmentFromBaseReader(IDataReader reader)
        {
            DepartmentDetail objReturn = null;
            if (reader != null)
            {
                reader.Read();
                objReturn = GetDepartmentFromReader(reader);
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

