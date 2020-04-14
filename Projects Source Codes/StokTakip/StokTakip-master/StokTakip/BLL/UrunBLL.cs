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
    class UrunBLL : IBLL<UrunDetayDTO, UrunDTO>
    {
        KategoriDAO kategoridao = new KategoriDAO();
        UrunDAO dao = new UrunDAO();
        SatisDAO satisdao = new SatisDAO();
        public bool Delete(UrunDetayDTO entity)
        {
            URUN urun = new URUN();
            urun.ID = entity.ID;
            dao.Delete(urun);
            SATIM satis = new SATIM();
            satis.UrunID = entity.ID;
            satisdao.Delete(satis);

            return true;
        }

        public bool GetBack( UrunDetayDTO entity)
        {
            return dao.GetBack(entity.ID);
        }

        public bool Insert(UrunDetayDTO entity)
        {
            URUN urun = new URUN();
            urun.Fiyat = entity.Fiyat;
            urun.UrunAd = entity.UrunAd;
            urun.KategoriID = entity.KategoriID;
            urun.isDeleted = false;
            return dao.Insert(urun);
        }

        public UrunDTO Select()
        {
            UrunDTO dto = new UrunDTO();
            dto.Kategoriler = kategoridao.Select();
            dto.Urunler = dao.Select();
            return dto;
        }

        public bool Update(UrunDetayDTO entity)
        {
            URUN urun = new URUN();
            if(entity.isStokEkleme)
            {
                urun.ID = entity.ID;
                urun.Stok = entity.StokMiktar;

            }
            else
            {
                urun.ID = entity.ID;
                urun.Fiyat = entity.Fiyat;
                urun.KategoriID = entity.KategoriID;
                urun.UrunAd = entity.UrunAd;
            }

            return dao.Update(urun);

        }
    }
}
