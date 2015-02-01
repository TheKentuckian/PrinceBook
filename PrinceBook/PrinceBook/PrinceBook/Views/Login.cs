using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrinceBook.Views
{
    public class Login : ContentPage
    {
        public Login()
        {
            BindingContext = new ViewModels.LoginViewModel(Navigation);

            var layout = new StackLayout { Padding = 10 };

            var label = new Label
            {
                Text = "Welcome to PrinceBook. Please Login.",
                Font = Font.BoldSystemFontOfSize(NamedSize.Large),
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                XAlign = TextAlignment.Center, // Center the text in the blue box.
                YAlign = TextAlignment.Center, // Center the text in the blue box.
            };

            layout.Children.Add(label);

            var username = new Entry { Placeholder = "Username" };
            username.SetBinding(Entry.TextProperty, ViewModels.LoginViewModel.UsernamePropertyName);
            layout.Children.Add(username);

            var password = new Entry { Placeholder = "Password", IsPassword = true };
            password.SetBinding(Entry.TextProperty, ViewModels.LoginViewModel.PasswordPropertyName);
            layout.Children.Add(password);

            var button = new Button { Text = "Log In", TextColor = Color.White };
            
            button.Clicked += delegate
            {
                List<ContentPage> pages = new List<ContentPage>(0);
                pages.Add(new Industry());
                pages.Add(new Industry());
                pages.Add(new Industry());
                pages.Add(new Industry());
                pages.Add(new Industry());

                Color[] colors = { Color.Red, Color.Green, Color.Blue };
                foreach (Color c in colors)
                {
                    pages.Add(new ContentPage
                    {
                        Content = new StackLayout
                        {
                            Children = {
                new Label { Text = c.ToString () },
                new BoxView {
                    Color = c,
                    VerticalOptions = LayoutOptions.FillAndExpand
                }
            }
                        }
                    });
                }

                Navigation.PushAsync(new CarouselPage
                {
                    Children = { pages[0], pages[1], pages[2] }
                });
            };
            layout.Children.Add(button);

            Content = new ScrollView { Content = layout };
        }

    }
}
