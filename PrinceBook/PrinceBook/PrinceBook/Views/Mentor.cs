using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrinceBook.Views
{
    public class Mentor : ContentPage
    {
        public Mentor()
        {
            var layout = new StackLayout { Padding = 10 };
            var label = new Label
            {
                Text = "Welcome to the Mentor Page.",
                Font = Font.BoldSystemFontOfSize(NamedSize.Large),
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                XAlign = TextAlignment.Center, 
                YAlign = TextAlignment.Center, 
            };
            layout.Children.Add(label);
            var button = new Button { Text = "See first Mentor", TextColor = Color.White };

            button.Clicked += delegate
            {
                Navigation.PushAsync(new MentorOne());
            };
            layout.Children.Add(button);
            BackgroundImage = "mentors.png";

            Content = new ScrollView { Content = layout };

        }
    }
}
