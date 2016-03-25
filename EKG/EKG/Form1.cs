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
            fire_polacz();

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

        private void fire_polacz()
        {

            //obsługa połączenia z bazą danych
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

            fb_comm.CommandText = "SELECT id,nazwisko,imie,godz_wej,godz_wyj FROM pracownicy";

            FbDataAdapter adapter = new FbDataAdapter(fb_comm);
            dt = new DataTable();
            adapter.Fill(dt);

            fb_conn.Close();
            dataGridView1.DataSource = dt;

            //modyfikacja wyglądu DataGridview
            //this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 15);
            //this.dataGridView1.DefaultCellStyle.ForeColor = Color.Blue;
            //this.dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
            // this.dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            //this.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Black; - kolor zaznaczenia

            //Nazwa kolumny
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Nazwisko";
            dataGridView1.Columns[2].HeaderText = "Imię";
            dataGridView1.Columns[3].HeaderText = "Godzina wejścia";
            dataGridView1.Columns[4].HeaderText = "Godzina wyjścia";

            //Szerokość kolumny
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 250;


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void axVLCPlugin21_Enter(object sender, EventArgs e)
        {

        }
    }
}
