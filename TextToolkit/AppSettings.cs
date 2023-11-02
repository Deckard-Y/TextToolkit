using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextToolkit
{
    public class AppSettings
    {
        public string ApplicationName { get; set; }
        public string Version { get; set; }
        public bool MaintenanceMode { get; set; }
        public DatabaseSettings Database { get; set; }
        public A4442Settings A4442 { get; set; }
    }

    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }
    }

    public class A4442Settings
    {
        public string VisaAddress { get; set; }
        public string InstrumentID { get; set; }
        public DefaultSetting DefaultSettings { get; set; }
    }

    public class DefaultSetting
    {
        public string Command { get; set; }
    }

}
