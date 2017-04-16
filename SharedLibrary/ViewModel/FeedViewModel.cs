using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.ViewModel
{
    using StravaDotNet;
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    public class FeedViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public FeedViewModel()
        {
            FollowerActivityCollection = new ObservableCollection<ActivitySummary>();
        }
        private ObservableCollection<ActivitySummary> _FollowerActivityCollection;
        public ObservableCollection<ActivitySummary> FollowerActivityCollection
        {
            get { return _FollowerActivityCollection; }
            set
            {
                _FollowerActivityCollection = value;
            }
        }

        public async void RefreshFeed()
        {
            ActivityClient Activity = new ActivityClient();
            List<ActivitySummary> Summary = await Activity.GetFollowersActivitiesAsync(1, 100);
            System.Diagnostics.Debug.WriteLine("Summary received");
        }
    }
}
