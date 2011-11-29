using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Web.Hosting;
using System.Web;


namespace AspHostTest
{
    public class MyExeHost : MarshalByRefObject
    {
        
        public void ProcessRequest(string p, string q, TextWriter tw)
        {
            SimpleWorkerRequest swr = new SimpleWorkerRequest(p, q, tw);
            HttpRuntime.ProcessRequest(swr);
            tw.Close();
        }
    }

    public class Servidor
    {
        private static System.Threading.Thread _hiloServicio;

        public static void Start()
        {
            _hiloServicio = new System.Threading.Thread(Servicio);
            _hiloServicio.Start();

        }

        public static void Stop() {
            _hiloServicio.Abort();
            _hiloServicio = null;
            GC.Collect();
        }

        private static void Servicio()
        {

            MyExeHost myHost = (MyExeHost)ApplicationHost.CreateApplicationHost(typeof(MyExeHost), "/", Environment.CurrentDirectory + "\\elWeb");

            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8081/");
            listener.Prefixes.Add("http://127.0.0.1:8081/");
            listener.Start();

            while (true)
            {
                try
                {
                    HttpListenerContext ctx = listener.GetContext();
                    string page = ctx.Request.Url.LocalPath.Replace("/", "");
                    string query = ctx.Request.Url.Query.Replace("?", "");

                    StreamWriter sw = new
                      StreamWriter(ctx.Response.OutputStream);
                    myHost.ProcessRequest(page, query, sw);
                    sw.Flush();
                    ctx.Response.Close();
                }
                catch (Exception ex) { }
            }

        }

    }


}