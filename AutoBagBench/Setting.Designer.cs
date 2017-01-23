namespace AutoBagBench
{
    partial class Setting
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
            this.tb_PLCAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_DataBaseServer = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_ReadInterval = new System.Windows.Forms.TextBox();
            this.tb_PLCPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_DataBaseCatalogue = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_LabelGroupPath = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbb_GroupingPrinter = new System.Windows.Forms.ComboBox();
            this.btn_OpenLabelImagePath = new System.Windows.Forms.Button();
            this.btn_OpenLabelPath = new System.Windows.Forms.Button();
            this.tb_LabelGroupImagePath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chb_Traceability = new System.Windows.Forms.CheckBox();
            this.btn_GenerateNewID = new System.Windows.Forms.Button();
            this.tb_EquipmentName = new System.Windows.Forms.TextBox();
            this.tb_Identity = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_Reload = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbb_IndividualPrinter = new System.Windows.Forms.ComboBox();
            this.tb_LabelIndividualPath = new System.Windows.Forms.TextBox();
            this.btn_LabelIndividualImagePath = new System.Windows.Forms.Button();
            this.btn_IndividualLabelpath = new System.Windows.Forms.Button();
            this.tb_IndividualImagePath = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbb_BaudRate = new System.Windows.Forms.ComboBox();
            this.cbb_ComName = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "BAUD RATE";
            // 
            // tb_PLCAddress
            // 
            this.tb_PLCAddress.Location = new System.Drawing.Point(168, 31);
            this.tb_PLCAddress.Name = "tb_PLCAddress";
            this.tb_PLCAddress.Size = new System.Drawing.Size(291, 20);
            this.tb_PLCAddress.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "IDENTITY";
            // 
            // tb_DataBaseServer
            // 
            this.tb_DataBaseServer.Location = new System.Drawing.Point(165, 31);
            this.tb_DataBaseServer.Name = "tb_DataBaseServer";
            this.tb_DataBaseServer.Size = new System.Drawing.Size(294, 20);
            this.tb_DataBaseServer.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tb_ReadInterval);
            this.groupBox1.Controls.Add(this.tb_PLCPort);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_PLCAddress);
            this.groupBox1.Location = new System.Drawing.Point(26, 223);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 139);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PLC";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(462, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "ms";
            // 
            // tb_ReadInterval
            // 
            this.tb_ReadInterval.Location = new System.Drawing.Point(168, 89);
            this.tb_ReadInterval.Name = "tb_ReadInterval";
            this.tb_ReadInterval.Size = new System.Drawing.Size(291, 20);
            this.tb_ReadInterval.TabIndex = 3;
            // 
            // tb_PLCPort
            // 
            this.tb_PLCPort.Location = new System.Drawing.Point(168, 61);
            this.tb_PLCPort.Name = "tb_PLCPort";
            this.tb_PLCPort.Size = new System.Drawing.Size(291, 20);
            this.tb_PLCPort.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "READ INTERVAL";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 33);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "IP ADDRESS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "PLC PORT";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_DataBaseCatalogue);
            this.groupBox2.Controls.Add(this.tb_DataBaseServer);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(580, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(486, 137);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DATABASE";
            // 
            // tb_DataBaseCatalogue
            // 
            this.tb_DataBaseCatalogue.Location = new System.Drawing.Point(165, 57);
            this.tb_DataBaseCatalogue.Name = "tb_DataBaseCatalogue";
            this.tb_DataBaseCatalogue.Size = new System.Drawing.Size(294, 20);
            this.tb_DataBaseCatalogue.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "CATALOGUE NAME";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "DATABASE SERVER";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "LABEL GROUP PATH";
            // 
            // tb_LabelGroupPath
            // 
            this.tb_LabelGroupPath.Location = new System.Drawing.Point(168, 26);
            this.tb_LabelGroupPath.Name = "tb_LabelGroupPath";
            this.tb_LabelGroupPath.Size = new System.Drawing.Size(775, 20);
            this.tb_LabelGroupPath.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbb_GroupingPrinter);
            this.groupBox3.Controls.Add(this.btn_OpenLabelImagePath);
            this.groupBox3.Controls.Add(this.btn_OpenLabelPath);
            this.groupBox3.Controls.Add(this.tb_LabelGroupImagePath);
            this.groupBox3.Controls.Add(this.tb_LabelGroupPath);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(26, 368);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1040, 118);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "GROUPING LABEL";
            // 
            // cbb_GroupingPrinter
            // 
            this.cbb_GroupingPrinter.FormattingEnabled = true;
            this.cbb_GroupingPrinter.Location = new System.Drawing.Point(168, 83);
            this.cbb_GroupingPrinter.Name = "cbb_GroupingPrinter";
            this.cbb_GroupingPrinter.Size = new System.Drawing.Size(775, 21);
            this.cbb_GroupingPrinter.TabIndex = 11;
            // 
            // btn_OpenLabelImagePath
            // 
            this.btn_OpenLabelImagePath.Location = new System.Drawing.Point(949, 55);
            this.btn_OpenLabelImagePath.Name = "btn_OpenLabelImagePath";
            this.btn_OpenLabelImagePath.Size = new System.Drawing.Size(75, 23);
            this.btn_OpenLabelImagePath.TabIndex = 10;
            this.btn_OpenLabelImagePath.Text = "PATH";
            this.btn_OpenLabelImagePath.UseVisualStyleBackColor = true;
            this.btn_OpenLabelImagePath.Click += new System.EventHandler(this.btn_OpenLabelImagePath_Click);
            // 
            // btn_OpenLabelPath
            // 
            this.btn_OpenLabelPath.Location = new System.Drawing.Point(949, 26);
            this.btn_OpenLabelPath.Name = "btn_OpenLabelPath";
            this.btn_OpenLabelPath.Size = new System.Drawing.Size(75, 23);
            this.btn_OpenLabelPath.TabIndex = 9;
            this.btn_OpenLabelPath.Text = "PATH";
            this.btn_OpenLabelPath.UseVisualStyleBackColor = true;
            this.btn_OpenLabelPath.Click += new System.EventHandler(this.btn_OpenLabelPath_Click);
            // 
            // tb_LabelGroupImagePath
            // 
            this.tb_LabelGroupImagePath.Location = new System.Drawing.Point(168, 55);
            this.tb_LabelGroupImagePath.Name = "tb_LabelGroupImagePath";
            this.tb_LabelGroupImagePath.Size = new System.Drawing.Size(775, 20);
            this.tb_LabelGroupImagePath.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "GROUPING PRINTER";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "LABEL GROUP IMAGE  PATH";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "INDIVIDUAL PRINTER";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(410, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(274, 37);
            this.label10.TabIndex = 9;
            this.label10.Text = "Auto Bag Setting";
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(909, 613);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 52);
            this.btn_Save.TabIndex = 10;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(990, 613);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 52);
            this.btn_Close.TabIndex = 11;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chb_Traceability);
            this.groupBox4.Controls.Add(this.btn_GenerateNewID);
            this.groupBox4.Controls.Add(this.tb_EquipmentName);
            this.groupBox4.Controls.Add(this.tb_Identity);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(26, 80);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(548, 137);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "EQUIPMENT";
            // 
            // chb_Traceability
            // 
            this.chb_Traceability.AutoSize = true;
            this.chb_Traceability.Location = new System.Drawing.Point(168, 102);
            this.chb_Traceability.Name = "chb_Traceability";
            this.chb_Traceability.Size = new System.Drawing.Size(15, 14);
            this.chb_Traceability.TabIndex = 5;
            this.chb_Traceability.UseVisualStyleBackColor = true;
            // 
            // btn_GenerateNewID
            // 
            this.btn_GenerateNewID.Location = new System.Drawing.Point(465, 32);
            this.btn_GenerateNewID.Name = "btn_GenerateNewID";
            this.btn_GenerateNewID.Size = new System.Drawing.Size(75, 23);
            this.btn_GenerateNewID.TabIndex = 4;
            this.btn_GenerateNewID.Text = "GENERATE";
            this.btn_GenerateNewID.UseVisualStyleBackColor = true;
            this.btn_GenerateNewID.Click += new System.EventHandler(this.btn_GenerateNewID_Click);
            // 
            // tb_EquipmentName
            // 
            this.tb_EquipmentName.Location = new System.Drawing.Point(168, 65);
            this.tb_EquipmentName.Name = "tb_EquipmentName";
            this.tb_EquipmentName.Size = new System.Drawing.Size(271, 20);
            this.tb_EquipmentName.TabIndex = 3;
            // 
            // tb_Identity
            // 
            this.tb_Identity.Location = new System.Drawing.Point(168, 34);
            this.tb_Identity.Name = "tb_Identity";
            this.tb_Identity.Size = new System.Drawing.Size(271, 20);
            this.tb_Identity.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 102);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "TRACEABILITY";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "EQUIPMENT NAME";
            // 
            // btn_Reload
            // 
            this.btn_Reload.Location = new System.Drawing.Point(828, 613);
            this.btn_Reload.Name = "btn_Reload";
            this.btn_Reload.Size = new System.Drawing.Size(75, 52);
            this.btn_Reload.TabIndex = 10;
            this.btn_Reload.Text = "Reload";
            this.btn_Reload.UseVisualStyleBackColor = true;
            this.btn_Reload.Click += new System.EventHandler(this.btn_Reload_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbb_IndividualPrinter);
            this.groupBox5.Controls.Add(this.tb_LabelIndividualPath);
            this.groupBox5.Controls.Add(this.btn_LabelIndividualImagePath);
            this.groupBox5.Controls.Add(this.btn_IndividualLabelpath);
            this.groupBox5.Controls.Add(this.tb_IndividualImagePath);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Location = new System.Drawing.Point(26, 492);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1040, 115);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "INDIVIDUAL LABEL";
            // 
            // cbb_IndividualPrinter
            // 
            this.cbb_IndividualPrinter.FormattingEnabled = true;
            this.cbb_IndividualPrinter.Location = new System.Drawing.Point(165, 70);
            this.cbb_IndividualPrinter.Name = "cbb_IndividualPrinter";
            this.cbb_IndividualPrinter.Size = new System.Drawing.Size(778, 21);
            this.cbb_IndividualPrinter.TabIndex = 11;
            // 
            // tb_LabelIndividualPath
            // 
            this.tb_LabelIndividualPath.Location = new System.Drawing.Point(165, 18);
            this.tb_LabelIndividualPath.Name = "tb_LabelIndividualPath";
            this.tb_LabelIndividualPath.Size = new System.Drawing.Size(778, 20);
            this.tb_LabelIndividualPath.TabIndex = 8;
            // 
            // btn_LabelIndividualImagePath
            // 
            this.btn_LabelIndividualImagePath.Location = new System.Drawing.Point(949, 44);
            this.btn_LabelIndividualImagePath.Name = "btn_LabelIndividualImagePath";
            this.btn_LabelIndividualImagePath.Size = new System.Drawing.Size(75, 23);
            this.btn_LabelIndividualImagePath.TabIndex = 10;
            this.btn_LabelIndividualImagePath.Text = "PATH";
            this.btn_LabelIndividualImagePath.UseVisualStyleBackColor = true;
            this.btn_LabelIndividualImagePath.Click += new System.EventHandler(this.btn_LabelIndividualImagePath_Click);
            // 
            // btn_IndividualLabelpath
            // 
            this.btn_IndividualLabelpath.Location = new System.Drawing.Point(949, 14);
            this.btn_IndividualLabelpath.Name = "btn_IndividualLabelpath";
            this.btn_IndividualLabelpath.Size = new System.Drawing.Size(75, 23);
            this.btn_IndividualLabelpath.TabIndex = 10;
            this.btn_IndividualLabelpath.Text = "PATH";
            this.btn_IndividualLabelpath.UseVisualStyleBackColor = true;
            this.btn_IndividualLabelpath.Click += new System.EventHandler(this.btn_IndividualLabelpath_Click);
            // 
            // tb_IndividualImagePath
            // 
            this.tb_IndividualImagePath.Location = new System.Drawing.Point(165, 47);
            this.tb_IndividualImagePath.Name = "tb_IndividualImagePath";
            this.tb_IndividualImagePath.Size = new System.Drawing.Size(778, 20);
            this.tb_IndividualImagePath.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "LABEL  IMAGE  PATH";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 26);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "LABEL PATH";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbb_BaudRate);
            this.groupBox6.Controls.Add(this.cbb_ComName);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Location = new System.Drawing.Point(581, 224);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(484, 138);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "BARCODE READER";
            // 
            // cbb_BaudRate
            // 
            this.cbb_BaudRate.FormattingEnabled = true;
            this.cbb_BaudRate.Location = new System.Drawing.Point(164, 55);
            this.cbb_BaudRate.Name = "cbb_BaudRate";
            this.cbb_BaudRate.Size = new System.Drawing.Size(121, 21);
            this.cbb_BaudRate.TabIndex = 0;
            // 
            // cbb_ComName
            // 
            this.cbb_ComName.FormattingEnabled = true;
            this.cbb_ComName.Location = new System.Drawing.Point(164, 29);
            this.cbb_ComName.Name = "cbb_ComName";
            this.cbb_ComName.Size = new System.Drawing.Size(121, 21);
            this.cbb_ComName.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 32);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "COM NAME";
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 668);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Reload);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Setting";
            this.Text = "Auto Bag Setting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Setting_FormClosing);
            this.Load += new System.EventHandler(this.Setting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_PLCAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_DataBaseServer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_ReadInterval;
        private System.Windows.Forms.TextBox tb_PLCPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_LabelGroupPath;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tb_LabelGroupImagePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_OpenLabelImagePath;
        private System.Windows.Forms.Button btn_OpenLabelPath;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_GenerateNewID;
        private System.Windows.Forms.TextBox tb_Identity;
        private System.Windows.Forms.TextBox tb_EquipmentName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chb_Traceability;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tb_DataBaseCatalogue;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btn_Reload;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tb_LabelIndividualPath;
        private System.Windows.Forms.Button btn_LabelIndividualImagePath;
        private System.Windows.Forms.Button btn_IndividualLabelpath;
        private System.Windows.Forms.TextBox tb_IndividualImagePath;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cbb_ComName;
        private System.Windows.Forms.ComboBox cbb_BaudRate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbb_GroupingPrinter;
        private System.Windows.Forms.ComboBox cbb_IndividualPrinter;
        private System.Windows.Forms.Label label18;
    }
}