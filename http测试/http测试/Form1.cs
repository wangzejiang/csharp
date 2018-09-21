using Fiddler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace http测试
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("test", typeof(string)));
            dt.Columns.Add(new DataColumn("test2", typeof(string)));
            dt.Columns.Add(new DataColumn("test3", typeof(string)));
            dataGridView1.DataSource = dt;

            timer1.Start();
        }

        private Stack<Fiddler.Session> oAllSessions = new Stack<Fiddler.Session>();
       // List<Fiddler.Session> oAllSessions = new List<Fiddler.Session>();
        private string sSecureEndpointHostname = "127.0.0.1";
        private int iSecureEndpointPort = 8888;
        private Proxy oSecureEndpoint;

        private void exit()
        {
            if (oSecureEndpoint != null)
            {
                oSecureEndpoint.Dispose();
            }
            Fiddler.FiddlerApplication.Shutdown();
        }

        private void button1_Click(object sender1, EventArgs e1)
        {
            exit();
            Fiddler.FiddlerApplication.SetAppDisplayName("FiddlerCoreDemoApp");
            Fiddler.CertMaker.createRootCert();
            X509Certificate2 oRootCert = Fiddler.CertMaker.GetRootCertificate();
            X509Store certStore = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
            certStore.Open(OpenFlags.ReadWrite);
            try
            {
                certStore.Add(oRootCert);
            }
            finally
            {
                certStore.Close();
            }
            Fiddler.FiddlerApplication.oDefaultClientCertificate = oRootCert;
            Fiddler.CONFIG.IgnoreServerCertErrors = false;
            //FiddlerApplication.Prefs.SetBoolPref("fiddler.network.streaming.abortifclientaborts", true);
            Fiddler.FiddlerApplication.OnNotification += delegate (object sender, NotificationEventArgs oNEA) { Console.WriteLine("** NotifyUser: " + oNEA.NotifyString); };
            Fiddler.FiddlerApplication.Log.OnLogString += delegate (object sender, LogEventArgs oLEA) { Console.WriteLine("** LogString: " + oLEA.LogString); };
            Fiddler.FiddlerApplication.BeforeRequest += new Fiddler.SessionStateHandler(delegate (Fiddler.Session oS)
            {
                oS.bBufferResponse = true;
            });
            Fiddler.FiddlerApplication.BeforeResponse += delegate (Fiddler.Session oS)
            {
                if (oS.isHTTPS)
                {
                    Monitor.Enter(oAllSessions);
                    oAllSessions.Push(oS);
                    Monitor.Exit(oAllSessions);
                }
            };
            int iPort = 8877;
            Fiddler.FiddlerApplication.Startup(iPort, true, true, true);
            oSecureEndpoint = FiddlerApplication.CreateProxyEndpoint(iSecureEndpointPort, true, sSecureEndpointHostname);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            if(oAllSessions.Count <= 0)
            {
                return;
            }
            var oS = oAllSessions.Pop();
            if(oS == null)
            {
                return;
            }
            DataRow dr = dt.NewRow();
            dr["test"] = oS.fullUrl;
            dr["test2"] = oS.GetResponseBodyAsString();
            byte[] dd = oS.ResponseBody;
            dr["test3"] = System.Text.Encoding.Default.GetString(dd);
            //if(!string.IsNullOrEmpty(textBox3.Text) && oS.fullUrl.IndexOf(textBox3.Text) > -1)
            //{
            //    textBox2.Text = oS.GetResponseBodyAsString();
            //    Console.WriteLine(oS.GetResponseBodyAsString());
            // }
            dt.Rows.Add(dr);
        }
    }
}
