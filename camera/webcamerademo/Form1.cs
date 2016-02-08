using System;
using System.Windows.Forms;
using WebEye;
using System.Drawing;
using System.Threading;
using System.Timers;

namespace WebCameraDemo
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            // Create a timer
            //myTimer = new System.Timers.Timer();
        }
        #region
        Thread tr;
        int changed;
        int notchanged;
        #endregion
        /// <summary>
        /// The helper class for a combo box item.
        /// </summary>
        private class ComboBoxItem
        {
            public ComboBoxItem(WebCameraId id)
            {
                _id = id;
            }

            private readonly WebCameraId _id;
            public WebCameraId Id
            {
                get { return _id; }
            }

            public override string ToString()
            {
                // Generates the text shown in the combo box.
                return _id.Name;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (WebCameraId camera in webCameraControl1.GetVideoCaptureDevices())
            {
                comboBox1.Items.Add(new ComboBoxItem(camera));
            }

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedItem = comboBox1.Items[0];
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            ComboBoxItem i = (ComboBoxItem)comboBox1.SelectedItem;

            try
            {
                webCameraControl1.StartCapture(i.Id);
                //INTERVAL
                // Tell the timer what to do when it elapses
                //myTimer.Elapsed += new ElapsedEventHandler(myEvent);
                //// Set it to go off every five seconds
                //myTimer.Interval = 5000;
                //// And start it        
                //myTimer.Enabled = true;
                tr = new Thread(() => Run(webCameraControl1, pbCapture1, pbCapture2));
                tr.Start();
                
            }
            finally
            {
                MessageBox.Show("finally");
                UpdateButtons();
            }
        }

        private void Run(WebCameraControl wc, PictureBox pb1, PictureBox pb2)
        {
            while(true)
            {
                myEvent(wc, pb1, pb2);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            webCameraControl1.StopCapture();
            //myTimer.Stop();
            tr.Abort();
            UpdateButtons();
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Bitmap Image|*.bmp";
            saveFileDialog1.Title = "Save an Image File";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                webCameraControl1.GetCurrentImage().Save(saveFileDialog1.FileName);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            startButton.Enabled = comboBox1.SelectedItem != null;
            stopButton.Enabled = webCameraControl1.IsCapturing;
            imageButton.Enabled = webCameraControl1.IsCapturing;
        }

        private void webCameraControl1_Load(object sender, EventArgs e)
        {

        }

        private void captureButton_Click(object sender, EventArgs e)
        {
            //while (true)
            //{
                Image img = webCameraControl1.GetCurrentImage();
                pbCapture1.Image = img;
                Thread.Sleep(1000);
                Image img2 = webCameraControl1.GetCurrentImage();
                pbCapture2.Image = img2;
            //}
        }

        private void captureButton2_Click(object sender, EventArgs e)
        {
            Image img = webCameraControl1.GetCurrentImage();
            pbCapture2.Image = img;
        }


        private void compareButton_Click(object sender, EventArgs e)
        {
            Bitmap bitImage1 = new Bitmap(pbCapture1.Image);
            Bitmap bitImage2 = new Bitmap(pbCapture2.Image);
            
            tORf.Text = CompareBitmaps(bitImage1, bitImage2).ToString() + changed + " " + notchanged;
        }


        //private System.Timers.Timer myTimer;
        private bool CompareBitmaps(Bitmap bmp1, Bitmap bmp2)
        {
            changed = 0;
            notchanged = 0;
            //bool equals = true;

            //Test to see if we have the same size of image
            if (bmp1.Size == bmp2.Size)
            {
                for (int x = 0; x < bmp1.Width; ++x)
                {
                    for (int y = 0; y <bmp1.Height; ++y)
                    {
                        if (!isSame(bmp1, bmp2, x, y))
                        {
                            //equals = false;
                            changed++;
                            //break;
                        }
                        else
                        {
                            notchanged++;
                        }
                    }
                }
                if (changed > (notchanged /2))
                {
                    //equals = false;
                    return false;
                }
            }
            else
            {
                //equals = false;
                return false;
            }

            //return equals;
            return true;
        }

        public bool isSame(Bitmap map1, Bitmap map2, int x, int y)
        {
            double rgbRatio;

            int B1 = map1.GetPixel(x, y).B;
            int R1 = map1.GetPixel(x, y).R;
            int G1 = map1.GetPixel(x, y).G;

            int B2 = map2.GetPixel(x, y).B;
            int R2 = map2.GetPixel(x, y).R;
            int G2 = map2.GetPixel(x, y).G;
            double rgb1 = CalcRGB(R1, G1, B1);
            double rgb2 = CalcRGB(R2, G2, B2);
            if (rgb1 > rgb2 )
                rgbRatio = rgb1 / rgb2;
            else
                rgbRatio = rgb2 / rgb1;
            if (rgbRatio < 1.4) 
                return true;

            return false;
            //return map1.GetPixel(x, y).B % map2.GetPixel(x, y).B < change && map1.GetPixel(x, y).G % map2.GetPixel(x, y).G < change && map1.GetPixel(x, y).R % map2.GetPixel(x, y).R < change;
        }

        public double CalcRGB(int R, int G, int B)
        {
            if ((R * 256 * 256) + (G * 256) + B == 0)
            {
                return 1;
            }
            return (R * 256 * 256) + (G * 256) + B;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public void Compare(PictureBox pb1, PictureBox pb2)
        {
            Bitmap bitImage1 = new Bitmap(pb1.Image);
            Bitmap bitImage2 = new Bitmap(pb2.Image);

            //tORf.Text = CompareBitmaps(bitImage1, bitImage2).ToString() + changed + " " + notchanged;
            MessageBox.Show(CompareBitmaps(bitImage1, bitImage2).ToString() + changed + " " + notchanged);
        }
        //public void Capturing()
        //{
        //    Image img = webCameraControl1.GetCurrentImage();
        //    pbCapture1.Image = img;
        //    Thread.Sleep(1000);
        //    Image img2 = webCameraControl1.GetCurrentImage();
        //    pbCapture2.Image = img2;
        //}
        private void myEvent(WebCameraControl wc, PictureBox pb1, PictureBox pb2)
        {

            Image img = wc.GetCurrentImage();
      
            pb1.Image = img;
            Thread.Sleep(500);
            Compare(pb1, pb2);


            Thread.Sleep(2000);

            Image img2 = wc.GetCurrentImage();
            pb2.Image = img2;
            Thread.Sleep(500);
            Compare(pb1, pb2);

            Thread.Sleep(2000);
            //if (count == 0)
            //{
            //    count++;
            //    firstPB = false;
            //    Image img = webCameraControl1.GetCurrentImage();
            //    pbCapture1.Image = img;
            //}
            //else
            //{
            //    if (firstPB)
            //    {
            //        Image img = webCameraControl1.GetCurrentImage();
            //        pbCapture1.Image = img;
            //        firstPB = false;
            //        Compare();
            //    }
            //    //Thread.Sleep(1000);
            //    else
            //    {
            //        Image img2 = webCameraControl1.GetCurrentImage();
            //        pbCapture2.Image = img2;
            //        firstPB = true;
            //        Compare();
            //    }
        }
    }

}
