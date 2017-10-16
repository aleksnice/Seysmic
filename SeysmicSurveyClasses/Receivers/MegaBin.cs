using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanSeysmicSystem.SeysmicSurveyClasses.Receivers
{
    public class MegaBin
    {
        // координаты точек
        private double _pointX;
        private double _pointY;
        private double _pointZ;

        // расстояние между датчиками по горизонтали
        private static int _horizSpacing;
        // расстояние между датчиками по вертикали
        private static int _vertSpacing;
        // расположение первого датчика по оси Х
        private static int _xCor;
        // расположение первого датчика по оси У
        private static int _yCor;
        // кол-во приемников в одной линии
        private static int _countStation;
        // кол-во линий
        private static int _countStationCrossLine;
        // площадь
        private static int _squareHeight;
        private static int _squareWidth;
        // тип размера съемки
        private static bool _typeSurveySize;

        public MegaBin(int horizSpacing, int vertSpacing, int xCor, int yCor, int countStation, int countStationCrossLine, int squareHeight, int squareWidth)
        {
            MegaBin._horizSpacing = horizSpacing;
            MegaBin._vertSpacing = vertSpacing;
            MegaBin._xCor = xCor;
            MegaBin._yCor = yCor;
            MegaBin._countStation = countStation;
            MegaBin._countStationCrossLine = countStationCrossLine;
            MegaBin._squareHeight = squareHeight;
            MegaBin._squareWidth = squareWidth;
        }

        public double PointX { get => _pointX; set => _pointX = value; }
        public double PointY { get => _pointY; set => _pointY = value; }
        public double PointZ { get => _pointZ; set => _pointZ = value; }
        public static int HorizSpacing { get => _horizSpacing; set => _horizSpacing = value; }
        public static int VertSpacing { get => _vertSpacing; set => _vertSpacing = value; }
        public static int XCor { get => _xCor; set => _xCor = value; }
        public static int YCor { get => _yCor; set => _yCor = value; }
        public static int CountStation { get => _countStation; set => _countStation = value; }
        public static int CountStationCrossLine { get => _countStationCrossLine; set => _countStationCrossLine = value; }
        public static int SquareHeight { get => _squareHeight; set => _squareHeight = value; }
        public static int SquareWidth { get => _squareWidth; set => _squareWidth = value; }
        public static bool TypeSurveySize { get => _typeSurveySize; set => _typeSurveySize = value; }
    }
}
