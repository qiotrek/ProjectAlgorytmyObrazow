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
        public static Statiscics CalculateStatistics(List<byte> pixels, int[] lut)
        {
           Statiscics stats = new Statiscics();
            stats.Max=CalculateMax(lut);
            stats.Min=CalculateMin(lut);
            stats.Mediana=CalculateMediana(pixels);
            stats.OdchStand=CalculateStandardDeviation(pixels);
            stats.PixelsCnt=pixels.Count;
            return stats;
        }
        private static double CalculateMediana(List<byte> pixels)
        {
            double result = 0;
            if (pixels.Count > 0)
            {
                var sortedPixels = pixels.OrderBy(x => x).ToList();
                int count = sortedPixels.Count;

                if (count % 2 == 0)
                {
                    // Jeśli liczba elementów jest parzysta, oblicz średnią dwóch środkowych elementów
                    int middle1 = count / 2 - 1;
                    int middle2 = count / 2;
                    result = (sortedPixels[middle1] + sortedPixels[middle2]) / 2.0;
                }
                else
                {
                    // Jeśli liczba elementów jest nieparzysta, środkowy element jest medianą
                    int middle = count / 2;
                    result = sortedPixels[middle];
                }
            }
            else
            {
                // Obsługa przypadku, gdy lista pixels jest pusta
                result= 0; // Lub inna wartość domyślna
            }
            return result;
        }

        private static double CalculateStandardDeviation(List<byte> pixels)
        {
            double result = 0;
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

                result = Math.Round( standardDeviation,2);
            }
            else
            {
                // Obsługa przypadku, gdy lista `pixels` jest pusta
                result = 0.0; // Lub inna wartość domyślna
            }
            return result;
        }

        private static int CalculateMax(int[] pixels)
        {
            int result = 0;

            for (int i = pixels.Length - 1; i >= 0; i--)
            {
                if (pixels[i] != 0)
                {
                    return i;
                }
            }

            return result;

        }
        private static int CalculateMin(int[] pixels)
        {
            
            int result = 0;
            for (int i = 0; i < pixels.Length; i++)
            {
                if (pixels[i] != 0)
                {
                    return i;
                }
            }

            return result;
        }
    }
}
