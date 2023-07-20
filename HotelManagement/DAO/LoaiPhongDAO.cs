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
    internal class LoaiPhongDAO
    {
        public MySqlConnection conn;
        public LoaiPhongDAO(MySqlConnection conn)
        {
            this.conn = conn;
        }

        public DataTable getAll()
        {
            if (this.conn.State == ConnectionState.Closed)
                conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT LP.MaLoai AS 'Mã loại phòng', LP.Mota AS 'Mô tả', LP.DonGia AS 'Đơn giá', LP.SoNguoi AS 'Số người tối đa', LP.QuyDinh AS 'Quy định' FROM LOAIPHONG LP";
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
