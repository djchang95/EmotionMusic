using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EmtionM
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Start_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmotionCapture());
        }

        private async void Songlist_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AzureTables());
        }
    }
}
