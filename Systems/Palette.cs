using System.Windows.Media;

namespace Archivum
{
	static class PaletteSystem
	{
		private static Brush to_Brush(string hex)
		{
			BrushConverter converter = new BrushConverter();
			return (Brush) converter.ConvertFromString(hex);
		}

		public static Brush background = to_Brush("#191d32");
		public static Brush text = to_Brush("#ffffff");
	}
}
