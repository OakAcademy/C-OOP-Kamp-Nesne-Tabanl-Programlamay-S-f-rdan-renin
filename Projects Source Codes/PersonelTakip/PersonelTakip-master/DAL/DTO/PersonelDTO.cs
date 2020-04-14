using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
  public  class PersonelDTO
    {
        public List<DEPARTMAN> Departmanlar { get; set; }
        public List<PozisyonDTO> Pozisyonlar { get; set; }
        public List<PersonelDetayDTO> Personeller { get; set; }



    }
}
