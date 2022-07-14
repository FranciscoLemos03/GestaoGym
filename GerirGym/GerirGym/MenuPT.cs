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
    public partial class MenuPT : Form
    {
        public MenuPT()
        {
            InitializeComponent();
        }

        public MySqlConnection connection;
        public MySqlDataReader reader;
        public MySqlCommand command;
        public MySqlDataAdapter adapter;
        string sql;

        private void MenuPT_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");

                sql = "SELECT * FROM cliente";

                adapter = new MySqlDataAdapter(sql, connection);

                DataTable dt = new DataTable();

                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

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

                sql = "SELECT * FROM cliente_pt";

                adapter = new MySqlDataAdapter(sql, connection);

                DataTable dt1 = new DataTable();

                adapter.Fill(dt1);
                dataGridView2.DataSource = dt1;

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

                sql = "SELECT * FROM plano_treino";

                adapter = new MySqlDataAdapter(sql, connection);

                DataTable dt2 = new DataTable();

                adapter.Fill(dt2);
                dataGridView3.DataSource = dt2;

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
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 inicio = new Form1();
            inicio.Show();
        }

        private void btn_mostrar_Click_1(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");

                sql = "SELECT * FROM cliente";

                adapter = new MySqlDataAdapter(sql, connection);

                DataTable dt = new DataTable();

                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

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

                sql = "SELECT * FROM cliente_pt";

                adapter = new MySqlDataAdapter(sql, connection);

                DataTable dt1 = new DataTable();

                adapter.Fill(dt1);
                dataGridView2.DataSource = dt1;

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

                sql = "SELECT * FROM plano_treino";

                adapter = new MySqlDataAdapter(sql, connection);

                DataTable dt2 = new DataTable();

                adapter.Fill(dt2);
                dataGridView3.DataSource = dt2;

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

        }

        private void btn_procurar_Click_1(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");

                sql = "SELECT * FROM plano_treino WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", tb_id_planot.Text);

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tb_id_planot.Text = Convert.ToString(reader["id"]);
                    tb_id.Text = Convert.ToString(reader["id_cliente"]);
                    tb_ex1.Text = Convert.ToString(reader["ex1"]);
                    tb_ex2.Text = Convert.ToString(reader["ex2"]);
                    tb_ex3.Text = Convert.ToString(reader["ex3"]);
                    tb_ex4.Text = Convert.ToString(reader["ex4"]);
                    tb_ex5.Text = Convert.ToString(reader["ex5"]);
                    tb_ex6.Text = Convert.ToString(reader["ex6"]);
                    tb_ex7.Text = Convert.ToString(reader["ex7"]);

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
        }

        private void btn_editar_Click_1(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");

                sql = "UPDATE plano_treino SET id_cliente = @id_cliente, ex1 = @ex1, ex2 = @ex2, ex3 = @ex3, ex4 = @ex4, ex5 = @ex5, ex6 = @ex6, ex7 = @ex7 WHERE ID = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", tb_id_planot.Text);
                command.Parameters.AddWithValue("@id_cliente", tb_id.Text);
                command.Parameters.AddWithValue("@ex1", tb_ex1.Text);
                command.Parameters.AddWithValue("@ex2", tb_ex2.Text);
                command.Parameters.AddWithValue("@ex3", tb_ex3.Text);
                command.Parameters.AddWithValue("@ex4", tb_ex4.Text);
                command.Parameters.AddWithValue("@ex5", tb_ex5.Text);
                command.Parameters.AddWithValue("@ex6", tb_ex6.Text);
                command.Parameters.AddWithValue("@ex7", tb_ex7.Text);

                connection.Open();

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show(" Editado com sucesso! ", "Mensage do sistema ");
                connection.Close();
                connection = new MySqlConnection(null);
                command = new MySqlCommand(null);
            }
        }

        private void btn_remover_Click_1(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");

                sql = "DELETE FROM plano_treino WHERE id = @ID";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ID", tb_id_planot.Text);

                connection.Open();

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show(" Removido com sucesso! ", "Mensage do sistema ");
                connection.Close();
                connection = new MySqlConnection(null);
                command = new MySqlCommand(null);
            }
        }

        private void btn_add_Click_1(object sender, EventArgs e)
        {

            try
            {
                connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");

                sql = "INSERT INTO plano_treino(id_cliente, ex1, ex2, ex3, ex4, ex5, ex6, ex7) VALUES(@id_cliente, @ex1, @ex2, @ex3, @ex4, @ex5, @ex6, @ex7)";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id_cliente", tb_id.Text);
                command.Parameters.AddWithValue("@ex1", tb_ex1.Text);
                command.Parameters.AddWithValue("@ex2", tb_ex2.Text);
                command.Parameters.AddWithValue("@ex3", tb_ex3.Text);
                command.Parameters.AddWithValue("@ex4", tb_ex4.Text);
                command.Parameters.AddWithValue("@ex5", tb_ex5.Text);
                command.Parameters.AddWithValue("@ex6", tb_ex6.Text);
                command.Parameters.AddWithValue("@ex7", tb_ex7.Text);

                connection.Open();

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show(" Adicionado com sucesso! ", "Mensagem do sistema ");
                connection.Close();
                connection = new MySqlConnection(null);
                command = new MySqlCommand(null);

            }

        }
    }
}
