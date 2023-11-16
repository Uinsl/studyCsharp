using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace bookMS
{
    internal class Dao
    {
        // mysql数据库
        public MySqlConnection connect;
        public MySqlConnection sqlConnect() 
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();

            builder.Server = "127.0.0.1"; //ip地址
            builder.Port = 3306;
            builder.UserID = "root";
            builder.Password = "root";
            builder.Database = "test"; //数据库名字

            connect = new MySqlConnection(builder.ConnectionString);
            connect.Open();

            return connect;
        }

        public MySqlCommand command(string sql) 
        {
            MySqlCommand cmd = new MySqlCommand(sql, sqlConnect());

            return cmd;
        }

        public int Eexcute(string sql) //更新
        {
            return command(sql).ExecuteNonQuery();
        }


        public MySqlDataReader read(string sql) //读取
        {

            return command(sql).ExecuteReader();
        }

        public void DaoClose() 
        {
            connect.Close();
        }


    }
}
