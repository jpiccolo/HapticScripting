using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripter.UI
{
    using System.Windows;
    using System.Windows.Media;

    public class LineVisualHost : FrameworkElement
    {
        private readonly VisualCollection children;

        public LineVisualHost(int height)
        {
            children = new VisualCollection(this);

            var visual = new DrawingVisual();
            children.Add(visual);

            using (var dc = visual.RenderOpen())
            {
                var whitePen = new Pen(Brushes.White, 2);

                dc.DrawLine(whitePen, new Point(0, 0), new Point(0, height));
            }
        }

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
