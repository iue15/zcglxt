using System;
using System.Configuration;

namespace WebWMS
{
    public class WebWMSSection : ConfigurationSection
    {
        [ConfigurationProperty("defaultConnectionStringName", DefaultValue = "LocalSqlServer")]
        public string DefaultConnectionStringName
        {
            get { return (string)base["defaultConnectionStringName"]; }
            set { base["connectionStdefaultConnectionStringNameringName"] = value; }
        }

        [ConfigurationProperty("defaultCacheDuration", DefaultValue = "600")]
        public int DefaultCacheDuration
        {
            get { return (int)base["defaultCacheDuration"]; }
            set { base["defaultCacheDuration"] = value; }
        }
        
        #region Member AddMode
        [ConfigurationProperty("addMode", IsRequired = true)]
        public AddModeElement AddMode
        {
            get { return (AddModeElement)base["addMode"]; }
        }
        #endregion
        
        #region Member Asset
        [ConfigurationProperty("asset", IsRequired = true)]
        public AssetElement Asset
        {
            get { return (AssetElement)base["asset"]; }
        }
        #endregion
        
        #region Member Assist
        [ConfigurationProperty("assist", IsRequired = true)]
        public AssistElement Assist
        {
            get { return (AssistElement)base["assist"]; }
        }
        #endregion
        
        #region Member Category
        [ConfigurationProperty("category", IsRequired = true)]
        public CategoryElement Category
        {
            get { return (CategoryElement)base["category"]; }
        }
        #endregion

        #region Member Check
        [ConfigurationProperty("check", IsRequired = true)]
        public CheckElement Check
        {
            get { return (CheckElement)base["check"]; }
        }
        #endregion
        
        #region Member CheckItems
        [ConfigurationProperty("checkItems", IsRequired = true)]
        public CheckItemsElement CheckItems
        {
            get { return (CheckItemsElement)base["checkItems"]; }
        }
        #endregion
        
        #region Member Dealer
        [ConfigurationProperty("dealer", IsRequired = true)]
        public DealerElement Dealer
        {
            get { return (DealerElement)base["dealer"]; }
        }
        #endregion
        
        #region Member Department
        [ConfigurationProperty("department", IsRequired = true)]
        public DepartmentElement Department
        {
            get { return (DepartmentElement)base["department"]; }
        }
        #endregion
        
        #region Member Employer
        [ConfigurationProperty("employer", IsRequired = true)]
        public EmployerElement Employer
        {
            get { return (EmployerElement)base["employer"]; }
        }
        #endregion
        
        #region Member Inventory
        [ConfigurationProperty("inventory", IsRequired = true)]
        public InventoryElement Inventory
        {
            get { return (InventoryElement)base["inventory"]; }
        }
        #endregion
        
        #region Member InventoryList
        [ConfigurationProperty("inventoryList", IsRequired = true)]
        public InventoryListElement InventoryList
        {
            get { return (InventoryListElement)base["inventoryList"]; }
        }
        #endregion
        
        #region Member Measure
        [ConfigurationProperty("measure", IsRequired = true)]
        public MeasureElement Measure
        {
            get { return (MeasureElement)base["measure"]; }
        }
        #endregion
        
        #region Member Menu
        [ConfigurationProperty("menu", IsRequired = true)]
        public MenuElement Menu
        {
            get { return (MenuElement)base["menu"]; }
        }
        #endregion
        
        #region Member OutStock
        [ConfigurationProperty("outStock", IsRequired = true)]
        public OutStockElement OutStock
        {
            get { return (OutStockElement)base["outStock"]; }
        }
        #endregion
        
        #region Member OutStockItems
        [ConfigurationProperty("outStockItems", IsRequired = true)]
        public OutStockItemsElement OutStockItems
        {
            get { return (OutStockItemsElement)base["outStockItems"]; }
        }
        #endregion
        
        #region Member Status
        [ConfigurationProperty("status", IsRequired = true)]
        public StatusElement Status
        {
            get { return (StatusElement)base["status"]; }
        }
        #endregion
        
        #region Member Storage
        [ConfigurationProperty("storage", IsRequired = true)]
        public StorageElement Storage
        {
            get { return (StorageElement)base["storage"]; }
        }
        #endregion
        
        #region Member User
        [ConfigurationProperty("user", IsRequired = true)]
        public UserElement User
        {
            get { return (UserElement)base["user"]; }
        }
        #endregion
        
        
        #region Member wCategory
        [ConfigurationProperty("wCategory", IsRequired = true)]
        public wCategoryElement wCategory
        {
            get { return (wCategoryElement)base["wCategory"]; }
        }
        #endregion

        #region Member wDepartmentEmployer
        [ConfigurationProperty("wDepartmentEmployer", IsRequired = true)]
        public wDepartmentEmployerElement wDepartmentEmployer
        {
            get { return (wDepartmentEmployerElement)base["wDepartmentEmployer"]; }
        }
        #endregion
        
    }
    
    #region Class AddModeElement
    public class AddModeElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (String)base["connectionStringName"]; }
            set { base["connectionString"] = value; }
        }


        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
                //return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "WebWMS.DAL.SqlClient.SqlAddModeProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }
    #endregion
    
    #region Class AssetElement
    public class AssetElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (String)base["connectionStringName"]; }
            set { base["connectionString"] = value; }
        }


        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
                //return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "WebWMS.DAL.SqlClient.SqlAssetProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }
    #endregion
    
    #region Class AssistElement
    public class AssistElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (String)base["connectionStringName"]; }
            set { base["connectionString"] = value; }
        }


        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
                //return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "WebWMS.DAL.SqlClient.SqlAssistProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }
    #endregion
    
    #region Class CategoryElement
    public class CategoryElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (String)base["connectionStringName"]; }
            set { base["connectionString"] = value; }
        }


        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
                //return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "WebWMS.DAL.SqlClient.SqlCategoryProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }
    #endregion

    #region Class CheckElement
    public class CheckElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (String)base["connectionStringName"]; }
            set { base["connectionString"] = value; }
        }


        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
                //return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "WebWMS.DAL.SqlClient.SqlCheckProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }
    #endregion
    
    #region Class CheckItemsElement
    public class CheckItemsElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (String)base["connectionStringName"]; }
            set { base["connectionString"] = value; }
        }


        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
                //return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "WebWMS.DAL.SqlClient.SqlCheckItemsProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }
    #endregion
    
    #region Class DealerElement
    public class DealerElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (String)base["connectionStringName"]; }
            set { base["connectionString"] = value; }
        }


        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
                //return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "WebWMS.DAL.SqlClient.SqlDealerProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }
    #endregion
    
    #region Class DepartmentElement
    public class DepartmentElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (String)base["connectionStringName"]; }
            set { base["connectionString"] = value; }
        }


        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
                //return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "WebWMS.DAL.SqlClient.SqlDepartmentProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }
    #endregion
    
    #region Class EmployerElement
    public class EmployerElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (String)base["connectionStringName"]; }
            set { base["connectionString"] = value; }
        }


        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
                //return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "WebWMS.DAL.SqlClient.SqlEmployerProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }
    #endregion
    
    #region Class InventoryElement
    public class InventoryElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (String)base["connectionStringName"]; }
            set { base["connectionString"] = value; }
        }


        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
                //return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "WebWMS.DAL.SqlClient.SqlInventoryProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }
    #endregion
    
    #region Class InventoryListElement
    public class InventoryListElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (String)base["connectionStringName"]; }
            set { base["connectionString"] = value; }
        }


        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
                //return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "WebWMS.DAL.SqlClient.SqlInventoryListProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }
    #endregion
    
    #region Class MeasureElement
    public class MeasureElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (String)base["connectionStringName"]; }
            set { base["connectionString"] = value; }
        }


        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
                //return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "WebWMS.DAL.SqlClient.SqlMeasureProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }
    #endregion
    
    #region Class MenuElement
    public class MenuElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (String)base["connectionStringName"]; }
            set { base["connectionString"] = value; }
        }


        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
                //return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "WebWMS.DAL.SqlClient.SqlMenuProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }
    #endregion
    
    #region Class OutStockElement
    public class OutStockElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (String)base["connectionStringName"]; }
            set { base["connectionString"] = value; }
        }


        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
                //return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "WebWMS.DAL.SqlClient.SqlOutStockProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }
    #endregion
    
    #region Class OutStockItemsElement
    public class OutStockItemsElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (String)base["connectionStringName"]; }
            set { base["connectionString"] = value; }
        }


        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
                //return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "WebWMS.DAL.SqlClient.SqlOutStockItemsProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }
    #endregion
    
    #region Class StatusElement
    public class StatusElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (String)base["connectionStringName"]; }
            set { base["connectionString"] = value; }
        }


        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
                //return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "WebWMS.DAL.SqlClient.SqlStatusProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }
    #endregion
    
    #region Class StorageElement
    public class StorageElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (String)base["connectionStringName"]; }
            set { base["connectionString"] = value; }
        }


        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
                return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "WebWMS.DAL.SqlClient.SqlStorageProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }
    #endregion
    
    #region Class UserElement
    public class UserElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (String)base["connectionStringName"]; }
            set { base["connectionString"] = value; }
        }


        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
                //return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "WebWMS.DAL.SqlClient.SqlUserProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }
    #endregion    
    
    #region Class wCategoryElement
    public class wCategoryElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (String)base["connectionStringName"]; }
            set { base["connectionString"] = value; }
        }


        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
                //return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "WebWMS.DAL.SqlClient.SqlwCategoryProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }
    #endregion

    #region Class wDepartmentEmployerElement
    public class wDepartmentEmployerElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (String)base["connectionStringName"]; }
            set { base["connectionString"] = value; }
        }


        public string ConnectionString
        {
            get
            {
                string connStringName = (string.IsNullOrEmpty(this.ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : this.ConnectionStringName);
                return ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
                //return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "WebWMS.DAL.SqlClient.SqlwDepartmentEmployerProvider")]
        public string ProviderType
        {
            get { return (string)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }
    #endregion
}


