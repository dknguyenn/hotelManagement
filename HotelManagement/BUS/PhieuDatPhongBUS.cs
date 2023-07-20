using HotelManagement.DAO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BUS
{
    internal class PhieuDatPhongBUS
    {
        PhieuDatPhongDAO dao;
        int MaPhieu;
        DateTime NgayLap;
        string TrangThai;
        DateTime NgayDen;
        DateTime NgayTraPhong;
        int MaPhong;
        string YeuCauDacBiet;
        int MaKH;
        int MaNV;

        public PhieuDatPhongBUS(MySqlConnection conn)
        {
            this.dao = new PhieuDatPhongDAO(conn);
        }
        public PhieuDatPhongBUS(MySqlConnection conn, string TrangThai, DateTime NgayDen, DateTime NgayTraPhong, int MaPhong, string YeuCauDacBiet, int MaKH, int MaNV)
        {
            this.dao = new PhieuDatPhongDAO(conn);
            this.TrangThai = TrangThai;
            this.NgayDen = NgayDen;
            this.NgayTraPhong = NgayTraPhong;
            this.MaPhong = MaPhong;
            this.YeuCauDacBiet = YeuCauDacBiet;
            this.MaKH = MaKH;
            this.MaNV = MaNV;
        }

        public void setAttributes(string TrangThai, DateTime NgayDen, DateTime NgayTraPhong, int MaPhong, string YeuCauDacBiet, int MaKH, int MaNV)
        {
            this.TrangThai = TrangThai;
            this.NgayDen = NgayDen;
            this.NgayTraPhong = NgayTraPhong;
            this.MaPhong = MaPhong;
            this.YeuCauDacBiet = YeuCauDacBiet;
            this.MaKH = MaKH;
            this.MaNV = MaNV;
        }

        public string getNgayDen()
        {
            return this.NgayDen.ToString("yyyy-MM-dd");
        }
        public string getNgayTraPhong()
        {
            return this.NgayTraPhong.ToString("yyyy-MM-dd");
        }

        public int getMaPhong()
        {
            return this.MaPhong;
        }
        public int getMaNV()
        {
            return this.MaNV;
        }
        public int getMaKH()
        {
            return this.MaKH;
        }
        public string getYeuCauDacBiet()
        {
            return this.YeuCauDacBiet;
        }

        public bool insertPhieuDatPhong()
        {
            return dao.insertPhieuDatPhong(this);
        }

        public DataTable getAll()
        {
            return dao.getAll();
        }

        public DataTable getByName(string nameKH)
        {
            return dao.getByName(nameKH);
        }
        public DataTable getBySDT(string sdtKH)
        {
            return dao.getBySDT(sdtKH);
        }
        public bool updateYeuCauPhieuDatPhong(int maPhieu, string yeuCauDacBiet)
        {
            return dao.updateYeuCauPhieuDatPhong(maPhieu, yeuCauDacBiet);
        }
        public bool updateTrangThai(int maPhieu, string trangThai)
        {
            return dao.updateTrangThai(maPhieu, trangThai);
        }
    }
}
