namespace AutoBagBench
{
    partial class Plc
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
            this.tm_Updater = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_PlcAddress = new System.Windows.Forms.Label();
            this.lbl_Port = new System.Windows.Forms.Label();
            this.chb_EmergencySwitch = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chb_M8Sensor = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chb_M12Sensor = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chb_M18Sensor = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chb_M30Sensor = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chb_RejectBin = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chb_ThroughBox = new System.Windows.Forms.CheckBox();
            this.label99 = new System.Windows.Forms.Label();
            this.chb_ThroughBag = new System.Windows.Forms.CheckBox();
            this.label100 = new System.Windows.Forms.Label();
            this.chb_M8OpenSens = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chb_M8CloseSens = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chb_M12OpenSens = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chb_M12CloseSens = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chb_M18OpenSens = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chb_M18CloseSens = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.chb_M30OpenSens = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.chb_M30CloseSens = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.chb_FingerLeft = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.chb_FingerRight = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.chb_M8Selected = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.chb_M12Selected = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.chb_M18Selected = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.chb_M30Selected = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.chb_Sealer = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.chb_Buzzer = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.chb_M8Gate = new System.Windows.Forms.CheckBox();
            this.label27 = new System.Windows.Forms.Label();
            this.chb_M12Gate = new System.Windows.Forms.CheckBox();
            this.label28 = new System.Windows.Forms.Label();
            this.chb_M18Gate = new System.Windows.Forms.CheckBox();
            this.label29 = new System.Windows.Forms.Label();
            this.gb_Input = new System.Windows.Forms.GroupBox();
            this.chb_M30Gate = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chb_C_M30_Gate = new System.Windows.Forms.CheckBox();
            this.chb_C_M18_Gate = new System.Windows.Forms.CheckBox();
            this.chb_C_M12_Gate = new System.Windows.Forms.CheckBox();
            this.chb_C_M8_Gate = new System.Windows.Forms.CheckBox();
            this.chb_C_Buzzer = new System.Windows.Forms.CheckBox();
            this.chb_C_Sealer = new System.Windows.Forms.CheckBox();
            this.chb_C_M30_Selected_Lamp = new System.Windows.Forms.CheckBox();
            this.chb_C_M18_Selected_Lamp = new System.Windows.Forms.CheckBox();
            this.chb_C_M12_Selected_Lamp = new System.Windows.Forms.CheckBox();
            this.chb_C_M8_Selected_Lamp = new System.Windows.Forms.CheckBox();
            this.tm_DisplayUpdater = new System.Windows.Forms.Timer(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.btn_AutoManual = new System.Windows.Forms.Button();
            this.gb_Input.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tm_Updater
            // 
            this.tm_Updater.Tick += new System.EventHandler(this.tm_Updater_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "PLC Address";
            // 
            // lbl_PlcAddress
            // 
            this.lbl_PlcAddress.AutoSize = true;
            this.lbl_PlcAddress.Location = new System.Drawing.Point(102, 81);
            this.lbl_PlcAddress.Name = "lbl_PlcAddress";
            this.lbl_PlcAddress.Size = new System.Drawing.Size(35, 13);
            this.lbl_PlcAddress.TabIndex = 3;
            this.lbl_PlcAddress.Text = "label2";
            // 
            // lbl_Port
            // 
            this.lbl_Port.AutoSize = true;
            this.lbl_Port.Location = new System.Drawing.Point(197, 81);
            this.lbl_Port.Name = "lbl_Port";
            this.lbl_Port.Size = new System.Drawing.Size(35, 13);
            this.lbl_Port.TabIndex = 3;
            this.lbl_Port.Text = "label2";
            // 
            // chb_EmergencySwitch
            // 
            this.chb_EmergencySwitch.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_EmergencySwitch.AutoSize = true;
            this.chb_EmergencySwitch.Enabled = false;
            this.chb_EmergencySwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_EmergencySwitch.Location = new System.Drawing.Point(25, 23);
            this.chb_EmergencySwitch.Name = "chb_EmergencySwitch";
            this.chb_EmergencySwitch.Size = new System.Drawing.Size(35, 23);
            this.chb_EmergencySwitch.TabIndex = 4;
            this.chb_EmergencySwitch.Text = "I0.0";
            this.chb_EmergencySwitch.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Emergency Switch";
            // 
            // chb_M8Sensor
            // 
            this.chb_M8Sensor.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_M8Sensor.AutoSize = true;
            this.chb_M8Sensor.Enabled = false;
            this.chb_M8Sensor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_M8Sensor.Location = new System.Drawing.Point(25, 52);
            this.chb_M8Sensor.Name = "chb_M8Sensor";
            this.chb_M8Sensor.Size = new System.Drawing.Size(35, 23);
            this.chb_M8Sensor.TabIndex = 4;
            this.chb_M8Sensor.Text = "I0.1";
            this.chb_M8Sensor.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Accessories M8 Sensor";
            // 
            // chb_M12Sensor
            // 
            this.chb_M12Sensor.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_M12Sensor.AutoSize = true;
            this.chb_M12Sensor.Enabled = false;
            this.chb_M12Sensor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_M12Sensor.Location = new System.Drawing.Point(25, 81);
            this.chb_M12Sensor.Name = "chb_M12Sensor";
            this.chb_M12Sensor.Size = new System.Drawing.Size(35, 23);
            this.chb_M12Sensor.TabIndex = 4;
            this.chb_M12Sensor.Text = "I0.2";
            this.chb_M12Sensor.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Accessories M12 Sensor";
            // 
            // chb_M18Sensor
            // 
            this.chb_M18Sensor.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_M18Sensor.AutoSize = true;
            this.chb_M18Sensor.Enabled = false;
            this.chb_M18Sensor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_M18Sensor.Location = new System.Drawing.Point(25, 110);
            this.chb_M18Sensor.Name = "chb_M18Sensor";
            this.chb_M18Sensor.Size = new System.Drawing.Size(35, 23);
            this.chb_M18Sensor.TabIndex = 4;
            this.chb_M18Sensor.Text = "I0.3";
            this.chb_M18Sensor.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Accessories M18 Sensor";
            // 
            // chb_M30Sensor
            // 
            this.chb_M30Sensor.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_M30Sensor.AutoSize = true;
            this.chb_M30Sensor.Enabled = false;
            this.chb_M30Sensor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_M30Sensor.Location = new System.Drawing.Point(25, 139);
            this.chb_M30Sensor.Name = "chb_M30Sensor";
            this.chb_M30Sensor.Size = new System.Drawing.Size(35, 23);
            this.chb_M30Sensor.TabIndex = 4;
            this.chb_M30Sensor.Text = "I0.4";
            this.chb_M30Sensor.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(66, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Accessories M30 Sensor";
            // 
            // chb_RejectBin
            // 
            this.chb_RejectBin.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_RejectBin.AutoSize = true;
            this.chb_RejectBin.Enabled = false;
            this.chb_RejectBin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_RejectBin.Location = new System.Drawing.Point(25, 168);
            this.chb_RejectBin.Name = "chb_RejectBin";
            this.chb_RejectBin.Size = new System.Drawing.Size(35, 23);
            this.chb_RejectBin.TabIndex = 4;
            this.chb_RejectBin.Text = "I0.5";
            this.chb_RejectBin.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(66, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Reject Bin Sensor";
            // 
            // chb_ThroughBox
            // 
            this.chb_ThroughBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_ThroughBox.AutoSize = true;
            this.chb_ThroughBox.Enabled = false;
            this.chb_ThroughBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_ThroughBox.Location = new System.Drawing.Point(25, 197);
            this.chb_ThroughBox.Name = "chb_ThroughBox";
            this.chb_ThroughBox.Size = new System.Drawing.Size(35, 23);
            this.chb_ThroughBox.TabIndex = 4;
            this.chb_ThroughBox.Text = "I0.6";
            this.chb_ThroughBox.UseVisualStyleBackColor = true;
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(66, 205);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(142, 13);
            this.label99.TabIndex = 5;
            this.label99.Text = "Bag Through To Box Sensor";
            // 
            // chb_ThroughBag
            // 
            this.chb_ThroughBag.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_ThroughBag.AutoSize = true;
            this.chb_ThroughBag.Enabled = false;
            this.chb_ThroughBag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_ThroughBag.Location = new System.Drawing.Point(25, 226);
            this.chb_ThroughBag.Name = "chb_ThroughBag";
            this.chb_ThroughBag.Size = new System.Drawing.Size(35, 23);
            this.chb_ThroughBag.TabIndex = 4;
            this.chb_ThroughBag.Text = "I0.0";
            this.chb_ThroughBag.UseVisualStyleBackColor = true;
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Location = new System.Drawing.Point(66, 234);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(125, 13);
            this.label100.TabIndex = 5;
            this.label100.Text = "Product Through To Bag";
            // 
            // chb_M8OpenSens
            // 
            this.chb_M8OpenSens.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_M8OpenSens.AutoSize = true;
            this.chb_M8OpenSens.Enabled = false;
            this.chb_M8OpenSens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_M8OpenSens.Location = new System.Drawing.Point(25, 255);
            this.chb_M8OpenSens.Name = "chb_M8OpenSens";
            this.chb_M8OpenSens.Size = new System.Drawing.Size(35, 23);
            this.chb_M8OpenSens.TabIndex = 4;
            this.chb_M8OpenSens.Text = "I0.0";
            this.chb_M8OpenSens.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(66, 263);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Accessoriess M8 Open Sensor";
            // 
            // chb_M8CloseSens
            // 
            this.chb_M8CloseSens.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_M8CloseSens.AutoSize = true;
            this.chb_M8CloseSens.Enabled = false;
            this.chb_M8CloseSens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_M8CloseSens.Location = new System.Drawing.Point(25, 284);
            this.chb_M8CloseSens.Name = "chb_M8CloseSens";
            this.chb_M8CloseSens.Size = new System.Drawing.Size(35, 23);
            this.chb_M8CloseSens.TabIndex = 4;
            this.chb_M8CloseSens.Text = "I0.0";
            this.chb_M8CloseSens.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(66, 292);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(158, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Accessoriess M8 Closed Sensor";
            // 
            // chb_M12OpenSens
            // 
            this.chb_M12OpenSens.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_M12OpenSens.AutoSize = true;
            this.chb_M12OpenSens.Enabled = false;
            this.chb_M12OpenSens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_M12OpenSens.Location = new System.Drawing.Point(25, 313);
            this.chb_M12OpenSens.Name = "chb_M12OpenSens";
            this.chb_M12OpenSens.Size = new System.Drawing.Size(35, 23);
            this.chb_M12OpenSens.TabIndex = 4;
            this.chb_M12OpenSens.Text = "I0.0";
            this.chb_M12OpenSens.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(66, 321);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(158, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Accessoriess M12 Open Sensor";
            // 
            // chb_M12CloseSens
            // 
            this.chb_M12CloseSens.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_M12CloseSens.AutoSize = true;
            this.chb_M12CloseSens.Enabled = false;
            this.chb_M12CloseSens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_M12CloseSens.Location = new System.Drawing.Point(25, 342);
            this.chb_M12CloseSens.Name = "chb_M12CloseSens";
            this.chb_M12CloseSens.Size = new System.Drawing.Size(35, 23);
            this.chb_M12CloseSens.TabIndex = 4;
            this.chb_M12CloseSens.Text = "I0.0";
            this.chb_M12CloseSens.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(66, 350);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(158, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Accessoriess M12 Close Sensor";
            // 
            // chb_M18OpenSens
            // 
            this.chb_M18OpenSens.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_M18OpenSens.AutoSize = true;
            this.chb_M18OpenSens.Enabled = false;
            this.chb_M18OpenSens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_M18OpenSens.Location = new System.Drawing.Point(25, 371);
            this.chb_M18OpenSens.Name = "chb_M18OpenSens";
            this.chb_M18OpenSens.Size = new System.Drawing.Size(35, 23);
            this.chb_M18OpenSens.TabIndex = 4;
            this.chb_M18OpenSens.Text = "I0.0";
            this.chb_M18OpenSens.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(66, 379);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(158, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Accessoriess M18 Open Sensor";
            // 
            // chb_M18CloseSens
            // 
            this.chb_M18CloseSens.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_M18CloseSens.AutoSize = true;
            this.chb_M18CloseSens.Enabled = false;
            this.chb_M18CloseSens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_M18CloseSens.Location = new System.Drawing.Point(25, 400);
            this.chb_M18CloseSens.Name = "chb_M18CloseSens";
            this.chb_M18CloseSens.Size = new System.Drawing.Size(35, 23);
            this.chb_M18CloseSens.TabIndex = 4;
            this.chb_M18CloseSens.Text = "I0.0";
            this.chb_M18CloseSens.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(66, 408);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(158, 13);
            this.label15.TabIndex = 5;
            this.label15.Text = "Accessoriess M18 Close Sensor";
            // 
            // chb_M30OpenSens
            // 
            this.chb_M30OpenSens.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_M30OpenSens.AutoSize = true;
            this.chb_M30OpenSens.Enabled = false;
            this.chb_M30OpenSens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_M30OpenSens.Location = new System.Drawing.Point(25, 429);
            this.chb_M30OpenSens.Name = "chb_M30OpenSens";
            this.chb_M30OpenSens.Size = new System.Drawing.Size(35, 23);
            this.chb_M30OpenSens.TabIndex = 4;
            this.chb_M30OpenSens.Text = "I0.0";
            this.chb_M30OpenSens.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(66, 437);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(158, 13);
            this.label16.TabIndex = 5;
            this.label16.Text = "Accessoriess M30 Open Sensor";
            // 
            // chb_M30CloseSens
            // 
            this.chb_M30CloseSens.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_M30CloseSens.AutoSize = true;
            this.chb_M30CloseSens.Enabled = false;
            this.chb_M30CloseSens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_M30CloseSens.Location = new System.Drawing.Point(25, 458);
            this.chb_M30CloseSens.Name = "chb_M30CloseSens";
            this.chb_M30CloseSens.Size = new System.Drawing.Size(35, 23);
            this.chb_M30CloseSens.TabIndex = 4;
            this.chb_M30CloseSens.Text = "I0.0";
            this.chb_M30CloseSens.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(66, 466);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(158, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "Accessoriess M30 Close Sensor";
            // 
            // chb_FingerLeft
            // 
            this.chb_FingerLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_FingerLeft.AutoSize = true;
            this.chb_FingerLeft.Enabled = false;
            this.chb_FingerLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_FingerLeft.Location = new System.Drawing.Point(25, 487);
            this.chb_FingerLeft.Name = "chb_FingerLeft";
            this.chb_FingerLeft.Size = new System.Drawing.Size(35, 23);
            this.chb_FingerLeft.TabIndex = 4;
            this.chb_FingerLeft.Text = "I0.0";
            this.chb_FingerLeft.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(66, 495);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(116, 13);
            this.label18.TabIndex = 5;
            this.label18.Text = "Finger Switch Left Side";
            // 
            // chb_FingerRight
            // 
            this.chb_FingerRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_FingerRight.AutoSize = true;
            this.chb_FingerRight.Enabled = false;
            this.chb_FingerRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_FingerRight.Location = new System.Drawing.Point(25, 516);
            this.chb_FingerRight.Name = "chb_FingerRight";
            this.chb_FingerRight.Size = new System.Drawing.Size(35, 23);
            this.chb_FingerRight.TabIndex = 4;
            this.chb_FingerRight.Text = "I0.0";
            this.chb_FingerRight.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(66, 524);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(123, 13);
            this.label19.TabIndex = 5;
            this.label19.Text = "Finger Switch Right Side";
            // 
            // chb_M8Selected
            // 
            this.chb_M8Selected.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_M8Selected.AutoSize = true;
            this.chb_M8Selected.Enabled = false;
            this.chb_M8Selected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_M8Selected.Location = new System.Drawing.Point(57, 26);
            this.chb_M8Selected.Name = "chb_M8Selected";
            this.chb_M8Selected.Size = new System.Drawing.Size(35, 23);
            this.chb_M8Selected.TabIndex = 4;
            this.chb_M8Selected.Text = "I0.0";
            this.chb_M8Selected.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(98, 34);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(156, 13);
            this.label21.TabIndex = 5;
            this.label21.Text = "Accessories M8 Selected Lamp";
            // 
            // chb_M12Selected
            // 
            this.chb_M12Selected.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_M12Selected.AutoSize = true;
            this.chb_M12Selected.Enabled = false;
            this.chb_M12Selected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_M12Selected.Location = new System.Drawing.Point(57, 55);
            this.chb_M12Selected.Name = "chb_M12Selected";
            this.chb_M12Selected.Size = new System.Drawing.Size(35, 23);
            this.chb_M12Selected.TabIndex = 4;
            this.chb_M12Selected.Text = "I0.0";
            this.chb_M12Selected.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(98, 63);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(162, 13);
            this.label22.TabIndex = 5;
            this.label22.Text = "Accessories M12 Selected Lamp";
            // 
            // chb_M18Selected
            // 
            this.chb_M18Selected.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_M18Selected.AutoSize = true;
            this.chb_M18Selected.Enabled = false;
            this.chb_M18Selected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_M18Selected.Location = new System.Drawing.Point(57, 84);
            this.chb_M18Selected.Name = "chb_M18Selected";
            this.chb_M18Selected.Size = new System.Drawing.Size(35, 23);
            this.chb_M18Selected.TabIndex = 4;
            this.chb_M18Selected.Text = "I0.0";
            this.chb_M18Selected.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(98, 92);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(162, 13);
            this.label23.TabIndex = 5;
            this.label23.Text = "Accessories M18 Selected Lamp";
            // 
            // chb_M30Selected
            // 
            this.chb_M30Selected.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_M30Selected.AutoSize = true;
            this.chb_M30Selected.Enabled = false;
            this.chb_M30Selected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_M30Selected.Location = new System.Drawing.Point(57, 113);
            this.chb_M30Selected.Name = "chb_M30Selected";
            this.chb_M30Selected.Size = new System.Drawing.Size(35, 23);
            this.chb_M30Selected.TabIndex = 4;
            this.chb_M30Selected.Text = "I0.0";
            this.chb_M30Selected.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(98, 121);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(162, 13);
            this.label24.TabIndex = 5;
            this.label24.Text = "Accessories M30 Selected Lamp";
            // 
            // chb_Sealer
            // 
            this.chb_Sealer.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_Sealer.AutoSize = true;
            this.chb_Sealer.Enabled = false;
            this.chb_Sealer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_Sealer.Location = new System.Drawing.Point(57, 142);
            this.chb_Sealer.Name = "chb_Sealer";
            this.chb_Sealer.Size = new System.Drawing.Size(35, 23);
            this.chb_Sealer.TabIndex = 4;
            this.chb_Sealer.Text = "I0.0";
            this.chb_Sealer.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(98, 150);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(37, 13);
            this.label25.TabIndex = 5;
            this.label25.Text = "Sealer";
            // 
            // chb_Buzzer
            // 
            this.chb_Buzzer.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_Buzzer.AutoSize = true;
            this.chb_Buzzer.Enabled = false;
            this.chb_Buzzer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_Buzzer.Location = new System.Drawing.Point(57, 171);
            this.chb_Buzzer.Name = "chb_Buzzer";
            this.chb_Buzzer.Size = new System.Drawing.Size(35, 23);
            this.chb_Buzzer.TabIndex = 4;
            this.chb_Buzzer.Text = "I0.0";
            this.chb_Buzzer.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(98, 179);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(39, 13);
            this.label26.TabIndex = 5;
            this.label26.Text = "Buzzer";
            // 
            // chb_M8Gate
            // 
            this.chb_M8Gate.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_M8Gate.AutoSize = true;
            this.chb_M8Gate.Enabled = false;
            this.chb_M8Gate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_M8Gate.Location = new System.Drawing.Point(57, 200);
            this.chb_M8Gate.Name = "chb_M8Gate";
            this.chb_M8Gate.Size = new System.Drawing.Size(35, 23);
            this.chb_M8Gate.TabIndex = 4;
            this.chb_M8Gate.Text = "I0.0";
            this.chb_M8Gate.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(98, 208);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(108, 13);
            this.label27.TabIndex = 5;
            this.label27.Text = "Accessories M8 Gate";
            // 
            // chb_M12Gate
            // 
            this.chb_M12Gate.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_M12Gate.AutoSize = true;
            this.chb_M12Gate.Enabled = false;
            this.chb_M12Gate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_M12Gate.Location = new System.Drawing.Point(57, 229);
            this.chb_M12Gate.Name = "chb_M12Gate";
            this.chb_M12Gate.Size = new System.Drawing.Size(35, 23);
            this.chb_M12Gate.TabIndex = 4;
            this.chb_M12Gate.Text = "I0.0";
            this.chb_M12Gate.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(98, 237);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(114, 13);
            this.label28.TabIndex = 5;
            this.label28.Text = "Accessories M12 Gate";
            // 
            // chb_M18Gate
            // 
            this.chb_M18Gate.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_M18Gate.AutoSize = true;
            this.chb_M18Gate.Enabled = false;
            this.chb_M18Gate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_M18Gate.Location = new System.Drawing.Point(57, 258);
            this.chb_M18Gate.Name = "chb_M18Gate";
            this.chb_M18Gate.Size = new System.Drawing.Size(35, 23);
            this.chb_M18Gate.TabIndex = 4;
            this.chb_M18Gate.Text = "I0.0";
            this.chb_M18Gate.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(98, 266);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(114, 13);
            this.label29.TabIndex = 5;
            this.label29.Text = "Accessories M18 Gate";
            // 
            // gb_Input
            // 
            this.gb_Input.Controls.Add(this.chb_EmergencySwitch);
            this.gb_Input.Controls.Add(this.chb_M8Sensor);
            this.gb_Input.Controls.Add(this.label19);
            this.gb_Input.Controls.Add(this.chb_M12Sensor);
            this.gb_Input.Controls.Add(this.label18);
            this.gb_Input.Controls.Add(this.chb_M18Sensor);
            this.gb_Input.Controls.Add(this.label17);
            this.gb_Input.Controls.Add(this.chb_M30Sensor);
            this.gb_Input.Controls.Add(this.label16);
            this.gb_Input.Controls.Add(this.chb_RejectBin);
            this.gb_Input.Controls.Add(this.label15);
            this.gb_Input.Controls.Add(this.chb_ThroughBox);
            this.gb_Input.Controls.Add(this.label14);
            this.gb_Input.Controls.Add(this.chb_ThroughBag);
            this.gb_Input.Controls.Add(this.label13);
            this.gb_Input.Controls.Add(this.chb_M8OpenSens);
            this.gb_Input.Controls.Add(this.label12);
            this.gb_Input.Controls.Add(this.chb_M8CloseSens);
            this.gb_Input.Controls.Add(this.label11);
            this.gb_Input.Controls.Add(this.chb_M12OpenSens);
            this.gb_Input.Controls.Add(this.label10);
            this.gb_Input.Controls.Add(this.chb_M12CloseSens);
            this.gb_Input.Controls.Add(this.label100);
            this.gb_Input.Controls.Add(this.chb_M18OpenSens);
            this.gb_Input.Controls.Add(this.label99);
            this.gb_Input.Controls.Add(this.chb_M18CloseSens);
            this.gb_Input.Controls.Add(this.label7);
            this.gb_Input.Controls.Add(this.chb_M30OpenSens);
            this.gb_Input.Controls.Add(this.label6);
            this.gb_Input.Controls.Add(this.chb_M30CloseSens);
            this.gb_Input.Controls.Add(this.label5);
            this.gb_Input.Controls.Add(this.chb_FingerLeft);
            this.gb_Input.Controls.Add(this.label4);
            this.gb_Input.Controls.Add(this.chb_FingerRight);
            this.gb_Input.Controls.Add(this.label3);
            this.gb_Input.Controls.Add(this.label2);
            this.gb_Input.Location = new System.Drawing.Point(32, 115);
            this.gb_Input.Name = "gb_Input";
            this.gb_Input.Size = new System.Drawing.Size(305, 553);
            this.gb_Input.TabIndex = 6;
            this.gb_Input.TabStop = false;
            this.gb_Input.Text = "INPUT";
            // 
            // chb_M30Gate
            // 
            this.chb_M30Gate.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_M30Gate.AutoSize = true;
            this.chb_M30Gate.Enabled = false;
            this.chb_M30Gate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_M30Gate.Location = new System.Drawing.Point(57, 287);
            this.chb_M30Gate.Name = "chb_M30Gate";
            this.chb_M30Gate.Size = new System.Drawing.Size(35, 23);
            this.chb_M30Gate.TabIndex = 4;
            this.chb_M30Gate.Text = "I0.0";
            this.chb_M30Gate.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(98, 295);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(114, 13);
            this.label20.TabIndex = 5;
            this.label20.Text = "Accessories M30 Gate";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chb_C_M30_Gate);
            this.groupBox1.Controls.Add(this.chb_C_M18_Gate);
            this.groupBox1.Controls.Add(this.chb_C_M12_Gate);
            this.groupBox1.Controls.Add(this.chb_C_M8_Gate);
            this.groupBox1.Controls.Add(this.chb_C_Buzzer);
            this.groupBox1.Controls.Add(this.chb_C_Sealer);
            this.groupBox1.Controls.Add(this.chb_C_M30_Selected_Lamp);
            this.groupBox1.Controls.Add(this.chb_C_M18_Selected_Lamp);
            this.groupBox1.Controls.Add(this.chb_C_M12_Selected_Lamp);
            this.groupBox1.Controls.Add(this.chb_C_M8_Selected_Lamp);
            this.groupBox1.Controls.Add(this.chb_M8Selected);
            this.groupBox1.Controls.Add(this.chb_M12Selected);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.chb_M18Selected);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.chb_M30Selected);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.chb_Sealer);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.chb_Buzzer);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.chb_M8Gate);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.chb_M12Gate);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.chb_M18Gate);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.chb_M30Gate);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Location = new System.Drawing.Point(343, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 553);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OUTPUT";
            // 
            // chb_C_M30_Gate
            // 
            this.chb_C_M30_Gate.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_C_M30_Gate.AutoSize = true;
            this.chb_C_M30_Gate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_C_M30_Gate.Location = new System.Drawing.Point(16, 287);
            this.chb_C_M30_Gate.Name = "chb_C_M30_Gate";
            this.chb_C_M30_Gate.Size = new System.Drawing.Size(35, 23);
            this.chb_C_M30_Gate.TabIndex = 4;
            this.chb_C_M30_Gate.Text = "I0.0";
            this.chb_C_M30_Gate.UseVisualStyleBackColor = true;
            this.chb_C_M30_Gate.CheckedChanged += new System.EventHandler(this.chb_C_M30_Gate_CheckedChanged_1);
            // 
            // chb_C_M18_Gate
            // 
            this.chb_C_M18_Gate.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_C_M18_Gate.AutoSize = true;
            this.chb_C_M18_Gate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_C_M18_Gate.Location = new System.Drawing.Point(16, 258);
            this.chb_C_M18_Gate.Name = "chb_C_M18_Gate";
            this.chb_C_M18_Gate.Size = new System.Drawing.Size(35, 23);
            this.chb_C_M18_Gate.TabIndex = 4;
            this.chb_C_M18_Gate.Text = "I0.0";
            this.chb_C_M18_Gate.UseVisualStyleBackColor = true;
            this.chb_C_M18_Gate.CheckedChanged += new System.EventHandler(this.chb_C_M18_Gate_CheckedChanged);
            // 
            // chb_C_M12_Gate
            // 
            this.chb_C_M12_Gate.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_C_M12_Gate.AutoSize = true;
            this.chb_C_M12_Gate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_C_M12_Gate.Location = new System.Drawing.Point(16, 229);
            this.chb_C_M12_Gate.Name = "chb_C_M12_Gate";
            this.chb_C_M12_Gate.Size = new System.Drawing.Size(35, 23);
            this.chb_C_M12_Gate.TabIndex = 4;
            this.chb_C_M12_Gate.Text = "I0.0";
            this.chb_C_M12_Gate.UseVisualStyleBackColor = true;
            this.chb_C_M12_Gate.CheckedChanged += new System.EventHandler(this.chb_C_M12_Gate_CheckedChanged);
            // 
            // chb_C_M8_Gate
            // 
            this.chb_C_M8_Gate.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_C_M8_Gate.AutoSize = true;
            this.chb_C_M8_Gate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_C_M8_Gate.Location = new System.Drawing.Point(16, 200);
            this.chb_C_M8_Gate.Name = "chb_C_M8_Gate";
            this.chb_C_M8_Gate.Size = new System.Drawing.Size(35, 23);
            this.chb_C_M8_Gate.TabIndex = 4;
            this.chb_C_M8_Gate.Text = "I0.0";
            this.chb_C_M8_Gate.UseVisualStyleBackColor = true;
            this.chb_C_M8_Gate.CheckedChanged += new System.EventHandler(this.chb_C_M8_Gate_CheckedChanged);
            // 
            // chb_C_Buzzer
            // 
            this.chb_C_Buzzer.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_C_Buzzer.AutoSize = true;
            this.chb_C_Buzzer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_C_Buzzer.Location = new System.Drawing.Point(16, 171);
            this.chb_C_Buzzer.Name = "chb_C_Buzzer";
            this.chb_C_Buzzer.Size = new System.Drawing.Size(35, 23);
            this.chb_C_Buzzer.TabIndex = 4;
            this.chb_C_Buzzer.Text = "I0.0";
            this.chb_C_Buzzer.UseVisualStyleBackColor = true;
            this.chb_C_Buzzer.CheckedChanged += new System.EventHandler(this.chb_C_Buzzer_CheckedChanged);
            // 
            // chb_C_Sealer
            // 
            this.chb_C_Sealer.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_C_Sealer.AutoSize = true;
            this.chb_C_Sealer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_C_Sealer.Location = new System.Drawing.Point(16, 142);
            this.chb_C_Sealer.Name = "chb_C_Sealer";
            this.chb_C_Sealer.Size = new System.Drawing.Size(35, 23);
            this.chb_C_Sealer.TabIndex = 4;
            this.chb_C_Sealer.Text = "I0.0";
            this.chb_C_Sealer.UseVisualStyleBackColor = true;
            this.chb_C_Sealer.CheckedChanged += new System.EventHandler(this.chb_C_Sealer_CheckedChanged);
            // 
            // chb_C_M30_Selected_Lamp
            // 
            this.chb_C_M30_Selected_Lamp.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_C_M30_Selected_Lamp.AutoSize = true;
            this.chb_C_M30_Selected_Lamp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_C_M30_Selected_Lamp.Location = new System.Drawing.Point(16, 113);
            this.chb_C_M30_Selected_Lamp.Name = "chb_C_M30_Selected_Lamp";
            this.chb_C_M30_Selected_Lamp.Size = new System.Drawing.Size(35, 23);
            this.chb_C_M30_Selected_Lamp.TabIndex = 4;
            this.chb_C_M30_Selected_Lamp.Text = "I0.0";
            this.chb_C_M30_Selected_Lamp.UseVisualStyleBackColor = true;
            this.chb_C_M30_Selected_Lamp.CheckedChanged += new System.EventHandler(this.chb_C_M30_Selected_Lamp_CheckedChanged);
            // 
            // chb_C_M18_Selected_Lamp
            // 
            this.chb_C_M18_Selected_Lamp.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_C_M18_Selected_Lamp.AutoSize = true;
            this.chb_C_M18_Selected_Lamp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_C_M18_Selected_Lamp.Location = new System.Drawing.Point(16, 84);
            this.chb_C_M18_Selected_Lamp.Name = "chb_C_M18_Selected_Lamp";
            this.chb_C_M18_Selected_Lamp.Size = new System.Drawing.Size(35, 23);
            this.chb_C_M18_Selected_Lamp.TabIndex = 4;
            this.chb_C_M18_Selected_Lamp.Text = "I0.0";
            this.chb_C_M18_Selected_Lamp.UseVisualStyleBackColor = true;
            this.chb_C_M18_Selected_Lamp.CheckedChanged += new System.EventHandler(this.chb_C_M18_Selected_Lamp_CheckedChanged);
            // 
            // chb_C_M12_Selected_Lamp
            // 
            this.chb_C_M12_Selected_Lamp.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_C_M12_Selected_Lamp.AutoSize = true;
            this.chb_C_M12_Selected_Lamp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_C_M12_Selected_Lamp.Location = new System.Drawing.Point(16, 55);
            this.chb_C_M12_Selected_Lamp.Name = "chb_C_M12_Selected_Lamp";
            this.chb_C_M12_Selected_Lamp.Size = new System.Drawing.Size(35, 23);
            this.chb_C_M12_Selected_Lamp.TabIndex = 4;
            this.chb_C_M12_Selected_Lamp.Text = "I0.0";
            this.chb_C_M12_Selected_Lamp.UseVisualStyleBackColor = true;
            this.chb_C_M12_Selected_Lamp.CheckedChanged += new System.EventHandler(this.chb_C_M12_Selected_Lamp_CheckedChanged);
            // 
            // chb_C_M8_Selected_Lamp
            // 
            this.chb_C_M8_Selected_Lamp.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_C_M8_Selected_Lamp.AutoSize = true;
            this.chb_C_M8_Selected_Lamp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_C_M8_Selected_Lamp.Location = new System.Drawing.Point(16, 26);
            this.chb_C_M8_Selected_Lamp.Name = "chb_C_M8_Selected_Lamp";
            this.chb_C_M8_Selected_Lamp.Size = new System.Drawing.Size(35, 23);
            this.chb_C_M8_Selected_Lamp.TabIndex = 4;
            this.chb_C_M8_Selected_Lamp.Text = "I0.0";
            this.chb_C_M8_Selected_Lamp.UseVisualStyleBackColor = true;
            this.chb_C_M8_Selected_Lamp.CheckedChanged += new System.EventHandler(this.chb_C_M8_Selected_Lamp_CheckedChanged);
            // 
            // tm_DisplayUpdater
            // 
            this.tm_DisplayUpdater.Enabled = true;
            this.tm_DisplayUpdater.Interval = 500;
            this.tm_DisplayUpdater.Tick += new System.EventHandler(this.tm_DisplayUpdater_Tick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(128, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(403, 46);
            this.label8.TabIndex = 8;
            this.label8.Text = "PLC INPUT/OUTPUT";
            // 
            // btn_AutoManual
            // 
            this.btn_AutoManual.Location = new System.Drawing.Point(503, 71);
            this.btn_AutoManual.Name = "btn_AutoManual";
            this.btn_AutoManual.Size = new System.Drawing.Size(75, 23);
            this.btn_AutoManual.TabIndex = 9;
            this.btn_AutoManual.Text = "button1";
            this.btn_AutoManual.UseVisualStyleBackColor = true;
            this.btn_AutoManual.Click += new System.EventHandler(this.btn_AutoManual_Click);
            // 
            // Plc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 682);
            this.Controls.Add(this.btn_AutoManual);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_Input);
            this.Controls.Add(this.lbl_Port);
            this.Controls.Add(this.lbl_PlcAddress);
            this.Controls.Add(this.label1);
            this.Name = "Plc";
            this.Text = "PLC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Plc_FormClosing);
            this.Load += new System.EventHandler(this.PLC_Load);
            this.gb_Input.ResumeLayout(false);
            this.gb_Input.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tm_Updater;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_PlcAddress;
        private System.Windows.Forms.Label lbl_Port;
        private System.Windows.Forms.CheckBox chb_EmergencySwitch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chb_M8Sensor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chb_M12Sensor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chb_M18Sensor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chb_M30Sensor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chb_RejectBin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chb_ThroughBox;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.CheckBox chb_ThroughBag;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.CheckBox chb_M8OpenSens;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chb_M8CloseSens;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chb_M12OpenSens;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chb_M12CloseSens;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chb_M18OpenSens;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chb_M18CloseSens;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chb_M30OpenSens;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chb_M30CloseSens;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chb_FingerLeft;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox chb_FingerRight;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox chb_M8Selected;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox chb_M12Selected;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox chb_M18Selected;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.CheckBox chb_M30Selected;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.CheckBox chb_Sealer;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.CheckBox chb_Buzzer;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.CheckBox chb_M8Gate;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.CheckBox chb_M12Gate;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.CheckBox chb_M18Gate;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.GroupBox gb_Input;
        private System.Windows.Forms.CheckBox chb_M30Gate;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chb_C_M30_Gate;
        private System.Windows.Forms.CheckBox chb_C_M18_Gate;
        private System.Windows.Forms.CheckBox chb_C_M12_Gate;
        private System.Windows.Forms.CheckBox chb_C_M8_Gate;
        private System.Windows.Forms.CheckBox chb_C_Buzzer;
        private System.Windows.Forms.CheckBox chb_C_Sealer;
        private System.Windows.Forms.CheckBox chb_C_M30_Selected_Lamp;
        private System.Windows.Forms.CheckBox chb_C_M18_Selected_Lamp;
        private System.Windows.Forms.CheckBox chb_C_M12_Selected_Lamp;
        private System.Windows.Forms.CheckBox chb_C_M8_Selected_Lamp;
        private System.Windows.Forms.Timer tm_DisplayUpdater;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_AutoManual;
    }
}