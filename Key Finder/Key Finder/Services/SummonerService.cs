using Key_Finder.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace League_Watcher.Services
{
    class SummonerService
    {
        public string URL { get; set; }
        public string URL_Division { get; set; }

        public string Api_Key { get; set; }


        public SummonerService()
        {
            this.URL = "https://la1.api.riotgames.com/lol/summoner/v4/summoners/by-name/";

            this.URL_Division = "https://la1.api.riotgames.com/lol/league/v4/entries/by-summoner/";
            this.Api_Key = "?api_key=RGAPI-36431b78-0ab8-4a42-b352-06deb35d1a51";
        }

        //Get Summoner data from Riot API
        public async Task<string> GetSummonerData(string name)
        {


            var request = new HttpRequestMessage();

            request.RequestUri = new Uri(URL + name + Api_Key);
            request.Method = HttpMethod.Get;

            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient();

            HttpResponseMessage response = await client.SendAsync(request);

            if(response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
            else
            {
                return "Error";
            }

        }

        public async Task<string> GetSummonerEloAsync(string encryptedSummonerId)
        {

            WebRequest oRequest = WebRequest.Create(URL_Division + encryptedSummonerId + Api_Key);
            WebResponse oResponse = oRequest.GetResponse();

            StreamReader sr = new StreamReader(oResponse.GetResponseStream());

            

            return await sr.ReadToEndAsync();
        }

        //Get Uri for profileIcon
        public string GetSummonerPicture(string picId)
        {
            return $"https://ddragon.leagueoflegends.com/cdn/12.2.1/img/profileicon/{picId}.png";
        }
    }
}
