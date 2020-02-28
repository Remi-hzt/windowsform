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
    public partial class Form9 : Form
    {
        
        Form main;
        string kh = null;
        string jsh = null;
        public Form9(Form a)
        {
            InitializeComponent();
            main = a;
        }
        public Form9(Form a,string kh,string jsh)
        {
            InitializeComponent();
            this.kh = kh;
            this.jsh = jsh;
            main = a;
        }
        private void Form9_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            if (kh == null && jsh == null)
            {
                DataSet kcm = db.Getdataset("select * from 课程表");
                comboBox1.DataSource = kcm.Tables[0];
                comboBox1.DisplayMember = "课程号";
                DataSet sk = db.Getdataset("select * from class_room");
                comboBox2.DataSource = sk.Tables[0];
                comboBox2.DisplayMember = "开课地点";
            }
            else
            {
                y();
            }
        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            main.Show(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            try
            {
                string teacher = textBox1.Text;
                string kch = comboBox1.Text;
                string date = dateTimePicker1.Text;
                string skd = comboBox2.Text;
                if(teacher!=""&&kch!="" && date!=null && skd!="")
               {
                    int tea = db.DataSet("select count(*) from 教师表 where 教师号='" + teacher + "';");
                    if (tea==1)
                    {
                        int a = db.Exitsql("insert into 授课表 values('" + teacher + "','" + kch + "','" + date + "','" + skd + "');");
                        if (a > 0)
                        {
                            MessageBox.Show("新建成功！！");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("新建失败，请检测是否已经授课！！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("教师号不存在，请重新输入！");
                    }
                }
                else
                {
                    MessageBox.Show("请填写完整！！！");
                }
            }
            catch
            {
                MessageBox.Show("新建失败！！");
            }

        }
        private void y()
        {

            DB a = new DB();
            string sql = string.Format("select * from 授课表 where 课程号='" + kh + "' and 教师号='"+jsh+"'");
            DataSet ds = new DataSet();
            ds = a.Getdataset(sql);
            string sql2 = string.Format("select * from 课程表");
            DataSet ds2 = new DataSet();
            ds2= a.Getdataset(sql2);
            
            comboBox1.DataSource = ds2.Tables[0];
            comboBox1.DisplayMember = "课程号";
            comboBox1.SelectedIndex = 1;
            string sql3 = string.Format("select * from 授课表");
            DataSet ds3 = new DataSet();
            ds3 = a.Getdataset(sql3);
            comboBox2.DataSource = ds3.Tables[0];
            comboBox2.DisplayMember = "开课地点";
            comboBox2.SelectedIndex = 1;
            comboBox1.Text = ds.Tables[0].Rows[0][1].ToString();
            textBox1.Text = ds.Tables[0].Rows[0][0].ToString();            
            dateTimePicker1.Text = ds.Tables[0].Rows[0][2].ToString();
            comboBox2.Text = ds.Tables[0].Rows[0][3].ToString();
        }
    }
}
