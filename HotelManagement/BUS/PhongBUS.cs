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
    internal class PhongBUS
    {
        PhongDAO dao;
        int MaPhong;
        string TinhTrang;
        int LoaiPhong;
        public PhongBUS(MySqlConnection conn)
        {
            dao = new PhongDAO(conn);
        }
        public PhongBUS(PhongDAO dao, int maPhong, string tinhTrang, int loaiPhong)
        {
            this.dao = dao;
            MaPhong = maPhong;
            TinhTrang = tinhTrang;
            LoaiPhong = loaiPhong;
        }

        public int getMaPhong()
        {
            return MaPhong;
        }
        public string getTinhTrang()
        {
            return TinhTrang;
        }
        public int getLoaiPhong()
        {
            return LoaiPhong;
        }

        public PhongBUS(MySqlConnection conn, int maPhong, string tinhTrang, int loaiPhong)
        {
            dao = new PhongDAO(conn);
            this.MaPhong = maPhong;
            this.TinhTrang = tinhTrang;
            this.LoaiPhong = loaiPhong;
        }

        public void setAttributes(int maPhong, string tinhTrang, int loaiPhong)
        {
            this.MaPhong = maPhong;
            this.TinhTrang = tinhTrang;
            this.LoaiPhong = loaiPhong;
        }

        public void setAttributes(int maPhong, string tinhTrang)
        {
            this.MaPhong = maPhong;
            this.TinhTrang = tinhTrang;
        }

        public DataTable getAll()
        {
            return dao.getAll();
        }

        public DataTable getAllDateFilter(DateTime ngayDen, DateTime ngayDi)
        {
            return dao.getAllDateFilter(ngayDen, ngayDi);
        }

        public int getOrderPrice(int maPhong, DateTime ngayDen, DateTime ngayDi)
        {
            if (ngayDi > ngayDen)
            {
                TimeSpan ts = ngayDi - ngayDen;
                int numOfDays = (int)ts.TotalDays;
                int price = dao.getOrderPrice(numOfDays,maPhong);
                return price;
            }
            else
            {
                return -1;
            }
        }

        public bool updatePhong()
        {
            return dao.updatePhong(this);
        }

        public bool updateTinhTrang()
        {
            return dao.updateTinhTrang(this);
        }
    }
}
