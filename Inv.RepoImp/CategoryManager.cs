using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Inv.IRepo;
using Category = Models.Category;

namespace Inv.RepoImp
{
    public class CategoryManager : ICategoryRepo
    {
        private InventdbEntities _dbContext;
        public CategoryManager()
        {
            _dbContext = new InventdbEntities();
        }
        public List<Category> GetAllCategories()
        {
            List<Category> categories = (from category in _dbContext.Categories
                select new Category
                {
                    ID = category.ID,
                    Name = category.Name,
                    CategoryType = category.CategoryType
                }).ToList();
            return categories;
        }

        public int SaveCategory(Category category)
        {
            int categoryID = 0;
            if (category.ID == 0)
            {
                var result = _dbContext.Categories.OrderByDescending(c => c.ID).ToList();
                var categoryData = result.First();
                categoryID = categoryData.ID + 1;

                DataAccess.Category ct = new DataAccess.Category()
                {
                    ID = categoryID,
                    Name = category.Name,
                    CategoryType = category.CategoryType
                };
                _dbContext.Categories.Add(ct);
                return _dbContext.SaveChanges();
            }
            DataAccess.Category cat = new DataAccess.Category()
            {
                ID = category.ID,
                Name = category.Name,
                CategoryType = category.CategoryType
            };
            _dbContext.Categories.Add(cat);
            return _dbContext.SaveChanges();
        }

        public Category GetCategoryById(int ID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateCategory(Category category)
        {
            var existingCategory = _dbContext.Categories.FirstOrDefault(p => p.ID == category.ID);
            if (existingCategory != null)
            {
                existingCategory.ID = category.ID;
                existingCategory.Name = category.Name;
                existingCategory.CategoryType = category.CategoryType;
                return _dbContext.SaveChanges();
            }

            return 0;
        }
    }
}
