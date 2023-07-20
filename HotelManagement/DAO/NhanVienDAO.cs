using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace HotelManagement.DAO
{
    internal class NhanVienDAO
    {
        public MySqlConnection conn;
        public NhanVienDAO(MySqlConnection conn)
        {
            this.conn = conn;
        }
    }
}
