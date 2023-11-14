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
        private Label labelStats; // Nowy Label do wyświetlania statystyk

        public HistoForm()
        {
            InitializeComponents();
            //this.SizeChanged += HistoForm_SizeChanged;
        }

        private void InitializeComponents()
        {
            this.chartHistogram = new Chart();
            this.pictureBoxImage = new PictureBox();
            this.labelStats = new Label(); // Inicjalizacja nowego Label do statystyk

            this.SuspendLayout();

            // Konfiguracja kontrolki PictureBox dla wyświetlenia obrazu
            this.pictureBoxImage.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxImage.BackColor = Color.Black;
            this.pictureBoxImage.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;

            // Konfiguracja kontrolki Chart do rysowania histogramu szaroodcieniowego
            this.chartHistogram.Location = new System.Drawing.Point(12, 305);
            this.chartHistogram.Series.Add("Histogram");
            this.chartHistogram.ChartAreas.Add(new ChartArea());
            this.chartHistogram.ChartAreas[0].AxisX.Title = "Wartość Piksela";
            this.chartHistogram.ChartAreas[0].AxisY.Title = "Liczba Pikseli";


            // Konfiguracja Labela do wyświetlania informacji o statystykach
            this.labelStats.AutoSize = true;

            this.Controls.Add(pictureBoxImage);
            this.Controls.Add(chartHistogram);
            this.Controls.Add(labelStats);

            this.Name = "HistoForm";
            this.ResumeLayout(false);
            //UpdateHistogramSize();
        }

        public void DisplayHistogram(int[] histogram)
        {
            this.chartHistogram.Size = new System.Drawing.Size(300, 230);
            // Wyczyść istniejące dane z wykresu
            chartHistogram.Series["Histogram"].Points.Clear();
            chartHistogram.Series["Histogram"].Color = Color.Black;
            // Dodaj dane histogramu do wykresu
            for (int i = 1; i < histogram.Length; i++)
            {
                chartHistogram.Series["Histogram"].Points.AddXY(i, histogram[i]);
            }
        }
        public void DisplayHistogramRGB(int[] histogramR, int[] histogramG, int[] histogramB)
        {
            this.chartHistogram.Size = new System.Drawing.Size(300, 430);
            // Wyczyść istniejące dane z wykresu
            chartHistogram.Series.Clear();
            chartHistogram.ChartAreas.Clear(); // Dodaj tę linię, aby usunąć wcześniej zdefiniowane obszary wykresu

            // Dodaj nowe obszary wykresu dla każdego kanału RGB
            chartHistogram.ChartAreas.Add(new ChartArea("ChartAreaR"));
            chartHistogram.ChartAreas.Add(new ChartArea("ChartAreaG"));
            chartHistogram.ChartAreas.Add(new ChartArea("ChartAreaB"));

            this.chartHistogram.ChartAreas[0].AxisX.Title = "Wartość Piksela";
            this.chartHistogram.ChartAreas[0].AxisY.Title = "Liczba Pikseli";

            this.chartHistogram.ChartAreas[1].AxisX.Title = "Wartość Piksela";
            this.chartHistogram.ChartAreas[1].AxisY.Title = "Liczba Pikseli";

            this.chartHistogram.ChartAreas[2].AxisX.Title = "Wartość Piksela";
            this.chartHistogram.ChartAreas[2].AxisY.Title = "Liczba Pikseli";
            // Dodaj serie dla każdego kanału RGB
            AddHistogramSeries("Histogram R", histogramR, Color.Red, "ChartAreaR");
            AddHistogramSeries("Histogram G", histogramG, Color.Green, "ChartAreaG");
            AddHistogramSeries("Histogram B", histogramB, Color.Blue, "ChartAreaB");

        }

        private void AddHistogramSeries(string seriesName, int[] histogram, Color color, string chartAreaName)
        {
            Series series = new Series(seriesName);
            series.ChartType = SeriesChartType.Column;
            series.Color = color;

            // Dodaj dane histogramu do serii
            for (int i = 1; i < histogram.Length; i++)
            {
                series.Points.AddXY(i, histogram[i]);
            }

            // Dodaj serię do wykresu
            chartHistogram.Series.Add(series);

            // Przypisz serię do konkretnego obszaru wykresu
            chartHistogram.Series[seriesName].ChartArea = chartAreaName;
        }
        public void DisplayImage(Image image)
        {
            // Wyświetl obraz w kontrolce PictureBox
            pictureBoxImage.Image = image;
        }

        public void DisplayStatistics(double? median, int? min, int? max, double? stdDev)
        {
            this.labelStats.Location = new Point(12, 535);
            labelStats.Text = $"Mediana: {(median != null ? median : 0)} | Min: {(min != null ? min : 0)} | Max: {(max != null ? max : 0)} | Odchylenie Std: {(stdDev != null ? stdDev : 0)}";
        }
        public void DisplayStatisticsRGB(
                    Statiscics statR, Statiscics statG, Statiscics statB)
        {
            this.labelStats.Location = new Point(12, 735);
            labelStats.Text = $"R: Mediana: {(statR.Mediana != null ? statR.Mediana : 0)} | Min: {(statR.Min != null ? statR.Min : 0)} | Max: {(statR.Max != null ? statR.Max : 0)} | Odchylenie Std: {(statR.OdchStand != null ? statR.OdchStand : 0)}\n" +
                              $"G: Mediana: {(statG.Mediana != null ? statG.Mediana : 0)} | Min: {(statG.Min != null ? statG.Min : 0)} | Max: {(statG.Max != null ? statG.Max : 0)} | Odchylenie Std: {(statG.OdchStand != null ? statG.OdchStand : 0)}\n" +
                              $"B: Mediana: {(statB.Mediana != null ? statB.Mediana : 0)} | Min: {(statB.Min != null ? statB.Min : 0)} | Max: {(statB.Max != null ? statB.Max : 0)} | Odchylenie Std: {(statB.OdchStand != null ? statB.OdchStand : 0)}";
        }
    }
}
