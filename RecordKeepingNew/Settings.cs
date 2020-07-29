using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace RecordKeepingNew
{
    static class Settings
    {
        public static SQLiteConnection Conncetion { get; set; }
        public static SQLiteCommand SqlCommand { get; set; }
        private static String dbFileName = "db.sqlite";

        public static void Load()
        {
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

            SqlCommand.CommandText = "CREATE TABLE IF NOT EXISTS Incoming (id INTEGER PRIMARY KEY AUTOINCREMENT, MailNumber TEXT, RegDate TEXT, Title TEXT, ReplyTo TEXT, Reply TEXT, Recipient TEXT, MailDate TEXT, Description TEXT, Files TEXT, Mark INT )";
            SqlCommand.ExecuteNonQuery();
            SqlCommand.CommandText = "CREATE TABLE IF NOT EXISTS Outgoing (id INTEGER PRIMARY KEY AUTOINCREMENT, MailNumber TEXT, RegDate TEXT, Title TEXT, ReplyTo TEXT, Reply TEXT, Recipient TEXT, MailDate TEXT, Description TEXT, Files TEXT, Mark INT )";
            SqlCommand.ExecuteNonQuery();

        }
    }
}
