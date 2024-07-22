using EFQuerySample.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFQuerySample.Dal
{
    public class CourseStoreDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<CourseTeachers> CourseTeachers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        public CourseStoreDbContext(DbContextOptions<CourseStoreDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
