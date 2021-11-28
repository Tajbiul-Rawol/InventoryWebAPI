using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Inv.IRepo
{
    public interface IProductRepo
    {
        List<Product> GetAllProducts();
        int SaveProduct(Product product);
        Product GetProductById(int ID);
        bool DeleteProduct(int id);

        int UpdateProduct(Product product);
    }
}
