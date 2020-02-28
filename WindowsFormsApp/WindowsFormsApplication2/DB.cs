using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    class DB
    {
        SqlConnection conn = null;
        string constr = "Data Source=ip地址;Initial Catalog=数据库名;User ID=用户名;Password=密码";

        public bool Open()
        {
            if (conn == null)
            {
                conn = new SqlConnection(constr);
                try
                {
                    conn.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }



        public bool Close()
        {
            if (conn != null)
            {
                try
                {
                    conn.Close();
                    conn = null;
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }


        public int Exitsql(string sql)
        {
            int a = 0;
            if (Open())
            {
               
                try
                {
              
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    a = cmd.ExecuteNonQuery();
                    
                }
                catch
                {
                    a = -1;
                    
                }
                finally
                {
                    Close();
                }
            }
            return a;
        }


        public SqlDataReader Exitselect(string sql)
        {
            SqlDataReader rs = null;
            if (Open())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    rs = cmd.ExecuteReader();
                    return rs;
                }
                catch
                {
                    return null;
                }
                
            }
            return null;
        }


        public int DataSet(string sql)
        {
            int a = 0;
            if (Open())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader ra = cmd.ExecuteReader();
                    if (ra.Read())
                    {
                        if (ra.GetInt32(0) > 0)
                        {
                            a = 1;
                        }
                        else
                        {
                            a = 2;
                        }
                    }
                    else
                    {
                        a = -1;
                    }
                }
                catch
                {
                    a = -1;
                }
                finally
                {
                    Close();
                }

            }
            return a;
        }


        public DataSet Getdataset(string sql)
        {
            if (Open())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);//sql是数据库命令，conn是数据库中那个库
                    SqlDataAdapter da = new SqlDataAdapter(cmd);//从数据库中获取一张表格
                    DataSet ds = new DataSet();//创建微型数据
                    da.Fill(ds);//微型数据库里面的内容等于查询到的表
                    da.Dispose();//释放资源
                    Close();
                    return ds;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    Close();
                }
            }
            return null;
        }
        public string aa(string sql)
        {
            if (Open())
            {
                try
                {
                    
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    string a = cmd.ExecuteScalar().ToString();
                    return a;
                }
                catch
                {
                    return "";
                }
            }
            return "";
        }
    }

}
