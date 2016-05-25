using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using WebWMS.Detail;

namespace WebWMS.DAL
{
    public abstract class UserProvider : DataAccess
    {
        #region create instance and class construct
        
        /// <summary>
        /// Returns an instance of the UserProvider type specified in the config file
        /// </summary>
        private static UserProvider _instance = null;
        static public UserProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    try
                    {
                        _instance = (UserProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.User.ProviderType));
                    }
                    catch (Exception ew)
                    {
                        throw new Exception(ew.Message);
                    }
                }
                return _instance;
            }
        }

        public UserProvider()
        {
            ConnectionString = Globals.Settings.User.ConnectionString;
        }
        
        #endregion

        //user's code added here
        //example:public abstract int Insert(UserDetail obj);
        public abstract int ChangePassword(string code,string oldPassword,string newPassword );
        
        
        public abstract int Login(string code,string password );
        
        
        public abstract int Update(string code,string password );
        
        public abstract int Update(UserDetail obj);
        
        public abstract int Update(List<UserDetail> objData);
        
        public abstract List<UserDetail> GetAll( );
        
        
        public abstract UserDetail GetByCode(string code );
        
        
        
        
        #region get object
        /// <summary>
        ///  Returns a new UserDetail instance filled with the DataReader's current record data
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual UserDetail GetUserFromReader(IDataReader reader)
        {
            UserDetail objReturn = null;
            try
            {
                SqlDataReader sqlReader = (SqlDataReader)reader;
                if (sqlReader.HasRows)
                {
                    objReturn = new UserDetail(

					Helpers.ReadInt(reader["ID"]),
					Helpers.ReadString(reader["Code"]),
					Helpers.ReadString(reader["Name"]),
					Helpers.ReadString(reader["Password"]),
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
        /// Returns a collection of UserDetail objects with the data read from the input DataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual List<UserDetail> GetUserCollectionFromReader(IDataReader reader)
        {
            List<UserDetail> objReturn = new List<UserDetail>();
            while (reader.Read())
                objReturn.Add(GetUserFromReader(reader));
            return objReturn;
        }
        
        protected virtual List<UserDetail> GetUserCollectionFromReader(IDataReader reader,out int totalNum,out int totalPage)
        {
            List<UserDetail> objReturn = new List<UserDetail>();
            
            totalPage = 0;
            totalNum = 0;

            if (reader != null)
            {
                while (reader.Read())
                objReturn.Add(GetUserFromReader(reader));

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

        protected virtual UserDetail GetUserFromBaseReader(IDataReader reader)
        {
            UserDetail objReturn = null;
            if (reader != null)
            {
                reader.Read();
                objReturn = GetUserFromReader(reader);
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

