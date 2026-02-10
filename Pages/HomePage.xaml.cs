using System.Windows.Controls;
using System.Windows;

namespace Archivum
{
	public partial class HomePage : Page
	{
		public HomePage()
		{
			InitializeComponent();
			for (int x=0; x<10; x++) {
				ProjectCard new_card = new ProjectCard();
				ProjectsGallery.Children.Add(new_card);
			}
		}

		private void NewProject(object sender, RoutedEventArgs e)
		{
			NavigationSystem.Instance.Navigate(new ProjectPage());
		}
	}
}
