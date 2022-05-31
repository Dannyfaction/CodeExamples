using System.IO;
using System.Windows.Forms;

namespace PipelineTools_Dialog.Core
{
    /// <summary>
    /// Class with Windows' Dialog system functionality
    /// </summary>
    public static class DialogManager
    {
        /// <summary>
        /// Opens the Dialog window for selecting a folder
        /// </summary>
        /// <param name="a_Description">The description at the top of the Dialog window</param>
        /// <returns>The selected directory</returns>
        public static string SelectFolder(string a_Description)
        {
            FolderBrowserDialog folderBrowerDialog = new FolderBrowserDialog();
            folderBrowerDialog.Description = a_Description;
            if (folderBrowerDialog.ShowDialog() == DialogResult.OK)
            {
                //done
            }
            return folderBrowerDialog.SelectedPath;
        }

        /// <summary>
        /// Gets all the child directories in a specific folder
        /// </summary>
        /// <param name="a_Path">The specific folder to search in</param>
        /// <returns>The found child directories</returns>
        public static string[] GetDirectoriesInFolder(string a_Path)
        {
            string[] files = Directory.GetDirectories(a_Path);
            return files;
        }

        public static string GetCurrentWorkingDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// Opens the Dialog window for selecting a single file with filters
        /// </summary>
        /// <param name="a_Title">The title at the top of the dialog window</param>
        /// <param name="a_FileTypesFilter">The file type filters</param>
        /// <returns>The selected file</returns>
        public static string SelectFile(string a_Title, string a_FileTypesFilter)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = a_Title;
            openDialog.Filter = a_FileTypesFilter;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                //done
            }
            return openDialog.FileName;
        }

        /// <summary>
        /// Displays a message dialog on-screen with an 'Ok' button
        /// </summary>
        /// <param name="a_Message">The written message inside the dialog</param>
        public static void ShowMessageDialog(string a_Message)
        {
            System.Windows.Forms.MessageBox.Show(a_Message);
        }
    }
}
