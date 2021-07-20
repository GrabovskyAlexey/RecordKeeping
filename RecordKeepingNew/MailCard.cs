using System;
using System.Windows.Forms;
using System.IO;

namespace RecordKeeping
{
    public partial class MailCard : Form
    {
        public Int64 Id { get; set; }
        public String MailNumber { get; set; }
        public String RegDate { get; set; }
        public String Title { get; set; }
        public String ReplyTo { get; set; }
        public String Reply { get; set; }
        public String SenderReciever { get; set; }
        public String MailDate { get; set; }
        public String Description { get; set; }
        public String Files { get; set; }
        public String ProjectName { get; set; }
        public String EmployeeName { get; set; }
        public Directions Direction { get; set; }
        private MailBD Record { get; set; }
        public MailCard()
        {
            InitializeComponent();
        }

        public void LoadData(Int64 RecordId, Directions direct)
        {
            ProjectName = "";
            EmployeeName = "";
            Record = new RecordBD();
            Record.Load(RecordId);
            if (direct == Directions.Incoming)
            {
                this.Text = "Входящее";
            }
            else if(direct == Directions.Outgoing)
            {
                this.Text = "Исходящее";
            }
            
            MailNumber = Record.MailNumber;
            RegDate = Record.RegDate;
            Title = Record.Title;
            ReplyTo = Record.ReplyTo;
            Reply = Record.Reply;
            SenderReciever = Record.SenderReciever;
            MailDate = Record.MailDate;
            Description = Record.Description;
            Files = Record.Files;
            if(Record.Project != 0)
            {
                ProjectBD project = new ProjectBD();
                project.Load(Record.Project);
                ProjectName = project.project_name;
            }
            if (Record.Employee != 0)
            {
                EmployeeBD employee = new EmployeeBD();
                employee.Load(Record.Project);
                EmployeeName = employee.employee_name;
            }
            Direction = direct;
        }

        private void MailCard_Load(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void RefreshData()
        {
            if (Direction == Directions.Incoming)
            {
                lbDirection.Text = "Входящее";
                lbSenderReciever.Text = "Отправитель: " + SenderReciever;
            }
            else if (Direction == Directions.Outgoing)
            {
                lbDirection.Text = "Исходящее";
                lbSenderReciever.Text = "Получатель: " + SenderReciever;
            }
            lbMailNumber.Text = "Номер письма: " + MailNumber;
            lbRegDate.Text = "Дата регистрации: " + RegDate;
            lbMailDate.Text = "Дата получения: " + MailDate;
            lbTitle.Text = Title;

            if (ReplyTo != "")
            {
                lbReplyTo.Text = "Ответ на письмо: " + ReplyTo;
                lbReplyTo.Visible = true;
            }
            else
                lbReplyTo.Visible = false;

            if (Reply != "")
            {
                lbReply.Text = "Ответное письмо: " + Reply;
                lbReply.Visible = true;
            }
            else
                lbReply.Visible = false;

            if (Files == "")
                btnAttach.Visible = false;
            else
                btnAttach.Visible = true;

            if (ProjectName != "")
            {
                lbProject.Text = "Проект: " + ProjectName;
                lbProject.Visible = true;
            }
            else
                lbProject.Visible = false;

            if (EmployeeName != "")
            {
                lbEmployee.Text = "Исполнитель: " + EmployeeName;
                lbEmployee.Visible = true;
            }
            else
                lbEmployee.Visible = false;

            tbDescription.Text = Description;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddEdit edit = new AddEdit();
            edit.Edit = true;
            edit.LoadData(Record, Direction);
            edit.ShowDialog();
            this.Close();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Files))
            {
                System.Diagnostics.Process.Start(Files);
            }
            else
            {
                ErrorPath error = new ErrorPath();
                error.Path = Files;
                error.ShowDialog();
            }
        }

        private void lbReply_Click(object sender, EventArgs e)
        {
            long id = RecordBD.GetIdByMailNumber(Reply);

            if(Form.ModifierKeys == Keys.Control)
            {
                MailCard newCard = new MailCard();
                newCard.LoadData(id, ChangeDirection());
                newCard.Show();
            }
            else
            {
                this.LoadData(id, ChangeDirection());
                this.RefreshData();
            }
        }        

        private void lbReplyTo_Click(object sender, EventArgs e)
        {
            long id = RecordBD.GetIdByMailNumber(ReplyTo);

            if (Form.ModifierKeys == Keys.Control)
            {
                MailCard newCard = new MailCard();
                newCard.LoadData(id, ChangeDirection());
                newCard.Show();
            }
            else
            {
                this.LoadData(id, ChangeDirection());
                this.RefreshData();
            }
        }
        private Directions ChangeDirection()
        {
            if (Direction == Directions.Incoming)
                return Directions.Outgoing;
            else
                return Directions.Incoming;

        }
    }
}
