namespace HapticScripterV2._0.Views
{
    #region

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Controls;
    using System.Windows.Input;

    using HapticScripterV2._0.Models;
    using HapticScripterV2._0.ViewModels;

    #endregion

    /// <summary>
    ///   Interaction logic for HapticEventMouseScripter.xaml
    /// </summary>
    public partial class PenisDragCanvasControl : UserControl
    {
        #region Fields

        private readonly DependencyPropertyDescriptor vaginaTopImageLeftDependencyProperty;
        private readonly DependencyPropertyDescriptor vaginaTopImageTopDependencyProperty;

        #endregion

        #region Constructors and Destructors

        public PenisDragCanvasControl()
        {
            InitializeComponent();

            this.vaginaTopImageTopDependencyProperty = DependencyPropertyDescriptor.FromProperty(
                Canvas.TopProperty, typeof(Canvas));
            this.vaginaTopImageLeftDependencyProperty = DependencyPropertyDescriptor.FromProperty(
                Canvas.LeftProperty, typeof(Canvas));

            this.vaginaTopImageTopDependencyProperty.AddValueChanged(
                this.VaginaTopImage, this.VaginaTopImageTopChangedCallback);
            this.vaginaTopImageLeftDependencyProperty.AddValueChanged(
                this.VaginaTopImage, this.VaginaTopImageLeftChangedCallback);
        }

        #endregion

        #region Methods

        private MovementAnalyser movementAnalyser = new MovementAnalyser();

        private void PenisImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }

            double top = Canvas.GetTop(this.VaginaTopImage);
            double pLeft = Canvas.GetLeft(this.PenisImage);
            double vLeft = Canvas.GetLeft(this.VaginaTopImage);

            Canvas.SetTop(this.PenisImage, top - 1.271);

            if ((vLeft + 54.75) < pLeft)
            {
                Canvas.SetLeft(this.PenisImage, vLeft + 54.75);
                return;
            }

            var t = 25;
            if (pLeft < (vLeft - t))
            {
                Canvas.SetLeft(this.PenisImage, vLeft - t);
            }

            var pos = Canvas.GetLeft(this.PenisImage);
            movementAnalyser.Add(pos);

            PenisLocTextBox.Text = pos.ToString();
        }

        private void VaginaTopImageLeftChangedCallback(object sender, EventArgs e)
        {
            double left = Canvas.GetLeft(this.VaginaTopImage);
            Canvas.SetLeft(this.VaginaBottomImage, left + 38.2);

            Canvas.SetLeft(this.PenisImage, left + 54.75);
        }

        private void VaginaTopImageTopChangedCallback(object sender, EventArgs e)
        {
            double top = Canvas.GetTop(this.VaginaTopImage);
            Canvas.SetTop(this.VaginaBottomImage, top - 5.857);

            Canvas.SetTop(this.PenisImage, top - 1.271);


            movementAnalyser.process();
        }

        #endregion

    }

    class Movement
    {
        public double Value;
        public TimeSpan Position;
    }

    class MovementAnalyser
    {
        enum Trend
        {
            In,
            Out,
            None
        }
        private Trend movementTrend;
        private List<Movement> movements = new List<Movement>();

        public void Add(double val)
        {
            var m = new Movement
                        {
                            Value = val,
                            Position = AppViewModel.VideoViewModel.Position
                        };
            movements.Add(m);

            if (movements.Count<2)
                return;

            if (movementTrend == Trend.None)
                figureMovementTrend();
            
            if (movementTrend == Trend.None)
                return;

            if (movementTrend == Trend.In)
            {
                //value decreasing
                if (val > movements[movements.Count-2].Value)
                {
                    //changing trend
                    TimeSpan span = m.Position - movements[0].Position;
                    if (span.TotalMilliseconds < 100)
                        return;

                    var startInMilli = movements[0].Position.TotalMilliseconds;

                    HapticEvent evt = new HapticEvent();
                    evt.Start = (int)startInMilli;
                    evt.Duration = (int)span.TotalMilliseconds;
                    evt.Magnitude = 200;
                    evt.Direction = HapticEvent.DirectionType.In;

                    AppViewModel.DataViewModel.TopAxisData.AddNewEvent(evt);
                }
                else
                {
                    return;
                }
            }

            if (movementTrend == Trend.Out)
            {
                //value increasing
                if (val < movements[movements.Count - 2].Value)
                {
                    //changing trend
                    TimeSpan span = m.Position - movements[0].Position;
                    if (span.TotalMilliseconds < 100)
                        return;

                    var startInMilli = movements[0].Position.TotalMilliseconds;

                    HapticEvent evt = new HapticEvent();
                    evt.Start = (int)startInMilli;
                    evt.Duration = (int)span.TotalMilliseconds;
                    evt.Magnitude = 200;
                    evt.Direction = HapticEvent.DirectionType.Out;

                    AppViewModel.DataViewModel.TopAxisData.AddNewEvent(evt);
                }
                else
                {
                    return;
                }
            }

            movementTrend = Trend.None;
            movements.Clear();
        }

        private void figureMovementTrend()
        {
            for (int j = 0; j < movements.Count; j++)
            {
                if (!nearlyEqual((float)this.movements[0].Value, (float)this.movements[j].Value, 0.00001f))
                {
                    this.movementTrend = this.movements[0].Value < this.movements[j].Value ? Trend.Out : Trend.In;
                    break;
                }
            }
        }

        public void process()
        {
            if (movements.Count < 2)
                return;
            
            if (movements.Count == 2)
                return; //todo later

            Console.WriteLine("********Here*********");
            foreach (var movement in movements)
            {
                Console.WriteLine(movement.Value + "    " + movement.Position.ToString());
            }

            var start = movements[0];

            this.movementTrend = start.Value < this.movements[1].Value ? Trend.Out : Trend.In;

            var lastVal = this.movements[1].Value;
            for (int i = 2; i < this.movements.Count; i++)
            {
                var movement = this.movements[i];

                switch (movementTrend)
                {
                    case Trend.In:
                        if (lastVal <= movement.Value)
                        {
                            TimeSpan span = movement.Position - start.Position;
                            if (span.TotalMilliseconds < 100)
                                break;
                            
                            var startInMilli = start.Position.TotalMilliseconds;
                            
                            HapticEvent evt = new HapticEvent();
                            evt.Start = (int)startInMilli;
                            evt.Duration = (int)span.TotalMilliseconds;
                            evt.Magnitude = 200;
                            evt.Direction = HapticEvent.DirectionType.In;

                            start = movements[i];
                            
                            AppViewModel.DataViewModel.TopAxisData.AddNewEvent(evt);

                            if (i != movements.Count)
                            {
                                for (int j = i; j < movements.Count; j++ )
                                {
                                    if (!nearlyEqual((float)start.Value, (float)this.movements[j].Value, 0.00001f))
                                    {
                                        this.movementTrend = start.Value < this.movements[j].Value ? Trend.Out : Trend.In;  
                                    }
                                }
                            }
                        }
                        break;
                    case Trend.Out:
                        if (lastVal >= movement.Value)
                        {
                            TimeSpan span = movement.Position - start.Position;

                            if (span.TotalMilliseconds < 100)
                                break;

                            var startInMilli = start.Position.TotalMilliseconds;

                            HapticEvent evt = new HapticEvent();
                            evt.Start = (int)startInMilli;
                            evt.Duration = (int)span.TotalMilliseconds;
                            evt.Magnitude = 200;
                            evt.Direction = HapticEvent.DirectionType.Out;

                            start = movements[i];

                            AppViewModel.DataViewModel.TopAxisData.AddNewEvent(evt);

                            if (i != movements.Count)
                            {
                                for (int j = i; j < movements.Count; j++)
                                {
                                    if (!nearlyEqual((float)start.Value, (float)this.movements[j].Value, 0.00001f))
                                    {
                                        this.movementTrend = start.Value < this.movements[j].Value ? Trend.Out : Trend.In;
                                    }
                                }
                            }
                        }
                        break;
                }
                lastVal = movement.Value;
            }

            movements.Clear();
        }

        public static bool nearlyEqual(float a, float b, float epsilon) 
        {
             float absA = Math.Abs(a);
             float absB = Math.Abs(b);
             float diff = Math.Abs(a - b);

            if (a == b) { // shortcut, handles infinities
                return true;
            }
            if (a == 0 || b == 0 || diff < float.MinValue) {
                // a or b is zero or both are extremely close to it
                // relative error is less meaningful here
                return diff < (epsilon * float.MinValue);
            } // use relative error
            return diff / (absA + absB) < epsilon;
        }
    }
}