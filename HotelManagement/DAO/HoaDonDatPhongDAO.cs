using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace HotelManagement.DAO
{
    internal class HoaDonDatPhongDAO
    {
        public MySqlConnection conn;

        public HoaDonDatPhongDAO(MySqlConnection conn)
        {
            this.conn = conn;
        }

    }
}
