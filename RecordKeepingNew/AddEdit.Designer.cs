namespace RecordKeeping
{
    partial class AddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEdit));
            this.rbIncoming = new System.Windows.Forms.RadioButton();
            this.rbOutgoing = new System.Windows.Forms.RadioButton();
            this.tbMailNumber = new RecordKeeping.MyTextBox();
            this.lbMailNumber = new System.Windows.Forms.Label();
            this.dtRegDate = new System.Windows.Forms.DateTimePicker();
            this.lbRegDate = new System.Windows.Forms.Label();
            this.cbReplyTo = new System.Windows.Forms.ComboBox();
            this.lbReplyTo = new System.Windows.Forms.Label();
            this.cbReply = new System.Windows.Forms.ComboBox();
            this.lbReply = new System.Windows.Forms.Label();
            this.tbSenderReciever = new RecordKeeping.MyTextBox();
            this.lbSenderRediever = new System.Windows.Forms.Label();
            this.dtMailDate = new System.Windows.Forms.DateTimePicker();
            this.lbMailDate = new System.Windows.Forms.Label();
            this.tbFiles = new System.Windows.Forms.TextBox();
            this.lbFiles = new System.Windows.Forms.Label();
            this.btnFiles = new System.Windows.Forms.Button();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.chkEdit = new System.Windows.Forms.CheckBox();
            this.fbdAttach = new System.Windows.Forms.FolderBrowserDialog();
            this.lbTitle = new System.Windows.Forms.Label();
            this.tbTitle = new RecordKeeping.MyTextBox();
            this.btnClearFormat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbIncoming
            // 
            this.rbIncoming.AutoSize = true;
            this.rbIncoming.Location = new System.Drawing.Point(13, 13);
            this.rbIncoming.Name = "rbIncoming";
            this.rbIncoming.Size = new System.Drawing.Size(76, 17);
            this.rbIncoming.TabIndex = 0;
            this.rbIncoming.Text = "Входящее";
            this.rbIncoming.UseVisualStyleBackColor = true;
            this.rbIncoming.CheckedChanged += new System.EventHandler(this.rbIncoming_CheckedChanged);
            // 
            // rbOutgoing
            // 
            this.rbOutgoing.AutoSize = true;
            this.rbOutgoing.Location = new System.Drawing.Point(95, 13);
            this.rbOutgoing.Name = "rbOutgoing";
            this.rbOutgoing.Size = new System.Drawing.Size(83, 17);
            this.rbOutgoing.TabIndex = 1;
            this.rbOutgoing.Text = "Исходящее";
            this.rbOutgoing.UseVisualStyleBackColor = true;
            this.rbOutgoing.CheckedChanged += new System.EventHandler(this.rbOutgoing_CheckedChanged);
            // 
            // tbMailNumber
            // 
            this.tbMailNumber.BorderColor = System.Drawing.Color.Gray;
            this.tbMailNumber.Location = new System.Drawing.Point(12, 49);
            this.tbMailNumber.Name = "tbMailNumber";
            this.tbMailNumber.Size = new System.Drawing.Size(193, 20);
            this.tbMailNumber.TabIndex = 2;
            // 
            // lbMailNumber
            // 
            this.lbMailNumber.AutoSize = true;
            this.lbMailNumber.Location = new System.Drawing.Point(9, 34);
            this.lbMailNumber.Name = "lbMailNumber";
            this.lbMailNumber.Size = new System.Drawing.Size(100, 13);
            this.lbMailNumber.TabIndex = 3;
            this.lbMailNumber.Text = "Номер Входящего";
            // 
            // dtRegDate
            // 
            this.dtRegDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtRegDate.Location = new System.Drawing.Point(221, 49);
            this.dtRegDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtRegDate.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dtRegDate.Name = "dtRegDate";
            this.dtRegDate.Size = new System.Drawing.Size(98, 20);
            this.dtRegDate.TabIndex = 4;
            // 
            // lbRegDate
            // 
            this.lbRegDate.AutoSize = true;
            this.lbRegDate.Location = new System.Drawing.Point(219, 34);
            this.lbRegDate.Name = "lbRegDate";
            this.lbRegDate.Size = new System.Drawing.Size(100, 13);
            this.lbRegDate.TabIndex = 5;
            this.lbRegDate.Text = "Дата регистрации";
            // 
            // cbReplyTo
            // 
            this.cbReplyTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbReplyTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbReplyTo.FormattingEnabled = true;
            this.cbReplyTo.Location = new System.Drawing.Point(334, 49);
            this.cbReplyTo.Name = "cbReplyTo";
            this.cbReplyTo.Size = new System.Drawing.Size(193, 21);
            this.cbReplyTo.TabIndex = 6;
            // 
            // lbReplyTo
            // 
            this.lbReplyTo.AutoSize = true;
            this.lbReplyTo.Location = new System.Drawing.Point(331, 34);
            this.lbReplyTo.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lbReplyTo.Name = "lbReplyTo";
            this.lbReplyTo.Size = new System.Drawing.Size(93, 13);
            this.lbReplyTo.TabIndex = 7;
            this.lbReplyTo.Text = "Ответ на письмо";
            // 
            // cbReply
            // 
            this.cbReply.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbReply.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbReply.FormattingEnabled = true;
            this.cbReply.Location = new System.Drawing.Point(543, 49);
            this.cbReply.Name = "cbReply";
            this.cbReply.Size = new System.Drawing.Size(193, 21);
            this.cbReply.TabIndex = 8;
            // 
            // lbReply
            // 
            this.lbReply.AutoSize = true;
            this.lbReply.Location = new System.Drawing.Point(540, 34);
            this.lbReply.Name = "lbReply";
            this.lbReply.Size = new System.Drawing.Size(96, 13);
            this.lbReply.TabIndex = 9;
            this.lbReply.Text = "Ответное письмо";
            // 
            // tbSenderReciever
            // 
            this.tbSenderReciever.BorderColor = System.Drawing.Color.Gray;
            this.tbSenderReciever.Location = new System.Drawing.Point(12, 91);
            this.tbSenderReciever.Name = "tbSenderReciever";
            this.tbSenderReciever.Size = new System.Drawing.Size(193, 20);
            this.tbSenderReciever.TabIndex = 10;
            // 
            // lbSenderRediever
            // 
            this.lbSenderRediever.AutoSize = true;
            this.lbSenderRediever.Location = new System.Drawing.Point(10, 75);
            this.lbSenderRediever.Name = "lbSenderRediever";
            this.lbSenderRediever.Size = new System.Drawing.Size(73, 13);
            this.lbSenderRediever.TabIndex = 11;
            this.lbSenderRediever.Text = "Отправитель";
            // 
            // dtMailDate
            // 
            this.dtMailDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtMailDate.Location = new System.Drawing.Point(221, 91);
            this.dtMailDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtMailDate.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dtMailDate.Name = "dtMailDate";
            this.dtMailDate.Size = new System.Drawing.Size(98, 20);
            this.dtMailDate.TabIndex = 12;
            // 
            // lbMailDate
            // 
            this.lbMailDate.AutoSize = true;
            this.lbMailDate.Location = new System.Drawing.Point(219, 75);
            this.lbMailDate.Name = "lbMailDate";
            this.lbMailDate.Size = new System.Drawing.Size(88, 13);
            this.lbMailDate.TabIndex = 13;
            this.lbMailDate.Text = "Дата получения";
            // 
            // tbFiles
            // 
            this.tbFiles.Enabled = false;
            this.tbFiles.Location = new System.Drawing.Point(334, 90);
            this.tbFiles.Multiline = true;
            this.tbFiles.Name = "tbFiles";
            this.tbFiles.Size = new System.Drawing.Size(302, 20);
            this.tbFiles.TabIndex = 14;
            // 
            // lbFiles
            // 
            this.lbFiles.AutoSize = true;
            this.lbFiles.Location = new System.Drawing.Point(331, 75);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(71, 13);
            this.lbFiles.TabIndex = 15;
            this.lbFiles.Text = "Приложения";
            // 
            // btnFiles
            // 
            this.btnFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFiles.Location = new System.Drawing.Point(643, 90);
            this.btnFiles.Margin = new System.Windows.Forms.Padding(0);
            this.btnFiles.Name = "btnFiles";
            this.btnFiles.Size = new System.Drawing.Size(93, 20);
            this.btnFiles.TabIndex = 16;
            this.btnFiles.Text = "Выбрать";
            this.btnFiles.UseVisualStyleBackColor = true;
            this.btnFiles.Click += new System.EventHandler(this.btnFiles_Click);
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(12, 171);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(724, 313);
            this.tbDescription.TabIndex = 17;
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(9, 155);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(57, 13);
            this.lbDescription.TabIndex = 18;
            this.lbDescription.Text = "Описание";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(661, 494);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(580, 494);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 20;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chkEdit
            // 
            this.chkEdit.AutoSize = true;
            this.chkEdit.Location = new System.Drawing.Point(-1, 508);
            this.chkEdit.Name = "chkEdit";
            this.chkEdit.Size = new System.Drawing.Size(110, 17);
            this.chkEdit.TabIndex = 21;
            this.chkEdit.Text = "Редактирование";
            this.chkEdit.UseVisualStyleBackColor = true;
            this.chkEdit.Visible = false;
            // 
            // fbdAttach
            // 
            this.fbdAttach.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Location = new System.Drawing.Point(9, 115);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(34, 13);
            this.lbTitle.TabIndex = 22;
            this.lbTitle.Text = "Тема";
            // 
            // tbTitle
            // 
            this.tbTitle.BorderColor = System.Drawing.Color.Gray;
            this.tbTitle.Location = new System.Drawing.Point(12, 131);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(724, 20);
            this.tbTitle.TabIndex = 23;
            // 
            // btnClearFormat
            // 
            this.btnClearFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFormat.Location = new System.Drawing.Point(264, 494);
            this.btnClearFormat.Name = "btnClearFormat";
            this.btnClearFormat.Size = new System.Drawing.Size(160, 23);
            this.btnClearFormat.TabIndex = 24;
            this.btnClearFormat.Text = "Удалить форматирование";
            this.btnClearFormat.UseVisualStyleBackColor = true;
            this.btnClearFormat.Click += new System.EventHandler(this.btnClearFormat_Click);
            // 
            // AddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 529);
            this.Controls.Add(this.btnClearFormat);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.chkEdit);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.btnFiles);
            this.Controls.Add(this.lbFiles);
            this.Controls.Add(this.tbFiles);
            this.Controls.Add(this.lbMailDate);
            this.Controls.Add(this.dtMailDate);
            this.Controls.Add(this.lbSenderRediever);
            this.Controls.Add(this.tbSenderReciever);
            this.Controls.Add(this.lbReply);
            this.Controls.Add(this.cbReply);
            this.Controls.Add(this.lbReplyTo);
            this.Controls.Add(this.cbReplyTo);
            this.Controls.Add(this.lbRegDate);
            this.Controls.Add(this.dtRegDate);
            this.Controls.Add(this.lbMailNumber);
            this.Controls.Add(this.tbMailNumber);
            this.Controls.Add(this.rbOutgoing);
            this.Controls.Add(this.rbIncoming);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEdit";
            this.Text = "Добавить\\Изменить";
            this.Load += new System.EventHandler(this.AddEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbIncoming;
        private System.Windows.Forms.RadioButton rbOutgoing;
        private System.Windows.Forms.Label lbMailNumber;
        private System.Windows.Forms.DateTimePicker dtRegDate;
        private System.Windows.Forms.Label lbRegDate;
        private System.Windows.Forms.ComboBox cbReplyTo;
        private System.Windows.Forms.Label lbReplyTo;
        private System.Windows.Forms.ComboBox cbReply;
        private System.Windows.Forms.Label lbReply;
        private System.Windows.Forms.Label lbSenderRediever;
        private System.Windows.Forms.DateTimePicker dtMailDate;
        private System.Windows.Forms.Label lbMailDate;
        private System.Windows.Forms.TextBox tbFiles;
        private System.Windows.Forms.Label lbFiles;
        private System.Windows.Forms.Button btnFiles;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox chkEdit;
        private System.Windows.Forms.FolderBrowserDialog fbdAttach;
        private System.Windows.Forms.Label lbTitle;
        private MyTextBox tbMailNumber;
        private MyTextBox tbSenderReciever;
        private MyTextBox tbTitle;
        private System.Windows.Forms.Button btnClearFormat;
    }
}