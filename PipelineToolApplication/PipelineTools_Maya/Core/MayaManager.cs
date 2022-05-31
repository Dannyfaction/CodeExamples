using PipelineTools_Dialog.Core;

namespace PipelineTools_Maya.Core
{
    public static class MayaManager
    {
        private static string m_MayaInstallationDir;
        public static string GetMayaInstallationDir()
        {
            return m_MayaInstallationDir;
        }
        private static string m_MayaProjectFile;
        public static string GetMayaProjectFile()
        {
            return m_MayaProjectFile;
        }

        /// <summary>
        /// Functionality for choosing a Maya Installation directory
        /// </summary>
        /// <returns>Returns the selected Maya Installation directory</returns>
        public static string SpecifyMayaInstallation()
        {
            m_MayaInstallationDir = DialogManager.SelectFolder("Specify Autodesk Maya installation directory");
            return m_MayaInstallationDir;
        }

        /// <summary>
        /// Whether the Maya Installation Directory is valid
        /// </summary>
        /// <param name="a_Path">The directory to check</param>
        /// <returns>The state of success</returns>
        public static bool IsValidMayaInstallationDir(string a_Path)
        {
            string[] subDirectories = DialogManager.GetDirectoriesInFolder(a_Path);
            bool hasBinDirectory = false;
            for (int i = 0; i < subDirectories.Length; i++)
            {
                if (subDirectories[i].Contains("\\bin"))
                {
                    hasBinDirectory = true;
                }
            }

            return hasBinDirectory;
        }

        /// <summary>
        /// Functionality for choosing a Maya Project File
        /// </summary>
        /// <returns>Returns the selected Project File</returns>
        public static string SelectMayaProjectFile()
        {
            m_MayaProjectFile = DialogManager.SelectFile("Select Maya project file",
                "Maya Project File (*.ma;*.mb)|*.ma;*.mb");
            return m_MayaProjectFile;
        }

        public static void MessageDialog(string a_Message)
        {
            DialogManager.ShowMessageDialog(a_Message);
        }
    }
}
