using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bookMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (accInput.Text!="" && pwdInput.Text!="")
            {
                login();


            }
            else
            {
                MessageBox.Show("用户名和密码不能为空");
            }
              
        }

        //登录方法验证账密 bool 和 boolean
        public void login()
        {
            bool result = false;

            if (radioBtnUser.Checked == true)
            {
                Dao dao = new Dao();
                string sql = $"select * from bookms_user WHERE id='{accInput.Text}' and pwd='{pwdInput.Text}';";
                //MessageBox.Show(sql);
                IDataReader dc = dao.read(sql);
                //dc.Read(); 读取下一行
                if (dc.Read())
                {

                    Data.Id = dc["id"].ToString();
                    Data.Name = dc["name"].ToString();

                    //MessageBox.Show("登录成功");
                    //result = true;
                    userForm user = new userForm();
                    this.Hide();//关闭loginForm

                    user.ShowDialog();// shwo 还能对登录窗口操作 ShowDialogon 不能操作登录窗口
                    this.Show();//显示userForm？

                    //
                    // data 类赋值
                }
                else
                {
                    //MessageBox.Show("登录失败");
                    //result = false;
                }
                dao.DaoClose();

            }

            if (radioBtnAdmin.Checked == true)
            {
                Dao dao = new Dao();
                string sql = $"select * from bookms_admin WHERE id='{accInput.Text}' and pwd='{pwdInput.Text}';";
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    adminForm admin = new adminForm();
                    this.Hide();
                    admin.ShowDialog();
                    this.Show();
                }
                else
                {
                    //MessageBox.Show("登录失败");
                    //result = false;
                }
                dao.DaoClose();

            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
