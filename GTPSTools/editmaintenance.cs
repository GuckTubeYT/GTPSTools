/*
 * This is Edit Maintenance Text
 * This is for change maintenance text
 * You can Design It As you can
 * But Please, Dont Change it be yours xD
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

namespace GTPSTools
{
    public partial class editmaintenance : Form
    {
        public string cuser1 = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public string xampp = @"C:\xampp\htdocs\growtopia";
        public string xampp1 = @"C:\xampp";
        public editmaintenance()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string toolpath = cuser1 + @"AppData\Local\Temp\gtpstools";
            if (!Directory.Exists(xampp))
            {
                MessageBox.Show("Please Setting GTPS First", "GTPSControllerCS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            using (System.IO.StreamWriter file1 =
               new System.IO.StreamWriter(toolpath + @"\maintext.txt", false))
            {
                file1.Write(textBox1.Text);
                file1.Close();
            }
            if (Directory.Exists(toolpath))
            {
                System.IO.Directory.CreateDirectory(@"C:\xampp\htdocs\growtopia");
                string ip = File.ReadAllText(toolpath + "ip.txt");
                string port = File.ReadAllText(toolpath + "port.txt");
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(xampp + @"\server_data.php", false))
                {
                    file.Write("server|" + ip);
                    file.Write("port|" + port);
                    file.WriteLine("type|1");
                    file.WriteLine("maint|" + textBox1.Text);
                    file.WriteLine("");
                    file.WriteLine("beta_server|127.0.0.1");
                    file.WriteLine("beta_port|17091");
                    file.WriteLine("");
                    file.WriteLine("beta_type|1");
                    file.WriteLine("meta|localhost");
                    file.WriteLine("RTENDMARKERBS1001");
                    file.Close();
                    using (System.IO.StreamWriter file1 =
                new System.IO.StreamWriter(toolpath + "maintext.txt", false))
                    {
                        file1.Write(textBox1.Text);
                        file1.Close();
                    }
                    MessageBox.Show("Maintenance Mode Has Been Turned Into On", "GTPSControllerCS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }
            }
            else
            {
                string text = File.ReadAllText(xampp + @"\server_data.php");
                string text1 = File.ReadAllText(toolpath + "maintext.txt");
                text = text.Replace("#maint|Mainetrance message (Not used for now) -- Growtopia Noobs", "maint|" + textBox1.Text);
                File.WriteAllText(xampp + @"\server_data.php", text);
                text1 = text.Replace("maint|" + text1, "maint|" + textBox1.Text);
                File.WriteAllText(xampp + @"\server_data.php", text);
                MessageBox.Show("Maintenance Mode Has Been Turned Into On", "GTPSControllerCS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            int A = rand.Next(0, 255);
            int R = rand.Next(0, 255);
            int G = rand.Next(0, 255);
            int B = rand.Next(0, 255); label1.ForeColor = Color.FromArgb(A, R, G, B);
        }
    }
}
