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
        public string ImagePath { get; }
        public string Id { get; }
        public Image Image { get; }
        public int[] histogram { get; }

        public Statiscics statistics { get; }

        public ImageObject(string imagePath)
        {
            ImagePath = imagePath;
            Image = Image.FromFile(imagePath);
            Id = Guid.NewGuid().ToString();
            histogram = new int[256];
            statistics = new Statiscics();
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
