using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace League_Watcher.Services
{
    class MatchService
    {
        public string Api_Key { get; set; }
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "UPs7n2OurGHavTKdGrXDXVJ4JuBU3FT6KzsOzmTP",
            BasePath = "https://league-watcher-1905-default-rtdb.firebaseio.com/"

        };
        public IFirebaseClient FireBase_client;

        public MatchService()
        {

            this.Api_Key = "RGAPI-5d6382b0-3b72-40ac-93ce-e3e9a1e6cae0";
        }

        public async Task<string> GetSummonerMatchHistory(string puiid)
        {



            FireBase_client = new FirebaseClient(ifc);

            FirebaseResponse firebase_response = await FireBase_client.GetAsync("Riot_Key");
            string riot_key = JsonConvert.DeserializeObject<string>(firebase_response.Body.ToString());


            var request = new HttpRequestMessage();

            request.RequestUri = new Uri($"https://americas.api.riotgames.com/lol/match/v5/matches/by-puuid/{puiid}/ids?start=0&count=10&api_key={riot_key}");
            request.Method = HttpMethod.Get;

            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient();

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                return content;

            }
            else
            {
                return "404";
            }
        }


        public async Task<string> GetMatchInformation(string MatchId)
        {



            FireBase_client = new FirebaseClient(ifc);

            FirebaseResponse firebase_response = await FireBase_client.GetAsync("Riot_Key");
            string riot_key = JsonConvert.DeserializeObject<string>(firebase_response.Body.ToString());

            var request = new HttpRequestMessage();
            request.RequestUri = new Uri($"https://americas.api.riotgames.com/lol/match/v5/matches/{MatchId}?api_key={riot_key}");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient();

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return "404";
            }
        }
    }
}
