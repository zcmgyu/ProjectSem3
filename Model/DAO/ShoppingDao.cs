using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ShoppingDao
    {
        private readonly OnlineShopDbContext _db;
        public ShoppingDao()
        {
            _db = new OnlineShopDbContext();
        }
        public bool InsertOrder(Order model, string xmlColorSizeQuantity)
        {
            object[] sqlParams =
            {
                new SqlParameter("@CreatedDate", model.CreatedDate),
                new SqlParameter("@CustomerID", model.CustomerID),
                new SqlParameter("@ShipFirstname", model.ShipFirstname),
                new SqlParameter("@ShipLastname", model.ShipLastname),
                new SqlParameter("@ShipGender", model.ShipGender),
                new SqlParameter("@ShipMobile", model.ShipMobile),
                new SqlParameter("@ShipCity", model.ShipCity),
                new SqlParameter("@ShipDistrict", model.ShipDistrict),
                new SqlParameter("@ShipAddress", model.ShipAddress),
                new SqlParameter("@ShipEmail", model.ShipEmail),
                new SqlParameter("@ShipPostCode", model.ShipPostCode),
                new SqlParameter("@ShipNote", model.ShipNote),
                new SqlParameter("@listColorSizeQuantity", xmlColorSizeQuantity)

            };

            //@CreatedDate, @CustomerID, @ShipFirstname, @ShipLastname, 
            //@ShipGender, @ShipMobile, @ShipCity, @ShipDistrict, @ShipAddress, @ShipEmail, @ShipPostCode, @ShipNote, @listColorSizeQuantity
            return _db.Database.SqlQuery<bool>("InsertOrder @CreatedDate, @CustomerID, @ShipFirstname, @ShipLastname, "
            + " @ShipGender, @ShipMobile, @ShipCity, @ShipDistrict, @ShipAddress, @ShipEmail, @ShipPostCode, @ShipNote, @listColorSizeQuantity", sqlParams).SingleOrDefault();
        }
    }
}
