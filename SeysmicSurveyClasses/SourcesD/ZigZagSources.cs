using LiveCharts;
using LiveCharts.Defaults;
using System;
using System.Collections.ObjectModel;

namespace PlanSeysmicSystem.SeysmicSurveyClasses.SourcesD
{
    public class ZigZagSources
    {
        /// <summary>
        /// Шаг зига по оси Х
        /// </summary>
        public static double ZigX { get; set; }
        /// <summary>
        ///  Шаг зига по оси У
        /// </summary>
        public static double ZigY { get; set; }
        public static double ZagX { get; set; }
        public static double ZagY { get; set; }
        /// <summary>
        /// Расстояние между линиями
        /// </summary>
        public static double CrosslineSpacing { get; set; }
        /// <summary>
        /// Количество датчиков в линии зига и зага
        /// </summary>
        public static int SourcesPerLeg { get; set; }
        /// <summary>
        /// ПП в линии
        /// </summary>
        public static int SourcesInLine { get; set; }
        // Количество линий ПП
        public static int SourcesOfLines { get; set; }
        public static double FirstSourceX { get; set; }
        public static double FirstSourceY { get; set; }
        /// <summary>
        /// Помечать удалять ли раннее устанавленные ПП
        /// </summary>
        public static bool RemoveSources { get; set; }

        private static ChartValues<ObservablePoint> listPointsZigZagSource= new ChartValues<ObservablePoint>();

        public static ChartValues<ObservablePoint> ListPointsZigZagSource
        {
            get
            {
                listPointsZigZagSource = new ChartValues<ObservablePoint>();
                int lineIndex = 0;
                string lineName = "0";
                // новый список ПП
                Sources.listSources = new ObservableCollection<Sources>();

                double x = FirstSourceX;
                double y = FirstSourceY;
                int stepZig = 1, stepZag = SourcesPerLeg + 1;
                int numberPV = 0;
                for (int i = 0; i < SourcesOfLines; i++)
                {
                    lineIndex++;
                    if (i < 9) lineName = "0" + (i + 1);
                    else lineName = i.ToString();

                    if (i != 0) y = FirstSourceY;

                    int recordIndex = 0;
                    for (int j = 0; j < SourcesInLine; j++)
                    {
                        recordIndex++;
                        string recordNumber = (j < 9) ? (i + 1) + "000" + recordIndex : (i + 1) + "00" + recordIndex;


                        if (stepZig <= SourcesPerLeg)
                        {
                            listPointsZigZagSource.Add(new ObservablePoint(x, y));
                            if (stepZig != SourcesPerLeg)
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
                        if (stepZag <= SourcesPerLeg)
                        {
                            listPointsZigZagSource.Add(new ObservablePoint(x, y));
                            if (stepZag != SourcesPerLeg)
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
                        Sources source = new Sources(lineIndex, lineName, recordIndex, recordNumber, "Зигзаг схема", x, y, 0.00, numberPV);
                        Sources.listSources.Add(source);

                        numberPV++;
                    }
                    x += CrosslineSpacing;
                }
                return listPointsZigZagSource;
            }
        }

    }
}
