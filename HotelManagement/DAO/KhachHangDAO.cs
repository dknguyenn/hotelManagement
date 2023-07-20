using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.BUS;
using MySql.Data.MySqlClient;


namespace HotelManagement.DAO
{
    internal class KhachHangDAO
    {
        public MySqlConnection conn;
        public KhachHangDAO(MySqlConnection conn)
        {
            this.conn = conn;
        }

        public DataTable getAll()
        {
            if (this.conn.State == ConnectionState.Closed)
                conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM KHACHHANG";
            cmd.CommandType = CommandType.Text;
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            cmd.Cancel();
            conn.Close();

            return dt;
        }

        public bool insertKhachHang(KhachHangBUS bus)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO KHACHHANG(HoTen,Email,CMND,GioiTinh,DiaChi,SDT,MaDoan) VALUES('"+bus.getHoTen()+ "', '"+bus.getEmail()+ "','"+bus.getCMND()+ "','"+bus.getGioiTinh()+"','" + bus.getDiaChi() + "','" + bus.getSDT() + "', null)";
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
        public bool updateKhachHang(KhachHangBUS bus)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE KHACHHANG SET HoTen = '" + bus.getHoTen() + "', Email = '" + bus.getEmail() + "', CMND = '" + bus.getCMND() + "', GioiTinh = '" + bus.getGioiTinh() + "', DiaChi = '" + bus.getDiaChi() + "', SDT = '" + bus.getSDT() + "' WHERE MaKH = "+bus.getMaKH()+"";
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
