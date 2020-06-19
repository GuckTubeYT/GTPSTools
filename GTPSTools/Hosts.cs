using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace GTPSTools
{
    public partial class Hosts : Form
    {
        public Hosts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string desktop = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(desktop + @"\hosts.txt", false))
            {
                file.WriteLine(textBox1.Text + " growtopia1.com");
                file.WriteLine(textBox1.Text + " growtopia2.com");
                MessageBox.Show("Hosts Has been saved into Desktop", "GTPSControllerCS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
        }
    }
}
