using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Medical_System.WebCrawler
{
    class WebMiner
    {

        //private string insertDrugQuery = @"Insert INTO Drugs(Name) Values("+WebDrug.name +")";
        private const string linkPattern = @"/drugportal/dpdirect.jsp\?name=\w+";
        private const string INVALID_CHARACTERS = @"[\\]";
        public WebMiner()
        {
        }

        public string writeDrugInsertScripts(List<Bottle> allTheMeds)
        {
            StringBuilder scriptBuilder = new StringBuilder("");
            foreach(Bottle b in allTheMeds)
            {
                foreach(WebDrug drug in b.data)
                {
                    if (drug.drug_name.Length <= 100)
                    {
                        scriptBuilder.Append("Insert INTO Medicine(Name) Values(\'" + drug.drug_name + "\')");
                        scriptBuilder.Append("\n");
                    }

                }
            }
            return scriptBuilder.ToString();
        }

        public List<Bottle> startWebMining()
        {
            List<Bottle> medCabinet = new List<Bottle>();

            string firstResponse = getWebString();
            string nextResponse = null;
            string nextURL = null;
            int totalPages = parseTotalPages(firstResponse);
            for (int i = 1; i <= totalPages; i++)
            {
                if (nextResponse == null)
                {
                    Console.WriteLine("Work has begun " + i);
                    medCabinet.Add(parseJSON(firstResponse));
                    nextURL = parseNextJSONPage(firstResponse);
                    nextResponse = getWebString(nextURL);
                }
                else
                {
                    Console.WriteLine("Working... " + i);
                    medCabinet.Add(parseJSON(nextResponse));
                    nextURL = parseNextJSONPage(nextResponse);
                    nextResponse = getWebString(nextURL);
                }
                if (i % 50 == 0)
                {
                    Console.WriteLine("Waiting...cuz u told me to.");
                    System.Threading.Thread.Sleep(4000);
                }
            }
            return medCabinet;
        }

        public int parseTotalPages(string webResponse)
        {
            string totalPagesPattern = @"total_pages\W+\d+";
            Regex regX = new Regex(totalPagesPattern, RegexOptions.IgnoreCase);
            MatchCollection match = regX.Matches(webResponse);
            string[] splitLine = Regex.Split(match[0].ToString(), "\":\"");
            return int.Parse(splitLine[1]);
        }

        public string parseNextJSONPage(string webResponse)
        {
            string metadataPattern = @"http:\W+dailymed\.nlm\.nih\.gov\W+dailymed\W+services\W+v2\W+drugnames\.json\?\w+=\d+&\w+=\d+";
            Regex regX = new Regex(metadataPattern, RegexOptions.IgnoreCase);
            MatchCollection matchedLine = regX.Matches(webResponse);
            //string[] endOfLine = Regex.Split(matchedLine[0].ToString(), "\":\"");
            //Console.WriteLine(endOfLine[0] + "Ending!");
            string validUrl = Regex.Replace(matchedLine[0].ToString(), INVALID_CHARACTERS, "", RegexOptions.IgnoreCase);
            return validUrl;


        }

        public Bottle parseJSON(string jsonResponse)
        {
            Bottle bottle = new JavaScriptSerializer().Deserialize<Bottle>(jsonResponse);
            return bottle;
        }

        public string getWebString()
        {

            var request = (HttpWebRequest)WebRequest.Create("http://dailymed.nlm.nih.gov/dailymed/services/v2/drugnames.json");
            var response = (HttpWebResponse)request.GetResponse();

            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString ;
        }

        public string getWebString(string webURI)
        {

            var request = (HttpWebRequest)WebRequest.Create(webURI);
            var response = (HttpWebResponse)request.GetResponse();

            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }

        public ArrayList mineDrugPortals(string firstWebResponse)
        {
            ArrayList drugList = new ArrayList();
            Regex tableRgx = new Regex(linkPattern, RegexOptions.IgnoreCase);
            MatchCollection collectedLinks = tableRgx.Matches(firstWebResponse);
            if (collectedLinks.Count > 0)
            {
                Console.WriteLine("You sorted them! :D");
                foreach (Match cm in collectedLinks)
                {
                    drugList.Add(cm);
                    //Console.WriteLine("{0} :D ", cm.Value);
                }
            }
            return drugList;
        }

        public string minePortalInformation(string drugAddress)
        {
            var portalRequest = (HttpWebRequest)WebRequest.Create(drugAddress);
            var response = (HttpWebResponse)portalRequest.GetResponse();

            Console.WriteLine(response);

            return null;
        }

    }
}
