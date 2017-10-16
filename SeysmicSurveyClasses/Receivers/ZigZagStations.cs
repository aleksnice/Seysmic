using LiveCharts;
using LiveCharts.Defaults;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PlanSeysmicSystem.SeysmicSurveyClasses.Receivers
{
    public static class ZigZagStations 
    {
        /// <summary>
        /// Шаг по оси Х
        /// </summary>
        public static double ZigX { get; set; }
        /// <summary>
        ///  Шаг по оси У
        /// </summary>
        public static double ZigY { get; set; }
        public static double ZagX { get; set; }
        public static double ZagY { get; set; }
        /// <summary>
        /// Расстояние между линиями
        /// </summary>
        public static double CrosslineSpacing { get; set; } 
        public static int StationsPerLeg { get; set; }
        /// <summary>
        /// ПП в линии
        /// </summary>
        public static int StationsInLine { get; set; }
        // Количество линий ПП
        public static int StationsOfLines { get; set; }
        public static double FirstStationX { get; set; }
        public static double FirstStationY { get; set; }
        /// <summary>
        /// Помечать удалять ли раннее устанавленные ПП
        /// </summary>
        public static bool RemoveStations { get; set; }

        private static ChartValues<ObservablePoint> listPointsZigZagStation;

        public static ChartValues<ObservablePoint> ListPointsZigZagStation
        {
            get
            {
                listPointsZigZagStation = new ChartValues<ObservablePoint>();
                // новый список ПП
                Stations.ListStations = new ObservableCollection<Stations>();
                int lineIndex = 0;
                string lineName = "0";

                double x = FirstStationX;
                double y = FirstStationY;
                int stepZig = 1, stepZag = StationsPerLeg + 1;
                int numberPP = 0;
                for (int i = 0; i < StationsOfLines; i++)
                {
                    lineIndex++;
                    if (i < 9) lineName = "0" + (i + 1);
                    else lineName = i.ToString();

                    if (i != 0) y = FirstStationY;
                    int recordIndex = 0;
                    for (int j = 0; j < StationsInLine; j++)
                    {
                        recordIndex++;
                        string recordNumber = (j < 9) ? (i + 1) + "000" + recordIndex : (i + 1) + "00" + recordIndex;

                        if (stepZig <= StationsPerLeg)
                        {
                            listPointsZigZagStation.Add(new ObservablePoint(x, y));
                            if (stepZig != StationsPerLeg)
                            {
                                x += ZigX;
                                y += ZigY;
                                stepZig += 1;
                            }
                            else
                            {
                                stepZag = 1;
                                stepZig += 1;
                                y += ZigY;
                                continue;
                            }
                        }
                        if(stepZag <= StationsPerLeg)
                        {
                            listPointsZigZagStation.Add(new ObservablePoint(x, y));
                            if (stepZag != StationsPerLeg)
                            {
                                x += ZagX;
                                y += ZagY;
                                stepZag += 1;
                            }
                            else
                            {
                                stepZig = 1;
                                stepZag += 1;
                                y += ZagY;
                                continue;
                            }
                        }
                        // заполняем список приемников
                        Stations stations = new Stations(lineIndex, lineName, recordIndex, recordNumber, "Зигзаг схема", x, y, 0.00, numberPP);
                        Stations.ListStations.Add(stations);
                        numberPP++;
                    }
                    x += CrosslineSpacing;
                }
                return listPointsZigZagStation;
            }
        }

    }
}
