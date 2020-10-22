using System;
using System.Data.SQLite;
using System.IO;
using System.Xml;

namespace RecordKeeping
{
    static class Settings
    {
        private static String SettingsFileName = "Setting.xml";
        public static SQLiteConnection Conncetion { get; set; }
        public static SQLiteCommand SqlCommand { get; set; }
        public static String LastSelectDirectory { get; set; }
        private static String dbFileName = "db.sqlite";

        public static void Load()
        {
            Settings.LoadSettings();
            CreateConnection();
        }

        public static void CreateConnection()
        {
            if (!File.Exists(dbFileName))
                SQLiteConnection.CreateFile(dbFileName);

            Conncetion = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
            SqlCommand = new SQLiteCommand();

            Conncetion.Open();
            
            SqlCommand.Connection = Conncetion;

            SqlCommand.CommandText = "CREATE TABLE IF NOT EXISTS Incoming (id INTEGER PRIMARY KEY AUTOINCREMENT, MailNumber TEXT, RegDate TEXT, Title TEXT, ReplyTo TEXT, Reply TEXT, Recipient TEXT, MailDate TEXT, Description TEXT, Files TEXT, Mark INT, project INTEGER, FOREIGN KEY(project) REFERENCES projects(id) ON DELETE SET NULL)";
            SqlCommand.ExecuteNonQuery();
            SqlCommand.CommandText = "CREATE TABLE IF NOT EXISTS Outgoing (id INTEGER PRIMARY KEY AUTOINCREMENT, MailNumber TEXT, RegDate TEXT, Title TEXT, ReplyTo TEXT, Reply TEXT, Recipient TEXT, MailDate TEXT, Description TEXT, Files TEXT, Mark INT, project INTEGER, FOREIGN KEY(project) REFERENCES projects(id) ON DELETE SET NULL)";
            SqlCommand.ExecuteNonQuery();
            SqlCommand.CommandText = "CREATE TABLE IF NOT EXISTS projects (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, project_name TEXT NOT NULL)";
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
