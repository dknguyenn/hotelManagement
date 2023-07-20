using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DAO;
using MySql.Data.MySqlClient;

namespace HotelManagement.BUS
{
    internal class DichVuPhongBUS
    {
        DichVuPhongDAO dao;
        public DichVuPhongBUS(MySqlConnection conn)
        {
            this.dao = new DichVuPhongDAO(conn);
        }
        public DataTable getByMaPhong(int maPhong)
        {
            return dao.getByMaPhong(maPhong);
        }
    }
}
