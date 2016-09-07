using System;
using System.Collections.Generic;
using System.Linq;
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
                Name = "Yoda",
                Side = Side.Light
            });
            this.users.Add(new User()
            {
                Id = "2",
                Name = "Darth Vader",
                Side = Side.Dark
            });
        }

        public static UserRepository Instance => instance;

        public void ChangeSide(User user)
        {
            if (user != null)
            {

                Side newSide = Side.Dark;
                if (user.Side == Side.Dark)
                {
                    newSide = Side.Light;
                }
                var foundUser = users.SingleOrDefault(u => u.Id == user.Id);
                if (foundUser != null)
                    foundUser.Side = newSide; //check!!!
            }
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