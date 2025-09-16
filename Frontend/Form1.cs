using Emgu.CV;
using Emgu.CV.Linemod;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Emgu.CV.Face.FaceRecognizer;



namespace DiseaseDetector
{
    public partial class leafDisease : Form
    {
        public leafDisease()
        {
            InitializeComponent();
            AddAppInfo();
            imagePanel.AllowDrop = true;
            imagePanel.DragEnter += ImagePanel_DragEnter;
            imagePanel.DragDrop += ImagePanel_DragDrop;
            AddDropMessage();
            modelComboBox.Items.Add("VGG 19");
            modelComboBox.Items.Add("Mobile net V3");
            modelComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private Dictionary<string, string> ReadMetadata(string path)
        {
            var dict = new Dictionary<string, string>();
            if (!File.Exists(path)) return dict;

            foreach (var line in File.ReadAllLines(path))
            {
                if (string.IsNullOrWhiteSpace(line) || !line.Contains("=")) continue;
                var parts = line.Split(new[] { '=' }, 2);
                dict[parts[0].Trim()] = parts[1].Trim();
            }

            return dict;
        }

        private void AddAppInfo()
        {
            string metadataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "metadata.txt");
            var metadata = ReadMetadata(metadataPath);

            if (metadata.TryGetValue("Publisher", out string publisher))
                labelPublisher.Text = "Published By: "+ publisher;

            if (metadata.TryGetValue("Version", out string version))
                labelVersion.Text = "Version: "+ version;
        }


        public class DiseasePredictionResult
        {
            public string image { get; set; }
            public string prediction { get; set; }
            public double confidence { get; set; }
            public string name { get; set; }
            public string cause { get; set; }
            public string symptoms { get; set; }
            public string cure_steps { get; set; }
            public string plant_survival { get; set; }
            public string recovery_time { get; set; }
            public string extra_tips { get; set; }
            public string timestamp { get; set; }
            public bool error { get; set; }
            public string message { get; set; }
        }

        string imagePath = null;
        private PictureBox pb;
        private void BrowsePredictButton_Click(object sender, EventArgs e)
        {
            if (browseDetectButton.Text == "Browse")
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Title = "Select a Leaf Image";
                    ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        imagePath = ofd.FileName;
                        LoadImageToPanel(imagePath);
                    }
                }
            }
            else if (browseDetectButton.Text == "Detect Disease")
            {
                if (pb?.Image == null)
                {
                    MessageBox.Show("Please select a leaf image first!");
                    return;
                }

                string pathName = pb.Tag.ToString();

                string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "main", "main.exe");

                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = exePath,
                    Arguments = $"--predict \"{pathName}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true, // still capture for logging, but won't block
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                string output, errors;
                using (var process = System.Diagnostics.Process.Start(psi))
                {
                    output = process.StandardOutput.ReadToEnd();
                    errors = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                }

                // Ignore TensorFlow warning messages in stderr
                if (!string.IsNullOrWhiteSpace(errors))
                {
                    var cleanedErrors = string.Join("\r\n",
                        errors.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
                              .Where(line => !line.Contains("oneDNN") && !line.Contains("TensorFlow")));
                    if (!string.IsNullOrWhiteSpace(cleanedErrors))
                    {
                        logTerminal.Text = "Python stderr (non-TF warnings):\r\n" + cleanedErrors;
                    }
                }

                // Parse JSON result
                try
                {
                    // Take only the last non-empty line (should be JSON)
                    var jsonLine = output.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries).Last();

                    var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var result = System.Text.Json.JsonSerializer.Deserialize<DiseasePredictionResult>(jsonLine, options);

                    if (result != null && !result.error)
                    {
                        double diseaseConfidence = result.confidence;
                        string diseaseName = result.name;
                        string diseaseCause = result.cause;
                        string diseaseSymptoms = result.symptoms;
                        string diseaseCureSteps = result.cure_steps;
                        string plantSurvival = result.plant_survival;
                        string recoveryTime = result.recovery_time;
                        string extraTips = result.extra_tips;
                        string message = $"Disease: \n{diseaseName}\r\n" +
                                         $"Confidence: {result.confidence:P2}\r\n" +
                                         $"Cause: {diseaseCause}\r\n" +
                                         $"Symptoms: {diseaseSymptoms}\r\n" +
                                         $"Cure Steps: \n{diseaseCureSteps}\r\n" +
                                         $"Plant Survival: {plantSurvival}\r\n" +
                                         $"Recovery Time: {recoveryTime}\r\n" + 
                                         $"Extra Tips: \n{extraTips}";

                        // Log to terminal
                        logTerminal.Text = message;

                        // Show custom popup (non-blocking)
                        Popup popup = new Popup(diseaseName, diseaseCause, diseaseSymptoms, diseaseCureSteps, plantSurvival, recoveryTime, extraTips, diseaseConfidence);
                        popup.Show(); // or popup.ShowDialog() if you want modal
                    }
                    else
                    {
                        string errorMsg = $"Prediction error: {result?.message ?? "Unknown error"}";
                        logTerminal.Text = errorMsg;
                    }
                }
                catch (Exception ex)
                {
                    logTerminal.Text = "Failed to parse JSON:\r\n" + ex.Message + "\r\nRaw Output:\r\n" + output;
                }
            }
        }




        private void RemoveButton_Click(object sender, EventArgs e)
        {
            imagePanel.Controls.Clear();
            AddDropMessage();
            browseDetectButton.Text = "Browse";
            removeImageButton.Enabled = false;
        }

        private void LoadImageToPanel(string imgPath)
        {
            imagePath = imgPath;
            imagePanel.Controls.Clear();
            pb = new PictureBox
            {
                Image = Image.FromFile(imagePath),
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill
            };
            pb.Tag = imagePath;
            imagePanel.Controls.Add(pb);
            browseDetectButton.Text = "Detect Disease";
            removeImageButton.Enabled = true;

        }

        private void ImagePanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void ImagePanel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0 && IsImageFile(files[0]))
                {
                    LoadImageToPanel(files[0]);
                }
            }
        }

        //Toggling between live and image detection
        private void ImageDetectionClick(object sender, EventArgs e)
        {
            imageDetectionButton.Enabled = false;
            liveDetectionButton.Enabled = true;
            ToggleBetweenLiveAndImage();
        }

        private void LiveDetectionClick(object sender, EventArgs e)
        {
            liveDetectionButton.Enabled = false;
            imageDetectionButton.Enabled = true;
            ToggleBetweenLiveAndImage();
        }

        private void ToggleBetweenLiveAndImage()
        {
            if (imageDetectionButton.Enabled)
            {
                startStopCamera.Visible = true;
                browseDetectButton.Visible = false;
                removeImageButton.Visible = false;
                AddDropMessage();
            }
            else
            {
                startStopCamera.Visible = false;
                browseDetectButton.Visible = true;
                removeImageButton.Visible = true;
                AddDropMessage();
            }
        }

        private void AddDropMessage()
        {
            Label lbl;
            if (!liveDetectionButton.Enabled == false)
            {
                lbl = new Label()
                {
                    Text = "Drag and drop an image here.",
                    ForeColor = Color.DarkGray,
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };
            }
            else
            {
                lbl = new Label()
                {
                    Text = "Click Start Camera to switch on the camera.",
                    ForeColor = Color.DarkGray,
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };
            }
            imagePanel.Controls.Clear();
            imagePanel.Controls.Add(lbl);
        }

        private bool IsImageFile(string filePath)
        {
            string ext = System.IO.Path.GetExtension(filePath).ToLower();
            return ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp" || ext == ".gif";
        }

        private VideoCapture _capture;
        private Timer _timer;
        private PictureBox videoFrame;
        private bool _isCameraRunning = false;

        private void InitializeCameraPreview()
        {
            videoFrame = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            imagePanel.Controls.Clear();
            imagePanel.Controls.Add(videoFrame);
        }

        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            if (!_isCameraRunning)
            {
                InitializeCameraPreview();

                _capture = new VideoCapture(0);
                _timer = new Timer { Interval = 30 };
                _timer.Tick += ProcessFrame;
                _timer.Start();

                startStopCamera.Text = "Stop Camera";
                imageDetectionButton.Enabled = false;
                _isCameraRunning = true;
            }
            else
            {
                _timer?.Stop();
                _capture?.Dispose();
                videoFrame.Image = null;

                startStopCamera.Text = "Start Camera";
                imageDetectionButton.Enabled = true;
                _isCameraRunning = false;
                AddDropMessage();
            }
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            if (_capture != null && _capture.Ptr != IntPtr.Zero)
            {
                using (Mat frame = _capture.QueryFrame())
                {
                    if (frame != null && !frame.IsEmpty)
                    {
                        CvInvoke.Flip(frame, frame, Emgu.CV.CvEnum.FlipType.Horizontal);
                        videoFrame.Image?.Dispose();
                        videoFrame.Image = frame.ToImage<Bgr, byte>().ToBitmap();
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timer?.Stop();
            _capture?.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
