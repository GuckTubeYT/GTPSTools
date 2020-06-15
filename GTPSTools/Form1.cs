/*
 * GTPSTools (C) By GuckTube YT
 * This App Allow you to Controlling your server, Set your sever, etc with GTPSTools
 * Dont Change it be yours and Dont Sell this App
 * Because this app is Free Source Code at https://github.com/gucktubeyt/GTPSTools
 * Dont forget to subscribe GuckTube YT
 * For New Video
 * And Dont Forget to Follow And Star My Repository
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace GTPSTools
{
    public partial class Form1 : Form
    {
        public string cuser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public string xampp = @"C:\xampp\htdocs\growtopia";
        public string xampp1 = @"C:\xampp";
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(xampp))
            {
                MessageBox.Show("Please Setting GTPS First", "GTPSControllerCS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string text = File.ReadAllText(xampp + @"\server_data.php");
            text = text.Replace("#maint|", "maint|");
            File.WriteAllText(xampp + @"\server_data.php", text);
            MessageBox.Show("Maintenance Mode Has Been Turned Into On", "GTPSControllerCS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            if (string.IsNullOrWhiteSpace(ip.Text))
            {
               MessageBox.Show("Please Input IP On TextBox", "GTPSControllerCS",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(port.Text))
            {
                MessageBox.Show("Please Input Port On TextBox", "GTPSControllerCS",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            System.IO.Directory.CreateDirectory(cuser + @"\AppData\Local\Temp\gtpstools");
            string toolpath = cuser + @"AppData\Local\Temp\gtpstools";
            if (Directory.Exists(toolpath))
    {
                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(toolpath + "ip.txt", false))
                {
                    file.WriteLine(ip.Text);
                    file.Close();
                }
                using (System.IO.StreamWriter file1 =
            new System.IO.StreamWriter(toolpath + "port.txt", false))
                {
                    file1.WriteLine(port.Text);
                    file1.Close();
                }
            }
            richTextBox1.AppendText("[+] Setting Firewall...\n");
            Process proc = new Process();
            string top = "netsh.exe";
            proc.StartInfo.Arguments = "Advfirewall set privateprofile state off";
            proc.StartInfo.FileName = top;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            proc.WaitForExit();
            Process proc1 = new Process();
            string top1 = "netsh.exe";
            proc1.StartInfo.Arguments = "Advfirewall set publicprofile state off";
            proc1.StartInfo.FileName = top1;
            proc1.StartInfo.UseShellExecute = false;
            proc1.StartInfo.RedirectStandardOutput = true;
            proc1.StartInfo.CreateNoWindow = true;
            proc1.Start();
            proc1.WaitForExit();
            Process proc2 = new Process();
            string top2 = "netsh.exe";
            proc2.StartInfo.Arguments = "firewall add portopening TCP 80 80";
            proc2.StartInfo.FileName = top2;
            proc2.StartInfo.UseShellExecute = false;
            proc2.StartInfo.RedirectStandardOutput = true;
            proc2.StartInfo.CreateNoWindow = true;
            proc2.Start();
            proc2.WaitForExit();
            Process proc3 = new Process();
            string top3 = "netsh.exe";
            proc2.StartInfo.Arguments = "firewall add portopening UDP " + port.Text + " " + port.Text;
            proc2.StartInfo.FileName = top3;
            proc2.StartInfo.UseShellExecute = false;
            proc2.StartInfo.RedirectStandardOutput = true;
            proc2.StartInfo.CreateNoWindow = true;
            proc2.Start();
            proc2.WaitForExit();
            richTextBox1.AppendText("[+] Firewall Has Been Setted!\n");
            if (!Directory.Exists(xampp1))
            {
                richTextBox1.AppendText("[E] Please Install XAMPP first: https://www.apachefriends.org/download.html \n");
                MessageBox.Show("Please Install XAMPP First", "GTPSControllerCS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            richTextBox1.AppendText("[+] XAMPP Founded!\n");
            System.IO.Directory.CreateDirectory(@"C:\xampp\htdocs\growtopia");
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(xampp + @"\server_data.php", false))
            {
                richTextBox1.AppendText("[+] Setting server_data.php\n");
                file.WriteLine("server|" + ip.Text);
                file.WriteLine("port|" + port.Text);
                file.WriteLine("type|1");
                file.WriteLine("#maint|Mainetrance message (Not used for now) -- Growtopia Noobs");
                file.WriteLine("");
                file.WriteLine("beta_server|127.0.0.1");
                file.WriteLine("beta_port|17091");
                file.WriteLine("");
                file.WriteLine("beta_type|1");
                file.WriteLine("meta|localhost");
                file.WriteLine("RTENDMARKERBS1001");
                file.Close();
                richTextBox1.AppendText("[+] server_data.php Has Been Setted!\n");
                richTextBox1.AppendText("[+] All Has Been Setted!\n");
                MessageBox.Show("Your Server Has Been Setted", "GTPSControllerCS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(xampp))
            {
                MessageBox.Show("Please Setting GTPS First", "GTPSControllerCS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string text = File.ReadAllText(xampp + @"\server_data.php");
            text = text.Replace("maint|", "#maint|");
            File.WriteAllText(xampp + @"\server_data.php", text);
            MessageBox.Show("Maintenance Mode Has Been Turned Into Off", "GTPSControllerCS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            editmaintenance show = new editmaintenance();
            show.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!File.Exists("enet.exe"))
            {
                MessageBox.Show("Where's enet.exe? Please Read How To Use This App", "GTPSControllerCS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!File.Exists("loop.bat"))
            {
                using (System.IO.StreamWriter file2 =
            new System.IO.StreamWriter("loop.bat", false))
                {
                    file2.WriteLine("@echo off");
                    file2.WriteLine(":loop");
                    file2.WriteLine("start /w enet.exe");
                    file2.WriteLine("goto loop");
                    file2.Close();
                }
                System.Diagnostics.Process.Start("loop.bat");
                return;
            }
            System.Diagnostics.Process.Start("loop.bat");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("enet.exe"))
            {
                System.Diagnostics.Process.Start("enet.exe");
                return;
            }
            else
            {
                MessageBox.Show("Where's enet.exe? Please Read How To Use This App", "GTPSControllerCS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName("enet"))
            {
                process.Kill();
                MessageBox.Show("enet.exe Has Been Stopped!", "GTPSControllerCS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return;
        }
    }
}
