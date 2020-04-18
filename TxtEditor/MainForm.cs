using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TxtEditor
{
    public interface IMainForm
    {
        string FilePath { get; }
        string Content { get; set; }
        void SetSymbolCount(int count);
        event EventHandler FileOpenClick;
        event EventHandler FileSaveClick;
        event EventHandler ContentChanged;
    }

    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();

            tBContent.TextChanged += TBContent_TextChanged;
            butSaveFile.Click += ButSaveFile_Click;
            butOpenFile.Click += ButOpenFile_Click;
        }

        private void TBContent_TextChanged(object sender, EventArgs e)
        {
            if(ContentChanged != null)
            {
                ContentChanged(this, EventArgs.Empty);
            }
        }

        private void ButSaveFile_Click(object sender, EventArgs e)
        {
            if(FileSaveClick != null)
            {
                FileSaveClick(this, EventArgs.Empty);
            }
        }

        private void ButOpenFile_Click(object sender, EventArgs e)
        {
            if(FileOpenClick!= null)
            {
                FileOpenClick(this, EventArgs.Empty);
            }
        }

        public string FilePath
        {
            get { return tBFilePath.Text; }
        }

        public string Content
        {
            get { return tBContent.Text; }
            set { tBContent.Text = value; }
        }

        public void SetSymbolCount(int count)
        {
            lblSybolCount.Text = count.ToString();
        }

        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;
        public event EventHandler ContentChanged;

    }
}
