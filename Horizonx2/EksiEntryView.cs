using Horizonx2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Horizonx2
{
    public class EksiEntryView : ContentPage
    {
        public EksiEntryView(EksiEntry entry)
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = entry.Content }
                }
            };
        }
    }
}