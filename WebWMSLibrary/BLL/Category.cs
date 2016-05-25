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
    ///  This is Category BLL class
    ///  For the DataBase Table Category
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class Category 
    {
        #region Settings Define
        protected static CategoryElement Settings
        {
            get { return Globals.Settings.Category; }
        }
        #endregion
        
        #region web_Category_Category_Int_Delete
        /// <summary>
        /// 
        /// </summary>
        public static int Delete(string code )
        {
            return SiteProvider.CategoryDA.Delete(code);
        }
        
        #endregion
        
        #region web_Category_Category_Int_Insert
        /// <summary>
        /// 
        /// </summary>
        public static int Insert(string name,string note )
        {
            return SiteProvider.CategoryDA.Insert(name,note);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Insert(CategoryDetail obj)
        {
            return SiteProvider.CategoryDA.Insert(obj);
        }
        
        public static int Insert(List<CategoryDetail> objData)
        {
            return SiteProvider.CategoryDA.Insert(objData);
        }
        #endregion
        
        #region web_Category_Category_Int_Update
        /// <summary>
        /// 
        /// </summary>
        public static int Update(string code,string name,string note )
        {
            return SiteProvider.CategoryDA.Update(code,name,note);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Update(CategoryDetail obj)
        {
            return SiteProvider.CategoryDA.Update(obj);
        }
        
        public static int Update(List<CategoryDetail> objData)
        {
            return SiteProvider.CategoryDA.Update(objData);
        }
        #endregion
        
        #region web_Category_Category_List_GetAll
        /// <summary>
        /// 
        /// </summary>
        public static List<CategoryDetail> GetAll( )
        {
            return SiteProvider.CategoryDA.GetAll();
        }
        
        #endregion
        
        #region web_Category_Category_Only_GetByCode
        /// <summary>
        /// 
        /// </summary>
        public static CategoryDetail GetByCode(string code )
        {
            return SiteProvider.CategoryDA.GetByCode(code);
        }
        
        #endregion
        
        
    }
}


