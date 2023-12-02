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
using System.Drawing.Imaging;

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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.wczytajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplikujToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analizaToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lutTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageEditionToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.negacjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greyscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progowanieZZachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progowanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rozciaganieLinioweToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redukcjaSzarosciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manipulacjaHistoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gammaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.equalizacjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacjeLogiczneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nOTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aNDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aDDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenu,
            this.analizaToolStripMenu,
            this.imageEditionToolStripMenu,
            this.manipulacjaHistoToolStripMenuItem,
            this.operacjeLogiczneToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(669, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenu
            // 
            this.plikToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wczytajToolStripMenuItem,
            this.duplikujToolStripMenuItem,
            this.zapiszToolStripMenuItem});
            this.plikToolStripMenu.Name = "plikToolStripMenu";
            this.plikToolStripMenu.Size = new System.Drawing.Size(46, 24);
            this.plikToolStripMenu.Text = "Plik";
            this.plikToolStripMenu.Click += new System.EventHandler(this.wczytajToolStripMenuItem_Click);
            // 
            // wczytajToolStripMenuItem
            // 
            this.wczytajToolStripMenuItem.Name = "wczytajToolStripMenuItem";
            this.wczytajToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.wczytajToolStripMenuItem.Text = "Wczytaj";
            this.wczytajToolStripMenuItem.Click += new System.EventHandler(this.WczytajFn);
            // 
            // duplikujToolStripMenuItem
            // 
            this.duplikujToolStripMenuItem.Name = "duplikujToolStripMenuItem";
            this.duplikujToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.duplikujToolStripMenuItem.Text = "Duplikuj";
            this.duplikujToolStripMenuItem.Click += new System.EventHandler(this.DuplikujFn);
            // 
            // zapiszToolStripMenuItem
            // 
            this.zapiszToolStripMenuItem.Name = "zapiszToolStripMenuItem";
            this.zapiszToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.zapiszToolStripMenuItem.Text = "Zapisz";
            this.zapiszToolStripMenuItem.Click += new System.EventHandler(this.ZapiszFn);
            // 
            // analizaToolStripMenu
            // 
            this.analizaToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.histogramToolStripMenuItem,
            this.lutTableToolStripMenuItem});
            this.analizaToolStripMenu.Name = "analizaToolStripMenu";
            this.analizaToolStripMenu.Size = new System.Drawing.Size(72, 24);
            this.analizaToolStripMenu.Text = "Analiza";
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.histogramToolStripMenuItem.Text = "Histogram";
            this.histogramToolStripMenuItem.Click += new System.EventHandler(this.HistogramFn);
            // 
            // lutTableToolStripMenuItem
            // 
            this.lutTableToolStripMenuItem.Name = "lutTableToolStripMenuItem";
            this.lutTableToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.lutTableToolStripMenuItem.Text = "Tablica LUT";
            this.lutTableToolStripMenuItem.Click += new System.EventHandler(this.LUTTableFn);
            // 
            // imageEditionToolStripMenu
            // 
            this.imageEditionToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.negacjaToolStripMenuItem,
            this.greyscaleToolStripMenuItem,
            this.progowanieZZachToolStripMenuItem,
            this.progowanieToolStripMenuItem,
            this.rozciaganieLinioweToolStripMenuItem,
            this.redukcjaSzarosciToolStripMenuItem});
            this.imageEditionToolStripMenu.Name = "imageEditionToolStripMenu";
            this.imageEditionToolStripMenu.Size = new System.Drawing.Size(112, 24);
            this.imageEditionToolStripMenu.Text = "ImageEdition";
            // 
            // negacjaToolStripMenuItem
            // 
            this.negacjaToolStripMenuItem.Name = "negacjaToolStripMenuItem";
            this.negacjaToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.negacjaToolStripMenuItem.Text = "Negacja";
            this.negacjaToolStripMenuItem.Click += new System.EventHandler(this.NeagcjaFn);
            // 
            // greyscaleToolStripMenuItem
            // 
            this.greyscaleToolStripMenuItem.Name = "greyscaleToolStripMenuItem";
            this.greyscaleToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.greyscaleToolStripMenuItem.Text = "ToGreyScale";
            this.greyscaleToolStripMenuItem.Click += new System.EventHandler(this.ToGreyScaleFN);
            // 
            // progowanieZZachToolStripMenuItem
            // 
            this.progowanieZZachToolStripMenuItem.Name = "progowanieZZachToolStripMenuItem";
            this.progowanieZZachToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.progowanieZZachToolStripMenuItem.Text = "ProgowanieZZach";
            this.progowanieZZachToolStripMenuItem.Click += new System.EventHandler(this.ProgowanieFNGreyscaleLvl);
            // 
            // progowanieToolStripMenuItem
            // 
            this.progowanieToolStripMenuItem.Name = "progowanieToolStripMenuItem";
            this.progowanieToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.progowanieToolStripMenuItem.Text = "Progowanie";
            this.progowanieToolStripMenuItem.Click += new System.EventHandler(this.ProgowanieFN);
            // 
            // rozciaganieLinioweToolStripMenuItem
            // 
            this.rozciaganieLinioweToolStripMenuItem.Name = "rozciaganieLinioweToolStripMenuItem";
            this.rozciaganieLinioweToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.rozciaganieLinioweToolStripMenuItem.Text = "RozciaganieLiniowe";
            this.rozciaganieLinioweToolStripMenuItem.Click += new System.EventHandler(this.ShowRozciaganieFormFN);
            // 
            // redukcjaSzarosciToolStripMenuItem
            // 
            this.redukcjaSzarosciToolStripMenuItem.Name = "redukcjaSzarosciToolStripMenuItem";
            this.redukcjaSzarosciToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.redukcjaSzarosciToolStripMenuItem.Text = "RedukcjaPozSzarości";
            this.redukcjaSzarosciToolStripMenuItem.Click += new System.EventHandler(this.RedukcjaSzarosciFN);
            // 
            // manipulacjaHistoToolStripMenuItem
            // 
            this.manipulacjaHistoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gammaToolStripMenuItem1,
            this.equalizacjaToolStripMenuItem});
            this.manipulacjaHistoToolStripMenuItem.Name = "manipulacjaHistoToolStripMenuItem";
            this.manipulacjaHistoToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.manipulacjaHistoToolStripMenuItem.Text = "Manipulacja Histo";
            // 
            // gammaToolStripMenuItem1
            // 
            this.gammaToolStripMenuItem1.Name = "gammaToolStripMenuItem1";
            this.gammaToolStripMenuItem1.Size = new System.Drawing.Size(167, 26);
            this.gammaToolStripMenuItem1.Text = "Gamma";
            this.gammaToolStripMenuItem1.Click += new System.EventHandler(this.GammaFn);
            // 
            // equalizacjaToolStripMenuItem
            // 
            this.equalizacjaToolStripMenuItem.Name = "equalizacjaToolStripMenuItem";
            this.equalizacjaToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.equalizacjaToolStripMenuItem.Text = "Equalizacja";
            this.equalizacjaToolStripMenuItem.Click += new System.EventHandler(this.EqualizacjaFn);
            // 
            // operacjeLogiczneToolStripMenuItem
            // 
            this.operacjeLogiczneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nOTToolStripMenuItem,
            this.aNDToolStripMenuItem,
            this.oRToolStripMenuItem,
            this.xORToolStripMenuItem,
            this.aDDToolStripMenuItem});
            this.operacjeLogiczneToolStripMenuItem.Name = "operacjeLogiczneToolStripMenuItem";
            this.operacjeLogiczneToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.operacjeLogiczneToolStripMenuItem.Text = "Operacje Logiczne";
            // 
            // nOTToolStripMenuItem
            // 
            this.nOTToolStripMenuItem.Name = "nOTToolStripMenuItem";
            this.nOTToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.nOTToolStripMenuItem.Text = "NOT";
            this.nOTToolStripMenuItem.Click += new System.EventHandler(this.NOTFn);
            // 
            // aNDToolStripMenuItem
            // 
            this.aNDToolStripMenuItem.Name = "aNDToolStripMenuItem";
            this.aNDToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.aNDToolStripMenuItem.Text = "AND";
            this.aNDToolStripMenuItem.Click += new System.EventHandler(this.ANDFn);
            // 
            // oRToolStripMenuItem
            // 
            this.oRToolStripMenuItem.Name = "oRToolStripMenuItem";
            this.oRToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.oRToolStripMenuItem.Text = "OR";
            this.oRToolStripMenuItem.Click += new System.EventHandler(this.ORFn);
            // 
            // xORToolStripMenuItem
            // 
            this.xORToolStripMenuItem.Name = "xORToolStripMenuItem";
            this.xORToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.xORToolStripMenuItem.Text = "XOR";
            this.xORToolStripMenuItem.Click += new System.EventHandler(this.XORFn);
            // 
            // aDDToolStripMenuItem
            // 
            this.aDDToolStripMenuItem.Name = "aDDToolStripMenuItem";
            this.aDDToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.aDDToolStripMenuItem.Text = "ADD";
            this.aDDToolStripMenuItem.Click += new System.EventHandler(this.ADDFn);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 65);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "AlgorytmyPrzetwarzaniaObrazow";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void ADDFn(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Obrazy|*.jpg;*.tif;*.png;*.bmp|Wszystkie pliki|*.*";
            string secoundFilePath = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                secoundFilePath = openFileDialog.FileName;
            }
            Mat imageA = new Mat(activeImage.ImagePath);
            Mat imageB = new Mat(secoundFilePath);
            Mat resultImage = Logiczne.LogicalAdd(imageA, imageB);
            Cv2.ImShow("ADD Result", resultImage);
        }
        private void ANDFn(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Obrazy|*.jpg;*.tif;*.png;*.bmp|Wszystkie pliki|*.*";
            string secoundFilePath = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                secoundFilePath = openFileDialog.FileName;              
            }
            Mat imageA = new Mat(activeImage.ImagePath);
            Mat imageB = new Mat(secoundFilePath);
            Mat resultImage = Logiczne.LogicalAND(imageA, imageB);
            Cv2.ImShow("AND Result", resultImage);
        }
        private void ORFn(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Obrazy|*.jpg;*.tif;*.png;*.bmp|Wszystkie pliki|*.*";
            string secoundFilePath = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                secoundFilePath = openFileDialog.FileName;
            }
            Mat imageA = new Mat(activeImage.ImagePath);
            Mat imageB = new Mat(secoundFilePath);
            Mat resultImage = Logiczne.LogicalOR(imageA, imageB);
            Cv2.ImShow("OR Result", resultImage);
        }
        private void NOTFn(object sender, EventArgs e)
        {      
            Mat imageA = new Mat(activeImage.ImagePath);
            Mat resultImage = Logiczne.LogicalNOT(imageA);
            Cv2.ImShow("NOT Result", resultImage);
        }
        private void XORFn(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Obrazy|*.jpg;*.tif;*.png;*.bmp|Wszystkie pliki|*.*";
            string secoundFilePath = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                secoundFilePath = openFileDialog.FileName;
            }
            Mat imageA = new Mat(activeImage.ImagePath);
            Mat imageB = new Mat(secoundFilePath);
            Mat resultImage = Logiczne.LogicalXor(imageA, imageB);
            Cv2.ImShow("XOR Result", resultImage);
        }
        private void ShowRozciaganieFormFN(object sender, EventArgs e) {
            if (activeImage == null)
            {
                MessageBox.Show("Najpierw wybierz aktywne zdjęcie");
            }
            else {
                bool przesycenie = RozciaganieHisto.ShowPrzesycenieCheckboxForm();
                Image image = activeImage.Image;
                Bitmap bitmap = new Bitmap(image);
                Bitmap strechedImage=null;
                if (przesycenie)
                {
                    bitmap = RozciaganieHisto.LiczPrzesycenie(bitmap);
                }
                    
                strechedImage = RozciaganieHisto.StretchHistogram(bitmap);
                 
                CreateNewForm((Image)strechedImage, "RozciaganieLiniowe");

            }
            //CreateNewRozciaganieForm("Rozciaganie Liniowe");
         
        }
        private void EqualizacjaFn(object sender, EventArgs e) {
            bool valid = CheckAndPrepareActiveImage();
            if (valid)
            {
                if (activeImage.isGrayscale)
                {
                    int[] dystrybuanta = PrepareDystrybuanta(activeImage.histogram);
                    int[] equalizeLUT = EqualizacjaNewLUT(dystrybuanta);
                    Image newImage = ManipulacjaHisto.LUTToImage(new Bitmap(activeImage.Image), equalizeLUT);
                    CreateNewForm(newImage, "Equalizacja");
                }
                else
                {
                    MessageBox.Show("Użyj obrazu szaroodcieniowego!");

                }
            }
        }
        private int[] EqualizacjaNewLUT(int[] dystrybuanta) {
            int[]  resutl =new int[256];
            int pierwszaNiezerowa = 0;
            for (int i = 0; i < dystrybuanta.Length; i++)
            {
                if (dystrybuanta[i] != 0)
                {
                    pierwszaNiezerowa=dystrybuanta[i];
                    break;
                }
            }
            for (int i = 0; i < dystrybuanta.Length; i++)
            {
                resutl[i] = ((dystrybuanta[i] - pierwszaNiezerowa) / (1 - pierwszaNiezerowa)) * 255;
            }
            return resutl;
        }
        private int[] PrepareDystrybuanta(int[] LUT)
        {
            int[] dystrybuanta = new int[256];
            int allSum = 0;
            for (int i = 0; i < LUT.Length; i++)
            {
                allSum = allSum + LUT[i];
            }
            for (int i = 0; i < LUT.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j <= i; j++)
                {
                    sum=sum + LUT[j];
                }

                dystrybuanta[i] =(int)(sum/ allSum);
                sum = 0;
            }
            return dystrybuanta;
        }
        private bool CheckAndPrepareActiveImage()
        {
            bool result = false;
            if (activeImage != null)
            {
                if ((activeImage.histogramB == null || activeImage.histogramB.Count() == 0) || (activeImage.histogram == null || activeImage.histogram.Count() == 0))
                {
                    GenerateHistogram();
                   
                }
                result = true;
            }
            else
            {
                MessageBox.Show("Najpierw wybierz obraz!");
            }
            return result;
        }
        private void GammaFn(object sender, EventArgs e)
        {
                bool valid= CheckAndPrepareActiveImage();
                if (valid)
                {
                    double gammaParam = ManipulacjaHisto.GetGammaParameterFromUser();
                    if (activeImage.isGrayscale)
                    {
                        int[] newGreyscaleLUT = UseGammaFormula(activeImage.histogram, gammaParam);
                        Image newImage = ManipulacjaHisto.LUTToImage(new Bitmap(activeImage.Image), newGreyscaleLUT);
                        CreateNewForm(newImage, "Funkcja Gamma");
                    }
                    else
                    {
                        MessageBox.Show("Użyj obrazu szaroodcieniowego!");

                    }
                }            
        }

        private int[] UseGammaFormula(int[] lutTable, double y)
        {
            int[] result = new int[lutTable.Length];

            for (int i = 0; i < lutTable.Length; i++)
            {
                double correctedValue = Math.Pow(i, 1.0 / y);

                // Możesz dodać ograniczenia, aby zapewnić, że wartości są w zakresie 0-255
                correctedValue = Math.Max(0, Math.Min(255, correctedValue));

                result[i] = (int)Math.Round(correctedValue);
            }

            return result;
        }

        private void ProgowanieFNGreyscaleLvl(object sender, EventArgs e)
        {
            if (activeImage != null)
            {
                Bitmap bitmap = new Bitmap(activeImage.Image);
                int poziomProgowania = OperacjePunktowe.GetPoziomProgowaniaForm();
                if (poziomProgowania != null && poziomProgowania > 0)
                {
                    Bitmap result = OperacjePunktowe.ApplyBinaryThresholdWithGrayLevels(bitmap, poziomProgowania);
                    CreateNewForm((Image)result, "Progowanie Binarne z zachowaniem szarości");
                }
                else
                {
                    MessageBox.Show("Nie podano poziomu progowania!");

                }
            }
            else
            {
                MessageBox.Show("Najpierw wybierz obraz!");
            }
        }
        private void ProgowanieFN(object sender, EventArgs e)
        {
            if (activeImage != null)
            {
                Bitmap bitmap = new Bitmap(activeImage.Image);
                int poziomProgowania = OperacjePunktowe.GetPoziomProgowaniaForm();
                if (poziomProgowania != null && poziomProgowania > 0)
                {
                    Bitmap result = OperacjePunktowe.ApplyBinaryThreshold(bitmap, poziomProgowania);
                    CreateNewForm((Image)result, "Progowanie binarne");
                }
                else
                {
                    MessageBox.Show("Nie podano poziomu progowania!");

                }
            }
            else
            {
                MessageBox.Show("Najpierw wybierz obraz!");
            }
        }
        private void NeagcjaFn(object sender, EventArgs e)
        {
            if (activeImage != null)
            {
                Bitmap bitmap = new Bitmap(activeImage.Image);         
                Bitmap result = OperacjePunktowe.NegateImage(bitmap);
                CreateNewForm((Image)result, "Negacja Obrazu");
                
            }
            else
            {
                MessageBox.Show("Najpierw wybierz obraz!");
            }
        }
        private void RedukcjaSzarosciFN(object sender, EventArgs e)
        {
            if (activeImage != null)
            {
                Bitmap bitmap = new Bitmap(activeImage.Image);
                int poziomSzarosci = OperacjePunktowe.GetPoziomySzarościForm();
                if (poziomSzarosci != null && poziomSzarosci > 0)
                {
                    Bitmap result = OperacjePunktowe.ReduceGrayscaleLevelsInImage(bitmap, poziomSzarosci);
                    CreateNewForm((Image)result, "Redukcja Szarości");
                }
                else {
                    MessageBox.Show("Nie podano poziomu szarości!");

                }
            }
            else
            {
                MessageBox.Show("Najpierw wybierz obraz!");
            }
        }
 
        private void CreateNewRozciaganieForm(string formTitle)
        {

            rozciaganieForm.Text = formTitle;
            rozciaganieForm.Min = 0;
            rozciaganieForm.Max = 255;
            rozciaganieForm.NewMin = 0;
            rozciaganieForm.NewMax = 255;
            rozciaganieForm.activeImage = activeImage;
            rozciaganieForm.Show();
        }
        private string ImageToPath() {
            string path = "C:\\Users\\piotr\\Pictures\\Props";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string name = "prop-" + Guid.NewGuid();
            string filePath = Path.Combine(path, name);
            activeImage.ImagePath = filePath;
            activeImage.Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
            return filePath;
        }

        private void LUTTableFn(object sender, EventArgs e)
        {
            GenerateLUTTable();
            

        }
        private void GenerateLUTTable() {
            if (activeImage != null)
            {
                if ((activeImage.histogramB == null || activeImage.histogramB.Count() == 0)||(activeImage.histogram == null || activeImage.histogram.Count() == 0))
                {
                    GenerateHistogram();
                }
                bool isGrayscale = true;
                if (activeImage.greyScale == null || activeImage.greyScale.Count() > 0)
                {
                    isGrayscale = false;
                }
                //var lutData= activeImage.histogram;
                using (var lutTableForm = new LUTTableForm(activeImage, isGrayscale))
                {
                    lutTableForm.Show();
                }

            }
            else
            {
                MessageBox.Show("Najpierw wczytaj obraz oraz zaznacz obraz.");
            }
        }
        private void HistogramFn(object sender, EventArgs e)
        {
            GenerateHistogram();
        }
        private void GenerateHistogram() 
        {
            if (activeImage != null)
            {
                Mat Image = new Mat();
                if (activeImage.ImagePath != null)
                {
                    Image = new Mat(activeImage.ImagePath);
                }
                else
                {
                    string filePath = ImageToPath();
                    Image = new Mat(filePath);
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
                    activeImage.isGrayscale = true;
                    activeImage.histogram = lutG;
                    activeImage.statistics = MathFns.CalculateStatistics(channelPixels[1], lutG);
                    ShowGreyScaleHistogram(lutG);

                }
                else
                {
                    activeImage.isGrayscale = false;
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
            histoForm.DisplayStatistics(activeImage.statistics.Mediana, activeImage.statistics.Min, activeImage.statistics.Max, activeImage.statistics.OdchStand,activeImage.statistics.PixelsCnt);

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
           
        }


        private void ToGreyScaleFN(object sender, EventArgs e) {
            if (activeImage != null)
            {
                Bitmap originalBitmap = new Bitmap(activeImage.Image);

                // Twórz nowy obraz w odcieniach szarości
                Bitmap grayscaleBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

                for (int x = 0; x < originalBitmap.Width; x++)
                {
                    for (int y = 0; y < originalBitmap.Height; y++)
                    {
                        Color originalColor = originalBitmap.GetPixel(x, y);

                        // Oblicz średnią wartość składowych koloru
                        int averageBrightness = (originalColor.R + originalColor.G + originalColor.B) / 3;

                        // Ustaw nowy kolor odcienia szarości
                        Color newColor = Color.FromArgb(averageBrightness, averageBrightness, averageBrightness);

                        // Ustaw piksel w obrazie w odcieniach szarości
                        grayscaleBitmap.SetPixel(x, y, newColor);
                    }
                }
               
                CreateNewForm((Image)grayscaleBitmap, "Obraz szaroodcieniowy");
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
            if (activeForm != null&& activeForm.Text.Contains("(Aktywne)"))
            {
                activeForm.Text = activeForm.Text.Replace(" (Aktywne)", "").Trim();
            }
            activeImage = imageForm.Image;
            rozciaganieForm.activeImage = activeImage;
            //if (activeForm != null)
            //{
            //    // Oznacz poprzednie okno jako nieaktywne
            //    activeForm.Text = "Wczytany Obraz";
            //}

            // Ustaw nowe okno jako aktywne
            activeForm = imageForm;
            if (!imageForm.Text.Contains("(Aktywne)"))
            {
                imageForm.Text = imageForm.Text + " (Aktywne)";
            }
        }

        private MenuStrip menuStrip1;
        private ToolStripMenuItem plikToolStripMenu;
        private ToolStripMenuItem wczytajToolStripMenuItem;
        private ToolStripMenuItem duplikujToolStripMenuItem;
        private ToolStripMenuItem zapiszToolStripMenuItem;
        private ToolStripMenuItem analizaToolStripMenu;
        private ToolStripMenuItem histogramToolStripMenuItem;
        private ToolStripMenuItem imageEditionToolStripMenu;
        private ToolStripMenuItem negacjaToolStripMenuItem;
        private ToolStripMenuItem greyscaleToolStripMenuItem;
        private ToolStripMenuItem progowanieToolStripMenuItem;
        private ToolStripMenuItem progowanieZZachToolStripMenuItem;
        private ToolStripMenuItem rozciaganieLinioweToolStripMenuItem;
        private ToolStripMenuItem redukcjaSzarosciToolStripMenuItem;
        private ToolStripMenuItem lutTableToolStripMenuItem;
        private ToolStripMenuItem manipulacjaHistoToolStripMenuItem;
        private ToolStripMenuItem gammaToolStripMenuItem1;
        private ToolStripMenuItem equalizacjaToolStripMenuItem;
        private ToolStripMenuItem operacjeLogiczneToolStripMenuItem;
        private ToolStripMenuItem nOTToolStripMenuItem;
        private ToolStripMenuItem aNDToolStripMenuItem;
        private ToolStripMenuItem oRToolStripMenuItem;
        private ToolStripMenuItem xORToolStripMenuItem;
        private ToolStripMenuItem aDDToolStripMenuItem;
    }


}

