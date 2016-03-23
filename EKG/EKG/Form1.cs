using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EKG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetFontAndColors();
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
    }
}
