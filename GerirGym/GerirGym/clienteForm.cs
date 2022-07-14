using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
#nullable disable

namespace GerirGym
{
    public partial class clienteForm : Form
    {
        public clienteForm()
        {
            InitializeComponent();
        }

        public MySqlConnection connection;
        public MySqlDataReader reader;
        public MySqlCommand command;
        public MySqlDataAdapter adapter;
        string sql;

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 back = new Form1();
            back.Show();
        }

        private void btn_inserir_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");

                sql = "UPDATE cliente SET peso = @peso, altura = @altura WHERE ID = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", tb_idcliente.Text);
                command.Parameters.AddWithValue("@peso", tb_peso.Text);
                command.Parameters.AddWithValue("@altura", tb_altura.Text);

                connection.Open();

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show(" Dados inseridos! ", "Mensage do sistema ");
                connection.Close();
                connection = new MySqlConnection(null);
                command = new MySqlCommand(null);
            }

            try
            {
                connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");

                sql = "Select * from plano_treino WHERE id_cliente = @id";

                command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", tb_idcliente.Text);

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lbl_ex1.Text = Convert.ToString(reader["ex1"]);
                    lbl_ex2.Text = Convert.ToString(reader["ex2"]);
                    lbl_ex3.Text = Convert.ToString(reader["ex3"]);
                    lbl_ex4.Text = Convert.ToString(reader["ex4"]);
                    lbl_ex5.Text = Convert.ToString(reader["ex5"]);
                    lbl_ex6.Text = Convert.ToString(reader["ex6"]);
                    lbl_ex7.Text = Convert.ToString(reader["ex7"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                connection = new MySqlConnection(null);
                command = new MySqlCommand(null);
            }

            try
            {
                connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");

                sql = "Select * from plano_alimentar";

                command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", tb_idcliente.Text);

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lbl_pa.Text = Convert.ToString(reader["pequeno_almoco"]);
                    lbl_lm.Text = Convert.ToString(reader["lanche_manha"]);
                    lbl_a.Text = Convert.ToString(reader["almoco"]);
                    lbl_lt.Text = Convert.ToString(reader["lanche_tarde"]);
                    lbl_j.Text = Convert.ToString(reader["jantar"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                connection = new MySqlConnection(null);
                command = new MySqlCommand(null);
            }

            try
            {
                connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");

                sql = "select pt.Username as nome from pt join cliente_pt cl_pt on pt.id = cl_pt.id_pt where cl_pt.id_cliente = @id";

                command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", tb_idcliente.Text);

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lbl_pt.Text = Convert.ToString(reader["nome"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                connection = new MySqlConnection(null);
                command = new MySqlCommand(null);
            }

            double Peso = Convert.ToDouble(tb_peso.Text);
            int Altura = Convert.ToInt16(tb_altura.Text);
            double imc = (Peso / (Altura * Altura) * 10000);
            lb_imc.Text = imc.ToString("n2"); 
            
        }
    }
}
