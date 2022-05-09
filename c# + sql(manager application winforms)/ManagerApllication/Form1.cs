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

namespace ManagerApllication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        
        


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet_manager1.Payment". При необходимости она может быть перемещена или удалена.
            this.paymentTableAdapter.Fill(this.dataSet_manager1.Payment);

            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet_manager1.Prepayment". При необходимости она может быть перемещена или удалена.
            this.prepaymentTableAdapter.Fill(this.dataSet_manager1.Prepayment);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet_manager1.Orders". При необходимости она может быть перемещена или удалена.
            this.ordersTableAdapter.Fill(this.dataSet_manager1.Orders);

        }      

        private void button1_Click(object sender, EventArgs e)
        {
            
            string connectionString = @"Data Source=DESKTOP-Q70ER6J;Initial Catalog=manager;Integrated Security=True";
            string sum = textBox1.Text;  
            string sqlExpression = "INSERT INTO Orders (summ) VALUES (@sum)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlParameter summParam = new SqlParameter("@sum", sum);

                    command.Parameters.Add(summParam);

                    command.ExecuteNonQuery();
                    connection.Close();
                    ordersTableAdapter.Fill(dataSet_manager1.Orders);
                    MessageBox.Show("Добавлен заказ на сумму: " + sum);
                }
                catch
                {
                    MessageBox.Show("Введите число");
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string connectionString = @"Data Source=DESKTOP-Q70ER6J;Initial Catalog=manager;Integrated Security=True";
            string sum = textBox2.Text;


            string sqlExpression = "INSERT INTO Prepayment (summ) VALUES (@sum)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlParameter summParam = new SqlParameter("@sum", sum);

                    command.Parameters.Add(summParam);
                    command.ExecuteNonQuery();
                    connection.Close();
                    prepaymentTableAdapter.Fill(dataSet_manager1.Prepayment);
                    MessageBox.Show("Добавлен аванс на сумму: " + sum);                  
                }
                catch
                {
                    MessageBox.Show("Введите число");
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-Q70ER6J;Initial Catalog=manager;Integrated Security=True";
            string orderid = textBox3.Text;
            string payid = textBox4.Text;
            string sum = textBox5.Text;


            string sqlExpression = "INSERT INTO Payment (order_id,prepayment_id,payment_sum) VALUES (@orderid,@payid,@sum);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlParameter summParam = new SqlParameter("@orderid", orderid);
                    SqlParameter summParam2 = new SqlParameter("@payid", payid);
                    SqlParameter summParam3 = new SqlParameter("@sum", sum);

                    command.Parameters.Add(summParam);
                    command.Parameters.Add(summParam2);
                    command.Parameters.Add(summParam3);
                    command.ExecuteNonQuery();
                    connection.Close();
                    ordersTableAdapter.Fill(dataSet_manager1.Orders);
                    prepaymentTableAdapter.Fill(dataSet_manager1.Prepayment);
                    paymentTableAdapter.Fill(dataSet_manager1.Payment);
                    MessageBox.Show("Добавлен заказ на сумму: " + sum);
                }
                catch
                {
                    MessageBox.Show("Введите число или верные индексы");
                }
                

            }
        }
    }
}
