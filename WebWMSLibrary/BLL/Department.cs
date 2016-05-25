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
    ///  This is Department BLL class
    ///  For the DataBase Table Department
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class Department 
    {
        #region Settings Define
        protected static DepartmentElement Settings
        {
            get { return Globals.Settings.Department; }
        }
        #endregion
        
        #region web_Department_Department_Int_Delete
        /// <summary>
        /// 
        /// </summary>
        public static int Delete(string code )
        {
            return SiteProvider.DepartmentDA.Delete(code);
        }
        
        #endregion
        
        #region web_Department_Department_Int_Insert
        /// <summary>
        /// 
        /// </summary>
        public static int Insert(string name,string user,string job,string note,string parentCode )
        {
            return SiteProvider.DepartmentDA.Insert(name,user,job,note,parentCode);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Insert(DepartmentDetail obj)
        {
            return SiteProvider.DepartmentDA.Insert(obj);
        }
        
        public static int Insert(List<DepartmentDetail> objData)
        {
            return SiteProvider.DepartmentDA.Insert(objData);
        }
        #endregion
        
        #region web_Department_Department_Int_Update
        /// <summary>
        /// 
        /// </summary>
        public static int Update(string code,string name,string user,string job,string note )
        {
            return SiteProvider.DepartmentDA.Update(code,name,user,job,note);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Update(DepartmentDetail obj)
        {
            return SiteProvider.DepartmentDA.Update(obj);
        }
        
        public static int Update(List<DepartmentDetail> objData)
        {
            return SiteProvider.DepartmentDA.Update(objData);
        }
        #endregion
        
        #region web_Department_Department_List_GetAll
        /// <summary>
        /// 
        /// </summary>
        public static List<DepartmentDetail> GetAll( )
        {
            return SiteProvider.DepartmentDA.GetAll();
        }
        
        #endregion
        
        #region web_Department_Department_Only_GetByCode
        /// <summary>
        /// 
        /// </summary>
        public static DepartmentDetail GetByCode(string code )
        {
            return SiteProvider.DepartmentDA.GetByCode(code);
        }
        
        #endregion
        
        #region web_Department_Department_Page_GetByCondition
        /// <summary>
        /// 
        /// </summary>
        public static List<DepartmentDetail> GetByCondition(string keyWord,int pageIndex,int pageSize ,out int totalNum,out int totalPage )
        {
            return SiteProvider.DepartmentDA.GetByCondition(keyWord,pageIndex,pageSize,out totalNum,out totalPage );
        }
        
        #endregion
        
        
    }
}


