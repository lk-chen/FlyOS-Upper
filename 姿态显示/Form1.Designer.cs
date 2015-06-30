namespace 姿态显示
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.lblUARTName = new System.Windows.Forms.Label();
            this.lblUARTBaud = new System.Windows.Forms.Label();
            this.cmbUARTName = new System.Windows.Forms.ComboBox();
            this.cmbUARTBaud = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblNewLine = new System.Windows.Forms.Label();
            this.cmbNewLine = new System.Windows.Forms.ComboBox();
            this.tbcShowData = new System.Windows.Forms.TabControl();
            this.tbpFigure = new System.Windows.Forms.TabPage();
            this.tbpText = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ckbDTR = new System.Windows.Forms.CheckBox();
            this.ckbRTS = new System.Windows.Forms.CheckBox();
            this.btnDataClear = new System.Windows.Forms.Button();
            this.cmbDataNum = new System.Windows.Forms.ComboBox();
            this.lblDataNum = new System.Windows.Forms.Label();
            this.drawTimer = new System.Windows.Forms.Timer(this.components);
            this.lblState = new System.Windows.Forms.Label();
            this.tbcShowData.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.ReadTimeout = 100;
            this.serialPort1.WriteTimeout = 100;
            // 
            // lblUARTName
            // 
            this.lblUARTName.AutoSize = true;
            this.lblUARTName.Location = new System.Drawing.Point(43, 21);
            this.lblUARTName.Name = "lblUARTName";
            this.lblUARTName.Size = new System.Drawing.Size(41, 12);
            this.lblUARTName.TabIndex = 1;
            this.lblUARTName.Text = "串口号";
            // 
            // lblUARTBaud
            // 
            this.lblUARTBaud.AutoSize = true;
            this.lblUARTBaud.Location = new System.Drawing.Point(242, 21);
            this.lblUARTBaud.Name = "lblUARTBaud";
            this.lblUARTBaud.Size = new System.Drawing.Size(41, 12);
            this.lblUARTBaud.TabIndex = 2;
            this.lblUARTBaud.Text = "波特率";
            // 
            // cmbUARTName
            // 
            this.cmbUARTName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUARTName.FormattingEnabled = true;
            this.cmbUARTName.Location = new System.Drawing.Point(101, 18);
            this.cmbUARTName.Name = "cmbUARTName";
            this.cmbUARTName.Size = new System.Drawing.Size(121, 20);
            this.cmbUARTName.TabIndex = 3;
            // 
            // cmbUARTBaud
            // 
            this.cmbUARTBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUARTBaud.FormattingEnabled = true;
            this.cmbUARTBaud.Items.AddRange(new object[] {
            "9600",
            "115200",
            "256000"});
            this.cmbUARTBaud.Location = new System.Drawing.Point(289, 21);
            this.cmbUARTBaud.Name = "cmbUARTBaud";
            this.cmbUARTBaud.Size = new System.Drawing.Size(121, 20);
            this.cmbUARTBaud.TabIndex = 4;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(447, 19);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblNewLine
            // 
            this.lblNewLine.AutoSize = true;
            this.lblNewLine.Location = new System.Drawing.Point(43, 57);
            this.lblNewLine.Name = "lblNewLine";
            this.lblNewLine.Size = new System.Drawing.Size(53, 12);
            this.lblNewLine.TabIndex = 6;
            this.lblNewLine.Text = "换行符号";
            // 
            // cmbNewLine
            // 
            this.cmbNewLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNewLine.FormattingEnabled = true;
            this.cmbNewLine.Items.AddRange(new object[] {
            "\\r\\n",
            "\\n"});
            this.cmbNewLine.Location = new System.Drawing.Point(102, 54);
            this.cmbNewLine.Name = "cmbNewLine";
            this.cmbNewLine.Size = new System.Drawing.Size(121, 20);
            this.cmbNewLine.TabIndex = 7;
            this.cmbNewLine.SelectedIndexChanged += new System.EventHandler(this.cmbNewLine_SelectedIndexChanged);
            // 
            // tbcShowData
            // 
            this.tbcShowData.Controls.Add(this.tbpFigure);
            this.tbcShowData.Controls.Add(this.tbpText);
            this.tbcShowData.Location = new System.Drawing.Point(45, 122);
            this.tbcShowData.Name = "tbcShowData";
            this.tbcShowData.SelectedIndex = 0;
            this.tbcShowData.Size = new System.Drawing.Size(200, 100);
            this.tbcShowData.TabIndex = 8;
            // 
            // tbpFigure
            // 
            this.tbpFigure.Location = new System.Drawing.Point(4, 22);
            this.tbpFigure.Name = "tbpFigure";
            this.tbpFigure.Padding = new System.Windows.Forms.Padding(3);
            this.tbpFigure.Size = new System.Drawing.Size(192, 74);
            this.tbpFigure.TabIndex = 0;
            this.tbpFigure.Text = "曲线";
            this.tbpFigure.UseVisualStyleBackColor = true;
            // 
            // tbpText
            // 
            this.tbpText.Location = new System.Drawing.Point(4, 22);
            this.tbpText.Name = "tbpText";
            this.tbpText.Padding = new System.Windows.Forms.Padding(3);
            this.tbpText.Size = new System.Drawing.Size(192, 74);
            this.tbpText.TabIndex = 1;
            this.tbpText.Text = "文本";
            this.tbpText.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ckbDTR
            // 
            this.ckbDTR.AutoSize = true;
            this.ckbDTR.Location = new System.Drawing.Point(244, 56);
            this.ckbDTR.Name = "ckbDTR";
            this.ckbDTR.Size = new System.Drawing.Size(42, 16);
            this.ckbDTR.TabIndex = 9;
            this.ckbDTR.Text = "DTR";
            this.ckbDTR.UseVisualStyleBackColor = true;
            this.ckbDTR.CheckedChanged += new System.EventHandler(this.ckbDTR_CheckedChanged);
            // 
            // ckbRTS
            // 
            this.ckbRTS.AutoSize = true;
            this.ckbRTS.Location = new System.Drawing.Point(303, 56);
            this.ckbRTS.Name = "ckbRTS";
            this.ckbRTS.Size = new System.Drawing.Size(42, 16);
            this.ckbRTS.TabIndex = 10;
            this.ckbRTS.Text = "RTS";
            this.ckbRTS.UseVisualStyleBackColor = true;
            this.ckbRTS.CheckedChanged += new System.EventHandler(this.ckbRTS_CheckedChanged);
            // 
            // btnDataClear
            // 
            this.btnDataClear.Location = new System.Drawing.Point(557, 16);
            this.btnDataClear.Name = "btnDataClear";
            this.btnDataClear.Size = new System.Drawing.Size(75, 23);
            this.btnDataClear.TabIndex = 11;
            this.btnDataClear.Text = "清空";
            this.btnDataClear.UseVisualStyleBackColor = true;
            this.btnDataClear.Click += new System.EventHandler(this.btnTextClear_Click);
            // 
            // cmbDataNum
            // 
            this.cmbDataNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataNum.FormattingEnabled = true;
            this.cmbDataNum.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cmbDataNum.Location = new System.Drawing.Point(511, 57);
            this.cmbDataNum.Name = "cmbDataNum";
            this.cmbDataNum.Size = new System.Drawing.Size(121, 20);
            this.cmbDataNum.TabIndex = 12;
            this.cmbDataNum.SelectedIndexChanged += new System.EventHandler(this.cmbDataNum_SelectedIndexChanged);
            // 
            // lblDataNum
            // 
            this.lblDataNum.AutoSize = true;
            this.lblDataNum.Location = new System.Drawing.Point(445, 65);
            this.lblDataNum.Name = "lblDataNum";
            this.lblDataNum.Size = new System.Drawing.Size(65, 12);
            this.lblDataNum.TabIndex = 13;
            this.lblDataNum.Text = "每行数据量";
            // 
            // drawTimer
            // 
            this.drawTimer.Enabled = true;
            this.drawTimer.Tick += new System.EventHandler(this.drawTimer_Tick);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(47, 269);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(797, 108);
            this.lblState.TabIndex = 14;
            this.lblState.Text = resources.GetString("lblState.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 621);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblDataNum);
            this.Controls.Add(this.cmbDataNum);
            this.Controls.Add(this.btnDataClear);
            this.Controls.Add(this.ckbRTS);
            this.Controls.Add(this.ckbDTR);
            this.Controls.Add(this.tbcShowData);
            this.Controls.Add(this.cmbNewLine);
            this.Controls.Add(this.lblNewLine);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cmbUARTBaud);
            this.Controls.Add(this.cmbUARTName);
            this.Controls.Add(this.lblUARTBaud);
            this.Controls.Add(this.lblUARTName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "姿态显示";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tbcShowData.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label lblUARTName;
        private System.Windows.Forms.Label lblUARTBaud;
        private System.Windows.Forms.ComboBox cmbUARTName;
        private System.Windows.Forms.ComboBox cmbUARTBaud;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblNewLine;
        private System.Windows.Forms.ComboBox cmbNewLine;
        private System.Windows.Forms.TabControl tbcShowData;
        private System.Windows.Forms.TabPage tbpFigure;
        private System.Windows.Forms.TabPage tbpText;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox ckbDTR;
        private System.Windows.Forms.CheckBox ckbRTS;
        private System.Windows.Forms.Button btnDataClear;
        private System.Windows.Forms.ComboBox cmbDataNum;
        private System.Windows.Forms.Label lblDataNum;
        private System.Windows.Forms.Timer drawTimer;
        private System.Windows.Forms.Label lblState;
    }
}

