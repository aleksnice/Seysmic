using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PlanSeysmicSystem.SeysmicSurveyClasses.Zone
{
    public class DistrictZone
    {
        public double StartX { get; set; }
        public double StartY { get; set; }
        public double FinishX { get; set; }
        public double FinishY { get; set; }
        public bool EnableZone { get; set; }

        public static ObservableCollection<DistrictZone> ListSistrictZones { get; set; } 

        public DistrictZone(double startX, double startY, double finishX, double finishY, bool enableZone)
        {
            StartX = startX;
            StartY = startY;
            FinishX = finishX;
            FinishY = finishY;
            EnableZone = enableZone;
        }
    }
}
