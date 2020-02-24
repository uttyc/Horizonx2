using Horizonx2.Data;
using Horizonx2.Models;
using Horizonx2.Views;
using HtmlAgilityPack;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Horizonx2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class HomePage : ContentPage
    {
        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }
        public HomePage()
        {
            InitializeComponent();

            RefreshData();
        }

        private void RefreshData()
        {
            //var randomPage = new Random().Next(1, 3078);
            //var url = "https://eksisozluk.com/ogrenildiginde-ufku-iki-katina-cikaran-seyler--2593151?p=" + randomPage;
            var url = "https://eksisozluk.com/";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            //var list = doc.DocumentNode.SelectNodes("//ul[@id='entry-item-list']//li").ToList();
            var topic = doc.DocumentNode.SelectSingleNode("//div[@id='topic']");
            var headers = topic.SelectNodes("//h1[@id='title']").ToList();
            var items = topic.SelectNodes("//ul[@id='entry-item-list']//li").ToList();
            var entries = new List<EksiEntry>();
            for (int i = 0; i < items.Count; i++)
            {
                var entry = new EksiEntry()
                {
                    Header = headers[i].InnerText,
                    Author = items[i].GetAttributeValue("data-author", ""),
                    Content = items[i].InnerText,
                    Likes = Convert.ToInt32(items[i].GetAttributeValue("data-favorite-count", "0"))

                };
                entries.Add(entry);
            }
            //var nodeCollection = doc.DocumentNode.SelectNodes("//div[@class='wrapper']//li");
            //CarouselView.ItemsSource = entries;

            

            EntriesList.RefreshCommand = new Command(() =>
            {
                //Do your stuff.
                RefreshData();
                EntriesList.IsRefreshing = false;
            });
            EntriesList.ItemsSource = entries;
            
            //EntriesList.ItemTemplate = new DataTemplate(typeof(EntryViewCell));
            //customCell.SetBinding(EntryViewCell.ContentThumbnailProperty, "ContentThumbnail");
            //customCell.SetBinding(EntryViewCell.LikesProperty, "Likes");
            //customCell.SetBinding(EntryViewCell.AuthorProperty, "Author");

        }
        private void EntriesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var entry = e.SelectedItem as EksiEntry;
            //var eklenen = await App.database.SaveFavAsync(entry);
            Navigation.PushAsync(new EksiEntryView(entry, true));

            //DisplayActionSheet(entry.Header, "Tamam", null, new string[] { "Favorilere Ekle" });

        }

        /*
          var entry = e.SelectedItem as EksiEntry;
            //var eklenen = await App.database.SaveFavAsync(entry);
            using (var con = new SQLiteConnection(App.FilePath))
            {
                con.CreateTable<EksiEntry>();

                var id = con.Insert(entry);
                
            }
         */
    }
}
