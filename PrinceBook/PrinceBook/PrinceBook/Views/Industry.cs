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

            var industries = new ServiceClient.ServiceClient().GetIndustries();
            foreach (var industry in industries)
            {
                layout.Children.Add(CreateIndustry(industry));
            }
            BackgroundImage = "industry.png";
            Content = new ScrollView { Content = layout };
        }

        public Button CreateIndustry(PrinceBookWebAPI.Models.Industry i)
        {
            var button = new Button { Text = i.Title, TextColor = Color.White };
            button.Clicked += delegate { Helpers.Global.Industry = i.Title; Navigation.PushAsync(GetIndustryPage(i.ID)); };
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
                    new Mentor(),
                    new Thatsall()
                }
            });
        }
    }
}
