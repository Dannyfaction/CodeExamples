using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PipelineToolApplication.MVVM.ViewModel
{
    public class MayaViewModel : INotifyPropertyChanged
    {
        public MayaViewModel()
        {
            m_MayaInstallationDirectory = "Specify Maya installation dir...";
            m_MayaProjectFile = "Specify Maya project file...";
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

        private string m_MayaInstallationDirectory;
        public string MayaInstallationDirectory
        {
            get { return m_MayaInstallationDirectory; }
            set
            {
                m_MayaInstallationDirectory = value;
                OnPropertyChanged(nameof(MayaInstallationDirectory));
            }
        }

        private string m_MayaProjectFile;
        public string MayaProjectFile
        {
            get { return m_MayaProjectFile; }
            set
            {
                m_MayaProjectFile = value;
                OnPropertyChanged(nameof(MayaProjectFile));
            }
        }
    }
}