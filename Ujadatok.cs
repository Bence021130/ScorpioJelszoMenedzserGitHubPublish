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
    public partial class Ujadatok : Form
    {
        
        public Ujadatok()
        {
            InitializeComponent();
        }
        void torol()
        {
            felhaszBox.Text = "";
            emailBox.Text = "";
            jelsz1Box.Text = "";
            nevBox.Text = "";
            jelsz2Box.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (jelsz1Box.Text == jelsz2Box.Text)
            {
                if (jelszavak.sendNewdatas(nevBox.Text, felhaszBox.Text, emailBox.Text, jelsz1Box.Text) == true)
                {
                    MessageBox.Show("Sikeres hozzáadás!");
                    torol();
                }
                else
                {
                    MessageBox.Show("Sikertelen hozzáadás!");
                    torol();
                }
            }
            else
            {
                MessageBox.Show("A jelszavak nem eggyeznek!");
                jelsz1Box.Text = "";
                jelsz2Box.Text = "";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
