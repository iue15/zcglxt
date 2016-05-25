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
    ///  This is Storage BLL class
    ///  For the DataBase Table Storage
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class Storage 
    {
        #region Settings Define
        protected static StorageElement Settings
        {
            get { return Globals.Settings.Storage; }
        }
        #endregion
        
        #region web_Storage_Storage_Int_Delete
        /// <summary>
        /// 
        /// </summary>
        public static int Delete(string code )
        {
            return SiteProvider.StorageDA.Delete(code);
        }
        
        #endregion
        
        #region web_Storage_Storage_Int_Insert
        /// <summary>
        /// 
        /// </summary>
        public static int Insert(string name,string note )
        {
            return SiteProvider.StorageDA.Insert(name,note);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Insert(StorageDetail obj)
        {
            return SiteProvider.StorageDA.Insert(obj);
        }
        
        public static int Insert(List<StorageDetail> objData)
        {
            return SiteProvider.StorageDA.Insert(objData);
        }
        #endregion
        
        #region web_Storage_Storage_Int_Update
        /// <summary>
        /// 
        /// </summary>
        public static int Update(string code,string name,string note )
        {
            return SiteProvider.StorageDA.Update(code,name,note);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Update(StorageDetail obj)
        {
            return SiteProvider.StorageDA.Update(obj);
        }
        
        public static int Update(List<StorageDetail> objData)
        {
            return SiteProvider.StorageDA.Update(objData);
        }
        #endregion
        
        #region web_Storage_Storage_List_GetAll
        /// <summary>
        /// 
        /// </summary>
        public static List<StorageDetail> GetAll( )
        {
            return SiteProvider.StorageDA.GetAll();
        }
        
        #endregion
        
        #region web_Storage_Storage_Only_GetByCode
        /// <summary>
        /// 
        /// </summary>
        public static StorageDetail GetByCode(string code )
        {
            return SiteProvider.StorageDA.GetByCode(code);
        }
        
        #endregion
        
        
    }
}


