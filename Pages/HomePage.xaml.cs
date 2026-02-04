using System.Windows.Controls;
using System.Windows;

namespace Archivum
{
	public partial class HomePage : Page
	{
		public HomePage()
		{
			InitializeComponent();
		}

		private void NewProject(object sender, RoutedEventArgs e)
		{
			NavigationSystem.Instance.Navigate(new ProjectPage());
		}
	}
}
