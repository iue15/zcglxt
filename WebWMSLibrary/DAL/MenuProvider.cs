using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using WebWMS.Detail;

namespace WebWMS.DAL
{
    public abstract class MenuProvider : DataAccess
    {
        #region create instance and class construct
        
        /// <summary>
        /// Returns an instance of the MenuProvider type specified in the config file
        /// </summary>
        private static MenuProvider _instance = null;
        static public MenuProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    try
                    {
                        _instance = (MenuProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Menu.ProviderType));
                    }
                    catch (Exception ew)
                    {
                        throw new Exception(ew.Message);
                    }
                }
                return _instance;
            }
        }

        public MenuProvider()
        {
            ConnectionString = Globals.Settings.Menu.ConnectionString;
        }
        
        #endregion

        //user's code added here
        //example:public abstract int Insert(MenuDetail obj);
        public abstract List<MenuDetail> GetAllEnabled( );
        
        
        
        
        #region get object
        /// <summary>
        ///  Returns a new MenuDetail instance filled with the DataReader's current record data
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual MenuDetail GetMenuFromReader(IDataReader reader)
        {
            MenuDetail objReturn = null;
            try
            {
                SqlDataReader sqlReader = (SqlDataReader)reader;
                if (sqlReader.HasRows)
                {
                    objReturn = new MenuDetail(

					Helpers.ReadString(reader["ModuleId"]),
					Helpers.ReadString(reader["ParentId"]),
					Helpers.ReadString(reader["Category"]),
					Helpers.ReadString(reader["Code"]),
					Helpers.ReadString(reader["FullName"]),
					Helpers.ReadString(reader["Icon"]),
					Helpers.ReadString(reader["Location"]),
					Helpers.ReadString(reader["Target"]),
					Helpers.ReadInt(reader["Level"]),
					Helpers.ReadInt(reader["Isexpand"]),
					Helpers.ReadInt(reader["AllowButton"]),
					Helpers.ReadInt(reader["AllowView"]),
					Helpers.ReadInt(reader["AllowForm"]),
					Helpers.ReadInt(reader["Authority"]),
					Helpers.ReadInt(reader["DataScope"]),
					Helpers.ReadString(reader["Remark"]),
					Helpers.ReadInt(reader["Enabled"]),
					Helpers.ReadInt(reader["SortCode"]),
					Helpers.ReadInt(reader["DeleteMark"]),
					Helpers.ReadDateTime(reader["CreateDate"]),
					Helpers.ReadString(reader["CreateUserId"]),
					Helpers.ReadString(reader["CreateUserName"]),
					Helpers.ReadDateTime(reader["ModifyDate"]),
					Helpers.ReadString(reader["ModifyUserId"]),
					Helpers.ReadString(reader["ModifyUserName"])                        
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
        /// Returns a collection of MenuDetail objects with the data read from the input DataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual List<MenuDetail> GetMenuCollectionFromReader(IDataReader reader)
        {
            List<MenuDetail> objReturn = new List<MenuDetail>();
            while (reader.Read())
                objReturn.Add(GetMenuFromReader(reader));
            return objReturn;
        }
        
        protected virtual List<MenuDetail> GetMenuCollectionFromReader(IDataReader reader,out int totalNum,out int totalPage)
        {
            List<MenuDetail> objReturn = new List<MenuDetail>();
            
            totalPage = 0;
            totalNum = 0;

            if (reader != null)
            {
                while (reader.Read())
                objReturn.Add(GetMenuFromReader(reader));

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

        protected virtual MenuDetail GetMenuFromBaseReader(IDataReader reader)
        {
            MenuDetail objReturn = null;
            if (reader != null)
            {
                reader.Read();
                objReturn = GetMenuFromReader(reader);
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

