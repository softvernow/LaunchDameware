using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaunchDameware
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void Open_Dameware()
        {

            String username = txtUserName.Text;
            String password = txtpassword.Text;
            String domain = txtDomain.Text;
            String machine = txtMachineName.Text;

            String dameware_file_exe = Get_Dameware_Exe();

            try
            {

                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                System.Security.SecureString ssPwd = new System.Security.SecureString();
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.FileName = dameware_file_exe;
                proc.StartInfo.Arguments = " -c: -m:" + machine + " -u:" + username + " -p:" + password + " -d:" + domain +"";
                proc.Start();

            }
            catch
            {
                MessageBox.Show("An Error Has Occured!");
            }

        }


        private String Get_Dameware_Exe()
        {
            foreach (string file in Directory.EnumerateFiles(@"c:\program files", "DWRCC.exe", SearchOption.AllDirectories))
            {
                return file;
            }

            foreach (string file in Directory.EnumerateFiles(@"C:\Program Files (x86)", "DWRCC.exe", SearchOption.AllDirectories))
            {
                return file;
            }

            return String.Empty;
        }

        private void btnRDP_Click(object sender, EventArgs e)
        {
            Open_Dameware();
        }
    }
}
