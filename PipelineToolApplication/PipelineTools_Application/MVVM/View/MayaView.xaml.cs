using System.Windows;
using System.Windows.Controls;
using PipelineToolApplication.MVVM.ViewModel;
using PipelineTools_Application.Core;
using PipelineTools_Maya.Core;
using PipelineTools_Python.Core;

namespace PipelineToolApplication.MVVM.View
{
    /// <summary>
    /// Interaction logic for MayaView.xaml
    /// </summary>
    public partial class MayaView : UserControl
    {
        public MayaViewModel CurrentModel;

        public MayaView()
        {
            InitializeComponent();
            CurrentModel = Scene.Instance.MayaVM;
            this.DataContext = CurrentModel;
        }

        /// ENVIRONMENT SETTINGS

        /// <summary>
        /// When the button 'Specify Maya Installation' is clicked
        /// </summary>
        /// <param name="sender">An object of the sender</param>
        /// <param name="e">Additional event arguments</param>
        public void ButtonSpecifyMayaInstallation_Click(object sender, RoutedEventArgs e)
        {
            CurrentModel.MayaInstallationDirectory = MayaManager.SpecifyMayaInstallation();
        }

        /// <summary>
        /// When the button 'Select Maya Project File' is clicked
        /// </summary>
        /// <param name="sender">An object of the sender</param>
        /// <param name="e">Additional event arguments</param>
        public void ButtonSelectMayaProjectFile_Click(object sender, RoutedEventArgs e)
        {
            CurrentModel.MayaProjectFile = MayaManager.SelectMayaProjectFile();
        }

        /// VALIDATION
        
        /// <summary>
        /// When the button 'Validate' is clicked
        /// </summary>
        /// <param name="sender">An object of the sender</param>
        /// <param name="e">Additional event arguments</param>
        public void ButtonValidate_Click(object sender, RoutedEventArgs e)
        {
            PythonScriptManager.RunScript(PythonScriptManager.TargetDCC.MAYA, "Validate", CurrentModel.MayaProjectFile);
        }

        /// ACTIONS

        /// <summary>
        /// When the button 'Center Pivot' is clicked
        /// </summary>
        /// <param name="sender">An object of the sender</param>
        /// <param name="e">Additional event arguments</param>
        public void ButtonCenterPivot_Click(object sender, RoutedEventArgs e)
        {
            string fileExtension = System.IO.Path.GetExtension(CurrentModel.MayaProjectFile);
            PythonScriptManager.RunScript(PythonScriptManager.TargetDCC.MAYA, "CenterPivotPoint", CurrentModel.MayaProjectFile + " " + fileExtension);
            MayaManager.MessageDialog("Successfully centered pivot and saved the project");
        }

        /// <summary>
        /// When the button 'Export Project' is clicked
        /// </summary>
        /// <param name="sender">An object of the sender</param>
        /// <param name="e">Additional event arguments</param>
        public void ButtonExportProject_Click(object sender, RoutedEventArgs e)
        {
            string fileName = System.IO.Path.GetFileNameWithoutExtension(CurrentModel.MayaProjectFile);
            PythonScriptManager.RunScript(PythonScriptManager.TargetDCC.MAYA, "ExportProjectToOBJ", CurrentModel.MayaProjectFile + " " + fileName);
            MayaManager.MessageDialog("Successfully exported to /MayaExports/");
        }

    }
}
