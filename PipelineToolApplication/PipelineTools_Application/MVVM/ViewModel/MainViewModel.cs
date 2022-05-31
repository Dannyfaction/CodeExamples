using PipelineTools_Application.Core;

namespace PipelineToolApplication.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public Scene m_Scene { get; set; }
        public RelayCommand HoudiniViewCommand { get; set; }
        public RelayCommand MayaViewCommand { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            m_Scene = Scene.Instance;

            CurrentView = m_Scene.HoudiniVM;

            HoudiniViewCommand = new RelayCommand(o => 
            {
                CurrentView = m_Scene.HoudiniVM;
            });
            
            MayaViewCommand = new RelayCommand(o =>
             {
                 CurrentView = m_Scene.MayaVM;
             });
        }
    }
}