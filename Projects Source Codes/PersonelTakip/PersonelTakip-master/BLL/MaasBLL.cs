using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DAO;
using DAL.DTO;

namespace BLL
{
    public class MaasBLL
    {
        public static MaasDTO GetAll()
        {
            MaasDTO dto = new MaasDTO();
            dto.Departmanlar = DepartmanDAO.DepartmanGetir();
            dto.Pozisyonlar = PozisyonDAO.PozisyonGetir();
            dto.Personeller = PersonelDAO.PersonelGetir();
            dto.Aylar = MaasDAO.getAylar();
            dto.Maaslar = MaasDAO.MaasGetir();
            return dto;
        }

        public static void MaasEkle(MAA maas, bool control)
        {
            MaasDAO.MaasEkle(maas);
            if (control)
            {
                MaasDetayDTO dto = new MaasDetayDTO();
                dto.PersoneID = maas.PersonelID;
                dto.MaasMiktar = maas.Miktar;
                PersonelDAO.PersonelMaasGuncelle(dto);
                    
                    
                    }
        }

        public static void MaasGuncelle(MaasDetayDTO maas, bool control)
        {
            MaasDAO.MaasGuncelle(maas);
            if (control)
                PersonelDAO.PersonelMaasGuncelle(maas);
        }

        public static void maasSil(int maasID)
        {
            MaasDAO.maasSil(maasID);
        }
    }
}
