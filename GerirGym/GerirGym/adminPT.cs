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
    public partial class adminPT : Form
    {
        public adminPT()
        {
            InitializeComponent();
        }

        public MySqlConnection connection;
        public MySqlDataReader reader;
        public MySqlCommand command;
        public MySqlDataAdapter adapter;
        string sql;

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");

                sql = "INSERT INTO pt(Username, Passwd) VALUES(@Username, @Passwd)";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Username", tb_username.Text);
                command.Parameters.AddWithValue("@Passwd", tb_passwd.Text);

                connection.Open();

                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show(" Adicionado com sucesso! ", "Mensage do sistema ");
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

                sql = "DELETE FROM pt WHERE ID = @ID";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ID", tb_id.Text);

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

                sql = "UPDATE pt SET Username = @Username, Passwd = @Passwd WHERE ID = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", tb_id.Text);
                command.Parameters.AddWithValue("@Username", tb_username.Text);
                command.Parameters.AddWithValue("@Passwd", tb_passwd.Text);

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

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");

                sql = "SELECT * FROM pt WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", tb_id.Text);

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tb_id.Text = Convert.ToString(reader["ID"]);
                    tb_username.Text = Convert.ToString(reader["Username"]);
                    tb_passwd.Text = Convert.ToString(reader["Passwd"]);
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

        private void btn_mostrar_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");

                sql = "SELECT * FROM pt";

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
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuSecretariaForm back = new MenuSecretariaForm();
            back.Show();
        }

        private void adminPT_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");

                sql = "SELECT * FROM pt";

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
        }
    }
}
