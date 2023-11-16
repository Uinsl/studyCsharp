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
    public partial class bookForm : Form
    {
        public bookForm()
        {
            InitializeComponent(); 
            table();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // 
        private void bookForm_Load(object sender, EventArgs e)
        {
            //table();
        }

        //从数据库读取数据
        public void table() 
        { 
            dataGridView1.Rows.Clear();//清空数据
            Dao dao = new Dao();
            string sql = "select * from bookms_book";
            IDataReader dc = dao.read(sql);
            while (dc.Read()) 
            {

                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(),dc[3].ToString(),dc[4].ToString());
            }
            dc.Close();
            dao.DaoClose();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addBooks addBooks = new addBooks();
            addBooks.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//
                // 选中的第0行，第Cells[0]0个元素的值，string
                label1.Text = id +"||||"+ dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                DialogResult dr = MessageBox.Show("确认删存吗？","信息提示",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK) {
                    string sql = $"Delete from bookms_book WHERE id = '{id}'";
                    Dao dao = new Dao();
                    if (dao.Eexcute(sql) > 0) { MessageBox.Show("删存成功"); table(); }
                    else { MessageBox.Show("删存顺便"); }
                    dao.DaoClose();
                }


        }

        // 不小心双击了某个元素，生成了click方法，怎么撤回
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
