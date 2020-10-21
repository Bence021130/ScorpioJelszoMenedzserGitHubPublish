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
    public partial class elfelejtettJelszo : Form
    {
        string userName;
        public elfelejtettJelszo()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey rkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("ScorpioPasswordManagerCredentials");
            if (rkey.GetValue(textBox2.Text + "_jelszo") != null)
            {
                if (rkey.GetValue(textBox2.Text + "_email").ToString() == textBox1.Text)
                {
                    email.passwordRecovery(textBox2.Text, textBox1.Text);
                    userName = textBox2.Text;
                }
                else
                {
                    MessageBox.Show("Az email cím helytelen!");
                    textBox1.Text = "";
                }

            }
            else
            {
                MessageBox.Show("Nincs ilyen nevű felhasználó!");
                textBox2.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == textBox5.Text)
            {
                    RegClass.updateCredentials(userName, textBox4.Text);
                MessageBox.Show("A jelszó frissítése sikerült!");
                    Close();
            }
            else MessageBox.Show("A jelszavak nem eggyeznek!");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == email.GeneratedCode)
            {
                button1.Enabled = false;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
            }
        }
    }
}
