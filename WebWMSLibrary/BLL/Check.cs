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
    ///  This is Check BLL class
    ///  For the DataBase Table Check
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class Check 
    {
        #region Settings Define
        protected static CheckElement Settings
        {
            get { return Globals.Settings.Check; }
        }
        #endregion
        
        #region web_Check_Check_Int_CheckOperate
        /// <summary>
        /// 
        /// </summary>
        public static int CheckOperate(int iD )
        {
            return SiteProvider.CheckDA.CheckOperate(iD);
        }
        
        #endregion
        
        #region web_Check_Check_Int_Complete
        /// <summary>
        /// 
        /// </summary>
        public static int Complete(int iD )
        {
            return SiteProvider.CheckDA.Complete(iD);
        }
        
        #endregion
        
        #region web_Check_Check_Int_Delete
        /// <summary>
        /// 
        /// </summary>
        public static int Delete(int iD )
        {
            return SiteProvider.CheckDA.Delete(iD);
        }
        
        #endregion
        
        #region web_Check_Check_Int_Insert
        /// <summary>
        /// 
        /// </summary>
        public static int Insert(string taskName,string mode,string departmentCode,DateTime startDate,DateTime endDate,string operatorCode,string note )
        {
            return SiteProvider.CheckDA.Insert(taskName,mode,departmentCode,startDate,endDate,operatorCode,note);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Insert(CheckDetail obj)
        {
            return SiteProvider.CheckDA.Insert(obj);
        }
        
        public static int Insert(List<CheckDetail> objData)
        {
            return SiteProvider.CheckDA.Insert(objData);
        }
        #endregion
        
        #region web_Check_Check_Int_Update
        /// <summary>
        /// 
        /// </summary>
        public static int Update(int iD,string taskName,string mode,DateTime startDate,DateTime endDate,string operatorCode,string note )
        {
            return SiteProvider.CheckDA.Update(iD,taskName,mode,startDate,endDate,operatorCode,note);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Update(CheckDetail obj)
        {
            return SiteProvider.CheckDA.Update(obj);
        }
        
        public static int Update(List<CheckDetail> objData)
        {
            return SiteProvider.CheckDA.Update(objData);
        }
        #endregion
        
        #region web_Check_Check_List_GetAll
        /// <summary>
        /// 
        /// </summary>
        public static List<CheckDetail> GetAll( )
        {
            return SiteProvider.CheckDA.GetAll();
        }
        
        #endregion
        
        #region web_Check_Check_Only_GetByID
        /// <summary>
        /// 
        /// </summary>
        public static CheckDetail GetByID(int iD )
        {
            return SiteProvider.CheckDA.GetByID(iD);
        }
        
        #endregion
        
        #region web_Check_Check_Page_GetByCondition
        /// <summary>
        /// 
        /// </summary>
        public static List<CheckDetail> GetByCondition(string keyWord,string statusCode,string departmentCode,DateTime startDate,DateTime endDate,string operatorCode,int pageIndex,int pageSize ,out int totalNum,out int totalPage )
        {
            return SiteProvider.CheckDA.GetByCondition(keyWord,statusCode,departmentCode,startDate,endDate,operatorCode,pageIndex,pageSize,out totalNum,out totalPage );
        }
        
        #endregion
        
        
    }
}


