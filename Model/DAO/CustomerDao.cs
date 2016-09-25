using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class CustomerDao
    {
        private readonly OnlineShopDbContext _db;
        public CustomerDao()
        {
            _db = new OnlineShopDbContext();
        }

        public List<CustomerViewModel> LoadListCustomer()
        {
            return _db.Database.SqlQuery<CustomerViewModel>("LoadListCustomer").ToList();
        }

        public AspNetUser LoadCustomerInfoById(string id)
        {
            return _db.AspNetUsers.Where(x => x.Id == id).SingleOrDefault();
        }

        public List<decimal> CountOrderTimeItemAmountByUserId(string userID)
        {
            return _db.Database.SqlQuery<decimal>("CountOrderTimeItemAmountByUserId @userId", new SqlParameter("@userId", userID)).ToList();
        }
    }
}
