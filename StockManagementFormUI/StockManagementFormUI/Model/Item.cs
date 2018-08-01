namespace StockManagementFormUI.Model
{
    class Item
    {
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public int ReorderLevel { get; set; }
        public string Name { get; set; }
    }
}
