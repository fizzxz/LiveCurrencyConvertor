using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace CurrencyConvertor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
           
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {


            List<string> CurrencyCodes = ImportCurrencyCodes();
            List<string> CurrencyNames = ImportCurrencyNames();

            Dictionary<string, string> dict = initialiseCurrencyDictionary(CurrencyCodes, CurrencyNames);
            System.Object[] ItemObject = new System.Object[dict.Count];
            foreach (var item in dict)
            {
                CurrencyValueBox1.Items.Add(item.Value);
                CurrencyValueBox2.Items.Add(item.Value);


                //Console.WriteLine(item.Key);
                //Console.WriteLine(item.Value);
            }
            CurrencyValueBox1.SelectedIndex = 0;
            CurrencyValueBox2.SelectedIndex = 0;
            
        }

        private Dictionary<string, string> initialiseCurrencyDictionary(List<string> CurrencyCodes, List<string> CurrencyNames)
        {
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

            return dict;
        }

        static List<string> ImportCurrencyCodes()
        {
            string[] CurrencyCodesImport = File.ReadAllLines("CurrencyCodes.txt");
            List<string> CurrencyCodes = new List<string>();

            foreach (var line in CurrencyCodesImport)
            {
                CurrencyCodes.Add(Convert.ToString(line));
            }

            return CurrencyCodes;
        } 


        static List<string> ImportCurrencyNames()
        {
            string[] CurrencyNamesImport = File.ReadAllLines("CurrencyNames.txt");

            List<string> CurrencyNames = new List<string>();

            foreach (var line in CurrencyNamesImport)
            {
                CurrencyNames.Add(Convert.ToString(line));
            }

            return CurrencyNames;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        
        private void CurrencyValue1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void CurrencyValue2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CurrencyValue1.Text) )
            {
                MessageBox.Show("Need to enter numerical values to convert!");
            }
            else if (CurrencyValueBox1.SelectedIndex > -1 && CurrencyValueBox2.SelectedIndex > -1)
            {
                List<string> CurrencyCodes = ImportCurrencyCodes();
                List<string> CurrencyNames = ImportCurrencyNames();

                Dictionary<string, string> dict = initialiseCurrencyDictionary(CurrencyNames,CurrencyCodes);

                if (dict.TryGetValue(CurrencyValueBox1.Text, out string result))
                {
                    List<CurrencyName> x = ImportCurrencyJSON(result);

                    if (dict.TryGetValue(CurrencyValueBox2.Text, out string result2))
                    {
                        foreach (CurrencyName f in x)
                        {
                            if (f.Code == result2)
                            {
                                double d = 0.0;
                                d = double.Parse(CurrencyValue1.Text) * f.Rate;
                                CurrencyValue2.Text = d.ToString();
                                break;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Could not find the specified Currency, Please choose off the list.");
                }

            }
            else
            {
                MessageBox.Show("Need to choose currency values to convert!");
            }
               
        }
        private List<CurrencyName> ImportCurrencyJSON(string Currency)
        {
            List<CurrencyName> CurrencysData= new List<CurrencyName>();
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString("http://www.floatrates.com/daily/" + Currency + ".json");
                JObject jo = JObject.Parse(json);


                List<string> code = new List<string>();
                List<string> alphaCode =new List<string>();
                List<string> numericCode = new List<string>();
                List<string> name = new List<string>();
                List<double> rate = new List<double>(); 
                List<string> date = new List<string>();
                List<double> inverseRate = new List<double>();

                List<CurrencyName> data = new List<CurrencyName>();
                int count = jo.Count;
               
               
                foreach (JToken token in jo.FindTokens("code"))
                {
                    code.Add(token.ToString());
                }
                foreach (JToken token in jo.FindTokens("alphaCode"))
                {
                    //Console.WriteLine(token.Path + ": " + token.ToString());
                    alphaCode.Add(token.ToString());
                }
                foreach (JToken token in jo.FindTokens("numericCode"))
                {
                    numericCode.Add(token.ToString());
                }
                foreach (JToken token in jo.FindTokens("name"))
                {
                    name.Add(token.ToString());
                }
                foreach (JToken token in jo.FindTokens("rate"))
                {
                    rate.Add(Convert.ToDouble(token));
                }
                foreach (JToken token in jo.FindTokens("date"))
                {
                    date.Add(token.ToString());
                }
                foreach (JToken token in jo.FindTokens("inverseRate"))
                {
                    inverseRate.Add(Convert.ToDouble(token));
                }

                for (int j = 0; j < count; j++)
                {

                    CurrencyName CurrencyData = new CurrencyName(code[j], alphaCode[j], numericCode[j], name[j], rate[j], date[j], inverseRate[j]);
                    //Console.WriteLine(CurrencyData.Code);
                        CurrencysData.Add(CurrencyData);
                }

                
            }
            return CurrencysData;
        }
    }

    public struct CurrencyName
    {
        public string Code;
        public string AlphaCode;
        public string NumericCode;
        public string Name;
        public double Rate;
        public string Date;
        public double InverseRate;

        public CurrencyName(string code, string alphaCode, string numericCode, string name, double rate, string date, double inverseRate)
        {
            Code = code;
            AlphaCode = alphaCode;
            NumericCode = numericCode;
            Name = name;
            Rate = rate;
            Date = date;
            InverseRate = inverseRate;
        }

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
}
