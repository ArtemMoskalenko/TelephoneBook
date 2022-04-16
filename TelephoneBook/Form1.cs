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

namespace TelephoneBook
{
    public partial class Form1 : Form
    {
        DataBase dataBase = new DataBase();
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Clear()
        {
            textBoxFirstName.Text = " ";
            textBoxLastName.Text = " ";
            textBoxPhone.Text = " ";
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            textBoxFirstName.MaxLength = 20;
            textBoxLastName.MaxLength = 20;
            textBoxPhone.MaxLength = 15;

            string _regional = comboBox1.Text;
            string _firsName = textBoxFirstName.Text;
            string _lastName = textBoxLastName.Text;
            int  _phoneBook = Convert.ToInt32(textBoxPhone.Text);

            string qerystring = $"Insert Into  Book(FirstName,LastName,InternationalCountryCode,Telephone) values('{_firsName}','{_lastName}','{_regional}','{_phoneBook}')"; 
            SqlCommand Command = new SqlCommand(qerystring, dataBase.GetConnection());
            dataBase.OpenConnection();
           

            
             if (Chechet()== true)
            {

            }
            
            else if (Chechet()== false)
            {
                 if (Command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Данные успешно добавлены!");
                }
                else
                {
                    MessageBox.Show("Операция не выполнена попробуйте еще раз!");
                }
            }
            

            dataBase.CloseConnection();
            Clear();
        }

        private Boolean Chechet()
        {
            var phone = Convert.ToInt32(textBoxPhone.Text);


            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();
            string qerystring = $"Select Telephone from Book where Telephone= '{phone}'";


            SqlCommand command = new SqlCommand(qerystring, dataBase.GetConnection());


            adapter.SelectCommand = command;
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                MessageBox.Show("Такой номер телефона уже существует!");
                return true;
            }
            else
            {
                return false;
            }
        }

        

        

        private void tabControl1_Click(object sender, EventArgs e)
        {
           
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
