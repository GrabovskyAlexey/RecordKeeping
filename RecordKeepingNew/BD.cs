﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace RecordKeeping
{
    public abstract class MailBD
    {
        public abstract bool Update();
        public abstract bool Delete();
        public abstract bool Add();
        public abstract void Load(Int64 Id);
        public abstract bool CheckData();
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
        public int Mark { get; set; }
        public long Project { get; set; }

    }
    class IncomingBD : MailBD
    {
        private String Command;
        public bool Single = true;

        public override bool Add()
        {
            SQLiteCommand sqlc = new SQLiteCommand();
            sqlc.Connection = Settings.Conncetion;
            if (!CheckData())
            {
                return false;
            }
            Command = "INSERT INTO Incoming (MailNumber, RegDate, Title, ReplyTo, Reply, Recipient, " +
                        "MailDate, Description, Files, Mark, project) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}, '{10}')";
            Command = String.Format(Command, MailNumber.Trim(), RegDate, Title.Trim(), ReplyTo.Trim(), Reply.Trim(), SenderReciever.Trim(),
                MailDate, Description, Files, Mark, Project);


            sqlc.CommandText = Command;
            if (this.Single)
                BeforeSave();
            int result = sqlc.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }

        public override bool Delete()
        {
            Command = "DELETE FROM Incoming WHERE Id = {0}";
            Command = String.Format(Command, Id);
            Settings.SqlCommand.CommandText = Command;
            int result = Settings.SqlCommand.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }

        public override void Load(long Id)
        {
            SQLiteCommand reader = new SQLiteCommand();
            reader.Connection = Settings.Conncetion;
            Command = "SELECT * FROM Incoming WHERE Id={0}";
            Command = String.Format(Command, Id);
            reader.CommandText = Command;
            SQLiteDataReader rec = reader.ExecuteReader();
            rec.Read();
            this.Id = (long)rec["Id"];
            MailNumber = (String)rec["MailNumber"];
            RegDate = (String)rec["RegDate"];
            Title = (String)rec["Title"];
            ReplyTo = (String)rec["ReplyTo"];
            Reply = (String)rec["Reply"];
            SenderReciever = (String)rec["Recipient"];
            MailDate = (String)rec["MailDate"];
            Description = (String)rec["Description"];
            Files = (String)rec["Files"];
            Mark = (int)rec["Mark"];
            if (rec["project"].GetType() != typeof(DBNull))
                Project = (long)rec["project"];
            else
                Project = 0;
        }

        public override bool Update()
        {
            if (!CheckData())
            {
                return false;
            }
            SQLiteCommand sqlc = new SQLiteCommand();
            sqlc.Connection = Settings.Conncetion;
            Command = "UPDATE Incoming SET MailNumber = '{0}', RegDate = '{1}', Title = '{2}', ReplyTo = '{3}', Reply = '{4}', Recipient = '{5}', " +
                        "MailDate = '{6}', Description = '{7}', Files = '{8}', Mark = '{9}', project = '{10}' WHERE Id = '{11}'";
            Command = String.Format(Command, MailNumber.Trim(), RegDate, Title.Trim(), ReplyTo.Trim(), Reply.Trim(), SenderReciever.Trim(),
                MailDate, Description, Files, Mark, Project, Id);

            sqlc.CommandText = Command;
            if (this.Single)
                BeforeSave();
            int result = sqlc.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }

        private void BeforeSave()
        {
            if (this.Reply != "")
            {
                SQLiteCommand reader = new SQLiteCommand();
                reader.Connection = Settings.Conncetion;
                Command = "SELECT * FROM Outgoing WHERE MailNumber LIKE '{0}'";
                Command = String.Format(Command, this.Reply);
                reader.CommandText = Command;
                SQLiteDataReader rec = reader.ExecuteReader();
                rec.Read();
                OutgoingBD Reply = new OutgoingBD();
                try
                {
                    Id = (long)rec["Id"];
                    Reply.Load(Id);
                    Reply.Single = false;
                    Reply.ReplyTo = this.MailNumber;
                    Reply.Update();
                }
                catch
                {
                    MessageBox.Show("Не найдено связанное ответное сообщение");
                }
            }

            if (this.ReplyTo != "")
            {
                SQLiteCommand reader = new SQLiteCommand();
                reader.Connection = Settings.Conncetion;
                Command = "SELECT * FROM Outgoing WHERE MailNumber LIKE '{0}'";
                Command = String.Format(Command, this.ReplyTo);
                reader.CommandText = Command;
                SQLiteDataReader rec = reader.ExecuteReader();
                rec.Read();
                OutgoingBD ReplyTo = new OutgoingBD();
                try
                {
                    Id = (long)rec["Id"];
                    ReplyTo.Load(Id);
                    ReplyTo.Single = false;
                    ReplyTo.Reply = this.MailNumber;
                    ReplyTo.Update();
                }
                catch
                {
                    MessageBox.Show("Не найдено связанное сообщение на которое данное является ответом.");
                }
            }
        }
        public override bool CheckData()
        {
            if (MailNumber == "" || RegDate == "" || SenderReciever == "" || MailDate == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    class OutgoingBD : MailBD
    {
        private String Command;
        public bool Single = true;
        public override bool Add()
        {
            SQLiteCommand sqlc = new SQLiteCommand();
            sqlc.Connection = Settings.Conncetion;
            if (!CheckData())
            {
                return false;
            }
            Command = "INSERT INTO Outgoing (MailNumber, RegDate, Title, ReplyTo, Reply, Recipient, " +
                        "MailDate, Description, Files, Mark, project) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}')";
            Command = String.Format(Command, MailNumber.Trim(), RegDate, Title.Trim(), ReplyTo.Trim(), Reply.Trim(), SenderReciever.Trim(),
                MailDate, Description, Files, Mark, Project);


            sqlc.CommandText = Command;
            if (this.Single)
                BeforeSave();
            int result = sqlc.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }

        public override bool Delete()
        {
            Command = "DELETE FROM Outgoing WHERE Id = {0}";
            Command = String.Format(Command, Id);
            Settings.SqlCommand.CommandText = Command;
            int result = Settings.SqlCommand.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }

        public override void Load(long Id)
        {
            SQLiteCommand reader = new SQLiteCommand();
            reader.Connection = Settings.Conncetion;
            Command = "SELECT * FROM Outgoing WHERE Id = {0}";
            Command = String.Format(Command, Id);
            reader.CommandText = Command;
            SQLiteDataReader rec = reader.ExecuteReader();
            rec.Read();
            this.Id = (long)rec["Id"];
            MailNumber = (String)rec["MailNumber"];
            RegDate = (String)rec["RegDate"];
            Title = (String)rec["Title"];
            ReplyTo = (String)rec["ReplyTo"];
            Reply = (String)rec["Reply"];
            SenderReciever = (String)rec["Recipient"];
            MailDate = (String)rec["MailDate"];
            Description = (String)rec["Description"];
            Files = (String)rec["Files"];
            Mark = (int)rec["Mark"];
            if (rec["project"].GetType() != typeof(DBNull))
                Project = (long)rec["project"];
            else
                Project = 0;
        }

        public override bool Update()
        {
            SQLiteCommand sqlc = new SQLiteCommand();
            sqlc.Connection = Settings.Conncetion;
            if (!CheckData())
            {
                return false;
            }

            Command = "UPDATE Outgoing SET MailNumber = '{0}', RegDate = '{1}', Title = '{2}', ReplyTo = '{3}', Reply = '{4}', Recipient = '{5}', " +
                        "MailDate = '{6}', Description = '{7}', Files = '{8}', Mark = '{9}', project = '{10}' WHERE Id = '{10}'";
            Command = String.Format(Command, MailNumber.Trim(), RegDate, Title, ReplyTo.Trim(), Reply.Trim(), SenderReciever.Trim(),
                MailDate, Description, Files, Mark, Project, Id);

            sqlc.CommandText = Command;
            if (this.Single)
                BeforeSave();
            int result = sqlc.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }
        private void BeforeSave()
        {
            if (this.Reply != "")
            {
                SQLiteCommand reader = new SQLiteCommand();
                reader.Connection = Settings.Conncetion;
                Command = "SELECT * FROM Incoming WHERE MailNumber LIKE '{0}'";
                Command = String.Format(Command, this.Reply);
                reader.CommandText = Command;
                SQLiteDataReader rec = reader.ExecuteReader();
                rec.Read();
                IncomingBD Reply = new IncomingBD();
                try
                {
                    Id = (long)rec["Id"];
                    Reply.Load(Id);
                    Reply.Single = false;
                    Reply.ReplyTo = this.MailNumber;
                    Reply.Update();
                }
                catch
                {
                    MessageBox.Show("Не найдено связанное ответное сообщение");
                }
            }

            if (this.ReplyTo != "")
            {
                SQLiteCommand reader = new SQLiteCommand();
                reader.Connection = Settings.Conncetion;
                Command = "SELECT * FROM Incoming WHERE MailNumber LIKE '{0}'";
                Command = String.Format(Command, this.ReplyTo);
                reader.CommandText = Command;
                SQLiteDataReader rec = reader.ExecuteReader();
                rec.Read();
                IncomingBD ReplyTo = new IncomingBD();
                try
                {
                    Id = (long)rec["Id"];
                    ReplyTo.Load(Id);
                    ReplyTo.Single = false;
                    ReplyTo.Reply = this.MailNumber;
                    ReplyTo.Update();
                }
                catch
                {
                    MessageBox.Show("Не найдено связанное сообщение на которое данное является ответом.");
                }
            }
        }
        public override bool CheckData()
        {
            if (MailNumber == "" || RegDate == "" || SenderReciever == "" || MailDate == "" || Title == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    class Project
    {        
        public string Name { get; set; }
        public long Value { get; set; }
    }

    class ProjectBD
    {
        private String Command;
        public String project_name { get; set; }
        public Int64 Id { get; set; }

        public bool Add() 
        {
            SQLiteCommand sqlc = new SQLiteCommand();
            sqlc.Connection = Settings.Conncetion;
            Command = "INSERT INTO projects (project_name) values ('{0}')";
            Command = String.Format(Command, project_name.Trim());

            sqlc.CommandText = Command;
            int result = sqlc.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }

        public bool Update()
        {
            SQLiteCommand sqlc = new SQLiteCommand();
            sqlc.Connection = Settings.Conncetion;
            Command = "UPDATE projects SET project_name='{0}' WHERE id={1}";
            Command = String.Format(Command, project_name.Trim(), Id);

            sqlc.CommandText = Command;
            int result = sqlc.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }

        public bool Delete()
        {
            Command = "DELETE FROM projects WHERE Id = {0}";
            Command = String.Format(Command, Id);
            Settings.SqlCommand.CommandText = Command;
            int result = Settings.SqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Command = String.Format("UPDATE Outgoing SET project='' WHERE project={0}", Id);
                Settings.SqlCommand.CommandText = Command;
                Settings.SqlCommand.ExecuteNonQuery();

                Command = String.Format("UPDATE Incoming SET project='' WHERE project={0}", Id);
                Settings.SqlCommand.CommandText = Command;
                Settings.SqlCommand.ExecuteNonQuery();
                return true;
            }
            else
                return false;
        }

        public void Load(Int64 Id)
        {
            SQLiteCommand reader = new SQLiteCommand();
            reader.Connection = Settings.Conncetion;
            Command = "SELECT * FROM projects WHERE Id = {0}";
            Command = String.Format(Command, Id);
            reader.CommandText = Command;
            SQLiteDataReader rec = reader.ExecuteReader();
            rec.Read();
            this.Id = (long)rec["Id"];
            project_name = (String)rec["project_name"];
        }
    }
}
