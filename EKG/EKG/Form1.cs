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
using Ozeki.Media;
using Ozeki.Camera;
using Vlc.DotNet.Forms;
using Vlc.DotNet.Core;
namespace EKG
{
    public partial class Form1 : Form
    {
        //Zmienne
        VlcControl player = null;
        public Form1()
        {
            InitializeComponent();
            SetFontAndColors();
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
            /*polacz Polacz = new polacz();
            DataSet get = Polacz.mysql_polacz("toya","192.168.100.59","root","ksy.123!","select * from pracownicy");
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = get;
            dataGridView1.DataMember = "pracownicy";*/
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void SetFontAndColors() //zmiana wyglądu datagridview
        {
            //this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 15);
            //this.dataGridView1.DefaultCellStyle.ForeColor = Color.Blue;
            //this.dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
           // this.dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            //this.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Black; - kolor zaznaczenia
        }

        private void laduj_tabele()
        {
            //połączenie z bazą danych
            DataTable dt = null;
            polacz baza_danych = new polacz();
            dt = baza_danych.fire_polacz("SELECT id,nazwisko,imie,godz_wej,godz_wyj FROM pracownicy");
            dataGridView1.DataSource = dt;

            //modyfikacja wyglądu DataGridview
            //this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 15);
            //this.dataGridView1.DefaultCellStyle.ForeColor = Color.Blue;
            //this.dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
            // this.dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            //this.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Black; - kolor zaznaczenia

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
            Form nowyRekord = new dodajRekord();
            nowyRekord.Show();
        }


    }
}
