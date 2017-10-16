
namespace PlanSeysmicSystem.SeysmicSurveyClasses
{
    // класс карты кратности
    public class Multiplicity
    {
        // координaты бина
        private double x, y;

        public Multiplicity(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
    }
}
