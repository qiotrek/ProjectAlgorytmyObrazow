using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProjektAlgorytmyObrazów.Modele
{
    public class LUTTableForm : Form
    {
        private DataGridView dataGridView;

        public LUTTableForm(ImageObject activeImage, bool isGrayscale)
        {
            InitializeComponents();

            if (isGrayscale&& activeImage.histogram!=null)
            {
                DisplayGrayscaleTable(activeImage.histogram);
            }
            else
            {
                DisplayRGBTable(activeImage.histogramR,activeImage.histogramG,activeImage.histogramB);
            }
        }

        private void InitializeComponents()
        {
            this.dataGridView = new DataGridView();

            this.SuspendLayout();

            // DataGridView configuration
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.RowHeadersVisible = false;

            this.Controls.Add(dataGridView);

            this.Name = "LUTTableForm";
            this.ResumeLayout(false);
        }

        private void DisplayGrayscaleTable(int[] lutData)
        {
            // Grayscale table with two columns: Pixel and Value
            DataTable table = new DataTable();
            table.Columns.Add("Piksel", typeof(int));
            table.Columns.Add("Wartość", typeof(int));
            this.dataGridView.Size = new System.Drawing.Size(200, 400);
            for (int i = 0; i < lutData.Length; i++)
            {
                table.Rows.Add(i, lutData[i]);
            }

            dataGridView.DataSource = table;
        }

        private void DisplayRGBTable(int[] lutDataR, int[] lutDataG, int[] lutDataB)
        {
            // RGB table with four columns: Pixel, Red, Green, Blue
            this.dataGridView.Size = new System.Drawing.Size(270, 400);

            DataTable table = new DataTable();
            table.Columns.Add("Piksel", typeof(int));
            table.Columns.Add("Red", typeof(int));
            table.Columns.Add("Green", typeof(int));
            table.Columns.Add("Blue", typeof(int));

      

            for (int i = 0; i < lutDataG.Length; i++)
            {
                table.Rows.Add(i, lutDataR[i], lutDataG[i], lutDataB[i]);
            }

            dataGridView.DataSource = table;
        }
    }
}
