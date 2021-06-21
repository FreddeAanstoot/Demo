using System;
using System.Collections.Generic;

namespace Demo.GitHub
{
    public interface IGitHubService
    {
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUsers(string query);
    }
}
