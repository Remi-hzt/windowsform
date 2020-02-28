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
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = comboBox1.Text;
            string pass = textBox2.Text;
            DB db = new DB();
            int a = db.DataSet("select COUNT(*) from yh where name='" + name + "'and pass='" + pass + "'");
            if (a == 1)
            {
                if (checkBox1.Checked)
                {
                    int n = db.Exitsql("insert into jzyh  values ('" + name + "','')");
                }
                if (checkBox2.Checked)
                {
                    int pa = db.Exitsql("update jzyh set pass='" + pass + "' where pass =''and name='" + name + "'");
                }
                Form2 mf = new Form2(name);
                mf.Show();
                this.Hide();
            }
            else if (a == 2)
            {
                MessageBox.Show("用户名或秘密错误！！");
            }
            else
            {
                MessageBox.Show("数据库操作错误！！");
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 mf = new Form7(this);
            mf.Show();
            this.Hide();

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            /*string name = textBox1.Text;
            string pass = textBox2.Text;
            DB db = new DB();
            int a = db.Exitsql("update jzyh set pass='"+pass+"' where pass =''and name='"+name+"'");
            if (a == 1)
            { 
                
            }
            else if (a == 0)
            {
                MessageBox.Show("请先记住用户名");
            }*/
        }

        private void checkBox1_KeyDown(object sender, KeyEventArgs e)
        {
            /*string name = textBox1.Text;

            DB db = new DB();
            int a = db.Exitsql("insert into jzyh  values ('" + name + "','')");
            if (a == 1)
            {
                MessageBox.Show("111");
            }*/
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (this.checkBox1.Checked)
            {
                this.checkBox2.Enabled = true;
             

            }
            else
            {
                this.checkBox2.Enabled = false;
                this.checkBox2.Checked = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          /*  DB db = new DB();
            string sql = string.Format("select * from jzyh");
            DataSet da = new DataSet();
            da = db.Getdataset(sql);
            comboBox1.DataSource = da.Tables[0];
            comboBox1.DisplayMember = "name";*/
            DB db = new DB();
            SqlDataReader rs = db.Exitselect("select name from yh");

            while (rs.Read())//一行一行的读取
            {
                comboBox1.Items.Add(rs.GetString(0));//写入下拉列表中
            }    
                
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB db = new DB();
            string name = comboBox1.Text;
            string sql = string.Format("select * from yh where name='"+name+"'");
            //int a = db.DataSet("select count(*) from yh where name = '"+name+"'");
            //if(a==2)
            //{
               // textBox2.Text = "";
           // }
            DataSet da = new DataSet();
            da=db.Getdataset(sql);           
            textBox2.Text = da.Tables[0].Rows[0][2].ToString();
            
            int b= db.DataSet("select count(*) from yh where name = '" + name + "'");
            if (b == 2)
            {
                textBox2.Text = null;
            }
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                textBox2.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DB db = new DB();
            string name = textBox2.Text;
           // int a = db.DataSet("select count(*) from yh where name = '" + name + "'");
           // if (a == 2)
           // {
               // textBox2.Text = "";
           // }
        }


    }
}
