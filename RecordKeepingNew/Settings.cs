using System;
using System.Data.SQLite;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Data;

namespace RecordKeeping
{
    static class Settings
    {
        private static String SettingsFileName = "Setting.xml";
        public static SQLiteConnection Conncetion { get; set; }
        public static SQLiteCommand SqlCommand { get; set; }
        public static String LastSelectDirectory { get; set; }
        private static String dbFileName = "db.sqlite";
        private static Int32 CurrentDBVersion = 2;
        private static bool NewDB = false;

        public static void Load()
        {
            Settings.LoadSettings();
            CreateConnection();
            if (NewDB)
                CreateTables();
            else if (!CheckDBVersion())
            {
                if (GetDBVersion() == 1)
                    UpdateDB_1_to_2();
            }
        }

        public static void CreateConnection()
        {
            if (!File.Exists(dbFileName))
            {
                SQLiteConnection.CreateFile(dbFileName);
                NewDB = true;
            }

            Conncetion = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
            SqlCommand = new SQLiteCommand();

            Conncetion.Open();

            SqlCommand.Connection = Conncetion;
        }

        private static void CreateTables()
        {
            SqlCommand.CommandText = "CREATE TABLE IF NOT EXISTS Records (id INTEGER PRIMARY KEY AUTOINCREMENT, Direction INT, MailNumber TEXT, RegDate TEXT, Title TEXT, ReplyTo TEXT, Reply TEXT, SenderReceiver TEXT, MailDate TEXT, Description TEXT, Files TEXT, Mark INT, project INTEGER, FOREIGN KEY(project) REFERENCES projects(id) ON DELETE SET NULL)";
            SqlCommand.ExecuteNonQuery();
            SqlCommand.CommandText = "CREATE TABLE IF NOT EXISTS projects (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, project_name TEXT NOT NULL)";
            SqlCommand.ExecuteNonQuery();
            SqlCommand.CommandText = "CREATE TABLE IF NOT EXISTS settings(name TEXT, value TEXT)";
            SqlCommand.ExecuteNonQuery();
            SqlCommand.CommandText = String.Format("INSERT INTO settings ('name', 'value') values ('version', '{0}')", CurrentDBVersion);
            SqlCommand.ExecuteNonQuery();
        }

        private static Int32 GetDBVersion()
        {
            SqlCommand = new SQLiteCommand();

            if (Conncetion.State != System.Data.ConnectionState.Open)
                Conncetion.Open();

            SqlCommand.Connection = Conncetion;
            SqlCommand.CommandText = "CREATE TABLE IF NOT EXISTS settings(name TEXT, value TEXT)";
            SqlCommand.ExecuteNonQuery();
            SqlCommand.CommandText = "SELECT * FROM settings WHERE name LIKE 'version'";
            SQLiteDataReader rec = SqlCommand.ExecuteReader();
            if (!rec.HasRows)
            {
                SQLiteCommand Command = new SQLiteCommand();
                Command.Connection = Conncetion;
                Command.CommandText = "INSERT INTO settings ('name', 'value') values ('version', '1')";
                Command.ExecuteNonQuery();
                return 1;
            }
            rec.Read();
            String value = (String)rec["value"];
            rec.Close();
            return int.Parse(value); 
        }

        private static bool CheckDBVersion()
        {
            int DBVersion = GetDBVersion();
            
            if (DBVersion != CurrentDBVersion)
                return false;
            else
                return true;
        }

        private static void SetDBVersion(Int32 ver)
        {
            SqlCommand = new SQLiteCommand();

            if (Conncetion.State != System.Data.ConnectionState.Open)
                Conncetion.Open();

            SqlCommand.Connection = Conncetion;
            SqlCommand.CommandText = String.Format("UPDATE settings SET value = {0} WHERE name LIKE 'version'", ver);
            SqlCommand.ExecuteNonQuery();
        }

        private static void UpdateDB_1_to_2()
        {
            SqlCommand = new SQLiteCommand();

            if (Conncetion.State != System.Data.ConnectionState.Open)
                Conncetion.Open();

            SqlCommand.Connection = Conncetion;

            SqlCommand.CommandText = "CREATE TABLE IF NOT EXISTS Records (id INTEGER PRIMARY KEY AUTOINCREMENT, Direction INT, MailNumber TEXT, RegDate TEXT, Title TEXT, ReplyTo TEXT, Reply TEXT, SenderReceiver TEXT, MailDate TEXT, Description TEXT, Files TEXT, Mark INT, project INTEGER, FOREIGN KEY(project) REFERENCES projects(id) ON DELETE SET NULL)";
            SqlCommand.ExecuteNonQuery();

            SQLiteDataReader dr;

            SqlCommand.CommandText = "SELECT * FROM Incoming";
            dr = SqlCommand.ExecuteReader();

            while (dr.Read())
            {
                RecordBD record = new RecordBD();
                record.Direction = 1;
                record.MailNumber = (string)dr["MailNumber"];
                record.RegDate = (string)dr["RegDate"];
                record.Title = (string)dr["Title"];
                record.ReplyTo = (string)dr["ReplyTo"];
                record.Reply = (string)dr["Reply"];
                record.SenderReciever = (string)dr["Recipient"];
                record.MailDate = (string)dr["MailDate"];
                record.Description = (string)dr["Description"];
                record.Files = (string)dr["Files"];
                record.Mark = (Int32)dr["Mark"];
                record.Project = (Int64)dr["project"];

                if (!record.Add(true))
                    break;
            }
            dr.Close();

            SqlCommand.CommandText = "SELECT * FROM Outgoing";
            dr = SqlCommand.ExecuteReader();

            while (dr.Read())
            {
                RecordBD record = new RecordBD();
                record.Direction = 2;
                record.MailNumber = (string)dr["MailNumber"];
                record.RegDate = (string)dr["RegDate"];
                record.Title = (string)dr["Title"];
                record.ReplyTo = (string)dr["ReplyTo"];
                record.Reply = (string)dr["Reply"];
                record.SenderReciever = (string)dr["Recipient"];
                record.MailDate = (string)dr["MailDate"];
                record.Description = (string)dr["Description"];
                record.Files = (string)dr["Files"];
                record.Mark = (Int32)dr["Mark"];
                record.Project = (Int64)dr["project"];

                if (!record.Add(true))
                    break;
            }
            dr.Close();

            DeleteOldTables("Incoming");
            DeleteOldTables("Outgoing");

            SetDBVersion(2);

        }

        private static void DeleteOldTables(String TableName)
        {
            SqlCommand.CommandText = "DROP TABLE IF EXISTS " + TableName;
            SqlCommand.ExecuteNonQuery();            
        }

        private static void LoadSettings()
        {
            if (File.Exists(Settings.SettingsFileName))
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(Settings.SettingsFileName);
                XmlNodeList LastDir =  xDoc.GetElementsByTagName("LastSelectDirectory");
                Settings.LastSelectDirectory = LastDir[0].InnerText;
            }
        }
        public static void SaveSettings()
        {
            XmlDocument xDoc = new XmlDocument();
            XmlDeclaration declar = xDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement LastDir = xDoc.CreateElement("LastSelectDirectory");
            XmlElement settings = xDoc.CreateElement("Settings");
            LastDir.InnerText = Settings.LastSelectDirectory;
            xDoc.AppendChild(declar);
            xDoc.AppendChild(settings);
            settings.AppendChild(LastDir);
            xDoc.Save(Settings.SettingsFileName);
        }
    }
}
