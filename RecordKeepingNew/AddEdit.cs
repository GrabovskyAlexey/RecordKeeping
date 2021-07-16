using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RecordKeeping
{
    public partial class AddEdit : Form
    {
        public Int64 Id { get; set; }
        public String MailNumber { get; set; }
        public String RegDate { get; set; }
        public String ReplyTo { get; set; }
        public String Reply { get; set; }
        public String SenderReciever { get; set; }
        public String MailDate { get; set; }
        public String Description { get; set; }
        public String Files { get; set; }
        public Directions Direction { get; set; }
        public bool Edit { get;  set; }
        private AutoCompleteStringCollection Incoming { get; set; }
        private AutoCompleteStringCollection Outgoing { get; set; }
        private String[] IncomingString { get; set; }
        private String[] OutgoingString { get; set; }

        private int project_id { get; set; }

        public MailBD Record { get; set; }


        public AddEdit()
        {
            InitializeComponent();
        }

        public void LoadData(MailBD rec, Directions direction)
        {
            Direction = direction;
            Record = rec;
            tbMailNumber.Text = Record.MailNumber;
            dtRegDate.Value = DateTime.Parse(Record.RegDate);
            tbTitle.Text = Record.Title;
            cbReplyTo.Text = Record.ReplyTo;
            cbReply.Text = Record.Reply;
            tbSenderReciever.Text = Record.SenderReciever;
            dtMailDate.Value = DateTime.Parse(Record.MailDate);
            tbDescription.Text = Record.Description;
            tbFiles.Text = Record.Files;
            this.project_id = (int)Record.Project;
        }

        private void rbIncoming_CheckedChanged(object sender, EventArgs e)
        {
            lbMailNumber.Text = "Номер Входящего";
            lbSenderRediever.Text = "Отправитель";
            lbMailDate.Text = "Дата получения";
            cbReply.AutoCompleteCustomSource = Outgoing;
            cbReplyTo.AutoCompleteCustomSource = Outgoing;
            cbReply.Items.Clear();
            cbReplyTo.Items.Clear();
            cbReply.Items.AddRange(OutgoingString);
            cbReplyTo.Items.AddRange(OutgoingString);
            lbEmployee.Visible = false;
            cbEmployee.Visible = false;
        }

        private void rbOutgoing_CheckedChanged(object sender, EventArgs e)
        {
            lbMailNumber.Text = "Номер Исходящего";
            lbSenderRediever.Text = "Получатель";
            lbMailDate.Text = "Дата отправки";
            cbReply.AutoCompleteCustomSource = Incoming;
            cbReplyTo.AutoCompleteCustomSource = Incoming;
            cbReply.Items.Clear();
            cbReplyTo.Items.Clear();
            cbReply.Items.AddRange(IncomingString);
            cbReplyTo.Items.AddRange(IncomingString);
            lbEmployee.Visible = true;
            cbEmployee.Visible = true;
        }

        private void btnFiles_Click(object sender, EventArgs e)
        {
            DialogResult result = fbdAttach.ShowDialog();
            if(result == DialogResult.OK)
            {
                tbFiles.Text = fbdAttach.SelectedPath;
                Settings.LastSelectDirectory = fbdAttach.SelectedPath;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (!Edit)
                Record = new RecordBD();
                Record.Mark = 0;

            if (rbIncoming.Checked)
                Record.Direction = 1;
            else if (rbOutgoing.Checked)
                Record.Direction = 2;

            Record.MailNumber = tbMailNumber.Text;
            Record.RegDate = dtRegDate.Value.ToString("dd.MM.yyy");
            Record.Title = tbTitle.Text;
            Record.ReplyTo = cbReplyTo.Text;
            Record.Reply = cbReply.Text;
            Record.SenderReciever = tbSenderReciever.Text;
            Record.MailDate = dtMailDate.Value.ToString("dd.MM.yyy");
            Record.Description = tbDescription.Text;
            Record.Files = tbFiles.Text;
            Record.Project = (long)cbProject.SelectedValue;
            if (!Record.CheckData())
            {
                MessageBox.Show("Заполненны не все обязательные поля", "Проверка данных", MessageBoxButtons.OK);
                if (tbMailNumber.Text == "")
                    tbMailNumber.BorderColor = Color.Red;
                else
                    tbMailNumber.BorderColor = Color.Gray;
                if (tbTitle.Text == "")
                    tbTitle.BorderColor = Color.Red;
                else
                    tbTitle.BorderColor = Color.Gray;
                if (tbSenderReciever.Text == "")
                    tbSenderReciever.BorderColor = Color.Red;
                else
                    tbSenderReciever.BorderColor = Color.Gray;
            }
            else
            {
                if (Edit)
                    result = Record.Update();
                else
                    result = Record.Add();
            }
            if(result)
                this.Close();
        }

        private void AddEdit_Load(object sender, EventArgs e)
        {
            Incoming = new AutoCompleteStringCollection();
            Outgoing = new AutoCompleteStringCollection();
            IncomingString = GetAutocompleteValue(Directions.Incoming);
            OutgoingString = GetAutocompleteValue(Directions.Outgoing);

            var dataSource = GetAutocompleteProject();

            this.cbProject.DataSource = dataSource;
            this.cbProject.DisplayMember = "Name";
            this.cbProject.ValueMember = "Value";
            this.cbProject.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbProject.SelectedValue = (long)project_id;
            Incoming.AddRange(IncomingString);
            Outgoing.AddRange(OutgoingString);
            if (Settings.LastSelectDirectory != null)
                fbdAttach.SelectedPath = Settings.LastSelectDirectory;
            else
                fbdAttach.SelectedPath = fbdAttach.RootFolder.ToString();
            if(Edit)
            {
                this.Text = "Редактирование";
            } 
            else
            {
                this.Text = "Добавить";
            }
            if (Direction == Directions.Incoming)
            {
                lbMailNumber.Text = "Номер Входящего";
                lbSenderRediever.Text = "Отправитель";
                lbMailDate.Text = "Дата получения";
                rbIncoming.Checked = true;
                cbReply.AutoCompleteCustomSource = Outgoing;
                cbReplyTo.AutoCompleteCustomSource = Outgoing;
                lbEmployee.Visible = false;
                cbEmployee.Visible = false;
            }
            else if (Direction == Directions.Outgoing)
            {
                lbMailNumber.Text = "Номер Исходящего";
                lbSenderRediever.Text = "Получатель";
                lbMailDate.Text = "Дата отправки";
                rbOutgoing.Checked = true;
                cbReply.AutoCompleteCustomSource = Incoming;
                cbReplyTo.AutoCompleteCustomSource = Incoming;
                lbEmployee.Visible = true;
                cbEmployee.Visible = true;
            }
        }
        private String[] GetAutocompleteValue(Directions direct)
        {
            List<String> temp_list = new List<string>();
            SQLiteCommand reader = new SQLiteCommand();
            reader.Connection = Settings.Conncetion;
            
            if (direct == Directions.Incoming)
                reader.CommandText = "SELECT MailNumber FROM Records WHERE Direction = '1'";
            else if (direct == Directions.Outgoing)
                reader.CommandText = "SELECT MailNumber FROM Records WHERE Direction = '2'";
            SQLiteDataReader rec = reader.ExecuteReader();
            while(rec.Read())
            {
                temp_list.Add((String)rec["MailNumber"]);
            }
            return temp_list.ToArray();
        }

        private List<Project> GetAutocompleteProject()
        {
            List<Project> temp_list = new List<Project>();
            SQLiteCommand reader = new SQLiteCommand();
            reader.Connection = Settings.Conncetion;            
            reader.CommandText = "SELECT id, project_name FROM projects";
            SQLiteDataReader rec = reader.ExecuteReader();
            temp_list.Add(new Project() { Name = "Без проекта", Value = 0 });
            while (rec.Read())
            {
                temp_list.Add(new Project() { Name = (String)rec["project_name"], Value = (long)rec["id"] });
            }
            return temp_list;
        }

        private Project GetProjectById(long id) 
        {
            SQLiteCommand reader = new SQLiteCommand();
            reader.Connection = Settings.Conncetion;
            String Command = "SELECT id, project_name FROM projects WHERE id='{0}'";
            Command = String.Format(Command, id);
            reader.CommandText = Command;
            SQLiteDataReader rec = reader.ExecuteReader();
            rec.Read();
            return new Project() { Name = (String)rec["project_name"], Value = (long)rec["id"] };
        }

        private void btnClearFormat_Click(object sender, EventArgs e)
        {
            tbDescription.Text = tbDescription.Text.Replace("\n", " ");
            tbDescription.Text = tbDescription.Text.Replace("\r", " ");
        }
        
        public void SetDirection(Directions direction)
        {
            if (direction == Directions.Incoming)
                Direction = Directions.Incoming;
            else if (direction == Directions.Outgoing)
                Direction = Directions.Outgoing;
        }

    }

    public enum Directions
    {
        Incoming = 1,
        Outgoing = 2        
    }

    public class MyTextBox : TextBox
    {
        const int WM_NCPAINT = 0x85;
        const uint RDW_INVALIDATE = 0x1;
        const uint RDW_IUPDATENOW = 0x100;
        const uint RDW_FRAME = 0x400;
        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("user32.dll")]
        static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprc, IntPtr hrgn, uint flags);
        Color borderColor = Color.Gray;
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                RedrawWindow(Handle, IntPtr.Zero, IntPtr.Zero,
                    RDW_FRAME | RDW_IUPDATENOW | RDW_INVALIDATE);
            }
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCPAINT && BorderColor != Color.Transparent &&
                BorderStyle == System.Windows.Forms.BorderStyle.Fixed3D)
            {
                var hdc = GetWindowDC(this.Handle);
                using (var g = Graphics.FromHdcInternal(hdc))
                using (var p = new Pen(BorderColor))
                    g.DrawRectangle(p, new Rectangle(0, 0, Width - 1, Height - 1));
                ReleaseDC(this.Handle, hdc);
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            RedrawWindow(Handle, IntPtr.Zero, IntPtr.Zero,
                   RDW_FRAME | RDW_IUPDATENOW | RDW_INVALIDATE);
        }
    }
}
