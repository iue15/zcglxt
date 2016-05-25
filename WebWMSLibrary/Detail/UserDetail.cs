using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;

namespace WebWMS.Detail
{
    /// </summary>
    ///  This is UserDetail class
    ///  For the DataBase Table User
    ///  Created By SunYong 2016/4/4 
    /// </summary>
    public class UserDetail 
    {
        #region  Constructor
        public UserDetail()
        {
			this._iD = -1;
			this._code = "";
			this._name = "";
			this._password = "";
			this._note = "";
        }
        
        public UserDetail(int iD,string code,string name,string password,string note)
        {
			this._iD = iD;
			this._code = code;
			this._name = name;
			this._password = password;
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
        public string Password
        {
            get { return _password; }
            set { _password = value; }
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
		private string _code;
		private string _name;
		private string _password;
		private string _note;
        #endregion

    
    }
}


