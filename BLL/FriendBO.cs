using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
using DAL;


namespace BLL
{
    public class FriendBO
    {
        public FriendBO ()
        { }

        public List<Friend> List()
        {
            try
            {
                var dao = new Persistence<Friend>();
                var friends = dao.List("SELECT IdFriend, Name, IdLocalization FROM Friend");

                var localizationBO = new LocalizationBO();

                foreach( var friend in friends)
                {                   
                    friend.Localization = new Localization();
                    friend.Localization = localizationBO.Get(friend.IdLocalization);
                }

                return friends;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Friend> ListCloseFriends (Localization localization, List<Friend> allFriends)
        {
            var localizationBO = new LocalizationBO();

            foreach (var friend in allFriends)
            {
                friend.RelativeDistance = localizationBO.Distance(localization, friend.Localization);
            }

            var closeFrients = allFriends.OrderBy(x => x.RelativeDistance).Take(3).ToList();

            return closeFrients;
        }
    }
}
