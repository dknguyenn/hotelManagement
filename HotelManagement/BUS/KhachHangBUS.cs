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
    internal class KhachHangBUS
    {
        KhachHangDAO dao;
        int MaKH;
        string HoTen;
        string Email;
        string CMND;
        string GioiTinh;
        string DiaChi;
        string SDT;
        int MaDoan;
        public KhachHangBUS(MySqlConnection conn)
        {
            dao = new KhachHangDAO(conn);
        }

        public void setAttributes(int MaKH, string HoTen, string Email, string CMND, string GioiTinh, string DiaChi,string SDT,int MaDoan)
        {
            this.MaKH = MaKH;
            this.HoTen = HoTen;
            this.Email = Email;
            this.CMND = CMND;
            this.GioiTinh = GioiTinh;
            this.DiaChi = DiaChi;
            this.SDT = SDT;
            this.MaDoan = MaDoan;
        }

        public int getMaKH()
        {
            return MaKH;
        }

        public string getHoTen()
        {
            return HoTen;
        }

        public string getEmail()
        {
            return Email;
        }

        public string getCMND()
        {
            return CMND;
        }
        public string getGioiTinh()
        {
            return GioiTinh;
        }
        public string getDiaChi()
        {
            return DiaChi;
        }
        public string getSDT()
        {
            return SDT;
        }
        public int getMaDoan()
        {
            return MaDoan;
        }
        public DataTable getAll()
        {
            return dao.getAll();
        }

        public bool insertKhachHang()
        {
            return dao.insertKhachHang(this);
        }

        public bool updateKhachHang()
        {
            return dao.updateKhachHang(this);
        }
    }
}
