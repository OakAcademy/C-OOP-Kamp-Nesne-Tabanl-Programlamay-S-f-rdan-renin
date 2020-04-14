using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;

namespace DAL.DAO
{
    public class MaasDAO : PersonelDataContext
    {
        public static List<AYLAR> getAylar()
        {
            return db.AYLARs.ToList();
        }

        public static void MaasEkle(MAA maas)
        {
            try
            {
                db.MAAs.InsertOnSubmit(maas);
                db.SubmitChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<MaasDetayDTO> MaasGetir()
        {
            List<MaasDetayDTO> liste = new List<MaasDetayDTO>();
            var list = (from m in db.MAAs
                        join p in db.PERSONELs on m.PersonelID equals p.ID
                        join ay in db.AYLARs on m.Ay_ID equals ay.ID
                        select new
                        {
                            Userno = p.UserNo,
                            ad = p.Ad,
                            soyad = p.Soyad,
                            maasmiktar = m.Miktar,
                            maasyil = m.YIL,
                            maasay = ay.Ay,
                            maasAYAd=ay.Ay,
                            eskimaas = m.Miktar,
                            maasID = m.ID,
                            personelID = p.ID,
                            departmanID = p.DepartmanID,
                            pozisyonID = p.PozisyonID,
                            maasAyID=m.Ay_ID
                        }).OrderBy(x => x.maasyil).ToList();
            foreach (var item in list)
            {
                MaasDetayDTO dto = new MaasDetayDTO();
                dto.UserNo = item.Userno;
                dto.Ad = item.ad;
                dto.Soyad = item.soyad;
                dto.MaasMiktar = item.maasmiktar;
                dto.MaasYil = item.maasyil;
                dto.MaasAy = item.maasay;
                dto.MaasID = item.maasID;
                dto.PersoneID = item.personelID;
                dto.DepartmanID = item.departmanID;
                dto.PozisyonID = item.pozisyonID;
                dto.MaasAyID = item.maasAyID;
               
                liste.Add(dto);

            }
            return liste;
        }

        public static void maasSil(int maasID)
        {
            try
            {
                MAA maas = db.MAAs.First(x => x.ID == maasID);
                db.MAAs.DeleteOnSubmit(maas);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void MaasGuncelle(MaasDetayDTO maas)
        {
            try
            {
                MAA m = db.MAAs.First(x => x.ID == maas.MaasID);
                m.Ay_ID = maas.MaasAyID;
                m.Miktar = maas.MaasMiktar;
                m.YIL = maas.MaasYil;
                db.SubmitChanges();
                
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
