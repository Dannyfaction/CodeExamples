using PipelineTools_Dialog.Core;

namespace PipelineTools_Houdini.Core
{
    public static class HoudiniManager
    {
        private static string m_HoudiniInstallationDir;
        public static string GetHoudiniInstallationDir()
        {
            return m_HoudiniInstallationDir;
        }
        private static string m_HoudiniProjectFile;
        public static string GetHoudiniProjectFile()
        {
            return m_HoudiniProjectFile;
        }

        /// <summary>
        /// Functionality for choosing a Houdini Installation directory
        /// </summary>
        /// <returns>Returns the selected Houdini Installation directory</returns>
        public static string SpecifyHoudiniInstallation()
        {
            m_HoudiniInstallationDir = DialogManager.SelectFolder("Specify SideFX Houdini installation directory");
            return m_HoudiniInstallationDir;
        }

        /// <summary>
        /// Whether the Houdini Installation Directory is valid
        /// </summary>
        /// <param name="a_Path">The directory to check</param>
        /// <returns>The state of success</returns>
        public static bool IsValidHoudiniInstallationDir(string a_Path)
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
        /// Functionality for choosing a Houdini Project File
        /// </summary>
        /// <returns>Returns the selected Project File</returns>
        public static string SelectHoudiniProjectFile()
        {
            m_HoudiniProjectFile = DialogManager.SelectFile("Select Houdini project file",
                "Houdini Project File (*.hipnc;*.hip)|*.hipnc;*.hip");
            return m_HoudiniProjectFile;
        }
    }
}
