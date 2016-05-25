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
    ///  This is Menu BLL class
    ///  For the DataBase Table Menu
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class Menu 
    {
        #region Settings Define
        protected static MenuElement Settings
        {
            get { return Globals.Settings.Menu; }
        }
        #endregion
        
        #region web_Menu_Menu_List_GetAllEnabled
        /// <summary>
        /// 
        /// </summary>
        public static List<MenuDetail> GetAllEnabled( )
        {
            return SiteProvider.MenuDA.GetAllEnabled();
        }
        
        #endregion
        
        
    }
}


