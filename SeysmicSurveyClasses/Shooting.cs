using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanSeysmicSystem.SeysmicSurveyClasses
{
    public static class Shooting
    {
        // переменнве дял выбора типа прострела
        public static bool? AutoShooting { get; set; }
        public static bool? HandShooting { get; set; }
        public static bool? SettingShooting { get; set; }

        // координаты выбранных точек
        public static double coordinateStartX { get; set; }
        public static double coordinateStartY { get; set; }
        // координаты выбранных точек
        public static double coordinateFinishX { get; set; }
        public static double coordinateFinishY { get; set; }
        // флаг для понимания какие коодинаты надо сохранить
        public static int flag { get; set; }
    }
}
