using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAO
{
    internal class DichVuPhongDAO
    {
        public MySqlConnection conn;
        public DichVuPhongDAO(MySqlConnection conn)
        {
            this.conn = conn;
        }

        public DataTable getByMaPhong(int maPhong)
        {
            if (this.conn.State == ConnectionState.Closed)
                conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT SANPHAMDICHVU.TenDichVu, SANPHAMDICHVU.ThongTinDichVu, SANPHAMDICHVU.DonGia FROM DICHVUPHONG, PHONG, SANPHAMDICHVU WHERE PHONG.MaPhong = " + maPhong + " AND SANPHAMDICHVU.MaDichVu = DICHVUPHONG.MaDichVu AND DICHVUPHONG.MaPhong = PHONG.MaPhong;";
            cmd.CommandType = CommandType.Text;
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            cmd.Cancel();
            conn.Close();

            return dt;
        }
    }
}
