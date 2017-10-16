using LiveCharts;
using LiveCharts.Defaults;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PlanSeysmicSystem.SeysmicSurveyClasses
{
    public class Stations
    {
        // координаты точек
        private double _pointX;
        private double _pointY;
        private double _pointZ;


        // мин и макс координаты по Х
        private static double _minPointX;
        private static double _maxPointX;

        // мин и макс координаты по У
        private static double _minPointY;
        private static double _maxPointY;

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
        //жизненный этап ПВ
        private int _liveSource;
        //регулярный или неруглярный
        private int _regOrUnreg;
        // тип размера съемки
        private static bool _typeSurveySize;
        // характеристики для таблицы данных
        private int _lineIndex;
        private string _lineName;
        private int _recordIndex;
        private string _recordNumber;
        private string _typeScheme;
        private static bool _changedData;
        private int _numberStation;

        public static ObservableCollection<Stations> ListStations { get; set; }
  
        //  список нерегулярной сетки для схемы
        public static ChartValues<ObservablePoint> UnregularPointsStations { get; set; }

        public Stations(int horizSpacing, int vertSpacing, int xCor, int yCor, int countStation, int countStationCrossLine, int squareHeight, int squareWidth)
        {
            Stations._horizSpacing = horizSpacing;
            Stations._vertSpacing = vertSpacing;
            Stations._xCor = xCor;
            Stations._yCor = yCor;
            Stations._countStation = countStation;
            Stations._countStationCrossLine = countStationCrossLine;
            Stations._squareHeight = squareHeight;
            Stations._squareWidth = squareWidth;
        }

        public Stations(double x, double y, int liveSource = 0, int regOrUnreg = 0)
        {
            _pointX = x;
            _pointY = y;
            _liveSource = liveSource;
            _regOrUnreg = regOrUnreg;
        }
        /// <summary>
        /// Формируем информацио о ПП
        /// </summary>
        /// <param name="lineIndex">Номер линии</param>
        /// <param name="lineName">Наименование линии</param>
        /// <param name="recordIndex">Номер записи</param>
        /// <param name="recordNumber">Наименование точки</param>
        /// <param name="typeScheme">Тип схемы</param>
        /// <param name="x">Координата Х</param>
        /// <param name="y">Координата У</param>
        /// <param name="z">Координата Z</param>
        public Stations(int lineIndex, string lineName, int recordIndex, string recordNumber, string typeScheme, double x, double y, double z = 0.00, int numberStation = 0)
        {
            _lineIndex = lineIndex;
            _lineName = lineName;
            _recordIndex = recordIndex;
            _recordNumber = recordNumber;
            _pointX = x;
            _pointY = y;
            _pointZ = z;
            _typeScheme = typeScheme;
            _numberStation = numberStation;
        }

        /// <summary>
        /// Формируем информацио о ПП
        /// </summary>
        /// <param name="recordIndex">Номер записи</param>
        /// <param name="recordNumber">Наименование точки</param>
        /// <param name="x">Координата Х</param>
        /// <param name="y">Координата У</param>
        /// <param name="typeScheme">Тип схемы</param>
        /// <param name="z">Координата Z</param>
        public Stations(int recordIndex, string recordNumber, string typeScheme, double x, double y, double z = 0.00, int numberStation = 0)
        {
            _recordIndex = recordIndex;
            _recordNumber = recordNumber;
            _pointX = Math.Round(x, 2);
            _pointY = Math.Round(y, 2);
            _pointZ = Math.Round(z, 2);
            _typeScheme = typeScheme;
            _numberStation = numberStation;
        }

        public Stations()
        {
            Stations.ListStations = ListStations;
        }

        public static int HorizSpacing { get => _horizSpacing; }

        public static int VertSpacing { get => _vertSpacing; }

        public static int XCor { get => _xCor; }

        public static int YCor { get => _yCor; }

        public static int CountSource { get => _countStation; }

        public static int CountSourcesCrossLine { get => _countStationCrossLine; }

        public static int SquareHeight { get => _squareHeight; }

        public static int SquareWidth { get => _squareWidth; }


        public static List<Stations> UnRegularStations { get; set; }

        public static double MinPointX { get => _minPointX; set => _minPointX = value; }

        public static double MaxPointX { get => _maxPointX; set => _maxPointX = value; }

        public static double MinPointY { get => _minPointY; set => _minPointY = value; }

        public static double MaxPointY { get => _maxPointY; set => _maxPointY = value; }


        public static bool TypeSurveySize { get => _typeSurveySize; set => _typeSurveySize = value; }
        public int LineIndex { get => _lineIndex; set => _lineIndex = value; }
        public string LineName { get => _lineName; set => _lineName = value; }
        public int RecordIndex { get => _recordIndex; set => _recordIndex = value; }
        public string RecordNumber { get => _recordNumber; set => _recordNumber = value; }
        public double PointX { get => _pointX; set => _pointX = value; }
        public double PointY { get => _pointY; set => _pointY = value; }
        public double PointZ { get => _pointZ; set => _pointZ = value; }
        public string TypeScheme { get => _typeScheme; set => _typeScheme = value; }
        public static bool ChangedData { get => _changedData; set => _changedData = value; }
        public int NumberStation { get => _numberStation; set => _numberStation = value; }
    }
}
