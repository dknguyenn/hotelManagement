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
    internal class PhieuDatPhongDAO
    {
        public MySqlConnection conn;
        public PhieuDatPhongDAO(MySqlConnection conn)
        {
            this.conn = conn;
        }

        public bool insertPhieuDatPhong(PhieuDatPhongBUS bus)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            if (bus.getYeuCauDacBiet() != "")
                cmd.CommandText = "INSERT INTO PHIEUDATPHONG(NgayLap,TrangThai,NgayDen,NgayTraPhong,MaPhong,YeuCauDacBiet,MaKH,MaNV) VALUES(DATE(now()), 'Đang đặt',DATE('" + bus.getNgayDen()+"'),DATE('"+bus.getNgayTraPhong()+"'),"+bus.getMaPhong()+",'"+bus.getYeuCauDacBiet()+"',"+bus.getMaKH()+ ","+bus.getMaNV()+")";
            else
                cmd.CommandText = "INSERT INTO PHIEUDATPHONG(NgayLap,TrangThai,NgayDen,NgayTraPhong,MaPhong,YeuCauDacBiet,MaKH,MaNV) VALUES(DATE(now()), 'Đang đặt', DATE('" + bus.getNgayDen() + "'),DATE('" + bus.getNgayTraPhong() + "')," + bus.getMaPhong() + ", null," + bus.getMaKH() + "," + bus.getMaNV() + ")";
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
                MessageBox.Show(ex.Message);    
                return false;
            }
        }
        public DataTable getAll()
        {
            if (this.conn.State == ConnectionState.Closed)
                conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM PHIEUDATPHONG";
            cmd.CommandType = CommandType.Text;
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            cmd.Cancel();
            conn.Close();

            return dt;
        }

        public DataTable getByName(string nameKH)
        {
            if (this.conn.State == ConnectionState.Closed)
                conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM PHIEUDATPHONG, KHACHHANG WHERE PHIEUDATPHONG.MaKH = KHACHHANG.MaKH AND KHACHHANG.HoTen like '%"+nameKH+"%'";
            cmd.CommandType = CommandType.Text;
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            cmd.Cancel();
            conn.Close();

            return dt;
        }
        public DataTable getBySDT(string sdtKH)
        {
            if (this.conn.State == ConnectionState.Closed)
                conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM PHIEUDATPHONG, KHACHHANG WHERE PHIEUDATPHONG.MaKH = KHACHHANG.MaKH AND KHACHHANG.SDT = '" + sdtKH + "'";
            cmd.CommandType = CommandType.Text;
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            cmd.Cancel();
            conn.Close();

            return dt;
        }
        public bool updateYeuCauPhieuDatPhong(int maPhieu, string yeuCauDacBiet)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE PHIEUDATPHONG Set YeuCauDacBiet = '"+ yeuCauDacBiet + "' WHERE MaPhieu = "+ maPhieu + "";
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
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool updateTrangThai(int maPhieu, string trangThai)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE PHIEUDATPHONG Set TrangThai = '" + trangThai + "' WHERE MaPhieu = " + maPhieu + "";
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
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
