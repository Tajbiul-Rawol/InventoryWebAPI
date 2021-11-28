using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Inv.IRepo
{
    public interface ICategoryRepo
    {
        List<Category> GetAllCategories();
        int SaveCategory(Category category);
        Category GetCategoryById(int ID);
        bool DeleteCategory(int id);

        int UpdateCategory(Category category);
    }
}
