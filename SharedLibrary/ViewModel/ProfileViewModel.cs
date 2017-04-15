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
    using StravaUWP.Helper;

    public class ProfileViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Athlete _AthleteInfo;
        public ProfileViewModel()
        {
            ShoesCollection = new ObservableCollection<Shoe>();
            ClubsCollection = new ObservableCollection<Club>();
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

        private ObservableCollection<Club> _ClubsCollection;
        public ObservableCollection<Club> ClubsCollection
        {
            get { return _ClubsCollection; }
            set
            {
                _ClubsCollection = value;
            }
        }
        public async void LoadAthleteInfo()
        {
            string json = await FileHelper.ReadFile(AppConstants.ProfileFile);
            AthleteInfo = JsonConvert.DeserializeObject<Athlete>(json);

            ShoesCollection.Clear();
            if (AthleteInfo.shoes != null && AthleteInfo.shoes.Count > 0)
            {
                foreach (var shoe in AthleteInfo.shoes)
                {
                    ShoesCollection.Add(shoe);
                }
            }
            ClubsCollection.Clear();
            if (AthleteInfo.clubs != null && AthleteInfo.clubs.Count > 0)
            {
                foreach (var club in AthleteInfo.clubs)
                {
                    ClubsCollection.Add(club);
                }
            }
        }

        public async void RefreshAthleteInfo()
        {
            string res = await HttpHelper.GetRequest(StravaUri.BaseUri, StravaUri.AthleteResourse);
            AthleteInfo = JsonConvert.DeserializeObject<Athlete>(res);
            ShoesCollection.Clear();
            if (AthleteInfo.shoes != null && AthleteInfo.shoes.Count > 0)
            {
                foreach (var shoe in AthleteInfo.shoes)
                {
                    ShoesCollection.Add(shoe);
                }
            }
            ClubsCollection.Clear();
            if (AthleteInfo.clubs != null && AthleteInfo.clubs.Count > 0)
            {
                foreach (var club in AthleteInfo.clubs)
                {
                    ClubsCollection.Add(club);
                }
            }
            await FileHelper.WriteFile(AppConstants.ProfileFile, res);
        }
    }
}
