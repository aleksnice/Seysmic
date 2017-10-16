using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PlanSeysmicSystem.SeysmicSurveyClasses
{
    public class VisibilitySeries: INotifyPropertyChanged
    {
        private bool _stationsSeriesVisibility;
        private bool _sourcesSeriesVisibility;
        private bool _scaterSeriesVisibility;

        public bool StationsSeriesVisibility
        {
            get => _stationsSeriesVisibility;
            set
            {
                _stationsSeriesVisibility = value;
                OnPropertyChanged("StationsSeriesVisibility");
            }
        }
        public  bool SourcesSeriesVisibility
        {
            get => _sourcesSeriesVisibility;
            set
            {
                _sourcesSeriesVisibility = value;
                OnPropertyChanged("SourcesSeriesVisibility");
            }
        }
        public  bool ScaterSeriesVisibility
        {
            get => _scaterSeriesVisibility;
            set
            {
                _scaterSeriesVisibility = value;
                OnPropertyChanged("ScaterSeriesVisibility");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
