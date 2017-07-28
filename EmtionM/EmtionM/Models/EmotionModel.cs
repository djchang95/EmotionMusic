using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace EmtionM.Model
{
    public class EmotionModel
        {
        [JsonProperty("scores")]
        public Scores scores { get; set; }
        }

    public class Scores
        {
        [JsonProperty("anger")]
        public double anger { get; set; }
        [JsonProperty("contempt")]
        public double contempt { get; set; }
        [JsonProperty("disgust")]
        public double disgust { get; set; }
        [JsonProperty("fear")]
        public double fear { get; set; }
        [JsonProperty("hapiness")]
        public double happiness { get; set; }
        [JsonProperty("neutral")]
        public double neutral { get; set; }
        [JsonProperty("sadness")]
        public double sadness { get; set; }
        [JsonProperty("surprise")]
        public double surprise { get; set; }
        }
    }
