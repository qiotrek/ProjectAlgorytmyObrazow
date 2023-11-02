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
    public class HistoForm : Form
    {
        public string Id;
        public ImageObject Image { get; set; }
        private Chart chartHistogram;
        private PictureBox pictureBoxImage;
        private Label labelMedian;
        private Label labelMin;
        private Label labelMax;
        private Label labelStdDev;

        public HistoForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.chartHistogram = new Chart();
            this.pictureBoxImage = new PictureBox();
            this.labelMedian = new Label();
            this.labelMin = new Label();
            this.labelMax = new Label();
            this.labelStdDev = new Label();

            this.SuspendLayout();

            // Konfiguracja kontrolki PictureBox dla wyświetlenia obrazu
            this.pictureBoxImage.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxImage.BackColor = Color.Black;
            this.pictureBoxImage.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;

            // Konfiguracja kontrolki Chart do rysowania histogramu
            this.chartHistogram.Location = new System.Drawing.Point(12, 318);
            this.chartHistogram.Size = new System.Drawing.Size(300, 200);
            this.chartHistogram.Series.Add("Histogram");
            this.chartHistogram.ChartAreas.Add(new ChartArea());

            // Dodaj opisy osi X i Y do wykresu
            this.chartHistogram.ChartAreas[0].AxisX.Title = "Wartość Piksela";
            this.chartHistogram.ChartAreas[0].AxisY.Title = "Liczba Pikseli";

            // Konfiguracja labeli do wyświetlania informacji
            this.labelMedian.Location = new Point(330, 12);
            this.labelMedian.AutoSize = true;
            this.labelMin.Location = new Point(330, 32);
            this.labelMin.AutoSize = true;
            this.labelMax.Location = new Point(330, 52);
            this.labelMax.AutoSize = true;
            this.labelStdDev.Location = new Point(330, 72);
            this.labelStdDev.AutoSize = true;

            this.Controls.Add(pictureBoxImage);
            this.Controls.Add(chartHistogram);
            this.Controls.Add(labelMedian);
            this.Controls.Add(labelMin);
            this.Controls.Add(labelMax);
            this.Controls.Add(labelStdDev);

            this.Name = "HistoForm";
            this.ResumeLayout(false);
        }

        public void DisplayHistogram(int[] histogram)
        {
            // Oblicz histogram na podstawie tablicy LUT
            //int[] histogram = new int[256];
            //for (int i = 0; i < lut.Length; i++)
            //{
            //    histogram[lut[i]]++;
            //}

            // Wyczyść istniejące dane z wykresu
            chartHistogram.Series["Histogram"].Points.Clear();

            // Dodaj dane histogramu do wykresu
            for (int i = 0; i < histogram.Length; i++)
            {
                chartHistogram.Series["Histogram"].Points.AddXY(i, histogram[i]);
            }
        }

        public void DisplayImage(Image image)
        {
            // Wyświetl obraz w kontrolce PictureBox
            pictureBoxImage.Image = image;
        }

        public void DisplayStatistics(double? median, int? min, int? max, double? stdDev)
        {
            // Wyświetl informacje o medianie, minimalnej, maksymalnej wartości i odchyleniu standardowym
            labelMedian.Text = $"Mediana: {(median!=null?median:0)}";
            labelMin.Text = $"Min: {(min != null ? min : 0)}";
            labelMax.Text = $"Max: {(max != null ? max : 0)}";
            labelStdDev.Text = $"Odchylenie Std: {(stdDev != null ? stdDev : 0)}";
        }
    }
}
