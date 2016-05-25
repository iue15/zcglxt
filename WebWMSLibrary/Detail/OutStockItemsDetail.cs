using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;

namespace WebWMS.Detail
{
    /// </summary>
    ///  This is OutStockItemsDetail class
    ///  For the DataBase Table OutStockItems
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class OutStockItemsDetail 
    {
        #region  Constructor
        public OutStockItemsDetail()
        {
			this._iD = "";
			this._billID = "";
			this._code = "";
			this._name = "";
			this._barCode = "";
			this._departmentCode = "";
			this._departmentName = "";
						this._checkTime = DateTime.Now;
			this._statusCode = "";
			this._statusName = "";
			this._checkUser = "";
						this._note = "";
        }
        
        public OutStockItemsDetail(string iD,string billID,string code,string name,string barCode,string departmentCode,string departmentName,decimal inventoryQuantity,DateTime checkTime,string statusCode,string statusName,string checkUser,decimal quantity,string note)
        {
			this._iD = iD;
			this._billID = billID;
			this._code = code;
			this._name = name;
			this._barCode = barCode;
			this._departmentCode = departmentCode;
			this._departmentName = departmentName;
			this._inventoryQuantity = inventoryQuantity;
			this._checkTime = checkTime;
			this._statusCode = statusCode;
			this._statusName = statusName;
			this._checkUser = checkUser;
			this._quantity = quantity;
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
        public string BillID
        {
            get { return _billID; }
            set { _billID = value; }
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
        public string BarCode
        {
            get { return _barCode; }
            set { _barCode = value; }
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
        public decimal InventoryQuantity
        {
            get { return _inventoryQuantity; }
            set { _inventoryQuantity = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public DateTime CheckTime
        {
            get { return _checkTime; }
            set { _checkTime = value; }
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
        public string CheckUser
        {
            get { return _checkUser; }
            set { _checkUser = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public decimal Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
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
		private string _billID;
		private string _code;
		private string _name;
		private string _barCode;
		private string _departmentCode;
		private string _departmentName;
		private decimal _inventoryQuantity;
		private DateTime _checkTime;
		private string _statusCode;
		private string _statusName;
		private string _checkUser;
		private decimal _quantity;
		private string _note;
        #endregion

    
    }
}


