using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class Form3 : Form
    {
        string xh = null;
        Form mian;
        public Form3(Form a,string xh)
        {
            InitializeComponent();
            mian = a;
            this.xh = xh;
        }
        public Form3(Form a)
        {
            InitializeComponent();
            mian = a;
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            int c=db.DataSet("select COUNT(*) from 学生表 where 学号='"+xh+"'");
            if (c==2)
            {
                string h = textBox1.Text;
                string name = textBox2.Text;
                string sex = comboBox2.Text;
                string zhuany = comboBox1.Text;
                string birthday = dateTimePicker1.Text;
                string jtdz = textBox5.Text;
                string phone = textBox6.Text;
                string xuefen = textBox7.Text;

                if (sex == "男")
                {
                    sex = "false";
                }
                else
                {
                    sex = "true";
                }

                int a = db.Exitsql("insert into 学生表 values ('" + h + "','" + name + "','" + sex + "','" + zhuany + "','" + birthday + "','" + jtdz + "','" + phone + "','" + xuefen + "')");
                if (a > 0)
                {
                    MessageBox.Show("新建成功！！");
                    Close();

                }
                else if (a == -1)
                {
                    MessageBox.Show("新建失败！！");
                }
                else
                {
                    MessageBox.Show("数据库操作错误！！");
                }
                
            }
            else if(c==1)
            {
                string h = textBox1.Text;
                string name = textBox2.Text;
                string sex = comboBox2.Text;
                string zhuany = comboBox1.Text;
                string birthday = dateTimePicker1.Text;
                string jtdz = textBox5.Text;
                string phone = textBox6.Text;
                string xuefen = textBox7.Text;

                if (sex == "男")
                {
                    sex = "false";
                }
                else
                {
                    sex = "true";
                }
                int b = db.Exitsql("update 学生表 set 学号='" + h + "',姓名='" + name + "',性别='" + sex + "',专业='" + zhuany + "',出生年月='" + birthday + "',家庭地址='" + jtdz + "',联系方式='" + phone + "',总学分='" + xuefen + "'where 学号='" + xh + "'");
                if (b > 0)
                {
                    MessageBox.Show("修改成功！！");
                    Close();
                }
                else if (b == -1)
                {
                    MessageBox.Show("修改失败！！");
                }
                else
                {
                    MessageBox.Show("数据库操作错误！！");
                }
            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {
           
            if (xh == null)
                
                a();//调用a
            else
                b();
        }
        private void a()
        {
            //专业名称显示在下拉列表中
            DB a = new DB();
            DataSet b = a.Getdataset("select * from 部门表");
            comboBox1.DataSource = b.Tables[0];//获取数据表格
            comboBox1.DisplayMember = "部门名称";//显示那一列
            
        }
        private void b()
        {
            DB a = new DB();
            string sql = string.Format("select * from 学生表 where 学号='{0}'", xh);
            DataSet ds = new DataSet();
            ds = a.Getdataset(sql);
            string sql1 = string.Format("select distinct 专业 from 学生表");
            DataSet ds1 = new DataSet();
            ds1 = a.Getdataset(sql1);
            comboBox1.DataSource = ds1.Tables[0];
            comboBox1.DisplayMember = "专业";
            comboBox1.SelectedIndex = 1;
            textBox1.Text = ds.Tables[0].Rows[0][0].ToString();
            textBox2.Text = ds.Tables[0].Rows[0][1].ToString();
            comboBox1.Text = ds.Tables[0].Rows[0][3].ToString();
            textBox5.Text = ds.Tables[0].Rows[0][5].ToString();
            textBox6.Text = ds.Tables[0].Rows[0][6].ToString();
            textBox7.Text = ds.Tables[0].Rows[0][7].ToString();
            dateTimePicker1.Text = ds.Tables[0].Rows[0][4].ToString();
            comboBox2.Text = ds.Tables[0].Rows[0][2].ToString();
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox2.Text = "";
            a();
            dateTimePicker1.Text = "";


        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
             mian.Show(); 
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
