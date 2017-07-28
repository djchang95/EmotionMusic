using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EmtionM.DataModels
{
    class myemotionmusicinformation
    {
        [JsonProperty(PropertyName = "Id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "SongName")]
        public string SongName { get; set; }

        [JsonProperty(PropertyName = "Emotion")]
        public string Emotion { get; set; }
    }
}
