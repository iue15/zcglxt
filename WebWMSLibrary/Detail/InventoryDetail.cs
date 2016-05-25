using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;

namespace WebWMS.Detail
{
    /// </summary>
    ///  This is InventoryDetail class
    ///  For the DataBase Table Inventory
    ///  Created By SunYong 2016/4/5 
    /// </summary>
    public class InventoryDetail 
    {
        #region  Constructor
        public InventoryDetail()
        {
			this._iD = "";
			this._code = "";
			this._name = "";
			this._measureCode = "";
			this._measureName = "";
			this._chartNumber = "";
			this._categoryCode = "";
			this._categoryName = "";
			this._statusCode = "";
			this._statusName = "";
			this._barCode = "";
																		this._storageCode = "";
			this._storageName = "";
			this._departmentCode = "";
			this._departmentName = "";
			this._userCode = "";
			this._userName = "";
			this._addModeCode = "";
			this._addModeName = "";
			this._addTime = "";
			this._operatorCode = "";
			this._operatorName = "";
			this._note = "";
        }
        
        public InventoryDetail(string iD,string code,string name,string measureCode,string measureName,string chartNumber,string categoryCode,string categoryName,string statusCode,string statusName,string barCode,decimal quantity,decimal limitYear,decimal residualRate,decimal originalValue,decimal presentValue,string storageCode,string storageName,string departmentCode,string departmentName,string userCode,string userName,string addModeCode,string addModeName,string addTime,string operatorCode,string operatorName,string note)
        {
			this._iD = iD;
			this._code = code;
			this._name = name;
			this._measureCode = measureCode;
			this._measureName = measureName;
			this._chartNumber = chartNumber;
			this._categoryCode = categoryCode;
			this._categoryName = categoryName;
			this._statusCode = statusCode;
			this._statusName = statusName;
			this._barCode = barCode;
			this._quantity = quantity;
			this._limitYear = limitYear;
			this._residualRate = residualRate;
			this._originalValue = originalValue;
			this._presentValue = presentValue;
			this._storageCode = storageCode;
			this._storageName = storageName;
			this._departmentCode = departmentCode;
			this._departmentName = departmentName;
			this._userCode = userCode;
			this._userName = userName;
			this._addModeCode = addModeCode;
			this._addModeName = addModeName;
			this._addTime = addTime;
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
        ///资产编码
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
        ///规格型号
        /// </summary>
        public string ChartNumber
        {
            get { return _chartNumber; }
            set { _chartNumber = value; }
        }

        /// <summary>
        ///资产类型编码
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
        ///资产条码
        /// </summary>
        public string BarCode
        {
            get { return _barCode; }
            set { _barCode = value; }
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
        ///使用年限
        /// </summary>
        public decimal LimitYear
        {
            get { return _limitYear; }
            set { _limitYear = value; }
        }

        /// <summary>
        ///残值率
        /// </summary>
        public decimal ResidualRate
        {
            get { return _residualRate; }
            set { _residualRate = value; }
        }

        /// <summary>
        ///资产原值
        /// </summary>
        public decimal OriginalValue
        {
            get { return _originalValue; }
            set { _originalValue = value; }
        }

        /// <summary>
        ///资产现值
        /// </summary>
        public decimal PresentValue
        {
            get { return _presentValue; }
            set { _presentValue = value; }
        }

        /// <summary>
        ///存放位置编码
        /// </summary>
        public string StorageCode
        {
            get { return _storageCode; }
            set { _storageCode = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public string StorageName
        {
            get { return _storageName; }
            set { _storageName = value; }
        }

        /// <summary>
        ///使用部门编码
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
        ///使用人编码
        /// </summary>
        public string UserCode
        {
            get { return _userCode; }
            set { _userCode = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        /// <summary>
        ///增加方式编码
        /// </summary>
        public string AddModeCode
        {
            get { return _addModeCode; }
            set { _addModeCode = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public string AddModeName
        {
            get { return _addModeName; }
            set { _addModeName = value; }
        }

        /// <summary>
        ///添加时间
        /// </summary>
        public string AddTime
        {
            get { return _addTime; }
            set { _addTime = value; }
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
        ///添加人
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
		private string _code;
		private string _name;
		private string _measureCode;
		private string _measureName;
		private string _chartNumber;
		private string _categoryCode;
		private string _categoryName;
		private string _statusCode;
		private string _statusName;
		private string _barCode;
		private decimal _quantity;
		private decimal _limitYear;
		private decimal _residualRate;
		private decimal _originalValue;
		private decimal _presentValue;
		private string _storageCode;
		private string _storageName;
		private string _departmentCode;
		private string _departmentName;
		private string _userCode;
		private string _userName;
		private string _addModeCode;
		private string _addModeName;
		private string _addTime;
		private string _operatorCode;
		private string _operatorName;
		private string _note;
        #endregion

    
    }
}


