using PlanSeysmicSystem.SeysmicSurveyClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlanSeysmicSystem.BinData
{
    public class Bin
    {
        // количество кратности
        private static int countPoints = 0;
        // список для карты кратности для выбранных бинов
        private static List<PointsSelectedObjects> countSelectedPointsInBin;
        // кол-во бинов
        private static int countBinX, countBinY;
        // размеры бинов
        static int sizeBinX = 25, sizeBinY = 25;
        // краность в бинах
        private static double[,] arrayBin = new double[0, 0];
        private static double minX, maxX, minY, maxY;

        public static List<PointsSelectedObjects> SelectedPointsInBin { get; set; }
        //размеры бинов
        public static int SizeBinX { get => sizeBinX; set => sizeBinX = value; }
        public static int SizeBinY { get => sizeBinY; set => sizeBinY = value; }
        // заполняем массив бинов краностью
        public static double[,] ArrayBin { get => arrayBin; }
        // получаем значения MAX и MIN
        public static double MaxX { get => maxX; }
        public static double MaxY { get => maxY; }

        public static List<Multiplicity> CoordMultiplicity { get; set; }

        public static List<PointsSelectedObjects> CountSelectedPointsInBin
        {
            get
            {
                if (SelectedPointsInBin.Count != 0) return countSelectedPointsInBin;
                else return null;
            }
        }

        public static void CountintsInBin()
        {
            countSelectedPointsInBin = new List<PointsSelectedObjects>();

            //for (int i = 0; i < selectedPointsInBin.Count; i++)
            //{
            //    double coordX = 0, coordY = 0;
            //    for (int j = 0; j < selectedPointsInBin.Count; j++)
            //    {
            //        if (selectedPointsInBin[i].PointX == selectedPointsInBin[j].PointX && selectedPointsInBin[i].PointY == selectedPointsInBin[j].PointY)
            //        {
            //            countPoints++;
            //            coordX = selectedPointsInBin[i].PointX;
            //            coordY = selectedPointsInBin[i].PointY;
            //        }
            //    }
            //    PointsSelectedObjects points = new PointsSelectedObjects(coordX, coordY, countPoints);
            //    countSelectedPointsInBin.Add(points);
            //    countPoints = 0;

            //}

            countSelectedPointsInBin = SelectedPointsInBin.GroupBy(p => new { p.PointX, p.PointY })
                                      .Select(g => new PointsSelectedObjects(g.Key.PointX, g.Key.PointY, g.Count())).ToList();
        }

        #region Подсчет бинов по Х и Y
        public static int CountBinX
        {
            get
            {
                // находим миниамльное и максимальное значение
                minX = Stations.MinPointX >= Sources.MinPointX ? Sources.MinPointX : Stations.MinPointX;
                maxX = Stations.MaxPointX >= Sources.MaxPointX ? Stations.MaxPointX : Sources.MaxPointX;
                countBinX = (int)((maxX - minX) / SizeBinX);
                return countBinX;
            }
        }

        public static int CountBinY
        {
            get
            {
                minY = Stations.MinPointY >= Sources.MinPointY ? Sources.MinPointY : Stations.MinPointY;
                maxY = Stations.MaxPointY >= Sources.MaxPointY ? Stations.MaxPointY : Sources.MaxPointY;
                countBinY = (int)((maxY - minY) / SizeBinY);
                return countBinY;
            }
        }
        #endregion


        public static void CountBin()
        {
            CountintsInBin();
            //arrayBin = new double[countBinX, countBinY];
            arrayBin = new double[CountBinX+1, CountBinY+1];
            foreach (var p in CountSelectedPointsInBin)
                arrayBin[Convert.ToInt32(p.PointX / SizeBinX), Convert.ToInt32(p.PointY / SizeBinY)]++;

        }

    }
}
