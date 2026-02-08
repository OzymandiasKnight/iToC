using System.Windows.Media;

namespace Archivum {

	public class Color {
		
		public Color(int r, int g, int b) {
			R = r;
			G = g;
			B = b;
		}

		public Color(string hex) {
			int hex_value = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
			B = hex_value%256;
			hex_value = hex_value >> 8;
			G = hex_value%256;
			hex_value = hex_value >> 8;
			R = hex_value%256;
		}

		public Color(int color_value) {
			B = color_value%256;
			color_value = color_value >> 8;
			G = color_value%256;
			color_value = color_value >> 8;
			R = color_value%256;
		}

		public int R { get; }
		public int G { get; }
		public int B { get; }

		public string getHex() {
			return R.ToString("X") + G.ToString("X") + B.ToString("X");
		}
	
		private static Brush to_Brush(string hex)
		{
			BrushConverter converter = new BrushConverter();
			return (Brush) converter.ConvertFromString(hex);
		}

	}

}
