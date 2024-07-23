using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFQuerySample.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFQuerySample.Dal
{
    public class CourseStoreRepository
    {
        private readonly CourseStoreDbContext _context;
        public CourseStoreRepository(CourseStoreDbContext courseStoreDbContext)
        {
            _context= courseStoreDbContext;
        }

        // Eager loading methods examples

        public void PrintCourceAndTeachersEager()
        {
            var resualt = _context.Courses
                .Include(c => c.CourseTeachers)
                .ThenInclude(c => c.Teacher)
                .ToList();
            foreach (var course in resualt)
            {
                Console.WriteLine($"Course :  {course.Name}");
                foreach (var teacher in course.CourseTeachers)
                {
                    Console.WriteLine($"Teachers : {teacher.Teacher.Name} {teacher.Teacher.LastName}");
                }
            }
        }

        public void PrintCourceAndTeachersAndTagsEager()
        {
            var resualt = _context.Courses
                .Include(c => c.CourseTeachers
                    .OrderBy(c=>c.SortOrder))
                .ThenInclude(c => c.Teacher)
                .Include(c=>c.Tags)
                .ToList();

            foreach (var course in resualt)
            {
                Console.WriteLine($"Course :  {course.Name}");

                foreach (var teacher in course.CourseTeachers)
                {
                    Console.WriteLine($"Teachers : {teacher.Teacher.Name} {teacher.Teacher.LastName}");
                }

                foreach (var courseTag in course.Tags)
                {
                    Console.WriteLine($"Tag {courseTag.Id} : {courseTag.Name}");
                }
            }
        }

        // Explicit loading methods examples

        public void PrintCourceAndTeachersExplicit()
        {
            var resualt = _context.Courses
                .ToList();
            foreach (var course in resualt)
            {
                Console.WriteLine($"Course :  {course.Name}");
                _context.Entry(course)
                    .Collection(c => c.CourseTeachers)
                    .Load();
                
                foreach (var teacher in course.CourseTeachers)
                {
                    _context.Entry(teacher)
                        .Reference(c => c.Teacher)
                        .Load();
                    Console.WriteLine($"Teachers : {teacher.Teacher.Name} {teacher.Teacher.LastName}");
                }
            }
        }

        public void PrintCourceAndTeachersAndTagsExplicit()
        {
            var resualt = _context.Courses
                .ToList();
            foreach (var course in resualt)
            {
                Console.WriteLine($"Course :  {course.Name}");
                _context.Entry(course)
                    .Collection(c => c.CourseTeachers)
                    .Load();

                foreach (var teacher in course.CourseTeachers)
                {
                    _context.Entry(teacher)
                        .Reference(c => c.Teacher)
                        .Load();
                    Console.WriteLine($"Teachers : {teacher.Teacher.Name} {teacher.Teacher.LastName}");
                }

                _context.Entry(course)
                    .Collection(c => c.Tags)
                    .Load();

                foreach (var courseTag in course.Tags)
                {
                    Console.WriteLine($"Tag {courseTag.Id} : {courseTag.Name}");
                }
            }
        }

        // Select loading methods examples

        public void CourseShortInfoDtoSelectLoading()
        {
            var resualt = _context.Courses
                .Select(c => new CourseShortInfoDto
                {
                    Name = c.Name,
                    Id = c.Id
                });
            foreach (var course in resualt)
            {
                Console.WriteLine($"Course :  {course.Name}");
            }
        }

        // client vs server method

        public void CourseClientVsServer()
        {
            var resualt = _context.Courses.Include(c => c.Tags)
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.StartDate,
                    Tags = string.Join(',', c.Tags)
                });

            foreach (var item in resualt)
            {
                Console.WriteLine($"{item.Name} : {item.Tags}");
            }
        }
    }
}
