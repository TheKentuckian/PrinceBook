using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace PrinceBooks
{

	public class MentorsView : ContentPage
	{


		User user1 = new User {Name = "Bob", Email = "Bob@me.com", Image="https://lh3.googleusercontent.com/-tQguVcMh7As/AAAAAAAAAAI/AAAAAAAAAN8/-RP2lAt4-6Q/photo.jpg"};
		User user2  = new User {Name = "Zak", Email = "Zak@me.com", Image="https://lh3.googleusercontent.com/-tQguVcMh7As/AAAAAAAAAAI/AAAAAAAAAN8/-RP2lAt4-6Q/photo.jpg"};

		private ObservableCollection<User> Users;

		public MentorsView ()
		{

			Title = "Mentors";
			Users = new ObservableCollection<User>();

			Users.Add(user1);
			Users.Add(user2);

			var list = new ListView();
			list.ItemsSource = Users;

			var cell = new DataTemplate(typeof(ImageCell));

			cell.SetBinding (TextCell.TextProperty, "Name");
			cell.SetBinding (TextCell.DetailProperty, "Email");
			cell.SetBinding (ImageCell.ImageSourceProperty, "Image");

			list.ItemTemplate = cell;

			Content = list;
		}

		private class User
		{
			public string Name {get; set;}
			public string Email {get; set;}
			public string Image {get; set;}

		}
	}
}

