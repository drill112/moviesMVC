using moviesMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace moviesMVC.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext db)
        {
            if (!await db.Movies.AnyAsync())
            {
                var movies = new List<Movie>
                {
                    new() { Title="Oppenheimer", Director="Christopher Nolan", Genre="Drama", Year=2023, PosterUrl="/images/oppenheimer.jpg", Description="История создания ядерной бомбы." },
                    new() { Title="Dune: Part Two", Director="Denis Villeneuve", Genre="Sci-Fi", Year=2024, PosterUrl="/images/dune2.jpg", Description="Продолжение пути Пола Атрейдеса." },
                    new() { Title="Inside Out 2", Director="Kelsey Mann", Genre="Animation", Year=2024, PosterUrl="/images/insideout2.jpg", Description="Новые эмоции у повзрослевшей Райли." },
                    new() { Title="Barbie", Director="Greta Gerwig", Genre="Comedy", Year=2023, PosterUrl="/images/barbie.jpg", Description="Кукольный мир встречает реальность." },
                    new() { Title="John Wick: Chapter 4", Director="Chad Stahelski", Genre="Action", Year=2023, PosterUrl="/images/johnwick4.jpg", Description="Новый раунд охоты на Джона Уика." },
                    new() { Title="Godzilla Minus One", Director="Takashi Yamazaki", Genre="Action", Year=2023, PosterUrl="/images/godzilla_minus_one.jpg", Description="Годзилла в послевоенной Японии." },
                    new() { Title="Pirates of the Caribbean: The Curse of the Black Pearl", Director="Gore Verbinski", Genre="Adventure", Year=2003, PosterUrl="/images/pirates.jpg", Description="Капитан Джек Воробей в погоне за проклятым сокровищем." },
                    new() { Title="Spider-Man: Across the Spider-Verse", Director="Joaquim Dos Santos", Genre="Animation", Year=2023, PosterUrl="/images/spiderverse2.jpg", Description="Майлз Моралес и мультивселенная." },
                    new() { Title="The Super Mario Bros. Movie", Director="Aaron Horvath", Genre="Animation", Year=2023, PosterUrl="/images/mario.jpg", Description="Приключения Марио и Луиджи." },
                    new() { Title="Mission: Impossible – Dead Reckoning", Director="Christopher McQuarrie", Genre="Action", Year=2023, PosterUrl="/images/mi7.jpg", Description="Итан Хант против ИИ-угрозы." }
                };

                await db.Movies.AddRangeAsync(movies);
                await db.SaveChangesAsync();
                return;
            }

            var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["Oppenheimer"] = "/images/oppenheimer.jpg",
                ["Dune: Part Two"] = "/images/dune2.jpg",
                ["Inside Out 2"] = "/images/insideout2.jpg",
                ["Barbie"] = "/images/barbie.jpg",
                ["John Wick: Chapter 4"] = "/images/johnwick4.jpg",
                ["Godzilla Minus One"] = "/images/godzilla_minus_one.jpg",
                ["Pirates of the Caribbean: The Curse of the Black Pearl"] = "/images/pirates.jpg",
                ["Spider-Man: Across the Spider-Verse"] = "/images/spiderverse2.jpg",
                ["The Super Mario Bros. Movie"] = "/images/mario.jpg",
                ["Mission: Impossible – Dead Reckoning"] = "/images/mi7.jpg"
            };

            var changed = false;
            foreach (var m in db.Movies)
            {
                if (map.TryGetValue(m.Title, out var path) && m.PosterUrl != path)
                {
                    m.PosterUrl = path;
                    changed = true;
                }
            }
            if (changed) await db.SaveChangesAsync();
        }
    }
}
