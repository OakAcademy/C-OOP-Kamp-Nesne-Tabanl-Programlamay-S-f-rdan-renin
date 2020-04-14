using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
  public  class IzinDetayDTO
    {


        public int PersoneID { get; set; }
        public int UserNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string DepartmanAd { get; set; }
        public string PozisyonAd { get; set; }
        public int DepartmanID { get; set; }
        public int PozisyonID { get; set; }
        public DateTime BaslamaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string Aciklama { get; set; }
        public int Sure { get; set; }
        public string IzinDurumAd { get; set; }
        public int IzinDurumID { get; set; }
        public int IzinID { get; set; }
    }
}
