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
    public class Rozciaganie2skladnikowe
    {
        public static Bitmap Rozciaganie(ImageObject activeImage)
        {
            Form chooseParameters = new Form();
            Bitmap result = new Bitmap(activeImage.Image.Width, activeImage.Image.Height);
            // Ustawienia formularza
            chooseParameters.Text = "Wybierz Parametry";
            chooseParameters.Size = new System.Drawing.Size(400, 220);
            chooseParameters.FormBorderStyle = FormBorderStyle.FixedSingle;
            chooseParameters.MaximizeBox = false;

            // Pole do wprowadzenia pierwszej wartości int
            TextBox firstValueTextBox = new TextBox();
            firstValueTextBox.Location = new System.Drawing.Point(50, 70);
            chooseParameters.Controls.Add(firstValueTextBox);

            // Pole do wprowadzenia drugiej wartości int
            TextBox secondValueTextBox = new TextBox();
            secondValueTextBox.Location = new System.Drawing.Point(200, 70);
            chooseParameters.Controls.Add(secondValueTextBox);

            // Przycisk na formularzu
            Button button = new Button();
            button.Text = "Zatwierdź";
            button.Location = new System.Drawing.Point(150, 120);
            button.Click += (s, args) =>
            {

               
                if (int.TryParse(firstValueTextBox.Text, out int firstValue) && int.TryParse(secondValueTextBox.Text, out int secondValue))
                {

                    int lowerValue = firstValue;
                    int higherValue = secondValue;
                    int localMinValue = activeImage.statistics.Min;
                    int localMaxValue = activeImage.statistics.Max;
                    Bitmap stretchedImage = new Bitmap(activeImage.Image.Width, activeImage.Image.Height);

                    for (int i = 0; i < activeImage.Image.Width; i++)
                    {
                        for (int j = 0; j < activeImage.Image.Height; j++)
                        {
                            Color pixelColor = ((Bitmap)activeImage.Image).GetPixel(i, j);
                            Color stretchedColor;

                            if (pixelColor.R < (lowerValue == -1 ? localMinValue : lowerValue))
                            {
                                stretchedColor = Color.Black;
                            }
                            else if (pixelColor.R >= (higherValue == -1 ? localMaxValue : higherValue))
                            {
                                stretchedColor = Color.White;
                            }
                            else
                            {
                                int value = (int)Math.Round((double)((pixelColor.R - (lowerValue == -1 ? localMinValue : lowerValue)) * 255 / ((higherValue == -1 ? localMaxValue : higherValue) - (lowerValue == -1 ? localMinValue : lowerValue))));
                                stretchedColor = Color.FromArgb(value, value, value);
                            }
                            stretchedImage.SetPixel(i, j, stretchedColor);
                        }
                    }
                    result= stretchedImage;
                }
                else
                {
                    // Jeśli wprowadzone wartości nie są liczbami całkowitymi, wyświetl komunikat
                    MessageBox.Show("Wprowadź poprawne wartości całkowite.");
                }

                // Zamknij formularz po kliknięciu przycisku "Zatwierdź"
                chooseParameters.Close();

                
            };
            chooseParameters.Controls.Add(button);

            // Pokaż formularz
            chooseParameters.ShowDialog();

            return result;
        }

    }
}
    