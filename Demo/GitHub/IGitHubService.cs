using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.GitHub
{
    public interface IGitHubService
    {
        Task<IEnumerable<User>> SearchUsersAsync(string searchString);
    }
}
