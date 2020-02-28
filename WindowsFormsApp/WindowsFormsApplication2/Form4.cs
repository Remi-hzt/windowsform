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
    public partial class Form4 : Form
    {
        string jh = null;
        Form main;
        public Form4(Form a,string jh)
        {
            InitializeComponent();
            main = a;
            this.jh = jh;
        }
          public Form4(Form a)
        {
            InitializeComponent();
            main = a;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            int  a = db.DataSet("select COUNT(*) from 教师表 where 教师号='"+jh+"'");
            
            if(a==2)
            {
                string name = textBox1.Text;
                string jsh = textBox2.Text;
                string zc = comboBox1.Text;
                string bmmc = comboBox2.Text;
                string lxfs = textBox3.Text;

                string bmbh = db.aa("select 部门编号 from 部门表 where 部门名称='" + bmmc + "';");
                int jshcf = db.DataSet("select count(*) from 教师表 where 教师号='" + jsh + "'");
                if (jshcf == 2) {
                    int b = db.Exitsql("insert into 教师表 values ('" + jsh + "','" + name + "','" + zc + "','" + bmbh + "','" + lxfs + "')");                              
                    if (b > 0)
                    {
                        MessageBox.Show("新建成功!!");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("新建失败！！");
                    }
                }
                else
                {
                    MessageBox.Show("教师号已存在");
                }

                
            }
            else if(a==1)
            {
                string name = textBox1.Text;
                string jsh = textBox2.Text;
                string zc = comboBox1.Text;
                string bmmc = comboBox2.Text;
                string lxfs = textBox3.Text;

                string bmbh = db.aa("select 部门编号 from 部门表 where 部门名称='" + bmmc + "';");
                int d = db.Exitsql("update 教师表 set 教师号='" + jsh + "',姓名='" + name + "',职称='" + zc + "',部门编号='" + bmbh + "',联系方式='" + lxfs + "' where 教师号='" + jh + "'");
                if (d > 0 )
                {
                    MessageBox.Show("修改成功！！");
                    
                    Close();

                }
                else
                {
                    MessageBox.Show("修改失败！！");
                }
                
            }
            

            


        }

        private void Form4_Load(object sender, EventArgs e)
        {
            if (jh == null)
            {
                a();
            }
            else
            { 
                b(); 
            }
        }
        private void a()
        {
            DB db = new DB();
            DataSet a = db.Getdataset("select distinct 职称 from 教师表");
            comboBox1.DataSource = a.Tables[0];
            comboBox1.DisplayMember = "职称";
            DataSet c = db.Getdataset("select * from 部门表");
            comboBox2.DataSource = c.Tables[0];
            comboBox2.DisplayMember = "部门名称";

            db.Close();
        }
        private void b()
        {
            DB db = new DB();
            string a = string.Format("select 姓名,C.教师号,部门名称,联系方式,职称 from 教师表 C  join 部门表 D on  C.部门编号=D.部门编号 where C.教师号='" + jh+"';");
            DataSet da = new DataSet();
            da = db.Getdataset(a);

            string b = string.Format("select distinct 职称 from 教师表");
            DataSet da1 = new DataSet();
            da1 = db.Getdataset(b);
            comboBox1.DataSource = da1.Tables[0];
            comboBox1.DisplayMember = "职称";

            string d= string.Format("select 部门名称 from 部门表");
            DataSet da3 = new DataSet();
            da3= db.Getdataset(d);
            comboBox2.DataSource=da3.Tables[0];
            comboBox2.DisplayMember="部门名称";





            textBox1.Text = da.Tables[0].Rows[0][0].ToString();
            textBox2.Text = da.Tables[0].Rows[0][1].ToString();
            comboBox2.Text = da.Tables[0].Rows[0][2].ToString();
            textBox3.Text = da.Tables[0].Rows[0][3].ToString();
            comboBox1.Text = da.Tables[0].Rows[0][4].ToString();
            db.Close();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
             main.Show();
            

        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
         
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            a();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
