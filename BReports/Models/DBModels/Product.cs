namespace BReports.Models.DBModels
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public bool IsDeleted { get; set; }
    }
}
