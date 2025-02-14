using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop
{
    class DbHelper
    {
        Connection conn = new Connection();

        public int Insert(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = conn.GetConnection();
            conn.OpenConn();
            var res = cmd.ExecuteNonQuery();
            conn.CloseConn();
            return res;
        }

        public int InsertCmd(SqlCommand cmd)
        {
            cmd.Connection = conn.GetConnection();
            conn.OpenConn();
            var res = cmd.ExecuteNonQuery();
            conn.CloseConn();
            return res;
        }

        public DataTable GetTable(string query)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = conn.GetConnection();
            conn.OpenConn();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            conn.CloseConn();
            return dt;
        }
        public DataTable GetTableCmd(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            cmd.Connection = conn.GetConnection();
            conn.OpenConn();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            conn.CloseConn();
            return dt;
        }
    }
}
