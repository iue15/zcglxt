using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;

namespace WebWMS.Detail
{
    /// </summary>
    ///  This is CheckDetail class
    ///  For the DataBase Table Check
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class CheckDetail 
    {
        #region  Constructor
        public CheckDetail()
        {
			this._iD = -1;
			this._taskName = "";
			this._mode = "";
			this._statusCode = "";
			this._statusName = "";
			this._departmentCode = "";
			this._departmentName = "";
			this._startDate = DateTime.Now;
			this._endDate = DateTime.Now;
			this._operatorCode = "";
			this._operatorName = "";
									this._note = "";
        }
        
        public CheckDetail(int iD,string taskName,string mode,string statusCode,string statusName,string departmentCode,string departmentName,DateTime startDate,DateTime endDate,string operatorCode,string operatorName,decimal inventoryQuantity,decimal actualQuantity,string note)
        {
			this._iD = iD;
			this._taskName = taskName;
			this._mode = mode;
			this._statusCode = statusCode;
			this._statusName = statusName;
			this._departmentCode = departmentCode;
			this._departmentName = departmentName;
			this._startDate = startDate;
			this._endDate = endDate;
			this._operatorCode = operatorCode;
			this._operatorName = operatorName;
			this._inventoryQuantity = inventoryQuantity;
			this._actualQuantity = actualQuantity;
			this._note = note;
        }
        #endregion
        
        #region  Properties
        /// <summary>
        ///
        /// </summary>
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        /// <summary>
        ///盘点任务名称
        /// </summary>
        public string TaskName
        {
            get { return _taskName; }
            set { _taskName = value; }
        }

        /// <summary>
        ///盘点模式
        /// </summary>
        public string Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public string StatusCode
        {
            get { return _statusCode; }
            set { _statusCode = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public string StatusName
        {
            get { return _statusName; }
            set { _statusName = value; }
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
        public decimal InventoryQuantity
        {
            get { return _inventoryQuantity; }
            set { _inventoryQuantity = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public decimal ActualQuantity
        {
            get { return _actualQuantity; }
            set { _actualQuantity = value; }
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
		private int _iD;
		private string _taskName;
		private string _mode;
		private string _statusCode;
		private string _statusName;
		private string _departmentCode;
		private string _departmentName;
		private DateTime _startDate;
		private DateTime _endDate;
		private string _operatorCode;
		private string _operatorName;
		private decimal _inventoryQuantity;
		private decimal _actualQuantity;
		private string _note;
        #endregion

    
    }
}


