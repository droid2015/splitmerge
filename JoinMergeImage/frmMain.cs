using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
            string pathTmp = txtPath.Text + @"\tmp";
            if (!Directory.Exists(txtPath.Text + @"\tmp"))
            {
                Directory.CreateDirectory(txtPath.Text + @"\tmp");
            }
            IEnumerable<string> paths= Directory.EnumerateFiles(txtPath.Text, "*.png");
            
            foreach (string fileName in paths)
            {
                ResizeImage(fileName, pathTmp);
            }
        }

        private void ResizeImage(string fileName, string pathTmp)
        {
            string[] name = fileName.Split('\\');
            Rectangle rec=new Rectangle(0, 0, (int)numWidth.Value, (int)numHeight.Value);
            using (Bitmap bm = new Bitmap((int)numWidth.Value, (int)numHeight.Value))
            {
                Graphics gp = Graphics.FromImage(bm);
                using(Image img=Image.FromFile(fileName))
                {
                    bm.SetResolution(img.HorizontalResolution, img.VerticalResolution);
                    gp.DrawImage(img,0,0);
                    bm.MakeTransparent();
                    bm.Save(pathTmp + @"\"+name[name.Length-1], ImageFormat.Png);
                
                }
            }
        }
    }
}
