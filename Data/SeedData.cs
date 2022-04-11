using System.Globalization;
using csharp.Models;
using CsvHelper;
using CsvHelper.Configuration;

namespace csharp.Data;

public class SeedData {
	
    public static void Initialize(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()) {
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Games.Any()){
                return;  // DB has already been seeded
            }

            var games = GetGames();
            context.Games.AddRange(games);
            context.SaveChanges();
        }
    }

    // public static Game[] GetGames()
    //     {
    //         // Process CSV
    //         List<Game> games = new List<Game>();
    //         string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "olympics.csv");
            
    //         using (StreamReader sr = File.OpenText(path))
    //         {
    //             string? line;
    //             bool isFirstLine = true;
    
    //             while ((line = sr.ReadLine()) != null)
    //             {
    //                 string[] lineInfo = line.Split(','); 
    //                 if (!isFirstLine)
    //                 {
    //                     string[] gameInfo = lineInfo;
    //                     Game game = new Game()
    //                     {
    //                         Id = gameInfo[0],
    //                         City = gameInfo[1],
    //                         Country = gameInfo[2],
    //                         Continent = gameInfo[3],
    //                         Season = gameInfo[4],
    //                         Year = gameInfo[5],
    //                         Opening = gameInfo[6],
    //                         Closing = gameInfo[7]

    //                     };
    //                     games.Add(game);
    //                 }
    //                 isFirstLine = false;
    //             }
    //         }
    
    //         return games.ToArray();
    //     }

    public static IEnumerable<Game> GetGames() {

        string[] p = {Directory.GetCurrentDirectory(),"wwwroot","olympics.csv"};
        var csvFilePath = Path.Combine(p);
        var config = new CsvConfiguration(CultureInfo.InvariantCulture) { 
            PrepareHeaderForMatch = args => args.Header.ToLower(),
        };
        var data = new List<Game>().AsEnumerable();
        using (var reader = new StreamReader(csvFilePath)) {
            using (var csvReader = new CsvReader(reader, config)) 
                { data = (csvReader.GetRecords<Game>()).ToList();
            } 
        }
        
        return data;
    }
    
}