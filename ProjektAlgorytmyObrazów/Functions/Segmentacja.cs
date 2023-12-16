using Emgu.CV;
using Emgu.CV.Dnn;
using Emgu.CV;
using OpenCvSharp;
using ProjektAlgorytmyObrazów.Modele;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ProjektAlgorytmyObrazów.Functions
{
    public class Segmentacja: ImageConverters
    {
        public static Bitmap Custom(OpenCvSharp.Mat image ,int param1,int param2) {

            OpenCvSharp.Mat binaryImage1 = new OpenCvSharp.Mat();
            Cv2.Threshold(image, binaryImage1, param1, param2, ThresholdTypes.Binary);
            return ConvertMatToBitmap(binaryImage1);
        }

        public static Bitmap Otsu(OpenCvSharp.Mat image)
        {

            OpenCvSharp.Mat binaryImage1 = new OpenCvSharp.Mat();
            Cv2.Threshold(image, binaryImage1, 0, 255, ThresholdTypes.Otsu);
            //CvInvoke.Threshold(image, binaryImage1, lower, higher, type)
            return ConvertMatToBitmap(binaryImage1);
        }

        public static Bitmap Adaptacyjne(ImageObject image,int localMaxValue)
        {

            Emgu.CV.Mat img = CvInvoke.Imread(image.ImagePath, Emgu.CV.CvEnum.ImreadModes.Grayscale);
            //Cv2.AdaptiveThreshold(image, binaryImage1, localMaxValue, AdaptiveThresholdTypes.GaussianC, ThresholdTypes.Binary, 3, 0);
            return null;
        }

        //public void Segmentation(int lower, int higher, bool adaptive = false, Emgu.CV.CvEnum.ThresholdType type = Emgu.CV.CvEnum.ThresholdType.Binary)
        //{


        //    Emgu.CV.Mat img = CvInvoke.Imread("temp.PNG", Emgu.CV.CvEnum.ImreadModes.Grayscale);

        //    //File.Delete("temp.PNG");

        //    Emgu.CV.Mat result = new Emgu.CV.Mat(img.Size, img.Depth, img.NumberOfChannels);

        //    if (adaptive)
        //        CvInvoke.AdaptiveThreshold(img, result, localMaxValue, Emgu.CV.CvEnum.AdaptiveThresholdType.GaussianC, Emgu.CV.CvEnum.ThresholdType.Binary, 3, 0);
        //    else
        //    {
        //        MessageBox.Show("Wyliczone progowanie: " + CvInvoke.Threshold(img, result, lower, higher, type).ToString());
        //    }

        //    //updateImage(result.ToBitmap());
        //}
    }
}
