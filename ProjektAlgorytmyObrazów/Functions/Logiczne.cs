using OpenCvSharp;
using System;
using System.Collections.Generic;
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
    }
}
