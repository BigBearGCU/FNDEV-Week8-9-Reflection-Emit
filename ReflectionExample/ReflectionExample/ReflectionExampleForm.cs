using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Security.Permissions;
using System.Security;
using System.Configuration;

//Creating a Plugin System with C++
//Code samples are all in C++ but some of the background info is good
//http://drdobbs.com/cpp/204202899

//MEF might be a much more robust framework for Late Binding?
//http://blogs.msdn.com/b/gblock/archive/2010/06/03/mef-has-shipped.aspx
//http://mef.codeplex.com/

namespace ReflectionExample
{
    public partial class ReflectionExampleForm : Form
    {
        public ReflectionExampleForm()
        {
            InitializeComponent();
            RunButton.Enabled = false;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RunButton.Enabled = false;

            
            string plugin_path = "plugins";

            PluginComboBox.Items.Clear();

            DirectoryInfo PluginDir = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), plugin_path));
            
            if (!PluginDir.Exists)
                PluginDir.Create();
            FileInfo[] dlls = PluginDir.GetFiles("*.dll");
            foreach (FileInfo dll in dlls)
            {
                try
                {
                    // late binding.  Assembly is load at the runtime.
                    Assembly asm = Assembly.LoadFrom(dll.FullName);

                    PluginComboBox.Items.Add(asm);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
            }

            if (PluginComboBox.Items.Count > 0)
            {
                PluginComboBox.SelectedIndex = 0;
                RunButton.Enabled = true;
            }
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            // remove the IO permission to prevent malicious plugin code!
            FileIOPermission fp = new FileIOPermission(PermissionState.Unrestricted);
            fp.AllFiles = FileIOPermissionAccess.AllAccess;
            fp.Assert();
            //fp.Deny();

            try
            {
                Assembly asm = PluginComboBox.SelectedItem as Assembly;
                Type[] types = asm.GetTypes();

                foreach (Type t in types)
                {
                    if (t.GetInterface("IExamplePlugin") != null)
                    {
                        IExamplePlugin plugin = asm.CreateInstance(t.FullName) as IExamplePlugin;
                        MessageBox.Show(plugin.GenerateLuckyMessage());
                    }
                }

            }
            catch (SecurityException se)
            {
                MessageBox.Show("Security violation!\r\n" + se.ToString());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void ReflectionExampleForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Type t = Type.GetType("System.IO.FileInfo");

                // Try to get the type for PluginA from the PluginA assembly
                // Type t = Type.GetType("PluginA.PluginA");
                 //MessageBox.Show(t.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
