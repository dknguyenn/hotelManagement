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
    internal class LoaiPhongBUS
    {
        LoaiPhongDAO dao;

        public LoaiPhongBUS(MySqlConnection conn)
        {
            dao = new LoaiPhongDAO(conn);
        }

        public DataTable getAll()
        {
            return dao.getAll();
        }
    }
}
