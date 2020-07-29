﻿using System;
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

namespace RecordKeepingNew
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
                    if (cellStyle.BackColor != Color.DarkSalmon) cellStyle.BackColor = Color.DarkSalmon;

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
    }
}