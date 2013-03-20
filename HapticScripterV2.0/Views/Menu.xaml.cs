namespace HapticScripterV2._0.Views
{
    #region

    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;

    using HapticScripterV2._0.ViewModels;

    using Microsoft.Win32;

    #endregion

    /// <summary>
    ///   Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        private DataViewModel data = AppViewModel.DataViewModel;

        #region Constructors and Destructors

        public Menu() { InitializeComponent(); }

        #endregion

        #region Methods

        private void MenuItem_About_Clicked(object sender, RoutedEventArgs e) { }

        private void MenuItem_CheckUpdates_Clicked(object sender, RoutedEventArgs e) { }

        private void MenuItem_CloseProject_Clicked(object sender, RoutedEventArgs e) { }

        private void MenuItem_Errors_ScriptCommandExceeds(object sender, RoutedEventArgs e) { }

        private void MenuItem_Exit_Clicked(object sender, RoutedEventArgs e) { }

        private void MenuItem_ExportScript_Click(object sender, RoutedEventArgs e) { }

        private void MenuItem_ExportScriptedVideo_Click(object sender, RoutedEventArgs e) { }

        private void MenuItem_FixErrors_Clicked(object sender, RoutedEventArgs e) { }

        private void MenuItem_ImportScript_Clicked(object sender, RoutedEventArgs e) { }

        private void MenuItem_ImportScriptedVideo_Clicked(object sender, RoutedEventArgs e) { }

        private void MenuItem_NewProject_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_OpenAppDataFolder_Clicked(object sender, RoutedEventArgs e) { }

        private void MenuItem_OpenProject_Clicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".HapProj";
            dlg.Filter = "Haptic Scripter Project (.HapProj)|*.HapProj";

            // Get the selected file name and display in a TextBox

            if (dlg.ShowDialog() == true)
            {
                data.ProjectFilePath = dlg.FileName;

                data.LoadProject(this.OnProjectLoaded);

                //if (realTouchProject != null)
                //{
                //    timelineArrangeCount = 2;
                //    this.closeProject();
                //}
                //else
                //{
                //    timelineArrangeCount = 1;
                //}

                //// Open document
                //realTouchProject = new RealTouchProject();
                //Logger.Log("Loading project: " + dlg.FileName);

                //BusyIndicator.Visibility = Visibility.Visible;
                //Panel.SetZIndex(BusyIndicator, 100);

                //realTouchProject.LoadProject(dlg.FileName, this.loadProject);

                this.ProjectLoadedMenuItems(true);
            }
        }

        private void OnProjectLoaded(Task obj)
        {
            //throw new System.NotImplementedException();
        }


        private void MenuItem_Preferences_Clicked(object sender, RoutedEventArgs e) { }

        private void MenuItem_RipScript_Clicked(object sender, RoutedEventArgs e) { }

        private void MenuItem_Save_Clicked(object sender, RoutedEventArgs e) { }

        private void MenuItem_ShiftAll_Clicked(object sender, RoutedEventArgs e) { }

        #endregion


        private void ProjectLoadedMenuItems(bool switchValue)
        {
            this.CloseProjectMenuItem.IsEnabled = switchValue;
            this.FixErrorsMenuItem.IsEnabled = switchValue;
            this.ShiftAllMenuItem.IsEnabled = switchValue;
            this.ExportScriptedVideioMenuItem.IsEnabled = switchValue;
            this.ExportScriptMenuItem.IsEnabled = switchValue;
            this.SaveMenuItem.IsEnabled = switchValue;
            this.ImportScriptMenuItem.IsEnabled = switchValue;
            this.ImportScriptedVideoMenuItem.IsEnabled = switchValue;

            OpenProjectMenuItem.IsEnabled = !switchValue;
            NewVideoProjectMenuItem.IsEnabled = !switchValue;
            ImportScriptedVideoMenuItem.IsEnabled = !switchValue;
        }
    }
}