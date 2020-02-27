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
        private readonly EksiEntry _entry;
        
        public EksiEntryView(EksiEntry entry, bool canBeFavorited)
        {
            _entry = entry;
            var btnAddToFavs = new Button { Text = "Favorilere Ekle", TextColor = Color.White, BackgroundColor = Color.FromRgb(129, 193, 75), CornerRadius = 50, Margin = new Thickness(5) };
            btnAddToFavs.Clicked += BtnAddToFavs_Clicked;
            var btnRemoveFromFavs = new Button { Text = "Favorilerden Çıkar", TextColor = Color.White, BackgroundColor = Color.Crimson, CornerRadius = 50, Margin = new Thickness(5) };
            btnRemoveFromFavs.Clicked += BtnRemoveFromFavs_Clicked;
            NavigationPage.SetBackButtonTitle(this, "Geri");

            Content = new StackLayout
            {
                
                Children = {
                    new StackLayout
                    {
                        Children = {
                            new Label { Text = _entry.Header, TextColor = Color.FromRgb(129, 193, 75), FontSize = 25, Margin = new Thickness(5), FontAttributes = FontAttributes.Bold},
                            new ScrollView {
                                Orientation = ScrollOrientation.Vertical,
                                Content =  new Label { Text = _entry.Content, Margin = new Thickness(5), TextColor = (Color) Application.Current.Resources["ListViewSecondaryColor"] }  },
                            canBeFavorited ? btnAddToFavs: btnRemoveFromFavs
                        },
                    }
                },
                BackgroundColor = (Color) Application.Current.Resources["PageBackgroundColor"]
                

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