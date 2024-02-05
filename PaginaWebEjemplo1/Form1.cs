using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaginaWebEjemplo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BotonIr_Click(object sender, EventArgs e)
        {
            string url = comboBox1.Text.ToString();


          
            if (!(url.Contains("http")))
            {
                url = "https//" + url;
            }
           
            webBrowser1.Navigate(new Uri(url));

            //controlpuntos

            if (!(url.Contains(".")))
            {
                url = "https://www.google.com/search?q=" + url;

            }
            webBrowser1.Navigate(new Uri(url));




        }

        private void inicioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void haciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void haciaAdelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            webBrowser1.GoHome();
        }
    }
}
