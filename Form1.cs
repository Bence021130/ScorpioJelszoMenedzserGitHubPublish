using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ScorpioJelszoMenedzser
{
    public partial class Form1 : Form
    {
        public static string localFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegistryKey rkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("ScorpioPasswordManagerCredentials");
            if (rkey.GetValue(textBox1.Text + "_jelszo") != null)
            {
              string passWHASH = rkey.GetValue(textBox1.Text + "_jelszo").ToString();
                if (RegClass.validateHashCode(textBox2.Text, passWHASH))
                {
                    databaseConnection.dataBaseName = textBox1.Text + "_jelszavak";
                    //MessageBox.Show("Helyes jelszó!");
                    Hide();
                    jelszavak jlsz = new jelszavak();
                    jlsz.Show();
                }
                else MessageBox.Show("Nem helyes jelszó!");
            }
            else
            {
                MessageBox.Show("Nincs ilyen nevű felhasználó!");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Info nfo = new Info();
            nfo.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            elfelejtettJelszo recPass = new elfelejtettJelszo();
            recPass.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            regisztracio regForm = new regisztracio();
            regForm.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            visszajelzes vszj = new visszajelzes();
            vszj.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
