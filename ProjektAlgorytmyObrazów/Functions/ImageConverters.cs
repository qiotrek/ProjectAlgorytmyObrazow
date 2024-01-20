using OpenCvSharp;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektAlgorytmyObrazów.Functions
{
    public class ImageConverters
    {

        public static Bitmap ConvertMatToBitmap(OpenCvSharp.Mat matData)
        {
            byte[] imageData= matData.ToBytes();
            try
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    // Utworzenie obiektu Bitmap z tablicy bajtów
                    Bitmap bitmap = new Bitmap(ms);
                    return bitmap;
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Błąd konwersji: {ex.Message}");
                return null;
            }
        }

       
    }
}
