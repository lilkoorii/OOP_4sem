namespace Laba2
{
    partial class SearchForm
    {
        Library library;
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
            this.inputBookTitle = new System.Windows.Forms.TextBox();
            this.lable = new System.Windows.Forms.Label();
            this.listBoxSearchResult = new System.Windows.Forms.ListBox();
            this.labelFound = new System.Windows.Forms.Label();
            this.gbSearchFormat = new System.Windows.Forms.GroupBox();
            this.rbRegex = new System.Windows.Forms.RadioButton();
            this.rbLinq = new System.Windows.Forms.RadioButton();
            this.btnYearSort = new System.Windows.Forms.Button();
            this.btnUploadSort = new System.Windows.Forms.Button();
            this.btnNameSort = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.inputPublisher = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inputYear = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.searhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.библиотекаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сортировкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поГодуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поДатеЗагрузкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поНазваниюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gbSearchFormat.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputBookTitle
            // 
            this.inputBookTitle.Location = new System.Drawing.Point(16, 93);
            this.inputBookTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inputBookTitle.Name = "inputBookTitle";
            this.inputBookTitle.Size = new System.Drawing.Size(469, 27);
            this.inputBookTitle.TabIndex = 0;
            this.inputBookTitle.TextChanged += new System.EventHandler(this.inputBookTitle_TextChanged);
            // 
            // lable
            // 
            this.lable.AutoSize = true;
            this.lable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lable.ForeColor = System.Drawing.Color.Black;
            this.lable.Location = new System.Drawing.Point(160, 69);
            this.lable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lable.Name = "lable";
            this.lable.Size = new System.Drawing.Size(191, 17);
            this.lable.TabIndex = 1;
            this.lable.Text = "Введите название книги";
            // 
            // listBoxSearchResult
            // 
            this.listBoxSearchResult.FormattingEnabled = true;
            this.listBoxSearchResult.ItemHeight = 20;
            this.listBoxSearchResult.Location = new System.Drawing.Point(13, 281);
            this.listBoxSearchResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxSearchResult.Name = "listBoxSearchResult";
            this.listBoxSearchResult.Size = new System.Drawing.Size(1083, 264);
            this.listBoxSearchResult.TabIndex = 2;
            // 
            // labelFound
            // 
            this.labelFound.AutoSize = true;
            this.labelFound.Location = new System.Drawing.Point(13, 550);
            this.labelFound.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFound.Name = "labelFound";
            this.labelFound.Size = new System.Drawing.Size(129, 20);
            this.labelFound.TabIndex = 3;
            this.labelFound.Text = "Найдено: 0 Дата: ";
            // 
            // gbSearchFormat
            // 
            this.gbSearchFormat.Controls.Add(this.rbRegex);
            this.gbSearchFormat.Controls.Add(this.rbLinq);
            this.gbSearchFormat.ForeColor = System.Drawing.Color.Black;
            this.gbSearchFormat.Location = new System.Drawing.Point(511, 93);
            this.gbSearchFormat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbSearchFormat.Name = "gbSearchFormat";
            this.gbSearchFormat.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbSearchFormat.Size = new System.Drawing.Size(125, 154);
            this.gbSearchFormat.TabIndex = 4;
            this.gbSearchFormat.TabStop = false;
            this.gbSearchFormat.Text = "Формат поиска";
            // 
            // rbRegex
            // 
            this.rbRegex.AutoSize = true;
            this.rbRegex.Location = new System.Drawing.Point(8, 88);
            this.rbRegex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbRegex.Name = "rbRegex";
            this.rbRegex.Size = new System.Drawing.Size(71, 24);
            this.rbRegex.TabIndex = 1;
            this.rbRegex.Text = "Regex";
            this.rbRegex.UseVisualStyleBackColor = true;
            this.rbRegex.CheckedChanged += new System.EventHandler(this.rbSearchFormat_CheckedChanged);
            // 
            // rbLinq
            // 
            this.rbLinq.AutoSize = true;
            this.rbLinq.Checked = true;
            this.rbLinq.Location = new System.Drawing.Point(9, 53);
            this.rbLinq.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbLinq.Name = "rbLinq";
            this.rbLinq.Size = new System.Drawing.Size(63, 24);
            this.rbLinq.TabIndex = 0;
            this.rbLinq.TabStop = true;
            this.rbLinq.Text = "LINQ";
            this.rbLinq.UseVisualStyleBackColor = true;
            this.rbLinq.CheckedChanged += new System.EventHandler(this.rbSearchFormat_CheckedChanged);
            // 
            // btnYearSort
            // 
            this.btnYearSort.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnYearSort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYearSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnYearSort.ForeColor = System.Drawing.SystemColors.Window;
            this.btnYearSort.Location = new System.Drawing.Point(676, 93);
            this.btnYearSort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnYearSort.Name = "btnYearSort";
            this.btnYearSort.Size = new System.Drawing.Size(125, 51);
            this.btnYearSort.TabIndex = 5;
            this.btnYearSort.Text = "Сорт. по году";
            this.btnYearSort.UseVisualStyleBackColor = false;
            this.btnYearSort.Click += new System.EventHandler(this.btnYearSort_Click);
            // 
            // btnUploadSort
            // 
            this.btnUploadSort.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnUploadSort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUploadSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUploadSort.ForeColor = System.Drawing.SystemColors.Window;
            this.btnUploadSort.Location = new System.Drawing.Point(676, 154);
            this.btnUploadSort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUploadSort.Name = "btnUploadSort";
            this.btnUploadSort.Size = new System.Drawing.Size(125, 51);
            this.btnUploadSort.TabIndex = 5;
            this.btnUploadSort.Text = "Сорт. по дате загрузки";
            this.btnUploadSort.UseVisualStyleBackColor = false;
            this.btnUploadSort.Click += new System.EventHandler(this.btnUploadSort_Click);
            // 
            // btnNameSort
            // 
            this.btnNameSort.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnNameSort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNameSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNameSort.ForeColor = System.Drawing.SystemColors.Window;
            this.btnNameSort.Location = new System.Drawing.Point(676, 213);
            this.btnNameSort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNameSort.Name = "btnNameSort";
            this.btnNameSort.Size = new System.Drawing.Size(125, 51);
            this.btnNameSort.TabIndex = 6;
            this.btnNameSort.Text = "Сорт. по названию";
            this.btnNameSort.UseVisualStyleBackColor = false;
            this.btnNameSort.Click += new System.EventHandler(this.btnNameSort_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(157, 130);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Введите издательство";
            // 
            // inputPublisher
            // 
            this.inputPublisher.Location = new System.Drawing.Point(13, 154);
            this.inputPublisher.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inputPublisher.Name = "inputPublisher";
            this.inputPublisher.Size = new System.Drawing.Size(469, 27);
            this.inputPublisher.TabIndex = 0;
            this.inputPublisher.TextChanged += new System.EventHandler(this.inputPublisher_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(157, 189);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Введите год издания";
            // 
            // inputYear
            // 
            this.inputYear.Location = new System.Drawing.Point(13, 213);
            this.inputYear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inputYear.Name = "inputYear";
            this.inputYear.Size = new System.Drawing.Size(469, 27);
            this.inputYear.TabIndex = 0;
            this.inputYear.TextChanged += new System.EventHandler(this.inputYear_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searhToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1115, 30);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // searhToolStripMenuItem
            // 
            this.searhToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.библиотекаToolStripMenuItem,
            this.searchToolStripMenuItem});
            this.searhToolStripMenuItem.Name = "searhToolStripMenuItem";
            this.searhToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.searhToolStripMenuItem.Text = "Меню";
            // 
            // библиотекаToolStripMenuItem
            // 
            this.библиотекаToolStripMenuItem.Name = "библиотекаToolStripMenuItem";
            this.библиотекаToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.библиотекаToolStripMenuItem.Text = "Библиотека";
            this.библиотекаToolStripMenuItem.Click += new System.EventHandler(this.библиотекаToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сортировкиToolStripMenuItem});
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.searchToolStripMenuItem.Text = "Поиск";
            // 
            // сортировкиToolStripMenuItem
            // 
            this.сортировкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поГодуToolStripMenuItem,
            this.поДатеЗагрузкиToolStripMenuItem,
            this.поНазваниюToolStripMenuItem});
            this.сортировкиToolStripMenuItem.Name = "сортировкиToolStripMenuItem";
            this.сортировкиToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.сортировкиToolStripMenuItem.Text = "Сортировки";
            // 
            // поГодуToolStripMenuItem
            // 
            this.поГодуToolStripMenuItem.Name = "поГодуToolStripMenuItem";
            this.поГодуToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.поГодуToolStripMenuItem.Text = "По году";
            this.поГодуToolStripMenuItem.Click += new System.EventHandler(this.поГодуToolStripMenuItem_Click);
            // 
            // поДатеЗагрузкиToolStripMenuItem
            // 
            this.поДатеЗагрузкиToolStripMenuItem.Name = "поДатеЗагрузкиToolStripMenuItem";
            this.поДатеЗагрузкиToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.поДатеЗагрузкиToolStripMenuItem.Text = "По дате загрузки";
            this.поДатеЗагрузкиToolStripMenuItem.Click += new System.EventHandler(this.поДатеЗагрузкиToolStripMenuItem_Click);
            // 
            // поНазваниюToolStripMenuItem
            // 
            this.поНазваниюToolStripMenuItem.Name = "поНазваниюToolStripMenuItem";
            this.поНазваниюToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.поНазваниюToolStripMenuItem.Text = "По названию";
            this.поНазваниюToolStripMenuItem.Click += new System.EventHandler(this.поНазваниюToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.aboutToolStripMenuItem.Text = "Хелп";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(187, 26);
            this.aboutToolStripMenuItem1.Text = "О программе";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 581);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputPublisher);
            this.Controls.Add(this.btnNameSort);
            this.Controls.Add(this.btnUploadSort);
            this.Controls.Add(this.btnYearSort);
            this.Controls.Add(this.gbSearchFormat);
            this.Controls.Add(this.labelFound);
            this.Controls.Add(this.listBoxSearchResult);
            this.Controls.Add(this.lable);
            this.Controls.Add(this.inputBookTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.gbSearchFormat.ResumeLayout(false);
            this.gbSearchFormat.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputBookTitle;
        private System.Windows.Forms.Label lable;
        private System.Windows.Forms.ListBox listBoxSearchResult;
        private System.Windows.Forms.Label labelFound;
        private System.Windows.Forms.GroupBox gbSearchFormat;
        private System.Windows.Forms.RadioButton rbRegex;
        private System.Windows.Forms.RadioButton rbLinq;
        private System.Windows.Forms.Button btnYearSort;
        private System.Windows.Forms.Button btnUploadSort;
        private Button btnNameSort;
        private Label label1;
        private TextBox inputPublisher;
        private Label label2;
        private TextBox inputYear;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem searhToolStripMenuItem;
        private ToolStripMenuItem библиотекаToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripMenuItem сортировкиToolStripMenuItem;
        private ToolStripMenuItem поГодуToolStripMenuItem;
        private ToolStripMenuItem поДатеЗагрузкиToolStripMenuItem;
        private ToolStripMenuItem поНазваниюToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem1;
    }
}