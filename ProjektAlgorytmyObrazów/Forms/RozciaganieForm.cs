using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProjektAlgorytmyObrazów.Modele
{
    public class RozciaganieForm : Form
    {
        public ImageObject activeImage { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int NewMin { get; set; }
        public int NewMax { get; set; }

        private Label labelMin;
        private Label labelMax;
        private Label labelNewMin;
        private Label labelNewMax;
        private TextBox textBoxMin;
        private TextBox textBoxMax;
        private TextBox textBoxNewMin;
        private TextBox textBoxNewMax;
        private Button buttonApply;

        public RozciaganieForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.labelMin = new Label();
            this.labelMax = new Label();
            this.labelNewMin = new Label();
            this.labelNewMax = new Label();
            this.textBoxMin = new TextBox();
            this.textBoxMax = new TextBox();
            this.textBoxNewMin = new TextBox();
            this.textBoxNewMax = new TextBox();
            this.buttonApply = new Button();

            this.SuspendLayout();

            // Label and TextBox Configuration
            ConfigureLabelAndTextBox(labelMin, textBoxMin, "Min:", 20, 1);
            ConfigureLabelAndTextBox(labelMax, textBoxMax, "Max:", 60, 2);
            ConfigureLabelAndTextBox(labelNewMin, textBoxNewMin, "New Min:", 100, 3);
            ConfigureLabelAndTextBox(labelNewMax, textBoxNewMax, "New Max:", 140, 4);

            // Button Configuration
            this.buttonApply.Location = new System.Drawing.Point(12, 180);
            this.buttonApply.Size = new System.Drawing.Size(160, 23);
            this.buttonApply.Text = "Zastosuj";
            this.buttonApply.Click += ButtonApply_Click;

            this.Controls.Add(buttonApply);

            this.Name = "RozciaganieForm";
            this.ClientSize = new System.Drawing.Size(200, 220); // Ustaw rozmiar okna
            this.ResumeLayout(false);
        }
        private void ConfigureLabelAndTextBox(Label label, TextBox textBox, string labelText, int textBoxLocationY, int textBoxTabIndex)
        {
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(12, textBoxLocationY);
            label.Text = labelText;

            textBox.Location = new System.Drawing.Point(80, textBoxLocationY);
            textBox.Size = new System.Drawing.Size(100, 20);
            textBox.TabIndex = textBoxTabIndex;
            textBox.MaxLength = 3;

            this.Controls.Add(label);
            this.Controls.Add(textBox);

            // Attach event handler to validate input
            textBox.KeyPress += TextBox_KeyPress;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sprawdź, czy wprowadzony znak jest cyfrą, kontrolką (np. backspace) lub zmyślną kombinacją klawiszy
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignoruj wprowadzone znaki, które nie są cyframi, kontrolkami lub backspace
            }

            // Jeśli to backspace, nie sprawdzaj dalej
            if (e.KeyChar == '\b')
            {
                return;
            }

            // Sprawdź, czy wprowadzona wartość (po dodaniu wprowadzonego znaku) mieści się w zakresie 0-255
            if (!int.TryParse(((TextBox)sender).Text + e.KeyChar, out int value) || value < 0 || value > 255)
            {
                e.Handled = true; // Ignoruj wprowadzone znaki, jeśli wartość przekracza zakres 0-255
            }
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            // Pobierz wartości z TextBox-ów
            if (int.TryParse(textBoxMin.Text, out int minValue) &&
                int.TryParse(textBoxMax.Text, out int maxValue) &&
                int.TryParse(textBoxNewMin.Text, out int newMinValue) &&
                int.TryParse(textBoxNewMax.Text, out int newMaxValue))
            {

                int Min = minValue;
                int Max = maxValue;
                int NewMin = newMinValue;
                int NewMax = newMaxValue;
                if (activeImage!=null && activeImage.ImagePath != null && activeImage.ImagePath != "")
                { 
                    MessageBox.Show("GIT:"+Min+Max+ NewMin+ NewMax);

                }
                else
                {
                    MessageBox.Show("Najpierw wybierz aktywne zdjęcie!");

                }

            }
            else
            {
                MessageBox.Show("Wprowadź poprawne wartości liczbowe.");
            }
        }

        
       
    }
}
