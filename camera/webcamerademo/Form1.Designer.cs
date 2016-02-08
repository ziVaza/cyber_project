namespace WebCameraDemo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.imageButton = new System.Windows.Forms.Button();
            this.webCameraControl1 = new WebEye.WebCameraControl();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pbCapture1 = new System.Windows.Forms.PictureBox();
            this.captureButton1 = new System.Windows.Forms.Button();
            this.pbCapture2 = new System.Windows.Forms.PictureBox();
            this.captureButton2 = new System.Windows.Forms.Button();
            this.tORf = new System.Windows.Forms.Label();
            this.compareButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCapture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCapture2)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(138, 252);
            this.startButton.Margin = new System.Windows.Forms.Padding(2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(222, 252);
            this.stopButton.Margin = new System.Windows.Forms.Padding(2);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // imageButton
            // 
            this.imageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imageButton.Enabled = false;
            this.imageButton.Location = new System.Drawing.Point(306, 252);
            this.imageButton.Margin = new System.Windows.Forms.Padding(2);
            this.imageButton.Name = "imageButton";
            this.imageButton.Size = new System.Drawing.Size(75, 23);
            this.imageButton.TabIndex = 3;
            this.imageButton.Text = "Image...";
            this.imageButton.UseVisualStyleBackColor = true;
            this.imageButton.Click += new System.EventHandler(this.imageButton_Click);
            // 
            // webCameraControl1
            // 
            this.webCameraControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webCameraControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.webCameraControl1.Location = new System.Drawing.Point(8, 8);
            this.webCameraControl1.Margin = new System.Windows.Forms.Padding(2);
            this.webCameraControl1.Name = "webCameraControl1";
            this.webCameraControl1.Size = new System.Drawing.Size(373, 239);
            this.webCameraControl1.TabIndex = 4;
            this.webCameraControl1.Load += new System.EventHandler(this.webCameraControl1_Load);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(8, 252);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pbCapture1
            // 
            this.pbCapture1.Image = ((System.Drawing.Image)(resources.GetObject("pbCapture1.Image")));
            this.pbCapture1.Location = new System.Drawing.Point(406, 8);
            this.pbCapture1.Name = "pbCapture1";
            this.pbCapture1.Size = new System.Drawing.Size(311, 238);
            this.pbCapture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCapture1.TabIndex = 5;
            this.pbCapture1.TabStop = false;
            // 
            // captureButton1
            // 
            this.captureButton1.Location = new System.Drawing.Point(406, 252);
            this.captureButton1.Name = "captureButton1";
            this.captureButton1.Size = new System.Drawing.Size(75, 23);
            this.captureButton1.TabIndex = 6;
            this.captureButton1.Text = "Capture1";
            this.captureButton1.UseVisualStyleBackColor = true;
            this.captureButton1.Click += new System.EventHandler(this.captureButton_Click);
            // 
            // pbCapture2
            // 
            this.pbCapture2.Image = ((System.Drawing.Image)(resources.GetObject("pbCapture2.Image")));
            this.pbCapture2.Location = new System.Drawing.Point(740, 8);
            this.pbCapture2.Name = "pbCapture2";
            this.pbCapture2.Size = new System.Drawing.Size(311, 238);
            this.pbCapture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCapture2.TabIndex = 7;
            this.pbCapture2.TabStop = false;
            // 
            // captureButton2
            // 
            this.captureButton2.Location = new System.Drawing.Point(487, 252);
            this.captureButton2.Name = "captureButton2";
            this.captureButton2.Size = new System.Drawing.Size(75, 23);
            this.captureButton2.TabIndex = 8;
            this.captureButton2.Text = "Capture2";
            this.captureButton2.UseVisualStyleBackColor = true;
            this.captureButton2.Click += new System.EventHandler(this.captureButton2_Click);
            // 
            // tORf
            // 
            this.tORf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tORf.Location = new System.Drawing.Point(740, 252);
            this.tORf.Name = "tORf";
            this.tORf.Size = new System.Drawing.Size(311, 20);
            this.tORf.TabIndex = 9;
            this.tORf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // compareButton
            // 
            this.compareButton.Location = new System.Drawing.Point(569, 251);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(75, 23);
            this.compareButton.TabIndex = 10;
            this.compareButton.Text = "Compare";
            this.compareButton.UseVisualStyleBackColor = true;
            this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(660, 251);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 276);
            this.Controls.Add(this.pbCapture1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.compareButton);
            this.Controls.Add(this.tORf);
            this.Controls.Add(this.captureButton2);
            this.Controls.Add(this.pbCapture2);
            this.Controls.Add(this.captureButton1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.webCameraControl1);
            this.Controls.Add(this.imageButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(408, 285);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCapture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCapture2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button imageButton;
        private WebEye.WebCameraControl webCameraControl1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox pbCapture1;
        private System.Windows.Forms.Button captureButton1;
        private System.Windows.Forms.PictureBox pbCapture2;
        private System.Windows.Forms.Button captureButton2;
        private System.Windows.Forms.Label tORf;
        private System.Windows.Forms.Button compareButton;
        private System.Windows.Forms.Button button1;

    }
}

