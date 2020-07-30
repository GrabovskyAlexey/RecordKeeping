namespace RecordKeeping
{
    partial class MailCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailCard));
            this.lbDirection = new System.Windows.Forms.Label();
            this.lbMailNumber = new System.Windows.Forms.Label();
            this.lbRegDate = new System.Windows.Forms.Label();
            this.lbMailDate = new System.Windows.Forms.Label();
            this.lbReplyTo = new System.Windows.Forms.Label();
            this.lbReply = new System.Windows.Forms.Label();
            this.llbFiles = new System.Windows.Forms.LinkLabel();
            this.gbDesc = new System.Windows.Forms.GroupBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lbSenderReciever = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lbTitle = new System.Windows.Forms.Label();
            this.gbDesc.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDirection
            // 
            this.lbDirection.AutoSize = true;
            this.lbDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbDirection.Location = new System.Drawing.Point(13, 13);
            this.lbDirection.Name = "lbDirection";
            this.lbDirection.Size = new System.Drawing.Size(82, 17);
            this.lbDirection.TabIndex = 0;
            this.lbDirection.Text = "Входящее";
            // 
            // lbMailNumber
            // 
            this.lbMailNumber.AutoSize = true;
            this.lbMailNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMailNumber.Location = new System.Drawing.Point(13, 58);
            this.lbMailNumber.Name = "lbMailNumber";
            this.lbMailNumber.Size = new System.Drawing.Size(98, 15);
            this.lbMailNumber.TabIndex = 1;
            this.lbMailNumber.Text = "Номер письма: ";
            // 
            // lbRegDate
            // 
            this.lbRegDate.AutoSize = true;
            this.lbRegDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbRegDate.Location = new System.Drawing.Point(13, 81);
            this.lbRegDate.Name = "lbRegDate";
            this.lbRegDate.Size = new System.Drawing.Size(120, 15);
            this.lbRegDate.TabIndex = 2;
            this.lbRegDate.Text = "Дата регистрации: ";
            // 
            // lbMailDate
            // 
            this.lbMailDate.AutoSize = true;
            this.lbMailDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMailDate.Location = new System.Drawing.Point(13, 105);
            this.lbMailDate.Name = "lbMailDate";
            this.lbMailDate.Size = new System.Drawing.Size(106, 15);
            this.lbMailDate.TabIndex = 3;
            this.lbMailDate.Text = "Дата получения: ";
            // 
            // lbReplyTo
            // 
            this.lbReplyTo.AutoSize = true;
            this.lbReplyTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbReplyTo.Location = new System.Drawing.Point(350, 58);
            this.lbReplyTo.Name = "lbReplyTo";
            this.lbReplyTo.Size = new System.Drawing.Size(113, 15);
            this.lbReplyTo.TabIndex = 4;
            this.lbReplyTo.Text = "Ответ на письмо: ";
            // 
            // lbReply
            // 
            this.lbReply.AutoSize = true;
            this.lbReply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbReply.Location = new System.Drawing.Point(350, 83);
            this.lbReply.Name = "lbReply";
            this.lbReply.Size = new System.Drawing.Size(117, 15);
            this.lbReply.TabIndex = 5;
            this.lbReply.Text = "Ответное письмо: ";
            // 
            // llbFiles
            // 
            this.llbFiles.AutoSize = true;
            this.llbFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.llbFiles.Location = new System.Drawing.Point(350, 107);
            this.llbFiles.Name = "llbFiles";
            this.llbFiles.Size = new System.Drawing.Size(48, 15);
            this.llbFiles.TabIndex = 6;
            this.llbFiles.TabStop = true;
            this.llbFiles.Text = "Файлы";
            this.llbFiles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbFiles_LinkClicked);
            // 
            // gbDesc
            // 
            this.gbDesc.Controls.Add(this.tbDescription);
            this.gbDesc.Location = new System.Drawing.Point(13, 125);
            this.gbDesc.Name = "gbDesc";
            this.gbDesc.Size = new System.Drawing.Size(624, 379);
            this.gbDesc.TabIndex = 7;
            this.gbDesc.TabStop = false;
            this.gbDesc.Text = "Описание";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(6, 20);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ReadOnly = true;
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(612, 353);
            this.tbDescription.TabIndex = 0;
            // 
            // lbSenderReciever
            // 
            this.lbSenderReciever.AutoSize = true;
            this.lbSenderReciever.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSenderReciever.Location = new System.Drawing.Point(350, 13);
            this.lbSenderReciever.Name = "lbSenderReciever";
            this.lbSenderReciever.Size = new System.Drawing.Size(200, 17);
            this.lbSenderReciever.TabIndex = 8;
            this.lbSenderReciever.Text = "Отправитель\\Получатель";
            // 
            // btnEdit
            // 
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(539, 510);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(98, 23);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbTitle.Location = new System.Drawing.Point(13, 37);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(46, 17);
            this.lbTitle.TabIndex = 10;
            this.lbTitle.Text = "Тема";
            // 
            // MailCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 543);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lbSenderReciever);
            this.Controls.Add(this.gbDesc);
            this.Controls.Add(this.llbFiles);
            this.Controls.Add(this.lbReply);
            this.Controls.Add(this.lbReplyTo);
            this.Controls.Add(this.lbMailDate);
            this.Controls.Add(this.lbRegDate);
            this.Controls.Add(this.lbMailNumber);
            this.Controls.Add(this.lbDirection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MailCard";
            this.Text = "MailCard";
            this.Load += new System.EventHandler(this.MailCard_Load);
            this.gbDesc.ResumeLayout(false);
            this.gbDesc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDirection;
        private System.Windows.Forms.Label lbMailNumber;
        private System.Windows.Forms.Label lbRegDate;
        private System.Windows.Forms.Label lbMailDate;
        private System.Windows.Forms.Label lbReplyTo;
        private System.Windows.Forms.Label lbReply;
        private System.Windows.Forms.LinkLabel llbFiles;
        private System.Windows.Forms.GroupBox gbDesc;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lbSenderReciever;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lbTitle;
    }
}