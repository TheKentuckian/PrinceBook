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
                XAlign = TextAlignment.Center, 
                YAlign = TextAlignment.Center, 
            };

            layout.Children.Add(label);

            var username = new Entry { Placeholder = "Username" };
            username.SetBinding(Entry.TextProperty, new Binding("Username", BindingMode.TwoWay));
            layout.Children.Add(username);

            var password = new Entry { Placeholder = "Password", IsPassword = true };
            password.SetBinding(Entry.TextProperty, ViewModels.LoginViewModel.PasswordPropertyName);
            layout.Children.Add(password);

            var button = new Button { Text = "Log In", TextColor = Color.White };
            
            button.Clicked += delegate
            {
                Helpers.Global.UserName = username.Text;
                Navigation.PushAsync(new Industry());
            };
            layout.Children.Add(button);

            Content = new ScrollView { Content = layout };
        }

    }
}
