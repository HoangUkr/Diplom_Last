using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DirectX.Capture;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using System.Net;
namespace Erasmus
{
    public partial class FormWebCam : Form
    {
        private Capture capture = null;
        private Filters filters = new Filters();
        //private System.Windows.Forms.Panel panelVideo;
        //private System.Windows.Forms.PictureBox pictureBox;
        //private PictureBox pictureBox_Remote;
        //private Button btnExit;
        //private IContainer components;
        private string IP;
        public FormWebCam()
        {
            InitializeComponent();
        }
        FormMessage fm;
        public FormWebCam(FormMessage form)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            // Nhận thiết bị đầu tiên được tìm thấy trong list
#if DEBUG
            capture = new Capture(filters.VideoInputDevices[0], filters.AudioInputDevices[0]);
#endif
            fm = new FormMessage();
            fm = form;
            if (fm.IPWebcam_rq != "")
            {
                IP = fm.IPWebcam_rq;
            }
            else
            {
                IP = fm.IPWebcam_rp;
            }
        }
        bool isSending = false;
        private void CaptureDone(System.Drawing.Bitmap e)
        {
            try
            {
                this.pictureBox.Image = e;
                if (isSending)
                    ThreadPool.QueueUserWorkItem(new WaitCallback(SendVideoBuffer), pictureBox.Image);
            }
            catch (Exception) { }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                isSending = false;
                server_sock.Close();
                ServerThread.Abort();
            }
            catch (Exception) { }

            try
            {
                capture.PreviewWindow = null;
                if (capture != null)
                    capture.Stop();
            }
            catch (Exception) { }
            stoped = true;
            this.Close();
        }

        private void FormWebCam_Load(object sender, EventArgs e)
        {
            ServerThread = new Thread(new ThreadStart(server));
            ServerThread.IsBackground = true;
            ServerThread.Start();

            if (capture != null)
            {
                capture.FrameRate = 15; // số khung hình/giây
                capture.FrameSize = new Size(320, 240); // mặc định size của webcam là 320x240
            }

            // Hiển thị ảnh webcam
            Start_Webcam();
        }
        bool stoped = false;
        Thread ServerThread;
        private void FormWebCam_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!stoped)
            {
                try
                {
                    isSending = false;
                    server_sock.Close();
                    ServerThread.Abort();
                }
                catch (Exception) { }

                try
                {
                    capture.PreviewWindow = null;
                    if (capture != null)
                        capture.Stop();
                }
                catch (Exception) { }
            }
        }
        private void Start_Webcam()
        {
            try
            {
                if (capture != null)
                {
                    if (capture.PreviewWindow != panelVideo)
                    {
                        capture.PreviewWindow = panelVideo;
                    }
                    capture.FrameEvent2 += new Capture.HeFrame(CaptureDone);
                    capture.GrapImg();
                    isSending = true;
                }
            }
            catch (Exception) { }
        }
        Socket server_sock;
        void server()
        {
            try
            {
                server_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server_sock.Bind(new IPEndPoint(IPAddress.Any, 6000));
                server_sock.Listen(-1);

                while (true)
                {
                    try
                    {
                        Socket new_socket = server_sock.Accept();
                        NetworkStream ns = new NetworkStream(new_socket);
                        pictureBox_Remote.Image = Image.FromStream(ns);
                        ns.Close();
                        new_socket.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception) { }

        }
        void SendVideoBuffer(object bufferIn)
        {
            try
            {
                TcpClient tcp = new TcpClient(IP, 6000);
                NetworkStream ns = tcp.GetStream();
                Image buffer = (Image)bufferIn;
                buffer.Save(ns, System.Drawing.Imaging.ImageFormat.Jpeg);
                ns.Close();
                tcp.Close();
            }
            catch (Exception) { }
        }

    }
}
