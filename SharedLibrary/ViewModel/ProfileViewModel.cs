using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.ViewModel
{
   
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Constants;
    using Helper;
    using Newtonsoft.Json;
    public class ProfileViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Athlete _AthleteInfo;
        public Athlete AthleteInfo
        {
            get { return _AthleteInfo; }
            set
            {
                _AthleteInfo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AthleteInfo)));
            }
        }

       

        public async void LoadAthleteInfo()
        {
            string json = await FileHelper.ReadFile(AppConstants.ProfileFile);
            AthleteInfo = JsonConvert.DeserializeObject<Athlete>(json);
        }
    }
}
