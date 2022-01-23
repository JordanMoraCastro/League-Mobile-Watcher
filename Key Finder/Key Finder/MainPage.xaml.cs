using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Key_Finder
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            if (searchBarSummoner.Text == "Schweitzer")
            {
                CardContainer.IsVisible = true;
                MessageContainer.IsVisible = false;
            }
            else
            {
                CardContainer.IsVisible = false;
                MessageContainer.IsVisible = true;
            }
        }
    }
}
