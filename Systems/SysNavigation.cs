using System;
using System.Windows.Controls;

namespace Archivum
{
	public class NavigationSystem {
		private static NavigationSystem instance;
		public static NavigationSystem Instance => instance ??= new NavigationSystem();
		public static Page currentPage = null;

		public event Action<Page> NavigationRequest;

		public void Navigate(Page page) {
			currentPage = page;
			NavigationRequest?.Invoke(page);
		
		}
	}
}
