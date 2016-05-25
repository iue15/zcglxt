using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;

namespace WebWMS.Detail
{
    /// </summary>
    ///  This is MenuDetail class
    ///  For the DataBase Table Menu
    ///  Created By SunYong 2016/4/3 
    /// </summary>
    public class MenuDetail 
    {
        #region  Constructor
        public MenuDetail()
        {
			this._moduleId = "";
			this._parentId = "";
			this._category = "";
			this._code = "";
			this._fullName = "";
			this._icon = "";
			this._location = "";
			this._target = "";
			this._level = -1;
			this._isexpand = -1;
			this._allowButton = -1;
			this._allowView = -1;
			this._allowForm = -1;
			this._authority = -1;
			this._dataScope = -1;
			this._remark = "";
			this._enabled = -1;
			this._sortCode = -1;
			this._deleteMark = -1;
			this._createDate = DateTime.Now;
			this._createUserId = "";
			this._createUserName = "";
			this._modifyDate = DateTime.Now;
			this._modifyUserId = "";
			this._modifyUserName = "";
        }
        
        public MenuDetail(string moduleId,string parentId,string category,string code,string fullName,string icon,string location,string target,int level,int isexpand,int allowButton,int allowView,int allowForm,int authority,int dataScope,string remark,int enabled,int sortCode,int deleteMark,DateTime createDate,string createUserId,string createUserName,DateTime modifyDate,string modifyUserId,string modifyUserName)
        {
			this._moduleId = moduleId;
			this._parentId = parentId;
			this._category = category;
			this._code = code;
			this._fullName = fullName;
			this._icon = icon;
			this._location = location;
			this._target = target;
			this._level = level;
			this._isexpand = isexpand;
			this._allowButton = allowButton;
			this._allowView = allowView;
			this._allowForm = allowForm;
			this._authority = authority;
			this._dataScope = dataScope;
			this._remark = remark;
			this._enabled = enabled;
			this._sortCode = sortCode;
			this._deleteMark = deleteMark;
			this._createDate = createDate;
			this._createUserId = createUserId;
			this._createUserName = createUserName;
			this._modifyDate = modifyDate;
			this._modifyUserId = modifyUserId;
			this._modifyUserName = modifyUserName;
        }
        #endregion
        
        #region  Properties
        /// <summary>
        ///模块主键
        /// </summary>
        public string ModuleId
        {
            get { return _moduleId; }
            set { _moduleId = value; }
        }

        /// <summary>
        ///父级主键
        /// </summary>
        public string ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }

        /// <summary>
        ///分类
        /// </summary>
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        /// <summary>
        ///编码
        /// </summary>
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        /// <summary>
        ///名称
        /// </summary>
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        /// <summary>
        ///图标
        /// </summary>
        public string Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        /// <summary>
        ///访问地址
        /// </summary>
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        /// <summary>
        ///目标
        /// </summary>
        public string Target
        {
            get { return _target; }
            set { _target = value; }
        }

        /// <summary>
        ///级别层次
        /// </summary>
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        /// <summary>
        ///展开
        /// </summary>
        public int Isexpand
        {
            get { return _isexpand; }
            set { _isexpand = value; }
        }

        /// <summary>
        ///动态按钮
        /// </summary>
        public int AllowButton
        {
            get { return _allowButton; }
            set { _allowButton = value; }
        }

        /// <summary>
        ///动态视图
        /// </summary>
        public int AllowView
        {
            get { return _allowView; }
            set { _allowView = value; }
        }

        /// <summary>
        ///动态表单
        /// </summary>
        public int AllowForm
        {
            get { return _allowForm; }
            set { _allowForm = value; }
        }

        /// <summary>
        ///访问权限
        /// </summary>
        public int Authority
        {
            get { return _authority; }
            set { _authority = value; }
        }

        /// <summary>
        ///数据范围
        /// </summary>
        public int DataScope
        {
            get { return _dataScope; }
            set { _dataScope = value; }
        }

        /// <summary>
        ///备注
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        /// <summary>
        ///有效
        /// </summary>
        public int Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        /// <summary>
        ///排序码
        /// </summary>
        public int SortCode
        {
            get { return _sortCode; }
            set { _sortCode = value; }
        }

        /// <summary>
        ///删除标记
        /// </summary>
        public int DeleteMark
        {
            get { return _deleteMark; }
            set { _deleteMark = value; }
        }

        /// <summary>
        ///创建时间
        /// </summary>
        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        /// <summary>
        ///创建用户主键
        /// </summary>
        public string CreateUserId
        {
            get { return _createUserId; }
            set { _createUserId = value; }
        }

        /// <summary>
        ///创建用户
        /// </summary>
        public string CreateUserName
        {
            get { return _createUserName; }
            set { _createUserName = value; }
        }

        /// <summary>
        ///修改时间
        /// </summary>
        public DateTime ModifyDate
        {
            get { return _modifyDate; }
            set { _modifyDate = value; }
        }

        /// <summary>
        ///修改用户主键
        /// </summary>
        public string ModifyUserId
        {
            get { return _modifyUserId; }
            set { _modifyUserId = value; }
        }

        /// <summary>
        ///修改用户
        /// </summary>
        public string ModifyUserName
        {
            get { return _modifyUserName; }
            set { _modifyUserName = value; }
        }

        #endregion
        
        #region Internal member variables
		private string _moduleId;
		private string _parentId;
		private string _category;
		private string _code;
		private string _fullName;
		private string _icon;
		private string _location;
		private string _target;
		private int _level;
		private int _isexpand;
		private int _allowButton;
		private int _allowView;
		private int _allowForm;
		private int _authority;
		private int _dataScope;
		private string _remark;
		private int _enabled;
		private int _sortCode;
		private int _deleteMark;
		private DateTime _createDate;
		private string _createUserId;
		private string _createUserName;
		private DateTime _modifyDate;
		private string _modifyUserId;
		private string _modifyUserName;
        #endregion

    
    }
}


