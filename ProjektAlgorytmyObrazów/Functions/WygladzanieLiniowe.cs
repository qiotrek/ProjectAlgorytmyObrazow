using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektAlgorytmyObrazów.Functions
{
    public class WygladzanieLiniowe:ImageConverters
    {
        public static Bitmap Usrednianie(Mat image)
        {
            Mat res = new Mat();
            Cv2.Blur(InputArray.Create(image), res, new OpenCvSharp.Size(3, 3));
            return ConvertMatToBitmap(res);
        }
        public static Bitmap UsrednianieZWagami(Mat image)
        {
            Mat res = new Mat();
            int kVal = CustomForms.GetValueForm("Podaj wartość wagi", "Wartośćwagi");
            Mat customMask = new Mat(3, 3, MatType.CV_32S, new int[]
           {
                 1, 1, 1,
                 1, kVal, 1,
                 1, 1, 1
           });
            // Mat customMask = new Mat(3, 3, MatType.CV_32S, new int[]
            //{
            //     -1, -1, -1,
            //     -2, 9, -2,
            //     -1, -1, -1
            //});
            //Cv2.Normalize(customMask, customMask, 1, 0, NormTypes.L1);
            Cv2.Filter2D(InputArray.Create(image), res, -1, customMask);

            return ConvertMatToBitmap(res);
        }
        public static Bitmap GaussianBlur(Mat image)
        {
            Mat res = new Mat();
            Cv2.GaussianBlur(InputArray.Create(image), res, new OpenCvSharp.Size(3, 3),0);
            return ConvertMatToBitmap(res);
        }

        public static Bitmap DetectEdgesSobel(Mat image)
        {
            // Stwórz obraz o takich samych wymiarach jak oryginalny, ale w skali szarości
            Mat edges = new Mat(image.Size(), MatType.CV_8U);

            // Zastosuj operator Sobela na obrazie
            Cv2.Sobel(image, edges, MatType.CV_8U, 1, 0, ksize: 3);

            return ConvertMatToBitmap(edges);

        }

        public static Bitmap DetectEdgesPrewitt(Mat image)
        {
            // Stwórz obraz o takich samych wymiarach jak oryginalny, ale w skali szarości
            Mat edges = new Mat(image.Size(), MatType.CV_8U);

            // Alternatywnie, można użyć operatora Prewitta zamiast Sobela:
            Mat kernel = new Mat(3, 3, MatType.CV_32F);
            kernel.Set<float>(0, 0, 0);
            kernel.Set<float>(0, 1, 1);
            kernel.Set<float>(0, 2, 0);
            kernel.Set<float>(1, 0, 0);
            kernel.Set<float>(1, 1, 0);
            kernel.Set<float>(1, 2, 0);
            kernel.Set<float>(2, 0, 0);
            kernel.Set<float>(2, 1, -1);
            kernel.Set<float>(2, 2, 0);

            Cv2.Filter2D(image, edges, MatType.CV_8U, kernel);

            return ConvertMatToBitmap(edges);

        }

        public static Bitmap WyostrzanieLinioweLaplasjan(Mat image,Mat customMask)
        {
           
                Mat res = new Mat();                            
                Cv2.Filter2D(InputArray.Create(image), res, -1, customMask);

                return ConvertMatToBitmap(res);
            

        }

        public static Mat ApplyNeighborhoodOperationWithConstantBorder(Mat image, Mat kernel, int borderValue)
        {
            Mat result = new Mat();
            Cv2.Filter2D(image, result, image.Depth(), kernel);

            // Uzupełnienie brzegów stałą wartością
            Cv2.CopyMakeBorder(result, result, kernel.Rows / 2, kernel.Rows / 2, kernel.Cols / 2, kernel.Cols / 2,
                BorderTypes.Constant, new Scalar(borderValue));

            return result;
        }

        public static Mat ApplyNeighborhoodOperationWithReflectBorder(Mat image, Mat kernel)
        {
            Mat result = new Mat();
            Cv2.Filter2D(image, result, image.Depth(), kernel);

            // Uzupełnienie brzegów przez odbicie
            Cv2.CopyMakeBorder(result, result, kernel.Rows / 2, kernel.Rows / 2, kernel.Cols / 2, kernel.Cols / 2,
                BorderTypes.Reflect101);

            return result;
        }

        public static Mat ApplyNeighborhoodOperationWithWrapBorder(Mat image, Mat kernel)
        {
            Mat result = new Mat();
            Cv2.Filter2D(image, result, image.Depth(), kernel);

            // Uzupełnienie brzegów przez zawinięcie (wrap)
            Cv2.CopyMakeBorder(result, result, kernel.Rows / 2, kernel.Rows / 2, kernel.Cols / 2, kernel.Cols / 2,
                BorderTypes.Wrap);

            return result;
        }

    }
}
