using DemoWebApp.Models;

namespace DemoWebApp.Db
{
    public static class GamesDb
    {
        public static List<GameViewModel> Games { get; set; } 

        //method that adds data to the list
        public static void Seed()
        {
            Games = new List<GameViewModel>();

            GameViewModel game1 = new GameViewModel
            {
                Id = 1,
                Category = CategoryEnum.Sports,
                Developers = "EA Games",
                Name = "FIFA",
                Description = "Football game",
                PEGI = 7
            };

            Games.Add(game1);

            Games.Add(new GameViewModel
            {
                Id = 2,
                Category = CategoryEnum.FPS,
                Developers = "Valve",
                Name = "CS-GO",
                Description = "First person game",
                PEGI = 16
            });

            Games.Add(new GameViewModel
            {
                Id = 3,
                Category = CategoryEnum.FPS,
                Developers = "Blizard",
                Name = "Cod",
                Description = "First person game",
                PEGI = 13
            });

            Games.Add(new GameViewModel
            {
                Id = 4,
                Category = CategoryEnum.Strategy,
                Developers = "Paradox Development Studio",
                Name = "Hearts of Iron IV",
                Description = "WW2 Grand Strategy Video game",
                PEGI = 16
            });

            Games.Add(new GameViewModel
            {
                Id = 5,
                Category = CategoryEnum.FPS,
                Developers = "Facepunch Development Studio",
                Name = "Rust",
                Description = "Open world survival game",
                PEGI = 18
            });

            Games.Add(new GameViewModel
            {
                Id = 6,
                Category = CategoryEnum.Sports,
                Developers = "EA Games",
                Name = "FIFA 2023",
                Description = "Football game",
                PEGI = 7
            });
        }
    }
}
