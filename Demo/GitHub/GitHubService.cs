using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xamarin.Essentials;

namespace Demo.GitHub
{
    public class GitHubService : IGitHubService
    {
        HttpClient client;

        public GitHubService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.GitHubUrl}/");
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public async Task<IEnumerable<User>> SearchUsersAsync(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString) && IsConnected)
            {
                try
                {
                    //Search for a string in email, real name or username
                    //See https://docs.github.com/en/rest/reference/search#search-users and
                    //https://docs.github.com/en/github/searching-for-information-on-github/searching-on-github/searching-users for more details

                    var query = Uri.EscapeUriString($"\"{searchString.Trim()}\" in:email OR \"{searchString.Trim()}\" in:name OR \"{searchString.Trim()}\" in:login");

                    var json = await client.GetStringAsync($"search/users?q={query}");

                    JObject parsedJson = JObject.Parse(json);
                    IList<JToken> userItems = parsedJson["items"].Children().ToList();

                    var users = userItems.Select(u => u.ToObject<User>());

                    return users;
                }
                catch (Exception ex)
                {
                    //Handle the proper exception here
                    throw;
                }
            }

            return null;
        }
    }
}
