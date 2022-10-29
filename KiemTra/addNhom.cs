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
    public partial class addNhom : Form
    {
        public addNhom()
        {
            InitializeComponent();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            var n = new Nhom
            {
                TenNhom = txtTenNhom.Text,
            };
            if (NhomServices.AddNhom(n) == KetQua.ThanhCong)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Tên Nhóm trùng!", "Thông báo");
                txtTenNhom.Focus();
            }
        }



    }
}
