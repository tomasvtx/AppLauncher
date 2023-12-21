using System;
using System.Collections.Generic;
using System.Text;

namespace AppLauncher
{
    public interface ILauncher
    {
        int LaunchAction(
            string filePath ,
            bool runAsAdministrator , out string error ,
            bool waitForExit = true ,
            string arguments = null ,
            string workingDirectory = null);
    }
    }
