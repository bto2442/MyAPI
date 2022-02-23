using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebAPIClient
{
    public class Film
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("rt_score")]
        public string Score { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("release_date")]
        public string Release { get; set; }
    }

    class Program

    {
        private static readonly HttpClient client = new HttpClient();


        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }

        private static async Task ProcessRepositories()
        {
            var allFilms = await client.GetAsync("https://ghibliapi.herokuapp.com/films");
            var allFilmsRead = await allFilms.Content.ReadAsStringAsync();
            var films = JsonConvert.DeserializeObject <List<Film>>(allFilmsRead);

            while (true)
            {
                try
                {
                    var filmIndex = -1;

                    Console.WriteLine("Enter a Studio Ghibli film name to get information about it! Press Enter without writing anything to quit the program.");

                    var ghibliName = Console.ReadLine();

                    if (string.IsNullOrEmpty(ghibliName))
                    {
                        Console.WriteLine("Goodbye!");
                        break;
                    }
                    
                    for (int i = 0; i < films.Count; i++)
                    {
                        if (films[i].Title.ToLower().Equals(ghibliName.ToLower()))
                            filmIndex = i;
                    }
                    if (filmIndex == -1)
                    {
                        Console.WriteLine("ERROR. Please enter a valid film name! \n");
                    }
                    if (filmIndex != -1)
                    {
                        Console.WriteLine("___ \n");
                        Console.WriteLine("Film Name: " + films[filmIndex].Title);
                        Console.WriteLine("Release Date: " + films[filmIndex].Release);
                        Console.WriteLine("Rotten Tomatoes Score: " + films[filmIndex].Score);
                        Console.WriteLine("Description: " + films[filmIndex].Description);
                        Console.WriteLine("\n---");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR. Please enter a valid film name! \n");
                }
            }
        }
    }
}
