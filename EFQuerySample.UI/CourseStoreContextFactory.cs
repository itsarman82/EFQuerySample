
using EFQuerySample.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFQuerySample.UI
{
    class CourseStoreContextFactory : IDesignTimeDbContextFactory<CourseStoreDbContext>
    {
        public CourseStoreDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<CourseStoreDbContext>();
            optionBuilder.UseSqlServer("Server=.; Database=CourseDB; TrustServerCertificate=True; User Id=sa; Password=armanz582");

            CourseStoreDbContext ctx = new CourseStoreDbContext(optionBuilder.Options);
            return ctx;
        }
    }
}
