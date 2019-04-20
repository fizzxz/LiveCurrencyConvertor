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

    public class CurrencyName 
    {
        public CurrencyName(string json,string currAlph) {

            JObject jObject = JObject.Parse(currAlph);
            JToken jUser = jObject["user"];
            Code = (string)jUser["code"];
            AlphaCode = (string)jUser["alphaCode"];
            NumericCode = (string)jUser["numericCode"];
            Name = (string)jUser["Name"];
            Rate = (int)jUser["rate"];
            Date = (string)jUser["Date"];
            InverseRate = (int)jUser["inverseRate"];

            //players = jUser["players"].ToArray();

        }

        public string Code { get; set; }
        public string AlphaCode { get; set; }
        public string NumericCode { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
        public string Date { get; set; }
        public int InverseRate { get; set; }
    }

    public static class JsonExtensions
    {
        public static List<JToken> FindTokens(this JToken containerToken, string name)
        {
            List<JToken> matches = new List<JToken>();
            FindTokens(containerToken, name, matches);
            return matches;
        }

        private static void FindTokens(JToken containerToken, string name, List<JToken> matches)
        {
            if (containerToken.Type == JTokenType.Object)
            {
                foreach (JProperty child in containerToken.Children<JProperty>())
                {
                    if (child.Name == name)
                    {
                        matches.Add(child.Value);
                    }
                    FindTokens(child.Value, name, matches);
                }
            }
            else if (containerToken.Type == JTokenType.Array)
            {
                foreach (JToken child in containerToken.Children())
                {
                    FindTokens(child, name, matches);
                }
            }
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());







            //ImportCurrencyJSON();

            List<string> CurrencyCodes = ImportCurrencyCodes();
            List<string> CurrencyNames = ImportCurrencyNames();



            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (var line in CurrencyCodes)
            {
                foreach (var line2 in CurrencyNames)
                    if (dict.ContainsKey(line) || dict.ContainsValue(line2))
                    {
                        //
                    }
                    else
                    {
                        dict.Add(line, line2);
                    }
            }
            foreach (var item in dict)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }
            ImportCurrencyJSON("USD");


        }

        //need to output json that gives all the currency info output
        private static void ImportCurrencyJSON(string Currency)
        {
           
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString("http://www.floatrates.com/daily/" + Currency + ".json");

                //List<CurrencyName> Curr = new CurrencyName(json,);
                //CurrencyValuePairs currVP = new CurrencyValuePairs();

                JObject jo = JObject.Parse(json);

                foreach (JToken token in jo.FindTokens("code"))
                {
                    Console.WriteLine(token.Path + ": " + token.ToString());
                }

                //dynamic  stuff = JsonConvert.DeserializeObject<CurrencyName>(json);
                //List<string> CurrencyCodes = ImportCurrencyCodes();

                //foreach (var item in CurrencyCodes)
                //{
                //    stuff = item;
                    
                //}
                
                
                //Curr.Add(currName);
                //var x = currName.AlphaName;
                //Console.WriteLine(stuff.AlphaCode);
            }


        }

        static List<string> ImportCurrencyNames()
        {
            string[] CurrencyNamesImport = File.ReadAllLines("CurrencyNames.txt");

            List<string> CurrencyNames = new List<string>();

            foreach (var line in CurrencyNamesImport)
            {
                CurrencyNames.Add(Convert.ToString(line));
            }

            //foreach (string y in CurrencyNames)
            //{
            //    Console.WriteLine("\t" + y);
            //}
            return CurrencyNames;
        }

        static List<string> ImportCurrencyCodes()
        {
            string[] CurrencyCodesImport = File.ReadAllLines("CurrencyCodes.txt");
            List<string> CurrencyCodes = new List<string>();

            foreach (var line in CurrencyCodesImport)
            {
                CurrencyCodes.Add(Convert.ToString(line));
            }
            //foreach (var line in CurrencyCodesImport)
            //{
            //    Console.WriteLine("\t" + line);

            //}
            return CurrencyCodes;
        }
    }
}
