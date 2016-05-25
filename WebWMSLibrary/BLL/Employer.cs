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
    ///  This is Employer BLL class
    ///  For the DataBase Table Employer
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class Employer 
    {
        #region Settings Define
        protected static EmployerElement Settings
        {
            get { return Globals.Settings.Employer; }
        }
        #endregion
        
        #region web_Employer_Employer_Int_Delete
        /// <summary>
        /// 
        /// </summary>
        public static int Delete(string code )
        {
            return SiteProvider.EmployerDA.Delete(code);
        }
        
        #endregion
        
        #region web_Employer_Employer_Int_Insert
        /// <summary>
        /// 
        /// </summary>
        public static int Insert(string name,string job,string departmentCode,string note )
        {
            return SiteProvider.EmployerDA.Insert(name,job,departmentCode,note);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Insert(EmployerDetail obj)
        {
            return SiteProvider.EmployerDA.Insert(obj);
        }
        
        public static int Insert(List<EmployerDetail> objData)
        {
            return SiteProvider.EmployerDA.Insert(objData);
        }
        #endregion
        
        #region web_Employer_Employer_Int_Move
        /// <summary>
        /// 
        /// </summary>
        public static int Move(string code,string departmentCode )
        {
            return SiteProvider.EmployerDA.Move(code,departmentCode);
        }
        
        #endregion
        
        #region web_Employer_Employer_Int_Update
        /// <summary>
        /// 
        /// </summary>
        public static int Update(string code,string name,string job,string note )
        {
            return SiteProvider.EmployerDA.Update(code,name,job,note);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Update(EmployerDetail obj)
        {
            return SiteProvider.EmployerDA.Update(obj);
        }
        
        public static int Update(List<EmployerDetail> objData)
        {
            return SiteProvider.EmployerDA.Update(objData);
        }
        #endregion
        
        #region web_Employer_Employer_List_GetAll
        /// <summary>
        /// 
        /// </summary>
        public static List<EmployerDetail> GetAll( )
        {
            return SiteProvider.EmployerDA.GetAll();
        }
        
        #endregion
        
        #region web_Employer_Employer_List_GetByDepartmentCode
        /// <summary>
        /// 
        /// </summary>
        public static List<EmployerDetail> GetByDepartmentCode(string departmentCode )
        {
            return SiteProvider.EmployerDA.GetByDepartmentCode(departmentCode);
        }
        
        #endregion
        
        #region web_Employer_Employer_Only_GetByCode
        /// <summary>
        /// 
        /// </summary>
        public static EmployerDetail GetByCode(string code )
        {
            return SiteProvider.EmployerDA.GetByCode(code);
        }
        
        #endregion
        
        #region web_Employer_Employer_Page_GetByCondition
        /// <summary>
        /// 
        /// </summary>
        public static List<EmployerDetail> GetByCondition(string keyWord,string departmentCode,int pageIndex,int pageSize ,out int totalNum,out int totalPage )
        {
            return SiteProvider.EmployerDA.GetByCondition(keyWord,departmentCode,pageIndex,pageSize,out totalNum,out totalPage );
        }
        
        #endregion
        
        #region web_Employer_Employer_Page_GetByDepartmentCode
        /// <summary>
        /// 
        /// </summary>
        public static List<EmployerDetail> GetByDepartmentCode(string departmentCode,int pageIndex,int pageSize ,out int totalNum,out int totalPage )
        {
            return SiteProvider.EmployerDA.GetByDepartmentCode(departmentCode,pageIndex,pageSize,out totalNum,out totalPage );
        }
        
        #endregion
        
        
    }
}


