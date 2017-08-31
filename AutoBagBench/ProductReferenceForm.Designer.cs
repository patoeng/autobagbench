namespace AutoBagBench
{
    partial class ProductReferenceForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_Id = new System.Windows.Forms.TextBox();
            this.tb_ReferenceName = new System.Windows.Forms.TextBox();
            this.cbb_BagType = new System.Windows.Forms.ComboBox();
            this.cbb_AccessoriesType = new System.Windows.Forms.ComboBox();
            this.tb_GroupingSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Article = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_LabelFile = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(477, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "PRODUCT REFERENCE";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_LabelFile);
            this.groupBox1.Controls.Add(this.tb_Id);
            this.groupBox1.Controls.Add(this.tb_ReferenceName);
            this.groupBox1.Controls.Add(this.cbb_BagType);
            this.groupBox1.Controls.Add(this.cbb_AccessoriesType);
            this.groupBox1.Controls.Add(this.tb_GroupingSize);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_Article);
            this.groupBox1.Location = new System.Drawing.Point(27, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(586, 239);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "REFERENCE";
            // 
            // tb_Id
            // 
            this.tb_Id.Location = new System.Drawing.Point(204, 31);
            this.tb_Id.Name = "tb_Id";
            this.tb_Id.ReadOnly = true;
            this.tb_Id.Size = new System.Drawing.Size(349, 20);
            this.tb_Id.TabIndex = 5;
            // 
            // tb_ReferenceName
            // 
            this.tb_ReferenceName.Location = new System.Drawing.Point(204, 57);
            this.tb_ReferenceName.Name = "tb_ReferenceName";
            this.tb_ReferenceName.Size = new System.Drawing.Size(349, 20);
            this.tb_ReferenceName.TabIndex = 5;
            // 
            // cbb_BagType
            // 
            this.cbb_BagType.FormattingEnabled = true;
            this.cbb_BagType.Location = new System.Drawing.Point(204, 165);
            this.cbb_BagType.Name = "cbb_BagType";
            this.cbb_BagType.Size = new System.Drawing.Size(349, 21);
            this.cbb_BagType.TabIndex = 4;
            // 
            // cbb_AccessoriesType
            // 
            this.cbb_AccessoriesType.FormattingEnabled = true;
            this.cbb_AccessoriesType.Location = new System.Drawing.Point(204, 137);
            this.cbb_AccessoriesType.Name = "cbb_AccessoriesType";
            this.cbb_AccessoriesType.Size = new System.Drawing.Size(349, 21);
            this.cbb_AccessoriesType.TabIndex = 3;
            // 
            // tb_GroupingSize
            // 
            this.tb_GroupingSize.Location = new System.Drawing.Point(204, 110);
            this.tb_GroupingSize.Name = "tb_GroupingSize";
            this.tb_GroupingSize.Size = new System.Drawing.Size(349, 20);
            this.tb_GroupingSize.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "ACCESSORIES TYPE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "BAG TYPE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "GROUPING SIZE";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "DATABASE ID";
            this.label7.Click += new System.EventHandler(this.label6_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "REFERENCE NAME";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ARTICLE NUMBER";
            // 
            // tb_Article
            // 
            this.tb_Article.Location = new System.Drawing.Point(204, 83);
            this.tb_Article.Name = "tb_Article";
            this.tb_Article.Size = new System.Drawing.Size(349, 20);
            this.tb_Article.TabIndex = 0;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(538, 304);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 46);
            this.btn_Save.TabIndex = 7;
            this.btn_Save.Text = "SAVE";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "LABEL FILE";
            // 
            // tb_LabelFile
            // 
            this.tb_LabelFile.Location = new System.Drawing.Point(204, 194);
            this.tb_LabelFile.Name = "tb_LabelFile";
            this.tb_LabelFile.Size = new System.Drawing.Size(349, 20);
            this.tb_LabelFile.TabIndex = 6;
            // 
            // ProductReferenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 363);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "ProductReferenceForm";
            this.Text = "ProductReferenceForm";
            this.Load += new System.EventHandler(this.ProductReferenceForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_Article;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_AccessoriesType;
        private System.Windows.Forms.TextBox tb_GroupingSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbb_BagType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_ReferenceName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_Id;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox tb_LabelFile;
        private System.Windows.Forms.Label label8;
    }
}