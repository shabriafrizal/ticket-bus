using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop
{
    class Connection
    {
        public SqlConnection cnn;

        public Connection()
        {
            string connString = @"data source=. ; initial catalog=DB_TICKET ; integrated security=true";
            cnn = new SqlConnection(connString);
        }

        public SqlConnection GetConnection()
        {
            return cnn;
        }

        public void OpenConn()
        {
            if (cnn.State == System.Data.ConnectionState.Closed)
            {
                cnn.Open();
            }
        }

        public void CloseConn()
        {
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                cnn.Close();
            }
        }

    }
}
