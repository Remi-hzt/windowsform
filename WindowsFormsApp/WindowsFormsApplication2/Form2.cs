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
    public partial class Form2 : Form
    {
        string loguser = null;
        private Form5 form5;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(string name)
        {
            InitializeComponent();
            loguser = name;
        }

        public Form2(Form5 form5)
        {
            //// TODO: Complete member initialization
            //this.form5 = form5;
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否关闭", "注意", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.FormClosing -= new FormClosingEventHandler(Form2_FormClosing);
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "欢迎光临:" + loguser;
            this.toolStripStatusLabel2.Text = "今天是：" + DateTime.Now.ToLongDateString();
            aa();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel3.Text = DateTime.Now.ToLongTimeString();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB db = new DB();
            if (tabControl1.SelectedIndex == 0)
            {
                DataSet a = db.Getdataset("select * from 学生表 ");
                dataGridView1.DataSource = a.Tables[0];
            }

            else if (tabControl1.SelectedIndex == 1)
            {
                DataSet b = db.Getdataset("select 姓名,C.教师号,部门名称,联系方式,职称 from 教师表 C  join 部门表 D on  C.部门编号=D.部门编号 ");
                dataGridView2.DataSource = b.Tables[0];

            }

            else if (tabControl1.SelectedIndex == 2)
            {
                DataSet c = db.Getdataset("select * from 课程表");
                dataGridView3.DataSource = c.Tables[0];
            }
            else if (tabControl1.SelectedIndex == 3)
            {

                DataSet d = db.Getdataset("select 学生表.姓名 as 学生姓名,专业,学生表.学号,选课表.课程号,课名,学时,学分,成绩,教师表.教师号,教师表.姓名 as 教师姓名 from 选课表 join 学生表 on 选课表.学号= 学生表.学号 join 课程表 on 选课表.课程号=课程表.课程号 join 授课表 on 授课表.课程号=选课表.课程号 join 教师表 on 授课表.教师号=教师表.教师号");
                dataGridView4.DataSource = d.Tables[0];

            }
            else
            {

                DataSet a = db.Getdataset("select a.教师号,a.姓名,b.课程号,c.课名,b.开课时间,b.开课地点 from 教师表 as a join 授课表 as b on a.教师号=b.教师号 join 课程表 as c on b.课程号=c.课程号;");
                if (a != null)
                {
                    dataGridView5.DataSource = a.Tables[0];
                }

            }
        }

        private void 新建学生档案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 mf = new Form3(this);
            mf.Show();
            this.Hide();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.RowIndex, y = e.ColumnIndex;
            string xh = dataGridView1.Rows[x].Cells["学号"].Value.ToString();
            DB db = new DB();
            //点击删除是删除相应信息
            if ((dataGridView1.Rows[x].Cells[y].Value) == "删除")
            {
                int b = db.Exitsql("delete from 学生表 where 学号='" + xh + "'");
                if (b > 0)
                {
                    MessageBox.Show("删除成功！！");
                }
                else if (b == -1)
                {
                    MessageBox.Show("删除失败！!");
                }
                else
                {
                    MessageBox.Show("数据库操作失败！！");
                }
            }


            //点击修改是弹出修改框
            if ((dataGridView1.Rows[x].Cells[y].Value) == "修改")
            {
                Form3 mf = new Form3(this,xh);
                mf.Show();
            }
            DataSet a = db.Getdataset("select * from 学生表 ");
            dataGridView1.DataSource = a.Tables[0];
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.RowIndex, y = e.ColumnIndex;
            string jh = dataGridView2.Rows[x].Cells["教师号"].Value.ToString();
            DB db = new DB();


            if (dataGridView2.Rows[x].Cells[y].Value == "删除")
            {
                int b = db.Exitsql("delete from 教师表 where 教师号='" + jh + "'");
                if (b > 0)
                {
                    MessageBox.Show("删除成功");
                    aa();

                }
                else if (b == -1)
                {
                    MessageBox.Show("删除失败");
                }
                else
                {
                    MessageBox.Show("数据库操作失败");
                }
            }


            if (dataGridView2.Rows[x].Cells[y].Value == "修改")
            {
                Form4 mf = new Form4(this,jh);
                mf.Show();

                aa();
            }


            DataSet a = db.Getdataset("select 姓名,C.教师号,部门名称,联系方式,职称 from 教师表 C  join 部门表 D on  C.部门编号=D.部门编号 ");
            dataGridView1.DataSource = a.Tables[0];
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DB db = new DB();
            DataSet a = db.Getdataset("select * from 课程表 where 课程号 not in (select distinct 课程号 from 选课表)");
            if (a != null)
            {
                dataGridView3.DataSource = a.Tables[0];

            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DB db = new DB();
            DataSet a = db.Getdataset("select distinct 选课表.课程号, 课名,学时,学分 from 课程表 join 选课表 on 课程表.课程号=选课表.课程号");
            if (a != null)
            {
                dataGridView3.DataSource = a.Tables[0];

            }
        }

        private void 学生选课ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 mf = new Form5(this);
            mf.Show();
            this.Hide();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DB db = new DB();
            int x = e.RowIndex, y = e.ColumnIndex;
            string kh = dataGridView3.Rows[x].Cells["课程号"].Value.ToString();


            if (dataGridView3.Rows[x].Cells[y].Value == "删除")
            {
                int a = db.Exitsql("delete from 课程表 where 课程号 ='" + kh + "'");
                if (a > 0)
                {
                    MessageBox.Show("删除成功！！");

                }
                else if (a == -1)
                {
                    MessageBox.Show("删除失败");
                }
                else
                {
                    MessageBox.Show("数据库操作失败");
                }
            }


            if (dataGridView3.Rows[x].Cells[y].Value == "修改")
            {
                Form8 mf = new Form8(this,kh);
                mf.Show();
                this.Hide();
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 新建教师档案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 mf = new Form4(this);
            mf.Show();
            this.Hide();
        
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DB db = new DB();
            int x = e.RowIndex, y = e.ColumnIndex;
            string xh = dataGridView4.Rows[x].Cells["学号"].Value.ToString();
            string kch = dataGridView4.Rows[x].Cells["课程号"].Value.ToString();
            string jsxm = dataGridView4.Rows[x].Cells["教师姓名"].Value.ToString();
            if (dataGridView4.Rows[x].Cells[y].Value == "删除")
            {
                int b = db.Exitsql("delete from 选课表 where 学号='" + xh + "'and 课程号='" + kch + "'");
                if (b > 0)
                {
                    MessageBox.Show("删除成功！");
                }
            }
            DataSet a = db.Getdataset("select 学生表.姓名 as 学生姓名,专业,学生表.学号,选课表.课程号,课名,学时,学分,成绩,教师表.姓名 as 教师姓名 from 选课表 join 学生表 on 选课表.学号= 学生表.学号 join 课程表 on 选课表.课程号=课程表.课程号 join 授课表 on 授课表.课程号=选课表.课程号 join 教师表 on 授课表.教师号=教师表.教师号");
            
          
            if (a != null)
            {
                dataGridView4.DataSource = a.Tables[0];

            }
        }

        private void linkLabel3_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DB db = new DB();
            DataSet a = db.Getdataset("select 学生表.姓名 as 学生姓名,专业,学生表.学号,选课表.课程号,课名,学时,学分,成绩,教师表.姓名 as 教师姓名 from 选课表 join 学生表 on 选课表.学号= 学生表.学号 join 课程表 on 选课表.课程号=课程表.课程号 join 授课表 on 授课表.课程号=选课表.课程号 join 教师表 on 授课表.教师号=教师表.教师号 order by 选课表.课程号");
            if (a != null)
            {
                dataGridView4.DataSource = a.Tables[0];

            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DB db = new DB();
            DataSet a = db.Getdataset("select 学生表.姓名 as 学生姓名,专业,学生表.学号,选课表.课程号,课名,学时,学分,成绩,教师表.姓名 as 教师姓名 from 选课表 join 学生表 on 选课表.学号= 学生表.学号 join 课程表 on 选课表.课程号=课程表.课程号 join 授课表 on 授课表.课程号=选课表.课程号 join 教师表 on 授课表.教师号=教师表.教师号 order by 选课表.学号");
            if (a != null)
            {
                dataGridView4.DataSource = a.Tables[0];

            }
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DB db = new DB();
            DataSet a = db.Getdataset("select a.课程号,a.课名,b.教师号,c.姓名,c.联系方式,b.开课地点,b.开课时间 from 课程表 as a ,授课表 as b ,教师表 as c;");
            if (a != null)
            {
                dataGridView5.DataSource = a.Tables[0];

            }
        }

        private void 新建课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 mf = new Form8(this);
            mf.Show();
            this.Hide();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void aa()
        {
            DB db = new DB();
            if (tabControl1.SelectedIndex == 0)
            {
                DataSet a = db.Getdataset("select * from 学生表 ");
                dataGridView1.DataSource = a.Tables[0];
            }

            else if (tabControl1.SelectedIndex == 1)
            {
                DataSet b = db.Getdataset("select 姓名,C.教师号,部门名称,联系方式,职称 from 教师表 C  join 部门表 D on  C.部门编号=D.部门编号");
                dataGridView2.DataSource = b.Tables[0];

            }

            else if (tabControl1.SelectedIndex == 2)
            {
                DataSet c = db.Getdataset("select * from 课程表");
                dataGridView3.DataSource = c.Tables[0];
            }
            else if (tabControl1.SelectedIndex == 3)
            {

                DataSet d = db.Getdataset("select 学生表.姓名 as 学生姓名,专业,学生表.学号,选课表.课程号,课名,学时,学分,成绩,教师表.姓名 as 教师姓名 from 选课表 join 学生表 on 选课表.学号= 学生表.学号 join 课程表 on 选课表.课程号=课程表.课程号 join 授课表 on 授课表.课程号=选课表.课程号 join 教师表 on 授课表.教师号=教师表.教师号");
                dataGridView4.DataSource = d.Tables[0];

            }
            else
            {
               
                DataSet a = db.Getdataset("select a.教师号,a.姓名,b.课程号,c.课名,b.开课时间,b.开课地点 from 教师表 as a join 授课表 as b on a.教师号=b.教师号 join 课程表 as c on b.课程号=c.课程号;");
                if (a != null)
                {
                    dataGridView5.DataSource = a.Tables[0];
                }

            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {    if (int.Parse(textBox1.Text) > 0)
                {
                    int search = int.Parse(textBox1.Text);
                    DB db = new DB();
                    DataSet stusea = db.Getdataset("select * from 学生表 where 学号 like '%" + search + "%';");
                    dataGridView1.DataSource = stusea.Tables[0];
                }
                
            }
            catch
            {

                string search = textBox1.Text;
                DB db = new DB();
                DataSet stusea = db.Getdataset("select * from 学生表 where 姓名 like '%" + search + "%';");
                dataGridView1.DataSource = stusea.Tables[0];
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        { 
            textBox2.Font = new Font("宋体", 9f);
            textBox2.ForeColor = Color.Black;
            textBox2.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DB db = new DB();
                string search = textBox2.Text;
                if (search[0] == 'j'||(search[0]>=48&&search[0]<=57))
                {

                    DataSet teasea = db.Getdataset("select * from 教师表 where 教师号 like '%" + search + "%' ;");
                    dataGridView2.DataSource = teasea.Tables[0];
                }
                else
                {
                    DataSet teasea = db.Getdataset("select * from 教师表 where 姓名 like '%" + search + "%' ;");
                    dataGridView2.DataSource = teasea.Tables[0];
                }
            }
            catch
            {


            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Font = new Font("宋体", 9f);
            textBox1.ForeColor = Color.Black;
            textBox1.Text = "";
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Font = new Font("宋体", 9f);
            textBox3.ForeColor = Color.Black;
            textBox3.Text = "";
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Font = new Font("宋体", 9f);
            textBox4.ForeColor = Color.Black;
            textBox4.Text = "";
        }
     
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DB db = new DB();
                string search = textBox3.Text;
                if (int.Parse(textBox3.Text) > 0)
                {

                    DataSet kcsea = db.Getdataset("select * from 课程表 where 课程号 like '%" + search + "%' ;");
                    dataGridView3.DataSource = kcsea.Tables[0];
                }
                else
                {
                    DataSet kcsea = db.Getdataset("select * from 课程表 where 课名 like '%" + search + "%' ;");
                    dataGridView3.DataSource = kcsea.Tables[0];
                }
            }
            catch
            {


            }
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DB db = new DB();
            int x = e.RowIndex, y = e.ColumnIndex;
            string jsh = dataGridView5.Rows[x].Cells["教师号"].Value.ToString();
            string kh = dataGridView5.Rows[x].Cells["课程号"].Value.ToString();

            if (dataGridView5.Rows[x].Cells[y].Value == "删除")
            {
                int a = db.Exitsql("delete from 授课表 where 课程号 ='" + kh + "' and 教师号='"+jsh+"';");
                if (a > 0)
                {
                    MessageBox.Show("删除成功！！");

                }
                else if (a == -1)
                {
                    MessageBox.Show("删除失败");
                }
                else
                {
                    MessageBox.Show("数据库操作失败");
                }
            }


            if (dataGridView5.Rows[x].Cells[y].Value == "修改")
            {
                Form9 mf = new Form9(this,kh,jsh);
                mf.Show();
                this.Hide();
            }
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void 教师授课ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 mf = new Form9(this);
            mf.Show();
            this.Hide();

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DB db = new DB();
                string search = textBox4.Text;
                if (int.Parse(textBox4.Text) > 0)
                {

                    DataSet xksea = db.Getdataset("select 学生表.姓名 as 学生姓名,专业,学生表.学号,选课表.课程号,课名,学时,学分,成绩,教师表.姓名 as 教师姓名 from 选课表 join 学生表 on 选课表.学号= 学生表.学号 join 课程表 on 选课表.课程号=课程表.课程号 join 授课表 on 授课表.课程号=选课表.课程号 join 教师表 on 授课表.教师号=教师表.教师号 where 学生表.学号 like '%" + search + "%' or 课程表.课程号 like '%" + search+"%'");
                    dataGridView4.DataSource = xksea.Tables[0];
                }
                else
                {
                    DataSet xksea = db.Getdataset("select 学生表.姓名 as 学生姓名,专业,学生表.学号,选课表.课程号,课名,学时,学分,成绩,教师表.姓名 as 教师姓名 from 选课表 join 学生表 on 选课表.学号= 学生表.学号 join 课程表 on 选课表.课程号=课程表.课程号 join 授课表 on 授课表.课程号=选课表.课程号 join 教师表 on 授课表.教师号=教师表.教师号 where 学生表.姓名 like '%" + search + "%' or 课程表.课名 like '%" + search + "%'");
                    dataGridView4.DataSource = xksea.Tables[0];
                }
            }
            catch
            {


            }
        }

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DB db = new DB();
                string search = textBox5.Text;
                if (search[0] == 'j' || (search[0] >= 48 && search[0] <= 57))
                {

                    DataSet sksea = db.Getdataset("select a.教师号,a.姓名,b.课程号,c.课名,b.开课时间,b.开课地点 from 教师表 as a join 授课表 as b on a.教师号=b.教师号 join 课程表 as c on b.课程号=c.课程号 where a.教师号 like '%"+search+"%' or b.课程号 like '%"+search+"%'");
                    dataGridView5.DataSource = sksea.Tables[0];
                }
                else
                {
                    DataSet sksea = db.Getdataset("select a.教师号,a.姓名,b.课程号,c.课名,b.开课时间,b.开课地点 from 教师表 as a join 授课表 as b on a.教师号=b.教师号 join 课程表 as c on b.课程号=c.课程号 where a.姓名 like '%" + search + "%' or b.课名 like '%" + search + "%'");
                    dataGridView5.DataSource = sksea.Tables[0];
                }
            }
            catch
            {


            }
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            
                textBox5.Font = new Font("宋体", 9f);
                textBox5.ForeColor = Color.Black;
                textBox5.Text = "";
           
        }
    }

  
}
