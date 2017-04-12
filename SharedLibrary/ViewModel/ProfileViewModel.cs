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
        public ProfileViewModel()
        {
            ShoesCollection = new ObservableCollection<Shoe>();
        }
        public Athlete AthleteInfo
        {
            get { return _AthleteInfo; }
            set
            {
                _AthleteInfo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AthleteInfo)));
            }
        }

        private ObservableCollection<Shoe> _ShoesCollection;
        public ObservableCollection<Shoe> ShoesCollection
        {
            get { return _ShoesCollection; }
            set
            {
                _ShoesCollection = value;
            }
        }

        public async void LoadAthleteInfo()
        {
            string json = await FileHelper.ReadFile(AppConstants.ProfileFile);
            AthleteInfo = JsonConvert.DeserializeObject<Athlete>(json);
            
            ShoesCollection.Clear();
            foreach (var shoe in AthleteInfo.shoes)
            {
                ShoesCollection.Add(shoe);
            }
        }
    }
}
