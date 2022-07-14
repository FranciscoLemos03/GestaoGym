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

namespace GerirGym
{
    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            tb_passwd.Text = "";
            tb_passwd.PasswordChar = '*';
        }
        public Form1()
        {
            InitializeComponent();
        }


        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Deseja mesmo sair? ", "Mensage do sistema ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            ControllerDB login = new ControllerDB();
           
            string txt;
            if ((txt = login.loginSecretaria(tb_username.Text, tb_passwd.Text)) != "")
            {
                MessageBox.Show("Bem vindo " + txt);
                this.Hide();
                MenuSecretariaForm SF = new MenuSecretariaForm();
                SF.Show();
                return;
            }
            if ((txt = login.loginCliente(tb_username.Text, tb_passwd.Text)) != "")
            {
                MessageBox.Show("Bem vindo " + txt);
                this.Hide();
                clienteForm cf = new clienteForm();
                cf.Show();
                return;
            }
            if ((txt = login.loginPT(tb_username.Text, tb_passwd.Text)) != "")
            {
                MessageBox.Show("Bem vindo " + txt);
                this.Hide();
                MenuPT pt = new MenuPT();
                pt.Show();
                return;
            }
            if ((txt = login.loginNutri(tb_username.Text, tb_passwd.Text)) != "")
            {
                MessageBox.Show("Bem vindo " + txt);
                this.Hide();
                MenuNutri mn = new MenuNutri();
                mn.Show();
                return;
            }
            else
            {
                MessageBox.Show("login errado");
                return;
            }
        }

    }
}
