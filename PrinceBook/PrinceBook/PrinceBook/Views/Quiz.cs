using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrinceBook.Views
{
    public class Quiz : ContentPage
    {
        public Quiz()
        {
            var layout = new StackLayout { Padding = 10 };
            var label = new Label
            {
                Text = "Welcome to the Quiz Page.",
                Font = Font.BoldSystemFontOfSize(NamedSize.Large),
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                XAlign = TextAlignment.Center, // Center the text in the blue box.
                YAlign = TextAlignment.Center, // Center the text in the blue box.
            };
            layout.Children.Add(label);

            Content = new ScrollView { Content = layout };

        }
    }
}
