using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//Create using directives for easier access of AForge library's methods
using AForge.Video;
using AForge.Video.DirectShow;
using System.Threading;
//using AForge.Imaging;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        //VideoCaptureDevice videoSource;
        VideoCaptureDevice[] videoSource = new VideoCaptureDevice[5];
        PictureBox[] pbName = new PictureBox[5];
        int locationX = 0;
        int locationY = 0;
        int howMuchCamerasAreAvailabale = 0;
        int cameraID=0;
        int button2clickCounter = 0;
        
        public void CreatePictureBoxes(int howMuchCameras)
        {
            for (int i = 0; i < howMuchCameras; i++)
            {
                pbName[i] = new PictureBox();
                this.Controls.Add(pbName[i]);
                pbName[i].Name = "picBox" + i;
                pbName[i].Size = new System.Drawing.Size(300, 300);
                pbName[i].Location = new Point(locationX, locationY);
                pbName[i].Visible = true;
                locationX += 201;
                //locationY += 201;
            }
        }

        public void Webcam()
        {
            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            
            howMuchCamerasAreAvailabale = videosources.Count;
            //MessageBox.Show(howMuchCamerasAreAvailabale.ToString());
            CreatePictureBoxes(videosources.Count);

            if (videosources != null)
            {
                while (cameraID < howMuchCamerasAreAvailabale)
                {

                    //For example use first video device. You may check if this is your webcam.
                    videoSource[cameraID] = new VideoCaptureDevice(videosources[cameraID].MonikerString);


                    try
                    {
                        //Check if the video device provides a list of supported resolutions
                        if (videoSource[cameraID].VideoCapabilities.Length > 0)
                        {
                            string highestSolution = "0;0";
                            //Search for the highest resolution
                            for (int i = 0; i < videoSource[cameraID].VideoCapabilities.Length; i++)
                            {
                                if (videoSource[cameraID].VideoCapabilities[i].FrameSize.Width > Convert.ToInt32(highestSolution.Split(';')[0]))
                                    highestSolution = videoSource[cameraID].VideoCapabilities[i].FrameSize.Width.ToString() + ";" + i.ToString();
                            }
                            //Set the highest resolution as active
                            //videoSource.VideoResolution = videoSource.VideoCapabilities[Convert.ToInt32(highestSolution.Split(';')[1])];
                        }
                    }
                    catch { }
                    Test test = new Test(pbName[cameraID]);
                    //MessageBox.Show(cameraID.ToString());
                    //Create NewFrame event handler
                    //(This one triggers every time a new frame/image is captured
                    videoSource[cameraID].NewFrame += new AForge.Video.NewFrameEventHandler(test.videoSource_NewFrame);
                    
                    //Start recording
                    videoSource[cameraID].Start();
                    cameraID++;
                }
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //void videoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        //{
        //    pbName[0].BackgroundImage = (Bitmap)eventArgs.Frame.Clone();
        //}

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < howMuchCamerasAreAvailabale; i++)
            {
                videoSource[i].SignalToStop();
                videoSource[i] = null;
            }
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2clickCounter++;
            if (button2clickCounter == 1)
            {
                Webcam();
                button2.Text = "Stop";
            }
            if (button2clickCounter % 2 == 0)
            {
                button2.Text = "Continue";
                for (int i = 0; i < howMuchCamerasAreAvailabale; i++)
                {
                    videoSource[i].SignalToStop();
                    pbName[i].Visible = false;
                }
            }
            if (button2clickCounter % 2 != 0)
            {
                button2.Text = "Stop";
                for (int i = 0; i < howMuchCamerasAreAvailabale; i++)
                {
                    videoSource[i].Start();
                    pbName[i].Visible = true;
                }
            }
           
        }

       

    }
}