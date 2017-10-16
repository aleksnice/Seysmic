using PlanSeysmicSystem.Settings;
using System;
using System.Windows;


namespace PlanSeysmicSystem.BinData
{
    /// <summary>
    /// Логика взаимодействия для WindowSettingsMap.xaml
    /// </summary>
    public partial class WindowSettingsMap : Window
    {
        public WindowSettingsMap()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // задаем параметры изображения
                DrawTools.Height = Convert.ToDouble(txt_height.Text);
                DrawTools.Width = Convert.ToDouble(txt_width.Text);
                DrawTools.StartX = Convert.ToDouble(txt_PointX.Text);
                DrawTools.StartY = Convert.ToDouble(txt_PointY.Text);
                DrawTools.DrawImg = true; // разрешаем его добавить
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка при вводе данных! Проверьте введенные параметры.", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
