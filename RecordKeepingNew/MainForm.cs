using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace RecordKeeping
{
    public partial class MainForm : Form
    {
        int IncomingSelected = 0;
        int OutgoingSelected = 0;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Settings.Load();
            if(Settings.Conncetion.State == ConnectionState.Open)
                lbStatusText.Text = "Подключена";
            else
                lbStatusText.Text = "Отключена";
            this.ReloadData();
        }

        public void ReloadData() 
        {
            DataTable dTableInc = new DataTable();
            DataTable dTableOut = new DataTable();

            dTableInc.Columns.AddRange(getColumnList());
            dTableOut.Columns.AddRange(getColumnList());

            if (dgvIncoming.Rows.Count > 0)
            {
                for (int i = 0; i < dgvIncoming.Rows.Count; i++)
                    if (dgvIncoming.Rows[i].Selected == true)
                        IncomingSelected = i;
            }
            if (dgvOutgoing.Rows.Count > 0)
            {
                for (int i = 0; i < dgvOutgoing.Rows.Count; i++)
                    if (dgvOutgoing.Rows[i].Selected == true)
                        OutgoingSelected = i;
            }

            String sqlQuery;

            try
            {
                sqlQuery = "SELECT * FROM Incoming";
                SQLiteDataAdapter adapterIncoming = new SQLiteDataAdapter(sqlQuery, Settings.Conncetion);
                adapterIncoming.Fill(dTableInc);
                dTableInc.DefaultView.Sort = "RegDate ASC";
                
                dgvIncoming.DataSource = dTableInc.DefaultView;
                                
                sqlQuery = "SELECT * FROM Outgoing";
                SQLiteDataAdapter adapterOutgoing = new SQLiteDataAdapter(sqlQuery, Settings.Conncetion);
                adapterOutgoing.Fill(dTableOut);
                dTableOut.DefaultView.Sort = "RegDate ASC";

                dgvOutgoing.DataSource = dTableOut.DefaultView;
                dgvIncoming.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dgvInc_RowPrePaint);
                dgvOutgoing.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dgvOut_RowPrePaint);
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            dgvIncoming.Rows[IncomingSelected].Selected = true;
            dgvOutgoing.Rows[OutgoingSelected].Selected = true;
            
        }

        void dgvInc_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if ((e.RowIndex > -1) && (e.RowIndex < dgvIncoming.RowCount))
            {
                DataGridViewCellStyle cellStyle = dgvIncoming.Rows[e.RowIndex].DefaultCellStyle;
                if (dgvIncoming.Rows[e.RowIndex].Cells["dgvcIncMark"].Value.ToString() == "1")
                {
                    if (cellStyle.BackColor != Color.MistyRose) cellStyle.BackColor = Color.MistyRose;

                }
            }
        }

        void dgvOut_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if ((e.RowIndex > -1) && (e.RowIndex < dgvOutgoing.RowCount))
            {
                DataGridViewCellStyle cellStyle = dgvOutgoing.Rows[e.RowIndex].DefaultCellStyle;
                if (dgvOutgoing.Rows[e.RowIndex].Cells["dgvcOutMark"].Value.ToString() == "1")
                {
                    if (cellStyle.BackColor != Color.Red) cellStyle.BackColor = Color.Red;
                }
            }
        }

        private void btnReloadRecords_Click(object sender, EventArgs e)
        {
            this.ReloadData();

        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            AddEdit addEdit = new AddEdit();
            if (tcMain.SelectedTab == tabIncoming)
                addEdit.SetDirection(Directions.Incoming);
            else if (tcMain.SelectedTab == tabOutgoing)
                addEdit.SetDirection(Directions.Outgoing);
            addEdit.ShowDialog();
            this.ReloadData();
        }

        private void tsmView_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            MailCard card = new MailCard();
            if (tcMain.SelectedTab == tabIncoming)
            {
                row = dgvIncoming.CurrentRow;
                card.LoadData((long)row.Cells[0].Value, Directions.Incoming);
            }
            else if (tcMain.SelectedTab == tabOutgoing)
            {
                row = dgvOutgoing.CurrentRow;
                card.LoadData((long)row.Cells[0].Value, Directions.Outgoing);
            }
            card.ShowDialog();            
            this.ReloadData();
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            MailBD Record = new IncomingBD();
            Directions direction = new Directions();
            if (tcMain.SelectedTab == tabIncoming)
            {
                row = dgvIncoming.CurrentRow;
                Record = new IncomingBD();
                direction = Directions.Incoming;
            }
            else if (tcMain.SelectedTab == tabOutgoing)
            {
                row = dgvOutgoing.CurrentRow;
                Record = new OutgoingBD();
                direction = Directions.Outgoing;
            }
            Record.Load((long)row.Cells[0].Value);
            AddEdit edit = new AddEdit();
            edit.Edit = true;
            edit.LoadData(Record, direction);
            edit.ShowDialog();
            this.ReloadData();
        }

        private void tmsDelete_Click(object sender, EventArgs e)
        {
            long id;

            if (tcMain.SelectedTab == tabIncoming)
            {
                id = (long)dgvIncoming.CurrentRow.Cells[0].Value;
                DeleteRecord(Directions.Incoming, id);

            }
            else if (tcMain.SelectedTab == tabOutgoing)
            {
                id = (long)dgvOutgoing.CurrentRow.Cells[0].Value;
                DeleteRecord(Directions.Outgoing, id);
            }
        }

        private void tsmMark_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            MailBD Record = new IncomingBD();
            if (tcMain.SelectedTab == tabIncoming)
            {
                row = dgvIncoming.CurrentRow;
                Record = new IncomingBD();

            }
            else if (tcMain.SelectedTab == tabOutgoing)
            {
                row = dgvOutgoing.CurrentRow;
                Record = new OutgoingBD();
            }
            Record.Load((long)row.Cells[0].Value);
            if(Record.Mark == 1)
            {
                Record.Mark = 0;
            }
            else
            {
                Record.Mark = 1;
            }
            Record.Update();
            this.ReloadData();
        }

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void dgvIncoming_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            MailCard card = new MailCard();
            if (tcMain.SelectedTab == tabIncoming)
            {
                row = dgvIncoming.CurrentRow;
                card.LoadData((long)row.Cells[0].Value, Directions.Incoming);
            }
            else if (tcMain.SelectedTab == tabOutgoing)
            {
                row = dgvOutgoing.CurrentRow;
                card.LoadData((long)row.Cells[0].Value, Directions.Outgoing);
            }
            card.ShowDialog();
            this.ReloadData();
        }

        private DataColumn[] getColumnList()
        {
            List<DataColumn> columnList = new List<DataColumn>();

            DataColumn colId = new DataColumn("Id");
            colId.DataType = System.Type.GetType("System.Int64");
            columnList.Add(colId);

            DataColumn colMailNumber = new DataColumn("MailNumber");
            colMailNumber.DataType = System.Type.GetType("System.String");
            columnList.Add(colMailNumber);

            DataColumn colRegDate = new DataColumn("RegDate");
            colRegDate.DataType = System.Type.GetType("System.DateTime");
            columnList.Add(colRegDate);

            DataColumn colTitle = new DataColumn("Title");
            colTitle.DataType = System.Type.GetType("System.String");
            columnList.Add(colTitle);

            DataColumn colReplyTo = new DataColumn("ReplyTo");
            colReplyTo.DataType = System.Type.GetType("System.String");
            columnList.Add(colReplyTo);

            DataColumn colReply = new DataColumn("Reply");
            colReply.DataType = System.Type.GetType("System.String");
            columnList.Add(colReply);

            DataColumn colRecitient = new DataColumn("Recipient");
            colRecitient.DataType = System.Type.GetType("System.String");
            columnList.Add(colRecitient);

            DataColumn colMailDate = new DataColumn("MailDate");
            colMailDate.DataType = System.Type.GetType("System.DateTime");
            columnList.Add(colMailDate);

            DataColumn colDescription = new DataColumn("Description");
            colDescription.DataType = System.Type.GetType("System.String");
            columnList.Add(colDescription);

            DataColumn colFiles = new DataColumn("Files");
            colFiles.DataType = System.Type.GetType("System.String");
            columnList.Add(colFiles);

            DataColumn colMark = new DataColumn("Mark");
            colMark.DataType = System.Type.GetType("System.Int32");
            columnList.Add(colMark);

            return columnList.ToArray();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Conncetion.Close();
            if (!Directory.Exists("backup"))
                Directory.CreateDirectory("backup");
            String backupFileName = "backup/" + DateTime.Now.ToString("yyMMdd_HHmm_") + "db.sqlite";

            File.Copy("db.sqlite", backupFileName);

            Settings.SaveSettings();
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool find = false;
            frmSearch search = new frmSearch();
            search.ShowDialog();
            DataGridView dgv = new DataGridView();
            if (tcMain.SelectedTab == tabIncoming)
            {
                dgv = dgvIncoming;
            }
            else if (tcMain.SelectedTab == tabOutgoing)
            {
                dgv = dgvOutgoing;
            }
            if (search.SearchText != "" && search.SearchText != null)
            {
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    dgv.Rows[i].Selected = false;
                    if (dgv.Rows[i].Cells[1].Value.ToString().Contains(search.SearchText) || dgv.Rows[i].Cells[3].Value.ToString().Contains(search.SearchText))
                    {
                        find = true;
                        dgv.Rows[i].Selected = true;
                        break;
                    }
                }
            }
            if (!find)
            {
                MessageBox.Show("Данные по запросу " + search.SearchText + " не найдены", "Результат поиска");
            }
        }

        private void btnAddRecord_MouseHover(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(btnAddRecord, "Добавить");
        }

        private void btnReloadRecords_MouseHover(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(btnReloadRecords, "Обновить");
        }

        private void btnSearch_MouseHover(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(btnSearch, "Поиск");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            long id;
            
            if (tcMain.SelectedTab == tabIncoming)
            {
                id = (long)dgvIncoming.CurrentRow.Cells[0].Value;
                DeleteRecord(Directions.Incoming, id);

            }
            else if (tcMain.SelectedTab == tabOutgoing)
            {
                id = (long)dgvOutgoing.CurrentRow.Cells[0].Value;
                DeleteRecord(Directions.Outgoing, id);
            }
            
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(btnDelete, "Удалить");
        }

        private void DeleteRecord(Directions direction, long id)
        {
            MailBD Record = new IncomingBD();
            if (direction == Directions.Incoming)                
                Record = new IncomingBD();
            else if (direction == Directions.Outgoing)
                Record = new OutgoingBD();
            
            Record.Load(id);
            DialogResult result = MessageBox.Show("Вы уверенны что хотите удалить письмо " + Record.MailNumber + "?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Record.Delete();
            }
            this.ReloadData();
        }
    }
}
