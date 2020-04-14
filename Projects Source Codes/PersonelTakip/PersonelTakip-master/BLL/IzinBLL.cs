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
    public class IzinBLL
    {
        public static void IzinEkle(IZIN iz)
        {
            IzinDAO.IzinEkle(iz);
        }

        public static IzinDTO GetAll()
        {
            IzinDTO dto = new IzinDTO();
            dto.Departmanlar = DepartmanDAO.DepartmanGetir();
            dto.Pozisyonlar = PozisyonDAO.PozisyonGetir();
            dto.IzinDurumlar = IzinDAO.DurumGetir();
            dto.Izinler = IzinDAO.IzinGetir();
            return dto;
        }

        public static void IzinGuncelle(IzinDetayDTO detaydto)
        {
            IzinDAO.IzinGunceller(detaydto);
        }

        public static void IzinGuncelle(int izinID, int onayla)
        {
            IzinDAO.IzinGunceller(izinID, onayla);
        }

        public static void IzinSil(int izinID)
        {
            IzinDAO.IzinSil(izinID);
        }
    }
}
