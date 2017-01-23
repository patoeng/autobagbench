namespace AutoBagBench
{
    partial class BarcodeReader
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_ComName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_BaudRate = new System.Windows.Forms.Label();
            this.btn_OpenClosePort = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_Read = new System.Windows.Forms.TextBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.SerialPortBarcode = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(137, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(412, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "BARCODE READER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "COM NAME";
            // 
            // lbl_ComName
            // 
            this.lbl_ComName.AutoSize = true;
            this.lbl_ComName.Location = new System.Drawing.Point(131, 79);
            this.lbl_ComName.Name = "lbl_ComName";
            this.lbl_ComName.Size = new System.Drawing.Size(35, 13);
            this.lbl_ComName.TabIndex = 2;
            this.lbl_ComName.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "BAUD RATE";
            // 
            // lbl_BaudRate
            // 
            this.lbl_BaudRate.AutoSize = true;
            this.lbl_BaudRate.Location = new System.Drawing.Point(131, 106);
            this.lbl_BaudRate.Name = "lbl_BaudRate";
            this.lbl_BaudRate.Size = new System.Drawing.Size(35, 13);
            this.lbl_BaudRate.TabIndex = 4;
            this.lbl_BaudRate.Text = "label4";
            // 
            // btn_OpenClosePort
            // 
            this.btn_OpenClosePort.Location = new System.Drawing.Point(296, 101);
            this.btn_OpenClosePort.Name = "btn_OpenClosePort";
            this.btn_OpenClosePort.Size = new System.Drawing.Size(75, 23);
            this.btn_OpenClosePort.TabIndex = 5;
            this.btn_OpenClosePort.Text = "Open Port";
            this.btn_OpenClosePort.UseVisualStyleBackColor = true;
            this.btn_OpenClosePort.Click += new System.EventHandler(this.btn_OpenClosePort_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_Read);
            this.groupBox1.Location = new System.Drawing.Point(12, 157);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(654, 147);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATA READ";
            // 
            // tb_Read
            // 
            this.tb_Read.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Read.Location = new System.Drawing.Point(3, 16);
            this.tb_Read.Multiline = true;
            this.tb_Read.Name = "tb_Read";
            this.tb_Read.Size = new System.Drawing.Size(648, 128);
            this.tb_Read.TabIndex = 0;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(588, 144);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.TabIndex = 7;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // BarcodeReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 325);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_OpenClosePort);
            this.Controls.Add(this.lbl_BaudRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_ComName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BarcodeReader";
            this.Text = "Barcode Reader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BarcodeReader_FormClosing);
            this.Load += new System.EventHandler(this.BarcodeReader_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_ComName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_BaudRate;
        private System.Windows.Forms.Button btn_OpenClosePort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_Read;
        private System.Windows.Forms.Button btn_Clear;
        private System.IO.Ports.SerialPort SerialPortBarcode;
    }
}