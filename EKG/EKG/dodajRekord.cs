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
        public dodajRekord()
        {
            InitializeComponent();
            numericUpDown1.Value = DateTime.Now.Hour;
            numericUpDown2.Value = DateTime.Now.Minute;
            this.ActiveControl = textBox1;
            button4.Enabled = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void wypelnij()
        {

            //MessageBox.Show("Dup Dup Dup DUPA!");
            polacz baza_danych = new polacz();
            DataTable dt = null;
            dt = baza_danych.fire_polacz("SELECT nazwisko, imie FROM baza_pracownicy WHERE id=" + textBox1.Text);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Nie znaleziono pracownika o takim numerze!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text = "";
                textBox1.Enabled = true;
                textBox1.Focus();
            }
            else
            {
                textBox2.Text = dt.Rows[0]["imie"].ToString();
                textBox3.Text = dt.Rows[0]["nazwisko"].ToString();
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

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            DateTime czas_wej = new DateTime();
            czas_wej.AddHours(Convert.ToDouble(numericUpDown1.Value));
            czas_wej.AddMinutes(Convert.ToDouble(numericUpDown2.Value));
            czas_wej.AddYears(dateTimePicker1.Value.Hour);
            czas_wej.AddMonths(dateTimePicker1.Value.Month);
            czas_wej.AddDays(dateTimePicker1.Value.Day);

            int RowIndex = form1.dataGridView1.Rows.Add();
            form1.dt.Rows[RowIndex].Cells[0].Value = 1;
            form1.dataGridView1.Rows[RowIndex].Cells[1].Value = textBox2.Text;
            form1.dataGridView1.Rows[RowIndex].Cells[2].Value = textBox3.Text;
            form1.dataGridView1.Rows[RowIndex].Cells[3].Value = czas_wej;

        }
    }
}
