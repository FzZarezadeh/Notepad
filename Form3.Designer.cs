namespace notepad
{
    partial class frmfindreplace
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtfind = new System.Windows.Forms.TextBox();
            this.btnfindnext = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnfind = new System.Windows.Forms.Button();
            this.btnreplace = new System.Windows.Forms.Button();
            this.txtreplace = new System.Windows.Forms.TextBox();
            this.btnreplaceall = new System.Windows.Forms.Button();
            this.pnlreplace = new System.Windows.Forms.Panel();
            this.lblmessage = new System.Windows.Forms.Label();
            this.pnlreplace.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtfind
            // 
            this.txtfind.Location = new System.Drawing.Point(148, 37);
            this.txtfind.Name = "txtfind";
            this.txtfind.Size = new System.Drawing.Size(108, 22);
            this.txtfind.TabIndex = 0;
            // 
            // btnfindnext
            // 
            this.btnfindnext.Location = new System.Drawing.Point(280, 70);
            this.btnfindnext.Name = "btnfindnext";
            this.btnfindnext.Size = new System.Drawing.Size(108, 32);
            this.btnfindnext.TabIndex = 1;
            this.btnfindnext.Text = "Find next";
            this.btnfindnext.UseVisualStyleBackColor = true;
            this.btnfindnext.Click += new System.EventHandler(this.btnfindnext_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Word or Phrase:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Replace with:";
            // 
            // btnfind
            // 
            this.btnfind.Location = new System.Drawing.Point(280, 32);
            this.btnfind.Name = "btnfind";
            this.btnfind.Size = new System.Drawing.Size(108, 32);
            this.btnfind.TabIndex = 1;
            this.btnfind.Text = "Find";
            this.btnfind.UseVisualStyleBackColor = true;
            this.btnfind.Click += new System.EventHandler(this.btnfind_Click);
            // 
            // btnreplace
            // 
            this.btnreplace.Location = new System.Drawing.Point(264, 6);
            this.btnreplace.Name = "btnreplace";
            this.btnreplace.Size = new System.Drawing.Size(108, 32);
            this.btnreplace.TabIndex = 4;
            this.btnreplace.Text = "Replace";
            this.btnreplace.UseVisualStyleBackColor = true;
            this.btnreplace.Click += new System.EventHandler(this.btnreplace_Click);
            // 
            // txtreplace
            // 
            this.txtreplace.Location = new System.Drawing.Point(132, 11);
            this.txtreplace.Name = "txtreplace";
            this.txtreplace.Size = new System.Drawing.Size(108, 22);
            this.txtreplace.TabIndex = 0;
            // 
            // btnreplaceall
            // 
            this.btnreplaceall.Location = new System.Drawing.Point(264, 44);
            this.btnreplaceall.Name = "btnreplaceall";
            this.btnreplaceall.Size = new System.Drawing.Size(108, 32);
            this.btnreplaceall.TabIndex = 4;
            this.btnreplaceall.Text = "Replace All";
            this.btnreplaceall.UseVisualStyleBackColor = true;
            this.btnreplaceall.Click += new System.EventHandler(this.btnreplaceall_Click);
            // 
            // pnlreplace
            // 
            this.pnlreplace.Controls.Add(this.btnreplaceall);
            this.pnlreplace.Controls.Add(this.btnreplace);
            this.pnlreplace.Controls.Add(this.label2);
            this.pnlreplace.Controls.Add(this.txtreplace);
            this.pnlreplace.Enabled = false;
            this.pnlreplace.Location = new System.Drawing.Point(16, 122);
            this.pnlreplace.Name = "pnlreplace";
            this.pnlreplace.Size = new System.Drawing.Size(402, 94);
            this.pnlreplace.TabIndex = 5;
            this.pnlreplace.Visible = false;
            // 
            // lblmessage
            // 
            this.lblmessage.AutoSize = true;
            this.lblmessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmessage.ForeColor = System.Drawing.Color.Green;
            this.lblmessage.Location = new System.Drawing.Point(36, 76);
            this.lblmessage.Name = "lblmessage";
            this.lblmessage.Size = new System.Drawing.Size(0, 18);
            this.lblmessage.TabIndex = 6;
            // 
            // frmfindreplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 228);
            this.Controls.Add(this.lblmessage);
            this.Controls.Add(this.pnlreplace);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnfind);
            this.Controls.Add(this.btnfindnext);
            this.Controls.Add(this.txtfind);
            this.Name = "frmfindreplace";
            this.Text = "Find";
            this.Load += new System.EventHandler(this.frmfindreplace_Load);
            this.pnlreplace.ResumeLayout(false);
            this.pnlreplace.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtfind;
        private System.Windows.Forms.Button btnfindnext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnfind;
        private System.Windows.Forms.Button btnreplace;
        private System.Windows.Forms.TextBox txtreplace;
        private System.Windows.Forms.Button btnreplaceall;
        private System.Windows.Forms.Panel pnlreplace;
        private System.Windows.Forms.Label lblmessage;
    }
}