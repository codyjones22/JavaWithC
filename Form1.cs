using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace JavaWithC
{
    [ComVisible(true)]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);

            // If you want to call C# code (method) in java script function then write this code.
            webBrowser1.ObjectForScripting = this;
            webBrowser1.ScriptErrorsSuppressed = false;

            // If you want to disable right click on the web browser control then write this code
            webBrowser1.IsWebBrowserContextMenuEnabled = false;
            webBrowser1.AllowWebBrowserDrop = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // In written code retrieve current directory of application
            string CurrentDirectory = Directory.GetCurrentDirectory();
            // Calling HTML page using navigate method. Mandatory for web Browser Document Completed Event
            webBrowser1.Navigate(Path.Combine(CurrentDirectory, "HTMLPageForJavaScript.html"));
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Form is load cursor focus on the Web browser control
            webBrowser1.Focus();

            // Call report method containing report content
            Report();
        }
        private void Report()
        {
            // Retrieve HTML page div from id of Div.
            HtmlElement div = webBrowser1.Document.GetElementById("reportContent");

            // Create simple html content
            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            sb.Append("<tr><td><B> Hi this is my report demo</B></td></tr>");
            sb.Append("</table>");

            // Assign content to HTML page div which will display on Browser control
            div.InnerHtml = sb.ToString();
        }

        public void PrintReport()
        {
            // Showing print dialog and calling print method of webbrowser control
            DialogResult dr = printDialog1.ShowDialog();

            if (dr.ToString() == "OK")
            {
                webBrowser1.Print();
            }
            else
            {
                return;
            }
        }
    }
}
