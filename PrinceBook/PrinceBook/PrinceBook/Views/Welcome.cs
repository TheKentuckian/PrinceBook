using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrinceBook.Views
{
    public class Welcome : ContentPage
    {
        public Welcome()
        {
            var layout = new StackLayout { Padding = 10 };
            var label2 = new Label
            {
                Text = "In " + Helpers.Global.Industry,
                Font = Font.BoldSystemFontOfSize(NamedSize.Large),
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Start,
            };
            layout.Children.Add(label2);

            var label = new Label
            {
                Text = String.Format("Welcome {0}. Start swipping to find out your new career", Helpers.Global.UserName),
                Font = Font.BoldSystemFontOfSize(NamedSize.Large),
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
            };
            layout.Children.Add(label);
            BackgroundImage = "Pup-home.png";
            Content = new ScrollView { Content = layout };
        }


    }
}
