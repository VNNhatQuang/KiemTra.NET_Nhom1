using KiemTra.ViewModel;
using KiemTra.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTra.Services
{
    internal class SinhVienServices
    {
        public static List<SinhVienViewModel> GetList()
        {
            var db = new AppDBContext();
            var rs = db.SinhVien.Select(e => new SinhVienViewModel
            {
                ID = e.MaSinhVien,
                HoTen = e.HoTen,
                DiaChi = e.DiaChi,
                Email = e.Email,
                ID_Nhom = e.IDNhom,
                SoDienThoai = e.SoDienThoai,
            }).ToList();

            return rs;
        }

        public static SinhVienViewModel GetSinhVien()
        {
            var db = new AppDBContext();
            var rs = db.SinhVien.Select(e => new SinhVienViewModel
            {
                ID = e.MaSinhVien,
                HoTen = e.HoTen,
                DiaChi = e.DiaChi,
                Email = e.Email,
                ID_Nhom = e.IDNhom,
                SoDienThoai = e.SoDienThoai,
            }).ToList();

            return rs[0];
        }

        public static List<SinhVienViewModel> GetList(int idNhom)
        {
            var db = new AppDBContext();
            var rs = db.SinhVien
                .Where(e => e.IDNhom == idNhom)
                .Select(e => new SinhVienViewModel
                {
                    ID = e.MaSinhVien,
                    SoDienThoai = e.SoDienThoai,
                    DiaChi = e.DiaChi,
                    Email = e.Email,
                    HoTen = e.HoTen,
                    ID_Nhom = e.IDNhom
                }).ToList();

            return rs;
        }

        public static KetQua AddSinhVien(SinhVien sv)
        {
            var db = new AppDBContext();
            var count = db.SinhVien.Where(e => e.MaSinhVien == sv.MaSinhVien).Count();
            if (count > 0)
            {
                return 0;
            }
            else
            {
                db.SinhVien.Add(sv);
                db.SaveChanges();
                return KetQua.ThanhCong;
            }
        }

        public static KetQua UpdateSinhVien(SinhVienViewModel sv)
        {
            var db = new AppDBContext();
            var sinhVien = db.SinhVien.Where(e => e.MaSinhVien == sv.ID).FirstOrDefault();
            sinhVien.MaSinhVien = sv.ID;
            sinhVien.IDNhom = sv.ID_Nhom;
            sinhVien.Email = sv.Email;
            sinhVien.DiaChi = sv.DiaChi;
            sinhVien.HoTen = sv.HoTen;
            sinhVien.SoDienThoai = sv.SoDienThoai;
            db.SaveChanges();
            return KetQua.ThanhCong;
        }

        public static KetQua RemoveSinhVien(SinhVienViewModel sv)
        {
            var db = new AppDBContext();
            var sinhVien = db.SinhVien.Where(e => e.MaSinhVien == sv.ID).FirstOrDefault();
            db.SinhVien.Remove(sinhVien);
            db.SaveChanges();

            return KetQua.ThanhCong;
        }
    }
}
