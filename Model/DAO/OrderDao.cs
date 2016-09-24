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
    public class OrderDao
    {
        private readonly OnlineShopDbContext _db;
        public OrderDao()
        {
            _db = new OnlineShopDbContext();
        }

        public List<OrderViewModel> LoadAllOrder()
        {
            return _db.Database.SqlQuery<OrderViewModel>("LoadAllOrder").ToList();
        }

        public Order LoadOrderById(int id)
        {
            return _db.Database.SqlQuery<Order>("LoadOrderById @id", new SqlParameter("@id", id)).SingleOrDefault();
        }
        public List<OrderDetailViewModel> LoadOrderDetailById(int orderId)
        {
            return _db.Database.SqlQuery<OrderDetailViewModel>("LoadOrderDetailById @orderId", new SqlParameter("@orderId", orderId)).ToList();
        }

        public bool UpdateOrderStatusById(long id, int status)
        {
            object[] sqlParams =
            {
                new SqlParameter("@orderId", id),
                new SqlParameter("@status", status)
            };
            return _db.Database.SqlQuery<bool>("UpdateOrderStatusById @orderId, @status", sqlParams).SingleOrDefault();
        }
    }
}
