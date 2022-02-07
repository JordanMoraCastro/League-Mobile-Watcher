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

        public MatchService()
        {

            this.Api_Key = "RGAPI-36431b78-0ab8-4a42-b352-06deb35d1a51";
        }


        public async Task<string> GetSummonerMatchHistory(string puiid)
        {


            var request = new HttpRequestMessage();

            request.RequestUri = new Uri($"https://americas.api.riotgames.com/lol/match/v5/matches/by-puuid/{puiid}/ids?start=0&count=5&api_key={Api_Key}");
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


            var request = new HttpRequestMessage();

            request.RequestUri = new Uri($"https://americas.api.riotgames.com/lol/match/v5/matches/{MatchId}?api_key={Api_Key}");
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
