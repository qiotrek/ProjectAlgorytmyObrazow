using OpenCvSharp;
using ProjektAlgorytmyObrazów.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektAlgorytmyObrazów.Functions
{
    public class Morfologia
    {
        public static Mat Morfology(ImageObject activeImage)
        {
            Mat image = Cv2.ImRead(activeImage.ImagePath, ImreadModes.Grayscale);

            Mat result = new Mat();


            // Utwórz element strukturalny dysk 3x3 i krzyż 3x3
            Mat elementDisk = Cv2.GetStructuringElement(MorphShapes.Ellipse, new Size(3, 3), new Point(-1, -1));
            Mat elementCross = Cv2.GetStructuringElement(MorphShapes.Cross, new Size(3, 3), new Point(-1, -1));

            Form chooseParameters = new Form();

            // Ustawienia formularza
            chooseParameters.Text = "Wybierz Kształt";
            chooseParameters.Size = new System.Drawing.Size(400, 220);
            chooseParameters.FormBorderStyle = FormBorderStyle.FixedSingle;
            chooseParameters.MaximizeBox = false;


            ComboBox shapeBox = new ComboBox();
            shapeBox.Items.AddRange(new object[] { "Krzyż", "Dysk" });
            shapeBox.Location = new System.Drawing.Point(50, 30);
            shapeBox.DropDownStyle = ComboBoxStyle.DropDownList;
            shapeBox.SelectedIndex = 0;
            chooseParameters.Controls.Add(shapeBox);


            ComboBox taskBox = new ComboBox();
            taskBox.Items.AddRange(new object[] { "Erozja", "Dylatacja", "Otwarcie","Zamknięcie" });
            taskBox.Location = new System.Drawing.Point(200, 30);
            taskBox.DropDownStyle = ComboBoxStyle.DropDownList;
            taskBox.SelectedIndex = 0;
            chooseParameters.Controls.Add(taskBox);

            // Przycisk na formularzu
            Button button = new Button();
            button.Text = "Zatwierdź";
            button.Location = new System.Drawing.Point(150, 120);
            button.Click += (s, args) =>
            {
                int selectedShape = shapeBox.SelectedIndex;
                int selectedTask = taskBox.SelectedIndex;

                switch (selectedTask)
                {
                    case 0:
                        Cv2.Erode(image, result, selectedShape == 0 ? elementCross : elementDisk, new Point(-1, -1), 1, BorderTypes.Constant, new Scalar(255, 255, 255));
                        break;
                    case 1:
                        Cv2.Dilate(image, result, selectedShape == 0 ? elementCross : elementDisk, new Point(-1, -1), 1, BorderTypes.Constant, new Scalar(255, 255, 255));
                        break;
                    case 2:
                        Cv2.MorphologyEx(image, result, MorphTypes.Open, selectedShape == 0 ? elementCross : elementDisk, new Point(-1, -1), 1, BorderTypes.Constant, new Scalar(255, 255, 255));
                        break;
                    case 3:
                        Cv2.MorphologyEx(image, result, MorphTypes.Close, selectedShape == 0 ? elementCross : elementDisk, new Point(-1, -1), 1, BorderTypes.Constant, new Scalar(255, 255, 255));
                        break;
                }

                chooseParameters.Close();
            };
            chooseParameters.Controls.Add(button);

            // Pokaż formularz
            chooseParameters.ShowDialog();


            return result;
        }
    }
}
