using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakip.DAL.DTO;


namespace StokTakip.DAL.DAO
{
    class KategoriDAO :StokContext, IDAO<KATEGORI, KategoriDetayDTO>
    {
        public bool Delete(KATEGORI entitiy)
        {
            KATEGORI kk = db.KATEGORI.First(x => x.ID == entitiy.ID);
            kk.isDeleted = true;
            kk.DeletedDate = DateTime.Today;
            db.SaveChanges();
            return true;
        }

        public bool GetBack(int ID)
        {
            KATEGORI kk = db.KATEGORI.First(x => x.ID == ID);
            kk.isDeleted = false;
            db.SaveChanges();
            return true;
        }

        public bool Insert(KATEGORI entity)
        {
            try
            {
                db.KATEGORI.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<KategoriDetayDTO> Select()
        {
            try
            {
                var list = db.KATEGORI.Where(x=>x.isDeleted==false);
                List<KategoriDetayDTO> liste = new List<KategoriDetayDTO>();
                foreach (var item in list)
                {
                    KategoriDetayDTO dto = new KategoriDetayDTO();
                    dto.ID = item.ID;
                    dto.KategoriAd = item.KategoriAd;
                    liste.Add(dto);

                }
                return liste;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<KategoriDetayDTO> Select( bool deleted)
        {
            try
            {
                var list = db.KATEGORI.Where(x => x.isDeleted == deleted);
                List<KategoriDetayDTO> liste = new List<KategoriDetayDTO>();
                foreach (var item in list)
                {
                    KategoriDetayDTO dto = new KategoriDetayDTO();
                    dto.ID = item.ID;
                    dto.KategoriAd = item.KategoriAd;
                    liste.Add(dto);

                }
                return liste;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(KATEGORI entity)
        {
            KATEGORI kt = db.KATEGORI.First(x => x.ID == entity.ID);
            kt.KategoriAd = entity.KategoriAd;
            db.SaveChanges();
            return true;
        }
    }
}
