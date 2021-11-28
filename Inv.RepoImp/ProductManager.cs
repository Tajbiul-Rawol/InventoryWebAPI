using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Inv.IRepo;
using Product = Models.Product;

namespace Inv.RepoImp
{
    public class ProductManager : IProductRepo
    {
        private InventdbEntities _dbContext;
        public ProductManager()
        {
            _dbContext = new InventdbEntities();
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = (from p in _dbContext.Products select new Product
            {
                ID = p.ID,
                ProductDetail = p.ProductDetail,
                Price = p.Price,
                ProductType = p.ProductType,
                ProductName = p.ProductName
            }).ToList();
            return products;
        }

        public int SaveProduct(Product product)
        {
            int productID = 0;
            if (product.ID == 0)
            {
                var result = _dbContext.Products.OrderByDescending(p => p.ID).ToList();
                var productData = result.First();
                productID = productData.ID+1;
               
                DataAccess.Product pd = new DataAccess.Product()
                {
                    ID = productID,
                    ProductDetail = product.ProductDetail,
                    Price = product.Price,
                    ProductType = product.ProductType,
                    ProductName = product.ProductName
                };
                _dbContext.Products.Add(pd);
                return _dbContext.SaveChanges();
            }
            DataAccess.Product prod = new DataAccess.Product()
            {
                ID = product.ID,
                ProductDetail = product.ProductDetail,
                Price = product.Price,
                ProductType = product.ProductType,
                ProductName = product.ProductName
            };
            _dbContext.Products.Add(prod);
            return _dbContext.SaveChanges();
        }

        public Product GetProductById(int ID)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.ID == ID);
            Product prod = new Product()
            {
                ID = product.ID,
                ProductDetail = product.ProductDetail,
                Price = product.Price,
                ProductType = product.ProductType,
                ProductName = product.ProductName
            };
            return prod;
        }

        public bool DeleteProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.ID == id);
            _dbContext.Products.Remove(product);
            if (_dbContext.SaveChanges() == 0)
            {
                return true;
            }

            return false;
        }

        public int UpdateProduct(Product prod)
        {
            var existingProduct = _dbContext.Products.FirstOrDefault(p => p.ID == prod.ID);
            if (existingProduct != null)
            {
                existingProduct.ID = prod.ID;
                existingProduct.Price = prod.Price;
                existingProduct.ProductDetail = prod.ProductDetail;
                existingProduct.ProductName = prod.ProductName;
                existingProduct.ProductType = prod.ProductType;
                return _dbContext.SaveChanges();
            }

            return 0;
        }
    }
}
