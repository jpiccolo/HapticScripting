namespace HapticScripterV2._0.Factories
{
    public static class TimelineFactory
    {
        //    private static void testCode(int start, int width, int count)
        //    {

        //        DrawingVisual visual = createTimeline(start, width, TimelineViewModel.ViewLevel.Level1);

        //        RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(width - start, 30, 96, 96, PixelFormats.Pbgra32);
        //        renderTargetBitmap.Render(visual);

        //        PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();

        //        pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
        //        using (var fileStream = new FileStream(string.Format("some{0}.png", count), FileMode.Create))
        //        {
        //            pngBitmapEncoder.Save(fileStream);
        //            fileStream.Flush();
        //            fileStream.Close();
        //        }
        //    }

        //    public static void RenderHeaderPicture()
        //    {
        //        const int ChunkSize = 5000;
        //        var bitmapFrames = new List<BitmapFrame>();

        //        // generates X number of DrawingVisual's based on ChunkSize
        //        List<DrawingVisual> visuals = generateHeaderVisualChunks(
        //            AppViewModel.TimelineViewModel.HeaderWidth, ChunkSize, TimelineViewModel.ViewLevel.Level1);

        //        for (var i = 0; i < visuals.Count; i++)
        //        {
        //            var renderTargetBitmap = new RenderTargetBitmap(ChunkSize, 30, 96, 96, PixelFormats.Pbgra32);
        //            renderTargetBitmap.Render(visuals[i]);

        //            //test to make sure image good
        //            saveHeaderSegmentAsPng(string.Format("headerSeg{0}.png", i), renderTargetBitmap);

        //            bitmapFrames.Add(BitmapFrame.Create(renderTargetBitmap));
        //        }

        //        var drawingVisual = new DrawingVisual();
        //        using (var drawingContext = drawingVisual.RenderOpen())
        //        {
        //            for (int i = 0; i < bitmapFrames.Count; i++)
        //            {
        //                drawingContext.DrawImage(bitmapFrames[i], new Rect(i * ChunkSize, 0, bitmapFrames[i].PixelWidth, 30));
        //            }
        //            drawingContext.Close();
        //        }

        //        var newBmp = new RenderTargetBitmap(AppViewModel.TimelineViewModel.HeaderWidth, 30, 96, 96, PixelFormats.Pbgra32);
        //        newBmp.Render(drawingVisual);

        //        AppViewModel.TimelineViewModel.HeaderImageSource = newBmp;
        //    }

        //    private static List<DrawingVisual> generateHeaderVisualChunks(int width, int chunkSize, TimelineViewModel.ViewLevel level) 
        //    { 
        //        var ret = new List<DrawingVisual>();

        //        var currentTime = new TimeSpan(0, 0, 0, 0, 0);
        //        var timeStep = new TimeSpan(0, 0, 0, 0, (int)level);
        //        var currentLine = 0;

        //        const double DistanceBetweenLines = 5;
        //        const int TenthOfSecondLine = 10;
        //        const int SecondLine = 100;

        //        int iterations = (width / chunkSize);
        //        int remainder = width % chunkSize; //not doing anything with yet

        //        var grayBrush = new SolidColorBrush(Color.FromRgb(192, 192, 192));
        //        var grayPen = new Pen(grayBrush, 2);
        //        var whitePen = new Pen(Brushes.Purple, 2);

        //        grayBrush.Freeze();
        //        grayPen.Freeze();
        //        whitePen.Freeze();

        //        for (int i = 0; i < iterations; i++)
        //        {
        //            var visual = new DrawingVisual();
        //            using (var dc = visual.RenderOpen())
        //            {
        //                double currentX = 0;

        //                if (i > 0)
        //                {
        //                    currentLine--;
        //                    currentTime -= timeStep;
        //                }

        //                while (currentX <= chunkSize)
        //                {
        //                    if (((currentLine % SecondLine) == 0) && currentLine != 0)
        //                    {
        //                        dc.DrawLine(whitePen, new Point(currentX, 30), new Point(currentX, 15));
        //                        FormattedText text = null;
        //                        double tempX = currentX;
        //                        switch (level)
        //                        {
        //                            case TimelineViewModel.ViewLevel.Level1:
        //                                text = new FormattedText(
        //                                        currentTime.ToString(@"hh\:mm\:ss\.fff"),
        //                                        CultureInfo.CurrentCulture,
        //                                        FlowDirection.LeftToRight,
        //                                        new Typeface("Tahoma"),
        //                                        8,
        //                                        grayBrush);
        //                                break;
        //                        }

        //                        dc.DrawText(text, new Point((tempX - 22), 0));
        //                    }
        //                    else if ((((currentLine % TenthOfSecondLine) == 0) && currentLine != 0)
        //                                && (currentLine % SecondLine) != 0)
        //                    {
        //                        dc.DrawLine(grayPen, new Point(currentX, 30), new Point(currentX, 20));

        //                        FormattedText text = null;
        //                        switch (level)
        //                        {
        //                            case TimelineViewModel.ViewLevel.Level1:
        //                                text = new FormattedText(
        //                                        string.Format(".{0}", currentTime.Milliseconds),
        //                                        CultureInfo.CurrentCulture,
        //                                        FlowDirection.LeftToRight,
        //                                        new Typeface("Tahoma"),
        //                                        8,
        //                                        grayBrush);
        //                                break;
        //                        }

        //                        dc.DrawText(text, new Point((currentX - 8), 8));
        //                    }
        //                    else
        //                    {
        //                        dc.DrawLine(grayPen, new Point(currentX, 30), new Point(currentX, 25));
        //                    }

        //                    currentX += DistanceBetweenLines;
        //                    currentLine++;
        //                    currentTime += timeStep;
        //                }
        //            }
        //            ret.Add(visual);
        //        }
        //        return ret;
        //    }

        //    private static void saveHeaderSegmentAsPng(string fileName, RenderTargetBitmap renderTargetBitmap)
        //{
        //    var pngBitmapEncoder = new PngBitmapEncoder();

        //    pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
        //    using (var fileStream = new FileStream(fileName, FileMode.Create))
        //    {
        //        pngBitmapEncoder.Save(fileStream);
        //        fileStream.Flush();
        //        fileStream.Close();
        //    }
        //}

        //    private static void testCode(int headerWidth)
        //    {
        //        var visual = createOtherTimeline(headerWidth, 4977, TimelineViewModel.ViewLevel.Level1);
        //        var bitmapFrames = new List<BitmapFrame>();
        //        foreach (var drawingVisual in visual)
        //        {
        //            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(4977, 30, 96, 96, PixelFormats.Pbgra32);
        //            renderTargetBitmap.Render(drawingVisual);

        //            bitmapFrames.Add(BitmapFrame.Create(renderTargetBitmap));

        //        }

        //        var localVisual = new DrawingVisual();
        //        using (var drawingContext = localVisual.RenderOpen())
        //        {
        //            for (int i = 0; i < bitmapFrames.Count; i++)
        //            {
        //                drawingContext.DrawImage(bitmapFrames[i], new Rect(i * 4977, 0, bitmapFrames[i].PixelWidth, 30));
        //            }
        //        }

        //        var newBmp = new RenderTargetBitmap(AppViewModel.TimelineViewModel.HeaderWidth, 30, 96, 96, PixelFormats.Pbgra32);
        //        newBmp.Render(localVisual);

        //        AppViewModel.TimelineViewModel.HeaderImageSource = newBmp;
        //    }

        //    private static List<DrawingVisual> createOtherTimeline(int width, int chunkSize, TimelineViewModel.ViewLevel level)
        //    {
        //        //var visual = new DrawingVisual();

        //        var currentTime = new TimeSpan(0, 0, 0, 0, 0);
        //        const int everyXLine100 = 10;
        //        double currentX = 0;
        //        var currentLine = 0;
        //        double distanceBetweenLines = 5;

        //        int iterations = (width / chunkSize);

        //        TimeSpan timeStep = new TimeSpan(0, 0, 0, 0, (int)level);
        //        int majorEveryXLine = 100;

        //        var grayBrush = new SolidColorBrush(Color.FromRgb(192, 192, 192));
        //        grayBrush.Freeze();
        //        var grayPen = new Pen(grayBrush, 2);
        //        var whitePen = new Pen(Brushes.White, 2);
        //        grayPen.Freeze();
        //        whitePen.Freeze();

        //        List<DrawingVisual> visuals = new List<DrawingVisual>();
        //        for (int i = 0; i < iterations; i++)
        //        {
        //            var visual = new DrawingVisual();

        //            using (var dc = visual.RenderOpen())
        //            {
        //                while (currentX < chunkSize*i)
        //                {
        //                    if (((currentLine % majorEveryXLine) == 0) && currentLine != 0)
        //                    {
        //                        dc.DrawLine(whitePen, new Point(currentX, 30), new Point(currentX, 15));
        //                        FormattedText text = null;
        //                        double tempX = currentX;
        //                        switch (level)
        //                        {
        //                            case TimelineViewModel.ViewLevel.Level1:
        //                                text = new FormattedText(
        //                                        currentTime.ToString(@"hh\:mm\:ss\.fff"),
        //                                        CultureInfo.CurrentCulture,
        //                                        FlowDirection.LeftToRight,
        //                                        new Typeface("Tahoma"),
        //                                        8,
        //                                        grayBrush);
        //                                break;
        //                            case TimelineViewModel.ViewLevel.Level2:
        //                            case TimelineViewModel.ViewLevel.Level3:
        //                            case TimelineViewModel.ViewLevel.Level4:
        //                            case TimelineViewModel.ViewLevel.Level5:
        //                                text = new FormattedText(
        //                                        currentTime.ToString(@"hh\:mm\:ss\.f"),
        //                                        CultureInfo.CurrentCulture,
        //                                        FlowDirection.LeftToRight,
        //                                        new Typeface("Tahoma"),
        //                                        8,
        //                                        grayBrush);
        //                                tempX = tempX + 4;
        //                                break;
        //                        }

        //                        dc.DrawText(text, new Point((tempX - 22), 0));
        //                    }
        //                    else if ((((currentLine % everyXLine100) == 0) && currentLine != 0)
        //                             && (currentLine % majorEveryXLine) != 0)
        //                    {
        //                        dc.DrawLine(grayPen, new Point(currentX, 30), new Point(currentX, 20));

        //                        FormattedText text = null;
        //                        switch (level)
        //                        {
        //                            case TimelineViewModel.ViewLevel.Level1:
        //                                text = new FormattedText(
        //                                        string.Format(".{0}", currentTime.Milliseconds),
        //                                        CultureInfo.CurrentCulture,
        //                                        FlowDirection.LeftToRight,
        //                                        new Typeface("Tahoma"),
        //                                        8,
        //                                        grayBrush);
        //                                break;
        //                            case TimelineViewModel.ViewLevel.Level2:
        //                            case TimelineViewModel.ViewLevel.Level3:
        //                            case TimelineViewModel.ViewLevel.Level4:
        //                            case TimelineViewModel.ViewLevel.Level5:
        //                                text = new FormattedText(
        //                                        string.Format("{0}", currentTime.ToString(@"ss\.f")),
        //                                        CultureInfo.CurrentCulture,
        //                                        FlowDirection.LeftToRight,
        //                                        new Typeface("Tahoma"),
        //                                        8,
        //                                        grayBrush);
        //                                break;
        //                            //case TimelineViewModel.ViewLevel.Level3:
        //                            //    text = new FormattedText(
        //                            //            string.Format("{0}", currentTime.ToString(@"mm\:ss")),
        //                            //            CultureInfo.CurrentCulture,
        //                            //            FlowDirection.LeftToRight,
        //                            //            new Typeface("Tahoma"),
        //                            //            8,
        //                            //            grayBrush);
        //                            //    break;
        //                            //case TimelineViewModel.ViewLevel.Level4:
        //                            //    text = new FormattedText(
        //                            //            string.Format("{0}", currentTime.ToString(@"mm\:ss")),
        //                            //            CultureInfo.CurrentCulture,
        //                            //            FlowDirection.LeftToRight,
        //                            //            new Typeface("Tahoma"),
        //                            //            8,
        //                            //            grayBrush);
        //                            //    break;
        //                        }

        //                        dc.DrawText(text, new Point((currentX - 8), 8));
        //                    }
        //                    else
        //                    {
        //                        dc.DrawLine(grayPen, new Point(currentX, 30), new Point(currentX, 25));
        //                    }

        //                    currentX += distanceBetweenLines;
        //                    currentLine++;
        //                    currentTime += timeStep;
        //                }
        //            }

        //            visuals.Add(visual);
        //        }

        //        return visuals;
        //    }

        //    private static DrawingVisual createTimeline(int start, int end, TimelineViewModel.ViewLevel level)
        //    {
        //        var myVisual = new DrawingVisual();

        //        var currentTime = new TimeSpan(0, 0, 0, 0, start*2);
        //        const int everyXLine100 = 10;
        //        double currentX = 0;
        //        if (start > 0)
        //        {
        //            currentX--;
        //        }
        //        var currentLine = start / 5;
        //        double distanceBetweenLines = 5;

        //        TimeSpan timeStep = new TimeSpan(0, 0, 0, 0, (int)level);
        //        int majorEveryXLine = 100;

        //        var grayBrush = new SolidColorBrush(Color.FromRgb(192, 192, 192));
        //        grayBrush.Freeze();
        //        var grayPen = new Pen(grayBrush, 2);
        //        var whitePen = new Pen(Brushes.White, 2);
        //        grayPen.Freeze();
        //        whitePen.Freeze();

        //        using (var dc = myVisual.RenderOpen())
        //        {
        //            while (currentX < (end - start))
        //            {
        //                if (((currentLine % majorEveryXLine) == 0) && currentLine != 0)
        //                {
        //                    dc.DrawLine(whitePen, new Point(currentX, 30), new Point(currentX, 15));
        //                    FormattedText text = null;
        //                    double tempX = currentX;
        //                    switch (level)
        //                    {
        //                        case TimelineViewModel.ViewLevel.Level1:
        //                            text = new FormattedText(
        //                                    currentTime.ToString(@"hh\:mm\:ss\.fff"),
        //                                    CultureInfo.CurrentCulture,
        //                                    FlowDirection.LeftToRight,
        //                                    new Typeface("Tahoma"),
        //                                    8,
        //                                    grayBrush);
        //                            break;
        //                        case TimelineViewModel.ViewLevel.Level2:
        //                        case TimelineViewModel.ViewLevel.Level3:
        //                        case TimelineViewModel.ViewLevel.Level4:
        //                        case TimelineViewModel.ViewLevel.Level5:
        //                            text = new FormattedText(
        //                                    currentTime.ToString(@"hh\:mm\:ss\.f"),
        //                                    CultureInfo.CurrentCulture,
        //                                    FlowDirection.LeftToRight,
        //                                    new Typeface("Tahoma"),
        //                                    8,
        //                                    grayBrush);
        //                            tempX = tempX + 4;
        //                            break;
        //                    }

        //                    dc.DrawText(text, new Point((tempX - 22), 0));
        //                }
        //                else if ((((currentLine % everyXLine100) == 0) && currentLine != 0)
        //                         && (currentLine % majorEveryXLine) != 0)
        //                {
        //                    dc.DrawLine(grayPen, new Point(currentX, 30), new Point(currentX, 20));

        //                    FormattedText text = null;
        //                    switch (level)
        //                    {
        //                        case TimelineViewModel.ViewLevel.Level1:
        //                            text = new FormattedText(
        //                                    string.Format(".{0}", currentTime.Milliseconds),
        //                                    CultureInfo.CurrentCulture,
        //                                    FlowDirection.LeftToRight,
        //                                    new Typeface("Tahoma"),
        //                                    8,
        //                                    grayBrush);
        //                            break;
        //                        case TimelineViewModel.ViewLevel.Level2:
        //                        case TimelineViewModel.ViewLevel.Level3:
        //                        case TimelineViewModel.ViewLevel.Level4:
        //                        case TimelineViewModel.ViewLevel.Level5:
        //                            text = new FormattedText(
        //                                    string.Format("{0}", currentTime.ToString(@"ss\.f")),
        //                                    CultureInfo.CurrentCulture,
        //                                    FlowDirection.LeftToRight,
        //                                    new Typeface("Tahoma"),
        //                                    8,
        //                                    grayBrush);
        //                            break;
        //                    }

        //                    dc.DrawText(text, new Point((currentX - 8), 8));
        //                }
        //                else
        //                {
        //                    dc.DrawLine(grayPen, new Point(currentX, 30), new Point(currentX, 25));
        //                }

        //                currentX += distanceBetweenLines;
        //                currentLine++;
        //                currentTime += timeStep;
        //            }
        //        }
        //        return myVisual;
        //    }
    }
}