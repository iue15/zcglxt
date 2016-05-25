namespace WebWMS.DAL
{
    public static class SiteProvider
    {
		public static AddModeProvider AddModeDA
		{
			get { return AddModeProvider.Instance; }
		}

		public static AssetProvider AssetDA
		{
			get { return AssetProvider.Instance; }
		}

		public static AssistProvider AssistDA
		{
			get { return AssistProvider.Instance; }
		}

		public static CategoryProvider CategoryDA
		{
			get { return CategoryProvider.Instance; }
		}

		public static CheckProvider CheckDA
		{
			get { return CheckProvider.Instance; }
		}

		public static CheckItemsProvider CheckItemsDA
		{
			get { return CheckItemsProvider.Instance; }
		}

		public static DealerProvider DealerDA
		{
			get { return DealerProvider.Instance; }
		}

		public static DepartmentProvider DepartmentDA
		{
			get { return DepartmentProvider.Instance; }
		}

		public static EmployerProvider EmployerDA
		{
			get { return EmployerProvider.Instance; }
		}

		public static InventoryProvider InventoryDA
		{
			get { return InventoryProvider.Instance; }
		}

		public static InventoryListProvider InventoryListDA
		{
			get { return InventoryListProvider.Instance; }
		}

		public static MeasureProvider MeasureDA
		{
			get { return MeasureProvider.Instance; }
		}

		public static MenuProvider MenuDA
		{
			get { return MenuProvider.Instance; }
		}

		public static OutStockProvider OutStockDA
		{
			get { return OutStockProvider.Instance; }
		}

		public static OutStockItemsProvider OutStockItemsDA
		{
			get { return OutStockItemsProvider.Instance; }
		}

		public static StatusProvider StatusDA
		{
			get { return StatusProvider.Instance; }
		}

		public static StorageProvider StorageDA
		{
			get { return StorageProvider.Instance; }
		}

		public static UserProvider UserDA
		{
			get { return UserProvider.Instance; }
		}

		public static wCategoryProvider wCategoryDA
		{
			get { return wCategoryProvider.Instance; }
		}

		public static wDepartmentEmployerProvider wDepartmentEmployerDA
		{
			get { return wDepartmentEmployerProvider.Instance; }
		}


   }
}
