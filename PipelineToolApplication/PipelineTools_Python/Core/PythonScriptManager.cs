using PipelineTools_Dialog.Core;
using PipelineTools_PowerShell.Core;
using PipelineTools_Houdini.Core;
using PipelineTools_Maya.Core;

namespace PipelineTools_Python.Core
{
    public static class PythonScriptManager
    {
        const string m_PythonScriptsSubDir = "\\PythonScripts\\";
        const string m_HoudiniCategoryDir = "Houdini\\";
        const string m_MayaCategoryDir = "Maya\\";

        public enum TargetDCC
        {
            HOUDINI = 0,
            MAYA = 1
        }

        /// <summary>
        /// Runs a python script on specific DCC software
        /// </summary>
        /// <param name="a_TargetDCC">The target DCC software</param>
        /// <param name="a_ScriptName">The name of the script that is placed in /PythonScripts/</param>
        /// <param name="a_Arguments">Additional arguments to send with the python script</param>
        public static void RunScript(TargetDCC a_TargetDCC, string a_ScriptName, string a_Arguments="")
        {
            PowerShellAPI.CreatePS();

            switch (a_TargetDCC)
            {
                case TargetDCC.HOUDINI:
                    if (HoudiniManager.GetHoudiniInstallationDir() == null)
                    {
                        DialogManager.ShowMessageDialog("Houdini installation has not been specified yet");
                        return;
                    }
                    else
                    {
                        if (!HoudiniManager.IsValidHoudiniInstallationDir(HoudiniManager.GetHoudiniInstallationDir()))
                        {
                            DialogManager.ShowMessageDialog("The specified Houdini installation directory is invalid");
                            return;
                        }

                        PowerShellAPI.AddCommand("cd " + HoudiniManager.GetHoudiniInstallationDir() + "\\bin");
                        PowerShellAPI.AddCommand("./Hython " + DialogManager.GetCurrentWorkingDirectory() + m_PythonScriptsSubDir + m_HoudiniCategoryDir + a_ScriptName + ".py");
                        string fullDir = "./Hython " + DialogManager.GetCurrentWorkingDirectory() + m_PythonScriptsSubDir + m_HoudiniCategoryDir + a_ScriptName + ".py";
                    }
                    break;
                case TargetDCC.MAYA:
                    if (MayaManager.GetMayaInstallationDir() == null)
                    {
                        DialogManager.ShowMessageDialog("Maya installation has not been specified yet");
                        return;
                    }
                    else
                    {
                        if (!MayaManager.IsValidMayaInstallationDir(MayaManager.GetMayaInstallationDir()))
                        {
                            DialogManager.ShowMessageDialog("The specified Maya installation directory is invalid");
                            return;
                        }

                        PowerShellAPI.AddCommand("cd " + '"' + MayaManager.GetMayaInstallationDir() + "\\bin" + '"');
                        PowerShellAPI.AddCommand("./mayapy " + DialogManager.GetCurrentWorkingDirectory() + m_PythonScriptsSubDir + m_MayaCategoryDir + a_ScriptName + ".py" + " " + a_Arguments);
                    }
                    break;
                default:
                    DialogManager.ShowMessageDialog("No target DCC specified.");
                    break;
            }

            string commandOuput = PowerShellAPI.Execute();
            DialogManager.ShowMessageDialog(commandOuput);

            PowerShellAPI.Clear();
        }
    }
}
