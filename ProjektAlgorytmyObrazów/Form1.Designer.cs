using ProjektAlgorytmyObrazów.Modele;
using ProjektAlgorytmyObrazów.Functions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OpenCvSharp;
using System.Runtime.InteropServices;
using System.IO;

namespace ProjektAlgorytmyObrazów
{
    public partial class Form1
    {
        private List<ImageObject> images = new List<ImageObject>();
        public ImageObject activeImage = null;
        private ImageForm activeForm = null;
        RozciaganieForm rozciaganieForm = new RozciaganieForm();

        public ImageObject AddImage(string imagePath)
        {
            ImageObject image = new ImageObject(imagePath);
            images.Add(image);
            return image;
        }
        public ImageObject AddImage(Image image)
        {
            ImageObject image2 = new ImageObject(image=image);
            images.Add(image2);
            return image2;
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
            this.RozciąganieLiniowe = new System.Windows.Forms.Button();
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
            // RozciąganieLiniowe
            // 
            this.RozciąganieLiniowe.Location = new System.Drawing.Point(374, 2);
            this.RozciąganieLiniowe.Name = "RozciąganieLiniowe";
            this.RozciąganieLiniowe.Size = new System.Drawing.Size(141, 33);
            this.RozciąganieLiniowe.TabIndex = 3;
            this.RozciąganieLiniowe.Text = "RozciąganieLiniowe";
            this.RozciąganieLiniowe.UseVisualStyleBackColor = true;
            this.RozciąganieLiniowe.Click += new System.EventHandler(this.ShowRozciaganieForm);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 129);
            this.Controls.Add(this.RozciąganieLiniowe);
            this.Controls.Add(this.Histogram);
            this.Controls.Add(this.Zapisz);
            this.Controls.Add(this.Duplikuj);
            this.Controls.Add(this.Wczytaj);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Wczytaj;
        private System.Windows.Forms.Button Duplikuj;
        private System.Windows.Forms.Button Zapisz;
        private System.Windows.Forms.Button Histogram;
        private Button RozciąganieLiniowe;

        private void ShowRozciaganieForm(object sender, EventArgs e) {
            if (activeImage == null)
            {
                MessageBox.Show("Najpierw wybierz aktywne zdjęcie");
            }
            else {
                bool przesycenie = ShowPrzesycenieCheckboxForm();
                Image image = activeImage.Image;
                Bitmap bitmap = new Bitmap(image);
                if (przesycenie)
                {
                }
                Bitmap strechedImage =StretchHistogram(bitmap);
                CreateNewForm((Image)strechedImage, "Wczytany Obraz");

            }
            //CreateNewRozciaganieForm("Rozciaganie Liniowe");
         
        }
        public static Bitmap StretchHistogram(Bitmap originalImage)
        {
            int minIntensity = 255;
            int maxIntensity = 0;

            // Znajdź minimalną i maksymalną intensywność piksela w obrazie
            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color pixelColor = originalImage.GetPixel(x, y);
                    int intensity = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);

                    if (intensity < minIntensity)
                        minIntensity = intensity;

                    if (intensity > maxIntensity)
                        maxIntensity = intensity;
                }
            }

            // Rozciągnięcie histogramu
            Bitmap stretchedImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color pixelColor = originalImage.GetPixel(x, y);
                    int intensity = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);

                    // Rozciągnięcie liniowe
                    int stretchedIntensity = (int)((intensity - minIntensity) / (double)(maxIntensity - minIntensity) * 255);

                    Color newColor = Color.FromArgb(stretchedIntensity, stretchedIntensity, stretchedIntensity);
                    stretchedImage.SetPixel(x, y, newColor);
                }
            }

            return stretchedImage;
        }
        private bool ShowPrzesycenieCheckboxForm() {
            Form rozciaganieForm = new Form();
            bool result = false;
            // Ustawienia formularza
            rozciaganieForm.Text = "Rozciaganie Liniowe";
            rozciaganieForm.Size = new System.Drawing.Size(300, 150);
            rozciaganieForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            rozciaganieForm.MaximizeBox = false;

            // Tekst na formularzu
            Label label = new Label();
            label.Text = "Przesycenie?";
            label.Location = new System.Drawing.Point(115, 10);
            rozciaganieForm.Controls.Add(label);

            // Checkbox na formularzu
            CheckBox checkBox = new CheckBox();
            checkBox.Location = new System.Drawing.Point(140, 30);
            rozciaganieForm.Controls.Add(checkBox);

            // Przycisk na formularzu
            Button button = new Button();
            button.Text = "Zatwierdź";
            button.Location = new System.Drawing.Point(110, 60);
            button.Click += (s, args) =>
            {
                if (checkBox.Checked)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                rozciaganieForm.Close();
            };
            rozciaganieForm.Controls.Add(button);

            // Pokaż formularz
            rozciaganieForm.ShowDialog();

            return result;
        }
        private void CreateNewRozciaganieForm( string formTitle) {

            rozciaganieForm.Text = formTitle;
            rozciaganieForm.Min = 0;
            rozciaganieForm.Max = 255;
            rozciaganieForm.NewMin = 0;
            rozciaganieForm.NewMax = 255;
            rozciaganieForm.activeImage = activeImage;
            rozciaganieForm.Show();
        }
        private void HistogramFn(object sender, EventArgs e)
        {
            if (activeImage != null)
            {
                Mat Image=new Mat();
                if (activeImage.ImagePath != null)
                {
                    Image = new Mat(activeImage.ImagePath);
                }
                else
                {
                    string path = "C:\\Users\\piotr\\Pictures\\Props";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string name = "prop-"+ Guid.NewGuid();
                    string filePath = Path.Combine(path, name);
                    activeImage.ImagePath = filePath;
                    activeImage.Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                    Image=new Mat(filePath);
                }
                //Mat grayscaleImage = new Mat();
                //Cv2.CvtColor(Image, Image, ColorConversionCodes.BGR2GRAY);

                int[] lutTable;
      
                    // Obraz kolorowy - generuj trzy tablice LUT dla każdego kanału RGB
                    List<byte>[] channelPixels = SplitChannels(Image);

                
                    int[] lutB = CreateLUT(channelPixels[0].ToList());
                    activeImage.statisticsB = MathFns.CalculateStatistics(channelPixels[0], lutB);
                    activeImage.histogramB = lutB;

                    int[] lutG = CreateLUT(channelPixels[1].ToList());
                    activeImage.statisticsG = MathFns.CalculateStatistics(channelPixels[1], lutG);
                    activeImage.histogramG = lutG;


                    int[] lutR = CreateLUT(channelPixels[2].ToList());
                    activeImage.statisticsR = MathFns.CalculateStatistics(channelPixels[2], lutR);
                    activeImage.histogramR = lutR;

                    bool areLUTsEqual = lutR.SequenceEqual(lutB) && lutB.SequenceEqual(lutG);

                    if (areLUTsEqual)
                    {

                        activeImage.histogram = lutG;
                        activeImage.statistics = MathFns.CalculateStatistics(channelPixels[1], lutG);
                        ShowGreyScaleHistogram(lutG);
                        
                    }
                    else {
                        ShowRGBHistogram(lutR, lutG, lutB);
                    }
                   
                


            }
            else
            {
                MessageBox.Show("Najpierw wczytaj obraz przed próbą utworzenia histogramu.");
            }
        }

        private void ShowGreyScaleHistogram(int[] lutTable) {

            HistoForm histoForm = new HistoForm();
            histoForm.Text = "Histogram";
            histoForm.Size = new System.Drawing.Size(350, 600);

            // Wyświetlanie histogramu w HistoForm
            histoForm.DisplayHistogram(lutTable);

            // Opcjonalnie możesz także wyświetlić oryginalny obraz
            Image imageToShow = Image.FromFile(activeImage.ImagePath);
            histoForm.DisplayImage(imageToShow);
            histoForm.DisplayStatistics(activeImage.statistics.Mediana, activeImage.statistics.Min, activeImage.statistics.Max, activeImage.statistics.OdchStand);

            // Wyświetlanie formularza
            histoForm.Show();
        }

        private void ShowRGBHistogram(int[] lutTableR, int[] lutTableG, int[] lutTableB)
        {
            HistoForm histoForm = new HistoForm();
            histoForm.Text = "Histogram";
            histoForm.Size = new System.Drawing.Size(350, 815); // Dostosuj szerokość okna do trzech histogramów

            // Wyświetlanie histogramu RGB w HistoForm
            histoForm.DisplayHistogramRGB(lutTableR, lutTableG, lutTableB);

            // Opcjonalnie możesz także wyświetlić oryginalny obraz
            Image imageToShow = Image.FromFile(activeImage.ImagePath);
            histoForm.DisplayImage(imageToShow);
            histoForm.DisplayStatisticsRGB(activeImage.statisticsR,activeImage.statisticsG,activeImage.statisticsB);

            // Wyświetlanie formularza
            histoForm.Show();
        }

        private List<byte>[] SplitChannels(Mat colorImage)
        {
            List<byte>[] channels = new List<byte>[3];
            for (int i = 0; i < 3; i++)
            {
                channels[i] = MatToListBytes(colorImage.ExtractChannel(i));
            }
            return channels;
        }
        private List<byte> MatToListBytes (Mat mat)
        {
            List<byte> byteList = new List<byte>();

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
            var histogram = new int[256]; ;
            if (pixels.Count > 0)
            {
             
                int i, iVal;

                for (i = 0; i < 256; ++i)
                    histogram[i] = 0;

                for (i = 0; i < pixels.Count; ++i)
                {
                    iVal = (byte)(pixels[i]);
                    ++histogram[iVal];

                }
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
                //Mat loadedImage = Cv2.ImRead(selectedFilePath);
                //int channels = loadedImage.Channels();
            }
           
        }

        private void DuplikujFn(object sender, EventArgs e)
        {
            if (activeImage != null)
            {
                CreateNewForm(activeImage.ImagePath, "Duplikat Obrazu");
            }
            else
            {
                MessageBox.Show("Najpierw wczytaj obraz przed próbą duplikacji.");
            }
            //if (activeImage != null)
            //{
            //    // Load the color image
            //    Mat colorImage = Cv2.ImRead(activeImage.ImagePath);

            //    // Convert the color image to grayscale
            //    Mat grayscaleImage = new Mat();
            //    Cv2.CvtColor(colorImage, grayscaleImage, ColorConversionCodes.BGR2GRAY);

            //    // Save the grayscale image
            //    string outputPath = "C:\\Users\\piotr\\Pictures\\grayscale_image.jpg";  // Replace with your desired path and filename
            //    Cv2.ImWrite(outputPath, grayscaleImage);

            //    // Optionally, create a new form with the grayscale image
            //    // CreateNewForm(outputPath, "Duplikat Obrazu");
            //}
            //else
            //{
            //    MessageBox.Show("Najpierw wczytaj obraz przed próbą duplikacji.");
            //}
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

        private void CreateNewForm(string filePath, string formTitle)
        {
            // Utwórz nowe okno dla wyświetlenia obrazu
            ImageForm imageForm = new ImageForm();
            imageForm.Text = formTitle;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile(filePath);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Skalowanie obrazu do rozmiaru okna

            ConfigureImageForm(imageForm, pictureBox, filePath);
        }

        private void CreateNewForm(Image image, string formTitle)
        {
            // Utwórz nowe okno dla wyświetlenia obrazu
            ImageForm imageForm = new ImageForm();
            imageForm.Text = formTitle;
          
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Skalowanie obrazu do rozmiaru okna

            ConfigureImageForm(imageForm, pictureBox, null, image);
        }

        private void ConfigureImageForm(ImageForm imageForm, PictureBox pictureBox, string filePath,Image image=null)
        {
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

            if (filePath != null)
            {
                imageForm.Image = AddImage(filePath);
                imageForm.FormClosed += (s, ev) =>
                {
                    if (imageForm.Image == activeImage)
                    {
                        activeImage = null;
                    }
                    RemoveImage(imageForm.Image.Id);

                };
            }
            else if (image != null)
            { 
                imageForm.Image = AddImage(image);
                imageForm.FormClosed += (s, ev) =>
                {
                    if (imageForm.Image == activeImage)
                    {
                        activeImage = null;
                    }
                    RemoveImage(imageForm.Image.Id);

                };

            }

            // Pokaż nowe okno
            imageForm.Show();
            imageForm.Refresh();

        }

        private void SetActiveImageForm(ImageForm imageForm)
        {
            activeImage = imageForm.Image;
            rozciaganieForm.activeImage = activeImage;
            if (activeForm != null)
            {
                // Oznacz poprzednie okno jako nieaktywne
                activeForm.Text = "Wczytany Obraz";
            }

            // Ustaw nowe okno jako aktywne
            activeForm = imageForm;
            imageForm.Text = imageForm.Text+" (Aktywne)";
        }

        
    }


}

