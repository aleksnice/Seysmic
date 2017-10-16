using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanSeysmicSystem.SeysmicSurveyClasses.SourcesD
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
        // кол-во возбудителей в одной линии
        private static int _countSources;
        // кол-во линий
        private static int _countSourcesCrossLine;
        // площадь
        private static int _squareHeight;
        private static int _squareWidth;

        // для выбора типа съемки
        private static bool _typeSurveySize;
        private static bool? _typeSurvey;

        public double PointX { get => _pointX; set => _pointX = value; }
        public double PointY { get => _pointY; set => _pointY = value; }
        public double PointZ { get => _pointZ; set => _pointZ = value; }
        public static int HorizSpacing { get => _horizSpacing; set => _horizSpacing = value; }
        public static int VertSpacing { get => _vertSpacing; set => _vertSpacing = value; }
        public static int XCor { get => _xCor; set => _xCor = value; }
        public static int YCor { get => _yCor; set => _yCor = value; }
        public static int CountSources { get => _countSources; set => _countSources = value; }
        public static int CountSourcesCrossLine { get => _countSourcesCrossLine; set => _countSourcesCrossLine = value; }
        public static int SquareHeight { get => _squareHeight; set => _squareHeight = value; }
        public static int SquareWidth { get => _squareWidth; set => _squareWidth = value; }
        public static bool TypeSurveySize { get => _typeSurveySize; set => _typeSurveySize = value; }
        public static bool? TypeSurvey { get => _typeSurvey; set => _typeSurvey = value; }

        public MegaBin(int horizSpacing, int vertSpacing, int xCor, int yCor, int countStation, int countStationCrossLine, int squareHeight, int squareWidth)
        {
            MegaBin._horizSpacing = horizSpacing;
            MegaBin._vertSpacing = vertSpacing;
            MegaBin._xCor = xCor;
            MegaBin._yCor = yCor;
            MegaBin._countSources = countStation;
            MegaBin._countSourcesCrossLine = countStationCrossLine;
            MegaBin._squareHeight = squareHeight;
            MegaBin._squareWidth = squareWidth;
        }

    }
}
