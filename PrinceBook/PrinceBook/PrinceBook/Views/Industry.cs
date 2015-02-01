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
                Text = "Select Your Interest.",
                Font = Font.BoldSystemFontOfSize(NamedSize.Large),
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                XAlign = TextAlignment.Center, 
                YAlign = TextAlignment.Center, 
            };
            layout.Children.Add(label);

            var subLabel = new Label
            {
                Text = "What do like to do?",
                Font = Font.BoldSystemFontOfSize(NamedSize.Medium),
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
            };
            layout.Children.Add(subLabel);
           
            layout.Children.Add(CreateIndustry("Tech", 1));
            layout.Children.Add(CreateIndustry("Design", 2));
            layout.Children.Add(CreateIndustry("Tech", 3));

            layout.Children.Add(CreateIndustry("Tech", 4));
            layout.Children.Add(CreateIndustry("Tech", 5));
            layout.Children.Add(CreateIndustry("Tech", 6));
            Content = new ScrollView { Content = layout };
        }

        public Button CreateIndustry(string text, int industryID)
        {
            var button = new Button { Text = text, TextColor = Color.White };
            button.Clicked += delegate { Navigation.PushAsync(GetIndustryPage(industryID)); };
            return button;
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
