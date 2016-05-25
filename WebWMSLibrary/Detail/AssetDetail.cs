using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;

namespace WebWMS.Detail
{
    /// </summary>
    ///  This is AssetDetail class
    ///  For the DataBase Table Asset
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class AssetDetail 
    {
        #region  Constructor
        public AssetDetail()
        {
			this._code = "";
			this._name = "";
			this._chartNumber = "";
			this._categoryCode = "";
			this._categoryName = "";
			this._measureCode = "";
			this._measureName = "";
			this._note = "";
        }
        
        public AssetDetail(string code,string name,string chartNumber,string categoryCode,string categoryName,string measureCode,string measureName,string note)
        {
			this._code = code;
			this._name = name;
			this._chartNumber = chartNumber;
			this._categoryCode = categoryCode;
			this._categoryName = categoryName;
			this._measureCode = measureCode;
			this._measureName = measureName;
			this._note = note;
        }
        #endregion
        
        #region  Properties
        /// <summary>
        ///
        /// </summary>
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ChartNumber
        {
            get { return _chartNumber; }
            set { _chartNumber = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public string CategoryCode
        {
            get { return _categoryCode; }
            set { _categoryCode = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public string MeasureCode
        {
            get { return _measureCode; }
            set { _measureCode = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public string MeasureName
        {
            get { return _measureName; }
            set { _measureName = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        #endregion
        
        #region Internal member variables
		private string _code;
		private string _name;
		private string _chartNumber;
		private string _categoryCode;
		private string _categoryName;
		private string _measureCode;
		private string _measureName;
		private string _note;
        #endregion

    
    }
}


