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
    public partial class deleteItems : Form
    {
        public deleteItems()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string report = databaseConnection.deleteDatasByID(Int32.Parse(textBox2.Text));
            if (report == "ok")
            {
                MessageBox.Show("Sikeres törlés!");
                textBox2.Text = "";
            }
            else
            {
                MessageBox.Show(report);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
