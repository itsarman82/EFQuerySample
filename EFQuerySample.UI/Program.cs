using EFQuerySample.Dal;
using Microsoft.EntityFrameworkCore;

namespace EFQuerySample.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<CourseStoreDbContext>();
            optionBuilder.UseSqlServer("Server=.; Database=CourseDB; TrustServerCertificate=True; User Id=sa; Password=armanz582");

            using CourseStoreDbContext ctx = new CourseStoreDbContext(optionBuilder.Options);

            CourseStoreRepository repository = new CourseStoreRepository(ctx);

            repository.CourseShortInfoDtoSelectLoading();
            Console.ReadKey();
        }
    }
}
