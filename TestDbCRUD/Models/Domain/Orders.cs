namespace TestDbCRUD.Models.Domain
{
    public class Orders
    {
        public Guid Id { get; set; }
        public string Contents { get; set; }
        public DateTime OrderDate { get; set; }
        public string Weight { get; set; }
        public string Dimentions { get; set; }
        public string Location { get; set; }


    }
}
