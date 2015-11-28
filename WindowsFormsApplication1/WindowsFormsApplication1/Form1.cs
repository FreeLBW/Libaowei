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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string[] files = GetFiles(ofd.SelectedPath);
            #region MyRegion
            foreach (string file in files)
            {
                FileStream fs = new FileStream(file, FileMode.Open);
                StreamWriter writer = new StreamWriter(fs);
                //Path.GetDirectoryName(ofd.FileName) + "1.avi"
                byte[] buffer = new byte[1024 * 1024*100];
                int offset = 0;
                FileStream fsWrite = new FileStream(@"G:\【传智播客.NET培训第24期_2015最新就业班】\文件txt\" + Path.GetFileName(file), FileMode.Append);

                while ((offset = fs.Read(buffer, 0, 1024 * 1024*100)) > 0)
                {
                    fsWrite.Write(buffer, 0, offset);
                }
                fs.Close();
                fs.Dispose();
                fsWrite.Close();
                fsWrite.Dispose();
            }
                MessageBox.Show("Test");
            
            #endregion
        }
        List<string> list = new List<string>();
        public string[] GetFiles(string filePath)
        {
            
            string[] path= Directory.GetDirectories(filePath);
            string[] files= Directory.GetFiles(filePath, "*.txt");
            list.AddRange(files);
            if (path.Length > 0)
            {
                foreach(string str in path)
                {
                    GetFiles(str);
                }
            }
            return list.ToArray();
        }
    }
}
