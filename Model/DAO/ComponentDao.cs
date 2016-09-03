using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ComponentDao
    {
        private readonly OnlineShopDbContext _db;
        public ComponentDao()
        {
            _db = new OnlineShopDbContext();
        }

        public List<Menu> LoadMenu(int menuType)
        {
           
            return _db.Database.SqlQuery<Menu>("[dbo].[LoadMenu] @menuType", new SqlParameter("@menuType", menuType)).ToList();
        }
    }
}