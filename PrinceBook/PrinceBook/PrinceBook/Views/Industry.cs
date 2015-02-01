using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrinceBook.Views
{
    public class Industry : ContentPage
    {
        public Industry()
        {
            var layout = new StackLayout { Padding = 10 };
            var label = new Label
            {
                Text = "Welcome to the Industry Page.",
                Font = Font.BoldSystemFontOfSize(NamedSize.Large),
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                XAlign = TextAlignment.Center, // Center the text in the blue box.
                YAlign = TextAlignment.Center, // Center the text in the blue box.
            };
            layout.Children.Add(label);

            var button = new Button { Text = "Choose Industry", TextColor = Color.White };

            button.Clicked += delegate
            {
                Navigation.PushAsync(GetIndustryPage(1));
            };
            layout.Children.Add(button);

            Content = new ScrollView { Content = layout };

        }
        public Page GetIndustryPage(int industryID)
        {
            return new NavigationPage(new CarouselPage
            {
                Children = {
                    new Welcome(),
                    new Projects(),
                    new Careers(),
                    new Quiz(),
                    new Mentor() }
            });
        }
    }
}
