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
    ///  This is Status BLL class
    ///  For the DataBase Table Status
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class Status 
    {
        #region Settings Define
        protected static StatusElement Settings
        {
            get { return Globals.Settings.Status; }
        }
        #endregion
        
        #region web_Status_Status_Int_Delete
        /// <summary>
        /// 
        /// </summary>
        public static int Delete(string code )
        {
            return SiteProvider.StatusDA.Delete(code);
        }
        
        #endregion
        
        #region web_Status_Status_Int_Insert
        /// <summary>
        /// 
        /// </summary>
        public static int Insert(string name,string note )
        {
            return SiteProvider.StatusDA.Insert(name,note);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Insert(StatusDetail obj)
        {
            return SiteProvider.StatusDA.Insert(obj);
        }
        
        public static int Insert(List<StatusDetail> objData)
        {
            return SiteProvider.StatusDA.Insert(objData);
        }
        #endregion
        
        #region web_Status_Status_Int_Update
        /// <summary>
        /// 
        /// </summary>
        public static int Update(string code,string name,string note )
        {
            return SiteProvider.StatusDA.Update(code,name,note);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Update(StatusDetail obj)
        {
            return SiteProvider.StatusDA.Update(obj);
        }
        
        public static int Update(List<StatusDetail> objData)
        {
            return SiteProvider.StatusDA.Update(objData);
        }
        #endregion
        
        #region web_Status_Status_List_GetAll
        /// <summary>
        /// 
        /// </summary>
        public static List<StatusDetail> GetAll( )
        {
            return SiteProvider.StatusDA.GetAll();
        }
        
        #endregion
        
        #region web_Status_Status_Only_GetByCode
        /// <summary>
        /// 
        /// </summary>
        public static StatusDetail GetByCode(string code )
        {
            return SiteProvider.StatusDA.GetByCode(code);
        }
        
        #endregion
        
        
    }
}


