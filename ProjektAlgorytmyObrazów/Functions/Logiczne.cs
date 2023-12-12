using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektAlgorytmyObrazów.Functions
{
    internal class Logiczne
    {

        public static Mat LogicalAND(Mat imageA, Mat imageB)
        {
            // Sprawdź, czy obrazy mają takie same wymiary
            if (imageA.Size() != imageB.Size())
                MessageBox.Show("Obrazy muszą mieć takie same wymiary");

            // Wykonaj operację AND
            Mat resultImage = new Mat();
            Cv2.BitwiseAnd(imageA, imageB, resultImage);

            return resultImage;
        }
        public static Mat LogicalNOT(Mat imageA)
        {
            // Wykonaj operację NOT
            Mat resultImage = new Mat();
            Cv2.BitwiseNot(imageA, resultImage);

            return resultImage;
        }
        public static Mat LogicalOR(Mat imageA, Mat imageB)
        {
            // Sprawdź, czy obrazy mają takie same wymiary
            if (imageA.Size() != imageB.Size())
                MessageBox.Show("Obrazy muszą mieć takie same wymiary");

            // Wykonaj operację OR
            Mat resultImage = new Mat();
            Cv2.BitwiseOr(imageA, imageB, resultImage);

            return resultImage;
        }
        public static Mat LogicalXor(Mat imageA, Mat imageB)
        {
            // Sprawdź, czy obrazy mają takie same wymiary
            if (imageA.Size() != imageB.Size())
                MessageBox.Show("Obrazy muszą mieć takie same wymiary");

            // Wykonaj operację Xor
            Mat resultImage = new Mat();
            Cv2.BitwiseXor(imageA, imageB, resultImage);

            return resultImage;
        }


        public static Mat LogicalAdd(Mat imageA, Mat imageB)
        {
            // Sprawdź, czy obrazy mają takie same wymiary
            if (imageA.Size() != imageB.Size())
                MessageBox.Show("Obrazy muszą mieć takie same wymiary");

            // Wykonaj operację Xor
            Mat resultImage = new Mat();
            Cv2.Add(imageA, imageB, resultImage);

            return resultImage;
        }

        public static Bitmap AddValueToImage(Bitmap image, int value)
        {
            Bitmap resultImage = new Bitmap(image.Width, image.Height);

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color pixel = image.GetPixel(i, j);

                    // Dodaj wartość do składowej czerwonej piksela
                    int newRed = SaturateValue(pixel.R + value);
                    int newGreen = SaturateValue(pixel.G + value);
                    int newBlue = SaturateValue(pixel.B + value);

                    // Ustaw wynikowy piksel
                    resultImage.SetPixel(i, j, Color.FromArgb(newRed, newGreen, newBlue));
                }
            }

            return resultImage;
        }

        public static Bitmap SubtractValueFromImage(Bitmap image, int value)
        {
            Bitmap resultImage = new Bitmap(image.Width, image.Height);

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color pixel = image.GetPixel(i, j);

                    int newRed = SaturateValue(pixel.R - value);
                    int newGreen = SaturateValue(pixel.G - value);
                    int newBlue = SaturateValue(pixel.B - value);

                    resultImage.SetPixel(i, j, Color.FromArgb(newRed, newGreen, newBlue));
                }
            }

            return resultImage;
        }

        public static Bitmap MultiplyImageByValue(Bitmap image, int value)
        {
            Bitmap resultImage = new Bitmap(image.Width, image.Height);

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color pixel = image.GetPixel(i, j);

                    int newRed = SaturateValue(pixel.R * value);
                    int newGreen = SaturateValue(pixel.G * value);
                    int newBlue = SaturateValue(pixel.B * value);

      
                    resultImage.SetPixel(i, j, Color.FromArgb(newRed, newGreen, newBlue));
                }
            }

            return resultImage;
        }

        public static Bitmap DivideImageByValue(Bitmap image, int value)
        {
            Bitmap resultImage = new Bitmap(image.Width, image.Height);

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color pixel = image.GetPixel(i, j);

                    if (value != 0)
                    {
                        // Podziel wartość składowej czerwonej piksela przez daną wartość
                        int newRed = SaturateValue(pixel.R / value);
                        int newGreen = SaturateValue(pixel.G / value);
                        int newBlue = SaturateValue(pixel.B / value);

                        // Ustaw wynikowy piksel
                        resultImage.SetPixel(i, j, Color.FromArgb(newRed, newGreen, newBlue));
                    }
                    else
                    {

                        MessageBox.Show("Nie dziel przez zero!");
                    }
                }
            }

            return resultImage;
        }


        public static Bitmap CalculateAbsoluteDifference(Bitmap image1, Bitmap image2)
        {
            // Sprawdź zgodność rozmiarów obrazów
            if (image1.Size != image2.Size)
            {
                MessageBox.Show("Rozmiary obrazów nie są zgodne.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            Bitmap resultImage = new Bitmap(image1.Width, image1.Height);

            for (int i = 0; i < image1.Width; i++)
            {
                for (int j = 0; j < image1.Height; j++)
                {
                    Color pixel1 = image1.GetPixel(i, j);
                    Color pixel2 = image2.GetPixel(i, j);

                    // Oblicz różnicę bezwzględną składowej czerwonej piksela
                    int redDifference = Math.Abs(pixel1.R - pixel2.R);
                    int greenDifference = Math.Abs(pixel1.G - pixel2.G);
                    int blueDifference = Math.Abs(pixel1.B - pixel2.B);

                    // Ustaw wynikowy piksel
                    resultImage.SetPixel(i, j, Color.FromArgb(redDifference, greenDifference, blueDifference));
                }
            }

            return resultImage;
        }
        private static int SaturateValue(int value)
        {
            return Math.Max(1, Math.Min(127, value));
        }


        public static int GetValueForm(string windowTitle,string labelTitle)
        {
            Form getValueForm = new Form();
            int poziomProgowania = 0;

            // Ustawienia formularza
            getValueForm.Text = windowTitle;
            getValueForm.Size = new System.Drawing.Size(300, 150);
            getValueForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            getValueForm.MaximizeBox = false;

            // Tekst na formularzu
            Label label = new Label();
            label.Text = labelTitle + ":";
            label.Size = new System.Drawing.Size(160, 17);
            label.Location = new System.Drawing.Point(70, 10);
            getValueForm.Controls.Add(label);

            // Numeric Up Down na formularzu
            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.Minimum = 1; // Minimalna wartość to 1 (liczba większa od 0)
            numericUpDown.Location = new System.Drawing.Point(90, 30);
            getValueForm.Controls.Add(numericUpDown);

            // Przycisk na formularzu
            Button button = new Button();
            button.Text = "Zatwierdź";
            button.Location = new System.Drawing.Point(110, 60);
            button.Click += (s, args) =>
            {

                if (int.TryParse(numericUpDown.Value.ToString(), out poziomProgowania) && poziomProgowania > 0)
                {
                    getValueForm.Close();
                }
                else
                {
                    MessageBox.Show("Wprowadź poprawną liczbę większą od 0.");
                }

            };
            getValueForm.Controls.Add(button);

            // Pokaż formularz
            getValueForm.ShowDialog();
            return poziomProgowania;
        }
    }
}
