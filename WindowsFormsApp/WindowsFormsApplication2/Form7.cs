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
    public partial class Form7 : Form
    {
        Form main;
        private Form1 form1;

        //public Form7(Form1 form1)
        //{
        //     TODO: Complete member initialization
        //    this.form1 = form1;
        //}
       public Form7(Form a)
        {
            InitializeComponent();
            main = a;
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string pass = textBox2.Text;
            string pass1=textBox3.Text;

            if (name == "")
            {
                MessageBox.Show("用户名不能为空！！");
                return;
            }
            if (pass == "")
            {
                MessageBox.Show("密码不能为空！！");
                return;
            }
            if (pass1 == "")
            {
                MessageBox.Show("确认密码不能为空！！");
                return;
            }
            if (pass != pass1)
            {               
               MessageBox.Show("密码不一致！！");
               return;
            }
            DB db = new DB();
            
            int b = db.DataSet("select COUNT(*) from yh where name='" + name + "'");
            if (b == 2)
            { 
                int a = db.Exitsql("insert into yh values('" + name + "','" + pass + "')");
                if (a > 0)
                {
                    MessageBox.Show("注册成功！！");
                }
                else
                {
                    MessageBox.Show("注册失败！！");
                }
                db.Close();
                Close();
            }
            else if (b == 1)
            {
                MessageBox.Show("用户名重复！！");
            }
           
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
