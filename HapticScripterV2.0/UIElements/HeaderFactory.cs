using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripterV2._0.UIElements
{
    using System.Globalization;
    using System.Windows;
    using System.Windows.Media;

    using HapticScripterV2._0.ViewModels;

    public class HeaderFactory : FrameworkElement
    {
        #region Fields

        private readonly VisualCollection children;

        public DrawingVisual MyVisual;

        #endregion

        #region Constructors and Destructors

        public HeaderFactory(int width, TimelineViewModel.ViewLevel level)
        {
            children = new VisualCollection(this);

            MyVisual = new DrawingVisual();
            children.Add(MyVisual);

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

            using (var dc = MyVisual.RenderOpen())
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
                            case TimelineViewModel.ViewLevel.Level1:
                                text = new FormattedText(
                                        currentTime.ToString(@"hh\:mm\:ss\.fff"),
                                        CultureInfo.CurrentCulture,
                                        FlowDirection.LeftToRight,
                                        new Typeface("Tahoma"),
                                        8,
                                        grayBrush);
                                break;
                            case TimelineViewModel.ViewLevel.Level2:
                            case TimelineViewModel.ViewLevel.Level3:
                            case TimelineViewModel.ViewLevel.Level4:
                            case TimelineViewModel.ViewLevel.Level5:
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
                            case TimelineViewModel.ViewLevel.Level1:
                                text = new FormattedText(
                                        string.Format(".{0}", currentTime.Milliseconds),
                                        CultureInfo.CurrentCulture,
                                        FlowDirection.LeftToRight,
                                        new Typeface("Tahoma"),
                                        8,
                                        grayBrush);
                                break;
                            case TimelineViewModel.ViewLevel.Level2:
                            case TimelineViewModel.ViewLevel.Level3:
                            case TimelineViewModel.ViewLevel.Level4:
                            case TimelineViewModel.ViewLevel.Level5:
                                text = new FormattedText(
                                        string.Format("{0}", currentTime.ToString(@"ss\.f")),
                                        CultureInfo.CurrentCulture,
                                        FlowDirection.LeftToRight,
                                        new Typeface("Tahoma"),
                                        8,
                                        grayBrush);
                                break;
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
