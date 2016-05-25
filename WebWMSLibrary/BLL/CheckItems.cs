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
    ///  This is CheckItems BLL class
    ///  For the DataBase Table CheckItems
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class CheckItems 
    {
        #region Settings Define
        protected static CheckItemsElement Settings
        {
            get { return Globals.Settings.CheckItems; }
        }
        #endregion
        
        #region web_CheckItems_CheckItems_Int_Check
        /// <summary>
        /// 
        /// </summary>
        public static int Check(int iD,DateTime checkTime,string checkUser,decimal actualQuantity )
        {
            return SiteProvider.CheckItemsDA.Check(iD,checkTime,checkUser,actualQuantity);
        }
        
        #endregion
        
        #region web_CheckItems_CheckItems_Int_Delete
        /// <summary>
        /// 
        /// </summary>
        public static int Delete(int iD )
        {
            return SiteProvider.CheckItemsDA.Delete(iD);
        }
        
        #endregion
        
        #region web_CheckItems_CheckItems_Int_Insert
        /// <summary>
        /// 
        /// </summary>
        public static int Insert(int billID,string code,string barCode,string departmentCode,decimal inventoryQuantity,string note )
        {
            return SiteProvider.CheckItemsDA.Insert(billID,code,barCode,departmentCode,inventoryQuantity,note);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Insert(CheckItemsDetail obj)
        {
            return SiteProvider.CheckItemsDA.Insert(obj);
        }
        
        public static int Insert(List<CheckItemsDetail> objData)
        {
            return SiteProvider.CheckItemsDA.Insert(objData);
        }
        #endregion
        
        #region web_CheckItems_CheckItems_Int_OneKeyCheck
        /// <summary>
        /// 
        /// </summary>
        public static int OneKeyCheck(int iD,int billID,DateTime checkTime,string checkUser,decimal actualQuantity )
        {
            return SiteProvider.CheckItemsDA.OneKeyCheck(iD,billID,checkTime,checkUser,actualQuantity);
        }
        
        #endregion
        
        #region web_CheckItems_CheckItems_Page_GetByBillID
        /// <summary>
        /// 
        /// </summary>
        public static List<CheckItemsDetail> GetByBillID(int billID,int pageIndex,int pageSize ,out int totalNum,out int totalPage )
        {
            return SiteProvider.CheckItemsDA.GetByBillID(billID,pageIndex,pageSize,out totalNum,out totalPage );
        }
        
        #endregion
        
        #region web_CheckItems_CheckItems_Page_GetByCondition
        /// <summary>
        /// 
        /// </summary>
        public static List<CheckItemsDetail> GetByCondition(int billID,string keyWord,string note,int pageIndex,int pageSize ,out int totalNum,out int totalPage )
        {
            return SiteProvider.CheckItemsDA.GetByCondition(billID,keyWord,note,pageIndex,pageSize,out totalNum,out totalPage );
        }
        
        #endregion
        
        
    }
}


