using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuerySample.Dal
{
    public class PracticeRepo
    {
        private readonly CourseStoreDbContext _context;

        public PracticeRepo(CourseStoreDbContext courseStoreDbContext)
        {
            _context = courseStoreDbContext;
        }

        // practice 2

        public void firstPractice()
        {
            var resault = _context.Courses
                .Include(c => c.Comments
                    .Take(3))
                .ToList();

            foreach (var course in resault)
            {
                Console.WriteLine($"Course name : {course.Name}");

                foreach (var comment in course.Comments)
                {
                    Console.WriteLine($"{comment.CommentBy} : {comment.CommentText}, {comment.StarCount}, {comment.IsApproved}");
                }
            }
        }

        public void secondPractice()
        {
            var resault = _context.Courses
                .Include(c => c.Comments
                    .Where(c => c.IsApproved == true))
                .ToList();

            foreach (var course in resault)
            {
                Console.WriteLine($"Course name : {course.Name}");

                foreach (var comment in course.Comments)
                {
                    Console.WriteLine($"{comment.CommentBy} : {comment.CommentText}, {comment.StarCount}, {comment.IsApproved}");
                }
            }
        }

        public void thirdPractice()
        {
            var resault = _context.Courses
                .ToList();

            foreach (var course in resault)
            {
                Console.WriteLine($"Course name : {course.Name}");
                _context.Courses
                    .Include(c => c.Comments
                        .Take(3))
                    .Load();

                foreach (var comment in course.Comments)
                {
                    Console.WriteLine($"{comment.CommentBy} : {comment.CommentText}, {comment.StarCount}, {comment.IsApproved}");
                }
            }
        }

        public void forthPractice()
        {
            var resault = _context.Courses
                .ToList();

            foreach (var course in resault)
            {
                Console.WriteLine($"Course name : {course.Name}");
                _context.Courses
                    .Include(c => c.Comments
                        .Where(c => c.IsApproved == true))
                    .Load();

                foreach (var comment in course.Comments)
                {
                    Console.WriteLine($"{comment.CommentBy} : {comment.CommentText}, {comment.StarCount}, {comment.IsApproved}");
                }
            }
        }

        public void fifthPractice()
        {
            var resualt = _context.Courses;

            foreach (var course in resualt)
            {
                Console.WriteLine($"{course.Name} {course.Description} {course.Price} {course.Tags}");
            }
        }
    }
}
