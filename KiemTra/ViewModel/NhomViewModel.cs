using KiemTra.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTra.ViewModel
{
    public class NhomViewModel
    {
        public int ID { get; set; }
        public string TenNhom { get; set; }


        /// <summary>
        /// Lấy toàn bộ lớp học
        /// </summary>
        /// <returns></returns>
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
    }
}
