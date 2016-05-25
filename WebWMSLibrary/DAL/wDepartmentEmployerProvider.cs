using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using WebWMS.Detail;

namespace WebWMS.DAL
{
    public abstract class wDepartmentEmployerProvider : DataAccess
    {
        #region create instance and class construct
        
        /// <summary>
        /// Returns an instance of the wDepartmentEmployerProvider type specified in the config file
        /// </summary>
        private static wDepartmentEmployerProvider _instance = null;
        static public wDepartmentEmployerProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    try
                    {
                        _instance = (wDepartmentEmployerProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.wDepartmentEmployer.ProviderType));
                    }
                    catch (Exception ew)
                    {
                        throw new Exception(ew.Message);
                    }
                }
                return _instance;
            }
        }

        public wDepartmentEmployerProvider()
        {
            ConnectionString = Globals.Settings.wDepartmentEmployer.ConnectionString;
        }
        
        #endregion

        //user's code added here
        //example:public abstract int Insert(wDepartmentEmployerDetail obj);
        public abstract List<wDepartmentEmployerDetail> GetAll( );
        
        
        
        #region get object
        /// <summary>
        ///  Returns a new wDepartmentEmployerDetail instance filled with the DataReader's current record data
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual wDepartmentEmployerDetail GetwDepartmentEmployerFromReader(IDataReader reader)
        {
            wDepartmentEmployerDetail objReturn = null;
            try
            {
                SqlDataReader sqlReader = (SqlDataReader)reader;
                if (sqlReader.HasRows)
                {
                    objReturn = new wDepartmentEmployerDetail(

					Helpers.ReadString(reader["Code"]),
					Helpers.ReadString(reader["Name"]),
					Helpers.ReadString(reader["ParentCode"])                        
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
        /// Returns a collection of wDepartmentEmployerDetail objects with the data read from the input DataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual List<wDepartmentEmployerDetail> GetwDepartmentEmployerCollectionFromReader(IDataReader reader)
        {
            List<wDepartmentEmployerDetail> objReturn = new List<wDepartmentEmployerDetail>();
            while (reader.Read())
                objReturn.Add(GetwDepartmentEmployerFromReader(reader));
            return objReturn;
        }
        
        protected virtual List<wDepartmentEmployerDetail> GetwDepartmentEmployerCollectionFromReader(IDataReader reader,out int totalNum,out int totalPage)
        {
            List<wDepartmentEmployerDetail> objReturn = new List<wDepartmentEmployerDetail>();
            
            totalPage = 0;
            totalNum = 0;

            if (reader != null)
            {
                while (reader.Read())
                objReturn.Add(GetwDepartmentEmployerFromReader(reader));

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

        protected virtual wDepartmentEmployerDetail GetwDepartmentEmployerFromBaseReader(IDataReader reader)
        {
            wDepartmentEmployerDetail objReturn = null;
            if (reader != null)
            {
                reader.Read();
                objReturn = GetwDepartmentEmployerFromReader(reader);
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

