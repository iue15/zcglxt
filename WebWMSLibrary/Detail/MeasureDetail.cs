using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;

namespace WebWMS.Detail
{
    /// </summary>
    ///  This is MeasureDetail class
    ///  For the DataBase Table Measure
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class MeasureDetail 
    {
        #region  Constructor
        public MeasureDetail()
        {
			this._code = "";
			this._name = "";
			this._note = "";
        }
        
        public MeasureDetail(string code,string name,string note)
        {
			this._code = code;
			this._name = name;
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
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        #endregion
        
        #region Internal member variables
		private string _code;
		private string _name;
		private string _note;
        #endregion

    
    }
}


