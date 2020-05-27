namespace JpegsToPdfCombiner
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.compressIndex = new System.Windows.Forms.NumericUpDown();
            this.PathFrom = new System.Windows.Forms.TextBox();
            this.OpenFromDirectory = new System.Windows.Forms.Button();
            this.PathTo = new System.Windows.Forms.TextBox();
            this.OpenToDirectory = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.prefixTextBox = new System.Windows.Forms.TextBox();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.fileSizeLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.compressIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Исходная папка";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Папка назначения";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Качество";
            // 
            // compressIndex
            // 
            this.compressIndex.ForeColor = System.Drawing.Color.Black;
            this.compressIndex.Location = new System.Drawing.Point(116, 122);
            this.compressIndex.Name = "compressIndex";
            this.compressIndex.Size = new System.Drawing.Size(46, 20);
            this.compressIndex.TabIndex = 16;
            this.compressIndex.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // PathFrom
            // 
            this.PathFrom.Location = new System.Drawing.Point(148, 33);
            this.PathFrom.Name = "PathFrom";
            this.PathFrom.Size = new System.Drawing.Size(283, 20);
            this.PathFrom.TabIndex = 17;
            // 
            // OpenFromDirectory
            // 
            this.OpenFromDirectory.Location = new System.Drawing.Point(463, 31);
            this.OpenFromDirectory.Name = "OpenFromDirectory";
            this.OpenFromDirectory.Size = new System.Drawing.Size(75, 23);
            this.OpenFromDirectory.TabIndex = 18;
            this.OpenFromDirectory.Text = "Открыть";
            this.OpenFromDirectory.UseVisualStyleBackColor = true;
            this.OpenFromDirectory.Click += new System.EventHandler(this.OpenFromDirectory_Click);
            // 
            // PathTo
            // 
            this.PathTo.Location = new System.Drawing.Point(148, 77);
            this.PathTo.Name = "PathTo";
            this.PathTo.Size = new System.Drawing.Size(283, 20);
            this.PathTo.TabIndex = 19;
            // 
            // OpenToDirectory
            // 
            this.OpenToDirectory.Location = new System.Drawing.Point(463, 74);
            this.OpenToDirectory.Name = "OpenToDirectory";
            this.OpenToDirectory.Size = new System.Drawing.Size(75, 23);
            this.OpenToDirectory.TabIndex = 20;
            this.OpenToDirectory.Text = "Открыть";
            this.OpenToDirectory.UseVisualStyleBackColor = true;
            this.OpenToDirectory.Click += new System.EventHandler(this.OpenToDirectory_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(130, 166);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(102, 23);
            this.createButton.TabIndex = 21;
            this.createButton.Text = "Создать PDF";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(60, 234);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(437, 26);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Префикс имени файла";
            // 
            // prefixTextBox
            // 
            this.prefixTextBox.Location = new System.Drawing.Point(365, 122);
            this.prefixTextBox.Name = "prefixTextBox";
            this.prefixTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.prefixTextBox.Size = new System.Drawing.Size(66, 20);
            this.prefixTextBox.TabIndex = 24;
            this.prefixTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(57, 204);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(64, 13);
            this.fileNameLabel.TabIndex = 25;
            this.fileNameLabel.Text = "Имя файла";
            // 
            // fileSizeLabel
            // 
            this.fileSizeLabel.AutoSize = true;
            this.fileSizeLabel.Location = new System.Drawing.Point(416, 204);
            this.fileSizeLabel.Name = "fileSizeLabel";
            this.fileSizeLabel.Size = new System.Drawing.Size(81, 13);
            this.fileSizeLabel.TabIndex = 26;
            this.fileSizeLabel.Text = "Размер файла";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(329, 166);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(102, 23);
            this.cancelButton.TabIndex = 27;
            this.cancelButton.Text = "Прервать";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 292);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.fileSizeLabel);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.prefixTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.OpenToDirectory);
            this.Controls.Add(this.PathTo);
            this.Controls.Add(this.OpenFromDirectory);
            this.Controls.Add(this.PathFrom);
            this.Controls.Add(this.compressIndex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание pdf из файлов jpeg";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.compressIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown compressIndex;
        private System.Windows.Forms.TextBox PathFrom;
        private System.Windows.Forms.Button OpenFromDirectory;
        private System.Windows.Forms.TextBox PathTo;
        private System.Windows.Forms.Button OpenToDirectory;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox prefixTextBox;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Label fileSizeLabel;
        private System.Windows.Forms.Button cancelButton;
    }
}

