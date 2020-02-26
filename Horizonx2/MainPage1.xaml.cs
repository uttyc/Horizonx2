using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Horizonx2
{
    [DesignTimeVisible(true)]
    public partial class MainPage1 : Shell
    {
        public MainPage1()
        {
            InitializeComponent();
            
        }
        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var sheet = await DisplayActionSheet("Uygulamayı Terk Etmek İstiyor Musunuz?", "Hayır", "Evet", new string[] { });
                switch (sheet)
                {
                    case "Evet":
                        System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                        break;
                }
            });
            return true;
        }
    }
}