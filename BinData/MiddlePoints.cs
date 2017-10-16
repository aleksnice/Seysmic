using LiveCharts;
using LiveCharts.Defaults;
using PlanSeysmicSystem.SeysmicSurveyClasses;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Collections.Generic;

namespace PlanSeysmicSystem.BinData
{
    public class MiddlePoints
    {
        private static ChartValues<ObservablePoint> _middlePointsBin;
        public static List<PointsSelectedObjects> ListMiddlePointsBin { get; set; }      
        public static List<PointsSelectedObjects> ListFiredStation { get; set; }
        public static List<PointsSelectedObjects> ListFiredSources { get; set; }
        public static ChartValues<ObservablePoint> MiddlePointsBin { get => _middlePointsBin; }
        public PlotModel MiddlePointsModel { get; set; }

        #region Карта средних тчоек
        public MiddlePoints()
        {
            var plotModel = new PlotModel { Title = "Поле средних точек"};
            var line = new LineSeries
            {
                StrokeThickness = 0,
                MarkerSize = 3,
                MarkerStroke = OxyColors.Transparent,                
                MarkerType = MarkerType.Circle

            };

            for(int i = 0; i < MiddlePointsBin.Count; i++)
            {
                line.Points.Add(new DataPoint(MiddlePointsBin[i].X, MiddlePointsBin[i].Y));
            }


            plotModel.Series.Add(line);
            this.MiddlePointsModel = plotModel;
        }
        #endregion



        public static void CountPoints()
        {
            // обнуляем счетчик
            _middlePointsBin = null;
            ListMiddlePointsBin = null;

            for (int i = 0; i < ListFiredSources.Count; i++)
            {
                // проходим по списку ПП
                for (int j = 0; j < ListFiredStation.Count; j++)
                {
                    // координата средней точки по оси Х
                    double xBin = (ListFiredSources[i].PointX + ListFiredStation[j].PointX) / 2;
                    // координата средней точки по оси У
                    double yBin = (ListFiredSources[i].PointY + ListFiredStation[j].PointY) / 2;
                    // добавляем в список среднюю точку соответсвующего бина
                    _middlePointsBin.Add(new ObservablePoint(xBin, yBin));
                    PointsSelectedObjects pointsSelectedObjects = new PointsSelectedObjects(xBin, yBin);
                    ListMiddlePointsBin.Add(pointsSelectedObjects);
                }
            }
            // передаем список средних тчоек для определения их координат
            Bin.SelectedPointsInBin = ListMiddlePointsBin;
        }
    }
}
