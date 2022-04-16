using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneBook
{
    class DataBase
    {
        SqlConnection SQLconnection = new SqlConnection(@"Data Source=ARTEM-PC\SQLEXPRESS; Initial Catalog= TelephoneBook; Integrated Security=True");
        public void OpenConnection()
        {
            if (SQLconnection.State == System.Data.ConnectionState.Closed)
            
                SQLconnection.Open();
            
        }

        public void CloseConnection()
        {
            if (SQLconnection.State == System.Data.ConnectionState.Open)

                SQLconnection.Close();

        }
        public SqlConnection GetConnection()
        {
            return SQLconnection;
        }
    }
}
