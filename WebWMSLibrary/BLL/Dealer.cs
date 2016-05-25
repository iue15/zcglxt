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
    ///  This is Dealer BLL class
    ///  For the DataBase Table Dealer
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class Dealer 
    {
        #region Settings Define
        protected static DealerElement Settings
        {
            get { return Globals.Settings.Dealer; }
        }
        #endregion
        
        #region web_Dealer_Dealer_Int_Delete
        /// <summary>
        /// 
        /// </summary>
        public static int Delete(string code )
        {
            return SiteProvider.DealerDA.Delete(code);
        }
        
        #endregion
        
        #region web_Dealer_Dealer_Int_Insert
        /// <summary>
        /// 
        /// </summary>
        public static int Insert(string name,string note )
        {
            return SiteProvider.DealerDA.Insert(name,note);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Insert(DealerDetail obj)
        {
            return SiteProvider.DealerDA.Insert(obj);
        }
        
        public static int Insert(List<DealerDetail> objData)
        {
            return SiteProvider.DealerDA.Insert(objData);
        }
        #endregion
        
        #region web_Dealer_Dealer_Int_Update
        /// <summary>
        /// 
        /// </summary>
        public static int Update(string code,string name,string note )
        {
            return SiteProvider.DealerDA.Update(code,name,note);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Update(DealerDetail obj)
        {
            return SiteProvider.DealerDA.Update(obj);
        }
        
        public static int Update(List<DealerDetail> objData)
        {
            return SiteProvider.DealerDA.Update(objData);
        }
        #endregion
        
        #region web_Dealer_Dealer_List_GetAll
        /// <summary>
        /// 
        /// </summary>
        public static List<DealerDetail> GetAll( )
        {
            return SiteProvider.DealerDA.GetAll();
        }
        
        #endregion
        
        #region web_Dealer_Dealer_Only_GetByCode
        /// <summary>
        /// 
        /// </summary>
        public static DealerDetail GetByCode(string code )
        {
            return SiteProvider.DealerDA.GetByCode(code);
        }
        
        #endregion
        
        
    }
}


