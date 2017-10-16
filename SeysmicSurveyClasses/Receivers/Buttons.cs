using LiveCharts;
using LiveCharts.Defaults;
using System;


namespace PlanSeysmicSystem.SeysmicSurveyClasses.Receivers
{
    public static class Buttons
    {
        /// <summary>
        /// ПП по горизонтали
        /// </summary>
        public static int InlineStations { get; set; }
        /// <summary>
        /// ПП по вретикали
        /// </summary>
        public static int CrosslineStations { get; set; }
        /// <summary>
        /// Расстояние по горизонтали
        /// </summary>
        public static double InlineSpacing { get; set; }
        /// <summary>
        /// РАстояние по вертикали
        /// </summary>
        public static double CrosslineSpacing { get; set; }
        /// <summary>
        /// Количество Buttons по горизонатли
        /// </summary>
        public static int InlineButtons { get; set; }
        /// <summary>
        /// Количество Buttons по вертикали
        /// </summary>
        public static int CrosslineButtons { get; set; }
        /// <summary>
        /// Расстояние между Buttons по горизонтали
        /// </summary>
        public static double InlineSeparation { get; set; }
        /// <summary>
        ///  Расстояние между Buttons по вертикали
        /// </summary>
        public static double CrosslineSeparation { get; set; }
        /// <summary>
        /// Начальная точка по Х
        /// </summary>
        public static double FirstStationX { get; set; }
        /// <summary>
        /// Начальная точка по У
        /// </summary>
        public static double FirstStationY { get; set; }

        // список точек
        private static ChartValues<ObservablePoint> listPointsButtonStation;

        public static ChartValues<ObservablePoint> ListPointsButtonStation
        {
            get
            {
                listPointsButtonStation = new ChartValues<ObservablePoint>();
                double x = FirstStationX;
                double y = FirstStationY;
                double x1 = 0, y1 = 0;
                double spacingX = InlineStations * (InlineSpacing - 1);
                double spacingY = CrosslineStations * (CrosslineSpacing - 1);
                for (int i = 0; i < (InlineButtons); i++)
                {
                    if (i > 0) x = x1 + InlineSeparation;
                    for(int j = 0; j < CrosslineButtons; j++)
                    {
                        if (j > 0)
                        {
                            y = y1 + spacingY + CrosslineSeparation;
                        }
                        for(int k = 0; k < InlineStations; k++)
                        {
                            if (k == 0) x1 = x;
                            else x1 = x1 + InlineSpacing;
                            for(int h = 0; h < CrosslineStations; h++)
                            {
                                if (h == 0) y1 = y;
                                else y1 = y1 + CrosslineSpacing;
                                listPointsButtonStation.Add(new ObservablePoint(x1, y1));
                            }
                        }
                    }
                }

                return listPointsButtonStation;
            }
        }

    }
}
