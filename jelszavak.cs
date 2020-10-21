using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScorpioJelszoMenedzser
{
    public partial class jelszavak : Form
    {
        public jelszavak()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText("1");
            Application.ExitThread();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText("1");
            Form1 login = new Form1();
            Close();
            login.Show();
        }
       
        public static bool sendNewdatas(string nev, string felhasz, string email, string jelszo)
        {
            string vissza =
                databaseConnection.addNewItemToDatabase(nev, felhasz, email, jelszo);
            if (vissza != "helyes")
            {
                return false;
            }
            else return true;
        }
        private void jelszavak_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = null;
            dataGridView1.DataSource = databaseConnection.updateList();
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            Ujadatok uja = new Ujadatok();
            uja.ShowDialog();
            //dataGridView1.DataSource = null;
            dataGridView1.DataSource = databaseConnection.updateList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            deleteItems ditems = new deleteItems();
            ditems.ShowDialog();
            dataGridView1.DataSource = databaseConnection.updateList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(dataGridView1.CurrentCell.Value.ToString());
        }
    }
}
