using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakip.DAL.DTO;

namespace StokTakip.DAL.DAO
{
    class SatisDAO : StokContext, IDAO<SATIM, SatisDetayDTO>
    {
        public bool Delete(SATIM entity)
        {
            if(entity.ID!=0)
            {
                SATIM satis = db.SATIM.First(x => x.ID == entity.ID);
                satis.isDeleted = true;
                satis.DeletedDate = DateTime.Today;
                db.SaveChanges();
            }
            else if(entity.UrunID!=0)
            {
                List<SATIM> list = db.SATIM.Where(x => x.UrunID == entity.UrunID).ToList();
                foreach (var item in list)
                {
                    item.isDeleted = true;
                    item.DeletedDate = DateTime.Today;

                }
                db.SaveChanges();
            }
            else if(entity.MusteriID!=0)
            {
                List<SATIM> list = db.SATIM.Where(x => x.MusteriID == entity.MusteriID).ToList();
                foreach (var item in list)
                {
                    URUN urun = db.URUN.First(x => x.ID == item.UrunID);
                    urun.Stok += item.SatisMiktar;
                    db.SaveChanges();


                }
                List<SATIM> list2 = db.SATIM.Where(x => x.MusteriID == entity.MusteriID).ToList();
                foreach (var item in list2)
                {
                    item.isDeleted = true;
                    item.DeletedDate = DateTime.Today;



                }
                db.SaveChanges();

            }
            
            return true;
        }

        public bool GetBack(int ID)
        {
            SATIM ss = db.SATIM.First(x => x.ID == ID);
            ss.isDeleted = false;
            db.SaveChanges();
            return true;
        }

        public bool Insert(SATIM entity)
        {
            try
            {
                db.SATIM.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SatisDetayDTO> Select()
        {
            try
            {
                List<SatisDetayDTO> liste = new List<SatisDetayDTO>();
                var list = (from s in db.SATIM.Where(x=>x.isDeleted==false)
                            join u in db.URUN on s.UrunID equals u.ID
                            join m in db.MUSTERI on s.MusteriID equals m.ID
                            join k in db.KATEGORI on s.KategoriID equals k.ID
                            select new
                            {
                                musteriad = m.MusterAd,
                                urunad = u.UrunAd,
                                kategoriad = k.KategoriAd,
                                fiyat = s.SatisFiyat,
                                satımtarih = s.SatisTarihi,
                                satismiktar = s.SatisMiktar,
                                stok = u.Stok,
                                satisID = s.ID,
                                urunID = s.UrunID,
                                musteriID = s.MusteriID,
                                kategoriID = s.KategoriID

                            }).OrderBy(x => x.satımtarih).ToList();
                foreach (var item in list)
                {
                    SatisDetayDTO dto = new SatisDetayDTO();
                    dto.MusteriAd = item.musteriad;
                    dto.UrunAd = item.urunad;
                    dto.KategoriAd = item.kategoriad;
                    dto.Fiyat = item.fiyat;
                    dto.SatisTarihi = item.satımtarih;
                    dto.SatisMiktar = item.satismiktar;
                    dto.StokMiktar = item.stok;
                    dto.SatisID = item.satisID;
                    dto.UrunID = item.urunID;
                    dto.MusteriID = item.musteriID;
                    dto.KategoriID = item.kategoriID;
                    liste.Add(dto);
                }


                return liste;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<SatisDetayDTO> Select(bool deleted)
        {
            try
            {
                List<SatisDetayDTO> liste = new List<SatisDetayDTO>();
                var list = (from s in db.SATIM.Where(x => x.isDeleted == deleted)
                            join u in db.URUN on s.UrunID equals u.ID
                            join m in db.MUSTERI on s.MusteriID equals m.ID
                            join k in db.KATEGORI on s.KategoriID equals k.ID
                            select new
                            {
                                musteriad = m.MusterAd,
                                urunad = u.UrunAd,
                                kategoriad = k.KategoriAd,
                                fiyat = s.SatisFiyat,
                                satımtarih = s.SatisTarihi,
                                satismiktar = s.SatisMiktar,
                                stok = u.Stok,
                                satisID = s.ID,
                                urunID = s.UrunID,
                                musteriID = s.MusteriID,
                                kategoriID = s.KategoriID,
                                kategordeleted=k.isDeleted,
                                musterideleted=m.isDeleted,
                                urundeleted=u.isDeleted

                            }).OrderBy(x => x.satımtarih).ToList();
                foreach (var item in list)
                {
                    SatisDetayDTO dto = new SatisDetayDTO();
                    dto.MusteriAd = item.musteriad;
                    dto.UrunAd = item.urunad;
                    dto.KategoriAd = item.kategoriad;
                    dto.Fiyat = item.fiyat;
                    dto.SatisTarihi = item.satımtarih;
                    dto.SatisMiktar = item.satismiktar;
                    dto.StokMiktar = item.stok;
                    dto.SatisID = item.satisID;
                    dto.UrunID = item.urunID;
                    dto.MusteriID = item.musteriID;
                    dto.KategoriID = item.kategoriID;
                    dto.mdeleted = item.musterideleted;
                    dto.kdeleted = item.kategordeleted;
                    dto.udeleted = item.urundeleted;
                    liste.Add(dto);
                }


                return liste;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(SATIM entity)
        {
            SATIM ss = db.SATIM.First(x => x.ID == entity.ID);
            ss.SatisMiktar = entity.SatisMiktar;
            db.SaveChanges();
            return true;
        }
    }
}
