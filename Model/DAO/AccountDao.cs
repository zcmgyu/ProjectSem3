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
            return _db.Database.SqlQuery<bool>("Login @Email, @Password", sqlParams).SingleOrDefault();
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
                "Register @Email, @Password, @Firstname, @Lastname, @Gender, @DOB, @Address, @City, @Country, @PostCode, @Phone, @CreatedBy", sqlParams).SingleOrDefault();
        }
        public AspNetUser GetInfo(string userId)
        {
            return _db.Database.SqlQuery<AspNetUser>("[dbo].[GetAccountInfoById] @userId", new SqlParameter("@userId", userId)).SingleOrDefault();
        }

        public bool UpdateInfo(AspNetUser model)
        {
            object[] sqlParams =
            {
                new SqlParameter("@userId", model.Id),
                new SqlParameter("@Firstname", model.Firstname),
                new SqlParameter("@Lastname", model.Lastname),
                new SqlParameter("@Gender", model.Gender),
                new SqlParameter("@DOB", model.DOB),
                new SqlParameter("@Address", model.Address),
                new SqlParameter("@City", model.City),
                new SqlParameter("@District", model.District),
                new SqlParameter("@PostCode", model.PostCode),
                new SqlParameter("@PhoneNumber", model.PhoneNumber)

            };
            return _db.Database.SqlQuery<bool>(
                "[dbo].[Update_ById] @userId, @Firstname, @Lastname, @Gender, @DOB, @Address, @City, @District, @PostCode, @PhoneNumber",
                sqlParams).SingleOrDefault();
        }

        public Shipping GetShippingInfo(string userId)
        {
            return _db.Database.SqlQuery<Shipping>("GetShippingInfo @userId", new SqlParameter("@userId", userId)).SingleOrDefault();
        }
        public bool CreateShipping(Shipping model)
        {
            object[] sqlParams = new[]
            {
                new SqlParameter("@Firstname", model.Firstname),
                 new SqlParameter("@Lastname", model.Lastname),
                  new SqlParameter("@Gender", model.Gender),
                 //new SqlParameter("@DOB", model.DOB),
                   new SqlParameter("@Address", model.Address),
                  new SqlParameter("@City", model.City),
                   new SqlParameter("@District", model.District),
                    new SqlParameter("@PostCode", model.PostCode),
                     new SqlParameter("@PhoneNumber", model.PhoneNumber),
                      new SqlParameter("@Email", model.Email),
                      new SqlParameter("@OrderNote", model.OrderNote),
                      new SqlParameter("@AccountID", model.AccountID),

            };
            return _db.Database.SqlQuery<bool>("InsertShipping @Firstname, @Lastname, @Gender, @Address, @City, @District, @PostCode, @PhoneNumber, @Email, @OrderNote, @AccountID", sqlParams).SingleOrDefault();
        }

    }
}

