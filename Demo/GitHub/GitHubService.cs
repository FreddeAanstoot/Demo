using System;
using System.Collections.Generic;

namespace Demo.GitHub
{
    public class GitHubService : IGitHubService
    {
        public GitHubService()
        {

        }

        public IEnumerable<User> GetUsers()
        {
            var users = new List<User> {
                    new User { Id = 1, Login = "JohnDoe" },
                    new User { Id = 2, Login = "AdamSmith" },
                };

            return users;
        }

        public IEnumerable<User> GetUsers(string query)
        {
            var users = new List<User> {
                    new User { Id = 1, Login = "JohnDoe" },
                    new User { Id = 2, Login = "AdamSmith" },
                };

            return users;
        }
    }
}
