using EmtionM.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmtionM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddSongPage : ContentPage
    {
        public AddSongPage()
        {
            InitializeComponent();

            EmotionPicker.Items.Add("Happy");
            EmotionPicker.Items.Add("Anger");
            EmotionPicker.Items.Add("Sadness");
            EmotionPicker.Items.Add("Contempt");
            EmotionPicker.Items.Add("Disgust");
            EmotionPicker.Items.Add("Fear");
            EmotionPicker.Items.Add("Neutral");
            EmotionPicker.Items.Add("Surprise");
        }

        private async Task AddButton_Clicked(object sender, EventArgs e)
        {
            if(SongNameEntry.Text.Length > 0)
            {
                myemotionmusicinformation model = new myemotionmusicinformation()
                {

                    Musician = MusicianEntry.Text,
                    SongName = SongNameEntry.Text,
                    Emotion = (string)EmotionPicker.SelectedItem

                };
                await AzureManager.AzureManagerInstance.PostMusicInformation(model);

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Alert", "Enter Your Song Name", "OK");
            }
           
        }
    }
}