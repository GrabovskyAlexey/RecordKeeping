using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using RecordKeeping;

namespace RecordKeeping
{
    public partial class MainForm : Form
    {
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
        }

        void dgvInc_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if ((e.RowIndex > -1) && (e.RowIndex < dgvIncoming.RowCount))
            {
                DataGridViewCellStyle cellStyle = dgvIncoming.Rows[e.RowIndex].DefaultCellStyle;
                if (dgvIncoming.Rows[e.RowIndex].Cells["dgvcIncMark"].Value.ToString() == "1")
                {
                    if (cellStyle.BackColor != Color.DarkSalmon) cellStyle.BackColor = Color.MistyRose;

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
        }

        private void tmsDelete_Click(object sender, EventArgs e)
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
            DialogResult result = MessageBox.Show("Вы уверенны что хотите удалить письмо " + Record.MailNumber + "?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result == DialogResult.Yes)
            {
                Record.Delete();
            }
            this.ReloadData();
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
    }
}
