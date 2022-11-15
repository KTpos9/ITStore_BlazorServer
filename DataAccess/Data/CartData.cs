using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class CartData
    {
        private readonly SqlDataAccess _db;
        public CartData(SqlDataAccess db)
        {
            _db = db;
        }
        public Task<List<Cart>> GetCart()
        {
            string sql = "select * from dbo.Cart2";
            return _db.LoadData<Cart, dynamic>(sql, new { });
        }
        public Task InsertCart(Cart cart)
        {
            string sql = @"insert into dbo.Cart2 (ProductImg, ProductName, ProductPrice) 
                          values (@ProductImg, @ProductName, @ProductPrice);";
            return _db.SaveData(sql, cart);
        }
        public Task DeleteCartByID(int id)
        {
            string sql = @"delete from dbo.Cart2
                           where CartID = @CartID";
            return _db.SaveData(sql,new { CartID = id });
        }
    }
}
