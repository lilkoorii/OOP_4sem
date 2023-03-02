namespace Laba1
{
    partial class CalCalculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalCalculator));
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
            this.Weight.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Weight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Weight.Location = new System.Drawing.Point(242, 38);
            this.Weight.MaxLength = 1000;
            this.Weight.Name = "Weight";
            this.Weight.PlaceholderText = "Введите вес...";
            this.Weight.Size = new System.Drawing.Size(125, 27);
            this.Weight.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(54, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ваш вес (кг):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(54, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ваш рост (см):";
            // 
            // Height
            // 
            this.Height.BackColor = System.Drawing.SystemColors.Window;
            this.Height.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Height.Location = new System.Drawing.Point(242, 70);
            this.Height.MaxLength = 1000;
            this.Height.Name = "Height";
            this.Height.PlaceholderText = "Введите рост...";
            this.Height.Size = new System.Drawing.Size(125, 27);
            this.Height.TabIndex = 2;
            // 
            // radioFemale
            // 
            this.radioFemale.AutoSize = true;
            this.radioFemale.ForeColor = System.Drawing.SystemColors.InfoText;
            this.radioFemale.Location = new System.Drawing.Point(6, 18);
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
            this.radioMale.ForeColor = System.Drawing.SystemColors.InfoText;
            this.radioMale.Location = new System.Drawing.Point(104, 18);
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
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(54, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Выберите ваш пол:";
            // 
            // trackBarAge
            // 
            this.trackBarAge.Location = new System.Drawing.Point(54, 193);
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
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(54, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Выберите ваш возраст:";
            // 
            // textBoxAge
            // 
            this.textBoxAge.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAge.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxAge.ForeColor = System.Drawing.Color.RoyalBlue;
            this.textBoxAge.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxAge.Location = new System.Drawing.Point(229, 225);
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
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(54, 272);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(5);
            this.label5.Size = new System.Drawing.Size(127, 30);
            this.label5.TabIndex = 13;
            this.label5.Text = "Цель рассчёта:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Magenta;
            this.label6.Location = new System.Drawing.Point(54, 332);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(5);
            this.label6.Size = new System.Drawing.Size(254, 30);
            this.label6.TabIndex = 14;
            this.label6.Text = "Желаемые вес (кг) и срок (дни):";
            // 
            // FutureWeight
            // 
            this.FutureWeight.Location = new System.Drawing.Point(345, 333);
            this.FutureWeight.MaxLength = 1000;
            this.FutureWeight.Name = "FutureWeight";
            this.FutureWeight.PlaceholderText = "Введите вес...";
            this.FutureWeight.Size = new System.Drawing.Size(125, 27);
            this.FutureWeight.TabIndex = 15;
            this.FutureWeight.TextChanged += new System.EventHandler(this.FutureWeight_TextChanged);
            // 
            // FutureTime
            // 
            this.FutureTime.Location = new System.Drawing.Point(506, 333);
            this.FutureTime.MaxLength = 1000;
            this.FutureTime.Name = "FutureTime";
            this.FutureTime.PlaceholderText = "Введите срок...";
            this.FutureTime.Size = new System.Drawing.Size(125, 27);
            this.FutureTime.TabIndex = 16;
            // 
            // radioSameWeight
            // 
            this.radioSameWeight.AutoSize = true;
            this.radioSameWeight.Location = new System.Drawing.Point(6, 22);
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
            this.radioLowerWeight.Location = new System.Drawing.Point(169, 22);
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
            this.radioHigherWeight.Location = new System.Drawing.Point(310, 22);
            this.radioHigherWeight.Name = "radioHigherWeight";
            this.radioHigherWeight.Size = new System.Drawing.Size(111, 24);
            this.radioHigherWeight.TabIndex = 19;
            this.radioHigherWeight.TabStop = true;
            this.radioHigherWeight.Text = "Набор веса";
            this.radioHigherWeight.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.radioFemale);
            this.groupBox1.Controls.Add(this.radioMale);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox1.Location = new System.Drawing.Point(242, 100);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 48);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.radioSameWeight);
            this.groupBox2.Controls.Add(this.radioLowerWeight);
            this.groupBox2.Controls.Add(this.radioHigherWeight);
            this.groupBox2.Location = new System.Drawing.Point(196, 252);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(427, 57);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Cyan;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.Magenta;
            this.button1.Location = new System.Drawing.Point(54, 399);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(704, 67);
            this.button1.TabIndex = 22;
            this.button1.Text = "Рассчитать калории";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.calculate_Click);
            // 
            // CalCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
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
            this.Name = "CalCalculator";
            this.Text = "Калькулятор калорий";
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