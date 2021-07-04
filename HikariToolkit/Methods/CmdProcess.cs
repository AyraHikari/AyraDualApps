﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Hikari_Android_Toolkit.Methods;

namespace Hikari_Android_Toolkit
{
    public class CmdProcess
    {
        // Thanks to Vitaliy Fedorchenko
        internal const int CTRL_C_EVENT = 0;
        [DllImport("kernel32.dll")]
        internal static extern bool GenerateConsoleCtrlEvent(uint dwCtrlEvent, uint dwProcessGroupId);
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool AttachConsole(uint dwProcessId);
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        internal static extern bool FreeConsole();
        [DllImport("kernel32.dll")]
        static extern bool SetConsoleCtrlHandler(ConsoleCtrlDelegate HandlerRoutine, bool Add);
        // Delegate type to be used as the Handler Routine for SCCH
        delegate Boolean ConsoleCtrlDelegate(uint CtrlType);

        public event CommandExecutionStartedHandler CommandExecutionStarted;
        public delegate void CommandExecutionStartedHandler();

        public event CommandExecutionStoppedHandler CommandExecutionStopped;
        public delegate void CommandExecutionStoppedHandler();

        Process process = new Process
        {

            StartInfo = new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = "/K set prompt=I$G$S",
                UseShellExecute = false,
                CreateNoWindow = true,
                ErrorDialog = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                StandardOutputEncoding = System.Text.Encoding.GetEncoding(437),
                StandardErrorEncoding = System.Text.Encoding.GetEncoding(437)
            }
        };

        public CmdProcess()
        {
            process.EnableRaisingEvents = true;
        }

        public Process GetProcess
        {
            get { return process; }
        }

        public event ClearConsoleHandler ClearConsole;
        public delegate void ClearConsoleHandler();
        public void StartProcessing(string @command, string @serialnumber)
        {
            if (command.StartsWith("adb"))
            {
                if (AdbDeviceWatcher.GetConnectedAdbDevices() > 0 || command.EndsWith("help") || command.EndsWith("version") || command.StartsWith("adb connect") || command.StartsWith("adb disconnect"))
                {
                    StopProcessing();
                    Thread.Sleep(50);
                    CommandExecutionStarted?.Invoke();
                    process.StandardInput.WriteLine(CommandParser(command, serialnumber));
                }
                else
                {
                    MessageBox.Show("No device connected. Please connect a device for adb commands.", "Error - No Device Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (command.StartsWith("cls"))
            {
                ClearConsole?.Invoke();
            }

            else
            {
                StopProcessing();
                Thread.Sleep(50);
                CommandExecutionStarted?.Invoke();
                process.StandardInput.WriteLine(CommandParser(command, serialnumber));
            }

        }

        public bool StopProcessing()
        {
            if (AttachConsole((uint)GetProcess.Id))
            {
                SetConsoleCtrlHandler(null, true);
                try
                {
                    if (!GenerateConsoleCtrlEvent(CTRL_C_EVENT, 0))
                    {
                        return false;
                    }

                }
                finally
                {
                    FreeConsole();
                    CommandExecutionStopped?.Invoke();
                }
                return true;
            }

            return false;
        }

        public string StartProcessingInThread(string @command, string @serialnumber)
        {
            if (command.StartsWith("adb"))
            {
                if (AdbDeviceWatcher.GetConnectedAdbDevices() > 0 || command.EndsWith("help") || command.EndsWith("version") || command.StartsWith("adb connect") || command.StartsWith("adb disconnect"))
                {
                    string output = "";

                    Thread t = new Thread(() => { output = StartProcessingReadToEnd(command, serialnumber); })
                    {
                        IsBackground = true
                    };

                    t.Start();

                    while (t.IsAlive)
                    {
                        Application.DoEvents();
                    }

                    return output;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                string output = "";

                Thread t = new Thread(() => { output = StartProcessingReadToEnd(command, serialnumber); })
                {
                    IsBackground = true
                };

                t.Start();

                while (t.IsAlive)
                {
                    Application.DoEvents();
                }

                return output;
            }
        }

        private string StartProcessingReadToEnd(string command, string serialnumber)
        {

            Process process2 = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd",
                    Arguments = "/C " + CommandParser(command, serialnumber),
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                }
            };

            process2.Start();

            return process2.StandardOutput.ReadToEnd();
        }

        private string CommandParser(string @command, string @serialnumber)
        {
            if (command.StartsWith("adb "))
            {
                command = command.Remove(0, 4);

                if (command.StartsWith("shell") || command.StartsWith("shell screencap"))
                {
                    command = command.Remove(0, 5);
                    command = "exec-out" + command;
                }
                if (command.StartsWith("logcat"))
                {
                    command = "exec-out " + command;
                }

                string serial = "";

                if (!string.IsNullOrEmpty(serialnumber))
                {
                    serial += "-s " + serialnumber + " ";
                }
                else
                {
                    serial = "";
                }

                string fullcommand = "adb " + serial + command;

                return fullcommand;

            }
            else if (command.StartsWith("fastboot "))
            {
                command = command.Remove(0, 9);

                string fullcommand = "fastboot " + command;

                return fullcommand;
            }
            else
            {
                return command;
            }

        }

    }

    public static class CheckAndDownloadDependencies
    {
        private static string downloadToTempPath = Path.GetTempPath() + "platform-tools-latest-windows.zip";

        private static string[] strFiles = { "adb.exe", "AdbWinApi.dll", "AdbWinUsbApi.dll", "fastboot.exe", "libwinpthread-1.dll" };

        public static void Start()
        {
            if (!EnvironmentVariableExists())
            {
                if (!CheckIfFilesExist())
                {
                    DialogResult dialogResult = MessageBox.Show("Enviroment Variables not set and files missing. \nShould all dependencies be downloaded and extracted?", "Error: Missing Files", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                    if (dialogResult == DialogResult.Yes)
                    {
                        DownloadFiles();
                    }

                    else if (dialogResult == DialogResult.No)
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }

        public static bool EnvironmentVariableExists()
        {
            string adb = Environment.ExpandEnvironmentVariables("adb.exe");

            string fastboot = Environment.ExpandEnvironmentVariables("fastboot.exe");



            string pathsUsr = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User);

            string[] pathsUsrArr = pathsUsr.Split(new char[1] { Path.PathSeparator });

            if (Path.GetDirectoryName(adb) == String.Empty)
            {
                foreach (string item in pathsUsrArr)
                {
                    string path = item.Trim();

                    if (File.Exists(Path.Combine(path, adb)) && File.Exists(Path.Combine(path, fastboot)))
                    {
                        return true;
                    }

                }

            }


            string pathsSys = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);

            string[] pathsSysArr = pathsSys.Split(new char[1] { Path.PathSeparator });

            if (Path.GetDirectoryName(adb) == String.Empty)
            {
                foreach (string item in pathsSysArr)
                {
                    string path = item.Trim();

                    if (File.Exists(Path.Combine(path, adb)) && File.Exists(Path.Combine(path, fastboot)))
                    {
                        return true;
                    }

                }

            }

            return false;

        }

        private static bool CheckIfFilesExist()
        {
            foreach (var item in strFiles)
            {
                if (!File.Exists(item))
                {
                    return false;
                }
            }
            return true;
        }

        private static void DownloadFiles()
        {
            ExtractionCompleted += DependenciesChecker_ExtractionCompleted;
            WebClient wc = new WebClient();
            wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
            wc.DownloadFileTaskAsync(new Uri("https://dl.google.com/android/repository/platform-tools-latest-windows.zip"), downloadToTempPath);
        }

        private static void Wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Thread tr = new Thread(new ThreadStart(ExtractFiles));
            tr.Start();
        }

        private static event ExtractionCompletedHandler ExtractionCompleted;

        private delegate void ExtractionCompletedHandler();

        private static void ExtractFiles()
        {
            if (Directory.Exists(Path.GetTempPath() + "platform-tools"))
            {
                Directory.Delete(Path.GetTempPath() + "platform-tools", true);
            }

            ZipFile.ExtractToDirectory(downloadToTempPath, Path.GetTempPath());

            ExtractionCompleted();
        }

        private static void DependenciesChecker_ExtractionCompleted()
        {
            string extractedFilesPath = Path.GetTempPath() + "platform-tools";


            foreach (var item in strFiles)
            {
                try
                {
                    File.Copy(extractedFilesPath + "\\" + item, item);
                }
                catch (Exception) { }

            }

            ExtractionCompleted -= DependenciesChecker_ExtractionCompleted;

            MessageBox.Show("Files downloaded, decompressed and moved successfully", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

    }

}
