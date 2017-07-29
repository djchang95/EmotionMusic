using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using EmtionM.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json.Linq;

namespace EmtionM
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmotionCapture : ContentPage
    {
        public static string YoutubeURL { get; set; }

        public EmotionCapture()
        {
            InitializeComponent();
            YoutubeCarrier.Opacity = 0;
        }

        private async void YoutubeCarrier_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new YoutubeWebPage());
        }

        private async void UploadPictureButton_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("No upload", "Picking a photo is not supported.", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
                return;

            Image1.Source = ImageSource.FromStream(() => file.GetStream());

            await AnalyseEmotion(file);
        }


        private async void TakePictureButton_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", "No camera available.", "OK");
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                PhotoSize = PhotoSize.Large,
                SaveToAlbum = true,
                Name = $"{DateTime.UtcNow}.jpg"
            });
            if (file == null)
                return;

            Image1.Source = ImageSource.FromStream(() => file.GetStream());

            await AnalyseEmotion(file);
        }

        static byte[] GetImageAsByteArray(MediaFile file)
        {
            var stream = file.GetStream();
            BinaryReader ReadBinary = new BinaryReader(stream);
            return ReadBinary.ReadBytes((int)stream.Length);
        }


        public async Task AnalyseEmotion(MediaFile file)
        {
            YoutubeCarrier.Opacity = 1;

            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "55d4b4f1ea264b978f1fe22fbff23a15");

            string url = "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize?";

            HttpResponseMessage response;

            byte[] byteData = GetImageAsByteArray(file);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(url, content);

                try
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();

                        JArray rss = JArray.Parse(responseString);
                        List<double> emotionList = new List<double>();

                        var anger = (double)rss[0]["scores"]["anger"];
                        var happiness = (double)rss[0]["scores"]["happiness"];
                        var sadness = (double)rss[0]["scores"]["sadness"];
                        var contempt = (double)rss[0]["scores"]["contempt"];
                        var disgust = (double)rss[0]["scores"]["disgust"];
                        var fear = (double)rss[0]["scores"]["fear"];
                        var neutral = (double)rss[0]["scores"]["neutral"];
                        var surprise = (double)rss[0]["scores"]["surprise"];

                        emotionList.Add(anger);
                        emotionList.Add(happiness);
                        emotionList.Add(sadness);
                        emotionList.Add(contempt);
                        emotionList.Add(disgust);
                        emotionList.Add(fear);
                        emotionList.Add(neutral);
                        emotionList.Add(surprise);

                        var listSorted = emotionList.OrderBy(i => i).ToList();
                        double maxElementInlist = listSorted[listSorted.Count - 1];

                        if (maxElementInlist == anger)
                        {
                            string[] YoutubeURLArray = new string[2];

                            YoutubeURLArray[0] = "https://youtu.be/mQvteoFiMlg";
                            YoutubeURLArray[1] = "https://youtu.be/d8ekz_CSBVg";

                            Random random = new Random();
                            int randomNumber = random.Next(0, 2);

                            YoutubeURL = YoutubeURLArray[randomNumber];

                            Emotion.Text += "Angry!!";
                        }
                        else if (maxElementInlist == happiness)
                        {
                            string[] YoutubeURLArray = new string[4];

                            YoutubeURLArray[0] = "https://youtu.be/09R8_2nJtjg";
                            YoutubeURLArray[1] = "https://youtu.be/QGJuMBdaqIw?list=RDQM41AQ-GSvq8A";
                            YoutubeURLArray[2] = "https://youtu.be/HMUDVMiITOU";
                            YoutubeURLArray[3] = "https://youtu.be/y6Sxv-sUYtM?list=RDQM41AQ-GSvq8A";
                            

                            Random random = new Random();
                            int randomNumber = random.Next(0, 4);

                            YoutubeURL = YoutubeURLArray[randomNumber];
                            Emotion.Text += " Happy :)";
                        }
                        else if (maxElementInlist == sadness)
                        {
                            string[] YoutubeURLArray = new string[4];

                            YoutubeURLArray[0] = "https://youtu.be/pB-5XG-DbAA";
                            YoutubeURLArray[1] = "https://youtu.be/-2U0Ivkn2Ds";
                            YoutubeURLArray[2] = "https://youtu.be/aVCMyA-EYWQ";
                            YoutubeURLArray[3] = "https://youtu.be/3AtDnEC4zak";
                            

                            Random random = new Random();
                            int randomNumber = random.Next(0, 4);

                            YoutubeURL = YoutubeURLArray[randomNumber];
                            Emotion.Text += " Sad :(";
                        }
                        else if (maxElementInlist == contempt)
                        {
                            string[] YoutubeURLArray = new string[2];

                            YoutubeURLArray[0] = "https://youtu.be/RubBzkZzpUA";
                            YoutubeURLArray[1] = "https://youtu.be/tvTRZJ-4EyI";

                            Random random = new Random();
                            int randomNumber = random.Next(0, 2);

                            YoutubeURL = YoutubeURLArray[randomNumber];
                            Emotion.Text += " Contempting";
                        }
                        else if (maxElementInlist == disgust)
                        {

                            YoutubeURL = "https://youtu.be/G9PnNW56bp0";
                            Emotion.Text += " Disgust";
                        }
                        else if (maxElementInlist == fear)
                        {
                            YoutubeURL = "https://youtu.be/j5-yKhDd64s";
                            Emotion.Text += " Fear";
                        }

                        else if (maxElementInlist == neutral)
                        {

                            string[] YoutubeURLArray = new string[4];

                            YoutubeURLArray[0] = "https://youtu.be/JGwWNGJdvx8";
                            YoutubeURLArray[1] = "https://youtu.be/8mL-uPIfwco";
                            YoutubeURLArray[2] = "https://youtu.be/RgKAFK5djSk";
                            YoutubeURLArray[3] = "https://youtu.be/PT2_F-1esPk";

                            Random random = new Random();
                            int randomNumber = random.Next(0, 4);

                            YoutubeURL = YoutubeURLArray[randomNumber];

                            Emotion.Text += " Neutral :|";
                        }
                        else if (maxElementInlist == surprise)
                        {
                            string[] YoutubeURLArray = new string[2];

                            YoutubeURLArray[0] = "https://youtu.be/axySrE0Kg6k";
                            YoutubeURLArray[1] = "https://youtu.be/cPAbx5kgCJo";

                            Random random = new Random();
                            int randomNumber = random.Next(0, 2);

                            YoutubeURL = YoutubeURLArray[randomNumber];
                            Emotion.Text += " Surprise :o";
                        }
                    }
                }
                catch
                {
                    Emotion.Text = "No face detected!!";
                }

                file.Dispose();
            }
        }
    }
}