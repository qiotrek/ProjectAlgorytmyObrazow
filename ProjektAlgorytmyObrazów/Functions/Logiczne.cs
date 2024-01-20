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

        public static Bitmap AddImages(Bitmap imageOriginal, Bitmap imageToMerge, bool saturation)
        {
            Bitmap mergedImage = new Bitmap(imageOriginal.Width, imageOriginal.Height);

            for (int i = 0; i < imageOriginal.Width; i++)
            {
                for (int j = 0; j < imageOriginal.Height; j++)
                {
                    Color pixelColorOriginal = ((Bitmap)imageOriginal).GetPixel(i, j);
                    Color pixelColor;

                    if (i < imageToMerge.Width && j < imageToMerge.Height)
                        pixelColor = imageToMerge.GetPixel(i, j);
                    else
                        pixelColor = Color.FromArgb(0, 0, 0);

                    Color mergeColor = Color.FromArgb(
                        saturation ? (pixelColorOriginal.R + pixelColor.R).Clamp<int>(0, 255) : (pixelColorOriginal.R.Clamp<byte>(1, 127) + pixelColor.R.Clamp<byte>(1, 127)).Clamp<int>(0, 255),
                        saturation ? (pixelColorOriginal.G + pixelColor.G).Clamp<int>(0, 255) : (pixelColorOriginal.G.Clamp<byte>(1, 127) + pixelColor.G.Clamp<byte>(1, 127)).Clamp<int>(0, 255),
                        saturation ? (pixelColorOriginal.B + pixelColor.B).Clamp<int>(0, 255) : (pixelColorOriginal.B.Clamp<byte>(1, 127) + pixelColor.B.Clamp<byte>(1, 127)).Clamp<int>(0, 255));

                    mergedImage.SetPixel(i, j, mergeColor);
                }
            }

            return mergedImage;
        }

        public static Bitmap  SubtractImages(Bitmap imageOriginal, Bitmap imageToMerge)
        {
            Bitmap mergedImage = new Bitmap(imageOriginal.Width, imageOriginal.Height);

            for (int i = 0; i < imageOriginal.Width; i++)
            {
                for (int j = 0; j < imageOriginal.Height; j++)
                {
                    Color pixelColorOriginal = ((Bitmap)imageOriginal).GetPixel(i, j);
                    Color pixelColor;

                    if (i < imageToMerge.Width && j < imageToMerge.Height)
                        pixelColor = imageToMerge.GetPixel(i, j);
                    else
                        pixelColor = Color.FromArgb(0, 0, 0);

                    Color mergeColor = Color.FromArgb((pixelColorOriginal.R - pixelColor.R).Clamp<int>(0, 255), (pixelColorOriginal.G - pixelColor.G).Clamp<int>(0, 255), (pixelColorOriginal.B - pixelColor.B).Clamp<int>(0, 255));

                    mergedImage.SetPixel(i, j, mergeColor);
                }
            }

            return mergedImage;
        }

        public static Bitmap AddValueToImage(Bitmap image, int value)
        {
            Bitmap resultImage = new Bitmap(image.Width, image.Height);

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color pixelColor = ((Bitmap)image).GetPixel(i, j);
                    Color addColor = Color.FromArgb((pixelColor.R + value).Clamp<int>(0, 255), (pixelColor.G + value).Clamp<int>(0, 255), (pixelColor.B + value).Clamp<int>(0, 255));

                    resultImage.SetPixel(i, j, addColor);
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
                    Color pixelColor = image.GetPixel(i, j);
                    Color subtractColor = Color.FromArgb(
                        (pixelColor.R - value).Clamp<int>(0, 255),
                        (pixelColor.G - value).Clamp<int>(0, 255),
                        (pixelColor.B - value).Clamp<int>(0, 255)
                    );

                    resultImage.SetPixel(i, j, subtractColor);
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
                    Color pixelColor = ((Bitmap)image).GetPixel(i, j);
                    Color multiplyColor = Color.FromArgb((pixelColor.R * value).Clamp<int>(0, 255), (pixelColor.G * value).Clamp<int>(0, 255), (pixelColor.B * value).Clamp<int>(0, 255));

                    resultImage.SetPixel(i, j, multiplyColor);
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
                        Color pixelColor = ((Bitmap)image).GetPixel(i, j);
                        Color dividedColor = Color.FromArgb((pixelColor.R / value).Clamp<int>(0, 255), (pixelColor.G / value).Clamp<int>(0, 255), (pixelColor.B / value).Clamp<int>(0, 255));

                        resultImage.SetPixel(i, j, dividedColor);
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
       
    }
}
