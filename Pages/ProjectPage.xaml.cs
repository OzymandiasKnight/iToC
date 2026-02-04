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
			pixel_canva.Width = 200;
			pixel_canva.Height = 200;
			pixel_canva.Source = bitmap;
			pixel_canva.MouseLeftButtonDown += new MouseButtonEventHandler(canvas_mouse_handler);
			CanvasHolder.Children.Add(pixel_canva);
			
		}


		static void canvas_mouse_handler(object sender, MouseEventArgs e)
		{
			int column = (int) e.GetPosition(pixel_canva).X;
			int row = (int) e.GetPosition(pixel_canva).Y;
			DrawPixel(column, row, 255, 255, 255);
		}


		static void DrawPixel(int x, int y, int r, int g, int b)
		{

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


}
