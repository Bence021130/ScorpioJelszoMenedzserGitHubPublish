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
    public partial class regisztracio : Form
    {
        public static string passwordHash;
        public static string databaseMainName;
        public regisztracio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == textBox4.Text)
            {
                string report = databaseManager.createDatabase(textBox1.Text + "_jelszavakDatas", textBox1.Text + "_jelszavak");
                if (report == "ok")
                {
                    MessageBox.Show("Létrehozva!");
                    RegClass.saveCredentials(textBox1.Text, textBox2.Text, RegClass.createHash(textBox3.Text));
                    MessageBox.Show("A regisztráció sikeres!");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                else MessageBox.Show("A regisztráció nem sikerült!\n" + report); 
            }
            else MessageBox.Show("A jelszó nem eggyezik");

        }
    }
}
