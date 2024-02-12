using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektAlgorytmyObrazów.Forms
{
    public class PointTransformation
    {
        private Point2f[] sourcePoints;
        private Point2f[] destinationPoints;

        public Point2f[] SourcePoints { get { return sourcePoints; } }
        public Point2f[] DestinationPoints { get { return destinationPoints; } }
        public PointTransformation()
        {
            // Inicjalizacja tablic punktów
            sourcePoints = new Point2f[3];
            destinationPoints = new Point2f[3];
        }

        public void SelectPoints(Mat image)
        {
            string type = (sourcePoints[0].X == 0 && sourcePoints[0].Y == 0) ? "sourcePoints" : "destinationPoints";
            MessageBox.Show($"Wybierz punkty źródłowe", "Information", MessageBoxButtons.OK);
            using (Window window = new Window("Select Points", image))
            {
                int selectedPointIndex = -1; // Indeks aktualnie wybranego punktu
                Point2f[] points = (type == "sourcePoints") ? sourcePoints : destinationPoints;
                Cv2.SetMouseCallback("Select Points", (MouseEventTypes eventType, int x, int y, MouseEventFlags flags, IntPtr userdata) =>
                {
                    
                    if (eventType == MouseEventTypes.LButtonDown)
                    {


                        for (int i = 0; i < points.Length; i++)
                        {
                            if (points[i].X == 0 && points[i].Y == 0) // wybraniue id punktu
                            {
                                selectedPointIndex = i;
                                break;
                            }
                        }


                        if (selectedPointIndex != -1)
                        {
                            DialogResult result = MessageBox.Show($"Wybrany punkt: ({x}, {y}). Accept?", "Confirmation", MessageBoxButtons.YesNo);

                            if (result == DialogResult.Yes)
                            {
                                points[selectedPointIndex] = new Point2f(x, y);
                                image.Circle(new Point(x, y), 5, type == "sourcePoints" ? Scalar.Red : Scalar.Blue, -1);
                                window.Image = image;
                                bool isLastPoint = CheckIsItLastPoint(points);
                                if (isLastPoint)
                                {
                                    if (type == "sourcePoints")
                                    {
                                        sourcePoints = points;
                                        points = destinationPoints;
                                        type = "destinationPoints";
                                        MessageBox.Show($"Wybierz punkty docelowe", "Information", MessageBoxButtons.OK);
                                    }
                                    else
                                    {
                                        destinationPoints = points;
                                        window.Close();
                                    }
                                }
                            }
                            // Jeśli użytkownik wybierze "Nie", nie rób nic i pozwól mu wybrać ponownie ten sam punkt

                            selectedPointIndex = -1;
                        }
                       
                    }
                });

                Cv2.WaitKey();
            }
        }

        private static bool CheckIsItLastPoint(Point2f[] points) {
            bool res = true;
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i].X == 0 && points[i].Y == 0) 
                {
                    res = false;
                    break;
                }
            }
            return res;
        }
        public Mat TransformPoints(Mat image)
        {
            Mat matrix = Cv2.GetAffineTransform(sourcePoints, destinationPoints);

            // Wykonanie przekształcenia
            Mat transformedImage = new Mat();
            Cv2.WarpAffine(image, transformedImage, matrix, image.Size());
            // Wyznaczanie macierzy transformacji na podstawie wybranych punktów
            return transformedImage;



        }
    }
}
