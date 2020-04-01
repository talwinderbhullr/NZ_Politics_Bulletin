
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System.Collections.Generic;

namespace NZ_Politics_Bulletin
{
    [Activity(Label = "NZ_Politics_Bulletin", Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        RESThandler objRest;

        ListView lstNews;
        List<Item> tmpNewsList;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            lstNews = FindViewById<ListView>(Resource.Id.lstNews);

            lstNews.ItemClick += OnLstNewsClick;

            lstNews.FastScrollEnabled = true;
            lstNews.ScrollingCacheEnabled = true;

            LoadNZ_Politics_Bulletin();
        }

        void OnLstNewsClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var NewsItem = tmpNewsList[e.Position];
            var NewsArticle = new Intent(this, typeof(News));
            NewsArticle.PutExtra("URL", NewsItem.Link);
            StartActivity(NewsArticle);

        }


        public async void LoadNZ_Politics_Bulletin()
        {
            objRest = new RESThandler(@"http://rss.nzherald.co.nz/rss/xml/nzhrsscid_000000001.xml");
            var Response = await objRest.ExecuteRequestAsync();

            lstNews.Adapter = new DataBaseManager(this, Response.Channel.Item);
            tmpNewsList = Response.Channel.Item;
        }

    }
}
