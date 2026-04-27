using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows;

namespace cyber_behaviour_profiling_2
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            if (!IsRunningAsAdministrator())
            {
                if (TryRestartElevated(e.Args))
                {
                    Shutdown();
                    return;
                }

                MessageBox.Show(
                    "This tool requires administrator privileges to access kernel-level telemetry.\n\n" +
                    "Please restart the application as Administrator.",
                    "Administrator Required",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                Shutdown();
                return;
            }

            base.OnStartup(e);
        }

        private static bool TryRestartElevated(string[] args)
        {
            try
            {
                string? processPath = Environment.ProcessPath;
                if (string.IsNullOrWhiteSpace(processPath))
                    return false;

                var startInfo = new ProcessStartInfo
                {
                    FileName = processPath,
                    UseShellExecute = true,
                    Verb = "runas",
                    Arguments = BuildArgumentString(args)
                };

                Process.Start(startInfo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static string BuildArgumentString(string[] args)
        {
            if (args == null || args.Length == 0)
                return string.Empty;

            return string.Join(" ", Array.ConvertAll(args, QuoteArgument));
        }

        private static string QuoteArgument(string arg)
        {
            if (string.IsNullOrEmpty(arg))
                return "\"\"";

            return arg.Contains(' ') || arg.Contains('"')
                ? $"\"{arg.Replace("\\", "\\\\").Replace("\"", "\\\"")}\""
                : arg;
        }

        private static bool IsRunningAsAdministrator()
        {
            using var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
