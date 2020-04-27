using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using FriendOrganizer.UI.Wrapper;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FriendOrganizer.UI.ViewModel
{
    class FriendDatailViewModel : ViewModelBase, IFriendDatailViewModel
    {
        private IFriendDataService _dataservice;
        private IEventAggregator _eventAggregator;
        private FriendWrapper _friend;

        public FriendDatailViewModel(IFriendDataService dataService,
            IEventAggregator eventAggregator)
        {
            _dataservice = dataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenFriendDatailViewEvent>()
                .Subscribe(OnOpenFriendDatailView);
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }
        public async Task LoadAsync(int friendId)
        {
            var friend = await _dataservice.GetByIdAsync(friendId);

            Friend = new FriendWrapper(friend);
        }

        public FriendWrapper Friend
        {
            get { return _friend; }
            private set
            {
                _friend = value;
                OnPropertyChange();
            }
        }
        public ICommand SaveCommand { get; }

        private async void OnSaveExecute()
        {

           await _dataservice.SaveAsync(Friend.Model);
            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Publish(
                new AfterFriendSavedEventArgs
                {
                    Id = Friend.Id,
                    DisplayMember = $"{Friend.FirstName} + {Friend.LastName}"
                });
        }

        private bool OnSaveCanExecute()
        {
            //TODO: Check if friend is valid
            return true;
        }

        private async void OnOpenFriendDatailView(int friendId)
        {
            await LoadAsync(friendId);
        }


    }
}
