using PlanSeysmicSystem.SeysmicSurveyClasses.Receivers;
using System;
using System.Windows;


namespace PlanSeysmicSystem
{
    /// <summary>
    /// Логика взаимодействия для SettingsStationZigZag.xaml
    /// </summary>
    public partial class SettingsStationZigZag : Window
    {
        public SettingsStationZigZag()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            // LoadData();
        }


        private void LoadData()
        {
            txt_CrossLine.Text = ZigZagStations.CrosslineSpacing.ToString();
            txt_inline.Text = ZigZagStations.StationsInLine.ToString();
            txt_line.Text = ZigZagStations.StationsOfLines.ToString();
            txt_PerLeg.Text = ZigZagStations.StationsPerLeg.ToString();
            txt_x.Text = ZigZagStations.FirstStationX.ToString();
            txt_y.Text = ZigZagStations.FirstStationY.ToString();
            txt_ZagX.Text = ZigZagStations.ZagX.ToString();
            txt_ZagY.Text = ZigZagStations.ZagY.ToString();
            txt_ZigX.Text = ZigZagStations.ZigX.ToString();
            txt_ZigY.Text = ZigZagStations.ZigY.ToString();
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            ZigZagStations.CrosslineSpacing = Convert.ToDouble(txt_CrossLine.Text);
            ZigZagStations.StationsOfLines = Convert.ToInt32(txt_inline.Text);
            ZigZagStations.StationsInLine = Convert.ToInt32(txt_line.Text);
            ZigZagStations.StationsPerLeg = Convert.ToInt32(txt_PerLeg.Text);
            ZigZagStations.FirstStationX = Convert.ToDouble(txt_x.Text);
            ZigZagStations.FirstStationY = Convert.ToDouble(txt_y.Text);
            ZigZagStations.ZagX = Convert.ToDouble(txt_ZagX.Text);
            ZigZagStations.ZagY = Convert.ToDouble(txt_ZagY.Text);
            ZigZagStations.ZigX = Convert.ToDouble(txt_ZigX.Text);
            ZigZagStations.ZigY = Convert.ToDouble(txt_ZigY.Text);
            this.Close();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
