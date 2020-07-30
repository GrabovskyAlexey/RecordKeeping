using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using Microsoft.SqlServer.Server;

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
    }
    class IncomingBD : MailBD
    {
        private String Command;
        
        public override bool Add()
        {
            if(!CheckData())
            {
                return false;
            }
            Command = "INSERT INTO Incoming (MailNumber, RegDate, Title, ReplyTo, Reply, Recipient, " +
                        "MailDate, Description, Files, Mark) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')";
            Command = String.Format(Command, MailNumber, RegDate, Title, ReplyTo, Reply, SenderReciever,
                MailDate, Description, Files, Mark);


            Settings.SqlCommand.CommandText = Command;
            int result = Settings.SqlCommand.ExecuteNonQuery();
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
        }

        public override bool Update()
        {
            if (!CheckData())
            {
                return false;
            }

            Command = "UPDATE Incoming SET MailNumber = '{0}', RegDate = '{1}', Title = '{2}', ReplyTo = '{3}', Reply = '{4}', Recipient = '{5}', " +
                        "MailDate = '{6}', Description = '{7}', Files = '{8}', Mark = '{9}' WHERE Id = '{10}'";
            Command = String.Format(Command,  MailNumber, RegDate, Title, ReplyTo, Reply, SenderReciever,
                MailDate, Description, Files, Mark, Id);

            Settings.SqlCommand.CommandText = Command;
            int result = Settings.SqlCommand.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
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
        public override bool Add()
        {
            if (!CheckData())
            {
                return false;
            }
            Command = "INSERT INTO Outgoing (MailNumber, RegDate, Title, ReplyTo, Reply, Recipient, " +
                        "MailDate, Description, Files, Mark) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')";
            Command = String.Format(Command, MailNumber, RegDate, Title, ReplyTo, Reply, SenderReciever,
                MailDate, Description, Files, Mark);


            Settings.SqlCommand.CommandText = Command;
            int result = Settings.SqlCommand.ExecuteNonQuery();
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
        }

        public override bool Update()
        {
            if (!CheckData())
            {
                return false;
            }

            Command = "UPDATE Outgoing SET MailNumber = '{0}', RegDate = '{1}', Title = '{2}', ReplyTo = '{3}', Reply = '{4}', Recipient = '{5}', " +
                        "MailDate = '{6}', Description = '{7}', Files = '{8}', Mark = '{9}' WHERE Id = '{10}'";
            Command = String.Format(Command, MailNumber, RegDate, Title, ReplyTo, Reply, SenderReciever,
                MailDate, Description, Files, Mark, Id);

            Settings.SqlCommand.CommandText = Command;
            int result = Settings.SqlCommand.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
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
}
