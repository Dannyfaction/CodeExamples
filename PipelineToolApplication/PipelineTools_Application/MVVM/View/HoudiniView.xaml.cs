using System.Windows;
using System.Windows.Controls;
using PipelineTools_Houdini.Core;
using PipelineToolApplication.MVVM.ViewModel;
using System;
using PipelineTools_Application.Core;
using PipelineTools_Python.Core;

namespace PipelineToolApplication.MVVM.View
{
    /// <summary>
    /// Interaction logic for HoudiniView.xaml
    /// </summary>
    public partial class HoudiniView : UserControl
    {
        public HoudiniViewModel CurrentModel;

        public HoudiniView()
        {
            InitializeComponent();
            CurrentModel = Scene.Instance.HoudiniVM;
            this.DataContext = CurrentModel;
        }

        /// <summary>
        /// When the button 'RunPythonScripts' is clicked
        /// </summary>
        /// <param name="sender">An object of the sender</param>
        /// <param name="e">Additional event arguments</param>
        public void ButtonRunPythonScripts_Click(object sender, RoutedEventArgs e)
        {
            PythonScriptManager.RunScript(PythonScriptManager.TargetDCC.HOUDINI, "CubeExport");
        }

        /// <summary>
        /// When the button 'Specify Houdini Installation' is clicked
        /// </summary>
        /// <param name="sender">An object of the sender</param>
        /// <param name="e">Additional event arguments</param>
        public void ButtonSpecifyHoudiniInstallation_Click(object sender, RoutedEventArgs e)
        {
            CurrentModel.HoudiniInstallationDirectory = HoudiniManager.SpecifyHoudiniInstallation();
        }

        /// <summary>
        /// When the button 'Select Houdini Project File' is clicked
        /// </summary>
        /// <param name="sender">An object of the sender</param>
        /// <param name="e">Additional event arguments</param>
        public void ButtonSelectHoudiniProjectFile_Click(object sender, RoutedEventArgs e)
        {
            CurrentModel.HoudiniProjectFile = HoudiniManager.SelectHoudiniProjectFile();
        }
    }
}
