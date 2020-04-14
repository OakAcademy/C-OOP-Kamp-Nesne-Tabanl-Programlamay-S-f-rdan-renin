using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.BLL
{
    interface IBLL<T,K> where T:class where K:class
    {
        bool Insert(T entity);
        bool Update(T entity);
        K Select();
        bool Delete(T entity);
        bool GetBack(T entity);
    }
}
