using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenCvSharp;
using System.Windows.Forms;

namespace ProjektAlgorytmyObrazów.Functions
{
    public class lab6
    {
        public static Mat ChooseSTRUCTUREtoLAB6Mask(Mat image)
        {
            Form chooseMaskForm = new Form();
            Mat selectedMask = new Mat();

            // Ustawienia formularza
            chooseMaskForm.Text = "Wybierz Kształt";
            chooseMaskForm.Size = new System.Drawing.Size(400, 220);
            chooseMaskForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            chooseMaskForm.MaximizeBox = false;


            ComboBox comboBox1 = new ComboBox();
            comboBox1.Items.AddRange(new object[] { "Krzyż", "Dysk" });
            comboBox1.Location = new System.Drawing.Point(50, 30);
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
            chooseMaskForm.Controls.Add(comboBox1);


            ComboBox comboBox2 = new ComboBox();
            comboBox2.Items.AddRange(new object[] { "3x3", "5x5" });
            comboBox2.Location = new System.Drawing.Point(200, 30);
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.SelectedIndex = 0;
            chooseMaskForm.Controls.Add(comboBox2);

            // Przycisk na formularzu
            Button button = new Button();
            button.Text = "Zatwierdź";
            button.Location = new System.Drawing.Point(150, 120);
            button.Click += (s, args) =>
            {
                int selectedOption1 = comboBox1.SelectedIndex;
                int selectedOption2 = comboBox2.SelectedIndex;
                if (selectedOption1 == 1)
                {
                    if (selectedOption2 == 1)
                    {
                        //ApplyErosion(image, MorphShapes.Cross)
                    }
                    else
                    { 
                    }

                }
                else
                {
                    if (selectedOption2 == 1)
                    {
                    }
                    else
                    {
                    }
                }

                chooseMaskForm.Close();
            };
            chooseMaskForm.Controls.Add(button);

            // Pokaż formularz
            chooseMaskForm.ShowDialog();
            return selectedMask;
        }
        public static Bitmap ApplyErosion(Mat inputImage, MorphShapes shape, OpenCvSharp.Size size)
        {
            Mat outputImage = new Mat();

            // Tworzymy element strukturalny (kernel)
            Mat element = Cv2.GetStructuringElement(shape, size);

            // Stosujemy erozję
            Cv2.Erode(inputImage, outputImage, element);

            return ImageConverters.ConvertMatToBitmap(outputImage);
        }
    }
}
