using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelephoneBook
{
    public partial class Form2 : Form
    {
        DataBase dataBase = new DataBase();
        public Form2()
        {
            InitializeComponent();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
           
            form1.Show();
            this.Hide();
        }
        private void LoadData()
        {
            SqlConnection SQLconnection = new SqlConnection(@"Data Source=ARTEM-PC\SQLEXPRESS; Initial Catalog= TelephoneBook; Integrated Security=True");
            dataBase.OpenConnection();


            string qery = "Select * From Book Order by id";
            SqlCommand command = new SqlCommand(qery, dataBase.GetConnection());

            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();


            while (reader.Read())
            {
                data.Add(new string[5]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
            }
            reader.Close();
            dataBase.CloseConnection();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
