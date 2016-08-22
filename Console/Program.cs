using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DTO;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            FriendBO friendBO = new FriendBO();
            var allFriends = friendBO.List();

            foreach (var friend in allFriends)
            {
                friend.CloseFriends = new List<Friend>();
                friend.CloseFriends = friendBO.ListCloseFriends(friend.Localization, allFriends.Where( x => x.IdFriend != friend.IdFriend).ToList());

                 System.Console.WriteLine(String.Format(" {0}: {1} ", friend.Name, friend.Localization.Estate));
                
                foreach (var closeFriend in friend.CloseFriends)
                {
                    System.Console.WriteLine(String.Format(" - {0}: {1} ", closeFriend.Name, closeFriend.Localization.Estate));
                }

                System.Console.WriteLine();
            }

            System.Console.Read();
        }       
    }
}
