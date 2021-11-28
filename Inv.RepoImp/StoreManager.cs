using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Inv.IRepo;
using Models;
using Store = Models.Store;

namespace Inv.RepoImp
{
    public class StoreManager : IStoreRepo
    {
        private InventdbEntities _dbContext;

        public StoreManager()
        {
            _dbContext = new InventdbEntities();
        }

        public List<Store> GetAllStore()
        {
            throw new NotImplementedException();
            return new List<Store>();
        }

        public int SaveStore(Store product)
        {
            throw new NotImplementedException();
        }

        public Store GetStoreById(int ID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteStore(int id)
        {
            throw new NotImplementedException();
        }
    }
}
