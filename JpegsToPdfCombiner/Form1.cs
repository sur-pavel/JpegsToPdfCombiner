using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JpegsToPdfCombiner
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource tokenSource;        
        public Form1()
        {
            InitializeComponent();

            compressIndex.Increment = 1m / SystemInformation.MouseWheelScrollLines;
            prefixTextBox.MaxLength = 10;
            cancelButton.Enabled = false;

        }

        private void OpenFromDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                PathFrom.Text = FBD.SelectedPath + @"\";
            }
        }
        private void OpenToDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                PathTo.Text = FBD.SelectedPath + @"\";
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            tokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = tokenSource.Token;

            FileHandler fileHandler = new FileHandler(progressBar, createButton, cancelButton,
                fileNameLabel, fileSizeLabel, compressIndex.Value, cancellationToken);
            
                Task.Factory.StartNew(() => fileHandler.CreatePdfFiles(PathFrom.Text, PathTo.Text, prefixTextBox.Text), cancellationToken);
            

            //PdfFunc = new Thread(delegate ()
            //{
            //    fileHandler.CreatePdfFiles(PathFrom.Text, PathTo.Text, prefixTextBox.Text);
            //});
            //PdfFunc.Start();
        }

        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (PdfFunc != null && PdfFunc.IsAlive)
            //{
            //    PdfFunc.Abort();
            //}
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            tokenSource.Cancel();
            tokenSource.Dispose();
        }
    }
}
