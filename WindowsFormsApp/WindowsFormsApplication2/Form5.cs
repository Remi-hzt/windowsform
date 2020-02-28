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
    public partial class Form5 : Form
    {

        DB db = new DB();
        Form main;
        public Form5(Form a)
        {
            InitializeComponent();
            main=a;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

          
                DataSet b = db.Getdataset("select * from 学生表 ");
                comboBox3.DataSource = b.Tables[0];
                comboBox3.DisplayMember = "学号";
                db.Close();
                  

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //获取用户输入的学号
            string xh = comboBox3.Text;
           
            /*构造查询语句，查询某学号同学的已选课程，逐行读取数据，显示在文本框中
            DB db =new DB();
            
            SqlDataReader  a = db.Exitselect("select distinct 课名 from 选课表 join 课程表 on 选课表.课程号=课程表.课程号 where 学号='" + xh + "'");

            while (a.Read())
            {
               textBox3.Text += a.GetString(0)+Environment.NewLine;
            }
            db.Close();*/

            ////////////////////////////
         
            dataGridView1.DataSource = db.Getdataset("select distinct 课名 from 选课表 join 课程表 on 选课表.课程号=课程表.课程号 where 学号='" + xh + "'").Tables[0];
            
            //显示可选课程
            DataSet b = db.Getdataset("select * from 课程表 where 课程号 not in (select 课程号 from 选课表 where 学号='"+xh+"')");
            comboBox2.DataSource = b.Tables[0];
            comboBox2.DisplayMember = "课名";
            db.Close();

        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //获取用户输入的学号
            string xh = comboBox3.Text;

            /*构造查询语句，查询某学号同学的已选课程，逐行读取数据，显示在文本框中
            DB db =new DB();
            
            SqlDataReader  a = db.Exitselect("select distinct 课名 from 选课表 join 课程表 on 选课表.课程号=课程表.课程号 where 学号='" + xh + "'");

            while (a.Read())
            {
               textBox3.Text += a.GetString(0)+Environment.NewLine;
            }
            db.Close();*/

            ////////////////////////////

            dataGridView1.DataSource = db.Getdataset("select distinct 课名 from 选课表 join 课程表 on 选课表.课程号=课程表.课程号 where 学号='" + xh + "'").Tables[0];

            //显示可选课程
            DataSet b = db.Getdataset("select * from 课程表 where 课程号 not in (select 课程号 from 选课表 where 学号='" + xh + "')");
            comboBox2.DataSource = b.Tables[0];
            comboBox2.DisplayMember = "课名";
            db.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string xh = comboBox3.Text;
            string km = comboBox2.Text;
            string jsmc = comboBox1.Text;
            string kch = db.aa("select 课程号 from 课程表 where 课名 = '"+km+"';");
            string jsh = db.aa("select 教师号 from 教师表 where 姓名='" + jsmc + "';");
            int a = db.Exitsql("insert into 选课表 (学号,教师号,课程号) values ('"+xh+"', '"+jsh+"','"+kch+"');");
            if (a > 0)
            {
                MessageBox.Show("选课成功！");
            }
            dataGridView1.DataSource = db.Getdataset("select distinct 课名 from 选课表 join 课程表 on 选课表.课程号=课程表.课程号 where 学号='" + xh + "'").Tables[0];
            DataSet b = db.Getdataset("select * from 课程表 where 课程号 not in (select 课程号 from 选课表 where 学号='"+xh+"' and 教师号 ='"+jsh+"' );");
            comboBox2.DataSource = b.Tables[0];
            comboBox2.DisplayMember = "课名";
            db.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string xh = comboBox3.Text;
            int a = dataGridView1.CurrentRow.Index;
            string b= dataGridView1.Rows[a].Cells[0].Value.ToString();
            string jsh = db.aa("select distinct 教师号 from 选课表 where 教师号 in(select 教师号 from 教师表 where 姓名='周元胜  ');");
            string kcm = db.aa("select 课程号 from 课程表 where 课名='" + b + "'");
            string sql = string.Format("delete 选课表 where 学号='{0}' and 课程号='{1}'  and 教师号='{2}';", comboBox3.Text,kcm,jsh);
            if (db.Exitsql(sql) > 0)
            {
                MessageBox.Show("已经取消了" + b + "课程");
                dataGridView1.DataSource = db.Getdataset("select distinct 课名 from 选课表 join 课程表 on 选课表.课程号=课程表.课程号 where 学号='" + xh + "'").Tables[0];
                DataSet c = db.Getdataset("select * from 课程表 where 课程号 not in (select 课程号 from 选课表 where 学号='" + xh + "' and 教师号 ='" + jsh + "' );");
                comboBox2.DataSource =c.Tables[0];
                comboBox2.DisplayMember = "课名";
               
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取用户输入的学号
            string kcm = comboBox2.Text;

            /*构造查询语句，查询某学号同学的已选课程，逐行读取数据，显示在文本框中
            DB db =new DB();
            
            SqlDataReader  a = db.Exitselect("select distinct 课名 from 选课表 join 课程表 on 选课表.课程号=课程表.课程号 where 学号='" + xh + "'");

            while (a.Read())
            {
               textBox3.Text += a.GetString(0)+Environment.NewLine;
            }
            db.Close();*/

            ////////////////////////////

          

            //显示可选课程
            DataSet b = db.Getdataset("select * from 教师表 where 教师号 in (select 教师号 from 授课表 where 课程号 in (select 课程号 from 课程表 where 课名='"+kcm+"'));");
            comboBox1.DataSource = b.Tables[0];
            comboBox1.DisplayMember = "姓名";
            db.Close();
        }
    }
}
