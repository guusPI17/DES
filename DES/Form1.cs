using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DES
{
    public partial class Form1 : Form
    {
        DES des = null;
        public Form1()
        {
            InitializeComponent();
        }

        //зашифровать
        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            des = new DES();
            List<string> result = new List<string>();
            result = des.encr(textBox_basisText.Text);

            textBox_encrText.Text = result[0];
            textBox_decKey.Text = result[1];
            textBox_encrKey.Text = result[2];
        }

        //расшифровать
        private void buttonDecipher_Click(object sender, EventArgs e)
        {
            string result = des.dec(textBox_encrText.Text, textBox_decKey.Text);

            textBox_decrText.Text = result;
        }
    }
}
