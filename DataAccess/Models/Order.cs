namespace Web_Project.DataModels
{
    public class Order
    {
        public int OrderID {get;set;}
        public DateTime OrderDate {get; set;}
        public string ProductName {get;set;}
        public string ProductImg { get; set; }
        public float ProductPrice {get;set;}
        public float ProductTotal {get;set;}
    }
}
