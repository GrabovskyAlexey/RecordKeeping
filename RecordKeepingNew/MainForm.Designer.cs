namespace RecordKeeping
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnAddRecord = new System.Windows.Forms.Button();
            this.btnReloadRecords = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbStatusText = new System.Windows.Forms.Label();
            this.lbStatusName = new System.Windows.Forms.Label();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.опрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabIncoming = new System.Windows.Forms.TabPage();
            this.dgvIncoming = new System.Windows.Forms.DataGridView();
            this.dgvcIncId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcIncMailNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcIncRegDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcIncTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcIncReplyTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcIncReply = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcIncRecipient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcIncMailDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcIncDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcIncAttach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcIncMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsPKM = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMark = new System.Windows.Forms.ToolStripMenuItem();
            this.tabOutgoing = new System.Windows.Forms.TabPage();
            this.dgvOutgoing = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcOutTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcOutMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tabIncoming.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncoming)).BeginInit();
            this.cmsPKM.SuspendLayout();
            this.tabOutgoing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutgoing)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddRecord
            // 
            this.btnAddRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRecord.Location = new System.Drawing.Point(955, 527);
            this.btnAddRecord.Name = "btnAddRecord";
            this.btnAddRecord.Size = new System.Drawing.Size(75, 23);
            this.btnAddRecord.TabIndex = 0;
            this.btnAddRecord.Text = "Добавить";
            this.btnAddRecord.UseVisualStyleBackColor = true;
            this.btnAddRecord.Click += new System.EventHandler(this.btnAddRecord_Click);
            // 
            // btnReloadRecords
            // 
            this.btnReloadRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReloadRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReloadRecords.Location = new System.Drawing.Point(874, 527);
            this.btnReloadRecords.Name = "btnReloadRecords";
            this.btnReloadRecords.Size = new System.Drawing.Size(75, 23);
            this.btnReloadRecords.TabIndex = 1;
            this.btnReloadRecords.Text = "Обновить";
            this.btnReloadRecords.UseVisualStyleBackColor = true;
            this.btnReloadRecords.Click += new System.EventHandler(this.btnReloadRecords_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbStatusText);
            this.panel1.Controls.Add(this.lbStatusName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 564);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1042, 19);
            this.panel1.TabIndex = 2;
            // 
            // lbStatusText
            // 
            this.lbStatusText.AutoSize = true;
            this.lbStatusText.Location = new System.Drawing.Point(62, 2);
            this.lbStatusText.Name = "lbStatusText";
            this.lbStatusText.Size = new System.Drawing.Size(63, 13);
            this.lbStatusText.TabIndex = 1;
            this.lbStatusText.Text = "Отключена";
            // 
            // lbStatusName
            // 
            this.lbStatusName.AutoSize = true;
            this.lbStatusName.Location = new System.Drawing.Point(3, 2);
            this.lbStatusName.Name = "lbStatusName";
            this.lbStatusName.Size = new System.Drawing.Size(63, 13);
            this.lbStatusName.TabIndex = 0;
            this.lbStatusName.Text = "Статус БД:";
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1042, 24);
            this.menuStripMain.TabIndex = 3;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.опрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Спра&вка";
            // 
            // опрограммеToolStripMenuItem
            // 
            this.опрограммеToolStripMenuItem.Name = "опрограммеToolStripMenuItem";
            this.опрограммеToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.опрограммеToolStripMenuItem.Text = "&О программе...";
            this.опрограммеToolStripMenuItem.Click += new System.EventHandler(this.опрограммеToolStripMenuItem_Click);
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tcMain.Controls.Add(this.tabIncoming);
            this.tcMain.Controls.Add(this.tabOutgoing);
            this.tcMain.Location = new System.Drawing.Point(3, 28);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(1039, 493);
            this.tcMain.TabIndex = 4;
            // 
            // tabIncoming
            // 
            this.tabIncoming.Controls.Add(this.dgvIncoming);
            this.tabIncoming.Location = new System.Drawing.Point(4, 25);
            this.tabIncoming.Name = "tabIncoming";
            this.tabIncoming.Padding = new System.Windows.Forms.Padding(3);
            this.tabIncoming.Size = new System.Drawing.Size(1031, 464);
            this.tabIncoming.TabIndex = 0;
            this.tabIncoming.Text = "Входящие";
            this.tabIncoming.UseVisualStyleBackColor = true;
            // 
            // dgvIncoming
            // 
            this.dgvIncoming.AllowUserToAddRows = false;
            this.dgvIncoming.AllowUserToDeleteRows = false;
            this.dgvIncoming.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIncoming.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIncoming.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncoming.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcIncId,
            this.dgvcIncMailNumber,
            this.dgvcIncRegDate,
            this.dgvcIncTitle,
            this.dgvcIncReplyTo,
            this.dgvcIncReply,
            this.dgvcIncRecipient,
            this.dgvcIncMailDate,
            this.dgvcIncDesc,
            this.dgvcIncAttach,
            this.dgvcIncMark});
            this.dgvIncoming.Location = new System.Drawing.Point(0, 0);
            this.dgvIncoming.MultiSelect = false;
            this.dgvIncoming.Name = "dgvIncoming";
            this.dgvIncoming.ReadOnly = true;
            this.dgvIncoming.RowHeadersVisible = false;
            this.dgvIncoming.RowTemplate.ContextMenuStrip = this.cmsPKM;
            this.dgvIncoming.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIncoming.Size = new System.Drawing.Size(1031, 464);
            this.dgvIncoming.TabIndex = 1;
            this.dgvIncoming.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIncoming_CellDoubleClick);
            // 
            // dgvcIncId
            // 
            this.dgvcIncId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvcIncId.DataPropertyName = "Id";
            this.dgvcIncId.FillWeight = 50F;
            this.dgvcIncId.HeaderText = "№";
            this.dgvcIncId.Name = "dgvcIncId";
            this.dgvcIncId.ReadOnly = true;
            this.dgvcIncId.Visible = false;
            this.dgvcIncId.Width = 50;
            // 
            // dgvcIncMailNumber
            // 
            this.dgvcIncMailNumber.DataPropertyName = "MailNumber";
            this.dgvcIncMailNumber.HeaderText = "Номер письма";
            this.dgvcIncMailNumber.Name = "dgvcIncMailNumber";
            this.dgvcIncMailNumber.ReadOnly = true;
            // 
            // dgvcIncRegDate
            // 
            this.dgvcIncRegDate.DataPropertyName = "RegDate";
            this.dgvcIncRegDate.HeaderText = "Дата регистрации";
            this.dgvcIncRegDate.Name = "dgvcIncRegDate";
            this.dgvcIncRegDate.ReadOnly = true;
            // 
            // dgvcIncTitle
            // 
            this.dgvcIncTitle.DataPropertyName = "Title";
            this.dgvcIncTitle.HeaderText = "Тема";
            this.dgvcIncTitle.Name = "dgvcIncTitle";
            this.dgvcIncTitle.ReadOnly = true;
            // 
            // dgvcIncReplyTo
            // 
            this.dgvcIncReplyTo.DataPropertyName = "ReplyTo";
            this.dgvcIncReplyTo.HeaderText = "Ответ на письмо";
            this.dgvcIncReplyTo.Name = "dgvcIncReplyTo";
            this.dgvcIncReplyTo.ReadOnly = true;
            // 
            // dgvcIncReply
            // 
            this.dgvcIncReply.DataPropertyName = "Reply";
            this.dgvcIncReply.HeaderText = "Ответное письмо";
            this.dgvcIncReply.Name = "dgvcIncReply";
            this.dgvcIncReply.ReadOnly = true;
            // 
            // dgvcIncRecipient
            // 
            this.dgvcIncRecipient.DataPropertyName = "Recipient";
            this.dgvcIncRecipient.HeaderText = "Отправитель";
            this.dgvcIncRecipient.Name = "dgvcIncRecipient";
            this.dgvcIncRecipient.ReadOnly = true;
            // 
            // dgvcIncMailDate
            // 
            this.dgvcIncMailDate.DataPropertyName = "MailDate";
            this.dgvcIncMailDate.HeaderText = "Дата получения";
            this.dgvcIncMailDate.Name = "dgvcIncMailDate";
            this.dgvcIncMailDate.ReadOnly = true;
            // 
            // dgvcIncDesc
            // 
            this.dgvcIncDesc.DataPropertyName = "Description";
            this.dgvcIncDesc.HeaderText = "Описание";
            this.dgvcIncDesc.Name = "dgvcIncDesc";
            this.dgvcIncDesc.ReadOnly = true;
            // 
            // dgvcIncAttach
            // 
            this.dgvcIncAttach.DataPropertyName = "Files";
            this.dgvcIncAttach.HeaderText = "Файлы";
            this.dgvcIncAttach.Name = "dgvcIncAttach";
            this.dgvcIncAttach.ReadOnly = true;
            // 
            // dgvcIncMark
            // 
            this.dgvcIncMark.DataPropertyName = "Mark";
            this.dgvcIncMark.HeaderText = "mark";
            this.dgvcIncMark.Name = "dgvcIncMark";
            this.dgvcIncMark.ReadOnly = true;
            this.dgvcIncMark.Visible = false;
            // 
            // cmsPKM
            // 
            this.cmsPKM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmEdit,
            this.tmsDelete,
            this.tsmView,
            this.tsmMark});
            this.cmsPKM.Name = "cmsPKM";
            this.cmsPKM.Size = new System.Drawing.Size(155, 92);
            // 
            // tsmEdit
            // 
            this.tsmEdit.Name = "tsmEdit";
            this.tsmEdit.Size = new System.Drawing.Size(154, 22);
            this.tsmEdit.Text = "Редактировать";
            this.tsmEdit.Click += new System.EventHandler(this.tsmEdit_Click);
            // 
            // tmsDelete
            // 
            this.tmsDelete.Name = "tmsDelete";
            this.tmsDelete.Size = new System.Drawing.Size(154, 22);
            this.tmsDelete.Text = "Удалить";
            this.tmsDelete.Click += new System.EventHandler(this.tmsDelete_Click);
            // 
            // tsmView
            // 
            this.tsmView.Name = "tsmView";
            this.tsmView.Size = new System.Drawing.Size(154, 22);
            this.tsmView.Text = "Просмотр";
            this.tsmView.Click += new System.EventHandler(this.tsmView_Click);
            // 
            // tsmMark
            // 
            this.tsmMark.Name = "tsmMark";
            this.tsmMark.Size = new System.Drawing.Size(154, 22);
            this.tsmMark.Text = "Отметить";
            this.tsmMark.Click += new System.EventHandler(this.tsmMark_Click);
            // 
            // tabOutgoing
            // 
            this.tabOutgoing.Controls.Add(this.dgvOutgoing);
            this.tabOutgoing.Location = new System.Drawing.Point(4, 25);
            this.tabOutgoing.Name = "tabOutgoing";
            this.tabOutgoing.Padding = new System.Windows.Forms.Padding(3);
            this.tabOutgoing.Size = new System.Drawing.Size(1031, 464);
            this.tabOutgoing.TabIndex = 1;
            this.tabOutgoing.Text = "Исходящие";
            this.tabOutgoing.UseVisualStyleBackColor = true;
            // 
            // dgvOutgoing
            // 
            this.dgvOutgoing.AllowUserToAddRows = false;
            this.dgvOutgoing.AllowUserToDeleteRows = false;
            this.dgvOutgoing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOutgoing.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOutgoing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutgoing.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dgvcOutTitle,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dgvcOutMark});
            this.dgvOutgoing.ContextMenuStrip = this.cmsPKM;
            this.dgvOutgoing.Location = new System.Drawing.Point(0, 0);
            this.dgvOutgoing.MultiSelect = false;
            this.dgvOutgoing.Name = "dgvOutgoing";
            this.dgvOutgoing.ReadOnly = true;
            this.dgvOutgoing.RowHeadersVisible = false;
            this.dgvOutgoing.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOutgoing.Size = new System.Drawing.Size(1031, 464);
            this.dgvOutgoing.TabIndex = 2;
            this.dgvOutgoing.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIncoming_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.FillWeight = 50F;
            this.dataGridViewTextBoxColumn1.HeaderText = "№";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MailNumber";
            this.dataGridViewTextBoxColumn2.HeaderText = "Номер письма";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "RegDate";
            this.dataGridViewTextBoxColumn3.HeaderText = "Дата регистрации";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dgvcOutTitle
            // 
            this.dgvcOutTitle.DataPropertyName = "Title";
            this.dgvcOutTitle.HeaderText = "Тема";
            this.dgvcOutTitle.Name = "dgvcOutTitle";
            this.dgvcOutTitle.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ReplyTo";
            this.dataGridViewTextBoxColumn4.HeaderText = "Ответ на письмо";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Reply";
            this.dataGridViewTextBoxColumn5.HeaderText = "Ответное письмо";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Recipient";
            this.dataGridViewTextBoxColumn6.HeaderText = "Получатель";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "MailDate";
            this.dataGridViewTextBoxColumn7.HeaderText = "Дата получения";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn8.HeaderText = "Описание";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Files";
            this.dataGridViewTextBoxColumn9.HeaderText = "Файлы";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dgvcOutMark
            // 
            this.dgvcOutMark.DataPropertyName = "Mark";
            this.dgvcOutMark.HeaderText = "mark";
            this.dgvcOutMark.Name = "dgvcOutMark";
            this.dgvcOutMark.ReadOnly = true;
            this.dgvcOutMark.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 583);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnReloadRecords);
            this.Controls.Add(this.btnAddRecord);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.Text = "Делопроизводитель";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.tcMain.ResumeLayout(false);
            this.tabIncoming.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncoming)).EndInit();
            this.cmsPKM.ResumeLayout(false);
            this.tabOutgoing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutgoing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddRecord;
        private System.Windows.Forms.Button btnReloadRecords;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbStatusText;
        private System.Windows.Forms.Label lbStatusName;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem опрограммеToolStripMenuItem;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabIncoming;
        private System.Windows.Forms.TabPage tabOutgoing;
        private System.Windows.Forms.DataGridView dgvIncoming;
        private System.Windows.Forms.ContextMenuStrip cmsPKM;
        private System.Windows.Forms.ToolStripMenuItem tsmEdit;
        private System.Windows.Forms.ToolStripMenuItem tmsDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmView;
        private System.Windows.Forms.DataGridView dgvOutgoing;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcIncId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcIncMailNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcIncRegDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcIncTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcIncReplyTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcIncReply;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcIncRecipient;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcIncMailDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcIncDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcIncAttach;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcIncMark;
        private System.Windows.Forms.ToolStripMenuItem tsmMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcOutTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcOutMark;
    }
}

