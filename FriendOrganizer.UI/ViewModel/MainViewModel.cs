using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
       

     public MainViewModel ( INavigationViewModel navigationViewModel,
         IFriendDatailViewModel friendDatailViewModel)
        {
            NavigationViewModel = navigationViewModel;
            FriendDatailViewModel = friendDatailViewModel;
        }
        public async Task LoadAsync()
        {
          await  NavigationViewModel.LoadAsync();
        }
        public INavigationViewModel NavigationViewModel { get;  }
        public IFriendDatailViewModel FriendDatailViewModel { get;  }
    }
}
