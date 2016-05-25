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
    ///  This is AddMode BLL class
    ///  For the DataBase Table AddMode
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class AddMode 
    {
        #region Settings Define
        protected static AddModeElement Settings
        {
            get { return Globals.Settings.AddMode; }
        }
        #endregion
        
        #region web_AddMode_AddMode_Int_Delete
        /// <summary>
        /// 
        /// </summary>
        public static int Delete(string code )
        {
            return SiteProvider.AddModeDA.Delete(code);
        }
        
        #endregion
        
        #region web_AddMode_AddMode_Int_Insert
        /// <summary>
        /// 
        /// </summary>
        public static int Insert(string name,string note )
        {
            return SiteProvider.AddModeDA.Insert(name,note);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Insert(AddModeDetail obj)
        {
            return SiteProvider.AddModeDA.Insert(obj);
        }
        
        public static int Insert(List<AddModeDetail> objData)
        {
            return SiteProvider.AddModeDA.Insert(objData);
        }
        #endregion
        
        #region web_AddMode_AddMode_Int_Update
        /// <summary>
        /// 
        /// </summary>
        public static int Update(string code,string name,string note )
        {
            return SiteProvider.AddModeDA.Update(code,name,note);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Update(AddModeDetail obj)
        {
            return SiteProvider.AddModeDA.Update(obj);
        }
        
        public static int Update(List<AddModeDetail> objData)
        {
            return SiteProvider.AddModeDA.Update(objData);
        }
        #endregion
        
        #region web_AddMode_AddMode_List_GetAll
        /// <summary>
        /// 
        /// </summary>
        public static List<AddModeDetail> GetAll( )
        {
            return SiteProvider.AddModeDA.GetAll();
        }
        
        #endregion
        
        #region web_AddMode_AddMode_Only_GetByCode
        /// <summary>
        /// 
        /// </summary>
        public static AddModeDetail GetByCode(string code )
        {
            return SiteProvider.AddModeDA.GetByCode(code);
        }
        
        #endregion
        
        
    }
}


