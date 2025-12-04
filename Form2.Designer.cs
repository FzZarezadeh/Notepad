namespace notepad
{
    partial class frmabout
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
            this.lblabut = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblabut
            // 
            this.lblabut.BackColor = System.Drawing.SystemColors.Window;
            this.lblabut.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblabut.Location = new System.Drawing.Point(12, 9);
            this.lblabut.Name = "lblabut";
            this.lblabut.Size = new System.Drawing.Size(523, 284);
            this.lblabut.TabIndex = 0;
            this.lblabut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmabout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 302);
            this.Controls.Add(this.lblabut);
            this.Name = "frmabout";
            this.Text = "About Us";
            this.Load += new System.EventHandler(this.frmabout_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblabut;
    }
}