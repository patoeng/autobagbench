namespace AutoBagBench
{
    partial class ChangePassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_NewPassword = new System.Windows.Forms.TextBox();
            this.btn_ChangeOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Password";
            // 
            // tb_NewPassword
            // 
            this.tb_NewPassword.Location = new System.Drawing.Point(35, 39);
            this.tb_NewPassword.Name = "tb_NewPassword";
            this.tb_NewPassword.Size = new System.Drawing.Size(481, 20);
            this.tb_NewPassword.TabIndex = 1;
            this.tb_NewPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_NewPassword_KeyDown);
            // 
            // btn_ChangeOk
            // 
            this.btn_ChangeOk.Location = new System.Drawing.Point(532, 39);
            this.btn_ChangeOk.Name = "btn_ChangeOk";
            this.btn_ChangeOk.Size = new System.Drawing.Size(75, 23);
            this.btn_ChangeOk.TabIndex = 2;
            this.btn_ChangeOk.Text = "OK";
            this.btn_ChangeOk.UseVisualStyleBackColor = true;
            this.btn_ChangeOk.Click += new System.EventHandler(this.btn_ChangeOk_Click);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 78);
            this.Controls.Add(this.btn_ChangeOk);
            this.Controls.Add(this.tb_NewPassword);
            this.Controls.Add(this.label1);
            this.Name = "ChangePassword";
            this.Text = "ChangePassword";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_NewPassword;
        private System.Windows.Forms.Button btn_ChangeOk;
    }
}