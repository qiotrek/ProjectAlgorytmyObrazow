using ProjektAlgorytmyObrazów.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektAlgorytmyObrazów.Functions
{
    public class MathFns
    {

        public static void CalculateMedian(List<byte> pixels,ImageObject activeImage)
        {
            if (pixels.Count > 0)
            {
                var sortedPixels = pixels.OrderBy(x => x).ToList();
                int count = sortedPixels.Count;

                if (count % 2 == 0)
                {
                    // Jeśli liczba elementów jest parzysta, oblicz średnią dwóch środkowych elementów
                    int middle1 = count / 2 - 1;
                    int middle2 = count / 2;
                    activeImage.statistics.Mediana = (sortedPixels[middle1] + sortedPixels[middle2]) / 2.0;
                }
                else
                {
                    // Jeśli liczba elementów jest nieparzysta, środkowy element jest medianą
                    int middle = count / 2;
                    activeImage.statistics.Mediana = sortedPixels[middle];
                }
            }
            else
            {
                // Obsługa przypadku, gdy lista pixels jest pusta
                activeImage.statistics.Mediana = 0; // Lub inna wartość domyślna
            }
        }

        public static void CalculateStandardDeviation(List<byte> pixels, ImageObject activeImage)
        {
            if (pixels.Count > 0)
            {
                double sum = 0.0;
                foreach (byte pixel in pixels)
                {
                    sum += pixel;
                }

                double mean = sum / pixels.Count;

                double sumOfSquares = 0.0;
                foreach (byte pixel in pixels)
                {
                    double deviation = pixel - mean;
                    sumOfSquares += deviation * deviation;
                }

                double variance = sumOfSquares / pixels.Count;
                double standardDeviation = Math.Sqrt(variance);

                activeImage.statistics.OdchStand = standardDeviation;
            }
            else
            {
                // Obsługa przypadku, gdy lista `pixels` jest pusta
                activeImage.statistics.OdchStand = 0.0; // Lub inna wartość domyślna
            }
        }


    }
}
