using System.Windows;
namespace Archivum
{
   public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
			BackgroundPanel.Background = PaletteSystem.background;
			MainFrame.Navigate(new HomePage());		
			NavigationSystem.Instance.NavigationRequest += page =>
			{
				MainFrame.Navigate(page);
			};
		}
    }
}
