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
    ///  This is wDepartmentEmployer BLL class
    ///  For the DataBase Table wDepartmentEmployer
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class wDepartmentEmployer 
    {
        #region Settings Define
        protected static wDepartmentEmployerElement Settings
        {
            get { return Globals.Settings.wDepartmentEmployer; }
        }
        #endregion
        
        #region web_wDepartmentEmployer_wDepartmentEmployer_List_GetAll
        /// <summary>
        /// 
        /// </summary>
        public static List<wDepartmentEmployerDetail> GetAll( )
        {
            return SiteProvider.wDepartmentEmployerDA.GetAll();
        }
        
        #endregion
        
        
    }
}


