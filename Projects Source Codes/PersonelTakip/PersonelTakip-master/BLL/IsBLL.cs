using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;
using DAL.DAO;
using DAL;

namespace BLL
{
    public class IsBLL
    {
        public static IsDTO GetAll()
        {
            IsDTO dto = new IsDTO();
            dto.Departmanlar = DepartmanDAO.DepartmanGetir();
            dto.Pozisyonlar = PozisyonDAO.PozisyonGetir();
            dto.Personeller = PersonelDAO.PersonelGetir();
            dto.Durumlar = IsDAO.DurumGetir();
            dto.Isler = IsDAO.IsGetir();
            return dto;
        }

        public static void IsEkle(I iss)
        {
            IsDAO.IsEkle(iss);
        }

        public static void IsGuncelle(IsDetayDTO dto)
        {
            IsDAO.IsGuncell(dto);
        }

        public static void IsSil(int isID)
        {
            IsDAO.IsSil(isID);
        }

        public static void IsGuncelle(int isID)
        {
            IsDAO.IsGuncellle(isID);
        }
    }
}
