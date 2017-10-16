using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PlanSeysmicSystem.SeysmicSurveyClasses
{
    // класс для хранения размеров сетки пострения
    public static class MapInstallSettings
    {
        public static double MinX { get; set; }
        public static double MinY { get; set; }
        public static double MaxX { get; set; }
        public static double MaxY { get; set; }
        // макс и мин число ПП и ПВ
        public static int MinCountStations { get; set; }
        public static int MaxCountStations { get; set; }
        public static int MinCountSources { get; set; }
        public static int MaxCountSources { get; set; }
        // проверяем заданы ли мин и макс кол-ва
        public static bool BoolMinCountStations { get; set; }
        public static bool BoolMinCountSources { get; set; }
        public static bool BoolMaxCountStations { get; set; }
        public static bool BoolMaxCountSources { get; set; }
        // проверяем на ручную отрисовку
        public static bool BoolDrawStations{ get; set; }
        public static bool BoolDrawSources { get; set; }
    }
}