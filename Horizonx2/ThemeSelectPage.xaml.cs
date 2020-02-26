using Horizonx2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Horizonx2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThemeSelectPage : ContentPage
    {
        public ThemeSelectPage()
        {
            InitializeComponent();
            var themes = new List<ThemeItem> { new ThemeItem { Theme = "Light", Text = "Açık Tema" }, new ThemeItem { Theme = "Dark Theme", Text = "Koyu Tema" } };
            
            ThemeSelectListView.ItemsSource = themes;
        }

        private void ThemeSelectListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = e.SelectedItem as ThemeItem;
            switch (item.Theme)
            {
                case "Light":
                    ThemeManager.ChangeTheme(ThemeManager.Themes.Light);
                    ThemeManager.LoadTheme();
                    break;
                case "Dark":
                    ThemeManager.ChangeTheme(ThemeManager.Themes.Dark);
                    ThemeManager.LoadTheme();
                    break;
            }
        }
    }
    
}