using Key_Finder.ViewModels;
using League_Watcher.Services;
using League_Watcher.ViewModels;
using League_Watcher.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using FireSharp;


namespace Key_Finder
{
    public partial class MainPage : ContentPage
    {
        SummonerService summonerService;
        MatchService matchService;

        public List<string> MatchList { get; set; }

        string SummonerId;


       


        public MainPage()
        {
            InitializeComponent();

           summonerService = new SummonerService();
           matchService = new MatchService();

        }



        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {

            if (!rdLAN.IsChecked && !rdLAS.IsChecked && !rdNA.IsChecked)
            {
                await DisplayAlert("League Watcher", "Por favor seleccione una región", "Aceptar");
                return;
            }
        
            CardContainer.IsVisible = false;
            activeIndicator.IsRunning = true;

            string respuesta = await summonerService.GetSummonerData(searchBarSummoner.Text);

            if (respuesta == "Error")
            {
                CardContainer.IsVisible = false;
                MessageContainer.IsVisible = true;
                activeIndicator.IsRunning = false;
            }
            else
            {

                activeIndicator.IsRunning = false;
                SummonerViewModel summoner = JsonConvert.DeserializeObject<SummonerViewModel>(respuesta);


                string respuesta_elo = await summonerService.GetSummonerEloAsync(summoner.id);
                var summoner_elo = JsonConvert.DeserializeObject<List<SummonerElo>>(respuesta_elo);



                if (summoner.name != null)
                {

                    SummonerId = summoner.id;
                    CardContainer.IsVisible = true;

                    lbSummonerName.Text = summoner.name;
                    lbDescription.Text = $"Región: LAN Nivel: {summoner.summonerLevel}";

                    if (summoner_elo.FirstOrDefault() != null)
                    {


                        var rank = from d in summoner_elo
                                   where d.tier != null
                                   orderby d.wins descending
                                   select d;

                        switch (rank.FirstOrDefault().tier.ToString())
                        {
                            case "IRON":
                                {
                                    imgRanked.Source = "Emblem_Iron.png";
                                    break;
                                }

                            case "GOLD":
                                {
                                    imgRanked.Source = "Emblem_Gold.png";
                                    break;
                                }
                            case "SILVER":
                                {
                                    imgRanked.Source = "Emblem_Silver.png";
                                    break;
                                }
                            case "BRONZE":
                                {
                                    imgRanked.Source = "Emblem_Bronze.png";
                                    break;
                                }
                            case "PLATINUM":
                                {
                                    imgRanked.Source = "Emblem_Platinum.png";
                                    break;
                                }
                            case "DIAMOND":
                                {
                                    imgRanked.Source = "Emblem_Diamond.png";
                                    break;
                                }
                            case "MASTER":
                                {
                                    imgRanked.Source = "Emblem_Master.png";
                                    break;
                                }
                            case "GRANSMASTER":
                                {
                                    imgRanked.Source = "Emblem_Grandmaster.png";
                                    break;
                                }
                            case "CHALLENGER":
                                {
                                    imgRanked.Source = "Emblem_Challenger.png";
                                    break;
                                }
                        }

                    }
                    else
                    {

                    }

                    imgProfile.Source = summonerService.GetSummonerPicture(summoner.profileIconId.ToString());

                    string match_response = await matchService.GetSummonerMatchHistory(summoner.puuid);
                    MatchList = JsonConvert.DeserializeObject<List<string>>(match_response);

                    MessageContainer.IsVisible = false;


                }
            }



        }

        async void Button_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ProfileView(MatchList, SummonerId));
        }
    }
}
