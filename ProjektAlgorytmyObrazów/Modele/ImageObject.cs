using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektAlgorytmyObrazów.Modele
{
    public class ImageObject
    {
        public string ImagePath { get; set; }
        public string Id { get; }
        public Image Image { get; }
        public int[] histogram { get; set; }
        public int[] histogramR { get; set; }
        public int[] histogramG { get; set; }
        public int[] histogramB { get; set; }
        public List<byte> greyScale { get; }
        public List<byte> R { get; set; }
        public List<byte> G { get; set; }
        public List<byte> B { get; set; }

        public Statiscics statistics { get; set; }
        public Statiscics statisticsR { get; set; }
        public Statiscics statisticsG { get; set; }
        public Statiscics statisticsB { get; set; }

        public ImageObject(string imagePath)
        {
            ImagePath = imagePath;
            Image = Image.FromFile(imagePath);
            Id = Guid.NewGuid().ToString();
            histogram = new int[256];
            statistics = new Statiscics();
            greyScale = null;
            R = new List<byte>();
            G = new List<byte>();
            B = new List<byte>();
        }
        public ImageObject(Image image)
        {
   
            Image = image;
            Id = Guid.NewGuid().ToString();
            histogram = new int[256];
            statistics = new Statiscics();
            greyScale = null;
            R = new List<byte>();
            G = new List<byte>();
            B = new List<byte>();
        }

        public ImageObject Duplicate()
        {

            return new ImageObject(ImagePath);
        }

        public bool IsInForm(Form form)
        {
           
            return true;
        }
    }
}
