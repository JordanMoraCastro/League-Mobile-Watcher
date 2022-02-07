using League_Watcher.Services;
using League_Watcher.ViewModels;
using League_Watcher.ViewModels.Match;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace League_Watcher.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileView : ContentPage
    {
        MatchService matchService = new MatchService();

        List<string> MatchList = new List<string>();
        List<MarchInformationViewModel> mathObjetList = new List<MarchInformationViewModel>();

        List<MarchInformationViewModel> FinallmathObjetList = new List<MarchInformationViewModel>();

        List<Participant> participantsList = new List<Participant>();

        string SummonerId;

      

        public ProfileView(List<string> puidd,string summonerId)
        {
            InitializeComponent();
            MatchList = puidd;
            SummonerId = summonerId;
   
            GetMatch();
        }


        public async void GetMatch()
        {

            foreach(var matchinfo in MatchList)
            {
                string respuesta = await matchService.GetMatchInformation(matchinfo);

                MarchInformationViewModel matchMetadata = JsonConvert.DeserializeObject<MarchInformationViewModel>(respuesta);

                var matchStatus = from d in matchMetadata.info.participants
                            where d.summonerId == SummonerId
                            select d.winner;
                var ChampionImage = from d in matchMetadata.info.participants
                                  where d.summonerId == SummonerId
                                  select d.championName;


                var item0 = from d in matchMetadata.info.participants
                            where d.summonerId == SummonerId
                            select d.item0;

                var item1 = from d in matchMetadata.info.participants
                            where d.summonerId == SummonerId
                            select d.item1;

                var item2 = from d in matchMetadata.info.participants
                            where d.summonerId == SummonerId
                            select d.item2;

                var item3 = from d in matchMetadata.info.participants
                            where d.summonerId == SummonerId
                            select d.item3;

                var item4 = from d in matchMetadata.info.participants
                            where d.summonerId == SummonerId
                            select d.item4;


                var item5 = from d in matchMetadata.info.participants
                            where d.summonerId == SummonerId
                            select d.item5;

                var kills = from d in matchMetadata.info.participants
                          where d.summonerId == SummonerId
                          select d.kills;

                var assists = from d in matchMetadata.info.participants
                            where d.summonerId == SummonerId
                            select d.assists;

                var deaths = from d in matchMetadata.info.participants
                            where d.summonerId == SummonerId
                            select d.deaths;


                var CS = from d in matchMetadata.info.participants
                          where d.summonerId == SummonerId
                          select d.totalMinionsKilled;



                var summonerSpell = from d in matchMetadata.info.participants
                         where d.summonerId == SummonerId
                         select d;






                matchMetadata.item0 = $"http://ddragon.leagueoflegends.com/cdn/12.3.1/img/item/{item0.FirstOrDefault()}.png";
                matchMetadata.item1 = $"http://ddragon.leagueoflegends.com/cdn/12.3.1/img/item/{item1.FirstOrDefault()}.png";
                matchMetadata.item2 = $"http://ddragon.leagueoflegends.com/cdn/12.3.1/img/item/{item2.FirstOrDefault()}.png";
                matchMetadata.item3 = $"http://ddragon.leagueoflegends.com/cdn/12.3.1/img/item/{item3.FirstOrDefault()}.png";
                matchMetadata.item4 = $"http://ddragon.leagueoflegends.com/cdn/12.3.1/img/item/{item4.FirstOrDefault()}.png";
                matchMetadata.item5 = $"http://ddragon.leagueoflegends.com/cdn/12.3.1/img/item/{item5.FirstOrDefault()}.png";


                matchMetadata.SummonerSpell1 = GetSummonerSpellImage(summonerSpell.FirstOrDefault().summoner1Id);
                matchMetadata.SummonerSpell2 = GetSummonerSpellImage(summonerSpell.FirstOrDefault().summoner2Id);


                matchMetadata.KDA = $"{kills.FirstOrDefault()}/{deaths.FirstOrDefault()}/{assists.FirstOrDefault()}";

                matchMetadata.cs = $"{CS.FirstOrDefault()} CS";


                matchMetadata.ChampionImage = $"http://ddragon.leagueoflegends.com/cdn/12.3.1/img/champion/{ChampionImage.FirstOrDefault()}.png";

             
                matchMetadata.win = matchStatus.FirstOrDefault();


                mathObjetList.Add(matchMetadata);

            }

         
            lsvMatch.ItemsSource = mathObjetList;


        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
           //TO DO: Cargar los datos al abrir la pagina
        }

        private string GetSummonerSpellImage(int spellId)
        {
            //TO DO: Cambiar 8.11.1 

            switch (spellId)
            {
                case 21:
                    {
                        return "http://ddragon.leagueoflegends.com/cdn/8.11.1/img/spell/SummonerBarrier.png";

                    }
                case 1:
                    {
                        return "http://ddragon.leagueoflegends.com/cdn/8.11.1/img/spell/SummonerBoost.png";

                    }
                case 35:
                    {
                        return "http://ddragon.leagueoflegends.com/cdn/8.11.1/img/spell/SummonerDarkStarChampSelect1.png";

                    }
                case 36:
                    {
                        return "http://ddragon.leagueoflegends.com/cdn/8.11.1/img/spell/SummonerDarkStarChampSelect2.png";

                    }
                case 14:
                    {
                        return "http://ddragon.leagueoflegends.com/cdn/8.11.1/img/spell/SummonerDot.png";

                    }
                case 3:
                    {
                        return "http://ddragon.leagueoflegends.com/cdn/8.11.1/img/spell/SummonerExhaust.png";

                    }
                case 4:
                    {
                        return "http://ddragon.leagueoflegends.com/cdn/8.11.1/img/spell/SummonerFlash.png";

                    }
                case 6:
                    {
                        return "http://ddragon.leagueoflegends.com/cdn/8.11.1/img/spell/SummonerHaste.png";

                    }
                case 7:
                    {
                        return "http://ddragon.leagueoflegends.com/cdn/8.11.1/img/spell/SummonerHeal.png";

                    }

                case 13:
                    {
                        return "http://ddragon.leagueoflegends.com/cdn/8.11.1/img/spell/SummonerMana.png";

                    }
                case 30:
                    {
                        return "http://ddragon.leagueoflegends.com/cdn/8.11.1/img/spell/SummonerPoroRecall.png";

                    }
                case 31:
                    {
                        return "http://ddragon.leagueoflegends.com/cdn/8.11.1/img/spell/SummonerPoroThrow.png";

                    }
                case 33:
                    {
                        return "http://ddragon.leagueoflegends.com/cdn/8.11.1/img/spell/SummonerSiegeChampSelect1.png";

                    }

                case 34:
                    {
                        return "http://ddragon.leagueoflegends.com/cdn/8.11.1/img/spell/SummonerSiegeChampSelect2.png";

                    }
                case 11:
                    {
                        return "http://ddragon.leagueoflegends.com/cdn/8.11.1/img/spell/SummonerSmite.png";

                    }
                case 39:
                    {
                        return "http://ddragon.leagueoflegends.com/cdn/8.11.1/img/spell/SummonerSnowURFSnowball_Mark.png";

                    }
                case 32:
                    {
                        return "http://ddragon.leagueoflegends.com/cdn/8.11.1/img/spell/SummonerSnowball.png";

                    }
                case 12:
                    {
                        return "http://ddragon.leagueoflegends.com/cdn/8.11.1/img/spell/SummonerTeleport.png";

                    }
                default:
                    {
                        return null;
                    }

            }

            }
        }

     
    }

