using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;

namespace WebWMS.Detail
{
    /// </summary>
    ///  This is wDepartmentEmployerDetail class
    ///  For the DataBase Table wDepartmentEmployer
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class wDepartmentEmployerDetail 
    {
        #region  Constructor
        public wDepartmentEmployerDetail()
        {
			this._code = "";
			this._name = "";
			this._parentCode = "";
        }
        
        public wDepartmentEmployerDetail(string code,string name,string parentCode)
        {
			this._code = code;
			this._name = name;
			this._parentCode = parentCode;
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
        public string ParentCode
        {
            get { return _parentCode; }
            set { _parentCode = value; }
        }

        #endregion
        
        #region Internal member variables
		private string _code;
		private string _name;
		private string _parentCode;
        #endregion

    
    }
}


