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
        public DataSet dt;
        public string _imie, _nazwisko;
        public DateTime _czas_wej;
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
            dt = baza_danych.fire_polacz("SELECT id,nazwisko,imie,godz_wej,godz_wyj FROM pracownicy");
            dataGridView1.DataSource = dt.Tables[0];

            //Nazwa kolumny
            dataGridView1.Columns [0].HeaderText = "ID";
            dataGridView1.Columns [1].HeaderText = "Nazwisko";
            dataGridView1.Columns [2].HeaderText = "Imię";
            dataGridView1.Columns [3].HeaderText = "Godzina wejścia";
            dataGridView1.Columns [4].HeaderText = "Godzina wyjścia";

            //Szerokość kolumny
            dataGridView1.Columns [0].Width = 50;
            dataGridView1.Columns [1].Width = 250;
            dataGridView1.Columns [2].Width = 250;
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
            int rowindex = dt.Tables[0].Rows.Count;
            row = dt.Tables[0].NewRow();
            row[0] = rowindex-1;
            row[1] = _imie;
            row[2] = _nazwisko;
            row[3] = _czas_wej;
            dt.Tables[0].Rows.Add(row); 
            
         }
        
    }
}
