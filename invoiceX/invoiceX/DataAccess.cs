using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace invoiceX
{
    class DataAccess
    {
        private SQLiteConnection connection;
        public DataAccess()
        {
            this.connection = new SQLiteConnection(@"Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "invoiceDB.db; Version = 3; New = True; Compress = True; ");
            try
            {
                MessageBox.Show(AppDomain.CurrentDomain.BaseDirectory);
                this.connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error connect db : " + ex);
            }
        }
        public void Close()
        {
            this.connection.Close();
        }
        public string QueryNamespace(String Namespace)
        {
            string myreader = "";
            int temp;
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = this.connection.CreateCommand();
            sqlite_cmd.CommandText = string.Format("SELECT ID FROM InvoiceType WHERE Namespace LIKE '%" + Namespace + "%'");
            try
            {
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {

                    myreader = Convert.ToString(sqlite_datareader["ID"]);
                }
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return myreader;
        }
        public string ReadData(string table, string column, int typeInvoice)
        {
            string myreader = "";
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = this.connection.CreateCommand();
            sqlite_cmd.CommandText = string.Format("SELECT " + column + " FROM " + table + " WHERE InvoiceType = " + typeInvoice);
            try
            {
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    myreader = sqlite_datareader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return myreader;
        }
        public void InsertData(string tableName, string value)
        {
            String queryInsert = @"INSERT INTO " + tableName + " VALUES " + value;
            try
            {
                using var cmd = new SQLiteCommand(this.connection);
                cmd.CommandText = queryInsert;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("message error : " + ex.Message);
            }
        }
        public void UpdateData(string table, string value, string condition)
        {

            String queryUpdate = @"UPDATE " + table + " SET " + value + " WHERE InvoiceType = " + condition;
            try
            {
                using var cmd = new SQLiteCommand(this.connection);
                cmd.CommandText = queryUpdate;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("message error : " + ex.Message);
            }
        }
    }
}
