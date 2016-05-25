using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;

namespace WebWMS.Detail
{
    /// </summary>
    ///  This is OutStockDetail class
    ///  For the DataBase Table OutStock
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class OutStockDetail 
    {
        #region  Constructor
        public OutStockDetail()
        {
			this._iD = "";
			this._task = "";
			this._name = "";
			this._departmentCode = "";
			this._departmentName = "";
			this._startDate = DateTime.Now;
			this._endDate = DateTime.Now;
			this._operatorCode = "";
			this._operatorName = "";
			this._note = "";
        }
        
        public OutStockDetail(string iD,string task,string name,string departmentCode,string departmentName,DateTime startDate,DateTime endDate,string operatorCode,string operatorName,string note)
        {
			this._iD = iD;
			this._task = task;
			this._name = name;
			this._departmentCode = departmentCode;
			this._departmentName = departmentName;
			this._startDate = startDate;
			this._endDate = endDate;
			this._operatorCode = operatorCode;
			this._operatorName = operatorName;
			this._note = note;
        }
        #endregion
        
        #region  Properties
        /// <summary>
        ///
        /// </summary>
        public string ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public string Task
        {
            get { return _task; }
            set { _task = value; }
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
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public string OperatorCode
        {
            get { return _operatorCode; }
            set { _operatorCode = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public string OperatorName
        {
            get { return _operatorName; }
            set { _operatorName = value; }
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
		private string _iD;
		private string _task;
		private string _name;
		private string _departmentCode;
		private string _departmentName;
		private DateTime _startDate;
		private DateTime _endDate;
		private string _operatorCode;
		private string _operatorName;
		private string _note;
        #endregion

    
    }
}


