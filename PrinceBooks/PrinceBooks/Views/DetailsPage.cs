
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrinceBooks
{
	public class DetailsPage : ContentPage
	{
		public DetailsPage(User user)
		{
			this.Title = user.Name;

			var details = new Label{
				Text = user.Name
			};



			var image = new Image
			{
				Source = user.Image,
				Aspect = Aspect.AspectFit,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			Content = new ScrollView
			{
				Padding = 20,
				Content = new StackLayout
				{
					Spacing = 10,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Children = {details,, image}
				}
			};
		}
	}
}
