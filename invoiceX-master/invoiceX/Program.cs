using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace invoiceX
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static string _fileName;

        public static string FileName1 { get => Program._fileName; set => Program._fileName = value; }

        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                _fileName = args[0];
            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ReadXML());
        }
    }
}
