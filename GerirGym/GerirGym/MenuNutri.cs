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
    public partial class MenuNutri : Form
    {
        public MenuNutri()
        {
            InitializeComponent();
        }

        public MySqlConnection connection;
        public MySqlDataReader reader;
        public MySqlCommand command;
        public MySqlDataAdapter adapter;
        string sql;

        private void btn_mostrar_Click(object sender, EventArgs e)
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

                sql = "SELECT * FROM plano_alimentar";

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

        private void MenuNutri_Load(object sender, EventArgs e)
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

                sql = "SELECT * FROM plano_alimentar";

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

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");

                sql = "INSERT INTO plano_alimentar(id_cliente, pequeno_almoco, lanche_manha, almoco, lanche_tarde, jantar) VALUES(@id_cliente, @pequeno_almoco, @lanche_manha, @almoco, @lanche_tarde, @jantar)";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id_cliente", tb_id.Text);
                command.Parameters.AddWithValue("@pequeno_almoco", tb_pa.Text);
                command.Parameters.AddWithValue("@lanche_manha", tb_lm.Text);
                command.Parameters.AddWithValue("@almoco", tb_a.Text);
                command.Parameters.AddWithValue("@lanche_tarde", tb_lt.Text);
                command.Parameters.AddWithValue("@jantar", tb_j.Text);

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

        private void btn_remover_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");

                sql = "DELETE FROM plano_alimentar WHERE id = @ID";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ID", tb_id_planoa.Text);

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

        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");

                sql = "UPDATE plano_alimentar SET id_cliente = @id_cliente, pequeno_almoco = @pa, lanche_manha = @lm, almoco = @a, lanche_tarde = @lt, jantar = @j WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", tb_id_planoa.Text);
                command.Parameters.AddWithValue("@id_cliente", tb_id.Text);
                command.Parameters.AddWithValue("@pa", tb_pa.Text);
                command.Parameters.AddWithValue("@lm", tb_lm.Text);
                command.Parameters.AddWithValue("@a", tb_a.Text);
                command.Parameters.AddWithValue("@lt", tb_lt.Text);
                command.Parameters.AddWithValue("@j", tb_j.Text);

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

        private void btn_procurar_Click(object sender, EventArgs e)
        {

            try
            {
                connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");

                sql = "SELECT * FROM plano_alimentar WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", tb_id_planoa.Text);

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tb_id_planoa.Text = Convert.ToString(reader["id"]);
                    tb_id.Text = Convert.ToString(reader["id_cliente"]);
                    tb_pa.Text = Convert.ToString(reader["pequeno_almoco"]);
                    tb_lm.Text = Convert.ToString(reader["lanche_manha"]);
                    tb_a.Text = Convert.ToString(reader["almoco"]);
                    tb_lt.Text = Convert.ToString(reader["lanche_tarde"]);
                    tb_j.Text = Convert.ToString(reader["jantar"]);

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
    }
}
