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

        public HistoForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.chartHistogram = new Chart();
            this.pictureBoxImage = new PictureBox();

            this.SuspendLayout();

            // Konfiguracja kontrolki PictureBox dla wyświetlenia obrazu
            this.pictureBoxImage.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxImage.Size = new System.Drawing.Size(300, 300);

            // Konfiguracja kontrolki Chart do rysowania histogramu
            this.chartHistogram.Location = new System.Drawing.Point(12, 318);
            this.chartHistogram.Size = new System.Drawing.Size(300, 200);
            this.chartHistogram.Series.Add("Histogram");
            this.chartHistogram.ChartAreas.Add(new ChartArea());

            this.Controls.Add(pictureBoxImage);
            this.Controls.Add(chartHistogram);

            this.Name = "HistoForm";
            this.ResumeLayout(false);
        }

        public void DisplayHistogram(byte[] lut)
        {
            // Oblicz histogram na podstawie tablicy LUT
            int[] histogram = new int[256];
            for (int i = 0; i < lut.Length; i++)
            {
                histogram[lut[i]]++;
            }

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
    }
}
