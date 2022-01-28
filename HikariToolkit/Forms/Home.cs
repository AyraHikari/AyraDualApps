using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hikari_Android_Toolkit.Methods;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace Hikari_Android_Toolkit
{
    public partial class MainForm : Form
    {

        public FormMethods formMethods;

        private CmdProcess cmdProcess = new CmdProcess();

        public MainForm()
        {
            InitializeComponent();

            // pass formMethods the created Form this
            formMethods = new FormMethods(this);

            cmdProcess.GetProcess.Start();


            // Begin and cancel so the RichTextBox will stay clean. Otherwise it will start in line 2.
            cmdProcess.GetProcess.BeginOutputReadLine();
            cmdProcess.GetProcess.CancelOutputRead();

            cmdProcess.GetProcess.OutputDataReceived += AppendReceivedData;
            cmdProcess.GetProcess.ErrorDataReceived += AppendReceivedData;

            Thread.Sleep(20);

            cmdProcess.GetProcess.BeginOutputReadLine();
            cmdProcess.GetProcess.BeginErrorReadLine();
            rtb_console.Clear();

            cmdProcess.CommandExecutionStarted += CommandExecutionStarted;
            cmdProcess.ClearConsole += () => { rtb_console.Clear(); };
            

            // Start the watcher which fires if adb devices changed
            AdbDeviceWatcher.DeviceChanged += DwAdb_DeviceChanged;
            AdbDeviceWatcher.StartDeviceWatcher();

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                cmdProcess.StopProcessing();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void CommandExecutionStarted()
        {
            BeginInvoke((MethodInvoker)delegate ()
            {
                if (tsb_AlwaysClearConsole.Checked)
                {
                    rtb_console.Clear();
                }
            });

        }

        private void DwAdb_DeviceChanged(AdbDeviceList e)
        {
            try
            {
                BeginInvoke((MethodInvoker)delegate ()
                {
                    formMethods.RefreshAdbSerialsInCombobox(e.GetDevicesList);
                    txt_DevicesAdb.Text = e.GetDevicesRaw.ToUpper().TrimEnd();
                });
            }
            catch (Exception)
            {

            }
        }

        private void Btn_consoleClear_Click(object sender, EventArgs e)
        {
            rtb_console.Clear();
        }

        private void Btn_consoleStop_Click(object sender, EventArgs e)
        {
            cmdProcess.StopProcessing();
        }

        Color clr = new Color();
        private void AppendReceivedData(object sender, DataReceivedEventArgs e)
        {
            try
            {
                BeginInvoke((MethodInvoker)delegate () { rtb_console.AppendText(e.Data + Environment.NewLine); });
                Thread.Sleep(2);
            }
            catch (Exception)
            { }
        }

        private void Rtb_console_Resize(object sender, EventArgs e)
        {
            rtb_console.ScrollToCaret();
        }
       
        private void Btn_adbRoot_Click(object sender, EventArgs e)
        {
            cmdProcess.StartProcessing("adb root", formMethods.SelectedDevice());
        }
        

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Kill the process
            // todo rename Forms
            try
            {
                //adb.StopProcessing();
                cmdProcess.GetProcess.Kill();
                cmdProcess.GetProcess.Dispose();
            }
            catch (Exception)
            { }
        }

        private void Tsb_OpenShell_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(formMethods.SelectedDevice()))
            {
                string serial = "";

                serial += "-s " + formMethods.SelectedDevice() + " ";

                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "cmd",
                        Arguments = "/K adb " + serial + " shell",
                    }
                };

                process.Start();
            }
            else
            {
                MessageBox.Show("No device connected. Please connect a device for adb commands.", "Error - No Device Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tsm_WirelessConnect_Click(object sender, EventArgs e)
        {
            var r = new Regex(@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}:\d{1,5}$");

            string ipadress = tst_IpAdress.Text;

            if (r.Match(ipadress).Success)
            {
                cmdProcess.StartProcessing("adb connect " + ipadress, "");
            }
            else
            {
                MessageBox.Show("Please enter a valid IP adress", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Tsm_WirelessDisconnect_Click(object sender, EventArgs e)
        {
            cmdProcess.StartProcessing("adb disconnect", "");
        }

        private void Tsb_KillServer_Click(object sender, EventArgs e)
        {
            formMethods.KillServer();
        }

        private void Tsb_RemountSystem_Click(object sender, EventArgs e)
        {
            cmdProcess.StartProcessing("adb remount", formMethods.SelectedDevice());
        }

        private void Tsb_AdbRoot_Click(object sender, EventArgs e)
        {
            cmdProcess.StartProcessing("adb root", formMethods.SelectedDevice());
        }

        private void Tsb_AdbUnroot_Click(object sender, EventArgs e)
        {
            cmdProcess.StartProcessing("adb unroot", formMethods.SelectedDevice());
        }

        private void Tsb_AlwaysClearConsole_Click(object sender, EventArgs e)
        {
            if (tsb_AlwaysClearConsole.Checked = !tsb_AlwaysClearConsole.Checked) ;
        }

        private void tsd_WirelessAdb_Click(object sender, EventArgs e)
        {

        }

        private void btn_DualAppsBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = " .apk|*.apk|.apks|*.apks";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txt_DualAppsPackageInstall.Text = openFileDialog.FileName;
            }
        }

        private string checkDevice()
        {
            clear();
            print("Checking device...");
            string output = cmdProcess.StartProcessingInThread("adb shell pm list packages com.samsung.android.da.daagent", formMethods.SelectedDevice());
            if (!String.IsNullOrEmpty(output))
            {
                string samcek = cmdProcess.StartProcessingInThread("adb shell pm list users", formMethods.SelectedDevice());
                if (String.IsNullOrEmpty(samcek)) { return "0"; }
                foreach (var item in samcek.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    try
                    {
                        var splitter = item.Remove(0, 10).Split(':');
                        if (splitter[1] == "DUAL_APP")
                        {
                            print("Dual apps detected.");
                            return splitter[0];
                        }
                    }
                    catch { }
                }
                print("Error: Your device is compatible, but no dual apps user found!");
                print("Tips: Go to Dual Messenger, and enable anything in there, then you can go use this.");
                return "null";
            }
            string output1 = cmdProcess.StartProcessingInThread("adb shell pm list packages com.samsung.android.da.daagent", formMethods.SelectedDevice());
            if (!String.IsNullOrEmpty(output))
            {
                print("Error: Your device is not compatible to do dual apps!");
                return "null";
            }
            print("Error: Your device is not compatible to do dual apps!");
            return "null";
        }

        private void RefreshInstalledApps()
        {
            cbx_DualAppsPackageUninstall.Items.Clear();

            cbx_DualAppsPackageUninstall.Enabled = false;

            string output = cmdProcess.StartProcessingInThread("adb shell pm list packages -3", formMethods.SelectedDevice());

            if (!String.IsNullOrEmpty(output))
            {
                foreach (var item in output.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    cbx_DualAppsPackageUninstall.Items.Add(item.Remove(0, 8));
                }

                cbx_DualAppsPackageUninstall.Sorted = true;

                if (cbx_DualAppsPackageUninstall.Items.Count > 0)
                {
                    cbx_DualAppsPackageUninstall.SelectedIndex = 0;
                }
            }


            cbx_DualAppsPackageUninstall.Enabled = true;
        }

        private void DualRefreshInstalledApps(string dualUser)
        {

            comboBox1.Items.Clear();

            comboBox1.Enabled = false;

            string output = cmdProcess.StartProcessingInThread("adb shell pm list packages -3 --user " + dualUser, formMethods.SelectedDevice());

            if (!String.IsNullOrEmpty(output))
            {
                foreach (var item in output.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    comboBox1.Items.Add(item.Remove(0, 8));
                }

                comboBox1.Sorted = true;

                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                }
            }


            comboBox1.Enabled = true;
        }

        private void btn_DualAppsInstall_Click(object sender, EventArgs e)
        {
            // Check dual apps compatible
            string DualApps = checkDevice();
            if (DualApps != "null")
            {
                // Funktionen einbauen: starten, stoppen, cache leeren, apk ziehen, aktivieren, deaktivieren
                var s = "\"" + txt_DualAppsPackageInstall.Text + "\"";
                string serial = " -s " + formMethods.SelectedDevice();

                if (txt_DualAppsPackageInstall.Text != "")
                {
                    print("Installing...");
                    cmdProcess.StartProcessing("adb install --user " + DualApps + " " + s, formMethods.SelectedDevice());

                    RefreshInstalledApps();
                }
                else
                {
                    MessageBox.Show("Please select a file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Your device is not compatible to do dual apps!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                print("Error: Your device is not compatible to do dual apps!");
            }
        }

        private void btn_DualAppsRefreshApps_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            RefreshInstalledApps();
            groupBox1.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;
        }

        private void btn_DualAppsUninstall_Click(object sender, EventArgs e)
        {
            // Check dual apps compatible
            string DualApps = checkDevice();
            int counts = 0;

            if (DualApps != "null")
            {
                var s = "\"" + cbx_DualAppsPackageUninstall.SelectedItem + "\"";
                string multiPacks = "";

                string output = cmdProcess.StartProcessingInThread("adb shell pm path " + s, formMethods.SelectedDevice());
                if (!String.IsNullOrEmpty(output))
                {
                    // creating installation session
                    string installSession = cmdProcess.StartProcessingInThread("adb shell pm install-create --user 95", formMethods.SelectedDevice());
                    Debug.WriteLine(installSession);
                    string sesId = installSession.Split('[')[1].Split(']')[0];
                    Debug.WriteLine(sesId);

                    foreach (var item in output.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        counts += 1;
                        var splitter = item.Remove(0, 8);
                        // Copying apks to temp data
                        // If multiple packages detected, pull into PC
                        if (counts >= 1)
                        {
                            string no1 = cmdProcess.StartProcessingInThread("adb shell cp " + splitter + " /data/local/tmp/" + counts + ".apk", formMethods.SelectedDevice());
                            multiPacks += "/data/local/tmp/" + counts + ".apk ";
                            string no2 = cmdProcess.StartProcessingInThread("adb shell pm install-write " + sesId + " " + counts + ".apk /data/local/tmp/" + counts + ".apk", formMethods.SelectedDevice());
                        }
                    }
                    print("Installing packages, please wait...");
                    //cmdProcess.StartProcessing("adb install --user " + DualApps + " " + multiPacks, formMethods.SelectedDevice());
                    string commit = cmdProcess.StartProcessingInThread("adb shell pm install-commit " + sesId, formMethods.SelectedDevice());
                    RefreshInstalledApps();
                    print("Installed!");

                    //string no3 = cmdProcess.StartProcessingInThread("del " + multiPacks, formMethods.SelectedDevice());
                    string no3 = cmdProcess.StartProcessingInThread("adb shell rm " + multiPacks, formMethods.SelectedDevice());
                }
            }
            else
            {
                MessageBox.Show("Your device is not compatible to do dual apps!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                print("Error: Your device is not compatible to do dual apps!");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string dualUser = checkDevice();
            if (dualUser == "null")
            {
                MessageBox.Show("Your device is not compatible to do dual apps!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                print("Error: Your device is not compatible to do dual apps!");
            }
            else
            {

                groupBox1.Enabled = false;
                groupBox3.Enabled = false;
                DualRefreshInstalledApps(dualUser);
                groupBox1.Enabled = true;
                groupBox3.Enabled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string dualUser = checkDevice();
            if (dualUser == "null")
            {
                MessageBox.Show("Your device is not compatible to do dual apps!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                print("Error: Your device is not compatible to do dual apps!");
            }
            else
            {
                var s = "\"" + comboBox1.SelectedItem + "\"";

                print("Uninstalling: " + comboBox1.SelectedItem);
                cmdProcess.StartProcessing("adb uninstall --user " + dualUser + " " + s, formMethods.SelectedDevice());

                RefreshInstalledApps();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }


        public void print(string @text)
        {
            rtb_console.Text += "\n" + text;
        }

        public void clear()
        {
            rtb_console.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/AyraHikari/AyraDualApps");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/AyraHikari/AyraDualApps/releases");
        }
    }
}
