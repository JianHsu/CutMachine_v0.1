namespace CutMachine_v0._1
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.captureBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.step1Box = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.step2Box = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.step3Box = new System.Windows.Forms.PictureBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.motorStep = new System.Windows.Forms.TextBox();
            this.rangeWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rangeHeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.searchBtn = new System.Windows.Forms.Button();
            this.sendBtn = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.captureBox = new System.Windows.Forms.PictureBox();
            this.finalBox = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.step1Box)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.step2Box)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.step3Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.captureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finalBox)).BeginInit();
            this.SuspendLayout();
            // 
            // captureBtn
            // 
            this.captureBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.captureBtn.Font = new System.Drawing.Font("新細明體", 12F);
            this.captureBtn.Location = new System.Drawing.Point(0, 114);
            this.captureBtn.Name = "captureBtn";
            this.captureBtn.Size = new System.Drawing.Size(249, 66);
            this.captureBtn.TabIndex = 2;
            this.captureBtn.Text = "捕捉影像";
            this.captureBtn.UseVisualStyleBackColor = true;
            this.captureBtn.Click += new System.EventHandler(this.captureBtn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.ItemSize = new System.Drawing.Size(90, 30);
            this.tabControl1.Location = new System.Drawing.Point(615, 850);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(3, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(890, 894);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(8, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(874, 848);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "原始圖";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.step1Box);
            this.tabPage2.Location = new System.Drawing.Point(8, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(874, 848);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Step1";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // step1Box
            // 
            this.step1Box.BackColor = System.Drawing.Color.Transparent;
            this.step1Box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.step1Box.Location = new System.Drawing.Point(3, 3);
            this.step1Box.Name = "step1Box";
            this.step1Box.Size = new System.Drawing.Size(868, 842);
            this.step1Box.TabIndex = 1;
            this.step1Box.TabStop = false;
            this.step1Box.Resize += new System.EventHandler(this.step1Box_Resize);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.step2Box);
            this.tabPage3.Location = new System.Drawing.Point(8, 38);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(874, 848);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Step2";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // step2Box
            // 
            this.step2Box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.step2Box.Location = new System.Drawing.Point(3, 3);
            this.step2Box.Name = "step2Box";
            this.step2Box.Size = new System.Drawing.Size(868, 842);
            this.step2Box.TabIndex = 1;
            this.step2Box.TabStop = false;
            this.step2Box.Resize += new System.EventHandler(this.step1Box_Resize);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.step3Box);
            this.tabPage4.Location = new System.Drawing.Point(8, 38);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(874, 848);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Step3";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // step3Box
            // 
            this.step3Box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.step3Box.Location = new System.Drawing.Point(3, 3);
            this.step3Box.Name = "step3Box";
            this.step3Box.Size = new System.Drawing.Size(868, 842);
            this.step3Box.TabIndex = 1;
            this.step3Box.TabStop = false;
            this.step3Box.Resize += new System.EventHandler(this.step1Box_Resize);
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(8, 38);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(874, 848);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "切割圖";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F);
            this.label2.Location = new System.Drawing.Point(16, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "馬達步距";
            // 
            // motorStep
            // 
            this.motorStep.Location = new System.Drawing.Point(227, 34);
            this.motorStep.Name = "motorStep";
            this.motorStep.Size = new System.Drawing.Size(146, 36);
            this.motorStep.TabIndex = 5;
            this.motorStep.Text = "0.2";
            this.motorStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.motorStep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.motorStep_KeyPress);
            // 
            // rangeWidth
            // 
            this.rangeWidth.Location = new System.Drawing.Point(227, 34);
            this.rangeWidth.Name = "rangeWidth";
            this.rangeWidth.Size = new System.Drawing.Size(146, 36);
            this.rangeWidth.TabIndex = 7;
            this.rangeWidth.Text = "260";
            this.rangeWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rangeWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rangeWidth_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 12F);
            this.label3.Location = new System.Drawing.Point(16, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "切割範圍(寬)";
            // 
            // rangeHeight
            // 
            this.rangeHeight.Location = new System.Drawing.Point(227, 34);
            this.rangeHeight.Name = "rangeHeight";
            this.rangeHeight.Size = new System.Drawing.Size(146, 36);
            this.rangeHeight.TabIndex = 9;
            this.rangeHeight.Text = "320";
            this.rangeHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rangeHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rangeHeight_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 12F);
            this.label4.Location = new System.Drawing.Point(16, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 32);
            this.label4.TabIndex = 8;
            this.label4.Text = "切割範圍(高)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(391, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "(mm)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(391, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "(mm)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(391, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 24);
            this.label7.TabIndex = 12;
            this.label7.Text = "(mm)";
            // 
            // searchBtn
            // 
            this.searchBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.searchBtn.Font = new System.Drawing.Font("新細明體", 12F);
            this.searchBtn.Location = new System.Drawing.Point(0, 180);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(249, 66);
            this.searchBtn.TabIndex = 13;
            this.searchBtn.Text = "偵測邊緣";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // sendBtn
            // 
            this.sendBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sendBtn.Font = new System.Drawing.Font("新細明體", 12F);
            this.sendBtn.Location = new System.Drawing.Point(0, 246);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(249, 66);
            this.sendBtn.TabIndex = 14;
            this.sendBtn.Text = "開始切割";
            this.sendBtn.UseVisualStyleBackColor = true;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(498, 883);
            this.panel1.TabIndex = 15;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 571);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(498, 312);
            this.panel5.TabIndex = 19;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.captureBtn);
            this.panel8.Controls.Add(this.searchBtn);
            this.panel8.Controls.Add(this.sendBtn);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(249, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(249, 312);
            this.panel8.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(249, 312);
            this.panel6.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.motorStep);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 300);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(498, 100);
            this.panel4.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.rangeWidth);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 200);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(498, 100);
            this.panel3.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.rangeHeight);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(498, 100);
            this.panel2.TabIndex = 16;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.textBox1);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(498, 100);
            this.panel7.TabIndex = 21;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(182, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(293, 36);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "192.168.2.2";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F);
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 32);
            this.label1.TabIndex = 14;
            this.label1.Text = "切割機IP";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Black;
            this.panel9.Controls.Add(this.captureBox);
            this.panel9.Controls.Add(this.finalBox);
            this.panel9.Location = new System.Drawing.Point(525, 12);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(920, 883);
            this.panel9.TabIndex = 16;
            // 
            // captureBox
            // 
            this.captureBox.BackColor = System.Drawing.Color.White;
            this.captureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.captureBox.Location = new System.Drawing.Point(25, 274);
            this.captureBox.Name = "captureBox";
            this.captureBox.Size = new System.Drawing.Size(920, 400);
            this.captureBox.TabIndex = 2;
            this.captureBox.TabStop = false;
            // 
            // finalBox
            // 
            this.finalBox.BackColor = System.Drawing.Color.White;
            this.finalBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.finalBox.Location = new System.Drawing.Point(0, 0);
            this.finalBox.Name = "finalBox";
            this.finalBox.Size = new System.Drawing.Size(920, 400);
            this.finalBox.TabIndex = 1;
            this.finalBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1439, 924);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "切割機V1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.step1Box)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.step2Box)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.step3Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.captureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finalBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button captureBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox motorStep;
        private System.Windows.Forms.TextBox rangeWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox rangeHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Button sendBtn;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.PictureBox step1Box;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox step2Box;
        private System.Windows.Forms.PictureBox step3Box;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.PictureBox finalBox;
        private System.Windows.Forms.PictureBox captureBox;
    }
}

