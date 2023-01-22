using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class AddFriendView
    {
        UserService userService;
        FriendService friendService;
        public AddFriendView(FriendService friendService, UserService userService)
        {
            this.friendService = friendService;
            this.userService = userService;
        }

        public void Show(User user)
        {
            var addFriendData = new AddFriendData();

            Console.Write("Введите почтовый адрес друга: ");
            addFriendData.FriendEmail = Console.ReadLine();

            addFriendData.UserId = user.Id;

            try
            {
                friendService.AddFriend(addFriendData);

                SuccessMessage.Show("Друг добавлен!");

                user = userService.FindById(user.Id);
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлении в друзья!");
            }

        }
    }
}
