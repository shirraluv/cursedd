using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using cursedd.Database;
using MySqlConnector;

namespace cursedd
{
    internal class DB
    {
        private DB() { }
        static DB instance;
        public static DB GetInstance()
        {
            if (instance == null)
                instance = new();
            return instance;
        }

        internal void AddData(Rieltor edit)
        {
            if (OpenConnection())
            {
                string sql = "INSERT INTO curse.rieltor (name, surname, patronymic, percent, phone) VALUES (@Name, @Name, @patronymic, @Percent, @Phone);";
                MySqlParameter[] parameters = new MySqlParameter[] {
                    new MySqlParameter("Name", edit.Name),
                    new MySqlParameter("Surname", edit.Name),
                    new MySqlParameter("Patronymic", edit.Patronymic),
                    new MySqlParameter("Percent", edit.Percent),
                    new MySqlParameter("Phone", edit.Phone)
                };
                MySqlHelper.ExecuteNonQuery(connection, sql, parameters);
                connection.Close();
            }
        } 
        public int GetNextID(string table)
        {
            int id = 0;
            if (OpenConnection())
            {
                string sql = $"SHOW TABLE STATUS FROM curse WHERE Name = '{table}'";
                using (var mc = new MySqlCommand(sql, connection))
                using (var dr = mc.ExecuteReader())
                {
                    if (dr.Read())
                        id = dr.GetInt32("Auto_increment");
                }
                connection.Close();
            }
            return id;
        }
        bool OpenConnection()
        {
            if (connection == null)
                ConfigureConnection();
            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        public void TestConnection()
        {
            if (OpenConnection())
            {
                connection.Close();
                System.Windows.MessageBox.Show("Успешно");
            }
        }

        MySqlConnection connection;
        void ConfigureConnection()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "192.168.200.13";
            sb.UserID = "student";
            sb.Password = "student";
            sb.Database = "imnatural";
            sb.CharacterSet = "utf8mb4";
            connection = new MySqlConnection(sb.ToString());
        }
    }
}
