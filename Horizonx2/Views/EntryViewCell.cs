using Horizonx2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Horizonx2.Views
{
    public class EntryViewCell : ViewCell
    {
        [Obsolete]
        public EntryViewCell()
        {
            Label header = new Label { TextColor = Color.Brown };
            Label likes = new Label { TextColor = Color.Crimson };
            Label author = new Label { TextColor = Color.RosyBrown };
            Grid grid = new Grid
            {
                Padding = new Thickness(10),
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto},
                    new RowDefinition { Height = GridLength.Auto}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Auto},
                    new ColumnDefinition { Width = GridLength.Auto}
                }
            };

            StackLayout stack = new StackLayout {
                Children =
                {
                    likes, header, author
                },
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Beige
            };
            stack.Orientation = StackOrientation.Horizontal;
            
            //stack.Children.Add(likes);
            //stack.Children.Add(author);
            //stack.Children.Add(header);


            grid.Children.Add(likes, 0, 0);
            grid.Children.Add(header, 1, 0);
            grid.Children.Add(author, 1, 1);

            View = stack;
            //set bindings
            likes.SetBinding<EksiEntry>(Label.TextProperty, i => i.Likes);
            header.SetBinding<EksiEntry>(Label.TextProperty, i => i.Header);
            author.SetBinding<EksiEntry>(Label.TextProperty, i => i.Author); 
            //likes.SetBinding(Label.TextProperty, "Likes");
            //author.SetBinding(Label.TextProperty, "Author");

            //Set properties for desired design
            //verticalLayout.Orientation = StackOrientation.Vertical;


            //author.TextColor = Color.FromHex("#f35e20");
            //likes.TextColor = Color.FromHex("#503026");

            //add views to the view hierarchy
            //grid.Children.Add(author, 1, 2, 1, 2);
            //grid.Children.Add(likes, 1, 2, 0, 1);

            //cellWrapper.BackgroundColor = Color.FromHex("#f2f2f2");
            //cellWrapper.Children.Add(verticalLayout);
        }

    }
}
