using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HapticScripterV2._0.Views
{
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using System.Windows.Interop;

    using HapticScripterV2._0.Factories;
    using HapticScripterV2._0.UIElements;
    using HapticScripterV2._0.ViewModels;

    /// <summary>
    /// Interaction logic for Timelines.xaml
    /// </summary>
    public partial class Timelines : UserControl
    {
        public Timelines()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppViewModel.DataViewModel.VideoDuration = new TimeSpan(0, 1, 20).TotalMilliseconds; //AppViewModel.VideoViewModel.Duration.TotalMilliseconds;

            AppViewModel.TimelineViewModel.HeaderWidth = (int)(AppViewModel.DataViewModel.VideoDuration / 2);      
            
            TimelineFactory.RenderHeaderPicture();

            //HeaderFactory temp = null;
            //RenderTargetBitmap bmp = new RenderTargetBitmap(size, 30, 96, 96, PixelFormats.Pbgra32);



            //temp = new HeaderFactory(0, size, TimelineViewModel.ViewLevel.Level1);
            //bmp.Render(temp.MyVisual);
            //bmp.Freeze();


            //PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
            //pngBitmapEncoder.Frames.Add(BitmapFrame.Create(bmp));






            //BitmapFrame bitmapFrame = BitmapFrame.Create(bmp);






            //using (FileStream fileStream = new FileStream("some.png", FileMode.Create))
            //{
            //    pngBitmapEncoder.Save(fileStream);
            //    fileStream.Flush();
            //    fileStream.Close();
            //}
            //var uri = new Uri(@"C:\some.png");

            ////AppViewModel.TimelineViewModel.HeaderImageSource = logo;




            ////saving png together
            //// Loads the images to tile (no need to specify PngBitmapDecoder, the correct decoder is automatically selected)
            //BitmapFrame frame1 = BitmapDecoder.Create(uri, BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            //BitmapFrame frame2 = BitmapDecoder.Create(uri, BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            //BitmapFrame frame3 = BitmapDecoder.Create(uri, BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            //BitmapFrame frame4 = BitmapDecoder.Create(uri, BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();

            ////// Gets the size of the images (I assume each image has the same size)
            //int imageWidth = frame1.PixelWidth;
            //int imageHeight = frame1.PixelHeight;

            ////// Draws the images into a DrawingVisual component
            //DrawingVisual drawingVisual = new DrawingVisual();
            //using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            //{
            //    drawingContext.DrawImage(frame1, new Rect(0, 0, imageWidth, imageHeight));
            //    drawingContext.DrawImage(frame2, new Rect(imageWidth, 0, imageWidth, imageHeight));
            //    drawingContext.DrawImage(frame3, new Rect(imageWidth * 2, 0, imageWidth, imageHeight));
            //    drawingContext.DrawImage(frame4, new Rect(imageWidth * 3, 0, imageWidth, imageHeight));
            //}

            ////// Converts the Visual (DrawingVisual) into a BitmapSource
            //RenderTargetBitmap bmp = new RenderTargetBitmap(imageWidth * 4, imageHeight, 96, 96, PixelFormats.Pbgra32);
            //bmp.Render(drawingVisual);

            ////// Creates a PngBitmapEncoder and adds the BitmapSource to the frames of the encoder
            ////PngBitmapEncoder encoder = new PngBitmapEncoder();
            ////encoder.Frames.Add(BitmapFrame.Create(bmp));

            ////// Saves the image into a file using the encoder
            ////using (Stream stream = File.Create("newest.png"))
            ////    encoder.Save(stream);




            //AppViewModel.TimelineViewModel.HeaderImageSource = bmp;



            //var bitmapSource = ConvertToBitmap(bmp);

            //RenderTargetBitmap bmp1 = new RenderTargetBitmap(size, 30, 96, 96, PixelFormats.Pbgra32);
            //temp = new HeaderFactory(100055, 200055, TimelineViewModel.ViewLevel.Level1);
            //bmp1.Render(temp.MyVisual);
            //bmp1.Freeze();

            //var bitmapSource1 = ConvertToBitmap(bmp1);


            //var blah = Combine(new[] { bitmapSource });

            //AppViewModel.TimelineViewModel.HeaderImageSource = bitmapSource.ToImageSource();
        }




        private System.Drawing.Bitmap ConvertToBitmap(BitmapSource target)
        {
            System.Drawing.Bitmap bitmap;

            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(target));
                enc.Save(outStream);
                bitmap = new System.Drawing.Bitmap(outStream);
            }

            return bitmap;
        }

        public static System.Drawing.Bitmap Combine(Bitmap[] files)
        {
            //read all images into memory
            List<System.Drawing.Bitmap> images = new List<System.Drawing.Bitmap>();
            System.Drawing.Bitmap finalImage = null;

            try
            {
                int width = 0;
                int height = 0;

                foreach (Bitmap image in files)
                {
                    //create a Bitmap from the file and add it to the list
                    //update the size of the final bitmap
                    width += image.Width;
                    height = image.Height > height ? image.Height : height;

                    images.Add(image);
                }

                //create a bitmap to hold the combined image
                finalImage = new System.Drawing.Bitmap(width, height);

                //get a graphics object from the image so we can draw on it
                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(finalImage))
                {
                    //set background color
                    g.Clear(System.Drawing.Color.Black);

                    //go through each image and draw it on the final image
                    int offset = 0;
                    foreach (System.Drawing.Bitmap image in images)
                    {
                        g.DrawImage(image,
                          new System.Drawing.Rectangle(offset, 0, image.Width, image.Height));
                        offset += image.Width;
                    }
                }

                return finalImage;
            }
            catch (Exception ex)
            {
                if (finalImage != null)
                    finalImage.Dispose();

                throw ex;
            }
            finally
            {
                //clean up memory
                foreach (System.Drawing.Bitmap image in images)
                {
                    image.Dispose();
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            AppViewModel.TimelineViewModel.TimelineScroller = TimelineScroller;
        }
    }

    public static class BitmapExtensions
    {
        public static ImageSource ToImageSource(this Bitmap bitmap)
        {
            var hbitmap = bitmap.GetHbitmap();
            try
            {
                var imageSource = Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromWidthAndHeight(bitmap.Width, bitmap.Height));

                return imageSource;
            }
            finally
            {
                NativeMethods.DeleteObject(hbitmap);
            }
        }
    }

    public static class NativeMethods
    {
        [DllImport("gdi32")]
        public static extern int DeleteObject(IntPtr hObject);
    }
}
