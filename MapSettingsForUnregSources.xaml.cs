using PlanSeysmicSystem.SeysmicSurveyClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PlanSeysmicSystem
{
    /// <summary>
    /// Логика взаимодействия для MapSettingsForUnregSources.xaml
    /// </summary>
    public partial class MapSettingsForUnregSources : Window
    {
        public MapSettingsForUnregSources()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // загружаем исходные данные
            txt_FinishPointX.Text = MapInstallSettings.MaxX.ToString();
            txt_FinishPointY.Text = MapInstallSettings.MaxY.ToString();
            txt_MaxCountPV.Text = MapInstallSettings.MaxCountSources.ToString();
            txt_MinCountPV.Text = MapInstallSettings.MinCountSources.ToString();
            txt_StartPointX.Text = MapInstallSettings.MinX.ToString();
            txt_StartPointY.Text = MapInstallSettings.MinY.ToString();
            chb_minPV.IsChecked = MapInstallSettings.BoolMinCountSources;
            chb_maxPV.IsChecked = MapInstallSettings.BoolMaxCountSources;
        }

        private void chb_minPV_Checked(object sender, RoutedEventArgs e)
        {
            // открываем спрятаные поля
            if (chb_minPV.IsChecked == true) stack_min.Visibility = Visibility.Visible;
            if (chb_maxPV.IsChecked == true) stack_max.Visibility = Visibility.Visible;
        }

        private void chb_minPV_Unchecked(object sender, RoutedEventArgs e)
        {
            // скрываем спрятанные поля
            if (chb_minPV.IsChecked == false) stack_min.Visibility = Visibility.Collapsed;
            if (chb_maxPV.IsChecked == false) stack_max.Visibility = Visibility.Collapsed;
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            MapInstallSettings.MinX = Convert.ToDouble(txt_StartPointX.Text);
            MapInstallSettings.MinY = Convert.ToDouble(txt_StartPointY.Text);
            if (Convert.ToDouble(txt_FinishPointX.Text) > 0 && Convert.ToDouble(txt_FinishPointX.Text) > MapInstallSettings.MinX) MapInstallSettings.MaxX = Convert.ToDouble(txt_FinishPointX.Text);
            else
            {
                MessageBox.Show("Конечная коордианата X должна быть > 0 и не быть равной Минимальной координате по Х!");
                return;
            }
            if (Convert.ToDouble(txt_FinishPointY.Text) > 0 && Convert.ToDouble(txt_FinishPointY.Text) > MapInstallSettings.MinY) MapInstallSettings.MaxY = Convert.ToDouble(txt_FinishPointY.Text);
            else
            {
                MessageBox.Show("Конечная коордианата Y должна быть > 0 и не быть равной Минимальной координате по Y!");
                return;
            }

            if (chb_minPV.IsChecked == true)
            {
                MapInstallSettings.BoolMinCountSources = true;
                if (Convert.ToDouble(txt_MinCountPV.Text) > 0 && Convert.ToDouble(txt_MinCountPV.Text) < Convert.ToDouble(txt_MaxCountPV.Text) && chb_maxPV.IsChecked == true) MapInstallSettings.MinCountSources = Convert.ToInt32(txt_MinCountPV.Text);
                else if (Convert.ToDouble(txt_MinCountPV.Text) > 0) MapInstallSettings.MinCountSources = Convert.ToInt32(txt_MinCountPV.Text);
                else
                {
                    MessageBox.Show("Минимальное количество ПП должно быть > 0 и < макс кол-ву ПП");
                    return;
                }
            }
            if (chb_maxPV.IsChecked == true)
            {
                MapInstallSettings.BoolMaxCountSources = true;
                if (Convert.ToDouble(txt_MaxCountPV.Text) > 0 && Convert.ToDouble(txt_MaxCountPV.Text) > Convert.ToInt32(txt_MinCountPV.Text) && chb_minPV.IsChecked == true) MapInstallSettings.MaxCountSources = Convert.ToInt32(txt_MaxCountPV.Text);
                if (Convert.ToDouble(txt_MaxCountPV.Text) > 0) MapInstallSettings.MaxCountSources = Convert.ToInt32(txt_MaxCountPV.Text);
                else
                {
                    MessageBox.Show("Максимальное количество ПП должно быть > 0 и > мин кол-ву ПП");
                    return;
                }
            }
            // разречаем отрисовку
            MapInstallSettings.BoolDrawSources = true;
            this.Close();
        }
    }
}
