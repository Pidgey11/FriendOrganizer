using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        private Func<FriendOrganizerDbContext> _contextCreator;

        public FriendDataService(Func<FriendOrganizerDbContext> contexCreator )
        {
            _contextCreator = contexCreator;
        }
        public async Task<Friend> GetByIdAsync(int friendID)
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Friends.AsNoTracking().SingleAsync(f => f.Id == friendID);
               }
        }
    }
}
