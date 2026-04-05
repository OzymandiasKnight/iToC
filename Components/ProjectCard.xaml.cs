using System;
using System.Windows.Controls;
using System.Windows;

namespace Archivum
{
	public partial class ProjectCard : UserControl
	{
		public string projectTitle = "";
		public string projectPath = "";

		public void setProjectPath(string new_path) {
			projectPath = new_path;
			projectTitle = (new_path.Split("\\")[new_path.Split("\\").Length-1]).Split(".")[0];
			ProjectButton.Content = projectTitle;
		}

		public ProjectCard()
		{
			InitializeComponent();
			ProjectButton.Content = projectTitle;
		}

		private void OpenProject(object sender, RoutedEventArgs e)
		{
			NavigationSystem.Instance.Navigate(new ProjectPage(projectTitle));
		}
	}
}
