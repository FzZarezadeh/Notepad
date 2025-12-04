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
    public partial class frmfindreplace : Form
    {
        private bool wich;
        public TextBox txtpad;
        private int lastindex = 0;
        private string lastSearch = "";
        public frmfindreplace(bool wich1,TextBox txt)
        {
            InitializeComponent();
            wich = wich1;
            txtpad = txt;
        }
        private void frmfindreplace_Load(object sender, EventArgs e)
        {
            if (wich)
            {
                pnlreplace.Visible = true;
                pnlreplace.Enabled = true;
                this.Text = "Replace";
            }
            else
            {
                pnlreplace.Visible = false;
                pnlreplace.Enabled = false;
                this.Text = "Find";
            }

            lblmessage.ForeColor = Color.Red;
            btnfindnext.Enabled = false;
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            lastSearch = txtfind.Text; ;

            if (!string.IsNullOrEmpty(lastSearch))
            {
                lastindex = 0;
                FindNext();
                btnfindnext.Enabled = true;
            }
            else
            {
                lblmessage.Text = "Enter word!";
            }
        }

        private void btnfindnext_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lastSearch))
            {
                FindNext();
            }
            else
            {
                lblmessage.Text = "Enter word!";
            }
        }

        private void btnreplace_Click(object sender, EventArgs e)
        {
            lastSearch = txtfind.Text;
            if (!string.IsNullOrEmpty(lastSearch))
            {
                if (txtpad.SelectionLength > 0)
                { 
                    string replaceWord = txtreplace.Text;
                    if (!string.IsNullOrEmpty(replaceWord))
                    {
                        txtpad.SelectedText = replaceWord;
                    }
                    else
                    {
                        lblmessage.Text = "Enter word!";
                    }
                }
                else
                {
                    lastindex = 0;
                    FindNext();

                    if (txtpad.SelectionLength > 0)
                    {
                        string replaceWord = txtreplace.Text;
                        if (!string.IsNullOrEmpty(replaceWord))
                        {                           
                            txtpad.SelectedText = replaceWord;                          
                        }
                        else
                        {
                            lblmessage.Text = "Enter word!";
                        }
                    }
                    else
                    {
                        lblmessage.Text = "Not find item";
                    }
                }
            }
            else
            {
                lblmessage.Text = "Enter word!";
            }
        }

        private void btnreplaceall_Click(object sender, EventArgs e)
        {
            lastSearch = txtfind.Text;
            if (!string.IsNullOrEmpty(lastSearch))
            {               
                if (txtpad.SelectionLength > 0)
                {
                    string replaceWord = txtreplace.Text;
                    if (!string.IsNullOrEmpty(replaceWord))
                    {
                        txtpad.Text = txtpad.Text.Replace(lastSearch, replaceWord);
                    }
                    else
                    {
                        lblmessage.Text = "Enter word!";
                    }
                }
                else
                {                   
                    lastindex = 0;
                    FindNext();

                    if (txtpad.SelectionLength > 0)
                    {
                        string replaceWord = txtreplace.Text;
                        if (!string.IsNullOrEmpty(replaceWord))
                        {
                            txtpad.Text = txtpad.Text.Replace(lastSearch, replaceWord);
                        }
                        else
                        {
                            lblmessage.Text = "Enter word!";
                        }
                    }
                    else
                    {
                        lblmessage.Text = "Not find item";
                    }
                }
            }
            else
            {
                lblmessage.Text = "Enter word!";
            }
        }

        private void FindNext()
        {
            int index = txtpad.Text.IndexOf(lastSearch, lastindex, StringComparison.OrdinalIgnoreCase);

            if (index != -1)
            {
                //txtpad.SelectionStart = index;
                //txtpad.SelectionLength = lastSearch.Length;
                txtpad.Select(index, lastSearch.Length);
                txtpad.Focus();
                txtpad.ScrollToCaret();
                lastindex = index + lastSearch.Length;
            }
            else
            {
                lblmessage.Text = "Not find item";
                lastindex = 0; // back first of text
            }
        }
    }
}
