using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad
{
    public partial class frmabout : Form
    {
        public frmabout()
        {
            InitializeComponent();
        }

        private void frmabout_Load(object sender, EventArgs e)
        {
            lblabut.Text = "Created notepad by:\nFz Zarezadeh";
        }
    }
}
