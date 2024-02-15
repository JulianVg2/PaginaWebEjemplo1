using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;


namespace PaginaWebEjemplo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(this.Form_Resize);
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            webView.Size = this.ClientSize - new System.Drawing.Size(webView.Location);
            BotonIr.Left = this.ClientSize.Width - BotonIr.Width;
            comboBox1.Width = BotonIr.Left - comboBox1.Left;
        }

        private void BotonIr_Click(object sender, EventArgs e)
        {
           string url = comboBox1.Text.ToString();

            if (webView != null && webView.CoreWebView2 != null)
            {
                if (!(url.Contains(".")))
                {
                    url = "https://www.google.com/search?q=" + url;

                }
                else if (!url.StartsWith("https://"))
                {
                    url = "https://" + url;
                }

                webView.CoreWebView2.Navigate(url);
                //Guardar Texto://
                Guardar("archivos.txt", comboBox1.Text);
                comboBox1.Items.Add(url);
                MessageBox.Show("Dirección guardada");
            }







        }

        private void Guardar (string NombreArchivo, string texto)
        {
            FileStream flujo = new FileStream(NombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(flujo);
            writer.WriteLine(texto);
            writer.Close();

        }

        private void inicioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webView.CoreWebView2.Navigate("https://www.bing.com");
        }

        private void haciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView.CoreWebView2.GoBack();
        }

        private void haciaAdelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView.CoreWebView2.GoForward();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;

            string fileName = @"C:\Users\Usuario\source\repos\PaginaWebEjemplo1\PaginaWebEjemplo1\bin\Debug\archivos.txt";

            FileStream flujo = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader lector = new StreamReader(flujo);

            while (lector.Peek() > -1)

            {
                string textoleido = lector.ReadLine();
                comboBox1.Items.Add(textoleido);
            }
            lector.Close();


        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
