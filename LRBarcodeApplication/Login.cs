using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LRLibrary;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Configuration;



namespace LRBarcodeApplication
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public  Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    
        public static string UserMd5(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(str)));
            t2 = t2.Replace("-", "");
            return t2;
        }
        private void btn_login_Click(object sender, EventArgs e)
        {


            //txtBox_userid   txtBox_passWd

            string uname = this.txtBox_userid.Text.Trim();
            string pwd = UserMd5(txtBox_passWd.Text.TrimEnd().TrimStart());
          SqlConnection sqlcon = DBLibrary.getConn("119.23.174.4", "LR", "lr", "lr123456");
         // SqlConnection sqlcon = DBLibrary.getConn("192.168.0.150", "HSLR", "sa", "abc@123");//正式服务器
            sqlcon.Open();                               //打开数据库连接
            SqlCommand cmd = new SqlCommand();     //创建SqlCommand对象
            cmd.Connection = sqlcon;               //用sqlCon初始化SqlCommand对象
            cmd.CommandText = "select * from ES_User where UserLogin='" + uname + "' and UserPwd='" + pwd + "'";
            SqlDataReader sqlDr = cmd.ExecuteReader();   //创建SqlDataReader对象
   
            
       
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    
            if (checkBox1.Checked)
                {
                    cfa.AppSettings.Settings["rememberme"].Value = "true";
                    cfa.AppSettings.Settings["name"].Value = uname;
                    cfa.AppSettings.Settings["password"].Value = txtBox_passWd.Text;
                    cfa.Save();
                }
                else
                {
                    cfa.AppSettings.Settings["rememberme"].Value = "false";
                    cfa.AppSettings.Settings["name"].Value = "";
                    cfa.AppSettings.Settings["password"].Value = "";
                } 
            cfa.Save();
         
           
            if (sqlDr.Read())                                  //帐号和密码正确
            {              
                MainForm mForm = new MainForm();
                this.Visible = false;
                mForm.ShowDialog();
                this.Dispose();
                this.Close();
            }
            else                                              //帐号或密码错误
            {
                MessageBox.Show("用户或密码不正确，请重新输入！");
             
                txtBox_passWd.Text = "";
            }
            sqlcon.Close();


            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["rememberme"].Equals("true"))
            {

                txtBox_userid.Text = cfa.AppSettings.Settings["name"].Value.ToString();
                txtBox_passWd.Text = cfa.AppSettings.Settings["password"].Value.ToString();
                checkBox1.Checked = true;
            }
        }
       
      
    }
}
