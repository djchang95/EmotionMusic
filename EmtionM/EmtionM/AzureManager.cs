using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using EmtionM.DataModels;

namespace EmtionM
{
    class AzureManager
    {
        private static AzureManager instance;
        private MobileServiceClient mobileClient;
        private IMobileServiceTable<myemotionmusicinformation> musicTable;

        private AzureManager()
        {
            this.mobileClient = new MobileServiceClient("http://emotionandmusic.azurewebsites.net");
            this.musicTable = this.mobileClient.GetTable<myemotionmusicinformation>();
        }

        public MobileServiceClient AzureClient
        {
            get { return mobileClient; }
        }

        public static AzureManager AzureManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureManager();
                }

                return instance;
            }
        }
        public async Task<List<myemotionmusicinformation>> GetMusicInformation()
        {
            return await this.musicTable.ToListAsync();
        }

        public async Task PostMusicInformation(myemotionmusicinformation musicList)
        {
            await this.musicTable.InsertAsync(musicList);
        }
    }
}
