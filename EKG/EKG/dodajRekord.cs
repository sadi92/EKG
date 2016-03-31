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
    public partial class dodajRekord : Form
    {
        polacz baza_danych = new polacz();
        private Form1 f1;
        public dodajRekord(Form1 f)
        {
            f1 = f;
            InitializeComponent();
            numericUpDown1.Value = DateTime.Now.Hour;
            numericUpDown2.Value = DateTime.Now.Minute;
            this.ActiveControl = textBox1;
            button4.Enabled = false;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void wypelnij()
        {

            //MessageBox.Show("Dup Dup Dup DUPA!");

            DataSet dt = null;
            dt = baza_danych.fire_polacz("SELECT nazwisko, imie FROM baza_pracownicy WHERE id=" + textBox1.Text);
            if (dt.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Nie znaleziono pracownika o takim numerze!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text = "";
                textBox1.Enabled = true;
                textBox1.Focus();
            }
            else
            {
                textBox2.Text = dt.Tables[0].Rows[0]["imie"].ToString();
                textBox3.Text = dt.Tables[0].Rows[0]["nazwisko"].ToString();
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox1.Enabled = false;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 || char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                base.OnKeyPress(e);
                if(e.KeyChar ==13)
                {
                    e.Handled = true;
                    wypelnij();           
                }
                
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            wypelnij();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox3.Text == "")
            {
                button4.Enabled = false;
            }
            else
            {
                button4.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e) //dodaj wejście
        {
            DateTime czas_wej = new DateTime();
            czas_wej.AddHours(Convert.ToDouble(numericUpDown1.Value));
            czas_wej.AddMinutes(Convert.ToDouble(numericUpDown2.Value));
            czas_wej.AddYears(dateTimePicker1.Value.Hour);
            czas_wej.AddMonths(dateTimePicker1.Value.Month);
            czas_wej.AddDays(dateTimePicker1.Value.Day);

            f1._imie = textBox2.Text;
            f1._nazwisko = textBox3.Text;
            f1._czas_wej = czas_wej;
            Close();
        }
    }
}
