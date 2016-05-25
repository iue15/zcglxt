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
    ///  This is OutStockItems BLL class
    ///  For the DataBase Table OutStockItems
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class OutStockItems 
    {
        #region Settings Define
        protected static OutStockItemsElement Settings
        {
            get { return Globals.Settings.OutStockItems; }
        }
        #endregion
        
        
    }
}


