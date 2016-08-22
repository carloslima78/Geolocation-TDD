using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using DTO;
using BLL;

namespace TDD
{
    [TestClass]
    public class Friend
    {
        [TestMethod]
        public void Get_Not_Null_Friends()
        {
            var friendBO = new FriendBO();
            Assert.IsNotNull(friendBO.List());
        }

        [TestMethod]
        public void Get_Not_Null_Close_Friends()
        {
            var friendBO = new FriendBO();
            var allFriends = friendBO.List();

            foreach (var friend in allFriends)
            {
                friend.CloseFriends = new List<DTO.Friend>();
                friend.CloseFriends = friendBO.ListCloseFriends(friend.Localization, allFriends.Where(x => x.IdFriend != friend.IdFriend).ToList());
                Assert.IsNotNull(friend.CloseFriends);
            }

            Assert.IsNotNull(allFriends);
        }

        [TestMethod]
        public void Get_Close_Friends_Are_Equal_3()
        {
            var friendBO = new FriendBO();
            var allFriends = friendBO.List();

            foreach (var friend in allFriends)
            {
                friend.CloseFriends = new List<DTO.Friend>();
                friend.CloseFriends = friendBO.ListCloseFriends(friend.Localization, allFriends.Where(x => x.IdFriend != friend.IdFriend).ToList());
                Assert.AreEqual<Int32>(3, friend.CloseFriends.Count());
            }
        }
    }
}
