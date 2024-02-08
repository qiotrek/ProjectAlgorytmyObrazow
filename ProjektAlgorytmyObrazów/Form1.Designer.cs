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
using ProjektAlgorytmyObrazów.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace ProjektAlgorytmyObrazów
{
    public partial class Form1
    {
        public static List<ImageObject> images = new List<ImageObject>();
        public ImageObject activeImage = null;
        public static ImageForm activeForm = null;
        RozciaganieForm rozciaganieForm = new RozciaganieForm();


        public ImageObject AddImage(string imagePath)
        {
            ImageObject image = new ImageObject(imagePath);
            images.Add(image);
            return image;
        }
        public ImageObject AddImage(Image image)
        {
            ImageObject image2 = new ImageObject(image = image);
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
            this.sUBSTRACTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oPERACJEZLICZBAMIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodawanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odejmowanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dzielenieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnożenieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.różnicaBezwzględnaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lAB4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wygładzanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uśrednianieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uśrednianieZWagamiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtrGaussowskiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyostrzanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detekcjaKrawędziToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medianaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lAB5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segmentacjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otsuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaptacyjneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operatorCannyegoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lab6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.składoweWektoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.momentyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polaPowierzchniIObwoduToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.morfologiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rozciaganieDwuskladnikoweToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.operacjeLogiczneToolStripMenuItem,
            this.lAB4ToolStripMenuItem,
            this.lAB5ToolStripMenuItem,
            this.lab6ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(985, 28);
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
            this.redukcjaSzarosciToolStripMenuItem,
            this.rozciaganieDwuskladnikoweToolStripMenuItem});
            this.imageEditionToolStripMenu.Name = "imageEditionToolStripMenu";
            this.imageEditionToolStripMenu.Size = new System.Drawing.Size(112, 24);
            this.imageEditionToolStripMenu.Text = "ImageEdition";
            // 
            // negacjaToolStripMenuItem
            // 
            this.negacjaToolStripMenuItem.Name = "negacjaToolStripMenuItem";
            this.negacjaToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.negacjaToolStripMenuItem.Text = "Negacja";
            this.negacjaToolStripMenuItem.Click += new System.EventHandler(this.NeagcjaFn);
            // 
            // greyscaleToolStripMenuItem
            // 
            this.greyscaleToolStripMenuItem.Name = "greyscaleToolStripMenuItem";
            this.greyscaleToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.greyscaleToolStripMenuItem.Text = "ToGreyScale";
            this.greyscaleToolStripMenuItem.Click += new System.EventHandler(this.ToGreyScaleFN);
            // 
            // progowanieZZachToolStripMenuItem
            // 
            this.progowanieZZachToolStripMenuItem.Name = "progowanieZZachToolStripMenuItem";
            this.progowanieZZachToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.progowanieZZachToolStripMenuItem.Text = "ProgowanieZZach";
            this.progowanieZZachToolStripMenuItem.Click += new System.EventHandler(this.ProgowanieFNGreyscaleLvl);
            // 
            // progowanieToolStripMenuItem
            // 
            this.progowanieToolStripMenuItem.Name = "progowanieToolStripMenuItem";
            this.progowanieToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.progowanieToolStripMenuItem.Text = "Progowanie";
            this.progowanieToolStripMenuItem.Click += new System.EventHandler(this.ProgowanieFN);
            // 
            // rozciaganieLinioweToolStripMenuItem
            // 
            this.rozciaganieLinioweToolStripMenuItem.Name = "rozciaganieLinioweToolStripMenuItem";
            this.rozciaganieLinioweToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.rozciaganieLinioweToolStripMenuItem.Text = "RozciaganieLiniowe";
            this.rozciaganieLinioweToolStripMenuItem.Click += new System.EventHandler(this.ShowRozciaganieFormFN);
            // 
            // redukcjaSzarosciToolStripMenuItem
            // 
            this.redukcjaSzarosciToolStripMenuItem.Name = "redukcjaSzarosciToolStripMenuItem";
            this.redukcjaSzarosciToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
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
            this.aDDToolStripMenuItem,
            this.sUBSTRACTToolStripMenuItem,
            this.oPERACJEZLICZBAMIToolStripMenuItem});
            this.operacjeLogiczneToolStripMenuItem.Name = "operacjeLogiczneToolStripMenuItem";
            this.operacjeLogiczneToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.operacjeLogiczneToolStripMenuItem.Text = "Operacje Logiczne";
            // 
            // nOTToolStripMenuItem
            // 
            this.nOTToolStripMenuItem.Name = "nOTToolStripMenuItem";
            this.nOTToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.nOTToolStripMenuItem.Text = "NOT";
            this.nOTToolStripMenuItem.Click += new System.EventHandler(this.NOTFn);
            // 
            // aNDToolStripMenuItem
            // 
            this.aNDToolStripMenuItem.Name = "aNDToolStripMenuItem";
            this.aNDToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.aNDToolStripMenuItem.Text = "AND";
            this.aNDToolStripMenuItem.Click += new System.EventHandler(this.ANDFn);
            // 
            // oRToolStripMenuItem
            // 
            this.oRToolStripMenuItem.Name = "oRToolStripMenuItem";
            this.oRToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.oRToolStripMenuItem.Text = "OR";
            this.oRToolStripMenuItem.Click += new System.EventHandler(this.ORFn);
            // 
            // xORToolStripMenuItem
            // 
            this.xORToolStripMenuItem.Name = "xORToolStripMenuItem";
            this.xORToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.xORToolStripMenuItem.Text = "XOR";
            this.xORToolStripMenuItem.Click += new System.EventHandler(this.XORFn);
            // 
            // aDDToolStripMenuItem
            // 
            this.aDDToolStripMenuItem.Name = "aDDToolStripMenuItem";
            this.aDDToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.aDDToolStripMenuItem.Text = "ADD";
            this.aDDToolStripMenuItem.Click += new System.EventHandler(this.ADDFn);
            // 
            // sUBSTRACTToolStripMenuItem
            // 
            this.sUBSTRACTToolStripMenuItem.Name = "sUBSTRACTToolStripMenuItem";
            this.sUBSTRACTToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.sUBSTRACTToolStripMenuItem.Text = "SUBSTRACT";
            this.sUBSTRACTToolStripMenuItem.Click += new System.EventHandler(this.SubstractFN);
            // 
            // oPERACJEZLICZBAMIToolStripMenuItem
            // 
            this.oPERACJEZLICZBAMIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodawanieToolStripMenuItem,
            this.odejmowanieToolStripMenuItem,
            this.dzielenieToolStripMenuItem,
            this.mnożenieToolStripMenuItem,
            this.różnicaBezwzględnaToolStripMenuItem});
            this.oPERACJEZLICZBAMIToolStripMenuItem.Name = "oPERACJEZLICZBAMIToolStripMenuItem";
            this.oPERACJEZLICZBAMIToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.oPERACJEZLICZBAMIToolStripMenuItem.Text = "OPERACJE Z LICZBAMI";
            // 
            // dodawanieToolStripMenuItem
            // 
            this.dodawanieToolStripMenuItem.Name = "dodawanieToolStripMenuItem";
            this.dodawanieToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.dodawanieToolStripMenuItem.Text = "Dodawanie";
            this.dodawanieToolStripMenuItem.Click += new System.EventHandler(this.ADDValueFn);
            // 
            // odejmowanieToolStripMenuItem
            // 
            this.odejmowanieToolStripMenuItem.Name = "odejmowanieToolStripMenuItem";
            this.odejmowanieToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.odejmowanieToolStripMenuItem.Text = "Odejmowanie";
            this.odejmowanieToolStripMenuItem.Click += new System.EventHandler(this.SubstractValueFn);
            // 
            // dzielenieToolStripMenuItem
            // 
            this.dzielenieToolStripMenuItem.Name = "dzielenieToolStripMenuItem";
            this.dzielenieToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.dzielenieToolStripMenuItem.Text = "Dzielenie";
            this.dzielenieToolStripMenuItem.Click += new System.EventHandler(this.DivideValueFn);
            // 
            // mnożenieToolStripMenuItem
            // 
            this.mnożenieToolStripMenuItem.Name = "mnożenieToolStripMenuItem";
            this.mnożenieToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.mnożenieToolStripMenuItem.Text = "Mnożenie";
            this.mnożenieToolStripMenuItem.Click += new System.EventHandler(this.MultiplyValueFn);
            // 
            // różnicaBezwzględnaToolStripMenuItem
            // 
            this.różnicaBezwzględnaToolStripMenuItem.Name = "różnicaBezwzględnaToolStripMenuItem";
            this.różnicaBezwzględnaToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.różnicaBezwzględnaToolStripMenuItem.Text = "Różnica Bezwzględna";
            this.różnicaBezwzględnaToolStripMenuItem.Click += new System.EventHandler(this.AbsoluteDifferenceFn);
            // 
            // lAB4ToolStripMenuItem
            // 
            this.lAB4ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wygładzanieToolStripMenuItem,
            this.wyostrzanieToolStripMenuItem,
            this.detekcjaKrawędziToolStripMenuItem,
            this.medianaToolStripMenuItem});
            this.lAB4ToolStripMenuItem.Name = "lAB4ToolStripMenuItem";
            this.lAB4ToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.lAB4ToolStripMenuItem.Text = "LAB4";
            // 
            // wygładzanieToolStripMenuItem
            // 
            this.wygładzanieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uśrednianieToolStripMenuItem,
            this.uśrednianieZWagamiToolStripMenuItem,
            this.filtrGaussowskiToolStripMenuItem});
            this.wygładzanieToolStripMenuItem.Name = "wygładzanieToolStripMenuItem";
            this.wygładzanieToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.wygładzanieToolStripMenuItem.Text = "Wygładzanie";
            // 
            // uśrednianieToolStripMenuItem
            // 
            this.uśrednianieToolStripMenuItem.Name = "uśrednianieToolStripMenuItem";
            this.uśrednianieToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.uśrednianieToolStripMenuItem.Text = "Uśrednianie";
            this.uśrednianieToolStripMenuItem.Click += new System.EventHandler(this.WygLinUsrednianieFn);
            // 
            // uśrednianieZWagamiToolStripMenuItem
            // 
            this.uśrednianieZWagamiToolStripMenuItem.Name = "uśrednianieZWagamiToolStripMenuItem";
            this.uśrednianieZWagamiToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.uśrednianieZWagamiToolStripMenuItem.Text = "Uśrednianie z wagami";
            this.uśrednianieZWagamiToolStripMenuItem.Click += new System.EventHandler(this.WygLinUsrednianieZWagamiFn);
            // 
            // filtrGaussowskiToolStripMenuItem
            // 
            this.filtrGaussowskiToolStripMenuItem.Name = "filtrGaussowskiToolStripMenuItem";
            this.filtrGaussowskiToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.filtrGaussowskiToolStripMenuItem.Text = "Filtr Gaussowski";
            this.filtrGaussowskiToolStripMenuItem.Click += new System.EventHandler(this.WygLinGaussianBlurFn);
            // 
            // wyostrzanieToolStripMenuItem
            // 
            this.wyostrzanieToolStripMenuItem.Name = "wyostrzanieToolStripMenuItem";
            this.wyostrzanieToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.wyostrzanieToolStripMenuItem.Text = "Wyostrzanie";
            this.wyostrzanieToolStripMenuItem.Click += new System.EventHandler(this.WyostrzanieFn);
            // 
            // detekcjaKrawędziToolStripMenuItem
            // 
            this.detekcjaKrawędziToolStripMenuItem.Name = "detekcjaKrawędziToolStripMenuItem";
            this.detekcjaKrawędziToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.detekcjaKrawędziToolStripMenuItem.Text = "Detekcja Krawędzi";
            this.detekcjaKrawędziToolStripMenuItem.Click += new System.EventHandler(this.DetekcjaKrawedziFn);
            // 
            // medianaToolStripMenuItem
            // 
            this.medianaToolStripMenuItem.Name = "medianaToolStripMenuItem";
            this.medianaToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.medianaToolStripMenuItem.Text = "Mediana";
            this.medianaToolStripMenuItem.Click += new System.EventHandler(this.MedianaFn);
            // 
            // lAB5ToolStripMenuItem
            // 
            this.lAB5ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.segmentacjaToolStripMenuItem,
            this.operatorCannyegoToolStripMenuItem});
            this.lAB5ToolStripMenuItem.Name = "lAB5ToolStripMenuItem";
            this.lAB5ToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.lAB5ToolStripMenuItem.Text = "LAB5";
            // 
            // segmentacjaToolStripMenuItem
            // 
            this.segmentacjaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customToolStripMenuItem,
            this.otsuToolStripMenuItem,
            this.adaptacyjneToolStripMenuItem});
            this.segmentacjaToolStripMenuItem.Name = "segmentacjaToolStripMenuItem";
            this.segmentacjaToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.segmentacjaToolStripMenuItem.Text = "Segmentacja";
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.customToolStripMenuItem.Text = "Custom";
            this.customToolStripMenuItem.Click += new System.EventHandler(this.ProgowanieCustomFn);
            // 
            // otsuToolStripMenuItem
            // 
            this.otsuToolStripMenuItem.Name = "otsuToolStripMenuItem";
            this.otsuToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.otsuToolStripMenuItem.Text = "Otsu";
            this.otsuToolStripMenuItem.Click += new System.EventHandler(this.ProgowanieOtsuFn);
            // 
            // adaptacyjneToolStripMenuItem
            // 
            this.adaptacyjneToolStripMenuItem.Name = "adaptacyjneToolStripMenuItem";
            this.adaptacyjneToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.adaptacyjneToolStripMenuItem.Text = "Adaptacyjne";
            this.adaptacyjneToolStripMenuItem.Click += new System.EventHandler(this.ProgowanieAdaptacyjneFn);
            // 
            // operatorCannyegoToolStripMenuItem
            // 
            this.operatorCannyegoToolStripMenuItem.Name = "operatorCannyegoToolStripMenuItem";
            this.operatorCannyegoToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.operatorCannyegoToolStripMenuItem.Text = "Operator Cannyego";
            this.operatorCannyegoToolStripMenuItem.Click += new System.EventHandler(this.CannyFn);
            // 
            // lab6ToolStripMenuItem
            // 
            this.lab6ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.składoweWektoraToolStripMenuItem,
            this.morfologiaToolStripMenuItem});
            this.lab6ToolStripMenuItem.Name = "lab6ToolStripMenuItem";
            this.lab6ToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.lab6ToolStripMenuItem.Text = "Lab6";
            // 
            // składoweWektoraToolStripMenuItem
            // 
            this.składoweWektoraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.momentyToolStripMenuItem,
            this.polaPowierzchniIObwoduToolStripMenuItem});
            this.składoweWektoraToolStripMenuItem.Name = "składoweWektoraToolStripMenuItem";
            this.składoweWektoraToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.składoweWektoraToolStripMenuItem.Text = "Składowe Wektora";
            // 
            // momentyToolStripMenuItem
            // 
            this.momentyToolStripMenuItem.Name = "momentyToolStripMenuItem";
            this.momentyToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.momentyToolStripMenuItem.Text = "Momenty";
            // 
            // polaPowierzchniIObwoduToolStripMenuItem
            // 
            this.polaPowierzchniIObwoduToolStripMenuItem.Name = "polaPowierzchniIObwoduToolStripMenuItem";
            this.polaPowierzchniIObwoduToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.polaPowierzchniIObwoduToolStripMenuItem.Text = "Pola powierzchni i obwodu";
            // 
            // morfologiaToolStripMenuItem
            // 
            this.morfologiaToolStripMenuItem.Name = "morfologiaToolStripMenuItem";
            this.morfologiaToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.morfologiaToolStripMenuItem.Text = "Morfologia";
            this.morfologiaToolStripMenuItem.Click += new System.EventHandler(this.MorfologiaFn);
            // 
            // rozciaganieDwuskladnikoweToolStripMenuItem
            // 
            this.rozciaganieDwuskladnikoweToolStripMenuItem.Name = "rozciaganieDwuskladnikoweToolStripMenuItem";
            this.rozciaganieDwuskladnikoweToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.rozciaganieDwuskladnikoweToolStripMenuItem.Text = "Rozciaganie Dwuskladnikowe";
            this.rozciaganieDwuskladnikoweToolStripMenuItem.Click += new System.EventHandler(this.Rozciaganie2Skladnikowe);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 58);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "AlgorytmyPrzetwarzaniaObrazow";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void Rozciaganie2Skladnikowe(object sender, EventArgs e)
        {
            if (activeImage == null)
            {
                MessageBox.Show("Najpierw wybierz obraz!");
                return;
            }
            Bitmap result = Rozciaganie2skladnikowe.Rozciaganie(activeImage);


            CreateNewForm((Image)result, "Rozciaganie 2 składnikowe Result");
        }

        private void MorfologiaFn(object sender, EventArgs e)
        {
            if (activeImage == null)
            {
                MessageBox.Show("Najpierw wybierz obraz!");
                return;
            }

            OpenCvSharp.Mat resultImage = Morfologia.Morfology(activeImage);
            CreateNewForm((Image)ImageConverters.ConvertMatToBitmap(resultImage), "Morfologia Result");
        }

        private void CannyFn(object sender, EventArgs e)
        {
            if (activeImage == null)
            {
                MessageBox.Show("Najpierw wybierz obraz!");
                return;
            }
            
            OpenCvSharp.Mat srcImage = Cv2.ImRead(activeImage.ImagePath, ImreadModes.Color);
            if (srcImage.Empty())
            {
                MessageBox.Show("Nie można wczytać obrazu!");
                return;
            }
            OpenCvSharp.Mat cannyEdges = new OpenCvSharp.Mat();
            Form chooseParameters = new Form();
            Bitmap result = new Bitmap(activeImage.Image.Width, activeImage.Image.Height);
            // Ustawienia formularza
            chooseParameters.Text = "Wybierz Parametry";
            chooseParameters.Size = new System.Drawing.Size(400, 220);
            chooseParameters.FormBorderStyle = FormBorderStyle.FixedSingle;
            chooseParameters.MaximizeBox = false;

            // Pole do wprowadzenia pierwszej wartości int
            TextBox firstValueTextBox = new TextBox();
            firstValueTextBox.Location = new System.Drawing.Point(50, 70);
            chooseParameters.Controls.Add(firstValueTextBox);

            // Pole do wprowadzenia drugiej wartości int
            TextBox secondValueTextBox = new TextBox();
            secondValueTextBox.Location = new System.Drawing.Point(200, 70);
            chooseParameters.Controls.Add(secondValueTextBox);

            // Przycisk na formularzu
            Button button = new Button();
            button.Text = "Zatwierdź";
            button.Location = new System.Drawing.Point(150, 120);
            button.Click += (s, args) =>
            {


                if (int.TryParse(firstValueTextBox.Text, out int firstValue) && int.TryParse(secondValueTextBox.Text, out int secondValue))
                {


                    OpenCvSharp.Mat grayMat = new OpenCvSharp.Mat();
                    Cv2.CvtColor(srcImage, grayMat, ColorConversionCodes.BGR2GRAY);

              
                    Cv2.Canny(grayMat, cannyEdges, firstValue, secondValue);
                }
                else
                {
                    // Jeśli wprowadzone wartości nie są liczbami całkowitymi, wyświetl komunikat
                    MessageBox.Show("Wprowadź poprawne wartości całkowite.");
                }

                // Zamknij formularz po kliknięciu przycisku "Zatwierdź"
                chooseParameters.Close();


            };
            chooseParameters.Controls.Add(button);

            // Pokaż formularz
            chooseParameters.ShowDialog();


            CreateNewForm((Image)ImageConverters.ConvertMatToBitmap(cannyEdges), "Canny Result");
        }

        private void MedianaFn(object sender, EventArgs e)
        {
            if (activeImage == null)
            {
                MessageBox.Show("Najpierw wybierz obraz!");
                return;
            }

            MedianForm medianForm = new MedianForm();
            medianForm.ShowDialog();
            int median = medianForm.GetSelectedMedian();
            int border = medianForm.GetSelectedBorder();
            int value = medianForm.GetFrameValue();
            OpenCvSharp.Mat res = MedianBlur(activeImage, median, border, value);

            CreateNewForm((Image)ImageConverters.ConvertMatToBitmap(res), "Median Result");

        }



        public static OpenCvSharp.Mat MedianBlur(ImageObject image, int medianValue, int border, int value)
        {
            OpenCvSharp.Mat img = Cv2.ImRead(image.ImagePath, ImreadModes.Color);

            OpenCvSharp.Mat bordered = new OpenCvSharp.Mat();

            switch (border)
            {
                case 0:
                    Cv2.CopyMakeBorder(img, bordered, 0, 0, 0, 0, BorderTypes.Constant, new Scalar(value, value, value, value));
                    break;
                case 1:
                    Cv2.CopyMakeBorder(img, bordered, 0, 0, 0, 0, BorderTypes.Reflect);
                    break;
                case 2:
                    Cv2.CopyMakeBorder(img, bordered, 0, 0, 0, 0, BorderTypes.Wrap);
                    break;
            }

            OpenCvSharp.Mat result = new OpenCvSharp.Mat();
            Cv2.MedianBlur(bordered, result, medianValue);

            return result;
        }
   
        private void ProgowanieCustomFn(object sender, EventArgs e)
        {
            if (activeImage == null)
            {
                MessageBox.Show("Najpierw wybierz obraz!");
                return;
            }
            GenerateHistogram();
            int param1 = CustomForms.GetValueForm("Podaj pierwszy próg", "Pierwszy próg");
            int param2 = CustomForms.GetValueForm("Podaj drugi próg", "Drugi próg");
            if (param1 != 0 && param2 != 0)
            {
                Bitmap resultImage = Segmentacja.Custom(activeImage, param1, param2);
                CreateNewForm((Image)resultImage, "Wyostrzanie Laplasjan Result");
            }
        }
        private void ProgowanieOtsuFn(object sender, EventArgs e)
        {
            if (activeImage == null)
            {
                MessageBox.Show("Najpierw wybierz obraz!");
                return;
            }
            GenerateHistogram();
            Bitmap resultImage = Segmentacja.Otsu(activeImage);
            CreateNewForm((Image)resultImage, "Progowanie Otsu Result");

        }
        private void ProgowanieAdaptacyjneFn(object sender, EventArgs e)
        {
            if (activeImage == null)
            {
                MessageBox.Show("Najpierw wybierz obraz!");
                return;
            }
            GenerateHistogram();
            Bitmap resultImage = Segmentacja.Adaptacyjne(activeImage);
            CreateNewForm((Image)resultImage, "Progowanie Adaptacyjne Result");

        }
        private void WyostrzanieFn(object sender, EventArgs e)
        {
            if (activeImage == null)
            {
                MessageBox.Show("Najpierw wybierz obraz!");
                return;
            }
            OpenCvSharp.Mat mask = CustomForms.ChooseLaplacianMask();
            if (mask.IsContinuous())
            {
                Bitmap resultImage = WygladzanieLiniowe.WyostrzanieLinioweLaplasjan(new OpenCvSharp.Mat(activeImage.ImagePath), mask);
                CreateNewForm((Image)resultImage, "Wyostrzanie Laplasjan Result");
            }
        }

        private void DetekcjaKrawedziFn(object sender, EventArgs e) {
            if (activeImage == null)
            {
                MessageBox.Show("Najpierw wybierz obraz!");
                return;
            }
            EdgeDetectionOptions edgeDetectionOptions = new EdgeDetectionOptions();
            edgeDetectionOptions.activeImage = activeImage;
            edgeDetectionOptions.Show();

        }


        public void CalculateEdgeDetection(int border, string textboxText, bool cont, ImageObject activeImage, int mask, int value2)
        {

            Bitmap result = null;

            if (border == 0)
            {
                if (int.TryParse(textboxText, out int value))
                {

                    if (int.Parse(textboxText) < 0 || int.Parse(textboxText) > 255)
                    {
                        cont = false;
                        MessageBox.Show("Podano nieprawidłową wartość", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        value2 = value;
                    }
                }
                else
                {
                    cont = false;
                    MessageBox.Show("Podano nieprawidłową wartość", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (cont)
            {
                if (mask == 8)
                {
                    result = EdgeDetectionOptions.SobelDetection(activeImage, border, value2);
                }
                else if (mask == 9)
                {
                    result = EdgeDetectionOptions.PrewittDetection(activeImage, border, value2);
                }
                else
                {
                    Mat<float> kernel = EdgeDetectionOptions.GetKernel(mask);
                    result = EdgeDetectionOptions.Filter(kernel, border, activeImage, value2);
                }


            }

            CreateNewForm((Image)result, "Detekcja Krawędzi");

        }

        private void WygLinUsrednianieFn(object sender, EventArgs e)
        {
            if (activeImage == null)
            {
                MessageBox.Show("Najpierw wybierz obraz!");
                return;
            }
            //SelectForm ramka = new SelectForm();
            //DialogResult result = ramka.ShowDialog();
            //string tamkaVal = ramka.GetSelectedOption();
            //int value = ramka.GetAdditionalValue();
            Bitmap resultImage = WygladzanieLiniowe.Usrednianie(new OpenCvSharp.Mat(activeImage.ImagePath));
            CreateNewForm((Image)resultImage, "Uśrednianie Result");
        }
        private void WygLinUsrednianieZWagamiFn(object sender, EventArgs e)
        {
            if (activeImage == null)
            {
                MessageBox.Show("Najpierw wybierz obraz!");
                return;
            }
            Bitmap resultImage = WygladzanieLiniowe.UsrednianieZWagami(new OpenCvSharp.Mat(activeImage.ImagePath));
            CreateNewForm((Image)resultImage, "Uśrednianie z Wagami Result");
        }
        private void WygLinGaussianBlurFn(object sender, EventArgs e)
        {
            if (activeImage == null)
            {
                MessageBox.Show("Najpierw wybierz obraz!");
                return;
            }
            Bitmap resultImage = WygladzanieLiniowe.GaussianBlur(new OpenCvSharp.Mat(activeImage.ImagePath));
            CreateNewForm((Image)resultImage, "Gaussian Result");
        }
        private void ADDValueFn(object sender, EventArgs e)
        {
            if (activeImage == null)
            {
                MessageBox.Show("Najpierw wybierz obraz!");
                return;
            }
            int addedValue = CustomForms.GetValueForm("Podaj wartość która ma zostać dodana", "Wartość do dodania");
            Bitmap image = new Bitmap(activeImage.ImagePath);
            Bitmap resultImage = Logiczne.AddValueToImage(image, addedValue);
            CreateNewForm((Image)resultImage, "ADD Value Result");
        }

        private void SubstractValueFn(object sender, EventArgs e)
        {
            if (activeImage == null)
            {
                MessageBox.Show("Najpierw wybierz obraz!");
                return;
            }
            int substractValue = CustomForms.GetValueForm("Podaj wartość która ma zostać odjęta", "Wartość do odjęcia");
            Bitmap image = new Bitmap(activeImage.ImagePath);
            Bitmap resultImage = Logiczne.SubtractValueFromImage(image, substractValue);
            CreateNewForm((Image)resultImage, "Substract Value Result");
        }

        private void MultiplyValueFn(object sender, EventArgs e)
        {
            if (activeImage != null)
            {
                int multiplyValue = CustomForms.GetValueForm("Podaj wartość która ma zostać pomnożona", "Wartość do mnożenia");
                Bitmap image = new Bitmap(activeImage.ImagePath);
                Bitmap resultImage = Logiczne.MultiplyImageByValue(image, multiplyValue);
                CreateNewForm((Image)resultImage, "Multiply Value Result");
            }
            else
            {
                MessageBox.Show("Najpierw wybierz obraz!");
            }
        }

        private void DivideValueFn(object sender, EventArgs e)
        {
            if (activeImage != null)
            {
                int divideValue = CustomForms.GetValueForm("Podaj wartość która ma zostać podzielona", "Wartość do dzielenia");
                Bitmap image = new Bitmap(activeImage.ImagePath);
                Bitmap resultImage = Logiczne.DivideImageByValue(image, divideValue);
                CreateNewForm((Image)resultImage, "Divide Value Result");
            }
            else
            {
                MessageBox.Show("Najpierw wybierz obraz!");
            }
        }

        private void AbsoluteDifferenceFn(object sender, EventArgs e)
        {
            if (activeImage != null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "Obrazy|*.jpg;*.tif;*.png;*.bmp|Wszystkie pliki|*.*";
                string secoundFilePath = null;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    secoundFilePath = openFileDialog.FileName;
                }
                Bitmap imageA = new Bitmap(activeImage.ImagePath);
                Bitmap imageB = new Bitmap(secoundFilePath);
                Bitmap resultImage = Logiczne.CalculateAbsoluteDifference(imageA, imageB);
                CreateNewForm((Image)resultImage, "AbsoluteDifference Value Result");
            }
            else
            {
                MessageBox.Show("Najpierw wybierz obraz!");
            }
        }
        private void ADDFn(object sender, EventArgs e)
        {
            if (activeImage != null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "Obrazy|*.jpg;*.tif;*.png;*.bmp|Wszystkie pliki|*.*";
                string secoundFilePath = null;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    secoundFilePath = openFileDialog.FileName;
                }
                Bitmap image = new Bitmap(activeImage.ImagePath);
                Bitmap image2 = new Bitmap(secoundFilePath);

                CheckboxForm checkboxForm = new CheckboxForm("Czy zastosować saturację?");
                DialogResult result = checkboxForm.ShowDialog();
                bool checkboxState = checkboxForm.GetCheckboxState();

                Bitmap resultImage = Logiczne.AddImages(image, image2, checkboxState);

                CreateNewForm((Image)resultImage, "ADD Result");

                //Cv2.ImShow("ADD Result", resultImage);
            }
            else
            {
                MessageBox.Show("Najpierw wybierz obraz!");
            }
        }


        private void SubstractFN(object sender, EventArgs e)
        {
            if (activeImage != null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "Obrazy|*.jpg;*.tif;*.png;*.bmp|Wszystkie pliki|*.*";
                string secoundFilePath = null;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    secoundFilePath = openFileDialog.FileName;
                }
                Bitmap image = new Bitmap(activeImage.ImagePath);
                Bitmap image2 = new Bitmap(secoundFilePath);

                Bitmap resultImage = Logiczne.SubtractImages(image, image2);

                CreateNewForm((Image)resultImage, "SUBSTRACT Result");

            }
            else
            {
                MessageBox.Show("Najpierw wybierz obraz!");
            }
        }
        private void ANDFn(object sender, EventArgs e) {
            if (activeImage != null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "Obrazy|*.jpg;*.tif;*.png;*.bmp|Wszystkie pliki|*.*";
                string secoundFilePath = null;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    secoundFilePath = openFileDialog.FileName;
                }
                OpenCvSharp.Mat imageA = new OpenCvSharp.Mat(activeImage.ImagePath);
                OpenCvSharp.Mat imageB = new OpenCvSharp.Mat(secoundFilePath);
                OpenCvSharp.Mat resultImage = Logiczne.LogicalAND(imageA, imageB);
                Cv2.ImShow("AND Result", resultImage);
            }
            else
            {
                MessageBox.Show("Najpierw wybierz obraz!");
            }
        }
        private void ORFn(object sender, EventArgs e)
        {
            if (activeImage != null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "Obrazy|*.jpg;*.tif;*.png;*.bmp|Wszystkie pliki|*.*";
                string secoundFilePath = null;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    secoundFilePath = openFileDialog.FileName;
                }
                OpenCvSharp.Mat imageA = new OpenCvSharp.Mat(activeImage.ImagePath);
                OpenCvSharp.Mat imageB = new OpenCvSharp.Mat(secoundFilePath);
                OpenCvSharp.Mat resultImage = Logiczne.LogicalOR(imageA, imageB);
                Cv2.ImShow("OR Result", resultImage);
            }
            else
            {
                MessageBox.Show("Najpierw wybierz obraz!");
            }
        }
        private void NOTFn(object sender, EventArgs e)
        {
            OpenCvSharp.Mat imageA = new OpenCvSharp.Mat(activeImage.ImagePath);
            OpenCvSharp.Mat resultImage = Logiczne.LogicalNOT(imageA);
            Cv2.ImShow("NOT Result", resultImage);
        }
        private void XORFn(object sender, EventArgs e)
        {
            if (activeImage != null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "Obrazy|*.jpg;*.tif;*.png;*.bmp|Wszystkie pliki|*.*";
                string secoundFilePath = null;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    secoundFilePath = openFileDialog.FileName;
                }
                OpenCvSharp.Mat imageA = new OpenCvSharp.Mat(activeImage.ImagePath);
                OpenCvSharp.Mat imageB = new OpenCvSharp.Mat(secoundFilePath);
                OpenCvSharp.Mat resultImage = Logiczne.LogicalXor(imageA, imageB);
                Cv2.ImShow("XOR Result", resultImage);
            }
            else
            {
                MessageBox.Show("Najpierw wybierz obraz!");
            }
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
                Bitmap strechedImage = null;
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
                    //int[] dystrybuanta = PrepareDystrybuanta(activeImage.histogram);
                    //int[] equalizeLUT = EqualizacjaNewLUT(activeImage.histogram);
                    //Image newImage = ManipulacjaHisto.LUTToImageGrayScale(new Bitmap(activeImage.Image), equalizeLUT);
                    OpenCvSharp.Mat result = ManipulacjaHisto.Equalize(activeImage);
                    CreateNewForm((Image)ImageConverters.ConvertMatToBitmap(result), "Equalizacja");
                    //CreateNewForm(newImage, "Equalizacja");
                }
                else
                {
                    MessageBox.Show("Użyj obrazu szaroodcieniowego!");

                }
            }
        }
        private int[] EqualizacjaNewLUT(int[] LUT) {
            int[] result = new int[256];
            int pierwszaNiezerowa = 0;
            for (int i = 0; i < LUT.Length; i++)
            {
                if (LUT[i] != 0)
                {
                    pierwszaNiezerowa = LUT[i];
                    break;
                }
            }
            double sum = 0;
            for (int i = 0; i < LUT.Length; i++)
            {
                sum = sum + LUT[i];
                double zmienna1 = (sum - pierwszaNiezerowa);
                var size = (activeImage.Image.Height * activeImage.Image.Width);
                result[i] = (int)((zmienna1 / (double)(size - pierwszaNiezerowa)) * 255);
            }
            return result;
        }
        private int[] PrepareDystrybuanta(int[] LUT)
        {
            int[] dystrybuanta = new int[256];
            //int allSum = 0;
            //for (int i = 0; i < LUT.Length; i++)
            //{
            //    allSum = allSum + LUT[i];
            //}
            int sum = 0;
            for (int i = 0; i < LUT.Length; i++)
            {
                sum = sum + LUT[i];

                dystrybuanta[i] = (int)(sum);

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
            bool valid = CheckAndPrepareActiveImage();
            if (valid)
            {
                double gammaParam = ManipulacjaHisto.GetGammaParameterFromUser();
                if (activeImage.isGrayscale)
                {
                    GenerateHistogram(false);
                    Bitmap gammaImage = new Bitmap(activeImage.Image.Width, activeImage.Image.Height);
                    double saturation = 0;
                    int[] data = new int[256];

                    int[] histogram = new int[256];

                    for (int i = 0; i < activeImage.Image.Width; i++)
                    {
                        for (int j = 0; j < activeImage.Image.Height; j++)
                        {
                            Color pixel = ((Bitmap)activeImage.Image).GetPixel(i, j);
                            histogram[pixel.R]++;
                        }
                    }

                    int minValue = activeImage.statistics.Min;
                    int maxValue = activeImage.statistics.Max;

                    if (saturation != 0)
                    {
                        int oversaturationThreshold = (int)((saturation / 100) * activeImage.Image.Width * activeImage.Image.Height);
                        int oversaturationCount = 0;

                        for (int i = 0; i < 256; i++)
                        {
                            oversaturationCount += histogram[i];
                            if (oversaturationCount > oversaturationThreshold)
                            {
                                minValue = i;
                                break;
                            }
                        }

                        oversaturationCount = 0;

                        for (int i = 255; i >= 0; i--)
                        {
                            oversaturationCount += histogram[i];
                            if (oversaturationCount > oversaturationThreshold)
                            {
                                maxValue = i;
                                break;
                            }
                        }
                    }

                    for (int i = 0; i < 256; ++i)
                    {
                        double temp = (255.0 * Math.Pow(((float)(i - minValue) / (float)(maxValue - minValue)), gammaParam));
                        data[i] = temp < 0 ? 0 : (int)Math.Floor(temp);
                    }

                    for (int i = 0; i < activeImage.Image.Width; i++)
                    {
                        for (int j = 0; j < activeImage.Image.Height; j++)
                        {
                            Color pixelColor = ((Bitmap)activeImage.Image).GetPixel(i, j);
                            Color gammaColor = Color.FromArgb(data[pixelColor.R], data[pixelColor.R], data[pixelColor.R]);

                            gammaImage.SetPixel(i, j, gammaColor);
                        }
                    }
                    CreateNewForm((Image)gammaImage, "Funkcja Gamma");
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
                int poziomProgowania = OperacjePunktowe.GetPoziomProgowaniaForm();
                if (poziomProgowania != null && poziomProgowania > 0)
                {
                    Bitmap result = OperacjePunktowe.Threshold(activeImage, poziomProgowania);
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
                int poziomProgowania = OperacjePunktowe.GetPoziomProgowaniaForm();
                if (poziomProgowania != null && poziomProgowania > 0)
                {
                    OpenCvSharp.Mat result = OperacjePunktowe.BinaryThreshold(activeImage, (double)poziomProgowania);
                    CreateNewForm((Image)ImageConverters.ConvertMatToBitmap(result), "Progowanie binarne");
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
                if ((activeImage.histogramB == null || activeImage.histogramB.Count() == 0) || (activeImage.histogram == null || activeImage.histogram.Count() == 0))
                {
                    GenerateHistogram();
                }

                //var lutData= activeImage.histogram;
                using (var lutTableForm = new LUTTableForm(activeImage, activeImage.isGrayscale))
                {
                    lutTableForm.ShowDialog();
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
        private void GenerateHistogram(bool show=true)
        {
            if (activeImage != null)
            {
                OpenCvSharp.Mat Image = new OpenCvSharp.Mat();
                if (activeImage.ImagePath != null)
                {
                    Image = new OpenCvSharp.Mat(activeImage.ImagePath);
                }
                else
                {
                    string filePath = ImageToPath();
                    Image = new OpenCvSharp.Mat(filePath);
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
                    if (show)
                    {
                        ShowGreyScaleHistogram(lutG);
                    }
                }
                else
                {
                    activeImage.isGrayscale = false;
                    if (show)
                    {
                        ShowRGBHistogram(lutR, lutG, lutB);
                    }
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
            histoForm.DisplayStatistics(activeImage.statistics.Mediana, activeImage.statistics.Min, activeImage.statistics.Max, activeImage.statistics.OdchStand, activeImage.statistics.PixelsCnt);

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
            histoForm.DisplayStatisticsRGB(activeImage.statisticsR, activeImage.statisticsG, activeImage.statisticsB);

            // Wyświetlanie formularza
            histoForm.Show();
        }

        private List<byte>[] SplitChannels(OpenCvSharp.Mat colorImage)
        {
            List<byte>[] channels = new List<byte>[3];
            for (int i = 0; i < 3; i++)
            {
                channels[i] = MatToListBytes(colorImage.ExtractChannel(i));
            }
            return channels;
        }
        private List<byte> MatToListBytes(OpenCvSharp.Mat mat)
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
            Bitmap grayscaleBitmap = ToGreyScale(activeImage);
            CreateNewForm((Image)grayscaleBitmap, "Obraz szaroodcieniowy");
        }

        private static Bitmap ToGreyScale(ImageObject activeImage){

            if (activeImage == null)
            {
                MessageBox.Show("Najpierw wczytaj obraz przed próbą duplikacji.");
            }


            Bitmap originalBitmap = new Bitmap(activeImage.Image);

            // Twórz nowy obraz w odcieniach szarości
            Bitmap grayscaleBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

            for (int x = 0; x<originalBitmap.Width; x++)
            {
                for (int y = 0; y<originalBitmap.Height; y++)
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
            return grayscaleBitmap;
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
        private ToolStripMenuItem oPERACJEZLICZBAMIToolStripMenuItem;
        private ToolStripMenuItem dodawanieToolStripMenuItem;
        private ToolStripMenuItem dzielenieToolStripMenuItem;
        private ToolStripMenuItem mnożenieToolStripMenuItem;
        private ToolStripMenuItem różnicaBezwzględnaToolStripMenuItem;
        private ToolStripMenuItem odejmowanieToolStripMenuItem;
        private ToolStripMenuItem lAB4ToolStripMenuItem;
        private ToolStripMenuItem wygładzanieToolStripMenuItem;
        private ToolStripMenuItem uśrednianieToolStripMenuItem;
        private ToolStripMenuItem uśrednianieZWagamiToolStripMenuItem;
        private ToolStripMenuItem filtrGaussowskiToolStripMenuItem;
        private ToolStripMenuItem wyostrzanieToolStripMenuItem;
        private ToolStripMenuItem lAB5ToolStripMenuItem;
        private ToolStripMenuItem segmentacjaToolStripMenuItem;
        private ToolStripMenuItem customToolStripMenuItem;
        private ToolStripMenuItem otsuToolStripMenuItem;
        private ToolStripMenuItem adaptacyjneToolStripMenuItem;
        private ToolStripMenuItem lab6ToolStripMenuItem;
        private ToolStripMenuItem składoweWektoraToolStripMenuItem;
        private ToolStripMenuItem momentyToolStripMenuItem;
        private ToolStripMenuItem polaPowierzchniIObwoduToolStripMenuItem;
        private ToolStripMenuItem detekcjaKrawędziToolStripMenuItem;
        private ToolStripMenuItem sUBSTRACTToolStripMenuItem;
        private ToolStripMenuItem medianaToolStripMenuItem;
        private ToolStripMenuItem operatorCannyegoToolStripMenuItem;
        private ToolStripMenuItem morfologiaToolStripMenuItem;
        private ToolStripMenuItem rozciaganieDwuskladnikoweToolStripMenuItem;
    }


}

