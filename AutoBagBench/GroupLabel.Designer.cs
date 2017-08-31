namespace AutoBagBench
{
    partial class GroupLabel
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.docPreview = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Path = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_Printer = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.cb_Rotate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Left = new System.Windows.Forms.TextBox();
            this.tb_Top = new System.Windows.Forms.TextBox();
            this.btn_Print = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docPreview)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.docPreview);
            this.groupBox1.Location = new System.Drawing.Point(12, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 347);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PREVIEW";
            // 
            // docPreview
            // 
            this.docPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.docPreview.Location = new System.Drawing.Point(3, 16);
            this.docPreview.Name = "docPreview";
            this.docPreview.Size = new System.Drawing.Size(497, 328);
            this.docPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.docPreview.TabIndex = 0;
            this.docPreview.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "SELECTED LABEL";
            // 
            // lbl_Path
            // 
            this.lbl_Path.AutoSize = true;
            this.lbl_Path.Location = new System.Drawing.Point(132, 90);
            this.lbl_Path.Name = "lbl_Path";
            this.lbl_Path.Size = new System.Drawing.Size(35, 13);
            this.lbl_Path.TabIndex = 2;
            this.lbl_Path.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(201, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(314, 46);
            this.label3.TabIndex = 3;
            this.label3.Text = "GROUP LABEL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "PRINTER";
            // 
            // lbl_Printer
            // 
            this.lbl_Printer.AutoSize = true;
            this.lbl_Printer.Location = new System.Drawing.Point(132, 123);
            this.lbl_Printer.Name = "lbl_Printer";
            this.lbl_Printer.Size = new System.Drawing.Size(35, 13);
            this.lbl_Printer.TabIndex = 2;
            this.lbl_Printer.Text = "label2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Apply);
            this.groupBox2.Controls.Add(this.cb_Rotate);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tb_Left);
            this.groupBox2.Controls.Add(this.tb_Top);
            this.groupBox2.Location = new System.Drawing.Point(522, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 147);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ADJUSTMENT";
            // 
            // btn_Apply
            // 
            this.btn_Apply.Location = new System.Drawing.Point(111, 110);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(100, 23);
            this.btn_Apply.TabIndex = 5;
            this.btn_Apply.Text = "APPLY";
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // cb_Rotate
            // 
            this.cb_Rotate.FormattingEnabled = true;
            this.cb_Rotate.Items.AddRange(new object[] {
            "0",
            "90",
            "180",
            "270"});
            this.cb_Rotate.Location = new System.Drawing.Point(111, 82);
            this.cb_Rotate.Name = "cb_Rotate";
            this.cb_Rotate.Size = new System.Drawing.Size(100, 21);
            this.cb_Rotate.TabIndex = 2;
            this.cb_Rotate.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "LEFT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "ROTATE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "TOP";
            // 
            // tb_Left
            // 
            this.tb_Left.Location = new System.Drawing.Point(111, 55);
            this.tb_Left.Name = "tb_Left";
            this.tb_Left.Size = new System.Drawing.Size(100, 20);
            this.tb_Left.TabIndex = 1;
            this.tb_Left.Text = "0";
            this.tb_Left.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb_Top
            // 
            this.tb_Top.Location = new System.Drawing.Point(111, 28);
            this.tb_Top.Name = "tb_Top";
            this.tb_Top.Size = new System.Drawing.Size(100, 20);
            this.tb_Top.TabIndex = 0;
            this.tb_Top.Text = "0";
            this.tb_Top.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_Print
            // 
            this.btn_Print.Location = new System.Drawing.Point(521, 309);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(229, 23);
            this.btn_Print.TabIndex = 6;
            this.btn_Print.Text = "PRINT";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // GroupLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 550);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_Printer);
            this.Controls.Add(this.lbl_Path);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "GroupLabel";
            this.Text = "Grouping Label";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GroupLabel_FormClosing);
            this.Load += new System.EventHandler(this.GroupLabel_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.docPreview)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Path;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox docPreview;
        private System.Windows.Forms.Label lbl_Printer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_Left;
        private System.Windows.Forms.TextBox tb_Top;
        private System.Windows.Forms.ComboBox cb_Rotate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_Apply;
    }
}