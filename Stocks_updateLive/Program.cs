using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CurrencyConvertor
{
    //public class CurrencyValuePairs
    //{
    //}

    

    static class Program
    {
  
        // The main entry point for the application.
  
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }


      
    }
}
