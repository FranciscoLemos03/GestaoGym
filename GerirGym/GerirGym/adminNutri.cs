using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerirGym
{
    public partial class adminNutri : Form
    {
        public adminNutri()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuSecretariaForm back = new MenuSecretariaForm();
            back.Show();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {

        }
    }
}
