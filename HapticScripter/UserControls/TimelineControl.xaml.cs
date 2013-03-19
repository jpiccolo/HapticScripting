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

namespace HapticScripter.UserControls
{
    using System.ComponentModel;
    using System.IO;
    using System.Windows.Threading;

    using HapticScripter.Data;
    using HapticScripter.UI;
    using HapticScripter.ViewModel;

    /// <summary>
    /// Interaction logic for TimelineControl.xaml
    /// </summary>
    public partial class TimelineControl : UserControl
    {
        public TimelineControl()
        {
            InitializeComponent();
        }

        private void TimelinesUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            BindingList<HapticEvent> blah = new BindingList<HapticEvent>();
            blah.Add(new HapticEvent());

            AppViewModel.DataViewModel.TopAxisData = blah;
            AppViewModel.DataViewModel.BothAxisData = blah;
            AppViewModel.DataViewModel.BottomAxisData = blah;
            AppViewModel.DataViewModel.SqueezeAxisData = blah;
            AppViewModel.DataViewModel.TopPeriodicData = blah;
            AppViewModel.DataViewModel.BothPeriodicData = blah;
            AppViewModel.DataViewModel.BottomPeriodicData = blah;
            AppViewModel.DataViewModel.SqueezePeriodicData = blah;
            AppViewModel.DataViewModel.LubeAxisData = blah;
            AppViewModel.DataViewModel.HeatAxisData = blah;
            AppViewModel.DataViewModel.StopAxisData = blah;

            AppViewModel.TimelineControlViewModel.TimelineScroller = TimelineScroller;


        }


        public void ExportToPng(string path, Canvas surface)
        {
            if (path == null) return;

            // Save current canvas transform
            Transform transform = surface.LayoutTransform;
            // reset current transform (in case it is scaled or rotated)
            surface.LayoutTransform = null;

            // Get the size of canvas
            Size size = new Size(surface.Width, surface.Height);
            // Measure and arrange the surface
            // VERY IMPORTANT
            surface.Measure(size);
            surface.Arrange(new Rect(size));

            // Create a render bitmap and push the surface to it
            RenderTargetBitmap renderBitmap =
              new RenderTargetBitmap(
                (int)size.Width,
                (int)size.Height,
                96d,
                96d,
                PixelFormats.Pbgra32);
            renderBitmap.Render(surface);

            // Create a file stream for saving image
            using (FileStream outStream = new FileStream(path, FileMode.Create))
            {
                // Use png encoder for our data
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                // push the rendered bitmap to it
                encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                // save the data to the stream
                encoder.Save(outStream);
            }

            // Restore previously saved layout
            surface.LayoutTransform = transform;
        }

        private void TimelineScroller_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            AppViewModel.TimelineControlViewModel.TimelineScrollViewerViewportWidth = TimelineScroller.ActualWidth;
        }

        private void Line_LayoutUpdated(object sender, EventArgs e)
        {
            //var d = AppViewModel.VideoPlayerControlViewModel.Position.TotalMilliseconds / 2;
            //d = d - (TimelineScroller.ViewportWidth / 2);
            //TimelineScroller.ScrollToHorizontalOffset(d);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var temp = new HeaderVisualHost(100000, TimelineControlViewModel.ViewLevel.Level1);

            AppViewModel.TimelineControlViewModel.HeaderWidth = 100000;

            RenderTargetBitmap bmp = new RenderTargetBitmap(100000, 30, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(temp.MyVisual);


            Header.Source = bmp;
            //PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
            ////JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder();
            ////jpegBitmapEncoder.Frames.Add(BitmapFrame.Create(bmp));
            //pngBitmapEncoder.Frames.Add(BitmapFrame.Create(bmp));
            ////using (FileStream fileStream = new FileStream("myju.jpg", FileMode.Create))
            ////{
            ////    jpegBitmapEncoder.Save(fileStream);
            ////    fileStream.Flush();
            ////    fileStream.Close();
            ////}

            //using (FileStream fileStream = new FileStream("some.png", FileMode.Create))
            //{
            //    pngBitmapEncoder.Save(fileStream);
            //    fileStream.Flush();
            //    fileStream.Close();
            //}
        }
    }
}
