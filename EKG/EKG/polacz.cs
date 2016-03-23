using System.Windows.Forms;
using System;
using System.Data;
using MySql.Data.MySqlClient;
using FirebirdSql.Data.FirebirdClient;

namespace EKG
{
    //Klasa do nawiązania połączenia z bazą danych. 
    class polacz
    {
        DataSet dataSet = new DataSet();

        public polacz()
        {
            //Initialize();
        }
        public DataSet mysql_polacz(string baza, string adres, string user, string password, string myQuery)
        {
            DialogResult dr = DialogResult.Retry;
            while (dr == DialogResult.Retry)
            {

                try
                {
                    string mysql_string = "Server=" + adres + ";Database=" + baza + ";Uid=" + user + ";Pwd=" + password;

                    MySqlConnection mysql_polaczenie = new MySqlConnection(mysql_string);

                    MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(myQuery, mysql_string);

                    mySqlAdapter.Fill(dataSet, "pracownicy");
                    dr = DialogResult.OK;
                    mysql_polaczenie.Close();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    dr = MessageBox.Show("Nie można nawiązać połączenia z bazą danych. Sprawdż połączenie. \nKliknij Ponów Próbę, aby spróbować ponownie, albo Anuluj, aby zamknąć aplikację.", "Błąd!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (dr == DialogResult.Cancel)
                    {
                        //po wciśnięciu "anuluj" zamknięcie aplikacji
                        Form1.ActiveForm.Close();
                    }

                }

            }
            return dataSet;
        }

        public FbDataAdapter fire_polacz()
        {
            string cselx = "User=SYSDBA;" +
                           "Password=masterkey;" +
                           "Database=baza;" +
                           "DataSource=localhost;" +
                           "Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=15;Pooling=true;MinPoolSize=0;MaxPoolSize=50;Packet Size=8192;ServerType=0";

            FbConnection fb_conn = new FbConnection(cselx);

            DataTable dt = null;
            fb_conn.Open();

            FbCommand fb_comm = new FbCommand();
            FbTransaction fb_trans = fb_conn.BeginTransaction();
            fb_comm.Connection = fb_conn;
            fb_comm.Transaction = fb_trans;

            fb_comm.CommandText = "SELECT * FROM table_name";

            FbDataAdapter adapter = new FbDataAdapter(fb_comm);
            dt = new DataTable();
            adapter.Fill(dt);

            fb_conn.Close();

            return adapter;
        }
    }


}
