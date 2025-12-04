using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace notepad
{
    public partial class frmmain : Form
    {
        bool issaved = false;
        string path = "";
        public frmmain()
        {
            InitializeComponent();
        }

        private void rightToLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rightToLeftToolStripMenuItem.Checked)
            {
                txtpad.RightToLeft = RightToLeft.No;
                rightToLeftToolStripMenuItem.Checked = false;
            }
            else
            {
                txtpad.RightToLeft = RightToLeft.Yes;
                rightToLeftToolStripMenuItem.Checked = true;
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (issaved)
            {
               if( MessageBox.Show("Are you sure to quit?","Exit",MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else if (txtpad.TextLength > 0)
            {
                if (MessageBox.Show("Do you want save text before quit App?","Save and Exit",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
                {
                        savetxt();
                    Application.Exit();
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure to quit?", "Exit", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void setColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog()==DialogResult.OK)
            {
                txtpad.ForeColor = colorDialog1.Color;
            }
        }

        private void setFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog()==DialogResult.OK)
            {
                txtpad.Font = fontDialog1.Font;
            }
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusBarToolStripMenuItem.Checked)
            {
                statusBarToolStripMenuItem.Checked = false;
                lblstatus.Visible = false;
            }
            else
            {
                statusBarToolStripMenuItem.Checked = true;
                lblstatus.Visible = true;
                status_load();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            statusBarToolStripMenuItem.Checked = true;
            lblstatus.Visible = true;
            status_load();

            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = false;

            // ذخیره اولین حالت
            undoStack.Push(txtpad.Text);

            // رویداد تغییر متن
            txtpad.TextChanged += txtpad_TextChanged;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmabout about = new frmabout();
            about.Show();
        }
        
        private void status_load()
        {
            int textChar = count_char();
            lblstatus.Text = textChar.ToString()+" character";            
        }
        private int count_char()
        {
            string context = txtpad.Text.Trim();
            string contextarr="";
            for (int i = 0; i < context.Length; i++)
            {
                if (context[i].ToString() != " " && context[i].ToString() != "\n" && context[i].ToString() != "\r")
                {
                    contextarr += context[i];
                }
            }
            int result = 0;

            if (context.Length == 0)
                result = 0;
            else
                result = contextarr.Length;

            return result;
        }

        private void txtpad_TextChanged(object sender, EventArgs e)
        {
            if (!isUndoRedo) // فقط وقتی کاربر تغییر داده
            {

                if (undoStack.Count == 0 || undoStack.Peek() != txtpad.Text)
                {
                    undoStack.Push(txtpad.Text);
                    redoStack.Clear();
                }
            }
            UpdateButtons();

            if (statusBarToolStripMenuItem.Checked)
                status_load();

            issaved = false;
        }
        private void savetxt()
        {
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;

                // ذخیره با Encoding انتخابی
                Encoding enc = Encoding.UTF8;
                File.WriteAllText(path, txtpad.Text, enc);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(path))
            {
                // ذخیره با Encoding انتخابی
                Encoding enc = Encoding.UTF8;
                File.WriteAllText(path, txtpad.Text, enc);
            }
            else
            {
                savetxt();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savetxt();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmfindreplace find = new frmfindreplace(false,txtpad);
            find.Show();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmfindreplace replace = new frmfindreplace(true,txtpad);
            replace.Show();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtpad.Select(0, txtpad.TextLength);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtpad.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtpad.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtpad.Paste();
        }


        Stack<string> undoStack = new Stack<string>();
        Stack<string> redoStack = new Stack<string>();
        bool isUndoRedo = false;

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (undoStack.Count > 1) // حداقل یک حالت قبلی وجود داشته باشه
            {
                isUndoRedo = true;
                string current = undoStack.Pop(); // حالت فعلی رو بردار
                redoStack.Push(current);          // بفرست داخل Redo
                txtpad.Text = undoStack.Peek(); // برگرد به حالت قبلی
                isUndoRedo = false;
            }

            UpdateButtons();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (redoStack.Count > 0)
            {
                isUndoRedo = true;
                string redoText = redoStack.Pop();
                undoStack.Push(redoText);
                txtpad.Text = redoText;
                isUndoRedo = false;
            }

            UpdateButtons();
        }

        private void UpdateButtons()
        {
            undoToolStripMenuItem.Enabled = undoStack.Count > 1; // اگر حالت قبلی وجود داشت
            redoToolStripMenuItem.Enabled = redoStack.Count > 0; // اگر حالت بعدی وجود داشت
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!issaved) // اگر ذخیره نشده
            {
                DialogResult result = MessageBox.Show(
                    "changes not saved!do you want save?",
                    "New Document", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    savetxt(); 
                    ClearEditor();
                }
                else if (result == DialogResult.No)
                {
                    ClearEditor();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            else
            {
                ClearEditor();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (issaved)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog1.FileName;

                    // انتخاب Encoding هنگام باز کردن
                    Encoding enc = Encoding.UTF8; // می‌تونی تغییر بدی به Encoding.Default یا Encoding.ASCII
                    txtpad.Text = File.ReadAllText(path, enc);
                    status_load();
                }
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    "changes not saved!do you want save?",
                    "open Document", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    savetxt();
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        path = openFileDialog1.FileName;

                        // انتخاب Encoding هنگام باز کردن
                        Encoding enc = Encoding.UTF8; // می‌تونی تغییر بدی به Encoding.Default یا Encoding.ASCII
                        txtpad.Text = File.ReadAllText(path, enc);
                        status_load();
                    }

                }
                else if (result == DialogResult.No)
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        path = openFileDialog1.FileName;

                        // انتخاب Encoding هنگام باز کردن
                        Encoding enc = Encoding.UTF8; // می‌تونی تغییر بدی به Encoding.Default یا Encoding.ASCII
                        txtpad.Text = File.ReadAllText(path, enc);
                        status_load();
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            
        }

        string textToPrint;
        int currentCharIndex = 0;
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                textToPrint = txtpad.Text;
                currentCharIndex = 0;

                printDocument1.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
                printDocument1.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font printFont = new Font("Arial", 12);
            int charsOnPage = 0;
            int linesPerPage = 0;

            // اندازه‌گیری چند کاراکتر در یک صفحه جا میشه
            e.Graphics.MeasureString(
                textToPrint.Substring(currentCharIndex),
                printFont,
                e.MarginBounds.Size,
                StringFormat.GenericTypographic,
                out charsOnPage,
                out linesPerPage);

            // چاپ همین بخش
            e.Graphics.DrawString(
                textToPrint.Substring(currentCharIndex, charsOnPage),
                printFont,
                Brushes.Black,
                e.MarginBounds,
                StringFormat.GenericTypographic);

            // برو جلو
            currentCharIndex += charsOnPage;

            // اگر هنوز متن باقی مونده، صفحه بعدی رو فعال کن
            if (currentCharIndex < textToPrint.Length)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
                currentCharIndex = 0; // ریست برای چاپ بعدی
            }
        }

        private void ClearEditor()
        {
            txtpad.Clear();
            undoStack.Clear();
            redoStack.Clear();
            undoStack.Push(txtpad.Text); // حالت اولیه
            issaved = true;
            UpdateButtons();
        }
    }
}
