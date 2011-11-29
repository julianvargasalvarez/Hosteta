using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Web.Hosting;
using AspHostTest;

namespace Hosteta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
            AspHostTest.Servidor.Start();
            webBrowser1.Navigate("http://localhost:" + "8081/Default.aspx");
            
        }
        
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AspHostTest.Servidor.Stop();
        }
    }
}
