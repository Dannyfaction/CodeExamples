using PipelineTools_Application.Core;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PipelineToolApplication.MVVM.ViewModel
{
    public class HoudiniViewModel : INotifyPropertyChanged
    {
        public HoudiniViewModel()
        {
            m_HoudiniInstallationDirectory = "Specify Houdini installation dir...";
            m_HoudiniProjectFile = "Specify Houdini project file...";
        }

        /// <summary>
        /// Property Changed Event Handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private string m_HoudiniInstallationDirectory;
        public string HoudiniInstallationDirectory { 
            get { return m_HoudiniInstallationDirectory; } 
            set { 
                m_HoudiniInstallationDirectory = value;
                OnPropertyChanged(nameof(HoudiniInstallationDirectory)); //Send out event that the property has changed
            } 
        }

        private string m_HoudiniProjectFile;
        public string HoudiniProjectFile
        {
            get { return m_HoudiniProjectFile; }
            set
            {
                m_HoudiniProjectFile = value;
                OnPropertyChanged(nameof(HoudiniProjectFile)); //Send out event that the property has changed
            }
        }
    }
}