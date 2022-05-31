using PipelineToolApplication.MVVM.ViewModel;

namespace PipelineTools_Application.Core
{
    /// <summary>
    /// Singleton class with a collection of instances of different ViewModels
    /// </summary>
    public sealed class Scene
    {
        private static Scene m_Instance = null;
        private static readonly object m_Padlock = new object();

        private Scene() 
        {
            HoudiniVM = new HoudiniViewModel();
            MayaVM = new MayaViewModel();
        }

        public static Scene Instance
        {
            get
            {
                lock (m_Padlock)
                {
                    if (m_Instance == null)
                    {
                        m_Instance = new Scene();
                    }
                    return m_Instance;
                }
            }
        }

        public HoudiniViewModel HoudiniVM { get; set; }
        public MayaViewModel MayaVM { get; set; }

    }
}
