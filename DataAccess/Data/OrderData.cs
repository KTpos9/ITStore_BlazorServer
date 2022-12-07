using Web_Project.DataModels;

namespace DataAccess.Data
{
    public class OrderData
    {
                private readonly SqlDataAccess _db;
        public OrderData(SqlDataAccess db)
        {
            _db = db;
        }
        public Task<List<Order>> GetOrder()
        {
            string sql = "select * from dbo.Order2";
            return _db.LoadData<Order, dynamic>(sql, new { });
        }
        public Task InsertOrder(Order newOrder)
        {
            string sql = @"insert into dbo.Order2 (OrderDate, ProductName, ProductImg, ProductPrice) 
                          values (@Img, @Name, @Desc, @Price);";
            return _db.SaveData(sql, new {Date = newOrder.OrderDate,Name = newOrder.ProductName, Img = newOrder.ProductImg,  Price = newOrder.ProductPrice });
        }

        public Task<List<Order>> GetOrderById(int Id)
        {
            string sql = @"select * from dbo.Order2 where ProductId=@Id";
            return _db.LoadData<Order, dynamic>(sql, new { Id = Id });
        }

        public Task UpdateOrder(Order order)
        {
            string sql = @"update dbo.Order2 set ProductImg=@ProductImg, ProductName=@ProductName, ProductDesc=@ProductDesc, ProductPrice=@ProductPrice where ProductId=@ProductId";
            return _db.SaveData(sql, order);
        }

        public Task DeleteProduct(int Id)
        {
            string sql = @"delete from dbo.Order2 
                          where OrderID = @Id";
            return _db.SaveData(sql, new { Id= Id});
        }
    }
}