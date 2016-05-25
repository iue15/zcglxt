using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;

namespace WebWMS.Detail
{
    /// </summary>
    ///  This is AssistDetail class
    ///  For the DataBase Table Assist
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class AssistDetail 
    {
        #region  Constructor
        public AssistDetail()
        {
			this._classCode = "";
			this._code = "";
			this._name = "";
			this._sort = -1;
			this._note = "";
        }
        
        public AssistDetail(string classCode,string code,string name,int sort,string note)
        {
			this._classCode = classCode;
			this._code = code;
			this._name = name;
			this._sort = sort;
			this._note = note;
        }
        #endregion
        
        #region  Properties
        /// <summary>
        ///
        /// </summary>
        public string ClassCode
        {
            get { return _classCode; }
            set { _classCode = value; }
        }

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
        public int Sort
        {
            get { return _sort; }
            set { _sort = value; }
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
		private string _classCode;
		private string _code;
		private string _name;
		private int _sort;
		private string _note;
        #endregion

    
    }
}


