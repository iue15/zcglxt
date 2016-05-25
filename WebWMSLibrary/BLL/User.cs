using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;

using WebWMS.Detail;
using WebWMS.DAL;

namespace WebWMS.BLL
{
    /// <summary>
    ///  This is User BLL class
    ///  For the DataBase Table User
    ///  Created By SunYong 2016/4/4 
    /// </summary>
    public class User 
    {
        #region Settings Define
        protected static UserElement Settings
        {
            get { return Globals.Settings.User; }
        }
        #endregion
        
        #region web_User_User_Int_ChangePassword
        /// <summary>
        /// 
        /// </summary>
        public static int ChangePassword(string code,string oldPassword,string newPassword )
        {
            return SiteProvider.UserDA.ChangePassword(code,oldPassword,newPassword);
        }
        
        #endregion
        
        #region web_User_User_Int_Login
        /// <summary>
        /// 
        /// </summary>
        public static int Login(string code,string password )
        {
            return SiteProvider.UserDA.Login(code,password);
        }
        
        #endregion
        
        #region web_User_User_Int_Update
        /// <summary>
        /// 
        /// </summary>
        public static int Update(string code,string password )
        {
            return SiteProvider.UserDA.Update(code,password);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Update(UserDetail obj)
        {
            return SiteProvider.UserDA.Update(obj);
        }
        
        public static int Update(List<UserDetail> objData)
        {
            return SiteProvider.UserDA.Update(objData);
        }
        #endregion
        
        #region web_User_User_List_GetAll
        /// <summary>
        /// 
        /// </summary>
        public static List<UserDetail> GetAll( )
        {
            return SiteProvider.UserDA.GetAll();
        }
        
        #endregion
        
        #region web_User_User_Only_GetByCode
        /// <summary>
        /// 
        /// </summary>
        public static UserDetail GetByCode(string code )
        {
            return SiteProvider.UserDA.GetByCode(code);
        }
        
        #endregion
        
        
    }
}


