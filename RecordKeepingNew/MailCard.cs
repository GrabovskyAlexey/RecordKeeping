﻿using System;
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
            lbMailNumber.Text += MailNumber;
            lbRegDate.Text += RegDate;
            lbMailDate.Text += MailDate;
            lbTitle.Text = Title;

            if (ReplyTo != "") 
                lbReplyTo.Text += ReplyTo;
            else
                lbReplyTo.Visible = false;

            if (Reply != "")
                lbReply.Text += Reply;
            else
                lbReply.Visible = false;

            if (Files == "")
            {

                btnAttach.Visible = false;
            }

            if (ProjectName != "")
                lbProject.Text += ProjectName;
            else
                lbProject.Visible = false;

            if (EmployeeName != "")
                lbEmployee.Text += EmployeeName;
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
    }
}
