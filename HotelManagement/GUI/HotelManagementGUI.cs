using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MySql.Data.MySqlClient;
using HotelManagement.BUS;
using HotelManagement.DAO;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Utilities;

namespace HotelManagement.GUI
{
    public partial class HotelManagementGUI : MaterialSkin.Controls.MaterialForm
    {
        int maNV;
        PhongBUS phongServices;
        LoaiPhongBUS loaiPhongServices;
        KhachHangBUS khachHangServices;
        PhieuDatPhongBUS phieuDatPhongServices;
        DichVuPhongBUS dichVuPhongServices;
        private DataGridViewRow row = new DataGridViewRow();
        public HotelManagementGUI(MySqlConnection conn, int maNV)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            this.maNV = maNV;
            phongServices = new PhongBUS(conn);
            loaiPhongServices = new LoaiPhongBUS(conn);
            khachHangServices = new KhachHangBUS(conn);
            phieuDatPhongServices = new PhieuDatPhongBUS(conn);
            dichVuPhongServices = new DichVuPhongBUS(conn);
            loadDSPhong();
            loadDSKhachHang();
            loadDSPhieuDatPhong();
        }

        void loadDSPhong()
        {
            dgvPhong.DataSource = phongServices.getAll();
            if (dgvPhong.Rows.Count > 1)
            {
                for (int i = 0; i < dgvPhong.Rows.Count - 1; i++)
                {
                    txtMaPhong.Items.Add(dgvPhong.Rows[i].Cells[0].Value);
                }
            }
        }

        void loadDSKhachHang()
        {
            dgvKhachHang.DataSource = khachHangServices.getAll();
            dgvKhachHang1.DataSource = khachHangServices.getAll();
        }

        void loadDSPhieuDatPhong()
        {
            dgvPhieuDatPhong.DataSource = phieuDatPhongServices.getAll();
        }
        private void btnUpdatePhong_Click(object sender, EventArgs e)
        {
            phongServices.setAttributes(Convert.ToInt32(txtMaPhong.Text), txtTinhTrang.Text, Convert.ToInt32(txtLoaiPhong.Text));
            if (phongServices.updatePhong() == true)
            {
                MessageBox.Show("Cập nhật phòng thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật phòng thất bại");
            }
            loadDSPhong();
        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPhong.CurrentRow.Selected = true;
            if (e.RowIndex >= 0)
            {
                row = dgvPhong.Rows[e.RowIndex];
                txtMaPhong.Text = row.Cells["Mã phòng"].Value.ToString(); ;
                txtTinhTrang.Text = row.Cells["Tình trạng"].Value.ToString();
                txtLoaiPhong.Text = row.Cells["Loại phòng"].Value.ToString();

            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvKhachHang.CurrentRow.Selected = true;
            if (e.RowIndex >= 0)
            {
                txtMaKH.Text = dgvKhachHang.Rows[e.RowIndex].Cells[0].Value.ToString(); ;
                txtHoTenKH.Text = dgvKhachHang.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtEmailKH.Text = dgvKhachHang.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtCMNDKH.Text = dgvKhachHang.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtGioiTinhKH.Text = dgvKhachHang.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtDiaChiKH.Text = dgvKhachHang.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtSDTKH.Text = dgvKhachHang.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtDoanKH.Text = dgvKhachHang.Rows[e.RowIndex].Cells[7].Value.ToString();
            }

        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            khachHangServices.setAttributes(Convert.ToInt32(txtMaKH.Text), txtHoTenKH.Text, txtEmailKH.Text, txtCMNDKH.Text, txtGioiTinhKH.Text, txtDiaChiKH.Text, txtSDTKH.Text, 0);
            if (khachHangServices.insertKhachHang() == true)
            {
                MessageBox.Show("Thêm khách hàng thành công");

            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại");
            }
            loadDSKhachHang();
        }

        private void btnThayDoiKhachHang_Click(object sender, EventArgs e)
        {
            khachHangServices.setAttributes(Convert.ToInt32(txtMaKH.Text), txtHoTenKH.Text, txtEmailKH.Text, txtCMNDKH.Text, txtGioiTinhKH.Text, txtDiaChiKH.Text, txtSDTKH.Text, 0);
            if (khachHangServices.updateKhachHang() == true)
            {
                MessageBox.Show("Cập nhật thông tin khách hàng thành công");

            }
            else
            {
                MessageBox.Show("Cập nhật thông tin khách hàng thất bại");
            }
            loadDSKhachHang();
        }

        private void btnLocPhong_Click(object sender, EventArgs e)
        {
            if (dtpNgayTraPhong.Value.Date > dtpNgayDen.Value.Date)
            {
                DataTable dt = phongServices.getAllDateFilter(dtpNgayDen.Value.Date, dtpNgayTraPhong.Value.Date);
                dgvFilterPhong.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Ngày trả phòng phải sau ngày đến");
            }

        }

        private void dgvKhachHang1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvKhachHang1.CurrentRow.Selected = true;
            if (e.RowIndex >= 0)
                txtMaKHDatPhong.Text = dgvKhachHang1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void dgvFilterPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvFilterPhong.CurrentRow.Selected = true;
            if (e.RowIndex >= 0)
            {
                txtMaPhongDatPhong.Text = dgvFilterPhong.Rows[e.RowIndex].Cells[0].Value.ToString();
                int maPhong = Convert.ToInt32(txtMaPhongDatPhong.Text);
                txtTienCoc.Text = phongServices.getOrderPrice(maPhong, dtpNgayDen.Value.Date, dtpNgayTraPhong.Value.Date).ToString();

            }
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            if (dtpNgayTraPhong.Value.Date > dtpNgayDen.Value.Date)
            {
                phieuDatPhongServices.setAttributes("Đang đặt", dtpNgayDen.Value.Date, dtpNgayTraPhong.Value.Date, Convert.ToInt32(txtMaPhongDatPhong.Text), txtYeuCauDacBiet.Text, Convert.ToInt32(txtMaKHDatPhong.Text), Convert.ToInt32(maNV));
                if (phieuDatPhongServices.insertPhieuDatPhong() == true)
                {
                    MessageBox.Show("Đặt phòng thành công");
                    phongServices.setAttributes(Convert.ToInt32(txtMaPhongDatPhong.Text), "Đã đặt");
                    phongServices.updateTinhTrang();
                    loadDSPhong();
                }
                else
                {
                    MessageBox.Show("Đặt phòng không thành công");
                }
            }
            else
            {
                MessageBox.Show("Ngày trả phòng phải sau ngày đến ít nhất một ngày");
            }
        }

        private void btnTimPhieu_Click(object sender, EventArgs e)
        {
            if (txtTenKHCheckin.Text != "" || txtSDTKHCheckin.Text != "")
            {
                if (txtSDTKHCheckin.Text != "")
                {
                    dgvPhieuDatPhong.DataSource = phieuDatPhongServices.getBySDT(txtSDTKHCheckin.Text);
                }
                else
                {
                    dgvPhieuDatPhong.DataSource = phieuDatPhongServices.getByName(txtTenKHCheckin.Text);
                }
            }
            else
            {
                loadDSPhieuDatPhong();
            }
        }

        private void dgvPhieuDatPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPhieuDatPhong.CurrentRow.Selected = true;
            if (e.RowIndex >= 0)
            {
                txtMaPhieu.Text = dgvPhieuDatPhong.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtMaPhongCheckIn.Text = dgvPhieuDatPhong.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtYeuCauDBCheckIn.Text = dgvPhieuDatPhong.Rows[e.RowIndex].Cells[6].Value.ToString();
                dgvDichVuPhong.DataSource = dichVuPhongServices.getByMaPhong(Convert.ToInt32(txtMaPhongCheckIn.Text));
            }
        }

        private void btnUpdateYeuCauDacBiet_Click(object sender, EventArgs e)
        {
            if (txtYeuCauDBCheckIn.Text != "" && txtMaPhieu.Text != "")
            {
                if (phieuDatPhongServices.updateYeuCauPhieuDatPhong(Convert.ToInt32(txtMaPhieu.Text), txtYeuCauDBCheckIn.Text) == true)
                {
                    MessageBox.Show("Cập nhật yêu cầu đặc biệt thành công");
                    loadDSPhieuDatPhong();

                }
                else
                {
                    MessageBox.Show("Cập nhật yêu cầu đặc biệt thất bại");
                }
                loadDSKhachHang();
            }
            else
            {
                MessageBox.Show("Vui lòng điền phiếu yêu cầu và chọn phiếu cần cập nhật");
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (txtMaPhieu.Text != "")
            {
                if (phieuDatPhongServices.updateTrangThai(Convert.ToInt32(txtMaPhieu.Text), "Đang sử dụng") == true)
                {
                    MessageBox.Show("Check in thành công");
                    loadDSPhieuDatPhong();

                }
                else
                {
                    MessageBox.Show("Check in thất bại");
                }
                loadDSKhachHang();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu check in");
            }
        }

        private void txtMaPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
