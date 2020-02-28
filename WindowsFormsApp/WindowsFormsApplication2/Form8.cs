using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form8 : Form
    {
        string kh = null;
        Form main;
        public Form8(Form a)
        {
            InitializeComponent();
            main = a;
        }
        public Form8(Form a,string kh)
        {
            InitializeComponent();
            this.kh = kh;
            main = a;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            if (kh == null)
            {
                string kch = textBox1.Text;
                string kcm = textBox2.Text;
                string bz = textBox3.Text;
                string xs = textBox4.Text;
                string xf = textBox5.Text;
                int kchcf = db.DataSet("select count(*) from 课程表 where 课程号='" + kch + "'");
                if (kchcf == 2)
                {
                    int a = db.Exitsql("insert into 课程表 values('" + kch + "','" + kcm + "'," + xs + "," + xf + ",'" + bz + "');");
                    if (a > 0)
                    {
                        MessageBox.Show("新建成功！！");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("新建失败！！");
                    }
                }
                else
                {
                    MessageBox.Show("课程号存在！！");
                }
            }
            else
            {
                string kch = textBox1.Text;
                string kcm = textBox2.Text;
                string bz = textBox3.Text;
                string xs = textBox4.Text;
                string xf = textBox5.Text;
                int kchcf = db.DataSet("select count(*) from 课程表 where 课程号='" + kch + "'");
                int a = db.Exitsql("update 课程表 set 课程号=" + kch + ",课名='" + kcm + "',学时=" + xs + ",学分=" + xf + ",备注='"+bz+"' where 课程号=" + kh + ";");
                if (a > 0)
                {
                    MessageBox.Show("修改成功！！");
                    Close();
                }
                else
                {
                    MessageBox.Show("修改失败！！该课程尚在课程中");

                }
            }
        
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            if (kh != null)
            {
                DB db = new DB();
                DataSet a = new DataSet();
                string sql = string.Format("select * from 课程表 where 课程号='" + kh + "'");
                a = db.Getdataset(sql);
                textBox1.Text = a.Tables[0].Rows[0][0].ToString();
                textBox2.Text = a.Tables[0].Rows[0][1].ToString();
                textBox3.Text = a.Tables[0].Rows[0][4].ToString();
                textBox4.Text = a.Tables[0].Rows[0][2].ToString();
                textBox5.Text = a.Tables[0].Rows[0][3].ToString();
            }
        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
       
                main.Show();
    
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
