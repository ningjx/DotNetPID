namespace Demo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.domainUpDown2 = new System.Windows.Forms.DomainUpDown();
            this.domainUpDown3 = new System.Windows.Forms.DomainUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.domainUpDown4 = new System.Windows.Forms.DomainUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 12);
            this.trackBar1.Maximum = 5000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(557, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            this.trackBar1.MouseCaptureChanged += new System.EventHandler(this.trackBar1_MouseCaptureChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(557, 530);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Items.Add("0.01");
            this.domainUpDown1.Items.Add("0.05");
            this.domainUpDown1.Items.Add("0.08");
            this.domainUpDown1.Items.Add("0.1");
            this.domainUpDown1.Items.Add("0.2");
            this.domainUpDown1.Items.Add("0.3");
            this.domainUpDown1.Items.Add("0.4");
            this.domainUpDown1.Items.Add("0.5");
            this.domainUpDown1.Items.Add("0.6");
            this.domainUpDown1.Items.Add("0.7");
            this.domainUpDown1.Items.Add("0.8");
            this.domainUpDown1.Items.Add("0.9");
            this.domainUpDown1.Items.Add("1");
            this.domainUpDown1.Location = new System.Drawing.Point(666, 223);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(120, 21);
            this.domainUpDown1.TabIndex = 3;
            this.domainUpDown1.Text = "0.05";
            // 
            // domainUpDown2
            // 
            this.domainUpDown2.Items.Add("0.01");
            this.domainUpDown2.Items.Add("0.05");
            this.domainUpDown2.Items.Add("0.08");
            this.domainUpDown2.Items.Add("0.1");
            this.domainUpDown2.Items.Add("0.2");
            this.domainUpDown2.Items.Add("0.3");
            this.domainUpDown2.Items.Add("0.4");
            this.domainUpDown2.Items.Add("0.5");
            this.domainUpDown2.Items.Add("0.6");
            this.domainUpDown2.Items.Add("0.7");
            this.domainUpDown2.Items.Add("0.8");
            this.domainUpDown2.Items.Add("0.9");
            this.domainUpDown2.Items.Add("1");
            this.domainUpDown2.Location = new System.Drawing.Point(666, 281);
            this.domainUpDown2.Name = "domainUpDown2";
            this.domainUpDown2.Size = new System.Drawing.Size(120, 21);
            this.domainUpDown2.TabIndex = 4;
            this.domainUpDown2.Text = "0.3";
            // 
            // domainUpDown3
            // 
            this.domainUpDown3.Items.Add("0.01");
            this.domainUpDown3.Items.Add("0.05");
            this.domainUpDown3.Items.Add("0.08");
            this.domainUpDown3.Items.Add("0.1");
            this.domainUpDown3.Items.Add("0.2");
            this.domainUpDown3.Items.Add("0.3");
            this.domainUpDown3.Items.Add("0.4");
            this.domainUpDown3.Items.Add("0.5");
            this.domainUpDown3.Items.Add("0.6");
            this.domainUpDown3.Items.Add("0.7");
            this.domainUpDown3.Items.Add("0.8");
            this.domainUpDown3.Items.Add("0.9");
            this.domainUpDown3.Items.Add("1");
            this.domainUpDown3.Location = new System.Drawing.Point(666, 339);
            this.domainUpDown3.Name = "domainUpDown3";
            this.domainUpDown3.Size = new System.Drawing.Size(120, 21);
            this.domainUpDown3.TabIndex = 5;
            this.domainUpDown3.Text = "0.02";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "增量型",
            "位置型"});
            this.comboBox1.Location = new System.Drawing.Point(666, 170);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Text = "增量型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(589, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "选择PID类型";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(598, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "比例参数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(598, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "积分参数";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(598, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "微分参数";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(598, 399);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "最大增量";
            // 
            // domainUpDown4
            // 
            this.domainUpDown4.Items.Add("无限制");
            this.domainUpDown4.Items.Add("10");
            this.domainUpDown4.Items.Add("20");
            this.domainUpDown4.Items.Add("30");
            this.domainUpDown4.Items.Add("40");
            this.domainUpDown4.Items.Add("50");
            this.domainUpDown4.Items.Add("60");
            this.domainUpDown4.Items.Add("70");
            this.domainUpDown4.Items.Add("80");
            this.domainUpDown4.Items.Add("90");
            this.domainUpDown4.Items.Add("100");
            this.domainUpDown4.Items.Add("200");
            this.domainUpDown4.Items.Add("300");
            this.domainUpDown4.Items.Add("400");
            this.domainUpDown4.Items.Add("500");
            this.domainUpDown4.Location = new System.Drawing.Point(666, 397);
            this.domainUpDown4.Name = "domainUpDown4";
            this.domainUpDown4.Size = new System.Drawing.Size(120, 21);
            this.domainUpDown4.TabIndex = 11;
            this.domainUpDown4.Text = "无限制";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(666, 447);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 21);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "20";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(589, 450);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "刷新频率毫秒";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 605);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.domainUpDown4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.domainUpDown3);
            this.Controls.Add(this.domainUpDown2);
            this.Controls.Add(this.domainUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.trackBar1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.DomainUpDown domainUpDown2;
        private System.Windows.Forms.DomainUpDown domainUpDown3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DomainUpDown domainUpDown4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
    }
}

