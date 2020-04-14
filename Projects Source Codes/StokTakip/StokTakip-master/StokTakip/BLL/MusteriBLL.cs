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
    class MusteriBLL : IBLL<MusteriDetayDTO, MusteriDTO>
    {
        MusteriDAO dao = new MusteriDAO();
        SatisDAO satisdao = new SatisDAO();
        public bool Delete(MusteriDetayDTO entity)
        {
            MUSTERI musteri = new MUSTERI();
            musteri.ID = entity.ID;
            dao.Delete(musteri);
            SATIM satis = new SATIM();
            satis.MusteriID = entity.ID;
            satisdao.Delete(satis);

            return true;
        }

        public bool GetBack(MusteriDetayDTO entity)
        {
            return dao.GetBack(entity.ID);
        }

        public bool Insert(MusteriDetayDTO entity)
        {
            MUSTERI musteri = new MUSTERI();
            musteri.MusterAd = entity.MusteriAd;
            musteri.isDeleted = false;
            return dao.Insert(musteri);
        }

        public MusteriDTO Select()
        {
            MusteriDTO dto = new MusteriDTO();
            dto.Musteriler = dao.Select();
            return dto;
        }

        public bool Update(MusteriDetayDTO entity)
        {
            MUSTERI musteri = new MUSTERI();
            musteri.ID = entity.ID;
            musteri.MusterAd = entity.MusteriAd;
            return dao.Update(musteri);
        }
    }
}
