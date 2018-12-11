namespace AutomaticMail
{
    partial class MainForm
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
            this.sendBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.statusListView = new System.Windows.Forms.ListBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView_name = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.richTextBoxNotes = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OpenExcelFileBtn = new System.Windows.Forms.Button();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.bodyTextBox = new System.Windows.Forms.RichTextBox();
            this.mailLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.sortListBtn = new MetroFramework.Controls.MetroButton();
            this.mailListTextbox = new System.Windows.Forms.TextBox();
            this.subjectTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sendeMailtoBtn = new MetroFramework.Controls.MetroButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.noteSaveBtn = new System.Windows.Forms.Button();
            this.searchTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.setImageLocation = new System.Windows.Forms.Button();
            this.selectAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // sendBtn
            // 
            this.sendBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sendBtn.Location = new System.Drawing.Point(1319, 528);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(96, 43);
            this.sendBtn.TabIndex = 0;
            this.sendBtn.Text = "Gönder";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(445, 648);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Durum: ";
            // 
            // statusListView
            // 
            this.statusListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.statusListView.FormattingEnabled = true;
            this.statusListView.ItemHeight = 16;
            this.statusListView.Location = new System.Drawing.Point(297, 668);
            this.statusListView.Name = "statusListView";
            this.statusListView.Size = new System.Drawing.Size(359, 36);
            this.statusListView.TabIndex = 9;
            // 
            // browseBtn
            // 
            this.browseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.browseBtn.Location = new System.Drawing.Point(1319, 90);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(96, 44);
            this.browseBtn.TabIndex = 10;
            this.browseBtn.Text = "Dosya Seç";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // name
            // 
            this.name.DisplayIndex = 0;
            this.name.Text = "İsim Soyisim";
            this.name.Width = 78;
            // 
            // listView_name
            // 
            this.listView_name.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listView_name.Location = new System.Drawing.Point(14, 133);
            this.listView_name.Name = "listView_name";
            this.listView_name.Size = new System.Drawing.Size(624, 265);
            this.listView_name.TabIndex = 13;
            this.listView_name.UseCompatibleStateImageBehavior = false;
            this.listView_name.View = System.Windows.Forms.View.Details;
            this.listView_name.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_name_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Kişi Listesi";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Son Mail Tarihi";
            this.columnHeader2.Width = 131;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Son Görüşme Tarihi";
            this.columnHeader3.Width = 152;
            // 
            // richTextBoxNotes
            // 
            this.richTextBoxNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBoxNotes.Location = new System.Drawing.Point(14, 570);
            this.richTextBoxNotes.Name = "richTextBoxNotes";
            this.richTextBoxNotes.Size = new System.Drawing.Size(267, 145);
            this.richTextBoxNotes.TabIndex = 14;
            this.richTextBoxNotes.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(100, 550);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Notlar";
            // 
            // OpenExcelFileBtn
            // 
            this.OpenExcelFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.OpenExcelFileBtn.Location = new System.Drawing.Point(1319, 155);
            this.OpenExcelFileBtn.Name = "OpenExcelFileBtn";
            this.OpenExcelFileBtn.Size = new System.Drawing.Size(96, 61);
            this.OpenExcelFileBtn.TabIndex = 17;
            this.OpenExcelFileBtn.Text = "Excel Dosyasını Aç";
            this.OpenExcelFileBtn.UseVisualStyleBackColor = true;
            this.OpenExcelFileBtn.Click += new System.EventHandler(this.OpenExcelFileBtn_Click);
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Location = new System.Drawing.Point(1140, 360);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(157, 29);
            this.metroComboBox1.TabIndex = 18;
            this.metroComboBox1.UseSelectable = true;
            this.metroComboBox1.SelectedIndexChanged += new System.EventHandler(this.metroComboBox1_SelectedIndexChanged);
            // 
            // bodyTextBox
            // 
            this.bodyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bodyTextBox.Location = new System.Drawing.Point(715, 395);
            this.bodyTextBox.Name = "bodyTextBox";
            this.bodyTextBox.Size = new System.Drawing.Size(582, 174);
            this.bodyTextBox.TabIndex = 19;
            this.bodyTextBox.Text = "";
            // 
            // mailLabel
            // 
            this.mailLabel.AutoSize = true;
            this.mailLabel.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.mailLabel.Location = new System.Drawing.Point(715, 360);
            this.mailLabel.Name = "mailLabel";
            this.mailLabel.Size = new System.Drawing.Size(76, 19);
            this.mailLabel.TabIndex = 21;
            this.mailLabel.Text = "Mail Girişi";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(1178, 338);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(110, 19);
            this.metroLabel1.TabIndex = 22;
            this.metroLabel1.Text = "Mail Şablonları";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Savunma",
            "Fabrika",
            "Genel"});
            this.checkedListBox1.Location = new System.Drawing.Point(86, 404);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 99);
            this.checkedListBox1.TabIndex = 28;
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkedListBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Items.AddRange(new object[] {
            "1. Grup",
            "2. Grup",
            "3. Grup",
            "Danışman"});
            this.checkedListBox2.Location = new System.Drawing.Point(212, 404);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(221, 99);
            this.checkedListBox2.TabIndex = 29;
            // 
            // sortListBtn
            // 
            this.sortListBtn.Location = new System.Drawing.Point(337, 449);
            this.sortListBtn.Name = "sortListBtn";
            this.sortListBtn.Size = new System.Drawing.Size(96, 54);
            this.sortListBtn.TabIndex = 30;
            this.sortListBtn.Text = "Verileri Sırala";
            this.sortListBtn.UseSelectable = true;
            this.sortListBtn.Click += new System.EventHandler(this.sortListBtn_Click);
            // 
            // mailListTextbox
            // 
            this.mailListTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mailListTextbox.Location = new System.Drawing.Point(860, 85);
            this.mailListTextbox.Multiline = true;
            this.mailListTextbox.Name = "mailListTextbox";
            this.mailListTextbox.Size = new System.Drawing.Size(428, 49);
            this.mailListTextbox.TabIndex = 31;
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Location = new System.Drawing.Point(860, 155);
            this.subjectTextBox.Multiline = true;
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(428, 61);
            this.subjectTextBox.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(83, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 33;
            this.label1.Text = "Arama";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(785, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 34;
            this.label4.Text = "Konu: ";
            // 
            // sendeMailtoBtn
            // 
            this.sendeMailtoBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.sendeMailtoBtn.Location = new System.Drawing.Point(494, 404);
            this.sendeMailtoBtn.Name = "sendeMailtoBtn";
            this.sendeMailtoBtn.Size = new System.Drawing.Size(144, 83);
            this.sendeMailtoBtn.TabIndex = 35;
            this.sendeMailtoBtn.Text = "Gönderilecekleri Seç";
            this.sendeMailtoBtn.UseSelectable = true;
            this.sendeMailtoBtn.Click += new System.EventHandler(this.sendeMailtoBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AutomaticMail.Properties.Resources.attachment;
            this.pictureBox1.Location = new System.Drawing.Point(715, 584);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(582, 131);
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // noteSaveBtn
            // 
            this.noteSaveBtn.BackColor = System.Drawing.Color.White;
            this.noteSaveBtn.BackgroundImage = global::AutomaticMail.Properties.Resources.saveButtonImage;
            this.noteSaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.noteSaveBtn.Location = new System.Drawing.Point(251, 687);
            this.noteSaveBtn.Name = "noteSaveBtn";
            this.noteSaveBtn.Size = new System.Drawing.Size(30, 28);
            this.noteSaveBtn.TabIndex = 16;
            this.noteSaveBtn.UseVisualStyleBackColor = false;
            this.noteSaveBtn.Click += new System.EventHandler(this.noteSaveBtn_Click);
            // 
            // searchTxt
            // 
            this.searchTxt.Location = new System.Drawing.Point(14, 106);
            this.searchTxt.Multiline = true;
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(192, 28);
            this.searchTxt.TabIndex = 37;
            this.searchTxt.TextChanged += new System.EventHandler(this.searchTxt_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(712, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 17);
            this.label5.TabIndex = 38;
            this.label5.Text = "Gönderilecekler:";
            // 
            // setImageLocation
            // 
            this.setImageLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.setImageLocation.Location = new System.Drawing.Point(1319, 622);
            this.setImageLocation.Name = "setImageLocation";
            this.setImageLocation.Size = new System.Drawing.Size(96, 43);
            this.setImageLocation.TabIndex = 39;
            this.setImageLocation.Text = "Eklenecek Resim Seç";
            this.setImageLocation.UseVisualStyleBackColor = true;
            this.setImageLocation.Click += new System.EventHandler(this.setImageLocation_Click);
            // 
            // selectAll
            // 
            this.selectAll.AutoSize = true;
            this.selectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.selectAll.Location = new System.Drawing.Point(212, 107);
            this.selectAll.Name = "selectAll";
            this.selectAll.Size = new System.Drawing.Size(102, 21);
            this.selectAll.TabIndex = 40;
            this.selectAll.Text = "Hepsini Seç";
            this.selectAll.UseVisualStyleBackColor = true;
            this.selectAll.CheckedChanged += new System.EventHandler(this.selectAll_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 738);
            this.Controls.Add(this.selectAll);
            this.Controls.Add(this.setImageLocation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.searchTxt);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sendeMailtoBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.subjectTextBox);
            this.Controls.Add(this.mailListTextbox);
            this.Controls.Add(this.sortListBtn);
            this.Controls.Add(this.checkedListBox2);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.bodyTextBox);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.mailLabel);
            this.Controls.Add(this.metroComboBox1);
            this.Controls.Add(this.OpenExcelFileBtn);
            this.Controls.Add(this.noteSaveBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBoxNotes);
            this.Controls.Add(this.listView_name);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.statusListView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sendBtn);
            this.Name = "MainForm";
            this.Text = "Automatic Mail 1.0 Beta";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox statusListView;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ListView listView_name;
        private System.Windows.Forms.RichTextBox richTextBoxNotes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button noteSaveBtn;
        private System.Windows.Forms.Button OpenExcelFileBtn;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private System.Windows.Forms.RichTextBox bodyTextBox;
        private MetroFramework.Controls.MetroLabel mailLabel;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private MetroFramework.Controls.MetroButton sortListBtn;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox mailListTextbox;
        private System.Windows.Forms.TextBox subjectTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroButton sendeMailtoBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox searchTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button setImageLocation;
        private System.Windows.Forms.CheckBox selectAll;
    }
}

