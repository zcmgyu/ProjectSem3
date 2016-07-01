using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class AccountDao
    {
        private readonly OnlineShopDbContext _db;
        public AccountDao()
        {
            _db = new OnlineShopDbContext();
        }

        public bool Login(string email, string password)
        {
            object[] sqlParams =
            {
                new SqlParameter("@Email", email),
                new SqlParameter("@Password", password)
            };
            return _db.Database.SqlQuery<bool>("Sp_Login @Email, @Password", sqlParams).SingleOrDefault();
        }

        public bool Register(Account model)
        {

            return true;
        }
    }
}
