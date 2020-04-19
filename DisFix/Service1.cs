using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;

namespace DisFix
{
    [RunInstaller(true)]
    public partial class Service1 : ServiceBase
    {
        //int SheduleTime = Convert.ToInt32(ConfigurationSettings.AppSettings["ThreadTime"]);
        public Thread Worker = null;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                ThreadStart start = new ThreadStart(Working);
                Worker = new Thread(start);
                Worker.Start();
            }

            catch (Exception)
            {
                throw;
            }
            
        }

        public void Working ()
        {
            while (true)
            {
                try
                {
                    Process[] process = Process.GetProcessesByName("Discord");

                    if (process.Length > 0)
                    {
                        foreach (Process item in process)
                        {
                            item.PriorityClass = ProcessPriorityClass.High;
                        }
                    }
                }

                catch (Exception)
                {
                    throw;
                }
                Thread.Sleep(1000);
            }
            
        }

        protected override void OnStop()
        {
        }
    }
}
