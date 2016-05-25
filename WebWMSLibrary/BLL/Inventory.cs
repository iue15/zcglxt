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
    ///  This is Inventory BLL class
    ///  For the DataBase Table Inventory
    ///  Created By SunYong 2016/4/5 
    /// </summary>
    public class Inventory 
    {
        #region Settings Define
        protected static InventoryElement Settings
        {
            get { return Globals.Settings.Inventory; }
        }
        #endregion
        
        #region web_Inventory_Inventory_Int_Allocate
        /// <summary>
        /// 
        /// </summary>
        public static int Allocate(string iD,string departmentCode,string userCode,string storageCode,string addTime,string operatorCode )
        {
            return SiteProvider.InventoryDA.Allocate(iD,departmentCode,userCode,storageCode,addTime,operatorCode);
        }
        
        #endregion
        
        #region web_Inventory_Inventory_Int_Allot
        /// <summary>
        /// 
        /// </summary>
        public static int Allot(string iD,string departmentCode,string userCode,string storageCode,string addTime,string operatorCode )
        {
            return SiteProvider.InventoryDA.Allot(iD,departmentCode,userCode,storageCode,addTime,operatorCode);
        }
        
        #endregion
        
        #region web_Inventory_Inventory_Int_Insert
        /// <summary>
        /// 
        /// </summary>
        public static int Insert(string iD,string code,string measureCode,string chartNumber,string categoryCode,decimal quantity,decimal limitYear,decimal originalValue,string storageCode,string addModeCode,string addTime,string operatorCode,string note )
        {
            return SiteProvider.InventoryDA.Insert(iD,code,measureCode,chartNumber,categoryCode,quantity,limitYear,originalValue,storageCode,addModeCode,addTime,operatorCode,note);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Insert(InventoryDetail obj)
        {
            return SiteProvider.InventoryDA.Insert(obj);
        }
        
        public static int Insert(List<InventoryDetail> objData)
        {
            return SiteProvider.InventoryDA.Insert(objData);
        }
        #endregion
        
        #region web_Inventory_Inventory_Int_Reuse
        /// <summary>
        /// 
        /// </summary>
        public static int Reuse(string iD,string departmentCode,string operatorCode,string addTime )
        {
            return SiteProvider.InventoryDA.Reuse(iD,departmentCode,operatorCode,addTime);
        }
        
        #endregion
        
        #region web_Inventory_Inventory_Int_Scrap
        /// <summary>
        /// 
        /// </summary>
        public static int Scrap(string iD,string departmentCode,string operatorCode,string addTime )
        {
            return SiteProvider.InventoryDA.Scrap(iD,departmentCode,operatorCode,addTime);
        }
        
        #endregion
        
        #region web_Inventory_Inventory_Int_Update
        /// <summary>
        /// 
        /// </summary>
        public static int Update(string iD,string chartNumber,decimal quantity,decimal limitYear,decimal originalValue,string storageCode,string addModeCode,string note )
        {
            return SiteProvider.InventoryDA.Update(iD,chartNumber,quantity,limitYear,originalValue,storageCode,addModeCode,note);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Update(InventoryDetail obj)
        {
            return SiteProvider.InventoryDA.Update(obj);
        }
        
        public static int Update(List<InventoryDetail> objData)
        {
            return SiteProvider.InventoryDA.Update(objData);
        }
        #endregion
        
        #region web_Inventory_Inventory_List_GetAll
        /// <summary>
        /// 
        /// </summary>
        public static List<InventoryDetail> GetAll( )
        {
            return SiteProvider.InventoryDA.GetAll();
        }
        
        #endregion
        
        #region web_Inventory_Inventory_Only_GetByID
        /// <summary>
        /// 
        /// </summary>
        public static InventoryDetail GetByID(string iD )
        {
            return SiteProvider.InventoryDA.GetByID(iD);
        }
        
        #endregion
        
        #region web_Inventory_Inventory_Page_GetByCondition
        /// <summary>
        /// 
        /// </summary>
        public static List<InventoryDetail> GetByCondition(string keyWord,string statusCode,string measureCode,string categoryCode,string storageCode,string departmentCode,string userCode,string addModeCode,int pageIndex,int pageSize ,out int totalNum,out int totalPage )
        {
            return SiteProvider.InventoryDA.GetByCondition(keyWord,statusCode,measureCode,categoryCode,storageCode,departmentCode,userCode,addModeCode,pageIndex,pageSize,out totalNum,out totalPage );
        }
        
        #endregion
        
        #region web_Inventory_Inventory_Page_GetByKeyWord
        /// <summary>
        /// 
        /// </summary>
        public static List<InventoryDetail> GetByKeyWord(string keyWord,int pageIndex,int pageSize ,out int totalNum,out int totalPage )
        {
            return SiteProvider.InventoryDA.GetByKeyWord(keyWord,pageIndex,pageSize,out totalNum,out totalPage );
        }
        
        #endregion
        
        #region web_Inventory_Inventory_Page_GetByKeyWordAndStatus
        /// <summary>
        /// 
        /// </summary>
        public static List<InventoryDetail> GetByKeyWordAndStatus(string keyWord,string statusCode,int pageIndex,int pageSize ,out int totalNum,out int totalPage )
        {
            return SiteProvider.InventoryDA.GetByKeyWordAndStatus(keyWord,statusCode,pageIndex,pageSize,out totalNum,out totalPage );
        }
        
        #endregion
        
        #region web_Inventory_Inventory_Page_GetByStatusCode
        /// <summary>
        /// 
        /// </summary>
        public static List<InventoryDetail> GetByStatusCode(string statusCode,int pageIndex,int pageSize ,out int totalNum,out int totalPage )
        {
            return SiteProvider.InventoryDA.GetByStatusCode(statusCode,pageIndex,pageSize,out totalNum,out totalPage );
        }
        
        #endregion
        
        #region web_Inventory_Inventory_Page_GetForStatistics
        /// <summary>
        /// 
        /// </summary>
        public static List<InventoryDetail> GetForStatistics(string keyWord,string categoryCode,string departmentCode,string addModeCode,string startTime,string endTime,int pageIndex,int pageSize ,out int totalNum,out int totalPage )
        {
            return SiteProvider.InventoryDA.GetForStatistics(keyWord,categoryCode,departmentCode,addModeCode,startTime,endTime,pageIndex,pageSize,out totalNum,out totalPage );
        }
        
        #endregion
        
        
    }
}


