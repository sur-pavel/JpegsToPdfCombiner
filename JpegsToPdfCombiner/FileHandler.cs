using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Drawing.Imaging;
using System;
using System.Threading;

namespace JpegsToPdfCombiner
{
    class FileHandler
    {
        private ProgressBar progressBar;
        private Button createButton;
        private Button cancelButton;
        private Label fileNameLabel;
        private Label fileSizeLabel;
        private decimal compressIndex;
        private CancellationToken cancellationToken;
        private bool error = false;
        private string errorMsg = "";

        public FileHandler(ProgressBar progressBar, Button createButton, Button cancelButton,
            Label fileNameLabel, Label fileSizeLabel, decimal compressIndex, CancellationToken cancellationToken)
        {
            this.progressBar = progressBar;
            this.createButton = createButton;
            this.cancelButton = cancelButton;
            this.fileNameLabel = fileNameLabel;
            this.fileSizeLabel = fileSizeLabel;
            this.compressIndex = compressIndex;
            this.cancellationToken = cancellationToken;
        }


        internal void CreatePdfFiles(string pathFrom, string pathTo, string namePrefix)
        {
            try
            {
               
                if (CheckPathes(pathFrom, pathTo) == false)
                {
                    cancelButton.Invoke(new Action(() => cancelButton.Enabled = true));
                    var dirNames = Directory.GetDirectories(pathFrom);
                    int dirInc = 0;

                    if (dirNames.Length != 0)
                    {
                        foreach (string dirName in dirNames)
                        {
                            dirInc = CombineJpegs(pathTo, namePrefix, dirInc, dirName + @"\");

                            if (cancellationToken.IsCancellationRequested)
                            {
                                cancelTask(dirName);
                                break;
                            }
                        }
                    }
                    else
                    {
                        CombineJpegs(pathTo, namePrefix, dirInc, pathFrom);
                    }
                }
            }
            catch (Exception ex)
            {                
                error = true;
                errorMsg = ex.Message;
            }
            if (error)
                MessageBox.Show(errorMsg + "\n\nПодробности смотрите в файле\nJpegsToPdfCombiner_log.txt", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Готово", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetControls();
        }

        private bool CheckPathes(string pathFrom, string pathTo)
        {
            bool cancel = false;
            try
            {                
                Path.IsPathRooted(pathFrom);
                Path.IsPathRooted(pathTo);
            }
            catch (Exception ex)
            {
                cancel = true;
                error = true;
                errorMsg = ex.Message;
            }
            return cancel;
        }
        private void cancelTask(string dirName)
        {
            error = true;
            errorMsg = "Задача была прервана";
            new LogWriter("Задача по созданию pdf из папки " + dirName + " была прервана.");
            ResetControls();
        }

        private int CombineJpegs(string pathTo, string namePrefix, int dirInc, string dirName)
        {
            dirInc++;
            PdfDocument pdfDoc = new PdfDocument();
            try
            {
                createButton.Invoke(new Action(() => createButton.Enabled = false));

                var jpegFiles = Directory.EnumerateFiles(dirName, "*.*", SearchOption.TopDirectoryOnly)
                    .Where(s => s.EndsWith(".jpeg") || s.EndsWith(".jpg") || s.EndsWith(".JPG") || s.EndsWith(".JPEG"));

                int filesNumber = jpegFiles.Count();
                int jpegInc = 0;
                if (filesNumber > 0)
                {
                    string fileName = GetFileName(dirName, namePrefix, dirInc) + ".pdf";
                    fileNameLabel.Invoke(new Action(() => fileNameLabel.Text = fileName));
                    foreach (string jpegFile in jpegFiles)
                    {
                        jpegInc = AddJpegToPdf(pathTo + fileName, pdfDoc, filesNumber, jpegInc, jpegFile);

                        if (cancellationToken.IsCancellationRequested)
                        {
                            cancelTask(dirName);
                            break;
                        }
                    }
                }
                else
                {
                    error = true;
                    errorMsg = "Файлы jpeg не обнаружены";
                    new LogWriter("В папке " + dirName + @"\ файлы jpeg не обнаружены");

                }
            }
            catch (Exception ex)
            {
                new LogWriter(ex.ToString());
                error = true;
                errorMsg = ex.Message;
            }
            pdfDoc.Close();
            pdfDoc.Dispose();
            return dirInc;
        }

        private int AddJpegToPdf(string pdfPath, PdfDocument pdfDoc, int filesNumber, int jpegInc, string jpegFile)
        {
            jpegInc++;
            progressBar.Invoke(new Action(() => progressBar.Value = jpegInc * 100 / filesNumber));
            AddPDFPage(pdfDoc, jpegFile);
            pdfDoc.Save(pdfPath);
            long fileSize = new FileInfo(pdfPath).Length;
            uint MB = Convert.ToUInt32(fileSize) >> 20;
            fileSizeLabel.Invoke(new Action(() => fileSizeLabel.Text = MB.ToString() + " МБ"));
            return jpegInc;
        }

        private string GetFileName(string dirName, string namePrefix, int dirInc)
        {
            string fileName;
            if (namePrefix.Length == 0)
            {
                fileName = Path.GetFileName(Path.GetDirectoryName(dirName));
            }
            else fileName = namePrefix + "_" + dirInc;
            return fileName;
        }

        private void ResetControls()
        {
            createButton.Invoke(new Action(() => createButton.Enabled = true));
            cancelButton.Invoke(new Action(() => cancelButton.Enabled = false));
            progressBar.Invoke(new Action(() => progressBar.Value = 0));
            fileNameLabel.Invoke(new Action(() => fileNameLabel.Text = "Имя файла"));
            fileSizeLabel.Invoke(new Action(() => fileSizeLabel.Text = "Размер файла"));
        }

        private void AddPDFPage(PdfDocument pdfDoc, string file)
        {
            XImage img = CompressJpeg(file);
            PdfPage page = pdfDoc.AddPage();
            page.Height = img.PixelHeight;
            page.Width = img.PixelWidth;
            XGraphics gfx = XGraphics.FromPdfPage(page);
            gfx.DrawImage(img, 0, 0, page.Width, page.Height);
            gfx.Dispose();
            img.Dispose();
        }

        private XImage CompressJpeg(string file)
        {
            using (Bitmap jpeg = new Bitmap(file))
            {
                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, (long)this.compressIndex);
                myEncoderParameters.Param[0] = myEncoderParameter;
                MemoryStream memoryStream = new MemoryStream();
                jpeg.Save(memoryStream, jpgEncoder, myEncoderParameters);
                XImage img = XImage.FromStream(memoryStream);

                return img;
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}
