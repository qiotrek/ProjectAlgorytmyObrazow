using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace ProjektAlgorytmyObrazów.Functions
{
    public class CustomForms
    {
        public static int GetValueForm(string windowTitle, string labelTitle)
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


        public static Mat ChooseLaplacianMask()
        {
            Form chooseMaskForm = new Form();
            Mat selectedMask = new Mat();

            // Ustawienia formularza
            chooseMaskForm.Text = "Wybierz Maskę Laplasjanową";
            chooseMaskForm.Size = new System.Drawing.Size(400, 380);
            chooseMaskForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            chooseMaskForm.MaximizeBox = false;

            // Grupa radiowa na formularzu
            GroupBox groupBox = new GroupBox();
            groupBox.Text = "Wybierz maskę:";
            groupBox.Size = new System.Drawing.Size(300, 240);
            groupBox.Location = new System.Drawing.Point(50, 10);
            chooseMaskForm.Controls.Add(groupBox);

            // Opcja radio 1
            RadioButton radio1 = new RadioButton();
            radio1.Text = "Maska 1:\n0 -1 0\n-1 4 -1\n0 -1 0";
            radio1.Size = new System.Drawing.Size(160, 60);
            radio1.Location = new System.Drawing.Point(10, 20);
            radio1.Checked = true;
            groupBox.Controls.Add(radio1);

            // Opcja radio 2
            RadioButton radio2 = new RadioButton();
            radio2.Text = "Maska 2:\n-1 -1 -1\n-1 8 -1\n-1 -1 -1";
            radio2.Size = new System.Drawing.Size(160, 60);
            radio2.Location = new System.Drawing.Point(10, 90);
            groupBox.Controls.Add(radio2);

            // Opcja radio 3
            RadioButton radio3 = new RadioButton();
            radio3.Text = "Maska 3:\n1 -2 1\n-2 4 -2\n1 -2 1";
            radio3.Size = new System.Drawing.Size(160, 60);
            radio3.Location = new System.Drawing.Point(10, 160);
            groupBox.Controls.Add(radio3);

            // Przycisk na formularzu
            Button button = new Button();
            button.Text = "Zatwierdź";
            button.Location = new System.Drawing.Point(150, 280);
            button.Click += (s, args) =>
            {             
                if (radio1.Checked)
                    selectedMask = new Mat(3, 3, MatType.CV_32S, new int[]
                    {
                            0, -1, 0,
                            -1, 4, -1,
                            0, -1, 0
                    });
                else if (radio2.Checked)
                    selectedMask = new Mat(3, 3, MatType.CV_32S, new int[]
                    {
                            -1, -1, -1,
                            -1, 8, -1,
                            -1, -1, -1
                    });
                else if (radio3.Checked)
                    selectedMask = new Mat(3, 3, MatType.CV_32S, new int[]
                    {
                            1, -2, 1,
                            -2, 4, -2,
                            1, -2, 1
                    });

                chooseMaskForm.Close();
            };
            chooseMaskForm.Controls.Add(button);
            // Pokaż formularz
            chooseMaskForm.ShowDialog();
            return selectedMask;
        }

       
    }
}
