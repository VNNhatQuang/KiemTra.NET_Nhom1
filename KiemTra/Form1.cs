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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KiemTra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            NapDSNhom();
            

            NapDSSinhVien();
        }

        public NhomViewModel selectedNhom
        {
            get
            {
                return nhomViewModelBindingSource.Current as NhomViewModel;
            }
        }
        public SinhVienViewModel selectedSinhVien
        {
            get
            {
                return sinhVienViewModelBindingSource.Current as SinhVienViewModel;
            }
        }

        void NapDSNhom()
        {
            var ls = NhomServices.GetList();
            nhomViewModelBindingSource.DataSource = ls;
            dataGridView1.DataSource = nhomViewModelBindingSource;
        }

        void NapDSSinhVien()
        {
            if (selectedNhom != null)
            {
                var ls = SinhVienServices.GetList(selectedNhom.ID);
                sinhVienViewModelBindingSource.DataSource = ls;
                dataGridView2.DataSource = sinhVienViewModelBindingSource;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NapDSSinhVien();
        }

        private NhomViewModel GetSelectedNhom()
        {
            return selectedNhom;
        }

        void HienThiChiTietLienLac()
        {
            if (selectedSinhVien != null)
            {
                var ls = SinhVienServices.GetSinhVien(selectedSinhVien.ID);
                lbTenGoi.Text = ls.HoTen;
                lbDiaChi.Text = ls.DiaChi;
                lbEmail.Text = ls.Email;
                lbSDT.Text = ls.SoDienThoai;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HienThiChiTietLienLac();
        }

        private void btnXoaLL_Click(object sender, EventArgs e)
        {
            if (selectedSinhVien != null)
            {
                var rs = MessageBox.Show("Bạn có chắc là muốn xóa?", "Chú ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.OK)
                {
                    SinhVienServices.RemoveSinhVien(selectedSinhVien);
                    NapDSSinhVien();
                }
            }
        }

        private void btnThemLL_Click(object sender, EventArgs e)
        {
            var a = new addLienLac();
            var rs = a.ShowDialog();
            if (rs == DialogResult.OK)
            {
                NapDSSinhVien();
            }
        }

        private void btnThemNhom_Click(object sender, EventArgs e)
        {
            var a = new addNhom();
            var rs = a.ShowDialog();
            if (rs == DialogResult.OK)
            {
                NapDSNhom();
            }
        }

        private void btnXoaNhom_Click(object sender, EventArgs e)
        {
            if (selectedNhom != null)
            {
                var rs = MessageBox.Show("Bạn có chắc là muốn xóa?", "Chú ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.OK)
                {
                    NhomServices.RemoveNhom(selectedNhom);
                    NapDSNhom();
                }
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var ls = SinhVienServices.TimKiem(txtTimKiem.Text, selectedNhom.ID);
                if (ls==null)
                {
                    MessageBox.Show($"Không tìm thấy {txtTimKiem.Text} trong Nhóm {selectedNhom.TenNhom}", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lbTenGoi.Text = ls.HoTen;
                    lbDiaChi.Text = ls.DiaChi;
                    lbEmail.Text = ls.Email;
                    lbSDT.Text = ls.SoDienThoai;

                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        if (dataGridView2.Rows[i].Cells[0].Value.ToString().Equals(txtTimKiem.Text))
                        {
                            dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells[0];
                            dataGridView2.CurrentRow.Selected = true;
                        }
                    }
                }

            }
        }
    }
}
