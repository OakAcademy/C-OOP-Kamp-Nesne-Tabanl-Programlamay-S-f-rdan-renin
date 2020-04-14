using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
  public  class MaasDetayDTO
    {
        public int PersoneID { get; set; }
        public int UserNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string DepartmanAd { get; set; }
        public string PozisyonAd { get; set; }
        public int DepartmanID { get; set; }
        public int PozisyonID { get; set; }
        public int MaasYil { get; set; }
        public string MaasAy { get; set; }
        
        public int MaasMiktar { get; set; }
        public int MaasID { get; set; }
        public int MaasAyID { get; set; }
        public int EskiMaas { get; set; }


    }
}
