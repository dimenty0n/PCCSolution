using System;
using System.Windows.Forms;
using System.Collections.Generic;
using ProcessLib;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Win32;


namespace ProtectedConfigCreator
{
    public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string ddd = Class1.TestMethod3("aaa");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            DBaseSettings dBaseSettings = new DBaseSettings();
            dBaseSettings.fileMode = dBaseFileMode.Checked;
            dBaseSettings.dir = dBaseDir.Text;
            dBaseSettings.serverName = dBaseServerName.Text;
            dBaseSettings.name = dBaseName.Text;
            dBaseSettings.userName = dBaseUserName.Text;
            dBaseSettings.userPass = dBaseUserPass.Text;

            DBaseSettings dBaseProtectedSettings = new DBaseSettings();
            dBaseProtectedSettings.fileMode = dBaseProtectedFileMode.Checked;
            dBaseProtectedSettings.dir = dBaseProtectedDir.Text;
            dBaseProtectedSettings.serverName = dBaseProtectedServerName.Text;
            dBaseProtectedSettings.name = dBaseProtectedName.Text;
            dBaseProtectedSettings.userName = dBaseProtectedUserName.Text;
            dBaseProtectedSettings.userPass = dBaseProtectedUserPass.Text;

            string ddd = Class1.TestMethod4(dBaseSettings,
                dBaseProtectedSettings,
                enterprisePath.Text,
                cfFileDir.Text,
                keySeries.Text,
                epfSrcDir.Text, 
                v8UnpackPath.Text, 
                epfFileDir.Text, 
                moduleNames.Lines, 
                licenceEditDir.Text);

            MessageBox.Show("Обработка завершена!");
        }

        private void SelectEnterprisePath_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "1cv8(1cv8.exe)|1cv8.exe";

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            enterprisePath.Text = openFileDialog1.FileName;
        }

        private void SelectDBaseDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            dBaseDir.Text = folderBrowserDialog1.SelectedPath;
        }

        private void SelectCfFileDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            cfFileDir.Text = folderBrowserDialog1.SelectedPath;
        }

        private void SelectEpfSrcDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            epfSrcDir.Text = folderBrowserDialog1.SelectedPath;
        }

        private void SelectV8UnpackPath_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "V8Unpack(V8Unpack.exe)|V8Unpack.exe";

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            v8UnpackPath.Text = openFileDialog1.FileName;
        }

        private void SelectEpfFileDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            epfFileDir.Text = folderBrowserDialog1.SelectedPath;
        }

        private void SelectLicenceEditDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            licenceEditDir.Text = folderBrowserDialog1.SelectedPath;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SortedList<string, string> enterprisePathList = new SortedList<string, string>();
            string displayName;
            RegistryKey key;

            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string; //+
                //    subkey.GetValue("InstallLocation") as string;
                //DisplayIcon

                if (displayName != null && displayName.IndexOf("1C:Предприятие", 0) >= 0)
                {
                //    //EnterprisePathList enterprisePath = new EnterprisePathList();
                //    //enterprisePath.path = subkey.GetValue("InstallLocation") as string;
                //    //enterprisePath.version = subkey.GetValue("DisplayVersion") as string;
                    enterprisePathList.Add(subkey.GetValue("DisplayVersion") as string, subkey.GetValue("InstallLocation") as string);
                }
            }

            XmlSerializer formatter = new XmlSerializer(typeof(DBaseSettings));
                
            DBaseSettings dBaseSettings = new DBaseSettings();

            using (StringReader reader = new StringReader(ProtectedConfigCreator.Properties.SavedSettings.Default.DBaseSettings))
            {
                dBaseSettings = (DBaseSettings)formatter.Deserialize(reader);
            }

            dBaseFileMode.Checked = dBaseSettings.fileMode;
            dBaseDir.Text = dBaseSettings.dir;
            dBaseServerName.Text = dBaseSettings.serverName;
            dBaseName.Text = dBaseSettings.name;
            dBaseUserName.Text = dBaseSettings.userName;
            dBaseUserPass.Text = dBaseSettings.userPass;

            DBaseSettings dBaseProtectedSettings = new DBaseSettings();

            using (StringReader reader = new StringReader(Properties.SavedSettings.Default.DBaseProtectedSettings))
            {
                dBaseProtectedSettings = (DBaseSettings)formatter.Deserialize(reader);
            }

            dBaseProtectedFileMode.Checked = dBaseProtectedSettings.fileMode;
            dBaseProtectedDir.Text = dBaseProtectedSettings.dir;
            dBaseProtectedServerName.Text = dBaseProtectedSettings.serverName;
            dBaseProtectedName.Text = dBaseProtectedSettings.name;
            dBaseProtectedUserName.Text = dBaseProtectedSettings.userName;
            dBaseProtectedUserPass.Text = dBaseProtectedSettings.userPass;

            enterprisePath.Text = Properties.SavedSettings.Default.EnterprisePath;
            cfFileDir.Text = Properties.SavedSettings.Default.CfFileDir;
            keySeries.Text = Properties.SavedSettings.Default.KeySeries;
            epfFileDir.Text = Properties.SavedSettings.Default.EpfFileDir;
            moduleNames.Text = Properties.SavedSettings.Default.ModuleNames;
            licenceEditDir.Text = Properties.SavedSettings.Default.LicenceEditDir;

            if (Properties.SavedSettings.Default.EpfSrcDir == "")
            {
                epfSrcDir.Text = Application.StartupPath + "\\EPF_SRC";
            }
            else
            {
                epfSrcDir.Text = Properties.SavedSettings.Default.EpfSrcDir;
            }

            if (Properties.SavedSettings.Default.V8UnpackPath == "")
            {
                v8UnpackPath.Text = Application.StartupPath + "\\V8Unpack20\\V8Unpack20\\bin\\V8Unpack.exe";
            }
            else
            {
                v8UnpackPath.Text = Properties.SavedSettings.Default.V8UnpackPath;
            }
            //var path = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            //enterprisePath.Text = Application.StartupPath;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(DBaseSettings));

            DBaseSettings dBaseSettings = new DBaseSettings();
            dBaseSettings.fileMode = dBaseFileMode.Checked;
            dBaseSettings.dir = dBaseDir.Text;
            dBaseSettings.serverName = dBaseServerName.Text;
            dBaseSettings.name = dBaseName.Text;
            dBaseSettings.userName = dBaseUserName.Text;
            dBaseSettings.userPass = dBaseUserPass.Text;
           
            using (StringWriter writer = new StringWriter())
            {
                formatter.Serialize(writer, dBaseSettings);
                Properties.SavedSettings.Default.DBaseSettings = writer.ToString();
            }

            DBaseSettings dBaseProtectedSettings = new DBaseSettings();
            dBaseProtectedSettings.fileMode = dBaseProtectedFileMode.Checked;
            dBaseProtectedSettings.dir = dBaseProtectedDir.Text;
            dBaseProtectedSettings.serverName = dBaseProtectedServerName.Text;
            dBaseProtectedSettings.name = dBaseProtectedName.Text;
            dBaseProtectedSettings.userName = dBaseProtectedUserName.Text;
            dBaseProtectedSettings.userPass = dBaseProtectedUserPass.Text;

            using (StringWriter writer = new StringWriter())
            {
                formatter.Serialize(writer, dBaseProtectedSettings);
                Properties.SavedSettings.Default.DBaseProtectedSettings = writer.ToString();
            }

            Properties.SavedSettings.Default.EnterprisePath = enterprisePath.Text;
            Properties.SavedSettings.Default.CfFileDir = cfFileDir.Text;
            Properties.SavedSettings.Default.KeySeries = keySeries.Text;
            Properties.SavedSettings.Default.EpfSrcDir = epfSrcDir.Text;
            Properties.SavedSettings.Default.V8UnpackPath = v8UnpackPath.Text;
            Properties.SavedSettings.Default.EpfFileDir = epfFileDir.Text;
            Properties.SavedSettings.Default.ModuleNames = moduleNames.Text;
            Properties.SavedSettings.Default.LicenceEditDir = licenceEditDir.Text;

            Properties.SavedSettings.Default.Save();
        }

        private void DBaseFileMode_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox fileMode = (CheckBox)sender;
            if (fileMode.Checked == true)
            {
                labelDBaseServerName.Enabled = false;
                labelDBaseName.Enabled = false;
                dBaseServerName.Enabled = false;
                dBaseName.Enabled = false;
                dBaseServerName.Text = "";
                dBaseName.Text = "";

                labelDBaseDir.Enabled = true;
                dBaseDir.Enabled = true;
                selectDBaseDir.Enabled = true;

            }
            if (fileMode.Checked == false)
            {
                labelDBaseServerName.Enabled = true;
                labelDBaseName.Enabled = true;
                dBaseServerName.Enabled = true;
                dBaseName.Enabled = true;

                labelDBaseDir.Enabled = false;
                dBaseDir.Enabled = false;
                selectDBaseDir.Enabled = false;
                dBaseDir.Text = "";

            }

        }

        private void SelectProtectedDBaseDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            dBaseProtectedDir.Text = folderBrowserDialog1.SelectedPath;
        }

        private void DBaseProtectedFileMode_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox fileMode = (CheckBox)sender;
            if (fileMode.Checked == true)
            {
                labelDBaseProtectedServerName.Enabled = false;
                labelDBaseProtectedName.Enabled = false;
                dBaseProtectedServerName.Enabled = false;
                dBaseProtectedName.Enabled = false;
                dBaseProtectedServerName.Text = "";
                dBaseProtectedName.Text = "";

                labelDBaseProtectedDir.Enabled = true;
                dBaseProtectedDir.Enabled = true;
                selectProtectedDBaseDir.Enabled = true;

            }
            if (fileMode.Checked == false)
            {
                labelDBaseProtectedServerName.Enabled = true;
                labelDBaseProtectedName.Enabled = true;
                dBaseProtectedServerName.Enabled = true;
                dBaseProtectedName.Enabled = true;

                labelDBaseProtectedDir.Enabled = false;
                dBaseProtectedDir.Enabled = false;
                selectProtectedDBaseDir.Enabled = false;
                dBaseProtectedDir.Text = "";

            }

        }

        private void labelEpfSrcDir_Click(object sender, EventArgs e)
        {

        }

        private void dBaseServerName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
