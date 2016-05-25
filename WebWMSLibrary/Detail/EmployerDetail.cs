using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;

namespace WebWMS.Detail
{
    /// </summary>
    ///  This is EmployerDetail class
    ///  For the DataBase Table Employer
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class EmployerDetail 
    {
        #region  Constructor
        public EmployerDetail()
        {
			this._code = "";
			this._name = "";
			this._job = "";
			this._departmentCode = "";
			this._departmentName = "";
			this._note = "";
        }
        
        public EmployerDetail(string code,string name,string job,string departmentCode,string departmentName,string note)
        {
			this._code = code;
			this._name = name;
			this._job = job;
			this._departmentCode = departmentCode;
			this._departmentName = departmentName;
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
        public string Job
        {
            get { return _job; }
            set { _job = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public string DepartmentCode
        {
            get { return _departmentCode; }
            set { _departmentCode = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public string DepartmentName
        {
            get { return _departmentName; }
            set { _departmentName = value; }
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
		private string _job;
		private string _departmentCode;
		private string _departmentName;
		private string _note;
        #endregion

    
    }
}


