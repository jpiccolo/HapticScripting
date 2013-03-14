using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripter.UI
{
    using System.Globalization;
    using System.Windows;
    using System.Windows.Media;

    public class HeaderVisualHost : FrameworkElement
    {
        #region Fields

        private readonly VisualCollection children;

        #endregion

        #region Constructors and Destructors

        public HeaderVisualHost(int width, MainWindow.ViewLevel level)
        {
            children = new VisualCollection(this);

            var visual = new DrawingVisual();
            children.Add(visual);

            var currentTime = new TimeSpan(0, 0, 0, 0, 0);
            const int everyXLine100 = 10;
            double currentX = 0;
            var currentLine = 0;
            double distanceBetweenLines = 5;


            TimeSpan timeStep = new TimeSpan(0, 0, 0, 0, (int)level);
            int majorEveryXLine = 100;

            var grayBrush = new SolidColorBrush(Color.FromRgb(192, 192, 192));
            grayBrush.Freeze();
            var grayPen = new Pen(grayBrush, 2);
            var whitePen = new Pen(Brushes.White, 2);
            grayPen.Freeze();
            whitePen.Freeze();

            using (var dc = visual.RenderOpen())
            {
                while (currentX < width)
                {
                    if (((currentLine % majorEveryXLine) == 0) && currentLine != 0)
                    {
                        dc.DrawLine(whitePen, new Point(currentX, 30), new Point(currentX, 15));
                        FormattedText text = null;
                        double tempX = currentX;
                        switch (level)
                        {
                            case MainWindow.ViewLevel.Level1:
                                text = new FormattedText(
                                        currentTime.ToString(@"hh\:mm\:ss\.fff"),
                                        CultureInfo.CurrentCulture,
                                        FlowDirection.LeftToRight,
                                        new Typeface("Tahoma"),
                                        8,
                                        grayBrush);
                                break;
                            case MainWindow.ViewLevel.Level2:
                            case MainWindow.ViewLevel.Level3:
                            case MainWindow.ViewLevel.Level4:
                            case MainWindow.ViewLevel.Level5:
                                text = new FormattedText(
                                        currentTime.ToString(@"hh\:mm\:ss\.f"),
                                        CultureInfo.CurrentCulture,
                                        FlowDirection.LeftToRight,
                                        new Typeface("Tahoma"),
                                        8,
                                        grayBrush);
                                tempX = tempX + 4;
                                break;
                        }

                        dc.DrawText(text, new Point((tempX - 22), 0));
                    }
                    else if ((((currentLine % everyXLine100) == 0) && currentLine != 0)
                             && (currentLine % majorEveryXLine) != 0)
                    {
                        dc.DrawLine(grayPen, new Point(currentX, 30), new Point(currentX, 20));

                        FormattedText text = null;
                        switch (level)
                        {
                            case MainWindow.ViewLevel.Level1:
                                text = new FormattedText(
                                        string.Format(".{0}", currentTime.Milliseconds),
                                        CultureInfo.CurrentCulture,
                                        FlowDirection.LeftToRight,
                                        new Typeface("Tahoma"),
                                        8,
                                        grayBrush);
                                break;
                            case MainWindow.ViewLevel.Level2:
                            case MainWindow.ViewLevel.Level3:
                            case MainWindow.ViewLevel.Level4:
                            case MainWindow.ViewLevel.Level5:
                                text = new FormattedText(
                                        string.Format("{0}", currentTime.ToString(@"ss\.f")),
                                        CultureInfo.CurrentCulture,
                                        FlowDirection.LeftToRight,
                                        new Typeface("Tahoma"),
                                        8,
                                        grayBrush);
                                break;
                            //case MainWindow.ViewLevel.Level3:
                            //    text = new FormattedText(
                            //            string.Format("{0}", currentTime.ToString(@"mm\:ss")),
                            //            CultureInfo.CurrentCulture,
                            //            FlowDirection.LeftToRight,
                            //            new Typeface("Tahoma"),
                            //            8,
                            //            grayBrush);
                            //    break;
                            //case MainWindow.ViewLevel.Level4:
                            //    text = new FormattedText(
                            //            string.Format("{0}", currentTime.ToString(@"mm\:ss")),
                            //            CultureInfo.CurrentCulture,
                            //            FlowDirection.LeftToRight,
                            //            new Typeface("Tahoma"),
                            //            8,
                            //            grayBrush);
                            //    break;
                        }


                        dc.DrawText(text, new Point((currentX - 8), 8));
                    }
                    else
                    {
                        dc.DrawLine(grayPen, new Point(currentX, 30), new Point(currentX, 25));
                    }

                    currentX += distanceBetweenLines;
                    currentLine++;
                    currentTime += timeStep;
                }
            }
        }

        #endregion

        // Provide a required override for the VisualChildrenCount property.

        #region Properties

        protected override int VisualChildrenCount { get { return children.Count; } }

        #endregion

        // Provide a required override for the GetVisualChild method.

        #region Methods

        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= children.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return children[index];
        }

        #endregion
    }
}
