using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace PlanSeysmicSystem.BinData
{
    public class DrawBinModel
    {
        public DrawBinModel()
        {
            this.BinModel = new PlotModel { Title = "Карта кратности" };
            this.BinModel.Axes.Add(new LinearColorAxis
            {
                Position = AxisPosition.Left,
                AxisTickToLabelDistance = 4,
                AxisDistance = 45,
                Angle = 0,
                SelectionMode = SelectionMode.Single,
                MinorStep = 2,
                Palette = OxyPalettes.BlueWhiteRed31,
                MajorTickSize = 20,
                AxislineThickness = 2,
                FontSize = 12,
                IsZoomEnabled = false,
                MajorStep = 1,
                
            });


            //OxyImage image;
            //using (FileStream stream = new FileStream(@"C:\Users\Александр\Desktop\1.png", FileMode.Open))
            //{
            //    image = new OxyImage(stream);

            //}

            //this.MyModel.Annotations.Add(new ImageAnnotation
            //{
            //    ImageSource = image,
            //    Opacity = 0.5,
            //    Interpolate = false,
            //    X = new PlotLength(0.2, PlotLengthUnit.RelativeToViewport),
            //    Y = new PlotLength(0.2, PlotLengthUnit.RelativeToViewport),
            //    Width = new PlotLength(0.2, PlotLengthUnit.RelativeToViewport),
            //    HorizontalAlignment = HorizontalAlignment.Center,
            //    VerticalAlignment = VerticalAlignment.Middle,


            //});

            double[,] arrayBin = new double[Bin.CountBinX+4, Bin.CountBinY+4];
            arrayBin = Bin.ArrayBin;

            var heatMapSeries = new HeatMapSeries
            {
                X0 = Bin.MaxX,
                X1 = 0,
                Y0 = Bin.MaxY,
                Y1 = 0,

                //    XAxisKey = "WeekdayAxis",
                //    YAxisKey = "CakeAxis",
                RenderMethod = HeatMapRenderMethod.Rectangles,
                //  CoordinateDefinition = HeatMapCoordinateDefinition.Edge,
                Selectable = true,
                RenderInLegend = true,
                LabelFontSize = 0.2, // neccessary to display the label
                Data = arrayBin
            };

            this.BinModel.Series.Add(heatMapSeries);
        }

        public PlotModel BinModel { get; private set; }
    }
}
