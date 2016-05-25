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
    ///  This is Assist BLL class
    ///  For the DataBase Table Assist
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class Assist 
    {
        #region Settings Define
        protected static AssistElement Settings
        {
            get { return Globals.Settings.Assist; }
        }
        #endregion
        
        #region web_Assist_Assist_Int_Delete
        /// <summary>
        /// 
        /// </summary>
        public static int Delete(string code )
        {
            return SiteProvider.AssistDA.Delete(code);
        }
        
        #endregion
        
        #region web_Assist_Assist_Int_Insert
        /// <summary>
        /// 
        /// </summary>
        public static int Insert(string classCode,string name,string note )
        {
            return SiteProvider.AssistDA.Insert(classCode,name,note);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Insert(AssistDetail obj)
        {
            return SiteProvider.AssistDA.Insert(obj);
        }
        
        public static int Insert(List<AssistDetail> objData)
        {
            return SiteProvider.AssistDA.Insert(objData);
        }
        #endregion
        
        #region web_Assist_Assist_List_GetByClassCode
        /// <summary>
        /// 
        /// </summary>
        public static List<AssistDetail> GetByClassCode(string classCode )
        {
            return SiteProvider.AssistDA.GetByClassCode(classCode);
        }
        
        #endregion
        
        #region web_Assist_Assist_Only_GetByCode
        /// <summary>
        /// 
        /// </summary>
        public static AssistDetail GetByCode(string code )
        {
            return SiteProvider.AssistDA.GetByCode(code);
        }
        
        #endregion
        
        
    }
}


