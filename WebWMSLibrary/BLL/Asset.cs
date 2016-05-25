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
    ///  This is Asset BLL class
    ///  For the DataBase Table Asset
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class Asset 
    {
        #region Settings Define
        protected static AssetElement Settings
        {
            get { return Globals.Settings.Asset; }
        }
        #endregion
        
        #region web_Asset_Asset_Int_Delete
        /// <summary>
        /// 
        /// </summary>
        public static int Delete(string code )
        {
            return SiteProvider.AssetDA.Delete(code);
        }
        
        #endregion
        
        #region web_Asset_Asset_Int_Insert
        /// <summary>
        /// 
        /// </summary>
        public static int Insert(string name,string chartNumber,string categoryCode,string measureCode,string note )
        {
            return SiteProvider.AssetDA.Insert(name,chartNumber,categoryCode,measureCode,note);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Insert(AssetDetail obj)
        {
            return SiteProvider.AssetDA.Insert(obj);
        }
        
        public static int Insert(List<AssetDetail> objData)
        {
            return SiteProvider.AssetDA.Insert(objData);
        }
        #endregion
        
        #region web_Asset_Asset_Int_Update
        /// <summary>
        /// 
        /// </summary>
        public static int Update(string code,string name,string note )
        {
            return SiteProvider.AssetDA.Update(code,name,note);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Update(AssetDetail obj)
        {
            return SiteProvider.AssetDA.Update(obj);
        }
        
        public static int Update(List<AssetDetail> objData)
        {
            return SiteProvider.AssetDA.Update(objData);
        }
        #endregion
        
        #region web_Asset_Asset_List_GetAll
        /// <summary>
        /// 
        /// </summary>
        public static List<AssetDetail> GetAll( )
        {
            return SiteProvider.AssetDA.GetAll();
        }
        
        #endregion
        
        #region web_Asset_Asset_Only_GetByCode
        /// <summary>
        /// 
        /// </summary>
        public static AssetDetail GetByCode(string code )
        {
            return SiteProvider.AssetDA.GetByCode(code);
        }
        
        #endregion
        
        #region web_Asset_Asset_Page_GetByCondition
        /// <summary>
        /// 
        /// </summary>
        public static List<AssetDetail> GetByCondition(string keyWord,string measureCode,string categoryCode,int pageIndex,int pageSize ,out int totalNum,out int totalPage )
        {
            return SiteProvider.AssetDA.GetByCondition(keyWord,measureCode,categoryCode,pageIndex,pageSize,out totalNum,out totalPage );
        }
        
        #endregion
        
        
    }
}


