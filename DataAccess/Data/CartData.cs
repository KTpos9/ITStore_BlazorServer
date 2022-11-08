using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    internal class CartData
    {
        private readonly SqlDataAccess _db;
        public CartData(SqlDataAccess db)
        {
            _db = db;
        }
        public Task<List<Cart>> GetCart()
        {
            string sql = "select * from dbo.Member";
            return _db.LoadData<Cart, dynamic>(sql, new { });
        }
        public Task InsertCart(Cart cart)
        {
            string sql = @"insert into dbo.Member () 
                          values (@,);";
            return _db.SaveData(sql, cart);
        }
    }
}
