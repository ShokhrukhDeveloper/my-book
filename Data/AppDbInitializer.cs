using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading;

namespace my_book.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context= serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Models.Book()
                    {
                        Title="1st Book Title",
                        Description="1st Book Description",
                        IsRead=true,
                        DateRead=DateTime.Now.AddDays(-10),
                        Rate=4,
                        Genre="Biograp",
                        Author="First author",
                        DateAdded=DateTime.Now,
                        CoverPicture = "Https===="

                        },
                       new Models.Book()
                    {
                        Title = "2st Book Title",
                        Description = "2st Book Description",
                        IsRead = false,
                        Rate = 4,
                        Genre = "Biograp",
                        Author = "Second author",
                        DateAdded = DateTime.Now,
                        CoverPicture="Https===="

                    }
                        );
                    context.SaveChanges();
                }
            }
        }
    }
}
