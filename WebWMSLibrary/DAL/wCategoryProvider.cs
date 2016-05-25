using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using WebWMS.Detail;

namespace WebWMS.DAL
{
    public abstract class wCategoryProvider : DataAccess
    {
        #region create instance and class construct
        
        /// <summary>
        /// Returns an instance of the wCategoryProvider type specified in the config file
        /// </summary>
        private static wCategoryProvider _instance = null;
        static public wCategoryProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    try
                    {
                        _instance = (wCategoryProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.wCategory.ProviderType));
                    }
                    catch (Exception ew)
                    {
                        throw new Exception(ew.Message);
                    }
                }
                return _instance;
            }
        }

        public wCategoryProvider()
        {
            ConnectionString = Globals.Settings.wCategory.ConnectionString;
        }
        
        #endregion

        //user's code added here
        //example:public abstract int Insert(wCategoryDetail obj);
        
        
        #region get object
        /// <summary>
        ///  Returns a new wCategoryDetail instance filled with the DataReader's current record data
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual wCategoryDetail GetwCategoryFromReader(IDataReader reader)
        {
            wCategoryDetail objReturn = null;
            try
            {
                SqlDataReader sqlReader = (SqlDataReader)reader;
                if (sqlReader.HasRows)
                {
                    objReturn = new wCategoryDetail(

					Helpers.ReadString(reader["Row"]),
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
        /// Returns a collection of wCategoryDetail objects with the data read from the input DataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual List<wCategoryDetail> GetwCategoryCollectionFromReader(IDataReader reader)
        {
            List<wCategoryDetail> objReturn = new List<wCategoryDetail>();
            while (reader.Read())
                objReturn.Add(GetwCategoryFromReader(reader));
            return objReturn;
        }
        
        protected virtual List<wCategoryDetail> GetwCategoryCollectionFromReader(IDataReader reader,out int totalNum,out int totalPage)
        {
            List<wCategoryDetail> objReturn = new List<wCategoryDetail>();
            
            totalPage = 0;
            totalNum = 0;

            if (reader != null)
            {
                while (reader.Read())
                objReturn.Add(GetwCategoryFromReader(reader));

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

        protected virtual wCategoryDetail GetwCategoryFromBaseReader(IDataReader reader)
        {
            wCategoryDetail objReturn = null;
            if (reader != null)
            {
                reader.Read();
                objReturn = GetwCategoryFromReader(reader);
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

