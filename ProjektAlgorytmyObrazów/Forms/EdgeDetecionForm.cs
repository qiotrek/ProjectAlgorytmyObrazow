using OpenCvSharp;
using ProjektAlgorytmyObrazów.Functions;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ProjektAlgorytmyObrazów.Modele
{
    public partial class EdgeDetectionOptions : Form
    {
        public int mask;
        public int border;
        public int value;
        public bool cont;
        public ImageObject activeImage { get; set; }
        public string SelectedMask { get; private set; }
        public string SelectedFrameType { get; private set; }
        public int FrameSize { get; private set; }

        private Label labelMask;
        private Label labelFrameType;
        private Label labelFrameSize;
        private ComboBox comboBoxMask;
        private ComboBox comboBoxFrameType;
        private TextBox textBoxFrameSize;
        private Button buttonApply;

        public EdgeDetectionOptions()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.labelMask = new Label();
            this.labelFrameType = new Label();
            this.labelFrameSize = new Label();
            this.comboBoxMask = new ComboBox();
            this.comboBoxFrameType = new ComboBox();
            this.textBoxFrameSize = new TextBox();
            this.buttonApply = new Button();

            this.SuspendLayout();

            // Label and ComboBox Configuration for Mask
            ConfigureLabelAndComboBox(labelMask, comboBoxMask, "Maska:", 20, 1);
            comboBoxMask.Items.AddRange(new object[] { "N", "NE", "E","SE","S","SW","W","NW","Sobel","Prewitt" }); 

            // Label and ComboBox Configuration for Frame Type
            ConfigureLabelAndComboBox(labelFrameType, comboBoxFrameType, "Typ ramki:", 60, 2);
            comboBoxFrameType.Items.AddRange(new object[] { "Constant", "Reflect", "Wrap" });
            //this.comboBoxFrameType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectedIndexChanged);
            // Label and TextBox Configuration for Frame Size
            ConfigureLabelAndTextBox(labelFrameSize, textBoxFrameSize, "Wartość:", 100, 3);

            // Button Configuration
            this.buttonApply.Location = new System.Drawing.Point(12, 140);
            this.buttonApply.Size = new System.Drawing.Size(160, 23);
            this.buttonApply.Text = "Zatwierdź";
            this.buttonApply.Click += button1_Click;

            this.Controls.Add(buttonApply);

            this.Name = "EdgeDetectionOptions";
            this.ClientSize = new System.Drawing.Size(200, 180); // Set window size
            this.ResumeLayout(false);
        }

        private void ComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxFrameSize.Enabled = textBoxFrameSize.Enabled = comboBoxFrameType.SelectedItem.ToString() == "CONSTANT";
        }

        private void ConfigureLabelAndComboBox(Label label, ComboBox comboBox, string labelText, int comboBoxLocationY, int comboBoxTabIndex)
        {
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(12, comboBoxLocationY);
            label.Text = labelText;

            comboBox.Location = new System.Drawing.Point(80, comboBoxLocationY);
            comboBox.Size = new System.Drawing.Size(100, 21);
            comboBox.TabIndex = comboBoxTabIndex;

            this.Controls.Add(label);
            this.Controls.Add(comboBox);
        }

        private void ConfigureLabelAndTextBox(Label label, TextBox textBox, string labelText, int textBoxLocationY, int textBoxTabIndex)
        {
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(12, textBoxLocationY);
            label.Text = labelText;

            textBox.Location = new System.Drawing.Point(120, textBoxLocationY);
            textBox.Size = new System.Drawing.Size(60, 20);
            textBox.TabIndex = textBoxTabIndex;

            this.Controls.Add(label);
            this.Controls.Add(textBox);


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            cont = true;
            mask = comboBoxMask.SelectedIndex;
            border = comboBoxFrameType.SelectedIndex;
            string textboxText = textBoxFrameSize.Text;
            Form1 form1Instance = new Form1();
            form1Instance.CalculateEdgeDetection( border,  textboxText,  cont, activeImage,mask,this.value);
            this.Close();
        }


        public static Bitmap Filter(Mat<float> kernel, int border, ImageObject activeImage, int value = 0)
        {
            Mat img = Cv2.ImRead(activeImage.ImagePath, ImreadModes.Color);

            Mat bordered = new Mat();
            switch (border)
            {
                case 0:
                    Cv2.CopyMakeBorder(img, bordered, 0, 0, 0, 0, BorderTypes.Constant, new Scalar(value, value, value, value));
                    break;
                case 1:
                    Cv2.CopyMakeBorder(img, bordered, 0, 0, 0, 0, BorderTypes.Reflect);
                    break;
                case 2:
                    Cv2.CopyMakeBorder(img, bordered, 0, 0, 0, 0, BorderTypes.Wrap);
                    break;
            }

            Mat result = new Mat();
            Cv2.Filter2D(bordered, result, -1, kernel);

            return ImageConverters.ConvertMatToBitmap(result);
        }

        public static Bitmap SobelDetection(ImageObject activeImage, int border, int value)
        {
            Mat img = Cv2.ImRead(activeImage.ImagePath, ImreadModes.Color);

            Mat bordered = new Mat();
            switch (border)
            {
                case 0:
                    Cv2.CopyMakeBorder(img, bordered, 0, 0, 0, 0, BorderTypes.Constant, new Scalar(value, value, value, value));
                    break;
                case 1:
                    Cv2.CopyMakeBorder(img, bordered, 0, 0, 0, 0, BorderTypes.Reflect);
                    break;
                case 2:
                    Cv2.CopyMakeBorder(img, bordered, 0, 0, 0, 0, BorderTypes.Wrap);
                    break;
            }

            Mat blurred = new Mat();
            Cv2.GaussianBlur(bordered, blurred, new OpenCvSharp.Size(3, 3), 0);

            Mat result = new Mat();
            Cv2.Sobel(blurred, result, MatType.CV_8U, 1, 1, 5);

            return ImageConverters.ConvertMatToBitmap(result);
        }

        public static Bitmap PrewittDetection(ImageObject activeImage, int border, int value)
        {
            Mat img = Cv2.ImRead(activeImage.ImagePath, ImreadModes.Color);

            Mat bordered = new Mat();
            switch (border)
            {
                case 0:
                    Cv2.CopyMakeBorder(img, bordered, 0, 0, 0, 0, BorderTypes.Constant, new Scalar(value, value, value, value));
                    break;
                case 1:
                    Cv2.CopyMakeBorder(img, bordered, 0, 0, 0, 0, BorderTypes.Reflect);
                    break;
                case 2:
                    Cv2.CopyMakeBorder(img, bordered, 0, 0, 0, 0, BorderTypes.Wrap);
                    break;
            }

            Mat blurred = new Mat();
            Cv2.GaussianBlur(bordered, blurred, new OpenCvSharp.Size(3, 3), 0);

            Mat firstStep = new Mat();
            Mat<float> kernelX = new Mat<float>(3, 3, new float[] { 1, 1, 1, 0, 0, 0, -1, -1, -1 });
            Cv2.Filter2D(blurred, firstStep, MatType.CV_32F, kernelX, new OpenCvSharp.Point(-1, -1), 0);

            Mat secondStep = new Mat();
            Mat<float> kernelY = new Mat<float>(3, 3, new float[] { -1, 0, 1, -1, 0, 1, -1, 0, 1 });
            Cv2.Filter2D(blurred, secondStep, MatType.CV_32F, kernelY, new OpenCvSharp.Point(-1, -1), 0);

            Mat result = new Mat();
            Cv2.Add(firstStep, secondStep, result);

            return ImageConverters.ConvertMatToBitmap(result);
        }



       
        public static Mat<float> GetKernel(int mask)
        {
            switch (mask)
            {
                case 0:
                    return new Mat<float>(3, 3, new float[,] { { 1, 1, 1 }, { 0, 0, 0 }, { -1, -1, -1 } });
                case 1:
                    return new Mat<float>(3, 3, new float[,] { { 0, 1, 1 }, { -1, 0, 1 }, { -1, -1, 0 } });
                case 2:
                    return new Mat<float>(3, 3, new float[,] { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } });
                case 3:
                    return new Mat<float>(3, 3, new float[,] { { -1, -1, 0 }, { -1, 0, 1 }, { 0, 1, 1 } });
                case 4:
                    return new Mat<float>(3, 3, new float[,] { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } });
                case 5:
                    return new Mat<float>(3, 3, new float[,] { { 0, -1, -1 }, { 1, 0, -1 }, { 1, 1, 0 } });
                case 6:
                    return new Mat<float>(3, 3, new float[,] { { 1, 0, -1 }, { 1, 0, -1 }, { 1, 0, -1 } });
                case 7:
                    return new Mat<float>(3, 3, new float[,] { { 1, 1, 0 }, { 1, 0, -1 }, { 0, -1, -1 } });
                default:
                    return new Mat<float>(3, 3, new float[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } });
            }
        }



    }

}
