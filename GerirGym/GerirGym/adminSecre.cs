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
    public partial class adminSecre : Form
    {
        public adminSecre()
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
            MenuSecretariaForm back = new MenuSecretariaForm();
            back.Show();
        }

        private void adminSecre_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");

                sql = "SELECT * FROM secretaria";

                adapter = new MySqlDataAdapter(sql, connection);

                DataTable dt1 = new DataTable();

                adapter.Fill(dt1);
                dataGridView1.DataSource = dt1;

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

        private void btn_refresh_Click(object sender, EventArgs e)
        {

        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {

        }
    }
}
