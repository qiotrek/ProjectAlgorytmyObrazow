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
    public class ManipulacjaHisto
    {
        public static Mat Equalize(ImageObject inputImage)
        {
            Mat matImage = new Mat(inputImage.ImagePath);
            Mat grayMat = new Mat();
            Cv2.CvtColor(matImage, grayMat, ColorConversionCodes.BGR2GRAY);

            Mat equalizedMat = new Mat();
            Cv2.EqualizeHist(grayMat, equalizedMat);

            Mat outputMat = new Mat();
            Cv2.CvtColor(equalizedMat, outputMat, ColorConversionCodes.GRAY2BGR);

            return outputMat;
        }

        public static double GetGammaParameterFromUser()
        {
            Form gammaForm = new Form();
            double gammaParameter = 1.0;

            // Ustawienia formularza
            gammaForm.Text = "Podaj Parametr Gamma";
            gammaForm.Size = new System.Drawing.Size(300, 150);
            gammaForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            gammaForm.MaximizeBox = false;

            // Tekst na formularzu
            Label label = new Label();
            label.Text = "Parametr gamma:";
            label.Size = new System.Drawing.Size(160, 17);
            label.Location = new System.Drawing.Point(70, 10);
            gammaForm.Controls.Add(label);

            // Numeric Up Down na formularzu
            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.Minimum = 0.1M; // Minimalna wartość parametru gamma (liczba większa od 0)
            numericUpDown.DecimalPlaces = 1; // Jedno miejsce po przecinku
            numericUpDown.Maximum = 5.0M; // Maksymalna wartość parametru gamma (dostosuj według potrzeb)
            numericUpDown.Increment = 0.1M; // Krok zmiany wartości
            numericUpDown.Location = new System.Drawing.Point(90, 30);
            gammaForm.Controls.Add(numericUpDown);

            // Przycisk na formularzu
            Button button = new Button();
            button.Text = "Zatwierdź";
            button.Location = new System.Drawing.Point(110, 60);
            button.Click += (s, args) =>
            {
                if (double.TryParse(numericUpDown.Text, out gammaParameter) && gammaParameter > 0)
                {
                    gammaForm.Close();
                }
                else
                {
                    MessageBox.Show("Wprowadź poprawną liczbę większą niż 0.");
                }
            };
            gammaForm.Controls.Add(button);

            // Pokaż formularz
            gammaForm.ShowDialog();
            return gammaParameter;
        }


        public static Image LUTToImage(Bitmap originalImage, int[] lutTable)
        {
            
            Bitmap correctedImage = new Bitmap(originalImage.Width, originalImage.Height);

            // Przetwarzamy każdy piksel w obrazie
            for (int i = 0; i < originalImage.Width; i++)
            {
                for (int j = 0; j < originalImage.Height; j++)
                {
                    // Pobieramy oryginalną wartość piksela
                    Color originalColor = originalImage.GetPixel(i, j);

                    // Zastosowanie tablicy LUT do wartości kanałów RGB
                    int red = lutTable[originalColor.R];
                    int green = lutTable[originalColor.G];
                    int blue = lutTable[originalColor.B];

                    // Tworzymy nowy kolor i ustawiamy go na obrazie wynikowym
                    Color correctedColor = Color.FromArgb(red, green, blue);
                    correctedImage.SetPixel(i, j, correctedColor);
                }
            }

            return (Image)correctedImage;
        }
        public static Image LUTToImageGrayScale(Bitmap originalImage, int[] lutTable)
        {
            Bitmap correctedImage = new Bitmap(originalImage.Width, originalImage.Height);

            // Przetwarzamy każdy piksel w obrazie
            for (int i = 0; i < originalImage.Width; i++)
            {
                for (int j = 0; j < originalImage.Height; j++)
                {
                    // Pobieramy oryginalną wartość piksela (skala szarości)
                    int originalGrayValue = originalImage.GetPixel(i, j).R;

                    // Zastosowanie tablicy LUT do wartości skali szarości
                    int correctedGrayValue = lutTable[originalGrayValue];

                    // Tworzymy nowy kolor i ustawiamy go na obrazie wynikowym
                    Color correctedColor = Color.FromArgb(correctedGrayValue, correctedGrayValue, correctedGrayValue);
                    correctedImage.SetPixel(i, j, correctedColor);
                }
            }

            return (Image)correctedImage;
        }
    }

}

