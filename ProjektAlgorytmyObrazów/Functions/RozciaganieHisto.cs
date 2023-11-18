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
    public class RozciaganieHisto
    {
        public static Bitmap LiczPrzesycenie(Bitmap originalImage)
        {

            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color pixelColor = originalImage.GetPixel(x, y);

                    pixelColor = Color.FromArgb(pixelColor.R / 2, pixelColor.G / 2, pixelColor.B / 2);
                    originalImage.SetPixel(x, y, pixelColor);
                }
            }

            return originalImage;
        }
        public static Bitmap StretchHistogram(Bitmap originalImage)
        {
            int minIntensity = 255;
            int maxIntensity = 0;

            // Znajdź minimalną i maksymalną intensywność piksela w obrazie
            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color pixelColor = originalImage.GetPixel(x, y);
                    int intensity = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);

                    if (intensity < minIntensity)
                        minIntensity = intensity;

                    if (intensity > maxIntensity)
                        maxIntensity = intensity;
                }
            }

            // Rozciągnięcie histogramu
            Bitmap stretchedImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color pixelColor = originalImage.GetPixel(x, y);
                    int intensity = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);

                    // Rozciągnięcie liniowe
                    int stretchedIntensity = (int)((intensity - minIntensity) / (double)(maxIntensity - minIntensity) * 255);

                    Color newColor = Color.FromArgb(stretchedIntensity, stretchedIntensity, stretchedIntensity);
                    stretchedImage.SetPixel(x, y, newColor);
                }
            }

            return stretchedImage;
        }
        public static bool ShowPrzesycenieCheckboxForm()
        {
            Form rozciaganieForm = new Form();
            bool result = false;
            // Ustawienia formularza
            rozciaganieForm.Text = "Rozciaganie Liniowe";
            rozciaganieForm.Size = new System.Drawing.Size(300, 150);
            rozciaganieForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            rozciaganieForm.MaximizeBox = false;

            // Tekst na formularzu
            Label label = new Label();
            label.Text = "Przesycenie?";
            label.Location = new System.Drawing.Point(115, 10);
            rozciaganieForm.Controls.Add(label);

            // Checkbox na formularzu
            CheckBox checkBox = new CheckBox();
            checkBox.Location = new System.Drawing.Point(140, 30);
            rozciaganieForm.Controls.Add(checkBox);

            // Przycisk na formularzu
            Button button = new Button();
            button.Text = "Zatwierdź";
            button.Location = new System.Drawing.Point(110, 60);
            button.Click += (s, args) =>
            {
                if (checkBox.Checked)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                rozciaganieForm.Close();
            };
            rozciaganieForm.Controls.Add(button);

            // Pokaż formularz
            rozciaganieForm.ShowDialog();

            return result;
        }
        
    }
}
