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
    ///  This is OutStock BLL class
    ///  For the DataBase Table OutStock
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class OutStock 
    {
        #region Settings Define
        protected static OutStockElement Settings
        {
            get { return Globals.Settings.OutStock; }
        }
        #endregion
        
        #region web_OutStock_OutStock_List_GetAll
        /// <summary>
        /// 
        /// </summary>
        public static List<OutStockDetail> GetAll( )
        {
            return SiteProvider.OutStockDA.GetAll();
        }
        
        #endregion
        
        #region web_OutStock_OutStock_Only_GetByID
        /// <summary>
        /// 
        /// </summary>
        public static OutStockDetail GetByID(string iD )
        {
            return SiteProvider.OutStockDA.GetByID(iD);
        }
        
        #endregion
        
        
    }
}


