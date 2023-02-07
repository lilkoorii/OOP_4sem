namespace Laba1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Weight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Height = new System.Windows.Forms.TextBox();
            this.radioFemale = new System.Windows.Forms.RadioButton();
            this.radioMale = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBarAge = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.FutureWeight = new System.Windows.Forms.TextBox();
            this.FutureTime = new System.Windows.Forms.TextBox();
            this.radioSameWeight = new System.Windows.Forms.RadioButton();
            this.radioLowerWeight = new System.Windows.Forms.RadioButton();
            this.radioHigherWeight = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAge)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Weight
            // 
            this.Weight.Location = new System.Drawing.Point(242, 53);
            this.Weight.MaxLength = 1000;
            this.Weight.Name = "Weight";
            this.Weight.PlaceholderText = "Введите вес...";
            this.Weight.Size = new System.Drawing.Size(125, 27);
            this.Weight.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ваш вес (кг):";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ваш рост (см):";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Height
            // 
            this.Height.BackColor = System.Drawing.SystemColors.Window;
            this.Height.Location = new System.Drawing.Point(242, 85);
            this.Height.MaxLength = 1000;
            this.Height.Name = "Height";
            this.Height.PlaceholderText = "Введите рост...";
            this.Height.Size = new System.Drawing.Size(125, 27);
            this.Height.TabIndex = 2;
            this.Height.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // radioFemale
            // 
            this.radioFemale.AutoSize = true;
            this.radioFemale.Location = new System.Drawing.Point(3, 5);
            this.radioFemale.Name = "radioFemale";
            this.radioFemale.Size = new System.Drawing.Size(92, 24);
            this.radioFemale.TabIndex = 4;
            this.radioFemale.TabStop = true;
            this.radioFemale.Text = "Женский";
            this.radioFemale.UseVisualStyleBackColor = true;
            // 
            // radioMale
            // 
            this.radioMale.AutoSize = true;
            this.radioMale.Location = new System.Drawing.Point(104, 5);
            this.radioMale.Name = "radioMale";
            this.radioMale.Size = new System.Drawing.Size(93, 24);
            this.radioMale.TabIndex = 5;
            this.radioMale.TabStop = true;
            this.radioMale.Text = "Мужской";
            this.radioMale.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Выберите ваш пол:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // trackBarAge
            // 
            this.trackBarAge.Location = new System.Drawing.Point(232, 149);
            this.trackBarAge.Maximum = 150;
            this.trackBarAge.Minimum = 1;
            this.trackBarAge.Name = "trackBarAge";
            this.trackBarAge.Size = new System.Drawing.Size(464, 56);
            this.trackBarAge.TabIndex = 7;
            this.trackBarAge.Value = 1;
            this.trackBarAge.Scroll += new System.EventHandler(this.trackBarAge_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Выберите ваш возраст:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBoxAge
            // 
            this.textBoxAge.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAge.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxAge.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxAge.Location = new System.Drawing.Point(416, 187);
            this.textBoxAge.MaxLength = 150;
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.PlaceholderText = "Ваш возраст";
            this.textBoxAge.ReadOnly = true;
            this.textBoxAge.Size = new System.Drawing.Size(97, 20);
            this.textBoxAge.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(341, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Цель рассчёта:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.OliveDrab;
            this.label6.Location = new System.Drawing.Point(270, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(269, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Желаемые вес (кг) и срок (недели):";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // FutureWeight
            // 
            this.FutureWeight.Location = new System.Drawing.Point(238, 347);
            this.FutureWeight.MaxLength = 1000;
            this.FutureWeight.Name = "FutureWeight";
            this.FutureWeight.PlaceholderText = "Введите вес...";
            this.FutureWeight.Size = new System.Drawing.Size(125, 27);
            this.FutureWeight.TabIndex = 15;
            // 
            // FutureTime
            // 
            this.FutureTime.Location = new System.Drawing.Point(432, 347);
            this.FutureTime.MaxLength = 1000;
            this.FutureTime.Name = "FutureTime";
            this.FutureTime.PlaceholderText = "Введите срок...";
            this.FutureTime.Size = new System.Drawing.Size(125, 27);
            this.FutureTime.TabIndex = 16;
            // 
            // radioSameWeight
            // 
            this.radioSameWeight.AutoSize = true;
            this.radioSameWeight.Location = new System.Drawing.Point(6, 23);
            this.radioSameWeight.Name = "radioSameWeight";
            this.radioSameWeight.Size = new System.Drawing.Size(163, 24);
            this.radioSameWeight.TabIndex = 17;
            this.radioSameWeight.TabStop = true;
            this.radioSameWeight.Text = "Поддержание веса";
            this.radioSameWeight.UseVisualStyleBackColor = true;
            // 
            // radioLowerWeight
            // 
            this.radioLowerWeight.AutoSize = true;
            this.radioLowerWeight.Location = new System.Drawing.Point(169, 23);
            this.radioLowerWeight.Name = "radioLowerWeight";
            this.radioLowerWeight.Size = new System.Drawing.Size(137, 24);
            this.radioLowerWeight.TabIndex = 18;
            this.radioLowerWeight.TabStop = true;
            this.radioLowerWeight.Text = "Снижение веса";
            this.radioLowerWeight.UseVisualStyleBackColor = true;
            // 
            // radioHigherWeight
            // 
            this.radioHigherWeight.AutoSize = true;
            this.radioHigherWeight.Location = new System.Drawing.Point(310, 23);
            this.radioHigherWeight.Name = "radioHigherWeight";
            this.radioHigherWeight.Size = new System.Drawing.Size(111, 24);
            this.radioHigherWeight.TabIndex = 19;
            this.radioHigherWeight.TabStop = true;
            this.radioHigherWeight.Text = "Набор веса";
            this.radioHigherWeight.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioFemale);
            this.groupBox1.Controls.Add(this.radioMale);
            this.groupBox1.Location = new System.Drawing.Point(242, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 35);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioSameWeight);
            this.groupBox2.Controls.Add(this.radioLowerWeight);
            this.groupBox2.Controls.Add(this.radioHigherWeight);
            this.groupBox2.Location = new System.Drawing.Point(191, 253);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(467, 57);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(281, 400);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 67);
            this.button1.TabIndex = 22;
            this.button1.Text = "Рассчитать калории";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 557);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.FutureTime);
            this.Controls.Add(this.FutureWeight);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxAge);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackBarAge);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Height);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Weight);
            this.Name = "Form1";
            this.Text = "Калькулятор калорий";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAge)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public TextBox Weight;
        private Label label1;
        private Label label2;
        public TextBox Height;
        private RadioButton radioFemale;
        private RadioButton radioMale;
        private Label label3;
        private TrackBar trackBarAge;
        private Label label4;
        private TextBox textBoxAge;
        private Label label5;
        private Label label6;
        public TextBox FutureWeight;
        public TextBox FutureTime;
        private RadioButton radioSameWeight;
        private RadioButton radioLowerWeight;
        private RadioButton radioHigherWeight;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button button1;
    }
}