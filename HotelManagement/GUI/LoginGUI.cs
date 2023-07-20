using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using HotelManagement.BUS;

namespace HotelManagement.GUI
{
    public partial class LoginGUI : Form
    {
        UserBUS userService;
        MySqlConnection conn;
        public LoginGUI()
        {
            InitializeComponent();
            userService = new UserBUS();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                conn = userService.getConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                try
                {
                    int MaNV = userService.loginHandle(username, password);
                    if (MaNV != -1)
                    {
                        HotelManagementGUI appGUI = new HotelManagementGUI(conn, MaNV);
                        appGUI.Show();
                        this.Visible = false;
                    }
                    else
                    {
                        throw new Exception("Đăng nhập sai.");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không được trống.", "Vui lòng nhập đầy đủ thông tin");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
