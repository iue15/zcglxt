using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using WebWMS.Detail;

namespace WebWMS.DAL
{
    public abstract class MeasureProvider : DataAccess
    {
        #region create instance and class construct
        
        /// <summary>
        /// Returns an instance of the MeasureProvider type specified in the config file
        /// </summary>
        private static MeasureProvider _instance = null;
        static public MeasureProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    try
                    {
                        _instance = (MeasureProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Measure.ProviderType));
                    }
                    catch (Exception ew)
                    {
                        throw new Exception(ew.Message);
                    }
                }
                return _instance;
            }
        }

        public MeasureProvider()
        {
            ConnectionString = Globals.Settings.Measure.ConnectionString;
        }
        
        #endregion

        //user's code added here
        //example:public abstract int Insert(MeasureDetail obj);
        public abstract int Delete(string code );
        
        
        public abstract int Insert(string name,string note );
        
        public abstract int Insert(MeasureDetail obj);
        
        public abstract int Insert(List<MeasureDetail> objData);
        
        public abstract int Update(string code,string name,string note );
        
        public abstract int Update(MeasureDetail obj);
        
        public abstract int Update(List<MeasureDetail> objData);
        
        public abstract List<MeasureDetail> GetAll( );
        
        
        public abstract MeasureDetail GetByCode(string code );
        
        
        
        
        #region get object
        /// <summary>
        ///  Returns a new MeasureDetail instance filled with the DataReader's current record data
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual MeasureDetail GetMeasureFromReader(IDataReader reader)
        {
            MeasureDetail objReturn = null;
            try
            {
                SqlDataReader sqlReader = (SqlDataReader)reader;
                if (sqlReader.HasRows)
                {
                    objReturn = new MeasureDetail(

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
        /// Returns a collection of MeasureDetail objects with the data read from the input DataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual List<MeasureDetail> GetMeasureCollectionFromReader(IDataReader reader)
        {
            List<MeasureDetail> objReturn = new List<MeasureDetail>();
            while (reader.Read())
                objReturn.Add(GetMeasureFromReader(reader));
            return objReturn;
        }
        
        protected virtual List<MeasureDetail> GetMeasureCollectionFromReader(IDataReader reader,out int totalNum,out int totalPage)
        {
            List<MeasureDetail> objReturn = new List<MeasureDetail>();
            
            totalPage = 0;
            totalNum = 0;

            if (reader != null)
            {
                while (reader.Read())
                objReturn.Add(GetMeasureFromReader(reader));

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

        protected virtual MeasureDetail GetMeasureFromBaseReader(IDataReader reader)
        {
            MeasureDetail objReturn = null;
            if (reader != null)
            {
                reader.Read();
                objReturn = GetMeasureFromReader(reader);
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

