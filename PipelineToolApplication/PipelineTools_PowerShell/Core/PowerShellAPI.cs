using System.Management.Automation;
using System.Diagnostics;

namespace PipelineTools_PowerShell.Core
{
    public static class PowerShellAPI
    {
        //PowerShell
        private static PowerShell m_PowerShell = null;

        /// <summary>
        /// Creates the powershell object
        /// </summary>
        public static void CreatePS()
        {
            if (m_PowerShell != null)
            {
                m_PowerShell.Dispose();
            }
            
            m_PowerShell = PowerShell.Create();
        }

        /// <summary>
        /// Adds a script to the PowerShell object
        /// </summary>
        /// <param name="a_Command">The command to add to the PowerShell object</param>
        public static void AddCommand(string a_Command)
        {
            m_PowerShell.AddScript(a_Command);
        }

        /// <summary>
        /// Executes the PowerShell command
        /// </summary>
        /// <returns>Returns the output of the command</returns>
        public static string Execute()
        {
            Debug.Assert(m_PowerShell != null);

            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> powerShellOuput = m_PowerShell.Invoke();

            string stringOutput = "";

            foreach (PSObject outputItem in powerShellOuput)
            {
                if (outputItem != null)
                {
                    if (stringOutput != "")
                    {
                        stringOutput += " \n";
                    }
                    stringOutput += outputItem.BaseObject.ToString();
                }
            }

            return stringOutput;
        }

        /// <summary>
        /// Frees the PowerShell object and sets it to null
        /// </summary>
        public static void Clear()
        {
            Debug.Assert(m_PowerShell != null);

            m_PowerShell.Dispose();
            m_PowerShell = null;
        }
    }
}
