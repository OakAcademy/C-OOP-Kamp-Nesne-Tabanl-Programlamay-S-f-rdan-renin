using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
   public class IsDetayDTO
    {
       
        public string Baslik { get; set; }
        public int UserNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string DepartmanAd { get; set; }
        public string PozisyonAd { get; set; }
        public int DepartmanID { get; set; }
        public int PozisyonID { get; set; }
        public int PersoneID { get; set; }
        public string Icerik { get; set; }
        public string IsDurumAd { get; set; }
        public int IsDurumID { get; set; }
        public DateTime IsBaslamaTarihi { get; set; }
        public DateTime IsBitisTarihi { get; set; }
        public int IsID { get; set; }


    }
}
