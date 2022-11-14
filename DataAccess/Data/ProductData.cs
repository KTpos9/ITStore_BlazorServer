using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Project.DataModels;

namespace DataAccess.Data
{
    public class ProductData
    {
        private readonly SqlDataAccess _db;
        public ProductData(SqlDataAccess db)
        {
            _db = db;
        }
        public Task<List<Product>> GetProduct()
        {
            string sql = "select * from dbo.Product2";
            return _db.LoadData<Product, dynamic>(sql, new { });
        }
        public Task InsertProduct(Product product)
        {
            string sql = @"insert into dbo.Product2 (ProductImg, ProductName, ProductDesc, ProductPrice) 
                          values (@ProductImg, @ProductName, @ProductDesc, @ProductPrice);";
            return _db.SaveData(sql, product);
        }

        public Task<List<Product>> GetProductById(int ProductId)
        { 
            string sql = @"select * from dbo.Product2 where ProductId=@Id";
            return _db.LoadData<Product, dynamic>(sql, new {  Id=ProductId});
        }

        public Task UpdateProduct(Product product)
        {
            string sql = @"update dbo.Product2 set ProductImg=@ProductImg, ProductName=@ProductName, ProductDesc=@ProductDesc, ProductPrice=@ProductPrice where ProductId=@ProductId";
            return _db.SaveData(sql, product);
        }



    }
}
