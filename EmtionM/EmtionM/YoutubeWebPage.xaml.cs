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
    public partial class YoutubeWebPage : ContentPage
    {
        public YoutubeWebPage()
        {
            InitializeComponent();
            Youtube.Source = EmotionCapture.YoutubeURL;

            Youtube.WidthRequest = 1000;
            Youtube.HeightRequest = 1000;

        }
    }
}