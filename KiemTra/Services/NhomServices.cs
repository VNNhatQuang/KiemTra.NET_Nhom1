using KiemTra.ViewModel;
using KiemTra.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTra.Services
{
    internal class NhomServices
    {
        public static List<NhomViewModel> GetList()
        {
            var db = new AppDBContext();
            var rs = db.Nhom.Select(e => new NhomViewModel
            {
                ID = e.MaNhom,
                TenNhom = e.TenNhom,
            }).ToList();

            return rs;
        }

        public static List<NhomViewModel> GetList(int idNhom)
        {
            var db = new AppDBContext();
            var rs = db.Nhom
                .Where(e => e.MaNhom == idNhom)
                .Select(e => new NhomViewModel
                {
                    ID = e.MaNhom,
                    TenNhom = e.TenNhom,
                }).ToList();

            return rs;
        }

        public static KetQua AddLopHoc(Nhom n)
        {
            var db = new AppDBContext();
            var count = db.Nhom.Where(e => e.MaNhom == n.MaNhom).Count();
            if (count > 0)
            {
                return 0;
            }
            else
            {
                db.Nhom.Add(n);
                db.SaveChanges();
                return KetQua.ThanhCong;
            }
        }

        public static KetQua UpdateLop(Nhom n)
        {
            var db = new AppDBContext();
            var nhom = db.Nhom.Where(e => e.MaNhom == n.MaNhom).FirstOrDefault();
            nhom.TenNhom = n.TenNhom;
            nhom.MaNhom = n.MaNhom;
            db.SaveChanges();
            return KetQua.ThanhCong;
        }

        public static KetQua RemoveLopHoc(NhomViewModel n)
        {
            var db = new AppDBContext();
            var lopHoc = db.Nhom.Where(e => e.MaNhom == n.ID).FirstOrDefault();
            db.Nhom.Remove(lopHoc);
            db.SaveChanges();

            return KetQua.ThanhCong;
        }
    }
}
