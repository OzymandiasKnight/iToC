using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System;

namespace Archivum
{
	public partial class ProjectPage : Page
	{
		static Image pixel_canva = new Image();
		static WriteableBitmap bitmap = new WriteableBitmap(400, 400, 96, 96, PixelFormats.Bgr32, null);
		
		public ProjectPage()
		{
			InitializeComponent();
			
			//Pixel canva
			pixel_canva.Source = bitmap;
			pixel_canva.MouseLeftButtonDown += new MouseButtonEventHandler(canvas_mouse_handler);
			pixel_canva.LayoutTransform = new ScaleTransform(2,2);
			CanvasHolder.Background = PaletteSystem.text;
			CanvasHolder.Children.Add(pixel_canva);
			//Width and Height parameters
			widthChange(WidthLine.TextValue);
			heightChange(HeightLine.TextValue);
			HeightLine.TextChanged += heightChange;
			WidthLine.TextChanged += widthChange;
			CodeLine.TextChanged += codeLineChange;
			XLine.TextChanged += codeLineChange;
			YLine.TextChanged += codeLineChange;
		}
	
		public void updateCode() {
			CodeHolder.Text = "";
			try {
				bitmap.Lock();
				unsafe {
					for (int x=0; x<bitmap.Width; x++) {
						for (int y=0; y<bitmap.Height; y++) {
							IntPtr pBackBuffer = bitmap.BackBuffer;
							pBackBuffer += y * bitmap.BackBufferStride;
							pBackBuffer += x * 4;
							if ((*(int*)pBackBuffer) != 0) {
								string code_line = CodeLine.TextValue.Replace(XLine.TextValue, x.ToString());
								code_line = code_line.Replace(YLine.TextValue, y.ToString());
								CodeHolder.Text += code_line + "\n";
							}
						}
					}
				}
			}
			finally {
				bitmap.Unlock();
			}
		}



		private void canvas_mouse_handler(object sender, MouseEventArgs e) {
			int column = (int) e.GetPosition(pixel_canva).X;
			int row = (int) e.GetPosition(pixel_canva).Y;
			DrawPixel(column, row, 255, 255, 255);
		}


		static void DrawPixel(int x, int y, int r, int g, int b) {
			//Check out of bound
			if (x < bitmap.Width && y < bitmap.Height) {
					try {
					bitmap.Lock();
					unsafe
					{
						IntPtr pBackBuffer = bitmap.BackBuffer;
						pBackBuffer += y * bitmap.BackBufferStride;
						pBackBuffer += x * 4;

						int colorData = 255 << 16; // R
						colorData |= 255 << 8;   // G
						colorData |= 255 << 0;   // B

						*((int*) pBackBuffer) = colorData;

						bitmap.AddDirtyRect(new Int32Rect(x, y, 1, 1));
					}
					
				}
				finally {
					bitmap.Unlock();
				}
			}
		}

		public void heightChange(string new_height) {
			pixel_canva.Height = int.Parse(new_height);
			CanvasHolder.Height = pixel_canva.Height*2;
			updateCanva();
		}

		public void widthChange(string new_width) {
			pixel_canva.Width = int.Parse(new_width);
			CanvasHolder.Width = pixel_canva.Width*2;
			updateCanva();
		}

		public void updateCanva() {
			if (pixel_canva.Height > 0 && pixel_canva.Width > 0) {
				bitmap = new WriteableBitmap((int)pixel_canva.Width, (int)pixel_canva.Height, 96, 96, PixelFormats.Bgr32, null);
				pixel_canva.Source = bitmap;			
			}

		}

		public void codeLineChange(string new_text) {
			updateCode();
		}

	}


}
