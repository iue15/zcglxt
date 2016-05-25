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
    ///  This is wCategory BLL class
    ///  For the DataBase Table wCategory
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class wCategory 
    {
        #region Settings Define
        protected static wCategoryElement Settings
        {
            get { return Globals.Settings.wCategory; }
        }
        #endregion
        
        
    }
}


