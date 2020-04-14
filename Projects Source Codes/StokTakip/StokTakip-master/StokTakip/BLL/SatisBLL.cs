using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakip.DAL.DTO;
using StokTakip.DAL.DAO;
using StokTakip.DAL;
namespace StokTakip.BLL
{
    class SatisBLL : IBLL<SatisDetayDTO, SatisDTO>
    {
        KategoriDAO kategoridao = new KategoriDAO();
        UrunDAO urunDAO = new UrunDAO();
        MusteriDAO musteridao = new MusteriDAO();
        SatisDAO dao = new SatisDAO();
        public bool Delete(SatisDetayDTO entity)
        {
            SATIM satis = new SATIM();
            satis.ID = entity.SatisID;
          dao.Delete(satis);
            urunDAO.stokGuncelle(entity);



            return true;
        }

        public bool GetBack( SatisDetayDTO entity)
        {
            dao.GetBack(entity.SatisID);
            URUN urun = new URUN();
            urun.ID = entity.UrunID;
            int temp = entity.StokMiktar + entity.SatisMiktar;
            urun.Stok = temp;
            urunDAO.Update(urun);
            return true;
        }

        public bool Insert(SatisDetayDTO entity)
        {
            SATIM satis = new SATIM();
            satis.KategoriID = entity.KategoriID;
            satis.MusteriID = entity.MusteriID;
            satis.SatisFiyat = entity.Fiyat;
            satis.SatisMiktar = entity.SatisMiktar;
            satis.SatisTarihi = DateTime.Today;
            satis.UrunID = entity.UrunID;
            dao.Insert(satis);
            URUN urun = new URUN();
            urun.ID = entity.UrunID;
            int temp = entity.StokMiktar - entity.SatisMiktar;
            urun.Stok = temp;
            urunDAO.Update(urun);
            return true;
            

        }

        public SatisDTO Select()
        {
            SatisDTO dto = new SatisDTO();
            dto.Musteriler = musteridao.Select();
            dto.Kategoriler = kategoridao.Select();
            dto.Urunler = urunDAO.Select();
            dto.Satislar = dao.Select();
            

            return dto;
        }
        public SatisDTO Select(bool deleted)
        {
            SatisDTO dto = new SatisDTO();
            dto.Musteriler = musteridao.Select(deleted);
            dto.Kategoriler = kategoridao.Select(deleted);
            dto.Urunler = urunDAO.Select(deleted);
            dto.Satislar = dao.Select(deleted);


            return dto;
        }

        public bool Update(SatisDetayDTO entity)
        {
            SATIM satis = new SATIM();
            satis.SatisMiktar = entity.SatisMiktar;
            satis.ID = entity.SatisID;
            dao.Update(satis);
            int temp = entity.StokMiktar;
            URUN urun = new URUN();
            urun.Stok = entity.StokMiktar - (entity.SatisMiktar - temp);
            urun.ID = entity.UrunID;
            urunDAO.Update(urun);


            return true;
        }
    }
}
