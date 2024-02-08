using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

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
            }




            //Poner https://

            

       

          




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
            comboBox1.SelectedIndex = 0;
            
            
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
