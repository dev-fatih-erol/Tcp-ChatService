using ChatService.Client.Models;

namespace ChatService.Client.Services
{
    public class UserService
	{
        private static readonly List<User> _users = new();

        public static void Add(User user)
        {
            _users.Add(user);
        }

        public static void Replace(User user)
        {
            int index = _users.FindIndex(s => s.Id == user.Id);
            if (index != -1)
                _users[index] = user;
        }

        public static User Get(Guid id)
        {
            return _users.First(s => s.Id == id);
        }

        public static void Remove(User user)
        {
            _users.Remove(user);
        }
    }
}