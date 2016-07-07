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

        public int Register(Account model)
        {
            object[] sqlParams =
            {
                new SqlParameter("@Email", model.Email),
                new SqlParameter("@Password", model.Password),
                new SqlParameter("@Firstname", model.Firstname),
                new SqlParameter("@Lastname", model.Lastname),
                new SqlParameter("@Gender", model.Gender),
                new SqlParameter("@DOB", model.DOB),
                new SqlParameter("@Address", model.Address),
                new SqlParameter("@City", model.City),
                new SqlParameter("@Country", model.Country),
                new SqlParameter("@PostCode", model.PostCode),
                new SqlParameter("@Phone", model.Phone),
                new SqlParameter("@CreatedBy", model.CreatedBy),
            };
            return _db.Database.SqlQuery<int>(
                "Sp_Register @Email, @Password, @Firstname, @Lastname, @Gender, @DOB, @Address, @City, @Country, @PostCode, @Phone, @CreatedBy", sqlParams).SingleOrDefault();
        }
    }
}
