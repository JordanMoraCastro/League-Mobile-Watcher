using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace League_Watcher.Services
{
    class SummonerService
    {
        public string URL { get; set; }

        public string Api_Key { get; set; }


        public SummonerService()
        {
            this.URL = "https://la1.api.riotgames.com/lol/summoner/v4/summoners/by-name/";
            this.Api_Key = "?api_key=RGAPI-113f4cbf-fcfa-4a48-abb5-d43a58b7cca6";
        }

        //Get Summoner data from Riot API
        public async Task<string> GetSummonerDataAsync(string name)
        {

            WebRequest oRequest = WebRequest.Create(URL + name + Api_Key);
            WebResponse oResponse = oRequest.GetResponse();


            StreamReader sr = new StreamReader(oResponse.GetResponseStream());

            return await sr.ReadToEndAsync();



        }


    }
}
