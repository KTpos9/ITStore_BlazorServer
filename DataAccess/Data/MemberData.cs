using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Project.DataModels;

namespace DataAccess.Data
{
    public class MemberData
    {
        private readonly SqlDataAccess _db;
        public MemberData(SqlDataAccess db)
        {
            _db = db;
        }
        public Task<List<Member>> GetMember()
        {
            string sql = "select * from dbo.Member2";
            return _db.LoadData<Member,dynamic>(sql,new {});
        }
        public Task InsertMember(Member member)
        {
            string sql = @"insert into dbo.Member2 (FirstName, LastName, Email, Password, Role) 
                          values (@FirstName, @LastName, @Email, @Password, @Role);";
            return _db.SaveData(sql,member);
        }
        public Task<Member> GetMemberByEmail(string email)
        {
            string sql = "select * from dbo.Member2 where Email=@Email";
            return _db.LoadSingleData<Member, dynamic>(sql, new { Email = email });
        }
    }
}
