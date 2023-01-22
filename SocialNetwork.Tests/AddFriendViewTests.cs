using NUnit.Framework;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Views;

namespace SocialNetwork.Tests
{
    [TestFixture]
    public class AddFriendViewTests
    {
        [Test]
        public void AddFriendMustThrowException()
        {
            var addFriendDataTest = new AddFriendData();
            var friendService = new FriendService();
            addFriendDataTest.FriendEmail = "wrong format";
            addFriendDataTest.UserId = 1; 
            
            Assert.Throws<UserNotFoundException>(() => friendService.AddFriend(addFriendDataTest));
        }
    }
}