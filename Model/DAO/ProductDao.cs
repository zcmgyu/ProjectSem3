using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;

namespace Model.DAO
{
    public class ProductDao
    {
        private readonly OnlineShopDbContext _db;
        public ProductDao()
        {
            _db = new OnlineShopDbContext();
        }


        public List<ProductViewModel> LoadProductPaging(int start, int pageLimit)
        {
            object[] sqlParams = {
                new SqlParameter("@Start", start),
                new SqlParameter("@PageLimit", pageLimit),
                //new SqlParameter("@sName", sName)
            };
            return _db.Database.SqlQuery<ProductViewModel>("LoadProductPaging @Start, @PageLimit", sqlParams).ToList();
        }
        public List<ProductViewModel> LoadProduct()
        {
            return _db.Database.SqlQuery<ProductViewModel>("LoadProduct").ToList();
        }
        public int CountProduct()
        {
            return _db.Database.SqlQuery<int>("CountProduct").SingleOrDefault();
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
            string shortDescription, string SKU, decimal? price,
            decimal? promotionPrice, int status, string moreImages, string listColorSizeQuantity)
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

            return _db.Database.SqlQuery<int>("InsertProduct @name," +
                    "@description, @shortDescription, @SKU," +
                "@price, @promotionPrice, @status, @moreImages, @listColorSizeQuantity", sqlParams)
                .SingleOrDefault() > 0;
        }

        //public List<Slide> LoadSlide()
        //{

        //}
        public bool InsertSlide(Slide model)
        {
            object[] sqlParams =
            {
                new SqlParameter("@title", model.Title),
                new SqlParameter("@description", model.Description),
                new SqlParameter("@image", model.Image),
                new SqlParameter("@link", model.Link),
                new SqlParameter("@@displayorder", model.DisplayOrder),
                new SqlParameter("@status", model.Status)
            };
            return _db.Database.SqlQuery<bool>("[dbo].[InsertSlideContent] @title, @description, @image, @link, @@displayorder, @status", sqlParams).SingleOrDefault();
        }

        public List<SlideViewModel> ListSlide()
        {
            return _db.Database.SqlQuery<SlideViewModel>("LoadSlideList").ToList();
        }

        public List<Slide> ListSlideForClient()
        {
            return _db.Database.SqlQuery<Slide>("LoadSlideListForClient").ToList();
        }

        public Slide EditSlide(int ID)
        {
            return _db.Database.SqlQuery<Slide>("EditSlideContent @ID", new SqlParameter("@ID", ID)).SingleOrDefault();
        }

        public bool UpdateSlide(Slide model)
        {
            object[] sqlParams =
            {
                new SqlParameter("@Id", model.ID),
                new SqlParameter("@title", model.Title),
                new SqlParameter("@description", model.Description),
                new SqlParameter("@image", model.Image),
                new SqlParameter("@displayorder", model.DisplayOrder),
                new SqlParameter("@status", model.Status)
            };
            return _db.Database.SqlQuery<bool>("UpdateSlideContent @Id, @title, @description, @image, @displayorder, @status", sqlParams).SingleOrDefault();
        }

        public IEnumerable<Product> LoadSimpleProductList(ref int totalRecord, int page = 1, int pageSize = 10)
        {

            var data = _db.Database.SqlQuery<Product>("LoadSimpleProductList").ToList();
            totalRecord = data.Count();
            return data.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public ProductDetailViewModel LoadProductDetail(long id)
        {
            var colors = _db.Database.SqlQuery<string>("LoadProductDetailColorById @productId", new SqlParameter("@productId", id)).ToList();
            var tempSCQ = _db.Database.SqlQuery<TempSizeColorQuantity>("LoadProductDetailSizeColorQuantityById @productId", new SqlParameter("@productId", id)).ToList();
            var general = _db.Database.SqlQuery<ProductDetailGeneral>("LoadProductDetailGeneralById @productId", new SqlParameter("@productId", id)).SingleOrDefault();

            // Parse Image Xml to List Image
            var xImages = XElement.Parse(general.MoreImages);
            var listImageReturn = new List<Image>();

            foreach (var xItem in xImages.Elements())
            {

                var image = new Image
                {
                    Id = Convert.ToInt32(xItem.Element("Id").Value),
                    Name = xItem.Element("Name").Value,
                    Order = Convert.ToInt32(xItem.Element("Order").Value),
                    Url = xItem.Element("Url").Value
                };
                listImageReturn.Add(image);
            };

            var model = new ProductDetailViewModel
            {
                ProductGeneral = general,
                SizeColorQuantities = new List<SizeColorQuantity>()
            };
            foreach (var color in colors)
            {
                var child = new SizeColorQuantity
                {
                    ColorId = color,
                    SizeAndQuantities = new List<SizeAndQuantity>()
                };
                foreach (var item in tempSCQ)
                {
                    if (item.ColorID == color)
                    {
                        child.SizeAndQuantities.Add(
                            new SizeAndQuantity
                            {
                                SizeId = item.SizeID,
                                Quantity = item.Quantity
                            }
                        );
                    }
                }
                model.SizeColorQuantities.Add(child);
            }

            // Sort by Order and Add list image to model
            model.ProductGeneral.ListImage = listImageReturn.OrderBy(x => x.Order).ToList();
            return model;
        }

        public Product LoadProduct(long id)
        {
            return _db.Products.SingleOrDefault(x => x.ID == id);
        }

        public List<ProductDetailGeneral> LoadRelatedProduct(long id)
        {

            var result = _db.Database.SqlQuery<ProductDetailGeneral>("LoadRelatedProduct @productId", new SqlParameter("@productId", id)).ToList();
            foreach(var item in result)
            {
                // Parse Image Xml to List Image
                var xImages = XElement.Parse(item.MoreImages);
                item.ListImage = new List<Image>();
                foreach (var xItem in xImages.Elements())
                {

                    var image = new Image
                    {
                        Id = Convert.ToInt32(xItem.Element("Id").Value),
                        Name = xItem.Element("Name").Value,
                        Order = Convert.ToInt32(xItem.Element("Order").Value),
                        Url = xItem.Element("Url").Value
                    };
                    item.ListImage.Add(image);
                };
                
            }
            
            return result;
        }
        
    }
}
