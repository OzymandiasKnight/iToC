using System.Windows.Controls;
using System.Windows;

namespace Archivum
{
	public partial class ProjectCard : UserControl
	{
		public ProjectCard()
		{
			InitializeComponent();
		}

		private void OpenProject(object sender, RoutedEventArgs e)
		{
			NavigationSystem.Instance.Navigate(new ProjectPage());
		}
	}
}
