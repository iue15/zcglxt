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
    ///  This is InventoryList BLL class
    ///  For the DataBase Table InventoryList
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class InventoryList 
    {
        #region Settings Define
        protected static InventoryListElement Settings
        {
            get { return Globals.Settings.InventoryList; }
        }
        #endregion
        
        #region web_InventoryList_InventoryList_Page_GetByCondition
        /// <summary>
        /// 
        /// </summary>
        public static List<InventoryListDetail> GetByCondition(string departmentCode,string operatorCode,string note,int pageIndex,int pageSize ,out int totalNum,out int totalPage )
        {
            return SiteProvider.InventoryListDA.GetByCondition(departmentCode,operatorCode,note,pageIndex,pageSize,out totalNum,out totalPage );
        }
        
        #endregion
        
        
    }
}


