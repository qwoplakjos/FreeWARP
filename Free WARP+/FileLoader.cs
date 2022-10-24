using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leaf.xNet;

namespace Free_WARP_
{
    public partial class FileLoader : Form
    {
        public string file = "";
        public ProxyType type = ProxyType.HTTP;

        public FileLoader()
        {
            InitializeComponent();
        }

        private void httploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text File (*.txt)|*.txt|All File (*.*)|*.*";
            openFileDialog.Title = "Open Proxylist";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                file = openFileDialog.FileName;
                type = ProxyType.HTTP;
                Close();
            }
        }

        private void socks4loadbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text File (*.txt)|*.txt|All File (*.*)|*.*";
            openFileDialog.Title = "Open Proxylist";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                file = openFileDialog.FileName;
                type = ProxyType.Socks4; 
                Close();
            }
        }

        private void socks5loadbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text File (*.txt)|*.txt|All File (*.*)|*.*";
            openFileDialog.Title = "Open Proxylist";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                file = openFileDialog.FileName;
                type = ProxyType.Socks5;
                Close();
            }
        }
    }
}
