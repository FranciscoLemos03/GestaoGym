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
    public partial class MenuSecretariaForm : Form
    {
        public MenuSecretariaForm()
        {
            InitializeComponent();
        }

        public MySqlConnection connection;
        public MySqlDataReader reader;
        public MySqlCommand command;
      //public MySqlDataAdapter adapter;
        string sql;

        private void MenuSecretariaForm_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");

                sql = "Select count(*) as myCount from cliente";

                command = new MySqlCommand(sql, connection);

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lbl_numcliente.Text = Convert.ToString(reader["myCount"]);
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

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 inicio = new Form1();
            inicio.Show();
        }

        private void btn_addcliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminForm af = new adminForm();
            af.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Deseja mesmo sair? ", "Mensage do sistema ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminPT aPT = new adminPT();
            aPT.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminSecre aSc = new adminSecre();
            aSc.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminNutri aNu = new adminNutri();
            aNu.Show();
        }

    }
}
