using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Day03.Task.Models;

namespace Day03.Task.Infrastructure
{
    public class UserRepository
    {
        private IList<User> users;
        private static readonly UserRepository instance = new UserRepository();

        public UserRepository()
        {
            this.users = new List<User>();
            this.users.Add(new User()
            {
                Id = "1",
                Name = "Good man",
                Side = Side.white
            });
            this.users.Add(new User()
            {
                Id = "2",
                Name = "Bad man",
                Side = Side.black
            });
        }

        public static UserRepository Instance => instance;

        public void ChangeSide(User user, Side side)
        {
            var foundUser = users.SingleOrDefault( u => u.Id == user.Id);
            if (foundUser != null)
                foundUser.Side = side;
        }

        public User GetById(string id)
        {
            return this.users.FirstOrDefault(u => u.Id.Equals(id));
        }

        public IList<User> GetAll()
        {
            return this.users;
        }
    }
}