using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DAO;
using MySql.Data.MySqlClient;

namespace HotelManagement.BUS
{
    internal class UserBUS
    {
        static UserDAO dao;

        public UserBUS ()
        {
            dao = new UserDAO ();
        }

        public MySqlConnection getConnection()
        {
           return dao.getConnection();
        }

        public int loginHandle(string username, string password)
        {
            return dao.loginHandle(username, password);
        }
    }
}
