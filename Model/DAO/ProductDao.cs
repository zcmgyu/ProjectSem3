using Model.EF;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Model.DAO
{
    public class ProductDao
    {
        private readonly OnlineShopDbContext _db;
        public ProductDao()
        {
            _db = new OnlineShopDbContext();
        }

        public List<ProductCategory> LoadProductCategory()
        {
            return _db.Database.SqlQuery<ProductCategory>("LoadProductCategory").ToList();
        }

        public List<string> LoadProductColor()
        {
            return _db.Database.SqlQuery<string>("LoadProductColor").ToList();
        }

        public List<string> LoadProductSize()
        {
            return _db.Database.SqlQuery<string>("LoadProductSize").ToList();
        }
        public bool InsertProduct(string name, string description, 
            string shortDescription,  string SKU, float price, 
            float promotionPrice, int status, string moreImages, string listColorSizeQuantity)
        {
            object[] sqlParams =
                {
                    new SqlParameter("@name", name),
                    //new SqlParameter("@metatitle", metaTitle),
                    new SqlParameter("@description", description),
                    new SqlParameter("@shortDescription", shortDescription),
                    //new SqlParameter("@categoryID", category),
                    new SqlParameter("@SKU", SKU),
                    new SqlParameter("@price", System.Data.SqlDbType.Decimal) {
                          Precision = 18,
                          Scale = 0,
                          Value = price
                    },
                    new SqlParameter("@promotionPrice", System.Data.SqlDbType.Decimal) {
                          Precision = 18,
                          Scale = 0,
                          Value = promotionPrice
                    },
                    new SqlParameter("@status", status),
                    new SqlParameter("@moreImages", moreImages),
                    new SqlParameter("@listColorSizeQuantity", listColorSizeQuantity)
                };
          //  return _db.Database.SqlQuery<int>("InsertProduct @name," +
          //      "@metatitle, @description, @shortDescription, @categoryID, @SKU," +
		        //"@price, @promotionPrice, @status, @moreImages, @listColorSizeQuantity", sqlParams)
          //      .SingleOrDefault() > 0;
            return _db.Database.SqlQuery<int>("InsertProduct @name," +
                    "@description, @shortDescription, @SKU," +
                "@price, @promotionPrice, @status, @moreImages, @listColorSizeQuantity", sqlParams)
                .SingleOrDefault() > 0;
        }
       
    }
}
