using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;

namespace WebWMS.Detail
{
    /// </summary>
    ///  This is DepartmentDetail class
    ///  For the DataBase Table Department
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class DepartmentDetail 
    {
        #region  Constructor
        public DepartmentDetail()
        {
			this._code = "";
			this._name = "";
			this._user = "";
			this._job = "";
			this._parentCode = "";
			this._parentName = "";
			this._note = "";
        }
        
        public DepartmentDetail(string code,string name,string user,string job,string parentCode,string parentName,string note)
        {
			this._code = code;
			this._name = name;
			this._user = user;
			this._job = job;
			this._parentCode = parentCode;
			this._parentName = parentName;
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
        ///负责人
        /// </summary>
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }

        /// <summary>
        ///职务
        /// </summary>
        public string Job
        {
            get { return _job; }
            set { _job = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ParentCode
        {
            get { return _parentCode; }
            set { _parentCode = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ParentName
        {
            get { return _parentName; }
            set { _parentName = value; }
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
		private string _user;
		private string _job;
		private string _parentCode;
		private string _parentName;
		private string _note;
        #endregion

    
    }
}


