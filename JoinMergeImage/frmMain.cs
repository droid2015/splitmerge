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

namespace JoinMergeImage
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text=fbd.SelectedPath;
                
            }
            
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            //Tạo thư mục tmp
            if (!Directory.Exists(txtPath.Text + @"\tmp"))
            {
                Directory.CreateDirectory(txtPath.Text + @"\tmp");
            }
            IEnumerable<string> paths= Directory.EnumerateFiles(txtPath.Text, "*.png");
            
            foreach (string fileName in paths)
            {

            }
        }
    }
}
