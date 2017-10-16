using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanSeysmicSystem.SeysmicSurveyClasses
{
    public class PointsSelectedObjects
    {
        private double pointX;
        private double pointY;
        private int numRect;
        private int countPoints;
        private bool bPoint;

        public PointsSelectedObjects(double x, double y, int numRect)
        {
            pointX = x;
            pointY = y;
            this.numRect = numRect;
        }

        public PointsSelectedObjects(double x, double y, int countPoints, bool bPoint = false)
        {
            pointX = x;
            pointY = y;
            this.countPoints = countPoints;
            this.bPoint = bPoint;
        }



        public PointsSelectedObjects(double x, double y)
        {
            pointX = x;
            pointY = y;
        }

        public double PointX { get => pointX; }

        public double PointY { get => pointY; }

        public int NumRect { get => numRect; set => numRect = value; }

        public int CountPoints { get => countPoints; }
    }
}