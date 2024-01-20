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
        public static Bitmap Custom(ImageObject image ,int param1,int param2) {


            Mat res=Segmentation(image,param1, param2);
            return ConvertMatToBitmap(res);
        }

        public static Bitmap Otsu(ImageObject image)
        {

            Mat res =Segmentation(image,0, 255, false, ThresholdTypes.Otsu);
            return ConvertMatToBitmap(res);
        }

        public static Bitmap Adaptacyjne(ImageObject image)
        {

            Mat res = Segmentation(image,0, 255, true);
            return ConvertMatToBitmap(res);
        }

        public static Mat Segmentation(ImageObject image, int lower, int higher, bool adaptive = false, ThresholdTypes type = ThresholdTypes.Binary)
        {
            Mat colorImage = Cv2.ImRead(image.ImagePath);
            Mat grayscaleImage = new Mat();
            Cv2.CvtColor(colorImage, grayscaleImage, ColorConversionCodes.BGR2GRAY);

            Mat result = new Mat(grayscaleImage.Size(), grayscaleImage.Type());

    
            if (adaptive)
            {
                Cv2.AdaptiveThreshold(grayscaleImage, result, (image.statistics.Max!=0)? image.statistics.Max:255, AdaptiveThresholdTypes.GaussianC, ThresholdTypes.Binary, 3, 0);
            }
            else
            {
                MessageBox.Show("Wyliczone progowanie: " + Cv2.Threshold(grayscaleImage, result, lower, higher, type).ToString());
            }

            return result;
        }
    }
}
