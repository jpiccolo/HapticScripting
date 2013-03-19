using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripter.ViewModel
{
    using System.ComponentModel;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    using HapticScripter.UI;

    public class TimelineControlViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }
            field = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        public enum ViewLevel
        {
            Level1 = 10,
            Level2 = 20,
            Level3 = 30,
            Level4 = 40,
            Level5 = 50
        }

        private int headerWidth;
        public int HeaderWidth
        {
            get { return this.headerWidth; }
            set
            {
                this.SetField(ref this.headerWidth, value, "HeaderWidth");
                HeaderVisualHost = new HeaderVisualHost(value, ViewLevel.Level1);
                LineVisualHost = new LineVisualHost(500);
            }
        }

        private HeaderVisualHost headerVisualHost = new HeaderVisualHost(1000, ViewLevel.Level1);
        private double timelineScrollViewerViewportWidth;
        private LineVisualHost lineVisualHost = new LineVisualHost(100);
        public HeaderVisualHost HeaderVisualHost
        {
            get
            {



                return this.headerVisualHost;
            }
            set
            {
                this.SetField(ref this.headerVisualHost, value, "HeaderVisualHost");
            }
        }


        public void ExportToPng(Uri path, Canvas surface)
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
            using (FileStream outStream = new FileStream(path.LocalPath, FileMode.Create))
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

        private void SaveImageToJPEG(Image ImageToSave, string Location)
        {
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)ImageToSave.Source.Width,
                                                                           (int)ImageToSave.Source.Height,
                                                                           100, 100, PixelFormats.Default);
            renderTargetBitmap.Render(ImageToSave);
            JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder();
            jpegBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
            using (FileStream fileStream = new FileStream(Location, FileMode.Create))
            {
                jpegBitmapEncoder.Save(fileStream);
                fileStream.Flush();
                fileStream.Close();
            }
        }


        public ScrollViewer TimelineScroller { get; set; }

        public double TimelineScrollViewerViewportWidth
        {
            get { return this.timelineScrollViewerViewportWidth; }
            set { this.SetField(ref this.timelineScrollViewerViewportWidth, value, "TimelineScrollViewerViewportWidth"); }
        }

        public LineVisualHost LineVisualHost
        {
            get { return this.lineVisualHost; }
            set { this.SetField(ref this.lineVisualHost, value, "LineVisualHost"); }
        }
    }
}
