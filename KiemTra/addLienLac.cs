using KiemTra.Model;
using KiemTra.Services;
using KiemTra.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiemTra
{
    public partial class addLienLac: Form
    {
        public addLienLac(SinhVienViewModel sinhVien = null)
        {
            InitializeComponent();
            NapDSNhom();
        }

        public NhomViewModel selectedNhom
        {
            get
            {
                return cbNhom.SelectedItem as NhomViewModel;
            }
        }

        void NapDSNhom()
        {
            var ls = NhomViewModel.GetList();
            cbNhom.DataSource = ls;
            cbNhom.DisplayMember = "TenNhom";
        }

        private void txtQueQuan_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtMaSinhVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            #region Thêm mới sinh viên
            var sv = new SinhVien
            {
                HoTen = txtHoTen.Text,
                DiaChi = txtDiaChi.Text,
                Email = txtEmail.Text,
                MaSinhVien = txtMaSinhVien.Text,
                IDNhom = selectedNhom.ID,
                SoDienThoai = txtSDT.Text,
            };
            if (SinhVienServices.AddSinhVien(sv) == KetQua.ThanhCong)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Mã sinh viên trùng", "Thông báo");
                txtMaSinhVien.Focus();
            }
            #endregion
        }
    }
}
