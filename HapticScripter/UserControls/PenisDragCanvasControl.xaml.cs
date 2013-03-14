namespace HapticScripter.UserControls
{
    using System;
    using System.ComponentModel;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
	/// Interaction logic for PenisDragCanvasControl.xaml
	/// </summary>
	public partial class PenisDragCanvasControl : UserControl
	{
        private readonly DependencyPropertyDescriptor vaginaTopImageTopDependencyProperty;
        private readonly DependencyPropertyDescriptor vaginaTopImageLeftDependencyProperty;

		public PenisDragCanvasControl()
		{
			this.InitializeComponent();


            this.vaginaTopImageTopDependencyProperty = DependencyPropertyDescriptor.FromProperty(Canvas.TopProperty, typeof(Canvas));
            this.vaginaTopImageLeftDependencyProperty = DependencyPropertyDescriptor.FromProperty(
                Canvas.LeftProperty, typeof(Canvas));

            this.vaginaTopImageTopDependencyProperty.AddValueChanged(this.VaginaTopImage, new EventHandler(this.VaginaTopImageTopChangedCallback));
            this.vaginaTopImageLeftDependencyProperty.AddValueChanged(this.VaginaTopImage, new EventHandler(this.VaginaTopImageLeftChangedCallback));
		}


        private void VaginaTopImageTopChangedCallback(object sender, EventArgs e)
        {
            double top = Canvas.GetTop(this.VaginaTopImage);
            Canvas.SetTop(this.VaginaBottomImage, top - 5.857);

            Canvas.SetTop(this.PenisImage, top - 1.271);
        }

        private void VaginaTopImageLeftChangedCallback(object sender, EventArgs e)
        {
            double left = Canvas.GetLeft(this.VaginaTopImage);
            Canvas.SetLeft(this.VaginaBottomImage, left + 38.2);

            Canvas.SetLeft(this.PenisImage, left + 54.75);
        }

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
        }
	}
}