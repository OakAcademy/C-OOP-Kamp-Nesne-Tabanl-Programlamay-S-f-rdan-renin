using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;

namespace DAL.DAO
{
    public class IzinDAO : PersonelDataContext
    {
        public static void IzinEkle(IZIN iz)
        {
            try
            {
                db.IZINs.InsertOnSubmit(iz);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<IZINDURUM> DurumGetir()
        {
            return db.IZINDURUMs.ToList();
        }

        public static List<IzinDetayDTO> IzinGetir()
        {
            List<IzinDetayDTO> liste = new List<IzinDetayDTO>();
            var list = (from i in db.IZINs
                        join p in db.PERSONELs on i.PersonelID equals p.ID
                        join d in db.IZINDURUMs on i.IzinDurumID equals d.ID
                        select new
                        {
                            UserNo = p.UserNo,
                            ad = p.Ad,
                            soyad = p.Soyad,
                            durumad = d.IzinDurumAd,
                            durumID = i.IzinDurumID,
                            baslamatarihi = i.IzinBaslamaTarihi,
                            bitistarihi = i.IzinBitisTarihi,
                            personelID = i.PersonelID,
                            izinID = i.ID,
                            aciklama = i.Acıklama,
                            sure = i.Sure,
                            departmanID=p.DepartmanID,
                            pozisyonID=p.PozisyonID

                        }
                      ).OrderBy(x => x.baslamatarihi).ToList();
            foreach (var item in list)
            {
                IzinDetayDTO dto = new IzinDetayDTO();
                dto.PersoneID = item.personelID;
                dto.BaslamaTarihi = item.baslamatarihi;
                dto.UserNo = item.UserNo;
                dto.Ad = item.ad;
                dto.Soyad = item.soyad;
                dto.BitisTarihi = item.bitistarihi;
                dto.Aciklama = item.aciklama;
                dto.IzinDurumAd = item.durumad;
                dto.IzinDurumID = item.durumID;
                dto.IzinID = item.izinID;
                dto.Sure = item.sure;
                dto.DepartmanID = item.departmanID;
                dto.PozisyonID = item.pozisyonID;
                liste.Add(dto);
            }
            
            return liste;
        }

        public static void IzinSil(int izinID)
        {
            try
            {
                IZIN iz = db.IZINs.First(x => x.ID == izinID);
                db.IZINs.DeleteOnSubmit(iz);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void IzinGunceller(int izinID, int onayla)
        {
            try
            {
                IZIN iz = db.IZINs.First(x => x.ID == izinID);
                iz.IzinDurumID = onayla;
             
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void IzinGunceller(IzinDetayDTO detaydto)
        {
            try
            {
                IZIN iz = db.IZINs.First(x => x.ID == detaydto.IzinID);
                iz.Acıklama = detaydto.Aciklama;
                iz.IzinBaslamaTarihi = detaydto.BaslamaTarihi;
                iz.IzinBitisTarihi = detaydto.BitisTarihi;
                iz.Sure = detaydto.Sure;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
