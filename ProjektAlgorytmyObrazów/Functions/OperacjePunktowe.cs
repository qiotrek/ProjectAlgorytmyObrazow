using OpenCvSharp;
using ProjektAlgorytmyObrazów.Modele;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektAlgorytmyObrazów.Functions
{
    public class OperacjePunktowe
    {
        public static Bitmap ReduceGrayscaleLevelsInImage(Bitmap originalImage, int newGrayLevels)
        {
            // Create a new bitmap with the same size as the original
            Bitmap reducedGrayscaleImage = new Bitmap(originalImage.Width, originalImage.Height);
            // Calculate the factor to scale the grayscale levels
            int factor = 255 / (newGrayLevels);
            // Iterate through each pixel and reduce the grayscale level
            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);
                    int newGrayValue = ((originalColor.R + originalColor.G + originalColor.B) / 3) / factor * factor;
                    Color newColor = Color.FromArgb(newGrayValue, newGrayValue, newGrayValue);
                    reducedGrayscaleImage.SetPixel(x, y, newColor);
                }
            }
            return reducedGrayscaleImage;
        }

        public static Bitmap NegateImage(Bitmap originalImage)
        {
            Bitmap negatedImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);

                    int red = 255 - originalColor.R;
                    int green = 255 - originalColor.G;
                    int blue = 255 - originalColor.B;

                    Color negatedColor = Color.FromArgb(red, green, blue);

                    negatedImage.SetPixel(x, y, negatedColor);
                }
            }

            return negatedImage;
        }
        public static int GetPoziomySzarościForm()
        {
            Form poziomszarosciForm = new
                Form();
            int przesycenie=0;

            // Ustawienia formularza
            poziomszarosciForm.Text = "PodajPoziomSzarosci";
            poziomszarosciForm.Size = new System.Drawing.Size(300, 150);
            poziomszarosciForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            poziomszarosciForm.MaximizeBox = false;

            // Tekst na formularzu
            Label label = new Label();
            label.Text = "Poziom szarości:";
            label.Size = new System.Drawing.Size(160, 17);
            label.Location = new System.Drawing.Point(70, 10);
            poziomszarosciForm.Controls.Add(label);

            // Numeric Up Down na formularzu
            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.Minimum = 1; // Minimalna wartość to 1 (liczba większa od 0)
            numericUpDown.Location = new System.Drawing.Point(90, 30);
            poziomszarosciForm.Controls.Add(numericUpDown);

            // Przycisk na formularzu
            Button button = new Button();
            button.Text = "Zatwierdź";
            button.Location = new System.Drawing.Point(110, 60);
            button.Click += (s, args) =>
            {
               
                if (int.TryParse(numericUpDown.Value.ToString(), out przesycenie) && przesycenie > 0)
                {
                     poziomszarosciForm.Close();
                }
                else
                {
                    MessageBox.Show("Wprowadź poprawną liczbę większą od 0.");
                }
               
            };
            poziomszarosciForm.Controls.Add(button);

            // Pokaż formularz
            poziomszarosciForm.ShowDialog();
            return przesycenie;
        }


        public static Mat BinaryThreshold(ImageObject inputImage, double threshold)
        {        
                Mat matImage = new Mat(inputImage.ImagePath);
                Mat grayMat = new Mat();
                Cv2.CvtColor(matImage, grayMat, ColorConversionCodes.BGR2GRAY);

                Mat binaryMat = new Mat();
                Cv2.Threshold(grayMat, binaryMat, threshold, 255, ThresholdTypes.Binary);

               return binaryMat;         
        }

        //public static Bitmap ApplyBinaryThreshold(Bitmap originalImage, int threshold)
        //{
        //    Bitmap binaryImage = new Bitmap(originalImage.Width, originalImage.Height);

        //    for (int x = 0; x < originalImage.Width; x++)
        //    {
        //        for (int y = 0; y < originalImage.Height; y++)
        //        {
        //            Color originalColor = originalImage.GetPixel(x, y);
        //            int averageBrightness = (originalColor.R + originalColor.G + originalColor.B) / 3;
        //            int thresholdValue = threshold;
        //            Color newColor = (averageBrightness > thresholdValue) ? Color.White : Color.Black;
        //            binaryImage.SetPixel(x, y, newColor);
        //        }
        //    }

        //    return binaryImage;
        //}


        public static Bitmap Threshold(ImageObject inputImage, double threshold)
        {
            Bitmap thresholdedImage = new Bitmap(inputImage.Image.Width, inputImage.Image.Height);

            for (int y = 0; y < inputImage.Image.Height; y++)
            {
                for (int x = 0; x < inputImage.Image.Width; x++)
                {
                    Color pixelColor = ((Bitmap)inputImage.Image).GetPixel(x, y);
                    int grayValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);

                    if (grayValue >= threshold)
                    {
                        thresholdedImage.SetPixel(x, y, Color.FromArgb(grayValue, grayValue, grayValue));
                    }
                    else
                    {
                        thresholdedImage.SetPixel(x, y, Color.Black);
                    }
                }
            }

            return thresholdedImage;


        }

        //public static Bitmap ApplyBinaryThresholdWithGrayLevels(Bitmap originalImage, int threshold)
        //{
        //    Bitmap binaryImage = new Bitmap(originalImage.Width, originalImage.Height);

        //    for (int x = 0; x < originalImage.Width; x++)
        //    {
        //        for (int y = 0; y < originalImage.Height; y++)
        //        {
        //            Color originalColor = originalImage.GetPixel(x, y);
        //            int averageBrightness = (originalColor.R + originalColor.G + originalColor.B) / 3;
        //            int thresholdValue = threshold;
        //            int newBrightness = (averageBrightness > thresholdValue) ? 255 : 0; // Ustawia jasność na maksymalną lub minimalną
        //            Color newColor = Color.FromArgb(newBrightness, newBrightness, newBrightness);
        //            binaryImage.SetPixel(x, y, newColor);
        //        }
        //    }

        //    return binaryImage;
        //}
        public static int GetPoziomProgowaniaForm()
        {
            Form poziomProgowaniaForm = new Form();
            int poziomProgowania = 0;

            // Ustawienia formularza
            poziomProgowaniaForm.Text = "PodajPoziomProgowania";
            poziomProgowaniaForm.Size = new System.Drawing.Size(300, 150);
            poziomProgowaniaForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            poziomProgowaniaForm.MaximizeBox = false;

            // Tekst na formularzu
            Label label = new Label();
            label.Text = "Poziom progowania:";
            label.Size = new System.Drawing.Size(160, 17);
            label.Location = new System.Drawing.Point(70, 10);
            poziomProgowaniaForm.Controls.Add(label);

            // Numeric Up Down na formularzu
            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.Minimum = 1; // Minimalna wartość to 1 (liczba większa od 0)
            numericUpDown.Location = new System.Drawing.Point(90, 30);
            poziomProgowaniaForm.Controls.Add(numericUpDown);

            // Przycisk na formularzu
            Button button = new Button();
            button.Text = "Zatwierdź";
            button.Location = new System.Drawing.Point(110, 60);
            button.Click += (s, args) =>
            {

                if (int.TryParse(numericUpDown.Value.ToString(), out poziomProgowania) && poziomProgowania > 0)
                {
                    poziomProgowaniaForm.Close();
                }
                else
                {
                    MessageBox.Show("Wprowadź poprawną liczbę większą od 0.");
                }

            };
            poziomProgowaniaForm.Controls.Add(button);

            // Pokaż formularz
            poziomProgowaniaForm.ShowDialog();
            return poziomProgowania;
        }
    }
}
