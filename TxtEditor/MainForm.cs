using System;
using System.Drawing;
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

            numUDFont.ValueChanged += NumUDFont_ValueChanged;
            butSelectFile.Click += ButSelectFile_Click;
            tBContent.TextChanged += TBContent_TextChanged;
            butSaveFile.Click += ButSaveFile_Click;
            butOpenFile.Click += ButOpenFile_Click;
        }

        private void NumUDFont_ValueChanged(object sender, EventArgs e)
        {
            tBContent.Font = new Font("Calibri", (float)numUDFont.Value);
        }

        private void ButSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tBFilePath.Text = openFileDialog.FileName;
                if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
            }
        }

        #region Event forwarding

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
        #endregion

        #region IMainForm realese

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

        #endregion
    }
}
