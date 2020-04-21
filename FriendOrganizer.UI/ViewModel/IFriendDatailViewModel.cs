using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
     public interface IFriendDatailViewModel
    {
        Task LoadAsync(int friendId);
    }
}