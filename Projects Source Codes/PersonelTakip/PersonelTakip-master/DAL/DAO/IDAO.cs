using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    interface IDAO
    {
        bool select();
        bool insert();
        bool delete();
        bool update();
    }
}
