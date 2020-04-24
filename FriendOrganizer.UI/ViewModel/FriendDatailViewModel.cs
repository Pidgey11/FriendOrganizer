using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
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

        public FriendDatailViewModel(IFriendDataService dataService,
            IEventAggregator eventAggregator)
        {
            _dataservice = dataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenFriendDatailViewEvent>()
                .Subscribe(OnOpenFriendDatailView);
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private async void OnSaveExecute()
        {

           await _dataservice.SaveAsync(Friend);
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

        public async Task LoadAsync(int friendId)
        {
            Friend = await _dataservice.GetByIdAsync(friendId);
        }
        private Friend _friend;
        public Friend Friend
        {
            get { return _friend; }
            private set
            {
                _friend = value;
                OnPropertyChange();
            }
        }
        public ICommand SaveCommand { get;  }
    }
}
