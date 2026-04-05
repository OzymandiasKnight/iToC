using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows;

namespace Archivum
{
	public partial class HomePage : Page
	{
		public HomePage()
		{
			InitializeComponent();
			string projectPath = Utilitary.getAppPath();

			if (!Directory.Exists(projectPath)) {
				Directory.CreateDirectory(projectPath);
			};
			string[] projectFiles = Directory.GetFiles(projectPath);

			foreach (string project in projectFiles) {
				ProjectCard new_card = new ProjectCard();
				new_card.setProjectPath(project);
				ProjectsGallery.Children.Add(new_card);
			}
		}

		public void openNewProject(object sender, RoutedEventArgs e) {
			NavigationSystem.Instance.Navigate(new ProjectPage());
		}

		public void openProjectFolder(object sender, RoutedEventArgs e) {
			string projectPath = Utilitary.getAppPath();
			Process.Start("explorer.exe", projectPath);
		}

	}
}
