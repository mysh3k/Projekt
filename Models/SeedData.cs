using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                if (context.Movie.Any())
                {
                    return;
                }

                Movie m1 = new Movie
                {
                    Title = "C#",
                    Description = "C# related forum.",
                };

                Movie m2 = new Movie
                {
                    Title = "Python",
                    Description = "Forum about snakes",
                };

                Movie m3 = new Movie
                {
                    Title = "Java",
                    Description = "Script",
                };

                Movie m4 = new Movie
                {
                    Title = "Lua",
                    Description = "???",
                };

                Movie[] seedMovies = { m1, m2, m3, m4 };
                context.Movie.AddRange(seedMovies);
                context.SaveChanges();

                User u1 = new User
                {
                    Login = "root",
                    Password = "root",
                    Username = "Administrator",
                    Permissions = true,
                };
                User u2 = new User
                {
                    Login = "user1",
                    Password = "user1",
                    Username = "Użytkownik1",
                    Permissions = false,
                };
                User u3 = new User
                {
                    Login = "student",
                    Password = "student",
                    Username = "StudentWSEI",
                    Permissions = false,
                };
                User u4 = new User
                {
                    Login = "hacker",
                    Password = "fajnie",
                    Username = "Niesamowite",
                    Permissions = true,
                };
                User[] seedUsers = { u1, u2, u3, u4 };
                context.User.AddRange(seedUsers);
                context.SaveChanges();


                Post p1 = new Post
                {
                    MovieID = seedMovies.Single(m => m.Title == "C#").Id,
                    UserID = seedUsers.Single(u => u.Login == "student").Id,
                    Thread = "Projekt",
                    Contents = "Wie ktoś jak wykonać projekt na zaliczenie?",
                };

                Post p2 = new Post
                {
                    MovieID = seedMovies.Single(m => m.Title == "Python").Id,
                    UserID = seedUsers.Single(u => u.Login == "root").Id,
                    Thread = "Pyton vs anakonda",
                    Contents = "Który wąż według was jest lepszy? Moim faworytem jest padalec",
                };

                Post p3 = new Post
                {
                    MovieID = seedMovies.Single(m => m.Title == "Java").Id,
                    UserID = seedUsers.Single(u => u.Login == "hacker").Id,
                    Thread = "Java??",
                    Contents = "Czy kod pisany w javie to javascript?",
                };

                Post p4 = new Post
                {
                    MovieID = seedMovies.Single(m => m.Title == "Lua").Id,
                    UserID = seedUsers.Single(u => u.Login == "user1").Id,
                    Thread = "Pętla for",
                    Contents = "for x=0, 5 do nothing(x) end",
                };
                Post p5 = new Post
                {
                    MovieID = seedMovies.Single(m => m.Title == "C#").Id,
                    UserID = seedUsers.Single(u => u.Login == "user1").Id,
                    Thread = "Który język lepszy?",
                    Contents = "Co według was jest lepsze C# czy cokolwiek innego?",
                };
                Post p6 = new Post
                {
                    MovieID = seedMovies.Single(m => m.Title == "Python").Id,
                    UserID = seedUsers.Single(u => u.Login == "hacker").Id,
                    Thread = "Django czy flask",
                    Contents = "Który framework jest według was lepszy do postawienia małej aplikacji?",
                };
                Post p7 = new Post
                {
                    MovieID = seedMovies.Single(m => m.Title == "Java").Id,
                    UserID = seedUsers.Single(u => u.Login == "student").Id,
                    Thread = "Skrypt",
                    Contents = "Zna się tutaj ktoś na javie? Bo potrzebuje skryptu do mojej strony",
                };
                Post[] seedPosts = { p1, p2, p3, p4, p5, p6, p7 };
                context.Post.AddRange(seedPosts);
                context.SaveChanges();

                Reply r1 = new Reply
                {
                    PostID = seedPosts.Single(p => p.Thread == "Projekt").Id,
                    Contents = "Ja też nie mam pojęcia, trzeba komuś zapłacić na jakimś fiverrze chyba",
                };
                Reply r2 = new Reply
                {
                    PostID = seedPosts.Single(p => p.Thread == "Projekt").Id,
                    Contents = "Zdecydowanie tak trzeba, oby trója wpadła chociaż",
                };
                Reply r3 = new Reply
                {
                    PostID = seedPosts.Single(p => p.Thread == "Pyton vs anakonda").Id,
                    Contents = "Padalec to nie wąż młotku, za to ja lubie gniewosza plamistego",
                };
                Reply r4 = new Reply
                {
                    PostID = seedPosts.Single(p => p.Thread == "Pyton vs anakonda").Id,
                    Contents = "Jak nie wąż to co niby?!",
                };
                Reply r5 = new Reply
                {
                    PostID = seedPosts.Single(p => p.Thread == "Java??").Id,
                    Contents = "Oczywiście, a dodawanie w C to C++",
                };
                Reply r6 = new Reply
                {
                    PostID = seedPosts.Single(p => p.Thread == "Pętla for").Id,
                    Contents = "Ale co to ma niby robić?",
                };
                Reply r7 = new Reply
                {
                    PostID = seedPosts.Single(p => p.Thread == "Pętla for").Id,
                    Contents = "Pięć razy nic",
                };
                Reply r8 = new Reply
                {
                    PostID = seedPosts.Single(p => p.Thread == "Który język lepszy?").Id,
                    Contents = "Zdecydowanie wszystko inne",
                };
                Reply r9 = new Reply
                {
                    PostID = seedPosts.Single(p => p.Thread == "Django czy flask").Id,
                    Contents = "Do małej apki lepszy powinien być flask",
                };
                Reply r10 = new Reply
                {
                    PostID = seedPosts.Single(p => p.Thread == "Skrypt").Id,
                    Contents = "Już mi się nie chce wymyślać głupot",
                };
                Reply r11 = new Reply
                {
                    PostID = seedPosts.Single(p => p.Thread == "Skrypt").Id,
                    Contents = "Próba mikrofonu",
                };

                Reply[] seedReplies = { r2, r1, r4, r3, r5, r7, r6, r8, r9, r11, r10 };
                context.Reply.AddRange(seedReplies);
                context.SaveChanges();

            }
        }
    }
}