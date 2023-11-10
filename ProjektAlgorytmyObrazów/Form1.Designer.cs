using ProjektAlgorytmyObrazów.Modele;
using ProjektAlgorytmyObrazów.Functions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OpenCvSharp;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;


namespace ProjektAlgorytmyObrazów
{
    partial class Form1
    {
        private List<ImageObject> images = new List<ImageObject>();
        private ImageObject activeImage = null;
        private ImageForm activeForm = null;

        public ImageObject AddImage(string imagePath)
        {
            ImageObject image = new ImageObject(imagePath);
            images.Add(image);
            return image;
        }
        public void RemoveImage(string id)
        {
            ImageObject imageToRemove = images.FirstOrDefault(img => img.Id == id);

            if (imageToRemove != null)
            {
                images.Remove(imageToRemove);
            }
        }

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.Wczytaj = new System.Windows.Forms.Button();
            this.Duplikuj = new System.Windows.Forms.Button();
            this.Zapisz = new System.Windows.Forms.Button();
            this.Histogram = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Wczytaj
            // 
            this.Wczytaj.Location = new System.Drawing.Point(3, 2);
            this.Wczytaj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Wczytaj.Name = "Wczytaj";
            this.Wczytaj.Size = new System.Drawing.Size(75, 33);
            this.Wczytaj.TabIndex = 0;
            this.Wczytaj.Text = "Wczytaj";
            this.Wczytaj.UseVisualStyleBackColor = true;
            this.Wczytaj.Click += new System.EventHandler(this.WczytajFn);
            // 
            // Duplikuj
            // 
            this.Duplikuj.Location = new System.Drawing.Point(83, 2);
            this.Duplikuj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Duplikuj.Name = "Duplikuj";
            this.Duplikuj.Size = new System.Drawing.Size(88, 33);
            this.Duplikuj.TabIndex = 1;
            this.Duplikuj.Text = "Duplikuj";
            this.Duplikuj.UseVisualStyleBackColor = true;
            this.Duplikuj.Click += new System.EventHandler(this.DuplikujFn);
            // 
            // Zapisz
            // 
            this.Zapisz.Location = new System.Drawing.Point(176, 2);
            this.Zapisz.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Zapisz.Name = "Zapisz";
            this.Zapisz.Size = new System.Drawing.Size(93, 33);
            this.Zapisz.TabIndex = 2;
            this.Zapisz.Text = "Zapisz";
            this.Zapisz.UseVisualStyleBackColor = true;
            this.Zapisz.Click += new System.EventHandler(this.ZapiszFn);
            // 
            // Histogram
            // 
            this.Histogram.Location = new System.Drawing.Point(275, 2);
            this.Histogram.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Histogram.Name = "Histogram";
            this.Histogram.Size = new System.Drawing.Size(93, 33);
            this.Histogram.TabIndex = 2;
            this.Histogram.Text = "Histogram";
            this.Histogram.UseVisualStyleBackColor = true;
            this.Histogram.Click += new System.EventHandler(this.HistogramFn);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 129);
            this.Controls.Add(this.Histogram);
            this.Controls.Add(this.Zapisz);
            this.Controls.Add(this.Duplikuj);
            this.Controls.Add(this.Wczytaj);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Wczytaj;
        private System.Windows.Forms.Button Duplikuj;
        private System.Windows.Forms.Button Zapisz;
        private System.Windows.Forms.Button Histogram;

        private void HistogramFn(object sender, EventArgs e)
        {

            if (activeImage != null)
            {

    
                Mat colorImage = new Mat(activeImage.ImagePath, ImreadModes.Color);
                Mat grayscaleImage = new Mat();
                Cv2.CvtColor(colorImage, grayscaleImage, ColorConversionCodes.BGR2GRAY);

                if (colorImage.Channels() == 3)
                {
                    // Obraz kolorowy - przekształć na szaro-skalowy
                    Cv2.CvtColor(colorImage, grayscaleImage, ColorConversionCodes.BGR2GRAY);
                }

                List<byte> pixels = MatToListBytes(grayscaleImage);

                int[] lutTable=CreateLUT(pixels);
                // Tworzenie instancji HistoForm
                HistoForm histoForm = new HistoForm();
                histoForm.Text = "Histogram";
                histoForm.Size = new System.Drawing.Size(350, 600);

                // Wyświetlanie histogramu w HistoForm
                histoForm.DisplayHistogram(lutTable);

                // Opcjonalnie możesz także wyświetlić oryginalny obraz
                Image imageToShow = Image.FromFile(activeImage.ImagePath);
                histoForm.DisplayImage(imageToShow);
                histoForm.DisplayStatistics(activeImage.statistics.Mediana,activeImage.statistics.Min,activeImage.statistics.Max,activeImage.statistics.OdchStand   );

                // Wyświetlanie formularza
                histoForm.Show();
            }
            else
            {
                MessageBox.Show("Najpierw wczytaj obraz przed próbą utworzenia histogramu.");
            }
            
        }
        List<byte> MatToListBytes (Mat mat)
        {
            List<byte> byteList = new List<byte>();

            if (mat.Channels() != 1)
            {
               // throw new InvalidOperationException("The input Mat must be a grayscale image.");
            }

            int width = mat.Width;
            int height = mat.Height;
            int step = (int)mat.Step(); // Szerokość w bajtach między kolejnymi wierszami

            byte[] bytes = new byte[width * height];
            Marshal.Copy(mat.Data, bytes, 0, width * height);
            byteList.AddRange(bytes);

            return byteList;
        }

        private int[] CreateLUT(List<byte> pixels)
        {
            var histogram = activeImage.histogram;
            if (pixels.Count > 0)
            {
             
                int i, iVal;

                for (i = 0; i < 256; ++i)
                    histogram[i] = 0;

                for (i = 0; i < pixels.Count; ++i)
                {
                    iVal = (byte)(pixels[i]);
                    ++histogram[iVal];

                    if (activeImage.statistics.Max == null || iVal > activeImage.statistics.Max)
                    {
                        activeImage.statistics.Max = iVal;
                    }
                    if (activeImage.statistics.Min == null || iVal < activeImage.statistics.Min)
                    {
                        activeImage.statistics.Min = iVal;
                    }
                }


                
                    
                
                MathFns.CalculateMedian(pixels, activeImage);
                MathFns.CalculateStandardDeviation(pixels, activeImage);
            }
            return histogram;
        }
       
       

       
        // Funkcja do przekształcania obrazu na podstawie tablicy LUT
       
        private void WczytajFn(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Obrazy|*.jpg;*.tif;*.png;*.bmp|Wszystkie pliki|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Pobranie ścieżki do wybranego pliku
                string selectedFilePath = openFileDialog.FileName;

                CreateNewForm(selectedFilePath, "Wczytany Obraz");
                

            }
        }

        private void DuplikujFn(object sender, EventArgs e)
        {
            if (activeImage!=null)
            {
                CreateNewForm(activeImage.ImagePath, "Duplikat Obrazu");
            }
            else
            {
                MessageBox.Show("Najpierw wczytaj obraz przed próbą duplikacji.");
            }
        }

        private void ZapiszFn(object sender, EventArgs e)
        {
            if (activeImage != null)
            {
                Image imageToSave = activeImage.Image;

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Pliki graficzne (*.png, *.jpg, *.tif, *.bmp)|*.png;*.jpg;*.tif;*.bmp";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Pobierz ścieżkę wybranej lokalizacji do zapisu
                    string savePath = saveFileDialog.FileName;

                    // Sprawdź, czy użytkownik wybrał lokalizację
                    if (!string.IsNullOrEmpty(savePath))
                    {
                        try
                        {
                            // Zapisz obraz na wybranej lokalizacji
                            imageToSave.Save(savePath);

                            MessageBox.Show("Obraz został zapisany pomyślnie.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Wystąpił błąd podczas zapisywania obrazu: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano aktywnego obrazu do zapisania.");
            }
        }

        private void CreateNewForm(string filePath ,string formTitle)
        {
            // Utwórz nowe okno dla wyświetlenia obrazu
            ImageForm imageForm = new ImageForm();
            imageForm.Text = formTitle;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile(filePath);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Skalowanie obrazu do rozmiaru okna

            imageForm.Controls.Add(pictureBox);

            // Wyśrodkowanie obrazu w oknie
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.MouseDown += (s, ev) =>
            {


                SetActiveImageForm(imageForm);

            };

            // Ustaw rozmiar okna na rozmiar obrazu
            imageForm.ClientSize = pictureBox.Image.Size;
            imageForm.Size = new System.Drawing.Size(400, 300);
            imageForm.Image = AddImage(filePath);


            imageForm.FormClosed += (s, ev) =>
            {

                if (imageForm.Image == activeImage)
                {
                    activeImage = null;
                }
                RemoveImage(imageForm.Image.Id);
                Console.Write("Zamknięto: " + imageForm.Image.Id);

            };
            // Pokaż nowe okno
            imageForm.Show();
            imageForm.Refresh();
            Console.Write("Utworzono: " + imageForm.Image.Id);

        }

        private void SetActiveImageForm(ImageForm imageForm)
        {
            activeImage = imageForm.Image;
            if (activeForm != null)
            {
                // Oznacz poprzednie okno jako nieaktywne
                activeForm.Text = "Wczytany Obraz";
            }

            // Ustaw nowe okno jako aktywne
            activeForm = imageForm;
            imageForm.Text = "Wczytany Obraz (Aktywne)";
        }

        
    }


}

