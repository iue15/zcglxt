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
    ///  This is Measure BLL class
    ///  For the DataBase Table Measure
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class Measure 
    {
        #region Settings Define
        protected static MeasureElement Settings
        {
            get { return Globals.Settings.Measure; }
        }
        #endregion
        
        #region web_Measure_Measure_Int_Delete
        /// <summary>
        /// 
        /// </summary>
        public static int Delete(string code )
        {
            return SiteProvider.MeasureDA.Delete(code);
        }
        
        #endregion
        
        #region web_Measure_Measure_Int_Insert
        /// <summary>
        /// 
        /// </summary>
        public static int Insert(string name,string note )
        {
            return SiteProvider.MeasureDA.Insert(name,note);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Insert(MeasureDetail obj)
        {
            return SiteProvider.MeasureDA.Insert(obj);
        }
        
        public static int Insert(List<MeasureDetail> objData)
        {
            return SiteProvider.MeasureDA.Insert(objData);
        }
        #endregion
        
        #region web_Measure_Measure_Int_Update
        /// <summary>
        /// 
        /// </summary>
        public static int Update(string code,string name,string note )
        {
            return SiteProvider.MeasureDA.Update(code,name,note);
        }
        
        /// <summary>
        /// ??
        /// </summary>
        public static int Update(MeasureDetail obj)
        {
            return SiteProvider.MeasureDA.Update(obj);
        }
        
        public static int Update(List<MeasureDetail> objData)
        {
            return SiteProvider.MeasureDA.Update(objData);
        }
        #endregion
        
        #region web_Measure_Measure_List_GetAll
        /// <summary>
        /// 
        /// </summary>
        public static List<MeasureDetail> GetAll( )
        {
            return SiteProvider.MeasureDA.GetAll();
        }
        
        #endregion
        
        #region web_Measure_Measure_Only_GetByCode
        /// <summary>
        /// 
        /// </summary>
        public static MeasureDetail GetByCode(string code )
        {
            return SiteProvider.MeasureDA.GetByCode(code);
        }
        
        #endregion
        
        
    }
}


