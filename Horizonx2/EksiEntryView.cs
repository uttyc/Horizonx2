using Horizonx2.Models;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Horizonx2
{
    public class EksiEntryView : ContentPage
    {
        private EksiEntry _entry;
        public EksiEntryView(EksiEntry entry, bool canBeFavorited)
        {
            _entry = entry;
            var btnAddToFavs = new Button { Text = "Favorilere Ekle" };
            btnAddToFavs.Clicked += BtnAddToFavs_Clicked;
            var btnRemoveFromFavs = new Button { Text = "Favorilerden Çıkar" };
            btnRemoveFromFavs.Clicked += BtnRemoveFromFavs_Clicked;
            Content = new StackLayout
            {
                Children = {
                    new StackLayout
                    {
                        Children = {
                            new Label { Text = _entry.Header, TextColor = Color.Crimson, FontSize = 25, Margin = new Thickness(10)},
                            new ScrollView {
                                Orientation = ScrollOrientation.Vertical,
                                Content =  new Label { Text = _entry.Content, Margin = new Thickness(10), TextColor = Color.FromHex("202020") }  },
                            canBeFavorited ? btnAddToFavs: btnRemoveFromFavs
                        }
                    }
                }
            };
        }

        private void BtnRemoveFromFavs_Clicked(object sender, EventArgs e)
        {
            App.Database.DeleteFavAsync(_entry);
            Navigation.PopAsync();
        }

        private void BtnAddToFavs_Clicked(object sender, EventArgs e)
        {
            App.Database.SaveFavAsync(_entry);
            CrossToastPopUp.Current.ShowToastMessage("Favorilere eklendi!");

        }
    }
}