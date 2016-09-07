using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Day02.Task.Attributes.Models;

namespace Day02.Task.Attributes.Infrastructure
{
    public class UserRepository
    {
        private IList<User> users;
        private static readonly UserRepository instance;

        public UserRepository()
        {
            this.users = new List<User>();
        }

        public static UserRepository Instance => instance;

        public async System.Threading.Tasks.Task Add(User user)
        {
            await System.Threading.Tasks.Task.Run(() => this.users.Add(user));
        }

        public async Task<bool> Remove(string id)
        {
            return await System.Threading.Tasks.Task.Run(() => this.users.Remove(this.users.Where(c => c.Id == id).SingleOrDefault()));
        }
        public IList<User> GetAll()
        {
            return this.users;
        }
    }
}