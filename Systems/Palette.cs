using System.Windows.Media;

namespace Archivum
{
	static class PaletteSystem
	{

		private static Color to_Color(string hex) {
			return new Color(hex);
		}

		private static Brush color_To_Brush(Color from_color) {
			BrushConverter converter = new BrushConverter();
			return (Brush) converter.ConvertFromString(from_color.getHex());
		}

		private static Brush to_Brush(string hex) {
			BrushConverter converter = new BrushConverter();
			return (Brush) converter.ConvertFromString(hex);
		}

		public static Brush background = to_Brush("#0d1b2a");
		public static Brush text = to_Brush("#e0e1dd");
		public static Brush border = to_Brush("#1b263b");
		public static Brush panel = to_Brush("#415a77");
	}
}
