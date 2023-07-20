using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagement.BUS;
using MySql.Data.MySqlClient;


namespace HotelManagement.DAO
{
    internal class PhongDAO
    {
        public MySqlConnection conn;
        public PhongDAO(MySqlConnection conn)
        {
            this.conn = conn;
        }

        public DataTable getAll()
        {
            if (this.conn.State == ConnectionState.Closed)
                conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT P.MaPhong AS 'Mã phòng', P.TinhTrang AS 'Tình trạng', P.LoaiPhong AS 'Loại phòng', LP.Mota AS 'Mô tả', LP.DonGia AS 'Đơn giá', LP.SoNguoi AS 'Số người tối đa', LP.QuyDinh AS 'Quy định' FROM PHONG P JOIN LOAIPHONG LP ON P.LoaiPhong = LP.MaLoai ";
            cmd.CommandType = CommandType.Text;
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            cmd.Cancel();
            conn.Close();

            return dt;
        }

        public DataTable getAllDateFilter(DateTime ngayDen, DateTime ngayDi)
        {
            if (this.conn.State == ConnectionState.Closed)
                conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT P.MaPhong AS 'Mã phòng', P.TinhTrang AS 'Tình trạng', P.LoaiPhong AS 'Loại phòng', LP.Mota AS 'Mô tả', LP.DonGia AS 'Đơn giá', LP.SoNguoi AS 'Số người tối đa', LP.QuyDinh AS 'Quy định' FROM PHONG P JOIN LOAIPHONG LP ON P.LoaiPhong = LP.MaLoai WHERE P.MaPhong NOT IN (SELECT MaPhong FROM PHIEUDATPHONG WHERE NgayDen < DATE('"+ngayDi+"') AND NgayTraPhong > DATE('"+ngayDen+"'))";
            cmd.CommandType = CommandType.Text;
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            cmd.Cancel();
            conn.Close();

            return dt;
        }

        public bool updatePhong(PhongBUS bus)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE PHONG SET TinhTrang = '"+ bus.getTinhTrang() + "', LoaiPhong = "+ bus.getLoaiPhong() +" WHERE MaPhong = "+ bus.getMaPhong() +"";
            try
            {
                if (cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    throw (new Exception());
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int getOrderPrice(int numOfDay, int maPhong)
        {
            if (this.conn.State == ConnectionState.Closed)
                conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT DonGia FROM PHONG, LOAIPHONG WHERE PHONG.LoaiPhong = LOAIPHONG.MaLoai AND PHONG.MaPhong = "+ maPhong;
            cmd.CommandType = CommandType.Text;
            Int32 reader = (Int32)cmd.ExecuteScalar() ;
            cmd.Cancel();
            conn.Close();

            return (int)((int)reader * numOfDay * 0.3);
        }

        public bool updateTinhTrang(PhongBUS bus)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE PHONG SET TinhTrang = '" + bus.getTinhTrang() + "' WHERE MaPhong = " + bus.getMaPhong() + "";
            try
            {
                if (cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    throw (new Exception());
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
