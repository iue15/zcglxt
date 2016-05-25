using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using WebWMS.Detail;

namespace WebWMS.DAL
{
    public abstract class OutStockItemsProvider : DataAccess
    {
        #region create instance and class construct
        
        /// <summary>
        /// Returns an instance of the OutStockItemsProvider type specified in the config file
        /// </summary>
        private static OutStockItemsProvider _instance = null;
        static public OutStockItemsProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    try
                    {
                        _instance = (OutStockItemsProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.OutStockItems.ProviderType));
                    }
                    catch (Exception ew)
                    {
                        throw new Exception(ew.Message);
                    }
                }
                return _instance;
            }
        }

        public OutStockItemsProvider()
        {
            ConnectionString = Globals.Settings.OutStockItems.ConnectionString;
        }
        
        #endregion

        //user's code added here
        //example:public abstract int Insert(OutStockItemsDetail obj);
        
        
        #region get object
        /// <summary>
        ///  Returns a new OutStockItemsDetail instance filled with the DataReader's current record data
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual OutStockItemsDetail GetOutStockItemsFromReader(IDataReader reader)
        {
            OutStockItemsDetail objReturn = null;
            try
            {
                SqlDataReader sqlReader = (SqlDataReader)reader;
                if (sqlReader.HasRows)
                {
                    objReturn = new OutStockItemsDetail(

					Helpers.ReadString(reader["ID"]),
					Helpers.ReadString(reader["BillID"]),
					Helpers.ReadString(reader["Code"]),
					Helpers.ReadString(reader["Name"]),
					Helpers.ReadString(reader["BarCode"]),
					Helpers.ReadString(reader["DepartmentCode"]),
					Helpers.ReadString(reader["DepartmentName"]),
					Helpers.ReadDecimal(reader["InventoryQuantity"]),
					Helpers.ReadDateTime(reader["CheckTime"]),
					Helpers.ReadString(reader["StatusCode"]),
					Helpers.ReadString(reader["StatusName"]),
					Helpers.ReadString(reader["CheckUser"]),
					Helpers.ReadDecimal(reader["Quantity"]),
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
        /// Returns a collection of OutStockItemsDetail objects with the data read from the input DataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual List<OutStockItemsDetail> GetOutStockItemsCollectionFromReader(IDataReader reader)
        {
            List<OutStockItemsDetail> objReturn = new List<OutStockItemsDetail>();
            while (reader.Read())
                objReturn.Add(GetOutStockItemsFromReader(reader));
            return objReturn;
        }
        
        protected virtual List<OutStockItemsDetail> GetOutStockItemsCollectionFromReader(IDataReader reader,out int totalNum,out int totalPage)
        {
            List<OutStockItemsDetail> objReturn = new List<OutStockItemsDetail>();
            
            totalPage = 0;
            totalNum = 0;

            if (reader != null)
            {
                while (reader.Read())
                objReturn.Add(GetOutStockItemsFromReader(reader));

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

        protected virtual OutStockItemsDetail GetOutStockItemsFromBaseReader(IDataReader reader)
        {
            OutStockItemsDetail objReturn = null;
            if (reader != null)
            {
                reader.Read();
                objReturn = GetOutStockItemsFromReader(reader);
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

