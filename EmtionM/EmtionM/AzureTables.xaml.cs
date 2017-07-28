using EmtionM.DataModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmtionM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AzureTables : ContentPage
    {

        public AzureTables()
        {
            InitializeComponent();

        }

        private async void Refresh_ClickedAsync(object sender, EventArgs e)
        {
            List<myemotionmusicinformation> EmotionAndMusic = await AzureManager.AzureManagerInstance.GetMusicInformation();

            MusicList.ItemsSource = EmotionAndMusic;
        }

        private async void AddSong_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddSongPage());
        }
    }
}