using Microsoft.Win32;
using PlanSeysmicSystem.SeysmicSurveyClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
    /// Логика взаимодействия для TablePointsSource.xaml
    /// </summary>
    public partial class TablePointsSource : Window
    {
        public TablePointsSource()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            LoadData();
            DataContext = this;
        }

        private ObservableCollection<Sources> _stations;

        public ObservableCollection<Sources> StationsPoint
        {
            get { return _stations; }
            set
            {
                _stations = value;
                OnPropertyChanged("Sources");
            }
        }


        #region МЕТОДЫ

        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private void FilterStations(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                LoadData();
                return;
            }

            if (rbt1.IsChecked == true) StationsPoint = new ObservableCollection<Sources>(Sources.listSources.Where(p => p.LineIndex.ToString().Contains(text)));
            else if (rbt2.IsChecked == true) StationsPoint = new ObservableCollection<Sources>(Sources.listSources.Where(p => p.LineName.ToString().Contains(text)));
            else if (rbt3.IsChecked == true) StationsPoint = new ObservableCollection<Sources>(Sources.listSources.Where(p => p.RecordNumber.ToString().Contains(text)));
            else if (rbt4.IsChecked == true) StationsPoint = new ObservableCollection<Sources>(Sources.listSources.Where(p => p.PointX.ToString().Contains(text)));
            else if (rbt5.IsChecked == true) StationsPoint = new ObservableCollection<Sources>(Sources.listSources.Where(p => p.PointY.ToString().Contains(text)));

            dgrPoints.ItemsSource = StationsPoint;
        }


        void LoadData()
        {
            StationsPoint = new ObservableCollection<Sources>(Sources.listSources);
            dgrPoints.ItemsSource = StationsPoint;
        }
        #endregion

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = txt_search.Text.ToLower();

            FilterStations(filter);
        }

        #region Изменения шрифта в таблице ЖИРНЫЙ или КУРСИВ
        private void chbBold_Checked(object sender, RoutedEventArgs e)
        {
            dgrPoints.FontWeight = FontWeights.ExtraBold;
        }

        private void chbBold_Unchecked(object sender, RoutedEventArgs e)
        {
            dgrPoints.FontWeight = FontWeights.Regular;
        }

        private void chbItalic_Checked(object sender, RoutedEventArgs e)
        {
            dgrPoints.FontStyle = FontStyles.Italic;
        }

        private void chbItalic_Unchecked(object sender, RoutedEventArgs e)
        {
            dgrPoints.FontStyle = FontStyles.Normal;
        }

        #endregion

        #region Изменения ячейки
        bool isEditEnding = false;

        private void dgrPoints_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {
            if (isEditEnding)
            {
                return;
            }
            try
            {
                isEditEnding = true;
                MessageBoxResult mr = MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (mr == MessageBoxResult.No)
                {
                    e.Cancel = true;
                    (sender as DataGrid).CancelEdit(DataGridEditingUnit.Cell);
                }
            }
            finally
            {
                isEditEnding = false;
            }
        }


        #endregion

        private void btn_imp_Click(object sender, RoutedEventArgs e)
        {

            SaveFileDialog dlg = new SaveFileDialog();
            // Configure save file dialog box
            dlg.Title = "Импорт-ПП";
            dlg.FileName = "Таблица - ПП"; // Default file name
            dlg.Filter = "Execl files (*.xls)|*.xls";  // Filter files by extension

            // Show save file dialog box
            Nullable<bool> answ = dlg.ShowDialog();

            // Process save file dialog box results
            if (answ == true)
            {
                dgrPoints.SelectAllCells();
                dgrPoints.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, dgrPoints);
                String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                String result = (string)Clipboard.GetData(DataFormats.Text);
                dgrPoints.UnselectAllCells();
                FileStream fs = null;
                try
                {
                    fs = new FileStream(dlg.FileName, FileMode.CreateNew);
                    using (StreamWriter writer = new StreamWriter(fs, Encoding.Default))
                    {
                        writer.WriteLine(result);
                    }
                }
                finally
                {
                    if (fs != null)
                        fs.Dispose();
                }
            }

        }


        private void btn_print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog Printdlg = new PrintDialog();
            if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
            {
                Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);
                // sizing of the element.
                dgrPoints.Measure(pageSize);
                dgrPoints.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                Printdlg.PrintVisual(dgrPoints, Title);
            }
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            txt_search.Text = "";
        }

        private void btn_newScheme_Click(object sender, RoutedEventArgs e)
        {
            Sources.listSources.Clear();
            LoadData();
            Sources.ChangedData = true;
        }
    }
}
