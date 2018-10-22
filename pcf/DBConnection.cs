using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace pcf {
    public class DBConnection {
        private DBConnection() {
        }

        private string databaseName = string.Empty;
        public string DatabaseName {
            get {
                return databaseName;
            }
            set {
                databaseName = value;
            }
        }

        public string Password {
            get; set;
        }
        private MySqlConnection connection = null;
        public MySqlConnection Connection {
            get {
                return connection;
            }
        }

        private static DBConnection _instance = null;
        public static DBConnection Instance() {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public bool IsConnect() {
            if (Connection == null) {
                if (String.IsNullOrEmpty(databaseName))
                    return false;
                string connstring = string.Format("Server=us-cdbr-iron-east-01.cleardb.net; database=ad_8db3f085ffef489; UID=b0736fd8272bd7; password=c26de3e4", databaseName);
                connection = new MySqlConnection(connstring);
                connection.Open();
            }

            return true;
        }

        public void Close() {
            connection.Close();
        }
    }
}
