using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;

namespace DAL.DAO
{
    public class PozisyonDAO : PersonelDataContext
    {
        public static void DepartmanEkle(POZISYON pz)
        {
            try
            {
                db.POZISYONs.InsertOnSubmit(pz);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<PozisyonDTO> PozisyonGetir()
        {
            try
            {
                var list = (from p in db.POZISYONs
                            join d in db.DEPARTMANs on p.DepartmanID equals d.ID
                            select new
                            {
                                PozisyonID = p.ID,
                                pozisyonAd = p.PozisyonAd,
                                departmanID = p.DepartmanID,
                                departmanAd = d.DepartmanAd


                            }
                          ).OrderBy(x => x.PozisyonID).ToList();
                List<PozisyonDTO> liste = new List<PozisyonDTO>();
                foreach (var item in list)
                {
                    PozisyonDTO pzt = new PozisyonDTO();
                    pzt.ID = item.PozisyonID;
                    pzt.PozisyonAd = item.pozisyonAd;
                    pzt.DepartmanID = item.departmanID;
                    pzt.DepartmanAd = item.departmanAd;
                    liste.Add(pzt);

                    

                }
                return liste;
                

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void PozisyonSil(int id)
        {
            POZISYON pz = db.POZISYONs.First(x => x.ID == id);
            db.POZISYONs.DeleteOnSubmit(pz);
            db.SubmitChanges();
        }

        public static void PozisyonGuncelle(PozisyonDetayDTO detay)
        {
            POZISYON pz = db.POZISYONs.First(x => x.ID == detay.ID);
            pz.PozisyonAd = detay.PozisyonAD;
            pz.DepartmanID = detay.DepartmanID;
            db.SubmitChanges();
        }
    }
}
