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
    public partial class adminForm : Form
    {
        public adminForm()
        {
            InitializeComponent();
        }

        public MySqlConnection connection;
        public MySqlDataReader reader;
        public MySqlCommand command;
        public MySqlDataAdapter adapter;
        string sql;

        private void btn_juntar_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");

                sql = "INSERT INTO pt_cliente(id_pt, id_cliente) VALUES(@id_pt, @id_cliente)";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id_pt", tb_idpt.Text);
                command.Parameters.AddWithValue("@id_cliente", tb_idcliente.Text);

                connection.Open();

                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show(" União feita com sucesso! ", "Mensage do sistema ");
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

                sql = "INSERT INTO cliente(Username, Passwd, sexo, data_nascimento, nacionalidade) VALUES(@Username, @Passwd, @sexo, @data_nascimento, @nacionalidade)";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Username", tb_username.Text);
                command.Parameters.AddWithValue("@Passwd", tb_passwd.Text);
                command.Parameters.AddWithValue("@sexo", cb_sexo.Text);
                command.Parameters.AddWithValue("@data_nascimento", tb_data.Text);
                command.Parameters.AddWithValue("@nacionalidade", tb_nacionalidade.Text);

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

        private void adminForm_Load(object sender, EventArgs e)
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

        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Deseja mesmo sair? ", "Mensage do sistema ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");

                sql = "UPDATE cliente SET Username = @Username, Passwd = @Passwd, sexo = @sexo, data_nascimento = @data_nascimento , nacionalidade = @nacionalidade WHERE ID = @id"; 

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", tb_id.Text);
                command.Parameters.AddWithValue("@Username", tb_username.Text);
                command.Parameters.AddWithValue("@Passwd", tb_passwd.Text);
                command.Parameters.AddWithValue("@sexo", cb_sexo.Text);
                command.Parameters.AddWithValue("@data_nascimento", tb_data.Text);
                command.Parameters.AddWithValue("@nacionalidade", tb_nacionalidade.Text);

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

                sql = "DELETE FROM cliente WHERE ID = @ID";

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

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");

                sql = "SELECT * FROM cliente WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", tb_id.Text);

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tb_id.Text = Convert.ToString(reader["ID"]);
                    tb_username.Text = Convert.ToString(reader["Username"]);
                    tb_passwd.Text = Convert.ToString(reader["Passwd"]);
                    cb_sexo.Text = Convert.ToString(reader["sexo"]);
                    tb_data.Text = Convert.ToString(reader["data_nascimento"]);
                    tb_nacionalidade.Text = Convert.ToString(reader["nacionalidade"]);
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
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuSecretariaForm back = new MenuSecretariaForm();
            back.Show();
        }

        
    }
}
