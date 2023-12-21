using System;
using System.Diagnostics;
using System.IO;

namespace AppLauncher
    {
        public class AppLauncher : ILauncher
        {
            public int LaunchAction(
                string filePath ,
                bool runAsAdministrator ,out string error,
                bool waitForExit = true ,
                string arguments = null ,
                string workingDirectory = null)
            {
                error = String.Empty;

            if (!File.Exists(filePath))
                {
                    error = "Application not found.";
                    return -1; // Indicate an error with a negative exit code
                }

                var exitCode = -1; // Default exit code for failure

                    var installerProcess = new Process()
                    {
                        StartInfo = new ProcessStartInfo(filePath)
                        {
                            UseShellExecute = true,
                            Verb = runAsAdministrator ? "runas" : "",
                            Arguments = arguments,
                            WorkingDirectory = workingDirectory
                        }
                    };

                    try
                    {
                        installerProcess.Start( );

                        if (waitForExit)
                        {
                            installerProcess.WaitForExit( );
                            exitCode = installerProcess.ExitCode; // Retrieve the exit code
                        }
                    }
                    catch (Exception ex)
                    {
                        error = $"Error running application: {ex.Message}";
                    }

                return exitCode;
            }
        }
    }
