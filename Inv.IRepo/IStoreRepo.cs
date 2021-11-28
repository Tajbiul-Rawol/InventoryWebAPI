using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Inv.IRepo
{
    public interface IStoreRepo
    {
        List<Store> GetAllStore();
        int SaveStore(Store product);
        Store GetStoreById(int ID);
        bool DeleteStore(int id);

    }
}
