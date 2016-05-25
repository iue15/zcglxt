using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;

namespace WebWMS.Detail
{
    /// </summary>
    ///  This is InventoryListDetail class
    ///  For the DataBase Table InventoryList
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class InventoryListDetail 
    {
        #region  Constructor
        public InventoryListDetail()
        {
			this._iD = -1;
			this._billID = "";
			this._departmentCode = "";
			this._departmentName = "";
			this._venderCode = "";
			this._venderName = "";
			this._operatorCode = "";
			this._operatorName = "";
			this._addTime = "";
			this._note = "";
        }
        
        public InventoryListDetail(int iD,string billID,string departmentCode,string departmentName,string venderCode,string venderName,string operatorCode,string operatorName,string addTime,string note)
        {
			this._iD = iD;
			this._billID = billID;
			this._departmentCode = departmentCode;
			this._departmentName = departmentName;
			this._venderCode = venderCode;
			this._venderName = venderName;
			this._operatorCode = operatorCode;
			this._operatorName = operatorName;
			this._addTime = addTime;
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
        ///
        /// </summary>
        public string BillID
        {
            get { return _billID; }
            set { _billID = value; }
        }

        /// <summary>
        ///原部门代码
        /// </summary>
        public string DepartmentCode
        {
            get { return _departmentCode; }
            set { _departmentCode = value; }
        }

        /// <summary>
        ///原部门名称
        /// </summary>
        public string DepartmentName
        {
            get { return _departmentName; }
            set { _departmentName = value; }
        }

        /// <summary>
        ///新部门代码
        /// </summary>
        public string VenderCode
        {
            get { return _venderCode; }
            set { _venderCode = value; }
        }

        /// <summary>
        ///新部门名称
        /// </summary>
        public string VenderName
        {
            get { return _venderName; }
            set { _venderName = value; }
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
        public string AddTime
        {
            get { return _addTime; }
            set { _addTime = value; }
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
		private string _billID;
		private string _departmentCode;
		private string _departmentName;
		private string _venderCode;
		private string _venderName;
		private string _operatorCode;
		private string _operatorName;
		private string _addTime;
		private string _note;
        #endregion

    
    }
}


