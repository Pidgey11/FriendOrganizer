using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    class FriendDatailViewModel : ViewModelBase, IFriendDatailViewModel
    {
        private IFriendDataService _dataservice;
        public FriendDatailViewModel(IFriendDataService dataService)
        {
            _dataservice = dataService;
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
    }
}
