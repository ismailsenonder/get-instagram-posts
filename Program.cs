using Newtonsoft.Json;
using System;
using System.Net;
using static GetInstagramPosts.Instagram;

namespace GetInstagramPosts
{
    class Program
    {
        static void Main(string[] args)
        {
            string act = "Your instagram access token. For more info: google";
            int count = 9; //how many posts do you want to retrieve?
            Console.WriteLine(GetInstagramPosts(act, count));
        }
        
        public static string GetInstagramPosts(string accesstoken, int count)
        {
            //you have to do required tasks and get an accesstoken from instagram before being able to use this method.
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://api.instagram.com/v1/users/self/media/recent/?access_token=" + accesstoken + "&count=" + count.ToString());

                #region optional
                //if you want to loop through posts:
                var root = JsonConvert.DeserializeObject<RootObject>(json);

                foreach (Datum dt in root.data)
                {
                    //your code
                    string postUrl = dt.link;
                    string thumbUrl = dt.images.thumbnail.url;
                    //etc etc...
                }
                #endregion

                return json;
            }
        }
    }
}
