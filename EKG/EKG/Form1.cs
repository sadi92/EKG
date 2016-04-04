using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
namespace EKG
{
    public partial class Form1 : Form
    {
        //Zmienne

        public DataSet dt = new DataSet();
        public string _imie, _nazwisko,_czas_wej,_data_wej;
        //public DateTime _czas_wej;
        public Form1()
        {
            InitializeComponent();
            laduj_tabele();

            //vlc - plugin
            axVLCPlugin21.playlist.add("rtsp://admin:12345@192.168.1.65:554//Streaming/Channels/1");
            axVLCPlugin21.playlist.play();
            axVLCPlugin21.Toolbar = false;

            //vlc2 - plugin
            axVLCPlugin22.playlist.add("rtsp://admin:12345@192.168.1.65:554//Streaming/Channels/1");
            axVLCPlugin22.playlist.play();
            axVLCPlugin22.Toolbar = false;
        }


        private void start_Click(object sender, EventArgs e)
        {
            
        }

        private void stop_Click(object sender, EventArgs e)
        {
            axVLCPlugin21.playlist.stop();
        }

        private void pause_Click(object sender, EventArgs e)
        {
            axVLCPlugin21.playlist.togglePause();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void laduj_tabele()
        {
            //połączenie z bazą danych
            //DataSet dt = null;
            polacz baza_danych = new polacz();
            /*dt.Tables.Add("pracownicy");
            dt.Tables[0].Columns.Add("id", typeof(int));
            dt.Tables[0].Columns.Add("imie", typeof(string));
            dt.Tables[0].Columns.Add("nazwisko", typeof(string));
            dt.Tables[0].Columns.Add("data_wej", typeof(DateTime));
            dt.Tables[0].Columns.Add("godz_wej", typeof(TimeSpan));
            dt.Tables[0].Columns.Add("data_wyj", typeof(DateTime));
            dt.Tables[0].Columns.Add("godz_wyj", typeof(TimeSpan));*/
              dt.Tables[0].Columns[0].DataType = typeof(int);
              dt.Tables[0].Columns[1].DataType = typeof(string);
              dt.Tables[0].Columns[2].DataType = typeof(string);
              dt.Tables[0].Columns[3].DataType = typeof(string);
              dt.Tables[0].Columns[4].DataType = typeof(string);
              dt.Tables[0].Columns[5].DataType = typeof(string);
              dt.Tables[0].Columns[6].DataType = typeof(string);
            dt = baza_danych.fire_polacz("SELECT id,nazwisko,imie,data_wej,godz_wej,data_wyj,godz_wyj FROM pracownicy");
            dataGridView1.DataSource = dt.Tables[0];
            dt.Tables[0].TableName = "pracownicy";

            //Nazwa kolumny
            dataGridView1.Columns [0].HeaderText = "ID";
            dataGridView1.Columns [1].HeaderText = "Nazwisko";
            dataGridView1.Columns [2].HeaderText = "Imię";
            dataGridView1.Columns [3].HeaderText = "Data wejścia";
            dataGridView1.Columns [4].HeaderText = "Godzina wejścia";
            dataGridView1.Columns [5].HeaderText = "Data wyjścia";
            dataGridView1.Columns [6].HeaderText = "Godzina wyjścia";

            //Szerokość kolumny
            dataGridView1.Columns [0].Width = 50;
            dataGridView1.Columns [1].Width = 250;
            dataGridView1.Columns [2].Width = 250;
            dataGridView1.Columns[3].Width = 130;
            dataGridView1.Columns[4].Width = 130;
            dataGridView1.Columns[5].Width = 130;
            dataGridView1.Columns[6].Width = 130;

            //datatype prawdopodobnie do wyjebania!
            // dt.Tables[0].Columns[0].DataType = typeof(int);


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void axVLCPlugin21_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form nowyRekord = new dodajRekord(this);
            nowyRekord.FormClosed += new FormClosedEventHandler(nowyRekord_Closed);
            nowyRekord.Show();
        }

         void nowyRekord_Closed(object sender, FormClosedEventArgs e)
         {
            //dodanie wiersza do datagridview
            //int rowindex = dt.Tables[0].Rows.Count;
            DataRow row;
            MessageBox.Show(_czas_wej.ToString());
            int rowindex = dataGridView1.Rows.Count;
            row = dt.Tables[0].NewRow();
            row[0] = rowindex;
            row[1] = _imie;
            row[2] = _nazwisko;
            row[3] = _data_wej;
            row[4] = _czas_wej;
            dt.Tables[0].Rows.Add(row);
            update();            
         }
        void update()
        {
            polacz baza_danych = new polacz();
            baza_danych.insert(dt);
        }
        
    }
}
