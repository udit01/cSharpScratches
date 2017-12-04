using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

namespace WebAPIClient
{   
    class program
    {
        static void Main(string[] args)
        {
            var repos = ProcessRepositories().Result;
            
            var count = 1;
            foreach(var repo in repos){
                Console.WriteLine($"Repository Number:{count}");
                Console.WriteLine(repo.Name);
                Console.WriteLine(repo.Description);
                Console.WriteLine(repo.GitHubHomeUrl);
                Console.WriteLine(repo.Homepage);
                Console.WriteLine(repo.Watchers);
                Console.WriteLine();
                count++;
            }
        }

        private static async Task<List<Repository>> ProcessRepositories(){
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var serializer = new DataContractJsonSerializer(typeof(List<Repository>));

            var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var repositories = serializer.ReadObject(await streamTask) as List<Repository>;
                
            return repositories;
            
            //Checker code
            // foreach (var repo in repositories)
            //     Console.WriteLine(repo.Name);
            
            /*
            var stringTask = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");
            var msg = await stringTask;
            // Console.Write(msg);
             */

        }
    }
}
