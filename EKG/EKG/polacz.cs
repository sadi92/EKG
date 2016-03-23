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


    }


}
