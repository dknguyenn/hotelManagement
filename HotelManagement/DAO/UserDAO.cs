using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Data;

namespace HotelManagement.DAO
{
    public class UserDAO
    {
        public static MySqlConnection conn;
        public UserDAO() {
        }

        public MySqlConnection getConnection()
        {
            string myConnectionString = "server=db-mysql-fra1-53705-do-user-14143572-0.b.db.ondigitalocean.com;port=25060;database=hotel_management;uid=doadmin;pwd=AVNS_NcCYeDJbKKFa6cA8zVS;";
            conn = new MySqlConnection(myConnectionString);
            return conn;
        }

        public string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }


        public int loginHandle(string username, string password)
        {
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT MaNV from USER where username = @username and password = @password";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            //cmd.CommandText = "select * from USER";
            cmd.CommandType = CommandType.Text;
            var maNV = cmd.ExecuteReader();
            if (maNV.Read())
            {
                int result = Convert.ToInt32(maNV.GetValue(0));
                conn.Close();
                return result;
            }
            else
            {
                conn.Close();
                return -1;
            }
        }
    }
}
